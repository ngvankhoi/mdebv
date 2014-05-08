using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Data;
using LibDuoc;
using LibMedi;
using LibVienphi;

namespace Medisoft
{
	public class frmBaohiem : System.Windows.Forms.Form
    {
        //linh
        int i_songaytoathuoccancanhbao = 0;
        //end linh
        #region Khai bao
        Language lan = new Language(); Bogotiengviet tv = new Bogotiengviet(); private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        private int i_maxlength_mabn = 8;
        private bool bXemToaCu = false;
		private System.Windows.Forms.Label label1;
		private MaskedTextBox.MaskedTextBox mabn;
		private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox hoten;
		private System.Windows.Forms.TextBox tenbd;
		private System.Windows.Forms.TextBox tenhc;
		private System.Windows.Forms.Label lTenhc;
		private System.Windows.Forms.TextBox mabd;
		private System.Windows.Forms.Label lTen;
        private System.Windows.Forms.Label lMabd;
		private MaskedTextBox.MaskedTextBox soluong;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label ldvt;
		private System.Windows.Forms.TextBox cachdung;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.Button butKetthuc;
		private System.Windows.Forms.Button butHuy;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.Button butXoa;
		private System.Windows.Forms.Button butThem;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butSua;
		private System.Windows.Forms.Button butMoi;
		private System.Windows.Forms.Button butCholai;
		private System.Windows.Forms.ComboBox cmbMabn;
		private LibDuoc.AccessData d=new LibDuoc.AccessData();
		private LibMedi.AccessData m=new LibMedi.AccessData();
		private LibMedi.AccessData v=new LibMedi.AccessData();
        private int i_nhom, i_userid, i_old, i_loai, i_mabd, i_sudungthuoc, i_madoituong, i_bhyt_inrieng, i_loaiba, iUserid_duyet, itable, i_mabdcu, i_makhocu, i_manguoncu, iUserid_donve,i_tunguyen,iBhyt_songay,i_row,i_col,i_w,i_h,traituyen,i_khudt=0;
        private int iKhoangcachngaycaptoa_voingaykham = 0, iSotien_cancanhbao_khicaptoa=0;
        private string user, nam, s_makho, s_makho_kp, s_ngay, s_ngay_kham, sql, s_mmyy, s_manguon, s_msg, s_diachi, s_bhyt, s_ngayht, xxx="", zzz, s_noidkkcb, s_madoituong, s_ngayvao, ngay1, ngay2, ngay3, ngay_reset_phieu38 = "";
        private string s_mabn, s_Hoten, s_Phai="", s_Namsinh, s_Sothe, s_Tenkp, s_Tenbs, s_Maicd, s_Chandoan, s_makp, s_mabs, s_doituong, s_ngaymakp = "", s_user, s_ngayvv = "", s_cholam = "", s_trieuchung = "", makhosave = "", f_soluong;
        private string s_mabncaptoa = "";
        private decimal l_id = 0, l_maql, l_mavaovien,l_sotoa =0 ;
        private decimal d_soluongcu, d_soluong, d_soluongton;
        private bool bNew, bEdit, bDiungthuoc, bDone, bChidinh, bKiemtrathuoc, bSolan, bLetet, bDieutringtr, bLuu_Donthuoc_bacsy, bDuyet = false, bInchitiet = false, bKhoaso, bCachdung, bMuangoai_tonkho, bTongtien_donduyet, bGiaban_theodot, bDonthuoc_stc, bGiaban, bAdmin, bAdminInlaidonthuoc, bChonkhoa, bNgoaitonkho, bDuyet_donve, bDuyet_donvepl, bBamhuyet, bTayy, bDutru_n_thuoc, bMabd_doituong, bNgayhienhanh_thuoc_chidinh, bThuphi_khongloadthuoc_BHYT, bCaptoa_theodanhmuc_duocketoa, bkhongdu_soluong=false;
		private LibList.List listDmbd;
		private LibList.List listCachdung;
        private bool bDichvu_vpkb = false, bDuyet_khambenh = false;// gam 25/10/2011
        private int i_loaibn = 0;//gam 07/03/2012
        private bool b_BNDaravien = false;

		private DataRow r;
        private DataTable dtngay = new DataTable();
        private DataTable dtdon = new DataTable();
		private DataTable dtton=new DataTable();
		private DataTable dtll=new DataTable();
		private DataTable dtct=new DataTable();
		private DataTable dtsave=new DataTable();
		private DataTable dtdmbd=new DataTable();
		private DataSet dsxoa=new DataSet();
        private DataTable dthoten=new DataTable();
        private DataTable dtbs = new DataTable();
        private DataTable dtkho = new DataTable();
        private DataTable dtnguon = new DataTable();
        private DataTable dthuyet = new DataTable();
        private DataTable dtLoidan = new DataTable();
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.ComboBox makho;
		private System.Windows.Forms.TextBox stt;
		private System.Windows.Forms.Label diung;
		private System.Windows.Forms.TextBox mahc;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.ComboBox manguon;
		private System.Windows.Forms.TreeView treeView1;
		private System.Windows.Forms.TextBox namsinh;
		private System.Windows.Forms.TextBox sothe;
		private System.Windows.Forms.TextBox chandoan;
		private System.Windows.Forms.TextBox maicd;
		private System.Windows.Forms.TextBox tenpk;
		private System.Windows.Forms.TextBox tenbs;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label lblbacsy;
		private System.Windows.Forms.Button butIn;
        private dllReportM.Print print = new dllReportM.Print();
        private System.Windows.Forms.Button butHen;
		private System.Windows.Forms.Label lghichu;
        private System.Windows.Forms.TextBox ghichu;
		private System.Windows.Forms.NumericUpDown songay;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
        private Label label11;
        private NumericUpDown solan;
        private TextBox makp;
        private TextBox mabs;
        private DataTable dtletet = new DataTable();
        private Label label12;
        private MaskedTextBox.MaskedTextBox moilan;
        private Label lbldvt;
        private ComboBox donthuoc;
        private CheckBox chkChon;
        private ToolTip toolTip1;
        private IContainer components;
        private byte[] image;
        private System.IO.MemoryStream memo;
        private System.IO.FileStream fstr;
        private MaskedTextBox.MaskedTextBox sum;
        private Label lblsum;
        private Panel p1;
        private Panel p2;
        private CheckBox chk2;
        private CheckBox chk1;
        private MaskedTextBox.MaskedTextBox c4;
        private MaskedTextBox.MaskedTextBox c3;
        private MaskedTextBox.MaskedTextBox c2;
        private Label label15;
        private MaskedTextBox.MaskedTextBox c1;
        private Label label14;
        private Label lblduongdung;
        private Label label19;
        private MaskedTextBox.MaskedTextBox soluong1;
        private Bitmap map;
        private bool bNgtru_dt_makp, bTinnhan_sound, bTinnhan;
        private int dt_ngtru = 0, kho_ngtru;
        private LibList.List listHoten;
        private LibList.List listBS;
        private ComboBox madoituong;
        private Label label13;
        private string makp_kho_dt;
        
        private Button butTuongtac;
        private Button butGoi;
        private TextBox dang;
        private CheckBox chkChitiet;
        private ComboBox huyet;
        private CheckBox chkHuyet;
        private TextBox tim;
        private Button butDongy;
        private NumericUpDown banin;
        private DataGrid dataGrid1;
        private bool bLocdichvu;
        private Label lbldungluc;
        private MaskedTextBox.MaskedTextBox txtgiaban;
        private MaskedTextBox.MaskedTextBox txtdongia;
        private bool bXemlai=false,bbadt=false;
        #endregion

        private string s_Huongtamthan = "";
        private NumericUpDown ngaynghi;
        private Label label8;
        private Label label21;
        private bool bHuongtanthan = false,bDondichvu_capnhieulantrongngay=false;
        private TextBox ghichuct;
        private Label label23;
        private Label label24;
        private Label lblGiaban;
        private Label lblGiamua;
        protected MaskedBox.MaskedBox txtNgaynghi_tungay;
        protected MaskedBox.MaskedBox txtNgaynghi_denngay;
        private Label label29;
        private Label label30;
        private Label label31;
        private NumericUpDown txtHen;
        private Label label32;
        private ToolStrip toolStrip1;
        private ToolStripDropDownButton toolTuychon;
        private ToolStripMenuItem chkThuoc;
        private ToolStripMenuItem chkXem;
        private ToolStripMenuItem chkXML;
        private ToolStripMenuItem chkVP;
        private ToolStripMenuItem chkTodieutri;
        private ToolStripMenuItem chkLuuin;
        private ToolStripMenuItem chkDoituong;
        private ToolStripMenuItem chkDongia;
        private ToolStripMenuItem chkQuanlyngaynghiphep;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripLabel toolStripLabel1;
        private ToolStripMenuItem chkCanhbaotoathuoclonhon10ngay;
        private Label label7;
        private Label label17;
        private Label label18;
        private ToolStripMenuItem chkDongy;
        private LibList.List listLoidan;
        private LibList.List listICD;
        private string s_ngaydonthuoc = "";
        private bool bToaThuocF5_TuDong_TruTonkho_F44 = false, bCaptoa_TheodmloaiDuocphepcaptoa_F45 = false, bgiaBHYT_Quidinh = false;
        private MaskedTextBox.MaskedTextBox tong_chiphi;
        private Label label26;
        private Label label27;
        private MaskedTextBox.MaskedTextBox tong_chidinh;
    
        public frmBaohiem(bool dieutringtr, string mabn, int loai, string mmyy, string ngay, int nhom,
            int userid, string title, decimal mavaovien, decimal lMaql, string sHoten, string sNamsinh,
            string sSothe, string sTenkp, string sTenbs, string sMaicd, string sChandoan, int madoituong,
            string makp, string _mabs, string doituong, string _cholam, string diachi, string _nam,
            string _t2, int loaiba, string _noidkkcb, bool chonkhoa, string _madoituong, string _ngayvao,
            string _trieuchung,int _traituyen,string _ngay1,string _ngay2,string _ngay3, string _phai,
            bool xemlai, int _khudt)
		{
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
            lan.Changelanguage_to_English(this.Name.ToString(), this); if (m.bBogo) tv.GanBogo(this, textBox111);
            s_mmyy = mmyy; s_ngay = ngay; s_ngay_kham = ngay; i_loai = loai; s_noidkkcb = _noidkkcb;
            s_mabn = mabn; l_maql = lMaql; i_loaiba = loaiba; bChonkhoa = chonkhoa; s_cholam = _cholam;
            s_mabncaptoa = s_mabn;//gam 08/03/2012
            s_Hoten = sHoten; bDieutringtr = dieutringtr; s_madoituong = _madoituong;
            s_Sothe = sSothe; s_Tenkp = sTenkp; s_Tenbs = sTenbs; maicd.Text=s_Maicd = sMaicd; s_Chandoan = sChandoan;
            i_userid = userid; s_makp = makp; mabs.Text=s_mabs = _mabs; l_mavaovien = mavaovien;
            i_nhom = nhom; i_madoituong = madoituong; s_doituong = doituong;
            s_trieuchung = _trieuchung; traituyen = _traituyen; ngay1 = _ngay1; ngay2 = _ngay2; ngay3 = _ngay3;
            s_Namsinh = sNamsinh;
            bXemlai = xemlai;
            s_Phai = _phai;
            i_khudt = _khudt;
            s_ngaydonthuoc = ngay;
            this.Text = title; s_diachi = diachi; nam = _nam; s_bhyt = _t2; s_ngayvao = _ngayvao;
		}        
        public frmBaohiem(bool dieutringtr, string mabn, int loai, string mmyy, string ngay,
            int nhom, int userid, string title, decimal mavaovien, decimal lMaql, string sHoten,
            string sNamsinh, string sSothe, string sTenkp, string sTenbs, string sMaicd,
            string sChandoan, int madoituong, string makp, string _mabs, string doituong,
            string _cholam, string diachi, string _nam, string _t2, int loaiba, string _noidkkcb,
            bool chonkhoa, string _madoituong, string _ngayvao, string _trieuchung, int _traituyen,
            string _ngay1, string _ngay2, string _ngay3, string _phai, int _khudt, int loaibn)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this); if (m.bBogo) tv.GanBogo(this, textBox111);
            s_mmyy = mmyy; s_ngay = ngay; s_ngay_kham = ngay; i_loai = loai; s_noidkkcb = _noidkkcb;
            s_mabn = mabn; l_maql = lMaql; i_loaiba = loaiba; bChonkhoa = chonkhoa; s_cholam = _cholam;
            s_mabncaptoa = s_mabn;//gam 08/03/2012
            s_Hoten = sHoten; bDieutringtr = dieutringtr; s_madoituong = _madoituong;
            s_Sothe = sSothe; s_Tenkp = sTenkp; s_Tenbs = sTenbs; maicd.Text = s_Maicd = sMaicd; s_Chandoan = sChandoan;
            i_userid = userid; s_makp = makp; mabs.Text = s_mabs = _mabs; l_mavaovien = mavaovien;
            i_nhom = nhom; i_madoituong = madoituong; s_doituong = doituong;
            s_trieuchung = _trieuchung; traituyen = _traituyen; ngay1 = _ngay1; ngay2 = _ngay2; ngay3 = _ngay3;
            s_Namsinh = sNamsinh;
            s_Phai = _phai;
            i_khudt = _khudt;
            s_ngaydonthuoc = ngay;
            i_loaibn = loaibn;//gam 07/03/2012
            this.Text = title; s_diachi = diachi; nam = _nam; s_bhyt = _t2; s_ngayvao = _ngayvao;
            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
        public frmBaohiem(bool dieutringtr, string mabn, int loai, string mmyy, string ngay, int nhom,
            int userid, string title, decimal mavaovien, decimal lMaql, string sHoten, string sNamsinh,
            string sSothe, string sTenkp, string sTenbs, string sMaicd, string sChandoan, int madoituong,
            string makp, string _mabs, string doituong, string _cholam, string diachi, string _nam,
            string _t2, int loaiba, string _noidkkcb, bool chonkhoa, string _madoituong, string _ngayvao,
            string _trieuchung, int _traituyen, string _ngay1, string _ngay2, string _ngay3, string _phai)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this); if (m.bBogo) tv.GanBogo(this, textBox111);
            s_mmyy = mmyy; s_ngay = ngay; s_ngay_kham = ngay; i_loai = loai; s_noidkkcb = _noidkkcb;
            s_mabn = mabn; l_maql = lMaql; i_loaiba = loaiba; bChonkhoa = chonkhoa; s_cholam = _cholam;
            s_mabncaptoa = s_mabn;//gam 08/03/2012
            s_Hoten = sHoten; bDieutringtr = dieutringtr; s_madoituong = _madoituong;
            s_Sothe = sSothe; s_Tenkp = sTenkp; s_Tenbs = sTenbs; maicd.Text = s_Maicd = sMaicd; s_Chandoan = sChandoan;
            i_userid = userid; s_makp = makp; mabs.Text = s_mabs = _mabs; l_mavaovien = mavaovien;
            i_nhom = nhom; i_madoituong = madoituong; s_doituong = doituong;
            s_trieuchung = _trieuchung; traituyen = _traituyen; ngay1 = _ngay1; ngay2 = _ngay2; ngay3 = _ngay3;
            s_Namsinh = sNamsinh;
            s_Phai = _phai;
            s_ngaydonthuoc = ngay;
            this.Text = title; s_diachi = diachi; nam = _nam; s_bhyt = _t2; s_ngayvao = _ngayvao;
            
            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
		//Tu:25/05/2011
        public frmBaohiem(bool dieutringtr, string mabn, int loai, string mmyy, string ngay, int nhom,
            int userid, string title, decimal mavaovien, decimal lMaql, string sHoten, string sNamsinh,
            string sSothe, string sTenkp, string sTenbs, string sMaicd, string sChandoan,
            int madoituong, string makp, string _mabs, string doituong, string _cholam,
            string diachi, string _nam, string _t2, int loaiba, string _noidkkcb, bool chonkhoa,
            string _madoituong, string _ngayvao, string _trieuchung, int _traituyen, string _ngay1, 
            string _ngay2, string _ngay3, string _phai, bool xemlai, int _khudt,bool _badt)
        {
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this); if (m.bBogo) tv.GanBogo(this, textBox111);
            s_mmyy = mmyy; s_ngay = ngay; s_ngay_kham = ngay; i_loai = loai; s_noidkkcb = _noidkkcb;
            s_mabn = mabn; l_maql = lMaql; i_loaiba = loaiba; bChonkhoa = chonkhoa; s_cholam = _cholam;
            s_mabncaptoa = s_mabn;//gam 08/03/2012
            s_Hoten = sHoten; bDieutringtr = dieutringtr; s_madoituong = _madoituong;
            s_Sothe = sSothe; s_Tenkp = sTenkp; s_Tenbs = sTenbs; maicd.Text = s_Maicd = sMaicd; s_Chandoan = sChandoan;
            i_userid = userid; s_makp = makp; mabs.Text = s_mabs = _mabs; l_mavaovien = mavaovien;
            i_nhom = nhom; i_madoituong = madoituong; s_doituong = doituong;
            s_trieuchung = _trieuchung; traituyen = _traituyen; ngay1 = _ngay1; ngay2 = _ngay2; ngay3 = _ngay3;
            s_Namsinh = sNamsinh;
            bXemlai = xemlai;
            s_Phai = _phai;
            i_khudt = _khudt;
            s_ngaydonthuoc = ngay;
            this.Text = title; s_diachi = diachi; nam = _nam; s_bhyt = _t2; s_ngayvao = _ngayvao;
            bbadt = _badt;
        }        
        //end Tu

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBaohiem));
            this.label1 = new System.Windows.Forms.Label();
            this.mabn = new MaskedTextBox.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.hoten = new System.Windows.Forms.TextBox();
            this.tenbd = new System.Windows.Forms.TextBox();
            this.tenhc = new System.Windows.Forms.TextBox();
            this.lTenhc = new System.Windows.Forms.Label();
            this.mabd = new System.Windows.Forms.TextBox();
            this.lTen = new System.Windows.Forms.Label();
            this.lMabd = new System.Windows.Forms.Label();
            this.soluong = new MaskedTextBox.MaskedTextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.ldvt = new System.Windows.Forms.Label();
            this.cachdung = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.cmbMabn = new System.Windows.Forms.ComboBox();
            this.listDmbd = new LibList.List();
            this.listCachdung = new LibList.List();
            this.label20 = new System.Windows.Forms.Label();
            this.makho = new System.Windows.Forms.ComboBox();
            this.stt = new System.Windows.Forms.TextBox();
            this.diung = new System.Windows.Forms.Label();
            this.mahc = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.manguon = new System.Windows.Forms.ComboBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.namsinh = new System.Windows.Forms.TextBox();
            this.sothe = new System.Windows.Forms.TextBox();
            this.chandoan = new System.Windows.Forms.TextBox();
            this.maicd = new System.Windows.Forms.TextBox();
            this.tenpk = new System.Windows.Forms.TextBox();
            this.tenbs = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblbacsy = new System.Windows.Forms.Label();
            this.lghichu = new System.Windows.Forms.Label();
            this.ghichu = new System.Windows.Forms.TextBox();
            this.songay = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.solan = new System.Windows.Forms.NumericUpDown();
            this.makp = new System.Windows.Forms.TextBox();
            this.mabs = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.moilan = new MaskedTextBox.MaskedTextBox();
            this.lbldvt = new System.Windows.Forms.Label();
            this.donthuoc = new System.Windows.Forms.ComboBox();
            this.chkChon = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.sum = new MaskedTextBox.MaskedTextBox();
            this.lblsum = new System.Windows.Forms.Label();
            this.p1 = new System.Windows.Forms.Panel();
            this.p2 = new System.Windows.Forms.Panel();
            this.c3 = new MaskedTextBox.MaskedTextBox();
            this.soluong1 = new MaskedTextBox.MaskedTextBox();
            this.c1 = new MaskedTextBox.MaskedTextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.ghichuct = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.c4 = new MaskedTextBox.MaskedTextBox();
            this.lblduongdung = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.c2 = new MaskedTextBox.MaskedTextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.chk1 = new System.Windows.Forms.CheckBox();
            this.chk2 = new System.Windows.Forms.CheckBox();
            this.listHoten = new LibList.List();
            this.listBS = new LibList.List();
            this.madoituong = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.dang = new System.Windows.Forms.TextBox();
            this.chkChitiet = new System.Windows.Forms.CheckBox();
            this.huyet = new System.Windows.Forms.ComboBox();
            this.chkHuyet = new System.Windows.Forms.CheckBox();
            this.tim = new System.Windows.Forms.TextBox();
            this.banin = new System.Windows.Forms.NumericUpDown();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.lbldungluc = new System.Windows.Forms.Label();
            this.txtgiaban = new MaskedTextBox.MaskedTextBox();
            this.txtdongia = new MaskedTextBox.MaskedTextBox();
            this.ngaynghi = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.butDongy = new System.Windows.Forms.Button();
            this.butGoi = new System.Windows.Forms.Button();
            this.butTuongtac = new System.Windows.Forms.Button();
            this.butHen = new System.Windows.Forms.Button();
            this.butIn = new System.Windows.Forms.Button();
            this.butCholai = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.butHuy = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butXoa = new System.Windows.Forms.Button();
            this.butThem = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.butSua = new System.Windows.Forms.Button();
            this.butMoi = new System.Windows.Forms.Button();
            this.lblGiaban = new System.Windows.Forms.Label();
            this.lblGiamua = new System.Windows.Forms.Label();
            this.txtNgaynghi_tungay = new MaskedBox.MaskedBox();
            this.txtNgaynghi_denngay = new MaskedBox.MaskedBox();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.txtHen = new System.Windows.Forms.NumericUpDown();
            this.label32 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolTuychon = new System.Windows.Forms.ToolStripDropDownButton();
            this.chkThuoc = new System.Windows.Forms.ToolStripMenuItem();
            this.chkXem = new System.Windows.Forms.ToolStripMenuItem();
            this.chkXML = new System.Windows.Forms.ToolStripMenuItem();
            this.chkVP = new System.Windows.Forms.ToolStripMenuItem();
            this.chkTodieutri = new System.Windows.Forms.ToolStripMenuItem();
            this.chkLuuin = new System.Windows.Forms.ToolStripMenuItem();
            this.chkDoituong = new System.Windows.Forms.ToolStripMenuItem();
            this.chkDongy = new System.Windows.Forms.ToolStripMenuItem();
            this.chkDongia = new System.Windows.Forms.ToolStripMenuItem();
            this.chkQuanlyngaynghiphep = new System.Windows.Forms.ToolStripMenuItem();
            this.chkCanhbaotoathuoclonhon10ngay = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.label7 = new System.Windows.Forms.Label();
            this.listLoidan = new LibList.List();
            this.listICD = new LibList.List();
            this.tong_chidinh = new MaskedTextBox.MaskedTextBox();
            this.tong_chiphi = new MaskedTextBox.MaskedTextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.songay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.solan)).BeginInit();
            this.p1.SuspendLayout();
            this.p2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.banin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ngaynghi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHen)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 23);
            this.label1.TabIndex = 25;
            this.label1.Text = "Mã BN :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mabn
            // 
            this.mabn.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabn.Enabled = false;
            this.mabn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabn.Location = new System.Drawing.Point(64, 28);
            this.mabn.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.mabn.MaxLength = 8;
            this.mabn.Name = "mabn";
            this.mabn.Size = new System.Drawing.Size(89, 21);
            this.mabn.TabIndex = 1;
            this.mabn.Validated += new System.EventHandler(this.mabn_Validated);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(151, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 23);
            this.label2.TabIndex = 26;
            this.label2.Text = "Họ tên :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // hoten
            // 
            this.hoten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.hoten.Enabled = false;
            this.hoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoten.Location = new System.Drawing.Point(200, 28);
            this.hoten.Name = "hoten";
            this.hoten.Size = new System.Drawing.Size(184, 21);
            this.hoten.TabIndex = 1;
            this.hoten.TextChanged += new System.EventHandler(this.hoten_TextChanged);
            this.hoten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.hoten_KeyDown);
            // 
            // tenbd
            // 
            this.tenbd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tenbd.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbd.Enabled = false;
            this.tenbd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbd.Location = new System.Drawing.Point(269, 421);
            this.tenbd.Name = "tenbd";
            this.tenbd.Size = new System.Drawing.Size(241, 21);
            this.tenbd.TabIndex = 17;
            this.tenbd.TextChanged += new System.EventHandler(this.tenbd_TextChanged);
            this.tenbd.Validated += new System.EventHandler(this.tenbd_Validated);
            this.tenbd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbd_KeyDown);
            // 
            // tenhc
            // 
            this.tenhc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tenhc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenhc.Enabled = false;
            this.tenhc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenhc.Location = new System.Drawing.Point(569, 421);
            this.tenhc.Name = "tenhc";
            this.tenhc.Size = new System.Drawing.Size(143, 21);
            this.tenhc.TabIndex = 18;
            this.tenhc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenhc_KeyDown);
            // 
            // lTenhc
            // 
            this.lTenhc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lTenhc.Location = new System.Drawing.Point(501, 419);
            this.lTenhc.Name = "lTenhc";
            this.lTenhc.Size = new System.Drawing.Size(69, 23);
            this.lTenhc.TabIndex = 56;
            this.lTenhc.Text = "Hoạt chất :";
            this.lTenhc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mabd
            // 
            this.mabd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.mabd.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mabd.Enabled = false;
            this.mabd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabd.Location = new System.Drawing.Point(170, 421);
            this.mabd.Name = "mabd";
            this.mabd.Size = new System.Drawing.Size(61, 21);
            this.mabd.TabIndex = 16;
            this.mabd.TextChanged += new System.EventHandler(this.mabd_TextChanged);
            this.mabd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabd_KeyDown);
            // 
            // lTen
            // 
            this.lTen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lTen.Location = new System.Drawing.Point(239, 422);
            this.lTen.Name = "lTen";
            this.lTen.Size = new System.Drawing.Size(32, 23);
            this.lTen.TabIndex = 55;
            this.lTen.Text = "Tên :";
            this.lTen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lMabd
            // 
            this.lMabd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lMabd.Location = new System.Drawing.Point(142, 422);
            this.lMabd.Name = "lMabd";
            this.lMabd.Size = new System.Drawing.Size(31, 23);
            this.lMabd.TabIndex = 54;
            this.lMabd.Text = "Mã :";
            this.lMabd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // soluong
            // 
            this.soluong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.soluong.Enabled = false;
            this.soluong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.soluong.Location = new System.Drawing.Point(296, 1);
            this.soluong.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
            this.soluong.Name = "soluong";
            this.soluong.Size = new System.Drawing.Size(46, 21);
            this.soluong.TabIndex = 2;
            this.soluong.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.soluong.Validated += new System.EventHandler(this.soluong_Validated);
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(234, -1);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(56, 23);
            this.label16.TabIndex = 63;
            this.label16.Text = "Số lượng :";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ldvt
            // 
            this.ldvt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ldvt.Location = new System.Drawing.Point(707, 422);
            this.ldvt.Name = "ldvt";
            this.ldvt.Size = new System.Drawing.Size(39, 23);
            this.ldvt.TabIndex = 57;
            this.ldvt.Text = "ĐVT :";
            this.ldvt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cachdung
            // 
            this.cachdung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cachdung.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cachdung.Enabled = false;
            this.cachdung.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cachdung.Location = new System.Drawing.Point(400, 1);
            this.cachdung.Name = "cachdung";
            this.cachdung.Size = new System.Drawing.Size(222, 21);
            this.cachdung.TabIndex = 28;
            this.cachdung.TextChanged += new System.EventHandler(this.cachdung_TextChanged);
            this.cachdung.Validated += new System.EventHandler(this.cachdung_Validated);
            this.cachdung.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cachdung_KeyDown);
            // 
            // label25
            // 
            this.label25.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label25.Location = new System.Drawing.Point(316, 1);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(88, 21);
            this.label25.TabIndex = 64;
            this.label25.Text = "Cách dùng :";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbMabn
            // 
            this.cmbMabn.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cmbMabn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMabn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMabn.Location = new System.Drawing.Point(64, 28);
            this.cmbMabn.Name = "cmbMabn";
            this.cmbMabn.Size = new System.Drawing.Size(89, 21);
            this.cmbMabn.TabIndex = 0;
            this.cmbMabn.SelectedIndexChanged += new System.EventHandler(this.cmbMabn_SelectedIndexChanged);
            this.cmbMabn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbMabn_KeyDown);
            // 
            // listDmbd
            // 
            this.listDmbd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.listDmbd.BackColor = System.Drawing.SystemColors.Info;
            this.listDmbd.ColumnCount = 0;
            this.listDmbd.Location = new System.Drawing.Point(77, 560);
            this.listDmbd.MatchBufferTimeOut = 1000;
            this.listDmbd.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listDmbd.Name = "listDmbd";
            this.listDmbd.Size = new System.Drawing.Size(75, 17);
            this.listDmbd.TabIndex = 89;
            this.listDmbd.TextIndex = -1;
            this.listDmbd.TextMember = null;
            this.listDmbd.ValueIndex = -1;
            this.listDmbd.Visible = false;
            this.listDmbd.DoubleClick += new System.EventHandler(this.listDmbd_DoubleClick);
            this.listDmbd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listDmbd_KeyDown);
            // 
            // listCachdung
            // 
            this.listCachdung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.listCachdung.BackColor = System.Drawing.SystemColors.Info;
            this.listCachdung.ColumnCount = 0;
            this.listCachdung.Location = new System.Drawing.Point(280, 555);
            this.listCachdung.MatchBufferTimeOut = 1000;
            this.listCachdung.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listCachdung.Name = "listCachdung";
            this.listCachdung.Size = new System.Drawing.Size(75, 17);
            this.listCachdung.TabIndex = 92;
            this.listCachdung.TextIndex = -1;
            this.listCachdung.TextMember = null;
            this.listCachdung.ValueIndex = -1;
            this.listCachdung.Visible = false;
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label20.Location = new System.Drawing.Point(141, 468);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(34, 23);
            this.label20.TabIndex = 58;
            this.label20.Text = "Kho :";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // makho
            // 
            this.makho.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.makho.BackColor = System.Drawing.SystemColors.HighlightText;
            this.makho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.makho.Enabled = false;
            this.makho.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makho.Location = new System.Drawing.Point(171, 470);
            this.makho.Name = "makho";
            this.makho.Size = new System.Drawing.Size(97, 21);
            this.makho.TabIndex = 25;
            // 
            // stt
            // 
            this.stt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.stt.Enabled = false;
            this.stt.Location = new System.Drawing.Point(688, 231);
            this.stt.Name = "stt";
            this.stt.Size = new System.Drawing.Size(24, 20);
            this.stt.TabIndex = 53;
            // 
            // diung
            // 
            this.diung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.diung.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diung.ForeColor = System.Drawing.Color.Blue;
            this.diung.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.diung.Location = new System.Drawing.Point(276, 2);
            this.diung.Name = "diung";
            this.diung.Size = new System.Drawing.Size(75, 23);
            this.diung.TabIndex = 33;
            this.diung.Text = "DỊ ỨNG";
            this.diung.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.diung.Click += new System.EventHandler(this.diung_Click);
            // 
            // mahc
            // 
            this.mahc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mahc.Location = new System.Drawing.Point(701, 195);
            this.mahc.Name = "mahc";
            this.mahc.Size = new System.Drawing.Size(48, 20);
            this.mahc.TabIndex = 50;
            // 
            // label22
            // 
            this.label22.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label22.Location = new System.Drawing.Point(4, 469);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(54, 23);
            this.label22.TabIndex = 59;
            this.label22.Text = "Nguồn :";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // manguon
            // 
            this.manguon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.manguon.BackColor = System.Drawing.SystemColors.HighlightText;
            this.manguon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.manguon.Enabled = false;
            this.manguon.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manguon.Location = new System.Drawing.Point(59, 469);
            this.manguon.Name = "manguon";
            this.manguon.Size = new System.Drawing.Size(87, 21);
            this.manguon.TabIndex = 24;
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.ItemHeight = 16;
            this.treeView1.Location = new System.Drawing.Point(628, 145);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(161, 245);
            this.treeView1.TabIndex = 49;
            this.toolTip1.SetToolTip(this.treeView1, "F7 Cho lại");
            this.treeView1.DoubleClick += new System.EventHandler(this.treeView1_DoubleClick);
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeView1_KeyDown);
            // 
            // namsinh
            // 
            this.namsinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.namsinh.Enabled = false;
            this.namsinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namsinh.Location = new System.Drawing.Point(459, 27);
            this.namsinh.Name = "namsinh";
            this.namsinh.Size = new System.Drawing.Size(32, 21);
            this.namsinh.TabIndex = 2;
            // 
            // sothe
            // 
            this.sothe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sothe.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sothe.Enabled = false;
            this.sothe.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sothe.Location = new System.Drawing.Point(611, 27);
            this.sothe.Name = "sothe";
            this.sothe.Size = new System.Drawing.Size(176, 21);
            this.sothe.TabIndex = 3;
            // 
            // chandoan
            // 
            this.chandoan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.chandoan.Enabled = false;
            this.chandoan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chandoan.Location = new System.Drawing.Point(64, 51);
            this.chandoan.Name = "chandoan";
            this.chandoan.Size = new System.Drawing.Size(320, 21);
            this.chandoan.TabIndex = 4;
            this.chandoan.TextChanged += new System.EventHandler(this.chandoan_TextChanged);
            this.chandoan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chandoan_KeyDown);
            // 
            // maicd
            // 
            this.maicd.BackColor = System.Drawing.SystemColors.HighlightText;
            this.maicd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.maicd.Enabled = false;
            this.maicd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maicd.Location = new System.Drawing.Point(346, 51);
            this.maicd.Name = "maicd";
            this.maicd.Size = new System.Drawing.Size(38, 21);
            this.maicd.TabIndex = 5;
            this.maicd.TextChanged += new System.EventHandler(this.maicd_TextChanged);
            this.maicd.Validated += new System.EventHandler(this.maicd_Validated);
            this.maicd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.maicd_KeyDown);
            // 
            // tenpk
            // 
            this.tenpk.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenpk.Enabled = false;
            this.tenpk.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenpk.Location = new System.Drawing.Point(459, 50);
            this.tenpk.Name = "tenpk";
            this.tenpk.Size = new System.Drawing.Size(110, 21);
            this.tenpk.TabIndex = 6;
            // 
            // tenbs
            // 
            this.tenbs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tenbs.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbs.Enabled = false;
            this.tenbs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbs.Location = new System.Drawing.Point(611, 51);
            this.tenbs.Name = "tenbs";
            this.tenbs.Size = new System.Drawing.Size(177, 21);
            this.tenbs.TabIndex = 7;
            this.tenbs.TextChanged += new System.EventHandler(this.tenbs_TextChanged);
            this.tenbs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbs_KeyDown);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(395, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 23);
            this.label3.TabIndex = 29;
            this.label3.Text = "Năm sinh :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(567, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 23);
            this.label4.TabIndex = 31;
            this.label4.Text = "Số thẻ :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(-11, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 23);
            this.label5.TabIndex = 34;
            this.label5.Text = "Chẩn đoán :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(379, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 23);
            this.label6.TabIndex = 37;
            this.label6.Text = "Khoa/phòng :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblbacsy
            // 
            this.lblbacsy.Location = new System.Drawing.Point(570, 51);
            this.lblbacsy.Name = "lblbacsy";
            this.lblbacsy.Size = new System.Drawing.Size(45, 23);
            this.lblbacsy.TabIndex = 39;
            this.lblbacsy.Text = "Bác sỹ :";
            this.lblbacsy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lghichu
            // 
            this.lghichu.Location = new System.Drawing.Point(-8, 95);
            this.lghichu.Name = "lghichu";
            this.lghichu.Size = new System.Drawing.Size(71, 23);
            this.lghichu.TabIndex = 47;
            this.lghichu.Text = "Ghi chú :";
            this.lghichu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ghichu
            // 
            this.ghichu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ghichu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ghichu.Enabled = false;
            this.ghichu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ghichu.Location = new System.Drawing.Point(64, 119);
            this.ghichu.Name = "ghichu";
            this.ghichu.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ghichu.Size = new System.Drawing.Size(725, 21);
            this.ghichu.TabIndex = 9;
            this.ghichu.TextChanged += new System.EventHandler(this.ghichu_TextChanged);
            this.ghichu.Validated += new System.EventHandler(this.ghichu_Validated);
            this.ghichu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ghichu_KeyDown_1);
            // 
            // songay
            // 
            this.songay.BackColor = System.Drawing.SystemColors.HighlightText;
            this.songay.Enabled = false;
            this.songay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.songay.Location = new System.Drawing.Point(64, 145);
            this.songay.Name = "songay";
            this.songay.Size = new System.Drawing.Size(39, 21);
            this.songay.TabIndex = 10;
            this.songay.ValueChanged += new System.EventHandler(this.songay_ValueChanged);
            this.songay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ghichu_KeyDown);
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(104, 147);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 16);
            this.label9.TabIndex = 46;
            this.label9.Text = "ngày";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(3, 147);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 16);
            this.label10.TabIndex = 44;
            this.label10.Text = "Cấp :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(-7, 2);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 22);
            this.label11.TabIndex = 60;
            this.label11.Text = "Ngày :";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // solan
            // 
            this.solan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.solan.Enabled = false;
            this.solan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.solan.Location = new System.Drawing.Point(29, 2);
            this.solan.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.solan.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.solan.Name = "solan";
            this.solan.Size = new System.Drawing.Size(33, 21);
            this.solan.TabIndex = 0;
            this.solan.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.solan.Validated += new System.EventHandler(this.solan_Validated);
            this.solan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ghichu_KeyDown);
            // 
            // makp
            // 
            this.makp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.makp.Enabled = false;
            this.makp.Location = new System.Drawing.Point(666, 205);
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(46, 20);
            this.makp.TabIndex = 51;
            // 
            // mabs
            // 
            this.mabs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mabs.Enabled = false;
            this.mabs.Location = new System.Drawing.Point(696, 205);
            this.mabs.Name = "mabs";
            this.mabs.Size = new System.Drawing.Size(33, 20);
            this.mabs.TabIndex = 52;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(61, 2);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(123, 20);
            this.label12.TabIndex = 61;
            this.label12.Text = "lần , lần :";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // moilan
            // 
            this.moilan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.moilan.Enabled = false;
            this.moilan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moilan.Location = new System.Drawing.Point(109, 1);
            this.moilan.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.moilan.Name = "moilan";
            this.moilan.Size = new System.Drawing.Size(43, 21);
            this.moilan.TabIndex = 1;
            this.moilan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.moilan.Validated += new System.EventHandler(this.solan_Validated);
            this.moilan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.moilan_KeyPress);
            // 
            // lbldvt
            // 
            this.lbldvt.Location = new System.Drawing.Point(156, 1);
            this.lbldvt.Name = "lbldvt";
            this.lbldvt.Size = new System.Drawing.Size(38, 21);
            this.lbldvt.TabIndex = 62;
            this.lbldvt.Text = "viên";
            this.lbldvt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // donthuoc
            // 
            this.donthuoc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.donthuoc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.donthuoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.donthuoc.Enabled = false;
            this.donthuoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.donthuoc.Location = new System.Drawing.Point(64, 74);
            this.donthuoc.Name = "donthuoc";
            this.donthuoc.Size = new System.Drawing.Size(682, 21);
            this.donthuoc.TabIndex = 9;
            this.donthuoc.SelectedIndexChanged += new System.EventHandler(this.donthuoc_SelectedIndexChanged);
            // 
            // chkChon
            // 
            this.chkChon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkChon.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkChon.AutoSize = true;
            this.chkChon.Enabled = false;
            this.chkChon.Location = new System.Drawing.Point(747, 72);
            this.chkChon.Name = "chkChon";
            this.chkChon.Size = new System.Drawing.Size(42, 23);
            this.chkChon.TabIndex = 94;
            this.chkChon.Text = "Chọn";
            this.chkChon.UseVisualStyleBackColor = true;
            this.chkChon.CheckedChanged += new System.EventHandler(this.chkChon_CheckedChanged);
            // 
            // sum
            // 
            this.sum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sum.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sum.Enabled = false;
            this.sum.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sum.Location = new System.Drawing.Point(516, 397);
            this.sum.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
            this.sum.Name = "sum";
            this.sum.Size = new System.Drawing.Size(114, 22);
            this.sum.TabIndex = 98;
            this.sum.Text = "0";
            this.sum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblsum
            // 
            this.lblsum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblsum.Location = new System.Drawing.Point(424, 397);
            this.lblsum.Name = "lblsum";
            this.lblsum.Size = new System.Drawing.Size(88, 23);
            this.lblsum.TabIndex = 99;
            this.lblsum.Text = "Tổng số tiền";
            this.lblsum.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // p1
            // 
            this.p1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.p1.Controls.Add(this.lbldvt);
            this.p1.Controls.Add(this.solan);
            this.p1.Controls.Add(this.label16);
            this.p1.Controls.Add(this.cachdung);
            this.p1.Controls.Add(this.soluong);
            this.p1.Controls.Add(this.moilan);
            this.p1.Controls.Add(this.label11);
            this.p1.Controls.Add(this.label12);
            this.p1.Controls.Add(this.label25);
            this.p1.Location = new System.Drawing.Point(170, 444);
            this.p1.Name = "p1";
            this.p1.Size = new System.Drawing.Size(618, 24);
            this.p1.TabIndex = 22;
            this.p1.VisibleChanged += new System.EventHandler(this.p1_VisibleChanged);
            // 
            // p2
            // 
            this.p2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.p2.Controls.Add(this.c3);
            this.p2.Controls.Add(this.soluong1);
            this.p2.Controls.Add(this.c1);
            this.p2.Controls.Add(this.label18);
            this.p2.Controls.Add(this.label14);
            this.p2.Controls.Add(this.ghichuct);
            this.p2.Controls.Add(this.label23);
            this.p2.Controls.Add(this.c4);
            this.p2.Controls.Add(this.lblduongdung);
            this.p2.Controls.Add(this.label17);
            this.p2.Controls.Add(this.label19);
            this.p2.Controls.Add(this.c2);
            this.p2.Controls.Add(this.label15);
            this.p2.Location = new System.Drawing.Point(59, 445);
            this.p2.Name = "p2";
            this.p2.Size = new System.Drawing.Size(733, 23);
            this.p2.TabIndex = 22;
            this.p2.VisibleChanged += new System.EventHandler(this.p2_VisibleChanged);
            // 
            // c3
            // 
            this.c3.BackColor = System.Drawing.SystemColors.HighlightText;
            this.c3.Enabled = false;
            this.c3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c3.Location = new System.Drawing.Point(334, 2);
            this.c3.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c3.Name = "c3";
            this.c3.Size = new System.Drawing.Size(30, 21);
            this.c3.TabIndex = 3;
            this.c3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.c3.Validated += new System.EventHandler(this.c3_Validated);
            this.c3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.c3_KeyPress);
            // 
            // soluong1
            // 
            this.soluong1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.soluong1.Enabled = false;
            this.soluong1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.soluong1.Location = new System.Drawing.Point(409, 2);
            this.soluong1.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
            this.soluong1.Name = "soluong1";
            this.soluong1.Size = new System.Drawing.Size(42, 21);
            this.soluong1.TabIndex = 4;
            this.soluong1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.soluong1.Validated += new System.EventHandler(this.soluong1_Validated);
            // 
            // c1
            // 
            this.c1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.c1.Enabled = false;
            this.c1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c1.Location = new System.Drawing.Point(112, 3);
            this.c1.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c1.Name = "c1";
            this.c1.Size = new System.Drawing.Size(39, 21);
            this.c1.TabIndex = 0;
            this.c1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.c1.Validated += new System.EventHandler(this.c1_Validated);
            this.c1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.c1_KeyPress);
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(312, 2);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(53, 21);
            this.label18.TabIndex = 309;
            this.label18.Text = "tối :";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(77, 2);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(49, 21);
            this.label14.TabIndex = 0;
            this.label14.Text = "sáng :";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ghichuct
            // 
            this.ghichuct.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ghichuct.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ghichuct.Enabled = false;
            this.ghichuct.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ghichuct.Location = new System.Drawing.Point(510, 2);
            this.ghichuct.Name = "ghichuct";
            this.ghichuct.Size = new System.Drawing.Size(220, 21);
            this.ghichuct.TabIndex = 23;
            this.ghichuct.TextChanged += new System.EventHandler(this.ghichuct_TextChanged);
            this.ghichuct.Validated += new System.EventHandler(this.ghichuct_Validated);
            this.ghichuct.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ghichuct_KeyDown);
            // 
            // label23
            // 
            this.label23.Location = new System.Drawing.Point(442, 2);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(68, 21);
            this.label23.TabIndex = 293;
            this.label23.Text = "Ghi chú :";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // c4
            // 
            this.c4.BackColor = System.Drawing.SystemColors.HighlightText;
            this.c4.Enabled = false;
            this.c4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c4.Location = new System.Drawing.Point(280, 2);
            this.c4.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c4.Name = "c4";
            this.c4.Size = new System.Drawing.Size(31, 21);
            this.c4.TabIndex = 2;
            this.c4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.c4.Validated += new System.EventHandler(this.c4_Validated);
            this.c4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.c4_KeyPress);
            // 
            // lblduongdung
            // 
            this.lblduongdung.Location = new System.Drawing.Point(3, 2);
            this.lblduongdung.Name = "lblduongdung";
            this.lblduongdung.Size = new System.Drawing.Size(86, 22);
            this.lblduongdung.TabIndex = 63;
            this.lblduongdung.Text = "lblduongdung";
            this.lblduongdung.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblduongdung.Visible = false;
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(243, 2);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(53, 21);
            this.label17.TabIndex = 308;
            this.label17.Text = "chiều :";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(374, 4);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(36, 16);
            this.label19.TabIndex = 76;
            this.label19.Text = "SL :";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // c2
            // 
            this.c2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.c2.Enabled = false;
            this.c2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c2.Location = new System.Drawing.Point(211, 2);
            this.c2.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.c2.Name = "c2";
            this.c2.Size = new System.Drawing.Size(30, 21);
            this.c2.TabIndex = 1;
            this.c2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.c2.Validated += new System.EventHandler(this.c2_Validated);
            this.c2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.c2_KeyPress);
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(181, 2);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 21);
            this.label15.TabIndex = 66;
            this.label15.Text = "trưa :";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chk1
            // 
            this.chk1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chk1.AutoSize = true;
            this.chk1.Location = new System.Drawing.Point(660, 475);
            this.chk1.Name = "chk1";
            this.chk1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk1.Size = new System.Drawing.Size(69, 17);
            this.chk1.TabIndex = 26;
            this.chk1.Text = "Trước ăn";
            this.chk1.UseVisualStyleBackColor = true;
            this.chk1.Visible = false;
            this.chk1.CheckedChanged += new System.EventHandler(this.chk1_CheckedChanged);
            this.chk1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ghichu_KeyDown);
            // 
            // chk2
            // 
            this.chk2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chk2.AutoSize = true;
            this.chk2.Location = new System.Drawing.Point(726, 475);
            this.chk2.Name = "chk2";
            this.chk2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk2.Size = new System.Drawing.Size(60, 17);
            this.chk2.TabIndex = 27;
            this.chk2.Text = "Sau ăn";
            this.chk2.UseVisualStyleBackColor = true;
            this.chk2.Visible = false;
            this.chk2.CheckedChanged += new System.EventHandler(this.chk2_CheckedChanged);
            this.chk2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ghichu_KeyDown);
            // 
            // listHoten
            // 
            this.listHoten.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.listHoten.BackColor = System.Drawing.SystemColors.Info;
            this.listHoten.ColumnCount = 0;
            this.listHoten.Location = new System.Drawing.Point(550, 555);
            this.listHoten.MatchBufferTimeOut = 1000;
            this.listHoten.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listHoten.Name = "listHoten";
            this.listHoten.Size = new System.Drawing.Size(75, 17);
            this.listHoten.TabIndex = 100;
            this.listHoten.TextIndex = -1;
            this.listHoten.TextMember = null;
            this.listHoten.ValueIndex = -1;
            this.listHoten.Visible = false;
            this.listHoten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listHoten_KeyDown);
            // 
            // listBS
            // 
            this.listBS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.listBS.BackColor = System.Drawing.SystemColors.Info;
            this.listBS.ColumnCount = 0;
            this.listBS.Location = new System.Drawing.Point(701, 555);
            this.listBS.MatchBufferTimeOut = 1000;
            this.listBS.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listBS.Name = "listBS";
            this.listBS.Size = new System.Drawing.Size(75, 17);
            this.listBS.TabIndex = 265;
            this.listBS.TextIndex = -1;
            this.listBS.TextMember = null;
            this.listBS.ValueIndex = -1;
            this.listBS.Visible = false;
            // 
            // madoituong
            // 
            this.madoituong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.madoituong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.madoituong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.madoituong.Enabled = false;
            this.madoituong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madoituong.Location = new System.Drawing.Point(59, 422);
            this.madoituong.Name = "madoituong";
            this.madoituong.Size = new System.Drawing.Size(86, 21);
            this.madoituong.TabIndex = 15;
            this.madoituong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.madoituong_KeyDown);
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label13.Location = new System.Drawing.Point(-17, 419);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(76, 23);
            this.label13.TabIndex = 267;
            this.label13.Text = "Đối tượng :";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dang
            // 
            this.dang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dang.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dang.Enabled = false;
            this.dang.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dang.Location = new System.Drawing.Point(751, 421);
            this.dang.Name = "dang";
            this.dang.Size = new System.Drawing.Size(41, 21);
            this.dang.TabIndex = 19;
            this.dang.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenhc_KeyDown);
            // 
            // chkChitiet
            // 
            this.chkChitiet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkChitiet.Checked = true;
            this.chkChitiet.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkChitiet.Location = new System.Drawing.Point(680, 322);
            this.chkChitiet.Name = "chkChitiet";
            this.chkChitiet.Size = new System.Drawing.Size(45, 17);
            this.chkChitiet.TabIndex = 274;
            this.chkChitiet.Text = "Số ngày cấp đơn phân bổ chi tiết";
            this.chkChitiet.UseVisualStyleBackColor = true;
            this.chkChitiet.CheckedChanged += new System.EventHandler(this.chkChitiet_CheckedChanged);
            // 
            // huyet
            // 
            this.huyet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.huyet.BackColor = System.Drawing.SystemColors.HighlightText;
            this.huyet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.huyet.Enabled = false;
            this.huyet.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.huyet.Location = new System.Drawing.Point(64, 96);
            this.huyet.Name = "huyet";
            this.huyet.Size = new System.Drawing.Size(682, 21);
            this.huyet.TabIndex = 8;
            this.huyet.SelectedIndexChanged += new System.EventHandler(this.huyet_SelectedIndexChanged);
            // 
            // chkHuyet
            // 
            this.chkHuyet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkHuyet.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkHuyet.AutoSize = true;
            this.chkHuyet.Enabled = false;
            this.chkHuyet.Location = new System.Drawing.Point(747, 95);
            this.chkHuyet.Name = "chkHuyet";
            this.chkHuyet.Size = new System.Drawing.Size(42, 23);
            this.chkHuyet.TabIndex = 275;
            this.chkHuyet.Text = "Chọn";
            this.chkHuyet.UseVisualStyleBackColor = true;
            this.chkHuyet.CheckedChanged += new System.EventHandler(this.chkHuyet_CheckedChanged);
            // 
            // tim
            // 
            this.tim.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tim.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tim.Enabled = false;
            this.tim.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tim.ForeColor = System.Drawing.Color.Red;
            this.tim.Location = new System.Drawing.Point(673, 2);
            this.tim.Name = "tim";
            this.tim.Size = new System.Drawing.Size(114, 21);
            this.tim.TabIndex = 276;
            this.tim.Text = "Tìm kiếm";
            this.tim.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tim.TextChanged += new System.EventHandler(this.tim_TextChanged);
            this.tim.Enter += new System.EventHandler(this.tim_Enter);
            // 
            // banin
            // 
            this.banin.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.banin.Location = new System.Drawing.Point(161, 2);
            this.banin.Name = "banin";
            this.banin.Size = new System.Drawing.Size(44, 21);
            this.banin.TabIndex = 279;
            // 
            // dataGrid1
            // 
            this.dataGrid1.AlternatingBackColor = System.Drawing.Color.Lavender;
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
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
            this.dataGrid1.Location = new System.Drawing.Point(11, 150);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(616, 240);
            this.dataGrid1.TabIndex = 281;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            // 
            // lbldungluc
            // 
            this.lbldungluc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbldungluc.Location = new System.Drawing.Point(478, 470);
            this.lbldungluc.Name = "lbldungluc";
            this.lbldungluc.Size = new System.Drawing.Size(186, 23);
            this.lbldungluc.TabIndex = 284;
            this.lbldungluc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtgiaban
            // 
            this.txtgiaban.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtgiaban.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtgiaban.Enabled = false;
            this.txtgiaban.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtgiaban.Location = new System.Drawing.Point(339, 469);
            this.txtgiaban.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
            this.txtgiaban.Name = "txtgiaban";
            this.txtgiaban.Size = new System.Drawing.Size(84, 22);
            this.txtgiaban.TabIndex = 285;
            this.txtgiaban.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtgiaban.Visible = false;
            this.txtgiaban.VisibleChanged += new System.EventHandler(this.txtgiaban_VisibleChanged);
            // 
            // txtdongia
            // 
            this.txtdongia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtdongia.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtdongia.Enabled = false;
            this.txtdongia.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdongia.Location = new System.Drawing.Point(469, 470);
            this.txtdongia.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
            this.txtdongia.Name = "txtdongia";
            this.txtdongia.Size = new System.Drawing.Size(161, 22);
            this.txtdongia.TabIndex = 286;
            this.txtdongia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtdongia.Visible = false;
            this.txtdongia.VisibleChanged += new System.EventHandler(this.txtdongia_VisibleChanged);
            // 
            // ngaynghi
            // 
            this.ngaynghi.BackColor = System.Drawing.Color.White;
            this.ngaynghi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngaynghi.Location = new System.Drawing.Point(214, 146);
            this.ngaynghi.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.ngaynghi.Name = "ngaynghi";
            this.ngaynghi.Size = new System.Drawing.Size(36, 21);
            this.ngaynghi.TabIndex = 11;
            this.ngaynghi.ValueChanged += new System.EventHandler(this.ngaynghi_ValueChanged);
            this.ngaynghi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ghichu_KeyDown);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(147, 147);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 16);
            this.label8.TabIndex = 289;
            this.label8.Text = "Nghỉ phép :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label21
            // 
            this.label21.Location = new System.Drawing.Point(254, 147);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(38, 16);
            this.label21.TabIndex = 291;
            this.label21.Text = "ngày";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label24
            // 
            this.label24.Location = new System.Drawing.Point(2, 76);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(61, 16);
            this.label24.TabIndex = 295;
            this.label24.Text = "Toa mẫu :";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butDongy
            // 
            this.butDongy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butDongy.Image = ((System.Drawing.Image)(resources.GetObject("butDongy.Image")));
            this.butDongy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butDongy.Location = new System.Drawing.Point(162, 547);
            this.butDongy.Name = "butDongy";
            this.butDongy.Size = new System.Drawing.Size(70, 25);
            this.butDongy.TabIndex = 277;
            this.butDongy.Text = "Đông y";
            this.butDongy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butDongy.Visible = false;
            this.butDongy.Click += new System.EventHandler(this.butDongy_Click);
            // 
            // butGoi
            // 
            this.butGoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butGoi.Enabled = false;
            this.butGoi.Image = ((System.Drawing.Image)(resources.GetObject("butGoi.Image")));
            this.butGoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butGoi.Location = new System.Drawing.Point(88, 522);
            this.butGoi.Name = "butGoi";
            this.butGoi.Size = new System.Drawing.Size(70, 25);
            this.butGoi.TabIndex = 273;
            this.butGoi.Text = "     &Gói";
            this.butGoi.Click += new System.EventHandler(this.butGoi_Click);
            // 
            // butTuongtac
            // 
            this.butTuongtac.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butTuongtac.Image = ((System.Drawing.Image)(resources.GetObject("butTuongtac.Image")));
            this.butTuongtac.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butTuongtac.Location = new System.Drawing.Point(706, 396);
            this.butTuongtac.Name = "butTuongtac";
            this.butTuongtac.Size = new System.Drawing.Size(85, 25);
            this.butTuongtac.TabIndex = 269;
            this.butTuongtac.Text = "Tương tác";
            this.butTuongtac.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butTuongtac.Click += new System.EventHandler(this.butTuongtac_Click);
            // 
            // butHen
            // 
            this.butHen.Image = ((System.Drawing.Image)(resources.GetObject("butHen.Image")));
            this.butHen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHen.Location = new System.Drawing.Point(206, 1);
            this.butHen.Name = "butHen";
            this.butHen.Size = new System.Drawing.Size(50, 23);
            this.butHen.TabIndex = 28;
            this.butHen.Text = "Hẹn";
            this.butHen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butHen.Visible = false;
            this.butHen.Click += new System.EventHandler(this.butHen_Click);
            // 
            // butIn
            // 
            this.butIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(650, 522);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 34;
            this.butIn.Text = "     &In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butCholai
            // 
            this.butCholai.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butCholai.Enabled = false;
            this.butCholai.Image = ((System.Drawing.Image)(resources.GetObject("butCholai.Image")));
            this.butCholai.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butCholai.Location = new System.Drawing.Point(630, 396);
            this.butCholai.Name = "butCholai";
            this.butCholai.Size = new System.Drawing.Size(77, 25);
            this.butCholai.TabIndex = 252;
            this.butCholai.Text = "&Cho lại";
            this.butCholai.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butCholai.Click += new System.EventHandler(this.butCholai_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butKetthuc.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(720, 522);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 35;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // butHuy
            // 
            this.butHuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butHuy.Image = ((System.Drawing.Image)(resources.GetObject("butHuy.Image")));
            this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHuy.Location = new System.Drawing.Point(580, 522);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(70, 25);
            this.butHuy.TabIndex = 33;
            this.butHuy.Text = "     &Hủy";
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butBoqua.Enabled = false;
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(510, 522);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(70, 25);
            this.butBoqua.TabIndex = 31;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butXoa
            // 
            this.butXoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butXoa.Enabled = false;
            this.butXoa.Image = ((System.Drawing.Image)(resources.GetObject("butXoa.Image")));
            this.butXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butXoa.Location = new System.Drawing.Point(440, 522);
            this.butXoa.Name = "butXoa";
            this.butXoa.Size = new System.Drawing.Size(70, 25);
            this.butXoa.TabIndex = 29;
            this.butXoa.Text = "    &Xóa";
            this.butXoa.Click += new System.EventHandler(this.butXoa_Click);
            // 
            // butThem
            // 
            this.butThem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butThem.Enabled = false;
            this.butThem.Image = ((System.Drawing.Image)(resources.GetObject("butThem.Image")));
            this.butThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butThem.Location = new System.Drawing.Point(370, 522);
            this.butThem.Name = "butThem";
            this.butThem.Size = new System.Drawing.Size(70, 25);
            this.butThem.TabIndex = 28;
            this.butThem.Tag = "";
            this.butThem.Text = "&Thêm";
            this.butThem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butThem.Click += new System.EventHandler(this.butThem_Click);
            // 
            // butLuu
            // 
            this.butLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butLuu.Enabled = false;
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(300, 522);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 30;
            this.butLuu.Text = "     &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butSua
            // 
            this.butSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butSua.Image = ((System.Drawing.Image)(resources.GetObject("butSua.Image")));
            this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.Location = new System.Drawing.Point(230, 522);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(70, 25);
            this.butSua.TabIndex = 33;
            this.butSua.Text = "    &Sửa";
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butMoi
            // 
            this.butMoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butMoi.Image = ((System.Drawing.Image)(resources.GetObject("butMoi.Image")));
            this.butMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMoi.Location = new System.Drawing.Point(158, 522);
            this.butMoi.Name = "butMoi";
            this.butMoi.Size = new System.Drawing.Size(70, 25);
            this.butMoi.TabIndex = 32;
            this.butMoi.Text = "Mới";
            this.butMoi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
            // 
            // lblGiaban
            // 
            this.lblGiaban.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblGiaban.Location = new System.Drawing.Point(255, 469);
            this.lblGiaban.Name = "lblGiaban";
            this.lblGiaban.Size = new System.Drawing.Size(76, 23);
            this.lblGiaban.TabIndex = 296;
            this.lblGiaban.Text = "Giá bán:";
            this.lblGiaban.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblGiaban.Visible = false;
            // 
            // lblGiamua
            // 
            this.lblGiamua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblGiamua.Location = new System.Drawing.Point(395, 471);
            this.lblGiamua.Name = "lblGiamua";
            this.lblGiamua.Size = new System.Drawing.Size(76, 23);
            this.lblGiamua.TabIndex = 297;
            this.lblGiamua.Text = "Giá mua:";
            this.lblGiamua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblGiamua.Visible = false;
            // 
            // txtNgaynghi_tungay
            // 
            this.txtNgaynghi_tungay.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtNgaynghi_tungay.Enabled = false;
            this.txtNgaynghi_tungay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNgaynghi_tungay.Location = new System.Drawing.Point(324, 146);
            this.txtNgaynghi_tungay.Mask = "##/##/####";
            this.txtNgaynghi_tungay.Name = "txtNgaynghi_tungay";
            this.txtNgaynghi_tungay.Size = new System.Drawing.Size(64, 21);
            this.txtNgaynghi_tungay.TabIndex = 12;
            this.txtNgaynghi_tungay.Text = "  /  /    ";
            this.txtNgaynghi_tungay.Validated += new System.EventHandler(this.txtNgaynghi_tungay_Validated);
            this.txtNgaynghi_tungay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ghichu_KeyDown);
            // 
            // txtNgaynghi_denngay
            // 
            this.txtNgaynghi_denngay.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtNgaynghi_denngay.Enabled = false;
            this.txtNgaynghi_denngay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNgaynghi_denngay.Location = new System.Drawing.Point(419, 146);
            this.txtNgaynghi_denngay.Mask = "##/##/####";
            this.txtNgaynghi_denngay.Name = "txtNgaynghi_denngay";
            this.txtNgaynghi_denngay.Size = new System.Drawing.Size(64, 21);
            this.txtNgaynghi_denngay.TabIndex = 13;
            this.txtNgaynghi_denngay.Text = "  /  /    ";
            this.txtNgaynghi_denngay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ghichu_KeyDown);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(294, 150);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(26, 13);
            this.label29.TabIndex = 301;
            this.label29.Text = "Từ: ";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(390, 150);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(32, 13);
            this.label30.TabIndex = 302;
            this.label30.Text = "đến: ";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(496, 149);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(30, 13);
            this.label31.TabIndex = 303;
            this.label31.Text = "Hẹn:";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtHen
            // 
            this.txtHen.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtHen.Enabled = false;
            this.txtHen.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHen.Location = new System.Drawing.Point(530, 146);
            this.txtHen.Name = "txtHen";
            this.txtHen.Size = new System.Drawing.Size(39, 21);
            this.txtHen.TabIndex = 14;
            this.txtHen.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ghichu_KeyDown);
            // 
            // label32
            // 
            this.label32.Location = new System.Drawing.Point(570, 147);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(49, 16);
            this.label32.TabIndex = 305;
            this.label32.Text = "ngày";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolTuychon,
            this.toolStripSeparator1,
            this.toolStripLabel1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(794, 25);
            this.toolStrip1.TabIndex = 306;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolTuychon
            // 
            this.toolTuychon.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chkThuoc,
            this.chkXem,
            this.chkXML,
            this.chkVP,
            this.chkTodieutri,
            this.chkLuuin,
            this.chkDoituong,
            this.chkDongy,
            this.chkDongia,
            this.chkQuanlyngaynghiphep,
            this.chkCanhbaotoathuoclonhon10ngay});
            this.toolTuychon.Image = ((System.Drawing.Image)(resources.GetObject("toolTuychon.Image")));
            this.toolTuychon.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolTuychon.Name = "toolTuychon";
            this.toolTuychon.Size = new System.Drawing.Size(80, 22);
            this.toolTuychon.Text = "Tùy chọn";
            this.toolTuychon.Click += new System.EventHandler(this.toolTuychon_Click);
            // 
            // chkThuoc
            // 
            this.chkThuoc.CheckOnClick = true;
            this.chkThuoc.Name = "chkThuoc";
            this.chkThuoc.Size = new System.Drawing.Size(260, 22);
            this.chkThuoc.Text = "Xem thuốc đã sử dụng";
            this.chkThuoc.CheckedChanged += new System.EventHandler(this.chkThuoc_CheckedChanged);
            // 
            // chkXem
            // 
            this.chkXem.CheckOnClick = true;
            this.chkXem.Name = "chkXem";
            this.chkXem.Size = new System.Drawing.Size(260, 22);
            this.chkXem.Text = "Xem trước khi in";
            // 
            // chkXML
            // 
            this.chkXML.CheckOnClick = true;
            this.chkXML.Name = "chkXML";
            this.chkXML.Size = new System.Drawing.Size(260, 22);
            this.chkXML.Text = "Xml";
            // 
            // chkVP
            // 
            this.chkVP.CheckOnClick = true;
            this.chkVP.Name = "chkVP";
            this.chkVP.Size = new System.Drawing.Size(260, 22);
            this.chkVP.Text = "In kèm theo chỉ định";
            // 
            // chkTodieutri
            // 
            this.chkTodieutri.CheckOnClick = true;
            this.chkTodieutri.Name = "chkTodieutri";
            this.chkTodieutri.Size = new System.Drawing.Size(260, 22);
            this.chkTodieutri.Text = "Tờ điều trị";
            // 
            // chkLuuin
            // 
            this.chkLuuin.CheckOnClick = true;
            this.chkLuuin.Name = "chkLuuin";
            this.chkLuuin.Size = new System.Drawing.Size(260, 22);
            this.chkLuuin.Text = "Lưu && in";
            // 
            // chkDoituong
            // 
            this.chkDoituong.CheckOnClick = true;
            this.chkDoituong.Name = "chkDoituong";
            this.chkDoituong.Size = new System.Drawing.Size(260, 22);
            this.chkDoituong.Text = "Chỉnh sửa đối tượng";
            this.chkDoituong.Click += new System.EventHandler(this.chkDoituong_Click);
            // 
            // chkDongy
            // 
            this.chkDongy.CheckOnClick = true;
            this.chkDongy.Name = "chkDongy";
            this.chkDongy.Size = new System.Drawing.Size(260, 22);
            this.chkDongy.Text = "In toa đông y";
            this.chkDongy.CheckedChanged += new System.EventHandler(this.chkDongy_CheckedChanged);
            // 
            // chkDongia
            // 
            this.chkDongia.CheckOnClick = true;
            this.chkDongia.Name = "chkDongia";
            this.chkDongia.Size = new System.Drawing.Size(260, 22);
            this.chkDongia.Text = "In kèm đơn giá";
            // 
            // chkQuanlyngaynghiphep
            // 
            this.chkQuanlyngaynghiphep.CheckOnClick = true;
            this.chkQuanlyngaynghiphep.Name = "chkQuanlyngaynghiphep";
            this.chkQuanlyngaynghiphep.Size = new System.Drawing.Size(260, 22);
            this.chkQuanlyngaynghiphep.Text = "Quản lý ngày nghỉ phép";
            this.chkQuanlyngaynghiphep.CheckedChanged += new System.EventHandler(this.chkQuanlyngaynghiphep_CheckedChanged);
            // 
            // chkCanhbaotoathuoclonhon10ngay
            // 
            this.chkCanhbaotoathuoclonhon10ngay.CheckOnClick = true;
            this.chkCanhbaotoathuoclonhon10ngay.Name = "chkCanhbaotoathuoclonhon10ngay";
            this.chkCanhbaotoathuoclonhon10ngay.Size = new System.Drawing.Size(260, 22);
            this.chkCanhbaotoathuoclonhon10ngay.Text = "Cảnh báo toa thuốc lớn hơn 10 ngày";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.AutoSize = false;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(105, 22);
            this.toolStripLabel1.Text = "Số bản in";
            this.toolStripLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(-7, 118);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 23);
            this.label7.TabIndex = 307;
            this.label7.Text = "Lời dặn :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // listLoidan
            // 
            this.listLoidan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.listLoidan.BackColor = System.Drawing.SystemColors.Info;
            this.listLoidan.ColumnCount = 0;
            this.listLoidan.Location = new System.Drawing.Point(394, 553);
            this.listLoidan.MatchBufferTimeOut = 1000;
            this.listLoidan.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listLoidan.Name = "listLoidan";
            this.listLoidan.Size = new System.Drawing.Size(75, 17);
            this.listLoidan.TabIndex = 308;
            this.listLoidan.TextIndex = -1;
            this.listLoidan.TextMember = null;
            this.listLoidan.ValueIndex = -1;
            this.listLoidan.Visible = false;
            // 
            // listICD
            // 
            this.listICD.BackColor = System.Drawing.SystemColors.Info;
            this.listICD.ColumnCount = 0;
            this.listICD.Location = new System.Drawing.Point(11, 537);
            this.listICD.MatchBufferTimeOut = 1000;
            this.listICD.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listICD.Name = "listICD";
            this.listICD.Size = new System.Drawing.Size(68, 17);
            this.listICD.TabIndex = 309;
            this.listICD.TextIndex = -1;
            this.listICD.TextMember = null;
            this.listICD.ValueIndex = -1;
            this.listICD.Visible = false;
            // 
            // tong_chidinh
            // 
            this.tong_chidinh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tong_chidinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tong_chidinh.Enabled = false;
            this.tong_chidinh.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tong_chidinh.Location = new System.Drawing.Point(329, 396);
            this.tong_chidinh.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
            this.tong_chidinh.Name = "tong_chidinh";
            this.tong_chidinh.Size = new System.Drawing.Size(116, 22);
            this.tong_chidinh.TabIndex = 310;
            this.tong_chidinh.Text = "0";
            this.tong_chidinh.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tong_chiphi
            // 
            this.tong_chiphi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tong_chiphi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tong_chiphi.Enabled = false;
            this.tong_chiphi.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tong_chiphi.Location = new System.Drawing.Point(116, 393);
            this.tong_chiphi.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
            this.tong_chiphi.Name = "tong_chiphi";
            this.tong_chiphi.Size = new System.Drawing.Size(116, 22);
            this.tong_chiphi.TabIndex = 311;
            this.tong_chiphi.Text = "0";
            this.tong_chiphi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label26
            // 
            this.label26.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label26.Location = new System.Drawing.Point(219, 393);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(104, 23);
            this.label26.TabIndex = 99;
            this.label26.Text = "Tổng CLS+ khám";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label27
            // 
            this.label27.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label27.Location = new System.Drawing.Point(22, 393);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(88, 23);
            this.label27.TabIndex = 99;
            this.label27.Text = "Tổng chi phí :";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmBaohiem
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(794, 575);
            this.Controls.Add(this.tong_chiphi);
            this.Controls.Add(this.tong_chidinh);
            this.Controls.Add(this.listICD);
            this.Controls.Add(this.listLoidan);
            this.Controls.Add(this.txtdongia);
            this.Controls.Add(this.txtgiaban);
            this.Controls.Add(this.lblGiamua);
            this.Controls.Add(this.lbldungluc);
            this.Controls.Add(this.makho);
            this.Controls.Add(this.chk1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtHen);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.txtNgaynghi_denngay);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.txtNgaynghi_tungay);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.chk2);
            this.Controls.Add(this.lblGiaban);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.ngaynghi);
            this.Controls.Add(this.banin);
            this.Controls.Add(this.butDongy);
            this.Controls.Add(this.tim);
            this.Controls.Add(this.chkHuyet);
            this.Controls.Add(this.huyet);
            this.Controls.Add(this.butGoi);
            this.Controls.Add(this.butTuongtac);
            this.Controls.Add(this.dang);
            this.Controls.Add(this.madoituong);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.listBS);
            this.Controls.Add(this.listHoten);
            this.Controls.Add(this.tenpk);
            this.Controls.Add(this.sum);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.lblsum);
            this.Controls.Add(this.sothe);
            this.Controls.Add(this.chkChon);
            this.Controls.Add(this.listCachdung);
            this.Controls.Add(this.donthuoc);
            this.Controls.Add(this.manguon);
            this.Controls.Add(this.songay);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.ghichu);
            this.Controls.Add(this.lghichu);
            this.Controls.Add(this.butHen);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.namsinh);
            this.Controls.Add(this.maicd);
            this.Controls.Add(this.hoten);
            this.Controls.Add(this.chandoan);
            this.Controls.Add(this.tenbs);
            this.Controls.Add(this.lblbacsy);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.diung);
            this.Controls.Add(this.tenhc);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.listDmbd);
            this.Controls.Add(this.cmbMabn);
            this.Controls.Add(this.butCholai);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butHuy);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butXoa);
            this.Controls.Add(this.butThem);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butSua);
            this.Controls.Add(this.butMoi);
            this.Controls.Add(this.ldvt);
            this.Controls.Add(this.tenbd);
            this.Controls.Add(this.lTenhc);
            this.Controls.Add(this.mabd);
            this.Controls.Add(this.lTen);
            this.Controls.Add(this.lMabd);
            this.Controls.Add(this.mabn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mabs);
            this.Controls.Add(this.makp);
            this.Controls.Add(this.stt);
            this.Controls.Add(this.mahc);
            this.Controls.Add(this.chkChitiet);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.p2);
            this.Controls.Add(this.p1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.dataGrid1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmBaohiem";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đơn thuốc";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmBaohiem_Load);
            this.Layout += new System.Windows.Forms.LayoutEventHandler(this.frmBaohiem_Layout);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmBaohiem_FormClosing);
            this.Validated += new System.EventHandler(this.frmBaohiem_Validated);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmBaohiem_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.songay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.solan)).EndInit();
            this.p1.ResumeLayout(false);
            this.p1.PerformLayout();
            this.p2.ResumeLayout(false);
            this.p2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.banin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ngaynghi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHen)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmBaohiem_Load(object sender, System.EventArgs e)
        {
            if (bbadt)
            {
                this.Location = new System.Drawing.Point(188 - 38, 120);//151
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                this.Size = new Size(829 + 40, 610);
            }
        
            dtdmbd = d.get_data("select * from " + d.user + ".d_dmbd where nhom=" + i_nhom).Tables[0];//gam 05/09/2011 di chuyen dong nay len tren, truoc khi goi hàm load tree view
            i_maxlength_mabn =LibMedi.AccessData.i_maxlength_mabn;
            mabn.MaxLength = i_maxlength_mabn;
            f_soluong = d.format_soluong(i_nhom);
            user = d.user; bLuu_Donthuoc_bacsy = m.bLuu_Donthuoc_bacsy;
            iUserid_donve = m.iUserid_donve; i_tunguyen = m.iTunguyen;
            bDuyet_donve = m.bDuyet_donve; bLocdichvu = m.bLocThuocCaptoa_doituong;
            iKhoangcachngaycaptoa_voingaykham = m.iKhoangcachngaycaptoa_voingaykham;
            bDuyet_donvepl = m.bDuyet_donvepl;
            bBamhuyet = m.bBamhuyet; bDutru_n_thuoc = m.bDutru_n_thuoc;
            bMabd_doituong = d.bMabd_doituong(i_nhom);
            iBhyt_songay = m.iBhyt_songay;
            bCaptoa_theodanhmuc_duocketoa = m.bCaptoa_theodanhmuc_duocketoa;
            bDondichvu_capnhieulantrongngay = m.bDondichvu_capnhieulantrongngay;
            i_w = dataGrid1.Size.Width; i_h = dataGrid1.Size.Height;
            bDichvu_vpkb = m.bDichvu_vpkb;//gam 25/10/2011
            bDuyet_khambenh = m.bDuyet_khambenh;//gam 25/10/2011
            if (i_loaiba == 1)//gam 08/03/2012 đối với bệnh nhân nội trú được phép cấp nhiều toa trong ngày
            {
                s_mabncaptoa = "";//gam 08/03/2012
            }
            f_load_option();
            if (bBamhuyet)
            {
                lghichu.Text = "Huyệt :";
                sql = "select * from " + user + ".dmhuyet where mabs='" + mabs.Text + "' and maicd='" + maicd.Text + "' order by stt";
                dthuyet = m.get_data(sql).Tables[0];
                if (dthuyet.Rows.Count == 0)
                {
                    sql = "select * from " + user + ".dmhuyet where maicd='" + maicd.Text + "' order by stt";
                    dthuyet = m.get_data(sql).Tables[0];
                    if (dthuyet.Rows.Count == 0)
                    {
                        sql = "select * from " + user + ".dmhuyet where mabs='" + mabs.Text + "' order by stt";
                        dthuyet = m.get_data(sql).Tables[0];
                        if (dthuyet.Rows.Count == 0)
                        {
                            sql = "select * from " + user + ".dmhuyet order by stt";
                            dthuyet = m.get_data(sql).Tables[0];
                        }
                    }
                }
                huyet.DataSource = dthuyet;
                huyet.ValueMember = "ID";
                huyet.DisplayMember = "TEN";
            }
            
            bGiaban = d.get_data("select * from " + user + ".d_doituong where loai=1 and madoituong=" + i_madoituong).Tables[0].Rows.Count > 0;
            foreach (DataRow r in m.get_data("select * from " + user + ".dlogin where id=" + i_userid).Tables[0].Rows)
                s_user = r["hoten"].ToString();
            chkThuoc.Checked = m.Thongso("xemthuoc") == "1";
            bThuphi_khongloadthuoc_BHYT = m.bThuphi_khongloadthuoc_BHYT;
            if (bChonkhoa)
            {
            	sql ="select a.mabn,b.hoten,a.id,c.mavaovien,a.maql,c.madoituong,d.sothe as sothe,b.nam,to_char(c.ngay,'dd/mm/yyyy') as ngay,";
                sql += "to_char(d.denngay,'dd/mm/yyyy') as denngay,e.chandoan,e.maicd,e.mabs,f.hoten as tenbs,trim(b.sonha)||' '||b.thon||', '||px.tenpxa||', '||qu.tenquan||', '||tt.tentt as diachi,";
                sql += "b.namsinh,e.giuong,";
                sql += " to_char(d.tungay,'dd/mm/yyyy') as tungay,to_char(d.ngay1,'dd/mm/yyyy') as ngay1,";
                sql += " to_char(d.ngay2,'dd/mm/yyyy') as ngay2,to_char(d.ngay3,'dd/mm/yyyy') as ngay3,case when d.traituyen is null then 0 else d.traituyen end as traituyen,d.mabv";
                sql += ", to_char(b.ngaysinh,'dd/mm/yyyy') as ngaysinh ";
                sql += ", case when b.phai=0 then 'Nam' else 'Nữ' end phai";
                sql += " from " + user + ".hiendien a inner join " + user + ".btdbn b on a.mabn=b.mabn ";
                sql += " inner join " + user + ".benhandt c on a.maql=c.maql ";
                sql += " left join " + user + ".bhyt d on a.maql=d.maql ";
                sql += " inner join " + user + ".nhapkhoa e on a.id=e.id ";
                sql += " left join " + user + ".dmbs f on e.mabs=f.ma";
                sql += " inner join " + user + ".btdtt tt on b.matt=tt.matt ";
                sql += " inner join " + user + ".btdquan qu on b.maqu=qu.maqu ";
                sql += " inner join " + user + ".btdpxa px on b.maphuongxa=px.maphuongxa ";
                sql += " where a.nhapkhoa=1 and a.xuatkhoa=0 ";
                if (!m.ma_phongmo(s_makp)) sql += " and a.makp='" + s_makp + "'"; 
			    sql += " and substr(a.ngay,1,10)<=to_date('"+s_ngay.Substring(0,10)+"','"+m.f_ngay+"')";
                sql += " and (d.sudung is null or d.sudung=1)";
			    sql += " order by a.id desc";
			    dthoten=m.get_data(sql).Tables[0];
			    listHoten.DisplayMember="MABN";
			    listHoten.ValueMember="HOTEN";
			    listHoten.DataSource=dthoten;
            }
            if (bChonkhoa || i_loaiba == 4 || i_loaiba==1)
            {
                dtbs = m.get_data("select * from " + user + ".dmbs where nhom not in (" + LibMedi.AccessData.nhanvien + ", " + LibMedi.AccessData.nghiviec + ") order by ma").Tables[0];
                listBS.DisplayMember = "MA";
                listBS.ValueMember = "HOTEN";
                listBS.DataSource = dtbs;
            }
            bDonthuoc_stc = m.bDonthuoc_stc;
            chkXem.Checked = m.bPreview;
            chkDongy.Checked = m.bDongy;
            bAdmin = m.bAdmin(i_userid);
            bAdminInlaidonthuoc = m.bAdminInlaidonthuoc;
            p2.Visible = bDonthuoc_stc;
            label25.Visible = cachdung.Visible = !bDonthuoc_stc;
            label23.Visible = ghichuct.Visible = bDonthuoc_stc;
            p1.Visible = !bDonthuoc_stc;
            bNgayhienhanh_thuoc_chidinh = m.bNgayhienhanh_thuoc_chidinh;
            if (bNgayhienhanh_thuoc_chidinh && !bChonkhoa && bXemlai==false) s_ngay = m.ngayhienhanh_server;
            bGiaban_theodot = d.bGiaban_theodot(i_nhom);
            //
            f_capnhat_db();
            //
            xxx = user + m.mmyy(s_ngay); zzz = user + s_mmyy;
           
            bNgtru_dt_makp = m.bNgtru_dt_makp;
            dt_ngtru = m.dt_ngtru;
            makp_kho_dt = m.makp_kho_dt;
            kho_ngtru = m.kho_ngtru;
            bool bDonngoaitru_auto_toaduocphat = m.bDonngoaitru_auto_chiapdungBNBHYT ;
            if (((i_loaiba == 2 && m.bDonngoaitru_auto) || i_loaiba == 3 || i_loaiba == 4) && i_madoituong != 5)//Thuy 23.02.2012
            {
                if ((bDonngoaitru_auto_toaduocphat && i_madoituong == 1) || !bDonngoaitru_auto_toaduocphat)
                {
                    bDuyet = (m.bDuyet_khambenh && i_loaiba != 4) || (bDuyet_donvepl && i_loaiba == 4);
                    bInchitiet = (bDuyet) ? m.bKham_inchiphi : false;
                    iUserid_duyet = m.iUserid_duyet;
                    bKhoaso = d.bKhoaso(i_nhom, s_mmyy);
                }
            }
            else if (i_loaiba == 1 && bDuyet_donve)
            {
                bDuyet = bDuyet_donve;
                iUserid_duyet = iUserid_donve;
            }
            
            if (bDuyet)
            {
                d.upd_capsotoa(s_mmyy, -99, s_ngay.Substring(0,10), 0, -1);
                d.upd_capsotoa(s_mmyy, -99, s_ngay.Substring(0,10), 1, -1);
                d.upd_capsotoa(s_mmyy, 2, s_ngay.Substring(0, 10), 0);
                d.upd_capsotoa(s_mmyy, 2, s_ngay.Substring(0, 10), 1);
            }
            bTinnhan_sound = d.bTinnhan_sound(i_nhom);
            bTinnhan = d.bTinnhan(i_nhom);
            bTongtien_donduyet = m.bTongtien_donduyet;
            lblsum.Visible = bTongtien_donduyet;
            sum.Visible = bTongtien_donduyet;
            chkDongia.Visible = bDuyet;
            bMuangoai_tonkho = (i_loai==7)?m.bMuangoai_tonkho:true;
            bCachdung = m.bCachdung;
            if (bDuyet) d.upd_capsotoa(s_mmyy, 2, s_ngay.Substring(0,10), (i_madoituong == 1) ? 0 : 1);
            s_ngayht = m.ngayhienhanh_server;//s_ngay
            bSolan = m.bSolan_donthuoc;
            i_bhyt_inrieng = d.iBhyt_inrieng(i_nhom);
            bKiemtrathuoc = m.bThuoc_ngay;
            s_msg = LibMedi.AccessData.Msg;
            i_sudungthuoc = m.iSudungthuoc;
            s_manguon = d.get_manguon(i_loai).Trim();
            if (bDieutringtr)
            {
                string s = d.get_manguon_doituong(i_madoituong);
                s_manguon = (s != "") ? s : s_manguon;
            }
            s_makho = d.get_dmkho(i_loai).Trim();
            if (m.bCaptoa_loctheokho_khaibaokhoa_trongduoc) s_makho_kp = d.get_dmkho_khoa(s_makp);
            //else s_makho_kp = "";//gam 22/09/2011
            else
            {
                try
                {
                    s_makho_kp = d.get_data("select kho from " + d.user + ".btdkp_bv where makp='" + s_makp +"'").Tables[0].Rows[0][0].ToString();//gam 22/09/2011
                }
                catch { s_makho_kp = ""; }
            }
            //end gam
            bChidinh = m.bInchidinh_donthuoc;
            chkVP.Checked = bChidinh;
            if (i_loai == 7) bNgoaitonkho = m.bNgoaitonkho;
            if (!bDieutringtr)
            {
                if (i_nhom == m.nhom_duoc && bNgtru_dt_makp && (i_madoituong == dt_ngtru || dt_ngtru==0) && makp_kho_dt.IndexOf(s_makp) != -1)
                    s_makho = kho_ngtru.ToString()+",";
                else
                {
                    string kho = "";
                    dtletet = m.get_data("select * from " + user + ".letet").Tables[0];
                    r = m.getrowbyid(dtletet, "ngay='" + s_ngayht.Substring(0, 5) + "'");
                    bLetet = r != null;
                    int hh1, hh2, hh3, mm1, mm2, mm3;
                    hh1 = int.Parse(s_ngayht.Substring(11, 2));
                    mm1 = int.Parse(s_ngayht.Substring(14, 2));
                    hh3 = int.Parse(m.sGiobaocao.Substring(0, 2));
                    mm3 = int.Parse(m.sGiobaocao.Substring(3, 2));
                    DateTime dt = m.StringToDate(s_ngay.Substring(0, 10));
                    string ddd = dt.DayOfWeek.ToString().Substring(0, 3);
                    if (i_madoituong == m.iTreem6tuoi && i_nhom == m.nhom_duoc && s_makho != "" && m.gio_treem != "00:00")
                    {
                        hh2 = int.Parse(m.gio_treem.Substring(0, 2));
                        mm2 = int.Parse(m.gio_treem.Substring(3, 2));
                        kho = m.kho_treem;
                        if (kho != "") kho += ",";
                        if (bLetet || ddd == "Sat" || ddd == "Sun" || hh1 > hh2 || (hh1 == hh2 && mm1 > mm2) || hh1 < hh3 || (hh1 == hh3 && mm1 < mm3)) s_makho = kho;
                        else if (kho != "") s_makho = s_makho.Remove(s_makho.IndexOf(kho), kho.Length);
                    }
                    else if (i_madoituong == 1 && i_nhom == m.nhom_duoc && s_makho != "" && m.gio_bhyt != "00:00")
                    {
                        hh2 = int.Parse(m.gio_bhyt.Substring(0, 2));
                        mm2 = int.Parse(m.gio_bhyt.Substring(3, 2));
                        kho = m.kho_bhyt;
                        if (kho != "") kho += ",";
                        if (bLetet || ddd == "Sat" || ddd == "Sun" || hh1 > hh2 || (hh1 == hh2 && mm1 > mm2) || hh1 < hh3 || (hh1 == hh3 && mm1 < mm3)) s_makho = kho;
                        else if (kho != "") s_makho = s_makho.Remove(s_makho.IndexOf(kho), kho.Length);
                    }
                    else if (i_madoituong == 2 && m.bDanhmuc_nhathuoc && i_nhom == m.nhom_nhathuoc && s_makho != "" && m.gio_nhathuoc != "00:00") //nha thuoc
                    {
                        hh2 = int.Parse(m.gio_nhathuoc.Substring(0, 2));
                        mm2 = int.Parse(m.gio_nhathuoc.Substring(3, 2));
                        kho = m.kho_nhathuoc;
                        if (kho != "") kho += ",";
                        if (bLetet || ddd == "Sat" || ddd == "Sun" || hh1 > hh2 || (hh1 == hh2 && mm1 > mm2) || hh1 < hh3 || (hh1 == hh3 && mm1 < mm3)) s_makho = kho;
                        else if (kho != "") s_makho = s_makho.Remove(s_makho.IndexOf(kho), kho.Length);
                    }
                }
            }
			diung.Tag="";
			bDiungthuoc=m.bDiungthuoc;
			diung.Visible=bDiungthuoc;
			

			listDmbd.DisplayMember="TEN";
			listDmbd.ValueMember="STT";

			listCachdung.DisplayMember="STT";
			listCachdung.ValueMember="TEN";

            listLoidan.DisplayMember = "ID";
            listLoidan.ValueMember = "TEN";

            if (!bChonkhoa) load_don();

            sql = "select * from "+user+".doituong";
            if (s_madoituong != "") sql += " where madoituong in (" + s_madoituong.Substring(0, s_madoituong.Length - 1) + ")";
            else if(i_loai == 7) sql += " where madoituong in (select madoituong from medibv.doituong)";
            sql += " order by madoituong";
            madoituong.DisplayMember = "DOITUONG";
            madoituong.ValueMember = "MADOITUONG";
            madoituong.DataSource = m.get_data(sql).Tables[0];
            //madoituong.SelectedIndex = 0;
            dtnguon = d.get_data("select * from " + user + ".d_dmnguon").Tables[0];
            if (bNgoaitonkho)
            {
                DataRow r = dtnguon.NewRow();
                r["id"] = -1;
                r["ten"] = "Tự mua";
                r["nhom"] = i_nhom;
                r["stt"] = -1;
                r["loai"] = 0;
                r["loaibc"] = 0;
                dtnguon.Rows.Add(r);
                d.upd_dmhang(-1, "...", 0, i_nhom, -1);
                d.upd_dmnuoc(-1, "...", 0, i_nhom, -1);
                d.upd_dmnhom(-1, "...", 0, i_nhom, 0, 0, -1);
                d.upd_dmloai(-1, "...", 0, i_nhom, -1);
            }
			manguon.DisplayMember="TEN";
			manguon.ValueMember="ID";
			manguon.DataSource=dtnguon;
			makho.DisplayMember="TEN";
			makho.ValueMember="ID";
			sql="select * from "+user+".d_dmkho where hide=0 ";
			if (s_makho!="") sql+=" and id in ("+s_makho.Substring(0,s_makho.Length-1)+")";
            if (i_khudt != 0) sql += " and (khu=0 or khu=" + i_khudt + ")";
			sql+=" order by stt";
            dtkho = d.get_data(sql).Tables[0];
            if (bNgoaitonkho)
            {
                DataRow r1 = dtkho.NewRow();
                r1["id"] = -1;
                r1["ten"] = "Tự mua";
                dtkho.Rows.Add(r1);
            }            
			makho.DataSource=dtkho;
            cmbMabn.DisplayMember="MABN";
			cmbMabn.ValueMember="ID";
			sql="select a.id,a.mabn,b.hoten,a.maql,to_char(a.ngay,'dd/mm/yyyy') as ngay,a.done,";
            sql += " b.namsinh,coalesce(d.sothe,' ') as sothe,a.chandoan,a.maicd,e.tenkp,coalesce(f.hoten,' ') as tenbs,";
            sql+="a.songay,a.ghichu,a.makp,a.mabs, to_char(b.ngaysinh,'dd/mm/yyyy') as ngaysinh, a.lanin,a.ngaynghi,"+
                "to_char(a.ngaynghi_tungay,'dd/mm/yyyy') ngaynghi_tungay,a.songayhen,a.sotoa ";
            sql += ",e.loai ";//gam 12/08/2011
			sql+=" from xxx.d_thuocbhytll a inner join "+user+".btdbn b on a.mabn=b.mabn ";
            sql += " left join " + s_bhyt + " d on a.maql=d.maql ";
            sql+=" inner join "+user+".btdkp_bv e on a.makp=e.makp";
            sql+=" left join "+user+".dmbs f on a.mabs=f.ma";
            if ((bChonkhoa) && s_mabncaptoa == "") sql += " where a.makp='" + s_makp + "' and to_char(a.ngay,'dd/mm/yyyy')='" + s_ngay.Substring(0, 10) + "' and a.loaiba=" + i_loaiba;//|| i_loaibn == 1
            else
            {
                sql += " where a.mabn='" + s_mabn + "' and a.maql=" + l_maql + " and a.madoituong=" + i_madoituong;
                //if (d.bLocbaohiem) sql += " and to_char(a.ngay,'dd/mm/yyyy')='" + s_ngay.Substring(0, 10) + "'";
            }
			sql+=" order by a.id";
			dtll=d.get_data_mmyy(sql,s_ngay_kham,s_ngay,true).Tables[0];
			cmbMabn.DataSource=dtll;
            bool bSkip = false;
            bTayy = true;
            if (cmbMabn.Items.Count > 0)
            {
                l_id = decimal.Parse(cmbMabn.SelectedValue.ToString());
                sql = "select distinct f.dongy";
                sql += " from " + xxx + ".d_thuocbhytct a inner join " + user + ".d_dmbd b on a.mabd=b.id ";
                sql += " left join " + user + ".d_dmkho f on a.makho=f.id ";
                sql += " inner join " + user + ".doituong c on a.madoituong=c.madoituong ";
                sql += " where a.id=" + l_id;
                DataTable tmp = d.get_data(sql).Tables[0];
                if (tmp.Rows.Count > 0)
                {
                    if (tmp.Rows[0]["dongy"].ToString() == "1")
                    {
                        label9.Text = lan.Change_language_MessageText("thang");
                        bTayy = false;
                        chkChitiet.Checked = true;
                    }
                    else
                    {
                        label9.Text = lan.Change_language_MessageText("ngày");
                        bTayy = true;
                        chkChitiet.Checked = false;
                    }
                    bSkip = true;
                    load_control();
                }
            }
            else l_id = 0;
            if (l_id!=0 && i_loai==5 && i_loaiba==3 && !bDuyet && !bChonkhoa) kiemtra_duyet();
			load_head();
            AddGridTableStyle();
            //end linh
			lan.Read_dtgrid_to_Xml(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			lan.Change_dtgrid_HeaderText_to_English(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			ref_text();
            //linh
            dsxoa = dtct.DataSet.Clone();
            if (bChonkhoa) load_dm();
            chkChitiet.Checked=m.Thongso("ctcapdon")=="1";
            makhosave = s_makho;
            butMoi.Enabled = bDongy(makhosave, 0);
            butDongy.Enabled = bDongy(makhosave, 1);
            string sbanin = m.Thongso("banin_" + ((i_loai == 7) ? "7" : "1"));
            banin.Value = decimal.Parse((sbanin!="")?sbanin:"0");
            chkLuuin.Checked = m.Thongso("bhluuin") == "1";
            //else if (chkThuoc.Checked) load_treeview();
            dataGrid1.ReadOnly = true;
            //
            ngay_reset_phieu38 = s_ngay;
            if (d.bSophieu_mau38_tangtheonam(m.nhom_duoc))
            {
                ngay_reset_phieu38 = "31/12/20" + s_mmyy.Substring(2, 2);                
            }
            else if (d.bSophieu_mau38_tangtheonam_tinhtuthang12(m.nhom_duoc))
            {
                ngay_reset_phieu38 = d.get_ngaytao_solieu_thangmoi("01"+s_mmyy.Substring(2,2), m.nhom_duoc); //d.iNgaytinh_Sophieu_mau38_tangtheonam(i_nhom).ToString().PadLeft(2, '0') + "/12/20" + (int.Parse(s_mmyy.Substring(2, 2)) - 1).ToString().PadLeft(2, '0');                
            }
            else
            {
                if (d.bSophieu_mau38_tangtheothang(m.nhom_duoc)) ngay_reset_phieu38 = "01/" + s_mmyy.Substring(0, 2) + "/20" + s_mmyy.Substring(2, 2);
                else if (d.bSophieu_mau38_tangtheothang_tinhtuthangtruoc(m.nhom_duoc))
                {                    
                    ngay_reset_phieu38 = d.get_ngaytao_solieu_thangmoi(s_mmyy, m.nhom_duoc); //d.iNgaytinh_Sophieu_mau38_tangthang(i_nhom).ToString().PadLeft(2, '0') + "/" + tmp_mm.ToString().PadLeft(2, '0') + "/20" + tmp_yy.ToString().PadLeft(2, '0');
                }               
            }
            //
            // hien : 22-06-2011
            s_Huongtamthan = m.Nhom_thuoc_huong_tam;
            //end hien
            //linh
            i_songaytoathuoccancanhbao = m.SoNgayToaThuocCanCanhBao;
            if (i_songaytoathuoccancanhbao == 0)
            {
                chkCanhbaotoathuoclonhon10ngay.Visible = false;
            }
            else
            {
                chkCanhbaotoathuoclonhon10ngay.Text = lan.Change_language_MessageText("Cảnh báo toa thuốc lớn hơn") + " " + i_songaytoathuoccancanhbao.ToString() + " " + lan.Change_language_MessageText("ngày");
                chkCanhbaotoathuoclonhon10ngay.Checked = (m.Thongso(chkCanhbaotoathuoclonhon10ngay.Name).ToString() == "1");
            }
            chkQuanlyngaynghiphep.Checked = (m.Thongso(chkQuanlyngaynghiphep.Name).ToString() == "1");
            //if (butMoi.Enabled )
            if (butMoi.Enabled && s_mabn.Trim() != "")//binh 130811
            {
                butMoi_Click(sender,e);
                //gam 12/08/2011 chi kiểm tra khi mới load form, kiểm tra các bệnh nhân phòng khám chỉ được nhập 1 toa và chỉ sửa trên toa thuốc
                if (!(butMoi.Enabled && butDongy.Enabled))
                {
                    if (m.getrowbyid(dtll, "mabn='" + mabn.Text + "' and done=0") != null)
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Đã nhập đơn thuốc chưa duyệt !"), LibMedi.AccessData.Msg);
                        butSua.Focus();
                        return;
                    }
                }
                //end gam 12/08/2011
            }
        }
        private void kiemtra_duyet()
        {
            if (d.get_done_thuocbhyt(s_ngay, l_id))
            {
                int songayduyet = d.iNgaykiemke;//.songayduyet(i_nhom);
                string s_tu = m.DateToString("dd/MM/yyyy", m.StringToDate(s_ngay).AddDays(-1 * songayduyet));
                string s_den = m.DateToString("dd/MM/yyyy", m.StringToDate(s_ngay).AddDays(songayduyet));
                if (d.get_data_mmyy("select * from xxx.bhytkb where id=" + l_id, s_tu, s_den, songayduyet).Tables[0].Rows.Count == 0)
                {
                    d.execute_data("update " + user + m.mmyy(s_ngay) + ".d_thuocbhytct set slthuc=0 where id=" + l_id);
                    d.execute_data("update " + user + m.mmyy(s_ngay) + ".d_thuocbhytll set done=0 where id=" + l_id);                    
                }
            }
        }

        private void load_don()
        {
            sql = "select a.*,' ' as hoten from " + user + ".d_theodonll a where a.mabs='" + mabs.Text + "' and a.maicd='" + maicd.Text + "' order by a.stt";
            dtdon = m.get_data(sql).Tables[0];
            if (dtdon.Rows.Count == 0)
            {
                sql = "select a.*,b.hoten from " + user + ".d_theodonll a," + user + ".dmbs b where a.mabs=b.ma and a.maicd='" + maicd.Text + "' order by a.stt";
                dtdon = m.get_data(sql).Tables[0];
            }
            string s = "";
            int ii=0;
            foreach (DataRow r in dtdon.Rows)
            {
				s=r["ghichu"].ToString().Trim();
                if (r["stt"].ToString() != "0")
                {
                    s = "";
                    sql = "select a.mabd,b.ma,trim(b.ten)||' '||b.hamluong as ten,b.hamluong,b.dang,b.mahc,b.tenhc,a.soluong,a.cachdung from " + user + ".d_theodonct a," + user + ".d_dmbd b";
                    sql += " where a.mabd=b.id and a.id=" + decimal.Parse(r["id"].ToString());
                    foreach (DataRow r3 in d.get_data(sql).Tables[0].Rows)
                        s += r3["ten"].ToString().Trim() + " " + r3["dang"].ToString().Trim() + ";";
                }
                r["ghichu"] = s;// r["stt"].ToString().Trim() + ". Đơn thuốc " + r["songay"].ToString().Trim() + " ngày , " + r["so"].ToString() + " loại " + ((r["hoten"].ToString().Trim() != "") ? "[" + r["hoten"].ToString().Trim() + "]" : "");
                ii += 1;
                if (ii >= 100) break;
            }
            donthuoc.DisplayMember = "GHICHU";
            donthuoc.ValueMember = "ID";
            donthuoc.DataSource = dtdon;
        }
        //12/03/14
        private void load_Chidinh()
        {
            sql = "select a.id,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay,a.makp,d.tenkp,a.madoituong,c.doituong,a.mavp,b.ten,b.dvt,a.soluong,a.dongia,a.paid,a.done,a.maql,a.idkhoa,a.vattu,a.tinhtrang,a.thuchien,b.ma,a.maicd,a.chandoan,a.mabs,a.loaiba,a.ghichu,b.hoichan,b.ctscannercq ";//,a.chandoansobo
            sql += ", a.tylegiam, a.stgiam, a.lydogiam,a.hide,e.hoten as user ";
            sql += " from xxx.v_chidinh a," + user + ".v_giavp b," + user + ".doituong c," + user + ".btdkp_bv d," + user + ".dlogin e ";
            sql += " where a.mavp=b.id and a.madoituong=c.madoituong and a.makp=d.makp and a.userid=e.id";
            sql += " and a.mabn='" + s_mabn + "'";
            if (l_mavaovien != 0 && i_loaiba == 3)
            {
                sql += " and a.mavaovien=" + l_mavaovien;
                sql += " and a.maql=" + l_maql;
                sql += " and to_char(a.ngay,'dd/mm/yyyy')='" + s_ngay.Substring(0, 10) + "'";
            }           
            sql += " order by a.ngay";            
            DataTable dsChidinh = d.get_data_mmyy(sql, s_ngay_kham, s_ngay, true).Tables[0];
            dsChidinh.Columns.Add("Chon", typeof(bool));
            DataGrid dg = new DataGrid();
            dg.DataSource = dsChidinh;
            CurrencyManager cm = (CurrencyManager)BindingContext[dg.DataSource, dg.DataMember];
            DataView dv = (DataView)cm.List;
            dv.AllowNew = false;
            decimal st = 0;
            foreach (DataRow row in dsChidinh.Rows)
            {
                row["chon"] = false;
                st += decimal.Parse(row["soluong"].ToString()) * decimal.Parse(row["dongia"].ToString());
            }
            tong_chidinh.Text = st.ToString("###,###,##0");
            tong_chiphi.Text = decimal.Parse(tong_chidinh.Text) + decimal.Parse(sum.Text) + "";
        }
            
		private void load_grid()
		{
            sql = "select a.stt,c.doituong,a.mabd,b.ma,trim(b.ten)||' '||b.hamluong as ten,nullif(b.tenhc,' ') as tenhc,b.dang,f.ten as tenkho,";
            sql+=" a.slyeucau as soluong,a.madoituong,a.makho,nullif(a.cachdung,' ') as cachdung,b.mahc,' ' as diung,a.manguon,";
            sql+=" 0 as tutruc,0 as idvpkhoa,a.solan,a.lan, ";
            if (bgiaBHYT_Quidinh)
            {
                sql += " b.gia_bh as  dongia ,a.slyeucau*b.gia_bh as sotien,";//b.giaban, // truong thuy 110414
            }
            else
            {
                sql += " b.dongia,a.slyeucau*b.dongia as sotien,";//b.giaban,
            }
            sql+=" a.ghichu,a2.hoten, ";//a.slyeucau*b.giaban as sotienban, 
            //if (bGiaban_theodot)//Thuy 29.03.2012
            //{
            //    sql += "t.giaban,a.slyeucau*t.giaban as sotienban ";
            //}
            //else
            //{
             // truong thuy edit lay theo gia BHYT  quy dinh 
           
            sql += "b.giaban, a.slyeucau*b.giaban as sotienban ";
            //}
			sql+=" from xxx.d_thuocbhytct a inner join "+user+".d_dmbd b on a.mabd=b.id inner join xxx.d_thuocbhytll a1 on a.id=a1.id ";
            sql+=" left join "+user+".d_dmkho f on a.makho=f.id inner join "+user+".dlogin a2 on a1.userid=a2.id ";
            sql+=" inner join "+user+".doituong c on a.madoituong=c.madoituong ";
            //if (bGiaban_theodot)
            //{
            //    sql += "inner join (select x.mabd,max(x.giaban) as giaban from xxx.d_theodoi x ";
            //    sql+="," + user + ".d_dmbd y where x.mabd=y.id and y.nhom="+i_nhom+" group by x.mabd) t on a.mabd=t.mabd ";
            //}
            sql+=" where a.id="+l_id+" order by a.stt";
			dtct=d.get_data_mmyy(sql, s_ngay_kham,s_ngay,true).Tables[0];
			if (bDiungthuoc) upd_diung();
			dataGrid1.DataSource=dtct;
            if (bTongtien_donduyet) tong();
            i_row = dataGrid1.CurrentRowIndex;
            load_Chidinh();
		}
        private void tong()
        {
            decimal st = 0;
            // gam 06-05-2011 
            foreach (DataRow r in dtct.Rows) st += ((i_loai == 7 || bGiaban) ? decimal.Parse((r["sotienban"].ToString() == "" ? "0" : r["sotienban"].ToString())) : decimal.Parse((r["sotien"].ToString() == "" ? "0" : r["sotien"].ToString())));
            sum.Text = st.ToString("###,###,###,###.00");
            tong_chiphi.Text = decimal.Parse(tong_chidinh.Text) + decimal.Parse(sum.Text) + "";//khuyen 12/03/14
        }
		private void upd_diung()
		{
			if (diung.Tag.ToString()!="")
			{
				int i=0;
                string[] s_diung = diung.Tag.ToString().ToLower().Split('+');
				foreach(DataRow r in dtct.Rows)
				{
					i=0;
                    while (i < s_diung.Length-1)
					{
						if (r["tenhc"].ToString().ToLower().IndexOf(s_diung[i].ToString())!=-1)
						{
							r["diung"]="1";
							break;
						}
						i++;
					}
				}
				dtct.AcceptChanges();
			}
		}

		private void AddGridTableStyle()
		{
			DataGridColoredTextBoxColumn TextCol;
			delegateGetColorRowCol de = new delegateGetColorRowCol(MyGetColorRowCol);
			DataGridTableStyle ts =new DataGridTableStyle();
			ts.MappingName = dtct.TableName;
			ts.AlternatingBackColor = Color.Beige;
			ts.BackColor = Color.GhostWhite;
			ts.ForeColor = Color.MidnightBlue;
			ts.GridLineColor = Color.RoyalBlue;
			ts.HeaderBackColor = Color.MidnightBlue;
			ts.HeaderForeColor = Color.Lavender;
			ts.SelectionBackColor = Color.Teal;
			ts.SelectionForeColor = Color.PaleGreen;
			//ts.ReadOnly=false;
			ts.RowHeaderWidth=5;
		    //0		
			TextCol=new DataGridColoredTextBoxColumn(de, 0);
			TextCol.MappingName = "stt";
			TextCol.HeaderText = "Stt";
			TextCol.Width = 30;
            TextCol.ReadOnly = true;
			ts.GridColumnStyles.Add(TextCol);
			
            //1
			TextCol=new DataGridColoredTextBoxColumn(de, 1);
			TextCol.MappingName = "doituong";
			TextCol.HeaderText = "Đối tượng";
			TextCol.Width = 80;
            TextCol.ReadOnly = true;
			ts.GridColumnStyles.Add(TextCol);
			
            //2
			TextCol=new DataGridColoredTextBoxColumn(de, 2);
			TextCol.MappingName = "ma";
			TextCol.HeaderText = "Mã số";
			TextCol.Width = 45;
            TextCol.ReadOnly = true;
			ts.GridColumnStyles.Add(TextCol);
			
            //3
			TextCol=new DataGridColoredTextBoxColumn(de, 3);
			TextCol.MappingName = "ten";
			TextCol.HeaderText = "Tên";
			TextCol.Width = (bTayy)?155:305;
            TextCol.ReadOnly = true;
			ts.GridColumnStyles.Add(TextCol);
			
            //4
			TextCol=new DataGridColoredTextBoxColumn(de, 4);
			TextCol.MappingName = "tenhc";
			TextCol.HeaderText = (bTayy)?"Hoạt chất":"";
			TextCol.Width = (bTayy)?150:0;
            TextCol.ReadOnly = true;
			ts.GridColumnStyles.Add(TextCol);
			
            //5
            TextCol = new DataGridColoredTextBoxColumn(de, 5);
            TextCol.MappingName = "dang";
            TextCol.HeaderText = "ĐVT";
            TextCol.Width = 34;
            TextCol.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol);
            
            //6
            TextCol = new DataGridColoredTextBoxColumn(de, 6);
            TextCol.MappingName = "solan";
            TextCol.HeaderText = (bTayy)?"":"Số";
            TextCol.Width = (bTayy)?0:30;
            TextCol.ReadOnly = true;
            TextCol.Alignment = HorizontalAlignment.Right;
            ts.GridColumnStyles.Add(TextCol);
            
            //7
            TextCol = new DataGridColoredTextBoxColumn(de, 7);
            TextCol.MappingName = "lan";
            TextCol.HeaderText = (bTayy)?"":"Số lượng";
            TextCol.Width = (bTayy)?0:50;
            if (bTayy) TextCol.ReadOnly = true;
            TextCol.Format = f_soluong;
            TextCol.Alignment = HorizontalAlignment.Right;
            ts.GridColumnStyles.Add(TextCol);
            
            //8
			TextCol=new DataGridColoredTextBoxColumn(de, 8);
			TextCol.MappingName = "soluong";
            TextCol.HeaderText = (bTayy) ? "Số lượng" : "";//Tổng cộng
			TextCol.Width = (bTayy)?70:0;
            TextCol.Format = f_soluong;
            if (!bTayy || bDuyet) TextCol.ReadOnly = true;//gam 04/01/2012 cho phép sửa số lượng trên lưới nếu không duyệt tự động
            //TextCol.ReadOnly = true;//gam 29/09/2011 không cho phép sửa số lượng trên lưới
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			

			TextCol=new DataGridColoredTextBoxColumn(de, 9);
			TextCol.MappingName = "madoituong";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			

			TextCol=new DataGridColoredTextBoxColumn(de, 10);
			TextCol.MappingName = "makho";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			

			TextCol=new DataGridColoredTextBoxColumn(de, 11);
			TextCol.MappingName = "cachdung";
            TextCol.HeaderText = (bDonthuoc_stc || !bTayy) ? "" : "Cách dùng";
            TextCol.Width = (bDonthuoc_stc || !bTayy) ? 0 : 150;
            TextCol.ReadOnly = true;
			ts.GridColumnStyles.Add(TextCol);
			

			TextCol=new DataGridColoredTextBoxColumn(de, 12);
			TextCol.MappingName = "mahc";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			

			TextCol=new DataGridColoredTextBoxColumn(de, 13);
			TextCol.MappingName = "diung";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			

			TextCol=new DataGridColoredTextBoxColumn(de, 14);
			TextCol.MappingName = "manguon";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			

            TextCol = new DataGridColoredTextBoxColumn(de, 15);
            TextCol.MappingName = (i_loai==7 || bGiaban)?"giaban":"dongia";
            TextCol.HeaderText = (bTongtien_donduyet && bTayy)?"Đơn giá":"";
            TextCol.Width = (bTongtien_donduyet && bTayy)?70:0;
            TextCol.Alignment = HorizontalAlignment.Right;
            TextCol.ReadOnly = true;
            TextCol.Format = "### ### ##0.00";
            ts.GridColumnStyles.Add(TextCol);
            

            TextCol = new DataGridColoredTextBoxColumn(de, 16);
            TextCol.MappingName = (i_loai==7 || bGiaban)?"sotienban":"sotien";
            TextCol.HeaderText = (bTongtien_donduyet && bTayy) ? "Số tiền" : "";
            TextCol.Width = (bTongtien_donduyet && bTayy) ? 80 : 0;
            TextCol.Alignment = HorizontalAlignment.Right;
            TextCol.ReadOnly = true;
            TextCol.Format = "### ### ##0.00";
            ts.GridColumnStyles.Add(TextCol);


            TextCol = new DataGridColoredTextBoxColumn(de, 17);
            TextCol.MappingName = "hoten";
            TextCol.HeaderText = "Người nhập";
            TextCol.Width = 100;
            ts.GridColumnStyles.Add(TextCol);
            //linha
            dataGrid1.TableStyles.Clear();
            //end linh
            dataGrid1.TableStyles.Add(ts);
		}

		public Color MyGetColorRowCol(int row, int col)
		{
            if (this.dataGrid1[row, 13].ToString().Trim() == "1") return Color.Red;
            else if (this.dataGrid1[row, 14].ToString().Trim() == "-1") return Color.Blue;
            else return Color.Black;
		}

		public delegate Color delegateGetColorRowCol(int row, int col);
		public class DataGridColoredTextBoxColumn : DataGridTextBoxColumn
		{
			private delegateGetColorRowCol _getColorRowCol;
			private int _column;
			public DataGridColoredTextBoxColumn(delegateGetColorRowCol getcolorRowCol, int column)
			{
				_getColorRowCol = getcolorRowCol;
				_column = column;
			}
			protected override void Paint(System.Drawing.Graphics g, System.Drawing.Rectangle bounds, System.Windows.Forms.CurrencyManager source, int rowNum, System.Drawing.Brush backBrush, System.Drawing.Brush foreBrush, bool alignToRight)
			{
				try
				{
					foreBrush = new SolidBrush(_getColorRowCol(rowNum, this._column));
					//backBrush = new SolidBrush(Color.GhostWhite);
				}
				catch{}
				finally
				{
					base.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight);
				}
			}
		}

		private void ref_text()
		{
			try
			{
				int i=dataGrid1.CurrentCell.RowNumber;
				stt.Text=dataGrid1[i,0].ToString();
				mabd.Text=dataGrid1[i,2].ToString();
				tenbd.Text=dataGrid1[i,3].ToString();
				tenhc.Text=dataGrid1[i,4].ToString();
				dang.Text=dataGrid1[i,5].ToString();
				d_soluong=(dataGrid1[i,8].ToString()!="")?decimal.Parse(dataGrid1[i,8].ToString()):0;
				makho.SelectedValue=dataGrid1[i,10].ToString();
				mahc.Text=dataGrid1[i,12].ToString();
				manguon.SelectedValue=dataGrid1[i,14].ToString();
                madoituong.SelectedValue = dataGrid1[i,9].ToString();
                i_madoituong = int.Parse(madoituong.SelectedValue.ToString());//lấy madoituong khi sửa đơn thuốc, lưu mã đt theo i_madoituong. trường hợp đối tượng thu phí
                //
                txtdongia.Text = dataGrid1[i, 15].ToString();
                txtgiaban.Text = dataGrid1[i, 15].ToString();
                //
                d_soluongcu = d_soluong;
                DataRow r1 = m.getrowbyid(dtct, "stt=" + decimal.Parse(stt.Text));
                i_mabdcu = i_makhocu = i_manguoncu = 0;
                if (r1 != null)
                {
                    i_manguoncu = int.Parse(r1["manguon"].ToString());
                    i_makhocu = int.Parse(r1["makho"].ToString());
                    i_mabdcu = int.Parse(r1["mabd"].ToString());
                    try
                    {
                        DataRow dr = d.getrowbyid(dtdmbd, "id=" + r1["mabd"].ToString() + "");
                        if (dr != null)
                        {
                            lbldvt.Text = (dr["donvidung"].ToString().Trim()!="") ? dr["donvidung"].ToString() : dr["dang"].ToString(); 
                        }

                    }
                    catch { }
                    if (bDonthuoc_stc) ghichuct.Text = r1["ghichu"].ToString();
                }
                if (bDonthuoc_stc)
                {
                    r1 = d.getrowbyid(dtdmbd, "ma='" + mabd.Text + "'");
                    if (r1 != null)
                        lblduongdung.Text = r1["duongdung"].ToString().Trim();
                    soluong1.Text = d_soluong.ToString("###,###,##0.00");
                    string s = dataGrid1[i, 11].ToString().Trim();
                    if (s.IndexOf("^") != -1)
                    {
                        int k = 0; string s1 = "";
                        for (int j = 0; j < s.Length; j++)
                        {
                            if (s.Substring(j, 1) == "^")
                            {
                                k++;
                                if (k == 1) c1.Text = s1;
                                else if (k == 2) c2.Text = s1;
                                else if (k == 3) c3.Text = s1;
                                s1 = "";
                            }
                            else s1 += s.Substring(j, 1);
                        }
                        if (s1 != "") c4.Text = s1;
                        cachdung.Text = "";
                    }
                    else cachdung.Text = s;
                    chk1.Checked = decimal.Parse(dataGrid1[i, 6].ToString()) == 1;
                    chk2.Checked = !chk1.Checked;
                }
                else
                {
                    soluong.Text = d_soluong.ToString("###,###,##0.00");
                    cachdung.Text = dataGrid1[i, 11].ToString();
                    solan.Value = decimal.Parse(dataGrid1[i, 6].ToString());
                    decimal sl=decimal.Parse(dataGrid1[i, 7].ToString());
                    moilan.Text = sl.ToString("###,###,##0.00");
                    //lbldvt.Text = dang.Text;
                }
			}
			catch{}
		}

		private void ena_object(bool ena)
		{
			mabn.Visible=ena;
			cmbMabn.Visible=!ena;
			if (d.bNhapmaso) mabd.Enabled=ena;
            if (bBamhuyet) chkHuyet.Enabled=huyet.Enabled = ena;
			tim.Enabled=songay.Enabled=ena;
			ghichu.Enabled=ena;
			tenbd.Enabled=ena;            
            if (!bTayy)
            {
                if (bDonthuoc_stc)
                    c1.Enabled = c2.Enabled = c3.Enabled = c4.Enabled = chk1.Enabled = chk2.Enabled = ghichuct.Enabled = false;
                else
                {
                    cachdung.Enabled = solan.Enabled = soluong.Enabled = false;
                    moilan.Enabled = ena;
                }
            }
            else
            {
                if (bDonthuoc_stc)
                    c1.Enabled = c2.Enabled = c3.Enabled = c4.Enabled = chk1.Enabled = chk2.Enabled = ghichuct.Enabled = ena;
                else
                {
                    if (bSolan) solan.Enabled = ena;
                    moilan.Enabled = solan.Enabled;
                    soluong.Enabled = cachdung.Enabled = ena;
                }
            }
            if (i_loaiba == 4 || i_loaiba==1) tenbs.Enabled = ena;
            //if (bChonkhoa) mabn.Enabled = hoten.Enabled = madoituong.Enabled = tenbs.Enabled = ena;
            //else if (bNgoaitonkho) tenhc.Enabled = dang.Enabled = ena;
            //tim.Visible = (bChonkhoa) ? ena : false;
            tim.Enabled = !ena;
            if (bChonkhoa && bNew)
            {
                mabn.Enabled = hoten.Enabled = madoituong.Enabled = tenbs.Enabled = ena;
                //tim.Visible = ena;
                tim.Enabled = !ena;
            }
            else if (bNgoaitonkho) tenhc.Enabled = dang.Enabled = ena;
			butThem.Enabled=ena;
			butXoa.Enabled=ena;
			butLuu.Enabled=ena;
			butBoqua.Enabled=ena;
			butMoi.Enabled=!ena;
            butDongy.Enabled = (bDongy(makhosave, 1))?true:false;//Thuy 22.05.2012
			butCholai.Enabled=ena;
            butIn.Enabled=!ena;
			butHuy.Enabled=!ena;
			butSua.Enabled=!ena;
			butKetthuc.Enabled=!ena;
            donthuoc.Enabled = ena;            
            butGoi.Enabled=chkChon.Enabled = ena;
			i_old=cmbMabn.SelectedIndex;
			if (ena && !bChonkhoa) load_dm();
            if (ena) load_control();
            dataGrid1.ReadOnly = !ena;
            //linha
            txtHen.Enabled = ena;
            ngaynghi.Enabled = (ena && chkQuanlyngaynghiphep.Checked);
            //endlinh
            if (s_Maicd != maicd.Text)//gam 13/12/2011
            {
                maicd.Enabled = ena;
                chandoan.Enabled = ena;
            }
		}

        private void emp_head()
        {
            if (bDiungthuoc)
            {
                diung.ForeColor = Color.FromArgb(0, 0, 128);
                diung.Tag = "";
            }
            mabn.Text = s_mabn; hoten.Text = s_Hoten; hoten.Tag = s_Phai;
            string[] arr_nsinh = s_Namsinh.Split('^');
            namsinh.Text = arr_nsinh[0];
            if (arr_nsinh.Length > 1) namsinh.Tag = arr_nsinh[1];
            else namsinh.Tag = "";
            chandoan.Text = s_Chandoan; maicd.Text = s_Maicd; ghichu.Text = "";
            tenpk.Text = s_Tenkp; tenbs.Text = s_Tenbs; sothe.Text = s_Sothe;
            makp.Text = s_makp; mabs.Text = s_mabs; s_ngayvv = s_ngay;
            l_id = 0; dsxoa.Clear(); s_ngaymakp = ""; songay.Value = iBhyt_songay;
            txtgiaban.Text = txtdongia.Text = "0";
        }

		private void emp_detail()
		{
            solan.Value = (bTayy)?1:Math.Max(1,songay.Value); mabd.Text = ""; tenbd.Text = ""; tenhc.Text = ""; dang.Text = ""; cachdung.Text = ""; mahc.Text = "";
            moilan.Text=soluong.Text = ""; makho.SelectedIndex = -1; stt.Text = d.get_stt(dtct).ToString();
            if (!bChonkhoa)
            {
                try
                {
                    if (i_loai == 9)
                    {
                        madoituong.SelectedValue = "3";
                        i_madoituong = 3;
                    }
                    else if (i_madoituong == 5) madoituong.SelectedValue = "2";
                    else madoituong.SelectedValue = i_madoituong.ToString();
                }
                catch { }
            }
            i_manguoncu = i_makhocu = i_mabdcu = 0; d_soluongcu = 0; lbldvt.Text = lblduongdung.Text = c1.Text = c2.Text = c3.Text = c4.Text = soluong1.Text = "";
            txtgiaban.Text = txtdongia.Text = "0";
            ghichuct.Text = "";
            chk1.Checked = true; chk2.Checked = false;
		}

		private void load_dm()
		{
            dtton = d.get_tonkhoth_dutru_bhyt(i_nhom, s_mmyy, s_makho, s_makho_kp, s_manguon, (bDieutringtr) ? 0 : i_madoituong, bLocdichvu);
            if (bNgoaitonkho)
            {
                int irec = dtton.Rows.Count + 1;
                foreach (DataRow r in m.get_data("select * from " + user + ".d_dmbd where nhom=" + i_nhom + " and hide<>1 order by ten").Tables[0].Rows)
                    updrec(irec++, decimal.Parse(r["id"].ToString()),r["ma"].ToString(),r["ten"].ToString().Trim() + " " + r["hamluong"].ToString(), r["dang"].ToString(), r["tenhc"].ToString(), r["mahc"].ToString());
            }
			listDmbd.DataSource=dtton;
			listCachdung.DataSource=d.get_data("select ten as stt,ten from "+user+".d_dmcachdung order by ten").Tables[0];

            dtLoidan = d.get_data("select id,ten from " + user + ".dmloidan order by ten").Tables[0];
            listLoidan.DataSource = dtLoidan;

            DataTable dticd = m.get_data("select cicd10,vviet from " + user + ".icd10 where hide=0 order by cicd10").Tables[0];
            listICD.DisplayMember = "CICD10";
            listICD.ValueMember = "VVIET";
            listICD.DataSource = dticd;
		}

        private void updrec(int irec,decimal id,string ma,string ten,string dang,string tenhc,string mahc)
        {
            DataRow r1 ;
            DataRow r2 = d.getrowbyid(dtton, "ma='" + ma + "'");
            if (r2 == null)
            {
                r1 = dtton.NewRow();
                r1["stt"] = irec;
                r1["tennguon"] = "Tự mua";
                r1["ma"] = ma;
                r1["ten"] = ten;
                r1["tenhc"] = tenhc;
                r1["dang"] = dang;
                r1["tenkho"] = "Tự mua";
                r1["soluong"] = 0;
                r1["id"] = id;
                r1["makho"] = -1;
                r1["bhyt"] = 0;
                r1["mahc"] = mahc;
                r1["manguon"] = -1;
                r1["tutruc"] = 0;
                dtton.Rows.Add(r1);
            }
        }

        private void load_control()
        {
            //linha
            //foreach (System.Windows.Forms.Control c in this.Controls) if (c.Name == "dataGrid1") this.Controls.Remove(c);
            //dataGrid1 = new System.Windows.Forms.DataGrid();
            //this.dataGrid1.AlternatingBackColor = System.Drawing.Color.Lavender;
            //this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            //            | System.Windows.Forms.AnchorStyles.Left)
            //            | System.Windows.Forms.AnchorStyles.Right)));
            //this.dataGrid1.BackColor = System.Drawing.Color.WhiteSmoke;
            //this.dataGrid1.BackgroundColor = System.Drawing.SystemColors.Control;
            //this.dataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            //this.dataGrid1.CaptionBackColor = System.Drawing.SystemColors.Control;
            //this.dataGrid1.CaptionFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //this.dataGrid1.CaptionForeColor = System.Drawing.Color.MidnightBlue;
            //this.dataGrid1.DataMember = "";
            //this.dataGrid1.FlatMode = true;
            //this.dataGrid1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //this.dataGrid1.ForeColor = System.Drawing.Color.MidnightBlue;
            //this.dataGrid1.GridLineColor = System.Drawing.Color.Gainsboro;
            //this.dataGrid1.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            //this.dataGrid1.HeaderFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            //this.dataGrid1.HeaderForeColor = System.Drawing.Color.WhiteSmoke;
            //this.dataGrid1.LinkColor = System.Drawing.Color.Teal;
            //this.dataGrid1.Location = new System.Drawing.Point(9, 165);
            //this.dataGrid1.Name = "dataGrid1";
            //this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            //this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            //this.dataGrid1.ReadOnly = true;
            //this.dataGrid1.RowHeaderWidth = 10;
            //this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            //this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            //this.dataGrid1.Size = new System.Drawing.Size(i_w,i_h);//615,279
            //this.dataGrid1.TabIndex = 281;
            //this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            //this.Controls.Add(dataGrid1);
            //endlinh
            load_grid();
            AddGridTableStyle();
        }

        private bool moi()
        {
            if (!d.bMmyy(s_mmyy))
            {
                MessageBox.Show(lan.Change_language_MessageText("Số liệu tồn kho tháng ") + s_mmyy.Substring(0, 2) + lan.Change_language_MessageText(" năm 20") + s_mmyy.Substring(2) + lan.Change_language_MessageText(" chưa tạo !"), s_msg);
                return false;
            }
            if (bChonkhoa && tim.Text != "" && tim.Text.Trim() != "Tìm kiếm")
            {
                tim.Text = "";
                tim_TextChanged(null, null);
            }
            DataRow r1;
            if (m.bDonthuoc_khambenh_1lan && i_loaiba != 1)
            {
                r1 = m.getrowbyid(dtll, "mabn='" + mabn.Text + "'");
                if (r1 != null)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Đã nhập đơn thuốc !"), LibMedi.AccessData.Msg);
                    butSua.Focus();
                    return false;
                }
            }
            //treeView1.Nodes.Clear();//binh 130811 //Khuong comment ngay 08/11/2011
            if (!(butMoi.Enabled && butDongy.Enabled))
            {
                //gam 12/08/2011
                //r1 = m.getrowbyid(dtll, "mabn='" + mabn.Text + "' and done=0");
                r1 = m.getrowbyid(dtll, "mabn='" + mabn.Text + "' and done=0 and loai=1");
                //gam 12/08/2011
                if (r1 != null)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Đã nhập đơn thuốc chưa duyệt !"), LibMedi.AccessData.Msg);
                    butSua.Focus();
                    return false;
                }

            }
            
            if (bKhoaso)
            {
                MessageBox.Show(lan.Change_language_MessageText("Số liệu tháng") + " " + s_mmyy.Substring(0, 2) + " " + lan.Change_language_MessageText("năm") + " " + s_mmyy.Substring(2, 2) + " " + lan.Change_language_MessageText("đã khóa !") + "\n" + lan.Change_language_MessageText("Nếu cần thay đổi thì vào mục khai báo hệ thống"), d.Msg);
                return false;
            }
            if (bInchitiet && i_loai != 7)
            {
                string tenkp = m.inchiphipk(s_ngay, l_mavaovien);
                if (tenkp != "")
                {
                    MessageBox.Show(lan.Change_language_MessageText("Đã in chi phí tại") + " " + tenkp + " !", s_msg);
                    return false;
                }
            }
            if (i_loaiba == 1 && !bChonkhoa && i_loai != 7)
            {
                if (m.get_thvpll(s_ngay, l_maql, s_ngayvao))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Chi phí người bệnh đã chuyển xuống viện phí !"), LibMedi.AccessData.Msg);
                    return false;
                }
            }
            
            if (i_loaiba == 2)
            {
                if (m.get_data("select * from " + user + ".benhanngtr where maql=" + l_maql+" and ngayrv is not null").Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Người bệnh")+" "+s_Hoten+" "+lan.Change_language_MessageText("đã kết thúc điều trị !"), LibMedi.AccessData.Msg);
                    return false;
                }
            }
            
            string _ngay = m.ngayhienhanh_server.Substring(0, 10);
            if (bNgayhienhanh_thuoc_chidinh && s_ngay.Substring(0, 10) != _ngay && (bDuyet || i_madoituong == 5))//bDieutringtr)
            {
                MessageBox.Show(lan.Change_language_MessageText("Ngày cấp đơn không được khác ngày hiện hành") + " " + _ngay, LibMedi.AccessData.Msg);
                return false;
            }
            if (!m.ngay(m.StringToDate(s_ngayvao.Substring(0, 10)), m.StringToDate(_ngay), iKhoangcachngaycaptoa_voingaykham) && (i_loaiba == 3 || i_loaiba==4 || i_loaiba==2) && m.bAdminHethong(i_userid)==false)
            {
                if (iKhoangcachngaycaptoa_voingaykham>0)
                    MessageBox.Show(lan.Change_language_MessageText("Ngày cấp toa so với ngày khám vượt quá '") + iKhoangcachngaycaptoa_voingaykham.ToString() + "' ngày!", s_msg);
                else
                    MessageBox.Show(lan.Change_language_MessageText("Ngày cấp toa không được khác so với ngày khám !"), s_msg);
                return false;
            }
            //
            //
            if (bXemlai && s_ngay != m.ngayhienhanh_server && m.bAdminHethong(i_userid) == false)
            {
                MessageBox.Show(lan.Change_language_MessageText("Bạn chỉ được phép xem lại này chứ không được phép thêm mới."));
                return false;
            }
            //
            //
            bool bExit = false;
            decimal d_songay = 0;
            string ngay_cap = "";
            sql = "select songay,to_char(ngay,'dd/mm/yyyy') as ngay,to_char(ngay,'yyyymmdd') as yyyymmdd from xxx.d_thuocbhytll where mabn='" + s_mabn + "' and nhom=" + i_nhom + " and madoituong=" + i_madoituong;
            sql += " and ngay<to_timestamp('" + s_ngay.Substring(0, 10) + "','" + d.f_ngay + "')";
            sql += " order by ngay desc";
            foreach (DataRow r in d.get_thuoc(s_ngay, s_ngay, sql).Tables[0].Select("true", "yyyymmdd desc"))
            {
                ngay_cap = r["ngay"].ToString();
                d_songay = decimal.Parse(r["songay"].ToString());
                if (d_songay > 0) bExit = Math.Abs(m.songay(m.StringToDate(s_ngay.Substring(0, 10)), m.StringToDate(r["ngay"].ToString()), 0)) < d_songay;
                break;
            }
            if (bExit)
            {
                if (MessageBox.Show(lan.Change_language_MessageText("Ngày") + " " + ngay_cap + " " + lan.Change_language_MessageText("cấp đơn thuốc") + " " + d_songay.ToString().Trim() + " " + lan.Change_language_MessageText("ngày") + "\n" + lan.Change_language_MessageText("Bạn có muốn cấp tiếp không ?"), LibMedi.AccessData.Msg, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    emp_head();
                    return false;
                }
            }
            bNew = true;
            bEdit = true;
            ena_object(true);
            dtct.Clear();
            dtsave.Clear();

            emp_head();
            emp_detail();
            //            
            ghichu.Text = f_get_ttmat(s_makp, l_maql);//load thong tin thi luc: neu la pk mat
            //
            //if (mabn.Text != "" && l_maql != 0)
            //{
            //    mabn_Validated(mabn, null);
            //    load_treeview();
            //}
            if (bDiungthuoc) load_diungthuoc(mabn.Text);
            
            if (bChonkhoa) mabn.Focus();
            else if (tenbs.Enabled) tenbs.Focus();
            else songay.Focus();
            return true;
        }
        private void butDongy_Click(object sender, EventArgs e)
        {
            //linh
            if (!test()) return;
            //if (makhosave != "")
            //{
            //    s_makho = "";
            //    sql = "select * from " + user + ".d_dmkho where dongy=1 and id in (" + makhosave.Substring(0, makhosave.Length - 1) + ")";
            //    if (i_khudt != 0) sql += " and (khu=0 or khu=" + i_khudt + ")";
            //    foreach (DataRow r in m.get_data(sql).Tables[0].Rows) s_makho += r["id"].ToString().PadLeft(3,'0') + ",";
            //}
            //end linh
            chkChitiet.Checked = true;
            label9.Text = " " + lan.Change_language_MessageText("thang");
            bTayy = false;
            if (!moi()) return;
        }

		private void butMoi_Click(object sender, System.EventArgs e)
		{
            s_ngaydonthuoc = s_ngay;
            if (!test()) return;
            bXemToaCu = false;
            chkChitiet.Checked = false;
            label9.Text = " " + lan.Change_language_MessageText("ngày");
            bTayy = true;        
            if (!moi()) return;
		}
        // Phương thức kiểm tra ngày khám của bệnh nhân và ngày cấp toa
        // nếu ngày khám lớn hơn ngày cấp toa iKhoangcachngaycaptoa_voingaykham thì không cho khám
        private bool kiemtra_ngaykham_toa()
        {
            try
            {
                DateTime d_ngaykham = m.StringToDate(s_ngay_kham);// new DateTime(int.Parse(s_ngay_kham.Substring(6, 4)), int.Parse(s_ngay_kham.Substring(3, 2)), int.Parse(s_ngay_kham.Substring(0, 2)));
                DateTime d_ngaydon = m.StringToDate(s_ngaydonthuoc);// new DateTime(int.Parse(s_ngaydonthuoc.Substring(6, 4)), int.Parse(s_ngaydonthuoc.Substring(3, 2)), int.Parse(s_ngaydonthuoc.Substring(0, 2)));
                TimeSpan p = d_ngaykham - d_ngaydon;
                int i_khoangcach = p.Days;
                if (i_khoangcach > m.iKhoangcachngaycaptoa_voingaykham)
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

		private void butSua_Click(object sender, System.EventArgs e)
		{
            if (cmbMabn.Items.Count > 0 && cmbMabn.SelectedIndex >= 0) cmbMabn_SelectedIndexChanged(null, null);
            if (!kiemtra_ngaykham_toa())
            {
                MessageBox.Show(lan.Change_language_MessageText("Ngày khám không thể lớn hơn ngày cấp toa"), "Medisoft");
                return;
            }
            if (bChonkhoa && b_BNDaravien)
            {
                MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân này đã ra khoa không cho sửa toa"), "Medisoft");
                return;
            }
            if (s_ngaydonthuoc != s_ngay)
            {
                s_ngay = s_ngaydonthuoc;
            }
            if (!bDuyet && !kiemtraDone_paid())//binh 130811
            {
                MessageBox.Show(lan.Change_language_MessageText("Bạn không thể sửa toa thuốc này, toa thuốc được cập duyệt rồi, phải thu hồi bên dược trước"), "Medisoft");
                return;
            }
            if (bDuyet && !kiemtra_paid(s_ngay_kham.Substring(0, 10), s_ngay.Substring(0, 10)))
            {
                MessageBox.Show(lan.Change_language_MessageText("Bạn không thể sửa toa thuốc này, toa thuốc đã thu tiền rồi, phải hoàn trả hoá đơn trước"), "Medisoft");
                return;
            }
            if (dtll.Rows.Count==0) return;
            if (bXemlai && s_ngay != m.ngayhienhanh_server && m.bAdminHethong(i_userid)==false)
            {
                MessageBox.Show(lan.Change_language_MessageText("Bạn chỉ được phép xem lại toa này chứ không được phép sửa."));
                return;
            }
            l_id = decimal.Parse(cmbMabn.SelectedValue.ToString());
            if (bKhoaso)
            {
                MessageBox.Show(lan.Change_language_MessageText("Số liệu tháng")+" " + s_mmyy.Substring(0, 2) + " "+lan.Change_language_MessageText("năm")+" " + s_mmyy.Substring(2, 2) + " "+lan.Change_language_MessageText("đã khóa !")+"\n"+lan.Change_language_MessageText("Nếu cần thay đổi thì vào mục khai báo hệ thống"), d.Msg);
                return;
            }
            //if (bInchitiet && i_loai!=7)
            if (bInchitiet && ((bToaThuocF5_TuDong_TruTonkho_F44 && i_loai ==7) || (bToaThuocF5_TuDong_TruTonkho_F44 == false && i_loai != 7)))//b i_loai!=7)
            {
                string tenkp = m.inchiphipk(s_ngay, l_mavaovien);
                if (tenkp != "")
                {
                    MessageBox.Show(lan.Change_language_MessageText("Đã in chi phí tại") + " " + tenkp + " !", s_msg);
                    return;
                }
            }
            else
            {
                if (bDuyet == false)
                    bDone = d.get_done_thuocbhyt(s_ngay, l_id);//binh 130811: neu KHONG duyet toa tu dong thi cho BS cap toa sua khi Duoc chua duyet
                else
                    bDone = d.get_paid_thuocbhyt(s_ngay, l_id);//binh 130811: neu duyet toa tu dong thi cho BS cap toa sua khi chua thu tien
                if (bDone)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Đã cập nhật !"), s_msg);
                    return;
                }
            }
            if (i_loaiba == 2)
            {
                if (m.get_data("select * from " + user + ".benhanngtr where maql=" + l_maql+" and ngayrv is not null").Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Người bệnh")+" " + s_Hoten + " "+lan.Change_language_MessageText("đã kết thúc điều trị !"), LibMedi.AccessData.Msg);
                    return;
                }
            }
            if (butMoi.Enabled && butDongy.Enabled)
            {
                if (makhosave != "")
                {
                    s_makho = "";//Thuy 23.04.2012 bỏ đk dongy="+((bTayy)?0:1)+"
                    //sql = "select * from " + user + ".d_dmkho where dongy="+((bTayy)?0:1)+" and id in (" + makhosave.Substring(0, makhosave.Length - 1) + ")";
                    sql = "select * from " + user + ".d_dmkho where hide=0 and id in (" + makhosave.Substring(0, makhosave.Length - 1) + ")";
                    if (i_khudt != 0) sql += " and (khu=0 or khu=" + i_khudt + ")";
                    foreach (DataRow r in m.get_data(sql).Tables[0].Rows)
                    {
                        //s_makho += r["id"].ToString().PadLeft(3, '0') + ",";
                        s_makho += r["id"].ToString() + ",";
                    }
                }
            }
            
			ena_object(true);
			butCholai.Enabled=false;
			bNew=false;
			bEdit=true;
            s_ngaymakp = "";
			dtsave=dtct.Copy();
			dsxoa.Clear();
			ref_text();
			dataGrid1.Focus();
		}
        /// <summary>
        /// Kiểm tra paid ,done nếu <> 0 thì không cho phép sửa
        /// </summary>
        /// <returns></returns>
        private bool kiemtraDone_paid()
        {
            sql = "select * from " + xxx + ".d_thuocbhytll where mabn='" + s_mabncaptoa + "' and maql=" + l_maql + " and id =" + l_id + " and done<>0";
            if (m.get_data(sql).Tables[0].Rows.Count > 0)
            {
                return false;
            }
            return true;
        }

		private bool kiemtra()
		{
			if (bKiemtrathuoc)
			{
                string ret=d.kiemtra_toathuoc(dtdmbd,dtct,mabn.Text,i_nhom,s_ngay,l_id);
                if (ret != "")
                {
                    MessageBox.Show(lan.Change_language_MessageText("Những thuốc sau đã kê toa :") + "\n" + ret);
                    return false;
                }
			}
            //if (dtct.Rows.Count == 0)  // truong thuy 06052014 // dong lai khi chua luu thì nó không cho them  thuốc vào 
            //{
            //    MessageBox.Show(lan.Change_language_MessageText("Đề nghị nhập thuốc !"), LibMedi.AccessData.Msg);
            //    butThem.Focus();
            //    return false;
            //}
            if (tenbs.Enabled && tenbs.Text == "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Chọn bác sỹ điều trị !"), LibMedi.AccessData.Msg);
                tenbs.Focus();
                return false;
            }
            if (bTayy && sothe.Text != "" && songay.Value!=0)
            {
                string denngay = "";
                sql = "select to_char(a.tungay,'dd/mm/yyyy') as tungay,to_char(a.denngay,'dd/mm/yyyy') as denngay,b.tenbv ";
                sql += " from " + xxx + ".bhyt a left join " + user + ".dmnoicapbhyt b on a.mabv=b.mabv where a.maql=" + l_maql;
                foreach (DataRow r in m.get_data(sql).Tables[0].Rows)
                {
                    denngay = r["denngay"].ToString();
                    break;
                }
                if (denngay != "")
                {
                    decimal so = m.songay(m.StringToDate(denngay), m.StringToDate(s_ngay), 1);
                    if (songay.Value > so)
                    {
                        if (MessageBox.Show(lan.Change_language_MessageText("Hạn sử dụng thẻ đến ngày")+" " + denngay + ", còn lại " + so.ToString() + " ngày\nSố ngày cấp đơn " + songay.Value.ToString() + " vượt quá hạn sử dụng\nBạn có tiếp tục không ?", LibMedi.AccessData.Msg, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                        {
                            songay.Value = so;
                            solan_Validated(null, null);
                            songay.Focus();
                            return false;
                        }
                    }
                }
            }
			return true;
		}
		private void butLuu_Click(object sender, System.EventArgs e)
		{
			bEdit=false;
			upd_table(dtct,"-");
			dtct.AcceptChanges();
			i_old=(bNew)?0:1;
			l_id=(bNew)?d.get_id_bhyt:l_id;
            bool b_kt = kiemtra();
			//if (!kiemtra()) return;
            itable = m.tableid(m.mmyy(s_ngay), "d_thuocbhytll");
            if (!bNew)
            {
                m.upd_eve_tables(s_ngay, itable, i_userid, "upd");
                m.upd_eve_upd_del(s_ngay, itable, i_userid, "upd",m.fields(xxx+".d_thuocbhytll","id="+l_id));
            }
            else m.upd_eve_tables(s_ngay, itable, i_userid, "ins");
            // hien:23-06-2011: them field ngay nghi
            //linha
                if (l_sotoa == 0)
            {
                l_sotoa = m.get_capsotoa_ngay(-2, i_madoituong.ToString(),s_ngay);
            }
            if (!d.upd_thuocbhytll(l_id, i_nhom, s_ngay, mabn.Text, l_mavaovien, l_maql, i_userid, (bChonkhoa && i_madoituong == 1) ? int.Parse(madoituong.SelectedValue.ToString()) : i_madoituong, ghichu.Text, songay.Value, makp.Text, mabs.Text, chandoan.Text, maicd.Text, i_loaiba, (int)ngaynghi.Value, txtNgaynghi_tungay.Text.Trim().Trim('/'), (int)txtHen.Value, l_sotoa))//gam 30/11/2011 (bChonkhoa && i_madoituong != 2)?5:
            {
                MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin !"), s_msg);
                return;
            }
            //endlinh
            if (i_loaiba == 1)
            {
                foreach (DataRow r in m.get_data("select mabv,sothe,to_char(denngay,'dd/mm/yyyy') as denngay,to_char(tungay,'dd/mm/yyyy') as tungay,maphu from " + user + ".bhyt where maql=" + l_maql).Tables[0].Rows)
                    m.upd_bhyt(s_ngay, mabn.Text, l_maql, r["sothe"].ToString(), r["denngay"].ToString(), r["mabv"].ToString(), int.Parse(r["maphu"].ToString()), r["tungay"].ToString(),ngay1,ngay2,ngay3,traituyen);
            }
			if (!bNew)
			{
                itable = m.tableid(m.mmyy(s_ngay), "d_thuocbhytct");
				foreach(DataRow r1 in dsxoa.Tables[0].Rows)
				{
                    m.upd_eve_tables(s_ngay, itable, i_userid, "del");
                    m.upd_eve_upd_del(s_ngay, itable, i_userid, "del",m.fields(xxx+".d_thuocbhytct","id="+l_id+" and stt="+decimal.Parse(r1["stt"].ToString())));
					d.execute_data("delete from "+xxx+".d_thuocbhytct where id="+l_id+" and stt="+decimal.Parse(r1["stt"].ToString()));
				}
                foreach (DataRow r1 in dtsave.Rows)
                {
                    d.upd_tonkhoth_dutru(d.delete, i_nhom, s_mmyy, int.Parse(r1["makho"].ToString()), int.Parse(r1["manguon"].ToString()), int.Parse(r1["mabd"].ToString()), decimal.Parse(r1["soluong"].ToString()));
                    m.upd_eve_tables(s_ngay, itable, i_userid, "upd");
                }
			}
            itable = m.tableid(m.mmyy(s_ngay), "d_thuocbhytct");
			foreach(DataRow r1 in dtct.Rows)
			{
                d.upd_thuocbhytct(s_ngay, l_id, int.Parse(r1["stt"].ToString()), int.Parse(r1["makho"].ToString()), int.Parse(r1["mabd"].ToString()), decimal.Parse(r1["soluong"].ToString()), r1["cachdung"].ToString(), int.Parse(r1["manguon"].ToString()), decimal.Parse(r1["solan"].ToString()), decimal.Parse(r1["lan"].ToString()), int.Parse(r1["madoituong"].ToString()), r1["ghichu"].ToString());
				d.upd_tonkhoth_dutru(d.insert,i_nhom,s_mmyy,int.Parse(r1["makho"].ToString()),int.Parse(r1["manguon"].ToString()),int.Parse(r1["mabd"].ToString()),decimal.Parse(r1["soluong"].ToString()));
				if (r1["cachdung"].ToString()!="" && bCachdung) d.upd_dmcachdung(r1["cachdung"].ToString());
                if (bNew) m.upd_eve_tables(s_ngay, itable, i_userid, "ins");
			}
            // hien:23-06-2011: them fiel ngay nghi
            //linha
            d.updrec_thuocbhytll(dtll, l_id, s_ngay, mabn.Text, l_maql, hoten.Text, namsinh.Text, sothe.Text, chandoan.Text, maicd.Text, tenpk.Text,
                tenbs.Text, ghichu.Text, makp.Text, mabs.Text, songay.Value, ngaynghi.Value,
                txtNgaynghi_tungay.Text.Trim('/'), (int)txtHen.Value, l_sotoa);//linh them so toa
            //end
			try
			{
				if (i_old==0 && dtll.Rows.Count>0) cmbMabn.SelectedIndex=dtll.Rows.Count-1;
			}
			catch{}
			if (bDiungthuoc) upd_diung();
			load_grid();
            if (bNew && bLuu_Donthuoc_bacsy) luu_don();
            //if (bDuyet && i_loai != 7) upd_duoc();//xuat ban ko tru kho tu dong 
            if (bDuyet && i_loai != 7) upd_duoc();//xuat ban khong tru kho tu dong//
            else if (bToaThuocF5_TuDong_TruTonkho_F44 && i_loai == 7) upd_duoc_xuatban();
            if (bDichvu_vpkb) upd_vienphi();
            maicd.Enabled = false;
            chandoan.Enabled = false;
			ena_object(false);
            if (bDonthuoc_stc)
            {
                soluong1.Enabled = false;
                cachdung.Enabled = false;
            }
            if (bChonkhoa) netsend();
            tenhc.Enabled = dang.Enabled = false;
            if (chkLuuin.Checked) butIn_Click(sender, e);
            else butMoi.Focus();
		}
        
        private void netsend()
        {
            if (bTinnhan || bTinnhan_sound)
            {
                string _makho = "";
                foreach (DataRow r in dtct.Rows)
                    if (_makho.IndexOf(r["makho"].ToString() + ",") == -1) _makho += r["makho"].ToString() + ",";
                _makho = (_makho == "") ? _makho : _makho.Substring(0, _makho.Length - 1);
                sql = "true";
                if (_makho != "") sql += " and id in (" + _makho + ")";
                if (bTinnhan)
                {
                    foreach (DataRow r in dtkho.Select(sql))
                        if (r["computer"].ToString() != "")
                            d.netsend(d.sDomain(i_nhom), r["computer"].ToString().Trim(), "DON THUOC " + mabn.Text + " " + m.khongdau(hoten.Text));
                }
                if (bTinnhan_sound)
                {
                    foreach (DataRow r in dtkho.Select(sql))
                        if (r["computer"].ToString() != "")
                            m.upd_tinnhan(r["computer"].ToString().Trim(), "duoc",1);
                }
            }
        }

        private void upd_duoc()
        {
            itable = d.tableid(s_mmyy, "bhytthuoc");
            if (!bNew)            
            {
                sql = "select a.*,t.manguon,t.nhomcc,t.handung,t.losx,t.giamua,t.giaban,a.soluong*t.giamua as sotienmua from " 
                    + zzz + ".bhytthuoc a," + zzz + ".d_theodoi t where a.sttt=t.id and a.id=" + l_id;
                foreach (DataRow r1 in d.get_data(sql).Tables[0].Rows)
                {
                    d.upd_eve_tables(s_mmyy, itable, i_userid, "del");
                    d.upd_eve_upd_del(s_mmyy, itable, i_userid, "del", d.fields(zzz + ".bhytthuoc", "id=" + l_id + " and stt=" + decimal.Parse(r1["stt"].ToString())));
                    d.execute_data("delete from " + zzz + ".bhytthuoc where id=" + l_id + " and stt=" + decimal.Parse(r1["stt"].ToString()));
                    d.upd_tonkhoct_xuat(d.delete, s_mmyy, decimal.Parse(r1["sttt"].ToString()), int.Parse(r1["makho"].ToString()), 
                        int.Parse(r1["manguon"].ToString()), int.Parse(r1["nhomcc"].ToString()), int.Parse(r1["mabd"].ToString()),
                        r1["handung"].ToString(), r1["losx"].ToString(), decimal.Parse(r1["soluong"].ToString()), 
                        decimal.Parse(r1["sotienmua"].ToString()), decimal.Parse(r1["giaban"].ToString()), decimal.Parse(r1["giamua"].ToString()));
                }
            }
            if (!d.upd_bhytds(s_mmyy, s_mabn, s_Hoten, s_Namsinh.Substring(0,4), s_diachi))
            {
                MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin !"), LibMedi.AccessData.Msg);
                return;
            }
            itable = d.tableid(s_mmyy, "bhytkb");
            if (bNew) d.upd_eve_tables(s_mmyy, itable, i_userid, "ins");
            else
            {
                d.upd_eve_tables(s_mmyy, itable, i_userid, "upd");
                d.upd_eve_upd_del(s_mmyy, itable, i_userid, "upd", d.fields(zzz + ".bhytkb", "id=" + l_id));
            }
            if (!d.upd_bhytkb(s_mmyy, l_id, i_nhom, s_ngay, s_mabn, l_mavaovien, l_maql, s_makp, s_Chandoan, s_Maicd, s_mabs, 
                s_Sothe, i_madoituong, s_noidkkcb, iUserid_duyet,i_loaiba,traituyen))
            {
                MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin !"), LibMedi.AccessData.Msg);
                return;
            }
            DataTable tmp = d.get_bhytthuoc(s_mmyy, load_thuoc(l_id), l_id, (i_loaiba == 2) ? 0 : i_madoituong);
            d.execute_data("update " + xxx + ".d_thuocbhytll set done=1 where id=" + l_id);
            int d_toaso = d.get_sotoa_bhyt(s_mmyy, l_id, s_ngay.Substring(0,10), i_madoituong);
            d.execute_data("update " + zzz + ".bhytkb set sotoa=" + d_toaso + " where id=" + l_id);
        }
        private void upd_vienphi()
        {
            DateTime dt1 = m.StringToDate(s_ngay).AddDays(-d.iNgaykiemke);
            DateTime dt2 = m.StringToDate(s_ngay).AddDays(d.iNgaykiemke);
            int y1 = dt1.Year, m1 = dt1.Month;
            int y2 = dt2.Year, m2 = dt2.Month;
            int itu, iden;
            string d_mmyy = "";
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
                        sql = "select id from " + user + mmyy + ".bhytkb where id=" + l_id;
                        tmp = m.get_data(sql).Tables[0];
                        if (tmp.Rows.Count > 0)
                        {
                            l_id = decimal.Parse(tmp.Rows[0]["id"].ToString());
                            d_mmyy = mmyy;
                            break;
                        }
                    }
                }
            }
            string yyy = user + m.mmyy(s_ngay);
            int stt = 1, itable;
            if (l_id != 0 && d_mmyy != "" && bDuyet_khambenh && sothe.Text != "" && i_loai !=7)
            {
                itable = d.tableid(d_mmyy, "bhytcls");
                d.execute_data("delete from " + user + d_mmyy + ".bhytcls where id=" + l_id);
                sql = "select * from xxx.v_chidinh where mabn='" + s_mabn + "' and mavaovien=" + l_mavaovien;
                if (l_maql != 0) sql += " and maql in (" +l_maql + ")";
                sql += " and madoituong=" + i_madoituong;
                foreach (DataRow r in d.get_data_mmyy(sql, s_ngay, s_ngay, 30).Tables[0].Rows)
                {
                    d.upd_bhytcls(d_mmyy, l_id, stt++, int.Parse(r["mavp"].ToString()), decimal.Parse(r["soluong"].ToString()), decimal.Parse(r["dongia"].ToString()), decimal.Parse(r["id"].ToString()));
                    sql = "update xxx.v_chidinh set paid=1 where id=" + decimal.Parse(r["id"].ToString()) + " and mavp=" + int.Parse(r["mavp"].ToString());
                    if (l_maql != 0) sql += " and maql in (" + l_maql + ")";
                    sql += " and madoituong=" +i_madoituong;
                    d.execute_data_mmyy(sql, s_ngay,s_ngay, 30);
                    d.upd_eve_tables(d_mmyy, itable, i_userid, "ins");
                }
            }
            else if (bDuyet_khambenh && sothe.Text != "")
            {
                int i_nhom = m.nhom_duoc;
                l_id = d.get_id_bhyt;
                d_mmyy = m.mmyy(s_ngay);
                if (!d.upd_bhytds(d_mmyy, s_mabn, hoten.Text, namsinh.Text,s_diachi))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin !"), LibMedi.AccessData.Msg);
                    return;
                }
                itable = d.tableid(d_mmyy, "bhytkb");
                d.upd_eve_tables(d_mmyy, itable, i_userid, "ins");
                if (!d.upd_bhytkb(d_mmyy, l_id, i_nhom, s_ngay, s_mabn, l_mavaovien, l_maql, makp.Text,chandoan.Text,maicd.Text, mabs.Text, sothe.Text, int.Parse(madoituong.SelectedValue.ToString()), "", i_userid, 3, traituyen))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin !"), LibMedi.AccessData.Msg);
                    return;
                }
                itable = d.tableid(d_mmyy, "bhytcls");
                sql = "select * from xxx.v_chidinh where mabn='" + s_mabn + "' and mavaovien=" + l_mavaovien;
                if (l_maql != 0) sql += " and maql in (" + l_maql + ")";
                sql += " and madoituong=" + int.Parse(madoituong.SelectedValue.ToString());
                foreach (DataRow r in d.get_data_mmyy(sql, s_ngay,s_ngay, 30).Tables[0].Rows)
                {
                    d.upd_bhytcls(d_mmyy, l_id, stt++, int.Parse(r["mavp"].ToString()), decimal.Parse(r["soluong"].ToString()), decimal.Parse(r["dongia"].ToString()), decimal.Parse(r["id"].ToString()));
                    sql = "update xxx.v_chidinh set paid=1 where id=" + decimal.Parse(r["id"].ToString()) + " and mavp=" + int.Parse(r["mavp"].ToString());
                    if (l_maql != 0) sql += " and maql in (" + l_maql + ")";
                    sql += " and madoituong=" + int.Parse(madoituong.SelectedValue.ToString());
                    d.execute_data_mmyy(sql,s_ngay,s_ngay, 30);
                    d.upd_eve_tables(d_mmyy, itable, i_userid, "ins");
                }
            }
        }

        private DataTable load_thuoc(decimal id)
        {
            sql = "select a.stt,0 as sttt,a.mabd,b.ma,trim(b.ten)||' '||b.hamluong as ten,";
            sql += " b.tenhc,b.dang,e.ten as tenkho,c.ten as tennguon,' ' as tennhomcc,";
            sql += " ' ' as handung,' ' as losx,ceiling(a.slyeucau) as soluong,0 as dongia,0 as sotien,0 as giaban,0 as sotienmua,";
            sql += " a.cachdung,a.makho,a.manguon,0 as nhomcc,0 as giamua,a.madoituong,ceiling(a.slyeucau) as soluongcu,to_number('0') as sotiencu ";//gam them field madoituong
            sql += " from " + xxx + ".d_thuocbhytct a," + user + ".d_dmbd b," + user + ".d_dmnguon c," + user + ".d_dmkho e ";
            sql += " where a.mabd=b.id and a.manguon=c.id and a.makho=e.id ";
            sql += " and a.id=" + id + " order by a.stt";
            return d.get_data(sql).Tables[0];
        }

        private void luu_don()
        {
            string ma1 = "", ma2 = "";
            int so = dtct.Select("soluong>0").Length;
            DataTable tmp;
            bool bFound = false;
            foreach (DataRow r in dtct.Select("soluong>0", "mabd,soluong")) ma1 += r["mabd"].ToString().PadLeft(7, '0') + r["soluong"].ToString().Trim() + ",";
            foreach (DataRow r in m.get_data("select * from "+user+".d_theodonll where mabs='" + s_mabs + "' and maicd='" + s_Maicd + "'").Tables[0].Rows)
            {
                tmp = m.get_data("select * from "+user+".d_theodonct where id=" + decimal.Parse(r["id"].ToString())).Tables[0];
                if (so == tmp.Select("soluong>0").Length)
                {
                    ma2 = "";
                    foreach (DataRow r1 in tmp.Select("soluong>0", "mabd,soluong")) ma2 += r1["mabd"].ToString().PadLeft(7, '0') + r1["soluong"].ToString().Trim() + ",";
                    if (ma1 == ma2)
                    {
                        bFound = true; break;
                    }
                }
            }
            if (!bFound)
            {
                decimal id = d.get_id_donthuoc_bacsy();
                d.upd_theodonll(id, s_mabs, s_Maicd, s_Chandoan, m.stt(s_mabs, s_Maicd, id), so, songay.Value);
                int stt = 1;
                foreach (DataRow r in dtct.Select("soluong>0"))
                    d.upd_theodonct(id, int.Parse(r["mabd"].ToString()), decimal.Parse(r["soluong"].ToString()), r["cachdung"].ToString(),stt++,0);
            }
        }

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			bEdit=false;
			try
			{
                cmbMabn.SelectedIndex=i_old;
				if (cmbMabn.Items.Count>0) l_id=decimal.Parse(cmbMabn.SelectedValue.ToString());
				else l_id=0;
			}
			catch{l_id=0;}
            cmbMabn.SelectedValue = l_id.ToString();
            ena_object(false);
            if (butDongy.Enabled && butMoi.Enabled)
            {
                sql = "select distinct f.dongy";
                sql += " from " + xxx + ".d_thuocbhytct a inner join " + user + ".d_dmbd b on a.mabd=b.id ";
                sql += " left join " + user + ".d_dmkho f on a.makho=f.id ";
                sql += " inner join " + user + ".doituong c on a.madoituong=c.madoituong ";
                sql += " where a.id=" + l_id;
                DataTable tmp = d.get_data(sql).Tables[0];
                if (tmp.Rows.Count > 0)
                {
                    if (tmp.Rows[0]["dongy"].ToString() == "1")
                    {
                        label9.Text = "thang";
                        bTayy = false;
                        chkChitiet.Checked = true;
                    }
                    else
                    {
                        bTayy = true;
                        label9.Text = "ngày";
                        chkChitiet.Checked = false;
                    }
                    load_control();
                }
            }
			load_head();			
            load_control();
            tenhc.Enabled = dang.Enabled = false;
			butMoi.Focus();
		}

		private void Filter_cachdung(string ten)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listCachdung.DataSource];
				DataView dv=(DataView)cm.List;
				dv.RowFilter="ten like '%"+ten.Trim()+"%'";
			}
			catch{}
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
            m.writeXml("thongso", "banin_" + ((i_loai == 7) ? "7" : "1"), banin.Value.ToString());
			m.close();this.Close();
		}

		private void cachdung_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==cachdung && bDonthuoc_stc==false)
			{
				Filter_cachdung(cachdung.Text);
				listCachdung.BrowseToBtdkp(cachdung,cachdung,butThem);
			}
		}

		private void cachdung_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
           
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
            {
                if(bDonthuoc_stc==false) listCachdung.Focus();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if (listCachdung.Visible)
                {
                    
                    listCachdung.Focus();
                }
                else SendKeys.Send("{Tab}");
            }
            else if (e.KeyCode == Keys.F2)
            {
                cachdung.Text = m.Viettat(cachdung.Text) + " ";
                SendKeys.Send("{END}");
            }
		}

		private void Filter_mabd(string ma)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listDmbd.DataSource];
				DataView dv=(DataView)cm.List;
				sql="ma like '%"+ma.Trim()+"%'";
                if (!bNgoaitonkho) sql += " and soluong>0";
                if (bThuphi_khongloadthuoc_BHYT && madoituong.SelectedValue.ToString() != "1") sql += " and bhyt=0 ";
                if (bCaptoa_theodanhmuc_duocketoa) sql += " and ketoa=1";
                if (bCaptoa_TheodmloaiDuocphepcaptoa_F45) sql += " and captoa=1 ";//duoc khai bao trong dmphanloai (duoc)
				dv.RowFilter=sql;
			}
			catch{}
		}

		private void Filter_dmbd(string ten)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listDmbd.DataSource];
				DataView dv=(DataView)cm.List;
                sql="(ten like '%"+ten.Trim()+"%'"+" or tenhc like '%"+ten.Trim()+"%')";
                if (!bNgoaitonkho) sql+=" and (soluong>0)";
                if (madoituong.SelectedValue.ToString() == "1" && bLocdichvu) sql += " and (bhyt>0)";
                if (bThuphi_khongloadthuoc_BHYT && madoituong.SelectedValue.ToString() != "1") sql += " and bhyt=0 ";
                if (bCaptoa_theodanhmuc_duocketoa) sql += " and ketoa=1";
                if (bCaptoa_TheodmloaiDuocphepcaptoa_F45) sql += " and captoa=1 ";//duoc khai bao trong dmphanloai (duoc)
				dv.RowFilter=sql;
			}
			catch{}
		}


		private void mabd_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==mabd)
			{
				if (butSua.Enabled) return;
				Filter_mabd(mabd.Text); 
                if (chkChitiet.Checked) listDmbd.Tonkhoct(mabd, tenbd, moilan, madoituong.Location.X, mabd.Location.Y + mabd.Height - 2, mabd.Width + lTen.Width + tenbd.Width + lMabd.Width + lTenhc.Width + tenhc.Width + dang.Width + manguon.Width, mabd.Height + 5);
                else if (bDonthuoc_stc) 
                    listDmbd.Tonkhoct(mabd, tenbd, c1, madoituong.Location.X, mabd.Location.Y + mabd.Height - 2, mabd.Width + lTen.Width + tenbd.Width + lMabd.Width + lTenhc.Width + tenhc.Width + dang.Width + manguon.Width, mabd.Height + 5);
                else if (solan.Enabled) listDmbd.Tonkhoct(mabd, tenbd, solan, madoituong.Location.X, mabd.Location.Y + mabd.Height - 2, mabd.Width + lTen.Width + tenbd.Width + lMabd.Width + lTenhc.Width + tenhc.Width + dang.Width+manguon.Width, mabd.Height + 5);
                else listDmbd.Tonkhoct(mabd,tenbd,soluong,madoituong.Location.X,mabd.Location.Y + mabd.Height-2,mabd.Width+lTen.Width+tenbd.Width+lMabd.Width+lTenhc.Width+tenhc.Width+dang.Width+manguon.Width,mabd.Height+5);
			}
		}

		private void tenbd_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tenbd)
			{
				if (butSua.Enabled) return;
				Filter_dmbd(tenbd.Text);
                if (chkChitiet.Checked) 
                    listDmbd.Tonkhoct(tenbd, mabd, moilan, madoituong.Location.X, mabd.Location.Y + mabd.Height - 2, mabd.Width + lTen.Width + tenbd.Width + lMabd.Width + lTenhc.Width + tenhc.Width + dang.Width + manguon.Width, mabd.Height + 5);
                else if (bDonthuoc_stc) 
                    listDmbd.Tonkhoct(tenbd, mabd, c1, madoituong.Location.X, mabd.Location.Y + mabd.Height - 2, mabd.Width + lTen.Width + tenbd.Width + lMabd.Width + lTenhc.Width + tenhc.Width + dang.Width + manguon.Width, mabd.Height + 5);
                else if (solan.Enabled) 
                    listDmbd.Tonkhoct(tenbd, mabd, solan, madoituong.Location.X, mabd.Location.Y + mabd.Height - 2, mabd.Width + lTen.Width + tenbd.Width + lMabd.Width + lTenhc.Width + tenhc.Width + dang.Width+manguon.Width, mabd.Height + 5);
				else 
                    listDmbd.Tonkhoct(tenbd,mabd,soluong,madoituong.Location.X,mabd.Location.Y + mabd.Height-2,mabd.Width+lTen.Width+tenbd.Width+lMabd.Width+lTenhc.Width+tenhc.Width+dang.Width+manguon.Width,mabd.Height+5);
			}
		}

		private void tenbd_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listDmbd.Focus();
			else if (e.KeyCode==Keys.Enter)
			{
				if (listDmbd.Visible) listDmbd.Focus();
				else SendKeys.Send("{Tab}");
			}
		}

		private void tenbd_Validated(object sender, System.EventArgs e)
		{
			if(!listDmbd.Focused) listDmbd.Hide();
		}

		private void listDmbd_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
			if (e.KeyCode==Keys.Enter)
			{
				try
				{
					r=d.getrowbyid(dtton,"stt="+int.Parse(mabd.Text));
                    if (r != null)
                    {
                        mabd.Text = r["ma"].ToString();
                        tenbd.Text = r["ten"].ToString();
                        tenhc.Text = r["tenhc"].ToString();
                        lbldungluc.Text = r["dungluc"].ToString();
                        dang.Text = r["dang"].ToString();
                        dang.Tag = r["donvidung"].ToString();
                        makho.SelectedValue = r["makho"].ToString();
                        mahc.Text = r["mahc"].ToString().Trim();
                        manguon.SelectedValue = r["manguon"].ToString();
                        txtdongia.Text = (bgiaBHYT_Quidinh) ? r["gia_bh"].ToString() : r["dongia"].ToString();
                        txtgiaban.Text = r["giaban"].ToString();
                        if (!bTayy) solan.Value = Math.Max(1, songay.Value);
                        if(r["mien"].ToString() == "1")//gam 28/09/2011
                        {
                            madoituong.SelectedValue = 3;
                        }
                        //gam 05/10/2011
                        else if (madoituong.SelectedValue.ToString() != i_madoituong.ToString() && !bChonkhoa)//gam 30/11/2011 them dk  && !bChonkhoa
                        {
                            madoituong.SelectedValue = i_madoituong;
                        }
                        //end gam
                        if (madoituong.SelectedValue.ToString() == "1" && !bLocdichvu)
                        {
                            if (d.getrowbyid(dtdmbd, "ma='" + mabd.Text + "' and bhyt>0") == null)
                            {
                                madoituong.SelectedValue = i_tunguyen;
                                madoituong.Update();
                            }
                        }
                        // hien: xu ly truong hop
                        //try
                        //{
                        //    DataRow r1 = d.getrowbyid(dtdmbd, "ma='" + mabd.Text + "'");
                        //    if (r1 != null)
                        //    {
                        //        bHuongtanthan = (s_Huongtamthan.IndexOf(r1["manhom"].ToString()) != -1);
                        //        if (bHuongtanthan)
                        //        {
                        //            if (songay.Value > 10)
                        //            {
                        //                MessageBox.Show(lan.Change_language_MessageText("Thuốc thuộc nhóm hướng tâm thần chỉ được uống tối đa 10 ngay"), "Medisoft");
                        //                songay.Value = 10;
                        //            }
                        //        }
                        //    }
                        //}
                        //catch { }
                        // end hien
                        if (bDonthuoc_stc)
                        {
                            DataRow r1 = d.getrowbyid(dtdmbd, "ma='" + mabd.Text + "'");
                            if (r1 != null)
                            {
                                lblduongdung.Text = r1["duongdung"].ToString().Trim();
                                
                            }
                        }
                        else lbldvt.Text = (dang.Tag.ToString()!="")?dang.Tag.ToString():r["dang"].ToString();//.Text;
                        #region diung
                        if (bDiungthuoc)
                        {
                            bool bFound = false;
                            if (diung.Tag.ToString() != "" && tenhc.Text != "")
                            {
                                int i = 0;
                                string[] s_diung = diung.Tag.ToString().ToLower().Split('+');
                                while (i < s_diung.Length-1)
                                {
                                    if (tenhc.Text.ToLower().IndexOf(s_diung[i].ToString()) != -1)
                                    {
                                        bFound = true;
                                        break;
                                    }
                                    i++;
                                }
                            }
                            if (bFound)
                            {
                                if (MessageBox.Show(lan.Change_language_MessageText("Người bệnh dị ứng thuốc")+" "+" \n" + tenhc.Text.Trim() + "\nBạn có đồng ý thêm vào không !", LibMedi.AccessData.Msg, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes) soluong.Focus();
                                else
                                {
                                    mabd.Text = ""; tenbd.Text = ""; tenhc.Text = ""; dang.Text = ""; mahc.Text = ""; lbldungluc.Text = "";
                                    mabd.Focus();
                                }
                            }
                        }
                        #endregion
                    }
                    else if (bNgoaitonkho)
                    {
                        if (tenbd.Text == "") tenbd.Focus();
                        else tenhc.Focus();
                    }
				}
                catch (Exception ex)
                {
                    if (bNgoaitonkho)
                    {
                        if (tenbd.Text == "") tenbd.Focus();
                        else tenhc.Focus(); 
                    }
                }
			}
		}

		private void cachdung_Validated(object sender, System.EventArgs e)
		{
			if(!listCachdung.Focused) listCachdung.Hide();
		}

		private void cmbMabn_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void cmbMabn_SelectedIndexChanged(object sender, System.EventArgs e)
		{
            if (ActiveControl == cmbMabn || sender == null)
            {
                try
                {
                    l_id = decimal.Parse(cmbMabn.SelectedValue.ToString());
                }
                catch { l_id = 0; }
                if (butDongy.Enabled && butMoi.Enabled)
                {
                    sql = "select distinct f.dongy";
                    sql += " from " + xxx + ".d_thuocbhytct a inner join " + user + ".d_dmbd b on a.mabd=b.id ";
                    sql += " left join " + user + ".d_dmkho f on a.makho=f.id ";
                    sql += " inner join " + user + ".doituong c on a.madoituong=c.madoituong ";
                    sql += " where a.id=" + l_id;
                    DataTable tmp = d.get_data(sql).Tables[0];
                    if (tmp.Rows.Count > 0)
                    {
                        if (tmp.Rows[0]["dongy"].ToString() == "1")
                        {
                            label9.Text = "thang";
                            bTayy = false;
                            chkChitiet.Checked = true;
                        }
                        else
                        {
                            bTayy = true;
                            label9.Text = "ngày";
                            chkChitiet.Checked = false;
                        }
                        load_control();
                    }
                }
                load_head();
            }
		}

		private void load_head()
		{
			try
			{
				r=d.getrowbyid(dtll,"id='"+l_id+"'");
				if (r!=null)
				{
                    l_sotoa = decimal.Parse(r["sotoa"].ToString() == "" ? "0" : r["sotoa"].ToString());//Thuy 30.03.2012
					mabn.Text=r["mabn"].ToString();
					hoten.Text=r["hoten"].ToString();
					tenbs.Text=r["tenbs"].ToString();
					tenpk.Text=r["tenkp"].ToString();
					chandoan.Text=r["chandoan"].ToString();
					maicd.Text=r["maicd"].ToString();
					namsinh.Text=r["namsinh"].ToString();
                    namsinh.Tag = r["ngaysinh"].ToString();
					sothe.Text=r["sothe"].ToString();
					ghichu.Text=r["ghichu"].ToString();
                    songay.Value = decimal.Parse(r["songay"].ToString());
                    makp.Text = r["makp"].ToString();
                    mabs.Text = r["mabs"].ToString();
                    //linh
                    txtHen.Value=decimal.Parse(r["songayhen"].ToString());
                    ngaynghi.Value = decimal.Parse(r["ngaynghi"].ToString());
                    txtNgaynghi_tungay.Text = r["ngaynghi_tungay"].ToString();
                    txtNgaynghi_tungay_Validated(null, null);
                    //end
					//l_maql=decimal.Parse(r["maql"].ToString());
					//if (i_sudungthuoc!=3) load_treeview();
                    if (bDiungthuoc) load_diungthuoc(mabn.Text);
                    b_BNDaravien = false;
                    if (bChonkhoa)
                    {
                        r = m.getrowbyid(dthoten, "mabn='" + mabn.Text + "'");
                        if (r != null)
                        {
                            nam = r["nam"].ToString();
                            s_ngayvv = r["ngay"].ToString();
                            l_maql = decimal.Parse(r["maql"].ToString());
                            l_mavaovien = decimal.Parse(r["mavaovien"].ToString());
                            s_noidkkcb = r["mabv"].ToString();
                            ngay1 = r["ngay1"].ToString();
                            ngay2 = r["ngay2"].ToString();
                            ngay3 = r["ngay3"].ToString();
                            traituyen = int.Parse(r["traituyen"].ToString());
                        }
                        else
                        {
                            b_BNDaravien = true;
                        }
                    }
				}
			}
			catch(Exception ex)
            {
                string s = ex.ToString();
                l_id=0;}
			load_grid();
			ref_text();
            //if (chkThuoc.Checked) load_treeview();
		}

		private bool KiemtraDetail(string tt)
		{
			i_mabd=0;
			if (mabd.Text=="" && tenbd.Text=="")
			{
				if (mabd.Enabled) mabd.Focus();
				else tenbd.Focus();
				return false;
			}
			if ((mabd.Text=="" && tenbd.Text!="") || (mabd.Text!="" && tenbd.Text==""))
			{
				if (mabd.Text=="" && mabd.Enabled)
				{
					MessageBox.Show(lan.Change_language_MessageText("Nhập mã số !"),s_msg);
					mabd.Focus();
					return false;
				}
				else if (tenbd.Text=="")
				{
					MessageBox.Show(lan.Change_language_MessageText("Nhập tên !"),s_msg);
					tenbd.Focus();
					return false;
				}
			}
			r=d.getrowbyid(dtton,"ma='"+mabd.Text+"'");
			if (r==null)
			{
                if (!bNgoaitonkho)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Mã số không hợp lệ !"), s_msg);
                    if (mabd.Enabled) mabd.Focus();
                    else tenbd.Focus();
                    return false;
                }
                else
                {
                    i_mabd = Convert.ToInt32(d.get_id_dmbd);
                    mabd.Text=d.getMabd("d_dmbd",tenbd.Text,i_nhom);
                    d.upd_dmbd(i_mabd, mabd.Text, tenbd.Text, dang.Text, "", -1, -1, -1, -1, 0, 0, 0, 0, tenhc.Text, "", 0, i_nhom, "", 0, 0, 0, 0, 0, 0, "", 0, 0, "", "", 0, "", 0,dang.Text,0);
                    d.execute_data("update " + user + ".d_dmbd set hide=-1 where id=" + i_mabd);
                    updrec(dtton.Rows.Count + 1, i_mabd,mabd.Text,tenbd.Text, dang.Text, tenhc.Text, mahc.Text);
                    makho.SelectedValue=manguon.SelectedValue = "-1";
                }
			}
			else i_mabd=int.Parse(r["id"].ToString());
            if (bDonthuoc_stc)
            {
                if (soluong1.Text == "" || soluong1.Text == "0.00" || soluong1.Text == "0")
                {
                    MessageBox.Show(lan.Change_language_MessageText("Nhập số lượng !"), s_msg);
                    soluong1.Focus();
                    return false;
                }
            }
            else
            {
                if (soluong.Text == "" || soluong.Text == "0.00" || soluong.Text == "0")
                {
                    MessageBox.Show(lan.Change_language_MessageText("Nhập số lượng !"), s_msg);
                    soluong.Focus();
                    return false;
                }
            }
            if (!bDutru_n_thuoc)
            {
                if (d_soluongcu != 0) return true;
                else if (dtct.Select("mabd=" + i_mabd).Length > 0 && tt == "-")
                {
                    MessageBox.Show(tenbd.Text.Trim() + " " + dang.Text.Trim() + " đã nhập !", LibMedi.AccessData.Msg);
                    mabd.Focus();
                    return false;
                }
            }
            if (songay.Value > 10)
            {
                foreach (DataRow rct in dtct.Rows)
                {
                    DataRow r1 = d.getrowbyid(dtdmbd, "id=" + rct["mabd"].ToString());
                    if (r1 != null)
                    {
                        if (r1["tt11"].ToString() == "1")
                        {

                            MessageBox.Show(lan.Change_language_MessageText("Thuốc thuộc nhóm hướng tâm thần chỉ được cho tối đa 10 ngày"), "Medisoft");
                            return false;
                        }
                    }
                }
                if (bDonthuoc_stc) c1_Validated(null, null);
                //else solan_Validated(null, null); //gam comment ngay 27/09/2011 khi click sua so luong tren luoi hai ham solan_Validated va Kiemtradetail goi lan nhau nen CT tu dong close 
            }
			return true;
		}

		private void butThem_Click(object sender, System.EventArgs e)
		{
			
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            if (d.bNhapmaso) mabd.Enabled=true;
			tenbd.Enabled=true;			
			 
             bool b_kt = kiemtra();
            if (b_kt == false) return;
            if (!upd_table(dtct,"-")) return;

          //  bool b_kt = kiemtra();
            if (i_madoituong == 1 && bTongtien_donduyet && iSotien_cancanhbao_khicaptoa > 0) 
            {
                tong();
                if(decimal.Parse(sum.Text) > decimal.Parse(iSotien_cancanhbao_khicaptoa.ToString()))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Tổng số tiền toa thuốc") + ": " + sum.Text + " " + 
                        lan.Change_language_MessageText("vượt quá số tiền qui định") + ": " + iSotien_cancanhbao_khicaptoa.ToString("###,###,###.0#"));
                    //ref_text();
                    //soluong.Focus();
                    //return;
                }
            }
			emp_detail();
            if (bDonthuoc_stc)
            {
                soluong1.Enabled = false;
                cachdung.Enabled = false;
            }
            else if (bTayy) soluong.Enabled = true;
            if (madoituong.Enabled) madoituong.Focus();
			else if (mabd.Enabled) mabd.Focus();
			else tenbd.Focus();
		}

		private void butXoa_Click(object sender, System.EventArgs e)
		{
			if (!upd_table(dsxoa.Tables[0],"+")) return;
			d.delrec(dtct,"stt="+int.Parse(stt.Text));
			dtct.AcceptChanges();
			if (dtct.Rows.Count==0) emp_detail();
			else ref_text();
            tong();//khuyen 12/03/14
		}

        private decimal get_stct()
        {
            //decimal _c1 = (c1.Text != "") ? decimal.Parse(c1.Text) : 0;
            //decimal _c2 = (c2.Text != "") ? decimal.Parse(c2.Text) : 0;
            //decimal _c3 = (c3.Text != "") ? decimal.Parse(c3.Text) : 0;
            //decimal _c4 = (c4.Text != "") ? decimal.Parse(c4.Text) : 0;
            return ParseSoluong(c1) + ParseSoluong(c2) + ParseSoluong(c3) + ParseSoluong(c4);// _c1 + _c2 + _c3 + _c4;
        }

		private bool upd_table(DataTable dt,string tt)
		{
			if (!KiemtraDetail(tt)) return false;
            
            if (madoituong.SelectedValue.ToString() == "1" && !bLocdichvu)
            {
                if (d.getrowbyid(dtdmbd, "id=" + i_mabd + " and bhyt>0")==null)
                {
                    madoituong.SelectedValue = i_tunguyen;
                    madoituong.Update();
                }
            }
            if (bDonthuoc_stc) d_soluong = (soluong1.Text != "") ? decimal.Parse(soluong1.Text) : 0;
			else d_soluong=(soluong.Text!="")?decimal.Parse(soluong.Text):0;
            string s = cachdung.Text;
            string s_ghichuct =  cachdung.Text ;
            if (bDonthuoc_stc)
            {
                if (get_stct() != 0)
                {
                    s = ((c1.Text != "") ? c1.Text : "0") + "^";
                    s += ((c2.Text != "") ? c2.Text : "0") + "^";
                    s += ((c3.Text != "") ? c3.Text : "0") + "^";
                    s += ((c4.Text != "") ? c4.Text : "0");
                }
                if (s == "") s = "0^0^0^0";

            }
            if (ghichuct.Text != "") s_ghichuct = ghichuct.Text;
            if (bDonthuoc_stc==false && s.Trim() != "" && lbldungluc.Text.Trim() != "" && s.IndexOf(lbldungluc.Text.Trim()) < 0) s = s.Trim() + " " + lbldungluc.Text;
            else if (bDonthuoc_stc && lbldungluc.Text.Trim() != "" && s_ghichuct.IndexOf(lbldungluc.Text.Trim()) < 0) s_ghichuct = s_ghichuct.Trim() + " " + lbldungluc.Text;
            //d.updrec_dutruct(tt, dt, int.Parse(stt.Text), madoituong.Text, i_mabd, mabd.Text, tenbd.Text, tenhc.Text, dang.Text, makho.Text, d_soluong, int.Parse(madoituong.SelectedValue.ToString()), int.Parse(makho.SelectedValue.ToString()), s, mahc.Text, int.Parse(manguon.SelectedValue.ToString()), 0, 0, (bDonthuoc_stc) ? ((chk1.Checked) ? 1 : 0) : (bTayy) ? solan.Value : songay.Value, (moilan.Text != "") ? decimal.Parse(moilan.Text) : 1, dtton, i_mabdcu, (txtdongia.Text.Trim() == "") ? 0 : decimal.Parse(txtdongia.Text), (txtgiaban.Text.Trim() == "") ? 0 : decimal.Parse(txtgiaban.Text));//(bTayy)?d_soluong/Math.Max(1,songay.Value):
            
            d.updrec_dutruct(tt, dt, int.Parse(stt.Text), madoituong.Text, i_mabd, mabd.Text, tenbd.Text,
                tenhc.Text, dang.Text, makho.Text, d_soluong, int.Parse(madoituong.SelectedValue.ToString()),
                int.Parse(makho.SelectedValue.ToString()),
                s, mahc.Text, int.Parse(manguon.SelectedValue.ToString()), 0, 0,
                (bDonthuoc_stc) ? ((chk1.Checked) ? 1 : 0) : (bTayy) ? solan.Value : songay.Value,
                (moilan.Text != "") ? ParseSoluong(moilan) : 1, dtton,
                i_mabdcu, (txtdongia.Text.Trim() == "") ? 0 : decimal.Parse(txtdongia.Text),
                (txtgiaban.Text.Trim() == "") ? 0 : decimal.Parse(txtgiaban.Text), s_ghichuct.Trim());//(bTayy)?d_soluong/Math.Max(1,songay.Value):
			return true;
		}

		private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
            i_col = dataGrid1.CurrentCell.ColumnNumber;
            if (butLuu.Enabled && (i_col==7 || i_col==8))
            {
                try
                {                    
                    DataRow r = m.getrowbyid(dtct, "stt=" + int.Parse(stt.Text));
                    d_soluongcu = (r != null) ? decimal.Parse(r["soluong"].ToString()) : 0;
                    stt.Text = dataGrid1[i_row, 0].ToString();
                    if (i_col == 7)
                    {
                        moilan.Text = dataGrid1[i_row, i_col].ToString();
                        solan_Validated(sender, e);

                    }
                    else
                    {
                        soluong.Text = dataGrid1[i_row, i_col].ToString();
                        soluong_Validated(sender, e);
                    }
                }
                catch { }
            }
            i_row = dataGrid1.CurrentRowIndex;
			ref_text();
		}

		private void soluong_Validated(object sender, System.EventArgs e)
		{
			try
			{
				if (!bEdit) return;
				d_soluong=(soluong.Text!="")?decimal.Parse(soluong.Text):0;
				if (d_soluong!=0) soluong.Text=d_soluong.ToString(f_soluong);
                if (mabd.Text != "" && tenbd.Text != "" && bMuangoai_tonkho)
				{
					r=d.getrowbyid(dtton,"ma='"+mabd.Text+"'");
					if (r!=null && r["manguon"].ToString()!="-1")
					{
						i_mabd=int.Parse(r["id"].ToString());
                        if (i_mabdcu != 0 && i_mabdcu != i_mabd)
                        {                            
                            d.updrec_tonkho_tutruc_nguon(dtton, i_makhocu, i_manguoncu, i_mabdcu,0, d_soluongcu, "+");
                            d_soluongcu = 0;
                        }
						d_soluongton=d.get_slton_nguon_tutruc(dtton,int.Parse(makho.SelectedValue.ToString()),i_mabd,int.Parse(manguon.SelectedValue.ToString()),0,d_soluongcu);
						if (d_soluong>d_soluongton)
						{
							MessageBox.Show(lan.Change_language_MessageText("Số lượng xuất lớn hơn số lượng tồn !(")+d_soluongton.ToString()+")",s_msg);
							soluong.Focus();
							return;
						}
					}
				}
				if (d_soluongcu!=0) upd_table(dtct,"-");
			}
			catch{}
		}
		private void butHuy_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (dtll.Rows.Count==0) return;
				l_id=decimal.Parse(cmbMabn.SelectedValue.ToString());
                if (bKhoaso)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Số liệu tháng")+" " + s_mmyy.Substring(0, 2) + " "+lan.Change_language_MessageText("năm")+" " + s_mmyy.Substring(2, 2) + " "+lan.Change_language_MessageText("đã khóa !")+"\n"+lan.Change_language_MessageText("Nếu cần thay đổi thì vào mục khai báo hệ thống"), d.Msg);
                    return;
                }
                if (b_BNDaravien && bChonkhoa)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân này đã ra khoa không cho hủy toa"), "Medisoft");
                    return;
                }
                if (bInchitiet && i_loai!=7)
                {
                    string tenkp = m.inchiphipk(s_ngay, l_mavaovien);
                    if (tenkp != "")
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Đã in chi phí tại") + " " + tenkp + " !", s_msg);
                        return;
                    }
                }
                else
                {
                    if (bInchitiet == false && i_loai == 7 && bToaThuocF5_TuDong_TruTonkho_F44 == false) 
                    {                    
                        bDone = d.get_done_thuocbhyt(s_ngay, l_id);
                        if (bDone)
                        {
                            MessageBox.Show(lan.Change_language_MessageText("Đã cập nhật !"), s_msg);
                            return;
                        }
                    }
                }
                if (i_loaiba == 2)
                {
                    if (m.get_data("select * from " + user + ".benhanngtr where maql=" + l_maql + " and ngayrv is not null").Tables[0].Rows.Count > 0)
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Người bệnh")+" " + s_Hoten + " "+lan.Change_language_MessageText("đã kết thúc điều trị !"), LibMedi.AccessData.Msg);
                        return;
                    }
                }
                if (!bDuyet && !kiemtraDone_paid())//binh 130811
                {
                    MessageBox.Show(lan.Change_language_MessageText("Bạn không thể sửa toa thuốc này, toa thuốc được cập duyệt rồi, phải thu hồi bên dược trước"), "Medisoft");
                    return;
                }
                if (bDuyet && !kiemtra_paid(s_ngay_kham.Substring(0, 10), s_ngay.Substring(0, 10)))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Bạn không thể sửa toa thuốc này, toa thuốc đã thu tiền rồi, phải hoàn trả hoá đơn trước"), "Medisoft");
                    return;
                }
                if (bXemlai && s_ngay != m.ngayhienhanh_server && m.bAdminHethong(i_userid) == false)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Bạn chỉ được phép xem lại toa này chứ không được phép hủy."));
                    return;
                }
				if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý hủy số phiếu này ?"),s_msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
				{
                    //gam 28/10/2011
                    if (bDichvu_vpkb)
                    {
                        itable =  d.tableid(s_mmyy, "bhytcls");
                        foreach (DataRow r2 in d.get_data("select * from " + zzz + ".bhytcls where id=" + l_id).Tables[0].Rows)
                        {
                            d.upd_eve_tables(s_mmyy, itable, i_userid, "del");
                            d.upd_eve_upd_del(s_mmyy, itable, i_userid, "del", d.fields(zzz + ".bhytcls", "id=" + l_id + " and stt=" + int.Parse(r2["stt"].ToString())));
                            d.execute_data("update "+zzz+".v_chidinh set paid=0 where id="+r2["idchidinh"].ToString());
                        }
                        d.execute_data("delete from " + zzz + ".bhytcls where id=" + l_id);

                    }
                    //end gam 28/10/2011
                    if (bDuyet)
                    {
                        if (i_loai != 7)
                        {
                            itable = d.tableid(s_mmyy, "bhytthuoc");
                            foreach (DataRow r1 in d.get_data("select a.*,t.manguon,t.nhomcc,t.handung,t.losx,a.soluong*t.giamua as sotien from " + zzz + ".bhytthuoc a," + zzz + ".d_theodoi t where a.sttt=t.id and a.id=" + l_id).Tables[0].Rows)
                            {
                                d.upd_eve_tables(s_mmyy, itable, i_userid, "del");
                                d.upd_eve_upd_del(s_mmyy, itable, i_userid, "del", d.fields(zzz + ".bhytthuoc", "id=" + l_id + " and stt=" + int.Parse(r1["stt"].ToString())));
                                d.upd_tonkhoct_xuat(d.delete, s_mmyy, decimal.Parse(r1["sttt"].ToString()), int.Parse(r1["makho"].ToString()), int.Parse(r1["manguon"].ToString()), int.Parse(r1["nhomcc"].ToString()), int.Parse(r1["mabd"].ToString()), r1["handung"].ToString(), r1["losx"].ToString(), decimal.Parse(r1["soluong"].ToString()), decimal.Parse(r1["sotien"].ToString()), 0, 0);
                            }
                            itable = d.tableid(s_mmyy, "bhytkb");
                            d.upd_eve_tables(s_mmyy, itable, i_userid, "del");
                            d.upd_eve_upd_del(s_mmyy, itable, i_userid, "del", d.fields(zzz + ".bhytkb", "id=" + l_id));
                            d.execute_data("delete from " + zzz + ".d_chandoan where loai=1 and id=" + l_id);
                            d.execute_data("delete from " + zzz + ".bhytthuoc where id=" + l_id);
                            d.execute_data("delete from " + zzz + ".bhytkb where sobienlai=0 and id=" + l_id);
                        }
                        else
                        {
                            itable = d.tableid(s_mmyy, "d_ngtruct");
                            foreach (DataRow r1 in d.get_data("select a.*,t.manguon,t.nhomcc,t.handung,t.losx,a.soluong*t.giamua as sotien from " + zzz + ".d_ngtruct a," + zzz + ".d_theodoi t where a.sttt=t.id and a.id=" + l_id).Tables[0].Rows)
                            {
                                d.upd_eve_tables(s_mmyy, itable, i_userid, "del");
                                d.upd_eve_upd_del(s_mmyy, itable, i_userid, "del", d.fields(zzz + ".d_ngtruct", "id=" + l_id + " and stt=" + int.Parse(r1["stt"].ToString())));
                                d.upd_tonkhoct_xuat(d.delete, s_mmyy, decimal.Parse(r1["sttt"].ToString()), int.Parse(r1["makho"].ToString()), int.Parse(r1["manguon"].ToString()), int.Parse(r1["nhomcc"].ToString()), int.Parse(r1["mabd"].ToString()), r1["handung"].ToString(), r1["losx"].ToString(), decimal.Parse(r1["soluong"].ToString()), decimal.Parse(r1["sotien"].ToString()), 0, 0);
                            }
                            itable = d.tableid(s_mmyy, "d_ngtrull");
                            d.upd_eve_tables(s_mmyy, itable, i_userid, "del");
                            d.upd_eve_upd_del(s_mmyy, itable, i_userid, "del", d.fields(zzz + ".d_ngtrull", "id=" + l_id));
                            d.execute_data("delete from " + zzz + ".d_chandoan where loai=1 and id=" + l_id);
                            d.execute_data("delete from " + zzz + ".d_ngtruct where id=" + l_id);
                            d.execute_data("delete from " + zzz + ".d_ngtrull where sobienlai=0 and id=" + l_id);
                        }
                    }
                    if (bDichvu_vpkb)//gam 28/10/2011
                    {
                        d.execute_data("delete from " + zzz + ".bhytkb where sobienlai=0 and id=" + l_id);
                    }

                    itable = m.tableid(m.mmyy(s_ngay), "d_thuocbhytll");
                    m.upd_eve_tables(s_ngay, itable, i_userid, "del");
                    m.upd_eve_upd_del(s_ngay, itable, i_userid, "del", m.fields(xxx + ".d_thuocbhytll", "id=" + l_id));
                    itable = m.tableid(m.mmyy(s_ngay), "d_thuocbhytct");
                    foreach (DataRow r1 in dtct.Rows)
                    {
                        m.upd_eve_tables(s_ngay, itable, i_userid, "del");
                        m.upd_eve_upd_del(s_ngay, itable, i_userid, "del", m.fields(xxx + ".d_thuocbhytct", "id=" + l_id + " and stt=" + decimal.Parse(r1["stt"].ToString())));
                        d.upd_tonkhoth_dutru(d.delete, i_nhom, s_mmyy, int.Parse(r1["makho"].ToString()), int.Parse(r1["manguon"].ToString()), int.Parse(r1["mabd"].ToString()), decimal.Parse(r1["soluong"].ToString()));
                    }
                    d.execute_data("delete from " + xxx + ".d_thuocbhytct where id=" + l_id);
                    d.execute_data("delete from " + xxx + ".d_thuocbhytll where id=" + l_id);
					d.delrec(dtll,"id='"+l_id+"'");
					dtll.AcceptChanges();
					cmbMabn.Refresh();
					if (cmbMabn.Items.Count>0) l_id=decimal.Parse(cmbMabn.SelectedValue.ToString());
					else l_id=0;
					load_head();
				}
			}
			catch{}
		}

		private void load_treeview()
		{
			if (l_maql==0 || nam=="") return;
            //linh
            sql = "select to_char(a.ngay,'yyyymmdd')||a.makp as ngay,e.tenkp,a.id,b.mabd,b.makho,sum(b.slyeucau) as soluong,'xxx.' as mmyy,a.maql ";
			sql+=" from xxx.d_thuocbhytll a inner join xxx.d_thuocbhytct b on a.id=b.id left join "+user+".btdkp_bv e on a.makp=e.makp";
            sql += " where a.mabn='" + ((bChonkhoa) ? mabn.Text : s_mabn) + "'";
			if (i_sudungthuoc==2) sql+=" and a.maql="+l_maql;
			sql+=" group by to_char(a.ngay,'yyyymmdd')||a.makp,e.tenkp,a.id,b.mabd,b.makho,a.maql";
			treeView1.Nodes.Clear();
			TreeNode node;
            if (nam.IndexOf(m.mmyy(m.ngayhienhanh_server.Substring(0, 10))) < 0)
            {
                nam = nam + m.mmyy(m.ngayhienhanh_server.Substring(0, 10)) + "+";
            }
			dtngay=(bChonkhoa)?m.get_data_mmyy(sql,s_ngayvv,s_ngay,false).Tables[0]:m.get_data_nam(nam,sql).Tables[0];
			string ngay="";
			DataRow [] dr;
			foreach(DataRow r1 in dtngay.Select("true","ngay desc"))
			{
				if (ngay!=r1["ngay"].ToString()+"["+r1["tenkp"].ToString().Trim()+"]")
				{
                    string _ngay = r1["ngay"].ToString();
					ngay=r1["ngay"].ToString()+"["+r1["tenkp"].ToString().Trim()+"]";
                    node = new TreeNode(ngay.Substring(6, 2) + "/" + ngay.Substring(4, 2) + "/" + ngay.Substring(0, 4) + ngay.Substring(10));
                    string _mmyy = r1["mmyy"].ToString().Trim('.');
                    node.Tag = r1["id"].ToString() + "^" + _mmyy + "^" + r1["maql"].ToString();
                    treeView1.Nodes.Add(node);
					dr=dtngay.Select("ngay='"+_ngay+"'");
					for(int i=0;i<dr.Length;i++)
					{
						r=d.getrowbyid(dtdmbd,"id="+int.Parse(dr[i]["mabd"].ToString()));
                        if (r != null)
                        {
                            node.Nodes.Add(r["ten"].ToString().Trim() + " " + r["hamluong"].ToString().Trim() + "/" + r["tenhc"].ToString().Trim() + " " + r["dang"].ToString().Trim() + " (" + dr[i]["soluong"].ToString().Trim() + ")");
                        }
					}
				}
			}
            //end linh
		}

		private void butCholai_Click(object sender, System.EventArgs e)
		{
			if (mabn.Text =="")
			{
				mabn.Focus();
				return;
			}
            if (nam == "") return;
			decimal idcholai=d.get_cholai_bhyt(nam,mabn.Text,s_makho);
			if (idcholai==0) return;
            get_cholai(idcholai);
		}

        private void get_cholai(decimal idcholai)
        {
            dtct.Clear();
            sql = "select a.songay,b.madoituong,b.makho,b.mabd,b.slyeucau as soluong,b.cachdung, ";
            sql += " c.doituong,e.ten as tenkho,f.ma,f.ten,f.tenhc,f.dang,f.mahc,b.manguon,0 as tutruc,b.solan,b.lan, f.giaban, b.ghichu, f.dongia giamua ";
            sql += " from xxx.d_thuocbhytll a inner join xxx.d_thuocbhytct b on a.id=b.id ";
            sql += " inner join " + user + ".d_dmkho e on b.makho=e.id ";
            sql += " inner join " + user + ".d_dmbd f on b.mabd=f.id ";
            sql += " inner join " + user + ".doituong c on  b.madoituong=c.madoituong ";
            sql += " where  a.id=" + idcholai;
            if (i_madoituong == 1) sql += " and f.bhyt > 0";
            sql += " order by b.stt";
            string s = ""; i_mabdcu = i_mabd = 0;
            decimal sl = 0, d_giamua = 0;
            int i_songaychothuoc = 0;
            int i_songaycu = 0;
            //
            DataSet lds = d.get_data_nam(nam, sql);
            decimal d_tongtien = 0;
            foreach (DataRow dr1 in lds.Tables[0].Rows)
            {
                d_tongtien += decimal.Parse(dr1["soluong"].ToString()) * decimal.Parse(dr1["giamua"].ToString());
            }
            //
            foreach (DataRow r in lds.Tables[0].Rows)
            {
                songay.Value = decimal.Parse(r["songay"].ToString());
                sl = d_soluong = decimal.Parse(r["soluong"].ToString());
                i_songaychothuoc = int.Parse(songay.Value.ToString());
                if (bDonthuoc_stc)
                {
                    i_songaycu = (r["solan"].ToString() == "") ? i_songaychothuoc : int.Parse(r["solan"].ToString());
                    if (i_songaycu <= 1 && d_soluong >= decimal.Parse(r["songay"].ToString()))
                    {
                        i_songaycu = int.Parse(songay.Value.ToString());
                    }
                }
                else i_songaycu = i_songaychothuoc;
                //
                //if (i_madoituong == 1)
                //{
                //    //kiem tra voi so ngay con lai cua the BHYT
                //    i_songaychothuoc = Math.Min(i_songaychothuoc, i_SoNgayConHanBhyt);
                //}
                //if (i_madoituong == 1 && i_SoNgayConHanBhyt > i_SongayCapToaToiDa && i_SongayCapToaToiDa > 0 && d_tongtien > decimal.Parse(iSotien_cancanhbao_khicaptoa.ToString()))
                //{
                //    i_songaychothuoc = Math.Min(i_songaychothuoc, i_SongayCapToaToiDa);
                //}
                //                
                i_mabd = int.Parse(r["mabd"].ToString());

                if (bDonthuoc_stc)
                {
                    d_soluong = (d_soluong / i_songaycu) * i_songaychothuoc;
                    d_soluong = (d_soluong > sl) ? sl : d_soluong;
                    sl = d_soluong;
                }
                d_giamua = (r["giamua"].ToString() == "") ? 0 : decimal.Parse(r["giamua"].ToString());
                if (chkChitiet.Checked && i_songaychothuoc > 1) d_soluong *= Math.Max(1, i_songaychothuoc); //if (chkChitiet.Checked && songay.Value > 1) d_soluong *= Math.Max(1, songay.Value);
                d_soluongton = d.get_slton_nguon_tutruc(dtton, int.Parse(r["makho"].ToString()), i_mabd, int.Parse(r["manguon"].ToString()), int.Parse(r["tutruc"].ToString()), 0);
                if (d_soluong > d_soluongton)
                {
                    s += r["ten"].ToString() + " " + r["dang"].ToString() + " (" + d_soluongton.ToString("###,###,###0.00") + ")\n";
                    if (chkChitiet.Checked && songay.Value > 1) sl = 0;
                    else sl = (d_soluong > d_soluongton) ? d_soluongton : d_soluong;
                }
                d_soluong = Math.Ceiling(d_soluong);
                //if (sl > 0) d.updrec_dutruct("-", dtct, d.get_stt(dtct), r["doituong"].ToString(), i_mabd, r["ma"].ToString(), r["ten"].ToString(), r["tenhc"].ToString(), r["dang"].ToString(), r["tenkho"].ToString(), sl, int.Parse(r["madoituong"].ToString()), int.Parse(r["makho"].ToString()), r["cachdung"].ToString(), r["mahc"].ToString(), int.Parse(r["manguon"].ToString()), int.Parse(r["tutruc"].ToString()), 0, decimal.Parse(r["solan"].ToString()), decimal.Parse(r["lan"].ToString()), dtton, i_mabdcu, 0, decimal.Parse(r["giaban"].ToString()), r["ghichu"].ToString());
                if (sl > 0) d.updrec_dutruct("-", dtct, d.get_stt(dtct), s_doituong, i_mabd, r["ma"].ToString(), r["ten"].ToString(), r["tenhc"].ToString(), r["dang"].ToString(), r["tenkho"].ToString(), sl, i_madoituong, int.Parse(r["makho"].ToString()), r["cachdung"].ToString(), r["mahc"].ToString(), int.Parse(r["manguon"].ToString()), int.Parse(r["tutruc"].ToString()), 0, decimal.Parse(r["solan"].ToString()), decimal.Parse(r["lan"].ToString()), dtton, i_mabdcu, d_giamua, decimal.Parse(r["giaban"].ToString()), r["ghichu"].ToString());
            }
            songay.Value = decimal.Parse(i_songaychothuoc.ToString());            
            try
            {
                txtHen.Value = i_songaychothuoc;//songay.Value;
            }
            catch { }
            if (i_mabd != 0 && s != "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Những mặt hàng sau không đủ trong tồn \n") + s, s_msg);
            }
            tong();
            ref_text();
        }
        private void get_cholai__(decimal idcholai)
        {
            dtct.Clear(); 
            sql = "select a.songay,b.madoituong,b.makho,b.mabd,b.slyeucau as soluong,b.cachdung, ";
            sql += " c.doituong,e.ten as tenkho,f.ma,f.ten,f.tenhc,f.dang,f.mahc,b.manguon,0 as tutruc,b.solan,b.lan ";
            sql += " from xxx.d_thuocbhytll a,xxx.d_thuocbhytct b," + user + ".d_dmkho e," + user + ".d_dmbd f,"+user+".doituong c ";
            sql += " where a.id=b.id and b.makho=e.id and b.mabd=f.id and b.madoituong=c.madoituong and a.id=" + idcholai;
            sql += " order by b.stt";
            string s = ""; i_mabdcu=i_mabd = 0;
            decimal sl;
            foreach (DataRow r in d.get_data_nam(nam, sql).Tables[0].Rows)
            {
                songay.Value = decimal.Parse(r["songay"].ToString());
                i_mabd = int.Parse(r["mabd"].ToString());
                sl=d_soluong = decimal.Parse(r["soluong"].ToString());
                if (chkChitiet.Checked && songay.Value > 1) d_soluong *= Math.Max(1, songay.Value);
                d_soluongton = d.get_slton_nguon_tutruc(dtton, int.Parse(r["makho"].ToString()), i_mabd, int.Parse(r["manguon"].ToString()), int.Parse(r["tutruc"].ToString()), 0);
                if (d_soluong > d_soluongton)
                {
                    s += r["ten"].ToString() + " " + r["dang"].ToString() + " (" + d_soluongton.ToString("###,###,###0.00") + ")\n";
                    if (chkChitiet.Checked && songay.Value > 1) sl = 0;
                    else sl = (d_soluong > d_soluongton) ? d_soluongton : d_soluong;
                }
                if (sl>0) d.updrec_dutruct("-", dtct, d.get_stt(dtct), r["doituong"].ToString(), i_mabd, r["ma"].ToString(), r["ten"].ToString(), r["tenhc"].ToString(), r["dang"].ToString(), r["tenkho"].ToString(),sl, int.Parse(r["madoituong"].ToString()), int.Parse(r["makho"].ToString()), r["cachdung"].ToString(), r["mahc"].ToString(), int.Parse(r["manguon"].ToString()), int.Parse(r["tutruc"].ToString()), 0, decimal.Parse(r["solan"].ToString()), decimal.Parse(r["lan"].ToString()), dtton,i_mabdcu);
            }
            if (i_mabd != 0 && s != "")
                MessageBox.Show(lan.Change_language_MessageText("Những mặt hàng sau không đủ trong tồn \n") + s, s_msg);
            ref_text();
        }

		private void frmBaohiem_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.F8) diung_Click(sender,e);	
			else if (e.KeyCode==Keys.F5) butCholai_Click(sender,e);
			else if (e.KeyCode==Keys.F9) butIn_Click(sender,e);
            else if (e.KeyCode == Keys.F3) butMoi_Click(sender, e);
            else if (e.KeyCode == Keys.F6) butDongy_Click(sender, e);
		}

		private void diung_Click(object sender, System.EventArgs e)
		{
			if (cmbMabn.Items.Count==0) return;
			frmDiungthuoc f=new frmDiungthuoc(m,cmbMabn.Text,hoten.Text,"","");
			f.ShowDialog(this);
			load_diungthuoc(cmbMabn.Text);
		}

		private void load_diungthuoc(string mabn)
		{
            //Thuy 01.08.2012 sửa lấy lên tên hoạt chất dị ứng thuốc để thông báo dị ứng thuốc trong trường hợp khác mã hoạt chất vì một thuốc gồm nhiều hoạt chất
            DataTable dt = m.get_data("select * from " + user + ".d_dmhoatchat where ma in(select mahc from " + user + ".diungthuoc  where mabn='" + mabn + "')").Tables[0];
			string s="";
			foreach(DataRow r in dt.Rows) s+=r["ten"].ToString().Trim()+"+";
			diung.ForeColor=(dt.Rows.Count!=0)?Color.FromArgb(255,0,0):Color.FromArgb(0,0,255);
			diung.Tag=s;
            
		}

		private void get_items(int stt)
		{
			try
			{
				r=d.getrowbyid(dtton,"stt="+stt);
				if (r!=null)
				{
					mabd.Text=r["ma"].ToString();
					tenbd.Text=r["ten"].ToString();
					tenhc.Text=r["tenhc"].ToString();
                    dang.Text = r["dang"].ToString();
                    dang.Tag = r["donvidung"].ToString();
					makho.SelectedValue=r["makho"].ToString();
					mahc.Text=r["mahc"].ToString().Trim();
					manguon.SelectedValue=r["manguon"].ToString();
                    //txtdongia.Text = r["dongia"].ToString().Trim();
                    txtdongia.Text = (bgiaBHYT_Quidinh) ? r["gia_bh"].ToString() : r["dongia"].ToString();
                    txtgiaban.Text = r["giaban"].ToString().Trim();
                    if (!bTayy) solan.Value = Math.Max(1, songay.Value);
                    if (bDonthuoc_stc)
                    {
                        DataRow r1 = d.getrowbyid(dtdmbd, "ma='" + mabd.Text + "'");
                        if (r1 != null)
                            lblduongdung.Text = r1["duongdung"].ToString().Trim();
                    }
                    else lbldvt.Text = (dang.Tag.ToString() != "") ? dang.Tag.ToString() : r["dang"].ToString();//.Text;
					#region diung
					if (bDiungthuoc)
					{
						bool bFound=false;
						if (diung.Tag.ToString()!="" && mahc.Text!="")
						{
							int i=0;
							while (i<diung.Tag.ToString().Length)
							{
								if (mahc.Text.IndexOf(diung.Tag.ToString().Substring(i,7))!=-1)
								{
									bFound=true;
									break;
								}
								i+=7;
							}
						}
						if (bFound)
						{
							if (MessageBox.Show(lan.Change_language_MessageText("Người bệnh dị ứng thuốc")+" \n"+tenhc.Text.Trim()+"\n"+lan.Change_language_MessageText("Bạn có đồng ý thêm vào không !"),LibMedi.AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)==DialogResult.Yes) soluong.Focus();
							else
							{
								mabd.Text="";tenbd.Text="";tenhc.Text="";dang.Text="";mahc.Text="";
								mabd.Focus();
							}
						}
					}
					#endregion
					listDmbd.Hide();
                    if (bDonthuoc_stc) c1.Focus();
                    else if (solan.Enabled) solan.Focus();
                    else soluong.Focus();
				}
			}
			catch{}		
		}

		private void listDmbd_DoubleClick(object sender, System.EventArgs e)
		{
			try
			{
				get_items(int.Parse(listDmbd.Text));
			}
			catch{}
		}

		private void mabd_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listDmbd.Focus();
			else if (e.KeyCode==Keys.Enter)
			{
				sql="ma like '"+mabd.Text.Trim()+"%'";
				DataRow [] dr=dtton.Select(sql);
				if (dr.Length==1)
				{
					mabd.Text=dr[0]["stt"].ToString();
					get_items(int.Parse(mabd.Text));
					if(!listDmbd.Focused) listDmbd.Hide();
                    if (solan.Enabled) solan.Focus();
                    else if (moilan.Enabled) moilan.Focus();
                    else soluong.Focus();
				}
				else
				{
					if (listDmbd.Visible) 
					{
						listDmbd.Focus();
						SendKeys.Send("{Up}");
					}
					else SendKeys.Send("{Tab}");
				}
			}
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
            if (bAdminInlaidonthuoc)
            {
                if (!bAdmin && s_ngay.Substring(0, 10) != m.ngayhienhanh_server.Substring(0, 10))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Bạn không có quyền in lại đơn của ngày trước !"), LibMedi.AccessData.Msg);
                    return;
                }
            }
            string lydo = "", stuoi = "", smaicd = maicd.Text.Trim() + ";", schandoan = chandoan.Text.Trim() + ";", ngayhen = "", ghichuhen = "", tungay = "", denngay = "", noidkkcb = "";
            if ((i_loaiba == 2 && bDieutringtr == false) || i_loaiba == 1) lydo = m.get_lydokham(l_maql).Trim();
            else lydo = m.get_lydokham(s_ngayvao, l_maql).Trim();
            int lanin = 0, isophieu = 0, i_max_lanin = m.iSolanin_toathuoc; ;
            if (bDuyet)
            {
                lanin = d.get_laninkb(s_mmyy, mabn.Text, l_maql, s_ngay.Substring(0,10), i_madoituong);
                isophieu = d.get_sophieu_bhyt_userid(s_mmyy,mabn.Text,l_mavaovien,s_ngay.Substring(0,10),i_madoituong,-1,ngay_reset_phieu38 );
            }
            if (sothe.Text != "")
            {
                sql = "select to_char(a.tungay,'dd/mm/yyyy') as tungay,to_char(a.denngay,'dd/mm/yyyy') as denngay,b.tenbv ";
                sql+=" from " + xxx + ".bhyt a left join "+user+".dmnoicapbhyt b on a.mabv=b.mabv where a.maql=" + l_maql;
                foreach (DataRow r in m.get_data(sql).Tables[0].Rows)
                {
                    tungay = r["tungay"].ToString();
                    denngay = r["denngay"].ToString();
                    noidkkcb = r["tenbv"].ToString();
                    break;
                }
            }
            foreach (DataRow r in m.get_data("select chandoan, maicd from " + xxx + ".cdkemtheo where maql=" + l_maql + " order by stt").Tables[0].Rows)
            {
                smaicd += r["maicd"].ToString() + ";";
                schandoan += r["chandoan"].ToString() + ";";
            }
            //linh -> bỏ truyền trực tiếp từ form
            foreach (DataRow r in m.get_data("select * from " + user + d.mmyy(s_ngay) + ".hen where maql=" + l_maql).Tables[0].Rows)
            {
                DateTime dt = m.StringToDate(s_ngay);
                switch (int.Parse(r["loai"].ToString()))
                {
                    case 1: ngayhen = m.DateToString("dd/MM/yyyy", dt.AddDays(int.Parse(r["songay"].ToString())));
                        break;
                    case 2: ngayhen = m.DateToString("dd/MM/yyyy", dt.AddDays(7 * int.Parse(r["songay"].ToString())));
                        break;
                    case 3: ngayhen = m.DateToString("dd/MM/yyyy", dt.AddMonths(int.Parse(r["songay"].ToString())));
                        break;
                    default: ngayhen = m.DateToString("dd/MM/yyyy", dt.AddYears(int.Parse(r["songay"].ToString())));
                        break;
                }
                ghichuhen = r["ghichu"].ToString();
            }
            //end linh
            stuoi = m.f_get_tuoivao(namsinh.Tag.ToString(), namsinh.Text, s_ngay);
            if (stuoi == "")
            {
                stuoi = m.f_get_tuoivao( s_ngay,s_ngay, l_maql);
            }
            if (namsinh.Text != "" && stuoi == "") 
			{
				int tuoi=DateTime.Now.Year-int.Parse(namsinh.Text);
				stuoi=tuoi.ToString();
			}
            
            string gioitinh = "",tennn="",s_stuoi="",s_ngaysinh="";
            //Tu:25/07/2011 lay them dia chi
            sql = "select a.phai,b.tennn,(a.sonha||','||a.thon||','||c.tenpxa||','||d.tenquan||','||e.tentt) as diachi,"+
                int.Parse(s_ngay.Substring(6, 4)) + "-to_number(a.namsinh,'0000') as tuoi,a.ngaysinh ";
            sql += "from " + user + ".btdbn a," + user + ".btdnn_bv b," + user + ".btdpxa c,";
            sql += "" + user + ".btdquan d," + user + ".btdtt e ";
            sql += "where a.mann=b.mann and a.maphuongxa=c.maphuongxa and a.maqu=d.maqu and a.matt=e.matt ";
            sql += "and a.mabn='" + mabn.Text + "'";
            foreach (DataRow r in m.get_data(sql).Tables[0].Rows)
            {
                gioitinh = (r["phai"].ToString() == "0") ? "Nam" : "Nữ";
                tennn = r["tennn"].ToString();
                s_diachi = r["diachi"].ToString();
                s_stuoi = r["tuoi"].ToString();
                s_ngaysinh = r["ngaysinh"].ToString();
                if (bChonkhoa) s_diachi = r["diachi"].ToString();// gam 31/12/2011 bệnh nhân nội trú cấp toa mua ngoài tự động lấy lại địa chỉ, bệnh nhân phòng khám lấy địa chỉ truyền vào form.
            }
            string s_tuoi = stuoi;
            stuoi = stuoi + "^" + gioitinh;
            try
            {
                stuoi += "^" + (namsinh.Tag.ToString() == "" ? namsinh.Text : namsinh.Tag.ToString());//gam 18/08/2011
            }
            catch { stuoi += "^" + namsinh.Text; }
			DataTable tmp=dtct.Copy();
            if (chkVP.Checked || i_bhyt_inrieng != 0)
            {
                DataSet dstmp, dstmp1;
                if (bDuyet)
                {
                    sql = "select 1 as loai,a.stt,' ' as doituong,b.ma,trim(b.ten)||' '||b.hamluong as ten,nullif(b.tenhc,' ') as tenhc,b.dang,f.ten as tenkho,a.soluong,1 as madoituong,a.makho,nullif(a.cachdung,' ') as cachdung,b.mahc,' ' as diung,t.giamua as manguon,0 as tutruc,0 as idvpkhoa,b.duongdung ";
                    if (i_bhyt_inrieng == 0) sql += ",0 as mabd";
                    else sql += ",case when c.nhomvp=" + i_bhyt_inrieng + " then 1 else 0 end as mabd";
                    if (bGiaban_theodot) sql += ",t.giaban";
                    sql += ",b.giaban";
                    sql += ",0 as solan,g.stt as sttin,g.ten as nhomin,'' as tu,'' as den";
                    sql += ", a.id ";
                    sql += "," + i_loaiba + " as loaiba,0 as sotoa ";
                    sql += ", h.ten as hangsx, i.ten as nuocsx, trim(b.ten) as tenthuoc, trim(b.hamluong) as hamluong, 0 as lanin, 0 as ngaynghi,b.tt10 as gaynghien,b.tt11 as huongthan ";
                    sql += ", c.id as idnhom, c.stt as sttnhom, c.ten as tennhom,'' as loidan ";//binh 290711
                    sql += ",f.dongy,k.dienthoai,k.didong ";//gam 18/10/2011
                    sql += " from xxx.bhytthuoc a inner join " + user + ".d_dmbd b on a.mabd=b.id inner join " + user + ".d_dmnhom c on " +
                        "b.manhom=c.id inner join " + user + ".d_dmkho f on a.makho=f.id inner join xxx.d_theodoi t on a.sttt=t.id";
                    sql += " inner join " + user + ".d_nhomin g on c.nhomin=g.id left join " + user + ".d_dmhang h on b.mahang=h.id left join " +
                        user + ".d_dmnuoc i on b.manuoc=i.id inner join xxx.bhytkb j on a.id=j.id left join " + user + ".dmbs k on j.mabs=k.ma ";
                    sql += " where a.id=" + l_id ;
                }
                else
                {
                    sql = "select 1 as loai,a.stt,' ' as doituong,b.ma,trim(b.ten)||' '||b.hamluong as ten,nullif(b.tenhc,' ') as tenhc,b.dang,f.ten as tenkho,a.slyeucau as soluong,h.madoituong,a.makho,nullif(a.cachdung,' ') as cachdung,b.mahc,' ' as diung,a.manguon,0 as tutruc,0 as idvpkhoa,b.duongdung ";
                    if (i_bhyt_inrieng == 0) sql += ",0 as mabd";
                    else sql += ",case when c.nhomvp=" + i_bhyt_inrieng + " then 1 else 0 end as mabd";
                    //if (bGiaban_theodot) sql += ",t.giaban";
                    sql += ",b.giaban"; 
                    sql += ",a.solan,g.stt as sttin,g.ten as nhomin,";
                    sql += "to_char(h.ngay,'dd/mm/yyyy') as tu,to_char(h.ngay+case when h.songay=0 then 1 else " + songay.Value + " end-1,'dd/mm/yyyy') as den";
                    sql += ", a.id ";
                    sql += ",h.loaiba,h.sotoa ";
                    sql += ", i.ten as hangsx, j.ten as nuocsx ,trim(b.ten) as tenthuoc, trim(b.hamluong) as hamluong, h.lanin, h.ngaynghi, b.tt10 as gaynghien,b.tt11 as huongthan ";
                    sql += ", c.id as idnhom, c.stt as sttnhom, c.ten as tennhom,a.ghichu as loidan ";//binh 290711
                    sql += ",f.dongy,k.dienthoai,k.didong ";//gam 18/10/2011
                    sql += " from xxx.d_thuocbhytct a," + user + ".d_dmbd b," + user + ".d_dmnhom c," + user + ".d_dmkho f ";
                    //if (bGiaban_theodot)
                    //{
                    //    sql += ",xxx.d_theodoi t ";// a.mabd=t.mabd
                    //}
                    sql += "," + user + ".d_nhomin g,xxx.d_thuocbhytll h, " + user + ".d_dmhang i, " + user + ".d_dmnuoc j,"+user+".dmbs k ";
                    sql += " where a.id=h.id and a.mabd=b.id and b.manhom=c.id and a.makho=f.id and c.nhomin=g.id and b.mahang=i.id(+) "+
                    "and b.manuoc=j.id(+) and k.ma=h.mabs and a.id=" + l_id;
                    //if (bGiaban_theodot)
                    //{
                    //    sql += " and a.mabd=t.mabd ";
                    //}
                }
                if (chkVP.Checked)
                {
                    int stt = dtct.Rows.Count;
                    sql += " union all ";
                    sql += " select 2 as loai,to_number(a.oid,'999999999999')+" + stt + " as stt,' ' as doituong,b.ma,trim(b.ten) as ten,' ' as tenhc,b.dvt as dang,' ' as tenkho,a.soluong,a.madoituong,0 as makho,' ' as cachdung,' ' as mahc,' ' as diung,";
                    if (chkDongia.Checked) sql += "a.dongia+a.vattu as manguon,";
                    else sql += "0 as manguon,";
                    sql += "0 as tutruc,0 as idvpkhoa,' ' as duongdung ";
                    if (i_bhyt_inrieng == 0) sql += ",0 as mabd";
                    else sql += ",case when d.ma=" + i_bhyt_inrieng + " then 1 else 0 end as mabd";
                    sql += ",a.dongia as giaban";
                    sql += ",0 as solan,0 as sttin,'' as nhomin,'' as tu,'' as den";
                    sql += ", a.id ";
                    sql += ", a.loaiba, 0 as sotoa,null as hangsx, null as nuocsx,trim(b.ten) as tenthuoc, ' ' as hamluong, 0 as lanin, 0 as ngaynghi,0 as gaynghien,0 as huongthan ";
                    sql += ", to_number('0') as idnhom, to_number('0') as sttnhom, '' as tennhom, '' as loidan ";//binh 290711
                    sql += ",to_number('0') as dongy,'' as dienthoai,'' as didong ";//gam 08/11/2011
                    sql += " from xxx.v_chidinh a," + user + ".v_giavp b," + user + ".v_loaivp c," + user + ".v_nhomvp d ";
                    sql += " where a.mavp=b.id and b.id_loai=c.id and c.id_nhom=d.ma and a.maql=" + l_maql;
                }
                dstmp = d.get_data_mmyy(sql,s_ngaydonthuoc,s_ngay,true);
                dstmp1 = dstmp.Copy();
                dstmp.Clear();
                dstmp.Merge(dstmp1.Tables[0].Select("true", "loai,stt"));
                tmp = dstmp.Tables[0];
            }
            else
            {
                sql = "select a.stt,c.doituong,0 as mabd,b.ma,trim(b.ten)||' '||b.hamluong as ten,nullif(b.tenhc,' ') as tenhc,b.dang,f.ten as tenkho,";
                sql += " a.slyeucau as soluong,h.madoituong,a.makho,nullif(a.cachdung,' ') as cachdung,b.mahc,' ' as diung,a.manguon,";
                sql += " 0 as tutruc,0 as idvpkhoa,a.solan,a.lan,b.dongia,a.slyeucau*b.dongia as sotien,b.giaban,";
                sql += " a.slyeucau*b.giaban as sotienban,g.stt as sttin,g.ten as nhomin,";
                sql += " to_char(h.ngay,'dd/mm/yyyy') as tu,to_char(h.ngay+case when h.songay=0 then 1 else " + songay.Value + " end-1,'dd/mm/yyyy') as den";
                sql += ", a.id, h.loaiba,h.sotoa ";
                sql += ", i.ten as hangsx, j.ten as nuocsx,trim(b.ten) as tenthuoc, trim(b.hamluong) as hamluong, h.lanin, h.ngaynghi,b.tt10 as gaynghien,b.tt11 as huongthan ";
                sql += ", d.id as idnhom, d.stt as sttnhom, d.ten as tennhom,a.ghichu as loidan ";//binh 290711
                sql += ",f.dongy,b.duongdung,k.dienthoai,k.didong ";
                sql += " from xxx.d_thuocbhytct a inner join " + user + ".d_dmbd b on a.mabd=b.id ";
                sql += " left join " + user + ".d_dmkho f on a.makho=f.id ";
                sql += " inner join " + user + ".doituong c on a.madoituong=c.madoituong ";
                sql += " left join " + user + ".d_dmnhom d on b.manhom=d.id ";
                sql += " left join " + user + ".d_nhomin g on d.nhomin=g.id ";
                sql += " inner join xxx.d_thuocbhytll h on a.id=h.id ";
                sql += " left join " + user + ".d_dmhang i on b.mahang=i.id ";
                sql += " left join " + user + ".d_dmnuoc j on b.manuoc=j.id ";
                sql += " left join " + user + ".dmbs k on h.mabs=k.ma ";
                sql += " where a.id=" + l_id + " order by a.stt";
                tmp = m.get_data_mmyy(sql,s_ngaydonthuoc,s_ngay,true).Tables[0];
            }
            tmp.Columns.Add("Image", typeof(byte[]));
            tmp.Columns.Add("ngayhen", typeof(String));
            tmp.Columns.Add("ghichuhen", typeof(String));
            tmp.Columns.Add("tungay", typeof(String));
            tmp.Columns.Add("denngay", typeof(String));
            tmp.Columns.Add("noidkkcb", typeof(String));
            tmp.Columns.Add("tenuser", typeof(String));
            //tmp.Columns.Add("lanin", typeof(decimal));
            tmp.Columns.Add("sophieu", typeof(decimal));
            tmp.Columns.Add("nguoinha", typeof(String));//linh
            tmp.Columns.Add("giuong", typeof(String));
            tmp.Columns.Add("maicd", typeof(String));
            tmp.Columns.Add("mach", typeof(decimal));
            tmp.Columns.Add("nhietdo", typeof(decimal));
            tmp.Columns.Add("huyetap", typeof(string));
            tmp.Columns.Add("cannang", typeof(decimal));
            tmp.Columns.Add("chieucao", typeof(decimal));
            tmp.Columns.Add("tennn", typeof(String));
            tmp.Columns.Add("ttmat", typeof(String));
            tmp.Columns.Add("c16", typeof(int)).DefaultValue = 0;
            //linha
            tmp.Columns.Add("ngaynghi_songay", typeof(int)).DefaultValue = (int)ngaynghi.Value;
            tmp.Columns.Add("ngaynghi_tungay", typeof(string)).DefaultValue = txtNgaynghi_tungay.Text.Trim().Trim('/').Trim();
            tmp.Columns.Add("ngaynghi_denngay", typeof(string)).DefaultValue = txtNgaynghi_denngay.Text.Trim().Trim('/').Trim();
            tmp.Columns.Add("songayhen", typeof(int)).DefaultValue = (int)txtHen.Value;
            tmp.Columns.Add("makp", typeof(String)); 
            tmp.Columns.Add("thangtuoi", typeof(String)); 

            //thêm số tháng
            if (int.Parse(s_stuoi) <= 6 && s_ngaysinh != "")
            {
                long songay = m.songay(m.StringToDateTime(s_ngay), DateTime.Parse(s_ngaysinh), 0);
                long sothang = songay / 30;
                foreach (DataRow r in tmp.Rows) r["thangtuoi"] = sothang.ToString();
            } 
            string s_ngayhen = "";
            if (txtHen.Value != 0)
            {
                string s_ngayhen_kham_trongdon = "";
                if (s_ngay_kham == "")
                {
                    s_ngayhen_kham_trongdon = m.Ngayhienhanh;
                }
                else
                {
                    s_ngayhen_kham_trongdon = s_ngay_kham;
                }
                DateTime dtngayhen = m.StringToDate(s_ngayhen_kham_trongdon);
                DateTime dtngayhendenngay = dtngayhen.AddDays((double)txtHen.Value);
                s_ngayhen = dtngayhendenngay.ToString("dd/MM/yyyy");
            }
            if (s_ngayhen == "") s_ngayhen = ngayhen;
            //endlinh
            if (File.Exists("..//..//..//chuky//" + mabs.Text + ".bmp"))
            {
                fstr = new FileStream("..//..//..//chuky//" + mabs.Text + ".bmp", FileMode.Open, FileAccess.Read);
                image = new byte[fstr.Length];
                fstr.Read(image, 0, System.Convert.ToInt32(fstr.Length));
                fstr.Close();
                foreach (DataRow r1 in tmp.Rows) r1["Image"] = image;
            }
            string nguoinha = "",zzz=user;
            if (i_loaiba == 3 || i_loaiba == 4 || i_loaiba == 2) zzz = user + m.mmyy(s_ngay);
            foreach (DataRow r in m.get_data("select * from " + zzz + ".quanhe where maql=" + l_maql).Tables[0].Rows)
            {
                nguoinha = r["quanhe"].ToString().Trim()+": "+ r["hoten"].ToString();
                break;
            }
            decimal mach = 0, nhietdo = 0, cannang = 0, chieucao = 0;
            string huyetap = "";
            bool bFound = false;
            foreach (DataRow r in m.get_data("select * from " + zzz + ".dausinhton where maql=" + l_maql).Tables[0].Rows)
            {
                mach = decimal.Parse(r["mach"].ToString());
                nhietdo=decimal.Parse(r["nhietdo"].ToString());
                cannang=decimal.Parse(r["cannang"].ToString());
                chieucao = decimal.Parse(r["chieucao"].ToString());
                huyetap = r["huyetap"].ToString();
                bFound = true;
                break;
            }
            if (!bFound)
            {
                foreach (DataRow r in m.get_data("select * from " + zzz + ".dausinhton where maql=" + l_maql).Tables[0].Rows)
                {
                    mach = decimal.Parse(r["mach"].ToString());
                    nhietdo = decimal.Parse(r["nhietdo"].ToString());
                    cannang = decimal.Parse(r["cannang"].ToString());
                    chieucao = decimal.Parse(r["chieucao"].ToString());
                    huyetap = r["huyetap"].ToString();
                    bFound = true;
                    break;
                }
            }
            string _giuong = "";
            if (bChonkhoa)
            {
                DataRow r2 = m.getrowbyid(dthoten, "mabn='" + mabn.Text + "'");
                if (r2 != null) _giuong = r2["giuong"].ToString();
            }
            if (bDuyet == false && tmp.Rows.Count > 0) lanin = int.Parse(tmp.Rows[0]["lanin"].ToString())+1;
            if (m.bAdminHethong(i_userid) == false && i_max_lanin > 0 && lanin > i_max_lanin)
            {
                MessageBox.Show(lan.Change_language_MessageText("Số lần in vượt quá số lần in đã qui định."));
                return;
            }
            else
            {
                m.execute_data("update " + user + s_mmyy + ".d_thuocbhytll set lanin=" + lanin + " where id=" + l_id);
            }
            //
            if (bXemToaCu)
            {
                DialogResult dlg = MessageBox.Show(lan.Change_language_MessageText("Bạn có muốn in lại toa cũ ngày "+s_ngaydonthuoc+"?"),"Medisoft THIS", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dlg == DialogResult.No)
                {
                    return;
                }
            }
            //
            string s_ttmat = f_get_ttmat(s_makp, l_maql);
            //linha
            // hien: Bệnh nhân dưới 6t- lây thông tin người thân.
            //string s_quahe = "";
            //try
            //{
            //    DateTime dt1 = m.StringToDate(s_ngay_kham);
            //    if (namsinh.Text.Trim() != "" && dt1.Year - int.Parse(namsinh.Text) <= 6) //if (int.Parse(s_tuoi) <= 6)
            //    {
            //        DataTable dt11 = m.get_data("select * from " + xxx + ".quanhe where maql=" + l_maql).Tables[0];
            //        s_quahe = " (" + dt11.Rows[0]["hoten"].ToString() + " - " + dt11.Rows[0]["quanhe"].ToString() + ")";
            //    }
            //}
            //catch
            //{ }
            // end hien
            //endlinh
            foreach (DataRow r1 in tmp.Rows)
            {
                r1["ngayhen"] = s_ngayhen;//linha
                r1["ghichuhen"] = ghichuhen;
                r1["tungay"] = tungay;
                r1["denngay"] = denngay;
                r1["noidkkcb"] = noidkkcb;
                r1["tenuser"] = s_user;
                r1["lanin"] = lanin;
                r1["sophieu"] = isophieu;
                r1["nguoinha"] = nguoinha;//linha
                r1["giuong"] = _giuong;
                r1["maicd"] = smaicd;
                r1["mach"] = mach;
                r1["nhietdo"] = nhietdo;
                r1["cannang"] = cannang;
                r1["chieucao"] = chieucao;
                r1["huyetap"] = huyetap;
                r1["tennn"] = tennn;
                r1["ttmat"] = s_ttmat;
                r1["ngaynghi_songay"] = (int)ngaynghi.Value;
                r1["ngaynghi_tungay"] = txtNgaynghi_tungay.Text.Trim().Trim('/').Trim();
                r1["ngaynghi_denngay"] = txtNgaynghi_denngay.Text.Trim().Trim('/').Trim();
                r1["songayhen"] = (int)txtHen.Value;
                r1["makp"] = s_makp;
                if (r1["cachdung"].ToString().IndexOf('^') != -1)
                {
                    r1["c16"] = 1;// hien
                }
                else
                {
                    r1["c16"] = 0;
                }
            }
            
            string tenfile=(System.IO.File.Exists("..//..//..//report//d_donthuocb.rpt"))?"d_donthuocb.rpt":"d_donthuoc.rpt";
            //if (!bTayy) tenfile = (System.IO.File.Exists("..//..//..//report//d_donthuoc_thang.rpt")) ? "d_donthuoc_thang.rpt" : tenfile ;
            tenfile = (chkDongy.Checked ? "d_donthuoc_thang.rpt" : tenfile);//gam 04/11/2011
            if (!System.IO.File.Exists("..\\..\\..\\Report\\" + tenfile))
            {
                MessageBox.Show(lan.Change_language_MessageText("Không tìm thấy report " + tenfile));
                return;
            }
            //end gam04/11/2011
            if (!bTayy)
            {
                //sap xep in toa thuoc theo hang ngang dua vao field stt_in
                int i = 1, i_stt = 0, j = 0, i_count = tmp.Rows.Count;
                tmp.Columns.Add("stt_in", typeof(decimal)).DefaultValue = 0;
                tmp.Columns.Add("ten1");
                tmp.Columns.Add("sl1", typeof(decimal)).DefaultValue = 0;
                tmp.Columns.Add("ten2");
                tmp.Columns.Add("sl2", typeof(decimal)).DefaultValue = 0;
                string sl="",ten="";
                foreach (DataRow r in tmp.Rows)
                {                    
                    //i = int.Parse(r["stt"].ToString());
                    if (i <= i_count / 2 + 1) i_stt = i + i - 1;
                    else { i_stt = i - (i_count / 2) + j; j++; }
                    r["stt_in"] = i_stt;
                    sl = (i_stt % 2 == 0) ? "sl2" : "sl1";
                    ten = (i_stt % 2 == 0) ? "ten2" : "ten1";
                    r[sl] = r["soluong"].ToString();
                    r[ten]=r["ten"].ToString();
                    i += 1;
                }
                DataRow r1;
                foreach (DataRow r in tmp.Select("ten1<>''"))
                {
                    i = int.Parse(r["stt_in"].ToString());
                    r1 = m.getrowbyid(tmp, "ten2<>'' and stt_in=" + (i + 1));
                    if (r1 != null)
                    {
                        r["ten2"] = r1["ten2"].ToString();
                        r["sl2"] = r1["sl2"].ToString();
                    }
                }
                foreach (DataRow r in tmp.Rows)
                    if (r["ten1"].ToString() == "") r.Delete();
                tmp.AcceptChanges();                
            }
            if (chkXML.Checked)
            {
                if (!System.IO.Directory.Exists("..//..//dataxml")) System.IO.Directory.CreateDirectory("..//xml");
                tmp.WriteXml("..//..//dataxml//bhyt.xml", XmlWriteMode.WriteSchema);
            }
            // hien sua: sothe=sothe+"^"+ngaynghi
			if (chkXem.Checked)
			{//linh
                //dllReportM.frmReport f = new dllReportM.frmReport(m, tmp, tenfile, hoten.Text , stuoi, sothe.Text + "^" + ngaynghi.Value.ToString(), schandoan + " ;" + s_Chandoan, s_diachi.Replace(",,", ",").Trim().Trim(',') + "^" + s_cholam.Trim(), tenbs.Text, dtct.Rows.Count.ToString() + "^" + songay.Value.ToString(), mabn.Text + "^" + s_ngay + "^" + s_ngay_kham, lydo.Replace("\r\n", " ") + "^" + ghichu.Text.Replace("\r\n", " "), s_doituong + "^" + s_Tenkp.Replace("\r\n", " ") + "^" + s_trieuchung.Replace("\r\n", " ") + "^" + lydo.Replace("\r\n", " ") + "^" + ghichu.Text.Replace("\r\n", " "), banin.Value);
                dllReportM.frmReport f = new dllReportM.frmReport(m, tmp, tenfile, hoten.Text,stuoi, sothe.Text + "^" + ngaynghi.Value.ToString(), schandoan, s_diachi.Replace(",,", ",").Trim().Trim(',') + "^" + s_cholam.Trim(), tenbs.Text, dtct.Rows.Count.ToString() + "^" + songay.Value.ToString(), mabn.Text + "^" + s_ngay + "^" + s_ngay_kham, lydo.Replace("\r\n", " ") + "^" + ghichu.Text.Replace("\r\n", " "), s_doituong + "^" + s_Tenkp.Replace("\r\n", " ") + "^" + s_trieuchung.Replace("\r\n", " ") + "^" + lydo.Replace("\r\n", " ") + "^" + ghichu.Text.Replace("\r\n", " "), banin.Value);//gam 22/08/2011 ;
				f.ShowDialog(this);
			}
            else print.Printer(m, tmp, tenfile, hoten.Text + nguoinha, stuoi, sothe.Text + "^" + ngaynghi.Value.ToString(), schandoan + " ;" + s_Chandoan, s_diachi.Replace(",,", ",").Trim().Trim(',') + "^" + s_cholam.Trim(), tenbs.Text, dtct.Rows.Count.ToString() + "^" + songay.Value.ToString(), mabn.Text + "^" + s_ngay + "^" + s_ngay_kham, lydo.Replace("\r\n", " ") + "^" + ghichu.Text.Replace("/r/n", " "), s_doituong + "^" + s_Tenkp + "^" + s_trieuchung.Replace("\r\n", " ") + "^" + lydo.Replace("\r\n", " ") + "^" + ghichu.Text.Replace("\r\n", " "), 1, Convert.ToInt16(banin.Value));
            //end linh
		}

		private void butHen_Click(object sender, System.EventArgs e)
		{
		}

		private void ghichu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");		
		}

        private void solan_Validated(object sender, EventArgs e)
        {
            gc_cachdung();
        }

        private void gc_cachdung()
        {
            if (moilan.Text != "")
            {
                if (bTayy)// && dang.Text.Trim()==lbldvt.Text.Trim())
                {
                    r = d.getrowbyid(dtton, "ma='" + mabd.Text + "'");
                    if (r != null)
                    {
                        DataRow r1 = d.getrowbyid(dtdmbd, "id=" + int.Parse(r["id"].ToString()));
                        if (r1 != null)
                            cachdung.Text = r1["duongdung"].ToString().Trim() + " " + lan.Change_language_MessageText("ngày") + " " + solan.Value.ToString() + " " + lan.Change_language_MessageText("lần , lần") + " " + moilan.Text.ToString().Trim() + " " + ((r1["donvidung"].ToString() != "") ? r1["donvidung"].ToString().Trim() : r1["dang"].ToString());
                    }
                }
                //decimal sl = Math.Max((!bTayy)?1:songay.Value,1) * solan.Value * decimal.Parse(moilan.Text);
                decimal sl = Math.Max((!bTayy) ? 1 : songay.Value, 1) * solan.Value * ParseSoluong(moilan);
                if (dang.Text.Trim() == lbldvt.Text.Trim() || dang.Text.Trim().ToLower() == lbldvt.Text.Trim().ToLower()) soluong.Text = sl.ToString(f_soluong);
                else soluong.Text = "";
                soluong.Refresh();
                soluong_Validated(null, null);
            }
        }

        private void chkChon_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == chkChon && donthuoc.SelectedIndex != -1) get_don();
        }

        private void donthuoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == donthuoc && donthuoc.SelectedIndex != -1)
            {
                dtct.Clear();
                get_don();
            }
        }

        private void get_don()
        {
            if (chkChon.Checked)
            {
                decimal id_donthuoc = decimal.Parse(donthuoc.SelectedValue.ToString());
                if (id_donthuoc != 0)
                {
                    songay.Value = decimal.Parse(dtdon.Rows[donthuoc.SelectedIndex]["songay"].ToString());
                    string s_ten = "";
                    decimal i_mabd = 0;
                    bool bFound = false;
                    decimal _soluong = 0;
                    sql = "select a.mabd,b.ma,trim(b.ten)||' '||b.hamluong as ten,b.hamluong,b.dang,b.mahc,b.tenhc,a.soluong,a.cachdung from "+user+".d_theodonct a,"+user+".d_dmbd b";
                    sql += " where a.mabd=b.id and a.id=" + id_donthuoc;
                    DataRow r1, r2;
                    foreach (DataRow r in d.get_data(sql).Tables[0].Rows)
                    {
                        bFound = false;
                        i_mabd = decimal.Parse(r["mabd"].ToString());
                        _soluong = decimal.Parse(r["soluong"].ToString());
                        sql = "soluong>=" + _soluong + " and id=" + i_mabd;
                        r1 = d.getrowbyid(dtton, sql);
                        if (r1 == null)
                        {
                            sql = "soluong>=" + _soluong + " and ten='" + r["ten"].ToString() + "' and dang='" + r["dang"].ToString() + "'";
                            r2 = d.getrowbyid(dtton, sql);
                            if (r2 != null)
                            {
                                bFound = true;
                                r["mabd"] = r2["id"].ToString();
                                r["ten"] = r2["ten"].ToString();
                                r["dang"] = r2["dang"].ToString();
                                r["ma"] = r2["ma"].ToString();
                                r["mahc"] = r2["mahc"].ToString();
                                r["tenhc"] = r2["tenhc"].ToString();
                                i_mabd = decimal.Parse(r2["id"].ToString());
                            }
                            else //tuong duong
                            {
                                foreach (DataRow r3 in d.get_data("select mabd,soluong from "+user+".d_dmbdtd where id=" + i_mabd).Tables[0].Rows)
                                {
                                    _soluong = decimal.Parse(r["soluong"].ToString()) * decimal.Parse(r3["soluong"].ToString());
                                    sql = "id=" + int.Parse(r3["mabd"].ToString()) + " and soluong>=" + d_soluong;
                                    r2 = d.getrowbyid(dtton, sql);
                                    if (r2 != null)
                                    {
                                        r["mabd"] = r2["id"].ToString();
                                        r["ten"] = r2["ten"].ToString();
                                        r["dang"] = r2["dang"].ToString();
                                        r["ma"] = r2["ma"].ToString();
                                        r["mahc"] = r2["mahc"].ToString();
                                        r["tenhc"] = r2["tenhc"].ToString();
                                        r["soluong"] = _soluong;
                                        i_mabd = decimal.Parse(r2["id"].ToString());
                                        bFound = true;
                                        break;
                                    }
                                }
                                //hoatchat - hamluong - dvt 
                                if (!bFound && r["tenhc"].ToString() != "")
                                {
                                    sql = "soluong>=" + _soluong + " and tenhc='" + r["tenhc"].ToString() + "' and dang='" + r["dang"].ToString() + "' and hamluong='" + r["hamluong"].ToString() + "'";
                                    r2 = d.getrowbyid(dtton, sql);
                                    if (r2 != null)
                                    {
                                        r["mabd"] = r2["id"].ToString();
                                        r["ten"] = r2["ten"].ToString();
                                        r["dang"] = r2["dang"].ToString();
                                        r["ma"] = r2["ma"].ToString();
                                        r["mahc"] = r2["mahc"].ToString();
                                        r["tenhc"] = r2["tenhc"].ToString();
                                        i_mabd = decimal.Parse(r2["id"].ToString());
                                    }
                                }
                            }
                        }
                        else bFound = true;
                        if (!bFound) s_ten += r["ten"].ToString().Trim() + "\n";
                        else d.updrec_dutruct("-", dtct, m.get_stt(dtct), "", int.Parse(r["mabd"].ToString()), r["ma"].ToString(), r["ten"].ToString(), r["tenhc"].ToString(), r["dang"].ToString(), (makho.SelectedIndex != -1) ? makho.Text : "", decimal.Parse(r["soluong"].ToString()), i_madoituong, int.Parse(r1["makho"].ToString()), r["cachdung"].ToString(), r["mahc"].ToString(), int.Parse(r1["manguon"].ToString()), 0, 0, solan.Value, (moilan.Text != "") ? decimal.Parse(moilan.Text) : 1, dtton,0);
                    }
                    if (s_ten.Length > 0) MessageBox.Show(lan.Change_language_MessageText("Những mặt hàng sau không đủ tồn")+"\n" + s_ten, LibMedi.AccessData.Msg);
                    ref_text();
                }
                else MessageBox.Show(lan.Change_language_MessageText("Không có trong danh mục !"), LibMedi.AccessData.Msg);
            }
            else dtct.Clear();
        }

        private void treeView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F7 && butLuu.Enabled)
            {
                try
                {
                    int p = s_ngaymakp.LastIndexOf("]");
                    if (p > 0) s_ngaymakp = s_ngaymakp.Substring(0, p+1);
                    DataRow [] r1 = dtngay.Select("substring(ngay,1,8)='" + s_ngaymakp.Substring(6, 4) + s_ngaymakp.Substring(3, 2) + s_ngaymakp.Substring(0, 2) + "' and tenkp='" + s_ngaymakp.Substring(11, s_ngaymakp.Length - 12) + "'");
                    for (int i = 0; i < r1.Length; i++)
                    {
                        if (s_makho != "")
                        {
                            if (s_makho.IndexOf(r1[i]["makho"].ToString().PadLeft(3, '0')) != -1)
                            {
                                get_cholai(decimal.Parse(r1[i]["id"].ToString()));
                                break;
                            }
                        }
                        else
                        {
                            get_cholai(decimal.Parse(r1[i]["id"].ToString()));
                            break;
                        }
                    }
                }
                catch { }
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Action == TreeViewAction.ByMouse || e.Action == TreeViewAction.ByKeyboard)
            {
                try
                {
                    s_ngaymakp = e.Node.FullPath.Trim();
                    //linh
                    treeView1.Tag = e.Node.Tag;
                    decimal tmp_maql = 0,temp_id=0;
                    if (e.Node != null)
                    {
                        string _tag = e.Node.Tag.ToString().Trim('^');
                        string[] s_tag = _tag.Split('^');
                        temp_id = decimal.Parse(s_tag[0]);
                        if (temp_id != l_id && butBoqua.Enabled)
                        {
                            butBoqua_Click(null,null);
                        }
                        l_id = decimal.Parse(s_tag[0]);// e.Node.Tag.ToString());
                        tmp_maql = decimal.Parse(s_tag[2]);
                        if (tmp_maql == l_maql)
                        {
                            butSua.Enabled = true;
                            butHuy.Enabled = true;
                            cmbMabn.SelectedValue = l_id;
                            cmbMabn_SelectedIndexChanged(null, null);
                        }
                        else
                        {
                            butSua.Enabled = false;
                            butHuy.Enabled = false;
                        }
                        
                    }
                    //edn linh
                    s_ngaydonthuoc = e.Node.Text;
                }
                catch { s_ngaymakp = "";}
                if (!butLuu.Enabled)
                {
                    bXemToaCu = true;
                    load_grid();
                }
            }
        }

        private void kiemtraton(MaskedTextBox.MaskedTextBox  txt)
        {
            try
            {
                bkhongdu_soluong = false;
                if (!bEdit) return;
                d_soluong = (soluong1.Text != "") ? decimal.Parse(soluong1.Text) : 0;
                soluong1.Text = d_soluong.ToString("#,###,##0.00");
                if (mabd.Text != "" && tenbd.Text != "" && bMuangoai_tonkho)
                {
                    r = d.getrowbyid(dtton, "ma='" + mabd.Text + "'");
                    if (r != null && r["manguon"].ToString()!="-1")
                    {
                        i_mabd = int.Parse(r["id"].ToString());
                        if (i_mabdcu != 0 && i_mabdcu != i_mabd)
                        {
                            d.updrec_tonkho_tutruc_nguon(dtton, i_makhocu, i_manguoncu, i_mabdcu, 0, d_soluongcu, "+");
                            d_soluongcu = 0;
                        }
                        d_soluongton = d.get_slton_nguon_tutruc(dtton, int.Parse(makho.SelectedValue.ToString()), i_mabd, int.Parse(manguon.SelectedValue.ToString()), 0, d_soluongcu);
                        if (d_soluong > d_soluongton)
                        {
                            MessageBox.Show(lan.Change_language_MessageText("Số lượng xuất lớn hơn số lượng tồn !(") + d_soluongton.ToString() + ")", s_msg);
                            txt.Focus();
                            bkhongdu_soluong = true;
                            return;
                        }
                    }
                }
                if (d_soluongcu != 0) upd_table(dtct, "-");
            }
            catch { }
        }

        private void c1_Validated(object sender, EventArgs e)
        {
            get_soluong(c1);
            if (bkhongdu_soluong)
            {
                if (c1.Text.Trim() != "" && c1.Text.Trim() != "0") c1.Focus();
                else if (c2.Text.Trim() != "" && c2.Text.Trim() != "0") c2.Focus();
                else if (c3.Text.Trim() != "" && c3.Text.Trim() != "0") c3.Focus();
                else if (c4.Text.Trim() != "" && c4.Text.Trim() != "0") c4.Focus();
            }
        }
        
        private void c2_Validated(object sender, EventArgs e)
        {
            get_soluong(c1);
            if (bkhongdu_soluong)
            {
                if (c1.Text.Trim() != "" && c1.Text.Trim() != "0") c1.Focus();
                else if (c2.Text.Trim() != "" && c2.Text.Trim() != "0") c2.Focus();
                else if (c3.Text.Trim() != "" && c3.Text.Trim() != "0") c3.Focus();
                else if (c4.Text.Trim() != "" && c4.Text.Trim() != "0") c4.Focus();
            }
        }

        private void c3_Validated(object sender, EventArgs e)
        {
            get_soluong(c1);
            if (bkhongdu_soluong)
            {
                if (c1.Text.Trim() != "" && c1.Text.Trim() != "0") c1.Focus();
                else if (c2.Text.Trim() != "" && c2.Text.Trim() != "0") c2.Focus();
                else if (c3.Text.Trim() != "" && c3.Text.Trim() != "0") c3.Focus();
                else if (c4.Text.Trim() != "" && c4.Text.Trim() != "0") c4.Focus();
            }
        }

        private void c4_Validated(object sender, EventArgs e)
        {
            get_soluong(c1);
            if (bkhongdu_soluong)
            {
                if (c1.Text.Trim() != "" && c1.Text.Trim() != "0") c1.Focus();
                else if (c2.Text.Trim() != "" && c2.Text.Trim() != "0") c2.Focus();
                else if (c3.Text.Trim() != "" && c3.Text.Trim() != "0") c3.Focus();
                else if (c4.Text.Trim() != "" && c4.Text.Trim() != "0") c4.Focus();
            }
        }
        private decimal ParseSoluong(MaskedTextBox.MaskedTextBox text)
        {
            decimal sl1 = 0;
            string[] arr;
            if (text.Text.Trim() != "")
            {
                arr = text.Text.Trim().Split('/');
                if (arr.Length == 2)
                {
                    try
                    {
                        int tu = int.Parse(arr[0].Trim() == "" ? "0" : arr[0].Trim());
                        int mau= int.Parse(arr[1].Trim() == "" ? "1" : arr[1].Trim());
                        sl1 = (decimal)(tu*(1M)/mau );
                    }
                    catch { }
                }
                else
                    if (arr.Length > 0)
                    {
                        try
                        {
                            sl1 = decimal.Parse(arr[0].Trim() == "" ? "0" : arr[0].Trim());
                        }
                        catch { }
                    }
            }
            return sl1;
        }
        private void get_soluong(MaskedTextBox.MaskedTextBox txt)
        {
            decimal sl = 0;// ((c1.Text != "") ? decimal.Parse(c1.Text) : 0) + ((c2.Text != "") ? decimal.Parse(c2.Text) : 0) + ((c3.Text != "") ? decimal.Parse(c3.Text) : 0) + ((c4.Text != "") ? decimal.Parse(c4.Text) : 0);
            sl = ParseSoluong(c1) + ParseSoluong(c2) + ParseSoluong(c3) + ParseSoluong(c4);
            soluong1.Enabled = sl == 0;
            cachdung.Enabled = sl == 0;
            chk1.Enabled = sl != 0;
            chk2.Enabled = sl != 0;
            sl *= Math.Max((chkChitiet.Checked) ? 1 : songay.Value, 1);
            soluong1.Text = sl.ToString();
            soluong1.Refresh();
            kiemtraton(txt);            
        }

        private void chk1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == chk1 && chk1.Checked) chk2.Checked = false;
        }

        private void chk2_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == chk2 && chk2.Checked) chk1.Checked = false;
        }

        private void soluong1_Validated(object sender, EventArgs e)
        {
            try
            {
                if (!bEdit) return;
                d_soluong = (soluong1.Text != "") ? decimal.Parse(soluong1.Text) : 0;
                soluong1.Text = d_soluong.ToString("#,###,##0.00");
                if (mabd.Text != "" && tenbd.Text != "" && bMuangoai_tonkho)
                {
                    r = d.getrowbyid(dtton, "ma='" + mabd.Text + "'");
                    if (r != null && r["manguon"].ToString()!="-1")
                    {
                        i_mabd = int.Parse(r["id"].ToString());
                        if (i_mabdcu != 0 && i_mabdcu != i_mabd)
                        {
                            d.updrec_tonkho_tutruc_nguon(dtton, i_makhocu, i_manguoncu, i_mabdcu, 0, d_soluongcu, "+");
                            d_soluongcu = 0;
                        }
                        d_soluongton = d.get_slton_nguon_tutruc(dtton, int.Parse(makho.SelectedValue.ToString()), i_mabd, int.Parse(manguon.SelectedValue.ToString()), 0, d_soluongcu);
                        if (d_soluong > d_soluongton)
                        {
                            MessageBox.Show(lan.Change_language_MessageText("Số lượng xuất lớn hơn số lượng tồn !(") + d_soluongton.ToString() + ")", s_msg);
                            soluong1.Focus();
                            return;
                        }
                    }
                }
                if (d_soluongcu != 0) upd_table(dtct, "-");
            }
            catch { }
        }

        private void mabn_Validated(object sender, System.EventArgs e)
        {
            if (mabn.Text == "" || mabn.Text.Trim().Length < 3) return;
            if (mabn.Text.Trim().Length != 8) mabn.Text = mabn.Text.Substring(0, 2) + mabn.Text.Substring(2).PadLeft(6, '0');
            r = m.getrowbyid(dthoten, "mabn='" + mabn.Text + "'");
            DataRow rct = m.getrowbyid(dtll, "mabn='" + mabn.Text + "'");
            //Khuong 03/11. Neu la don thuoc dich vu va duoc check option F43 thi duoc cap nhieu toa trong ngay
            if (rct != null&&!(i_loai==7&&bDondichvu_capnhieulantrongngay))
            {
                MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân "+mabn.Text+" đã cấp toa."));
                mabn.Visible = false;
                cmbMabn.Visible = true;
                cmbMabn.SelectedValue = rct["id"].ToString();
                cmbMabn_SelectedIndexChanged(sender,e);
                ena_object(false);
                butSua.Focus();
                listHoten.Hide();
                listBS.Hide();
                return;
                
            }
            if (r != null)
            {
                hoten.Text = r["hoten"].ToString();
                hoten.Tag = r["phai"].ToString();
                namsinh.Text = r["namsinh"].ToString();
                namsinh.Tag = r["ngaysinh"].ToString(); 
                i_madoituong = int.Parse(r["madoituong"].ToString());
                //madoituong.SelectedValue = i_madoituong.ToString(); Sửa cho đơn thuốc nội trú không load madoituong theo madoituong của bn vì đơn thuốc nội trú chỉ cho đtuong thu phí
                sothe.Text = r["sothe"].ToString();
                l_maql = decimal.Parse(r["maql"].ToString());
                l_mavaovien = decimal.Parse(r["mavaovien"].ToString());
                mabs.Text = r["mabs"].ToString();
                s_Maicd = maicd.Text = r["maicd"].ToString();
                tenpk.Text = s_Tenkp;
                tenbs.Text = r["tenbs"].ToString();
                s_Chandoan = chandoan.Text = r["chandoan"].ToString();
                nam = r["nam"].ToString();
                s_ngayvv = r["ngay"].ToString();
                s_noidkkcb = r["mabv"].ToString();
                ngay1 = r["ngay1"].ToString();
                ngay2 = r["ngay2"].ToString();
                ngay3 = r["ngay3"].ToString();
                traituyen = (r["traituyen"].ToString() == "") ? 0 : int.Parse(r["traituyen"].ToString());
                load_don();
            }
            else { hoten.Text = ""; hoten.Tag = ""; l_maql = 0; namsinh.Text = ""; sothe.Text = ""; }
        }

        private void hoten_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up) listHoten.Focus();
            else if (e.KeyCode == Keys.Enter)
            {
                if (listHoten.Visible) listHoten.Focus();
                else SendKeys.Send("{Tab}");
            }
        }

        private void hoten_TextChanged(object sender, System.EventArgs e)
        {
            if (this.ActiveControl == hoten)
            {
                Filt_hoten(hoten.Text);
                if (tenbs.Enabled)
                    listHoten.BrowseToDanhmuc(hoten, mabn, tenbs);
                else
                    listHoten.BrowseToDanhmuc(hoten, mabn, songay);
            }
        }

        private void Filt_hoten(string ten)
        {
            try
            {
                CurrencyManager cm = (CurrencyManager)BindingContext[listHoten.DataSource];
                DataView dv = (DataView)cm.List;
                dv.RowFilter = "hoten like '%" + ten.Trim() + "%'";
            }
            catch { }
        }

        private void listHoten_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) mabn_Validated(null, null);
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
                if (songay.Enabled)
                    listBS.BrowseToICD10(tenbs, mabs, songay, tenpk.Location.X, tenbs.Location.Y + tenbs.Height, tenbs.Width + tenpk.Width + lblbacsy.Width - 10, tenbs.Height);
                else
                    listBS.BrowseToICD10(tenbs, mabs, ghichu, tenpk.Location.X, tenbs.Location.Y + tenbs.Height, tenbs.Width + tenpk.Width + lblbacsy.Width - 10, tenbs.Height);
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

        private void madoituong_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (madoituong.Items.Count > 0 && madoituong.SelectedIndex == -1) madoituong.SelectedIndex = 0;
                SendKeys.Send("{Tab}");
            }
        }

        private void chkThuoc_CheckedChanged(object sender, EventArgs e)
        {
            //linh
            //if (this.ActiveControl == chkThuoc)
            //{
                m.writeXml("thongso", "xemthuoc", (chkThuoc.Checked)?"1":"0");
                if (chkThuoc.Checked) load_treeview();
                else treeView1.Nodes.Clear();
            //}
            //end
        }

        private void tenhc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void butTuongtac_Click(object sender, EventArgs e)
        {
            testc.clsTuongtac t = new testc.clsTuongtac();
            bool b_tuongtac=t.kiemtra_tuongtac(dtct, i_nhom);
        }

        private void butGoi_Click(object sender, EventArgs e)
        {
            if (mabn.Text == "")
            {
                mabn.Focus();
                return;
            }
            frmChongoi f = new frmChongoi(m, -1, i_nhom);
            f.ShowDialog();
            if (f.dt.Rows.Count > 0)
            {
                if (!bTayy && songay.Value == 0) songay.Value = 1;
                string s = ""; i_mabd = 0; 
                DataRow r1;
                decimal sl;
                string s_hanghet = "";
                foreach (DataRow r in f.dt.Rows)
                {
                    i_mabd = int.Parse(r["mabd"].ToString());
                    sl = Math.Max(songay.Value, 1) * decimal.Parse(r["soluong"].ToString());
                    d_soluong = Math.Max(songay.Value, 1) * decimal.Parse(r["soluong"].ToString());
                    r1 = m.getrowbyid(dtton, "id=" + i_mabd);
                    if (r1 != null)
                    {
                        d_soluongton = d.get_slton_nguon(dtton, int.Parse(r1["makho"].ToString()), i_mabd, int.Parse(r1["manguon"].ToString()), 0);
                        if (d_soluong > d_soluongton)
                        {
                            s += r["ten"].ToString() + " " + r["dang"].ToString() + " (" + d_soluongton.ToString("###,###,###0.000") + ")\n";
                            if (chkChitiet.Checked && songay.Value > 1) sl = 0;
                            else sl = (d_soluong > d_soluongton) ? d_soluongton : d_soluong;
                        }
                        if (bMabd_doituong && r1["madoituong"].ToString() != "0") madoituong.SelectedValue = r1["madoituong"].ToString();
                        else
                        {
                            if (i_madoituong == 5 || i_loaiba==1)
                            {
                                madoituong.SelectedValue = 2;
                            }
                            else
                            {
                                madoituong.SelectedValue = i_madoituong;
                            }
                        }
                        d.updrec_dutruct("-", dtct, d.get_stt(dtct), madoituong.Text, i_mabd, r["ma"].ToString(), r["ten"].ToString(), r["tenhc"].ToString(), r["dang"].ToString(), r1["tenkho"].ToString(), sl, int.Parse(madoituong.SelectedValue.ToString()), int.Parse(r1["makho"].ToString()), r["cachdung"].ToString(), r["mahc"].ToString(), int.Parse(r1["manguon"].ToString()), 1, 0, (bTayy) ? 1 : songay.Value, (bTayy) ? 1 : decimal.Parse(r["soluong"].ToString()), dtton, 0);
                    }
                    else
                    {
                        s_hanghet += r["ma"].ToString() + "-" + r["ten"].ToString() + "[" + r["mabd"].ToString() + "]; ";
                    }
                }
                if (i_mabd != 0 && s != "")
                    MessageBox.Show(lan.Change_language_MessageText("Những mặt hàng sau không đủ trong tồn \n") + s, s_msg);
                else if (s_hanghet!="")
                    MessageBox.Show(lan.Change_language_MessageText("Những mặt hàng sau không có trong kho \n") + s_hanghet, s_msg);
                ref_text();
            }
        }

        private void chkChitiet_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == chkChitiet) m.writeXml("thongso", "ctcapdon", (chkChitiet.Checked) ? "1" : "0");
        }

        private void ghichu_TextChanged(object sender, EventArgs e)
        {
            if (ghichu.Text == "\r\n") SendKeys.Send("{Tab}");
            if (this.ActiveControl == ghichu && dtLoidan.Rows.Count>0)
            {
                Filter(ghichu.Text, listLoidan); //Khuong 16/11/2011
                
                listLoidan.BrowseToDanhmuc(ghichu, songay, ghichu.Width);
            }
        }

        private void Filter(string ten, LibList.List list)
        {
            try
            {
                CurrencyManager cm = (CurrencyManager)BindingContext[list.DataSource];
                DataView dv = (DataView)cm.List;
                dv.RowFilter = "ten like '%" + ten.Trim() + "%'";
            }
            catch { }
        }

        private void huyet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == huyet && huyet.SelectedIndex != -1)
                ghichu.Text = dthuyet.Rows[huyet.SelectedIndex]["noidung"].ToString();
        }

        private void chkHuyet_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == chkHuyet && huyet.SelectedIndex != -1) huyet.Text = dthuyet.Rows[huyet.SelectedIndex]["noidung"].ToString();
        }

        private void tim_TextChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == tim || sender ==null)
            {
                CurrencyManager cm = (CurrencyManager)BindingContext[cmbMabn.DataSource];
                DataView dv = (DataView)cm.List;
                if (tim.Text != "")
                    dv.RowFilter = "hoten like '%" + tim.Text.Trim() + "%' or mabn like '%" + tim.Text.Trim() + "%'";
                else
                    dv.RowFilter = "";
            }
        }

        private void tim_Enter(object sender, EventArgs e)
        {
            tim.Text = "";
        }

        private bool bDongy(string makho,int dongy)
        {
            sql = "select * from " + user + ".d_dmkho where hide=0 and dongy="+dongy;
            if (makho != "") sql += " and id in (" + makho.Substring(0, makho.Length - 1) + ")";
            return m.get_data(sql).Tables[0].Rows.Count > 0;
        }

        private void songay_ValueChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == songay && !bTayy)
            {
                foreach (DataRow r in dtct.Rows)
                {
                    r["solan"] = Math.Max(1,songay.Value);
                    r["soluong"] = decimal.Parse(r["solan"].ToString()) * decimal.Parse(r["lan"].ToString());
                }
                ref_text();
            }
            //linh
            txtHen.Value = songay.Value;
            if (songay.Value > (decimal)i_songaytoathuoccancanhbao && i_songaytoathuoccancanhbao > 0)
            {
                MessageBox.Show(lan.Change_language_MessageText("Đơn thuốc đã vượt quá") + songay.Value.ToString() + lan.Change_language_MessageText("ngày thuốc qui định"), "Medisoft");
            }
            //end
            // hien: xu ly truong hop
            try
            {
                //if (mabd.Text != "")//linh
                //{
                if (songay.Value > 10)
                {
                    //foreach (DataRow rct in dtct.Rows)
                    //{
                    //    DataRow r1 = d.getrowbyid(dtdmbd, "id=" + r["mabd"].ToString());
                    //    if (r1 != null)
                    //    {
                    //        //bHuongtanthan = (s_Huongtamthan.IndexOf(r1["manhom"].ToString()) != -1);
                    //        //if (bHuongtanthan)
                    //        if (r1["tt11"].ToString() == "1")
                    //        {

                    //            MessageBox.Show(lan.Change_language_MessageText("Thuốc thuộc nhóm hướng tâm thần chỉ được cho tối đa 10 ngày"), "Medisoft 2007");
                    //            songay.Value = 10;
                    //            break;
                    //        }
                    //    }
                    //}
                    if (bDonthuoc_stc) c1_Validated(null, null);
                    else solan_Validated(null, null);
                }
            }
            catch { }
            // end hien
        }

        private void chkLuuin_CheckedChanged(object sender, EventArgs e)
        {
            //linh
            //if (this.ActiveControl == chkLuuin) 
                //m.writeXml("thongso", "bhluuin", (chkLuuin.Checked) ? "1" : "0");
            //end linh
        }

        private void chkDoituong_Click(object sender, EventArgs e)
        {
            if (!(!this.butLuu.Enabled || this.bChonkhoa))
            {
                this.madoituong.Enabled = this.chkDoituong.Checked;
            }
        }

        private void f_load_option()
        {
            iSotien_cancanhbao_khicaptoa = m.iSotien_cancanhbao_khicaptoa;
            bToaThuocF5_TuDong_TruTonkho_F44 = m.bToaThuocF5_TuDong_TruTonkho_F44;
            bCaptoa_TheodmloaiDuocphepcaptoa_F45 = m.bCaptoa_TheodmloaiDuocphepcaptoa_F45;
            bgiaBHYT_Quidinh = m.bGia_bh_quydinh;
        }
        private void f_capnhat_db()
        {
            string tmp_mmyy = m.mmyy(s_ngay);
            sql = "select lanin from " + user + tmp_mmyy + ".d_thuocbhytll where 1=2";
            DataSet lds = m.get_data(sql);
            if (lds == null || lds.Tables.Count <= 0)
            {
                sql = "alter table " + user + tmp_mmyy + ".d_thuocbhytll add lanin numeric (3) default 0";
                m.execute_data(sql);
            }
        }
        private string f_get_ttmat(string m_makp, decimal m_maql)
        {
            string m_makp_bo = m.f_get_makp_bo(m_makp);
            string s_mat = "";
            if (m_makp_bo == "25")
            {
                foreach (DataRow r in m.get_data("select * from " + xxx + ".ttmat where maql=" + m_maql).Tables[0].Rows)
                {
                    s_mat = (r["mp"].ToString().Trim() != "") ? "TL mắt phải: " + r["mp"].ToString().Trim() + "/10," : "";
                    s_mat += (r["mt"].ToString().Trim() != "") ? "TL mắt trái: " + r["mt"].ToString().Trim() + "/10," : "";
                    s_mat += (r["nhanapp"].ToString().Trim() != "") ? "Nhãn áp mắt phải: " + r["nhanapp"].ToString().Trim() + ", " : "";
                    s_mat += (r["nhanapt"].ToString().Trim() != "") ? "Nhãn áp mắt trái: " + r["nhanapt"].ToString().Trim() + ", " : "";
                    break;
                }
            }
            return s_mat.Trim(',');
        }

        private void c1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && e.KeyChar != '/')
            {
                e.Handled = true;
            }
        }

        private void c2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && e.KeyChar != '/')
            {
                e.Handled = true;
            }
        }

        private void c3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && e.KeyChar != '/')
            {
                e.Handled = true;
            }
        }

        private void c4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && e.KeyChar != '/')
            {
                e.Handled = true;
            }
        }

        private void moilan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && e.KeyChar != '/')
            {
                e.Handled = true;
            }
        }

        private void ghichuct_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }
        //linha
        private void frmBaohiem_FormClosing(object sender, FormClosingEventArgs e)
        {
            m.writeXml("thongso", "bhluuin", (chkLuuin.Checked) ? "1" : "0");
            m.writeXml("thongso", chkQuanlyngaynghiphep.Name, (chkQuanlyngaynghiphep.Checked) ? "1" : "0");
            m.writeXml("thongso", chkCanhbaotoathuoclonhon10ngay.Name, (chkCanhbaotoathuoclonhon10ngay.Checked) ? "1" : "0");
        }
        //endlinh
        private void txtdongia_VisibleChanged(object sender, EventArgs e)
        {
            lblGiamua.Visible = txtdongia.Visible;
        }

        private void txtgiaban_VisibleChanged(object sender, EventArgs e)
        {
            lblGiaban.Visible = txtgiaban.Visible;
        }

        private void txtNgaynghi_tungay_Validated(object sender, EventArgs e)
        {
            string s_ngaynghi = txtNgaynghi_tungay.Text.Trim();
            s_ngaynghi = s_ngaynghi.Trim('/');
            s_ngaynghi = s_ngaynghi.Trim();
            if (s_ngaynghi == "" && ngaynghi.Value > 0)
            {
                MessageBox.Show(lan.Change_language_MessageText("Vui lòng nhập ngày bắt đầu nghỉ phép"), "Medisoft");
                txtNgaynghi_tungay.Focus();
            }
            else if (s_ngaynghi != "" && ngaynghi.Value > 0)
            {
                DateTime dtngay = m.StringToDate(s_ngaynghi);
                DateTime dtdenngay = dtngay.AddDays((double)ngaynghi.Value - 1d);
                txtNgaynghi_denngay.Text = m.DateToString("dd/MM/yyyy", dtdenngay);
            }
        }

        private void ngaynghi_ValueChanged(object sender, EventArgs e)
        {
            if (ActiveControl == ngaynghi)
            {
                txtNgaynghi_tungay.Enabled = ngaynghi.Value > 0;
                if (ngaynghi.Enabled && txtNgaynghi_tungay.Text.Replace("/", "").Trim() == "")
                {
                    txtNgaynghi_tungay.Text = m.Ngayhienhanh;
                }
                if (txtNgaynghi_tungay.Text.Replace("/", "").Trim() != "")
                {
                    txtNgaynghi_tungay_Validated(null, null);
                }
            }
        }

        private void chkQuanlyngaynghiphep_CheckedChanged(object sender, EventArgs e)
        {
            ngaynghi.Enabled = (chkQuanlyngaynghiphep.Checked && butLuu.Enabled);
        }
        public int SoNgayHen
        {
            get { return (int)txtHen.Value; }
            set { txtHen.Value = value; }
        }

        private void p2_VisibleChanged(object sender, EventArgs e)
        {
            p2.Enabled = p2.Visible;
        }

        private void p1_VisibleChanged(object sender, EventArgs e)
        {
            p1.Enabled = p1.Visible;
        }

        private void treeView1_DoubleClick(object sender, EventArgs e)
        {
            if (treeView1.Tag != null)
            {
                string _tag = treeView1.Tag.ToString();
                if (_tag != "")
                {
                    try
                    {
                        string[] tag = _tag.Split('^');
                        decimal d_id = decimal.Parse(tag[0]);
                        string _mmyy = tag[1];
                        _mmyy = _mmyy.Replace(user, "");
                        if (butLuu.Enabled)
                        {
                            DialogResult dlg = MessageBox.Show("Bạn có đồng ý cho lại không?", "Medisoft THIS", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                            if (dlg == DialogResult.Yes)
                            {
                                get_cholai(d_id, _mmyy);
                            }
                        }
                    }
                    catch { }
                }
            }
        }
        private void get_cholai(decimal idcholai, string _mmyy)
        {
            if (m.bMmyy(_mmyy))
            {
                string usermmyy = user + _mmyy;
                dtct.Clear();
                sql = "select a.songay,b.madoituong,b.makho,b.mabd,b.slyeucau as soluong,b.cachdung, ";
                sql += " c.doituong,e.ten as tenkho,f.ma,f.ten,f.tenhc,f.dang,f.mahc,b.manguon,0 as tutruc,b.solan,b.lan ";
                sql += " from " + usermmyy + ".d_thuocbhytll a," + usermmyy + ".d_thuocbhytct b," + user + ".d_dmkho e," + user + ".d_dmbd f," + user + ".doituong c ";
                sql += " where a.id=b.id and b.makho=e.id and b.mabd=f.id and b.madoituong=c.madoituong and a.id=" + idcholai.ToString()+" and b.madoituong = "+ i_madoituong;
                sql += " order by b.stt";
                string s = ""; i_mabdcu = i_mabd = 0;
                decimal sl;
                foreach (DataRow r in d.get_data(sql).Tables[0].Rows)
                {
                    songay.Value = decimal.Parse(r["songay"].ToString());
                    i_mabd = int.Parse(r["mabd"].ToString());
                    sl = d_soluong = decimal.Parse(r["soluong"].ToString());
                    if (chkChitiet.Checked && songay.Value > 1) d_soluong *= Math.Max(1, songay.Value);
                    d_soluongton = d.get_slton_nguon_tutruc(dtton, int.Parse(r["makho"].ToString()), i_mabd, int.Parse(r["manguon"].ToString()), int.Parse(r["tutruc"].ToString()), 0);
                    if (d_soluong > d_soluongton)
                    {
                        s += r["ten"].ToString() + " " + r["dang"].ToString() + " (" + d_soluongton.ToString("###,###,###0.00") + ")\n";
                        if (chkChitiet.Checked && songay.Value > 1) sl = 0;
                        else sl = (d_soluong > d_soluongton) ? d_soluongton : d_soluong;
                    }
                    if (sl > 0) d.updrec_dutruct("-", dtct, d.get_stt(dtct), r["doituong"].ToString(), i_mabd, r["ma"].ToString(), r["ten"].ToString(), r["tenhc"].ToString(), r["dang"].ToString(), r["tenkho"].ToString(), sl, int.Parse(r["madoituong"].ToString()), int.Parse(r["makho"].ToString()), r["cachdung"].ToString(), r["mahc"].ToString(), int.Parse(r["manguon"].ToString()), int.Parse(r["tutruc"].ToString()), 0, decimal.Parse(r["solan"].ToString()), decimal.Parse(r["lan"].ToString()), dtton, i_mabdcu);
                }
                if (i_mabd != 0 && s != "")
                {
                    MessageBox.Show(lan.Change_language_MessageText("Những mặt hàng sau không đủ trong tồn") + "\n" + s, s_msg);
                }
                ref_text();
            }
        }
        bool test()
        {
            if (!kiemtra_ngaykham_toa())
            {
                MessageBox.Show(lan.Change_language_MessageText("Ngày khám và ngày cấp toa vượt quá") + m.iKhoangcachngaycaptoa_voingaykham.ToString() + " " + lan.Change_language_MessageText("ngày"), "Medisoft");
                return false;
            }
            if (!kiemtraDone_paid())
            {
                MessageBox.Show(lan.Change_language_MessageText("Bạn không thể sửa toa thuốc này"), "Medisoft");
                return false;
            }
            if (makhosave != "")
            {
                s_makho = "";
                //sql = "select * from " + user + ".d_dmkho where dongy=0 and id in (" + makhosave.Substring(0, makhosave.Length - 1) + ")";//gam comment ngay 27/09/2011 -->không lay đuuoc thuoc kho dong y khi cap toa
                sql = "select * from " + user + ".d_dmkho where hide=0 and id in (" + makhosave.Substring(0, makhosave.Length - 1) + ")";
                if (i_khudt != 0) sql += " and (khu=0 or khu=" + i_khudt + ")";
                foreach (DataRow r in m.get_data(sql).Tables[0].Rows)
                {
                    //s_makho += r["id"].ToString().PadLeft(3, '0') + ",";
                    s_makho += r["id"].ToString()+ ",";
                }
            }
            return true;
        }

        private void toolTuychon_Click(object sender, EventArgs e)
        {

        }

        private void frmBaohiem_Validated(object sender, EventArgs e)
        {
            
        }

        private void frmBaohiem_Layout(object sender, LayoutEventArgs e)
        {
            listCachdung.Location = new System.Drawing.Point(570, this.Height - 140);
            listCachdung.Width = cachdung.Width;
            listCachdung.Height = 100;
        }

        private void chkDongy_CheckedChanged(object sender, EventArgs e)
        {
            m.writeXml("thongso", "dongy", (chkThuoc.Checked) ? "1" : "0");
        }

        private void ghichu_KeyDown_1(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)&& dtLoidan.Rows.Count>0)
            {
                listLoidan.Focus();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if (listLoidan.Visible) listLoidan.Focus();
                else SendKeys.Send("{Tab}");
            }
        }

        private void ghichu_Validated(object sender, EventArgs e)
        {
            if (!listLoidan.Focused) listLoidan.Hide();
        }

        private void chandoan_TextChanged(object sender, EventArgs e)
        {
            //listICD.Hide();
            if (ActiveControl == chandoan)//Thuy 11.04.2012
            {
                listICD.BrowseToICD10(chandoan, maicd, makp, chandoan.Location.X, chandoan.Location.Y +
                    chandoan.Height - 2, chandoan.Width + chandoan.Width + 2, chandoan.Height);
            }
        }

        private void chandoan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up) listICD.Focus();
            else if (e.KeyCode == Keys.Enter)
            {
                if (listICD.Visible) listICD.Focus();
                else SendKeys.Send("{Tab}");
            }	
        }

        private void maicd_TextChanged(object sender, EventArgs e)
        {
            listICD.Hide();
        }

        private void maicd_Validated(object sender, EventArgs e)
        {
            chandoan.Text = m.get_vviet(maicd.Text);
        }

        private void maicd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ghichu.Focus();
            }	
        }

        private void ghichuct_TextChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == ghichuct && bDonthuoc_stc == false)
            {
                Filter_cachdung(cachdung.Text);
                listCachdung.BrowseToBtdkp(ghichuct, ghichuct, butThem);
            }
        }

        private void ghichuct_Validated(object sender, EventArgs e)
        {
            if (!listCachdung.Focused) listCachdung.Hide();
        }
        //en

        /// <summary>
        /// Kiểm tra paid ,done nếu <> 0 thì không cho phép sửa
        /// </summary>
        /// <returns></returns>
        private bool kiemtra_paid(string m_tu, string m_den)
        {
            sql = "select id from xxx.bhytkb where mabn='" + s_mabncaptoa + "' and id =" + l_id + " and sobienlai <> 0";
            sql += " UNION ALL ";
            sql += "select id from xxx.D_NGTRULL where mabn='" + s_mabncaptoa + "' and id =" + l_id + " and sobienlai<>0";
            if (m.get_data_mmyy(sql, m_tu, m_den, true).Tables[0].Rows.Count > 0)
            {
                return false;
            }
            return true;
        }

        private void upd_duoc_xuatban()
        {
            itable = d.tableid(s_mmyy, "d_ngtruct");
            if (!bNew)
            {
                sql = "select a.*,t.manguon,t.nhomcc,t.handung,t.losx,t.giamua,t.giaban,a.soluong*t.giamua as sotienmua from "
                    + zzz + ".d_ngtruct a," + zzz + ".d_theodoi t where a.sttt=t.id and a.id=" + l_id;
                foreach (DataRow r1 in d.get_data(sql).Tables[0].Rows)
                {
                    d.upd_eve_tables(s_mmyy, itable, i_userid, "del");
                    d.upd_eve_upd_del(s_mmyy, itable, i_userid, "del", d.fields(zzz + ".d_ngtruct", "id=" + l_id + " and stt=" + decimal.Parse(r1["stt"].ToString())));
                    d.execute_data("delete from " + zzz + ".d_ngtruct where id=" + l_id + " and stt=" + decimal.Parse(r1["stt"].ToString()));
                    d.upd_tonkhoct_xuat(d.delete, s_mmyy, decimal.Parse(r1["sttt"].ToString()), int.Parse(r1["makho"].ToString()),
                        int.Parse(r1["manguon"].ToString()), int.Parse(r1["nhomcc"].ToString()), int.Parse(r1["mabd"].ToString()),
                        r1["handung"].ToString(), r1["losx"].ToString(), decimal.Parse(r1["soluong"].ToString()),
                        decimal.Parse(r1["sotienmua"].ToString()), decimal.Parse(r1["giaban"].ToString()), decimal.Parse(r1["giamua"].ToString()));
                }
            }

            itable = d.tableid(s_mmyy, "d_ngtrull");
            if (bNew) d.upd_eve_tables(s_mmyy, itable, i_userid, "ins");
            else
            {
                d.upd_eve_tables(s_mmyy, itable, i_userid, "upd");
                d.upd_eve_upd_del(s_mmyy, itable, i_userid, "upd", d.fields(zzz + ".d_ngtrull", "id=" + l_id));
            }
            int d_toaso = d.get_sotoa_bhyt(s_mmyy, l_id, s_ngay.Substring(0, 10), i_madoituong);
            int i_makp = 0, i_sotoa = 0;
            //
            try
            {
                DataSet ads_dkp = m.get_data("select id from medibv.d_duockp where makp='" + s_makp + "' order by id");
                if (ads_dkp != null && ads_dkp.Tables.Count > 0 && ads_dkp.Tables[0].Rows.Count > 0)
                {
                    i_makp = int.Parse(ads_dkp.Tables[0].Rows[0]["id"].ToString());
                }
                else i_makp = 0;
            }
            catch { i_makp = 0; }
            //
            if (!d.upd_ngtrull(s_mmyy, l_id, i_nhom, s_mabn, hoten.Text, namsinh.Text, s_ngay, s_mabs, i_makp, i_loai, i_userid, d_toaso, l_maql, s_diachi, ghichu.Text))
            {
                MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin !"), LibMedi.AccessData.Msg);
                return;
            }
            //DataTable tmp = d.get_bhytthuoc(s_mmyy, load_thuoc(l_id), l_id, (i_loaiba == 2) ? 0 : i_madoituong);
            d.execute_data("update " + xxx + ".d_thuocbhytll set done=1 where id=" + l_id);
            DataTable tmp = d.get_ngtruct(s_mmyy, load_thuoc(l_id), l_id);
        }
	}
}

