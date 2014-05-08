using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibDuoc;
using LibMedi;
using dichso;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.IO;

namespace Medisoft
{
	/// <summary>
	/// Summary description for frmDuyet.
	/// </summary>
	public class frmXacnhan_Thuchien_dmkt : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.DataGrid dataGrid1;
		private Brush disabledBackBrush;
		private Brush disabledTextBrush;
		private Brush alertBackBrush;
		private Font alertFont,alertFont2;
		private Brush alertTextBrush;
		private Font currentRowFont,currentRowFont2;
		private Brush currentRowBackBrush,RowBackBrushVP;
        private bool afterCurrentCellChanged, bSkip = false, bCongkham_pl, bIncstt, bKhoaso, bQuyenso, bDuyettoa_ketthuc, bAdmin, bChuyenkham_congkham, bInchiphi_chandoan_bacsy, bDuyetcls, bChenhlech, bGia_bh_quydinh_giamua, bPhongkhamduyetrieng=true;
        private bool bThuchenhlechtruoc_duyettoasau = false, bLaygiamua_khi_giabh_0_giabh_nho_giamua = true, bBHYT_Traituyen_tinh_Tyle_khac = false, bTraituyen_bhtra = false, bBhyt_tra_1_congkham = false, bQuanly_HinhBN = false, b_chuathutienthuoc=true;
        private int checkCol = 0, i_userid, i_row, i_mavp, iMavp_congkham, songayduyet, i_tunguyen, i_quyen_duyetmau38=0;
        private System.Drawing.Bitmap map;
        private LibMedi.AccessData m = new LibMedi.AccessData();
        private string s_loavp_thuchien = "", s_loaivp_cdha = "", s_mavp_kham = "";
        private LibDuoc.AccessData d = new LibDuoc.AccessData();
		private int i_nhom,i_madoituong,i_loaiba,itable,_madoituong,iTraituyen, i_khudt=0;
		private decimal l_id=0,l_maql=0,l_mavaovien=0,lTraituyen=0, l_iddoan=0;
        private string user,v_id="", xxx, yyy, sql, s_kho, s_ngay, s_manguon, s_mmyy, s_mabn, s_makp, s_hoten="", s_tu, s_den, stime, s_mabs, s_userid, s_mavp = "", s_chenhlech, fie_tunguyen, s_tunguyen, ngay_reset_phieu38="";
        private string s_idcomputer = "", s_tendoanksk = "";
        private string pathImage = "", FileType = "";
		private DataSet ds=new DataSet();
        private DataSet ds1 = new DataSet();
        private DataSet dsxmlin = new DataSet();
		private DataTable dt=new DataTable();
		private DataTable dtct=new DataTable();
		private DataTable dtton=new DataTable();
		private DataTable dttonct=new DataTable();
		private DataTable dtmavp=new DataTable();
		public DataTable dtll=new DataTable();
        private DataTable dtkp = new DataTable();
        private DataTable dtbs = new DataTable();
        private DataTable dtdt = new DataTable();
        private DataTable dtvpin = new DataTable();
        private DataTable dtbd = new DataTable();
        private DataTable dtdtf = new DataTable();
        private DataTable dtnv = new DataTable();
        public bool bOk = false, bHoadon, bGiaban = false, bDuyetError = false;
		public int sobienlai,i_bhyt_inrieng;
		private numbertotext doiso=new numbertotext();
        private System.Windows.Forms.TextBox tim;
		private System.Windows.Forms.DataGrid dataGrid2;
		private System.Windows.Forms.TextBox tim2;
        private System.Windows.Forms.Button butIn;
        private FileStream fstr;
        private byte[] image,imageuser;
        private CheckBox chkXML;
        private CheckBox chkXem;
        private Button butList;
        private Label label1;
        private NumericUpDown soban;
        private Button butAll;
        private ToolTip toolTip1;
        private IContainer components;
        private decimal Bhyt_7cn;
        private bool bchenhlech_thuoc, bGia_bh_quydinh, bChenhlech_thuoc_dannhmuc;
        private Button button1;
        private Button btHuy38;
        private bool bAutoLoad = true;
        protected PictureBox pic;
        private Button butdaduyet_chuthu;
        private NumericUpDown numNgayduyettoa;
        private Label label2;
        private Label label3;
        private Label label4;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Button butKetthucDS;
        private Button butInds;
        private DataGridView dataGridView1;
        private Label label5;
        private Label lblTu;
        private TextBox txttim;
        private DateTimePicker txtDen;
        private DateTimePicker txtTu;
        private Button button2;
        private DataGridViewTextBoxColumn c_id;
        private DataGridViewTextBoxColumn c_ngay;
        private DataGridViewTextBoxColumn c_mabn;
        private DataGridViewTextBoxColumn c_Hoten;
        private DataGridViewTextBoxColumn c_phai;
        private DataGridViewTextBoxColumn c_namsinh;
        private DataGridViewTextBoxColumn c_tenkt;
        private DataGridViewTextBoxColumn c_khoa;
        private DataGridViewTextBoxColumn c_nhanvien;
        private Label label6;
        private DateTimePicker txtNgayThuchien;
        private bool bDsdaduyet = false;
        

        public frmXacnhan_Thuchien_dmkt(string _makp,string _mabs, int userid, string ngay, bool admin)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            s_makp = _makp;
           i_userid = userid;
            s_ngay = ngay;  bAdmin = admin;
            s_mabs = _mabs;

            
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);            
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
					if(disabledBackBrush != null)
					{
						disabledBackBrush.Dispose();
						disabledTextBrush.Dispose();
						alertBackBrush.Dispose();
						alertFont.Dispose();
						alertTextBrush.Dispose();
						currentRowFont.Dispose();
						currentRowBackBrush.Dispose();
						RowBackBrushVP.Dispose();
						alertFont2.Dispose();
						currentRowFont2.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmXacnhan_Thuchien_dmkt));
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.tim = new System.Windows.Forms.TextBox();
            this.dataGrid2 = new System.Windows.Forms.DataGrid();
            this.tim2 = new System.Windows.Forms.TextBox();
            this.chkXML = new System.Windows.Forms.CheckBox();
            this.chkXem = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.soban = new System.Windows.Forms.NumericUpDown();
            this.butAll = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pic = new System.Windows.Forms.PictureBox();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.butList = new System.Windows.Forms.Button();
            this.butIn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btHuy38 = new System.Windows.Forms.Button();
            this.butdaduyet_chuthu = new System.Windows.Forms.Button();
            this.numNgayduyettoa = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNgayThuchien = new System.Windows.Forms.DateTimePicker();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTu = new System.Windows.Forms.Label();
            this.txttim = new System.Windows.Forms.TextBox();
            this.txtDen = new System.Windows.Forms.DateTimePicker();
            this.txtTu = new System.Windows.Forms.DateTimePicker();
            this.butKetthucDS = new System.Windows.Forms.Button();
            this.butInds = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.c_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_ngay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_mabn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_Hoten = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_phai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_namsinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_tenkt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_khoa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_nhanvien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.soban)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNgayduyettoa)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGrid1
            // 
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGrid1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid1.CaptionBackColor = System.Drawing.SystemColors.Control;
            this.dataGrid1.DataMember = "";
            this.dataGrid1.FlatMode = true;
            this.dataGrid1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(6, -11);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.RowHeaderWidth = 3;
            this.dataGrid1.Size = new System.Drawing.Size(361, 373);
            this.dataGrid1.TabIndex = 0;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            this.dataGrid1.Click += new System.EventHandler(this.dataGrid1_Click);
            // 
            // tim
            // 
            this.tim.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tim.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tim.Location = new System.Drawing.Point(145, 368);
            this.tim.Name = "tim";
            this.tim.Size = new System.Drawing.Size(222, 21);
            this.tim.TabIndex = 3;
            this.tim.Text = "Tìm kiếm";
            this.tim.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tim.TextChanged += new System.EventHandler(this.tim_TextChanged);
            this.tim.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tim_KeyDown);
            this.tim.Enter += new System.EventHandler(this.tim_Enter);
            // 
            // dataGrid2
            // 
            this.dataGrid2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid2.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGrid2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid2.CaptionBackColor = System.Drawing.SystemColors.Control;
            this.dataGrid2.DataMember = "";
            this.dataGrid2.FlatMode = true;
            this.dataGrid2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid2.Location = new System.Drawing.Point(373, -11);
            this.dataGrid2.Name = "dataGrid2";
            this.dataGrid2.RowHeaderWidth = 3;
            this.dataGrid2.Size = new System.Drawing.Size(405, 370);
            this.dataGrid2.TabIndex = 1;
            this.dataGrid2.CurrentCellChanged += new System.EventHandler(this.dataGrid2_CurrentCellChanged);
            this.dataGrid2.Click += new System.EventHandler(this.dataGrid2_Click);
            // 
            // tim2
            // 
            this.tim2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tim2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tim2.Location = new System.Drawing.Point(373, 368);
            this.tim2.Name = "tim2";
            this.tim2.Size = new System.Drawing.Size(414, 21);
            this.tim2.TabIndex = 5;
            this.tim2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tim2.TextChanged += new System.EventHandler(this.tim2_TextChanged);
            this.tim2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tim_KeyDown);
            // 
            // chkXML
            // 
            this.chkXML.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkXML.AutoSize = true;
            this.chkXML.Enabled = false;
            this.chkXML.Location = new System.Drawing.Point(145, 480);
            this.chkXML.Name = "chkXML";
            this.chkXML.Size = new System.Drawing.Size(73, 17);
            this.chkXML.TabIndex = 237;
            this.chkXML.Text = "Xuất XML";
            this.chkXML.UseVisualStyleBackColor = true;
            this.chkXML.Visible = false;
            // 
            // chkXem
            // 
            this.chkXem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkXem.AutoSize = true;
            this.chkXem.Enabled = false;
            this.chkXem.Location = new System.Drawing.Point(44, 480);
            this.chkXem.Name = "chkXem";
            this.chkXem.Size = new System.Drawing.Size(102, 17);
            this.chkXem.TabIndex = 238;
            this.chkXem.Text = "Xem trước khi in";
            this.chkXem.UseVisualStyleBackColor = true;
            this.chkXem.Visible = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(676, 435);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 243;
            this.label1.Text = "Số bản in :";
            this.label1.Visible = false;
            // 
            // soban
            // 
            this.soban.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.soban.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.soban.Location = new System.Drawing.Point(733, 431);
            this.soban.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.soban.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.soban.Name = "soban";
            this.soban.Size = new System.Drawing.Size(38, 21);
            this.soban.TabIndex = 244;
            this.soban.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.soban.Visible = false;
            // 
            // butAll
            // 
            this.butAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butAll.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butAll.Location = new System.Drawing.Point(373, 367);
            this.butAll.Name = "butAll";
            this.butAll.Size = new System.Drawing.Size(24, 22);
            this.butAll.TabIndex = 4;
            this.butAll.Text = "...";
            this.toolTip1.SetToolTip(this.butAll, "Chọn tất cả");
            this.butAll.UseVisualStyleBackColor = true;
            this.butAll.Visible = false;
            this.butAll.Click += new System.EventHandler(this.butAll_Click);
            // 
            // pic
            // 
            this.pic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pic.BackColor = System.Drawing.SystemColors.Desktop;
            this.pic.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pic.Image = ((System.Drawing.Image)(resources.GetObject("pic.Image")));
            this.pic.InitialImage = ((System.Drawing.Image)(resources.GetObject("pic.InitialImage")));
            this.pic.Location = new System.Drawing.Point(-6, 396);
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(81, 65);
            this.pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic.TabIndex = 308;
            this.pic.TabStop = false;
            this.toolTip1.SetToolTip(this.pic, "DoubleClick phóng to hình");
            this.pic.Visible = false;
            this.pic.DoubleClick += new System.EventHandler(this.pic_DoubleClick);
            // 
            // butBoqua
            // 
            this.butBoqua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butBoqua.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(582, 429);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(86, 25);
            this.butBoqua.TabIndex = 8;
            this.butBoqua.Text = "&Kết thúc";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butLuu
            // 
            this.butLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butLuu.Enabled = false;
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(161, 429);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(86, 25);
            this.butLuu.TabIndex = 7;
            this.butLuu.Text = "      &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butList
            // 
            this.butList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butList.Image = ((System.Drawing.Image)(resources.GetObject("butList.Image")));
            this.butList.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butList.Location = new System.Drawing.Point(333, 429);
            this.butList.Name = "butList";
            this.butList.Size = new System.Drawing.Size(125, 25);
            this.butList.TabIndex = 9;
            this.butList.Text = "DS &Chưa thực hiện";
            this.butList.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butList.Click += new System.EventHandler(this.butList_Click);
            // 
            // butIn
            // 
            this.butIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butIn.Enabled = false;
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(93, 398);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(72, 25);
            this.butIn.TabIndex = 6;
            this.butIn.Text = "&In";
            this.butIn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butIn.Visible = false;
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(458, 429);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 25);
            this.button1.TabIndex = 249;
            this.button1.Text = "DS &Đã thực hiện";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btHuy38
            // 
            this.btHuy38.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btHuy38.Enabled = false;
            this.btHuy38.Image = ((System.Drawing.Image)(resources.GetObject("btHuy38.Image")));
            this.btHuy38.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btHuy38.Location = new System.Drawing.Point(247, 429);
            this.btHuy38.Name = "btHuy38";
            this.btHuy38.Size = new System.Drawing.Size(86, 25);
            this.btHuy38.TabIndex = 250;
            this.btHuy38.Text = "&Hủy";
            this.btHuy38.Click += new System.EventHandler(this.btHuy38_Click);
            // 
            // butdaduyet_chuthu
            // 
            this.butdaduyet_chuthu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butdaduyet_chuthu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butdaduyet_chuthu.Location = new System.Drawing.Point(93, 422);
            this.butdaduyet_chuthu.Name = "butdaduyet_chuthu";
            this.butdaduyet_chuthu.Size = new System.Drawing.Size(118, 25);
            this.butdaduyet_chuthu.TabIndex = 309;
            this.butdaduyet_chuthu.Text = "&Đã duyệt+chưa thu";
            this.butdaduyet_chuthu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butdaduyet_chuthu.Visible = false;
            this.butdaduyet_chuthu.Click += new System.EventHandler(this.button2_Click);
            // 
            // numNgayduyettoa
            // 
            this.numNgayduyettoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.numNgayduyettoa.Location = new System.Drawing.Point(740, 392);
            this.numNgayduyettoa.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numNgayduyettoa.Name = "numNgayduyettoa";
            this.numNgayduyettoa.Size = new System.Drawing.Size(46, 20);
            this.numNgayduyettoa.TabIndex = 310;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(602, 396);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 13);
            this.label2.TabIndex = 311;
            this.label2.Text = "Khoảng cách ngày duyệt :";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(222, 394);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 312;
            this.label3.Text = "TỔNG TIỀN :";
            this.label3.Visible = false;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(291, 394);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 13);
            this.label4.TabIndex = 313;
            this.label4.Text = "0";
            this.label4.Visible = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(3, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(792, 503);
            this.tabControl1.TabIndex = 314;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.txtNgayThuchien);
            this.tabPage1.Controls.Add(this.dataGrid1);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.dataGrid2);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.butBoqua);
            this.tabPage1.Controls.Add(this.numNgayduyettoa);
            this.tabPage1.Controls.Add(this.tim);
            this.tabPage1.Controls.Add(this.butdaduyet_chuthu);
            this.tabPage1.Controls.Add(this.tim2);
            this.tabPage1.Controls.Add(this.pic);
            this.tabPage1.Controls.Add(this.butIn);
            this.tabPage1.Controls.Add(this.btHuy38);
            this.tabPage1.Controls.Add(this.chkXem);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.chkXML);
            this.tabPage1.Controls.Add(this.butLuu);
            this.tabPage1.Controls.Add(this.butList);
            this.tabPage1.Controls.Add(this.butAll);
            this.tabPage1.Controls.Add(this.soban);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(784, 477);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Xác nhận thực hiện";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label6.Location = new System.Drawing.Point(10, 373);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 315;
            this.label6.Text = "Ngày";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // txtNgayThuchien
            // 
            this.txtNgayThuchien.CustomFormat = "dd/MM/yyyy";
            this.txtNgayThuchien.Enabled = false;
            this.txtNgayThuchien.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtNgayThuchien.Location = new System.Drawing.Point(46, 370);
            this.txtNgayThuchien.Name = "txtNgayThuchien";
            this.txtNgayThuchien.Size = new System.Drawing.Size(95, 20);
            this.txtNgayThuchien.TabIndex = 314;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.lblTu);
            this.tabPage2.Controls.Add(this.txttim);
            this.tabPage2.Controls.Add(this.txtDen);
            this.tabPage2.Controls.Add(this.txtTu);
            this.tabPage2.Controls.Add(this.butKetthucDS);
            this.tabPage2.Controls.Add(this.butInds);
            this.tabPage2.Controls.Add(this.dataGridView1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(784, 477);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "DS Đã thực hiện";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(242, 434);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(76, 27);
            this.button2.TabIndex = 16;
            this.button2.Text = "&Xem";
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(213, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Đến ngày ";
            // 
            // lblTu
            // 
            this.lblTu.AutoSize = true;
            this.lblTu.Location = new System.Drawing.Point(18, 14);
            this.lblTu.Name = "lblTu";
            this.lblTu.Size = new System.Drawing.Size(49, 13);
            this.lblTu.TabIndex = 14;
            this.lblTu.Text = "Từ ngày ";
            // 
            // txttim
            // 
            this.txttim.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txttim.Location = new System.Drawing.Point(375, 11);
            this.txttim.Name = "txttim";
            this.txttim.Size = new System.Drawing.Size(401, 20);
            this.txttim.TabIndex = 13;
            this.txttim.Text = "Tìm kiếm";
            this.txttim.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtDen
            // 
            this.txtDen.CustomFormat = "dd/MM/yyyy";
            this.txtDen.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtDen.Location = new System.Drawing.Point(271, 10);
            this.txtDen.Name = "txtDen";
            this.txtDen.Size = new System.Drawing.Size(96, 20);
            this.txtDen.TabIndex = 12;
            // 
            // txtTu
            // 
            this.txtTu.CustomFormat = "dd/MM/yyyy";
            this.txtTu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtTu.Location = new System.Drawing.Point(101, 10);
            this.txtTu.Name = "txtTu";
            this.txtTu.Size = new System.Drawing.Size(96, 20);
            this.txtTu.TabIndex = 11;
            // 
            // butKetthucDS
            // 
            this.butKetthucDS.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.butKetthucDS.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butKetthucDS.Image = ((System.Drawing.Image)(resources.GetObject("butKetthucDS.Image")));
            this.butKetthucDS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthucDS.Location = new System.Drawing.Point(394, 434);
            this.butKetthucDS.Name = "butKetthucDS";
            this.butKetthucDS.Size = new System.Drawing.Size(90, 27);
            this.butKetthucDS.TabIndex = 10;
            this.butKetthucDS.Text = "&Kết thúc";
            this.butKetthucDS.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthucDS.Click += new System.EventHandler(this.butKetthucDS_Click);
            // 
            // butInds
            // 
            this.butInds.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.butInds.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butInds.Location = new System.Drawing.Point(318, 434);
            this.butInds.Name = "butInds";
            this.butInds.Size = new System.Drawing.Size(76, 27);
            this.butInds.TabIndex = 9;
            this.butInds.Text = "&In";
            this.butInds.Click += new System.EventHandler(this.butInds_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.c_id,
            this.c_ngay,
            this.c_mabn,
            this.c_Hoten,
            this.c_phai,
            this.c_namsinh,
            this.c_tenkt,
            this.c_khoa,
            this.c_nhanvien});
            this.dataGridView1.Location = new System.Drawing.Point(4, 36);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(775, 386);
            this.dataGridView1.TabIndex = 0;
            // 
            // c_id
            // 
            this.c_id.DataPropertyName = "id";
            this.c_id.HeaderText = "ID";
            this.c_id.Name = "c_id";
            this.c_id.Visible = false;
            // 
            // c_ngay
            // 
            this.c_ngay.DataPropertyName = "ngay";
            this.c_ngay.HeaderText = "Ngày";
            this.c_ngay.Name = "c_ngay";
            this.c_ngay.Width = 80;
            // 
            // c_mabn
            // 
            this.c_mabn.DataPropertyName = "mabn";
            this.c_mabn.HeaderText = "MSBN";
            this.c_mabn.Name = "c_mabn";
            this.c_mabn.Width = 70;
            // 
            // c_Hoten
            // 
            this.c_Hoten.DataPropertyName = "hoten";
            this.c_Hoten.HeaderText = "Họ tên";
            this.c_Hoten.Name = "c_Hoten";
            this.c_Hoten.Width = 160;
            // 
            // c_phai
            // 
            this.c_phai.DataPropertyName = "gioitinh";
            this.c_phai.HeaderText = "Phái";
            this.c_phai.Name = "c_phai";
            this.c_phai.Width = 60;
            // 
            // c_namsinh
            // 
            this.c_namsinh.DataPropertyName = "namsinh";
            this.c_namsinh.HeaderText = "N.Sinh";
            this.c_namsinh.Name = "c_namsinh";
            this.c_namsinh.Width = 60;
            // 
            // c_tenkt
            // 
            this.c_tenkt.DataPropertyName = "tenkythuat";
            this.c_tenkt.HeaderText = "Tên kỹ thuật";
            this.c_tenkt.Name = "c_tenkt";
            this.c_tenkt.Width = 200;
            // 
            // c_khoa
            // 
            this.c_khoa.DataPropertyName = "tenkp";
            this.c_khoa.HeaderText = "Khoa-Phòng";
            this.c_khoa.Name = "c_khoa";
            this.c_khoa.Width = 120;
            // 
            // c_nhanvien
            // 
            this.c_nhanvien.DataPropertyName = "tenbs";
            this.c_nhanvien.HeaderText = "Nhân viên";
            this.c_nhanvien.Name = "c_nhanvien";
            this.c_nhanvien.Width = 120;
            // 
            // frmXacnhan_Thuchien_dmkt
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.butBoqua;
            this.ClientSize = new System.Drawing.Size(798, 505);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(0, 38);
            this.Name = "frmXacnhan_Thuchien_dmkt";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Xác nhận thực hiện dịch vụ kỹ thuật";
            this.Load += new System.EventHandler(this.frmDuyetbhyt_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmDuyetbhyt_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.soban)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNgayduyettoa)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void frmDuyetbhyt_Load(object sender, System.EventArgs e)
		{
            user = m.user; 
            //
            s_idcomputer = m.get_dmcomputer(System.Environment.MachineName).ToString().PadLeft(4, '0');            
            bDsdaduyet = false;
            btHuy38.Enabled = false;
            dataGridView1.AutoGenerateColumns = false;
            
            int ikhoangcachngaycaptoa = m.iKhoangcachngaycaptoa_voingaykham;//tuy chon nay chon ben medisoft
            songayduyet = m.iNgaykiemke;
            try
            {
                numNgayduyettoa.Value = songayduyet;
            }
            catch { numNgayduyettoa.Value = 7; }
            //
            s_tu = m.DateToString("dd/MM/yyyy", m.StringToDate(s_ngay).AddDays(-1 * songayduyet));
            s_den = s_ngay;stime = "'dd/mm/yyyy'";
            DateTime dtngay = m.StringToDate(s_ngay);
            txtNgayThuchien.Value = dtngay;
            txtTu.Value = dtngay;
            txtDen.Value = dtngay;

            //
            s_loavp_thuchien = f_get_loavp(s_makp);
            s_loaivp_cdha = f_get_loavp_cdha_xn();
            s_mavp_kham = m.f_get_mavp_congkham();

            _madoituong = i_madoituong;
            			
			this.disabledBackBrush = new SolidBrush(Color.FromArgb(255,255,192));
			this.disabledTextBrush = new SolidBrush(Color.FromArgb(255,0,0));

			this.alertBackBrush = new SolidBrush(SystemColors.HotTrack);
			this.alertFont = new Font(this.dataGrid1.Font.Name, this.dataGrid1.Font.Size, FontStyle.Bold);
			this.alertTextBrush = new SolidBrush(Color.White);
			this.alertFont2 = new Font(this.dataGrid2.Font.Name, this.dataGrid2.Font.Size, FontStyle.Bold);
			this.currentRowFont2 = new Font(this.dataGrid2.Font.Name, this.dataGrid2.Font.Size, FontStyle.Regular);

			this.currentRowFont = new Font(this.dataGrid1.Font.Name, this.dataGrid1.Font.Size, FontStyle.Regular);
			this.currentRowBackBrush = new SolidBrush(Color.FromArgb(0,255, 255));
			this.RowBackBrushVP = new SolidBrush(Color.Blue);

            //ds1.ReadXml("..\\..\\..\\xml\\m_inravien.xml");
            //dsxmlin.ReadXml("..\\..\\..\\xml\\m_inravien.xml");
            //dsxmlin.Tables[0].Columns.Add("Image", typeof(byte[]));
            //dsxmlin.Tables[0].Columns.Add("Imagetk", typeof(byte[]));
            //dsxmlin.Tables[0].Columns.Add("Imageuser", typeof(byte[]));
            //dsxmlin.Tables[0].Columns.Add("mabs");
            //dsxmlin.Tables[0].Columns.Add("tenbs");
            //dsxmlin.Tables[0].Columns.Add("makprv");
            //dsxmlin.Tables[0].Columns.Add("tenuser");
            //dsxmlin.Tables[0].Columns.Add("cholam");
            //dsxmlin.Tables[0].Columns.Add("madt", typeof(decimal));
            //dsxmlin.Tables[0].Columns.Add("haophi", typeof(decimal));
            //dsxmlin.Tables[0].Columns.Add("gianovat", typeof(decimal));
            //dsxmlin.Tables[0].Columns.Add("idttrv", typeof(decimal));
            //dsxmlin.Tables[0].Columns.Add("sotientra", typeof(decimal));
            //dsxmlin.Tables[0].Columns.Add("traituyen", typeof(decimal));           
            //dsxmlin.Tables[0].Columns.Add("kythuat", typeof(decimal));
            //dsxmlin.Tables[0].Columns.Add("loaikythuat", typeof(string));

            //dsxmlin.Tables[0].Columns.Add("sttbhyt", typeof(decimal)).DefaultValue = 0;
            //dsxmlin.Tables[0].Columns.Add("idnhombhyt", typeof(decimal)).DefaultValue = 0;
            //dsxmlin.Tables[0].Columns.Add("tennhombhyt", typeof(string));

			ds.ReadXml("..\\..\\..\\xml\\d_duyetbhyt.xml");
			dataGrid2.DataSource=ds.Tables[0];
			AddGridTableStyle2();
            //lan.Read_dtgrid2002_to_Xml(dataGrid2, this.Name + "_dataGrid2");
            //lan.Change_dtgrid2002_HeaderText_to_English(dataGrid2, this.Name + "_dataGrid2");
			CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid2.DataSource,dataGrid1.DataMember]; 
			DataView dv = (DataView) cm.List; 
			dv.AllowNew = false; 
			ds.Tables[0].Columns.Add("Chon",typeof(bool));
            ds.Tables[0].Columns.Add("done", typeof(decimal));
            ds.Tables[0].Columns.Add("mabn");
            ds.Tables[0].Columns.Add("ngay");
            ds.Tables[0].Columns.Add("ngayud");            
            if (bAutoLoad) load_grid("", 0, l_iddoan );//linh 251011                        
		}

		private void AddGridTableStyle2()
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
			ts.RowHeaderWidth=3;
			ts.AllowSorting=false;

			FormattableBooleanColumn discontinuedCol = new FormattableBooleanColumn();
			discontinuedCol.MappingName = "ctytra";
			discontinuedCol.HeaderText = "Chọn";
			discontinuedCol.Width = 35;
			discontinuedCol.AllowNull = false;

			discontinuedCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat2);
			discontinuedCol.BoolValueChanged += new BoolValueChangedEventHandler(BoolValueChanged2);
			ts.GridColumnStyles.Add(discontinuedCol);
			dataGrid2.TableStyles.Add(ts);

			FormattableTextBoxColumn TextCol = new FormattableTextBoxColumn();
			TextCol.MappingName = "hoten";
			TextCol.HeaderText = "Họ tên";
			TextCol.Width =125;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat2);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts);

			TextCol = new FormattableTextBoxColumn();
			TextCol.MappingName = "ten";
			TextCol.HeaderText = "Tên Kỹ thuật";
			TextCol.Width =200;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat2);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts);

            TextCol = new FormattableTextBoxColumn();
            TextCol.MappingName = "dang";
            TextCol.HeaderText = "ĐVT";
            TextCol.Width = 25;
            TextCol.ReadOnly = true;
            TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat2);
            ts.GridColumnStyles.Add(TextCol);
            dataGrid2.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "soluong";
			TextCol.HeaderText = "Số lượng";
			TextCol.Width = 50;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat2);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "makho";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat2);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts);

            TextCol = new FormattableTextBoxColumn();
            TextCol.MappingName = "done";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            TextCol.ReadOnly = true;
            TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat2);
            ts.GridColumnStyles.Add(TextCol);
            dataGrid2.TableStyles.Add(ts);

            TextCol = new FormattableTextBoxColumn();
            TextCol.MappingName = "dongia";
            TextCol.HeaderText = "Giá";
            TextCol.Width = 50;
            TextCol.ReadOnly = true;
            TextCol.Format = "### ### ###";
            TextCol.Alignment = HorizontalAlignment.Right;
            TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat2);
            ts.GridColumnStyles.Add(TextCol);
            dataGrid2.TableStyles.Add(ts);

            FormattableBooleanColumn discontinuedCol1 = new FormattableBooleanColumn();
            discontinuedCol1.MappingName = "chon";
            discontinuedCol1.HeaderText = "Bỏ";
            discontinuedCol1.Width = 20;
            discontinuedCol1.AllowNull = false;

            discontinuedCol1.SetCellFormat += new FormatCellEventHandler(SetCellFormat3);
            discontinuedCol1.BoolValueChanged += new BoolValueChangedEventHandler(BoolValueChanged2);
            ts.GridColumnStyles.Add(discontinuedCol1);
            dataGrid2.TableStyles.Add(ts);
		}

		private void AddGridTableStyle()
		{
			DataGridTableStyle ts =new DataGridTableStyle();
			ts.MappingName = dt.TableName;
			ts.AlternatingBackColor = Color.Beige;
			ts.BackColor = Color.GhostWhite;
			ts.ForeColor = Color.MidnightBlue;
			ts.GridLineColor = Color.RoyalBlue;
			ts.HeaderBackColor = Color.MidnightBlue;
			ts.HeaderForeColor = Color.Lavender;
			ts.SelectionBackColor = Color.FromArgb(0,255,255);
			ts.SelectionForeColor = Color.PaleGreen;
			ts.RowHeaderWidth=3;
			ts.AllowSorting=false;

			FormattableBooleanColumn discontinuedCol = new FormattableBooleanColumn();
			discontinuedCol.MappingName = "chon";
			discontinuedCol.HeaderText = "Chọn";
			discontinuedCol.Width = 30;
			discontinuedCol.AllowNull = false;

			discontinuedCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			discontinuedCol.BoolValueChanged += new BoolValueChangedEventHandler(BoolValueChanged);
			ts.GridColumnStyles.Add(discontinuedCol);
			dataGrid1.TableStyles.Add(ts);

			FormattableTextBoxColumn TextCol = new FormattableTextBoxColumn();
			TextCol.MappingName = "mabn";//1
			TextCol.HeaderText = "Mã BN";
			TextCol.Width =70;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);
			

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "hoten";//2
			TextCol.HeaderText = "Họ tên";
			TextCol.Width = 120;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new FormattableTextBoxColumn();
			TextCol.MappingName = "makp";//3
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			TextCol.ReadOnly=true;
			TextCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);


            TextCol = new FormattableTextBoxColumn();
            TextCol.MappingName = "maql";//4
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            
            TextCol = new FormattableTextBoxColumn();
            TextCol.MappingName = "mavaovien";//5
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);
           
            TextCol = new FormattableTextBoxColumn();
            TextCol.MappingName = "ngaycaptoa";//6
            TextCol.HeaderText = "Ngày";
            TextCol.Width = 68;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new FormattableTextBoxColumn();
            TextCol.MappingName = "sotien";//7
            TextCol.HeaderText = "Số tiền";
            TextCol.Width = 60;
            TextCol.Format = "### ### ###";
            TextCol.Alignment = HorizontalAlignment.Right;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

		}
	
		private void SetCellFormat(object sender, DataGridFormatCellEventArgs e)
		{
			try
			{
				bool discontinued = (bool) ((e.Column != 0) ? this.dataGrid1[e.Row, 0] : e.CurrentCellValue);
				if(e.Column > 0 && (bool)(this.dataGrid1[e.Row, 0]))//discontinued)
					e.ForeBrush = this.disabledTextBrush;
				else if(e.Column > 0 && e.Row == this.dataGrid1.CurrentRowIndex)//discontinued)
				{
					e.BackBrush = this.currentRowBackBrush;
					e.TextFont = this.currentRowFont;
				}
			}
			catch{}
		}

		private void SetCellFormat2(object sender, DataGridFormatCellEventArgs e)
		{
			try
			{
				bool discontinued = (bool) ((e.Column != 0) ? this.dataGrid2[e.Row, 0] : e.CurrentCellValue);
                if (e.Column > 0 && (bool)(this.dataGrid2[e.Row, 0])) e.ForeBrush = this.disabledTextBrush;
                else if (e.Column > 0 && this.dataGrid2[e.Row, 4].ToString() == "0") e.ForeBrush = this.RowBackBrushVP;                
                else if (e.Column > 0 && e.Row == this.dataGrid2.CurrentRowIndex)
                {
                    e.BackBrush = this.currentRowBackBrush;
                    e.TextFont = this.currentRowFont2;
                }

			}
			catch{}
		}

        private void SetCellFormat3(object sender, DataGridFormatCellEventArgs e)
        {
            try
            {
                bool discontinued = (bool)((e.Column != 0) ? this.dataGrid2[e.Row, 8] : e.CurrentCellValue);
                if (e.Column > 0 && (bool)(this.dataGrid2[e.Row, 8])) e.ForeBrush = this.disabledTextBrush;
                else if (e.Column > 0 && this.dataGrid2[e.Row, 4].ToString() == "0") e.ForeBrush = this.RowBackBrushVP;
                else if (e.Column > 0 && e.Row == this.dataGrid2.CurrentRowIndex)
                {
                    e.BackBrush = this.currentRowBackBrush;
                    e.TextFont = this.currentRowFont2;
                }

            }
            catch { }
        }

		private void BoolValueChanged(object sender, BoolValueChangedEventArgs e)
		{
			this.dataGrid1.EndEdit(this.dataGrid1.TableStyles[0].GridColumnStyles["Discontinued"],e.Row, false);
			RefreshRow(e.Row);
			this.dataGrid1.BeginEdit(this.dataGrid1.TableStyles[0].GridColumnStyles["Discontinued"],e.Row);
		}

		private void RefreshRow(int row)
		{
			Rectangle rect = this.dataGrid1.GetCellBounds(row,0);
			rect = new Rectangle(rect.Right, rect.Top, this.dataGrid1.Width, rect.Height);
			this.dataGrid1.Invalidate(rect);
		}


		private void BoolValueChanged2(object sender, BoolValueChangedEventArgs e)
		{
			this.dataGrid2.EndEdit(this.dataGrid2.TableStyles[0].GridColumnStyles["Discontinued"],e.Row, false);
			RefreshRow2(e.Row);
			this.dataGrid2.BeginEdit(this.dataGrid2.TableStyles[0].GridColumnStyles["Discontinued"],e.Row);
		}

       
		private void RefreshRow2(int row)
		{
			Rectangle rect = this.dataGrid2.GetCellBounds(row,0);
			rect = new Rectangle(rect.Right, rect.Top, this.dataGrid2.Width, rect.Height);
			this.dataGrid2.Invalidate(rect);
		}

		private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			if((bool)this.dataGrid1[this.dataGrid1.CurrentRowIndex, checkCol]) this.dataGrid1.CurrentCell = new DataGridCell(this.dataGrid1.CurrentRowIndex, checkCol);
			afterCurrentCellChanged = true;
			i_row=dataGrid1.CurrentRowIndex;
            //
            
            //
            s_mabn = dataGrid1[i_row, 1].ToString();
            s_hoten = dataGrid1[i_row, 2].ToString();
            //f_load_hinh();
            try
            {
                int i_row_index = dataGrid1.CurrentRowIndex;
                setFalse();
                dataGrid1[i_row_index, 0] = !(bool)dataGrid1[i_row_index, 0];
                //
                l_id = decimal.Parse(dataGrid1[i_row_index, 4].ToString());
                l_maql = decimal.Parse(dataGrid1[i_row_index, 4].ToString()); // gam 29-04-2011???
                l_mavaovien = decimal.Parse(dataGrid1[i_row_index, 5].ToString());
                s_mabn = dataGrid1[i_row_index, 1].ToString();
                s_mabs = "";
                if (dataGrid1[i_row_index, 0].ToString().Trim() == "True")
                {
                    ds = load_dtct(bDsdaduyet ? 2 : 0);
                    ds.Tables[0].Columns.Add("chon", typeof(bool));
                    ds.Tables[0].Columns.Add("ctytra", typeof(bool));
                    foreach (DataRow r in ds.Tables[0].Rows)
                    {
                        r["chon"] = false;
                        r["ctytra"] = false;
                    }
                    ds.AcceptChanges();
                    dataGrid2.DataSource = ds.Tables[0];
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, d.Msg);
            }
		}

		private void dataGrid1_Click(object sender, System.EventArgs e)
		{
            try
            {
               
                Point pt = this.dataGrid1.PointToClient(Control.MousePosition);
                DataGrid.HitTestInfo hti = this.dataGrid1.HitTest(pt);
                BindingManagerBase bmb = this.BindingContext[this.dataGrid1.DataSource, this.dataGrid1.DataMember];
                if (afterCurrentCellChanged && hti.Row < bmb.Count && hti.Type == DataGrid.HitTestType.Cell && hti.Column == checkCol)
                {
                    this.dataGrid1[hti.Row, checkCol] = !(bool)this.dataGrid1[hti.Row, checkCol];
                    RefreshRow(hti.Row);
                }
                afterCurrentCellChanged = false;
                //
                string atam = dataGrid1[i_row, 4].ToString()+",";
                
                l_id = decimal.Parse(dataGrid1[i_row, 4].ToString());
                l_maql = decimal.Parse(dataGrid1[i_row, 4].ToString()); // gam 29-04-2011???
                //_madoituong = 8;
                l_mavaovien = decimal.Parse(dataGrid1[i_row, 5].ToString());
                s_makp = dataGrid1[i_row, 3].ToString();
                s_mabn = dataGrid1[i_row, 1].ToString();
                s_mabs = "";                
                if (dataGrid1[i_row, 0].ToString().Trim() == "True")
                {
                    ds = load_dtct(bDsdaduyet ? 2 : 0);
                    ds.Tables[0].Columns.Add("chon", typeof(bool));
                    ds.Tables[0].Columns.Add("ctytra", typeof(bool));
                    foreach (DataRow r in ds.Tables[0].Rows)
                    {
                        r["chon"]=false;
                        r["ctytra"] = false;
                    }
                    ds.AcceptChanges();
                    dataGrid2.DataSource = ds.Tables[0];
                }
            }
            catch { }
		}

		private void load_grid(string mabn,int i_loai, decimal v_iddoan)
		{
            //i_loai=0: chua duyet
            //i_loai=1: da duyet                    
            //           
            sql = "select a.mabn,a.maql,a.mavaovien,";
            sql += " b.hoten,b.namsinh,";//trim(b.sonha)||' '||b.thon as diachi,b.cholam,x.tentt,y.tenquan,z.tenpxa,";
            sql += " a.makp, to_char(a.ngay,'dd/mm/yyyy') as ngaycaptoa ";
            sql += " , sum(a.soluong*a.dongia) as sotien ";
            sql += " from xxx.v_chidinh a inner join " + user + ".btdbn b on a.mabn=b.mabn ";            
            sql += " left join " + user + ".btdkp_bv e on a.makp=e.makp ";           
            sql += " inner join " + user + ".doituong f on a.madoituong=f.madoituong";            
            sql += " left join " + user + ".btdtt x on b.matt=x.matt ";
            sql += " left join " + user + ".btdquan y on b.maqu=y.maqu ";
            sql += " left join " + user + ".btdpxa z on b.maphuongxa=z.maphuongxa ";
            sql += " inner join " + user + ".v_giavp u on a.mavp=u.id ";
            sql += " inner join " + user + ".v_loaivp v on u.id_loai=v.id ";            
            sql += " where a.hide=0 ";
            sql += " and a.done= " + i_loai;
            if (s_tu == s_den) sql += " and to_char(a.ngay,'dd/mm/yyyy')='" + s_tu + "'";
            else sql += " and " + m.for_ngay("a.ngay", stime) + " between to_date('" + s_tu + "','dd/mm/yyyy') and to_date('" + s_den + "','dd/mm/yyyy')";            	            
            if (mabn != "") sql += " and a.mabn like '%" + mabn + "%'";
            if (s_loavp_thuchien.Trim().Trim(',') != "") sql += " and v.id in(" + s_loavp_thuchien.Trim().Trim(',') + ")";
            if (s_loaivp_cdha.Trim().Trim(',') != "") sql += " and v.id not in(" + s_loaivp_cdha.Trim().Trim(',') + ")";
            if (s_mavp_kham.Trim().Trim(',') != "") sql += " and a.mavp not in(" + s_mavp_kham.Trim().Trim(',') + ")";
            sql += " group by a.mabn, a.maql, a.mavaovien, b.hoten, b.namsinh, to_char(a.ngay,'dd/mm/yyyy'), a.makp ";
			dt=m.get_data_mmyy(sql,s_tu,s_den,songayduyet).Tables[0];            
                        
            dt.AcceptChanges();
			dataGrid1.DataSource=dt;
            if (!bSkip)
            {
                AddGridTableStyle();
                //lan.Read_dtgrid2002_to_Xml(dataGrid1, this.Name + "_dataGrid1");
                //lan.Change_dtgrid2002_HeaderText_to_English(dataGrid1, this.Name + "_dataGrid1");
            }
			bSkip=true;
			CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource,dataGrid1.DataMember]; 
			DataView dv = (DataView) cm.List; 
			dv.AllowNew = false; 
			dt.Columns.Add("Chon",typeof(bool));
            foreach (DataRow row in dt.Rows)
            {
                row["chon"] = false;
            }
            decimal d_tongtien = 0;
            f_get_tongtien(ref d_tongtien);
            label4.Text = d_tongtien.ToString("### ### ###");
            //
            //
            butLuu.Enabled = bDsdaduyet ? false : dt.Rows.Count != 0;
			butIn.Enabled=butLuu.Enabled;
			dataGrid1.Focus();
			i_row=dataGrid1.CurrentRowIndex;
			load_items();
		}
        

		private void load_items()
		{
			ds.Clear();
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
            //m.close();
            this.Close();
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			luu_in(false);
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="i_loai">0: chua duyet, 2: da duyet</param>
		/// <returns></returns>
        private DataSet load_dtct(int i_loai)
        {
            //i_loai:0: chua duyet
            //i_loai=2: da duyet
            DataSet dstmp, ds1;

            sql = "select c.hoten, a.id, a.maql,a.maql as maql1,a.stt,0 as sttt,a.mavp as mabd,b.ma,trim(b.ten) as ten,";
            sql += " a.mabs as tennguon,a.mabs as tennhomcc,";//c.ten as tennguon
            sql += " ' ' as handung,' ' as losx,a.soluong, a.dongia,0 as sotien,0 as giaban,0 as giamua,0 as sotienmua,";
            sql += " 0 as nhomcc,1 as done,to_char(a.ngay,'dd/mm/yyyy') as ngay,to_char(a.ngayud,'dd/mm/yyyy hh24:mi') as ngayud,a.mabn, a.paid, a.kskphatsinh ";
            sql += " from xxx.v_chidinh a," + user + ".v_giavp b, " + user + ".btdbn c ,"+user+".v_loaivp d ";
            sql += " where a.mavp=b.id and a.mabn=c.mabn ";
            sql += " and b.id_loai=d.id ";
            sql += " and a.mabn='" + s_mabn + "' and a.maql=" + l_maql;
            //sql += " and a.paid=" + i_loai;// +" order by a.stt";          
            sql += " and a.done= "+i_loai;// (a.kskphatsinh=2 or (a.kskphatsinh=1 and a.paid=2))";
            if (s_loaivp_cdha.Trim().Trim(',') != "") sql += " and d.id not in(" + s_loaivp_cdha.Trim().Trim(',') + ")";
            if (s_loavp_thuchien.Trim().Trim(',') != "") sql += " and d.id in(" + s_loavp_thuchien.Trim().Trim(',') + ")";
            if (s_mavp_kham.Trim().Trim(',') != "") sql += " and a.mavp not in(" + s_mavp_kham.Trim().Trim(',') + ")";
            dstmp = m.get_data_mmyy(sql, s_tu, s_den, songayduyet);
            ds1 = dstmp.Copy();
            dstmp.Clear();
            dstmp.Merge(ds1.Tables[0].Select("true", "sttt,stt"));

            return dstmp;
        }
		

		private void upd_data_hoadon(bool prn)
		{
			
			DataRow r;
			DataRow [] dr=ds.Tables[0].Select("ctytra=true and soluong>0","id");						
            string m_mabn="";
            string s_ngayth = txtNgayThuchien.Text;
            string s_ngay = (dr.Length > 0) ? dr[0]["ngay"].ToString() : "";
            string s_noidung = "", m_mmyy = ""; ;
            m_mmyy = (s_ngay == "") ? "" : m.mmyy(s_ngay);
            int itable = (s_ngay == "") ? 0 : m.tableid(m.mmyy(s_ngay), "v_chidinh");
            for (int i = 0; i < dr.Length; i++)
            {
                //update even
                l_id = decimal.Parse(dr[i]["id"].ToString());
                m_mabn = dr[i]["mabn"].ToString();
                s_noidung = f_get_noidung_chidinh(m_mmyy, m_mabn, l_id.ToString());
                {
                    m.upd_eve_tables(s_ngay, itable, i_userid, "upd");
                    m.upd_eve_upd_del(s_ngay, itable, i_userid, "upd", s_noidung);
                }
                if (dr[i]["ctytra"].ToString().ToLower() == "true")
                {
                    m.upd_thuchienylenh(l_id, s_ngayth, s_mabs, 0, 0, "", 0, "", "", s_makp, i_userid);
                    d.execute_data_mmyy("update xxx.v_chidinh set done=2, idphongthuchiencls=" + s_makp.ToString() + ", userid_duyet=" + i_userid + " where mabn='" + m_mabn + "' and id=" + l_id, s_tu, s_den, songayduyet);
                }
                else
                {
                    m.execute_data("delete from medibv.thuchienylenh where id=" + l_id);
                    d.execute_data_mmyy("update xxx.v_chidinh set done=0, userid_duyet=0 where mabn='" + m_mabn + "' and id=" + l_id, s_tu, s_den, songayduyet);
                }
            }
		}

		private void tim_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void tim_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tim)
			{
				refresh_list(tim.Text.Trim());
			}
		}

		private void tim2_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tim2)
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[dataGrid2.DataSource];
				DataView dv=(DataView)cm.List;
				if (tim2.Text!="")
					dv.RowFilter="ten like '%"+tim2.Text.Trim()+"%' or hoten like '%"+tim2.Text.Trim()+"%'";
				else
					dv.RowFilter="";
			}
		}

		private void dataGrid2_Click(object sender, System.EventArgs e)
		{
			try
			{
				Point pt = this.dataGrid1.PointToClient(Control.MousePosition);
				DataGrid.HitTestInfo hti = this.dataGrid1.HitTest(pt);
				BindingManagerBase bmb = this.BindingContext[this.dataGrid2.DataSource, this.dataGrid2.DataMember];
				if(afterCurrentCellChanged && hti.Row < bmb.Count && hti.Type == DataGrid.HitTestType.Cell &&  hti.Column == checkCol )
				{	
					this.dataGrid2[hti.Row, checkCol] = !(bool)this.dataGrid2[hti.Row, checkCol];
					RefreshRow(hti.Row);
				}
				afterCurrentCellChanged = false;
			}
			catch{}
		}

		private void dataGrid2_CurrentCellChanged(object sender, System.EventArgs e)
		{
            try
            {
                if ((bool)this.dataGrid2[this.dataGrid2.CurrentRowIndex, checkCol]) this.dataGrid2.CurrentCell = new DataGridCell(this.dataGrid2.CurrentRowIndex, checkCol);
            }
            catch { }
			afterCurrentCellChanged = true;
		}

        private void luu_in(bool prn)
        {
           
            Cursor = Cursors.WaitCursor;
            CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource];
            DataView dv = (DataView)cm.List;
            dv.RowFilter = "";
            cm = (CurrencyManager)BindingContext[dataGrid2.DataSource];
            dv = (DataView)cm.List;
            dv.RowFilter = "";
            upd_data_hoadon(prn);
            if (bAutoLoad) load_grid("",0,l_iddoan);//linh 251011
            else
            {
                ds.Clear();
                m.delrec(dt, "chon=true");
            }
            bOk = true;
            Cursor = Cursors.Default;
        }

		private void butIn_Click(object sender, System.EventArgs e)
		{
			//luu_in(true);
		}

		private void printer(decimal id,decimal bntra,decimal bhyttra,string mabn,string hoten,string namsinh,string diachi,string sothe,string chandoan,decimal chiphi,decimal congkham,decimal sobienlai,string mabs,int traituyen)
		{
			int irec=0,d_toaso=d.get_sotoa_bhyt(s_mmyy,id,s_ngay,i_madoituong);
			l_maql=0;
			string s_tenbv="",s_tentt="",s_tungay="",s_denngay="",tenbs="";
			d.execute_data("update "+yyy+".bhytkb set sotoa="+d_toaso+" where id="+id);
			d.updrec_bhytll(dtll,l_id,d_toaso);
            string cholam = "";
            foreach (DataRow r1 in d.get_data("select cholam from " + user + ".btdbn where mabn='" + mabn + "'").Tables[0].Rows)
                cholam = r1["cholam"].ToString();
			int iTuoi=(namsinh!="")?DateTime.Now.Year-int.Parse(namsinh):0;
			sql="select a.maql,to_char(b.tungay,'dd/mm/yyyy') as tungay,to_char(b.denngay,'dd/mm/yyyy') as denngay,c.hoten ";
            sql += "from " + yyy + ".bhytkb a," + xxx + ".bhyt b," + user + ".dmbs c where a.maql=b.maql and a.mabs=c.ma and a.id=" + id;
            //sql += "from " + yyy + ".bhytkb a," + user + ".vbhyt_" + s_idcomputer + " b," + user + ".dmbs c where a.maql=b.maql and a.mabs=c.ma and a.id=" + id;
			foreach(DataRow r in d.get_data(sql).Tables[0].Rows)
			{
				s_tungay=r["tungay"].ToString();s_denngay=r["denngay"].ToString();tenbs=r["hoten"].ToString();
				l_maql=decimal.Parse(r["maql"].ToString());
			}            
            if (l_maql == 0 && songayduyet != 0)
            {
            	sql="select a.maql,to_char(b.tungay,'dd/mm/yyyy') as tungay,to_char(b.denngay,'dd/mm/yyyy') as denngay,c.hoten ";
                sql += "from " + yyy + ".bhytkb a," + user+m.mmyy(s_tu) + ".bhyt b," + user + ".dmbs c where a.maql=b.maql and a.mabs=c.ma and a.id=" + id;
                //sql += "from " + yyy + ".bhytkb a," + user + ".vbhyt_" + s_idcomputer + " b," + user + ".dmbs c where a.maql=b.maql and a.mabs=c.ma and a.id=" + id;
			    foreach(DataRow r in d.get_data(sql).Tables[0].Rows)
			    {
				    s_tungay=r["tungay"].ToString();s_denngay=r["denngay"].ToString();tenbs=r["hoten"].ToString();
				    l_maql=decimal.Parse(r["maql"].ToString());
			    }
            }
			if (l_maql!=0)
			{
				foreach(DataRow r3 in d.get_data_mmyy("select b.tenbv from xxx.noigioithieu a,"+user+".dstt b where a.mabv=b.mabv and a.maql="+l_maql,s_tu,s_den,songayduyet).Tables[0].Rows)
					s_tentt=r3["tenbv"].ToString().Trim();
                foreach (DataRow r3 in d.get_data_mmyy("select b.tenbv, a.mabv from xxx.bhyt a," + user + ".dmnoicapbhyt b where a.mabv=b.mabv and a.maql=" + l_maql, s_tu, s_den, songayduyet).Tables[0].Rows) 
					s_tenbv=r3["tenbv"].ToString().Trim()+"^"+r3["mabv"].ToString().Trim();
			}
			DataSet dstmp,ds1;
			if (d.bInBHYT_nhomvp(i_nhom))
			{
				sql="select '"+s_tungay+"' as tungay,'"+s_denngay+"' as denngay,a.stt,a.sttt,a.mabd,b.ma,trim(b.ten)||' '||b.hamluong as ten,b.tenhc,b.dang,e.ten as tenkho,c.ten as tennguon,'' as tennhomcc,t.handung,t.losx,a.soluong,";
                if (bGiaban && i_madoituong != 1) sql += "b.giaban as dongia,a.soluong*b.giaban as sotien,";
                else
                {
                    if (bGia_bh_quydinh && bLaygiamua_khi_giabh_0_giabh_nho_giamua) sql += "(case when a.gia_bh=0 or t.giamua<a.gia_bh then t.giamua else a.gia_bh end) as giaban,(case when a.gia_bh=0 or t.giamua<a.gia_bh then t.giamua else a.gia_bh end)*a.soluong as sotien,";
                    else if (bGia_bh_quydinh && bLaygiamua_khi_giabh_0_giabh_nho_giamua == false) sql += "a.gia_bh as giaban,a.gia_bh*a.soluong as sotien,";
                    else sql += "t.giamua as giaban,a.soluong*t.giamua as sotien,";
                    //sql += "t.giamua as dongia,a.soluong*t.giamua as sotien,";
                }

				sql+="a.soluong*t.giamua as sotienmua,t.giaban,a.cachdung,a.makho,t.manguon,t.nhomcc,h.stt as nhomin,h.ten as tennhomin,g.id as manhom ";
				if (i_bhyt_inrieng==0) sql+=",0 as loaidv";
				else sql+=",case when h.ma="+i_bhyt_inrieng+" then 1 else 0 end as loaidv,"+traituyen+" as traituyen";
                sql += ",i.ten as hangsx, j.ten as nuocsx ";
                sql += " from " + yyy + ".bhytthuoc a," + user + ".d_dmbd b," + user + ".d_dmnguon c," + user + ".d_dmnx d," + user + ".d_dmkho e, " + user + ".d_dmnhom f, " + user + ".d_nhomin g," + user + ".v_nhomvp h," + user + s_mmyy + ".d_theodoi t";
                sql += ", " + user + ".d_dmhang i, " + user + ".d_dmnuoc j ";
				sql+=" where a.sttt=t.id and a.mabd=b.id and t.manguon=c.id and t.nhomcc=d.id and a.makho=e.id and b.manhom=f.id and f.nhomin=g.id and f.nhomvp=h.ma";
                sql += " and b.mahang=i.id(+) and b.manuoc=j.id(+)";
                sql += " and a.id=" + id;// +" order by h.stt,a.stt";			
                sql += " union all ";
                sql+="select '"+s_tungay+"' as tungay,'"+s_denngay+"' as denngay,a.stt,0 as sttt,a.mavp as mabd,b.ma,b.ten,' ' as tenhc,b.dvt as dang,' ' as tenkho,' ' as tennguon,' ' as tennhomcc,' ' as handung,' ' as losx,a.soluong,a.dongia,a.soluong*a.dongia as sotien,a.soluong*a.dongia as sotienmua,a.dongia as giaban,' ' as cachdung,0 as makho,0 as manguon,0 as nhomcc,d.stt as nhomin,d.ten as tennhomin,0 as manhom ";
				if (i_bhyt_inrieng==0) sql+=",0 as loaidv";
                else sql += ",case when d.ma=" + i_bhyt_inrieng + " then 1 else 0 end as loaidv," + traituyen + " as traituyen";
                sql += ", null as hangsx, null as nuocsx ";
                sql += " from " + yyy + ".bhytcls a," + user + ".v_giavp b," + user + ".v_loaivp c," + user + ".v_nhomvp d where a.mavp=b.id and b.id_loai=c.id and c.id_nhom=d.ma and a.id=" + id ;// +" order by d.stt,a.stt";
			}
			else
			{
				sql="select '"+s_tungay+"' as tungay,'"+s_denngay+"' as denngay,a.stt,a.sttt,a.mabd,b.ma,trim(b.ten)||' '||b.hamluong as ten,b.tenhc,b.dang,e.ten as tenkho,c.ten as tennguon,'' as tennhomcc,t.handung,t.losx,a.soluong,";
				if (bGiaban) sql+="b.giaban as dongia,a.soluong*b.giaban as sotien,";
				else sql+="t.giamua as dongia,a.soluong*t.giamua as sotien,";
                sql += "a.soluong*t.giamua as sotienmua,t.giaban,a.cachdung,a.makho,t.manguon,t.nhomcc,case when b.manhom=9 then f.nhomin else 4 end as nhomin,case when b.manhom=9 then f.ten else g.ten end as tennhomin,1 as loaidv,g.id as manhom," + traituyen + " as traituyen";
                sql += ",i.ten as hangsx, j.ten as nuocsx ";
                sql += " from " + yyy + ".bhytthuoc a," + user + ".d_dmbd b," + user + ".d_dmnguon c," + user + ".d_dmnx d," + user + ".d_dmkho e, " + user + ".d_dmnhom f, " + user + ".d_nhomin g," + user + s_mmyy + ".d_theodoi t";
                sql += ", " + user + ".d_dmhang i, " + user + ".d_dmnuoc j ";
				sql+=" where a.sttt=t.id and a.mabd=b.id and t.manguon=c.id and t.nhomcc=d.id and a.makho=e.id and b.manhom=f.id and f.nhomin=g.id ";
                sql += " and b.mahang=i.id(+) and b.manuoc=j.id(+)";
                sql += " and a.id=" + id;// +" order by a.stt";			
                sql += " union all ";
                sql += "select '" + s_tungay + "' as tungay,'" + s_denngay + "' as denngay,a.stt,0 as sttt,a.mavp as mabd,b.ma,b.ten,' ' as tenhc,b.dvt as dang,' ' as tenkho,' ' as tennguon,' ' as tennhomcc,' ' as handung,' ' as losx,a.soluong,a.dongia,a.soluong*a.dongia as sotien,a.soluong*a.dongia as sotienmua,a.dongia as giaban,' ' as cachdung,0 as makho,0 as manguon,0 as nhomcc,4 as nhomin,' ' as tennhomin, 2 as loaidv,0 as manhom," + traituyen + " as traituyen";
                sql += ", null as hangsx, null as nuocsx ";
                sql += " from " + yyy + ".bhytcls a," + user + ".v_giavp b where a.mavp=b.id and a.id=" + id;// +" order by a.stt";
			}
            dstmp = d.get_data(sql);
            ds1 = dstmp.Copy();
            dstmp.Clear();
            dstmp.Merge(ds1.Tables[0].Select("true", "nhomin,stt"));
            irec = dstmp.Tables[0].Select("sttt<>0").Length;
            DataColumn dc = new DataColumn("Image", typeof(byte[]));
            dstmp.Tables[0].Columns.Add(dc);

			foreach(DataRow r3 in dstmp.Tables[0].Rows) 
			{
				r3["tennhomcc"]=s_tentt;
				r3["tennguon"]=s_tenbv;
			}

            if (File.Exists("..\\..\\..\\chuky\\" + mabs + ".bmp"))
            {
                fstr = new FileStream("..\\..\\..\\chuky\\" + mabs + ".bmp", FileMode.Open, FileAccess.Read);
                image = new byte[fstr.Length];
                fstr.Read(image, 0, System.Convert.ToInt32(fstr.Length));
                fstr.Close();
                foreach (DataRow r in dstmp.Tables[0].Rows) r["Image"] = image;
            }

            if (chkXML.Checked)
            {
                if (!System.IO.Directory.Exists("..\\xml")) System.IO.Directory.CreateDirectory("..\\xml");
                dstmp.WriteXml("..\\xml\\bhyt.xml", XmlWriteMode.WriteSchema);
            }
            //if (chkXem.Checked)
            //{
            //    frmReport f = new frmReport(d, dstmp.Tables[0], "d_bhyt.rpt", hoten + "   (" + mabn + ")", (iTuoi == 0) ? "" : iTuoi.ToString(), diachi.Trim() + "^" + cholam.Trim(), sothe , chandoan, irec.ToString(), chiphi.ToString(), bntra.ToString(), bhyttra.ToString(), tenbs, d_toaso.ToString() + "/" + sobienlai.ToString(), congkham.ToString(), soban.Value);
            //    f.ShowDialog();
            //}
            //else
            //{
            //    ReportDocument oRpt=new ReportDocument();
            //    oRpt.Load("..\\..\\..\\report\\d_bhyt.rpt",OpenReportMethod.OpenReportByTempCopy);
            //    oRpt.SetDataSource(dstmp.Tables[0]);
            //    oRpt.DataDefinition.FormulaFields["soyte"].Text="'"+d.Syte+"'";
            //    oRpt.DataDefinition.FormulaFields["benhvien"].Text="'"+d.Tenbv+"'";
            //    oRpt.DataDefinition.FormulaFields["c1"].Text="'"+hoten+"   ("+mabn+")"+"'";
            //    oRpt.DataDefinition.FormulaFields["c2"].Text=(iTuoi==0)?"'"+iTuoi.ToString()+"'":"";
            //    oRpt.DataDefinition.FormulaFields["c3"].Text="'"+diachi.Trim()+"^"+cholam.Trim()+"'";
            //    oRpt.DataDefinition.FormulaFields["c4"].Text="'"+sothe+"'";
            //    oRpt.DataDefinition.FormulaFields["c5"].Text="'"+chandoan+"'";
            //    oRpt.DataDefinition.FormulaFields["c6"].Text="'"+irec.ToString()+"'";
            //    oRpt.DataDefinition.FormulaFields["c7"].Text="'"+chiphi.ToString()+"'";
            //    oRpt.DataDefinition.FormulaFields["c8"].Text="'"+bntra.ToString()+"'";
            //    oRpt.DataDefinition.FormulaFields["c9"].Text="'"+bhyttra.ToString()+"'";
            //    oRpt.DataDefinition.FormulaFields["c10"].Text="'"+tenbs+"'";
            //    oRpt.DataDefinition.FormulaFields["giamdoc"].Text="'"+d_toaso.ToString()+"/"+sobienlai.ToString()+"'";
            //    oRpt.DataDefinition.FormulaFields["phutrach"].Text="'"+d.Phutrach(i_nhom)+"'";
            //    oRpt.DataDefinition.FormulaFields["thongke"].Text="'"+congkham.ToString()+"'";
            //    oRpt.DataDefinition.FormulaFields["ketoan"].Text="'"+d.Ketoan(i_nhom)+"'";
            //    oRpt.DataDefinition.FormulaFields["thukho"].Text="'"+d.Thukho(i_nhom)+"'";
            //    oRpt.PrintToPrinter(Convert.ToInt32(soban.Value),false,0,0);
            //    oRpt.Close(); oRpt.Dispose();
            //}
		}

		private void frmDuyetbhyt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.F9) butIn_Click(sender,e);
			else if (e.KeyCode==Keys.F5) butLuu_Click(sender,e);
		}

        private void butList_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            songayduyet = int.Parse(numNgayduyettoa.Value.ToString());
            s_tu = m.DateToString("dd/MM/yyyy", m.StringToDate(txtNgayThuchien.Text).AddDays(-1 * songayduyet));
            load_grid("", 0, l_iddoan); //linh 251011
            if (tim.Text.Trim() != "" && tim.Text.Trim() != "Tìm kiếm") refresh_list(tim.Text.Trim());
            Cursor = Cursors.Default;
            btHuy38.Enabled = false;
            bDsdaduyet = false;
            butLuu.Enabled = true;

            //butIn.Enabled = false;
        }

        private void kiemtra_duyet(decimal id)
        {
            if (d.get_done_thuocbhyt(s_ngay, id))
            {
                string s_tu = m.DateToString("dd/MM/yyyy", m.StringToDate(s_ngay).AddDays(-1 * songayduyet));
                string s_den = s_ngay;
                if (d.get_data_mmyy("select * from xxx.bhytkb where id=" + id, s_tu, s_den, songayduyet).Tables[0].Rows.Count == 0)
                {
                    d.execute_data("update " + xxx + ".d_thuocbhytct set slthuc=0 where id=" + id);
                    d.execute_data("update " + xxx + ".d_thuocbhytll set done=0 where id=" + id);
                }
            }
        }

        private void butAll_Click(object sender, EventArgs e)
        {
            if (dt.Rows.Count <= 0 && tim.Text.Trim().Length == 8) load_grid(tim.Text.Trim(), 0, l_iddoan);//linh 251011
            Cursor = Cursors.WaitCursor;
            string sql1 = "chon=false";
            if (tim.Text != "")
                sql1 += " and (hoten like '%" + tim.Text.Trim() + "%' or sothe like '%" + tim.Text.Trim() + "%' or mabn like '%" + tim.Text.Trim() + "%' or tenkp like '%" + tim.Text.Trim() + "%')";
            ds = new DataSet();
            foreach (DataRow r1 in dt.Select(sql1))
            {
                l_id = decimal.Parse(r1["id"].ToString());
                s_makp = r1["makp"].ToString();
                s_mabn = r1["mabn"].ToString();
                l_maql = decimal.Parse(r1["maql"].ToString());
                _madoituong = int.Parse(r1["madoituong"].ToString());
                l_mavaovien = decimal.Parse(r1["mavaovien"].ToString());
                if (ds == null || ds.Tables.Count < 0)
                    ds = load_dtct(bDsdaduyet ? 2 : 0);
                else ds.Merge(load_dtct(bDsdaduyet ? 2 : 0));
                                
                r1["chon"] = true;
            }
            Cursor = Cursors.Default;
            butIn.Focus();
        }

        private void tim_Enter(object sender, EventArgs e)
        {
            tim.Text="";
        }
  
      
        public void updrec_thuocbhytct(DataTable dt,string mabn,string ngay,string hoten, decimal id, decimal stt, decimal sttt, 
            int mabd, string ma, string ten, string tenhc, string dang, string tenkho, string tennguon, string tennhomcc, 
            string handung, string losx, decimal soluong, decimal dongia, decimal sotien, string cachdung, int makho, 
            int manguon, int nhomcc, string ngayud, int done, bool b_chon)
        {
            string exp = "sttt=" + sttt;
            if (sttt == 0) exp += " and stt=" + stt;
            exp += " and mabd=" + mabd + " and mabn='" + mabn + "' and ngay='" + ngay + "'";
            exp += " and ngayud='" + ngayud + "'";
            DataRow r = d.getrowbyid(dt, exp); 
            if (r == null)
            {
                DataRow nrow = dt.NewRow();
                nrow["hoten"] = hoten;
                nrow["id"] = id;
                nrow["mabn"] = mabn;
                nrow["ngay"] = ngay;
                nrow["ngayud"] = ngayud;
                nrow["stt"] = stt;
                nrow["sttt"] = sttt;
                nrow["mabd"] = mabd;
                nrow["ma"] = ma;
                nrow["ten"] = ten;
                nrow["tenhc"] = tenhc;
                nrow["dang"] = dang;
                nrow["tenkho"] = tenkho;
                nrow["tennguon"] = tennguon;
                nrow["tennhomcc"] = tennhomcc;
                nrow["handung"] = handung;
                nrow["losx"] = losx;
                nrow["soluong"] = soluong;
                nrow["dongia"] = dongia;
                nrow["sotien"] = sotien;
                nrow["cachdung"] = cachdung;
                nrow["makho"] = makho;
                nrow["manguon"] = manguon;
                nrow["nhomcc"] = nhomcc;
                nrow["chon"] = b_chon ;//false
                nrow["done"] = done;
                dt.Rows.Add(nrow);
            }
            else
            {
                DataRow[] dr = dt.Select(exp);
                dr[0]["sttt"] = sttt;
                dr[0]["mabd"] = mabd;
                dr[0]["ma"] = ma;
                dr[0]["ten"] = ten;
                dr[0]["tenhc"] = tenhc;
                dr[0]["dang"] = dang;
                dr[0]["tenkho"] = tenkho;
                dr[0]["tennguon"] = tennguon;
                dr[0]["tennhomcc"] = tennhomcc;
                dr[0]["handung"] = handung;
                dr[0]["losx"] = losx;
                dr[0]["soluong"] = soluong;
                dr[0]["dongia"] = dongia;
                dr[0]["sotien"] = sotien;
                dr[0]["cachdung"] = cachdung;
                dr[0]["makho"] = makho;
                dr[0]["manguon"] = manguon;
                dr[0]["nhomcc"] = nhomcc;
                dr[0]["chon"] = b_chon;// false;
                dr[0]["done"] = done;
            }
        }

        private string check_mabn_chuaduyet()
        {
            string s_mabn = "";
            bool bln = false;
            foreach (DataRow r in dt.Select("chon=true"))
            {
                s_mabn = r["mabn"].ToString();
                foreach (DataRow dr in dt.Select("mabn='" + s_mabn + "' and chon=false"))
                {
                    bln = true;
                    break;
                }
                if (bln) break;
            }
            return (bln) ? s_mabn : "";
        }
        private void f_load_option()
        {
            bThuchenhlechtruoc_duyettoasau = d.bThuchenhlechtruoc_duyettoasau(i_nhom);
            bLaygiamua_khi_giabh_0_giabh_nho_giamua = d.bLaygiamua_khi_giabh_0_giabh_nho_giamua;
            bBHYT_Traituyen_tinh_Tyle_khac = m.bBHYT_Traituyen_tinh_Tyle_khac;
            bTraituyen_bhtra = m.bTraituyen_bhtra;//True: BHYT trai tuyen chi tinh tren tong chi phi BHYT thanh toan sau khi tinh theo ty le the
            bBhyt_tra_1_congkham = m.bBH_chitra_1congkham_conlaikhongtinh_G79_1 || m.bBH_chitra_1congkham;
            i_quyen_duyetmau38 = d.f_quyet_duyet_mau38(i_nhom, i_userid);
            pathImage = m.pathImage;
            FileType = m.FileType;
            bQuanly_HinhBN = m.bHinh;
            pic.Tag = "";
        }

        private void refresh_list(string s_tim)
        {
            CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource];
            DataView dv = (DataView)cm.List;
            sql = "hoten like '%" + s_tim + "%' or mabn like '%" + s_tim + "%' or chon=true";
            if (s_tim != "")
            {
                dv.RowFilter = sql;
               
            }
            else
                dv.RowFilter = "";
        }

        private bool bBN_Chuakhamxong(string d_mmyy, string d_mavaovien)
        {
            bool bln = false;
            sql = "select a.maql, a.mabn from " + user + d_mmyy + ".benhanpk a left join " + user + d_mmyy + ".xutrikbct b on a.maql=b.maql where b.maql is null and a.mavaovien=" + d_mavaovien;
            DataSet lds = d.get_data(sql);
            if (lds == null || lds.Tables.Count <= 0)
                bln = false;
            else if (lds.Tables[0].Rows.Count > 0) bln = true;
            return bln;
        }
        private void get_chandoan_chinh(string mmyy, int d_loaiba, decimal d_mavaovien, string d_mabn, string d_makp, ref string d_chandoan, ref string d_icd)
        {
            DataSet lds=new DataSet();
            switch (d_loaiba)
            {
                case 1:
                    sql = "select a.chandoan, a.maicd from " + user + ".nhapkhoa a, " + user + ".benhandt b where a.maql=b.maql and b.mavaovien=" + d_mavaovien + " and a.mabn='" + d_mabn + "' and a.makp='" + d_makp + "' order by maql desc, a.id desc";
                    lds = d.get_data(sql);
                    break;
                case 2:
                    sql = "select chandoan, maicd from " + user + ".benhanngtr where mavaovien=" + d_mavaovien + " and mabn='" + d_mabn + "' and makp='" + d_makp + "' order by maql desc";
                    if (d.bMmyy(mmyy))
                    {
                        sql += "union all ";
                        sql += "select chandoan, maicd from " + user + mmyy + ".benhanngpk where mavaovien=" + d_mavaovien + " and mabn='" + d_mabn + "' and makp='" + d_makp + "' order by maql desc";
                    }
                    lds = d.get_data(sql);
                    break;
                case 3:
                    if (d.bMmyy(mmyy))
                    {
                        sql = "select chandoan, maicd from " + user + mmyy + ".benhanpk where mavaovien=" + d_mavaovien + " and mabn='" + d_mabn + "' and makp='" + d_makp + "' order by maql desc";
                        lds = d.get_data(sql);
                    }
                    break;
                case 4:
                    if (d.bMmyy(mmyy))
                    {
                        sql = "select chandoan, maicd from " + user + mmyy + ".benhancc where mavaovien=" + d_mavaovien + " and mabn='" + d_mabn + "' and makp='" + d_makp + "' order by maql desc";
                        lds = d.get_data(sql);
                    }
                    break;
                default:
                    if (d.bMmyy(mmyy))
                    {
                        sql = "select chandoan, maicd from " + user + mmyy + ".benhanpk where mavaovien=" + d_mavaovien + " and mabn='" + d_mabn + "' and makp='" + d_makp + "' order by maql desc";
                        lds = d.get_data(sql);
                    }
                    break;

            }
            if (lds == null || lds.Tables.Count <= 0 || lds.Tables[0].Rows.Count <= 0) { d_chandoan = ""; d_icd = ""; }
            else
            {
                d_chandoan = lds.Tables[0].Rows[0]["chandoan"].ToString();
                d_icd = lds.Tables[0].Rows[0]["maicd"].ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            songayduyet = int.Parse(numNgayduyettoa.Value.ToString());
            s_tu = m.DateToString("dd/MM/yyyy", m.StringToDate(txtNgayThuchien.Text).AddDays(-1 * songayduyet));
            bDsdaduyet = true;
            b_chuathutienthuoc = false;
            btHuy38.Enabled = true ;
            load_grid("",2, l_iddoan);
            //butIn.Enabled = true;
        }

        private void btHuy38_Click(object sender, EventArgs e)
        {
            try
            {
                bool bDelete = false;
                if (dt.Rows.Count == 0)
                    return;
                if (ds.Tables[0].Select("ctytra=true").Length <= 0)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Đề nghị chọn kỹ thuật cần hủy."), "Medisoft THIS");
                    return;
                }
                //sql = "select distinct done from " + d.user + s_mmyy + ".v_chidinh where id=" + l_id + " and done=1 ";
                //DataSet lds = d.get_data(sql);
                //if (lds != null && lds.Tables.Count > 0 && lds.Tables[0].Rows.Count > 0)
                //{
                //    MessageBox.Show(lan.Change_language_MessageText("Dịch vụ đã được viện phí thu, không hủy được."));
                //    return;
                //}
                
                if (bDuyetError == false)
                {
                   
                    DialogResult dlg = MessageBox.Show(lan.Change_language_MessageText("Đồng ý hủy thực hiện kỹ thuật này ?"), d.Msg, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlg == DialogResult.Yes)
                    {
                        bDelete = true;
                    }
                    else bDelete = false;
                }
                else bDelete = true;
                if (bDelete)
                {
                    foreach (DataRow r in ds.Tables[0].Select("ctytra=true"))
                    {
                        d.execute_data_mmyy("update xxx.v_chidinh set done=0, userid_duyet=0 where done=2 and id in (" + r["id"].ToString() + ")", s_tu, s_den, songayduyet);                        
                    }
                    load_grid("", 2, l_iddoan);
                }
            }
            catch (Exception ex) { }
        }

        private void pic_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                frmXemhinh f = new frmXemhinh(s_hoten, (byte[])(pic.Tag));
                f.ShowDialog();
            }
            catch { }
        }

        private void f_load_hinh()
        {
            if (bQuanly_HinhBN)
            {
                //linh
                bool error = true;
                try
                {
                    if (pathImage != "")
                    {
                        pathImage = pathImage.Replace("\\", "//");
                        pathImage = pathImage.Trim('/');
                        string pathpic = pathImage + "//" + s_mabn + "." + FileType;
                        if (System.IO.File.Exists(pathpic))
                        {
                            error = false;
                            pic.Tag = pathpic;
                        }
                        else
                        {
                            error = true;
                        }
                    }
                    else
                    {
                        error = true;
                    }
                }
                catch
                {
                    error = true;
                    pic.Tag = "0000.bmp";
                }
                if (error)
                {
                    //linh                    
                    pic.Image = pic.InitialImage;// (Bitmap)map;
                    //end linh
                }
                else
                {
                    fstr = new System.IO.FileStream(pic.Tag.ToString(), System.IO.FileMode.Open, System.IO.FileAccess.Read);
                    map = new Bitmap(Image.FromStream(fstr));
                    pic.Image = (Bitmap)map;
                }
                //end linh
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            songayduyet = int.Parse(numNgayduyettoa.Value.ToString());
            s_tu = m.DateToString("dd/MM/yyyy", m.StringToDate(s_ngay).AddDays(-1 * songayduyet));
            b_chuathutienthuoc = true;
            bDsdaduyet = true;
            btHuy38.Enabled = true;
            butLuu.Enabled = false;
            //load_grid_daduyet("", b_chuathutienthuoc);//linh 251011
            load_grid("", 2, l_iddoan);
        }

        private void setFalse()
        {

            foreach (DataRow r in dt.Select("chon=true"))
            {
                r["chon"] = false;
            }
            dt.AcceptChanges();
        }
        private void f_get_tongtien(ref decimal a_tongtien)
        {
            foreach (DataRow r in dt.Rows)
            {
                a_tongtien += decimal.Parse(r["sotien"].ToString());
            }
        }

        private string f_get_noidung_chidinh(string m_mmyy, string m_mabn, string m_id)
        {
            string xxx=m.user+m_mmyy;
            string s_noidung="";
            string asql = " select a.* from " + xxx + ".v_chidinh a inner join medibv.v_giavp b on a.mavp=b.id ";
            asql += " where a.mabn='" + m_mabn + "' and a.id=" + m_id;
            asql += " ";
            
            DataSet lds = m.get_data(asql);
            foreach (DataRow r in lds.Tables[0].Rows)
            {
                for(int j=0;j<lds.Tables[0].Columns.Count;j++)
                {
                    s_noidung+=r[j].ToString()+"^";
                }
                break;
            }
                
            return s_noidung;
        }

        private string f_get_loavp(string amakp)
        {
            string aLoaivp = "";
            string asql = "select loaicd, muccd from medibv.btdkp_bv where mabn ='" + amakp + "'";
            DataSet ads = m.get_data(asql);
            if (ads == null || ads.Tables.Count <= 0 || ads.Tables[0].Rows.Count <= 0)
            {
                aLoaivp = "";
            }
            else
            {
                foreach (DataRow dr in ads.Tables[0].Rows)
                {
                    aLoaivp += dr["loaicd"].ToString().Trim().Trim(',')+",";
                }
            }
            return aLoaivp.Replace(",,", ",").Trim().Trim(',');
        }

        private string f_get_loavp_cdha_xn()
        {
            string aLoaivp = "";
            string asql = "select id_loaivp from medibv.cdha_loai ";
            DataSet ads = m.get_data(asql);
            if (ads == null || ads.Tables.Count <= 0 || ads.Tables[0].Rows.Count <= 0)
            {
                aLoaivp = "";
            }
            else
            {
                foreach (DataRow dr in ads.Tables[0].Rows)
                {
                    aLoaivp += dr["id_loaivp"].ToString().Trim().Trim(',') + ",";
                }
            }
            //xn
            asql = " select distinct b.id_loai from medibv.xn_bv_ten a inner join medibv.v_giavp b on a.id_vienphi=b.id ";
            ads = m.get_data(asql);
            if (ads == null || ads.Tables.Count <= 0 || ads.Tables[0].Rows.Count <= 0)
            {
                aLoaivp = aLoaivp;
            }
            else
            {
                foreach (DataRow dr in ads.Tables[0].Rows)
                {
                    aLoaivp += dr["id_loai"].ToString().Trim().Trim(',') + ",";
                }
            }
            return aLoaivp.Replace(",,", ",").Trim().Trim(',');
        }


        private DataSet load_gridview_dathuchien(string m_tu, string m_den)
        {
            //i_loai=0: chua duyet
            //i_loai=1: da duyet                    
            //           
            sql = "select a.mabn,a.maql,a.mavaovien, ";
            sql += " b.hoten,b.namsinh,b.phai, case when b.phai=0 then 'Nam' else 'Nữ' end as gioitinh, ";//trim(b.sonha)||' '||b.thon as diachi,b.cholam,x.tentt,y.tenquan,z.tenpxa,";
            sql += " a.makp, to_char(aa.ngay,'dd/mm/yyyy') as ngay, to_char(b.ngaysinh,'dd/mm/yyyy') as ngaysinh, ";
            sql += " a.soluong*a.dongia as sotien, u.ten as tenkythuat, u.ma as makt, ";
            sql += " aa.makp, e.tenkp, l.hoten as nguoinhap, m.hoten as tenbs, aa.manv ";
            sql += " from " + user + ".thuchienylenh aa inner join xxx.v_chidinh a on aa.id=a.id inner join " + user + ".btdbn b on a.mabn=b.mabn ";
            sql += " left join " + user + ".btdkp_bv e on aa.makp=e.makp ";
            sql += " inner join " + user + ".doituong f on a.madoituong=f.madoituong";
            sql += " left join " + user + ".btdtt x on b.matt=x.matt ";
            sql += " left join " + user + ".btdquan y on b.maqu=y.maqu ";
            sql += " left join " + user + ".btdpxa z on b.maphuongxa=z.maphuongxa ";
            sql += " inner join " + user + ".v_giavp u on a.mavp=u.id ";
            sql += " inner join " + user + ".v_loaivp v on u.id_loai=v.id ";
            sql += " inner join " + user + ".dlogin l on aa.userid =l.id ";
            sql += " left join " + user + ".dmbs m on aa.manv =m.ma ";
            sql += " where 1=1 ";
            if (m_tu == m_den) sql += " and to_char(a.ngay,'dd/mm/yyyy')='" + m_tu + "'";
            else sql += " and " + m.for_ngay("a.ngay", stime) + " between to_date('" + m_tu + "','dd/mm/yyyy') and to_date('" + m_den + "','dd/mm/yyyy')";            
            if (s_loavp_thuchien.Trim().Trim(',') != "") sql += " and v.id in(" + s_loavp_thuchien.Trim().Trim(',') + ")";
            if (s_loaivp_cdha.Trim().Trim(',') != "") sql += " and v.id not in(" + s_loaivp_cdha.Trim().Trim(',') + ")";
            if (s_mavp_kham.Trim().Trim(',') != "") sql += " and a.mavp not in(" + s_mavp_kham.Trim().Trim(',') + ")";
            //sql += " group by a.mabn, a.maql, a.mavaovien, b.hoten, b.namsinh, to_char(a.ngay,'dd/mm/yyyy'), a.makp ";
            DataSet adslist = m.get_data_mmyy(sql, s_tu, s_den, songayduyet);

            return adslist;            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            DataSet dslist = load_gridview_dathuchien(txtTu.Text, txtDen.Text);
            dataGridView1.DataSource = dslist.Tables[0];
        }

        private void butKetthucDS_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butInds_Click(object sender, EventArgs e)
        {
            DataSet dslist = load_gridview_dathuchien(txtTu.Text, txtDen.Text);
            dataGridView1.DataSource = dslist.Tables[0];
            if (System.IO.Directory.Exists("..//..//dataxml") == false) System.IO.Directory.CreateDirectory("..//..//dataxml");
            dslist.WriteXml("..//..//dataxml//rptdsthuchiendvkt.xml", XmlWriteMode.WriteSchema);
            string s_title = "Từ ngày " + txtTu.Text + " and đến ngày " + txtDen.Text;
            dllReportM.frmReport f = new dllReportM.frmReport(m, dslist, "rptdsthuchiendvkt.rpt", m.Syte, m.Tenbv, s_title, "", "", "");
            f.ShowDialog();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            txtNgayThuchien.Enabled = !txtNgayThuchien.Enabled;
        }
	}
}
