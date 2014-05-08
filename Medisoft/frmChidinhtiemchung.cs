using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibMedi;
using LibVienphi;
using LibDuoc;
using System.IO;

namespace Medisoft
{
    public class frmChidinhtiemchung : System.Windows.Forms.Form
    {
        #region Khai bao
        Language lan = new Language();
        Bogotiengviet tv = new Bogotiengviet();
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
        private LibDuoc.AccessData d = new LibDuoc.AccessData();
        private string nam, user, s_mabn, s_hoten, s_tuoi, s_ngay, tmp_ngay, s_makp, s_tenkp, sql, s_dvt, s_table = "benhantc", s_loaivp = "", s_mucvp = "", s_mabs, s_chandoan, s_maicd, s_chenhlech;
        private int i_madoituong = 2, i_loai, i_done, i_paid, i_row = 0, i_userid, iChidinh, v1, v2, i_nhom, i_madoituongvao, i_tunguyen, i_loaiba;
        private int i_traituyen = 0;
        private decimal l_maql, l_idkhoa, l_id, l_mavaovien, l_idchidinh;
        private decimal d_soluong, d_dongia, d_vattu;
        private bool bInchitiet, bTinnhan, bTinnhan_sound, bAdmin, bAdminInlaidonthuoc, bMadoituong, bChidinh_exp_txt, bChuky, bChidinh_ngtru_vienphi, bChenhlech_doituong, bChidinh_loaivp, bNew;
        private DataSet ds = new DataSet();
        private DataTable dt = new DataTable();
        private DataTable dtngay = new DataTable();
        private DataTable dtkp = new DataTable();
        private DataTable dtbs = new DataTable();
        private DataTable dtdt = new DataTable();
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
        private Brush alertBackBrush;
        private Font alertFont;
        private Brush alertTextBrush;
        private Font currentRowFont;
        private Brush currentRowBackBrush;
        private bool afterCurrentCellChanged = true, bCD_BS_Chidinh, bChidinh_thutienlien;
        private int checkCol = 0;
        private CheckBox chkXem;
        private CheckBox chkXML;
        private dllReportM.Print print = new dllReportM.Print();
        private Label label11;
        private MaskedTextBox.MaskedTextBox tong;
        private CheckBox chkmadt_def;
        private Label label12;
        private TextBox tenbs;
        private Label label13;
        private TextBox chandoan;
        private LibList.List listBS;
        private TextBox mabs;
        private FileStream fstr;
        private byte[] image;
        private System.IO.MemoryStream memo;
        private string sothe_jl;
        private int vitri_jl;
        private string cl_cholam = "", cl_tendoituong = "";
        private decimal cl_tyle = 0;
        private int cl_doituong = 3;
        private Button butInct;
        private bool bLocdichvu, bTrongoi_doituong, bSophieu_chidinh;
        private Label label14;
        private TextBox ghichu;
        private CheckBox chkIntheodot;
        private bool bXemlai = false;
        //Tu:28/03/2011
        private string s_madoituong = "";
        private string s_ngayvk = "";
        private int loaiba = 0;
        private int traituyen = 0;
        private string s_denngay = "";
        private bool b_chonngay = false;
        private int i_phieu, i_somay, i_makp, i_makhoa, i_buoi;
        private string s_makho = "";
        private DataSet dsxoa = new DataSet();
        private decimal l_duyet = 0;
        private DataTable dtll = new DataTable();
        private DataTable dtdmbd = new DataTable();
        //
        #endregion
        private System.ComponentModel.Container components = null;

        public frmChidinhtiemchung(LibMedi.AccessData acc, string mabn, string hoten, string tuoi, string ngay, string makp, string tenkp, int madoituong, int loai, decimal mavaovien, decimal maql, decimal idkhoa, int userid, string table, string thebhyt, string _nam, int loaiba, string _mabs, string _chandoan, string _maicd, int traituyen)
        {
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            m = acc; v = new LibVienphi.AccessData(); if (m.bBogo) tv.GanBogo(this, textBox111);
            s_mabn = mabn; s_hoten = hoten; s_tuoi = tuoi; s_ngay = ngay; s_makp = makp; s_tenkp = tenkp; s_table = table; nam = _nam; i_madoituongvao = madoituong; s_mabs = _mabs; s_chandoan = _chandoan;
            tmp_ngay = s_ngay;
            i_madoituong = madoituong; i_loai = loai; l_maql = maql; l_idkhoa = idkhoa; i_userid = userid; sothe.Text = thebhyt; l_mavaovien = mavaovien; i_loaiba = loaiba; s_maicd = _maicd;
            i_traituyen = traituyen;
        }
        //
        public frmChidinhtiemchung(LibMedi.AccessData acc, string mabn, string hoten, string tuoi, string ngay, string makp, string tenkp, int madoituong, int loai, decimal mavaovien, decimal maql, decimal idkhoa, int userid, string table, string thebhyt, string _nam, int loaiba, string _mabs, string _chandoan, string _maicd, int traituyen, bool xemlai)
        {
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            m = acc; v = new LibVienphi.AccessData(); if (m.bBogo) tv.GanBogo(this, textBox111);
            s_mabn = mabn; s_hoten = hoten; s_tuoi = tuoi; s_ngay = ngay; s_makp = makp; s_tenkp = tenkp; s_table = table; nam = _nam; i_madoituongvao = madoituong; s_mabs = _mabs; s_chandoan = _chandoan;
            tmp_ngay = s_ngay;
            i_madoituong = madoituong; i_loai = loai; l_maql = maql; l_idkhoa = idkhoa; i_userid = userid; sothe.Text = thebhyt; l_mavaovien = mavaovien; i_loaiba = loaiba; s_maicd = _maicd;
            i_traituyen = traituyen;
            bXemlai = xemlai;
        }
        //--linh
        public frmChidinhtiemchung(LibMedi.AccessData acc, string mabn, string hoten, string tuoi, string ngay, string makp, string tenkp, int madoituong, int loai, decimal mavaovien, decimal maql, decimal idkhoa, int userid, string table, string thebhyt, string _nam, string loaiba, string _mabs, string _chandoan, bool badmin, int traituyen)
        {
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this); tv.GanBogo(this, textBox111);
            m = acc; v = new LibVienphi.AccessData();
            s_mabn = mabn; s_hoten = hoten; s_tuoi = tuoi; s_ngay = ngay; s_makp = makp; s_tenkp = tenkp; s_table = table; nam = _nam; i_madoituongvao = madoituong; s_mabs = _mabs; s_chandoan = _chandoan;
            tmp_ngay = s_ngay;
            i_madoituong = madoituong; i_loai = loai; l_maql = maql; l_idkhoa = idkhoa; i_userid = userid; sothe.Text = thebhyt; l_mavaovien = mavaovien;
            i_traituyen = traituyen;
            //i_loaiba = loaiba;
            // s_maicd = _maicd;
        }//--end
        //Tu
        public frmChidinhtiemchung(LibMedi.AccessData acc, string mabn, string hoten, string tuoi, string ngay, string makp, string tenkp, int madoituong, int loai, decimal maql, decimal idkhoa, int userid, string table, string thebhyt, string _madoituong, string _mabs, string _chandoan, bool admin, decimal _mavaovien, int _loaiba, int _traituyen, string denngay)
        {
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            m = acc; v = new LibVienphi.AccessData(); s_madoituong = _madoituong; s_ngayvk = ngay;
            s_mabn = mabn; s_hoten = hoten; s_tuoi = tuoi; s_ngay = ngay; s_makp = makp; s_tenkp = tenkp; s_table = table; l_mavaovien = _mavaovien;
            i_madoituong = madoituong; i_loai = loai; l_maql = maql; l_idkhoa = idkhoa; i_userid = userid; sothe.Text = thebhyt; s_chandoan = _chandoan; s_mabs = _mabs;
            bAdmin = admin; loaiba = _loaiba; traituyen = _traituyen;
            s_denngay = denngay; nam = m.StringToDateTime(ngay).Month.ToString().PadLeft(2, '0') + m.StringToDateTime(ngay).Year.ToString().Substring(2, 2);
        }
        public frmChidinhtiemchung(LibMedi.AccessData acc, string mabn, string hoten, string tuoi, string ngay, string makp, string tenkp, int madoituong, int loai, decimal maql, decimal idkhoa, int userid, string table, string thebhyt, string _madoituong, string _mabs, string _chandoan, bool admin, decimal _mavaovien, int _loaiba, int _traituyen, bool _chonngay)
        {
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            m = acc; v = new LibVienphi.AccessData(); s_madoituong = _madoituong; s_ngayvk = ngay;
            s_mabn = mabn; s_hoten = hoten; s_tuoi = tuoi; s_ngay = ngay; s_makp = makp; s_tenkp = tenkp; s_table = table; l_mavaovien = _mavaovien;
            i_madoituong = madoituong; i_loai = loai; l_maql = maql; l_idkhoa = idkhoa; i_userid = userid; sothe.Text = thebhyt; s_chandoan = _chandoan; s_mabs = _mabs;
            bAdmin = admin; loaiba = _loaiba; traituyen = _traituyen;
            b_chonngay = _chonngay;
        }
        public frmChidinhtiemchung(LibMedi.AccessData acc, string _mabn, string ngay, string makp, string tenkp, int _i_phieu,
            int _i_somay, int _i_makp, int _i_makhoa, string _s_makho, decimal _l_duyet, int _i_buoi, int _i_nhom)
        {
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            m = acc; v = new LibVienphi.AccessData();
            s_ngay = ngay; s_makp = makp; s_tenkp = tenkp; i_phieu = _i_phieu; i_somay = _i_somay;
            i_makp = _i_makp; i_makhoa = _i_makhoa; s_makho = _s_makho; l_duyet = _l_duyet; i_buoi = _i_buoi;
            s_mabn = _mabn; mabn.Text = _mabn; i_nhom = _i_nhom;
            i_loai = 2;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
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
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChidinhtiemchung));
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
            this.butLietke = new System.Windows.Forms.Button();
            this.butMoi = new System.Windows.Forms.Button();
            this.butSua = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butHuy = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tinhtrang = new System.Windows.Forms.ComboBox();
            this.thuchien = new System.Windows.Forms.ComboBox();
            this.ma = new System.Windows.Forms.TextBox();
            this.butNet = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.sothe = new System.Windows.Forms.TextBox();
            this.butIn = new System.Windows.Forms.Button();
            this.chkXem = new System.Windows.Forms.CheckBox();
            this.chkXML = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tong = new MaskedTextBox.MaskedTextBox();
            this.chkmadt_def = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tenbs = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.chandoan = new System.Windows.Forms.TextBox();
            this.listBS = new LibList.List();
            this.mabs = new System.Windows.Forms.TextBox();
            this.butInct = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.ghichu = new System.Windows.Forms.TextBox();
            this.chkIntheodot = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 3);
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
            this.mabn.Location = new System.Drawing.Point(56, 3);
            this.mabn.Name = "mabn";
            this.mabn.Size = new System.Drawing.Size(56, 21);
            this.mabn.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(108, 3);
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
            this.hoten.Location = new System.Drawing.Point(156, 3);
            this.hoten.Name = "hoten";
            this.hoten.Size = new System.Drawing.Size(152, 21);
            this.hoten.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(306, 3);
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
            this.tuoi.Location = new System.Drawing.Point(340, 3);
            this.tuoi.Name = "tuoi";
            this.tuoi.Size = new System.Drawing.Size(48, 21);
            this.tuoi.TabIndex = 5;
            // 
            // treeView1
            // 
            this.treeView1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.Location = new System.Drawing.Point(588, 25);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(121, 236);
            this.treeView1.TabIndex = 60;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
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
            this.dataGrid1.Location = new System.Drawing.Point(8, 8);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(576, 253);
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
            this.list.KeyDown += new System.Windows.Forms.KeyEventHandler(this.list_KeyDown);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(493, 308);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 23);
            this.label4.TabIndex = 9;
            this.label4.Text = "Đối tượng :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // madoituong
            // 
            this.madoituong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.madoituong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.madoituong.Enabled = false;
            this.madoituong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madoituong.Location = new System.Drawing.Point(573, 310);
            this.madoituong.Name = "madoituong";
            this.madoituong.Size = new System.Drawing.Size(136, 21);
            this.madoituong.TabIndex = 4;
            this.madoituong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.madoituong_KeyDown);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(0, 332);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 23);
            this.label5.TabIndex = 11;
            this.label5.Text = "Dịch vụ :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ten
            // 
            this.ten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ten.Enabled = false;
            this.ten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ten.Location = new System.Drawing.Point(145, 332);
            this.ten.Name = "ten";
            this.ten.Size = new System.Drawing.Size(456, 21);
            this.ten.TabIndex = 6;
            this.ten.TextChanged += new System.EventHandler(this.ten_TextChanged);
            this.ten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ten_KeyDown);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(589, 332);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 23);
            this.label6.TabIndex = 13;
            this.label6.Text = "Số lượng :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // soluong
            // 
            this.soluong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.soluong.Enabled = false;
            this.soluong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.soluong.Location = new System.Drawing.Point(653, 332);
            this.soluong.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
            this.soluong.Name = "soluong";
            this.soluong.Size = new System.Drawing.Size(56, 21);
            this.soluong.TabIndex = 7;
            this.soluong.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.soluong.Validated += new System.EventHandler(this.soluong_Validated);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(350, 3);
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
            this.tenkp.Location = new System.Drawing.Point(420, 3);
            this.tenkp.Name = "tenkp";
            this.tenkp.Size = new System.Drawing.Size(129, 21);
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
            // butLietke
            // 
            this.butLietke.Image = ((System.Drawing.Image)(resources.GetObject("butLietke.Image")));
            this.butLietke.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLietke.Location = new System.Drawing.Point(27, 382);
            this.butLietke.Name = "butLietke";
            this.butLietke.Size = new System.Drawing.Size(70, 25);
            this.butLietke.TabIndex = 11;
            this.butLietke.Text = "     Liệt kê";
            this.butLietke.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butLietke.Visible = false;
            this.butLietke.Click += new System.EventHandler(this.butLietke_Click);
            // 
            // butMoi
            // 
            this.butMoi.Image = ((System.Drawing.Image)(resources.GetObject("butMoi.Image")));
            this.butMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMoi.Location = new System.Drawing.Point(97, 382);
            this.butMoi.Name = "butMoi";
            this.butMoi.Size = new System.Drawing.Size(70, 25);
            this.butMoi.TabIndex = 12;
            this.butMoi.Text = "     &Mới";
            this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
            // 
            // butSua
            // 
            this.butSua.Image = ((System.Drawing.Image)(resources.GetObject("butSua.Image")));
            this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.Location = new System.Drawing.Point(167, 382);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(70, 25);
            this.butSua.TabIndex = 13;
            this.butSua.Text = "    &Sửa";
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butLuu
            // 
            this.butLuu.Enabled = false;
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(237, 382);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 9;
            this.butLuu.Text = "    &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Enabled = false;
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(307, 382);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(70, 25);
            this.butBoqua.TabIndex = 10;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butHuy
            // 
            this.butHuy.Image = ((System.Drawing.Image)(resources.GetObject("butHuy.Image")));
            this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHuy.Location = new System.Drawing.Point(377, 382);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(70, 25);
            this.butHuy.TabIndex = 14;
            this.butHuy.Text = "     &Hủy";
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(517, 382);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 18;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(-7, 308);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 23);
            this.label8.TabIndex = 18;
            this.label8.Text = "Tình trạng :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(248, 308);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 23);
            this.label9.TabIndex = 19;
            this.label9.Text = "Thực hiện :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tinhtrang
            // 
            this.tinhtrang.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tinhtrang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tinhtrang.Enabled = false;
            this.tinhtrang.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tinhtrang.Location = new System.Drawing.Point(56, 310);
            this.tinhtrang.Name = "tinhtrang";
            this.tinhtrang.Size = new System.Drawing.Size(186, 21);
            this.tinhtrang.TabIndex = 2;
            this.tinhtrang.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tinhtrang_KeyDown);
            // 
            // thuchien
            // 
            this.thuchien.BackColor = System.Drawing.SystemColors.HighlightText;
            this.thuchien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.thuchien.Enabled = false;
            this.thuchien.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thuchien.Location = new System.Drawing.Point(312, 310);
            this.thuchien.Name = "thuchien";
            this.thuchien.Size = new System.Drawing.Size(192, 21);
            this.thuchien.TabIndex = 3;
            this.thuchien.KeyDown += new System.Windows.Forms.KeyEventHandler(this.thuchien_KeyDown);
            // 
            // ma
            // 
            this.ma.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ma.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ma.Enabled = false;
            this.ma.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ma.Location = new System.Drawing.Point(56, 332);
            this.ma.Name = "ma";
            this.ma.Size = new System.Drawing.Size(88, 21);
            this.ma.TabIndex = 5;
            this.ma.Validated += new System.EventHandler(this.mavp_Validated);
            this.ma.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ma_KeyDown);
            // 
            // butNet
            // 
            this.butNet.Image = ((System.Drawing.Image)(resources.GetObject("butNet.Image")));
            this.butNet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butNet.Location = new System.Drawing.Point(469, 419);
            this.butNet.Name = "butNet";
            this.butNet.Size = new System.Drawing.Size(60, 25);
            this.butNet.TabIndex = 16;
            this.butNet.Text = "&Gửi tin";
            this.butNet.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butNet.Visible = false;
            this.butNet.Click += new System.EventHandler(this.butNet_Click);
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(543, 3);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 21);
            this.label10.TabIndex = 76;
            this.label10.Text = "Số thẻ :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sothe
            // 
            this.sothe.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sothe.Enabled = false;
            this.sothe.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sothe.Location = new System.Drawing.Point(588, 3);
            this.sothe.Name = "sothe";
            this.sothe.Size = new System.Drawing.Size(121, 21);
            this.sothe.TabIndex = 75;
            // 
            // butIn
            // 
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(447, 382);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 15;
            this.butIn.Text = "     &In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // chkXem
            // 
            this.chkXem.AutoSize = true;
            this.chkXem.Location = new System.Drawing.Point(312, 267);
            this.chkXem.Name = "chkXem";
            this.chkXem.Size = new System.Drawing.Size(102, 17);
            this.chkXem.TabIndex = 78;
            this.chkXem.Text = "Xem trước khi in";
            this.chkXem.UseVisualStyleBackColor = true;
            // 
            // chkXML
            // 
            this.chkXML.AutoSize = true;
            this.chkXML.Location = new System.Drawing.Point(420, 267);
            this.chkXML.Name = "chkXML";
            this.chkXML.Size = new System.Drawing.Size(73, 17);
            this.chkXML.TabIndex = 79;
            this.chkXML.Text = "Xuất XML";
            this.chkXML.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(547, 266);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(38, 18);
            this.label11.TabIndex = 80;
            this.label11.Text = "Tổng :";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tong
            // 
            this.tong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tong.Enabled = false;
            this.tong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tong.Location = new System.Drawing.Point(588, 264);
            this.tong.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
            this.tong.Name = "tong";
            this.tong.Size = new System.Drawing.Size(121, 21);
            this.tong.TabIndex = 81;
            this.tong.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // chkmadt_def
            // 
            this.chkmadt_def.Enabled = false;
            this.chkmadt_def.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkmadt_def.Location = new System.Drawing.Point(56, 264);
            this.chkmadt_def.Name = "chkmadt_def";
            this.chkmadt_def.Size = new System.Drawing.Size(127, 24);
            this.chkmadt_def.TabIndex = 139;
            this.chkmadt_def.Text = "Đối tượng khi vào";
            this.chkmadt_def.CheckedChanged += new System.EventHandler(this.chkmadt_def_CheckedChanged);
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(-29, 285);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(84, 23);
            this.label12.TabIndex = 140;
            this.label12.Text = "Bác sỹ :";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tenbs
            // 
            this.tenbs.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbs.Enabled = false;
            this.tenbs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbs.Location = new System.Drawing.Point(56, 288);
            this.tenbs.Name = "tenbs";
            this.tenbs.Size = new System.Drawing.Size(186, 21);
            this.tenbs.TabIndex = 0;
            this.tenbs.TextChanged += new System.EventHandler(this.tenbs_TextChanged);
            this.tenbs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbs_KeyDown);
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(240, 285);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(72, 23);
            this.label13.TabIndex = 142;
            this.label13.Text = "Chẩn đoán :";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chandoan
            // 
            this.chandoan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.chandoan.Enabled = false;
            this.chandoan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chandoan.Location = new System.Drawing.Point(312, 287);
            this.chandoan.Name = "chandoan";
            this.chandoan.Size = new System.Drawing.Size(397, 21);
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
            // butInct
            // 
            this.butInct.Image = ((System.Drawing.Image)(resources.GetObject("butInct.Image")));
            this.butInct.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butInct.Location = new System.Drawing.Point(530, 419);
            this.butInct.Name = "butInct";
            this.butInct.Size = new System.Drawing.Size(90, 25);
            this.butInct.TabIndex = 17;
            this.butInct.Text = "&In từng ngày";
            this.butInct.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butInct.Visible = false;
            this.butInct.Click += new System.EventHandler(this.butInct_Click);
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(2, 356);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(55, 23);
            this.label14.TabIndex = 229;
            this.label14.Text = "Ghi chú :";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ghichu
            // 
            this.ghichu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ghichu.Enabled = false;
            this.ghichu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ghichu.Location = new System.Drawing.Point(56, 355);
            this.ghichu.Name = "ghichu";
            this.ghichu.Size = new System.Drawing.Size(653, 21);
            this.ghichu.TabIndex = 8;
            this.ghichu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ghichu_KeyDown);
            // 
            // chkIntheodot
            // 
            this.chkIntheodot.AutoSize = true;
            this.chkIntheodot.Location = new System.Drawing.Point(178, 268);
            this.chkIntheodot.Name = "chkIntheodot";
            this.chkIntheodot.Size = new System.Drawing.Size(69, 17);
            this.chkIntheodot.TabIndex = 230;
            this.chkIntheodot.Text = "In cả đợt";
            this.chkIntheodot.UseVisualStyleBackColor = true;
            this.chkIntheodot.Click += new System.EventHandler(this.chkIntheodot_Click);
            // 
            // frmChidinhtiemchung
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(714, 447);
            this.Controls.Add(this.chkIntheodot);
            this.Controls.Add(this.ghichu);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.tuoi);
            this.Controls.Add(this.butInct);
            this.Controls.Add(this.listBS);
            this.Controls.Add(this.tenbs);
            this.Controls.Add(this.chandoan);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.chkmadt_def);
            this.Controls.Add(this.tong);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.chkXML);
            this.Controls.Add(this.chkXem);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChidinhtiemchung";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chỉ định dịch vụ";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmChidinhtiemchung_KeyDown);
            this.Load += new System.EventHandler(this.frmChidinhtiemchung_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private void frmChidinhtiemchung_Load(object sender, System.EventArgs e)
        {
            //
            //chkIntheodot_chidinhclspk
            chkIntheodot.Checked = m.Thongso("chkIntheodot_chidinhclspk") == "1";
            f_capnhat_db();
            //
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
            bChidinh_thutienlien = m.bChidinh_thutienlien;
            bChenhlech_doituong = m.bChenhlech_doituong;
            bAdminInlaidonthuoc = m.bAdminInlaidonthuoc;
            if (i_loaiba == 4 && m.bPhongluu_chidinh_chonngay) s_ngay = s_ngay;
            else if (m.bNgayhienhanh_thuoc_chidinh && bXemlai == false) s_ngay = m.ngayhienhanh_server;
            bChidinh_exp_txt = m.bChidinh_exp_txt;
            i_nhom = m.nhom_duoc; l_idchidinh = v.get_id_chidinhll;
            bInchitiet = m.bKham_inchiphi;
            user = m.user; v1 = 4; v2 = 2; i_tunguyen = m.iTunguyen;
            string vitri = d.thetunguyen_vitri_ora(m.nhom_duoc);
            if (vitri.Length == 3)
            {
                v1 = int.Parse(vitri.Substring(0, 1)) - 1; v2 = int.Parse(vitri.Substring(2, 1));
            }
            bChuky = m.bChuky;
            iChidinh = m.iChidinh;
            bMadoituong = m.bSuadt_thuoc_vp;
            chkmadt_def.Checked = !bMadoituong;
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
            //sql="select a.id,a.ten,a.ma,a.dvt,a.gia_th,a.gia_bh,a.gia_dv,a.gia_nn,a.bhyt,a.vattu_th,a.vattu_bh,a.vattu_dv,";
            //sql+="a.vattu_nn,b.computer,b.computervp,a.trongoi,a.locthe,a.gia_cs,a.vattu_cs,a.chenhlech,a.gia_ksk,a.vattu_ksk ";
            //sql+=" from "+user+".v_giavp a,"+user+".v_loaivp b ";
            //sql+="where a.id_loai=b.id and a.hide=0";
            //if (s_loaivp!="") sql+=" and a.id_loai in ("+s_loaivp+")";
            //if (s_mucvp!="") sql+=" and a.id not in ("+s_mucvp+")";
            //sql+=" and (a.loaibn=0 or a.loaibn="+v.iNgoaitru+")";
            //sql+=" order by b.stt,a.stt";
            dsxoa.ReadXml("..//..//..//xml//d_dutruct.xml");
            sql = "select a.id,a.ten,a.ma,a.dvt,a.gia_th,a.gia_bh,a.gia_dv,a.gia_nn,a.bhyt,a.vattu_th, ";
            sql += "a.vattu_bh,a.vattu_dv,a.vattu_nn,b.computer,b.computervp,a.trongoi,a.locthe,a.gia_cs, ";
            sql += "a.vattu_cs,a.chenhlech,a.gia_ksk,a.vattu_ksk ";
            sql += "from medibv.v_giavp a,medibv.v_loaivp b where a.id_loai=b.id ";
            sql += "and a.id in(select id from medibv.v_trongoi) ";
            dt = m.get_data(sql).Tables[0];
            list.DisplayMember = "TEN";
            list.ValueMember = "ID";
            list.DataSource = dt;

            sql = "select a.id,a.mabn,d.hoten,a.mavaovien,a.maql,a.idkhoa,to_char(a.ngayvv,'dd/mm/yyyy hh24:mi') as ngayvv,to_char(c.ngay,'dd/mm/yyyy hh24:mi') as ngay,c.mabs,c.manv,c.mach, ";
            sql += "c.nhietdo,c.huyetap,c.nhiptho,c.cannang,c.phong,c.giuong,c.ghichu,a.read,a.songay,a.traituyen ";
            sql += " from " + user + m.mmyy(s_ngay) + ".d_xtutrucll a inner join " + user + m.mmyy(s_ngay) + ".d_duyet b on a.idduyet=b.id ";
            sql += " left join " + user + m.mmyy(s_ngay) + ".d_dausinhton c on a.id=c.iddutru inner join " + user + ".btdbn d on a.mabn=d.mabn ";
            sql += " where b.id=" + l_duyet + " order by a.id";
            dtll = d.get_data(sql).Tables[0];

            dtdmbd = d.get_data("select a.*,nullif(b.nhomvp,0) as nhomvp,nullif(c.id,0) as loaivp from " + user + ".d_dmbd a inner join " + user + ".d_dmnhom b on a.manhom=b.id left join " + user + ".v_loaivp c on b.nhomvp=c.id_nhom where a.nhom=" + i_nhom).Tables[0];

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
            if (iChidinh != 4) load_treeView();
            if (bMadoituong) { madoituong.Enabled = true; chkmadt_def.Enabled = true; madoituong.SelectedValue = i_madoituong; }
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
        }

        private void SetCellFormat(object sender, DataGridFormatCellEventArgs e)
        {
            try
            {
                if (this.dataGrid1[e.Row, 12].ToString().Trim() == "1" || this.dataGrid1[e.Row, 13].ToString().Trim() == "1")
                    e.ForeBrush = this.disabledTextBrush;
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
            sql = "select a.id,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay,a.makp,d.tenkp,a.madoituong,c.doituong,a.mavp,b.ten,b.dvt,a.soluong,a.dongia,a.paid,a.done,a.maql,a.idkhoa,a.vattu,a.tinhtrang,a.thuchien,b.ma,a.maicd,a.chandoan,a.mabs,a.loaiba,a.ghichu ";
            sql += ", a.tylegiam, a.stgiam, a.lydogiam,a.hide ";
            sql += " from xxx.v_chidinh a," + user + ".v_giavp b," + user + ".doituong c," + user + ".btdkp_bv d ";
            sql += " where a.mavp=b.id and a.madoituong=c.madoituong and a.makp=d.makp ";
            sql += " and a.mabn='" + s_mabn + "'";
            if (l_mavaovien != 0 && i_loaiba == 3)
            {
                if (chkIntheodot.Checked) sql += " and a.mavaovien=" + l_mavaovien;
                else sql += " and a.maql=" + l_maql;
                sql += " and to_char(a.ngay,'dd/mm/yyyy')='" + s_ngay.Substring(0, 10) + "'";
            }
            else if (iChidinh == 2) sql += " and a.maql=" + l_maql;
            else if (iChidinh == 3 && l_idkhoa != 0) sql += " and a.idkhoa=" + l_idkhoa;
            else sql += " and to_char(a.ngay,'dd/mm/yyyy')='" + s_ngay.Substring(0, 10) + "'";
            sql += " and a.makp='" + s_makp + "'";
            if (chkIntheodot.Checked == false) sql += " and a.thuchien>0";
            sql += " order by a.ngay";
            //TU:13/04/2011
            if (nam != "" && nam != null)
                ds = (iChidinh > 1) ? m.get_data_nam(m.mmyy(s_ngay) + "+", sql) : m.get_data_nam(nam, sql);
            else
                ds = m.get_data_nam(m.mmyy(s_ngay) + "+", sql);
            //END TU
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
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (madoituong.SelectedIndex == -1) madoituong.SelectedIndex = 0;
                SendKeys.Send("{Tab}");
            }
        }

        private void ten_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up) list.Focus();
            else if (e.KeyCode == Keys.Enter)
            {
                if (list.Visible) list.Focus();
                else SendKeys.Send("{Tab}");
            }
        }

        private void ten_TextChanged(object sender, System.EventArgs e)
        {
            if (this.ActiveControl == ten)
            {
                Filter(ten.Text);
                list.BrowseToDanhmuc_ma(ten, mavp, soluong, 80);
            }
        }

        private void soluong_Validated(object sender, System.EventArgs e)
        {
            try
            {
                if (soluong.Text == "") soluong.Text = "1";
                d_soluong = decimal.Parse(soluong.Text);
                soluong.Text = d_soluong.ToString("###,###.00");
            }
            catch { soluong.Text = "1"; }
        }

        private void ref_text()
        {
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
                DataRow r = m.getrowbyid(ds.Tables[0], "id=" + l_id);
                if (r != null)
                {
                    chandoan.Text = r["chandoan"].ToString();
                    mabs.Text = r["mabs"].ToString();
                    DataRow r1 = m.getrowbyid(dtbs, "ma='" + mabs.Text + "'");
                    tenbs.Text = (r1 != null) ? r1["hoten"].ToString() : "";
                }
                ghichu.Text = dataGrid1[i_row, 20].ToString();
            }
            catch { }
        }

        private void Filter(string ten)
        {
            try
            {
                CurrencyManager cm = (CurrencyManager)BindingContext[list.DataSource];
                DataView dv = (DataView)cm.List;
                sql = "ten like '%" + ten.Trim() + "%'";
                if (madoituong.SelectedValue.ToString() == "1" && bLocdichvu)
                {
                    if (sothe.Text.Trim().Length >= vitri_jl + sothe_jl.Length && sothe_jl != "")
                    {
                        if (sothe.Text.Substring(vitri_jl - 1, sothe_jl.Length) != sothe_jl)
                        {
                            sql += " and bhyt<>0";
                            if (sothe.Text.Trim().Length > v1 + v2) sql += " and (locthe is null or locthe like '%" + sothe.Text.Substring(v1, v2) + "%' or locthe like '%" + sothe.Text.Substring(0, 2) + ",%')";
                        }
                    }
                    else
                    {
                        sql += " and bhyt<>0";
                        if (sothe.Text.Trim().Length > v1 + v2) sql += " and (locthe='' or locthe is null or locthe like '%" + sothe.Text.Trim().Substring(v1, v2) + "%' or locthe like '%" + sothe.Text.Substring(0, 2) + ",%')";
                    }
                }
                dv.RowFilter = sql;
            }
            catch { }
        }

        private void ena_object(bool ena)
        {
            ma.Enabled = ena;
            if (bMadoituong) madoituong.Enabled = ena;
            chkmadt_def.Enabled = ena;
            ghichu.Enabled = tenbs.Enabled = chandoan.Enabled = tinhtrang.Enabled = ena;
            thuchien.Enabled = ena;
            ten.Enabled = ena;
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
            //dataGrid1.ReadOnly=!ena;
            if (ena && l_id == 0)
            {
                ghichu.Text = ten.Text = ma.Text = "";
                soluong.Text = "1";
                s_dvt = ""; i_paid = 0; i_done = 0;
                chandoan.Text = (s_chandoan != "") ? s_chandoan : chandoan.Text;
                mabs.Text = s_mabs;
                DataRow r1 = m.getrowbyid(dtbs, "ma='" + mabs.Text + "'");
                tenbs.Text = (r1 != null) ? r1["hoten"].ToString() : "";
            }
            else butMoi.Focus();
        }

        private void butMoi_Click(object sender, System.EventArgs e)
        {
            try { hoten.Text = m.get_data("select hoten from " + user + ".btdbn where mabn='" + mabn.Text.Trim() + "'").Tables[0].Rows[0][0].ToString(); }
            catch { }
            if (bXemlai && s_ngay != m.ngayhienhanh_server && m.bAdminHethong(i_userid) == false)
            {
                MessageBox.Show(lan.Change_language_MessageText("Bạn chỉ được phép xem lại chứ không được phép nhập thêm."), LibMedi.AccessData.Msg);
                return;
            }
            if (bInchitiet && i_loaiba == 3)
            {
                string tenkp = m.inchiphipk(s_ngay, l_mavaovien);
                if (tenkp != "")
                {
                    MessageBox.Show(lan.Change_language_MessageText("Đã in chi phí tại") + " " + tenkp + " !", LibMedi.AccessData.Msg);
                    return;
                }
            }
            string _ngay = m.ngayhienhanh_server.Substring(0, 10);
            if (s_ngay.Substring(0, 10) != _ngay && i_loaiba == 2)
            {
                MessageBox.Show(lan.Change_language_MessageText("Ngày chỉ định không được khác ngày hiện hành") + " " + _ngay, LibMedi.AccessData.Msg);
                return;
            }
            l_id = 0;
            ena_object(true);
            bNew = true;
            //s_ngay = tmp_ngay;
            madoituong.SelectedValue = i_madoituong.ToString();
            //
            if (tinhtrang.Items.Count > 0) tinhtrang.SelectedIndex = 0;
            if (thuchien.Items.Count > 0) thuchien.SelectedIndex = 0;
            //
            if (tenbs.Text == "" && tenbs.Enabled) tenbs.Focus();
            else if (chandoan.Text == "" && chandoan.Enabled) chandoan.Focus();
            else ma.Focus();
        }

        private void butSua_Click(object sender, System.EventArgs e)
        {
            if (ds.Tables[0].Rows.Count == 0) return;
            if (bXemlai && s_ngay != m.ngayhienhanh_server && m.bAdminHethong(i_userid) == false)
            {
                MessageBox.Show(lan.Change_language_MessageText("Bạn chỉ được phép xem lại chứ không được phép sửa."), LibMedi.AccessData.Msg);
                return;
            }
            if (bInchitiet && i_loaiba == 3)
            {
                string tenkp = m.inchiphipk(s_ngay, l_mavaovien);
                if (tenkp != "")
                {
                    MessageBox.Show(lan.Change_language_MessageText("Đã in chi phí tại") + " " + tenkp + " !", LibMedi.AccessData.Msg);
                    return;
                }
            }

            try
            {
                i_row = dataGrid1.CurrentCell.RowNumber;
                bool bFound = true;
                i_row = dataGrid1.CurrentCell.RowNumber;
                l_id = decimal.Parse(dataGrid1[i_row, 1].ToString());
                tmp_ngay = s_ngay;
                s_ngay = dataGrid1[i_row, 3].ToString();
                DataTable tmp = m.getChidinh(s_ngay, l_id);
                if (tmp.Rows.Count > 0)
                {
                    if (tmp.Rows[0]["hide"].ToString() == "1")
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Số liệu chênh lệch không cho phép sửa !"), LibMedi.AccessData.Msg);
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
                    DialogResult dlg = MessageBox.Show(lan.Change_language_MessageText("Số liệu đã cập nhật không thể sửa !\nBạn có muốn nhập bổ sung thêm không?"), LibMedi.AccessData.Msg, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (dlg == DialogResult.No)
                        return;
                    else
                    {
                        l_id = 0;
                    }
                }
            }
            catch { l_id = 0; }
            bNew = false;
            ena_object(true);
            ten.Focus();
        }

        private bool kiemtra()
        {
            if (madoituong.SelectedIndex == -1)
            {
                madoituong.Focus();
                return false;
            }
            if (tinhtrang.SelectedIndex == -1)
            {
                tinhtrang.Focus();
                return false;
            }
            if (thuchien.SelectedIndex == -1)
            {
                thuchien.Focus();
                return false;
            }
            if (ten.Text == "" || mavp.Text == "")
            {
                ten.Focus();
                return false;
            }
            if (soluong.Text == "")
            {
                soluong.Focus();
                return false;
            }
            if (bCD_BS_Chidinh)
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
                    MessageBox.Show(lan.Change_language_MessageText("Người bệnh này không phải đối tượng")+" " + madoituong.Text, LibMedi.AccessData.Msg);
                    madoituong.Focus();
                    return false;
                }
            }
            return true;
        }

        private void butLuu_Click(object sender, System.EventArgs e)
        {
            DataRow r;
            //
            string a_sql = "";
            a_sql = "select id,id_nhom,id_loai,id_gia as mabd,sotien,stt,soluong,madoituong from medibv.v_trongoi where id_loai=-999 ";
            a_sql += "union all ";
            a_sql += "select a.id,a.id_nhom,a.id_loai,a.id_gia as mabd,a.sotien,a.stt,a.soluong,a.madoituong from medibv.v_trongoi a,medibv.v_giavp b,medibv.v_loaivp c ";
            a_sql += "where a.id_gia=b.id and b.id_loai=c.id and c.id_nhom=15 ";
            DataTable dtct = new DataTable();
            decimal l_idvpkhoa = 0;
            sql = "select a.stt,e.doituong,a.mabd,b.ma,trim(b.ten)||' '||b.hamluong as ten,nullif(b.tenhc,' ') ";
            sql += "as tenhc,b.dang,f.ten as tenkho,a.slyeucau as soluong,a.madoituong,a.makho,";
            sql += "nullif(a.cachdung,' ') as cachdung,b.mahc,' ' as diung,a.manguon,1 as tutruc,a.idvpkhoa,";
            sql += "a.solan,a.lan,0 as done ";
            sql += " from " + user + m.mmyy(s_ngay) + ".d_xtutrucct a," + user + ".d_dmbd b," + user + ".d_doituong e";
            sql += "," + user + ".d_dmkho f where a.mabd=b.id and a.madoituong=e.madoituong and a.makho=f.id and ";
            sql += "a.id=" + l_id + " order by a.stt";
            dtct = d.get_data(a_sql).Tables[0];
            upd_table(dtct, "-");
            dtct.AcceptChanges();
            if (dtct.Rows.Count > 0)
            {
                string s = "";
                foreach (DataRow rbd in dtct.Rows)
                {
                    if (d.get_tutrucct_dutru(m.mmyy(s_ngay), i_makp, int.Parse(s_makho.Trim(',')), 1, int.Parse(rbd["mabd"].ToString()), 0, i_nhom).Rows.Count == 0)
                    {
                        DataRow drbd = d.getrowbyid(dtdmbd, "id=" + rbd["mabd"].ToString());
                        s += drbd["ten"].ToString() + ",";
                    }
                }
                if (s != "")
                {
                    MessageBox.Show(lan.Change_language_MessageText("Những thuốc này: (") + s.Trim(',') + lan.Change_language_MessageText(") đã hết trong tủ trực"));
                    return;
                }
                //i_old = (bNew) ? 0 : 1;
                l_id = d.get_id_xuatsd;
                //itable = m.tableid(d.mmyy(s_ngay), "d_xtutrucll");
                DataTable tmp = new DataTable();
                bool bFound = false;
                //if (bNew) m.upd_eve_tables(s_ngay, itable, i_userid, "ins");
                //else
                //{
                //    m.upd_eve_tables(s_ngay, itable, i_userid, "upd");
                //    m.upd_eve_upd_del(s_ngay, itable, i_userid, "upd", l_id.ToString() + "^" + l_duyet.ToString() + "^" + mabn.Text + "^" + l_mavaovien.ToString() + "^" + l_maql.ToString() + "^" + l_idkhoa.ToString() + "^" + s_ngayvv + "^" + songay.Value.ToString());
                //}
                if (!bNew)
                {
                    sql = "select * from " + user + m.mmyy(s_ngay) + ".d_tienthuoc where mabn='" + mabn.Text + "' and mavaovien=" + l_mavaovien + " and maql=" + l_maql;
                    sql += " and idkhoa=" + l_idkhoa + " and id=" + l_id;
                    sql += " and to_char(ngay,'dd/mm/yyyy')='" + s_ngay + "'";
                    sql += " and done=1 and makp=" + s_makp;
                    tmp = m.get_data(sql).Tables[0];
                    bFound = true;
                    foreach (DataRow r1 in d.get_data("select a.*,b.manguon,b.giaban,b.giamua,a.soluong*b.giamua as sotien,b.gianovat, a.gia_bh from " + user + m.mmyy(s_ngay) + ".d_thucxuat a," + user + m.mmyy(s_ngay) + ".d_theodoi b where a.sttt=b.id and a.id=" + l_id).Tables[0].Rows)
                    {
                        d.upd_tonkhoct_thucxuat(d.delete, m.mmyy(s_ngay), i_makp, i_loai, 1, decimal.Parse(r1["sttt"].ToString()), int.Parse(r1["makho"].ToString()), int.Parse(r1["manguon"].ToString()), int.Parse(r1["mabd"].ToString()), decimal.Parse(r1["soluong"].ToString()));
                        d.upd_theodoicongno(d.delete, mabn.Text, l_mavaovien, l_maql, l_idkhoa, int.Parse(r1["madoituong"].ToString()), decimal.Parse(r1["sotien"].ToString()), "thuoc");
                        d.upd_tienthuoc(d.delete, m.mmyy(s_ngay), l_id, mabn.Text, l_mavaovien, l_maql, l_idkhoa, s_ngay, i_makp, i_loai, int.Parse(r1["madoituong"].ToString()), int.Parse(r1["mabd"].ToString()), decimal.Parse(r1["soluong"].ToString()), decimal.Parse(r1["giaban"].ToString()), decimal.Parse(r1["giamua"].ToString()), decimal.Parse(r1["gianovat"].ToString()), 0, decimal.Parse(r1["gia_bh"].ToString()),mabs.Text);
                    }
                    d.execute_data("delete from " + user + m.mmyy(s_ngay) + ".d_xuatsdct where id=" + l_id);
                    d.execute_data("delete from " + user + m.mmyy(s_ngay) + ".d_thucxuat where id=" + l_id);
                }
                if (l_duyet == 0)
                {
                    if (i_somay == 1)
                    {
                        if (d.get_data("select id from " + user + m.mmyy(s_ngay) + ".d_duyet where nhom=" + i_nhom + " and to_char(ngay,'dd/mm/yyyy')='" + s_ngay + "' and loai=" + i_loai + " and phieu=" + i_phieu + " and makhoa=" + s_makp).Tables[0].Rows.Count > 0)
                        {
                            MessageBox.Show(lan.Change_language_MessageText("Ngày ") + s_ngay + "\nKhoa " + s_tenkp + "\nPhiếu " + "s_tenphieu" + "\nĐã nhập !", LibMedi.AccessData.Msg);
                            return;
                        }
                    }
                    else
                    {
                        DataTable dtd = d.get_data("select id from " + user + m.mmyy(s_ngay) + ".d_duyet where nhom=" + i_nhom + " and to_char(ngay,'dd/mm/yyyy')='" + s_ngay + "'" + " and loai=" + i_loai + " and phieu=" + i_phieu + " and makhoa=" + s_makp).Tables[0];
                        if (dtd.Rows.Count != 0) l_duyet = decimal.Parse(dtd.Rows[0][0].ToString());
                        else l_duyet = d.get_id_duyet;
                    }
                    if (l_duyet == 0) l_duyet = d.get_id_duyet;
                    d.upd_duyet(m.mmyy(s_ngay), l_duyet, i_nhom, s_ngay, i_loai, i_phieu, i_makp, 0, i_userid, i_makhoa,0);
                    foreach (DataRow r1 in m.get_data("select * from " + user + ".d_dmkho where hide=0 and id in (" + s_makho.Substring(0, s_makho.Length - 1) + ")").Tables[0].Rows)
                        d.upd_duyetkho(m.mmyy(s_ngay), l_duyet, int.Parse(r1["id"].ToString()), 0);
                }
                else d.upd_duyet(m.mmyy(s_ngay), l_duyet, i_nhom, s_ngay, i_loai, i_phieu, i_makp, 0, i_userid, i_makhoa,0);
                //d.upd_dausinhton(m.mmyy(s_ngay), l_id, l_idkhoa, l_id, (bDausinhton) ? ngay.Text : s_ngay, mabs.Text, manv.Text, (mach.Text != "") ? decimal.Parse(mach.Text) : 0, (nhietdo.Text != "") ? decimal.Parse(nhietdo.Text) : 0, huyetap.Text, (nhiptho.Text != "") ? decimal.Parse(nhiptho.Text) : 0, (cannang.Text != "") ? int.Parse(cannang.Text) : 0, phong.Text, giuong.Text, ghichu.Text);
                if (!d.upd_xtutrucll(m.mmyy(s_ngay), l_id, l_duyet, mabn.Text, l_mavaovien, l_maql, l_idkhoa, s_ngay, 0))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin !"));
                    return;
                }
                d.execute_data("update " + user + m.mmyy(s_ngay) + ".d_xtutrucll set traituyen=" + i_traituyen + " where id=" + l_id);
                //itable = m.tableid(d.mmyy(s_ngay), "d_xtutrucct");
                if (!bNew)
                {
                    foreach (DataRow r1 in dsxoa.Tables[0].Rows)
                    {
                        //m.upd_eve_tables(s_ngay, itable, i_userid, "del");
                        //m.upd_eve_upd_del(s_ngay, itable, i_userid, "del", m.fields(xxx + ".d_xtutrucct", "id=" + l_id + " and stt=" + decimal.Parse(r1["stt"].ToString())));
                        d.execute_data("delete from " + user + m.mmyy(s_ngay) + ".d_xtutrucct where id=" + l_id + " and stt=" + decimal.Parse(r1["stt"].ToString()));
                        if (decimal.Parse(r1["idvpkhoa"].ToString()) != 0)
                            v.execute_data("delete from " + user + m.mmyy(s_ngay) + ".v_vpkhoa where id=" + decimal.Parse(r1["idvpkhoa"].ToString()));
                    }
                }
                foreach (DataRow r1 in dtct.Rows)
                {
                    if (m.get_data("select * from " + user + m.mmyy(s_ngay) + ".d_xtutrucct where id=" + l_id + " and stt=" + int.Parse(r1["stt"].ToString())).Tables[0].Rows.Count != 0)
                    {
                        //m.upd_eve_tables(s_ngay, itable, i_userid, "upd");
                        //m.upd_eve_upd_del(s_ngay, itable, i_userid, "upd", l_id.ToString() + "^" + r1["stt"].ToString() + "^" + r1["madoituong"].ToString() + "^" + r1["makho"].ToString() + "^" + r1["mabd"].ToString() + "^" + r1["soluong"].ToString() + "^" + "0" + "^" + r1["cachdung"].ToString() + "^" + r1["manguon"].ToString() + "^" + r1["idvpkhoa"].ToString() + "^" + r1["solan"].ToString() + "^" + r1["lan"].ToString());
                    }
                    //else m.upd_eve_tables(s_ngay, itable, i_userid, "ins");
                    d.upd_xtutrucct(m.mmyy(s_ngay), l_id, int.Parse(r1["stt"].ToString()),
                        (int.Parse(r1["madoituong"].ToString()) == 0) ? 5 : int.Parse(r1["madoituong"].ToString()), int.Parse(s_makho.Trim(',')),//int.Parse(r1["makho"].ToString()) 
                        int.Parse(r1["mabd"].ToString()), decimal.Parse(r1["soluong"].ToString()), 0,
                        "", 1, //r1["cachdung"].ToString(),int.Parse(r1["manguon"].ToString())
                        0, 1, //decimal.Parse(r1["idvpkhoa"].ToString()),decimal.Parse(r1["solan"].ToString())
                        0);//decimal.Parse(r1["solan"].ToString())
                    d.execute_data("update " + user + user + m.mmyy(s_ngay) + ".d_xtutrucll set traituyen=" + i_traituyen + " where id=" + l_id);
                }
                //d.updrec_dutrull(dtll, l_id, mabn.Text, l_mavaovien, l_maql, l_idkhoa, hoten.Text, mabs.Text, manv.Text, (bDausinhton) ? ngay.Text : s_ngay, (mach.Text != "") ? decimal.Parse(mach.Text) : 0, (nhietdo.Text != "") ? decimal.Parse(nhietdo.Text) : 0, huyetap.Text, (nhiptho.Text != "") ? decimal.Parse(nhiptho.Text) : 0, (cannang.Text != "") ? int.Parse(cannang.Text) : 0, phong.Text, giuong.Text, ghichu.Text, 0, 1, s_ngayvv);
                d.updrec_dutrull(dtll, l_id, mabn.Text, l_mavaovien, l_maql, l_idkhoa, hoten.Text, mabs.Text, "",
                    s_ngay, 0, 0, "0", 0, 0, "", "", "", 0, 1, s_ngay);
                #region xuatsd
                //itable = m.tableid(d.mmyy(s_ngay), "d_xuatsdll");
                //if (bNew) m.upd_eve_tables(s_ngay, itable, i_userid, "ins");
                //else
                //{
                //    m.upd_eve_tables(s_ngay, itable, i_userid, "upd");
                //    m.upd_eve_upd_del(s_ngay, itable, i_userid, "upd", l_id.ToString() + "^" + i_nhom.ToString() + "^" + mabn.Text + "^" + l_mavaovien.ToString() + "^" + l_maql.ToString() + "^" + l_idkhoa.ToString() + "^" + s_ngay + "^" + i_loai.ToString() + "^" + i_phieu.ToString() + "^" + i_makp.ToString() + "^" + i_userid.ToString() + "^" + l_id.ToString() + "^" + "1" + "^" + i_makhoa.ToString() + "^" + "0" + "^" + "0" + "^" + "");
                //}
                if (!d.upd_xuatsdll(m.mmyy(s_ngay), l_id, i_nhom, mabn.Text, l_mavaovien, l_maql, l_idkhoa, s_ngay, i_loai, i_phieu, i_makp, i_userid, l_id, 1, i_makhoa, 0, 0, "", s_ngay,0,""))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin phiếu lĩnh !"), d.Msg);
                    return;
                }
                d.execute_data("update " + user + m.mmyy(s_ngay) + ".d_xuatsdll set traituyen=" + i_traituyen + " where id=" + l_id);
                //
                try { dtct.Columns.Remove("makho"); dtct.Columns.Remove("manguon"); }
                catch { }
                DataColumn dc1 = new DataColumn("makho", typeof(string)); dc1.DefaultValue = s_makho.Trim(',');
                dtct.Columns.Add(dc1);
                DataColumn dc2 = new DataColumn("manguon", typeof(string)); dc2.DefaultValue = 1;
                dtct.Columns.Add(dc2);
                dtct.AcceptChanges();
                d.get_xuatsdct_cstt(m.mmyy(s_ngay), dtct.Select("soluong>0", "stt"), i_makp, // and idvpkhoa=0
                    i_makhoa, 0, l_id, mabn.Text, l_mavaovien, l_maql, l_idkhoa, i_loai, 1, s_ngay, i_nhom, 
                    s_ngay, i_traituyen,mabs.Text);
                if (bFound)
                {
                    sql = "delete from " + user + m.mmyy(s_ngay) + ".d_tienthuoc where mabn='" + mabn.Text + "' and mavaovien=" + l_mavaovien + " and maql=" + l_maql;
                    sql += " and idkhoa=" + l_idkhoa + " and id=" + l_id;
                    sql += " and to_char(ngay,'dd/mm/yyyy')='" + s_ngay + "'";
                    sql += " and done=1 and makp=" + i_makhoa + " and soluong=0";
                    d.execute_data(sql);
                    foreach (DataRow r1 in tmp.Rows)
                    {
                        sql = "update " + user + m.mmyy(s_ngay) + ".d_tienthuoc set done=" + int.Parse(r1["done"].ToString()) + ",idttrv=" + decimal.Parse(r1["idttrv"].ToString());
                        sql += " where mabn='" + mabn.Text + "' and mavaovien=" + l_mavaovien + " and maql=" + l_maql;
                        sql += " and idkhoa=" + l_idkhoa;
                        sql += " and to_char(ngay,'dd/mm/yyyy')='" + s_ngay + "' and makp=" + int.Parse(r1["makp"].ToString());
                        sql += " and id=" + l_id;
                        sql += " and madoituong=" + int.Parse(r1["madoituong"].ToString());
                        sql += " and mabd=" + decimal.Parse(r1["mabd"].ToString());
                        sql += " and done=0";
                        d.execute_data(sql);
                    }
                }
                if (d.get_data("select * from " + user + m.mmyy(s_ngay) + ".d_xuatsdct where id=" + l_id).Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin phiếu lĩnh chi tiết !"), d.Msg);
                    return;
                }
                decimal gia = 0;
                foreach (DataRow r1 in dtct.Select("soluong>0 and idvpkhoa<>0", "stt"))
                {
                    gia = d.get_dongia(m.mmyy(s_ngay), i_makp, int.Parse(r1["mabd"].ToString()), int.Parse(r1["makho"].ToString()), int.Parse(r1["manguon"].ToString()), int.Parse(r1["madoituong"].ToString()));
                    r = d.getrowbyid(dtdmbd, "id=" + int.Parse(r1["mabd"].ToString()));
                    if (r != null)
                    {
                        //itable = m.tableid(d.mmyy(s_ngay), "v_giavp");
                        //m.upd_eve_tables(s_ngay, itable, i_userid, "ins");
                        gia = (gia == 0) ? decimal.Parse(r["dongia"].ToString()) : gia;
                        v.upd_giavp(int.Parse(r1["mabd"].ToString()), decimal.Parse(r["loaivp"].ToString()), int.Parse(r["stt"].ToString()), r["ma"].ToString(), r["ten"].ToString().Trim() + " " + r["hamluong"].ToString(), r["dang"].ToString(), gia, gia, gia, gia, gia, int.Parse(r["bhyt"].ToString()), i_userid, 0, 0, 0, 0, 0, 0, 0, 0, "");
                    }
                    //itable = m.tableid(d.mmyy(s_ngay), "v_vpkhoa");
                    //m.upd_eve_tables(s_ngay, itable, i_userid, "ins");
                    l_idvpkhoa = decimal.Parse(r1["idvpkhoa"].ToString());
                    l_idvpkhoa = (l_idvpkhoa == 0 || l_idvpkhoa == -1) ? v.get_id_vpkhoa : l_idvpkhoa;
                    v.upd_vpkhoa(l_idvpkhoa, mabn.Text, l_mavaovien, l_maql, l_idkhoa, s_ngay, s_makp, int.Parse(r1["madoituong"].ToString()), int.Parse(r1["mabd"].ToString()), decimal.Parse(r1["soluong"].ToString()), gia, 0, i_userid, i_buoi);
                    d.upd_theodoicongno(d.insert, mabn.Text, l_mavaovien, l_maql, l_idkhoa, int.Parse(r1["madoituong"].ToString()), Math.Round(decimal.Parse(r1["soluong"].ToString()) * gia, 3), "vienphi");
                    d.execute_data("update " + user + m.mmyy(s_ngay) + ".d_xtutrucct set idvpkhoa=" + l_idvpkhoa + " where id=" + l_id + " and stt=" + int.Parse(r1["stt"].ToString()));
                }
                #endregion
                if (!kiemtrasoluong(d.get_data("select mabd,sum(soluong) as soluong from " + user + m.mmyy(s_ngay) + ".d_xuatsdct where id=" + l_id + " group by mabd").Tables[0], load_thuoc()))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Số lượng không đủ trong tủ trực !"), LibMedi.AccessData.Msg);
                    //del();
                    butBoqua_Click(sender, e);
                    return;
                }
                //try
                //{
                //    if (i_old == 0 && dtll.Rows.Count > 0) cmbMabn.SelectedIndex = dtll.Rows.Count - 1;
                //}
                //catch { }
                //if (bDiungthuoc) upd_diung();
                ref_text();
                //if (Tamung_min != 0 && bThongbaoChiphi) thongbao(false);
                butMoi.Focus();
                //
            }
            if (!kiemtra()) return;
            DataRow[] dr = dt.Select("trongoi=1 and id=" + int.Parse(mavp.Text));
            if (!bLocdichvu && madoituong.SelectedValue.ToString() == "1")
            {
                sql = "id=" + decimal.Parse(mavp.Text) + " and bhyt<>0";
                if (sothe.Text.Trim().Length > v1 + v2) sql += " and (locthe='' or locthe is null or locthe like '%" + sothe.Text.Trim().Substring(v1, v2) + "%' or locthe like '%" + sothe.Text.Substring(0, 2) + ",%')";
                if (m.getrowbyid(dt, sql) == null)
                {
                    madoituong.SelectedValue = 2;// i_tunguyen.ToString();
                    madoituong.Update();
                }
            }
            decimal st = 0;
            string fie = "gia_th";
            //DataRow r;
            int _madt = (madoituong.SelectedIndex != -1) ? int.Parse(madoituong.SelectedValue.ToString()) : 0;
            if (dr.Length > 0)
            {
                sql = "select a.* from " + user + ".v_trongoi a," + user + ".v_giavp b ";
                sql += " where a.id_gia=b.id and a.id=" + int.Parse(mavp.Text);
                if (madoituong.SelectedValue.ToString() == "1" & bLocdichvu) sql += " and b.bhyt>0";
                sql += " order by a.stt";
                foreach (DataRow r1 in v.get_data(sql).Tables[0].Rows)
                {
                    l_id = 0; st = decimal.Parse(r1["sotien"].ToString());
                    if (bTrongoi_doituong)
                    {
                        fie = m.field_gia(_madt.ToString());
                        r = m.getrowbyid(dt, "id=" + int.Parse(r1["id_gia"].ToString()));
                        if (r != null) st = decimal.Parse(r[fie].ToString());
                    }
                    upd_data(int.Parse(r1["id_gia"].ToString()), decimal.Parse(r1["soluong"].ToString()), (int.Parse(r1["madoituong"].ToString()) == 0) ? _madt : int.Parse(r1["madoituong"].ToString()), st, int.Parse(r1["id"].ToString()));
                    if (s_table == "xxx.tiepdon") upd_tiepdon(decimal.Parse(r1["id"].ToString()), decimal.Parse(r1["id_gia"].ToString()));
                }
                if (l_id == 0) upd_data(int.Parse(mavp.Text), decimal.Parse(soluong.Text), _madt, 0, 0);
            }
            else upd_data(int.Parse(mavp.Text), decimal.Parse(soluong.Text), _madt, 0, 0);
            getTong();

            load_grid();
            ena_object(false);
        }
        private DataTable load_thuoc()
        {
            sql = "select mabd,sum(slyeucau) as soluong from " + user + m.mmyy(s_ngay) + ".d_xtutrucct where id=" + l_id + "group by mabd";
            return d.get_data(sql).Tables[0];
        }
        private bool kiemtrasoluong(DataTable dt1, DataTable dt2)
        {
            string ma1 = "", ma2 = "";
            int so = dt1.Select("soluong>0").Length;
            foreach (DataRow r in dt1.Select("soluong>0", "mabd,soluong")) ma1 += r["mabd"].ToString().PadLeft(7, '0') + r["soluong"].ToString().Trim() + ",";
            foreach (DataRow r in dt2.Select("soluong>0", "mabd,soluong")) ma2 += r["mabd"].ToString().PadLeft(7, '0') + r["soluong"].ToString().Trim() + ",";
            return ma1 == ma2;
        }
        private bool upd_table(DataTable dt, string tt)
        {
            //if (!KiemtraDetail(tt)) return false;
            //d_soluong = (soluong.Text != "") ? decimal.Parse(soluong.Text) : 0;
            //d.updrec_dutruct(tt, dt, int.Parse(stt.Text), madoituong.Text, i_mabd, mabd.Text, tenbd.Text,
            //    tenhc.Text, dang.Text, makho.Text, d_soluong, int.Parse(madoituong.SelectedValue.ToString()),
            //    int.Parse(makho.SelectedValue.ToString()), cachdung.Text, mahc.Text,
            //    int.Parse(manguon.SelectedValue.ToString()), 1, (vpkhoa.Checked) ? 0 : (l_idvpkhoa == 0) ? -1 :
            //    l_idvpkhoa, solan.Value, (moilan.Text != "") ? decimal.Parse(moilan.Text) : 1, dtton, i_mabdcu);
            //if (tt == "-")
            //{
            //    DataRow r = d.getrowbyid(dt, "stt=" + int.Parse(stt.Text));
            //    if (r != null) r["done"] = i_done;
            //}
            return true;
        }
        private void upd_tiepdon(decimal idgiavp, decimal id)
        {
            DataTable tmp = m.get_data("select * from " + user + ".v_trongoipk where idgiavp=" + idgiavp + " and id=" + id + " order by stt").Tables[0];
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
                        m.upd_tiepdon(s_mabn, l_maql, _maql, r["makp"].ToString(), ngay, int.Parse(r1["madoituong"].ToString()), r1["sovaovien"].ToString(), r1["tuoivao"].ToString(), i_userid, int.Parse(r1["bnmoi"].ToString()), int.Parse(r1["noitiepdon"].ToString()), int.Parse(r1["loai"].ToString()));
                        if (r1["sothe"].ToString().Trim() != "")
                            m.upd_bhyt(ngay, s_mabn, _maql, r1["sothe"].ToString(), r1["denngay"].ToString(), r1["mabv"].ToString(), 0, r1["tungay"].ToString(), r1["ngay1"].ToString(), r1["ngay2"].ToString(), r1["ngay3"].ToString(), int.Parse(r1["traituyen"].ToString()));
                        m.upd_sukien(ngay, s_mabn, l_maql, int.Parse(r1["noitiepdon"].ToString()), _maql);
                        m.upd_lienhe(ngay, _maql, r1["sonha"].ToString(), r1["thon"].ToString(), r1["cholam"].ToString(), r1["matt"].ToString(), r1["maqu"].ToString(), r1["maphuongxa"].ToString(), r1["tuoivao"].ToString(), int.Parse(r1["loai"].ToString()), int.Parse(r1["bnmoi"].ToString()));
                        j++;
                    }
                }
                m.execute_data("update " + xxx + ".tiepdon set done='x' where maql=" + l_maql + " and done is null");
            }
        }
        private void upd_data(int i_mavp, decimal d_soluong, int i_madt, decimal dongia, int idtrongoi)
        {
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
            r = m.getrowbyid(dt, "id=" + i_mavp);
            if (r != null)
            {
                if (bChenhlech_doituong) bCont = bCont && s_chenhlech.IndexOf(i_madoituongvao.ToString().Trim() + ",") != -1;
                else bCont = bCont && s_chenhlech.IndexOf(i_madt.ToString().Trim() + ",") != -1;
                //bCont = bCont && s_chenhlech.IndexOf(i_madt.ToString().Trim() + ",") != -1
                //        && r["chenhlech"].ToString().Trim() == "1" 
                //        && decimal.Parse(r[m.field_gia(i_tunguyen.ToString())].ToString()) > decimal.Parse(r[fie].ToString());
                bCont = bCont && r["chenhlech"].ToString().Trim() == "1"
                        && decimal.Parse(r[m.field_gia(i_tunguyen.ToString())].ToString()) > decimal.Parse(r[fie].ToString());
                if (!bChidinh_thutienlien) bCont = bCont && i_loaiba == 3;
                if (bChenhlech_doituong) bCont = bCont && (i_madt == i_tunguyen);
                if (i_madoituongvao == 1) bCont = bCont && (decimal.Parse(r["bhyt"].ToString()) > 0);
                if (bCont)
                {
                    madoituong.SelectedValue = i_madoituongvao.ToString();
                    madoituong.Update();
                    upd_detail(false, i_mavp, d_soluong, dongia, idtrongoi);
                    l_id = 0;
                    madoituong.SelectedValue = i_tunguyen.ToString();
                    madoituong.Update();
                    upd_detail(true, i_mavp, d_soluong, dongia, idtrongoi);
                }
                else
                {
                    madoituong.SelectedValue = i_madt.ToString();
                    madoituong.Update();
                    upd_detail(false, i_mavp, d_soluong, dongia, idtrongoi);
                }
                if (bTinnhan) netsend(r["computer"].ToString());
                if (bTinnhan_sound) m.upd_tinnhan((bChidinh_ngtru_vienphi) ? r["computervp"].ToString() : r["computer"].ToString(), (bChidinh_ngtru_vienphi) ? "vienphi" : "cls", 1);
            }
        }

        private void upd_detail(bool chenhlech, int i_mavp, decimal d_soluong, decimal dongia, int idtrongoi)
        {
            string gia, giavt;
            decimal tygia, dg_giam = 0, vt_giam = 0;
            DataRow r = m.getrowbyid(dt, "id=" + i_mavp);
            if (r != null)
            {
                if (chenhlech)
                {
                    gia = m.field_gia(madoituong.SelectedValue.ToString());
                    giavt = "vattu_" + gia.Substring(4).Trim();
                    tygia = (gia.IndexOf("_nn") != -1) ? m.dTygia : 1;
                    d_dongia = decimal.Parse(r[gia].ToString()) * tygia - decimal.Parse(r["gia_bh"].ToString());
                    d_vattu = decimal.Parse(r[giavt].ToString()) * tygia - decimal.Parse(r["vattu_bh"].ToString());
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
                    d_dongia = decimal.Parse(r[gia].ToString()) * tygia;
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

        private void butBoqua_Click(object sender, System.EventArgs e)
        {
            ena_object(false);
            if (bMadoituong) { madoituong.Enabled = true; chkmadt_def.Enabled = true; madoituong.SelectedValue = i_madoituong; }
        }

        private void butHuy_Click(object sender, System.EventArgs e)
        {
            if (ds.Tables[0].Rows.Count == 0) return;
            if (bXemlai && s_ngay != m.ngayhienhanh_server && m.bAdminHethong(i_userid) == false)
            {
                MessageBox.Show(lan.Change_language_MessageText("Bạn chỉ được phép xem lại chứ không được phép hủy."), LibMedi.AccessData.Msg);
                return;
            }
            try
            {
                bool bFound = true;
                i_row = dataGrid1.CurrentCell.RowNumber;
                l_id = decimal.Parse(dataGrid1[i_row, 1].ToString());
                string s_ngaycd = dataGrid1[i_row, 3].ToString();
                string s_tendv = dataGrid1[i_row, 5].ToString();
                DataTable tmp = m.getChidinh(s_ngay, l_id);
                if (tmp.Rows.Count > 0)
                {
                    if (tmp.Rows[0]["hide"].ToString() == "1")
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Số liệu chênh lệch không cho phép hủy !"), LibMedi.AccessData.Msg);
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
                    MessageBox.Show(lan.Change_language_MessageText("Số liệu đã cập nhật không thể hủy !"), LibMedi.AccessData.Msg);
                    return;
                }
                if (bInchitiet && i_loaiba == 3)
                {
                    string tenkp = m.inchiphipk(s_ngay, l_mavaovien);
                    if (tenkp != "")
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Đã in chi phí tại") + " " + tenkp + " !", LibMedi.AccessData.Msg);
                        return;
                    }
                }
                if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý hủy '" + s_tendv + "' ?"), LibMedi.AccessData.Msg, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    bool dChenhlech = false;
                    int itable = m.tableid(m.mmyy(s_ngay), "v_chidinh");
                    m.upd_eve_tables(s_ngay, itable, i_userid, "del");
                    m.upd_eve_upd_del(s_ngay, itable, i_userid, "del", m.fields(user + m.mmyy(s_ngay) + ".v_chidinh", "id=" + l_id));
                    DataTable tmp1 = m.get_data("select * from " + user + m.mmyy(s_ngay) + ".v_chidinh where id=" + l_id).Tables[0];
                    m.execute_data("delete from " + user + m.mmyy(s_ngay) + ".v_chidinh where id=" + l_id);
                    if (tmp.Rows.Count > 0)
                    {
                        if (m.get_data("select id from " + user + ".v_giavp where chenhlech=1 and id=" + decimal.Parse(tmp1.Rows[0]["mavp"].ToString())).Tables[0].Rows.Count > 0)
                        {
                            sql = "delete from " + user + m.mmyy(s_ngay) + ".v_chidinh where maql=" + l_maql + " and mavaovien=" + l_mavaovien;
                            sql += " and madoituong=" + i_tunguyen + " and userid=" + decimal.Parse(tmp1.Rows[0]["userid"].ToString());
                            sql += " and to_char(ngay,'dd/mm/yyyy')='" + s_ngaycd.Substring(0, 10) + "' and hide=1 and done=1 and mavp=" + decimal.Parse(tmp1.Rows[0]["mavp"].ToString());
                            sql += " and idchidinh=" + decimal.Parse(tmp1.Rows[0]["idchidinh"].ToString());
                            sql += " and idkhoa=" + decimal.Parse(tmp1.Rows[0]["idkhoa"].ToString());
                            sql += " and loai=" + decimal.Parse(tmp1.Rows[0]["loai"].ToString());
                            sql += " and makp='" + tmp1.Rows[0]["makp"].ToString() + "'";
                            m.execute_data(sql);
                            dChenhlech = true;
                        }
                    }
                    if (dChenhlech) load_grid();
                    else m.delrec(ds.Tables[0], "id=" + l_id);
                    ref_text();
                    getTong();
                }
            }
            catch { }
        }

        private void butKetthuc_Click(object sender, System.EventArgs e)
        {
            m.close(); this.Close();
        }

        private void butLietke_Click(object sender, System.EventArgs e)
        {
            if (bInchitiet && i_loaiba == 3)
            {
                string tenkp = m.inchiphipk(s_ngay, l_mavaovien);
                if (tenkp != "")
                {
                    MessageBox.Show(lan.Change_language_MessageText("Đã in chi phí tại") + " " + tenkp + " !", LibMedi.AccessData.Msg);
                    return;
                }
            }
            string _ngay = m.ngayhienhanh_server.Substring(0, 10);
            if (s_ngay.Substring(0, 10) != _ngay && i_loaiba == 2)
            {
                MessageBox.Show(lan.Change_language_MessageText("Ngày chỉ định không được khác ngày hiện hành") + " " + _ngay, LibMedi.AccessData.Msg);
                return;
            }
            if (madoituong.SelectedIndex == -1 || i_madoituong == 0)
            {
                madoituong.Focus(); return;
            }
            if (tinhtrang.SelectedIndex == -1 && tinhtrang.Items.Count > 0) tinhtrang.SelectedIndex = 0;
            if (thuchien.SelectedIndex == -1 && thuchien.Items.Count > 0) thuchien.SelectedIndex = 0;
            if (tinhtrang.SelectedIndex == -1)
            {
                tinhtrang.Focus(); return;
            }
            if (thuchien.SelectedIndex == -1)
            {
                thuchien.Focus(); return;
            }
            chandoan.Text = s_chandoan;
            mabs.Text = s_mabs;
            DataRow r2 = m.getrowbyid(dtbs, "ma='" + mabs.Text + "'");
            tenbs.Text = (r2 != null) ? r2["hoten"].ToString() : "";
            if (madoituong.Enabled == false) madoituong.SelectedValue = i_madoituong.ToString();
            int tmp_madoituong = int.Parse(madoituong.SelectedValue.ToString());
            //frmChonchidinh f = new frmChonchidinh(m, s_mabn, i_madoituong, s_loaivp, s_mucvp, i_loai, sothe.Text, v1, v2, false);
            frmChonchidinh f = new frmChonchidinh(m, s_mabn, tmp_madoituong, s_loaivp, s_mucvp, i_loai, sothe.Text, v1, v2, false);
            f.ShowDialog(this);
            if (f.dt.Rows.Count > 0)
            {
                DataRow[] dr;
                int _madt = int.Parse(madoituong.SelectedValue.ToString());
                int tmp_madt = _madt;
                decimal st = 0;
                string fie = "gia_th";
                foreach (DataRow r in f.dt.Rows)
                {
                    _madt = tmp_madt;
                    if (!bLocdichvu && _madt == 1)
                    {
                        sql = "id=" + int.Parse(r["mavp"].ToString()) + " and bhyt<>0";
                        if (sothe.Text.Trim().Length > v1 + v2) sql += " and (locthe='' or locthe is null or locthe like '%" + sothe.Text.Trim().Substring(v1, v2) + "%' or locthe like '%" + sothe.Text.Substring(0, 2) + ",%')";
                        if (m.getrowbyid(dt, sql) == null)
                        {
                            _madt = i_tunguyen;
                            //madoituong.SelectedValue = 2;// i_tunguyen.ToString();
                            //madoituong.Update();
                        }
                    }
                    l_id = 0;

                    dr = dt.Select("trongoi=1 and id=" + int.Parse(r["mavp"].ToString()));
                    if (dr.Length > 0)
                    {
                        sql = "select a.* from " + user + ".v_trongoi a," + user + ".v_giavp b ";
                        sql += " where a.id_gia=b.id and a.id=" + int.Parse(r["mavp"].ToString());
                        if (madoituong.SelectedValue.ToString() == "1" && bLocdichvu) sql += " and b.bhyt>0";
                        sql += " order by a.stt";
                        foreach (DataRow r1 in v.get_data(sql).Tables[0].Rows)
                        {
                            l_id = 0; st = decimal.Parse(r1["sotien"].ToString());
                            if (bTrongoi_doituong)
                            {
                                fie = m.field_gia(madoituong.SelectedValue.ToString());
                                r2 = m.getrowbyid(dt, "id=" + int.Parse(r1["id_gia"].ToString()));
                                if (r2 != null) st = decimal.Parse(r2[fie].ToString());
                            }
                            upd_data(int.Parse(r1["id_gia"].ToString()), decimal.Parse(r1["soluong"].ToString()), (int.Parse(r1["madoituong"].ToString()) == 0) ? _madt : int.Parse(r1["madoituong"].ToString()), st, int.Parse(r1["id"].ToString()));
                            if (s_table == "xxx.tiepdon") upd_tiepdon(decimal.Parse(r1["id"].ToString()), decimal.Parse(r1["id_gia"].ToString()));
                        }
                        if (l_id == 0) upd_data(int.Parse(r["mavp"].ToString()), decimal.Parse(r["soluong"].ToString()), _madt, 0, 0);
                    }
                    else upd_data(int.Parse(r["mavp"].ToString()), decimal.Parse(r["soluong"].ToString()), _madt, 0, 0);
                }
                getTong();
            }
        }

        private void load_treeView()
        {
            treeView1.Nodes.Clear();
            TreeNode node;
            if (l_idkhoa == 0)
            {
                sql = "select distinct a.ngay,a.maql,0 as idkhoa from " + user + "." + s_table + " a,xxx.v_chidinh b where a.maql=b.maql";
                sql += " and a.mabn='" + s_mabn + "'";
                if (iChidinh == 2) sql += " and a.maql='" + l_maql + "'";
                sql += " order by a.ngay desc";
            }
            else
            {
                sql = "select distinct a.ngay,a.maql,a.id as idkhoa from " + user + "." + s_table + " a,xxx.v_chidinh b where a.id=b.idkhoa";
                sql += " and a.mabn='" + s_mabn + "'";
                if (iChidinh == 2) sql += " and a.maql='" + l_maql + "'";
                else if (iChidinh == 3) sql += " and a.id='" + l_idkhoa + "'";
                sql += " order by a.ngay desc";
            }
            //TU:13/04/2011
            if (nam != "" && nam != null)
                dtngay = (iChidinh > 1) ? m.get_data_nam(m.mmyy(s_ngay) + "+", sql).Tables[0] : m.get_data_nam(nam, sql).Tables[0];
            else
                dtngay = m.get_data_nam(m.mmyy(s_ngay) + "+", sql).Tables[0];
            //end TU
            foreach (DataRow r in dtngay.Rows)
            {
                node = treeView1.Nodes.Add(m.DateToString("dd/MM/yyyy HH:mm", DateTime.Parse(r["ngay"].ToString())));
                sql = "select b.ten from " + user + m.mmyy(m.DateToString("dd/MM/yyyy HH:mm", DateTime.Parse(r["ngay"].ToString()))) + ".v_chidinh a," + user + ".v_giavp b where a.mavp=b.id";
                if (l_idkhoa == 0) sql += " and a.maql=" + decimal.Parse(r["maql"].ToString());
                else sql += " and a.idkhoa=" + decimal.Parse(r["idkhoa"].ToString());
                foreach (DataRow r1 in m.get_data(sql).Tables[0].Rows)
                    node.Nodes.Add(r1["ten"].ToString());
                r["ngay"] = m.StringToDateTime(m.DateToString("dd/MM/yyyy HH:mm", DateTime.Parse(r["ngay"].ToString())));
            }
        }

        private void treeView1_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            if (e.Action == TreeViewAction.ByMouse)
            {
            }
        }

        private void list_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
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
                            if (sothe.Text.Trim().Length > v1 + v2) sql += " and (locthe='' or locthe is null or locthe like '%" + sothe.Text.Trim().Substring(v1, v2) + "%' or locthe like '%" + sothe.Text.Substring(0, 2) + ",%')";
                            if (m.getrowbyid(dt, sql) == null)
                            {
                                madoituong.SelectedValue = 2;// i_tunguyen.ToString();
                                madoituong.Update();
                            }
                        }
                        string gia = m.field_gia(madoituong.SelectedValue.ToString());
                        string giavt = "vattu_" + gia.Substring(4).Trim();
                        decimal tygia = (gia.IndexOf("_nn") != -1) ? m.dTygia : 1;
                        d_dongia = decimal.Parse(r[gia].ToString()) * tygia;
                        d_vattu = decimal.Parse(r[giavt].ToString()) * tygia;
                    }
                }
                catch { s_dvt = ""; d_dongia = 0; d_vattu = 0; }
            }
        }

        private void tinhtrang_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (tinhtrang.SelectedIndex == -1) tinhtrang.SelectedIndex = 0;
                SendKeys.Send("{Tab}");
            }
        }

        private void thuchien_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (tinhtrang.SelectedIndex == -1) tinhtrang.SelectedIndex = 0;
                SendKeys.Send("{Tab}");
            }
        }

        private void mavp_Validated(object sender, System.EventArgs e)
        {
            if (ma.Text != "")
            {
                sql = "ma='" + ma.Text + "'";
                if (madoituong.SelectedValue.ToString() == "1" && bLocdichvu)
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
                DataRow r = m.getrowbyid(dt, sql);
                if (r != null)
                {
                    s_dvt = r["dvt"].ToString();
                    ten.Text = r["ten"].ToString();
                    mavp.Text = r["id"].ToString();
                    if (!bLocdichvu && madoituong.SelectedValue.ToString() == "1")
                    {
                        sql = "id=" + decimal.Parse(mavp.Text) + " and bhyt<>0";
                        if (sothe.Text.Trim().Length > v1 + v2) sql += " and (locthe='' or locthe is null or locthe like '%" + sothe.Text.Trim().Substring(v1, v2) + "%' or locthe like '%" + sothe.Text.Substring(0, 2) + ",%')";
                        if (m.getrowbyid(dt, sql) == null)
                        {
                            madoituong.SelectedValue = 2;// i_tunguyen.ToString();
                            madoituong.Update();
                        }
                    }
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
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void butNet_Click(object sender, System.EventArgs e)
        {
            string s1 = "", s2 = "";
            DataRow r1;
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                r1 = m.getrowbyid(dt, "id=" + int.Parse(r["mavp"].ToString()));
                if (r1 != null)
                    if (s1.IndexOf(r1["computer"].ToString().Trim() + "+") == -1) s1 += r1["computer"].ToString().Trim() + "+";
            }
            m.writeXml("d_netsend", "ma", s1);
            m.writeXml("d_netsend", "ten", s2);
            NetSend f = new NetSend();
            f.ShowDialog(this);
        }

        private void netsend(String computer)
        {
            if (bTinnhan && computer != "")
                d.netsend(d.sDomain(i_nhom), computer, mabn.Text + " " + m.khongdau(hoten.Text));
        }

        private void frmChidinhtiemchung_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F6:
                    butLietke_Click(sender, e);
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
            fprint("rptChidinhcls.rpt", false);
        }

        private void fprint(string tenfile, bool chitiet)
        {
            if (bAdminInlaidonthuoc)
            {
                if (!bAdmin && s_ngay.Substring(0, 10) != m.ngayhienhanh_server.Substring(0, 10))
                {
                    MessageBox.Show(lan.Change_language_MessageText("Bạn không có quyền in lại chỉ định của ngày trước !"), LibMedi.AccessData.Msg);
                    return;
                }
            }
            string s_id = "";
            foreach (DataRow r1 in ds.Tables[0].Select("chon=true")) s_id += r1["id"].ToString() + ",";
            //
            if (m.bInchidinh_dien && s_id != "")
            {
                DLLPrintchidinh.frmPrintchidinh f1 = new DLLPrintchidinh.frmPrintchidinh();
                f1.f_Print_Chidinh(false, s_mabn, l_maql.ToString(), "", s_ngay.Substring(0, 10), s_id);
                return;
            }
            else if (m.bInchidinh_dien && s_id == "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Đề nghị dịch vụ cần in phiếu chỉ định."), LibMedi.AccessData.Msg);
                return;
            }
            //
            string sophieu = "";
            if (bSophieu_chidinh) sophieu = "CD" + s_ngay.Substring(8, 2) + s_ngay.Substring(3, 2) + s_ngay.Substring(0, 2) + m.get_sophieucls(m.mmyy(s_ngay), mabn.Text, l_mavaovien, s_ngay.Substring(0, 10), 1, 0).ToString().PadLeft(4, '0');
            sql = "select ";
            if (bChidinh_loaivp) sql += "e.ten as nhomvp,";
            else sql += "f.ten as nhomvp,";
            sql += " e.ten as tenloaivp, e.stt as sttloai, f.ten as tennhomvp, f.stt as sttnhom, ";
            sql += "a.mabn,g.hoten,";
            sql += int.Parse(s_ngay.Substring(6, 4)) + "-to_number(g.namsinh,'0000') as tuoi,";
            sql += "trim(g.sonha)||' '||trim(g.thon)||' '||trim(j.tenpxa)||','||trim(i.tenquan)||','||trim(h.tentt) as diachi,";
            sql += "case when g.phai=0 then 'Nam' else 'Nữ' end as phai,d.tenkp,b.ten,b.dvt,a.soluong,";
            if (s_table == "xxx.tiepdon") sql += "a.chandoan,'' as maicd,";
            else sql += "coalesce(a.chandoan,a.chandoan) as chandoan,a.maicd,";
            if (l_idkhoa == 0) sql += "'' as giuong,";
            else sql += "c.giuong,";
            sql += "m.ten as tinhtrang,n.ten as thuchien,";
            sql += " case when x.sothe is null then x1.sothe else x.sothe end as sothe,";
            sql += " case when x.tungay is null then to_char(x1.tungay,'dd/mm/yyyy')  else to_char(x.tungay,'dd/mm/yyyy') end as tungay,";
            sql += " case when x.denngay is null then to_char(x1.denngay,'dd/mm/yyyy')  else to_char(x.denngay,'dd/mm/yyyy') end as denngay,";
            sql += " case when y.tenbv is null then y1.tenbv else y.tenbv end as noigioithieu,";
            if (s_table == "xxx.tiepdon") sql += "'' as tenbs,a.mabs";
            else sql += "p.hoten as tenbs,a.mabs";
            sql += ",a.madoituong,z.doituong,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay,a.mavp,b.chenhlech,b.gia_th,b.gia_bh,b.gia_dv,b.gia_cs,b.gia_nn,b.gia_ksk,a.ghichu";
            sql += ", a.loaiba";
            sql += " from xxx.v_chidinh a inner join " + user + ".v_giavp b on a.mavp=b.id ";
            if (l_idkhoa == 0) sql += " left join " + user + "." + s_table + " c on a.maql=c.maql ";
            else sql += " left join " + user + "." + s_table + " c on a.idkhoa=c.id";
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
            sql += " left join xxx.bhyt x on a.maql=x.maql ";
            sql += " left join " + user + ".bhyt x1 on a.maql=x1.maql ";
            sql += " left join " + user + ".dmnoicapbhyt y on x.mabv=y.mabv";
            sql += " left join " + user + ".dmnoicapbhyt y1 on x1.mabv=y1.mabv";
            sql += " inner join " + user + ".doituong z on a.madoituong=z.madoituong ";
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
                if (i_madoituongvao == 1 && dstmp.Tables[0].Select("chenhlech=1").Length > 0)
                {
                    foreach (DataRow r1 in dstmp.Tables[0].Select("chenhlech=1 and madoituong=" + i_tunguyen, "mabn,ngay,mavp"))
                        if (r1[m.field_gia(i_tunguyen.ToString())].ToString() != r1["gia_bh"].ToString())
                            m.delrec(dstmp.Tables[0], "mabn='" + r1["mabn"].ToString() + "' and mavp=" + int.Parse(r1["mavp"].ToString()) + " and ngay='" + r1["ngay"].ToString() + "' and madoituong=" + i_tunguyen);
                    dstmp.AcceptChanges();
                }
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
                dstmp.Tables[0].Columns.Add("sophieu");
                if (bSophieu_chidinh) foreach (DataRow r in dstmp.Tables[0].Rows) r["sophieu"] = sophieu;
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
                            for (int j = 0; j < dst.Tables[0].Columns.Count; j++) r[j] = r1[j].ToString();
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
                else print.Printer(m, dstmp, tenfile, s_ngay.Substring(0, 10), 1);
            }
        }

        private void chkmadt_def_CheckedChanged(object sender, EventArgs e)
        {
            bMadoituong = !chkmadt_def.Checked;
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
                listBS.BrowseToDanhmuc(tenbs, mabs, chandoan);
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
            m.writeXml("thongso", "chkIntheodot_chidinhclspk", (chkIntheodot.Checked) ? "1" : "0");
            load_grid();
        }

        private void f_capnhat_db()
        {
            string xxx = m.user + m.mmyy(s_ngay);
            string asql = "alter table " + xxx + ".v_chidinh add tylegiam numeric(5,2) default 0";
            m.execute_data(asql, false);
            asql = "alter table " + xxx + ".v_chidinh add stgiam numeric(18) default 0";
            m.execute_data(asql, false);
            asql = "alter table " + xxx + ".v_chidinh add lydogiam text";
            m.execute_data(asql, false);
        }
    }
}