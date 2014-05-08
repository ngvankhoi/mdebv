using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using LibMedi;
using LibDuoc;
using LibVienphi;

namespace Medisoft
{
	public class frmPttt : System.Windows.Forms.Form
    {
        #region Khai bao
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.TreeView treeView1;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.TextBox hoten;
		private MaskedTextBox.MaskedTextBox mabn2;
		private System.Windows.Forms.TextBox tuoi;
		private System.Windows.Forms.TextBox phai;
		private System.Windows.Forms.TextBox diachi;
		private System.Windows.Forms.TextBox sothe;
		private System.Windows.Forms.TextBox giuong;
		private System.Windows.Forms.ComboBox tenkp;
		private System.Windows.Forms.TextBox makp;
		private System.Windows.Forms.ComboBox loaipt;
		private System.Windows.Forms.TextBox phuongphap;
		private System.Windows.Forms.ComboBox tenphuongphap;
		private System.Windows.Forms.TextBox mabs;
		private System.Windows.Forms.ComboBox taibien;
		private System.Windows.Forms.ComboBox tuvong;
		private System.Windows.Forms.Button butMoi;
		private System.Windows.Forms.Button butSua;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.TextBox icd_vk;
		private System.Windows.Forms.TextBox cd_vk;
		private MaskedTextBox.MaskedTextBox icd_t;
		private MaskedTextBox.MaskedTextBox mapt;
		private LibMedi.AccessData m;
		private LibDuoc.AccessData d=new LibDuoc.AccessData();
		private LibVienphi.AccessData v=new LibVienphi.AccessData();
        private string nam, user, m_makp, m_mabn, m_hoten, m_tuoi, m_phai, m_diachi, m_sothe, s_msg, m_loaipt, m_ngayra, FileType, s_nhomvp_pttt;
		private string s_mabn,m_tuoivao,m_loaituoi,m_giuong,m_ngayvv,m_cd_vk,m_icd_vk,s_ngay,s_nhomkho="";
        private int m_userid, songay, i_loaibn, i_traituyen=0,i_khudt=0;
		private System.Windows.Forms.ComboBox tinhhinh;
        private decimal l_maql, l_id, l_idvpkhoa, l_idkhoa, l_idduoc, l_mavaovien, p_maql, p_mavaovien, p_idkhoa, l_idchidinh, l_duyet;
		private System.Windows.Forms.TextBox sophieu;
        private bool bStatus = false, b_bacsi, bAdmin, bPttt_pmo, bMat, bPttt_vp, bPTTT_Xuatvien, bPttt_thuoc, bEdit_vp, bTiepdon_pttt, bSophieu, bHoisuc, bChandoan, bCapso, bChidinh, bThuthuat = false, bPttt_tsoduoc, bQuanly_Theo_Chinhanh=false,bPhauthuat = false;
		private MaskedTextBox.MaskedTextBox icd_s;
		private LibList.List listpttt;
		private System.Windows.Forms.TextBox tenpt;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Button butPttt;
		private System.ComponentModel.IContainer components;
        private string s_icd_t = "", s_icd_s = "", sql, s_makp, s_madoituong, pathImage, i_nhomvp ="";
		private System.Windows.Forms.TextBox cd_t;
		private System.Windows.Forms.TextBox cd_s;
		private LibList.List listICD;
		private DataTable dticd=new DataTable();
		private LibList.List listBS;
        private int i_idcn = 0;
		private DataTable dtpt=new DataTable();
        
        private DataTable dtIcdt = new DataTable();
        
        private DataTable dtIcds = new DataTable();
        
        private DataTable dtPhuongPhap = new DataTable();

        private DataTable dtptpp = new DataTable();

		private DataSet dsmau=new DataSet();
		private DataTable dtvp=new DataTable();
		private DataTable dtmavp=new DataTable();
		private DataTable dtduockp=new DataTable();
		private DataSet dslmau=new DataSet();
        private DataSet dsngay = new DataSet();
		private System.Windows.Forms.TextBox tenbs;
		private System.Windows.Forms.Label label11;
		private MaskedBox.MaskedBox nhietdo;
		private MaskedTextBox.MaskedTextBox huyetap;
		private MaskedTextBox.MaskedTextBox mach;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.Label label28;
		private System.Windows.Forms.Label label29;
		private System.Windows.Forms.Label label30;
		private System.Windows.Forms.Label label31;
		private System.Windows.Forms.Label label32;
		private System.Windows.Forms.Label label33;
		private System.Windows.Forms.Label label34;
		private System.Windows.Forms.TextBox phu1;
		private System.Windows.Forms.TextBox tenphu1;
		private System.Windows.Forms.TextBox tenphu2;
		private System.Windows.Forms.TextBox phu2;
		private System.Windows.Forms.TextBox tenktvgayme;
		private System.Windows.Forms.TextBox ktvgayme;
		private System.Windows.Forms.TextBox tenbsgayme;
		private System.Windows.Forms.TextBox bsgayme;
		private System.Windows.Forms.TextBox tendungcu;
		private System.Windows.Forms.TextBox dungcu;
		private System.Windows.Forms.TextBox tenhoisuc;
		private System.Windows.Forms.TextBox hoisuc;
		private System.Windows.Forms.Label label35;
		private MaskedTextBox.MaskedTextBox mamau;
		private System.Windows.Forms.TextBox tenmau;
		private System.Windows.Forms.CheckBox chktuongtrinh;
		private System.Windows.Forms.ComboBox mautuongtrinh;
		private System.Windows.Forms.CheckBox butTuongtrinh;
		private System.Windows.Forms.TextBox noidung; 
		private DataTable dtbs=new DataTable();
        private DataTable dtlist = new DataTable();
		private System.Windows.Forms.Label label36;
		private System.Windows.Forms.ComboBox loaibn;
		private System.Windows.Forms.Label label37;
		private System.Windows.Forms.Label lmat;
		private System.Windows.Forms.ComboBox mapmo;
		private System.Windows.Forms.NumericUpDown somat;
		private DataSet dsxml=new DataSet();
		private DataSet dsloaibn=new DataSet();
		private DataTable dtpm=new DataTable();
        private DataTable dttt = new DataTable();
		private System.Windows.Forms.CheckBox molaimien;
		private System.Windows.Forms.Button butHuy;
		private System.Windows.Forms.Button butKetthuc;
		private System.Windows.Forms.Label label38;
		private System.Windows.Forms.ComboBox loaivp;
		private System.Windows.Forms.TextBox sotien;
		private System.Windows.Forms.ComboBox mavp;
		private System.Windows.Forms.Button butThuoc;
		private System.Windows.Forms.ComboBox madoituong;
		private System.Windows.Forms.Label label39;
		private System.Windows.Forms.TextBox mabn3;
		private MaskedBox.MaskedBox ngay;
		private MaskedBox.MaskedBox ngaykt;
		private MaskedBox.MaskedBox gio;
		private MaskedBox.MaskedBox giokt;
		private System.Windows.Forms.ComboBox lmau;
		private System.Windows.Forms.TextBox tenpttt;
		private System.Windows.Forms.Label label40;
		private System.Windows.Forms.Label label41;
		private MaskedBox.MaskedBox giovv;
		private MaskedBox.MaskedBox ngayvv;
		private System.Windows.Forms.CheckBox chkXem;
		private DataTable dtkp=new DataTable();
        private CheckBox noisoi;
        private Button butThem;
        private Panel p;
        private Button butCancel;
        private Button butOk;
        private TextBox tim;
        private DataGrid dataGrid1;
        private Brush disabledBackBrush;
        private Brush disabledTextBrush;
        private Brush alertBackBrush;
        private Font alertFont;
        private Brush alertTextBrush;
        private Font currentRowFont;
        private Brush currentRowBackBrush;
        bool afterCurrentCellChanged;
        int checkCol = 0;
        private Label label42;
        private ComboBox ngayvao;
        private PictureBox pic;
        private byte[] image;
        private System.IO.MemoryStream memo;
        private System.IO.FileStream fstr;
        private Bitmap map;
        private Button butNhanvien;
        private GroupBox danhsach;
        private AsYetUnnamed.MultiColumnListBox list;
        private Label lblso;
        private TextBox textBox1;
        private Button butRef;
        private CheckBox chkXml;
        private Button butHinh;
        private dllReportM.Print print = new dllReportM.Print();
        private string makho, manguon, ngay_thuoc, mmyy_thuoc, _tu, _den;
        private int nhom, kp, loai, phieu, makhoa, i_maxlength_mabn = 8;
        private RadioButton rdtatca;
        private RadioButton rdphauthuat;
        private MaskedTextBox.MaskedTextBox stgiam;
        private MaskedTextBox.MaskedTextBox tylegiam;
        private Label label43;
        private Label label44;
        private Label label45;
        private RadioButton rdtt;
        private Button butThemcdT;
        private Button butThemPP;
        private Button butThemcdS;
        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButton2;
        private ToolStripButton toolStripButton1;
        private ComboBox cmbNhomMau;
        private Label label46;
        private Label label47;
        private Label label48;
        private Label lblTenkythuat;
        private bool bbadt = false;
        #endregion

        public frmPttt(LibMedi.AccessData acc, string makp, string mabn, string hoten, string tuoi, string phai, string diachi, string sothe, string giuong, string ngayvv, string cd_vk, string icd_vk, string loaipt, int userid, string ngayra, string _makp, string _madoituong, decimal _maql, decimal _mavaovien, decimal _idkhoa, int _loaibn, bool thuthuat)
        {
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            m_makp = makp; m_mabn = mabn; m_hoten = hoten; m_tuoi = tuoi; m_phai = phai; m_diachi = diachi; m_sothe = sothe;
            m_giuong = giuong; m_ngayvv = ngayvv; m_cd_vk = cd_vk; m_icd_vk = icd_vk; m_userid = userid;
            m = acc; s_makp = _makp; s_madoituong = _madoituong; m_loaipt = loaipt; m_ngayra = ngayra; i_loaibn = _loaibn;
            if (m.bBogo) tv.GanBogo(this, textBox111);
            if (m_tuoi.Length == 4)
            {
                switch (int.Parse(m_tuoi.Substring(3, 1)))
                {
                    case 0: m_loaituoi = "TU";
                        break;
                    case 1: m_loaituoi = "TH";
                        break;
                    case 2: m_loaituoi = "NG";
                        break;
                    default: m_loaituoi = "GI";
                        break;
                }
                m_tuoi = m_tuoi.Substring(0, 3) + m_loaituoi;
            }
            p_maql = _maql; p_mavaovien = _mavaovien; p_idkhoa = _idkhoa; bThuthuat = thuthuat;
            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
        //ThanhCuong - 06/08/2012 - Kỹ thuật cao
        public frmPttt(LibMedi.AccessData acc, string makp, string mabn, string hoten, string tuoi, string phai, string diachi, string sothe, string giuong, string ngayvv, string cd_vk, string icd_vk, string loaipt, int userid, string ngayra, string _makp, string _madoituong, decimal _maql, decimal _mavaovien, decimal _idkhoa, int _loaibn, bool thuthuat,string _nhomkho,int _khudt)
        {
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            m_makp = makp; m_mabn = mabn; m_hoten = hoten; m_tuoi = tuoi; m_phai = phai; m_diachi = diachi; m_sothe = sothe;
            m_giuong = giuong; m_ngayvv = ngayvv; m_cd_vk = cd_vk; m_icd_vk = icd_vk; m_userid = userid;
            m = acc; s_makp = _makp; s_madoituong = _madoituong; m_loaipt = loaipt; m_ngayra = ngayra; i_loaibn = _loaibn; s_nhomkho = _nhomkho; i_khudt = _khudt;
            if (m.bBogo) tv.GanBogo(this, textBox111);
            if (m_tuoi.Length == 4)
            {
                switch (int.Parse(m_tuoi.Substring(3, 1)))
                {
                    case 0: m_loaituoi = "TU";
                        break;
                    case 1: m_loaituoi = "TH";
                        break;
                    case 2: m_loaituoi = "NG";
                        break;
                    default: m_loaituoi = "GI";
                        break;
                }
                m_tuoi = m_tuoi.Substring(0, 3) + m_loaituoi;
            }
            p_maql = _maql; p_mavaovien = _mavaovien; p_idkhoa = _idkhoa; bThuthuat = thuthuat;
            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
        //End

        //Tu:25/05/2011
        public frmPttt(LibMedi.AccessData acc, string makp, string mabn, string hoten, string tuoi, string phai, string diachi, string sothe, string giuong, string ngayvv, string cd_vk, string icd_vk, string loaipt, int userid, string ngayra, string _makp, string _madoituong, decimal _maql, decimal _mavaovien, decimal _idkhoa, int _loaibn, bool thuthuat,bool _badt)
        {
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            m_makp = makp; m_mabn = mabn; m_hoten = hoten; m_tuoi = tuoi; m_phai = phai; m_diachi = diachi; m_sothe = sothe;
            m_giuong = giuong; m_ngayvv = ngayvv; m_cd_vk = cd_vk; m_icd_vk = icd_vk; m_userid = userid;
            m = acc; s_makp = _makp; s_madoituong = _madoituong; m_loaipt = loaipt; m_ngayra = ngayra; i_loaibn = _loaibn;
            if (m.bBogo) tv.GanBogo(this, textBox111);
            if (m_tuoi.Length == 4)
            {
                switch (int.Parse(m_tuoi.Substring(3, 1)))
                {
                    case 0: m_loaituoi = "TU";
                        break;
                    case 1: m_loaituoi = "TH";
                        break;
                    case 2: m_loaituoi = "NG";
                        break;
                    default: m_loaituoi = "GI";
                        break;
                }
                m_tuoi = m_tuoi.Substring(0, 3) + m_loaituoi;
            }
            p_maql = _maql; p_mavaovien = _mavaovien; p_idkhoa = _idkhoa; bThuthuat = thuthuat;
            bbadt = _badt;
        }
        //end Tu

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPttt));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.hoten = new System.Windows.Forms.TextBox();
            this.mabn2 = new MaskedTextBox.MaskedTextBox();
            this.tuoi = new System.Windows.Forms.TextBox();
            this.phai = new System.Windows.Forms.TextBox();
            this.diachi = new System.Windows.Forms.TextBox();
            this.sothe = new System.Windows.Forms.TextBox();
            this.giuong = new System.Windows.Forms.TextBox();
            this.tenkp = new System.Windows.Forms.ComboBox();
            this.makp = new System.Windows.Forms.TextBox();
            this.icd_vk = new System.Windows.Forms.TextBox();
            this.cd_vk = new System.Windows.Forms.TextBox();
            this.icd_t = new MaskedTextBox.MaskedTextBox();
            this.mapt = new MaskedTextBox.MaskedTextBox();
            this.loaipt = new System.Windows.Forms.ComboBox();
            this.phuongphap = new System.Windows.Forms.TextBox();
            this.tenphuongphap = new System.Windows.Forms.ComboBox();
            this.mabs = new System.Windows.Forms.TextBox();
            this.tinhhinh = new System.Windows.Forms.ComboBox();
            this.taibien = new System.Windows.Forms.ComboBox();
            this.tuvong = new System.Windows.Forms.ComboBox();
            this.sophieu = new System.Windows.Forms.TextBox();
            this.icd_s = new MaskedTextBox.MaskedTextBox();
            this.tenpt = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.butPttt = new System.Windows.Forms.Button();
            this.butThem = new System.Windows.Forms.Button();
            this.butRef = new System.Windows.Forms.Button();
            this.cd_t = new System.Windows.Forms.TextBox();
            this.cd_s = new System.Windows.Forms.TextBox();
            this.tenbs = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.nhietdo = new MaskedBox.MaskedBox();
            this.huyetap = new MaskedTextBox.MaskedTextBox();
            this.mach = new MaskedTextBox.MaskedTextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.phu1 = new System.Windows.Forms.TextBox();
            this.tenphu1 = new System.Windows.Forms.TextBox();
            this.tenphu2 = new System.Windows.Forms.TextBox();
            this.phu2 = new System.Windows.Forms.TextBox();
            this.tenktvgayme = new System.Windows.Forms.TextBox();
            this.ktvgayme = new System.Windows.Forms.TextBox();
            this.tenbsgayme = new System.Windows.Forms.TextBox();
            this.bsgayme = new System.Windows.Forms.TextBox();
            this.tendungcu = new System.Windows.Forms.TextBox();
            this.dungcu = new System.Windows.Forms.TextBox();
            this.tenhoisuc = new System.Windows.Forms.TextBox();
            this.hoisuc = new System.Windows.Forms.TextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.mamau = new MaskedTextBox.MaskedTextBox();
            this.tenmau = new System.Windows.Forms.TextBox();
            this.chktuongtrinh = new System.Windows.Forms.CheckBox();
            this.mautuongtrinh = new System.Windows.Forms.ComboBox();
            this.noidung = new System.Windows.Forms.TextBox();
            this.label36 = new System.Windows.Forms.Label();
            this.loaibn = new System.Windows.Forms.ComboBox();
            this.label37 = new System.Windows.Forms.Label();
            this.lmat = new System.Windows.Forms.Label();
            this.mapmo = new System.Windows.Forms.ComboBox();
            this.somat = new System.Windows.Forms.NumericUpDown();
            this.molaimien = new System.Windows.Forms.CheckBox();
            this.label38 = new System.Windows.Forms.Label();
            this.loaivp = new System.Windows.Forms.ComboBox();
            this.sotien = new System.Windows.Forms.TextBox();
            this.mavp = new System.Windows.Forms.ComboBox();
            this.madoituong = new System.Windows.Forms.ComboBox();
            this.label39 = new System.Windows.Forms.Label();
            this.mabn3 = new System.Windows.Forms.TextBox();
            this.ngay = new MaskedBox.MaskedBox();
            this.ngaykt = new MaskedBox.MaskedBox();
            this.gio = new MaskedBox.MaskedBox();
            this.giokt = new MaskedBox.MaskedBox();
            this.lmau = new System.Windows.Forms.ComboBox();
            this.tenpttt = new System.Windows.Forms.TextBox();
            this.label40 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.giovv = new MaskedBox.MaskedBox();
            this.ngayvv = new MaskedBox.MaskedBox();
            this.chkXem = new System.Windows.Forms.CheckBox();
            this.noisoi = new System.Windows.Forms.CheckBox();
            this.p = new System.Windows.Forms.Panel();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.butCancel = new System.Windows.Forms.Button();
            this.butOk = new System.Windows.Forms.Button();
            this.tim = new System.Windows.Forms.TextBox();
            this.butThemcdT = new System.Windows.Forms.Button();
            this.butThemPP = new System.Windows.Forms.Button();
            this.butThemcdS = new System.Windows.Forms.Button();
            this.label42 = new System.Windows.Forms.Label();
            this.ngayvao = new System.Windows.Forms.ComboBox();
            this.danhsach = new System.Windows.Forms.GroupBox();
            this.rdtatca = new System.Windows.Forms.RadioButton();
            this.rdphauthuat = new System.Windows.Forms.RadioButton();
            this.rdtt = new System.Windows.Forms.RadioButton();
            this.list = new AsYetUnnamed.MultiColumnListBox();
            this.lblso = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.chkXml = new System.Windows.Forms.CheckBox();
            this.butHinh = new System.Windows.Forms.Button();
            this.butNhanvien = new System.Windows.Forms.Button();
            this.pic = new System.Windows.Forms.PictureBox();
            this.butThuoc = new System.Windows.Forms.Button();
            this.butTuongtrinh = new System.Windows.Forms.CheckBox();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.butIn = new System.Windows.Forms.Button();
            this.butHuy = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.butSua = new System.Windows.Forms.Button();
            this.butMoi = new System.Windows.Forms.Button();
            this.stgiam = new MaskedTextBox.MaskedTextBox();
            this.tylegiam = new MaskedTextBox.MaskedTextBox();
            this.label43 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.listBS = new LibList.List();
            this.listICD = new LibList.List();
            this.listpttt = new LibList.List();
            this.cmbNhomMau = new System.Windows.Forms.ComboBox();
            this.label46 = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.lblTenkythuat = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.somat)).BeginInit();
            this.p.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.danhsach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(208, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 23);
            this.label1.TabIndex = 80;
            this.label1.Text = "Số phiếu :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(7, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 23);
            this.label2.TabIndex = 72;
            this.label2.Text = "Mã BN :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(173, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 23);
            this.label3.TabIndex = 73;
            this.label3.Text = "Họ tên :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(550, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 23);
            this.label4.TabIndex = 75;
            this.label4.Text = "Tuổi :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(184, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 23);
            this.label5.TabIndex = 1;
            this.label5.Text = "&Khoa :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(49, 133);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 23);
            this.label6.TabIndex = 83;
            this.label6.Text = "Phẫu thủ thuật lúc :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(-23, 207);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(176, 23);
            this.label7.TabIndex = 94;
            this.label7.Text = "CĐ Trước phẫu thủ thuật :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(-31, 231);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(184, 23);
            this.label8.TabIndex = 95;
            this.label8.Text = "CĐ Sau phẫu thủ thuật :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(17, 309);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(136, 23);
            this.label9.TabIndex = 98;
            this.label9.Text = "Phương pháp vô cảm :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(-39, 257);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(192, 23);
            this.label10.TabIndex = 9;
            this.label10.Text = "Phương pháp phẫu thủ thuật :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(17, 183);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(136, 23);
            this.label12.TabIndex = 93;
            this.label12.Text = "Chẩn đoán vào khoa :";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(632, 259);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(40, 23);
            this.label13.TabIndex = 97;
            this.label13.Text = "Loại :";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(412, 309);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(120, 23);
            this.label14.TabIndex = 99;
            this.label14.Text = "Phẫu thủ thuật viên :";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label15
            // 
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(456, 54);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(56, 23);
            this.label15.TabIndex = 74;
            this.label15.Text = "Giới tính :";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label16
            // 
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(8, 82);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(56, 23);
            this.label16.TabIndex = 76;
            this.label16.Text = "Địa chỉ :";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label17
            // 
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(224, 82);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(56, 23);
            this.label17.TabIndex = 77;
            this.label17.Text = "Số thẻ :";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label18
            // 
            this.label18.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label18.Location = new System.Drawing.Point(673, 544);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(64, 23);
            this.label18.TabIndex = 78;
            this.label18.Text = "Giường :";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label18.Visible = false;
            // 
            // label19
            // 
            this.label19.ForeColor = System.Drawing.Color.Black;
            this.label19.Location = new System.Drawing.Point(339, 105);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(72, 23);
            this.label19.TabIndex = 81;
            this.label19.Text = "Vào viện lúc :";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // treeView1
            // 
            this.treeView1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.Location = new System.Drawing.Point(642, 25);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(138, 232);
            this.treeView1.TabIndex = 110;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // label20
            // 
            this.label20.ForeColor = System.Drawing.Color.Black;
            this.label20.Location = new System.Drawing.Point(17, 409);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(136, 23);
            this.label20.TabIndex = 106;
            this.label20.Text = "Tình hình :";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label21
            // 
            this.label21.ForeColor = System.Drawing.Color.Black;
            this.label21.Location = new System.Drawing.Point(234, 409);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(56, 23);
            this.label21.TabIndex = 107;
            this.label21.Text = "Tai biến :";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label22
            // 
            this.label22.ForeColor = System.Drawing.Color.Black;
            this.label22.Location = new System.Drawing.Point(435, 409);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(97, 23);
            this.label22.TabIndex = 108;
            this.label22.Text = "Tử vong :";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // hoten
            // 
            this.hoten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.hoten.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.hoten.Enabled = false;
            this.hoten.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoten.Location = new System.Drawing.Point(213, 54);
            this.hoten.Name = "hoten";
            this.hoten.Size = new System.Drawing.Size(243, 23);
            this.hoten.TabIndex = 13;
            // 
            // mabn2
            // 
            this.mabn2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabn2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabn2.Location = new System.Drawing.Point(63, 54);
            this.mabn2.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.mabn2.MaxLength = 2;
            this.mabn2.Name = "mabn2";
            this.mabn2.Size = new System.Drawing.Size(32, 23);
            this.mabn2.TabIndex = 5;
            this.mabn2.Validated += new System.EventHandler(this.mabn2_Validated);
            // 
            // tuoi
            // 
            this.tuoi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tuoi.Enabled = false;
            this.tuoi.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tuoi.Location = new System.Drawing.Point(592, 54);
            this.tuoi.Name = "tuoi";
            this.tuoi.Size = new System.Drawing.Size(48, 23);
            this.tuoi.TabIndex = 15;
            // 
            // phai
            // 
            this.phai.BackColor = System.Drawing.SystemColors.HighlightText;
            this.phai.Enabled = false;
            this.phai.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phai.Location = new System.Drawing.Point(509, 54);
            this.phai.Name = "phai";
            this.phai.Size = new System.Drawing.Size(48, 23);
            this.phai.TabIndex = 8;
            // 
            // diachi
            // 
            this.diachi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.diachi.Enabled = false;
            this.diachi.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diachi.Location = new System.Drawing.Point(62, 80);
            this.diachi.Name = "diachi";
            this.diachi.Size = new System.Drawing.Size(175, 23);
            this.diachi.TabIndex = 14;
            // 
            // sothe
            // 
            this.sothe.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sothe.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.sothe.Enabled = false;
            this.sothe.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sothe.Location = new System.Drawing.Point(282, 80);
            this.sothe.Name = "sothe";
            this.sothe.Size = new System.Drawing.Size(174, 23);
            this.sothe.TabIndex = 7;
            // 
            // giuong
            // 
            this.giuong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.giuong.Enabled = false;
            this.giuong.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.giuong.Location = new System.Drawing.Point(734, 542);
            this.giuong.Name = "giuong";
            this.giuong.Size = new System.Drawing.Size(48, 23);
            this.giuong.TabIndex = 8;
            this.giuong.Visible = false;
            // 
            // tenkp
            // 
            this.tenkp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenkp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tenkp.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenkp.Location = new System.Drawing.Point(275, 27);
            this.tenkp.Name = "tenkp";
            this.tenkp.Size = new System.Drawing.Size(160, 24);
            this.tenkp.TabIndex = 3;
            this.tenkp.SelectedIndexChanged += new System.EventHandler(this.tenkp_SelectedIndexChanged);
            this.tenkp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenkp_KeyDown);
            // 
            // makp
            // 
            this.makp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.makp.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makp.Location = new System.Drawing.Point(239, 27);
            this.makp.MaxLength = 2;
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(34, 23);
            this.makp.TabIndex = 2;
            this.makp.Validated += new System.EventHandler(this.makp_Validated);
            this.makp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.makp_KeyDown);
            // 
            // icd_vk
            // 
            this.icd_vk.BackColor = System.Drawing.SystemColors.HighlightText;
            this.icd_vk.Enabled = false;
            this.icd_vk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.icd_vk.Location = new System.Drawing.Point(149, 183);
            this.icd_vk.Name = "icd_vk";
            this.icd_vk.Size = new System.Drawing.Size(56, 23);
            this.icd_vk.TabIndex = 21;
            // 
            // cd_vk
            // 
            this.cd_vk.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cd_vk.Enabled = false;
            this.cd_vk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cd_vk.Location = new System.Drawing.Point(207, 183);
            this.cd_vk.Name = "cd_vk";
            this.cd_vk.Size = new System.Drawing.Size(433, 23);
            this.cd_vk.TabIndex = 22;
            // 
            // icd_t
            // 
            this.icd_t.BackColor = System.Drawing.SystemColors.HighlightText;
            this.icd_t.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.icd_t.Enabled = false;
            this.icd_t.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.icd_t.Location = new System.Drawing.Point(149, 207);
            this.icd_t.Masked = MaskedTextBox.MaskedTextBox.Mask.ICD10;
            this.icd_t.MaxLength = 9;
            this.icd_t.Name = "icd_t";
            this.icd_t.Size = new System.Drawing.Size(56, 23);
            this.icd_t.TabIndex = 23;
            this.icd_t.Validated += new System.EventHandler(this.icd_t_Validated);
            // 
            // mapt
            // 
            this.mapt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mapt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mapt.Enabled = false;
            this.mapt.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mapt.Location = new System.Drawing.Point(149, 257);
            this.mapt.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.mapt.MaxLength = 6;
            this.mapt.Name = "mapt";
            this.mapt.Size = new System.Drawing.Size(56, 23);
            this.mapt.TabIndex = 27;
            this.mapt.Validated += new System.EventHandler(this.mapt_Validated);
            // 
            // loaipt
            // 
            this.loaipt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.loaipt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.loaipt.Enabled = false;
            this.loaipt.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loaipt.Location = new System.Drawing.Point(672, 258);
            this.loaipt.Name = "loaipt";
            this.loaipt.Size = new System.Drawing.Size(108, 24);
            this.loaipt.TabIndex = 35;
            // 
            // phuongphap
            // 
            this.phuongphap.BackColor = System.Drawing.SystemColors.HighlightText;
            this.phuongphap.Enabled = false;
            this.phuongphap.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phuongphap.Location = new System.Drawing.Point(149, 309);
            this.phuongphap.MaxLength = 2;
            this.phuongphap.Name = "phuongphap";
            this.phuongphap.Size = new System.Drawing.Size(24, 23);
            this.phuongphap.TabIndex = 32;
            this.phuongphap.Validated += new System.EventHandler(this.phuongphap_Validated);
            this.phuongphap.KeyDown += new System.Windows.Forms.KeyEventHandler(this.phuongphap_KeyDown);
            // 
            // tenphuongphap
            // 
            this.tenphuongphap.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenphuongphap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tenphuongphap.Enabled = false;
            this.tenphuongphap.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenphuongphap.Location = new System.Drawing.Point(174, 309);
            this.tenphuongphap.Name = "tenphuongphap";
            this.tenphuongphap.Size = new System.Drawing.Size(240, 24);
            this.tenphuongphap.TabIndex = 33;
            this.tenphuongphap.SelectedIndexChanged += new System.EventHandler(this.tenphuongphap_SelectedIndexChanged);
            this.tenphuongphap.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenphuongphap_KeyDown);
            // 
            // mabs
            // 
            this.mabs.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mabs.Enabled = false;
            this.mabs.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabs.Location = new System.Drawing.Point(529, 309);
            this.mabs.MaxLength = 4;
            this.mabs.Name = "mabs";
            this.mabs.Size = new System.Drawing.Size(38, 23);
            this.mabs.TabIndex = 34;
            this.mabs.Validated += new System.EventHandler(this.mabs_Validated);
            this.mabs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabs_KeyDown);
            // 
            // tinhhinh
            // 
            this.tinhhinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tinhhinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tinhhinh.Enabled = false;
            this.tinhhinh.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tinhhinh.Location = new System.Drawing.Point(149, 409);
            this.tinhhinh.Name = "tinhhinh";
            this.tinhhinh.Size = new System.Drawing.Size(91, 24);
            this.tinhhinh.TabIndex = 48;
            this.tinhhinh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tinhhinh_KeyDown);
            // 
            // taibien
            // 
            this.taibien.BackColor = System.Drawing.SystemColors.HighlightText;
            this.taibien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.taibien.Enabled = false;
            this.taibien.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.taibien.Location = new System.Drawing.Point(288, 409);
            this.taibien.Name = "taibien";
            this.taibien.Size = new System.Drawing.Size(126, 24);
            this.taibien.TabIndex = 49;
            this.taibien.KeyDown += new System.Windows.Forms.KeyEventHandler(this.taibien_KeyDown);
            // 
            // tuvong
            // 
            this.tuvong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tuvong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tuvong.Enabled = false;
            this.tuvong.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tuvong.Location = new System.Drawing.Point(529, 409);
            this.tuvong.Name = "tuvong";
            this.tuvong.Size = new System.Drawing.Size(251, 24);
            this.tuvong.TabIndex = 50;
            this.tuvong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tuvong_KeyDown);
            // 
            // sophieu
            // 
            this.sophieu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sophieu.Enabled = false;
            this.sophieu.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sophieu.Location = new System.Drawing.Point(281, 106);
            this.sophieu.Name = "sophieu";
            this.sophieu.Size = new System.Drawing.Size(48, 23);
            this.sophieu.TabIndex = 10;
            this.sophieu.Validated += new System.EventHandler(this.sophieu_Validated);
            this.sophieu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            this.sophieu.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.sophieu_KeyPress);
            // 
            // icd_s
            // 
            this.icd_s.BackColor = System.Drawing.SystemColors.HighlightText;
            this.icd_s.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.icd_s.Enabled = false;
            this.icd_s.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.icd_s.Location = new System.Drawing.Point(149, 232);
            this.icd_s.Masked = MaskedTextBox.MaskedTextBox.Mask.ICD10;
            this.icd_s.MaxLength = 9;
            this.icd_s.Name = "icd_s";
            this.icd_s.Size = new System.Drawing.Size(56, 23);
            this.icd_s.TabIndex = 25;
            this.icd_s.Validated += new System.EventHandler(this.icd_s_Validated);
            // 
            // tenpt
            // 
            this.tenpt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenpt.Enabled = false;
            this.tenpt.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenpt.Location = new System.Drawing.Point(207, 257);
            this.tenpt.Name = "tenpt";
            this.tenpt.Size = new System.Drawing.Size(433, 23);
            this.tenpt.TabIndex = 28;
            this.tenpt.TextChanged += new System.EventHandler(this.tenpt_TextChanged);
            this.tenpt.Validated += new System.EventHandler(this.tenpt_Validated);
            this.tenpt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenpt_KeyDown);
            // 
            // butPttt
            // 
            this.butPttt.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butPttt.Location = new System.Drawing.Point(0, 594);
            this.butPttt.Name = "butPttt";
            this.butPttt.Size = new System.Drawing.Size(22, 22);
            this.butPttt.TabIndex = 40;
            this.butPttt.Text = "...";
            this.toolTip1.SetToolTip(this.butPttt, "Liệt kê danh mục phẫu thuật - thủ thuật");
            this.butPttt.Visible = false;
            this.butPttt.Click += new System.EventHandler(this.butPttt_Click);
            // 
            // butThem
            // 
            this.butThem.Enabled = false;
            this.butThem.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butThem.Location = new System.Drawing.Point(758, 282);
            this.butThem.Name = "butThem";
            this.butThem.Size = new System.Drawing.Size(24, 24);
            this.butThem.TabIndex = 257;
            this.butThem.Text = "...";
            this.toolTip1.SetToolTip(this.butThem, "Thêm thủ thuật");
            this.butThem.UseVisualStyleBackColor = true;
            this.butThem.Click += new System.EventHandler(this.butThem_Click);
            // 
            // butRef
            // 
            this.butRef.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butRef.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butRef.Location = new System.Drawing.Point(606, 24);
            this.butRef.Name = "butRef";
            this.butRef.Size = new System.Drawing.Size(24, 21);
            this.butRef.TabIndex = 1;
            this.butRef.Text = "...";
            this.toolTip1.SetToolTip(this.butRef, "Danh sách thủ thuật");
            this.butRef.Click += new System.EventHandler(this.butRef_Click);
            // 
            // cd_t
            // 
            this.cd_t.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cd_t.Enabled = false;
            this.cd_t.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cd_t.Location = new System.Drawing.Point(207, 207);
            this.cd_t.Name = "cd_t";
            this.cd_t.Size = new System.Drawing.Size(398, 23);
            this.cd_t.TabIndex = 24;
            this.cd_t.TextChanged += new System.EventHandler(this.cd_t_TextChanged);
            this.cd_t.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cd_t_KeyDown);
            // 
            // cd_s
            // 
            this.cd_s.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cd_s.Enabled = false;
            this.cd_s.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cd_s.Location = new System.Drawing.Point(207, 231);
            this.cd_s.Name = "cd_s";
            this.cd_s.Size = new System.Drawing.Size(398, 23);
            this.cd_s.TabIndex = 26;
            this.cd_s.TextChanged += new System.EventHandler(this.cd_s_TextChanged);
            this.cd_s.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cd_t_KeyDown);
            // 
            // tenbs
            // 
            this.tenbs.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbs.Enabled = false;
            this.tenbs.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbs.Location = new System.Drawing.Point(568, 309);
            this.tenbs.Name = "tenbs";
            this.tenbs.Size = new System.Drawing.Size(212, 23);
            this.tenbs.TabIndex = 35;
            this.tenbs.TextChanged += new System.EventHandler(this.tenbs_TextChanged);
            this.tenbs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbs_KeyDown);
            // 
            // label11
            // 
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(363, 133);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(76, 23);
            this.label11.TabIndex = 85;
            this.label11.Text = "đến";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nhietdo
            // 
            this.nhietdo.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nhietdo.Enabled = false;
            this.nhietdo.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhietdo.Location = new System.Drawing.Point(314, 158);
            this.nhietdo.Mask = "##.##";
            this.nhietdo.Name = "nhietdo";
            this.nhietdo.Size = new System.Drawing.Size(43, 23);
            this.nhietdo.TabIndex = 19;
            this.nhietdo.Text = "  .  ";
            // 
            // huyetap
            // 
            this.huyetap.BackColor = System.Drawing.SystemColors.HighlightText;
            this.huyetap.Enabled = false;
            this.huyetap.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.huyetap.Location = new System.Drawing.Point(446, 158);
            this.huyetap.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.huyetap.MaxLength = 7;
            this.huyetap.Name = "huyetap";
            this.huyetap.Size = new System.Drawing.Size(56, 23);
            this.huyetap.TabIndex = 20;
            // 
            // mach
            // 
            this.mach.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mach.Enabled = false;
            this.mach.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mach.Location = new System.Drawing.Point(149, 158);
            this.mach.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.mach.MaxLength = 5;
            this.mach.Name = "mach";
            this.mach.Size = new System.Drawing.Size(35, 23);
            this.mach.TabIndex = 18;
            this.mach.Validated += new System.EventHandler(this.mach_Validated);
            // 
            // label23
            // 
            this.label23.ForeColor = System.Drawing.Color.Black;
            this.label23.Location = new System.Drawing.Point(113, 158);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(40, 23);
            this.label23.TabIndex = 87;
            this.label23.Text = "Mạch :";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label24
            // 
            this.label24.ForeColor = System.Drawing.Color.Black;
            this.label24.Location = new System.Drawing.Point(184, 158);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(48, 23);
            this.label24.TabIndex = 88;
            this.label24.Text = "lần/phút";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label25
            // 
            this.label25.ForeColor = System.Drawing.Color.Black;
            this.label25.Location = new System.Drawing.Point(239, 158);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(70, 23);
            this.label25.TabIndex = 89;
            this.label25.Text = "Nhiệt độ";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label26
            // 
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.Black;
            this.label26.Location = new System.Drawing.Point(362, 158);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(18, 23);
            this.label26.TabIndex = 90;
            this.label26.Text = "°C";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label27
            // 
            this.label27.ForeColor = System.Drawing.Color.Black;
            this.label27.Location = new System.Drawing.Point(383, 158);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(56, 23);
            this.label27.TabIndex = 91;
            this.label27.Text = "Huyết áp";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label28
            // 
            this.label28.ForeColor = System.Drawing.Color.Black;
            this.label28.Location = new System.Drawing.Point(504, 158);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(38, 23);
            this.label28.TabIndex = 92;
            this.label28.Text = "mmHg";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label29
            // 
            this.label29.ForeColor = System.Drawing.Color.Black;
            this.label29.Location = new System.Drawing.Point(17, 333);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(136, 23);
            this.label29.TabIndex = 100;
            this.label29.Text = "Phụ mỗ vòng trong  :";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label30
            // 
            this.label30.ForeColor = System.Drawing.Color.Black;
            this.label30.Location = new System.Drawing.Point(420, 333);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(112, 23);
            this.label30.TabIndex = 101;
            this.label30.Text = "Phụ mỗ vòng ngoài :";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label31
            // 
            this.label31.ForeColor = System.Drawing.Color.Black;
            this.label31.Location = new System.Drawing.Point(17, 360);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(136, 23);
            this.label31.TabIndex = 102;
            this.label31.Text = "Gây mê 1 :";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label32
            // 
            this.label32.ForeColor = System.Drawing.Color.Black;
            this.label32.Location = new System.Drawing.Point(428, 360);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(104, 23);
            this.label32.TabIndex = 103;
            this.label32.Text = "Gây mê 2 :";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label33
            // 
            this.label33.ForeColor = System.Drawing.Color.Black;
            this.label33.Location = new System.Drawing.Point(17, 384);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(136, 23);
            this.label33.TabIndex = 104;
            this.label33.Text = "Hồi sức :";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label34
            // 
            this.label34.ForeColor = System.Drawing.Color.Black;
            this.label34.Location = new System.Drawing.Point(420, 384);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(112, 23);
            this.label34.TabIndex = 105;
            this.label34.Text = "Dụng cụ :";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // phu1
            // 
            this.phu1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.phu1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.phu1.Enabled = false;
            this.phu1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phu1.Location = new System.Drawing.Point(149, 334);
            this.phu1.MaxLength = 4;
            this.phu1.Name = "phu1";
            this.phu1.Size = new System.Drawing.Size(38, 23);
            this.phu1.TabIndex = 36;
            this.phu1.Validated += new System.EventHandler(this.phu1_Validated);
            this.phu1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabs_KeyDown);
            // 
            // tenphu1
            // 
            this.tenphu1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenphu1.Enabled = false;
            this.tenphu1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenphu1.Location = new System.Drawing.Point(189, 334);
            this.tenphu1.Name = "tenphu1";
            this.tenphu1.Size = new System.Drawing.Size(224, 23);
            this.tenphu1.TabIndex = 37;
            this.tenphu1.TextChanged += new System.EventHandler(this.tenphu1_TextChanged);
            this.tenphu1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbs_KeyDown);
            // 
            // tenphu2
            // 
            this.tenphu2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenphu2.Enabled = false;
            this.tenphu2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenphu2.Location = new System.Drawing.Point(568, 334);
            this.tenphu2.Name = "tenphu2";
            this.tenphu2.Size = new System.Drawing.Size(212, 23);
            this.tenphu2.TabIndex = 39;
            this.tenphu2.TextChanged += new System.EventHandler(this.tenphu2_TextChanged);
            this.tenphu2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbs_KeyDown);
            // 
            // phu2
            // 
            this.phu2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.phu2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.phu2.Enabled = false;
            this.phu2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phu2.Location = new System.Drawing.Point(529, 334);
            this.phu2.MaxLength = 4;
            this.phu2.Name = "phu2";
            this.phu2.Size = new System.Drawing.Size(38, 23);
            this.phu2.TabIndex = 38;
            this.phu2.Validated += new System.EventHandler(this.phu2_Validated);
            this.phu2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabs_KeyDown);
            // 
            // tenktvgayme
            // 
            this.tenktvgayme.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenktvgayme.Enabled = false;
            this.tenktvgayme.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenktvgayme.Location = new System.Drawing.Point(568, 359);
            this.tenktvgayme.Name = "tenktvgayme";
            this.tenktvgayme.Size = new System.Drawing.Size(212, 23);
            this.tenktvgayme.TabIndex = 43;
            this.tenktvgayme.TextChanged += new System.EventHandler(this.tenktvgayme_TextChanged);
            this.tenktvgayme.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbs_KeyDown);
            // 
            // ktvgayme
            // 
            this.ktvgayme.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ktvgayme.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ktvgayme.Enabled = false;
            this.ktvgayme.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ktvgayme.Location = new System.Drawing.Point(529, 359);
            this.ktvgayme.MaxLength = 4;
            this.ktvgayme.Name = "ktvgayme";
            this.ktvgayme.Size = new System.Drawing.Size(38, 23);
            this.ktvgayme.TabIndex = 42;
            this.ktvgayme.Validated += new System.EventHandler(this.ktvgayme_Validated);
            this.ktvgayme.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabs_KeyDown);
            // 
            // tenbsgayme
            // 
            this.tenbsgayme.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbsgayme.Enabled = false;
            this.tenbsgayme.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbsgayme.Location = new System.Drawing.Point(189, 359);
            this.tenbsgayme.Name = "tenbsgayme";
            this.tenbsgayme.Size = new System.Drawing.Size(224, 23);
            this.tenbsgayme.TabIndex = 41;
            this.tenbsgayme.TextChanged += new System.EventHandler(this.tenbsgayme_TextChanged);
            this.tenbsgayme.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbs_KeyDown);
            // 
            // bsgayme
            // 
            this.bsgayme.BackColor = System.Drawing.SystemColors.HighlightText;
            this.bsgayme.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.bsgayme.Enabled = false;
            this.bsgayme.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bsgayme.Location = new System.Drawing.Point(149, 359);
            this.bsgayme.MaxLength = 4;
            this.bsgayme.Name = "bsgayme";
            this.bsgayme.Size = new System.Drawing.Size(38, 23);
            this.bsgayme.TabIndex = 40;
            this.bsgayme.Validated += new System.EventHandler(this.bsgayme_Validated);
            this.bsgayme.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabs_KeyDown);
            // 
            // tendungcu
            // 
            this.tendungcu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tendungcu.Enabled = false;
            this.tendungcu.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tendungcu.Location = new System.Drawing.Point(568, 384);
            this.tendungcu.Name = "tendungcu";
            this.tendungcu.Size = new System.Drawing.Size(212, 23);
            this.tendungcu.TabIndex = 47;
            this.tendungcu.TextChanged += new System.EventHandler(this.tendungcu_TextChanged);
            this.tendungcu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbs_KeyDown);
            // 
            // dungcu
            // 
            this.dungcu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dungcu.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.dungcu.Enabled = false;
            this.dungcu.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dungcu.Location = new System.Drawing.Point(529, 384);
            this.dungcu.MaxLength = 4;
            this.dungcu.Name = "dungcu";
            this.dungcu.Size = new System.Drawing.Size(38, 23);
            this.dungcu.TabIndex = 46;
            this.dungcu.Validated += new System.EventHandler(this.dungcu_Validated);
            this.dungcu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabs_KeyDown);
            // 
            // tenhoisuc
            // 
            this.tenhoisuc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenhoisuc.Enabled = false;
            this.tenhoisuc.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenhoisuc.Location = new System.Drawing.Point(189, 384);
            this.tenhoisuc.Name = "tenhoisuc";
            this.tenhoisuc.Size = new System.Drawing.Size(224, 23);
            this.tenhoisuc.TabIndex = 45;
            this.tenhoisuc.TextChanged += new System.EventHandler(this.tenhoisuc_TextChanged);
            this.tenhoisuc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbs_KeyDown);
            // 
            // hoisuc
            // 
            this.hoisuc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.hoisuc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.hoisuc.Enabled = false;
            this.hoisuc.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoisuc.Location = new System.Drawing.Point(149, 384);
            this.hoisuc.MaxLength = 4;
            this.hoisuc.Name = "hoisuc";
            this.hoisuc.Size = new System.Drawing.Size(38, 23);
            this.hoisuc.TabIndex = 44;
            this.hoisuc.Validated += new System.EventHandler(this.hoisuc_Validated);
            this.hoisuc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabs_KeyDown);
            // 
            // label35
            // 
            this.label35.ForeColor = System.Drawing.Color.Black;
            this.label35.Location = new System.Drawing.Point(17, 283);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(136, 23);
            this.label35.TabIndex = 96;
            this.label35.Text = "Phương pháp thực tế :";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mamau
            // 
            this.mamau.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mamau.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mamau.Enabled = false;
            this.mamau.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mamau.Location = new System.Drawing.Point(688, 58);
            this.mamau.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.mamau.MaxLength = 10;
            this.mamau.Name = "mamau";
            this.mamau.Size = new System.Drawing.Size(83, 23);
            this.mamau.TabIndex = 27;
            this.mamau.Validated += new System.EventHandler(this.mamau_Validated);
            // 
            // tenmau
            // 
            this.tenmau.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenmau.Enabled = false;
            this.tenmau.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenmau.Location = new System.Drawing.Point(149, 283);
            this.tenmau.Name = "tenmau";
            this.tenmau.Size = new System.Drawing.Size(83, 23);
            this.tenmau.TabIndex = 29;
            this.tenmau.TextChanged += new System.EventHandler(this.tenmau_TextChanged);
            this.tenmau.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenpt_KeyDown);
            // 
            // chktuongtrinh
            // 
            this.chktuongtrinh.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chktuongtrinh.Enabled = false;
            this.chktuongtrinh.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.chktuongtrinh.Location = new System.Drawing.Point(33, 562);
            this.chktuongtrinh.Name = "chktuongtrinh";
            this.chktuongtrinh.Size = new System.Drawing.Size(130, 24);
            this.chktuongtrinh.TabIndex = 59;
            this.chktuongtrinh.Text = "Tường trình theo mẫu";
            this.chktuongtrinh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chktuongtrinh.Visible = false;
            this.chktuongtrinh.CheckedChanged += new System.EventHandler(this.chktuongtrinh_CheckedChanged);
            this.chktuongtrinh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabs_KeyDown);
            // 
            // mautuongtrinh
            // 
            this.mautuongtrinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mautuongtrinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mautuongtrinh.Enabled = false;
            this.mautuongtrinh.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mautuongtrinh.Location = new System.Drawing.Point(168, 634);
            this.mautuongtrinh.Name = "mautuongtrinh";
            this.mautuongtrinh.Size = new System.Drawing.Size(624, 24);
            this.mautuongtrinh.TabIndex = 60;
            this.mautuongtrinh.Visible = false;
            this.mautuongtrinh.SelectedIndexChanged += new System.EventHandler(this.mautuongtrinh_SelectedIndexChanged);
            this.mautuongtrinh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabs_KeyDown);
            // 
            // noidung
            // 
            this.noidung.BackColor = System.Drawing.SystemColors.Info;
            this.noidung.Enabled = false;
            this.noidung.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noidung.Location = new System.Drawing.Point(-4, 12);
            this.noidung.Multiline = true;
            this.noidung.Name = "noidung";
            this.noidung.Size = new System.Drawing.Size(631, 405);
            this.noidung.TabIndex = 255;
            this.noidung.Visible = false;
            // 
            // label36
            // 
            this.label36.ForeColor = System.Drawing.Color.Black;
            this.label36.Location = new System.Drawing.Point(-2, 26);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(72, 23);
            this.label36.TabIndex = 70;
            this.label36.Text = "Người bệnh :";
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // loaibn
            // 
            this.loaibn.BackColor = System.Drawing.SystemColors.HighlightText;
            this.loaibn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.loaibn.Enabled = false;
            this.loaibn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loaibn.Location = new System.Drawing.Point(63, 27);
            this.loaibn.Name = "loaibn";
            this.loaibn.Size = new System.Drawing.Size(137, 24);
            this.loaibn.TabIndex = 0;
            this.loaibn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.loaibn_KeyDown);
            // 
            // label37
            // 
            this.label37.ForeColor = System.Drawing.Color.Black;
            this.label37.Location = new System.Drawing.Point(432, 26);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(68, 23);
            this.label37.TabIndex = 71;
            this.label37.Text = "Phòng mỗ :";
            this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lmat
            // 
            this.lmat.ForeColor = System.Drawing.Color.Black;
            this.lmat.Location = new System.Drawing.Point(547, 106);
            this.lmat.Name = "lmat";
            this.lmat.Size = new System.Drawing.Size(48, 23);
            this.lmat.TabIndex = 82;
            this.lmat.Text = "Số mắt :";
            this.lmat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mapmo
            // 
            this.mapmo.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mapmo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mapmo.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mapmo.Location = new System.Drawing.Point(496, 27);
            this.mapmo.Name = "mapmo";
            this.mapmo.Size = new System.Drawing.Size(144, 24);
            this.mapmo.TabIndex = 4;
            this.mapmo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mapmo_KeyDown);
            // 
            // somat
            // 
            this.somat.BackColor = System.Drawing.SystemColors.HighlightText;
            this.somat.Enabled = false;
            this.somat.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.somat.Location = new System.Drawing.Point(592, 106);
            this.somat.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.somat.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.somat.Name = "somat";
            this.somat.Size = new System.Drawing.Size(48, 23);
            this.somat.TabIndex = 13;
            this.somat.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.somat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabs_KeyDown);
            // 
            // molaimien
            // 
            this.molaimien.Enabled = false;
            this.molaimien.ForeColor = System.Drawing.Color.Black;
            this.molaimien.Location = new System.Drawing.Point(224, 465);
            this.molaimien.Name = "molaimien";
            this.molaimien.Size = new System.Drawing.Size(104, 19);
            this.molaimien.TabIndex = 55;
            this.molaimien.Text = "Mỗ lại miễn phí";
            this.molaimien.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabs_KeyDown);
            // 
            // label38
            // 
            this.label38.ForeColor = System.Drawing.Color.Black;
            this.label38.Location = new System.Drawing.Point(17, 435);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(136, 23);
            this.label38.TabIndex = 109;
            this.label38.Text = "Viện phí :";
            this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // loaivp
            // 
            this.loaivp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.loaivp.Enabled = false;
            this.loaivp.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loaivp.Location = new System.Drawing.Point(149, 435);
            this.loaivp.Name = "loaivp";
            this.loaivp.Size = new System.Drawing.Size(160, 24);
            this.loaivp.TabIndex = 51;
            this.loaivp.SelectedIndexChanged += new System.EventHandler(this.loaivp_SelectedIndexChanged);
            this.loaivp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mavp_KeyDown);
            // 
            // sotien
            // 
            this.sotien.Enabled = false;
            this.sotien.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sotien.Location = new System.Drawing.Point(672, 435);
            this.sotien.Name = "sotien";
            this.sotien.Size = new System.Drawing.Size(108, 23);
            this.sotien.TabIndex = 53;
            this.sotien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // mavp
            // 
            this.mavp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mavp.Enabled = false;
            this.mavp.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mavp.Location = new System.Drawing.Point(311, 435);
            this.mavp.Name = "mavp";
            this.mavp.Size = new System.Drawing.Size(360, 24);
            this.mavp.TabIndex = 52;
            this.mavp.SelectedIndexChanged += new System.EventHandler(this.mavp_SelectedIndexChanged);
            this.mavp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mavp_KeyDown);
            // 
            // madoituong
            // 
            this.madoituong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.madoituong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.madoituong.Enabled = false;
            this.madoituong.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madoituong.Location = new System.Drawing.Point(62, 106);
            this.madoituong.Name = "madoituong";
            this.madoituong.Size = new System.Drawing.Size(143, 24);
            this.madoituong.TabIndex = 9;
            this.madoituong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngay_KeyDown);
            // 
            // label39
            // 
            this.label39.ForeColor = System.Drawing.Color.Black;
            this.label39.Location = new System.Drawing.Point(3, 106);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(60, 23);
            this.label39.TabIndex = 79;
            this.label39.Text = "Đối tượng :";
            this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mabn3
            // 
            this.mabn3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabn3.Location = new System.Drawing.Point(96, 54);
            this.mabn3.MaxLength = 8;
            this.mabn3.Name = "mabn3";
            this.mabn3.Size = new System.Drawing.Size(79, 23);
            this.mabn3.TabIndex = 6;
            this.mabn3.Validated += new System.EventHandler(this.mabn3_Validated);
            this.mabn3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngay_KeyDown);
            this.mabn3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mabn3_KeyPress);
            // 
            // ngay
            // 
            this.ngay.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngay.Enabled = false;
            this.ngay.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngay.Location = new System.Drawing.Point(149, 133);
            this.ngay.Mask = "##/##/####";
            this.ngay.Name = "ngay";
            this.ngay.Size = new System.Drawing.Size(88, 23);
            this.ngay.TabIndex = 14;
            this.ngay.Text = "  /  /    ";
            this.ngay.Validated += new System.EventHandler(this.ngay_Validated);
            // 
            // ngaykt
            // 
            this.ngaykt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngaykt.Enabled = false;
            this.ngaykt.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngaykt.Location = new System.Drawing.Point(446, 133);
            this.ngaykt.Mask = "##/##/####";
            this.ngaykt.Name = "ngaykt";
            this.ngaykt.Size = new System.Drawing.Size(88, 23);
            this.ngaykt.TabIndex = 16;
            this.ngaykt.Text = "  /  /    ";
            this.ngaykt.Validated += new System.EventHandler(this.ngaykt_Validated);
            // 
            // gio
            // 
            this.gio.BackColor = System.Drawing.SystemColors.HighlightText;
            this.gio.Enabled = false;
            this.gio.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gio.Location = new System.Drawing.Point(314, 133);
            this.gio.Mask = "##:##";
            this.gio.Name = "gio";
            this.gio.Size = new System.Drawing.Size(43, 23);
            this.gio.TabIndex = 15;
            this.gio.Text = "  :  ";
            this.gio.Validated += new System.EventHandler(this.gio_Validated);
            // 
            // giokt
            // 
            this.giokt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.giokt.Enabled = false;
            this.giokt.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.giokt.Location = new System.Drawing.Point(584, 133);
            this.giokt.Mask = "##:##";
            this.giokt.Name = "giokt";
            this.giokt.Size = new System.Drawing.Size(43, 23);
            this.giokt.TabIndex = 17;
            this.giokt.Text = "  :  ";
            this.giokt.Validated += new System.EventHandler(this.giokt_Validated);
            // 
            // lmau
            // 
            this.lmau.BackColor = System.Drawing.SystemColors.HighlightText;
            this.lmau.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lmau.Enabled = false;
            this.lmau.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lmau.Location = new System.Drawing.Point(233, 283);
            this.lmau.Name = "lmau";
            this.lmau.Size = new System.Drawing.Size(181, 24);
            this.lmau.TabIndex = 30;
            this.lmau.SelectedIndexChanged += new System.EventHandler(this.lmau_SelectedIndexChanged);
            this.lmau.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lmau_KeyDown);
            // 
            // tenpttt
            // 
            this.tenpttt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenpttt.Enabled = false;
            this.tenpttt.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenpttt.Location = new System.Drawing.Point(448, 283);
            this.tenpttt.Name = "tenpttt";
            this.tenpttt.Size = new System.Drawing.Size(310, 23);
            this.tenpttt.TabIndex = 31;
            this.tenpttt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenpttt_KeyDown);
            // 
            // label40
            // 
            this.label40.ForeColor = System.Drawing.Color.Black;
            this.label40.Location = new System.Drawing.Point(285, 131);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(28, 23);
            this.label40.TabIndex = 84;
            this.label40.Text = "giờ :";
            this.label40.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label41
            // 
            this.label41.ForeColor = System.Drawing.Color.Black;
            this.label41.Location = new System.Drawing.Point(552, 132);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(28, 23);
            this.label41.TabIndex = 86;
            this.label41.Text = "giờ :";
            this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // giovv
            // 
            this.giovv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.giovv.Enabled = false;
            this.giovv.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.giovv.Location = new System.Drawing.Point(501, 106);
            this.giovv.Mask = "##:##";
            this.giovv.Name = "giovv";
            this.giovv.Size = new System.Drawing.Size(43, 23);
            this.giovv.TabIndex = 12;
            this.giovv.Text = "  :  ";
            this.giovv.Validated += new System.EventHandler(this.giovv_Validated);
            // 
            // ngayvv
            // 
            this.ngayvv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngayvv.Enabled = false;
            this.ngayvv.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngayvv.Location = new System.Drawing.Point(410, 106);
            this.ngayvv.Mask = "##/##/####";
            this.ngayvv.Name = "ngayvv";
            this.ngayvv.Size = new System.Drawing.Size(88, 23);
            this.ngayvv.TabIndex = 11;
            this.ngayvv.Text = "  /  /    ";
            this.ngayvv.Validated += new System.EventHandler(this.ngayvv_Validated);
            // 
            // chkXem
            // 
            this.chkXem.ForeColor = System.Drawing.Color.Black;
            this.chkXem.Location = new System.Drawing.Point(588, 465);
            this.chkXem.Name = "chkXem";
            this.chkXem.Size = new System.Drawing.Size(104, 19);
            this.chkXem.TabIndex = 256;
            this.chkXem.Text = "Xem trước khi in";
            // 
            // noisoi
            // 
            this.noisoi.Enabled = false;
            this.noisoi.ForeColor = System.Drawing.Color.Black;
            this.noisoi.Location = new System.Drawing.Point(149, 465);
            this.noisoi.Name = "noisoi";
            this.noisoi.Size = new System.Drawing.Size(83, 20);
            this.noisoi.TabIndex = 54;
            this.noisoi.Text = "Mỗ nội soi";
            this.noisoi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabs_KeyDown);
            // 
            // p
            // 
            this.p.Controls.Add(this.label47);
            this.p.Controls.Add(this.dataGrid1);
            this.p.Controls.Add(this.butCancel);
            this.p.Controls.Add(this.butOk);
            this.p.Controls.Add(this.tim);
            this.p.Location = new System.Drawing.Point(164, 22);
            this.p.Name = "p";
            this.p.Size = new System.Drawing.Size(558, 463);
            this.p.TabIndex = 258;
            this.p.Visible = false;
            this.p.Paint += new System.Windows.Forms.PaintEventHandler(this.p_Paint);
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
            this.dataGrid1.Location = new System.Drawing.Point(4, 45);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.Size = new System.Drawing.Size(538, 416);
            this.dataGrid1.TabIndex = 32;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            this.dataGrid1.Click += new System.EventHandler(this.dataGrid1_Click);
            // 
            // butCancel
            // 
            this.butCancel.Location = new System.Drawing.Point(483, 17);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(60, 23);
            this.butCancel.TabIndex = 3;
            this.butCancel.Text = "Bỏ qua";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // butOk
            // 
            this.butOk.Location = new System.Drawing.Point(423, 17);
            this.butOk.Name = "butOk";
            this.butOk.Size = new System.Drawing.Size(60, 23);
            this.butOk.TabIndex = 2;
            this.butOk.Text = "Đồng ý";
            this.butOk.UseVisualStyleBackColor = true;
            this.butOk.Click += new System.EventHandler(this.butOk_Click);
            // 
            // tim
            // 
            this.tim.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tim.ForeColor = System.Drawing.Color.Red;
            this.tim.Location = new System.Drawing.Point(0, 18);
            this.tim.Name = "tim";
            this.tim.Size = new System.Drawing.Size(423, 21);
            this.tim.TabIndex = 0;
            this.tim.Text = "Tìm kiếm";
            this.tim.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tim.TextChanged += new System.EventHandler(this.tim_TextChanged);
            this.tim.Enter += new System.EventHandler(this.tim_Enter);
            // 
            // butThemcdT
            // 
            this.butThemcdT.Enabled = false;
            this.butThemcdT.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.butThemcdT.Location = new System.Drawing.Point(605, 206);
            this.butThemcdT.Name = "butThemcdT";
            this.butThemcdT.Size = new System.Drawing.Size(35, 25);
            this.butThemcdT.TabIndex = 100;
            this.butThemcdT.Text = "+";
            this.butThemcdT.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.butThemcdT.UseVisualStyleBackColor = true;
            this.butThemcdT.Click += new System.EventHandler(this.butThemcdT_Click);
            // 
            // butThemPP
            // 
            this.butThemPP.Enabled = false;
            this.butThemPP.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.butThemPP.Location = new System.Drawing.Point(414, 282);
            this.butThemPP.Name = "butThemPP";
            this.butThemPP.Size = new System.Drawing.Size(35, 26);
            this.butThemPP.TabIndex = 102;
            this.butThemPP.Text = "+";
            this.butThemPP.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.butThemPP.UseVisualStyleBackColor = true;
            this.butThemPP.Click += new System.EventHandler(this.butThemPP_Click);
            // 
            // butThemcdS
            // 
            this.butThemcdS.Enabled = false;
            this.butThemcdS.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.butThemcdS.Location = new System.Drawing.Point(605, 230);
            this.butThemcdS.Name = "butThemcdS";
            this.butThemcdS.Size = new System.Drawing.Size(35, 25);
            this.butThemcdS.TabIndex = 101;
            this.butThemcdS.Text = "+";
            this.butThemcdS.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.butThemcdS.UseVisualStyleBackColor = true;
            this.butThemcdS.Click += new System.EventHandler(this.butThemcdS_Click);
            // 
            // label42
            // 
            this.label42.ForeColor = System.Drawing.Color.Black;
            this.label42.Location = new System.Drawing.Point(445, 82);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(67, 23);
            this.label42.TabIndex = 259;
            this.label42.Text = "Ngày vào :";
            this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ngayvao
            // 
            this.ngayvao.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngayvao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ngayvao.Enabled = false;
            this.ngayvao.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngayvao.Location = new System.Drawing.Point(509, 79);
            this.ngayvao.Name = "ngayvao";
            this.ngayvao.Size = new System.Drawing.Size(131, 24);
            this.ngayvao.TabIndex = 8;
            this.ngayvao.Validated += new System.EventHandler(this.ngayvao_Validated);
            this.ngayvao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngayvao_KeyDown);
            // 
            // danhsach
            // 
            this.danhsach.Controls.Add(this.rdtatca);
            this.danhsach.Controls.Add(this.rdphauthuat);
            this.danhsach.Controls.Add(this.rdtt);
            this.danhsach.Controls.Add(this.list);
            this.danhsach.Controls.Add(this.lblso);
            this.danhsach.Controls.Add(this.textBox1);
            this.danhsach.Controls.Add(this.butRef);
            this.danhsach.Location = new System.Drawing.Point(4, 82);
            this.danhsach.Name = "danhsach";
            this.danhsach.Size = new System.Drawing.Size(636, 323);
            this.danhsach.TabIndex = 262;
            this.danhsach.TabStop = false;
            // 
            // rdtatca
            // 
            this.rdtatca.AutoSize = true;
            this.rdtatca.Location = new System.Drawing.Point(180, 318);
            this.rdtatca.Name = "rdtatca";
            this.rdtatca.Size = new System.Drawing.Size(56, 17);
            this.rdtatca.TabIndex = 6;
            this.rdtatca.Text = "Tất cả";
            this.rdtatca.UseVisualStyleBackColor = true;
            this.rdtatca.Click += new System.EventHandler(this.rdtatca_Click);
            // 
            // rdphauthuat
            // 
            this.rdphauthuat.AutoSize = true;
            this.rdphauthuat.Location = new System.Drawing.Point(108, 318);
            this.rdphauthuat.Name = "rdphauthuat";
            this.rdphauthuat.Size = new System.Drawing.Size(50, 17);
            this.rdphauthuat.TabIndex = 5;
            this.rdphauthuat.Text = "Khoa";
            this.rdphauthuat.UseVisualStyleBackColor = true;
            this.rdphauthuat.Click += new System.EventHandler(this.rdtatca_Click);
            // 
            // rdtt
            // 
            this.rdtt.AutoSize = true;
            this.rdtt.Checked = true;
            this.rdtt.Location = new System.Drawing.Point(8, 318);
            this.rdtt.Name = "rdtt";
            this.rdtt.Size = new System.Drawing.Size(85, 17);
            this.rdtt.TabIndex = 4;
            this.rdtt.TabStop = true;
            this.rdtt.Text = "Phòng khám";
            this.rdtt.UseVisualStyleBackColor = true;
            this.rdtt.Click += new System.EventHandler(this.rdtatca_Click);
            // 
            // list
            // 
            this.list.BackColor = System.Drawing.SystemColors.Info;
            this.list.ColumnCount = 0;
            this.list.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.list.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.list.FormattingEnabled = true;
            this.list.Location = new System.Drawing.Point(4, 47);
            this.list.MatchBufferTimeOut = 1000;
            this.list.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.list.Name = "list";
            this.list.Size = new System.Drawing.Size(626, 264);
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
            this.lblso.Location = new System.Drawing.Point(579, 27);
            this.lblso.Name = "lblso";
            this.lblso.Size = new System.Drawing.Size(28, 13);
            this.lblso.TabIndex = 3;
            this.lblso.Text = "Tìm";
            this.lblso.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.Red;
            this.textBox1.Location = new System.Drawing.Point(4, 25);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(578, 21);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "Tìm kiếm";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.Enter += new System.EventHandler(this.textBox1_Enter);
            // 
            // chkXml
            // 
            this.chkXml.ForeColor = System.Drawing.Color.Black;
            this.chkXml.Location = new System.Drawing.Point(696, 465);
            this.chkXml.Name = "chkXml";
            this.chkXml.Size = new System.Drawing.Size(86, 19);
            this.chkXml.TabIndex = 263;
            this.chkXml.Text = "Xuất ra XML";
            // 
            // butHinh
            // 
            this.butHinh.BackColor = System.Drawing.Color.Transparent;
            this.butHinh.Enabled = false;
            this.butHinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butHinh.ForeColor = System.Drawing.SystemColors.ControlText;
            this.butHinh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHinh.Location = new System.Drawing.Point(468, 511);
            this.butHinh.Name = "butHinh";
            this.butHinh.Size = new System.Drawing.Size(92, 25);
            this.butHinh.TabIndex = 68;
            this.butHinh.Text = "Hình phẫu thuật";
            this.butHinh.UseVisualStyleBackColor = false;
            this.butHinh.Click += new System.EventHandler(this.butHinh_Click);
            // 
            // butNhanvien
            // 
            this.butNhanvien.BackColor = System.Drawing.Color.Transparent;
            this.butNhanvien.Enabled = false;
            this.butNhanvien.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butNhanvien.ForeColor = System.Drawing.SystemColors.ControlText;
            this.butNhanvien.Image = ((System.Drawing.Image)(resources.GetObject("butNhanvien.Image")));
            this.butNhanvien.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butNhanvien.Location = new System.Drawing.Point(184, 511);
            this.butNhanvien.Name = "butNhanvien";
            this.butNhanvien.Size = new System.Drawing.Size(82, 25);
            this.butNhanvien.TabIndex = 67;
            this.butNhanvien.Text = "&Nhân viên";
            this.butNhanvien.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butNhanvien.UseVisualStyleBackColor = false;
            this.butNhanvien.Click += new System.EventHandler(this.butNhanvien_Click);
            // 
            // pic
            // 
            this.pic.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pic.Image = ((System.Drawing.Image)(resources.GetObject("pic.Image")));
            this.pic.Location = new System.Drawing.Point(6, 408);
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(70, 73);
            this.pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic.TabIndex = 260;
            this.pic.TabStop = false;
            // 
            // butThuoc
            // 
            this.butThuoc.BackColor = System.Drawing.Color.Transparent;
            this.butThuoc.ForeColor = System.Drawing.SystemColors.ControlText;
            this.butThuoc.Image = ((System.Drawing.Image)(resources.GetObject("butThuoc.Image")));
            this.butThuoc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butThuoc.Location = new System.Drawing.Point(619, 511);
            this.butThuoc.Name = "butThuoc";
            this.butThuoc.Size = new System.Drawing.Size(93, 25);
            this.butThuoc.TabIndex = 65;
            this.butThuoc.Text = "Thuốc+&vật tư";
            this.butThuoc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butThuoc.UseVisualStyleBackColor = false;
            this.butThuoc.Click += new System.EventHandler(this.butThuoc_Click);
            // 
            // butTuongtrinh
            // 
            this.butTuongtrinh.Appearance = System.Windows.Forms.Appearance.Button;
            this.butTuongtrinh.BackColor = System.Drawing.Color.Transparent;
            this.butTuongtrinh.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butTuongtrinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butTuongtrinh.ForeColor = System.Drawing.SystemColors.ControlText;
            this.butTuongtrinh.Image = ((System.Drawing.Image)(resources.GetObject("butTuongtrinh.Image")));
            this.butTuongtrinh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butTuongtrinh.Location = new System.Drawing.Point(383, 511);
            this.butTuongtrinh.Name = "butTuongtrinh";
            this.butTuongtrinh.Size = new System.Drawing.Size(86, 25);
            this.butTuongtrinh.TabIndex = 64;
            this.butTuongtrinh.Text = "&Tường trình";
            this.butTuongtrinh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butTuongtrinh.UseVisualStyleBackColor = false;
            this.butTuongtrinh.CheckedChanged += new System.EventHandler(this.butTuongtrinh_CheckedChanged);
            // 
            // butKetthuc
            // 
            this.butKetthuc.BackColor = System.Drawing.Color.Transparent;
            this.butKetthuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butKetthuc.ForeColor = System.Drawing.SystemColors.ControlText;
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(711, 511);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 66;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.UseVisualStyleBackColor = false;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // butIn
            // 
            this.butIn.BackColor = System.Drawing.Color.Transparent;
            this.butIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butIn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(324, 511);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(60, 25);
            this.butIn.TabIndex = 63;
            this.butIn.Text = "      &In";
            this.butIn.UseVisualStyleBackColor = false;
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butHuy
            // 
            this.butHuy.BackColor = System.Drawing.Color.Transparent;
            this.butHuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butHuy.ForeColor = System.Drawing.SystemColors.ControlText;
            this.butHuy.Image = ((System.Drawing.Image)(resources.GetObject("butHuy.Image")));
            this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHuy.Location = new System.Drawing.Point(265, 511);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(60, 25);
            this.butHuy.TabIndex = 62;
            this.butHuy.Text = "     &Hủy";
            this.butHuy.UseVisualStyleBackColor = false;
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.BackColor = System.Drawing.Color.Transparent;
            this.butBoqua.Enabled = false;
            this.butBoqua.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butBoqua.ForeColor = System.Drawing.SystemColors.ControlText;
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.butBoqua.Location = new System.Drawing.Point(558, 511);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(62, 25);
            this.butBoqua.TabIndex = 59;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.UseVisualStyleBackColor = false;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butLuu
            // 
            this.butLuu.BackColor = System.Drawing.Color.Transparent;
            this.butLuu.Enabled = false;
            this.butLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butLuu.ForeColor = System.Drawing.SystemColors.ControlText;
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(125, 511);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(60, 25);
            this.butLuu.TabIndex = 58;
            this.butLuu.Text = "      &Lưu";
            this.butLuu.UseVisualStyleBackColor = false;
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butSua
            // 
            this.butSua.BackColor = System.Drawing.Color.Transparent;
            this.butSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butSua.ForeColor = System.Drawing.SystemColors.ControlText;
            this.butSua.Image = ((System.Drawing.Image)(resources.GetObject("butSua.Image")));
            this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.Location = new System.Drawing.Point(66, 511);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(60, 25);
            this.butSua.TabIndex = 61;
            this.butSua.Text = "     &Sửa";
            this.butSua.UseVisualStyleBackColor = false;
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butMoi
            // 
            this.butMoi.BackColor = System.Drawing.Color.Transparent;
            this.butMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butMoi.ForeColor = System.Drawing.SystemColors.ControlText;
            this.butMoi.Image = ((System.Drawing.Image)(resources.GetObject("butMoi.Image")));
            this.butMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMoi.Location = new System.Drawing.Point(7, 511);
            this.butMoi.Name = "butMoi";
            this.butMoi.Size = new System.Drawing.Size(60, 25);
            this.butMoi.TabIndex = 60;
            this.butMoi.Text = "     &Mới";
            this.butMoi.UseVisualStyleBackColor = false;
            this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
            // 
            // stgiam
            // 
            this.stgiam.BackColor = System.Drawing.SystemColors.HighlightText;
            this.stgiam.Enabled = false;
            this.stgiam.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stgiam.Location = new System.Drawing.Point(504, 461);
            this.stgiam.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
            this.stgiam.Name = "stgiam";
            this.stgiam.Size = new System.Drawing.Size(82, 21);
            this.stgiam.TabIndex = 57;
            this.stgiam.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.stgiam.Validated += new System.EventHandler(this.stgiam_Validated);
            // 
            // tylegiam
            // 
            this.tylegiam.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tylegiam.Enabled = false;
            this.tylegiam.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tylegiam.Location = new System.Drawing.Point(389, 461);
            this.tylegiam.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
            this.tylegiam.Name = "tylegiam";
            this.tylegiam.Size = new System.Drawing.Size(30, 21);
            this.tylegiam.TabIndex = 56;
            this.tylegiam.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tylegiam.Validated += new System.EventHandler(this.tylegiam_Validated);
            // 
            // label43
            // 
            this.label43.ForeColor = System.Drawing.Color.Black;
            this.label43.Location = new System.Drawing.Point(425, 461);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(80, 23);
            this.label43.TabIndex = 289;
            this.label43.Text = "Số tiền giảm :";
            this.label43.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label44
            // 
            this.label44.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label44.Location = new System.Drawing.Point(415, 461);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(21, 23);
            this.label44.TabIndex = 288;
            this.label44.Text = "%";
            this.label44.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label45
            // 
            this.label45.ForeColor = System.Drawing.Color.Black;
            this.label45.Location = new System.Drawing.Point(323, 461);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(68, 23);
            this.label45.TabIndex = 287;
            this.label45.Text = "Tỷ lệ giảm :";
            this.label45.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton2,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(792, 25);
            this.toolStrip1.TabIndex = 290;
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(198, 22);
            this.toolStripButton2.Text = "Phiếu thanh toán vật tư tiêu hao";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(179, 22);
            this.toolStripButton1.Text = "Giấy chứng nhận phẩu thuật";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // listBS
            // 
            this.listBS.BackColor = System.Drawing.SystemColors.Info;
            this.listBS.ColumnCount = 0;
            this.listBS.Location = new System.Drawing.Point(184, 561);
            this.listBS.MatchBufferTimeOut = 1000;
            this.listBS.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listBS.Name = "listBS";
            this.listBS.Size = new System.Drawing.Size(75, 17);
            this.listBS.TabIndex = 224;
            this.listBS.TextIndex = -1;
            this.listBS.TextMember = null;
            this.listBS.ValueIndex = -1;
            this.listBS.Visible = false;
            // 
            // listICD
            // 
            this.listICD.BackColor = System.Drawing.SystemColors.Info;
            this.listICD.ColumnCount = 0;
            this.listICD.Location = new System.Drawing.Point(336, 562);
            this.listICD.MatchBufferTimeOut = 1000;
            this.listICD.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listICD.Name = "listICD";
            this.listICD.Size = new System.Drawing.Size(75, 17);
            this.listICD.TabIndex = 223;
            this.listICD.TextIndex = -1;
            this.listICD.TextMember = null;
            this.listICD.ValueIndex = -1;
            this.listICD.Visible = false;
            // 
            // listpttt
            // 
            this.listpttt.BackColor = System.Drawing.SystemColors.Info;
            this.listpttt.ColumnCount = 0;
            this.listpttt.Location = new System.Drawing.Point(472, 562);
            this.listpttt.MatchBufferTimeOut = 1000;
            this.listpttt.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listpttt.Name = "listpttt";
            this.listpttt.Size = new System.Drawing.Size(75, 17);
            this.listpttt.TabIndex = 39;
            this.listpttt.TextIndex = -1;
            this.listpttt.TextMember = null;
            this.listpttt.ValueIndex = -1;
            this.listpttt.Visible = false;
            this.listpttt.Validated += new System.EventHandler(this.listpttt_Validated);
            // 
            // cmbNhomMau
            // 
            this.cmbNhomMau.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cmbNhomMau.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNhomMau.Enabled = false;
            this.cmbNhomMau.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbNhomMau.Items.AddRange(new object[] {
            "O",
            "A",
            "B",
            "AB"});
            this.cmbNhomMau.Location = new System.Drawing.Point(149, 486);
            this.cmbNhomMau.Name = "cmbNhomMau";
            this.cmbNhomMau.Size = new System.Drawing.Size(91, 24);
            this.cmbNhomMau.TabIndex = 291;
            // 
            // label46
            // 
            this.label46.ForeColor = System.Drawing.Color.Black;
            this.label46.Location = new System.Drawing.Point(73, 487);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(72, 23);
            this.label46.TabIndex = 292;
            this.label46.Text = "Nhóm máu :";
            this.label46.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.ForeColor = System.Drawing.Color.Blue;
            this.label47.Location = new System.Drawing.Point(194, 469);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(0, 13);
            this.label47.TabIndex = 293;
            this.label47.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label47.Visible = false;
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.ForeColor = System.Drawing.Color.Blue;
            this.label48.Location = new System.Drawing.Point(247, 492);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(111, 13);
            this.label48.TabIndex = 294;
            this.label48.Text = "Tên dịch vụ kỹ thuật :";
            this.label48.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label48.Visible = false;
            // 
            // lblTenkythuat
            // 
            this.lblTenkythuat.AutoSize = true;
            this.lblTenkythuat.ForeColor = System.Drawing.Color.Blue;
            this.lblTenkythuat.Location = new System.Drawing.Point(358, 492);
            this.lblTenkythuat.Name = "lblTenkythuat";
            this.lblTenkythuat.Size = new System.Drawing.Size(111, 13);
            this.lblTenkythuat.TabIndex = 295;
            this.lblTenkythuat.Text = "Tên dịch vụ kỹ thuật :";
            this.lblTenkythuat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTenkythuat.Visible = false;
            // 
            // frmPttt
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.lblTenkythuat);
            this.Controls.Add(this.p);
            this.Controls.Add(this.label48);
            this.Controls.Add(this.danhsach);
            this.Controls.Add(this.cmbNhomMau);
            this.Controls.Add(this.label46);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.butThemPP);
            this.Controls.Add(this.butThemcdS);
            this.Controls.Add(this.butThemcdT);
            this.Controls.Add(this.tylegiam);
            this.Controls.Add(this.label44);
            this.Controls.Add(this.label45);
            this.Controls.Add(this.molaimien);
            this.Controls.Add(this.stgiam);
            this.Controls.Add(this.label43);
            this.Controls.Add(this.butHinh);
            this.Controls.Add(this.chkXml);
            this.Controls.Add(this.butNhanvien);
            this.Controls.Add(this.pic);
            this.Controls.Add(this.ngayvao);
            this.Controls.Add(this.sothe);
            this.Controls.Add(this.label42);
            this.Controls.Add(this.butThem);
            this.Controls.Add(this.noisoi);
            this.Controls.Add(this.chkXem);
            this.Controls.Add(this.giovv);
            this.Controls.Add(this.ngayvv);
            this.Controls.Add(this.label41);
            this.Controls.Add(this.label40);
            this.Controls.Add(this.tenpttt);
            this.Controls.Add(this.lmau);
            this.Controls.Add(this.giokt);
            this.Controls.Add(this.gio);
            this.Controls.Add(this.mapt);
            this.Controls.Add(this.ngaykt);
            this.Controls.Add(this.ngay);
            this.Controls.Add(this.mabn3);
            this.Controls.Add(this.madoituong);
            this.Controls.Add(this.giuong);
            this.Controls.Add(this.tenkp);
            this.Controls.Add(this.label39);
            this.Controls.Add(this.butThuoc);
            this.Controls.Add(this.loaivp);
            this.Controls.Add(this.sotien);
            this.Controls.Add(this.mavp);
            this.Controls.Add(this.label38);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.loaibn);
            this.Controls.Add(this.somat);
            this.Controls.Add(this.mapmo);
            this.Controls.Add(this.lmat);
            this.Controls.Add(this.label37);
            this.Controls.Add(this.label36);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.butTuongtrinh);
            this.Controls.Add(this.mautuongtrinh);
            this.Controls.Add(this.chktuongtrinh);
            this.Controls.Add(this.tenmau);
            this.Controls.Add(this.label35);
            this.Controls.Add(this.tenhoisuc);
            this.Controls.Add(this.tenbsgayme);
            this.Controls.Add(this.tenphu1);
            this.Controls.Add(this.tenbs);
            this.Controls.Add(this.tendungcu);
            this.Controls.Add(this.dungcu);
            this.Controls.Add(this.hoisuc);
            this.Controls.Add(this.tenktvgayme);
            this.Controls.Add(this.ktvgayme);
            this.Controls.Add(this.bsgayme);
            this.Controls.Add(this.tenphu2);
            this.Controls.Add(this.phu2);
            this.Controls.Add(this.phu1);
            this.Controls.Add(this.label34);
            this.Controls.Add(this.label33);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.nhietdo);
            this.Controls.Add(this.huyetap);
            this.Controls.Add(this.mach);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.listBS);
            this.Controls.Add(this.listICD);
            this.Controls.Add(this.cd_s);
            this.Controls.Add(this.cd_t);
            this.Controls.Add(this.butPttt);
            this.Controls.Add(this.tenpt);
            this.Controls.Add(this.listpttt);
            this.Controls.Add(this.icd_s);
            this.Controls.Add(this.sophieu);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.butHuy);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butSua);
            this.Controls.Add(this.butMoi);
            this.Controls.Add(this.tuvong);
            this.Controls.Add(this.taibien);
            this.Controls.Add(this.tinhhinh);
            this.Controls.Add(this.mabs);
            this.Controls.Add(this.tenphuongphap);
            this.Controls.Add(this.phuongphap);
            this.Controls.Add(this.loaipt);
            this.Controls.Add(this.icd_t);
            this.Controls.Add(this.cd_vk);
            this.Controls.Add(this.icd_vk);
            this.Controls.Add(this.makp);
            this.Controls.Add(this.diachi);
            this.Controls.Add(this.phai);
            this.Controls.Add(this.tuoi);
            this.Controls.Add(this.mabn2);
            this.Controls.Add(this.hoten);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.mamau);
            this.Controls.Add(this.noidung);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmPttt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thông tin phẫu thủ thuật";
            this.Load += new System.EventHandler(this.frmPttt_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPttt_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.somat)).EndInit();
            this.p.ResumeLayout(false);
            this.p.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.danhsach.ResumeLayout(false);
            this.danhsach.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmPttt_Load(object sender, System.EventArgs e)
        {
            if (bbadt)
            {
                this.Location = new System.Drawing.Point(188 - 38, 120);//151
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                this.Size = new Size(829 + 40, 610);
            }

            i_maxlength_mabn = LibMedi.AccessData.i_maxlength_mabn;
            bQuanly_Theo_Chinhanh = m.bQuanly_Theo_Chinhanh;
            mabn3.MaxLength = i_maxlength_mabn - 2;

            this.WindowState = (Screen.PrimaryScreen.WorkingArea.Width > 800) ? System.Windows.Forms.FormWindowState.Normal : System.Windows.Forms.FormWindowState.Maximized;
            pathImage = m.pathImage;
            FileType = m.FileType;
            user = d.user;
            bPttt_tsoduoc = m.bPttt_tsoduoc;
            pic.Visible = m.bHinh || m.bChonhinh;
            chkXem.Checked = m.bPreview;
            bChidinh = m.bThuthuat_chidinh;
            
            label48.Visible = bChidinh;
            lblTenkythuat.Visible = bChidinh;

            i_nhomvp = m.iNhomvp_thuthuat;
            bSophieu = m.bSophieu_pttt;
            bHoisuc = m.bHoisuc_dungcu;
            bTiepdon_pttt = m.bTiepdon(LibMedi.AccessData.Phauthuthuat);
            bPttt_pmo = m.bPttt_phongmo;
            bPttt_vp = m.bPttt_vienphi;
            //
            f_capnhat_db();
            visibled_giam(bPttt_vp);
            //
            bPTTT_Xuatvien = m.bPTTT_Xuatvien;
            bEdit_vp = m.bEdit_pttt_vienphi;
            bPttt_thuoc = m.bPttt_thuoc;
            dsngay.ReadXml("..//..//..//xml//m_ngayvao.xml");
            dsloaibn.ReadXml("..//..//..//xml//m_loaibn.xml");
            dsxml.ReadXml("..//..//..//xml//m_pttt.xml");
            dsxml.Tables[0].Columns.Add("ngayrv");
            dsxml.Tables[0].Columns.Add("ttlrv");
            dsxml.Tables[0].Columns.Add("sovaovien");
            dsxml.Tables[0].Columns.Add("nhommau");
            dsxml.Tables[0].Columns.Add("tennn");
            dsxml.Tables[0].Columns.Add("ngaykt");
            bAdmin = m.bAdmin(m_userid);
            b_bacsi = m.bsPttt;
            bChandoan = m.bChandoan_icd10;
            butThuoc.Enabled = bPttt_thuoc;
            i_idcn = m.i_Chinhanh_hientai;
            sql = "select * from " + user + ".d_duockp where 1=1 ";
            if (i_idcn > 0) sql += " and chinhanh in(0," + i_idcn + ")";
            dtduockp = m.get_data(sql).Tables[0];
            tenkp.DisplayMember = "TENKP";
            tenkp.ValueMember = "MAKP";
            load_btdkp();

            mapmo.DisplayMember = "TEN";
            mapmo.ValueMember = "MA";
            if (bPttt_pmo) load_btdpm(makp.Text);
            mapmo.Enabled = bPttt_pmo;

            s_nhomvp_pttt = m.iNhompttt;
            sql = "select a.* from " + user + ".v_giavp a," + user + ".v_loaivp b where a.id_loai=b.id ";
            if (s_nhomvp_pttt.Trim().Trim(',') != "") sql += " and b.id_nhom in(" + s_nhomvp_pttt.Trim().Trim(',') + ")";
            dtmavp = m.get_data(sql).Tables[0];
            //dtmavp = m.get_data("select a.* from " + user + ".v_giavp a," + user + ".v_loaivp b where a.id_loai=b.id and b.id_nhom=" + m.iNhompttt).Tables[0];

            //
            sql = "select * from " + user + ".v_loaivp ";
            if (s_nhomvp_pttt.Trim().Trim(',') != "") sql += " where id_nhom in(" + s_nhomvp_pttt.Trim().Trim(',') + ")";
            sql += " order by stt";
            loaivp.DisplayMember = "TEN";
            loaivp.ValueMember = "ID";
            loaivp.DataSource = m.get_data(sql).Tables[0];// m.get_data("select * from " + user + ".v_loaivp where id_nhom=" + m.iNhompttt + " order by stt").Tables[0];

            ngayvao.DisplayMember = "NGAYVAO";
            ngayvao.ValueMember = "MAQL";
            ngayvao.DataSource = dsngay.Tables[0];

            mavp.DisplayMember = "TEN";
            mavp.ValueMember = "ID";

            sql = "select ma,ten,mapt,mabs,makp,noidung,mavp from " + user + ".pttt_mau";//,image1,image2
            if (bThuthuat) sql += " where mapt like '%TT%'";
            sql += " union all ";
            sql += "select mapt as ma,noi_dung as ten,mapt,'' as mabs,'' as makp,'' as noidung,mavp from " + user + ".dmpttt";//,null as image1, null as image2
            if (bThuthuat) sql += " where substring(mapt,1,1)='T'";
            dsmau = m.get_data(sql);
            sql = "select MAPT,NOI_DUNG,DACBIET,LOAI1,LOAI2,LOAI3 from " + user + ".dmpttt";
            if (bThuthuat) sql += " where substring(mapt,1,1)='T'";
            dtpt = m.get_data(sql).Tables[0];

            dtptpp = dtpt.Copy();
            dtptpp.Columns[0].ColumnName = "cicd10";
            dtptpp.Columns[1].ColumnName = "vviet";

            sql = "select a.ma,a.ten,a.mapt,a.mabs,a.makp,a.noidung,a.mavp,b.noi_dung as tenpt,b.loaipt from " + user + ".pttt_mau a," + user + ".dmpttt b where a.mapt=b.mapt and substring(a.mapt,1,1)='T'";
            sql += " union all ";
            sql += "select mapt as ma,noi_dung as ten,mapt,'' as mabs,'' as makp,'' as noidung,mavp,noi_dung as tenpt,loaipt from " + user + ".dmpttt where substring(mapt,1,1)='T'";
            dttt = m.get_data(sql).Tables[0];

            dttt.Columns.Add("chon", typeof(bool));
            foreach (DataRow r in dttt.Rows) r["chon"] = false;
            dataGrid1.DataSource = dttt;
            CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource];
            DataView dv = (DataView)cm.List;
            dv.AllowNew = false;
            AddGridTableStyle();

            this.disabledBackBrush = new SolidBrush(Color.FromArgb(255, 255, 192));
            this.disabledTextBrush = new SolidBrush(Color.FromArgb(255, 0, 0));

            this.alertBackBrush = new SolidBrush(SystemColors.HotTrack);
            this.alertFont = new Font(this.dataGrid1.Font.Name, this.dataGrid1.Font.Size, FontStyle.Bold);
            this.alertTextBrush = new SolidBrush(Color.White);

            this.currentRowFont = new Font(this.dataGrid1.Font.Name, this.dataGrid1.Font.Size, FontStyle.Regular);
            this.currentRowBackBrush = new SolidBrush(Color.FromArgb(0, 255, 255));

            listpttt.DisplayMember = "TEN";
            listpttt.ValueMember = "MA";
            listpttt.DataSource = dsmau.Tables[0];

            loaibn.DisplayMember = "TEN";
            loaibn.ValueMember = "ID";
            loaibn.DataSource = dsloaibn.Tables[0];

            tenphuongphap.DisplayMember = "TEN";
            tenphuongphap.ValueMember = "MA";
            tenphuongphap.DataSource = m.get_data("select * from " + user + ".dmmete order by ma").Tables[0];

            sql = "select a.*,to_char(madoituong) as madoituong1 from " + user + ".doituong a ";
            if (s_madoituong.Length >= 2) s_madoituong = s_madoituong.Substring(0, s_madoituong.Length - 1);
            if (s_madoituong != "") sql += " where madoituong in (" + s_madoituong + ")";
            sql += " order by madoituong";
            madoituong.DisplayMember = "DOITUONG";
            madoituong.ValueMember = "MADOITUONG";
            madoituong.DataSource = m.get_data(sql).Tables[0];

            loaipt.DisplayMember = "TEN";
            loaipt.ValueMember = "MA";
            loaipt.DataSource = m.get_data("select * from " + user + ".loaipttt order by ma").Tables[0];

            taibien.DisplayMember = "TEN";
            taibien.ValueMember = "MA";
            taibien.DataSource = m.get_data("select * from " + user + ".taibienpt order by ma").Tables[0];

            lmau.DisplayMember = "TEN";
            lmau.ValueMember = "MA";

            mautuongtrinh.DisplayMember = "TEN";
            mautuongtrinh.ValueMember = "NOIDUNG";

            tinhhinh.DisplayMember = "TEN";
            tinhhinh.ValueMember = "MA";
            tinhhinh.DataSource = m.get_data("select * from " + user + ".tinhhinhpt order by ma desc").Tables[0];

            tuvong.DisplayMember = "TEN";
            tuvong.ValueMember = "MA";
            tuvong.DataSource = m.get_data("select * from " + user + ".tuvongpt order by ma").Tables[0];


            dtbs = m.get_data("select * from " + user + ".dmbs where nhom not in (" + LibMedi.AccessData.nghiviec + ") order by ma").Tables[0];
            listBS.DisplayMember = "MA";
            listBS.ValueMember = "HOTEN";
            listBS.DataSource = dtbs;

            dticd = m.get_data("select cicd10,vviet from " + user + ".icd10 order by cicd10").Tables[0];
            listICD.DisplayMember = "CICD10";
            listICD.ValueMember = "VVIET";
            listICD.DataSource = dticd;

            s_msg = LibMedi.AccessData.Msg;
            songay = m.Ngaylv_Ngayht;
            mabn2.Text = DateTime.Now.Year.ToString().Substring(2, 2);
            loaibn.SelectedIndex = i_loaibn;

            //danhsach.Visible = bChidinh;
            danhsach.Visible = bChidinh && (list.Items.Count > 0);
            rdtt.Checked = m.Thongso("dschopttt") == "1";
            rdphauthuat.Checked = m.Thongso("dschopttt") == "2";
            rdtatca.Checked = m.Thongso("dschopttt") == "0";
            bPhauthuat = m.bNhapPTTTNgoaiTru_I10;
            if (m_mabn != "")
            {
                mabn2.Text = m_mabn.Substring(0, 2);
                //if (bQuanly_Theo_Chinhanh)
                //{
                mabn3.Text = m_mabn.Substring(2);
                //}
                //else
                //{
                //    mabn3.Text = m_mabn.Substring(2,6);
                //}
                l_maql = 0;
                l_idkhoa = 0;
                ena_object(true);
                emp_text();
                if (tenkp.SelectedIndex != -1) makp.Text = tenkp.SelectedValue.ToString();
                bStatus = true;
                mabn2.Enabled = false;
                mabn3.Enabled = false;
                makp.Enabled = false;
                tenkp.Enabled = false;
                load_mabn();//
                if (bChidinh)
                {
                    load_ref();
                }
                if (loaibn.Enabled) loaibn.Focus();
                else ngayvao.Focus();
            }
            else
            {
                if (bChidinh)
                {
                    list.DisplayMember = "HOTEN";
                    list.ValueMember = "MABN";
                    list.ColumnWidths[0] = 60;
                    list.ColumnWidths[1] = 180;
                    list.ColumnWidths[2] = 120;
                    list.ColumnWidths[3] = list.Width - 360;
                    load_ref();
                    danhsach.Visible = false;
                }
            }
        }

        private void load_ref()
        {
            string _ngaysrv = m.ngayhienhanh_server;
            string s_tu = m.DateToString("dd/MM/yyyy", m.StringToDate(_ngaysrv.Substring(0,10)).AddDays(-m.iNgaykiemke));
            sql = "select a.mabn,b.hoten||'('||b.namsinh||')' as hoten, kp.tenkp, c.ten||' ['||c.ma||']' as tenkythuat, a.mavaovien,a.maql,a.idkhoa,a.makp,a.madoituong,a.id,a.loai ";
            sql +=" from " + user + m.mmyy(_ngaysrv) + ".v_chidinh a," + user + ".btdbn b,"+user+".v_giavp c,"+user+".v_loaivp d,"+user+".btdkp_bv kp ";
            sql += " where a.mabn=b.mabn and a.mavp=c.id and c.id_loai=d.id and a.makp=kp.makp ";
            sql += " and a.done=0 and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + s_tu + "','dd/mm/yyyy') and to_date('" + _ngaysrv.Substring(0, 10) + "','dd/mm/yyyy')";
            if(i_nhomvp!="")
            {
                sql += "and d.id_nhom in(" + i_nhomvp + ") ";
            }
            if (s_makp != "")
            {
                //kiem tra khoa pt gây mê hoi suc
                bool bphongmo = false;
                string[] smakp=s_makp.Split(',');
                foreach (string _makp in smakp)
                {
                    if (m.ma_phongmo(_makp))
                    {
                        bphongmo = true;
                        break;
                    }
                }
                //
                if (!bphongmo)
                {
                    string s = s_makp.Replace(",", "','");
                    sql += " and a.makp in ('" + s.Substring(0, s.Length - 3) + "')";
                }
            }
            if (rdtt.Checked) sql += " and kp.loai=1";
            else if (rdphauthuat.Checked) sql += " and kp.loai=0";
            sql += " order by a.makp,a.ngay,a.mabn";
            dtlist = m.get_data(sql).Tables[0];
            list.DataSource = dtlist;
            lblso.Text = list.Items.Count.ToString();
        }

        private void AddGridTableStyle()
        {
            DataGridTableStyle ts = new DataGridTableStyle();
            ts.MappingName = dttt.TableName;
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
            discontinuedCol.Width = 35;
            discontinuedCol.AllowNull = false;

            discontinuedCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
            discontinuedCol.BoolValueChanged += new BoolValueChangedEventHandler(BoolValueChanged);
            ts.GridColumnStyles.Add(discontinuedCol);
            dataGrid1.TableStyles.Add(ts);

            FormattableTextBoxColumn TextCol = new FormattableTextBoxColumn();
            TextCol.MappingName = "ma";
            TextCol.HeaderText = "Mã";
            TextCol.Width = 65;
            TextCol.ReadOnly = true;
            TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new FormattableTextBoxColumn();
            TextCol.MappingName = "ten";
            TextCol.HeaderText = "Phương pháp";
            TextCol.Width = 405;
            TextCol.ReadOnly = true;
            TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);
        }

        private void SetCellFormat(object sender, DataGridFormatCellEventArgs e)
        {
            try
            {
                bool discontinued = (bool)((e.Column != 0) ? this.dataGrid1[e.Row, 0] : e.CurrentCellValue);
                if (e.Column > 0 && (bool)(this.dataGrid1[e.Row, 0]))//discontinued)
                {
                    e.ForeBrush = this.disabledTextBrush;
                }
                else if (e.Column > 0 && e.Row == this.dataGrid1.CurrentRowIndex)//discontinued)
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

		private void makp_Validated(object sender, System.EventArgs e)
		{
			try
			{
				tenkp.SelectedValue=makp.Text;
				DataRow r=m.getrowbyid(dtkp,"makpbo='25' and makp='"+makp.Text+"'");
				bMat=r!=null;
				lmat.Visible=bMat;
				somat.Visible=bMat;
				load_btdpm(makp.Text);
			}
			catch{}
		}

		private void makp_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{F4}");
		}

		private void tenkp_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				if (tenkp.SelectedIndex==-1) tenkp.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void tenkp_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tenkp)
			{
				makp.Text=tenkp.SelectedValue.ToString();
				DataRow r=m.getrowbyid(dtkp,"makpbo='25' and makp='"+makp.Text+"'");
				bMat=r!=null;
				lmat.Visible=bMat;
				somat.Visible=bMat;
				load_btdpm(makp.Text);
			}
		}

		private void load_btdkp()
		{
            sql = "select * from " + user + ".btdkp_bv ";
            if (i_idcn > 0) sql += " where chinhanh in(0," + i_idcn + ")";
            if (s_makp != "")
            {
                //kiem tra khoa hoi suc cap cuu
                bool bphongmo = false;
                string[] smakp = s_makp.Split(',');
                foreach (string _makp in smakp)
                {
                    if (m.ma_phongmo(_makp))
                    {
                        bphongmo = true;
                        break;
                    }
                }
                //
                if (!bphongmo)
                {
                    string s = s_makp.Replace(",", "','");
                    if (s.Length >= 3) s = s.Substring(0, s.Length - 3);
                    if (i_idcn > 0)
                    {
                        sql += " and makp in ('" + s + "')";
                    }
                    else
                    {
                        sql += " where makp in ('" + s + "')";
                    }
                }
                //
                
            }
            sql+=" order by loai,makp";
			dtkp=m.get_data(sql).Tables[0];
            if (dtkp.Rows.Count == 0) dtkp = m.get_data("select * from " + user + ".btdkp_bv order by loai,makp").Tables[0];
			tenkp.DataSource=dtkp;
			makp.Text=tenkp.SelectedValue.ToString();
		}

		private void mabn2_Validated(object sender, System.EventArgs e)
		{
			mabn2.Text=mabn2.Text.PadLeft(2,'0');
		}

		private void mabn3_Validated(object sender, System.EventArgs e)
		{
            if (bChidinh) danhsach.Visible = false;
            l_idchidinh = 0;
            bCapso = false; l_id = 0;
            if (pic.Visible)
            {
                pic.Tag = "0000.bmp";
                fstr = new System.IO.FileStream(pic.Tag.ToString(), System.IO.FileMode.Open, System.IO.FileAccess.Read);
                map = new Bitmap(Image.FromStream(fstr));
                pic.Image = (Bitmap)map;
            }
			if (mabn3.Text=="" && butLuu.Enabled)
			{
				if (makp.Text=="")
				{
					makp.Focus();
					return;
				}
				if (mabn2.Text=="")
				{
					mabn2.Focus();return;
				}
				if (m.get_capso(makp.Text))
				{
					bCapso=true;
					mabn3.Text=m.get_mabn(int.Parse(mabn2.Text),2,int.Parse(makp.Text),true).ToString().PadLeft(6,'0');
                    s_mabn = mabn2.Text + mabn3.Text;
					frmSuahc f=new frmSuahc(m,"",m_userid,false,mabn2.Text+mabn3.Text);
					f.ShowDialog(this);
					if (f.m_mabn!="")
					{
						sql="select a.*,nullif(b.tentt,' ') as tentt,nullif(c.tenquan,' ') as tenquan,nullif(d.tenpxa,' ') as tenpxa ";
                        sql+=" from "+user+".btdbn a left join "+user+".btdtt b on a.matt=b.matt ";
                        sql+=" left join "+user+".btdquan c on a.maqu=c.maqu";
                        sql+=" left join "+user+".btdpxa d on a.maphuongxa=d.maphuongxa";
						sql+=" where a.mabn='"+s_mabn+"'";
						foreach(DataRow r in m.get_data(sql).Tables[0].Rows)
						{
							hoten.Text=r["hoten"].ToString();
							phai.Text=(r["phai"].ToString()=="0")?"Nam":"Nữ";
							diachi.Text=r["sonha"].ToString()+" "+r["thon"].ToString()+" "+r["tenpxa"].ToString().Trim()+"-"+r["tenquan"].ToString().Trim()+"-"+r["tentt"].ToString().Trim();
							int ituoi=DateTime.Now.Year-int.Parse(r["namsinh"].ToString());
							tuoi.Text=ituoi.ToString();
                            try
                            {
                                loaibn.SelectedIndex = 4;
                                loaibn.Refresh();
                            }
                            catch { }
                            l_maql = m.getidyymmddhhmiss_stt_computer;//get_capid(1);
                            m.upd_tiepdon(s_mabn, l_maql, l_maql,makp.Text, ngayvv.Text + " " + giovv.Text, (madoituong.SelectedIndex != -1) ? int.Parse(madoituong.SelectedValue.ToString()) : 2, "", ituoi.ToString().PadLeft(3, '0') + "0", m_userid,0,LibMedi.AccessData.Pttt, 0);
                            m.upd_lienhe(ngayvv.Text + " " + giovv.Text, l_maql, r["sonha"].ToString(),r["thon"].ToString(), r["cholam"].ToString(), r["matt"].ToString(), r["maqu"].ToString(), r["maphuongxa"].ToString(), ituoi.ToString().PadLeft(3, '0') + "0", 0, 0);
							break;
						}
						ngayvv.Enabled=true;giovv.Enabled=true;
						ngayvv.Text=m.Ngaygio_hienhanh.Substring(0,10);
						giovv.Text=m.Ngaygio_hienhanh.Substring(11);
					}
					else
					{
						makp.Focus();
						return;
					}
				}
			}
			if (mabn3.Text=="") 
			{
				mabn2.Focus();
				return;
			}
			mabn3.Text=mabn3.Text.PadLeft(6,'0');
            l_maql = p_maql; l_mavaovien = p_mavaovien; l_idkhoa = p_idkhoa;
			if (mabn2.Text+mabn3.Text!=m_mabn) 
			{
				int iRet=load_mabn();
				if (iRet!=0)
				{
					if (bTiepdon_pttt && butLuu.Enabled)
					{
						if (MessageBox.Show(lan.Change_language_MessageText("Chưa có thông tin hành chính.Bạn có muốn nhập không ?"),s_msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)==DialogResult.Yes)
						{
							frmSuahc f=new frmSuahc(m,"",m_userid,false,mabn2.Text+mabn3.Text);
							f.ShowDialog(this);
							if (f.m_mabn!="")
							{
                                sql = "select a.*,nullif(b.tentt,' ') as tentt,nullif(c.tenquan,' ') as tenquan,nullif(d.tenpxa,' ') as tenpxa ";
                                sql += " from " + user + ".btdbn a left join " + user + ".btdtt b on a.matt=b.matt ";
                                sql += " left join " + user + ".btdquan c on a.maqu=c.maqu";
                                sql += " left join " + user + ".btdpxa d on a.maphuongxa=d.maphuongxa";
                                sql += " where a.mabn='" + s_mabn + "'";
								foreach(DataRow r in m.get_data(sql).Tables[0].Rows)
								{
									hoten.Text=r["hoten"].ToString();
									phai.Text=(r["phai"].ToString()=="0")?"Nam":"Nữ";
									diachi.Text=r["sonha"].ToString()+" "+r["thon"].ToString()+" "+r["tenpxa"].ToString().Trim()+"-"+r["tenquan"].ToString().Trim()+"-"+r["tentt"].ToString().Trim();
									int ituoi=DateTime.Now.Year-int.Parse(r["namsinh"].ToString());
									tuoi.Text=ituoi.ToString();
									break;
								}
								ngayvv.Enabled=true;giovv.Enabled=true;
								ngayvv.Text=m.Ngaygio_hienhanh.Substring(0,10);
								giovv.Text=m.Ngaygio_hienhanh.Substring(11);
							}
							else
							{
								makp.Focus();
								return;
							}
						}
						else
						{
							makp.Focus();
							return;
						}
					}
					else
					{
						string msg=(iRet==1)?lan.Change_language_MessageText("Thông tin hành chính không tìm thấy !"):lan.Change_language_MessageText("Bệnh nhân chưa nhập khoa !")+tenkp.Text.Trim();
						MessageBox.Show(msg,s_msg);
						makp.Focus();
						return;
					}
				}
			}
		}

		private int load_mabn()
		{
			s_mabn=mabn2.Text+mabn3.Text;
			int ret=1,ituoi;
            sql = "select a.*,nullif(b.tentt,' ') as tentt,nullif(c.tenquan,' ') as tenquan,nullif(d.tenpxa,' ') as tenpxa ";
            sql += " from " + user + ".btdbn a left join " + user + ".btdtt b on a.matt=b.matt ";
            sql += " left join " + user + ".btdquan c on a.maqu=c.maqu";
            sql += " left join " + user + ".btdpxa d on a.maphuongxa=d.maphuongxa";
            sql += " where a.mabn='" + s_mabn + "'";

			foreach(DataRow r in m.get_data(sql).Tables[0].Rows)
			{
                nam = r["nam"].ToString();
				hoten.Text=r["hoten"].ToString();
				phai.Text=(r["phai"].ToString()=="0")?"Nam":"Nữ";
				diachi.Text=r["sonha"].ToString()+" "+r["thon"].ToString()+" "+r["tenpxa"].ToString().Trim()+"-"+r["tenquan"].ToString().Trim()+"-"+r["tentt"].ToString().Trim();
				ituoi=DateTime.Now.Year-int.Parse(r["namsinh"].ToString());
				tuoi.Text=ituoi.ToString();
				ret=0;
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
				break;
			}
			if (ret==0)
			{
                if (butMoi.Enabled)
                {
                    if (p_maql != 0)
                    {
                        l_maql = p_maql; l_mavaovien = p_mavaovien; l_idkhoa = p_idkhoa;
                    }
                    load_treeView();
                    //load_pttt("", "");
                }
                else
                {
                    DataSet ds1;
                    if (nam == "") nam = m.mmyy(m.ngayhienhanh_server) + "+";
                    if (loaibn.SelectedIndex ==0)
                    {
                        sql = "select 0 as loai,1 as loaiba,maql,to_char(ngay,'dd/mm/yyyy hh24:mi') as ngayvao,madoituong,to_char(ngay,'yymmddhh24mi') as yymmdd,makp ";
                        sql += " from "+user+".benhandt where mabn='" + s_mabn + "'";
                        ds1 = m.get_data(sql);
                    }
                    else if (loaibn.SelectedIndex == 1)
                    {
                        sql = "select 0 as loai,2 as loaiba,maql,to_char(ngay,'dd/mm/yyyy hh24:mi') as ngayvao,madoituong,to_char(ngay,'yymmddhh24mi') as yymmdd,makp ";
                        sql += " from " + user + ".benhanngtr where mabn='" + s_mabn + "'";
                        ds1 = m.get_data(sql);
                    }
                    else if (loaibn.SelectedIndex == 2)
                    {
                        sql = "select 0 as loai,4 as loaiba,maql,to_char(ngay,'dd/mm/yyyy hh24:mi') as ngayvao,madoituong,to_char(ngay,'yymmddhh24mi') as yymmdd,makp ";
                        sql += " from xxx.benhancc where mabn='" + s_mabn + "'";
                        ds1 = m.get_data_nam(nam, sql);
                    }
                    else if (loaibn.SelectedIndex == 3)
                    {
                        sql = "select 1 as loai,3 as loaiba,a.maql,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayvao,a.madoituong,to_char(a.ngay,'yymmddhh24mi') as yymmdd,a.makp from xxx.benhanpk a ";
                        sql += " where a.mabn='" + s_mabn + "'";
                        ds1 = m.get_data_nam(nam, sql);
                    }
                    else
                    {
                        sql = "select 2 as loai,3 as loaiba,a.maql,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayvao,";
                        sql += " a.madoituong,to_char(a.ngay,'yymmddhh24mi') as yymmdd,makp from xxx.tiepdon a where noitiepdon in (0,17) ";
                        sql += " and a.mabn='" + s_mabn + "'";
                        ds1 = m.get_data_nam(nam, sql);
                    }

                    dsngay.Clear();
                    DataRow r1;
                    foreach (DataRow r in ds1.Tables[0].Select("true", "yymmdd desc,loai,loaiba"))
                    {
                        r1 = dsngay.Tables[0].NewRow();
                        r1["maql"] = r["maql"].ToString();
                        r1["ngayvao"] = r["ngayvao"].ToString();
                        r1["madoituong"] = r["madoituong"].ToString();
                        r1["maphu"] = r["loai"].ToString();
                        dsngay.Tables[0].Rows.Add(r1);
                    }
                    ngayvao.DataSource = dsngay.Tables[0];
                    if (dsngay.Tables[0].Rows.Count > 0) ngayvao.SelectedIndex = 0;
                    l_maql = (ngayvao.SelectedIndex != -1) ? decimal.Parse(ngayvao.SelectedValue.ToString()) : 0;
                    if (l_maql != 0)
                    {
                        s_ngay = ngayvao.Text;

                        makp.Text=m.getrowbyid(ds1.Tables[0],"ngayvao like '%"+s_ngay+"%'")["makp"].ToString();
                        makp_Validated(null, null);//Khuong 01/12/2011

                        ngayvv.Text = s_ngay.Substring(0, 10);
                        giovv.Text = s_ngay.Substring(11);
                        load_vv(false);
                    }
                    load_treeView();
                }
				if (ngayvv.Text=="")
				{
					ngayvv.Enabled=true;giovv.Enabled=true;
					ngayvv.Text=m.Ngaygio_hienhanh.Substring(0,10);
					giovv.Text=m.Ngaygio_hienhanh.Substring(11);
				}
			}
			return ret;
		}

		private void ngay_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void icd_t_Validated(object sender, System.EventArgs e)
		{
			if (icd_t.Text!=s_icd_t)
			{
				if (icd_t.Text=="") cd_t.Text="";
				else cd_t.Text=m.get_vviet(icd_t.Text).Trim();
				if (cd_t.Text=="" && icd_t.Text!="")
				{
                    dllDanhmucMedisoft.frmDMICD10 f = new dllDanhmucMedisoft.frmDMICD10(m, "icd10", icd_t.Text, cd_t.Text, true);
					f.ShowDialog();
					if (f.mICD!="")
					{
						cd_t.Text=f.mTen;
						icd_t.Text=f.mICD;
					}
				}
				if (cd_s.Text=="")
				{
					cd_s.Text=cd_t.Text;
					icd_s.Text=icd_t.Text;
					s_icd_s=icd_s.Text;
					if (cd_vk.Text=="")
					{
						cd_vk.Text=cd_t.Text;
						icd_vk.Text=icd_t.Text;
					}
				}
				s_icd_t=icd_t.Text;
			}
		}

		private void cd_t_Validated(object sender, System.EventArgs e)
		{
			if (icd_t.Text=="") icd_t.Text=m.get_cicd10(cd_t.Text);
			if (!m.bMaicd(icd_t.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Mã ICD10 này không có trong danh mục !"),s_msg);
				icd_t.Text="";
				icd_t.Focus();
			}
		}

		private void icd_s_Validated(object sender, System.EventArgs e)
		{
			if (icd_s.Text!=s_icd_s)
			{
				if (icd_s.Text=="") cd_s.Text="";
				else cd_s.Text=m.get_vviet(icd_s.Text).Trim();
				if (cd_s.Text=="" && icd_s.Text!="")
				{
                    dllDanhmucMedisoft.frmDMICD10 f = new dllDanhmucMedisoft.frmDMICD10(m, "icd10", icd_s.Text, cd_s.Text, true);
					f.ShowDialog();
					if (f.mICD!="")
					{
						cd_s.Text=f.mTen;
						icd_s.Text=f.mICD;
					}
				}
				s_icd_s=icd_s.Text;
			}
		}

		private void cd_s_Validated(object sender, System.EventArgs e)
		{
			if (icd_s.Text=="") icd_s.Text=m.get_cicd10(cd_s.Text);
			if (!m.bMaicd(icd_s.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Mã ICD10 này không có trong danh mục !"),s_msg);
				icd_s.Text="";
				icd_s.Focus();
			}
		}

		private void mapt_Validated(object sender, System.EventArgs e)
		{
			string s=m.get_tenpt(mapt.Text).Trim();
			if (s!="")
			{
				tenpt.Text=s.Substring(1);
				loaipt.SelectedValue=s.Substring(0,1);
			}
			else tenpt.Text="";
		}

		private void phuongphap_Validated(object sender, System.EventArgs e)
		{
			try
			{
				tenphuongphap.SelectedValue=phuongphap.Text;
			}
			catch{}
		}

		private void phuongphap_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{F4}");
		}

		private void tenphuongphap_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				if (tenphuongphap.SelectedIndex==-1) tenphuongphap.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void tenphuongphap_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				phuongphap.Text=tenphuongphap.SelectedValue.ToString();
			}
			catch{}
		}

		private void tinhhinh_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{F4}");
		}

		private void taibien_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{F4}");
		}

		private void tuvong_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void ena_object(bool ena)
		{
			bCapso=false;
			butTuongtrinh.Checked=false;
			noidung.Visible=false;
			noidung.Enabled=ena;
			if (bSophieu) sophieu.Enabled=ena;
			ngay.Enabled=ena;
           //28.12.2011 bỏ if
            //if (!bThuthuat)
            //{
            cd_t.Enabled = ena;
            icd_t.Enabled = ena;
            cd_s.Enabled = ena;
            icd_s.Enabled = ena;
            //}
			if (somat.Visible) somat.Enabled=ena;
			if (bEdit_vp) loaivp.Enabled=ena;
			mavp.Enabled=loaivp.Enabled;
			madoituong.Enabled=ena;
            ngayvao.Enabled = ena;
			loaibn.Enabled=ena;
			molaimien.Enabled=ena;
            noisoi.Enabled = ena;
            butThem.Enabled = ena;
			chktuongtrinh.Checked=false;
			phuongphap.Enabled=ena;
			tenphuongphap.Enabled=ena;
			ngaykt.Enabled=ena;
			mach.Enabled=ena;
			nhietdo.Enabled=ena;
			huyetap.Enabled=ena;
			//mamau.Enabled=ena;
			tenmau.Enabled=ena;
			phu1.Enabled=ena;
			tenphu1.Enabled=ena;
			phu2.Enabled=ena;
			tenphu2.Enabled=ena;
			bsgayme.Enabled=ena;
			tenbsgayme.Enabled=ena;
			ktvgayme.Enabled=ena;
			tenktvgayme.Enabled=ena;
			gio.Enabled=ena;
			giokt.Enabled=ena;
			lmau.Enabled=ena;
			tenpttt.Enabled=ena;
            butThemcdS.Enabled = ena;
            butThemcdT.Enabled = ena;
            butThemPP.Enabled = ena;
            //
            if(bPttt_vp)enabled_giam(ena);
            else enabled_giam(false);
            //
			if (bHoisuc)
			{
				hoisuc.Enabled=ena;
				tenhoisuc.Enabled=ena;
				dungcu.Enabled=ena;
				tendungcu.Enabled=ena;
			}
			//mautuongtrinh.Enabled=ena;
			chktuongtrinh.Enabled=ena;
			mabs.Enabled=ena;
			tenbs.Enabled=ena;
			tinhhinh.Enabled=ena;
			taibien.Enabled=ena;
			tuvong.Enabled=ena;
			butMoi.Enabled=!ena;
			butSua.Enabled=!ena;
			butLuu.Enabled=ena;
			butHinh.Enabled=butBoqua.Enabled=ena;
			butHuy.Enabled=!ena;
			butIn.Enabled=!ena;
            butNhanvien.Enabled = ena;
			butKetthuc.Enabled=!ena;
			if (ena && !bThuthuat)
			{
                //28.12.2011 bỏ dk tắt cd_t,cd_s
                //cd_t.Enabled=m.bChandoan;
                //cd_s.Enabled=cd_t.Enabled;
			}
			else
			{
				ngayvv.Enabled=ena;
				giovv.Enabled=ena;
			}
            treeView1.Enabled = !ena;
            cmbNhomMau.Enabled = ena;
		}

        private void emp_text()
        {
            treeView1.Nodes.Clear();
            molaimien.Checked = false; noisoi.Checked = false;
            if (somat.Visible) somat.Value = 1;
            nam = ""; sophieu.Text = "";
            mabn2.Text = DateTime.Now.Year.ToString().Substring(2, 2);
            mabn3.Text = ""; cd_t.Text = ""; icd_t.Text = "";
            cd_s.Text = ""; icd_s.Text = ""; mapt.Text = "";
            tenpt.Text = ""; mach.Text = ""; nhietdo.Text = "";
            huyetap.Text = ""; mamau.Text = ""; tenmau.Text = "";
            phu1.Text = ""; tenphu1.Text = ""; phu2.Text = "";
            tenphu2.Text = ""; bsgayme.Text = ""; tenbsgayme.Text = "";
            ktvgayme.Text = ""; tenktvgayme.Text = ""; hoisuc.Text = "";
            tenhoisuc.Text = ""; dungcu.Text = ""; tendungcu.Text = "";
            noidung.Text = ""; tenpttt.Text = "";
            lmau.SelectedIndex = -1;
            mautuongtrinh.SelectedIndex = -1;
            loaipt.SelectedIndex = -1;
            tinhhinh.SelectedIndex = 0;
            taibien.SelectedIndex = 0;
            tuvong.SelectedIndex = 0;
            tenphuongphap.SelectedIndex = -1;
            loaivp.SelectedIndex = -1;
            mavp.SelectedIndex = -1;
            hoten.Text = m_hoten;
            tuoi.Text = m_tuoi;
            phai.Text = m_phai;
            diachi.Text = m_diachi;
            sothe.Text = m_sothe;
            giuong.Text = m_giuong;
            ngayvv.Text = m.Ngaygio_hienhanh.Substring(0, 10);
            giovv.Text = m.Ngaygio_hienhanh.Substring(11);
            cd_vk.Text = m_cd_vk;
            icd_vk.Text = m_icd_vk;
            int dd = DateTime.Now.Day;
            int mm = DateTime.Now.Month;
            int yyyy = DateTime.Now.Year;
            int hh = DateTime.Now.Hour;
            int mi = DateTime.Now.Minute;
            ngay.Text = m.Ngaygio_hienhanh.Substring(0, 10);
            ngaykt.Text = ngay.Text;
            gio.Text = m.Ngaygio_hienhanh.Substring(11);
            giokt.Text = gio.Text;
            s_ngay = ngay.Text;
            s_icd_t = ""; s_icd_s = "";
            tylegiam.Text = stgiam.Text = "0";
            foreach (DataRow r in dttt.Rows) r["chon"] = false;
            if (m_mabn != "")
            {
                mabn2.Text = m_mabn.Substring(0, 2);
                if (bQuanly_Theo_Chinhanh)
                {
                    mabn3.Text = m_mabn.Substring(2, i_maxlength_mabn - 2);
                }
                else
                {
                    mabn3.Text = m_mabn.Substring(2,6);
                }
                
                tenkp.SelectedValue = m_makp;
                makp.Text = m_makp;
            }
            dtIcdt = m.get_data("select maicd,chandoan,userid from " + user + ".pttt_chandoan where 0=1").Tables[0];
            
            dtIcds = dtIcdt.Clone();

            dtPhuongPhap = dtIcdt.Clone();
            

            butThemcdT.ForeColor = Color.Black;
            butThemcdS.ForeColor = Color.Black;
            lblTenkythuat.Text = "";
        }

		private void butMoi_Click(object sender, System.EventArgs e)
		{
			ena_object(true);
			emp_text();
            i_traituyen = 0;
			bStatus=true;
            //if (m_mabn == "")
            //{
                if (bChidinh)
                {
                    load_ref();
                    danhsach.Visible = (list.Items.Count > 0);
                    if (danhsach.Visible)
                    {
                        danhsach.BringToFront();
                    }
                    if (!danhsach.Visible)
                    {
                        if (loaibn.Enabled) loaibn.Focus();
                        else makp.Focus();
                    }
                    else list.Focus();
                }
                else if (loaibn.Enabled) loaibn.Focus();
                else makp.Focus();
            //}           
            //else sophieu.Focus();
		}

		private void butSua_Click(object sender, System.EventArgs e)
		{
			if (hoten.Text=="") return;
			bStatus=false;
			try
			{
				foreach(DataRow r in m.get_data("select id,mavaovien,maql,idkhoa,idvpkhoa,idduoc,idchidinh from "+user+d.mmyy(ngay.Text)+".pttt where mabn='"+s_mabn+"' and to_char(ngay,'dd/mm/yyyy hh24:mi')='"+ngay.Text+" "+gio.Text+"'").Tables[0].Rows)
				{
					l_id=decimal.Parse(r["id"].ToString());
					l_idkhoa=decimal.Parse(r["idkhoa"].ToString());
					l_idduoc=decimal.Parse(r["idduoc"].ToString());
					l_idvpkhoa=decimal.Parse(r["idvpkhoa"].ToString());
					l_maql=decimal.Parse(r["maql"].ToString());
                    l_mavaovien = decimal.Parse(r["mavaovien"].ToString());
                    l_idchidinh = decimal.Parse(r["idchidinh"].ToString());
				}
			}
			catch{}
			ena_object(true);
            butThem.Enabled = false;
			sophieu.Focus();
		}

		private bool kiemtra()
		{
			if (tenkp.SelectedIndex==-1)
			{
				makp.Focus();
				return false;
			}
			if (hoten.Text=="")
			{
				mabn3.Focus();
				return false;
			}
			if (tenpttt.Text=="")
			{
				tenpttt.Focus();
				return false;
			}
			if (sophieu.Text=="" && sophieu.Enabled)
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập số phiếu phẫu thuật / thủ thuật !"),s_msg);
				sophieu.Focus();
				return false;
			}
            if ((!bPTTT_Xuatvien || bPttt_vp) && !butMoi.Enabled && ngayvao.SelectedIndex >= 0)
            {
                bool bln = bDaxuatvien(mabn2.Text.PadLeft(2, '0') + mabn3.Text.PadLeft(i_maxlength_mabn-2, '0'), decimal.Parse(ngayvao.SelectedValue.ToString()));
                if (bln)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân này đã xuất viện !"), "PTTT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
			if (bChandoan && !bThuthuat)
			{
				if (cd_t.Text=="" || icd_t.Text=="")
				{
					MessageBox.Show(lan.Change_language_MessageText("Chẩn đoán trước phẫu thuật / thủ thuật !"),s_msg);
					icd_t.Focus();
					return false;
				}
				if (!m.Kiemtra_maicd(dticd,icd_t.Text))
				{
					MessageBox.Show(lan.Change_language_MessageText("Mã ICD không hợp lệ !"),LibMedi.AccessData.Msg);
					icd_t.Focus();
					return false;
				}
				if (!m.Kiemtra_tenbenh(dticd,cd_t.Text))
				{
					MessageBox.Show(lan.Change_language_MessageText("Chẩn đoán không hợp lệ !"),LibMedi.AccessData.Msg);
					cd_t.Focus();
					return false;
				}
				if (cd_s.Text=="" || icd_s.Text=="")
				{
					MessageBox.Show(lan.Change_language_MessageText("Chẩn đoán sau phẫu thuật / thủ thuật !"),s_msg);
					icd_s.Focus();
					return false;
				}
				if (!m.Kiemtra_maicd(dticd,icd_s.Text))
				{
					MessageBox.Show(lan.Change_language_MessageText("Mã ICD không hợp lệ !"),LibMedi.AccessData.Msg);
					icd_s.Focus();
					return false;
				}
				if (!m.Kiemtra_tenbenh(dticd,cd_s.Text))
				{
					MessageBox.Show(lan.Change_language_MessageText("Chẩn đoán không hợp lệ !"),LibMedi.AccessData.Msg);
					cd_s.Focus();
					return false;
				}
			}
			if (mapt.Text=="" || tenpt.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Phương pháp phẫu thuật / thủ thuật !"),s_msg);
				mapt.Focus();
				return false;
			}

			if (!m.Kiemtra_mapt(dtpt,mapt.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Mã phẫu thuật - thủ thuật không hợp lệ !"),LibMedi.AccessData.Msg);
				mapt.Focus();
				return false;
			}
			if (!m.Kiemtra_tenpt(dtpt,tenpt.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Tên phẫu thuật - thủ thuật không hợp lệ !"),LibMedi.AccessData.Msg);
				tenpt.Focus();
				return false;
			}
			if (tenphuongphap.SelectedIndex==-1)
			{
				MessageBox.Show(lan.Change_language_MessageText("Phương pháp vô cảm !"),s_msg);
				phuongphap.Focus();
				return false;
			}

			if (mabs.Text=="" || tenbs.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Phẫu thuật / thủ thuật viên !"),s_msg);
				mabs.Focus();
				return false;
			}

			if (!m.bNgaygio(ngaykt.Text+" "+giokt.Text,ngay.Text+" "+gio.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Ngày giờ kết thúc không được nhỏ hơn ngày giờ bắt đầu !"),s_msg);
				ngaykt.Focus();
				return false;
			}
			if (m_ngayra!="")
			{
				if (!m.bNgaygio(m_ngayra,ngaykt.Text+" "+giokt.Text))
				{
					MessageBox.Show(lan.Change_language_MessageText("Ngày phẫu thuật / thủ thuật không được lớn hơn ngày ra viện !"),s_msg);
					ngay.Focus();
					return false;
				}
			}
			if (bPttt_pmo)
			{
				if (mapmo.SelectedIndex==-1)
				{
					MessageBox.Show(lan.Change_language_MessageText("Chọn phòng mỗ !"),LibMedi.AccessData.Msg);
					mapmo.Focus();
					return false;
				}
			}
			if (madoituong.SelectedIndex==-1)
			{
				MessageBox.Show(lan.Change_language_MessageText("Chọn đối tượng !"),s_msg);
				madoituong.Focus();
				return false;
			}
            if (ngayvao.SelectedIndex == -1)
            {
                MessageBox.Show(lan.Change_language_MessageText("Chọn ngày vào !"), LibMedi.AccessData.Msg);
                ngayvao.Focus();
                return false;
            }
            if (bChidinh && bStatus)
            {
                if (mapt.Text.IndexOf("T") != -1)
                {
                    DataRow r1 = m.getrowbyid(dtlist, "mabn='" + mabn2.Text + mabn3.Text + "'");
                    if (r1 == null)
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Người bệnh ") + hoten.Text + "\n"+lan.Change_language_MessageText("Chưa được chỉ định !"), LibMedi.AccessData.Msg);
                        butMoi.Focus();
                        return false;
                    }
                }
            }
            if (!m.bMmyy(ngay.Text)) m.tao_schema(m.mmyy(ngay.Text), m_userid);
            if (bStatus)
            {
                if (m.get_data("select * from " + user + m.mmyy(ngay.Text) + ".pttt where mabn='" + mabn2.Text + mabn3.Text + "' and to_char(ngay,'dd/mm/yyyy hh24:mi')='" + ngay.Text + " " + gio.Text + "'").Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Người bệnh ") + hoten.Text + "\n" + lan.Change_language_MessageText("Đã nhập ngày ") + ngay.Text + " " + gio.Text, LibMedi.AccessData.Msg);
                    ngay.Focus();
                    return false;
                }
            }
			return true;
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			if (!kiemtra()) return;
            int itable = m.tableid(m.mmyy(ngay.Text), "pttt");
            if (bStatus)
            {
                if (nam.IndexOf(m.mmyy(ngay.Text) + "+") == -1)
                {
                    nam = nam + m.mmyy(ngay.Text) + "+";
                    m.execute_data("update " + user + ".btdbn set nam='" + nam + "' where mabn='" + mabn2.Text + mabn3.Text + "'");
                }
                l_id = m.getidyymmddhhmiss_stt_computer;// m.get_capid(6);
                if (bPttt_vp && !molaimien.Checked && mavp.SelectedIndex != -1)
                {
                    if (loaibn.SelectedIndex == 4 && m.get_capso(makp.Text))
                        l_idvpkhoa = v.get_id_chidinh;
                    else
                        l_idvpkhoa = v.get_id_vpkhoa;
                }
                if (bPttt_thuoc) l_idduoc = d.get_id_xuatsd;
                m.upd_eve_tables(ngay.Text,itable, m_userid, "ins");
            }
            else
            {
                if (!bAdmin)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Bạn không có quyền chỉnh sửa thông tin !"), LibMedi.AccessData.Msg);
                    return;
                }
                m.upd_eve_tables(ngay.Text,itable, m_userid, "upd");
                m.upd_eve_upd_del(ngay.Text, itable, m_userid, "upd",m.fields(user+m.mmyy(ngay.Text)+".pttt","id="+l_id));
            }
			//if (bCapso && makp.Text!="")  m.upd_capmabn(int.Parse(mabn2.Text),2,int.Parse(makp.Text),int.Parse(mabn3.Text));
			if (!m.upd_pttt(l_id,mabn2.Text+mabn3.Text,l_mavaovien,l_maql,makp.Text,(sophieu.Text!="")?decimal.Parse(sophieu.Text):0,ngay.Text+" "+gio.Text,cd_t.Text,icd_t.Text,cd_s.Text,icd_s.Text,mapt.Text,tenpttt.Text,phuongphap.Text,int.Parse(tinhhinh.SelectedValue.ToString()),mabs.Text,int.Parse(taibien.SelectedValue.ToString()),int.Parse(tuvong.SelectedValue.ToString()),m_userid,tenmau.Text,ngaykt.Text+" "+giokt.Text,(mach.Text!="")?decimal.Parse(mach.Text):0,(nhietdo.Text!="")?decimal.Parse(nhietdo.Text):0,huyetap.Text,phu1.Text,phu2.Text,bsgayme.Text,ktvgayme.Text,hoisuc.Text,dungcu.Text,noidung.Text,int.Parse(loaibn.SelectedValue.ToString()),(bPttt_pmo)?mapmo.SelectedValue.ToString():"",(somat.Visible)?Convert.ToInt32(somat.Value):1,(molaimien.Checked)?1:0,l_idvpkhoa,l_idduoc,l_idkhoa,(mavp.SelectedIndex!=-1)?int.Parse(mavp.SelectedValue.ToString()):0,int.Parse(madoituong.SelectedValue.ToString()),0,(noisoi.Checked)?1:0))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin phẩu thuật / thủ thuật !"),s_msg);
				return;
			}
            //Khuong 16/12/2011: insert vao bang pttt_chandoan va pttt_phuongphap
            
                m.execute_data("delete " + user + ".pttt_chandoan where id=" + l_id.ToString());
                m.execute_data("delete " + user + ".pttt_phuongphap where id=" + l_id.ToString());
            
            foreach (DataRow r in dtIcdt.Rows)
            {
                m.upd_pttt_chandoan(l_id, r["maicd"].ToString(), r["chandoan"].ToString(), int.Parse(r["userid"].ToString()), 0);
            }
            
            foreach (DataRow r in dtIcds.Rows)
            {
                m.upd_pttt_chandoan(l_id, r["maicd"].ToString(), r["chandoan"].ToString(), int.Parse(r["userid"].ToString()), 1);
            }

            foreach (DataRow r in dtPhuongPhap.Rows)
            {
                m.upd_pttt_phuongphap(l_id, r["maicd"].ToString(), r["chandoan"].ToString(), int.Parse(r["userid"].ToString()));
            }
            //Tu:21/05/2011 insert vao bang theodoitsu
            try
            {
                DataRow dr = m.getrowbyid(dsmau.Tables[0],"mapt='"+mapt.Text.Trim()+"'");
                if (dr != null)
                {
                    string s_mabn = mabn2.Text + mabn3.Text;
                    DataSet ds_tiendu = m.get_data("select (max(stt)+1) from " + user + ".theodoitsu where mabn='" + s_mabn + "'");
                    int i_stt = 1;
                    try { i_stt = int.Parse(ds_tiendu.Tables[0].Rows[0][0].ToString()); }
                    catch { i_stt = 1; }
                    m.upd_theodoitsu(s_mabn, tenpt.Text, ngayvv.Text.Substring(0, 10), mapt.Text, i_stt);
                    decimal i_stt_tsu = 0;
                    try { i_stt_tsu = decimal.Parse(m.get_data("select (max(stt)+1) from " + user + ".dmtheodoi").Tables[0].Rows[0][0].ToString()); }
                    catch { i_stt_tsu = 1; }
                    m.upd_dmtheodoi(mapt.Text, i_stt_tsu, tenpttt.Text);
                }
            }
            catch { }
            //end Tu
            if (bChidinh && bStatus)
            {
                m.execute_data("update " + user + m.mmyy(ngay.Text) + ".pttt set idchidinh=" + l_idchidinh + " where id=" + l_id);
                m.execute_data_mmyy("update xxx.v_chidinh set done=1 where id=" + l_idchidinh, ngay.Text, ngay.Text, true);
            }
            m.execute_data("update " + user + ".pttt_bs set id=" + l_id + " where id=0");
			if (bPttt_vp && !molaimien.Checked && mavp.SelectedIndex!=-1)
			{
                string gia = m.field_gia(madoituong.SelectedValue.ToString());
                string giavt = "vattu_" + gia.Substring(4).Trim();
                decimal tygia = (gia.IndexOf("_nn") != -1) ? m.dTygia : 1;
                decimal dongia = decimal.Parse(dtvp.Rows[mavp.SelectedIndex][gia].ToString()) * tygia;
                decimal vattu= decimal.Parse(dtvp.Rows[mavp.SelectedIndex][giavt].ToString()) * tygia;
                if (loaibn.SelectedIndex == 4 && m.get_capso(makp.Text))
                {
                    v.upd_chidinh(l_idvpkhoa, mabn2.Text + mabn3.Text, l_mavaovien, l_maql, l_idkhoa, ngay.Text + " " + gio.Text, v.iNgoaitru, makp.Text, int.Parse(madoituong.SelectedValue.ToString()), int.Parse(mavp.SelectedValue.ToString()), 1, dongia, vattu, m_userid, 0, 0,l_idvpkhoa,icd_vk.Text,cd_vk.Text, mabs.Text,loaibn.SelectedIndex,"");
                    v.execute_data("update " + user + m.mmyy(ngay.Text) + ".v_chidinh set done=1, tylegiam=" + (tylegiam.Text.Trim() == "" ? 0 : decimal.Parse(tylegiam.Text.Trim())) + ", stgiam=" + (stgiam.Text.Trim() == "" ? 0 : decimal.Parse(stgiam.Text.Trim())) + " where id=" + l_idvpkhoa);
                }
                else
                {
                    v.upd_vpkhoa(l_idvpkhoa, mabn2.Text + mabn3.Text, l_mavaovien, l_maql, l_idkhoa, ngay.Text + " " + gio.Text, makp.Text, int.Parse(madoituong.SelectedValue.ToString()), int.Parse(mavp.SelectedValue.ToString()), 1,dongia,vattu, m_userid, 0);
                    v.execute_data("update " + user + d.mmyy(ngay.Text) + ".v_vpkhoa set readonly=1,tylegiam=" + (tylegiam.Text.Trim() == "" ? 0 : decimal.Parse(tylegiam.Text.Trim())) + ",stgiam=" + (stgiam.Text.Trim() == "" ? 0 : decimal.Parse(stgiam.Text.Trim())) + " where id=" + l_idvpkhoa);
                }
                m.execute_data("update " + user + m.mmyy(ngay.Text) + ".pttt set tylegiam=" + (tylegiam.Text.Trim() == "" ? 0 : decimal.Parse(tylegiam.Text.Trim())) + ", stgiam=" + (stgiam.Text.Trim() == "" ? 0 : decimal.Parse(stgiam.Text.Trim())) + " where id=" + l_id);
			}
			else if (!bStatus && molaimien.Checked) v.execute_data("delete from "+user+d.mmyy(ngayvv.Text)+".v_vpkhoa where id="+l_idvpkhoa);
            if (bStatus)
            {
                decimal _id = 0;
                foreach (DataRow r in dttt.Select("chon=true"))
                {
                    _id = m.getidyymmddhhmiss_stt_computer;// m.get_capid(6);
                    m.upd_pttt(_id, mabn2.Text + mabn3.Text, l_mavaovien, l_maql, makp.Text, (sophieu.Text != "") ? decimal.Parse(sophieu.Text) : 0, ngay.Text + " " + gio.Text, cd_t.Text, icd_t.Text, cd_s.Text, icd_s.Text, r["mapt"].ToString(), r["ten"].ToString(), phuongphap.Text, int.Parse(tinhhinh.SelectedValue.ToString()), mabs.Text, int.Parse(taibien.SelectedValue.ToString()), int.Parse(tuvong.SelectedValue.ToString()), m_userid, r["ma"].ToString(), ngaykt.Text + " " + giokt.Text, (mach.Text != "") ? decimal.Parse(mach.Text) : 0, (nhietdo.Text != "") ? decimal.Parse(nhietdo.Text) : 0, huyetap.Text, phu1.Text, phu2.Text, bsgayme.Text, ktvgayme.Text, hoisuc.Text, dungcu.Text, r["noidung"].ToString(), int.Parse(loaibn.SelectedValue.ToString()), (bPttt_pmo) ? mapmo.SelectedValue.ToString() : "", (somat.Visible) ? Convert.ToInt32(somat.Value) : 1, (molaimien.Checked) ? 1 : 0, l_idvpkhoa, l_idduoc, l_idkhoa, (mavp.SelectedIndex != -1) ? int.Parse(mavp.SelectedValue.ToString()) : 0, int.Parse(madoituong.SelectedValue.ToString()), 0, (noisoi.Checked) ? 1 : 0);
                }
                p.Visible = false;
            }
			ena_object(false);
			load_mabn();
			if (!chkXem.Checked) butIn_Click(sender,e);
            if (bChidinh) load_ref();
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			ena_object(false);
            p.Visible = false;
            m.execute_data("delete " + user + ".pttt_bs where id=0");
            if (m_mabn != "") load_treeView();
		}

		private void butHuy_Click(object sender, System.EventArgs e)
		{
			if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý hủy thông tin này !"),s_msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
			{
				s_mabn=mabn2.Text+mabn3.Text;
				if (bPttt_thuoc)
				{
                    sql = "select a.* from " + user + m.mmyy(ngay.Text)+ ".d_duyet a," + user + m.mmyy(ngay.Text) + ".d_xtutrucll b where a.id=b.idduyet and b.id=" + l_idduoc + " and a.done=2";
					if (m.get_data(sql).Tables[0].Rows.Count>0)
					{
                        MessageBox.Show(lan.Change_language_MessageText("Khoa Dược Đã duyệt thuốc & vật tư không cho phép hủy"), LibMedi.AccessData.Msg);
						return;
					}
					int kp=0;
					DataRow r=m.getrowbyid(dtduockp,"makp='"+makp.Text+"'");
					if (r!=null) kp=int.Parse(r["id"].ToString());
                    string s_mmyy = ngay.Text.Substring(3, 2) + ngay.Text.Substring(8, 2), xxx = d.user + s_mmyy;
                    foreach (DataRow r1 in d.get_data("select a.*,b.manguon,b.giaban,b.giamua,a.soluong*b.giamua as sotien,b.gianovat, a.gia_bh from " + xxx + ".d_thucxuat a," + xxx + ".d_theodoi b where a.sttt=b.id and a.id_ktcao=" + l_idvpkhoa + " and a.id=" + l_idduoc).Tables[0].Rows)
					{
						d.upd_tonkhoct_thucxuat(d.delete,s_mmyy,kp,2,1,decimal.Parse(r1["sttt"].ToString()),int.Parse(r1["makho"].ToString()),int.Parse(r1["manguon"].ToString()),int.Parse(r1["mabd"].ToString()),decimal.Parse(r1["soluong"].ToString()));
						d.upd_theodoicongno(d.delete,mabn2.Text+mabn3.Text,l_mavaovien,l_maql,l_idkhoa,int.Parse(r1["madoituong"].ToString()),decimal.Parse(r1["sotien"].ToString()),"thuoc");
                        d.upd_tienthuoc(d.delete, s_mmyy, l_idduoc, mabn2.Text + mabn3.Text, l_mavaovien, l_maql, l_idkhoa, ngay.Text, kp, 2, int.Parse(r1["madoituong"].ToString()), int.Parse(r1["mabd"].ToString()), decimal.Parse(r1["soluong"].ToString()), decimal.Parse(r1["giaban"].ToString()), decimal.Parse(r1["giamua"].ToString()), decimal.Parse(r1["gianovat"].ToString()), 0, decimal.Parse(r1["gia_bh"].ToString()), mabs.Text, long.Parse(l_idvpkhoa.ToString()));
					}
                    d.execute_data("delete from " + user + s_mmyy + ".d_xuatsdct where id=" + l_idduoc + " and id_ktcao=" + l_idvpkhoa);
                    d.execute_data("delete from " + user + s_mmyy + ".d_thucxuat where id=" + l_idduoc + " and id_ktcao=" + l_idvpkhoa);
                    if (d.get_data("select * from " + user + s_mmyy + ".d_xuatsdct where id=" + l_idduoc).Tables[0].Rows.Count <= 0)
                    {
                        d.execute_data("delete from " + user + s_mmyy + ".d_xuatsdll where id=" + l_idduoc);
                    }
                    d.execute_data("delete from " + user + s_mmyy + ".d_xtutrucct where id=" + l_idduoc + " and id_ktcao=" + l_idvpkhoa);
                    if (d.get_data("select * from " + user + s_mmyy + ".d_xtutrucct where id=" + l_idduoc).Tables[0].Rows.Count <= 0)
                    {
                        d.execute_data("delete from " + user + s_mmyy + ".d_xtutrucll where id=" + l_idduoc);
                    }
				}
                int itable = m.tableid(m.mmyy(ngay.Text), "pttt");
                m.upd_eve_tables(ngay.Text, itable, m_userid, "del");
                m.upd_eve_upd_del(ngay.Text, itable, m_userid, "del", m.fields(user + d.mmyy(ngay.Text) + ".pttt", "mabn='" + s_mabn + "' and to_char(ngay,'dd/mm/yyyy hh24:mi')='" + ngay.Text + " " + gio.Text + "' and mamau='"+tenmau.Text+"'"));
                m.execute_data("delete from " + user + ".pttt_phuongphap where id=" + l_id);
                m.execute_data("delete from " + user + ".pttt_chandoan where id=" + l_id);
				m.execute_data("delete from "+user+d.mmyy(ngay.Text)+".pttt where mabn='"+s_mabn+"' and to_char(ngay,'dd/mm/yyyy hh24:mi')='"+ngay.Text+" "+gio.Text+"' and mamau='"+tenmau.Text+"'");
                if (bPttt_vp)
                {
                    if (loaibn.SelectedIndex == 4 && m.get_capso(makp.Text))
                        v.execute_data("delete from " + user + d.mmyy(ngay.Text) + ".v_chidinh where id=" + l_idvpkhoa);
                    else
                        v.execute_data("delete from " + user + d.mmyy(ngay.Text) + ".v_vpkhoa where id=" + l_idvpkhoa);
                }
				load_mabn();
                if (bChidinh)
                {
                    v.execute_data("update " + user + d.mmyy(ngay.Text) + ".v_chidinh set done=0 where id=" + l_idchidinh);
                    load_ref();
                }
			}
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			print_pttt("rptTuongtrinh.rpt");
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}

		private void load_vv(bool skip)
		{
			s_mabn=mabn2.Text+mabn3.Text;
			string sql="";
			int i_tuoi;
			bool bFound=false;
            string _ngay = ngayvao.Text;
            if (loaibn.SelectedIndex == 3 && m.bMmyy(_ngay))
            {
                sql = "select 0 as id,a.namsinh,b.*,c.sothe, c.traituyen from " + user + ".btdbn a inner join " + user + m.mmyy(_ngay) + ".benhanpk b on a.mabn=b.mabn ";
                sql+=" left join " + user + m.mmyy(_ngay) + ".bhyt c on b.maql=c.maql where a.mabn='" + s_mabn + "'";
                if (l_maql != 0) sql += " and b.maql=" + l_maql;
                sql+=" order by b.ngay desc";
            }
            else
            {
                sql = "select d.id,a.namsinh,b.*,c.sothe, c.traituyen from " + user + ".btdbn a inner join " + user + ".benhandt b on a.mabn=b.mabn left join " + user + ".bhyt c on b.maql=c.maql ";
                sql += " inner join " + user + ".hiendien d on b.maql=d.maql ";
                sql += " where a.mabn='" + s_mabn + "' and d.nhapkhoa=1 and d.xuatkhoa=0";//and d.makp='" + makp.Text + "'
                if (l_maql != 0) sql += " and b.maql=" + l_maql;
                sql += " order by b.maql desc ";
            }
			foreach(DataRow r in m.get_data(sql).Tables[0].Rows)
			{
                l_mavaovien = decimal.Parse(r["mavaovien"].ToString());
				l_maql=decimal.Parse(r["maql"].ToString());
                l_idkhoa = decimal.Parse(r["id"].ToString());
                i_traituyen = (r["traituyen"].ToString() == "") ? 0 : int.Parse(r["traituyen"].ToString());
				string s_ngay=m.DateToString("dd/MM/yyyy HH:mm",DateTime.Parse(r["ngay"].ToString()));
				ngayvv.Text=s_ngay.Substring(0,10);
				giovv.Text=s_ngay.Substring(11);
				cd_vk.Text=r["chandoan"].ToString();
				icd_vk.Text=r["maicd"].ToString();
				if (!skip) madoituong.SelectedValue=r["madoituong"].ToString();
				i_tuoi=DateTime.Now.Year-int.Parse(r["namsinh"].ToString());
				tuoi.Text=i_tuoi.ToString();
                sothe.Text = r["sothe"].ToString();
				bFound=true;
                makp.Text = r["makp"].ToString(); //Khuong 01/12/2011
                makp_Validated(null, null);
				break;
			}
            if (!bFound)
            {
                foreach (DataRow r in m.get_data("select * from " + user + ".nhapkhoa where makp='" + makp.Text + "' and maql=" + l_maql + " order by ngay desc").Tables[0].Rows)
                {
                    m_tuoivao = r["tuoivao"].ToString();
                    cd_vk.Text = r["chandoan"].ToString();
                    icd_vk.Text = r["maicd"].ToString();
                    giuong.Text = r["giuong"].ToString();
                    l_idkhoa = decimal.Parse(r["id"].ToString());
                    bFound = true;
                    break;
                }
                m_tuoivao = m.get_tuoivao(l_maql).Trim();
            }
            if (!bFound && m.bMmyy(m.Ngayhienhanh))
			{
				if (l_maql==0)
					sql="select a.*,b.sothe from "+user+d.mmyy(m.Ngayhienhanh)+".tiepdon a left join "+user+d.mmyy(m.Ngayhienhanh)+".bhyt b on a.maql=b.maql where a.mabn='"+s_mabn+"' order by a.ngay desc";
				else
					sql="select a.*,b.sothe from "+user+d.mmyy(m.Ngayhienhanh)+".tiepdon a left join "+user+d.mmyy(m.Ngayhienhanh)+".bhyt b on a.maql=b.maql where a.maql="+l_maql;
				foreach(DataRow r in m.get_data(sql).Tables[0].Rows)
				{
					l_maql=decimal.Parse(r["maql"].ToString());
                    l_mavaovien = l_maql;
                    if (!skip) madoituong.SelectedValue = r["madoituong"].ToString();
					string s_ngay=m.DateToString("dd/MM/yyyy HH:mm",DateTime.Parse(r["ngay"].ToString()));
					ngayvv.Text=s_ngay.Substring(0,10);
					giovv.Text=s_ngay.Substring(11);
					m_tuoivao=r["tuoivao"].ToString();
                    sothe.Text = r["sothe"].ToString();
					break;
				}
			}
			try
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
				tuoi.Text=m_tuoivao.Substring(0,3)+m_loaituoi;
			}
			catch{}
		}

		private void load_treeView()
		{
			s_mabn=mabn2.Text+mabn3.Text;
			treeView1.Nodes.Clear();
            if (nam == "") return;
			TreeNode node;
			foreach(DataRow r in m.get_data_nam(nam,"select ngay,mamau,tenpt from xxx.pttt where mabn='"+s_mabn+"' order by ngay desc").Tables[0].Rows)
			{
				node=treeView1.Nodes.Add(m.DateToString("dd/MM/yyyy HH:mm",DateTime.Parse(r["ngay"].ToString()))+" "+r["mamau"].ToString());
                node.Tag = m.DateToString("dd/MM/yyyy HH:mm", DateTime.Parse(r["ngay"].ToString())) + " " + r["mamau"].ToString();
				//node.Nodes.Add(r["tenpt"].ToString());
                TreeNode nnode = new TreeNode();
                nnode.Text = r["tenpt"].ToString();
                nnode.Tag = m.DateToString("dd/MM/yyyy HH:mm", DateTime.Parse(r["ngay"].ToString())) + " " + r["mamau"].ToString();
                node.Nodes.Add(nnode);
			}
		}

		private void treeView1_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			if (e.Action==TreeViewAction.ByMouse)
			{
				try
				{
                    string s = e.Node.Tag.ToString();
					int iPos=s.IndexOf("/");
					s_ngay=s.Substring(iPos-2,16);
                    s_mabn = mabn2.Text + mabn3.Text;
                    load_vv(true);//29.11.2012
                    load_pttt(s_ngay, s.Substring(16 + iPos - 2 + 1));
                    DataSet ds1;
                    if (nam == "") nam = m.mmyy(m.ngayhienhanh_server) + "+";
                    if (loaibn.SelectedIndex == 0)
                    {
                        sql = "select 0 as loai,1 as loaiba,maql,to_char(ngay,'dd/mm/yyyy hh24:mi') as ngayvao,madoituong,to_char(ngay,'yymmddhh24mi') as yymmdd ";
                        sql += " from " + user + ".benhandt where mabn='" + s_mabn + "'";
                        ds1 = m.get_data(sql);
                    }
                    else if (loaibn.SelectedIndex == 1)
                    {
                        sql = "select 0 as loai,2 as loaiba,maql,to_char(ngay,'dd/mm/yyyy hh24:mi') as ngayvao,madoituong,to_char(ngay,'yymmddhh24mi') as yymmdd ";
                        sql += " from " + user + ".benhanngtr where mabn='" + s_mabn + "'";
                        ds1 = m.get_data(sql);
                    }
                    else if (loaibn.SelectedIndex == 2)
                    {
                        sql = "select 0 as loai,4 as loaiba,maql,to_char(ngay,'dd/mm/yyyy hh24:mi') as ngayvao,madoituong,to_char(ngay,'yymmddhh24mi') as yymmdd ";
                        sql += " from xxx.benhancc where mabn='" + s_mabn + "'";
                        ds1 = m.get_data_nam(nam, sql);
                    }
                    else if (loaibn.SelectedIndex == 3)
                    {
                        sql = "select 1 as loai,3 as loaiba,a.maql,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayvao,a.madoituong,to_char(a.ngay,'yymmddhh24mi') as yymmdd from xxx.benhanpk a ";
                        sql += " where a.mabn='" + s_mabn + "'";
                        ds1 = m.get_data_nam(nam, sql);
                    }
                    else
                    {
                        sql = "select 2 as loai,3 as loaiba,a.maql,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayvao,";
                        sql += " a.madoituong,to_char(a.ngay,'yymmddhh24mi') as yymmdd from xxx.tiepdon a where noitiepdon=0 ";
                        sql += " and a.mabn='" + s_mabn + "'";
                        ds1 = m.get_data_nam(nam, sql);
                    }

                    dsngay.Clear();
                    DataRow r1;
                    foreach (DataRow r in ds1.Tables[0].Select("true", "yymmdd desc,loai,loaiba"))
                    {
                        r1 = dsngay.Tables[0].NewRow();
                        r1["maql"] = r["maql"].ToString();
                        r1["ngayvao"] = r["ngayvao"].ToString();
                        r1["madoituong"] = r["madoituong"].ToString();
                        r1["maphu"] = r["loai"].ToString();
                        dsngay.Tables[0].Rows.Add(r1);
                    }
                    ngayvao.DataSource = dsngay.Tables[0];
                    if (dsngay.Tables[0].Rows.Count > 0) ngayvao.SelectedIndex = 0;
                    /*
                    l_maql = (ngayvao.SelectedIndex != -1) ? decimal.Parse(ngayvao.SelectedValue.ToString()) : 0;
                    if (l_maql != 0)
                    {
                        s_ngay = ngayvao.Text;
                        ngayvv.Text = s_ngay.Substring(0, 10);
                        giovv.Text = s_ngay.Substring(11);
                        load_vv(false);
                    }*/
				}
				catch{}
			}
		}

		private void load_pttt(string s_ngay,string s_mamau)
		{
            if (s_ngay == "") return;
			string sql="",s_ngaykt="";
            DataRow r1;
			s_mabn=mabn2.Text+mabn3.Text;
			sql="select * from "+user+d.mmyy(s_ngay)+".pttt where to_char(ngay,'dd/mm/yyyy hh24:mi')='"+s_ngay+"' and mabn='"+s_mabn+"' and mamau='"+s_mamau+"'";
			foreach(DataRow r in m.get_data(sql).Tables[0].Rows)
			{
                l_mavaovien = decimal.Parse(r["mavaovien"].ToString());
                l_id = decimal.Parse(r["id"].ToString());
				l_maql=decimal.Parse(r["maql"].ToString());
				l_idkhoa=decimal.Parse(r["idkhoa"].ToString());
				l_idvpkhoa=decimal.Parse(r["idvpkhoa"].ToString());
				l_idduoc=decimal.Parse(r["idduoc"].ToString());
                l_idchidinh = decimal.Parse(r["idchidinh"].ToString());
				s_ngay=m.DateToString("dd/MM/yyyy HH:mm",DateTime.Parse(r["ngay"].ToString()));
				if (r["ngaykt"].ToString()!="") s_ngaykt=m.DateToString("dd/MM/yyyy HH:mm",DateTime.Parse(r["ngaykt"].ToString()));
				else s_ngaykt=s_ngay;
				ngay.Text=s_ngay.Substring(0,10);
				gio.Text=s_ngay.Substring(11);
				ngaykt.Text=s_ngaykt.Substring(0,10);
				giokt.Text=s_ngaykt.Substring(11);
				tenkp.SelectedValue=r["makp"].ToString();
				makp.Text=r["makp"].ToString();
				if (bPttt_pmo)
				{
					load_btdpm(makp.Text);
					mapmo.SelectedValue=r["mapmo"].ToString();
				}
				r1=m.getrowbyid(dtkp,"makpbo='25' and makp='"+makp.Text+"'");
				bMat=r1!=null;
				lmat.Visible=bMat;
				somat.Visible=bMat;
				if (somat.Visible) somat.Value=decimal.Parse(r["somat"].ToString());
				molaimien.Checked=r["molaimien"].ToString()=="1";
                noisoi.Checked = r["noisoi"].ToString() == "1";
				madoituong.SelectedValue=r["madoituong"].ToString();
				loaibn.SelectedValue=r["loaibn"].ToString();
				sophieu.Text=r["sophieu"].ToString();
				cd_t.Text=r["chandoant"].ToString();
				icd_t.Text=r["maicdt"].ToString();
				cd_s.Text=r["chandoans"].ToString();
				icd_s.Text=r["maicds"].ToString();
				mapt.Text=r["mapt"].ToString();
				tenpttt.Text=r["tenpt"].ToString();
				mamau.Text=r["mamau"].ToString();
				tenmau.Text=mamau.Text;
				load_mau(mamau.Text.Substring(0,6));
				lmau.SelectedValue=mamau.Text;
				r1=m.getrowbyid(dtpt,"mapt='"+mapt.Text+"'");
				if (r1!=null) tenpt.Text=r1["noi_dung"].ToString();
				tenphuongphap.SelectedValue=r["phuongphap"].ToString();
				tinhhinh.SelectedValue=r["tinhhinh"].ToString();
				taibien.SelectedValue=r["taibien"].ToString();
				tuvong.SelectedValue=r["tuvong"].ToString();
				mach.Text=r["mach"].ToString();
				nhietdo.Text=r["nhietdo"].ToString();
				huyetap.Text=r["huyetap"].ToString();
				noidung.Text=r["noidung"].ToString();
                //
                tylegiam.Text = r["tylegiam"].ToString();
                stgiam.Text = r["stgiam"].ToString();
                //
				gan_text(r["ptv"].ToString(),mabs,tenbs);
				gan_text(r["phu1"].ToString(),phu1,tenphu1);
				gan_text(r["phu2"].ToString(),phu2,tenphu2);
				gan_text(r["bsgayme"].ToString(),bsgayme,tenbsgayme);
				gan_text(r["ktvgayme"].ToString(),ktvgayme,tenktvgayme);
				gan_text(r["hoisuc"].ToString(),hoisuc,tenhoisuc);
				gan_text(r["dungcu"].ToString(),dungcu,tendungcu);

                dtIcdt = m.get_data("select maicd,chandoan,userid from " + user + ".pttt_chandoan where id=" + r["id"].ToString() + " and loai=0").Tables[0];
                

                dtIcds = m.get_data("select maicd,chandoan,userid from " + user + ".pttt_chandoan where id=" + r["id"].ToString() + " and loai=1").Tables[0];

                dtPhuongPhap = m.get_data("select mapt as maicd,tenpt as chandoan,userid from " + user + ".pttt_phuongphap where id=" + r["id"].ToString() ).Tables[0];

                if (dtPhuongPhap.Rows.Count > 0)
                {
                    butThemPP.ForeColor = Color.Red;
                }
                else
                    butThemPP.ForeColor = Color.Black;

                if (dtIcdt.Rows.Count > 0)
                {
                    butThemcdT.ForeColor = Color.Red;
                }
                else
                    butThemcdT.ForeColor = Color.Black;

                if (dtIcds.Rows.Count > 0)
                {
                    butThemcdS.ForeColor = Color.Red;
                }
                else
                    butThemcdS.ForeColor = Color.Black;

				try
				{
					loaipt.SelectedValue=m.get_data("select loaipt from "+user+".dmpttt where mapt='"+mapt.Text+"'").Tables[0].Rows[0][0].ToString();
				}
				catch{loaipt.SelectedIndex=0;}
				if (bPttt_vp)
				{
					r1=m.getrowbyid(dtmavp,"id="+int.Parse(r["mavp"].ToString()));
					if (r1!=null)
					{
						loaivp.SelectedValue=r1["id_loai"].ToString();
						mavp.SelectedValue=r1["id"].ToString();
					}
					else
					{
						loaivp.SelectedIndex=-1;
						mavp.SelectedIndex=-1;
					}
				}
				break;
			}
			s_icd_t=icd_t.Text;
			s_icd_s=icd_s.Text;
		}

		private void gan_text(string s,TextBox ma,TextBox ten)
		{
			if (s!="")
			{
				ma.Text=s;
                sql = "ma='"+s+"'";
                if (b_bacsi) sql += " and makp='" + makp.Text + "'";
				DataRow r=m.getrowbyid(dtbs,sql);
				if (r!=null) ten.Text=r["hoten"].ToString();
				else ma.Text=ten.Text="";
			}
			else ten.Text="";
		}

		private void ngay_Validated(object sender, System.EventArgs e)
		{
			ngay.Text=ngay.Text.Trim();
			if (ngay.Text.Length==6) ngay.Text=ngay.Text+DateTime.Now.Year.ToString();
			if (ngay.Text.Length<10)
			{
				MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập ngày !"),s_msg);
				ngay.Focus();
				return;
			}
			if (!m.bNgay(ngay.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"));
				ngay.Focus();
				return;
			}
			if (!m.ngay(m.StringToDate(ngay.Text.Substring(0,10)),DateTime.Now,songay))
			{
				MessageBox.Show(lan.Change_language_MessageText("Ngày phẫu thuật / thủ thuật không hợp lệ so với khai báo hệ thống (")+songay.ToString()+")!",s_msg);
				ngay.Focus();
				return;
			}
		}

		private void sophieu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void sophieu_Validated(object sender, System.EventArgs e)
		{
			try
			{
				sophieu.Text=decimal.Parse(sophieu.Text.ToString()).ToString();
			}
			catch{sophieu.Text="0";}
		}

		private void frmPttt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.F3:
					if (butMoi.Enabled) butMoi_Click(sender,e);
					break;
                case Keys.F5:
                    if (butNhanvien.Enabled) butNhanvien_Click(sender, e);
                    break;
				case Keys.F6:
					if (butLuu.Enabled) butLuu_Click(sender,e);
					break;
				case Keys.F9:
					if (butIn.Enabled) butIn_Click(sender,e);
					break;
				case Keys.F10:
					if (butKetthuc.Enabled) butKetthuc_Click(sender,e);
					break;
			}
		}

		private void tenpt_Validated(object sender, System.EventArgs e)
		{
			string s=m.get_mapt(tenpt.Text);
			if (s!="")
			{
				mapt.Text=s.Substring(1);
				loaipt.SelectedValue=s.Substring(0,1);
			}
			if(!listpttt.Focused)listpttt.Hide();
		}

		private void tenpt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listpttt.Focus(); 
			else if (e.KeyCode==Keys.Enter)
			{
				if (listpttt.Visible)
				{
					listpttt.Focus();
					SendKeys.Send("{Up}");
				}
				else SendKeys.Send("{Tab}");
			}
		}

		private void tenpt_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tenpt)
			{
				Filt_pttt(tenpt.Text);
				listpttt.BrowseToText(tenpt,mapt,phuongphap);
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

		private void butPttt_Click(object sender, System.EventArgs e)
		{
            dllDanhmucMedisoft.frmDmpttt f = new dllDanhmucMedisoft.frmDmpttt(m, mapt.Text, tenpt.Text, true);
			f.ShowDialog();
			if (f.m_mapt!="")
			{
				tenpt.Text=f.m_tenpt;
				mapt.Text=f.m_mapt;
				loaipt.SelectedValue=f.m_loaipt;
			}
		}

		private void listpttt_Validated(object sender, System.EventArgs e)
		{
			mamau_Validated(sender,e);
		}

		private void cd_t_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listICD.Focus(); 
			else if (e.KeyCode==Keys.Enter)
			{
				if (listICD.Visible) listICD.Focus();
				else SendKeys.Send("{Tab}{Home}");
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

		private void cd_t_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==cd_t)
			{
				if (bChandoan || icd_t.Text=="")
				{
					Filt_ICD(cd_t.Text);
					listICD.BrowseToICD10(cd_t,icd_t,icd_s,icd_t.Location.X,icd_t.Location.Y+icd_t.Height,icd_t.Width+cd_t.Width+2,icd_t.Height);
				}
			}		
		}

		private void cd_s_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==cd_s)
			{
				if (bChandoan || icd_s.Text=="")
				{
					Filt_ICD(cd_s.Text);
					listICD.BrowseToICD10(cd_s,icd_s,mapt,icd_s.Location.X,icd_s.Location.Y+icd_s.Height,icd_s.Width+cd_s.Width+2,icd_s.Height);
				}
			}		
		}

		private void sophieu_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			m.MaskDigit(e);
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
				listBS.BrowseToICD10(tenbs,mabs,phu1,mabs.Location.X,mabs.Location.Y+mabs.Height,mabs.Width+tenbs.Width+2,mabs.Height);
			}		
		}

		private void Filt_tenbs(string ten)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listBS.DataSource];
				DataView dv=(DataView)cm.List;
                sql = "hoten like '%" + ten.Trim() + "%'";
                if (b_bacsi) sql += " and makp='" + makp.Text + "'";
                dv.RowFilter = sql;
			}
			catch{}
		}

		private void mabs_Validated(object sender, System.EventArgs e)
		{
			gan_text(mabs.Text,mabs,tenbs);
		}

		private void mabs_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void ngaykt_Validated(object sender, System.EventArgs e)
		{
			ngaykt.Text=ngaykt.Text.Trim();
			if (ngaykt.Text.Length==6) ngaykt.Text=ngaykt.Text+DateTime.Now.Year.ToString();
			if (ngaykt.Text.Length<10)
			{
				MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập ngày !"),s_msg);
				ngaykt.Focus();
				return;
			}
			if (!m.bNgay(ngaykt.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"));
				ngaykt.Focus();
				return;
			}
			if (!m.ngay(m.StringToDate(ngaykt.Text.Substring(0,10)),DateTime.Now,songay))
			{
				MessageBox.Show(lan.Change_language_MessageText("Ngày phẫu thuật / thủ thuật không hợp lệ so với khai báo hệ thống (")+songay.ToString()+")!",s_msg);
				ngaykt.Focus();
				return;
			}
		}

		private void phu1_Validated(object sender, System.EventArgs e)
		{
			gan_text(phu1.Text,phu1,tenphu1);
		}

		private void phu2_Validated(object sender, System.EventArgs e)
		{
			gan_text(phu2.Text,phu2,tenphu2);
		}

		private void bsgayme_Validated(object sender, System.EventArgs e)
		{
			gan_text(bsgayme.Text,bsgayme,tenbsgayme);
		}

		private void ktvgayme_Validated(object sender, System.EventArgs e)
		{
			gan_text(ktvgayme.Text,ktvgayme,tenktvgayme);
		}

		private void hoisuc_Validated(object sender, System.EventArgs e)
		{
			gan_text(hoisuc.Text,hoisuc,tenhoisuc);
		}

		private void dungcu_Validated(object sender, System.EventArgs e)
		{
			gan_text(dungcu.Text,dungcu,tendungcu);
		}

		private void tenphu1_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tenphu1)
			{
				Filt_tenbs(tenphu1.Text);
				listBS.BrowseToICD10(tenphu1,phu1,phu2,phu1.Location.X,phu1.Location.Y+phu1.Height,phu1.Width+tenphu1.Width+2,phu1.Height);
			}		
		}

		private void tenphu2_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tenphu2)
			{
				Filt_tenbs(tenphu2.Text);
				listBS.BrowseToICD10(tenphu2,phu2,bsgayme,phu2.Location.X,phu2.Location.Y+phu2.Height,phu2.Width+tenphu2.Width+2,phu2.Height);
			}		
		}

		private void tenbsgayme_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tenbsgayme)
			{
				Filt_tenbs(tenbsgayme.Text);
				listBS.BrowseToICD10(tenbsgayme,bsgayme,ktvgayme,bsgayme.Location.X,bsgayme.Location.Y+bsgayme.Height,bsgayme.Width+tenbsgayme.Width+2,bsgayme.Height);
			}		
		}

		private void tenktvgayme_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tenktvgayme)
			{
				Filt_tenbs(tenktvgayme.Text);
				listBS.BrowseToICD10(tenktvgayme,ktvgayme,hoisuc,ktvgayme.Location.X,ktvgayme.Location.Y+ktvgayme.Height,ktvgayme.Width+tenktvgayme.Width+2,ktvgayme.Height);
			}		
		}

		private void tenhoisuc_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tenhoisuc)
			{
				Filt_tenbs(tenhoisuc.Text);
				listBS.BrowseToICD10(tenhoisuc,hoisuc,dungcu,hoisuc.Location.X,hoisuc.Location.Y+hoisuc.Height,hoisuc.Width+tenhoisuc.Width+2,hoisuc.Height);
			}		
		}

		private void tendungcu_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tendungcu)
			{
				Filt_tenbs(tendungcu.Text);
				listBS.BrowseToICD10(tendungcu,dungcu,tinhhinh,dungcu.Location.X,dungcu.Location.Y+dungcu.Height,dungcu.Width+tendungcu.Width+2,dungcu.Height);
			}		
		}

		private void mamau_Validated(object sender, System.EventArgs e)
		{
			if (mamau.Text!="")
			{
				DataRow r=m.getrowbyid(dsmau.Tables[0],"ma='"+mamau.Text+"'");
				if (r!=null)
				{
					if (bPttt_vp) load_vienphi(mamau.Text);
					tenpttt.Text=r["ten"].ToString();
					mapt.Text=r["mapt"].ToString();
					noidung.Text=r["noidung"].ToString();
					mapt_Validated(sender,e);
					load_mau(mamau.Text.Substring(0,6));
					lmau.SelectedValue=mamau.Text;
				}
			}
		}

		private void load_mau(string ma)
		{
            string s_loaipttt = "'T'";
            if (bPhauthuat && i_loaibn == 1)
                s_loaipttt = "'T','P'";
            sql = "select ma,ten,mapt,mabs,makp,noidung,mavp from " + user + ".pttt_mau where ma like '%" + ma.Trim() + "%'";
            if (bThuthuat)
            {
                sql += " and substring(mapt,1,1) in ("+s_loaipttt+")";
            }
            sql += " union all ";
            sql += "select mapt as ma,noi_dung as ten,mapt,'' as mabs,'' as makp,'' as noidung,0 as mavp from " + user + ".dmpttt where mapt like '%" + ma.Trim() + "%'";
            if (bThuthuat) sql += " and substring(mapt,1,1) in (" + s_loaipttt + ")";
			dslmau=m.get_data(sql);
			lmau.DataSource=dslmau.Tables[0];
		}

		private void tenmau_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tenmau)
			{
				Filt_pttt(tenmau.Text);
				listpttt.BrowseToPTTT(tenmau,mamau,lmau,tenmau.Location.X,tenmau.Location.Y+tenmau.Height,tenmau.Width+lmau.Width+tenpttt.Width+4,tenmau.Height);
			}
		}

		private void butTuongtrinh_CheckedChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==butTuongtrinh)
			{
				noidung.Visible=butTuongtrinh.Checked;
                noidung.BringToFront();
			}
		}

		private void chktuongtrinh_CheckedChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==chktuongtrinh)
			{
				if (chktuongtrinh.Checked)
				{
					if (mamau.Text!="")
					{
						mautuongtrinh.DataSource=m.get_data("select * from "+user+".pttt_mau where ma like '%"+mamau.Text.Trim().Substring(0,6)+"%'").Tables[0];
						if (!noidung.Visible) mautuongtrinh_SelectedIndexChanged(sender,e);
						else if (mautuongtrinh.Items.Count>0) noidung.Text=mautuongtrinh.SelectedValue.ToString();
					}
					else mautuongtrinh.DataSource=null;
				}
				else noidung.Text="";
				mautuongtrinh.Enabled=chktuongtrinh.Checked;
			}
		}

		private void mautuongtrinh_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==mautuongtrinh)
			{
				if (mautuongtrinh.Items.Count>0) noidung.Text=mautuongtrinh.SelectedValue.ToString();
				if (bPttt_vp) load_vienphi(mautuongtrinh.SelectedValue.ToString());
			}
		}

		private void load_vienphi(string ma)
		{
			DataRow r,r1;
			r1=m.getrowbyid(dsmau.Tables[0],"ma='"+ma+"'");
			if (r1!=null)
			{
				r=m.getrowbyid(dtmavp,"id="+int.Parse(r1["mavp"].ToString()));
				if (r!=null)
				{
					loaivp.SelectedValue=r["id_loai"].ToString();
					mavp.SelectedValue=r1["mavp"].ToString();
                    enabled_giam(true);
				}
				else
				{
					loaivp.SelectedIndex=-1;
					mavp.SelectedIndex=-1;
                    enabled_giam(false);
				}
			}
		}

		private void loaibn_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				if (loaibn.SelectedIndex==-1 && loaibn.Items.Count>0) loaibn.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void mapmo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (mapmo.SelectedIndex==-1 && mapmo.Items.Count>0) mapmo.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void mavp_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void mavp_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (mavp.SelectedIndex!=-1) 
			{
                string sfie = m.field_gia((madoituong.SelectedIndex < 0 ? "2" : madoituong.SelectedValue.ToString()));
                decimal st = decimal.Parse(dtvp.Rows[mavp.SelectedIndex][sfie].ToString()) + decimal.Parse(dtvp.Rows[mavp.SelectedIndex][sfie.Replace("gia","vattu")].ToString());
				sotien.Text=st.ToString("###,###,###,###");
			}
		}

		private void loaivp_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (loaivp.SelectedIndex!=-1) load_mavp();
		}
		
		private void load_mavp()
		{
			dtvp=m.get_data("select * from "+user+".v_giavp where id_loai="+int.Parse(loaivp.SelectedValue.ToString())+" order by stt").Tables[0];
			mavp.DataSource=dtvp;
		}

		private void mabn3_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			m.MaskDigit(e);
		}

		private void butThuoc_Click(object sender, System.EventArgs e)
		{
            if (butLuu.Enabled) butLuu_Click(sender, e);
            if (mamau.Text == "") return;
            loai = 0; phieu = 0; kp = 0; nhom = m.nhom_duoc; l_duyet = 0; ngay_thuoc = ngay.Text;
            mmyy_thuoc = ngay.Text.Substring(3, 2) + ngay.Text.Substring(8, 2); makho = ""; manguon = "";
            DataRow r;
            r = m.getrowbyid(dtduockp, "makp='" + makp.Text + "'");
            if (r != null) kp = int.Parse(r["id"].ToString());
            makhoa = kp;
            //ThanhCuong - 06/08/2012 - Kỹ thuật cao
            loai = 2;
            frmChonthongso f = new frmChonthongso(m,1,loai,0,makp.Text,false,s_nhomkho,i_khudt,this.m_userid);//linh 16102012
            f.IDXuatTuTruc = l_idduoc;
            f.ShowDialog();
            if (f.s_makp != "")
            {
                l_duyet = f.l_duyet;
                if (l_duyet == 0)
                {
                    l_duyet = d.get_id_duyet;
                }
                if (loai != 0 && f.i_phieu != 0 && kp != 0 && mmyy_thuoc != "")
                {
                    frmXtutruc f1 = new frmXtutruc(f.s_ngay, f.s_makho, f.s_makp, f.i_nhom, loai, f.i_phieu, f.i_macstt, f.i_makp, m_userid, f.s_mmyy, f.l_duyet, "Phiếu xuất tủ trực " + f.s_tennhom.Trim() + " theo người bệnh (" + f.s_ngay.Trim() + ", " + f.s_tenkp.Trim() + ", " + f.s_phieu.Trim() + ", " + m_userid.ToString().Trim() + ")", LibMedi.AccessData.Msg, m.bDausinhton, m.iSudungthuoc, f.s_manguon, s_mabn, f.i_buoi, f.s_tenkp, f.s_phieu, f.i_somay, "", s_madoituong,long.Parse(l_idvpkhoa.ToString()), makp.Text, ngay.Text + " " + gio.Text);
                    f1.IDXTutruc_Cu = l_idduoc;
                    f1.GoiPTTT = true;
                    f1.Ma_PTTT = (mapt.Text.Trim().Length > 6) ? mapt.Text.Trim().Substring(0, 6) : mapt.Text;
                    f1.Ma_Mau_PTTT = mapt.Text;
                    f1.ShowDialog();
                    l_idduoc = f1.l_id;                    
                }
            }
		}

		private void gio_Validated(object sender, System.EventArgs e)
		{
			string sgio=(gio.Text.Trim()=="")?"00:00":gio.Text.Trim();
			gio.Text=sgio.Substring(0, 2).Trim().PadLeft(2, '0')+":"+sgio.Substring(3).Trim().PadRight(2,'0');
			if (!m.bGio(gio.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Giờ không hợp lệ !"));
				gio.Focus();
				return;
			}
			if (ngayvv.Text!="")
			{
				if (!m.bNgaygio(ngay.Text+" "+gio.Text,ngayvv.Text+" "+giovv.Text))
				{
					MessageBox.Show(lan.Change_language_MessageText("Ngày phẫu thuật / thủ thuật không được nhỏ hơn ngày vào viện !"),s_msg);
					ngay.Focus();
					return;
				}
				if (m_ngayra!="")
				{
					if (!m.bNgaygio(m_ngayra,ngay.Text+" "+gio.Text))
					{
						MessageBox.Show(lan.Change_language_MessageText("Ngày phẫu thuật / thủ thuật không được lớn hơn ngày ra viện !"),s_msg);
						ngay.Focus();
						return;
					}
				}
			}
		}

		private void giokt_Validated(object sender, System.EventArgs e)
		{
			string sgio=(giokt.Text.Trim()=="")?"00:00":giokt.Text.Trim();
			giokt.Text=sgio.Substring(0, 2).Trim().PadLeft(2, '0')+":"+sgio.Substring(3).Trim().PadRight(2,'0');
			if (!m.bGio(giokt.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Giờ không hợp lệ !"));
				giokt.Focus();
				return;
			}
			if (!m.bNgaygio(ngaykt.Text+" "+giokt.Text,ngay.Text+" "+gio.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Ngày kết thúc không được nhỏ hơn ngày bắt đầu !"),s_msg);
				ngaykt.Focus();
				return;
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
				if (r!=null)
				{
					noidung.Text=r["noidung"].ToString();
					tenmau.Text=r["ma"].ToString();
					tenpttt.Text=lmau.Text;
				}
			}
		}

		private void tenpttt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void mach_Validated(object sender, System.EventArgs e)
		{
			if (mach.Text=="") icd_t.Focus();
		}

		private void ngayvv_Validated(object sender, System.EventArgs e)
		{
			ngayvv.Text=ngayvv.Text.Trim();
			if (ngayvv.Text.Length==6) ngayvv.Text=ngayvv.Text+DateTime.Now.Year.ToString();
			if (ngayvv.Text.Length<10)
			{
				MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập ngày !"),s_msg);
				ngayvv.Focus();
				return;
			}
			if (!m.bNgay(ngayvv.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"));
				ngayvv.Focus();
				return;
			}
			if (!m.ngay(m.StringToDate(ngayvv.Text.Substring(0,10)),DateTime.Now,songay))
			{
				MessageBox.Show(lan.Change_language_MessageText("Ngày vào viện không hợp lệ so với khai báo hệ thống (")+songay.ToString()+")!",s_msg);
				ngayvv.Focus();
				return;
			}		
            
		}

		private void giovv_Validated(object sender, System.EventArgs e)
		{
			string sgio=(giovv.Text.Trim()=="")?"00:00":giovv.Text.Trim();
			giovv.Text=sgio.Substring(0, 2).Trim().PadLeft(2, '0')+":"+sgio.Substring(3).PadLeft(2,'0');
			if (!m.bGio(giovv.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Giờ không hợp lệ !"));
				giovv.Focus();
				return;
			}
		}

		private void load_btdpm(string ma)
		{
			dtpm=m.get_data("select * from "+user+".btdpmo where makp like '%"+ma.Trim()+",%' order by ma").Tables[0];
			if (dtpm.Rows.Count==0) dtpm=m.get_data("select * from "+user+".btdpmo order by ma").Tables[0];
			mapmo.DataSource=dtpm; 
		}

        private void tim_Enter(object sender, EventArgs e)
        {
            tim.Text = "";
        }

        private void tim_TextChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == tim)
            {
                try
                {
                    CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource];
                    DataView dv = (DataView)cm.List;
                    if (tim.Text != "")
                        dv.RowFilter = "(ma like '%" + tim.Text.Trim() + "%' or ten like '%" + tim.Text.Trim() + "%' or tenpt like '%"+tim.Text.Trim()+"%') and (ma<>'"+tenmau.Text+"')";
                    else
                        dv.RowFilter = "mamau<>'"+tenmau.Text+"'";
                }
                catch { }
            }
        }

        private void butOk_Click(object sender, EventArgs e)
        {
            p.Visible = false;
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            foreach (DataRow r in dttt.Rows) r["chon"] = false;
        }

        private void butThem_Click(object sender, EventArgs e)
        {
            if (tenmau.Text == "")
            {
                tenmau.Focus();
                return;
            }
            foreach (DataRow r in dttt.Rows) r["chon"] = false;
            p.Visible = true;
            p.BringToFront();
        }

        private void ngayvao_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (ngayvao.SelectedIndex == -1 && ngayvao.Items.Count > 0) ngayvao.SelectedIndex = 0;
                l_maql = (ngayvao.SelectedIndex != -1) ? decimal.Parse(ngayvao.SelectedValue.ToString()) : 0;
                                
                load_vv(false);
                SendKeys.Send("{Tab}");
            }
        }

        private void butNhanvien_Click(object sender, EventArgs e)
        {
            if (mabs.Text == "" || tenbs.Text == "")
            {
                mabs.Focus();
                return;
            }
            frmPttt_bs f = new frmPttt_bs(m, l_id);
            f.ShowDialog();
        }

        private void list_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                danhsach.Visible = false;
                mabn2.Focus();
            }
            else if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab) gan_mabn();
        }

        private void list_DoubleClick(object sender, EventArgs e)
        {
            gan_mabn();	
        }

        private void gan_mabn()
        {
            try
            {
                s_mabn = list.SelectedValue.ToString();
                if (s_mabn != "")
                {
                    DataRow r = m.getrowbyid(dtlist, "mabn='" + s_mabn + "'");
                    if (r != null)
                    {
                        int loai = 0;
                        makp.Text = r["makp"].ToString();
                        tenkp.SelectedValue = r["makp"].ToString();
                        if (makp.Text == "99") loai = 2;
                        else
                        {
                            if (r["loai"].ToString() == "1") loai = 0;
                            else
                            {
                                DataRow r1 = m.getrowbyid(dtkp, "makp='" + makp.Text + "'");
                                if (r1 != null) loai = (r1["loai"].ToString() == "1") ? 3 : 1;
                            }
                        }                        
                        loaibn.SelectedValue = loai.ToString();
                        mabn2.Text = s_mabn.Substring(0, 2);
                        mabn3.Text = s_mabn.Substring(2);
                        mabn3_Validated(null, null);
                        l_idchidinh = decimal.Parse(r["id"].ToString());
                        ngayvao.Focus();
                        lblTenkythuat.Text = r["tenkythuat"].ToString();
                    }
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

        private void butRef_Click(object sender, EventArgs e)
        {
            load_ref();
            list.Focus();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == textBox1)
            {
                try
                {
                    CurrencyManager cm = (CurrencyManager)BindingContext[list.DataSource];
                    DataView dv = (DataView)cm.List;
                    if (tim.Text != "")
                        dv.RowFilter = "hoten like '%" + textBox1.Text.Trim() + "%' or mabn like '%" + textBox1.Text.Trim() + "%'";
                    else
                        dv.RowFilter = "";
                }
                catch { }
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void butHinh_Click(object sender, EventArgs e)
        {
            if (l_id == 0) butLuu_Click(sender, e);
            frmPttt_hinh f = new frmPttt_hinh(m,ngay.Text,l_id, dsmau.Tables[0], mamau.Text);
            f.ShowDialog(this);
            
        }
        private bool bDaxuatvien(string mabn, decimal maql)
        {
            bool bln = false;
            sql = "select * from " + m.user + ".xuatvien where mabn='" + mabn + "' and maql=" + l_maql;
            bln = m.get_data(sql).Tables[0].Rows.Count > 0;
            return bln;
        }

        private void ngayvao_Validated(object sender, EventArgs e)
        {
            if ((!bPTTT_Xuatvien || bPttt_vp) && !butMoi.Enabled && ngayvao.SelectedIndex >= 0)
            {
                bool bln = bDaxuatvien(mabn2.Text.PadLeft(2, '0') + mabn3.Text.PadLeft(i_maxlength_mabn-2, '0'), decimal.Parse(ngayvao.SelectedValue.ToString()));
                if (bln)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân này đã xuất viện !"), "PTTT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    butBoqua_Click(null, null);
                }
            }
        }

       

        private void rdtatca_Click(object sender, EventArgs e)
        {
            m.writeXml("thongso", "dschopttt", (rdtt.Checked) ? "1" : (rdphauthuat.Checked) ? "2" : "0");
        }

        private void enabled_giam(bool ena)
        {
            tylegiam.Enabled = ena;
            stgiam.Enabled = ena;
        }

        private void visibled_giam(bool ena)
        {
            tylegiam.Visible  = ena;
            stgiam.Visible =  ena;
            label43.Visible = ena;
            label44.Visible = ena;
            label45.Visible = ena;
        }

        private void tylegiam_Validated(object sender, EventArgs e)
        {
            if (mavp.SelectedIndex < 0) return;
            if (tylegiam.Text.Trim() == "" || tylegiam.Text.Trim() == "0") { stgiam.Text = "0"; return; }
            get_st_giam(int.Parse(mavp.SelectedValue.ToString()), int.Parse(madoituong.SelectedValue.ToString()), decimal.Parse(tylegiam.Text));
        }

        private void get_st_giam(int i_mavp, int i_madoituong, decimal d_tylegiam)
        {
            if (d_tylegiam == 0) { stgiam.Text = "0"; return; }
            else
            {
                string gia = m.field_gia(i_madoituong.ToString());
                DataRow dr = m.getrowbyid(dtvp, "id=" + i_mavp);
                if (dr != null)
                {
                    decimal dgia = (dr[gia].ToString().Trim() == "") ? 0 : decimal.Parse(dr[gia].ToString());
                    stgiam.Text = Math.Round((dgia * d_tylegiam / 100), 0).ToString();
                }
            }
        }

        private void get_tylegiam_giam(int i_mavp, int i_madoituong, decimal d_stgiam)
        {
            if (d_stgiam == 0) { tylegiam.Text = "0"; return; }
            else
            {
                string gia = m.field_gia(i_madoituong.ToString());
                DataRow dr = m.getrowbyid(dtvp, "id=" + i_mavp);
                if (dr != null)
                {
                    decimal dgia = (dr[gia].ToString().Trim() == "") ? 0 : decimal.Parse(dr[gia].ToString());
                    tylegiam.Text = Math.Round(((d_stgiam / dgia) * 100), 0).ToString();
                }
            }
        }
        private void stgiam_Validated(object sender, EventArgs e)
        {
            if (mavp.SelectedIndex < 0) return;
            if (stgiam.Text.Trim() == "" || stgiam.Text.Trim() == "0") { tylegiam.Text = "0"; return; }
            get_tylegiam_giam(int.Parse(mavp.SelectedValue.ToString()), int.Parse(madoituong.SelectedValue.ToString()), decimal.Parse(stgiam.Text));
        }

        private void f_capnhat_db()
        {
            string xxx = m.user + m.mmyy(m.ngayhienhanh_server);
            string asql = "alter table " + xxx + ".pttt add tylegiam numeric(5,2) default 0";
            m.execute_data(asql, false);
            asql = "alter table " + xxx + ".pttt add stgiam numeric(18) default 0";
            m.execute_data(asql, false);           
        }

        private void butThemcdT_Click(object sender, EventArgs e)
        {
            if (icd_t.Text.Trim() != "" && cd_t.Text.Trim() != "")
            {
                frmPttt_chandoan f = new frmPttt_chandoan(m,icd_t.Text, cd_t.Text, m_userid, 0,dtIcdt,dticd);
                f.ShowDialog();
                dtIcdt = f.dt.Copy();
               
                if (dtIcdt.Rows.Count > 0)
                {
                    butThemcdT.ForeColor = Color.Red;
                }
                else
                    butThemcdT.ForeColor = Color.Black;
            }
        }

        private void butThemcdS_Click(object sender, EventArgs e)
        {
            if (icd_s.Text.Trim() != "" && cd_s.Text.Trim() != "")
            {
                frmPttt_chandoan f = new frmPttt_chandoan(m,icd_s.Text, cd_s.Text, m_userid, 1, dtIcds,dticd);
                f.ShowDialog();
                dtIcds = f.dt.Copy();
               
                if (dtIcds.Rows.Count > 0)
                {
                    butThemcdS.ForeColor = Color.Red;
                }
                else
                    butThemcdS.ForeColor = Color.Black;
            }
        }

        private void butThemPP_Click(object sender, EventArgs e)
        {
            if (icd_s.Text.Trim() != "" && cd_s.Text.Trim() != "")
            {
                frmPttt_chandoan f = new frmPttt_chandoan(m, tenmau.Text, lmau.Text, m_userid, 99, dtPhuongPhap, dtptpp);
                f.ShowDialog();
                dtPhuongPhap = f.dt.Copy();

                if (dtPhuongPhap.Rows.Count > 0)
                {
                    butThemPP.ForeColor = Color.Red;
                }
                else
                    butThemPP.ForeColor = Color.Black;
            }
        }
        private void print_pttt(string report_name)
        {
            if (hoten.Text == "") return;
            string s, _ptv = tenbs.Text.Trim() + ",", _phu1 = tenphu1.Text.Trim() + ",", _phu2 = tenphu2.Text.Trim() + ",", _gayme1 = tenbsgayme.Text.Trim() + ",", _gayme2 = tenktvgayme.Text.Trim() + ",", _dungcu = tendungcu.Text.Trim() + ",", _hoisuc = tenhoisuc.Text.Trim() + ",";
            foreach (DataRow r1 in m.get_data("select a.loai,b.hoten from " + user + ".pttt_bs a," + user + ".dmbs b where a.mabs=b.ma and a.id=" + l_id + " order by a.loai").Tables[0].Rows)
            {
                switch (int.Parse(r1["loai"].ToString()))
                {
                    case 1:
                        _ptv += r1["hoten"].ToString().Trim() + ",";
                        break;
                    case 2:
                        _phu1 += r1["hoten"].ToString().Trim() + ",";
                        break;
                    case 3:
                        _phu2 += r1["hoten"].ToString().Trim() + ",";
                        break;
                    case 4:
                        _gayme1 += r1["hoten"].ToString().Trim() + ",";
                        break;
                    case 5:
                        _gayme2 += r1["hoten"].ToString().Trim() + ",";
                        break;
                    case 6:
                        _dungcu += r1["hoten"].ToString().Trim() + ",";
                        break;
                    case 7:
                        _hoisuc += r1["hoten"].ToString().Trim() + ",";
                        break;
                }

            }
            dsxml.Clear();
            DataRow r;
            DataTable dtcd_ts = new DataTable();
            DataTable dttemp = new DataTable();
            string cd_truoc = "", cd_sau = "", ppptkemtheo = "";
            r = dsxml.Tables[0].NewRow();
            r["mabn"] = mabn2.Text + mabn3.Text;
            r["hoten"] = hoten.Text;
            r["tuoi"] = tuoi.Text;
            r["phai"] = phai.Text;
            r["diachi"] = diachi.Text;
            r["khoa"] = tenkp.Text;
            r["giuong"] = giuong.Text;
            s = ngayvv.Text + " " + giovv.Text;
            if (s.Length == 16)
                r["ngayvv"] = s.Substring(11, 2) + " giờ " + s.Substring(14, 2) + " phút, " + "       " + "Ngày " + s.Substring(0, 2) + " tháng " + s.Substring(3, 2) + " năm " + s.Substring(6, 4);
            s = ngay.Text + " " + gio.Text;
            r["ngaypt"] = s.Substring(11, 2) + " giờ " + s.Substring(14, 2) + " phút, " + "       " + "Ngày " + s.Substring(0, 2) + " tháng " + s.Substring(3, 2) + " năm " + s.Substring(6, 4);
            s = ngaykt.Text + " " + giokt.Text;
            r["ngaykt"] = s.Substring(11, 2) + " giờ " + s.Substring(14, 2) + " phút, " + "       " + "Ngày " + s.Substring(0, 2) + " tháng " + s.Substring(3, 2) + " năm " + s.Substring(6, 4);
            r["chandoanvk"] = cd_vk.Text;
            dtcd_ts = m.get_data("select chandoan,loai from " + user + ".pttt_chandoan where id=" + l_id).Tables[0];
            DataTable dtpppttt = m.get_data("select tenpt from " + user + ".pttt_phuongphap where id=" + l_id).Tables[0];
            foreach (DataRow r1 in dtcd_ts.Rows)
            {
                if (r1["loai"].ToString() == "0")
                {
                    cd_truoc += r1["chandoan"].ToString() + "^";
                }
                else
                {
                    cd_sau += r1["chandoan"].ToString() + "^";
                }
            }
            foreach (DataRow r2 in dtpppttt.Rows)
            {
                ppptkemtheo = r2["tenpt"].ToString() + "^";
            }
            r["chandoant"] = cd_t.Text + "^" + cd_truoc;
            r["chandoans"] = cd_s.Text + "^" + cd_sau;
            r["tenpt"] = tenpttt.Text + "^" + ppptkemtheo;
            r["loaipt"] = loaipt.Text;
            r["vocam"] = tenphuongphap.Text;
            r["ptv"] = _ptv.Substring(0, _ptv.Length - 1);
            r["phu1"] = _phu1.Substring(0, _phu1.Length - 1);
            r["phu2"] = _phu2.Substring(0, _phu2.Length - 1);
            r["bsgayme"] = _gayme1.Substring(0, _gayme1.Length - 1);
            r["ktvgayme"] = _gayme2.Substring(0, _gayme2.Length - 1);
            r["hoisuc"] = _hoisuc.Substring(0, _hoisuc.Length - 1);
            r["dungcu"] = _dungcu.Substring(0, _dungcu.Length - 1);
            r["noidung"] = noidung.Text;
            dttemp = m.get_data("select to_char(a.ngay,'dd/mm/yyyy') as ngayrv,b.ten,c.sovaovien,e.tennn from " + user + ".xuatvien a inner join " + user + ".ketqua b on a.ketqua=b.ma inner join " + user + ".benhandt c on a.maql=c.maql left join " + user + ".btdbn d on a.mabn=d.mabn left join " + user + ".btdnn_bv e on d.mann=e.mann where a.maql=" + l_maql).Tables[0];
            if (dttemp.Rows.Count > 0)
            {
                r["ngayrv"] = dttemp.Rows[0]["ngayrv"].ToString();
                r["ttlrv"] = dttemp.Rows[0]["ten"].ToString();
            }
            string xxx = m.mmyy(s);
            string sql = "select c.sovaovien,e.tennn from " + user + ".benhandt c inner join " + user + ".btdbn d on c.mabn=d.mabn left join " + user + ".btdnn_bv e on d.mann=e.mann where c.maql=" + l_maql;
            sql +=" union select c.sovaovien,e.tennn from " + user + xxx + ".benhanpk c inner join " + user + ".btdbn d on c.mabn=d.mabn left join " + user + ".btdnn_bv e on d.mann=e.mann where c.maql=" + l_maql;
            dttemp = m.get_data(sql).Tables[0];
            if (dttemp.Rows.Count > 0)
            {
                r["sovaovien"] = dttemp.Rows[0]["sovaovien"].ToString();
                r["tennn"] = dttemp.Rows[0]["tennn"].ToString();
                r["nhommau"] = cmbNhomMau.Text;
            }
            dsxml.Tables[0].Rows.Add(r);
            if (chkXml.Checked)
            {
                if (!System.IO.Directory.Exists("..//xml")) System.IO.Directory.CreateDirectory("..//xml");
                dsxml.WriteXml("..//xml//pttt.xml", XmlWriteMode.WriteSchema);
            }
            if (chkXem.Checked)
            {
                dllReportM.frmReport f = new dllReportM.frmReport(m, dsxml, "", report_name, true);
                f.ShowDialog();
            }
            else print.Printer(m, dsxml, report_name, "", 1);
            butMoi.Focus();
        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (l_idduoc != 0L)
            {
                string _mmyy = m.mmyy(ngay.Text);
                if (m.bMmyy(_mmyy))
                {
                    //if (l_id != 0)
                    //{
                    //    m.execute_data("update " + m.user + _mmyy + ".pttt set lanin=lanin+1 where id=" + l_id);
                    //}
                    string _usermmyy = user + _mmyy;
                    sql = "select g.ten as tennhom,b.stt,b.makho,t.manguon,e.ten as nguon,b.madoituong,d.doituong,b.mabd,a.ma,";
                    sql += " trim(a.ten)||' '||a.hamluong as ten,a.dang,c.ten as tenhang,b.soluong,t.giaban,b.soluong*t.giaban as sotien,m.tenkp khoachuyen,n.ten tenpmo ";
                    sql += " from " + user + ".d_dmbd a inner join xxx.d_xuatsdct b on a.id=b.mabd";
                    sql += " inner join " + user + ".d_dmhang c on a.mahang=c.id ";
                    sql += " left join " + user + ".d_doituong d on b.madoituong=d.madoituong ";
                    sql += " inner join xxx.d_theodoi t on b.sttt=t.id ";
                    sql += " inner join " + user + ".d_dmnguon e on t.manguon=e.id ";
                    sql += " left join " + user + ".d_dmnhom f on a.manhom=f.id ";
                    sql += " left join " + user + ".v_nhomvp g on f.nhomvp=g.ma ";
                    sql += " left join " + _usermmyy + ".pttt k on b.id=k.idduoc ";
                    sql += " left join " + _usermmyy + ".v_chidinh l on k.idchidinh=l.id ";
                    sql += " left join " + user + ".btdkp_bv m on l.makp=m.makp ";
                    sql += " left join " + user + ".btdpmo n on k.mapmo=n.ma ";
                    sql += " where b.id=" + l_idduoc + " order by b.stt";
                    DataSet dset = m.get_data_mmyy(sql, ngay.Text, ngay.Text, true);
                    if (dset.Tables[0].Rows.Count == 0)
                    {
                        MessageBox.Show(this.lan.Change_language_MessageText("Không có số liệu"));
                        return;
                    }
                    string strPtvChinh = tenbs.Text.Trim();
                    string strPhu1 = tenphu1.Text.Trim();
                    string strPhu2 = tenphu2.Text.Trim();
                    string strBSGayme = tenbsgayme.Text.Trim();
                    string strKTVGayme = tenktvgayme.Text.Trim();
                    string strDungcu = tendungcu.Text.Trim();
                    string strHoisuc = tenhoisuc.Text.Trim();
                    dset.Tables[0].Columns.Add("mabn");
                    dset.Tables[0].Columns.Add("hoten");
                    dset.Tables[0].Columns.Add("tuoi");
                    dset.Tables[0].Columns.Add("phai");
                    dset.Tables[0].Columns.Add("diachi");
                    dset.Tables[0].Columns.Add("khoa");
                    dset.Tables[0].Columns.Add("giuong");
                    dset.Tables[0].Columns.Add("ngayvv");
                    dset.Tables[0].Columns.Add("ngaypt");
                    dset.Tables[0].Columns.Add("chandoanvk");
                    dset.Tables[0].Columns.Add("chandoant");
                    dset.Tables[0].Columns.Add("chandoans");
                    dset.Tables[0].Columns.Add("tenpt");
                    dset.Tables[0].Columns.Add("loaipt");
                    dset.Tables[0].Columns.Add("vocam");
                    dset.Tables[0].Columns.Add("ptv");
                    dset.Tables[0].Columns.Add("phu1");
                    dset.Tables[0].Columns.Add("phu2");
                    dset.Tables[0].Columns.Add("bsgayme");
                    dset.Tables[0].Columns.Add("ktvgayme");
                    dset.Tables[0].Columns.Add("hoisuc");
                    dset.Tables[0].Columns.Add("dungcu");
                    dset.Tables[0].Columns.Add("noidung");
                    dset.Tables[0].Columns.Add("sophieu");
                    dset.Tables[0].Columns.Add("tendoituong");
                    dset.Tables[0].Columns.Add("sothe");
                    dset.Tables[0].Columns.Add("ghichu");
                    //dset.Tables[0].Columns.Add("tenuser");
                    dset.Tables[0].Columns.Add("userid");
                    dset.Tables[0].Columns.Add("noichuyen");
                    foreach (DataRow row in dset.Tables[0].Rows)
                    {
                        row["mabn"] = mabn2.Text + mabn3.Text;
                        row["hoten"] = hoten.Text;
                        row["tuoi"] = tuoi.Text;
                        row["phai"] = phai.Text;
                        row["diachi"] = diachi.Text;
                        row["khoa"] = tenkp.Text;
                        row["giuong"] = giuong.Text;
                        string strNgayvv = ngayvv.Text + " " + giovv.Text;
                        if (strNgayvv.Length == 0x10)
                        {
                            row["ngayvv"] = strNgayvv.Substring(11, 2) + " giờ " + strNgayvv.Substring(14, 2) + " phút,        Ngày " + strNgayvv.Substring(0, 2) + " tháng " + strNgayvv.Substring(3, 2) + " năm " + strNgayvv.Substring(6, 4);
                        }
                        strNgayvv = ngay.Text + " " + gio.Text;
                        row["ngaypt"] = strNgayvv.Substring(11, 2) + " giờ " + strNgayvv.Substring(14, 2) + " phút,        Ngày " + strNgayvv.Substring(0, 2) + " tháng " + strNgayvv.Substring(3, 2) + " năm " + strNgayvv.Substring(6, 4);
                        row["chandoanvk"] = cd_vk.Text;
                        row["chandoant"] = cd_t.Text;
                        row["chandoans"] = cd_s.Text;
                        row["tenpt"] = tenpttt.Text;
                        row["loaipt"] = loaipt.Text;
                        row["vocam"] = tenphuongphap.Text;
                        row["ptv"] = strPtvChinh;//.Substring(0, strPtvChinh.Length - 1);
                        row["phu1"] = strPhu1;//.Substring(0, strPhu1.Length - 1);
                        row["phu2"] = strPhu2;//.Substring(0, strPhu2.Length - 1);
                        row["bsgayme"] = strBSGayme;//.Substring(0, strBSGayme.Length - 1);
                        row["ktvgayme"] = strKTVGayme;//.Substring(0, strKTVGayme.Length - 1);
                        row["hoisuc"] = strHoisuc;//.Substring(0, strHoisuc.Length - 1);
                        row["dungcu"] = strDungcu;//.Substring(0, strDungcu.Length - 1);
                        row["noidung"] = noidung.Text;
                        row["sophieu"] = sophieu.Text;
                        //row["ghichu"] = ghichu.Text;
                        row["tendoituong"] = madoituong.Text;
                        row["sothe"] = sothe.Text;
                        //row["tenuser"] = s_userid;
                        row["userid"] = m_userid;
                        //row["noichuyen"] = mabn3.Tag.ToString();
                    }
                    if (chkXml.Checked)
                    {
                        if (!System.IO.Directory.Exists("..//xml"))
                        {
                            System.IO.Directory.CreateDirectory("..//xml");
                        }
                        dset.WriteXml("..//xml//qtpttt.xml", XmlWriteMode.WriteSchema);
                    }

                    if (chkXem.Checked)
                    {
                        new frmReport(m, dset, "", "rQtpttt.rpt", true).ShowDialog();
                    }
                    else
                    {
                        print.Printer(m, dset, "rQtpttt.rpt", "", 1);
                    }
                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            print_pttt("rptChungNhanPTTT.rpt");
        }

        private void p_Paint(object sender, PaintEventArgs e)
        {

        }
	}
}
