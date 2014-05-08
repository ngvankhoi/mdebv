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
using MifareTest;

namespace Medisoft
{
	/// <summary>
	/// Summary description for frmXuatvien.
	/// </summary>
	public class frmTiepdon_scard : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private LibMedi.AccessData m;
		private LibDuoc.AccessData d;
		private LibVienphi.AccessData v;
        private int i_maxlength_mabn = 8;
		//private Doisototext doiso;
        numbertotext doiso;
		private DataSet ds=new DataSet();
		private DataSet dsxml=new DataSet();
		private DataSet dslien=new DataSet();
		private DataSet dsdt=new DataSet();
		private DataSet dshn=new DataSet();
		private DataTable dtnkp=new DataTable();
		private DataTable dttkham=new DataTable();
		private DataTable dtbs=new DataTable();
		private DataSet dsloai=new DataSet();
		private DataSet dsbnmoi=new DataSet();
		private DataSet dsbdien=new DataSet();
        private string user, nam = "", s_userid, s_makp, s_mabn, s_msg, s_ngayvv, sql, s_kyhieu, s_maqu, ma_vantay, s_madoituong, s_path, ngaysrv, pathImage, FileType,pathSave,file="",_mabvso;
        private int i_userid, i_maba, iChidinh, hh1, hh2, hh3, mm1, mm2, mm3,i_madoituong_ng,imavp_the,i_useridvp;
		private long l_maql=0,l_id=0;
		private decimal d_dongia,d_mien,d_vattu;
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
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.Button butKetthuc;
		private int songay=30,iTreem6,iTreem15,iKhamnhi,iLoai,i_loai,i_sohieu,i_sokham,iChuyendoituong1,iChuyenmavp,iChuyendoituong2, i_khudt=0;
        private bool b_Edit = false, b_Hoten = false, bAdmin, bInkhambenh, bDanhsach, bSobienlai, bSuagiakham, bInphieudieutri, bKhamthai, bChuyenkhoasan, bHonnhan, bLydokham, bKhongintienkham, bLuachontienkham, bVantay, bBacsy, bKyhieu_chung, bNew, b_trongngoai, bDenngay_sothe, bQuan01, bLoad_tiepdon, bTungay, bBangdien, bNoigioithieu, bVantay_mabntudong, bDssothe, bTudong = false, b701306, bDocmavach, bSothe_mabn, bMabn_tudong, bHinh, bThuphi_kham, bGoi, bChonhinh, bThutien_the, bChuyendoituong, bKyhieu_may, bDangky_bsbv, bBienlai_mien, bIn1lan, bBhyt1kham, bSmartcard;
		private System.ComponentModel.IContainer components=null;
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
		private System.Windows.Forms.ComboBox tendoituong;
		private MaskedTextBox.MaskedTextBox qh_dienthoai;
		private System.Windows.Forms.TextBox qh_diachi;
		private System.Windows.Forms.TextBox qh_hoten;
		private System.Windows.Forms.TextBox quanhe;
		private MaskedTextBox.MaskedTextBox sovaovien;
		private System.Windows.Forms.Label label30;
		private System.Windows.Forms.Label label29;
		private System.Windows.Forms.Label label28;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.TextBox makp;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label53;
		private System.Windows.Forms.Panel pvaovien;
		private MaskedBox.MaskedBox ngayvv;
		private MaskedBox.MaskedBox denngay;
		private MaskedBox.MaskedBox ngaysinh;
		private LibList.List list;
		private MaskedTextBox.MaskedTextBox mabv;
		private System.Windows.Forms.TextBox tenbv;
        private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label lkyhieu;
		private System.Windows.Forms.Label lsobienlai;
		private System.Windows.Forms.ComboBox kyhieu;
		private MaskedTextBox.MaskedTextBox sobienlai;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.DomainUpDown dongia;
		private System.Windows.Forms.ComboBox bnmoi;
		private System.Windows.Forms.Label l_bnmoi;
        private System.Windows.Forms.CheckedListBox n_makp;
		private System.Windows.Forms.Button butInbarcode;
		private System.Windows.Forms.Panel khamthai;
		private System.Windows.Forms.Label label9;
		private MaskedTextBox.MaskedTextBox para1;
		private MaskedTextBox.MaskedTextBox para2;
		private MaskedTextBox.MaskedTextBox para3;
		private MaskedTextBox.MaskedTextBox para4;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox dacdiem;
		private MaskedBox.MaskedBox kinhcc;
		private MaskedBox.MaskedBox ngaysanh;
		private MaskedTextBox.MaskedTextBox lydo;
		private System.Windows.Forms.Panel dausinhton;
		private MaskedBox.MaskedBox nhietdo;
		private MaskedTextBox.MaskedTextBox huyetap;
		private MaskedTextBox.MaskedTextBox mach;
		private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label lhonnhan;
		private System.Windows.Forms.ComboBox honnhan;
		private System.Windows.Forms.Label llydo;
		private System.Windows.Forms.Label ltienkham;
		private System.Windows.Forms.ComboBox tienkham;
        private System.Windows.Forms.PictureBox ptb;
		private System.Windows.Forms.Button butKyhieu;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.TextBox dt_nha;
		private System.Windows.Forms.Panel pdienthoai;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.TextBox dt_coquan;
		private System.Windows.Forms.TextBox dt_didong;
		private System.Windows.Forms.TextBox dt_email;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Label label31;
		private System.Windows.Forms.Panel pmien;
		private System.Windows.Forms.Label label32;
		private System.Windows.Forms.Label label33;
		private System.Windows.Forms.ComboBox lydomien;
		private System.Windows.Forms.ComboBox duyet;
		private System.Windows.Forms.TextBox tenbs;
		private System.Windows.Forms.TextBox mabs;
		private LibList.List listBS;
		private System.Windows.Forms.Label lbacsy;
		private System.Windows.Forms.Label label34;
		private System.Windows.Forms.ComboBox loai;
		private FingerApp.FrmNhanDang fnhandang;
		private System.Windows.Forms.Label label35;
		private MaskedBox.MaskedBox tungay;
		private System.Windows.Forms.TextBox matienkham;
		private LibList.List listdstt;
		private System.Windows.Forms.Label label36;
		private MaskedTextBox.MaskedTextBox madstt;
		private System.Windows.Forms.TextBox tendstt;
		private LibList.List listSothe;
		private System.Windows.Forms.TextBox sothe;
        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButton1;
        private ToolStripButton toolStripButton2;
        private ToolStripButton toolStripButton3;
        private ToolStripButton toolStripButton4;
        private ToolStripButton tbutvantay;
        private ToolStripLabel tlbl;
        private dllReportM.Print print = new dllReportM.Print();
        private Label label37;
        private MaskedBox.MaskedBox giovv;
        private CheckBox chkXem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripSeparator toolStripSeparator4;
        //private AxBARCODELib.AxBarcode barcode;
        private Label label42;
        private Button button1;
        private Button button2;
        private PictureBox pic;
        private ComboBox phai;
        private Label label44;
        private Label label43;
        private PictureBox pictureBox2;
        private Label label38;
        private byte[] image;
        private System.IO.MemoryStream memo;
        private System.IO.FileStream fstr;
        private Bitmap map;
        private PictureBox pBarcode;
        private CheckBox chkDieutri;
        private Panel pgoi;
        private Button butGoilai;
        private Button butGoi;
        private NumericUpDown sonhay;
        private NumericUpDown den;
        private NumericUpDown tu;
        private Label label50;
        private Label label39;
        private Label label40;
        private MaskedTextBox.MaskedTextBox bmi;
        private MaskedTextBox.MaskedTextBox chieucao;
        private MaskedTextBox.MaskedTextBox cannang;
        private Label label45;
        private Label linthe;
        private CheckBox chkxml;
        private Label lbienlaithe;
        private Label lbs;
        private TextBox bacsy;
        private Label lbv;
        private TextBox benhvien;
        private ToolTip toolTip1;
        private LibList.List listbv;
        private LibList.List listbs1;
        private Panel pnmakp;
        private DataGrid dataGrid1;
        private DataTable dtletet = new DataTable();
        private Brush disabledBackBrush;
        private Brush disabledTextBrush;
        private Brush alertBackBrush;
        private Font alertFont;
        private Brush alertTextBrush;
        private Font currentRowFont;
        private Brush currentRowBackBrush;
        private bool afterCurrentCellChanged, bTiepdon_ngoaitru;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripButton toolStripButton5;
        private CheckBox chkNgoaitru;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripButton toolStripButton6;
        private Button butSmartcard;
        private int checkCol = 0;        
        MifareTest.clsSmartcart clsSMCart = new MifareTest.clsSmartcart();
        clsDoitiengviet c = new clsDoitiengviet();
        private ToolStripButton toolStripButton7;
        private ToolStripSeparator toolStripSeparator7;
        private AxMIFARES50_HSA.AxMIFARES50 MIFARES501;
        string strUID = "";

		public frmTiepdon_scard(LibMedi.AccessData acc,string makp,string hoten,int userid,int sohieu,int loai,string _madoituong, int _khudieutri)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
            m = acc; s_makp = makp; s_madoituong = _madoituong; if (m.bBogo) tv.GanBogo(this, textBox111);
			s_userid=hoten;i_userid=userid;i_loai=loai;
			i_sohieu=sohieu;d=new LibDuoc.AccessData();
			v=new LibVienphi.AccessData();
            i_khudt = _khudieutri;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTiepdon_scard));
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
            this.butBoqua = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.phanhchinh = new System.Windows.Forms.Panel();
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
            this.pvaovien = new System.Windows.Forms.Panel();
            this.chkNgoaitru = new System.Windows.Forms.CheckBox();
            this.pnmakp = new System.Windows.Forms.Panel();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.n_makp = new System.Windows.Forms.CheckedListBox();
            this.benhvien = new System.Windows.Forms.TextBox();
            this.listbv = new LibList.List();
            this.bacsy = new System.Windows.Forms.TextBox();
            this.lbv = new System.Windows.Forms.Label();
            this.listbs1 = new LibList.List();
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
            this.mabs = new System.Windows.Forms.TextBox();
            this.qh_dienthoai = new MaskedTextBox.MaskedTextBox();
            this.qh_hoten = new System.Windows.Forms.TextBox();
            this.lbs = new System.Windows.Forms.Label();
            this.denngay = new MaskedBox.MaskedBox();
            this.chkxml = new System.Windows.Forms.CheckBox();
            this.dongia = new System.Windows.Forms.DomainUpDown();
            this.sobienlai = new MaskedTextBox.MaskedTextBox();
            this.lydo = new MaskedTextBox.MaskedTextBox();
            this.llydo = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.kyhieu = new System.Windows.Forms.ComboBox();
            this.lkyhieu = new System.Windows.Forms.Label();
            this.butKyhieu = new System.Windows.Forms.Button();
            this.matienkham = new System.Windows.Forms.TextBox();
            this.tienkham = new System.Windows.Forms.ComboBox();
            this.lsobienlai = new System.Windows.Forms.Label();
            this.ltienkham = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.mabv = new MaskedTextBox.MaskedTextBox();
            this.label53 = new System.Windows.Forms.Label();
            this.dausinhton = new System.Windows.Forms.Panel();
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
            this.honnhan = new System.Windows.Forms.ComboBox();
            this.lhonnhan = new System.Windows.Forms.Label();
            this.madstt = new MaskedTextBox.MaskedTextBox();
            this.tendstt = new System.Windows.Forms.TextBox();
            this.ngayvv = new MaskedBox.MaskedBox();
            this.giovv = new MaskedBox.MaskedBox();
            this.label37 = new System.Windows.Forms.Label();
            this.sothe = new System.Windows.Forms.TextBox();
            this.tungay = new MaskedBox.MaskedBox();
            this.label35 = new System.Windows.Forms.Label();
            this.tenbv = new System.Windows.Forms.TextBox();
            this.butLuu = new System.Windows.Forms.Button();
            this.loai = new System.Windows.Forms.ComboBox();
            this.butTiep = new System.Windows.Forms.Button();
            this.label34 = new System.Windows.Forms.Label();
            this.tenbs = new System.Windows.Forms.TextBox();
            this.lbacsy = new System.Windows.Forms.Label();
            this.butIn = new System.Windows.Forms.Button();
            this.bnmoi = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tenkp = new System.Windows.Forms.ComboBox();
            this.madoituong = new System.Windows.Forms.TextBox();
            this.tendoituong = new System.Windows.Forms.ComboBox();
            this.qh_diachi = new System.Windows.Forms.TextBox();
            this.quanhe = new System.Windows.Forms.TextBox();
            this.sovaovien = new MaskedTextBox.MaskedTextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.pmien = new System.Windows.Forms.Panel();
            this.duyet = new System.Windows.Forms.ComboBox();
            this.lydomien = new System.Windows.Forms.ComboBox();
            this.label33 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.makp = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.list = new LibList.List();
            this.l_bnmoi = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.listdstt = new LibList.List();
            this.button2 = new System.Windows.Forms.Button();
            this.listSothe = new LibList.List();
            this.listBS = new LibList.List();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.ngaysinh = new MaskedBox.MaskedBox();
            this.butInbarcode = new System.Windows.Forms.Button();
            this.pdienthoai = new System.Windows.Forms.Panel();
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
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.tbutvantay = new System.Windows.Forms.ToolStripButton();
            this.chkXem = new System.Windows.Forms.CheckBox();
            this.label42 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.phai = new System.Windows.Forms.ComboBox();
            this.label44 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.pic = new System.Windows.Forms.PictureBox();
            this.barcode = new AxBARCODELib.AxBarcode();
            this.ptb = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pBarcode = new System.Windows.Forms.PictureBox();
            this.chkDieutri = new System.Windows.Forms.CheckBox();
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
            this.butSmartcard = new System.Windows.Forms.Button();
            this.MIFARES501 = new AxMIFARES50_HSA.AxMIFARES50();
            this.phanhchinh.SuspendLayout();
            this.pvaovien.SuspendLayout();
            this.pnmakp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.khamthai.SuspendLayout();
            this.dausinhton.SuspendLayout();
            this.pmien.SuspendLayout();
            this.pdienthoai.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barcode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBarcode)).BeginInit();
            this.pgoi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sonhay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.den)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MIFARES501)).BeginInit();
            this.SuspendLayout();
            // 
            // tenba
            // 
            this.tenba.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenba.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tenba.Enabled = false;
            this.tenba.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenba.Location = new System.Drawing.Point(266, 27);
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
            this.label3.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label3.Location = new System.Drawing.Point(23, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 23);
            this.label3.TabIndex = 3;
            this.label3.Text = "&Mã BN :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.mabn1.Location = new System.Drawing.Point(93, 50);
            this.mabn1.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.mabn1.MaxLength = 8;
            this.mabn1.Name = "mabn1";
            this.mabn1.Size = new System.Drawing.Size(45, 21);
            this.mabn1.TabIndex = 4;
            // 
            // mabn2
            // 
            this.mabn2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabn2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabn2.Location = new System.Drawing.Point(140, 50);
            this.mabn2.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.mabn2.MaxLength = 2;
            this.mabn2.Name = "mabn2";
            this.mabn2.Size = new System.Drawing.Size(23, 21);
            this.mabn2.TabIndex = 5;
            this.mabn2.Validated += new System.EventHandler(this.mabn2_Validated);
            // 
            // mabn3
            // 
            this.mabn3.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabn3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mabn3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabn3.Location = new System.Drawing.Point(165, 50);
            this.mabn3.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.mabn3.MaxLength = 6;
            this.mabn3.Name = "mabn3";
            this.mabn3.Size = new System.Drawing.Size(72, 21);
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
            this.tuoi.Location = new System.Drawing.Point(284, 94);
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
            this.hoten.Location = new System.Drawing.Point(93, 72);
            this.hoten.Name = "hoten";
            this.hoten.Size = new System.Drawing.Size(284, 21);
            this.hoten.TabIndex = 7;
            this.hoten.Validated += new System.EventHandler(this.hoten_Validated);
            this.hoten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.hoten_KeyDown);
            // 
            // label52
            // 
            this.label52.BackColor = System.Drawing.Color.LightGray;
            this.label52.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label52.ForeColor = System.Drawing.Color.DimGray;
            this.label52.Location = new System.Drawing.Point(6, 29);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(378, 19);
            this.label52.TabIndex = 141;
            this.label52.Text = "I. HÀNH CHÍNH :";
            this.label52.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // butBoqua
            // 
            this.butBoqua.BackColor = System.Drawing.Color.Transparent;
            this.butBoqua.Enabled = false;
            this.butBoqua.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butBoqua.ForeColor = System.Drawing.SystemColors.ControlText;
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(159, 423);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(68, 25);
            this.butBoqua.TabIndex = 27;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.UseVisualStyleBackColor = false;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.BackColor = System.Drawing.Color.Transparent;
            this.butKetthuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butKetthuc.ForeColor = System.Drawing.SystemColors.ControlText;
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(302, 423);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 30;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.UseVisualStyleBackColor = false;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // phanhchinh
            // 
            this.phanhchinh.BackColor = System.Drawing.SystemColors.Control;
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
            // cholam
            // 
            this.cholam.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cholam.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cholam.Location = new System.Drawing.Point(76, 155);
            this.cholam.Name = "cholam";
            this.cholam.Size = new System.Drawing.Size(283, 21);
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
            // pvaovien
            // 
            this.pvaovien.Controls.Add(this.chkNgoaitru);
            this.pvaovien.Controls.Add(this.pnmakp);
            this.pvaovien.Controls.Add(this.n_makp);
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
            this.pvaovien.Controls.Add(this.sothe);
            this.pvaovien.Controls.Add(this.tungay);
            this.pvaovien.Controls.Add(this.label35);
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
            this.pvaovien.Controls.Add(this.label8);
            this.pvaovien.Controls.Add(this.tenkp);
            this.pvaovien.Controls.Add(this.madoituong);
            this.pvaovien.Controls.Add(this.tendoituong);
            this.pvaovien.Controls.Add(this.qh_diachi);
            this.pvaovien.Controls.Add(this.quanhe);
            this.pvaovien.Controls.Add(this.sovaovien);
            this.pvaovien.Controls.Add(this.label30);
            this.pvaovien.Controls.Add(this.label29);
            this.pvaovien.Controls.Add(this.label28);
            this.pvaovien.Controls.Add(this.label27);
            this.pvaovien.Controls.Add(this.label26);
            this.pvaovien.Controls.Add(this.pmien);
            this.pvaovien.Controls.Add(this.label25);
            this.pvaovien.Controls.Add(this.label24);
            this.pvaovien.Controls.Add(this.label23);
            this.pvaovien.Controls.Add(this.label19);
            this.pvaovien.Controls.Add(this.makp);
            this.pvaovien.Controls.Add(this.label1);
            this.pvaovien.Controls.Add(this.list);
            this.pvaovien.Controls.Add(this.l_bnmoi);
            this.pvaovien.Controls.Add(this.label36);
            this.pvaovien.Controls.Add(this.listdstt);
            this.pvaovien.Controls.Add(this.button2);
            this.pvaovien.Controls.Add(this.listSothe);
            this.pvaovien.Controls.Add(this.listBS);
            this.pvaovien.Location = new System.Drawing.Point(388, 27);
            this.pvaovien.Name = "pvaovien";
            this.pvaovien.Size = new System.Drawing.Size(400, 458);
            this.pvaovien.TabIndex = 15;
            // 
            // chkNgoaitru
            // 
            this.chkNgoaitru.BackColor = System.Drawing.SystemColors.Control;
            this.chkNgoaitru.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkNgoaitru.ForeColor = System.Drawing.SystemColors.Desktop;
            this.chkNgoaitru.Location = new System.Drawing.Point(13, 131);
            this.chkNgoaitru.Name = "chkNgoaitru";
            this.chkNgoaitru.Size = new System.Drawing.Size(103, 21);
            this.chkNgoaitru.TabIndex = 14;
            this.chkNgoaitru.Text = "Điều trị ngoại trú";
            this.chkNgoaitru.UseVisualStyleBackColor = false;
            this.chkNgoaitru.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkNgoaitru_KeyDown);
            // 
            // pnmakp
            // 
            this.pnmakp.BackColor = System.Drawing.SystemColors.Control;
            this.pnmakp.Controls.Add(this.dataGrid1);
            this.pnmakp.Location = new System.Drawing.Point(131, 170);
            this.pnmakp.Name = "pnmakp";
            this.pnmakp.Size = new System.Drawing.Size(248, 253);
            this.pnmakp.TabIndex = 267;
            this.pnmakp.Visible = false;
            // 
            // dataGrid1
            // 
            this.dataGrid1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid1.CaptionBackColor = System.Drawing.SystemColors.Control;
            this.dataGrid1.DataMember = "";
            this.dataGrid1.FlatMode = true;
            this.dataGrid1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(0, -14);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.Size = new System.Drawing.Size(248, 267);
            this.dataGrid1.TabIndex = 32;
            // 
            // n_makp
            // 
            this.n_makp.BackColor = System.Drawing.SystemColors.Info;
            this.n_makp.CheckOnClick = true;
            this.n_makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.n_makp.Location = new System.Drawing.Point(215, 178);
            this.n_makp.Name = "n_makp";
            this.n_makp.Size = new System.Drawing.Size(165, 244);
            this.n_makp.TabIndex = 229;
            this.n_makp.Visible = false;
            this.n_makp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.n_makp_KeyDown);
            // 
            // benhvien
            // 
            this.benhvien.BackColor = System.Drawing.SystemColors.HighlightText;
            this.benhvien.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.benhvien.Location = new System.Drawing.Point(54, 310);
            this.benhvien.Name = "benhvien";
            this.benhvien.Size = new System.Drawing.Size(326, 21);
            this.benhvien.TabIndex = 24;
            this.benhvien.TextChanged += new System.EventHandler(this.benhvien_TextChanged);
            this.benhvien.Validated += new System.EventHandler(this.benhvien_Validated);
            this.benhvien.KeyDown += new System.Windows.Forms.KeyEventHandler(this.benhvien_KeyDown);
            // 
            // listbv
            // 
            this.listbv.BackColor = System.Drawing.SystemColors.Info;
            this.listbv.ColumnCount = 0;
            this.listbv.Location = new System.Drawing.Point(295, 88);
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
            // bacsy
            // 
            this.bacsy.BackColor = System.Drawing.SystemColors.HighlightText;
            this.bacsy.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bacsy.Location = new System.Drawing.Point(54, 288);
            this.bacsy.Name = "bacsy";
            this.bacsy.Size = new System.Drawing.Size(326, 21);
            this.bacsy.TabIndex = 23;
            this.bacsy.TextChanged += new System.EventHandler(this.bacsy_TextChanged);
            this.bacsy.Validated += new System.EventHandler(this.bacsy_Validated);
            this.bacsy.KeyDown += new System.Windows.Forms.KeyEventHandler(this.bacsy_KeyDown);
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
            // listbs1
            // 
            this.listbs1.BackColor = System.Drawing.SystemColors.Info;
            this.listbs1.ColumnCount = 0;
            this.listbs1.Location = new System.Drawing.Point(214, 88);
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
            // khamthai
            // 
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
            this.khamthai.Size = new System.Drawing.Size(377, 45);
            this.khamthai.TabIndex = 25;
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
            this.ngaysanh.Location = new System.Drawing.Point(111, 23);
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
            this.label11.Location = new System.Drawing.Point(2, 25);
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
            this.para4.Location = new System.Drawing.Point(145, 1);
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
            this.para3.Location = new System.Drawing.Point(122, 1);
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
            this.para2.Location = new System.Drawing.Point(99, 1);
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
            this.para1.Location = new System.Drawing.Point(76, 1);
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
            this.label9.Location = new System.Drawing.Point(14, 5);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 15);
            this.label9.TabIndex = 19;
            this.label9.Text = "Para :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mabs
            // 
            this.mabs.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mabs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabs.Location = new System.Drawing.Point(55, 199);
            this.mabs.Name = "mabs";
            this.mabs.Size = new System.Drawing.Size(32, 21);
            this.mabs.TabIndex = 22;
            this.mabs.Validated += new System.EventHandler(this.mabs_Validated);
            this.mabs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabs_KeyDown);
            // 
            // qh_dienthoai
            // 
            this.qh_dienthoai.BackColor = System.Drawing.SystemColors.HighlightText;
            this.qh_dienthoai.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.qh_dienthoai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qh_dienthoai.Location = new System.Drawing.Point(55, 176);
            this.qh_dienthoai.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.qh_dienthoai.MaxLength = 20;
            this.qh_dienthoai.Name = "qh_dienthoai";
            this.qh_dienthoai.Size = new System.Drawing.Size(124, 21);
            this.qh_dienthoai.TabIndex = 19;
            // 
            // qh_hoten
            // 
            this.qh_hoten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.qh_hoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qh_hoten.Location = new System.Drawing.Point(55, 154);
            this.qh_hoten.Name = "qh_hoten";
            this.qh_hoten.Size = new System.Drawing.Size(124, 21);
            this.qh_hoten.TabIndex = 17;
            this.qh_hoten.Validated += new System.EventHandler(this.qh_hoten_Validated);
            this.qh_hoten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.qh_hoten_KeyDown);
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
            // denngay
            // 
            this.denngay.BackColor = System.Drawing.SystemColors.HighlightText;
            this.denngay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.denngay.Location = new System.Drawing.Point(143, 88);
            this.denngay.Mask = "##/##/####";
            this.denngay.Name = "denngay";
            this.denngay.Size = new System.Drawing.Size(60, 21);
            this.denngay.TabIndex = 11;
            this.denngay.Text = "  /  /    ";
            this.denngay.Validated += new System.EventHandler(this.denngay_Validated);
            // 
            // chkxml
            // 
            this.chkxml.AutoSize = true;
            this.chkxml.BackColor = System.Drawing.SystemColors.Control;
            this.chkxml.ForeColor = System.Drawing.SystemColors.Desktop;
            this.chkxml.Location = new System.Drawing.Point(295, 3);
            this.chkxml.Name = "chkxml";
            this.chkxml.Size = new System.Drawing.Size(85, 17);
            this.chkxml.TabIndex = 264;
            this.chkxml.Text = "Xuất ra XML";
            this.chkxml.UseVisualStyleBackColor = false;
            // 
            // dongia
            // 
            this.dongia.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dongia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dongia.Location = new System.Drawing.Point(242, 342);
            this.dongia.Name = "dongia";
            this.dongia.Size = new System.Drawing.Size(97, 20);
            this.dongia.TabIndex = 29;
            this.dongia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.dongia.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dongia_KeyDown);
            // 
            // sobienlai
            // 
            this.sobienlai.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sobienlai.Location = new System.Drawing.Point(192, 342);
            this.sobienlai.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.sobienlai.MaxLength = 7;
            this.sobienlai.Name = "sobienlai";
            this.sobienlai.Size = new System.Drawing.Size(48, 20);
            this.sobienlai.TabIndex = 28;
            this.sobienlai.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.sobienlai.Validated += new System.EventHandler(this.sobienlai_Validated);
            // 
            // lydo
            // 
            this.lydo.BackColor = System.Drawing.SystemColors.HighlightText;
            this.lydo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lydo.Location = new System.Drawing.Point(55, 221);
            this.lydo.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.lydo.Name = "lydo";
            this.lydo.Size = new System.Drawing.Size(325, 21);
            this.lydo.TabIndex = 21;
            this.lydo.Validated += new System.EventHandler(this.lydo_Validated);
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
            // checkBox1
            // 
            this.checkBox1.BackColor = System.Drawing.SystemColors.Control;
            this.checkBox1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.checkBox1.Location = new System.Drawing.Point(362, 344);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(16, 21);
            this.checkBox1.TabIndex = 222;
            this.toolTip1.SetToolTip(this.checkBox1, "Liệt kê tất cả ký hiệu biên lai");
            this.checkBox1.UseVisualStyleBackColor = false;
            this.checkBox1.CheckStateChanged += new System.EventHandler(this.checkBox1_CheckStateChanged);
            // 
            // kyhieu
            // 
            this.kyhieu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kyhieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kyhieu.Location = new System.Drawing.Point(55, 342);
            this.kyhieu.Name = "kyhieu";
            this.kyhieu.Size = new System.Drawing.Size(93, 21);
            this.kyhieu.TabIndex = 26;
            this.kyhieu.SelectedIndexChanged += new System.EventHandler(this.kyhieu_SelectedIndexChanged);
            this.kyhieu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.kyhieu_KeyDown);
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
            // butKyhieu
            // 
            this.butKyhieu.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butKyhieu.Image = ((System.Drawing.Image)(resources.GetObject("butKyhieu.Image")));
            this.butKyhieu.Location = new System.Drawing.Point(340, 342);
            this.butKyhieu.Name = "butKyhieu";
            this.butKyhieu.Size = new System.Drawing.Size(21, 21);
            this.butKyhieu.TabIndex = 244;
            this.butKyhieu.Text = "...";
            this.butKyhieu.Click += new System.EventHandler(this.butKyhieu_Click);
            // 
            // matienkham
            // 
            this.matienkham.BackColor = System.Drawing.SystemColors.HighlightText;
            this.matienkham.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.matienkham.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.matienkham.Location = new System.Drawing.Point(55, 365);
            this.matienkham.Name = "matienkham";
            this.matienkham.Size = new System.Drawing.Size(48, 21);
            this.matienkham.TabIndex = 24;
            this.matienkham.Validated += new System.EventHandler(this.matienkham_Validated);
            this.matienkham.KeyDown += new System.Windows.Forms.KeyEventHandler(this.matienkham_KeyDown);
            // 
            // tienkham
            // 
            this.tienkham.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tienkham.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tienkham.Location = new System.Drawing.Point(104, 365);
            this.tienkham.Name = "tienkham";
            this.tienkham.Size = new System.Drawing.Size(274, 21);
            this.tienkham.TabIndex = 25;
            this.tienkham.SelectedIndexChanged += new System.EventHandler(this.tienkham_SelectedIndexChanged);
            this.tienkham.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tienkham_KeyDown);
            // 
            // lsobienlai
            // 
            this.lsobienlai.BackColor = System.Drawing.SystemColors.Control;
            this.lsobienlai.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lsobienlai.Location = new System.Drawing.Point(131, 346);
            this.lsobienlai.Name = "lsobienlai";
            this.lsobienlai.Size = new System.Drawing.Size(62, 15);
            this.lsobienlai.TabIndex = 27;
            this.lsobienlai.Text = "Biên lai :";
            this.lsobienlai.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            // label38
            // 
            this.label38.BackColor = System.Drawing.SystemColors.Control;
            this.label38.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label38.Location = new System.Drawing.Point(3, 338);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(377, 50);
            this.label38.TabIndex = 254;
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
            this.mabv.TabIndex = 12;
            this.mabv.Validated += new System.EventHandler(this.mabv_Validated);
            // 
            // label53
            // 
            this.label53.BackColor = System.Drawing.Color.LightGray;
            this.label53.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label53.ForeColor = System.Drawing.Color.DimGray;
            this.label53.Location = new System.Drawing.Point(2, 2);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(380, 19);
            this.label53.TabIndex = 0;
            this.label53.Text = "II. THÔNG TIN ĐĂNG KÝ  KHÁM BỆNH :";
            this.label53.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dausinhton
            // 
            this.dausinhton.BackColor = System.Drawing.SystemColors.Control;
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
            this.dausinhton.Size = new System.Drawing.Size(374, 48);
            this.dausinhton.TabIndex = 24;
            // 
            // huyetap
            // 
            this.huyetap.BackColor = System.Drawing.SystemColors.HighlightText;
            this.huyetap.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.huyetap.Location = new System.Drawing.Point(299, 3);
            this.huyetap.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.huyetap.MaxLength = 7;
            this.huyetap.Name = "huyetap";
            this.huyetap.Size = new System.Drawing.Size(42, 21);
            this.huyetap.TabIndex = 20;
            //this.huyetap.Text = "   /   ";
            this.huyetap.Validated += new System.EventHandler(this.huyetap_Validated);
            // 
            // mach
            // 
            this.mach.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mach.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mach.Location = new System.Drawing.Point(50, 3);
            this.mach.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.mach.MaxLength = 5;
            this.mach.Name = "mach";
            this.mach.Size = new System.Drawing.Size(37, 21);
            this.mach.TabIndex = 16;
            // 
            // nhietdo
            // 
            this.nhietdo.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nhietdo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhietdo.Location = new System.Drawing.Point(181, 3);
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
            this.chieucao.Location = new System.Drawing.Point(181, 25);
            this.chieucao.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.chieucao.MaxLength = 5;
            this.chieucao.Name = "chieucao";
            this.chieucao.Size = new System.Drawing.Size(36, 21);
            this.chieucao.TabIndex = 22;
            this.chieucao.Validated += new System.EventHandler(this.chieucao_Validated);
            // 
            // bmi
            // 
            this.bmi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.bmi.Enabled = false;
            this.bmi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bmi.Location = new System.Drawing.Point(299, 25);
            this.bmi.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.bmi.MaxLength = 5;
            this.bmi.Name = "bmi";
            this.bmi.Size = new System.Drawing.Size(43, 21);
            this.bmi.TabIndex = 28;
            // 
            // cannang
            // 
            this.cannang.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cannang.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cannang.Location = new System.Drawing.Point(50, 25);
            this.cannang.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
            this.cannang.Name = "cannang";
            this.cannang.Size = new System.Drawing.Size(37, 21);
            this.cannang.TabIndex = 21;
            this.cannang.Validated += new System.EventHandler(this.cannang_Validated);
            // 
            // label45
            // 
            this.label45.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label45.Location = new System.Drawing.Point(221, 23);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(98, 23);
            this.label45.TabIndex = 31;
            this.label45.Text = "cm           BMI :";
            this.label45.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label40
            // 
            this.label40.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label40.Location = new System.Drawing.Point(91, 22);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(89, 23);
            this.label40.TabIndex = 29;
            this.label40.Text = "kg     Chiều cao :";
            this.label40.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label39
            // 
            this.label39.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label39.Location = new System.Drawing.Point(5, 25);
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
            this.label14.Location = new System.Drawing.Point(90, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(97, 23);
            this.label14.TabIndex = 17;
            this.label14.Text = "l/p       Nhiệt độ :";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.SystemColors.Control;
            this.label13.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label13.Location = new System.Drawing.Point(11, 2);
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
            this.label16.Location = new System.Drawing.Point(218, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(106, 23);
            this.label16.TabIndex = 19;
            this.label16.Text = "°C     Huyết áp :";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label18
            // 
            this.label18.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label18.Location = new System.Drawing.Point(340, 1);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(38, 23);
            this.label18.TabIndex = 21;
            this.label18.Text = "mmHg";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // honnhan
            // 
            this.honnhan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.honnhan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.honnhan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.honnhan.Location = new System.Drawing.Point(312, 176);
            this.honnhan.Name = "honnhan";
            this.honnhan.Size = new System.Drawing.Size(69, 21);
            this.honnhan.TabIndex = 20;
            this.honnhan.VisibleChanged += new System.EventHandler(this.honnhan_VisibleChanged);
            this.honnhan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.honnhan_KeyDown);
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
            // madstt
            // 
            this.madstt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.madstt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madstt.Location = new System.Drawing.Point(141, 44);
            this.madstt.Masked = MaskedTextBox.MaskedTextBox.Mask.MABV;
            this.madstt.MaxLength = 8;
            this.madstt.Name = "madstt";
            this.madstt.Size = new System.Drawing.Size(48, 21);
            this.madstt.TabIndex = 5;
            this.madstt.Validated += new System.EventHandler(this.madstt_Validated);
            // 
            // tendstt
            // 
            this.tendstt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tendstt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tendstt.Location = new System.Drawing.Point(192, 44);
            this.tendstt.Name = "tendstt";
            this.tendstt.Size = new System.Drawing.Size(188, 21);
            this.tendstt.TabIndex = 6;
            this.tendstt.TextChanged += new System.EventHandler(this.tendstt_TextChanged);
            this.tendstt.Validated += new System.EventHandler(this.tendstt_Validated);
            this.tendstt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tendstt_KeyDown);
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
            // sothe
            // 
            this.sothe.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sothe.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.sothe.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sothe.Location = new System.Drawing.Point(222, 66);
            this.sothe.MaxLength = 20;
            this.sothe.Name = "sothe";
            this.sothe.Size = new System.Drawing.Size(158, 21);
            this.sothe.TabIndex = 9;
            this.sothe.TextChanged += new System.EventHandler(this.sothe_TextChanged);
            this.sothe.Validated += new System.EventHandler(this.sothe_Validated);
            this.sothe.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sothe_KeyDown);
            // 
            // tungay
            // 
            this.tungay.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tungay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tungay.Location = new System.Drawing.Point(55, 88);
            this.tungay.Mask = "##/##/####";
            this.tungay.Name = "tungay";
            this.tungay.Size = new System.Drawing.Size(60, 21);
            this.tungay.TabIndex = 10;
            this.tungay.Text = "  /  /    ";
            this.tungay.Validated += new System.EventHandler(this.tungay_Validated);
            // 
            // label35
            // 
            this.label35.BackColor = System.Drawing.SystemColors.Control;
            this.label35.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label35.Location = new System.Drawing.Point(10, 89);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(48, 23);
            this.label35.TabIndex = 249;
            this.label35.Text = "Từ :";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tenbv
            // 
            this.tenbv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbv.Location = new System.Drawing.Point(117, 110);
            this.tenbv.Name = "tenbv";
            this.tenbv.Size = new System.Drawing.Size(264, 21);
            this.tenbv.TabIndex = 13;
            this.tenbv.TextChanged += new System.EventHandler(this.tenbv_TextChanged);
            this.tenbv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbv_KeyDown);
            // 
            // butLuu
            // 
            this.butLuu.BackColor = System.Drawing.Color.Transparent;
            this.butLuu.Enabled = false;
            this.butLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butLuu.ForeColor = System.Drawing.SystemColors.ControlText;
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(86, 423);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(73, 25);
            this.butLuu.TabIndex = 26;
            this.butLuu.Text = "     &Lưu";
            this.butLuu.UseVisualStyleBackColor = false;
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
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
            // butTiep
            // 
            this.butTiep.BackColor = System.Drawing.Color.Transparent;
            this.butTiep.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butTiep.ForeColor = System.Drawing.SystemColors.ControlText;
            this.butTiep.Image = ((System.Drawing.Image)(resources.GetObject("butTiep.Image")));
            this.butTiep.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butTiep.Location = new System.Drawing.Point(15, 423);
            this.butTiep.Name = "butTiep";
            this.butTiep.Size = new System.Drawing.Size(71, 25);
            this.butTiep.TabIndex = 28;
            this.butTiep.Text = "       &Tiếp";
            this.butTiep.UseVisualStyleBackColor = false;
            this.butTiep.Click += new System.EventHandler(this.butTiep_Click);
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
            // tenbs
            // 
            this.tenbs.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbs.Location = new System.Drawing.Point(89, 199);
            this.tenbs.Name = "tenbs";
            this.tenbs.Size = new System.Drawing.Size(291, 21);
            this.tenbs.TabIndex = 23;
            this.tenbs.TextChanged += new System.EventHandler(this.tenbs_TextChanged);
            this.tenbs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbs_KeyDown);
            // 
            // lbacsy
            // 
            this.lbacsy.BackColor = System.Drawing.SystemColors.Control;
            this.lbacsy.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lbacsy.Location = new System.Drawing.Point(10, 198);
            this.lbacsy.Name = "lbacsy";
            this.lbacsy.Size = new System.Drawing.Size(48, 19);
            this.lbacsy.TabIndex = 246;
            this.lbacsy.Text = "Bác sĩ :";
            this.lbacsy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butIn
            // 
            this.butIn.BackColor = System.Drawing.Color.Transparent;
            this.butIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butIn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(227, 423);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(75, 25);
            this.butIn.TabIndex = 29;
            this.butIn.Text = "      &In";
            this.butIn.UseVisualStyleBackColor = false;
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
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
            this.bnmoi.TabIndex = 15;
            this.bnmoi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.bnmoi_KeyDown);
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.SystemColors.Control;
            this.label8.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label8.Location = new System.Drawing.Point(6, 110);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 23);
            this.label8.TabIndex = 215;
            this.label8.Text = "ĐKKCB :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tenkp
            // 
            this.tenkp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenkp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tenkp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenkp.Location = new System.Drawing.Point(248, 22);
            this.tenkp.Name = "tenkp";
            this.tenkp.Size = new System.Drawing.Size(132, 21);
            this.tenkp.TabIndex = 3;
            this.tenkp.SelectedIndexChanged += new System.EventHandler(this.tenkp_SelectedIndexChanged);
            this.tenkp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenkp_KeyDown);
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
            // tendoituong
            // 
            this.tendoituong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tendoituong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tendoituong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tendoituong.Location = new System.Drawing.Point(74, 66);
            this.tendoituong.Name = "tendoituong";
            this.tendoituong.Size = new System.Drawing.Size(102, 21);
            this.tendoituong.TabIndex = 8;
            this.tendoituong.SelectedIndexChanged += new System.EventHandler(this.tendoituong_SelectedIndexChanged);
            this.tendoituong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tendoituong_KeyDown);
            // 
            // qh_diachi
            // 
            this.qh_diachi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.qh_diachi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qh_diachi.Location = new System.Drawing.Point(222, 154);
            this.qh_diachi.Name = "qh_diachi";
            this.qh_diachi.Size = new System.Drawing.Size(158, 21);
            this.qh_diachi.TabIndex = 18;
            this.qh_diachi.Validated += new System.EventHandler(this.qh_diachi_Validated);
            this.qh_diachi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.qh_diachi_KeyDown);
            // 
            // quanhe
            // 
            this.quanhe.BackColor = System.Drawing.SystemColors.HighlightText;
            this.quanhe.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quanhe.Location = new System.Drawing.Point(312, 132);
            this.quanhe.Name = "quanhe";
            this.quanhe.Size = new System.Drawing.Size(69, 21);
            this.quanhe.TabIndex = 16;
            this.quanhe.Validated += new System.EventHandler(this.quanhe_Validated);
            this.quanhe.KeyDown += new System.Windows.Forms.KeyEventHandler(this.quanhe_KeyDown);
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
            // label30
            // 
            this.label30.BackColor = System.Drawing.SystemColors.Control;
            this.label30.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label30.Location = new System.Drawing.Point(3, 42);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(55, 23);
            this.label30.TabIndex = 201;
            this.label30.Text = "Số khám :";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label29
            // 
            this.label29.BackColor = System.Drawing.SystemColors.Control;
            this.label29.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label29.Location = new System.Drawing.Point(3, 174);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(56, 23);
            this.label29.TabIndex = 200;
            this.label29.Text = "Đ. thoại :";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label28
            // 
            this.label28.BackColor = System.Drawing.SystemColors.Control;
            this.label28.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label28.Location = new System.Drawing.Point(157, 152);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(69, 23);
            this.label28.TabIndex = 199;
            this.label28.Text = "Địa chỉ :";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label27
            // 
            this.label27.BackColor = System.Drawing.SystemColors.Control;
            this.label27.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label27.Location = new System.Drawing.Point(3, 153);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(56, 23);
            this.label27.TabIndex = 198;
            this.label27.Text = "Họ tên :";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label26
            // 
            this.label26.BackColor = System.Drawing.SystemColors.Control;
            this.label26.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label26.Location = new System.Drawing.Point(245, 130);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(69, 23);
            this.label26.TabIndex = 197;
            this.label26.Text = "Người  thân :";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pmien
            // 
            this.pmien.BackColor = System.Drawing.SystemColors.Control;
            this.pmien.Controls.Add(this.duyet);
            this.pmien.Controls.Add(this.lydomien);
            this.pmien.Controls.Add(this.label33);
            this.pmien.Controls.Add(this.label32);
            this.pmien.Location = new System.Drawing.Point(-1, 389);
            this.pmien.Name = "pmien";
            this.pmien.Size = new System.Drawing.Size(382, 28);
            this.pmien.TabIndex = 18;
            // 
            // duyet
            // 
            this.duyet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.duyet.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.duyet.Location = new System.Drawing.Point(260, 4);
            this.duyet.Name = "duyet";
            this.duyet.Size = new System.Drawing.Size(115, 21);
            this.duyet.TabIndex = 245;
            this.duyet.KeyDown += new System.Windows.Forms.KeyEventHandler(this.duyet_KeyDown);
            // 
            // lydomien
            // 
            this.lydomien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lydomien.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lydomien.Location = new System.Drawing.Point(58, 4);
            this.lydomien.Name = "lydomien";
            this.lydomien.Size = new System.Drawing.Size(157, 21);
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
            this.label32.Location = new System.Drawing.Point(-3, 6);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(65, 16);
            this.label32.TabIndex = 242;
            this.label32.Text = "Lý do miễn :";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label25
            // 
            this.label25.BackColor = System.Drawing.SystemColors.Control;
            this.label25.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label25.Location = new System.Drawing.Point(82, 89);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(64, 23);
            this.label25.TabIndex = 196;
            this.label25.Text = "Đến :";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label24
            // 
            this.label24.BackColor = System.Drawing.SystemColors.Control;
            this.label24.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label24.Location = new System.Drawing.Point(160, 66);
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
            this.label23.Location = new System.Drawing.Point(2, 66);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(54, 23);
            this.label23.TabIndex = 12;
            this.label23.Text = "Đ. tượng :";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label19
            // 
            this.label19.BackColor = System.Drawing.SystemColors.Control;
            this.label19.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label19.Location = new System.Drawing.Point(9, 20);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(49, 23);
            this.label19.TabIndex = 0;
            this.label19.Text = "Ngày :";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // makp
            // 
            this.makp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.makp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makp.Location = new System.Drawing.Point(222, 22);
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(24, 21);
            this.makp.TabIndex = 2;
            this.makp.Validated += new System.EventHandler(this.makp_Validated);
            this.makp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.makp_KeyDown);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label1.Location = new System.Drawing.Point(144, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 23);
            this.label1.TabIndex = 165;
            this.label1.Text = "P.khám :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            // label36
            // 
            this.label36.BackColor = System.Drawing.SystemColors.Control;
            this.label36.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label36.Location = new System.Drawing.Point(82, 43);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(60, 23);
            this.label36.TabIndex = 244;
            this.label36.Text = "Giới thiệu :";
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.Control;
            this.button2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button2.Location = new System.Drawing.Point(0, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(384, 453);
            this.button2.TabIndex = 253;
            this.button2.UseVisualStyleBackColor = false;
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
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.SystemColors.Info;
            this.treeView1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.Location = new System.Drawing.Point(93, 356);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(219, 48);
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
            this.butInbarcode.BackColor = System.Drawing.Color.Transparent;
            this.butInbarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butInbarcode.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.butInbarcode.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butInbarcode.Location = new System.Drawing.Point(512, 397);
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
            this.pdienthoai.Size = new System.Drawing.Size(362, 47);
            this.pdienthoai.TabIndex = 14;
            // 
            // dt_email
            // 
            this.dt_email.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dt_email.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
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
            this.toolStripSeparator6,
            this.toolStripButton6,
            this.toolStripSeparator5,
            this.toolStripButton7,
            this.toolStripSeparator7,
            this.tbutvantay});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(774, 23);
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
            this.toolStripButton3.Size = new System.Drawing.Size(42, 20);
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
            this.toolStripButton4.Size = new System.Drawing.Size(40, 20);
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
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 23);
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
            // chkXem
            // 
            this.chkXem.AutoSize = true;
            this.chkXem.BackColor = System.Drawing.SystemColors.Control;
            this.chkXem.ForeColor = System.Drawing.SystemColors.Desktop;
            this.chkXem.Location = new System.Drawing.Point(280, 433);
            this.chkXem.Name = "chkXem";
            this.chkXem.Size = new System.Drawing.Size(102, 17);
            this.chkXem.TabIndex = 245;
            this.chkXem.Text = "Xem trước khi in";
            this.chkXem.UseVisualStyleBackColor = false;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.BackColor = System.Drawing.SystemColors.Control;
            this.label42.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label42.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label42.Location = new System.Drawing.Point(91, 341);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(125, 13);
            this.label42.TabIndex = 251;
            this.label42.Text = "Các lần khám trước :";
            this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.Location = new System.Drawing.Point(3, 26);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(383, 454);
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
            this.label44.AutoSize = true;
            this.label44.BackColor = System.Drawing.SystemColors.Control;
            this.label44.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label44.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label44.Location = new System.Drawing.Point(317, 416);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(67, 13);
            this.label44.TabIndex = 255;
            this.label44.Text = "Fingerprint";
            this.label44.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label43
            // 
            this.label43.BackColor = System.Drawing.SystemColors.Control;
            this.label43.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label43.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label43.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label43.Image = ((System.Drawing.Image)(resources.GetObject("label43.Image")));
            this.label43.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label43.Location = new System.Drawing.Point(7, 416);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(80, 18);
            this.label43.TabIndex = 256;
            this.label43.Text = "      Photo ";
            this.label43.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label43.Click += new System.EventHandler(this.label43_Click);
            // 
            // pic
            // 
            this.pic.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pic.Image = ((System.Drawing.Image)(resources.GetObject("pic.Image")));
            this.pic.Location = new System.Drawing.Point(17, 341);
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(70, 73);
            this.pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic.TabIndex = 253;
            this.pic.TabStop = false;
            // 
            // barcode
            // 
            this.barcode.Enabled = true;
            this.barcode.Location = new System.Drawing.Point(108, 402);
            this.barcode.Name = "barcode";
            this.barcode.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("barcode.OcxState")));
            this.barcode.Size = new System.Drawing.Size(168, 53);
            this.barcode.TabIndex = 251;
            // 
            // ptb
            // 
            this.ptb.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ptb.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ptb.ErrorImage = null;
            this.ptb.InitialImage = ((System.Drawing.Image)(resources.GetObject("ptb.InitialImage")));
            this.ptb.Location = new System.Drawing.Point(322, 350);
            this.ptb.Name = "ptb";
            this.ptb.Size = new System.Drawing.Size(48, 64);
            this.ptb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptb.TabIndex = 242;
            this.ptb.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox2.ErrorImage = null;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.InitialImage")));
            this.pictureBox2.Location = new System.Drawing.Point(318, 350);
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
            this.pBarcode.Location = new System.Drawing.Point(247, 391);
            this.pBarcode.Name = "pBarcode";
            this.pBarcode.Size = new System.Drawing.Size(33, 13);
            this.pBarcode.TabIndex = 258;
            this.pBarcode.TabStop = false;
            // 
            // chkDieutri
            // 
            this.chkDieutri.AutoSize = true;
            this.chkDieutri.BackColor = System.Drawing.SystemColors.Control;
            this.chkDieutri.ForeColor = System.Drawing.SystemColors.Desktop;
            this.chkDieutri.Location = new System.Drawing.Point(280, 451);
            this.chkDieutri.Name = "chkDieutri";
            this.chkDieutri.Size = new System.Drawing.Size(99, 17);
            this.chkDieutri.TabIndex = 259;
            this.chkDieutri.Text = "In phiếu điều trị";
            this.chkDieutri.UseVisualStyleBackColor = false;
            // 
            // pgoi
            // 
            this.pgoi.BackColor = System.Drawing.SystemColors.Control;
            this.pgoi.Controls.Add(this.butGoilai);
            this.pgoi.Controls.Add(this.butGoi);
            this.pgoi.Controls.Add(this.sonhay);
            this.pgoi.Controls.Add(this.den);
            this.pgoi.Controls.Add(this.tu);
            this.pgoi.Controls.Add(this.label50);
            this.pgoi.Location = new System.Drawing.Point(470, -1);
            this.pgoi.Name = "pgoi";
            this.pgoi.Size = new System.Drawing.Size(304, 26);
            this.pgoi.TabIndex = 262;
            // 
            // butGoilai
            // 
            this.butGoilai.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butGoilai.Location = new System.Drawing.Point(244, 2);
            this.butGoilai.Name = "butGoilai";
            this.butGoilai.Size = new System.Drawing.Size(55, 23);
            this.butGoilai.TabIndex = 6;
            this.butGoilai.Text = "Gọi lại";
            this.butGoilai.UseVisualStyleBackColor = true;
            this.butGoilai.Click += new System.EventHandler(this.butGoilai_Click);
            // 
            // butGoi
            // 
            this.butGoi.Image = ((System.Drawing.Image)(resources.GetObject("butGoi.Image")));
            this.butGoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butGoi.Location = new System.Drawing.Point(188, 2);
            this.butGoi.Name = "butGoi";
            this.butGoi.Size = new System.Drawing.Size(55, 23);
            this.butGoi.TabIndex = 5;
            this.butGoi.Text = "      &Gọi";
            this.butGoi.UseVisualStyleBackColor = true;
            this.butGoi.Click += new System.EventHandler(this.butGoi_Click);
            // 
            // sonhay
            // 
            this.sonhay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sonhay.Location = new System.Drawing.Point(148, 3);
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
            this.den.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.den.Location = new System.Drawing.Point(105, 3);
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
            this.tu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.Location = new System.Drawing.Point(61, 3);
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
            this.label50.Location = new System.Drawing.Point(22, 7);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(42, 13);
            this.label50.TabIndex = 0;
            this.label50.Text = "Số :";
            this.label50.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // linthe
            // 
            this.linthe.BackColor = System.Drawing.SystemColors.Control;
            this.linthe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linthe.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linthe.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.linthe.Image = ((System.Drawing.Image)(resources.GetObject("linthe.Image")));
            this.linthe.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linthe.Location = new System.Drawing.Point(7, 434);
            this.linthe.Name = "linthe";
            this.linthe.Size = new System.Drawing.Size(100, 18);
            this.linthe.TabIndex = 263;
            this.linthe.Text = "      In thẻ";
            this.linthe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linthe.Click += new System.EventHandler(this.linthe_Click);
            // 
            // lbienlaithe
            // 
            this.lbienlaithe.BackColor = System.Drawing.SystemColors.Control;
            this.lbienlaithe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbienlaithe.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbienlaithe.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbienlaithe.Image = ((System.Drawing.Image)(resources.GetObject("lbienlaithe.Image")));
            this.lbienlaithe.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbienlaithe.Location = new System.Drawing.Point(7, 453);
            this.lbienlaithe.Name = "lbienlaithe";
            this.lbienlaithe.Size = new System.Drawing.Size(134, 18);
            this.lbienlaithe.TabIndex = 264;
            this.lbienlaithe.Text = "      In biên lai in thẻ";
            this.lbienlaithe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbienlaithe.Click += new System.EventHandler(this.lbienlaithe_Click);
            // 
            // butSmartcard
            // 
            this.butSmartcard.Location = new System.Drawing.Point(281, 50);
            this.butSmartcard.Name = "butSmartcard";
            this.butSmartcard.Size = new System.Drawing.Size(96, 22);
            this.butSmartcard.TabIndex = 265;
            this.butSmartcard.Text = "Đọc Smart Card";
            this.butSmartcard.UseVisualStyleBackColor = true;
            this.butSmartcard.Click += new System.EventHandler(this.butSmartcard_Click);
            // 
            // MIFARES501
            // 
            this.MIFARES501.Enabled = true;
            this.MIFARES501.Location = new System.Drawing.Point(0, 356);
            this.MIFARES501.Name = "MIFARES501";
            this.MIFARES501.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("MIFARES501.OcxState")));
            this.MIFARES501.Size = new System.Drawing.Size(30, 31);
            this.MIFARES501.TabIndex = 266;
            // 
            // frmTiepdon_scard
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(774, 481);
            this.Controls.Add(this.MIFARES501);
            this.Controls.Add(this.butSmartcard);
            this.Controls.Add(this.lbienlaithe);
            this.Controls.Add(this.linthe);
            this.Controls.Add(this.pgoi);
            this.Controls.Add(this.chkDieutri);
            this.Controls.Add(this.phai);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label43);
            this.Controls.Add(this.label44);
            this.Controls.Add(this.pic);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.chkXem);
            this.Controls.Add(this.label42);
            this.Controls.Add(this.barcode);
            this.Controls.Add(this.pvaovien);
            this.Controls.Add(this.mabn3);
            this.Controls.Add(this.mabn2);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.pdienthoai);
            this.Controls.Add(this.ptb);
            this.Controls.Add(this.butInbarcode);
            this.Controls.Add(this.ngaysinh);
            this.Controls.Add(this.phanhchinh);
            this.Controls.Add(this.tenba);
            this.Controls.Add(this.label52);
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
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pBarcode);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(0, -2);
            this.Name = "frmTiepdon_scard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Medisoft THIS - Đăng ký ";
            this.Load += new System.EventHandler(this.frmTiepdon_scard_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmTiepdon_scard_KeyDown);
            this.phanhchinh.ResumeLayout(false);
            this.phanhchinh.PerformLayout();
            this.pvaovien.ResumeLayout(false);
            this.pvaovien.PerformLayout();
            this.pnmakp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.khamthai.ResumeLayout(false);
            this.khamthai.PerformLayout();
            this.dausinhton.ResumeLayout(false);
            this.dausinhton.PerformLayout();
            this.pmien.ResumeLayout(false);
            this.pdienthoai.ResumeLayout(false);
            this.pdienthoai.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barcode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBarcode)).EndInit();
            this.pgoi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sonhay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.den)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MIFARES501)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmTiepdon_scard_Load(object sender, System.EventArgs e)
		{
            if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            i_maxlength_mabn = m.i_maxlength_mabn;
            mabn3.MaxLength = i_maxlength_mabn;
            iChuyendoituong1 = m.iChuyendoituong1; iChuyenmavp = m.iChuyenmavp; iChuyendoituong2 = m.iChuyendoituong2;
            bChuyendoituong = m.bChuyendoituong; bKyhieu_may = m.bKyhieu_may; bDangky_bsbv = m.bDangky_bsbv;
            bBienlai_mien = m.bBienlai_mien; bSmartcard = m.bSmartcard;
            butSmartcard.Visible = bSmartcard;
            if (bSmartcard) start_smartcard();
            bTiepdon_ngoaitru = m.bTiepdon_ngoaitru;
            chkNgoaitru.Visible = bTiepdon_ngoaitru;
            bBhyt1kham = m.bBhyt1kham;
            i_useridvp = m.iUservp;
            lbs.Visible = bDangky_bsbv;
            lbv.Visible = bDangky_bsbv;
            bacsy.Visible = bDangky_bsbv;
            benhvien.Visible = bDangky_bsbv;
            FileType = m.FileType;
            bGoi = m.bGoi_dangky;
            bIn1lan = m.bIn1lan;
            bThutien_the = m.bThutien_the;
            imavp_the = m.iMavp_the;
            lbienlaithe.Visible = bThutien_the && imavp_the != 0;
            ngaysrv=m.ngayhienhanh_server.Substring(0,10);
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
            user = m.user; b701306 = m.Mabv_so == 701306; bMabn_tudong = m.bMabn_tudong_tiepdon;
            bDssothe = m.bDsSothe; i_madoituong_ng = m.iDoituong_ngoaigio;
            bNoigioithieu = m.bNoigioithieu_tiepdon; bDocmavach = m.bDocmavach;
			madstt.Enabled=bNoigioithieu;
			tendstt.Enabled=bNoigioithieu;
            bSothe_mabn = m.bsothe_mabn;
            bHinh = m.bHinh; bChonhinh = m.bChonhinh;
            if (bHinh || bChonhinh)
            {
                dsthe.ReadXml("..//..//..//xml//m_phieudieutri.xml");
                DataColumn dc = new DataColumn("image", typeof(byte[]));
                dsthe.Tables[0].Columns.Add(dc);
                dc = new DataColumn("barcode", typeof(byte[]));
                dsthe.Tables[0].Columns.Add(dc);
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
            linthe.Visible = bHinh || bChonhinh;
            chkxml.Visible = bHinh || bChonhinh;
            bThuphi_kham = m.bThuphi_kham;
            if (bDocmavach)
            {
                mabn2.MaxLength = 8;
                mabn3.MaxLength = 8;
            }
			if (bNoigioithieu)
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
                barcode.Visible = true;
                barcode.Text = "07123456";
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
			songay=m.Ngaylv_Ngayht;
			s_msg=LibMedi.AccessData.Msg;
			iTreem6=m.iTreem6;
			iTreem15=m.iTreem15;
			iKhamnhi=m.iTuoi_khamnhi;
			b_Hoten=m.bHoten_gioitinh;
			vis_vienphi(bInkhambenh || bKhongintienkham);
			butIn.Enabled=(bInkhambenh || bInphieudieutri);
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
                    sobienlai.Text = (bKyhieu_chung) ? m.get_sobienlai(long.Parse(kyhieu.SelectedValue.ToString()), 1).ToString() : dtkh.Rows[kyhieu.SelectedIndex]["soghi"].ToString();
                }
            }
            catch { }
            if (bDangky_bsbv)
            {
                dtbv = m.get_data("select ten,ten as stt from " + user + ".dmbvchidinh order by ten").Tables[0];
                listbv.DataSource = dtbv;
                listbv.DisplayMember = "TEN";
                listbv.ValueMember = "TEN";

                dtbs1 = m.get_data("select * from " + user + ".dmbschidinh order by ten,benhvien ").Tables[0];
                listbs1.DataSource = dtbs1;
                listbs1.DisplayMember = "TEN";
                listbs1.ValueMember = "TEN";
            }
            sql = "select * from " + user + ".btdkp_bv where loai=1 and viettat<>'" + makp.Text + "'";
            if (i_khudt != 0) sql += " and (khu=0 or khu=" + i_khudt + ")";
            sql+=" order by makp";
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
		}

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
			foreach(DataRow r in m.get_data("select distinct b.ten from "+user+".diungthuoc a,"+user+".d_dmhoatchat b where a.mahc=b.ma and a.mabn='"+mabn2.Text+mabn3.Text+"'").Tables[0].Rows) tlbl.Text+=r["ten"].ToString().Trim()+";";
			//diungthuoc.Checked=tlbl.Text!="";
			//if (diungthuoc.Checked) 
            if (tlbl.Text!="") tlbl.Text=lan.Change_language_MessageText("DỊ ỨNG THUỐC :")+tlbl.Text;
			//l_diungthuoc.ForeColor=(diungthuoc.Checked)?Color.FromArgb(255,0,0):Color.FromArgb(0,0,255);
		}

		private void load_dm()
		{
			list.DisplayMember="MABV";
			list.ValueMember="TENBV";
			list.DataSource=m.get_data("select mabv,tenbv,diachi from "+user+".dmnoicapbhyt order by mabv").Tables[0];

			listSothe.DisplayMember="SOTHE";
			listSothe.ValueMember="SOTHE";
			if (bDssothe) 
			{
				dtsothe=m.get_data("select a.sothe as st,a.sothe,a.mabv,nullif(b.tenbv,'') as tenbv,to_char(a.tungay,'dd/mm/yyyy') as tungay,to_char(a.denngay,'dd/mm/yyyy') as denngay from "+user+".dmbhyt a left join "+user+".dmnoicapbhyt b using(mabv) order by a.sothe").Tables[0];
				listSothe.DataSource=dtsothe;
			}

			sql="select * from "+user+".btdkp_bv where makp<>'01' and loai=1";
            if (s_makp != "")
            {
                string s = s_makp.Replace(",", "','");
                sql += " and makp in ('" + s.Substring(0, s.Length - 3) + "')";
            }
            if (i_khudt != 0) sql += " and (khu=0 or khu=" + i_khudt + ")";
			sql+=" order by makp";
			dtkp=m.get_data(sql).Tables[0];
			tenkp.DisplayMember="TENKP";
			tenkp.ValueMember="VIETTAT";
			tenkp.DataSource=dtkp;
			if (tenkp.Items.Count>0) tenkp.SelectedIndex=0;
			dtba=m.get_data("select * from "+user+".dmbenhan_bv where loaiba=3 order by maba").Tables[0];
			tenba.DisplayMember="TENVT";
			tenba.ValueMember="MAVT";
			tenba.DataSource=dtba;
			tenba.SelectedIndex=0;
            _mabvso = m.Mabv_so.ToString().PadLeft(6, '0');
            mabn1.Text = _mabvso;
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
			if (s_madoituong!="") sql+=" where madoituong in ("+s_madoituong.Substring(0,s_madoituong.Length-1)+")";
			sql+=" order by madoituong";
			dtdt=m.get_data(sql).Tables[0];
			tendoituong.DisplayMember="DOITUONG";
			tendoituong.ValueMember="MADOITUONG";
			tendoituong.DataSource=dtdt;
			if (tendoituong.SelectedIndex!=-1)
			{
				madoituong.Text=tendoituong.SelectedValue.ToString();
				string so=m.sothe(int.Parse(tendoituong.SelectedValue.ToString()));
				sothe.Enabled=int.Parse(so.Substring(0,2))>0;
				denngay.Enabled=so.Substring(2,1)=="1";
				mabv.Enabled=so.Substring(3,1)=="1";
				tenbv.Enabled=mabv.Enabled;
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
			if (e.KeyCode==Keys.Enter)
			{
				if (tenkp.SelectedIndex==-1) tenkp.SelectedIndex=0;
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
				s_mabn=mabn2.Text+mabn3.Text;
				DataTable dt=m.get_Timmabn(hoten.Text.Trim().ToUpper(),ngaysinh.Text,namsinh.Text,s_mabn).Tables[0];
				if (dt.Rows.Count>0)
				{
					frmTimMabn f=new frmTimMabn(dt);
					f.ShowDialog();
					if (f.m_mabn!="")
					{
						mabn2.Text=f.m_mabn.Substring(0,2);
						mabn3.Text=f.m_mabn.Substring(2,6);
						s_mabn=mabn2.Text+mabn3.Text;
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
            if (bDocmavach)
            {
                string s = mabn2.Text;
                if (s.Length == 8)
                {
                    mabn2.Text = s.Substring(0, 2);
                    mabn3.Text = s.Substring(2);
                    mabn3_Validated(sender, e);
                }
            }
			mabn2.Text=mabn2.Text.PadLeft(2,'0');
		}

		private void mabn3_Validated(object sender, System.EventArgs e)
		{
			if(bVantay) loadHinhVanTay(mabn2.Text+mabn3.Text);
			bNew=true;
			load_btdnn(0);
			if (bChuyenkhoasan) phai.SelectedIndex=1;
            nam = "";
            if (bMabn_tudong && mabn3.Text == "")
            {
                if (mabn2.Text == "")
                {
                    mabn2.Focus();
                    return;
                }
                long stt = 0;
                for (; ; )
                {
                    stt = m.get_mabn(int.Parse(mabn2.Text), 1, 1, true);
                    mabn3.Text = stt.ToString().PadLeft(i_maxlength_mabn - 2, '0');//(6, '0');
                    s_mabn = mabn2.Text + mabn3.Text;
                    if (m.get_data("select * from "+user+".btdbn where mabn='" + s_mabn + "'").Tables[0].Rows.Count == 0) break;
                }
                if (barcode.Visible) barcode.Text = s_mabn;
                emp_text(true);
                return;
            }
			else if (mabn3.Text=="") return;
            if (bDocmavach)
            {
                string s = mabn3.Text;
                if (s.Length == 8)
                {
                    mabn2.Text = s.Substring(0,2);
                    mabn3.Text = s.Substring(2);
                }
            }
            mabn3.Text = mabn3.Text.PadLeft(i_maxlength_mabn - 2, '0');//(6,'0');
			s_mabn=mabn2.Text+mabn3.Text;
			if (barcode.Visible) barcode.Text=s_mabn;
			emp_text(true);
			if (load_mabn())
			{
				if (ngayvv.Text=="")
				{
					if (load_vv_mabn() && !bAdmin) ena_but(false);
				}
				if (bAdmin && !bDocmavach)
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
		}

		private bool load_mabn()
		{
			bool ret=false;
			foreach(DataRow r in m.get_data("select * from "+user+".btdbn where mabn='"+s_mabn+"'").Tables[0].Rows)
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
                            pic.Tag = (System.IO.File.Exists(pathImage + "//" + s_mabn + "." + FileType)) ? pathImage + "//" + s_mabn + "." + FileType : "0000.bmp";
                            File.Copy(pic.Tag.ToString(), file, true);
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
                        File.Copy(pic.Tag.ToString(), file, true);
                    }
                    if (error)
                    {
                        fstr = new System.IO.FileStream(pic.Tag.ToString(), System.IO.FileMode.Open, System.IO.FileAccess.Read);
                        map = new Bitmap(Image.FromStream(fstr));
                        pic.Image = (Bitmap)map;
                        image = new byte[fstr.Length];
                        fstr.Read(image, 0, System.Convert.ToInt32(fstr.Length));
                        fstr.Close();                        
                        if (pathImage == "") pic.Tag = image;
                    }
                }
				break;
			}
            if (ret && manuoc.Enabled)
                foreach (DataRow r1 in m.get_data("select id_nuoc from " + user + ".nuocngoai where mabn='" + s_mabn + "'").Tables[0].Rows) tennuoc.SelectedValue=r1["id_nuoc"].ToString();
			load_diungthuoc();
			if (bLoad_tiepdon) load_treeView();
			return ret;
		}

		private void load_vv_maql(bool skip)
		{
			//emp_vv();
            if (ngayvv.Text == "") return;
			DataRow r1;
			foreach(DataRow r in m.get_data("select * from "+user+m.mmyy(ngayvv.Text)+".tiepdon where maql="+l_maql).Tables[0].Rows)
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
				if (r1!=null) tenkp.SelectedValue=r1["viettat"].ToString();
				if (bHonnhan) vis_honnhan(!m.kiemtra_khamnhi(r["makp"].ToString()));
				sovaovien.Text=r["sovaovien"].ToString();
				bnmoi.SelectedIndex=int.Parse(r["bnmoi"].ToString());
				loai.SelectedIndex=int.Parse(r["loai"].ToString());
				string stuoi=r["tuoivao"].ToString();
				if (stuoi.Length==4)
				{
					tuoi.Text=stuoi.Substring(0,3);
					loaituoi.SelectedIndex=Math.Min(int.Parse(stuoi.Substring(3,1)),3);
				}
                if (bTiepdon_ngoaitru) chkNgoaitru.Checked = int.Parse(r["noitiepdon"].ToString()) == -2;
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
				l_maql=long.Parse(r["maql"].ToString());
                s_ngayvv = m.DateToString("dd/MM/yyyy HH:mm", DateTime.Parse(r["ngay"].ToString()));
                ngayvv.Text = s_ngayvv.Substring(0, 10);
                giovv.Text = s_ngayvv.Substring(11);
				r1=m.getrowbyid(dtkp,"makp='"+r["makp"].ToString()+"'");
				if (r1!=null) tenkp.SelectedValue=r1["viettat"].ToString();
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
			foreach(DataRow r in m.get_data("select * from "+xxx+".quanhe where maql="+l_maql).Tables[0].Rows)
			{
				quanhe.Text=r["quanhe"].ToString();
				qh_hoten.Text=r["hoten"].ToString();
				qh_diachi.Text=r["diachi"].ToString();
				qh_dienthoai.Text=r["dienthoai"].ToString();
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
						if (so.Substring(3,1)=="1")
						{
							mabv.Text=r["mabv"].ToString();
							try
							{
								tenbv.Text=m.get_data("select tenbv from "+user+".dmnoicapbhyt where mabv='"+mabv.Text+"'").Tables[0].Rows[0][0].ToString();
							}
							catch{}
						}
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
                    tinh_bmi();
					break;
				}
			}
			if (bBacsy)
			{
				foreach(DataRow r in m.get_data("select * from "+xxx+".lienhe where maql="+l_maql).Tables[0].Rows)
				{
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
									l_id=long.Parse(dttmp.Rows[0]["id"].ToString());
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
									l_id=long.Parse(r1["id"].ToString());
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
											long l_dongia=long.Parse(dongia.Text)/m.dTygia;
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
			else if (e.KeyCode==Keys.Enter)	SendKeys.Send("{Tab}{Home}");
		}

		private void cholam_Validated(object sender, System.EventArgs e)
		{
			cholam.Text=m.Caps(cholam.Text);		
		}
		//khanh son
		private void lay_mabn_vantay()
		{
			ma_vantay="";
			if(fnhandang==null) fnhandang=new FingerApp.FrmNhanDang(ptb);
			fnhandang.ShowDialog();
			ma_vantay=fnhandang.mabn;
			if(ma_vantay.Length==8)
			{
				mabn2.Text=ma_vantay.Substring(0,2);
				mabn3.Text=ma_vantay.Substring(2,6);
				s_mabn=mabn2.Text+mabn3.Text;
				load_mabn();
				ngayvv.Focus();
				SendKeys.Send("{Home}");
			}
			else
			{
				if (bVantay_mabntudong)
				{
					long maso=m.get_mabn(int.Parse(DateTime.Now.Year.ToString().Substring(2)),1,1,true);
					if (maso!=0)
					{
						string ma=DateTime.Now.Year.ToString().Substring(2)+maso.ToString().PadLeft(6,'0');
						mabn2.Text=ma.Substring(0,2);
						mabn3.Text=ma.Substring(2,6);
						hoten.Text="";
						hoten.Focus();
					}
				}
				else
				{
					mabn2.Text=DateTime.Now.Year.ToString().Substring(2,2);
					mabn3.Text="";
					mabn2.Focus();
				}
			}
		}
		//khanh son
		private void frmTiepdon_scard_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
                case Keys.F1: if (bGoi) butGoi_Click(sender, e); break;
                case Keys.F3: butTiep_Click(sender, e); break;
                case Keys.F6: butLuu_Click(sender, e); break;
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
				denngay.Enabled=so.Substring(2,1)=="1";
				if (bTungay && denngay.Enabled) tungay.Enabled=denngay.Enabled;
				else tungay.Enabled=false;
				mabv.Enabled=so.Substring(3,1)=="1";
				tenbv.Enabled=mabv.Enabled;
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
					if (denngay.Enabled && bTungay) tungay.Enabled=denngay.Enabled;
					else tungay.Enabled=false;
					mabv.Enabled=so.Substring(3,1)=="1";
					tenbv.Enabled=mabv.Enabled;
					if (bSuagiakham || bLuachontienkham) load_dongia();
					if (pmien.Visible) 
					{
						lydomien.Enabled=madoituong.Text!="1" && m.mien_doituong(int.Parse(madoituong.Text),dtdt);
						duyet.Enabled=lydomien.Enabled;
					}
				}
				catch{}
			}
		}

		private void load_bhyt()
		{
            string so = m.sothe(int.Parse(tendoituong.SelectedValue.ToString()));
            if (nam == "")
            {
                try
                {
                    if (so.Substring(3, 1) == "1")
                    {
                        if (mabv.Text == "") mabv.Text = m.Mabv;
                        tenbv.Text = m.get_data("select tenbv from " + user + ".dmnoicapbhyt where mabv='" + mabv.Text + "'").Tables[0].Rows[0][0].ToString();
                    }
                }
                catch { }
                return;
            }
			if (int.Parse(so.Substring(0,2))>0 && ngayvv.Text!="")
			{
				s_mabn=mabn2.Text+mabn3.Text;
				if (so.Substring(2,1)=="1" && bDenngay_sothe)
                    sql="select sothe,denngay,mabv,tungay from xxx.bhyt where mabn='"+s_mabn+"'"+" and denngay>=to_timestamp('"+ngayvv.Text.Substring(0,10)+"','"+m.f_ngay+"')"+" order by maql desc";
				else
					sql="select sothe,denngay,mabv,tungay from xxx.bhyt where mabn='"+s_mabn+"' order by maql desc";
				foreach(DataRow r in m.get_data_nam_dec(nam,sql).Tables[0].Rows)
				{
					sothe.Text=r["sothe"].ToString();
					if (bTungay && r["tungay"].ToString()!="")
						tungay.Text=m.DateToString("dd/MM/yyyy",DateTime.Parse(r["tungay"].ToString()));
					if (r["denngay"].ToString()!="")
						denngay.Text=m.DateToString("dd/MM/yyyy",DateTime.Parse(r["denngay"].ToString()));
					if (so.Substring(3,1)=="1") mabv.Text=r["mabv"].ToString();
					break;
				}
                if (sothe.Text == "")
                {
                    if (so.Substring(2, 1) == "1" && bDenngay_sothe)
                        sql = "select sothe,denngay,tungay,mabv from " + user + ".bhyt where mabn='" + s_mabn + "' and denngay>=to_timestamp('" + ngayvv.Text.Substring(0, 10) + "','" + m.f_ngay + "')" + " order by maql desc";
                    else
                        sql = "select sothe,denngay,tungay,mabv from " + user + ".bhyt where mabn='" + s_mabn + "' order by maql desc";
                    foreach (DataRow r in m.get_data(sql).Tables[0].Rows)
                    {
                        sothe.Text = r["sothe"].ToString();
                        if (bTungay && r["tungay"].ToString() != "")
                            tungay.Text = m.DateToString("dd/MM/yyyy", DateTime.Parse(r["tungay"].ToString()));
                        if (r["denngay"].ToString() != "")
                            denngay.Text = m.DateToString("dd/MM/yyyy", DateTime.Parse(r["denngay"].ToString()));
                        if (so.Substring(3, 1) == "1") mabv.Text = r["mabv"].ToString();
                        break;
                    }
                }
				try
				{
					if (so.Substring(3,1)=="1")
					{
						if (mabv.Text=="") mabv.Text=m.Mabv;
						tenbv.Text=m.get_data("select tenbv from "+user+".dmnoicapbhyt where mabv='"+mabv.Text+"'").Tables[0].Rows[0][0].ToString();
					}
				}
				catch{}
			}
			else
			{
				sothe.Text="";denngay.Text="";tungay.Text="";
				mabv.Text="";tenbv.Text="";
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
					else butLuu.Focus();
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
                if (qh_diachi.Text == "") qh_diachi.Text = 
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
		}

		private void emp_text(bool skip)
		{
			ena_but(true);
			if (!skip)
			{
				mabn2.Text=DateTime.Now.Year.ToString().Substring(2,2);
				mabn3.Text="";
			}
            ptb.Image = null;
            mabn1.Text = _mabvso;
            loaituoi.SelectedIndex = 0; nam = "";
			mabs.Text="";tenbs.Text="";hoten.Text="";ngaysinh.Text="";
			namsinh.Text="";tuoi.Text="";sonha.Text="";thon.Text="";
			cholam.Text="";ma_vantay="";dt_nha.Text="";
			dt_coquan.Text="";dt_didong.Text="";dt_email.Text="";
			tentqx.SelectedIndex=-1;bnmoi.SelectedIndex=0;
			tqx.Text="";l_maql=0;
			bNew=true;
			b_Edit=false;
			tentinh.SelectedValue=m.Mabv.Substring(0,3);
			tendantoc.SelectedValue="25";
			tennuoc.SelectedValue="VN";
			treeView1.Nodes.Clear();
			ref_check();
			load_quan();
			load_pxa();
			emp_vv();
			emp_bhyt();
			if (bHonnhan) vis_honnhan(bHonnhan);
            if (bHinh || bChonhinh)
            {
                pic.Tag = "0000.bmp";
                fstr = new System.IO.FileStream(pic.Tag.ToString(), System.IO.FileMode.Open, System.IO.FileAccess.Read);
                map = new Bitmap(Image.FromStream(fstr));
                pic.Image = (Bitmap)map;
                image = new byte[fstr.Length];
                fstr.Read(image, 0, System.Convert.ToInt32(fstr.Length));
                fstr.Close();
                if (pathImage == "") pic.Tag = image;
            }
            if (bTiepdon_ngoaitru) chkNgoaitru.Checked = false;
            for (int i = 0; i < n_makp.Items.Count; i++) n_makp.SetItemCheckState(i, CheckState.Unchecked);
		}

        private void emp_bhyt()
		{
			sothe.Text="";
			denngay.Text="";
			tungay.Text="";
			mabv.Text="";
			tenbv.Text="";
		}

		private void emp_vv()
		{
            s_ngayvv = m.Ngaygio;
            ngayvv.Text = s_ngayvv.Substring(0, 10);
            giovv.Text = s_ngayvv.Substring(11);
            s_ngayvv = ""; bacsy.Text = ""; benhvien.Text = "";
			madoituong.Text="";
			tendoituong.SelectedIndex=-1;
			quanhe.Text="";
			qh_hoten.Text="";
			qh_diachi.Text="";
			qh_dienthoai.Text="";
			sovaovien.Text="";
			para1.Text="";
			para2.Text="";
			para3.Text="";
			para4.Text="";
			kinhcc.Text="";
			ngaysanh.Text="";
			dacdiem.Text="";
			lydo.Text="";
			madstt.Text="";
			tendstt.Text="";
			if (honnhan.Items.Count>0) honnhan.SelectedIndex=0;
            mach.Text = ""; nhietdo.Text = ""; huyetap.Text = ""; cannang.Text = ""; chieucao.Text = ""; bmi.Text = "";
		}

		private void butTiep_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (bInkhambenh || bKhongintienkham)
				{
					kyhieu.SelectedValue=s_kyhieu.ToString();
					sobienlai.Text=(bKyhieu_chung)?m.get_sobienlai(long.Parse(kyhieu.SelectedValue.ToString()),1).ToString():dtkh.Rows[kyhieu.SelectedIndex]["soghi"].ToString();
				}
			}
			catch{}
            if (bHinh || bChonhinh)
            {
                pathSave = "..//image";
                if (!System.IO.Directory.Exists(pathSave)) System.IO.Directory.CreateDirectory(pathSave);
                if (!System.IO.File.Exists(file)) setFile();
            }
            fnhandang = null;
			emp_text(false);
			mabn2.Focus();
		}

		private bool kiemtra()
		{
			DataRow r1;
			if (mabn2.Text=="" || mabn3.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập mã bệnh nhân !"),s_msg);
				mabn2.Focus();
				return false;
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
					if (bTungay && so.Substring(2,1)=="1" && tungay.Text=="")
					{
						tungay.Focus();
						return false;
					}
					if (so.Substring(2,1)=="1" && denngay.Text=="")
					{
						denngay.Focus();
						return false;
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
			if (makp.Text=="" || tenkp.SelectedIndex==-1)
			{
				MessageBox.Show(lan.Change_language_MessageText("Chọn khoa/phòng !"),s_msg);
				tenkp.Focus();
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
			s_mabn=mabn2.Text+mabn3.Text;
			r1=m.getrowbyid(dtkp,"viettat='"+makp.Text+"'");
			if (r1==null)
			{
				MessageBox.Show(lan.Change_language_MessageText("Phòng khám không hợp lệ !"),LibMedi.AccessData.Msg);
				makp.Focus();
				return false;
			}
            if (m.get_maql_tiepdon(s_mabn, r1["makp"].ToString(), ngayvv.Text + " " + giovv.Text) == 0)
            {
                if (m.bTuvong(mabn2.Text + mabn3.Text))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Người bệnh này đã tử vong !"), LibMedi.AccessData.Msg);
                    butBoqua_Click(null, null);
                    return false;
                }
            }
            if (!m.bMmyy(m.mmyy(ngayvv.Text))) m.tao_schema(m.mmyy(ngayvv.Text), i_userid);
			l_maql=m.get_maql_tiepdon(s_mabn,ngayvv.Text+" "+giovv.Text);
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
                if (m.get_data("select * from " + user + m.mmyy(ngayvv.Text) + ".tiepdon where maql=" + l_maql + " and done is not null").Tables[0].Rows.Count > 0)
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
			if ((bInkhambenh || bKhongintienkham || bLuachontienkham) && kyhieu.SelectedIndex!=-1)
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
						sobienlai.Text=m.get_sobienlai(long.Parse(kyhieu.SelectedValue.ToString()),1).ToString();
						if (bSobienlai)
						{
							int so=int.Parse(sobienlai.Text);
							//if (n_makp.Visible) for(int i=0;i<n_makp.Items.Count;i++) if (n_makp.GetItemChecked(i)) so+=1;
                            if (pnmakp.Visible)
                                foreach (DataRow rk in dtnkp.Select("chon=true", "makp")) so += 1;
							if (!m.kiemtra_bienlai(long.Parse(kyhieu.SelectedValue.ToString()),so))
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
				if ((madstt.Text=="" && tendstt.Text!="") || (madstt.Text!="" && tendstt.Text==""))
				{
					MessageBox.Show(lan.Change_language_MessageText("Nhập nơi giới thiệu !"),s_msg);
					madstt.Focus();
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
                        MessageBox.Show(lan.Change_language_MessageText("Số thẻ ")+" " + sothe.Text + "\n "+lan.Change_language_MessageText("Đã có mã người bệnh :") + s + "\n"+lan.Change_language_MessageText("Sử dụng !"), LibMedi.AccessData.Msg);
                        sothe.Focus();
                        return false;
                    }
                }
            }
            if (bTiepdon_ngoaitru)
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
			return true;
		}
		//moi them 14/1/2006 khanh son
		private void loadHinhVanTay(string mabn)
		{
            ptb.Image = null;
			if(fnhandang==null) fnhandang=new FingerApp.FrmNhanDang(ptb);
			ptb.Image=fnhandang.getImageFromMabn(mabn);
		}

		private void luu_vantay()
		{
			try
			{
				string ma=mabn2.Text+mabn3.Text;
				fnhandang.save_orac(ma);
			}
			catch{}
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			if (bVantay && ma_vantay=="") luu_vantay();
            //if (bVantay && ptb.Image != null) luu_vantay();
			if (!kiemtra()) return;
            string zzz=user+m.mmyy(ngayvv.Text);
			if (i_sokham!=3 && makp.Text!="" && bNew)
			{
				DataRow r2=m.getrowbyid(dtkp,"viettat='"+makp.Text+"'");
				if (r2!=null) sovaovien.Text=m.get_sokham(ngayvv.Text.Substring(0,10),r2["makp"].ToString(),i_sokham).ToString();
			}
            if (nam.IndexOf(m.mmyy(ngayvv.Text) + "+") == -1) nam = nam + m.mmyy(ngayvv.Text) + "+";
			if (!m.upd_btdbn(s_mabn,hoten.Text,ngaysinh.Text,namsinh.Text,phai.SelectedIndex,mann.Text,madantoc.Text,sonha.Text,thon.Text,cholam.Text,matt.Text,maqu1.Text+maqu2.Text,mapxa1.Text+mapxa2.Text,i_userid,nam))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin hành chính !"),s_msg);
				return;
			}
            if (bHinh || bChonhinh)
            {
                if (pathImage != "")
                {
                    if (!System.IO.File.Exists(pathImage + "//" + s_mabn + "." + FileType))
                        System.IO.File.Copy(file, pathImage + "//" + s_mabn + "." + FileType, true);
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
			if (honnhan.Visible && honnhan.SelectedIndex!=-1) m.execute_data("update "+user+m.mmyy(ngayvv.Text)+".lienhe set honnhan="+honnhan.SelectedIndex+" where maql="+l_maql);
			if (bBacsy && mabs.Text!="") m.execute_data("update "+user+m.mmyy(ngayvv.Text)+".lienhe set mabs='"+mabs.Text+"' where maql="+l_maql);
			DataRow r1=m.getrowbyid(dtkp,"viettat='"+makp.Text+"'");
            int itable = m.tableid(m.mmyy(ngayvv.Text), "tiepdon");
            if (m.get_maql_tiepdon(s_mabn, r1["makp"].ToString(), ngayvv.Text + " " + giovv.Text) != 0)
            {
                m.upd_eve_tables(ngayvv.Text, itable, i_userid, "upd");
                m.upd_eve_upd_del(ngayvv.Text, itable, i_userid, "upd",m.fields(zzz+".tiepdon","maql="+l_maql));
            }
            else m.upd_eve_tables(ngayvv.Text, itable, i_userid, "ins");
            if (!m.upd_tiepdon(s_mabn,l_maql, l_maql, r1["makp"].ToString(), ngayvv.Text+" "+giovv.Text, int.Parse(tendoituong.SelectedValue.ToString()), sovaovien.Text, tuoi.Text.PadLeft(3, '0') + loaituoi.SelectedIndex.ToString(), i_userid, bnmoi.SelectedIndex,(bTiepdon_ngoaitru)?(chkNgoaitru.Checked)?-2:0:0, loai.SelectedIndex))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin đăng ký !"),s_msg);
				return;
			}
			if (lydo.Visible && lydo.Text=="") m.upd_lydokham(ngayvv.Text+" "+giovv.Text,l_maql,lydo.Text);
			else m.execute_data("delete from "+user+m.mmyy(ngayvv.Text)+".lydokham where maql="+l_maql);
            if (dausinhton.Visible) m.upd_dausinhton(ngayvv.Text, l_maql, (mach.Text != "") ? decimal.Parse(mach.Text) : 0, (nhietdo.Text != "") ? decimal.Parse(nhietdo.Text) : 0, huyetap.Text, (cannang.Text != "") ? decimal.Parse(cannang.Text) : 0, (chieucao.Text != "") ? decimal.Parse(chieucao.Text) : 0);
			m.upd_sukien(s_mabn,l_maql,LibMedi.AccessData.Tiepdon,l_maql);
			if (khamthai.Visible) m.upd_ttkhamthai(ngayvv.Text,s_mabn,l_maql,para1.Text.PadLeft(2,'0')+para2.Text.PadLeft(2,'0')+para3.Text.PadLeft(2,'0')+para4.Text.PadLeft(2,'0'),kinhcc.Text,ngaysanh.Text,dacdiem.Text);
            //if (n_makp.Visible) upd_tiepdon();
            if (pnmakp.Visible) upd_tiepdon();
            else if (r1["kem"].ToString().Trim() != "") upd_tiepdon(r1["kem"].ToString().Trim());
			string so=m.sothe(int.Parse(tendoituong.SelectedValue.ToString()));
			if (int.Parse(so.Substring(0,2))>0)
			{
				if (!m.upd_bhyt(ngayvv.Text,s_mabn,l_maql,sothe.Text,denngay.Text,mabv.Text,0,tungay.Text,"","","",0))
				{
					MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin bảo hiểm !"),s_msg);
					return;
				}
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
			if (manuoc.Enabled && manuoc.Text!="") m.upd_nuocngoai(s_mabn,manuoc.Text);
			else m.execute_data("delete from "+user+".nuocngoai where mabn='"+s_mabn+"'");
			if (quanhe.Text!="") m.upd_quanhe(ngayvv.Text,l_maql,quanhe.Text,qh_hoten.Text,qh_diachi.Text,qh_dienthoai.Text);
			if (bInkhambenh || bDanhsach || bInphieudieutri ||bKhongintienkham) butIn_Click(null,null);
            if (bDangky_bsbv)
            {
                DataRow r3, r4;
                m.upd_tttiepdon(ngayvv.Text, l_maql, "", bacsy.Text, benhvien.Text,"","");
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
			ena_but(false);
			if (bBangdien)
			{
				dsbdien.Clear();
				r1=dsbdien.Tables[0].NewRow();
				r1["mabn"]=mabn2.Text+mabn3.Text;
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
			butTiep.Focus();
		}

        private void upd_tiepdon(string kem)
        {
            string kp, sokham = sovaovien.Text, ngay, ng = ngayvv.Text + " " + giovv.Text;
            int j = 1;
            long maql = 0;
            string s = kem.Replace(",", "','");
            sql = "select * from btdkp_bv where loai=1";
            sql += " and makp in ('" + s.Substring(0, s.Length - 3) + "')";
            if (i_khudt != 0) sql += " and (khu=0 or khu=" + i_khudt + ")";
            foreach (DataRow r in m.get_data(sql).Tables[0].Rows)
            {
                kp = r["makp"].ToString();
                DateTime dtime = m.StringToDateTime(ng).AddMinutes(j);
                ngay = ng.Substring(0, 10) + " " + dtime.Hour.ToString().PadLeft(2, '0') + ":" + dtime.Minute.ToString().PadLeft(2, '0');
                maql = m.get_maql(s_mabn, kp, ngay);
                if (i_sokham != 3 && bNew) sokham = m.get_sokham(ngay.Substring(0, 10), kp, i_sokham).ToString();
                if (!m.upd_tiepdon(s_mabn,maql, maql, kp, ngay, int.Parse(tendoituong.SelectedValue.ToString()), sokham, tuoi.Text.PadLeft(3, '0') + loaituoi.SelectedIndex.ToString(), i_userid, bnmoi.SelectedIndex,(bTiepdon_ngoaitru)?(chkNgoaitru.Checked)?-2:0:0, loai.SelectedIndex))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin đăng ký !"), s_msg);
                    return;
                }
                if (sothe.Text != "") m.upd_bhyt(ngay, s_mabn, maql, sothe.Text, denngay.Text, mabv.Text, 0, tungay.Text,"","","",0);
                m.upd_sukien(ngay, s_mabn, maql, LibMedi.AccessData.Tiepdon, maql);
                m.upd_eve_tables(ngay, m.tableid(m.mmyy(ngay), "tiepdon"), i_userid, "ins");
                j++;
            }
        }

        private void upd_tiepdon()
        {
            string kp, sokham = sovaovien.Text, ngay, ng = ngayvv.Text + " " + giovv.Text;
            int j = 1;
            long maql = 0;
            //for (int i = 0; i < n_makp.Items.Count; i++)
            foreach (DataRow rk in dtnkp.Select("chon=true", "makp"))
            {
                //if (n_makp.GetItemChecked(i))
                //{
                    kp = rk["makp"].ToString();
                    DateTime dtime = m.StringToDateTime(ng).AddMinutes(j);
                    ngay = ng.Substring(0, 10) + " " + dtime.Hour.ToString().PadLeft(2, '0') + ":" + dtime.Minute.ToString().PadLeft(2, '0');
                    maql = m.get_maql(s_mabn, kp, ngay);
                    if (i_sokham != 3) sokham = m.get_sokham(ngay.Substring(0, 10), kp, i_sokham).ToString();
                if (!m.upd_tiepdon(s_mabn,maql, maql, kp, ngay, int.Parse(tendoituong.SelectedValue.ToString()), sokham, tuoi.Text.PadLeft(3, '0') + loaituoi.SelectedIndex.ToString(), i_userid,(rk["taikham"].ToString().ToLower()=="true")?1:0,0, loai.SelectedIndex))
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin đăng ký !"), s_msg);
                        return;
                    }
                    if (sothe.Text != "") m.upd_bhyt(ngay, s_mabn, maql, sothe.Text, denngay.Text, mabv.Text, 0, tungay.Text,"","","",0);
                    m.upd_sukien(ngay, s_mabn, maql, LibMedi.AccessData.Tiepdon, maql);
                    m.upd_eve_tables(ngay, m.tableid(m.mmyy(ngay), "tiepdon"), i_userid, "ins");
                    j++;
                //}
            }
        }


		private void ena_but(bool ena)
		{
			butLuu.Enabled=ena;
			butBoqua.Enabled=ena;
            if (bInkhambenh || bInphieudieutri) butIn.Enabled = !ena;
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
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
            s_mabn = mabn2.Text + mabn3.Text;
            TreeNode node;
            try
            {
                sql = "select to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay,b.tenkp,to_char(a.ngay,'yyyymmddhh24mi') as yymmdd from xxx.tiepdon a," + user + ".btdkp_bv b where a.makp=b.makp and a.mabn='" + s_mabn + "'" + " and a.noitiepdon=0";
                if (i_khudt != 0) sql += " and (b.khu=0 or b.khu=" + i_khudt + ")";
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
					s_mabn=mabn2.Text+mabn3.Text;
					l_maql=m.get_maql(s_mabn,"??",ngay);
					bNew=l_maql==0;
					if (l_maql!=0)
					{
                        ngayvv.Text = ngay.Substring(0, 10);
                        giovv.Text = ngay.Substring(11);
						load_vv_maql(true);
						load_n_makp(ngayvv.Text+" "+giovv.Text);
						if (!bAdmin) ena_but(false);
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
				DataRow r1=m.getrowbyid(dtkp,"viettat='"+makp.Text+"'");
				if (r1!=null)
				{
					if (this.ActiveControl==tenkp)
					{
						if (i_sokham==2) sovaovien.Text=m.get_sokham(ngayvv.Text.Substring(0,10),r1["makp"].ToString(),i_sokham).ToString();
						if (bSuagiakham || bLuachontienkham) load_dongia();
					}
					if (bHonnhan) vis_honnhan(!m.kiemtra_khamnhi(r1["makp"].ToString()));
				}
			}
			catch{makp.Text="";}
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
			dv.RowFilter="TENBV LIKE '%"+ten.Trim()+"%'";
		}

		private void mabv_Validated(object sender, System.EventArgs e)
		{
			try
			{
                tenbv.Text = m.get_data("select tenbv from " + user + ".dmnoicapbhyt where mabv='" + mabv.Text + "'").Tables[0].Rows[0][0].ToString();
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
			#region phieudieutri
			if (chkDieutri.Checked)
			{
				DataRow r1=m.getrowbyid(dtkp,"viettat='"+makp.Text+"'");
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
				dsdt.Tables[0].Rows[0]["mabn"]=mabn2.Text+mabn3.Text;
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
				dsdt.Tables[0].Rows[0]["dantoc"]=tendantoc.Text;
                dsdt.Tables[0].Rows[0]["cholam"] = cholam.Text;
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
            int j = 1;
            DataRow[] dr;
            DataRow r = m.getrowbyid(dtkp, "viettat='" + makp.Text + "'");
            if (r != null)
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
                    else d_dongia = m.tienkham(madantoc.Text == "55", int.Parse(r[fie].ToString()), int.Parse(madoituong.Text), m.field_gia(madoituong.Text));
                }
                if (bDanhsach)
                {
                    j = 0;
                    DateTime dtime = m.StringToDateTime(ng).AddMinutes(j);
                    ngay = ng.Substring(0, 10) + " " + dtime.Hour.ToString().PadLeft(2, '0') + ":" + dtime.Minute.ToString().PadLeft(2, '0');
                    j++;
                    dr = dtgia.Select("trongoi=1 and id=" + i_mavp);
                    if (dr.Length > 0)
                    {
                        foreach (DataRow r1 in v.get_data("select * from "+user+".v_trongoi where id=" + i_mavp + " order by stt").Tables[0].Rows)
                            upd_data(ngay, int.Parse(r1["id_gia"].ToString()), r["makp"].ToString());
                    }
                    else upd_data(ngay, i_mavp, r["makp"].ToString());
                    if (pnmakp.Visible)
                    {
                        foreach (DataRow rk in dtnkp.Select("chon=true", "makp"))
                        {
                            dtime = m.StringToDateTime(ng).AddMinutes(j);
                            ngay = ng.Substring(0, 10) + " " + dtime.Hour.ToString().PadLeft(2, '0') + ":" + dtime.Minute.ToString().PadLeft(2, '0');
                            i_mavp = (bLuachontienkham) ? int.Parse(tienkham.SelectedValue.ToString()) : int.Parse(rk[(rk["taikham"].ToString().ToLower() == "true") ? "mavptk" : "mavp"].ToString());
                            d_dongia = (bLuachontienkham) ? decimal.Parse(dongia.Text) : m.tienkham(madantoc.Text == "55", i_mavp, int.Parse(madoituong.Text), m.field_gia(madoituong.Text));
                            l_maql = m.get_maql(s_mabn, rk["makp"].ToString(), ngay);
                            dr = dtgia.Select("trongoi=1 and id=" + i_mavp);
                            if (dr.Length > 0)
                            {
                                foreach (DataRow r1 in v.get_data("select * from " + user + ".v_trongoi where id=" + i_mavp + " order by stt").Tables[0].Rows)
                                    upd_data(ngay, int.Parse(r1["id_gia"].ToString()), rk["makp"].ToString());
                            }
                            else upd_data(ngay, i_mavp, rk["makp"].ToString());
                            j++;
                        }
                    }
                }
                else if (kyhieu.SelectedIndex != -1)
                {
                    j = 0;
                    DateTime dtime = m.StringToDateTime(ng).AddMinutes(j);
                    ngay = ng.Substring(0, 10) + " " + dtime.Hour.ToString().PadLeft(2, '0') + ":" + dtime.Minute.ToString().PadLeft(2, '0');
                    l_id = (imavp_the!=0)?m.get_id_vienphi(ngay,l_maql,i_mavp,v.iNgoaitru):m.get_id_vienphi(l_maql, ngay, v.iNgoaitru);
                    bNew = l_id == 0;
                    if (bNew || !b701306)
                    {
                        if (bNew) l_id = v.get_id_vienphi;
                        in_bienlai(l_id, l_maql, ngay, r["makp"].ToString(), tenkp.Text, i_mavp, d_dongia);
                        if (bNew) m.upd_eve_tables(ngay, m.tableid(m.mmyy(ngay), "v_vienphill"), i_userid, "ins");
                    }
                    else if (!bIn1lan) in_bienlai(l_id, l_maql, ngay, r["makp"].ToString(), tenkp.Text, i_mavp, d_dongia);
                    #region nhieuphongkham
                    j++;
                    if (pnmakp.Visible)//(n_makp.Visible)
                    {
                        //for (int i = 0; i < n_makp.Items.Count; i++)
                        foreach (DataRow rk in dtnkp.Select("chon=true", "makp"))
                        {
                            //if (n_makp.GetItemChecked(i))
                            //{
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
                                    else d_dongia = m.tienkham(madantoc.Text == "55", i_mavp, int.Parse(madoituong.Text), m.field_gia(madoituong.Text));
                                }
                                dtime = m.StringToDateTime(ng).AddMinutes(j);
                                ngay = ng.Substring(0, 10) + " " + dtime.Hour.ToString().PadLeft(2, '0') + ":" + dtime.Minute.ToString().PadLeft(2, '0');
                                l_maql = m.get_maql_tiepdon(s_mabn, rk["makp"].ToString(), ngay);
                                //l_id = (imavp_the != 0) ? m.get_id_vienphi(ngay, l_maql, i_mavp, v.iNgoaitru) : m.get_id_vienphi(l_maql, ngay, v.iNgoaitru);
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
                            //}
                        }
                    }
                    #endregion
                }
            }
			#endregion
			butTiep.Focus();
		}

        private void upd_data(string ngay, int _mavp, string _makp)
        {
            d_dongia = 0; d_vattu = 0;
            string mmyy = m.mmyy(ngay), gia; decimal tygia = 1;
            DataRow r = m.getrowbyid(dtgia, "id=" + _mavp);
            int _madoituong = int.Parse(tendoituong.SelectedValue.ToString());
            if (bChuyendoituong && iChuyendoituong1!=0 && iChuyendoituong2!=0)
            {
                if (_madoituong == iChuyendoituong1) _madoituong = iChuyendoituong2;
            }
            if (r != null)
            {
                if (_madoituong == 1 && r["chenhlech"].ToString() == "1" && (r[m.field_gia(m.iTunguyen.ToString())].ToString() != r["gia_bh"].ToString()))
                {
                    l_id = m.get_id_chidinh(ngay, l_maql, 0, v.iNgoaitru);
                    if (l_id == 0)
                    {
                        l_id = v.get_id_chidinh;
                        gia = m.field_gia(_madoituong.ToString());
                        tygia = (gia.IndexOf("_nn") != -1) ? m.dTygia : 1;
                        d_dongia = decimal.Parse(r[gia].ToString()) * tygia;
                        if (d_dongia != 0)  upd_detail(ngay, _makp, _mavp, _madoituong, d_dongia);
                        l_id = v.get_id_chidinh;
                        gia = m.field_gia(m.iTunguyen.ToString());
                        tygia = (gia.IndexOf("_nn") != -1) ? m.dTygia : 1;
                        d_dongia = decimal.Parse(r[gia].ToString()) * tygia - decimal.Parse(r["gia_bh"].ToString());
                        if (d_dongia != 0) upd_detail(ngay, _makp, _mavp, m.iTunguyen, d_dongia);
                    }
                }
                else
                {
                    l_id = m.get_id_chidinh(ngay, l_maql, 0, v.iNgoaitru);
                    if (l_id == 0) l_id = v.get_id_chidinh;
                    gia = m.field_gia(_madoituong.ToString());
                    tygia = (gia.IndexOf("_nn") != -1) ? m.dTygia : 1;
                    d_dongia = decimal.Parse(r[gia].ToString()) * tygia;
                    if (d_dongia != 0)
                        upd_detail(ngay, _makp, _mavp, _madoituong, d_dongia);
                }
            }
        }

        private void upd_detail(string ngay,string _makp,int _mavp,int _madoituong,decimal d_dongia)
        {
            v.upd_chidinh(l_id, mabn2.Text + mabn3.Text, l_maql, l_maql, 0, ngay, v.iNgoaitru, _makp, _madoituong, _mavp, 1, d_dongia,0, i_userid, 0, 0, l_id,"","","",3,"");
            if (bThuphi_kham)
            {
                DataRow r = m.getrowbyid(dtdt, "mien=0 and madoituong=" + _madoituong);
                if (r != null) m.execute_data("update " + user + m.mmyy(ngay) + ".tiepdon set done='x' where maql=" + l_maql);
            }
        }

		private decimal upd_data_vp(long id,int _mavp,int stt,string kp)
		{
			decimal dongia=0,mien=0;
			DataRow r=m.getrowbyid(dtgia,"id="+_mavp);
			if (r!=null)
			{
				if (m.bNuocngoai(mabn2.Text+mabn3.Text))
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

		private void in_bienlai(long id,long maql,string ngay,string kp,string tkp,int mavp,decimal dongia)
		{
			decimal gia=0;					
			string nguoithu=s_userid;
			string lydo="";
			DataRow r=m.getrowbyid(dtuser,"id="+i_useridvp);
			if (r!=null) nguoithu=r["hoten"].ToString();
			DataRow [] dr=dtgia.Select("trongoi=1 and id="+mavp);
			d_dongia=0;d_mien=0;
            bool inbienlai = (dongia - d_mien != 0 || (bBienlai_mien && madoituong.Text != "1"));
            v.upd_vienphill(id, (!inbienlai) ? -1 : long.Parse(kyhieu.SelectedValue.ToString()), (!inbienlai) ? -1 : long.Parse(sobienlai.Text), ngay, mabn2.Text + mabn3.Text, maql, maql, 0, kp, hoten.Text, phai.SelectedIndex, namsinh.Text, sonha.Text.Trim() + " " + thon.Text.Trim(), iLoai, v.iNgoaitru, (!inbienlai) ? -1 : i_useridvp, "");
			if (dr.Length>0) 
			{
				int i=1;
				if (madoituong.Text=="1")
				{
					lydo="Covered by insurance=";
					sql="select a.* from "+user+".v_giavp a,"+user+".v_trongoi b where a.id=b.id_gia and b.id="+mavp+" and a.bhyt<>0 order by b.stt";
					foreach(DataRow r1 in v.get_data(sql).Tables[0].Rows)
					{
						gia=upd_data_vp(id,int.Parse(r1["id"].ToString()),i++,kp);
						lydo=lydo+r1["ten"].ToString().Trim()+"["+gia.ToString("###,###,###").Trim()+"];";
					}
					sql="select a.* from "+user+".v_giavp a,"+user+".v_trongoi b where a.id=b.id_gia and b.id="+mavp+" and a.bhyt=0 order by b.stt";
					lydo+="Patient must pay=";
					foreach(DataRow r1 in v.get_data(sql).Tables[0].Rows)
					{
						gia=upd_data_vp(id,int.Parse(r1["id"].ToString()),i++,kp);
						lydo=lydo+r1["ten"].ToString().Trim()+"["+gia.ToString("###,###,###").Trim()+"];";
					}
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
				if (madoituong.Text=="1")
				{
					int i_maphu=0;
					v.upd_bhyt(ngayvv.Text,id,sothe.Text,i_maphu,mabv.Text,"");
				}
				else if (pmien.Visible)
				{
					if (m.mien_doituong(int.Parse(madoituong.Text),dtdt))
						v.upd_mienngtru(ngayvv.Text,id,dongia,"",int.Parse(duyet.SelectedValue.ToString()),int.Parse(lydomien.SelectedValue.ToString()));
				}
				gia=upd_data_vp(id,mavp,1,kp);
				lydo=m.get_tenvp(mavp);
			}
            inbienlai = (dongia - d_mien != 0 || (bBienlai_mien && madoituong.Text != "1"));
			if (inbienlai)
			{
				if (bKyhieu_chung && bNew) sobienlai.Text=m.get_sobienlai(long.Parse(kyhieu.SelectedValue.ToString()),true).ToString();
				else if (bNew) m.upd_sobienlai(long.Parse(kyhieu.SelectedValue.ToString()),int.Parse(sobienlai.Text));
			}
            v.upd_vienphill(id, (!inbienlai)? -1 : long.Parse(kyhieu.SelectedValue.ToString()), (!inbienlai) ? -1 : long.Parse(sobienlai.Text), ngay, mabn2.Text + mabn3.Text, maql, maql, 0, kp, hoten.Text, phai.SelectedIndex, namsinh.Text, sonha.Text.Trim() + " " + thon.Text.Trim(), iLoai, v.iNgoaitru, (!inbienlai) ? -1 : i_useridvp, "");
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
                    r1["tongcucthue"] = tendoituong.Text;
                    r1["cucthue"] = madoituong.Text;
					r1["masothue"]=v.Masothue;
					r1["mauso"]=v.Mausobienlai;
					r1["nguoiin"]=s_userid;
					r1["ngaysinh"]=ngaysinh.Text;
                    r1["namsinh"] = namsinh.Text;
					r1["gioitinh"]=phai.Text;
					r1["quyenso"]=kyhieu.Text;
					r1["sobienlai"]=sobienlai.Text;
					r1["hoten"]=hoten.Text;
					r1["mabn"]=mabn2.Text+mabn3.Text;
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
                        r1["doituong"] = tendoituong.Text;//binh 240108
                    }
                    catch 
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Thêm 2 field: dienthoai, doituong trong file v_bienlai.xml, trong thu muc xml"));
                        m.upd_error("Them 2 field: dienthoai, doituong trong file v_bienlai.xml, trong thu muc xml", "", "v_bienlai.xml"); 
                    }
					dsxml.Tables[0].Rows.Add(r1);
				}
				sobienlai.Text=m.get_sobienlai(long.Parse(kyhieu.SelectedValue.ToString()),1).ToString();
				m.updrec(dtkh,long.Parse(kyhieu.SelectedValue.ToString()),sobienlai.Text);
				if (bInkhambenh)
				{
                    if (bDocmavach)
                    {
                        if (!System.IO.Directory.Exists("c://reportpic")) System.IO.Directory.CreateDirectory("c://reportpic");
                        barcode.Picture.Save("c://reportpic//barcode.bmp");
                    }
					if (chkXem.Checked)
					{
						dllReportM.frmReport f=new dllReportM.frmReport(dsxml,s_userid,sovaovien.Text,"v_bienlaithuvienphi.rpt");
						f.ShowDialog(this);
					}
					else 
					{
						print.Printer(dsxml,"v_bienlaithuvienphi.rpt",s_userid,sovaovien.Text,0);
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
					if (!m.kiemtra_bienlai(long.Parse(kyhieu.SelectedValue.ToString()),int.Parse(sobienlai.Text)))
					{
						MessageBox.Show(lan.Change_language_MessageText("Số biên lai vượt quá trong khoản từ : ")+dtkh.Rows[kyhieu.SelectedIndex]["tu"].ToString()+" đến : "+dtkh.Rows[kyhieu.SelectedIndex]["den"].ToString(),LibMedi.AccessData.Msg);
						sobienlai.Text=dtkh.Rows[kyhieu.SelectedIndex]["soghi"].ToString();
						sobienlai.Focus();
						return;
					}
					m.upd_sobienlai(long.Parse(kyhieu.SelectedValue.ToString()),int.Parse(sobienlai.Text));
					m.updrec(dtkh,long.Parse(kyhieu.SelectedValue.ToString()),sobienlai.Text);
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
				m.updrec(dtkh,long.Parse(kyhieu.SelectedValue.ToString()),sobienlai.Text);
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
			s_mabn=mabn2.Text+mabn3.Text;
			DataRow r1=m.getrowbyid(dtkp,"viettat='"+makp.Text+"'");
			if (r1==null) return;
			l_maql=m.get_maql_tiepdon(s_mabn,r1["makp"].ToString(),ngayvv.Text+" "+giovv.Text);
			if (l_maql==0)
			{
				if (!kiemtra()) return;
				butLuu_Click(null,null);
			}
            dllvpkhoa_chidinh.frmChidinh f = new dllvpkhoa_chidinh.frmChidinh(m, s_mabn, hoten.Text, tuoi.Text + " " + loaituoi.Text, ngayvv.Text + " " + giovv.Text, r1["makp"].ToString(), tenkp.Text, int.Parse(madoituong.Text), v.iNgoaitru, l_maql, l_maql, 0, i_userid, "xxx.tiepdon", sothe.Text, nam, 3, "", "", "", 0,true,i_khudt);
			f.ShowDialog(this);
			load_chidinh();
		}

		private void l_diungthuoc_Click(object sender, System.EventArgs e)
		{
			s_mabn=mabn2.Text+mabn3.Text;
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
            if (makp.Text == "" || tenkp.SelectedIndex == -1)
            {
                makp.Focus();
                return;
            }
            dtnkp.Clear();
            DataRow r1;

            sql = "select * from " + user + ".btdkp_bv where loai=1 and viettat<>'" + makp.Text + "'";
            if (i_khudt != 0) sql += " and (khu=0 or khu=" + i_khudt + ")";
            sql += "  order by makp";
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
            barcode.Picture.Save("c://reportpic//barcode.bmp");
			dllReportM.frmReport f=new dllReportM.frmReport(m,null,"rptbarcode.rpt",mabn2.Text+mabn3.Text,hoten.Text,namsinh.Text,phai.Text,sonha.Text.Trim()+" "+thon.Text.Trim()+" "+tenpxa.Text.Trim()+","+tenquan.Text.Trim()+","+tentinh.Text.Trim(),"");
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
			s_mabn=mabn2.Text+mabn3.Text;
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

		private void tenbs_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tenbs)
			{
				Filt_tenbs(tenbs.Text);
				if (dausinhton.Visible) listBS.BrowseToICD10(tenbs,mabs,mach,mabs.Location.X,mabs.Location.Y+mabs.Height,mabs.Width+tenbs.Width+2,mabs.Height);
				else if (khamthai.Visible) listBS.BrowseToICD10(tenbs,mabs,para1,mabs.Location.X,mabs.Location.Y+mabs.Height,mabs.Width+tenbs.Width+2,mabs.Height);
				else if (bSuagiakham) listBS.BrowseToICD10(tenbs,mabs,dongia,mabs.Location.X,mabs.Location.Y+mabs.Height,mabs.Width+tenbs.Width+2,mabs.Height);
				else if (pmien.Visible) listBS.BrowseToICD10(tenbs,mabs,lydomien,mabs.Location.X,mabs.Location.Y+mabs.Height,mabs.Width+tenbs.Width+2,mabs.Height);
				else listBS.BrowseToICD10(tenbs,mabs,butLuu,mabs.Location.X,mabs.Location.Y+mabs.Height,mabs.Width+tenbs.Width+2,mabs.Height);				
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
			dv.RowFilter="TENBV LIKE '%"+ten.Trim()+"%'";
		}

		private void sothe_TextChanged(object sender, System.EventArgs e)
		{
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
            l_maql = m.get_maql_tiepdon_ngay(s_mabn, ngayvv.Text);
            if (l_maql != 0)
            {
                if (MessageBox.Show(lan.Change_language_MessageText("Người bệnh này đã được đăng ký,") + "\n" + lan.Change_language_MessageText("Bạn có muốn xem lại !"), LibMedi.AccessData.Msg, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    load_vv_maql(false);
                    if (!bAdmin) ena_but(false);
                    s_ngayvv = ngayvv.Text;
                    return;
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
            ref_check();
            string s = ngayvv.Text + " " + giovv.Text;
            int i_madt = 0;
            s_mabn = mabn2.Text + mabn3.Text;
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
                    load_quanhe();
                    emp_bhyt();
                    ngayvv.Text = s.Substring(0, 10);
                    giovv.Text = s.Substring(11);
                    if (i_madt != 0)
                    {
                        try
                        {
                            madoituong.Text = i_madoituong_ng.ToString();
                            tendoituong.SelectedValue = madoituong.Text;
                        }
                        catch { madoituong.Text = ""; tendoituong.SelectedIndex = -1; }
                    }
                    if (bSuagiakham || bLuachontienkham) load_dongia();
                }
                s_ngayvv = s;
            }
            if (i_sokham != 3 && makp.Text != "" && sovaovien.Text == "")
            {
                DataRow r1 = m.getrowbyid(dtkp, "viettat='" + makp.Text + "'");
                if (r1 != null) sovaovien.Text = m.get_sokham(ngayvv.Text.Substring(0, 10), r1["makp"].ToString(), i_sokham).ToString();
            }
        }
        private void load_quanhe()
        {
            if (nam != "")
            {
                try
                {
                    foreach (DataRow r in m.get_data_nam_dec(nam, "select b.* from xxx.tiepdon a,xxx.quanhe b where a.maql=b.maql and a.mabn='" + mabn2.Text + mabn3.Text + "'").Tables[0].Rows)
                    {
                        quanhe.Text = r["quanhe"].ToString();
                        qh_hoten.Text = r["hoten"].ToString();
                        qh_diachi.Text = r["diachi"].ToString();
                        qh_dienthoai.Text = r["dienthoai"].ToString();
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
            if (bHinh)
            {
                Medisoft_Image.frmChuphinh f = new Medisoft_Image.frmChuphinh();
                f.ShowDialog();
                if (f.path_image != "")
                {
                    string sDir = System.Environment.CurrentDirectory.ToString();
                    pic.Tag = f.path_image;
                    fstr = new System.IO.FileStream(pic.Tag.ToString(), System.IO.FileMode.Open, System.IO.FileAccess.Read);
                    image = new byte[fstr.Length];
                    fstr.Read(image, 0, System.Convert.ToInt32(fstr.Length));
                    if (pathImage == "") pic.Tag = image;
                    map = new Bitmap(Image.FromStream(fstr));
                    pic.Image = (Bitmap)map;
                    fstr.Close();
                    System.Environment.CurrentDirectory = sDir;
                    butLuu.Focus();
                }
            }
            else if (bChonhinh)
            {
                string sDir = System.Environment.CurrentDirectory.ToString();
                OpenFileDialog of = new OpenFileDialog();
                of.Title = "Chọn hình";
                of.Filter = "Files (*."+FileType+")|*.*|All Files (*.*)|*.*";
                of.RestoreDirectory = true;
                if (of.ShowDialog() == DialogResult.OK)
                {
                    pic.Tag = of.FileName;
                    fstr = new System.IO.FileStream(pic.Tag.ToString(), System.IO.FileMode.Open, System.IO.FileAccess.Read);
                    image = new byte[fstr.Length];
                    fstr.Read(image, 0, System.Convert.ToInt32(fstr.Length));
                    if (pathImage == "") pic.Tag = image;
                    map = new Bitmap(Image.FromStream(fstr));
                    pic.Image = (Bitmap)map;
                    fstr.Close();
                    File.Copy(pic.Tag.ToString(), file, true);
                }
                System.Environment.CurrentDirectory = sDir;
                butLuu.Focus();
            }
        }

        private void butGoi_Click(object sender, EventArgs e)
        {
            tu.Value = den.Value + 1;
            den.Value = den.Value + sonhay.Value;
            tu.Update(); den.Update();
            m.goi_dangky(ngaysrv, i_userid, tu.Value.ToString(), den.Value.ToString(),true);
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
            dsthe.Tables[0].Rows[0]["mabn"] = mabn2.Text + mabn3.Text;
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
                map = new Bitmap(Image.FromStream(fstr));
                pic.Image = (Bitmap)map;
                image = new byte[fstr.Length];
                fstr.Read(image, 0, System.Convert.ToInt32(fstr.Length));
                fstr.Close();
                dsthe.Tables[0].Rows[0]["image"] = image;
            }
            if (barcode.Visible)
            {
                if (!System.IO.Directory.Exists("..//barcode")) System.IO.Directory.CreateDirectory("..//barcode");
                barcode.Picture.Save("..//barcode//barcode.bmp");
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
            DataRow r1 = m.getrowbyid(dtkp, "viettat='" + makp.Text + "'");
            if (r1 != null)
            {
                string ngay = ngayvv.Text + " " + giovv.Text;
                l_maql = m.get_maql_tiepdon(s_mabn, r1["makp"].ToString(),ngay);
                if (l_maql == 0)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Thông tin đăng ký chưa cập nhật !"), LibMedi.AccessData.Msg);
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

        private decimal upd_data_the(long id, int _mavp, int stt, string kp)
        {
            decimal dongia = 0,mien=0;
            int _madoituong = int.Parse(madoituong.Text);
            DataRow r = m.getrowbyid(dtgia, "id=" + _mavp);
            if (r != null)
            {
                if (m.bNuocngoai(mabn2.Text + mabn3.Text))
                    dongia = decimal.Parse(r["gia_nn"].ToString()) * m.dTygia;
                else
                {
                    string gia = m.field_gia(tendoituong.SelectedValue.ToString());
                    string giavt = "vattu_" + gia.Substring(4).Trim();
                    dongia = decimal.Parse(r[gia].ToString());
                }
                if (madoituong.Text == "1") mien = (r["bhyt"].ToString() == "0") ? 0 : dongia;
                else if (m.mien_doituong(int.Parse(madoituong.Text), dtdt)) mien = dongia;
                if (mien == dongia) _madoituong = m.iTunguyen;
                v.upd_vienphict(ngayvv.Text + " " + giovv.Text, id, stt, _madoituong, _mavp, r["ten"].ToString(), 1, dongia,0, 0, 0, "", kp);
            }
            return dongia;
        }

        private void in_bienlaithe(long id, long maql, string ngay, string kp, string tkp, int mavp)
        {
            string nguoithu = s_userid;
            string lydo = "";
            DataRow r = m.getrowbyid(dtuser, "id=" + i_useridvp);
            if (r != null) nguoithu = r["hoten"].ToString();
            r = m.getrowbyid(dtgia, "id=" + imavp_the);
            if (r != null) lydo = r["ten"].ToString();
            v.upd_vienphill(id, long.Parse(kyhieu.SelectedValue.ToString()), long.Parse(sobienlai.Text), ngay, mabn2.Text + mabn3.Text, l_maql, l_maql, 0, kp, hoten.Text, phai.SelectedIndex, namsinh.Text, sonha.Text.Trim() + " " + thon.Text.Trim(), iLoai, v.iNgoaitru, i_useridvp, "");
            d_dongia = upd_data_the(id, mavp, 1, kp);
            if (d_dongia != 0)
            {
                if (bKyhieu_chung && bNew) sobienlai.Text = m.get_sobienlai(long.Parse(kyhieu.SelectedValue.ToString()), true).ToString();
                else if (bNew) m.upd_sobienlai(long.Parse(kyhieu.SelectedValue.ToString()), int.Parse(sobienlai.Text));
            }
            v.upd_vienphill(id, long.Parse(kyhieu.SelectedValue.ToString()), long.Parse(sobienlai.Text), ngay, mabn2.Text + mabn3.Text, l_maql, l_maql, 0, kp, hoten.Text, phai.SelectedIndex, namsinh.Text, sonha.Text.Trim() + " " + thon.Text.Trim(), iLoai, v.iNgoaitru, i_useridvp, "");
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
                    r1["mabn"] = mabn2.Text + mabn3.Text;
                    r1["diachi"] = sonha.Text.Trim() + " " + thon.Text.Trim() + " " + tenpxa.Text.Trim() + ", " + tenquan.Text.Trim() + ", " + tentinh.Text.Trim();
                    r1["khoa"] = tkp;
                    r1["lydo"] = lydo;
                    r1["sotien"] = d_dongia.ToString();
                    r1["chutien"] = doiso.doiraso(dongia.ToString());
                    r1["diengiai"] = lydo;
                    r1["ghichu"] = lydo;
                    r1["ngayin"] = ngayvv.Text.Substring(0, 10);
                    r1["lien"] = dslien.Tables[0].Rows[i]["ten"].ToString();
                    r1["nguoithu"] = nguoithu;
                    dsxml.Tables[0].Rows.Add(r1);
                }
                sobienlai.Text = m.get_sobienlai(long.Parse(kyhieu.SelectedValue.ToString()), 1).ToString();
                m.updrec(dtkh, long.Parse(kyhieu.SelectedValue.ToString()), sobienlai.Text);
                if (bDocmavach)
                {
                    if (!System.IO.Directory.Exists("c://reportpic")) System.IO.Directory.CreateDirectory("c://reportpic");
                    barcode.Picture.Save("c://reportpic//barcode.bmp");
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
            s_mabn=mabn2.Text+mabn3.Text;
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

        }

        private void chkNgoaitru_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            if (mabn2.Text == "" || mabn3.Text == "" || hoten.Text == "") return;
            s_mabn = mabn2.Text + mabn3.Text;
            frmBenhmantinh f = new frmBenhmantinh(m, s_mabn, i_userid);
            f.ShowDialog();
        }

        private void start_smartcard()
        {
            int err_Renamed = -1;
            string strError = "";
            MIFARES501.Dev_Silence = true;

            for (int intComPort = 1; intComPort <= 2; intComPort++)
            {
                err_Renamed = MIFARES501.Dev_OpenComPort(intComPort);
                if (err_Renamed == 0)
                    if (err_Renamed == 0) break;
                if (err_Renamed != 0)
                    strError = MIFARES501.ErrMsg;
            }
        }

        private void butSmartcard_Click(object sender, EventArgs e)
        {
            strUID = "";
            clsSMCart.Read_UID(MIFARES501, ref strUID,false);
            clsSMCart.DocHISA_TTBN(MIFARES501, strUID);
            if (clsSMCart.strError.Trim() == "")
            {
                try
                {
                    //
                    MIFARES501.Dev_SetBeeper(1, 0);
                    //
                    string txtMSBN = clsSMCart.strMSBN.Substring(6);
                    mabn1.Text = clsSMCart.strMSBN.Substring(0, 6);
                    mabn2.Text = txtMSBN.Substring(0, 2);
                    mabn3.Text = txtMSBN.Substring(2);
                    hoten.Text = c.Doi_ma_sang_kytuviet(clsSMCart.strHoten);
                    phai.SelectedIndex = int.Parse(clsSMCart.strPhai);
                    //numNhommau.Value = decimal.Parse(clsSMCart.strNhommau);
                    string txtNgaysinh = clsSMCart.strNgaysinh.Trim();
                    if (txtNgaysinh != "")
                    {
                        if (txtNgaysinh.Length == 8)
                        {
                            ngaysinh.Text = txtNgaysinh.Substring(0, 2) + "/" + txtNgaysinh.Substring(2, 2) + "/" + txtNgaysinh.Substring(4);
                            string tuoivao = m.Tuoivao("", ngaysinh.Text);
                            tuoi.Text = tuoivao.Substring(2).PadLeft(3, '0');
                            loaituoi.SelectedIndex = int.Parse(tuoivao.Substring(0, 1));
                            namsinh.Text = m.Namsinh(ngaysinh.Text).ToString();
                        }
                        else if (txtNgaysinh.Length == 4)
                        {
                            namsinh.Text = txtNgaysinh;
                            tuoi.Text = Convert.ToString(DateTime.Now.Year - int.Parse(namsinh.Text)).PadLeft(3, '0');
                            loaituoi.SelectedIndex = 0;
                        }
                    }
                    string txtDiachi = clsSMCart.strDiachi;
                    tentinh.SelectedValue = txtDiachi.Substring(0, 3);
                    load_quan();
                    tenquan.SelectedValue = txtDiachi.Substring(0, 5);
                    load_pxa();
                    tenpxa.SelectedValue = txtDiachi;
                    thon.Text = c.Doi_ma_sang_kytuviet(clsSMCart.strSonha);
                    dt_nha.Text = clsSMCart.strDienthoai;
                    string txtDiungthuoc = clsSMCart.strDiungthuoc;
                    string txtBenhmantinh = clsSMCart.strBenhmantinh;
                    s_mabn = mabn2.Text + mabn3.Text;
                    if (load_mabn()) ngayvv.Focus();
                    else hoten.Focus();
                }
                catch { }
            }
            else MessageBox.Show(clsSMCart.strError);

            clsSMCart.Doc_BHYT(MIFARES501, strUID);
            if (clsSMCart.strError == "")
            {
                sothe.Text = clsSMCart.strSothe;
                string txtTungay = clsSMCart.strNgaybatdau.Trim();
                if (txtTungay.Length == 6) tungay.Text = txtTungay.Substring(0, 2) + "/" + txtTungay.Substring(2, 2) + "/20" + txtTungay.Substring(4);
                string txtDenngay = clsSMCart.strNgayketthuc.Trim();
                if (txtDenngay.Length == 6) denngay.Text = txtDenngay.Substring(0, 2) + "/" + txtDenngay.Substring(2, 2) + "/20" + txtDenngay.Substring(4);
                if (sothe.Text != "")
                {
                    //if (bSothe_dkkcb)
                    //{
                        int _dai=18,_vitri=14;
                        string _sothe = "79001";
                        if (sothe.Text.Trim().Length == _dai && _vitri != 0 && _sothe != "")
                        {
                            mabv.Text = sothe.Text.Substring(_vitri - 1, _sothe.Length);
                            mabv_Validated(sender, e);
                            madoituong.Text = tendoituong.SelectedText = "1";
                        }
                    //}
                }
                string txtDonvichitra = clsSMCart.strDonvichitra;
            }
            else MessageBox.Show(clsSMCart.strError);

        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            if (mabn2.Text == "" || mabn3.Text == "" || hoten.Text == "") return;
            frmTheodoitsu f = new frmTheodoitsu(m, mabn2.Text + mabn3.Text, hoten.Text, namsinh.Text, phai.Text);
            f.ShowDialog();
        }
	}
}
