using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Data;
using LibDuoc;


namespace Duoc
{
    /// <summary>
    /// Summary description for rptNxt_tonghop.
    /// </summary>
    public class rptNxt_CK_ngay : System.Windows.Forms.Form
    {
        Language lan = new Language(); Bogotiengviet tv = new Bogotiengviet(); private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        //lan.Read_Language_to_Xml(this.Name.ToString(),this);
		//lan.Changelanguage_to_English(this.Name.ToString(),this);
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button butIn;
        private System.Windows.Forms.Button butKetthuc;
        private LibDuoc.AccessData d;
        private int i_nhom, i_tt, i_dongiale, i_userid=0;
        private bool bClear = true, bGiaban, bGiabandot;
        private bool bln_chonmaubaocao = true;
        private string user, xxx, sql, s_mmyy, s_tu, s_den, s_yy, s_kho, tenfile, s_manhom, tenreport, exp, s_khott, s_maduocbv="", s_tenduocbv="";
        private DataRow r1, r2, r3, r4;
        private DataSet ds = new DataSet();
        private DataSet dsxml = new DataSet();
        private DataTable dt = new DataTable();
        private DataTable dtdmnhomdbv = new DataTable();
        private DataSet ds_dsbc = new DataSet();
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox manguon;
        private System.Windows.Forms.NumericUpDown yyyy;
        private System.Windows.Forms.NumericUpDown tu;
        private System.Windows.Forms.NumericUpDown den;
        private System.Windows.Forms.Label label3;
        private DataTable dtdmkho = new DataTable();
        private DataTable dtdmnhom = new DataTable();
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox tt;
        private CheckBox chkGiachuaVAT;
        private CheckBox chkKhoahoantra;
        private ToolTip toolTip1;
        private ComboBox cbmaubaocao;
        private Label label5;
        private Button butmaubc;
        private CheckBox chkNhacc;
        private TreeView_HAISON treeView_Kho;
        private TreeView_HAISON treeView_Manhom;
        private CheckBox chkXML;
        private RadioButton radioButton1;
        private RadioButton rdthang;
        private NumericUpDown mmtu;
        private NumericUpDown mmden;
        private NumericUpDown yyden;
        private NumericUpDown yytu;
        private DateTimePicker denngay;
        private DateTimePicker tungay;
        private Label label8;
        private Label label10;
        private Label label13;
        private Label label16;
        private IContainer components;
        private CheckBox chkchitietkho;
        private CheckBox chkchuyenkho;
        private TreeView_HAISON tree_duocbv;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private RichTextBox richTextBox1;
        private bool bGiaban_Dot = false;

        public rptNxt_CK_ngay(AccessData acc, int nhom, string kho, string mmyy, string file, bool giaban, int _userid)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            //Language lan = new Language(); Bogotiengviet tv = new Bogotiengviet(); private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        lan.Read_Language_to_Xml(this.Name.ToString(),this);
		lan.Changelanguage_to_English(this.Name.ToString(),this);
            d = acc;
            i_nhom = nhom;
            s_kho = kho;
            tenfile = file;
            i_userid = _userid;
            tu.Value = decimal.Parse(mmyy.Substring(0, 2));
            den.Value = tu.Value; bGiaban = giaban;
            yyyy.Value = decimal.Parse("20" + mmyy.Substring(2, 2));
            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rptNxt_CK_ngay));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.manguon = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tu = new System.Windows.Forms.NumericUpDown();
            this.yyyy = new System.Windows.Forms.NumericUpDown();
            this.den = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tt = new System.Windows.Forms.ComboBox();
            this.chkGiachuaVAT = new System.Windows.Forms.CheckBox();
            this.chkKhoahoantra = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.cbmaubaocao = new System.Windows.Forms.ComboBox();
            this.chkNhacc = new System.Windows.Forms.CheckBox();
            this.chkXML = new System.Windows.Forms.CheckBox();
            this.chkchitietkho = new System.Windows.Forms.CheckBox();
            this.chkchuyenkho = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.butmaubc = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.rdthang = new System.Windows.Forms.RadioButton();
            this.mmtu = new System.Windows.Forms.NumericUpDown();
            this.mmden = new System.Windows.Forms.NumericUpDown();
            this.yyden = new System.Windows.Forms.NumericUpDown();
            this.yytu = new System.Windows.Forms.NumericUpDown();
            this.denngay = new System.Windows.Forms.DateTimePicker();
            this.tungay = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.butIn = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.treeView_Manhom = new Duoc.TreeView_HAISON();
            this.treeView_Kho = new Duoc.TreeView_HAISON();
            this.tree_duocbv = new Duoc.TreeView_HAISON();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.tu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yyyy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.den)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mmtu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mmden)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yyden)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yytu)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ tháng :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(204, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 23);
            this.label2.TabIndex = 4;
            this.label2.Text = "năm";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // manguon
            // 
            this.manguon.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manguon.Location = new System.Drawing.Point(69, 102);
            this.manguon.Name = "manguon";
            this.manguon.Size = new System.Drawing.Size(222, 21);
            this.manguon.TabIndex = 9;
            this.manguon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Nguồn :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tu
            // 
            this.tu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tu.Location = new System.Drawing.Point(70, 34);
            this.tu.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.tu.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tu.Name = "tu";
            this.tu.Size = new System.Drawing.Size(40, 21);
            this.tu.TabIndex = 0;
            this.tu.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // yyyy
            // 
            this.yyyy.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yyyy.Location = new System.Drawing.Point(243, 34);
            this.yyyy.Maximum = new decimal(new int[] {
            3004,
            0,
            0,
            0});
            this.yyyy.Minimum = new decimal(new int[] {
            2004,
            0,
            0,
            0});
            this.yyyy.Name = "yyyy";
            this.yyyy.Size = new System.Drawing.Size(48, 21);
            this.yyyy.TabIndex = 2;
            this.yyyy.Value = new decimal(new int[] {
            2004,
            0,
            0,
            0});
            this.yyyy.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // den
            // 
            this.den.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.den.Location = new System.Drawing.Point(162, 34);
            this.den.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.den.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.den.Name = "den";
            this.den.Size = new System.Drawing.Size(40, 21);
            this.den.TabIndex = 1;
            this.den.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.den.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(126, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "đến :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(6, 124);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 23);
            this.label6.TabIndex = 10;
            this.label6.Text = "Kho :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 302);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "In theo:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tt
            // 
            this.tt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tt.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tt.Items.AddRange(new object[] {
            "Nội ngoại,nhóm",
            "Kho,nhóm kế toán",
            "Nhóm",
            "Phân loại",
            "Nhóm dược BV"});
            this.tt.Location = new System.Drawing.Point(69, 303);
            this.tt.Name = "tt";
            this.tt.Size = new System.Drawing.Size(222, 24);
            this.tt.TabIndex = 13;
            this.tt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // chkGiachuaVAT
            // 
            this.chkGiachuaVAT.AutoSize = true;
            this.chkGiachuaVAT.Location = new System.Drawing.Point(116, 353);
            this.chkGiachuaVAT.Name = "chkGiachuaVAT";
            this.chkGiachuaVAT.Size = new System.Drawing.Size(93, 17);
            this.chkGiachuaVAT.TabIndex = 17;
            this.chkGiachuaVAT.Text = "Giá chưa thuế";
            this.toolTip1.SetToolTip(this.chkGiachuaVAT, "Chọn để in ra giá trước VAT");
            this.chkGiachuaVAT.UseVisualStyleBackColor = true;
            this.chkGiachuaVAT.Click += new System.EventHandler(this.chkGiachuaVAT_Click);
            // 
            // chkKhoahoantra
            // 
            this.chkKhoahoantra.AutoSize = true;
            this.chkKhoahoantra.Location = new System.Drawing.Point(6, 387);
            this.chkKhoahoantra.Name = "chkKhoahoantra";
            this.chkKhoahoantra.Size = new System.Drawing.Size(121, 17);
            this.chkKhoahoantra.TabIndex = 20;
            this.chkKhoahoantra.Text = "In cột hoàn trả riêng";
            this.toolTip1.SetToolTip(this.chkKhoahoantra, "Trả theo bệnh nhân + Trả theo thu hồi cơ số tủ trực + Khoa hoàn trả cơ số tủ trực" +
                    "");
            this.chkKhoahoantra.UseVisualStyleBackColor = true;
            this.chkKhoahoantra.Visible = false;
            this.chkKhoahoantra.Click += new System.EventHandler(this.chkKhoahoantra_Click);
            // 
            // cbmaubaocao
            // 
            this.cbmaubaocao.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbmaubaocao.Location = new System.Drawing.Point(69, 328);
            this.cbmaubaocao.Name = "cbmaubaocao";
            this.cbmaubaocao.Size = new System.Drawing.Size(424, 21);
            this.cbmaubaocao.TabIndex = 22;
            this.toolTip1.SetToolTip(this.cbmaubaocao, "Khai báo mẫu báo cáo trong file XML: dsbaocao_nxt.xml, cùng với thư mục của file " +
                    "EXE");
            this.cbmaubaocao.Visible = false;
            // 
            // chkNhacc
            // 
            this.chkNhacc.AutoSize = true;
            this.chkNhacc.Location = new System.Drawing.Point(6, 353);
            this.chkNhacc.Name = "chkNhacc";
            this.chkNhacc.Size = new System.Drawing.Size(104, 17);
            this.chkNhacc.TabIndex = 24;
            this.chkNhacc.Text = "In nhà cung cấp";
            this.toolTip1.SetToolTip(this.chkNhacc, "Trả theo bệnh nhân + Trả theo thu hồi cơ số tủ trực + Khoa hoàn trả cơ số tủ trực" +
                    "");
            this.chkNhacc.UseVisualStyleBackColor = true;
            // 
            // chkXML
            // 
            this.chkXML.AutoSize = true;
            this.chkXML.Location = new System.Drawing.Point(296, 353);
            this.chkXML.Name = "chkXML";
            this.chkXML.Size = new System.Drawing.Size(73, 17);
            this.chkXML.TabIndex = 17;
            this.chkXML.Text = "Xuất XML";
            this.toolTip1.SetToolTip(this.chkXML, "yutyutu");
            this.chkXML.UseVisualStyleBackColor = true;
            this.chkXML.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chkXML_MouseMove);
            // 
            // chkchitietkho
            // 
            this.chkchitietkho.AutoSize = true;
            this.chkchitietkho.Location = new System.Drawing.Point(6, 370);
            this.chkchitietkho.Name = "chkchitietkho";
            this.chkchitietkho.Size = new System.Drawing.Size(103, 17);
            this.chkchitietkho.TabIndex = 80;
            this.chkchitietkho.Text = "Chi tiết theo kho";
            this.toolTip1.SetToolTip(this.chkchitietkho, "Trả theo bệnh nhân + Trả theo thu hồi cơ số tủ trực + Khoa hoàn trả cơ số tủ trực" +
                    "");
            this.chkchitietkho.UseVisualStyleBackColor = true;
            this.chkchitietkho.Visible = false;
            // 
            // chkchuyenkho
            // 
            this.chkchuyenkho.AutoSize = true;
            this.chkchuyenkho.Location = new System.Drawing.Point(383, 353);
            this.chkchuyenkho.Name = "chkchuyenkho";
            this.chkchuyenkho.Size = new System.Drawing.Size(131, 17);
            this.chkchuyenkho.TabIndex = 81;
            this.chkchuyenkho.Text = "Chuyển kho tính riêng";
            this.toolTip1.SetToolTip(this.chkchuyenkho, "yutyutu");
            this.chkchuyenkho.UseVisualStyleBackColor = true;
            this.chkchuyenkho.Visible = false;
            this.chkchuyenkho.Click += new System.EventHandler(this.chkchuyenkho_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 332);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Mẫu BC:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label5.Visible = false;
            // 
            // butmaubc
            // 
            this.butmaubc.Location = new System.Drawing.Point(494, 327);
            this.butmaubc.Name = "butmaubc";
            this.butmaubc.Size = new System.Drawing.Size(31, 23);
            this.butmaubc.TabIndex = 23;
            this.butmaubc.Text = "---";
            this.butmaubc.UseVisualStyleBackColor = true;
            this.butmaubc.Visible = false;
            this.butmaubc.Click += new System.EventHandler(this.butmaubc_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(187, 9);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(76, 17);
            this.radioButton1.TabIndex = 58;
            this.radioButton1.Text = "Theo ngày";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // rdthang
            // 
            this.rdthang.AutoSize = true;
            this.rdthang.Checked = true;
            this.rdthang.Location = new System.Drawing.Point(70, 9);
            this.rdthang.Name = "rdthang";
            this.rdthang.Size = new System.Drawing.Size(84, 17);
            this.rdthang.TabIndex = 57;
            this.rdthang.TabStop = true;
            this.rdthang.Text = "Theo Tháng";
            this.rdthang.UseVisualStyleBackColor = true;
            this.rdthang.CheckedChanged += new System.EventHandler(this.rdthang_CheckedChanged);
            // 
            // mmtu
            // 
            this.mmtu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mmtu.Location = new System.Drawing.Point(201, 56);
            this.mmtu.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.mmtu.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.mmtu.Name = "mmtu";
            this.mmtu.Size = new System.Drawing.Size(40, 21);
            this.mmtu.TabIndex = 4;
            this.mmtu.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.mmtu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // mmden
            // 
            this.mmden.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mmden.Location = new System.Drawing.Point(201, 79);
            this.mmden.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.mmden.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.mmden.Name = "mmden";
            this.mmden.Size = new System.Drawing.Size(40, 21);
            this.mmden.TabIndex = 7;
            this.mmden.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.mmden.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // yyden
            // 
            this.yyden.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yyden.Location = new System.Drawing.Point(243, 79);
            this.yyden.Maximum = new decimal(new int[] {
            3004,
            0,
            0,
            0});
            this.yyden.Minimum = new decimal(new int[] {
            2004,
            0,
            0,
            0});
            this.yyden.Name = "yyden";
            this.yyden.Size = new System.Drawing.Size(48, 21);
            this.yyden.TabIndex = 8;
            this.yyden.Value = new decimal(new int[] {
            2004,
            0,
            0,
            0});
            this.yyden.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // yytu
            // 
            this.yytu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yytu.Location = new System.Drawing.Point(243, 56);
            this.yytu.Maximum = new decimal(new int[] {
            3004,
            0,
            0,
            0});
            this.yytu.Minimum = new decimal(new int[] {
            2004,
            0,
            0,
            0});
            this.yytu.Name = "yytu";
            this.yytu.Size = new System.Drawing.Size(48, 21);
            this.yytu.TabIndex = 5;
            this.yytu.Value = new decimal(new int[] {
            2004,
            0,
            0,
            0});
            this.yytu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // denngay
            // 
            this.denngay.CalendarFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.denngay.CustomFormat = "dd/MM/yyyy";
            this.denngay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.denngay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.denngay.Location = new System.Drawing.Point(69, 79);
            this.denngay.Name = "denngay";
            this.denngay.Size = new System.Drawing.Size(80, 21);
            this.denngay.TabIndex = 6;
            this.denngay.Validated += new System.EventHandler(this.denngay_Validated);
            this.denngay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // tungay
            // 
            this.tungay.CalendarFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tungay.CustomFormat = "dd/MM/yyyy";
            this.tungay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tungay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tungay.Location = new System.Drawing.Point(69, 56);
            this.tungay.Name = "tungay";
            this.tungay.Size = new System.Drawing.Size(80, 21);
            this.tungay.TabIndex = 3;
            this.tungay.Validated += new System.EventHandler(this.tungay_Validated);
            this.tungay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tu_KeyDown);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(27, 78);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 23);
            this.label8.TabIndex = 73;
            this.label8.Text = "đến :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(12, 57);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 23);
            this.label10.TabIndex = 72;
            this.label10.Text = "Từ ngày :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(148, 55);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(42, 23);
            this.label13.TabIndex = 75;
            this.label13.Text = "SốLiệu";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(149, 79);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(42, 23);
            this.label16.TabIndex = 79;
            this.label16.Text = "SốLiệu";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(292, 395);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(71, 25);
            this.butKetthuc.TabIndex = 11;
            this.butKetthuc.Text = "    &Kết thúc";
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // butIn
            // 
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(221, 395);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(71, 25);
            this.butIn.TabIndex = 10;
            this.butIn.Text = "   &In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(540, 462);
            this.tabControl1.TabIndex = 83;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.treeView_Manhom);
            this.tabPage1.Controls.Add(this.chkchitietkho);
            this.tabPage1.Controls.Add(this.chkchuyenkho);
            this.tabPage1.Controls.Add(this.chkNhacc);
            this.tabPage1.Controls.Add(this.chkKhoahoantra);
            this.tabPage1.Controls.Add(this.treeView_Kho);
            this.tabPage1.Controls.Add(this.chkGiachuaVAT);
            this.tabPage1.Controls.Add(this.mmtu);
            this.tabPage1.Controls.Add(this.manguon);
            this.tabPage1.Controls.Add(this.tree_duocbv);
            this.tabPage1.Controls.Add(this.mmden);
            this.tabPage1.Controls.Add(this.tt);
            this.tabPage1.Controls.Add(this.butKetthuc);
            this.tabPage1.Controls.Add(this.yyden);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.butIn);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.yytu);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.chkXML);
            this.tabPage1.Controls.Add(this.denngay);
            this.tabPage1.Controls.Add(this.butmaubc);
            this.tabPage1.Controls.Add(this.tungay);
            this.tabPage1.Controls.Add(this.cbmaubaocao);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.rdthang);
            this.tabPage1.Controls.Add(this.label13);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label16);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.radioButton1);
            this.tabPage1.Controls.Add(this.tu);
            this.tabPage1.Controls.Add(this.yyyy);
            this.tabPage1.Controls.Add(this.den);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(532, 436);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Nhập-Xuất-Tồn";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // treeView_Manhom
            // 
            this.treeView_Manhom.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.treeView_Manhom.BackColor = System.Drawing.Color.Transparent;
            this.treeView_Manhom.Location = new System.Drawing.Point(296, 2);
            this.treeView_Manhom.Name = "treeView_Manhom";
            this.treeView_Manhom.Size = new System.Drawing.Size(228, 178);
            this.treeView_Manhom.TabIndex = 25;
            // 
            // treeView_Kho
            // 
            this.treeView_Kho.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.treeView_Kho.BackColor = System.Drawing.Color.Transparent;
            this.treeView_Kho.Location = new System.Drawing.Point(69, 124);
            this.treeView_Kho.Name = "treeView_Kho";
            this.treeView_Kho.Size = new System.Drawing.Size(222, 178);
            this.treeView_Kho.TabIndex = 25;
            // 
            // tree_duocbv
            // 
            this.tree_duocbv.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tree_duocbv.BackColor = System.Drawing.Color.Transparent;
            this.tree_duocbv.Location = new System.Drawing.Point(296, 181);
            this.tree_duocbv.Name = "tree_duocbv";
            this.tree_duocbv.Size = new System.Drawing.Size(228, 146);
            this.tree_duocbv.TabIndex = 82;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.richTextBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(532, 436);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Hướng dẫn";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(3, 3);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(526, 430);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // rptNxt_CK_ngay
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(540, 462);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "rptNxt_CK_ngay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo cáo nhập xuất tồn";
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rptNxt_CK_MouseMove);
            this.Load += new System.EventHandler(this.rptNxt_CK_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yyyy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.den)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mmtu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mmden)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yyden)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yytu)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        private void rptNxt_CK_Load(object sender, System.EventArgs e)
        {
            user = d.user;
            Enable_ngay((rdthang.Checked == true) ? true : false);
            string mmyy = "";
            mmyy = s_mmyy;
            mmtu.Value = decimal.Parse(tungay.Text.Substring(3, 2));
            mmden.Value = decimal.Parse(denngay.Text.Substring(3, 2));
            yytu.Value = decimal.Parse(tungay.Text.Substring(6, 4));
            yyden.Value = decimal.Parse(denngay.Text.Substring(6,4)); 
            // 
            bGiabandot = d.bGiaban_theodot(i_nhom);
            i_dongiale = d.d_dongia_le(i_nhom);
            if (tt.Items.Count > 0) tt.SelectedIndex = 0;
            sql = "select * from " + user + ".d_dmkho where hide=0 and nhom=" + i_nhom;
            if (s_kho != "") sql += " and id in (" + s_kho.Substring(0, s_kho.Length - 1) + ")";
            sql += " order by stt";
            dtdmkho = d.get_data(sql).Tables[0];
            treeView_Kho.setDataSource(dtdmkho, "TEN", "ID", "Chọn tất cả KHo", false, "Nếu check vào thì chọn tất cả kho");                 

            dtdmnhom = d.get_data("select * from " + user + ".d_dmnhom where stt<>0 and nhom=" + i_nhom + " order by stt").Tables[0];
            treeView_Manhom.setDataSource(dtdmnhom, "TEN", "ID", "Chọn tất cả nhóm", false, "Nếu check vào thì chọn tất cả nhóm");

            dtdmnhomdbv = d.get_data("select * from " + user + ".d_nhombo where nhom=" + i_nhom + " order by stt").Tables[0];
            tree_duocbv.setDataSource(dtdmnhomdbv, "TEN", "ID", "Chọn tất cả nhóm Dược BV", false, "Nếu check vào thì chọn tất cả nhóm");   

            manguon.DisplayMember = "TEN";
            manguon.ValueMember = "ID";
            if (d.bQuanlynguon(i_nhom))
                manguon.DataSource = d.get_data("select * from " + user + ".d_dmnguon where nhom=" + i_nhom + " order by stt").Tables[0];
            else
                manguon.DataSource = d.get_data("select * from " + user + ".d_dmnguon where id=0 or nhom=" + i_nhom + " order by stt").Tables[0];
            //
            manguon.SelectedIndex = -1;
            manguon.Text = "";
            //
            ds.ReadXml("..\\..\\..\\xml\\d_nxt_ck.xml");
            //dsxml.ReadXml("..\\..\\..\\xml\\d_nxt_ck.xml");
            try { ds.Tables[0].Columns.Add(new DataColumn("SL_TRA", typeof(decimal))); }
            catch { }
            try { ds.Tables[0].Columns.Add(new DataColumn("ST_TRA", typeof(decimal))); }
            catch { }
            try { ds.Tables[0].Columns.Add(new DataColumn("SL_TH", typeof(decimal))); }
            catch { }
            try { ds.Tables[0].Columns.Add(new DataColumn("ST_TH", typeof(decimal))); }
            catch { }
            try { ds.Tables[0].Columns.Add(new DataColumn("MANHACC", typeof(decimal))); }
            catch { }
            try { ds.Tables[0].Columns.Add(new DataColumn("TENNHACC", typeof(string))); }
            catch { }

            try { ds.Tables[0].Columns.Add(new DataColumn("SLXUAT_BAN", typeof(decimal))); }
            catch { }
            try { ds.Tables[0].Columns.Add(new DataColumn("STXUAT_BAN", typeof(decimal))); }
            catch { }
            try { ds.Tables[0].Columns.Add(new DataColumn("VAT", typeof(decimal))); }
            catch { }
            try { ds.Tables[0].Columns.Add(new DataColumn("SL_TRANHACC", typeof(decimal))); }
            catch { }
            try { ds.Tables[0].Columns.Add(new DataColumn("ST_TRANHACC", typeof(decimal))); }
            catch { }
            dsxml = ds.Copy();
            
            if (bGiaban) tt.SelectedIndex = 3;
            // //Tao file dsbaocaonhapxuatton
            //try
            //{
            //    if (File.Exists("dsbaocao_nxt.xml") == false)
            //    {
            //        sql = "Select 'TK01 - Báo cáo nhập xuất tồn' as tenreport, 'd_bcnxt_ck.rpt' as tenfile from dual";
            //        DataSet lds = d.get_data(sql);
            //        lds.WriteXml("dsbaocao_nxt.xml", XmlWriteMode.WriteSchema);
            //    }
            //    load_dmmaubaocao(this.Name);
            //    cbmaubaocao.DisplayMember = "ten";
            //    cbmaubaocao.ValueMember = "ma";
            //}
            //catch { }
            chkGiachuaVAT.Checked = d.Thongso("chkGiachuaVAT_rptnxt_ck") == "1";
            chkchuyenkho.Checked = d.Thongso("chkchuyenkho_rptnxt_ck") == "1";
            
        }

        private void butIn_Click(object sender, System.EventArgs e)
        {
            if (rdthang.Checked == true)
            {
                if (tu.Value > den.Value)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Tháng không hợp lệ !"), d.Msg);
                    tu.Focus();
                    return;
                }
            }
            else
            {
                if (tungay.Value > denngay.Value)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"), d.Msg);
                    tungay.Focus();
                    return;
                }
            }
                i_tt = tt.SelectedIndex;
                if (i_tt == 0)
                {
                    //string s_noingoai=" ";
                    if (d.bNoiNgoai_Hang(i_nhom) == true)
                    {
                        sql = "select a.*, b.stt as tt, b.ten as tennhom, f.id as idnn, f.ten as noingoai from " + user + ".d_dmbd a, " + user + ".d_dmnhom b, " + user + ".d_dmhang e, " + user + ".d_nhomhang f";
                        sql += " where a.manhom=b.id and a.mahang=e.id and e.loai=f.id and a.nhom=" + i_nhom + " order by a.id";
                    }
                    else if (d.bNoiNgoai_Nuoc(i_nhom) == true)
                    {
                        sql = "select a.*, b.stt as tt, b.ten as tennhom, f.id as idnn, f.ten as noingoai from " + user + ".d_dmbd a, " + user + ".d_dmnhom b, " + user + ".d_dmnuoc e, " + user + ".d_nhomnuoc f";
                        sql += " where a.manhom=b.id and a.manuoc=e.id and e.loai=f.id and a.nhom=" + i_nhom + " order by a.id";
                    }
                    else
                    {
                        sql = "select a.*, b.stt as tt, b.ten as tennhom, a.maloai as idnn, f.ten as noingoai from " + user + ".d_dmbd a, " + user + ".d_dmnhom b, " + user + ".d_dmhang e, " + user + ".d_dmloai f";
                        sql += " where a.manhom=b.id and a.mahang=e.id and a.maloai=f.id and a.nhom=" + i_nhom + " order by a.id";
                    }
                }
                else if (i_tt == 1)//nhom kt + kho
                {
                    sql = "select a.*, b.stt as tt, b.ten as tennhom";
                    sql += " from " + user + ".d_dmbd a," + user + ".d_dmnhomkt b where a.sotk=b.id(+) and a.nhom=" + i_nhom + " order by a.id";
                }
                else if (i_tt == 2) //nhom 
                {
                    sql = "select a.*, b.stt as tt, b.ten as tennhom";
                    sql += " from " + user + ".d_dmbd a," + user + ".d_dmnhom b where a.manhom=b.id and a.nhom=" + i_nhom + " order by a.id";
                }
                else if (i_tt == 3) //phan  loai
                {
                    sql = "select a.*, b.stt as tt, b.ten as tennhom";
                    sql += " from " + user + ".d_dmbd a," + user + ".d_dmloai b where a.maloai=b.id and a.nhom=" + i_nhom + " order by a.id";
                }
                else
                {
                    sql = "select a.*, b.stt as tt, b.ten as tennhom ";
                    sql += " from " + user + ".d_dmbd a," + user + ".d_nhombo b where a.nhombo=b.id and a.nhom=" + i_nhom + " order by a.id";
                }
                dt = d.get_data(sql).Tables[0];
                //
                s_khott = "";
                s_manhom = "";
                string s_tenkho = "";
                s_manhom = treeView_Manhom.get_Ma;

                s_kho = "";
                s_kho = treeView_Kho.get_Ma;
                s_tenkho = treeView_Kho.get_Ten;


                s_maduocbv = tree_duocbv.get_Ma;
                s_tenduocbv  = tree_duocbv.get_Ten;

                if (s_tenkho.Trim() == "") s_tenkho = "Toàn viện, ";
                //
                if (ds.Tables.Count <= 0)
                {
                    //
                    if (rdthang.Checked == true)
                    {
                        get_data();
                    }
                    else
                    {
                        get_data_ddmmyy();

                    }
                }
                else if (ds.Tables[0].Rows.Count > 0)
                {
                    DialogResult dlg = MessageBox.Show(lan.Change_language_MessageText("Bạn có muốn tổng hợp lại số liệu trước khi in không ?"), lan.Change_language_MessageText("Báo cáo Nhập xuất tồn"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlg == DialogResult.Yes)
                    {
                        if (rdthang.Checked == true)
                        {
                            get_data();
                        }
                        else
                        {
                            get_data_ddmmyy();

                        }
                    }
                   
                }
                else get_data();
                if (ds.Tables[0].Rows.Count <= 0)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Không có số liệu"), d.Msg);
                    return;
                }
                // 
            string s_thoigian="";
            if(rdthang.Checked==true)
                s_thoigian = d.title(tu.Value.ToString(), den.Value.ToString()) + " Năm " + yyyy.Value.ToString();
            else
               s_thoigian = "Từ ngày :"+tungay.Text.Substring(0,10)+" đến ngày :"+denngay.Text.Substring(0,10) + " Năm " + yyyy.Value.ToString();

            if (s_tenkho != "") s_thoigian = s_tenkho.Substring(0, s_tenkho.Trim().Length - 1) + " - " + s_thoigian;
                //
                tenfile = tenfile.Replace(".rpt", "");
                if (bGiaban)
                {
                    tenreport = tenfile;
                    bln_chonmaubaocao = false;
                }
                else
                {
                    tenreport = (s_kho == "" && d.bChuyenkho_inrieng(i_nhom)) ? "d_bcnxt_ck_n" : tenfile;
                }
                if (chkKhoahoantra.Checked) { tenreport += "_tra"; bln_chonmaubaocao = false; }
                tenreport = tenreport.Replace(".rpt", "") + ".rpt";
                cbmaubaocao.Enabled = bln_chonmaubaocao;
                string tmp_report = "";
                if (bln_chonmaubaocao && cbmaubaocao.SelectedIndex >= 0)
                {
                    tenreport = cbmaubaocao.SelectedValue.ToString().Replace(".rpt", "") + ".rpt";
                }
                if (chkXML.Checked) ds.WriteXml("..\\..\\DataXml\\d_nxt_ck.xml", XmlWriteMode.WriteSchema);
                tenreport = tenreport.Replace(".rpt", "") + ".rpt";
                if (File.Exists("..\\..\\..\\report\\" + tenreport.Replace(".rpt", "") + ".rpt") == false) tenreport = tenfile;
                if (File.Exists("..\\..\\..\\report\\" + tenreport.Replace(".rpt", "") + ".rpt") == false) tenreport = "d_bcnxt_ck.rpt";
                frmReport f = new frmReport(d, ds.Tables[0], i_userid, tenreport.Replace(".rpt", "") + ".rpt", s_thoigian, (manguon.SelectedIndex == -1) ? "" : "Nguồn :" + manguon.Text, s_tenkho, "", "", "", "", "", "", "");
                f.ShowDialog();
                if (d.bChuyenkho_inrieng(i_nhom))
                {
                    if (ds.Tables[0].Select("slxuat_ck>0").Length > 0)
                    {
                        d.delrec(dsxml.Tables[0], "slxuat_ck=0");
                        tenreport = "d_chuyenkho.rpt";
                        if (chkXML.Checked) dsxml.WriteXml("..\\..\\DataXml\\d_nxt_ck.xml", XmlWriteMode.WriteSchema);
                        tenreport = tenreport.Replace(".rpt", "") + ".rpt";
                        frmReport f1 = new frmReport(d, ds.Tables[0],i_userid, tenreport, s_thoigian, (manguon.SelectedIndex == -1) ? "" : "Nguồn :" + manguon.Text, s_tenkho, "", "", "", "", "", "", "");
                        f1.ShowDialog();
                    }
                }           

            // 
        }     

        private void get_sort()
        {
            //d.delrec(dsxml.Tables[0],"tondau+slnhap+slxuat+slxuat_ck+slnhap_ck=0");
            dsxml.Clear();
            sql = (s_manhom != "") ? "idnn,stt,ten" : "idnn,stt,ten";
            tenreport = tenfile;
            dsxml.Merge(ds.Tables[0].Select("", sql));
        }

        private void get_tondau(string d_mmyy)
        {
            xxx = user + d_mmyy;
            sql = "select ";
            if (i_tt == 1) sql += "a.makho,";
            if (bGiaban)
            {
                if (bGiabandot) sql += "c.giaban,";//gam 15/08/2011  sql += "a.giaban,";
                else sql += "b.giaban,";
            }
            else sql += "0 as giaban,";
            if (chkGiachuaVAT.Checked)
            {
                sql += "a.mabd,trunc(c.gianovat," + i_dongiale + ") as dongia,c.manguon,sum(a.tondau) as soluong,sum(a.tondau*c.gianovat) as sotien ";
            }
            else
            {
                sql += "a.mabd,trunc(c.giamua," + i_dongiale + ") as dongia,c.manguon,sum(a.tondau) as soluong,sum(a.tondau*c.giamua) as sotien ";
            }
            if (chkNhacc.Checked) sql += ", C.nhomcc as manhacc, ncc.ten as tennhacc ";
            else sql+=", 0 as manhacc, null as tennhacc ";
            sql += ",case when c.gianovat=0 then 0 else (round(c.giamua/c.gianovat,2)-1)*100 end as vat ";
            sql += "from " + xxx + ".d_tonkhoct a," + user + ".d_dmbd b," + xxx + ".d_theodoi c ";
            if (chkNhacc.Checked) sql += ", " + user + ".d_dmnx ncc";
            sql += " where a.mabd=b.id and a.stt=c.id and b.nhom=" + i_nhom;//a.tondau>0 and 
            if (chkNhacc.Checked) sql += " and c.nhomcc=ncc.id ";
            if (s_kho != "") sql += " and a.makho in (" + s_kho.Substring(0, s_kho.Length - 1) + ")";
            if (s_manhom != "") sql += " and b.manhom in (" + s_manhom.Substring(0, s_manhom.Length - 1) + ")";
            if (s_maduocbv != "") sql += " and b.nhombo in (" + s_maduocbv.Trim().Trim(',') + ")";
            if (manguon.SelectedIndex != -1) sql += " and c.manguon=" + int.Parse(manguon.SelectedValue.ToString());

            sql += " group by ";
            if (i_tt == 1) sql += "a.makho,";
            if (bGiaban)
            {
                if (bGiabandot) sql += "c.giaban,";//gam 15/08/2011  sql += "a.giaban,";
                else sql += "b.giaban,";
            }
            if (chkGiachuaVAT.Checked)
            {
                sql += "a.mabd,trunc(c.gianovat," + i_dongiale + "),c.manguon";
            }
            else
            {
                sql += "a.mabd,trunc(c.giamua," + i_dongiale + "),c.manguon";
            }
            if (chkNhacc.Checked) sql += ", C.nhomcc, ncc.ten";
            sql += ",case when c.gianovat=0 then 0 else (round(c.giamua/c.gianovat,2)-1)*100 end";
            foreach (DataRow r in d.get_data(sql).Tables[0].Rows)
            {
                exp = "mabd=" + int.Parse(r["mabd"].ToString());
                exp += " and dongia=" + decimal.Parse(r["dongia"].ToString());
                if (manguon.SelectedIndex != -1) exp += " and manguon=" + int.Parse(manguon.SelectedValue.ToString());
                if (i_tt == 1) exp += " and idnn=" + int.Parse(r["makho"].ToString());
                r1 = d.getrowbyid(ds.Tables[0], exp);
                if (r1 == null)
                {
                    r3 = d.getrowbyid(dt, "id=" + int.Parse(r["mabd"].ToString()));
                    if (r3 != null)
                    {
                        r2 = ds.Tables[0].NewRow();
                        r2["manhom"] = r3["manhom"].ToString();
                        r2["tennhom"] = r3["tennhom"].ToString();
                        r2["mabd"] = r["mabd"].ToString();
                        r2["ma"] = r3["ma"].ToString();
                        r2["ten"] = r3["ten"].ToString().Trim() + " " + r3["hamluong"].ToString();
                        if (i_tt == 0) r2["tenhc"] = r3["tenhc"].ToString();
                        else r2["tenhc"] = "";
                        r2["manhacc"] = r["manhacc"].ToString();
                        r2["tennhacc"] = r["tennhacc"].ToString();
                        r2["noingoai"] = "";
                        r2["dang"] = r3["dang"].ToString();
                        r2["tondau"] = r["soluong"].ToString();
                        r2["sttondau"] = r["sotien"].ToString();
                        r2["slnhap"] = 0;
                        r2["stnhap"] = 0;
                        r2["slxuat"] = 0;
                        r2["stxuat"] = 0;
                        r2["sl_tra"] = 0;
                        r2["st_tra"] = 0;
                        r2["dongia"] = r["dongia"].ToString();
                        r2["giaban"] = r["giaban"].ToString();
                        r2["sttt"] = 0;
                        r2["manguon"] = r["manguon"].ToString();
                        r2["stt"] = (r3["tt"].ToString() == "") ? "0" : r3["tt"].ToString();
                        if (i_tt == 0)
                        {
                            r2["idnn"] = r3["idnn"].ToString();
                            r2["noingoai"] = r3["noingoai"].ToString();
                        }
                        else if (i_tt == 1)
                        {
                            r4 = d.getrowbyid(dtdmkho, "id=" + int.Parse(r["makho"].ToString()));
                            if (r4 != null)
                            {
                                r2["idnn"] = r["makho"].ToString();
                                r2["noingoai"] = r4["ten"].ToString();
                            }
                        }
                        r2["slxuat_ck"] = "0";
                        r2["stxuat_ck"] = "0";
                        r2["slnhap_ck"] = "0";
                        r2["stnhap_ck"] = "0";
                        r2["sl_th"] = "0";
                        r2["st_th"] = "0";
                        r2["vat"] = r["vat"].ToString();
                        ds.Tables[0].Rows.Add(r2);
                    }
                }
                else
                {
                    DataRow[] dr = ds.Tables[0].Select(exp);
                    dr[0]["tondau"] = decimal.Parse(dr[0]["tondau"].ToString()) + decimal.Parse(r["soluong"].ToString());
                    dr[0]["sttondau"] = decimal.Parse(dr[0]["sttondau"].ToString()) + decimal.Parse(r["sotien"].ToString());
                }
            }
            ds.AcceptChanges();
        }
        // ham chuyen nguon theo ngay
        // 
        private void get_chuyennguon_denngay(string d_mmyy, string s_tungay)
        {
            xxx = user + d_mmyy;
            sql = "select ";
            if (i_tt == 1) sql += "b.makho,";
            if (bGiaban)
            {
                if (bGiabandot) sql += "b.giaban,";
                else sql += "c.giaban,";
            }
            else sql += "0 as giaban,";
            if (chkGiachuaVAT.Checked)
            {
                sql += "b.mabd,trunc(d.gianovat," + i_dongiale + ") as dongia, d.manguon,";
                sql += "sum(b.soluong) as soluong,sum(b.soluong*d.gianovat) as sotien ";
            }
            else
            {
                sql += "b.mabd,trunc(d.giamua," + i_dongiale + ") as dongia, d.manguon,";
                sql += "sum(b.soluong) as soluong,sum(b.soluong*d.giamua) as sotien ";
            }
            if (chkNhacc.Checked) sql += ", d.nhomcc as manhacc, ncc.ten as tennhacc ";
            else sql += ", 0 as manhacc, null as tennhacc ";
            sql += ",case when d.gianovat=0 then 0 else (round(d.giamua/d.gianovat,2)-1)*100 end as vat ";
            //
            sql += " from " + xxx + ".d_chuyenll a," + xxx + ".d_chuyenct b, " + user + ".d_dmbd c," + xxx + ".d_theodoi d ";
            if (chkNhacc.Checked) sql += ", " + user + ".d_dmnx ncc";
            sql += " where a.id=b.id and b.mabd=c.id and b.sttt=d.id and a.nhom=" + i_nhom + " and b.soluong>0";
            if (chkNhacc.Checked) sql += " and d.nhomcc=ncc.id ";
            sql += " and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') < to_date('" + s_tungay + "','dd/mm/yyyy')";
            if (s_kho != "") sql += " and b.makho in (" + s_kho.Substring(0, s_kho.Length - 1) + ")";
            if (s_manhom != "") sql += " and c.manhom in (" + s_manhom.Substring(0, s_manhom.Length - 1) + ")";
            if (s_maduocbv != "") sql += " and c.nhombo in (" + s_maduocbv.Trim().Trim(',') + ")";
            if (manguon.SelectedIndex != -1) sql += " and d.manguon=" + int.Parse(manguon.SelectedValue.ToString());
            sql += " group by ";
            if (i_tt == 1) sql += "b.makho,";
            if (bGiaban)
            {
                if (bGiabandot) sql += "b.giaban,";
                else sql += "c.giaban,";
            }
            if (chkGiachuaVAT.Checked)
            {
                sql += "b.mabd,trunc(d.gianovat," + i_dongiale + "),d.manguon ";
            }
            else
            {
                sql += "b.mabd,trunc(d.giamua," + i_dongiale + "),d.manguon ";
            }
            if (chkNhacc.Checked) sql += ", d.nhomcc, ncc.ten";
            sql += ",case when d.gianovat=0 then 0 else (round(d.giamua/d.gianovat,2)-1)*100 end ";
            foreach (DataRow r in d.get_data(sql).Tables[0].Rows)
            {
                exp = "mabd=" + int.Parse(r["mabd"].ToString());
                exp += " and dongia=" + decimal.Parse(r["dongia"].ToString());
                if (manguon.SelectedIndex != -1) exp += " and manguon=" + int.Parse(manguon.SelectedValue.ToString());
                if (i_tt == 1) exp += " and idnn=" + int.Parse(r["makho"].ToString());
                r1 = d.getrowbyid(ds.Tables[0], exp);
                // 
                if (r1 == null)
                {
                    r3 = d.getrowbyid(dt, "id=" + int.Parse(r["mabd"].ToString()));
                    if (r3 != null)
                    {
                        r2 = ds.Tables[0].NewRow();
                        r2["manhom"] = r3["manhom"].ToString();
                        r2["tennhom"] = r3["tennhom"].ToString();
                        r2["mabd"] = r["mabd"].ToString();
                        r2["ma"] = r3["ma"].ToString();
                        r2["ten"] = r3["ten"].ToString().Trim() + " " + r3["hamluong"].ToString();
                        if (i_tt == 0) r2["tenhc"] = r3["tenhc"].ToString();
                        else r2["tenhc"] = "";
                        r2["manhacc"] = r["manhacc"].ToString();
                        r2["tennhacc"] = r["tennhacc"].ToString();
                        r2["noingoai"] = "";
                        r2["dang"] = r3["dang"].ToString();
                        r2["tondau"] = Convert.ToDecimal(r["soluong"].ToString()) * (-1);
                        r2["sttondau"] = Convert.ToDecimal(r["sotien"].ToString()) * (-1);
                        r2["slxuat"] = 0;
                        r2["stxuat"] = 0;
                        r2["dongia"] = r["dongia"].ToString();
                        r2["giaban"] = r["giaban"].ToString();
                        r2["sttt"] = 0;
                        r2["manguon"] = r["manguon"].ToString();
                        r2["stt"] = (r3["tt"].ToString().Trim() == "") ? "0" : r3["tt"].ToString();
                        // 
                        if (i_tt == 0)
                        {
                            r2["idnn"] = r3["idnn"].ToString();
                            r2["noingoai"] = r3["noingoai"].ToString();
                        }
                        else if (i_tt == 1)
                        {
                            r4 = d.getrowbyid(dtdmkho, "id=" + int.Parse(r["makho"].ToString()));
                            if (r4 != null)
                            {
                                r2["idnn"] = r["makho"].ToString();
                                r2["noingoai"] = r4["ten"].ToString();
                            }
                        }
                        r2["slxuat_ck"] = 0;
                        r2["stxuat_ck"] = 0;
                        r2["slnhap_ck"] = 0;
                        r2["stnhap_ck"] = 0;
                        r2["slnhap"] = 0;
                        r2["stnhap"] = 0;
                        r2["sl_tra"] = 0;
                        r2["st_tra"] = 0;
                        r2["vat"] = r["vat"].ToString();
                        ds.Tables[0].Rows.Add(r2);
                    }
                }
                else
                {
                    DataRow[] dr = ds.Tables[0].Select(exp);
                    dr[0]["tondau"] = decimal.Parse(dr[0]["tondau"].ToString()) - decimal.Parse(r["soluong"].ToString());
                    dr[0]["sttondau"] = decimal.Parse(dr[0]["sttondau"].ToString()) - decimal.Parse(r["sotien"].ToString());
                }
            }
            //
            sql = "select ";
            if (i_tt == 1) sql += " b.makho,";
            if (bGiaban)
            {
                if (bGiabandot) sql += "b.giaban,";
                else sql += "c.giaban,";
            }
            else sql += "0 as giaban,";
            if (chkGiachuaVAT.Checked)
            {
                sql += "b.mabd,trunc(d.gianovat," + i_dongiale + ") as dongia, d.manguon,";
                sql += "sum(b.soluong) as soluong,sum(b.soluong*d.gianovat) as sotien ";
            }
            else
            {
                sql += "b.mabd,trunc(d.giamua," + i_dongiale + ") as dongia, d.manguon,";
                sql += "sum(b.soluong) as soluong,sum(b.soluong*d.giamua) as sotien ";
            }
            //
            if (chkNhacc.Checked) sql += ", d.nhomcc as manhacc, ncc.ten as tennhacc ";
            else sql += ", 0 as manhacc, null as tennhacc ";
            sql += ",case when d.gianovat=0 then 0 else (round(d.giamua/d.gianovat,2)-1)*100 end as vat ";
            sql += "from " + xxx + ".d_chuyenll a," + xxx + ".d_chuyenct b, " + user + ".d_dmbd c," + xxx + ".d_theodoi d ";
            if (chkNhacc.Checked) sql += ", " + user + ".d_dmnx ncc";
            sql += " where a.id=b.id and b.mabd=c.id and b.stttchuyen=d.id and a.nhom=" + i_nhom + " and b.soluong>0";
            if (chkNhacc.Checked) sql += " and d.nhomcc=ncc.id ";
            sql += " and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') < to_date('" + s_tungay + "','dd/mm/yyyy') ";
            if (s_kho != "") sql += " and b.makho in (" + s_kho.Substring(0, s_kho.Length - 1) + ")";
            if (s_manhom != "") sql += " and c.manhom in (" + s_manhom.Substring(0, s_manhom.Length - 1) + ")";
            if (s_maduocbv != "") sql += " and c.nhombo in (" + s_maduocbv.Trim().Trim(',') + ")";
            if (manguon.SelectedIndex != -1) sql += " and b.nguonchuyen=" + int.Parse(manguon.SelectedValue.ToString());

            sql += " group by ";
            if (i_tt == 1) sql += "b.makho,";
            if (bGiaban)
            {
                if (bGiabandot) sql += "b.giaban,";
                else sql += "c.giaban,";
            }
            if (chkGiachuaVAT.Checked)
            {
                sql += "b.mabd,trunc(d.gianovat," + i_dongiale + "),d.manguon ";
            }
            else
            {
                sql += "b.mabd,trunc(d.giamua," + i_dongiale + "),d.manguon ";
            }
            if (chkNhacc.Checked) sql += ", d.nhomcc, ncc.ten";
            sql += ",case when d.gianovat=0 then 0 else (round(d.giamua/d.gianovat,2)-1)*100 end";
            foreach (DataRow r in d.get_data(sql).Tables[0].Rows)
            {
                exp = "mabd=" + int.Parse(r["mabd"].ToString()) + " and dongia=" + decimal.Parse(r["dongia"].ToString());
                if (manguon.SelectedIndex != -1) exp += " and manguon=" + int.Parse(manguon.SelectedValue.ToString());
                if (i_tt == 1) exp += " and idnn=" + int.Parse(r["makho"].ToString());
                r1 = d.getrowbyid(ds.Tables[0], exp);
                if (r1 == null)
                {
                    r3 = d.getrowbyid(dt, "id=" + int.Parse(r["mabd"].ToString()));
                    if (r3 != null)
                    {
                        r2 = ds.Tables[0].NewRow();
                        r2["manhom"] = r3["manhom"].ToString();
                        r2["tennhom"] = r3["tennhom"].ToString();
                        r2["mabd"] = r["mabd"].ToString();
                        r2["ma"] = r3["ma"].ToString();
                        r2["ten"] = r3["ten"].ToString().Trim() + " " + r3["hamluong"].ToString();
                        if (i_tt == 0) r2["tenhc"] = r3["tenhc"].ToString();
                        else r2["tenhc"] = "";
                        r2["noingoai"] = "";
                        r2["dang"] = r3["dang"].ToString();
                        r2["tondau"] = Convert.ToDecimal(r["soluong"].ToString());
                        r2["sttondau"] = Convert.ToDecimal(r["sotien"].ToString());
                        r2["slxuat"] = 0;
                        r2["stxuat"] = 0;
                        r2["dongia"] = r["dongia"].ToString();
                        r2["giaban"] = r["giaban"].ToString();
                        r2["sttt"] = 0;
                        r2["manguon"] = r["manguon"].ToString();
                        r2["stt"] = (r3["tt"].ToString().Trim() == "") ? "0" : r3["tt"].ToString();
                        if (i_tt == 0)
                        {
                            r2["idnn"] = r3["idnn"].ToString();
                            r2["noingoai"] = r3["noingoai"].ToString();
                        }
                        else if (i_tt == 1)
                        {
                            r4 = d.getrowbyid(dtdmkho, "id=" + int.Parse(r["makho"].ToString()));
                            if (r4 != null)
                            {
                                r2["idnn"] = r["makho"].ToString();
                                r2["noingoai"] = r4["ten"].ToString();
                            }
                        }
                        r2["slnhap_ck"] = 0;// r["soluong"].ToString();
                        r2["stnhap_ck"] = 0;// r["sotien"].ToString();
                        r2["slxuat_ck"] = 0;
                        r2["stxuat_ck"] = 0;
                        r2["slnhap"] = 0;
                        r2["stnhap"] = 0;
                        r2["sl_tra"] = 0;
                        r2["st_tra"] = 0;
                        r2["vat"] = r["vat"].ToString();
                        ds.Tables[0].Rows.Add(r2);
                    }
                }
                else
                {
                    DataRow[] dr = ds.Tables[0].Select(exp);
                    dr[0]["tondau"] = decimal.Parse(dr[0]["tondau"].ToString()) + decimal.Parse(r["soluong"].ToString());
                    dr[0]["sttondau"] = decimal.Parse(dr[0]["sttondau"].ToString()) + decimal.Parse(r["sotien"].ToString());
                }
            }
            ds.AcceptChanges();
        }
        private void get_chuyennguon_ddmmyy(string d_mmyy, string s_tungay, string s_denngay)
        {
            xxx = user + d_mmyy;
            sql = "select ";
            if (i_tt == 1) sql += "b.makho,";
            if (bGiaban)
            {
                if (bGiabandot) sql += "b.giaban,";
                else sql += "c.giaban,";
            }
            else sql += "0 as giaban,";
            if (chkGiachuaVAT.Checked)
            {
                sql += "b.mabd,trunc(d.gianovat," + i_dongiale + ") as dongia, d.manguon,";
                sql += "sum(b.soluong) as soluong,sum(b.soluong*d.gianovat) as sotien ";
            }
            else
            {
                sql += "b.mabd,trunc(d.giamua," + i_dongiale + ") as dongia, d.manguon,";
                sql += "sum(b.soluong) as soluong,sum(b.soluong*d.giamua) as sotien ";
            }
            if (chkNhacc.Checked) sql += ", d.nhomcc as manhacc, ncc.ten as tennhacc ";
            else sql += ", 0 as manhacc, null as tennhacc ";
            sql += ",case when d.gianovat=0 then 0 else (round(d.giamua/d.gianovat,2)-1)*100 end as vat ";
            //
            sql += " from " + xxx + ".d_chuyenll a," + xxx + ".d_chuyenct b, " + user + ".d_dmbd c," + xxx + ".d_theodoi d ";
            if (chkNhacc.Checked) sql += ", " + user + ".d_dmnx ncc";
            sql += " where a.id=b.id and b.mabd=c.id and b.sttt=d.id and a.nhom=" + i_nhom + " and b.soluong>0";
            if (chkNhacc.Checked) sql += " and d.nhomcc=ncc.id ";
            sql += " and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + s_tungay + "','dd/mm/yyyy') and to_date('" + s_denngay + "','dd/mm/yyyy')";
            if (s_kho != "") sql += " and b.makho in (" + s_kho.Substring(0, s_kho.Length - 1) + ")";
            if (s_manhom != "") sql += " and c.manhom in (" + s_manhom.Substring(0, s_manhom.Length - 1) + ")";
            if (s_maduocbv != "") sql += " and c.nhombo in (" + s_maduocbv.Trim().Trim(',') + ")";
            if (manguon.SelectedIndex != -1) sql += " and d.manguon=" + int.Parse(manguon.SelectedValue.ToString());
            sql += " group by ";
            if (i_tt == 1) sql += "b.makho,";
            if (bGiaban)
            {
                if (bGiabandot) sql += "b.giaban,";
                else sql += "c.giaban,";
            }
            if (chkGiachuaVAT.Checked)
            {
                sql += "b.mabd,trunc(d.gianovat," + i_dongiale + "),d.manguon ";
            }
            else
            {
                sql += "b.mabd,trunc(d.giamua," + i_dongiale + "),d.manguon ";
            }
            if (chkNhacc.Checked) sql += ", d.nhomcc, ncc.ten";
            sql += ",case when d.gianovat=0 then 0 else (round(d.giamua/d.gianovat,2)-1)*100 end ";
            foreach (DataRow r in d.get_data(sql).Tables[0].Rows)
            {
                exp = "mabd=" + int.Parse(r["mabd"].ToString());
                exp += " and dongia=" + decimal.Parse(r["dongia"].ToString());
                if (manguon.SelectedIndex != -1) exp += " and manguon=" + int.Parse(manguon.SelectedValue.ToString());
                if (i_tt == 1) exp += " and idnn=" + int.Parse(r["makho"].ToString());
                r1 = d.getrowbyid(ds.Tables[0], exp);
                if (r1 == null)
                {
                    r3 = d.getrowbyid(dt, "id=" + int.Parse(r["mabd"].ToString()));
                    if (r3 != null)
                    {
                        r2 = ds.Tables[0].NewRow();
                        r2["manhom"] = r3["manhom"].ToString();
                        r2["tennhom"] = r3["tennhom"].ToString();
                        r2["mabd"] = r["mabd"].ToString();
                        r2["ma"] = r3["ma"].ToString();
                        r2["ten"] = r3["ten"].ToString().Trim() + " " + r3["hamluong"].ToString();
                        if (i_tt == 0) r2["tenhc"] = r3["tenhc"].ToString();
                        else r2["tenhc"] = "";
                        r2["manhacc"] = r["manhacc"].ToString();
                        r2["tennhacc"] = r["tennhacc"].ToString();
                        r2["noingoai"] = "";
                        r2["dang"] = r3["dang"].ToString();
                        r2["tondau"] = 0;
                        r2["sttondau"] = 0;
                        r2["slxuat"] = 0;
                        r2["stxuat"] = 0;
                        r2["dongia"] = r["dongia"].ToString();
                        r2["giaban"] = r["giaban"].ToString();
                        r2["sttt"] = 0;
                        r2["manguon"] = r["manguon"].ToString();
                        r2["stt"] = (r3["tt"].ToString().Trim() == "") ? "0" : r3["tt"].ToString();
                        if (i_tt == 0)
                        {
                            r2["idnn"] = r3["idnn"].ToString();
                            r2["noingoai"] = r3["noingoai"].ToString();
                        }
                        else if (i_tt == 1)
                        {
                            r4 = d.getrowbyid(dtdmkho, "id=" + int.Parse(r["makho"].ToString()));
                            if (r4 != null)
                            {
                                r2["idnn"] = r["makho"].ToString();
                                r2["noingoai"] = r4["ten"].ToString();
                            }
                        }
                        r2["slxuat_ck"] = r["soluong"].ToString();
                        r2["stxuat_ck"] = r["sotien"].ToString();
                        r2["slnhap_ck"] = 0;
                        r2["stnhap_ck"] = 0;
                        r2["slnhap"] = 0;
                        r2["stnhap"] = 0;
                        r2["sl_tra"] = 0;
                        r2["st_tra"] = 0;
                        r2["vat"] = r["vat"].ToString();
                        ds.Tables[0].Rows.Add(r2);
                    }
                }
                else
                {
                    DataRow[] dr = ds.Tables[0].Select(exp);
                    dr[0]["slxuat_ck"] = decimal.Parse(dr[0]["slxuat_ck"].ToString()) + decimal.Parse(r["soluong"].ToString());
                    dr[0]["stxuat_ck"] = decimal.Parse(dr[0]["stxuat_ck"].ToString()) + decimal.Parse(r["sotien"].ToString());
                }
            }
            //
            sql = "select ";
            if (i_tt == 1) sql += " b.makho,";
            if (bGiaban)
            {
                if (bGiabandot) sql += "b.giaban,";
                else sql += "c.giaban,";
            }
            else sql += "0 as giaban,";
            if (chkGiachuaVAT.Checked)
            {
                sql += "b.mabd,trunc(d.gianovat," + i_dongiale + ") as dongia, d.manguon,";
                sql += "sum(b.soluong) as soluong,sum(b.soluong*d.gianovat) as sotien ";
            }
            else
            {
                sql += "b.mabd,trunc(d.giamua," + i_dongiale + ") as dongia, d.manguon,";
                sql += "sum(b.soluong) as soluong,sum(b.soluong*d.giamua) as sotien ";
            }
            //
            if (chkNhacc.Checked) sql += ", d.nhomcc as manhacc, ncc.ten as tennhacc ";
            else sql += ", 0 as manhacc, null as tennhacc ";
            sql += ",case when d.gianovat=0 then 0 else (round(d.giamua/d.gianovat,2)-1)*100 end as vat ";
            sql += "from " + xxx + ".d_chuyenll a," + xxx + ".d_chuyenct b, " + user + ".d_dmbd c," + xxx + ".d_theodoi d ";
            if (chkNhacc.Checked) sql += ", " + user + ".d_dmnx ncc";
            sql += " where a.id=b.id and b.mabd=c.id and b.stttchuyen=d.id and a.nhom=" + i_nhom + " and b.soluong>0";
            if (chkNhacc.Checked) sql += " and d.nhomcc=ncc.id ";
            sql += " and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + s_tungay + "','dd/mm/yyyy') and to_date('" + s_denngay + "','dd/mm/yyyy')";
            if (s_kho != "") sql += " and b.makho in (" + s_kho.Substring(0, s_kho.Length - 1) + ")";
            if (s_manhom != "") sql += " and c.manhom in (" + s_manhom.Substring(0, s_manhom.Length - 1) + ")";
            if (s_maduocbv != "") sql += " and c.nhombo in (" + s_maduocbv.Trim().Trim(',') + ")";
            if (manguon.SelectedIndex != -1) sql += " and b.nguonchuyen=" + int.Parse(manguon.SelectedValue.ToString());

            sql += " group by ";
            if (i_tt == 1) sql += "b.makho,";
            if (bGiaban)
            {
                if (bGiabandot) sql += "b.giaban,";
                else sql += "c.giaban,";
            }
            if (chkGiachuaVAT.Checked)
            {
                sql += "b.mabd,trunc(d.gianovat," + i_dongiale + "),d.manguon ";
            }
            else
            {
                sql += "b.mabd,trunc(d.giamua," + i_dongiale + "),d.manguon ";
            }
            if (chkNhacc.Checked) sql += ", d.nhomcc, ncc.ten";
            sql += ",case when d.gianovat=0 then 0 else (round(d.giamua/d.gianovat,2)-1)*100 end ";
            foreach (DataRow r in d.get_data(sql).Tables[0].Rows)
            {
                exp = "mabd=" + int.Parse(r["mabd"].ToString()) + " and dongia=" + decimal.Parse(r["dongia"].ToString());
                if (manguon.SelectedIndex != -1) exp += " and manguon=" + int.Parse(manguon.SelectedValue.ToString());
                if (i_tt == 1) exp += " and idnn=" + int.Parse(r["makho"].ToString());
                r1 = d.getrowbyid(ds.Tables[0], exp);
                if (r1 == null)
                {
                    r3 = d.getrowbyid(dt, "id=" + int.Parse(r["mabd"].ToString()));
                    if (r3 != null)
                    {
                        r2 = ds.Tables[0].NewRow();
                        r2["manhom"] = r3["manhom"].ToString();
                        r2["tennhom"] = r3["tennhom"].ToString();
                        r2["mabd"] = r["mabd"].ToString();
                        r2["ma"] = r3["ma"].ToString();
                        r2["ten"] = r3["ten"].ToString().Trim() + " " + r3["hamluong"].ToString();
                        if (i_tt == 0) r2["tenhc"] = r3["tenhc"].ToString();
                        else r2["tenhc"] = "";
                        r2["noingoai"] = "";
                        r2["dang"] = r3["dang"].ToString();
                        r2["tondau"] = 0;
                        r2["sttondau"] = 0;
                        r2["slxuat"] = 0;
                        r2["stxuat"] = 0;
                        r2["dongia"] = r["dongia"].ToString();
                        r2["giaban"] = r["giaban"].ToString();
                        r2["sttt"] = 0;
                        r2["manguon"] = r["manguon"].ToString();
                        r2["stt"] = (r3["tt"].ToString().Trim() == "") ? "0" : r3["tt"].ToString();
                        if (i_tt == 0)
                        {
                            r2["idnn"] = r3["idnn"].ToString();
                            r2["noingoai"] = r3["noingoai"].ToString();
                        }
                        else if (i_tt == 1)
                        {
                            r4 = d.getrowbyid(dtdmkho, "id=" + int.Parse(r["makho"].ToString()));
                            if (r4 != null)
                            {
                                r2["idnn"] = r["makho"].ToString();
                                r2["noingoai"] = r4["ten"].ToString();
                            }
                        }
                        r2["slnhap_ck"] = r["soluong"].ToString();
                        r2["stnhap_ck"] = r["sotien"].ToString();
                        r2["slxuat_ck"] = 0;
                        r2["stxuat_ck"] = 0;
                        r2["slnhap"] = 0;
                        r2["stnhap"] = 0;
                        r2["sl_tra"] = 0;
                        r2["st_tra"] = 0;
                        r2["vat"] = r["vat"].ToString();
                        ds.Tables[0].Rows.Add(r2);
                    }
                }
                else
                {
                    DataRow[] dr = ds.Tables[0].Select(exp);
                    dr[0]["slnhap_ck"] = decimal.Parse(dr[0]["slnhap_ck"].ToString()) + decimal.Parse(r["soluong"].ToString());
                    dr[0]["stnhap_ck"] = decimal.Parse(dr[0]["stnhap_ck"].ToString()) + decimal.Parse(r["sotien"].ToString());
                }
            }
            ds.AcceptChanges();
        }
        private void get_chuyennguon(string d_mmyy)
        {
            xxx = user + d_mmyy;
            sql = "select ";
            if (i_tt == 1) sql += "b.makho,";
            if (bGiaban)
            {
                if (bGiabandot) sql += "b.giaban,";
                else sql += "c.giaban,";
            }
            else sql += "0 as giaban,";
            if (chkGiachuaVAT.Checked)
            {
                sql += "b.mabd,trunc(d.gianovat," + i_dongiale + ") as dongia, d.manguon,";
                sql += "sum(b.soluong) as soluong,sum(b.soluong*d.gianovat) as sotien ";
            }
            else
            {
                sql += "b.mabd,trunc(d.giamua," + i_dongiale + ") as dongia, d.manguon,";
                sql += "sum(b.soluong) as soluong,sum(b.soluong*d.giamua) as sotien ";
            }
            if (chkNhacc.Checked) sql += ", d.nhomcc as manhacc, ncc.ten as tennhacc ";
            else sql+=", 0 as manhacc, null as tennhacc ";
            sql += ",case when d.gianovat=0 then 0 else (round(d.giamua/d.gianovat,2)-1)*100 end as vat ";
            //
            sql += " from " + xxx + ".d_chuyenll a," + xxx + ".d_chuyenct b, " + user + ".d_dmbd c," + xxx + ".d_theodoi d ";
            if (chkNhacc.Checked) sql += ", " + user + ".d_dmnx ncc";
            sql += " where a.id=b.id and b.mabd=c.id and b.sttt=d.id and a.nhom=" + i_nhom + " and b.soluong>0";
            if (chkNhacc.Checked) sql += " and d.nhomcc=ncc.id ";
            if (s_kho != "") sql += " and b.makho in (" + s_kho.Substring(0, s_kho.Length - 1) + ")";
            if (s_manhom != "") sql += " and c.manhom in (" + s_manhom.Substring(0, s_manhom.Length - 1) + ")";
            if (s_maduocbv != "") sql += " and c.nhombo in (" + s_maduocbv.Trim().Trim(',') + ")";
            if (manguon.SelectedIndex != -1) sql += " and d.manguon=" + int.Parse(manguon.SelectedValue.ToString());
            sql += " group by ";
            if (i_tt == 1) sql += "b.makho,";
            if (bGiaban)
            {
                if (bGiabandot) sql += "b.giaban,";
                else sql += "c.giaban,";
            }
            if (chkGiachuaVAT.Checked)
            {
                sql += "b.mabd,trunc(d.gianovat," + i_dongiale + "),d.manguon ";
            }
            else
            {
                sql += "b.mabd,trunc(d.giamua," + i_dongiale + "),d.manguon ";
            }
            if (chkNhacc.Checked) sql += ", d.nhomcc, ncc.ten";
            sql += ",case when d.gianovat=0 then 0 else (round(d.giamua/d.gianovat,2)-1)*100 end ";
            foreach (DataRow r in d.get_data(sql).Tables[0].Rows)
            {
                exp = "mabd=" + int.Parse(r["mabd"].ToString());
                exp += " and dongia=" + decimal.Parse(r["dongia"].ToString());
                if (manguon.SelectedIndex != -1) exp += " and manguon=" + int.Parse(manguon.SelectedValue.ToString());
                if (i_tt == 1) exp += " and idnn=" + int.Parse(r["makho"].ToString());
                r1 = d.getrowbyid(ds.Tables[0], exp);
                if (r1 == null)
                {
                    r3 = d.getrowbyid(dt, "id=" + int.Parse(r["mabd"].ToString()));
                    if (r3 != null)
                    {
                        r2 = ds.Tables[0].NewRow();
                        r2["manhom"] = r3["manhom"].ToString();
                        r2["tennhom"] = r3["tennhom"].ToString();
                        r2["mabd"] = r["mabd"].ToString();
                        r2["ma"] = r3["ma"].ToString();
                        r2["ten"] = r3["ten"].ToString().Trim() + " " + r3["hamluong"].ToString();
                        if (i_tt == 0) r2["tenhc"] = r3["tenhc"].ToString();
                        else r2["tenhc"] = "";
                        r2["manhacc"] = r["manhacc"].ToString();
                        r2["tennhacc"] = r["tennhacc"].ToString();
                        r2["noingoai"] = "";
                        r2["dang"] = r3["dang"].ToString();
                        r2["tondau"] = 0;
                        r2["sttondau"] = 0;
                        r2["slxuat"] = 0;
                        r2["stxuat"] = 0;
                        r2["dongia"] = r["dongia"].ToString();
                        r2["giaban"] = r["giaban"].ToString();
                        r2["sttt"] = 0;
                        r2["manguon"] = r["manguon"].ToString();
                        r2["stt"] = (r3["tt"].ToString().Trim() == "") ? "0" : r3["tt"].ToString();
                        if (i_tt == 0)
                        {
                            r2["idnn"] = r3["idnn"].ToString();
                            r2["noingoai"] = r3["noingoai"].ToString();
                        }
                        else if (i_tt == 1)
                        {
                            r4 = d.getrowbyid(dtdmkho, "id=" + int.Parse(r["makho"].ToString()));
                            if (r4 != null)
                            {
                                r2["idnn"] = r["makho"].ToString();
                                r2["noingoai"] = r4["ten"].ToString();
                            }
                        }
                        r2["slxuat_ck"] = r["soluong"].ToString();
                        r2["stxuat_ck"] = r["sotien"].ToString();
                        r2["slnhap_ck"] = 0;
                        r2["stnhap_ck"] = 0;
                        r2["slnhap"] = 0;
                        r2["stnhap"] = 0;
                        r2["sl_tra"] = 0;
                        r2["st_tra"] = 0;
                        r2["vat"] = r["vat"].ToString();
                        ds.Tables[0].Rows.Add(r2);
                    }
                }
                else
                {
                    DataRow[] dr = ds.Tables[0].Select(exp);
                    dr[0]["slxuat_ck"] = decimal.Parse(dr[0]["slxuat_ck"].ToString()) + decimal.Parse(r["soluong"].ToString());
                    dr[0]["stxuat_ck"] = decimal.Parse(dr[0]["stxuat_ck"].ToString()) + decimal.Parse(r["sotien"].ToString());
                }
            }
            // 
            sql = "select ";
            if (i_tt == 1) sql += " b.makho,";
            if (bGiaban)
            {
                if (bGiabandot) sql += "b.giaban,";
                else sql += "c.giaban,";
            }
            else sql += "0 as giaban,";
            if (chkGiachuaVAT.Checked)
            {
                sql += "b.mabd,trunc(d.gianovat," + i_dongiale + ") as dongia, d.manguon,";
                sql += "sum(b.soluong) as soluong,sum(b.soluong*d.gianovat) as sotien ";
            }
            else
            {
                sql += "b.mabd,trunc(d.giamua," + i_dongiale + ") as dongia, d.manguon,";
                sql += "sum(b.soluong) as soluong,sum(b.soluong*d.giamua) as sotien ";
            }
            //
            if (chkNhacc.Checked) sql += ", d.nhomcc as manhacc, ncc.ten as tennhacc ";
            else sql+=", 0 as manhacc, null as tennhacc ";
            sql += ",case when d.gianovat=0 then 0 else (round(d.giamua/d.gianovat,2)-1)*100 end as vat ";
            sql += "from " + xxx + ".d_chuyenll a," + xxx + ".d_chuyenct b, " + user + ".d_dmbd c," + xxx + ".d_theodoi d ";
            if (chkNhacc.Checked) sql += ", " + user + ".d_dmnx ncc";
            sql += " where a.id=b.id and b.mabd=c.id and b.stttchuyen=d.id and a.nhom=" + i_nhom + " and b.soluong>0";
            if (chkNhacc.Checked) sql += " and d.nhomcc=ncc.id ";
            if (s_kho != "") sql += " and b.makho in (" + s_kho.Substring(0, s_kho.Length - 1) + ")";
            if (s_manhom != "") sql += " and c.manhom in (" + s_manhom.Substring(0, s_manhom.Length - 1) + ")";
            if (s_maduocbv != "") sql += " and c.nhombo in (" + s_maduocbv.Trim().Trim(',') + ")";
            if (manguon.SelectedIndex != -1) sql += " and b.nguonchuyen=" + int.Parse(manguon.SelectedValue.ToString());

            sql += " group by ";
            if (i_tt == 1) sql += "b.makho,";
            if (bGiaban)
            {
                if (bGiabandot) sql += "b.giaban,";
                else sql += "c.giaban,";
            }
            if (chkGiachuaVAT.Checked)
            {
                sql += "b.mabd,trunc(d.gianovat," + i_dongiale + "),d.manguon ";
            }
            else
            {
                sql += "b.mabd,trunc(d.giamua," + i_dongiale + "),d.manguon ";
            }
            if (chkNhacc.Checked) sql += ", d.nhomcc, ncc.ten";
            sql += ",case when d.gianovat=0 then 0 else (round(d.giamua/d.gianovat,2)-1)*100 end ";
            foreach (DataRow r in d.get_data(sql).Tables[0].Rows)
            {
                exp = "mabd=" + int.Parse(r["mabd"].ToString()) + " and dongia=" + decimal.Parse(r["dongia"].ToString());
                if (manguon.SelectedIndex != -1) exp += " and manguon=" + int.Parse(manguon.SelectedValue.ToString());
                if (i_tt == 1) exp += " and idnn=" + int.Parse(r["makho"].ToString());
                r1 = d.getrowbyid(ds.Tables[0], exp);
                if (r1 == null)
                {
                    r3 = d.getrowbyid(dt, "id=" + int.Parse(r["mabd"].ToString()));
                    if (r3 != null)
                    {
                        r2 = ds.Tables[0].NewRow();
                        r2["manhom"] = r3["manhom"].ToString();
                        r2["tennhom"] = r3["tennhom"].ToString();
                        r2["mabd"] = r["mabd"].ToString();
                        r2["ma"] = r3["ma"].ToString();
                        r2["ten"] = r3["ten"].ToString().Trim() + " " + r3["hamluong"].ToString();
                        if (i_tt == 0) r2["tenhc"] = r3["tenhc"].ToString();
                        else r2["tenhc"] = "";
                        r2["noingoai"] = "";
                        r2["dang"] = r3["dang"].ToString();
                        r2["tondau"] = 0;
                        r2["sttondau"] = 0;
                        r2["slxuat"] = 0;
                        r2["stxuat"] = 0;
                        r2["dongia"] = r["dongia"].ToString();
                        r2["giaban"] = r["giaban"].ToString();
                        r2["sttt"] = 0;
                        r2["manguon"] = r["manguon"].ToString();
                        r2["stt"] = (r3["tt"].ToString().Trim() == "") ? "0" : r3["tt"].ToString();
                        if (i_tt == 0)
                        {
                            r2["idnn"] = r3["idnn"].ToString();
                            r2["noingoai"] = r3["noingoai"].ToString();
                        }
                        else if (i_tt == 1)
                        {
                            r4 = d.getrowbyid(dtdmkho, "id=" + int.Parse(r["makho"].ToString()));
                            if (r4 != null)
                            {
                                r2["idnn"] = r["makho"].ToString();
                                r2["noingoai"] = r4["ten"].ToString();
                            }
                        }
                        r2["slnhap_ck"] = r["soluong"].ToString();
                        r2["stnhap_ck"] = r["sotien"].ToString();
                        r2["slxuat_ck"] = 0;
                        r2["stxuat_ck"] = 0;
                        r2["slnhap"] = 0;
                        r2["stnhap"] = 0;
                        r2["sl_tra"] = 0;
                        r2["st_tra"] = 0;
                        r2["vat"] = r["vat"].ToString();
                        ds.Tables[0].Rows.Add(r2);
                    }
                }
                else
                {
                    DataRow[] dr = ds.Tables[0].Select(exp);
                    dr[0]["slnhap_ck"] = decimal.Parse(dr[0]["slnhap_ck"].ToString()) + decimal.Parse(r["soluong"].ToString());
                    dr[0]["stnhap_ck"] = decimal.Parse(dr[0]["stnhap_ck"].ToString()) + decimal.Parse(r["sotien"].ToString());
                }
            }
            ds.AcceptChanges();
        }

        private void get_nhap(string d_mmyy)
        {
            string asql = "";
            xxx = user + d_mmyy;
            
            #region nhap moi + tai nhap
            sql = "select ";
            if (i_tt == 1) sql += " a.makho,";
            if (bGiaban)
            {
                if (bGiabandot) sql += "b.giaban,";
                else sql += "c.giaban,";
            }
            else sql += "0 as giaban,";
            if (chkGiachuaVAT.Checked)
            {
                sql += "0 as loai,b.mabd,trunc(b.dongia," + i_dongiale + ") as dongia,a.manguon,";
                sql += "sum(b.soluong) as soluong,sum(b.soluong*b.dongia+b.cuocvc+b.chaythu) as sotien ";
            }
            else
            {
                sql += "0 as loai,b.mabd,trunc(b.giamua," + i_dongiale + ") as dongia,a.manguon,";
                sql += "sum(b.soluong) as soluong,sum(b.sotien+b.sotien*b.vat/100+b.cuocvc+b.chaythu) as sotien ";
            }
            if (chkNhacc.Checked) sql += ", a.madv as manhacc, ncc.ten as tennhacc ";
            else sql+=", 0 as manhacc, null as tennhacc ";            
            //
            sql += ", b.vat ";
            sql += "from " + xxx + ".d_nhapll a," + xxx + ".d_nhapct b," + user + ".d_dmbd c ";
            if (chkNhacc.Checked) sql += ", " + user + ".d_dmnx ncc";                        
            sql += " where a.id=b.id and b.mabd=c.id and a.nhom=" + i_nhom + "  and b.soluong>0";
            if (chkNhacc.Checked) sql += " and a.madv=ncc.id ";
            if (s_kho != "") sql += " and a.makho in (" + s_kho.Substring(0, s_kho.Length - 1) + ")";
            if (s_manhom != "") sql += " and c.manhom in (" + s_manhom.Substring(0, s_manhom.Length - 1) + ")";
            if (s_maduocbv != "") sql += " and c.nhombo in (" + s_maduocbv.Trim().Trim(',') + ")";
            if (manguon.SelectedIndex != -1) sql += " and a.manguon=" + int.Parse(manguon.SelectedValue.ToString());

            sql += " group by ";
            if (i_tt == 1) sql += "a.makho,";
            if (bGiaban)
            {
                if (bGiabandot) sql += "b.giaban,";
                else sql += "c.giaban,";
            }
            if (chkGiachuaVAT.Checked)
            {
                sql += "b.mabd,trunc(b.dongia," + i_dongiale + "),a.manguon";
            }
            else
            {
                sql += "b.mabd,trunc(b.giamua," + i_dongiale + "),a.manguon";
            }
            if (chkNhacc.Checked) sql += ", a.madv, ncc.ten";
            sql += ", b.vat ";
            #endregion nhap moi + tai nhap

            if (s_khott == "")
            {

                #region lay so lieu nhap do chuyen kho
                sql += " union all select ";
                if (i_tt == 1) sql += "a.khon as makho,";
                if (bGiaban)
                {
                    if (bGiabandot) sql += "b.giaban,";
                    else sql += "c.giaban,";
                }
                else sql += "0 as giaban,";
                //
                if (chkchuyenkho.Checked)//nhap chuyen kho khong tinh vao cot nhap
                {
                    sql += "1 as loai, ";
                }
                else
                {
                    sql += "0 as loai, ";
                }
                //
                if (chkGiachuaVAT.Checked)
                {
                    sql += "b.mabd,trunc(d.gianovat," + i_dongiale + ") as dongia, d.manguon,";
                    sql += "sum(b.soluong) as soluong,sum(b.soluong*d.gianovat) as sotien ";
                }
                else
                {
                    sql += "b.mabd,trunc(d.giamua," + i_dongiale + ") as dongia, d.manguon,";
                    sql += "sum(b.soluong) as soluong,sum(b.soluong*d.giamua) as sotien ";
                }
                if (chkNhacc.Checked) sql += ", d.nhomcc as manhacc, ncc.ten as tennhacc ";
                else sql += ", 0 as manhacc, null as tennhacc ";
                //
                sql += ",case when d.gianovat=0 then 0 else (round(d.giamua/d.gianovat,2)-1)*100 end as vat ";
                sql += "from " + xxx + ".d_xuatll a," + xxx + ".d_xuatct b, " + user + ".d_dmbd c," + xxx + ".d_theodoi d ";
                if (chkNhacc.Checked) sql += ", " + user + ".d_dmnx ncc";
                sql += " where a.id=b.id and b.mabd=c.id and b.sttt=d.id and a.nhom=" + i_nhom + " and a.loai in ('CK') and b.soluong>0";
                if (chkNhacc.Checked) sql += " and d.nhomcc=ncc.id ";
                if (s_kho != "") sql += " and a.khon in (" + s_kho.Substring(0, s_kho.Length - 1) + ")";
                if (s_kho != "") sql += " and a.khox not in (" + s_kho.Substring(0, s_kho.Length - 1) + ")";
                if (s_manhom != "") sql += " and c.manhom in (" + s_manhom.Substring(0, s_manhom.Length - 1) + ")";
                if (s_maduocbv != "") sql += " and c.nhombo in (" + s_maduocbv.Trim().Trim(',') + ")";
                if (manguon.SelectedIndex != -1) sql += " and d.manguon=" + int.Parse(manguon.SelectedValue.ToString());
                //// trang them 060310
                //sql += " and to_date(d.ngayud,'dd/mm/yy') between to_date('" + d_tu.Text.Substring(0, 10) + "','dd/mm/yy') and to_date('" + d_den.Text.Substring(0, 10) + "','dd/mm/yy') ";
                //// end
                sql += " group by ";
                if (i_tt == 1) sql += "a.khon,";
                if (bGiaban)
                {
                    if (bGiabandot) sql += "b.giaban,";
                    else sql += "c.giaban,";
                }
                if (chkGiachuaVAT.Checked)
                {
                    sql += "b.mabd,trunc(d.gianovat," + i_dongiale + "),d.manguon ";
                }
                else
                {
                    sql += "b.mabd,trunc(d.giamua," + i_dongiale + "),d.manguon ";
                }
                if (chkNhacc.Checked) sql += ", d.nhomcc, ncc.ten";
                sql += ",case when d.gianovat=0 then 0 else (round(d.giamua/d.gianovat,2)-1)*100 end";
                #endregion lay so lieu nhap do chuyen kho

                #region lay so lieu thu hoi co so tu truc + hoan tra tu truc
                asql = "  select ";
                if (i_tt == 1) asql += "a.khon as makho,";
                if (bGiaban)
                {
                    if (bGiabandot) asql += "b.giaban,";
                    else asql += "c.giaban,";
                }
                else asql += "0 as giaban,";
                if (chkGiachuaVAT.Checked)
                {
                    asql += "0 as loai,b.mabd,trunc(d.gianovat," + i_dongiale + ") as dongia, d.manguon,";
                    asql += "sum(b.soluong) as soluong,sum(b.soluong*d.gianovat) as sotien ";
                }
                else
                {
                    asql += "0 as loai,b.mabd,trunc(d.giamua," + i_dongiale + ") as dongia, d.manguon,";
                    asql += "sum(b.soluong) as soluong,sum(b.soluong*d.giamua) as sotien ";
                }
                if (chkNhacc.Checked) asql += ", d.nhomcc as manhacc, ncc.ten as tennhacc ";
                else asql += ", 0 as manhacc, null as tennhacc ";
                asql += ",case when d.gianovat=0 then 0 else (round(d.giamua/d.gianovat,2)-1)*100 end as vat ";
                //
                asql += "from " + xxx + ".d_xuatll a," + xxx + ".d_xuatct b, " + user + ".d_dmbd c," + xxx + ".d_theodoi d ";
                if (chkNhacc.Checked) asql += ", " + user + ".d_dmnx ncc";
                asql += " where a.id=b.id and b.mabd=c.id and b.sttt=d.id and a.nhom=" + i_nhom + " and a.loai in ('HT','TH') and b.soluong>0";
                if (chkNhacc.Checked) asql += " and d.nhomcc=ncc.id ";
                if (s_kho != "") asql += " and a.khon in (" + s_kho.Substring(0, s_kho.Length - 1) + ")";
                if (s_manhom != "") asql += " and c.manhom in (" + s_manhom.Substring(0, s_manhom.Length - 1) + ")";
                if (s_maduocbv != "") asql += " and c.nhombo in (" + s_maduocbv.Trim().Trim(',') + ")";
                if (manguon.SelectedIndex != -1) asql += " and d.manguon=" + int.Parse(manguon.SelectedValue.ToString());
                asql += " group by ";
                if (i_tt == 1) asql += "a.khon,";
                if (bGiaban)
                {
                    if (bGiabandot) asql += "b.giaban,";
                    else asql += "c.giaban,";
                }
                if (chkGiachuaVAT.Checked)
                {
                    asql += "b.mabd,trunc(d.gianovat," + i_dongiale + "),d.manguon ";
                }
                else
                {
                    asql += "b.mabd,trunc(d.giamua," + i_dongiale + "),d.manguon ";
                }
                if (chkNhacc.Checked) asql += ", d.nhomcc, ncc.ten";
                asql += ",case when d.gianovat=0 then 0 else (round(d.giamua/d.gianovat,2)-1)*100 end ";
                f_Get_Hoantra_Thuhoi_CSTT(d.get_data(asql));
                #endregion lay so lieu thu hoi co so tu truc + hoan tra tu truc

            }
            else
            {
                #region kho trung tam
                #region lay so lieu do nhap chuyen kho
                sql += " union all select ";
                if (i_tt == 1) sql += "a.khon as makho,";
                if (bGiaban)
                {
                    if (bGiabandot) sql += "b.giaban,";
                    else sql += "c.giaban,";
                }
                else sql += "0 as giaban,";
                if (chkGiachuaVAT.Checked)
                {
                    sql += "1 as loai,b.mabd,trunc(d.gianovat," + i_dongiale + ") as dongia, d.manguon,";
                    sql += "sum(b.soluong) as soluong,sum(b.soluong*d.gianovat) as sotien ";
                }
                else
                {
                    sql += "1 as loai,b.mabd,trunc(d.giamua," + i_dongiale + ") as dongia, d.manguon,";
                    sql += "sum(b.soluong) as soluong,sum(b.soluong*d.giamua) as sotien ";
                }
                if (chkNhacc.Checked) sql += ", d.nhomcc as manhacc, ncc.ten as tennhacc ";
                else sql += ", 0 as manhacc, null as tennhacc ";
                sql += ",case when d.gianovat=0 then 0 else (round(d.giamua/d.gianovat,2)-1)*100 end as vat ";
                //
                sql += "from " + xxx + ".d_xuatll a," + xxx + ".d_xuatct b, " + user + ".d_dmbd c," + xxx + ".d_theodoi d ";
                if (chkNhacc.Checked) sql += ", " + user + ".d_dmnx ncc";
                sql += " where a.id=b.id and b.mabd=c.id and b.sttt=d.id and a.nhom=" + i_nhom + " and a.loai in ('CK') and b.soluong>0";
                if (chkNhacc.Checked) sql += " and d.nhomcc=ncc.id ";
                if (s_kho != "") sql += " and a.khon in (" + s_kho.Substring(0, s_kho.Length - 1) + ")";
                if (s_kho != "") sql += " and a.khox not in (" + s_kho.Substring(0, s_kho.Length - 1) + ")";
                if (s_manhom != "") sql += " and c.manhom in (" + s_manhom.Substring(0, s_manhom.Length - 1) + ")";
                if (s_maduocbv != "") sql += " and c.nhombo in (" + s_maduocbv.Trim().Trim(',') + ")";
                if (manguon.SelectedIndex != -1) sql += " and d.manguon=" + int.Parse(manguon.SelectedValue.ToString());
                //sql += " and a.khox not in (" + s_khott.Substring(0, s_khott.Length - 1) + ")";
                //// trang them 060310
                //sql += " and to_date(d.ngayud,'dd/mm/yy') between to_date('" + d_tu.Text.Substring(0, 10) + "','dd/mm/yy') and to_date('" + d_den.Text.Substring(0, 10) + "','dd/mm/yy') ";
                //// end
                sql += " group by ";
                if (i_tt == 1) sql += "a.khon,";
                if (bGiaban)
                {
                    if (bGiabandot) sql += "b.giaban,";
                    else sql += "c.giaban,";
                }
                if (chkGiachuaVAT.Checked)
                {
                    sql += "b.mabd,trunc(d.gianovat," + i_dongiale + "),d.manguon ";
                }
                else
                {
                    sql += "b.mabd,trunc(d.giamua," + i_dongiale + "),d.manguon ";
                }
                if (chkNhacc.Checked) sql += ", d.nhomcc, ncc.ten";
                sql += ",case when d.gianovat=0 then 0 else (round(d.giamua/d.gianovat,2)-1)*100 end";
                #endregion lay so lieu do nhap chuyen kho

                #region lay so lieu thu hoi co so tu truc + hoan tra tu truc
                asql = "  select ";
                if (i_tt == 1) asql += "a.khon as makho,";
                if (bGiaban)
                {
                    if (bGiabandot) asql += "b.giaban,";
                    else asql += "c.giaban,";
                }
                else asql += "0 as giaban,";
                if (chkGiachuaVAT.Checked)
                {
                    asql += "1 as loai,b.mabd,trunc(d.gianovat," + i_dongiale + ") as dongia, d.manguon,";
                    asql += "sum(b.soluong) as soluong,sum(b.soluong*d.gianovat) as sotien ";
                }
                else
                {
                    asql += "1 as loai,b.mabd,trunc(d.giamua," + i_dongiale + ") as dongia, d.manguon,";
                    asql += "sum(b.soluong) as soluong,sum(b.soluong*d.giamua) as sotien ";
                }
                if (chkNhacc.Checked) asql += ", d.nhomcc as manhacc, ncc.ten as tennhacc ";
                else asql += ", 0 as manhacc, null as tennhacc ";
                asql += ",case when d.gianovat=0 then 0 else (round(d.giamua/d.gianovat,2)-1)*100 end as vat ";
                asql += "from " + xxx + ".d_xuatll a," + xxx + ".d_xuatct b, " + user + ".d_dmbd c," + xxx + ".d_theodoi d ";
                if (chkNhacc.Checked) asql += ", " + user + ".d_dmnx ncc";
                asql += " where a.id=b.id and b.mabd=c.id and b.sttt=d.id and a.nhom=" + i_nhom + " and a.loai in ('TH','HT') and b.soluong>0";
                if (chkNhacc.Checked) asql += " and d.nhomcc=ncc.id ";
                if (s_kho != "") asql += " and a.khon in (" + s_kho.Substring(0, s_kho.Length - 1) + ")";
                if (s_manhom != "") asql += " and c.manhom in (" + s_manhom.Substring(0, s_manhom.Length - 1) + ")";
                if (s_maduocbv != "") asql += " and c.nhombo in (" + s_maduocbv.Trim().Trim(',') + ")";
                if (manguon.SelectedIndex != -1) asql += " and d.manguon=" + int.Parse(manguon.SelectedValue.ToString());
                asql += " group by ";
                if (i_tt == 1) asql += "a.khon,";
                if (bGiaban)
                {
                    if (bGiabandot) asql += "b.giaban,";
                    else asql += "c.giaban,";
                }
                if (chkGiachuaVAT.Checked)
                {
                    asql += "b.mabd,trunc(d.gianovat," + i_dongiale + "),d.manguon ";
                }
                else
                {
                    asql += "b.mabd,trunc(d.giamua," + i_dongiale + "),d.manguon ";
                }
                if (chkNhacc.Checked) asql += ", d.nhomcc, ncc.ten ";
                asql += ",case when d.gianovat=0 then 0 else (round(d.giamua/d.gianovat,2)-1)*100 end ";
                if (!d.bChuyenkho_inrieng(i_nhom))// || kho.SelectedItems.Count == 1)
                {
                    //asql += " union all select ";
                    //if (i_tt == 1) asql += "a.khon as makho,";
                    //if (bGiaban)
                    //{
                    //    if (bGiabandot) asql += "b.giaban,";
                    //    else asql += "c.giaban,";
                    //}
                    //else asql += "0 as giaban,";
                    //if (chkGiachuaVAT.Checked)
                    //{
                    //    asql += "1 as loai,b.mabd,trunc(d.gianovat," + i_dongiale + ") as dongia,d.manguon,";
                    //    asql += "sum(b.soluong) as soluong,sum(b.soluong*d.gianovat) as sotien ";
                    //}
                    //else
                    //{
                    //    asql += "1 as loai,b.mabd,trunc(d.giamua," + i_dongiale + ") as dongia,d.manguon,";
                    //    asql += "sum(b.soluong) as soluong,sum(b.soluong*d.giamua) as sotien ";
                    //}
                    //asql += "from " + xxx + ".d_xuatll a," + xxx + ".d_xuatct b, " + user + ".d_dmbd c," + xxx + ".d_theodoi d where a.id=b.id and b.mabd=c.id and b.sttt=d.id and a.nhom=" + i_nhom + " and a.loai in ('CK','HT','TH') and b.soluong>0";
                    //if (s_kho != "") asql += " and a.khon in (" + s_kho.Substring(0, s_kho.Length - 1) + ")";
                    //if (s_manhom != "") asql += " and c.manhom in (" + s_manhom.Substring(0, s_manhom.Length - 1) + ")";
                    //if (manguon.SelectedIndex != -1) asql += " and d.manguon=" + int.Parse(manguon.SelectedValue.ToString());
                    //asql += " and b.soluong>0 and a.khox in (" + s_khott.Substring(0, s_khott.Length - 1) + ")";
                    //asql += " group by ";
                    //if (i_tt == 1) asql += "a.khon,";
                    //if (bGiaban)
                    //{
                    //    if (bGiabandot) asql += "b.giaban,";
                    //    else sql += "c.giaban,";
                    //}
                    //if (chkGiachuaVAT.Checked)
                    //{
                    //    asql += "b.mabd,trunc(d.gianovat," + i_dongiale + "),d.manguon ";
                    //}
                    //else
                    //{
                    //    asql += "b.mabd,trunc(d.giamua," + i_dongiale + "),d.manguon ";
                    //}
                }
                f_Get_Hoantra_Thuhoi_CSTT(d.get_data(asql));

                #endregion lay so lieu thu hoi co so tu truc + hoan tra tu truc

                #endregion  kho trung tam
            }

            #region insert item
            string f1 = "slnhap", f2 = "stnhap";
            foreach (DataRow r in d.get_data(sql).Tables[0].Rows)
            {
                r3 = d.getrowbyid(dt, "id=" + int.Parse(r["mabd"].ToString()));
                if (r3 != null)
                {
                    f1 = "slnhap"; f2 = "stnhap";
                    if (r["loai"].ToString() == "1" && !bGiaban)
                    {
                        f1 += "_ck"; f2 += "_ck";
                    }
        
                    exp = "mabd=" + int.Parse(r["mabd"].ToString());
                    exp += " and dongia=" + decimal.Parse(r["dongia"].ToString());
                    if (manguon.SelectedIndex != -1) exp += " and manguon=" + int.Parse(manguon.SelectedValue.ToString());
                    if (i_tt == 1) exp += " and idnn=" + int.Parse(r["makho"].ToString());
                    r1 = d.getrowbyid(ds.Tables[0], exp);
                    if (r1 == null)
                    {
                        r2 = ds.Tables[0].NewRow();
                        r2["manhom"] = r3["manhom"].ToString();
                        r2["tennhom"] = r3["tennhom"].ToString();
                        r2["mabd"] = r["mabd"].ToString();
                        r2["ma"] = r3["ma"].ToString();
                        r2["ten"] = r3["ten"].ToString().Trim() + " " + r3["hamluong"].ToString();
                        if (i_tt == 0) r2["tenhc"] = r3["tenhc"].ToString();
                        else r2["tenhc"] = "";
                        r2["manhacc"] = r["manhacc"].ToString();
                        r2["tennhacc"] = r["tennhacc"].ToString();
                        r2["noingoai"] = "";
                        r2["dang"] = r3["dang"].ToString();
                        r2["tondau"] = 0;
                        r2["sttondau"] = 0;
                        r2["slxuat"] = 0;
                        r2["stxuat"] = 0;
                        r2["sl_tra"] = 0;
                        r2["st_tra"] = 0;
                        r2["dongia"] = r["dongia"].ToString();
                        r2["giaban"] = r["giaban"].ToString();
                        r2["sttt"] = 0;
                        r2["manguon"] = r["manguon"].ToString();
                        r2["stt"] = (r3["tt"].ToString().Trim() == "") ? "0" : r3["tt"].ToString();
                        if (i_tt == 0)
                        {
                            r2["idnn"] = r3["idnn"].ToString();
                            r2["noingoai"] = r3["noingoai"].ToString();
                        }
                        else if (i_tt == 1)
                        {
                            r4 = d.getrowbyid(dtdmkho, "id=" + int.Parse(r["makho"].ToString()));
                            if (r4 != null)
                            {
                                r2["idnn"] = r["makho"].ToString();
                                r2["noingoai"] = r4["ten"].ToString();
                            }
                        }
                        r2["slxuat_ck"] = "0";
                        r2["stxuat_ck"] = "0";
                        r2["slnhap_ck"] = "0";
                        r2["stnhap_ck"] = "0";
                        r2["slnhap"] = "0";
                        r2["stnhap"] = "0";
                        r2["sl_th"] = "0";
                        r2["st_th"] = "0";
                        r2[f1] = r["soluong"].ToString();
                        r2[f2] = r["sotien"].ToString();
                        r2["vat"] = r["vat"].ToString();
                        ds.Tables[0].Rows.Add(r2);
                    }
                    else
                    {
                        DataRow[] dr = ds.Tables[0].Select(exp);
                        dr[0][f1] = decimal.Parse(dr[0][f1].ToString()) + decimal.Parse(r["soluong"].ToString());
                        dr[0][f2] = decimal.Parse(dr[0][f2].ToString()) + decimal.Parse(r["sotien"].ToString());
                    }
                }
            }
            ds.AcceptChanges();
            #endregion insert item

        }
        // nhap theo ngay
        private void get_nhap_ddmmyy(string d_mmyy, string s_tungay, string s_denngay)
        {
            string asql = "";
            xxx = user + d_mmyy;

            #region nhap moi + tai nhap
            sql = "select ";
            if (i_tt == 1) sql += " a.makho,";
            if (bGiaban)
            {
                if (bGiabandot) sql += "b.giaban,";
                else sql += "c.giaban,";
            }
            else sql += "0 as giaban,";
            if (chkGiachuaVAT.Checked)
            {
                sql += "0 as loai,b.mabd,trunc(b.dongia," + i_dongiale + ") as dongia,a.manguon,";
                sql += "sum(b.soluong) as soluong,sum(b.soluong*b.dongia+b.cuocvc+b.chaythu) as sotien ";
            }
            else
            {
                sql += "0 as loai,b.mabd,trunc(b.giamua," + i_dongiale + ") as dongia,a.manguon,";
                sql += "sum(b.soluong) as soluong,sum(b.sotien+b.sotien*b.vat/100+b.cuocvc+b.chaythu) as sotien ";
            }
            if (chkNhacc.Checked) sql += ", a.madv as manhacc, ncc.ten as tennhacc ";
            else sql += ", 0 as manhacc, null as tennhacc ";
            sql += ", b.vat ";
            //
            sql += "from " + xxx + ".d_nhapll a," + xxx + ".d_nhapct b," + user + ".d_dmbd c ";
            if (chkNhacc.Checked) sql += ", " + user + ".d_dmnx ncc";
            sql += " where a.id=b.id and b.mabd=c.id and a.nhom=" + i_nhom + "  and b.soluong>0";        
            sql += " and to_date(to_char(a.ngaysp,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" +s_tungay + "','dd/mm/yyyy') and to_date('" + s_denngay + "','dd/mm/yyyy')";
            if (chkNhacc.Checked) sql += " and a.madv=ncc.id ";
            if (s_kho != "") sql += " and a.makho in (" + s_kho.Substring(0, s_kho.Length - 1) + ")";
            if (s_manhom != "") sql += " and c.manhom in (" + s_manhom.Substring(0, s_manhom.Length - 1) + ")";
            if (s_maduocbv != "") sql += " and c.nhombo in (" + s_maduocbv.Trim().Trim(',') + ")";
            if (manguon.SelectedIndex != -1) sql += " and a.manguon=" + int.Parse(manguon.SelectedValue.ToString());

            sql += " group by ";
            if (i_tt == 1) sql += "a.makho,";
            if (bGiaban)
            {
                if (bGiabandot) sql += "b.giaban,";
                else sql += "c.giaban,";
            }
            if (chkGiachuaVAT.Checked)
            {
                sql += "b.mabd,trunc(b.dongia," + i_dongiale + "),a.manguon";
            }
            else
            {
                sql += "b.mabd,trunc(b.giamua," + i_dongiale + "),a.manguon";
            }
            if (chkNhacc.Checked) sql += ", a.madv, ncc.ten";
            sql += ",b.vat ";
            #endregion nhap moi + tai nhap

            if (s_khott == "")
            {
                #region khong la kho trung tam
                #region lay so lieu nhap do chuyen kho
                sql += " union all select ";
                if (i_tt == 1) sql += "a.khon as makho,";
                if (bGiaban)
                {
                    if (bGiabandot) sql += "b.giaban,";
                    else sql += "c.giaban,";
                }
                else sql += "0 as giaban,";
                if (chkchuyenkho.Checked)sql += "1 as loai,";                
                else sql += "0 as loai,"; 

                if (chkGiachuaVAT.Checked)
                {
                    sql += "b.mabd,trunc(d.gianovat," + i_dongiale + ") as dongia, d.manguon,";
                    sql += "sum(b.soluong) as soluong,sum(b.soluong*d.gianovat) as sotien ";
                }
                else
                {
                    sql += "b.mabd,trunc(d.giamua," + i_dongiale + ") as dongia, d.manguon,";
                    sql += "sum(b.soluong) as soluong,sum(b.soluong*d.giamua) as sotien ";
                }
                if (chkNhacc.Checked) sql += ", d.nhomcc as manhacc, ncc.ten as tennhacc ";
                else sql += ", 0 as manhacc, null as tennhacc ";
                sql += ",case when d.gianovat=0 then 0 else (round(d.giamua/d.gianovat,2)-1)*100 end as vat ";
                //
                sql += "from " + xxx + ".d_xuatll a," + xxx + ".d_xuatct b, " + user + ".d_dmbd c," + xxx + ".d_theodoi d ";
                if (chkNhacc.Checked) sql += ", " + user + ".d_dmnx ncc";
                sql += " where a.id=b.id and b.mabd=c.id and b.sttt=d.id and a.nhom=" + i_nhom + " and a.loai in ('CK') and b.soluong>0";
                sql += " and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + s_tungay + "','dd/mm/yyyy') and to_date('" + s_denngay + "','dd/mm/yyyy')";
                if (chkNhacc.Checked) sql += " and d.nhomcc=ncc.id ";
                if (s_kho != "") sql += " and a.khon in (" + s_kho.Substring(0, s_kho.Length - 1) + ")";
                if (s_kho != "") sql += " and a.khox not in (" + s_kho.Substring(0, s_kho.Length - 1) + ")";
                if (s_manhom != "") sql += " and c.manhom in (" + s_manhom.Substring(0, s_manhom.Length - 1) + ")";
                if (s_maduocbv != "") sql += " and c.nhombo in (" + s_maduocbv.Trim().Trim(',') + ")";
                if (manguon.SelectedIndex != -1) sql += " and d.manguon=" + int.Parse(manguon.SelectedValue.ToString());
                //// trang them 060310
                //sql += " and to_date(d.ngayud,'dd/mm/yy') between to_date('" + d_tu.Text.Substring(0, 10) + "','dd/mm/yy') and to_date('" + d_den.Text.Substring(0, 10) + "','dd/mm/yy') ";
                //// end
                sql += " group by ";
                if (i_tt == 1) sql += "a.khon,";
                if (bGiaban)
                {
                    if (bGiabandot) sql += "b.giaban,";
                    else sql += "c.giaban,";
                }
                if (chkGiachuaVAT.Checked)
                {
                    sql += "b.mabd,trunc(d.gianovat," + i_dongiale + "),d.manguon ";
                }
                else
                {
                    sql += "b.mabd,trunc(d.giamua," + i_dongiale + "),d.manguon ";
                }
                if (chkNhacc.Checked) sql += ", d.nhomcc, ncc.ten";
                sql += ",case when d.gianovat=0 then 0 else (round(d.giamua/d.gianovat,2)-1)*100 end";
                #endregion lay so lieu nhap do chuyen kho

                #region lay so lieu thu hoi co so tu truc + hoan tra tu truc
                asql = "  select ";
                if (i_tt == 1) asql += "a.khon as makho,";
                if (bGiaban)
                {
                    if (bGiabandot) asql += "b.giaban,";
                    else asql += "c.giaban,";
                }
                else asql += "0 as giaban,";
                if (chkGiachuaVAT.Checked)
                {
                    asql += "0 as loai,b.mabd,trunc(d.gianovat," + i_dongiale + ") as dongia, d.manguon,";
                    asql += "sum(b.soluong) as soluong,sum(b.soluong*d.gianovat) as sotien ";
                }
                else
                {
                    asql += "0 as loai,b.mabd,trunc(d.giamua," + i_dongiale + ") as dongia, d.manguon,";
                    asql += "sum(b.soluong) as soluong,sum(b.soluong*d.giamua) as sotien ";
                }
                if (chkNhacc.Checked) asql += ", d.nhomcc as manhacc, ncc.ten as tennhacc ";
                else asql += ", 0 as manhacc, null as tennhacc ";
                asql += ",case when d.gianovat=0 then 0 else (round(d.giamua/d.gianovat,2)-1)*100 end as vat ";
                asql += "from " + xxx + ".d_xuatll a," + xxx + ".d_xuatct b, " + user + ".d_dmbd c," + xxx + ".d_theodoi d ";               
                if (chkNhacc.Checked) asql += ", " + user + ".d_dmnx ncc";
                asql += " where a.id=b.id and b.mabd=c.id and b.sttt=d.id and a.nhom=" + i_nhom + " and a.loai in ('HT','TH') and b.soluong>0";
                if (chkNhacc.Checked) asql += " and d.nhomcc=ncc.id ";
                asql += " and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + s_tungay + "','dd/mm/yyyy') and to_date('" + s_denngay + "','dd/mm/yyyy')";
                if (s_kho != "") asql += " and a.khon in (" + s_kho.Substring(0, s_kho.Length - 1) + ")";
                if (s_manhom != "") asql += " and c.manhom in (" + s_manhom.Substring(0, s_manhom.Length - 1) + ")";
                if (s_maduocbv != "") asql += " and c.nhombo in (" + s_maduocbv.Trim().Trim(',') + ")";
                if (manguon.SelectedIndex != -1) asql += " and d.manguon=" + int.Parse(manguon.SelectedValue.ToString());
                //// trang them 060310
                //sql += " and to_date(d.ngayud,'dd/mm/yy') between to_date('" + d_tu.Text + "','dd/mm/yy') and to_date('" + d_den.Text.Substring(0, 10) + "','dd/mm/yy') ";
                //// end
                asql += " group by ";
                if (i_tt == 1) asql += "a.khon,";
                if (bGiaban)
                {
                    if (bGiabandot) asql += "b.giaban,";
                    else asql += "c.giaban,";
                }
                if (chkGiachuaVAT.Checked)
                {
                    asql += "b.mabd,trunc(d.gianovat," + i_dongiale + "),d.manguon ";
                }
                else
                {
                    asql += "b.mabd,trunc(d.giamua," + i_dongiale + "),d.manguon ";
                }
                if (chkNhacc.Checked) asql += ", d.nhomcc, ncc.ten";
                asql += ",case when d.gianovat=0 then 0 else (round(d.giamua/d.gianovat,2)-1)*100 end ";
                f_Get_Hoantra_Thuhoi_CSTT(d.get_data(asql));
                #endregion lay so lieu thu hoi co so tu truc + hoan tra tu truc
                //}
                #endregion  khong la kho trung tam
            }
            else
            {
                #region kho trung tam
                //if (!chkKhoahoantra.Checked)
                //{
                //    #region  thu hoi tu truc + khoa tra tu truc + nhap do chuyen kho
                //    sql += " union all select ";
                //    if (i_tt == 1) sql += "a.khon as makho,";
                //    if (bGiaban)
                //    {
                //        if (bGiabandot) sql += "b.giaban,";
                //        else sql += "c.giaban,";
                //    }
                //    else sql += "0 as giaban,";
                //    if (chkGiachuaVAT.Checked)
                //    {
                //        sql += "1 as loai,b.mabd,trunc(d.gianovat," + i_dongiale + ") as dongia, d.manguon,";
                //        sql += "sum(b.soluong) as soluong,sum(b.soluong*d.gianovat) as sotien ";
                //    }
                //    else
                //    {
                //        sql += "1 as loai,b.mabd,trunc(d.giamua," + i_dongiale + ") as dongia, d.manguon,";
                //        sql += "sum(b.soluong) as soluong,sum(b.soluong*d.giamua) as sotien ";
                //    }
                //    sql += "from " + xxx + ".d_xuatll a," + xxx + ".d_xuatct b, " + user + ".d_dmbd c," + xxx + ".d_theodoi d where a.id=b.id and b.mabd=c.id and b.sttt=d.id and a.nhom=" + i_nhom + " and a.loai in ('CK','HT','TH') and b.soluong>0";
                //    if (s_kho != "") sql += " and a.khon in (" + s_kho.Substring(0, s_kho.Length - 1) + ")";
                //    if (s_kho != "") sql += " and a.khox not in (" + s_kho.Substring(0, s_kho.Length - 1) + ")";
                //    if (s_manhom != "") sql += " and c.manhom in (" + s_manhom.Substring(0, s_manhom.Length - 1) + ")";
                //    if (manguon.SelectedIndex != -1) sql += " and d.manguon=" + int.Parse(manguon.SelectedValue.ToString());
                //    sql += " and a.khox not in (" + s_khott.Substring(0, s_khott.Length - 1) + ")";
                //    sql += " group by ";
                //    if (i_tt == 1) sql += "a.khon,";
                //    if (bGiaban)
                //    {
                //        if (bGiabandot) sql += "b.giaban,";
                //        else sql += "c.giaban,";
                //    }
                //    if (chkGiachuaVAT.Checked)
                //    {
                //        sql += "b.mabd,trunc(d.gianovat," + i_dongiale + "),d.manguon ";
                //    }
                //    else
                //    {
                //        sql += "b.mabd,trunc(d.giamua," + i_dongiale + "),d.manguon ";
                //    }

                //    if (!d.bChuyenkho_inrieng(i_nhom) || kho.SelectedItems.Count == 1)
                //    {
                //        sql += " union all select ";
                //        if (i_tt == 1) sql += "a.khon as makho,";
                //        if (bGiaban)
                //        {
                //            if (bGiabandot) sql += "b.giaban,";
                //            else sql += "c.giaban,";
                //        }
                //        else sql += "0 as giaban,";
                //        if (chkGiachuaVAT.Checked)
                //        {
                //            sql += "1 as loai,b.mabd,trunc(d.gianovat," + i_dongiale + ") as dongia,d.manguon,";
                //            sql += "sum(b.soluong) as soluong,sum(b.soluong*d.gianovat) as sotien ";
                //        }
                //        else
                //        {
                //            sql += "1 as loai,b.mabd,trunc(d.giamua," + i_dongiale + ") as dongia,d.manguon,";
                //            sql += "sum(b.soluong) as soluong,sum(b.soluong*d.giamua) as sotien ";
                //        }
                //        sql += "from " + xxx + ".d_xuatll a," + xxx + ".d_xuatct b, " + user + ".d_dmbd c," + xxx + ".d_theodoi d where a.id=b.id and b.mabd=c.id and b.sttt=d.id and a.nhom=" + i_nhom + " and a.loai in ('CK','HT','TH') and b.soluong>0";
                //        if (s_kho != "") sql += " and a.khon in (" + s_kho.Substring(0, s_kho.Length - 1) + ")";
                //        if (s_manhom != "") sql += " and c.manhom in (" + s_manhom.Substring(0, s_manhom.Length - 1) + ")";
                //        if (manguon.SelectedIndex != -1) sql += " and d.manguon=" + int.Parse(manguon.SelectedValue.ToString());
                //        sql += " and b.soluong>0 and a.khox in (" + s_khott.Substring(0, s_khott.Length - 1) + ")";
                //        sql += " group by ";
                //        if (i_tt == 1) sql += "a.khon,";
                //        if (bGiaban)
                //        {
                //            if (bGiabandot) sql += "b.giaban,";
                //            else sql += "c.giaban,";
                //        }
                //        if (chkGiachuaVAT.Checked)
                //        {
                //            sql += "b.mabd,trunc(d.gianovat," + i_dongiale + "),d.manguon ";
                //        }
                //        else
                //        {
                //            sql += "b.mabd,trunc(d.giamua," + i_dongiale + "),d.manguon ";
                //        }
                //    }
                //    #endregion  thu hoi tu truc + khoa tra tu truc + nhap do chuyen kho
                //}
                //else
                //{
                #region lay so lieu do nhap chuyen kho
                sql += " union all select ";
                if (i_tt == 1) sql += "a.khon as makho,";
                if (bGiaban)
                {
                    if (bGiabandot) sql += "b.giaban,";
                    else sql += "c.giaban,";
                }
                else sql += "0 as giaban,";
                if (chkGiachuaVAT.Checked)
                {
                    sql += "1 as loai,b.mabd,trunc(d.gianovat," + i_dongiale + ") as dongia, d.manguon,";
                    sql += "sum(b.soluong) as soluong,sum(b.soluong*d.gianovat) as sotien ";
                }
                else
                {
                    sql += "1 as loai,b.mabd,trunc(d.giamua," + i_dongiale + ") as dongia, d.manguon,";
                    sql += "sum(b.soluong) as soluong,sum(b.soluong*d.giamua) as sotien ";
                }
                if (chkNhacc.Checked) sql += ", d.nhomcc as manhacc, ncc.ten as tennhacc ";
                else sql += ", 0 as manhacc, null as tennhacc ";
                sql += ",case when d.gianovat=0 then 0 else (round(d.giamua/d.gianovat,2)-1)*100 end as vat ";
                sql += "from " + xxx + ".d_xuatll a," + xxx + ".d_xuatct b, " + user + ".d_dmbd c," + xxx + ".d_theodoi d ";
                if (chkNhacc.Checked) sql += ", " + user + ".d_dmnx ncc";
                sql += " where a.id=b.id and b.mabd=c.id and b.sttt=d.id and a.nhom=" + i_nhom + " and a.loai in ('CK') and b.soluong>0";
                sql += " and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + s_tungay + "','dd/mm/yyyy') and to_date('" + s_denngay + "','dd/mm/yyyy')";
                if (chkNhacc.Checked) sql += " and d.nhomcc=ncc.id ";
                if (s_kho != "") sql += " and a.khon in (" + s_kho.Substring(0, s_kho.Length - 1) + ")";
                if (s_kho != "") sql += " and a.khox not in (" + s_kho.Substring(0, s_kho.Length - 1) + ")";
                if (s_manhom != "") sql += " and c.manhom in (" + s_manhom.Substring(0, s_manhom.Length - 1) + ")";
                if (s_maduocbv != "") sql += " and c.nhombo in (" + s_maduocbv.Trim().Trim(',') + ")";
                if (manguon.SelectedIndex != -1) sql += " and d.manguon=" + int.Parse(manguon.SelectedValue.ToString());

                sql += " group by ";
                if (i_tt == 1) sql += "a.khon,";
                if (bGiaban)
                {
                    if (bGiabandot) sql += "b.giaban,";
                    else sql += "c.giaban,";
                }
                if (chkGiachuaVAT.Checked)
                {
                    sql += "b.mabd,trunc(d.gianovat," + i_dongiale + "),d.manguon ";
                }
                else
                {
                    sql += "b.mabd,trunc(d.giamua," + i_dongiale + "),d.manguon ";
                }
                if (chkNhacc.Checked) sql += ", d.nhomcc, ncc.ten";
                sql += ",case when d.gianovat=0 then 0 else (round(d.giamua/d.gianovat,2)-1)*100 end ";
                // if (!d.bChuyenkho_inrieng(i_nhom) || kho.CheckedItems.Count==1)//.SelectedItems.Count == 1)
                //  {
                //sql += " union all select ";
                //if (i_tt == 1) sql += "a.khon as makho,";
                //if (bGiaban)
                //{
                //    if (bGiabandot) sql += "b.giaban,";
                //    else sql += "c.giaban,";
                //}
                //else sql += "0 as giaban,";
                //if (chkGiachuaVAT.Checked)
                //{
                //    sql += "1 as loai,b.mabd,trunc(d.gianovat," + i_dongiale + ") as dongia,d.manguon,";
                //    sql += "sum(b.soluong) as soluong,sum(b.soluong*d.gianovat) as sotien ";
                //}
                //else
                //{
                //    sql += "1 as loai,b.mabd,trunc(d.giamua," + i_dongiale + ") as dongia,d.manguon,";
                //    sql += "sum(b.soluong) as soluong,sum(b.soluong*d.giamua) as sotien ";
                //}
                //sql += "from " + xxx + ".d_xuatll a," + xxx + ".d_xuatct b, " + user + ".d_dmbd c," + xxx + ".d_theodoi d where a.id=b.id and b.mabd=c.id and b.sttt=d.id and a.nhom=" + i_nhom + " and a.loai in ('CK','HT','TH') and b.soluong>0";
                //if (s_kho != "") sql += " and a.khon in (" + s_kho.Substring(0, s_kho.Length - 1) + ")";
                //if (s_manhom != "") sql += " and c.manhom in (" + s_manhom.Substring(0, s_manhom.Length - 1) + ")";
                //if (manguon.SelectedIndex != -1) sql += " and d.manguon=" + int.Parse(manguon.SelectedValue.ToString());
                //sql += " and b.soluong>0 and a.khox in (" + s_khott.Substring(0, s_khott.Length - 1) + ")";
                //sql += " group by ";
                //if (i_tt == 1) sql += "a.khon,";
                //if (bGiaban)
                //{
                //    if (bGiabandot) sql += "b.giaban,";
                //    else sql += "c.giaban,";
                //}
                //if (chkGiachuaVAT.Checked)
                //{
                //    sql += "b.mabd,trunc(d.gianovat," + i_dongiale + "),d.manguon ";
                //}
                //else
                //{
                //    sql += "b.mabd,trunc(d.giamua," + i_dongiale + "),d.manguon ";
                //}
                //  }
                #endregion lay so lieu do nhap chuyen kho

                #region lay so lieu thu hoi co so tu truc + hoan tra tu truc
                asql = "  select ";
                if (i_tt == 1) asql += "a.khon as makho,";
                if (bGiaban)
                {
                    if (bGiabandot) asql += "b.giaban,";
                    else asql += "c.giaban,";
                }
                else asql += "0 as giaban,";
                if (chkGiachuaVAT.Checked)
                {
                    asql += "1 as loai,b.mabd,trunc(d.gianovat," + i_dongiale + ") as dongia, d.manguon,";
                    asql += "sum(b.soluong) as soluong,sum(b.soluong*d.gianovat) as sotien ";
                }
                else
                {
                    asql += "1 as loai,b.mabd,trunc(d.giamua," + i_dongiale + ") as dongia, d.manguon,";
                    asql += "sum(b.soluong) as soluong,sum(b.soluong*d.giamua) as sotien ";
                }
                if (chkNhacc.Checked) asql += ", d.nhomcc as manhacc, ncc.ten as tennhacc ";
                else asql += ", 0 as manhacc, null as tennhacc ";
                asql += ",case when d.gianovat=0 then 0 else (round(d.giamua/d.gianovat,2)-1)*100 end as vat ";
                asql += "from " + xxx + ".d_xuatll a," + xxx + ".d_xuatct b, " + user + ".d_dmbd c," + xxx + ".d_theodoi d ";
                if (chkNhacc.Checked) asql += ", " + user + ".d_dmnx ncc";
                asql += " where a.id=b.id and b.mabd=c.id and b.sttt=d.id and a.nhom=" + i_nhom + " and a.loai in ('TH','HT') and b.soluong>0";
                if (chkNhacc.Checked) asql += " and d.nhomcc=ncc.id ";
                if (s_kho != "") asql += " and a.khon in (" + s_kho.Substring(0, s_kho.Length - 1) + ")";
                if (s_manhom != "") asql += " and c.manhom in (" + s_manhom.Substring(0, s_manhom.Length - 1) + ")";
                if (s_maduocbv != "") asql += " and c.nhombo in (" + s_maduocbv.Trim().Trim(',') + ")";
                if (manguon.SelectedIndex != -1) asql += " and d.manguon=" + int.Parse(manguon.SelectedValue.ToString());
                asql += " and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + s_tungay + "','dd/mm/yyyy') and to_date('" + s_denngay + "','dd/mm/yyyy')";

                asql += " group by ";
                if (i_tt == 1) asql += "a.khon,";
                if (bGiaban)
                {
                    if (bGiabandot) asql += "b.giaban,";
                    else asql += "c.giaban,";
                }
                if (chkGiachuaVAT.Checked)
                {
                    asql += "b.mabd,trunc(d.gianovat," + i_dongiale + "),d.manguon ";
                }
                else
                {
                    asql += "b.mabd,trunc(d.giamua," + i_dongiale + "),d.manguon ";
                }
                if (chkNhacc.Checked) asql += ", d.nhomcc, ncc.ten ";
                asql += ",case when d.gianovat=0 then 0 else (round(d.giamua/d.gianovat,2)-1)*100 end";
                if (!d.bChuyenkho_inrieng(i_nhom))// || kho.SelectedItems.Count == 1)
                {
                    //asql += " union all select ";
                    //if (i_tt == 1) asql += "a.khon as makho,";
                    //if (bGiaban)
                    //{
                    //    if (bGiabandot) asql += "b.giaban,";
                    //    else asql += "c.giaban,";
                    //}
                    //else asql += "0 as giaban,";
                    //if (chkGiachuaVAT.Checked)
                    //{
                    //    asql += "1 as loai,b.mabd,trunc(d.gianovat," + i_dongiale + ") as dongia,d.manguon,";
                    //    asql += "sum(b.soluong) as soluong,sum(b.soluong*d.gianovat) as sotien ";
                    //}
                    //else
                    //{
                    //    asql += "1 as loai,b.mabd,trunc(d.giamua," + i_dongiale + ") as dongia,d.manguon,";
                    //    asql += "sum(b.soluong) as soluong,sum(b.soluong*d.giamua) as sotien ";
                    //}
                    //asql += "from " + xxx + ".d_xuatll a," + xxx + ".d_xuatct b, " + user + ".d_dmbd c," + xxx + ".d_theodoi d where a.id=b.id and b.mabd=c.id and b.sttt=d.id and a.nhom=" + i_nhom + " and a.loai in ('CK','HT','TH') and b.soluong>0";
                    //if (s_kho != "") asql += " and a.khon in (" + s_kho.Substring(0, s_kho.Length - 1) + ")";
                    //if (s_manhom != "") asql += " and c.manhom in (" + s_manhom.Substring(0, s_manhom.Length - 1) + ")";
                    //if (manguon.SelectedIndex != -1) asql += " and d.manguon=" + int.Parse(manguon.SelectedValue.ToString());
                    //asql += " and b.soluong>0 and a.khox in (" + s_khott.Substring(0, s_khott.Length - 1) + ")";
                    //asql += " group by ";
                    //if (i_tt == 1) asql += "a.khon,";
                    //if (bGiaban)
                    //{
                    //    if (bGiabandot) asql += "b.giaban,";
                    //    else sql += "c.giaban,";
                    //}
                    //if (chkGiachuaVAT.Checked)
                    //{
                    //    asql += "b.mabd,trunc(d.gianovat," + i_dongiale + "),d.manguon ";
                    //}
                    //else
                    //{
                    //    asql += "b.mabd,trunc(d.giamua," + i_dongiale + "),d.manguon ";
                    //}
                    //}
                    f_Get_Hoantra_Thuhoi_CSTT(d.get_data(asql));

                #endregion lay so lieu thu hoi co so tu truc + hoan tra tu truc
                }
                #endregion  kho trung tam
            }

            #region insert item
            string f1 = "slnhap", f2 = "stnhap";
            foreach (DataRow r in d.get_data(sql).Tables[0].Rows)
            {
                r3 = d.getrowbyid(dt, "id=" + int.Parse(r["mabd"].ToString()));
                if (r3 != null)
                {
                    f1 = "slnhap"; f2 = "stnhap";
                    if (r["loai"].ToString() == "1" && !bGiaban)
                    {
                        f1 += "_ck"; f2 += "_ck";
                    }

                    exp = "mabd=" + int.Parse(r["mabd"].ToString());
                    exp += " and dongia=" + decimal.Parse(r["dongia"].ToString());
                    if (manguon.SelectedIndex != -1) exp += " and manguon=" + int.Parse(manguon.SelectedValue.ToString());
                    if (i_tt == 1) exp += " and idnn=" + int.Parse(r["makho"].ToString());
                    r1 = d.getrowbyid(ds.Tables[0], exp);
                    if (r1 == null)
                    {
                        r2 = ds.Tables[0].NewRow();
                        r2["manhom"] = r3["manhom"].ToString();
                        r2["tennhom"] = r3["tennhom"].ToString();
                        r2["mabd"] = r["mabd"].ToString();
                        r2["ma"] = r3["ma"].ToString();
                        r2["ten"] = r3["ten"].ToString().Trim() + " " + r3["hamluong"].ToString();
                        if (i_tt == 0) r2["tenhc"] = r3["tenhc"].ToString();
                        else r2["tenhc"] = "";
                        r2["manhacc"] = r["manhacc"].ToString();
                        r2["tennhacc"] = r["tennhacc"].ToString();
                        r2["noingoai"] = "";
                        r2["dang"] = r3["dang"].ToString();
                        r2["tondau"] = 0;
                        r2["sttondau"] = 0;
                        r2["slxuat"] = 0;
                        r2["stxuat"] = 0;
                        r2["sl_tra"] = 0;
                        r2["st_tra"] = 0;
                        r2["dongia"] = r["dongia"].ToString();
                        r2["giaban"] = r["giaban"].ToString();
                        r2["sttt"] = 0;
                        r2["manguon"] = r["manguon"].ToString();
                        r2["stt"] = (r3["tt"].ToString().Trim() == "") ? "0" : r3["tt"].ToString();
                        if (i_tt == 0)
                        {
                            r2["idnn"] = r3["idnn"].ToString();
                            r2["noingoai"] = r3["noingoai"].ToString();
                        }
                        else if (i_tt == 1)
                        {
                            r4 = d.getrowbyid(dtdmkho, "id=" + int.Parse(r["makho"].ToString()));
                            if (r4 != null)
                            {
                                r2["idnn"] = r["makho"].ToString();
                                r2["noingoai"] = r4["ten"].ToString();
                            }
                        }
                        r2["slxuat_ck"] = "0";
                        r2["stxuat_ck"] = "0";
                        r2["slnhap_ck"] = "0";
                        r2["stnhap_ck"] = "0";
                        r2["slnhap"] = "0";
                        r2["stnhap"] = "0";
                        r2["sl_th"] = "0";
                        r2["st_th"] = "0";
                        r2["vat"] = r["vat"].ToString();
                        r2[f1] = r["soluong"].ToString();
                        r2[f2] = r["sotien"].ToString();
                        ds.Tables[0].Rows.Add(r2);
                    }
                    else
                    {
                        DataRow[] dr = ds.Tables[0].Select(exp);
                        dr[0][f1] = decimal.Parse(dr[0][f1].ToString()) + decimal.Parse(r["soluong"].ToString());
                        dr[0][f2] = decimal.Parse(dr[0][f2].ToString()) + decimal.Parse(r["sotien"].ToString());
                    }
                }
            }
            ds.AcceptChanges();
            #endregion insert item

        }
        // ham xuat den ngay
         private void get_xuat_denngay(string d_mmyy, string s_tungay)
        {
            xxx = user + d_mmyy;
            sql = "select ";
            if (i_tt == 1) sql += "b.makho,";
            if (bGiaban)
            {
                if (bGiabandot) sql += "b.giaban,";
                else sql += "c.giaban,";
            }
            else sql += "0 as giaban,";
            if (chkGiachuaVAT.Checked)
            {
                sql += "b.mabd,trunc(d.gianovat," + i_dongiale + ") as dongia, d.manguon,";
                sql += "sum(b.soluong) as soluong,sum(b.soluong*d.gianovat) as sotien ";
            }
            else
            {
                sql += "b.mabd,trunc(d.giamua," + i_dongiale + ") as dongia, d.manguon,";
                sql += "sum(b.soluong) as soluong,sum(b.soluong*d.giamua) as sotien ";
            }
            //
            if (chkNhacc.Checked) sql += ", d.nhomcc as manhacc, ncc.ten as tennhacc ";
            else sql += ", 0 as manhacc, null as tennhacc ";
            sql += ",case when d.gianovat=0 then 0 else (round(d.giamua/d.gianovat,2)-1)*100 end as vat ";
            //
            sql += "from " + xxx + ".d_xuatsdll a," + xxx + ".d_thucxuat b," + user + ".d_dmbd c," + xxx + ".d_theodoi d ";
            if (chkNhacc.Checked) sql += ", " + user + ".d_dmnx ncc";
            sql += " where a.id=b.id and b.mabd=c.id and b.sttt=d.id and a.loai in(1,4) and a.nhom=" + i_nhom;
            if (chkNhacc.Checked) sql += " and d.nhomcc=ncc.id ";
            sql += " and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') < to_date('" + s_tungay + "','dd/mm/yyyy') ";
            if (s_kho != "") sql += " and b.makho in (" + s_kho.Substring(0, s_kho.Length - 1) + ")";
            if (s_manhom != "") sql += " and c.manhom in (" + s_manhom.Substring(0, s_manhom.Length - 1) + ")";
            if (s_maduocbv != "") sql += " and c.nhombo in (" + s_maduocbv.Trim().Trim(',') + ")";
            if (manguon.SelectedIndex != -1) sql += " and d.manguon=" + int.Parse(manguon.SelectedValue.ToString());
            sql += " and b.soluong>0";
            // 
            sql += " group by ";
            if (i_tt == 1) sql += " b.makho,";
            if (bGiaban)
            {
                if (bGiabandot) sql += "b.giaban,";
                else sql += "c.giaban,";
            }
            if (chkGiachuaVAT.Checked)
            {
                sql += "b.mabd,trunc(d.gianovat," + i_dongiale + "),d.manguon";
            }
            else
            {
                sql += "b.mabd,trunc(d.giamua," + i_dongiale + "),d.manguon";
            }
            if (chkNhacc.Checked) sql += ", d.nhomcc, ncc.ten";
            sql += ",case when d.gianovat=0 then 0 else (round(d.giamua/d.gianovat,2)-1)*100 end ";
            //xu ly tren d_thucbucstt: bu tu truc
            sql += " union all select ";
            if (i_tt == 1) sql += "b.makho,";
            if (bGiaban)
            {
                if (bGiabandot) sql += "b.giaban,";
                else sql += "c.giaban,";
            }
            else sql += "0 as giaban,";
            if (chkGiachuaVAT.Checked)
            {
                sql += "b.mabd,trunc(d.gianovat," + i_dongiale + ") as dongia, d.manguon,";
                sql += "sum(b.soluong) as soluong,sum(b.soluong*d.gianovat) as sotien ";
            }
            else
            {
                sql += "b.mabd,trunc(d.giamua," + i_dongiale + ") as dongia, d.manguon,";
                sql += "sum(b.soluong) as soluong,sum(b.soluong*d.giamua) as sotien ";
            }
            //
            //
            if (chkNhacc.Checked) sql += ", d.nhomcc as manhacc, ncc.ten as tennhacc ";
            else sql += ", 0 as manhacc, null as tennhacc ";
            sql += ",case when d.gianovat=0 then 0 else (round(d.giamua/d.gianovat,2)-1)*100 end as vat ";
            //
            sql += "from " + xxx + ".d_xuatsdll a," + xxx + ".d_thucbucstt b," + user + ".d_dmbd c," + xxx + ".d_theodoi d ";
            if (chkNhacc.Checked) sql += ", " + user + ".d_dmnx ncc";
            sql += " where a.id=b.id and b.mabd=c.id and b.sttt=d.id and a.loai in(2) and a.nhom=" + i_nhom;
            if (chkNhacc.Checked) sql += " and d.nhomcc=ncc.id ";
            sql += " and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') < to_date('" + s_tungay + "','dd/mm/yyyy') ";
            if (s_kho != "") sql += " and b.makho in (" + s_kho.Substring(0, s_kho.Length - 1) + ")";
            if (s_manhom != "") sql += " and c.manhom in (" + s_manhom.Substring(0, s_manhom.Length - 1) + ")";
            if (s_maduocbv != "") sql += " and c.nhombo in (" + s_maduocbv.Trim().Trim(',') + ")";
            if (manguon.SelectedIndex != -1) sql += " and d.manguon=" + int.Parse(manguon.SelectedValue.ToString());
            sql += " and b.soluong>0";
            // 
            sql += " group by ";
            if (i_tt == 1) sql += " b.makho,";
            if (bGiaban)
            {
                if (bGiabandot) sql += "b.giaban,";
                else sql += "c.giaban,";
            }
            if (chkGiachuaVAT.Checked)
            {
                sql += "b.mabd,trunc(d.gianovat," + i_dongiale + "),d.manguon";
            }
            else
            {
                sql += "b.mabd,trunc(d.giamua," + i_dongiale + "),d.manguon";
            }
            if (chkNhacc.Checked) sql += ", d.nhomcc, ncc.ten";
            sql += ",case when d.gianovat=0 then 0 else (round(d.giamua/d.gianovat,2)-1)*100 end ";
            //xuat CK, BS, XK
            sql += " union all select ";
            if (i_tt == 1) sql += "a.khox makho,";
            if (bGiaban)
            {
                if (bGiabandot) sql += "b.giaban,";
                else sql += "c.giaban,";
            }
            else sql += "0 as giaban,";
            if (chkGiachuaVAT.Checked)
            {
                sql += "b.mabd,trunc(d.gianovat," + i_dongiale + ") as dongia, d.manguon,";
                sql += "sum(b.soluong) as soluong,sum(b.soluong*d.gianovat) as sotien ";
            }
            else
            {
                sql += "b.mabd,trunc(d.giamua," + i_dongiale + ") as dongia, d.manguon,";
                sql += "sum(b.soluong) as soluong,sum(b.soluong*d.giamua) as sotien ";
            }
            //
            //
            if (chkNhacc.Checked) sql += ", d.nhomcc as manhacc, ncc.ten as tennhacc ";
            else sql += ", 0 as manhacc, null as tennhacc ";
            sql += ",case when d.gianovat=0 then 0 else (round(d.giamua/d.gianovat,2)-1)*100 end as vat ";
            //
            sql += " from " + xxx + ".d_xuatll a," + xxx + ".d_xuatct b," + user + ".d_dmbd c," + xxx + ".d_theodoi d ";
            if (chkNhacc.Checked) sql += ", " + user + ".d_dmnx ncc";
            sql += " where a.id=b.id and b.mabd=c.id and b.sttt=d.id and a.nhom=" + i_nhom;
            if (chkNhacc.Checked) sql += " and d.nhomcc=ncc.id ";
            sql += " and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') < to_date('" + s_tungay + "','dd/mm/yyyy') ";
            sql += " and a.loai in ('BS','XK')";
            if (s_kho != "") sql += " and a.khox in (" + s_kho.Substring(0, s_kho.Length - 1) + ")";
            if (s_manhom != "") sql += " and c.manhom in (" + s_manhom.Substring(0, s_manhom.Length - 1) + ")";
            if (manguon.SelectedIndex != -1) sql += " and d.manguon=" + int.Parse(manguon.SelectedValue.ToString());
            sql += " and b.soluong>0";

            sql += " group by ";
            if (i_tt == 1) sql += " a.khox,";
            if (bGiaban)
            {
                if (bGiabandot) sql += "b.giaban,";
                else sql += "c.giaban,";
            }
            if (chkGiachuaVAT.Checked)
            {
                sql += "b.mabd,trunc(d.gianovat," + i_dongiale + "),d.manguon";
            }
            else
            {
                sql += "b.mabd,trunc(d.giamua," + i_dongiale + "),d.manguon";
            }
            if (chkNhacc.Checked) sql += ", d.nhomcc, ncc.ten";
            sql += ",case when d.gianovat=0 then 0 else (round(d.giamua/d.gianovat,2)-1)*100 end ";
            //BHYT
            sql += " union all select ";
            if (i_tt == 1) sql += "b.makho,";
            if (bGiaban)
            {
                if (bGiabandot) sql += "b.giaban,";
                else sql += "c.giaban,";
            }
            else sql += "0 as giaban,";
            if (chkGiachuaVAT.Checked)
            {
                sql += "b.mabd,trunc(d.gianovat," + i_dongiale + ") as dongia, d.manguon,";
                sql += "sum(b.soluong) as soluong,sum(b.soluong*d.gianovat) as sotien ";
            }
            else
            {
                sql += "b.mabd,trunc(d.giamua," + i_dongiale + ") as dongia, d.manguon,";
                sql += "sum(b.soluong) as soluong,sum(b.soluong*d.giamua) as sotien ";
            }
            if (chkNhacc.Checked) sql += ", d.nhomcc as manhacc, ncc.ten as tennhacc ";
            else sql += ", 0 as manhacc, null as tennhacc ";
            sql += ",case when d.gianovat=0 then 0 else (round(d.giamua/d.gianovat,2)-1)*100 end as vat ";
            sql += "from " + xxx + ".bhytkb a," + xxx + ".bhytthuoc b," + user + ".d_dmbd c," + xxx + ".d_theodoi d ";
            if (chkNhacc.Checked) sql += ", " + user + ".d_dmnx ncc";
            sql += " where a.id=b.id and b.mabd=c.id and b.sttt=d.id and a.nhom=" + i_nhom;
            sql += " and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') < to_date('" + s_tungay + "','dd/mm/yyyy')";
            if (chkNhacc.Checked) sql += " and d.nhomcc=ncc.id ";
            if (s_kho != "") sql += " and b.makho in (" + s_kho.Substring(0, s_kho.Length - 1) + ")";
            if (s_manhom != "") sql += " and c.manhom in (" + s_manhom.Substring(0, s_manhom.Length - 1) + ")";
            if (s_maduocbv != "") sql += " and c.nhombo in (" + s_maduocbv.Trim().Trim(',') + ")";
            if (manguon.SelectedIndex != -1) sql += " and d.manguon=" + int.Parse(manguon.SelectedValue.ToString());
            sql += " and b.soluong>0";

            sql += " group by ";
            if (i_tt == 1) sql += " b.makho,";
            if (bGiaban)
            {
                if (bGiabandot) sql += "b.giaban,";
                else sql += "c.giaban,";
            }
            if (chkGiachuaVAT.Checked)
            {
                sql += "b.mabd,trunc(d.gianovat," + i_dongiale + "),d.manguon";
            }
            else
            {
                sql += "b.mabd,trunc(d.giamua," + i_dongiale + "),d.manguon";
            }
            if (chkNhacc.Checked) sql += ", d.nhomcc, ncc.ten";
            sql += ",case when d.gianovat=0 then 0 else (round(d.giamua/d.gianovat,2)-1)*100 end";
            //ngoaitru
            //BHYT
            sql += " union all select ";
            if (i_tt == 1) sql += "b.makho,";
            if (bGiaban)
            {
                if (bGiabandot) sql += "b.giaban,";
                else sql += "c.giaban,";
            }
            else sql += "0 as giaban,";
            if (chkGiachuaVAT.Checked)
            {
                sql += "b.mabd,trunc(d.gianovat," + i_dongiale + ") as dongia, d.manguon,";
                sql += "sum(b.soluong) as soluong,sum(b.soluong*d.gianovat) as sotien ";
            }
                // 
            else
            {
                sql += "b.mabd,trunc(d.giamua," + i_dongiale + ") as dongia, d.manguon,";
                sql += "sum(b.soluong) as soluong,sum(b.soluong*d.giamua) as sotien ";
            }
            if (chkNhacc.Checked) sql += ", d.nhomcc as manhacc, ncc.ten as tennhacc ";
            else sql += ", 0 as manhacc, null as tennhacc ";
            sql += ",case when d.gianovat=0 then 0 else (round(d.giamua/d.gianovat,2)-1)*100 end as vat ";
            sql += "from " + xxx + ".d_ngtrull a," + xxx + ".d_ngtruct b," + user + ".d_dmbd c," + xxx + ".d_theodoi d ";
            if (chkNhacc.Checked) sql += ", " + user + ".d_dmnx ncc";
            sql += " where a.id=b.id and b.mabd=c.id and b.sttt=d.id and a.nhom=" + i_nhom;
            sql += " and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') < to_date('" + s_tungay + "','dd/mm/yyyy') ";
            if (chkNhacc.Checked) sql += " and d.nhomcc=ncc.id ";
            if (s_kho != "") sql += " and b.makho in (" + s_kho.Substring(0, s_kho.Length - 1) + ")";
            if (s_manhom != "") sql += " and c.manhom in (" + s_manhom.Substring(0, s_manhom.Length - 1) + ")";
            if (s_maduocbv != "") sql += " and c.nhombo in (" + s_maduocbv.Trim().Trim(',') + ")";
            if (manguon.SelectedIndex != -1) sql += " and d.manguon=" + int.Parse(manguon.SelectedValue.ToString());
            sql += " and b.soluong>0";
            // 

            sql += " group by ";
            if (i_tt == 1) sql += " b.makho,";
            if (bGiaban)
            {
                if (bGiabandot) sql += "b.giaban,";
                else sql += "c.giaban,";
            }
            if (chkGiachuaVAT.Checked)
            {
                sql += "b.mabd,trunc(d.gianovat," + i_dongiale + "),d.manguon";
            }
            else
            {
                sql += "b.mabd,trunc(d.giamua," + i_dongiale + "),d.manguon";
            }
            if (chkNhacc.Checked) sql += ", d.nhomcc, ncc.ten";
            sql += ",case when d.gianovat=0 then 0 else (round(d.giamua/d.gianovat,2)-1)*100 end ";
            foreach (DataRow r in d.get_data(sql).Tables[0].Rows)
            {
                exp = "mabd=" + int.Parse(r["mabd"].ToString());
                exp += " and dongia=" + decimal.Parse(r["dongia"].ToString());
                if (manguon.SelectedIndex != -1) exp += " and manguon=" + int.Parse(manguon.SelectedValue.ToString());
                if (i_tt == 1) exp += " and idnn=" + int.Parse(r["makho"].ToString());
                r1 = d.getrowbyid(ds.Tables[0], exp);
                if (r1 == null)
                {
                    r3 = d.getrowbyid(dt, "id=" + int.Parse(r["mabd"].ToString()));
                    if (r3 != null)
                    {
                        r2 = ds.Tables[0].NewRow();
                        r2["manhom"] = r3["manhom"].ToString();
                        r2["tennhom"] = r3["tennhom"].ToString();
                        r2["mabd"] = r["mabd"].ToString();
                        r2["ma"] = r3["ma"].ToString();
                        r2["ten"] = r3["ten"].ToString().Trim() + " " + r3["hamluong"].ToString();
                        if (i_tt == 0) r2["tenhc"] = r3["tenhc"].ToString();
                        else r2["tenhc"] = "";
                        r2["manhacc"] = r["manhacc"].ToString();
                        r2["tennhacc"] = r["tennhacc"].ToString();
                        r2["noingoai"] = "";
                        r2["dang"] = r3["dang"].ToString();
                        r2["tondau"] = Convert.ToDecimal(r["soluong"].ToString())*(-1);
                        r2["sttondau"] = Convert.ToDecimal(r["sotien"].ToString()) * (-1);
                        r2["slnhap"] = 0;
                        r2["stnhap"] = 0;
                        r2["slnhap_ck"] = 0;
                        r2["stnhap_ck"] = 0;
                        r2["slxuat_ck"] = 0;
                        r2["stxuat_ck"] = 0;
                        r2["sl_tra"] = 0;
                        r2["st_tra"] = 0;
                        r2["slxuat"] = 0;
                        r2["stxuat"] = 0;
                        r2["sl_th"] = 0;
                        r2["st_th"] = 0;
                        r2["slxuat"] = 0;
                        r2["stxuat"] = 0;
                        r2["dongia"] =  r["dongia"].ToString();
                        r2["giaban"] =  r["giaban"].ToString();
                        r2["sttt"] = 0;
                        r2["manguon"] = r["manguon"].ToString();
                        r2["stt"] = (r3["tt"].ToString().Trim() == "") ? "0" : r3["tt"].ToString();
                        r2["noingoai"] = "";
                        if (i_tt == 0)
                        {
                            r2["idnn"] = r3["idnn"].ToString();
                            r2["noingoai"] = r3["noingoai"].ToString();
                        }
                        else if (i_tt == 1)
                        {
                            r4 = d.getrowbyid(dtdmkho, "id=" + int.Parse(r["makho"].ToString()));
                            if (r4 != null)
                            {
                                r2["idnn"] = r["makho"].ToString();
                                r2["noingoai"] = r4["ten"].ToString();
                            }
                        }
                        r2["vat"] = r["vat"].ToString();
                        ds.Tables[0].Rows.Add(r2);
                    }
                }
                else
                {
                    DataRow[] dr = ds.Tables[0].Select(exp);
                    dr[0]["tondau"] = decimal.Parse(dr[0]["tondau"].ToString()) - decimal.Parse(r["soluong"].ToString());
                    dr[0]["sttondau"] = decimal.Parse(dr[0]["sttondau"].ToString()) - decimal.Parse(r["sotien"].ToString());
                }
            }
            sql = "select ";
            if (i_tt == 1) sql += "a.khox makho,";
            if (bGiaban)
            {
                if (bGiabandot) sql += "b.giaban,";
                else sql += "c.giaban,";
            }
            else sql += "0 as giaban,";
            if (chkGiachuaVAT.Checked)
            {
                sql += "b.mabd,trunc(d.gianovat," + i_dongiale + ") as dongia,d.manguon,sum(b.soluong) as soluong,sum(b.soluong*d.gianovat) as sotien ";
            }
            else
            {
                sql += "b.mabd,trunc(d.giamua," + i_dongiale + ") as dongia,d.manguon,sum(b.soluong) as soluong,sum(b.soluong*d.giamua) as sotien ";
            }
            if (chkNhacc.Checked) sql += ", d.nhomcc as manhacc, ncc.ten as tennhacc ";
            else sql += ", 0 as manhacc, null as tennhacc ";
            sql += ",case when d.gianovat=0 then 0 else (round(d.giamua/d.gianovat,2)-1)*100 end as vat ";

            sql += "from " + xxx + ".d_xuatll a," + xxx + ".d_xuatct b," + user + ".d_dmbd c," + xxx + ".d_theodoi d ";
            if (chkNhacc.Checked) sql += ", " + user + ".d_dmnx ncc";
            sql += " where a.id=b.id and b.mabd=c.id and b.sttt=d.id and a.nhom=" + i_nhom + " and a.loai in ('CK')";
            if (chkNhacc.Checked) sql += " and d.nhomcc=ncc.id ";
            sql += " and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') < to_date('" + s_tungay + "','dd/mm/yyyy') ";
            if (s_kho != "") sql += " and a.khox in (" + s_kho.Substring(0, s_kho.Length - 1) + ")";
            if (s_kho != "") sql += " and a.khon not in (" + s_kho.Substring(0, s_kho.Length - 1) + ")";
            if (s_manhom != "") sql += " and c.manhom in (" + s_manhom.Substring(0, s_manhom.Length - 1) + ")";
            if (s_maduocbv != "") sql += " and c.nhombo in (" + s_maduocbv.Trim().Trim(',') + ")";
            if (manguon.SelectedIndex != -1) sql += " and d.manguon=" + int.Parse(manguon.SelectedValue.ToString());
            sql += " and b.soluong>0";

            sql += " group by ";
            if (i_tt == 1) sql += "a.khox,";
            if (bGiaban)
            {
                if (bGiabandot) sql += "b.giaban,";
                else sql += "c.giaban,";
            }
            if (chkGiachuaVAT.Checked)
            {
                sql += "b.mabd,trunc(d.gianovat," + i_dongiale + "),d.manguon";
            }
            else
            {
                sql += "b.mabd,trunc(d.giamua," + i_dongiale + "),d.manguon";
            }
            if (chkNhacc.Checked) sql += ", d.nhomcc, ncc.ten";
            sql += ",case when d.gianovat=0 then 0 else (round(d.giamua/d.gianovat,2)-1)*100 end";
            foreach (DataRow r in d.get_data(sql).Tables[0].Rows)
            {
                exp = "mabd=" + int.Parse(r["mabd"].ToString());
                exp += " and dongia=" + decimal.Parse(r["dongia"].ToString());
                if (manguon.SelectedIndex != -1) exp += " and manguon=" + int.Parse(manguon.SelectedValue.ToString());
                if (i_tt == 1) exp += " and idnn=" + int.Parse(r["makho"].ToString());
                r1 = d.getrowbyid(ds.Tables[0], exp);
                if (r1 == null)
                {
                    r3 = d.getrowbyid(dt, "id=" + int.Parse(r["mabd"].ToString()));
                    if (r3 != null)
                    {
                        r2 = ds.Tables[0].NewRow();
                        r2["manhom"] = r3["manhom"].ToString();
                        r2["tennhom"] = r3["tennhom"].ToString();
                        r2["mabd"] = r["mabd"].ToString();
                        r2["ma"] = r3["ma"].ToString();
                        r2["ten"] = r3["ten"].ToString().Trim() + " " + r3["hamluong"].ToString();
                        if (i_tt == 0) r2["tenhc"] = r3["tenhc"].ToString();
                        else r2["tenhc"] = "";
                        r2["manhacc"] = r["manhacc"].ToString();
                        r2["tennhacc"] = r["tennhacc"].ToString();
                        r2["noingoai"] = "";
                        r2["dang"] = r3["dang"].ToString();
                        r2["tondau"] =Convert.ToDecimal(r["soluong"].ToString())*(-1);
                        r2["sttondau"] = Convert.ToDecimal(r["sotien"].ToString())*(-1);
                        r2["slnhap"] = 0;
                        r2["stnhap"] = 0;
                        r2["slnhap_ck"] = 0;
                        r2["stnhap_ck"] = 0;
                        r2["slxuat"] = 0;
                        r2["stxuat"] = 0;
                        r2["slxuat_ck"] = 0;
                        r2["stxuat_ck"] = 0;
                        r2["sl_tra"] = 0;
                        r2["st_tra"] = 0;
                        
                        r2["dongia"] = r["dongia"].ToString();
                        r2["giaban"] = r["giaban"].ToString();
                        r2["sttt"] = 0;
                        r2["manguon"] = r["manguon"].ToString();
                        r2["stt"] = (r3["tt"].ToString().Trim() == "") ? "0" : r3["tt"].ToString();
                        if (i_tt == 0)
                        {
                            r2["idnn"] = r3["idnn"].ToString();
                            r2["noingoai"] = r3["noingoai"].ToString();
                        }
                        else if (i_tt == 1)
                        {
                            r4 = d.getrowbyid(dtdmkho, "id=" + int.Parse(r["makho"].ToString()));
                            if (r4 != null)
                            {
                                r2["idnn"] = r["makho"].ToString();
                                r2["noingoai"] = r4["ten"].ToString();
                            }
                        }
                        r2["vat"] = r["vat"].ToString();
                        ds.Tables[0].Rows.Add(r2);
                    }
                }
                else
                {
                    DataRow[] dr = ds.Tables[0].Select(exp);                   

                    dr[0]["tondau"] = decimal.Parse(dr[0]["tondau"].ToString()) - decimal.Parse(r["soluong"].ToString());
                    dr[0]["sttondau"] = decimal.Parse(dr[0]["sttondau"].ToString()) - decimal.Parse(r["sotien"].ToString());
                }
            }
            ds.AcceptChanges();
        }
        // ham get_nhap_denngay
        private void get_nhap_denngay(string d_mmyy, string s_tungay)
        {
            string asql = "";
            xxx = user + d_mmyy;

            #region nhap moi + tai nhap
            sql = "select ";
            if (i_tt == 1) sql += " a.makho,";
            if (bGiaban)
            {
                if (bGiabandot) sql += "b.giaban,";
                else sql += "c.giaban,";
            }
            else sql += "0 as giaban,";
            if (chkGiachuaVAT.Checked)
            {
                sql += "0 as loai,b.mabd,trunc(b.dongia," + i_dongiale + ") as dongia,a.manguon,";
                sql += "sum(b.soluong) as soluong,sum(b.soluong*b.dongia+b.cuocvc+b.chaythu) as sotien ";
            }
            else
            {
                sql += "0 as loai,b.mabd,trunc(b.giamua," + i_dongiale + ") as dongia,a.manguon,";
                sql += "sum(b.soluong) as soluong,sum(b.sotien+b.sotien*b.vat/100+b.cuocvc+b.chaythu) as sotien ";
            }
            if (chkNhacc.Checked) sql += ", a.madv as manhacc, ncc.ten as tennhacc ";
            else sql += ", 0 as manhacc, null as tennhacc ";
            sql += ",b.vat ";
            //
            sql += "from " + xxx + ".d_nhapll a," + xxx + ".d_nhapct b," + user + ".d_dmbd c ";
            if (chkNhacc.Checked) sql += ", " + user + ".d_dmnx ncc";
            sql += " where a.id=b.id and b.mabd=c.id and a.nhom=" + i_nhom + "  and b.soluong>0";
            sql += " and to_date(to_char(a.ngaysp,'dd/mm/yyyy'),'dd/mm/yyyy') < to_date('" + s_tungay + "','dd/mm/yyyy')" ;
            if (s_kho != "") sql += " and a.makho in (" + s_kho.Substring(0, s_kho.Length - 1) + ")";
            if (s_manhom != "") sql += " and c.manhom in (" + s_manhom.Substring(0, s_manhom.Length - 1) + ")";
            if (s_maduocbv != "") sql += " and c.nhombo in (" + s_maduocbv.Trim().Trim(',') + ")";
            if (manguon.SelectedIndex != -1) sql += " and a.manguon=" + int.Parse(manguon.SelectedValue.ToString());

            sql += " group by ";
            if (i_tt == 1) sql += "a.makho,";
            if (bGiaban)
            {
                if (bGiabandot) sql += "b.giaban,";
                else sql += "c.giaban,";
            }
            if (chkGiachuaVAT.Checked)
            {
                sql += "b.mabd,trunc(b.dongia," + i_dongiale + "),a.manguon";
            }
            else
            {
                sql += "b.mabd,trunc(b.giamua," + i_dongiale + "),a.manguon";
            }
            if (chkNhacc.Checked) sql += ", a.madv, ncc.ten";
            sql += ", b.vat ";
            #endregion nhap moi + tai nhap

            if (s_khott == "")
            {
                #region khong la kho trung tam

                #region lay so lieu nhap do chuyen kho
                sql += " union all select ";
                if (i_tt == 1) sql += "a.khon as makho,";
                if (bGiaban)
                {
                    if (bGiabandot) sql += "b.giaban,";
                    else sql += "c.giaban,";
                }
                else sql += "0 as giaban,";
                if (chkGiachuaVAT.Checked)
                {
                    sql += "0 as loai,b.mabd,trunc(d.gianovat," + i_dongiale + ") as dongia, d.manguon,";
                    sql += "sum(b.soluong) as soluong,sum(b.soluong*d.gianovat) as sotien ";
                }
                else
                {
                    sql += "0 as loai,b.mabd,trunc(d.giamua," + i_dongiale + ") as dongia, d.manguon,";
                    sql += "sum(b.soluong) as soluong,sum(b.soluong*d.giamua) as sotien ";
                }
                if (chkNhacc.Checked) sql += ", d.nhomcc as manhacc, ncc.ten as tennhacc ";
                else sql += ", 0 as manhacc, null as tennhacc ";
                sql += ",case when d.gianovat=0 then 0 else (round(d.giamua/d.gianovat,2)-1)*100 end as vat ";
                //
                sql += "from " + xxx + ".d_xuatll a," + xxx + ".d_xuatct b, " + user + ".d_dmbd c," + xxx + ".d_theodoi d ";
                if (chkNhacc.Checked) sql += ", " + user + ".d_dmnx ncc";
                sql += " where a.id=b.id and b.mabd=c.id and b.sttt=d.id and a.nhom=" + i_nhom + " and a.loai in ('CK') and b.soluong>0";
                sql += " and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') < to_date('" + s_tungay + "','dd/mm/yyyy')";
                if (chkNhacc.Checked) sql += " and d.nhomcc=ncc.id ";
                if (s_kho != "") sql += " and a.khon in (" + s_kho.Substring(0, s_kho.Length - 1) + ")";
                if (s_kho != "") sql += " and a.khox not in (" + s_kho.Substring(0, s_kho.Length - 1) + ")";
                if (s_manhom != "") sql += " and c.manhom in (" + s_manhom.Substring(0, s_manhom.Length - 1) + ")";
                if (s_maduocbv != "") sql += " and c.nhombo in (" + s_maduocbv.Trim().Trim(',') + ")";
                if (manguon.SelectedIndex != -1) sql += " and d.manguon=" + int.Parse(manguon.SelectedValue.ToString());

                sql += " group by ";
                if (i_tt == 1) sql += "a.khon,";
                if (bGiaban)
                {
                    if (bGiabandot) sql += "b.giaban,";
                    else sql += "c.giaban,";
                }
                if (chkGiachuaVAT.Checked)
                {
                    sql += "b.mabd,trunc(d.gianovat," + i_dongiale + "),d.manguon ";
                }
                else
                {
                    sql += "b.mabd,trunc(d.giamua," + i_dongiale + "),d.manguon ";
                }
                if (chkNhacc.Checked) sql += ", d.nhomcc, ncc.ten";
                sql += ",case when d.gianovat=0 then 0 else (round(d.giamua/d.gianovat,2)-1)*100 end ";
                #endregion lay so lieu nhap do chuyen kho

                #region lay so lieu thu hoi co so tu truc + hoan tra tu truc
                asql = "  select ";
                if (i_tt == 1) asql += "a.khon as makho,";
                if (bGiaban)
                {
                    if (bGiabandot) asql += "b.giaban,";
                    else asql += "c.giaban,";
                }
                else asql += "0 as giaban,";
                if (chkGiachuaVAT.Checked)
                {
                    asql += "0 as loai,b.mabd,trunc(d.gianovat," + i_dongiale + ") as dongia, d.manguon,";
                    asql += "sum(b.soluong) as soluong,sum(b.soluong*d.gianovat) as sotien ";
                }
                else
                {
                    asql += "0 as loai,b.mabd,trunc(d.giamua," + i_dongiale + ") as dongia, d.manguon,";
                    asql += "sum(b.soluong) as soluong,sum(b.soluong*d.giamua) as sotien ";
                }
                if (chkNhacc.Checked) asql += ", d.nhomcc as manhacc, ncc.ten as tennhacc ";
                else asql += ", 0 as manhacc, null as tennhacc ";
                asql += ",case when d.gianovat=0 then 0 else (round(d.giamua/d.gianovat,2)-1)*100 end as vat ";
                asql += "from " + xxx + ".d_xuatll a," + xxx + ".d_xuatct b, " + user + ".d_dmbd c," + xxx + ".d_theodoi d ";
                if (chkNhacc.Checked) asql += ", " + user + ".d_dmnx ncc";
                asql += " where a.id=b.id and b.mabd=c.id and b.sttt=d.id and a.nhom=" + i_nhom + " and a.loai in ('HT','TH') and b.soluong>0";
                if (chkNhacc.Checked) asql += " and d.nhomcc=ncc.id ";
                asql += " and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') < to_date('" + s_tungay + "','dd/mm/yyyy')";
                if (s_kho != "") asql += " and a.khon in (" + s_kho.Substring(0, s_kho.Length - 1) + ")";
                if (s_manhom != "") asql += " and c.manhom in (" + s_manhom.Substring(0, s_manhom.Length - 1) + ")";
                if (s_maduocbv != "") asql += " and c.nhombo in (" + s_maduocbv.Trim().Trim(',') + ")";
                if (manguon.SelectedIndex != -1) asql += " and d.manguon=" + int.Parse(manguon.SelectedValue.ToString());

                asql += " group by ";
                if (i_tt == 1) asql += "a.khon,";
                if (bGiaban)
                {
                    if (bGiabandot) asql += "b.giaban,";
                    else asql += "c.giaban,";
                }
                if (chkGiachuaVAT.Checked)
                {
                    asql += "b.mabd,trunc(d.gianovat," + i_dongiale + "),d.manguon ";
                }
                else
                {
                    asql += "b.mabd,trunc(d.giamua," + i_dongiale + "),d.manguon ";
                }
                if (chkNhacc.Checked) asql += ", d.nhomcc, ncc.ten";
                asql += ",case when d.gianovat=0 then 0 else (round(d.giamua/d.gianovat,2)-1)*100 end ";
                f_Get_Hoantra_Thuhoi_CSTT(d.get_data(asql), "tondau", "sttondau");
                #endregion lay so lieu thu hoi co so tu truc + hoan tra tu truc
                //}
                #endregion  khong la kho trung tam
            }
            else
            {
                #region kho trung tam

                #region lay so lieu do nhap chuyen kho
                sql += " union all select ";
                if (i_tt == 1) sql += "a.khon as makho,";
                if (bGiaban)
                {
                    if (bGiabandot) sql += "b.giaban,";
                    else sql += "c.giaban,";
                }
                else sql += "0 as giaban,";
                if (chkGiachuaVAT.Checked)
                {
                    sql += "1 as loai,b.mabd,trunc(d.gianovat," + i_dongiale + ") as dongia, d.manguon,";
                    sql += "sum(b.soluong) as soluong,sum(b.soluong*d.gianovat) as sotien ";
                }
                else
                {
                    sql += "1 as loai,b.mabd,trunc(d.giamua," + i_dongiale + ") as dongia, d.manguon,";
                    sql += "sum(b.soluong) as soluong,sum(b.soluong*d.giamua) as sotien ";
                }
                if (chkNhacc.Checked) sql += ", d.nhomcc as manhacc, ncc.ten as tennhacc ";
                else sql += ", 0 as manhacc, null as tennhacc ";
                sql += ",case when d.gianovat=0 then 0 else (round(d.giamua/d.gianovat,2)-1)*100 end as vat ";

                sql += "from " + xxx + ".d_xuatll a," + xxx + ".d_xuatct b, " + user + ".d_dmbd c," + xxx + ".d_theodoi d ";
                if (chkNhacc.Checked) sql += ", " + user + ".d_dmnx ncc";
                sql += " where a.id=b.id and b.mabd=c.id and b.sttt=d.id and a.nhom=" + i_nhom + " and a.loai in ('CK') and b.soluong>0";
                sql += " and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') < to_date('" + s_tungay + "','dd/mm/yyyy')";
                if (chkNhacc.Checked) sql += " and d.nhomcc=ncc.id ";
                if (s_kho != "") sql += " and a.khon in (" + s_kho.Substring(0, s_kho.Length - 1) + ")";
                if (s_kho != "") sql += " and a.khox not in (" + s_kho.Substring(0, s_kho.Length - 1) + ")";
                if (s_manhom != "") sql += " and c.manhom in (" + s_manhom.Substring(0, s_manhom.Length - 1) + ")";
                if (s_maduocbv != "") sql += " and c.nhombo in (" + s_maduocbv.Trim().Trim(',') + ")";
                if (manguon.SelectedIndex != -1) sql += " and d.manguon=" + int.Parse(manguon.SelectedValue.ToString());
                //sql += " and a.khox not in (" + s_khott.Substring(0, s_khott.Length - 1) + ")";
                sql += " group by ";
                if (i_tt == 1) sql += "a.khon,";
                if (bGiaban)
                {
                    if (bGiabandot) sql += "b.giaban,";
                    else sql += "c.giaban,";
                }
                if (chkGiachuaVAT.Checked)
                {
                    sql += "b.mabd,trunc(d.gianovat," + i_dongiale + "),d.manguon ";
                }
                else
                {
                    sql += "b.mabd,trunc(d.giamua," + i_dongiale + "),d.manguon ";
                }
                if (chkNhacc.Checked) sql += ", d.nhomcc, ncc.ten";
                sql += ",case when d.gianovat=0 then 0 else (round(d.giamua/d.gianovat,2)-1)*100 end";
                #endregion lay so lieu do nhap chuyen kho

                #region lay so lieu thu hoi co so tu truc + hoan tra tu truc
                asql = "  select ";
                if (i_tt == 1) asql += "a.khon as makho,";
                if (bGiaban)
                {
                    if (bGiabandot) asql += "b.giaban,";
                    else asql += "c.giaban,";
                }
                else asql += "0 as giaban,";
                if (chkGiachuaVAT.Checked)
                {
                    asql += "1 as loai,b.mabd,trunc(d.gianovat," + i_dongiale + ") as dongia, d.manguon,";
                    asql += "sum(b.soluong) as soluong,sum(b.soluong*d.gianovat) as sotien ";
                }
                else
                {
                    asql += "1 as loai,b.mabd,trunc(d.giamua," + i_dongiale + ") as dongia, d.manguon,";
                    asql += "sum(b.soluong) as soluong,sum(b.soluong*d.giamua) as sotien ";
                }
                if (chkNhacc.Checked) asql += ", d.nhomcc as manhacc, ncc.ten as tennhacc ";
                else asql += ", 0 as manhacc, null as tennhacc ";
                asql += ",case when d.gianovat=0 then 0 else (round(d.giamua/d.gianovat,2)-1)*100 end as vat ";
                asql += "from " + xxx + ".d_xuatll a," + xxx + ".d_xuatct b, " + user + ".d_dmbd c," + xxx + ".d_theodoi d ";
                if (chkNhacc.Checked) asql += ", " + user + ".d_dmnx ncc";
                asql += " where a.id=b.id and b.mabd=c.id and b.sttt=d.id and a.nhom=" + i_nhom + " and a.loai in ('TH','HT') and b.soluong>0";
                if (chkNhacc.Checked) asql += " and d.nhomcc=ncc.id ";
                if (s_kho != "") asql += " and a.khon in (" + s_kho.Substring(0, s_kho.Length - 1) + ")";
                if (s_manhom != "") asql += " and c.manhom in (" + s_manhom.Substring(0, s_manhom.Length - 1) + ")";
                if (s_maduocbv != "") asql += " and c.nhombo in (" + s_maduocbv.Trim().Trim(',') + ")";
                if (manguon.SelectedIndex != -1) asql += " and d.manguon=" + int.Parse(manguon.SelectedValue.ToString());
                asql += " and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') < to_date('" + s_tungay + "','dd/mm/yyyy') ";

                asql += " group by ";
                if (i_tt == 1) asql += "a.khon,";
                if (bGiaban)
                {
                    if (bGiabandot) asql += "b.giaban,";
                    else asql += "c.giaban,";
                }
                if (chkGiachuaVAT.Checked)
                {
                    asql += "b.mabd,trunc(d.gianovat," + i_dongiale + "),d.manguon ";
                }
                else
                {
                    asql += "b.mabd,trunc(d.giamua," + i_dongiale + "),d.manguon ";
                }
                if (chkNhacc.Checked) asql += ", d.nhomcc, ncc.ten ";
                asql += ",case when d.gianovat=0 then 0 else (round(d.giamua/d.gianovat,2)-1)*100 end";

                f_Get_Hoantra_Thuhoi_CSTT(d.get_data(asql), "tondau", "sttondau");

                #endregion lay so lieu thu hoi co so tu truc + hoan tra tu truc
                #endregion  kho trung tam
            }

            #region insert item
            //
            string f1 = "tondau", f2 = "sttondau";
            foreach (DataRow r in d.get_data(sql).Tables[0].Rows)
            {
                r3 = d.getrowbyid(dt, "id=" + int.Parse(r["mabd"].ToString()));
                if (r3 != null)
                {
                    exp = "mabd=" + int.Parse(r["mabd"].ToString());
                    exp += " and dongia=" + decimal.Parse(r["dongia"].ToString());
                    if (manguon.SelectedIndex != -1) exp += " and manguon=" + int.Parse(manguon.SelectedValue.ToString());
                    if (i_tt == 1) exp += " and idnn=" + int.Parse(r["makho"].ToString());
                    r1 = d.getrowbyid(ds.Tables[0], exp);
                    if (r1 == null)
                    {
                        r2 = ds.Tables[0].NewRow();
                        r2["manhom"] = r3["manhom"].ToString();
                        r2["tennhom"] = r3["tennhom"].ToString();
                        r2["mabd"] = r["mabd"].ToString();
                        r2["ma"] = r3["ma"].ToString();
                        r2["ten"] = r3["ten"].ToString().Trim() + " " + r3["hamluong"].ToString();
                        if (i_tt == 0) r2["tenhc"] = r3["tenhc"].ToString();
                        else r2["tenhc"] = "";
                        r2["manhacc"] = r["manhacc"].ToString();
                        r2["tennhacc"] = r["tennhacc"].ToString();
                        r2["noingoai"] = "";
                        r2["dang"] = r3["dang"].ToString();
                        r2["tondau"] = 0;
                        r2["sttondau"] = 0;
                        r2["slxuat"] = 0;
                        r2["stxuat"] = 0;
                        r2["sl_tra"] = 0;
                        r2["st_tra"] = 0;
                        r2["dongia"] = r["dongia"].ToString();
                        r2["giaban"] = r["giaban"].ToString();
                        r2["sttt"] = 0;
                        r2["manguon"] = r["manguon"].ToString();
                        r2["stt"] = (r3["tt"].ToString().Trim() == "") ? "0" : r3["tt"].ToString();
                        if (i_tt == 0)
                        {
                            r2["idnn"] = r3["idnn"].ToString();
                            r2["noingoai"] = r3["noingoai"].ToString();
                        }
                        else if (i_tt == 1)
                        {
                            r4 = d.getrowbyid(dtdmkho, "id=" + int.Parse(r["makho"].ToString()));
                            if (r4 != null)
                            {
                                r2["idnn"] = r["makho"].ToString();
                                r2["noingoai"] = r4["ten"].ToString();
                            }
                        }
                        r2["slxuat_ck"] = "0";
                        r2["stxuat_ck"] = "0";
                        r2["slnhap_ck"] = "0";
                        r2["stnhap_ck"] = "0";
                        r2["slnhap"] = "0";
                        r2["stnhap"] = "0";
                        r2["sl_th"] = "0";
                        r2["st_th"] = "0";
                        r2[f1] = r["soluong"].ToString();
                        r2[f2] = r["sotien"].ToString();
                        r2["vat"] = r["vat"].ToString();
                        ds.Tables[0].Rows.Add(r2);
                    }
                    else
                    {
                        DataRow[] dr = ds.Tables[0].Select(exp);
                        dr[0][f1] = decimal.Parse(dr[0][f1].ToString()) + decimal.Parse(r["soluong"].ToString());
                        dr[0][f2] = decimal.Parse(dr[0][f2].ToString()) + decimal.Parse(r["sotien"].ToString());
                    }
                }
            }
            ds.AcceptChanges();
            #endregion insert item
        }
        // 
        private void get_xuat(string d_mmyy)
        {
            xxx = user + d_mmyy;
            sql = "select a.loai, ";
            if (i_tt == 1) sql += "b.makho,";
            if (bGiaban)
            {
                if (bGiabandot) sql += "b.giaban,";
                else sql += "c.giaban,";
            }
            else sql += "0 as giaban,";
            if (chkGiachuaVAT.Checked)
            {
                sql += "b.mabd,trunc(d.gianovat," + i_dongiale + ") as dongia, d.manguon,";
                sql += "sum(b.soluong) as soluong,sum(b.soluong*d.gianovat) as sotien ";
            }
            else
            {
                sql += "b.mabd,trunc(d.giamua," + i_dongiale + ") as dongia, d.manguon,";
                sql += "sum(b.soluong) as soluong,sum(b.soluong*d.giamua) as sotien ";
            }
            //
            if (chkNhacc.Checked) sql += ", d.nhomcc as manhacc, ncc.ten as tennhacc ";
            else sql+=", 0 as manhacc, null as tennhacc ";
            sql += ",case when d.gianovat=0 then 0 else (round(d.giamua/d.gianovat,2)-1)*100 end as vat ";
            //
            sql += "from " + xxx + ".d_xuatsdll a," + xxx + ".d_thucxuat b," + user + ".d_dmbd c," + xxx + ".d_theodoi d ";
            if (chkNhacc.Checked) sql += ", " + user + ".d_dmnx ncc";
            sql += " where a.id=b.id and b.mabd=c.id and b.sttt=d.id and a.loai in(1,4) and a.nhom=" + i_nhom;
            if (chkNhacc.Checked) sql += " and d.nhomcc=ncc.id ";
            if (s_kho != "") sql += " and b.makho in (" + s_kho.Substring(0, s_kho.Length - 1) + ")";
            if (s_manhom != "") sql += " and c.manhom in (" + s_manhom.Substring(0, s_manhom.Length - 1) + ")";
            if (s_maduocbv != "") sql += " and c.nhombo in (" + s_maduocbv.Trim().Trim(',') + ")";
            if (manguon.SelectedIndex != -1) sql += " and d.manguon=" + int.Parse(manguon.SelectedValue.ToString());
            sql += " and b.soluong>0";

            sql += " group by a.loai,";
            if (i_tt == 1) sql += " b.makho,";
            if (bGiaban)
            {
                if (bGiabandot) sql += "b.giaban,";
                else sql += "c.giaban,";
            }
            if (chkGiachuaVAT.Checked)
            {
                sql += "b.mabd,trunc(d.gianovat," + i_dongiale + "),d.manguon";
            }
            else
            {
                sql += "b.mabd,trunc(d.giamua," + i_dongiale + "),d.manguon";
            }
            if (chkNhacc.Checked) sql += ", d.nhomcc, ncc.ten";
            sql += ",case when d.gianovat=0 then 0 else (round(d.giamua/d.gianovat,2)-1)*100 end";
            //xu ly tren d_thucbucstt: bu tu truc
            sql += " union all ";
            sql += " select a.loai, ";
            if (i_tt == 1) sql += "b.makho,";
            if (bGiaban)
            {
                if (bGiabandot) sql += "b.giaban,";
                else sql += "c.giaban,";
            }
            else sql += "0 as giaban,";
            if (chkGiachuaVAT.Checked)
            {
                sql += "b.mabd,trunc(d.gianovat," + i_dongiale + ") as dongia, d.manguon,";
                sql += "sum(b.soluong) as soluong,sum(b.soluong*d.gianovat) as sotien ";
            }
            else
            {
                sql += "b.mabd,trunc(d.giamua," + i_dongiale + ") as dongia, d.manguon,";
                sql += "sum(b.soluong) as soluong,sum(b.soluong*d.giamua) as sotien ";
            }
            //
            //
            if (chkNhacc.Checked) sql += ", d.nhomcc as manhacc, ncc.ten as tennhacc ";
            else sql+=", 0 as manhacc, null as tennhacc ";
            sql += ",case when d.gianovat=0 then 0 else (round(d.giamua/d.gianovat,2)-1)*100 end as vat ";    
            //
            sql += "from " + xxx + ".d_xuatsdll a," + xxx + ".d_thucbucstt b," + user + ".d_dmbd c," + xxx + ".d_theodoi d ";
            if (chkNhacc.Checked) sql += ", " + user + ".d_dmnx ncc"; 
            sql+=" where a.id=b.id and b.mabd=c.id and b.sttt=d.id and a.loai in(2) and a.nhom=" + i_nhom;
            if (chkNhacc.Checked) sql += " and d.nhomcc=ncc.id ";
            if (s_kho != "") sql += " and b.makho in (" + s_kho.Substring(0, s_kho.Length - 1) + ")";
            if (s_manhom != "") sql += " and c.manhom in (" + s_manhom.Substring(0, s_manhom.Length - 1) + ")";
            if (s_maduocbv != "") sql += " and c.nhombo in (" + s_maduocbv.Trim().Trim(',') + ")";
            if (manguon.SelectedIndex != -1) sql += " and d.manguon=" + int.Parse(manguon.SelectedValue.ToString());
            sql += " and b.soluong>0";

            sql += " group by a.loai,";
            if (i_tt == 1) sql += " b.makho,";
            if (bGiaban)
            {
                if (bGiabandot) sql += "b.giaban,";
                else sql += "c.giaban,";
            }
            if (chkGiachuaVAT.Checked)
            {
                sql += "b.mabd,trunc(d.gianovat," + i_dongiale + "),d.manguon";
            }
            else
            {
                sql += "b.mabd,trunc(d.giamua," + i_dongiale + "),d.manguon";
            }
            if (chkNhacc.Checked) sql += ", d.nhomcc, ncc.ten";
            sql += ",case when d.gianovat=0 then 0 else (round(d.giamua/d.gianovat,2)-1)*100 end ";
            //xuat CK, BS, XK
            sql += " union all select case when a.loai='XK' and a.khon=0 then to_number('56') else to_number('52') end as loai,";
            if (i_tt == 1) sql += "a.khox makho,";
            if (bGiaban)
            {
                if (bGiabandot) sql += "b.giaban,";
                else sql += "c.giaban,";
            }
            else sql += "0 as giaban,";
            if (chkGiachuaVAT.Checked)
            {
                sql += "b.mabd,trunc(d.gianovat," + i_dongiale + ") as dongia, d.manguon,";
                sql += "sum(b.soluong) as soluong,sum(b.soluong*d.gianovat) as sotien ";
            }
            else
            {
                sql += "b.mabd,trunc(d.giamua," + i_dongiale + ") as dongia, d.manguon,";
                sql += "sum(b.soluong) as soluong,sum(b.soluong*d.giamua) as sotien ";
            }
            //
            //
            if (chkNhacc.Checked) sql += ", d.nhomcc as manhacc, ncc.ten as tennhacc ";
            else sql+=", 0 as manhacc, null as tennhacc ";
            sql += ",case when d.gianovat=0 then 0 else (round(d.giamua/d.gianovat,2)-1)*100 end as vat ";
            //
            sql += " from " + xxx + ".d_xuatll a," + xxx + ".d_xuatct b," + user + ".d_dmbd c," + xxx + ".d_theodoi d ";
            if (chkNhacc.Checked) sql += ", " + user + ".d_dmnx ncc";            
            sql+=" where a.id=b.id and b.mabd=c.id and b.sttt=d.id and a.nhom=" + i_nhom;
            if (chkNhacc.Checked) sql += " and d.nhomcc=ncc.id ";
            sql += " and a.loai in ('BS','XK')";
            if (s_kho != "") sql += " and a.khox in (" + s_kho.Substring(0, s_kho.Length - 1) + ")";
            if (s_manhom != "") sql += " and c.manhom in (" + s_manhom.Substring(0, s_manhom.Length - 1) + ")";
            if (s_maduocbv != "") sql += " and c.nhombo in (" + s_maduocbv.Trim().Trim(',') + ")";
            if (manguon.SelectedIndex != -1) sql += " and d.manguon=" + int.Parse(manguon.SelectedValue.ToString());
            sql += " and b.soluong>0";

            sql += " group by ";
            if (i_tt == 1) sql += " a.khox,";
            if (bGiaban)
            {
                if (bGiabandot) sql += "b.giaban,";
                else sql += "c.giaban,";
            }
            if (chkGiachuaVAT.Checked)
            {
                sql += "b.mabd,trunc(d.gianovat," + i_dongiale + "),d.manguon";
            }
            else
            {
                sql += "b.mabd,trunc(d.giamua," + i_dongiale + "),d.manguon";
            }
            if (chkNhacc.Checked) sql += ", d.nhomcc, ncc.ten";
            sql += ",case when d.gianovat=0 then 0 else (round(d.giamua/d.gianovat,2)-1)*100 end ";
            sql += ", case when a.loai='XK' and a.khon=0 then to_number('56') else to_number('52') end";
            //BHYT
            sql += " union all select to_number('51') as loai, ";
            if (i_tt == 1) sql += "b.makho,";
            if (bGiaban)
            {
                if (bGiabandot) sql += "b.giaban,";
                else sql += "c.giaban,";
            }
            else sql += "0 as giaban,";
            if (chkGiachuaVAT.Checked)
            {
                sql += "b.mabd,trunc(d.gianovat," + i_dongiale + ") as dongia, d.manguon,";
                sql += "sum(b.soluong) as soluong,sum(b.soluong*d.gianovat) as sotien ";
            }
            else
            {
                sql += "b.mabd,trunc(d.giamua," + i_dongiale + ") as dongia, d.manguon,";
                sql += "sum(b.soluong) as soluong,sum(b.soluong*d.giamua) as sotien ";
            }
            if (chkNhacc.Checked) sql += ", d.nhomcc as manhacc, ncc.ten as tennhacc ";
            else sql+=", 0 as manhacc, null as tennhacc ";
            sql += ",case when d.gianovat=0 then 0 else (round(d.giamua/d.gianovat,2)-1)*100 end as vat ";
            sql += "from " + xxx + ".bhytkb a," + xxx + ".bhytthuoc b," + user + ".d_dmbd c," + xxx + ".d_theodoi d ";
            if (chkNhacc.Checked) sql += ", " + user + ".d_dmnx ncc";            
            sql+=" where a.id=b.id and b.mabd=c.id and b.sttt=d.id and a.nhom=" + i_nhom;
            if (chkNhacc.Checked) sql += " and d.nhomcc=ncc.id ";
            if (s_kho != "") sql += " and b.makho in (" + s_kho.Substring(0, s_kho.Length - 1) + ")";
            if (s_manhom != "") sql += " and c.manhom in (" + s_manhom.Substring(0, s_manhom.Length - 1) + ")";
            if (s_maduocbv != "") sql += " and c.nhombo in (" + s_maduocbv.Trim().Trim(',') + ")";
            if (manguon.SelectedIndex != -1) sql += " and d.manguon=" + int.Parse(manguon.SelectedValue.ToString());
            sql += " and b.soluong>0";

            sql += " group by ";
            if (i_tt == 1) sql += " b.makho,";
            if (bGiaban)
            {
                if (bGiabandot) sql += "b.giaban,";
                else sql += "c.giaban,";
            }
            if (chkGiachuaVAT.Checked)
            {
                sql += "b.mabd,trunc(d.gianovat," + i_dongiale + "),d.manguon";
            }
            else
            {
                sql += "b.mabd,trunc(d.giamua," + i_dongiale + "),d.manguon";
            }
            if (chkNhacc.Checked) sql += ", d.nhomcc, ncc.ten";
            sql += ",case when d.gianovat=0 then 0 else (round(d.giamua/d.gianovat,2)-1)*100 end ";
            //ngoaitru
            //BHYT
            sql += " union all select to_number('53') as loai, ";
            if (i_tt == 1) sql += "b.makho,";
            if (bGiaban)
            {
                if (bGiabandot) sql += "b.giaban,";
                else sql += "c.giaban,";
            }
            else sql += "0 as giaban,";
            if (chkGiachuaVAT.Checked)
            {
                sql += "b.mabd,trunc(d.gianovat," + i_dongiale + ") as dongia, d.manguon,";
                sql += "sum(b.soluong) as soluong,sum(b.soluong*d.gianovat) as sotien ";
            }
            else
            {
                sql += "b.mabd,trunc(d.giamua," + i_dongiale + ") as dongia, d.manguon,";
                sql += "sum(b.soluong) as soluong,sum(b.soluong*d.giamua) as sotien ";
            }
            if (chkNhacc.Checked) sql += ", d.nhomcc as manhacc, ncc.ten as tennhacc ";
            else sql+=", 0 as manhacc, null as tennhacc ";
            sql += ",case when d.gianovat=0 then 0 else (round(d.giamua/d.gianovat,2)-1)*100 end as vat ";
            sql += "from " + xxx + ".d_ngtrull a," + xxx + ".d_ngtruct b," + user + ".d_dmbd c," + xxx + ".d_theodoi d ";
            if (chkNhacc.Checked) sql += ", " + user + ".d_dmnx ncc";
            sql+=" where a.id=b.id and b.mabd=c.id and b.sttt=d.id and a.nhom=" + i_nhom;
            if (chkNhacc.Checked) sql += " and d.nhomcc=ncc.id ";
            if (s_kho != "") sql += " and b.makho in (" + s_kho.Substring(0, s_kho.Length - 1) + ")";
            if (s_manhom != "") sql += " and c.manhom in (" + s_manhom.Substring(0, s_manhom.Length - 1) + ")";
            if (s_maduocbv != "") sql += " and c.nhombo in (" + s_maduocbv.Trim().Trim(',') + ")";
            if (manguon.SelectedIndex != -1) sql += " and d.manguon=" + int.Parse(manguon.SelectedValue.ToString());
            sql += " and b.soluong>0";

            sql += " group by ";
            if (i_tt == 1) sql += " b.makho,";
            if (bGiaban)
            {
                if (bGiabandot) sql += "b.giaban,";
                else sql += "c.giaban,";
            }
            if (chkGiachuaVAT.Checked)
            {
                sql += "b.mabd,trunc(d.gianovat," + i_dongiale + "),d.manguon";
            }
            else
            {
                sql += "b.mabd,trunc(d.giamua," + i_dongiale + "),d.manguon";
            }
            if (chkNhacc.Checked) sql += ", d.nhomcc, ncc.ten";
            sql += ",case when d.gianovat=0 then 0 else (round(d.giamua/d.gianovat,2)-1)*100 end ";
            foreach (DataRow r in d.get_data(sql).Tables[0].Rows)
            {
                exp = "mabd=" + int.Parse(r["mabd"].ToString());
                exp += " and dongia=" + decimal.Parse(r["dongia"].ToString());
                if (manguon.SelectedIndex != -1) exp += " and manguon=" + int.Parse(manguon.SelectedValue.ToString());
                if (i_tt == 1) exp += " and idnn=" + int.Parse(r["makho"].ToString());
                r1 = d.getrowbyid(ds.Tables[0], exp);
                if (r1 == null)
                {
                    r3 = d.getrowbyid(dt, "id=" + int.Parse(r["mabd"].ToString()));
                    if (r3 != null)
                    {
                        r2 = ds.Tables[0].NewRow();
                        r2["manhom"] = r3["manhom"].ToString();
                        r2["tennhom"] = r3["tennhom"].ToString();
                        r2["mabd"] = r["mabd"].ToString();
                        r2["ma"] = r3["ma"].ToString();
                        r2["ten"] = r3["ten"].ToString().Trim() + " " + r3["hamluong"].ToString();
                        if (i_tt == 0) r2["tenhc"] = r3["tenhc"].ToString();
                        else r2["tenhc"] = "";
                        r2["manhacc"] = r["manhacc"].ToString();
                        r2["tennhacc"] = r["tennhacc"].ToString();
                        r2["noingoai"] = "";
                        r2["dang"] = r3["dang"].ToString();
                        r2["tondau"] = 0;
                        r2["sttondau"] = 0;
                        r2["slnhap"] = 0;
                        r2["stnhap"] = 0;
                        r2["slnhap_ck"] = 0;
                        r2["stnhap_ck"] = 0;
                        r2["slxuat_ck"] = 0;
                        r2["stxuat_ck"] = 0;
                        r2["sl_tra"] = 0;
                        r2["st_tra"] = 0;
                        r2["slxuat"] = 0;
                        r2["stxuat"] = 0;
                        r2["sl_th"] = 0;
                        r2["st_th"] = 0;
                        //                        
                        r2["SLXUAT_BAN"] = 0;
                        r2["STXUAT_BAN"] = 0;
                        if (r["loai"].ToString() == "53")//xuatban
                        {
                            r2["SLXUAT_BAN"] = r["soluong"].ToString();
                            r2["STXUAT_BAN"] = r["sotien"].ToString();
                        }
                        if (r["loai"].ToString() == "56")//xuat tra nha cung cap
                        {
                            r2["SL_TRANHACC"] = r["soluong"].ToString();
                            r2["ST_TRANHACC"] = r["sotien"].ToString();
                        }
                        r2["slxuat"] = r["soluong"].ToString();
                        r2["stxuat"] = r["sotien"].ToString();

                        r2["dongia"] = r["dongia"].ToString();
                        r2["giaban"] = r["giaban"].ToString();
                        r2["sttt"] = 0;
                        r2["manguon"] = r["manguon"].ToString();
                        r2["stt"] = (r3["tt"].ToString().Trim() == "") ? "0" : r3["tt"].ToString();
                        r2["noingoai"] = "";
                        r2["vat"] = r["vat"].ToString();
                        if (i_tt == 0)
                        {
                            r2["idnn"] = r3["idnn"].ToString();
                            r2["noingoai"] = r3["noingoai"].ToString();
                        }
                        else if (i_tt == 1)
                        {
                            r4 = d.getrowbyid(dtdmkho, "id=" + int.Parse(r["makho"].ToString()));
                            if (r4 != null)
                            {
                                r2["idnn"] = r["makho"].ToString();
                                r2["noingoai"] = r4["ten"].ToString();
                            }
                        }

                        ds.Tables[0].Rows.Add(r2);
                    }
                }
                else
                {
                    DataRow[] dr = ds.Tables[0].Select(exp);
                    if (r["loai"].ToString() == "53")//xuat ban
                    {
                        dr[0]["SLXUAT_BAN"] = ((dr[0]["SLXUAT_BAN"].ToString() == "") ? 0 : decimal.Parse(dr[0]["SLXUAT_BAN"].ToString())) + decimal.Parse(r["soluong"].ToString());
                        dr[0]["STXUAT_BAN"] = ((dr[0]["STXUAT_BAN"].ToString() == "") ? 0 : decimal.Parse(dr[0]["STXUAT_BAN"].ToString())) + decimal.Parse(r["sotien"].ToString());
                    }
                    if (r["loai"].ToString() == "56")//xuat ban
                    {
                        dr[0]["SL_TRANHACC"] = ((dr[0]["SL_TRANHACC"].ToString() == "") ? 0 : decimal.Parse(dr[0]["SL_TRANHACC"].ToString())) + decimal.Parse(r["soluong"].ToString());
                        dr[0]["ST_TRANHACC"] = ((dr[0]["ST_TRANHACC"].ToString() == "") ? 0 : decimal.Parse(dr[0]["ST_TRANHACC"].ToString())) + decimal.Parse(r["sotien"].ToString());
                    }
                    dr[0]["slxuat"] = decimal.Parse(dr[0]["slxuat"].ToString()) + decimal.Parse(r["soluong"].ToString());
                    dr[0]["stxuat"] = decimal.Parse(dr[0]["stxuat"].ToString()) + decimal.Parse(r["sotien"].ToString());
                }
            }
            sql = "select ";
            if (i_tt == 1) sql += "a.khox makho,";
            if (bGiaban)
            {
                if (bGiabandot) sql += "b.giaban,";
                else sql += "c.giaban,";
            }
            else sql += "0 as giaban,";
            if (chkGiachuaVAT.Checked)
            {
                sql += "b.mabd,trunc(d.gianovat," + i_dongiale + ") as dongia,d.manguon,sum(b.soluong) as soluong,sum(b.soluong*d.gianovat) as sotien ";
            }
            else
            {
                sql += "b.mabd,trunc(d.giamua," + i_dongiale + ") as dongia,d.manguon,sum(b.soluong) as soluong,sum(b.soluong*d.giamua) as sotien ";
            }
            if (chkNhacc.Checked) sql += ", d.nhomcc as manhacc, ncc.ten as tennhacc ";
            else sql+=", 0 as manhacc, null as tennhacc ";
            sql += ",case when d.gianovat=0 then 0 else (round(d.giamua/d.gianovat,2)-1)*100 end as vat ";
            
            sql += "from " + xxx + ".d_xuatll a," + xxx + ".d_xuatct b," + user + ".d_dmbd c," + xxx + ".d_theodoi d ";
            if (chkNhacc.Checked) sql += ", " + user + ".d_dmnx ncc";
            sql += " where a.id=b.id and b.mabd=c.id and b.sttt=d.id and a.nhom=" + i_nhom + " and a.loai in ('CK')";
            if (chkNhacc.Checked) sql += " and d.nhomcc=ncc.id ";
            if (s_kho != "") sql += " and a.khox in (" + s_kho.Substring(0, s_kho.Length - 1) + ")";
            if (s_kho != "") sql += " and a.khon not in (" + s_kho.Substring(0, s_kho.Length - 1) + ")";
            if (s_manhom != "") sql += " and c.manhom in (" + s_manhom.Substring(0, s_manhom.Length - 1) + ")";
            if (s_maduocbv != "") sql += " and c.nhombo in (" + s_maduocbv.Trim().Trim(',') + ")";
            if (manguon.SelectedIndex != -1) sql += " and d.manguon=" + int.Parse(manguon.SelectedValue.ToString());
            sql += " and b.soluong>0";

            sql += " group by ";
            if (i_tt == 1) sql += "a.khox,";
            if (bGiaban)
            {
                if (bGiabandot) sql += "b.giaban,";
                else sql += "c.giaban,";
            }
            if (chkGiachuaVAT.Checked)
            {
                sql += "b.mabd,trunc(d.gianovat," + i_dongiale + "),d.manguon";
            }
            else
            {
                sql += "b.mabd,trunc(d.giamua," + i_dongiale + "),d.manguon";
            }
            if (chkNhacc.Checked) sql += ", d.nhomcc, ncc.ten";
            sql += ",case when d.gianovat=0 then 0 else (round(d.giamua/d.gianovat,2)-1)*100 end ";
            foreach (DataRow r in d.get_data(sql).Tables[0].Rows)
            {
                exp = "mabd=" + int.Parse(r["mabd"].ToString());
                exp += " and dongia=" + decimal.Parse(r["dongia"].ToString());
                if (manguon.SelectedIndex != -1) exp += " and manguon=" + int.Parse(manguon.SelectedValue.ToString());
                if (i_tt == 1) exp += " and idnn=" + int.Parse(r["makho"].ToString());
                r1 = d.getrowbyid(ds.Tables[0], exp);
                if (r1 == null)
                {
                    r3 = d.getrowbyid(dt, "id=" + int.Parse(r["mabd"].ToString()));
                    if (r3 != null)
                    {
                        r2 = ds.Tables[0].NewRow();
                        r2["manhom"] = r3["manhom"].ToString();
                        r2["tennhom"] = r3["tennhom"].ToString();
                        r2["mabd"] = r["mabd"].ToString();
                        r2["ma"] = r3["ma"].ToString();
                        r2["ten"] = r3["ten"].ToString().Trim() + " " + r3["hamluong"].ToString();
                        if (i_tt == 0) r2["tenhc"] = r3["tenhc"].ToString();
                        else r2["tenhc"] = "";
                        r2["manhacc"] = r["manhacc"].ToString();
                        r2["tennhacc"] = r["tennhacc"].ToString();
                        r2["noingoai"] = "";
                        r2["dang"] = r3["dang"].ToString();
                        r2["tondau"] = 0;
                        r2["sttondau"] = 0;
                        r2["slnhap"] = 0;
                        r2["stnhap"] = 0;
                        r2["slnhap_ck"] = 0;
                        r2["stnhap_ck"] = 0;
                        r2["slxuat"] = 0;
                        r2["stxuat"] = 0;
                        r2["slxuat_ck"] = 0;
                        r2["stxuat_ck"] = 0;
                        r2["sl_tra"] = 0;
                        r2["st_tra"] = 0;
                        if (bGiaban && chkchuyenkho.Checked==false)
                        {
                            r2["slxuat"] = r["soluong"].ToString();
                            r2["stxuat"] = r["sotien"].ToString();
                        }
                        else
                        {
                            r2["slxuat_ck"] = r["soluong"].ToString();
                            r2["stxuat_ck"] = r["sotien"].ToString();
                        }
                        r2["dongia"] = r["dongia"].ToString();
                        r2["giaban"] = r["giaban"].ToString();
                        r2["sttt"] = 0;
                        r2["manguon"] = r["manguon"].ToString();
                        r2["stt"] = (r3["tt"].ToString().Trim() == "") ? "0" : r3["tt"].ToString();
                        if (i_tt == 0)
                        {
                            r2["idnn"] = r3["idnn"].ToString();
                            r2["noingoai"] = r3["noingoai"].ToString();
                        }
                        else if (i_tt == 1)
                        {
                            r4 = d.getrowbyid(dtdmkho, "id=" + int.Parse(r["makho"].ToString()));
                            if (r4 != null)
                            {
                                r2["idnn"] = r["makho"].ToString();
                                r2["noingoai"] = r4["ten"].ToString();
                            }
                        }
                        r2["vat"] = r["vat"].ToString();
                        ds.Tables[0].Rows.Add(r2);
                    }
                }
                else
                {
                    DataRow[] dr = ds.Tables[0].Select(exp);
                    if (bGiaban && chkchuyenkho.Checked == false)
                    {
                        dr[0]["slxuat"] = decimal.Parse(dr[0]["slxuat"].ToString()) + decimal.Parse(r["soluong"].ToString());
                        dr[0]["stxuat"] = decimal.Parse(dr[0]["stxuat"].ToString()) + decimal.Parse(r["sotien"].ToString());
                    }
                    else
                    {
                        dr[0]["slxuat_ck"] = decimal.Parse(dr[0]["slxuat_ck"].ToString()) + decimal.Parse(r["soluong"].ToString());
                        dr[0]["stxuat_ck"] = decimal.Parse(dr[0]["stxuat_ck"].ToString()) + decimal.Parse(r["sotien"].ToString());
                    }
                }
            }
            ds.AcceptChanges();
        }
        // xuat theo ngay 
        private void get_xuat_ddmmyy(string d_mmyy, string s_tungay, string s_denngay)
        {
            xxx = user + d_mmyy;
            sql = "select a.loai,";
            if (i_tt == 1) sql += "b.makho,";
            if (bGiaban)
            {
                if (bGiabandot) sql += "b.giaban,";
                else sql += "c.giaban,";
            }
            else sql += "0 as giaban,";
            if (chkGiachuaVAT.Checked)
            {
                sql += "b.mabd,trunc(d.gianovat," + i_dongiale + ") as dongia, d.manguon,";
                sql += "sum(b.soluong) as soluong,sum(b.soluong*d.gianovat) as sotien ";
            }
            else
            {
                sql += "b.mabd,trunc(d.giamua," + i_dongiale + ") as dongia, d.manguon,";
                sql += "sum(b.soluong) as soluong,sum(b.soluong*d.giamua) as sotien ";
            }
            //
            if (chkNhacc.Checked) sql += ", d.nhomcc as manhacc, ncc.ten as tennhacc ";
            else sql += ", 0 as manhacc, null as tennhacc ";
            sql += ",case when d.gianovat=0 then 0 else (round(d.giamua/d.gianovat,2)-1)*100 end as vat ";
            //
            sql += "from " + xxx + ".d_xuatsdll a," + xxx + ".d_thucxuat b," + user + ".d_dmbd c," + xxx + ".d_theodoi d ";
            if (chkNhacc.Checked) sql += ", " + user + ".d_dmnx ncc";
            sql += " where a.id=b.id and b.mabd=c.id and b.sttt=d.id and a.loai in(1,4) and a.nhom=" + i_nhom;
            if (chkNhacc.Checked) sql += " and d.nhomcc=ncc.id ";
            sql += " and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + s_tungay + "','dd/mm/yyyy') and to_date('" + s_denngay + "','dd/mm/yyyy')";
            if (s_kho != "") sql += " and b.makho in (" + s_kho.Substring(0, s_kho.Length - 1) + ")";
            if (s_manhom != "") sql += " and c.manhom in (" + s_manhom.Substring(0, s_manhom.Length - 1) + ")";
            if (s_maduocbv != "") sql += " and c.nhombo in (" + s_maduocbv.Trim().Trim(',') + ")";
            if (manguon.SelectedIndex != -1) sql += " and d.manguon=" + int.Parse(manguon.SelectedValue.ToString());
            sql += " and b.soluong>0";
            // 
            sql += " group by a.loai,";
            if (i_tt == 1) sql += " b.makho,";
            if (bGiaban)
            {
                if (bGiabandot) sql += "b.giaban,";
                else sql += "c.giaban,";
            }
            if (chkGiachuaVAT.Checked)
            {
                sql += "b.mabd,trunc(d.gianovat," + i_dongiale + "),d.manguon";
            }
            else
            {
                sql += "b.mabd,trunc(d.giamua," + i_dongiale + "),d.manguon";
            }
            if (chkNhacc.Checked) sql += ", d.nhomcc, ncc.ten";
            sql += ",case when d.gianovat=0 then 0 else (round(d.giamua/d.gianovat,2)-1)*100 end";
            
            //xu ly tren d_thucbucstt: bu tu truc
            sql += " union all select a.loai,";
            if (i_tt == 1) sql += "b.makho,";
            if (bGiaban)
            {
                if (bGiabandot) sql += "b.giaban,";
                else sql += "c.giaban,";
            }
            else sql += "0 as giaban,";
            if (chkGiachuaVAT.Checked)
            {
                sql += "b.mabd,trunc(d.gianovat," + i_dongiale + ") as dongia, d.manguon,";
                sql += "sum(b.soluong) as soluong,sum(b.soluong*d.gianovat) as sotien ";
            }
            else
            {
                sql += "b.mabd,trunc(d.giamua," + i_dongiale + ") as dongia, d.manguon,";
                sql += "sum(b.soluong) as soluong,sum(b.soluong*d.giamua) as sotien ";
            }
            //
            //
            if (chkNhacc.Checked) sql += ", d.nhomcc as manhacc, ncc.ten as tennhacc ";
            else sql += ", 0 as manhacc, null as tennhacc ";
            sql += ",case when d.gianovat=0 then 0 else (round(d.giamua/d.gianovat,2)-1)*100 end as vat ";
            //
            sql += "from " + xxx + ".d_xuatsdll a," + xxx + ".d_thucbucstt b," + user + ".d_dmbd c," + xxx + ".d_theodoi d ";
            if (chkNhacc.Checked) sql += ", " + user + ".d_dmnx ncc";
            sql += " where a.id=b.id and b.mabd=c.id and b.sttt=d.id and a.loai in(2) and a.nhom=" + i_nhom;
            if (chkNhacc.Checked) sql += " and d.nhomcc=ncc.id ";
            sql += " and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + s_tungay + "','dd/mm/yyyy') and to_date('" + s_denngay + "','dd/mm/yyyy')";
            if (s_kho != "") sql += " and b.makho in (" + s_kho.Substring(0, s_kho.Length - 1) + ")";
            if (s_manhom != "") sql += " and c.manhom in (" + s_manhom.Substring(0, s_manhom.Length - 1) + ")";
            if (s_maduocbv != "") sql += " and c.nhombo in (" + s_maduocbv.Trim().Trim(',') + ")";
            if (manguon.SelectedIndex != -1) sql += " and d.manguon=" + int.Parse(manguon.SelectedValue.ToString());
            sql += " and b.soluong>0";
            // 

            sql += " group by a.loai, ";
            if (i_tt == 1) sql += " b.makho,";
            if (bGiaban)
            {
                if (bGiabandot) sql += "b.giaban,";
                else sql += "c.giaban,";
            }
            if (chkGiachuaVAT.Checked)
            {
                sql += "b.mabd,trunc(d.gianovat," + i_dongiale + "),d.manguon";
            }
            else
            {
                sql += "b.mabd,trunc(d.giamua," + i_dongiale + "),d.manguon";
            }
            if (chkNhacc.Checked) sql += ", d.nhomcc, ncc.ten";
            sql += ",case when d.gianovat=0 then 0 else (round(d.giamua/d.gianovat,2)-1)*100 end ";
            //xuat CK, BS, XK
            sql += " union all select case when a.loai='XK' and a.khon=0 then to_number('56') else to_number('52') end as loai,";
            if (i_tt == 1) sql += "a.khox makho,";
            if (bGiaban)
            {
                if (bGiabandot) sql += "b.giaban,";
                else sql += "c.giaban,";
            }
            else sql += "0 as giaban,";
            if (chkGiachuaVAT.Checked)
            {
                sql += "b.mabd,trunc(d.gianovat," + i_dongiale + ") as dongia, d.manguon,";
                sql += "sum(b.soluong) as soluong,sum(b.soluong*d.gianovat) as sotien ";
            }
            else
            {
                sql += "b.mabd,trunc(d.giamua," + i_dongiale + ") as dongia, d.manguon,";
                sql += "sum(b.soluong) as soluong,sum(b.soluong*d.giamua) as sotien ";
            }
            //
            //
            if (chkNhacc.Checked) sql += ", d.nhomcc as manhacc, ncc.ten as tennhacc ";
            else sql += ", 0 as manhacc, null as tennhacc ";
            sql += ",case when d.gianovat=0 then 0 else (round(d.giamua/d.gianovat,2)-1)*100 end as vat ";
            //
            sql += " from " + xxx + ".d_xuatll a," + xxx + ".d_xuatct b," + user + ".d_dmbd c," + xxx + ".d_theodoi d ";
            if (chkNhacc.Checked) sql += ", " + user + ".d_dmnx ncc";
            sql += " where a.id=b.id and b.mabd=c.id and b.sttt=d.id and a.nhom=" + i_nhom;
            if (chkNhacc.Checked) sql += " and d.nhomcc=ncc.id ";
            sql += " and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + s_tungay + "','dd/mm/yyyy') and to_date('" + s_denngay + "','dd/mm/yyyy')";
            sql += " and a.loai in ('BS','XK')";
            if (s_kho != "") sql += " and a.khox in (" + s_kho.Substring(0, s_kho.Length - 1) + ")";
            if (s_manhom != "") sql += " and c.manhom in (" + s_manhom.Substring(0, s_manhom.Length - 1) + ")";
            if (s_maduocbv != "") sql += " and c.nhombo in (" + s_maduocbv.Trim().Trim(',') + ")";
            if (manguon.SelectedIndex != -1) sql += " and d.manguon=" + int.Parse(manguon.SelectedValue.ToString());
            sql += " and b.soluong>0";

            sql += " group by ";
            if (i_tt == 1) sql += " a.khox,";
            if (bGiaban)
            {
                if (bGiabandot) sql += "b.giaban,";
                else sql += "c.giaban,";
            }
            if (chkGiachuaVAT.Checked)
            {
                sql += "b.mabd,trunc(d.gianovat," + i_dongiale + "),d.manguon";
            }
            else
            {
                sql += "b.mabd,trunc(d.giamua," + i_dongiale + "),d.manguon";
            }
            if (chkNhacc.Checked) sql += ", d.nhomcc, ncc.ten";
            sql += ",case when d.gianovat=0 then 0 else (round(d.giamua/d.gianovat,2)-1)*100 end";
            sql += ", case when a.loai='XK' and a.khon=0 then to_number('56') else to_number('52') end";
            //BHYT
            sql += " union all select to_number('51') as loai,";
            if (i_tt == 1) sql += "b.makho,";
            if (bGiaban)
            {
                if (bGiabandot) sql += "b.giaban,";
                else sql += "c.giaban,";
            }
            else sql += "0 as giaban,";
            if (chkGiachuaVAT.Checked)
            {
                sql += "b.mabd,trunc(d.gianovat," + i_dongiale + ") as dongia, d.manguon,";
                sql += "sum(b.soluong) as soluong,sum(b.soluong*d.gianovat) as sotien ";
            }
            else
            {
                sql += "b.mabd,trunc(d.giamua," + i_dongiale + ") as dongia, d.manguon,";
                sql += "sum(b.soluong) as soluong,sum(b.soluong*d.giamua) as sotien ";
            }
            if (chkNhacc.Checked) sql += ", d.nhomcc as manhacc, ncc.ten as tennhacc ";
            else sql += ", 0 as manhacc, null as tennhacc ";
            sql += ",case when d.gianovat=0 then 0 else (round(d.giamua/d.gianovat,2)-1)*100 end as vat ";
            sql += "from " + xxx + ".bhytkb a," + xxx + ".bhytthuoc b," + user + ".d_dmbd c," + xxx + ".d_theodoi d ";
            if (chkNhacc.Checked) sql += ", " + user + ".d_dmnx ncc";
            sql += " where a.id=b.id and b.mabd=c.id and b.sttt=d.id and a.nhom=" + i_nhom;
            sql += " and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + s_tungay + "','dd/mm/yyyy') and to_date('" + s_denngay + "','dd/mm/yyyy')";
            if (chkNhacc.Checked) sql += " and d.nhomcc=ncc.id ";
            if (s_kho != "") sql += " and b.makho in (" + s_kho.Substring(0, s_kho.Length - 1) + ")";
            if (s_manhom != "") sql += " and c.manhom in (" + s_manhom.Substring(0, s_manhom.Length - 1) + ")";
            if (s_maduocbv != "") sql += " and c.nhombo in (" + s_maduocbv.Trim().Trim(',') + ")";
            if (manguon.SelectedIndex != -1) sql += " and d.manguon=" + int.Parse(manguon.SelectedValue.ToString());
            sql += " and b.soluong>0";
    
            sql += " group by ";
            if (i_tt == 1) sql += " b.makho,";
            if (bGiaban)
            {
                if (bGiabandot) sql += "b.giaban,";
                else sql += "c.giaban,";
            }
            if (chkGiachuaVAT.Checked)
            {
                sql += "b.mabd,trunc(d.gianovat," + i_dongiale + "),d.manguon";
            }
            else
            {
                sql += "b.mabd,trunc(d.giamua," + i_dongiale + "),d.manguon";
            }
            if (chkNhacc.Checked) sql += ", d.nhomcc, ncc.ten";
            sql += ",case when d.gianovat=0 then 0 else (round(d.giamua/d.gianovat,2)-1)*100 end ";
            //ngoaitru
            //BHYT
            sql += " union all select to_number('53') as loai, ";
            if (i_tt == 1) sql += "b.makho,";
            if (bGiaban)
            {
                if (bGiabandot) sql += "b.giaban,";
                else sql += "c.giaban,";
            }
            else sql += "0 as giaban,";
            if (chkGiachuaVAT.Checked)
            {
                sql += "b.mabd,trunc(d.gianovat," + i_dongiale + ") as dongia, d.manguon,";
                sql += "sum(b.soluong) as soluong,sum(b.soluong*d.gianovat) as sotien ";
            }
                // 
            else
            {
                sql += "b.mabd,trunc(d.giamua," + i_dongiale + ") as dongia, d.manguon,";
                sql += "sum(b.soluong) as soluong,sum(b.soluong*d.giamua) as sotien ";
            }
            if (chkNhacc.Checked) sql += ", d.nhomcc as manhacc, ncc.ten as tennhacc ";
            else sql += ", 0 as manhacc, null as tennhacc ";
            sql += ",case when d.gianovat=0 then 0 else (round(d.giamua/d.gianovat,2)-1)*100 end as vat ";
            sql += "from " + xxx + ".d_ngtrull a," + xxx + ".d_ngtruct b," + user + ".d_dmbd c," + xxx + ".d_theodoi d ";
            if (chkNhacc.Checked) sql += ", " + user + ".d_dmnx ncc";
            sql += " where a.id=b.id and b.mabd=c.id and b.sttt=d.id and a.nhom=" + i_nhom;
            sql += " and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + s_tungay + "','dd/mm/yyyy') and to_date('" + s_denngay + "','dd/mm/yyyy')";
            if (chkNhacc.Checked) sql += " and d.nhomcc=ncc.id ";
            if (s_kho != "") sql += " and b.makho in (" + s_kho.Substring(0, s_kho.Length - 1) + ")";
            if (s_manhom != "") sql += " and c.manhom in (" + s_manhom.Substring(0, s_manhom.Length - 1) + ")";
            if (s_maduocbv != "") sql += " and c.nhombo in (" + s_maduocbv.Trim().Trim(',') + ")";
            if (manguon.SelectedIndex != -1) sql += " and d.manguon=" + int.Parse(manguon.SelectedValue.ToString());
            sql += " and b.soluong>0";
            // 

            sql += " group by ";
            if (i_tt == 1) sql += " b.makho,";
            if (bGiaban)
            {
                if (bGiabandot) sql += "b.giaban,";
                else sql += "c.giaban,";
            }
            if (chkGiachuaVAT.Checked)
            {
                sql += "b.mabd,trunc(d.gianovat," + i_dongiale + "),d.manguon";
            }
            else
            {
                sql += "b.mabd,trunc(d.giamua," + i_dongiale + "),d.manguon";
            }
            if (chkNhacc.Checked) sql += ", d.nhomcc, ncc.ten";
            sql += ",case when d.gianovat=0 then 0 else (round(d.giamua/d.gianovat,2)-1)*100 end ";
            foreach (DataRow r in d.get_data(sql).Tables[0].Rows)
            {
                exp = "mabd=" + int.Parse(r["mabd"].ToString());
                exp += " and dongia=" + decimal.Parse(r["dongia"].ToString());
                if (manguon.SelectedIndex != -1) exp += " and manguon=" + int.Parse(manguon.SelectedValue.ToString());
                if (i_tt == 1) exp += " and idnn=" + int.Parse(r["makho"].ToString());
                r1 = d.getrowbyid(ds.Tables[0], exp);
                if (r1 == null)
                {
                    r3 = d.getrowbyid(dt, "id=" + int.Parse(r["mabd"].ToString()));
                    if (r3 != null)
                    {
                        r2 = ds.Tables[0].NewRow();
                        r2["manhom"] = r3["manhom"].ToString();
                        r2["tennhom"] = r3["tennhom"].ToString();
                        r2["mabd"] = r["mabd"].ToString();
                        r2["ma"] = r3["ma"].ToString();
                        r2["ten"] = r3["ten"].ToString().Trim() + " " + r3["hamluong"].ToString();
                        if (i_tt == 0) r2["tenhc"] = r3["tenhc"].ToString();
                        else r2["tenhc"] = "";
                        r2["manhacc"] = r["manhacc"].ToString();
                        r2["tennhacc"] = r["tennhacc"].ToString();
                        r2["noingoai"] = "";
                        r2["dang"] = r3["dang"].ToString();
                        r2["tondau"] = 0;
                        r2["sttondau"] = 0;
                        r2["slnhap"] = 0;
                        r2["stnhap"] = 0;
                        r2["slnhap_ck"] = 0;
                        r2["stnhap_ck"] = 0;
                        r2["slxuat_ck"] = 0;
                        r2["stxuat_ck"] = 0;
                        r2["sl_tra"] = 0;
                        r2["st_tra"] = 0;
                        r2["slxuat"] = 0;
                        r2["stxuat"] = 0;
                        r2["sl_th"] = 0;
                        r2["st_th"] = 0;
                        r2["slxuat"] = r["soluong"].ToString();
                        r2["stxuat"] = r["sotien"].ToString();
                        r2["dongia"] = r["dongia"].ToString();
                        r2["giaban"] = r["giaban"].ToString();
                        if (r["loai"].ToString() == "53")//xuatban
                        {
                            r2["SLXUAT_BAN"] = r["soluong"].ToString();
                            r2["STXUAT_BAN"] = r["sotien"].ToString();
                        }
                        if (r["loai"].ToString() == "56")//xuat tra nha cung cap
                        {
                            r2["SL_TRANHACC"] = r["soluong"].ToString();
                            r2["ST_TRANHACC"] = r["sotien"].ToString();
                        }
                        r2["sttt"] = 0;
                        r2["manguon"] = r["manguon"].ToString();
                        r2["stt"] = (r3["tt"].ToString().Trim() == "") ? "0" : r3["tt"].ToString();
                        r2["noingoai"] = "";
                        if (i_tt == 0)
                        {
                            r2["idnn"] = r3["idnn"].ToString();
                            r2["noingoai"] = r3["noingoai"].ToString();
                        }
                        else if (i_tt == 1)
                        {
                            r4 = d.getrowbyid(dtdmkho, "id=" + int.Parse(r["makho"].ToString()));
                            if (r4 != null)
                            {
                                r2["idnn"] = r["makho"].ToString();
                                r2["noingoai"] = r4["ten"].ToString();
                            }
                        }
                        r2["vat"] = r["vat"].ToString();
                        ds.Tables[0].Rows.Add(r2);
                    }
                }
                else
                {
                    DataRow[] dr = ds.Tables[0].Select(exp);
                    dr[0]["slxuat"] = decimal.Parse(dr[0]["slxuat"].ToString()) + decimal.Parse(r["soluong"].ToString());
                    dr[0]["stxuat"] = decimal.Parse(dr[0]["stxuat"].ToString()) + decimal.Parse(r["sotien"].ToString());
                    if (r["loai"].ToString() == "53")//xuat ban
                    {
                        dr[0]["SLXUAT_BAN"] = ((dr[0]["SLXUAT_BAN"].ToString() == "") ? 0 : decimal.Parse(dr[0]["SLXUAT_BAN"].ToString())) + decimal.Parse(r["soluong"].ToString());
                        dr[0]["STXUAT_BAN"] = ((dr[0]["STXUAT_BAN"].ToString() == "") ? 0 : decimal.Parse(dr[0]["STXUAT_BAN"].ToString())) + decimal.Parse(r["sotien"].ToString());
                    }
                    if (r["loai"].ToString() == "56")//xuat ban
                    {
                        dr[0]["SL_TRANHACC"] = ((dr[0]["SL_TRANHACC"].ToString() == "") ? 0 : decimal.Parse(dr[0]["SL_TRANHACC"].ToString())) + decimal.Parse(r["soluong"].ToString());
                        dr[0]["ST_TRANHACC"] = ((dr[0]["ST_TRANHACC"].ToString() == "") ? 0 : decimal.Parse(dr[0]["ST_TRANHACC"].ToString())) + decimal.Parse(r["sotien"].ToString());
                    }
                }
            }
            sql = "select ";
            if (i_tt == 1) sql += "a.khox makho,";
            if (bGiaban)
            {
                if (bGiabandot) sql += "b.giaban,";
                else sql += "c.giaban,";
            }
            else sql += "0 as giaban,";
            if (chkGiachuaVAT.Checked)
            {
                sql += "b.mabd,trunc(d.gianovat," + i_dongiale + ") as dongia,d.manguon,sum(b.soluong) as soluong,sum(b.soluong*d.gianovat) as sotien ";
            }
            else
            {
                sql += "b.mabd,trunc(d.giamua," + i_dongiale + ") as dongia,d.manguon,sum(b.soluong) as soluong,sum(b.soluong*d.giamua) as sotien ";
            }
            if (chkNhacc.Checked) sql += ", d.nhomcc as manhacc, ncc.ten as tennhacc ";
            else sql += ", 0 as manhacc, null as tennhacc ";
            sql += ",case when d.gianovat=0 then 0 else (round(d.giamua/d.gianovat,2)-1)*100 end as vat ";

            sql += "from " + xxx + ".d_xuatll a," + xxx + ".d_xuatct b," + user + ".d_dmbd c," + xxx + ".d_theodoi d ";
            if (chkNhacc.Checked) sql += ", " + user + ".d_dmnx ncc";
            sql += " where a.id=b.id and b.mabd=c.id and b.sttt=d.id and a.nhom=" + i_nhom + " and a.loai in ('CK')";
            if (chkNhacc.Checked) sql += " and d.nhomcc=ncc.id ";
            sql += " and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + s_tungay + "','dd/mm/yyyy') and to_date('" + s_denngay + "','dd/mm/yyyy')";
            if (s_kho != "") sql += " and a.khox in (" + s_kho.Substring(0, s_kho.Length - 1) + ")";
            if (s_kho != "") sql += " and a.khon not in (" + s_kho.Substring(0, s_kho.Length - 1) + ")";
            if (s_manhom != "") sql += " and c.manhom in (" + s_manhom.Substring(0, s_manhom.Length - 1) + ")";
            if (s_maduocbv != "") sql += " and c.nhombo in (" + s_maduocbv.Trim().Trim(',') + ")";
            if (manguon.SelectedIndex != -1) sql += " and d.manguon=" + int.Parse(manguon.SelectedValue.ToString());
            sql += " and b.soluong>0";

            sql += " group by ";
            if (i_tt == 1) sql += "a.khox,";
            if (bGiaban)
            {
                if (bGiabandot) sql += "b.giaban,";
                else sql += "c.giaban,";
            }
            if (chkGiachuaVAT.Checked)
            {
                sql += "b.mabd,trunc(d.gianovat," + i_dongiale + "),d.manguon";
            }
            else
            {
                sql += "b.mabd,trunc(d.giamua," + i_dongiale + "),d.manguon";
            }
            if (chkNhacc.Checked) sql += ", d.nhomcc, ncc.ten";
            sql += ",case when d.gianovat=0 then 0 else (round(d.giamua/d.gianovat,2)-1)*100 end";
            foreach (DataRow r in d.get_data(sql).Tables[0].Rows)
            {
                exp = "mabd=" + int.Parse(r["mabd"].ToString());
                exp += " and dongia=" + decimal.Parse(r["dongia"].ToString());
                if (manguon.SelectedIndex != -1) exp += " and manguon=" + int.Parse(manguon.SelectedValue.ToString());
                if (i_tt == 1) exp += " and idnn=" + int.Parse(r["makho"].ToString());
                r1 = d.getrowbyid(ds.Tables[0], exp);
                if (r1 == null)
                {
                    r3 = d.getrowbyid(dt, "id=" + int.Parse(r["mabd"].ToString()));
                    if (r3 != null)
                    {
                        r2 = ds.Tables[0].NewRow();
                        r2["manhom"] = r3["manhom"].ToString();
                        r2["tennhom"] = r3["tennhom"].ToString();
                        r2["mabd"] = r["mabd"].ToString();
                        r2["ma"] = r3["ma"].ToString();
                        r2["ten"] = r3["ten"].ToString().Trim() + " " + r3["hamluong"].ToString();
                        if (i_tt == 0) r2["tenhc"] = r3["tenhc"].ToString();
                        else r2["tenhc"] = "";
                        r2["manhacc"] = r["manhacc"].ToString();
                        r2["tennhacc"] = r["tennhacc"].ToString();
                        r2["noingoai"] = "";
                        r2["dang"] = r3["dang"].ToString();
                        r2["tondau"] = 0;
                        r2["sttondau"] = 0;
                        r2["slnhap"] = 0;
                        r2["stnhap"] = 0;
                        r2["slnhap_ck"] = 0;
                        r2["stnhap_ck"] = 0;
                        r2["slxuat"] = 0;
                        r2["stxuat"] = 0;
                        r2["slxuat_ck"] = 0;
                        r2["stxuat_ck"] = 0;
                        r2["sl_tra"] = 0;
                        r2["st_tra"] = 0;
                        if (bGiaban)
                        {
                            r2["slxuat"] = r["soluong"].ToString();
                            r2["stxuat"] = r["sotien"].ToString();
                        }
                        else
                        {
                            r2["slxuat_ck"] = r["soluong"].ToString();
                            r2["stxuat_ck"] = r["sotien"].ToString();
                        }
                        r2["dongia"] = r["dongia"].ToString();
                        r2["giaban"] = r["giaban"].ToString();
                        r2["sttt"] = 0;
                        r2["manguon"] = r["manguon"].ToString();
                        r2["stt"] = (r3["tt"].ToString().Trim() == "") ? "0" : r3["tt"].ToString();
                        if (i_tt == 0)
                        {
                            r2["idnn"] = r3["idnn"].ToString();
                            r2["noingoai"] = r3["noingoai"].ToString();
                        }
                        else if (i_tt == 1)
                        {
                            r4 = d.getrowbyid(dtdmkho, "id=" + int.Parse(r["makho"].ToString()));
                            if (r4 != null)
                            {
                                r2["idnn"] = r["makho"].ToString();
                                r2["noingoai"] = r4["ten"].ToString();
                            }
                        }
                        r2["vat"] = r["vat"].ToString();
                        ds.Tables[0].Rows.Add(r2);
                    }
                }
                else
                {
                    DataRow[] dr = ds.Tables[0].Select(exp);
                    if (bGiaban)
                    {
                        dr[0]["slxuat"] = decimal.Parse(dr[0]["slxuat"].ToString()) + decimal.Parse(r["soluong"].ToString());
                        dr[0]["stxuat"] = decimal.Parse(dr[0]["stxuat"].ToString()) + decimal.Parse(r["sotien"].ToString());
                    }
                    else
                    {
                        dr[0]["slxuat_ck"] = decimal.Parse(dr[0]["slxuat_ck"].ToString()) + decimal.Parse(r["soluong"].ToString());
                        dr[0]["stxuat_ck"] = decimal.Parse(dr[0]["stxuat_ck"].ToString()) + decimal.Parse(r["sotien"].ToString());
                    }
                }
            }
            ds.AcceptChanges();
        }

        private void get_hoantra(string d_mmyy)
        {
            xxx = user + d_mmyy;
            sql = "select ";
            if (i_tt == 1) sql += "b.makho,";
            if (bGiaban)
            {
                if (bGiabandot) sql += "b.giaban,";
                else sql += "c.giaban,";
            }
            else sql += "0 as giaban,";
            if (chkGiachuaVAT.Checked)
            {
                sql += "b.mabd,trunc(d.gianovat," + i_dongiale + ") as dongia,d.manguon,";
                sql += "sum(b.soluong) as soluong,sum(b.soluong*d.gianovat) as sotien ";
            }
            else
            {
                sql += "b.mabd,trunc(d.giamua," + i_dongiale + ") as dongia,d.manguon,";
                sql += "sum(b.soluong) as soluong,sum(b.soluong*d.giamua) as sotien ";
            }
            if (chkNhacc.Checked) sql += ", d.nhomcc as manhacc, ncc.ten as tennhacc ";
            else sql += ", 0 as manhacc, null as tennhacc ";
            sql += ",case when d.gianovat=0 then 0 else (round(d.giamua/d.gianovat,2)-1)*100 end as vat ";
            //                     
            sql += "from " + xxx + ".d_xuatsdll a," + xxx + ".d_thucxuat b," + user + ".d_dmbd c," + xxx + ".d_theodoi d ";
            if (chkNhacc.Checked) sql += ", " + user + ".d_dmnx ncc";
            sql+=" where a.id=b.id and b.mabd=c.id and b.sttt=d.id and a.loai=3 and a.nhom=" + i_nhom;
            if (chkNhacc.Checked) sql += " and d.nhomcc=ncc.id ";
            if (s_kho != "") sql += " and b.makho in (" + s_kho.Substring(0, s_kho.Length - 1) + ")";
            if (s_manhom != "") sql += " and c.manhom in (" + s_manhom.Substring(0, s_manhom.Length - 1) + ")";
            if (s_maduocbv != "") sql += " and c.nhombo in (" + s_maduocbv.Trim().Trim(',') + ")";
            if (manguon.SelectedIndex != -1) sql += " and d.manguon=" + int.Parse(manguon.SelectedValue.ToString());
            sql += " and b.soluong>0";

            sql += " group by ";
            if (i_tt == 1) sql += "b.makho,";
            if (bGiaban)
            {
                if (bGiabandot) sql += "b.giaban,";
                else sql += "c.giaban,";
            }
            if (chkGiachuaVAT.Checked)
            {
                sql += "b.mabd,trunc(d.gianovat," + i_dongiale + "),d.manguon";
            }
            else
            {
                sql += "b.mabd,trunc(d.giamua," + i_dongiale + "),d.manguon";
            }
            if (chkNhacc.Checked) sql += ", d.nhomcc, ncc.ten";
            sql += ",case when d.gianovat=0 then 0 else (round(d.giamua/d.gianovat,2)-1)*100 end";
            foreach (DataRow r in d.get_data(sql).Tables[0].Rows)
            {
           
                exp = "mabd=" + int.Parse(r["mabd"].ToString());
                exp += " and dongia=" + decimal.Parse(r["dongia"].ToString());
                if (manguon.SelectedIndex != -1) exp += " and manguon=" + int.Parse(manguon.SelectedValue.ToString());
                if (i_tt == 1) exp += " and idnn=" + int.Parse(r["makho"].ToString());
                r1 = d.getrowbyid(ds.Tables[0], exp);
                if (r1 == null)
                {
                    r3 = d.getrowbyid(dt, "id=" + int.Parse(r["mabd"].ToString()));
                    if (r3 != null)
                    {
                        r2 = ds.Tables[0].NewRow();
                        r2["manhom"] = r3["manhom"].ToString();
                        r2["tennhom"] = r3["tennhom"].ToString();
                        r2["mabd"] = r["mabd"].ToString();
                        r2["ma"] = r3["ma"].ToString();
                        r2["ten"] = r3["ten"].ToString().Trim() + " " + r3["hamluong"].ToString();
                        if (i_tt == 0) r2["tenhc"] = r3["tenhc"].ToString();
                        else r2["tenhc"] = "";
                        r2["manhacc"] = r["manhacc"].ToString();
                        r2["tennhacc"] = r["tennhacc"].ToString();
                        r2["noingoai"] = "";
                        r2["dang"] = r3["dang"].ToString();
                        r2["tondau"] = 0;
                        r2["sttondau"] = 0;
                        r2["slnhap"] = 0;
                        r2["stnhap"] = 0;
                        r2["slxuat"] = 0;
                        r2["stxuat"] = 0;
                        r2["sl_th"] = 0;
                        r2["st_th"] = 0;
                        //if (!chkKhoahoantra.Checked) // khoa tra  khau tru vao xuat
                        //{
                        //    r2["slxuat"] = -decimal.Parse(r["soluong"].ToString());
                        //    r2["stxuat"] = -decimal.Parse(r["sotien"].ToString());
                        //}
                        //else {
                            
                        r2["sl_tra"] = decimal.Parse(r["soluong"].ToString());
                        r2["st_tra"] = decimal.Parse(r["sotien"].ToString());
                        //}
                        r2["dongia"] = r["dongia"].ToString();
                        r2["giaban"] = r["giaban"].ToString();
                        r2["sttt"] = 0;
                        r2["manguon"] = r["manguon"].ToString();
                        r2["stt"] = (r3["tt"].ToString().Trim() == "") ? "0" : r3["tt"].ToString();
                        if (i_tt == 0)
                        {
                            r2["idnn"] = r3["idnn"].ToString();
                            r2["noingoai"] = r3["noingoai"].ToString();
                        }
                        else if (i_tt == 1)
                        {
                            r4 = d.getrowbyid(dtdmkho, "id=" + int.Parse(r["makho"].ToString()));
                            if (r4 != null)
                            {
                                r2["idnn"] = r["makho"].ToString();
                                r2["noingoai"] = r4["ten"].ToString();
                            }
                        }
                        r2["slxuat_ck"] = "0";
                        r2["stxuat_ck"] = "0";
                        r2["slnhap_ck"] = "0";
                        r2["stnhap_ck"] = "0";
                        r2["vat"] = r["vat"].ToString();
                        ds.Tables[0].Rows.Add(r2);
                    }
                }
                else
                {
                    DataRow[] dr = ds.Tables[0].Select(exp);
                    if (dr != null)
                    {
                        //if (!chkKhoahoantra.Checked)
                        //{
                        //    dr0[0]["slxuat"] = decimal.Parse(dr[0]["slxuat"].ToString()) - decimal.Parse(r["soluong"].ToString());
                        //    dr[0]["stxuat"] = decimal.Parse(dr[0]["stxuat"].ToString()) - decimal.Parse(r["sotien"].ToString());
                        //}
                        //else {
                        dr[0]["sl_tra"] = decimal.Parse(dr[0]["sl_tra"].ToString()) + decimal.Parse(r["soluong"].ToString());
                        dr[0]["st_tra"] = decimal.Parse(dr[0]["st_tra"].ToString()) + decimal.Parse(r["sotien"].ToString());
                        //}
                    }
                }
            }
            ds.AcceptChanges();            
        }
        private void get_hoantra_ddmmyy(string d_mmyy, string s_tungay, string s_denngay)
        {
            xxx = user + d_mmyy;
            sql = "select ";
            if (i_tt == 1) sql += "b.makho,";
            if (bGiaban)
            {
                if (bGiabandot) sql += "b.giaban,";
                else sql += "c.giaban,";
            }
            else sql += "0 as giaban,";
            if (chkGiachuaVAT.Checked)
            {
                sql += "b.mabd,trunc(d.gianovat," + i_dongiale + ") as dongia,d.manguon,";
                sql += "sum(b.soluong) as soluong,sum(b.soluong*d.gianovat) as sotien ";
            }
            else
            {
                sql += "b.mabd,trunc(d.giamua," + i_dongiale + ") as dongia,d.manguon,";
                sql += "sum(b.soluong) as soluong,sum(b.soluong*d.giamua) as sotien ";
            }
            if (chkNhacc.Checked) sql += ", d.nhomcc as manhacc, ncc.ten as tennhacc ";
            else sql += ", 0 as manhacc, null as tennhacc ";
            sql += ",case when d.gianovat=0 then 0 else (round(d.giamua/d.gianovat,2)-1)*100 end as vat ";
            //                     
            sql += "from " + xxx + ".d_xuatsdll a," + xxx + ".d_thucxuat b," + user + ".d_dmbd c," + xxx + ".d_theodoi d ";
            if (chkNhacc.Checked) sql += ", " + user + ".d_dmnx ncc";
            sql += " where a.id=b.id and b.mabd=c.id and b.sttt=d.id and a.loai=3 and a.nhom=" + i_nhom;
            if (chkNhacc.Checked) sql += " and d.nhomcc=ncc.id ";
            sql += " and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + s_tungay + "','dd/mm/yyyy') and to_date('" + s_denngay + "','dd/mm/yyyy')";
            if (s_kho != "") sql += " and b.makho in (" + s_kho.Substring(0, s_kho.Length - 1) + ")";
            if (s_manhom != "") sql += " and c.manhom in (" + s_manhom.Substring(0, s_manhom.Length - 1) + ")";
            if (s_maduocbv != "") sql += " and c.nhombo in (" + s_maduocbv.Trim().Trim(',') + ")";
            if (manguon.SelectedIndex != -1) sql += " and d.manguon=" + int.Parse(manguon.SelectedValue.ToString());
            sql += " and b.soluong>0";

            sql += " group by ";
            if (i_tt == 1) sql += "b.makho,";
            if (bGiaban)
            {
                if (bGiabandot) sql += "b.giaban,";
                else sql += "c.giaban,";
            }
            if (chkGiachuaVAT.Checked)
            {
                sql += "b.mabd,trunc(d.gianovat," + i_dongiale + "),d.manguon";
            }
            else
            {
                sql += "b.mabd,trunc(d.giamua," + i_dongiale + "),d.manguon";
            }
            if (chkNhacc.Checked) sql += ", d.nhomcc, ncc.ten";
            sql += ",case when d.gianovat=0 then 0 else (round(d.giamua/d.gianovat,2)-1)*100 end ";
            foreach (DataRow r in d.get_data(sql).Tables[0].Rows)
            {

                exp = "mabd=" + int.Parse(r["mabd"].ToString());
                exp += " and dongia=" + decimal.Parse(r["dongia"].ToString());
                if (manguon.SelectedIndex != -1) exp += " and manguon=" + int.Parse(manguon.SelectedValue.ToString());
                if (i_tt == 1) exp += " and idnn=" + int.Parse(r["makho"].ToString());
                r1 = d.getrowbyid(ds.Tables[0], exp);
                if (r1 == null)
                {
                    r3 = d.getrowbyid(dt, "id=" + int.Parse(r["mabd"].ToString()));
                    if (r3 != null)
                    {
                        r2 = ds.Tables[0].NewRow();
                        r2["manhom"] = r3["manhom"].ToString();
                        r2["tennhom"] = r3["tennhom"].ToString();
                        r2["mabd"] = r["mabd"].ToString();
                        r2["ma"] = r3["ma"].ToString();
                        r2["ten"] = r3["ten"].ToString().Trim() + " " + r3["hamluong"].ToString();
                        if (i_tt == 0) r2["tenhc"] = r3["tenhc"].ToString();
                        else r2["tenhc"] = "";
                        r2["manhacc"] = r["manhacc"].ToString();
                        r2["tennhacc"] = r["tennhacc"].ToString();
                        r2["noingoai"] = "";
                        r2["dang"] = r3["dang"].ToString();
                        r2["tondau"] = 0;
                        r2["sttondau"] = 0;
                        r2["slnhap"] = 0;
                        r2["stnhap"] = 0;
                        r2["slxuat"] = 0;
                        r2["stxuat"] = 0;
                        r2["sl_th"] = 0;
                        r2["st_th"] = 0;
                       
                        r2["sl_tra"] = decimal.Parse(r["soluong"].ToString());
                        r2["st_tra"] = decimal.Parse(r["sotien"].ToString());
                        //}
                        r2["dongia"] = r["dongia"].ToString();
                        r2["giaban"] = r["giaban"].ToString();
                        r2["sttt"] = 0;
                        r2["manguon"] = r["manguon"].ToString();
                        r2["stt"] = (r3["tt"].ToString().Trim() == "") ? "0" : r3["tt"].ToString();
                        if (i_tt == 0)
                        {
                            r2["idnn"] = r3["idnn"].ToString();
                            r2["noingoai"] = r3["noingoai"].ToString();
                        }
                        else if (i_tt == 1)
                        {
                            r4 = d.getrowbyid(dtdmkho, "id=" + int.Parse(r["makho"].ToString()));
                            if (r4 != null)
                            {
                                r2["idnn"] = r["makho"].ToString();
                                r2["noingoai"] = r4["ten"].ToString();
                            }
                        }
                        r2["slxuat_ck"] = "0";
                        r2["stxuat_ck"] = "0";
                        r2["slnhap_ck"] = "0";
                        r2["stnhap_ck"] = "0";
                        r2["vat"] = r["vat"].ToString();
                        ds.Tables[0].Rows.Add(r2);
                    }
                }
                else
                {
                    DataRow[] dr = ds.Tables[0].Select(exp);
                    if (dr != null)
                    {
                        //if (!chkKhoahoantra.Checked)
                        //{
                        //    dr0[0]["slxuat"] = decimal.Parse(dr[0]["slxuat"].ToString()) - decimal.Parse(r["soluong"].ToString());
                        //    dr[0]["stxuat"] = decimal.Parse(dr[0]["stxuat"].ToString()) - decimal.Parse(r["sotien"].ToString());
                        //}
                        //else {
                        dr[0]["sl_tra"] = decimal.Parse(dr[0]["sl_tra"].ToString()) + decimal.Parse(r["soluong"].ToString());
                        dr[0]["st_tra"] = decimal.Parse(dr[0]["st_tra"].ToString()) + decimal.Parse(r["sotien"].ToString());
                        //}
                    }
                }
            }
            ds.AcceptChanges();
        }
        // 090310
        private void get_hoantra_denngay(string d_mmyy, string s_tungay)
        {
            xxx = user + d_mmyy;
            sql = "select ";
            if (i_tt == 1) sql += "b.makho,";
            if (bGiaban)
            {
                if (bGiabandot) sql += "b.giaban,";
                else sql += "c.giaban,";
            }
            else sql += "0 as giaban,";
            if (chkGiachuaVAT.Checked)
            {
                sql += "b.mabd,trunc(d.gianovat," + i_dongiale + ") as dongia,d.manguon,";
                sql += "sum(b.soluong) as soluong,sum(b.soluong*d.gianovat) as sotien ";
            }
            else
            {
                sql += "b.mabd,trunc(d.giamua," + i_dongiale + ") as dongia,d.manguon,";
                sql += "sum(b.soluong) as soluong,sum(b.soluong*d.giamua) as sotien ";
            }
            if (chkNhacc.Checked) sql += ", d.nhomcc as manhacc, ncc.ten as tennhacc ";
            else sql += ", 0 as manhacc, null as tennhacc ";
            sql += ",case when d.gianovat=0 then 0 else (round(d.giamua/d.gianovat,2)-1)*100 end as vat ";
            //                     
            sql += "from " + xxx + ".d_xuatsdll a," + xxx + ".d_thucxuat b," + user + ".d_dmbd c," + xxx + ".d_theodoi d ";
            if (chkNhacc.Checked) sql += ", " + user + ".d_dmnx ncc";
            sql += " where a.id=b.id and b.mabd=c.id and b.sttt=d.id and a.loai=3 and a.nhom=" + i_nhom;
            if (chkNhacc.Checked) sql += " and d.nhomcc=ncc.id ";
            sql += " and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') < to_date('" + s_tungay + "','dd/mm/yyyy')";
            if (s_kho != "") sql += " and b.makho in (" + s_kho.Substring(0, s_kho.Length - 1) + ")";
            if (s_manhom != "") sql += " and c.manhom in (" + s_manhom.Substring(0, s_manhom.Length - 1) + ")";
            if (s_maduocbv != "") sql += " and c.nhombo in (" + s_maduocbv.Trim().Trim(',') + ")";
            if (manguon.SelectedIndex != -1) sql += " and d.manguon=" + int.Parse(manguon.SelectedValue.ToString());
            sql += " and b.soluong>0";

            sql += " group by ";
            if (i_tt == 1) sql += "b.makho,";
            if (bGiaban)
            {
                if (bGiabandot) sql += "b.giaban,";
                else sql += "c.giaban,";
            }
            if (chkGiachuaVAT.Checked)
            {
                sql += "b.mabd,trunc(d.gianovat," + i_dongiale + "),d.manguon";
            }
            else
            {
                sql += "b.mabd,trunc(d.giamua," + i_dongiale + "),d.manguon";
            }
            if (chkNhacc.Checked) sql += ", d.nhomcc, ncc.ten";
            sql += ",case when d.gianovat=0 then 0 else (round(d.giamua/d.gianovat,2)-1)*100 end ";
            foreach (DataRow r in d.get_data(sql).Tables[0].Rows)
            {

                exp = "mabd=" + int.Parse(r["mabd"].ToString());
                exp += " and dongia=" + decimal.Parse(r["dongia"].ToString());
                if (manguon.SelectedIndex != -1) exp += " and manguon=" + int.Parse(manguon.SelectedValue.ToString());
                if (i_tt == 1) exp += " and idnn=" + int.Parse(r["makho"].ToString());
                r1 = d.getrowbyid(ds.Tables[0], exp);
                if (r1 == null)
                {
                    r3 = d.getrowbyid(dt, "id=" + int.Parse(r["mabd"].ToString()));
                    if (r3 != null)
                    {
                        r2 = ds.Tables[0].NewRow();
                        r2["manhom"] = r3["manhom"].ToString();
                        r2["tennhom"] = r3["tennhom"].ToString();
                        r2["mabd"] = r["mabd"].ToString();
                        r2["ma"] = r3["ma"].ToString();
                        r2["ten"] = r3["ten"].ToString().Trim() + " " + r3["hamluong"].ToString();
                        if (i_tt == 0) r2["tenhc"] = r3["tenhc"].ToString();
                        else r2["tenhc"] = "";
                        r2["manhacc"] = r["manhacc"].ToString();
                        r2["tennhacc"] = r["tennhacc"].ToString();
                        r2["noingoai"] = "";
                        r2["dang"] = r3["dang"].ToString();
                        r2["tondau"] = decimal.Parse(r["soluong"].ToString());
                        r2["sttondau"] = decimal.Parse(r["sotien"].ToString());
                        r2["slnhap"] = 0;
                        r2["stnhap"] = 0;
                        r2["slxuat"] = 0;
                        r2["stxuat"] = 0;
                        r2["sl_th"] = 0;
                        r2["st_th"] = 0;                       

                        r2["sl_tra"] =0;
                        r2["st_tra"] = 0;
                        //}
                        r2["dongia"] = r["dongia"].ToString();
                        r2["giaban"] = r["giaban"].ToString();
                        r2["sttt"] = 0;
                        r2["manguon"] = r["manguon"].ToString();
                        r2["stt"] = (r3["tt"].ToString().Trim() == "") ? "0" : r3["tt"].ToString();
                        if (i_tt == 0)
                        {
                            r2["idnn"] = r3["idnn"].ToString();
                            r2["noingoai"] = r3["noingoai"].ToString();
                        }
                        else if (i_tt == 1)
                        {
                            r4 = d.getrowbyid(dtdmkho, "id=" + int.Parse(r["makho"].ToString()));
                            if (r4 != null)
                            {
                                r2["idnn"] = r["makho"].ToString();
                                r2["noingoai"] = r4["ten"].ToString();
                            }
                        }
                        r2["slxuat_ck"] = "0";
                        r2["stxuat_ck"] = "0";
                        r2["slnhap_ck"] = "0";
                        r2["stnhap_ck"] = "0";
                        r2["vat"] = r["vat"].ToString();
                        ds.Tables[0].Rows.Add(r2);
                    }
                }
                else
                {
                    DataRow[] dr = ds.Tables[0].Select(exp);
                    if (dr != null)
                    {                        
                        dr[0]["tondau"] = decimal.Parse(dr[0]["tondau"].ToString()) + decimal.Parse(r["soluong"].ToString());
                        dr[0]["sttondau"] = decimal.Parse(dr[0]["sttondau"].ToString()) + decimal.Parse(r["sotien"].ToString());
                        //}
                    }
                }
            }
            ds.AcceptChanges();
        }
        private void butKetthuc_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void tu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }


        private void rptNxt_CK_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (bClear)
            {
                manguon.SelectedIndex = -1;
                bClear = false;
            }
        }

        private void get_data()
        {
            ds.Clear();
            dsxml.Clear();
            sql = "select * from " + user + ".d_dmkho where hide=0 and khott=1 and nhom=" + i_nhom;
            if (s_kho != "") sql += " and id in (" + s_kho.Substring(0, s_kho.Length - 1) + ")";
            sql += " order by id";
            foreach (DataRow r in d.get_data(sql).Tables[0].Rows) s_khott += r["id"].ToString().Trim() + ",";
            s_mmyy = tu.Value.ToString().PadLeft(2, '0') + yyyy.Value.ToString().PadLeft(4, '0').Substring(2, 2);
            s_tu = tu.Value.ToString().PadLeft(2, '0');
            s_den = den.Value.ToString().PadLeft(2, '0');
            s_yy = yyyy.Value.ToString().PadLeft(4, '0').Substring(2, 2);
            int y1 = int.Parse(yyyy.Value.ToString()), m1 = int.Parse(tu.Value.ToString());
            int y2 = int.Parse(yyyy.Value.ToString()), m2 = int.Parse(den.Value.ToString());
            int itu, iden;

            this.Cursor = Cursors.WaitCursor;
            string mmyy = m1.ToString().PadLeft(2, '0') + y1.ToString().Substring(2, 2);
            if (d.bMmyy(mmyy)) get_tondau(mmyy);
            for (int i = y1; i <= y2; i++)
            {
                itu = (i == y1) ? m1 : 1;
                iden = (i == y2) ? m2 : 12;
                for (int j = itu; j <= iden; j++)
                {
                    mmyy = j.ToString().PadLeft(2, '0') + i.ToString().Substring(2, 2);
                    if (d.bMmyy(mmyy))
                    {
                        get_nhap(mmyy);
                        get_xuat(mmyy);
                        get_hoantra(mmyy);
                        if (manguon.SelectedIndex != -1) get_chuyennguon(mmyy);
                    }
                }
            }
           
            if (ds.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"), lan.Change_language_MessageText("Báo cáo tổng hợp"));
                this.Cursor = Cursors.Default;
                return;
            }
           
            this.Cursor = Cursors.Default;
        }
        // lấy danh sách từ ngày đến ngày 
        private void get_data_ddmmyy()
        {
            ds.Clear();
            dsxml.Clear();
            sql = "select * from " + user + ".d_dmkho where hide=0 and khott=1 and nhom=" + i_nhom;
            if (s_kho != "") sql += " and id in (" + s_kho.Substring(0, s_kho.Length - 1) + ")";
            sql += " order by id";
            foreach (DataRow r in d.get_data(sql).Tables[0].Rows) s_khott += r["id"].ToString().Trim() + ",";
            s_mmyy = tu.Value.ToString().PadLeft(2, '0') + yyyy.Value.ToString().PadLeft(4, '0').Substring(2, 2);
            s_tu = tungay.Text.Substring(0, 10);
            s_den = denngay.Text.Substring(0, 10);
            s_yy = yyyy.Value.ToString().PadLeft(4, '0').Substring(2, 2);
            int y1 = int.Parse(yytu.Value.ToString()), m1 = int.Parse(mmtu.Value.ToString());
            int y2 = int.Parse(yyden.Value.ToString()), m2 = int.Parse(mmden.Value.ToString());
            int itu, iden;

            this.Cursor = Cursors.WaitCursor;
            string mmyy = m1.ToString().PadLeft(2, '0') + y1.ToString().Substring(2, 2);
            if (d.bMmyy(mmyy))
            {
                get_tondau(mmyy);
                get_nhap_denngay(mmyy, s_tu);
                get_xuat_denngay(mmyy, s_tu);
                get_hoantra_denngay(mmyy, s_tu);
                if (manguon.SelectedIndex != -1) get_chuyennguon_denngay(mmyy, s_tu);
            }
            for (int i = y1; i <= y2; i++)
            {
                itu = (i == y1) ? m1 : 1;
                iden = (i == y2) ? m2 : 12;
                for (int j = itu; j <= iden; j++)
                {
                    mmyy = j.ToString().PadLeft(2, '0') + i.ToString().Substring(2, 2);
                    if (d.bMmyy(mmyy))
                    {
                        get_nhap_ddmmyy(mmyy,s_tu,s_den);
                        get_xuat_ddmmyy(mmyy,s_tu,s_den);
                        get_hoantra_ddmmyy(mmyy,s_tu,s_den);
                        if (manguon.SelectedIndex != -1) get_chuyennguon_ddmmyy(mmyy, s_tu, s_den);
                    }
                }
            }            

            if (ds.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"), lan.Change_language_MessageText("Báo cáo tổng hợp"));
                this.Cursor = Cursors.Default;
                return;
            }

            this.Cursor = Cursors.Default;
        }
        //        
        private void f_Get_Hoantra_Thuhoi_CSTT(DataSet ads)
        {
            foreach (DataRow r in ads.Tables[0].Rows)
            {

                exp = "mabd=" + int.Parse(r["mabd"].ToString());
                exp += " and dongia=" + decimal.Parse(r["dongia"].ToString());
                if (manguon.SelectedIndex != -1) exp += " and manguon=" + int.Parse(manguon.SelectedValue.ToString());
                if (i_tt == 1) exp += " and idnn=" + int.Parse(r["makho"].ToString());
                r1 = d.getrowbyid(ds.Tables[0], exp);
                if (r1 == null)
                {
                    r3 = d.getrowbyid(dt, "id=" + int.Parse(r["mabd"].ToString()));
                    if (r3 != null)
                    {
                        r2 = ds.Tables[0].NewRow();
                        r2["manhom"] = r3["manhom"].ToString();
                        r2["tennhom"] = r3["tennhom"].ToString();
                        r2["mabd"] = r["mabd"].ToString();
                        r2["ma"] = r3["ma"].ToString();
                        r2["ten"] = r3["ten"].ToString().Trim() + " " + r3["hamluong"].ToString();
                        if (i_tt == 0) r2["tenhc"] = r3["tenhc"].ToString();
                        else r2["tenhc"] = "";
                        r2["manhacc"] = r["manhacc"].ToString();
                        r2["tennhacc"] = r["tennhacc"].ToString();
                        r2["noingoai"] = "";
                        r2["dang"] = r3["dang"].ToString();
                        r2["tondau"] = 0;
                        r2["sttondau"] = 0;
                        r2["slnhap"] = 0;
                        r2["stnhap"] = 0;
                        r2["slxuat"] = 0;
                        r2["stxuat"] = 0;
                        r2["sl_tra"] = 0;
                        r2["st_tra"] = 0;
                       
                        //if (chkKhoahoantra.Checked)
                        //{
                            r2["sl_th"] = decimal.Parse(r["soluong"].ToString());
                            r2["st_th"] = decimal.Parse(r["sotien"].ToString());
                        //}
                        //else
                        //{
                        //    r2["slxuat"] = - decimal.Parse(r["soluong"].ToString());
                        //    r2["stxuat"] = - decimal.Parse(r["sotien"].ToString());
                        //}
                        r2["dongia"] = r["dongia"].ToString();
                        r2["giaban"] = r["giaban"].ToString();
                        r2["sttt"] = 0;
                        r2["manguon"] = r["manguon"].ToString();
                        r2["stt"] = (r3["tt"].ToString().Trim() == "") ? "0" : r3["tt"].ToString();
                        if (i_tt == 0)
                        {
                            r2["idnn"] = r3["idnn"].ToString();
                            r2["noingoai"] = r3["noingoai"].ToString();
                        }
                        else if (i_tt == 1)
                        {
                            r4 = d.getrowbyid(dtdmkho, "id=" + int.Parse(r["makho"].ToString()));
                            if (r4 != null)
                            {
                                r2["idnn"] = r["makho"].ToString();
                                r2["noingoai"] = r4["ten"].ToString();
                            }
                        }
                        r2["slxuat_ck"] = "0";
                        r2["stxuat_ck"] = "0";
                        r2["slnhap_ck"] = "0";
                        r2["stnhap_ck"] = "0";
                        r2["vat"] = r["vat"].ToString();
                        ds.Tables[0].Rows.Add(r2);
                    }
                }
                else
                {
                    DataRow[] dr = ds.Tables[0].Select(exp);
                    if (dr != null)
                    {

                        dr[0]["sl_th"] = decimal.Parse(dr[0]["sl_th"].ToString()) + decimal.Parse(r["soluong"].ToString());
                        dr[0]["st_th"] = decimal.Parse(dr[0]["st_th"].ToString()) + decimal.Parse(r["sotien"].ToString());

                    }
                }
            }
            ds.AcceptChanges();  
        }
        private void f_Get_Hoantra_Thuhoi_CSTT(DataSet ads, string field_sl, string field_st)
        {
            foreach (DataRow r in ads.Tables[0].Rows)
            {

                exp = "mabd=" + int.Parse(r["mabd"].ToString());
                exp += " and dongia=" + decimal.Parse(r["dongia"].ToString());
                if (manguon.SelectedIndex != -1) exp += " and manguon=" + int.Parse(manguon.SelectedValue.ToString());
                if (i_tt == 1) exp += " and idnn=" + int.Parse(r["makho"].ToString());
                r1 = d.getrowbyid(ds.Tables[0], exp);
                if (r1 == null)
                {
                    r3 = d.getrowbyid(dt, "id=" + int.Parse(r["mabd"].ToString()));
                    if (r3 != null)
                    {
                        r2 = ds.Tables[0].NewRow();
                        r2["manhom"] = r3["manhom"].ToString();
                        r2["tennhom"] = r3["tennhom"].ToString();
                        r2["mabd"] = r["mabd"].ToString();
                        r2["ma"] = r3["ma"].ToString();
                        r2["ten"] = r3["ten"].ToString().Trim() + " " + r3["hamluong"].ToString();
                        if (i_tt == 0) r2["tenhc"] = r3["tenhc"].ToString();
                        else r2["tenhc"] = "";
                        r2["manhacc"] = r["manhacc"].ToString();
                        r2["tennhacc"] = r["tennhacc"].ToString();
                        r2["noingoai"] = "";
                        r2["dang"] = r3["dang"].ToString();
                        r2["tondau"] = 0;
                        r2["sttondau"] = 0;
                        r2["slnhap"] = 0;
                        r2["stnhap"] = 0;
                        r2["slxuat"] = 0;
                        r2["stxuat"] = 0;
                        r2["sl_tra"] = 0;
                        r2["st_tra"] = 0;

                        r2[field_sl] = decimal.Parse(r["soluong"].ToString());
                        r2[field_st] = decimal.Parse(r["sotien"].ToString());
                        
                        r2["dongia"] = r["dongia"].ToString();
                        r2["giaban"] = r["giaban"].ToString();
                        r2["sttt"] = 0;
                        r2["manguon"] = r["manguon"].ToString();
                        r2["stt"] = (r3["tt"].ToString().Trim() == "") ? "0" : r3["tt"].ToString();
                        if (i_tt == 0)
                        {
                            r2["idnn"] = r3["idnn"].ToString();
                            r2["noingoai"] = r3["noingoai"].ToString();
                        }
                        else if (i_tt == 1)
                        {
                            r4 = d.getrowbyid(dtdmkho, "id=" + int.Parse(r["makho"].ToString()));
                            if (r4 != null)
                            {
                                r2["idnn"] = r["makho"].ToString();
                                r2["noingoai"] = r4["ten"].ToString();
                            }
                        }
                        r2["slxuat_ck"] = "0";
                        r2["stxuat_ck"] = "0";
                        r2["slnhap_ck"] = "0";
                        r2["stnhap_ck"] = "0";
                        r2["vat"] = r["vat"].ToString();
                        ds.Tables[0].Rows.Add(r2);
                    }
                }
                else
                {
                    DataRow[] dr = ds.Tables[0].Select(exp);
                    if (dr != null)
                    {

                        dr[0][field_sl] = decimal.Parse(dr[0][field_sl].ToString()) + decimal.Parse(r["soluong"].ToString());
                        dr[0][field_st] = decimal.Parse(dr[0][field_st].ToString()) + decimal.Parse(r["sotien"].ToString());
                        
                    }
                }
            }
            ds.AcceptChanges();
        }

        private void chkKhoahoantra_Click(object sender, EventArgs e)
        {
            if(bln_chonmaubaocao)cbmaubaocao.Enabled = !chkKhoahoantra.Checked;
        }
        private void butmaubc_Click(object sender, EventArgs e)
        {
            string s_tmp_maubaocao = "";

            if (cbmaubaocao.SelectedIndex >= 0) s_tmp_maubaocao = cbmaubaocao.SelectedValue.ToString();
            frmdmmaubc f = new frmdmmaubc(d, this.Name);
            f.ShowDialog();
            if (s_tmp_maubaocao.Trim() != "") cbmaubaocao.SelectedValue = s_tmp_maubaocao;
            load_dmmaubaocao(this.Name);

        }       
        private void load_dmmaubaocao(string maloai)
        {            
            sql = " select filereport as ma, ten from " + d.user + ".bhyt_maubaocao where maloai='" + maloai + "'";
            ds_dsbc = d.get_data(sql);
            cbmaubaocao.DataSource = ds_dsbc.Tables[0];

        }
        private void chkXML_MouseMove(object sender, MouseEventArgs e)
        {            
            //toolTip1.SetToolTip(chkXML, d.s_getDirec_XML("d_nxt_ck"));
        }

        private void rdthang_CheckedChanged(object sender, EventArgs e)
        {
            Enable_ngay((rdthang.Checked == true) ? true : false);
        }
        private void Enable_ngay(bool ena)
        {
            tungay.Enabled = !ena;
            denngay.Enabled = !ena;
            mmtu.Enabled = !ena;
            mmden.Enabled = !ena;
            yytu.Enabled = !ena;
            yyden.Enabled = !ena;
            //
            tu.Enabled = ena;
            den.Enabled = ena;
            yyyy.Enabled = ena;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Enable_ngay((rdthang.Checked == true) ? true : false);
        }

        private void tungay_Validated(object sender, EventArgs e)
        {
            mmtu.Value = tungay.Value.Month;
            yytu.Value = tungay.Value.Year;
        }

        private void denngay_Validated(object sender, EventArgs e)
        {
            mmden.Value = denngay.Value.Month;
            yyden.Value = denngay.Value.Year;
        }

        private void chkGiachuaVAT_Click(object sender, EventArgs e)
        {
            d.writeXml("thongso", "chkGiachuaVAT_rptnxt_ck", (chkGiachuaVAT.Checked) ? "1" : "0");
        }

        private void chkchuyenkho_Click(object sender, EventArgs e)
        {
            d.writeXml("thongso", "chkchuyenkho_rptnxt_ck", (chkchuyenkho.Checked) ? "1" : "0");
        }       
    }
}
