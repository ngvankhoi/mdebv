using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibMedi;
using LibVienphi;
using LibDuoc;

namespace DllPhonggiuong
{
	/// <summary>
	/// Summary description for frmXuatvien.
	/// </summary>
	public class frmNhapkhoa : System.Windows.Forms.Form
	{
		Language lan = new Language();
		//Binh
		DataSet dshd;
		//
		private LibMedi.AccessData m;
		private LibVienphi.AccessData v=new LibVienphi.AccessData();
		private LibDuoc.AccessData d=new LibDuoc.AccessData();
		private DataSet ds=new DataSet();
		private string mmyy,s_userid,s_makp,s_mabn,s_msg,s_ngayvv,s_ngayvk,m_phainu,m_sosinh,s_ngayde,s_ngaybong,para,s_noicap,sql,nam;
		private int i_userid,i_mabv,i_maba,i_chidinh;
		private long l_id=0,l_maql=0;
		private DataTable dtba=new DataTable();
		private DataTable dt=new DataTable();
		private DataTable dtg=new DataTable();
		private DataTable dtdt=new DataTable();
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
		private MaskedTextBox.MaskedTextBox giuong;
		private System.Windows.Forms.Label label38;
		private MaskedTextBox.MaskedTextBox icd_kemtheo;
		private System.Windows.Forms.Label label46;
		private System.Windows.Forms.ComboBox tenbs;
		private System.Windows.Forms.TextBox mabs;
		private System.Windows.Forms.Label label49;
		private System.Windows.Forms.CheckBox thuthuat;
		private System.Windows.Forms.CheckBox phauthuat;
		private System.Windows.Forms.Label label52;
		private System.Windows.Forms.Button butTiep;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.Button butKetthuc;
		private System.Windows.Forms.Label l_thuthuat;
		private System.Windows.Forms.Label l_phauthuat;
		private int songay=30,iTreem6,iTreem15;
		private bool b_Edit=false,b_Hoten=false,bSankhoa,bBong,bUngbuou,bNhi,bSosinh,bTamthan,b_bacsi,b_nhapvien,bHanhchinh,bAdmin,bMabame,bSuadoituong;
		private System.Windows.Forms.ToolTip toolTip2;
		private System.ComponentModel.IContainer components;
		private bool b_sovaovien,b_soluutru,bKhamthai,bTiepdon,bChuyenkhoasan,bDenngay_sothe,bChandoan,bNhapsoluutru,bCapso,bSothe_mabn,b101204,bPhonggiuong;
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
		private System.Windows.Forms.Panel psankhoa;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label lbong;
		private System.Windows.Forms.Panel pungbuou_v;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label15;
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
		private System.Windows.Forms.CheckBox kiemsoat;
		private MaskedTextBox.MaskedTextBox giaidoan_v;
		private MaskedTextBox.MaskedTextBox m_v;
		private MaskedTextBox.MaskedTextBox n_v;
		private MaskedTextBox.MaskedTextBox t_v;
		private System.Windows.Forms.TreeView treeView1;
		private System.Windows.Forms.Label label64;
		private System.Windows.Forms.TreeView treeView2;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label l_tainantt;
		private System.Windows.Forms.CheckBox tainantt;
		private MaskedBox.MaskedBox ngaybong;
		private MaskedBox.MaskedBox ngaysinh;
		private MaskedBox.MaskedBox denngay;
		private MaskedBox.MaskedBox ngayvv;
		private MaskedBox.MaskedBox ngayvk;
		private MaskedBox.MaskedBox ngayde;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.Label label14;
		private string s_icd_noichuyenden,s_icd_kkb,s_icd_vaokhoa,s_icd_kemtheo,s_madstt;
		private LibList.List listICD;
		private System.Windows.Forms.TextBox cd_vaokhoa;
		private System.Windows.Forms.TextBox cd_noichuyenden;
		private System.Windows.Forms.TextBox cd_kkb;
		private System.Windows.Forms.TextBox cd_kemtheo;
		private System.Windows.Forms.CheckBox chidinh;
		private System.Windows.Forms.Label l_chidinh;
		private System.Windows.Forms.CheckBox vienphi;
		private System.Windows.Forms.Label l_vienphi;
		private System.Windows.Forms.Label l_cls;
		private System.Windows.Forms.CheckBox cls;
		private System.Windows.Forms.Label l_kemtheo;
		private System.Windows.Forms.CheckBox kemtheo;
		private MaskedTextBox.MaskedTextBox mame;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.CheckBox diungthuoc;
		private System.Windows.Forms.Label l_diungthuoc;
		private System.Windows.Forms.Label lbl;
		private System.Windows.Forms.Panel khamthai;
		private MaskedTextBox.MaskedTextBox para4;
		private MaskedTextBox.MaskedTextBox para3;
		private MaskedTextBox.MaskedTextBox para2;
		private MaskedTextBox.MaskedTextBox para1;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Panel ddsosinh;
		private MaskedTextBox.MaskedTextBox vongdau;
		private MaskedTextBox.MaskedTextBox cao;
		private MaskedTextBox.MaskedTextBox cannang;
		private MaskedTextBox.MaskedTextBox apgar10;
		private MaskedTextBox.MaskedTextBox apgar5;
		private MaskedTextBox.MaskedTextBox apgar1;
		private System.Windows.Forms.Label label47;
		private System.Windows.Forms.Label label44;
		private System.Windows.Forms.Label label42;
		private System.Windows.Forms.Label label40;
		private System.Windows.Forms.Label label39;
		private System.Windows.Forms.Label label36;
		private System.Windows.Forms.Label label37;
		private System.Windows.Forms.Label label48;
		private System.Windows.Forms.Label label50;
		private System.Windows.Forms.Label label51;
		private System.Windows.Forms.Label label54;
		private System.Windows.Forms.Label label65;
		private System.Windows.Forms.Label label66;
		private System.Windows.Forms.GroupBox danhsach;
		private System.Windows.Forms.Button butRef;
		private AsYetUnnamed.MultiColumnListBox list;
		private System.Windows.Forms.Button butPhong;
		private System.Windows.Forms.ComboBox cachthucde;
		private System.Windows.Forms.Label label67;
		private System.Windows.Forms.TextBox matb;
		private System.Windows.Forms.ComboBox tentb;
		private MaskedTextBox.MaskedTextBox soluutru;
		private System.Windows.Forms.Label label68;
		private System.Windows.Forms.Panel pmat;
		private MaskedTextBox.MaskedTextBox nhanapt;
		private MaskedTextBox.MaskedTextBox nhanapp;
		private MaskedTextBox.MaskedTextBox mt;
		private MaskedTextBox.MaskedTextBox mp;
		private System.Windows.Forms.Label label69;
		private System.Windows.Forms.Label label70;
		private System.Windows.Forms.Label label71;
		private System.Windows.Forms.Label label72;
		private System.Windows.Forms.Label label73;
		private System.Windows.Forms.Label label74;
		private System.Windows.Forms.Label lblme;
		private System.Windows.Forms.Label lblhiv;
		private System.Windows.Forms.Label lbltieusu;
		private DataTable dticd=new DataTable();

		public frmNhapkhoa(LibMedi.AccessData acc,string makp,string hoten,int userid,int mabv,bool sovaovien,bool soluutru)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
			m=acc;
			s_makp=makp;
			s_userid=hoten;
			i_userid=userid;
			i_mabv=mabv;
			b_sovaovien=sovaovien;
			b_soluutru=soluutru; 
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmNhapkhoa));
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
			this.giuong = new MaskedTextBox.MaskedTextBox();
			this.label38 = new System.Windows.Forms.Label();
			this.icd_kemtheo = new MaskedTextBox.MaskedTextBox();
			this.label46 = new System.Windows.Forms.Label();
			this.tenbs = new System.Windows.Forms.ComboBox();
			this.mabs = new System.Windows.Forms.TextBox();
			this.label49 = new System.Windows.Forms.Label();
			this.thuthuat = new System.Windows.Forms.CheckBox();
			this.phauthuat = new System.Windows.Forms.CheckBox();
			this.label52 = new System.Windows.Forms.Label();
			this.butTiep = new System.Windows.Forms.Button();
			this.butLuu = new System.Windows.Forms.Button();
			this.butBoqua = new System.Windows.Forms.Button();
			this.butKetthuc = new System.Windows.Forms.Button();
			this.l_thuthuat = new System.Windows.Forms.Label();
			this.l_phauthuat = new System.Windows.Forms.Label();
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
			this.label17 = new System.Windows.Forms.Label();
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
			this.cd_vaokhoa = new System.Windows.Forms.TextBox();
			this.cd_noichuyenden = new System.Windows.Forms.TextBox();
			this.cd_kkb = new System.Windows.Forms.TextBox();
			this.ngaybong = new MaskedBox.MaskedBox();
			this.denngay = new MaskedBox.MaskedBox();
			this.ngayvk = new MaskedBox.MaskedBox();
			this.ngayvv = new MaskedBox.MaskedBox();
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
			this.label18 = new System.Windows.Forms.Label();
			this.lbltieusu = new System.Windows.Forms.Label();
			this.psankhoa = new System.Windows.Forms.Panel();
			this.tentb = new System.Windows.Forms.ComboBox();
			this.matb = new System.Windows.Forms.TextBox();
			this.cachthucde = new System.Windows.Forms.ComboBox();
			this.label67 = new System.Windows.Forms.Label();
			this.ngayde = new MaskedBox.MaskedBox();
			this.kiemsoat = new System.Windows.Forms.CheckBox();
			this.label10 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.pungbuou_v = new System.Windows.Forms.Panel();
			this.giaidoan_v = new MaskedTextBox.MaskedTextBox();
			this.m_v = new MaskedTextBox.MaskedTextBox();
			this.n_v = new MaskedTextBox.MaskedTextBox();
			this.t_v = new MaskedTextBox.MaskedTextBox();
			this.label15 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.treeView2 = new System.Windows.Forms.TreeView();
			this.label16 = new System.Windows.Forms.Label();
			this.l_tainantt = new System.Windows.Forms.Label();
			this.tainantt = new System.Windows.Forms.CheckBox();
			this.ngaysinh = new MaskedBox.MaskedBox();
			this.butIn = new System.Windows.Forms.Button();
			this.listICD = new LibList.List();
			this.cd_kemtheo = new System.Windows.Forms.TextBox();
			this.chidinh = new System.Windows.Forms.CheckBox();
			this.l_chidinh = new System.Windows.Forms.Label();
			this.vienphi = new System.Windows.Forms.CheckBox();
			this.l_vienphi = new System.Windows.Forms.Label();
			this.l_cls = new System.Windows.Forms.Label();
			this.cls = new System.Windows.Forms.CheckBox();
			this.l_kemtheo = new System.Windows.Forms.Label();
			this.kemtheo = new System.Windows.Forms.CheckBox();
			this.diungthuoc = new System.Windows.Forms.CheckBox();
			this.l_diungthuoc = new System.Windows.Forms.Label();
			this.lbl = new System.Windows.Forms.Label();
			this.ddsosinh = new System.Windows.Forms.Panel();
			this.label42 = new System.Windows.Forms.Label();
			this.label39 = new System.Windows.Forms.Label();
			this.vongdau = new MaskedTextBox.MaskedTextBox();
			this.cao = new MaskedTextBox.MaskedTextBox();
			this.cannang = new MaskedTextBox.MaskedTextBox();
			this.apgar10 = new MaskedTextBox.MaskedTextBox();
			this.apgar5 = new MaskedTextBox.MaskedTextBox();
			this.apgar1 = new MaskedTextBox.MaskedTextBox();
			this.label47 = new System.Windows.Forms.Label();
			this.label44 = new System.Windows.Forms.Label();
			this.label40 = new System.Windows.Forms.Label();
			this.label36 = new System.Windows.Forms.Label();
			this.label37 = new System.Windows.Forms.Label();
			this.label48 = new System.Windows.Forms.Label();
			this.label50 = new System.Windows.Forms.Label();
			this.label51 = new System.Windows.Forms.Label();
			this.label54 = new System.Windows.Forms.Label();
			this.label65 = new System.Windows.Forms.Label();
			this.label66 = new System.Windows.Forms.Label();
			this.danhsach = new System.Windows.Forms.GroupBox();
			this.butRef = new System.Windows.Forms.Button();
			this.list = new AsYetUnnamed.MultiColumnListBox();
			this.butPhong = new System.Windows.Forms.Button();
			this.soluutru = new MaskedTextBox.MaskedTextBox();
			this.label68 = new System.Windows.Forms.Label();
			this.pmat = new System.Windows.Forms.Panel();
			this.nhanapt = new MaskedTextBox.MaskedTextBox();
			this.nhanapp = new MaskedTextBox.MaskedTextBox();
			this.mt = new MaskedTextBox.MaskedTextBox();
			this.mp = new MaskedTextBox.MaskedTextBox();
			this.label69 = new System.Windows.Forms.Label();
			this.label70 = new System.Windows.Forms.Label();
			this.label71 = new System.Windows.Forms.Label();
			this.label72 = new System.Windows.Forms.Label();
			this.label73 = new System.Windows.Forms.Label();
			this.label74 = new System.Windows.Forms.Label();
			this.lblme = new System.Windows.Forms.Label();
			this.lblhiv = new System.Windows.Forms.Label();
			this.pnhi.SuspendLayout();
			this.phanhchinh.SuspendLayout();
			this.psosinh.SuspendLayout();
			this.ppara.SuspendLayout();
			this.pvaovien.SuspendLayout();
			this.khamthai.SuspendLayout();
			this.psankhoa.SuspendLayout();
			this.pungbuou_v.SuspendLayout();
			this.ddsosinh.SuspendLayout();
			this.danhsach.SuspendLayout();
			this.pmat.SuspendLayout();
			this.SuspendLayout();
			// 
			// tenba
			// 
			this.tenba.BackColor = System.Drawing.SystemColors.HighlightText;
			this.tenba.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.tenba.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tenba.Location = new System.Drawing.Point(59, 19);
			this.tenba.Name = "tenba";
			this.tenba.Size = new System.Drawing.Size(102, 21);
			this.tenba.TabIndex = 2;
			this.tenba.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenba_KeyDown);
			this.tenba.SelectedIndexChanged += new System.EventHandler(this.tenba_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.label2.Location = new System.Drawing.Point(5, 19);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 23);
			this.label2.TabIndex = 0;
			this.label2.Text = "&Bệnh án :";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label3
			// 
			this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.label3.Location = new System.Drawing.Point(160, 19);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(48, 23);
			this.label3.TabIndex = 3;
			this.label3.Text = "&Mã BN :";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label4
			// 
			this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.label4.Location = new System.Drawing.Point(271, 19);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 23);
			this.label4.TabIndex = 10;
			this.label4.Text = "Họ và tên :";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label5
			// 
			this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.label5.Location = new System.Drawing.Point(451, 19);
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
			this.mabn1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.mabn1.Location = new System.Drawing.Point(160, 0);
			this.mabn1.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
			this.mabn1.MaxLength = 8;
			this.mabn1.Name = "mabn1";
			this.mabn1.Size = new System.Drawing.Size(45, 21);
			this.mabn1.TabIndex = 4;
			this.mabn1.Text = "";
			this.mabn1.Visible = false;
			// 
			// mabn2
			// 
			this.mabn2.BackColor = System.Drawing.SystemColors.HighlightText;
			this.mabn2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.mabn2.Location = new System.Drawing.Point(208, 19);
			this.mabn2.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
			this.mabn2.MaxLength = 2;
			this.mabn2.Name = "mabn2";
			this.mabn2.Size = new System.Drawing.Size(22, 21);
			this.mabn2.TabIndex = 5;
			this.mabn2.Text = "";
			this.mabn2.Validated += new System.EventHandler(this.mabn2_Validated);
			// 
			// mabn3
			// 
			this.mabn3.BackColor = System.Drawing.SystemColors.HighlightText;
			this.mabn3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.mabn3.Location = new System.Drawing.Point(232, 19);
			this.mabn3.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
			this.mabn3.MaxLength = 6;
			this.mabn3.Name = "mabn3";
			this.mabn3.Size = new System.Drawing.Size(45, 21);
			this.mabn3.TabIndex = 6;
			this.mabn3.Text = "";
			this.mabn3.Validated += new System.EventHandler(this.mabn3_Validated);
			// 
			// label6
			// 
			this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.label6.Location = new System.Drawing.Point(573, 19);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(64, 23);
			this.label6.TabIndex = 14;
			this.label6.Text = "Năm sinh :";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// namsinh
			// 
			this.namsinh.BackColor = System.Drawing.SystemColors.HighlightText;
			this.namsinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.namsinh.Location = new System.Drawing.Point(635, 19);
			this.namsinh.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
			this.namsinh.MaxLength = 4;
			this.namsinh.Name = "namsinh";
			this.namsinh.Size = new System.Drawing.Size(34, 21);
			this.namsinh.TabIndex = 9;
			this.namsinh.Text = "";
			this.namsinh.Validated += new System.EventHandler(this.namsinh_Validated);
			// 
			// label7
			// 
			this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.label7.Location = new System.Drawing.Point(668, 19);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(32, 23);
			this.label7.TabIndex = 16;
			this.label7.Text = "Tuổi :";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// loaituoi
			// 
			this.loaituoi.BackColor = System.Drawing.SystemColors.HighlightText;
			this.loaituoi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.loaituoi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.loaituoi.Items.AddRange(new object[] {
														  "Tuổi",
														  "Tháng",
														  "Ngày",
														  "Giờ"});
			this.loaituoi.Location = new System.Drawing.Point(729, 19);
			this.loaituoi.Name = "loaituoi";
			this.loaituoi.Size = new System.Drawing.Size(58, 21);
			this.loaituoi.TabIndex = 11;
			this.loaituoi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.loaituoi_KeyDown);
			// 
			// maba
			// 
			this.maba.BackColor = System.Drawing.SystemColors.HighlightText;
			this.maba.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.maba.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.maba.Location = new System.Drawing.Point(128, 0);
			this.maba.MaxLength = 3;
			this.maba.Name = "maba";
			this.maba.Size = new System.Drawing.Size(30, 21);
			this.maba.TabIndex = 1;
			this.maba.Text = "";
			this.maba.Visible = false;
			this.maba.KeyDown += new System.Windows.Forms.KeyEventHandler(this.maba_KeyDown);
			this.maba.Validated += new System.EventHandler(this.maba_Validated);
			// 
			// tuoi
			// 
			this.tuoi.BackColor = System.Drawing.SystemColors.HighlightText;
			this.tuoi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tuoi.Location = new System.Drawing.Point(699, 19);
			this.tuoi.MaxLength = 3;
			this.tuoi.Name = "tuoi";
			this.tuoi.Size = new System.Drawing.Size(28, 21);
			this.tuoi.TabIndex = 10;
			this.tuoi.Text = "";
			this.tuoi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tuoi_KeyDown);
			this.tuoi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tuoi_KeyPress);
			this.tuoi.Validated += new System.EventHandler(this.tuoi_Validated);
			// 
			// hoten
			// 
			this.hoten.BackColor = System.Drawing.SystemColors.HighlightText;
			this.hoten.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.hoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.hoten.Location = new System.Drawing.Point(334, 19);
			this.hoten.Name = "hoten";
			this.hoten.Size = new System.Drawing.Size(120, 21);
			this.hoten.TabIndex = 7;
			this.hoten.Text = "";
			this.hoten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.hoten_KeyDown);
			this.hoten.Validated += new System.EventHandler(this.hoten_Validated);
			// 
			// giuong
			// 
			this.giuong.BackColor = System.Drawing.SystemColors.HighlightText;
			this.giuong.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.giuong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.giuong.Location = new System.Drawing.Point(109, 362);
			this.giuong.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
			this.giuong.MaxLength = 10;
			this.giuong.Name = "giuong";
			this.giuong.Size = new System.Drawing.Size(75, 21);
			this.giuong.TabIndex = 33;
			this.giuong.Text = "";
			// 
			// label38
			// 
			this.label38.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.label38.Location = new System.Drawing.Point(16, 363);
			this.label38.Name = "label38";
			this.label38.Size = new System.Drawing.Size(96, 23);
			this.label38.TabIndex = 90;
			this.label38.Text = "Phòng/giường :";
			this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// icd_kemtheo
			// 
			this.icd_kemtheo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.icd_kemtheo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.icd_kemtheo.Location = new System.Drawing.Point(109, 339);
			this.icd_kemtheo.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
			this.icd_kemtheo.MaxLength = 9;
			this.icd_kemtheo.Name = "icd_kemtheo";
			this.icd_kemtheo.Size = new System.Drawing.Size(59, 21);
			this.icd_kemtheo.TabIndex = 31;
			this.icd_kemtheo.Text = "";
			this.icd_kemtheo.Validated += new System.EventHandler(this.icd_kemtheo_Validated);
			this.icd_kemtheo.TextChanged += new System.EventHandler(this.icd_noichuyenden_TextChanged);
			// 
			// label46
			// 
			this.label46.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.label46.Location = new System.Drawing.Point(-7, 339);
			this.label46.Name = "label46";
			this.label46.Size = new System.Drawing.Size(120, 23);
			this.label46.TabIndex = 105;
			this.label46.Text = "Bệnh kèm theo :";
			this.label46.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// tenbs
			// 
			this.tenbs.BackColor = System.Drawing.SystemColors.HighlightText;
			this.tenbs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.tenbs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tenbs.Location = new System.Drawing.Point(336, 362);
			this.tenbs.Name = "tenbs";
			this.tenbs.Size = new System.Drawing.Size(184, 21);
			this.tenbs.TabIndex = 35;
			this.tenbs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbs_KeyDown);
			this.tenbs.SelectedIndexChanged += new System.EventHandler(this.tenbs_SelectedIndexChanged);
			// 
			// mabs
			// 
			this.mabs.BackColor = System.Drawing.SystemColors.HighlightText;
			this.mabs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.mabs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.mabs.Location = new System.Drawing.Point(295, 362);
			this.mabs.MaxLength = 4;
			this.mabs.Name = "mabs";
			this.mabs.Size = new System.Drawing.Size(40, 21);
			this.mabs.TabIndex = 34;
			this.mabs.Text = "";
			this.mabs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabs_KeyDown);
			this.mabs.Validated += new System.EventHandler(this.mabs_Validated);
			// 
			// label49
			// 
			this.label49.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.label49.Location = new System.Drawing.Point(213, 363);
			this.label49.Name = "label49";
			this.label49.Size = new System.Drawing.Size(80, 23);
			this.label49.TabIndex = 117;
			this.label49.Text = "Bác sĩ điều trị :";
			this.label49.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// thuthuat
			// 
			this.thuthuat.BackColor = System.Drawing.Color.Transparent;
			this.thuthuat.Enabled = false;
			this.thuthuat.Location = new System.Drawing.Point(660, 387);
			this.thuthuat.Name = "thuthuat";
			this.thuthuat.Size = new System.Drawing.Size(16, 14);
			this.thuthuat.TabIndex = 123;
			// 
			// phauthuat
			// 
			this.phauthuat.BackColor = System.Drawing.Color.Transparent;
			this.phauthuat.Enabled = false;
			this.phauthuat.Location = new System.Drawing.Point(660, 403);
			this.phauthuat.Name = "phauthuat";
			this.phauthuat.Size = new System.Drawing.Size(16, 14);
			this.phauthuat.TabIndex = 124;
			// 
			// label52
			// 
			this.label52.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, (System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline), System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label52.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.label52.Location = new System.Drawing.Point(8, -2);
			this.label52.Name = "label52";
			this.label52.Size = new System.Drawing.Size(112, 23);
			this.label52.TabIndex = 141;
			this.label52.Text = "I. HÀNH CHÍNH :";
			this.label52.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// butTiep
			// 
			this.butTiep.BackColor = System.Drawing.SystemColors.Control;
			this.butTiep.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.butTiep.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.butTiep.Image = ((System.Drawing.Bitmap)(resources.GetObject("butTiep.Image")));
			this.butTiep.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butTiep.Location = new System.Drawing.Point(243, 419);
			this.butTiep.Name = "butTiep";
			this.butTiep.Size = new System.Drawing.Size(75, 28);
			this.butTiep.TabIndex = 44;
			this.butTiep.Text = "          &Tiếp";
			this.butTiep.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butTiep.Click += new System.EventHandler(this.butTiep_Click);
			// 
			// butLuu
			// 
			this.butLuu.BackColor = System.Drawing.SystemColors.Control;
			this.butLuu.Enabled = false;
			this.butLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.butLuu.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.butLuu.Image = ((System.Drawing.Bitmap)(resources.GetObject("butLuu.Image")));
			this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butLuu.Location = new System.Drawing.Point(320, 419);
			this.butLuu.Name = "butLuu";
			this.butLuu.Size = new System.Drawing.Size(75, 28);
			this.butLuu.TabIndex = 42;
			this.butLuu.Text = "           &Lưu";
			this.butLuu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
			// 
			// butBoqua
			// 
			this.butBoqua.BackColor = System.Drawing.SystemColors.Control;
			this.butBoqua.Enabled = false;
			this.butBoqua.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.butBoqua.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.butBoqua.Image = ((System.Drawing.Bitmap)(resources.GetObject("butBoqua.Image")));
			this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butBoqua.Location = new System.Drawing.Point(397, 419);
			this.butBoqua.Name = "butBoqua";
			this.butBoqua.Size = new System.Drawing.Size(75, 28);
			this.butBoqua.TabIndex = 43;
			this.butBoqua.Text = "        Bỏ qua";
			this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
			// 
			// butKetthuc
			// 
			this.butKetthuc.BackColor = System.Drawing.SystemColors.Control;
			this.butKetthuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.butKetthuc.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.butKetthuc.Image = ((System.Drawing.Bitmap)(resources.GetObject("butKetthuc.Image")));
			this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butKetthuc.Location = new System.Drawing.Point(474, 419);
			this.butKetthuc.Name = "butKetthuc";
			this.butKetthuc.Size = new System.Drawing.Size(74, 28);
			this.butKetthuc.TabIndex = 46;
			this.butKetthuc.Text = "Kết thúc";
			this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
			// 
			// l_thuthuat
			// 
			this.l_thuthuat.Cursor = System.Windows.Forms.Cursors.Hand;
			this.l_thuthuat.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.l_thuthuat.Image = ((System.Drawing.Bitmap)(resources.GetObject("l_thuthuat.Image")));
			this.l_thuthuat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.l_thuthuat.Location = new System.Drawing.Point(673, 387);
			this.l_thuthuat.Name = "l_thuthuat";
			this.l_thuthuat.Size = new System.Drawing.Size(100, 14);
			this.l_thuthuat.TabIndex = 151;
			this.l_thuthuat.Text = "       Phẩu thủ thuật";
			this.l_thuthuat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.l_thuthuat.Click += new System.EventHandler(this.l_thuthuat_Click);
			// 
			// l_phauthuat
			// 
			this.l_phauthuat.Cursor = System.Windows.Forms.Cursors.Hand;
			this.l_phauthuat.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.l_phauthuat.Image = ((System.Drawing.Bitmap)(resources.GetObject("l_phauthuat.Image")));
			this.l_phauthuat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.l_phauthuat.Location = new System.Drawing.Point(673, 403);
			this.l_phauthuat.Name = "l_phauthuat";
			this.l_phauthuat.Size = new System.Drawing.Size(100, 14);
			this.l_phauthuat.TabIndex = 152;
			this.l_phauthuat.Text = "       Trẻ sơ sinh";
			this.l_phauthuat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.l_phauthuat.Click += new System.EventHandler(this.l_phauthuat_Click);
			// 
			// tdvh
			// 
			this.tdvh.BackColor = System.Drawing.SystemColors.HighlightText;
			this.tdvh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tdvh.Location = new System.Drawing.Point(434, 45);
			this.tdvh.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
			this.tdvh.MaxLength = 30;
			this.tdvh.Name = "tdvh";
			this.tdvh.Size = new System.Drawing.Size(88, 21);
			this.tdvh.TabIndex = 11;
			this.tdvh.Text = "";
			this.toolTip2.SetToolTip(this.tdvh, "Trình độ văn hóa");
			this.tdvh.Visible = false;
			// 
			// lanthu
			// 
			this.lanthu.BackColor = System.Drawing.SystemColors.HighlightText;
			this.lanthu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lanthu.Location = new System.Drawing.Point(640, 22);
			this.lanthu.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
			this.lanthu.MaxLength = 3;
			this.lanthu.Name = "lanthu";
			this.lanthu.Size = new System.Drawing.Size(24, 21);
			this.lanthu.TabIndex = 6;
			this.lanthu.Text = "";
			this.toolTip2.SetToolTip(this.lanthu, "Vào viện do bệnh này lần thứ");
			this.lanthu.Validated += new System.EventHandler(this.lanthu_Validated);
			// 
			// ss_para4
			// 
			this.ss_para4.BackColor = System.Drawing.SystemColors.HighlightText;
			this.ss_para4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ss_para4.Location = new System.Drawing.Point(320, 0);
			this.ss_para4.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
			this.ss_para4.MaxLength = 2;
			this.ss_para4.Name = "ss_para4";
			this.ss_para4.Size = new System.Drawing.Size(20, 21);
			this.ss_para4.TabIndex = 4;
			this.ss_para4.Text = "";
			this.toolTip2.SetToolTip(this.ss_para4, "Sống");
			this.ss_para4.Validated += new System.EventHandler(this.ss_para4_Validated);
			// 
			// ss_para3
			// 
			this.ss_para3.BackColor = System.Drawing.SystemColors.HighlightText;
			this.ss_para3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ss_para3.Location = new System.Drawing.Point(299, 0);
			this.ss_para3.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
			this.ss_para3.MaxLength = 2;
			this.ss_para3.Name = "ss_para3";
			this.ss_para3.Size = new System.Drawing.Size(20, 21);
			this.ss_para3.TabIndex = 3;
			this.ss_para3.Text = "";
			this.toolTip2.SetToolTip(this.ss_para3, "Sẩy (nạo,hút)");
			this.ss_para3.Validated += new System.EventHandler(this.ss_para3_Validated);
			// 
			// ss_para2
			// 
			this.ss_para2.BackColor = System.Drawing.SystemColors.HighlightText;
			this.ss_para2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ss_para2.Location = new System.Drawing.Point(278, 0);
			this.ss_para2.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
			this.ss_para2.MaxLength = 2;
			this.ss_para2.Name = "ss_para2";
			this.ss_para2.Size = new System.Drawing.Size(20, 21);
			this.ss_para2.TabIndex = 2;
			this.ss_para2.Text = "";
			this.toolTip2.SetToolTip(this.ss_para2, "Sớm (thiếu tháng)");
			this.ss_para2.Validated += new System.EventHandler(this.ss_para2_Validated);
			// 
			// ss_para1
			// 
			this.ss_para1.BackColor = System.Drawing.SystemColors.HighlightText;
			this.ss_para1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ss_para1.Location = new System.Drawing.Point(257, 0);
			this.ss_para1.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
			this.ss_para1.MaxLength = 2;
			this.ss_para1.Name = "ss_para1";
			this.ss_para1.Size = new System.Drawing.Size(20, 21);
			this.ss_para1.TabIndex = 1;
			this.ss_para1.Text = "";
			this.toolTip2.SetToolTip(this.ss_para1, "Sinh (đủ tháng)");
			this.ss_para1.Validated += new System.EventHandler(this.ss_para1_Validated);
			// 
			// pnhi
			// 
			this.pnhi.Controls.AddRange(new System.Windows.Forms.Control[] {
																			   this.nhi_mann_me,
																			   this.nhi_tennn_me,
																			   this.label43,
																			   this.nhi_vanhoa_me,
																			   this.label45,
																			   this.nhi_mann_bo,
																			   this.nhi_tennn_bo,
																			   this.label41,
																			   this.nhi_vanhoa_bo,
																			   this.label35,
																			   this.nhi_hoten_me,
																			   this.label33,
																			   this.nhi_hoten_bo,
																			   this.label14});
			this.pnhi.Location = new System.Drawing.Point(0, 528);
			this.pnhi.Name = "pnhi";
			this.pnhi.Size = new System.Drawing.Size(792, 48);
			this.pnhi.TabIndex = 15;
			this.pnhi.Visible = false;
			// 
			// nhi_mann_me
			// 
			this.nhi_mann_me.BackColor = System.Drawing.SystemColors.HighlightText;
			this.nhi_mann_me.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.nhi_mann_me.Location = new System.Drawing.Point(562, 23);
			this.nhi_mann_me.MaxLength = 2;
			this.nhi_mann_me.Name = "nhi_mann_me";
			this.nhi_mann_me.Size = new System.Drawing.Size(24, 21);
			this.nhi_mann_me.TabIndex = 6;
			this.nhi_mann_me.Text = "";
			this.nhi_mann_me.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nhi_mann_me_KeyDown);
			this.nhi_mann_me.Validated += new System.EventHandler(this.nhi_mann_me_Validated);
			// 
			// nhi_tennn_me
			// 
			this.nhi_tennn_me.BackColor = System.Drawing.SystemColors.HighlightText;
			this.nhi_tennn_me.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.nhi_tennn_me.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.nhi_tennn_me.Location = new System.Drawing.Point(588, 23);
			this.nhi_tennn_me.Name = "nhi_tennn_me";
			this.nhi_tennn_me.Size = new System.Drawing.Size(200, 21);
			this.nhi_tennn_me.TabIndex = 7;
			this.nhi_tennn_me.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nhi_tennn_me_KeyDown);
			this.nhi_tennn_me.SelectedIndexChanged += new System.EventHandler(this.nhi_tennn_me_SelectedIndexChanged);
			// 
			// label43
			// 
			this.label43.ForeColor = System.Drawing.SystemColors.ActiveCaption;
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
			this.nhi_vanhoa_me.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.nhi_vanhoa_me.Location = new System.Drawing.Point(310, 23);
			this.nhi_vanhoa_me.Name = "nhi_vanhoa_me";
			this.nhi_vanhoa_me.Size = new System.Drawing.Size(120, 21);
			this.nhi_vanhoa_me.TabIndex = 5;
			this.nhi_vanhoa_me.Text = "";
			this.nhi_vanhoa_me.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nhi_vanhoa_me_KeyDown);
			this.nhi_vanhoa_me.Validated += new System.EventHandler(this.nhi_vanhoa_me_Validated);
			// 
			// label45
			// 
			this.label45.ForeColor = System.Drawing.SystemColors.ActiveCaption;
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
			this.nhi_mann_bo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.nhi_mann_bo.Location = new System.Drawing.Point(562, 0);
			this.nhi_mann_bo.MaxLength = 2;
			this.nhi_mann_bo.Name = "nhi_mann_bo";
			this.nhi_mann_bo.Size = new System.Drawing.Size(24, 21);
			this.nhi_mann_bo.TabIndex = 2;
			this.nhi_mann_bo.Text = "";
			this.nhi_mann_bo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nhi_mann_bo_KeyDown);
			this.nhi_mann_bo.Validated += new System.EventHandler(this.nhi_mann_bo_Validated);
			// 
			// nhi_tennn_bo
			// 
			this.nhi_tennn_bo.BackColor = System.Drawing.SystemColors.HighlightText;
			this.nhi_tennn_bo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.nhi_tennn_bo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.nhi_tennn_bo.Location = new System.Drawing.Point(588, 0);
			this.nhi_tennn_bo.Name = "nhi_tennn_bo";
			this.nhi_tennn_bo.Size = new System.Drawing.Size(200, 21);
			this.nhi_tennn_bo.TabIndex = 3;
			this.nhi_tennn_bo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nhi_tennn_bo_KeyDown);
			this.nhi_tennn_bo.SelectedIndexChanged += new System.EventHandler(this.nhi_tennn_bo_SelectedIndexChanged);
			// 
			// label41
			// 
			this.label41.ForeColor = System.Drawing.SystemColors.ActiveCaption;
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
			this.nhi_vanhoa_bo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.nhi_vanhoa_bo.Location = new System.Drawing.Point(310, 0);
			this.nhi_vanhoa_bo.Name = "nhi_vanhoa_bo";
			this.nhi_vanhoa_bo.Size = new System.Drawing.Size(120, 21);
			this.nhi_vanhoa_bo.TabIndex = 1;
			this.nhi_vanhoa_bo.Text = "";
			this.nhi_vanhoa_bo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nhi_vanhoa_bo_KeyDown);
			this.nhi_vanhoa_bo.Validated += new System.EventHandler(this.nhi_vanhoa_bo_Validated);
			// 
			// label35
			// 
			this.label35.ForeColor = System.Drawing.SystemColors.ActiveCaption;
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
			this.nhi_hoten_me.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.nhi_hoten_me.Location = new System.Drawing.Point(59, 23);
			this.nhi_hoten_me.Name = "nhi_hoten_me";
			this.nhi_hoten_me.Size = new System.Drawing.Size(120, 21);
			this.nhi_hoten_me.TabIndex = 4;
			this.nhi_hoten_me.Text = "";
			this.nhi_hoten_me.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nhi_hoten_me_KeyDown);
			this.nhi_hoten_me.Validated += new System.EventHandler(this.nhi_hoten_me_Validated);
			// 
			// label33
			// 
			this.label33.ForeColor = System.Drawing.SystemColors.ActiveCaption;
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
			this.nhi_hoten_bo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.nhi_hoten_bo.Location = new System.Drawing.Point(59, 0);
			this.nhi_hoten_bo.Name = "nhi_hoten_bo";
			this.nhi_hoten_bo.Size = new System.Drawing.Size(120, 21);
			this.nhi_hoten_bo.TabIndex = 0;
			this.nhi_hoten_bo.Text = "";
			this.nhi_hoten_bo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nhi_hoten_bo_KeyDown);
			this.nhi_hoten_bo.Validated += new System.EventHandler(this.nhi_hoten_bo_Validated);
			// 
			// label14
			// 
			this.label14.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.label14.Location = new System.Drawing.Point(-3, 0);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(64, 23);
			this.label14.TabIndex = 11;
			this.label14.Text = "Họ tên bố :";
			this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// phanhchinh
			// 
			this.phanhchinh.Controls.AddRange(new System.Windows.Forms.Control[] {
																					 this.tennuoc,
																					 this.manuoc,
																					 this.lmanuoc,
																					 this.sonha,
																					 this.tendantoc,
																					 this.tentqx,
																					 this.cholam,
																					 this.thon,
																					 this.mapxa2,
																					 this.maqu2,
																					 this.matt,
																					 this.tqx,
																					 this.madantoc,
																					 this.mann,
																					 this.tennn,
																					 this.tenquan,
																					 this.tentinh,
																					 this.tenpxa,
																					 this.mapxa1,
																					 this.lmaphuongxa,
																					 this.maqu1,
																					 this.lmaqu,
																					 this.lmatt,
																					 this.ltqx,
																					 this.lcholam,
																					 this.lthon,
																					 this.lsonha,
																					 this.lmadantoc,
																					 this.lmann});
			this.phanhchinh.Location = new System.Drawing.Point(-13, 88);
			this.phanhchinh.Name = "phanhchinh";
			this.phanhchinh.Size = new System.Drawing.Size(805, 68);
			this.phanhchinh.TabIndex = 14;
			// 
			// tennuoc
			// 
			this.tennuoc.BackColor = System.Drawing.SystemColors.HighlightText;
			this.tennuoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.tennuoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tennuoc.Location = new System.Drawing.Point(600, 0);
			this.tennuoc.Name = "tennuoc";
			this.tennuoc.Size = new System.Drawing.Size(82, 21);
			this.tennuoc.TabIndex = 5;
			this.tennuoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tennuoc_KeyDown);
			this.tennuoc.SelectedIndexChanged += new System.EventHandler(this.tennuoc_SelectedIndexChanged);
			// 
			// manuoc
			// 
			this.manuoc.BackColor = System.Drawing.SystemColors.HighlightText;
			this.manuoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.manuoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.manuoc.Location = new System.Drawing.Point(576, 0);
			this.manuoc.MaxLength = 2;
			this.manuoc.Name = "manuoc";
			this.manuoc.Size = new System.Drawing.Size(24, 21);
			this.manuoc.TabIndex = 4;
			this.manuoc.Text = "";
			this.manuoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.manuoc_KeyDown);
			this.manuoc.Validated += new System.EventHandler(this.manuoc_Validated);
			// 
			// lmanuoc
			// 
			this.lmanuoc.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.lmanuoc.Location = new System.Drawing.Point(512, 0);
			this.lmanuoc.Name = "lmanuoc";
			this.lmanuoc.Size = new System.Drawing.Size(64, 23);
			this.lmanuoc.TabIndex = 65;
			this.lmanuoc.Text = "Quốc tịch :";
			this.lmanuoc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// sonha
			// 
			this.sonha.BackColor = System.Drawing.SystemColors.HighlightText;
			this.sonha.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.sonha.Location = new System.Drawing.Point(728, 0);
			this.sonha.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
			this.sonha.MaxLength = 10;
			this.sonha.Name = "sonha";
			this.sonha.Size = new System.Drawing.Size(74, 21);
			this.sonha.TabIndex = 6;
			this.sonha.Text = "";
			// 
			// tendantoc
			// 
			this.tendantoc.BackColor = System.Drawing.SystemColors.HighlightText;
			this.tendantoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.tendantoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tendantoc.Location = new System.Drawing.Point(440, 0);
			this.tendantoc.Name = "tendantoc";
			this.tendantoc.Size = new System.Drawing.Size(65, 21);
			this.tendantoc.TabIndex = 3;
			this.tendantoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tendantoc_KeyDown);
			this.tendantoc.SelectedIndexChanged += new System.EventHandler(this.tendantoc_SelectedIndexChanged);
			// 
			// tentqx
			// 
			this.tentqx.BackColor = System.Drawing.SystemColors.HighlightText;
			this.tentqx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.tentqx.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tentqx.Location = new System.Drawing.Point(384, 23);
			this.tentqx.Name = "tentqx";
			this.tentqx.Size = new System.Drawing.Size(227, 21);
			this.tentqx.TabIndex = 9;
			this.tentqx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tentqx_KeyDown);
			this.tentqx.SelectedIndexChanged += new System.EventHandler(this.tentqx_SelectedIndexChanged);
			// 
			// cholam
			// 
			this.cholam.BackColor = System.Drawing.SystemColors.HighlightText;
			this.cholam.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.cholam.Location = new System.Drawing.Point(659, 46);
			this.cholam.Name = "cholam";
			this.cholam.Size = new System.Drawing.Size(141, 21);
			this.cholam.TabIndex = 18;
			this.cholam.Text = "";
			this.cholam.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cholam_KeyDown);
			this.cholam.Validated += new System.EventHandler(this.cholam_Validated);
			// 
			// thon
			// 
			this.thon.BackColor = System.Drawing.SystemColors.HighlightText;
			this.thon.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.thon.Location = new System.Drawing.Point(72, 24);
			this.thon.Name = "thon";
			this.thon.Size = new System.Drawing.Size(212, 21);
			this.thon.TabIndex = 7;
			this.thon.Text = "";
			this.thon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.thon_KeyDown);
			this.thon.Validated += new System.EventHandler(this.thon_Validated);
			// 
			// mapxa2
			// 
			this.mapxa2.BackColor = System.Drawing.SystemColors.HighlightText;
			this.mapxa2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.mapxa2.Location = new System.Drawing.Point(368, 46);
			this.mapxa2.MaxLength = 2;
			this.mapxa2.Name = "mapxa2";
			this.mapxa2.Size = new System.Drawing.Size(23, 21);
			this.mapxa2.TabIndex = 16;
			this.mapxa2.Text = "";
			this.mapxa2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mapxa2_KeyDown);
			this.mapxa2.Validated += new System.EventHandler(this.mapxa2_Validated);
			// 
			// maqu2
			// 
			this.maqu2.BackColor = System.Drawing.SystemColors.HighlightText;
			this.maqu2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.maqu2.Location = new System.Drawing.Point(80, 46);
			this.maqu2.MaxLength = 2;
			this.maqu2.Name = "maqu2";
			this.maqu2.Size = new System.Drawing.Size(23, 21);
			this.maqu2.TabIndex = 13;
			this.maqu2.Text = "";
			this.maqu2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.maqu2_KeyDown);
			this.maqu2.Validated += new System.EventHandler(this.maqu2_Validated);
			// 
			// matt
			// 
			this.matt.BackColor = System.Drawing.SystemColors.HighlightText;
			this.matt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.matt.Location = new System.Drawing.Point(656, 23);
			this.matt.MaxLength = 3;
			this.matt.Name = "matt";
			this.matt.Size = new System.Drawing.Size(27, 21);
			this.matt.TabIndex = 10;
			this.matt.Text = "";
			this.matt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.matt_KeyDown);
			this.matt.Validated += new System.EventHandler(this.matt_Validated);
			// 
			// tqx
			// 
			this.tqx.BackColor = System.Drawing.SystemColors.HighlightText;
			this.tqx.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tqx.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tqx.Location = new System.Drawing.Point(336, 23);
			this.tqx.Name = "tqx";
			this.tqx.Size = new System.Drawing.Size(48, 21);
			this.tqx.TabIndex = 8;
			this.tqx.Text = "";
			this.tqx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tqx_KeyDown);
			// 
			// madantoc
			// 
			this.madantoc.BackColor = System.Drawing.SystemColors.HighlightText;
			this.madantoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.madantoc.Location = new System.Drawing.Point(416, 0);
			this.madantoc.MaxLength = 2;
			this.madantoc.Name = "madantoc";
			this.madantoc.Size = new System.Drawing.Size(24, 21);
			this.madantoc.TabIndex = 2;
			this.madantoc.Text = "";
			this.madantoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.madantoc_KeyDown);
			this.madantoc.Validated += new System.EventHandler(this.madantoc_Validated);
			// 
			// mann
			// 
			this.mann.BackColor = System.Drawing.SystemColors.HighlightText;
			this.mann.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.mann.Location = new System.Drawing.Point(185, 0);
			this.mann.MaxLength = 2;
			this.mann.Name = "mann";
			this.mann.Size = new System.Drawing.Size(22, 21);
			this.mann.TabIndex = 0;
			this.mann.Text = "";
			this.mann.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mann_KeyDown);
			this.mann.Validated += new System.EventHandler(this.mann_Validated);
			// 
			// tennn
			// 
			this.tennn.BackColor = System.Drawing.SystemColors.HighlightText;
			this.tennn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.tennn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tennn.Location = new System.Drawing.Point(209, 0);
			this.tennn.Name = "tennn";
			this.tennn.Size = new System.Drawing.Size(159, 21);
			this.tennn.TabIndex = 1;
			this.tennn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tennn_KeyDown);
			this.tennn.SelectedIndexChanged += new System.EventHandler(this.tennn_SelectedIndexChanged);
			// 
			// tenquan
			// 
			this.tenquan.BackColor = System.Drawing.SystemColors.HighlightText;
			this.tenquan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.tenquan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tenquan.Location = new System.Drawing.Point(104, 46);
			this.tenquan.Name = "tenquan";
			this.tenquan.Size = new System.Drawing.Size(158, 21);
			this.tenquan.TabIndex = 14;
			this.tenquan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenquan_KeyDown);
			this.tenquan.SelectedIndexChanged += new System.EventHandler(this.tenquan_SelectedIndexChanged);
			// 
			// tentinh
			// 
			this.tentinh.BackColor = System.Drawing.SystemColors.HighlightText;
			this.tentinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.tentinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tentinh.Location = new System.Drawing.Point(688, 23);
			this.tentinh.Name = "tentinh";
			this.tentinh.Size = new System.Drawing.Size(112, 21);
			this.tentinh.TabIndex = 11;
			this.tentinh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tentinh_KeyDown);
			this.tentinh.SelectedIndexChanged += new System.EventHandler(this.tentinh_SelectedIndexChanged);
			// 
			// tenpxa
			// 
			this.tenpxa.BackColor = System.Drawing.SystemColors.HighlightText;
			this.tenpxa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.tenpxa.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tenpxa.Location = new System.Drawing.Point(392, 46);
			this.tenpxa.Name = "tenpxa";
			this.tenpxa.Size = new System.Drawing.Size(194, 21);
			this.tenpxa.TabIndex = 17;
			this.tenpxa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenpxa_KeyDown);
			this.tenpxa.SelectedIndexChanged += new System.EventHandler(this.tenpxa_SelectedIndexChanged);
			// 
			// mapxa1
			// 
			this.mapxa1.BackColor = System.Drawing.SystemColors.HighlightText;
			this.mapxa1.Enabled = false;
			this.mapxa1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.mapxa1.Location = new System.Drawing.Point(327, 46);
			this.mapxa1.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
			this.mapxa1.MaxLength = 5;
			this.mapxa1.Name = "mapxa1";
			this.mapxa1.Size = new System.Drawing.Size(40, 21);
			this.mapxa1.TabIndex = 15;
			this.mapxa1.Text = "";
			// 
			// lmaphuongxa
			// 
			this.lmaphuongxa.ForeColor = System.Drawing.SystemColors.ActiveCaption;
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
			this.maqu1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.maqu1.Location = new System.Drawing.Point(53, 46);
			this.maqu1.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
			this.maqu1.MaxLength = 3;
			this.maqu1.Name = "maqu1";
			this.maqu1.Size = new System.Drawing.Size(27, 21);
			this.maqu1.TabIndex = 12;
			this.maqu1.Text = "";
			// 
			// lmaqu
			// 
			this.lmaqu.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.lmaqu.Location = new System.Drawing.Point(-24, 48);
			this.lmaqu.Name = "lmaqu";
			this.lmaqu.Size = new System.Drawing.Size(80, 23);
			this.lmaqu.TabIndex = 76;
			this.lmaqu.Text = "Quận/H :";
			this.lmaqu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lmatt
			// 
			this.lmatt.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.lmatt.Location = new System.Drawing.Point(600, 24);
			this.lmatt.Name = "lmatt";
			this.lmatt.Size = new System.Drawing.Size(56, 23);
			this.lmatt.TabIndex = 75;
			this.lmatt.Text = "Tỉnh/TP :";
			this.lmatt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// ltqx
			// 
			this.ltqx.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.ltqx.Location = new System.Drawing.Point(264, 24);
			this.ltqx.Name = "ltqx";
			this.ltqx.Size = new System.Drawing.Size(72, 23);
			this.ltqx.TabIndex = 74;
			this.ltqx.Text = "T/Q/PXã :";
			this.ltqx.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lcholam
			// 
			this.lcholam.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.lcholam.Location = new System.Drawing.Point(591, 47);
			this.lcholam.Name = "lcholam";
			this.lcholam.Size = new System.Drawing.Size(72, 23);
			this.lcholam.TabIndex = 73;
			this.lcholam.Text = "Nơi làm việc :";
			this.lcholam.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lthon
			// 
			this.lthon.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.lthon.Location = new System.Drawing.Point(0, 24);
			this.lthon.Name = "lthon";
			this.lthon.Size = new System.Drawing.Size(72, 23);
			this.lthon.TabIndex = 72;
			this.lthon.Text = "Thôn, phố :";
			this.lthon.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lsonha
			// 
			this.lsonha.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.lsonha.Location = new System.Drawing.Point(680, 0);
			this.lsonha.Name = "lsonha";
			this.lsonha.Size = new System.Drawing.Size(48, 23);
			this.lsonha.TabIndex = 70;
			this.lsonha.Text = "Số nhà :";
			this.lsonha.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lmadantoc
			// 
			this.lmadantoc.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.lmadantoc.Location = new System.Drawing.Point(360, 0);
			this.lmadantoc.Name = "lmadantoc";
			this.lmadantoc.Size = new System.Drawing.Size(56, 23);
			this.lmadantoc.TabIndex = 61;
			this.lmadantoc.Text = "Dân tộc :";
			this.lmadantoc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lmann
			// 
			this.lmann.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.lmann.Location = new System.Drawing.Point(108, 0);
			this.lmann.Name = "lmann";
			this.lmann.Size = new System.Drawing.Size(80, 23);
			this.lmann.TabIndex = 58;
			this.lmann.Text = "Nghề nghiệp :";
			this.lmann.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// psosinh
			// 
			this.psosinh.Controls.AddRange(new System.Windows.Forms.Control[] {
																				  this.mame,
																				  this.label17,
																				  this.ss_hoten_me,
																				  this.ss_ns_bo,
																				  this.label60,
																				  this.ss_mann_bo,
																				  this.ss_tennn_bo,
																				  this.label61,
																				  this.ss_hoten_bo,
																				  this.label62,
																				  this.ss_delan,
																				  this.label59,
																				  this.ss_ns_me,
																				  this.label58,
																				  this.ss_mann_me,
																				  this.ss_tennn_me,
																				  this.label56,
																				  this.label57});
			this.psosinh.Location = new System.Drawing.Point(0, 41);
			this.psosinh.Name = "psosinh";
			this.psosinh.Size = new System.Drawing.Size(888, 44);
			this.psosinh.TabIndex = 13;
			// 
			// mame
			// 
			this.mame.BackColor = System.Drawing.SystemColors.HighlightText;
			this.mame.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.mame.Location = new System.Drawing.Point(144, 0);
			this.mame.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
			this.mame.MaxLength = 8;
			this.mame.Name = "mame";
			this.mame.Size = new System.Drawing.Size(64, 21);
			this.mame.TabIndex = 0;
			this.mame.Text = "";
			this.mame.Validated += new System.EventHandler(this.mame_Validated);
			// 
			// label17
			// 
			this.label17.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.label17.Location = new System.Drawing.Point(96, -2);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(48, 23);
			this.label17.TabIndex = 69;
			this.label17.Text = "Mã mẹ :";
			this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// ss_hoten_me
			// 
			this.ss_hoten_me.BackColor = System.Drawing.SystemColors.HighlightText;
			this.ss_hoten_me.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.ss_hoten_me.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ss_hoten_me.Location = new System.Drawing.Point(250, 0);
			this.ss_hoten_me.Name = "ss_hoten_me";
			this.ss_hoten_me.Size = new System.Drawing.Size(120, 21);
			this.ss_hoten_me.TabIndex = 1;
			this.ss_hoten_me.Text = "";
			this.ss_hoten_me.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ss_hoten_me_KeyDown);
			this.ss_hoten_me.Validated += new System.EventHandler(this.ss_hoten_me_Validated);
			// 
			// ss_ns_bo
			// 
			this.ss_ns_bo.BackColor = System.Drawing.SystemColors.HighlightText;
			this.ss_ns_bo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ss_ns_bo.Location = new System.Drawing.Point(414, 22);
			this.ss_ns_bo.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
			this.ss_ns_bo.MaxLength = 4;
			this.ss_ns_bo.Name = "ss_ns_bo";
			this.ss_ns_bo.Size = new System.Drawing.Size(40, 21);
			this.ss_ns_bo.TabIndex = 7;
			this.ss_ns_bo.Text = "";
			this.ss_ns_bo.Validated += new System.EventHandler(this.ss_ns_bo_Validated);
			// 
			// label60
			// 
			this.label60.ForeColor = System.Drawing.SystemColors.ActiveCaption;
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
			this.ss_mann_bo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ss_mann_bo.Location = new System.Drawing.Point(575, 22);
			this.ss_mann_bo.MaxLength = 2;
			this.ss_mann_bo.Name = "ss_mann_bo";
			this.ss_mann_bo.Size = new System.Drawing.Size(24, 21);
			this.ss_mann_bo.TabIndex = 8;
			this.ss_mann_bo.Text = "";
			this.ss_mann_bo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ss_mann_bo_KeyDown);
			this.ss_mann_bo.Validated += new System.EventHandler(this.ss_mann_bo_Validated);
			// 
			// ss_tennn_bo
			// 
			this.ss_tennn_bo.BackColor = System.Drawing.SystemColors.HighlightText;
			this.ss_tennn_bo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ss_tennn_bo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ss_tennn_bo.Location = new System.Drawing.Point(600, 22);
			this.ss_tennn_bo.Name = "ss_tennn_bo";
			this.ss_tennn_bo.Size = new System.Drawing.Size(187, 21);
			this.ss_tennn_bo.TabIndex = 9;
			this.ss_tennn_bo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ss_tennn_bo_KeyDown);
			this.ss_tennn_bo.SelectedIndexChanged += new System.EventHandler(this.ss_tennn_bo_SelectedIndexChanged);
			// 
			// label61
			// 
			this.label61.ForeColor = System.Drawing.SystemColors.ActiveCaption;
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
			this.ss_hoten_bo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ss_hoten_bo.Location = new System.Drawing.Point(208, 22);
			this.ss_hoten_bo.Name = "ss_hoten_bo";
			this.ss_hoten_bo.Size = new System.Drawing.Size(120, 21);
			this.ss_hoten_bo.TabIndex = 6;
			this.ss_hoten_bo.Text = "";
			this.ss_hoten_bo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ss_hoten_bo_KeyDown);
			this.ss_hoten_bo.Validated += new System.EventHandler(this.ss_hoten_bo_Validated);
			// 
			// label62
			// 
			this.label62.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.label62.Location = new System.Drawing.Point(112, 21);
			this.label62.Name = "label62";
			this.label62.Size = new System.Drawing.Size(96, 23);
			this.label62.TabIndex = 60;
			this.label62.Text = "Họ tên bố :";
			this.label62.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// ss_delan
			// 
			this.ss_delan.BackColor = System.Drawing.SystemColors.HighlightText;
			this.ss_delan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ss_delan.Location = new System.Drawing.Point(59, 23);
			this.ss_delan.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
			this.ss_delan.MaxLength = 6;
			this.ss_delan.Name = "ss_delan";
			this.ss_delan.Size = new System.Drawing.Size(45, 21);
			this.ss_delan.TabIndex = 5;
			this.ss_delan.Text = "";
			this.ss_delan.Validated += new System.EventHandler(this.ss_delan_Validated);
			// 
			// label59
			// 
			this.label59.ForeColor = System.Drawing.SystemColors.ActiveCaption;
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
			this.ss_ns_me.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ss_ns_me.Location = new System.Drawing.Point(426, 0);
			this.ss_ns_me.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
			this.ss_ns_me.MaxLength = 4;
			this.ss_ns_me.Name = "ss_ns_me";
			this.ss_ns_me.Size = new System.Drawing.Size(40, 21);
			this.ss_ns_me.TabIndex = 2;
			this.ss_ns_me.Text = "";
			this.ss_ns_me.Validated += new System.EventHandler(this.ss_ns_me_Validated);
			// 
			// label58
			// 
			this.label58.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.label58.Location = new System.Drawing.Point(362, -2);
			this.label58.Name = "label58";
			this.label58.Size = new System.Drawing.Size(64, 23);
			this.label58.TabIndex = 36;
			this.label58.Text = "Năm sinh :";
			this.label58.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// ss_mann_me
			// 
			this.ss_mann_me.BackColor = System.Drawing.SystemColors.HighlightText;
			this.ss_mann_me.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ss_mann_me.Location = new System.Drawing.Point(575, 0);
			this.ss_mann_me.MaxLength = 2;
			this.ss_mann_me.Name = "ss_mann_me";
			this.ss_mann_me.Size = new System.Drawing.Size(24, 21);
			this.ss_mann_me.TabIndex = 3;
			this.ss_mann_me.Text = "";
			this.ss_mann_me.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ss_mann_me_KeyDown);
			this.ss_mann_me.Validated += new System.EventHandler(this.ss_mann_me_Validated);
			// 
			// ss_tennn_me
			// 
			this.ss_tennn_me.BackColor = System.Drawing.SystemColors.HighlightText;
			this.ss_tennn_me.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ss_tennn_me.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ss_tennn_me.Location = new System.Drawing.Point(600, 0);
			this.ss_tennn_me.Name = "ss_tennn_me";
			this.ss_tennn_me.Size = new System.Drawing.Size(187, 21);
			this.ss_tennn_me.TabIndex = 4;
			this.ss_tennn_me.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ss_tennn_me_KeyDown);
			this.ss_tennn_me.SelectedIndexChanged += new System.EventHandler(this.ss_tennn_me_SelectedIndexChanged);
			// 
			// label56
			// 
			this.label56.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.label56.Location = new System.Drawing.Point(458, -2);
			this.label56.Name = "label56";
			this.label56.Size = new System.Drawing.Size(120, 23);
			this.label56.TabIndex = 34;
			this.label56.Text = "Nghề nghiệp của mẹ :";
			this.label56.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label57
			// 
			this.label57.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.label57.Location = new System.Drawing.Point(202, -2);
			this.label57.Name = "label57";
			this.label57.Size = new System.Drawing.Size(48, 23);
			this.label57.TabIndex = 30;
			this.label57.Text = "Họ tên :";
			this.label57.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// phai
			// 
			this.phai.BackColor = System.Drawing.SystemColors.HighlightText;
			this.phai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.phai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.phai.Items.AddRange(new object[] {
													  "Nam",
													  "Nữ"});
			this.phai.Location = new System.Drawing.Point(59, 42);
			this.phai.Name = "phai";
			this.phai.Size = new System.Drawing.Size(43, 21);
			this.phai.TabIndex = 12;
			this.phai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.phai_KeyDown);
			this.phai.SelectedIndexChanged += new System.EventHandler(this.phai_SelectedIndexChanged);
			// 
			// lphai
			// 
			this.lphai.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.lphai.Location = new System.Drawing.Point(5, 41);
			this.lphai.Name = "lphai";
			this.lphai.Size = new System.Drawing.Size(56, 23);
			this.lphai.TabIndex = 161;
			this.lphai.Text = "Giới tính :";
			this.lphai.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// ppara
			// 
			this.ppara.Controls.AddRange(new System.Windows.Forms.Control[] {
																				this.label64,
																				this.ss_nhommau,
																				this.ss_para4,
																				this.ss_para3,
																				this.ss_para2,
																				this.ss_para1,
																				this.label63,
																				this.label8});
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
			this.ss_nhommau.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
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
			this.label8.Location = new System.Drawing.Point(-12, 0);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(88, 23);
			this.label8.TabIndex = 76;
			this.label8.Text = "Nhóm máu mẹ :";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// pvaovien
			// 
			this.pvaovien.Controls.AddRange(new System.Windows.Forms.Control[] {
																				   this.cd_vaokhoa,
																				   this.cd_noichuyenden,
																				   this.cd_kkb,
																				   this.tdvh,
																				   this.ngaybong,
																				   this.denngay,
																				   this.ngayvk,
																				   this.ngayvv,
																				   this.tenkp,
																				   this.lbong,
																				   this.ltdvh,
																				   this.label55,
																				   this.madoituong,
																				   this.tendentu,
																				   this.tendoituong,
																				   this.label32,
																				   this.icd_vaokhoa,
																				   this.lvaokhoa,
																				   this.icd_kkb,
																				   this.label34,
																				   this.icd_noichuyenden,
																				   this.label31,
																				   this.qh_dienthoai,
																				   this.qh_diachi,
																				   this.qh_hoten,
																				   this.quanhe,
																				   this.lanthu,
																				   this.sothe,
																				   this.sovaovien,
																				   this.label30,
																				   this.label29,
																				   this.label28,
																				   this.label27,
																				   this.label26,
																				   this.label25,
																				   this.label24,
																				   this.label23,
																				   this.tennhantu,
																				   this.label22,
																				   this.nhantu,
																				   this.dentu,
																				   this.label21,
																				   this.label20,
																				   this.label19,
																				   this.makp,
																				   this.label1,
																				   this.label53,
																				   this.khamthai,
																				   this.lbltieusu});
			this.pvaovien.Location = new System.Drawing.Point(-8, 144);
			this.pvaovien.Name = "pvaovien";
			this.pvaovien.Size = new System.Drawing.Size(800, 184);
			this.pvaovien.TabIndex = 17;
			// 
			// cd_vaokhoa
			// 
			this.cd_vaokhoa.BackColor = System.Drawing.SystemColors.HighlightText;
			this.cd_vaokhoa.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.cd_vaokhoa.Location = new System.Drawing.Point(178, 160);
			this.cd_vaokhoa.Name = "cd_vaokhoa";
			this.cd_vaokhoa.Size = new System.Drawing.Size(486, 21);
			this.cd_vaokhoa.TabIndex = 27;
			this.cd_vaokhoa.Text = "";
			this.cd_vaokhoa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cd_kkb_KeyDown);
			this.cd_vaokhoa.TextChanged += new System.EventHandler(this.cd_vaokhoa_TextChanged);
			// 
			// cd_noichuyenden
			// 
			this.cd_noichuyenden.BackColor = System.Drawing.SystemColors.HighlightText;
			this.cd_noichuyenden.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.cd_noichuyenden.Location = new System.Drawing.Point(178, 114);
			this.cd_noichuyenden.Name = "cd_noichuyenden";
			this.cd_noichuyenden.Size = new System.Drawing.Size(486, 21);
			this.cd_noichuyenden.TabIndex = 23;
			this.cd_noichuyenden.Text = "";
			this.cd_noichuyenden.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cd_kkb_KeyDown);
			this.cd_noichuyenden.TextChanged += new System.EventHandler(this.cd_noichuyenden_TextChanged);
			// 
			// cd_kkb
			// 
			this.cd_kkb.BackColor = System.Drawing.SystemColors.HighlightText;
			this.cd_kkb.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.cd_kkb.Location = new System.Drawing.Point(178, 137);
			this.cd_kkb.Name = "cd_kkb";
			this.cd_kkb.Size = new System.Drawing.Size(486, 21);
			this.cd_kkb.TabIndex = 25;
			this.cd_kkb.Text = "";
			this.cd_kkb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cd_kkb_KeyDown);
			this.cd_kkb.TextChanged += new System.EventHandler(this.cd_kkb_TextChanged);
			// 
			// ngaybong
			// 
			this.ngaybong.BackColor = System.Drawing.SystemColors.HighlightText;
			this.ngaybong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ngaybong.Location = new System.Drawing.Point(434, 45);
			this.ngaybong.Mask = "##/##/#### ##:##";
			this.ngaybong.Name = "ngaybong";
			this.ngaybong.Size = new System.Drawing.Size(94, 21);
			this.ngaybong.TabIndex = 10;
			this.ngaybong.Text = "";
			this.ngaybong.Validated += new System.EventHandler(this.ngaybong_Validated);
			// 
			// denngay
			// 
			this.denngay.BackColor = System.Drawing.SystemColors.HighlightText;
			this.denngay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.denngay.Location = new System.Drawing.Point(464, 68);
			this.denngay.Mask = "##/##/####";
			this.denngay.Name = "denngay";
			this.denngay.Size = new System.Drawing.Size(64, 21);
			this.denngay.TabIndex = 16;
			this.denngay.Text = "";
			this.denngay.Validated += new System.EventHandler(this.denngay_Validated);
			// 
			// ngayvk
			// 
			this.ngayvk.BackColor = System.Drawing.SystemColors.HighlightText;
			this.ngayvk.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ngayvk.Location = new System.Drawing.Point(117, 45);
			this.ngayvk.Mask = "##/##/#### ##:##";
			this.ngayvk.Name = "ngayvk";
			this.ngayvk.Size = new System.Drawing.Size(94, 21);
			this.ngayvk.TabIndex = 7;
			this.ngayvk.Text = "";
			this.ngayvk.Validated += new System.EventHandler(this.ngayvk_Validated);
			// 
			// ngayvv
			// 
			this.ngayvv.BackColor = System.Drawing.SystemColors.HighlightText;
			this.ngayvv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ngayvv.Location = new System.Drawing.Point(117, 22);
			this.ngayvv.Mask = "##/##/#### ##:##";
			this.ngayvv.Name = "ngayvv";
			this.ngayvv.Size = new System.Drawing.Size(94, 21);
			this.ngayvv.TabIndex = 1;
			this.ngayvv.Text = "";
			this.ngayvv.Validated += new System.EventHandler(this.ngayvv_Validated);
			// 
			// tenkp
			// 
			this.tenkp.BackColor = System.Drawing.SystemColors.HighlightText;
			this.tenkp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.tenkp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tenkp.Location = new System.Drawing.Point(304, 45);
			this.tenkp.Name = "tenkp";
			this.tenkp.Size = new System.Drawing.Size(80, 21);
			this.tenkp.TabIndex = 9;
			this.tenkp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenkp_KeyDown);
			this.tenkp.SelectedIndexChanged += new System.EventHandler(this.tenkp_SelectedIndexChanged);
			// 
			// lbong
			// 
			this.lbong.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.lbong.Location = new System.Drawing.Point(364, 45);
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
			this.ltdvh.Location = new System.Drawing.Point(388, 45);
			this.ltdvh.Name = "ltdvh";
			this.ltdvh.Size = new System.Drawing.Size(48, 23);
			this.ltdvh.TabIndex = 209;
			this.ltdvh.Text = "TĐVH :";
			this.ltdvh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.ltdvh.Visible = false;
			// 
			// label55
			// 
			this.label55.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, (System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline), System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label55.ForeColor = System.Drawing.SystemColors.Highlight;
			this.label55.Location = new System.Drawing.Point(672, 1);
			this.label55.Name = "label55";
			this.label55.Size = new System.Drawing.Size(128, 23);
			this.label55.TabIndex = 207;
			this.label55.Text = "CÁC LẦN VÀO VIỆN :";
			this.label55.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// madoituong
			// 
			this.madoituong.BackColor = System.Drawing.SystemColors.HighlightText;
			this.madoituong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.madoituong.Location = new System.Drawing.Point(117, 68);
			this.madoituong.Name = "madoituong";
			this.madoituong.Size = new System.Drawing.Size(18, 21);
			this.madoituong.TabIndex = 13;
			this.madoituong.Text = "";
			this.madoituong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.madoituong_KeyDown);
			this.madoituong.Validated += new System.EventHandler(this.madoituong_Validated);
			// 
			// tendentu
			// 
			this.tendentu.BackColor = System.Drawing.SystemColors.HighlightText;
			this.tendentu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.tendentu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tendentu.Location = new System.Drawing.Point(485, 22);
			this.tendentu.Name = "tendentu";
			this.tendentu.Size = new System.Drawing.Size(87, 21);
			this.tendentu.TabIndex = 5;
			this.tendentu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tendentu_KeyDown);
			this.tendentu.SelectedIndexChanged += new System.EventHandler(this.tendentu_SelectedIndexChanged);
			// 
			// tendoituong
			// 
			this.tendoituong.BackColor = System.Drawing.SystemColors.HighlightText;
			this.tendoituong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.tendoituong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tendoituong.Location = new System.Drawing.Point(136, 68);
			this.tendoituong.Name = "tendoituong";
			this.tendoituong.Size = new System.Drawing.Size(104, 21);
			this.tendoituong.TabIndex = 14;
			this.tendoituong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tendoituong_KeyDown);
			this.tendoituong.SelectedIndexChanged += new System.EventHandler(this.tendoituong_SelectedIndexChanged);
			// 
			// label32
			// 
			this.label32.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.label32.Location = new System.Drawing.Point(8, 45);
			this.label32.Name = "label32";
			this.label32.Size = new System.Drawing.Size(112, 23);
			this.label32.TabIndex = 208;
			this.label32.Text = "Ngày giờ vào khoa :";
			this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// icd_vaokhoa
			// 
			this.icd_vaokhoa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.icd_vaokhoa.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.icd_vaokhoa.Location = new System.Drawing.Point(117, 160);
			this.icd_vaokhoa.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
			this.icd_vaokhoa.MaxLength = 9;
			this.icd_vaokhoa.Name = "icd_vaokhoa";
			this.icd_vaokhoa.Size = new System.Drawing.Size(59, 21);
			this.icd_vaokhoa.TabIndex = 26;
			this.icd_vaokhoa.Text = "";
			this.icd_vaokhoa.Validated += new System.EventHandler(this.icd_vaokhoa_Validated);
			this.icd_vaokhoa.TextChanged += new System.EventHandler(this.icd_noichuyenden_TextChanged);
			// 
			// lvaokhoa
			// 
			this.lvaokhoa.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.lvaokhoa.Location = new System.Drawing.Point(1, 159);
			this.lvaokhoa.Name = "lvaokhoa";
			this.lvaokhoa.Size = new System.Drawing.Size(120, 23);
			this.lvaokhoa.TabIndex = 204;
			this.lvaokhoa.Text = "CĐ khoa điều trị :";
			this.lvaokhoa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// icd_kkb
			// 
			this.icd_kkb.BackColor = System.Drawing.SystemColors.HighlightText;
			this.icd_kkb.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.icd_kkb.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.icd_kkb.Location = new System.Drawing.Point(117, 137);
			this.icd_kkb.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
			this.icd_kkb.MaxLength = 9;
			this.icd_kkb.Name = "icd_kkb";
			this.icd_kkb.Size = new System.Drawing.Size(59, 21);
			this.icd_kkb.TabIndex = 24;
			this.icd_kkb.Text = "";
			this.icd_kkb.Validated += new System.EventHandler(this.icd_kkb_Validated);
			this.icd_kkb.TextChanged += new System.EventHandler(this.icd_noichuyenden_TextChanged);
			// 
			// label34
			// 
			this.label34.ForeColor = System.Drawing.SystemColors.ActiveCaption;
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
			this.icd_noichuyenden.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.icd_noichuyenden.Location = new System.Drawing.Point(117, 114);
			this.icd_noichuyenden.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
			this.icd_noichuyenden.MaxLength = 9;
			this.icd_noichuyenden.Name = "icd_noichuyenden";
			this.icd_noichuyenden.Size = new System.Drawing.Size(59, 21);
			this.icd_noichuyenden.TabIndex = 22;
			this.icd_noichuyenden.Text = "";
			this.icd_noichuyenden.Validated += new System.EventHandler(this.icd_noichuyenden_Validated);
			this.icd_noichuyenden.TextChanged += new System.EventHandler(this.icd_noichuyenden_TextChanged);
			// 
			// label31
			// 
			this.label31.ForeColor = System.Drawing.SystemColors.ActiveCaption;
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
			this.qh_dienthoai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.qh_dienthoai.Location = new System.Drawing.Point(600, 91);
			this.qh_dienthoai.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
			this.qh_dienthoai.MaxLength = 20;
			this.qh_dienthoai.Name = "qh_dienthoai";
			this.qh_dienthoai.Size = new System.Drawing.Size(64, 21);
			this.qh_dienthoai.TabIndex = 21;
			this.qh_dienthoai.Text = "";
			// 
			// qh_diachi
			// 
			this.qh_diachi.BackColor = System.Drawing.SystemColors.HighlightText;
			this.qh_diachi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.qh_diachi.Location = new System.Drawing.Point(416, 91);
			this.qh_diachi.Name = "qh_diachi";
			this.qh_diachi.Size = new System.Drawing.Size(120, 21);
			this.qh_diachi.TabIndex = 20;
			this.qh_diachi.Text = "";
			this.qh_diachi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.qh_diachi_KeyDown);
			this.qh_diachi.Validated += new System.EventHandler(this.qh_diachi_Validated);
			// 
			// qh_hoten
			// 
			this.qh_hoten.BackColor = System.Drawing.SystemColors.HighlightText;
			this.qh_hoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.qh_hoten.Location = new System.Drawing.Point(224, 91);
			this.qh_hoten.Name = "qh_hoten";
			this.qh_hoten.Size = new System.Drawing.Size(147, 21);
			this.qh_hoten.TabIndex = 19;
			this.qh_hoten.Text = "";
			this.qh_hoten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.qh_hoten_KeyDown);
			this.qh_hoten.Validated += new System.EventHandler(this.qh_hoten_Validated);
			// 
			// quanhe
			// 
			this.quanhe.BackColor = System.Drawing.SystemColors.HighlightText;
			this.quanhe.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.quanhe.Location = new System.Drawing.Point(117, 91);
			this.quanhe.Name = "quanhe";
			this.quanhe.Size = new System.Drawing.Size(64, 21);
			this.quanhe.TabIndex = 18;
			this.quanhe.Text = "";
			this.quanhe.KeyDown += new System.Windows.Forms.KeyEventHandler(this.quanhe_KeyDown);
			this.quanhe.Validated += new System.EventHandler(this.quanhe_Validated);
			// 
			// sothe
			// 
			this.sothe.BackColor = System.Drawing.SystemColors.HighlightText;
			this.sothe.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.sothe.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.sothe.Location = new System.Drawing.Point(283, 68);
			this.sothe.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
			this.sothe.MaxLength = 20;
			this.sothe.Name = "sothe";
			this.sothe.Size = new System.Drawing.Size(120, 21);
			this.sothe.TabIndex = 15;
			this.sothe.Text = "";
			this.sothe.Validated += new System.EventHandler(this.sothe_Validated);
			// 
			// sovaovien
			// 
			this.sovaovien.BackColor = System.Drawing.SystemColors.HighlightText;
			this.sovaovien.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.sovaovien.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.sovaovien.Location = new System.Drawing.Point(599, 68);
			this.sovaovien.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
			this.sovaovien.MaxLength = 10;
			this.sovaovien.Name = "sovaovien";
			this.sovaovien.Size = new System.Drawing.Size(65, 21);
			this.sovaovien.TabIndex = 17;
			this.sovaovien.Text = "";
			this.sovaovien.Validated += new System.EventHandler(this.sovaovien_Validated);
			// 
			// label30
			// 
			this.label30.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.label30.Location = new System.Drawing.Point(528, 68);
			this.label30.Name = "label30";
			this.label30.Size = new System.Drawing.Size(72, 23);
			this.label30.TabIndex = 201;
			this.label30.Text = "Số vào viện :";
			this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label29
			// 
			this.label29.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.label29.Location = new System.Drawing.Point(536, 91);
			this.label29.Name = "label29";
			this.label29.Size = new System.Drawing.Size(64, 23);
			this.label29.TabIndex = 200;
			this.label29.Text = "Điện thoại :";
			this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label28
			// 
			this.label28.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.label28.Location = new System.Drawing.Point(352, 91);
			this.label28.Name = "label28";
			this.label28.Size = new System.Drawing.Size(64, 23);
			this.label28.TabIndex = 199;
			this.label28.Text = "Địa chỉ :";
			this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label27
			// 
			this.label27.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.label27.Location = new System.Drawing.Point(128, 91);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(96, 23);
			this.label27.TabIndex = 198;
			this.label27.Text = "Họ tên :";
			this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label26
			// 
			this.label26.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.label26.Location = new System.Drawing.Point(-17, 90);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(136, 23);
			this.label26.TabIndex = 197;
			this.label26.Text = "Người nhà, quan hệ :";
			this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label25
			// 
			this.label25.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.label25.Location = new System.Drawing.Point(400, 68);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(64, 23);
			this.label25.TabIndex = 196;
			this.label25.Text = "Đến ngày :";
			this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label24
			// 
			this.label24.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.label24.Location = new System.Drawing.Point(190, 68);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(96, 23);
			this.label24.TabIndex = 195;
			this.label24.Text = "Số thẻ :";
			this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label23
			// 
			this.label23.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.label23.Location = new System.Drawing.Point(32, 68);
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
			this.tennhantu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tennhantu.Location = new System.Drawing.Point(304, 22);
			this.tennhantu.Name = "tennhantu";
			this.tennhantu.Size = new System.Drawing.Size(87, 21);
			this.tennhantu.TabIndex = 3;
			this.tennhantu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tennhantu_KeyDown);
			this.tennhantu.SelectedIndexChanged += new System.EventHandler(this.tennhantu_SelectedIndexChanged);
			// 
			// label22
			// 
			this.label22.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.label22.Location = new System.Drawing.Point(568, 22);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(72, 23);
			this.label22.TabIndex = 193;
			this.label22.Text = "Lần thứ :";
			this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// nhantu
			// 
			this.nhantu.BackColor = System.Drawing.SystemColors.HighlightText;
			this.nhantu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.nhantu.Location = new System.Drawing.Point(284, 22);
			this.nhantu.Name = "nhantu";
			this.nhantu.Size = new System.Drawing.Size(18, 21);
			this.nhantu.TabIndex = 2;
			this.nhantu.Text = "";
			this.nhantu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nhantu_KeyDown);
			this.nhantu.Validated += new System.EventHandler(this.nhantu_Validated);
			// 
			// dentu
			// 
			this.dentu.BackColor = System.Drawing.SystemColors.HighlightText;
			this.dentu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.dentu.Location = new System.Drawing.Point(465, 22);
			this.dentu.Name = "dentu";
			this.dentu.Size = new System.Drawing.Size(18, 21);
			this.dentu.TabIndex = 4;
			this.dentu.Text = "";
			this.dentu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dentu_KeyDown);
			this.dentu.Validated += new System.EventHandler(this.dentu_Validated);
			// 
			// label21
			// 
			this.label21.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.label21.Location = new System.Drawing.Point(384, 22);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(87, 23);
			this.label21.TabIndex = 191;
			this.label21.Text = "Nơi giới thiệu :";
			this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label20
			// 
			this.label20.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.label20.Location = new System.Drawing.Point(206, 22);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(80, 23);
			this.label20.TabIndex = 186;
			this.label20.Text = "Nhận từ :";
			this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label19
			// 
			this.label19.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.label19.Location = new System.Drawing.Point(0, 22);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(120, 23);
			this.label19.TabIndex = 0;
			this.label19.Text = "Ngày giờ &vào viện :";
			this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// makp
			// 
			this.makp.BackColor = System.Drawing.SystemColors.HighlightText;
			this.makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.makp.Location = new System.Drawing.Point(284, 45);
			this.makp.Name = "makp";
			this.makp.Size = new System.Drawing.Size(18, 21);
			this.makp.TabIndex = 8;
			this.makp.Text = "";
			this.makp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.makp_KeyDown);
			this.makp.Validated += new System.EventHandler(this.makp_Validated);
			// 
			// label1
			// 
			this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.label1.Location = new System.Drawing.Point(215, 45);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(71, 23);
			this.label1.TabIndex = 165;
			this.label1.Text = "Nơi chuyển :";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label53
			// 
			this.label53.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, (System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline), System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label53.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.label53.Location = new System.Drawing.Point(16, 1);
			this.label53.Name = "label53";
			this.label53.Size = new System.Drawing.Size(160, 23);
			this.label53.TabIndex = 0;
			this.label53.Text = "II. THÔNG TIN VÀO KHOA :";
			this.label53.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// khamthai
			// 
			this.khamthai.Controls.AddRange(new System.Windows.Forms.Control[] {
																				   this.para4,
																				   this.para3,
																				   this.para2,
																				   this.para1,
																				   this.label18});
			this.khamthai.Location = new System.Drawing.Point(538, 44);
			this.khamthai.Name = "khamthai";
			this.khamthai.Size = new System.Drawing.Size(128, 24);
			this.khamthai.TabIndex = 12;
			// 
			// para4
			// 
			this.para4.BackColor = System.Drawing.SystemColors.HighlightText;
			this.para4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.para4.Location = new System.Drawing.Point(104, 1);
			this.para4.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
			this.para4.MaxLength = 2;
			this.para4.Name = "para4";
			this.para4.Size = new System.Drawing.Size(22, 21);
			this.para4.TabIndex = 3;
			this.para4.Text = "";
			this.para4.Validated += new System.EventHandler(this.para4_Validated);
			// 
			// para3
			// 
			this.para3.BackColor = System.Drawing.SystemColors.HighlightText;
			this.para3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.para3.Location = new System.Drawing.Point(80, 1);
			this.para3.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
			this.para3.MaxLength = 2;
			this.para3.Name = "para3";
			this.para3.Size = new System.Drawing.Size(22, 21);
			this.para3.TabIndex = 2;
			this.para3.Text = "";
			this.para3.Validated += new System.EventHandler(this.para3_Validated);
			// 
			// para2
			// 
			this.para2.BackColor = System.Drawing.SystemColors.HighlightText;
			this.para2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.para2.Location = new System.Drawing.Point(56, 1);
			this.para2.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
			this.para2.MaxLength = 2;
			this.para2.Name = "para2";
			this.para2.Size = new System.Drawing.Size(22, 21);
			this.para2.TabIndex = 1;
			this.para2.Text = "";
			this.para2.Validated += new System.EventHandler(this.para2_Validated);
			// 
			// para1
			// 
			this.para1.BackColor = System.Drawing.SystemColors.HighlightText;
			this.para1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.para1.Location = new System.Drawing.Point(32, 1);
			this.para1.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
			this.para1.MaxLength = 2;
			this.para1.Name = "para1";
			this.para1.Size = new System.Drawing.Size(22, 21);
			this.para1.TabIndex = 0;
			this.para1.Text = "";
			this.para1.Validated += new System.EventHandler(this.para1_Validated);
			// 
			// label18
			// 
			this.label18.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.label18.Location = new System.Drawing.Point(-3, 5);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(32, 15);
			this.label18.TabIndex = 0;
			this.label18.Text = "Para :";
			this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lbltieusu
			// 
			this.lbltieusu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lbltieusu.Location = new System.Drawing.Point(528, 4);
			this.lbltieusu.Name = "lbltieusu";
			this.lbltieusu.Size = new System.Drawing.Size(136, 16);
			this.lbltieusu.TabIndex = 253;
			this.lbltieusu.Text = "Tiểu sử người bệnh (^S)";
			this.lbltieusu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.lbltieusu.Click += new System.EventHandler(this.lbltieusu_Click);
			// 
			// psankhoa
			// 
			this.psankhoa.Controls.AddRange(new System.Windows.Forms.Control[] {
																				   this.tentb,
																				   this.matb,
																				   this.cachthucde,
																				   this.label67,
																				   this.ngayde,
																				   this.kiemsoat,
																				   this.label10,
																				   this.label9});
			this.psankhoa.Location = new System.Drawing.Point(1, 480);
			this.psankhoa.Name = "psankhoa";
			this.psankhoa.Size = new System.Drawing.Size(800, 22);
			this.psankhoa.TabIndex = 18;
			// 
			// tentb
			// 
			this.tentb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.tentb.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tentb.Location = new System.Drawing.Point(456, 0);
			this.tentb.Name = "tentb";
			this.tentb.Size = new System.Drawing.Size(128, 21);
			this.tentb.TabIndex = 3;
			this.tentb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tentb_KeyDown);
			this.tentb.SelectedIndexChanged += new System.EventHandler(this.tentb_SelectedIndexChanged);
			// 
			// matb
			// 
			this.matb.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.matb.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.matb.Location = new System.Drawing.Point(408, 0);
			this.matb.Name = "matb";
			this.matb.Size = new System.Drawing.Size(48, 21);
			this.matb.TabIndex = 2;
			this.matb.Text = "";
			this.matb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.matb_KeyDown);
			this.matb.Validated += new System.EventHandler(this.matb_Validated);
			// 
			// cachthucde
			// 
			this.cachthucde.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cachthucde.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.cachthucde.Location = new System.Drawing.Point(256, 0);
			this.cachthucde.Name = "cachthucde";
			this.cachthucde.Size = new System.Drawing.Size(112, 21);
			this.cachthucde.TabIndex = 1;
			this.cachthucde.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cachthucde_KeyDown);
			// 
			// label67
			// 
			this.label67.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.label67.Location = new System.Drawing.Point(348, 0);
			this.label67.Name = "label67";
			this.label67.Size = new System.Drawing.Size(60, 23);
			this.label67.TabIndex = 207;
			this.label67.Text = "Tai biến";
			this.label67.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// ngayde
			// 
			this.ngayde.BackColor = System.Drawing.SystemColors.HighlightText;
			this.ngayde.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ngayde.Location = new System.Drawing.Point(108, 0);
			this.ngayde.Mask = "##/##/#### ##:##";
			this.ngayde.Name = "ngayde";
			this.ngayde.Size = new System.Drawing.Size(94, 21);
			this.ngayde.TabIndex = 0;
			this.ngayde.Text = "";
			this.ngayde.Validated += new System.EventHandler(this.ngayde_Validated);
			// 
			// kiemsoat
			// 
			this.kiemsoat.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.kiemsoat.Location = new System.Drawing.Point(584, 0);
			this.kiemsoat.Name = "kiemsoat";
			this.kiemsoat.Size = new System.Drawing.Size(96, 24);
			this.kiemsoat.TabIndex = 4;
			this.kiemsoat.Text = "KS tử cung";
			this.kiemsoat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.kiemsoat_KeyDown);
			// 
			// label10
			// 
			this.label10.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.label10.Location = new System.Drawing.Point(152, 1);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(104, 23);
			this.label10.TabIndex = 206;
			this.label10.Text = "Cách thức";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label9
			// 
			this.label9.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.label9.Location = new System.Drawing.Point(7, 0);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(104, 23);
			this.label9.TabIndex = 204;
			this.label9.Text = "Ngày đẻ (mổ đẻ) :";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// pungbuou_v
			// 
			this.pungbuou_v.Controls.AddRange(new System.Windows.Forms.Control[] {
																					 this.giaidoan_v,
																					 this.m_v,
																					 this.n_v,
																					 this.t_v,
																					 this.label15,
																					 this.label13,
																					 this.label12,
																					 this.label11});
			this.pungbuou_v.Location = new System.Drawing.Point(0, 504);
			this.pungbuou_v.Name = "pungbuou_v";
			this.pungbuou_v.Size = new System.Drawing.Size(800, 21);
			this.pungbuou_v.TabIndex = 19;
			this.pungbuou_v.Visible = false;
			// 
			// giaidoan_v
			// 
			this.giaidoan_v.BackColor = System.Drawing.SystemColors.HighlightText;
			this.giaidoan_v.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.giaidoan_v.Location = new System.Drawing.Point(547, 0);
			this.giaidoan_v.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
			this.giaidoan_v.MaxLength = 50;
			this.giaidoan_v.Name = "giaidoan_v";
			this.giaidoan_v.Size = new System.Drawing.Size(109, 21);
			this.giaidoan_v.TabIndex = 3;
			this.giaidoan_v.Text = "";
			// 
			// m_v
			// 
			this.m_v.BackColor = System.Drawing.SystemColors.HighlightText;
			this.m_v.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_v.Location = new System.Drawing.Point(380, 0);
			this.m_v.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
			this.m_v.MaxLength = 50;
			this.m_v.Name = "m_v";
			this.m_v.Size = new System.Drawing.Size(110, 21);
			this.m_v.TabIndex = 2;
			this.m_v.Text = "";
			// 
			// n_v
			// 
			this.n_v.BackColor = System.Drawing.SystemColors.HighlightText;
			this.n_v.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.n_v.Location = new System.Drawing.Point(245, 0);
			this.n_v.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
			this.n_v.MaxLength = 50;
			this.n_v.Name = "n_v";
			this.n_v.Size = new System.Drawing.Size(110, 21);
			this.n_v.TabIndex = 1;
			this.n_v.Text = "";
			// 
			// t_v
			// 
			this.t_v.BackColor = System.Drawing.SystemColors.HighlightText;
			this.t_v.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.t_v.Location = new System.Drawing.Point(109, 0);
			this.t_v.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
			this.t_v.MaxLength = 50;
			this.t_v.Name = "t_v";
			this.t_v.Size = new System.Drawing.Size(110, 21);
			this.t_v.TabIndex = 0;
			this.t_v.Text = "";
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
			// treeView1
			// 
			this.treeView1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.treeView1.ImageIndex = -1;
			this.treeView1.Location = new System.Drawing.Point(665, 168);
			this.treeView1.Name = "treeView1";
			this.treeView1.SelectedImageIndex = -1;
			this.treeView1.Size = new System.Drawing.Size(120, 104);
			this.treeView1.TabIndex = 207;
			this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
			// 
			// treeView2
			// 
			this.treeView2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.treeView2.ImageIndex = -1;
			this.treeView2.Location = new System.Drawing.Point(665, 304);
			this.treeView2.Name = "treeView2";
			this.treeView2.SelectedImageIndex = -1;
			this.treeView2.Size = new System.Drawing.Size(120, 80);
			this.treeView2.TabIndex = 208;
			this.treeView2.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView2_AfterSelect);
			// 
			// label16
			// 
			this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, (System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline), System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label16.ForeColor = System.Drawing.SystemColors.Highlight;
			this.label16.Location = new System.Drawing.Point(664, 285);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(128, 16);
			this.label16.TabIndex = 209;
			this.label16.Text = "CÁC LẦN VÀO KHOA :";
			this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// l_tainantt
			// 
			this.l_tainantt.BackColor = System.Drawing.Color.Transparent;
			this.l_tainantt.Cursor = System.Windows.Forms.Cursors.Hand;
			this.l_tainantt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.l_tainantt.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.l_tainantt.Image = ((System.Drawing.Bitmap)(resources.GetObject("l_tainantt.Image")));
			this.l_tainantt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.l_tainantt.Location = new System.Drawing.Point(673, 450);
			this.l_tainantt.Name = "l_tainantt";
			this.l_tainantt.Size = new System.Drawing.Size(134, 14);
			this.l_tainantt.TabIndex = 215;
			this.l_tainantt.Text = "       Tai nạn,thương tích";
			this.l_tainantt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.l_tainantt.Click += new System.EventHandler(this.l_tainantt_Click);
			// 
			// tainantt
			// 
			this.tainantt.BackColor = System.Drawing.Color.Transparent;
			this.tainantt.Enabled = false;
			this.tainantt.Location = new System.Drawing.Point(660, 450);
			this.tainantt.Name = "tainantt";
			this.tainantt.Size = new System.Drawing.Size(16, 14);
			this.tainantt.TabIndex = 214;
			// 
			// ngaysinh
			// 
			this.ngaysinh.BackColor = System.Drawing.SystemColors.HighlightText;
			this.ngaysinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ngaysinh.Location = new System.Drawing.Point(512, 19);
			this.ngaysinh.Mask = "##/##/####";
			this.ngaysinh.Name = "ngaysinh";
			this.ngaysinh.Size = new System.Drawing.Size(64, 21);
			this.ngaysinh.TabIndex = 8;
			this.ngaysinh.Text = "";
			this.ngaysinh.Validated += new System.EventHandler(this.ngaysinh_Validated);
			// 
			// butIn
			// 
			this.butIn.BackColor = System.Drawing.SystemColors.Control;
			this.butIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.butIn.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.butIn.Image = ((System.Drawing.Bitmap)(resources.GetObject("butIn.Image")));
			this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butIn.Location = new System.Drawing.Point(24, 432);
			this.butIn.Name = "butIn";
			this.butIn.Size = new System.Drawing.Size(75, 28);
			this.butIn.TabIndex = 45;
			this.butIn.Text = "          &In";
			this.butIn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butIn.Visible = false;
			this.butIn.Click += new System.EventHandler(this.butIn_Click);
			// 
			// listICD
			// 
			this.listICD.BackColor = System.Drawing.SystemColors.Info;
			this.listICD.ColumnCount = 0;
			this.listICD.Location = new System.Drawing.Point(568, 440);
			this.listICD.MatchBufferTimeOut = 1000;
			this.listICD.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
			this.listICD.Name = "listICD";
			this.listICD.Size = new System.Drawing.Size(75, 17);
			this.listICD.TabIndex = 219;
			this.listICD.TextIndex = -1;
			this.listICD.TextMember = null;
			this.listICD.ValueIndex = -1;
			this.listICD.Visible = false;
			// 
			// cd_kemtheo
			// 
			this.cd_kemtheo.BackColor = System.Drawing.SystemColors.HighlightText;
			this.cd_kemtheo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.cd_kemtheo.Location = new System.Drawing.Point(170, 339);
			this.cd_kemtheo.Name = "cd_kemtheo";
			this.cd_kemtheo.Size = new System.Drawing.Size(486, 21);
			this.cd_kemtheo.TabIndex = 32;
			this.cd_kemtheo.Text = "";
			this.cd_kemtheo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cd_kkb_KeyDown);
			this.cd_kemtheo.TextChanged += new System.EventHandler(this.cd_kemtheo_TextChanged);
			// 
			// chidinh
			// 
			this.chidinh.BackColor = System.Drawing.Color.Transparent;
			this.chidinh.Enabled = false;
			this.chidinh.Location = new System.Drawing.Point(660, 419);
			this.chidinh.Name = "chidinh";
			this.chidinh.Size = new System.Drawing.Size(16, 14);
			this.chidinh.TabIndex = 225;
			// 
			// l_chidinh
			// 
			this.l_chidinh.BackColor = System.Drawing.Color.Transparent;
			this.l_chidinh.Cursor = System.Windows.Forms.Cursors.Hand;
			this.l_chidinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.l_chidinh.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.l_chidinh.Image = ((System.Drawing.Bitmap)(resources.GetObject("l_chidinh.Image")));
			this.l_chidinh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.l_chidinh.Location = new System.Drawing.Point(673, 419);
			this.l_chidinh.Name = "l_chidinh";
			this.l_chidinh.Size = new System.Drawing.Size(120, 14);
			this.l_chidinh.TabIndex = 226;
			this.l_chidinh.Text = "       Chỉ định dịch vụ";
			this.l_chidinh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.l_chidinh.Click += new System.EventHandler(this.l_chidinh_Click);
			// 
			// vienphi
			// 
			this.vienphi.BackColor = System.Drawing.Color.Transparent;
			this.vienphi.Enabled = false;
			this.vienphi.Location = new System.Drawing.Point(660, 435);
			this.vienphi.Name = "vienphi";
			this.vienphi.Size = new System.Drawing.Size(16, 14);
			this.vienphi.TabIndex = 227;
			// 
			// l_vienphi
			// 
			this.l_vienphi.BackColor = System.Drawing.Color.Transparent;
			this.l_vienphi.Cursor = System.Windows.Forms.Cursors.Hand;
			this.l_vienphi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.l_vienphi.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.l_vienphi.Image = ((System.Drawing.Bitmap)(resources.GetObject("l_vienphi.Image")));
			this.l_vienphi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.l_vienphi.Location = new System.Drawing.Point(673, 435);
			this.l_vienphi.Name = "l_vienphi";
			this.l_vienphi.Size = new System.Drawing.Size(120, 14);
			this.l_vienphi.TabIndex = 228;
			this.l_vienphi.Text = "       Viện phí";
			this.l_vienphi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.l_vienphi.Click += new System.EventHandler(this.l_vienphi_Click);
			// 
			// l_cls
			// 
			this.l_cls.BackColor = System.Drawing.Color.Transparent;
			this.l_cls.Cursor = System.Windows.Forms.Cursors.Hand;
			this.l_cls.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.l_cls.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.l_cls.Image = ((System.Drawing.Bitmap)(resources.GetObject("l_cls.Image")));
			this.l_cls.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.l_cls.Location = new System.Drawing.Point(673, 483);
			this.l_cls.Name = "l_cls";
			this.l_cls.Size = new System.Drawing.Size(134, 14);
			this.l_cls.TabIndex = 234;
			this.l_cls.Text = "        Xem cận lâm sàng";
			this.l_cls.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.l_cls.Click += new System.EventHandler(this.l_cls_Click);
			// 
			// cls
			// 
			this.cls.BackColor = System.Drawing.Color.Transparent;
			this.cls.Enabled = false;
			this.cls.Location = new System.Drawing.Point(660, 483);
			this.cls.Name = "cls";
			this.cls.Size = new System.Drawing.Size(16, 14);
			this.cls.TabIndex = 233;
			// 
			// l_kemtheo
			// 
			this.l_kemtheo.BackColor = System.Drawing.Color.Transparent;
			this.l_kemtheo.Cursor = System.Windows.Forms.Cursors.Hand;
			this.l_kemtheo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.l_kemtheo.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.l_kemtheo.Image = ((System.Drawing.Bitmap)(resources.GetObject("l_kemtheo.Image")));
			this.l_kemtheo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.l_kemtheo.Location = new System.Drawing.Point(673, 466);
			this.l_kemtheo.Name = "l_kemtheo";
			this.l_kemtheo.Size = new System.Drawing.Size(134, 14);
			this.l_kemtheo.TabIndex = 232;
			this.l_kemtheo.Text = "       Bệnh kèm theo";
			this.l_kemtheo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.l_kemtheo.Click += new System.EventHandler(this.l_kemtheo_Click);
			// 
			// kemtheo
			// 
			this.kemtheo.BackColor = System.Drawing.Color.Transparent;
			this.kemtheo.Enabled = false;
			this.kemtheo.Location = new System.Drawing.Point(660, 466);
			this.kemtheo.Name = "kemtheo";
			this.kemtheo.Size = new System.Drawing.Size(16, 14);
			this.kemtheo.TabIndex = 231;
			// 
			// diungthuoc
			// 
			this.diungthuoc.BackColor = System.Drawing.Color.Transparent;
			this.diungthuoc.Enabled = false;
			this.diungthuoc.Location = new System.Drawing.Point(660, 499);
			this.diungthuoc.Name = "diungthuoc";
			this.diungthuoc.Size = new System.Drawing.Size(16, 14);
			this.diungthuoc.TabIndex = 240;
			// 
			// l_diungthuoc
			// 
			this.l_diungthuoc.BackColor = System.Drawing.Color.Transparent;
			this.l_diungthuoc.Cursor = System.Windows.Forms.Cursors.Hand;
			this.l_diungthuoc.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.l_diungthuoc.Image = ((System.Drawing.Bitmap)(resources.GetObject("l_diungthuoc.Image")));
			this.l_diungthuoc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.l_diungthuoc.Location = new System.Drawing.Point(673, 499);
			this.l_diungthuoc.Name = "l_diungthuoc";
			this.l_diungthuoc.Size = new System.Drawing.Size(100, 14);
			this.l_diungthuoc.TabIndex = 241;
			this.l_diungthuoc.Text = "       Dị ứng thuốc";
			this.l_diungthuoc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.l_diungthuoc.Click += new System.EventHandler(this.l_diungthuoc_Click);
			// 
			// lbl
			// 
			this.lbl.AutoSize = true;
			this.lbl.ForeColor = System.Drawing.Color.Red;
			this.lbl.Location = new System.Drawing.Point(119, -1);
			this.lbl.Name = "lbl";
			this.lbl.Size = new System.Drawing.Size(60, 13);
			this.lbl.TabIndex = 242;
			this.lbl.Text = "diungthuoc";
			this.lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ddsosinh
			// 
			this.ddsosinh.Controls.AddRange(new System.Windows.Forms.Control[] {
																				   this.label42,
																				   this.label39,
																				   this.vongdau,
																				   this.cao,
																				   this.cannang,
																				   this.apgar10,
																				   this.apgar5,
																				   this.apgar1,
																				   this.label47,
																				   this.label44,
																				   this.label40,
																				   this.label36,
																				   this.label37,
																				   this.label48,
																				   this.label50,
																				   this.label51,
																				   this.label54,
																				   this.label65,
																				   this.label66});
			this.ddsosinh.Location = new System.Drawing.Point(21, 385);
			this.ddsosinh.Name = "ddsosinh";
			this.ddsosinh.Size = new System.Drawing.Size(640, 24);
			this.ddsosinh.TabIndex = 37;
			this.ddsosinh.Visible = false;
			// 
			// label42
			// 
			this.label42.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.label42.Location = new System.Drawing.Point(416, 0);
			this.label42.Name = "label42";
			this.label42.Size = new System.Drawing.Size(32, 23);
			this.label42.TabIndex = 212;
			this.label42.Text = "gram";
			this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label39
			// 
			this.label39.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.label39.Location = new System.Drawing.Point(432, 0);
			this.label39.Name = "label39";
			this.label39.Size = new System.Drawing.Size(40, 23);
			this.label39.TabIndex = 210;
			this.label39.Text = "Cao";
			this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// vongdau
			// 
			this.vongdau.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.vongdau.Location = new System.Drawing.Point(584, 0);
			this.vongdau.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
			this.vongdau.MaxLength = 5;
			this.vongdau.Name = "vongdau";
			this.vongdau.Size = new System.Drawing.Size(32, 21);
			this.vongdau.TabIndex = 220;
			this.vongdau.Text = "";
			// 
			// cao
			// 
			this.cao.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.cao.Location = new System.Drawing.Point(474, 1);
			this.cao.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
			this.cao.MaxLength = 5;
			this.cao.Name = "cao";
			this.cao.Size = new System.Drawing.Size(32, 21);
			this.cao.TabIndex = 219;
			this.cao.Text = "";
			// 
			// cannang
			// 
			this.cannang.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.cannang.Location = new System.Drawing.Point(383, 0);
			this.cannang.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
			this.cannang.MaxLength = 5;
			this.cannang.Name = "cannang";
			this.cannang.Size = new System.Drawing.Size(32, 21);
			this.cannang.TabIndex = 218;
			this.cannang.Text = "";
			// 
			// apgar10
			// 
			this.apgar10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.apgar10.Location = new System.Drawing.Point(274, 0);
			this.apgar10.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
			this.apgar10.MaxLength = 3;
			this.apgar10.Name = "apgar10";
			this.apgar10.Size = new System.Drawing.Size(24, 21);
			this.apgar10.TabIndex = 217;
			this.apgar10.Text = "";
			// 
			// apgar5
			// 
			this.apgar5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.apgar5.Location = new System.Drawing.Point(177, 0);
			this.apgar5.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
			this.apgar5.MaxLength = 3;
			this.apgar5.Name = "apgar5";
			this.apgar5.Size = new System.Drawing.Size(24, 21);
			this.apgar5.TabIndex = 216;
			this.apgar5.Text = "";
			// 
			// apgar1
			// 
			this.apgar1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.apgar1.Location = new System.Drawing.Point(88, 0);
			this.apgar1.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
			this.apgar1.MaxLength = 3;
			this.apgar1.Name = "apgar1";
			this.apgar1.Size = new System.Drawing.Size(24, 21);
			this.apgar1.TabIndex = 215;
			this.apgar1.Text = "";
			// 
			// label47
			// 
			this.label47.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.label47.Location = new System.Drawing.Point(617, 0);
			this.label47.Name = "label47";
			this.label47.Size = new System.Drawing.Size(32, 23);
			this.label47.TabIndex = 214;
			this.label47.Text = "cm";
			this.label47.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label44
			// 
			this.label44.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.label44.Location = new System.Drawing.Point(506, 0);
			this.label44.Name = "label44";
			this.label44.Size = new System.Drawing.Size(24, 23);
			this.label44.TabIndex = 213;
			this.label44.Text = "cm";
			this.label44.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label40
			// 
			this.label40.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.label40.Location = new System.Drawing.Point(517, 0);
			this.label40.Name = "label40";
			this.label40.Size = new System.Drawing.Size(64, 23);
			this.label40.TabIndex = 211;
			this.label40.Text = "Vòng đầu";
			this.label40.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label36
			// 
			this.label36.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.label36.Location = new System.Drawing.Point(325, 0);
			this.label36.Name = "label36";
			this.label36.Size = new System.Drawing.Size(55, 23);
			this.label36.TabIndex = 209;
			this.label36.Text = "Cân nặng";
			this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label37
			// 
			this.label37.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.label37.Location = new System.Drawing.Point(298, 0);
			this.label37.Name = "label37";
			this.label37.Size = new System.Drawing.Size(32, 23);
			this.label37.TabIndex = 208;
			this.label37.Text = "điểm";
			this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label48
			// 
			this.label48.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.label48.Location = new System.Drawing.Point(231, 0);
			this.label48.Name = "label48";
			this.label48.Size = new System.Drawing.Size(48, 23);
			this.label48.TabIndex = 206;
			this.label48.Text = "10 phút";
			this.label48.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label50
			// 
			this.label50.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.label50.Location = new System.Drawing.Point(201, 0);
			this.label50.Name = "label50";
			this.label50.Size = new System.Drawing.Size(32, 23);
			this.label50.TabIndex = 205;
			this.label50.Text = "điểm";
			this.label50.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label51
			// 
			this.label51.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.label51.Location = new System.Drawing.Point(142, 0);
			this.label51.Name = "label51";
			this.label51.Size = new System.Drawing.Size(42, 23);
			this.label51.TabIndex = 203;
			this.label51.Text = "5 phút";
			this.label51.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label54
			// 
			this.label54.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.label54.Location = new System.Drawing.Point(110, 0);
			this.label54.Name = "label54";
			this.label54.Size = new System.Drawing.Size(32, 23);
			this.label54.TabIndex = 202;
			this.label54.Text = "điểm";
			this.label54.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label65
			// 
			this.label65.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.label65.Location = new System.Drawing.Point(54, 0);
			this.label65.Name = "label65";
			this.label65.Size = new System.Drawing.Size(42, 23);
			this.label65.TabIndex = 200;
			this.label65.Text = "1 phút";
			this.label65.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label66
			// 
			this.label66.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.label66.Location = new System.Drawing.Point(4, 0);
			this.label66.Name = "label66";
			this.label66.Size = new System.Drawing.Size(36, 23);
			this.label66.TabIndex = 199;
			this.label66.Text = "Apgar ";
			this.label66.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// danhsach
			// 
			this.danhsach.Controls.AddRange(new System.Windows.Forms.Control[] {
																				   this.butRef,
																				   this.list});
			this.danhsach.Location = new System.Drawing.Point(0, 40);
			this.danhsach.Name = "danhsach";
			this.danhsach.Size = new System.Drawing.Size(208, 408);
			this.danhsach.TabIndex = 4;
			this.danhsach.TabStop = false;
			this.danhsach.Text = "DANH SÁCH CHỜ NHẬP KHOA";
			this.danhsach.Visible = false;
			// 
			// butRef
			// 
			this.butRef.Image = ((System.Drawing.Bitmap)(resources.GetObject("butRef.Image")));
			this.butRef.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butRef.Location = new System.Drawing.Point(5, 376);
			this.butRef.Name = "butRef";
			this.butRef.Size = new System.Drawing.Size(196, 28);
			this.butRef.TabIndex = 1;
			this.butRef.Text = "&Danh sách chờ";
			this.butRef.Click += new System.EventHandler(this.butRef_Click);
			// 
			// list
			// 
			this.list.ColumnCount = 0;
			this.list.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.list.Location = new System.Drawing.Point(5, 19);
			this.list.MatchBufferTimeOut = 1000;
			this.list.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
			this.list.Name = "list";
			this.list.Size = new System.Drawing.Size(196, 355);
			this.list.TabIndex = 0;
			this.list.TextIndex = -1;
			this.list.TextMember = null;
			this.list.ValueIndex = -1;
			this.list.KeyDown += new System.Windows.Forms.KeyEventHandler(this.list_KeyDown);
			this.list.DoubleClick += new System.EventHandler(this.list_DoubleClick);
			// 
			// butPhong
			// 
			this.butPhong.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.butPhong.Location = new System.Drawing.Point(186, 361);
			this.butPhong.Name = "butPhong";
			this.butPhong.Size = new System.Drawing.Size(24, 23);
			this.butPhong.TabIndex = 33;
			this.butPhong.Text = "...";
			this.butPhong.Click += new System.EventHandler(this.butPhong_Click);
			// 
			// soluutru
			// 
			this.soluutru.BackColor = System.Drawing.SystemColors.HighlightText;
			this.soluutru.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.soluutru.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.soluutru.Location = new System.Drawing.Point(576, 362);
			this.soluutru.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
			this.soluutru.MaxLength = 10;
			this.soluutru.Name = "soluutru";
			this.soluutru.Size = new System.Drawing.Size(80, 21);
			this.soluutru.TabIndex = 36;
			this.soluutru.Text = "";
			this.soluutru.Validated += new System.EventHandler(this.soluutru_Validated);
			// 
			// label68
			// 
			this.label68.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.label68.Location = new System.Drawing.Point(504, 360);
			this.label68.Name = "label68";
			this.label68.Size = new System.Drawing.Size(72, 23);
			this.label68.TabIndex = 245;
			this.label68.Text = "Số lưu trữ :";
			this.label68.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// pmat
			// 
			this.pmat.Controls.AddRange(new System.Windows.Forms.Control[] {
																			   this.nhanapt,
																			   this.nhanapp,
																			   this.mt,
																			   this.mp,
																			   this.label69,
																			   this.label70,
																			   this.label71,
																			   this.label72,
																			   this.label73,
																			   this.label74});
			this.pmat.Location = new System.Drawing.Point(-7, 384);
			this.pmat.Name = "pmat";
			this.pmat.Size = new System.Drawing.Size(664, 22);
			this.pmat.TabIndex = 37;
			// 
			// nhanapt
			// 
			this.nhanapt.BackColor = System.Drawing.SystemColors.HighlightText;
			this.nhanapt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.nhanapt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.nhanapt.Location = new System.Drawing.Point(583, 0);
			this.nhanapt.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
			this.nhanapt.MaxLength = 10;
			this.nhanapt.Name = "nhanapt";
			this.nhanapt.Size = new System.Drawing.Size(81, 21);
			this.nhanapt.TabIndex = 26;
			this.nhanapt.Text = "";
			// 
			// nhanapp
			// 
			this.nhanapp.BackColor = System.Drawing.SystemColors.HighlightText;
			this.nhanapp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.nhanapp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.nhanapp.Location = new System.Drawing.Point(464, 0);
			this.nhanapp.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
			this.nhanapp.MaxLength = 10;
			this.nhanapp.Name = "nhanapp";
			this.nhanapp.Size = new System.Drawing.Size(56, 21);
			this.nhanapp.TabIndex = 25;
			this.nhanapp.Text = "";
			// 
			// mt
			// 
			this.mt.BackColor = System.Drawing.SystemColors.HighlightText;
			this.mt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.mt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.mt.Location = new System.Drawing.Point(247, 0);
			this.mt.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
			this.mt.MaxLength = 10;
			this.mt.Name = "mt";
			this.mt.Size = new System.Drawing.Size(64, 21);
			this.mt.TabIndex = 24;
			this.mt.Text = "";
			// 
			// mp
			// 
			this.mp.BackColor = System.Drawing.SystemColors.HighlightText;
			this.mp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.mp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.mp.Location = new System.Drawing.Point(116, 0);
			this.mp.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
			this.mp.MaxLength = 10;
			this.mp.Name = "mp";
			this.mp.Size = new System.Drawing.Size(60, 21);
			this.mp.TabIndex = 23;
			this.mp.Text = "";
			// 
			// label69
			// 
			this.label69.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.label69.Location = new System.Drawing.Point(315, 4);
			this.label69.Name = "label69";
			this.label69.Size = new System.Drawing.Size(24, 16);
			this.label69.TabIndex = 5;
			this.label69.Text = "/10";
			this.label69.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label70
			// 
			this.label70.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.label70.Location = new System.Drawing.Point(542, 4);
			this.label70.Name = "label70";
			this.label70.Size = new System.Drawing.Size(40, 16);
			this.label70.TabIndex = 3;
			this.label70.Text = "Trái :";
			this.label70.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label71
			// 
			this.label71.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.label71.Location = new System.Drawing.Point(344, 4);
			this.label71.Name = "label71";
			this.label71.Size = new System.Drawing.Size(120, 16);
			this.label71.TabIndex = 2;
			this.label71.Text = "Nhãn áp phải :";
			this.label71.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label72
			// 
			this.label72.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.label72.Location = new System.Drawing.Point(206, 4);
			this.label72.Name = "label72";
			this.label72.Size = new System.Drawing.Size(40, 16);
			this.label72.TabIndex = 1;
			this.label72.Text = "Trái :";
			this.label72.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label73
			// 
			this.label73.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.label73.Location = new System.Drawing.Point(178, 4);
			this.label73.Name = "label73";
			this.label73.Size = new System.Drawing.Size(24, 16);
			this.label73.TabIndex = 4;
			this.label73.Text = "/10";
			this.label73.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label74
			// 
			this.label74.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.label74.Location = new System.Drawing.Point(32, 4);
			this.label74.Name = "label74";
			this.label74.Size = new System.Drawing.Size(88, 16);
			this.label74.TabIndex = 0;
			this.label74.Text = "Thị lực phải :";
			this.label74.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblme
			// 
			this.lblme.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblme.ForeColor = System.Drawing.Color.Red;
			this.lblme.Location = new System.Drawing.Point(528, 0);
			this.lblme.Name = "lblme";
			this.lblme.Size = new System.Drawing.Size(256, 17);
			this.lblme.TabIndex = 246;
			this.lblme.Text = "ttme";
			this.lblme.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblhiv
			// 
			this.lblhiv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblhiv.ForeColor = System.Drawing.Color.Red;
			this.lblhiv.Location = new System.Drawing.Point(696, 0);
			this.lblhiv.Name = "lblhiv";
			this.lblhiv.Size = new System.Drawing.Size(128, 16);
			this.lblhiv.TabIndex = 247;
			this.lblhiv.Text = "HIV Dưong tính";
			this.lblhiv.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// frmNhapkhoa
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(792, 573);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.danhsach,
																		  this.psosinh,
																		  this.lblhiv,
																		  this.l_phauthuat,
																		  this.l_thuthuat,
																		  this.phauthuat,
																		  this.thuthuat,
																		  this.l_diungthuoc,
																		  this.l_cls,
																		  this.l_kemtheo,
																		  this.l_vienphi,
																		  this.l_chidinh,
																		  this.l_tainantt,
																		  this.pmat,
																		  this.tenbs,
																		  this.soluutru,
																		  this.label68,
																		  this.butPhong,
																		  this.ddsosinh,
																		  this.lbl,
																		  this.diungthuoc,
																		  this.cls,
																		  this.kemtheo,
																		  this.vienphi,
																		  this.chidinh,
																		  this.cd_kemtheo,
																		  this.listICD,
																		  this.ngaysinh,
																		  this.tainantt,
																		  this.label16,
																		  this.treeView2,
																		  this.icd_kemtheo,
																		  this.label46,
																		  this.treeView1,
																		  this.ppara,
																		  this.phai,
																		  this.lphai,
																		  this.phanhchinh,
																		  this.psankhoa,
																		  this.pungbuou_v,
																		  this.pnhi,
																		  this.pvaovien,
																		  this.tenba,
																		  this.butKetthuc,
																		  this.butIn,
																		  this.butBoqua,
																		  this.butLuu,
																		  this.butTiep,
																		  this.label52,
																		  this.mabs,
																		  this.label49,
																		  this.giuong,
																		  this.label38,
																		  this.namsinh,
																		  this.hoten,
																		  this.tuoi,
																		  this.maba,
																		  this.mabn3,
																		  this.loaituoi,
																		  this.label7,
																		  this.label6,
																		  this.mabn2,
																		  this.mabn1,
																		  this.label5,
																		  this.label4,
																		  this.label3,
																		  this.label2,
																		  this.lblme});
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.Name = "frmNhapkhoa";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Medisoft";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmNhapkhoa_KeyDown);
			this.Load += new System.EventHandler(this.frmNhapkhoa_Load);
			this.pnhi.ResumeLayout(false);
			this.phanhchinh.ResumeLayout(false);
			this.psosinh.ResumeLayout(false);
			this.ppara.ResumeLayout(false);
			this.pvaovien.ResumeLayout(false);
			this.khamthai.ResumeLayout(false);
			this.psankhoa.ResumeLayout(false);
			this.pungbuou_v.ResumeLayout(false);
			this.ddsosinh.ResumeLayout(false);
			this.danhsach.ResumeLayout(false);
			this.pmat.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void frmNhapkhoa_Load(object sender, System.EventArgs e)
		{			
			lblhiv.Visible=false;
			bPhonggiuong=m.bPhonggiuong;
			if (bPhonggiuong) dtg=m.get_data("select * from dmgiuong").Tables[0];
			giuong.Enabled=!bPhonggiuong;
			butPhong.Visible=bPhonggiuong;
			bSuadoituong=m.bSuadoituong;
			b101204=m.Mabv_so==101204 || m.bNgoaitru_noitru;
			if (b101204) m.upd_ttxk(8,"Chuyển HTĐT",0);
			pmat.Visible=m.Mabv_so==701424;
			bNhapsoluutru=m.bSoluutru_nhapvien;
			bChandoan=m.bChandoan_icd10;
			bSothe_mabn=m.bsothe_mabn;
			tentb.DisplayMember="TEN";
			tentb.ValueMember="MA";
			tentb.DataSource=m.get_data("select * from dmtaibiensanh order by stt").Tables[0];
			cachthucde.DisplayMember="TEN";
			cachthucde.ValueMember="MA";
			cachthucde.DataSource=m.get_data("select * from dmkieusanh order by stt").Tables[0];
			bDenngay_sothe=m.bDenngay_sothe;
			bTiepdon=m.bTiepdon(LibMedi.AccessData.Khoa);
			bKhamthai=m.bKhamthai;
			khamthai.Visible=bKhamthai;
			bChuyenkhoasan=m.bChuyenkhoasan;
			if (bChuyenkhoasan) phai.SelectedIndex=1;
			lbl.Text="";lblme.Text="";
			bMabame=m.bMabame;
			bAdmin=m.bAdmin(i_userid);
			iTreem6=m.iTreem6;
			iTreem15=m.iTreem15;
			b_nhapvien=m.bThongtinnhapvien;
			b_bacsi=m.bsNhapkhoa;
			bHanhchinh=m.bHanhChinh;
			psankhoa.Top=317;
			pungbuou_v.Top=psankhoa.Top;
			ppara.Top=134;
			pnhi.Top=111;
			load_dm();
			i_chidinh=m.iChidinh;
			b_Hoten=m.bHoten_gioitinh;
			phai.SelectedIndex=0;
			ngayvv.Text=m.Ngaygio;
			ngayvk.Text=ngayvv.Text;
			s_ngayvv=ngayvv.Text;
			s_ngayvk=ngayvk.Text;
			songay=m.Ngaylv_Ngayht;
			s_msg=LibMedi.AccessData.Msg;
			m_phainu=LibMedi.AccessData.phainu;
			m_sosinh=LibMedi.AccessData.sosinh;
			sovaovien.Enabled=!b_sovaovien;
			cd_kkb.Enabled=m.bChandoan;
            cd_vaokhoa.Enabled=cd_kkb.Enabled;
			cd_noichuyenden.Enabled=cd_kkb.Enabled;
			cd_kemtheo.Enabled=cd_kkb.Enabled;
			makp.Enabled=m.bNoichuyen;
			tenkp.Enabled=makp.Enabled;
			ngayvv.Enabled=b_nhapvien;
			nhantu.Enabled=ngayvv.Enabled;
			tennhantu.Enabled=ngayvv.Enabled;
			dentu.Enabled=ngayvv.Enabled;
			tendentu.Enabled=ngayvv.Enabled;
			lanthu.Enabled=ngayvv.Enabled;
			tdvh.Enabled=ngayvv.Enabled;
			ngaybong.Enabled=ngayvv.Enabled;
			if (m.Mabv_so==701424) sovaovien.Enabled=false;
			else if (!b_sovaovien) sovaovien.Enabled=ngayvv.Enabled;
			quanhe.Enabled=ngayvv.Enabled;
			qh_hoten.Enabled=ngayvv.Enabled;
			qh_diachi.Enabled=ngayvv.Enabled;
			qh_dienthoai.Enabled=ngayvv.Enabled;
			icd_noichuyenden.Enabled=ngayvv.Enabled;
			cd_noichuyenden.Enabled=ngayvv.Enabled;
			icd_kkb.Enabled=ngayvv.Enabled;
			cd_kkb.Enabled=ngayvv.Enabled;
			ena_object();
			soluutru.Enabled=bNhapsoluutru;
			//Binh: load ds hang doi
			list.DisplayMember="HOTEN";
			list.ValueMember="ID";
			Load_dshienhien_cho(s_makp);			
			list.ColumnWidths[0]=60;
			list.ColumnWidths[1]=100;
			list.ColumnWidths[2]=0;
			list.ColumnWidths[3]=60;			
			//
			//
		}

		private void ena_object()
		{	
			bCapso=false;
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
		private void load_phauthuat()
		{
			if (l_maql==0) return;
			phauthuat.Checked=m.get_data("select * from tresosinh where maql="+l_maql).Tables[0].Rows.Count!=0;
			l_phauthuat.ForeColor=(phauthuat.Checked)?Color.FromArgb(255,0,0):Color.FromArgb(0,0,255);
			if (phauthuat.Checked && bSankhoa) lvaokhoa.Text="CĐ khoa điều trị :";
		}

		private void load_thuthuat()
		{
			if (l_maql==0) return;
			thuthuat.Checked=m.get_data("select * from pttt where maql="+l_maql).Tables[0].Rows.Count!=0;
			l_thuthuat.ForeColor=(thuthuat.Checked)?Color.FromArgb(255,0,0):Color.FromArgb(0,0,255);
		}

		private void load_tainantt()
		{
			if (l_maql==0) return;
			tainantt.Checked=m.get_data("select * from tainantt where maql="+l_maql).Tables[0].Rows.Count!=0;
			l_tainantt.ForeColor=(tainantt.Checked)?Color.FromArgb(255,0,0):Color.FromArgb(0,0,255);
		}

		private void load_chidinh()
		{
			if (l_maql==0 || !m.bMmyy(m.ngayhienhanh_server)) return;
			sql="select * from v_chidinh";
			if (i_chidinh==1) sql+=" where mabn='"+s_mabn+"'";
			else if (i_chidinh==2) sql+=" where maql="+l_maql;
			else if (i_chidinh==3) sql+=" where idkhoa="+l_id;
			chidinh.Checked=m.get_data_v(m.mmyy(m.ngayhienhanh_server),sql).Tables[0].Rows.Count!=0;
			l_chidinh.ForeColor=(chidinh.Checked)?Color.FromArgb(255,0,0):Color.FromArgb(0,0,255);
		}

		private void load_vienphi()
		{
			if (l_maql==0 || !m.bMmyy(m.ngayhienhanh_server)) return;
			sql="select * from v_vpkhoa";
			if (i_chidinh==1) sql+=" where mabn='"+s_mabn+"'";
			else if (i_chidinh==2) sql+=" where maql="+l_maql;
			else if (i_chidinh==3) sql+=" where idkhoa="+l_id;
			vienphi.Checked=m.get_data_v(m.mmyy(m.ngayhienhanh_server),sql).Tables[0].Rows.Count!=0;
			l_vienphi.ForeColor=(vienphi.Checked)?Color.FromArgb(255,0,0):Color.FromArgb(0,0,255);
		}

		private void load_diungthuoc()
		{
			lbl.Text="";
			foreach(DataRow r in m.get_data("select distinct b.ten from diungthuoc a,d_dmhoatchat b where a.mahc=b.ma and a.mabn='"+mabn2.Text+mabn3.Text+"'").Tables[0].Rows) lbl.Text+=r["ten"].ToString().Trim()+";";
			diungthuoc.Checked=lbl.Text!="";
			if (diungthuoc.Checked) lbl.Text=lan.Change_language_MessageText("DỊ ỨNG THUỐC :")+lbl.Text;
			l_diungthuoc.ForeColor=(diungthuoc.Checked)?Color.FromArgb(255,0,0):Color.FromArgb(0,0,255);
		}

		private void load_dm()
		{
			dtdt=m.get_data("select * from doituong").Tables[0];
			dticd=m.get_data("select cicd10,vviet from icd10 order by cicd10").Tables[0];
			listICD.DisplayMember="CICD10";
			listICD.ValueMember="VVIET";
			listICD.DataSource=dticd;

			if (b101204) sql="select * from btdkp_bv order by makp";
			else sql="select * from btdkp_bv where loai=0 and makp<>'"+s_makp+"'"+" order by makp";
			tenkp.DisplayMember="TENKP";
			tenkp.ValueMember="MAKP";
			tenkp.DataSource=m.get_data(sql).Tables[0];
			try
			{
				string s_maba=m.get_data("select maba from btdkp_bv where makp='"+s_makp+"'").Tables[0].Rows[0][0].ToString();
				if (b101204) sql="select * from dmbenhan_bv where maba in ("+s_maba+")"+" order by maba";
				else sql="select * from dmbenhan_bv where loaiba=1 and maba in ("+s_maba+")"+" order by maba";
				dtba=m.get_data(sql).Tables[0];
			}
			catch
			{
				if (b101204) sql="select * from dmbenhan_bv order by maba";
				else sql="select * from dmbenhan_bv where loaiba=1 order by maba";
				dtba=m.get_data(sql).Tables[0];
			}
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
			tendantoc.DataSource=m.get_data("select * from btddt order by madantoc").Tables[0];
			tendantoc.SelectedValue="25";

			tentinh.DisplayMember="TENTT";
			tentinh.ValueMember="MATT";
			tentinh.DataSource=m.get_data("select * from btdtt order by matt").Tables[0];
			tentinh.SelectedValue=m.Mabv.Substring(0,3);

			tenquan.DisplayMember="TENQUAN";
			tenquan.ValueMember="MAQU";
			load_quan();
            
			tenpxa.DisplayMember="TENPXA";
			tenpxa.ValueMember="MAPHUONGXA";
			load_pxa();
			
			tennuoc.DisplayMember="TEN";
			tennuoc.ValueMember="MA";
			tennuoc.DataSource=m.get_data("select * from dmquocgia order by ma").Tables[0];
			tennuoc.SelectedIndex=-1;

			tentqx.DisplayMember="TEN";
			tentqx.ValueMember="MAPHUONGXA";

			tendentu.DisplayMember="TEN";
			tendentu.ValueMember="MA";
			tendentu.DataSource=m.get_data("select * from dentu order by ma").Tables[0];
			tendentu.SelectedIndex=-1;

			tennhantu.DisplayMember="TEN";
			tennhantu.ValueMember="MA";
			tennhantu.DataSource=m.get_data("select * from nhantu order by ma").Tables[0];
			tennhantu.SelectedIndex=-1;

			tendoituong.DisplayMember="DOITUONG";
			tendoituong.ValueMember="MADOITUONG";

			tenbs.DisplayMember="HOTEN";
			tenbs.ValueMember="MA";
			if (b_bacsi)
			{
				tenbs.DataSource=m.get_data("select * from dmbs where nhom not in ("+LibMedi.AccessData.nhanvien+","+LibMedi.AccessData.nghiviec+") and makp='"+s_makp+"'"+" order by ma").Tables[0];
				if (tenbs.Items.Count==0) tenbs.DataSource=m.get_data("select * from dmbs where nhom not in ("+LibMedi.AccessData.nhanvien+","+LibMedi.AccessData.nghiviec+") order by ma").Tables[0];
			}
			else tenbs.DataSource=m.get_data("select * from dmbs where nhom not in ("+LibMedi.AccessData.nhanvien+","+LibMedi.AccessData.nghiviec+") order by ma").Tables[0];
			tenbs.SelectedIndex=-1;

			ss_tennn_bo.DisplayMember="TENNN";
			ss_tennn_bo.ValueMember="MANN";
			ss_tennn_bo.DataSource=m.get_data("select * from btdnn_bv where mannbo<>'01' order by mann").Tables[0];

			ss_tennn_me.DisplayMember="TENNN";
			ss_tennn_me.ValueMember="MANN";
			ss_tennn_me.DataSource=m.get_data("select * from btdnn_bv where mannbo<>'01' order by mann").Tables[0];

			nhi_tennn_bo.DisplayMember="TENNN";
			nhi_tennn_bo.ValueMember="MANN";
			nhi_tennn_bo.DataSource=m.get_data("select * from btdnn_bv where mannbo<>'01' order by mann").Tables[0];

			nhi_tennn_me.DisplayMember="TENNN";
			nhi_tennn_me.ValueMember="MANN";
			nhi_tennn_me.DataSource=m.get_data("select * from btdnn_bv where mannbo<>'01' order by mann").Tables[0];

			ss_nhommau.DisplayMember="TEN";
			ss_nhommau.ValueMember="MA";
			ss_nhommau.DataSource=m.get_data("select * from dmnhommau").Tables[0];
		}

		private void load_mann(bool btreem)
		{
			if (btreem)
				tennn.DataSource=m.get_data("select * from btdnn_bv where mannbo='01' order by mann").Tables[0];
			else
				tennn.DataSource=m.get_data("select * from btdnn_bv order by mann").Tables[0];
			if (tenba.SelectedValue.ToString()=="BSO")
				tendoituong.DataSource=m.get_data("select * from doituong where madoituong<>1 order by madoituong").Tables[0];
			else
				tendoituong.DataSource=m.get_data("select * from doituong order by madoituong").Tables[0];
			if (tendoituong.SelectedIndex!=-1)
			{
				madoituong.Text=tendoituong.SelectedValue.ToString();
				string so=m.sothe(int.Parse(tendoituong.SelectedValue.ToString()));
				sothe.Enabled=int.Parse(so.Substring(0,2))>0;
				denngay.Enabled=so.Substring(2,1)=="1";
			}
			if (bKhamthai) khamthai.Visible=tenba.SelectedValue.ToString()!="BSO";
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
			tenquan.DataSource=m.get_data("select * from btdquan where matt='"+tentinh.SelectedValue.ToString()+"'"+" order by maqu").Tables[0];
		}

		private void load_pxa()
		{
			tenpxa.DataSource=m.get_data("select * from btdpxa where maqu='"+tenquan.SelectedValue.ToString()+"'"+" order by maphuongxa").Tables[0];
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
				this.Text=lan.Change_language_MessageText("Nhập khoa > ")+m.get_data("select tenkp from btdkp_bv where makp='"+s_makp+"'").Tables[0].Rows[0][0].ToString()+"\\"+tenba.Text.Trim()+lan.Change_language_MessageText("< Người cập nhật : ")+s_userid.Trim()+" >";
				DataRow r=m.getrowbyid(dtba,"mavt='"+tenba.SelectedValue.ToString()+"'");
				if (r!=null) i_maba=int.Parse(r[0].ToString());
				else i_maba=0;
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
			psankhoa.Visible=bSankhoa;
			bTamthan=tenba.SelectedValue.ToString()=="BTH";
			ltdvh.Visible=bTamthan;
			tdvh.Visible=ltdvh.Visible;
			tenkp.Width=(ltdvh.Visible)?87:209;
			lbong.Visible=bBong;
			ngaybong.Visible=bBong;
			if (bBong) tenkp.Width=80;
			pungbuou_v.Visible=bUngbuou;
			l_phauthuat.Enabled=bSankhoa;
			if (bSosinh)
			{
				tendoituong.SelectedValue="3"; 
				madoituong.Text=tendoituong.SelectedValue.ToString();
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
			ddsosinh.Visible=ena;
		}

		private void loaituoi_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (loaituoi.SelectedIndex==-1) loaituoi.SelectedIndex=0;
				namsinh.Text=m.Namsinh("",int.Parse(tuoi.Text),loaituoi.SelectedIndex).ToString();
				int ituoi=DateTime.Now.Year-int.Parse(namsinh.Text);
				if (ituoi>m.iTuoi_nguoibenh)
				{
					MessageBox.Show(lan.Change_language_MessageText("Năm sinh không hợp lệ !"),LibMedi.AccessData.Msg);
					namsinh.Focus();
					return;
				}
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
				DataTable dt=m.get_Timmabn(hoten.Text,ngaysinh.Text,namsinh.Text,s_mabn).Tables[0];
				if (dt.Rows.Count>0)
				{
					frmTimMabn f=new frmTimMabn(dt);
					f.ShowDialog();
					if (f.m_mabn!="")
					{
						mabn2.Text=f.m_mabn.Substring(0,2);
						mabn3.Text=f.m_mabn.Substring(2,6);
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
			catch{tennn.SelectedIndex=0;}
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
			bCapso=false;
			danhsach.Visible=false;
			load_btdnn(0);
			if (bChuyenkhoasan) phai.SelectedIndex=1;
			if (mabn3.Text=="")
			{
				if (mabn2.Text=="")
				{
					mabn2.Focus();
					return;
				}
				if (m.get_capso(s_makp)) 
				{
					bCapso=true;
					mabn3.Text=m.get_mabn(int.Parse(mabn2.Text),2,int.Parse(s_makp),true).ToString().PadLeft(6,'0');
				}
				else return;
			}
			mabn3.Text=mabn3.Text.PadLeft(6,'0');
			s_mabn=mabn2.Text+mabn3.Text;
			lbltieusu.ForeColor=(m.get_data("select * from theodoitsu where mabn='"+s_mabn+"'").Tables[0].Rows.Count>0)?Color.Red:Color.Black;
			emp_text(true);
			lblhiv.Visible=m.get_hiv(s_mabn);			
			if (load_mabn())
			{
					if (load_vv_mabn())
					{
						if (!bAdmin) ena_but(false);
					}
					else if (!ngayvv.Enabled)
					{
						MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân này chưa nhập viện !"),LibMedi.AccessData.Msg);
						butBoqua_Click(null,null);
						return;
					}
					s_icd_noichuyenden=icd_noichuyenden.Text;
					s_icd_kkb=icd_kkb.Text;
					s_icd_vaokhoa=icd_vaokhoa.Text;
					s_icd_kemtheo=icd_kemtheo.Text;
				if (bHanhchinh && bAdmin)
				{
					if (MessageBox.Show(lan.Change_language_MessageText("Bạn có sửa thông tin hành chính không ?"),s_msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)==DialogResult.Yes)
					{
						b_Edit=true;
						hoten.Focus();
					}
					else 
					{
						if (b_nhapvien) ngayvv.Focus();
						else ngayvk.Focus();
						SendKeys.Send("{Home}");
					}
				}
				else
				{
					if (b_nhapvien) ngayvv.Focus();
					else ngayvk.Focus();
					SendKeys.Send("{Home}");
				}
			}
			else if (!ngayvv.Enabled)
			{
				MessageBox.Show(lan.Change_language_MessageText("Không tìm thấy bệnh nhân này !"),LibMedi.AccessData.Msg);
				butBoqua_Click(null,null);
			}
		}

		private bool load_mabn()
		{
			bool ret=false;
			foreach(DataRow r in m.get_data("select * from btdbn where mabn='"+s_mabn+"'").Tables[0].Rows)
			{
				nam=r["nam"].ToString();
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
			if (ret && manuoc.Enabled) tennuoc.SelectedValue=m.get_data("select id_nuoc from nuocngoai where mabn='"+s_mabn+"'").Tables[0].Rows[0][0].ToString();
			if (ret)
			{
				if (bNhi)
				{
					foreach(DataRow r in m.get_data("select * from hcnhi where mabn='"+s_mabn+"'").Tables[0].Rows)
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
					foreach(DataRow r in m.get_data("select * from hcsosinh where mabn='"+s_mabn+"'").Tables[0].Rows)
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
			foreach(DataRow r in m.get_data("select * from benhandt where loaiba=1 and maql="+l_maql).Tables[0].Rows)
			{
				if (!skip)
				{
					ngayvv.Text=m.DateToString("dd/MM/yyyy HH:mm",DateTime.Parse(r["ngay"].ToString()));
					s_ngayvv=ngayvv.Text;
				}
                tendentu.SelectedValue=r["dentu"].ToString();
				tennhantu.SelectedValue=r["nhantu"].ToString();
				tendoituong.SelectedValue=r["madoituong"].ToString();
				madoituong.Text=r["madoituong"].ToString();
				lanthu.Text=r["lanthu"].ToString();
				sovaovien.Text=r["sovaovien"].ToString();
				cd_kkb.Text=r["chandoan"].ToString();
				icd_kkb.Text=r["maicd"].ToString();
				if (!bSuadoituong) ena_doituong(false);
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
			foreach(DataRow r in m.get_data("select * from benhandt where loaiba=1 and mabn='"+s_mabn+"'"+" order by ngay desc").Tables[0].Rows)
			{
				l_maql=long.Parse(r["maql"].ToString());
				ngayvv.Text=m.DateToString("dd/MM/yyyy HH:mm",DateTime.Parse(r["ngay"].ToString()));
				s_ngayvv=ngayvv.Text;
				tendentu.SelectedValue=r["dentu"].ToString();
				tennhantu.SelectedValue=r["nhantu"].ToString();
				tendoituong.SelectedValue=r["madoituong"].ToString();
				madoituong.Text=r["madoituong"].ToString();
				lanthu.Text=r["lanthu"].ToString();
				sovaovien.Text=r["sovaovien"].ToString();
				cd_kkb.Text=r["chandoan"].ToString();
				icd_kkb.Text=r["maicd"].ToString();
				if (!bSuadoituong) ena_doituong(false);
				break;
			}
			if (bPhonggiuong && giuong.Text=="")
			{
				foreach(DataRow r in m.get_data("select b.ma from datgiuong a,dmgiuong b where a.idgiuong=b.id and a.mabn='"+s_mabn+"' and den is null").Tables[0].Rows)
				{
					giuong.Text=r["ma"].ToString();							
					break;
				}						
				butPhong.Enabled=giuong.Text=="";
			}
			load_vv();
			return l_maql!=0;
		}

		private void load_vv()
		{
			emp_bhyt();
			foreach(DataRow r in m.get_data("select * from quanhe where maql="+l_maql).Tables[0].Rows)
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
					foreach(DataRow r in m.get_data("select * from bhyt where maql="+l_maql).Tables[0].Rows)
					{
						sothe.Text=r["sothe"].ToString();
						s_noicap=r["mabv"].ToString();
						if (r["denngay"].ToString()!="")
							denngay.Text=m.DateToString("dd/MM/yyyy",DateTime.Parse(r["denngay"].ToString()));
					}
				}
			}
			if (bSosinh)
			{
				foreach(DataRow r in m.get_data("select * from ddsosinh where maql="+l_maql).Tables[0].Rows)
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
				foreach(DataRow r in m.get_data("select * from ttkhamthai where maql="+l_maql).Tables[0].Rows)
				{
					para1.Text=r["para"].ToString().Substring(0,2);
					para2.Text=r["para"].ToString().Substring(2,2);
					para3.Text=r["para"].ToString().Substring(4,2);
					para4.Text=r["para"].ToString().Substring(6,2);
				}
			}
			if (dentu.Text=="1")
			{
				foreach(DataRow r in m.get_data("select * from noigioithieu where maql="+l_maql).Tables[0].Rows)
				{
					cd_noichuyenden.Text=r["chandoan"].ToString();
					icd_noichuyenden.Text=r["maicd"].ToString();
					s_madstt=r["mabv"].ToString();
				}
			}
			try
			{
				if (bTamthan) tdvh.Text=m.get_data("select vanhoa from tttamthan where maql="+l_maql).Tables[0].Rows[0][0].ToString();
				else if (bBong) ngaybong.Text=m.get_data("select to_char(ngay,'dd/mm/yyyy hh24:mi') from ttbong where maql="+l_maql).Tables[0].Rows[0][0].ToString();
			}
			catch{}
			if (pmat.Visible)
			{
				foreach(DataRow r in m.get_data("select * from ttmat where maql="+l_maql).Tables[0].Rows)
				{
					mp.Text=r["mp"].ToString();
					mt.Text=r["mt"].ToString();
					nhanapp.Text=r["nhanapp"].ToString();
					nhanapt.Text=r["nhanapt"].ToString();
					break;
				}
			}
			if (bNhapsoluutru) soluutru.Text=m.get_soluutru(l_maql).ToString();
			s_icd_noichuyenden=icd_noichuyenden.Text;
			s_icd_kkb=icd_kkb.Text;
			s_icd_vaokhoa=icd_vaokhoa.Text;
			s_icd_kemtheo=icd_kemtheo.Text;
			s_ngayde=ngayde.Text;
			s_ngaybong=ngaybong.Text;
			load_treeView2();
			load_phauthuat();
			load_thuthuat();
			load_tainantt();
			if (i_chidinh<3)
			{
				load_chidinh();
				load_vienphi();
			}
		}

		private bool load_vk(bool skip)
		{
			ena_but(true);
			bool ret=false;
			string sql="select * from nhapkhoa a where a.makp='"+s_makp+"' and a.maql="+l_maql;
			if (skip) sql+=" and to_char(a.ngay,'dd/mm/yyyy hh24:mi')='"+ngayvk.Text+"'";
			sql+=" order by a.ngay desc";
			foreach(DataRow r in m.get_data(sql).Tables[0].Rows)
			{
				l_id=long.Parse(r["id"].ToString());
				if (!skip)
				{
					ngayvk.Text=m.DateToString("dd/MM/yyyy HH:mm",DateTime.Parse(r["ngay"].ToString()));
					s_ngayvk=ngayvk.Text;
				}
				tuoi.Text=r["tuoivao"].ToString().Substring(0,3);
				loaituoi.SelectedIndex=int.Parse(r["tuoivao"].ToString().Substring(3,1));
				tenbs.SelectedValue=r["mabs"].ToString();
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
				foreach(DataRow r in m.get_data("select * from cdungbuou where id="+l_id).Tables[0].Rows)
				{
					t_v.Text=r["t_v"].ToString();
					n_v.Text=r["n_v"].ToString();
					m_v.Text=r["m_v"].ToString();
					giaidoan_v.Text=r["giaidoan_v"].ToString();
					break;
				}
			}
			if (ret)
			{
				foreach(DataRow r in m.get_data("select * from cdkemtheo where loai=2 and id="+l_id+" order by stt").Tables[0].Rows)
				{
					cd_kemtheo.Text=r["chandoan"].ToString();
					icd_kemtheo.Text=r["maicd"].ToString();
					break;
				}
			}
			if (bSankhoa)
			{
				//foreach(DataRow r in m.get_data("select * from cdsankhoa where maql="+l_maql+" and to_date(ngay,'dd/mm/yyyy hh24:mi')<=to_date('"+ngayvk.Text+"','dd/mm/yyyy hh24:mi')").Tables[0].Rows)
				foreach(DataRow r in m.get_data("select * from cdsankhoa where maql="+l_maql).Tables[0].Rows)
				{
					ngayde.Text=m.DateToString("dd/MM/yyyy HH:mm",DateTime.Parse(r["ngay"].ToString()));
					cachthucde.SelectedValue=r["cachthucde"].ToString();
					kiemsoat.Checked=(int.Parse(r["kiemsoat"].ToString())==1)?true:false;
					matb.Text=r["mataibien"].ToString();
					tentb.SelectedValue=matb.Text;
					ena_sankhoa(m.bNgaygio(ngayde.Text,ngayvk.Text));
				}
			}
			try
			{
				if (!ret)
				{
					DataTable dt=m.get_data("select makp,ngaychuyen from chuyenkhoa where khoaden='"+s_makp+"' and maql="+l_maql+" order by ngaychuyen desc").Tables[0];
					if (dt.Rows.Count!=0)
					{
						ngayvk.Text=m.DateToString("dd/MM/yyyy HH:mm",DateTime.Parse(dt.Rows[0][1].ToString()));
						s_ngayvk=ngayvk.Text;
						tenkp.SelectedValue=dt.Rows[0][0].ToString();
					}
					else
					{
						if (ngayvk.Focused)
						{
							string ma=m.get_makp(l_maql);
							if (ma==s_makp) tenkp.SelectedValue="01";
							else
							{
								try
								{
									if (ma=="")	MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân này chưa nhập viện !"),LibMedi.AccessData.Msg);
									else MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân này chưa được chỉ định vào khoa !"),LibMedi.AccessData.Msg);
									butBoqua_Click(null,null); 
									return false;
								}
								catch{}
							}
						}
					}
				}
			}
			catch{}
			if (i_chidinh==3)
			{
				load_chidinh();
				load_vienphi();
			}
			load_kemtheo();
			return ret;
		}

		private void ena_sankhoa(bool ena)
		{
			ngayde.Enabled=ena;
			cachthucde.Enabled=ena;
			kiemsoat.Enabled=ena;
			matb.Enabled=ena;
			tentb.Enabled=ena;
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

		private void frmNhapkhoa_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.F5:
					l_thuthuat_Click(sender,e);
					break;
				case Keys.F6:
					l_phauthuat_Click(sender,e);
					break;
				case Keys.F7:
					l_chidinh_Click(sender,e);
					break;
				case Keys.F8:
					l_vienphi_Click(sender,e);
					break;
				case Keys.F9:
					l_tainantt_Click(sender,e);
					break;
				case Keys.F11:
					l_kemtheo_Click(sender,e);
					break;
				case Keys.F12:
					l_cls_Click(sender,e);
					break;
				case Keys.F10:
					butKetthuc_Click(sender,e);
					break;
				case Keys.Escape:
					danhsach.Visible=false;
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
					case Keys.S:
						lbltieusu_Click(sender,e);
						break;		
				}
			}
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			this.Close();
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
				if (m.bChandoan) cd_noichuyenden.Enabled=dentu.Text=="1";
				icd_noichuyenden.Enabled=dentu.Text=="1";
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
				if (so.Substring(2,1)=="1"  && bDenngay_sothe)
					sql="select sothe,denngay,mabv from bhyt where mabn='"+s_mabn+"'"+" and to_date(denngay,'dd/mm/yy')>=to_date('"+ngayvv.Text.Substring(0,10)+"','dd/mm/yy')"+" order by maql desc";
				else
					sql="select sothe,denngay,mabv from bhyt where mabn='"+s_mabn+"' order by maql desc";
				foreach(DataRow r in m.get_data(sql).Tables[0].Rows)
				{
					sothe.Text=r["sothe"].ToString();
					if (r["denngay"].ToString()!="")
						denngay.Text=m.DateToString("dd/MM/yyyy",DateTime.Parse(r["denngay"].ToString()));
					if (so.Substring(3,1)=="1") s_noicap=r["mabv"].ToString();
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
			try
			{
				tenbs.SelectedValue=mabs.Text;
			}
			catch{}
		}

		private void mabs_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{F4}");
		}

		private void tenbs_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				if (tenbs.SelectedIndex==-1) tenbs.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void tenbs_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				mabs.Text=tenbs.SelectedValue.ToString();
			}
			catch{mabs.Text="";}
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
					frmDMICD10 f=new frmDMICD10(m,"icd10",icd_noichuyenden.Text,cd_noichuyenden.Text,true);
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
					frmDMICD10 f=new frmDMICD10(m,"icd10",icd_kkb.Text,cd_kkb.Text,true);
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
					frmDMICD10 f=new frmDMICD10(m,"icd10",icd_vaokhoa.Text,cd_vaokhoa.Text,true);
					f.ShowDialog();
					if (f.mICD!="")
					{
						cd_vaokhoa.Text=f.mTen;
						icd_vaokhoa.Text=f.mICD;
					}
				}
				s_icd_vaokhoa=icd_vaokhoa.Text;
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
					frmDMICD10 f=new frmDMICD10(m,"icd10",icd_kemtheo.Text,cd_kemtheo.Text,true);
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
				if (!m.bNgay(denngay.Text))
				{
					MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"));
					denngay.Focus();
					return;
				}
				denngay.Text=m.Ktngaygio(denngay.Text,10);
				if (!m.bNgay(denngay.Text,ngayvk.Text))
				{
					MessageBox.Show(lan.Change_language_MessageText("Ngày hết hạn không được nhỏ hơn ngày vào khoa!"),s_msg);
					denngay.Focus();
					return;
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
			if (bSankhoa) ena_sankhoa(true);
			if (!skip)
			{
				mabn2.Text=DateTime.Now.Year.ToString().Substring(2,2);
				mabn3.Text="";
			}
			nam="";
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
			lblme.Text="";
			l_maql=0;
			l_id=0;
			b_Edit=false;lblhiv.Visible=false;
			tentinh.SelectedValue=m.Mabv.Substring(0,3);
			tendantoc.SelectedValue="25";
			tennuoc.SelectedValue="VN";
			diungthuoc.Checked=false;
			l_diungthuoc.ForeColor=Color.FromArgb(0,0,255);
			treeView1.Nodes.Clear();
			treeView2.Nodes.Clear();
			ref_check();
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
			else if (bUngbuou)
			{
				t_v.Text="";
				n_v.Text="";
				m_v.Text="";
				giaidoan_v.Text="";
			}
			tdvh.Text="";
			ngaybong.Text="";
			s_ngaybong="";
		}

		private void ref_check()
		{
			phauthuat.Checked=false;
			l_phauthuat.ForeColor=Color.FromArgb(0,0,255);
			thuthuat.Checked=false;
			l_thuthuat.ForeColor=Color.FromArgb(0,0,255);
			tainantt.Checked=false;
			l_tainantt.ForeColor=Color.FromArgb(0,0,255);
			chidinh.Checked=false;
			l_chidinh.ForeColor=Color.FromArgb(0,0,255);
			vienphi.Checked=false;
			l_vienphi.ForeColor=Color.FromArgb(0,0,255);
			kemtheo.Checked=false;
			l_kemtheo.ForeColor=Color.FromArgb(0,0,255);
			cls.Checked=false;
			l_cls.ForeColor=Color.FromArgb(0,0,255);
		}

		private void emp_bhyt()
		{
			sothe.Text="";
			denngay.Text="";
			s_noicap=m.Mabv;
		}

		private void emp_vv()
		{
			ngayvv.Text=m.Ngaygio;
			ngayvk.Text=ngayvv.Text;
			s_ngayvv="";//ngayvv.Text;
			s_ngayvk="";//ngayvk.Text;
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
			if (bSankhoa)
			{
				ngayde.Text="";
				s_ngayde="";
				cachthucde.SelectedIndex=-1;
				matb.Text="";
				tentb.SelectedIndex=-1;
				kiemsoat.Checked=false;
			}
			s_icd_noichuyenden="";
			s_icd_kkb="";
			s_madstt=m.Mabv;
			para1.Text="";para2.Text="";para3.Text="";para4.Text="";
			if (pmat.Visible)
			{
				mp.Text="";mt.Text="";
				nhanapp.Text="";nhanapt.Text="";
			}
		}

		private void emp_rv()
		{
			cd_vaokhoa.Text="";
			icd_vaokhoa.Text="";
			cd_kemtheo.Text="";
			icd_kemtheo.Text="";
			if (!bPhonggiuong) giuong.Text="";
			tenbs.SelectedIndex=-1;
			s_icd_vaokhoa="";
			s_icd_kemtheo="";
		}

		private void butTiep_Click(object sender, System.EventArgs e)
		{
			lbltieusu.ForeColor=Color.Black;
			emp_text(false);
			Load_dshienhien_cho(s_makp);
			if(dshd.Tables[0].Rows.Count<=0)
			{
				mabn2.Focus();
				danhsach.Visible=false;
			}
			else
			{
				danhsach.Visible=true;
				list.Focus();
			}
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
				if (!m.Kiemtra_maicd(dticd,icd_noichuyenden.Text))
				{
					MessageBox.Show(lan.Change_language_MessageText("Mã ICD không hợp lệ !"),LibMedi.AccessData.Msg);
					icd_noichuyenden.Focus();
					return false;
				}
				if (!m.Kiemtra_tenbenh(dticd,cd_noichuyenden.Text))
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
					if (sothe.Text=="")
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
			if (!m.Kiemtra_maicd(dticd,icd_kemtheo.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Mã ICD không hợp lệ !"),LibMedi.AccessData.Msg);
				icd_kemtheo.Focus();
				return false;
			}
			if (!m.Kiemtra_tenbenh(dticd,cd_kemtheo.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Chẩn đoán không hợp lệ !"),LibMedi.AccessData.Msg);
				cd_kemtheo.Focus();
				return false;
			}
			if (mabs.Text=="" || tenbs.SelectedIndex==-1)
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
//				if (para=="" || para=="00000000")
//				{
//					MessageBox.Show(lan.Change_language_MessageText("Nhập tiền thai (Para) !"),s_msg);
//					ss_para1.Focus();
//					return false;
//				}
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
			if (ngayvk.Text!=s_ngayvk)
			{
				string s_tenkp=m.bHiendien(l_maql);
				if (s_tenkp!="")
				{
					MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân đang hiện diện trong khoa {")+s_tenkp.Trim().ToUpper()+"}"+"\n"+lan.Change_language_MessageText("Không thể thêm được phải xuất bệnh nhân này ra trước khi nhập khoa !"),s_msg);
					butBoqua_Click(null,null);
					return false;
				}
				if (m.get_maql_ravien(l_maql))
				{
					MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân vào viện ngày "+ngayvv.Text+" đã xuất viện !"),s_msg);
					butBoqua_Click(null,null);
					return false;
				}
			}
			string sql="select * from nhapkhoa a, hiendien b where a.id=b.id and a.makp='"+s_makp+"' and a.maql="+l_maql+" and b.nhapkhoa=1";
			sql+=" and to_char(a.ngay,'dd/mm/yyyy hh24:mi')='"+ngayvk.Text+"'";
			sql+=" order by a.ngay desc";
			if (m.get_data(sql).Tables[0].Rows.Count==0)
			{
				DataTable dt=m.get_data("select makp,ngaychuyen from chuyenkhoa where khoaden='"+s_makp+"'"+" and maql="+l_maql+" order by ngaychuyen desc").Tables[0];
				if (dt.Rows.Count!=0)
				{
					ngayvk.Text=m.DateToString("dd/MM/yyyy HH:mm",DateTime.Parse(dt.Rows[0][1].ToString()));
					s_ngayvk=ngayvk.Text;
					tenkp.SelectedValue=dt.Rows[0][0].ToString();
				}
				else
				{
					string ma=m.get_makp(l_maql);
					if (ma==s_makp) tenkp.SelectedValue="01";
					else if (!bTiepdon)
					{
						try
						{
							if (ma=="")	MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân này chưa nhập viện !"),LibMedi.AccessData.Msg);
							else MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân này chưa được chỉ định vào khoa !"),LibMedi.AccessData.Msg);
							butBoqua_Click(null,null); 
							return false;
						}
						catch{}
					}
				}
			}
			if (bSothe_mabn)
			{
				if (sothe.Enabled && sothe.Text!="")
				{
					string s=m.mabn_bhyt(mabn2.Text+mabn3.Text,sothe.Text);
					if (s!="")
					{
						MessageBox.Show("Số thẻ "+sothe.Text+"\nĐã có mã người bệnh :"+s+"\nSử dụng !",LibMedi.AccessData.Msg);
						sothe.Focus();
						return false;
					}
				}
			}
			mmyy=m.mmyy(ngayvv.Text);
			if (!m.bMmyy(mmyy)) d.tao_user_mmyy(mmyy,i_userid);
			if (bPhonggiuong && giuong.Text=="")
			{
				MessageBox.Show("Yêu cầu chọn phòng/giường !",LibMedi.AccessData.Msg);
				butPhong.Focus();
				return false;
			}
			if (m.get_data("select * from nhapkhoa where maql="+l_maql+" and to_char(ngay,'dd/mm/yyyy hh24:mi')='"+ngayvk.Text+"'").Tables[0].Rows.Count==0)
			{
				if (!b_nhapvien && m.get_data("select * from hiendien where maql="+l_maql+" and makp='"+s_makp+"' and nhapkhoa=0 and xuatkhoa=0").Tables[0].Rows.Count==0)
				{
					MessageBox.Show("Người bệnh chưa được chỉ định vào khoa !",LibMedi.AccessData.Msg);
					butBoqua.Focus();
					return false;
				}
			}
			return true;
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			if (!kiemtra()) return;
			s_mabn=mabn2.Text+mabn3.Text;
			if (nam.IndexOf(m.mmyy(ngayvv.Text) + "+") == -1) nam = nam + m.mmyy(ngayvv.Text) + "+";
			if (!m.upd_btdbn(s_mabn,hoten.Text,ngaysinh.Text,namsinh.Text,phai.SelectedIndex,mann.Text,madantoc.Text,sonha.Text,thon.Text,cholam.Text,matt.Text,maqu1.Text+maqu2.Text,mapxa1.Text+mapxa2.Text,i_userid,nam))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin hành chính !"),s_msg);
				return;
			}
			l_maql=m.get_maql(1,s_mabn,s_makp,ngayvv.Text,true);
			if (!m.upd_lienhe(l_maql,sonha.Text,thon.Text,cholam.Text,matt.Text,maqu1.Text+maqu2.Text,mapxa1.Text+mapxa2.Text,tuoi.Text.PadLeft(3,'0')+loaituoi.SelectedIndex.ToString(),0,0))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin hành chính !"),s_msg);
				return;
			}
			int itable = m.tableid("", "benhandt");
			if (m.get_maql(1,s_mabn,s_makp,ngayvv.Text,false)!= 0)
			{
				m.upd_eve_tables(itable, i_userid, "upd");
				m.upd_eve_upd_del(itable, i_userid, "upd",s_mabn+"^"+l_maql.ToString()+"^"+s_makp+"^"+ngayvv.Text+"^"+dentu.Text+"^"+nhantu.Text+"^"+lanthu.Text+"^"+tendoituong.SelectedValue.ToString()+"^"+cd_kkb.Text.Trim()+"^"+icd_kkb.Text+"^"+mabs.Text+"^"+sovaovien.Text+"^"+"1"+i_userid.ToString());
			}
			else m.upd_eve_tables(itable, i_userid, "ins");

			if (!m.upd_benhandt(s_mabn,l_maql,s_makp,ngayvv.Text,int.Parse(dentu.Text),int.Parse(nhantu.Text),int.Parse(lanthu.Text),int.Parse(tendoituong.SelectedValue.ToString()),cd_kkb.Text,icd_kkb.Text,mabs.Text,sovaovien.Text,1,i_userid,false,0))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin vào viện !"),s_msg);
				return;
			}
			if (bNhapsoluutru) m.upd_soluutru(l_maql,soluutru.Text);
			long l_matd=m.get_tiepdon(s_mabn,ngayvv.Text);
			if (bTiepdon)
			{
				if (l_matd==0)
				{
					l_matd=m.get_capid(1);
					m.upd_tiepdon_mmyy(s_mabn,l_matd,makp.Text,ngayvv.Text,int.Parse(madoituong.Text),sovaovien.Text,tuoi.Text.PadLeft(3,'0')+loaituoi.SelectedIndex.ToString(),0,i_userid,LibMedi.AccessData.Khoa,0,l_matd);
				}
			}
			m.upd_sukien(s_mabn,l_matd,LibMedi.AccessData.Khoa,l_maql);
			bool bNew=true;long idgiuong=0;
			if (bPhonggiuong)
			{				
				bNew=m.get_data("select id from nhapkhoa where maql="+l_maql+" and makp='"+s_makp+"' and to_char(ngay,'dd/mm/yyyy hh24:mi')='"+ngayvk.Text+"'").Tables[0].Rows.Count==0;
				if (bNew)
				{
					l_id=m.get_id(l_maql,s_makp,ngayvk.Text);
					DataRow r2,r1=m.getrowbyid(dtg,"ma='"+giuong.Text+"'");
					string fie="gia_th";
					long id=v.get_id_vpkhoa;
					if (r1!=null)
					{
						r2=m.getrowbyid(dtdt,"madoituong="+int.Parse(madoituong.Text));
						if (r2!=null) fie=r2["field_gia"].ToString().Trim();
						decimal tygia = (fie.IndexOf("_nn") != -1) ? m.dTygia : 1;
						idgiuong=long.Parse(r1["id"].ToString());
						m.upd_theodoigiuong(id,s_makp,s_mabn,l_maql,l_id,int.Parse(madoituong.Text),int.Parse(r1["id"].ToString()),ngayvk.Text,decimal.Parse(r1[fie].ToString())*tygia,i_userid);
						m.execute_data("update dmgiuong set tinhtrang=2,soluong=soluong+1 where id="+int.Parse(r1["id"].ToString()));
						itable=m.tableid("","theodoigiuong");
						m.upd_eve_tables(itable,i_userid,"ins");
						m.upd_eve_upd_del(itable,i_userid,"ins",m.fields(m.user+".theodoigiuong","id="+id));
					}
					if (m.get_data("select * from datgiuong where mabn='"+s_mabn+"'").Tables[0].Rows.Count>0)
						m.execute_data("update datgiuong set den=to_date('"+ngayvk.Text+"','dd/mm/yyyy hh24:mi') where mabn='"+s_mabn+"' and den is null");
					bNew=false;
				}
			}
			if (bNew) l_id=m.get_id(l_maql,s_makp,ngayvk.Text);
			if (i_maba==0)
			{
				DataRow r=m.getrowbyid(dtba,"mavt='"+maba.Text+"'");
				if (r!=null) i_maba=int.Parse(r[0].ToString());
			}

			itable = m.tableid("","nhapkhoa");
			if (bNew) m.upd_eve_tables(itable, i_userid, "ins");
			else
			{
				m.upd_eve_tables(itable, i_userid, "upd");
				m.upd_eve_upd_del(itable, i_userid, "upd",m.fields(m.user+".nhapkhoa","id="+l_id));
			}

			if (!m.upd_nhapkhoa(l_id,s_mabn,l_maql,s_makp,i_maba,ngayvk.Text,tuoi.Text.PadLeft(3,'0')+loaituoi.SelectedIndex.ToString(),giuong.Text,makp.Text,cd_vaokhoa.Text,icd_vaokhoa.Text,mabs.Text,1,i_userid))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin vào khoa !"),s_msg);
				return;
			}
			if (idgiuong!=0) m.execute_data("update hiendien set idgiuong="+idgiuong+" where id="+l_id);
			string so=m.sothe(int.Parse(tendoituong.SelectedValue.ToString()));
			if (int.Parse(so.Substring(0,2))>0)
			{
				if (!m.upd_bhyt(s_mabn,l_maql,sothe.Text,denngay.Text,s_noicap))
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
			else m.execute_data("delete from nuocngoai where mabn='"+s_mabn+"'");
			if (quanhe.Text!="") m.upd_quanhe(l_maql,quanhe.Text,qh_hoten.Text,qh_diachi.Text,qh_dienthoai.Text);
			if (cd_kemtheo.Text!="") m.upd_cdkemtheo(l_id,l_maql,2,cd_kemtheo.Text,icd_kemtheo.Text,1);
			else m.execute_data("delete from cdkemtheo where stt=1 and loai=2 and id="+l_id);
			if (khamthai.Visible) m.upd_ttkhamthai(s_mabn,l_maql,para1.Text.PadLeft(2,'0')+para2.Text.PadLeft(2,'0')+para3.Text.PadLeft(2,'0')+para4.Text.PadLeft(2,'0'),"","","");
			if (pmat.Visible) m.upd_ttmat(l_maql,mp.Text,mt.Text,nhanapp.Text,nhanapt.Text);
			upd_khac();
			try
			{
				if (sovaovien.Text=="") sovaovien.Text=m.get_data("select sovaovien from benhandt where loaiba=1 and maql="+l_maql).Tables[0].Rows[0][0].ToString();
			}
			catch{}
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
				m.upd_ddsosinh(s_mabn,l_maql,(apgar1.Text!="")?int.Parse(apgar1.Text):0,(apgar5.Text!="")?int.Parse(apgar5.Text):0,(apgar10.Text!="")?int.Parse(apgar10.Text):0,(cannang.Text!="")?int.Parse(cannang.Text):0,(cao.Text!="")?int.Parse(cao.Text):0,(vongdau.Text!="")?int.Parse(vongdau.Text):0,"","",1,"",1,0,0,"","",0,"");
			}
			else if (bBong && ngaybong.Text!="") m.upd_ttbong(l_maql,ngaybong.Text);
			else if (bTamthan && tdvh.Text!="") m.upd_tttamthan(l_maql,tdvh.Text);
			else if (bNhi) m.upd_hcnhi(s_mabn,nhi_hoten_bo.Text,nhi_vanhoa_bo.Text,nhi_mann_bo.Text,nhi_hoten_me.Text,nhi_vanhoa_me.Text,nhi_mann_me.Text);
			else if (bSankhoa && ngayde.Text!="") m.upd_cdsankhoa(l_maql,ngayde.Text,cachthucde.SelectedValue.ToString(),(kiemsoat.Checked)?1:0,matb.Text);
			else if (bUngbuou)
			{
				if (t_v.Text.Trim()+n_v.Text.Trim()+m_v.Text.Trim()+giaidoan_v.Text.Trim()!="")
					m.upd_cdungbuou(l_id,l_maql,t_v.Text.Trim(),n_v.Text.Trim(),m_v.Text.Trim(),giaidoan_v.Text.Trim(),0);
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

		private void ngayvk_Validated(object sender, System.EventArgs e)
		{
			try
			{
				if (ngayvk.Text=="")
				{
					ngayvk.Focus();
					return;
				}
				ngayvk.Text=ngayvk.Text.Trim();
				if (ngayvk.Text.Length<16)
				{
					MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập Ngày và giờ vào viện !"),s_msg);
					ngayvk.Focus();
					return;
				}
				if (!m.bNgay(ngayvk.Text))
				{
					MessageBox.Show(lan.Change_language_MessageText("Ngày và giờ không hợp lệ !"));
					ngayvk.Focus();
					return;
				}
				ngayvk.Text=m.Ktngaygio(ngayvk.Text,16);
				if (!m.bNgaygio(ngayvk.Text,ngayvv.Text))
				{
					MessageBox.Show(lan.Change_language_MessageText("Ngày vào khoa không được nhỏ hơn ngày vào viện !"),s_msg);
					ngayvk.Focus();
					return;
				}
				if (ngayvk.Text!=s_ngayvk || cd_vaokhoa.Text=="")
				{
					try
					{
						if (namsinh.Text!=m.Namsinh("",int.Parse(tuoi.Text),loaituoi.SelectedIndex).ToString())
						{
							tuoi.Text=Convert.ToString(int.Parse(ngayvk.Text.Substring(6,4))-int.Parse(namsinh.Text)).PadLeft(3,'0');
							loaituoi.SelectedIndex=0;
						}
					}
					catch{}
					s_mabn=mabn2.Text+mabn3.Text;
					l_maql=m.get_maql(1,s_mabn,"??",ngayvv.Text,false);
					if (l_maql!=0)
					{
						if (!load_vk(true))
						{
							if (m.get_maql_ravien(l_maql))
							{
								MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân vào viện ngày "+ngayvv.Text+" đã xuất viện !"),s_msg);
								butBoqua_Click(null,null);
								return;
							}
							string s_tenkp=m.bHiendien(l_maql);
							if (s_tenkp!="")
							{
								MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân đang hiện diện trong khoa {")+s_tenkp.Trim().ToUpper()+"}"+"\n"+lan.Change_language_MessageText("Không thể thêm được phải xuất bệnh nhân này ra trước khi nhập khoa !"),s_msg);
								butBoqua_Click(null,null);
								return;
							}
							if (!m.ngay(m.StringToDate(ngayvk.Text.Substring(0,10)),DateTime.Now,songay))
							{
								MessageBox.Show(lan.Change_language_MessageText("Ngày vào khoa không hợp lệ so với khai báo hệ thống (")+songay.ToString()+")!",s_msg);
								ngayvk.Focus();
								s_ngayvk="";
								return;
							}
							emp_rv();
						}
					}
					else
					{
						if (!m.ngay(m.StringToDate(ngayvk.Text.Substring(0,10)),DateTime.Now,songay))
						{
							MessageBox.Show(lan.Change_language_MessageText("Ngày vào khoa không hợp lệ so với khai báo hệ thống (")+songay.ToString()+")!",s_msg);
							ngayvk.Focus();
							s_ngayvk="";
							return;
						}
						emp_rv();
					}
					s_ngayvk=ngayvk.Text;
				}
			}
			catch{}
		}

		private void ngayvv_Validated(object sender, System.EventArgs e)
		{
			if (ngayvv.Text=="")
			{
				ngayvv.Focus();
				return;
			}
			ngayvv.Text=ngayvv.Text.Trim();
			if (ngayvv.Text.Length<16)
			{
				MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập Ngày và giờ vào viện !"),s_msg);
				ngayvv.Focus();
				return;
			}
			if (!m.bNgay(ngayvv.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Ngày và giờ không hợp lệ !"));
				ngayvv.Focus();
				return;
			}
			ngayvv.Text=m.Ktngaygio(ngayvv.Text,16);
			if (ngayvv.Text!=s_ngayvv)
			{
				ref_check();
				try
				{
					if (tuoi.Text!="")
					{
						if (namsinh.Text!=m.Namsinh("",int.Parse(tuoi.Text),loaituoi.SelectedIndex).ToString())
						{
							tuoi.Text=Convert.ToString(int.Parse(ngayvv.Text.Substring(6,4))-int.Parse(namsinh.Text)).PadLeft(3,'0');
							loaituoi.SelectedIndex=0;
						}
					}
				}
				catch{}
				string s=ngayvv.Text;
				s_ngayvv=ngayvv.Text;
				s_mabn=mabn2.Text+mabn3.Text;
				l_maql=m.get_maql(1,s_mabn,"??",ngayvv.Text,false);
				if (l_maql!=0)
				{
					load_vv_maql(true);
					//load_vk(false);
					ngayvv.Text=s;
					if (!bAdmin) ena_but(false);
				}
				else
				{
					if (!bTiepdon)
					{
						if (m.get_tiepdon(s_mabn,ngayvv.Text)==0)
						{
							MessageBox.Show(lan.Change_language_MessageText("Người bệnh này chưa qua đăng ký khám bệnh !"),s_msg);
							butBoqua_Click(sender,e);
							return; 
						}
					}
					string s_tenkp=m.bHiendien(s_mabn,1);
					if (s_tenkp!="")
					{
						MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân đang điều trị trong khoa {")+s_tenkp.Trim().ToUpper()+"}"+"\n"+lan.Change_language_MessageText("Không thể thêm được phải xuất bệnh nhân này ra trước khi nhập viện !"),s_msg);
						butBoqua_Click(null,null);
						return;
					}
					else
					{
						s_tenkp=m.bNhapvien(s_mabn,l_maql,1);
						if (s_tenkp!="")
						{
							MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân đã được nhập viện vào khoa {")+s_tenkp.Trim().ToUpper()+"}"+"\n"+lan.Change_language_MessageText("Không thể thêm được phải xuất bệnh nhân này ra trước khi nhập viện !"),s_msg);
							butBoqua_Click(null,null);
							return;
						}
					}
					if (!m.ngay(m.StringToDate(ngayvv.Text.Substring(0,10)),DateTime.Now,songay))
					{
						MessageBox.Show(lan.Change_language_MessageText("Ngày vào viện không hợp lệ so với khai báo hệ thống (")+songay.ToString()+")!",s_msg);
						ngayvv.Focus();
						s_ngayvv="";
						return;
					}
					ena_but(true);
					emp_vv();
					emp_bhyt();
					emp_rv();
					if (ngayvv.Text!="") load_tiepdon(ngayvv.Text.Substring(0,10),false);
					ngayvv.Text=s;
					ngayvk.Text=s;
				}
			}
		}

		private void load_tiepdon(string m_ngay,bool skip)
		{
			string user=m.user,mmyy=m.mmyy(m_ngay);
			if (!m.bMmyy(mmyy)) return;
			sql="select * from "+user+mmyy+".tiepdon where mabn='"+s_mabn+"'"+" and to_char(ngay,'dd/mm/yyyy')='"+m_ngay+"'";
			sql+=" order by ngay desc";
			foreach(DataRow r in m.get_data(sql).Tables[0].Rows)
			{
				if (skip)
				{
					ngayvv.Text=m.DateToString("dd/MM/yyyy HH:mm",DateTime.Parse(r["ngay"].ToString()));
					s_ngayvv=ngayvv.Text;
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
				l_maql=long.Parse(r["maql"].ToString());
				break;
			}
			if (l_maql!=0)
			{
				emp_bhyt();
				foreach(DataRow r in m.get_data("select * from "+user+mmyy+".quanhe where maql="+l_maql).Tables[0].Rows)
				{
					quanhe.Text=r["quanhe"].ToString();
					qh_hoten.Text=r["hoten"].ToString();
					qh_diachi.Text=r["diachi"].ToString();
					qh_dienthoai.Text=r["dienthoai"].ToString();
				}
				string so=m.sothe(int.Parse(tendoituong.SelectedValue.ToString()));
				if (int.Parse(so.Substring(0,2))>0)
				{
					foreach(DataRow r in m.get_data("select * from "+user+mmyy+".bhyt where maql="+l_maql).Tables[0].Rows)
					{
						sothe.Text=r["sothe"].ToString();
						if (r["denngay"].ToString()!="")
							denngay.Text=m.DateToString("dd/MM/yyyy",DateTime.Parse(r["denngay"].ToString()));
					}
				}
				if (khamthai.Visible)
				{
					foreach(DataRow r in m.get_data("select * from "+user+mmyy+".ttkhamthai where maql="+l_maql).Tables[0].Rows)
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
			foreach(DataRow r in m.get_data("select ngay,chandoan from benhandt where loaiba=1 and mabn='"+s_mabn+"'"+" order by ngay desc").Tables[0].Rows)
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
						load_vk(false);
						ngayvv.Text=ngay;
						load_treeView2();
					}
				}
				catch{}
			}
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
		}

		private void l_phauthuat_Click(object sender, System.EventArgs e)
		{
			if (!bSankhoa) return;
			s_mabn=mabn2.Text+mabn3.Text;
			if (ngayde.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập ngày đẻ (mổ đẻ) !"),s_msg);
				ngayde.Focus();
				return;
			}
			l_maql=m.get_maql(1,s_mabn,s_makp,ngayvv.Text,false);
			if (l_maql==0)
			{
				if (!kiemtra()) return;
				butLuu_Click(null,null);
			}
			frmTresosinh f=new frmTresosinh(m,s_mabn,hoten.Text,tuoi.Text.PadLeft(3,'0')+"T",l_maql,ngayde.Text,i_userid,tentinh.SelectedValue.ToString(),tenquan.SelectedValue.ToString(),tenpxa.SelectedValue.ToString());
			f.ShowDialog();
			load_phauthuat();
		}

		private void l_thuthuat_Click(object sender, System.EventArgs e)
		{
			s_mabn=mabn2.Text+mabn3.Text;
			l_maql=m.get_maql(1,s_mabn,s_makp,ngayvv.Text,false);
			if (l_maql==0)
			{
				if (!kiemtra()) return;
				butLuu_Click(null,null);
			}
			frmPttt f=new frmPttt(m,s_makp,s_mabn,hoten.Text,tuoi.Text.PadLeft(3,'0')+loaituoi.SelectedIndex.ToString(),phai.Text,sonha.Text.Trim()+" "+thon.Text,sothe.Text,giuong.Text,ngayvv.Text,cd_vaokhoa.Text,icd_vaokhoa.Text,"T",i_userid,"","","","","","",0,0,0,0,0,"",0);
			f.ShowDialog();
			load_thuthuat();		
		}

		private void sovaovien_Validated(object sender, System.EventArgs e)
		{
			if (sovaovien.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập số vào viện !"),s_msg);
				sovaovien.Focus();
				return;
			}
			if (m.blSovaovien(ngayvv.Text,1,sovaovien.Text,l_maql))
			{
				MessageBox.Show(lan.Change_language_MessageText("Số vào viện này đã có !"),s_msg);
				sovaovien.Focus();
				return;
			}
		}

		private void soluutru_Validated(object sender, System.EventArgs e)
		{
			if (soluutru.Text=="") return;
			if (m.blSoluutru(soluutru.Text,l_maql,"lienhe"))
			{
				MessageBox.Show(lan.Change_language_MessageText("Số lưu trữ này đã có !"),s_msg);
				soluutru.Focus();
				return;
			}
		}

		private void tenkp_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				makp.Text=tenkp.SelectedValue.ToString();
			}
			catch{makp.Text="01";}
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
				if (!m.bNgaygio(ngayvk.Text,ngaybong.Text))
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

		private void ngayde_Validated(object sender, System.EventArgs e)
		{
			if (ngayde.Text=="")
			{
				icd_kemtheo.Focus();
				return;
			}
			ngayde.Text=ngayde.Text.Trim();
			if (ngayde.Text!=s_ngayde)
			{
				if (ngayde.Text.Length<16)
				{
					MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập ngày và giờ !"),s_msg);
					ngayde.Focus();
					return;
				}
				if (!m.bNgay(ngayde.Text))
				{
					MessageBox.Show(lan.Change_language_MessageText("Ngày và giờ không hợp lệ !"));
					ngayde.Focus();
					return;
				}
				ngayde.Text=m.Ktngaygio(ngayde.Text,16);
				if (!m.bNgaygio(ngayde.Text,ngayvk.Text))
				{
					MessageBox.Show(lan.Change_language_MessageText("Ngày đẻ (mổ đẻ) không được nhỏ hơn ngày vào viện !"),s_msg);
					ngayde.Focus();
					return;
				}

				if (!m.ngay(m.StringToDate(ngayde.Text.Substring(0,10)),DateTime.Now,songay))
				{
					MessageBox.Show(lan.Change_language_MessageText("Ngày đẻ (mổ đẻ) không hợp lệ so với khai báo hệ thống (")+songay.ToString()+")!",s_msg);
					ngayde.Focus();
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
//			if (ss_para1.Text+ss_para2.Text+ss_para3.Text+ss_para4.Text=="00000000")
//			{
//				MessageBox.Show(lan.Change_language_MessageText("Tiền thai (Para) không hợp lệ !"),s_msg);
//				ss_para1.Focus();
//			}
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

		private void kiemsoat_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{Home}");
		}

		private void load_treeView2()
		{
			treeView2.Nodes.Clear();
			TreeNode node;
			foreach(DataRow r in m.get_data("select ngay,chandoan from nhapkhoa where makp='"+s_makp+"'"+" and maql="+l_maql+" order by ngay desc").Tables[0].Rows)
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
					ngayvk.Text=ngay;
					load_vk(true);
				}
				catch{}
			}
		}

		private void l_tainantt_Click(object sender, System.EventArgs e)
		{
			s_mabn=mabn2.Text+mabn3.Text;
			l_maql=m.get_maql(1,s_mabn,s_makp,ngayvv.Text,false);
			if (l_maql==0)
			{
				if (!kiemtra()) return;
				butLuu_Click(null,null);
			}
			frmTainantt f=new frmTainantt(m,l_maql,s_mabn,ngayvv.Text,hoten.Text,namsinh.Text,tennn.Text,sonha.Text.Trim()+" "+thon.Text,i_userid);
			f.ShowDialog();
			load_tainantt();
		}

		private void load_btdnn(int i)
		{
			if (i==0) tennn.DataSource=m.get_data("select * from btdnn_bv order by mann").Tables[0];
			else
			{
				if (namsinh.Text!="")
				{
					if (DateTime.Now.Year-int.Parse(namsinh.Text)<iTreem6)
						tennn.DataSource=m.get_data("select * from btdnn_bv where mannbo='01' order by mann").Tables[0];
					else if (DateTime.Now.Year-int.Parse(namsinh.Text)<iTreem15)
						tennn.DataSource=m.get_data("select * from btdnn_bv where mannbo in ('01','02') order by mann").Tables[0];
					else tennn.DataSource=m.get_data("select * from btdnn_bv where mannbo<>'01' order by mann").Tables[0];
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
				if (bChandoan || icd_kkb.Text=="")
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
				if (bChandoan || icd_noichuyenden.Text=="")
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
				if (bChandoan || icd_vaokhoa.Text=="")
				{
					Filt_ICD(cd_vaokhoa.Text);
					if (bSankhoa) listICD.BrowseToICD10(cd_vaokhoa,icd_vaokhoa,ngayde,icd_kkb.Location.X-8,pvaovien.Location.Y+8*icd_kemtheo.Height+12,icd_kemtheo.Width+cd_kemtheo.Width+2,icd_kemtheo.Height);
					else if (bUngbuou) listICD.BrowseToICD10(cd_vaokhoa,icd_vaokhoa,t_v,icd_kkb.Location.X-8,pvaovien.Location.Y+8*icd_kemtheo.Height+12,icd_kemtheo.Width+cd_kemtheo.Width+2,icd_kemtheo.Height);
					else listICD.BrowseToICD10(cd_vaokhoa,icd_vaokhoa,icd_kemtheo,icd_kkb.Location.X-8,pvaovien.Location.Y+8*icd_kemtheo.Height+12,icd_kemtheo.Width+cd_kemtheo.Width+2,icd_kemtheo.Height);
				}
			}		
		}

		private void cd_kemtheo_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==cd_kemtheo)
			{
				if (bChandoan || icd_kemtheo.Text=="")
				{
					Filt_ICD(cd_kemtheo.Text);
					if (giuong.Enabled)
						listICD.BrowseToICD10(cd_kemtheo,icd_kemtheo,giuong,icd_kemtheo.Location.X,icd_kemtheo.Location.Y+icd_kemtheo.Height,icd_kemtheo.Width+cd_kemtheo.Width+2,icd_kemtheo.Height);
					else
						listICD.BrowseToICD10(cd_kemtheo,icd_kemtheo,butPhong,icd_kemtheo.Location.X,icd_kemtheo.Location.Y+icd_kemtheo.Height,icd_kemtheo.Width+cd_kemtheo.Width+2,icd_kemtheo.Height);
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

		private void l_chidinh_Click(object sender, System.EventArgs e)
		{
			s_mabn=mabn2.Text+mabn3.Text;
			l_maql=m.get_maql(1,s_mabn,s_makp,ngayvv.Text,false);
			if (l_maql==0)
			{
				if (!kiemtra()) return;
				butLuu_Click(null,null);
			}
//			frmChidinh f=new frmChidinh(m,s_mabn,hoten.Text,tuoi.Text+" "+loaituoi.Text,ngayvk.Text,s_makp,m.get_data("select tenkp from btdkp_bv where makp='"+s_makp+"'").Tables[0].Rows[0][0].ToString(),int.Parse(madoituong.Text),v.iNoitru,l_maql,l_id,i_userid,"nhapkhoa",sothe.Text,"",mabs.Text,cd_kkb.Text,bAdmin,l_maql);
//			f.ShowDialog(this);
//			load_chidinh();
		}

		private void l_vienphi_Click(object sender, System.EventArgs e)
		{
			s_mabn=mabn2.Text+mabn3.Text;
			l_maql=m.get_maql(1,s_mabn,s_makp,ngayvv.Text,false);
			if (l_maql==0)
			{
				if (!kiemtra()) return;
				butLuu_Click(null,null);
			}
//			frmChonthongsovp f1=new frmChonthongsovp(m,s_makp,i_userid);
//			f1.ShowDialog(this);
//			if (f1.s_makp!="")
//			{
//				frmChonvpk f=new frmChonvpk(m,s_mabn,hoten.Text,tuoi.Text+" "+loaituoi.Text,f1.s_ngay,f1.s_makp,f1.s_tenkp,int.Parse(madoituong.Text),l_maql,l_id,i_userid,"nhapkhoa",f1.i_buoi,sothe.Text);
//				f.ShowDialog(this);
//				load_vienphi();
//			}
		}

		private void load_kemtheo()
		{
			kemtheo.Checked=m.get_data("select * from cdkemtheo where stt>1 and loai=2 and id="+l_id).Tables[0].Rows.Count!=0;
			l_kemtheo.ForeColor=(kemtheo.Checked)?Color.FromArgb(255,0,0):Color.FromArgb(0,0,255);
		}

		private void l_kemtheo_Click(object sender, System.EventArgs e)
		{
			if (icd_kemtheo.Text=="" || cd_kemtheo.Text=="")
			{
				icd_kemtheo.Focus();
				return;
			}
			s_mabn=mabn2.Text+mabn3.Text;
			l_maql=m.get_maql(1,s_mabn,s_makp,ngayvv.Text,false);
			if (l_maql==0) luu();
			else 
			{
				l_id=m.get_id(l_maql,s_makp,ngayvk.Text);
				if (cd_kemtheo.Text!="") m.upd_cdkemtheo(l_id,l_maql,2,cd_kemtheo.Text,icd_kemtheo.Text,1);
			}
//			frmCdkemtheo f=new frmCdkemtheo(m,l_id,l_maql,2,"");
//			f.ShowDialog();
//			load_kemtheo();
		}

		private void luu()
		{
			if (!m.upd_btdbn(s_mabn,hoten.Text,ngaysinh.Text,namsinh.Text,phai.SelectedIndex,mann.Text,madantoc.Text,sonha.Text,thon.Text,cholam.Text,matt.Text,maqu1.Text+maqu2.Text,mapxa1.Text+mapxa2.Text,i_userid))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin hành chính !"),s_msg);
				return;
			}
			l_maql=m.get_maql(1,s_mabn,s_makp,ngayvv.Text,true);
			if (!m.upd_lienhe(l_maql,sonha.Text,thon.Text,cholam.Text,matt.Text,maqu1.Text+maqu2.Text,mapxa1.Text+mapxa2.Text,tuoi.Text.PadLeft(3,'0')+loaituoi.SelectedIndex.ToString(),0,0))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin hành chính !"),s_msg);
				return;
			}
			if (!m.upd_benhandt(s_mabn,l_maql,s_makp,ngayvv.Text,int.Parse(dentu.Text),int.Parse(nhantu.Text),int.Parse(lanthu.Text),int.Parse(tendoituong.SelectedValue.ToString()),cd_kkb.Text,icd_kkb.Text,mabs.Text,sovaovien.Text,1,i_userid,false,0))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin vào viện !"),s_msg);
				return;
			}
			long l_matd=m.get_tiepdon(s_mabn,ngayvv.Text);
			if (bTiepdon)
			{
				if (l_matd==0)
				{
					l_matd=m.get_capid(1);
					m.upd_tiepdon(s_mabn,l_matd,makp.Text,ngayvv.Text,int.Parse(madoituong.Text),sovaovien.Text,tuoi.Text.PadLeft(3,'0')+loaituoi.SelectedIndex.ToString(),0,i_userid,LibMedi.AccessData.Khoa,0);
				}
			}
			m.upd_sukien(s_mabn,l_matd,LibMedi.AccessData.Khoa,l_maql);
			l_id=m.get_id(l_maql,s_makp,ngayvk.Text);//tinh them gio
			if (i_maba==0)
			{
				DataRow r=m.getrowbyid(dtba,"mavt='"+maba.Text+"'");
				if (r!=null) i_maba=int.Parse(r[0].ToString());
			}
			if (!m.upd_nhapkhoa(l_id,s_mabn,l_maql,s_makp,i_maba,ngayvk.Text,tuoi.Text.PadLeft(3,'0')+loaituoi.SelectedIndex.ToString(),giuong.Text,makp.Text,cd_vaokhoa.Text,icd_vaokhoa.Text,mabs.Text,1,i_userid))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin vào khoa !"),s_msg);
				return;
			}
			if (cd_kemtheo.Text!="") m.upd_cdkemtheo(l_id,l_maql,2,cd_kemtheo.Text,icd_kemtheo.Text,1);
			if (khamthai.Visible) m.upd_ttkhamthai(s_mabn,l_maql,para1.Text.PadLeft(2,'0')+para2.Text.PadLeft(2,'0')+para3.Text.PadLeft(2,'0')+para4.Text.PadLeft(2,'0'),"","","");
		}

		private void l_diungthuoc_Click(object sender, System.EventArgs e)
		{
			s_mabn=mabn2.Text+mabn3.Text;
			l_maql=m.get_maql(1,s_mabn,s_makp,ngayvv.Text,false);
			if (l_maql==0) luu();
			frmDiungthuoc f=new frmDiungthuoc(m,s_mabn,hoten.Text,tuoi.Text+" "+loaituoi.Text,sonha.Text.Trim()+" "+thon.Text.Trim()+" "+tenpxa.Text.Trim()+","+tenquan.Text.Trim()+","+tentinh.Text.Trim());
			f.ShowDialog(this);
			load_diungthuoc();
		}

		private void l_cls_Click(object sender, System.EventArgs e)
		{
			if (mabn2.Text=="" || mabn3.Text=="" || hoten.Text=="") return;
			frmCanlamsan.frmXemCanLamSan_medi f=new frmCanlamsan.frmXemCanLamSan_medi(mabn2.Text+mabn3.Text,hoten.Text,tuoi.Text+" "+loaituoi.Text,sonha.Text.Trim()+" "+thon.Text.Trim());
			f.ShowDialog(this);
		}

		private void mame_Validated(object sender, System.EventArgs e)
		{
			lblme.Text="";
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
			foreach(DataRow r in m.get_data("select * from btdbn where mabn='"+mame.Text+"'").Tables[0].Rows)
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
				if (manuoc.Enabled) tennuoc.SelectedValue=m.get_data("select id_nuoc from nuocngoai where mabn='"+mame.Text+"'").Tables[0].Rows[0][0].ToString();
				break;
			}
			foreach(DataRow r in m.get_data("select * from ddsosinh where mabn='"+mame.Text+"' order by maql desc").Tables[0].Rows)
			{
				apgar1.Text=(r["apgar1"].ToString()=="0")?"":r["apgar1"].ToString();
				apgar5.Text=(r["apgar5"].ToString()=="0")?"":r["apgar5"].ToString();
				apgar10.Text=(r["apgar10"].ToString()=="0")?"":r["apgar10"].ToString();
				cannang.Text=(r["cannang"].ToString()=="0")?"":r["cannang"].ToString();
				cao.Text=(r["cao"].ToString()=="0")?"":r["cao"].ToString();
				vongdau.Text=(r["vongdau"].ToString()=="0")?"":r["vongdau"].ToString();
				break;
			}
			foreach(DataRow r in m.get_data("select * from ttkhamthai where mabn='"+mame.Text+"' order by maql desc").Tables[0].Rows)
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
			lblme.Text="";
			sql="select nvl(d.ten,'') as ten,c.tenkp from nhapkhoa a,xuatkhoa b,btdkp_bv c,ttxk d";
			sql+=" where a.id=b.id(+) and a.makp=c.makp and b.ttlucrk=d.ma(+) and a.mabn='"+mame.Text+"' order by a.ngay desc";
			foreach(DataRow r in m.get_data(sql).Tables[0].Rows)
			{
				lblme.Text="MẸ : "+((r["ten"].ToString()=="")?"ĐANG ĐIỀU TRỊ TẠI":r["ten"].ToString().Trim().ToUpper())+" "+r["tenkp"].ToString().Trim().ToUpper();
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

		#region Binh_dshangdoi
		private void Load_dshienhien_cho(string s_makp)
		{
			string ngay=DateTime.Now.Day.ToString().PadLeft(2,'0')+"/"+DateTime.Now.Month.ToString().PadLeft(2,'0')+"/"+DateTime.Now.Year.ToString().PadLeft(4,'0');
			sql="select a.mabn msbn, b.hoten, b.namsinh,to_char(a.ngay,'dd/mm/yyyy') ngayvv, a.* "+
				" from hiendien a, btdbn b where a.mabn=b.mabn and a.nhapkhoa=0 and a.xuatkhoa=0";
			if(s_mabn!="")sql+=" and a.makp='"+s_makp+"'";
			sql+=" and to_date(a.ngay,'dd/mm/yy') between to_date('"+ngay+"','dd/mm/yy')-"+songay+" and to_date('"+ngay+"','dd/mm/yy')+"+songay;
			dshd=m.get_data(sql);
			list.DataSource=dshd.Tables[0];
			if(dshd.Tables[0].Rows.Count>0)
				danhsach.Visible=true;
			else
				danhsach.Visible=false;
		}
		private void get_benhnhan(long id)
		{
			DataRow r=m.getrowbyid(dshd.Tables[0],"id="+id);
			if(r!=null)
			{
				s_mabn=r["mabn"].ToString();
				l_maql=long.Parse(r["maql"].ToString());
				mabn2.Text=s_mabn.Substring(0,2);
				mabn3.Text=s_mabn.Substring(2);
				mabn3_Validated(null,null);
				l_id=id;
			}
		}
		#endregion

		private void list_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			//binh
			if(e.KeyCode==Keys.Enter)
			{
				if(list.SelectedIndex<0)
				{
					danhsach.Visible=false;
					l_id=0;
					mabn1.Focus();
				}
				else
				{
					l_id=long.Parse(list.SelectedValue.ToString());
					danhsach.Visible=false;
					get_benhnhan(l_id);					
					l_id=long.Parse(list.SelectedValue.ToString());
				}
			}
			else if(e.KeyCode==Keys.Escape)
			{
				mabn1.Focus();
				danhsach.Visible=false;
				l_id=0;
				mabn1.Focus();
			}
		}

		private void list_DoubleClick(object sender, System.EventArgs e)
		{
			//binh
			if(list.SelectedIndex<0)
			{
				danhsach.Visible=false;
				l_id=0;
				mabn1.Focus();
			}
			else
			{
				l_id=long.Parse(list.SelectedValue.ToString());
				danhsach.Visible=false;
				get_benhnhan(l_id);					
			}
			//
		}

		private void butRef_Click(object sender, System.EventArgs e)
		{
			Load_dshienhien_cho(s_makp);
		}

		private void butPhong_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (mabn2.Text=="" || mabn3.Text=="") return;		
				if (m.get_data("select * from theodoigiuong where mabn='"+mabn2.Text+mabn3.Text+"' and makp='"+s_makp+"' and den is null").Tables[0].Rows.Count>0)
				{
					MessageBox.Show("Đã chọn phòng/giường\nNếu muốn chuyển phòng/giường thì chọn phần chuyển phòng giường !",LibMedi.AccessData.Msg);
					return;
				}
				frmDsgiuong f=new frmDsgiuong(m,dt,s_makp,int.Parse(madoituong.Text),false,false);
				f.ShowDialog();
				if (f.ma!="") giuong.Text=f.ma;
				if (mabs.Text=="") mabs.Focus();
				else butLuu.Focus();
			}
			catch{}
		}

		private void cachthucde_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (cachthucde.SelectedIndex==-1 && cachthucde.Items.Count>0) cachthucde.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void matb_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
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

		private void tentb_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tentb) matb.Text=tentb.SelectedValue.ToString();
		}

		private void icd_noichuyenden_TextChanged(object sender, System.EventArgs e)
		{
			listICD.Hide();
		}

		private void lbltieusu_Click(object sender, System.EventArgs e)
		{
			if (mabn2.Text.Length+mabn3.Text.Length!=8 || hoten.Text=="") return;
//			frmTheodoitsu f=new frmTheodoitsu(m,mabn2.Text+mabn3.Text,hoten.Text,namsinh.Text,phai.Text);
//			f.ShowDialog();
//			lbltieusu.ForeColor=(m.get_data("select * from theodoitsu where mabn='"+s_mabn+"'").Tables[0].Rows.Count>0)?Color.Red:Color.Black;
		}
	}
}
