using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibVienphi;
using LibMedi;
using LibDuoc;
using System.IO;
namespace libxTutruc
{
	/// <summary>
	/// Summary description for frmXuatvien.
	/// </summary>
	public class frmXuatkhoa : System.Windows.Forms.Form
	{
		Language lan = new Language();
        Bogotiengviet tv = new Bogotiengviet();
        private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private LibMedi.AccessData m;
		private LibDuoc.AccessData d=new LibDuoc.AccessData();
        private LibVienphi.AccessData v = new LibVienphi.AccessData();
		private DataSet ds=new DataSet();
        private DataTable  dtbs = new DataTable ();
        private string user, nam, s_userid, s_makp, s_mabn, s_msg, s_ngayvv, s_ngayvk, s_ngayrk, m_nguyennhan, m_phainu, m_sosinh, s_ngayde, s_ngaybong, para, s_noicap, u00 = "U00", makp_chuyenkhoa,s_tenkhoa="",s_tungay="",ngay1="",ngay2="",ngay3="";
		private int i_userid,i_mabv,i_maba,traituyen=0;
		private decimal l_id=0,l_maql=0,l_matd=0;
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
		private MaskedTextBox.MaskedTextBox giuong;
		private System.Windows.Forms.Label label38;
		private System.Windows.Forms.ComboBox tenketqua;
		private System.Windows.Forms.TextBox ketqua;
		private System.Windows.Forms.Label label39;
		private System.Windows.Forms.ComboBox tenttlucrv;
		private System.Windows.Forms.TextBox ttlucrv;
		private System.Windows.Forms.Label label40;
		private System.Windows.Forms.Label label42;
		private MaskedTextBox.MaskedTextBox icd_chinh;
		private System.Windows.Forms.Label label44;
		private MaskedTextBox.MaskedTextBox icd_nguyennhan;
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
        private System.Windows.Forms.Button butKetthuc;
        private int songay = 30, iTreem6, iTreem15, madoituong_giuongdichvu;
        private bool b_Edit = false, b_Hoten = false, bSankhoa, bBong, bUngbuou, bNhi, bSosinh, bTamthan, b_bacsi, bHanhchinh, bLuutru_Mabn, bAdmin, bNhapsoluutru, bMabame, bKhamthai, bTiepdon, bChuyenkhoasan, bTress_bame, bPhonggiuong, bDanhmuc_nhathuoc, bTtptttkhoa;
		private System.Windows.Forms.TextBox songaydt;
		private System.Windows.Forms.CheckBox giaiphau;
		private System.Windows.Forms.ToolTip toolTip2;
		private System.ComponentModel.IContainer components;
        private bool b_sovaovien, b_soluutru, bDenngay_sothe, bChandoan, bChandoan_kemtheo, bChandoan_nguyennhan, bSoluutru_icd10, b101204, bSoluutru_sovaovien, bSoluutru, bInravien_ravien, bThanhtoan_khoa, bNgayra_ngayvao_1, bSoluutru_xuatkhoa, bGiuong_khoa, bKiemtra,bSothe_ngay_huong;
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
		private System.Windows.Forms.Label label32;
		private MaskedTextBox.MaskedTextBox icd_vaokhoa;
		private System.Windows.Forms.Label lvaokhoa;
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
		private System.Windows.Forms.Label label25;
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
		private System.Windows.Forms.Panel pungbuou_v;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label36;
		private System.Windows.Forms.Panel pungbuou_r;
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
		private MaskedTextBox.MaskedTextBox giaidoan_v;
		private MaskedTextBox.MaskedTextBox m_v;
		private MaskedTextBox.MaskedTextBox n_v;
		private MaskedTextBox.MaskedTextBox t_v;
		private MaskedTextBox.MaskedTextBox giaidoan_r;
		private MaskedTextBox.MaskedTextBox m_r;
		private MaskedTextBox.MaskedTextBox n_r;
		private MaskedTextBox.MaskedTextBox t_r;
		private System.Windows.Forms.TreeView treeView1;
		private System.Windows.Forms.Label label64;
		private System.Windows.Forms.Label label65;
		private System.Windows.Forms.Panel pkhoaden;
		private System.Windows.Forms.ComboBox tenkhoaden;
		private System.Windows.Forms.TextBox khoaden;
		private System.Windows.Forms.TreeView treeView2;
		private System.Windows.Forms.Label lkhoa;
        private System.Windows.Forms.ComboBox gphaubenh;
		private System.Windows.Forms.CheckBox tainantt;
		private MaskedBox.MaskedBox ngaysinh;
		private MaskedBox.MaskedBox denngay;
		private MaskedBox.MaskedBox ngaybong;
		private MaskedBox.MaskedBox ngayvk;
		private MaskedBox.MaskedBox ngayrv;
		private System.Windows.Forms.ComboBox cmbTaibien;
		private MaskedBox.MaskedBox ngayvv;
		private System.Windows.Forms.Label label14;
		private string s_icd_noichuyenden,s_icd_kkb,s_icd_vaokhoa,s_icd_chinh,s_icd_kemtheo,s_icd_nguyennhan,s_mabv,s_madstt,sql,khoadens="";
		private LibList.List listICD;
		private System.Windows.Forms.TextBox cd_vaokhoa;
		private System.Windows.Forms.TextBox cd_noichuyenden;
		private System.Windows.Forms.TextBox cd_kkb;
		private System.Windows.Forms.TextBox cd_kemtheo;
		private System.Windows.Forms.TextBox cd_chinh;
		private System.Windows.Forms.TextBox cd_nguyennhan;
		private MaskedTextBox.MaskedTextBox mame;
        private System.Windows.Forms.Label label66;
		private System.Windows.Forms.Panel khamthai;
		private MaskedTextBox.MaskedTextBox para4;
		private MaskedTextBox.MaskedTextBox para3;
		private MaskedTextBox.MaskedTextBox para2;
		private MaskedTextBox.MaskedTextBox para1;
		private System.Windows.Forms.Label label67;
        private System.Windows.Forms.Button butVienphi;
        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButton1;
        private ToolStripButton toolStripButton2;
        private ToolStripButton toolStripButton3;
        private ToolStripButton toolStripButton4;
        private ToolStripButton toolStripButton5;
        private ToolStripButton toolStripButton6;
        private ToolStripButton toolStripButton7;
        private CheckBox chkIn;
        private Label label68;
        private CheckBox kiemsoat;
        private MaskedBox.MaskedBox ngayde;
        private Label label9;
        private TextBox matb;
        private ComboBox tentb;
        private Panel psankhoa;
        private MaskedBox.MaskedBox giode;
        private Label label10;
        private MaskedBox.MaskedBox giovk;
        private Label label76;
        private MaskedBox.MaskedBox giovv;
        private Label label75;
        private MaskedBox.MaskedBox giorv;
        private Label label69;
        private Button butBoqua;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton toolStripButton8;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripSeparator toolStripSeparator7;
        private ToolStripSeparator toolStripSeparator8;
        private ToolStripButton toolStripButton9;
        private ToolStripButton toolStripButton10;
        private ToolStripSeparator toolStripSeparator9;
		private DataTable dticd=new DataTable();
        private DataTable dtg = new DataTable();
        private TextBox tenbs;
        private LibList.List listBS;
        private DataTable dtdt = new DataTable();
	
		public frmXuatkhoa(LibMedi.AccessData acc,string makp,string hoten,int userid,int mabv,bool sovaovien,bool soluutru)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
            m = acc; s_makp = makp; s_userid = hoten; i_userid = userid; i_mabv = mabv; b_sovaovien = sovaovien; b_soluutru = soluutru; loaituoi.Items.Clear();
            loaituoi.Items.AddRange(new string[]{lan.Change_language_MessageText("Năm tuổi"),
                                                 lan.Change_language_MessageText("Tháng tuổi"),
                                                 lan.Change_language_MessageText("Ngày tuổi"),
                                                 lan.Change_language_MessageText("Giờ tuổi")});

            phai.Items.Clear();
            if (m.bBogo) tv.GanBogo(this, textBox111);
            phai.Items.AddRange(new string[]{lan.Change_language_MessageText("Nam"),
                                                 lan.Change_language_MessageText("Nữ")});
            //
			// TODO: Add any constructor code after InitializeComponent call
			//
		}
        //--linh
        public frmXuatkhoa(LibMedi.AccessData acc, string makp, string hoten, int userid, int mabv, bool sovaovien, bool soluutru, string _, string mabn, string tenba)
        {
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this); tv.GanBogo(this, textBox111);
            m = acc; s_makp = makp; s_userid = hoten; i_userid = userid; i_mabv = mabv; b_sovaovien = sovaovien; b_soluutru = soluutru; loaituoi.Items.Clear();
            loaituoi.Items.AddRange(new string[]{lan.Change_language_MessageText("Năm tuổi"),
                                                 lan.Change_language_MessageText("Tháng tuổi"),
                                                 lan.Change_language_MessageText("Ngày tuổi"),
                                                 lan.Change_language_MessageText("Giờ tuổi")});

            phai.Items.Clear();
            phai.Items.AddRange(new string[]{lan.Change_language_MessageText("Nam"),
                                                 lan.Change_language_MessageText("Nữ")});
        }//end

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmXuatkhoa));
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
            this.giuong = new MaskedTextBox.MaskedTextBox();
            this.label38 = new System.Windows.Forms.Label();
            this.tenketqua = new System.Windows.Forms.ComboBox();
            this.ketqua = new System.Windows.Forms.TextBox();
            this.label39 = new System.Windows.Forms.Label();
            this.tenttlucrv = new System.Windows.Forms.ComboBox();
            this.ttlucrv = new System.Windows.Forms.TextBox();
            this.label40 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.icd_chinh = new MaskedTextBox.MaskedTextBox();
            this.icd_nguyennhan = new MaskedTextBox.MaskedTextBox();
            this.label44 = new System.Windows.Forms.Label();
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
            this.giaiphau = new System.Windows.Forms.CheckBox();
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.tdvh = new MaskedTextBox.MaskedTextBox();
            this.lanthu = new MaskedTextBox.MaskedTextBox();
            this.ss_para4 = new MaskedTextBox.MaskedTextBox();
            this.ss_para3 = new MaskedTextBox.MaskedTextBox();
            this.ss_para2 = new MaskedTextBox.MaskedTextBox();
            this.ss_para1 = new MaskedTextBox.MaskedTextBox();
            this.pnhi = new System.Windows.Forms.Panel();
            this.nhi_mann_me = new System.Windows.Forms.TextBox();
            this.nhi_tennn_me = new System.Windows.Forms.ComboBox();
            this.label43 = new System.Windows.Forms.Label();
            this.nhi_vanhoa_me = new System.Windows.Forms.TextBox();
            this.label45 = new System.Windows.Forms.Label();
            this.nhi_mann_bo = new System.Windows.Forms.TextBox();
            this.nhi_tennn_bo = new System.Windows.Forms.ComboBox();
            this.label41 = new System.Windows.Forms.Label();
            this.nhi_vanhoa_bo = new System.Windows.Forms.TextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.nhi_hoten_me = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.nhi_hoten_bo = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
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
            this.psosinh = new System.Windows.Forms.Panel();
            this.mame = new MaskedTextBox.MaskedTextBox();
            this.label66 = new System.Windows.Forms.Label();
            this.ss_hoten_me = new System.Windows.Forms.TextBox();
            this.ss_ns_bo = new MaskedTextBox.MaskedTextBox();
            this.label60 = new System.Windows.Forms.Label();
            this.ss_mann_bo = new System.Windows.Forms.TextBox();
            this.ss_tennn_bo = new System.Windows.Forms.ComboBox();
            this.label61 = new System.Windows.Forms.Label();
            this.ss_hoten_bo = new System.Windows.Forms.TextBox();
            this.label62 = new System.Windows.Forms.Label();
            this.ss_delan = new MaskedTextBox.MaskedTextBox();
            this.label59 = new System.Windows.Forms.Label();
            this.ss_ns_me = new MaskedTextBox.MaskedTextBox();
            this.label58 = new System.Windows.Forms.Label();
            this.ss_mann_me = new System.Windows.Forms.TextBox();
            this.ss_tennn_me = new System.Windows.Forms.ComboBox();
            this.label56 = new System.Windows.Forms.Label();
            this.label57 = new System.Windows.Forms.Label();
            this.phai = new System.Windows.Forms.ComboBox();
            this.lphai = new System.Windows.Forms.Label();
            this.ppara = new System.Windows.Forms.Panel();
            this.label64 = new System.Windows.Forms.Label();
            this.ss_nhommau = new System.Windows.Forms.ComboBox();
            this.label63 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.pvaovien = new System.Windows.Forms.Panel();
            this.ngayvv = new MaskedBox.MaskedBox();
            this.giovv = new MaskedBox.MaskedBox();
            this.label75 = new System.Windows.Forms.Label();
            this.ngayvk = new MaskedBox.MaskedBox();
            this.giovk = new MaskedBox.MaskedBox();
            this.label76 = new System.Windows.Forms.Label();
            this.cd_vaokhoa = new System.Windows.Forms.TextBox();
            this.cd_noichuyenden = new System.Windows.Forms.TextBox();
            this.cd_kkb = new System.Windows.Forms.TextBox();
            this.ngaybong = new MaskedBox.MaskedBox();
            this.denngay = new MaskedBox.MaskedBox();
            this.tenkp = new System.Windows.Forms.ComboBox();
            this.lbong = new System.Windows.Forms.Label();
            this.ltdvh = new System.Windows.Forms.Label();
            this.label55 = new System.Windows.Forms.Label();
            this.madoituong = new System.Windows.Forms.TextBox();
            this.tendentu = new System.Windows.Forms.ComboBox();
            this.tendoituong = new System.Windows.Forms.ComboBox();
            this.label32 = new System.Windows.Forms.Label();
            this.icd_vaokhoa = new MaskedTextBox.MaskedTextBox();
            this.lvaokhoa = new System.Windows.Forms.Label();
            this.icd_kkb = new MaskedTextBox.MaskedTextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.icd_noichuyenden = new MaskedTextBox.MaskedTextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.qh_dienthoai = new MaskedTextBox.MaskedTextBox();
            this.qh_diachi = new System.Windows.Forms.TextBox();
            this.qh_hoten = new System.Windows.Forms.TextBox();
            this.quanhe = new System.Windows.Forms.TextBox();
            this.sothe = new MaskedTextBox.MaskedTextBox();
            this.sovaovien = new MaskedTextBox.MaskedTextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.tennhantu = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.nhantu = new System.Windows.Forms.TextBox();
            this.dentu = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.makp = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.khamthai = new System.Windows.Forms.Panel();
            this.para4 = new MaskedTextBox.MaskedTextBox();
            this.para3 = new MaskedTextBox.MaskedTextBox();
            this.para2 = new MaskedTextBox.MaskedTextBox();
            this.para1 = new MaskedTextBox.MaskedTextBox();
            this.label67 = new System.Windows.Forms.Label();
            this.pungbuou_v = new System.Windows.Forms.Panel();
            this.giaidoan_v = new MaskedTextBox.MaskedTextBox();
            this.m_v = new MaskedTextBox.MaskedTextBox();
            this.n_v = new MaskedTextBox.MaskedTextBox();
            this.t_v = new MaskedTextBox.MaskedTextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.pungbuou_r = new System.Windows.Forms.Panel();
            this.giaidoan_r = new MaskedTextBox.MaskedTextBox();
            this.m_r = new MaskedTextBox.MaskedTextBox();
            this.n_r = new MaskedTextBox.MaskedTextBox();
            this.t_r = new MaskedTextBox.MaskedTextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.pkhoaden = new System.Windows.Forms.Panel();
            this.tenkhoaden = new System.Windows.Forms.ComboBox();
            this.khoaden = new System.Windows.Forms.TextBox();
            this.label65 = new System.Windows.Forms.Label();
            this.treeView2 = new System.Windows.Forms.TreeView();
            this.lkhoa = new System.Windows.Forms.Label();
            this.gphaubenh = new System.Windows.Forms.ComboBox();
            this.tainantt = new System.Windows.Forms.CheckBox();
            this.ngaysinh = new MaskedBox.MaskedBox();
            this.ngayrv = new MaskedBox.MaskedBox();
            this.cmbTaibien = new System.Windows.Forms.ComboBox();
            this.listICD = new LibList.List();
            this.cd_kemtheo = new System.Windows.Forms.TextBox();
            this.cd_chinh = new System.Windows.Forms.TextBox();
            this.cd_nguyennhan = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton10 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton8 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton9 = new System.Windows.Forms.ToolStripButton();
            this.chkIn = new System.Windows.Forms.CheckBox();
            this.label68 = new System.Windows.Forms.Label();
            this.kiemsoat = new System.Windows.Forms.CheckBox();
            this.ngayde = new MaskedBox.MaskedBox();
            this.label9 = new System.Windows.Forms.Label();
            this.matb = new System.Windows.Forms.TextBox();
            this.tentb = new System.Windows.Forms.ComboBox();
            this.psankhoa = new System.Windows.Forms.Panel();
            this.giode = new MaskedBox.MaskedBox();
            this.label10 = new System.Windows.Forms.Label();
            this.giorv = new MaskedBox.MaskedBox();
            this.label69 = new System.Windows.Forms.Label();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butVienphi = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.butTiep = new System.Windows.Forms.Button();
            this.tenbs = new System.Windows.Forms.TextBox();
            this.listBS = new LibList.List();
            this.pnhi.SuspendLayout();
            this.phanhchinh.SuspendLayout();
            this.psosinh.SuspendLayout();
            this.ppara.SuspendLayout();
            this.pvaovien.SuspendLayout();
            this.khamthai.SuspendLayout();
            this.pungbuou_v.SuspendLayout();
            this.pungbuou_r.SuspendLayout();
            this.pkhoaden.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.psankhoa.SuspendLayout();
            this.SuspendLayout();
            // 
            // tenba
            // 
            this.tenba.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenba.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tenba.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenba.Location = new System.Drawing.Point(59, 21);
            this.tenba.Name = "tenba";
            this.tenba.Size = new System.Drawing.Size(102, 21);
            this.tenba.TabIndex = 2;
            this.tenba.SelectedIndexChanged += new System.EventHandler(this.tenba_SelectedIndexChanged);
            this.tenba.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(5, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "&Bệnh án :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(160, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 23);
            this.label3.TabIndex = 3;
            this.label3.Text = "&Mã BN :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(271, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 23);
            this.label4.TabIndex = 10;
            this.label4.Text = "Họ và tên :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(451, 21);
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
            this.mabn1.Location = new System.Drawing.Point(160, 0);
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
            this.mabn2.Location = new System.Drawing.Point(208, 21);
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
            this.mabn3.Location = new System.Drawing.Point(232, 21);
            this.mabn3.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.mabn3.MaxLength = 6;
            this.mabn3.Name = "mabn3";
            this.mabn3.Size = new System.Drawing.Size(45, 21);
            this.mabn3.TabIndex = 6;
            this.mabn3.Validated += new System.EventHandler(this.mabn3_Validated);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(573, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 23);
            this.label6.TabIndex = 14;
            this.label6.Text = "Năm sinh :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // namsinh
            // 
            this.namsinh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.namsinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.namsinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namsinh.Location = new System.Drawing.Point(635, 21);
            this.namsinh.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.namsinh.MaxLength = 4;
            this.namsinh.Name = "namsinh";
            this.namsinh.Size = new System.Drawing.Size(34, 21);
            this.namsinh.TabIndex = 9;
            this.namsinh.Validated += new System.EventHandler(this.namsinh_Validated);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(658, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 23);
            this.label7.TabIndex = 16;
            this.label7.Text = "Tuổi :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // loaituoi
            // 
            this.loaituoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.loaituoi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.loaituoi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.loaituoi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loaituoi.Items.AddRange(new object[] {
            "Tuổi",
            "Tháng",
            "Ngày",
            "Giờ"});
            this.loaituoi.Location = new System.Drawing.Point(729, 21);
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
            this.maba.Location = new System.Drawing.Point(128, 0);
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
            this.tuoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tuoi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tuoi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tuoi.Location = new System.Drawing.Point(699, 21);
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
            this.hoten.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.hoten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.hoten.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.hoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoten.Location = new System.Drawing.Point(334, 21);
            this.hoten.Name = "hoten";
            this.hoten.Size = new System.Drawing.Size(120, 21);
            this.hoten.TabIndex = 7;
            this.hoten.Validated += new System.EventHandler(this.hoten_Validated);
            this.hoten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.hoten_KeyDown);
            // 
            // label37
            // 
            this.label37.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label37.Location = new System.Drawing.Point(10, 358);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(104, 23);
            this.label37.TabIndex = 20;
            this.label37.Text = "Ngày giờ &ra khoa :";
            this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // giuong
            // 
            this.giuong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.giuong.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.giuong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.giuong.Location = new System.Drawing.Point(421, 358);
            this.giuong.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.giuong.MaxLength = 10;
            this.giuong.Name = "giuong";
            this.giuong.Size = new System.Drawing.Size(74, 21);
            this.giuong.TabIndex = 23;
            // 
            // label38
            // 
            this.label38.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label38.Location = new System.Drawing.Point(338, 358);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(86, 23);
            this.label38.TabIndex = 90;
            this.label38.Text = "Ph/giường :";
            this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tenketqua
            // 
            this.tenketqua.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenketqua.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tenketqua.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenketqua.Location = new System.Drawing.Point(563, 358);
            this.tenketqua.Name = "tenketqua";
            this.tenketqua.Size = new System.Drawing.Size(93, 21);
            this.tenketqua.TabIndex = 25;
            this.tenketqua.SelectedIndexChanged += new System.EventHandler(this.tenketqua_SelectedIndexChanged);
            this.tenketqua.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenketqua_KeyDown);
            // 
            // ketqua
            // 
            this.ketqua.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ketqua.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ketqua.Location = new System.Drawing.Point(543, 358);
            this.ketqua.Name = "ketqua";
            this.ketqua.Size = new System.Drawing.Size(18, 21);
            this.ketqua.TabIndex = 24;
            this.ketqua.Validated += new System.EventHandler(this.ketqua_Validated);
            this.ketqua.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ketqua_KeyDown);
            // 
            // label39
            // 
            this.label39.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label39.Location = new System.Drawing.Point(489, 358);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(56, 23);
            this.label39.TabIndex = 93;
            this.label39.Text = "Kết quả :";
            this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tenttlucrv
            // 
            this.tenttlucrv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenttlucrv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tenttlucrv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenttlucrv.Location = new System.Drawing.Point(403, 450);
            this.tenttlucrv.Name = "tenttlucrv";
            this.tenttlucrv.Size = new System.Drawing.Size(109, 21);
            this.tenttlucrv.TabIndex = 36;
            this.tenttlucrv.SelectedIndexChanged += new System.EventHandler(this.tenttlucrv_SelectedIndexChanged);
            this.tenttlucrv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenttlucrv_KeyDown);
            // 
            // ttlucrv
            // 
            this.ttlucrv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ttlucrv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ttlucrv.Location = new System.Drawing.Point(383, 450);
            this.ttlucrv.Name = "ttlucrv";
            this.ttlucrv.Size = new System.Drawing.Size(18, 21);
            this.ttlucrv.TabIndex = 35;
            this.ttlucrv.Validated += new System.EventHandler(this.ttlucrv_Validated);
            this.ttlucrv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ttlucrv_KeyDown);
            // 
            // label40
            // 
            this.label40.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label40.Location = new System.Drawing.Point(316, 449);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(70, 23);
            this.label40.TabIndex = 96;
            this.label40.Text = "Tình trạng :";
            this.label40.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label42
            // 
            this.label42.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label42.Location = new System.Drawing.Point(-10, 380);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(120, 23);
            this.label42.TabIndex = 97;
            this.label42.Text = "Bệnh chính :";
            this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // icd_chinh
            // 
            this.icd_chinh.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.icd_chinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.icd_chinh.Location = new System.Drawing.Point(109, 381);
            this.icd_chinh.Masked = MaskedTextBox.MaskedTextBox.Mask.ICD10;
            this.icd_chinh.MaxLength = 9;
            this.icd_chinh.Name = "icd_chinh";
            this.icd_chinh.Size = new System.Drawing.Size(59, 21);
            this.icd_chinh.TabIndex = 26;
            this.icd_chinh.TextChanged += new System.EventHandler(this.icd_noichuyenden_TextChanged);
            this.icd_chinh.Validated += new System.EventHandler(this.icd_chinh_Validated);
            // 
            // icd_nguyennhan
            // 
            this.icd_nguyennhan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.icd_nguyennhan.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.icd_nguyennhan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.icd_nguyennhan.Location = new System.Drawing.Point(109, 404);
            this.icd_nguyennhan.Masked = MaskedTextBox.MaskedTextBox.Mask.ICD10;
            this.icd_nguyennhan.MaxLength = 9;
            this.icd_nguyennhan.Name = "icd_nguyennhan";
            this.icd_nguyennhan.Size = new System.Drawing.Size(59, 21);
            this.icd_nguyennhan.TabIndex = 29;
            this.icd_nguyennhan.TextChanged += new System.EventHandler(this.icd_noichuyenden_TextChanged);
            this.icd_nguyennhan.Validated += new System.EventHandler(this.icd_nguyennhan_Validated);
            // 
            // label44
            // 
            this.label44.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label44.Location = new System.Drawing.Point(-7, 404);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(120, 23);
            this.label44.TabIndex = 101;
            this.label44.Text = "Nguyên nhân :";
            this.label44.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // icd_kemtheo
            // 
            this.icd_kemtheo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.icd_kemtheo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.icd_kemtheo.Location = new System.Drawing.Point(109, 427);
            this.icd_kemtheo.Masked = MaskedTextBox.MaskedTextBox.Mask.ICD10;
            this.icd_kemtheo.MaxLength = 9;
            this.icd_kemtheo.Name = "icd_kemtheo";
            this.icd_kemtheo.Size = new System.Drawing.Size(59, 21);
            this.icd_kemtheo.TabIndex = 31;
            this.icd_kemtheo.TextChanged += new System.EventHandler(this.icd_noichuyenden_TextChanged);
            this.icd_kemtheo.Validated += new System.EventHandler(this.icd_kemtheo_Validated);
            // 
            // label46
            // 
            this.label46.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label46.Location = new System.Drawing.Point(-7, 427);
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
            this.tenloaibv.Location = new System.Drawing.Point(128, 473);
            this.tenloaibv.Name = "tenloaibv";
            this.tenloaibv.Size = new System.Drawing.Size(88, 21);
            this.tenloaibv.TabIndex = 39;
            this.tenloaibv.SelectedIndexChanged += new System.EventHandler(this.tenloaibv_SelectedIndexChanged);
            this.tenloaibv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenloaibv_KeyDown);
            // 
            // loaibv
            // 
            this.loaibv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.loaibv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loaibv.Location = new System.Drawing.Point(109, 473);
            this.loaibv.Name = "loaibv";
            this.loaibv.Size = new System.Drawing.Size(18, 21);
            this.loaibv.TabIndex = 38;
            this.loaibv.Validated += new System.EventHandler(this.loaibv_Validated);
            this.loaibv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.loaibv_KeyDown);
            // 
            // label47
            // 
            this.label47.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label47.Location = new System.Drawing.Point(25, 473);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(88, 23);
            this.label47.TabIndex = 111;
            this.label47.Text = "Chuyển viện :";
            this.label47.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label48
            // 
            this.label48.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label48.Location = new System.Drawing.Point(217, 473);
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
            this.mabv.Location = new System.Drawing.Point(286, 473);
            this.mabv.Masked = MaskedTextBox.MaskedTextBox.Mask.MABV;
            this.mabv.MaxLength = 8;
            this.mabv.Name = "mabv";
            this.mabv.Size = new System.Drawing.Size(55, 21);
            this.mabv.TabIndex = 40;
            this.mabv.Validated += new System.EventHandler(this.mabv_Validated);
            // 
            // tenbv
            // 
            this.tenbv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tenbv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbv.Location = new System.Drawing.Point(343, 473);
            this.tenbv.Name = "tenbv";
            this.tenbv.Size = new System.Drawing.Size(313, 21);
            this.tenbv.TabIndex = 41;
            this.tenbv.SelectedIndexChanged += new System.EventHandler(this.tenbv_SelectedIndexChanged);
            this.tenbv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbv_KeyDown);
            // 
            // mabs
            // 
            this.mabs.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mabs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabs.Location = new System.Drawing.Point(109, 450);
            this.mabs.MaxLength = 4;
            this.mabs.Name = "mabs";
            this.mabs.Size = new System.Drawing.Size(38, 21);
            this.mabs.TabIndex = 33;
            this.mabs.Validated += new System.EventHandler(this.mabs_Validated);
            this.mabs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabs_KeyDown);
            // 
            // label49
            // 
            this.label49.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label49.Location = new System.Drawing.Point(6, 450);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(104, 23);
            this.label49.TabIndex = 117;
            this.label49.Text = "Bác sĩ điều trị :";
            this.label49.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // soluutru
            // 
            this.soluutru.BackColor = System.Drawing.SystemColors.HighlightText;
            this.soluutru.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.soluutru.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.soluutru.Location = new System.Drawing.Point(579, 450);
            this.soluutru.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.soluutru.MaxLength = 10;
            this.soluutru.Name = "soluutru";
            this.soluutru.Size = new System.Drawing.Size(76, 21);
            this.soluutru.TabIndex = 37;
            this.soluutru.Validated += new System.EventHandler(this.soluutru_Validated);
            // 
            // label50
            // 
            this.label50.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label50.Location = new System.Drawing.Point(517, 449);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(64, 23);
            this.label50.TabIndex = 119;
            this.label50.Text = "Số lưu trữ :";
            this.label50.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // songaydt
            // 
            this.songaydt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.songaydt.Enabled = false;
            this.songaydt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.songaydt.Location = new System.Drawing.Point(314, 358);
            this.songaydt.Name = "songaydt";
            this.songaydt.Size = new System.Drawing.Size(39, 21);
            this.songaydt.TabIndex = 22;
            // 
            // label51
            // 
            this.label51.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label51.Location = new System.Drawing.Point(238, 358);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(80, 23);
            this.label51.TabIndex = 121;
            this.label51.Text = "Tổng số ngày :";
            this.label51.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // taibien
            // 
            this.taibien.ForeColor = System.Drawing.SystemColors.ControlText;
            this.taibien.Location = new System.Drawing.Point(658, 384);
            this.taibien.Name = "taibien";
            this.taibien.Size = new System.Drawing.Size(147, 24);
            this.taibien.TabIndex = 126;
            this.taibien.Text = "Tai biến điều trị nội khoa";
            this.taibien.CheckStateChanged += new System.EventHandler(this.taibien_CheckStateChanged);
            // 
            // bienchung
            // 
            this.bienchung.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bienchung.Location = new System.Drawing.Point(658, 472);
            this.bienchung.Name = "bienchung";
            this.bienchung.Size = new System.Drawing.Size(112, 24);
            this.bienchung.TabIndex = 127;
            this.bienchung.Text = "Biến chứng";
            // 
            // label52
            // 
            this.label52.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label52.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label52.Location = new System.Drawing.Point(8, -2);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(112, 23);
            this.label52.TabIndex = 141;
            this.label52.Text = "I. HÀNH CHÍNH :";
            this.label52.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label54
            // 
            this.label54.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label54.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label54.Location = new System.Drawing.Point(8, 342);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(160, 23);
            this.label54.TabIndex = 143;
            this.label54.Text = "III. THÔNG TIN RA KHOA :";
            this.label54.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // giaiphau
            // 
            this.giaiphau.ForeColor = System.Drawing.SystemColors.ControlText;
            this.giaiphau.Location = new System.Drawing.Point(658, 429);
            this.giaiphau.Name = "giaiphau";
            this.giaiphau.Size = new System.Drawing.Size(104, 24);
            this.giaiphau.TabIndex = 128;
            this.giaiphau.Text = "Giải phẫu bệnh";
            this.giaiphau.CheckStateChanged += new System.EventHandler(this.giaiphau_CheckStateChanged);
            // 
            // tdvh
            // 
            this.tdvh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tdvh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tdvh.Location = new System.Drawing.Point(456, 45);
            this.tdvh.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.tdvh.MaxLength = 30;
            this.tdvh.Name = "tdvh";
            this.tdvh.Size = new System.Drawing.Size(88, 21);
            this.tdvh.TabIndex = 11;
            this.toolTip2.SetToolTip(this.tdvh, "Trình độ văn hóa");
            this.tdvh.Visible = false;
            // 
            // lanthu
            // 
            this.lanthu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.lanthu.Enabled = false;
            this.lanthu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lanthu.Location = new System.Drawing.Point(640, 22);
            this.lanthu.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.lanthu.MaxLength = 3;
            this.lanthu.Name = "lanthu";
            this.lanthu.Size = new System.Drawing.Size(24, 21);
            this.lanthu.TabIndex = 6;
            this.toolTip2.SetToolTip(this.lanthu, "Vào viện do bệnh này lần thứ");
            this.lanthu.Validated += new System.EventHandler(this.lanthu_Validated);
            // 
            // ss_para4
            // 
            this.ss_para4.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ss_para4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ss_para4.Location = new System.Drawing.Point(320, 0);
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
            this.ss_para3.Location = new System.Drawing.Point(299, 0);
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
            this.ss_para2.Location = new System.Drawing.Point(278, 0);
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
            this.ss_para1.Location = new System.Drawing.Point(257, 0);
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
            this.pnhi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnhi.Controls.Add(this.nhi_mann_me);
            this.pnhi.Controls.Add(this.nhi_tennn_me);
            this.pnhi.Controls.Add(this.label43);
            this.pnhi.Controls.Add(this.nhi_vanhoa_me);
            this.pnhi.Controls.Add(this.label45);
            this.pnhi.Controls.Add(this.nhi_mann_bo);
            this.pnhi.Controls.Add(this.nhi_tennn_bo);
            this.pnhi.Controls.Add(this.label41);
            this.pnhi.Controls.Add(this.nhi_vanhoa_bo);
            this.pnhi.Controls.Add(this.label35);
            this.pnhi.Controls.Add(this.nhi_hoten_me);
            this.pnhi.Controls.Add(this.label33);
            this.pnhi.Controls.Add(this.nhi_hoten_bo);
            this.pnhi.Controls.Add(this.label14);
            this.pnhi.Location = new System.Drawing.Point(0, 525);
            this.pnhi.Name = "pnhi";
            this.pnhi.Size = new System.Drawing.Size(792, 48);
            this.pnhi.TabIndex = 15;
            this.pnhi.Visible = false;
            // 
            // nhi_mann_me
            // 
            this.nhi_mann_me.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nhi_mann_me.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhi_mann_me.Location = new System.Drawing.Point(562, 23);
            this.nhi_mann_me.MaxLength = 2;
            this.nhi_mann_me.Name = "nhi_mann_me";
            this.nhi_mann_me.Size = new System.Drawing.Size(24, 21);
            this.nhi_mann_me.TabIndex = 6;
            this.nhi_mann_me.Validated += new System.EventHandler(this.nhi_mann_me_Validated);
            this.nhi_mann_me.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nhi_mann_me_KeyDown);
            // 
            // nhi_tennn_me
            // 
            this.nhi_tennn_me.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.nhi_tennn_me.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nhi_tennn_me.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nhi_tennn_me.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhi_tennn_me.Location = new System.Drawing.Point(588, 23);
            this.nhi_tennn_me.Name = "nhi_tennn_me";
            this.nhi_tennn_me.Size = new System.Drawing.Size(200, 21);
            this.nhi_tennn_me.TabIndex = 7;
            this.nhi_tennn_me.SelectedIndexChanged += new System.EventHandler(this.nhi_tennn_me_SelectedIndexChanged);
            this.nhi_tennn_me.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nhi_tennn_me_KeyDown);
            // 
            // label43
            // 
            this.label43.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label43.Location = new System.Drawing.Point(445, 21);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(120, 23);
            this.label43.TabIndex = 29;
            this.label43.Text = "Nghề nghiệp của mẹ :";
            this.label43.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nhi_vanhoa_me
            // 
            this.nhi_vanhoa_me.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nhi_vanhoa_me.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhi_vanhoa_me.Location = new System.Drawing.Point(310, 23);
            this.nhi_vanhoa_me.Name = "nhi_vanhoa_me";
            this.nhi_vanhoa_me.Size = new System.Drawing.Size(120, 21);
            this.nhi_vanhoa_me.TabIndex = 5;
            this.nhi_vanhoa_me.Validated += new System.EventHandler(this.nhi_vanhoa_me_Validated);
            this.nhi_vanhoa_me.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nhi_vanhoa_me_KeyDown);
            // 
            // label45
            // 
            this.label45.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label45.Location = new System.Drawing.Point(200, 21);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(112, 23);
            this.label45.TabIndex = 25;
            this.label45.Text = "Trình độ VH của mẹ :";
            this.label45.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nhi_mann_bo
            // 
            this.nhi_mann_bo.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nhi_mann_bo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhi_mann_bo.Location = new System.Drawing.Point(562, 0);
            this.nhi_mann_bo.MaxLength = 2;
            this.nhi_mann_bo.Name = "nhi_mann_bo";
            this.nhi_mann_bo.Size = new System.Drawing.Size(24, 21);
            this.nhi_mann_bo.TabIndex = 2;
            this.nhi_mann_bo.Validated += new System.EventHandler(this.nhi_mann_bo_Validated);
            this.nhi_mann_bo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nhi_mann_bo_KeyDown);
            // 
            // nhi_tennn_bo
            // 
            this.nhi_tennn_bo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.nhi_tennn_bo.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nhi_tennn_bo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nhi_tennn_bo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhi_tennn_bo.Location = new System.Drawing.Point(588, 0);
            this.nhi_tennn_bo.Name = "nhi_tennn_bo";
            this.nhi_tennn_bo.Size = new System.Drawing.Size(200, 21);
            this.nhi_tennn_bo.TabIndex = 3;
            this.nhi_tennn_bo.SelectedIndexChanged += new System.EventHandler(this.nhi_tennn_bo_SelectedIndexChanged);
            this.nhi_tennn_bo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nhi_tennn_bo_KeyDown);
            // 
            // label41
            // 
            this.label41.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label41.Location = new System.Drawing.Point(453, 0);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(112, 23);
            this.label41.TabIndex = 24;
            this.label41.Text = "Nghề nghiệp của bố :";
            this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nhi_vanhoa_bo
            // 
            this.nhi_vanhoa_bo.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nhi_vanhoa_bo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhi_vanhoa_bo.Location = new System.Drawing.Point(310, 0);
            this.nhi_vanhoa_bo.Name = "nhi_vanhoa_bo";
            this.nhi_vanhoa_bo.Size = new System.Drawing.Size(120, 21);
            this.nhi_vanhoa_bo.TabIndex = 1;
            this.nhi_vanhoa_bo.Validated += new System.EventHandler(this.nhi_vanhoa_bo_Validated);
            this.nhi_vanhoa_bo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nhi_vanhoa_bo_KeyDown);
            // 
            // label35
            // 
            this.label35.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label35.Location = new System.Drawing.Point(200, 0);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(112, 23);
            this.label35.TabIndex = 15;
            this.label35.Text = "Trình độ VH của bố :";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nhi_hoten_me
            // 
            this.nhi_hoten_me.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nhi_hoten_me.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhi_hoten_me.Location = new System.Drawing.Point(59, 23);
            this.nhi_hoten_me.Name = "nhi_hoten_me";
            this.nhi_hoten_me.Size = new System.Drawing.Size(120, 21);
            this.nhi_hoten_me.TabIndex = 4;
            this.nhi_hoten_me.Validated += new System.EventHandler(this.nhi_hoten_me_Validated);
            this.nhi_hoten_me.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nhi_hoten_me_KeyDown);
            // 
            // label33
            // 
            this.label33.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label33.Location = new System.Drawing.Point(-2, 21);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(64, 23);
            this.label33.TabIndex = 13;
            this.label33.Text = "Họ tên mẹ :";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nhi_hoten_bo
            // 
            this.nhi_hoten_bo.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nhi_hoten_bo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhi_hoten_bo.Location = new System.Drawing.Point(59, 0);
            this.nhi_hoten_bo.Name = "nhi_hoten_bo";
            this.nhi_hoten_bo.Size = new System.Drawing.Size(120, 21);
            this.nhi_hoten_bo.TabIndex = 0;
            this.nhi_hoten_bo.Validated += new System.EventHandler(this.nhi_hoten_bo_Validated);
            this.nhi_hoten_bo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nhi_hoten_bo_KeyDown);
            // 
            // label14
            // 
            this.label14.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label14.Location = new System.Drawing.Point(-3, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(64, 23);
            this.label14.TabIndex = 11;
            this.label14.Text = "Họ tên bố :";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // phanhchinh
            // 
            this.phanhchinh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
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
            this.phanhchinh.Location = new System.Drawing.Point(-13, 86);
            this.phanhchinh.Name = "phanhchinh";
            this.phanhchinh.Size = new System.Drawing.Size(805, 68);
            this.phanhchinh.TabIndex = 14;
            // 
            // tennuoc
            // 
            this.tennuoc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tennuoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tennuoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tennuoc.Location = new System.Drawing.Point(600, 0);
            this.tennuoc.Name = "tennuoc";
            this.tennuoc.Size = new System.Drawing.Size(82, 21);
            this.tennuoc.TabIndex = 5;
            this.tennuoc.SelectedIndexChanged += new System.EventHandler(this.tennuoc_SelectedIndexChanged);
            this.tennuoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tennuoc_KeyDown);
            // 
            // manuoc
            // 
            this.manuoc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.manuoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.manuoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manuoc.Location = new System.Drawing.Point(575, 0);
            this.manuoc.MaxLength = 2;
            this.manuoc.Name = "manuoc";
            this.manuoc.Size = new System.Drawing.Size(24, 21);
            this.manuoc.TabIndex = 4;
            this.manuoc.Validated += new System.EventHandler(this.manuoc_Validated);
            this.manuoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.manuoc_KeyDown);
            // 
            // lmanuoc
            // 
            this.lmanuoc.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lmanuoc.Location = new System.Drawing.Point(512, 0);
            this.lmanuoc.Name = "lmanuoc";
            this.lmanuoc.Size = new System.Drawing.Size(64, 23);
            this.lmanuoc.TabIndex = 65;
            this.lmanuoc.Text = "Quốc tịch :";
            this.lmanuoc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sonha
            // 
            this.sonha.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sonha.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sonha.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sonha.Location = new System.Drawing.Point(728, 0);
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
            this.tendantoc.Location = new System.Drawing.Point(440, 0);
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
            this.tentqx.Location = new System.Drawing.Point(384, 23);
            this.tentqx.Name = "tentqx";
            this.tentqx.Size = new System.Drawing.Size(227, 21);
            this.tentqx.TabIndex = 9;
            this.tentqx.SelectedIndexChanged += new System.EventHandler(this.tentqx_SelectedIndexChanged);
            this.tentqx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tentqx_KeyDown);
            // 
            // cholam
            // 
            this.cholam.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cholam.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cholam.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cholam.Location = new System.Drawing.Point(659, 46);
            this.cholam.Name = "cholam";
            this.cholam.Size = new System.Drawing.Size(141, 21);
            this.cholam.TabIndex = 18;
            this.cholam.Validated += new System.EventHandler(this.cholam_Validated);
            this.cholam.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cholam_KeyDown);
            // 
            // thon
            // 
            this.thon.BackColor = System.Drawing.SystemColors.HighlightText;
            this.thon.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thon.Location = new System.Drawing.Point(72, 24);
            this.thon.Name = "thon";
            this.thon.Size = new System.Drawing.Size(212, 21);
            this.thon.TabIndex = 7;
            this.thon.Validated += new System.EventHandler(this.thon_Validated);
            this.thon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.thon_KeyDown);
            // 
            // mapxa2
            // 
            this.mapxa2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mapxa2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mapxa2.Location = new System.Drawing.Point(368, 46);
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
            this.maqu2.Location = new System.Drawing.Point(80, 46);
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
            this.matt.Location = new System.Drawing.Point(659, 23);
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
            this.tqx.Location = new System.Drawing.Point(336, 23);
            this.tqx.Name = "tqx";
            this.tqx.Size = new System.Drawing.Size(48, 21);
            this.tqx.TabIndex = 8;
            this.tqx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tqx_KeyDown);
            // 
            // madantoc
            // 
            this.madantoc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.madantoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madantoc.Location = new System.Drawing.Point(416, 0);
            this.madantoc.MaxLength = 2;
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
            this.mann.Location = new System.Drawing.Point(185, 0);
            this.mann.MaxLength = 2;
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
            this.tennn.Location = new System.Drawing.Point(209, 0);
            this.tennn.Name = "tennn";
            this.tennn.Size = new System.Drawing.Size(159, 21);
            this.tennn.TabIndex = 1;
            this.tennn.SelectedIndexChanged += new System.EventHandler(this.tennn_SelectedIndexChanged);
            this.tennn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tennn_KeyDown);
            // 
            // tenquan
            // 
            this.tenquan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenquan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tenquan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenquan.Location = new System.Drawing.Point(104, 46);
            this.tenquan.Name = "tenquan";
            this.tenquan.Size = new System.Drawing.Size(158, 21);
            this.tenquan.TabIndex = 14;
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
            this.tentinh.Location = new System.Drawing.Point(688, 23);
            this.tentinh.Name = "tentinh";
            this.tentinh.Size = new System.Drawing.Size(112, 21);
            this.tentinh.TabIndex = 11;
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
            this.tenpxa.Location = new System.Drawing.Point(392, 46);
            this.tenpxa.Name = "tenpxa";
            this.tenpxa.Size = new System.Drawing.Size(194, 21);
            this.tenpxa.TabIndex = 17;
            this.tenpxa.SelectedIndexChanged += new System.EventHandler(this.tenpxa_SelectedIndexChanged);
            this.tenpxa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenpxa_KeyDown);
            // 
            // mapxa1
            // 
            this.mapxa1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mapxa1.Enabled = false;
            this.mapxa1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mapxa1.Location = new System.Drawing.Point(327, 46);
            this.mapxa1.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.mapxa1.MaxLength = 5;
            this.mapxa1.Name = "mapxa1";
            this.mapxa1.Size = new System.Drawing.Size(40, 21);
            this.mapxa1.TabIndex = 15;
            // 
            // lmaphuongxa
            // 
            this.lmaphuongxa.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lmaphuongxa.Location = new System.Drawing.Point(256, 46);
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
            this.maqu1.Location = new System.Drawing.Point(53, 46);
            this.maqu1.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.maqu1.MaxLength = 3;
            this.maqu1.Name = "maqu1";
            this.maqu1.Size = new System.Drawing.Size(27, 21);
            this.maqu1.TabIndex = 12;
            // 
            // lmaqu
            // 
            this.lmaqu.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lmaqu.Location = new System.Drawing.Point(-24, 48);
            this.lmaqu.Name = "lmaqu";
            this.lmaqu.Size = new System.Drawing.Size(80, 23);
            this.lmaqu.TabIndex = 76;
            this.lmaqu.Text = "Quận/H :";
            this.lmaqu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lmatt
            // 
            this.lmatt.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lmatt.Location = new System.Drawing.Point(606, 24);
            this.lmatt.Name = "lmatt";
            this.lmatt.Size = new System.Drawing.Size(56, 23);
            this.lmatt.TabIndex = 75;
            this.lmatt.Text = "Tỉnh/TP :";
            this.lmatt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ltqx
            // 
            this.ltqx.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ltqx.Location = new System.Drawing.Point(264, 24);
            this.ltqx.Name = "ltqx";
            this.ltqx.Size = new System.Drawing.Size(72, 23);
            this.ltqx.TabIndex = 74;
            this.ltqx.Text = "T/Q/PXã :";
            this.ltqx.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lcholam
            // 
            this.lcholam.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lcholam.Location = new System.Drawing.Point(591, 47);
            this.lcholam.Name = "lcholam";
            this.lcholam.Size = new System.Drawing.Size(72, 23);
            this.lcholam.TabIndex = 73;
            this.lcholam.Text = "Nơi làm việc :";
            this.lcholam.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lthon
            // 
            this.lthon.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lthon.Location = new System.Drawing.Point(0, 24);
            this.lthon.Name = "lthon";
            this.lthon.Size = new System.Drawing.Size(72, 23);
            this.lthon.TabIndex = 72;
            this.lthon.Text = "Thôn, phố :";
            this.lthon.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lsonha
            // 
            this.lsonha.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lsonha.Location = new System.Drawing.Point(680, 0);
            this.lsonha.Name = "lsonha";
            this.lsonha.Size = new System.Drawing.Size(48, 23);
            this.lsonha.TabIndex = 70;
            this.lsonha.Text = "Số nhà :";
            this.lsonha.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lmadantoc
            // 
            this.lmadantoc.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lmadantoc.Location = new System.Drawing.Point(360, 0);
            this.lmadantoc.Name = "lmadantoc";
            this.lmadantoc.Size = new System.Drawing.Size(56, 23);
            this.lmadantoc.TabIndex = 61;
            this.lmadantoc.Text = "Dân tộc :";
            this.lmadantoc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lmann
            // 
            this.lmann.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lmann.Location = new System.Drawing.Point(108, 0);
            this.lmann.Name = "lmann";
            this.lmann.Size = new System.Drawing.Size(80, 23);
            this.lmann.TabIndex = 58;
            this.lmann.Text = "Nghề nghiệp :";
            this.lmann.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // psosinh
            // 
            this.psosinh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.psosinh.Controls.Add(this.ss_ns_me);
            this.psosinh.Controls.Add(this.mame);
            this.psosinh.Controls.Add(this.label66);
            this.psosinh.Controls.Add(this.ss_hoten_me);
            this.psosinh.Controls.Add(this.ss_ns_bo);
            this.psosinh.Controls.Add(this.label60);
            this.psosinh.Controls.Add(this.ss_mann_bo);
            this.psosinh.Controls.Add(this.ss_tennn_bo);
            this.psosinh.Controls.Add(this.label61);
            this.psosinh.Controls.Add(this.ss_hoten_bo);
            this.psosinh.Controls.Add(this.label62);
            this.psosinh.Controls.Add(this.ss_delan);
            this.psosinh.Controls.Add(this.label59);
            this.psosinh.Controls.Add(this.label58);
            this.psosinh.Controls.Add(this.ss_mann_me);
            this.psosinh.Controls.Add(this.ss_tennn_me);
            this.psosinh.Controls.Add(this.label56);
            this.psosinh.Controls.Add(this.label57);
            this.psosinh.Location = new System.Drawing.Point(0, 42);
            this.psosinh.Name = "psosinh";
            this.psosinh.Size = new System.Drawing.Size(789, 44);
            this.psosinh.TabIndex = 13;
            // 
            // mame
            // 
            this.mame.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mame.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mame.Location = new System.Drawing.Point(144, 1);
            this.mame.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.mame.MaxLength = 8;
            this.mame.Name = "mame";
            this.mame.Size = new System.Drawing.Size(64, 21);
            this.mame.TabIndex = 0;
            this.mame.Validated += new System.EventHandler(this.mame_Validated);
            // 
            // label66
            // 
            this.label66.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label66.Location = new System.Drawing.Point(96, -1);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(48, 23);
            this.label66.TabIndex = 71;
            this.label66.Text = "Mã mẹ :";
            this.label66.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ss_hoten_me
            // 
            this.ss_hoten_me.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ss_hoten_me.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ss_hoten_me.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ss_hoten_me.Location = new System.Drawing.Point(256, 1);
            this.ss_hoten_me.Name = "ss_hoten_me";
            this.ss_hoten_me.Size = new System.Drawing.Size(152, 21);
            this.ss_hoten_me.TabIndex = 1;
            this.ss_hoten_me.Validated += new System.EventHandler(this.ss_hoten_me_Validated);
            this.ss_hoten_me.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ss_hoten_me_KeyDown);
            // 
            // ss_ns_bo
            // 
            this.ss_ns_bo.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ss_ns_bo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ss_ns_bo.Location = new System.Drawing.Point(414, 22);
            this.ss_ns_bo.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.ss_ns_bo.MaxLength = 4;
            this.ss_ns_bo.Name = "ss_ns_bo";
            this.ss_ns_bo.Size = new System.Drawing.Size(40, 21);
            this.ss_ns_bo.TabIndex = 7;
            this.ss_ns_bo.Validated += new System.EventHandler(this.ss_ns_bo_Validated);
            // 
            // label60
            // 
            this.label60.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label60.Location = new System.Drawing.Point(328, 21);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(88, 23);
            this.label60.TabIndex = 66;
            this.label60.Text = "Năm sinh/Tuổi :";
            this.label60.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ss_mann_bo
            // 
            this.ss_mann_bo.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ss_mann_bo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ss_mann_bo.Location = new System.Drawing.Point(575, 22);
            this.ss_mann_bo.MaxLength = 2;
            this.ss_mann_bo.Name = "ss_mann_bo";
            this.ss_mann_bo.Size = new System.Drawing.Size(24, 21);
            this.ss_mann_bo.TabIndex = 8;
            this.ss_mann_bo.Validated += new System.EventHandler(this.ss_mann_bo_Validated);
            this.ss_mann_bo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ss_mann_bo_KeyDown);
            // 
            // ss_tennn_bo
            // 
            this.ss_tennn_bo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ss_tennn_bo.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ss_tennn_bo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ss_tennn_bo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ss_tennn_bo.Location = new System.Drawing.Point(600, 22);
            this.ss_tennn_bo.Name = "ss_tennn_bo";
            this.ss_tennn_bo.Size = new System.Drawing.Size(188, 21);
            this.ss_tennn_bo.TabIndex = 9;
            this.ss_tennn_bo.SelectedIndexChanged += new System.EventHandler(this.ss_tennn_bo_SelectedIndexChanged);
            this.ss_tennn_bo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ss_tennn_bo_KeyDown);
            // 
            // label61
            // 
            this.label61.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label61.Location = new System.Drawing.Point(458, 21);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(120, 23);
            this.label61.TabIndex = 64;
            this.label61.Text = "Nghề nghiệp của bố :";
            this.label61.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ss_hoten_bo
            // 
            this.ss_hoten_bo.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ss_hoten_bo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ss_hoten_bo.Location = new System.Drawing.Point(208, 23);
            this.ss_hoten_bo.Name = "ss_hoten_bo";
            this.ss_hoten_bo.Size = new System.Drawing.Size(120, 21);
            this.ss_hoten_bo.TabIndex = 6;
            this.ss_hoten_bo.Validated += new System.EventHandler(this.ss_hoten_bo_Validated);
            this.ss_hoten_bo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ss_hoten_bo_KeyDown);
            // 
            // label62
            // 
            this.label62.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label62.Location = new System.Drawing.Point(144, 21);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(64, 23);
            this.label62.TabIndex = 60;
            this.label62.Text = "Họ tên bố :";
            this.label62.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ss_delan
            // 
            this.ss_delan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ss_delan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ss_delan.Location = new System.Drawing.Point(59, 23);
            this.ss_delan.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.ss_delan.MaxLength = 6;
            this.ss_delan.Name = "ss_delan";
            this.ss_delan.Size = new System.Drawing.Size(45, 21);
            this.ss_delan.TabIndex = 5;
            this.ss_delan.Validated += new System.EventHandler(this.ss_delan_Validated);
            // 
            // label59
            // 
            this.label59.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label59.Location = new System.Drawing.Point(-3, 21);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(67, 23);
            this.label59.TabIndex = 58;
            this.label59.Text = "Đẻ lần mấy :";
            this.label59.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ss_ns_me
            // 
            this.ss_ns_me.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ss_ns_me.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ss_ns_me.Location = new System.Drawing.Point(464, 1);
            this.ss_ns_me.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.ss_ns_me.MaxLength = 4;
            this.ss_ns_me.Name = "ss_ns_me";
            this.ss_ns_me.Size = new System.Drawing.Size(40, 21);
            this.ss_ns_me.TabIndex = 2;
            this.ss_ns_me.Validated += new System.EventHandler(this.ss_ns_me_Validated);
            // 
            // label58
            // 
            this.label58.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label58.Location = new System.Drawing.Point(376, -1);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(88, 23);
            this.label58.TabIndex = 36;
            this.label58.Text = "Năm sinh :";
            this.label58.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ss_mann_me
            // 
            this.ss_mann_me.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ss_mann_me.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ss_mann_me.Location = new System.Drawing.Point(575, 1);
            this.ss_mann_me.MaxLength = 2;
            this.ss_mann_me.Name = "ss_mann_me";
            this.ss_mann_me.Size = new System.Drawing.Size(24, 21);
            this.ss_mann_me.TabIndex = 3;
            this.ss_mann_me.Validated += new System.EventHandler(this.ss_mann_me_Validated);
            this.ss_mann_me.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ss_mann_me_KeyDown);
            // 
            // ss_tennn_me
            // 
            this.ss_tennn_me.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ss_tennn_me.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ss_tennn_me.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ss_tennn_me.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ss_tennn_me.Location = new System.Drawing.Point(600, 1);
            this.ss_tennn_me.Name = "ss_tennn_me";
            this.ss_tennn_me.Size = new System.Drawing.Size(188, 21);
            this.ss_tennn_me.TabIndex = 4;
            this.ss_tennn_me.SelectedIndexChanged += new System.EventHandler(this.ss_tennn_me_SelectedIndexChanged);
            this.ss_tennn_me.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ss_tennn_me_KeyDown);
            // 
            // label56
            // 
            this.label56.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label56.Location = new System.Drawing.Point(496, -1);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(80, 23);
            this.label56.TabIndex = 34;
            this.label56.Text = "Nghề nghiệp :";
            this.label56.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label57
            // 
            this.label57.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label57.Location = new System.Drawing.Point(192, -1);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(64, 23);
            this.label57.TabIndex = 30;
            this.label57.Text = "Họ tên :";
            this.label57.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // phai
            // 
            this.phai.BackColor = System.Drawing.SystemColors.HighlightText;
            this.phai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.phai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phai.Items.AddRange(new object[] {
            "Nam",
            "Nữ"});
            this.phai.Location = new System.Drawing.Point(59, 43);
            this.phai.Name = "phai";
            this.phai.Size = new System.Drawing.Size(43, 21);
            this.phai.TabIndex = 12;
            this.phai.SelectedIndexChanged += new System.EventHandler(this.phai_SelectedIndexChanged);
            this.phai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.phai_KeyDown);
            // 
            // lphai
            // 
            this.lphai.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lphai.Location = new System.Drawing.Point(5, 42);
            this.lphai.Name = "lphai";
            this.lphai.Size = new System.Drawing.Size(56, 23);
            this.lphai.TabIndex = 161;
            this.lphai.Text = "Giới tính :";
            this.lphai.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ppara
            // 
            this.ppara.Controls.Add(this.label64);
            this.ppara.Controls.Add(this.ss_nhommau);
            this.ppara.Controls.Add(this.ss_para4);
            this.ppara.Controls.Add(this.ss_para3);
            this.ppara.Controls.Add(this.ss_para2);
            this.ppara.Controls.Add(this.ss_para1);
            this.ppara.Controls.Add(this.label63);
            this.ppara.Controls.Add(this.label8);
            this.ppara.Location = new System.Drawing.Point(318, -8);
            this.ppara.Name = "ppara";
            this.ppara.Size = new System.Drawing.Size(466, 21);
            this.ppara.TabIndex = 16;
            this.ppara.Visible = false;
            // 
            // label64
            // 
            this.label64.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label64.Location = new System.Drawing.Point(344, 0);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(120, 23);
            this.label64.TabIndex = 79;
            this.label64.Text = "(Sinh,Sớm,Sẩy,Sống)";
            this.label64.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ss_nhommau
            // 
            this.ss_nhommau.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ss_nhommau.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ss_nhommau.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ss_nhommau.Location = new System.Drawing.Point(72, 0);
            this.ss_nhommau.Name = "ss_nhommau";
            this.ss_nhommau.Size = new System.Drawing.Size(96, 21);
            this.ss_nhommau.TabIndex = 0;
            this.ss_nhommau.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ss_nhommau_KeyDown);
            // 
            // label63
            // 
            this.label63.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label63.Location = new System.Drawing.Point(176, 0);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(88, 23);
            this.label63.TabIndex = 78;
            this.label63.Text = "Tiền thai (Para) :";
            this.label63.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label8.Location = new System.Drawing.Point(-15, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 23);
            this.label8.TabIndex = 76;
            this.label8.Text = "Nhóm máu mẹ :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pvaovien
            // 
            this.pvaovien.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pvaovien.Controls.Add(this.ngayvv);
            this.pvaovien.Controls.Add(this.giovv);
            this.pvaovien.Controls.Add(this.label75);
            this.pvaovien.Controls.Add(this.ngayvk);
            this.pvaovien.Controls.Add(this.giovk);
            this.pvaovien.Controls.Add(this.label76);
            this.pvaovien.Controls.Add(this.cd_vaokhoa);
            this.pvaovien.Controls.Add(this.cd_noichuyenden);
            this.pvaovien.Controls.Add(this.cd_kkb);
            this.pvaovien.Controls.Add(this.tdvh);
            this.pvaovien.Controls.Add(this.ngaybong);
            this.pvaovien.Controls.Add(this.denngay);
            this.pvaovien.Controls.Add(this.tenkp);
            this.pvaovien.Controls.Add(this.lbong);
            this.pvaovien.Controls.Add(this.ltdvh);
            this.pvaovien.Controls.Add(this.label55);
            this.pvaovien.Controls.Add(this.madoituong);
            this.pvaovien.Controls.Add(this.tendentu);
            this.pvaovien.Controls.Add(this.tendoituong);
            this.pvaovien.Controls.Add(this.label32);
            this.pvaovien.Controls.Add(this.icd_vaokhoa);
            this.pvaovien.Controls.Add(this.lvaokhoa);
            this.pvaovien.Controls.Add(this.icd_kkb);
            this.pvaovien.Controls.Add(this.label34);
            this.pvaovien.Controls.Add(this.icd_noichuyenden);
            this.pvaovien.Controls.Add(this.label31);
            this.pvaovien.Controls.Add(this.qh_dienthoai);
            this.pvaovien.Controls.Add(this.qh_diachi);
            this.pvaovien.Controls.Add(this.qh_hoten);
            this.pvaovien.Controls.Add(this.quanhe);
            this.pvaovien.Controls.Add(this.lanthu);
            this.pvaovien.Controls.Add(this.sothe);
            this.pvaovien.Controls.Add(this.sovaovien);
            this.pvaovien.Controls.Add(this.label30);
            this.pvaovien.Controls.Add(this.label29);
            this.pvaovien.Controls.Add(this.label28);
            this.pvaovien.Controls.Add(this.label27);
            this.pvaovien.Controls.Add(this.label26);
            this.pvaovien.Controls.Add(this.label25);
            this.pvaovien.Controls.Add(this.label24);
            this.pvaovien.Controls.Add(this.label23);
            this.pvaovien.Controls.Add(this.tennhantu);
            this.pvaovien.Controls.Add(this.label22);
            this.pvaovien.Controls.Add(this.nhantu);
            this.pvaovien.Controls.Add(this.dentu);
            this.pvaovien.Controls.Add(this.label21);
            this.pvaovien.Controls.Add(this.label20);
            this.pvaovien.Controls.Add(this.label19);
            this.pvaovien.Controls.Add(this.makp);
            this.pvaovien.Controls.Add(this.label1);
            this.pvaovien.Controls.Add(this.label53);
            this.pvaovien.Controls.Add(this.khamthai);
            this.pvaovien.Location = new System.Drawing.Point(-8, 158);
            this.pvaovien.Name = "pvaovien";
            this.pvaovien.Size = new System.Drawing.Size(667, 181);
            this.pvaovien.TabIndex = 17;
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
            // label75
            // 
            this.label75.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label75.Location = new System.Drawing.Point(182, 20);
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(32, 23);
            this.label75.TabIndex = 263;
            this.label75.Text = "giờ :";
            this.label75.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ngayvk
            // 
            this.ngayvk.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngayvk.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngayvk.Location = new System.Drawing.Point(117, 45);
            this.ngayvk.Mask = "##/##/####";
            this.ngayvk.Name = "ngayvk";
            this.ngayvk.Size = new System.Drawing.Size(70, 21);
            this.ngayvk.TabIndex = 7;
            this.ngayvk.Text = "  /  /    ";
            this.ngayvk.Validated += new System.EventHandler(this.ngayvk_Validated);
            // 
            // giovk
            // 
            this.giovk.BackColor = System.Drawing.SystemColors.HighlightText;
            this.giovk.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.giovk.Location = new System.Drawing.Point(211, 45);
            this.giovk.Mask = "##:##";
            this.giovk.Name = "giovk";
            this.giovk.Size = new System.Drawing.Size(36, 21);
            this.giovk.TabIndex = 8;
            this.giovk.Text = "  :  ";
            this.giovk.Validated += new System.EventHandler(this.giovk_Validated);
            // 
            // label76
            // 
            this.label76.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label76.Location = new System.Drawing.Point(181, 43);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(32, 23);
            this.label76.TabIndex = 261;
            this.label76.Text = "giờ :";
            this.label76.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cd_vaokhoa
            // 
            this.cd_vaokhoa.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cd_vaokhoa.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cd_vaokhoa.Location = new System.Drawing.Point(177, 159);
            this.cd_vaokhoa.Name = "cd_vaokhoa";
            this.cd_vaokhoa.Size = new System.Drawing.Size(486, 21);
            this.cd_vaokhoa.TabIndex = 27;
            this.cd_vaokhoa.TextChanged += new System.EventHandler(this.cd_vaokhoa_TextChanged);
            this.cd_vaokhoa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cd_kkb_KeyDown);
            // 
            // cd_noichuyenden
            // 
            this.cd_noichuyenden.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cd_noichuyenden.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cd_noichuyenden.Location = new System.Drawing.Point(177, 113);
            this.cd_noichuyenden.Name = "cd_noichuyenden";
            this.cd_noichuyenden.Size = new System.Drawing.Size(486, 21);
            this.cd_noichuyenden.TabIndex = 23;
            this.cd_noichuyenden.TextChanged += new System.EventHandler(this.cd_noichuyenden_TextChanged);
            this.cd_noichuyenden.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cd_kkb_KeyDown);
            // 
            // cd_kkb
            // 
            this.cd_kkb.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cd_kkb.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cd_kkb.Location = new System.Drawing.Point(177, 136);
            this.cd_kkb.Name = "cd_kkb";
            this.cd_kkb.Size = new System.Drawing.Size(486, 21);
            this.cd_kkb.TabIndex = 25;
            this.cd_kkb.TextChanged += new System.EventHandler(this.cd_kkb_TextChanged);
            this.cd_kkb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cd_kkb_KeyDown);
            // 
            // ngaybong
            // 
            this.ngaybong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngaybong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngaybong.Location = new System.Drawing.Point(456, 45);
            this.ngaybong.Mask = "##/##/#### ##:##";
            this.ngaybong.Name = "ngaybong";
            this.ngaybong.Size = new System.Drawing.Size(94, 21);
            this.ngaybong.TabIndex = 11;
            this.ngaybong.Text = "  /  /       :  ";
            this.ngaybong.Validated += new System.EventHandler(this.ngaybong_Validated);
            // 
            // denngay
            // 
            this.denngay.BackColor = System.Drawing.SystemColors.HighlightText;
            this.denngay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.denngay.Location = new System.Drawing.Point(464, 68);
            this.denngay.Mask = "##/##/####";
            this.denngay.Name = "denngay";
            this.denngay.Size = new System.Drawing.Size(64, 21);
            this.denngay.TabIndex = 16;
            this.denngay.Text = "  /  /    ";
            this.denngay.Validated += new System.EventHandler(this.denngay_Validated);
            // 
            // tenkp
            // 
            this.tenkp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenkp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tenkp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenkp.Location = new System.Drawing.Point(328, 45);
            this.tenkp.Name = "tenkp";
            this.tenkp.Size = new System.Drawing.Size(85, 21);
            this.tenkp.TabIndex = 10;
            this.tenkp.SelectedIndexChanged += new System.EventHandler(this.tenkp_SelectedIndexChanged);
            this.tenkp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenkp_KeyDown);
            // 
            // lbong
            // 
            this.lbong.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbong.Location = new System.Drawing.Point(392, 44);
            this.lbong.Name = "lbong";
            this.lbong.Size = new System.Drawing.Size(72, 23);
            this.lbong.TabIndex = 212;
            this.lbong.Text = "TG bỏng :";
            this.lbong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbong.Visible = false;
            // 
            // ltdvh
            // 
            this.ltdvh.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.ltdvh.Location = new System.Drawing.Point(408, 45);
            this.ltdvh.Name = "ltdvh";
            this.ltdvh.Size = new System.Drawing.Size(48, 23);
            this.ltdvh.TabIndex = 209;
            this.ltdvh.Text = "TĐVH :";
            this.ltdvh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ltdvh.Visible = false;
            // 
            // label55
            // 
            this.label55.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label55.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label55.Location = new System.Drawing.Point(672, 4);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(128, 23);
            this.label55.TabIndex = 207;
            this.label55.Text = "CÁC LẦN VÀO VIỆN :";
            this.label55.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // madoituong
            // 
            this.madoituong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.madoituong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madoituong.Location = new System.Drawing.Point(117, 68);
            this.madoituong.Name = "madoituong";
            this.madoituong.Size = new System.Drawing.Size(18, 21);
            this.madoituong.TabIndex = 13;
            this.madoituong.Validated += new System.EventHandler(this.madoituong_Validated);
            this.madoituong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.madoituong_KeyDown);
            // 
            // tendentu
            // 
            this.tendentu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tendentu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tendentu.Enabled = false;
            this.tendentu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tendentu.Location = new System.Drawing.Point(507, 22);
            this.tendentu.Name = "tendentu";
            this.tendentu.Size = new System.Drawing.Size(87, 21);
            this.tendentu.TabIndex = 5;
            this.tendentu.SelectedIndexChanged += new System.EventHandler(this.tendentu_SelectedIndexChanged);
            this.tendentu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tendentu_KeyDown);
            // 
            // tendoituong
            // 
            this.tendoituong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tendoituong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tendoituong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tendoituong.Location = new System.Drawing.Point(136, 68);
            this.tendoituong.Name = "tendoituong";
            this.tendoituong.Size = new System.Drawing.Size(120, 21);
            this.tendoituong.TabIndex = 14;
            this.tendoituong.SelectedIndexChanged += new System.EventHandler(this.tendoituong_SelectedIndexChanged);
            this.tendoituong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tendoituong_KeyDown);
            // 
            // label32
            // 
            this.label32.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label32.Location = new System.Drawing.Point(17, 45);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(104, 23);
            this.label32.TabIndex = 208;
            this.label32.Text = "Ngày giờ vào khoa :";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // icd_vaokhoa
            // 
            this.icd_vaokhoa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.icd_vaokhoa.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.icd_vaokhoa.Location = new System.Drawing.Point(117, 159);
            this.icd_vaokhoa.Masked = MaskedTextBox.MaskedTextBox.Mask.ICD10;
            this.icd_vaokhoa.MaxLength = 9;
            this.icd_vaokhoa.Name = "icd_vaokhoa";
            this.icd_vaokhoa.Size = new System.Drawing.Size(59, 21);
            this.icd_vaokhoa.TabIndex = 26;
            this.icd_vaokhoa.TextChanged += new System.EventHandler(this.icd_noichuyenden_TextChanged);
            this.icd_vaokhoa.Validated += new System.EventHandler(this.icd_vaokhoa_Validated);
            // 
            // lvaokhoa
            // 
            this.lvaokhoa.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lvaokhoa.Location = new System.Drawing.Point(1, 159);
            this.lvaokhoa.Name = "lvaokhoa";
            this.lvaokhoa.Size = new System.Drawing.Size(120, 23);
            this.lvaokhoa.TabIndex = 204;
            this.lvaokhoa.Text = "CĐ khoa điều trị :";
            this.lvaokhoa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // icd_kkb
            // 
            this.icd_kkb.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.icd_kkb.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.icd_kkb.Location = new System.Drawing.Point(117, 136);
            this.icd_kkb.Masked = MaskedTextBox.MaskedTextBox.Mask.ICD10;
            this.icd_kkb.MaxLength = 9;
            this.icd_kkb.Name = "icd_kkb";
            this.icd_kkb.Size = new System.Drawing.Size(59, 21);
            this.icd_kkb.TabIndex = 24;
            this.icd_kkb.TextChanged += new System.EventHandler(this.icd_noichuyenden_TextChanged);
            this.icd_kkb.Validated += new System.EventHandler(this.icd_kkb_Validated);
            // 
            // label34
            // 
            this.label34.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label34.Location = new System.Drawing.Point(17, 137);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(104, 23);
            this.label34.TabIndex = 203;
            this.label34.Text = "CĐ KKB, Cấp cứu :";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // icd_noichuyenden
            // 
            this.icd_noichuyenden.BackColor = System.Drawing.SystemColors.HighlightText;
            this.icd_noichuyenden.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.icd_noichuyenden.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.icd_noichuyenden.Location = new System.Drawing.Point(117, 113);
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
            this.label31.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label31.Location = new System.Drawing.Point(8, 114);
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
            this.qh_diachi.Location = new System.Drawing.Point(408, 91);
            this.qh_diachi.Name = "qh_diachi";
            this.qh_diachi.Size = new System.Drawing.Size(136, 21);
            this.qh_diachi.TabIndex = 20;
            this.qh_diachi.Validated += new System.EventHandler(this.qh_diachi_Validated);
            this.qh_diachi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.qh_diachi_KeyDown);
            // 
            // qh_hoten
            // 
            this.qh_hoten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.qh_hoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qh_hoten.Location = new System.Drawing.Point(224, 91);
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
            this.quanhe.Size = new System.Drawing.Size(64, 21);
            this.quanhe.TabIndex = 18;
            this.quanhe.Validated += new System.EventHandler(this.quanhe_Validated);
            this.quanhe.KeyDown += new System.Windows.Forms.KeyEventHandler(this.quanhe_KeyDown);
            // 
            // sothe
            // 
            this.sothe.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sothe.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.sothe.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sothe.Location = new System.Drawing.Point(296, 68);
            this.sothe.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.sothe.MaxLength = 20;
            this.sothe.Name = "sothe";
            this.sothe.Size = new System.Drawing.Size(111, 21);
            this.sothe.TabIndex = 15;
            this.sothe.Validated += new System.EventHandler(this.sothe_Validated);
            // 
            // sovaovien
            // 
            this.sovaovien.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sovaovien.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.sovaovien.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sovaovien.Location = new System.Drawing.Point(600, 68);
            this.sovaovien.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.sovaovien.MaxLength = 10;
            this.sovaovien.Name = "sovaovien";
            this.sovaovien.Size = new System.Drawing.Size(64, 21);
            this.sovaovien.TabIndex = 17;
            this.sovaovien.Validated += new System.EventHandler(this.sovaovien_Validated);
            // 
            // label30
            // 
            this.label30.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label30.Location = new System.Drawing.Point(528, 68);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(72, 23);
            this.label30.TabIndex = 201;
            this.label30.Text = "Số vào viện :";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label29
            // 
            this.label29.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label29.Location = new System.Drawing.Point(537, 91);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(64, 23);
            this.label29.TabIndex = 200;
            this.label29.Text = "Điện thoại :";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label28
            // 
            this.label28.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label28.Location = new System.Drawing.Point(338, 91);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(70, 23);
            this.label28.TabIndex = 199;
            this.label28.Text = "Địa chỉ :";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label27
            // 
            this.label27.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label27.Location = new System.Drawing.Point(160, 91);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(64, 23);
            this.label27.TabIndex = 198;
            this.label27.Text = "Họ tên :";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label26
            // 
            this.label26.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label26.Location = new System.Drawing.Point(-16, 90);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(136, 23);
            this.label26.TabIndex = 197;
            this.label26.Text = "Người nhà, quan hệ :";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label25
            // 
            this.label25.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label25.Location = new System.Drawing.Point(400, 68);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(64, 23);
            this.label25.TabIndex = 196;
            this.label25.Text = "Đến ngày :";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label24
            // 
            this.label24.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label24.Location = new System.Drawing.Point(232, 68);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(64, 23);
            this.label24.TabIndex = 195;
            this.label24.Text = "Số thẻ :";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label23
            // 
            this.label23.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label23.Location = new System.Drawing.Point(30, 65);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(87, 23);
            this.label23.TabIndex = 12;
            this.label23.Text = "Đối tượng :";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tennhantu
            // 
            this.tennhantu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tennhantu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tennhantu.Enabled = false;
            this.tennhantu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tennhantu.Location = new System.Drawing.Point(326, 22);
            this.tennhantu.Name = "tennhantu";
            this.tennhantu.Size = new System.Drawing.Size(87, 21);
            this.tennhantu.TabIndex = 3;
            this.tennhantu.SelectedIndexChanged += new System.EventHandler(this.tennhantu_SelectedIndexChanged);
            this.tennhantu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tennhantu_KeyDown);
            // 
            // label22
            // 
            this.label22.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label22.Location = new System.Drawing.Point(584, 22);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(58, 23);
            this.label22.TabIndex = 193;
            this.label22.Text = "Lần thứ :";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nhantu
            // 
            this.nhantu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nhantu.Enabled = false;
            this.nhantu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhantu.Location = new System.Drawing.Point(303, 22);
            this.nhantu.Name = "nhantu";
            this.nhantu.Size = new System.Drawing.Size(21, 21);
            this.nhantu.TabIndex = 2;
            this.nhantu.Validated += new System.EventHandler(this.nhantu_Validated);
            this.nhantu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nhantu_KeyDown);
            // 
            // dentu
            // 
            this.dentu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dentu.Enabled = false;
            this.dentu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dentu.Location = new System.Drawing.Point(487, 22);
            this.dentu.Name = "dentu";
            this.dentu.Size = new System.Drawing.Size(18, 21);
            this.dentu.TabIndex = 4;
            this.dentu.Validated += new System.EventHandler(this.dentu_Validated);
            this.dentu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dentu_KeyDown);
            // 
            // label21
            // 
            this.label21.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label21.Location = new System.Drawing.Point(406, 22);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(87, 23);
            this.label21.TabIndex = 191;
            this.label21.Text = "Nơi giới thiệu :";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label20
            // 
            this.label20.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label20.Location = new System.Drawing.Point(226, 22);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(80, 23);
            this.label20.TabIndex = 186;
            this.label20.Text = "Nhận từ :";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label19
            // 
            this.label19.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label19.Location = new System.Drawing.Point(17, 22);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(104, 23);
            this.label19.TabIndex = 0;
            this.label19.Text = "Ngày giờ vào viện :";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // makp
            // 
            this.makp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makp.Location = new System.Drawing.Point(305, 45);
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(21, 21);
            this.makp.TabIndex = 9;
            this.makp.Validated += new System.EventHandler(this.makp_Validated);
            this.makp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.makp_KeyDown);
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(233, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 23);
            this.label1.TabIndex = 165;
            this.label1.Text = "Nơi chuyển :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label53
            // 
            this.label53.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label53.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label53.Location = new System.Drawing.Point(16, 3);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(160, 23);
            this.label53.TabIndex = 0;
            this.label53.Text = "II. THÔNG TIN VÀO KHOA :";
            this.label53.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // khamthai
            // 
            this.khamthai.Controls.Add(this.para4);
            this.khamthai.Controls.Add(this.para3);
            this.khamthai.Controls.Add(this.para2);
            this.khamthai.Controls.Add(this.para1);
            this.khamthai.Controls.Add(this.label67);
            this.khamthai.Location = new System.Drawing.Point(537, 44);
            this.khamthai.Name = "khamthai";
            this.khamthai.Size = new System.Drawing.Size(128, 24);
            this.khamthai.TabIndex = 12;
            // 
            // para4
            // 
            this.para4.BackColor = System.Drawing.SystemColors.HighlightText;
            this.para4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.para4.Location = new System.Drawing.Point(105, 1);
            this.para4.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.para4.MaxLength = 2;
            this.para4.Name = "para4";
            this.para4.Size = new System.Drawing.Size(21, 21);
            this.para4.TabIndex = 3;
            this.para4.Validated += new System.EventHandler(this.para4_Validated);
            // 
            // para3
            // 
            this.para3.BackColor = System.Drawing.SystemColors.HighlightText;
            this.para3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.para3.Location = new System.Drawing.Point(82, 1);
            this.para3.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.para3.MaxLength = 2;
            this.para3.Name = "para3";
            this.para3.Size = new System.Drawing.Size(21, 21);
            this.para3.TabIndex = 2;
            this.para3.Validated += new System.EventHandler(this.para3_Validated);
            // 
            // para2
            // 
            this.para2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.para2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.para2.Location = new System.Drawing.Point(59, 1);
            this.para2.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.para2.MaxLength = 2;
            this.para2.Name = "para2";
            this.para2.Size = new System.Drawing.Size(21, 21);
            this.para2.TabIndex = 1;
            this.para2.Validated += new System.EventHandler(this.para2_Validated);
            // 
            // para1
            // 
            this.para1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.para1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.para1.Location = new System.Drawing.Point(36, 1);
            this.para1.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.para1.MaxLength = 2;
            this.para1.Name = "para1";
            this.para1.Size = new System.Drawing.Size(21, 21);
            this.para1.TabIndex = 0;
            this.para1.Validated += new System.EventHandler(this.para1_Validated);
            // 
            // label67
            // 
            this.label67.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label67.Location = new System.Drawing.Point(6, 5);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(32, 15);
            this.label67.TabIndex = 0;
            this.label67.Text = "Para :";
            this.label67.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pungbuou_v
            // 
            this.pungbuou_v.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pungbuou_v.Controls.Add(this.giaidoan_v);
            this.pungbuou_v.Controls.Add(this.m_v);
            this.pungbuou_v.Controls.Add(this.n_v);
            this.pungbuou_v.Controls.Add(this.t_v);
            this.pungbuou_v.Controls.Add(this.label15);
            this.pungbuou_v.Controls.Add(this.label13);
            this.pungbuou_v.Controls.Add(this.label12);
            this.pungbuou_v.Controls.Add(this.label11);
            this.pungbuou_v.Location = new System.Drawing.Point(0, 672);
            this.pungbuou_v.Name = "pungbuou_v";
            this.pungbuou_v.Size = new System.Drawing.Size(800, 22);
            this.pungbuou_v.TabIndex = 19;
            this.pungbuou_v.Visible = false;
            // 
            // giaidoan_v
            // 
            this.giaidoan_v.BackColor = System.Drawing.SystemColors.HighlightText;
            this.giaidoan_v.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.giaidoan_v.Location = new System.Drawing.Point(547, 0);
            this.giaidoan_v.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.giaidoan_v.MaxLength = 50;
            this.giaidoan_v.Name = "giaidoan_v";
            this.giaidoan_v.Size = new System.Drawing.Size(108, 21);
            this.giaidoan_v.TabIndex = 3;
            // 
            // m_v
            // 
            this.m_v.BackColor = System.Drawing.SystemColors.HighlightText;
            this.m_v.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_v.Location = new System.Drawing.Point(380, 0);
            this.m_v.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.m_v.MaxLength = 50;
            this.m_v.Name = "m_v";
            this.m_v.Size = new System.Drawing.Size(110, 21);
            this.m_v.TabIndex = 2;
            // 
            // n_v
            // 
            this.n_v.BackColor = System.Drawing.SystemColors.HighlightText;
            this.n_v.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.n_v.Location = new System.Drawing.Point(245, 0);
            this.n_v.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.n_v.MaxLength = 50;
            this.n_v.Name = "n_v";
            this.n_v.Size = new System.Drawing.Size(110, 21);
            this.n_v.TabIndex = 1;
            // 
            // t_v
            // 
            this.t_v.BackColor = System.Drawing.SystemColors.HighlightText;
            this.t_v.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t_v.Location = new System.Drawing.Point(109, 0);
            this.t_v.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.t_v.MaxLength = 50;
            this.t_v.Name = "t_v";
            this.t_v.Size = new System.Drawing.Size(110, 21);
            this.t_v.TabIndex = 0;
            // 
            // label15
            // 
            this.label15.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label15.Location = new System.Drawing.Point(486, 1);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(64, 23);
            this.label15.TabIndex = 213;
            this.label15.Text = "Giai đoạn :";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label13.Location = new System.Drawing.Point(354, 1);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(25, 23);
            this.label13.TabIndex = 211;
            this.label13.Text = "M :";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label12.Location = new System.Drawing.Point(217, 1);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(25, 23);
            this.label12.TabIndex = 209;
            this.label12.Text = "N :";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label11.Location = new System.Drawing.Point(5, 1);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(104, 23);
            this.label11.TabIndex = 205;
            this.label11.Text = "T :";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pungbuou_r
            // 
            this.pungbuou_r.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pungbuou_r.Controls.Add(this.giaidoan_r);
            this.pungbuou_r.Controls.Add(this.m_r);
            this.pungbuou_r.Controls.Add(this.n_r);
            this.pungbuou_r.Controls.Add(this.t_r);
            this.pungbuou_r.Controls.Add(this.label16);
            this.pungbuou_r.Controls.Add(this.label17);
            this.pungbuou_r.Controls.Add(this.label18);
            this.pungbuou_r.Controls.Add(this.label36);
            this.pungbuou_r.Location = new System.Drawing.Point(0, 592);
            this.pungbuou_r.Name = "pungbuou_r";
            this.pungbuou_r.Size = new System.Drawing.Size(656, 22);
            this.pungbuou_r.TabIndex = 28;
            this.pungbuou_r.Visible = false;
            // 
            // giaidoan_r
            // 
            this.giaidoan_r.BackColor = System.Drawing.SystemColors.HighlightText;
            this.giaidoan_r.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.giaidoan_r.Location = new System.Drawing.Point(547, 0);
            this.giaidoan_r.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.giaidoan_r.MaxLength = 50;
            this.giaidoan_r.Name = "giaidoan_r";
            this.giaidoan_r.Size = new System.Drawing.Size(108, 21);
            this.giaidoan_r.TabIndex = 3;
            // 
            // m_r
            // 
            this.m_r.BackColor = System.Drawing.SystemColors.HighlightText;
            this.m_r.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_r.Location = new System.Drawing.Point(380, 0);
            this.m_r.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.m_r.MaxLength = 50;
            this.m_r.Name = "m_r";
            this.m_r.Size = new System.Drawing.Size(110, 21);
            this.m_r.TabIndex = 2;
            // 
            // n_r
            // 
            this.n_r.BackColor = System.Drawing.SystemColors.HighlightText;
            this.n_r.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.n_r.Location = new System.Drawing.Point(245, 0);
            this.n_r.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.n_r.MaxLength = 50;
            this.n_r.Name = "n_r";
            this.n_r.Size = new System.Drawing.Size(110, 21);
            this.n_r.TabIndex = 1;
            // 
            // t_r
            // 
            this.t_r.BackColor = System.Drawing.SystemColors.HighlightText;
            this.t_r.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t_r.Location = new System.Drawing.Point(109, 0);
            this.t_r.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.t_r.MaxLength = 50;
            this.t_r.Name = "t_r";
            this.t_r.Size = new System.Drawing.Size(110, 21);
            this.t_r.TabIndex = 0;
            // 
            // label16
            // 
            this.label16.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label16.Location = new System.Drawing.Point(486, 1);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(64, 23);
            this.label16.TabIndex = 213;
            this.label16.Text = "Giai đoạn :";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label17
            // 
            this.label17.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label17.Location = new System.Drawing.Point(354, 1);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(25, 23);
            this.label17.TabIndex = 211;
            this.label17.Text = "M :";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label18
            // 
            this.label18.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label18.Location = new System.Drawing.Point(217, 1);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(25, 23);
            this.label18.TabIndex = 209;
            this.label18.Text = "N :";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label36
            // 
            this.label36.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label36.Location = new System.Drawing.Point(5, 1);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(104, 23);
            this.label36.TabIndex = 205;
            this.label36.Text = "T :";
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.Location = new System.Drawing.Point(665, 188);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(120, 65);
            this.treeView1.TabIndex = 207;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // pkhoaden
            // 
            this.pkhoaden.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pkhoaden.Controls.Add(this.tenkhoaden);
            this.pkhoaden.Controls.Add(this.khoaden);
            this.pkhoaden.Controls.Add(this.label65);
            this.pkhoaden.Location = new System.Drawing.Point(0, 588);
            this.pkhoaden.Name = "pkhoaden";
            this.pkhoaden.Size = new System.Drawing.Size(656, 22);
            this.pkhoaden.TabIndex = 37;
            this.pkhoaden.Visible = false;
            // 
            // tenkhoaden
            // 
            this.tenkhoaden.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenkhoaden.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tenkhoaden.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenkhoaden.Location = new System.Drawing.Point(134, 0);
            this.tenkhoaden.Name = "tenkhoaden";
            this.tenkhoaden.Size = new System.Drawing.Size(522, 21);
            this.tenkhoaden.TabIndex = 114;
            this.tenkhoaden.SelectedIndexChanged += new System.EventHandler(this.tenkhoaden_SelectedIndexChanged);
            this.tenkhoaden.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenkhoaden_KeyDown);
            // 
            // khoaden
            // 
            this.khoaden.BackColor = System.Drawing.SystemColors.HighlightText;
            this.khoaden.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.khoaden.Location = new System.Drawing.Point(109, 1);
            this.khoaden.MaxLength = 2;
            this.khoaden.Name = "khoaden";
            this.khoaden.Size = new System.Drawing.Size(24, 21);
            this.khoaden.TabIndex = 113;
            this.khoaden.Validated += new System.EventHandler(this.khoaden_Validated);
            this.khoaden.KeyDown += new System.Windows.Forms.KeyEventHandler(this.khoaden_KeyDown);
            // 
            // label65
            // 
            this.label65.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label65.Location = new System.Drawing.Point(5, 0);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(104, 23);
            this.label65.TabIndex = 112;
            this.label65.Text = "Khoa đến :";
            this.label65.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // treeView2
            // 
            this.treeView2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView2.Location = new System.Drawing.Point(665, 275);
            this.treeView2.Name = "treeView2";
            this.treeView2.Size = new System.Drawing.Size(120, 83);
            this.treeView2.TabIndex = 208;
            this.treeView2.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView2_AfterSelect);
            // 
            // lkhoa
            // 
            this.lkhoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lkhoa.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lkhoa.Location = new System.Drawing.Point(664, 259);
            this.lkhoa.Name = "lkhoa";
            this.lkhoa.Size = new System.Drawing.Size(128, 16);
            this.lkhoa.TabIndex = 210;
            this.lkhoa.Text = "CÁC LẦN VÀO KHOA :";
            this.lkhoa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gphaubenh
            // 
            this.gphaubenh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.gphaubenh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gphaubenh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gphaubenh.Location = new System.Drawing.Point(658, 450);
            this.gphaubenh.Name = "gphaubenh";
            this.gphaubenh.Size = new System.Drawing.Size(126, 21);
            this.gphaubenh.TabIndex = 129;
            this.gphaubenh.Visible = false;
            // 
            // tainantt
            // 
            this.tainantt.BackColor = System.Drawing.Color.Transparent;
            this.tainantt.Enabled = false;
            this.tainantt.Location = new System.Drawing.Point(0, 596);
            this.tainantt.Name = "tainantt";
            this.tainantt.Size = new System.Drawing.Size(16, 14);
            this.tainantt.TabIndex = 214;
            this.tainantt.UseVisualStyleBackColor = false;
            this.tainantt.Visible = false;
            // 
            // ngaysinh
            // 
            this.ngaysinh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ngaysinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngaysinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngaysinh.Location = new System.Drawing.Point(512, 21);
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
            this.ngayrv.Location = new System.Drawing.Point(109, 358);
            this.ngayrv.Mask = "##/##/####";
            this.ngayrv.Name = "ngayrv";
            this.ngayrv.Size = new System.Drawing.Size(70, 21);
            this.ngayrv.TabIndex = 21;
            this.ngayrv.Text = "  /  /    ";
            this.ngayrv.Validated += new System.EventHandler(this.ngayrv_Validated);
            // 
            // cmbTaibien
            // 
            this.cmbTaibien.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cmbTaibien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTaibien.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTaibien.Location = new System.Drawing.Point(658, 404);
            this.cmbTaibien.Name = "cmbTaibien";
            this.cmbTaibien.Size = new System.Drawing.Size(126, 21);
            this.cmbTaibien.TabIndex = 216;
            this.cmbTaibien.Visible = false;
            // 
            // listICD
            // 
            this.listICD.BackColor = System.Drawing.SystemColors.Info;
            this.listICD.ColumnCount = 0;
            this.listICD.Location = new System.Drawing.Point(-16, 592);
            this.listICD.MatchBufferTimeOut = 1000;
            this.listICD.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listICD.Name = "listICD";
            this.listICD.Size = new System.Drawing.Size(75, 17);
            this.listICD.TabIndex = 220;
            this.listICD.TextIndex = -1;
            this.listICD.TextMember = null;
            this.listICD.ValueIndex = -1;
            this.listICD.Visible = false;
            // 
            // cd_kemtheo
            // 
            this.cd_kemtheo.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cd_kemtheo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cd_kemtheo.Location = new System.Drawing.Point(169, 427);
            this.cd_kemtheo.Name = "cd_kemtheo";
            this.cd_kemtheo.Size = new System.Drawing.Size(486, 21);
            this.cd_kemtheo.TabIndex = 32;
            this.cd_kemtheo.TextChanged += new System.EventHandler(this.cd_kemtheo_TextChanged);
            this.cd_kemtheo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cd_kkb_KeyDown);
            // 
            // cd_chinh
            // 
            this.cd_chinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cd_chinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cd_chinh.Location = new System.Drawing.Point(169, 381);
            this.cd_chinh.Name = "cd_chinh";
            this.cd_chinh.Size = new System.Drawing.Size(486, 21);
            this.cd_chinh.TabIndex = 27;
            this.cd_chinh.TextChanged += new System.EventHandler(this.cd_chinh_TextChanged);
            this.cd_chinh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cd_kkb_KeyDown);
            // 
            // cd_nguyennhan
            // 
            this.cd_nguyennhan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cd_nguyennhan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cd_nguyennhan.Location = new System.Drawing.Point(169, 404);
            this.cd_nguyennhan.Name = "cd_nguyennhan";
            this.cd_nguyennhan.Size = new System.Drawing.Size(486, 21);
            this.cd_nguyennhan.TabIndex = 30;
            this.cd_nguyennhan.TextChanged += new System.EventHandler(this.cd_nguyennhan_TextChanged);
            this.cd_nguyennhan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cd_kkb_KeyDown);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripSeparator2,
            this.toolStripButton2,
            this.toolStripSeparator3,
            this.toolStripButton3,
            this.toolStripSeparator4,
            this.toolStripButton4,
            this.toolStripSeparator5,
            this.toolStripButton5,
            this.toolStripSeparator6,
            this.toolStripButton6,
            this.toolStripSeparator7,
            this.toolStripButton10,
            this.toolStripSeparator9,
            this.toolStripButton7,
            this.toolStripSeparator1,
            this.toolStripButton8,
            this.toolStripSeparator8,
            this.toolStripButton9});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(792, 23);
            this.toolStrip1.TabIndex = 239;
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
            this.toolStripButton1.ToolTipText = "Toa thuốc dược phát";
            this.toolStripButton1.Click += new System.EventHandler(this.l_thuoc_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 23);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(39, 20);
            this.toolStripButton2.Text = "F5";
            this.toolStripButton2.ToolTipText = "Toa thuốc mua ngoài";
            this.toolStripButton2.Click += new System.EventHandler(this.l_thuthuat_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 23);
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
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 23);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(39, 20);
            this.toolStripButton4.Text = "F7";
            this.toolStripButton4.ToolTipText = "Cập nhật trẻ sơ sinh";
            this.toolStripButton4.Click += new System.EventHandler(this.l_tresosinh_Click);
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
            this.toolStripButton5.Text = "F8";
            this.toolStripButton5.ToolTipText = "Tử vong";
            this.toolStripButton5.Click += new System.EventHandler(this.l_tuvong_Click);
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
            this.toolStripButton6.Size = new System.Drawing.Size(39, 20);
            this.toolStripButton6.Text = "F9";
            this.toolStripButton6.ToolTipText = "Tai nạn thương tích";
            this.toolStripButton6.Click += new System.EventHandler(this.l_tainantt_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 23);
            // 
            // toolStripButton10
            // 
            this.toolStripButton10.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton10.Image")));
            this.toolStripButton10.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton10.Name = "toolStripButton10";
            this.toolStripButton10.Size = new System.Drawing.Size(45, 20);
            this.toolStripButton10.Text = "F11";
            this.toolStripButton10.ToolTipText = "Bệnh kèm theo";
            this.toolStripButton10.Click += new System.EventHandler(this.toolStripButton10_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 23);
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton7.Image")));
            this.toolStripButton7.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.Size = new System.Drawing.Size(66, 20);
            this.toolStripButton7.Text = "Lịch hẹn";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 23);
            // 
            // toolStripButton8
            // 
            this.toolStripButton8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton8.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton8.Image")));
            this.toolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton8.Name = "toolStripButton8";
            this.toolStripButton8.Size = new System.Drawing.Size(23, 20);
            this.toolStripButton8.ToolTipText = "Bệnh mãn tính";
            this.toolStripButton8.Click += new System.EventHandler(this.toolStripButton8_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 23);
            // 
            // toolStripButton9
            // 
            this.toolStripButton9.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton9.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton9.Image")));
            this.toolStripButton9.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton9.Name = "toolStripButton9";
            this.toolStripButton9.Size = new System.Drawing.Size(23, 20);
            this.toolStripButton9.Text = "Nội dung tường trình phẫu thuật vắn tắt";
            this.toolStripButton9.Click += new System.EventHandler(this.toolStripButton9_Click);
            // 
            // chkIn
            // 
            this.chkIn.Checked = true;
            this.chkIn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkIn.Location = new System.Drawing.Point(658, 364);
            this.chkIn.Name = "chkIn";
            this.chkIn.Size = new System.Drawing.Size(128, 18);
            this.chkIn.TabIndex = 236;
            this.chkIn.Text = "In thanh toán ra viện";
            this.chkIn.Click += new System.EventHandler(this.chkIn_Click);
            // 
            // label68
            // 
            this.label68.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label68.Location = new System.Drawing.Point(7, 0);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(104, 23);
            this.label68.TabIndex = 204;
            this.label68.Text = "Ngày đẻ (mổ đẻ) :";
            this.label68.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // kiemsoat
            // 
            this.kiemsoat.ForeColor = System.Drawing.SystemColors.ControlText;
            this.kiemsoat.Location = new System.Drawing.Point(584, 0);
            this.kiemsoat.Name = "kiemsoat";
            this.kiemsoat.Size = new System.Drawing.Size(96, 24);
            this.kiemsoat.TabIndex = 4;
            this.kiemsoat.Text = "KS tử cung";
            this.kiemsoat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.kiemsoat_KeyDown);
            // 
            // ngayde
            // 
            this.ngayde.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngayde.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngayde.Location = new System.Drawing.Point(108, 0);
            this.ngayde.Mask = "##/##/####";
            this.ngayde.Name = "ngayde";
            this.ngayde.Size = new System.Drawing.Size(70, 21);
            this.ngayde.TabIndex = 0;
            this.ngayde.Text = "  /  /    ";
            this.ngayde.Validated += new System.EventHandler(this.ngayde_Validated);
            // 
            // label9
            // 
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(225, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 23);
            this.label9.TabIndex = 207;
            this.label9.Text = "Tai biến";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // matb
            // 
            this.matb.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.matb.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.matb.Location = new System.Drawing.Point(286, 0);
            this.matb.Name = "matb";
            this.matb.Size = new System.Drawing.Size(48, 21);
            this.matb.TabIndex = 2;
            this.matb.Validated += new System.EventHandler(this.matb_Validated);
            this.matb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.matb_KeyDown);
            // 
            // tentb
            // 
            this.tentb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tentb.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tentb.Location = new System.Drawing.Point(336, 0);
            this.tentb.Name = "tentb";
            this.tentb.Size = new System.Drawing.Size(242, 21);
            this.tentb.TabIndex = 3;
            this.tentb.SelectedIndexChanged += new System.EventHandler(this.tentb_SelectedIndexChanged);
            this.tentb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tentb_KeyDown);
            // 
            // psankhoa
            // 
            this.psankhoa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.psankhoa.Controls.Add(this.ngayde);
            this.psankhoa.Controls.Add(this.giode);
            this.psankhoa.Controls.Add(this.label10);
            this.psankhoa.Controls.Add(this.tentb);
            this.psankhoa.Controls.Add(this.matb);
            this.psankhoa.Controls.Add(this.label9);
            this.psankhoa.Controls.Add(this.kiemsoat);
            this.psankhoa.Controls.Add(this.label68);
            this.psankhoa.Location = new System.Drawing.Point(1, 524);
            this.psankhoa.Name = "psankhoa";
            this.psankhoa.Size = new System.Drawing.Size(800, 22);
            this.psankhoa.TabIndex = 18;
            // 
            // giode
            // 
            this.giode.BackColor = System.Drawing.SystemColors.HighlightText;
            this.giode.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.giode.Location = new System.Drawing.Point(204, 0);
            this.giode.Mask = "##:##";
            this.giode.Name = "giode";
            this.giode.Size = new System.Drawing.Size(36, 21);
            this.giode.TabIndex = 1;
            this.giode.Text = "  :  ";
            this.giode.Validated += new System.EventHandler(this.giode_Validated);
            // 
            // label10
            // 
            this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label10.Location = new System.Drawing.Point(175, -2);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 23);
            this.label10.TabIndex = 257;
            this.label10.Text = "giờ :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // giorv
            // 
            this.giorv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.giorv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.giorv.Location = new System.Drawing.Point(203, 358);
            this.giorv.Mask = "##:##";
            this.giorv.Name = "giorv";
            this.giorv.Size = new System.Drawing.Size(36, 21);
            this.giorv.TabIndex = 22;
            this.giorv.Text = "  :  ";
            this.giorv.Validated += new System.EventHandler(this.giorv_Validated);
            // 
            // label69
            // 
            this.label69.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label69.Location = new System.Drawing.Point(172, 356);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(32, 23);
            this.label69.TabIndex = 265;
            this.label69.Text = "giờ :";
            this.label69.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butBoqua
            // 
            this.butBoqua.BackColor = System.Drawing.Color.Transparent;
            this.butBoqua.Enabled = false;
            this.butBoqua.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butBoqua.ForeColor = System.Drawing.SystemColors.ControlText;
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(315, 500);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(60, 25);
            this.butBoqua.TabIndex = 45;
            this.butBoqua.Text = "Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.UseVisualStyleBackColor = false;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butVienphi
            // 
            this.butVienphi.BackColor = System.Drawing.Color.Transparent;
            this.butVienphi.Enabled = false;
            this.butVienphi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butVienphi.ForeColor = System.Drawing.SystemColors.ControlText;
            this.butVienphi.Image = ((System.Drawing.Image)(resources.GetObject("butVienphi.Image")));
            this.butVienphi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butVienphi.Location = new System.Drawing.Point(375, 500);
            this.butVienphi.Name = "butVienphi";
            this.butVienphi.Size = new System.Drawing.Size(153, 25);
            this.butVienphi.TabIndex = 44;
            this.butVienphi.Text = "   &Chuyển chi phí thanh toán";
            this.butVienphi.UseVisualStyleBackColor = false;
            this.butVienphi.Click += new System.EventHandler(this.butVienphi_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.BackColor = System.Drawing.Color.Transparent;
            this.butKetthuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butKetthuc.ForeColor = System.Drawing.SystemColors.ControlText;
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(528, 500);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 46;
            this.butKetthuc.Text = "Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.UseVisualStyleBackColor = false;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // butLuu
            // 
            this.butLuu.BackColor = System.Drawing.Color.Transparent;
            this.butLuu.Enabled = false;
            this.butLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butLuu.ForeColor = System.Drawing.SystemColors.ControlText;
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(255, 500);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(60, 25);
            this.butLuu.TabIndex = 42;
            this.butLuu.Text = "    &Lưu";
            this.butLuu.UseVisualStyleBackColor = false;
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butTiep
            // 
            this.butTiep.BackColor = System.Drawing.Color.Transparent;
            this.butTiep.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butTiep.ForeColor = System.Drawing.SystemColors.ControlText;
            this.butTiep.Image = ((System.Drawing.Image)(resources.GetObject("butTiep.Image")));
            this.butTiep.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butTiep.Location = new System.Drawing.Point(195, 500);
            this.butTiep.Name = "butTiep";
            this.butTiep.Size = new System.Drawing.Size(60, 25);
            this.butTiep.TabIndex = 43;
            this.butTiep.Text = "      &Tiếp";
            this.butTiep.UseVisualStyleBackColor = false;
            this.butTiep.Click += new System.EventHandler(this.butTiep_Click);
            // 
            // tenbs
            // 
            this.tenbs.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbs.Location = new System.Drawing.Point(148, 450);
            this.tenbs.MaxLength = 4;
            this.tenbs.Name = "tenbs";
            this.tenbs.Size = new System.Drawing.Size(176, 21);
            this.tenbs.TabIndex = 34;
            this.tenbs.TextChanged += new System.EventHandler(this.tenbs_TextChanged);
            this.tenbs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbs_KeyDown);
            // 
            // listBS
            // 
            this.listBS.BackColor = System.Drawing.SystemColors.Info;
            this.listBS.ColumnCount = 0;
            this.listBS.Location = new System.Drawing.Point(383, 551);
            this.listBS.MatchBufferTimeOut = 1000;
            this.listBS.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listBS.Name = "listBS";
            this.listBS.Size = new System.Drawing.Size(148, 17);
            this.listBS.TabIndex = 266;
            this.listBS.TextIndex = -1;
            this.listBS.TextMember = null;
            this.listBS.ValueIndex = -1;
            this.listBS.Visible = false;
            // 
            // frmXuatkhoa
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.pnhi);
            this.Controls.Add(this.listBS);
            this.Controls.Add(this.tenbs);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.ngayrv);
            this.Controls.Add(this.giorv);
            this.Controls.Add(this.label69);
            this.Controls.Add(this.chkIn);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.treeView2);
            this.Controls.Add(this.psankhoa);
            this.Controls.Add(this.butVienphi);
            this.Controls.Add(this.pkhoaden);
            this.Controls.Add(this.loaibv);
            this.Controls.Add(this.tenloaibv);
            this.Controls.Add(this.pungbuou_r);
            this.Controls.Add(this.cd_nguyennhan);
            this.Controls.Add(this.cd_kemtheo);
            this.Controls.Add(this.cd_chinh);
            this.Controls.Add(this.listICD);
            this.Controls.Add(this.cmbTaibien);
            this.Controls.Add(this.gphaubenh);
            this.Controls.Add(this.giaiphau);
            this.Controls.Add(this.bienchung);
            this.Controls.Add(this.tainantt);
            this.Controls.Add(this.taibien);
            this.Controls.Add(this.ngaysinh);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.lkhoa);
            this.Controls.Add(this.ppara);
            this.Controls.Add(this.phai);
            this.Controls.Add(this.lphai);
            this.Controls.Add(this.phanhchinh);
            this.Controls.Add(this.pungbuou_v);
            this.Controls.Add(this.pvaovien);
            this.Controls.Add(this.psosinh);
            this.Controls.Add(this.tenba);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butTiep);
            this.Controls.Add(this.label54);
            this.Controls.Add(this.label52);
            this.Controls.Add(this.songaydt);
            this.Controls.Add(this.label51);
            this.Controls.Add(this.tenttlucrv);
            this.Controls.Add(this.soluutru);
            this.Controls.Add(this.label50);
            this.Controls.Add(this.mabs);
            this.Controls.Add(this.label49);
            this.Controls.Add(this.tenbv);
            this.Controls.Add(this.mabv);
            this.Controls.Add(this.label48);
            this.Controls.Add(this.label47);
            this.Controls.Add(this.icd_kemtheo);
            this.Controls.Add(this.label46);
            this.Controls.Add(this.icd_nguyennhan);
            this.Controls.Add(this.label44);
            this.Controls.Add(this.icd_chinh);
            this.Controls.Add(this.label42);
            this.Controls.Add(this.tenketqua);
            this.Controls.Add(this.ttlucrv);
            this.Controls.Add(this.label40);
            this.Controls.Add(this.giuong);
            this.Controls.Add(this.ketqua);
            this.Controls.Add(this.label39);
            this.Controls.Add(this.label38);
            this.Controls.Add(this.label37);
            this.Controls.Add(this.namsinh);
            this.Controls.Add(this.hoten);
            this.Controls.Add(this.tuoi);
            this.Controls.Add(this.maba);
            this.Controls.Add(this.mabn3);
            this.Controls.Add(this.loaituoi);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.mabn2);
            this.Controls.Add(this.mabn1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmXuatkhoa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Medisoft";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmXuatkhoa_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmXuatkhoa_KeyDown);
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
            this.khamthai.ResumeLayout(false);
            this.khamthai.PerformLayout();
            this.pungbuou_v.ResumeLayout(false);
            this.pungbuou_v.PerformLayout();
            this.pungbuou_r.ResumeLayout(false);
            this.pungbuou_r.PerformLayout();
            this.pkhoaden.ResumeLayout(false);
            this.pkhoaden.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.psankhoa.ResumeLayout(false);
            this.psankhoa.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmXuatkhoa_Load(object sender, System.EventArgs e)
		{
            if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            //this.phanhchinh.Size = new System.Drawing.Size(this.Width, 68);
            //this.pvaovien.Size = new System.Drawing.Size(this.Width, 181);
            //this.psosinh.Size = new System.Drawing.Size(this.Width, 44);
            //this.pnhi.Size = new System.Drawing.Size(this.Width, 48);
            bInravien_ravien = m.bInravien_ravien; bPhonggiuong = m.bPhonggiuong; bGiuong_khoa = m.bGiuong_khoa;
            bSoluutru_xuatkhoa = m.bSoluutru_xuatkhoa; bTtptttkhoa = m.bTtptttkhoa;
            bTress_bame = m.bTress_bame; b101204 = m.Mabv_so == 101204; 
            user = m.user; bSoluutru_icd10 = m.bSoluutru_icd10; bThanhtoan_khoa = m.bThanhtoan_khoa;
            bSoluutru_sovaovien = m.bSoluutru_sovaovien; bSoluutru = m.bSoluutru_nam;
            madoituong_giuongdichvu = (m.bMadoituong_giuongdichvu) ? m.madoituong_giuongdichvu : 0;
            bNgayra_ngayvao_1 = m.bNgayra_ngayvao_1;
            bSothe_ngay_huong = m.bSothe_ngay_huong;
            bKiemtra = d.bKiemtra_phat_thuhoi(m.nhom_duoc);
            if (bPhonggiuong) dtg = m.get_data("select a.*,b.chenhlech,c.dichvu from " + user + ".dmgiuong a," + user + ".v_giavp b," + user + ".dmphong c where a.id=b.id and a.idphong=c.id").Tables[0];
            dtdt = m.get_data("select a.*,to_char(madoituong) as madoituong1 from " + user + ".doituong a").Tables[0];
            foreach (DataRow r in m.get_data("select tenkp from " + user + ".btdkp_bv where makp='" + s_makp + "'").Tables[0].Rows)
                s_tenkhoa = r["tenkp"].ToString();
            s_msg = LibMedi.AccessData.Msg;
            makp_chuyenkhoa = m.makp_chuyenkhoa;
            m_nguyennhan = LibMedi.AccessData.cdnguyennhan;
            m_phainu = LibMedi.AccessData.phainu;
            m_sosinh = LibMedi.AccessData.sosinh;
            bDanhmuc_nhathuoc = m.bDanhmuc_nhathuoc;//binh
			bChandoan=m.bChandoan_icd10;
            bChandoan_kemtheo = m.bChandoan_kemtheo_icd10;
            bChandoan_nguyennhan = m.bChandoan_nguyennhan_icd10;
			tentb.DisplayMember="TEN";
			tentb.ValueMember="MA";
			tentb.DataSource=m.get_data("select * from "+user+".dmtaibiensanh order by stt").Tables[0];
			bDenngay_sothe=m.bDenngay_sothe;
			bTiepdon=m.bTiepdon(LibMedi.AccessData.Khoa);
			bKhamthai=m.bKhamthai;
			khamthai.Visible=bKhamthai;
			bChuyenkhoasan=m.bChuyenkhoasan;
			if (bChuyenkhoasan) phai.SelectedIndex=1;
			bMabame=m.bMabame;
			bNhapsoluutru=m.bSoluutru_nhapvien;
			bAdmin=m.bAdmin(i_userid);
			iTreem6=m.iTreem6;
			iTreem15=m.iTreem15;
			b_bacsi=m.bsXuatkhoa;
			bHanhchinh=m.bHanhChinh;
			bLuutru_Mabn=m.bSoluutru_Mabn;
			psankhoa.Top=317;
			pungbuou_v.Top=psankhoa.Top;
			pungbuou_r.Top=404;
			ppara.Top=134;
			pnhi.Top=111;
			pkhoaden.Top=472;
			load_dm();
			b_Hoten=m.bHoten_gioitinh;
			phai.SelectedIndex=0;
			s_ngayvv=m.Ngaygio;
            ngayvv.Text = s_ngayvv.Substring(0, 10);
            giovv.Text = s_ngayvv.Substring(11);
            ngayvk.Text = s_ngayvv.Substring(0, 10);
            giovk.Text = s_ngayvv.Substring(11);
            s_ngayvk = s_ngayvv;
			songay=m.Ngaylv_Ngayht;
			sovaovien.Enabled=!b_sovaovien;
			cd_kkb.Enabled=m.bChandoan;
			cd_vaokhoa.Enabled=cd_kkb.Enabled;
			cd_noichuyenden.Enabled=cd_kkb.Enabled;
			cd_chinh.Enabled=cd_kkb.Enabled;
			//cd_nguyennhan.Enabled=cd_kkb.Enabled;
			cd_kemtheo.Enabled=cd_kkb.Enabled;
            giuong.Enabled = !bPhonggiuong;
            soluutru.Enabled=!(bLuutru_Mabn || bSoluutru_icd10 || bSoluutru || bSoluutru_sovaovien);
			ena_object();
			chkIn.Checked=m.bInphieuttravien_xuatkhoa;
		}

		private void ena_object()
		{            
			loaituoi.Enabled=bHanhchinh;
			hoten.Enabled=bHanhchinh;
			ngaysinh.Enabled=bHanhchinh;
			namsinh.Enabled=bHanhchinh;
			tuoi.Enabled=bHanhchinh;
			sonha.Enabled=bHanhchinh;
			thon.Enabled=bHanhchinh;
			cholam.Enabled=bHanhchinh;
			tentqx.Enabled=bHanhchinh;
			tqx.Enabled=bHanhchinh;
			tentinh.Enabled=bHanhchinh;
			tendantoc.Enabled=bHanhchinh;
			tennuoc.Enabled=bHanhchinh;
			mann.Enabled=bHanhchinh;
			tennn.Enabled=bHanhchinh;
			tenquan.Enabled=bHanhchinh;
			maqu2.Enabled=bHanhchinh;
			tenpxa.Enabled=bHanhchinh;
			mapxa2.Enabled=bHanhchinh;
			madantoc.Enabled=bHanhchinh;
			matt.Enabled=bHanhchinh;
			phai.Enabled=bHanhchinh;
			if (bSosinh)
			{
				ss_hoten_bo.Enabled=bHanhchinh;
				ss_ns_bo.Enabled=bHanhchinh;
				ss_tennn_bo.Enabled=bHanhchinh;
				ss_delan.Enabled=bHanhchinh;
				ss_para1.Enabled=bHanhchinh;
				ss_para2.Enabled=bHanhchinh;
				ss_para3.Enabled=bHanhchinh;
				ss_para4.Enabled=bHanhchinh;
				ss_hoten_me.Enabled=bHanhchinh;
				ss_ns_me.Enabled=bHanhchinh;
				ss_tennn_me.Enabled=bHanhchinh;
			}
			else if (bNhi)
			{
				nhi_hoten_bo.Enabled=bHanhchinh;
				nhi_hoten_me.Enabled=bHanhchinh;
				nhi_vanhoa_bo.Enabled=bHanhchinh;
				nhi_vanhoa_me.Enabled=bHanhchinh;
				nhi_tennn_bo.Enabled=bHanhchinh;
				nhi_tennn_me.Enabled=bHanhchinh;
			}
		}

		private void load_chuyenkhoa()
		{
            //chuyenkhoa.Checked=m.get_data("select * from chuyenkhoa where maql="+l_maql).Tables[0].Rows.Count!=0;
            //l_chuyenkhoa.ForeColor=(chuyenkhoa.Checked)?Color.FromArgb(255,0,0):Color.FromArgb(0,0,255);
		}

		private void load_tuvong()
		{
            //tuvong.Checked=m.get_data("select * from tuvong where maql="+l_maql).Tables[0].Rows.Count!=0;
            //l_tuvong.ForeColor=(tuvong.Checked)?Color.FromArgb(255,0,0):Color.FromArgb(0,0,255);
		}

		private void load_baohiem()
		{
            //thuoc.Checked=m.get_data("select * from d_thuocbhytll where nhom="+m.nhom_duoc+" and maql="+l_maql).Tables[0].Rows.Count!=0;
            //l_thuoc.ForeColor=(thuoc.Checked)?Color.FromArgb(255,0,0):Color.FromArgb(0,0,255);
		}

		private void load_phauthuat()
		{
            //phauthuat.Checked=m.get_data("select * from pttt where substr(mapt,1,1)='P' and maql="+l_maql).Tables[0].Rows.Count!=0;
            //l_phauthuat.ForeColor=(phauthuat.Checked)?Color.FromArgb(255,0,0):Color.FromArgb(0,0,255);
		}

		private void load_thuthuat()
		{
            //thuthuat.Checked=m.get_data("select * from pttt where substr(mapt,1,1)='T' and maql="+l_maql).Tables[0].Rows.Count!=0;
            //l_thuthuat.ForeColor=(thuthuat.Checked)?Color.FromArgb(255,0,0):Color.FromArgb(0,0,255);
		}

		private void load_tainantt()
		{
            //tainantt.Checked=m.get_data("select * from tainantt where maql="+l_maql).Tables[0].Rows.Count!=0;
            //l_tainantt.ForeColor=(tainantt.Checked)?Color.FromArgb(255,0,0):Color.FromArgb(0,0,255);
		}

		private void load_tresosinh()
		{
            //tresosinh.Checked=m.get_data("select * from tresosinh where maql="+l_maql).Tables[0].Rows.Count!=0;
            //l_tresosinh.ForeColor=(tresosinh.Checked)?Color.FromArgb(255,0,0):Color.FromArgb(0,0,255);
		}

		private void load_dm()
		{
            dticd = m.get_data("select cicd10,vviet from " + user + ".icd10 where hide=0 order by cicd10").Tables[0];
			listICD.DisplayMember="CICD10";
			listICD.ValueMember="VVIET";
			listICD.DataSource=dticd;

			tenkp.DisplayMember="TENKP";
			tenkp.ValueMember="MAKP";
            tenkp.DataSource = m.get_data("select * from " + user + ".btdkp_bv where loai=0 and makp<>'" + s_makp + "' order by makp").Tables[0];
			try
			{
                string s_maba = m.get_data("select maba from " + user + ".btdkp_bv where makp='" + s_makp + "'").Tables[0].Rows[0][0].ToString();
                dtba = m.get_data("select * from " + user + ".dmbenhan_bv where loaiba=1 and maba in (" + s_maba + ")" + " order by maba").Tables[0];
			}
			catch
			{
                dtba = m.get_data("select * from " + user + ".dmbenhan_bv where loaiba=1 order by maba").Tables[0];
			}
			tenba.DisplayMember="TENVT";
			tenba.ValueMember="MAVT";
			tenba.DataSource=dtba;
			if(dtba.Rows.Count>0) tenba.SelectedIndex=0;
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

			tenketqua.DisplayMember="TEN";
			tenketqua.ValueMember="MA";
            tenketqua.DataSource = m.get_data("select * from " + user + ".ketqua order by ma").Tables[0];
			tenketqua.SelectedIndex=-1;

			tenttlucrv.DisplayMember="TEN";
			tenttlucrv.ValueMember="MA";
            tenttlucrv.DataSource = m.get_data("select * from " + user + ".ttxk order by ma").Tables[0];
			tenttlucrv.SelectedIndex=-1;

            listBS.DisplayMember = "MA";
            listBS.ValueMember = "HOTEN";
			if (b_bacsi)
			{
                dtbs  = m.get_data("select ma, hoten, makp, mapk, viettat from " + user + ".dmbs where nhom not in (" + LibMedi.AccessData.nhanvien + "," + LibMedi.AccessData.nghiviec + ") and makp='" + s_makp + "'" + " order by ma").Tables[0];
                if (dtbs.Rows.Count == 0) dtbs = m.get_data("select ma, hoten, makp, mapk, viettat from " + user + ".dmbs where nhom not in (" + LibMedi.AccessData.nhanvien + "," + LibMedi.AccessData.nghiviec + ") order by ma").Tables[0];
			}
            else dtbs = m.get_data("select ma, hoten, makp, mapk, viettat from " + user + ".dmbs where nhom not in (" + LibMedi.AccessData.nhanvien + "," + LibMedi.AccessData.nghiviec + ") order by ma").Tables[0];
            tenbs.Text = "";
            mabs.Text = "";
            listBS.DataSource = dtbs;

			tenloaibv.DisplayMember="TEN";
			tenloaibv.ValueMember="MA";
            tenloaibv.DataSource = m.get_data("select * from " + user + ".loaibv order by ma").Tables[0];
			tenloaibv.SelectedIndex=-1;

			tenbv.DisplayMember="TENBV";
			tenbv.ValueMember="MABV";	
	
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

			tenkhoaden.DisplayMember="TENKP";
			tenkhoaden.ValueMember="MAKP";
			load_khoaden();

			gphaubenh.DisplayMember="TEN";
			gphaubenh.ValueMember="MA";
            gphaubenh.DataSource = m.get_data("select * from " + user + ".gphaubenh").Tables[0];

			cmbTaibien.DisplayMember="TEN";
			cmbTaibien.ValueMember="MA";
            cmbTaibien.DataSource = m.get_data("select * from " + user + ".taibien").Tables[0];
		}

		private void load_khoaden()
		{
            tenkhoaden.DataSource = m.get_data("select * from " + user + ".btdkp_bv where loai=0 and makp<>'01' and makp<>'" + s_makp + "'" + " order by makp").Tables[0];
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
            tendoituong.DataSource = m.get_data("select a.*,to_char(madoituong) as madoituong1 from " + user + ".doituong a order by madoituong").Tables[0];
            tendoituong.DisplayMember = "DOITUONG";
            tendoituong.ValueMember = "MADOITUONG";
            if (tendoituong.SelectedIndex != -1)
            {
                madoituong.Text = tendoituong.SelectedValue.ToString();
                string so = m.sothe(int.Parse(tendoituong.SelectedValue.ToString()));
                sothe.Enabled = int.Parse(so.Substring(0, 2)) > 0;
                denngay.Enabled = so.Substring(2, 1) == "1";
            }
            if (bKhamthai) khamthai.Visible = tenba.SelectedValue.ToString() != "BSO";
		}

		private void load_mabv(string maloai)
		{
			if (maloai=="3")
				tenbv.DataSource=m.get_data("select * from "+user+".tenvien where substr(maloai,1,1)='2' and mabv like '"+mabv.Text+"%'"+" and mabv<>'"+m.Mabv+"' order by mabv").Tables[0];
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
                this.Text = "Xuất khoa " + s_tenkhoa + "//" + tenba.Text.Trim() + " < Người cập nhật : " + s_userid.Trim() + " >";
				DataRow r=m.getrowbyid(dtba,"mavt='"+tenba.SelectedValue.ToString()+"'");
                if (r != null)
                {
                    i_maba = int.Parse(r[0].ToString());
                    if (bGiuong_khoa)
                    {
                        bPhonggiuong = r["phong"].ToString() == "1";
                        giuong.Enabled = !bPhonggiuong;
                    }
                }
                else i_maba = 0;
				if (m.bChandoan)
					cd_nguyennhan.Enabled=m_nguyennhan.IndexOf(tenba.SelectedValue.ToString())!=-1;
				icd_nguyennhan.Enabled=m_nguyennhan.IndexOf(tenba.SelectedValue.ToString())!=-1;
				phai.Enabled=m_phainu.IndexOf(tenba.SelectedValue.ToString())==-1;
				load_mann(m_sosinh.IndexOf(tenba.SelectedValue.ToString())!=-1);
				tennn.SelectedIndex=-1;
				if (!phai.Enabled) phai.SelectedIndex=1;
				load_text();
			}
			catch{}
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
			bUngbuou=tenba.SelectedValue.ToString()=="BUN";
			if (m.Mabv_so==701306) lvaokhoa.Text=lan.Change_language_MessageText("CĐ khoa điều trị :");
			else lvaokhoa.Text=(bSankhoa)?lan.Change_language_MessageText("CĐ khi vào đẻ :"):lan.Change_language_MessageText("CĐ khoa điều trị :");
			pvaovien.Top=(bSankhoa || bUngbuou)?135:156;
			treeView1.Top=pvaovien.Top+22;
			treeView1.Height=(bSankhoa || bUngbuou)?100:80;
			psankhoa.Visible=bSankhoa;
			bTamthan=tenba.SelectedValue.ToString()=="BTH";
			ltdvh.Visible=bTamthan;
			tdvh.Visible=ltdvh.Visible;
			tenkp.Width=(ltdvh.Visible)?87:209;
			lbong.Visible=bBong;
			ngaybong.Visible=bBong;
			if (bBong) tenkp.Width=80;
			pungbuou_v.Visible=bUngbuou;
			pungbuou_r.Visible=bUngbuou;
			toolStripButton4.Enabled=bSankhoa;
			if (bSosinh)
			{
				tendoituong.SelectedValue="3"; 
				madoituong.Text=tendoituong.SelectedValue.ToString();
				khamthai.Visible=false;
			}			
		}

		private void load_sosinh(bool ena)
		{
			lmadantoc.Left=(ena)?15:365;
			madantoc.Left=(ena)?72:421;
			tendantoc.Left=(ena)?98:447;
			lmanuoc.Left=(ena)?167:514;
			manuoc.Left=(ena)?234:575;
			tennuoc.Left=(ena)?260:601;
			lsonha.Left=(ena)?355:680;
			sonha.Left=(ena)?403:726;
			lthon.Top=(ena)?0:23;
			lthon.Left=(ena)?517:2;
			thon.Top=lthon.Top;
			thon.Left=(ena)?588:72;
			thon.Width=(ena)?212:184;
			ltqx.Left=(ena)?-2:249;
			tqx.Left=(ena)?72:323;
			tentqx.Left=(ena)?122:373;
			lmatt.Left=(ena)?344:603;
			matt.Left=(ena)?403:659;
			tentinh.Left=(ena)?432:688;
			lmaqu.Top=(ena)?23:46;
			maqu1.Top=lmaqu.Top;
			maqu2.Top=lmaqu.Top;
			tenquan.Top=lmaqu.Top;
			lmaqu.Left=(ena)?512:-8;
			maqu1.Left=(ena)?588:72;
			maqu2.Left=(ena)?617:101;
			tenquan.Left=(ena)?642:126;
			tenquan.Width=(ena)?158:130;
			lmaphuongxa.Left=(ena)?1:251;
			mapxa1.Left=(ena)?72:323;
			mapxa2.Left=(ena)?113:365;
			tenpxa.Left=(ena)?137:390;
			if (ena)psosinh.Top=42;
			lmann.Visible=!ena;
			mann.Visible=!ena;
			tennn.Visible=!ena;
			psosinh.Visible=ena;
			phanhchinh.Top=(ena)?87:42;
			ppara.Visible=ena;
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
                    //    ngayvv.Focus();
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
			if (mabn3.Text=="") return;
			mabn3.Text=mabn3.Text.PadLeft(6,'0');
			s_mabn=mabn2.Text+mabn3.Text;
			emp_text(true);
			butVienphi.Enabled=true;
			if (load_mabn())
			{
				//if (ngayvv.Text=="")
				//{
				if (load_vv_mabn())
				{
					if (!bAdmin) ena_but(false);
					if (load_vk(false)) load_rk();
				}
				s_icd_noichuyenden=icd_noichuyenden.Text;
				s_icd_kkb=icd_kkb.Text;
				s_icd_vaokhoa=icd_vaokhoa.Text;
				s_icd_chinh=icd_chinh.Text;
				s_icd_nguyennhan=icd_nguyennhan.Text;
				s_icd_kemtheo=icd_kemtheo.Text;
				//}
				if (bHanhchinh && bAdmin)
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
			else 
			{
				MessageBox.Show(lan.Change_language_MessageText("Không tìm thấy mã bệnh nhân !"),s_msg);
				mabn2.Focus();
				return;
			}
		}

		private bool load_mabn()
		{
			bool ret=false;
            foreach (DataRow r in m.get_data("select * from " + user + ".btdbn where mabn='" + s_mabn + "'").Tables[0].Rows)
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
					}
				}
			}
			load_treeView();
			return ret;
		}

		private void ena_doituong(bool ena)
		{
			madoituong.Enabled=ena;
			tendoituong.Enabled=ena;
			sothe.Enabled=ena;
			denngay.Enabled=ena;
		}

		private void load_vv_maql(bool skip)
		{
			ena_but(true);
			emp_vv();
			emp_rv();
			ena_doituong(true);
            foreach (DataRow r in m.get_data("select * from " + user + ".benhandt where loaiba=1 and maql=" + l_maql).Tables[0].Rows)
			{
				if (!skip)
				{
					s_ngayvv=m.DateToString("dd/MM/yyyy HH:mm",DateTime.Parse(r["ngay"].ToString()));
                    ngayvv.Text = s_ngayvv.Substring(0, 10);
                    giovv.Text = s_ngayvv.Substring(11);
				}
                l_matd = long.Parse(r["mavaovien"].ToString());
				tendentu.SelectedValue=r["dentu"].ToString();
				tennhantu.SelectedValue=r["nhantu"].ToString();
				tendoituong.SelectedValue=r["madoituong"].ToString();
				madoituong.Text=r["madoituong"].ToString();
				lanthu.Text=r["lanthu"].ToString();
				sovaovien.Text=r["sovaovien"].ToString();
				cd_kkb.Text=r["chandoan"].ToString();
				icd_kkb.Text=r["maicd"].ToString();
				ena_doituong(false);
				if (!bAdmin) ena_but(false);
			}
			load_vv();
		}

		private bool load_vv_mabn()
		{
			l_maql=0;
			emp_vv();
			emp_rv();
			ena_doituong(true);
            foreach (DataRow r in m.get_data("select * from " + user + ".benhandt where loaiba=1 and mabn='" + s_mabn + "' order by ngay desc").Tables[0].Rows)
			{
                l_matd = long.Parse(r["mavaovien"].ToString());
				l_maql=long.Parse(r["maql"].ToString());
				s_ngayvv=m.DateToString("dd/MM/yyyy HH:mm",DateTime.Parse(r["ngay"].ToString()));
                ngayvv.Text = s_ngayvv.Substring(0, 10);
                giovv.Text = s_ngayvv.Substring(11);
				tendentu.SelectedValue=r["dentu"].ToString();
				tennhantu.SelectedValue=r["nhantu"].ToString();
				tendoituong.SelectedValue=r["madoituong"].ToString();
				madoituong.Text=r["madoituong"].ToString();
				lanthu.Text=r["lanthu"].ToString();
				sovaovien.Text=r["sovaovien"].ToString();
				cd_kkb.Text=r["chandoan"].ToString();
				icd_kkb.Text=r["maicd"].ToString();
				ena_doituong(false);
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
						s_noicap=r["mabv"].ToString();
						if (r["tungay"].ToString()!="")
							s_tungay=m.DateToString("dd/MM/yyyy",DateTime.Parse(r["tungay"].ToString()));
                        if (r["denngay"].ToString() != "")
                            denngay.Text = m.DateToString("dd/MM/yyyy", DateTime.Parse(r["denngay"].ToString()));
                        if (bSothe_ngay_huong)
                        {
                            if (r["ngay1"].ToString() != "")
                                ngay1 = m.DateToString("dd/MM/yyyy", DateTime.Parse(r["ngay1"].ToString()));
                            if (r["ngay2"].ToString() != "")
                                ngay2 = m.DateToString("dd/MM/yyyy", DateTime.Parse(r["ngay2"].ToString()));
                            if (r["ngay3"].ToString() != "")
                                ngay3 = m.DateToString("dd/MM/yyyy", DateTime.Parse(r["ngay3"].ToString()));
                        }                        
                        traituyen= int.Parse(r["traituyen"].ToString());
					}
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
                foreach (DataRow r in m.get_data("select * from " + user + ".noigioithieu where maql=" + l_maql).Tables[0].Rows)
				{
					cd_noichuyenden.Text=r["chandoan"].ToString();
					icd_noichuyenden.Text=r["maicd"].ToString();
					s_madstt=r["mabv"].ToString();			
				}
			}
			try
			{
                if (bTamthan) tdvh.Text = m.get_data("select vanhoa from " + user + ".tttamthan where maql=" + l_maql).Tables[0].Rows[0][0].ToString();
                else if (bBong) ngaybong.Text = m.get_data("select to_char(ngay,'dd/mm/yyyy hh24:mi') from " + user + ".ttbong where maql=" + l_maql).Tables[0].Rows[0][0].ToString();
				else if (bSankhoa)
				{
                    foreach (DataRow r in m.get_data("select * from " + user + ".cdsankhoa where maql=" + l_maql).Tables[0].Rows)
					{
						s_ngayde=m.DateToString("dd/MM/yyyy HH:mm",DateTime.Parse(r["ngay"].ToString()));
                        ngayde.Text = s_ngayde.Substring(0, 10);
                        giode.Text = s_ngayde.Substring(11);
						kiemsoat.Checked=(int.Parse(r["kiemsoat"].ToString())==1)?true:false;
						matb.Text=r["mataibien"].ToString();
						tentb.SelectedValue=matb.Text;
					}
				}
			}
			catch{}
			if (bNhapsoluutru) soluutru.Text=m.get_soluutru(l_maql).ToString();
			s_icd_noichuyenden=icd_noichuyenden.Text;
			s_icd_kkb=icd_kkb.Text;
			s_ngaybong=ngaybong.Text;
			s_ngayde=ngayde.Text+" "+giode.Text;
			load_treeView2();
			load_tuvong();
			load_phauthuat();
			load_thuthuat();
			load_baohiem();
			load_tainantt();
			if (bSankhoa) load_tresosinh();
		}

		private bool load_vk(bool skip)
		{
			ena_but(true);
			bool ret=false;
            string sql = "select * from " + user + ".nhapkhoa where makp='" + s_makp + "' and maql=" + l_maql;
			if (skip) sql+=" and to_char(ngay,'dd/mm/yyyy hh24:mi')='"+ngayvk.Text+" "+giovk.Text+"'";
			sql+=" order by ngay desc";
			foreach(DataRow r in m.get_data(sql).Tables[0].Rows)
			{
				l_id=long.Parse(r["id"].ToString());
				if (!skip)
				{
					s_ngayvk=m.DateToString("dd/MM/yyyy HH:mm",DateTime.Parse(r["ngay"].ToString()));
                    ngayvk.Text = s_ngayvk.Substring(0, 10);
                    giovk.Text = s_ngayvk.Substring(11);
				}
				tuoi.Text=r["tuoivao"].ToString().Substring(0,3);
				loaituoi.SelectedIndex=int.Parse(r["tuoivao"].ToString().Substring(3,1));
				cd_vaokhoa.Text=r["chandoan"].ToString();
				icd_vaokhoa.Text=r["maicd"].ToString();
				giuong.Text=r["giuong"].ToString();
				tenkp.SelectedValue=r["khoachuyen"].ToString();
				ret=true;
				if (!bAdmin) ena_but(false);
				break;
			}
			if (ret && bUngbuou)
			{
                foreach (DataRow r in m.get_data("select * from " + user + ".cdungbuou where id=" + l_id).Tables[0].Rows)
				{
					t_v.Text=r["t_v"].ToString();
					n_v.Text=r["n_v"].ToString();
					m_v.Text=r["m_v"].ToString();
					giaidoan_v.Text=r["giaidoan_v"].ToString();
					break;
				}
			}
			s_icd_vaokhoa=icd_vaokhoa.Text;
			return ret;
		}

		private void load_rk()
		{
			ena_but(true);
            foreach (DataRow r in m.get_data("select * from " + user + ".xuatkhoa where id=" + l_id).Tables[0].Rows)
			{
				s_ngayrk=m.DateToString("dd/MM/yyyy HH:mm",DateTime.Parse(r["ngay"].ToString()));
                ngayrv.Text = s_ngayrk.Substring(0, 10);
                giorv.Text = s_ngayrk.Substring(11);
				songaydt.Text=m.songay(m.StringToDate(ngayrv.Text.Substring(0,10)),m.StringToDate(ngayvk.Text.Substring(0,10)),(tenkp.SelectedValue.ToString()=="01")?1:0).ToString();
				tenketqua.SelectedValue=r["ketqua"].ToString();
				cd_chinh.Text=r["chandoan"].ToString();
				icd_chinh.Text=r["maicd"].ToString();
                mabs.Text = r["mabs"].ToString();
                mabs_Validated(null, null);
				tenttlucrv.SelectedValue=r["ttlucrk"].ToString();
                ttlucrv.Tag = r["ttlucrk"].ToString();
				bienchung.Checked=int.Parse(r["bienchung"].ToString())==1;
				taibien.Checked=int.Parse(r["taibien"].ToString())!=0;
				if (taibien.Checked) cmbTaibien.SelectedValue=int.Parse(r["taibien"].ToString());
				giaiphau.Checked=int.Parse(r["giaiphau"].ToString())!=0;
				if (giaiphau.Checked) gphaubenh.SelectedValue=int.Parse(r["giaiphau"].ToString());
				if (!bAdmin) ena_but(false);
			}			
			if (ngayrv.Text!="")
			{
                foreach (DataRow r in m.get_data("select * from " + user + ".cdnguyennhan where id=" + l_id).Tables[0].Rows)
				{
					cd_nguyennhan.Text=r["chandoan"].ToString();
					icd_nguyennhan.Text=r["maicd"].ToString();
				}

                foreach (DataRow r in m.get_data("select * from " + user + ".cdkemtheo where loai=3 and id=" + l_id + " order by stt").Tables[0].Rows)
				{
					cd_kemtheo.Text=r["chandoan"].ToString();
					icd_kemtheo.Text=r["maicd"].ToString();
					break;
				}
				if (loaibv.Enabled)
				{
                    foreach (DataRow r in m.get_data("select * from " + user + ".chuyenvien where maql=" + l_maql).Tables[0].Rows)
					{
						tenloaibv.SelectedValue=r["loaibv"].ToString();
						mabv.Text=r["mabv"].ToString();
						load_mabv(loaibv.Text);
						tenbv.SelectedValue=mabv.Text;
						s_mabv=mabv.Text;
					}
				}
				if (bUngbuou)
				{
                    foreach (DataRow r in m.get_data("select * from " + user + ".cdungbuou where id=" + l_id).Tables[0].Rows)
					{
						t_r.Text=r["t_r"].ToString();
						n_r.Text=r["n_r"].ToString();
						m_r.Text=r["m_r"].ToString();
						giaidoan_r.Text=r["giaidoan_r"].ToString();
						break;
					}
				}
                if (ttlucrv.Text == "5")
                {
                    tenkhoaden.SelectedValue = m.get_khoaden(l_id);
                    khoadens = tenkhoaden.SelectedValue.ToString();
                }
				try
				{
                    if (bLuutru_Mabn) soluutru.Text=mabn2.Text+mabn3.Text;
					else if (bSoluutru_sovaovien) soluutru.Text=sovaovien.Text;
                    else soluutru.Text = m.get_data("select soluutru from " + user + ".xuatvien where maql=" + l_maql).Tables[0].Rows[0][0].ToString();
				}
				catch{}
			}
			else
			{
                string s = m.Ngaygio;
                ngayrv.Text = s.Substring(0, 10);
                giorv.Text = s.Substring(11);
			}
			s_icd_chinh=icd_chinh.Text;
			s_icd_nguyennhan=icd_nguyennhan.Text;
			s_icd_kemtheo=icd_kemtheo.Text;
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
					MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập thêm giờ sinh !"),s_msg);
					ngaysinh.Focus();
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

		private void frmXuatkhoa_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.F3:
					l_thuoc_Click(sender,e);
					break;
				case Keys.F5:
					l_thuthuat_Click(sender,e);
					break;
				case Keys.F6:
					l_phauthuat_Click(sender,e);
					break;
				case Keys.F7:
					l_tresosinh_Click(sender,e);
					break;
				case Keys.F8:
					l_tuvong_Click(sender,e);
					break;
				case Keys.F9:
					l_tainantt_Click(sender,e);
					break;
				case Keys.F10:
					butKetthuc_Click(sender,e);
					break;
                case Keys.F11:
                    toolStripButton10_Click(sender, e);
                    break;
			}
			if (e.Control)
			{
				switch (e.KeyCode)
				{
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
				SendKeys.Send("{Tab}");
			}
		}

		private void tendentu_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				dentu.Text=tendentu.SelectedValue.ToString();
				if (m.bChandoan && bHanhchinh) cd_noichuyenden.Enabled=dentu.Text=="1";
				if (bHanhchinh) icd_noichuyenden.Enabled=dentu.Text=="1";
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
					mabv.Enabled=so.Substring(3,1)=="1";
					tenbv.Enabled=mabv.Enabled;
				}
				catch
				{
					if (bSosinh) tendoituong.SelectedValue="3";
					else tendoituong.SelectedIndex=0;
				}
			}
		}

		private void load_bhyt()
		{
			string so=m.sothe(int.Parse(tendoituong.SelectedValue.ToString()));
			if (int.Parse(so.Substring(0,2))>0 && ngayvv.Text!="")
			{
				s_mabn=mabn2.Text+mabn3.Text;
                if (so.Substring(2, 1) == "1" && bDenngay_sothe)
                    sql = "select * from " + user + ".bhyt where mabn='" + s_mabn + "' and denngay>=to_timestamp('" + ngayvv.Text.Substring(0, 10) + "','" + m.f_ngay + "')" + " order by maql desc";
                else
                    sql = "select * from " + user + ".bhyt where mabn='" + s_mabn + "' order by maql desc";
				foreach(DataRow r in m.get_data(sql).Tables[0].Rows)
				{
					sothe.Text=r["sothe"].ToString();
					if (so.Substring(3,1)=="1") mabv.Text=r["mabv"].ToString();
					s_noicap=r["mabv"].ToString();
                    if (r["tungay"].ToString() != "")
                        s_tungay = m.DateToString("dd/MM/yyyy", DateTime.Parse(r["tungay"].ToString()));
                    if (r["denngay"].ToString() != "")
                        denngay.Text = m.DateToString("dd/MM/yyyy", DateTime.Parse(r["denngay"].ToString()));
                    if (bSothe_ngay_huong)
                    {
                        if (r["ngay1"].ToString() != "")
                            ngay1 = m.DateToString("dd/MM/yyyy", DateTime.Parse(r["ngay1"].ToString()));
                        if (r["ngay2"].ToString() != "")
                            ngay2 = m.DateToString("dd/MM/yyyy", DateTime.Parse(r["ngay2"].ToString()));
                        if (r["ngay3"].ToString() != "")
                            ngay3 = m.DateToString("dd/MM/yyyy", DateTime.Parse(r["ngay3"].ToString()));
                    }
                    traituyen = int.Parse(r["traituyen"].ToString());
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
                        if (so.Substring(3, 1) == "1") s_noicap = r["mabv"].ToString();
                        s_noicap = r["mabv"].ToString();
                        if (r["tungay"].ToString() != "")
                            s_tungay = m.DateToString("dd/MM/yyyy", DateTime.Parse(r["tungay"].ToString()));
                        if (r["denngay"].ToString() != "")
                            denngay.Text = m.DateToString("dd/MM/yyyy", DateTime.Parse(r["denngay"].ToString()));
                        if (bSothe_ngay_huong)
                        {
                            if (r["ngay1"].ToString() != "")
                                ngay1 = m.DateToString("dd/MM/yyyy", DateTime.Parse(r["ngay1"].ToString()));
                            if (r["ngay2"].ToString() != "")
                                ngay2 = m.DateToString("dd/MM/yyyy", DateTime.Parse(r["ngay2"].ToString()));
                            if (r["ngay3"].ToString() != "")
                                ngay3 = m.DateToString("dd/MM/yyyy", DateTime.Parse(r["ngay3"].ToString()));
                        }
                        traituyen = int.Parse(r["traituyen"].ToString());
                        break;
                    }
                }
			}
			else
			{
				s_tungay=ngay1=ngay2=ngay3=sothe.Text=denngay.Text="";
                s_noicap = m.Mabv; traituyen = 0;
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

		private void tenbs_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up) listBS.Focus();
            else if (e.KeyCode == Keys.Enter)
            {
                if (listBS.Visible) listBS.Focus();
                else SendKeys.Send("{Tab}{Home}");
            }
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
				pkhoaden.Visible=ttlucrv.Text=="5";
                if (!bLuutru_Mabn && !bSoluutru_icd10 && !bSoluutru && !bSoluutru_sovaovien) soluutru.Enabled = !pkhoaden.Visible;
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
				if ((quanhe.Text=="Mẹ") && (ss_hoten_me.Text!="" || nhi_hoten_me.Text!=""))
					qh_hoten.Text=(ss_hoten_me.Visible)?ss_hoten_me.Text:nhi_hoten_me.Text;
				else if ((quanhe.Text=="Bố") && (ss_hoten_bo.Text!="" || nhi_hoten_bo.Text!=""))
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
                    //dllDanhmucMedisoft.frmDMICD10 f = new dllDanhmucMedisoft.frmDMICD10(m, "icd10", icd_kkb.Text, cd_kkb.Text, true);
                    //f.ShowDialog();
                    //if (f.mICD!="")
                    //{
                    //    cd_kkb.Text=f.mTen;
                    //    icd_kkb.Text=f.mICD;
                    //}
				}
				s_icd_kkb=icd_kkb.Text;
			}
		}

		private void cd_vaokhoa_Validated(object sender, System.EventArgs e)
		{
			if (icd_vaokhoa.Text=="") icd_vaokhoa.Text=m.get_cicd10(cd_vaokhoa.Text);
			if (!m.bMaicd(icd_vaokhoa.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Mã ICD10 này không có trong danh mục !"),s_msg);
				icd_vaokhoa.Text="";
				icd_vaokhoa.Focus();
			}
		}

		private void icd_vaokhoa_Validated(object sender, System.EventArgs e)
		{
			if (icd_vaokhoa.Text!=s_icd_vaokhoa)
			{
				if (icd_vaokhoa.Text=="") cd_vaokhoa.Text="";
				else cd_vaokhoa.Text=m.get_vviet(icd_vaokhoa.Text);
				if (cd_vaokhoa.Text=="" && icd_vaokhoa.Text!="")
				{
                    //dllDanhmucMedisoft.frmDMICD10 f = new dllDanhmucMedisoft.frmDMICD10(m, "icd10", icd_vaokhoa.Text, cd_vaokhoa.Text, true);
                    //f.ShowDialog();
                    //if (f.mICD!="")
                    //{
                    //    cd_vaokhoa.Text=f.mTen;
                    //    icd_vaokhoa.Text=f.mICD;
                    //}
				}
				s_icd_vaokhoa=icd_vaokhoa.Text;
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
                    //dllDanhmucMedisoft.frmDMICD10 f = new dllDanhmucMedisoft.frmDMICD10(m, "icd10", icd_chinh.Text, cd_chinh.Text, true);
                    //f.ShowDialog();
                    //if (f.mICD!="")
                    //{
                    //    cd_chinh.Text=f.mTen;
                    //    icd_chinh.Text=f.mICD;
                    //}
				}
				s_icd_chinh=icd_chinh.Text;
			}
		}

		private void cd_nguyennhan_Validated(object sender, System.EventArgs e)
		{
			if (icd_nguyennhan.Text=="") icd_nguyennhan.Text=m.get_cicd10(cd_nguyennhan.Text);
			if (!m.bMaicd(icd_nguyennhan.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Mã ICD10 này không có trong danh mục !"),s_msg);
				icd_nguyennhan.Text="";
				icd_nguyennhan.Focus();
			}
		}

		private void icd_nguyennhan_Validated(object sender, System.EventArgs e)
		{
			if (icd_nguyennhan.Text!=s_icd_nguyennhan)
			{
				if (icd_nguyennhan.Text=="") cd_nguyennhan.Text="";
				else cd_nguyennhan.Text=m.get_vviet(icd_nguyennhan.Text);
				if (cd_nguyennhan.Text=="" && icd_nguyennhan.Text!="")
				{
                    //dllDanhmucMedisoft.frmDMICD10 f = new dllDanhmucMedisoft.frmDMICD10(m, "icd10", icd_nguyennhan.Text, cd_nguyennhan.Text, true);
                    //f.ShowDialog();
                    //if (f.mICD!="")
                    //{
                    //    cd_nguyennhan.Text=f.mTen;
                    //    icd_nguyennhan.Text=f.mICD;
                    //}
				}
				s_icd_nguyennhan=icd_nguyennhan.Text;
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
                    denngay.Text = m.Ktngaygio(denngay.Text, 10);
                    if (!m.bNgay(denngay.Text, ngayvk.Text))
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Ngày hết hạn không được nhỏ hơn ngày vào khoa!"), s_msg);
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
			l_maql=0;
            l_matd = 0;
			l_id=0;
			b_Edit=false;
			tentinh.SelectedValue=m.Mabv.Substring(0,3);
			tendantoc.SelectedValue="25";
			tennuoc.SelectedValue="VN";
			treeView1.Nodes.Clear();
			treeView2.Nodes.Clear();
			//chuyenkhoa.Checked=false;
			//l_chuyenkhoa.ForeColor=Color.FromArgb(0,0,255);
			//ref_check();
			load_quan();
			load_pxa();
			emp_vv();
			emp_bhyt();
			emp_rv();
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
			else if (bUngbuou)
			{
				t_v.Text="";
				n_v.Text="";
				m_v.Text="";
				giaidoan_v.Text="";
				t_r.Text="";
				n_r.Text="";
				m_r.Text="";
				giaidoan_r.Text="";
			}
			tdvh.Text="";
			ngaybong.Text="";
			s_ngaybong="";
		}

		private void emp_bhyt()
		{
			s_tungay=ngay1=ngay2=ngay3=sothe.Text=denngay.Text="";
            s_noicap = m.Mabv; traituyen = 0;
		}

		private void emp_vv()
		{
			string s=m.Ngaygio;
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
			cd_noichuyenden.Text="";
			icd_noichuyenden.Text="";
			cd_kkb.Text="";
			icd_kkb.Text="";
			s_icd_noichuyenden="";
			s_icd_kkb="";
			s_madstt=m.Mabv;
			if (bSankhoa)
			{
				ngayde.Text="";
                giode.Text = "";
				s_ngayde="";
				matb.Text="";
				tentb.SelectedIndex=-1;
				kiemsoat.Checked=false;
			}
			para1.Text="";para2.Text="";para3.Text="";para4.Text="";
		}

		private void emp_rv()
		{
			ngayvk.Text=ngayvv.Text;
            giovk.Text = giovv.Text;
			s_ngayvk="";//ngayvk.Text;
			s_ngayrk="";
			cd_vaokhoa.Text="";
			icd_vaokhoa.Text="";
            ngayrv.Text = ""; giorv.Text = "";
			songaydt.Text="";
			cd_chinh.Text="";
			icd_chinh.Text="";
			cd_nguyennhan.Text="";
			icd_nguyennhan.Text="";
			cd_kemtheo.Text="";
			icd_kemtheo.Text="";
			bienchung.Checked=false;
			taibien.Checked=false;
			giaiphau.Checked=false;
            if (!bLuutru_Mabn) soluutru.Text="";
			else if (bSoluutru_sovaovien) soluutru.Text=sovaovien.Text;
			else soluutru.Text=mabn2.Text+mabn3.Text;
			giuong.Text="";
            mabs.Text = "";
            tenbs.Text = "";
			tenketqua.SelectedIndex=-1;
			tenttlucrv.SelectedIndex=-1;
            ttlucrv.Tag = "";
			tenloaibv.SelectedIndex=-1;
			tenbv.SelectedIndex=-1;
			tenkhoaden.SelectedIndex=-1;
			khoadens=s_icd_vaokhoa="";
			s_icd_chinh="";
			s_icd_nguyennhan="";
			s_icd_kemtheo="";
			s_mabv="";
		}

		private void butTiep_Click(object sender, System.EventArgs e)
		{
			emp_text(false);
			enable_xuatkhoa(true);
			butVienphi.Enabled=false;
			mabn2.Focus();
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
			if (!phai.Enabled && bHanhchinh) phai.SelectedIndex=1;

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

            if (icd_chinh.Text == "" && cd_chinh.Text != "") icd_chinh.Text = u00;
            if (icd_kkb.Text == "" && cd_kkb.Text != "") icd_kkb.Text = u00;
            if (icd_vaokhoa.Text == "" && cd_vaokhoa.Text != "") icd_vaokhoa.Text = u00;
            if (icd_noichuyenden.Text == "" && cd_noichuyenden.Text != "") icd_noichuyenden.Text = u00;
            if (icd_kemtheo.Text == "" && cd_kemtheo.Text != "") icd_kemtheo.Text = u00;

			if (dentu.Text=="1")
			{
				if (icd_noichuyenden.Text=="" && cd_noichuyenden.Text!="")
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
				if (bChandoan_kemtheo && !m.Kiemtra_maicd(dticd,icd_noichuyenden.Text))
				{
					MessageBox.Show(lan.Change_language_MessageText("Mã ICD không hợp lệ !"),LibMedi.AccessData.Msg);
					icd_noichuyenden.Focus();
					return false;
				}
                if (bChandoan_kemtheo && !m.Kiemtra_tenbenh(dticd, cd_noichuyenden.Text))
				{
					MessageBox.Show(lan.Change_language_MessageText("Chẩn đoán không hợp lệ !"),LibMedi.AccessData.Msg);
					cd_noichuyenden.Focus();
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
					if (sothe.Text=="" && sothe.Enabled)
					{
						sothe.Focus();
						return false;
					}
					if (so.Substring(2,1)=="1" && denngay.Text=="" && denngay.Enabled)
					{
						denngay.Focus();
						return false;
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
			if (icd_vaokhoa.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập mã ICD vào khoa điều trị !"),s_msg);
				icd_vaokhoa.Focus();
				return false;
			}

			if (cd_vaokhoa.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập chẩn đoán vào khoa điều trị !"),s_msg);
				if (cd_vaokhoa.Enabled) cd_vaokhoa.Focus();
				else icd_vaokhoa.Focus();
				return false;
			}
			if (!m.Kiemtra_maicd(dticd,icd_vaokhoa.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Mã ICD không hợp lệ !"),LibMedi.AccessData.Msg);
				icd_vaokhoa.Focus();
				return false;
			}
			if (!m.Kiemtra_tenbenh(dticd,cd_vaokhoa.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Chẩn đoán không hợp lệ !"),LibMedi.AccessData.Msg);
				cd_vaokhoa.Focus();
				return false;
			}
			if (ngayrv.Text!="")
			{
                if (bKiemtra && tenttlucrv.SelectedValue.ToString() != "5")
                {
                    string s_mmyy = "", s_ngay = m.ngayhienhanh_server, _ngaythuoc = s_ngay;
                    DataSet dstmp;
                    DataTable tmp;

                    sql = "select mmyy from " + user + ".table ";
                    sql += " order by substr(mmyy,3,2) desc,substr(mmyy,1,2) desc";
                    tmp = d.get_data(sql).Tables[0];
                    
                    if (tmp.Rows.Count >= 0) s_mmyy = tmp.Rows[0][0].ToString();
                    else s_mmyy = s_ngay.Substring(3, 2) + s_ngay.Substring(8, 2);

                    if (m.bMmyy(s_mmyy) == false) s_mmyy = m.mmyy(m.ngayhienhanh_server.Substring(0, 10));
                    sql = "select to_char(ngay,'dd/mm/yyyy hh24:mi') as ngay from " + user + s_mmyy + ".d_tienthuoc where mabn='" + s_mabn + "' and maql=" + l_maql + " order by ngay desc";
                    dstmp = m.get_data(sql);
                    if (dstmp!=null && dstmp.Tables.Count>0 && dstmp.Tables[0].Rows.Count > 0)
                    {
                        DataTable tmp1;
                        decimal sl = 0;
                        foreach (DataRow r1 in dstmp.Tables[0].Rows)
                        {
                            if (_ngaythuoc != dstmp.Tables[0].Rows[0]["ngay"].ToString())
                            {
                                _ngaythuoc = dstmp.Tables[0].Rows[0]["ngay"].ToString();
                                sql = "select sum(soluong) as soluong from " + user + s_mmyy + ".d_tienthuoc where mabn='" + s_mabn + "' and maql=" + l_maql + " and to_char(ngay,'dd/mm/yyyy')='" + r1["ngay"].ToString().Substring(0, 10) + "'";
                                tmp1 = m.get_data(sql).Tables[0];
                                sl = (tmp1.Rows[0]["soluong"].ToString() != null) ? decimal.Parse(tmp1.Rows[0]["soluong"].ToString()) : 0;
                                if (sl != 0) break;
                            }
                        }
                        if (!m.bNgaygio(ngayrv.Text + " " + giorv.Text, _ngaythuoc) && sl != 0)
                        {
                            MessageBox.Show(lan.Change_language_MessageText("Ngày giờ ra viện không hợp lệ")+" \n"+"So với ngày duyệt thuốc là :" + tmp.Rows[0]["ngay"].ToString().Substring(0, 10), LibMedi.AccessData.Msg);
                            ngayrv.Focus();
                            return false;
                        }
                    }
                }
				if (tenketqua.SelectedIndex==-1 || ketqua.Text=="")
				{
					MessageBox.Show(lan.Change_language_MessageText("Nhập kết quả điều trị !"),s_msg);
					ketqua.Focus();
					return false;
				}

				if (tenttlucrv.SelectedIndex==-1 || ttlucrv.Text=="")
				{
					MessageBox.Show(lan.Change_language_MessageText("Nhập tình trạng ra khoa !"),s_msg);
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
                if (bChandoan_kemtheo && !m.Kiemtra_maicd(dticd, icd_kemtheo.Text))
				{
					MessageBox.Show(lan.Change_language_MessageText("Mã ICD không hợp lệ !"),LibMedi.AccessData.Msg);
					icd_kemtheo.Focus();
					return false;
				}
                if (bChandoan_kemtheo && !m.Kiemtra_tenbenh(dticd, cd_kemtheo.Text))
				{
					MessageBox.Show(lan.Change_language_MessageText("Chẩn đoán không hợp lệ !"),LibMedi.AccessData.Msg);
					cd_kemtheo.Focus();
					return false;
				}
				if (icd_nguyennhan.Text=="" && cd_nguyennhan.Text!="")
				{
					MessageBox.Show(lan.Change_language_MessageText("Nhập mã ICD nguyên nhân !"),s_msg);
					icd_nguyennhan.Focus();
					return false;
				}
				else if (cd_nguyennhan.Text=="" && icd_nguyennhan.Text!="")
				{
					MessageBox.Show(lan.Change_language_MessageText("Nhập chẩn đoán nguyên nhân !"),s_msg);
					if (cd_nguyennhan.Enabled) cd_nguyennhan.Focus();
					else icd_nguyennhan.Focus();
					return false;
				}
                if (bChandoan_nguyennhan && !m.Kiemtra_maicd(dticd, icd_nguyennhan.Text))
				{
					MessageBox.Show(lan.Change_language_MessageText("Mã ICD không hợp lệ !"),LibMedi.AccessData.Msg);
					icd_nguyennhan.Focus();
					return false;
				}
                if (bChandoan_nguyennhan && !m.Kiemtra_tenbenh(dticd, cd_nguyennhan.Text))
				{
					MessageBox.Show(lan.Change_language_MessageText("Chẩn đoán không hợp lệ !"),LibMedi.AccessData.Msg);
					cd_nguyennhan.Focus();
					return false;
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
				else if (ttlucrv.Text=="5" && (tenkhoaden.SelectedIndex==-1 || khoaden.Text=="")) 
				{
					MessageBox.Show(lan.Change_language_MessageText("Nhập khoa đến !"),s_msg);
					khoaden.Focus();
					return false;
				}
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
			string s_tenkp=bHiendien(l_maql, s_makp);
			if (s_tenkp!="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân đang hiện diện trong khoa {")+s_tenkp.Trim().ToUpper()+"}"+"\n"+lan.Change_language_MessageText("Không thể xuất khoa cho Bệnh nhân này thêm lần nữa!"),s_msg);
				butBoqua_Click(null,null);
				return false;
			}
            if (!b101204)
            {
                if (tenttlucrv.SelectedValue.ToString() == "5" && !m.bThanhtoan_ndot && !bThanhtoan_khoa)
                {
                    if (m.get_thvpll(ngayrv.Text + " " + giorv.Text, l_maql,ngayvk.Text+" "+giovk.Text))
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Người bệnh này đã chuyển số liệu xuống viện phí !") + "\n" + lan.Change_language_MessageText("Không thể xuất chuyển khoa được."), LibMedi.AccessData.Msg);
                        butBoqua_Click(null, null);
                        return false;
                    }
                }
            }
            l_maql = m.get_maql(1, s_mabn, s_makp, ngayvv.Text + " " + giovv.Text, true);
            if ((ttlucrv.Text == "5" || ttlucrv.Text == "8") && m.get_data("select * from " + user + ".xuatvien where maql=" + l_maql).Tables[0].Rows.Count > 0)
            {
                MessageBox.Show(lan.Change_language_MessageText("Người bệnh đã xuất viện không được sửa tình trạng !"), LibMedi.AccessData.Msg);
                ttlucrv.Focus();
                return false;
            }

            if ((ttlucrv.Tag.ToString() == "5" || ttlucrv.Tag.ToString() == "8") && m.get_data("select * from " + user + ".xuatvien where maql=" + l_maql).Tables[0].Rows.Count > 0)
            {
                MessageBox.Show(lan.Change_language_MessageText("Người bệnh đã xuất viện không được sửa tình trạng !"), LibMedi.AccessData.Msg);
                ttlucrv.Focus();
                return false;
            }
            if (ngayrv.Text != "" && (bSoluutru_icd10 || bSoluutru) && !(ttlucrv.Text == "5" || ttlucrv.Text == "8") && bSoluutru_xuatkhoa)
            {
                if (m.get_data("select * from "+user+".xuatvien where maql=" + l_maql).Tables[0].Rows.Count == 0)
                {
                    if (bSoluutru_icd10) soluutru.Text=m.get_soluutru(l_maql,icd_chinh.Text,ngayrv.Text);
					else soluutru.Text=m.get_soluutru_nam(ngayrv.Text);
                    soluutru.Update();
                }
            }

            if (ttlucrv.Text != "5")
            {
                if ((makp_chuyenkhoa != "" && makp_chuyenkhoa.IndexOf(s_makp) != -1))
                {
                    MessageBox.Show(s_tenkhoa + " không được cho người bệnh xuất viện !", LibMedi.AccessData.Msg);
                    return false;
                }
            }
            else if (khoadens!="" && khoadens!=khoaden.Text)
            {
                string s = "";
                foreach (DataRow r in m.get_data("select b.tenkp from " + user + ".nhapkhoa a," + user + ".btdkp_bv b where a.makp=b.makp and a.maql=" + l_maql + " and a.makp='" + khoadens + "' and to_char(a.ngay,'dd/mm/yyyy hh24:mi')='" + ngayrv.Text + " " + giorv.Text+"'").Tables[0].Rows)
                {
                    s = r["tenkp"].ToString();
                    break;
                }
                if (s != "")
                {
                    MessageBox.Show(lan.Change_language_MessageText("Khoa " + s + " đã nhập thông tin vào khoa !"), LibMedi.AccessData.Msg);
                    return false;
                }
            }
            if (!m.bNgaygio(ngayrv.Text + " " + giorv.Text, ngayvk.Text + " " + giovk.Text))
            {
                MessageBox.Show(lan.Change_language_MessageText("Ngày ra khoa không được nhỏ hơn ngày vào khoa !"), s_msg);
                ngayrv.Focus();
                return false;
            }
			return true;
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			if (!kiemtra()) return;
            string _mabs = mabs.Text;
			s_mabn=mabn2.Text+mabn3.Text;
            if (nam.IndexOf(m.mmyy(ngayvv.Text) + "+") == -1) nam = nam + m.mmyy(ngayvv.Text) + "+";
			if (!m.upd_btdbn(s_mabn,hoten.Text,ngaysinh.Text,namsinh.Text,phai.SelectedIndex,mann.Text,madantoc.Text,sonha.Text,thon.Text,cholam.Text,matt.Text,maqu1.Text+maqu2.Text,mapxa1.Text+mapxa2.Text,i_userid,nam))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin hành chính !"),s_msg);
				return;
			}
			//l_maql=m.get_maql(1,s_mabn,s_makp,ngayvv.Text+" "+giovv.Text,true);
			if (!m.upd_lienhe(l_maql,sonha.Text,thon.Text,cholam.Text,matt.Text,maqu1.Text+maqu2.Text,mapxa1.Text+mapxa2.Text,tuoi.Text.PadLeft(3,'0')+loaituoi.SelectedIndex.ToString(),0,0))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin hành chính !"),s_msg);
				return;
			}
			l_id=m.get_id(l_maql,s_makp,ngayvk.Text+" "+giovk.Text);
			if (tendoituong.SelectedValue.ToString()=="1")
			{
				if (!m.upd_bhyt(s_mabn,l_maql,sothe.Text,denngay.Text,s_noicap,0,s_tungay,ngay1,ngay2,ngay3,traituyen))
				{
					MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin bảo hiểm !"),s_msg);
					return;
				}
			}
			
			if (cd_noichuyenden.Text!="")
			{
				if (!m.upd_noigioithieu(l_maql,s_madstt,cd_noichuyenden.Text,icd_noichuyenden.Text))
				{
					MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin chuyển đến !"),s_msg);
					return;
				}
			}

			if (manuoc.Enabled && manuoc.Text!="") m.upd_nuocngoai(s_mabn,manuoc.Text);
			else m.execute_data("delete from "+user+".nuocngoai where mabn='"+s_mabn+"'");

			if (quanhe.Text!="") m.upd_quanhe(l_maql,quanhe.Text,qh_hoten.Text,qh_diachi.Text,qh_dienthoai.Text);
			if (ngayrv.Text!="")
			{
				if (tenttlucrv.SelectedValue.ToString()=="7" || tenketqua.SelectedValue.ToString()=="5") 
				{
					tenketqua.SelectedValue="5";
                    if (m.get_data("select * from " + user + ".tuvong where maql=" + l_maql).Tables[0].Rows.Count == 0)
						l_tuvong_Click(null,null);
				}
                int itable = m.tableid("","xuatkhoa");
                bool bUpdate = m.get_data("select * from " + user + ".xuatkhoa where id=" + l_id).Tables[0].Rows.Count > 0;
                if (bUpdate)
                {
                    m.upd_eve_tables(itable, i_userid, "upd");
                    m.upd_eve_upd_del(itable, i_userid, "upd", l_id.ToString() + "^" + ngayrv.Text + " " + giorv.Text + "^" + ketqua.Text + "^" + ttlucrv.Text + "^" + cd_chinh.Text + "^" + icd_chinh.Text + "^" + mabs.Text + "^" + ((bienchung.Checked) ? "1" : "0") + "^" + ((taibien.Checked) ? cmbTaibien.SelectedValue.ToString() : "0") + "^" + ((giaiphau.Checked) ? gphaubenh.SelectedValue.ToString() : "0") + "^" + i_userid.ToString());
                }
                else
                {
                    m.upd_eve_tables(itable, i_userid, "ins");
                    if (bPhonggiuong)
                    {
                        bool bPhongluuc = m.get_phongluu_nhapkhoa(l_maql);
                        itable = m.tableid("", "theodoigiuong");
                        decimal songay = 0,dongia=0;
                        int _madoituong = int.Parse(madoituong.Text),itunguyen=m.iTunguyen;
                        bool bQuahan = false;
                        string fie = "gia_th";
                        DataRow r2,r3;
                        foreach (DataRow r1 in m.get_data("select a.id,a.mavaovien,to_char(a.tu,'dd/mm/yyyy hh24:mi') as tu,a.dongia,a.idgiuong,a.madoituong,c.dichvu from "+user+".theodoigiuong a,"+user+".dmgiuong b,"+user+".dmphong c where a.idgiuong=b.id and b.idphong=c.id and a.idkhoa=" + l_id + " and a.soluong=0 and a.den is null").Tables[0].Rows)
                        {
                            if (bNgayra_ngayvao_1 && madoituong_giuongdichvu != 0) _madoituong = (r1["dichvu"].ToString() == "1") ? madoituong_giuongdichvu : int.Parse(r1["madoituong"].ToString());//int.Parse(madoituong.Text);
                            else _madoituong = int.Parse(r1["madoituong"].ToString());
                            bQuahan = madoituong.Text == "1";
                            if (bQuahan && denngay.Text != "") bQuahan = m.bNgay(ngayrv.Text,denngay.Text);
                            if (bQuahan)
                            {
                                songay = (bNgayra_ngayvao_1) ? m.songaygiuong(m.StringToDateTime(ngayrv.Text + " " + giorv.Text), m.StringToDateTime(r1["tu"].ToString()), 1, int.Parse(r1["idgiuong"].ToString())) : Math.Max(0, m.songay(m.StringToDateTime(ngayrv.Text), m.StringToDateTime(r1["tu"].ToString().Substring(0, 10)), (makp.Text == "01" && !bPhongluuc && (ngayvk.Text + " " + giovk.Text) == r1["tu"].ToString()) ? 1 : 0));
                                m.upd_theodoigiuong(long.Parse(r1["id"].ToString()), ngayrv.Text + " " + giorv.Text, _madoituong, songay);
                                songay = (bNgayra_ngayvao_1) ? m.songaygiuong(m.StringToDateTime(denngay.Text + " " + giorv.Text), m.StringToDateTime(r1["tu"].ToString()), 1, int.Parse(r1["idgiuong"].ToString())) : Math.Max(0, m.songay(m.StringToDateTime(denngay.Text), m.StringToDateTime(r1["tu"].ToString().Substring(0, 10)), (makp.Text == "01" && !bPhongluuc && (ngayvk.Text + " " + giovk.Text) == r1["tu"].ToString()) ? 1 : 0));
                                v.upd_vpkhoa(long.Parse(r1["id"].ToString()), s_mabn, long.Parse(r1["mavaovien"].ToString()), l_maql, l_id, denngay.Text + " " + giorv.Text, s_makp, _madoituong, int.Parse(r1["idgiuong"].ToString()), Convert.ToDecimal(songay), decimal.Parse(r1["dongia"].ToString()), 0, i_userid, 0);
                                dongia = decimal.Parse(r1["dongia"].ToString());
                                r2= m.getrowbyid(dtg, "id=" + long.Parse(r1["idgiuong"].ToString()));
                                if (r2 != null)
                                {
                                    r3 = m.getrowbyid(dtdt, "madoituong=" + itunguyen);
                                    if (r3 != null) fie = r3["field_gia"].ToString().Trim();
                                    dongia = decimal.Parse(r2[fie].ToString());
                                }
                                songay = (bNgayra_ngayvao_1) ? m.songaygiuong(m.StringToDateTime(ngayrv.Text + " " + giorv.Text), m.StringToDateTime(denngay.Text + " " + giorv.Text).AddDays(1), 1, int.Parse(r1["idgiuong"].ToString())) : Math.Max(0, m.songay(m.StringToDateTime(ngayrv.Text), m.StringToDateTime(denngay.Text.Substring(0, 10)).AddDays(1), (makp.Text == "01" && !bPhongluuc && (ngayvk.Text + " " + giovk.Text) == r1["tu"].ToString()) ? 1 : 0));
                                if (songay != 0)
                                {
                                    decimal _id = v.get_id_vpkhoa;
                                    v.upd_vpkhoa(_id, s_mabn, long.Parse(r1["mavaovien"].ToString()), l_maql, l_id, ngayrv.Text + " " + giorv.Text, s_makp, itunguyen, int.Parse(r1["idgiuong"].ToString()), Convert.ToDecimal(songay), dongia, 0, i_userid, 0);
                                }
                            }
                            else
                            {
                                songay = (bNgayra_ngayvao_1) ? m.songaygiuong(m.StringToDateTime(ngayrv.Text + " " + giorv.Text), m.StringToDateTime(r1["tu"].ToString()), 1, int.Parse(r1["idgiuong"].ToString())) : Math.Max(0, m.songay(m.StringToDateTime(ngayrv.Text), m.StringToDateTime(r1["tu"].ToString().Substring(0, 10)), (makp.Text == "01" && !bPhongluuc  && (ngayvk.Text + " " + giovk.Text) == r1["tu"].ToString()) ? 1 : 0));
                                m.upd_theodoigiuong(long.Parse(r1["id"].ToString()), ngayrv.Text + " " + giorv.Text, _madoituong, songay);
                                if (songay!=0) v.upd_vpkhoa(long.Parse(r1["id"].ToString()), s_mabn, long.Parse(r1["mavaovien"].ToString()), l_maql, l_id, ngayrv.Text + " " + giorv.Text, s_makp, _madoituong, int.Parse(r1["idgiuong"].ToString()), Convert.ToDecimal(songay), decimal.Parse(r1["dongia"].ToString()), 0, i_userid, 0);
                            }
                            m.execute_data("update "+user+".dmgiuong set soluong=soluong-1,tinhtrang=0 where id=" + int.Parse(r1["idgiuong"].ToString()));
                            m.upd_eve_tables(itable, i_userid, "upd");
                            m.upd_eve_upd_del(itable, i_userid, "upd", m.fields(user + ".theodoigiuong", "id=" + long.Parse(r1["id"].ToString())));
                        }
                    }
                }

                if (!m.upd_xuatkhoa(l_id, ngayrv.Text + " " + giorv.Text, int.Parse(ketqua.Text), int.Parse(ttlucrv.Text), cd_chinh.Text, icd_chinh.Text, mabs.Text, (bienchung.Checked) ? 1 : 0, (taibien.Checked) ? int.Parse(cmbTaibien.SelectedValue.ToString()) : 0, (giaiphau.Checked) ? int.Parse(gphaubenh.SelectedValue.ToString()) : 0, i_userid))
				{
					MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin ra khoa !"),s_msg);
					return;
				}
				if (ttlucrv.Text!="5")
				{
                    DataTable dt1 = m.get_data_nam_dec(nam, "select to_char(ngay,'dd/mm/yyyy hh24:mi') as ngay from xxx.pttt where maql=" + l_maql + " order by ngay desc,id desc").Tables[0];
                    if (dt1.Rows.Count != 0)
                    {
                        string s_ngaypt = dt1.Rows[0][0].ToString();
                        if (!m.bNgaygio(ngayrv.Text + " " + giorv.Text, s_ngaypt))
                        {
                            MessageBox.Show(lan.Change_language_MessageText("Ngày ra khoa không được nhỏ hơn ngày phẫu thuật - thủ thuật !") + "\n" + s_ngaypt, LibMedi.AccessData.Msg);
                            ngayrv.Focus();
                            return;
                        }
                    }
                    itable = m.tableid("","xuatvien");
                    if (m.get_data("select * from " + user + ".xuatvien where maql=" + l_maql).Tables[0].Rows.Count > 0)
                    {
                        m.upd_eve_tables(itable, i_userid, "upd");
                        m.upd_eve_upd_del(itable, i_userid, "upd", s_mabn + "^" + l_maql.ToString() + "^" + s_makp + "^" + ngayrv.Text + " " + giorv.Text + "^" + ketqua.Text + "^" + ttlucrv.Text + "^" + cd_chinh.Text + "^" + icd_chinh.Text + "^" + mabs.Text + "^" + soluutru.Text + "^" + ((bienchung.Checked) ? "1" : "0") + "^" + ((taibien.Checked) ? cmbTaibien.SelectedValue.ToString() : "0") + "^" +((giaiphau.Checked) ? gphaubenh.SelectedValue.ToString() : "0")+"^"+ i_userid.ToString());
                    }
                    else m.upd_eve_tables(itable, i_userid, "ins");
                    if (!m.upd_xuatvien(s_mabn, l_maql, s_makp, ngayrv.Text + " " + giorv.Text, int.Parse(ketqua.Text), int.Parse(ttlucrv.Text), cd_chinh.Text, icd_chinh.Text, mabs.Text, soluutru.Text, (bienchung.Checked) ? 1 : 0, (taibien.Checked) ? int.Parse(cmbTaibien.SelectedValue.ToString()) : 0, (giaiphau.Checked) ? int.Parse(gphaubenh.SelectedValue.ToString()) : 0, i_userid))
					{
						MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin ra viện !"),s_msg);
						return;
					}
					//binh
                    if (bUpdate) m.execute_data("delete from " + user + ".chuyenkhoa where id=" + l_id);
					delete_hiendien_do_chuyenkhoa(s_mabn,l_maql,s_makp);
					//
				}
				else
				{
                    if (!m.upd_chuyenkhoa(l_id, s_mabn, l_maql, s_makp, ngayrv.Text + " " + giorv.Text, khoaden.Text, cd_chinh.Text, icd_chinh.Text, i_userid))
					{
						MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin chuyển khoa !"),s_msg);
						return;
					}
					//binh: update hien dien truoc
                    if (m.get_id(l_maql, khoaden.Text, ngayrv.Text + " " + giorv.Text, false) == 0)
                    {
                        decimal id_new = 0;
                        id_new = get_id_hiendien_do_chuyenkhoa(s_mabn, l_maql, s_makp);
                        if (id_new <= 0)
                        {
                            m.execute_data("delete from " + user + ".hiendien where maql=" + l_maql + " and nhapkhoa=0 and xuatkhoa=0 and makp='" + khoaden.Text + "'");
                            id_new = m.getidyymmddhhmiss_stt_computer;//m.get_capid(2);
                        }
                        m.upd_hiendien(id_new, s_mabn, l_matd, l_maql, khoaden.Text, ngayvv.Text + " " + giovv.Text, ngayrv.Text + " " + giorv.Text, giuong.Text, mabs.Text, icd_chinh.Text, s_makp, 0, 0);
                        //
                    }
				}
				if (cd_nguyennhan.Text!="") m.upd_cdnguyennhan(l_id,l_maql,cd_nguyennhan.Text,icd_nguyennhan.Text);
				else m.execute_data("delete from "+user+".cdnguyennhan where id="+l_id);
				if (cd_kemtheo.Text!="") m.upd_cdkemtheo(l_id,l_maql,3,cd_kemtheo.Text,icd_kemtheo.Text,1);
                else m.execute_data("delete from " + user + ".cdkemtheo where stt=1 and loai=3 and id=" + l_id);
				if (loaibv.Enabled && loaibv.Text!="") m.upd_chuyenvien(l_maql,mabv.Text,int.Parse(loaibv.Text));
                else m.execute_data("delete from " + user + ".chuyenvien where maql=" + l_maql);
			}
			upd_khac();
			try
			{
                if (sovaovien.Text == "") sovaovien.Text = m.get_data("select sovaovien from " + user + ".benhandt where loaiba=1 and maql=" + l_maql).Tables[0].Rows[0][0].ToString();
			}
			catch{}
			enable_xuatkhoa(false);
			ena_but(false);
            if (bInravien_ravien)
            {
                if ((tenttlucrv.SelectedValue.ToString() != "5" && !m.bThanhtoan_ndot && !bTress_bame) || (bThanhtoan_khoa))
                {
                    if (m.get_thvpll(ngayrv.Text + " " + giorv.Text, l_maql, ngayvk.Text + " " + giovk.Text) == false)
                    {
                        if (m.get_data("select * from " + user + m.mmyy(ngayrv.Text) + ".d_thuocbhytll where nhom=" + m.nhom_duoc + " and done=0 and maql=" + l_maql).Tables[0].Rows.Count != 0)
                            MessageBox.Show(lan.Change_language_MessageText("Người bệnh có đơn thuốc về")+"\n"+lan.Change_language_MessageText("Chương trình không chuyển số liệu xuống viện phí")+"\n"+lan.Change_language_MessageText("Chờ dược phát sau đó in phiếu thanh toán !"), LibMedi.AccessData.Msg);
                        else 
                            butVienphi_Click(null, null);
                    }
                }
            }
            mabs.Text = _mabs;
            mabs_Validated(null, null);
			butTiep.Focus();
		}

		private void upd_khac()
		{
			if (bSosinh) m.upd_hcsosinh(s_mabn,ss_hoten_me.Text,ss_ns_me.Text,ss_mann_me.Text,int.Parse(ss_delan.Text),ss_hoten_bo.Text,ss_ns_bo.Text,ss_mann_bo.Text,int.Parse(ss_nhommau.SelectedValue.ToString()),para,mame.Text);
			else if (bBong && ngaybong.Text!="") m.upd_ttbong(l_maql,ngaybong.Text);
			else if (bTamthan && tdvh.Text!="") m.upd_tttamthan(l_maql,tdvh.Text);
			else if (bNhi) m.upd_hcnhi(s_mabn,nhi_hoten_bo.Text,nhi_vanhoa_bo.Text,nhi_mann_bo.Text,nhi_hoten_me.Text,nhi_vanhoa_me.Text,nhi_mann_me.Text);
			else if (bSankhoa && ngayde.Text!="" && giode.Text!="") m.upd_cdsankhoa(l_maql,ngayde.Text+" "+giode.Text,(kiemsoat.Checked)?1:0,matb.Text);
			else if (bUngbuou)
			{
				if (t_v.Text.Trim()+n_v.Text.Trim()+m_v.Text.Trim()+giaidoan_v.Text.Trim()!="")
					m.upd_cdungbuou(l_id,l_maql,t_v.Text.Trim(),n_v.Text.Trim(),m_v.Text.Trim(),giaidoan_v.Text.Trim(),0);
				if (ngayrv.Text!="" && t_r.Text.Trim()+n_r.Text.Trim()+m_r.Text.Trim()+giaidoan_r.Text.Trim()!="")
					m.upd_cdungbuou(l_id,l_maql,t_r.Text.Trim(),n_r.Text.Trim(),m_r.Text.Trim(),giaidoan_r.Text.Trim(),1);
			}
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
            foreach (DataRow r in m.get_data("select ngay,chandoan from " + user + ".benhandt where tuchoi=0 and loaiba=1 and mabn='" + s_mabn + "' order by ngay desc").Tables[0].Rows)
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
						if (load_vk(false)) load_rk();
                        ngayvv.Text = ngay.Substring(0, 10);
                        giovv.Text = ngay.Substring(11);
						load_treeView2();
					}
				}
				catch{}
			}
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
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
            l_maql = m.get_maql(1, s_mabn, s_makp, ngayvv.Text + " " + giovv.Text, false);
			if (l_maql==0)
			{
				if (!kiemtra()) return;
				butLuu_Click(null,null);
			}
            //frmTuvong f = new frmTuvong(m, s_mabn, hoten.Text, tuoi.Text.PadLeft(3, '0') + loaituoi.SelectedIndex.ToString(), ngayrv.Text + " " + giorv.Text, songaydt.Text, l_maql, i_userid);
            //f.ShowDialog();
            //load_tuvong();
		}

		private void l_phauthuat_Click(object sender, System.EventArgs e)
		{
			s_mabn=mabn2.Text+mabn3.Text;
            l_maql = m.get_maql(1, s_mabn, s_makp, ngayvv.Text + " " + giovv.Text, false);
			if (l_maql==0)
			{
				if (!kiemtra()) return;
				butLuu_Click(null,null);
			}
            //frmPttt f = new frmPttt(m, s_makp, s_mabn, hoten.Text, tuoi.Text.PadLeft(3, '0') + loaituoi.SelectedIndex.ToString(), phai.Text, sonha.Text.Trim() + " " + thon.Text, sothe.Text, giuong.Text, ngayvv.Text + " " + giovv.Text, cd_vaokhoa.Text, icd_vaokhoa.Text, "P", i_userid, ngayrv.Text + " " + giorv.Text, "", "",l_maql,l_matd,l_id,0,false);
            //f.ShowDialog();
			load_phauthuat();
		}

		private void l_thuthuat_Click(object sender, System.EventArgs e)
		{
            s_mabn = mabn2.Text + mabn3.Text;             
            l_maql = m.get_maql(1, s_mabn, s_makp, ngayvv.Text + " " + giovv.Text, false);
			if (l_maql==0)
			{                
				if (!kiemtra()) return;			                                
                butLuu_Click(null, null);
            }
            string adiachi = sonha.Text.Trim() + " " + thon.Text.Trim() + ", " + tenpxa.Text.Trim() + ", " + tenquan.Text.Trim() + ", " + tentinh.Text.Trim();
            adiachi = adiachi.Replace("Không xác định", "");
            if (bDanhmuc_nhathuoc)
            {
                string s_mmyy = (ngayrv.Text == "") ? m.mmyy(m.ngayhienhanh_server) : (ngayrv.Text.Substring(3, 2) + ngayrv.Text.Substring(8, 2));
                sql = "select mmyy from " + user + ".table order by substr(mmyy,3,2) desc,substr(mmyy,1,2) desc";
                DataTable dt = m.get_data(sql).Tables[0];
                foreach (DataRow r in dt.Rows)
                {
                    s_mmyy = r["mmyy"].ToString();
                    if (d.get_data("select a.* from " + user + s_mmyy + ".d_tonkhoth a," + user + ".d_dmkho b where a.makho=b.id and b.nhom=" + m.nhom_nhathuoc).Tables[0].Rows.Count > 0) break;
                }

                //frmBaohiem f = new frmBaohiem(false, s_mabn, 7, s_mmyy, ngayrv.Text + " " + giorv.Text, m.nhom_nhathuoc, i_userid, "Đơn thuốc", l_matd, l_maql, hoten.Text, namsinh.Text + "^" + ngaysinh.Text, sothe.Text, s_tenkhoa, tenbs.Text, (icd_chinh.Text.Trim() == "") ? icd_vaokhoa.Text.Trim() : icd_chinh.Text.Trim(), (cd_chinh.Text.Trim() == "") ? cd_vaokhoa.Text.Trim() : cd_chinh.Text.Trim(), 5, s_makp, mabs.Text, tendoituong.Text, cholam.Text, adiachi.Trim().Trim(','), nam, user + m.mmyy(ngayvv.Text) + ".bhyt", 1, s_noicap, false, "", ngayvv.Text + " " + giovv.Text, "", traituyen, ngay1, ngay2, ngay3);
                //f.ShowDialog(this);                
            }
            else
            {
                //frmToathuoc f2 = new frmToathuoc(m, s_mabn, hoten.Text, tuoi.Text + " " + loaituoi.Text, ngayrv.Text + " " + giorv.Text, s_makp, s_tenkhoa, mabs.Text, tenbs.Text, (cd_chinh.Text.Trim()=="")?cd_vaokhoa.Text.Trim():cd_chinh.Text.Trim(), (icd_chinh.Text.Trim()=="")?icd_vaokhoa.Text:icd_chinh.Text.Trim(), l_maql, i_userid, adiachi.Trim().Trim(','), nam);
                //f2.ShowDialog(this);                
            }
			/*
            s_mabn=mabn2.Text+mabn3.Text;
            l_maql = m.get_maql(1, s_mabn, s_makp, ngayvv.Text + " " + giovv.Text, false);
			if (l_maql==0)
			{
				if (!kiemtra()) return;
				butLuu_Click(null,null);
			}
            frmPttt f = new frmPttt(m, s_makp, s_mabn, hoten.Text, tuoi.Text.PadLeft(3, '0') + loaituoi.SelectedIndex.ToString(), phai.Text, sonha.Text.Trim() + " " + thon.Text, sothe.Text, giuong.Text, ngayvv.Text + " " + giovv.Text, cd_vaokhoa.Text, icd_vaokhoa.Text, "T", i_userid, ngayrv.Text + " " + giorv.Text, "", "",l_maql,l_matd,l_id,0);
			f.ShowDialog();
			load_thuthuat();		
            */
		}

		private void sovaovien_Validated(object sender, System.EventArgs e)
		{
			if (sovaovien.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập số vào viện !"),s_msg);
				sovaovien.Focus();
				return;
			}
//			if (m.blSovaovien(1,sovaovien.Text))
//			{
//				MessageBox.Show(lan.Change_language_MessageText("Số vào viện này đã có !"),s_msg);
//				sovaovien.Focus();
//				return;
//			}
		}

		private void tenkp_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				makp.Text=tenkp.SelectedValue.ToString();
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
                if (!m.bNgaygio(ngayvk.Text + " " + giovk.Text, ngaybong.Text))
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
			if (ss_para1.Text+ss_para2.Text+ss_para3.Text+ss_para4.Text=="00000000")
			{
				MessageBox.Show(lan.Change_language_MessageText("Tiền thai (Para) không hợp lệ !"),s_msg);
				ss_para1.Focus();
			}
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
			//				MessageBox.Show(lan.Change_language_MessageText("Nhập họ tên mẹ !",s_msg);
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

		private void kiemsoat_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{Home}");
		}

		private void l_tresosinh_Click(object sender, System.EventArgs e)
		{
			if (!bSankhoa) return;
			s_mabn=mabn2.Text+mabn3.Text;
			if (ngayde.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập ngày đẻ (mổ đẻ) !"),s_msg);
				ngayde.Focus();
				return;
			}
            l_maql = m.get_maql(1, s_mabn, s_makp, ngayvv.Text + " " + giovv.Text, false);
			if (l_maql==0)
			{
				if (!kiemtra()) return;
				butLuu_Click(null,null);
			}
            //frmTresosinh f=new frmTresosinh(m,s_mabn,hoten.Text,tuoi.Text.PadLeft(3,'0')+"T",l_maql,ngayde.Text+" "+giode.Text,i_userid,tentinh.SelectedValue.ToString(),tenquan.SelectedValue.ToString(),tenpxa.SelectedValue.ToString());
            //f.ShowDialog();
            //load_tresosinh();
		}

		private void khoaden_Validated(object sender, System.EventArgs e)
		{
			try
			{
				tenkhoaden.SelectedValue=khoaden.Text;
			}
			catch{}
		}

		private void khoaden_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{F4}");
		}

		private void tenkhoaden_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				if (tenkhoaden.SelectedIndex==-1) tenkhoaden.SelectedIndex=0;
				SendKeys.Send("{Tab}");		
			}
		}

		private void tenkhoaden_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				khoaden.Text=tenkhoaden.SelectedValue.ToString();
			}
			catch{khoaden.Text="";}
		}

		private void load_treeView2()
		{
			treeView2.Nodes.Clear();
			TreeNode node;
            foreach (DataRow r in m.get_data("select ngay,chandoan from " + user + ".nhapkhoa where makp='" + s_makp + "' and maql=" + l_maql + " order by ngay desc").Tables[0].Rows)
			{
				node=treeView2.Nodes.Add(m.DateToString("dd/MM/yyyy HH:mm",DateTime.Parse(r["ngay"].ToString())));
				node.Nodes.Add(r["chandoan"].ToString());
			}
		}

		private void treeView2_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			if (e.Action==TreeViewAction.ByMouse)
			{
				try
				{
					string s=e.Node.FullPath.Trim();
					int iPos=s.IndexOf("/");
					string ngay=s.Substring(iPos-2,16);
					s_mabn=mabn2.Text+mabn3.Text;
					emp_rv();
                    ngayvk.Text = ngay.Substring(0, 10);
                    giovk.Text = ngay.Substring(11);
					if (load_vk(true)) load_rk();
				}
				catch{}
			}
		}

		private void giaiphau_CheckStateChanged(object sender, System.EventArgs e)
		{
			gphaubenh.Visible=giaiphau.Checked;
		}

		private void l_tainantt_Click(object sender, System.EventArgs e)
		{
			s_mabn=mabn2.Text+mabn3.Text;
            l_maql = m.get_maql(1, s_mabn, s_makp, ngayvv.Text + " " + giovv.Text, false);
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
                if (bChandoan_kemtheo || icd_kkb.Text == "" || icd_kkb.Text.Trim() == u00)
				{
					Filt_ICD(cd_kkb.Text);
					listICD.BrowseToICD10(cd_kkb,icd_kkb,icd_vaokhoa,icd_kkb.Location.X-8,pvaovien.Location.Y+7*icd_kkb.Height+10,icd_kkb.Width+cd_kkb.Width+2,icd_kkb.Height);
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
					if (icd_kkb.Enabled) listICD.BrowseToICD10(cd_noichuyenden,icd_noichuyenden,icd_kkb,icd_kkb.Location.X-8,pvaovien.Location.Y+6*icd_noichuyenden.Height+8,icd_noichuyenden.Width+cd_noichuyenden.Width+2,icd_noichuyenden.Height);
					else listICD.BrowseToICD10(cd_noichuyenden,icd_noichuyenden,icd_vaokhoa,icd_kkb.Location.X-8,pvaovien.Location.Y+6*icd_noichuyenden.Height+8,icd_noichuyenden.Width+cd_noichuyenden.Width+2,icd_noichuyenden.Height);
				}
			}
		}

		private void cd_vaokhoa_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==cd_vaokhoa)
			{
                if (bChandoan || icd_vaokhoa.Text == "" || icd_vaokhoa.Text.Trim() == u00)
				{
					Filt_ICD(cd_vaokhoa.Text);
					if (bSankhoa) listICD.BrowseToICD10(cd_vaokhoa,icd_vaokhoa,ngayde,icd_kkb.Location.X-8,pvaovien.Location.Y+8*icd_kemtheo.Height+12,icd_kemtheo.Width+cd_kemtheo.Width+2,icd_kemtheo.Height);
					else if (bUngbuou) listICD.BrowseToICD10(cd_vaokhoa,icd_vaokhoa,t_v,icd_kkb.Location.X-8,pvaovien.Location.Y+8*icd_kemtheo.Height+12,icd_kemtheo.Width+cd_kemtheo.Width+2,icd_kemtheo.Height);
					else listICD.BrowseToICD10(cd_vaokhoa,icd_vaokhoa,ngayrv,icd_kkb.Location.X-8,pvaovien.Location.Y+8*icd_kemtheo.Height+12,icd_kemtheo.Width+cd_kemtheo.Width+2,icd_kemtheo.Height);
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
					if (bUngbuou)listICD.BrowseToICD10(cd_chinh,icd_chinh,t_r,icd_chinh.Location.X,icd_chinh.Location.Y+icd_chinh.Height,icd_chinh.Width+cd_chinh.Width+2,icd_chinh.Height);
					else if (icd_nguyennhan.Enabled) listICD.BrowseToICD10(cd_chinh,icd_chinh,icd_nguyennhan,icd_chinh.Location.X,icd_chinh.Location.Y+icd_chinh.Height,icd_chinh.Width+cd_chinh.Width+2,icd_chinh.Height);
					else listICD.BrowseToICD10(cd_chinh,icd_chinh,icd_kemtheo,icd_chinh.Location.X,icd_chinh.Location.Y+icd_chinh.Height,icd_chinh.Width+cd_chinh.Width+2,icd_chinh.Height);
				}
			}		
		}

		private void cd_nguyennhan_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==cd_nguyennhan)
			{
				if (bChandoan_nguyennhan || icd_nguyennhan.Text=="")
				{
					Filt_ICD(cd_nguyennhan.Text);
					listICD.BrowseToICD10(cd_nguyennhan,icd_nguyennhan,icd_kemtheo,icd_nguyennhan.Location.X,icd_nguyennhan.Location.Y+icd_nguyennhan.Height,icd_nguyennhan.Width+cd_nguyennhan.Width+2,icd_nguyennhan.Height);
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
				dv.RowFilter="vviet like '%"+ten.Trim()+"%'";
			}
			catch{}
		}

		private void tuoi_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			m.MaskDigit(e);
		}

		private void mame_Validated(object sender, System.EventArgs e)
		{
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
			if (mame.Text=="" || mame.Text.Trim().Length<3) return;
			if (mame.Text.Trim().Length!=8) mame.Text=mame.Text.Substring(0,2)+mame.Text.Substring(2).PadLeft(6,'0');
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
                    foreach(DataRow r1 in m.get_data("select id_nuoc from "+user+".nuocngoai where mabn='"+mame.Text+"'").Tables[0].Rows) tennuoc.SelectedValue=r1["id_nuoc"].ToString();
				break;
			}
			foreach(DataRow r in m.get_data("select * from "+user+".ttkhamthai where mabn='"+mame.Text+"' order by maql desc").Tables[0].Rows)
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
			if (ss_hoten_me.Text!="") ss_delan.Focus();
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
			if (bKhamthai && !bSosinh) khamthai.Visible=phai.SelectedIndex==1;		
		}
		#region Binh_dschuyenkhoa
		//Binh: delete thong tin chuyen khoa cua BN ma co update vao hiendien
		private void delete_hiendien_do_chuyenkhoa(string s_mabn, decimal s_maql, string s_noichuyen)
		{
			sql="select * from "+user+".hiendien where mabn='"+s_mabn+"' and maql="+s_maql+" and noichuyen='" +s_noichuyen+"' and nhapkhoa=0 and xuatkhoa=0 order by id desc";
			DataTable dt=m.get_data(sql).Tables[0];
			if(dt.Rows.Count>0)
			{
                sql = "delete from " + user + ".hiendien where id=" + dt.Rows[0]["id"].ToString();
				m.execute_data(sql);
			}
			dt.Dispose();
		}
		private decimal get_id_hiendien_do_chuyenkhoa(string s_mabn, decimal s_maql, string s_noichuyen)
		{
			decimal lid=0;
            sql = "select * from " + user + ".hiendien where mabn='" + s_mabn + "' and maql=" + s_maql + " and noichuyen='" + s_noichuyen + "' and nhapkhoa=0 and xuatkhoa=0 order by id desc";
			DataTable dt=m.get_data(sql).Tables[0];
			if(dt.Rows.Count>0)
			{
				lid=long.Parse(dt.Rows[0]["id"].ToString());				
			}
			dt.Dispose();
			return lid;
		}
		private string bHiendien(decimal m_maql, string s_makp)
		{
			try
			{
                return m.get_data("select trim(b.tenkp)||' '||to_char(a.ngay,'dd/mm/yyyy hh24:mi') from " + user + ".hiendien a," + user + ".btdkp_bv b where a.makp=b.makp and a.nhapkhoa=1 and a.xuatkhoa=0 and a.maql=" + m_maql + " and a.makp<>'" + s_makp + "'").Tables[0].Rows[0][0].ToString();
			}
			catch{return "";}
		}
		private void enable_xuatkhoa(bool ena)
		{
			ngayrv.Enabled=ena;
			//songaydt.Enabled=ena;			
			cd_chinh.Text="";
			icd_chinh.Enabled=ena;
			cd_nguyennhan.Enabled=ena;
			icd_nguyennhan.Enabled=ena;
			cd_kemtheo.Enabled=ena;
			icd_kemtheo.Enabled=ena;
			bienchung.Enabled=ena;
			taibien.Enabled=ena;
			giaiphau.Enabled=ena;
            if (!bLuutru_Mabn && !bSoluutru_icd10 && !bSoluutru) soluutru.Enabled = ena;
			giuong.Enabled=ena;
            tenbs.Text = "";
            mabs.Text = "";
			tenketqua.Enabled=ena;
			tenttlucrv.Enabled=ena;
			tenloaibv.Enabled=ena;
			tenbv.Enabled=ena;
			mabs.Enabled=tenbs.Enabled=tenkhoaden.Enabled=ena;
		}
		private bool Get_def_inttrv()
		{
			DataSet ds=new DataSet();
			ds.ReadXml("..//..//..//xml//d_def_inttrv.xml");
			if(ds.Tables[0].Rows[0]["def_inttrv"].ToString()=="0")return false;
			else return true;
		}

		#endregion	

		private void butVienphi_Click(object sender, System.EventArgs e)
		{
			if (ttlucrv.Text=="5" && !bThanhtoan_khoa) return;
			if (butLuu.Enabled)
			{
				MessageBox.Show(lan.Change_language_MessageText("Cập nhật thông tin ra khoa trước khi chuyển chi phí thanh toán !"),LibMedi.AccessData.Msg);
				return;
			}
            if (m.get_thvpll(ngayrv.Text + " " + giorv.Text, l_maql,ngayvk.Text+" "+giovk.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Đã chuyển chi phí thanh toán !"),LibMedi.AccessData.Msg);
				butTiep_Click(sender,e);
				return;
			}
            //Kiem tra BN nhieu the --> thi de nghi ra man hinh thanh toan ra vien de chuyen so lieu xuong vien phi
            string s_sothebhyt = m.get_sothe_thanhtoan(l_maql);
            if (s_sothebhyt.Trim().Trim(';').Split(';').Length > 1)
            {
                MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân này có '" + s_sothebhyt.Trim().Trim(';').Split(';').Length + " thẻ', vì vậy phải chuyển số liệu xuống thanh toán theo đợt.\nBạn vào menu 'Nội trú --> phiếu thanh toán ra viện' để chuyển xuống."),"Xuất khoa",MessageBoxButtons.OK,MessageBoxIcon.Information);
                butTiep.Focus();
                return;
            }
            //
            DataSet dsxml = m.get_thanhtoan(l_maql, l_id, ngayvv.Text + " " + giovv.Text, ngayrv.Text + " " + giorv.Text,1,m.bThanhtoan_khoa,s_userid,i_userid);
			string s_rpt="rptTtravien.rpt",title="PHIẾU THANH TOÁN RA VIỆN";
			if (m.bInthanhtoanchitiet)
			{
				s_rpt="rpt_ttravien_kp.rpt";
				title=m.get_tenkp(s_makp);
			}
			if (dsxml.Tables[0].Rows.Count>0)
			{
				if (chkIn.Checked)
				{
					dllReportM.frmReport f=new dllReportM.frmReport(m,dsxml,title,s_rpt,true);
					f.ShowDialog();
				}
				else MessageBox.Show(lan.Change_language_MessageText("Đã chuyển số liệu xuống phòng thanh toán."),lan.Change_language_MessageText("Xuất khoa"),MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
			}
			else MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),LibMedi.AccessData.Msg);
			butTiep_Click(sender,e);
		}
		
		private void chkIn_Click(object sender, System.EventArgs e)
		{
			m.writeXml("d_def_inttrv","def_inttrv",(chkIn.Checked)?"1":"0");
		}
	
		private void tentb_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (tentb.SelectedIndex==-1 && tentb.Items.Count>0) tentb.SelectedIndex=0;
				matb.Text=tentb.SelectedValue.ToString();
				SendKeys.Send("{Tab}");
			}
		}

		private void matb_Validated(object sender, System.EventArgs e)
		{
			try
			{
				tentb.SelectedValue=matb.Text;
			}
			catch{tentb.SelectedIndex=-1;}
		}

		private void matb_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void tentb_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tentb) matb.Text=tentb.SelectedValue.ToString();
		}

		private void l_thuoc_Click(object sender, System.EventArgs e)
		{
			if (ngayrv.Text=="") return;
			s_mabn=mabn2.Text+mabn3.Text;
            l_maql = m.get_maql(1, s_mabn, s_makp, ngayvv.Text + " " + giovv.Text, false);
			if (l_maql==0)
			{
				if (!kiemtra()) return;
				butLuu_Click(null,null);
			}
			LibDuoc.AccessData d=new LibDuoc.AccessData();
			string s_mmyy=ngayrv.Text.Substring(3,2)+ngayrv.Text.Substring(8,2);
			sql="select mmyy from "+user+".table order by substr(mmyy,3,2) desc,substr(mmyy,1,2) desc";
			DataTable dt=m.get_data(sql).Tables[0];
			foreach(DataRow r in dt.Rows)
			{
				s_mmyy=r["mmyy"].ToString();
                if (d.get_data( "select a.* from " + user + s_mmyy + ".d_tonkhoth a," + user + ".d_dmkho b where a.makho=b.id and b.nhom=" + m.nhom_duoc).Tables[0].Rows.Count > 0) break;
			}
            if (madoituong.Text != "1")
            {
                if (m.get_data("select * from " + user + ".d_dmphieu where id=6 and madoituong like '%" + madoituong.Text.Trim() + ",%'").Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Đối tượng ")+"\n" + tendoituong.Text + "\n"+lan.Change_language_MessageText("Không được cấp thuốc !"), LibMedi.AccessData.Msg);
                    return;
                }
            }
            string adiachi = sonha.Text.Trim() + " " + thon.Text.Trim() + ", " + tenpxa.Text.Trim() + ", " + tenquan.Text.Trim() + ", " + tentinh.Text.Trim();
            adiachi = adiachi.Replace("Không xác định", "");
            //frmBaohiem f = new frmBaohiem(false, s_mabn, (madoituong.Text == "1") ? 5 : 6, s_mmyy, ngayrv.Text + " " + giorv.Text, m.nhom_duoc, i_userid, "Đơn thuốc dược phát", l_matd, l_maql, hoten.Text, namsinh.Text + "^" + ngaysinh.Text, sothe.Text, s_tenkhoa, tenbs.Text, (icd_chinh.Text.Trim() == "") ? icd_vaokhoa.Text.Trim() : icd_chinh.Text.Trim(), (cd_chinh.Text.Trim() == "") ? cd_vaokhoa.Text.Trim() : cd_chinh.Text.Trim(), int.Parse(madoituong.Text), s_makp, mabs.Text, tendoituong.Text, cholam.Text, adiachi.Trim().Trim(','), nam, user + ".bhyt", 1, s_noicap, false, "", ngayvv.Text + " " + giovv.Text, "", traituyen, ngay1, ngay2, ngay3);
            //f.ShowDialog(this);
			load_baohiem();
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
            if (s_ngayvv.Trim().Length > 10)
            {
                if (ngayvv.Text != s_ngayvv.Substring(0,10) || cd_kkb.Text == "")
                {
                    try
                    {
                        if (namsinh.Text != m.Namsinh("", int.Parse(tuoi.Text), loaituoi.SelectedIndex).ToString())
                        {
                            tuoi.Text = Convert.ToString(int.Parse(ngayvv.Text.Substring(6, 4)) - int.Parse(namsinh.Text)).PadLeft(3, '0');
                            loaituoi.SelectedIndex = 0;
                        }
                    }
                    catch { }
                    if (!m.ngay(m.StringToDate(ngayvv.Text.Substring(0, 10)), DateTime.Now, songay))
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Ngày vào viện không hợp lệ so với khai báo hệ thống (") + songay.ToString() + ")!", s_msg);
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
            if (ngayvv.Text+" "+giovv.Text != s_ngayvv || cd_kkb.Text == "")
            {
                string s = ngayvv.Text+" "+giovv.Text;
                s_mabn = mabn2.Text + mabn3.Text;
                l_maql = m.get_maql(1, s_mabn, "??",s, false);
                if (l_maql != 0)
                {
                    load_vv_maql(true);
                    if (load_vk(false)) load_rk();
                    ngayvv.Text = s.Substring(0,10);
                    giovv.Text = s.Substring(11);
                    if (!bAdmin) ena_but(false);
                }
                else
                {
                    MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân chưa nhập viện ngày {") + s + "}", s_msg);
                    butBoqua_Click(null, null);
                }
                s_ngayvv = s;
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

            if (s_ngayvk.Trim().Length > 10)
            {
                if (ngayvk.Text != s_ngayvk.Substring(0,10) || cd_vaokhoa.Text == "")
                {
                    try
                    {
                        if (namsinh.Text != m.Namsinh("", int.Parse(tuoi.Text), loaituoi.SelectedIndex).ToString())
                        {
                            tuoi.Text = Convert.ToString(int.Parse(ngayvk.Text.Substring(6, 4)) - int.Parse(namsinh.Text)).PadLeft(3, '0');
                            loaituoi.SelectedIndex = 0;
                        }
                    }
                    catch { }
                    if (!m.ngay(m.StringToDate(ngayvk.Text.Substring(0, 10)), DateTime.Now, songay))
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Ngày vào khoa không hợp lệ so với khai báo hệ thống (") + songay.ToString() + ")!", s_msg);
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

            if (!m.bNgaygio(ngayvk.Text+" "+giovk.Text, ngayvv.Text+" "+giovv.Text))
            {
                MessageBox.Show(lan.Change_language_MessageText("Ngày vào khoa không được nhỏ hơn ngày vào viện !"), s_msg);
                ngayvk.Focus();
                return;
            }
            if (ngayvk.Text+" "+giovk.Text != s_ngayvk || cd_vaokhoa.Text == "")
            {
                s_mabn = mabn2.Text + mabn3.Text;
                l_maql = m.get_maql(1, s_mabn, "??", ngayvv.Text+" "+giovv.Text, false);
                if (l_maql != 0)
                {
                    if (!load_vk(true))
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân này chưa nhập khoa {") + ngayvk.Text+" "+giovk.Text + "}", s_msg);
                        butBoqua_Click(null, null);
                        return;
                    }
                    load_rk();
                }
                else
                {
                    MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân này chưa nhập khoa {") + ngayvk.Text+" "+giovk.Text + "}", s_msg);
                    butBoqua_Click(null, null);
                    return;
                }
                s_ngayvk = ngayvk.Text+" "+giovk.Text;
            }
            if (psankhoa.Visible) ngayde.Focus();
            else ngayrv.Focus();
        }

        private void ngayrv_Validated(object sender, System.EventArgs e)
        {
            if (ngayrv.Text == "")
            {
                string s = m.Ngaygio;
                ngayrv.Text = s.Substring(0, 10);
                giorv.Text = s.Substring(11);
            }
            ngayrv.Text = ngayrv.Text.Trim();
            if (ngayrv.Text.Length == 6) ngayrv.Text = ngayrv.Text + DateTime.Now.Year.ToString();
            if (!m.bNgay(ngayrv.Text))
            {
                MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"));
                ngayrv.Focus();
                return;
            }
            if (s_ngayrk.Trim().Length > 10)
            {
                if (ngayrv.Text != s_ngayrk.Substring(0,10))
                {
                    if (!m.ngay(m.StringToDate(ngayrv.Text.Substring(0, 10)), DateTime.Now, songay))
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Ngày ra khoa không hợp lệ so với khai báo hệ thống (") + songay.ToString() + ")!", s_msg);
                        ngayrv.Focus();
                        return;
                    }
                    string sql = "select * from " + user + ".nhapkhoa where makp='" + s_makp + "' and maql=" + l_maql;
                    sql += " and to_char(ngay,'dd/mm/yyyy hh24:mi')='" + ngayvk.Text+" "+giovk.Text + "'";
                    if (m.get_data(sql).Tables[0].Rows.Count == 0)
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân này chưa nhập khoa {") + ngayvk.Text + " " + giovk.Text + "}", s_msg);
                        butBoqua_Click(sender, e);
                        return;
                    }
                }
            }
            try
            {
                songaydt.Text = m.songay(m.StringToDate(ngayrv.Text.Substring(0, 10)), m.StringToDate(ngayvk.Text.Substring(0, 10)), (tenkp.SelectedValue.ToString() == "01") ? 1 : 0).ToString();
            }
            catch { songaydt.Text = ""; }

            if (bLuutru_Mabn) soluutru.Text=mabn2.Text+mabn3.Text;
			else if (bSoluutru_sovaovien) soluutru.Text=sovaovien.Text;
            if (bSankhoa && cd_chinh.Text == "")
            {
                cd_chinh.Text = cd_vaokhoa.Text;
                icd_chinh.Text = icd_vaokhoa.Text;
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
            if (ngayrv.Text+" "+giorv.Text != s_ngayrk)
            {
                if (!m.bNgaygio(ngayrv.Text+" "+giorv.Text, ngayvk.Text+" "+giovk.Text))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Ngày ra khoa không được nhỏ hơn ngày vào khoa !"), s_msg);
                    ngayrv.Focus();
                    return;
                }
            }
        }

        private void ngayde_Validated(object sender, System.EventArgs e)
        {
            if (ngayde.Text == "")
            {
                ngayrv.Focus();
                return;
            }
            ngayde.Text = ngayde.Text.Trim();
            if (ngayde.Text.Length == 6) ngayde.Text = ngayde.Text + DateTime.Now.Year.ToString();
            if (s_ngayde.Trim().Length > 10)
            {
                if (ngayde.Text != s_ngayde.Substring(0,10))
                {
                    if (ngayde.Text.Length < 10)
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập ngày và giờ !"), s_msg);
                        ngayde.Focus();
                        return;
                    }
                    if (!m.bNgay(ngayde.Text))
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Ngày và giờ không hợp lệ !"));
                        ngayde.Focus();
                        return;
                    }
                    if (!m.ngay(m.StringToDate(ngayde.Text.Substring(0, 10)), DateTime.Now, songay))
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Ngày đẻ (mổ đẻ) không hợp lệ so với khai báo hệ thống (") + songay.ToString() + ")!", s_msg);
                        ngayde.Focus();
                        return;
                    }
                }
            }
        }

        private void giode_Validated(object sender, EventArgs e)
        {
            string sgio = (giode.Text.Trim() == "") ? "00:00" : giode.Text.Trim();
            giode.Text = sgio.Substring(0, 2).Trim().PadLeft(2, '0') + ":" + sgio.Substring(3).Trim().PadRight(2, '0');
            if (!m.bGio(giode.Text))
            {
                MessageBox.Show(lan.Change_language_MessageText("Giờ không hợp lệ !"));
                giode.Focus();
                return;
            }
            if (ngayde.Text+" "+giode.Text != s_ngayde)
            {
                if (!m.bNgaygio(ngayde.Text+" "+giode.Text, ngayvk.Text+" "+giovk.Text))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Ngày đẻ (mổ đẻ) không được nhỏ hơn ngày vào khoa !"), s_msg);
                    ngayde.Focus();
                    return;
                }
            }
        }

        private void soluutru_Validated(object sender, EventArgs e)
        {
            if (soluutru.Text == "") return;
            if (m.blSoluutru(soluutru.Text, l_maql, "xuatvien"))
            {
                MessageBox.Show(lan.Change_language_MessageText("Số lưu trữ này đã có !"), s_msg);
                soluutru.Focus();
                return;
            }
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            if (mabn2.Text == "" || mabn3.Text == "" || hoten.Text == "") return;
            s_mabn = mabn2.Text + mabn3.Text;
            //frmBenhmantinh f = new frmBenhmantinh(m, s_mabn, i_userid);
            //f.ShowDialog();
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            if (!bTtptttkhoa) return;
            string _tuongtrinh = "", ngayvao = ngayvv.Text, ngayra = (ngayrv.Text.Trim().Length == 10) ? ngayrv.Text : m.ngayhienhanh_server.Substring(0, 10);
            foreach (DataRow r in m.get_data_mmyy("select to_char(a.ngay,'dd/mm/yyyy') as ngay,b.hoten as ptv,a.tenpt,a.noidung,c.ten as vocam from xxx.pttt a," + user + ".dmbs b," + user + ".dmmete c where a.ptv=b.ma and a.phuongphap=c.ma and a.maql=" + l_maql, ngayvao.Substring(0, 10), ngayra.Substring(0, 10), false).Tables[0].Rows)
            {
                _tuongtrinh=r["noidung"].ToString().Trim();
                break;
            }

            if (_tuongtrinh != "")
            {
                //frmTtptttkhoa f = new frmTtptttkhoa(m, mabn2.Text + mabn3.Text, hoten.Text, namsinh.Text, phai.Text, ngayvao, ngayra, l_maql, l_id, i_userid, _tuongtrinh);
                //f.ShowDialog();
            }
            else MessageBox.Show(lan.Change_language_MessageText("Người bệnh") + " " + hoten.Text + "\n" + lan.Change_language_MessageText("Không có phẫu thuật !"), LibMedi.AccessData.Msg);
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            if (icd_kemtheo.Text == "" || cd_kemtheo.Text == "")
            {
                icd_kemtheo.Focus();
                return;
            }
            s_mabn = mabn2.Text + mabn3.Text;
            l_maql = m.get_maql(1, s_mabn, s_makp, ngayvv.Text + " " + giovv.Text, false);
            if (l_maql == 0)
            {
                if (!kiemtra()) return;
                butLuu_Click(null, null);
            }
            else
            {
                l_id = m.get_id(l_maql, s_makp, ngayvk.Text + " " + giovk.Text);
                if (cd_kemtheo.Text != "") m.upd_cdkemtheo(l_id, l_maql, 2, cd_kemtheo.Text, icd_kemtheo.Text, 1);
            }
            //frmCdkemtheo f = new frmCdkemtheo(m, l_id, l_maql, 2, "");
            //f.ShowDialog();
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
                dv.RowFilter = "hoten like '%" + ten.Trim() + "%'";
            }
            catch { }
        }
	}
}
