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
	/// Summary description for frmRavien.
	/// </summary>
	public class frmCSDL : System.Windows.Forms.Form
	{
		Language lan = new Language();
        Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.Button butExit;
		private DataSet ds=new DataSet();
		private LibMedi.AccessData m;
        private string user;
		private Brush disabledBackBrush;
		private Brush disabledTextBrush;
		private Brush alertBackBrush;
		private Font alertFont;
		private Brush alertTextBrush;
		private Font currentRowFont;
		private Brush currentRowBackBrush;
		bool afterCurrentCellChanged;
        bool bKiemTraCauTrucNhieuCN = false;
		int checkCol=0, checkCol1=2;
        int i_userid = 0;
        bool bAdminHethong = false;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Button butKiemTra;
        private Label label3;
        private NumericUpDown numNamDich;
        private Label label4;
        private NumericUpDown numThangDich;
        private Label label2;
        private NumericUpDown numNamNguon;
        private Label label1;
        private NumericUpDown numThangNguon;
        private Button butCopyccautruc;
        private TextBox txtView;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
        private DataSet dsCauTrucNguon;
        string ammyyNguon = "";
        private DataTable dtCNNguon;
        private DataTable dtCNDich;
        private int i_IDChiNhanh = 0;

        private Label lblStatus;
        private TabPage tabPage3;
        private Button butCopyccautrucCN;
        private Button butKiemTraCN;
        private Label label5;
        private NumericUpDown numNamCN;
        private Label label6;
        private NumericUpDown numThangCN;
        private GroupBox groupBox1;
        private Label label8;
        private ComboBox cmbChiNhanhNguon;
        private TextBox txtDatabaseNguon;
        private Label label7;
        private TextBox txtPortNguon;
        private Label label9;
        private TextBox txtIPNguon;
        private Label label10;
        private Label lblStatusCN;
        private TextBox txtViewCN;
        private GroupBox groupBox2;
        private Label label11;
        private ComboBox cmbChiNhanhDich;
        private TextBox txtDatabaseDich;
        private Label label12;
        private TextBox txtPortDich;
        private Label label13;
        private TextBox txtIPDich;
        private Label label14;
        private CheckBox chkGoc;
        private TabPage tabPage4;
        private DataGridView dataGridView1;
        private Label label16;
        private TextBox txtTblName;
        private TextBox txtTim;
        private Label label15;
        private ComboBox cbSchema;
        private Button butLuuAltertable;
        private ComboBox cbCommand;
        private Label label20;
        private TextBox txtDatatype;
        private Label label19;
        private TextBox txtDefaultValue;
        private Label label18;
        private Label label17;
        private TextBox txtColumnName;
        private Button butSuaAlter;
        private Button butBoquaAlter;
        string ammyyDich = "";

        private DataSet dsColumnAlter=new DataSet();
        private DataGridViewTextBoxColumn c_ID;
        private DataGridViewTextBoxColumn c_schema;
        private DataGridViewTextBoxColumn c_tablename;
        private DataGridViewTextBoxColumn c_Column_name;
        private DataGridViewTextBoxColumn c_comand;
        private DataGridViewTextBoxColumn c_datatype;
        private DataGridViewTextBoxColumn c_default_value;
        private DataTable dtmmyy;
        private ComboBox cbMMYY;
        private Button butTaolai;
        private CheckBox chkmedibvgoc;
        private decimal d_idcolumn = 0;
        private bool bAllowAlter = false;

		public frmCSDL(LibMedi.AccessData acc, int userid)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
            m = acc; if (m.bBogo) tv.GanBogo(this, textBox111);
            i_userid=userid;
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
					if(disabledBackBrush != null)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCSDL));
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.butLuu = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butExit = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtView = new System.Windows.Forms.TextBox();
            this.butCopyccautruc = new System.Windows.Forms.Button();
            this.butKiemTra = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.numNamDich = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.numThangDich = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numNamNguon = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.numThangNguon = new System.Windows.Forms.NumericUpDown();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.chkGoc = new System.Windows.Forms.CheckBox();
            this.lblStatusCN = new System.Windows.Forms.Label();
            this.txtViewCN = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbChiNhanhDich = new System.Windows.Forms.ComboBox();
            this.txtDatabaseDich = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtPortDich = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtIPDich = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.numNamCN = new System.Windows.Forms.NumericUpDown();
            this.numThangCN = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbChiNhanhNguon = new System.Windows.Forms.ComboBox();
            this.txtDatabaseNguon = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPortNguon = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtIPNguon = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.butCopyccautrucCN = new System.Windows.Forms.Button();
            this.butKiemTraCN = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.chkmedibvgoc = new System.Windows.Forms.CheckBox();
            this.cbMMYY = new System.Windows.Forms.ComboBox();
            this.butBoquaAlter = new System.Windows.Forms.Button();
            this.butSuaAlter = new System.Windows.Forms.Button();
            this.cbCommand = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtDatatype = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtDefaultValue = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txtColumnName = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtTblName = new System.Windows.Forms.TextBox();
            this.txtTim = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cbSchema = new System.Windows.Forms.ComboBox();
            this.butTaolai = new System.Windows.Forms.Button();
            this.butLuuAltertable = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.c_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_schema = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_tablename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_Column_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_comand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_datatype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_default_value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNamDich)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numThangDich)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNamNguon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numThangNguon)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNamCN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numThangCN)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
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
            this.dataGrid1.Location = new System.Drawing.Point(7, -12);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.Size = new System.Drawing.Size(348, 404);
            this.dataGrid1.TabIndex = 10;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            this.dataGrid1.Click += new System.EventHandler(this.dataGrid1_Click);
            // 
            // butLuu
            // 
            this.butLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(120, 395);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 6;
            this.butLuu.Text = "    &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(190, 395);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(70, 25);
            this.butBoqua.TabIndex = 7;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butExit
            // 
            this.butExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butExit.Location = new System.Drawing.Point(151, 484);
            this.butExit.Name = "butExit";
            this.butExit.Size = new System.Drawing.Size(70, 25);
            this.butExit.TabIndex = 11;
            this.butExit.Text = "&Kết thúc";
            this.butExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butExit.Click += new System.EventHandler(this.butExit_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(1, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(374, 452);
            this.tabControl1.TabIndex = 12;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGrid1);
            this.tabPage1.Controls.Add(this.butBoqua);
            this.tabPage1.Controls.Add(this.butLuu);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(366, 426);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Số liệu đã tạo";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lblStatus);
            this.tabPage2.Controls.Add(this.txtView);
            this.tabPage2.Controls.Add(this.butCopyccautruc);
            this.tabPage2.Controls.Add(this.butKiemTra);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.numNamDich);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.numThangDich);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.numNamNguon);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.numThangNguon);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(366, 426);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Kiểm tra cấu trúc";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lblStatus
            // 
            this.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStatus.Location = new System.Drawing.Point(7, 395);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(348, 23);
            this.lblStatus.TabIndex = 11;
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtView
            // 
            this.txtView.Location = new System.Drawing.Point(7, 84);
            this.txtView.Multiline = true;
            this.txtView.Name = "txtView";
            this.txtView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtView.Size = new System.Drawing.Size(348, 304);
            this.txtView.TabIndex = 10;
            // 
            // butCopyccautruc
            // 
            this.butCopyccautruc.Location = new System.Drawing.Point(163, 30);
            this.butCopyccautruc.Name = "butCopyccautruc";
            this.butCopyccautruc.Size = new System.Drawing.Size(94, 23);
            this.butCopyccautruc.TabIndex = 9;
            this.butCopyccautruc.Text = "Copy cấu trúc";
            this.butCopyccautruc.UseVisualStyleBackColor = true;
            this.butCopyccautruc.Click += new System.EventHandler(this.butCopyccautruc_Click);
            // 
            // butKiemTra
            // 
            this.butKiemTra.Location = new System.Drawing.Point(69, 30);
            this.butKiemTra.Name = "butKiemTra";
            this.butKiemTra.Size = new System.Drawing.Size(94, 23);
            this.butKiemTra.TabIndex = 8;
            this.butKiemTra.Text = "Kiểm tra";
            this.butKiemTra.UseVisualStyleBackColor = true;
            this.butKiemTra.Click += new System.EventHandler(this.butKiemTra_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(225, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Năm :";
            // 
            // numNamDich
            // 
            this.numNamDich.Location = new System.Drawing.Point(266, 60);
            this.numNamDich.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numNamDich.Minimum = new decimal(new int[] {
            2001,
            0,
            0,
            0});
            this.numNamDich.Name = "numNamDich";
            this.numNamDich.Size = new System.Drawing.Size(50, 20);
            this.numNamDich.TabIndex = 6;
            this.numNamDich.Value = new decimal(new int[] {
            2001,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Tháng :";
            // 
            // numThangDich
            // 
            this.numThangDich.Location = new System.Drawing.Point(70, 58);
            this.numThangDich.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numThangDich.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numThangDich.Name = "numThangDich";
            this.numThangDich.Size = new System.Drawing.Size(50, 20);
            this.numThangDich.TabIndex = 4;
            this.numThangDich.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(225, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Năm :";
            // 
            // numNamNguon
            // 
            this.numNamNguon.Location = new System.Drawing.Point(266, 6);
            this.numNamNguon.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numNamNguon.Minimum = new decimal(new int[] {
            2001,
            0,
            0,
            0});
            this.numNamNguon.Name = "numNamNguon";
            this.numNamNguon.Size = new System.Drawing.Size(50, 20);
            this.numNamNguon.TabIndex = 2;
            this.numNamNguon.Value = new decimal(new int[] {
            2001,
            0,
            0,
            0});
            this.numNamNguon.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tháng :";
            // 
            // numThangNguon
            // 
            this.numThangNguon.Location = new System.Drawing.Point(70, 6);
            this.numThangNguon.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numThangNguon.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numThangNguon.Name = "numThangNguon";
            this.numThangNguon.Size = new System.Drawing.Size(50, 20);
            this.numThangNguon.TabIndex = 0;
            this.numThangNguon.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.chkGoc);
            this.tabPage3.Controls.Add(this.lblStatusCN);
            this.tabPage3.Controls.Add(this.txtViewCN);
            this.tabPage3.Controls.Add(this.groupBox2);
            this.tabPage3.Controls.Add(this.numNamCN);
            this.tabPage3.Controls.Add(this.numThangCN);
            this.tabPage3.Controls.Add(this.groupBox1);
            this.tabPage3.Controls.Add(this.butCopyccautrucCN);
            this.tabPage3.Controls.Add(this.butKiemTraCN);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(366, 426);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Cấu trúc các CN";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // chkGoc
            // 
            this.chkGoc.AutoSize = true;
            this.chkGoc.Location = new System.Drawing.Point(255, 10);
            this.chkGoc.Name = "chkGoc";
            this.chkGoc.Size = new System.Drawing.Size(82, 17);
            this.chkGoc.TabIndex = 21;
            this.chkGoc.Text = "Medibv gốc";
            this.chkGoc.UseVisualStyleBackColor = true;
            // 
            // lblStatusCN
            // 
            this.lblStatusCN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStatusCN.Location = new System.Drawing.Point(3, 402);
            this.lblStatusCN.Name = "lblStatusCN";
            this.lblStatusCN.Size = new System.Drawing.Size(354, 23);
            this.lblStatusCN.TabIndex = 20;
            this.lblStatusCN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtViewCN
            // 
            this.txtViewCN.Location = new System.Drawing.Point(5, 271);
            this.txtViewCN.Multiline = true;
            this.txtViewCN.Name = "txtViewCN";
            this.txtViewCN.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtViewCN.Size = new System.Drawing.Size(352, 130);
            this.txtViewCN.TabIndex = 19;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.cmbChiNhanhDich);
            this.groupBox2.Controls.Add(this.txtDatabaseDich);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txtPortDich);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.txtIPDich);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Location = new System.Drawing.Point(-5, 158);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(370, 111);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Server Đích";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(29, 27);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 13);
            this.label11.TabIndex = 14;
            this.label11.Text = "Chi nhánh :";
            // 
            // cmbChiNhanhDich
            // 
            this.cmbChiNhanhDich.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChiNhanhDich.FormattingEnabled = true;
            this.cmbChiNhanhDich.Location = new System.Drawing.Point(101, 21);
            this.cmbChiNhanhDich.Name = "cmbChiNhanhDich";
            this.cmbChiNhanhDich.Size = new System.Drawing.Size(260, 21);
            this.cmbChiNhanhDich.TabIndex = 13;
            this.cmbChiNhanhDich.SelectedIndexChanged += new System.EventHandler(this.cmbChiNhanhDich_SelectedIndexChanged);
            // 
            // txtDatabaseDich
            // 
            this.txtDatabaseDich.Location = new System.Drawing.Point(101, 87);
            this.txtDatabaseDich.Name = "txtDatabaseDich";
            this.txtDatabaseDich.Size = new System.Drawing.Size(263, 20);
            this.txtDatabaseDich.TabIndex = 11;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(36, 90);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(59, 13);
            this.label12.TabIndex = 10;
            this.label12.Text = "Database :";
            // 
            // txtPortDich
            // 
            this.txtPortDich.Location = new System.Drawing.Point(101, 66);
            this.txtPortDich.Name = "txtPortDich";
            this.txtPortDich.Size = new System.Drawing.Size(263, 20);
            this.txtPortDich.TabIndex = 9;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(63, 69);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(32, 13);
            this.label13.TabIndex = 8;
            this.label13.Text = "Port :";
            // 
            // txtIPDich
            // 
            this.txtIPDich.Location = new System.Drawing.Point(101, 45);
            this.txtIPDich.Name = "txtIPDich";
            this.txtIPDich.Size = new System.Drawing.Size(263, 20);
            this.txtIPDich.TabIndex = 7;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(72, 48);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(23, 13);
            this.label14.TabIndex = 6;
            this.label14.Text = "IP :";
            // 
            // numNamCN
            // 
            this.numNamCN.Location = new System.Drawing.Point(199, 7);
            this.numNamCN.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numNamCN.Minimum = new decimal(new int[] {
            2001,
            0,
            0,
            0});
            this.numNamCN.Name = "numNamCN";
            this.numNamCN.Size = new System.Drawing.Size(50, 20);
            this.numNamCN.TabIndex = 12;
            this.numNamCN.Value = new decimal(new int[] {
            2001,
            0,
            0,
            0});
            // 
            // numThangCN
            // 
            this.numThangCN.Location = new System.Drawing.Point(73, 7);
            this.numThangCN.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numThangCN.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numThangCN.Name = "numThangCN";
            this.numThangCN.Size = new System.Drawing.Size(50, 20);
            this.numThangCN.TabIndex = 10;
            this.numThangCN.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cmbChiNhanhNguon);
            this.groupBox1.Controls.Add(this.txtDatabaseNguon);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtPortNguon);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtIPNguon);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(356, 107);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Server nguồn";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Chi nhánh :";
            // 
            // cmbChiNhanhNguon
            // 
            this.cmbChiNhanhNguon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChiNhanhNguon.FormattingEnabled = true;
            this.cmbChiNhanhNguon.Location = new System.Drawing.Point(87, 16);
            this.cmbChiNhanhNguon.Name = "cmbChiNhanhNguon";
            this.cmbChiNhanhNguon.Size = new System.Drawing.Size(263, 21);
            this.cmbChiNhanhNguon.TabIndex = 7;
            this.cmbChiNhanhNguon.SelectedIndexChanged += new System.EventHandler(this.cmbChiNhanhNguon_SelectedIndexChanged);
            // 
            // txtDatabaseNguon
            // 
            this.txtDatabaseNguon.Location = new System.Drawing.Point(87, 82);
            this.txtDatabaseNguon.Name = "txtDatabaseNguon";
            this.txtDatabaseNguon.Size = new System.Drawing.Size(263, 20);
            this.txtDatabaseNguon.TabIndex = 5;
            this.txtDatabaseNguon.Text = "hepa_ksk1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 85);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Database :";
            // 
            // txtPortNguon
            // 
            this.txtPortNguon.Location = new System.Drawing.Point(87, 61);
            this.txtPortNguon.Name = "txtPortNguon";
            this.txtPortNguon.Size = new System.Drawing.Size(263, 20);
            this.txtPortNguon.TabIndex = 3;
            this.txtPortNguon.Text = "5432";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(49, 64);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Port :";
            // 
            // txtIPNguon
            // 
            this.txtIPNguon.Location = new System.Drawing.Point(87, 40);
            this.txtIPNguon.Name = "txtIPNguon";
            this.txtIPNguon.Size = new System.Drawing.Size(263, 20);
            this.txtIPNguon.TabIndex = 1;
            this.txtIPNguon.Text = "172.16.1.114";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(58, 43);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(23, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "IP :";
            // 
            // butCopyccautrucCN
            // 
            this.butCopyccautrucCN.Location = new System.Drawing.Point(169, 133);
            this.butCopyccautrucCN.Name = "butCopyccautrucCN";
            this.butCopyccautrucCN.Size = new System.Drawing.Size(94, 23);
            this.butCopyccautrucCN.TabIndex = 15;
            this.butCopyccautrucCN.Text = "Copy cấu trúc";
            this.butCopyccautrucCN.UseVisualStyleBackColor = true;
            this.butCopyccautrucCN.Click += new System.EventHandler(this.butCopyccautrucCN_Click);
            // 
            // butKiemTraCN
            // 
            this.butKiemTraCN.Location = new System.Drawing.Point(75, 133);
            this.butKiemTraCN.Name = "butKiemTraCN";
            this.butKiemTraCN.Size = new System.Drawing.Size(94, 23);
            this.butKiemTraCN.TabIndex = 14;
            this.butKiemTraCN.Text = "Kiểm tra";
            this.butKiemTraCN.UseVisualStyleBackColor = true;
            this.butKiemTraCN.Click += new System.EventHandler(this.butKiemTraCN_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(158, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Năm :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Tháng :";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.chkmedibvgoc);
            this.tabPage4.Controls.Add(this.cbMMYY);
            this.tabPage4.Controls.Add(this.butBoquaAlter);
            this.tabPage4.Controls.Add(this.butSuaAlter);
            this.tabPage4.Controls.Add(this.cbCommand);
            this.tabPage4.Controls.Add(this.label20);
            this.tabPage4.Controls.Add(this.txtDatatype);
            this.tabPage4.Controls.Add(this.label19);
            this.tabPage4.Controls.Add(this.txtDefaultValue);
            this.tabPage4.Controls.Add(this.label18);
            this.tabPage4.Controls.Add(this.label17);
            this.tabPage4.Controls.Add(this.txtColumnName);
            this.tabPage4.Controls.Add(this.label16);
            this.tabPage4.Controls.Add(this.txtTblName);
            this.tabPage4.Controls.Add(this.txtTim);
            this.tabPage4.Controls.Add(this.label15);
            this.tabPage4.Controls.Add(this.cbSchema);
            this.tabPage4.Controls.Add(this.butTaolai);
            this.tabPage4.Controls.Add(this.butLuuAltertable);
            this.tabPage4.Controls.Add(this.dataGridView1);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(366, 426);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Duyệt tạo cấu trúc";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // chkmedibvgoc
            // 
            this.chkmedibvgoc.AutoSize = true;
            this.chkmedibvgoc.Location = new System.Drawing.Point(262, 404);
            this.chkmedibvgoc.Name = "chkmedibvgoc";
            this.chkmedibvgoc.Size = new System.Drawing.Size(82, 17);
            this.chkmedibvgoc.TabIndex = 35;
            this.chkmedibvgoc.Text = "Medibv gốc";
            this.chkmedibvgoc.UseVisualStyleBackColor = true;
            // 
            // cbMMYY
            // 
            this.cbMMYY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMMYY.FormattingEnabled = true;
            this.cbMMYY.Location = new System.Drawing.Point(152, 402);
            this.cbMMYY.Name = "cbMMYY";
            this.cbMMYY.Size = new System.Drawing.Size(104, 21);
            this.cbMMYY.TabIndex = 34;
            // 
            // butBoquaAlter
            // 
            this.butBoquaAlter.Location = new System.Drawing.Point(240, 378);
            this.butBoquaAlter.Name = "butBoquaAlter";
            this.butBoquaAlter.Size = new System.Drawing.Size(94, 23);
            this.butBoquaAlter.TabIndex = 33;
            this.butBoquaAlter.Text = "Bỏ qua";
            this.butBoquaAlter.UseVisualStyleBackColor = true;
            this.butBoquaAlter.Click += new System.EventHandler(this.butBoquaAlter_Click);
            // 
            // butSuaAlter
            // 
            this.butSuaAlter.Location = new System.Drawing.Point(52, 378);
            this.butSuaAlter.Name = "butSuaAlter";
            this.butSuaAlter.Size = new System.Drawing.Size(94, 23);
            this.butSuaAlter.TabIndex = 32;
            this.butSuaAlter.Text = "Sửa";
            this.butSuaAlter.UseVisualStyleBackColor = true;
            this.butSuaAlter.Click += new System.EventHandler(this.butSuaAlter_Click);
            // 
            // cbCommand
            // 
            this.cbCommand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCommand.FormattingEnabled = true;
            this.cbCommand.Items.AddRange(new object[] {
            "add",
            "alter column"});
            this.cbCommand.Location = new System.Drawing.Point(75, 334);
            this.cbCommand.Name = "cbCommand";
            this.cbCommand.Size = new System.Drawing.Size(89, 21);
            this.cbCommand.TabIndex = 31;
            this.cbCommand.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTblName_KeyDown);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(171, 338);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(53, 13);
            this.label20.TabIndex = 30;
            this.label20.Text = "Data type";
            // 
            // txtDatatype
            // 
            this.txtDatatype.Location = new System.Drawing.Point(233, 335);
            this.txtDatatype.Name = "txtDatatype";
            this.txtDatatype.Size = new System.Drawing.Size(131, 20);
            this.txtDatatype.TabIndex = 29;
            this.txtDatatype.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTblName_KeyDown);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(2, 359);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(70, 13);
            this.label19.TabIndex = 28;
            this.label19.Text = "Default value";
            // 
            // txtDefaultValue
            // 
            this.txtDefaultValue.Location = new System.Drawing.Point(75, 356);
            this.txtDefaultValue.Name = "txtDefaultValue";
            this.txtDefaultValue.Size = new System.Drawing.Size(289, 20);
            this.txtDefaultValue.TabIndex = 27;
            this.txtDefaultValue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTblName_KeyDown);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(17, 338);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(54, 13);
            this.label18.TabIndex = 26;
            this.label18.Text = "Command";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(180, 316);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(73, 13);
            this.label17.TabIndex = 24;
            this.label17.Text = "Column Name";
            // 
            // txtColumnName
            // 
            this.txtColumnName.Location = new System.Drawing.Point(260, 313);
            this.txtColumnName.Name = "txtColumnName";
            this.txtColumnName.Size = new System.Drawing.Size(104, 20);
            this.txtColumnName.TabIndex = 23;
            this.txtColumnName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTblName_KeyDown);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 316);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(65, 13);
            this.label16.TabIndex = 22;
            this.label16.Text = "Table Name";
            // 
            // txtTblName
            // 
            this.txtTblName.Location = new System.Drawing.Point(75, 313);
            this.txtTblName.Name = "txtTblName";
            this.txtTblName.Size = new System.Drawing.Size(100, 20);
            this.txtTblName.TabIndex = 21;
            this.txtTblName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTblName_KeyDown);
            // 
            // txtTim
            // 
            this.txtTim.Location = new System.Drawing.Point(170, 6);
            this.txtTim.Name = "txtTim";
            this.txtTim.Size = new System.Drawing.Size(194, 20);
            this.txtTim.TabIndex = 20;
            this.txtTim.Text = "Tìm kiếm";
            this.txtTim.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTim.TextChanged += new System.EventHandler(this.txtTim_TextChanged);
            this.txtTim.Leave += new System.EventHandler(this.txtTim_Leave);
            this.txtTim.Enter += new System.EventHandler(this.txtTim_Enter);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(14, 9);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(46, 13);
            this.label15.TabIndex = 19;
            this.label15.Text = "Schema";
            // 
            // cbSchema
            // 
            this.cbSchema.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSchema.FormattingEnabled = true;
            this.cbSchema.Items.AddRange(new object[] {
            "MMYY",
            "Medibv"});
            this.cbSchema.Location = new System.Drawing.Point(63, 5);
            this.cbSchema.Name = "cbSchema";
            this.cbSchema.Size = new System.Drawing.Size(101, 21);
            this.cbSchema.TabIndex = 18;
            this.cbSchema.SelectedIndexChanged += new System.EventHandler(this.cbSchema_SelectedIndexChanged);
            this.cbSchema.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTblName_KeyDown);
            // 
            // butTaolai
            // 
            this.butTaolai.Location = new System.Drawing.Point(29, 402);
            this.butTaolai.Name = "butTaolai";
            this.butTaolai.Size = new System.Drawing.Size(117, 23);
            this.butTaolai.TabIndex = 17;
            this.butTaolai.Text = "Tạo lại số liệu";
            this.butTaolai.UseVisualStyleBackColor = true;
            this.butTaolai.Click += new System.EventHandler(this.butTaolai_Click);
            // 
            // butLuuAltertable
            // 
            this.butLuuAltertable.Location = new System.Drawing.Point(146, 378);
            this.butLuuAltertable.Name = "butLuuAltertable";
            this.butLuuAltertable.Size = new System.Drawing.Size(94, 23);
            this.butLuuAltertable.TabIndex = 16;
            this.butLuuAltertable.Text = "Lưu";
            this.butLuuAltertable.UseVisualStyleBackColor = true;
            this.butLuuAltertable.Click += new System.EventHandler(this.butLuuAltertable_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.c_ID,
            this.c_schema,
            this.c_tablename,
            this.c_Column_name,
            this.c_comand,
            this.c_datatype,
            this.c_default_value});
            this.dataGridView1.Location = new System.Drawing.Point(7, 29);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(357, 278);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CurrentCellChanged += new System.EventHandler(this.dataGridView1_CurrentCellChanged);
            // 
            // c_ID
            // 
            this.c_ID.DataPropertyName = "id";
            this.c_ID.HeaderText = "ID";
            this.c_ID.Name = "c_ID";
            this.c_ID.Visible = false;
            // 
            // c_schema
            // 
            this.c_schema.DataPropertyName = "schema_name";
            this.c_schema.HeaderText = "Schema";
            this.c_schema.Name = "c_schema";
            // 
            // c_tablename
            // 
            this.c_tablename.DataPropertyName = "table_name";
            this.c_tablename.HeaderText = "Table_Name";
            this.c_tablename.Name = "c_tablename";
            // 
            // c_Column_name
            // 
            this.c_Column_name.DataPropertyName = "field_name";
            this.c_Column_name.HeaderText = "Column Name";
            this.c_Column_name.Name = "c_Column_name";
            // 
            // c_comand
            // 
            this.c_comand.DataPropertyName = "command_ct";
            this.c_comand.HeaderText = "Command";
            this.c_comand.Name = "c_comand";
            // 
            // c_datatype
            // 
            this.c_datatype.DataPropertyName = "data_type";
            this.c_datatype.HeaderText = "Data Type";
            this.c_datatype.Name = "c_datatype";
            // 
            // c_default_value
            // 
            this.c_default_value.DataPropertyName = "default_value";
            this.c_default_value.HeaderText = "Default value";
            this.c_default_value.Name = "c_default_value";
            // 
            // frmCSDL
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(379, 521);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.butExit);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmCSDL";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý cơ sở dữ liệu";
            this.Load += new System.EventHandler(this.frmCSDL_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCSDL_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNamDich)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numThangDich)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNamNguon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numThangNguon)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNamCN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numThangCN)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void frmCSDL_Load(object sender, System.EventArgs e)
		{
            user = m.user;
            //
            dataGridView1.AutoGenerateColumns = false;
            //
			ds.ReadXml("..//..//..//xml//m_csdl.xml");
			ds.Tables[0].Columns.Add("chon",typeof(bool));
            ds.Tables[0].Columns.Add("huy", typeof(bool));
            bAdminHethong = m.bAdminHethong(i_userid);
			load_grid();
			dataGrid1.DataSource=ds.Tables[0];
			CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource];
			DataView dv = (DataView) cm.List; 
			dv.AllowNew = false; 
			AddGridTableStyle();
			lan.Read_dtgrid_to_Xml(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			lan.Change_dtgrid_HeaderText_to_English(dataGrid1, this.Name.ToString()+"_"+dataGrid1.Name.ToString());
			this.disabledBackBrush = new SolidBrush(Color.FromArgb(255,255,192));//SystemColors.Info
			this.disabledTextBrush = new SolidBrush(Color.FromArgb(255,0,0));

			this.alertBackBrush = new SolidBrush(SystemColors.HotTrack);
			this.alertFont = new Font(this.dataGrid1.Font.Name, this.dataGrid1.Font.Size, FontStyle.Bold);
			this.alertTextBrush = new SolidBrush(Color.White);
			
			this.currentRowFont = new Font(this.dataGrid1.Font.Name, this.dataGrid1.Font.Size, FontStyle.Regular);
			this.currentRowBackBrush = new SolidBrush(Color.FromArgb(0,255, 255));
            //
            int i_mm = DateTime.Now.Month;
            int i_mmnguon = (i_mm == 1) ? 12 : i_mm - 1;
            int i_yy = DateTime.Now.Year;
            int i_yynguon = (i_mm == 1) ? i_yy - 1 : i_yy;
            numThangDich.Value = decimal.Parse(i_mm.ToString());
            numThangNguon.Value = decimal.Parse(i_mmnguon.ToString());
            numNamDich.Value = decimal.Parse(i_yy.ToString());
            numNamNguon.Value = decimal.Parse(i_yynguon.ToString());
            numThangCN.Value = decimal.Parse(i_mm.ToString());
            numNamCN.Value = decimal.Parse(i_yy.ToString());
            LoadChiNhanh_nguon();
            LoadChiNhanh_Dich(0);
            //
            #region alter table            
            cbSchema.SelectedIndex = 0;
            f_capnhat_db();
            f_load_alter_table("xxx");
            ena_alter_obj(false);
            #endregion
        }

		private void load_grid()
		{
			DataRow r1;
			ds.Clear();
			string sql="select mmyy,substr(mmyy,3,2)||substr(mmyy,1,2) as yymm,bak from "+user+".table ";
			foreach(DataRow r in m.get_data(sql).Tables[0].Select("true","yymm"))
			{
				r1=ds.Tables[0].NewRow();
				r1["mmyy"]=r["mmyy"].ToString();
				r1["noidung"]="Tháng "+r["mmyy"].ToString().Substring(0,2)+" năm "+r["mmyy"].ToString().Substring(2,2);
				r1["chon"]=(r["bak"].ToString()=="0")?true:false;
                r1["huy"] = false;
				ds.Tables[0].Rows.Add(r1);
			}
            //
            dtmmyy = ds.Tables[0].Copy();
            cbMMYY.DisplayMember = "mmyy";
            cbMMYY.ValueMember = "mmyy";
            cbMMYY.DataSource = dtmmyy;
            if (dtmmyy.Rows.Count > 0)
            {
                cbMMYY.SelectedIndex = dtmmyy.Rows.Count - 1;
            }
		}

		private void butExit_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}

		private void AddGridTableStyle()
		{
			DataGridTableStyle ts =new DataGridTableStyle();
			ts.MappingName = ds.Tables[0].TableName;
			ts.AlternatingBackColor = Color.Beige;
			ts.BackColor = Color.GhostWhite;
			ts.ForeColor = Color.MidnightBlue;
			ts.GridLineColor = Color.RoyalBlue;
			ts.HeaderBackColor = Color.MidnightBlue;
			ts.HeaderForeColor = Color.Lavender;
			ts.SelectionBackColor = Color.FromArgb(0,255,255);
			ts.SelectionForeColor = Color.PaleGreen;
			ts.RowHeaderWidth=10;
					
			FormattableBooleanColumn discontinuedCol = new FormattableBooleanColumn();
			discontinuedCol.MappingName = "chon";
			discontinuedCol.HeaderText = "Sao lưu";
			discontinuedCol.Width = 50;
			discontinuedCol.AllowNull = false;

			discontinuedCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			discontinuedCol.BoolValueChanged += new BoolValueChangedEventHandler(BoolValueChanged);
			ts.GridColumnStyles.Add(discontinuedCol);
			dataGrid1.TableStyles.Add(ts);

			FormattableTextBoxColumn TextCol = new FormattableTextBoxColumn();
			TextCol.MappingName = "noidung";
			TextCol.HeaderText = "Cơ sở dữ liệu";
			TextCol.Width = 180;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

            FormattableBooleanColumn discontinuedCol1 = new FormattableBooleanColumn();
            discontinuedCol1.MappingName = "huy";
            discontinuedCol1.HeaderText = "Không dùng";
            discontinuedCol1.Width = 100;
            discontinuedCol1.AllowNull = false;

            discontinuedCol1.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
            discontinuedCol1.BoolValueChanged += new BoolValueChangedEventHandler(BoolValueChanged);
            ts.GridColumnStyles.Add(discontinuedCol1);
            dataGrid1.TableStyles.Add(ts);
		}
	
		// Provides the format for the given cell.
		private void SetCellFormat(object sender, DataGridFormatCellEventArgs e)
		{
			try
			{
				//conditionally set properties in e depending upon e.Row and e.Col
				bool discontinued = (bool) ((e.Column != 0) ? this.dataGrid1[e.Row, 0] : e.CurrentCellValue);
				//check is discontinued
				if(e.Column > 0 && !(bool)(this.dataGrid1[e.Row, 0]))//discontinued)
				{
					e.ForeBrush = this.disabledTextBrush;
				}
				else if(e.Column > 0 && e.Row == this.dataGrid1.CurrentRowIndex)//discontinued)
				{
					e.BackBrush = this.currentRowBackBrush;
					e.TextFont = this.currentRowFont;
				}
			}
			catch{}
		}

		private void BoolValueChanged(object sender, BoolValueChangedEventArgs e)
		{
			this.dataGrid1.EndEdit(this.dataGrid1.TableStyles[0].GridColumnStyles["Discontinued"],e.Row, false);
			RefreshRow(e.Row);
			this.dataGrid1.BeginEdit(this.dataGrid1.TableStyles[0].GridColumnStyles["Discontinued"],e.Row);
		}
		private void RefreshRow(int row)
		{
			Rectangle rect = this.dataGrid1.GetCellBounds(row, 0);
			rect = new Rectangle(rect.Right, rect.Top, this.dataGrid1.Width, rect.Height);
			this.dataGrid1.Invalidate(rect);
		}

		private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			if((bool)this.dataGrid1[this.dataGrid1.CurrentRowIndex, checkCol])
				this.dataGrid1.CurrentCell = new DataGridCell(this.dataGrid1.CurrentRowIndex, checkCol);
            else if ((bool)this.dataGrid1[this.dataGrid1.CurrentRowIndex, checkCol1])
                this.dataGrid1.CurrentCell = new DataGridCell(this.dataGrid1.CurrentRowIndex, checkCol1);
			afterCurrentCellChanged = true;
		}

		private void dataGrid1_Click(object sender, System.EventArgs e)
		{
			Point pt = this.dataGrid1.PointToClient(Control.MousePosition);
			DataGrid.HitTestInfo hti = this.dataGrid1.HitTest(pt);
			BindingManagerBase bmb = this.BindingContext[this.dataGrid1.DataSource, this.dataGrid1.DataMember];
			if(afterCurrentCellChanged && hti.Row < bmb.Count 
				&& hti.Type == DataGrid.HitTestType.Cell 
				&&  hti.Column == checkCol )
			{	
				this.dataGrid1[hti.Row, checkCol] = !(bool)this.dataGrid1[hti.Row, checkCol];
				RefreshRow(hti.Row);
			}
            else if (afterCurrentCellChanged && hti.Row < bmb.Count
                && hti.Type == DataGrid.HitTestType.Cell
                && hti.Column == checkCol1)
            {
                this.dataGrid1[hti.Row, checkCol1] = !(bool)this.dataGrid1[hti.Row, checkCol1];
                RefreshRow(hti.Row);
            }
			afterCurrentCellChanged = false;
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			load_grid();
		}

        private void butLuu_Click(object sender, System.EventArgs e)
        {
            foreach (DataRow r in ds.Tables[0].Rows)
                m.execute_data("update " + user + ".table set bak=" + ((r["chon"].ToString() == "True") ? 0 : 1) + " where mmyy='" + r["mmyy"].ToString() + "'");

            bool bhuy = false;

            foreach (DataRow r1 in ds.Tables[0].Select("huy=true"))
            {
                if (bAdminHethong)
                {
                    DialogResult dlg = MessageBox.Show(lan.Change_language_MessageText(" không ?") + "\n" + lan.Change_language_MessageText("Khi ẩn rồi thì sẽ không lấy số liệu của tháng đó được nữa."), lan.Change_language_MessageText("Quản lý CSDL"), MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (dlg == DialogResult.Yes)
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Nếu muốn khôi phục lại số liệu tháng '") + r1["mmyy"].ToString() + "'\n"+lan.Change_language_MessageText("Thì chỉ cần đăng ký tiếp đón 1 bệnh nhân nào đó vào bất kỳ ngày nào trong tháng '") + r1["mmyy"].ToString() + "'", lan.Change_language_MessageText("Quản lý CSDL"), MessageBoxButtons.OK, MessageBoxIcon.Information);

                        m.execute_data("delete from " + user + ".table where mmyy='" + r1["mmyy"].ToString() + "'");
                        bhuy = true;
                    }
                }
                else
                {
                    MessageBox.Show(lan.Change_language_MessageText("Bạn chưa được phân quyền để ẩn dữ liệu tháng '" + r1["mmyy"].ToString() + "'.")+"\n"+lan.Change_language_MessageText("Đề nghị liên hệ phòng máy tính"));
                    bhuy = false;
                }
            }
            if (bhuy) load_grid();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void butKiemTra_Click(object sender, EventArgs e)
        {
            ammyyNguon = numThangNguon.Value.ToString().PadLeft(2, '0') + numNamNguon.Value.ToString().Substring(2, 2);
            ammyyDich = numThangDich.Value.ToString().PadLeft(2, '0') + numNamDich.Value.ToString().Substring(2, 2);
            Cursor = Cursors.WaitCursor;
            dsCauTrucNguon = KiemTraCauTruc(ammyyNguon, ammyyDich);
            //
            string s_dbname = m.Maincode("Database");            
            m.f_get_cautruc_chuan(s_dbname, m.user, ammyyNguon);           
            //
            Cursor = Cursors.Default;
        }

        private DataSet KiemTraCauTruc_CN(string ammyy)
        {
            DataSet dsnguon;
            DataSet dsdich;
            string s_database = m.Maincode("Database");
            string s_connnguon = m.GetConnString(txtIPNguon.Text, txtPortNguon.Text, txtDatabaseNguon.Text);
            string s_connDich = m.GetConnString(txtIPDich.Text, txtPortDich.Text, txtDatabaseDich.Text);
            string asql = "", xxx = m.user + ammyy;
            asql = " select table_schema as a1, table_name as a2, column_name as a3, 'alter table '||table_schema||'.'||table_name ||' add '||column_name||' '|| data_type ||' '|| case when trim(numeric_precision)='' or numeric_precision is null then '' else '('||numeric_precision||')' end ||case when column_default is null then '' else ' default '||column_default end ||';' as sql, to_number('0') as khac ";
            asql += " from information_schema.columns  where table_catalog='" + txtDatabaseNguon.Text + "' AND table_schema='" + xxx + "' and data_type<>'character varying' ";
            asql += " UNION ALL ";
            asql += " select table_schema as a1, table_name as a2, column_name as a3, 'alter table '||table_schema||'.'||table_name ||' add '||column_name||' '|| data_type ||' ('|| character_maximum_length||')'||';' as sql , to_number('0') as khac ";
            asql += " from information_schema.columns  where table_catalog='" + txtDatabaseNguon.Text + "' AND table_schema='" + xxx + "' and data_type='character varying' ";
            dsnguon = m.get_data_con(asql, s_connnguon);
            //            
            asql = " select table_schema as a1, table_name as a2, column_name as a3, 'alter table '||table_schema||'.'||table_name ||' add '||column_name||' '|| data_type ||' '|| case when trim(numeric_precision)='' or numeric_precision is null then '' else '('||numeric_precision||')' end ||case when column_default is null then '' else ' default '||column_default end ||';' as sql, to_number('0') as khac ";
            asql += " from information_schema.columns  where table_catalog='" + txtDatabaseDich.Text + "' AND table_schema='" + xxx + "' and data_type<>'character varying' ";
            asql += " UNION ALL ";
            asql += " select table_schema as a1, table_name as a2, column_name as a3, 'alter table '||table_schema||'.'||table_name ||' add '||column_name||' '|| data_type ||' ('|| character_maximum_length||')'||';' as sql , to_number('0') as khac ";
            asql += " from information_schema.columns  where table_catalog='" + txtDatabaseDich.Text + "' AND table_schema='" + xxx + "' and data_type='character varying' ";
            dsdich = m.get_data_con(asql, s_connDich);

            string s_khacBiet = "";
            string s_exp = "";
            DataRow dr1;
            int iCount = 0, iStt = 0, iKhac = 0;
            foreach (DataRow dr in dsnguon.Tables[0].Rows)
            {
                iStt += 1;
                s_exp = "a2='" + dr["a2"].ToString() + "' and a3='" + dr["a3"].ToString() + "'";
                dr1 = m.getrowbyid(dsdich.Tables[0], s_exp);
                if (dr1 == null)
                {
                    dr["khac"] = 1;
                    s_khacBiet += dr["a2"].ToString() + "." + dr["a3"].ToString() + "\r\n";
                    butCopyccautruc.Enabled = true;
                    iKhac += 1;
                }
                lblStatusCN.Text = iStt.ToString() + "/" + iCount.ToString() + " - " + iKhac.ToString();
                lblStatusCN.Refresh();
            }
            dsnguon.AcceptChanges();
            txtViewCN.Text = s_khacBiet;
            txtViewCN.Refresh();

            return dsnguon;
        }

        private void butCopyccautruc_Click(object sender, EventArgs e)
        {
            string xxx = m.user + ammyyNguon, xxx1 = m.user + ammyyDich;
            Cursor = Cursors.WaitCursor;
            if (dsCauTrucNguon == null || dsCauTrucNguon.Tables.Count <= 0)
            {
                butKiemTra_Click(null, null);
            }
            //
            string a_mmyy = ammyyDich;
            if (m.bMmyy(a_mmyy) == false)
            {
                MessageBox.Show("Cấu trúc dữ liệu tháng " + a_mmyy + " chưa tạo.");
                Cursor = Cursors.Default;
                return;
            }            
            m.modify_schema_mmyy_new(a_mmyy);
            //
            //string asql = "";
            //foreach (DataRow dr in dsCauTrucNguon.Tables[0].Select("khac=1"))
            //{
            //    asql = dr["khac"].ToString();
            //    asql = dr["sql"].ToString();
            //    asql = dr["sql"].ToString().Replace(xxx, xxx1);
            //    m.execute_data(asql, false);
            //}
            Cursor = Cursors.Default;
        }


        public void LoadChiNhanh_nguon()
        {
            string asql = "select * from medibv.dmchinhanh where id >0 order by id ";
            dtCNNguon = m.get_data(asql).Tables[0].Copy();
            cmbChiNhanhNguon.DataSource = dtCNNguon;
            cmbChiNhanhNguon.DisplayMember = "TEN";
            cmbChiNhanhNguon.ValueMember = "ID";
            //butKiemTraCN.Enabled = (dtCNNguon.Rows.Count > 1);
            butCopyccautrucCN.Enabled = butKiemTraCN.Enabled;
        }
        public void LoadChiNhanh_Dich(int i_IDCN_Nguon)
        {
            string asql = "select * from medibv.dmchinhanh where id >0 and id<>" + i_IDCN_Nguon + " order by id ";
            dtCNDich = m.get_data(asql).Tables[0].Copy();
            cmbChiNhanhDich.DataSource = dtCNDich;// ksk.get_data(asql).Tables[0];
            cmbChiNhanhDich.DisplayMember = "TEN";
            cmbChiNhanhDich.ValueMember = "ID";
            //butKiemTraCN.Enabled = (dtCNDich.Rows.Count > 1);
            butCopyccautrucCN.Enabled = butKiemTraCN.Enabled;
        }

        private void cmbChiNhanhNguon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == cmbChiNhanhNguon || sender == null)
            {
                int i_IDCNNguon = (cmbChiNhanhNguon.SelectedIndex >= 0) ? int.Parse(cmbChiNhanhNguon.SelectedValue.ToString()) : 0;
                LoadChiNhanh_Dich(i_IDCNNguon);
                Load_thongtin_cnNguon(i_IDCNNguon);
            }
        }

        private void cmbChiNhanhDich_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == cmbChiNhanhDich || sender == null)
            {
                Load_thongtin_cnDich(cmbChiNhanhDich.SelectedIndex < 0 ? 0 : int.Parse(cmbChiNhanhDich.SelectedValue.ToString()));
            }
        }

        private void Load_thongtin_cnNguon(int i_idCN)
        {
            DataRow dr = m.getrowbyid(dtCNNguon, "id=" + i_idCN);
            if (dr != null)
            {
                txtIPNguon.Text = dr["ip"].ToString();
                txtPortNguon.Text = dr["port"].ToString();
                txtDatabaseNguon.Text = dr["database_local"].ToString();
            }
        }

        private void Load_thongtin_cnDich(int i_idCN)
        {
            DataRow dr = m.getrowbyid(dtCNDich, "id=" + i_idCN);
            if (dr != null)
            {
                txtIPDich.Text = dr["ip"].ToString();
                txtPortDich.Text = dr["port"].ToString();
                txtDatabaseDich.Text = dr["database_local"].ToString();
                txtIPDich.Tag = dr["database"].ToString();
            }
        }

        private void butKiemTraCN_Click(object sender, EventArgs e)
        {
            ammyyNguon = numThangCN.Value.ToString().PadLeft(2, '0') + numNamCN.Value.ToString().Substring(2, 2);
            if (chkGoc.Checked) ammyyNguon = "";
            Cursor = Cursors.WaitCursor;
            dsCauTrucNguon = KiemTraCauTruc_CN(ammyyNguon);
            Cursor = Cursors.Default;
        }

        private DataSet KiemTraCauTruc(string ammyy_nguon, string ammyy_dich)
        {
            DataSet dsnguon;
            DataSet dsdich;
            string s_database = m.Maincode("Database");
            string asql = "", xxx = m.user + ammyy_nguon;
            asql = " select table_schema as a1, table_name as a2, column_name as a3, 'alter table '||table_schema||'.'||table_name ||' add '||column_name||' '|| data_type ||' '|| case when trim(numeric_precision)='' or numeric_precision is null then '' else '('||numeric_precision||')' end ||case when column_default is null then '' else ' default '||column_default end ||';' as sql, to_number('0') as khac ";
            asql += " from information_schema.columns  where table_catalog='" + s_database + "' AND table_schema='" + xxx + "' and data_type<>'character varying' ";
            asql += " UNION ALL ";
            asql += " select table_schema as a1, table_name as a2, column_name as a3, 'alter table '||table_schema||'.'||table_name ||' add '||column_name||' '|| data_type ||' ('|| character_maximum_length||')'||';' as sql , to_number('0') as khac ";
            asql += " from information_schema.columns  where table_catalog='" + s_database + "' AND table_schema='" + xxx + "' and data_type='character varying' ";
            dsnguon = m.get_data(asql);
            //
            xxx = m.user + ammyy_dich;
            asql = " select table_schema as a1, table_name as a2, column_name as a3, 'alter table '||table_schema||'.'||table_name ||' add '||column_name||' '|| data_type ||' '|| case when trim(numeric_precision)='' or numeric_precision is null then '' else '('||numeric_precision||')' end ||case when column_default is null then '' else ' default '||column_default end ||';' as sql, to_number('0') as khac ";
            asql += " from information_schema.columns  where table_catalog='" + s_database + "' AND table_schema='" + xxx + "' and data_type<>'character varying' ";
            asql += " UNION ALL ";
            asql += " select table_schema as a1, table_name as a2, column_name as a3, 'alter table '||table_schema||'.'||table_name ||' add '||column_name||' '|| data_type ||' ('|| character_maximum_length||')'||';' as sql, to_number('0') as khac ";
            asql += " from information_schema.columns  where table_catalog='" + s_database + "' AND table_schema='" + xxx + "' and data_type='character varying' ";
            dsdich = m.get_data(asql);

            string s_khacBiet = "";
            string s_exp = "";
            DataRow dr1;
            int iCount = 0, iStt = 0, iKhac = 0;
            foreach (DataRow dr in dsnguon.Tables[0].Rows)
            {
                iStt += 1;
                s_exp = "a2='" + dr["a2"].ToString() + "' and a3='" + dr["a3"].ToString() + "'";
                dr1 = m.getrowbyid(dsdich.Tables[0], s_exp);
                if (dr1 == null)
                {
                    dr["khac"] = 1;
                    s_khacBiet += dr["a2"].ToString() + "." + dr["a3"].ToString() + "\r\n";
                    butCopyccautruc.Enabled = true;
                    iKhac += 1;
                }
                lblStatus.Text = iStt.ToString() + "/" + iCount.ToString() + " - " + iKhac.ToString();
                lblStatus.Refresh();
            }
            dsnguon.AcceptChanges();
            txtView.Text = s_khacBiet;
            txtView.Refresh();

            return dsnguon;
        }

        private void butCopyccautrucCN_Click(object sender, EventArgs e)
        {
            //string xxx = m.user + ammyyNguon, xxx1 = m.user + ammyyDich;
            Cursor = Cursors.WaitCursor;            
            string s_connDich = m.GetConnString(txtIPDich.Text, txtPortDich.Text, txtDatabaseDich.Text);
            if (dsCauTrucNguon == null || dsCauTrucNguon.Tables.Count <= 0)
            {
                butKiemTraCN_Click(null, null);
            }
            string asql = "";
            foreach (DataRow dr in dsCauTrucNguon.Tables[0].Select("khac=1"))
            {                
                asql = dr["sql"].ToString();
                asql = dr["sql"].ToString();//.Replace(xxx, xxx1);
                m.execute_sql(asql, s_connDich);
            }
            Cursor = Cursors.Default;
        }

        private void f_load_alter_table(string s_SchemaName)
        {
            if (s_SchemaName.ToLower() == "mmyy") s_SchemaName = "xxx";
            string asql = "select * from medibv.alter_table where schema_name='" + s_SchemaName + "'";
            dsColumnAlter = m.get_data(asql);
            dataGridView1.DataSource = dsColumnAlter.Tables[0];
        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                int i = dataGridView1.CurrentCell.RowIndex;

                d_idcolumn = decimal.Parse(dataGridView1[0, i].Value.ToString());
                DataRow r = m.getrowbyid(dsColumnAlter.Tables[0], "id='" + d_idcolumn + "'");
                if (r != null)
                {
                    txtTblName.Text = r["table_name"].ToString();
                    txtColumnName.Text = r["field_name"].ToString();
                    txtDatatype.Text = r["data_type"].ToString();
                    txtDefaultValue.Text = r["default_value"].ToString();
                    cbCommand.Text   = r["command_ct"].ToString();

                    ena_alter_obj(false);
                }
            }
            catch { }
        }

        private void ena_alter_obj(bool ena)
        {
            dataGridView1.Enabled = !ena;

            cbSchema.Enabled = !ena;
            txtTim.Enabled = !ena;
            txtTblName.Enabled = false;// ena;
            txtColumnName.Enabled = false;// ena;
            txtDatatype.Enabled = ena;
            txtDefaultValue.Enabled = ena;
            cbCommand.Enabled = ena;

            butSuaAlter.Enabled = !ena;
            butBoquaAlter.Enabled = ena;
            butLuuAltertable.Enabled = ena;            
        }

        private void emp_alter_obj()
        {
            txtTblName.Text = "";
            txtColumnName.Text = "";
            txtDatatype.Text = "";
            txtDefaultValue.Text = "";
            cbCommand.SelectedIndex = 0;
        }

        private void butBoquaAlter_Click(object sender, EventArgs e)
        {
            ena_alter_obj(false);
            dataGridView1.Focus();
        }

        private void butSuaAlter_Click(object sender, EventArgs e)
        {
            if (bAllowAlter == false)
            {
                MessageBox.Show("Bạn không được phép sửa.");
                return;
            }
            ena_alter_obj(true);
            cbCommand.Focus();
        }

        private void butLuuAltertable_Click(object sender, EventArgs e)
        {
            if (txtTblName.Text == "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Đề nghị nhập Table Name"));
                txtTblName.Focus();
                return;
            }
            if (txtColumnName.Text == "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Đề nghị nhập Column Name"));
                txtColumnName.Focus();
                return;
            }
            if (cbCommand.Text == "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Đề nghị chọn command"));
                cbCommand.Focus();
                return;
            }
            if (txtDatatype.Text == "")
            {
                MessageBox.Show(lan.Change_language_MessageText("Đề nghị nhập Data Type"));
                txtDatatype.Focus();
                return;
            }
            //
            m.upd_alter_table(d_idcolumn == 0, d_idcolumn, (cbSchema.Text.ToLower() == "mmyy") ? "xxx" : cbSchema.Text, txtTblName.Text, txtColumnName.Text, cbCommand.Text, txtDatatype.Text, txtDefaultValue.Text);
            //
            f_load_alter_table((cbSchema.Text.ToLower() == "mmyy") ? "xxx" : cbSchema.Text);
            ena_alter_obj(false);
            dataGridView1.Focus();

        }

        private void txtTim_Enter(object sender, EventArgs e)
        {
            txtTim.Text = "";
        }

        private void txtTim_Leave(object sender, EventArgs e)
        {
            if (txtTim.Text == "") txtTim.Text = "Tìm kiếm";
        }

        private void txtTim_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtTim.Text.Trim() == "Tìm kiếm") { txtTim.Text = ""; return; }
                CurrencyManager cm = (CurrencyManager)BindingContext[dataGridView1.DataSource];
                DataView dv = (DataView)cm.List;
                dv.RowFilter = "table_name like '%" + txtTim.Text.Trim() + "%' or field_name like '%" + txtTim.Text.Trim() + "%'";
            }
            catch { }
        }

        private void cbSchema_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == cbSchema || sender == null)
            {
                f_load_alter_table((cbSchema.Text.ToLower() == "mmyy") ? "xxx" : cbSchema.Text.ToLower());
            }
        }

        private void txtTblName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void butTaolai_Click(object sender, EventArgs e)
        {
            if (cbMMYY.Items.Count > 0 && cbMMYY.SelectedIndex >= 0)
            {
                string a_mmyy = cbMMYY.SelectedValue.ToString();
                if (m.bMmyy(a_mmyy) == false)
                {
                    MessageBox.Show("Cấu trúc dữ liệu tháng " + a_mmyy + " chưa tạo.");
                    return;
                }
                Cursor = Cursors.WaitCursor;
                if (chkmedibvgoc.Checked) m.modify_schema_root_new();
                m.modify_schema_mmyy_new(a_mmyy);
                Cursor = Cursors.Default;
                MessageBox.Show("Đã tạo xong.");
            }
        }



        private void f_capnhat_db()
        {
            string asql = "create table medibv.alter_table (id serial, schema_name varchar(60) , table_name varchar(60),command_ct varchar(30), field_name varchar(60), data_type varchar(128), default_value varchar(300), constraint pk_alter_table primary key (id))";
            m.execute_data(asql,false);
        }

        private void frmCSDL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A && e.Control && e.Shift && e.Alt)
            {
                bAllowAlter = !bAllowAlter;
            }
        }
	}
}
