using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibMedi;

namespace Medisoft
{
	/// <summary>
	/// Summary description for frmHoichan.
	/// </summary>
	public class frmHoichan : System.Windows.Forms.Form
	{
        Language lan = new Language();
        Bogotiengviet tv = new Bogotiengviet();
        private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();	
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TextBox mabn;
		private System.Windows.Forms.TextBox giuong;
		private System.Windows.Forms.TextBox sothe;
		private System.Windows.Forms.TextBox phai;
		private System.Windows.Forms.TextBox tuoi;
		private System.Windows.Forms.TextBox hoten;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox ngayvv;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox lmau;
		private System.Windows.Forms.TextBox tenmau;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.Label label30;
		private System.Windows.Forms.Label label29;
		private System.Windows.Forms.ComboBox tenphuongphap;
		private System.Windows.Forms.TextBox phuongphap;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label89;
		private System.Windows.Forms.Label label70;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.CheckBox sonde;
		private System.Windows.Forms.Label label72;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.CheckBox rh;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.CheckBox rb0;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.CheckBox rb1;
		private System.Windows.Forms.CheckBox rb3;
		private System.Windows.Forms.CheckBox rb2;
		private System.Windows.Forms.CheckBox rb5;
		private System.Windows.Forms.CheckBox rb4;
		private System.Windows.Forms.CheckBox rb7;
		private System.Windows.Forms.CheckBox rb6;
		private System.Windows.Forms.CheckBox rb9;
		private System.Windows.Forms.CheckBox rb8;
		private System.Windows.Forms.CheckBox rb19;
		private System.Windows.Forms.CheckBox rb18;
		private System.Windows.Forms.CheckBox rb17;
		private System.Windows.Forms.CheckBox rb16;
		private System.Windows.Forms.CheckBox rb15;
		private System.Windows.Forms.CheckBox rb14;
		private System.Windows.Forms.CheckBox rb13;
		private System.Windows.Forms.CheckBox rb12;
		private System.Windows.Forms.CheckBox rb11;
		private System.Windows.Forms.CheckBox rb10;
		private System.Windows.Forms.CheckBox rb27;
		private System.Windows.Forms.CheckBox rb26;
		private System.Windows.Forms.CheckBox rb23;
		private System.Windows.Forms.CheckBox rb22;
		private System.Windows.Forms.CheckBox rb21;
		private System.Windows.Forms.CheckBox rb20;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label label22;
		private MaskedTextBox.MaskedTextBox rb24;
		private MaskedTextBox.MaskedTextBox rb25;
		private MaskedTextBox.MaskedTextBox mau;
		private System.Windows.Forms.ComboBox nhommau;
		private System.Windows.Forms.Label label23;
		private MaskedBox.MaskedBox giomo;
		private MaskedBox.MaskedBox ngaymo;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.CheckBox xq;
		private System.Windows.Forms.TextBox xnkhac;
		private System.Windows.Forms.TextBox ykien;
		private System.Windows.Forms.Label label26;
		private MaskedBox.MaskedBox ngay;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.Label label28;
		private System.Windows.Forms.Label label31;
		private System.Windows.Forms.Label label32;
		private System.Windows.Forms.Label label33;
		private System.Windows.Forms.Label label34;
		private System.Windows.Forms.Label label35;
		private System.Windows.Forms.Label label36;
		private System.Windows.Forms.Label label37;
		private System.Windows.Forms.Label label38;
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
		private System.Windows.Forms.Label label51;
		private System.Windows.Forms.Label label52;
		private MaskedBox.MaskedBox nhietdo;
		private MaskedTextBox.MaskedTextBox huyetap;
		private MaskedTextBox.MaskedTextBox nhiptho;
		private MaskedTextBox.MaskedTextBox cannang;
		private MaskedTextBox.MaskedTextBox mach;
		private System.Windows.Forms.Label label53;
		private System.Windows.Forms.Label label54;
		private System.Windows.Forms.Label label55;
		private System.Windows.Forms.Label label56;
		private System.Windows.Forms.Label label57;
		private System.Windows.Forms.Label label58;
		private System.Windows.Forms.Label label59;
		private System.Windows.Forms.Label label60;
		private System.Windows.Forms.Label label61;
		private System.Windows.Forms.Label label62;
		private System.Windows.Forms.Label label63;
		private System.Windows.Forms.Label label64;
		private System.Windows.Forms.Label label65;
		private System.Windows.Forms.Label label66;
		private System.Windows.Forms.Label label67;
		private System.Windows.Forms.Label label68;
		private System.Windows.Forms.Label label69;
		private System.Windows.Forms.Label label71;
		private System.Windows.Forms.Label label73;
		private System.Windows.Forms.Label label74;
		private System.Windows.Forms.Label label75;
		private System.Windows.Forms.Label label76;
		private System.Windows.Forms.Label label77;
		private System.Windows.Forms.Label label78;
		private System.Windows.Forms.Label label79;
		private System.Windows.Forms.Label label80;
		private System.Windows.Forms.Label label81;
		private System.Windows.Forms.Label label82;
		private MaskedBox.MaskedBox ngaykham;
		private System.Windows.Forms.Label label83;
		private System.Windows.Forms.TextBox tenbstruongk;
		private System.Windows.Forms.TextBox bstruongk;
		private System.Windows.Forms.TextBox tenkhth;
		private System.Windows.Forms.TextBox khth;
		private System.Windows.Forms.TextBox tenptv;
		private System.Windows.Forms.TextBox ptv;
		private System.Windows.Forms.TextBox tengayme;
		private System.Windows.Forms.TextBox gayme;
		private System.Windows.Forms.TextBox tengiamdoc;
		private System.Windows.Forms.TextBox giamdoc;
		private System.Windows.Forms.TextBox thoigian;
		private System.Windows.Forms.TextBox tuthe;
		private System.Windows.Forms.TextBox tenptphu;
		private System.Windows.Forms.TextBox tenptdutru;
		private System.Windows.Forms.TextBox ptdutru;
		private System.Windows.Forms.TextBox ptphu;
		private System.Windows.Forms.TextBox tenptchinh;
		private System.Windows.Forms.TextBox ptchinh;
		private System.Windows.Forms.TextBox tenbs_pass;
		private System.Windows.Forms.TextBox tenbs;
		private System.Windows.Forms.TextBox mabs;
		private System.Windows.Forms.TextBox ketluan;
		private System.Windows.Forms.TextBox thuthuat;
		private System.Windows.Forms.TextBox dukien;
		private System.Windows.Forms.ComboBox mallampati;
		private System.Windows.Forms.ComboBox glodmann;
		private System.Windows.Forms.ComboBox asa;
		private System.Windows.Forms.TextBox denghi;
		private System.Windows.Forms.TextBox dieutri;
		private System.Windows.Forms.TextBox canlamsang;
		private System.Windows.Forms.CheckBox gu;
		private System.Windows.Forms.CheckBox cungcotsong;
		private System.Windows.Forms.TextBox tl_khac;
		private System.Windows.Forms.CheckBox ranggia;
		private System.Windows.Forms.CheckBox seo;
		private System.Windows.Forms.CheckBox cungham;
		private System.Windows.Forms.CheckBox giap;
		private System.Windows.Forms.CheckBox khoiu;
		private System.Windows.Forms.CheckBox luoito;
		private System.Windows.Forms.CheckBox congan;
		private System.Windows.Forms.CheckBox hanche;
		private MaskedTextBox.MaskedTextBox chieucao;
		private MaskedTextBox.MaskedTextBox glasgow;
		private System.Windows.Forms.CheckBox khotho;
		private System.Windows.Forms.CheckBox yeu;
		private System.Windows.Forms.CheckBox nhot;
		private System.Windows.Forms.CheckBox hong;
		private System.Windows.Forms.CheckBox phu;
		private System.Windows.Forms.CheckBox map;
		private System.Windows.Forms.TextBox chitiet;
		private System.Windows.Forms.TextBox giadinh;
		private System.Windows.Forms.CheckBox th_khac;
		private System.Windows.Forms.CheckBox tieuhoa;
		private System.Windows.Forms.CheckBox thuongvi;
		private System.Windows.Forms.CheckBox viemgan;
		private System.Windows.Forms.CheckBox vangda;
		private System.Windows.Forms.CheckBox soithan;
		private System.Windows.Forms.CheckBox tn_khac;
		private System.Windows.Forms.CheckBox suythan;
		private System.Windows.Forms.CheckBox cauthan;
		private System.Windows.Forms.CheckBox hethong;
		private System.Windows.Forms.CheckBox tk_khac;
		private System.Windows.Forms.CheckBox tieuduong;
		private System.Windows.Forms.CheckBox maukdong;
		private System.Windows.Forms.CheckBox tbmmn;
		private System.Windows.Forms.CheckBox buouco;
		private System.Windows.Forms.CheckBox dongkinh;
		private System.Windows.Forms.CheckBox tamthan;
		private System.Windows.Forms.CheckBox hh_khac;
		private System.Windows.Forms.CheckBox copd;
		private System.Windows.Forms.CheckBox horamau;
		private System.Windows.Forms.CheckBox phequan;
		private System.Windows.Forms.CheckBox lao;
		private System.Windows.Forms.CheckBox timbamsinh;
		private System.Windows.Forms.CheckBox suytim;
		private System.Windows.Forms.CheckBox nmct;
		private System.Windows.Forms.CheckBox thatnguc;
		private System.Windows.Forms.CheckBox caoha;
		private System.Windows.Forms.CheckBox matuy;
		private System.Windows.Forms.CheckBox ruou;
		private System.Windows.Forms.CheckBox thuocla;
		private System.Windows.Forms.TextBox diung;
		private System.Windows.Forms.TextBox bieuhien;
		private System.Windows.Forms.CheckBox chkdiung;
		private System.Windows.Forms.CheckBox truyenmau;
		private System.Windows.Forms.CheckBox taibien;
		private System.Windows.Forms.CheckBox te;
		private System.Windows.Forms.CheckBox me;
		private System.Windows.Forms.TextBox mo;
		private System.Windows.Forms.CheckBox chkXML;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.Button butBoqua;
		private LibList.List listBS;
		private LibList.List listpttt;
		private MaskedTextBox.MaskedTextBox mamau;
		private DataTable dtbs=new DataTable();
		private DataTable dtmau=new DataTable();
		private DataSet dsmau=new DataSet();
		private DataSet dslmau=new DataSet();
		private DataSet ds=new DataSet();
		private System.Windows.Forms.TextBox chandoan;
		private LibList.List listBS1;
		private AccessData m;
		private string sql,s_mabn,s_makp,user,xxx,s_tenkp,s_sovaovien,s_ngayvv;
		private int i_userid;
		private decimal l_maql,l_id=0,l_idkhoa,l_idthuchien,l_duyet;
		private bool bAdmin;
		public bool bUpdate=false;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Button butKetthuc;
		private System.Windows.Forms.CheckedListBox chonin;
		private AsYetUnnamedColor.MultiColumnListBoxColor list;
		private System.Windows.Forms.Button butMoi;
		private System.Windows.Forms.TextBox tinhmach;
		private System.Windows.Forms.Label label84;
		private System.Windows.Forms.Label label85;
		private MaskedTextBox.MaskedTextBox bmi;
		private System.Windows.Forms.Label label86;
		private System.Windows.Forms.CheckBox tm_bt;
		private System.Windows.Forms.CheckBox tm_cha;
		private System.Windows.Forms.CheckBox tm_ln;
		private System.Windows.Forms.CheckBox tm_dtn;
		private System.Windows.Forms.Label label87;
		private System.Windows.Forms.TextBox tm_khac;
		private System.Windows.Forms.Label label88;
		private System.Windows.Forms.CheckBox hh_bt;
		private System.Windows.Forms.CheckBox hh_copd;
		private System.Windows.Forms.CheckBox hh_suyen;
		private System.Windows.Forms.TextBox k_hh_khac;
		private System.Windows.Forms.Label label90;
		private System.Windows.Forms.Label label91;
		private System.Windows.Forms.CheckBox nt_bt;
		private System.Windows.Forms.CheckBox nt_bg;
		private System.Windows.Forms.CheckBox nt_td;
		private System.Windows.Forms.Label label92;
		private System.Windows.Forms.TextBox nt_khac;
		private System.Windows.Forms.Label label93;
		private System.Windows.Forms.CheckBox tk_bt;
		private System.Windows.Forms.CheckBox tk_yeu;
		private System.Windows.Forms.Label label94;
		private System.Windows.Forms.TextBox k_tk_khac;
		private System.Windows.Forms.CheckBox cs_bt;
		private System.Windows.Forms.Label label95;
		private System.Windows.Forms.TextBox cs_khac;
		private System.Windows.Forms.TextBox dungcu;
		private System.Windows.Forms.TextBox khac;
		private System.Windows.Forms.Label label96;
		private System.Windows.Forms.Label label97;
		private System.Windows.Forms.Label label98;
		private System.Windows.Forms.TextBox ptttlich;
		private System.Windows.Forms.Button butCls;
        private GroupBox groupBox2;
        private GroupBox groupBox1;
        private GroupBox groupBox5;
        private GroupBox groupBox4;
        private GroupBox groupBox3;
        private GroupBox groupBox6;
        private GroupBox groupBox8;
        private GroupBox groupBox7;
		private System.ComponentModel.IContainer components;

		public frmHoichan(AccessData acc,DataSet _ds,decimal _id,decimal _idthuchien,string _mabn,string _makp,string _tenkp,int userid,bool _admin,string _ngayvv)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			m=acc;ds=_ds;l_id=_id;s_mabn=_mabn;s_makp=_makp;s_tenkp=_tenkp;i_userid=userid;bAdmin=_admin;
			l_idthuchien=_idthuchien;l_duyet=l_id;s_ngayvv=_ngayvv;
            
lan.Read_Language_to_Xml(this.Name.ToString(),this);
lan.Changelanguage_to_English(this.Name.ToString(),this);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHoichan));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ptttlich = new System.Windows.Forms.TextBox();
            this.label98 = new System.Windows.Forms.Label();
            this.dungcu = new System.Windows.Forms.TextBox();
            this.label97 = new System.Windows.Forms.Label();
            this.label96 = new System.Windows.Forms.Label();
            this.khac = new System.Windows.Forms.TextBox();
            this.tenphuongphap = new System.Windows.Forms.ComboBox();
            this.listBS = new LibList.List();
            this.listpttt = new LibList.List();
            this.chandoan = new System.Windows.Forms.TextBox();
            this.tenbstruongk = new System.Windows.Forms.TextBox();
            this.bstruongk = new System.Windows.Forms.TextBox();
            this.tenkhth = new System.Windows.Forms.TextBox();
            this.khth = new System.Windows.Forms.TextBox();
            this.tenptv = new System.Windows.Forms.TextBox();
            this.ptv = new System.Windows.Forms.TextBox();
            this.tengayme = new System.Windows.Forms.TextBox();
            this.gayme = new System.Windows.Forms.TextBox();
            this.tengiamdoc = new System.Windows.Forms.TextBox();
            this.giamdoc = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.ngay = new MaskedBox.MaskedBox();
            this.label26 = new System.Windows.Forms.Label();
            this.ykien = new System.Windows.Forms.TextBox();
            this.xnkhac = new System.Windows.Forms.TextBox();
            this.xq = new System.Windows.Forms.CheckBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.nhommau = new System.Windows.Forms.ComboBox();
            this.mau = new MaskedTextBox.MaskedTextBox();
            this.rb25 = new MaskedTextBox.MaskedTextBox();
            this.rb24 = new MaskedTextBox.MaskedTextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.rb27 = new System.Windows.Forms.CheckBox();
            this.rb26 = new System.Windows.Forms.CheckBox();
            this.rb23 = new System.Windows.Forms.CheckBox();
            this.rb22 = new System.Windows.Forms.CheckBox();
            this.rb21 = new System.Windows.Forms.CheckBox();
            this.rb20 = new System.Windows.Forms.CheckBox();
            this.rb19 = new System.Windows.Forms.CheckBox();
            this.rb18 = new System.Windows.Forms.CheckBox();
            this.rb17 = new System.Windows.Forms.CheckBox();
            this.rb16 = new System.Windows.Forms.CheckBox();
            this.rb15 = new System.Windows.Forms.CheckBox();
            this.rb14 = new System.Windows.Forms.CheckBox();
            this.rb13 = new System.Windows.Forms.CheckBox();
            this.rb12 = new System.Windows.Forms.CheckBox();
            this.rb11 = new System.Windows.Forms.CheckBox();
            this.rb10 = new System.Windows.Forms.CheckBox();
            this.rb9 = new System.Windows.Forms.CheckBox();
            this.rb8 = new System.Windows.Forms.CheckBox();
            this.rb7 = new System.Windows.Forms.CheckBox();
            this.rb6 = new System.Windows.Forms.CheckBox();
            this.rb5 = new System.Windows.Forms.CheckBox();
            this.rb4 = new System.Windows.Forms.CheckBox();
            this.rb3 = new System.Windows.Forms.CheckBox();
            this.rb2 = new System.Windows.Forms.CheckBox();
            this.rb1 = new System.Windows.Forms.CheckBox();
            this.label16 = new System.Windows.Forms.Label();
            this.rb0 = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.rh = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label72 = new System.Windows.Forms.Label();
            this.thoigian = new System.Windows.Forms.TextBox();
            this.tuthe = new System.Windows.Forms.TextBox();
            this.sonde = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.giomo = new MaskedBox.MaskedBox();
            this.ngaymo = new MaskedBox.MaskedBox();
            this.label89 = new System.Windows.Forms.Label();
            this.label70 = new System.Windows.Forms.Label();
            this.tenptphu = new System.Windows.Forms.TextBox();
            this.tenptdutru = new System.Windows.Forms.TextBox();
            this.ptdutru = new System.Windows.Forms.TextBox();
            this.ptphu = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.tenptchinh = new System.Windows.Forms.TextBox();
            this.ptchinh = new System.Windows.Forms.TextBox();
            this.phuongphap = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.mabn = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.hoten = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tuoi = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.phai = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.sothe = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.giuong = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.ngayvv = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tenmau = new System.Windows.Forms.TextBox();
            this.lmau = new System.Windows.Forms.ComboBox();
            this.mamau = new MaskedTextBox.MaskedTextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.diung = new System.Windows.Forms.TextBox();
            this.chkdiung = new System.Windows.Forms.CheckBox();
            this.label38 = new System.Windows.Forms.Label();
            this.bieuhien = new System.Windows.Forms.TextBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.mo = new System.Windows.Forms.TextBox();
            this.me = new System.Windows.Forms.CheckBox();
            this.te = new System.Windows.Forms.CheckBox();
            this.taibien = new System.Windows.Forms.CheckBox();
            this.truyenmau = new System.Windows.Forms.CheckBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.vangda = new System.Windows.Forms.CheckBox();
            this.viemgan = new System.Windows.Forms.CheckBox();
            this.tieuhoa = new System.Windows.Forms.CheckBox();
            this.thuongvi = new System.Windows.Forms.CheckBox();
            this.th_khac = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cauthan = new System.Windows.Forms.CheckBox();
            this.suythan = new System.Windows.Forms.CheckBox();
            this.soithan = new System.Windows.Forms.CheckBox();
            this.tn_khac = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.thuocla = new System.Windows.Forms.CheckBox();
            this.ruou = new System.Windows.Forms.CheckBox();
            this.matuy = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tamthan = new System.Windows.Forms.CheckBox();
            this.dongkinh = new System.Windows.Forms.CheckBox();
            this.maukdong = new System.Windows.Forms.CheckBox();
            this.tieuduong = new System.Windows.Forms.CheckBox();
            this.tbmmn = new System.Windows.Forms.CheckBox();
            this.hethong = new System.Windows.Forms.CheckBox();
            this.tk_khac = new System.Windows.Forms.CheckBox();
            this.buouco = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.caoha = new System.Windows.Forms.CheckBox();
            this.thatnguc = new System.Windows.Forms.CheckBox();
            this.nmct = new System.Windows.Forms.CheckBox();
            this.suytim = new System.Windows.Forms.CheckBox();
            this.timbamsinh = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.phequan = new System.Windows.Forms.CheckBox();
            this.lao = new System.Windows.Forms.CheckBox();
            this.horamau = new System.Windows.Forms.CheckBox();
            this.copd = new System.Windows.Forms.CheckBox();
            this.hh_khac = new System.Windows.Forms.CheckBox();
            this.cs_khac = new System.Windows.Forms.TextBox();
            this.label95 = new System.Windows.Forms.Label();
            this.cungcotsong = new System.Windows.Forms.CheckBox();
            this.gu = new System.Windows.Forms.CheckBox();
            this.k_tk_khac = new System.Windows.Forms.TextBox();
            this.label94 = new System.Windows.Forms.Label();
            this.tk_yeu = new System.Windows.Forms.CheckBox();
            this.tk_bt = new System.Windows.Forms.CheckBox();
            this.label93 = new System.Windows.Forms.Label();
            this.cs_bt = new System.Windows.Forms.CheckBox();
            this.nt_khac = new System.Windows.Forms.TextBox();
            this.label92 = new System.Windows.Forms.Label();
            this.nt_td = new System.Windows.Forms.CheckBox();
            this.nt_bg = new System.Windows.Forms.CheckBox();
            this.nt_bt = new System.Windows.Forms.CheckBox();
            this.label91 = new System.Windows.Forms.Label();
            this.k_hh_khac = new System.Windows.Forms.TextBox();
            this.label90 = new System.Windows.Forms.Label();
            this.hh_suyen = new System.Windows.Forms.CheckBox();
            this.hh_copd = new System.Windows.Forms.CheckBox();
            this.hh_bt = new System.Windows.Forms.CheckBox();
            this.label88 = new System.Windows.Forms.Label();
            this.tm_khac = new System.Windows.Forms.TextBox();
            this.label87 = new System.Windows.Forms.Label();
            this.tm_dtn = new System.Windows.Forms.CheckBox();
            this.tm_ln = new System.Windows.Forms.CheckBox();
            this.tm_cha = new System.Windows.Forms.CheckBox();
            this.tm_bt = new System.Windows.Forms.CheckBox();
            this.label86 = new System.Windows.Forms.Label();
            this.bmi = new MaskedTextBox.MaskedTextBox();
            this.label85 = new System.Windows.Forms.Label();
            this.tinhmach = new System.Windows.Forms.TextBox();
            this.label84 = new System.Windows.Forms.Label();
            this.listBS1 = new LibList.List();
            this.tenbs_pass = new System.Windows.Forms.TextBox();
            this.tenbs = new System.Windows.Forms.TextBox();
            this.mabs = new System.Windows.Forms.TextBox();
            this.label82 = new System.Windows.Forms.Label();
            this.ngaykham = new MaskedBox.MaskedBox();
            this.label83 = new System.Windows.Forms.Label();
            this.ketluan = new System.Windows.Forms.TextBox();
            this.thuthuat = new System.Windows.Forms.TextBox();
            this.dukien = new System.Windows.Forms.TextBox();
            this.mallampati = new System.Windows.Forms.ComboBox();
            this.glodmann = new System.Windows.Forms.ComboBox();
            this.asa = new System.Windows.Forms.ComboBox();
            this.label81 = new System.Windows.Forms.Label();
            this.label80 = new System.Windows.Forms.Label();
            this.label79 = new System.Windows.Forms.Label();
            this.label78 = new System.Windows.Forms.Label();
            this.label77 = new System.Windows.Forms.Label();
            this.label76 = new System.Windows.Forms.Label();
            this.denghi = new System.Windows.Forms.TextBox();
            this.dieutri = new System.Windows.Forms.TextBox();
            this.canlamsang = new System.Windows.Forms.TextBox();
            this.label75 = new System.Windows.Forms.Label();
            this.label74 = new System.Windows.Forms.Label();
            this.label73 = new System.Windows.Forms.Label();
            this.label71 = new System.Windows.Forms.Label();
            this.label69 = new System.Windows.Forms.Label();
            this.label68 = new System.Windows.Forms.Label();
            this.label67 = new System.Windows.Forms.Label();
            this.tl_khac = new System.Windows.Forms.TextBox();
            this.label66 = new System.Windows.Forms.Label();
            this.ranggia = new System.Windows.Forms.CheckBox();
            this.seo = new System.Windows.Forms.CheckBox();
            this.cungham = new System.Windows.Forms.CheckBox();
            this.giap = new System.Windows.Forms.CheckBox();
            this.khoiu = new System.Windows.Forms.CheckBox();
            this.luoito = new System.Windows.Forms.CheckBox();
            this.congan = new System.Windows.Forms.CheckBox();
            this.hanche = new System.Windows.Forms.CheckBox();
            this.label65 = new System.Windows.Forms.Label();
            this.label64 = new System.Windows.Forms.Label();
            this.chieucao = new MaskedTextBox.MaskedTextBox();
            this.label63 = new System.Windows.Forms.Label();
            this.nhietdo = new MaskedBox.MaskedBox();
            this.huyetap = new MaskedTextBox.MaskedTextBox();
            this.nhiptho = new MaskedTextBox.MaskedTextBox();
            this.cannang = new MaskedTextBox.MaskedTextBox();
            this.mach = new MaskedTextBox.MaskedTextBox();
            this.label53 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.label55 = new System.Windows.Forms.Label();
            this.label56 = new System.Windows.Forms.Label();
            this.label57 = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.label59 = new System.Windows.Forms.Label();
            this.label60 = new System.Windows.Forms.Label();
            this.label61 = new System.Windows.Forms.Label();
            this.label62 = new System.Windows.Forms.Label();
            this.glasgow = new MaskedTextBox.MaskedTextBox();
            this.label52 = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.khotho = new System.Windows.Forms.CheckBox();
            this.yeu = new System.Windows.Forms.CheckBox();
            this.nhot = new System.Windows.Forms.CheckBox();
            this.hong = new System.Windows.Forms.CheckBox();
            this.label50 = new System.Windows.Forms.Label();
            this.phu = new System.Windows.Forms.CheckBox();
            this.map = new System.Windows.Forms.CheckBox();
            this.label49 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.chitiet = new System.Windows.Forms.TextBox();
            this.label46 = new System.Windows.Forms.Label();
            this.giadinh = new System.Windows.Forms.TextBox();
            this.label45 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.chkXML = new System.Windows.Forms.CheckBox();
            this.butLuu = new System.Windows.Forms.Button();
            this.butIn = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.list = new AsYetUnnamedColor.MultiColumnListBoxColor();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.chonin = new System.Windows.Forms.CheckedListBox();
            this.butMoi = new System.Windows.Forms.Button();
            this.butCls = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(208, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(808, 712);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ptttlich);
            this.tabPage1.Controls.Add(this.label98);
            this.tabPage1.Controls.Add(this.dungcu);
            this.tabPage1.Controls.Add(this.label97);
            this.tabPage1.Controls.Add(this.label96);
            this.tabPage1.Controls.Add(this.khac);
            this.tabPage1.Controls.Add(this.tenphuongphap);
            this.tabPage1.Controls.Add(this.listBS);
            this.tabPage1.Controls.Add(this.listpttt);
            this.tabPage1.Controls.Add(this.chandoan);
            this.tabPage1.Controls.Add(this.tenbstruongk);
            this.tabPage1.Controls.Add(this.bstruongk);
            this.tabPage1.Controls.Add(this.tenkhth);
            this.tabPage1.Controls.Add(this.khth);
            this.tabPage1.Controls.Add(this.tenptv);
            this.tabPage1.Controls.Add(this.ptv);
            this.tabPage1.Controls.Add(this.tengayme);
            this.tabPage1.Controls.Add(this.gayme);
            this.tabPage1.Controls.Add(this.tengiamdoc);
            this.tabPage1.Controls.Add(this.giamdoc);
            this.tabPage1.Controls.Add(this.label33);
            this.tabPage1.Controls.Add(this.label32);
            this.tabPage1.Controls.Add(this.label31);
            this.tabPage1.Controls.Add(this.label28);
            this.tabPage1.Controls.Add(this.label27);
            this.tabPage1.Controls.Add(this.ngay);
            this.tabPage1.Controls.Add(this.label26);
            this.tabPage1.Controls.Add(this.ykien);
            this.tabPage1.Controls.Add(this.xnkhac);
            this.tabPage1.Controls.Add(this.xq);
            this.tabPage1.Controls.Add(this.label25);
            this.tabPage1.Controls.Add(this.label24);
            this.tabPage1.Controls.Add(this.label23);
            this.tabPage1.Controls.Add(this.nhommau);
            this.tabPage1.Controls.Add(this.mau);
            this.tabPage1.Controls.Add(this.rb25);
            this.tabPage1.Controls.Add(this.rb24);
            this.tabPage1.Controls.Add(this.label22);
            this.tabPage1.Controls.Add(this.label21);
            this.tabPage1.Controls.Add(this.label20);
            this.tabPage1.Controls.Add(this.label19);
            this.tabPage1.Controls.Add(this.rb27);
            this.tabPage1.Controls.Add(this.rb26);
            this.tabPage1.Controls.Add(this.rb23);
            this.tabPage1.Controls.Add(this.rb22);
            this.tabPage1.Controls.Add(this.rb21);
            this.tabPage1.Controls.Add(this.rb20);
            this.tabPage1.Controls.Add(this.rb19);
            this.tabPage1.Controls.Add(this.rb18);
            this.tabPage1.Controls.Add(this.rb17);
            this.tabPage1.Controls.Add(this.rb16);
            this.tabPage1.Controls.Add(this.rb15);
            this.tabPage1.Controls.Add(this.rb14);
            this.tabPage1.Controls.Add(this.rb13);
            this.tabPage1.Controls.Add(this.rb12);
            this.tabPage1.Controls.Add(this.rb11);
            this.tabPage1.Controls.Add(this.rb10);
            this.tabPage1.Controls.Add(this.rb9);
            this.tabPage1.Controls.Add(this.rb8);
            this.tabPage1.Controls.Add(this.rb7);
            this.tabPage1.Controls.Add(this.rb6);
            this.tabPage1.Controls.Add(this.rb5);
            this.tabPage1.Controls.Add(this.rb4);
            this.tabPage1.Controls.Add(this.rb3);
            this.tabPage1.Controls.Add(this.rb2);
            this.tabPage1.Controls.Add(this.rb1);
            this.tabPage1.Controls.Add(this.label16);
            this.tabPage1.Controls.Add(this.rb0);
            this.tabPage1.Controls.Add(this.label13);
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.rh);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label72);
            this.tabPage1.Controls.Add(this.thoigian);
            this.tabPage1.Controls.Add(this.tuthe);
            this.tabPage1.Controls.Add(this.sonde);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.giomo);
            this.tabPage1.Controls.Add(this.ngaymo);
            this.tabPage1.Controls.Add(this.label89);
            this.tabPage1.Controls.Add(this.label70);
            this.tabPage1.Controls.Add(this.tenptphu);
            this.tabPage1.Controls.Add(this.tenptdutru);
            this.tabPage1.Controls.Add(this.ptdutru);
            this.tabPage1.Controls.Add(this.ptphu);
            this.tabPage1.Controls.Add(this.label30);
            this.tabPage1.Controls.Add(this.label29);
            this.tabPage1.Controls.Add(this.tenptchinh);
            this.tabPage1.Controls.Add(this.ptchinh);
            this.tabPage1.Controls.Add(this.phuongphap);
            this.tabPage1.Controls.Add(this.label14);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.mabn);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.hoten);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.tuoi);
            this.tabPage1.Controls.Add(this.label15);
            this.tabPage1.Controls.Add(this.phai);
            this.tabPage1.Controls.Add(this.label17);
            this.tabPage1.Controls.Add(this.sothe);
            this.tabPage1.Controls.Add(this.label18);
            this.tabPage1.Controls.Add(this.giuong);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.ngayvv);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.tenmau);
            this.tabPage1.Controls.Add(this.lmau);
            this.tabPage1.Controls.Add(this.mamau);
            this.tabPage1.Controls.Add(this.label34);
            this.tabPage1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(800, 686);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Hội chẩn";
            // 
            // ptttlich
            // 
            this.ptttlich.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ptttlich.Enabled = false;
            this.ptttlich.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ptttlich.Location = new System.Drawing.Point(152, 45);
            this.ptttlich.Name = "ptttlich";
            this.ptttlich.Size = new System.Drawing.Size(640, 21);
            this.ptttlich.TabIndex = 374;
            // 
            // label98
            // 
            this.label98.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label98.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label98.Location = new System.Drawing.Point(-8, 46);
            this.label98.Name = "label98";
            this.label98.Size = new System.Drawing.Size(160, 23);
            this.label98.TabIndex = 373;
            this.label98.Text = "Phương pháp PTTT theo lịch :";
            this.label98.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dungcu
            // 
            this.dungcu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dungcu.Enabled = false;
            this.dungcu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dungcu.Location = new System.Drawing.Point(320, 434);
            this.dungcu.Name = "dungcu";
            this.dungcu.Size = new System.Drawing.Size(472, 21);
            this.dungcu.TabIndex = 57;
            this.dungcu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // label97
            // 
            this.label97.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label97.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label97.Location = new System.Drawing.Point(224, 461);
            this.label97.Name = "label97";
            this.label97.Size = new System.Drawing.Size(48, 16);
            this.label97.TabIndex = 372;
            this.label97.Text = "Khác :";
            this.label97.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label96
            // 
            this.label96.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label96.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label96.Location = new System.Drawing.Point(224, 438);
            this.label96.Name = "label96";
            this.label96.Size = new System.Drawing.Size(104, 16);
            this.label96.TabIndex = 371;
            this.label96.Text = "Dụng cụ đặc biệt :";
            this.label96.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // khac
            // 
            this.khac.BackColor = System.Drawing.SystemColors.HighlightText;
            this.khac.Enabled = false;
            this.khac.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.khac.Location = new System.Drawing.Point(320, 457);
            this.khac.Name = "khac";
            this.khac.Size = new System.Drawing.Size(472, 21);
            this.khac.TabIndex = 58;
            this.khac.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // tenphuongphap
            // 
            this.tenphuongphap.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenphuongphap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tenphuongphap.Enabled = false;
            this.tenphuongphap.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenphuongphap.Location = new System.Drawing.Point(177, 163);
            this.tenphuongphap.Name = "tenphuongphap";
            this.tenphuongphap.Size = new System.Drawing.Size(231, 21);
            this.tenphuongphap.TabIndex = 22;
            this.tenphuongphap.SelectedIndexChanged += new System.EventHandler(this.tenphuongphap_SelectedIndexChanged);
            this.tenphuongphap.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenphuongphap_KeyDown);
            // 
            // listBS
            // 
            this.listBS.BackColor = System.Drawing.SystemColors.Info;
            this.listBS.ColumnCount = 0;
            this.listBS.Location = new System.Drawing.Point(280, 656);
            this.listBS.MatchBufferTimeOut = 1000;
            this.listBS.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listBS.Name = "listBS";
            this.listBS.Size = new System.Drawing.Size(75, 17);
            this.listBS.TabIndex = 367;
            this.listBS.TextIndex = -1;
            this.listBS.TextMember = null;
            this.listBS.ValueIndex = -1;
            this.listBS.Visible = false;
            // 
            // listpttt
            // 
            this.listpttt.BackColor = System.Drawing.SystemColors.Info;
            this.listpttt.ColumnCount = 0;
            this.listpttt.Location = new System.Drawing.Point(360, 656);
            this.listpttt.MatchBufferTimeOut = 1000;
            this.listpttt.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listpttt.Name = "listpttt";
            this.listpttt.Size = new System.Drawing.Size(75, 17);
            this.listpttt.TabIndex = 369;
            this.listpttt.TextIndex = -1;
            this.listpttt.TextMember = null;
            this.listpttt.ValueIndex = -1;
            this.listpttt.Visible = false;
            this.listpttt.Validated += new System.EventHandler(this.listpttt_Validated);
            // 
            // chandoan
            // 
            this.chandoan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.chandoan.Enabled = false;
            this.chandoan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chandoan.Location = new System.Drawing.Point(432, 23);
            this.chandoan.Name = "chandoan";
            this.chandoan.Size = new System.Drawing.Size(360, 21);
            this.chandoan.TabIndex = 8;
            // 
            // tenbstruongk
            // 
            this.tenbstruongk.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbstruongk.Enabled = false;
            this.tenbstruongk.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbstruongk.Location = new System.Drawing.Point(264, 577);
            this.tenbstruongk.Name = "tenbstruongk";
            this.tenbstruongk.Size = new System.Drawing.Size(200, 21);
            this.tenbstruongk.TabIndex = 68;
            this.tenbstruongk.TextChanged += new System.EventHandler(this.tenbstruongk_TextChanged);
            this.tenbstruongk.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenptdutru_KeyDown);
            // 
            // bstruongk
            // 
            this.bstruongk.BackColor = System.Drawing.SystemColors.HighlightText;
            this.bstruongk.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.bstruongk.Enabled = false;
            this.bstruongk.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bstruongk.Location = new System.Drawing.Point(224, 577);
            this.bstruongk.MaxLength = 4;
            this.bstruongk.Name = "bstruongk";
            this.bstruongk.Size = new System.Drawing.Size(38, 21);
            this.bstruongk.TabIndex = 67;
            this.bstruongk.Validated += new System.EventHandler(this.bstruongk_Validated);
            this.bstruongk.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // tenkhth
            // 
            this.tenkhth.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenkhth.Enabled = false;
            this.tenkhth.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenkhth.Location = new System.Drawing.Point(264, 554);
            this.tenkhth.Name = "tenkhth";
            this.tenkhth.Size = new System.Drawing.Size(200, 21);
            this.tenkhth.TabIndex = 64;
            this.tenkhth.TextChanged += new System.EventHandler(this.tenkhth_TextChanged);
            this.tenkhth.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenptdutru_KeyDown);
            // 
            // khth
            // 
            this.khth.BackColor = System.Drawing.SystemColors.HighlightText;
            this.khth.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.khth.Enabled = false;
            this.khth.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.khth.Location = new System.Drawing.Point(224, 554);
            this.khth.MaxLength = 4;
            this.khth.Name = "khth";
            this.khth.Size = new System.Drawing.Size(38, 21);
            this.khth.TabIndex = 63;
            this.khth.Validated += new System.EventHandler(this.khth_Validated);
            this.khth.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // tenptv
            // 
            this.tenptv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenptv.Enabled = false;
            this.tenptv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenptv.Location = new System.Drawing.Point(592, 577);
            this.tenptv.Name = "tenptv";
            this.tenptv.Size = new System.Drawing.Size(200, 21);
            this.tenptv.TabIndex = 70;
            this.tenptv.TextChanged += new System.EventHandler(this.tenptv_TextChanged);
            this.tenptv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenptdutru_KeyDown);
            // 
            // ptv
            // 
            this.ptv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ptv.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ptv.Enabled = false;
            this.ptv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ptv.Location = new System.Drawing.Point(552, 577);
            this.ptv.MaxLength = 4;
            this.ptv.Name = "ptv";
            this.ptv.Size = new System.Drawing.Size(38, 21);
            this.ptv.TabIndex = 69;
            this.ptv.Validated += new System.EventHandler(this.ptv_Validated);
            this.ptv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // tengayme
            // 
            this.tengayme.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tengayme.Enabled = false;
            this.tengayme.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tengayme.Location = new System.Drawing.Point(592, 554);
            this.tengayme.Name = "tengayme";
            this.tengayme.Size = new System.Drawing.Size(200, 21);
            this.tengayme.TabIndex = 66;
            this.tengayme.TextChanged += new System.EventHandler(this.tengayme_TextChanged);
            this.tengayme.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenptdutru_KeyDown);
            // 
            // gayme
            // 
            this.gayme.BackColor = System.Drawing.SystemColors.HighlightText;
            this.gayme.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.gayme.Enabled = false;
            this.gayme.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gayme.Location = new System.Drawing.Point(552, 554);
            this.gayme.MaxLength = 4;
            this.gayme.Name = "gayme";
            this.gayme.Size = new System.Drawing.Size(38, 21);
            this.gayme.TabIndex = 65;
            this.gayme.Validated += new System.EventHandler(this.gayme_Validated);
            this.gayme.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // tengiamdoc
            // 
            this.tengiamdoc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tengiamdoc.Enabled = false;
            this.tengiamdoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tengiamdoc.Location = new System.Drawing.Point(592, 531);
            this.tengiamdoc.Name = "tengiamdoc";
            this.tengiamdoc.Size = new System.Drawing.Size(200, 21);
            this.tengiamdoc.TabIndex = 62;
            this.tengiamdoc.TextChanged += new System.EventHandler(this.tengiamdoc_TextChanged);
            this.tengiamdoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenptdutru_KeyDown);
            // 
            // giamdoc
            // 
            this.giamdoc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.giamdoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.giamdoc.Enabled = false;
            this.giamdoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.giamdoc.Location = new System.Drawing.Point(552, 531);
            this.giamdoc.MaxLength = 4;
            this.giamdoc.Name = "giamdoc";
            this.giamdoc.Size = new System.Drawing.Size(38, 21);
            this.giamdoc.TabIndex = 61;
            this.giamdoc.Validated += new System.EventHandler(this.giamdoc_Validated);
            this.giamdoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // label33
            // 
            this.label33.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label33.Location = new System.Drawing.Point(440, 580);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(112, 16);
            this.label33.TabIndex = 355;
            this.label33.Text = "Phẫu thuật viên :";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label32
            // 
            this.label32.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label32.Location = new System.Drawing.Point(136, 580);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(80, 16);
            this.label32.TabIndex = 354;
            this.label32.Text = "Trưởng khoa :";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label31
            // 
            this.label31.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label31.Location = new System.Drawing.Point(432, 559);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(120, 16);
            this.label31.TabIndex = 353;
            this.label31.Text = "Gây mê :";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label28
            // 
            this.label28.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label28.Location = new System.Drawing.Point(128, 559);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(88, 16);
            this.label28.TabIndex = 352;
            this.label28.Text = "Phòng KHTH :";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label27
            // 
            this.label27.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label27.Location = new System.Drawing.Point(420, 532);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(132, 16);
            this.label27.TabIndex = 351;
            this.label27.Text = "Giám đốc :";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ngay
            // 
            this.ngay.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngay.Enabled = false;
            this.ngay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngay.Location = new System.Drawing.Point(224, 531);
            this.ngay.Mask = "##/##/####";
            this.ngay.Name = "ngay";
            this.ngay.Size = new System.Drawing.Size(72, 21);
            this.ngay.TabIndex = 60;
            this.ngay.Text = "  /  /    ";
            this.ngay.Validated += new System.EventHandler(this.ngay_Validated);
            // 
            // label26
            // 
            this.label26.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label26.Location = new System.Drawing.Point(176, 532);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(40, 16);
            this.label26.TabIndex = 349;
            this.label26.Text = "Ngày :";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ykien
            // 
            this.ykien.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ykien.Enabled = false;
            this.ykien.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ykien.Location = new System.Drawing.Point(224, 480);
            this.ykien.Multiline = true;
            this.ykien.Name = "ykien";
            this.ykien.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ykien.Size = new System.Drawing.Size(568, 48);
            this.ykien.TabIndex = 59;
            // 
            // xnkhac
            // 
            this.xnkhac.BackColor = System.Drawing.SystemColors.HighlightText;
            this.xnkhac.Enabled = false;
            this.xnkhac.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xnkhac.Location = new System.Drawing.Point(243, 365);
            this.xnkhac.Multiline = true;
            this.xnkhac.Name = "xnkhac";
            this.xnkhac.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.xnkhac.Size = new System.Drawing.Size(549, 48);
            this.xnkhac.TabIndex = 55;
            // 
            // xq
            // 
            this.xq.BackColor = System.Drawing.SystemColors.Control;
            this.xq.Enabled = false;
            this.xq.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xq.ForeColor = System.Drawing.SystemColors.ControlText;
            this.xq.Location = new System.Drawing.Point(224, 416);
            this.xq.Name = "xq";
            this.xq.Size = new System.Drawing.Size(160, 16);
            this.xq.TabIndex = 56;
            this.xq.Text = "Có Xquang tại phòng mổ";
            this.xq.UseVisualStyleBackColor = false;
            this.xq.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // label25
            // 
            this.label25.Font = new System.Drawing.Font("Tahoma", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label25.Location = new System.Drawing.Point(8, 480);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(216, 16);
            this.label25.TabIndex = 343;
            this.label25.Text = "Đề nghị của hội đồng duyệt mổ :";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label24
            // 
            this.label24.Font = new System.Drawing.Font("Tahoma", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label24.Location = new System.Drawing.Point(8, 416);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(200, 16);
            this.label24.TabIndex = 342;
            this.label24.Text = "Đề nghị của Phẫu thuật viên :";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label23
            // 
            this.label23.Font = new System.Drawing.Font("Tahoma", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label23.Location = new System.Drawing.Point(8, 365);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(144, 16);
            this.label23.TabIndex = 341;
            this.label23.Text = "Các xét nghiệm khác :";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nhommau
            // 
            this.nhommau.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nhommau.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nhommau.Enabled = false;
            this.nhommau.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhommau.Location = new System.Drawing.Point(152, 206);
            this.nhommau.Name = "nhommau";
            this.nhommau.Size = new System.Drawing.Size(88, 21);
            this.nhommau.TabIndex = 24;
            this.nhommau.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nhommau_KeyDown);
            // 
            // mau
            // 
            this.mau.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mau.Enabled = false;
            this.mau.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mau.Location = new System.Drawing.Point(528, 206);
            this.mau.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.mau.MaxLength = 5;
            this.mau.Name = "mau";
            this.mau.Size = new System.Drawing.Size(40, 21);
            this.mau.TabIndex = 26;
            this.mau.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // rb25
            // 
            this.rb25.BackColor = System.Drawing.SystemColors.HighlightText;
            this.rb25.Enabled = false;
            this.rb25.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb25.Location = new System.Drawing.Point(701, 271);
            this.rb25.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.rb25.MaxLength = 5;
            this.rb25.Name = "rb25";
            this.rb25.Size = new System.Drawing.Size(40, 21);
            this.rb25.TabIndex = 52;
            this.rb25.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // rb24
            // 
            this.rb24.BackColor = System.Drawing.SystemColors.HighlightText;
            this.rb24.Enabled = false;
            this.rb24.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb24.Location = new System.Drawing.Point(701, 248);
            this.rb24.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.rb24.MaxLength = 5;
            this.rb24.Name = "rb24";
            this.rb24.Size = new System.Drawing.Size(40, 21);
            this.rb24.TabIndex = 51;
            this.rb24.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label22
            // 
            this.label22.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label22.Location = new System.Drawing.Point(741, 274);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(40, 16);
            this.label22.TabIndex = 336;
            this.label22.Text = "mmHg";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label21
            // 
            this.label21.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label21.Location = new System.Drawing.Point(741, 251);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(24, 16);
            this.label21.TabIndex = 335;
            this.label21.Text = "%";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label20
            // 
            this.label20.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label20.Location = new System.Drawing.Point(644, 274);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(48, 16);
            this.label20.TabIndex = 334;
            this.label20.Text = "PAPm";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label19.Location = new System.Drawing.Point(644, 251);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(48, 16);
            this.label19.TabIndex = 333;
            this.label19.Text = "EF";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rb27
            // 
            this.rb27.BackColor = System.Drawing.SystemColors.Control;
            this.rb27.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rb27.Enabled = false;
            this.rb27.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb27.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rb27.Location = new System.Drawing.Point(595, 318);
            this.rb27.Name = "rb27";
            this.rb27.Size = new System.Drawing.Size(120, 16);
            this.rb27.TabIndex = 54;
            this.rb27.Text = "XQ phổi";
            this.rb27.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rb27.UseVisualStyleBackColor = false;
            this.rb27.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // rb26
            // 
            this.rb26.BackColor = System.Drawing.SystemColors.Control;
            this.rb26.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rb26.Enabled = false;
            this.rb26.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb26.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rb26.Location = new System.Drawing.Point(595, 297);
            this.rb26.Name = "rb26";
            this.rb26.Size = new System.Drawing.Size(120, 16);
            this.rb26.TabIndex = 53;
            this.rb26.Text = "Chức năng hô hấp";
            this.rb26.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rb26.UseVisualStyleBackColor = false;
            this.rb26.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // rb23
            // 
            this.rb23.BackColor = System.Drawing.SystemColors.Control;
            this.rb23.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rb23.Enabled = false;
            this.rb23.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb23.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rb23.Location = new System.Drawing.Point(488, 318);
            this.rb23.Name = "rb23";
            this.rb23.Size = new System.Drawing.Size(96, 16);
            this.rb23.TabIndex = 50;
            this.rb23.Text = "Siêu âm tim";
            this.rb23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rb23.UseVisualStyleBackColor = false;
            this.rb23.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // rb22
            // 
            this.rb22.BackColor = System.Drawing.SystemColors.Control;
            this.rb22.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rb22.Enabled = false;
            this.rb22.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb22.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rb22.Location = new System.Drawing.Point(488, 297);
            this.rb22.Name = "rb22";
            this.rb22.Size = new System.Drawing.Size(96, 16);
            this.rb22.TabIndex = 49;
            this.rb22.Text = "TMCT/NMCT";
            this.rb22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rb22.UseVisualStyleBackColor = false;
            this.rb22.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // rb21
            // 
            this.rb21.BackColor = System.Drawing.SystemColors.Control;
            this.rb21.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rb21.Enabled = false;
            this.rb21.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb21.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rb21.Location = new System.Drawing.Point(488, 275);
            this.rb21.Name = "rb21";
            this.rb21.Size = new System.Drawing.Size(96, 16);
            this.rb21.TabIndex = 48;
            this.rb21.Text = "Loạn nhịp";
            this.rb21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rb21.UseVisualStyleBackColor = false;
            this.rb21.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // rb20
            // 
            this.rb20.BackColor = System.Drawing.SystemColors.Control;
            this.rb20.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rb20.Enabled = false;
            this.rb20.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb20.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rb20.Location = new System.Drawing.Point(488, 253);
            this.rb20.Name = "rb20";
            this.rb20.Size = new System.Drawing.Size(96, 16);
            this.rb20.TabIndex = 47;
            this.rb20.Text = "ECG";
            this.rb20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rb20.UseVisualStyleBackColor = false;
            this.rb20.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // rb19
            // 
            this.rb19.BackColor = System.Drawing.SystemColors.Control;
            this.rb19.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rb19.Enabled = false;
            this.rb19.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb19.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rb19.Location = new System.Drawing.Point(377, 338);
            this.rb19.Name = "rb19";
            this.rb19.Size = new System.Drawing.Size(104, 16);
            this.rb19.TabIndex = 46;
            this.rb19.Text = "TPT nước tiểu";
            this.rb19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rb19.UseVisualStyleBackColor = false;
            this.rb19.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // rb18
            // 
            this.rb18.BackColor = System.Drawing.SystemColors.Control;
            this.rb18.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rb18.Enabled = false;
            this.rb18.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb18.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rb18.Location = new System.Drawing.Point(377, 318);
            this.rb18.Name = "rb18";
            this.rb18.Size = new System.Drawing.Size(104, 16);
            this.rb18.TabIndex = 45;
            this.rb18.Text = "Albumin";
            this.rb18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rb18.UseVisualStyleBackColor = false;
            this.rb18.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // rb17
            // 
            this.rb17.BackColor = System.Drawing.SystemColors.Control;
            this.rb17.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rb17.Enabled = false;
            this.rb17.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb17.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rb17.Location = new System.Drawing.Point(377, 297);
            this.rb17.Name = "rb17";
            this.rb17.Size = new System.Drawing.Size(104, 16);
            this.rb17.TabIndex = 44;
            this.rb17.Text = "Bilirubin";
            this.rb17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rb17.UseVisualStyleBackColor = false;
            this.rb17.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // rb16
            // 
            this.rb16.BackColor = System.Drawing.SystemColors.Control;
            this.rb16.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rb16.Enabled = false;
            this.rb16.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb16.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rb16.Location = new System.Drawing.Point(377, 276);
            this.rb16.Name = "rb16";
            this.rb16.Size = new System.Drawing.Size(104, 16);
            this.rb16.TabIndex = 43;
            this.rb16.Text = "SGPT";
            this.rb16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rb16.UseVisualStyleBackColor = false;
            this.rb16.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // rb15
            // 
            this.rb15.BackColor = System.Drawing.SystemColors.Control;
            this.rb15.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rb15.Enabled = false;
            this.rb15.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb15.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rb15.Location = new System.Drawing.Point(377, 253);
            this.rb15.Name = "rb15";
            this.rb15.Size = new System.Drawing.Size(104, 16);
            this.rb15.TabIndex = 42;
            this.rb15.Text = "SGOT";
            this.rb15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rb15.UseVisualStyleBackColor = false;
            this.rb15.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // rb14
            // 
            this.rb14.BackColor = System.Drawing.SystemColors.Control;
            this.rb14.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rb14.Enabled = false;
            this.rb14.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb14.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rb14.Location = new System.Drawing.Point(274, 338);
            this.rb14.Name = "rb14";
            this.rb14.Size = new System.Drawing.Size(94, 16);
            this.rb14.TabIndex = 41;
            this.rb14.Text = "Ceton";
            this.rb14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rb14.UseVisualStyleBackColor = false;
            this.rb14.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // rb13
            // 
            this.rb13.BackColor = System.Drawing.SystemColors.Control;
            this.rb13.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rb13.Enabled = false;
            this.rb13.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb13.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rb13.Location = new System.Drawing.Point(274, 318);
            this.rb13.Name = "rb13";
            this.rb13.Size = new System.Drawing.Size(94, 16);
            this.rb13.TabIndex = 40;
            this.rb13.Text = "Đường huyết";
            this.rb13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rb13.UseVisualStyleBackColor = false;
            this.rb13.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // rb12
            // 
            this.rb12.BackColor = System.Drawing.SystemColors.Control;
            this.rb12.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rb12.Enabled = false;
            this.rb12.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rb12.Location = new System.Drawing.Point(274, 297);
            this.rb12.Name = "rb12";
            this.rb12.Size = new System.Drawing.Size(94, 16);
            this.rb12.TabIndex = 39;
            this.rb12.Text = "Ion đồ";
            this.rb12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rb12.UseVisualStyleBackColor = false;
            this.rb12.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // rb11
            // 
            this.rb11.BackColor = System.Drawing.SystemColors.Control;
            this.rb11.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rb11.Enabled = false;
            this.rb11.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rb11.Location = new System.Drawing.Point(274, 276);
            this.rb11.Name = "rb11";
            this.rb11.Size = new System.Drawing.Size(94, 16);
            this.rb11.TabIndex = 38;
            this.rb11.Text = "Creatinin";
            this.rb11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rb11.UseVisualStyleBackColor = false;
            this.rb11.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // rb10
            // 
            this.rb10.BackColor = System.Drawing.SystemColors.Control;
            this.rb10.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rb10.Enabled = false;
            this.rb10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rb10.Location = new System.Drawing.Point(274, 253);
            this.rb10.Name = "rb10";
            this.rb10.Size = new System.Drawing.Size(94, 16);
            this.rb10.TabIndex = 37;
            this.rb10.Text = "Urê";
            this.rb10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rb10.UseVisualStyleBackColor = false;
            this.rb10.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // rb9
            // 
            this.rb9.BackColor = System.Drawing.SystemColors.Control;
            this.rb9.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rb9.Enabled = false;
            this.rb9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rb9.Location = new System.Drawing.Point(152, 338);
            this.rb9.Name = "rb9";
            this.rb9.Size = new System.Drawing.Size(112, 16);
            this.rb9.TabIndex = 36;
            this.rb9.Text = "HIV";
            this.rb9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rb9.UseVisualStyleBackColor = false;
            this.rb9.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // rb8
            // 
            this.rb8.BackColor = System.Drawing.SystemColors.Control;
            this.rb8.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rb8.Enabled = false;
            this.rb8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rb8.Location = new System.Drawing.Point(152, 318);
            this.rb8.Name = "rb8";
            this.rb8.Size = new System.Drawing.Size(112, 16);
            this.rb8.TabIndex = 35;
            this.rb8.Text = "Taux de Prothrombin";
            this.rb8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rb8.UseVisualStyleBackColor = false;
            this.rb8.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // rb7
            // 
            this.rb7.BackColor = System.Drawing.SystemColors.Control;
            this.rb7.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rb7.Enabled = false;
            this.rb7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rb7.Location = new System.Drawing.Point(152, 297);
            this.rb7.Name = "rb7";
            this.rb7.Size = new System.Drawing.Size(112, 16);
            this.rb7.TabIndex = 34;
            this.rb7.Text = "Tiểu cầu";
            this.rb7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rb7.UseVisualStyleBackColor = false;
            this.rb7.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // rb6
            // 
            this.rb6.BackColor = System.Drawing.SystemColors.Control;
            this.rb6.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rb6.Enabled = false;
            this.rb6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rb6.Location = new System.Drawing.Point(152, 276);
            this.rb6.Name = "rb6";
            this.rb6.Size = new System.Drawing.Size(112, 16);
            this.rb6.TabIndex = 33;
            this.rb6.Text = "TCK";
            this.rb6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rb6.UseVisualStyleBackColor = false;
            this.rb6.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // rb5
            // 
            this.rb5.BackColor = System.Drawing.SystemColors.Control;
            this.rb5.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rb5.Enabled = false;
            this.rb5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rb5.Location = new System.Drawing.Point(152, 253);
            this.rb5.Name = "rb5";
            this.rb5.Size = new System.Drawing.Size(112, 16);
            this.rb5.TabIndex = 32;
            this.rb5.Text = "TQ";
            this.rb5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rb5.UseVisualStyleBackColor = false;
            this.rb5.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // rb4
            // 
            this.rb4.BackColor = System.Drawing.SystemColors.Control;
            this.rb4.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rb4.Enabled = false;
            this.rb4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rb4.Location = new System.Drawing.Point(48, 338);
            this.rb4.Name = "rb4";
            this.rb4.Size = new System.Drawing.Size(96, 16);
            this.rb4.TabIndex = 31;
            this.rb4.Text = "TS";
            this.rb4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rb4.UseVisualStyleBackColor = false;
            this.rb4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // rb3
            // 
            this.rb3.BackColor = System.Drawing.SystemColors.Control;
            this.rb3.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rb3.Enabled = false;
            this.rb3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rb3.Location = new System.Drawing.Point(48, 318);
            this.rb3.Name = "rb3";
            this.rb3.Size = new System.Drawing.Size(96, 16);
            this.rb3.TabIndex = 30;
            this.rb3.Text = "Bạch cầu";
            this.rb3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rb3.UseVisualStyleBackColor = false;
            this.rb3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // rb2
            // 
            this.rb2.BackColor = System.Drawing.SystemColors.Control;
            this.rb2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rb2.Enabled = false;
            this.rb2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rb2.Location = new System.Drawing.Point(48, 297);
            this.rb2.Name = "rb2";
            this.rb2.Size = new System.Drawing.Size(96, 16);
            this.rb2.TabIndex = 29;
            this.rb2.Text = "Hb";
            this.rb2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rb2.UseVisualStyleBackColor = false;
            this.rb2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // rb1
            // 
            this.rb1.BackColor = System.Drawing.SystemColors.Control;
            this.rb1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rb1.Enabled = false;
            this.rb1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rb1.Location = new System.Drawing.Point(48, 276);
            this.rb1.Name = "rb1";
            this.rb1.Size = new System.Drawing.Size(96, 16);
            this.rb1.TabIndex = 28;
            this.rb1.Text = "Hồng cầu/Hct";
            this.rb1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rb1.UseVisualStyleBackColor = false;
            this.rb1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label16.Location = new System.Drawing.Point(168, 232);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(192, 16);
            this.label16.TabIndex = 307;
            this.label16.Text = "( Gạch chéo vào ô : Bất thường □ )";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rb0
            // 
            this.rb0.BackColor = System.Drawing.SystemColors.Control;
            this.rb0.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rb0.Enabled = false;
            this.rb0.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb0.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rb0.Location = new System.Drawing.Point(48, 253);
            this.rb0.Name = "rb0";
            this.rb0.Size = new System.Drawing.Size(96, 16);
            this.rb0.TabIndex = 27;
            this.rb0.Text = "CTM";
            this.rb0.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rb0.UseVisualStyleBackColor = false;
            this.rb0.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Tahoma", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label13.Location = new System.Drawing.Point(8, 232);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(144, 16);
            this.label13.TabIndex = 305;
            this.label13.Text = "Xét nghiệm tiền phẩu";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label12.Location = new System.Drawing.Point(568, 208);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(48, 16);
            this.label12.TabIndex = 304;
            this.label12.Text = "Đơn vị";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label11.Location = new System.Drawing.Point(446, 208);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(80, 16);
            this.label11.TabIndex = 303;
            this.label11.Text = "Dự trù máu :";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rh
            // 
            this.rh.BackColor = System.Drawing.SystemColors.Control;
            this.rh.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rh.Enabled = false;
            this.rh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rh.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rh.Location = new System.Drawing.Point(256, 208);
            this.rh.Name = "rh";
            this.rh.Size = new System.Drawing.Size(72, 16);
            this.rh.TabIndex = 25;
            this.rh.Text = "Rh (        )";
            this.rh.UseVisualStyleBackColor = false;
            this.rh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(72, 208);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 16);
            this.label8.TabIndex = 301;
            this.label8.Text = "Nhóm máu :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label72
            // 
            this.label72.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label72.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label72.Location = new System.Drawing.Point(320, 191);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(168, 17);
            this.label72.TabIndex = 300;
            this.label72.Text = "TÌNH TRẠNG BỆNH NHÂN";
            this.label72.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // thoigian
            // 
            this.thoigian.BackColor = System.Drawing.SystemColors.HighlightText;
            this.thoigian.Enabled = false;
            this.thoigian.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thoigian.Location = new System.Drawing.Point(526, 139);
            this.thoigian.Name = "thoigian";
            this.thoigian.Size = new System.Drawing.Size(266, 21);
            this.thoigian.TabIndex = 20;
            this.thoigian.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // tuthe
            // 
            this.tuthe.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tuthe.Enabled = false;
            this.tuthe.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tuthe.Location = new System.Drawing.Point(152, 139);
            this.tuthe.Name = "tuthe";
            this.tuthe.Size = new System.Drawing.Size(256, 21);
            this.tuthe.TabIndex = 19;
            this.tuthe.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // sonde
            // 
            this.sonde.BackColor = System.Drawing.SystemColors.Control;
            this.sonde.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.sonde.Enabled = false;
            this.sonde.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sonde.ForeColor = System.Drawing.SystemColors.ControlText;
            this.sonde.Location = new System.Drawing.Point(404, 164);
            this.sonde.Name = "sonde";
            this.sonde.Size = new System.Drawing.Size(136, 16);
            this.sonde.TabIndex = 23;
            this.sonde.Text = "Đặt ống nội phế quản";
            this.sonde.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.sonde.UseVisualStyleBackColor = false;
            this.sonde.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(414, 139);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 16);
            this.label6.TabIndex = 296;
            this.label6.Text = "Thời gian dự trù mổ :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(88, 139);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 16);
            this.label5.TabIndex = 295;
            this.label5.Text = "Tư thế mổ :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // giomo
            // 
            this.giomo.BackColor = System.Drawing.SystemColors.HighlightText;
            this.giomo.Enabled = false;
            this.giomo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.giomo.Location = new System.Drawing.Point(632, 115);
            this.giomo.Mask = "##:##";
            this.giomo.Name = "giomo";
            this.giomo.Size = new System.Drawing.Size(40, 21);
            this.giomo.TabIndex = 18;
            this.giomo.Text = "  :  ";
            this.giomo.Validated += new System.EventHandler(this.giomo_Validated);
            // 
            // ngaymo
            // 
            this.ngaymo.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngaymo.Enabled = false;
            this.ngaymo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngaymo.Location = new System.Drawing.Point(526, 115);
            this.ngaymo.Mask = "##/##/####";
            this.ngaymo.Name = "ngaymo";
            this.ngaymo.Size = new System.Drawing.Size(72, 21);
            this.ngaymo.TabIndex = 17;
            this.ngaymo.Text = "  /  /    ";
            this.ngaymo.Validated += new System.EventHandler(this.ngaymo_Validated);
            // 
            // label89
            // 
            this.label89.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label89.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label89.Location = new System.Drawing.Point(600, 117);
            this.label89.Name = "label89";
            this.label89.Size = new System.Drawing.Size(32, 16);
            this.label89.TabIndex = 294;
            this.label89.Text = "Giờ :";
            this.label89.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label70
            // 
            this.label70.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label70.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label70.Location = new System.Drawing.Point(486, 117);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(40, 16);
            this.label70.TabIndex = 293;
            this.label70.Text = "Ngày :";
            this.label70.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tenptphu
            // 
            this.tenptphu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenptphu.Enabled = false;
            this.tenptphu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenptphu.Location = new System.Drawing.Point(192, 115);
            this.tenptphu.Name = "tenptphu";
            this.tenptphu.Size = new System.Drawing.Size(216, 21);
            this.tenptphu.TabIndex = 16;
            this.tenptphu.TextChanged += new System.EventHandler(this.tenptphu_TextChanged);
            this.tenptphu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenptdutru_KeyDown);
            // 
            // tenptdutru
            // 
            this.tenptdutru.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenptdutru.Enabled = false;
            this.tenptdutru.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenptdutru.Location = new System.Drawing.Point(192, 91);
            this.tenptdutru.Name = "tenptdutru";
            this.tenptdutru.Size = new System.Drawing.Size(216, 21);
            this.tenptdutru.TabIndex = 12;
            this.tenptdutru.TextChanged += new System.EventHandler(this.tenptdutru_TextChanged);
            this.tenptdutru.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenptdutru_KeyDown);
            // 
            // ptdutru
            // 
            this.ptdutru.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ptdutru.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ptdutru.Enabled = false;
            this.ptdutru.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ptdutru.Location = new System.Drawing.Point(152, 91);
            this.ptdutru.MaxLength = 4;
            this.ptdutru.Name = "ptdutru";
            this.ptdutru.Size = new System.Drawing.Size(38, 21);
            this.ptdutru.TabIndex = 11;
            this.ptdutru.Validated += new System.EventHandler(this.ptdutru_Validated);
            this.ptdutru.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // ptphu
            // 
            this.ptphu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ptphu.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ptphu.Enabled = false;
            this.ptphu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ptphu.Location = new System.Drawing.Point(152, 115);
            this.ptphu.MaxLength = 4;
            this.ptphu.Name = "ptphu";
            this.ptphu.Size = new System.Drawing.Size(38, 21);
            this.ptphu.TabIndex = 15;
            this.ptphu.Validated += new System.EventHandler(this.ptphu_Validated);
            this.ptphu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // label30
            // 
            this.label30.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label30.Location = new System.Drawing.Point(40, 94);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(112, 16);
            this.label30.TabIndex = 68;
            this.label30.Text = "Phẫu thuật dự trù :";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label29
            // 
            this.label29.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label29.Location = new System.Drawing.Point(32, 118);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(120, 16);
            this.label29.TabIndex = 67;
            this.label29.Text = "Phẫu thuật viên phụ :";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tenptchinh
            // 
            this.tenptchinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenptchinh.Enabled = false;
            this.tenptchinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenptchinh.Location = new System.Drawing.Point(566, 91);
            this.tenptchinh.Name = "tenptchinh";
            this.tenptchinh.Size = new System.Drawing.Size(226, 21);
            this.tenptchinh.TabIndex = 14;
            this.tenptchinh.TextChanged += new System.EventHandler(this.tenptchinh_TextChanged);
            this.tenptchinh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenptdutru_KeyDown);
            // 
            // ptchinh
            // 
            this.ptchinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ptchinh.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ptchinh.Enabled = false;
            this.ptchinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ptchinh.Location = new System.Drawing.Point(526, 91);
            this.ptchinh.MaxLength = 4;
            this.ptchinh.Name = "ptchinh";
            this.ptchinh.Size = new System.Drawing.Size(38, 21);
            this.ptchinh.TabIndex = 13;
            this.ptchinh.Validated += new System.EventHandler(this.ptchinh_Validated);
            this.ptchinh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // phuongphap
            // 
            this.phuongphap.BackColor = System.Drawing.SystemColors.HighlightText;
            this.phuongphap.Enabled = false;
            this.phuongphap.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phuongphap.Location = new System.Drawing.Point(152, 163);
            this.phuongphap.MaxLength = 2;
            this.phuongphap.Name = "phuongphap";
            this.phuongphap.Size = new System.Drawing.Size(24, 21);
            this.phuongphap.TabIndex = 21;
            this.phuongphap.Validated += new System.EventHandler(this.phuongphap_Validated);
            this.phuongphap.KeyDown += new System.Windows.Forms.KeyEventHandler(this.phuongphap_KeyDown);
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label14.Location = new System.Drawing.Point(382, 91);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(144, 23);
            this.label14.TabIndex = 66;
            this.label14.Text = "Phẫu thuật viên chính :";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(-8, 166);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(160, 16);
            this.label9.TabIndex = 65;
            this.label9.Text = "Phương pháp vô cảm đề nghị :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(104, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 19);
            this.label2.TabIndex = 54;
            this.label2.Text = "Mã BN :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mabn
            // 
            this.mabn.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabn.Enabled = false;
            this.mabn.Location = new System.Drawing.Point(152, 2);
            this.mabn.Name = "mabn";
            this.mabn.Size = new System.Drawing.Size(64, 20);
            this.mabn.TabIndex = 0;
            this.mabn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(227, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 19);
            this.label3.TabIndex = 55;
            this.label3.Text = "Họ tên :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // hoten
            // 
            this.hoten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.hoten.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.hoten.Enabled = false;
            this.hoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoten.Location = new System.Drawing.Point(275, 1);
            this.hoten.Name = "hoten";
            this.hoten.Size = new System.Drawing.Size(192, 21);
            this.hoten.TabIndex = 1;
            this.hoten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(461, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 20);
            this.label4.TabIndex = 56;
            this.label4.Text = "Tuổi :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tuoi
            // 
            this.tuoi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tuoi.Enabled = false;
            this.tuoi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tuoi.Location = new System.Drawing.Point(502, 1);
            this.tuoi.Name = "tuoi";
            this.tuoi.Size = new System.Drawing.Size(40, 21);
            this.tuoi.TabIndex = 2;
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label15.Location = new System.Drawing.Point(536, 5);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(56, 19);
            this.label15.TabIndex = 57;
            this.label15.Text = "Giới tính :";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // phai
            // 
            this.phai.BackColor = System.Drawing.SystemColors.HighlightText;
            this.phai.Enabled = false;
            this.phai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phai.Location = new System.Drawing.Point(592, 1);
            this.phai.Name = "phai";
            this.phai.Size = new System.Drawing.Size(38, 21);
            this.phai.TabIndex = 3;
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label17.Location = new System.Drawing.Point(616, 5);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(56, 19);
            this.label17.TabIndex = 58;
            this.label17.Text = "Số thẻ :";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sothe
            // 
            this.sothe.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sothe.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.sothe.Enabled = false;
            this.sothe.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sothe.Location = new System.Drawing.Point(672, 1);
            this.sothe.Name = "sothe";
            this.sothe.Size = new System.Drawing.Size(120, 21);
            this.sothe.TabIndex = 4;
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label18.Location = new System.Drawing.Point(88, 22);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(64, 23);
            this.label18.TabIndex = 59;
            this.label18.Text = "Số giường :";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // giuong
            // 
            this.giuong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.giuong.Enabled = false;
            this.giuong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.giuong.Location = new System.Drawing.Point(152, 23);
            this.giuong.Name = "giuong";
            this.giuong.Size = new System.Drawing.Size(64, 21);
            this.giuong.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(195, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 16);
            this.label7.TabIndex = 60;
            this.label7.Text = "Ngày vào :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ngayvv
            // 
            this.ngayvv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngayvv.Enabled = false;
            this.ngayvv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngayvv.Location = new System.Drawing.Point(275, 23);
            this.ngayvv.Name = "ngayvv";
            this.ngayvv.Size = new System.Drawing.Size(92, 21);
            this.ngayvv.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(360, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 64;
            this.label1.Text = "Chẩn đoán :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label10.Location = new System.Drawing.Point(-9, 66);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(160, 23);
            this.label10.TabIndex = 67;
            this.label10.Text = "Phương pháp phẫu thủ thuật :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tenmau
            // 
            this.tenmau.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenmau.Enabled = false;
            this.tenmau.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenmau.Location = new System.Drawing.Point(152, 68);
            this.tenmau.Name = "tenmau";
            this.tenmau.Size = new System.Drawing.Size(122, 21);
            this.tenmau.TabIndex = 9;
            this.tenmau.TextChanged += new System.EventHandler(this.tenmau_TextChanged);
            this.tenmau.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenmau_KeyDown);
            // 
            // lmau
            // 
            this.lmau.BackColor = System.Drawing.SystemColors.HighlightText;
            this.lmau.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lmau.Enabled = false;
            this.lmau.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lmau.Location = new System.Drawing.Point(275, 68);
            this.lmau.Name = "lmau";
            this.lmau.Size = new System.Drawing.Size(517, 21);
            this.lmau.TabIndex = 10;
            this.lmau.SelectedIndexChanged += new System.EventHandler(this.lmau_SelectedIndexChanged);
            this.lmau.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lmau_KeyDown);
            // 
            // mamau
            // 
            this.mamau.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mamau.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mamau.Enabled = false;
            this.mamau.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mamau.Location = new System.Drawing.Point(264, 383);
            this.mamau.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.mamau.MaxLength = 10;
            this.mamau.Name = "mamau";
            this.mamau.Size = new System.Drawing.Size(16, 21);
            this.mamau.TabIndex = 370;
            this.mamau.Validated += new System.EventHandler(this.mamau_Validated);
            // 
            // label34
            // 
            this.label34.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label34.Location = new System.Drawing.Point(8, 384);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(256, 16);
            this.label34.TabIndex = 366;
            this.label34.Text = "(CTscan; MRI; Nội soi hô hấp; tiêu hoá v.v. . . )";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox8);
            this.tabPage2.Controls.Add(this.groupBox7);
            this.tabPage2.Controls.Add(this.groupBox6);
            this.tabPage2.Controls.Add(this.groupBox5);
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.cs_khac);
            this.tabPage2.Controls.Add(this.label95);
            this.tabPage2.Controls.Add(this.cungcotsong);
            this.tabPage2.Controls.Add(this.gu);
            this.tabPage2.Controls.Add(this.k_tk_khac);
            this.tabPage2.Controls.Add(this.label94);
            this.tabPage2.Controls.Add(this.tk_yeu);
            this.tabPage2.Controls.Add(this.tk_bt);
            this.tabPage2.Controls.Add(this.label93);
            this.tabPage2.Controls.Add(this.cs_bt);
            this.tabPage2.Controls.Add(this.nt_khac);
            this.tabPage2.Controls.Add(this.label92);
            this.tabPage2.Controls.Add(this.nt_td);
            this.tabPage2.Controls.Add(this.nt_bg);
            this.tabPage2.Controls.Add(this.nt_bt);
            this.tabPage2.Controls.Add(this.label91);
            this.tabPage2.Controls.Add(this.k_hh_khac);
            this.tabPage2.Controls.Add(this.label90);
            this.tabPage2.Controls.Add(this.hh_suyen);
            this.tabPage2.Controls.Add(this.hh_copd);
            this.tabPage2.Controls.Add(this.hh_bt);
            this.tabPage2.Controls.Add(this.label88);
            this.tabPage2.Controls.Add(this.tm_khac);
            this.tabPage2.Controls.Add(this.label87);
            this.tabPage2.Controls.Add(this.tm_dtn);
            this.tabPage2.Controls.Add(this.tm_ln);
            this.tabPage2.Controls.Add(this.tm_cha);
            this.tabPage2.Controls.Add(this.tm_bt);
            this.tabPage2.Controls.Add(this.label86);
            this.tabPage2.Controls.Add(this.bmi);
            this.tabPage2.Controls.Add(this.label85);
            this.tabPage2.Controls.Add(this.tinhmach);
            this.tabPage2.Controls.Add(this.label84);
            this.tabPage2.Controls.Add(this.listBS1);
            this.tabPage2.Controls.Add(this.tenbs_pass);
            this.tabPage2.Controls.Add(this.tenbs);
            this.tabPage2.Controls.Add(this.mabs);
            this.tabPage2.Controls.Add(this.label82);
            this.tabPage2.Controls.Add(this.ngaykham);
            this.tabPage2.Controls.Add(this.label83);
            this.tabPage2.Controls.Add(this.ketluan);
            this.tabPage2.Controls.Add(this.thuthuat);
            this.tabPage2.Controls.Add(this.dukien);
            this.tabPage2.Controls.Add(this.mallampati);
            this.tabPage2.Controls.Add(this.glodmann);
            this.tabPage2.Controls.Add(this.asa);
            this.tabPage2.Controls.Add(this.label81);
            this.tabPage2.Controls.Add(this.label80);
            this.tabPage2.Controls.Add(this.label79);
            this.tabPage2.Controls.Add(this.label78);
            this.tabPage2.Controls.Add(this.label77);
            this.tabPage2.Controls.Add(this.label76);
            this.tabPage2.Controls.Add(this.denghi);
            this.tabPage2.Controls.Add(this.dieutri);
            this.tabPage2.Controls.Add(this.canlamsang);
            this.tabPage2.Controls.Add(this.label75);
            this.tabPage2.Controls.Add(this.label74);
            this.tabPage2.Controls.Add(this.label73);
            this.tabPage2.Controls.Add(this.label71);
            this.tabPage2.Controls.Add(this.label69);
            this.tabPage2.Controls.Add(this.label68);
            this.tabPage2.Controls.Add(this.label67);
            this.tabPage2.Controls.Add(this.tl_khac);
            this.tabPage2.Controls.Add(this.label66);
            this.tabPage2.Controls.Add(this.ranggia);
            this.tabPage2.Controls.Add(this.seo);
            this.tabPage2.Controls.Add(this.cungham);
            this.tabPage2.Controls.Add(this.giap);
            this.tabPage2.Controls.Add(this.khoiu);
            this.tabPage2.Controls.Add(this.luoito);
            this.tabPage2.Controls.Add(this.congan);
            this.tabPage2.Controls.Add(this.hanche);
            this.tabPage2.Controls.Add(this.label65);
            this.tabPage2.Controls.Add(this.label64);
            this.tabPage2.Controls.Add(this.chieucao);
            this.tabPage2.Controls.Add(this.label63);
            this.tabPage2.Controls.Add(this.nhietdo);
            this.tabPage2.Controls.Add(this.huyetap);
            this.tabPage2.Controls.Add(this.nhiptho);
            this.tabPage2.Controls.Add(this.cannang);
            this.tabPage2.Controls.Add(this.mach);
            this.tabPage2.Controls.Add(this.label53);
            this.tabPage2.Controls.Add(this.label54);
            this.tabPage2.Controls.Add(this.label55);
            this.tabPage2.Controls.Add(this.label56);
            this.tabPage2.Controls.Add(this.label57);
            this.tabPage2.Controls.Add(this.label58);
            this.tabPage2.Controls.Add(this.label59);
            this.tabPage2.Controls.Add(this.label60);
            this.tabPage2.Controls.Add(this.label61);
            this.tabPage2.Controls.Add(this.label62);
            this.tabPage2.Controls.Add(this.glasgow);
            this.tabPage2.Controls.Add(this.label52);
            this.tabPage2.Controls.Add(this.label51);
            this.tabPage2.Controls.Add(this.khotho);
            this.tabPage2.Controls.Add(this.yeu);
            this.tabPage2.Controls.Add(this.nhot);
            this.tabPage2.Controls.Add(this.hong);
            this.tabPage2.Controls.Add(this.label50);
            this.tabPage2.Controls.Add(this.phu);
            this.tabPage2.Controls.Add(this.map);
            this.tabPage2.Controls.Add(this.label49);
            this.tabPage2.Controls.Add(this.label48);
            this.tabPage2.Controls.Add(this.label47);
            this.tabPage2.Controls.Add(this.chitiet);
            this.tabPage2.Controls.Add(this.label46);
            this.tabPage2.Controls.Add(this.giadinh);
            this.tabPage2.Controls.Add(this.label45);
            this.tabPage2.Controls.Add(this.label36);
            this.tabPage2.Controls.Add(this.label35);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(800, 686);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Khám tiền mê";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.diung);
            this.groupBox8.Controls.Add(this.chkdiung);
            this.groupBox8.Controls.Add(this.label38);
            this.groupBox8.Controls.Add(this.bieuhien);
            this.groupBox8.Location = new System.Drawing.Point(91, 65);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(275, 65);
            this.groupBox8.TabIndex = 435;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Dị ứng";
            // 
            // diung
            // 
            this.diung.BackColor = System.Drawing.SystemColors.HighlightText;
            this.diung.Enabled = false;
            this.diung.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diung.Location = new System.Drawing.Point(58, 14);
            this.diung.Name = "diung";
            this.diung.Size = new System.Drawing.Size(213, 21);
            this.diung.TabIndex = 6;
            this.diung.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // chkdiung
            // 
            this.chkdiung.Enabled = false;
            this.chkdiung.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkdiung.Location = new System.Drawing.Point(57, -3);
            this.chkdiung.Name = "chkdiung";
            this.chkdiung.Size = new System.Drawing.Size(24, 21);
            this.chkdiung.TabIndex = 5;
            this.chkdiung.Text = "- Dị ứng ";
            this.chkdiung.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkdiung.CheckedChanged += new System.EventHandler(this.chkdiung_CheckedChanged);
            this.chkdiung.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // label38
            // 
            this.label38.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label38.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label38.Location = new System.Drawing.Point(6, 40);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(52, 20);
            this.label38.TabIndex = 71;
            this.label38.Text = "Biểu hiện :";
            this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bieuhien
            // 
            this.bieuhien.BackColor = System.Drawing.SystemColors.HighlightText;
            this.bieuhien.Enabled = false;
            this.bieuhien.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bieuhien.Location = new System.Drawing.Point(58, 37);
            this.bieuhien.Name = "bieuhien";
            this.bieuhien.Size = new System.Drawing.Size(213, 21);
            this.bieuhien.TabIndex = 7;
            this.bieuhien.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.mo);
            this.groupBox7.Controls.Add(this.me);
            this.groupBox7.Controls.Add(this.te);
            this.groupBox7.Controls.Add(this.taibien);
            this.groupBox7.Controls.Add(this.truyenmau);
            this.groupBox7.Location = new System.Drawing.Point(91, 1);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(275, 63);
            this.groupBox7.TabIndex = 434;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Mỗ lần trước";
            // 
            // mo
            // 
            this.mo.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mo.Enabled = false;
            this.mo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mo.Location = new System.Drawing.Point(11, 16);
            this.mo.Name = "mo";
            this.mo.Size = new System.Drawing.Size(260, 21);
            this.mo.TabIndex = 0;
            this.mo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // me
            // 
            this.me.Enabled = false;
            this.me.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.me.Location = new System.Drawing.Point(12, 36);
            this.me.Name = "me";
            this.me.Size = new System.Drawing.Size(40, 16);
            this.me.TabIndex = 1;
            this.me.Text = "Mê";
            this.me.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // te
            // 
            this.te.Enabled = false;
            this.te.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.te.Location = new System.Drawing.Point(60, 36);
            this.te.Name = "te";
            this.te.Size = new System.Drawing.Size(40, 16);
            this.te.TabIndex = 2;
            this.te.Text = "Tê";
            this.te.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // taibien
            // 
            this.taibien.Enabled = false;
            this.taibien.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.taibien.Location = new System.Drawing.Point(108, 36);
            this.taibien.Name = "taibien";
            this.taibien.Size = new System.Drawing.Size(68, 16);
            this.taibien.TabIndex = 3;
            this.taibien.Text = "Tai biến";
            this.taibien.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // truyenmau
            // 
            this.truyenmau.Enabled = false;
            this.truyenmau.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.truyenmau.Location = new System.Drawing.Point(184, 36);
            this.truyenmau.Name = "truyenmau";
            this.truyenmau.Size = new System.Drawing.Size(88, 16);
            this.truyenmau.TabIndex = 4;
            this.truyenmau.Text = "Truyền máu";
            this.truyenmau.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.vangda);
            this.groupBox6.Controls.Add(this.viemgan);
            this.groupBox6.Controls.Add(this.tieuhoa);
            this.groupBox6.Controls.Add(this.thuongvi);
            this.groupBox6.Controls.Add(this.th_khac);
            this.groupBox6.Location = new System.Drawing.Point(544, 139);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(139, 102);
            this.groupBox6.TabIndex = 433;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Tiêu hoá";
            // 
            // vangda
            // 
            this.vangda.Enabled = false;
            this.vangda.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vangda.Location = new System.Drawing.Point(6, 30);
            this.vangda.Name = "vangda";
            this.vangda.Size = new System.Drawing.Size(78, 16);
            this.vangda.TabIndex = 33;
            this.vangda.Text = "Vàng da";
            this.vangda.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // viemgan
            // 
            this.viemgan.Enabled = false;
            this.viemgan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viemgan.Location = new System.Drawing.Point(6, 47);
            this.viemgan.Name = "viemgan";
            this.viemgan.Size = new System.Drawing.Size(72, 16);
            this.viemgan.TabIndex = 34;
            this.viemgan.Text = "Viêm gan";
            this.viemgan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // tieuhoa
            // 
            this.tieuhoa.Enabled = false;
            this.tieuhoa.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tieuhoa.Location = new System.Drawing.Point(6, 13);
            this.tieuhoa.Name = "tieuhoa";
            this.tieuhoa.Size = new System.Drawing.Size(128, 16);
            this.tieuhoa.TabIndex = 35;
            this.tieuhoa.Text = "Xuất huyết tiêu hoá";
            this.tieuhoa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // thuongvi
            // 
            this.thuongvi.Enabled = false;
            this.thuongvi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thuongvi.Location = new System.Drawing.Point(6, 64);
            this.thuongvi.Name = "thuongvi";
            this.thuongvi.Size = new System.Drawing.Size(128, 16);
            this.thuongvi.TabIndex = 36;
            this.thuongvi.Text = "Đau thượng vị";
            this.thuongvi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // th_khac
            // 
            this.th_khac.Enabled = false;
            this.th_khac.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.th_khac.Location = new System.Drawing.Point(6, 81);
            this.th_khac.Name = "th_khac";
            this.th_khac.Size = new System.Drawing.Size(80, 16);
            this.th_khac.TabIndex = 37;
            this.th_khac.Text = "Khác";
            this.th_khac.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cauthan);
            this.groupBox5.Controls.Add(this.suythan);
            this.groupBox5.Controls.Add(this.soithan);
            this.groupBox5.Controls.Add(this.tn_khac);
            this.groupBox5.Location = new System.Drawing.Point(688, 139);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(109, 102);
            this.groupBox5.TabIndex = 432;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Tiết niệu";
            // 
            // cauthan
            // 
            this.cauthan.Enabled = false;
            this.cauthan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cauthan.Location = new System.Drawing.Point(6, 12);
            this.cauthan.Name = "cauthan";
            this.cauthan.Size = new System.Drawing.Size(98, 21);
            this.cauthan.TabIndex = 29;
            this.cauthan.Text = "Viêm cầu thận";
            this.cauthan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // suythan
            // 
            this.suythan.Enabled = false;
            this.suythan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.suythan.Location = new System.Drawing.Point(6, 33);
            this.suythan.Name = "suythan";
            this.suythan.Size = new System.Drawing.Size(98, 16);
            this.suythan.TabIndex = 30;
            this.suythan.Text = "Suy thận";
            this.suythan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // soithan
            // 
            this.soithan.Enabled = false;
            this.soithan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.soithan.Location = new System.Drawing.Point(6, 49);
            this.soithan.Name = "soithan";
            this.soithan.Size = new System.Drawing.Size(88, 16);
            this.soithan.TabIndex = 31;
            this.soithan.Text = "Sỏi thận";
            this.soithan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // tn_khac
            // 
            this.tn_khac.Enabled = false;
            this.tn_khac.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tn_khac.Location = new System.Drawing.Point(6, 65);
            this.tn_khac.Name = "tn_khac";
            this.tn_khac.Size = new System.Drawing.Size(80, 16);
            this.tn_khac.TabIndex = 32;
            this.tn_khac.Text = "Khác";
            this.tn_khac.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.thuocla);
            this.groupBox3.Controls.Add(this.ruou);
            this.groupBox3.Controls.Add(this.matuy);
            this.groupBox3.Location = new System.Drawing.Point(372, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(170, 85);
            this.groupBox3.TabIndex = 430;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Thói quen";
            // 
            // thuocla
            // 
            this.thuocla.Enabled = false;
            this.thuocla.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thuocla.Location = new System.Drawing.Point(6, 17);
            this.thuocla.Name = "thuocla";
            this.thuocla.Size = new System.Drawing.Size(96, 16);
            this.thuocla.TabIndex = 8;
            this.thuocla.Text = "Hút thuốc lá";
            this.thuocla.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // ruou
            // 
            this.ruou.Enabled = false;
            this.ruou.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ruou.Location = new System.Drawing.Point(6, 40);
            this.ruou.Name = "ruou";
            this.ruou.Size = new System.Drawing.Size(80, 16);
            this.ruou.TabIndex = 9;
            this.ruou.Text = "Uống rượu";
            this.ruou.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // matuy
            // 
            this.matuy.Enabled = false;
            this.matuy.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.matuy.Location = new System.Drawing.Point(6, 63);
            this.matuy.Name = "matuy";
            this.matuy.Size = new System.Drawing.Size(68, 16);
            this.matuy.TabIndex = 10;
            this.matuy.Text = "Ma túy";
            this.matuy.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tamthan);
            this.groupBox4.Controls.Add(this.dongkinh);
            this.groupBox4.Controls.Add(this.maukdong);
            this.groupBox4.Controls.Add(this.tieuduong);
            this.groupBox4.Controls.Add(this.tbmmn);
            this.groupBox4.Controls.Add(this.hethong);
            this.groupBox4.Controls.Add(this.tk_khac);
            this.groupBox4.Controls.Add(this.buouco);
            this.groupBox4.Location = new System.Drawing.Point(372, 95);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(170, 146);
            this.groupBox4.TabIndex = 431;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Thần kinh, nội tiết, huyết học";
            // 
            // tamthan
            // 
            this.tamthan.Enabled = false;
            this.tamthan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tamthan.Location = new System.Drawing.Point(6, 14);
            this.tamthan.Name = "tamthan";
            this.tamthan.Size = new System.Drawing.Size(72, 16);
            this.tamthan.TabIndex = 21;
            this.tamthan.Text = "Tâm thần";
            this.tamthan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // dongkinh
            // 
            this.dongkinh.Enabled = false;
            this.dongkinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dongkinh.Location = new System.Drawing.Point(6, 30);
            this.dongkinh.Name = "dongkinh";
            this.dongkinh.Size = new System.Drawing.Size(98, 16);
            this.dongkinh.TabIndex = 22;
            this.dongkinh.Text = "Động kinh";
            this.dongkinh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // maukdong
            // 
            this.maukdong.Enabled = false;
            this.maukdong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maukdong.Location = new System.Drawing.Point(6, 46);
            this.maukdong.Name = "maukdong";
            this.maukdong.Size = new System.Drawing.Size(144, 16);
            this.maukdong.TabIndex = 25;
            this.maukdong.Text = "Bệnh máu không đông";
            this.maukdong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // tieuduong
            // 
            this.tieuduong.Enabled = false;
            this.tieuduong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tieuduong.Location = new System.Drawing.Point(6, 62);
            this.tieuduong.Name = "tieuduong";
            this.tieuduong.Size = new System.Drawing.Size(98, 16);
            this.tieuduong.TabIndex = 26;
            this.tieuduong.Text = "Tiểu đường";
            this.tieuduong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // tbmmn
            // 
            this.tbmmn.Enabled = false;
            this.tbmmn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbmmn.Location = new System.Drawing.Point(6, 78);
            this.tbmmn.Name = "tbmmn";
            this.tbmmn.Size = new System.Drawing.Size(80, 16);
            this.tbmmn.TabIndex = 23;
            this.tbmmn.Text = "TBMMN cũ";
            this.tbmmn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // hethong
            // 
            this.hethong.Enabled = false;
            this.hethong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hethong.Location = new System.Drawing.Point(6, 94);
            this.hethong.Name = "hethong";
            this.hethong.Size = new System.Drawing.Size(104, 16);
            this.hethong.TabIndex = 27;
            this.hethong.Text = "Bệnh hệ thống";
            this.hethong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // tk_khac
            // 
            this.tk_khac.Enabled = false;
            this.tk_khac.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tk_khac.Location = new System.Drawing.Point(6, 126);
            this.tk_khac.Name = "tk_khac";
            this.tk_khac.Size = new System.Drawing.Size(54, 16);
            this.tk_khac.TabIndex = 28;
            this.tk_khac.Text = "Khác";
            this.tk_khac.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // buouco
            // 
            this.buouco.Enabled = false;
            this.buouco.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buouco.Location = new System.Drawing.Point(6, 110);
            this.buouco.Name = "buouco";
            this.buouco.Size = new System.Drawing.Size(80, 16);
            this.buouco.TabIndex = 24;
            this.buouco.Text = "Bướu cổ";
            this.buouco.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.caoha);
            this.groupBox2.Controls.Add(this.thatnguc);
            this.groupBox2.Controls.Add(this.nmct);
            this.groupBox2.Controls.Add(this.suytim);
            this.groupBox2.Controls.Add(this.timbamsinh);
            this.groupBox2.Location = new System.Drawing.Point(544, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(140, 100);
            this.groupBox2.TabIndex = 429;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tim mạch";
            // 
            // caoha
            // 
            this.caoha.Enabled = false;
            this.caoha.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.caoha.Location = new System.Drawing.Point(6, 16);
            this.caoha.Name = "caoha";
            this.caoha.Size = new System.Drawing.Size(64, 16);
            this.caoha.TabIndex = 11;
            this.caoha.Text = "Cao HA";
            this.caoha.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // thatnguc
            // 
            this.thatnguc.Enabled = false;
            this.thatnguc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thatnguc.Location = new System.Drawing.Point(6, 32);
            this.thatnguc.Name = "thatnguc";
            this.thatnguc.Size = new System.Drawing.Size(98, 16);
            this.thatnguc.TabIndex = 12;
            this.thatnguc.Text = "Đau thắt ngực";
            this.thatnguc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // nmct
            // 
            this.nmct.Enabled = false;
            this.nmct.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nmct.Location = new System.Drawing.Point(6, 48);
            this.nmct.Name = "nmct";
            this.nmct.Size = new System.Drawing.Size(56, 16);
            this.nmct.TabIndex = 13;
            this.nmct.Text = "NMCT";
            this.nmct.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // suytim
            // 
            this.suytim.Enabled = false;
            this.suytim.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.suytim.Location = new System.Drawing.Point(6, 64);
            this.suytim.Name = "suytim";
            this.suytim.Size = new System.Drawing.Size(64, 16);
            this.suytim.TabIndex = 14;
            this.suytim.Text = "Suy tim";
            this.suytim.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // timbamsinh
            // 
            this.timbamsinh.Enabled = false;
            this.timbamsinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timbamsinh.Location = new System.Drawing.Point(6, 80);
            this.timbamsinh.Name = "timbamsinh";
            this.timbamsinh.Size = new System.Drawing.Size(96, 16);
            this.timbamsinh.TabIndex = 15;
            this.timbamsinh.Text = "Tim bẩm sinh";
            this.timbamsinh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.phequan);
            this.groupBox1.Controls.Add(this.lao);
            this.groupBox1.Controls.Add(this.horamau);
            this.groupBox1.Controls.Add(this.copd);
            this.groupBox1.Controls.Add(this.hh_khac);
            this.groupBox1.Location = new System.Drawing.Point(688, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(109, 100);
            this.groupBox1.TabIndex = 428;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Hô hấp";
            // 
            // phequan
            // 
            this.phequan.Enabled = false;
            this.phequan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phequan.Location = new System.Drawing.Point(7, 32);
            this.phequan.Name = "phequan";
            this.phequan.Size = new System.Drawing.Size(98, 16);
            this.phequan.TabIndex = 17;
            this.phequan.Text = "Hen phế quản";
            this.phequan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // lao
            // 
            this.lao.Enabled = false;
            this.lao.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lao.Location = new System.Drawing.Point(7, 16);
            this.lao.Name = "lao";
            this.lao.Size = new System.Drawing.Size(64, 16);
            this.lao.TabIndex = 16;
            this.lao.Text = "Lao";
            this.lao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // horamau
            // 
            this.horamau.Enabled = false;
            this.horamau.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.horamau.Location = new System.Drawing.Point(7, 48);
            this.horamau.Name = "horamau";
            this.horamau.Size = new System.Drawing.Size(80, 16);
            this.horamau.TabIndex = 18;
            this.horamau.Text = "Ho ra máu";
            this.horamau.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // copd
            // 
            this.copd.Enabled = false;
            this.copd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.copd.Location = new System.Drawing.Point(7, 64);
            this.copd.Name = "copd";
            this.copd.Size = new System.Drawing.Size(64, 16);
            this.copd.TabIndex = 19;
            this.copd.Text = "COPD";
            this.copd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // hh_khac
            // 
            this.hh_khac.Enabled = false;
            this.hh_khac.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hh_khac.Location = new System.Drawing.Point(7, 80);
            this.hh_khac.Name = "hh_khac";
            this.hh_khac.Size = new System.Drawing.Size(48, 16);
            this.hh_khac.TabIndex = 20;
            this.hh_khac.Text = "khác";
            this.hh_khac.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // cs_khac
            // 
            this.cs_khac.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cs_khac.Enabled = false;
            this.cs_khac.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cs_khac.Location = new System.Drawing.Point(664, 430);
            this.cs_khac.Name = "cs_khac";
            this.cs_khac.Size = new System.Drawing.Size(128, 21);
            this.cs_khac.TabIndex = 106;
            this.cs_khac.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // label95
            // 
            this.label95.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label95.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label95.Location = new System.Drawing.Point(632, 432);
            this.label95.Name = "label95";
            this.label95.Size = new System.Drawing.Size(88, 16);
            this.label95.TabIndex = 427;
            this.label95.Text = "Khác :";
            this.label95.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cungcotsong
            // 
            this.cungcotsong.Enabled = false;
            this.cungcotsong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cungcotsong.Location = new System.Drawing.Point(536, 432);
            this.cungcotsong.Name = "cungcotsong";
            this.cungcotsong.Size = new System.Drawing.Size(104, 16);
            this.cungcotsong.TabIndex = 105;
            this.cungcotsong.Text = "Cứng cột sống";
            this.cungcotsong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // gu
            // 
            this.gu.Enabled = false;
            this.gu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gu.Location = new System.Drawing.Point(480, 432);
            this.gu.Name = "gu";
            this.gu.Size = new System.Drawing.Size(78, 16);
            this.gu.TabIndex = 104;
            this.gu.Text = "Gù, vẹo";
            this.gu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // k_tk_khac
            // 
            this.k_tk_khac.BackColor = System.Drawing.SystemColors.HighlightText;
            this.k_tk_khac.Enabled = false;
            this.k_tk_khac.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.k_tk_khac.Location = new System.Drawing.Point(248, 430);
            this.k_tk_khac.Name = "k_tk_khac";
            this.k_tk_khac.Size = new System.Drawing.Size(136, 21);
            this.k_tk_khac.TabIndex = 102;
            this.k_tk_khac.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // label94
            // 
            this.label94.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label94.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label94.Location = new System.Drawing.Point(216, 432);
            this.label94.Name = "label94";
            this.label94.Size = new System.Drawing.Size(88, 16);
            this.label94.TabIndex = 101;
            this.label94.Text = "Khác :";
            this.label94.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tk_yeu
            // 
            this.tk_yeu.Enabled = false;
            this.tk_yeu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tk_yeu.Location = new System.Drawing.Point(110, 432);
            this.tk_yeu.Name = "tk_yeu";
            this.tk_yeu.Size = new System.Drawing.Size(119, 16);
            this.tk_yeu.TabIndex = 100;
            this.tk_yeu.Text = "Yếu liệt nửa người";
            this.tk_yeu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // tk_bt
            // 
            this.tk_bt.Enabled = false;
            this.tk_bt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tk_bt.Location = new System.Drawing.Point(75, 432);
            this.tk_bt.Name = "tk_bt";
            this.tk_bt.Size = new System.Drawing.Size(40, 16);
            this.tk_bt.TabIndex = 99;
            this.tk_bt.Text = "BT";
            this.tk_bt.CheckedChanged += new System.EventHandler(this.tk_bt_CheckedChanged);
            this.tk_bt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // label93
            // 
            this.label93.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label93.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label93.Location = new System.Drawing.Point(12, 432);
            this.label93.Name = "label93";
            this.label93.Size = new System.Drawing.Size(80, 16);
            this.label93.TabIndex = 426;
            this.label93.Text = "+Thần kinh :";
            this.label93.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cs_bt
            // 
            this.cs_bt.Enabled = false;
            this.cs_bt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cs_bt.Location = new System.Drawing.Point(448, 432);
            this.cs_bt.Name = "cs_bt";
            this.cs_bt.Size = new System.Drawing.Size(48, 16);
            this.cs_bt.TabIndex = 103;
            this.cs_bt.Text = "BT";
            this.cs_bt.CheckedChanged += new System.EventHandler(this.cs_bt_CheckedChanged);
            this.cs_bt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // nt_khac
            // 
            this.nt_khac.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nt_khac.Enabled = false;
            this.nt_khac.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nt_khac.Location = new System.Drawing.Point(664, 406);
            this.nt_khac.Name = "nt_khac";
            this.nt_khac.Size = new System.Drawing.Size(128, 21);
            this.nt_khac.TabIndex = 98;
            this.nt_khac.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // label92
            // 
            this.label92.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label92.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label92.Location = new System.Drawing.Point(632, 408);
            this.label92.Name = "label92";
            this.label92.Size = new System.Drawing.Size(88, 16);
            this.label92.TabIndex = 97;
            this.label92.Text = "Khác :";
            this.label92.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nt_td
            // 
            this.nt_td.Enabled = false;
            this.nt_td.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nt_td.Location = new System.Drawing.Point(544, 408);
            this.nt_td.Name = "nt_td";
            this.nt_td.Size = new System.Drawing.Size(88, 16);
            this.nt_td.TabIndex = 96;
            this.nt_td.Text = "Tiểu đường";
            this.nt_td.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // nt_bg
            // 
            this.nt_bg.Enabled = false;
            this.nt_bg.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nt_bg.Location = new System.Drawing.Point(472, 408);
            this.nt_bg.Name = "nt_bg";
            this.nt_bg.Size = new System.Drawing.Size(80, 16);
            this.nt_bg.TabIndex = 95;
            this.nt_bg.Text = "Bướu giáp";
            this.nt_bg.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // nt_bt
            // 
            this.nt_bt.Enabled = false;
            this.nt_bt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nt_bt.Location = new System.Drawing.Point(440, 408);
            this.nt_bt.Name = "nt_bt";
            this.nt_bt.Size = new System.Drawing.Size(40, 16);
            this.nt_bt.TabIndex = 94;
            this.nt_bt.Text = "BT";
            this.nt_bt.CheckedChanged += new System.EventHandler(this.nt_bt_CheckedChanged);
            this.nt_bt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // label91
            // 
            this.label91.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label91.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label91.Location = new System.Drawing.Point(384, 408);
            this.label91.Name = "label91";
            this.label91.Size = new System.Drawing.Size(80, 16);
            this.label91.TabIndex = 93;
            this.label91.Text = "+Nội tiết :";
            this.label91.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // k_hh_khac
            // 
            this.k_hh_khac.BackColor = System.Drawing.SystemColors.HighlightText;
            this.k_hh_khac.Enabled = false;
            this.k_hh_khac.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.k_hh_khac.Location = new System.Drawing.Point(248, 406);
            this.k_hh_khac.Name = "k_hh_khac";
            this.k_hh_khac.Size = new System.Drawing.Size(136, 21);
            this.k_hh_khac.TabIndex = 92;
            this.k_hh_khac.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // label90
            // 
            this.label90.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label90.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label90.Location = new System.Drawing.Point(216, 408);
            this.label90.Name = "label90";
            this.label90.Size = new System.Drawing.Size(88, 16);
            this.label90.TabIndex = 91;
            this.label90.Text = "Khác :";
            this.label90.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // hh_suyen
            // 
            this.hh_suyen.Enabled = false;
            this.hh_suyen.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hh_suyen.Location = new System.Drawing.Point(160, 408);
            this.hh_suyen.Name = "hh_suyen";
            this.hh_suyen.Size = new System.Drawing.Size(56, 16);
            this.hh_suyen.TabIndex = 90;
            this.hh_suyen.Text = "Suyễn";
            this.hh_suyen.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // hh_copd
            // 
            this.hh_copd.Enabled = false;
            this.hh_copd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hh_copd.Location = new System.Drawing.Point(109, 408);
            this.hh_copd.Name = "hh_copd";
            this.hh_copd.Size = new System.Drawing.Size(67, 16);
            this.hh_copd.TabIndex = 89;
            this.hh_copd.Text = "COPD";
            this.hh_copd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // hh_bt
            // 
            this.hh_bt.Enabled = false;
            this.hh_bt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hh_bt.Location = new System.Drawing.Point(75, 408);
            this.hh_bt.Name = "hh_bt";
            this.hh_bt.Size = new System.Drawing.Size(40, 16);
            this.hh_bt.TabIndex = 88;
            this.hh_bt.Text = "BT";
            this.hh_bt.CheckedChanged += new System.EventHandler(this.hh_bt_CheckedChanged);
            this.hh_bt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // label88
            // 
            this.label88.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label88.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label88.Location = new System.Drawing.Point(12, 408);
            this.label88.Name = "label88";
            this.label88.Size = new System.Drawing.Size(80, 16);
            this.label88.TabIndex = 414;
            this.label88.Text = "+Hô hấp :";
            this.label88.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tm_khac
            // 
            this.tm_khac.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tm_khac.Enabled = false;
            this.tm_khac.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tm_khac.Location = new System.Drawing.Point(664, 383);
            this.tm_khac.Name = "tm_khac";
            this.tm_khac.Size = new System.Drawing.Size(128, 21);
            this.tm_khac.TabIndex = 87;
            this.tm_khac.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // label87
            // 
            this.label87.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label87.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label87.Location = new System.Drawing.Point(632, 385);
            this.label87.Name = "label87";
            this.label87.Size = new System.Drawing.Size(88, 16);
            this.label87.TabIndex = 86;
            this.label87.Text = "Khác :";
            this.label87.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tm_dtn
            // 
            this.tm_dtn.Enabled = false;
            this.tm_dtn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tm_dtn.Location = new System.Drawing.Point(440, 385);
            this.tm_dtn.Name = "tm_dtn";
            this.tm_dtn.Size = new System.Drawing.Size(104, 16);
            this.tm_dtn.TabIndex = 84;
            this.tm_dtn.Text = "Đau thắt ngực";
            this.tm_dtn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // tm_ln
            // 
            this.tm_ln.Enabled = false;
            this.tm_ln.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tm_ln.Location = new System.Drawing.Point(544, 385);
            this.tm_ln.Name = "tm_ln";
            this.tm_ln.Size = new System.Drawing.Size(78, 16);
            this.tm_ln.TabIndex = 85;
            this.tm_ln.Text = "Loạn nhịp";
            this.tm_ln.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // tm_cha
            // 
            this.tm_cha.Enabled = false;
            this.tm_cha.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tm_cha.Location = new System.Drawing.Point(336, 385);
            this.tm_cha.Name = "tm_cha";
            this.tm_cha.Size = new System.Drawing.Size(96, 16);
            this.tm_cha.TabIndex = 83;
            this.tm_cha.Text = "Cao huyết áp";
            this.tm_cha.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // tm_bt
            // 
            this.tm_bt.Enabled = false;
            this.tm_bt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tm_bt.Location = new System.Drawing.Point(240, 385);
            this.tm_bt.Name = "tm_bt";
            this.tm_bt.Size = new System.Drawing.Size(88, 16);
            this.tm_bt.TabIndex = 82;
            this.tm_bt.Text = "Bình thường";
            this.tm_bt.CheckedChanged += new System.EventHandler(this.tm_bt_CheckedChanged);
            this.tm_bt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // label86
            // 
            this.label86.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label86.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label86.Location = new System.Drawing.Point(144, 385);
            this.label86.Name = "label86";
            this.label86.Size = new System.Drawing.Size(80, 16);
            this.label86.TabIndex = 81;
            this.label86.Text = "+ Tim mạch :";
            this.label86.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bmi
            // 
            this.bmi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.bmi.Enabled = false;
            this.bmi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bmi.Location = new System.Drawing.Point(752, 301);
            this.bmi.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.bmi.MaxLength = 5;
            this.bmi.Name = "bmi";
            this.bmi.Size = new System.Drawing.Size(40, 21);
            this.bmi.TabIndex = 70;
            this.bmi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label85
            // 
            this.label85.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label85.Location = new System.Drawing.Point(712, 304);
            this.label85.Name = "label85";
            this.label85.Size = new System.Drawing.Size(40, 16);
            this.label85.TabIndex = 69;
            this.label85.Text = "BMI :";
            this.label85.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tinhmach
            // 
            this.tinhmach.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tinhmach.Enabled = false;
            this.tinhmach.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tinhmach.Location = new System.Drawing.Point(696, 278);
            this.tinhmach.Name = "tinhmach";
            this.tinhmach.Size = new System.Drawing.Size(96, 21);
            this.tinhmach.TabIndex = 50;
            this.tinhmach.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // label84
            // 
            this.label84.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label84.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label84.Location = new System.Drawing.Point(624, 281);
            this.label84.Name = "label84";
            this.label84.Size = new System.Drawing.Size(88, 16);
            this.label84.TabIndex = 404;
            this.label84.Text = "Hệ tĩnh mạch :";
            this.label84.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // listBS1
            // 
            this.listBS1.BackColor = System.Drawing.SystemColors.Info;
            this.listBS1.ColumnCount = 0;
            this.listBS1.Location = new System.Drawing.Point(264, 664);
            this.listBS1.MatchBufferTimeOut = 1000;
            this.listBS1.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listBS1.Name = "listBS1";
            this.listBS1.Size = new System.Drawing.Size(75, 17);
            this.listBS1.TabIndex = 402;
            this.listBS1.TextIndex = -1;
            this.listBS1.TextMember = null;
            this.listBS1.ValueIndex = -1;
            this.listBS1.Visible = false;
            // 
            // tenbs_pass
            // 
            this.tenbs_pass.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbs_pass.Enabled = false;
            this.tenbs_pass.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbs_pass.Location = new System.Drawing.Point(720, 628);
            this.tenbs_pass.Name = "tenbs_pass";
            this.tenbs_pass.PasswordChar = '*';
            this.tenbs_pass.Size = new System.Drawing.Size(72, 21);
            this.tenbs_pass.TabIndex = 123;
            this.tenbs_pass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbs_pass_KeyDown);
            // 
            // tenbs
            // 
            this.tenbs.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbs.Enabled = false;
            this.tenbs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbs.Location = new System.Drawing.Point(519, 628);
            this.tenbs.Name = "tenbs";
            this.tenbs.Size = new System.Drawing.Size(200, 21);
            this.tenbs.TabIndex = 122;
            this.tenbs.TextChanged += new System.EventHandler(this.tenbs_TextChanged);
            this.tenbs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbs_KeyDown);
            // 
            // mabs
            // 
            this.mabs.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mabs.Enabled = false;
            this.mabs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabs.Location = new System.Drawing.Point(480, 628);
            this.mabs.MaxLength = 4;
            this.mabs.Name = "mabs";
            this.mabs.Size = new System.Drawing.Size(38, 21);
            this.mabs.TabIndex = 121;
            this.mabs.Validated += new System.EventHandler(this.mabs_Validated);
            this.mabs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // label82
            // 
            this.label82.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label82.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label82.Location = new System.Drawing.Point(392, 632);
            this.label82.Name = "label82";
            this.label82.Size = new System.Drawing.Size(88, 16);
            this.label82.TabIndex = 401;
            this.label82.Text = "Bác sĩ GMHS :";
            this.label82.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ngaykham
            // 
            this.ngaykham.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngaykham.Enabled = false;
            this.ngaykham.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngaykham.Location = new System.Drawing.Point(176, 628);
            this.ngaykham.Mask = "##/##/####";
            this.ngaykham.Name = "ngaykham";
            this.ngaykham.Size = new System.Drawing.Size(72, 21);
            this.ngaykham.TabIndex = 120;
            this.ngaykham.Text = "  /  /    ";
            this.ngaykham.Validated += new System.EventHandler(this.ngaykham_Validated);
            // 
            // label83
            // 
            this.label83.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label83.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label83.Location = new System.Drawing.Point(132, 632);
            this.label83.Name = "label83";
            this.label83.Size = new System.Drawing.Size(40, 16);
            this.label83.TabIndex = 399;
            this.label83.Text = "Ngày :";
            this.label83.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ketluan
            // 
            this.ketluan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ketluan.Enabled = false;
            this.ketluan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ketluan.Location = new System.Drawing.Point(176, 593);
            this.ketluan.Multiline = true;
            this.ketluan.Name = "ketluan";
            this.ketluan.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ketluan.Size = new System.Drawing.Size(616, 29);
            this.ketluan.TabIndex = 119;
            // 
            // thuthuat
            // 
            this.thuthuat.BackColor = System.Drawing.SystemColors.HighlightText;
            this.thuthuat.Enabled = false;
            this.thuthuat.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thuthuat.Location = new System.Drawing.Point(176, 571);
            this.thuthuat.Name = "thuthuat";
            this.thuthuat.Size = new System.Drawing.Size(616, 21);
            this.thuthuat.TabIndex = 118;
            this.thuthuat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // dukien
            // 
            this.dukien.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dukien.Enabled = false;
            this.dukien.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dukien.Location = new System.Drawing.Point(568, 549);
            this.dukien.Name = "dukien";
            this.dukien.Size = new System.Drawing.Size(224, 21);
            this.dukien.TabIndex = 117;
            this.dukien.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // mallampati
            // 
            this.mallampati.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mallampati.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mallampati.Enabled = false;
            this.mallampati.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mallampati.Items.AddRange(new object[] {
            "I",
            "II",
            "III",
            "IV"});
            this.mallampati.Location = new System.Drawing.Point(432, 549);
            this.mallampati.Name = "mallampati";
            this.mallampati.Size = new System.Drawing.Size(40, 21);
            this.mallampati.TabIndex = 115;
            this.mallampati.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mallampati_KeyDown);
            // 
            // glodmann
            // 
            this.glodmann.BackColor = System.Drawing.SystemColors.HighlightText;
            this.glodmann.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.glodmann.Enabled = false;
            this.glodmann.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.glodmann.Items.AddRange(new object[] {
            "I",
            "II",
            "III",
            "IV"});
            this.glodmann.Location = new System.Drawing.Point(317, 549);
            this.glodmann.Name = "glodmann";
            this.glodmann.Size = new System.Drawing.Size(40, 21);
            this.glodmann.TabIndex = 113;
            this.glodmann.KeyDown += new System.Windows.Forms.KeyEventHandler(this.glodmann_KeyDown);
            // 
            // asa
            // 
            this.asa.BackColor = System.Drawing.SystemColors.HighlightText;
            this.asa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.asa.Enabled = false;
            this.asa.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.asa.Items.AddRange(new object[] {
            "I",
            "II",
            "III",
            "IV",
            "V"});
            this.asa.Location = new System.Drawing.Point(208, 549);
            this.asa.Name = "asa";
            this.asa.Size = new System.Drawing.Size(40, 21);
            this.asa.TabIndex = 111;
            this.asa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.asa_KeyDown);
            // 
            // label81
            // 
            this.label81.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label81.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label81.Location = new System.Drawing.Point(88, 573);
            this.label81.Name = "label81";
            this.label81.Size = new System.Drawing.Size(128, 17);
            this.label81.TabIndex = 392;
            this.label81.Text = "Các thủ thuật :";
            this.label81.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label80
            // 
            this.label80.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label80.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label80.Location = new System.Drawing.Point(473, 551);
            this.label80.Name = "label80";
            this.label80.Size = new System.Drawing.Size(104, 17);
            this.label80.TabIndex = 116;
            this.label80.Text = "Dự kiến vô cảm :";
            this.label80.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label79
            // 
            this.label79.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label79.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label79.Location = new System.Drawing.Point(360, 551);
            this.label79.Name = "label79";
            this.label79.Size = new System.Drawing.Size(80, 17);
            this.label79.TabIndex = 114;
            this.label79.Text = "Mallampati :";
            this.label79.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label78
            // 
            this.label78.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label78.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label78.Location = new System.Drawing.Point(248, 551);
            this.label78.Name = "label78";
            this.label78.Size = new System.Drawing.Size(72, 17);
            this.label78.TabIndex = 112;
            this.label78.Text = "Goldmann :";
            this.label78.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label77
            // 
            this.label77.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label77.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label77.Location = new System.Drawing.Point(176, 551);
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(40, 17);
            this.label77.TabIndex = 110;
            this.label77.Text = "ASA :";
            this.label77.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label76
            // 
            this.label76.Font = new System.Drawing.Font("Tahoma", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label76.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label76.Location = new System.Drawing.Point(8, 589);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(224, 17);
            this.label76.TabIndex = 387;
            this.label76.Text = "KẾT LUẬN CHUNG :";
            this.label76.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // denghi
            // 
            this.denghi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.denghi.Enabled = false;
            this.denghi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.denghi.Location = new System.Drawing.Point(176, 512);
            this.denghi.Multiline = true;
            this.denghi.Name = "denghi";
            this.denghi.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.denghi.Size = new System.Drawing.Size(616, 31);
            this.denghi.TabIndex = 109;
            // 
            // dieutri
            // 
            this.dieutri.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dieutri.Enabled = false;
            this.dieutri.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dieutri.Location = new System.Drawing.Point(176, 473);
            this.dieutri.Name = "dieutri";
            this.dieutri.Size = new System.Drawing.Size(616, 21);
            this.dieutri.TabIndex = 108;
            this.dieutri.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // canlamsang
            // 
            this.canlamsang.BackColor = System.Drawing.SystemColors.HighlightText;
            this.canlamsang.Enabled = false;
            this.canlamsang.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.canlamsang.Location = new System.Drawing.Point(176, 451);
            this.canlamsang.Name = "canlamsang";
            this.canlamsang.Size = new System.Drawing.Size(616, 21);
            this.canlamsang.TabIndex = 107;
            this.canlamsang.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // label75
            // 
            this.label75.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label75.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label75.Location = new System.Drawing.Point(128, 495);
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(344, 16);
            this.label75.TabIndex = 383;
            this.label75.Text = "( Khám chuyên khoa, Xét nghiệm, Thêm thuốc, ngưng thuốc )";
            this.label75.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label74
            // 
            this.label74.Font = new System.Drawing.Font("Tahoma", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label74.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label74.Location = new System.Drawing.Point(8, 551);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(224, 17);
            this.label74.TabIndex = 382;
            this.label74.Text = "ĐÁNH GIÁ CỦA GÂY MÊ :";
            this.label74.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label73
            // 
            this.label73.Font = new System.Drawing.Font("Tahoma", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label73.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label73.Location = new System.Drawing.Point(8, 496);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(224, 17);
            this.label73.TabIndex = 381;
            this.label73.Text = "ĐỀ NGHỊ ĐẶC BIỆT :";
            this.label73.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label71
            // 
            this.label71.Font = new System.Drawing.Font("Tahoma", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label71.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label71.Location = new System.Drawing.Point(8, 472);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(224, 17);
            this.label71.TabIndex = 380;
            this.label71.Text = "ĐIỀU TRỊ ĐANG THỰC HIỆN :";
            this.label71.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label69
            // 
            this.label69.Font = new System.Drawing.Font("Tahoma", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label69.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label69.Location = new System.Drawing.Point(8, 452);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(224, 17);
            this.label69.TabIndex = 379;
            this.label69.Text = "CẬN LÂM SÀNG BẤT THƯỜNG :";
            this.label69.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label68
            // 
            this.label68.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label68.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label68.Location = new System.Drawing.Point(384, 432);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(72, 17);
            this.label68.TabIndex = 103;
            this.label68.Text = "+ Cột sống :";
            this.label68.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label67
            // 
            this.label67.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label67.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label67.Location = new System.Drawing.Point(16, 385);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(144, 17);
            this.label67.TabIndex = 369;
            this.label67.Text = "3. Khám cơ quan :";
            this.label67.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tl_khac
            // 
            this.tl_khac.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tl_khac.Enabled = false;
            this.tl_khac.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tl_khac.Location = new System.Drawing.Point(296, 358);
            this.tl_khac.Name = "tl_khac";
            this.tl_khac.Size = new System.Drawing.Size(496, 21);
            this.tl_khac.TabIndex = 80;
            this.tl_khac.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // label66
            // 
            this.label66.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label66.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label66.Location = new System.Drawing.Point(152, 361);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(152, 16);
            this.label66.TabIndex = 79;
            this.label66.Text = "Đặc điểm bất thường khác :";
            this.label66.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ranggia
            // 
            this.ranggia.Enabled = false;
            this.ranggia.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ranggia.Location = new System.Drawing.Point(552, 342);
            this.ranggia.Name = "ranggia";
            this.ranggia.Size = new System.Drawing.Size(80, 16);
            this.ranggia.TabIndex = 78;
            this.ranggia.Text = "Răng giả";
            this.ranggia.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // seo
            // 
            this.seo.Enabled = false;
            this.seo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.seo.Location = new System.Drawing.Point(448, 342);
            this.seo.Name = "seo";
            this.seo.Size = new System.Drawing.Size(96, 16);
            this.seo.TabIndex = 77;
            this.seo.Text = "Sẹo ở cổ, mặt";
            this.seo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // cungham
            // 
            this.cungham.Enabled = false;
            this.cungham.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cungham.Location = new System.Drawing.Point(336, 342);
            this.cungham.Name = "cungham";
            this.cungham.Size = new System.Drawing.Size(80, 16);
            this.cungham.TabIndex = 76;
            this.cungham.Text = "Cứng hàm";
            this.cungham.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // giap
            // 
            this.giap.Enabled = false;
            this.giap.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.giap.Location = new System.Drawing.Point(152, 342);
            this.giap.Name = "giap";
            this.giap.Size = new System.Drawing.Size(184, 16);
            this.giap.TabIndex = 75;
            this.giap.Text = "Khoảng cách giáp -  cằm < 6cm";
            this.giap.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // khoiu
            // 
            this.khoiu.Enabled = false;
            this.khoiu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.khoiu.Location = new System.Drawing.Point(552, 326);
            this.khoiu.Name = "khoiu";
            this.khoiu.Size = new System.Drawing.Size(184, 16);
            this.khoiu.TabIndex = 74;
            this.khoiu.Text = "Khối u dưới cằm, cổ, xương ức";
            this.khoiu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // luoito
            // 
            this.luoito.Enabled = false;
            this.luoito.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.luoito.Location = new System.Drawing.Point(448, 326);
            this.luoito.Name = "luoito";
            this.luoito.Size = new System.Drawing.Size(64, 16);
            this.luoito.TabIndex = 73;
            this.luoito.Text = "Lưỡi to";
            this.luoito.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // congan
            // 
            this.congan.Enabled = false;
            this.congan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.congan.Location = new System.Drawing.Point(336, 326);
            this.congan.Name = "congan";
            this.congan.Size = new System.Drawing.Size(72, 16);
            this.congan.TabIndex = 72;
            this.congan.Text = "Cổ ngắn";
            this.congan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // hanche
            // 
            this.hanche.Enabled = false;
            this.hanche.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hanche.Location = new System.Drawing.Point(152, 326);
            this.hanche.Name = "hanche";
            this.hanche.Size = new System.Drawing.Size(144, 16);
            this.hanche.TabIndex = 71;
            this.hanche.Text = "Há miệng hạn chế";
            this.hanche.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // label65
            // 
            this.label65.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label65.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label65.Location = new System.Drawing.Point(16, 326);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(144, 17);
            this.label65.TabIndex = 358;
            this.label65.Text = "2. Tiên lượng đặt NKQ :";
            this.label65.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label64
            // 
            this.label64.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label64.Location = new System.Drawing.Point(688, 304);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(32, 16);
            this.label64.TabIndex = 68;
            this.label64.Text = "cm";
            this.label64.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chieucao
            // 
            this.chieucao.BackColor = System.Drawing.SystemColors.HighlightText;
            this.chieucao.Enabled = false;
            this.chieucao.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chieucao.Location = new System.Drawing.Point(648, 301);
            this.chieucao.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.chieucao.MaxLength = 5;
            this.chieucao.Name = "chieucao";
            this.chieucao.Size = new System.Drawing.Size(40, 21);
            this.chieucao.TabIndex = 67;
            this.chieucao.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.chieucao.Validated += new System.EventHandler(this.chieucao_Validated);
            // 
            // label63
            // 
            this.label63.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label63.Location = new System.Drawing.Point(296, 304);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(24, 16);
            this.label63.TabIndex = 57;
            this.label63.Text = "T° :";
            this.label63.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nhietdo
            // 
            this.nhietdo.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nhietdo.Enabled = false;
            this.nhietdo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhietdo.Location = new System.Drawing.Point(320, 301);
            this.nhietdo.Mask = "##.##";
            this.nhietdo.Name = "nhietdo";
            this.nhietdo.Size = new System.Drawing.Size(32, 21);
            this.nhietdo.TabIndex = 58;
            this.nhietdo.Text = "  .  ";
            // 
            // huyetap
            // 
            this.huyetap.BackColor = System.Drawing.SystemColors.HighlightText;
            this.huyetap.Enabled = false;
            this.huyetap.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.huyetap.Location = new System.Drawing.Point(211, 301);
            this.huyetap.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.huyetap.MaxLength = 7;
            this.huyetap.Name = "huyetap";
            this.huyetap.Size = new System.Drawing.Size(45, 21);
            this.huyetap.TabIndex = 55;
            // 
            // nhiptho
            // 
            this.nhiptho.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nhiptho.Enabled = false;
            this.nhiptho.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhiptho.Location = new System.Drawing.Point(432, 301);
            this.nhiptho.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.nhiptho.MaxLength = 5;
            this.nhiptho.Name = "nhiptho";
            this.nhiptho.Size = new System.Drawing.Size(32, 21);
            this.nhiptho.TabIndex = 61;
            this.nhiptho.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cannang
            // 
            this.cannang.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cannang.Enabled = false;
            this.cannang.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cannang.Location = new System.Drawing.Point(552, 301);
            this.cannang.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
            this.cannang.MaxLength = 5;
            this.cannang.Name = "cannang";
            this.cannang.Size = new System.Drawing.Size(40, 21);
            this.cannang.TabIndex = 64;
            this.cannang.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.cannang.Validated += new System.EventHandler(this.cannang_Validated);
            // 
            // mach
            // 
            this.mach.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mach.Enabled = false;
            this.mach.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mach.Location = new System.Drawing.Point(112, 301);
            this.mach.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.mach.MaxLength = 5;
            this.mach.Name = "mach";
            this.mach.Size = new System.Drawing.Size(32, 21);
            this.mach.TabIndex = 52;
            this.mach.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label53
            // 
            this.label53.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label53.Location = new System.Drawing.Point(152, 301);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(24, 19);
            this.label53.TabIndex = 53;
            this.label53.Text = "l/p";
            this.label53.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label54
            // 
            this.label54.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label54.Location = new System.Drawing.Point(352, 305);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(24, 16);
            this.label54.TabIndex = 59;
            this.label54.Text = "°C";
            this.label54.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label55
            // 
            this.label55.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label55.Location = new System.Drawing.Point(256, 304);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(38, 16);
            this.label55.TabIndex = 56;
            this.label55.Text = "mmHg";
            this.label55.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label56
            // 
            this.label56.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label56.Location = new System.Drawing.Point(464, 304);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(24, 16);
            this.label56.TabIndex = 62;
            this.label56.Text = "l/p";
            this.label56.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label57
            // 
            this.label57.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label57.Location = new System.Drawing.Point(592, 304);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(24, 16);
            this.label57.TabIndex = 65;
            this.label57.Text = "Kg";
            this.label57.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label58
            // 
            this.label58.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label58.Location = new System.Drawing.Point(488, 304);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(64, 16);
            this.label58.TabIndex = 63;
            this.label58.Text = "Cân nặng :";
            this.label58.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label59
            // 
            this.label59.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label59.Location = new System.Drawing.Point(376, 304);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(56, 16);
            this.label59.TabIndex = 60;
            this.label59.Text = "Nhịp thở :";
            this.label59.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label60
            // 
            this.label60.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label60.Location = new System.Drawing.Point(179, 304);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(32, 16);
            this.label60.TabIndex = 54;
            this.label60.Text = "HA :";
            this.label60.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label61
            // 
            this.label61.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label61.Location = new System.Drawing.Point(616, 304);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(32, 16);
            this.label61.TabIndex = 66;
            this.label61.Text = "Cao :";
            this.label61.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label62
            // 
            this.label62.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label62.Location = new System.Drawing.Point(71, 304);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(40, 16);
            this.label62.TabIndex = 51;
            this.label62.Text = "Mạch :";
            this.label62.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // glasgow
            // 
            this.glasgow.BackColor = System.Drawing.SystemColors.HighlightText;
            this.glasgow.Enabled = false;
            this.glasgow.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.glasgow.Location = new System.Drawing.Point(552, 278);
            this.glasgow.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.glasgow.MaxLength = 5;
            this.glasgow.Name = "glasgow";
            this.glasgow.Size = new System.Drawing.Size(40, 21);
            this.glasgow.TabIndex = 48;
            this.glasgow.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label52
            // 
            this.label52.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label52.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label52.Location = new System.Drawing.Point(592, 281);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(32, 16);
            this.label52.TabIndex = 49;
            this.label52.Text = "điểm";
            this.label52.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label51
            // 
            this.label51.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label51.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label51.Location = new System.Drawing.Point(480, 285);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(72, 17);
            this.label51.TabIndex = 47;
            this.label51.Text = "Glasgow :";
            this.label51.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // khotho
            // 
            this.khotho.Enabled = false;
            this.khotho.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.khotho.Location = new System.Drawing.Point(424, 285);
            this.khotho.Name = "khotho";
            this.khotho.Size = new System.Drawing.Size(64, 16);
            this.khotho.TabIndex = 46;
            this.khotho.Text = "khó thở";
            this.khotho.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // yeu
            // 
            this.yeu.Enabled = false;
            this.yeu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yeu.Location = new System.Drawing.Point(360, 285);
            this.yeu.Name = "yeu";
            this.yeu.Size = new System.Drawing.Size(64, 16);
            this.yeu.TabIndex = 45;
            this.yeu.Text = "Yếu/liệt";
            this.yeu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // nhot
            // 
            this.nhot.Enabled = false;
            this.nhot.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhot.Location = new System.Drawing.Point(312, 285);
            this.nhot.Name = "nhot";
            this.nhot.Size = new System.Drawing.Size(48, 16);
            this.nhot.TabIndex = 44;
            this.nhot.Text = "nhợt";
            this.nhot.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // hong
            // 
            this.hong.Enabled = false;
            this.hong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hong.Location = new System.Drawing.Point(264, 285);
            this.hong.Name = "hong";
            this.hong.Size = new System.Drawing.Size(48, 16);
            this.hong.TabIndex = 43;
            this.hong.Text = "hồng";
            this.hong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // label50
            // 
            this.label50.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label50.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label50.Location = new System.Drawing.Point(208, 285);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(72, 17);
            this.label50.TabIndex = 42;
            this.label50.Text = "Da niêm :";
            this.label50.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // phu
            // 
            this.phu.Enabled = false;
            this.phu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phu.Location = new System.Drawing.Point(160, 285);
            this.phu.Name = "phu";
            this.phu.Size = new System.Drawing.Size(48, 16);
            this.phu.TabIndex = 41;
            this.phu.Text = "Phù";
            this.phu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // map
            // 
            this.map.Enabled = false;
            this.map.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.map.Location = new System.Drawing.Point(112, 285);
            this.map.Name = "map";
            this.map.Size = new System.Drawing.Size(48, 16);
            this.map.TabIndex = 40;
            this.map.Text = "Mập";
            this.map.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // label49
            // 
            this.label49.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label49.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label49.Location = new System.Drawing.Point(16, 285);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(88, 17);
            this.label49.TabIndex = 115;
            this.label49.Text = "1. Tổng trạng :";
            this.label49.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label48
            // 
            this.label48.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label48.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label48.Location = new System.Drawing.Point(128, 263);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(168, 16);
            this.label48.TabIndex = 114;
            this.label48.Text = "( Gạch chéo vào ô : □ nếu có )";
            this.label48.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label47
            // 
            this.label47.Font = new System.Drawing.Font("Tahoma", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label47.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label47.Location = new System.Drawing.Point(8, 263);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(120, 17);
            this.label47.TabIndex = 113;
            this.label47.Text = "KHÁM LÂM SÀNG :";
            this.label47.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chitiet
            // 
            this.chitiet.BackColor = System.Drawing.SystemColors.HighlightText;
            this.chitiet.Enabled = false;
            this.chitiet.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chitiet.Location = new System.Drawing.Point(91, 208);
            this.chitiet.Multiline = true;
            this.chitiet.Name = "chitiet";
            this.chitiet.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.chitiet.Size = new System.Drawing.Size(275, 30);
            this.chitiet.TabIndex = 39;
            // 
            // label46
            // 
            this.label46.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label46.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label46.Location = new System.Drawing.Point(5, 187);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(128, 17);
            this.label46.TabIndex = 111;
            this.label46.Text = "3. Trình bày chi tiết :";
            this.label46.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // giadinh
            // 
            this.giadinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.giadinh.Enabled = false;
            this.giadinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.giadinh.Location = new System.Drawing.Point(91, 131);
            this.giadinh.Multiline = true;
            this.giadinh.Name = "giadinh";
            this.giadinh.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.giadinh.Size = new System.Drawing.Size(275, 54);
            this.giadinh.TabIndex = 38;
            // 
            // label45
            // 
            this.label45.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label45.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label45.Location = new System.Drawing.Point(5, 131);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(80, 17);
            this.label45.TabIndex = 109;
            this.label45.Text = "2. Gia đình :";
            this.label45.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label36
            // 
            this.label36.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label36.Location = new System.Drawing.Point(16, 20);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(80, 17);
            this.label36.TabIndex = 62;
            this.label36.Text = "1. Cá nhân :";
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label35
            // 
            this.label35.Font = new System.Drawing.Font("Tahoma", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label35.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label35.Location = new System.Drawing.Point(8, 3);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(72, 17);
            this.label35.TabIndex = 61;
            this.label35.Text = "TIỀN CĂN :";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label44
            // 
            this.label44.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label44.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label44.Location = new System.Drawing.Point(45, 74);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(161, 15);
            this.label44.TabIndex = 103;
            this.label44.Text = "- Tiêu hóa :";
            this.label44.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label43
            // 
            this.label43.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label43.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label43.Location = new System.Drawing.Point(45, 74);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(161, 15);
            this.label43.TabIndex = 98;
            this.label43.Text = "- Tiết niệu :";
            this.label43.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label42
            // 
            this.label42.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label42.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label42.Location = new System.Drawing.Point(45, 74);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(161, 15);
            this.label42.TabIndex = 89;
            this.label42.Text = "- Thần kinh, Nội tiết, Huyết học :";
            this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label41
            // 
            this.label41.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label41.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label41.Location = new System.Drawing.Point(45, 74);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(161, 15);
            this.label41.TabIndex = 83;
            this.label41.Text = "- Hô hấp :";
            this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label40
            // 
            this.label40.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label40.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label40.Location = new System.Drawing.Point(45, 74);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(161, 15);
            this.label40.TabIndex = 77;
            this.label40.Text = "- Tim mạch :";
            this.label40.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label39
            // 
            this.label39.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label39.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label39.Location = new System.Drawing.Point(45, 74);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(161, 15);
            this.label39.TabIndex = 73;
            this.label39.Text = "- Thói quen :";
            this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label37
            // 
            this.label37.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label37.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label37.Location = new System.Drawing.Point(45, 74);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(161, 15);
            this.label37.TabIndex = 63;
            this.label37.Text = "- Mổ lần trước :";
            this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkXML
            // 
            this.chkXML.Location = new System.Drawing.Point(12, 536);
            this.chkXML.Name = "chkXML";
            this.chkXML.Size = new System.Drawing.Size(88, 16);
            this.chkXML.TabIndex = 7;
            this.chkXML.Text = "Xuất ra XML";
            // 
            // butLuu
            // 
            this.butLuu.Enabled = false;
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(71, 466);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 4;
            this.butLuu.Text = "     &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butIn
            // 
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(76, 495);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(65, 25);
            this.butIn.TabIndex = 5;
            this.butIn.Text = "   &In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Enabled = false;
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(141, 466);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(70, 25);
            this.butBoqua.TabIndex = 6;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // list
            // 
            this.list.BackColor = System.Drawing.SystemColors.Info;
            this.list.ColumnCount = 0;
            this.list.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.list.Location = new System.Drawing.Point(0, 2);
            this.list.MatchBufferTimeOut = 1000;
            this.list.MatchEntryStyle = AsYetUnnamedColor.MatchEntryStyle.FirstLetterInsensitive;
            this.list.Name = "list";
            this.list.Size = new System.Drawing.Size(208, 420);
            this.list.TabIndex = 13;
            this.list.TextIndex = -1;
            this.list.TextMember = null;
            this.toolTip1.SetToolTip(this.list, "F7 chọn");
            this.list.ValueIndex = -1;
            this.list.DoubleClick += new System.EventHandler(this.list_DoubleClick);
            this.list.KeyDown += new System.Windows.Forms.KeyEventHandler(this.list_KeyDown);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(140, 495);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(72, 25);
            this.butKetthuc.TabIndex = 8;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // chonin
            // 
            this.chonin.CheckOnClick = true;
            this.chonin.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chonin.Items.AddRange(new object[] {
            "Hội chẩn",
            "Khám tiền mê"});
            this.chonin.Location = new System.Drawing.Point(0, 426);
            this.chonin.Name = "chonin";
            this.chonin.Size = new System.Drawing.Size(208, 36);
            this.chonin.TabIndex = 12;
            // 
            // butMoi
            // 
            this.butMoi.Image = ((System.Drawing.Image)(resources.GetObject("butMoi.Image")));
            this.butMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMoi.Location = new System.Drawing.Point(1, 466);
            this.butMoi.Name = "butMoi";
            this.butMoi.Size = new System.Drawing.Size(70, 25);
            this.butMoi.TabIndex = 14;
            this.butMoi.Text = "     &Thêm";
            this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
            // 
            // butCls
            // 
            this.butCls.Image = ((System.Drawing.Image)(resources.GetObject("butCls.Image")));
            this.butCls.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butCls.Location = new System.Drawing.Point(1, 495);
            this.butCls.Name = "butCls";
            this.butCls.Size = new System.Drawing.Size(76, 25);
            this.butCls.TabIndex = 15;
            this.butCls.Text = "&Xem CLS";
            this.butCls.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butCls.Click += new System.EventHandler(this.butCls_Click);
            // 
            // frmHoichan
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(1016, 712);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.butCls);
            this.Controls.Add(this.butMoi);
            this.Controls.Add(this.list);
            this.Controls.Add(this.chonin);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.chkXML);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.label42);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.label41);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label37);
            this.Controls.Add(this.label39);
            this.Controls.Add(this.label40);
            this.Controls.Add(this.label43);
            this.Controls.Add(this.label44);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmHoichan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hội chẩn duyệt mổ";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmHoichan_KeyDown);
            this.Load += new System.EventHandler(this.frmHoichan_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void frmHoichan_Load(object sender, System.EventArgs e)
		{
			user=m.user;
            dsmau = m.get_data("select ma,ten,mapt,mabs,makp,noidung,mavp,image1,image2 from " + user + ".pttt_mau order by ma");
            dsmau.Merge(m.get_data("select mapt as ma,noi_dung as ten,mapt,'' as mabs,'' as makp,'' as noidung,cast(0 as numeric) as mavp,image1,image2 from " + user + ".dmpttt order by mapt"));
			ngayvv.Text=s_ngayvv;
			xxx=m.user+m.mmyy(s_ngayvv);
		
			list.DisplayMember="NGAY";
			list.ValueMember="ID";
			load_list();
			list.ColumnWidths[0]=80;
			list.ColumnWidths[1]=list.Width-80;

			listpttt.DisplayMember="TEN";
			listpttt.ValueMember="MA";
			listpttt.DataSource=dsmau.Tables[0];

			lmau.DisplayMember="TEN";
			lmau.ValueMember="MA";

			tenphuongphap.DisplayMember="TEN";
			tenphuongphap.ValueMember="MA";
            tenphuongphap.DataSource = m.get_data("select * from " + user + ".dmmete order by ma").Tables[0];

            dtbs = m.get_data("select * from " + user + ".dmbs where nhom not in (" + LibMedi.AccessData.nghiviec + ") order by ma").Tables[0];
			listBS.DisplayMember="MA";
			listBS.ValueMember="HOTEN";
			listBS.DataSource=dtbs;

			listBS1.DisplayMember="MA";
			listBS1.ValueMember="HOTEN";
            listBS1.DataSource = m.get_data("select * from " + user + ".dmbs where nhom not in (" + LibMedi.AccessData.nghiviec + ") order by ma").Tables[0];

			nhommau.DisplayMember="TEN";
			nhommau.ValueMember="MA";
            nhommau.DataSource = m.get_data("select * from " + user + ".dmnhommau order by ma").Tables[0];
			asa.SelectedIndex=0;glodmann.SelectedIndex=0;mallampati.SelectedIndex=0;			
			for(int i=0;i<chonin.Items.Count;i++) chonin.SetItemCheckState(i,CheckState.Checked);
			get_mabn(s_mabn);
		}

		private void load_list()
		{
			sql="select to_char(ngay,'dd/mm/yyyy') as ngay,to_char(ngaymo,'dd/mm/yyyy hh24:mi') as ngaymo,id from "+xxx+".ba_hoichan ";
			if (l_id!=0) sql+=" where id="+l_id;
			else sql+=" where idthuchien="+l_idthuchien;
			sql+=" order by ngay";
			list.DataSource=m.get_data(sql).Tables[0];
		}		

		private void mabn_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void tenbs_pass_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab) butLuu.Focus();
		}

		private void asa_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (asa.SelectedIndex==-1) asa.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void glodmann_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (glodmann.SelectedIndex==-1) glodmann.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void mallampati_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (mallampati.SelectedIndex==-1) mallampati.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void gan_text(string s,TextBox ma,TextBox ten)
		{
			if (s!="")
			{
				ma.Text=s;
				DataRow r=m.getrowbyid(dtbs,"ma='"+s+"'");
				if (r!=null) ten.Text=r["hoten"].ToString();
				else ten.Text="";
			}
			else 
			{
				ma.Text="";
				ten.Text="";
			}
		}

		private void ptdutru_Validated(object sender, System.EventArgs e)
		{
			gan_text(ptdutru.Text,ptdutru,tenptdutru);
		}

		private void ptchinh_Validated(object sender, System.EventArgs e)
		{
			gan_text(ptchinh.Text,ptchinh,tenptchinh);
		}

		private void ptphu_Validated(object sender, System.EventArgs e)
		{
			gan_text(ptphu.Text,ptphu,tenptphu);
		}

		private void giamdoc_Validated(object sender, System.EventArgs e)
		{
			gan_text(giamdoc.Text,giamdoc,tengiamdoc);
		}

		private void khth_Validated(object sender, System.EventArgs e)
		{
			gan_text(khth.Text,khth,tenkhth);
		}

		private void gayme_Validated(object sender, System.EventArgs e)
		{
			gan_text(gayme.Text,gayme,tengayme);
		}

		private void bstruongk_Validated(object sender, System.EventArgs e)
		{
			gan_text(bstruongk.Text,bstruongk,tenbstruongk);
		}

		private void ptv_Validated(object sender, System.EventArgs e)
		{
			gan_text(ptv.Text,ptv,tenptv);
		}

		private void mabs_Validated(object sender, System.EventArgs e)
		{
			gan_text(mabs.Text,mabs,tenbs);
		}

		private void tenptdutru_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listBS.Focus(); 
			else if (e.KeyCode==Keys.Enter)
			{
				if (listBS.Visible) listBS.Focus();
				else SendKeys.Send("{Tab}");
			}		
		}

		private void tenbs_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listBS1.Focus(); 
			else if (e.KeyCode==Keys.Enter)
			{
				if (listBS1.Visible) listBS1.Focus();
				else SendKeys.Send("{Tab}");
			}		
		}

		private void tenbs_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tenbs)
			{
				Filt_tenbs1(tenbs.Text);
				listBS1.BrowseToICD10(tenbs,mabs,tenbs_pass,mabs.Location.X,mabs.Location.Y+mabs.Height,mabs.Width+tenbs.Width+2,mabs.Height);
			}		
		}

		private void Filt_tenbs1(string ten)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listBS1.DataSource];
				DataView dv=(DataView)cm.List;
				dv.RowFilter="hoten like '%"+ten.Trim()+"%'";
			}
			catch{}
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

		private void tenptdutru_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tenptdutru)
			{
				Filt_tenbs(tenptdutru.Text);
				listBS.BrowseToICD10(tenptdutru,ptdutru,ptchinh,ptdutru.Location.X,ptdutru.Location.Y+ptdutru.Height,ptdutru.Width+tenptdutru.Width+2,ptdutru.Height);
			}				
		}

		private void tenptchinh_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tenptchinh)
			{
				Filt_tenbs(tenptchinh.Text);
				listBS.BrowseToICD10(tenptchinh,ptchinh,ptphu,ptchinh.Location.X,ptchinh.Location.Y+ptchinh.Height,ptchinh.Width+tenptchinh.Width+2,ptchinh.Height);
			}				
		}

		private void tenptphu_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tenptphu)
			{
				Filt_tenbs(tenptphu.Text);
				listBS.BrowseToICD10(tenptphu,ptphu,ngaymo,ptphu.Location.X,ptphu.Location.Y+ptphu.Height,ptphu.Width+tenptphu.Width+2,ptphu.Height);
			}				
		}

		private void tengiamdoc_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tengiamdoc)
			{
				Filt_tenbs(tengiamdoc.Text);
				listBS.BrowseToICD10(tengiamdoc,giamdoc,khth,giamdoc.Location.X,giamdoc.Location.Y+giamdoc.Height,giamdoc.Width+tengiamdoc.Width+2,giamdoc.Height);
			}				
		}

		private void tenkhth_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tenkhth)
			{
				Filt_tenbs(tenkhth.Text);
				listBS.BrowseToICD10(tenkhth,khth,gayme,khth.Location.X,khth.Location.Y+khth.Height,khth.Width+tenkhth.Width+2,khth.Height);
			}				
		}

		private void tengayme_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tengayme)
			{
				Filt_tenbs(tengayme.Text);
				listBS.BrowseToICD10(tengayme,gayme,bstruongk,gayme.Location.X,gayme.Location.Y+gayme.Height,gayme.Width+tengayme.Width+2,gayme.Height);
			}				
		}

		private void tenbstruongk_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tenbstruongk)
			{
				Filt_tenbs(tenbstruongk.Text);
				listBS.BrowseToICD10(tenbstruongk,bstruongk,ptv,bstruongk.Location.X,bstruongk.Location.Y+bstruongk.Height,bstruongk.Width+tenbstruongk.Width+2,bstruongk.Height);
			}						
		}

		private void tenptv_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tenptv)
			{
				Filt_tenbs(tenptv.Text);
				listBS.BrowseToICD10(tenptv,ptv,butLuu,ptv.Location.X,ptv.Location.Y+ptv.Height,ptv.Width+tenptv.Width+2,ptv.Height);
			}						
		}

		private void tenmau_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listpttt.Focus(); 
			else if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (listpttt.Visible)
				{
					listpttt.Focus();
					SendKeys.Send("{Up}");
				}
				else SendKeys.Send("{Tab}");
			}
		}

		private void load_mau(string ma)
		{
            dslmau = m.get_data("select ma,ten,mapt,mabs,makp,noidung,mavp from " + user + ".pttt_mau where ma like '%" + ma.Trim() + "%' order by ma");
            dslmau.Merge(m.get_data("select mapt as ma,noi_dung as ten,mapt,'' as mabs,'' as makp,'' as noidung,to_number('0') as mavp from " + user + ".dmpttt where mapt like '%" + ma.Trim() + "%' order by mapt"));
			lmau.DataSource=dslmau.Tables[0];
		}

		private void tenmau_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tenmau)
			{
				Filt_pttt(tenmau.Text);
				listpttt.BrowseToPTTT(tenmau,mamau,lmau,tenmau.Location.X,tenmau.Location.Y+tenmau.Height,tenmau.Width+lmau.Width,tenmau.Height);
			}
		}

		private void lmau_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (lmau.SelectedIndex==-1 && lmau.Items.Count>0) lmau.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void lmau_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==lmau)
			{
				DataRow r=m.getrowbyid(dslmau.Tables[0],"ma='"+lmau.SelectedValue.ToString()+"'");
				if (r!=null) tenmau.Text=r["ma"].ToString();
			}
		}

		private void mamau_Validated(object sender, System.EventArgs e)
		{
			if (mamau.Text!="")
			{
				DataRow r=m.getrowbyid(dsmau.Tables[0],"ma='"+mamau.Text+"'");
				if (r!=null)
				{
					load_mau(mamau.Text.Substring(0,6));
					lmau.SelectedValue=mamau.Text;
				}
			}
		}

		private void listpttt_Validated(object sender, System.EventArgs e)
		{
			mamau_Validated(sender,e);
		}

		private void frmHoichan_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.F3:
					if (butMoi.Enabled) butMoi_Click(sender,e);
					break;
				case Keys.F5:
					if (butLuu.Enabled) butLuu_Click(sender,e);
					break;
				case Keys.F7: if (list.Enabled) list_DoubleClick(sender,e);
					break;
				case Keys.F8:
					if (butBoqua.Enabled) butBoqua_Click(sender,e);
					break;
				case Keys.F9:
					if (butIn.Enabled) butIn_Click(sender,e);
					break;
				case Keys.F10:
					if (butKetthuc.Enabled) butKetthuc_Click(sender,e);
					break;
				case Keys.F12:
					if (butCls.Enabled) butCls_Click(sender,e);
					break;
			}		
		}

		private void Filt_pttt(string ten)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listpttt.DataSource];
				DataView dv=(DataView)cm.List;
				dv.RowFilter="ten LIKE '%"+ten.Trim()+"%' or ma like '%"+ten.Trim()+"%'";
			}
			catch{}
		}

		private void get_mabn(string _mabn)
		{
			emp_text();
			string m_tuoivao="",m_loaituoi="TU";
			sql=(l_duyet!=0)?"id="+l_id:"mabn='"+_mabn+"'";
			DataRow r=m.getrowbyid(ds.Tables[0],sql);
			if (r!=null)
			{
				mabn.Text=r["mabn"].ToString();
				hoten.Text=r["hoten"].ToString();
				m_tuoivao=r["tuoivao"].ToString();
				if (m_tuoivao.Length==4)
				{
					switch (int.Parse(m_tuoivao.Substring(3,1)))
					{
						case 0: m_loaituoi="TU";
							break;
						case 1: m_loaituoi="TH";
							break;
						case 2: m_loaituoi="NG";
							break;
						default: m_loaituoi="GI";
							break;
					}
				}
				if(m_tuoivao.Length>=3)tuoi.Text=m_tuoivao.Substring(0,3)+m_loaituoi;
                else tuoi.Text = m_tuoivao + m_loaituoi;
				phai.Text=(r["phai"].ToString()=="0")?"Nam":"Nữ";
                try { giuong.Text = r["giuong"].ToString(); }
                catch { }
				sothe.Text=r["sothe"].ToString();
				chandoan.Text=r["chandoan"].ToString();
                try { l_idkhoa = decimal.Parse(r["id"].ToString()); }
                catch { l_idkhoa = 0; }
				l_maql=decimal.Parse(r["maql"].ToString());
				s_sovaovien=r["sovaovien"].ToString();
				if (l_duyet!=0)
				{
					tenphuongphap.SelectedValue=r["phuongphap"].ToString();
					mamau.Text=r["mamau"].ToString();
					tenmau.Text=mamau.Text;
					ptttlich.Text=r["tenpt"].ToString();
					load_mau(mamau.Text.Substring(0,6));
					lmau.SelectedValue=mamau.Text;
					string _ngaymo=r["ngaymo"].ToString();
					ngaymo.Text=_ngaymo.Substring(0,10);
					giomo.Text=_ngaymo.Substring(11);
					gan_text(r["ptv"].ToString(),ptchinh,tenptchinh);
					gan_text(r["phu1"].ToString(),ptphu,tenptphu);
					tenmau.Focus();
				}
				else
				{
					decimal _id=m.get_idchung(ngayvv.Text,l_idthuchien);
					foreach(DataRow r1 in m.get_data("select * from "+xxx+".ba_kbdausinhton where id="+_id).Tables[0].Rows)
					{
						mach.Text=(r1["mach"].ToString()!="0")?r1["mach"].ToString():"";
						nhietdo.Text=(r1["nhietdo"].ToString()!="0")?r1["nhietdo"].ToString():"";
						huyetap.Text=r1["huyetap"].ToString();
						nhiptho.Text=(r1["nhiptho"].ToString()!="0")?r1["nhiptho"].ToString():"";
						cannang.Text=(r1["cannang"].ToString()!="0")?r1["cannang"].ToString():"";
						break;
					}
				}
				//load_data();
			}
		}

		private void emp_text()
		{
			string _ngay=m.ngayhienhanh_server;
			l_id=l_duyet;tenmau.Text="";mamau.Text="";lmau.SelectedIndex=-1;ptphu.Text="";tenptdutru.Text="";ptttlich.Text="";
			ptchinh.Text="";tenptchinh.Text="";ptphu.Text="";tenptphu.Text="";
			phuongphap.Text="";tenphuongphap.SelectedIndex=-1;ngaymo.Text=_ngay.Substring(0,10);giomo.Text=_ngay.Substring(11);
			tuthe.Text="";thoigian.Text="";sonde.Checked=false;nhommau.SelectedIndex=-1;rh.Checked=false;mau.Text="";
			rb0.Checked=false;rb1.Checked=false;rb2.Checked=false;rb3.Checked=false;rb4.Checked=false;rb5.Checked=false;
			rb6.Checked=false;rb7.Checked=false;rb8.Checked=false;rb9.Checked=false;rb10.Checked=false;rb11.Checked=false;
			rb12.Checked=false;rb13.Checked=false;rb14.Checked=false;rb15.Checked=false;rb16.Checked=false;rb17.Checked=false;
			rb18.Checked=false;rb19.Checked=false;rb20.Checked=false;rb21.Checked=false;rb22.Checked=false;rb23.Checked=false;
			rb24.Text="";rb25.Text="";rb26.Checked=false;rb27.Checked=false;xnkhac.Text="";
			xq.Checked=false;dungcu.Text="";khac.Text="";ykien.Text="";giamdoc.Text="";
			tengiamdoc.Text="";khth.Text="";tenkhth.Text="";gayme.Text="";tengayme.Text="";
			bstruongk.Text="";tenbstruongk.Text="";ptv.Text="";tenptv.Text="";ngay.Text=_ngay.Substring(0,10);
			ngaykham.Text=_ngay.Substring(0,10);mo.Text="";me.Checked=false;te.Checked=false;taibien.Checked=false;truyenmau.Checked=false;
			chkdiung.Checked=false;diung.Text="";bieuhien.Text="";thuocla.Checked=false;ruou.Checked=false;
			matuy.Checked=false;caoha.Checked=false;thatnguc.Checked=false;nmct.Checked=false;suytim.Checked=false;
			timbamsinh.Checked=false;lao.Checked=false;phequan.Checked=false;horamau.Checked=false;copd.Checked=false;
			hh_khac.Checked=false;tamthan.Checked=false;dongkinh.Checked=false;tbmmn.Checked=false;buouco.Checked=false;
			maukdong.Checked=false;tieuduong.Checked=false;hethong.Checked=false;tk_khac.Checked=false;cauthan.Checked=false;
			suythan.Checked=false;soithan.Checked=false;tn_khac.Checked=false;vangda.Checked=false;viemgan.Checked=false;
			tieuhoa.Checked=false;thuongvi.Checked=false;th_khac.Checked=false;giadinh.Text="";chitiet.Text="";
			map.Checked=false;phu.Checked=false;hong.Checked=false;nhot.Checked=false;yeu.Checked=false;khotho.Checked=false;
			glasgow.Text="";mach.Text="";huyetap.Text="";nhietdo.Text="";nhiptho.Text="";cannang.Text="";
			chieucao.Text="";hanche.Checked=false;congan.Checked=false;luoito.Checked=false;khoiu.Checked=false;
			giap.Checked=false;cungham.Checked=false;seo.Checked=false;ranggia.Checked=false;tl_khac.Text="";
			gu.Checked=false;cungcotsong.Checked=false;cs_bt.Checked=false;canlamsang.Text="";dieutri.Text="";cs_khac.Text="";
			denghi.Text="";asa.SelectedIndex=0;glodmann.SelectedIndex=0;mallampati.SelectedIndex=0;dukien.Text="";
			thuthuat.Text="";ketluan.Text="";mabs.Text="";tenbs.Text="";tenbs_pass.Text="";
			tinhmach.Text="";bmi.Text="";tm_bt.Checked=false;tm_cha.Checked=false;tm_dtn.Checked=false;tm_ln.Checked=false;
			tm_khac.Text="";hh_bt.Checked=false;hh_copd.Checked=false;hh_suyen.Checked=false;k_hh_khac.Text="";
			nt_bt.Checked=false;nt_bg.Checked=false;nt_td.Checked=false;nt_khac.Text="";tk_bt.Checked=false;tk_yeu.Checked=false;k_tk_khac.Text="";
			decimal _id=m.get_idchung(ngayvv.Text,l_idthuchien);
			foreach(DataRow r in m.get_data("select * from "+xxx+".ba_kbdausinhton where id="+_id).Tables[0].Rows)
			{
				mach.Text=(r["mach"].ToString()!="0")?r["mach"].ToString():"";
				nhietdo.Text=(r["nhietdo"].ToString()!="0")?r["nhietdo"].ToString():"";
				huyetap.Text=r["huyetap"].ToString();
				nhiptho.Text=(r["nhiptho"].ToString()!="0")?r["nhiptho"].ToString():"";
				cannang.Text=(r["cannang"].ToString()!="0")?r["cannang"].ToString():"";
				break;
			}
			ena_object(true);
		}

		private void ena_object(bool ena)
		{
			tenmau.Enabled=!ena;lmau.Enabled=!ena;ptdutru.Enabled=!ena;tenptdutru.Enabled=!ena;
			ptchinh.Enabled=!ena;tenptchinh.Enabled=!ena;ptphu.Enabled=!ena;tenptphu.Enabled=!ena;
			phuongphap.Enabled=!ena;tenphuongphap.Enabled=!ena;ngaymo.Enabled=!ena;giomo.Enabled=!ena;
			tuthe.Enabled=!ena;thoigian.Enabled=!ena;sonde.Enabled=!ena;nhommau.Enabled=!ena;rh.Enabled=!ena;mau.Enabled=!ena;
			rb0.Enabled=!ena;rb1.Enabled=!ena;rb2.Enabled=!ena;rb3.Enabled=!ena;rb4.Enabled=!ena;rb5.Enabled=!ena;
			rb6.Enabled=!ena;rb7.Enabled=!ena;rb8.Enabled=!ena;rb9.Enabled=!ena;rb10.Enabled=!ena;rb11.Enabled=!ena;
			rb12.Enabled=!ena;rb13.Enabled=!ena;rb14.Enabled=!ena;rb15.Enabled=!ena;rb16.Enabled=!ena;rb17.Enabled=!ena;
			rb18.Enabled=!ena;rb19.Enabled=!ena;rb20.Enabled=!ena;rb21.Enabled=!ena;rb22.Enabled=!ena;rb23.Enabled=!ena;
			rb24.Enabled=!ena;rb25.Enabled=!ena;rb26.Enabled=!ena;rb27.Enabled=!ena;xnkhac.Enabled=!ena;
			xq.Enabled=!ena;dungcu.Enabled=!ena;khac.Enabled=!ena;ykien.Enabled=!ena;giamdoc.Enabled=!ena;
			tengiamdoc.Enabled=!ena;khth.Enabled=!ena;tenkhth.Enabled=!ena;gayme.Enabled=!ena;tengayme.Enabled=!ena;
			bstruongk.Enabled=!ena;tenbstruongk.Enabled=!ena;ptv.Enabled=!ena;tenptv.Enabled=!ena;ngay.Enabled=!ena;
			ngaykham.Enabled=!ena;mo.Enabled=!ena;me.Enabled=!ena;te.Enabled=!ena;taibien.Enabled=!ena;truyenmau.Enabled=!ena;
			chkdiung.Enabled=!ena;//diung.Enabled=!ena;bieuhien.Enabled=!ena;
			thuocla.Enabled=!ena;ruou.Enabled=!ena;
			matuy.Enabled=!ena;caoha.Enabled=!ena;thatnguc.Enabled=!ena;nmct.Enabled=!ena;suytim.Enabled=!ena;
			timbamsinh.Enabled=!ena;lao.Enabled=!ena;phequan.Enabled=!ena;horamau.Enabled=!ena;copd.Enabled=!ena;
			hh_khac.Enabled=!ena;tamthan.Enabled=!ena;dongkinh.Enabled=!ena;tbmmn.Enabled=!ena;buouco.Enabled=!ena;
			maukdong.Enabled=!ena;tieuduong.Enabled=!ena;hethong.Enabled=!ena;tk_khac.Enabled=!ena;cauthan.Enabled=!ena;
			suythan.Enabled=!ena;soithan.Enabled=!ena;tn_khac.Enabled=!ena;vangda.Enabled=!ena;viemgan.Enabled=!ena;
			tieuhoa.Enabled=!ena;thuongvi.Enabled=!ena;th_khac.Enabled=!ena;giadinh.Enabled=!ena;chitiet.Enabled=!ena;
			map.Enabled=!ena;phu.Enabled=!ena;hong.Enabled=!ena;nhot.Enabled=!ena;yeu.Enabled=!ena;khotho.Enabled=!ena;
			glasgow.Enabled=!ena;mach.Enabled=!ena;huyetap.Enabled=!ena;nhietdo.Enabled=!ena;nhiptho.Enabled=!ena;cannang.Enabled=!ena;
			chieucao.Enabled=!ena;hanche.Enabled=!ena;congan.Enabled=!ena;luoito.Enabled=!ena;khoiu.Enabled=!ena;
			giap.Enabled=!ena;cungham.Enabled=!ena;seo.Enabled=!ena;ranggia.Enabled=!ena;tl_khac.Enabled=!ena;
			gu.Enabled=!ena;cungcotsong.Enabled=!ena;cs_bt.Enabled=!ena;cs_khac.Enabled=!ena;canlamsang.Enabled=!ena;dieutri.Enabled=!ena;
			denghi.Enabled=!ena;asa.Enabled=!ena;glodmann.Enabled=!ena;mallampati.Enabled=!ena;dukien.Enabled=!ena;
			thuthuat.Enabled=!ena;ketluan.Enabled=!ena;mabs.Enabled=!ena;tenbs.Enabled=!ena;tenbs_pass.Enabled=!ena;
			butKetthuc.Enabled=ena;butLuu.Enabled=!ena;butBoqua.Enabled=!ena;butIn.Enabled=ena;butMoi.Enabled=ena;list.Enabled=ena;
			tinhmach.Enabled=!ena;tm_bt.Enabled=!ena;tm_cha.Enabled=!ena;tm_dtn.Enabled=!ena;tm_ln.Enabled=!ena;butCls.Enabled=!ena;
			tm_khac.Enabled=!ena;hh_bt.Enabled=!ena;hh_copd.Enabled=!ena;hh_suyen.Enabled=!ena;k_hh_khac.Enabled=!ena;
			nt_bt.Enabled=!ena;nt_bg.Enabled=!ena;nt_td.Enabled=!ena;nt_khac.Enabled=!ena;tk_bt.Enabled=!ena;tk_yeu.Enabled=!ena;k_tk_khac.Enabled=!ena;

		}

		private void load_data()
		{
			Cursor=Cursors.WaitCursor;
			ena_object(false);
			l_idthuchien=m.get_idthuchien(s_ngayvv,l_idkhoa);
			if (l_idthuchien!=0)
			{
				foreach(DataRow r in m.get_data("select a.*,to_char(a.ngay,'dd/mm/yyyy') as ng,to_char(a.ngaymo,'dd/mm/yyyy hh24:mi') as ngmo from "+xxx+".ba_hoichan a where a.id="+l_id).Tables[0].Rows)
				{
					ngay.Text=r["ng"].ToString();
					ngaymo.Text=r["ngmo"].ToString().Substring(0,10);
					giomo.Text=r["ngmo"].ToString().Substring(11);
					mamau.Text=r["mamau"].ToString();
					tenmau.Text=mamau.Text;
					load_mau(mamau.Text.Substring(0,6));
					lmau.SelectedValue=mamau.Text;
					phuongphap.Text=r["phuongphap"].ToString().PadLeft(2,'0');
					tenphuongphap.SelectedValue=phuongphap.Text;
					gan_text(r["ptdutru"].ToString(),ptdutru,tenptdutru);
					gan_text(r["ptchinh"].ToString(),ptchinh,tenptchinh);
					gan_text(r["ptphu"].ToString(),ptphu,tenptphu);
					thoigian.Text=r["thoigian"].ToString();
					sonde.Checked=r["sonde"].ToString()=="1";
					nhommau.SelectedValue=r["nhommau"].ToString();
					rh.Checked=r["rh"].ToString()=="1";
					mau.Text=(r["mau"].ToString()!="0")?r["mau"].ToString():"";
					xnkhac.Text=r["xnkhac"].ToString();
					tuthe.Text=r["tuthe"].ToString();
					xq.Checked=r["xq"].ToString()=="1";
					dungcu.Text=r["dungcu"].ToString();
					khac.Text=r["khac"].ToString();
					ykien.Text=r["ykien"].ToString();
					gan_text(r["giamdoc"].ToString(),giamdoc,tengiamdoc);
					gan_text(r["khth"].ToString(),khth,tenkhth);
					gan_text(r["gayme"].ToString(),gayme,tengayme);
					gan_text(r["bstruongk"].ToString(),bstruongk,tenbstruongk);
					gan_text(r["ptv"].ToString(),ptv,tenptv);
				}
				DataTable tmp=m.get_data("select * from "+xxx+".ba_hoichanxn where id="+l_id).Tables[0];
				DataRow r1;
				string _name="";int so=0;
				foreach(System.Windows.Forms.Control t in this.tabControl1.Controls)
				{
					if (t.Name=="tabPage1")
					{
						foreach(System.Windows.Forms.Control c in t.Controls)
						{
							try
							{
								_name=c.Name.ToString();
								if (_name.Substring(0,2)=="rb")
								{
									so=int.Parse(_name.Substring(2));
									if (so==24 || so==25)
									{
										r1=m.getrowbyid(tmp,"ma="+so);										
										if (r1!=null)
										{
											TextBox txt=(TextBox)c;
											txt.Text=(r1["tinhtrang"].ToString()!="0")?r1["tinhtrang"].ToString():"";
										}
									}
									else
									{
										r1=m.getrowbyid(tmp,"ma="+so);										
										if (r1!=null)
										{
											CheckBox chk=(CheckBox)c;
											chk.Checked=r1["tinhtrang"].ToString()=="1";
										}
									}
								}
							}
							catch{}
						}
					}
				}

				foreach(DataRow r in m.get_data("select a.*,to_char(a.ngay,'dd/mm/yyyy') as ngaykham from "+xxx+".ba_khamtienme a where a.id="+l_id).Tables[0].Rows)
				{
					ngaykham.Text=r["ngaykham"].ToString();
					mo.Text=r["mo"].ToString();
					me.Checked=r["mete"].ToString()=="1";
					te.Checked=r["mete"].ToString()=="2";
					taibien.Checked=r["taibien"].ToString()=="1";
					truyenmau.Checked=r["truyenmau"].ToString()=="1";
					diung.Text=r["diung"].ToString();
					bieuhien.Text=r["bieuhien"].ToString();
					thuocla.Checked=r["thuocla"].ToString()=="1";
					ruou.Checked=r["ruou"].ToString()=="1";
					matuy.Checked=r["matuy"].ToString()=="1";
					caoha.Checked=r["caoha"].ToString()=="1";
					thatnguc.Checked=r["thatnguc"].ToString()=="1";
					nmct.Checked=r["nmct"].ToString()=="1";
					suytim.Checked=r["suytim"].ToString()=="1";
					timbamsinh.Checked=r["timbamsinh"].ToString()=="1";
					lao.Checked=r["lao"].ToString()=="1";
					phequan.Checked=r["phequan"].ToString()=="1";
					horamau.Checked=r["horamau"].ToString()=="1";
					copd.Checked=r["copd"].ToString()=="1";
					hh_khac.Checked=r["hh_khac"].ToString()=="1";
					tamthan.Checked=r["tamthan"].ToString()=="1";
					dongkinh.Checked=r["dongkinh"].ToString()=="1";
					tbmmn.Checked=r["tbmmn"].ToString()=="1";
					buouco.Checked=r["buouco"].ToString()=="1";
					maukdong.Checked=r["maukdong"].ToString()=="1";
					tieuduong.Checked=r["tieuduong"].ToString()=="1";
					hethong.Checked=r["hethong"].ToString()=="1";
					tk_khac.Checked=r["tk_khac"].ToString()=="1";
					cauthan.Checked=r["cauthan"].ToString()=="1";
					suythan.Checked=r["suythan"].ToString()=="1";
					soithan.Checked=r["soithan"].ToString()=="1";
					tn_khac.Checked=r["tn_khac"].ToString()=="1";
					vangda.Checked=r["vangda"].ToString()=="1";
					viemgan.Checked=r["viemgan"].ToString()=="1";
					tieuhoa.Checked=r["tieuhoa"].ToString()=="1";
					thuongvi.Checked=r["thuongvi"].ToString()=="1";
					th_khac.Checked=r["th_khac"].ToString()=="1";
					giadinh.Text=r["giadinh"].ToString();
					chitiet.Text=r["chitiet"].ToString();
					map.Checked=r["map"].ToString()=="1";
					phu.Checked=r["phu"].ToString()=="1";
					hong.Checked=r["hong"].ToString()=="1";
					nhot.Checked=r["nhot"].ToString()=="1";
					yeu.Checked=r["yeu"].ToString()=="1";
					khotho.Checked=r["khotho"].ToString()=="1";
					glasgow.Text=(r["glasgow"].ToString()!="0")?r["glasgow"].ToString():"";

					mach.Text=(r["mach"].ToString()!="0")?r["mach"].ToString():"";
					nhietdo.Text=(r["nhietdo"].ToString()!="0")?r["nhietdo"].ToString():"";
					huyetap.Text=r["huyetap"].ToString();
					nhiptho.Text=(r["nhiptho"].ToString()!="0")?r["nhiptho"].ToString():"";
					cannang.Text=(r["cannang"].ToString()!="0")?r["cannang"].ToString():"";
					chieucao.Text=(r["chieucao"].ToString()!="0")?r["chieucao"].ToString():"";
					tinh_bmi();
					hanche.Checked=r["hanche"].ToString()=="1";
					congan.Checked=r["congan"].ToString()=="1";
					luoito.Checked=r["luoito"].ToString()=="1";
					khoiu.Checked=r["khoiu"].ToString()=="1";
					giap.Checked=r["giap"].ToString()=="1";
					cungham.Checked=r["cungham"].ToString()=="1";
					seo.Checked=r["seo"].ToString()=="1";
					ranggia.Checked=r["ranggia"].ToString()=="1";
					tl_khac.Text=r["tl_khac"].ToString();
		
					tinhmach.Text=r["tinhmach"].ToString();
					tm_bt.Checked=r["tm_bt"].ToString()=="1";
					tm_cha.Checked=r["tm_cha"].ToString()=="1";
					tm_dtn.Checked=r["tm_dtn"].ToString()=="1";
					tm_ln.Checked=r["tm_ln"].ToString()=="1";
					tm_khac.Text=r["tm_khac"].ToString();
					hh_bt.Checked=r["hh_bt"].ToString()=="1";
					hh_copd.Checked=r["hh_copd"].ToString()=="1";
					hh_suyen.Checked=r["hh_suyen"].ToString()=="1";
					k_hh_khac.Text=r["k_hh_khac"].ToString();
					nt_bt.Checked=r["nt_bt"].ToString()=="1";
					nt_bg.Checked=r["nt_bg"].ToString()=="1";
					nt_td.Checked=r["nt_td"].ToString()=="1";
					nt_khac.Text=r["nt_khac"].ToString();
					tk_bt.Checked=r["tk_bt"].ToString()=="1";
					tk_yeu.Checked=r["tk_yeu"].ToString()=="1";
					k_tk_khac.Text=r["k_tk_khac"].ToString();

					gu.Checked=r["gu"].ToString()=="1";
					cungcotsong.Checked=r["cungcotsong"].ToString()=="1";
					cs_bt.Checked=r["cs_bt"].ToString()=="1";
					cs_khac.Text=r["cs_khac"].ToString();
					canlamsang.Text=r["canlamsang"].ToString();
					dieutri.Text=r["dieutri"].ToString();
					denghi.Text=r["denghi"].ToString();
					asa.Text=r["asa"].ToString();
					glodmann.Text=r["glodmann"].ToString();
					mallampati.Text=r["mallampati"].ToString();
					dukien.Text=r["dukien"].ToString();
					thuthuat.Text=r["thuthuat"].ToString();
					ketluan.Text=r["ketluan"].ToString();
					gan_text(r["mabs"].ToString(),mabs,tenbs);
					chkdiung.Checked=diung.Text!="";
					diung.Enabled=chkdiung.Checked;
					bieuhien.Enabled=chkdiung.Checked;
					if (mabs.Text!="")
					{
						r1=m.getrowbyid(dtbs,"ma='"+mabs.Text+"'");
						if (r1!=null) tenbs_pass.Text=r1["password_"].ToString();
					}
				}
			}
			Cursor=Cursors.Default;
		}

		private bool kiemtra()
		{
			if (ngay.Text=="")
			{
				ngay.Focus();return false;
			}
			if (ngaymo.Text=="")
			{
				ngaymo.Focus();return false;
			}
			if (giomo.Text=="")
			{
				giomo.Focus();return false;
			}
			if (ngaykham.Text=="")
			{
				ngaykham.Focus();return false;
			}
			if (tenmau.Text=="")
			{
				tenmau.Focus();return false;
			}
			if (lmau.SelectedIndex==-1)
			{
				lmau.Focus();return false;
			}
			if (tenphuongphap.SelectedIndex==-1)
			{
				tenphuongphap.Focus();return false;
			}
			if (nhommau.SelectedIndex==-1)
			{
				nhommau.Focus();return false;
			}
			if (mabs.Text!="" && tenbs.Text!="")
			{
				DataRow r=m.getrowbyid(dtbs,"ma='"+mabs.Text+"'");
				if (r==null)
				{
					MessageBox.Show(lan.Change_language_MessageText("Bác sĩ GMHS chưa hợp lệ !"),LibMedi.AccessData.Msg);
					mabs.Focus();
					return false;
				}
				if (!bAdmin)
				{
					if (tenbs_pass.Text!=r["password_"].ToString())
					{
						MessageBox.Show(
lan.Change_language_MessageText("Mật khẩu bác sĩ GMHS chưa hợp lệ !"),LibMedi.AccessData.Msg);
						tenbs_pass.Focus();
						return false;
					}
				}
			}
			return true;
		}
		private void butLuu_Click(object sender, System.EventArgs e)
		{
			if (!kiemtra()) return;
			l_idthuchien=m.get_idthuchien(ngayvv.Text,l_idkhoa);
			if (l_idthuchien==0) 
			{
				l_idthuchien=m.get_capid(-300);
				m.upd_ba_thuchien(ngayvv.Text,l_idthuchien,mabn.Text,l_maql,l_idkhoa,s_makp,"",giuong.Text,chandoan.Text);
			}
			if (l_id==0) l_id=m.get_capid(6);
			m.upd_ba_hoichan(ngayvv.Text,mabn.Text,l_id,l_idthuchien,ngay.Text,ngaymo.Text+" "+giomo.Text,tenmau.Text,lmau.Text,thoigian.Text,(sonde.Checked)?1:0,int.Parse(nhommau.SelectedValue.ToString()),(rh.Checked)?1:0,(mau.Text!="")?decimal.Parse(mau.Text):0,xnkhac.Text,ptdutru.Text,
				ptchinh.Text,ptphu.Text,int.Parse(tenphuongphap.SelectedValue.ToString()),tuthe.Text,(xq.Checked)?1:0,dungcu.Text,khac.Text,ykien.Text,giamdoc.Text,khth.Text,gayme.Text,bstruongk.Text,ptv.Text,i_userid);			
			string _name="";
			int so=0;
			foreach(System.Windows.Forms.Control t in this.tabControl1.Controls)
			{
				if (t.Name=="tabPage1")
				{
					foreach(System.Windows.Forms.Control c in t.Controls)
					{
						try
						{
							_name=c.Name.ToString();
							if (_name.Substring(0,2)=="rb")
							{
								so=int.Parse(_name.Substring(2));
								if (so==24 || so==25)
								{
									TextBox txt=(TextBox)c;
                                    m.upd_ba_hoichanxn(ngayvv.Text, mabn.Text, l_id, so, (txt.Text != "") ? int.Parse(txt.Text) : 0);
								}
								else
								{
									CheckBox chk=(CheckBox)c;
                                    m.upd_ba_hoichanxn(ngayvv.Text, mabn.Text, l_id, so, (chk.Checked) ? 1 : 0);
								}
							}
						}
						catch{}
					}
				}
			}
            m.upd_ba_khamtienme1(ngayvv.Text, mabn.Text, l_id, ngaykham.Text, mo.Text, (te.Checked) ? 1 : (me.Checked) ? 2 : 0, (taibien.Checked) ? 1 : 0, (truyenmau.Checked) ? 1 : 0,
				diung.Text,bieuhien.Text,(thuocla.Checked)?1:0,(ruou.Checked)?1:0,(matuy.Checked)?1:0,(caoha.Checked)?1:0,(thatnguc.Checked)?1:0,
				(nmct.Checked)?1:0,(suytim.Checked)?1:0,(timbamsinh.Checked)?1:0,(lao.Checked)?1:0,(phequan.Checked)?1:0,(horamau.Checked)?1:0,(copd.Checked)?1:0,(hh_khac.Checked)?1:0,
				(tamthan.Checked)?1:0,(dongkinh.Checked)?1:0,(tbmmn.Checked)?1:0,(buouco.Checked)?1:0,(maukdong.Checked)?1:0,(tieuduong.Checked)?1:0,(hethong.Checked)?1:0,
				(tk_khac.Checked)?1:0,(cauthan.Checked)?1:0,(suythan.Checked)?1:0);
            m.upd_ba_khamtienme2(ngayvv.Text, mabn.Text, l_id, (soithan.Checked) ? 1 : 0, (tn_khac.Checked) ? 1 : 0, (vangda.Checked) ? 1 : 0, (viemgan.Checked) ? 1 : 0,
				(tieuhoa.Checked)?1:0,(thuongvi.Checked)?1:0,(th_khac.Checked)?1:0,giadinh.Text,chitiet.Text,(map.Checked)?1:0,(phu.Checked)?1:0,
				(hong.Checked)?1:0,(nhot.Checked)?1:0,(yeu.Checked)?1:0,(khotho.Checked)?1:0,(glasgow.Text!="")?decimal.Parse(glasgow.Text):0,(mach.Text!="")?decimal.Parse(mach.Text):0,huyetap.Text,
				(nhietdo.Text!="")?decimal.Parse(nhietdo.Text):0,(nhiptho.Text!="")?decimal.Parse(nhiptho.Text):0,(cannang.Text!="")?decimal.Parse(cannang.Text):0,(chieucao.Text!="")?decimal.Parse(chieucao.Text):0,(hanche.Checked)?1:0,(congan.Checked)?1:0,(luoito.Checked)?1:0,
				(khoiu.Checked)?1:0,(giap.Checked)?1:0,(cungham.Checked)?1:0,(seo.Checked)?1:0,(ranggia.Checked)?1:0);
            m.upd_ba_khamtienme3(ngayvv.Text, mabn.Text, l_id, tl_khac.Text, 0, 0, 0, 0, 0, (gu.Checked) ? 1 : 0, (cungcotsong.Checked) ? 1 : 0, 0, canlamsang.Text,
				dieutri.Text,denghi.Text,asa.Text,glodmann.Text,mallampati.Text,dukien.Text,thuthuat.Text,ketluan.Text,mabs.Text);
            m.upd_ba_khamtienme4(ngayvv.Text, mabn.Text, l_id, tinhmach.Text, (tm_bt.Checked) ? 1 : 0, (tm_cha.Checked) ? 1 : 0, (tm_dtn.Checked) ? 1 : 0, (tm_ln.Checked) ? 1 : 0, tm_khac.Text, (hh_bt.Checked) ? 1 : 0, (hh_copd.Checked) ? 1 : 0, (hh_suyen.Checked) ? 1 : 0, k_hh_khac.Text, (nt_bt.Checked) ? 1 : 0, (nt_bg.Checked) ? 1 : 0, (nt_td.Checked) ? 1 : 0, nt_khac.Text, (tk_bt.Checked) ? 1 : 0, (tk_yeu.Checked) ? 1 : 0, k_tk_khac.Text, (cs_bt.Checked) ? 1 : 0, cs_khac.Text);
			load_list();
			bUpdate=true;
			ena_object(true);
			butIn.Focus();
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			ena_object(true);
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			for(int i=0;i<chonin.Items.Count;i++)
				if (chonin.GetItemChecked(i)) page(i);
		}

		private void page(int loai)
		{
			switch (loai)
			{
				case 0: page_1();break;
				case 1: page_2();break;
			}
		}

        private void page_1()
        {
            DataSet dsxml = new DataSet();
            sql = "select '' as mabn,'' as hoten,'' as sovaovien,'' as chandoan,'' as tuoi,'' phai,";
            sql += "a.ptdutru,a.ptchinh,a.ptphu,a.giamdoc,a.khth,a.gayme,a.bstruongk,a.ptv,to_char(a.ngaymo,'dd/mm/yyyy hh24:mi') as ngaymo,";
            sql += "to_char(a.ngay,'dd/mm/yyyy') as ngay,a.tuthe,a.thoigian,'' as phuongphap,a.sonde,'' as nhommau,a.rh,a.mau,";
            sql += "0 as c0,0 as c1,0 as c2,0 as c3,0 as c4,0 as c5,0 as c6,0 as c7,0 as c8,0 as c9,0 as c10,";
            sql += "0 as c11,0 as c12,0 as c13,0 as c14,0 as c15,0 as c16,0 as c17,0 as c18,0 as c19,0 as c20,";
            sql += "0 as c21,0 as c22,0 as c23,0 as c24,0 as c25,0 as c26,0 as c27,";
            sql += "a.xnkhac,a.xq,a.dungcu,a.khac,a.ykien,";
            sql += "'' as igiamdoc,'' as ikhth,'' as igayme,'' as ibstruongk,'' as iptv,";//b.image,c.image,d.image,e.image,f.image
            sql += " '' as image1,'' as image2 ";//g.image1,g.image2
            sql += " from " + user + m.mmyy(ngayvv.Text) + ".ba_hoichan a left join " + user + ".dmbs b on a.giamdoc=b.ma";
            sql += " left join " + user + ".dmbs c on a.khth=c.ma left join " + user + ".dmbs d on a.gayme=d.ma";
            sql += " left join " + user + ".dmbs e on a.bstruongk=e.ma left join " + user + ".dmbs f on a.ptv=f.ma";
            sql += " left join " + user + ".pttt_mau g on a.mamau=g.ma";
            sql += " where a.id=" + l_id;
            dsxml = m.get_data(sql);
            foreach (DataRow r in dsxml.Tables[0].Rows)
            {
                r["mabn"] = mabn.Text; r["hoten"] = hoten.Text; r["sovaovien"] = s_sovaovien; r["chandoan"] = chandoan.Text; r["tuoi"] = tuoi.Text; r["phai"] = phai.Text;
                r["ptdutru"] = tenptdutru.Text; r["ptchinh"] = tenptchinh.Text; r["ptphu"] = tenptphu.Text; r["phuongphap"] = tenphuongphap.Text; r["nhommau"] = nhommau.Text;
                r["c0"] = (rb0.Checked) ? 1 : 0; r["c1"] = (rb1.Checked) ? 1 : 0; r["c2"] = (rb2.Checked) ? 1 : 0; r["c3"] = (rb3.Checked) ? 1 : 0; r["c4"] = (rb4.Checked) ? 1 : 0;
                r["c5"] = (rb5.Checked) ? 1 : 0; r["c6"] = (rb6.Checked) ? 1 : 0; r["c7"] = (rb7.Checked) ? 1 : 0; r["c8"] = (rb8.Checked) ? 1 : 0;
                r["c9"] = (rb9.Checked) ? 1 : 0; r["c10"] = (rb10.Checked) ? 1 : 0; r["c11"] = (rb11.Checked) ? 1 : 0; r["c12"] = (rb12.Checked) ? 1 : 0;
                r["c13"] = (rb13.Checked) ? 1 : 0; r["c14"] = (rb14.Checked) ? 1 : 0; r["c15"] = (rb15.Checked) ? 1 : 0; r["c16"] = (rb16.Checked) ? 1 : 0;
                r["c17"] = (rb17.Checked) ? 1 : 0; r["c17"] = (rb17.Checked) ? 1 : 0; r["c18"] = (rb18.Checked) ? 1 : 0; r["c19"] = (rb19.Checked) ? 1 : 0;
                r["c20"] = (rb20.Checked) ? 1 : 0; r["c21"] = (rb21.Checked) ? 1 : 0; r["c22"] = (rb22.Checked) ? 1 : 0; r["c23"] = (rb23.Checked) ? 1 : 0;
                r["c24"] = (rb24.Text != "") ? decimal.Parse(rb24.Text) : 0; r["c25"] = (rb25.Text != "") ? decimal.Parse(rb25.Text) : 0; r["c26"] = (rb26.Checked) ? 1 : 0; r["c27"] = (rb27.Checked) ? 1 : 0;
                r["giamdoc"] = tengiamdoc.Text; r["khth"] = tenkhth.Text; r["bstruongk"] = tenbstruongk.Text; r["ptv"] = tenptv.Text; r["gayme"] = tengayme.Text;
            }

            if (dsxml.Tables[0].Rows.Count > 0)
            {
                if (chkXML.Checked)
                {
                    if (!System.IO.Directory.Exists("..\\xml")) System.IO.Directory.CreateDirectory("..\\xml");
                    dsxml.WriteXml("..\\xml\\hoichan.xml", XmlWriteMode.WriteSchema);
                }
                dllReportM.frmReport f = new dllReportM.frmReport(m, dsxml, s_tenkp, "rHoichan.rpt");
                f.ShowDialog();
            }
        }
        private void page_2()
        {
            DataSet dsxml = new DataSet();
            sql = "select a.*,to_char(a.ngay,'dd/mm/yyyy') as ngaykham,b.hoten as tenbs,'' as image ";
            sql += " from " + user + m.mmyy(ngayvv.Text) + ".ba_khamtienme a left join " + user + ".dmbs b on a.mabs=b.ma";
            sql += " where a.id=" + l_id;
            dsxml = m.get_data(sql);
            if (dsxml.Tables[0].Rows.Count > 0)
            {
                if (chkXML.Checked)
                {
                    if (!System.IO.Directory.Exists("..\\xml")) System.IO.Directory.CreateDirectory("..\\xml");
                    dsxml.WriteXml("..\\xml\\khamtienme.xml", XmlWriteMode.WriteSchema);
                }
                dllReportM.frmReport f = new dllReportM.frmReport(m, dsxml, "", "rKhamtienme.rpt");
                f.ShowDialog();
            }
        }

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void tenphuongphap_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				phuongphap.Text=tenphuongphap.SelectedValue.ToString();
			}
			catch{}
		}

		private void tenphuongphap_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				if (tenphuongphap.SelectedIndex==-1) tenphuongphap.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void phuongphap_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{F4}");
		}

		private void phuongphap_Validated(object sender, System.EventArgs e)
		{
			try
			{
				tenphuongphap.SelectedValue=phuongphap.Text;
			}
			catch{}
		}

		private void ngaymo_Validated(object sender, System.EventArgs e)
		{
			ngaymo.Text=ngaymo.Text.Trim();
			if (ngaymo.Text.Length==6) ngaymo.Text=ngaymo.Text+DateTime.Now.Year.ToString();
			if (!m.bNgay(ngaymo.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"));
				ngaymo.Focus();
				return;
			}
		}

		private void ngay_Validated(object sender, System.EventArgs e)
		{
			ngay.Text=ngay.Text.Trim();
			if (ngay.Text.Length==6) ngay.Text=ngay.Text+DateTime.Now.Year.ToString();
			if (!m.bNgay(ngay.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"));
				ngay.Focus();
				return;
			}
		}

		private void ngaykham_Validated(object sender, System.EventArgs e)
		{
			ngaykham.Text=ngaykham.Text.Trim();
			if (ngaykham.Text.Length==6) ngaykham.Text=ngaykham.Text+DateTime.Now.Year.ToString();
			if (!m.bNgay(ngaykham.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"));
				ngaykham.Focus();
				return;
			}
		}

		private void giomo_Validated(object sender, System.EventArgs e)
		{
			string sgio=(giomo.Text.Trim()=="")?"00:00":giomo.Text.Trim();
			giomo.Text=sgio.Substring(0,2).PadLeft(2,'0')+":"+sgio.Substring(3).Trim().PadRight(2,'0');
			if (!m.bGio(giomo.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Giờ không hợp lệ !"));
				giomo.Focus();
				return;
			}
		}

		private void nhommau_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (nhommau.SelectedIndex==-1 && nhommau.Items.Count>0) nhommau.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void chkdiung_CheckedChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==chkdiung)
			{
				diung.Enabled=chkdiung.Checked;
				bieuhien.Enabled=diung.Enabled;
				if (!chkdiung.Checked)
				{
					diung.Text="";bieuhien.Text="";
				}
			}
		}

		private void list_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				l_id=(list.SelectedIndex!=-1)?decimal.Parse(list.SelectedValue.ToString()):0;
				load_data();
			}
		}

		private void list_DoubleClick(object sender, System.EventArgs e)
		{
			l_id=(list.SelectedIndex!=-1)?decimal.Parse(list.SelectedValue.ToString()):0;
			load_data();
		}

		private void butMoi_Click(object sender, System.EventArgs e)
		{
			get_mabn(s_mabn);
			ena_object(false);
		}

		private void tinh_bmi()
		{
			decimal cn=(cannang.Text!="")?decimal.Parse(cannang.Text):0;
			decimal cc=(chieucao.Text!="")?decimal.Parse(chieucao.Text):0;
			decimal _bmi=0;
			if (cn!=0 && cc!=0) _bmi=(cn*1000)/(cc*cc);
			else _bmi=0;
			bmi.Text=_bmi.ToString("####0.00");
		}

		private void cannang_Validated(object sender, System.EventArgs e)
		{
			tinh_bmi();
		}

		private void chieucao_Validated(object sender, System.EventArgs e)
		{
			tinh_bmi();
		}

		private void tm_bt_CheckedChanged(object sender, System.EventArgs e)
		{
			tm_cha.Enabled=!tm_bt.Checked;
			tm_dtn.Enabled=tm_cha.Enabled;
			tm_ln.Enabled=tm_cha.Enabled;
			tm_khac.Enabled=tm_cha.Enabled;
		}

		private void hh_bt_CheckedChanged(object sender, System.EventArgs e)
		{
			hh_copd.Enabled=!hh_bt.Checked;
			hh_suyen.Enabled=hh_copd.Enabled;
			k_hh_khac.Enabled=hh_copd.Enabled;
		}

		private void nt_bt_CheckedChanged(object sender, System.EventArgs e)
		{
			nt_bg.Enabled=!nt_bt.Checked;
			nt_td.Enabled=nt_bg.Enabled;
			nt_khac.Enabled=nt_bg.Enabled;
		}

		private void tk_bt_CheckedChanged(object sender, System.EventArgs e)
		{
			tk_yeu.Enabled=!tk_bt.Checked;
			k_tk_khac.Enabled=tk_yeu.Enabled;
		}

		private void cs_bt_CheckedChanged(object sender, System.EventArgs e)
		{
			gu.Enabled=!cs_bt.Checked;
			cungcotsong.Enabled=gu.Enabled;
			cs_khac.Enabled=gu.Enabled;
		}

		private void butCls_Click(object sender, System.EventArgs e)
		{
			if (mabn.Text=="" || hoten.Text=="") return;
			frmCanlamsan.frmXemCanLamSan_medi f=new frmCanlamsan.frmXemCanLamSan_medi(mabn.Text,hoten.Text,tuoi.Text,"");
			f.ShowDialog(this);		
		}
	}
}
