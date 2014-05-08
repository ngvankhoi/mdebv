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
    public class frmPhanungthuoccohai : System.Windows.Forms.Form
    {
        #region Khai bao
        private Language lan = new Language();
        private int status_moi = 0;
        private decimal idpu = 0;
        public DataSet dsthuoc = new DataSet();
        public DataSet dsthuocsddongthoi = new DataSet();
        public string s_xetnghiem = "";
        protected LibList.List listICD;
        private LibMedi.AccessData m;
        private LibVienphi.AccessData v = new LibVienphi.AccessData();
        private System.Windows.Forms.ToolTip toolTip1;
        private System.ComponentModel.IContainer components;
        private string sql, s_makp, s_mabn, user, xxx, s_cd_chinh, s_sovaovien, s_cd_kemtheo, s_userid, s_ngay = "";
        private int i_userid, i_madoituong, i_loai, i_maba, i_mabv, i_loaiba;
        private DataTable dtnv = new DataTable();
        private DataTable dtg = new DataTable();
        private DataTable dtdt = new DataTable();
        private DataSet ds = new DataSet();
        private System.Windows.Forms.Label label7;
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
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label37;
        private DataSet dscd = new DataSet();
        private DataSet dsct = new DataSet();
        private DataTable dtba = new DataTable();
        private DataTable dt = new DataTable();
        private DataTable dthinh = new DataTable();
        private DataTable dticd = new DataTable();
        DataSet dsthuoc_ = new DataSet();
        private decimal l_maql, l_id, l_mavaovien;
        //private bool b_sovaovien,b_soluutru,bAdmin;
        private System.Windows.Forms.TabPage tab2;
        private System.Windows.Forms.TabPage tab4;
        private System.Windows.Forms.CheckBox chkXML;
        private System.Windows.Forms.Label label20;
        private GroupBox groupBox2;
        private TextBox dantoc;
        private Label label6;
        private Label label18;
        private Label label12;
        private Label label13;
        private TextBox cannang;
        private Label label11;
        private Label label2;
        private TextBox chieucao;
        private TextBox msbcdonvi;
        private Label label25;
        private TextBox msbctt;
        private Label label24;
        private DataGridView dgvThuoc;
        private DataGridViewTextBoxColumn ten;
        private DataGridViewTextBoxColumn hamluong;
        private DataGridViewTextBoxColumn cachdung;
        private DataGridViewTextBoxColumn solandung;
        private DataGridViewTextBoxColumn duongdung;
        private DataGridViewTextBoxColumn ngaybd;
        private DataGridViewTextBoxColumn ngaykt;
        private DataGridViewTextBoxColumn losx;
        private DataGridViewTextBoxColumn tennsx;
        private Button butThuocdasd;
        private TextBox txtbenhsu;
        private Button button3;
        private TextBox textBox9;
        private TextBox textBox10;
        private CheckBox checkBox1;
        private Label label16;
        private Button button4;
        private Button button5;
        private CheckBox checkBox2;
        private CheckBox checkBox3;
        private DataGridView dataGridView2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private Label label21;
        private Label label22;
        private Label label23;
        private TextBox textBox11;
        private Label label27;
        private Label label28;
        private TextBox textBox12;
        private CheckBox checkBox12;
        private CheckBox checkBox13;
        private Label label9;
        private CheckBox checkBox14;
        private CheckBox checkBox15;
        private CheckBox checkBox16;
        private CheckBox checkBox17;
        private CheckBox checkBox18;
        private CheckBox checkBox19;
        private TextBox textBox13;
        private TextBox textBox14;
        private Label label29;
        private Label label30;
        private Label label31;
        private Label label33;
        private TextBox txtbinhluanbacsi;
        private Label label32;
        private Label label41;
        private Label label40;
        private Label label39;
        private Label label38;
        private Label label34;
        private CheckBox chkkhongchacchan_yte;
        private CheckBox chkcothe_yte;
        private CheckBox chkcokhanang_yte;
        private CheckBox chkchacchan_yte;
        private Label label42;
        private Label label43;
        private Label label44;
        private Label label45;
        private TextBox txtchucvu;
        private Label label49;
        private System.Windows.Forms.MaskedTextBox txtngaybc;
        private TextBox txtEmail;
        private Label label46;
        private Label label47;
        private TextBox txtsodienthoai;
        private TextBox txtten;
        private CheckBox chkbosung;
        private CheckBox chklandau;
        private TextBox txtkyten;
        private Label label50;
        private Label label51;
        private DataGrid dataGrid1;
        private Button butin;
        private Button butketthuc;
        private Button butboqua;
        private Button butxoa;
        private Button butsua;
        private Button butluu;
        private Button butmoi;
        protected TextBox cd_chinh;
        protected MaskedTextBox.MaskedTextBox icd_chinh;
        private Button butThem;
        private Label lbldvt;
        private MaskedTextBox.MaskedTextBox moilan;
        private Label label52;
        private MaskedTextBox.MaskedTextBox soluong;
        private NumericUpDown solan;
        private Label label53;
        private TextBox tenhc;
        private TextBox textBox1;
        private Label label54;
        private Label label55;
        private Label ltenhc;
        private bool bDanhmuc;
        public DataTable dtthuoc = new DataTable();
        private System.Windows.Forms.MaskedTextBox ngaypu;
        private string ngaybatdau = "", ngayketthuc = "";
        #endregion
        private Button butdelete;
        private ComboBox ngay;
        private Label label57;
        private TextBox lydodungthuoc;
        private CheckBox ThangNaranjo;
        private CheckBox ThangWho;
        private CheckBox Thangkhac;
        private CheckBox chkkhongthephanloai;
        private CheckBox chkchuaphanloai;
        private Label lab;
        private Label label35;
        private Button buttsddt;
        private Label label26;
        private TextBox txtmotapu;
        private NumericUpDown timexuathienpu;
        private CheckBox chkkhongxacdinh;
        private CheckBox chkchetkhonglienquanthuoc;
        private CheckBox chkchetdoADR;
        private CheckBox chkkhongphuchoi;
        private CheckBox chkphuchoicodichung;
        private CheckBox chkhoiphuckhongdichung;
        private Label label8;
        private ComboBox cbdonvitimexuathienpu;
        private CheckBox chkditat_md;
        private CheckBox chkkhongngtrong_md;
        private CheckBox chktuvong_md;
        private CheckBox chktantat_md;
        private CheckBox chkdedoa_md;
        private CheckBox chknhapnamvien_md;
        private Label label15;
        private Label label17;
        private Label label19;
        private ComboBox cbcaithien;
        private Label label36;
        protected TextBox thuocsddongthoi;
        private DataGrid dataGrid2;
        private Button btthem;
        private Button btdelete;
        private Label label58;
        private CheckBox chksdthuockhac_khongbiet;
        private CheckBox chksdthuockhac_dieutritiep;
        private CheckBox chksdthuockhac_khongtientrien;
        private CheckBox chksdthuockhac_tientrientot;
        private CheckBox chkngungthuoc_khongbiet;
        private CheckBox chkngungthuoc_dieutritiep;
        private CheckBox chkngungthuoc_khongtientrien;
        private CheckBox chkngungthuoc_tientrientot;
        private TextBox txtsdthuockhac;
        private TextBox txtngungdungthuoc;
        private Label label74;
        private Label label73;
        private Label label72;
        private Button btxetnghiem;
        private RichTextBox txtxetnghiem;
        private CheckBox chkdangphuchoi;
        private ComboBox cbtaiphanung;
        private CheckBox chkkhac_thamdinh;
        private Label label56;

        public frmPhanungthuoccohai(LibMedi.AccessData acc, string _makp, string _cd_kemtheo, string _mabn, int userid,
            string _cd_chinh, string suserid, decimal _mavaovien, decimal _maql, string _ngay, int _loai, int _maba,
            int _mabv, int _loaiba)
        {
            InitializeComponent();
            m = acc; s_makp = _makp; s_cd_kemtheo = _cd_kemtheo; s_mabn = _mabn; i_userid = userid;
            s_cd_chinh = _cd_chinh; i_mabv = _mabv;
            s_userid = suserid; l_mavaovien = _mavaovien; l_maql = _maql; i_loai = _loai; i_maba = _maba;
            s_ngay = _ngay; mabn.Text = s_mabn; i_loaiba = _loaiba;
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
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPhanungthuoccohai));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label7 = new System.Windows.Forms.Label();
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tab2 = new System.Windows.Forms.TabPage();
            this.label58 = new System.Windows.Forms.Label();
            this.cd_chinh = new System.Windows.Forms.TextBox();
            this.btdelete = new System.Windows.Forms.Button();
            this.btthem = new System.Windows.Forms.Button();
            this.label36 = new System.Windows.Forms.Label();
            this.thuocsddongthoi = new System.Windows.Forms.TextBox();
            this.dataGrid2 = new System.Windows.Forms.DataGrid();
            this.cbcaithien = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.cbdonvitimexuathienpu = new System.Windows.Forms.ComboBox();
            this.timexuathienpu = new System.Windows.Forms.NumericUpDown();
            this.label57 = new System.Windows.Forms.Label();
            this.lydodungthuoc = new System.Windows.Forms.TextBox();
            this.butdelete = new System.Windows.Forms.Button();
            this.label56 = new System.Windows.Forms.Label();
            this.lbldvt = new System.Windows.Forms.Label();
            this.moilan = new MaskedTextBox.MaskedTextBox();
            this.label52 = new System.Windows.Forms.Label();
            this.soluong = new MaskedTextBox.MaskedTextBox();
            this.solan = new System.Windows.Forms.NumericUpDown();
            this.label53 = new System.Windows.Forms.Label();
            this.tenhc = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label54 = new System.Windows.Forms.Label();
            this.label55 = new System.Windows.Forms.Label();
            this.ltenhc = new System.Windows.Forms.Label();
            this.butThem = new System.Windows.Forms.Button();
            this.txtbenhsu = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.icd_chinh = new MaskedTextBox.MaskedTextBox();
            this.dgvThuoc = new System.Windows.Forms.DataGridView();
            this.ten = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hamluong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cachdung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.solandung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.duongdung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngaybd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngaykt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.losx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tennsx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dantoc = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.butThuocdasd = new System.Windows.Forms.Button();
            this.tab4 = new System.Windows.Forms.TabPage();
            this.chkdangphuchoi = new System.Windows.Forms.CheckBox();
            this.txtxetnghiem = new System.Windows.Forms.RichTextBox();
            this.btxetnghiem = new System.Windows.Forms.Button();
            this.chksdthuockhac_khongbiet = new System.Windows.Forms.CheckBox();
            this.chksdthuockhac_dieutritiep = new System.Windows.Forms.CheckBox();
            this.chksdthuockhac_khongtientrien = new System.Windows.Forms.CheckBox();
            this.chksdthuockhac_tientrientot = new System.Windows.Forms.CheckBox();
            this.chkngungthuoc_khongbiet = new System.Windows.Forms.CheckBox();
            this.chkngungthuoc_dieutritiep = new System.Windows.Forms.CheckBox();
            this.chkngungthuoc_khongtientrien = new System.Windows.Forms.CheckBox();
            this.chkngungthuoc_tientrientot = new System.Windows.Forms.CheckBox();
            this.txtsdthuockhac = new System.Windows.Forms.TextBox();
            this.txtngungdungthuoc = new System.Windows.Forms.TextBox();
            this.label74 = new System.Windows.Forms.Label();
            this.label73 = new System.Windows.Forms.Label();
            this.label72 = new System.Windows.Forms.Label();
            this.chkditat_md = new System.Windows.Forms.CheckBox();
            this.chkkhongngtrong_md = new System.Windows.Forms.CheckBox();
            this.chktuvong_md = new System.Windows.Forms.CheckBox();
            this.chktantat_md = new System.Windows.Forms.CheckBox();
            this.chkdedoa_md = new System.Windows.Forms.CheckBox();
            this.chknhapnamvien_md = new System.Windows.Forms.CheckBox();
            this.label15 = new System.Windows.Forms.Label();
            this.chkkhongthephanloai = new System.Windows.Forms.CheckBox();
            this.chkchuaphanloai = new System.Windows.Forms.CheckBox();
            this.lab = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.Thangkhac = new System.Windows.Forms.CheckBox();
            this.ThangNaranjo = new System.Windows.Forms.CheckBox();
            this.ThangWho = new System.Windows.Forms.CheckBox();
            this.chkbosung = new System.Windows.Forms.CheckBox();
            this.chklandau = new System.Windows.Forms.CheckBox();
            this.txtkyten = new System.Windows.Forms.TextBox();
            this.label50 = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.txtchucvu = new System.Windows.Forms.TextBox();
            this.label49 = new System.Windows.Forms.Label();
            this.txtngaybc = new System.Windows.Forms.MaskedTextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label46 = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.txtsodienthoai = new System.Windows.Forms.TextBox();
            this.txtten = new System.Windows.Forms.TextBox();
            this.label44 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.chkkhongchacchan_yte = new System.Windows.Forms.CheckBox();
            this.chkcothe_yte = new System.Windows.Forms.CheckBox();
            this.chkcokhanang_yte = new System.Windows.Forms.CheckBox();
            this.chkchacchan_yte = new System.Windows.Forms.CheckBox();
            this.label41 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.txtbinhluanbacsi = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.chkkhongxacdinh = new System.Windows.Forms.CheckBox();
            this.chkchetkhonglienquanthuoc = new System.Windows.Forms.CheckBox();
            this.chkchetdoADR = new System.Windows.Forms.CheckBox();
            this.chkkhongphuchoi = new System.Windows.Forms.CheckBox();
            this.chkphuchoicodichung = new System.Windows.Forms.CheckBox();
            this.chkhoiphuckhongdichung = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.butin = new System.Windows.Forms.Button();
            this.butketthuc = new System.Windows.Forms.Button();
            this.butboqua = new System.Windows.Forms.Button();
            this.butxoa = new System.Windows.Forms.Button();
            this.butsua = new System.Windows.Forms.Button();
            this.butluu = new System.Windows.Forms.Button();
            this.butmoi = new System.Windows.Forms.Button();
            this.chkXML = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ngay = new System.Windows.Forms.ComboBox();
            this.ngaypu = new System.Windows.Forms.MaskedTextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.txtmotapu = new System.Windows.Forms.TextBox();
            this.msbcdonvi = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.msbctt = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cannang = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chieucao = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label16 = new System.Windows.Forms.Label();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.checkBox12 = new System.Windows.Forms.CheckBox();
            this.checkBox13 = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.checkBox14 = new System.Windows.Forms.CheckBox();
            this.checkBox15 = new System.Windows.Forms.CheckBox();
            this.checkBox16 = new System.Windows.Forms.CheckBox();
            this.checkBox17 = new System.Windows.Forms.CheckBox();
            this.checkBox18 = new System.Windows.Forms.CheckBox();
            this.checkBox19 = new System.Windows.Forms.CheckBox();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.listICD = new LibList.List();
            this.buttsddt = new System.Windows.Forms.Button();
            this.cbtaiphanung = new System.Windows.Forms.ComboBox();
            this.chkkhac_thamdinh = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.tab2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timexuathienpu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.solan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThuoc)).BeginInit();
            this.tab4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(0, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 16);
            this.label7.TabIndex = 40;
            this.label7.Text = "Ngày vào viện :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // diachi
            // 
            this.diachi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.diachi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.diachi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diachi.Location = new System.Drawing.Point(829, 15);
            this.diachi.Name = "diachi";
            this.diachi.Size = new System.Drawing.Size(180, 21);
            this.diachi.TabIndex = 12;
            this.diachi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.diachi_KeyDown);
            // 
            // phai
            // 
            this.phai.BackColor = System.Drawing.SystemColors.HighlightText;
            this.phai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phai.Location = new System.Drawing.Point(470, 15);
            this.phai.Name = "phai";
            this.phai.Size = new System.Drawing.Size(32, 21);
            this.phai.TabIndex = 4;
            // 
            // namsinh
            // 
            this.namsinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.namsinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namsinh.Location = new System.Drawing.Point(386, 15);
            this.namsinh.Name = "namsinh";
            this.namsinh.Size = new System.Drawing.Size(32, 21);
            this.namsinh.TabIndex = 3;
            // 
            // hoten
            // 
            this.hoten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.hoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoten.Location = new System.Drawing.Point(199, 15);
            this.hoten.Name = "hoten";
            this.hoten.Size = new System.Drawing.Size(160, 21);
            this.hoten.TabIndex = 2;
            // 
            // mabn
            // 
            this.mabn.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabn.Location = new System.Drawing.Point(83, 15);
            this.mabn.MaxLength = 10;
            this.mabn.Name = "mabn";
            this.mabn.Size = new System.Drawing.Size(70, 21);
            this.mabn.TabIndex = 0;
            this.mabn.Validated += new System.EventHandler(this.mabn_Validated);
            this.mabn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabn_KeyDown);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(783, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 16);
            this.label5.TabIndex = 32;
            this.label5.Text = "Địa chỉ :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(418, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 16);
            this.label4.TabIndex = 31;
            this.label4.Text = "Giới tính :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(359, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 16);
            this.label3.TabIndex = 30;
            this.label3.Text = "NS :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(153, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Họ tên :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(37, 17);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 16);
            this.label10.TabIndex = 28;
            this.label10.Text = "Mã BN :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tab2);
            this.tabControl1.Controls.Add(this.tab4);
            this.tabControl1.Location = new System.Drawing.Point(3, 101);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1013, 577);
            this.tabControl1.TabIndex = 3;
            // 
            // tab2
            // 
            this.tab2.Controls.Add(this.cbtaiphanung);
            this.tab2.Controls.Add(this.label58);
            this.tab2.Controls.Add(this.cd_chinh);
            this.tab2.Controls.Add(this.btdelete);
            this.tab2.Controls.Add(this.btthem);
            this.tab2.Controls.Add(this.label36);
            this.tab2.Controls.Add(this.thuocsddongthoi);
            this.tab2.Controls.Add(this.dataGrid2);
            this.tab2.Controls.Add(this.cbcaithien);
            this.tab2.Controls.Add(this.label19);
            this.tab2.Controls.Add(this.label17);
            this.tab2.Controls.Add(this.cbdonvitimexuathienpu);
            this.tab2.Controls.Add(this.timexuathienpu);
            this.tab2.Controls.Add(this.label57);
            this.tab2.Controls.Add(this.lydodungthuoc);
            this.tab2.Controls.Add(this.butdelete);
            this.tab2.Controls.Add(this.label56);
            this.tab2.Controls.Add(this.lbldvt);
            this.tab2.Controls.Add(this.moilan);
            this.tab2.Controls.Add(this.label52);
            this.tab2.Controls.Add(this.soluong);
            this.tab2.Controls.Add(this.solan);
            this.tab2.Controls.Add(this.label53);
            this.tab2.Controls.Add(this.tenhc);
            this.tab2.Controls.Add(this.textBox1);
            this.tab2.Controls.Add(this.label54);
            this.tab2.Controls.Add(this.label55);
            this.tab2.Controls.Add(this.ltenhc);
            this.tab2.Controls.Add(this.butThem);
            this.tab2.Controls.Add(this.txtbenhsu);
            this.tab2.Controls.Add(this.label20);
            this.tab2.Controls.Add(this.label37);
            this.tab2.Controls.Add(this.label14);
            this.tab2.Controls.Add(this.dataGrid1);
            this.tab2.Controls.Add(this.icd_chinh);
            this.tab2.Controls.Add(this.dgvThuoc);
            this.tab2.Controls.Add(this.dantoc);
            this.tab2.Controls.Add(this.label6);
            this.tab2.Controls.Add(this.butThuocdasd);
            this.tab2.Location = new System.Drawing.Point(4, 22);
            this.tab2.Name = "tab2";
            this.tab2.Size = new System.Drawing.Size(1005, 551);
            this.tab2.TabIndex = 1;
            this.tab2.Text = "Trang 1";
            // 
            // label58
            // 
            this.label58.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label58.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label58.Location = new System.Drawing.Point(8, 291);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(527, 17);
            this.label58.TabIndex = 348;
            this.label58.Text = "II. Các thuốc dùng đồng thời (Ngoại trừ các thuốc dùng điều trị/khắc phục hậu quả" +
                " của ADR)";
            this.label58.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cd_chinh
            // 
            this.cd_chinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cd_chinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cd_chinh.Location = new System.Drawing.Point(161, 162);
            this.cd_chinh.Name = "cd_chinh";
            this.cd_chinh.Size = new System.Drawing.Size(312, 21);
            this.cd_chinh.TabIndex = 14;
            this.cd_chinh.TextChanged += new System.EventHandler(this.cd_chinh_TextChanged);
            this.cd_chinh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cd_chinh_KeyDown);
            // 
            // btdelete
            // 
            this.btdelete.Image = ((System.Drawing.Image)(resources.GetObject("btdelete.Image")));
            this.btdelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btdelete.Location = new System.Drawing.Point(637, 462);
            this.btdelete.Name = "btdelete";
            this.btdelete.Size = new System.Drawing.Size(60, 23);
            this.btdelete.TabIndex = 23;
            this.btdelete.Text = "&Xóa";
            this.btdelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btdelete.UseVisualStyleBackColor = true;
            this.btdelete.Click += new System.EventHandler(this.btdelete_Click);
            // 
            // btthem
            // 
            this.btthem.Image = ((System.Drawing.Image)(resources.GetObject("btthem.Image")));
            this.btthem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btthem.Location = new System.Drawing.Point(571, 462);
            this.btthem.Name = "btthem";
            this.btthem.Size = new System.Drawing.Size(60, 23);
            this.btthem.TabIndex = 22;
            this.btthem.Text = "Thêm";
            this.btthem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btthem.UseVisualStyleBackColor = true;
            this.btthem.Click += new System.EventHandler(this.btthem_Click);
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(25, 467);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(133, 13);
            this.label36.TabIndex = 347;
            this.label36.Text = "Thuốc sử dụng đồng thời :";
            // 
            // thuocsddongthoi
            // 
            this.thuocsddongthoi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.thuocsddongthoi.Location = new System.Drawing.Point(167, 464);
            this.thuocsddongthoi.Name = "thuocsddongthoi";
            this.thuocsddongthoi.Size = new System.Drawing.Size(398, 20);
            this.thuocsddongthoi.TabIndex = 21;
            this.thuocsddongthoi.TextChanged += new System.EventHandler(this.thuocsddongthoi_TextChanged);
            this.thuocsddongthoi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.thuocsddongthoi_KeyDown);
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
            this.dataGrid2.HeaderForeColor = System.Drawing.SystemColors.Desktop;
            this.dataGrid2.LinkColor = System.Drawing.Color.Teal;
            this.dataGrid2.Location = new System.Drawing.Point(11, 311);
            this.dataGrid2.Name = "dataGrid2";
            this.dataGrid2.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid2.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid2.ReadOnly = true;
            this.dataGrid2.RowHeaderWidth = 5;
            this.dataGrid2.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid2.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid2.Size = new System.Drawing.Size(490, 147);
            this.dataGrid2.TabIndex = 345;
            // 
            // cbcaithien
            // 
            this.cbcaithien.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cbcaithien.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cbcaithien.FormattingEnabled = true;
            this.cbcaithien.Items.AddRange(new object[] {
            "Không",
            "Có",
            "Không ngừng/giảm liều",
            "Không có thông tin"});
            this.cbcaithien.Location = new System.Drawing.Point(492, 228);
            this.cbcaithien.Name = "cbcaithien";
            this.cbcaithien.Size = new System.Drawing.Size(138, 21);
            this.cbcaithien.TabIndex = 18;
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label19.Location = new System.Drawing.Point(8, 256);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(475, 17);
            this.label19.TabIndex = 26;
            this.label19.Text = "Tái sử dụng thuốc nghi ngờ có xuất hiện lại phản ứng không?";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label17.Location = new System.Drawing.Point(8, 233);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(475, 17);
            this.label17.TabIndex = 344;
            this.label17.Text = "Sau khi ngừng/giảm liều của thuốc bị nghi ngờ, phản ứng có được cải thiện không?";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbdonvitimexuathienpu
            // 
            this.cbdonvitimexuathienpu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cbdonvitimexuathienpu.FormattingEnabled = true;
            this.cbdonvitimexuathienpu.Items.AddRange(new object[] {
            "Ngày",
            "Tuần",
            "Tháng"});
            this.cbdonvitimexuathienpu.Location = new System.Drawing.Point(507, 485);
            this.cbdonvitimexuathienpu.Name = "cbdonvitimexuathienpu";
            this.cbdonvitimexuathienpu.Size = new System.Drawing.Size(58, 21);
            this.cbdonvitimexuathienpu.TabIndex = 330;
            // 
            // timexuathienpu
            // 
            this.timexuathienpu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.timexuathienpu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timexuathienpu.Location = new System.Drawing.Point(464, 485);
            this.timexuathienpu.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.timexuathienpu.Name = "timexuathienpu";
            this.timexuathienpu.Size = new System.Drawing.Size(37, 21);
            this.timexuathienpu.TabIndex = 329;
            this.timexuathienpu.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Location = new System.Drawing.Point(58, 211);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(99, 13);
            this.label57.TabIndex = 328;
            this.label57.Text = "Lý do dùng thuốc : ";
            // 
            // lydodungthuoc
            // 
            this.lydodungthuoc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.lydodungthuoc.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lydodungthuoc.Location = new System.Drawing.Point(160, 206);
            this.lydodungthuoc.Name = "lydodungthuoc";
            this.lydodungthuoc.Size = new System.Drawing.Size(779, 20);
            this.lydodungthuoc.TabIndex = 17;
            // 
            // butdelete
            // 
            this.butdelete.Image = ((System.Drawing.Image)(resources.GetObject("butdelete.Image")));
            this.butdelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butdelete.Location = new System.Drawing.Point(661, 250);
            this.butdelete.Name = "butdelete";
            this.butdelete.Size = new System.Drawing.Size(60, 23);
            this.butdelete.TabIndex = 326;
            this.butdelete.Text = "&Xóa";
            this.butdelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butdelete.UseVisualStyleBackColor = true;
            this.butdelete.Click += new System.EventHandler(this.butdelete_Click);
            // 
            // label56
            // 
            this.label56.Location = new System.Drawing.Point(107, 164);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(50, 21);
            this.label56.TabIndex = 325;
            this.label56.Text = "Tên :";
            this.label56.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbldvt
            // 
            this.lbldvt.Location = new System.Drawing.Point(303, 183);
            this.lbldvt.Name = "lbldvt";
            this.lbldvt.Size = new System.Drawing.Size(68, 23);
            this.lbldvt.TabIndex = 324;
            this.lbldvt.Text = "viên";
            this.lbldvt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // moilan
            // 
            this.moilan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.moilan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moilan.Location = new System.Drawing.Point(258, 184);
            this.moilan.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
            this.moilan.Name = "moilan";
            this.moilan.Size = new System.Drawing.Size(43, 21);
            this.moilan.TabIndex = 16;
            this.moilan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.moilan.Validated += new System.EventHandler(this.moilan_Validated);
            // 
            // label52
            // 
            this.label52.Location = new System.Drawing.Point(206, 184);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(55, 21);
            this.label52.TabIndex = 323;
            this.label52.Text = "lần , lần :";
            this.label52.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // soluong
            // 
            this.soluong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.soluong.Enabled = false;
            this.soluong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.soluong.Location = new System.Drawing.Point(423, 184);
            this.soluong.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.soluong.Name = "soluong";
            this.soluong.Size = new System.Drawing.Size(50, 21);
            this.soluong.TabIndex = 317;
            this.soluong.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // solan
            // 
            this.solan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.solan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.solan.Location = new System.Drawing.Point(160, 184);
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
            this.solan.Size = new System.Drawing.Size(37, 21);
            this.solan.TabIndex = 15;
            this.solan.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.solan.Validated += new System.EventHandler(this.solan_Validated);
            this.solan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.solan_KeyDown);
            // 
            // label53
            // 
            this.label53.Location = new System.Drawing.Point(117, 186);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(40, 21);
            this.label53.TabIndex = 321;
            this.label53.Text = "Ngày :";
            this.label53.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tenhc
            // 
            this.tenhc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenhc.Enabled = false;
            this.tenhc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenhc.Location = new System.Drawing.Point(551, 162);
            this.tenhc.Name = "tenhc";
            this.tenhc.Size = new System.Drawing.Size(387, 21);
            this.tenhc.TabIndex = 314;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(551, 184);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(387, 21);
            this.textBox1.TabIndex = 318;
            // 
            // label54
            // 
            this.label54.Location = new System.Drawing.Point(472, 184);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(80, 19);
            this.label54.TabIndex = 322;
            this.label54.Text = "Cách dùng :";
            this.label54.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label55
            // 
            this.label55.Location = new System.Drawing.Point(367, 183);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(56, 20);
            this.label55.TabIndex = 320;
            this.label55.Text = "Số lượng :";
            this.label55.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ltenhc
            // 
            this.ltenhc.Location = new System.Drawing.Point(479, 160);
            this.ltenhc.Name = "ltenhc";
            this.ltenhc.Size = new System.Drawing.Size(72, 23);
            this.ltenhc.TabIndex = 319;
            this.ltenhc.Text = "Hoạt chất :";
            this.ltenhc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butThem
            // 
            this.butThem.Image = ((System.Drawing.Image)(resources.GetObject("butThem.Image")));
            this.butThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butThem.Location = new System.Drawing.Point(661, 227);
            this.butThem.Name = "butThem";
            this.butThem.Size = new System.Drawing.Size(60, 23);
            this.butThem.TabIndex = 20;
            this.butThem.Text = "Thêm";
            this.butThem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butThem.UseVisualStyleBackColor = true;
            this.butThem.Click += new System.EventHandler(this.butThem_Click);
            // 
            // txtbenhsu
            // 
            this.txtbenhsu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtbenhsu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtbenhsu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbenhsu.Location = new System.Drawing.Point(63, 507);
            this.txtbenhsu.Multiline = true;
            this.txtbenhsu.Name = "txtbenhsu";
            this.txtbenhsu.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtbenhsu.Size = new System.Drawing.Size(842, 23);
            this.txtbenhsu.TabIndex = 5;
            this.txtbenhsu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbenhsu_KeyDown);
            // 
            // label20
            // 
            this.label20.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(11, 505);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(57, 27);
            this.label20.TabIndex = 277;
            this.label20.Text = "Tiền sử:";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label37
            // 
            this.label37.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label37.Location = new System.Drawing.Point(11, 483);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(458, 23);
            this.label37.TabIndex = 97;
            this.label37.Text = "Phản ứng xuất hiện sau bao lâu (tính từ lần dùng cuối cùng của thuốc nghi ngờ):";
            this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label14.Location = new System.Drawing.Point(8, 8);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(240, 17);
            this.label14.TabIndex = 61;
            this.label14.Text = "I. Thông tin về thuốc nghi ngờ gây ADN :";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.Desktop;
            this.dataGrid1.LinkColor = System.Drawing.Color.Teal;
            this.dataGrid1.Location = new System.Drawing.Point(5, 12);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 5;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(997, 143);
            this.dataGrid1.TabIndex = 312;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            // 
            // icd_chinh
            // 
            this.icd_chinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.icd_chinh.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.icd_chinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.icd_chinh.Location = new System.Drawing.Point(60, 58);
            this.icd_chinh.Masked = MaskedTextBox.MaskedTextBox.Mask.ICD10;
            this.icd_chinh.MaxLength = 9;
            this.icd_chinh.Name = "icd_chinh";
            this.icd_chinh.Size = new System.Drawing.Size(47, 21);
            this.icd_chinh.TabIndex = 0;
            this.icd_chinh.Visible = false;
            this.icd_chinh.Validated += new System.EventHandler(this.icd_chinh_Validated);
            this.icd_chinh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.icd_chinh_KeyDown);
            // 
            // dgvThuoc
            // 
            this.dgvThuoc.AllowUserToAddRows = false;
            this.dgvThuoc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvThuoc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvThuoc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvThuoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThuoc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ten,
            this.hamluong,
            this.cachdung,
            this.solandung,
            this.duongdung,
            this.ngaybd,
            this.ngaykt,
            this.losx,
            this.tennsx});
            this.dgvThuoc.Location = new System.Drawing.Point(11, 58);
            this.dgvThuoc.Name = "dgvThuoc";
            this.dgvThuoc.Size = new System.Drawing.Size(10, 44);
            this.dgvThuoc.TabIndex = 302;
            this.dgvThuoc.Visible = false;
            // 
            // ten
            // 
            this.ten.HeaderText = "Tên các thuốc nghi ngờ";
            this.ten.Name = "ten";
            // 
            // hamluong
            // 
            this.hamluong.HeaderText = "Hàm lượng hoặc nồng độ";
            this.hamluong.Name = "hamluong";
            // 
            // cachdung
            // 
            this.cachdung.HeaderText = "Liều dùng một lần";
            this.cachdung.Name = "cachdung";
            // 
            // solandung
            // 
            this.solandung.HeaderText = "Số lần dùng(ngày,tuần,tháng)";
            this.solandung.Name = "solandung";
            // 
            // duongdung
            // 
            this.duongdung.HeaderText = "Đường dùng";
            this.duongdung.Name = "duongdung";
            // 
            // ngaybd
            // 
            this.ngaybd.HeaderText = "Ngày bắt đầu điều trị";
            this.ngaybd.Name = "ngaybd";
            // 
            // ngaykt
            // 
            this.ngaykt.HeaderText = "Ngày kết thúc điều trị";
            this.ngaykt.Name = "ngaykt";
            // 
            // losx
            // 
            this.losx.HeaderText = "Lô sản xuất-Hạn dùng";
            this.losx.Name = "losx";
            // 
            // tennsx
            // 
            this.tennsx.HeaderText = "Tên nhà sản xuất";
            this.tennsx.Name = "tennsx";
            // 
            // dantoc
            // 
            this.dantoc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dantoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dantoc.Location = new System.Drawing.Point(562, 17);
            this.dantoc.Name = "dantoc";
            this.dantoc.Size = new System.Drawing.Size(57, 21);
            this.dantoc.TabIndex = 5;
            this.dantoc.Visible = false;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(514, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 16);
            this.label6.TabIndex = 38;
            this.label6.Text = "Dân tộc :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label6.Visible = false;
            // 
            // butThuocdasd
            // 
            this.butThuocdasd.Image = ((System.Drawing.Image)(resources.GetObject("butThuocdasd.Image")));
            this.butThuocdasd.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.butThuocdasd.Location = new System.Drawing.Point(38, 105);
            this.butThuocdasd.Name = "butThuocdasd";
            this.butThuocdasd.Size = new System.Drawing.Size(83, 37);
            this.butThuocdasd.TabIndex = 305;
            this.butThuocdasd.Text = "Xem các thuốc sử dụng";
            this.butThuocdasd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butThuocdasd.UseVisualStyleBackColor = true;
            this.butThuocdasd.Visible = false;
            this.butThuocdasd.Click += new System.EventHandler(this.butThuocdasd_Click);
            // 
            // tab4
            // 
            this.tab4.Controls.Add(this.chkkhac_thamdinh);
            this.tab4.Controls.Add(this.chkdangphuchoi);
            this.tab4.Controls.Add(this.txtxetnghiem);
            this.tab4.Controls.Add(this.btxetnghiem);
            this.tab4.Controls.Add(this.chksdthuockhac_khongbiet);
            this.tab4.Controls.Add(this.chksdthuockhac_dieutritiep);
            this.tab4.Controls.Add(this.chksdthuockhac_khongtientrien);
            this.tab4.Controls.Add(this.chksdthuockhac_tientrientot);
            this.tab4.Controls.Add(this.chkngungthuoc_khongbiet);
            this.tab4.Controls.Add(this.chkngungthuoc_dieutritiep);
            this.tab4.Controls.Add(this.chkngungthuoc_khongtientrien);
            this.tab4.Controls.Add(this.chkngungthuoc_tientrientot);
            this.tab4.Controls.Add(this.txtsdthuockhac);
            this.tab4.Controls.Add(this.txtngungdungthuoc);
            this.tab4.Controls.Add(this.label74);
            this.tab4.Controls.Add(this.label73);
            this.tab4.Controls.Add(this.label72);
            this.tab4.Controls.Add(this.chkditat_md);
            this.tab4.Controls.Add(this.chkkhongngtrong_md);
            this.tab4.Controls.Add(this.chktuvong_md);
            this.tab4.Controls.Add(this.chktantat_md);
            this.tab4.Controls.Add(this.chkdedoa_md);
            this.tab4.Controls.Add(this.chknhapnamvien_md);
            this.tab4.Controls.Add(this.label15);
            this.tab4.Controls.Add(this.chkkhongthephanloai);
            this.tab4.Controls.Add(this.chkchuaphanloai);
            this.tab4.Controls.Add(this.lab);
            this.tab4.Controls.Add(this.label35);
            this.tab4.Controls.Add(this.Thangkhac);
            this.tab4.Controls.Add(this.ThangNaranjo);
            this.tab4.Controls.Add(this.ThangWho);
            this.tab4.Controls.Add(this.chkbosung);
            this.tab4.Controls.Add(this.chklandau);
            this.tab4.Controls.Add(this.txtkyten);
            this.tab4.Controls.Add(this.label50);
            this.tab4.Controls.Add(this.label51);
            this.tab4.Controls.Add(this.txtchucvu);
            this.tab4.Controls.Add(this.label49);
            this.tab4.Controls.Add(this.txtngaybc);
            this.tab4.Controls.Add(this.txtEmail);
            this.tab4.Controls.Add(this.label46);
            this.tab4.Controls.Add(this.label47);
            this.tab4.Controls.Add(this.txtsodienthoai);
            this.tab4.Controls.Add(this.txtten);
            this.tab4.Controls.Add(this.label44);
            this.tab4.Controls.Add(this.label45);
            this.tab4.Controls.Add(this.label43);
            this.tab4.Controls.Add(this.label42);
            this.tab4.Controls.Add(this.chkkhongchacchan_yte);
            this.tab4.Controls.Add(this.chkcothe_yte);
            this.tab4.Controls.Add(this.chkcokhanang_yte);
            this.tab4.Controls.Add(this.chkchacchan_yte);
            this.tab4.Controls.Add(this.label41);
            this.tab4.Controls.Add(this.label40);
            this.tab4.Controls.Add(this.label39);
            this.tab4.Controls.Add(this.label38);
            this.tab4.Controls.Add(this.label34);
            this.tab4.Controls.Add(this.label33);
            this.tab4.Controls.Add(this.txtbinhluanbacsi);
            this.tab4.Controls.Add(this.label32);
            this.tab4.Controls.Add(this.chkkhongxacdinh);
            this.tab4.Controls.Add(this.chkchetkhonglienquanthuoc);
            this.tab4.Controls.Add(this.chkchetdoADR);
            this.tab4.Controls.Add(this.chkkhongphuchoi);
            this.tab4.Controls.Add(this.chkphuchoicodichung);
            this.tab4.Controls.Add(this.chkhoiphuckhongdichung);
            this.tab4.Controls.Add(this.label8);
            this.tab4.Location = new System.Drawing.Point(4, 22);
            this.tab4.Name = "tab4";
            this.tab4.Size = new System.Drawing.Size(1005, 551);
            this.tab4.TabIndex = 3;
            this.tab4.Text = "Trang 2";
            // 
            // chkdangphuchoi
            // 
            this.chkdangphuchoi.Location = new System.Drawing.Point(294, 232);
            this.chkdangphuchoi.Name = "chkdangphuchoi";
            this.chkdangphuchoi.Size = new System.Drawing.Size(137, 27);
            this.chkdangphuchoi.TabIndex = 387;
            this.chkdangphuchoi.Text = "Đang phục hồi";
            this.chkdangphuchoi.CheckedChanged += new System.EventHandler(this.chkdangphuchoi_CheckedChanged);
            // 
            // txtxetnghiem
            // 
            this.txtxetnghiem.Location = new System.Drawing.Point(168, 3);
            this.txtxetnghiem.Name = "txtxetnghiem";
            this.txtxetnghiem.ReadOnly = true;
            this.txtxetnghiem.Size = new System.Drawing.Size(482, 82);
            this.txtxetnghiem.TabIndex = 386;
            this.txtxetnghiem.Text = "";
            // 
            // btxetnghiem
            // 
            this.btxetnghiem.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btxetnghiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btxetnghiem.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.btxetnghiem.Location = new System.Drawing.Point(6, 32);
            this.btxetnghiem.Name = "btxetnghiem";
            this.btxetnghiem.Size = new System.Drawing.Size(161, 23);
            this.btxetnghiem.TabIndex = 385;
            this.btxetnghiem.Text = "Các Xét nghiệm liên quan";
            this.btxetnghiem.UseVisualStyleBackColor = false;
            this.btxetnghiem.Click += new System.EventHandler(this.btxetnghiem_Click);
            // 
            // chksdthuockhac_khongbiet
            // 
            this.chksdthuockhac_khongbiet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chksdthuockhac_khongbiet.Location = new System.Drawing.Point(925, 117);
            this.chksdthuockhac_khongbiet.Name = "chksdthuockhac_khongbiet";
            this.chksdthuockhac_khongbiet.Size = new System.Drawing.Size(77, 18);
            this.chksdthuockhac_khongbiet.TabIndex = 384;
            this.chksdthuockhac_khongbiet.Text = "Không biết";
            this.chksdthuockhac_khongbiet.CheckedChanged += new System.EventHandler(this.chksdthuockhac_khongbiet_CheckedChanged_1);
            // 
            // chksdthuockhac_dieutritiep
            // 
            this.chksdthuockhac_dieutritiep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chksdthuockhac_dieutritiep.Location = new System.Drawing.Point(832, 118);
            this.chksdthuockhac_dieutritiep.Name = "chksdthuockhac_dieutritiep";
            this.chksdthuockhac_dieutritiep.Size = new System.Drawing.Size(99, 18);
            this.chksdthuockhac_dieutritiep.TabIndex = 383;
            this.chksdthuockhac_dieutritiep.Text = "Điều trị tiếp tục";
            this.chksdthuockhac_dieutritiep.CheckedChanged += new System.EventHandler(this.chksdthuockhac_dieutritiep_CheckedChanged_1);
            // 
            // chksdthuockhac_khongtientrien
            // 
            this.chksdthuockhac_khongtientrien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chksdthuockhac_khongtientrien.Location = new System.Drawing.Point(733, 120);
            this.chksdthuockhac_khongtientrien.Name = "chksdthuockhac_khongtientrien";
            this.chksdthuockhac_khongtientrien.Size = new System.Drawing.Size(100, 15);
            this.chksdthuockhac_khongtientrien.TabIndex = 382;
            this.chksdthuockhac_khongtientrien.Text = "Không tiến triển";
            this.chksdthuockhac_khongtientrien.CheckedChanged += new System.EventHandler(this.chksdthuockhac_khongtientrien_CheckedChanged_1);
            // 
            // chksdthuockhac_tientrientot
            // 
            this.chksdthuockhac_tientrientot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chksdthuockhac_tientrientot.Location = new System.Drawing.Point(652, 118);
            this.chksdthuockhac_tientrientot.Name = "chksdthuockhac_tientrientot";
            this.chksdthuockhac_tientrientot.Size = new System.Drawing.Size(87, 20);
            this.chksdthuockhac_tientrientot.TabIndex = 381;
            this.chksdthuockhac_tientrientot.Text = "Tiến triển tốt";
            this.chksdthuockhac_tientrientot.CheckedChanged += new System.EventHandler(this.chksdthuockhac_tientrientot_CheckedChanged_1);
            // 
            // chkngungthuoc_khongbiet
            // 
            this.chkngungthuoc_khongbiet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkngungthuoc_khongbiet.Location = new System.Drawing.Point(925, 97);
            this.chkngungthuoc_khongbiet.Name = "chkngungthuoc_khongbiet";
            this.chkngungthuoc_khongbiet.Size = new System.Drawing.Size(77, 21);
            this.chkngungthuoc_khongbiet.TabIndex = 380;
            this.chkngungthuoc_khongbiet.Text = "Không biết";
            this.chkngungthuoc_khongbiet.CheckedChanged += new System.EventHandler(this.chkngungthuoc_khongbiet_CheckedChanged_1);
            // 
            // chkngungthuoc_dieutritiep
            // 
            this.chkngungthuoc_dieutritiep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkngungthuoc_dieutritiep.Location = new System.Drawing.Point(832, 97);
            this.chkngungthuoc_dieutritiep.Name = "chkngungthuoc_dieutritiep";
            this.chkngungthuoc_dieutritiep.Size = new System.Drawing.Size(99, 22);
            this.chkngungthuoc_dieutritiep.TabIndex = 379;
            this.chkngungthuoc_dieutritiep.Text = "Điều trị tiếp tục";
            this.chkngungthuoc_dieutritiep.CheckedChanged += new System.EventHandler(this.chkngungthuoc_dieutritiep_CheckedChanged_1);
            // 
            // chkngungthuoc_khongtientrien
            // 
            this.chkngungthuoc_khongtientrien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkngungthuoc_khongtientrien.Location = new System.Drawing.Point(733, 98);
            this.chkngungthuoc_khongtientrien.Name = "chkngungthuoc_khongtientrien";
            this.chkngungthuoc_khongtientrien.Size = new System.Drawing.Size(100, 20);
            this.chkngungthuoc_khongtientrien.TabIndex = 378;
            this.chkngungthuoc_khongtientrien.Text = "Không tiến triển";
            this.chkngungthuoc_khongtientrien.CheckedChanged += new System.EventHandler(this.chkngungthuoc_khongtientrien_CheckedChanged_1);
            // 
            // chkngungthuoc_tientrientot
            // 
            this.chkngungthuoc_tientrientot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkngungthuoc_tientrientot.Location = new System.Drawing.Point(652, 97);
            this.chkngungthuoc_tientrientot.Name = "chkngungthuoc_tientrientot";
            this.chkngungthuoc_tientrientot.Size = new System.Drawing.Size(87, 21);
            this.chkngungthuoc_tientrientot.TabIndex = 377;
            this.chkngungthuoc_tientrientot.Text = "Tiến triển tốt";
            this.chkngungthuoc_tientrientot.CheckedChanged += new System.EventHandler(this.chkngungthuoc_tientrientot_CheckedChanged_1);
            // 
            // txtsdthuockhac
            // 
            this.txtsdthuockhac.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtsdthuockhac.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtsdthuockhac.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsdthuockhac.Location = new System.Drawing.Point(168, 115);
            this.txtsdthuockhac.Multiline = true;
            this.txtsdthuockhac.Name = "txtsdthuockhac";
            this.txtsdthuockhac.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtsdthuockhac.Size = new System.Drawing.Size(482, 21);
            this.txtsdthuockhac.TabIndex = 373;
            // 
            // txtngungdungthuoc
            // 
            this.txtngungdungthuoc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtngungdungthuoc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtngungdungthuoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtngungdungthuoc.Location = new System.Drawing.Point(168, 91);
            this.txtngungdungthuoc.Multiline = true;
            this.txtngungdungthuoc.Name = "txtngungdungthuoc";
            this.txtngungdungthuoc.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtngungdungthuoc.Size = new System.Drawing.Size(482, 21);
            this.txtngungdungthuoc.TabIndex = 372;
            // 
            // label74
            // 
            this.label74.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label74.Location = new System.Drawing.Point(11, 112);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(153, 26);
            this.label74.TabIndex = 376;
            this.label74.Text = "Sử dụng các thuốc khác :";
            this.label74.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label73
            // 
            this.label73.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label73.Location = new System.Drawing.Point(42, 96);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(120, 16);
            this.label73.TabIndex = 375;
            this.label73.Text = "Ngưng dùng thuốc :";
            this.label73.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label72
            // 
            this.label72.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label72.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label72.Location = new System.Drawing.Point(11, 81);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(168, 17);
            this.label72.TabIndex = 374;
            this.label72.Text = "III. Cách sử trí ADR :";
            this.label72.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkditat_md
            // 
            this.chkditat_md.AutoSize = true;
            this.chkditat_md.Location = new System.Drawing.Point(581, 158);
            this.chkditat_md.Name = "chkditat_md";
            this.chkditat_md.Size = new System.Drawing.Size(88, 17);
            this.chkditat_md.TabIndex = 371;
            this.chkditat_md.Text = "Dị tật thai nhi";
            this.chkditat_md.UseVisualStyleBackColor = true;
            this.chkditat_md.CheckedChanged += new System.EventHandler(this.chkditat_md_CheckedChanged);
            // 
            // chkkhongngtrong_md
            // 
            this.chkkhongngtrong_md.AutoSize = true;
            this.chkkhongngtrong_md.Location = new System.Drawing.Point(678, 158);
            this.chkkhongngtrong_md.Name = "chkkhongngtrong_md";
            this.chkkhongngtrong_md.Size = new System.Drawing.Size(121, 17);
            this.chkkhongngtrong_md.TabIndex = 370;
            this.chkkhongngtrong_md.Text = "Không nghiêm trọng";
            this.chkkhongngtrong_md.UseVisualStyleBackColor = true;
            this.chkkhongngtrong_md.CheckedChanged += new System.EventHandler(this.chkkhongngtrong_md_CheckedChanged);
            // 
            // chktuvong_md
            // 
            this.chktuvong_md.AutoSize = true;
            this.chktuvong_md.Location = new System.Drawing.Point(11, 158);
            this.chktuvong_md.Name = "chktuvong_md";
            this.chktuvong_md.Size = new System.Drawing.Size(66, 17);
            this.chktuvong_md.TabIndex = 369;
            this.chktuvong_md.Text = "Tử vong";
            this.chktuvong_md.UseVisualStyleBackColor = true;
            this.chktuvong_md.CheckedChanged += new System.EventHandler(this.chktuvong_md_CheckedChanged);
            // 
            // chktantat_md
            // 
            this.chktantat_md.AutoSize = true;
            this.chktantat_md.Location = new System.Drawing.Point(422, 158);
            this.chktantat_md.Name = "chktantat_md";
            this.chktantat_md.Size = new System.Drawing.Size(153, 17);
            this.chktantat_md.TabIndex = 368;
            this.chktantat_md.Text = "Tàn tật vĩnh viễn/nặng nề";
            this.chktantat_md.UseVisualStyleBackColor = true;
            this.chktantat_md.CheckedChanged += new System.EventHandler(this.chktantat_md_CheckedChanged);
            // 
            // chkdedoa_md
            // 
            this.chkdedoa_md.AutoSize = true;
            this.chkdedoa_md.Location = new System.Drawing.Point(91, 158);
            this.chkdedoa_md.Name = "chkdedoa_md";
            this.chkdedoa_md.Size = new System.Drawing.Size(112, 17);
            this.chkdedoa_md.TabIndex = 367;
            this.chkdedoa_md.Text = "Đe dọa tính mạng";
            this.chkdedoa_md.UseVisualStyleBackColor = true;
            this.chkdedoa_md.CheckedChanged += new System.EventHandler(this.chkdedoa_md_CheckedChanged);
            // 
            // chknhapnamvien_md
            // 
            this.chknhapnamvien_md.AutoSize = true;
            this.chknhapnamvien_md.Location = new System.Drawing.Point(211, 158);
            this.chknhapnamvien_md.Name = "chknhapnamvien_md";
            this.chknhapnamvien_md.Size = new System.Drawing.Size(205, 17);
            this.chknhapnamvien_md.TabIndex = 366;
            this.chknhapnamvien_md.Text = "Nhập viện/Kéo dài thời gian nằm viện";
            this.chknhapnamvien_md.UseVisualStyleBackColor = true;
            this.chknhapnamvien_md.CheckedChanged += new System.EventHandler(this.chknhapnamvien_md_CheckedChanged);
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label15.Location = new System.Drawing.Point(5, 138);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(231, 17);
            this.label15.TabIndex = 365;
            this.label15.Text = "IV. Mức độ nghiêm trọng của phản ứng:";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkkhongthephanloai
            // 
            this.chkkhongthephanloai.Location = new System.Drawing.Point(284, 324);
            this.chkkhongthephanloai.Name = "chkkhongthephanloai";
            this.chkkhongthephanloai.Size = new System.Drawing.Size(13, 14);
            this.chkkhongthephanloai.TabIndex = 364;
            this.chkkhongthephanloai.CheckedChanged += new System.EventHandler(this.chkkhongthephanloai_CheckedChanged);
            // 
            // chkchuaphanloai
            // 
            this.chkchuaphanloai.Location = new System.Drawing.Point(284, 306);
            this.chkchuaphanloai.Name = "chkchuaphanloai";
            this.chkchuaphanloai.Size = new System.Drawing.Size(13, 14);
            this.chkchuaphanloai.TabIndex = 363;
            this.chkchuaphanloai.CheckedChanged += new System.EventHandler(this.chkchuaphanloai_CheckedChanged);
            // 
            // lab
            // 
            this.lab.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab.Location = new System.Drawing.Point(316, 322);
            this.lab.Name = "lab";
            this.lab.Size = new System.Drawing.Size(157, 16);
            this.lab.TabIndex = 361;
            this.lab.Text = "Không thể phân loại";
            this.lab.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label35
            // 
            this.label35.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label35.Location = new System.Drawing.Point(314, 303);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(140, 16);
            this.label35.TabIndex = 360;
            this.label35.Text = "Chưa phân loại";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Thangkhac
            // 
            this.Thangkhac.AutoSize = true;
            this.Thangkhac.Location = new System.Drawing.Point(425, 360);
            this.Thangkhac.Name = "Thangkhac";
            this.Thangkhac.Size = new System.Drawing.Size(84, 17);
            this.Thangkhac.TabIndex = 359;
            this.Thangkhac.Text = "Thang khác";
            this.Thangkhac.UseVisualStyleBackColor = true;
            this.Thangkhac.CheckedChanged += new System.EventHandler(this.Thangkhac_CheckedChanged);
            // 
            // ThangNaranjo
            // 
            this.ThangNaranjo.AutoSize = true;
            this.ThangNaranjo.Location = new System.Drawing.Point(247, 360);
            this.ThangNaranjo.Name = "ThangNaranjo";
            this.ThangNaranjo.Size = new System.Drawing.Size(97, 17);
            this.ThangNaranjo.TabIndex = 358;
            this.ThangNaranjo.Text = "Thang Naranjo";
            this.ThangNaranjo.UseVisualStyleBackColor = true;
            this.ThangNaranjo.CheckedChanged += new System.EventHandler(this.ThangNaranjo_CheckedChanged);
            // 
            // ThangWho
            // 
            this.ThangWho.AutoSize = true;
            this.ThangWho.Location = new System.Drawing.Point(79, 360);
            this.ThangWho.Name = "ThangWho";
            this.ThangWho.Size = new System.Drawing.Size(87, 17);
            this.ThangWho.TabIndex = 357;
            this.ThangWho.Text = "Thang WHO";
            this.ThangWho.UseVisualStyleBackColor = true;
            this.ThangWho.CheckedChanged += new System.EventHandler(this.ThangWho_CheckedChanged);
            // 
            // chkbosung
            // 
            this.chkbosung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkbosung.Location = new System.Drawing.Point(847, 504);
            this.chkbosung.Name = "chkbosung";
            this.chkbosung.Size = new System.Drawing.Size(90, 17);
            this.chkbosung.TabIndex = 356;
            this.chkbosung.Text = "Bổ sung";
            this.chkbosung.CheckedChanged += new System.EventHandler(this.chkbosung_CheckedChanged);
            // 
            // chklandau
            // 
            this.chklandau.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chklandau.Location = new System.Drawing.Point(771, 504);
            this.chklandau.Name = "chklandau";
            this.chklandau.Size = new System.Drawing.Size(70, 16);
            this.chklandau.TabIndex = 355;
            this.chklandau.Text = "Lần đầu";
            this.chklandau.CheckedChanged += new System.EventHandler(this.chklandau_CheckedChanged);
            // 
            // txtkyten
            // 
            this.txtkyten.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtkyten.Location = new System.Drawing.Point(518, 528);
            this.txtkyten.Name = "txtkyten";
            this.txtkyten.Size = new System.Drawing.Size(153, 20);
            this.txtkyten.TabIndex = 10;
            this.txtkyten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox17_KeyDown);
            // 
            // label50
            // 
            this.label50.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label50.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label50.Location = new System.Drawing.Point(468, 529);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(48, 16);
            this.label50.TabIndex = 352;
            this.label50.Text = "Ký tên :";
            this.label50.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label51
            // 
            this.label51.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label51.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label51.Location = new System.Drawing.Point(683, 504);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(85, 16);
            this.label51.TabIndex = 351;
            this.label51.Text = "Dạng báo cáo :";
            this.label51.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtchucvu
            // 
            this.txtchucvu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtchucvu.Location = new System.Drawing.Point(518, 502);
            this.txtchucvu.Name = "txtchucvu";
            this.txtchucvu.Size = new System.Drawing.Size(153, 20);
            this.txtchucvu.TabIndex = 8;
            this.txtchucvu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox16_KeyDown);
            // 
            // label49
            // 
            this.label49.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label49.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label49.Location = new System.Drawing.Point(468, 503);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(57, 16);
            this.label49.TabIndex = 347;
            this.label49.Text = "Chức vụ :";
            this.label49.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtngaybc
            // 
            this.txtngaybc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtngaybc.Location = new System.Drawing.Point(315, 523);
            this.txtngaybc.Mask = "00/00/0000";
            this.txtngaybc.Name = "txtngaybc";
            this.txtngaybc.Size = new System.Drawing.Size(68, 20);
            this.txtngaybc.TabIndex = 7;
            this.txtngaybc.ValidatingType = typeof(System.DateTime);
            this.txtngaybc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtngaybc_KeyDown);
            // 
            // txtEmail
            // 
            this.txtEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtEmail.Location = new System.Drawing.Point(315, 502);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(153, 20);
            this.txtEmail.TabIndex = 6;
            this.txtEmail.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEmail_KeyDown);
            // 
            // label46
            // 
            this.label46.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label46.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label46.Location = new System.Drawing.Point(238, 523);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(80, 16);
            this.label46.TabIndex = 344;
            this.label46.Text = "Ngày báo cáo :";
            this.label46.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label47
            // 
            this.label47.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label47.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label47.Location = new System.Drawing.Point(244, 503);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(74, 16);
            this.label47.TabIndex = 343;
            this.label47.Text = "Địa chỉ Email :";
            this.label47.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtsodienthoai
            // 
            this.txtsodienthoai.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtsodienthoai.Location = new System.Drawing.Point(83, 524);
            this.txtsodienthoai.Name = "txtsodienthoai";
            this.txtsodienthoai.Size = new System.Drawing.Size(153, 20);
            this.txtsodienthoai.TabIndex = 5;
            this.txtsodienthoai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtsodienthoai_KeyDown);
            // 
            // txtten
            // 
            this.txtten.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtten.Location = new System.Drawing.Point(83, 503);
            this.txtten.Name = "txtten";
            this.txtten.Size = new System.Drawing.Size(153, 20);
            this.txtten.TabIndex = 4;
            this.txtten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtten_KeyDown);
            // 
            // label44
            // 
            this.label44.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label44.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label44.Location = new System.Drawing.Point(9, 524);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(80, 16);
            this.label44.TabIndex = 340;
            this.label44.Text = "Số điện thoại :";
            this.label44.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label45
            // 
            this.label45.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label45.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label45.Location = new System.Drawing.Point(53, 504);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(33, 16);
            this.label45.TabIndex = 339;
            this.label45.Text = "Tên :";
            this.label45.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label43
            // 
            this.label43.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label43.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label43.Location = new System.Drawing.Point(7, 458);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(336, 17);
            this.label43.TabIndex = 338;
            this.label43.Text = "VII-Thông tin về người báo cáo :";
            this.label43.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label42
            // 
            this.label42.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label42.Location = new System.Drawing.Point(39, 338);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(247, 26);
            this.label42.TabIndex = 337;
            this.label42.Text = "Đơn vị thẩm định ADR theo thang nào?";
            this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkkhongchacchan_yte
            // 
            this.chkkhongchacchan_yte.Location = new System.Drawing.Point(284, 289);
            this.chkkhongchacchan_yte.Name = "chkkhongchacchan_yte";
            this.chkkhongchacchan_yte.Size = new System.Drawing.Size(13, 14);
            this.chkkhongchacchan_yte.TabIndex = 331;
            this.chkkhongchacchan_yte.CheckedChanged += new System.EventHandler(this.chkkhongchacchan_yte_CheckedChanged);
            // 
            // chkcothe_yte
            // 
            this.chkcothe_yte.Location = new System.Drawing.Point(55, 325);
            this.chkcothe_yte.Name = "chkcothe_yte";
            this.chkcothe_yte.Size = new System.Drawing.Size(13, 14);
            this.chkcothe_yte.TabIndex = 330;
            this.chkcothe_yte.CheckedChanged += new System.EventHandler(this.chkcothe_yte_CheckedChanged);
            // 
            // chkcokhanang_yte
            // 
            this.chkcokhanang_yte.Location = new System.Drawing.Point(55, 308);
            this.chkcokhanang_yte.Name = "chkcokhanang_yte";
            this.chkcokhanang_yte.Size = new System.Drawing.Size(13, 14);
            this.chkcokhanang_yte.TabIndex = 329;
            this.chkcokhanang_yte.CheckedChanged += new System.EventHandler(this.chkcokhanang_yte_CheckedChanged);
            // 
            // chkchacchan_yte
            // 
            this.chkchacchan_yte.Location = new System.Drawing.Point(55, 292);
            this.chkchacchan_yte.Name = "chkchacchan_yte";
            this.chkchacchan_yte.Size = new System.Drawing.Size(13, 14);
            this.chkchacchan_yte.TabIndex = 328;
            this.chkchacchan_yte.CheckedChanged += new System.EventHandler(this.chkchacchan_yte_CheckedChanged);
            // 
            // label41
            // 
            this.label41.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label41.Location = new System.Drawing.Point(313, 287);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(157, 16);
            this.label41.TabIndex = 327;
            this.label41.Text = "Không có chắc chắn(Unlikely) :";
            this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label40
            // 
            this.label40.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label40.Location = new System.Drawing.Point(64, 322);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(106, 16);
            this.label40.TabIndex = 326;
            this.label40.Text = "Có thể(Posible) :";
            this.label40.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label39
            // 
            this.label39.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label39.Location = new System.Drawing.Point(67, 305);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(136, 16);
            this.label39.TabIndex = 325;
            this.label39.Text = "Có khả năng(Probable) :";
            this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label38
            // 
            this.label38.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label38.Location = new System.Drawing.Point(65, 289);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(123, 16);
            this.label38.TabIndex = 304;
            this.label38.Text = "Chắc chắn(Certain) :";
            this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label34
            // 
            this.label34.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.Location = new System.Drawing.Point(42, 273);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(189, 15);
            this.label34.TabIndex = 322;
            this.label34.Text = "Đánh giá liên quan đến ADR :";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label33
            // 
            this.label33.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label33.Location = new System.Drawing.Point(10, 256);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(336, 17);
            this.label33.TabIndex = 321;
            this.label33.Text = "VI-Phần thẩm định ADR :";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtbinhluanbacsi
            // 
            this.txtbinhluanbacsi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtbinhluanbacsi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtbinhluanbacsi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbinhluanbacsi.Location = new System.Drawing.Point(42, 393);
            this.txtbinhluanbacsi.Multiline = true;
            this.txtbinhluanbacsi.Name = "txtbinhluanbacsi";
            this.txtbinhluanbacsi.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtbinhluanbacsi.Size = new System.Drawing.Size(878, 47);
            this.txtbinhluanbacsi.TabIndex = 2;
            this.txtbinhluanbacsi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbinhluanbacsi_KeyDown);
            // 
            // label32
            // 
            this.label32.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label32.Location = new System.Drawing.Point(39, 376);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(336, 17);
            this.label32.TabIndex = 319;
            this.label32.Text = "Phần bình luận của cán bộ y tế:";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkkhongxacdinh
            // 
            this.chkkhongxacdinh.Location = new System.Drawing.Point(584, 212);
            this.chkkhongxacdinh.Name = "chkkhongxacdinh";
            this.chkkhongxacdinh.Size = new System.Drawing.Size(137, 27);
            this.chkkhongxacdinh.TabIndex = 318;
            this.chkkhongxacdinh.Text = "Không xác định";
            this.chkkhongxacdinh.CheckedChanged += new System.EventHandler(this.chkkhongxacdinh_CheckedChanged);
            // 
            // chkchetkhonglienquanthuoc
            // 
            this.chkchetkhonglienquanthuoc.Location = new System.Drawing.Point(294, 212);
            this.chkchetkhonglienquanthuoc.Name = "chkchetkhonglienquanthuoc";
            this.chkchetkhonglienquanthuoc.Size = new System.Drawing.Size(204, 27);
            this.chkchetkhonglienquanthuoc.TabIndex = 317;
            this.chkchetkhonglienquanthuoc.Text = "Tử vong không liên quan đến thuốc";
            this.chkchetkhonglienquanthuoc.CheckedChanged += new System.EventHandler(this.chkchetkhonglienquanthuoc_CheckedChanged);
            // 
            // chkchetdoADR
            // 
            this.chkchetdoADR.Location = new System.Drawing.Point(294, 192);
            this.chkchetdoADR.Name = "chkchetdoADR";
            this.chkchetdoADR.Size = new System.Drawing.Size(154, 27);
            this.chkchetdoADR.TabIndex = 316;
            this.chkchetdoADR.Text = "Tử vong do ADR";
            this.chkchetdoADR.CheckedChanged += new System.EventHandler(this.chkchetdoADR_CheckedChanged);
            // 
            // chkkhongphuchoi
            // 
            this.chkkhongphuchoi.Location = new System.Drawing.Point(47, 232);
            this.chkkhongphuchoi.Name = "chkkhongphuchoi";
            this.chkkhongphuchoi.Size = new System.Drawing.Size(137, 27);
            this.chkkhongphuchoi.TabIndex = 315;
            this.chkkhongphuchoi.Text = "Chưa phục hồi";
            this.chkkhongphuchoi.CheckedChanged += new System.EventHandler(this.chkkhongphuchoi_CheckedChanged);
            // 
            // chkphuchoicodichung
            // 
            this.chkphuchoicodichung.Location = new System.Drawing.Point(47, 212);
            this.chkphuchoicodichung.Name = "chkphuchoicodichung";
            this.chkphuchoicodichung.Size = new System.Drawing.Size(137, 27);
            this.chkphuchoicodichung.TabIndex = 314;
            this.chkphuchoicodichung.Text = "Phục hồi có di chứng";
            this.chkphuchoicodichung.CheckedChanged += new System.EventHandler(this.chkphuchoicodichung_CheckedChanged);
            // 
            // chkhoiphuckhongdichung
            // 
            this.chkhoiphuckhongdichung.Location = new System.Drawing.Point(47, 192);
            this.chkhoiphuckhongdichung.Name = "chkhoiphuckhongdichung";
            this.chkhoiphuckhongdichung.Size = new System.Drawing.Size(154, 27);
            this.chkhoiphuckhongdichung.TabIndex = 313;
            this.chkhoiphuckhongdichung.Text = "Hồi phục không di chứng";
            this.chkhoiphuckhongdichung.CheckedChanged += new System.EventHandler(this.chkhoiphuckhongdichung_CheckedChanged);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label8.Location = new System.Drawing.Point(4, 177);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(336, 17);
            this.label8.TabIndex = 312;
            this.label8.Text = "V-Kết quả sau khi xử trí ADR(đánh giá của bác điều trị) :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // butin
            // 
            this.butin.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.butin.Image = ((System.Drawing.Image)(resources.GetObject("butin.Image")));
            this.butin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butin.Location = new System.Drawing.Point(685, 694);
            this.butin.Name = "butin";
            this.butin.Size = new System.Drawing.Size(61, 24);
            this.butin.TabIndex = 11;
            this.butin.Text = "    In";
            this.butin.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butin.UseVisualStyleBackColor = true;
            this.butin.Click += new System.EventHandler(this.butin_Click);
            // 
            // butketthuc
            // 
            this.butketthuc.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.butketthuc.Image = ((System.Drawing.Image)(resources.GetObject("butketthuc.Image")));
            this.butketthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butketthuc.Location = new System.Drawing.Point(749, 694);
            this.butketthuc.Name = "butketthuc";
            this.butketthuc.Size = new System.Drawing.Size(69, 24);
            this.butketthuc.TabIndex = 12;
            this.butketthuc.Text = "Kết thúc";
            this.butketthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butketthuc.UseVisualStyleBackColor = true;
            this.butketthuc.Click += new System.EventHandler(this.butketthuc_Click);
            // 
            // butboqua
            // 
            this.butboqua.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.butboqua.Image = ((System.Drawing.Image)(resources.GetObject("butboqua.Image")));
            this.butboqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butboqua.Location = new System.Drawing.Point(621, 694);
            this.butboqua.Name = "butboqua";
            this.butboqua.Size = new System.Drawing.Size(61, 24);
            this.butboqua.TabIndex = 10;
            this.butboqua.Text = "    Bỏ qua";
            this.butboqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butboqua.UseVisualStyleBackColor = true;
            this.butboqua.Click += new System.EventHandler(this.butboqua_Click);
            // 
            // butxoa
            // 
            this.butxoa.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.butxoa.Image = ((System.Drawing.Image)(resources.GetObject("butxoa.Image")));
            this.butxoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butxoa.Location = new System.Drawing.Point(557, 694);
            this.butxoa.Name = "butxoa";
            this.butxoa.Size = new System.Drawing.Size(61, 24);
            this.butxoa.TabIndex = 9;
            this.butxoa.Text = "    Xóa";
            this.butxoa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butxoa.UseVisualStyleBackColor = true;
            this.butxoa.Click += new System.EventHandler(this.butxoa_Click);
            // 
            // butsua
            // 
            this.butsua.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.butsua.Image = ((System.Drawing.Image)(resources.GetObject("butsua.Image")));
            this.butsua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butsua.Location = new System.Drawing.Point(493, 694);
            this.butsua.Name = "butsua";
            this.butsua.Size = new System.Drawing.Size(61, 24);
            this.butsua.TabIndex = 8;
            this.butsua.Text = "    Sửa";
            this.butsua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butsua.UseVisualStyleBackColor = true;
            this.butsua.Click += new System.EventHandler(this.butsua_Click);
            // 
            // butluu
            // 
            this.butluu.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.butluu.Image = ((System.Drawing.Image)(resources.GetObject("butluu.Image")));
            this.butluu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butluu.Location = new System.Drawing.Point(429, 694);
            this.butluu.Name = "butluu";
            this.butluu.Size = new System.Drawing.Size(61, 24);
            this.butluu.TabIndex = 7;
            this.butluu.Text = "    Lưu";
            this.butluu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butluu.UseVisualStyleBackColor = true;
            this.butluu.Click += new System.EventHandler(this.butluu_Click);
            // 
            // butmoi
            // 
            this.butmoi.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.butmoi.Image = ((System.Drawing.Image)(resources.GetObject("butmoi.Image")));
            this.butmoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butmoi.Location = new System.Drawing.Point(365, 694);
            this.butmoi.Name = "butmoi";
            this.butmoi.Size = new System.Drawing.Size(61, 24);
            this.butmoi.TabIndex = 6;
            this.butmoi.Text = "    Mới";
            this.butmoi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butmoi.UseVisualStyleBackColor = true;
            this.butmoi.Click += new System.EventHandler(this.butmoi_Click);
            // 
            // chkXML
            // 
            this.chkXML.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkXML.Location = new System.Drawing.Point(10, 690);
            this.chkXML.Name = "chkXML";
            this.chkXML.Size = new System.Drawing.Size(104, 16);
            this.chkXML.TabIndex = 300;
            this.chkXML.Text = "Xuất ra XML";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.ngay);
            this.groupBox2.Controls.Add(this.ngaypu);
            this.groupBox2.Controls.Add(this.label26);
            this.groupBox2.Controls.Add(this.txtmotapu);
            this.groupBox2.Controls.Add(this.msbcdonvi);
            this.groupBox2.Controls.Add(this.label25);
            this.groupBox2.Controls.Add(this.msbctt);
            this.groupBox2.Controls.Add(this.label24);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.cannang);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.chieucao);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.mabn);
            this.groupBox2.Controls.Add(this.hoten);
            this.groupBox2.Controls.Add(this.diachi);
            this.groupBox2.Controls.Add(this.namsinh);
            this.groupBox2.Controls.Add(this.phai);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1011, 92);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "I-Thông tin về phản ứng có hại";
            // 
            // ngay
            // 
            this.ngay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ngay.FormattingEnabled = true;
            this.ngay.Location = new System.Drawing.Point(83, 39);
            this.ngay.Name = "ngay";
            this.ngay.Size = new System.Drawing.Size(150, 21);
            this.ngay.TabIndex = 304;
            this.ngay.SelectedIndexChanged += new System.EventHandler(this.ngay_SelectedIndexChanged);
            // 
            // ngaypu
            // 
            this.ngaypu.Location = new System.Drawing.Point(330, 39);
            this.ngaypu.Mask = "00/00/0000 90:00";
            this.ngaypu.Name = "ngaypu";
            this.ngaypu.PromptChar = ' ';
            this.ngaypu.Size = new System.Drawing.Size(116, 20);
            this.ngaypu.TabIndex = 9;
            this.ngaypu.ValidatingType = typeof(System.DateTime);
            this.ngaypu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngaypu_KeyDown);
            // 
            // label26
            // 
            this.label26.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(0, 57);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(83, 32);
            this.label26.TabIndex = 303;
            this.label26.Text = "Mô tả phản ứng và nhận xét :";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtmotapu
            // 
            this.txtmotapu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtmotapu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtmotapu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmotapu.Location = new System.Drawing.Point(83, 62);
            this.txtmotapu.Multiline = true;
            this.txtmotapu.Name = "txtmotapu";
            this.txtmotapu.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtmotapu.Size = new System.Drawing.Size(926, 24);
            this.txtmotapu.TabIndex = 13;
            this.txtmotapu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtmotapu_KeyDown);
            // 
            // msbcdonvi
            // 
            this.msbcdonvi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.msbcdonvi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.msbcdonvi.Location = new System.Drawing.Point(566, 39);
            this.msbcdonvi.Name = "msbcdonvi";
            this.msbcdonvi.Size = new System.Drawing.Size(159, 21);
            this.msbcdonvi.TabIndex = 10;
            this.msbcdonvi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.msbcdonvi_KeyDown);
            // 
            // label25
            // 
            this.label25.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(443, 41);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(123, 16);
            this.label25.TabIndex = 52;
            this.label25.Text = "MS báo cáo của đơn vị :";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // msbctt
            // 
            this.msbctt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.msbctt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.msbctt.Location = new System.Drawing.Point(829, 39);
            this.msbctt.Name = "msbctt";
            this.msbctt.Size = new System.Drawing.Size(180, 21);
            this.msbctt.TabIndex = 11;
            this.msbctt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.msbctt_KeyDown);
            // 
            // label24
            // 
            this.label24.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(706, 41);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(123, 16);
            this.label24.TabIndex = 50;
            this.label24.Text = "MS báo cáo của TT :";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(239, 41);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(96, 16);
            this.label18.TabIndex = 48;
            this.label18.Text = "Ngày bắt đầu PU :";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(759, 17);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(27, 16);
            this.label12.TabIndex = 47;
            this.label12.Text = "kg";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(637, 17);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(64, 16);
            this.label13.TabIndex = 45;
            this.label13.Text = "Cân nặng :";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cannang
            // 
            this.cannang.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cannang.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cannang.Location = new System.Drawing.Point(702, 15);
            this.cannang.Name = "cannang";
            this.cannang.Size = new System.Drawing.Size(51, 21);
            this.cannang.TabIndex = 7;
            this.cannang.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cannang_KeyDown);
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(619, 17);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(27, 16);
            this.label11.TabIndex = 44;
            this.label11.Text = "cm";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(502, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 42;
            this.label2.Text = "Chiều cao :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chieucao
            // 
            this.chieucao.BackColor = System.Drawing.SystemColors.HighlightText;
            this.chieucao.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chieucao.Location = new System.Drawing.Point(566, 15);
            this.chieucao.Name = "chieucao";
            this.chieucao.Size = new System.Drawing.Size(51, 21);
            this.chieucao.TabIndex = 6;
            this.chieucao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chieucao_KeyDown);
            // 
            // textBox9
            // 
            this.textBox9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox9.BackColor = System.Drawing.SystemColors.HighlightText;
            this.textBox9.Enabled = false;
            this.textBox9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox9.Location = new System.Drawing.Point(160, 508);
            this.textBox9.Multiline = true;
            this.textBox9.Name = "textBox9";
            this.textBox9.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox9.Size = new System.Drawing.Size(842, 72);
            this.textBox9.TabIndex = 309;
            // 
            // textBox10
            // 
            this.textBox10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox10.BackColor = System.Drawing.SystemColors.HighlightText;
            this.textBox10.Enabled = false;
            this.textBox10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox10.Location = new System.Drawing.Point(160, 435);
            this.textBox10.Multiline = true;
            this.textBox10.Name = "textBox10";
            this.textBox10.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox10.Size = new System.Drawing.Size(842, 72);
            this.textBox10.TabIndex = 308;
            // 
            // checkBox1
            // 
            this.checkBox1.Location = new System.Drawing.Point(11, 563);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(104, 16);
            this.checkBox1.TabIndex = 300;
            this.checkBox1.Text = "Xuất ra XML";
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label16.Location = new System.Drawing.Point(8, 418);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(240, 17);
            this.label16.TabIndex = 307;
            this.label16.Text = "III. Các thuốc dùng đồng thời và bệnh sử :";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // checkBox2
            // 
            this.checkBox2.Location = new System.Drawing.Point(825, 375);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(176, 32);
            this.checkBox2.TabIndex = 304;
            this.checkBox2.Text = "Không xuất hiện triệu chứng cũ";
            // 
            // checkBox3
            // 
            this.checkBox3.Location = new System.Drawing.Point(825, 342);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(176, 27);
            this.checkBox3.TabIndex = 303;
            this.checkBox3.Text = "Các triệu chứng cũ lặp lại";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9});
            this.dataGridView2.Location = new System.Drawing.Point(94, 28);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(908, 210);
            this.dataGridView2.TabIndex = 302;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Tên các thuốc nghi ngờ";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Hàm lượng hoặc nồng độ";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Liều dùng một lần";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Số lần dùng(ngày,tuần,tháng)";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Đường dùng";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Ngày bắt đầu điều trị";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "Ngày kết thúc điều trị";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "Lô sản xuất-Hạn dùng";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "Tên nhà sản xuất";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            // 
            // label21
            // 
            this.label21.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(8, 508);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(146, 27);
            this.label21.TabIndex = 277;
            this.label21.Text = "Các bệnh sử có liên quan khác :";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label22
            // 
            this.label22.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(8, 435);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(208, 16);
            this.label22.TabIndex = 276;
            this.label22.Text = "Các thuốc dùng đồng thời :";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label23
            // 
            this.label23.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(8, 323);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(208, 16);
            this.label23.TabIndex = 275;
            this.label23.Text = "Tái sử dụng thuốc :";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox11
            // 
            this.textBox11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox11.BackColor = System.Drawing.SystemColors.HighlightText;
            this.textBox11.Enabled = false;
            this.textBox11.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox11.Location = new System.Drawing.Point(94, 258);
            this.textBox11.Multiline = true;
            this.textBox11.Name = "textBox11";
            this.textBox11.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox11.Size = new System.Drawing.Size(908, 64);
            this.textBox11.TabIndex = 6;
            // 
            // label27
            // 
            this.label27.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(8, 240);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(200, 16);
            this.label27.TabIndex = 97;
            this.label27.Text = "Chẩn đoán và chỉ định điều trị :";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label28
            // 
            this.label28.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label28.Location = new System.Drawing.Point(8, 8);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(240, 17);
            this.label28.TabIndex = 61;
            this.label28.Text = "II. Thông tin về thuốc nghi ngờ gây ADN :";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox12
            // 
            this.textBox12.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox12.BackColor = System.Drawing.SystemColors.HighlightText;
            this.textBox12.Enabled = false;
            this.textBox12.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox12.Location = new System.Drawing.Point(3, 339);
            this.textBox12.Multiline = true;
            this.textBox12.Name = "textBox12";
            this.textBox12.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox12.Size = new System.Drawing.Size(816, 72);
            this.textBox12.TabIndex = 8;
            // 
            // checkBox12
            // 
            this.checkBox12.Location = new System.Drawing.Point(647, 96);
            this.checkBox12.Name = "checkBox12";
            this.checkBox12.Size = new System.Drawing.Size(137, 27);
            this.checkBox12.TabIndex = 308;
            this.checkBox12.Text = "Tiến triển tốt";
            // 
            // checkBox13
            // 
            this.checkBox13.Location = new System.Drawing.Point(647, 60);
            this.checkBox13.Name = "checkBox13";
            this.checkBox13.Size = new System.Drawing.Size(137, 27);
            this.checkBox13.TabIndex = 305;
            this.checkBox13.Text = "Không có tiến triển";
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label9.Location = new System.Drawing.Point(8, 160);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(336, 17);
            this.label9.TabIndex = 312;
            this.label9.Text = "V-Kết quả sau khi xử trí ADR(đánh giá của bác điều trị) :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // checkBox14
            // 
            this.checkBox14.Location = new System.Drawing.Point(840, 126);
            this.checkBox14.Name = "checkBox14";
            this.checkBox14.Size = new System.Drawing.Size(137, 27);
            this.checkBox14.TabIndex = 311;
            this.checkBox14.Text = "Không biết";
            // 
            // checkBox15
            // 
            this.checkBox15.Location = new System.Drawing.Point(840, 93);
            this.checkBox15.Name = "checkBox15";
            this.checkBox15.Size = new System.Drawing.Size(137, 27);
            this.checkBox15.TabIndex = 310;
            this.checkBox15.Text = "Phải điều trị tiếp tục";
            // 
            // checkBox16
            // 
            this.checkBox16.Location = new System.Drawing.Point(647, 129);
            this.checkBox16.Name = "checkBox16";
            this.checkBox16.Size = new System.Drawing.Size(137, 27);
            this.checkBox16.TabIndex = 309;
            this.checkBox16.Text = "Không có tiến triển";
            // 
            // checkBox17
            // 
            this.checkBox17.Location = new System.Drawing.Point(840, 57);
            this.checkBox17.Name = "checkBox17";
            this.checkBox17.Size = new System.Drawing.Size(137, 27);
            this.checkBox17.TabIndex = 307;
            this.checkBox17.Text = "Không biết";
            // 
            // checkBox18
            // 
            this.checkBox18.Location = new System.Drawing.Point(840, 24);
            this.checkBox18.Name = "checkBox18";
            this.checkBox18.Size = new System.Drawing.Size(137, 27);
            this.checkBox18.TabIndex = 306;
            this.checkBox18.Text = "Phải điều trị tiếp tục";
            // 
            // checkBox19
            // 
            this.checkBox19.Location = new System.Drawing.Point(647, 27);
            this.checkBox19.Name = "checkBox19";
            this.checkBox19.Size = new System.Drawing.Size(137, 27);
            this.checkBox19.TabIndex = 304;
            this.checkBox19.Text = "Tiến triển tốt";
            // 
            // textBox13
            // 
            this.textBox13.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox13.BackColor = System.Drawing.SystemColors.HighlightText;
            this.textBox13.Enabled = false;
            this.textBox13.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox13.Location = new System.Drawing.Point(124, 96);
            this.textBox13.Multiline = true;
            this.textBox13.Name = "textBox13";
            this.textBox13.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox13.Size = new System.Drawing.Size(517, 60);
            this.textBox13.TabIndex = 1;
            // 
            // textBox14
            // 
            this.textBox14.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox14.BackColor = System.Drawing.SystemColors.HighlightText;
            this.textBox14.Enabled = false;
            this.textBox14.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox14.Location = new System.Drawing.Point(124, 22);
            this.textBox14.Multiline = true;
            this.textBox14.Name = "textBox14";
            this.textBox14.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox14.Size = new System.Drawing.Size(517, 69);
            this.textBox14.TabIndex = 0;
            // 
            // label29
            // 
            this.label29.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(8, 98);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(119, 26);
            this.label29.TabIndex = 119;
            this.label29.Text = "Sử dụng các thuốc khác :";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label30
            // 
            this.label30.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.Location = new System.Drawing.Point(8, 24);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(127, 16);
            this.label30.TabIndex = 118;
            this.label30.Text = "Ngưng dùng thuốc :";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label31
            // 
            this.label31.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label31.Location = new System.Drawing.Point(8, 6);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(168, 17);
            this.label31.TabIndex = 115;
            this.label31.Text = "IV-Cách sử trí ADR :";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button3
            // 
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.button3.Location = new System.Drawing.Point(5, 454);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(83, 37);
            this.button3.TabIndex = 310;
            this.button3.Text = "    Xem các chỉ định làm";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
            this.button4.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.button4.Location = new System.Drawing.Point(5, 268);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(83, 37);
            this.button4.TabIndex = 306;
            this.button4.Text = "    Xem các chỉ định làm";
            this.button4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Image = ((System.Drawing.Image)(resources.GetObject("button5.Image")));
            this.button5.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.button5.Location = new System.Drawing.Point(5, 55);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(83, 37);
            this.button5.TabIndex = 305;
            this.button5.Text = "Xem các thuốc sử dụng";
            this.button5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button5.UseVisualStyleBackColor = true;
            // 
            // listICD
            // 
            this.listICD.BackColor = System.Drawing.SystemColors.Info;
            this.listICD.ColumnCount = 0;
            this.listICD.Location = new System.Drawing.Point(1000, 900);
            this.listICD.MatchBufferTimeOut = 1000;
            this.listICD.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listICD.Name = "listICD";
            this.listICD.Size = new System.Drawing.Size(75, 17);
            this.listICD.TabIndex = 216;
            this.listICD.TextIndex = -1;
            this.listICD.TextMember = null;
            this.listICD.ValueIndex = -1;
            this.listICD.Visible = false;
            this.listICD.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listICD_KeyDown);
            // 
            // buttsddt
            // 
            this.buttsddt.Image = ((System.Drawing.Image)(resources.GetObject("buttsddt.Image")));
            this.buttsddt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttsddt.Location = new System.Drawing.Point(117, 690);
            this.buttsddt.Name = "buttsddt";
            this.buttsddt.Size = new System.Drawing.Size(143, 23);
            this.buttsddt.TabIndex = 310;
            this.buttsddt.Text = "    Xem các thuốc sử dụng";
            this.buttsddt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttsddt.UseVisualStyleBackColor = true;
            this.buttsddt.Visible = false;
            this.buttsddt.Click += new System.EventHandler(this.buttsddt_Click);
            // 
            // cbtaiphanung
            // 
            this.cbtaiphanung.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cbtaiphanung.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cbtaiphanung.FormattingEnabled = true;
            this.cbtaiphanung.Items.AddRange(new object[] {
            "Không",
            "Có",
            "Không ngừng/giảm liều",
            "Không có thông tin"});
            this.cbtaiphanung.Location = new System.Drawing.Point(492, 250);
            this.cbtaiphanung.Name = "cbtaiphanung";
            this.cbtaiphanung.Size = new System.Drawing.Size(138, 21);
            this.cbtaiphanung.TabIndex = 350;
            // 
            // chkkhac_thamdinh
            // 
            this.chkkhac_thamdinh.AutoSize = true;
            this.chkkhac_thamdinh.Location = new System.Drawing.Point(584, 302);
            this.chkkhac_thamdinh.Name = "chkkhac_thamdinh";
            this.chkkhac_thamdinh.Size = new System.Drawing.Size(51, 17);
            this.chkkhac_thamdinh.TabIndex = 388;
            this.chkkhac_thamdinh.Text = "Khác";
            this.chkkhac_thamdinh.UseVisualStyleBackColor = true;
            // 
            // frmPhanungthuoccohai
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(1014, 730);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.butin);
            this.Controls.Add(this.listICD);
            this.Controls.Add(this.butketthuc);
            this.Controls.Add(this.butxoa);
            this.Controls.Add(this.butboqua);
            this.Controls.Add(this.chkXML);
            this.Controls.Add(this.butmoi);
            this.Controls.Add(this.butluu);
            this.Controls.Add(this.butsua);
            this.Controls.Add(this.buttsddt);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmPhanungthuoccohai";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hồ sơ bệnh án";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPhanungthuoccohai_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPhanungthuoccohai_KeyDown);
            this.tabControl1.ResumeLayout(false);
            this.tab2.ResumeLayout(false);
            this.tab2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timexuathienpu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.solan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThuoc)).EndInit();
            this.tab4.ResumeLayout(false);
            this.tab4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private void frmPhanungthuoccohai_Load(object sender, System.EventArgs e)
        {
            user = m.user;
            bDanhmuc = m.bDanhmucthuocbv;
            ngay.DisplayMember = "NGAYVV";
            ngay.ValueMember = "MAQL";
            try { string mahang = m.get_data("select mahang from " + user + ".d_dmthuoc where 1=0").Tables[0].Columns[0].ToString(); }
            catch { m.execute_data("alter table " + user + ".d_dmthuoc add mahang numeric(5) default 0"); }
            LoadData("");
            loadgrid(0);
            loadgrid1(0);
            AddGridTableStyle();
            AddGridTableStyle1();
            listICD.DisplayMember = "ID";
            listICD.ValueMember = "TEN";
            load_thuoc();
            cbdonvitimexuathienpu.SelectedIndex = 0;
            cbcaithien.SelectedIndex = 0;
            cbtaiphanung.SelectedIndex = 0;
            if (s_ngay != "") ngaypu.Text = s_ngay;
            else ngaypu.Text = m.Ngaygio_hienhanh;
            txtngaybc.Text = m.Ngayhienhanh;
           
            ena_object(false);
            mabn_Validated(sender, e);
        }
        private void load_thuoc()
        {
            if (bDanhmuc) sql = "select a.id,trim(a.ten)||' '||trim(a.hamluong) as ten,a.tenhc,a.dang,a.mahc,a.duongdung from " + user + ".d_dmbd a," + user + ".d_dmnhomkho b where a.nhom=b.id and b.loai=1 and a.nhom=" + m.nhom_duoc + " order by a.tenhc";
            else sql = "select id,ten,tenhc,dang,cachdung,'' as duongdung from " + user + ".d_dmthuoc where hide=0 order by stt,ten";
            dtthuoc = m.get_data(sql).Tables[0];
            listICD.DataSource = dtthuoc;
        }
        private void emp_text()
        {
            s_sovaovien = ""; i_madoituong = 0; l_id = 0; ; l_maql = 0; ; dscd.Clear();
        }

        private void LoadData(string mabn)
        {
            if (s_ngay != "")
                xxx = user + m.mmyy(s_ngay);
            else
                xxx = user + m.mmyy(DateTime.Now.Date.ToString("dd/MM/yyyy"));
            sql = "select * from(";
            sql += "select distinct 3 as loaiba,a.madoituong,a.maql,a.mavaovien,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayvv,a.mabn,b.hoten,b.namsinh,b.phai,a.sovaovien,c.dantoc,a.chandoan, ";
            sql += "b.sonha||'-'||b.thon||'-'||f.tenpxa||'-'||e.tenquan||'-'||d.tentt as diachi ";
            sql += "from " + xxx + ".benhanpk a, " + user + ".btdbn b," + user + ".btddt c, " + user + ".btdtt d, ";
            sql += "" + user + ".btdquan e, " + user + ".btdpxa f ";
            sql += "where a.mabn=b.mabn and b.madantoc=c.madantoc and b.matt=d.matt and b.maqu=e.maqu ";
            sql += "and b.maphuongxa=f.maphuongxa and a.mabn = '" + mabn + "'";
            sql += " union all ";
            sql += "select distinct 2 as loaiba,a.madoituong,a.maql,a.mavaovien,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayvv,a.mabn,b.hoten,b.namsinh,b.phai,a.sovaovien,c.dantoc,a.chandoan, ";
            sql += "b.sonha||'-'||b.thon||'-'||f.tenpxa||'-'||e.tenquan||'-'||d.tentt as diachi ";
            sql += "from " + user + ".benhanngtr a, " + user + ".btdbn b," + user + ".btddt c, " + user + ".btdtt d, ";
            sql += "" + user + ".btdquan e, " + user + ".btdpxa f ";
            sql += "where a.mabn=b.mabn and b.madantoc=c.madantoc and b.matt=d.matt and b.maqu=e.maqu ";
            sql += "and b.maphuongxa=f.maphuongxa and a.mabn = '" + mabn + "'";
            sql += " union all ";
            sql += "select distinct 1 as loaiba,a.madoituong,a.maql,a.mavaovien,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayvv,a.mabn,b.hoten,b.namsinh,b.phai,a.sovaovien,c.dantoc,a.chandoan, ";
            sql += "b.sonha||'-'||b.thon||'-'||f.tenpxa||'-'||e.tenquan||'-'||d.tentt as diachi ";
            sql += "from " + user + ".benhandt a, " + user + ".btdbn b," + user + ".btddt c, " + user + ".btdtt d, ";
            sql += "" + user + ".btdquan e, " + user + ".btdpxa f ";
            sql += "where a.mabn=b.mabn and b.madantoc=c.madantoc and b.matt=d.matt and b.maqu=e.maqu ";
            sql += "and b.maphuongxa=f.maphuongxa and a.mabn = '" + mabn + "'";
            sql += " union all ";
            sql += "select distinct 4 as loaiba,a.madoituong,a.maql,a.mavaovien,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayvv,a.mabn,b.hoten,b.namsinh,b.phai,a.sovaovien,c.dantoc,a.chandoan, ";
            sql += "b.sonha||'-'||b.thon||'-'||f.tenpxa||'-'||e.tenquan||'-'||d.tentt as diachi ";
            sql += "from " + xxx + ".benhancc a, " + user + ".btdbn b," + user + ".btddt c, " + user + ".btdtt d, ";
            sql += "" + user + ".btdquan e, " + user + ".btdpxa f ";
            sql += "where a.mabn=b.mabn and b.madantoc=c.madantoc and b.matt=d.matt and b.maqu=e.maqu ";
            sql += "and b.maphuongxa=f.maphuongxa and a.mabn = '" + mabn + "'";
            sql += " ) order by ngayvv desc";
            ds = m.get_data(sql);
           
            ngay.DataSource = ds.Tables[0];
        }
        private void AddGridTableStyle()
        {
            DataGridColoredTextBoxColumn TextCol;
            delegateGetColorRowCol de = new delegateGetColorRowCol(MyGetColorRowCol);
            DataGridTableStyle ts = new DataGridTableStyle();
            ts.MappingName = dsthuoc.Tables[0].TableName;
            ts.AlternatingBackColor = Color.Beige;
            ts.BackColor = Color.GhostWhite;
            ts.ForeColor = Color.MidnightBlue;
            ts.GridLineColor = Color.RoyalBlue;
            ts.HeaderBackColor = Color.MidnightBlue;
            ts.HeaderForeColor = Color.Lavender;
            //ts.SelectionBackColor = Color.Teal;
            ts.SelectionBackColor = Color.FromArgb(0, 255, 255);
            ts.SelectionForeColor = Color.PaleGreen;
            //ts.ReadOnly=false;
            ts.RowHeaderWidth = 5;

            TextCol = new DataGridColoredTextBoxColumn(de, 0);
            TextCol.MappingName = "mabd";
            TextCol.HeaderText = "Mabd";
            TextCol.Width = 0;
            TextCol.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 1);
            TextCol.MappingName = "tenbd";
            TextCol.HeaderText = "Tên thuốc - hàm lượng";
            TextCol.Width = 200;
            TextCol.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);


            TextCol = new DataGridColoredTextBoxColumn(de, 2);
            TextCol.MappingName = "hamluong";
            TextCol.HeaderText = "Dạng bào chế";
            TextCol.Width = 100;
            TextCol.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 3);
            TextCol.MappingName = "cachdung";
            TextCol.HeaderText = "Liều dùng trong 1 lần";
            TextCol.Width = 100;
            TextCol.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 4);
            TextCol.MappingName = "solan";
            TextCol.HeaderText = "Số lần dùng";
            TextCol.Width = 80;
            TextCol.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 5);
            TextCol.MappingName = "duongdung";
            TextCol.HeaderText = "Đường dùng";
            TextCol.Width = 100;
            TextCol.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 6);
            TextCol.MappingName = "ngay";
            TextCol.HeaderText = "Ngày bắt đầu";
            TextCol.Width = 80; 
            TextCol.Format = "dd/MM/yyyy hh:mm";
            TextCol.ReadOnly = false;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 7);
            TextCol.MappingName = "ngayket";
            TextCol.HeaderText = "Ngày kết thúc";
            TextCol.Width = 80; 
            TextCol.Format = "dd/MM/yyyy hh:mm";
            TextCol.ReadOnly = false;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 8);
            TextCol.MappingName = "losx";
            TextCol.HeaderText = "Lô sản xuất-hạn dùng";
            TextCol.Width = 100;
            TextCol.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 9);
            TextCol.MappingName = "ten";
            TextCol.HeaderText = "Tên nhà sản xuất";
            TextCol.Width = 100;
            TextCol.ReadOnly = true;
            TextCol.Alignment = HorizontalAlignment.Right;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 10);
            TextCol.MappingName = "loai";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            TextCol.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 11);
            TextCol.MappingName = "lydodungthuoc";
            TextCol.HeaderText = "Lý do dùng thuốc";
            TextCol.Width = 0;
            TextCol.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 12);
            TextCol.MappingName = "caithien";
            TextCol.HeaderText = "Cải thiện";
            TextCol.Width = 0;
            TextCol.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 13);
            TextCol.MappingName = "taiphanung";
            TextCol.HeaderText = "Tái phản ứng";
            TextCol.Width = 0;
            TextCol.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 14);
            TextCol.MappingName = "moilan";
            TextCol.HeaderText = "Mỗi lần";
            TextCol.Width = 0;
            TextCol.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);
        }

        private void AddGridTableStyle1()
        {
            DataGridColoredTextBoxColumn TextCol;
            delegateGetColorRowCol de = new delegateGetColorRowCol(MyGetColorRowCol);
            DataGridTableStyle ts = new DataGridTableStyle();
            ts.MappingName = dsthuocsddongthoi.Tables[0].TableName;
            ts.AlternatingBackColor = Color.Beige;
            ts.BackColor = Color.GhostWhite;
            ts.ForeColor = Color.MidnightBlue;
            ts.GridLineColor = Color.RoyalBlue;
            ts.HeaderBackColor = Color.MidnightBlue;
            ts.HeaderForeColor = Color.Lavender;
            //ts.SelectionBackColor = Color.Teal;
            ts.SelectionBackColor = Color.FromArgb(0, 255, 255);
            ts.SelectionForeColor = Color.PaleGreen;
            //ts.ReadOnly=false;
            ts.RowHeaderWidth = 5;

            TextCol = new DataGridColoredTextBoxColumn(de, 0);
            TextCol.MappingName = "mabd";
            TextCol.HeaderText = "Mabd";
            TextCol.Width = 0;
            TextCol.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid2.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 1);
            TextCol.MappingName = "tenbd";
            TextCol.HeaderText = "Tên thuốc - hàm lượng";
            TextCol.Width = 200;
            TextCol.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid2.TableStyles.Add(ts);


            TextCol = new DataGridColoredTextBoxColumn(de, 2);
            TextCol.MappingName = "hamluong";
            TextCol.HeaderText = "Dạng bào chế";
            TextCol.Width = 100;
            TextCol.ReadOnly = true;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid2.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 3);
            TextCol.MappingName = "ngay";
            TextCol.HeaderText = "Ngày bắt đầu";
            TextCol.Width = 80;
            TextCol.Format = "dd/MM/yyyy hh:mm";
            TextCol.ReadOnly = false;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid2.TableStyles.Add(ts);

            TextCol = new DataGridColoredTextBoxColumn(de, 4);
            TextCol.MappingName = "ngayket";
            TextCol.HeaderText = "Ngày kết thúc";
            TextCol.Width = 80;
            TextCol.Format = "dd/MM/yyyy hh:mm";
            TextCol.ReadOnly = false;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid2.TableStyles.Add(ts);

        }
        public Color MyGetColorRowCol(int row, int col)
        {
            if (this.dataGrid1[row, 5].ToString().Trim() == "1") return Color.Red;
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
                catch { }
                finally
                {
                    base.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight);
                }
            }
        }
        private void get_mabn(string _mabn, decimal maql)
        {
            emp_text();
            LoadData(_mabn);
            sql = "mabn='" + _mabn + "'";
            if (maql != 0) sql += " and maql=" + maql;
            DataRow r = m.getrowbyid(ds.Tables[0], sql);
            if (r != null)
            {
                mabn.Text = r["mabn"].ToString();
                hoten.Text = r["hoten"].ToString();
                namsinh.Text = r["namsinh"].ToString();
                phai.Text = (r["phai"].ToString() == "0") ? "Nam" : "Nữ";
                diachi.Text = r["diachi"].ToString();
                dantoc.Text = r["dantoc"].ToString();
                ngay.Text = r["ngayvv"].ToString();
                l_maql = decimal.Parse(r["maql"].ToString());
                s_sovaovien = r["sovaovien"].ToString();
                //ena_object(false);

                //read xml thong tin nguoi bao cao
                DataSet read_xml = new DataSet();
                try
                {
                    read_xml.ReadXml("..//..//..//xml//thongtinnguoibaocao.xml", XmlReadMode.ReadSchema);
                    foreach (DataRow r1 in read_xml.Tables[0].Rows)
                    {
                        txtten.Text = r1["ten"].ToString();
                        txtsodienthoai.Text = r1["sodt"].ToString();
                        txtEmail.Text = r1["diachi"].ToString();
                        txtngaybc.Text = r1["ngaybc"].ToString();
                        txtchucvu.Text = r1["chucvu"].ToString();
                        txtkyten.Text = r1["kyten"].ToString();
                        if (r1["dangbc"].ToString() == "1") chklandau.Checked = true;
                        else if (r1["dangbc"].ToString() == "2") chkbosung.Checked = true;
                        break;
                    }
                }
                catch { }
                if (ngay.Items.Count > 0)
                {
                    ngay.SelectedIndex = 0;
                    ngay_SelectedIndexChanged(null, null);
                }
                //end read xml
            }
            else
            {
                refresh_selected();
                MessageBox.Show(lan.Change_language_MessageText("Không tìm thấy !"), LibMedi.AccessData.Msg);
                mabn.Focus();
            }
            //status_moi = 0;
        }
        private bool kiemtra()
        {
            if (ngaypu.Text.Trim().Trim(':').Trim().Trim('/').Trim() == "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Vui lòng nhập ngày phản ứng!"));
                ngaypu.Focus();
                return false;
            }
            else
            {
                DateTime dt1 = m.StringToDate(ngaypu.Text.Substring(0, 10));
                DateTime dt2 = m.StringToDate(ngay.Text.Substring(0, 10));
                if (DateTime.Compare(dt1, dt2) < 0)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Ngày phản ứng phải lớn hơn ngày vào viện!"));
                    ngaypu.Focus();
                    return false;
                }
            }
            if (dsthuoc.Tables[0].Select("ngay=''").Length > 0 || dsthuoc.Tables[0].Select("ngayket=''").Length > 0)
            {
                MessageBox.Show(lan.Change_language_MessageText("Vui lòng nhập ngày bắt đầu - kết thúc điều trị!"));
                return false;
            }
            foreach(DataRow r in dsthuoc.Tables[0].Rows)
            {
                string _ngay = r["ngay"].ToString();
                try
                {
                    m.StringToDate(_ngay);
                }
                catch
                {
                    MessageBox.Show(lan.Change_language_MessageText("Vui lòng nhập ngày bắt đầu - kết thúc điều trị!"));
                    return false;
                }
                _ngay = r["ngayket"].ToString();
                try
                {
                    m.StringToDate(_ngay);
                }
                catch
                {
                    MessageBox.Show(lan.Change_language_MessageText("Vui lòng nhập ngày bắt đầu - kết thúc điều trị!"));
                    return false;
                }
            }
            return true;
        }

        private void ena_object(bool ena)
        {
            butluu.Enabled = ena;
            butboqua.Enabled = ena;
            txtmotapu.Enabled = cd_chinh.Enabled = thuocsddongthoi.Enabled = lydodungthuoc.Enabled = cbcaithien.Enabled = cbtaiphanung.Enabled = solan.Enabled = moilan.Enabled = ena;
            txtbenhsu.Enabled = txtngungdungthuoc.Enabled = ena;
            cbdonvitimexuathienpu.Enabled = timexuathienpu.Enabled = ena;
            txtsdthuockhac.Enabled = txtbinhluanbacsi.Enabled = ena;
            chieucao.Enabled = cannang.Enabled = ena;
            butmoi.Enabled = !ena;
            butxoa.Enabled = !ena;
            butsua.Enabled = !ena;
            butketthuc.Enabled = !ena;
            Thangkhac.Enabled = ena;
            ThangNaranjo.Enabled = ena;
            ThangWho.Enabled = ena;
            chkbosung.Enabled = ena;
            chkchacchan_yte.Enabled = ena;
            chkchetdoADR.Enabled = ena;
            chkchetkhonglienquanthuoc.Enabled = ena;
            chkchuaphanloai.Enabled = ena;
            chkcothe_yte.Enabled = ena;
            chkdedoa_md.Enabled = ena;
            chkcokhanang_yte.Enabled = ena;
            chkkhongthephanloai.Enabled = ena;
            chkditat_md.Enabled = ena;
            chkhoiphuckhongdichung.Enabled = ena;
            chkkhongchacchan_yte.Enabled = ena;
            chkkhac_thamdinh.Enabled = ena;
            chkkhongngtrong_md.Enabled = ena;
            chkkhongphuchoi.Enabled = ena;
            lab.Enabled = ena;
            chkkhongxacdinh.Enabled = ena;
            chklandau.Enabled = ena;
            chkngungthuoc_dieutritiep.Enabled = ena;
            chkngungthuoc_khongbiet.Enabled = ena;
            chkngungthuoc_khongtientrien.Enabled = ena;
            chkngungthuoc_tientrientot.Enabled = ena;
            chknhapnamvien_md.Enabled = ena;
            chkphuchoicodichung.Enabled = ena;
            chksdthuockhac_dieutritiep.Enabled = ena;
            chksdthuockhac_khongbiet.Enabled = ena;
            chksdthuockhac_khongtientrien.Enabled = ena;
            chksdthuockhac_tientrientot.Enabled = ena;
            chkdangphuchoi.Enabled = ena;
            chktantat_md.Enabled = ena;
            chktuvong_md.Enabled = ena;
            txtten.Enabled = ena;
            txtEmail.Enabled = ena;
            txtkyten.Enabled = ena;
            txtchucvu.Enabled = ena;
            txtngaybc.Enabled = ena;
            txtsodienthoai.Enabled = ena;
        }

        private void mabn_Validated(object sender, System.EventArgs e)
        {
            if (mabn.Text == "" || mabn.Text.Trim().Length < 3) return;
            if (mabn.Text.Trim().Length != 8) mabn.Text = mabn.Text.Substring(0, 2) + mabn.Text.Substring(2).PadLeft(6, '0');
            get_mabn(mabn.Text, l_maql);
        }

        private void frmPhanungthuoccohai_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter) SendKeys.Send("{TAB}");
        }

        private void butKethuc_Click(object sender, System.EventArgs e)
        {
            m.close();//v.close();
            System.GC.Collect();
            this.Close();
        }

        private void butThuocdasd_Click(object sender, EventArgs e)
        {
            try
            {
                if (mabn.Text == "") return;
                frmXemthuocdasudung f = new frmXemthuocdasudung(m, mabn.Text, "", hoten.Text);
                f.ShowDialog();
                dsthuoc = f.tmp;
                dataGrid1.DataSource = f.tmp.Tables[0];
            }
            catch { }
        }

        private void butChandoandieutri_Click(object sender, EventArgs e)
        {

        }

        private void buttsddt_Click(object sender, EventArgs e)
        {
            try
            {
                if (mabn.Text == "") return;
                frmXemthuocdasudung f = new frmXemthuocdasudung(m, mabn.Text,l_maql.ToString(), hoten.Text);
                f.ShowDialog();
                string s_thuoc = "";
                foreach (DataRow dr in f.tmp.Tables[0].Select())
                {
                    s_thuoc += "+" + dr["tenbd"].ToString() + " .\n ";
                }
                //txtthuocdungdongthoi.Text = s_thuoc;
            }
            catch { }
        }

        private void butbenhsu_Click(object sender, EventArgs e)
        {

        }

        private void butmoi_Click(object sender, EventArgs e)
        {
            status_moi = 1; dsthuoc.Clear();
            dsthuocsddongthoi.Clear();
            mabn_Validated(sender, e);
            ena_object(true);
            emp_item();
            mabn.Focus();
            //dataGrid1.DataSource = dsthuoc.Tables[0];
        }

        private void butsua_Click(object sender, EventArgs e)
        {
            ena_object(true);
        }

        private void butxoa_Click(object sender, EventArgs e)
        {

        }

        private void butketthuc_Click(object sender, EventArgs e)
        {
            m.close();//v.close();
            System.GC.Collect();
            this.Close();
        }

        private void icd_chinh_Validated(object sender, EventArgs e)
        {
            //if (icd_chinh.Text == "" && !cd_chinh.Enabled)
            //{
            //    cd_chinh.Text = "";
            //    return;
            //}
            //else if (icd_chinh.Text != "")//s_icd_chinh
            //{
            //    cd_chinh.Text = m.get_vviet(icd_chinh.Text);
            //    if (cd_chinh.Text == "" && icd_chinh.Text != "")
            //    {
            //        frmDMICD10 f = new frmDMICD10(m, "icd10", icd_chinh.Text, cd_chinh.Text, true);
            //        f.ShowDialog();
            //        if (f.mICD != "")
            //        {
            //            cd_chinh.Text = f.mTen;
            //            icd_chinh.Text = f.mICD;
            //        }
            //    }
            //    //s_icd_chinh=icd_chinh.Text;
            //}
        }

        private void cd_chinh_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.ActiveControl == cd_chinh)
                {
                    //if (icd_chinh.Text == "")
                    //{
                    Filt_ICD(cd_chinh.Text);
                    listICD.BrowseToICD10(cd_chinh, icd_chinh, solan, cd_chinh.Location.X, cd_chinh.Location.Y + cd_chinh.Height + 20, cd_chinh.Width + cd_chinh.Width + 2, cd_chinh.Height);
                    //listICD.BrowseToToathuoc(cd_chinh, icd_chinh, txtchandoanvachidinh, icd_chinh.Width + icd_chinh.Width + cd_chinh.Width);
                    //}
                }
            }
            catch { }
        }

        private void Filt_ICD(string ten)
        {
            try
            {
                CurrencyManager cm = (CurrencyManager)BindingContext[listICD.DataSource];
                DataView dv = (DataView)cm.List;
                dv.RowFilter = "ten like '%" + ten.Trim() + "%'";
            }
            catch { }
        }

        private void cd_chinh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up) listICD.Focus();
            else if (e.KeyCode == Keys.Enter)
            {
                if (listICD.Visible) listICD.Focus();
                else SendKeys.Send("{Tab}{Home}"); butThem.Focus();
            }
        }

        private void butboqua_Click(object sender, EventArgs e)
        {
            status_moi = 0;
            ena_object(false);
            loadgrid(0);
            mabn_Validated(sender, e);
        }

        private void butluu_Click(object sender, EventArgs e)
        {
            if (!kiemtra()) return;
            if (s_ngay == "" || s_ngay == null) s_ngay = m.ngayhienhanh_server;
            xxx = user + m.mmyy(s_ngay);
            l_id = l_maql;
            string time_xuathienpu = timexuathienpu.Value.ToString() + " " + cbdonvitimexuathienpu.SelectedItem.ToString();
            int mdopu =0,kqxutripu=0;
            if (chktuvong_md.Checked)
                mdopu = 1;
            else if (chkdedoa_md.Checked)
                mdopu = 2;
            else if (chknhapnamvien_md.Checked)
                mdopu = 3;
            else if (chktantat_md.Checked)
                mdopu = 4;
            else if (chkditat_md.Checked)
                mdopu = 5;
            else if (chkkhongngtrong_md.Checked)
                mdopu = 6;
            //check ket qua sau khi xu tri phan ung
            if (chkdangphuchoi.Checked)
                kqxutripu = 4;
            else if(chkkhongxacdinh.Checked)
                kqxutripu = 7;
            else if(chkphuchoicodichung.Checked)
                kqxutripu = 5;
            else if(chkhoiphuckhongdichung.Checked)
                kqxutripu = 6;
            else if(chkkhongphuchoi.Checked)
                kqxutripu = 3;
            else if(chkchetdoADR.Checked)
                kqxutripu = 1;
            else if(chkchetkhonglienquanthuoc.Checked)
                kqxutripu = 2;

            if (!m.upd_phanungthuoc_adr(l_id, mabn.Text, l_maql, l_mavaovien, msbcdonvi.Text, msbctt.Text,
                (cannang.Text != "") ? double.Parse(cannang.Text) : 0, (chieucao.Text != "") ? double.Parse(chieucao.Text) : 0,
                ngaypu.Text, txtmotapu.Text, "", "",0, "", txtbenhsu.Text, i_userid,
                txtngaybc.Text.Substring(0, 10) + " 00:00", (chklandau.Checked) ? 1 : (chkbosung.Checked) ? 2 : 0,s_xetnghiem,time_xuathienpu,mdopu,kqxutripu))
            {
                MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin phản ứng thuốc !"), LibMedi.AccessData.Msg);
                return;
            }

            try
            {
                //m.execute_data("delete from " + user + ".thuocnghingo_adr where id=" + l_id);
                if (dsthuoc.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow r in dsthuoc.Tables[0].Rows)
                    {
                        if (!m.upd_thuocnghingo_adr(l_id, int.Parse(r["stt"].ToString()), int.Parse(r["mabd"].ToString()), r["cachdung"].ToString(),
                            int.Parse(r["solan"].ToString()), r["lydodungthuoc"].ToString(),r["ngay"].ToString().Trim().Trim(':').Trim().Trim('/').Trim(), 
                            r["ngayket"].ToString().Trim().Trim(':').Trim().Trim('/').Trim(), r["losx"].ToString(),int.Parse(r["caithien"].ToString()),int.Parse(r["taiphanung"].ToString()),int.Parse(r["moilan"].ToString()), i_userid))
                        {
                            MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin nghi ngờ thuốc !"), LibMedi.AccessData.Msg);
                            return;
                        }
                    }
                }
            }
            catch { }
            try
            {
                m.execute_data("delete from " + user + ".thuocsudungdongthoi where id=" + l_id);
                if (dsthuoc.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow r in dsthuocsddongthoi.Tables[0].Rows)
                    {
                        //upd_thuocsudungdongthoi
                        if (!m.upd_thuocsudungdongthoi(l_id, int.Parse(r["stt"].ToString()), int.Parse(r["mabd"].ToString()), r["ngay"].ToString().Trim().Trim(':').Trim().Trim('/').Trim(),
                            r["ngayket"].ToString().Trim().Trim(':').Trim().Trim('/').Trim(), i_userid))
                        {
                            MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin nghi ngờ thuốc !"), LibMedi.AccessData.Msg);
                            return;
                        }
                    }
                }
            }
            catch { }

            int chkngungthuoc_tientrien = 0, chkngungthuoc_dieutri = 0, chksudung_tientrien = 0, chksudung_dieutri = 0;
            if (chkngungthuoc_tientrientot.Checked) chkngungthuoc_tientrien = 1;
            if (chkngungthuoc_khongtientrien.Checked) chkngungthuoc_tientrien = 2;
            if (chkngungthuoc_dieutritiep.Checked) chkngungthuoc_dieutri = 1;
            if (chkngungthuoc_khongbiet.Checked) chkngungthuoc_dieutri = 2;
            if (chksdthuockhac_tientrientot.Checked) chksudung_tientrien = 1;
            if (chksdthuockhac_khongtientrien.Checked) chksudung_tientrien = 2;
            if (chksdthuockhac_dieutritiep.Checked) chksudung_dieutri = 1;
            if (chksdthuockhac_khongbiet.Checked) chksudung_dieutri = 2;
            //
            int kq_ADR = 0;
            if (chkhoiphuckhongdichung.Checked) kq_ADR = 1;
            else if (chkphuchoicodichung.Checked) kq_ADR = 2;
            else if (chkkhongphuchoi.Checked) kq_ADR = 3;
            else if (chkchetdoADR.Checked) kq_ADR = 4;
            else if (chkchetkhonglienquanthuoc.Checked) kq_ADR = 5;
            else if (chkkhongxacdinh.Checked) kq_ADR = 6;
            //
            int thamdinh_ADR_yte = 0;
            string thangthamdinh_ADR_chuyengia = "";
            if (chkchacchan_yte.Checked) thamdinh_ADR_yte = 1;
            else if (chkcokhanang_yte.Checked) thamdinh_ADR_yte = 2;
            else if (chkcothe_yte.Checked) thamdinh_ADR_yte = 3;
            else if (chkkhongchacchan_yte.Checked) thamdinh_ADR_yte = 4;
            else if (chkchuaphanloai.Checked) thamdinh_ADR_yte = 5;
            else if (chkkhongthephanloai.Checked) thamdinh_ADR_yte = 6;
            else if (chkkhac_thamdinh.Checked) thamdinh_ADR_yte = 7;
            if (ThangWho.Checked) thangthamdinh_ADR_chuyengia = "1";
            else if (ThangNaranjo.Checked) thangthamdinh_ADR_chuyengia = "2";
            else if (Thangkhac.Checked) thangthamdinh_ADR_chuyengia = "3";
            if (!m.upd_xutri_adr(l_id, txtngungdungthuoc.Text, chkngungthuoc_tientrien, chkngungthuoc_dieutri,
                txtsdthuockhac.Text, chksudung_tientrien, chksudung_dieutri, kq_ADR, txtbinhluanbacsi.Text,
                thamdinh_ADR_yte, thangthamdinh_ADR_chuyengia, "", i_userid))
            {
                MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin xử trí thuốc !"), LibMedi.AccessData.Msg);
                return;
            }
            if (sender != null)
            {
                ena_object(false);
                butmoi.Focus();
            }
            //write xml thong tin nguoi bao cao
            try
            {
                DataSet write_xml = new DataSet();
                DataTable dt_xml = new DataTable();
                dt_xml.Columns.Add("ten", typeof(string));
                dt_xml.Columns.Add("sodt", typeof(string));
                dt_xml.Columns.Add("diachi", typeof(string));
                dt_xml.Columns.Add("ngaybc", typeof(string));
                dt_xml.Columns.Add("chucvu", typeof(string));
                dt_xml.Columns.Add("sofax", typeof(string));
                dt_xml.Columns.Add("kyten", typeof(string));
                dt_xml.Columns.Add("dangbc", typeof(string));
                DataRow nr = dt_xml.NewRow();
                nr["ten"] = txtten.Text;
                nr["sodt"] = txtsodienthoai.Text;
                nr["diachi"] = txtEmail.Text;
                nr["ngaybc"] = txtngaybc.Text;
                nr["chucvu"] = txtchucvu.Text;
                //nr["sofax"] = txtsofax.Text;
                nr["kyten"] = txtkyten.Text;
                if (chklandau.Checked) nr["dangbc"] = "1";
                else if (chkbosung.Checked) nr["dangbc"] = "2";
                else nr["dangbc"] = "0";
                dt_xml.Rows.Add(nr);
                write_xml.Tables.Add(dt_xml);
                write_xml.WriteXml("..//..//..//xml//thongtinnguoibaocao.xml", XmlWriteMode.WriteSchema);
            }
            catch { }
            //end write xml
        }

        private void mabn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{TAB}");
        }

        private void chieucao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{TAB}");
        }

        private void cannang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{TAB}");
        }

        private void ngay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{TAB}");
        }

        private void ngaypu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{TAB}");
        }

        private void msbcdonvi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{TAB}");
        }

        private void msbctt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{TAB}");
        }

        private void diachi_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter) SendKeys.Send("{TAB}");
        }

        private void txtmotapu_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter) SendKeys.Send("{TAB}");
        }

        private void icd_chinh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{TAB}");
        }

        private void txtchandoanvachidinh_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter) SendKeys.Send("{TAB}");
        }

        private void txttaisdthuoc_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter) SendKeys.Send("{TAB}");
        }

        private void txtthuocdungdongthoi_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter) SendKeys.Send("{TAB}");
        }

        private void txtbenhsu_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter) SendKeys.Send("{TAB}");
        }

        private void txtngungdungthuoc_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter) SendKeys.Send("{TAB}");
        }

        private void txtsdthuockhac_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter) SendKeys.Send("{TAB}");
        }

        private void txtbinhluanbacsi_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter) SendKeys.Send("{TAB}");
        }

        private void txtykienchuyengia_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter) SendKeys.Send("{TAB}");
        }

        private void txtten_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter) SendKeys.Send("{TAB}");
        }

        private void txtsodienthoai_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter) SendKeys.Send("{TAB}");
        }

        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            // if (e.KeyCode == Keys.Enter) SendKeys.Send("{TAB}");
        }

        private void txtngaybc_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter) SendKeys.Send("{TAB}");
        }

        private void textBox16_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter) SendKeys.Send("{TAB}");
        }

        private void textBox15_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter) SendKeys.Send("{TAB}");
        }

        private void textBox17_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter) SendKeys.Send("{TAB}");
        }

        private void butin_Click(object sender, EventArgs e)
        {
            DataSet ds_in = new DataSet();
            sql = "";
            sql = "select a.stt,a.caithien,a.taiphanung,a.lieudungmotlan,a.solantrongngay,a.lydodungthuoc,to_char(a.ngaybatdau,'dd/mm/yyyy') as ngaybatdau,to_char(a.ngayketthuc,'dd/mm/yyyy') as ngayketthuc,a.losx,d.ten as nhasx,nvl(b.ten,c.ten) as tenbd,b.duongdung,nvl(b.hamluong,c.hamluong) as hamluong ";
            sql += "from " + user + ".thuocnghingo_adr a left join " + user + ".d_dmbd b on a.mabd=b.id left join " + user + ".d_dmthuoc c on a.mabd=c.id left join " + user + ".d_dmnx d on b.madv=d.id ";
            sql += "where  a.id=" + l_maql + "";
            DataTable dt_in = new DataTable();
            dt_in = m.get_data(sql).Tables[0];
            dt_in.TableName = "thuocnghingo";
            ds_in.Tables.Add(dt_in.Copy());

            sql = "select to_char(a.ngaybatdau,'dd/mm/yyyy') as ngaybatdau,to_char(a.ngayketthuc,'dd/mm/yyyy') as ngayketthuc,nvl(b.ten,c.ten) as tenbd,nvl(b.hamluong,c.hamluong) as hamluong ";
            sql += "from " + user + ".thuocsudungdongthoi a left join " + user + ".d_dmbd b on a.mabd=b.id left join " + user + ".d_dmthuoc c on a.mabd=c.id ";
            sql += "where  a.id=" + l_maql + "";
            DataTable dt_in0 = new DataTable();
            dt_in0 = m.get_data(sql).Tables[0];
            dt_in0.TableName = "thuocsudungdongthoi";
            ds_in.Tables.Add(dt_in0.Copy());

            sql = "select a.*,to_char(a.ngayphanung,'dd/mm/yyyy')as ngayphanung1,b.*,c.hoten,d.dantoc,c.phai,to_char(c.ngaysinh,'dd/mm/yyyy')as ngaysinh,c.namsinh from " + user + ".phanungthuoc_adr a,";
            sql += "" + user + ".xutri_adr b," + user + ".btdbn c," + user + ".btddt d ";
            sql += "where a.id=b.id and a.mabn=c.mabn and c.madantoc=d.madantoc ";
            sql += " and a.mabn='" + mabn.Text.Trim() + "' and a.id=" + l_maql + "";
            DataTable dt_in1 = new DataTable();
            dt_in1 = m.get_data(sql).Tables[0];
            dt_in1.TableName = "chung";
            string[] s_xn;
            DataColumn ten_xn = new DataColumn();
            ten_xn.DataType = System.Type.GetType("System.String");
            ten_xn.ColumnName = "ten_xn";
            dt_in1.Columns.Add(ten_xn);
            foreach (DataRow r in dt_in1.Rows)
            {
                s_xn = r["xetnghiem"].ToString().Split('+');
                for (int i = 0; i < s_xn.Length; i++)
                {
                    DataRow r_xn = m.getrowbyid(m.get_data("select ten,id from " + user + ".v_giavp").Tables[0], "id=" + s_xn[i]);
                    if (r_xn != null)
                    {
                        if (i == s_xn.Length - 1)
                            r["ten_xn"] += " - " + r_xn["ten"].ToString();
                        else
                            r["ten_xn"] += " - " + r_xn["ten"].ToString() + "\n";
                    }
                }
            }
            ds_in.Tables.Add(dt_in1.Copy());
            DataSet read_ttbc = new DataSet();
            DataTable dt_in2 = new DataTable();
            try { read_ttbc.ReadXml("..//..//..//xml//thongtinnguoibaocao.xml", XmlReadMode.ReadSchema); }
            catch { }
            dt_in2 = read_ttbc.Tables[0].Copy();
            dt_in2.TableName = "thongtinbc";
            ds_in.Tables.Add(dt_in2.Copy());

            if (chkXML.Checked) ds_in.WriteXml("..//..//dataxml//phanungthuoc.xml", XmlWriteMode.WriteSchema);
            if (ds_in.Tables["chung"].Rows.Count > 0)
            {
                dllReportM.frmReport f = new dllReportM.frmReport(m, ds_in, "", "rptPhanungthuoc.rpt");
                f.ShowDialog();
            }
            if (ds_in.Tables["chung"].Rows.Count > 0)
            {
                dllReportM.frmReport f1 = new dllReportM.frmReport(m, ds_in, "", "rptPhanungthuoc1.rpt");
                f1.ShowDialog();
            }
        }
        string stt = "0";
        private void butThem_Click(object sender, EventArgs e)
        {
            if (cd_chinh.Text.Trim() == "" || icd_chinh.Text.Trim() == "") return;
            //stt = m.get_stt(dsthuoc.Tables[0]).ToString();
            if (icd_chinh.Text.Trim() == "") return;
            updrec_thuocnghingo(dsthuoc, l_id, int.Parse(icd_chinh.Text));
            dataGrid1.DataSource = dsthuoc.Tables[0];
            emp_item();
            cd_chinh.Focus();
        }
        private void emp_item()
        {
            stt = m.get_stt(dsthuoc.Tables[0]).ToString();
            cd_chinh.Text = "";
            thuocsddongthoi.Text = "";
            tenhc.Text = "";
            cbdonvitimexuathienpu.SelectedItem = "";
            timexuathienpu.Value = 0;
            soluong.Text = "";
            textBox1.Text = "";
            solan.Value = 1;
            moilan.Text = ""; 
            lydodungthuoc.Text = "";
            txtxetnghiem.Text = "";
            cbcaithien.SelectedIndex = 0;
            cbtaiphanung.SelectedIndex = 0;
        }
        public void updrec_thuocnghingo(DataSet ds, decimal id, int stt)
        {
            try
            {
                
                string exp = "mabd=" + stt;
                DataRow[] r = ds.Tables[0].Select(exp);
                int i_stt = m.get_stt(dsthuoc.Tables[0]);
                DataRow r1 = m.getrowbyid(dtthuoc, "id=" + stt);
                if (r.Length > 0)
                {
                    DataRow[] dr = ds.Tables[0].Select(exp);
                    dr[0]["stt"] = i_stt;
                    dr[0]["mabd"] = stt;// icd_chinh.Text;
                    dr[0]["tenbd"] = cd_chinh.Text;
                    dr[0]["hamluong"] = r1["dang"].ToString();
                    dr[0]["cachdung"] = textBox1.Text;
                    dr[0]["lydodungthuoc"] = lydodungthuoc.Text;
                    dr[0]["solan"] = solan.Value;
                    dr[0]["duongdung"] = "";
                    dr[0]["losx"] = "";
                    dr[0]["caithien"] = cbcaithien.SelectedIndex +1 ;
                    dr[0]["taiphanung"] = cbtaiphanung.SelectedIndex +1 ;
                    dr[0]["moilan"] = moilan.Text;
                    //dr[0]["soluong"] = (soluong.Text != "") ? decimal.Parse(soluong.Text) : 0;
                    dr[0]["ten"] = "";
                    dr[0]["ngay"] = ngaybatdau;//DateTime.Now.Date.ToString("dd/MM/yyyy hh:mm");
                    dr[0]["ngayket"] = ngayketthuc;//DateTime.Now.Date.ToString("dd/MM/yyyy hh:mm");
                }
                else
                {
                    DataRow nrow = ds.Tables[0].NewRow();
                    nrow["stt"] = i_stt;
                    nrow["mabd"] = stt;// icd_chinh.Text;
                    nrow["tenbd"] = cd_chinh.Text;
                    nrow["hamluong"] = r1["dang"].ToString();
                    nrow["cachdung"] = textBox1.Text;
                    nrow["lydodungthuoc"] = lydodungthuoc.Text;
                    nrow["solan"] = solan.Value;
                    nrow["duongdung"] = "";
                    nrow["losx"] = "";
                    nrow["caithien"] = cbcaithien.SelectedIndex +1 ;
                    nrow["taiphanung"] = cbtaiphanung.SelectedIndex + 1;
                    nrow["moilan"] = moilan.Text;
                    nrow["ten"] = "";
                    nrow["ngay"] = ngaybatdau;//DateTime.Now.Date.ToString("dd/MM/yyyy hh:mm");
                    nrow["ngayket"] = ngayketthuc;//DateTime.Now.Date.ToString("dd/MM/yyyy hh:mm");
                    ds.Tables[0].Rows.Add(nrow);
                }
            }
            catch { }
        }
        public void updrec_thuocsddongthoi(DataSet ds, decimal id, int stt)//, int mabd, string lieudungmotlan
        //, string solantrongngay, string ngaybatdau, string ngayketthuc, string losx)
            {
            try
            {

                string exp = "mabd=" + stt;
                DataRow[] r = ds.Tables[0].Select(exp);
                int i_stt = m.get_stt(dsthuocsddongthoi.Tables[0]);
                DataRow r1 = m.getrowbyid(dtthuoc, "id=" + stt);
                if (r.Length > 0)
                {
                    DataRow[] dr = ds.Tables[0].Select(exp);
                    dr[0]["stt"] = i_stt;
                    dr[0]["mabd"] = stt;// icd_chinh.Text;
                    dr[0]["tenbd"] = thuocsddongthoi.Text;
                    dr[0]["hamluong"] = r1["dang"].ToString();
                    dr[0]["ten"] = "";
                    dr[0]["ngay"] = ngaybatdau;//DateTime.Now.Date.ToString("dd/MM/yyyy hh:mm");
                    dr[0]["ngayket"] = ngayketthuc;//DateTime.Now.Date.ToString("dd/MM/yyyy hh:mm");
                }
                else
                {
                    DataRow nrow = ds.Tables[0].NewRow();
                    nrow["stt"] = i_stt;
                    nrow["mabd"] = stt;// icd_chinh.Text;
                    nrow["tenbd"] = thuocsddongthoi.Text;
                    nrow["hamluong"] = r1["dang"].ToString();
                    nrow["ten"] = "";
                    nrow["ngay"] = ngaybatdau;//DateTime.Now.Date.ToString("dd/MM/yyyy hh:mm");
                    nrow["ngayket"] = ngayketthuc;//DateTime.Now.Date.ToString("dd/MM/yyyy hh:mm");
                    ds.Tables[0].Rows.Add(nrow);
                }
            }
            catch { }
        }
        private void loadgrid(decimal _maql)
        {
            sql = "";
            sql = "select a.mabd,nvl(c.ten,e.ten) as tenbd,a.stt,a.lydodungthuoc,nvl(c.hamluong,e.hamluong) as hamluong,lieudungmotlan as cachdung,solantrongngay as solan,moilan,";
            sql += "nvl(c.duongdung,e.duongdung) as duongdung,to_char(a.ngaybatdau,'dd/mm/yyyy hh24:mi') as ngay, ";
            sql += "to_char(a.ngayketthuc,'dd/mm/yyyy hh24:mi') as ngayket,a.losx,nvl(d.ten,f.ten) as ten,a.caithien,a.taiphanung ";
            sql += "from " + user + ".thuocnghingo_adr a," + user + ".phanungthuoc_adr b," + user + ".d_dmbd c," + user + ".d_dmhang d," + user + ".d_dmthuoc e ," + user + ".d_dmhang f ";
            sql += "where a.id=b.id and a.mabd=c.id(+) and a.mabd=e.id(+) and c.mahang=d.id(+) and e.mahang=f.id(+) and b.maql = " + l_maql ;
            dsthuoc = m.get_data(sql);
            dataGrid1.DataSource = dsthuoc.Tables[0];
            try
            {
                cbcaithien.SelectedIndex = int.Parse(dsthuoc.Tables[0].Rows[0]["caithien"].ToString());
                cbtaiphanung.SelectedIndex = int.Parse(dsthuoc.Tables[0].Rows[0]["taiphanung"].ToString());
                string sql_bd = "select to_char(ngay,'dd/mm/yyyy hh24:mi') as ngay from " + xxx + ".benhanpk where maql=" + l_maql ;
                sql_bd += " union all select to_char(ngay,'dd/mm/yyyy hh24:mi') as ngay from " + user + ".benhanngtr where maql=" + l_maql;
                sql_bd += " union all select to_char(ngay,'dd/mm/yyyy hh24:mi') as ngay from " + xxx + ".benhancc where maql=" + l_maql ;
                sql_bd += " union all select to_char(ngay,'dd/mm/yyyy hh24:mi') as ngay from " + user + ".benhandt where maql=" + l_maql ;//gam 13/03/2012
                ngaybatdau = m.get_data(sql_bd).Tables[0].Rows[0][0].ToString();
                string sql_kt = "select to_char(ngay,'dd/mm/yyyy hh24:mi') as ngayket from " + xxx + ".benhanpk where maql=" + l_maql;
                sql_kt += " union all select to_char(ngayrv,'dd/mm/yyyy hh24:mi') as ngayket from " + user + ".benhanngtr where maql=" + l_maql;
                sql_kt += " union all select to_char(ngay,'dd/mm/yyyy hh24:mi') as ngayket from " + xxx + ".benhancc where maql=" + l_maql;
                sql_kt += " union all select to_char(b.ngay,'dd/mm/yyyy hh24:mi') as ngayket from medibv.benhandt a inner join medibv.xuatvien b on a.maql=b.maql and a.maql=" + l_maql;
                ngayketthuc = m.get_data(sql_kt).Tables[0].Rows[0][0].ToString();
            }
            catch { }
        }

        private void loadgrid1(decimal _maql)
        {
            sql = "";
            sql = "select a.mabd,nvl(c.ten,e.ten) as tenbd,a.stt,nvl(c.hamluong,e.hamluong) as hamluong,";
            sql += "to_char(a.ngaybatdau,'dd/mm/yyyy hh24:mi') as ngay, ";
            sql += "to_char(a.ngayketthuc,'dd/mm/yyyy hh24:mi') as ngayket,nvl(d.ten,f.ten) as ten ";
            sql += "from " + user + ".thuocsudungdongthoi a," + user + ".phanungthuoc_adr b," + user + ".d_dmbd c," + user + ".d_dmhang d," + user + ".d_dmthuoc e ," + user + ".d_dmhang f ";
            sql += "where a.id=b.id and a.mabd=c.id(+) and a.mabd=e.id(+) and c.mahang=d.id(+) and e.mahang=f.id(+) and b.maql = " + l_maql + "";
            dsthuocsddongthoi = m.get_data(sql);
            dataGrid2.DataSource = dsthuocsddongthoi.Tables[0];
            try
            {
                string sql_bd = "select to_char(ngay,'dd/mm/yyyy hh24:mi') as ngay from " + xxx + ".benhanpk where maql=" + l_maql + "";
                sql_bd += " union all select to_char(ngay,'dd/mm/yyyy hh24:mi') as ngay from " + user + ".benhanngtr where maql=" + l_maql + "";
                sql_bd += " union all select to_char(ngay,'dd/mm/yyyy hh24:mi') as ngay from " + xxx + ".benhancc where maql=" + l_maql + "";
                ngaybatdau = m.get_data(sql_bd).Tables[0].Rows[0][0].ToString();
                string sql_kt = "select to_char(ngay,'dd/mm/yyyy hh24:mi') as ngayket from " + xxx + ".benhanpk where maql=" + l_maql + "";
                sql_kt += " union all select to_char(ngayrv,'dd/mm/yyyy hh24:mi') as ngayket from " + user + ".benhanngtr where maql=" + l_maql + "";
                sql_kt += " union all select to_char(ngay,'dd/mm/yyyy hh24:mi') as ngayket from " + xxx + ".benhancc where maql=" + l_maql + "";
                ngayketthuc = m.get_data(sql_kt).Tables[0].Rows[0][0].ToString();
            }
            catch { }
        }
        private void listICD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                try
                {
                    DataRow r = m.getrowbyid(dtthuoc, "id=" + decimal.Parse(icd_chinh.Text));
                    if (r != null)
                    {
                        tenhc.Text = r["tenhc"].ToString();
                        //textBox1.Text = r["ten"].ToString();
                        if (!bDanhmuc) textBox1.Text = r["cachdung"].ToString();
                    }
                }
                catch { }
            }
        }
        private void gc_cachdung()
        {
            if (moilan.Text != "")
            {
                DataRow r1 = m.getrowbyid(dtthuoc, "id=" + decimal.Parse(icd_chinh.Text));
                if (r1 != null)
                {
                    textBox1.Text = r1["duongdung"].ToString().Trim() + " " + lan.Change_language_MessageText("ngày") + " " + solan.Value.ToString() + " " + lan.Change_language_MessageText("lần , lần") + " " + moilan.Text.ToString().Trim() + " " + r1["dang"].ToString().Trim();
                }
                //decimal sl = Math.Max(songay.Value, 1) * solan.Value * decimal.Parse(moilan.Text);
                decimal sl = solan.Value * decimal.Parse(moilan.Text);
                soluong.Text = sl.ToString();
                soluong.Refresh();
            }
        }
        private void solan_Validated(object sender, EventArgs e)
        {
            gc_cachdung();
        }

        private void moilan_Validated(object sender, EventArgs e)
        {
            gc_cachdung();
        }

        private void solan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void butdelete_Click(object sender, EventArgs e)
        {
            if (butsua.Enabled == false)
            {
                string aa = dataGrid1[dataGrid1.CurrentRowIndex, 0].ToString();
                DataRow dr = m.getrowbyid(dsthuoc.Tables[0], "mabd=" + dataGrid1[dataGrid1.CurrentRowIndex, 0].ToString() + "");
                if (dr != null) dsthuoc.Tables[0].Rows.Remove(dr);
                emp_item();
            }
        }

        private void chkngungthuoc_tientrientot_CheckedChanged(object sender, EventArgs e)
        {
            if (chkngungthuoc_tientrientot.Checked)
            {
                chkngungthuoc_khongtientrien.Checked = false;
                chkngungthuoc_khongbiet.Checked = false;
                chkngungthuoc_dieutritiep.Checked = false;
            }
        }

        private void chkngungthuoc_khongtientrien_CheckedChanged(object sender, EventArgs e)
        {
            if (chkngungthuoc_khongtientrien.Checked)
            {
                chkngungthuoc_tientrientot.Checked = false;
                chkngungthuoc_khongbiet.Checked = false;
                chkngungthuoc_dieutritiep.Checked = false;
            }
        }

        private void chkngungthuoc_dieutritiep_CheckedChanged(object sender, EventArgs e)
        {
            if (chkngungthuoc_dieutritiep.Checked)
            {
                chkngungthuoc_khongtientrien.Checked = false;
                chkngungthuoc_khongbiet.Checked = false;
                chkngungthuoc_tientrientot.Checked = false;
            }
        }

        private void chkngungthuoc_khongbiet_CheckedChanged(object sender, EventArgs e)
        {
            if (chkngungthuoc_khongbiet.Checked)
            {
                chkngungthuoc_khongtientrien.Checked = false;
                chkngungthuoc_tientrientot.Checked = false;
                chkngungthuoc_dieutritiep.Checked = false;
            }
        }

        private void chksdthuockhac_tientrientot_CheckedChanged(object sender, EventArgs e)
        {
            if (chksdthuockhac_tientrientot.Checked)
            {
                chksdthuockhac_khongtientrien.Checked = false;
                chksdthuockhac_khongbiet.Checked = false;
                chksdthuockhac_dieutritiep.Checked = false;
            }
        }

        private void chksdthuockhac_khongtientrien_CheckedChanged(object sender, EventArgs e)
        {
            if (chksdthuockhac_khongtientrien.Checked)
            {
                chksdthuockhac_tientrientot.Checked = false;
                chksdthuockhac_khongbiet.Checked = false;
                chksdthuockhac_dieutritiep.Checked = false;
            }
        }

        private void chksdthuockhac_dieutritiep_CheckedChanged(object sender, EventArgs e)
        {
            if (chksdthuockhac_dieutritiep.Checked)
            {
                chksdthuockhac_tientrientot.Checked = false;
                chksdthuockhac_khongbiet.Checked = false;
                chksdthuockhac_khongtientrien.Checked = false;
            }
        }

        private void chksdthuockhac_khongbiet_CheckedChanged(object sender, EventArgs e)
        {
            if (chksdthuockhac_khongbiet.Checked)
            {
                chksdthuockhac_tientrientot.Checked = false;
                chksdthuockhac_dieutritiep.Checked = false;
                chksdthuockhac_khongtientrien.Checked = false;
            }
        }

        private void chkhoiphuckhongdichung_CheckedChanged(object sender, EventArgs e)
        {
            if (chkhoiphuckhongdichung.Checked)
            {
                chkkhongphuchoi.Checked = false;
                chkphuchoicodichung.Checked = false;
                chkchetdoADR.Checked = false;
                chkchetkhonglienquanthuoc.Checked = false;
                chkkhongxacdinh.Checked = false;
                chkdangphuchoi.Checked = false;
            }
        }

        private void chkphuchoicodichung_CheckedChanged(object sender, EventArgs e)
        {
            if (chkphuchoicodichung.Checked)
            {
                chkkhongphuchoi.Checked = false;
                chkhoiphuckhongdichung.Checked = false;
                chkchetdoADR.Checked = false;
                chkchetkhonglienquanthuoc.Checked = false;
                chkkhongxacdinh.Checked = false;
                chkdangphuchoi.Checked = false;
            }
        }

        private void chkkhongphuchoi_CheckedChanged(object sender, EventArgs e)
        {
            if (chkkhongphuchoi.Checked)
            {
                chkphuchoicodichung.Checked = false;
                chkhoiphuckhongdichung.Checked = false;
                chkchetdoADR.Checked = false;
                chkchetkhonglienquanthuoc.Checked = false;
                chkkhongxacdinh.Checked = false;
                chkdangphuchoi.Checked = false;
            }
        }

        private void chkchetdoADR_CheckedChanged(object sender, EventArgs e)
        {
            if (chkchetdoADR.Checked)
            {
                chkphuchoicodichung.Checked = false;
                chkhoiphuckhongdichung.Checked = false;
                chkkhongphuchoi.Checked = false;
                chkchetkhonglienquanthuoc.Checked = false;
                chkkhongxacdinh.Checked = false;
                chkdangphuchoi.Checked = false;
            }
        }

        private void chkchetkhonglienquanthuoc_CheckedChanged(object sender, EventArgs e)
        {
            if (chkchetkhonglienquanthuoc.Checked)
            {
                chkphuchoicodichung.Checked = false;
                chkhoiphuckhongdichung.Checked = false;
                chkkhongphuchoi.Checked = false;
                chkchetdoADR.Checked = false;
                chkkhongxacdinh.Checked = false;
                chkdangphuchoi.Checked = false;

            }
        }

        private void chkkhongxacdinh_CheckedChanged(object sender, EventArgs e)
        {
            if (chkkhongxacdinh.Checked)
            {
                chkphuchoicodichung.Checked = false;
                chkhoiphuckhongdichung.Checked = false;
                chkkhongphuchoi.Checked = false;
                chkchetdoADR.Checked = false;
                chkchetkhonglienquanthuoc.Checked = false;
                chkdangphuchoi.Checked = false;
            }
        }

        private void chkchacchan_yte_CheckedChanged(object sender, EventArgs e)
        {
            if (chkchacchan_yte.Checked)
            {
                chkkhongthephanloai.Checked = false;
                chkchuaphanloai.Checked = false;
                chkcokhanang_yte.Checked = false;
                chkcothe_yte.Checked = false;
                chkkhongchacchan_yte.Checked = false;
            }
        }

        private void chkcokhanang_yte_CheckedChanged(object sender, EventArgs e)
        {
            if (chkcokhanang_yte.Checked)
            {
                chkkhongthephanloai.Checked = false;
                chkchuaphanloai.Checked = false;
                chkchacchan_yte.Checked = false;
                chkcothe_yte.Checked = false;
                chkkhongchacchan_yte.Checked = false;
            }
        }

        private void chkcothe_yte_CheckedChanged(object sender, EventArgs e)
        {
            if (chkcothe_yte.Checked)
            {
                chkchuaphanloai.Checked = false;
                chkkhongthephanloai.Checked = false;
                chkchacchan_yte.Checked = false;
                chkcokhanang_yte.Checked = false;
                chkkhongchacchan_yte.Checked = false;
            }
        }

        private void chkkhongchacchan_yte_CheckedChanged(object sender, EventArgs e)
        {
            if (chkkhongchacchan_yte.Checked)
            {
                chkchacchan_yte.Checked = false;
                chkcokhanang_yte.Checked = false;
                chkcothe_yte.Checked = false;
                chkchuaphanloai.Checked = false;
                chkkhongthephanloai.Checked = false;
            }
        }

        private void chklandau_CheckedChanged(object sender, EventArgs e)
        {
            if (chklandau.Checked)
                chkbosung.Checked = false;
        }

        private void chkbosung_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbosung.Checked)
                chklandau.Checked = false;
        }

        private void refresh_selected()
        {
            cannang.Text = "";
            chieucao.Text = "";
            msbcdonvi.Text = "";
            msbctt.Text = "";
            ngaypu.Text = "";
            txtmotapu.Text = "";
            txtbenhsu.Text = "";
            txtngungdungthuoc.Text = "";
            chkngungthuoc_tientrientot.Checked = false;
            chkngungthuoc_khongtientrien.Checked = false;
            chkngungthuoc_dieutritiep.Checked = false;
            chkngungthuoc_khongbiet.Checked = false;
            txtsdthuockhac.Text = "";
            chksdthuockhac_tientrientot.Checked = false;
            chksdthuockhac_khongtientrien.Checked = false;
            chksdthuockhac_dieutritiep.Checked = false;
            chksdthuockhac_khongbiet.Checked = false;
            chkhoiphuckhongdichung.Checked = false;
            chkphuchoicodichung.Checked = false;
            chkdangphuchoi.Checked = false;
            chkkhongphuchoi.Checked = false;
            chkchetdoADR.Checked = false;
            chkchetkhonglienquanthuoc.Checked = false;
            chkkhongxacdinh.Checked = false;
            txtbinhluanbacsi.Text = "";
            chkchacchan_yte.Checked = false;
            chkcokhanang_yte.Checked = false;
            chkcothe_yte.Checked = false;
            chkkhongchacchan_yte.Checked = false;
            chkchuaphanloai.Checked = false;
            chkkhongthephanloai.Checked = false;
            chkkhac_thamdinh.Checked = false;
            ThangWho.Checked = false;
            ThangNaranjo.Checked = false;
            Thangkhac.Checked = false;
        }
        private void ngay_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ActiveControl == ngay || sender == null)
            {
                refresh_selected();
                l_maql = decimal.Parse(ngay.SelectedValue.ToString());
                l_id = l_maql;
                int i = 0;
                string s_chidinh,ten_xn,sql1;
                string[] s_xnghiem;
                string s_ngay = "", s_chieucao = "", s_cannang = "", s_benhsu = "", s_msbcdonvi = "", s_msbctt = "";
                foreach (DataRow r2 in ds.Tables[0].Select("maql=" + l_maql))
                {
                    s_chidinh = "";
                    foreach (DataRow r0 in m.get_data("select b.ten from " + xxx + ".v_chidinh a," + user + ".v_giavp b where a.mavp=b.id and a.maql=" + l_maql).Tables[0].Rows)
                    {
                        s_chidinh += r0["ten"].ToString() + "-";
                    }
                    s_chidinh.Trim('-');
                    s_chidinh = r2["chandoan"].ToString() + ".\n +" + s_chidinh;
                    s_benhsu = r2["chandoan"].ToString();
                    foreach (DataRow r1 in m.get_data("select chieucao,cannang from " + xxx + ".bavv_dausinhton where maql=" + l_maql).Tables[0].Rows)
                    {
                        s_chieucao = r1["chieucao"].ToString();
                        s_cannang = r1["cannang"].ToString();
                    }
                    if (i == 0)
                    {
                        //txtchandoanvachidinh.Text = s_chidinh.Trim('+');
                        chieucao.Text = s_chieucao;
                        cannang.Text = s_cannang;
                        s_ngay = r2["ngayvv"].ToString();
                        txtbenhsu.Text = s_benhsu;
                    }
                    i++;
                }
                hoten.Enabled = false;
                namsinh.Enabled = false;
                phai.Enabled = false;
                dantoc.Enabled = false;
                diachi.Enabled = false;
                chieucao.Enabled = false;
                cannang.Enabled = false;
                sql = "select id,ngayphanung,msbcdonvi,msbctt,cannang,chieucao,xetnghiem,";
                sql += "to_char(ngayphanung,'dd/mm/yyyy hh24:mi') as ngaypu,motaphanung,chandoandieutri,";
                sql += "taisudungthuoc,trieuchungcu,thuocsudungdongthoi,benhsulienquan,thoigianxuathienphanung,mucdopu,kqxutripu ";
                sql += "from " + user + ".phanungthuoc_adr where id=" + l_id + " order by ngayphanung";
                if (m.get_data(sql).Tables[0].Rows.Count < 1)
                {
                    emp_item();
                }
                else
                {
                    txtxetnghiem.Text = "";
                    foreach (DataRow r1 in m.get_data(sql).Tables[0].Rows)
                    {
                        s_xnghiem = r1["xetnghiem"].ToString().Split('+');
                        cannang.Text = r1["cannang"].ToString();
                        chieucao.Text = r1["chieucao"].ToString();
                        msbcdonvi.Text = r1["msbcdonvi"].ToString();
                        msbctt.Text = r1["msbctt"].ToString();
                        ngaypu.Text = r1["ngaypu"].ToString();
                        txtmotapu.Text = r1["motaphanung"].ToString();
                        txtbenhsu.Text = r1["benhsulienquan"].ToString();
                        string[] s_timexhpu = r1["thoigianxuathienphanung"].ToString().Split(' ');
                        timexuathienpu.Value = decimal.Parse(s_timexhpu[0]);
                        cbdonvitimexuathienpu.SelectedItem = s_timexhpu[1];
                        for (int j = 0; j < s_xnghiem.Length; j++)
                        {

                            DataRow r_xn = m.getrowbyid(m.get_data("select ten,id from " + user + ".v_giavp").Tables[0],"id="+s_xnghiem[j]);
                            if (r_xn != null)
                            {
                                if (j == s_xnghiem.Length - 1)
                                    txtxetnghiem.Text += " - " + r_xn["ten"].ToString();
                                else
                                    txtxetnghiem.Text += " - " + r_xn["ten"].ToString() + "\n";
                            }
                        }
                        if (r1["mucdopu"].ToString() == "1") chktuvong_md.Checked = true;
                        else if (r1["mucdopu"].ToString() == "2") chkdedoa_md.Checked = true;
                        else if (r1["mucdopu"].ToString() == "3") chknhapnamvien_md.Checked = true;
                        else if (r1["mucdopu"].ToString() == "4") chktantat_md.Checked = true;
                        else if (r1["mucdopu"].ToString() == "5") chkditat_md.Checked = true;
                        else if (r1["mucdopu"].ToString() == "6") chkkhongngtrong_md.Checked = true;
                        else chktuvong_md.Checked = chkdedoa_md.Checked = chknhapnamvien_md.Checked = chktantat_md.Checked = chkditat_md.Checked = chkkhongngtrong_md.Checked = false;
                        if (r1["kqxutripu"].ToString() == "1") chkchetdoADR.Checked = true;
                        else if (r1["kqxutripu"].ToString() == "2") chkchetkhonglienquanthuoc.Checked = true;
                        else if (r1["kqxutripu"].ToString() == "3") chkkhongphuchoi.Checked = true;
                        else if (r1["kqxutripu"].ToString() == "4") chkdangphuchoi.Checked = true;
                        else if (r1["kqxutripu"].ToString() == "5") chkphuchoicodichung.Checked = true;
                        else if (r1["kqxutripu"].ToString() == "6") chkhoiphuckhongdichung.Checked = true;
                        else if (r1["kqxutripu"].ToString() == "7") chkkhongxacdinh.Checked = true;
                        else chkchetdoADR.Checked = chkchetkhonglienquanthuoc.Checked = chkkhongphuchoi.Checked = chkdangphuchoi.Checked = chkphuchoicodichung.Checked = chkhoiphuckhongdichung.Checked = chkkhongxacdinh.Checked = false; 
                    }
                }
                DataRow nr = m.getrowbyid(ds.Tables[0], "maql=" + l_maql);
                if (nr != null)
                {
                    int i_loaiba = int.Parse(nr["loaiba"].ToString());
                    loadgrid(l_maql);
                    loadgrid1(l_maql);
                }
                foreach (DataRow r2 in m.get_data("select * from " + user + ".xutri_adr where id=" + l_id+ "").Tables[0].Rows)
                {
                    txtngungdungthuoc.Text = r2["ngungdungthuoc"].ToString();
                    if (r2["ngung_tientrien"].ToString() == "1") chkngungthuoc_tientrientot.Checked = true;
                    else if (r2["ngung_tientrien"].ToString() == "2") chkngungthuoc_khongtientrien.Checked = true;
                    if (r2["ngung_dieutri"].ToString() == "1") chkngungthuoc_dieutritiep.Checked = true;
                    else if (r2["ngung_dieutri"].ToString() == "2") chkngungthuoc_khongbiet.Checked = true;
                    txtsdthuockhac.Text = r2["sudungthuockhac"].ToString();
                    if (r2["sudung_tientrien"].ToString() == "1") chksdthuockhac_tientrientot.Checked = true;
                    else if (r2["sudung_tientrien"].ToString() == "2") chksdthuockhac_khongtientrien.Checked = true;
                    if (r2["sudung_dieutri"].ToString() == "1") chksdthuockhac_dieutritiep.Checked = true;
                    else if (r2["sudung_dieutri"].ToString() == "2") chksdthuockhac_khongbiet.Checked = true;
                    if (r2["ketquaxutriadr"].ToString() == "1") chkhoiphuckhongdichung.Checked = true;
                    else if (r2["ketquaxutriadr"].ToString() == "2") chkphuchoicodichung.Checked = true;
                    else if (r2["ketquaxutriadr"].ToString() == "3") chkkhongphuchoi.Checked = true;
                    else if (r2["ketquaxutriadr"].ToString() == "4") chkchetdoADR.Checked = true;
                    else if (r2["ketquaxutriadr"].ToString() == "5") chkchetkhonglienquanthuoc.Checked = true;
                    else if (r2["ketquaxutriadr"].ToString() == "6") chkkhongxacdinh.Checked = true;
                    txtbinhluanbacsi.Text = r2["bsbinhluan"].ToString();
                    if (r2["thamdinhadr_dvyte"].ToString() == "1") chkchacchan_yte.Checked = true;
                    else if (r2["thamdinhadr_dvyte"].ToString() == "2") chkcokhanang_yte.Checked = true;
                    else if (r2["thamdinhadr_dvyte"].ToString() == "3") chkcothe_yte.Checked = true;
                    else if (r2["thamdinhadr_dvyte"].ToString() == "4") chkkhongchacchan_yte.Checked = true;
                    else if (r2["thamdinhadr_dvyte"].ToString() == "5") chkchuaphanloai.Checked = true;
                    else if (r2["thamdinhadr_dvyte"].ToString() == "6") chkkhongthephanloai.Checked = true;
                    else if (r2["thamdinhadr_dvyte"].ToString() == "7") chkkhac_thamdinh.Checked = true;
                    if (r2["thangthamdinhadr_chuyengia"].ToString() == "1") ThangWho.Checked = true;
                    else if (r2["thangthamdinhadr_chuyengia"].ToString() == "2") ThangNaranjo.Checked = true;
                    else if (r2["thangthamdinhadr_chuyengia"].ToString() == "3") Thangkhac.Checked = true;
                    
                }
            }
        }

        private void thuocsddongthoi_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.ActiveControl == thuocsddongthoi)
                {
                    //if (icd_chinh.Text == "")
                    //{
                    Filt_ICD(thuocsddongthoi.Text);
                    listICD.BrowseToICD10(thuocsddongthoi,icd_chinh,btthem,thuocsddongthoi.Location.X, thuocsddongthoi.Location.Y + thuocsddongthoi.Height + 20,thuocsddongthoi.Width + thuocsddongthoi.Width + 2, thuocsddongthoi.Height);
                    //listICD.BrowseToToathuoc(cd_chinh, icd_chinh, txtchandoanvachidinh, icd_chinh.Width + icd_chinh.Width + cd_chinh.Width);
                    //}
                }
            }
            catch { }
        }

        private void thuocsddongthoi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up) listICD.Focus();
            else if (e.KeyCode == Keys.Enter)
            {
                if (listICD.Visible) listICD.Focus();
                else btthem.Focus();
            }
        }

        private void btthem_Click(object sender, EventArgs e)
        {
            if (thuocsddongthoi.Text.Trim() == "" || thuocsddongthoi.Text.Trim() == "") return;
            if (icd_chinh.Text.Trim() == "") return;
            updrec_thuocsddongthoi(dsthuocsddongthoi, l_id, int.Parse(icd_chinh.Text));
            dataGrid2.DataSource = dsthuocsddongthoi.Tables[0];
            emp_item();
            thuocsddongthoi.Focus();
        }

        private void btdelete_Click(object sender, EventArgs e)
        {
            if (butsua.Enabled == false)
            {
                string aa = dataGrid2[dataGrid2.CurrentRowIndex, 0].ToString();
                DataRow dr = m.getrowbyid(dsthuocsddongthoi.Tables[0], "mabd=" + dataGrid2[dataGrid2.CurrentRowIndex, 0].ToString() + "");
                if (dr != null) dsthuocsddongthoi.Tables[0].Rows.Remove(dr);
            }
        }

        private void btxetnghiem_Click(object sender, EventArgs e)
        {
            if (butsua.Enabled == false)
            {
                s_xetnghiem = "";
                txtxetnghiem.Text = "";
                DataTable dt = m.get_data("select c.id from medibv.v_nhomvp b, medibv.v_loaivp c where b.ma = c.id_nhom and b.idnhomvpmedisoft =1").Tables[0];
                string s_loaivp = "";
                foreach (DataRow r in dt.Rows)
                {
                    s_loaivp += r["id"].ToString() + ",";
                }
                DataRow r1 = m.getrowbyid(ds.Tables[0], "maql=" + l_maql);
                string i_madoituong = r1["madoituong"].ToString();
                frmChonchidinh f = new frmChonchidinh(m, mabn.Text, int.Parse(i_madoituong), s_loaivp, "", i_loaiba, "", 0, 0, false);
                f.ShowDialog(this);
                int count = f.dt.Rows.Count;
                if (count > 0)
                {
                    foreach (DataRow r3 in f.dt.Rows)
                    {
                        count--;
                        if (count == 0)
                        {
                            s_xetnghiem += r3["mavp"].ToString();
                            txtxetnghiem.Text += " - " + r3["ten"].ToString();
                        }
                        else
                        {
                            s_xetnghiem += r3["mavp"].ToString() + "+";
                            txtxetnghiem.Text =  " - " + r3["ten"].ToString() + "\n";
                        }
                    }
                }
                
            }
        }

        private void chkngungthuoc_tientrientot_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chkngungthuoc_tientrientot.Checked)
            {
                chkngungthuoc_khongtientrien.Checked = false;
                chkngungthuoc_dieutritiep.Checked = false;
                chkngungthuoc_khongbiet.Checked = false;
            }

        }

        private void chkngungthuoc_khongtientrien_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chkngungthuoc_khongtientrien.Checked)
            {
                chkngungthuoc_tientrientot.Checked = false;
                chkngungthuoc_dieutritiep.Checked = false;
                chkngungthuoc_khongbiet.Checked = false;
            }
        }

        private void chkngungthuoc_dieutritiep_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chkngungthuoc_dieutritiep.Checked)
            {
                chkngungthuoc_tientrientot.Checked = false;
                chkngungthuoc_khongbiet.Checked = false;
                chkngungthuoc_khongtientrien.Checked = false;
            }
        }

        private void chkngungthuoc_khongbiet_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chkngungthuoc_khongbiet.Checked)
            {
                chkngungthuoc_tientrientot.Checked = false;
                chkngungthuoc_dieutritiep.Checked = false;
                chkngungthuoc_khongtientrien.Checked = false;
            }
        }

        private void chksdthuockhac_tientrientot_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chksdthuockhac_tientrientot.Checked)
            {
                chksdthuockhac_khongtientrien.Checked = false;
                chksdthuockhac_dieutritiep.Checked = false;
                chksdthuockhac_khongbiet.Checked = false;
            }
        }

        private void chksdthuockhac_khongtientrien_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chksdthuockhac_khongtientrien.Checked)
            {
                chksdthuockhac_dieutritiep.Checked = false;
                chksdthuockhac_khongbiet.Checked = false;
                chksdthuockhac_tientrientot.Checked = false;
            }
        }

        private void chksdthuockhac_dieutritiep_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chksdthuockhac_dieutritiep.Checked)
            {
                chksdthuockhac_khongtientrien.Checked = false;
                chksdthuockhac_khongbiet.Checked = false;
                chksdthuockhac_tientrientot.Checked = false;
            }
        }

        private void chksdthuockhac_khongbiet_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chksdthuockhac_khongbiet.Checked)
            {
                chksdthuockhac_khongtientrien.Checked = false;
                chksdthuockhac_tientrientot.Checked = false;
                chksdthuockhac_dieutritiep.Checked = false;
            }
        }

        private void chktuvong_md_CheckedChanged(object sender, EventArgs e)
        {
            if (chktuvong_md.Checked)
            {
                chkdedoa_md.Checked = false;
                chknhapnamvien_md.Checked = false;
                chktantat_md.Checked = false;
                chkditat_md.Checked = false;
                chkkhongngtrong_md.Checked = false;
            }
        }

        private void chkdedoa_md_CheckedChanged(object sender, EventArgs e)
        {
            if (chkdedoa_md.Checked)
            {
                chktuvong_md.Checked = false;
                chknhapnamvien_md.Checked = false;
                chktantat_md.Checked = false;
                chkditat_md.Checked = false;
                chkkhongngtrong_md.Checked = false;
            }
        }

        private void chknhapnamvien_md_CheckedChanged(object sender, EventArgs e)
        {
            if (chknhapnamvien_md.Checked)
            {
                chktantat_md.Checked = false;
                chkditat_md.Checked = false;
                chkkhongngtrong_md.Checked = false;
                chktuvong_md.Checked = false;
                chkdedoa_md.Checked = false;
            }
        }

        private void chktantat_md_CheckedChanged(object sender, EventArgs e)
        {
            if (chktantat_md.Checked)
            {
                chknhapnamvien_md.Checked = false;
                chkditat_md.Checked = false;
                chkkhongngtrong_md.Checked = false;
                chktuvong_md.Checked = false;
                chkdedoa_md.Checked = false;
            }
        }

        private void chkditat_md_CheckedChanged(object sender, EventArgs e)
        {
            if (chkditat_md.Checked)
            {
                chknhapnamvien_md.Checked = false;
                chktantat_md.Checked = false;
                chkkhongngtrong_md.Checked = false;
                chktuvong_md.Checked = false;
                chkdedoa_md.Checked = false;
            }
        }

        private void chkkhongngtrong_md_CheckedChanged(object sender, EventArgs e)
        {
            if (chkkhongngtrong_md.Checked)
            {
                chknhapnamvien_md.Checked = false;
                chktantat_md.Checked = false;
                chkditat_md.Checked = false;
                chktuvong_md.Checked = false;
                chkdedoa_md.Checked = false;
            }
        }

        private void chkchuaphanloai_CheckedChanged(object sender, EventArgs e)
        {
            if (chkchuaphanloai.Checked)
            {
                chkchacchan_yte.Checked = false;
                chkcokhanang_yte.Checked = false;
                chkcothe_yte.Checked = false;
                chkkhongchacchan_yte.Checked = false;
                chkkhongthephanloai.Checked = false;
            }
        }

        private void chkkhongthephanloai_CheckedChanged(object sender, EventArgs e)
        {
            if (chkkhongthephanloai.Checked)
            {
                chkchacchan_yte.Checked = false;
                chkcokhanang_yte.Checked = false;
                chkcothe_yte.Checked = false;
                chkkhongchacchan_yte.Checked = false;
                chkchuaphanloai.Checked = false;
            }
        }

        private void ThangWho_CheckedChanged(object sender, EventArgs e)
        {
            if (ThangWho.Checked)
            {
                ThangNaranjo.Checked = false;
                Thangkhac.Checked = false;
            }
        }

        private void ThangNaranjo_CheckedChanged(object sender, EventArgs e)
        {
            if (ThangNaranjo.Checked)
            {
                ThangWho.Checked = false;
                Thangkhac.Checked = false;
            }
        }

        private void Thangkhac_CheckedChanged(object sender, EventArgs e)
        {
            if (Thangkhac.Checked)
            {
                ThangWho.Checked = false;
                ThangNaranjo.Checked = false;
            }
        }

        private void chkdangphuchoi_CheckedChanged(object sender, EventArgs e)
        {
            if (chkdangphuchoi.Checked)
            {
                chkkhongxacdinh.Checked = false;
                chkphuchoicodichung.Checked = false;
                chkhoiphuckhongdichung.Checked = false;
                chkkhongphuchoi.Checked = false;
                chkchetdoADR.Checked = false;
                chkchetkhonglienquanthuoc.Checked = false;
            }
        }

        private void dataGrid1_CurrentCellChanged(object sender, EventArgs e)
        {
            int index_r = dataGrid1.CurrentCell.RowNumber;
            cd_chinh.Text = dataGrid1[index_r, 1].ToString();
            tenhc.Text = dataGrid1[index_r, 2].ToString();
            solan.Value = decimal.Parse(dataGrid1[index_r, 4].ToString());
            moilan.Text = dataGrid1[index_r, 14].ToString();
            decimal sl = solan.Value * decimal.Parse(moilan.Text);
            soluong.Text = sl.ToString();
            soluong.Refresh();
            textBox1.Text = dataGrid1[index_r, 3].ToString();
            lydodungthuoc.Text = dataGrid1[index_r, 11].ToString();
            cbcaithien.SelectedIndex = int.Parse(dataGrid1[index_r, 12].ToString())-1;
            cbtaiphanung.SelectedIndex = int.Parse(dataGrid1[index_r, 13].ToString())-1;
        }

    }
}

