using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibMedi;
//using Npgsql;
using LibVienphi;
using LibDuoc;
using System.IO;

namespace dllvpkhoa_chidinh
{
	public class frmChidinh : System.Windows.Forms.Form
    {
        //linh
        string s_tenchinhanh = "";
        string s_diachi = "", s_nghenghiep = "", s_cholam = "", s_namsinh = "", s_dantoc = "", s_ngoaikieu = "", s_dienthoai = "", s_phai = "";
        string s_madantoc = "", s_mann = "", s_matt = "", s_maquan = "", s_mapxa = "", s_ngaysinh = "";
        string s_tentt = "", s_tenquanhuyen = "", s_tenpxa = "";
        string s_tungay = "", s_denngay = "", s_ngay1 = "", s_ngay2 = "", s_ngay3 = "";
        string s_manoidkkcb = "", s_mabv = "", s_tuoivao = "", xxx="";
        int i_maphu = 0, i_phai = 0, i_trangthai = 0, i_idchinhanhden = -1, i_songayhen = 0;
        bool b_chuyenngoaitru = false, b_chuyenvien = false, b_xuatvien_hen = false;
        private bool b_cholai = false, bchuyenclsvathongtinbnsangcnkhac = false, bChiPhiVuotTamUngKoChoChiDinh=false;
        string s_ngay_vaovien = "";
        Form frm_parent = null;
        DataTable dtchinhanh = null;
        //khuong
        DataTable dtPhieu = new DataTable();
        //end khuong
        //end linh
        #region Khai bao
        Language lan = new Language();
        Bogotiengviet tv = new Bogotiengviet();
        private int i_maxlength_mabn = 8;
        private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox mabn;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox hoten;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox tuoi;
		private System.Windows.Forms.TreeView treeView1;
		private System.Windows.Forms.DataGrid dataGrid1;
		private LibList.List list;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox madoituong;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox ten;
		private System.Windows.Forms.Label label6;
		private MaskedTextBox.MaskedTextBox soluong;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox tenkp;
		private System.Windows.Forms.TextBox mavp;
		private System.Windows.Forms.Button butLietke;
		private System.Windows.Forms.Button butMoi;
		private System.Windows.Forms.Button butSua;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.Button butHuy;
		private System.Windows.Forms.Button butKetthuc;
		private LibMedi.AccessData m;
		private LibVienphi.AccessData v;
		private LibDuoc.AccessData d=new LibDuoc.AccessData();
        private string nam, user, s_mabn, s_hoten, s_tuoi, s_ngay, tmp_ngay, s_makp, s_tenkp, sql, s_dvt, s_table, s_loaivp = "", s_mucvp = "", s_mabs, s_chandoan, s_maicd, s_chenhlech, s_gioitinh = "", username="";
        private int i_madoituong, i_loai, i_done, i_paid, i_row = 0, i_userid, iChidinh, v1, v2, i_nhom, i_madoituongvao, i_tunguyen, i_loaiba, ichinhanh;
        private int i_traituyen = 0, i_kythuat = -1;
        private decimal l_maql, l_idkhoa, l_id, l_mavaovien, l_idchidinh, Tamung_min = 0;
		private decimal d_soluong,d_dongia,d_vattu;
        private bool bInchitiet, bTinnhan, bTinnhan_sound, bAdmin, bAdminHethong, bAdminInlaiphieuchidinh, bAdminInlaidonthuoc, bMadoituong, bChidinh_exp_txt, bChuky, bChidinh_ngtru_vienphi, bChenhlech = false, bChenhlech_doituong, bChidinh_loaivp, bNew, bChidinh_lietke_kemgia = true, bBHYT_Traituyen_tinh_Tyle_khac = false, bChenhlechPK_chitinh_vaongaynghi = false, bCheckgiaphuthu, bNgayhienhanh_thuoc_chidinh=true;
		private DataSet ds = new DataSet();
		private DataTable dt = new DataTable();
		private DataTable dtngay = new DataTable();
		private DataTable dtkp = new DataTable();
        private DataTable dtbs = new DataTable();
        private DataTable dtdt = new DataTable();
        private DataTable dthoten = new DataTable();
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.ComboBox tinhtrang;
		private System.Windows.Forms.ComboBox thuchien;
		private System.Windows.Forms.TextBox ma;
		private System.Windows.Forms.Button butNet;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox sothe;
		private System.Windows.Forms.Button butIn;
        private Brush disabledBackBrush;
        private Brush disabledTextBrush;
        private Brush disabledTextBrush1;
        private Brush alertBackBrush;
        private Font alertFont;
        private Brush alertTextBrush;
        private Font currentRowFont;
        private Brush currentRowBackBrush;
        private bool afterCurrentCellChanged = true, bCD_BS_Chidinh, bChidinh_thutienlien;
        private int checkCol = 0;
        private dllReportM.Print print = new dllReportM.Print();
        private Label label11;
        private MaskedTextBox.MaskedTextBox tong;
        private Label label12;
        private TextBox tenbs;
        private Label label13;
        private TextBox chandoan;
        private LibList.List listBS;
        private TextBox mabs;
        private FileStream fstr;
        private byte[] image;
        //private System.IO.MemoryStream memo;
        private string sothe_jl;
        private int vitri_jl;
        private string cl_cholam = "",cl_tendoituong="";
        private decimal cl_tyle = 0;
        private int cl_doituong = 3;
        private bool bLocdichvu, bTrongoi_doituong, bSophieu_chidinh;
        private Label label14;
        private TextBox ghichu;
        private bool bXemlai = false, bDainmau38 = false;
		private System.ComponentModel.Container components = null;
        private bool bbadt = false;
        private int i_tuoi, i_idloaitg = 0, i_doituonggiatheotg;//linh ixamlan, i_hoichan, i_tutuoi, i_dentuoi, s_gtvp = "", 
        private string s_id = "", s_idvienphi_icd10 = "", s_maicd10 = "";
        private DataSet ds_bnmien = new DataSet();
        private DataSet ds_bnloaitg = new DataSet();
        private DateTime dttungay, dtdenngay, dtngayhuongktc;
        private DataSet ds_vienphi_icd10 = new DataSet();
        private DataSet ds_ktrahuongKTC = new DataSet();
        #endregion
        private Label label15;
        private TextBox txtchandoansobo;
        private ToolStripMenuItem butInct;
        private ToolStrip toolStrip1;
        private bool bChidinh_dain_khongchohuy = false;
        ToolStripDropDownButton toolStripButton1 = new System.Windows.Forms.ToolStripDropDownButton();
        ToolStripMenuItem butGiaycamdoanCT = new System.Windows.Forms.ToolStripMenuItem();
        ToolStripMenuItem butPhieukhambenhchupCT = new System.Windows.Forms.ToolStripMenuItem();
        ToolStripMenuItem butGiayhoichan = new System.Windows.Forms.ToolStripMenuItem();
        ToolStripMenuItem chkXem = new System.Windows.Forms.ToolStripMenuItem();
        ToolStripMenuItem chkXML = new System.Windows.Forms.ToolStripMenuItem();
        ToolStripMenuItem chkIntheodot = new System.Windows.Forms.ToolStripMenuItem();
        private Button butGoi;
        private ToolStripMenuItem chkTudongchonthongso;
        private ToolStripMenuItem tmn_hienthi_phuthu;
        private ToolStripMenuItem chkCanhbaobnBHYTKhidungDVKTC;
        private CheckBox chkDoiTuongVao;
        private ToolStripMenuItem mnuSapXepTenTheoABC;
        Button btchuyen = new System.Windows.Forms.Button();

        public frmChidinh(LibMedi.AccessData acc,string mabn,string hoten,string tuoi,string ngay,string makp,string tenkp,int madoituong,int loai,decimal mavaovien,decimal maql,decimal idkhoa,int userid,string table,string thebhyt,string _nam,int loaiba,string _mabs,string _chandoan,string _maicd, int traituyen)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
            m = acc; v = new LibVienphi.AccessData(); if (m.bBogo) tv.GanBogo(this, textBox111);
            s_mabn = mabn; s_hoten = hoten; s_tuoi = tuoi; s_ngay = ngay; s_makp = makp; s_tenkp = tenkp; s_table = table; nam = _nam; i_madoituongvao = madoituong; s_mabs = _mabs; s_chandoan = _chandoan;
            tmp_ngay = s_ngay;
            i_madoituong = madoituong; i_loai = loai; l_maql = maql; l_idkhoa = idkhoa; i_userid = userid; sothe.Text = thebhyt; l_mavaovien = mavaovien; i_loaiba = loaiba; s_maicd = _maicd;
            i_traituyen = traituyen;
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}
        //
        public frmChidinh(LibMedi.AccessData acc, string mabn, string hoten, string tuoi, string ngay, string makp, string tenkp, int madoituong, int loai, decimal mavaovien, decimal maql, decimal idkhoa, int userid, string table, string thebhyt, string _nam, int loaiba, string _mabs, string _chandoan, string _maicd, int traituyen, bool xemlai, bool _dainmau38)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            m = acc; v = new LibVienphi.AccessData(); if (m.bBogo) tv.GanBogo(this, textBox111);
            s_mabn = mabn; s_hoten = hoten; s_tuoi = tuoi; s_ngay = ngay; s_makp = makp; s_tenkp = tenkp; s_table = table; nam = _nam; i_madoituongvao = madoituong; s_mabs = _mabs; s_chandoan = _chandoan;
            tmp_ngay = s_ngay;
            i_madoituong = madoituong; i_loai = loai; l_maql = maql; l_idkhoa = idkhoa; i_userid = userid; sothe.Text = thebhyt; l_mavaovien = mavaovien; i_loaiba = loaiba; s_maicd = _maicd;
            i_traituyen = traituyen;
            bXemlai = xemlai;
            bDainmau38 = _dainmau38;
            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
        //--linh
        public frmChidinh(LibMedi.AccessData acc, string mabn, string hoten, string tuoi, string ngay, string makp, string tenkp, int madoituong, int loai, decimal mavaovien, decimal maql, decimal idkhoa, int userid, string table, string thebhyt, string _nam, string loaiba, string _mabs, string _chandoan, bool badmin, int traituyen)
        {
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this); tv.GanBogo(this, textBox111);
            m = acc; v = new LibVienphi.AccessData();
            s_mabn = mabn; s_hoten = hoten; s_tuoi = tuoi; s_ngay = ngay; s_makp = makp; s_tenkp = tenkp; s_table = table; nam = _nam; i_madoituongvao = madoituong; s_mabs = _mabs; s_chandoan = _chandoan;
            tmp_ngay = s_ngay;
            i_madoituong = madoituong; i_loai = loai; l_maql = maql; l_idkhoa = idkhoa; i_userid = userid; sothe.Text = thebhyt; l_mavaovien = mavaovien;
            i_traituyen = traituyen;
        }//--end
		//Tu:25/05/2011
        public frmChidinh(LibMedi.AccessData acc, string mabn, string hoten, string tuoi, string ngay, string makp, string tenkp, int madoituong, int loai, decimal mavaovien, decimal maql, decimal idkhoa, int userid, string table, string thebhyt, string _nam, int loaiba, string _mabs, string _chandoan, string _maicd, int traituyen,bool _badt,int _ichinhanh)
        {
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            m = acc; v = new LibVienphi.AccessData(); if (m.bBogo) tv.GanBogo(this, textBox111);
            s_mabn = mabn; s_hoten = hoten; s_tuoi = tuoi; s_ngay = ngay; s_makp = makp; s_tenkp = tenkp; s_table = table; nam = _nam; i_madoituongvao = madoituong; s_mabs = _mabs; s_chandoan = _chandoan;
            tmp_ngay = s_ngay;
            i_madoituong = madoituong; i_loai = loai; l_maql = maql; l_idkhoa = idkhoa; i_userid = userid; sothe.Text = thebhyt; l_mavaovien = mavaovien; i_loaiba = loaiba; s_maicd = _maicd;
            i_traituyen = traituyen;
            bbadt = _badt;
            ichinhanh = _ichinhanh;
        }
        
        //end Tu
        // Dong 01/06/2011
        public frmChidinh(LibMedi.AccessData acc, string mabn, string hoten, string tuoi, string ngay, string makp, string tenkp, int madoituong, int loai, decimal mavaovien, decimal maql, decimal idkhoa, int userid, string table, string thebhyt, string _nam, int loaiba, string _mabs, string _chandoan, string _maicd, int traituyen, int i_chinhanh)
        {
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            m = acc; v = new LibVienphi.AccessData(); if (m.bBogo) tv.GanBogo(this, textBox111);
            s_mabn = mabn; s_hoten = hoten; s_tuoi = tuoi; s_ngay = ngay; s_makp = makp; s_tenkp = tenkp; s_table = table; nam = _nam; i_madoituongvao = madoituong; s_mabs = _mabs; s_chandoan = _chandoan;
            tmp_ngay = s_ngay;
            i_madoituong = madoituong; i_loai = loai; l_maql = maql; l_idkhoa = idkhoa; i_userid = userid; sothe.Text = thebhyt; l_mavaovien = mavaovien; i_loaiba = loaiba; s_maicd = _maicd;
            i_traituyen = traituyen;
            ichinhanh = i_chinhanh;
        }
        //Dong
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
                        disabledTextBrush1.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChidinh));
            this.label1 = new System.Windows.Forms.Label();
            this.mabn = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.hoten = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tuoi = new System.Windows.Forms.TextBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.list = new LibList.List();
            this.label4 = new System.Windows.Forms.Label();
            this.madoituong = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ten = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.soluong = new MaskedTextBox.MaskedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tenkp = new System.Windows.Forms.TextBox();
            this.mavp = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tinhtrang = new System.Windows.Forms.ComboBox();
            this.thuchien = new System.Windows.Forms.ComboBox();
            this.ma = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.sothe = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tong = new MaskedTextBox.MaskedTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tenbs = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.chandoan = new System.Windows.Forms.TextBox();
            this.listBS = new LibList.List();
            this.mabs = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.ghichu = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtchandoansobo = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.butGiaycamdoanCT = new System.Windows.Forms.ToolStripMenuItem();
            this.butPhieukhambenhchupCT = new System.Windows.Forms.ToolStripMenuItem();
            this.butGiayhoichan = new System.Windows.Forms.ToolStripMenuItem();
            this.butInct = new System.Windows.Forms.ToolStripMenuItem();
            this.chkXem = new System.Windows.Forms.ToolStripMenuItem();
            this.chkXML = new System.Windows.Forms.ToolStripMenuItem();
            this.chkIntheodot = new System.Windows.Forms.ToolStripMenuItem();
            this.chkTudongchonthongso = new System.Windows.Forms.ToolStripMenuItem();
            this.tmn_hienthi_phuthu = new System.Windows.Forms.ToolStripMenuItem();
            this.chkCanhbaobnBHYTKhidungDVKTC = new System.Windows.Forms.ToolStripMenuItem();
            this.btchuyen = new System.Windows.Forms.Button();
            this.butIn = new System.Windows.Forms.Button();
            this.butNet = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.butHuy = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.butSua = new System.Windows.Forms.Button();
            this.butMoi = new System.Windows.Forms.Button();
            this.butLietke = new System.Windows.Forms.Button();
            this.butGoi = new System.Windows.Forms.Button();
            this.chkDoiTuongVao = new System.Windows.Forms.CheckBox();
            this.mnuSapXepTenTheoABC = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(2, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã BN :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mabn
            // 
            this.mabn.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabn.Enabled = false;
            this.mabn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabn.Location = new System.Drawing.Point(47, 32);
            this.mabn.Name = "mabn";
            this.mabn.Size = new System.Drawing.Size(65, 21);
            this.mabn.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(108, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Họ tên :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // hoten
            // 
            this.hoten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.hoten.Enabled = false;
            this.hoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoten.Location = new System.Drawing.Point(156, 32);
            this.hoten.Name = "hoten";
            this.hoten.Size = new System.Drawing.Size(152, 21);
            this.hoten.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(306, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tuổi :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tuoi
            // 
            this.tuoi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tuoi.Enabled = false;
            this.tuoi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tuoi.Location = new System.Drawing.Point(340, 32);
            this.tuoi.Name = "tuoi";
            this.tuoi.Size = new System.Drawing.Size(48, 21);
            this.tuoi.TabIndex = 5;
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.Location = new System.Drawing.Point(630, 55);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(209, 292);
            this.treeView1.TabIndex = 60;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
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
            this.dataGrid1.Location = new System.Drawing.Point(8, 36);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(622, 311);
            this.dataGrid1.TabIndex = 70;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            this.dataGrid1.Click += new System.EventHandler(this.dataGrid1_Click);
            // 
            // list
            // 
            this.list.BackColor = System.Drawing.SystemColors.Info;
            this.list.ColumnCount = 0;
            this.list.Location = new System.Drawing.Point(386, 427);
            this.list.MatchBufferTimeOut = 1000;
            this.list.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.list.Name = "list";
            this.list.Size = new System.Drawing.Size(75, 17);
            this.list.TabIndex = 80;
            this.list.TextIndex = -1;
            this.list.TextMember = null;
            this.list.ValueIndex = -1;
            this.list.Visible = false;
            this.list.DoubleClick += new System.EventHandler(this.list_DoubleClick);
            this.list.KeyDown += new System.Windows.Forms.KeyEventHandler(this.list_KeyDown);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.Location = new System.Drawing.Point(554, 397);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 23);
            this.label4.TabIndex = 9;
            this.label4.Text = "Đối tượng :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // madoituong
            // 
            this.madoituong.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.madoituong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.madoituong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.madoituong.Enabled = false;
            this.madoituong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madoituong.Location = new System.Drawing.Point(630, 399);
            this.madoituong.Name = "madoituong";
            this.madoituong.Size = new System.Drawing.Size(209, 21);
            this.madoituong.TabIndex = 4;
            this.madoituong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.madoituong_KeyDown);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.Location = new System.Drawing.Point(0, 421);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 23);
            this.label5.TabIndex = 11;
            this.label5.Text = "Dịch vụ :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ten
            // 
            this.ten.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ten.Enabled = false;
            this.ten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ten.Location = new System.Drawing.Point(145, 421);
            this.ten.Name = "ten";
            this.ten.Size = new System.Drawing.Size(456, 21);
            this.ten.TabIndex = 6;
            this.ten.TextChanged += new System.EventHandler(this.ten_TextChanged);
            this.ten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ten_KeyDown);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.Location = new System.Drawing.Point(589, 421);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 23);
            this.label6.TabIndex = 13;
            this.label6.Text = "Số lượng :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // soluong
            // 
            this.soluong.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.soluong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.soluong.Enabled = false;
            this.soluong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.soluong.Location = new System.Drawing.Point(653, 421);
            this.soluong.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
            this.soluong.Name = "soluong";
            this.soluong.Size = new System.Drawing.Size(186, 21);
            this.soluong.TabIndex = 7;
            this.soluong.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.soluong.Validated += new System.EventHandler(this.soluong_Validated);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(350, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 23);
            this.label7.TabIndex = 15;
            this.label7.Text = "Khoa :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tenkp
            // 
            this.tenkp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenkp.Enabled = false;
            this.tenkp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenkp.Location = new System.Drawing.Point(420, 32);
            this.tenkp.Name = "tenkp";
            this.tenkp.Size = new System.Drawing.Size(166, 21);
            this.tenkp.TabIndex = 16;
            // 
            // mavp
            // 
            this.mavp.Enabled = false;
            this.mavp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mavp.Location = new System.Drawing.Point(64, 179);
            this.mavp.Name = "mavp";
            this.mavp.Size = new System.Drawing.Size(46, 21);
            this.mavp.TabIndex = 33;
            this.mavp.Validated += new System.EventHandler(this.mavp_Validated);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.Location = new System.Drawing.Point(-7, 397);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 23);
            this.label8.TabIndex = 18;
            this.label8.Text = "Tình trạng :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.Location = new System.Drawing.Point(248, 397);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 23);
            this.label9.TabIndex = 19;
            this.label9.Text = "Thực hiện :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tinhtrang
            // 
            this.tinhtrang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tinhtrang.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tinhtrang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tinhtrang.Enabled = false;
            this.tinhtrang.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tinhtrang.Location = new System.Drawing.Point(56, 399);
            this.tinhtrang.Name = "tinhtrang";
            this.tinhtrang.Size = new System.Drawing.Size(186, 21);
            this.tinhtrang.TabIndex = 2;
            this.tinhtrang.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tinhtrang_KeyDown);
            // 
            // thuchien
            // 
            this.thuchien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.thuchien.BackColor = System.Drawing.SystemColors.HighlightText;
            this.thuchien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.thuchien.Enabled = false;
            this.thuchien.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thuchien.Location = new System.Drawing.Point(312, 399);
            this.thuchien.Name = "thuchien";
            this.thuchien.Size = new System.Drawing.Size(208, 21);
            this.thuchien.TabIndex = 3;
            this.thuchien.KeyDown += new System.Windows.Forms.KeyEventHandler(this.thuchien_KeyDown);
            // 
            // ma
            // 
            this.ma.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ma.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ma.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ma.Enabled = false;
            this.ma.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ma.Location = new System.Drawing.Point(56, 421);
            this.ma.Name = "ma";
            this.ma.Size = new System.Drawing.Size(88, 21);
            this.ma.TabIndex = 5;
            this.ma.Validated += new System.EventHandler(this.mavp_Validated);
            this.ma.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ma_KeyDown);
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(581, 32);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 21);
            this.label10.TabIndex = 76;
            this.label10.Text = "Số thẻ :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sothe
            // 
            this.sothe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sothe.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sothe.Enabled = false;
            this.sothe.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sothe.Location = new System.Drawing.Point(630, 32);
            this.sothe.Name = "sothe";
            this.sothe.Size = new System.Drawing.Size(209, 21);
            this.sothe.TabIndex = 75;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label11.Location = new System.Drawing.Point(634, 355);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(38, 18);
            this.label11.TabIndex = 80;
            this.label11.Text = "Tổng :";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tong
            // 
            this.tong.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tong.Enabled = false;
            this.tong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tong.Location = new System.Drawing.Point(669, 353);
            this.tong.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
            this.tong.Name = "tong";
            this.tong.Size = new System.Drawing.Size(170, 21);
            this.tong.TabIndex = 81;
            this.tong.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label12.Location = new System.Drawing.Point(-29, 374);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(84, 23);
            this.label12.TabIndex = 140;
            this.label12.Text = "Bác sỹ :";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tenbs
            // 
            this.tenbs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tenbs.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbs.Enabled = false;
            this.tenbs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbs.Location = new System.Drawing.Point(56, 377);
            this.tenbs.Name = "tenbs";
            this.tenbs.Size = new System.Drawing.Size(186, 21);
            this.tenbs.TabIndex = 0;
            this.tenbs.TextChanged += new System.EventHandler(this.tenbs_TextChanged);
            this.tenbs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbs_KeyDown);
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label13.Location = new System.Drawing.Point(240, 374);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(72, 23);
            this.label13.TabIndex = 142;
            this.label13.Text = "Chẩn đoán :";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chandoan
            // 
            this.chandoan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.chandoan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.chandoan.Enabled = false;
            this.chandoan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chandoan.Location = new System.Drawing.Point(312, 376);
            this.chandoan.Name = "chandoan";
            this.chandoan.Size = new System.Drawing.Size(528, 21);
            this.chandoan.TabIndex = 1;
            this.chandoan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ma_KeyDown);
            // 
            // listBS
            // 
            this.listBS.BackColor = System.Drawing.SystemColors.Info;
            this.listBS.ColumnCount = 0;
            this.listBS.Location = new System.Drawing.Point(305, 427);
            this.listBS.MatchBufferTimeOut = 1000;
            this.listBS.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listBS.Name = "listBS";
            this.listBS.Size = new System.Drawing.Size(75, 17);
            this.listBS.TabIndex = 226;
            this.listBS.TextIndex = -1;
            this.listBS.TextMember = null;
            this.listBS.ValueIndex = -1;
            this.listBS.Visible = false;
            // 
            // mabs
            // 
            this.mabs.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabs.Enabled = false;
            this.mabs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabs.Location = new System.Drawing.Point(391, 179);
            this.mabs.Name = "mabs";
            this.mabs.Size = new System.Drawing.Size(44, 21);
            this.mabs.TabIndex = 227;
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label14.Location = new System.Drawing.Point(2, 445);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(55, 23);
            this.label14.TabIndex = 229;
            this.label14.Text = "Ghi chú :";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ghichu
            // 
            this.ghichu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ghichu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ghichu.Enabled = false;
            this.ghichu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ghichu.Location = new System.Drawing.Point(56, 444);
            this.ghichu.Name = "ghichu";
            this.ghichu.Size = new System.Drawing.Size(545, 21);
            this.ghichu.TabIndex = 8;
            this.ghichu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ghichu_KeyDown);
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.Location = new System.Drawing.Point(382, 499);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(102, 21);
            this.label15.TabIndex = 232;
            this.label15.Text = "Chẩn đoán sơ bộ :";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label15.Visible = false;
            // 
            // txtchandoansobo
            // 
            this.txtchandoansobo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtchandoansobo.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtchandoansobo.Enabled = false;
            this.txtchandoansobo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtchandoansobo.Location = new System.Drawing.Point(486, 498);
            this.txtchandoansobo.Name = "txtchandoansobo";
            this.txtchandoansobo.Size = new System.Drawing.Size(209, 21);
            this.txtchandoansobo.TabIndex = 233;
            this.txtchandoansobo.Visible = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(844, 25);
            this.toolStrip1.TabIndex = 235;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.butGiaycamdoanCT,
            this.butPhieukhambenhchupCT,
            this.butGiayhoichan,
            this.butInct,
            this.chkXem,
            this.chkXML,
            this.chkIntheodot,
            this.chkTudongchonthongso,
            this.tmn_hienthi_phuthu,
            this.chkCanhbaobnBHYTKhidungDVKTC,
            this.mnuSapXepTenTheoABC});
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(56, 22);
            this.toolStripButton1.Text = "Tiện ích";
            // 
            // butGiaycamdoanCT
            // 
            this.butGiaycamdoanCT.Name = "butGiaycamdoanCT";
            this.butGiaycamdoanCT.Size = new System.Drawing.Size(356, 22);
            this.butGiaycamdoanCT.Text = "Giấy cam đoan";
            this.butGiaycamdoanCT.Click += new System.EventHandler(this.butGiaycamdoanCT_Click);
            // 
            // butPhieukhambenhchupCT
            // 
            this.butPhieukhambenhchupCT.Name = "butPhieukhambenhchupCT";
            this.butPhieukhambenhchupCT.Size = new System.Drawing.Size(356, 22);
            this.butPhieukhambenhchupCT.Text = "Phiếu khám bệnh chụp CT Scanner";
            this.butPhieukhambenhchupCT.Click += new System.EventHandler(this.btCtscannercocq_Click);
            // 
            // butGiayhoichan
            // 
            this.butGiayhoichan.Name = "butGiayhoichan";
            this.butGiayhoichan.Size = new System.Drawing.Size(356, 22);
            this.butGiayhoichan.Text = "Giấy hội chẩn chụp CT Scanner";
            this.butGiayhoichan.Click += new System.EventHandler(this.btHoichan_Click);
            // 
            // butInct
            // 
            this.butInct.Name = "butInct";
            this.butInct.Size = new System.Drawing.Size(356, 22);
            this.butInct.Text = "In từng ngày";
            this.butInct.Click += new System.EventHandler(this.butInct_Click);
            // 
            // chkXem
            // 
            this.chkXem.CheckOnClick = true;
            this.chkXem.Name = "chkXem";
            this.chkXem.Size = new System.Drawing.Size(356, 22);
            this.chkXem.Text = "Xem trước khi in";
            // 
            // chkXML
            // 
            this.chkXML.CheckOnClick = true;
            this.chkXML.Name = "chkXML";
            this.chkXML.Size = new System.Drawing.Size(356, 22);
            this.chkXML.Text = "XML";
            // 
            // chkIntheodot
            // 
            this.chkIntheodot.CheckOnClick = true;
            this.chkIntheodot.Name = "chkIntheodot";
            this.chkIntheodot.Size = new System.Drawing.Size(356, 22);
            this.chkIntheodot.Text = "In cả đợt";
            this.chkIntheodot.Click += new System.EventHandler(this.chkIntheodot_Click);
            // 
            // chkTudongchonthongso
            // 
            this.chkTudongchonthongso.Name = "chkTudongchonthongso";
            this.chkTudongchonthongso.Size = new System.Drawing.Size(356, 22);
            this.chkTudongchonthongso.Text = "Tự động chọn thông số khi chỉ định";
            // 
            // tmn_hienthi_phuthu
            // 
            this.tmn_hienthi_phuthu.CheckOnClick = true;
            this.tmn_hienthi_phuthu.Name = "tmn_hienthi_phuthu";
            this.tmn_hienthi_phuthu.Size = new System.Drawing.Size(356, 22);
            this.tmn_hienthi_phuthu.Text = "Hiển thị phần phụ thu - chênh lệch giá";
            this.tmn_hienthi_phuthu.Click += new System.EventHandler(this.tmn_hienthi_phuthu_Click);
            // 
            // chkCanhbaobnBHYTKhidungDVKTC
            // 
            this.chkCanhbaobnBHYTKhidungDVKTC.CheckOnClick = true;
            this.chkCanhbaobnBHYTKhidungDVKTC.Name = "chkCanhbaobnBHYTKhidungDVKTC";
            this.chkCanhbaobnBHYTKhidungDVKTC.Size = new System.Drawing.Size(356, 22);
            this.chkCanhbaobnBHYTKhidungDVKTC.Text = "Cảnh báo bệnh nhân BHYT khi dùng dịch vụ kỹ thuật cao";
            // 
            // btchuyen
            // 
            this.btchuyen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btchuyen.Image = ((System.Drawing.Image)(resources.GetObject("btchuyen.Image")));
            this.btchuyen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btchuyen.Location = new System.Drawing.Point(629, 471);
            this.btchuyen.Name = "btchuyen";
            this.btchuyen.Size = new System.Drawing.Size(70, 25);
            this.btchuyen.TabIndex = 231;
            this.btchuyen.Text = "Chuyển";
            this.btchuyen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btchuyen.Click += new System.EventHandler(this.btchuyen_Click);
            // 
            // butIn
            // 
            this.butIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(489, 471);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 15;
            this.butIn.Text = "     &In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butNet
            // 
            this.butNet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butNet.Image = ((System.Drawing.Image)(resources.GetObject("butNet.Image")));
            this.butNet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butNet.Location = new System.Drawing.Point(699, 471);
            this.butNet.Name = "butNet";
            this.butNet.Size = new System.Drawing.Size(70, 25);
            this.butNet.TabIndex = 16;
            this.butNet.Text = "&Gửi tin";
            this.butNet.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butNet.Click += new System.EventHandler(this.butNet_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(769, 471);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 18;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // butHuy
            // 
            this.butHuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butHuy.Image = ((System.Drawing.Image)(resources.GetObject("butHuy.Image")));
            this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHuy.Location = new System.Drawing.Point(419, 471);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(70, 25);
            this.butHuy.TabIndex = 14;
            this.butHuy.Text = "     &Hủy";
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butBoqua.Enabled = false;
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(349, 471);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(70, 25);
            this.butBoqua.TabIndex = 10;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butLuu
            // 
            this.butLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butLuu.Enabled = false;
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(279, 471);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 9;
            this.butLuu.Text = "    &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butSua
            // 
            this.butSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butSua.Image = ((System.Drawing.Image)(resources.GetObject("butSua.Image")));
            this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.Location = new System.Drawing.Point(209, 471);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(70, 25);
            this.butSua.TabIndex = 13;
            this.butSua.Text = "    &Sửa";
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butMoi
            // 
            this.butMoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butMoi.Image = ((System.Drawing.Image)(resources.GetObject("butMoi.Image")));
            this.butMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMoi.Location = new System.Drawing.Point(139, 471);
            this.butMoi.Name = "butMoi";
            this.butMoi.Size = new System.Drawing.Size(70, 25);
            this.butMoi.TabIndex = 12;
            this.butMoi.Text = "     &Mới";
            this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
            // 
            // butLietke
            // 
            this.butLietke.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butLietke.Image = ((System.Drawing.Image)(resources.GetObject("butLietke.Image")));
            this.butLietke.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLietke.Location = new System.Drawing.Point(69, 471);
            this.butLietke.Name = "butLietke";
            this.butLietke.Size = new System.Drawing.Size(70, 25);
            this.butLietke.TabIndex = 11;
            this.butLietke.Text = "     Liệt kê";
            this.butLietke.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butLietke.Click += new System.EventHandler(this.butLietke_Click);
            // 
            // butGoi
            // 
            this.butGoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butGoi.Image = ((System.Drawing.Image)(resources.GetObject("butGoi.Image")));
            this.butGoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butGoi.Location = new System.Drawing.Point(559, 471);
            this.butGoi.Name = "butGoi";
            this.butGoi.Size = new System.Drawing.Size(70, 25);
            this.butGoi.TabIndex = 236;
            this.butGoi.Text = "Gói DV";
            this.butGoi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butGoi.Click += new System.EventHandler(this.butGoi_Click);
            // 
            // chkDoiTuongVao
            // 
            this.chkDoiTuongVao.Enabled = false;
            this.chkDoiTuongVao.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.chkDoiTuongVao.Location = new System.Drawing.Point(728, 445);
            this.chkDoiTuongVao.Name = "chkDoiTuongVao";
            this.chkDoiTuongVao.Size = new System.Drawing.Size(111, 24);
            this.chkDoiTuongVao.TabIndex = 259;
            this.chkDoiTuongVao.Text = "Đối tượng khi vào";
            this.chkDoiTuongVao.CheckedChanged += new System.EventHandler(this.chkDoiTuongVao_CheckedChanged);
            // 
            // mnuSapXepTenTheoABC
            // 
            this.mnuSapXepTenTheoABC.Name = "mnuSapXepTenTheoABC";
            this.mnuSapXepTenTheoABC.Size = new System.Drawing.Size(356, 22);
            this.mnuSapXepTenTheoABC.Text = "Liệt kê các dịch vụ sắp xếp Tên theo thứ tự ABC";
            this.mnuSapXepTenTheoABC.Click += new System.EventHandler(this.mnuSapXepTenTheoABC_Click);
            // 
            // frmChidinh
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(844, 536);
            this.Controls.Add(this.chkDoiTuongVao);
            this.Controls.Add(this.butGoi);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.txtchandoansobo);
            this.Controls.Add(this.btchuyen);
            this.Controls.Add(this.ghichu);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.tuoi);
            this.Controls.Add(this.listBS);
            this.Controls.Add(this.tenbs);
            this.Controls.Add(this.chandoan);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.tong);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.sothe);
            this.Controls.Add(this.tenkp);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.butNet);
            this.Controls.Add(this.ma);
            this.Controls.Add(this.tinhtrang);
            this.Controls.Add(this.thuchien);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.madoituong);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butHuy);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butSua);
            this.Controls.Add(this.butMoi);
            this.Controls.Add(this.butLietke);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.ten);
            this.Controls.Add(this.soluong);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.list);
            this.Controls.Add(this.hoten);
            this.Controls.Add(this.mabn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.mavp);
            this.Controls.Add(this.mabs);
            this.Controls.Add(this.label15);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChidinh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chỉ định dịch vụ";
            this.Load += new System.EventHandler(this.frmChidinh_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmChidinh_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmChidinh_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

        private void frmChidinh_Load(object sender, System.EventArgs e)
        {
            user = m.user;
            xxx = user + m.mmyy(s_ngay);
            if (bbadt)
            {
                //linh
                if (frm_parent != null)
                {
                    this.Location = new System.Drawing.Point(frm_parent.Left + 160, frm_parent.Top + 153);//151
                    this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                    this.Size = new Size(frm_parent.Width - 165, frm_parent.Height - 100);
                }
                else
                {
                    this.Size = new Size(829 + 40, 500);
                }
                //end linh
            }
            chkIntheodot.Checked = m.Thongso("chkIntheodot_chidinhclspk") == "1";
            mnuSapXepTenTheoABC.Checked = m.Thongso("chidinh_sort_ten") == "1";
            
            f_capnhat_db();
            f_load_option();
            if (nam == null || nam.Trim().Trim('+') == "")
            {
                nam = f_get_nam_btdbn(s_mabn);
            }
            bChidinh_lietke_kemgia = m.bChidinh_lietke_kemgia;
            sothe_jl = m.sSothe_jl; vitri_jl = m.iSothe_jl_vitri;
            bCD_BS_Chidinh = m.bCD_BS_Chidinh; bTrongoi_doituong = m.bTrongoi_doituong;
            chkXem.Checked = m.bPreview; bLocdichvu = m.bLocdichvu_doituong;
            cl_cholam = m.mien_chenhlech_cholam.Trim().ToLower();
            cl_tyle = m.mien_chenhlech; bChidinh_loaivp = m.bChidinh_loaivp;
            cl_doituong = m.mien_chenhlech_doituong;
            bChidinh_ngtru_vienphi = m.bChidinh_ngtru_vienphi;
            bTinnhan = m.bTinnhan_chidinh;
            bTinnhan_sound = m.bTinnhan_chidinh_sound;
            bAdmin = m.bAdmin(i_userid); bSophieu_chidinh = m.bSophieu_chidinh;
            bAdminHethong = m.bAdminHethong(i_userid);
            bChidinh_thutienlien = m.bChidinh_thutienlien;
            bChenhlech_doituong = m.bChenhlech_doituong;
            bChidinh_dain_khongchohuy = m.bChidinh_dain_khongchohuy;

            bAdminInlaidonthuoc = m.bAdminInlaidonthuoc;
            bAdminInlaiphieuchidinh = m.bAdminInlaiphieuchidinh;
            //linh
            //if (i_loaiba == 4 && m.bPhongluu_chidinh_chonngay) s_ngay = s_ngay;
            //else 
            if (s_ngay_vaovien == "") s_ngay_vaovien = s_ngay;
            if (bNgayhienhanh_thuoc_chidinh && bXemlai == false && s_makp != "99") s_ngay = m.ngayhienhanh_server;
            else if (s_makp == "99" && m.bPhongluu_chidinh_chonngay == false && bNgayhienhanh_thuoc_chidinh) s_ngay = m.ngayhienhanh_server;
            if (bChenhlechPK_chitinh_vaongaynghi)
            {
                bChenhlechPK_chitinh_vaongaynghi = i_loaiba != 1 && i_loaiba != 4 && m.bNgaynghi(s_ngay);
            }
            bChidinh_exp_txt = m.bChidinh_exp_txt;
            i_nhom = m.nhom_duoc; l_idchidinh = v.get_id_chidinhll;
            bInchitiet = m.bKham_inchiphi;
            v1 = 4; v2 = 2; i_tunguyen = m.iTunguyen;

            string vitri = d.thetunguyen_vitri_ora(m.nhom_duoc);
            if (vitri.Length == 3)
            {
                //v1 = int.Parse(vitri.Substring(0, 1)) - 1; v2 = int.Parse(vitri.Substring(2, 1)); //Tu: 18/08/2011
                v1 = int.Parse(vitri.Substring(0, 1)); v2 = int.Parse(vitri.Substring(2, 1));
            }
            bChuky = m.bChuky;
            iChidinh = m.iChidinh;
            bMadoituong = m.bSuadt_thuoc_vp;
            chkDoiTuongVao.Checked = !bMadoituong;
            s_chenhlech = "";
            foreach (DataRow r in m.get_data("select a.*,to_char(madoituong) as madoituong1 from " + user + ".doituong a where chenhlech=1").Tables[0].Rows)
                s_chenhlech += r["madoituong"].ToString().Trim() + ",";
            dtkp = m.get_data("select * from " + user + ".btdkp_bv where makp='" + s_makp + "'").Tables[0];
            if (dtkp.Rows.Count == 1)
            {
                s_loaivp = dtkp.Rows[0]["loaicd"].ToString().Trim();
                s_mucvp = dtkp.Rows[0]["muccd"].ToString().Trim();
                if (s_loaivp != "") s_loaivp = s_loaivp.Substring(0, s_loaivp.Length - 1);
                if (s_mucvp != "") s_mucvp = s_mucvp.Substring(0, s_mucvp.Length - 1);
            }
            //string s_ten = "a.ten";
            //if (bChidinh_lietke_kemgia) s_ten += "||' ['||a.gia_th||']'";
            //sql = "select a.id," + s_ten + " as ten,a.ma,a.dvt,a.gia_th,a.gia_bh,a.gia_dv,a.gia_nn,a.bhyt,a.vattu_th,a.vattu_bh,a.vattu_dv,";
            //sql += "a.vattu_nn,b.computer,b.computervp,a.trongoi,a.locthe,a.gia_cs,a.vattu_cs,a.chenhlech,a.gia_ksk,a.vattu_ksk, a.bhyt_tt,"+
            //    "a.sothe,a.batbuocthutien,a.coso,a.cosothay,a.phongthuchiencls,a.hoichan,a.giaycamdoan,substr(a.tgtrakq,1,2) thoigiantrakq,"+
            //    "substr(a.tgtrakq,4,1) giongay,a.gioitinh,a.tutuoi,a.dentuoi,a.xamlan,a.phuthu_th,a.phuthu_dv,a.phuthu_nn,a.phuthu_cs,a.ctscannercq,"+
            //    "a.kythuat, ";
            //sql += "a.guingoai,a.guimau,a.guinguoi,a.tgtrakq, a.chuyenchungtu ";//linh
            //sql += " from " + user + ".v_giavp a," + user + ".v_loaivp b ";
            //sql += "where a.id_loai=b.id and a.hide=0";
            //if (s_loaivp != "") sql += " and a.id_loai in (" + s_loaivp + ")";
            //if (s_mucvp != "") sql += " and a.id not in (" + s_mucvp + ")";
            //sql += " and (a.loaibn=0 or a.loaibn=" + v.iNgoaitru + ")";
            //sql += " order by b.stt,a.stt";
            //dt = m.get_data(sql).Tables[0];
            //list.DisplayMember = "TEN";
            //list.ValueMember = "ID";
            //list.DataSource = dt;
            f_load_dmgiavp();

            dtbs = m.get_data("select * from " + user + ".dmbs where nhom not in (" + LibMedi.AccessData.nhanvien + "," + LibMedi.AccessData.nghiviec + ") order by ma").Tables[0];
            listBS.DisplayMember = "MA";
            listBS.ValueMember = "HOTEN";
            listBS.DataSource = dtbs;

            tinhtrang.DisplayMember = "TEN";
            tinhtrang.ValueMember = "ID";
            tinhtrang.DataSource = m.get_data("select * from " + user + ".dmtinhtrang order by id").Tables[0];

            thuchien.DisplayMember = "TEN";
            thuchien.ValueMember = "ID";
            thuchien.DataSource = m.get_data("select * from " + user + ".dmthuchien order by id").Tables[0];

            dtdt = m.get_data("select a.*,to_char(madoituong) as madoituong1 from " + user + ".doituong a order by madoituong").Tables[0];
            madoituong.DisplayMember = "DOITUONG";
            madoituong.ValueMember = "MADOITUONG";
            madoituong.DataSource = dtdt;
            if (cl_tyle != 0)
            {
                DataRow r = m.getrowbyid(dtdt, "madoituong=" + cl_doituong);
                cl_tendoituong = (r != null) ? r["doituong"].ToString() : "";
            }
            load_grid();
            AddGridTableStyle();
            lan.Read_dtgrid_to_Xml(dataGrid1, this.Name.ToString() + "_" + dataGrid1.Name.ToString());
            lan.Change_dtgrid_HeaderText_to_English(dataGrid1, this.Name.ToString() + "_" + dataGrid1.Name.ToString());

            this.disabledBackBrush = new SolidBrush(Color.Black);
            this.disabledTextBrush = new SolidBrush(Color.Red);
            this.disabledTextBrush1 = new SolidBrush(Color.Chocolate);

            this.alertBackBrush = new SolidBrush(SystemColors.HotTrack);
            this.alertFont = new Font(this.dataGrid1.Font.Name, this.dataGrid1.Font.Size, FontStyle.Bold);
            this.alertTextBrush = new SolidBrush(Color.White);

            this.currentRowFont = new Font(this.dataGrid1.Font.Name, this.dataGrid1.Font.Size, FontStyle.Regular);
            this.currentRowBackBrush = new SolidBrush(Color.FromArgb(0, 255, 255));
            if (bSophieu_chidinh) m.upd_capsotoacls(m.mmyy(s_ngay), -89, s_ngay.Substring(0, 10), 0, 0);
            //
            if (tinhtrang.Items.Count > 0) tinhtrang.SelectedIndex = 0;
            if (thuchien.Items.Count > 0) thuchien.SelectedIndex = 0;
            //
            ref_text();
            mabn.Text = s_mabn;
            hoten.Text = s_hoten;
            tuoi.Text = s_tuoi;
            tenkp.Text = s_tenkp;
            if (iChidinh != 4)
                load_treeView();
            if (bMadoituong) { madoituong.Enabled = true; chkDoiTuongVao.Enabled = true; madoituong.SelectedValue = i_madoituong; }
            else { madoituong.SelectedValue = i_madoituong; }
            if (bDainmau38 && !bAdminHethong)
            {
                butMoi.Enabled = false;
                butSua.Enabled = false;
                butHuy.Enabled = false;
                butLietke.Enabled = false;
            }
            //linh
            ///Dong them
            //sql = " select phai,namsinh from " + user + ".btdbn where mabn='" + s_mabn + "'";
            //foreach (DataRow dr in m.get_data(sql).Tables[0].Rows)
            //{
            s_gioitinh = s_phai.ToLower() == "nam" ? "0" : "1";// dr["phai"].ToString();
            if (s_namsinh != "")
            {
                string i_namsinh = s_namsinh.Length == 10 ? s_namsinh.Substring(6, 4) : s_namsinh;//int.Parse(dr["namsinh"].ToString());
                i_tuoi = int.Parse(DateTime.Now.Year.ToString()) - int.Parse(i_namsinh);
            }
            //}
            //end linh
            sql = " select id_loaitg from " + user + ".bndk_tg where mabn='" + s_mabn + "' and mavaovien=" + l_mavaovien;
            foreach (DataRow dr in m.get_data(sql).Tables[0].Rows)
            {
                i_idloaitg = int.Parse(dr["id_loaitg"].ToString());
            }
            i_doituonggiatheotg = m.Doituong_gia_loaitg(i_idloaitg);
            string mmyy = user + m.mmyy(s_ngay);
            sql = " select a.maicd,b.mavp from " + mmyy + ".benhanpk a inner join " + user + ".icd10_chidinh b on a.maicd=b.maicd10 ";
            sql += " where a.mabn='" + s_mabn + "' and a.maql=" + l_maql;
            sql += " union all";
            sql += " select a.maicd,b.mavp from " + mmyy + ".cdkemtheo a inner join " + user + ".icd10_chidinh b on a.maicd=b.maicd10 where a.maql=" + l_maql;
            sql += " union all";
            sql += " select a.maicd,b.mavp from " + user + ".cdkemtheo a inner join " + user + ".icd10_chidinh b on a.maicd=b.maicd10 where a.maql=" + l_maql;
            ds_vienphi_icd10 = m.get_data(sql);
            if (ds_vienphi_icd10 != null || ds_vienphi_icd10.Tables.Count > 0)
            {
                foreach (DataRow dr in ds_vienphi_icd10.Tables[0].Rows)
                {
                    s_idvienphi_icd10 += dr["mavp"].ToString();
                    s_maicd10 += dr["maicd"].ToString();
                }
            }
            if (i_madoituong == 1)
            {
                ds_ktrahuongKTC = f_Kiemtrahuong_KTC(s_mabn, s_ngay, s_ngay, i_loaiba);
            }
            if (ds_ktrahuongKTC != null && ds_ktrahuongKTC.Tables.Count > 0 && ds_ktrahuongKTC.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds_ktrahuongKTC.Tables[0].Rows)
                {
                    dttungay = DateTime.Parse(r["tungay"].ToString());
                    dtdenngay = DateTime.Parse(r["denngay"].ToString());
                    dtngayhuongktc = DateTime.Parse(r["ngayduochuongktc"].ToString());
                    break;
                }
            }
            //linh
            DataSet dstmp = m.get_data("select id,ten,database,mabv from " + user + ".dmchinhanh");
            if (dstmp != null)
            {
                if (dstmp.Tables[0].Rows.Count > 0)
                {
                    dtchinhanh = dstmp.Tables[0].Copy();
                    dstmp.Dispose();
                }
            }
            if (dtchinhanh != null)
            {
                DataRow rcn = m.getrowbyid(dtchinhanh, "id=" + ichinhanh);
                if (rcn != null)
                {
                    s_tenchinhanh = rcn["ten"].ToString();
                }
            }
            chkCanhbaobnBHYTKhidungDVKTC.Checked = m.Thongso(chkCanhbaobnBHYTKhidungDVKTC.Name) == "1";
            chkTudongchonthongso.Checked = m.Thongso(chkTudongchonthongso.Name) == "1";
            bchuyenclsvathongtinbnsangcnkhac = m.bchuyenclsvathongtinbnsangcnkhac;
            bChiPhiVuotTamUngKoChoChiDinh = m.bChiPhiVuotTamUngKoChoChiDinh;
            Tamung_min = m.Tamung_min;
            //chkThongBaoChiPhi.Checked = m.Thongso("thongbaochiphi_cd") == "1";
            //chkThongBaoChiPhi.Enabled = bChiPhiVuotTamUngKoChoChiDinh;
            try
            {
                username = m.get_data("select hoten from " + user + ".dlogin where id=" + i_userid).Tables[0].Rows[0][0].ToString();
            }
            catch { }
            //end linh
            //Thuy load ds hiendien khoa
            if(i_loaiba == 1)
            {
                sql = "select a.mabn,b.hoten,a.id,c.mavaovien,a.maql,c.madoituong,d.sothe,b.nam,to_char(c.ngay,'dd/mm/yyyy') as ngay,coalesce(to_char(d.ngaygiahan,'dd/mm/yyyy'),to_char(d.denngay,'dd/mm/yyyy')) as denngay,e.mabs,e.chandoan,e.maicd, nvl(to_char(d.tungay,'dd/mm/yyyy'),to_char(c.ngay,'dd/mm/yyyy')) as tungay, nvl(d.traituyen,0) as traituyen ";//Thuy 04.01.2012
                sql += " from " + user + ".hiendien a inner join " + user + ".btdbn b on a.mabn=b.mabn ";
                sql += " inner join " + user + ".benhandt c on a.maql=c.maql ";
                sql += " left join " + user + ".bhyt d on a.maql=d.maql ";
                sql += " inner join " + user + ".nhapkhoa e on a.id=e.id ";
                sql += " where a.nhapkhoa=1 and a.xuatkhoa=0 ";
                if (!m.ma_phongmo(s_makp)) sql += " and a.makp='" + s_makp + "'";
                sql += " and substr(a.ngay,1,10)<=to_date('" + s_ngay.Substring(0,10) + "','" + m.f_ngay + "')";
                sql += " and (d.sudung is null or d.sudung=1)";
                sql += " order by a.id desc";
                dthoten = m.get_data(sql).Tables[0];
            }
        }
        private void AddGridTableStyle()
        {
            DataGridTableStyle ts = new DataGridTableStyle();
            ts.MappingName = ds.Tables[0].TableName;
            ts.AlternatingBackColor = Color.Beige;
            ts.BackColor = Color.GhostWhite;
            ts.ForeColor = Color.MidnightBlue;
            ts.GridLineColor = Color.RoyalBlue;
            ts.HeaderBackColor = Color.MidnightBlue;
            ts.HeaderForeColor = Color.Lavender;
            ts.SelectionBackColor = Color.FromArgb(0, 255, 255);
            ts.SelectionForeColor = Color.PaleGreen;
            ts.RowHeaderWidth = 5;

            FormattableBooleanColumn discontinuedCol = new FormattableBooleanColumn();
            discontinuedCol.MappingName = "chon";
            discontinuedCol.HeaderText = "In";
            discontinuedCol.Width = 20;
            discontinuedCol.AllowNull = false;

            discontinuedCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
            discontinuedCol.BoolValueChanged += new BoolValueChangedEventHandler(BoolValueChanged);
            ts.GridColumnStyles.Add(discontinuedCol);
            dataGrid1.TableStyles.Add(ts);

            FormattableTextBoxColumn TextCol1 = new FormattableTextBoxColumn();
            TextCol1.MappingName = "id";
            TextCol1.HeaderText = "";
            TextCol1.Width = 0;
            TextCol1.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new FormattableTextBoxColumn();
            TextCol1.MappingName = "tenkp";
            TextCol1.HeaderText = "Khoa/phòng";
            TextCol1.Width = 100;
            TextCol1.ReadOnly = true;
            TextCol1.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new FormattableTextBoxColumn();
            TextCol1.MappingName = "ngay";
            TextCol1.HeaderText = "Ngày";
            TextCol1.Width = 100;
            TextCol1.ReadOnly = true;
            TextCol1.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new FormattableTextBoxColumn();
            TextCol1.MappingName = "doituong";
            TextCol1.HeaderText = "Đối tượng";
            TextCol1.Width = 60;
            TextCol1.ReadOnly = true;
            TextCol1.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new FormattableTextBoxColumn();
            TextCol1.MappingName = "ten";
            TextCol1.HeaderText = "Dịch vụ";
            TextCol1.Width = 200;
            TextCol1.ReadOnly = true;
            TextCol1.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new FormattableTextBoxColumn();
            TextCol1.MappingName = "dvt";
            TextCol1.HeaderText = "ĐVT";
            TextCol1.Width = 30;
            TextCol1.ReadOnly = true;
            TextCol1.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new FormattableTextBoxColumn();
            TextCol1.MappingName = "soluong";
            TextCol1.HeaderText = "SL";
            TextCol1.Width = 30;
            TextCol1.ReadOnly = false;
            TextCol1.Alignment = HorizontalAlignment.Right;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new FormattableTextBoxColumn();
            TextCol1.MappingName = "makp";
            TextCol1.HeaderText = "";
            TextCol1.Width = 0;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new FormattableTextBoxColumn();
            TextCol1.MappingName = "madoituong";
            TextCol1.HeaderText = "";
            TextCol1.Width = 0;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new FormattableTextBoxColumn();
            TextCol1.MappingName = "mavp";
            TextCol1.HeaderText = "";
            TextCol1.Width = 0;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new FormattableTextBoxColumn();
            TextCol1.MappingName = "dongia";
            TextCol1.HeaderText = "";
            TextCol1.Width = 0;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new FormattableTextBoxColumn();
            TextCol1.MappingName = "paid";
            TextCol1.HeaderText = "";
            TextCol1.Width = 0;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new FormattableTextBoxColumn();
            TextCol1.MappingName = "done";
            TextCol1.HeaderText = "";
            TextCol1.Width = 0;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new FormattableTextBoxColumn();
            TextCol1.MappingName = "maql";
            TextCol1.HeaderText = "";
            TextCol1.Width = 0;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new FormattableTextBoxColumn();
            TextCol1.MappingName = "idkhoa";
            TextCol1.HeaderText = "";
            TextCol1.Width = 0;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new FormattableTextBoxColumn();
            TextCol1.MappingName = "vattu";
            TextCol1.HeaderText = "";
            TextCol1.Width = 0;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new FormattableTextBoxColumn();
            TextCol1.MappingName = "tinhtrang";
            TextCol1.HeaderText = "";
            TextCol1.Width = 0;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new FormattableTextBoxColumn();
            TextCol1.MappingName = "thuchien";
            TextCol1.HeaderText = "";
            TextCol1.Width = 0;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new FormattableTextBoxColumn();
            TextCol1.MappingName = "ma";
            TextCol1.HeaderText = "";
            TextCol1.Width = 0;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new FormattableTextBoxColumn();
            TextCol1.MappingName = "ghichu";
            TextCol1.HeaderText = "";
            TextCol1.Width = 0;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);

            TextCol1 = new FormattableTextBoxColumn();
            TextCol1.MappingName = "user";
            TextCol1.HeaderText = "Người nhập";
            TextCol1.Width = 100;
            ts.GridColumnStyles.Add(TextCol1);
            dataGrid1.TableStyles.Add(ts);
        }

        private void SetCellFormat(object sender, DataGridFormatCellEventArgs e)
        {
            try
            {
                if (this.dataGrid1[e.Row, 12].ToString().Trim() == "1" )//|| this.dataGrid1[e.Row, 13].ToString().Trim() == "1")
                    e.ForeBrush = this.disabledTextBrush;//paid
                else if (this.dataGrid1[e.Row, 13].ToString().Trim() == "1")//|| this.dataGrid1[e.Row, 13].ToString().Trim() == "1")
                    e.ForeBrush = this.disabledTextBrush1;//done
                bool discontinued = (bool)((e.Column != 0) ? this.dataGrid1[e.Row, 0] : e.CurrentCellValue);
                if (e.Column > 0 && (bool)(this.dataGrid1[e.Row, 0])) e.ForeBrush = new SolidBrush(Color.Blue);
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
            ref_text();
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
        }

		private void load_grid()
		{
            sql = "select a.id,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay,a.makp,d.tenkp,a.madoituong,c.doituong,a.mavp,b.ten,b.dvt,a.soluong,a.dongia,a.paid,a.done,a.maql,a.idkhoa,a.vattu,a.tinhtrang,a.thuchien,b.ma,a.maicd,a.chandoan,a.mabs,a.loaiba,a.ghichu,b.hoichan,b.ctscannercq ";//,a.chandoansobo
            sql += ", a.tylegiam, a.stgiam, a.lydogiam,a.hide,e.hoten as user ";
            sql += " from xxx.v_chidinh a," + user + ".v_giavp b," + user + ".doituong c," + user + ".btdkp_bv d,"+user+".dlogin e ";
            sql += " where a.mavp=b.id and a.madoituong=c.madoituong and a.makp=d.makp and a.userid=e.id";
            sql += " and a.mabn='" + s_mabn + "'";
            if (l_mavaovien != 0 && i_loaiba == 3)
            {
                if (chkIntheodot.Checked) sql += " and a.mavaovien=" + l_mavaovien;
                else sql += " and a.maql=" + l_maql;
                sql += " and to_char(a.ngay,'dd/mm/yyyy')='" + s_ngay.Substring(0, 10) + "'";
            }
            else if (iChidinh == 2) 
                sql += " and a.maql=" + l_maql;
            else if (iChidinh == 3 && l_idkhoa != 0) 
                sql += " and a.idkhoa=" + l_idkhoa;
            else 
                sql += " and to_char(a.ngay,'dd/mm/yyyy')='" + s_ngay.Substring(0, 10) + "'";
            if (chkIntheodot.Checked == false) 
                sql += " and a.makp='" + s_makp + "'";
            //if (chkIntheodot.Checked == false) sql += " and a.thuchien>0";
            if (tmn_hienthi_phuthu.Checked == false) sql += " and a.hide=0 ";
            sql += " order by a.ngay";
            ds = (iChidinh > 1) ? m.get_data_mmyy(sql, s_ngay_vaovien, s_ngay, true) : m.get_data_nam(nam, sql);
            ds.Tables[0].Columns.Add("Chon", typeof(bool));
            dataGrid1.DataSource = ds.Tables[0];
            CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource, dataGrid1.DataMember];
            DataView dv = (DataView)cm.List;
            dv.AllowNew = false;
            decimal st = 0;
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                row["chon"] = false;
                st += decimal.Parse(row["soluong"].ToString()) * decimal.Parse(row["dongia"].ToString());
            }
            tong.Text = st.ToString("###,###,###");
		}
		private void madoituong_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (madoituong.SelectedIndex==-1) madoituong.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void ten_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) list.Focus(); 
			else if (e.KeyCode==Keys.Enter)
			{
				if (list.Visible) list.Focus();
				else SendKeys.Send("{Tab}");
			}		
		}

		private void ten_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==ten)
			{
				Filter(ten.Text);
				list.BrowseToDanhmuc_ma(ten,mavp,soluong,80);
			}
		}

		private void soluong_Validated(object sender, System.EventArgs e)
		{
			try
			{
				if (soluong.Text=="") soluong.Text="1";
				d_soluong=decimal.Parse(soluong.Text);
				soluong.Text=d_soluong.ToString("###,###.00");
			}
			catch{soluong.Text="1";}
		}

        private void ref_text()
        {
            int _idhoichan = 0, i_ctscannercq = 0;
            try
            {
                i_row = dataGrid1.CurrentCell.RowNumber;
                madoituong.SelectedValue = dataGrid1[i_row, 9].ToString();
                mavp.Text = dataGrid1[i_row, 10].ToString();
                ten.Text = dataGrid1[i_row, 5].ToString();
                s_dvt = dataGrid1[i_row, 6].ToString();
                d_dongia = decimal.Parse(dataGrid1[i_row, 11].ToString());
                d_vattu = decimal.Parse(dataGrid1[i_row, 16].ToString());
                i_paid = int.Parse(dataGrid1[i_row, 12].ToString());
                i_done = int.Parse(dataGrid1[i_row, 13].ToString());
                d_soluong = decimal.Parse(dataGrid1[i_row, 7].ToString());
                soluong.Text = d_soluong.ToString("###,###.00");
                l_id = decimal.Parse(dataGrid1[i_row, 1].ToString());
                tinhtrang.SelectedValue = dataGrid1[i_row, 17].ToString();
                thuchien.SelectedValue = dataGrid1[i_row, 18].ToString();
                ma.Text = dataGrid1[i_row, 19].ToString();
                ghichu.Text = dataGrid1[i_row, 20].ToString();
                DataRow r = m.getrowbyid(ds.Tables[0], "id=" + l_id);
                if (r != null)
                {
                    chandoan.Text = r["chandoan"].ToString();
                    mabs.Text = r["mabs"].ToString();
                    DataRow r1 = m.getrowbyid(dtbs, "ma='" + mabs.Text + "'");
                    tenbs.Text = (r1 != null) ? r1["hoten"].ToString() : "";
                }
                //linh
                DataRow rgiavp = m.getrowbyid(dt, "id=" + mavp.Text);
                if (rgiavp != null)
                {
                    butGiaycamdoanCT.Enabled = rgiavp["giaycamdoan"].ToString() == "1";
                    butPhieukhambenhchupCT.Enabled = rgiavp["ctscannercq"].ToString() == "1";
                    butGiayhoichan.Enabled = rgiavp["hoichan"].ToString() == "1";
                }
                //end linh
            }
            catch { }
        }

		private void Filter(string ten)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[list.DataSource];
				DataView dv=(DataView)cm.List;
				sql="ten like '%"+ten.Trim()+"%'";
				if (madoituong.SelectedValue.ToString()=="1"  && bLocdichvu)
				{
                    if (sothe.Text.Trim().Length >= vitri_jl + sothe_jl.Length && sothe_jl != "")
                    {
                        if (sothe.Text.Substring(vitri_jl - 1, sothe_jl.Length) != sothe_jl)
                        {
                            sql += " and bhyt<>0";
                            if (sothe.Text.Trim().Length > v1 + v2) sql += " and (locthe is null or locthe='' or locthe like '%" + sothe.Text.Substring(v1, v2) + "%' or locthe like '%" + sothe.Text.Substring(0, 2) + ",%')";
                        }
                    }
                    else
                    {
                        sql += " and bhyt<>0";
                        if (sothe.Text.Trim().Length > v1 + v2) sql += " and (locthe='' or locthe is null or locthe like '%" + sothe.Text.Trim().Substring(v1, v2) + "%' or locthe like '%" + sothe.Text.Substring(0, 2) + ",%')";
                    }
				}
				dv.RowFilter=sql;
			}
			catch{}
		}

		private void ena_object(bool ena)
		{
			ma.Enabled=ena;
			if (bMadoituong) madoituong.Enabled=ena;
            chkDoiTuongVao.Enabled = ena;
            ghichu.Enabled = tenbs.Enabled = chandoan.Enabled = tinhtrang.Enabled = txtchandoansobo.Enabled = ena;
			thuchien.Enabled=ena;
			ten.Enabled=ena;
            soluong.Enabled = ena;
            butMoi.Enabled = !ena;
            butSua.Enabled = !ena;
            butHuy.Enabled = !ena;
            butKetthuc.Enabled = !ena;
            butLietke.Enabled = !ena;
            butNet.Enabled = !ena;
            butInct.Enabled = butIn.Enabled = !ena;
            butLuu.Enabled = ena;
            butBoqua.Enabled = ena;
            btchuyen.Enabled = !ena;
            butGiayhoichan.Enabled = !ena;
			//dataGrid1.ReadOnly=!ena;
			if (ena && l_id==0)
			{
				ghichu.Text=ten.Text=ma.Text="";
				soluong.Text="1";
				s_dvt="";i_paid=0;i_done=0;
                chandoan.Text = (s_chandoan != "") ? s_chandoan : chandoan.Text;
                if (mabs.Text != "") s_mabs = mabs.Text;//binh 250711
                mabs.Text = s_mabs;
                DataRow r1 = m.getrowbyid(dtbs, "ma='" + mabs.Text + "'");
                tenbs.Text = (r1 != null) ? r1["hoten"].ToString() : "";
			}
			else butMoi.Focus();
            butPhieukhambenhchupCT.Enabled = false;
		}

		private void butMoi_Click(object sender, System.EventArgs e)
		{
            if (bXemlai && tmp_ngay != m.ngayhienhanh_server && m.bAdminHethong(i_userid) == false)
            {
                MessageBox.Show(lan.Change_language_MessageText("Bạn chỉ được phép xem lại chứ không được phép nhập thêm."));
                return;
            }
            if (bInchitiet && i_loaiba==3)
            {
                string tenkp = m.inchiphipk(s_ngay, l_mavaovien);
                if (tenkp != "")
                {
                    MessageBox.Show(lan.Change_language_MessageText("Đã in chi phí tại")+" " + tenkp + " !", LibMedi.AccessData.Msg);
                    return;
                }
            }
            //string _ngay = m.ngayhienhanh_server.Substring(0, 10);
            ////tmp_ngay = s_ngay;
            //if (s_ngay.Substring(0, 10) != _ngay && i_loaiba == 2)
            //{
            //    MessageBox.Show(lan.Change_language_MessageText("Ngày chỉ định không được khác ngày hiện hành")+" " + _ngay, LibMedi.AccessData.Msg);
            //    return;
            //} //Khuong 17/11/2011 comment, khong kiem tra ngay chi dinh doi voi benh an ngoai tru
			l_id=0;
			ena_object(true);
            bNew = true;
            //s_ngay = tmp_ngay;
			madoituong.SelectedValue=i_madoituong.ToString();
            madoituong.Update();
            //                        
            //
            if (tinhtrang.Items.Count > 0) tinhtrang.SelectedIndex = 0;
            if (thuchien.Items.Count > 0) thuchien.SelectedIndex = 0;
            //
            if (tenbs.Text == "" && tenbs.Enabled) tenbs.Focus();
            else if (chandoan.Text == "" && chandoan.Enabled) 
                chandoan.Focus();
            else ma.Focus();
		}

		private void butSua_Click(object sender, System.EventArgs e)
		{
			if (ds.Tables[0].Rows.Count==0) return;
            if (bXemlai && tmp_ngay != m.ngayhienhanh_server && m.bAdminHethong(i_userid) == false)
            {
                MessageBox.Show(lan.Change_language_MessageText(("Bạn chỉ được phép xem lại chứ không được phép sửa.")));
                return;
            }
            if (bInchitiet && i_loaiba==3)
            {
                string tenkp = m.inchiphipk(s_ngay, l_mavaovien);
                if (tenkp != "")
                {
                    MessageBox.Show(lan.Change_language_MessageText("Đã in chi phí tại")+" " + tenkp + " !", LibMedi.AccessData.Msg);
                    return;
                }
            }
            if (!bAdminHethong && bChidinh_dain_khongchohuy && l_id > 0)
            {
                if (m.get_dain_chidinh(m.mmyy(s_ngay), l_id))
                {
                    MessageBox.Show("Đã in phiếu chỉ định, không cho phép sửa.\nĐề nghị liên hệ với người quản trị hệ thống.!", LibMedi.AccessData.Msg);
                    return ;
                }
            }
            
			try
			{
				i_row=dataGrid1.CurrentCell.RowNumber;
                bool bFound = true;
                i_row = dataGrid1.CurrentCell.RowNumber;
                l_id = decimal.Parse(dataGrid1[i_row, 1].ToString());
                tmp_ngay = s_ngay;
                s_ngay = dataGrid1[i_row, 3].ToString();
                DataTable tmp= m.getChidinh(s_ngay, l_id);
                if (tmp.Rows.Count > 0)
                {
                    if (tmp.Rows[0]["paid"].ToString() != "1")
                    {
                        DataTable tmp_cl = m.getChidinh_chenhlech_dathanhtoan(s_ngay, decimal.Parse(tmp.Rows[0]["maql"].ToString()), int.Parse(tmp.Rows[0]["mavp"].ToString()));
                        if (tmp_cl.Rows.Count > 0)
                        {
                            MessageBox.Show(lan.Change_language_MessageText("Dịch vụ đã đóng tiền phần chênh lệch, không thể sửa !"), LibMedi.AccessData.Msg);
                            return;
                        }
                    }
                    if (tmp.Rows[0]["hide"].ToString() == "1")
                    {
                        MessageBox.Show(lan.Change_language_MessageText(("Số liệu chênh lệch không cho phép sửa !")));
                        return;
                    }
                    if (tmp.Rows[0]["paid"].ToString() == "1" || tmp.Rows[0]["done"].ToString() == "1")//(dataGrid1[i_row,12].ToString()=="1" || dataGrid1[i_row,13].ToString()=="1")
                    {
                        bFound = false;
                        if (tmp.Rows[0]["done"].ToString() == "1" && tmp.Rows[0]["paid"].ToString() == "0")//(dataGrid1[i_row, 13].ToString() == "1" && dataGrid1[i_row, 12].ToString() == "0")
                        {
                            DataRow r = m.getrowbyid(ds.Tables[0], "id=" + l_id);
                            if (r != null)
                            {
                                if (int.Parse(r["madoituong"].ToString()) == i_tunguyen)
                                    bFound = m.getrowbyid(dt, "chenhlech=1 and id=" + decimal.Parse(r["mavp"].ToString())) != null;
                            }
                        }
                    }
                }
                if (!bFound)
                {
					DialogResult dlg= MessageBox.Show(lan.Change_language_MessageText("Số liệu đã cập nhật không thể sửa !\nBạn có muốn nhập bổ sung thêm không?"),LibMedi.AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (dlg == DialogResult.No)
                        return;
                    else
                    {
                        l_id = 0;
                    }
				}
			}
			catch{l_id=0;}
            bNew = false;
			ena_object(true);
			ten.Focus();
		}

		private bool kiemtra()
		{
			if (madoituong.SelectedIndex==-1)
			{
				madoituong.Focus();
				return false;
			}
            if (madoituong.SelectedValue.ToString() == "1" && chandoan.Text == "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Đề nghị nhập chẩn đoán."));
                chandoan.Enabled = true;
                chandoan.Focus();
                return false;
            }
			if (tinhtrang.SelectedIndex==-1)
			{
				tinhtrang.Focus();
				return false;
			}
			if (thuchien.SelectedIndex==-1)
			{
				thuchien.Focus();
				return false;
			}
			if (ten.Text=="" || mavp.Text=="")
			{
				ten.Focus();
				return false;
			}
			if (soluong.Text=="")
			{
				soluong.Focus();
				return false;
			}
            if (bCD_BS_Chidinh || madoituong.SelectedValue.ToString()=="1")
            {
                if (tenbs.Text == "")
                {
                    MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập bác sỹ "), LibMedi.AccessData.Msg);
                    tenbs.Focus();
                    return false;
                }
                if (chandoan.Text == "")
                {
                    MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập chẩn đoán "), LibMedi.AccessData.Msg);
                    chandoan.Focus();
                    return false;
                }
            }
            if (madoituong.SelectedIndex != -1)
            {
                if (i_madoituongvao != 1 && int.Parse(madoituong.SelectedValue.ToString()) == 1)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Người bệnh này không phải đối tượng") + " " + madoituong.Text);
                    madoituong.Focus();
                    return false;
                }
            }
            if (i_loaiba == 1)
            {
                DataRow r_hd = d.getrowbyid(dthoten, "mabn='" + mabn.Text + "'");
                if (r_hd == null)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Người bệnh này không hợp lệ !"), LibMedi.AccessData.Msg);
                    try
                    {
                        mabn.Focus();
                    }
                    catch { }
                    return false;
                }
            }
			return true;
		}

        /// <summary>
        /// Dong Them
        /// </summary>
        /// <param name="idvp"></param>
        private void f_bnmien(int idvp)
        {
            foreach (DataRow r in m.get_data(" select id_loai from " + user + ".v_giavp where id=" + idvp).Tables[0].Rows)
            {
                sql = "select mabn,mavaovien,tyle as tylemien from " + user + ".tylemien_km a inner join medibv.v_nhommien b on a.id_nhommien=b.id where a.mabn='" + s_mabn + "' and a.mavaovien=" + l_mavaovien + " and b.loaivp like '%+" + r["id_loai"].ToString() + "+%' and b.sudung=1";
                sql += " union ";
                sql += " select mabn,mavaovien,tyle as tylemien from " + user + ".tylemien_mg a inner join medibv.v_nhommien b on a.id_nhommien=b.id where a.mabn='" + s_mabn + "' and a.mavaovien=" + l_mavaovien + " and b.loaivp like '%+" + r["id_loai"].ToString() + "+%' and b.sudung=1";
                sql += " union ";
                sql += " select mabn,mavaovien,tyle as tylemien  from " + user + ".tylemien_ud a inner join medibv.v_nhommien b on a.id_nhommien=b.id where a.mabn='" + s_mabn + "' and a.mavaovien=" + l_mavaovien + " and b.loaivp like '%+" + r["id_loai"].ToString() + "+%' and b.sudung=1";
                sql += " order by mabn";
                ds_bnmien = m.get_data(sql);
            }
        }
        /// <summary>
        /// End Dong
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void butLuu_Click(object sender, System.EventArgs e)
		{
            if (!kiemtra())
            {
                return;
            }
            save();
        }
        //linh
        void save()
        {
            f_bnmien(int.Parse(mavp.Text.Trim()));
            DataRow[] dr = dt.Select("trongoi=1 and id=" + int.Parse(mavp.Text));
            if (!bLocdichvu && madoituong.SelectedValue.ToString() == "1")
            {
                sql = "id=" + decimal.Parse(mavp.Text) + " and bhyt<>0";
                if (sothe.Text.Trim().Length > v1 + v2) sql += " and (locthe='' or locthe is null or locthe like '%" + sothe.Text.Trim().Substring(v1, v2) + "%' or locthe like '%" + sothe.Text.Substring(0, 2) + ",%'or locthe like '%"
                                    + sothe.Text.Substring(vitri_jl - 1, 1) + ",%')";
                if (m.getrowbyid(dt, sql) == null)
                {
                    madoituong.SelectedValue = 2;
                    madoituong.Update();
                }
            }
            decimal st = 0;
            string fie = "gia_th";
            DataRow r;
            int _madt = (madoituong.SelectedIndex != -1) ? int.Parse(madoituong.SelectedValue.ToString()) : 0;
            int tmp_madt = _madt;
            decimal d_dongiachitiet = 0;
            if (dr.Length > 0)
            {
                sql = "select a.*, b.sothe, b.kythuat, b.sothe from " + user + ".v_trongoi a," + user + ".v_giavp b ";
                sql += " where a.id_gia=b.id and a.id=" + int.Parse(mavp.Text);
                if (madoituong.SelectedValue.ToString() == "1" & bLocdichvu) sql += " and b.bhyt>0";
                sql += " order by a.stt";
                foreach (DataRow r1 in v.get_data(sql).Tables[0].Rows)
                {
                    l_id = 0; st = decimal.Parse(r1["sotien"].ToString());
                    i_kythuat = int.Parse(r1["kythuat"].ToString());
                    madoituong.SelectedValue = tmp_madt;
                    madoituong.Update();
                    _madt = int.Parse(madoituong.SelectedValue.ToString());
                    if (madoituong.SelectedValue.ToString() == "1" && sothe.Text.Trim() != "" && r1["sothe"].ToString().Trim().Trim(',') != "")
                    {
                        string s_loaithe_bn = "";
                        if (m.iSokytuthe_xet_chiphivanchuyen == 3)
                        {
                            s_loaithe_bn = sothe.Text.Substring(2,1);
                        }
                        else
                        {
                            s_loaithe_bn = sothe.Text.Substring(0,2);
                        }
                        if (r1["sothe"].ToString().Trim().IndexOf(s_loaithe_bn + ",") < 0)//the khong thuoc nhung The qui dinh --> BHYT khong thanh toan
                        {
                            _madt = 2;
                            madoituong.SelectedValue = _madt;
                            madoituong.Update();
                        }
                    }
                    if (bTrongoi_doituong)
                    {
                        fie = m.field_gia(_madt.ToString());
                        r = m.getrowbyid(dt, "id=" + int.Parse(r1["id_gia"].ToString()));
                        if (r != null) st = decimal.Parse(r[fie].ToString());
                    }
                    if (madoituong.SelectedValue.ToString() == "1")
                    {
                        d_dongiachitiet = 0;
                    }
                    else
                    {
                        d_dongiachitiet = r1["sotien"].ToString() == "" ? 0 : decimal.Parse(r1["sotien"].ToString());
                    }
                    upd_data(int.Parse(r1["id_gia"].ToString()), decimal.Parse(r1["soluong"].ToString()), (int.Parse(r1["madoituong"].ToString()) == 0) ? _madt : int.Parse(r1["madoituong"].ToString()), d_dongiachitiet, int.Parse(r1["id"].ToString()));//thay st bang 0: vi khai bao trong goi, gia phai tinh lai chi tiet tung mon
                    if (s_table == "xxx.tiepdon") upd_tiepdon(decimal.Parse(r1["id"].ToString()), decimal.Parse(r1["id_gia"].ToString()));
                }
                if (l_id == 0)
                    upd_data(int.Parse(mavp.Text), decimal.Parse(soluong.Text), _madt, 0, 0);
                ena_object(false);
            }
            else
            {
                DataRow rvp = m.getrowbyid(dt, "id='" + mavp.Text+"'");
                int i_hoichan = 0 ;
                int ixamlan = 0;
                if (rvp != null)
                {
                    if (madoituong.SelectedValue.ToString() == "1" && sothe.Text.Trim() != "" && rvp["sothe"].ToString().Trim().Trim(',') != "")
                    {
                        string s_loaithe_bn = "";
                        if (m.iSokytuthe_xet_chiphivanchuyen == 3)
                        {
                            s_loaithe_bn = sothe.Text.Substring(2, 1);
                        }
                        else
                        {
                            s_loaithe_bn = sothe.Text.Substring(0, 2);
                        }
                        if (rvp["sothe"].ToString().Trim().IndexOf(s_loaithe_bn + ",") < 0)//the khong thuoc nhung The qui dinh --> BHYT khong thanh toan
                        {
                            _madt = 2;
                            madoituong.SelectedValue = _madt;
                            madoituong.Update();
                        }
                    }
                    i_kythuat = int.Parse(rvp["kythuat"].ToString());
                    i_hoichan = int.Parse(rvp["hoichan"].ToString());
                    ixamlan = int.Parse(rvp["xamlan"].ToString());
                }
                //upd_data(int.Parse(mavp.Text), decimal.Parse(soluong.Text), _madt, 0, 0);
                //linh
                // Dong them
                //i_tutuoi = int.Parse(rvp["tutuoi"].ToString());
                //i_dentuoi = int.Parse(rvp["dentuoi"].ToString());
                //s_gtvp = rvp["gioitinh"].ToString();
                //string s_tghen = rvp["tgtrakq"].ToString();
                //string s_giongay = rvp["giongay"].ToString();
                //string s_cosothay = rvp["cosothay"].ToString();
                //int i_batbuocthutien = int.Parse(rvp["batbuocthutien"].ToString());
                b_chuyenngoaitru = false;
                b_chuyenvien = false;
                b_xuatvien_hen = false;
                tmp_madt = int.Parse(madoituong.SelectedValue.ToString());
                if (f_Kiemtra_ThemVienphi(int.Parse(mavp.Text.Trim())))//, s_giongay))//s_tghen
                {
                    if (ixamlan == 1 && (i_loaiba == 3 || i_loaiba == 0))
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Kỹ thuật này bắt buộc mở hồ sơ ngoại trú") + ".", "Medisoft THIS");//==> chuyển sang form khám bệnh xử lý, tại button chỉ định cận lâm sàng
                        b_chuyenngoaitru = true;
                        madoituong.SelectedValue = "5";
                        madoituong.Update();
                        madoituong.Refresh();
                        upd_data(int.Parse(mavp.Text), decimal.Parse(soluong.Text), 5, 0, 0);
                        this.Close();
                    }
                    else
                    {
                        string s_cosoduocthuchien = rvp["coso"].ToString();
                        i_idchinhanhden = int.Parse(s_cosoduocthuchien);
                        int i_guingoai = int.Parse(rvp["guingoai"].ToString());
                        int i_guinguoi = int.Parse(rvp["guinguoi"].ToString());
                        int i_chuyenchungtu = int.Parse(rvp["chuyenchungtu"].ToString());
                        int i_guimau = int.Parse(rvp["guimau"].ToString());
                        i_trangthai = 0;
                        if (i_guimau == 1 || i_guinguoi == 1 || (i_chuyenchungtu == 1 && tmp_madt == 1))//BINH 270711
                        {
                            string s_tenchinhanhchuyenden = m.f_getten_chinhanh(i_idchinhanhden);
                            if (i_guinguoi == 1)
                            {
                                b_chuyenvien = true;
                                MessageBox.Show(lan.Change_language_MessageText("Kỹ thuật") + ": " + rvp["ten"].ToString() + ".\n" +
                                    lan.Change_language_MessageText("Cần gửi sang") + " " + s_tenchinhanhchuyenden + " " + lan.Change_language_MessageText("để thực hiện.") + "\n" +
                                    lan.Change_language_MessageText("Vui lòng kết thúc màn hình chỉ định để xuất giấy chuyển viện cho bệnh nhân sang chi nhánh") + " " + s_tenchinhanhchuyenden);
                                i_trangthai = 2;
                                //madoituong.SelectedValue = "5";
                                //i_madoituong = 5;
                            }
                            else if (i_guimau == 1)
                            {
                                MessageBox.Show(lan.Change_language_MessageText("Kỹ thuật") + ": " + rvp["ten"].ToString() + ".\n" +
                                    lan.Change_language_MessageText("Cần gửi sang") + " " + s_tenchinhanhchuyenden + " " + lan.Change_language_MessageText("để thực hiện."));
                                i_trangthai = 3;
                            }
                            else if (i_chuyenchungtu == 1)//BINH 270711
                            {
                                MessageBox.Show(lan.Change_language_MessageText("Kỹ thuật") + ": " + rvp["ten"].ToString() + ".\n" +
                                    lan.Change_language_MessageText("Cần chuyển chứng từ sang") + " '" + s_tenchinhanhchuyenden + "'.");
                                i_trangthai = 6;
                            }
                            //upd_data_cosoden(int.Parse(mavp.Text), decimal.Parse(soluong.Text), _madt, 0, 0, s_tendatabasechuyenden, i_idchinhanhden, i_guinguoi);
                        }
                        else if (i_guingoai == 1)
                        {
                            MessageBox.Show(lan.Change_language_MessageText("Kỹ thuật") + ": " + rvp["ten"].ToString() + ".\n" +
                                    lan.Change_language_MessageText("Cần gửi sang bệnh viện khác để trả kết quả."));
                            i_trangthai = 4;
                        }
                        if (!b_chuyenvien)
                        {
                            string s_thoigiantraketqua = rvp["tgtrakq"].ToString().PadLeft(10, '0');
                            string s_loaithoigian = s_thoigiantraketqua.Substring(0, 1);
                            string s_thoigian = s_thoigiantraketqua.Substring(1, 7).Trim('-');
                            string s_donvitinh = s_thoigiantraketqua.Substring(9, 1).Trim('-');
                            double d_thoigian = double.Parse(s_thoigian);
                            if ((s_donvitinh == "0" && d_thoigian >= 24) || (s_donvitinh == "1" && d_thoigian > 0)) //hơn 24h hoặc hơn 1 ngày -> hẹn
                            {
                                b_xuatvien_hen = true;
                                if (s_donvitinh == "0")
                                {
                                    i_songayhen = (int)Math.Floor(d_thoigian / 24);
                                }
                                else
                                {
                                    i_songayhen = (int)Math.Floor(d_thoigian);
                                }
                                s_donvitinh = (s_donvitinh == "1" ? lan.Change_language_MessageText("Ngày") : lan.Change_language_MessageText("Giờ"));
                                s_loaithoigian = (s_loaithoigian == "1" ? lan.Change_language_MessageText("Sau") : "");
                                MessageBox.Show(lan.Change_language_MessageText("Kỹ thuật") + ": " + rvp["ten"].ToString() + ".\n" +
                                    lan.Change_language_MessageText("Có thời gian trả kết là") + " " + s_loaithoigian + " " + d_thoigian.ToString() + " " + s_donvitinh + ".\n" +
                                    lan.Change_language_MessageText("Bạn cần phải hẹn bệnh nhân") + " " + i_songayhen.ToString() + " " + lan.Change_language_MessageText("ngày") + " " +
                                    lan.Change_language_MessageText("để lấy kết quả") + ".");
                            }
                        }
                        //    s_tendatabasechuyenden = m.get_Tendatabase(i_idchinhanhden);
                        //    s_mabv = m.get_mabv(i_idchinhanhden);
                        //    DialogResult dlr = MessageBox.Show(lan.Change_language_MessageText(" Cở cở này không thực hiện CLS này, bạn có muốn chuyển đến cơ sở") + " " + s_tendatabasechuyenden + " " + lan.Change_language_MessageText("để thực hiện cls."), "Medisoft 2007", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                        //    if (dlr == DialogResult.Yes)
                        //    {
                        //        //upd_data(int.Parse(mavp.Text), decimal.Parse(soluong.Text), _madt, 0, 0, i_idchinhanhden, i_batbuocthutien);
                        //        upd_data_cosoden(int.Parse(mavp.Text), decimal.Parse(soluong.Text), _madt, 0, 0, s_tendatabasechuyenden, i_idchinhanhden, i_batbuocthutien);
                        //        getTong();
                        //        load_grid();
                        //        ena_object(false);
                        //    }
                        //    f_chuyenvien(s_mabv);
                        //}
                        //else
                        //{
                        //    upd_data(int.Parse(mavp.Text), decimal.Parse(soluong.Text), _madt, 0, 0);
                        //    getTong();
                        //    load_grid();
                        //    ena_object(false);
                        //}
                        //}
                        // else
                        //{
                        if (decimal.Parse(soluong.Text) > 1 && m.bXetnghiem_cdha(mavp.Text))// gam 07/12/2011 nếu chỉ định viện phí thuộc nhóm xét nghiệm hoặc CDHA thì insert số dòng = số lượng
                        {
                            for (int i = 0; i < decimal.Parse(soluong.Text); i++)
                            {
                                upd_data(int.Parse(mavp.Text), 1, _madt, 0, 0);
                                l_id = 0;
                                b_cholai = true;
                            }
                            b_cholai = false;
                        }
                        else
                        {
                            upd_data(int.Parse(mavp.Text), decimal.Parse(soluong.Text), _madt, 0, 0);
                        }
                        // }
                        getTong();
                        //load_grid(); //Tu: 11/08/2011 comment khi them moi thi check những chỉ định mới, --> in 
                        ena_object(false);

                        madoituong.SelectedValue = tmp_madt;//binh 240711
                        //i_madoituong = tmp_madt; //Khuong 04/11/2011 comment: tai sao lai doi doi tuong ban dau cua bn???
                        if (bchuyenclsvathongtinbnsangcnkhac)
                        {
                            if (i_guimau == 1 || i_guinguoi == 1)
                            {
                                frmChuyenDataksk f = new frmChuyenDataksk(mabn.Text);
                                f.ShowDialog(this);
                            }
                        }
                    }
                }
            }
        }
        /*
        private void f_chuyenvien( string tenbv)
        { 
            DataSet dschuyenvien = new DataSet();
            if (tenbv != "")
            {
                sql = " select a.mabn,a.maql,to_char(a.ngay,'dd/mm/yyyy hh24:mi') ngaykham,";
                sql += "c.hoten,c.ngaysinh,c.namsinh,c.phai,c.cmnd,c.msthue,c.sonha,c.thon,c.cholam,"; ;
                sql += "d.tennn,e.dantoc,f.tentt,g.tenquan,h.tenpxa,b.sothe,j.doituong,i.hoten tenbs,m.tenbv noidkkcb,a.chandoan,a.maicd,n.tenkp";
                sql += " from " + user + m.mmyy(s_ngay) + ".benhanpk a left join " + user + m.mmyy(s_ngay) + ".bhyt b on a.mabn=b.mabn and a.maql=b.maql inner join " + user + ".btdbn c on a.mabn=c.mabn ";
                sql += " left join " + user + ".btdnn d on c.mann=d.mann left join " + user + ".btddt e on c.madantoc=e.madantoc left join " + user + ".btdtt f on c.matt=f.matt";
                sql += " left join " + user + ".btdquan g on c.maqu=g.maqu left join " + user + ".btdpxa h on c.maphuongxa=h.maphuongxa";
                sql += " inner join " + user + ".doituong j on a.madoituong=j.madoituong inner join " + user + ".dmbs i on a.mabs=i.ma";
                sql += " left join " + user + ".tenvien m on b.mabv=m.ma_cskcb and m.mabv='" + tenbv + "'";
                sql += " left join " + user + ".btdkp_bv n on a.makp=n.makp";
                sql += " where a.maql=" + l_maql + " and a.mabn='" + s_mabn + "'";
                dschuyenvien = m.get_data(sql);
                if (!System.IO.Directory.Exists("..//..//dataxml"))
                {
                    System.IO.Directory.CreateDirectory("..//..//dataxml");
                }
                dschuyenvien.WriteXml("..//..//dataxml//rptGiaycv_cd.xml", XmlWriteMode.WriteSchema);
                dllReportM.frmReport fr = new dllReportM.frmReport(m, dschuyenvien, s_ngay.Substring(0, 10), "rptGiaycv_cd.rpt");
                fr.ShowDialog();
            }
        }
        */
        private bool f_Kiemtra_ThemVienphi(int i_mavp)//, string s_gn)// string s_hen,//end linh
        {
            string s_mavpxungdot = "";
            int i_ktraxungdot;
            s_mavpxungdot = m.mavpxungdot(i_mavp) + ",";
            if (s_mavpxungdot != "")
            {
                //string[] Arr = s_mavpxungdot.Split(',');
                //for (int i = 0; i < Arr.Length; i++)
                //{
                //i_ktraxungdot = int.Parse(Arr[i].ToString());
                string s_sql = "select a.mavp,b.ten from xxx.v_chidinh a left join " + user + ".v_giavp b on a.mavp=b.id where a.mavaovien=" + l_mavaovien + " and a.mabn='" + s_mabn + "'" +
                    " and mavp not in(" + i_mavp.ToString()+")";
                foreach (DataRow dr in m.get_data_mmyy(s_sql, s_ngay.Substring(0, 10), s_ngay.Substring(0, 10), true).Tables[0].Rows)
                {
                    int i_mavpxd = int.Parse(dr["mavp"].ToString());
                    string s_tenvpxungdot = dr["ten"].ToString();
                    //if (i_ktraxungdot == i_mavpxd)
                    if (s_mavpxungdot.IndexOf(i_mavpxd.ToString() + ",") > -1)
                    {
                        DialogResult dl = MessageBox.Show(lan.Change_language_MessageText("Kỹ thuật này xung đột với") + " " + s_tenvpxungdot + "\n" +
                            "Bạn có muốn nhập thêm không?", " Medisoft THIS", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                        if (dl == DialogResult.No)
                        {
                            ten.Focus();
                            return false;
                        }
                    }
                }
                //}
            }
            //linh
            DataRow rvp = m.getrowbyid(dt, "id=" + i_mavp.ToString());
            if (rvp != null)
            {
                string s_gtvp = rvp["gioitinh"].ToString();
                if (s_gtvp.IndexOf(s_gioitinh) == -1 && s_gtvp != "")
                {
                    if(MessageBox.Show(lan.Change_language_MessageText("Giới tính không hợp lệ so với danh mục giá viện phí đã khai báo")+".\n"+
                        lan.Change_language_MessageText("Bạn có muốn nhập dịch vụ này không")+"?", "Medisoft THIS", 
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)==DialogResult.No)
                    {
                        return false;
                    }
                }
                string s_tutuoi = rvp["tutuoi"].ToString().TrimStart('0');
                string s_dentuoi = rvp["dentuoi"].ToString().TrimStart('0');
                int i_tutuoi = -1, i_dentuoi = -1;
                if (s_tutuoi != "" && s_dentuoi == "")
                {
                    i_tutuoi = int.Parse(s_tutuoi);
                    if (i_tuoi < i_tutuoi)
                    {
                        if (MessageBox.Show(lan.Change_language_MessageText("Tuổi không hợp lệ so với danh mục giá viện phí đã khai báo") + ".\n" +
                            lan.Change_language_MessageText("Bạn có muốn nhập dịch vụ này không") + "?", " Medisoft THIS",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.No)
                        {
                            return false;
                        }
                    }
                }
                else if (s_dentuoi != "" && s_tutuoi == "")
                {
                    i_dentuoi = int.Parse(s_dentuoi);
                    if (i_tuoi > i_dentuoi)
                    {
                        if (MessageBox.Show(lan.Change_language_MessageText("Tuổi không hợp lệ so với danh mục giá viện phí đã khai báo") + ".\n" +
                            lan.Change_language_MessageText("Bạn có muốn nhập dịch vụ này không") + "?", " Medisoft THIS",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.No)
                        {
                            return false;
                        }
                    }
                }
                else if (s_dentuoi != "" && s_tutuoi != "")
                {
                    i_dentuoi = int.Parse(s_dentuoi);
                    i_tutuoi = int.Parse(s_tutuoi);
                    if (i_tuoi > i_dentuoi || i_tuoi < i_tutuoi)
                    {
                        if (MessageBox.Show(lan.Change_language_MessageText("Tuổi không hợp lệ so với danh mục giá viện phí đã khai báo") + ".\n" +
                            lan.Change_language_MessageText("Bạn có muốn nhập dịch vụ này không") + "?", " Medisoft THIS",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.No)
                        {
                            return false;
                        }
                    }
                }
                //if ((i_tutuoi != 0 && i_dentuoi != 0) && (i_tuoi < i_tutuoi || i_tuoi > i_dentuoi))
                //{
                //    DialogResult dl = MessageBox.Show(lan.Change_language_MessageText("Tuổi không họp lệ so với danh mục giá viện phí đã khai báo."), " Medisoft 2007", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                //    if (dl == DialogResult.No)
                //    {
                //        ten.Focus();
                //        return false;
                //    }
                //}
            }
            //linh :bỏ -> đem lên trên butluu_click
            /*
            if (s_hen.Trim() != "00" && s_hen != "")
            {
                //0: gio , 1: ngay
                if (s_gn == "0")
                {
                    DialogResult dl = MessageBox.Show(lan.Change_language_MessageText("Bạn phải nhớ in giấy hẹn " + s_hen + " giờ cho bệnh nhân."), " Medisoft 2007", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (dl == DialogResult.Yes)
                    {
                        ///update benhanpk set henlay ket qua khi chi dinh co thoi gian hen tra ket qua.
                        if(i_loaiba==3|| i_loaiba==4 || i_loai==0 || i_loaiba==2)
                        {
                            m.execute_data(" update " + user + m.mmyy(s_ngay) + ".xutrikbct set xutri=xutri||'03,' where maql=" + l_maql);
                        }
                    }
                }
                if (s_gn == "1")
                {
                    DialogResult dl = MessageBox.Show(lan.Change_language_MessageText("Bạn phải nhớ in giấy hẹn " + s_hen + " ngày cho bệnh nhân."), " Medisoft 2007", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (dl == DialogResult.Yes)
                    {
                        ///update benhanpk set henlay ket qua khi chi dinh co thoi gian hen tra ket qua.
                        if (i_loaiba == 3 || i_loaiba == 4 || i_loai == 0 || i_loaiba == 2)
                        {
                            m.execute_data(" update " + user + m.mmyy(s_ngay) + ".xutrikbct set xutri=xutri||'03,' where maql=" + l_maql);
                        }
                    }
                }
            }
            if (ixamlan == 1)
            {
                DialogResult dl = MessageBox.Show(lan.Change_language_MessageText(" Kỹ thuật này thuộc xâm lấn bạn có làm tường trình phẫu thuật, thủ thuật không."), " Medisoft 2007", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (dl == DialogResult.No)
                {
                    ten.Focus();
                    return false;
                }
            }*/
            //end linh
            if (s_idvienphi_icd10 != "")
            {
                if (s_idvienphi_icd10.IndexOf(mavp.ToString()+",") != -1)
                {
                    DialogResult dl = MessageBox.Show(lan.Change_language_MessageText("Chỉ định không phù hợp với chẩn đoán của ICD10. Bạn có đồng ý cho không? "), " Medisoft THIS", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                    if (dl == DialogResult.No)
                    {
                        ten.Focus();
                        return false;
                    }
                }
            }
            return true;
        }
        private void upd_tiepdon(decimal idgiavp,decimal id)
        {
            DataTable tmp = m.get_data("select * from " + user + ".v_trongoipk where idgiavp="+idgiavp+" and id=" + id + " order by stt").Tables[0];
            if (tmp.Rows.Count > 0)
            {
                decimal _maql = 0; string xxx = user + m.mmyy(s_ngay);
                sql = "select a.*,b.sonha,b.thon,b.cholam,b.matt,b.maqu,b.maphuongxa,coalesce(c.sothe,'') as sothe,to_char(c.tungay,'dd/mm/yyyy') as tungay,";
                sql += " to_char(c.denngay,'dd/mm/yyyy') as denngay,coalesce(c.mabv,'') as mabv,";
                sql += " to_char(c.ngay1,'dd/mm/yyyy') as ngay1,";
                sql += " to_char(c.ngay2,'dd/mm/yyyy') as ngay2,to_char(c.ngay3,'dd/mm/yyyy') as ngay3,c.traituyen";
                sql += " from " + xxx + ".tiepdon a inner join " + user + ".btdbn b on a.mabn=b.mabn ";
                sql += " left join " + xxx + ".bhyt c on a.maql=c.maql where a.maql=" + l_maql;
                int j = 1;
                foreach (DataRow r1 in m.get_data(sql).Tables[0].Rows)
                {
                    foreach (DataRow r in tmp.Rows)
                    {
                        DateTime dtime = m.StringToDateTime(s_ngay).AddMinutes(j);
                        string ngay = s_ngay.Substring(0, 10) + " " + dtime.Hour.ToString().PadLeft(2, '0') + ":" + dtime.Minute.ToString().PadLeft(2, '0');
                        _maql = m.getidyymmddhhmiss_stt_computer;
                        m.upd_tiepdon(s_mabn, l_maql, _maql,r["makp"].ToString(),ngay, int.Parse(r1["madoituong"].ToString()),r1["sovaovien"].ToString(),r1["tuoivao"].ToString(),i_userid,int.Parse(r1["bnmoi"].ToString()),int.Parse(r1["noitiepdon"].ToString()),int.Parse(r1["loai"].ToString()));
                        if (r1["sothe"].ToString().Trim()!="")
                            m.upd_bhyt(ngay, s_mabn, _maql, r1["sothe"].ToString(), r1["denngay"].ToString(), r1["mabv"].ToString(), 0, r1["tungay"].ToString(), r1["ngay1"].ToString(), r1["ngay2"].ToString(), r1["ngay3"].ToString(),int.Parse(r1["traituyen"].ToString()));
                        m.upd_sukien(ngay, s_mabn, l_maql,int.Parse(r1["noitiepdon"].ToString()),_maql);
                        m.upd_lienhe(ngay, _maql,r1["sonha"].ToString(),r1["thon"].ToString(),r1["cholam"].ToString(),r1["matt"].ToString(),r1["maqu"].ToString(),r1["maphuongxa"].ToString(),r1["tuoivao"].ToString(),int.Parse(r1["loai"].ToString()),int.Parse(r1["bnmoi"].ToString()));
                        j++;
                    }
                }
                m.execute_data("update " + xxx + ".tiepdon set done='x' where maql=" + l_maql + " and done is null");
            }
        }
        //linh
        /*
        /// <summary>
        /// Dong inser du lieu vao data base co so den thuc hien. 
        private void upd_data_cosoden(int i_mavp, decimal d_soluong, int i_madt, decimal dongia, int idtrongoi,string stendatabase,int icosoden,int ibatbuocthutien)
        {
            string xxx = m.user + m.mmyy(s_ngay);
            bool bCont = false;
            string fie = "gia_bh";
            int s_doituong_chenhlech = (i_madt == i_tunguyen || i_madt == i_madoituongvao) ? i_madoituongvao : i_madt;//binh 050109
            DataRow r = m.getrowbyid(dtdt, "madoituong=" + s_doituong_chenhlech);//binh 050109
            if (r != null) { fie = r["field_gia"].ToString(); bCont = r["chenhlech"].ToString() == "1"; }
            else bCont = false;
            bCont = bCont && bChenhlech;//kiem tra co check G27
            r = m.getrowbyid(dt, "id=" + i_mavp);
            if (r != null)
            {
                if (bChenhlech_doituong)
                    bCont = bCont && s_chenhlech.IndexOf(i_madoituongvao.ToString().Trim() + ",") != -1;
                else bCont = bCont && s_chenhlech.IndexOf(i_madt.ToString().Trim() + ",") != -1;
                bCont = bCont && r["chenhlech"].ToString().Trim() == "1"
                        && decimal.Parse(r[m.field_gia(i_tunguyen.ToString())].ToString()) > decimal.Parse(r[fie].ToString());
                if (!bChidinh_thutienlien) bCont = bCont && i_loaiba == 3;
                if (bChenhlech_doituong) bCont = bCont && (i_madt == i_tunguyen);
                if (i_madoituongvao == 1) bCont = bCont && (decimal.Parse(r["bhyt"].ToString()) > 0);
                bool b_chenhlechngaynghi = bChenhlechPK_chitinh_vaongaynghi && r["chenhlech"].ToString().Trim() == "1" && decimal.Parse(r[m.field_gia(i_tunguyen.ToString())].ToString()) > decimal.Parse(r[fie].ToString());
                if (bCont || b_chenhlechngaynghi)
                {
                    madoituong.SelectedValue = i_madoituongvao.ToString();
                    madoituong.Update();
                    upd_detail(false, i_mavp, d_soluong, dongia, idtrongoi, false);
                    m.execute_data_client("update " + xxx + ".v_chidinh@" + stendatabase + " set dachenhlech=1 where id=" + l_id + " and mavp=" + i_mavp);
                    l_id = 0;
                    madoituong.SelectedValue = i_tunguyen.ToString();
                    madoituong.Update();
                    upd_detail(true, i_mavp, d_soluong, dongia, idtrongoi, true);
                    m.execute_data_client("update " + xxx + ".v_chidinh@" + stendatabase + " set dachenhlech=1 where id=" + l_id + " and mavp=" + i_mavp);
                }
                else
                {
                    madoituong.SelectedValue = i_madt.ToString();
                    madoituong.Update();
                    upd_detail_cosoden(false, i_mavp, d_soluong, dongia, idtrongoi, stendatabase, icosoden, icosoden);
                }
            }
        }
        private void upd_detail_cosoden(bool chenhlech, int i_mavp, decimal d_soluong, decimal dongia, int idtrongoi, string stendatabse,int icosoden,int ibatbuocthutien)
        {
            string gia, giavt;
            decimal tygia, dg_giam = 0, vt_giam = 0, d_tyle_traituyen = 1;
            DataRow r = m.getrowbyid(dt, "id=" + i_mavp);
            if (r != null)
            {
                if (chenhlech)
                {
                    gia = m.field_gia(madoituong.SelectedValue.ToString());
                    giavt = "vattu_" + gia.Substring(4).Trim();
                    tygia = (gia.IndexOf("_nn") != -1) ? m.dTygia : 1;
                    d_dongia = decimal.Parse(r[gia].ToString()) * tygia - decimal.Parse(r["gia_bh"].ToString());
                    d_vattu = decimal.Parse(r[giavt].ToString()) * tygia - (decimal.Parse(r["vattu_bh"].ToString()));
                    if (cl_tyle != 0 && cl_cholam != "")
                    {
                        string scholam = m.get_cholam(mabn.Text).ToString().Trim().ToLower();
                        if (cl_cholam.IndexOf(scholam) != -1 && scholam != "")
                        {
                            dg_giam = d_dongia * (cl_tyle / 100);
                            vt_giam = d_vattu * (cl_tyle / 100);
                            d_dongia -= dg_giam;
                            d_vattu -= vt_giam;
                        }
                    }
                }
                else
                {
                    gia = m.field_gia(madoituong.SelectedValue.ToString());
                    giavt = "vattu_" + gia.Substring(4).Trim();
                    tygia = (gia.IndexOf("_nn") != -1) ? m.dTygia : 1;
                    d_dongia = decimal.Parse(r[gia].ToString()) * tygia;// *d_tyle_traituyen;
                    d_vattu = decimal.Parse(r[giavt].ToString()) * tygia;
                }
                int itable = m.tableid(m.mmyy(s_ngay), "v_chidinh");
                if (l_id == 0)
                {
                    l_id = v.get_id_chidinh;
                    m.upd_eve_tables(s_ngay, itable, i_userid, "ins");
                }
                else
                {
                    m.upd_eve_tables(s_ngay, itable, i_userid, "upd");
                    m.upd_eve_upd_del(s_ngay, itable, i_userid, "upd", l_id.ToString() + "^" + s_mabn + "^" + l_mavaovien.ToString() + "^" + l_maql.ToString() + "^" + l_idkhoa.ToString() + "^" + s_ngay + "^" + i_loai.ToString() + "^" + s_makp + "^" + madoituong.SelectedValue.ToString() + "^" + i_mavp.ToString() + "^" + d_soluong.ToString() + "^" + d_dongia.ToString() + "^" + d_vattu.ToString() + "^" + i_userid.ToString() + "^" + tinhtrang.SelectedValue.ToString() + "^" + thuchien.SelectedValue.ToString());
                }
                if (ibatbuocthutien == 1)
                {
                    if (f_Kiemtrabatbuocthutien(stendatabse, ibatbuocthutien))
                    {
                        if (!m.upd_chidinh_cosoden(l_id, s_mabn, l_mavaovien, l_maql, l_idkhoa, s_ngay, i_loai, s_makp, int.Parse(madoituong.SelectedValue.ToString()), i_mavp, d_soluong, (dongia != 0) ? dongia : d_dongia, (dongia != 0) ? 0 : d_vattu, i_userid, int.Parse(tinhtrang.SelectedValue.ToString()), int.Parse(thuchien.SelectedValue.ToString()), l_idchidinh, (s_maicd == "" && chandoan.Text != "") ? "U00" : s_maicd, chandoan.Text, mabs.Text, i_loaiba, ghichu.Text, stendatabse))
                        {
                            MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin chỉ định !"), LibMedi.AccessData.Msg);
                            return;
                        }
                        else
                        {
                            m.execute_data_client("update " + user + m.mmyy(s_ngay) + ".v_chidinh@" + stendatabse + " set paid=1,done=0 where id=" + l_id);
                            m.execute_data("update " + user + m.mmyy(s_ngay) + ".v_chidinh set paid=0,done=3 where id=" + l_id);
                        }
                    }
                }
                else
                {
                    if (f_Kiemtrabatbuocthutien(stendatabse, ibatbuocthutien))
                    {
                        m.execute_data("update " + user + m.mmyy(s_ngay) + ".v_chidinh set paid=1,done=3 where id=" + l_id);
                    }
                }
                if (chenhlech)
                {
                    if (!bNew)
                        m.execute_data_client("delete from " + user + m.mmyy(s_ngay) + ".v_chidinh@" + stendatabse + " where paid=0 and hide=1 and maql=" + l_maql + " and idkhoa=" + l_idkhoa + " and mavp=" + i_mavp + " and to_char(ngay,'dd/mm/yyyy')='" + s_ngay.Substring(0, 10) + "'");
                    m.execute_data_client("update " + user + m.mmyy(s_ngay) + ".v_chidinh@" + stendatabse + " set done=1,hide=1 where done=0 and id=" + l_id);
                }
                if (idtrongoi != 0)
                    m.execute_data_client("update " + user + m.mmyy(s_ngay) + ".v_chidinh@" + stendatabse + " set idtrongoi=" + idtrongoi + " where id=" + l_id);
                m.execute_data_client("update " + user + m.mmyy(s_ngay.Substring(0, 10)) + ".v_chidinh@" + stendatabse + " set traituyen=" + i_traituyen + " where id =" + l_id);
                if (bChidinh_exp_txt) 
                    m.exp_chidinh(m.mmyy(s_ngay), l_id.ToString(), "0");
                m.execute_data_client("update " + user + m.mmyy(s_ngay) + ".v_chidinh@" + stendatabse + " set traituyen=" + i_traituyen + " where id=" + l_id);
                m.updrec_chidinh(ds.Tables[0], l_id, s_ngay, s_makp, s_tenkp, int.Parse(madoituong.SelectedValue.ToString()), madoituong.Text, i_mavp, r["ten"].ToString(), r["dvt"].ToString(), d_soluong, (dongia != 0) ? dongia : d_dongia, (dongia != 0) ? 0 : d_vattu, 0, 0, int.Parse(tinhtrang.SelectedValue.ToString()), int.Parse(thuchien.SelectedValue.ToString()), r["ma"].ToString(), (s_maicd == "" && chandoan.Text != "") ? "U00" : s_maicd, chandoan.Text, mabs.Text, i_loaiba, ghichu.Text, 0, 0, "");
                DataRow[] dr = ds.Tables[0].Select("id=" + l_id);
                if (dr.Length > 0)
                {
                    dr[0]["chon"] = true;
                    if (chenhlech && dr[0]["done"].ToString() == "0") dr[0]["done"] = 1;
                }
                if (dg_giam != 0)
                {
                    l_id = v.get_id_chidinh;
                    m.upd_chidinh_cosoden(l_id, s_mabn, l_mavaovien, l_maql, l_idkhoa, s_ngay, i_loai, s_makp, cl_doituong, i_mavp, d_soluong, dg_giam, vt_giam, i_userid, int.Parse(tinhtrang.SelectedValue.ToString()), int.Parse(thuchien.SelectedValue.ToString()), l_idchidinh, (s_maicd == "" && chandoan.Text != "") ? "U00" : s_maicd, chandoan.Text, mabs.Text, i_loaiba, ghichu.Text, stendatabse);
                    m.execute_data_client("update " + user + m.mmyy(s_ngay) + ".v_chidinh@" + stendatabse + " set done=0,hide=1,traituyen=" + i_traituyen + " where done=0 and id=" + l_id);
                    m.updrec_chidinh(ds.Tables[0], l_id, s_ngay, s_makp, s_tenkp, cl_doituong, cl_tendoituong, i_mavp, r["ten"].ToString(), r["dvt"].ToString(), d_soluong, dg_giam, vt_giam, 0, 0, int.Parse(tinhtrang.SelectedValue.ToString()), int.Parse(thuchien.SelectedValue.ToString()), r["ma"].ToString(), (s_maicd == "" && chandoan.Text != "") ? "U00" : s_maicd, chandoan.Text, mabs.Text, i_loaiba, ghichu.Text, 0, 0, "");
                }
            }
        }
       */
        //end linh
        private bool f_Kiemtrabatbuocthutien(string stendatabse,int ibatbuoctt)
        {
            DataSet dsbtdbn = new DataSet();
            dsbtdbn = m.get_data(" select mabn,hoten,ngaysinh,namsinh,phai,mann,madantoc,sonha,thon,cholam,matt,maqu,maphuongxa,userid,hotenkdau,nam,cmnd,msthue from " + user + ".btdbn where mabn='" + s_mabn + "'");
            foreach (DataRow dr1 in dsbtdbn.Tables[0].Rows)
            {
                if (!m.upd_btdbn_client(dr1["mabn"].ToString(), dr1["hoten"].ToString(), dr1["namsinh"].ToString(), int.Parse(dr1["phai"].ToString()), dr1["mann"].ToString(), dr1["madantoc"].ToString(), dr1["sonha"].ToString(), dr1["thon"].ToString(), dr1["cholam"].ToString(), dr1["matt"].ToString(), dr1["maqu"].ToString(), dr1["maphuongxa"].ToString(), int.Parse(dr1["userid"].ToString()), dr1["hotenkdau"].ToString(), dr1["nam"].ToString(), dr1["cmnd"].ToString(), dr1["msthue"].ToString(), stendatabse))
                    return false;
            }
            if (ibatbuoctt == 1)
            {
                DataSet dstiepdon = new DataSet();
                dstiepdon = m.get_data("select mabn,mavaovien,maql,makp,to_char(ngay,'dd/mm/yyyy hh24:mi') ngay,madoituong,sovaovien,tuoivao,done,bnmoi,noitiepdon,loai,userid,idchidinh from " + user + m.mmyy(s_ngay) + ".tiepdon where mabn='" + s_mabn + "' and mavaovien=" + l_mavaovien);
                foreach (DataRow dr2 in dstiepdon.Tables[0].Rows)
                {
                    if (!m.upd_tiepdon_client(dr2["mabn"].ToString(), decimal.Parse(dr2["mavaovien"].ToString()), decimal.Parse(dr2["maql"].ToString()), dr2["makp"].ToString(), dr2["ngay"].ToString(), int.Parse(dr2["madoituong"].ToString()), dr2["sovaovien"].ToString(), dr2["tuoivao"].ToString(), dr2["done"].ToString(), int.Parse(dr2["bnmoi"].ToString()), int.Parse(dr2["noitiepdon"].ToString()), int.Parse(dr2["loai"].ToString()), i_userid, decimal.Parse(dr2["idchidinh"].ToString()), stendatabse))
                        return false;
                }
                DataSet dspk = new DataSet();
                dspk = m.get_data(" select mabn,mavaovien,maql,makp,to_char(ngay,'dd/mm/yyyy hh24:mi') ngay,dentu,nhantu,madoituong,chandoan,maicd,ttlucrv,mabs,sovaovien,bienchung,taibien,giaiphau,mangtr,userid from " + user + m.mmyy(s_ngay) + ".benhanpk where mabn='" + s_mabn + "' and mavaovien=" + l_mavaovien);
                foreach (DataRow dr3 in dspk.Tables[0].Rows)
                {
                    if (!m.upd_benhanpk_client(dr3["mabn"].ToString(), decimal.Parse(dr3["mavaovien"].ToString()), decimal.Parse(dr3["maql"].ToString()), dr3["makp"].ToString(), dr3["ngay"].ToString(), int.Parse(dr3["dentu"].ToString()), int.Parse(dr3["nhantu"].ToString()), int.Parse(dr3["madoituong"].ToString()), dr3["chandoan"].ToString(), dr3["maicd"].ToString(), int.Parse(dr3["ttlucrv"].ToString()), dr3["mabs"].ToString(), dr3["sovaovien"].ToString(), int.Parse(dr3["bienchung"].ToString()), int.Parse(dr3["taibien"].ToString()), int.Parse(dr3["giaiphau"].ToString()), decimal.Parse(dr3["mangtr"].ToString()), i_userid, stendatabse))
                        return false;
                }
            }
            return true;
        }
        //linh
        /*
        private void upd_detail(bool chenhlech, int i_mavp, decimal d_soluong, decimal dongia, int idtrongoi, int idataden)
        {
            string gia, giavt;
            decimal tygia, dg_giam = 0, vt_giam = 0, d_tyle_traituyen = 1;
            DataRow r = m.getrowbyid(dt, "id=" + i_mavp);
            if (r != null)
            {
                if (chenhlech)
                {
                    gia = m.field_gia(madoituong.SelectedValue.ToString());
                    giavt = "vattu_" + gia.Substring(4).Trim();
                    tygia = (gia.IndexOf("_nn") != -1) ? m.dTygia : 1;
                    d_dongia = decimal.Parse(r[gia].ToString()) * tygia - decimal.Parse(r["gia_bh"].ToString());

                    d_vattu = decimal.Parse(r[giavt].ToString()) * tygia - (decimal.Parse(r["vattu_bh"].ToString()));
                    if (cl_tyle != 0 && cl_cholam != "")
                    {
                        string scholam = m.get_cholam(mabn.Text).ToString().Trim().ToLower();
                        if (cl_cholam.IndexOf(scholam) != -1 && scholam != "")
                        {
                            dg_giam = d_dongia * (cl_tyle / 100);
                            vt_giam = d_vattu * (cl_tyle / 100);
                            d_dongia -= dg_giam;
                            d_vattu -= vt_giam;
                        }
                    }
                }
                else
                {
                    gia = m.field_gia(madoituong.SelectedValue.ToString());
                    giavt = "vattu_" + gia.Substring(4).Trim();
                    tygia = (gia.IndexOf("_nn") != -1) ? m.dTygia : 1;
                    d_dongia = decimal.Parse(r[gia].ToString()) * tygia;// *d_tyle_traituyen;
                    d_vattu = decimal.Parse(r[giavt].ToString()) * tygia;
                }

                int itable = m.tableid(m.mmyy(s_ngay), "v_chidinh");
                if (l_id == 0)
                {
                    l_id = v.get_id_chidinh;
                    m.upd_eve_tables(s_ngay, itable, i_userid, "ins");
                }
                else
                {
                    m.upd_eve_tables(s_ngay, itable, i_userid, "upd");
                    m.upd_eve_upd_del(s_ngay, itable, i_userid, "upd", l_id.ToString() + "^" + s_mabn + "^" + l_mavaovien.ToString() + "^" + l_maql.ToString() + "^" + l_idkhoa.ToString() + "^" + s_ngay + "^" + i_loai.ToString() + "^" + s_makp + "^" + madoituong.SelectedValue.ToString() + "^" + i_mavp.ToString() + "^" + d_soluong.ToString() + "^" + d_dongia.ToString() + "^" + d_vattu.ToString() + "^" + i_userid.ToString() + "^" + tinhtrang.SelectedValue.ToString() + "^" + thuchien.SelectedValue.ToString());
                }
                if (!v.upd_chidinh(l_id, s_mabn, l_mavaovien, l_maql, l_idkhoa, s_ngay, i_loai, s_makp, int.Parse(madoituong.SelectedValue.ToString()), i_mavp, d_soluong, (dongia != 0) ? dongia : d_dongia, (dongia != 0) ? 0 : d_vattu, i_userid, int.Parse(tinhtrang.SelectedValue.ToString()), int.Parse(thuchien.SelectedValue.ToString()), l_idchidinh, (s_maicd == "" && chandoan.Text != "") ? "U00" : s_maicd, chandoan.Text, mabs.Text, i_loaiba, ghichu.Text))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin chỉ định !"), LibMedi.AccessData.Msg);
                    return;
                }
                if (idataden != 0)
                    m.execute_data(" update " + user + m.mmyy(s_ngay) + ".v_chidinh set done=3,cosoden=" + idataden + " where id=" + l_id);
                if (chenhlech)
                {
                    if (!bNew) m.execute_data("delete from " + user + m.mmyy(s_ngay) + ".v_chidinh where paid=0 and hide=1 and maql=" + l_maql + " and idkhoa=" + l_idkhoa + " and mavp=" + i_mavp + " and to_char(ngay,'dd/mm/yyyy')='" + s_ngay.Substring(0, 10) + "'");
                    m.execute_data("update " + user + m.mmyy(s_ngay) + ".v_chidinh set done=1,hide=1 where done=0 and id=" + l_id);
                }
                if (idtrongoi != 0) m.execute_data("update " + user + m.mmyy(s_ngay) + ".v_chidinh set idtrongoi=" + idtrongoi + " where id=" + l_id);
                m.execute_data("update " + user + m.mmyy(s_ngay.Substring(0, 10)) + ".v_chidinh set traituyen=" + i_traituyen + " where id =" + l_id);
                if (bChidinh_exp_txt) m.exp_chidinh(m.mmyy(s_ngay), l_id.ToString(), "0");
                m.execute_data("update " + user + m.mmyy(s_ngay) + ".v_chidinh set traituyen=" + i_traituyen + " where id=" + l_id);
                m.updrec_chidinh(ds.Tables[0], l_id, s_ngay, s_makp, s_tenkp, int.Parse(madoituong.SelectedValue.ToString()), madoituong.Text, i_mavp, r["ten"].ToString(), r["dvt"].ToString(), d_soluong, (dongia != 0) ? dongia : d_dongia, (dongia != 0) ? 0 : d_vattu, 0, 0, int.Parse(tinhtrang.SelectedValue.ToString()), int.Parse(thuchien.SelectedValue.ToString()), r["ma"].ToString(), (s_maicd == "" && chandoan.Text != "") ? "U00" : s_maicd, chandoan.Text, mabs.Text, i_loaiba, ghichu.Text, 0, 0, "");
                DataRow[] dr = ds.Tables[0].Select("id=" + l_id);
                if (dr.Length > 0)
                {
                    dr[0]["chon"] = true;
                    if (chenhlech && dr[0]["done"].ToString() == "0") dr[0]["done"] = 1;
                }
                if (dg_giam != 0)
                {
                    l_id = v.get_id_chidinh;
                    v.upd_chidinh(l_id, s_mabn, l_mavaovien, l_maql, l_idkhoa, s_ngay, i_loai, s_makp, cl_doituong, i_mavp, d_soluong, dg_giam, vt_giam, i_userid, int.Parse(tinhtrang.SelectedValue.ToString()), int.Parse(thuchien.SelectedValue.ToString()), l_idchidinh, (s_maicd == "" && chandoan.Text != "") ? "U00" : s_maicd, chandoan.Text, mabs.Text, i_loaiba, ghichu.Text);
                    m.execute_data("update " + user + m.mmyy(s_ngay) + ".v_chidinh set done=0,hide=1,traituyen=" + i_traituyen + " where done=0 and id=" + l_id);
                    m.updrec_chidinh(ds.Tables[0], l_id, s_ngay, s_makp, s_tenkp, cl_doituong, cl_tendoituong, i_mavp, r["ten"].ToString(), r["dvt"].ToString(), d_soluong, dg_giam, vt_giam, 0, 0, int.Parse(tinhtrang.SelectedValue.ToString()), int.Parse(thuchien.SelectedValue.ToString()), r["ma"].ToString(), (s_maicd == "" && chandoan.Text != "") ? "U00" : s_maicd, chandoan.Text, mabs.Text, i_loaiba, ghichu.Text, 0, 0, "");
                }
            }
        }
         * */
        /*
        private void upd_data(int i_mavp, decimal d_soluong, int i_madt, decimal dongia, int idtrongoi,int idataden,int ibatbuocthutien)
        {
            string xxx = m.user + m.mmyy(s_ngay);
            bool b_chenhlechngaynghi = bChenhlechPK_chitinh_vaongaynghi;
            //if (bNew)
            //{
            sql = "select to_char(a.ngay,'dd/mm/yyyy') as ngay,b.ten from xxx.v_chidinh a," + user + ".v_giavp b where a.mavp=b.id and a.mavaovien=" + l_mavaovien + " and mabn='" + mabn.Text + "' and a.mavp=" + i_mavp + " and a.id<>" + l_id + " and a.madoituong=" + i_madt;
            DataTable tmp = d.get_data_mmyy(sql, s_ngay, s_ngay, 30).Tables[0];
            if (tmp.Rows.Count > 0)
                if (MessageBox.Show(tmp.Rows[0]["ten"].ToString().Trim() + " đã nhập ngày " + tmp.Rows[0]["ngay"].ToString() + "\nBạn đồng ý nhập tiếp không ?", LibMedi.AccessData.Msg, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            //}
            bool bCont = false;
            string fie = "gia_bh";
            int s_doituong_chenhlech = (i_madt == i_tunguyen || i_madt == i_madoituongvao) ? i_madoituongvao : i_madt;//binh 050109
            DataRow r = m.getrowbyid(dtdt, "madoituong=" + s_doituong_chenhlech);//binh 050109
            if (r != null) { fie = r["field_gia"].ToString(); bCont = r["chenhlech"].ToString() == "1"; }
            else bCont = false;
            bCont = bCont && bChenhlech;//kiem tra co check G27
            r = m.getrowbyid(dt, "id=" + i_mavp);
            if (r != null)
            {

                if (bChenhlech_doituong) bCont = bCont && s_chenhlech.IndexOf(i_madoituongvao.ToString().Trim() + ",") != -1;
                else bCont = bCont && s_chenhlech.IndexOf(i_madt.ToString().Trim() + ",") != -1;
                bCont = bCont && r["chenhlech"].ToString().Trim() == "1"
                        && decimal.Parse(r[m.field_gia(i_tunguyen.ToString())].ToString()) > decimal.Parse(r[fie].ToString());
                if (!bChidinh_thutienlien) bCont = bCont && i_loaiba == 3;
                if (bChenhlech_doituong) bCont = bCont && (i_madt == i_tunguyen);
                if (i_madoituongvao == 1) bCont = bCont && (decimal.Parse(r["bhyt"].ToString()) > 0);
                b_chenhlechngaynghi = bChenhlechPK_chitinh_vaongaynghi && r["chenhlech"].ToString().Trim() == "1" && decimal.Parse(r[m.field_gia(i_tunguyen.ToString())].ToString()) > decimal.Parse(r[fie].ToString());
                if (bCont || b_chenhlechngaynghi)
                {
                    madoituong.SelectedValue = i_madoituongvao.ToString();
                    madoituong.Update();
                    upd_detail(false, i_mavp, d_soluong, dongia, idtrongoi, false);
                    m.execute_data("update " + xxx + ".v_chidinh set dachenhlech=1 where id=" + l_id + " and mavp=" + i_mavp);
                    l_id = 0;
                    madoituong.SelectedValue = i_tunguyen.ToString();
                    madoituong.Update();
                    upd_detail(true, i_mavp, d_soluong, dongia, idtrongoi, idataden);
                    m.execute_data("update " + xxx + ".v_chidinh set dachenhlech=1 where id=" + l_id + " and mavp=" + i_mavp);
                }
                else
                {
                    madoituong.SelectedValue = i_madt.ToString();
                    madoituong.Update();
                    upd_detail(false, i_mavp, d_soluong, dongia, idtrongoi, idataden);
                }
                if (bTinnhan)
                    netsend(r["computer"].ToString());
                if (bTinnhan_sound)
                    m.upd_tinnhan((bChidinh_ngtru_vienphi) ? r["computervp"].ToString() : r["computer"].ToString(), (bChidinh_ngtru_vienphi) ? "vienphi" : "cls", 1);
            }
        }
        */
        //end Dong
        //end linh
        /// <summary>
        /// 
        /// </summary>
        /// <param name="i_mavp"></param>
        /// <param name="d_soluong"></param>
        /// <param name="i_madt"></param>
        /// <param name="dongia"></param>
        /// <param name="idtrongoi"></param>
        private void upd_data(int i_mavp, decimal d_soluong, int i_madt, decimal dongia, int idtrongoi)
        {
            f_bnmien(i_mavp);
            string xxx = m.user + m.mmyy(s_ngay);
            bool b_chenhlechngaynghi = bChenhlechPK_chitinh_vaongaynghi;
            sql = " select to_char(a.ngay,'dd/mm/yyyy') as ngay,b.ten,d.tenkp from xxx.v_chidinh a inner join " + user + ".v_giavp b on a.mavp=b.id ";
            sql += " inner join " + user + ".v_loaivp c on b.id_loai=c.id inner join "+user+".btdkp_bv d on a.makp=d.makp ";
            sql += " where a.mavaovien=" + l_mavaovien + " and mabn='" + mabn.Text + "' and a.mavp=" + i_mavp + " and a.id<>" + l_id + "";
            DataTable tmp = m.get_data_mmyy(sql, s_ngay, s_ngay, 31).Tables[0];
            if (tmp.Rows.Count > 0 && !b_cholai)
            {
                if (MessageBox.Show(tmp.Rows[0]["ten"].ToString().Trim() + " đã nhập khoa " + tmp.Rows[0]["tenkp"].ToString() + ",ngày " + tmp.Rows[0]["ngay"].ToString() + "\nBạn đồng ý nhập tiếp không ?", LibMedi.AccessData.Msg, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            }
            bool bCont = false;
            string fie = "gia_bh";
            int s_doituong_chenhlech = (i_madt == i_tunguyen || i_madt == i_madoituongvao) ? i_madoituongvao : i_madt;//binh 050109
            DataRow r = m.getrowbyid(dtdt, "madoituong=" + s_doituong_chenhlech);//binh 050109
            if (r != null) { fie = r["field_gia"].ToString(); bCont = r["chenhlech"].ToString() == "1"; }
            else bCont = false;
            bCont = bCont && bChenhlech;//kiem tra co check G27 (3 deu la true)
            r = m.getrowbyid(dt, "id=" + i_mavp);
            if (r != null)
            {
                if (bChenhlech_doituong) bCont = bCont && s_chenhlech.IndexOf(i_madoituongvao.ToString().Trim() + ",") != -1;
                else bCont = bCont && s_chenhlech.IndexOf(i_madt.ToString().Trim() + ",") != -1;
                bCont = bCont && r["chenhlech"].ToString().Trim() == "1"
                        && decimal.Parse(r[m.field_gia(i_tunguyen.ToString())].ToString()) > decimal.Parse(r[fie].ToString());
                if (!bChidinh_thutienlien) bCont = bCont && (i_loaiba == 3||i_loaiba==4);//Thuy 13.08.2012 thêm i_loaiba=4 cho chỉ định ở phòng lưu
                if (bChenhlech_doituong) bCont = bCont && (i_madt == i_tunguyen);
                if (i_madoituongvao == 1) bCont = bCont && (decimal.Parse(r["bhyt"].ToString()) > 0);
                b_chenhlechngaynghi = bChenhlechPK_chitinh_vaongaynghi && r["chenhlech"].ToString().Trim() ==
                    "1" && decimal.Parse(r[m.field_gia(i_tunguyen.ToString())].ToString()) > decimal.Parse(r[fie].ToString()) && i_madoituongvao == 1;//gam 24/09/2011 bv q7 chỉ tính chênh lệch đối tượng BHYT
                //Thuy 27.08.2012 Kiểm tra nếu đki phòng dv+option chenhlechpktinhvaongaynghi khong check thì tính chênh lệch cho chỉ định
                if(dtkp.Rows.Count ==1)
                {
                    DataRow r_kp = m.getrowbyid(dtkp,"makp="+s_makp);
                    if (!bChenhlechPK_chitinh_vaongaynghi && r_kp["phongdv"].ToString() == "1" && i_loaiba!=4)
                    {
                        b_chenhlechngaynghi = true;
                    }
                }
                //end Thuy 27.08.2012
                if (bCont || b_chenhlechngaynghi)
                {
                    madoituong.SelectedValue = i_madoituongvao.ToString();
                    madoituong.Update();
                    upd_detail(false, i_mavp, d_soluong, dongia, idtrongoi, false);
                    m.execute_data("update " + xxx + ".v_chidinh set dachenhlech=1 where id=" + l_id + " and mavp=" + i_mavp);
                    l_id = l_id * -1;// l_id = 0;//binh 270711
                    madoituong.SelectedValue = (bCheckgiaphuthu) ? i_doituonggiatheotg.ToString() : i_tunguyen.ToString();//binh 270711
                    madoituong.Update();
                    upd_detail(true, i_mavp, d_soluong, dongia, idtrongoi, true);
                    m.execute_data("update " + xxx + ".v_chidinh set dachenhlech=1 where id=" + l_id + " and mavp=" + i_mavp);
                    ///Dong 
                    if (ds_bnmien.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow ddr in ds_bnmien.Tables[0].Rows)
                        {
                            int i_tylegiam = int.Parse(ddr["tylemien"].ToString());
                            foreach (DataRow ddr1 in m.get_data(" select id,done,idchidinh,dongia from " + user + m.mmyy(s_ngay) + ".v_chidinh where mavaovien=" + l_mavaovien + " and mabn='" + s_mabn + "' and id=" + l_id + " and done=1 and tylegiam=0 and madoituong!=1").Tables[0].Rows)
                            {
                                m.execute_data(" update " + user + m.mmyy(s_ngay) + ".v_chidinh set tylegiam=" + i_tylegiam + ",stgiam=(" + i_tylegiam + "*" + decimal.Parse(ddr1["dongia"].ToString()) + ")/100 where id=" + decimal.Parse(ddr1["id"].ToString()));
                            }
                        }
                    }
                }
                else
                {
                    madoituong.SelectedValue = i_madt.ToString();
                    madoituong.Update();
                    upd_detail(false, i_mavp, d_soluong, dongia, idtrongoi, false);
                    ///Dong 
                    if (ds_bnmien.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow ddr in ds_bnmien.Tables[0].Rows)
                        {
                            int i_tylegiam = int.Parse(ddr["tylemien"].ToString());
                            foreach (DataRow ddr1 in m.get_data(" select id,done,idchidinh,dongia from " + user + m.mmyy(s_ngay) + ".v_chidinh where mavaovien=" + l_mavaovien + " and mabn='" + s_mabn + "' and id=" + l_id + " and done=0 and madoituong!=1").Tables[0].Rows)
                            {
                                m.execute_data(" update " + user + m.mmyy(s_ngay) + ".v_chidinh set tylegiam=" + i_tylegiam + ",stgiam=(" + i_tylegiam + "*" + decimal.Parse(ddr1["dongia"].ToString()) + ")/100 where id=" + ddr1["id"].ToString());
                            }
                        }
                    }
                }
                //linh
                if (r["giaycamdoan"].ToString() == "1")
                {
                    MessageBox.Show(lan.Change_language_MessageText("Kỹ thuật") + ": " + r["ten"].ToString() + " " + 
                        lan.Change_language_MessageText("cần in giấy cam đoan cho bệnh nhân."), "Medisoft THIS");
                    string s_loaigiay = "TIỂU PHẪU / THỦ THUẬT";
                    if (r["ctscannercq"].ToString() == "1")
                    {
                        s_loaigiay = "CHỤP CT SCANNER CÓ CẢN QUANG";
                    }
                    in_giaycamdoan(s_loaigiay, i_mavp);
                }
                if (r["ctscannercq"].ToString() == "1")
                {
                    MessageBox.Show(lan.Change_language_MessageText("Kỹ thuật") + ": " + r["ten"].ToString() + " " + 
                        lan.Change_language_MessageText("cần in phiếu khám bệnh chụp CT Scanner có cản quang."), "Medisoft THIS");
                    in_phieukbctscanner(i_mavp);
                }
                if (r["hoichan"].ToString() == "1" && i_madoituong == 1)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Kỹ thuật") + ": " + r["ten"].ToString() + " " +
                        lan.Change_language_MessageText("cần in biên bản hội chẩn chụp CT Scanner."), "Medisoft THIS");
                    in_bienbanhoichanctscanner(i_mavp);
                }
                //set control dua vao su kiem ref_text
                //if (ds.Tables[0].Rows.Count > 0)
                //{
                //    DataSet dshoichan = new DataSet();
                //    dshoichan = ds.Clone();
                //    foreach (DataRow ddr1 in ds.Tables[0].Rows)
                //    {
                //        decimal l_idtmp = decimal.Parse(ddr1["id"].ToString());
                //        DataRow ddr2 = m.getrowbyid(ds.Tables[0], "id=" + l_idtmp + " and hoichan=1 and madoituong=1 ");
                //        if (ddr2 != null)
                //        {
                //            dshoichan.Tables[0].Rows.Add(ddr2.ItemArray);
                //        }
                //    }
                //    if (dshoichan.Tables[0].Rows.Count > 0)
                //    {
                //        butGiayhoichan.Enabled = true;
                //    }
                //    else
                //        butGiayhoichan.Enabled = false;
                //}

                //Kiem tra dich vu cls co check CTScanner có cản quang không ,ten biến= ctscannercq
                //if (ds.Tables[0].Rows.Count > 0)
                //{
                //    DataSet dsCTscanner = new DataSet();
                //    dsCTscanner = ds.Clone();
                //    foreach (DataRow ddr1 in ds.Tables[0].Rows)
                //    {
                //        decimal l_idtmp = decimal.Parse(ddr1["id"].ToString());
                //        DataRow ddr2 = m.getrowbyid(ds.Tables[0], "id=" + l_idtmp + " and ctscannercq=1 ");
                //        if (ddr2 != null)
                //        {
                //            dsCTscanner.Tables[0].Rows.Add(ddr2.ItemArray);
                //        }
                //    }
                //    if (dsCTscanner.Tables[0].Rows.Count > 0)
                //    {
                //        butPhieukhambenhchupCT.Enabled = true;
                //    }
                //    else
                //        butPhieukhambenhchupCT.Enabled = false;
                //}
                //end linh
                if (bTinnhan)
                    netsend(r["computer"].ToString());
                if (bTinnhan_sound)
                    m.upd_tinnhan((bChidinh_ngtru_vienphi) ? r["computervp"].ToString() : r["computer"].ToString(), (bChidinh_ngtru_vienphi) ? "vienphi" : "cls", 1);
            }
        }
        private void upd_detail(bool chenhlech, int i_mavp, decimal d_soluong, decimal dongia, int idtrongoi, bool _bCheckgiaphuthu)
        {
            string gia, giavt;
            decimal tygia,dg_giam=0,vt_giam=0, d_tyle_traituyen=1;
            DataRow r = m.getrowbyid(dt, "id=" + i_mavp);
            if (r != null)
            {   
                ///Kiem tra them benh an dien tu của hepa trong G27.1 có check 
                ///Begin Dong
                ///bH19_CLS_Phanbiettronggio_ngoaigio
                if (bCheckgiaphuthu)
                {
                    if (chenhlech)
                    {
                        gia = m.field_gia(i_doituonggiatheotg.ToString());
                        giavt = "vattu_" + gia.Substring(4).Trim();
                        string s_giachlech = gia.Replace("gia", "phuthu"); 
                        d_dongia = decimal.Parse(r[s_giachlech].ToString());
                        if (d_dongia <= 0) return;
                        if (cl_tyle != 0 && cl_cholam != "")
                        {
                            string scholam = m.get_cholam(mabn.Text).ToString().Trim().ToLower();
                            if (cl_cholam.IndexOf(scholam) != -1 && scholam != "")
                            {
                                dg_giam = d_dongia * (cl_tyle / 100);
                                vt_giam = d_vattu * (cl_tyle / 100);
                                d_dongia -= dg_giam;
                                d_vattu -= vt_giam;
                            }
                        }
                    }
                    else
                    {
                        gia = m.field_gia(madoituong.SelectedValue.ToString());
                        giavt = "vattu_" + gia.Substring(4).Trim();
                        tygia = (gia.IndexOf("_nn") != -1) ? m.dTygia : 1;
                        d_dongia = decimal.Parse(r[gia].ToString()) * tygia;// *d_tyle_traituyen;
                        d_vattu = decimal.Parse(r[giavt].ToString()) * tygia;
                    }
                }
                /// End Dong
                else
                {
                    if (chenhlech)
                    {
                        gia = m.field_gia(madoituong.SelectedValue.ToString());
                        giavt = "vattu_" + gia.Substring(4).Trim();
                        tygia = (gia.IndexOf("_nn") != -1) ? m.dTygia : 1;
                        d_dongia = decimal.Parse(r[gia].ToString()) * tygia - decimal.Parse(r["gia_bh"].ToString());

                        d_vattu = decimal.Parse(r[giavt].ToString()) * tygia - (decimal.Parse(r["vattu_bh"].ToString()));
                        if (d_dongia <= 0) return;
                        if (cl_tyle != 0 && cl_cholam != "")
                        {
                            string scholam = m.get_cholam(mabn.Text).ToString().Trim().ToLower();
                            if (cl_cholam.IndexOf(scholam) != -1 && scholam != "")
                            {
                                dg_giam = d_dongia * (cl_tyle / 100);
                                vt_giam = d_vattu * (cl_tyle / 100);
                                d_dongia -= dg_giam;
                                d_vattu -= vt_giam;
                            }
                        }
                    }
                    else
                    {
                        gia = m.field_gia(madoituong.SelectedValue.ToString());
                        giavt = "vattu_" + gia.Substring(4).Trim();
                        tygia = (gia.IndexOf("_nn") != -1) ? m.dTygia : 1;
                        d_dongia = decimal.Parse(r[gia].ToString()) * tygia;// *d_tyle_traituyen;
                        d_vattu = decimal.Parse(r[giavt].ToString()) * tygia;
                    }
                }
                int itable = m.tableid(m.mmyy(s_ngay), "v_chidinh");
                if (l_id == 0)
                {
                    l_id = v.get_id_chidinh;
                    m.upd_eve_tables(s_ngay, itable, i_userid, "ins");
                }
                else
                {
                    m.upd_eve_tables(s_ngay, itable, i_userid, "upd");
                    m.upd_eve_upd_del(s_ngay, itable, i_userid, "upd", l_id.ToString() + "^" + s_mabn + "^" + l_mavaovien.ToString() + "^" + l_maql.ToString() + "^" + l_idkhoa.ToString() + "^" + s_ngay + "^" + i_loai.ToString() + "^" + s_makp + "^" + madoituong.SelectedValue.ToString() + "^" + i_mavp.ToString() + "^" + d_soluong.ToString() + "^" + d_dongia.ToString() + "^" + d_vattu.ToString() + "^" + i_userid.ToString() + "^" + tinhtrang.SelectedValue.ToString() + "^" + thuchien.SelectedValue.ToString());
                }
                //Thuy 11.10.2012 kiem tra chi phi vuot tamung -> khong cho chidinh
                //if (chkThongBaoChiPhi.Checked && bChiPhiVuotTamUngKoChoChiDinh)
                //{
                //    if (!thongbao(false, (dongia != 0) ? dongia : d_dongia)) return;
                //}
                /// Kiểm tra G27.1 sau nay k can kiem tra thi thao ra
                /// bCheckgiaphuthu
                /// i_doituonggiatheotg
                if (i_madoituongvao == 1 && i_kythuat > -1)
                {
                    if ((dtngayhuongktc.ToString() == "") || dtngayhuongktc > m.StringToDate(s_ngay))
                    {
                        DialogResult dl = MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân này chưa được hưởng kỹ thuật cao. Bạn có muốn chuyển sang đối tượng thu phí không?."), "Medisoft THIS", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                        if (dl == DialogResult.Yes)
                        {
                            madoituong.SelectedValue = "2";
                            if (!v.upd_chidinh(l_id, s_mabn, l_mavaovien, l_maql, l_idkhoa, s_ngay, i_loai, s_makp, int.Parse(madoituong.SelectedValue.ToString()), i_mavp, d_soluong, (dongia != 0) ? dongia : d_dongia, (dongia != 0) ? 0 : d_vattu, i_userid, int.Parse(tinhtrang.SelectedValue.ToString()), int.Parse(thuchien.SelectedValue.ToString()), l_idchidinh, (s_maicd == "" && chandoan.Text != "") ? "U00" : s_maicd, chandoan.Text, mabs.Text, i_loaiba, ghichu.Text))
                            {
                                MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin chỉ định !"), LibMedi.AccessData.Msg);
                                return;
                            }
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (!v.upd_chidinh(l_id, s_mabn, l_mavaovien, l_maql, l_idkhoa, s_ngay, i_loai, s_makp, int.Parse(madoituong.SelectedValue.ToString()), i_mavp, d_soluong, (dongia != 0) ? dongia : d_dongia, (dongia != 0) ? 0 : d_vattu, i_userid, int.Parse(tinhtrang.SelectedValue.ToString()), int.Parse(thuchien.SelectedValue.ToString()), l_idchidinh, (s_maicd == "" && chandoan.Text != "") ? "U00" : s_maicd, chandoan.Text, mabs.Text, i_loaiba, ghichu.Text))
                        {
                            MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin chỉ định !"), LibMedi.AccessData.Msg);
                            return;
                        }
                    }
                }
                else
                {
                    if (!v.upd_chidinh(l_id, s_mabn, l_mavaovien, l_maql, l_idkhoa, s_ngay, i_loai, s_makp, int.Parse(madoituong.SelectedValue.ToString()), i_mavp, d_soluong, (dongia != 0) ? dongia : d_dongia, (dongia != 0) ? 0 : d_vattu, i_userid, int.Parse(tinhtrang.SelectedValue.ToString()), int.Parse(thuchien.SelectedValue.ToString()), l_idchidinh, (s_maicd == "" && chandoan.Text != "") ? "U00" : s_maicd, chandoan.Text, mabs.Text, i_loaiba, ghichu.Text))
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin chỉ định !"), LibMedi.AccessData.Msg);
                        return;
                    }
                }
                //m.execute_data(" update " + user + m.mmyy(s_ngay.Substring(0, 10)) + ".v_chidinh set chandoansobo='" + txtchandoansobo.Text.Trim() + "'");
                if (chenhlech) 
                {
                    if (!bNew) 
                        m.execute_data("delete from " + user + m.mmyy(s_ngay) + ".v_chidinh where paid=0 and hide=1 and maql=" + l_maql + " and idkhoa=" + l_idkhoa + " and mavp=" + i_mavp + " and to_char(ngay,'dd/mm/yyyy')='" + s_ngay.Substring(0, 10) + "'");
                    m.execute_data("update " + user + m.mmyy(s_ngay) + ".v_chidinh set done=1,hide=1 where done=0 and id=" + l_id);
                    //if (m.bH19_CLS_Phanbiettronggio_ngoaigio) ///kiem tra Option h19
                    //{
                    //    if (_bCheckgiaphuthu) ///Kiem tra G27.1
                    //        m.execute_data("update " + user + m.mmyy(s_ngay) + ".v_chidinh set madoituong=" + i_doituonggiatheotg + " where id=" + l_id);
                    //    else
                    //        m.execute_data("update " + user + m.mmyy(s_ngay) + ".v_chidinh set madoituong=" + i_madoituongvao + " where id=" + l_id);
                    //}
                    //else
                    //    m.execute_data("update " + user + m.mmyy(s_ngay) + ".v_chidinh set madoituong=" + i_madoituongvao + " where id=" + l_id);
                }
                if (idtrongoi != 0)
                {
                    m.execute_data("update " + user + m.mmyy(s_ngay) + ".v_chidinh set idtrongoi=" + idtrongoi + " where id=" + l_id);
                }
                //linh
                try
                {
                    if (i_trangthai > 1)//chuyển giữa các chi nhánh 
                    {
                        if (dtchinhanh != null)
                        {
                            DataRow rcn = m.getrowbyid(dtchinhanh, "id=" + i_idchinhanhden);
                            if (rcn != null)
                            {
                                string _mmyy = m.mmyy(s_ngay);
                                string databaselink = rcn["database"].ToString().Trim('@');
                                s_mabv = rcn["mabv"].ToString();
                                databaselink = databaselink == "" ? "" : "@" + databaselink;
                                if (databaselink != "")
                                {
                                    if (m.get_data("select mmyy from " + user + ".table" + databaselink + " where mmyy='" + _mmyy + "'").Tables[0].Rows.Count > 0)
                                    {
                                        string s_chuyendi = "1";
                                        s_chuyendi = s_chuyendi.PadRight(300, '1');
                                        m = new LibMedi.AccessData();
                                        m.DatabseLinkName = databaselink.Trim('@');
                                        if (m.upd_btdbn(s_mabn, hoten.Text, s_ngaysinh, s_namsinh, i_phai, s_mann, s_madantoc, "", s_diachi, s_cholam, s_matt, s_maquan, s_mapxa, i_userid, s_chuyendi, ""))
                                        {
                                            m.upd_lienhe(s_ngay, l_maql, "", s_diachi, s_cholam, s_matt, s_maquan, s_mapxa, s_tuoivao, ichinhanh, ichinhanh, s_chuyendi);
                                            m.upd_tiepdon(s_mabn, l_mavaovien, l_maql, s_makp, s_ngay, i_madoituong, "", s_tuoivao, i_userid, 1, 20, i_loai, s_chuyendi);
                                            if (sothe.Text != "")
                                            {
                                                m.upd_bhyt(s_ngay, s_mabn, l_maql, sothe.Text, s_denngay, s_manoidkkcb, i_maphu, s_tungay, s_ngay1, s_ngay2, s_ngay3, i_traituyen, s_chuyendi);
                                            }
                                            m.DatabseLinkName = "";
                                            //
                                            v = new LibVienphi.AccessData();
                                            v.DatabseLinkName = databaselink.Trim('@');
                                            v.upd_chidinh(l_id, s_mabn, l_mavaovien, l_maql, l_idkhoa, s_ngay, i_loai, s_makp, i_madoituong, i_mavp, d_soluong, d_dongia, 0, i_userid, -1, -1, l_idchidinh, s_maicd, chandoan.Text, s_mabs, i_loaiba, "Chi nhánh " + s_tenchinhanh + " chuyển đến", s_chuyendi, ichinhanh);
                                            databaselink = databaselink.Trim('@') == "" ? "" : "@" + databaselink.Trim('@');
                                            
                                            //if (i_trangthai != 6)//i_trangthai=6 -  chuyen chung tu: set paid=1 and done =1  --> de sang chi nhanh khac khong lam duoc
                                            //{
                                            //    v.execute_data("update " + v.user + _mmyy + ".v_chidinh" + databaselink + " set paid=1, done=0 where id=" + l_id);
                                            //}

                                            v.DatabseLinkName = "";
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show(lan.Change_language_MessageText("Cơ sở dữ liệu của chi nhánh cần chuyển tới chưa được tạo.") + "\n" +
                                            lan.Change_language_MessageText("Vui lòng liên hệ với quản trị mạng"));
                                    }
                                }
                            }
                        }
                    }
                }
                catch { }
                //dư=> m.execute_data("update " + user + m.mmyy(s_ngay.Substring(0, 10)) + ".v_chidinh set traituyen=" + i_traituyen + " where id =" + l_id);
                m.execute_data("update " + user + m.mmyy(s_ngay) + ".v_chidinh set traituyen=" + i_traituyen + ",trangthai=" + i_trangthai.ToString() + " where id=" + l_id.ToString());
                //end linh
                if (tmn_hienthi_phuthu.Checked || (tmn_hienthi_phuthu.Checked == false && chenhlech == false))
                {
                    m.updrec_chidinh(ds.Tables[0], l_id, s_ngay, s_makp, s_tenkp, int.Parse(madoituong.SelectedValue.ToString()), madoituong.Text, i_mavp, r["ten"].ToString(), r["dvt"].ToString(), d_soluong, (dongia != 0) ? dongia : d_dongia, (dongia != 0) ? 0 : d_vattu, 0, 0, int.Parse(tinhtrang.SelectedValue.ToString()), int.Parse(thuchien.SelectedValue.ToString()), r["ma"].ToString(), (s_maicd == "" && chandoan.Text != "") ? "U00" : s_maicd, chandoan.Text, mabs.Text, i_loaiba, ghichu.Text, 0, 0, "");
                }
                DataRow[] dr = ds.Tables[0].Select("id=" + l_id);
                if (dr.Length > 0)
                {
                    dr[0]["chon"] = true;
                    if (chenhlech && dr[0]["done"].ToString()=="0")
                        dr[0]["done"] = 1;
                }
                if (dg_giam != 0)
                {
                    l_id = v.get_id_chidinh;                    
                    v.upd_chidinh(l_id, s_mabn, l_mavaovien, l_maql, l_idkhoa, s_ngay, i_loai, s_makp,cl_doituong, i_mavp, d_soluong,dg_giam,vt_giam, i_userid, int.Parse(tinhtrang.SelectedValue.ToString()), int.Parse(thuchien.SelectedValue.ToString()), l_idchidinh, (s_maicd == "" && chandoan.Text != "") ? "U00" : s_maicd, chandoan.Text, mabs.Text, i_loaiba,ghichu.Text);
                    ///Dong 
                    if(ds_bnmien.Tables[0].Rows.Count>0)
                    {
                        foreach (DataRow ddr in ds_bnmien.Tables[0].Rows)
                        {
                            foreach (DataRow ddr1 in m.get_data(" select id,done,idchidinh,dongia from " + user + m.mmyy(s_ngay) + ".v_chidinh where mavaovien=" + l_mavaovien + " and mabn='" + s_mabn + "' and id=" + l_id  + " and done=1 and madoituong!=1").Tables[0].Rows)
                            {
                                m.execute_data(" update " + user + m.mmyy(s_ngay) + ".v_chidinh set tylegiam=" + int.Parse(ddr["tylemien"].ToString()) + ",stgiam=" + decimal.Parse(ddr["tyle"] + "*" + decimal.Parse(ddr1["dongia"].ToString())) + " where maql=" + l_maql + " and id=" + ddr1["id"].ToString() + " and done=1");
                            }
                        }
                    }
                    ///End dong
                    m.execute_data("update " + user + m.mmyy(s_ngay) + ".v_chidinh set done=0,hide=1,traituyen=" + i_traituyen + " where done=0 and id=" + l_id);
                    if (tmn_hienthi_phuthu.Checked || (tmn_hienthi_phuthu.Checked == false && chenhlech == false))
                    {
                        m.updrec_chidinh(ds.Tables[0], l_id, s_ngay, s_makp, s_tenkp, cl_doituong, cl_tendoituong, i_mavp, r["ten"].ToString(), r["dvt"].ToString(), d_soluong, dg_giam, vt_giam, 0, 0, int.Parse(tinhtrang.SelectedValue.ToString()), int.Parse(thuchien.SelectedValue.ToString()), r["ma"].ToString(), (s_maicd == "" && chandoan.Text != "") ? "U00" : s_maicd, chandoan.Text, mabs.Text, i_loaiba, ghichu.Text, 0, 0, "");
                    }
                }
                if (bChidinh_exp_txt) m.exp_chidinh(m.mmyy(s_ngay), l_id.ToString(), "0");
            }
        }
		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			ena_object(false);
            if (bMadoituong) { madoituong.Enabled = true; chkDoiTuongVao.Enabled = true; madoituong.SelectedValue = i_madoituong; }
		}

		private void butHuy_Click(object sender, System.EventArgs e)
		{
			if (ds.Tables[0].Rows.Count==0) return;
            if (bXemlai && s_ngay != m.ngayhienhanh_server && m.bAdminHethong(i_userid) == false)
            {
                MessageBox.Show(lan.Change_language_MessageText("Bạn chỉ được phép xem lại chứ không được phép hủy."));
                return;
            }
			try
			{
                bool bFound = true;
				i_row=dataGrid1.CurrentCell.RowNumber;
				l_id=decimal.Parse(dataGrid1[i_row,1].ToString());
                string s_ngaycd=dataGrid1[i_row, 3].ToString();
                string s_tendv = dataGrid1[i_row, 5].ToString();
                DataTable tmp = m.getChidinh(s_ngay, l_id);
                if (tmp.Rows.Count > 0)
                {
                    if (tmp.Rows[0]["paid"].ToString() != "1")
                    {
                        DataTable tmp_cl = m.getChidinh_chenhlech_dathanhtoan(s_ngay, decimal.Parse(tmp.Rows[0]["maql"].ToString()), int.Parse(tmp.Rows[0]["mavp"].ToString()), -1 * l_id);
                        if (tmp_cl.Rows.Count > 0)
                        {
                            MessageBox.Show(lan.Change_language_MessageText("Dịch vụ đã đóng tiền phần chênh lệch, không thể hủy !"), LibMedi.AccessData.Msg);
                            return;
                        }
                    }
                    if (!bAdminHethong && tmp.Rows[0]["hide"].ToString() == "1")
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Số liệu chênh lệch không cho phép hủy !"), LibMedi.AccessData.Msg);
                        return;
                    }
                    if (tmp.Rows[0]["paid"].ToString() == "1" || tmp.Rows[0]["done"].ToString() == "1")//(dataGrid1[i_row,12].ToString()=="1" || dataGrid1[i_row,13].ToString()=="1")
                    {
                        bFound = (tmp.Rows[0]["paid"].ToString() == "0");
                        if (!bFound)
                        {
                            MessageBox.Show(lan.Change_language_MessageText("Dịch vụ đã đóng tiền, không thể hủy !"), LibMedi.AccessData.Msg);
                            return;
                        }
                        bFound = (tmp.Rows[0]["done"].ToString() == "0");// && tmp.Rows[0]["paid"].ToString() == "0");
                        if (!bFound)
                        {
                            MessageBox.Show(lan.Change_language_MessageText("Dịch vụ đã thực hiện, không thể hủy !"), LibMedi.AccessData.Msg);
                            return;
                        }
                        bFound = false;
                        if (tmp.Rows[0]["done"].ToString() == "1" && tmp.Rows[0]["paid"].ToString() == "0")//(dataGrid1[i_row, 13].ToString() == "1" && dataGrid1[i_row, 12].ToString() == "0")
                        {
                                MessageBox.Show(lan.Change_language_MessageText("Dịch vụ này đã thực hiện, không hủy được !"), LibMedi.AccessData.Msg);
                                return;
                        }
                        else
                        {
                            if (tmp.Rows[0]["idttrv"].ToString() == "0") //if (bAdminHethong && tmp.Rows[0]["idttrv"].ToString() == "0")
                            {
                                MessageBox.Show(lan.Change_language_MessageText("Dịch vụ đã được BHYT duyệt chi phí, không được hủy !"), LibMedi.AccessData.Msg, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            else
                            {
                                MessageBox.Show(lan.Change_language_MessageText("Dịch vụ đã đóng tiền, không thể hủy !"), LibMedi.AccessData.Msg);
                                return;
                            }
                        }
                    }
                    //Tu:10/08/2011
                    if (tmp.Rows[0]["done"].ToString() == "2")
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Số liệu đã cập nhật, không thể hủy !"), LibMedi.AccessData.Msg);
                        return;
                    }
                    //end Tu
                }
                //Thuy 13.11.2012 bn khong hien dien ko cho phep huy
                DataRow r_hd = d.getrowbyid(dthoten, "mabn='" + mabn.Text + "'");
                if (r_hd == null && !bAdmin && !bAdminHethong && i_loaiba==1)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Bệnh nhân đã ra khỏi khoa !"), LibMedi.AccessData.Msg);
                    return;
                } 
                if (!bAdminHethong && bChidinh_dain_khongchohuy)
                {
                    if (m.get_dain_chidinh(m.mmyy(s_ngay), l_id))
                    {
                        MessageBox.Show("Đã in không cho phép hủy !", LibMedi.AccessData.Msg);
                        return;
                    }
                }
                if (!bAdminHethong && bInchitiet && i_loaiba == 3)
                {
                    string tenkp = m.inchiphipk(s_ngay, l_mavaovien);
                    if (tenkp != "")
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Đã in chi phí tại")+" " + tenkp + " !", LibMedi.AccessData.Msg);
                        return;
                    }
                }
				if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý hủy '"+s_tendv+"' ?"),LibMedi.AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
				{

                    bool dChenhlech = false;
                    string mmyy = m.mmyy(s_ngaycd);
                    string xxx = user + mmyy;
                    int itable = m.tableid(mmyy, "v_chidinh");
                    m.upd_eve_tables(s_ngaycd, itable, i_userid, "del");
                    m.upd_eve_upd_del(s_ngaycd, itable, i_userid, "del", m.fields(user + m.mmyy(s_ngaycd) + ".v_chidinh", "id=" + l_id));
                    //                    
                    //string s_field = d.f_get_select_field_mmyy(mmyy, "v_chidinh", "");
                    //if (s_field != "")
                    //{
                        sql = "insert into " + xxx + ".v_chidinh_huy (id, mabn, maql, mavaovien, mavp, madoituong, dongia, ngay, makp, userid, ngayud)  select id, mabn, maql, mavaovien, mavp, madoituong, dongia, ngay, makp, " + i_userid + " as userid, now() as ngayud from " + xxx + ".v_chidinh where id in(" + l_id + ",-" + l_id + ")";
                        m.execute_data(sql);
                        
                    //}
                    //
                    DataTable tmp1 = m.get_data("select * from " + user + m.mmyy(s_ngaycd) + ".v_chidinh where id in(" + l_id + ",-" + l_id + ")").Tables[0];
                    m.execute_data("delete from " + user + m.mmyy(s_ngaycd) + ".v_chidinh where id in(" + l_id + ",-" + l_id + ")");
                    if (tmp.Rows.Count > 0)
                    {
                        if (m.get_data("select id from " + user + ".v_giavp where chenhlech=1 and id=" + decimal.Parse(tmp1.Rows[0]["mavp"].ToString())).Tables[0].Rows.Count>0)
                        {
                            sql = "delete from " + user + m.mmyy(s_ngaycd) + ".v_chidinh where maql=" + l_maql + " and mavaovien=" + l_mavaovien;
                            if (bCheckgiaphuthu)
                                sql += " and madoituong in(" + i_doituonggiatheotg + "," + i_tunguyen + ")";//binh 270711
                            else
                                sql += " and madoituong=" + i_tunguyen;
                            sql += " and paid=0 ";//Tu: 15/08/2011
                            sql += " and userid=" + decimal.Parse(tmp1.Rows[0]["userid"].ToString());
                            sql += " and to_char(ngay,'dd/mm/yyyy')='" + s_ngaycd.Substring(0,10) + "' and hide=1 and done=1 and mavp="+decimal.Parse(tmp1.Rows[0]["mavp"].ToString());
                            sql += " and idchidinh=" + decimal.Parse(tmp1.Rows[0]["idchidinh"].ToString());
                            sql += " and idkhoa=" + decimal.Parse(tmp1.Rows[0]["idkhoa"].ToString());
                            sql += " and loai=" + decimal.Parse(tmp1.Rows[0]["loai"].ToString());
                            sql += " and makp='" + tmp1.Rows[0]["makp"].ToString() + "'";
                            m.execute_data(sql);
                            dChenhlech = true;
                        }
                    }
                    if (dChenhlech) load_grid();
					else m.delrec(ds.Tables[0],"id="+l_id);
					ref_text();
                    getTong();
				}
			}
			catch{}
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}

		private void butLietke_Click(object sender, System.EventArgs e)
		{
            if (bXemlai && tmp_ngay != m.ngayhienhanh_server && m.bAdminHethong(i_userid) == false)
            {
                MessageBox.Show(lan.Change_language_MessageText("Bạn chỉ được phép xem lại chứ không được phép sửa."));
                return;
            }
            if (bInchitiet && i_loaiba==3)
            {
                string tenkp = m.inchiphipk(s_ngay, l_mavaovien);
                if (tenkp != "")
                {
                    MessageBox.Show(lan.Change_language_MessageText("Đã in chi phí tại")+" " + tenkp + " !", LibMedi.AccessData.Msg);
                    return;
                }
            }
            //string _ngay = m.ngayhienhanh_server.Substring(0, 10);
            //if (s_ngay.Substring(0, 10) != _ngay && i_loaiba==2)
            //{
            //    MessageBox.Show(lan.Change_language_MessageText("Ngày chỉ định không được khác ngày hiện hành")+" " + _ngay, LibMedi.AccessData.Msg);
            //    return;
            //} //khuong 22/11/2011 Khong kiem tra ngay chi dinh doi voi benh an ngoai tru
			if (madoituong.SelectedIndex==-1 || i_madoituong==0)
			{
				madoituong.Focus();return;
			}
            if (tinhtrang.SelectedIndex == -1 && tinhtrang.Items.Count > 0) tinhtrang.SelectedIndex = 0;
            if (thuchien.SelectedIndex == -1 && thuchien.Items.Count > 0) thuchien.SelectedIndex = 0;
			if (tinhtrang.SelectedIndex==-1)
			{
				tinhtrang.Focus();return;
			}
			if (thuchien.SelectedIndex==-1)
			{
				thuchien.Focus();return;
			}
            chandoan.Text = s_chandoan;
            mabs.Text = s_mabs;
            DataRow r2 = m.getrowbyid(dtbs, "ma='" + mabs.Text + "'");
            tenbs.Text = (r2 != null) ? r2["hoten"].ToString() : "";
            //
            //madoituong.SelectedValue = i_madoituong.ToString();
            madoituong.Update();
            if (madoituong.Enabled == false) madoituong.SelectedValue = i_madoituong.ToString();
            int tmp_madoituong = int.Parse(madoituong.SelectedValue.ToString());

            
            //frmChonchidinh f = new frmChonchidinh(m, s_mabn, i_madoituong, s_loaivp, s_mucvp, i_loai, sothe.Text, v1, v2, false);
            frmChonchidinh f = new frmChonchidinh(m, s_mabn, tmp_madoituong, s_loaivp, s_mucvp, i_loai, sothe.Text, v1, v2, false, l_mavaovien, s_idvienphi_icd10, l_maql, s_ngay);
            f.SapxepTenKT_TheoABC = mnuSapXepTenTheoABC.Checked;
			f.ShowDialog(this);
			if (f.dt.Rows.Count>0)
			{
				DataRow [] dr;
                int _madt = int.Parse(madoituong.SelectedValue.ToString());
                int tmp_madt = _madt;
                decimal st = 0;
                string fie="gia_th";
				foreach(DataRow r in f.dt.Rows)
				{
                    _madt = tmp_madt;
                    madoituong.SelectedValue = tmp_madt;
                    madoituong.Update();
                    l_id = 0;
                    mavp.Text = r["mavp"].ToString();
                    soluong.Text = r["soluong"].ToString();
                    save();
                    //if (!bLocdichvu && _madt == 1)
                    //{
                    //    sql = "id=" + int.Parse(r["mavp"].ToString()) + " and bhyt<>0";
                    //    if (sothe.Text.Trim().Length > v1 + v2) sql += " and (locthe='' or locthe is null or locthe like '%" + sothe.Text.Trim().Substring(v1, v2) + "%' or locthe like '%" + sothe.Text.Substring(0, 2) + ",%')";
                    //    if (m.getrowbyid(dt, sql) == null)
                    //    {
                    //        _madt = i_tunguyen;
                    //        //madoituong.SelectedValue = 2;// i_tunguyen.ToString();
                    //        //madoituong.Update();
                    //    }
                    //}
                    //l_id=0;
                    
                    //dr=dt.Select("trongoi=1 and id="+int.Parse(r["mavp"].ToString()));
                    //if (dr.Length > 0)
                    //{
                    //    sql = "select a.*, b.sothe from " + user + ".v_trongoi a," + user + ".v_giavp b ";
                    //    sql += " where a.id_gia=b.id and a.id=" + int.Parse(r["mavp"].ToString());
                    //    if (madoituong.SelectedValue.ToString() == "1" && bLocdichvu) sql += " and b.bhyt>0";
                    //    sql += " order by a.stt";
                    //    foreach (DataRow r1 in v.get_data(sql).Tables[0].Rows)
                    //    {
                    //        l_id = 0; st = decimal.Parse(r1["sotien"].ToString());
                    //        madoituong.SelectedValue = tmp_madoituong.ToString();
                    //        madoituong.Update();
                    //        _madt = int.Parse(madoituong.SelectedValue.ToString());
                    //        if (madoituong.SelectedValue.ToString() == "1" && sothe.Text.Trim() != "" && r1["sothe"].ToString().Trim().Trim(',') != "")
                    //        {
                    //            string s_loaithe_bn = sothe.Text.Substring(0, m.iSokytuthe_xet_chiphivanchuyen);
                    //            if (r1["sothe"].ToString().Trim().IndexOf(s_loaithe_bn + ",") < 0)//the khong thuoc nhung The qui dinh --> BHYT khong thanh toan
                    //            {
                    //                _madt = 2;
                    //                madoituong.SelectedValue = _madt;
                    //                madoituong.Update();
                    //            }
                    //        }
                    //        if (bTrongoi_doituong)
                    //        {
                    //            fie = m.field_gia(_madt.ToString()); //fie = m.field_gia(madoituong.SelectedValue.ToString());
                    //            r2 = m.getrowbyid(dt, "id=" + int.Parse(r1["id_gia"].ToString()));
                    //            if (r2 != null) st = decimal.Parse(r2[fie].ToString());
                    //        }
                    //        upd_data(int.Parse(r1["id_gia"].ToString()), decimal.Parse(r1["soluong"].ToString()), (int.Parse(r1["madoituong"].ToString()) == 0) ? _madt : int.Parse(r1["madoituong"].ToString()), st, int.Parse(r1["id"].ToString()));
                    //        if (s_table == "xxx.tiepdon") upd_tiepdon(decimal.Parse(r1["id"].ToString()), decimal.Parse(r1["id_gia"].ToString()));
                    //    }
                    //    if (l_id == 0) upd_data(int.Parse(r["mavp"].ToString()), decimal.Parse(r["soluong"].ToString()), _madt, 0, 0);
                    //}
                    //else
                    //{
                    //    DataRow rvp = m.getrowbyid(dt, "id=" + r["mavp"].ToString());
                    //    if (rvp != null)
                    //    {
                    //        if (madoituong.SelectedValue.ToString() == "1" && sothe.Text.Trim() != "" && rvp["sothe"].ToString().Trim().Trim(',') != "")
                    //        {
                    //            string s_loaithe_bn = sothe.Text.Substring(0, m.iSokytuthe_xet_chiphivanchuyen);
                    //            if (rvp["sothe"].ToString().Trim().IndexOf(s_loaithe_bn + ",") < 0)//the khong thuoc nhung The qui dinh --> BHYT khong thanh toan
                    //            {
                    //                _madt = 2;
                    //                madoituong.SelectedValue = _madt;
                    //                madoituong.Update();
                    //            }
                    //        }
                    //    }
                    //    upd_data(int.Parse(r["mavp"].ToString()), decimal.Parse(r["soluong"].ToString()), _madt, 0, 0);
                    //}
				}
                getTong();
			}
		}

		private void load_treeView______()
		{
			treeView1.Nodes.Clear();
			TreeNode node;
            //if (l_idkhoa==0)
            //{
            string tmp_table=s_ngay;
            if (s_ngay_vaovien.Substring(3, 2) != s_ngay.Substring(3, 2))
            {
                //ngay vao va ngay chi dinh khac thang nhau (vd: dag ky ngay 31/03 - chi dinh: 01/04)
                tmp_table = s_table.Replace("xxx", user + m.mmyy(s_ngay_vaovien));
            }
            sql = "select distinct b.ngay,a.maql,0 as idkhoa from xxx.v_chidinh b left join " + tmp_table + " a on a.maql=b.maql ";
            sql += " where 1=1 ";
				sql+=" and b.mabn='"+s_mabn+"'";
				if (iChidinh==2) sql+=" and b.maql='"+l_maql+"'";                
				sql+=" order by b.ngay desc";
            //}
            //else
            //{
            //    sql="select distinct a.ngay,a.maql,a.id as idkhoa from "+s_table+" a,xxx.v_chidinh b where a.id=b.idkhoa";
            //    sql+=" and a.mabn='"+s_mabn+"'";
            //    if (iChidinh==2) sql+=" and a.maql='"+l_maql+"'";
            //    else if (iChidinh==3) sql+=" and a.id='"+l_idkhoa+"'";
            //    sql+=" order by a.ngay desc";
            //}
            
            dtngay = (iChidinh > 1) ? m.get_data_mmyy(sql, s_ngay_vaovien, s_ngay, true).Tables[0] : m.get_data_nam(nam, sql).Tables[0];

			foreach(DataRow r in dtngay.Rows)
			{
				node=treeView1.Nodes.Add(m.DateToString("dd/MM/yyyy HH:mm",DateTime.Parse(r["ngay"].ToString())));
                sql = "select b.ten from " + user + m.mmyy(m.DateToString("dd/MM/yyyy HH:mm", DateTime.Parse(r["ngay"].ToString()))) + ".v_chidinh a," + user + ".v_giavp b where a.mavp=b.id and a.hide=0";//Thuy 12.04.2013 ko the hien ~ món chênh lệch
				if (l_idkhoa==0) sql+=" and a.maql="+decimal.Parse(r["maql"].ToString());
				else sql+=" and a.idkhoa="+decimal.Parse(r["idkhoa"].ToString());
				foreach(DataRow r1 in m.get_data(sql).Tables[0].Rows)
					node.Nodes.Add(r1["ten"].ToString());
				r["ngay"]=m.StringToDateTime(m.DateToString("dd/MM/yyyy HH:mm",DateTime.Parse(r["ngay"].ToString())));
			}
		}

        private void load_treeView()
        {
            treeView1.Nodes.Clear();
            TreeNode node = null;
            //if (l_idkhoa==0)
            //{
            string tmp_table = s_table;
            if (s_ngay_vaovien.Substring(3, 2) != s_ngay.Substring(3, 2))
            {
                //ngay vao va ngay chi dinh khac thang nhau (vd: dag ky ngay 31/03 - chi dinh: 01/04)
                tmp_table = s_table.Replace("xxx", user + m.mmyy(s_ngay_vaovien));
            }
            sql = "select distinct to_char(b.ngay,'dd/mm/yyyy') as ngay, b.maql,0 as idkhoa, b.id, b.mavp, c.ten, c.ma, b.makp from xxx.v_chidinh b left join " + tmp_table + " a on a.maql=b.maql ";
            sql += " inner join medibv.v_giavp c on b.mavp=c.id ";
            sql += " where 1=1 ";
            sql += " and b.mabn='" + s_mabn + "'";
            if (iChidinh == 2) sql += " and b.maql='" + l_maql + "'";
            sql += " order by b.ngay desc";
            //}
            //else
            //{
            //    sql="select distinct a.ngay,a.maql,a.id as idkhoa from "+s_table+" a,xxx.v_chidinh b where a.id=b.idkhoa";
            //    sql+=" and a.mabn='"+s_mabn+"'";
            //    if (iChidinh==2) sql+=" and a.maql='"+l_maql+"'";
            //    else if (iChidinh==3) sql+=" and a.id='"+l_idkhoa+"'";
            //    sql+=" order by a.ngay desc";
            //}

            dtngay = (iChidinh > 1) ? m.get_data_mmyy(sql, s_ngay_vaovien, s_ngay, true).Tables[0] : m.get_data_nam(nam, sql).Tables[0];

            string tmp_node = "";
            foreach (DataRow r in dtngay.Rows)
            {
                if (tmp_node != r["ngay"].ToString() + "-" + r["maql"].ToString())
                {
                    tmp_node = r["ngay"].ToString() + "-" + r["maql"].ToString();
                    node = treeView1.Nodes.Add(tmp_node);
                    node.Nodes.Add(r["ten"].ToString() + " [" + r["ma"].ToString() + "]");
                }
                else
                {
                    node.Nodes.Add(r["ten"].ToString() + " [" + r["ma"].ToString() + "]");
                }
                //node = treeView1.Nodes.Add(m.DateToString("dd/MM/yyyy HH:mm", DateTime.Parse(r["ngay"].ToString())));
                //sql = "select b.ten from " + user + m.mmyy(m.DateToString("dd/MM/yyyy HH:mm", DateTime.Parse(r["ngay"].ToString()))) + ".v_chidinh a," + user + ".v_giavp b where a.mavp=b.id and a.hide=0";//Thuy 12.04.2013 ko the hien ~ món chênh lệch
                //if (l_idkhoa == 0) sql += " and a.maql=" + decimal.Parse(r["maql"].ToString());
                //else sql += " and a.idkhoa=" + decimal.Parse(r["idkhoa"].ToString());
                //foreach (DataRow r1 in m.get_data(sql).Tables[0].Rows)
                //    node.Nodes.Add(r1["ten"].ToString());
                //r["ngay"] = m.StringToDateTime(m.DateToString("dd/MM/yyyy HH:mm", DateTime.Parse(r["ngay"].ToString())));
            }
        }

		private void treeView1_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			if (e.Action==TreeViewAction.ByMouse)
			{
 			}
		}

		private void list_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
                select_list();
                
			}
		}
        private void select_list()
        {
            try
            {
                DataRow r = m.getrowbyid(dt, "id=" + int.Parse(mavp.Text));
                if (r != null)
                {
                    s_dvt = r["dvt"].ToString();
                    ten.Text = r["ten"].ToString();
                    ma.Text = r["ma"].ToString();
                    if (!bLocdichvu && madoituong.SelectedValue.ToString() == "1")
                    {
                        sql = "id=" + int.Parse(mavp.Text);
                        sql += " and bhyt<>0";
                        if (sothe.Text.Trim().Length > v1 + v2) sql += " and (locthe='' or locthe is null or locthe like '%" + sothe.Text.Trim().Substring(v1, v2) + "%' or locthe like '%" + sothe.Text.Substring(0, 2) + ",%'or locthe like '%"
                                    + sothe.Text.Substring(vitri_jl - 1, 1) + ",%')";
                        if (m.getrowbyid(dt, sql) == null)
                        {
                            madoituong.SelectedValue = 2;// i_tunguyen.ToString();
                            madoituong.Update();
                        }
                    }
                    //chi phi van chuyen
                    //if (madoituong.SelectedValue.ToString() == "1" && sothe.Text.Trim() != "" && r["sothe"].ToString().Trim().Trim(',') != "")
                    //{
                    //    string s_loaithe_bn = sothe.Text.Substring(0, m.iSokytuthe_xet_chiphivanchuyen);
                    //    if (r["sothe"].ToString().Trim().IndexOf(s_loaithe_bn + ",") < 0)//the khong thuoc nhung The qui dinh --> BHYT khong thanh toan
                    //    {
                    //        madoituong.SelectedValue = 2;// i_tunguyen.ToString();
                    //        madoituong.Update();
                    //    }
                    //}
                    //
                    string gia = m.field_gia(madoituong.SelectedValue.ToString());
                    string giavt = "vattu_" + gia.Substring(4).Trim();
                    decimal tygia = (gia.IndexOf("_nn") != -1) ? m.dTygia : 1;
                    d_dongia = decimal.Parse(r[gia].ToString()) * tygia;
                    d_vattu = decimal.Parse(r[giavt].ToString()) * tygia;
                }
            }
            catch { s_dvt = ""; d_dongia = 0; d_vattu = 0; }
        }
		private void tinhtrang_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (tinhtrang.SelectedIndex==-1) tinhtrang.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}		
		}

		private void thuchien_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (tinhtrang.SelectedIndex==-1) tinhtrang.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void mavp_Validated(object sender, System.EventArgs e)
		{
			 if (ma.Text!="")
			{
				sql="ma='"+ma.Text+"'";
				if (madoituong.SelectedValue.ToString()=="1" && bLocdichvu)
				{
                    if (sothe.Text.Trim().Length >= vitri_jl + sothe_jl.Length && sothe_jl != "")
                    {
                        if (sothe.Text.Substring(vitri_jl - 1, sothe_jl.Length) != sothe_jl)
                        {
                            sql += " and bhyt<>0";
                            if (sothe.Text.Trim().Length > v1 + v2) sql += " and (locthe='' or locthe is null or locthe like '%" + sothe.Text.Substring(v1, v2) + "%' or locthe like '%" + sothe.Text.Substring(0, 2) + ",%')";
                        }
                    }
                    else
                    {
                        sql += " and bhyt<>0";
                        if (sothe.Text.Trim().Length > v1 + v2) sql += " and (locthe='' or locthe is null or locthe like '%" + sothe.Text.Trim().Substring(v1, v2) + "%' or locthe like '%" + sothe.Text.Substring(0, 2) + ",%')";
                    }
				}
				DataRow r=m.getrowbyid(dt,sql);
				if (r!=null)
				{
					s_dvt=r["dvt"].ToString();
					ten.Text=r["ten"].ToString();
					mavp.Text=r["id"].ToString();
                    if (!bLocdichvu && madoituong.SelectedValue.ToString() == "1")
                    {
                        sql = "id=" + decimal.Parse(mavp.Text) + " and bhyt<>0";
                        if (sothe.Text.Trim().Length > v1 + v2)
                        {
                            sql += " and (locthe='' or locthe is null or locthe like '%"
                                + sothe.Text.Substring(vitri_jl - 1, 1) + ",%' or locthe like '%"
                                + sothe.Text.Substring(0, 2) + ",%')";
                        }
                        if (m.getrowbyid(dt, sql) == null)
                        {
                            madoituong.SelectedValue = 2;// i_tunguyen.ToString();
                            madoituong.Update();
                        }
                    }
                    //chi phi bhyt
                    //if (madoituong.SelectedValue.ToString() == "1" && sothe.Text.Trim() != "" && r["sothe"].ToString().Trim().Trim(',') != "")
                    //{
                    //    string s_loaithe_bn = sothe.Text.Substring(0, m.iSokytuthe_xet_chiphivanchuyen);
                    //    if (r["sothe"].ToString().Trim().IndexOf(s_loaithe_bn + ",") < 0)//the khong thuoc nhung The qui dinh --> BHYT khong thanh toan
                    //    {
                    //        madoituong.SelectedValue = 2;// i_tunguyen.ToString();
                    //        madoituong.Update();
                    //    }
                    //}
                    //
                    string gia = m.field_gia(madoituong.SelectedValue.ToString());
                    string giavt = "vattu_" + gia.Substring(4).Trim();
                    decimal tygia = (gia.IndexOf("_nn") != -1) ? m.dTygia : 1;
                    d_dongia = decimal.Parse(r[gia].ToString()) * tygia;
                    d_vattu = decimal.Parse(r[giavt].ToString()) * tygia;
				}				
			}
		}

		private void ma_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void butNet_Click(object sender, System.EventArgs e)
		{
			string s1="",s2="";
			DataRow r1;
			foreach(DataRow r in ds.Tables[0].Rows)
			{
				r1=m.getrowbyid(dt,"id="+int.Parse(r["mavp"].ToString()));
				if (r1!=null)
					if (s1.IndexOf(r1["computer"].ToString().Trim()+"+")==-1) s1+=r1["computer"].ToString().Trim()+"+";
			}
			m.writeXml("d_netsend","ma",s1);
			m.writeXml("d_netsend","ten",s2);
			NetSend f=new NetSend();
			f.ShowDialog(this);
		}

        private void netsend(String computer)
        {
            if (bTinnhan && computer!="")
               d.netsend(d.sDomain(i_nhom), computer,mabn.Text+" "+m.khongdau(hoten.Text));
        }

		private void frmChidinh_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.F6:
					butLietke_Click(sender,e);
					break;
			}
		}

        private void getTong()
        {
            decimal st = 0;
            ds.AcceptChanges();
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                st += decimal.Parse(r["soluong"].ToString()) * decimal.Parse(r["dongia"].ToString());
            }
            tong.Text = st.ToString("###,###,###,###");
            
        }

		private void butIn_Click(object sender, System.EventArgs e)
		{
            fprint("rptChidinhcls.rpt",false);
		}
        private void fprint(string tenfile,bool chitiet)
        {
            s_id = "";
            if (bAdminInlaidonthuoc || bAdminInlaiphieuchidinh)
            {
                if (!m.bAdminHethong(i_userid) && s_ngay.Substring(0, 10) != m.ngayhienhanh_server.Substring(0, 10))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Bạn không có quyền in lại chỉ định của ngày trước !"), LibMedi.AccessData.Msg);
                    return;
                }
            }
            foreach (DataRow r1 in ds.Tables[0].Select("chon=true"))
                s_id += r1["id"].ToString() + ",";
            //
            if (m.bCapSTT_Chidinh_Loaivp_H20) m.f_get_stt_cls_loaivp(s_ngay, s_mabn, l_maql.ToString());
            //
            if (m.bInchidinh_dien && s_id != "") 
            {
                DLLPrintchidinh.frmPrintchidinh f1 = new DLLPrintchidinh.frmPrintchidinh();
                f1.f_Print_Chidinh(false, s_mabn, l_maql.ToString(), "",s_ngay.Substring(0,10),s_id);
                return;
            }
            else if (m.bInchidinh_dien && s_id == "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Đề nghị dịch vụ cần in phiếu chỉ định."));
                return;
            }
            //
            if (bChidinh_dain_khongchohuy)
            {
                if (s_id.Trim().Trim(',') == "")
                {
                    foreach (DataRow r1 in ds.Tables[0].Rows)
                        m.execute_data("update " + xxx + ".v_chidinh set lan=lan+1 where id=" + decimal.Parse(r1["id"].ToString()));
                }
                else
                {
                    sql = "update " + xxx + ".v_chidinh set lan=lan+1 where id in (" + s_id.Trim().Trim(',') + ")";
                    m.execute_data(sql);
                }
            }
            
            string sophieu = "";
            if(username.IndexOf("'")!=-1)
            {
                username = username.Replace("'", "`");//Thuy 21.02.2012
            }
            //
            string sql_bhyt = "";
            sql_bhyt = "select mabn, maql, sothe, tungay, denngay, mabv, traituyen, sudung from xxx.bhyt where mabn='" + s_mabn + "'";
            sql_bhyt = m.get_sql_mmyy(sql_bhyt, s_ngay, s_ngay, true);
            //
            if (bSophieu_chidinh) 
                sophieu = "CD" + s_ngay.Substring(8, 2) + s_ngay.Substring(3, 2) + s_ngay.Substring(0, 2) + m.get_sophieucls(m.mmyy(s_ngay), mabn.Text, l_mavaovien, s_ngay.Substring(0, 10), 1, 0).ToString().PadLeft(4, '0');
            sql = "select ";
            if (bChidinh_loaivp) sql += "e.ten as nhomvp,";
            else sql += "f.ten as nhomvp,";
            sql += " e.ten as tenloaivp, e.stt as sttloai, f.ten as tennhomvp, f.stt as sttnhom, ";
            sql += "a.mabn,g.hoten,";
            sql += int.Parse(s_ngay.Substring(6, 4)) + "-to_number(g.namsinh,'0000') as tuoi, g.ngaysinh,";
            sql += "trim(g.sonha)||' '||trim(g.thon)||' '||trim(j.tenpxa)||','||trim(i.tenquan)||','||trim(h.tentt) as diachi,";
            sql += "case when g.phai=0 then 'Nam' else 'Nữ' end as phai,d.tenkp,b.ten,b.dvt,a.soluong,";
            if (s_table == "xxx.tiepdon") sql += "a.chandoan,'' as maicd,";
            else sql += "coalesce(a.chandoan,c.chandoan) as chandoan,c.maicd,";
            if (l_idkhoa == 0) sql += "'' as giuong,";
            else sql += "c.giuong,";
            sql += " m.ten as tinhtrang,n.ten as thuchien,";
            sql += " case when x.sothe is null then x1.sothe else x.sothe end as sothe,";
            sql += " case when x.tungay is null then to_char(x1.tungay,'dd/mm/yyyy')  else to_char(x.tungay,'dd/mm/yyyy') end as tungay,";
            sql += " case when x.denngay is null then to_char(x1.denngay,'dd/mm/yyyy')  else to_char(x.denngay,'dd/mm/yyyy') end as denngay,";
            sql += " case when y.tenbv is null then y1.tenbv else y.tenbv end as noigioithieu,";
            if (s_table == "xxx.tiepdon") sql += "'' as tenbs,a.mabs";
            else sql += "p.hoten as tenbs,a.mabs";
            sql += ", a.madoituong,z.doituong,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay,a.mavp,b.chenhlech,b.gia_th,b.gia_bh,b.gia_dv,b.gia_cs,b.gia_nn,b.gia_ksk,a.ghichu";
            sql += ", a.loaiba, case when x.traituyen is null then (case when x1.traituyen is null then 0 else x1.traituyen end) else x.traituyen end traituyen ";
            sql += ", case when (lh.tuoivao is null) then '0000' else lh.tuoivao end as tuoivao, lh.cholam,b.giaycamdoan,d1.tennn,d2.dantoc,g.cholam noilamviec ";//,a.chandoansobo
            sql += ",substr(b.tgtrakq,1,2) thoigiantrakq,substr(b.tgtrakq,4,1) giongay, a.trangthai";
            sql += ", a.stt as sttcho,'"+username+"' as nguoiin,'' as trieuchung,b.stt ";       // khuong 09/12/2011 them nguoi in
            sql += " from xxx.v_chidinh a inner join " + user + ".v_giavp b on a.mavp=b.id ";
            if (l_idkhoa == 0) sql += " left join " + s_table + " c on a.maql=c.maql ";
            else sql += " left join " + s_table + " c on a.idkhoa=c.id ";
            sql += " inner join " + user + ".btdkp_bv d on a.makp=d.makp ";
            sql += " inner join " + user + ".v_loaivp e on b.id_loai=e.id ";
            sql += " inner join " + user + ".v_nhomvp f on e.id_nhom=f.ma ";
            sql += " inner join " + user + ".btdbn g on a.mabn=g.mabn ";
            sql += " inner join " + user + ".btdtt h on g.matt=h.matt ";
            sql += " inner join " + user + ".btdquan i on g.maqu=i.maqu ";
            sql += " inner join " + user + ".btdpxa j on g.maphuongxa=j.maphuongxa ";
            sql += " left join " + user + ".dmtinhtrang m on a.tinhtrang=m.id ";
            sql += " left join " + user + ".dmthuchien n on a.thuchien=n.id ";
            if (s_table != "xxx.tiepdon") sql += " left join " + user + ".dmbs p on a.mabs=p.ma ";
            sql += " left join (" + sql_bhyt + ") x on a.maql=x.maql "; //sql += " left join xxx.bhyt x on a.maql=x.maql ";
            sql += " left join " + user + ".bhyt x1 on a.maql=x1.maql ";
            sql += " left join " + user + ".dmnoicapbhyt y on x.mabv=y.mabv";
            sql += " left join " + user + ".dmnoicapbhyt y1 on x1.mabv=y1.mabv";
            sql += " inner join " + user + ".doituong z on a.madoituong=z.madoituong ";
            sql += " left join xxx.lienhe lh on a.maql=lh.maql";
            sql += " left join " + user + ".btdnn_bv d1 on g.mann=d1.mann ";
            sql += " left join " + user + ".btddt d2 on g.madantoc=d2.madantoc ";
            sql += " where a.mabn='" + s_mabn + "' and a.hide=0 and to_char(a.ngay,'dd/mm/yyyy')='" + s_ngay.Substring(0, 10) + "'";
            if (l_mavaovien != 0 && i_loaiba == 3 && chkIntheodot.Checked) sql += " and a.mavaovien=" + l_mavaovien;
            else sql += " and a.maql=" + l_maql;
            if (l_idkhoa != 0) sql += " and a.idkhoa=" + l_idkhoa;
            if (s_id != "") sql += " and a.id in (" + s_id.Substring(0, s_id.Length - 1) + ")";
            if (chkIntheodot.Checked == false) sql += " and a.thuchien>0";
            sql += " order by a.ngay,";
            if (bChidinh_loaivp) sql += "e.ten,";
            else sql += "f.ten,";
            sql += "b.ten";
            DataSet dstmp = m.get_data_nam(m.mmyy(s_ngay), sql);
            
            if (dstmp.Tables[0].Rows.Count > 0)
            {
                //if (i_madoituongvao == 1 && dstmp.Tables[0].Select("chenhlech=1").Length > 0)
                //{
                //    foreach (DataRow r1 in dstmp.Tables[0].Select("chenhlech=1 and madoituong=" + i_tunguyen, "mabn,ngay,mavp"))
                //        if (r1[m.field_gia(i_tunguyen.ToString())].ToString() != r1["gia_bh"].ToString())
                //            m.delrec(dstmp.Tables[0], "mabn='" + r1["mabn"].ToString() + "' and mavp=" + int.Parse(r1["mavp"].ToString()) + " and ngay='" + r1["ngay"].ToString() + "' and madoituong=" + i_tunguyen);
                //    dstmp.AcceptChanges();
                //}
                if (bChuky)
                {
                    DataColumn dc = new DataColumn("Image", typeof(byte[]));
                    dstmp.Tables[0].Columns.Add(dc);
                    foreach (DataRow r in dstmp.Tables[0].Rows)
                    {
                        if (File.Exists("..//..//..//chuky//" + r["mabs"].ToString() + ".bmp"))
                        {
                            fstr = new FileStream("..//..//..//chuky//" + r["mabs"].ToString() + ".bmp", FileMode.Open, FileAccess.Read);
                            image = new byte[fstr.Length];
                            fstr.Read(image, 0, System.Convert.ToInt32(fstr.Length));
                            fstr.Close();
                            r["Image"] = image;
                        }
                    }
                }
                string s_tuoi = "",s_ngaysinh="";
                dstmp.Tables[0].Columns.Add("thangtuoi");
                foreach (DataRow r in dstmp.Tables[0].Rows)
                {
                    s_tuoi =r["tuoi"].ToString();
                    s_ngaysinh = r["ngaysinh"].ToString();
                }
                if (int.Parse(s_tuoi) <= 6 && s_ngaysinh!="")
                {
                    long songay = m.songay(m.StringToDateTime(s_ngay), DateTime.Parse(s_ngaysinh), 0);
                    long sothang = songay / 30;
                    foreach (DataRow r in dstmp.Tables[0].Rows) r["thangtuoi"] = sothang.ToString();
                }
                dstmp.Tables[0].Columns.Add("sophieu");
                if (bSophieu_chidinh) 
                    foreach (DataRow r in dstmp.Tables[0].Rows) r["sophieu"] = sophieu;
                if (chitiet)
                {
                    DataSet dst = new DataSet();
                    dst = dstmp.Copy();
                    dstmp.Clear();
                    decimal sl = 0, n = 0;
                    DataRow r;
                    foreach (DataRow r1 in dst.Tables[0].Rows)
                    {
                        sl = decimal.Parse(r1["soluong"].ToString());
                        n = sl;
                        for (int i = 0; i < Convert.ToInt16(n); i++)
                        {
                            r = dstmp.Tables[0].NewRow();
                            for (int j = 0; j < dst.Tables[0].Columns.Count; j++) 
                                r[j] = r1[j].ToString();
                            r["soluong"] = Math.Min(sl, 1);
                            r["ngay"] = m.DateToString("dd/MM/yyyy", m.StringToDate(r1["ngay"].ToString().Substring(0, 10)).AddDays(i));
                            dstmp.Tables[0].Rows.Add(r);
                            sl -= 1;
                        }
                    }
                }
                string s_cdkemtheo = m.f_get_cdkemtheo(s_ngay, l_maql, 4);
                if (s_cdkemtheo.Trim().Trim(',') != "")
                {
                    foreach (DataRow dr in dstmp.Tables[0].Rows)
                    {
                        dr["chandoan"] += ((dr["chandoan"].ToString().Trim() == "") ? "" : ", ") + s_cdkemtheo;
                    }
                }
                string s_trieuchung = m.get_trieuchung(tmp_ngay, l_maql);
                if (s_trieuchung.Trim() != "")
                {
                    foreach (DataRow dr in dstmp.Tables[0].Rows)
                    {
                        dr["trieuchung"] += ((dr["trieuchung"].ToString().Trim() == "") ? "" : ", ") + s_trieuchung;
                    }
                }
                if (chkXML.Checked)
                {
                    if (!System.IO.Directory.Exists("..//xml")) System.IO.Directory.CreateDirectory("..//xml");
                    dstmp.WriteXml("..//xml//chidinh.xml", XmlWriteMode.WriteSchema);
                }
                if (chkXem.Checked)
                {
                    dllReportM.frmReport f = new dllReportM.frmReport(m, dstmp, s_ngay.Substring(0, 10), tenfile);
                    f.ShowDialog();
                }
                else 
                    print.Printer(m, dstmp,tenfile, s_ngay.Substring(0, 10), 1);
                //linh bỏ đưa vào butLuu
                //Kiem tra xem co hen hay k neu co hen thi in ngay hen
                //foreach (DataRow dr in dstmp.Tables[0].Select("thoigiantrakq<>'00'"))
                //{
                //    DataSet dsingiayhen = new DataSet();
                //    s_tgtrakq = dr["thoigiantrakq"].ToString();
                //    s_giongay = dr["giongay"].ToString();
                //    if (s_tgtrakq != "" && s_tgtrakq != "00")
                //    {
                //        sql = "select a.mabn,a.maql,to_char(a.ngay,'dd/mm/yyyy hh24:mi') ngaykham,(to_date(to_char(a.ngay,'dd/mm/yyyy hh24:mi'),'dd/mm/yyyy hh24:mi') +" + int.Parse(s_tgtrakq) + ")ngaylaykg,c.hoten,c.ngaysinh,c.namsinh,c.phai,c.cmnd,c.msthue,c.sonha,c.thon,c.cholam,";
                //        sql += " d.tennn,e.dantoc,f.tentt,g.tenquan,h.tenpxa,b.sothe,j.doituong";
                //        sql += " from " + user + m.mmyy(s_ngay) + ".benhanpk a left join " + user + m.mmyy(s_ngay) + ".bhyt b on a.mabn=b.mabn and a.maql=b.maql inner join " + user + ".btdbn c on a.mabn=c.mabn ";
                //        sql += " left join " + user + ".btdnn d on c.mann=d.mann left join " + user + ".btddt e on c.madantoc=e.madantoc left join " + user + ".btdtt f on c.matt=f.matt";
                //        sql += " left join " + user + ".btdquan g on c.maqu=g.maqu left join " + user + ".btdpxa h on c.maphuongxa=h.maphuongxa left join " + user + m.mmyy(s_ngay) + ".bhyt i on a.maql=i.maql ";
                //        sql += " where a.maql=" + l_maql + " and a.mabn='" + s_mabn + "'";
                //        dsingiayhen = m.get_data(sql);
                //        if (dsingiayhen.Tables[0].Rows.Count > 0)
                //        {
                //            dllReportM.frmReport fr = new dllReportM.frmReport(m, dsingiayhen, s_ngay.Substring(0, 10), "rptGiayhenkqcls.rpt");
                //            fr.ShowDialog();
                //        }
                //    }
                //}
                //if (dstmp.Tables[0].Rows.Count > 0)
                //{
                //    DataSet dscamdoan=new DataSet();
                //    dscamdoan = dstmp.Clone();
                //    foreach (DataRow dr in dstmp.Tables[0].Rows)
                //    {
                //        int _mavptmp = int.Parse(dr["mavp"].ToString());
                //        DataRow dr1 = m.getrowbyid(dstmp.Tables[0], "mavp=" + _mavptmp + " and giaycamdoan=1");
                //        if (dr1 != null)
                //        {
                //            dscamdoan.Tables[0].Rows.Add(dr1.ItemArray);
                //        }
                //    }
                //    if (dscamdoan.Tables[0].Rows.Count > 0)
                //    {
                //        dllReportM.frmReport fr = new dllReportM.frmReport(m, dscamdoan, s_ngay.Substring(0, 10), "rptGiaycamdoan.rpt");
                //        fr.ShowDialog();
                //    }
                //}
                //end linh
            }
        }
       
        private void chkmadt_def_CheckedChanged(object sender, EventArgs e)
        {
            bMadoituong = !chkDoiTuongVao.Checked;
            madoituong.Enabled = bMadoituong;
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
                listBS.BrowseToDanhmuc(tenbs, mabs,chandoan);
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

        private void butInct_Click(object sender, EventArgs e)
        {
            fprint("rptChidinhcls_ii.rpt", true);
        }
        private void ghichu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }
        private void chkIntheodot_Click(object sender, EventArgs e)
        {
            m.writeXml("thongso", "chkIntheodot_chidinhclspk", (chkIntheodot.Checked)?"1":"0");
            load_grid();
        }
        private void f_load_option()
        {
            i_maxlength_mabn = LibMedi.AccessData.i_maxlength_mabn;
            mabn.MaxLength = i_maxlength_mabn;
            bChenhlech = m.bChenhlech;
            bCheckgiaphuthu = m.bChenhlech_laygiaphuthu;
            
            bBHYT_Traituyen_tinh_Tyle_khac = m.bBHYT_Traituyen_tinh_Tyle_khac;
            bChenhlechPK_chitinh_vaongaynghi = m.bChenhlechPK_chitinh_vaongaynghi;

            tmn_hienthi_phuthu.Checked = m.Thongso("chidinh_chenhlech") == "1";
            bNgayhienhanh_thuoc_chidinh = m.bNgayhienhanh_thuoc_chidinh;
        }
        private void f_capnhat_db()
        {
            string xxx = m.user + m.mmyy(s_ngay);
            string asql = "select tylegiam from " + xxx + ".v_chidinh where 1=2";
            DataSet lds = m.get_data(asql);
            bool bln = (lds==null || lds.Tables.Count==0);
            if (bln)
            {
                asql = "alter table " + xxx + ".v_chidinh add tylegiam numeric(5,2) default 0";
                m.execute_data(asql, false);
                asql = "alter table " + xxx + ".v_chidinh add stgiam numeric(18) default 0";
                m.execute_data(asql, false);
                asql = "alter table " + xxx + ".v_chidinh add lydogiam text";
                m.execute_data(asql, false);
            }
            asql = "select id from " + xxx + ".v_chidinh_huy where 1=2";
            lds = m.get_data(asql);
            bln = false;
            bln = (lds == null || lds.Tables.Count == 0);
            if (bln)
            {
                asql = "create table " + xxx + ".v_chidinh_huy as select * from " + xxx + ".v_chidinh where 1=2";
                m.execute_data(asql, false);
            }
            asql = "select ghichu from " + xxx + ".v_chidinh where 1=2";
            lds = m.get_data(asql);
            bln = false;
            bln = (lds == null || lds.Tables.Count == 0);
            if (bln)
            {
                asql = "alter table " + xxx + ".v_chidinh add ghichu text";
                m.execute_data(asql, false);
            }
            asql = "select dachenhlech from " + xxx + ".v_chidinh where 1=2";
            lds = m.get_data(asql);
            bln = false;
            bln = (lds == null || lds.Tables.Count == 0);
            if (bln)
            {
                asql = "alter table " + xxx + ".v_chidinh add dachenhlech numeric(1) default 0";
                m.execute_data(asql, false);
                asql = "alter table " + xxx + ".v_vpkhoa add dachenhlech numeric(1) default 0";
                m.execute_data(asql, false);
            }
            //asql = "select chandoansobo from " + xxx + ".v_chidinh where 1=2";
            //lds = m.get_data(asql);
            //bln = false;
            //bln = (lds == null || lds.Tables.Count == 0);
            //if (bln)
            //{
            //    asql = "alter table " + xxx + ".v_chidinh add chandoansobo text default null";
            //    m.execute_data(asql, false);
            //}
        }

        private void btHoichan_Click(object sender, EventArgs e)
        {
            //linh
            i_row = dataGrid1.CurrentCell.RowNumber;
            int i_mavp = int.Parse(dataGrid1[i_row, 10].ToString());
            in_bienbanhoichanctscanner(i_mavp);
            //string s_mahc = "";
            //DataSet dshoichan = new DataSet();
            //foreach (DataRow r1 in ds.Tables[0].Select("hoichan=1"))
            //    s_mahc += r1["id"].ToString() + ",";
            //sql = "select a.id,a.mabn,a.maql,a.mavaovien,to_char(a.ngay,'dd/mm/yyyy hh24:mi')ngaychidinh,a.mavp,b.ten,b.id_loai,a.mabn,d.hoten,d.namsinh,d.phai,b.hoichan,a.loaiba ";
            //sql += " from xxx.v_chidinh a inner join medibv.v_giavp b on a.mavp=b.id inner join medibv.v_loaivp c on b.id_loai=c.id ";
            //sql += " inner join medibv.btdbn d on a.mabn=d.mabn";
            //sql += " where a.mabn='" + s_mabn + "' and b.hoichan=1 and a.hide=0 and to_char(a.ngay,'dd/mm/yyyy')='" + s_ngay.Substring(0, 10) + "' and a.maql=" + l_maql;
            //if (s_mahc != "")
            //    sql += " and a.id in (" + s_mahc.Substring(0, s_mahc.Length - 1) + ")";
            //dshoichan = m.get_data_nam(m.mmyy(s_ngay), sql);
            //if (dshoichan.Tables[0].Rows.Count > 0)
            //{
            //    dllvpkhoa_chidinh.frmBienbanhoichancls f = new dllvpkhoa_chidinh.frmBienbanhoichancls(m, s_mabn, l_mavaovien, l_maql, s_ngay, dshoichan, i_userid);
            //    f.ShowInTaskbar = false;
            //    f.Show();
            //}
            //else
            //{
            //    MessageBox.Show(lan.Change_language_MessageText(" Không có cận lâm sàn nào cần làm biên bản hội chẩn."), "Medisoft 2007", MessageBoxButtons.OK, MessageBoxIcon.Question);
            //    return;
            //}
            //end linh
        }
        private string f_get_nam_btdbn(string _s_mabn)
        {
            string s_nam = "";
            sql = "select nam from " + user + ".btdbn where mabn='" + _s_mabn + "'";
            try
            {
                s_nam = m.get_data(sql).Tables[0].Rows[0]["nam"].ToString();
                if (s_nam.Trim().Trim('+') == "")
                    s_nam = m.mmyy(m.ngayhienhanh_server.Substring(0, 10)) + "+";
            }
            catch { s_nam = m.mmyy(m.ngayhienhanh_server.Substring(0, 10)) + "+"; }
            return s_nam;
        }

        private void btchuyen_Click(object sender, EventArgs e)
        {
            frmChonchinhanhthuchiencls frm = new frmChonchinhanhthuchiencls(m, ichinhanh);
            frm.ShowDialog(this);
            int _ichinhanh = frm.ichinhanh;
            decimal lidchidinh = 0;
            string s_tendbchuyen = m.get_Tendatabase(_ichinhanh);
            foreach (DataRow r1 in ds.Tables[0].Select("chon=true"))
            {
                lidchidinh = decimal.Parse(r1["id"].ToString());
                if (f_Kiemtrachuyencoso(s_tendbchuyen))
                {
                    DataSet dsbnchuyen = new DataSet();
                    sql = " select id,mabn,mavaovien,maql,idkhoa,to_char(ngay,'dd/mm/yyyy hh24:mi') ngay,loai,makp,madoituong,mavp,soluong,dongia,vattu,userid,tinhtrang,thuchien,computer,idchidinh,maicd,chandoan,mabs,loaiba,ghichu from " + user + m.mmyy(s_ngay) + ".v_chidinh where id=" + lidchidinh;
                    foreach (DataRow r2 in m.get_data(sql).Tables[0].Rows)
                    {
                        m.upd_chidinh_cosoden(lidchidinh, r2["mabn"].ToString(), decimal.Parse(r2["mavaovien"].ToString()), decimal.Parse(r2["maql"].ToString()), decimal.Parse(r2["idkhoa"].ToString()), r2["ngay"].ToString(), int.Parse(r2["loai"].ToString()), r2["makp"].ToString(), int.Parse(r2["madoituong"].ToString()), int.Parse(r2["mavp"].ToString()), decimal.Parse(r2["soluong"].ToString()), decimal.Parse(r2["dongia"].ToString()), decimal.Parse(r2["vattu"].ToString()), int.Parse(r2["userid"].ToString()), int.Parse(r2["tinhtrang"].ToString()), int.Parse(r2["thuchien"].ToString()), decimal.Parse(r2["idchidinh"].ToString()), r2["maicd"].ToString(), r2["chandoan"].ToString(), r2["mabs"].ToString(), int.Parse(r2["loaiba"].ToString()), r2["ghichu"].ToString(), s_tendbchuyen);
                        m.execute_data(" update " + user + m.mmyy(s_ngay) + ".v_chidinh set done=3 where id=" + lidchidinh);
                    }
                }
            }
        }
        private bool f_Kiemtrachuyencoso(string stendatabse)
        {
            DataSet dsbtdbn = new DataSet();
            dsbtdbn = m.get_data(" select mabn,hoten,ngaysinh,namsinh,phai,mann,madantoc,sonha,thon,cholam,matt,maqu,maphuongxa,userid,hotenkdau,nam,cmnd,msthue from " + user + ".btdbn where mabn='" + s_mabn + "'");
            foreach (DataRow dr1 in dsbtdbn.Tables[0].Rows)
            {
                if (!m.upd_btdbn_client(dr1["mabn"].ToString(), dr1["hoten"].ToString(), dr1["namsinh"].ToString(), int.Parse(dr1["phai"].ToString()), dr1["mann"].ToString(), dr1["madantoc"].ToString(), dr1["sonha"].ToString(), dr1["thon"].ToString(), dr1["cholam"].ToString(), dr1["matt"].ToString(), dr1["maqu"].ToString(), dr1["maphuongxa"].ToString(), int.Parse(dr1["userid"].ToString()), dr1["hotenkdau"].ToString(), dr1["nam"].ToString(), dr1["cmnd"].ToString(), dr1["msthue"].ToString(), stendatabse))
                    return false;
            }
            DataSet dstiepdon = new DataSet();
            dstiepdon = m.get_data("select mabn,mavaovien,maql,makp,to_char(ngay,'dd/mm/yyyy hh24:mi') ngay,madoituong,sovaovien,tuoivao,done,bnmoi,noitiepdon,loai,userid,idchidinh from " + user + m.mmyy(s_ngay) + ".tiepdon where mabn='" + s_mabn + "' and mavaovien=" + l_mavaovien);
            foreach (DataRow dr2 in dstiepdon.Tables[0].Rows)
            {
                if (!m.upd_tiepdon_client(dr2["mabn"].ToString(), decimal.Parse(dr2["mavaovien"].ToString()), decimal.Parse(dr2["maql"].ToString()), dr2["makp"].ToString(), dr2["ngay"].ToString(), int.Parse(dr2["madoituong"].ToString()), dr2["sovaovien"].ToString(), dr2["tuoivao"].ToString(), dr2["done"].ToString(), int.Parse(dr2["bnmoi"].ToString()), int.Parse(dr2["noitiepdon"].ToString()), int.Parse(dr2["loai"].ToString()), i_userid, decimal.Parse(dr2["idchidinh"].ToString()), stendatabse))
                    return false;
            }
            DataSet dspk = new DataSet();
            dspk = m.get_data(" select mabn,mavaovien,maql,makp,to_char(ngay,'dd/mm/yyyy hh24:mi') ngay,dentu,nhantu,madoituong,chandoan,maicd,ttlucrv,mabs,sovaovien,bienchung,taibien,giaiphau,mangtr,userid from " + user + m.mmyy(s_ngay) + ".benhanpk where mabn='" + s_mabn + "' and mavaovien=" + l_mavaovien);
            foreach (DataRow dr3 in dspk.Tables[0].Rows)
            {
                if (!m.upd_benhanpk_client(dr3["mabn"].ToString(), decimal.Parse(dr3["mavaovien"].ToString()), decimal.Parse(dr3["maql"].ToString()), dr3["makp"].ToString(), dr3["ngay"].ToString(), int.Parse(dr3["dentu"].ToString()), int.Parse(dr3["nhantu"].ToString()), int.Parse(dr3["madoituong"].ToString()), dr3["chandoan"].ToString(), dr3["maicd"].ToString(), int.Parse(dr3["ttlucrv"].ToString()), dr3["mabs"].ToString(), dr3["sovaovien"].ToString(), int.Parse(dr3["bienchung"].ToString()), int.Parse(dr3["taibien"].ToString()), int.Parse(dr3["giaiphau"].ToString()), decimal.Parse(dr3["mangtr"].ToString()), i_userid, stendatabse))
                    return false;
            }
            return true;
        }

        private void btCtscannercocq_Click(object sender, EventArgs e)
        {
            //linh
            i_row = dataGrid1.CurrentCell.RowNumber;
            int i_mavp = int.Parse(dataGrid1[i_row, 10].ToString());
            in_phieukbctscanner(i_mavp);
            //endlinh
        }
        public DataSet f_Kiemtrahuong_KTC(string s_mabn, string s_tu, string s_den, int s_loaibn)
        {
            string table = "";
            sql = " select distinct a.mabn,a.maql,to_date(to_char(c.tungay,'dd/mm/yyyy'),'dd/mm/yyyy') tungay,to_date(to_char(c.denngay,'dd/mm/yyyy'),'dd/mm/yyyy') denngay ,";
            sql += " to_date(to_char(c.ngay1,'dd/mm/yyyy'),'dd/mm/yyyy') ngayduochuongktc from ";
            switch (s_loaibn)
            {
                case 0:
                    table = "xxx.tiepdon ";
                    break;
                case 1:
                    table = "medibv.benhandt ";
                    break;
                case 2:
                    table = "medibv.benhanngtr ";
                    break;
                case 3:
                    table = "xxx.benhanpk ";
                    break;
                case 4:
                    table = "xxx.benhancc ";
                    break;
            }
            if (s_loaibn == 0 || s_loaibn == 3 || s_loaibn == 4)
            {
                sql += table + " a inner join medibv.doituong b on a.madoituong=b.madoituong left join xxx.bhyt c on a.mabn=c.mabn where a.mabn=" + s_mabn + " and (c.sudung=1 or c.sudung is null) and c.ngay1 is not null ";
            }
            else
            {
                sql += table + " a inner join medibv.doituong b on a.madoituong=b.madoituong left join medibv.bhyt c on a.mabn=c.mabn where a.mabn=" + s_mabn + " and (c.sudung=1 or c.sudung is null) and c.ngay1 is not null ";
            }
            return 
                m.get_data_mmyy(sql, s_tu, s_den,31);
        }
        //linh
        public Form ParentForm
        {
            set { frm_parent = value; }
        }
        public string DiaChi
        {
            set { s_diachi = value; }
        }
        public string NgheNghiep
        {
            set { s_nghenghiep = value; }
        }
        public string NamSinh
        {
            set { s_namsinh= value; }
        }
        public string Phai
        {
            set
            {
                s_phai = value;
                if (s_phai == "nam") { i_phai = 0; }
                else { i_phai = 1; }
            }
        }
        public string ChoLam
        {
            set { s_cholam = value; }
        }
        public string NgoaiKieu
        {
            set { s_ngoaikieu = value; }
        }
        public string DanToc
        {
            set { s_dantoc = value; }
        }
        public string MaDanToc
        {
            set { s_madantoc = value; }
        }
        public string Ngaysinh
        {
            set { s_ngaysinh = value; }
        }
        public string MaNgheNghiep
        {
            set { s_mann = value; }
        }
        public string MaTinhThanh
        {
            set { s_matt = value; }
        }
        public string TenTinhThanh
        {
            set { s_tentt = value; }
        }
        public string MaQuanHuyen
        {
            set { s_maquan = value; }
        }
        public string TenQuanHuyen
        {
            set { s_tenquanhuyen = value; }
        }
        public string MaPhuongXa
        {
            set
            {
                s_mapxa = value;
                if (s_mapxa.Length == 7)
                {
                    s_matt = s_mapxa.Substring(0, 3);
                    s_maquan = s_mapxa.Substring(0, 5);
                }
            }
        }
        public string TenPhuongXa
        {
            set { s_tenpxa=value; }
        }
        /// <summary>
        /// Mabv nơi DKKCB
        /// </summary>
        public string TheBHYT_NoiDKKCB
        {
            set { s_manoidkkcb = value; }
        }
        public string TheBHYT_TuNgay
        {
            set { s_tungay= value; }
        }
        public string TheBHYT_DenNgay
        {
            set { s_denngay = value; }
        }
        public string TheBHYT_NgayHuongKyThuatCao
        {
            set { s_ngay1 = value; }
        }
        public string TheBHYT_NgayHuongChamSOcThaiSan
        {
            set { s_ngay2 = value; }
        }
        public string TheBHYT_NgayHuongThuocUngThu
        {
            set { s_ngay3 = value; }
        }
        public string TuoiVao
        {
            set { s_tuoivao = value; }
        }
        public int TheBHYT_MaPhu
        {
            set { i_maphu = value; }
        }
        public bool ChuyenVien
        {
            get { return b_chuyenvien; }
        }
        public bool ChuyenNgoaiTru
        {
            get { return b_chuyenngoaitru; }
        }
        public bool XuatVienHenTraKetQua
        {
            get { return b_xuatvien_hen; }
        }
        public string MaBenhVienCanChuyen
        {
            get { return s_mabv; }
        }
        public int IDChiNhanhCanChuyen
        {
            get { return i_idchinhanhden; }
        }
        public int SoNgayHenTraKetQua
        {
            get { return i_songayhen; }
        }
        void in_giaycamdoan(string s_loaigiay, int i_mavp)
        {
            DataSet dstmp = new DataSet();
            dstmp = ds.Clone(); 
            dstmp.Tables[0].Columns.Add("loaigiay", typeof(string)).DefaultValue = s_loaigiay;
            dstmp.Tables[0].Columns.Add("hoten", typeof(string)).DefaultValue = hoten.Text;
            dstmp.Tables[0].Columns.Add("mabn", typeof(string)).DefaultValue = mabn.Text;
            dstmp.Tables[0].Columns.Add("tuoi", typeof(string)).DefaultValue = tuoi.Text;
            dstmp.Tables[0].Columns.Add("ngaysinh", typeof(string)).DefaultValue = s_ngaysinh == "" ? s_namsinh : s_ngaysinh;
            dstmp.Tables[0].Columns.Add("phai", typeof(string)).DefaultValue = s_phai;
            dstmp.Tables[0].Columns.Add("nghenghiep", typeof(string)).DefaultValue = s_nghenghiep;
            dstmp.Tables[0].Columns.Add("cholam", typeof(string)).DefaultValue = s_cholam;
            dstmp.Tables[0].Columns.Add("diachi", typeof(string)).DefaultValue = (s_diachi.Trim(',') == "" ? "" : s_diachi.Trim(',') + ", ") + s_tenpxa + ", " + s_tenquanhuyen + ", " + s_tentt;
            dstmp.Tables[0].Columns.Add("dantoc", typeof(string)).DefaultValue = s_dantoc;
            dstmp.Tables[0].Columns.Add("ngoaikieu", typeof(string)).DefaultValue = s_ngoaikieu;
            dstmp.Tables[0].Columns.Add("tenchinhanh", typeof(string)).DefaultValue = s_tenchinhanh;
            foreach (DataRow dr in ds.Tables[0].Select("mavp=" + i_mavp.ToString()))
            {
                dstmp.Tables[0].Rows.Add(dr.ItemArray);
            }
            if (chkXML.Checked)
            {
                dstmp.WriteXml("..//..//dataxml//camdoan.xml", XmlWriteMode.WriteSchema);
            }
            if (dstmp.Tables[0].Rows.Count > 0)
            {
                dllReportM.frmReport fr = new dllReportM.frmReport(m, dstmp, s_ngay.Substring(0, 10), "rptGiaycamdoan.rpt");
                fr.LayDauVanTay = true;
                fr.MaBenhNhan = mabn.Text;
                int i_loaigiay=(int)LibMedi.LoaiChungTuCanKyTen.GiayCamDoanCTCanQuang;
                if(s_loaigiay == "THỦ THUẬT / TIỂU PHẪU")
                {
                    i_loaigiay=(int)LibMedi.LoaiChungTuCanKyTen.GiayCamDoanPTTT;
                }
                fr.LoaiChungTu = i_loaigiay;
                fr.UserID = i_userid;
                fr.NgayKyGiay = s_ngay;
                fr.ShowDialog();
            }
        }
        void in_giayhoichan(int i_loai,int i_mavp)
        {
            DataSet dstmp = new DataSet();
            dstmp = ds.Clone();
            string s_loaigiay = "CHỤP CT SCANNER CÓ CẢN QUANG";
            if (i_loai == 0)
            {
                s_loaigiay = "TIỂU PHẪU / THỦ THUẬT";
            }
            dstmp.Tables[0].Columns.Add("loaigiay", typeof(string)).DefaultValue = s_loaigiay;
            foreach (DataRow dr in ds.Tables[0].Select("mavp=" + i_mavp.ToString()))
            {
                dstmp.Tables[0].Rows.Add(dr.ItemArray);
            }
            if (chkXML.Checked)
            {
                dstmp.WriteXml("..//..//dataxml//hoichan.xml", XmlWriteMode.WriteSchema);
            }
            if (dstmp.Tables[0].Rows.Count > 0)
            {
                dllReportM.frmReport fr = new dllReportM.frmReport(m, dstmp, s_ngay.Substring(0, 10), "rptGiaycamdoan.rpt");
                fr.ShowDialog();
            }
        }
        void in_phieukbctscanner(int i_mavp)
        {
            string s_idchidinh = "";
            DataSet dstmp = new DataSet();
            foreach (DataRow r1 in ds.Tables[0].Select("mavp="+i_mavp.ToString()))
            {
                s_idchidinh += r1["id"].ToString() + ",";
            }
            s_idchidinh = s_idchidinh.Trim(',');
            if (s_idchidinh != "")
            {
                string s_sql = "select a.id,a.mabn,a.maql,a.mavaovien,to_char(a.ngay,'dd/mm/yyyy hh24:mi')ngaychidinh,a.mavp,b.ten,b.id_loai,a.mabn,d.hoten,d.namsinh,d.phai,b.ctscannercq,a.loaiba ";
                s_sql += " from xxx.v_chidinh a inner join medibv.v_giavp b on a.mavp=b.id inner join medibv.v_loaivp c on b.id_loai=c.id ";
                s_sql += " inner join medibv.btdbn d on a.mabn=d.mabn";
                s_sql += " where a.id in (" + s_idchidinh + ")";
                dstmp = m.get_data_nam(m.mmyy(s_ngay), s_sql);
                if (chkXML.Checked)
                {
                    dstmp.WriteXml("..//..//dataxml//phieukhambenhchupctscanner.xml", XmlWriteMode.WriteSchema);
                }
                if (dstmp.Tables[0].Rows.Count > 0)
                {
                    frmKhambenhchupctcocq f = new frmKhambenhchupctcocq(m, s_mabn, l_mavaovien, l_maql, s_ngay, dstmp, s_maicd10, i_userid);
                    f.ShowInTaskbar = false;
                    f.ShowDialog();
                }
            }
        }
        void in_bienbanhoichanctscanner(int i_mavp)
        {
            string s_idchidinh = "";
            DataSet dstmp = new DataSet();
            foreach (DataRow r1 in ds.Tables[0].Select("mavp=" + i_mavp.ToString()))
            {
                s_idchidinh += r1["id"].ToString() + ",";
            }
            s_idchidinh = s_idchidinh.Trim(',');
            if (s_idchidinh != "")
            {
                string s_sql = "select a.id,a.mabn,a.maql,a.mavaovien,to_char(a.ngay,'dd/mm/yyyy hh24:mi')ngaychidinh,a.mavp,b.ten,b.id_loai,a.mabn,d.hoten,d.namsinh,d.phai,b.hoichan,a.loaiba ";
                s_sql += " from xxx.v_chidinh a inner join medibv.v_giavp b on a.mavp=b.id inner join medibv.v_loaivp c on b.id_loai=c.id ";
                s_sql += " inner join medibv.btdbn d on a.mabn=d.mabn";
                s_sql += " where a.id in (" + s_idchidinh + ")";
                dstmp = m.get_data_nam(m.mmyy(s_ngay), s_sql);
                if (chkXML.Checked)
                {
                    dstmp.WriteXml("..//..//dataxml//bienbanhoichanchupctscanner.xml", XmlWriteMode.WriteSchema);
                }
                if (dstmp.Tables[0].Rows.Count > 0)
                {
                    frmBienbanhoichancls f = new frmBienbanhoichancls(m, s_mabn, l_mavaovien, l_maql, s_ngay, dstmp, i_userid);
                    f.ShowInTaskbar = false;
                    f.ShowDialog();
                }
            }
        }

        private void butGiaycamdoanCT_Click(object sender, EventArgs e)
        {
            i_row = dataGrid1.CurrentRowIndex;
            int i_mavp = int.Parse(dataGrid1[i_row, 10].ToString());
            DataRow rtmp = m.getrowbyid(dt, "id=" + i_mavp.ToString());
            if (rtmp != null)
            {
                string s_loaigiay = "THỦ THUẬT / TIỂU PHẪU";
                if (rtmp["ctscannercq"].ToString() == "1")
                {
                    s_loaigiay = "CHỤP CT SCANNER CÓ CẢN QUANG";
                }
                in_giaycamdoan(s_loaigiay, i_mavp);
            }
        }
        //khuong
        private void butGoi_Click(object sender, EventArgs e)
        {
            if (m.Thongso(chkTudongchonthongso.Name) == "1")
            {
                decimal l_duyet1 = 0;
                string s_manguon = d.get_data("select nguon from " + m.user + ".d_dmphieu where id=2").Tables[0].Rows[0][0].ToString();
                sql = "select id,ten from " + m.user + ".d_loaiphieu where loai=2 and id not in(select phieu from " + m.user + m.mmyy(s_ngay) + ".d_duyet where to_char(ngay,'dd/mm/yyyy')='" + s_ngay.Substring(0, 10) + "' and loai=2 and done<>0)order by ten";
                dtPhieu = m.get_data(sql).Tables[0];
                DataRow drttKho = m.get_data("select a.makp,b.ten,b.somay,b.id,b.matutruc,b.makho from " + m.user + ".btdkp_bv a, " + m.user + ".d_duockp b where a.makp=b.makp and a.makp='" + s_makp + "'").Tables[0].Rows[0];
                try
                {
                    l_duyet1 = decimal.Parse(d.get_data("select id from " + m.user + m.mmyy(s_ngay) + ".d_duyet where phieu=" + dtPhieu.Rows[0]["id"].ToString() + " and to_char(ngay,'dd/mm/yyyy')='" + s_ngay.Substring(0, 10) + "' and makp=" + drttKho["id"].ToString() + " and loai=2").Tables[0].Rows[0][0].ToString());
                }
                catch { l_duyet1 = 0; }
                frmGoiDichvu f = new frmGoiDichvu(1, int.Parse(drttKho["id"].ToString()), s_ngay.Substring(0, 10), 2, int.Parse(dtPhieu.Rows[0]["id"].ToString()), m.mmyy(s_ngay), drttKho["makho"].ToString(), s_manguon, l_duyet1, s_mabn,
                       l_mavaovien, l_maql, 0, i_userid, 0, int.Parse(drttKho["matutruc"].ToString()), s_ngay, "", "", true, 0, i_madoituong, s_makp, 0, sothe.Text, s_maicd, s_chandoan, s_mabs,
                       i_loaiba, false, false, 0);
                f.ShowInTaskbar = false;
                f.ShowDialog();
            }
            else
            {
                frmChonthongso f1 = new frmChonthongso(m, 1, 2, 0, s_makp, false, "");
                f1.ShowInTaskbar = false;
                f1.ShowDialog(this);
                if (f1.s_makp != "")
                {
                    frmGoiDichvu f = new frmGoiDichvu(f1.i_nhom, f1.i_makp, f1.s_ngay, 2, f1.i_phieu, f1.s_mmyy, f1.s_makho, f1.s_manguon, f1.l_duyet, s_mabn,
                        l_mavaovien, l_maql, 0, i_userid, 0, f1.i_makp, s_ngay, "", "", true, 0, i_madoituong, s_makp, 0, sothe.Text, s_maicd, s_chandoan, s_mabs,
                        i_loaiba, false, false, 0);
                    f.ShowInTaskbar = false;
                    f.ShowDialog();
                }
            }
        }

        private void tmn_hienthi_phuthu_Click(object sender, EventArgs e)
        {
            load_grid();
            m.writeXml("thongso", "chidinh_chenhlech", tmn_hienthi_phuthu.Checked ? "1" : "0");
        }

        private void frmChidinh_FormClosing(object sender, FormClosingEventArgs e)
        {
            m.writeXml("thongso.xml", chkCanhbaobnBHYTKhidungDVKTC.Name, chkCanhbaobnBHYTKhidungDVKTC.Checked ? "1" : "0");
            m.writeXml("thongso.xml", chkTudongchonthongso.Name, chkTudongchonthongso.Checked ? "1" : "0");
        }

        private void list_DoubleClick(object sender, EventArgs e)
        {
            select_list();
        }

        private void chkDoiTuongVao_CheckedChanged(object sender, EventArgs e)
        {
            bMadoituong = !chkDoiTuongVao.Checked;
            madoituong.Enabled = bMadoituong;
        }

        private void mnuSapXepTenTheoABC_Click(object sender, EventArgs e)
        {
            m.writeXml("thongso.xml", "chidinh_sort_ten", mnuSapXepTenTheoABC.Checked ? "1" : "0");
            Cursor = Cursors.WaitCursor;
            f_load_dmgiavp();
            Cursor = Cursors.Default;
        }
        //
        //private bool thongbao(bool skip, decimal chiphi_hientai)
        //{
        //    if (madoituong.SelectedValue.ToString() == "1" || madoituong.SelectedValue.ToString() == "2")
        //    {
        //        decimal tamung = 0;
        //        string s = m.get_chiphi_mabn(mabn.Text, (i_loaiba == 2) ? l_mavaovien : l_maql, i_loaiba, false);
        //        string[] a_chiphi = s.Split('~');
        //        if (decimal.Parse(a_chiphi[0]) == 0)
        //        {
        //            tamung = m.get_tamung(mabn.Text, l_maql, s_ngay.Substring(0, 10), s_ngay.Substring(0, 10), s_makp, int.Parse(madoituong.SelectedValue.ToString()));
        //        }
        //        else
        //        {
        //            tamung = decimal.Parse(a_chiphi[1]);
        //        }
        //        decimal chiphi = decimal.Parse(a_chiphi[0]) + chiphi_hientai;// (s.Substring(0, s.IndexOf("~")));
        //        decimal bhyttra = decimal.Parse(a_chiphi[2]);//s.Substring(s.IndexOf("~") + 1));
        //        decimal bntra = decimal.Parse(a_chiphi[3]);
        //        decimal conlai = tamung + bhyttra - chiphi;//chi phi -tamung - bhyttra;
        //        if (conlai < Tamung_min && !skip)
        //        {
        //            s = "Tổng chi phí :" + chiphi.ToString("### ### ### ### ###").PadLeft(20, ' ') + "\n";
        //            s += "Tạm ứng      :" + tamung.ToString("### ### ### ### ###").PadLeft(20, ' ') + "\n";
        //            s += "BHYT Trả      :" + bhyttra.ToString("### ### ### ### ###").PadLeft(20, ' ') + "\n";
        //            s += "BN phải Trả      :" + bntra.ToString("### ### ### ### ###").PadLeft(20, ' ') + "\n";
        //            if (conlai > 0)
        //            {
        //                s += "BN Thừa tiền    :" + conlai.ToString("### ### ### ### ###").PadLeft(20, ' ') + "\n\n";
        //            }
        //            else
        //            {
        //                conlai = conlai * -1;
        //                s += "Còn thiếu    :" + conlai.ToString("### ### ### ### ###").PadLeft(20, ' ') + "\n\n";
        //            }
        //            s += "Yêu cầu người bệnh đóng tạm ứng !";
        //            MessageBox.Show(s, LibMedi.AccessData.Msg);
        //            return false;
        //        }
        //    }
        //    return true;
        //}

        //private void chkThongBaoChiPhi_Click(object sender, EventArgs e)
        //{
        //    m.writeXml("thongso", "thongbaochiphi_cd", chkThongBaoChiPhi.Checked ? "1" : "0");
        //}
        //private DataSet get_chiphi()
        //{
        //    try
        //    {
        //        DataSet ads = new DataSet();
        //        string sql = "";
        //        sql  ="select a.mabn,a.hoten,sum(case when g.soluong is null then 0 else g.soluong*g.dongia end) as sotien,g.maql as maql,g.loai "; 
        //        sql +=" from medibv.btdbn a inner join (select mabn, maql, soluong, dongia, paid, ngay, madoituong,idttrv,to_number(makp) as makp,";
        //        sql +=" 0 as loai from xxx.v_chidinh where paid=0 and idttrv=0 ";  
        //        sql +=" union all select distinct a.mabn,a.maql,b.soluong as soluong, b.giaban as dongia,b.idttrv as paid,a.ngay,b.madoituong,";
        //        sql +=" b.idttrv,0 as makp,1 as loai from xxx.d_ngtrull a inner join xxx.d_ngtruct b on a.id=b.id where b.idttrv=0 ";
        //        sql +=" ) g on a.mabn=g.mabn where g.maql="+l_maql;
        //        sql +=" and g.madoituong<>1 and g.paid=0 and g.idttrv=0  and g.paid=0 and g.idttrv=0 group by a.mabn,a.hoten,g.loai,g.maql ";
        //        sql +=" order by a.hoten, a.mabn ";
        //        ads = (iChidinh > 1) ? m.get_data_nam(m.mmyy(s_ngay) + "+", sql) : m.get_data_nam(nam, sql);
        //        return ads;
        //    }
        //    catch(Exception ex)
        //    {
        //        return null;
        //    }
        //}

        private void f_load_dmgiavp()
        {
            string s_ten = "a.ten";
            if (bChidinh_lietke_kemgia) s_ten += "||' ['||a.gia_th||']'";
            sql = "select a.id," + s_ten + " as ten,a.ma,a.dvt,a.gia_th,a.gia_bh,a.gia_dv,a.gia_nn,a.bhyt,a.vattu_th,a.vattu_bh,a.vattu_dv,";
            sql += "a.vattu_nn,b.computer,b.computervp,a.trongoi,a.locthe,a.gia_cs,a.vattu_cs,a.chenhlech,a.gia_ksk,a.vattu_ksk, a.bhyt_tt," +
                "a.sothe,a.batbuocthutien,a.coso,a.cosothay,a.phongthuchiencls,a.hoichan,a.giaycamdoan,substr(a.tgtrakq,1,2) thoigiantrakq," +
                "substr(a.tgtrakq,4,1) giongay,a.gioitinh,a.tutuoi,a.dentuoi,a.xamlan,a.phuthu_th,a.phuthu_dv,a.phuthu_nn,a.phuthu_cs,a.ctscannercq," +
                "a.kythuat, ";
            sql += "a.guingoai,a.guimau,a.guinguoi,a.tgtrakq, a.chuyenchungtu ";//linh
            sql += " from " + user + ".v_giavp a," + user + ".v_loaivp b ";
            sql += "where a.id_loai=b.id and a.hide=0";
            if (s_loaivp != "") sql += " and a.id_loai in (" + s_loaivp + ")";
            if (s_mucvp != "") sql += " and a.id not in (" + s_mucvp + ")";
            sql += " and (a.loaibn=0 or a.loaibn=" + v.iNgoaitru + ")";
            sql += " order by b.stt,a.stt";
            dt = m.get_data(sql).Tables[0];
            list.DisplayMember = "TEN";
            list.ValueMember = "ID";
            list.DataSource = dt;
        }

        public string NgayVaoVien
        {
            set
            {
                s_ngay_vaovien = value;
            }
        }
	}
}