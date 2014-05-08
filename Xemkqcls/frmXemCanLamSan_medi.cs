using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Xml;
using LibXetnghiem;
using LibMedi;
using System.DirectoryServices;
using System.IO;
using LibVP;

namespace frmCanlamsan
{
	public class frmXemCanLamSan_medi : System.Windows.Forms.Form
    {
        #region Khai bao
        PictureBox[] Pb=new PictureBox[100];
		internal double[] CobbCoord = new double[8];
		Bitmap bm;
		
        Language lan = new Language();      
		private LibXetnghiem.AccessData m_x = new LibXetnghiem.AccessData();
        private LibVP.AccessData m_v = new LibVP.AccessData(); 
        private LibMedi.AccessData m = new LibMedi.AccessData();
        private LibDuoc.AccessData d = new LibDuoc.AccessData();
		private DateTime m_tn= new DateTime(DateTime.Now.Year,1,1);
		private DateTime m_dn= new DateTime(DateTime.Now.Year,DateTime.Now.Month,DateTime.Now.Day);
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtMabn;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtHoTen;  
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.RadioButton rdHienTai;
        private System.Windows.Forms.RadioButton rdTatCa;
        private System.Windows.Forms.TextBox txtTuoi;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label4;		        
        private System.Windows.Forms.TextBox txtPhai;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem menuItem5;
        private System.Windows.Forms.MenuItem menuItem6;
		private System.Windows.Forms.ContextMenu contextMenu2;
		private System.Windows.Forms.MenuItem menu200;
		private System.Windows.Forms.MenuItem menu400;
		private System.Windows.Forms.MenuItem menu600;
        private System.Windows.Forms.MenuItem menu800;
        private System.Windows.Forms.FontDialog FontDialog;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ColorDialog ColorDialog;
        private System.Windows.Forms.ImageList _imageList;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel1;
        private Panel panel5;
        private TreeView treeView1;
        private Panel panel6;
        private TabControl tabCtrl;
        private TabPage tabPage3;
        private DataGridView dataGridView1;
        private TabPage tabPage4;
        private Panel panel7;
        private Panel panel10;
        private Panel panel9;
        private Panel panel8;
        private TextBox txtMota;
        private Label label9;
        private Label label8;
        private Panel panel11;
        private Label label5;
        private Panel pnlPicture;
        private Label lblNopic;
        private bool bl_QuanlyhinhDataBase = false;
        private string s_Path_image_Maychu = "", s_ngaycdha = "",nam="",user,s_sql;
        private Button cmdBN_New;
        private Button butKetthuc;
        private TabPage tabPage1;
        private PictureBox picPreview;
        private Label label7;
        private TextBox diachi;
        private Panel panel12;
        private TextBox txtKetluan;
        private System.ComponentModel.IContainer components;
        private int soluong_le = 0;
        private Button butBieudo;
        private Label label10;
        private DateTimePicker txtDenngay;
        private Label label6;
        private DateTimePicker txtTungay;
        private DataGridViewTextBoxColumn Column_stt;
        private DataGridViewTextBoxColumn Column_stt1;
        private DataGridViewTextBoxColumn Column_so;
        private DataGridViewTextBoxColumn ketqua;
        private DataGridViewTextBoxColumn dvt;
        private DataGridViewTextBoxColumn csbt_nam;
        private DataGridViewTextBoxColumn csbt_nu;
        private DataGridViewTextBoxColumn ten_xn;
        private DataGridViewTextBoxColumn ngay;
        private DataGridViewTextBoxColumn xn_id_ten;
        private NumericUpDown numSothang;
        private Button butXem;
        private CheckBox chkXemtatca;
        private Label label11;
        private bool bbadt = false;
        #endregion

        public frmXemCanLamSan_medi(string x_mabn,string x_hoten,string x_tuoi,string x_diachi)
		{			
			
			InitializeComponent();
            lan.Read_Language_to_Xml(this.Name, this);
            lan.Changelanguage_to_English(this.Name, this);
			
			txtMabn.Text=x_mabn;
			txtHoTen.Text=x_hoten;
			txtTuoi.Text=x_tuoi;
            bl_QuanlyhinhDataBase = bQuanlyhinhDatabase;
            s_Path_image_Maychu = f_Thumuc_Luuhinh;
		}
        //Tu:25/05/2011
        public frmXemCanLamSan_medi(string x_mabn, string x_hoten, string x_tuoi, string x_diachi,bool _badt)
        {
            InitializeComponent();
            lan.Read_Language_to_Xml(this.Name, this);
            lan.Changelanguage_to_English(this.Name, this);

            txtMabn.Text = x_mabn;
            txtHoTen.Text = x_hoten;
            txtTuoi.Text = x_tuoi;
            bl_QuanlyhinhDataBase = bQuanlyhinhDatabase;
            s_Path_image_Maychu = f_Thumuc_Luuhinh;
            bbadt = _badt;
        }
        //end Tu
        public bool bQuanlyhinhDatabase
        {
            get
            {
                try
                {
                    return m_v.get_data("select giatri from medibv.cdha_thongso where id=23").Tables[0].Rows[0][0].ToString() == "1" ? true : false;
                }
                catch
                {
                    return false;
                }
            }

        }
        public string f_Thumuc_Luuhinh
        {
            get
            {
                try
                {
                    return m_v.get_data("select ten from medibv.cdha_thongso where id=21").Tables[0].Rows[0][0].ToString();
                }
                catch
                {
                    return "";
                }
            }

        }
        public frmXemCanLamSan_medi()
        {
            InitializeComponent();
        }
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmXemCanLamSan_medi));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMabn = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTuoi = new System.Windows.Forms.TextBox();
            this.rdHienTai = new System.Windows.Forms.RadioButton();
            this.rdTatCa = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPhai = new System.Windows.Forms.TextBox();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.contextMenu2 = new System.Windows.Forms.ContextMenu();
            this.menu200 = new System.Windows.Forms.MenuItem();
            this.menu400 = new System.Windows.Forms.MenuItem();
            this.menu600 = new System.Windows.Forms.MenuItem();
            this.menu800 = new System.Windows.Forms.MenuItem();
            this.FontDialog = new System.Windows.Forms.FontDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ColorDialog = new System.Windows.Forms.ColorDialog();
            this._imageList = new System.Windows.Forms.ImageList(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.tabCtrl = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDenngay = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTungay = new System.Windows.Forms.DateTimePicker();
            this.butBieudo = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column_stt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_stt1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_so = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ketqua = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dvt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.csbt_nam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.csbt_nu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ten_xn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xn_id_ten = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.panel11 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.pnlPicture = new System.Windows.Forms.Panel();
            this.lblNopic = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.txtMota = new System.Windows.Forms.TextBox();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel12 = new System.Windows.Forms.Panel();
            this.txtKetluan = new System.Windows.Forms.TextBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.picPreview = new System.Windows.Forms.PictureBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.cmdBN_New = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.diachi = new System.Windows.Forms.TextBox();
            this.numSothang = new System.Windows.Forms.NumericUpDown();
            this.butXem = new System.Windows.Forms.Button();
            this.chkXemtatca = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.tabCtrl.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel10.SuspendLayout();
            this.pnlPicture.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel12.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSothang)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(8, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã BN :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtMabn
            // 
            this.txtMabn.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtMabn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMabn.ForeColor = System.Drawing.Color.Black;
            this.txtMabn.Location = new System.Drawing.Point(53, 11);
            this.txtMabn.MaxLength = 10;
            this.txtMabn.Name = "txtMabn";
            this.txtMabn.Size = new System.Drawing.Size(67, 21);
            this.txtMabn.TabIndex = 1;
            this.txtMabn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMabn_KeyDown);
            this.txtMabn.Validating += new System.ComponentModel.CancelEventHandler(this.txtMabn_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(119, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Họ tên :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtHoTen
            // 
            this.txtHoTen.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtHoTen.Enabled = false;
            this.txtHoTen.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHoTen.ForeColor = System.Drawing.Color.Black;
            this.txtHoTen.Location = new System.Drawing.Point(162, 11);
            this.txtHoTen.MaxLength = 50;
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(171, 21);
            this.txtHoTen.TabIndex = 3;
            this.txtHoTen.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtHoTen_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(415, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Năm sinh :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTuoi
            // 
            this.txtTuoi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtTuoi.Enabled = false;
            this.txtTuoi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTuoi.ForeColor = System.Drawing.Color.Black;
            this.txtTuoi.Location = new System.Drawing.Point(472, 11);
            this.txtTuoi.MaxLength = 4;
            this.txtTuoi.Name = "txtTuoi";
            this.txtTuoi.Size = new System.Drawing.Size(40, 21);
            this.txtTuoi.TabIndex = 7;
            this.txtTuoi.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // rdHienTai
            // 
            this.rdHienTai.ForeColor = System.Drawing.Color.Navy;
            this.rdHienTai.Location = new System.Drawing.Point(18, 10);
            this.rdHienTai.Name = "rdHienTai";
            this.rdHienTai.Size = new System.Drawing.Size(64, 17);
            this.rdHienTai.TabIndex = 0;
            this.rdHienTai.Text = "Hiện tại";
            this.rdHienTai.CheckedChanged += new System.EventHandler(this.rdHienTai_CheckedChanged);
            // 
            // rdTatCa
            // 
            this.rdTatCa.Checked = true;
            this.rdTatCa.ForeColor = System.Drawing.Color.Navy;
            this.rdTatCa.Location = new System.Drawing.Point(108, 10);
            this.rdTatCa.Name = "rdTatCa";
            this.rdTatCa.Size = new System.Drawing.Size(77, 18);
            this.rdTatCa.TabIndex = 1;
            this.rdTatCa.TabStop = true;
            this.rdTatCa.Text = "Toàn bộ";
            this.rdTatCa.CheckedChanged += new System.EventHandler(this.rdTatCa_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdHienTai);
            this.groupBox1.Controls.Add(this.rdTatCa);
            this.groupBox1.ForeColor = System.Drawing.Color.Navy;
            this.groupBox1.Location = new System.Drawing.Point(4, 558);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(211, 31);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Navy;
            this.label4.Location = new System.Drawing.Point(332, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Giới tính :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPhai
            // 
            this.txtPhai.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtPhai.Enabled = false;
            this.txtPhai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhai.ForeColor = System.Drawing.Color.Black;
            this.txtPhai.Location = new System.Drawing.Point(385, 11);
            this.txtPhai.MaxLength = 4;
            this.txtPhai.Name = "txtPhai";
            this.txtPhai.Size = new System.Drawing.Size(31, 21);
            this.txtPhai.TabIndex = 5;
            this.txtPhai.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // contextMenu1
            // 
            this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem2,
            this.menuItem3,
            this.menuItem1,
            this.menuItem4,
            this.menuItem5,
            this.menuItem6});
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 0;
            this.menuItem2.Text = "Vị trí bình thường";
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 1;
            this.menuItem3.Text = "-";
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 2;
            this.menuItem1.Text = "Xoay ngang";
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 3;
            this.menuItem4.Text = "Xoay thẳng đứng";
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 4;
            this.menuItem5.Text = "Xoay theo chiều kim đồng hồ";
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 5;
            this.menuItem6.Text = "Xoay ngược chiều kim đồng hồ";
            // 
            // contextMenu2
            // 
            this.contextMenu2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menu200,
            this.menu400,
            this.menu600,
            this.menu800});
            // 
            // menu200
            // 
            this.menu200.Index = 0;
            this.menu200.Text = "200%";
            this.menu200.Click += new System.EventHandler(this.menu200_Click);
            // 
            // menu400
            // 
            this.menu400.Index = 1;
            this.menu400.Text = "400%";
            this.menu400.Click += new System.EventHandler(this.menu400_Click);
            // 
            // menu600
            // 
            this.menu600.Index = 2;
            this.menu600.Text = "600%";
            this.menu600.Click += new System.EventHandler(this.menu600_Click);
            // 
            // menu800
            // 
            this.menu800.Index = 3;
            this.menu800.Text = "800%";
            this.menu800.Click += new System.EventHandler(this.menu800_Click);
            // 
            // _imageList
            // 
            this._imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("_imageList.ImageStream")));
            this._imageList.TransparentColor = System.Drawing.SystemColors.Control;
            this._imageList.Images.SetKeyName(0, "");
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(2, 596);
            this.panel2.TabIndex = 227;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(825, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(2, 596);
            this.panel3.TabIndex = 227;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(2, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(823, 2);
            this.panel4.TabIndex = 227;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Location = new System.Drawing.Point(2, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(823, 514);
            this.panel1.TabIndex = 229;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.tabCtrl);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(252, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(567, 510);
            this.panel6.TabIndex = 1;
            // 
            // tabCtrl
            // 
            this.tabCtrl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabCtrl.Controls.Add(this.tabPage3);
            this.tabCtrl.Controls.Add(this.tabPage4);
            this.tabCtrl.Controls.Add(this.tabPage1);
            this.tabCtrl.Location = new System.Drawing.Point(3, 0);
            this.tabCtrl.Name = "tabCtrl";
            this.tabCtrl.SelectedIndex = 0;
            this.tabCtrl.Size = new System.Drawing.Size(564, 510);
            this.tabCtrl.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Controls.Add(this.txtDenngay);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.txtTungay);
            this.tabPage3.Controls.Add(this.butBieudo);
            this.tabPage3.Controls.Add(this.dataGridView1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(556, 484);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Xét nghiệm";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Navy;
            this.label10.Location = new System.Drawing.Point(324, 463);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(58, 13);
            this.label10.TabIndex = 8;
            this.label10.Text = "đến ngày: ";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDenngay
            // 
            this.txtDenngay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenngay.CustomFormat = "dd/MM/yyyy";
            this.txtDenngay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtDenngay.Location = new System.Drawing.Point(385, 459);
            this.txtDenngay.Name = "txtDenngay";
            this.txtDenngay.Size = new System.Drawing.Size(96, 20);
            this.txtDenngay.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Navy;
            this.label6.Location = new System.Drawing.Point(169, 463);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Từ ngày: ";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTungay
            // 
            this.txtTungay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTungay.CustomFormat = "dd/MM/yyyy";
            this.txtTungay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtTungay.Location = new System.Drawing.Point(220, 459);
            this.txtTungay.Name = "txtTungay";
            this.txtTungay.Size = new System.Drawing.Size(99, 20);
            this.txtTungay.TabIndex = 5;
            // 
            // butBieudo
            // 
            this.butBieudo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butBieudo.ForeColor = System.Drawing.Color.Black;
            this.butBieudo.Image = ((System.Drawing.Image)(resources.GetObject("butBieudo.Image")));
            this.butBieudo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBieudo.Location = new System.Drawing.Point(482, 458);
            this.butBieudo.Name = "butBieudo";
            this.butBieudo.Size = new System.Drawing.Size(70, 23);
            this.butBieudo.TabIndex = 4;
            this.butBieudo.Text = "Biểu đồ";
            this.butBieudo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBieudo.UseVisualStyleBackColor = true;
            this.butBieudo.Click += new System.EventHandler(this.butBieudo_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.MintCream;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.PaleGreen;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Blue;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_stt,
            this.Column_stt1,
            this.Column_so,
            this.ketqua,
            this.dvt,
            this.csbt_nam,
            this.csbt_nu,
            this.ten_xn,
            this.ngay,
            this.xn_id_ten});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.PaleGreen;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.GridColor = System.Drawing.Color.Silver;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 20;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(550, 452);
            this.dataGridView1.StandardTab = true;
            this.dataGridView1.TabIndex = 3;
            // 
            // Column_stt
            // 
            this.Column_stt.DataPropertyName = "id";
            this.Column_stt.HeaderText = "id";
            this.Column_stt.Name = "Column_stt";
            this.Column_stt.ReadOnly = true;
            this.Column_stt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column_stt.Visible = false;
            this.Column_stt.Width = 21;
            // 
            // Column_stt1
            // 
            this.Column_stt1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column_stt1.DataPropertyName = "ma";
            this.Column_stt1.HeaderText = "Mã XN";
            this.Column_stt1.Name = "Column_stt1";
            this.Column_stt1.ReadOnly = true;
            this.Column_stt1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column_stt1.Width = 50;
            // 
            // Column_so
            // 
            this.Column_so.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column_so.DataPropertyName = "ten";
            this.Column_so.HeaderText = "Xét nghiệm";
            this.Column_so.Name = "Column_so";
            this.Column_so.ReadOnly = true;
            this.Column_so.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column_so.Width = 160;
            // 
            // ketqua
            // 
            this.ketqua.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ketqua.DataPropertyName = "ketqua";
            this.ketqua.HeaderText = "Kết quả";
            this.ketqua.Name = "ketqua";
            this.ketqua.ReadOnly = true;
            this.ketqua.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ketqua.Width = 110;
            // 
            // dvt
            // 
            this.dvt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dvt.DataPropertyName = "donvi";
            this.dvt.HeaderText = "ĐVT";
            this.dvt.Name = "dvt";
            this.dvt.ReadOnly = true;
            this.dvt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dvt.Width = 60;
            // 
            // csbt_nam
            // 
            this.csbt_nam.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.csbt_nam.DataPropertyName = "csbt_nam";
            this.csbt_nam.HeaderText = "Bình thường(Nam)";
            this.csbt_nam.Name = "csbt_nam";
            this.csbt_nam.ReadOnly = true;
            this.csbt_nam.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // csbt_nu
            // 
            this.csbt_nu.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.csbt_nu.DataPropertyName = "csbt_nu";
            this.csbt_nu.HeaderText = "Bình thường (Nữ)";
            this.csbt_nu.Name = "csbt_nu";
            this.csbt_nu.ReadOnly = true;
            this.csbt_nu.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ten_xn
            // 
            this.ten_xn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ten_xn.HeaderText = "Tên xét nghiệm";
            this.ten_xn.Name = "ten_xn";
            this.ten_xn.ReadOnly = true;
            this.ten_xn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ten_xn.Visible = false;
            this.ten_xn.Width = 150;
            // 
            // ngay
            // 
            this.ngay.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ngay.DataPropertyName = "ngay";
            this.ngay.HeaderText = "Ngày";
            this.ngay.Name = "ngay";
            this.ngay.ReadOnly = true;
            this.ngay.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ngay.Visible = false;
            // 
            // xn_id_ten
            // 
            this.xn_id_ten.DataPropertyName = "id_ten";
            this.xn_id_ten.HeaderText = "id_ten";
            this.xn_id_ten.Name = "xn_id_ten";
            this.xn_id_ten.ReadOnly = true;
            this.xn_id_ten.Visible = false;
            this.xn_id_ten.Width = 61;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.panel11);
            this.tabPage4.Controls.Add(this.panel7);
            this.tabPage4.Controls.Add(this.panel8);
            this.tabPage4.Controls.Add(this.panel12);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(556, 484);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "Chẩn đoán hình ảnh";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // panel11
            // 
            this.panel11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel11.BackColor = System.Drawing.SystemColors.Control;
            this.panel11.Controls.Add(this.label5);
            this.panel11.Location = new System.Drawing.Point(3, 341);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(550, 16);
            this.panel11.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(0, 1);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 19);
            this.label5.TabIndex = 222;
            this.label5.Text = "Kết luận :";
            // 
            // panel7
            // 
            this.panel7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel7.Controls.Add(this.panel10);
            this.panel7.Controls.Add(this.panel9);
            this.panel7.Location = new System.Drawing.Point(3, 22);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(550, 317);
            this.panel7.TabIndex = 1;
            // 
            // panel10
            // 
            this.panel10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel10.Controls.Add(this.pnlPicture);
            this.panel10.Location = new System.Drawing.Point(252, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(298, 317);
            this.panel10.TabIndex = 0;
            // 
            // pnlPicture
            // 
            this.pnlPicture.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlPicture.AutoScroll = true;
            this.pnlPicture.BackColor = System.Drawing.SystemColors.Control;
            this.pnlPicture.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlPicture.Controls.Add(this.lblNopic);
            this.pnlPicture.Location = new System.Drawing.Point(0, 0);
            this.pnlPicture.Name = "pnlPicture";
            this.pnlPicture.Size = new System.Drawing.Size(298, 317);
            this.pnlPicture.TabIndex = 219;
            // 
            // lblNopic
            // 
            this.lblNopic.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNopic.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblNopic.Location = new System.Drawing.Point(78, 106);
            this.lblNopic.Name = "lblNopic";
            this.lblNopic.Size = new System.Drawing.Size(150, 95);
            this.lblNopic.TabIndex = 0;
            this.lblNopic.Text = "NO PICTURE";
            this.lblNopic.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblNopic.Visible = false;
            // 
            // panel9
            // 
            this.panel9.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel9.Controls.Add(this.txtMota);
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(254, 317);
            this.panel9.TabIndex = 0;
            // 
            // txtMota
            // 
            this.txtMota.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMota.BackColor = System.Drawing.SystemColors.Window;
            this.txtMota.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMota.ForeColor = System.Drawing.SystemColors.Desktop;
            this.txtMota.Location = new System.Drawing.Point(0, 0);
            this.txtMota.Multiline = true;
            this.txtMota.Name = "txtMota";
            this.txtMota.ReadOnly = true;
            this.txtMota.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtMota.Size = new System.Drawing.Size(254, 317);
            this.txtMota.TabIndex = 1;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.SystemColors.Control;
            this.panel8.Controls.Add(this.label9);
            this.panel8.Controls.Add(this.label8);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(3, 3);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(550, 19);
            this.panel8.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(255, 3);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(295, 19);
            this.label9.TabIndex = 222;
            this.label9.Text = "Hình:";
            // 
            // label8
            // 
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(10, 3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 13);
            this.label8.TabIndex = 221;
            this.label8.Text = "Mô tả:";
            // 
            // panel12
            // 
            this.panel12.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel12.Controls.Add(this.txtKetluan);
            this.panel12.Location = new System.Drawing.Point(3, 341);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(550, 140);
            this.panel12.TabIndex = 3;
            // 
            // txtKetluan
            // 
            this.txtKetluan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKetluan.BackColor = System.Drawing.SystemColors.Window;
            this.txtKetluan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKetluan.ForeColor = System.Drawing.SystemColors.Desktop;
            this.txtKetluan.Location = new System.Drawing.Point(0, 16);
            this.txtKetluan.Multiline = true;
            this.txtKetluan.Name = "txtKetluan";
            this.txtKetluan.ReadOnly = true;
            this.txtKetluan.Size = new System.Drawing.Size(550, 124);
            this.txtKetluan.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.picPreview);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(556, 484);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Xem hình";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // picPreview
            // 
            this.picPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picPreview.BackColor = System.Drawing.Color.Black;
            this.picPreview.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picPreview.Location = new System.Drawing.Point(0, 0);
            this.picPreview.Name = "picPreview";
            this.picPreview.Size = new System.Drawing.Size(556, 484);
            this.picPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picPreview.TabIndex = 3;
            this.picPreview.TabStop = false;
            this.picPreview.Click += new System.EventHandler(this.picPreview_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.treeView1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(252, 510);
            this.panel5.TabIndex = 0;
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.treeView1.BackColor = System.Drawing.SystemColors.Info;
            this.treeView1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.ForeColor = System.Drawing.Color.Navy;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(252, 510);
            this.treeView1.TabIndex = 3;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeView1_KeyDown);
            // 
            // cmdBN_New
            // 
            this.cmdBN_New.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdBN_New.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdBN_New.ForeColor = System.Drawing.Color.Black;
            this.cmdBN_New.Image = ((System.Drawing.Image)(resources.GetObject("cmdBN_New.Image")));
            this.cmdBN_New.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdBN_New.Location = new System.Drawing.Point(676, 560);
            this.cmdBN_New.Name = "cmdBN_New";
            this.cmdBN_New.Size = new System.Drawing.Size(68, 25);
            this.cmdBN_New.TabIndex = 230;
            this.cmdBN_New.Text = "    &Tiếp";
            this.cmdBN_New.UseVisualStyleBackColor = true;
            this.cmdBN_New.Click += new System.EventHandler(this.cmdBN_New_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butKetthuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butKetthuc.ForeColor = System.Drawing.Color.Black;
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(745, 560);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(71, 25);
            this.butKetthuc.TabIndex = 230;
            this.butKetthuc.Text = "    &Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.UseVisualStyleBackColor = true;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Navy;
            this.label7.Location = new System.Drawing.Point(514, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 13);
            this.label7.TabIndex = 231;
            this.label7.Text = "Địa chỉ :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // diachi
            // 
            this.diachi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.diachi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.diachi.Enabled = false;
            this.diachi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diachi.ForeColor = System.Drawing.Color.Black;
            this.diachi.Location = new System.Drawing.Point(557, 11);
            this.diachi.MaxLength = 4;
            this.diachi.Name = "diachi";
            this.diachi.Size = new System.Drawing.Size(267, 21);
            this.diachi.TabIndex = 232;
            // 
            // numSothang
            // 
            this.numSothang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numSothang.Location = new System.Drawing.Point(364, 567);
            this.numSothang.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numSothang.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numSothang.Name = "numSothang";
            this.numSothang.Size = new System.Drawing.Size(45, 20);
            this.numSothang.TabIndex = 233;
            this.numSothang.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // butXem
            // 
            this.butXem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butXem.ForeColor = System.Drawing.Color.Navy;
            this.butXem.Location = new System.Drawing.Point(307, 565);
            this.butXem.Name = "butXem";
            this.butXem.Size = new System.Drawing.Size(55, 23);
            this.butXem.TabIndex = 234;
            this.butXem.Text = "Xem";
            this.butXem.UseVisualStyleBackColor = true;
            this.butXem.Click += new System.EventHandler(this.butXem_Click);
            // 
            // chkXemtatca
            // 
            this.chkXemtatca.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkXemtatca.AutoSize = true;
            this.chkXemtatca.ForeColor = System.Drawing.Color.Navy;
            this.chkXemtatca.Location = new System.Drawing.Point(221, 569);
            this.chkXemtatca.Name = "chkXemtatca";
            this.chkXemtatca.Size = new System.Drawing.Size(77, 17);
            this.chkXemtatca.TabIndex = 235;
            this.chkXemtatca.Text = "Xem tất cả";
            this.chkXemtatca.UseVisualStyleBackColor = true;
            this.chkXemtatca.CheckedChanged += new System.EventHandler(this.chkXemtatca_CheckedChanged);
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Navy;
            this.label11.Location = new System.Drawing.Point(412, 571);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(79, 13);
            this.label11.TabIndex = 236;
            this.label11.Text = "tháng gần nhất";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmXemCanLamSan_medi
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(827, 596);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.chkXemtatca);
            this.Controls.Add(this.butXem);
            this.Controls.Add(this.numSothang);
            this.Controls.Add(this.txtMabn);
            this.Controls.Add(this.diachi);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.cmdBN_New);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtPhai);
            this.Controls.Add(this.txtHoTen);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTuoi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmXemCanLamSan_medi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hồ sơ bệnh án";
            this.Load += new System.EventHandler(this.frmXemCanLamSan_medi_Load);
            this.Resize += new System.EventHandler(this.frmXemCanLamSan_medi_Resize);
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.tabCtrl.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.pnlPicture.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).EndInit();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numSothang)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion


        private DataTable get_pttt(string nam, string xxx, decimal maql, decimal idkhoa)
        {
            DataSet ads;
            if (nam == "")
            {
                s_sql = "select a.ngay,a.tenpt,a.noidung,b.hoten as tenbs from " + xxx + ".pttt a," + user + ".dmbs b where a.ptv=b.ma and a.mabn='" + txtMabn.Text + "' and a.maql=" + maql;
                if (idkhoa != 0) s_sql += " and a.idkhoa=" + idkhoa;
                //return m.get_data(s_sql).Tables[0];
                ads = m.get_data(s_sql);
                if (ads != null && ads.Tables.Count > 0)
                {
                    return ads.Tables[0];
                }
                else
                {
                    return null;
                }
            }
            else
            {
                s_sql = "select a.ngay,a.tenpt,a.noidung,b.hoten as tenbs from xxx.pttt a," + user + ".dmbs b where a.ptv=b.ma and a.mabn='" + txtMabn.Text + "' and a.maql=" + maql;
                if (idkhoa != 0) s_sql += " and a.idkhoa=" + idkhoa;
                //return m.get_data_nam(nam,s_sql).Tables[0];
                ads = m.get_data_nam(nam, s_sql);
                if (ads != null && ads.Tables.Count > 0)
                {
                    return ads.Tables[0];
                }
                else
                {
                    return null;
                }
            }
        }
        private DataTable get_chidinh(string nam, string xxx, decimal maql, decimal idkhoa)
        {
            DataSet ads;
            if (nam == "")
            {
                s_sql = "select b.ten,a.done from " + xxx + ".v_chidinh a," + user + ".v_giavp b";
                s_sql += " where a.mavp=b.id and a.mabn='" + txtMabn.Text + "'";
                s_sql += " and a.maql=" + maql;
                if (idkhoa != 0) s_sql += " and a.idkhoa=" + idkhoa;
                ads = m.get_data(s_sql);
                if (ads != null && ads.Tables.Count > 0)
                {
                    return ads.Tables[0];
                }
                else
                {
                    return null;
                }
            }
            else
            {
                s_sql = "select b.ten,a.done from  xxx.v_chidinh a," + user + ".v_giavp b";
                s_sql += " where a.mavp=b.id and a.mabn='" + txtMabn.Text + "'";
                s_sql += " and a.maql=" + maql;
                if (idkhoa != 0) s_sql += " and a.idkhoa=" + idkhoa;
                //return m.get_data_nam(nam,s_sql).Tables[0];
                ads = m.get_data_nam(nam, s_sql);
                if (ads != null && ads.Tables.Count > 0)
                {
                    return ads.Tables[0];
                }
                else
                {
                    return null;
                }
            }
        }

        private DataTable get_thuoc(string nam, string xxx, decimal maql, decimal idkhoa)
        {
            DataSet ads = new DataSet();
            if (nam == "")
            {
                s_sql = "select b.stt,trim(c.ten)||' '||c.hamluong as ten,c.dang,trunc(b.slyeucau," + soluong_le + ") as soluong,b.cachdung from " + xxx + ".d_thuocbhytll a," + xxx + ".d_thuocbhytct b," + user + ".d_dmbd c";
                s_sql += " where a.id=b.id and b.mabd=c.id and a.mabn='" + txtMabn.Text + "'";
                s_sql += " and a.maql=" + maql;
                s_sql += " union all ";
                s_sql += " select b.stt,trim(c.ten)||' '||c.hamluong as ten,c.dang,trunc(b.soluong," + soluong_le + ") as soluong,b.cachdung from " + xxx + ".d_toathuocll a," + xxx + ".d_toathuocct b," + user + ".d_dmthuoc c";
                s_sql += " where a.id=b.id and b.mabd=c.id and a.mabn='" + txtMabn.Text + "'";
                s_sql += " and a.maql=" + maql;
                s_sql += " union all ";
                s_sql += " select b.stt,trim(c.ten)||' '||c.hamluong as ten,c.dang,trunc(b.slyeucau," + soluong_le + ") as soluong,b.cachdung from " + xxx + ".d_dutrull a," + xxx + ".d_dutruct b," + user + ".d_dmbd c";
                s_sql += " where a.id=b.id and b.mabd=c.id and a.mabn='" + txtMabn.Text + "'";
                s_sql += " and a.maql=" + maql;
                if (idkhoa != 0) s_sql += " and a.idkhoa=" + idkhoa;
                s_sql += " union all ";
                s_sql += " select b.stt,trim(c.ten)||' '||c.hamluong as ten,c.dang,trunc(b.slyeucau," + soluong_le + ") as soluong,b.cachdung from " + xxx + ".d_xtutrucll a," + xxx + ".d_xtutrucct b," + user + ".d_dmbd c";
                s_sql += " where a.id=b.id and b.mabd=c.id and a.mabn='" + txtMabn.Text + "'";
                s_sql += " and a.maql=" + maql;
                if (idkhoa != 0) s_sql += " and a.idkhoa=" + idkhoa;
                ads = m.get_data_nam (nam,s_sql);
                if (ads != null && ads.Tables.Count > 0)
                {
                    return ads.Tables[0];
                }
                else
                {
                    return null;
                }
            }
            else
            {
                s_sql = "select b.stt,trim(c.ten)||' '||c.hamluong as ten,c.dang,trunc(b.slyeucau," + soluong_le + ") as soluong,b.cachdung from xxx.d_thuocbhytll a,xxx.d_thuocbhytct b," + user + ".d_dmbd c";
                s_sql += " where a.id=b.id and b.mabd=c.id and a.mabn='" + txtMabn.Text + "'";
                s_sql += " and a.maql=" + maql;
                s_sql += " union all ";
                s_sql += " select b.stt,trim(c.ten)||' '||c.hamluong as ten,c.dang,trunc(b.slyeucau," + soluong_le + ") as soluong,b.cachdung from xxx.d_dutrull a,xxx.d_dutruct b," + user + ".d_dmbd c";
                s_sql += " where a.id=b.id and b.mabd=c.id and a.mabn='" + txtMabn.Text + "'";
                s_sql += " and a.maql=" + maql;
                if (idkhoa != 0) s_sql += " and a.idkhoa=" + idkhoa;
                s_sql += " union all ";
                s_sql += " select b.stt,trim(c.ten)||' '||c.hamluong as ten,c.dang,trunc(b.slyeucau," + soluong_le + ") as soluong,b.cachdung from xxx.d_xtutrucll a,xxx.d_xtutrucct b," + user + ".d_dmbd c";
                s_sql += " where a.id=b.id and b.mabd=c.id and a.mabn='" + txtMabn.Text + "'";
                s_sql += " and a.maql=" + maql;
                if (idkhoa != 0) s_sql += " and a.idkhoa=" + idkhoa;
                ads = m.get_data_nam(nam, s_sql);
                if (ads != null && ads.Tables.Count > 0)
                {
                    return ads.Tables[0];
                }
                else
                {
                    return null;
                }
                //return m.get_data_nam(nam,s_sql).Tables[0];
            }
        }

        private void load_tv1_2()
        {
            try
            {
                treeView1.Nodes.Clear();
                int i = -1, j = -1, k = -1, ii = -1;
                string xn = "", so = "", nhom = "", s_i = "", tmp_mmyy0 = "";
                DataSet ds_cdha = new DataSet();
                string s_sql = "", ngay, xxx,mmyy="";string [] namall = f_get_mmyy_mabn();
                int i_max_mmyy = int.Parse(numSothang.Value.ToString());
                if (i_max_mmyy > namall.Length - 1) i_max_mmyy = namall.Length - 1;
                for (int n = 0; n <= i_max_mmyy; n++) mmyy += namall[n].ToString() + "+";
                DataTable tmp = new DataTable();
                try
                {
                    tmp = f_Load_Caclanxetnghiem(txtMabn.Text.Trim(),namall).Tables[0];
                }
                catch 
                {
                }
                TreeNode anode_xn = new TreeNode(), anode_ngay;
                TreeNode anode, anoder, anodect, anodect_sa, dicom;
                TreeNode node = new TreeNode();
                TreeNode node1 = new TreeNode();
                TreeNode node2 = new TreeNode();
                TreeNode node3 = new TreeNode();
                TreeNode node4 = new TreeNode();
                TreeNode node5 = new TreeNode();
                TreeNode node6 = new TreeNode();

                nam = m.get_mabn_nam(txtMabn.Text);
                //
                if (chkXemtatca.Checked == false)
                {
                    int i_length = int.Parse(numSothang.Value.ToString()) * 5;
                    if (nam.Length > i_length) nam = nam.Substring(nam.Length - i_length);
                }
                //
                DataTable tmp1=new DataTable();

                #region tien su benh
                string noidung = "",s="";
                try
                {
                    if (m.bTiensu)
                    {
                        foreach (DataRow r in m.get_data("select * from " + user + ".theodoitsu where mabn='" + txtMabn.Text + "'").Tables[0].Rows)
                        {
                            noidung = r["noidung"].ToString();
                            break;
                        }
                        if (noidung != "")
                        {
                            node = new TreeNode();
                            node.Text = lan.Change_language_MessageText("Bệnh tiền sử");
                            node.Tag = "BTS";
                            treeView1.Nodes.Add(node);
                            node1 = new TreeNode();
                            node1.Text = noidung;
                            node.Nodes.Add(node1);
                            i++;
                        }
                    }
                    else
                    {
                        DataTable tmpts = m.get_data("select * from " + user + ".dmtheodoi order by stt").Tables[0];
                        foreach (DataRow r in m.get_data("select * from " + user + ".theodoitsu where mabn='" + txtMabn.Text + "'").Tables[0].Rows)
                        {
                            s = r["noidung"].ToString();
                            break;
                        }
                        if (s != "")
                        {
                            node = new TreeNode();
                            node.Text = lan.Change_language_MessageText("Tiền sử bệnh");
                            node.Tag = "BTS";
                            treeView1.Nodes.Add(node);
                            foreach (DataRow r in tmpts.Rows)
                            {
                                if (s.IndexOf(r["id"].ToString().PadLeft(3, '0') + "+") != -1)
                                {
                                    node1 = new TreeNode();
                                    node1.Text = r["ten"].ToString();
                                    node.Nodes.Add(node1);
                                }
                            }
                            i++;
                        }
                    }
                }
                catch { }
                #endregion

                #region benh man tinh
                try
                {
                    DataTable tmpmt = m.get_data("select * from " + user + ".benhmantinh where mabn='" + txtMabn.Text + "'").Tables[0];
                    if (tmpmt.Rows.Count > 0)
                    {
                        node = new TreeNode();
                        node.Text = lan.Change_language_MessageText("Bệnh mãn tính");
                        node.Tag = "BMT";
                        treeView1.Nodes.Add(node);
                        foreach (DataRow r in tmpmt.Rows)
                        {
                            node1 = new TreeNode();
                            node1.Text = r["chandoan"].ToString();
                            node.Nodes.Add(node1);
                            if (r["ghichu"].ToString() != "")
                            {
                                node2 = new TreeNode();
                                node2.Text = r["ghichu"].ToString();
                                node1.Nodes.Add(node2);
                            }
                        }
                        i++;
                    }
                }
                catch { }
                #endregion

                #region di ung thuoc
                try
                {
                    s_sql = "select distinct a.mahc,b.ten,a.mucdo,c.ten as tenmucdo from " + user + ".diungthuoc a," + user + ".d_dmhoatchat b," + user + ".mucdodiung c";
                    s_sql += " where a.mahc=b.ma and a.mucdo=c.id and a.mabn='" + txtMabn.Text + "'";
                    DataTable tmpmt = m.get_data(s_sql).Tables[0];
                    if (tmpmt.Rows.Count > 0)
                    {
                        node = new TreeNode();
                        node.Text = lan.Change_language_MessageText("Dị ứng thuốc");
                        node.Tag = "DUT";
                        treeView1.Nodes.Add(node);
                        foreach (DataRow r in tmpmt.Rows)
                        {
                            node1 = new TreeNode();
                            node1.Text = r["ten"].ToString();
                            node.Nodes.Add(node1);
                        }
                        i++;
                    }
                }
                catch { }
                #endregion

                #region kham benh
                node = new TreeNode();
                node.Text = lan.Change_language_MessageText("Khám bệnh");
                node.Tag = "KB";
                treeView1.Nodes.Add(node);
                try
                {
                    foreach (DataRow r in m.get_data_nam(nam, "select a.maql,a.ngay,a.makp,b.tenkp,a.chandoan,to_char(a.ngay,'yyyymmdd') as yyyymmdd from xxx.benhanpk a," + user + ".btdkp_bv b where a.makp=b.makp and a.mabn='" + txtMabn.Text + "' and mangtr=0").Tables[0].Select("true", "yyyymmdd desc"))
                    {
                        node1 = new TreeNode();
                        ngay = m.DateToString("dd/MM/yyyy HH:mm", DateTime.Parse(r["ngay"].ToString()));
                        node1.Text = r["tenkp"].ToString().Trim() + " : [" + ngay + "]";
                        node.Nodes.Add(node1);
                        node2 = new TreeNode();
                        node2.Text = r["chandoan"].ToString();
                        node1.Nodes.Add(node2);

                        tmp_mmyy0 = m.mmyy(ngay);
                        if (m.bMmyy(tmp_mmyy0))
                        {
                            xxx = user + tmp_mmyy0;//m.mmyy(ngay);
                            //xxx = user + m.mmyy(ngay);
                            tmp1 = get_thuoc("", xxx, decimal.Parse(r["maql"].ToString()), 0);
                            if (tmp1 != null && tmp1.Rows.Count > 0)
                            {
                                node3 = new TreeNode();
                                node3.Text = "Thuốc";
                                node1.Nodes.Add(node3);
                                foreach (DataRow r1 in tmp1.Rows)
                                {
                                    node4 = new TreeNode();
                                    node4.Text = r1["ten"].ToString().Trim() + " " + r1["soluong"].ToString().Trim() + " " + r1["dang"].ToString().Trim();
                                    node3.Nodes.Add(node4);
                                }
                            }

                            tmp1 = get_chidinh("", xxx, decimal.Parse(r["maql"].ToString()), 0);
                            if (tmp1 != null && tmp1.Rows.Count > 0)
                            {
                                node3 = new TreeNode();
                                node3.Text = "Chỉ định cận lâm sàng";
                                node1.Nodes.Add(node3);
                                foreach (DataRow r1 in tmp1.Rows)
                                {
                                    node4 = new TreeNode();
                                    node4.Text = r1["ten"].ToString().Trim();
                                    node3.Nodes.Add(node4);
                                }
                            }
                            tmp1 = get_pttt("", xxx, decimal.Parse(r["maql"].ToString()), 0);
                            if (tmp1 != null && tmp1.Rows.Count > 0)
                            {
                                node3 = new TreeNode();
                                node3.Text = "Phẫu thủ thuật";
                                node1.Nodes.Add(node3);
                                foreach (DataRow r1 in tmp1.Rows)
                                {
                                    ngay = m.DateToString("dd/MM/yyyy HH:mm", DateTime.Parse(r1["ngay"].ToString()));
                                    node4 = new TreeNode();
                                    node4.Text = ngay + " " + r1["tenbs"].ToString();
                                    node3.Nodes.Add(node4);
                                    node5 = new TreeNode();
                                    node5.Text = r1["tenpt"].ToString();
                                    node4.Nodes.Add(node5);
                                    if (r1["noidung"].ToString() != "")
                                    {
                                        node2 = new TreeNode();
                                        node2.Text = r1["noidung"].ToString();
                                        node5.Nodes.Add(node2);
                                    }
                                }
                            }
                        }
                    }
                }
                catch { }
                i ++;
                #endregion

                #region ngoai tru
                node = new TreeNode();
                node.Text = "Ngoại trú";
                node.Tag = "NGTRU";
                treeView1.Nodes.Add(node);
                try
                {
                    foreach (DataRow r in m.get_data("select a.maql,a.ngay,a.chandoan,b.tenkp,a.ngayrv from " + user + ".benhanngtr a," + user + ".btdkp_bv b where a.makp=b.makp and a.mabn='" + txtMabn.Text + "' order by a.ngay desc").Tables[0].Rows)
                    {
                        node1 = new TreeNode();
                        ngay = m.DateToString("dd/MM/yyyy HH:mm", DateTime.Parse(r["ngay"].ToString()));
                        if (r["ngayrv"].ToString() != "") ngay += " - " + m.DateToString("dd/MM/yyyy HH:mm", DateTime.Parse(r["ngayrv"].ToString()));
                        node1.Text = r["tenkp"].ToString().Trim() + " : [" + ngay + "]";
                        node.Nodes.Add(node1);
                        node2 = new TreeNode();
                        node2.Text = r["chandoan"].ToString();
                        node1.Nodes.Add(node2);
                        tmp_mmyy0 = m.mmyy(ngay);
                        if (m.bMmyy(tmp_mmyy0))
                        {
                            xxx = user + tmp_mmyy0;//m.mmyy(ngay);
                            tmp1 = get_thuoc("", xxx, decimal.Parse(r["maql"].ToString()), 0);
                            if (tmp1 != null && tmp1.Rows.Count > 0)
                            {
                                node3 = new TreeNode();
                                node3.Text = "Thuốc";
                                node1.Nodes.Add(node3);
                                foreach (DataRow r1 in tmp1.Rows)
                                {
                                    node4 = new TreeNode();
                                    node4.Text = r1["ten"].ToString().Trim() + " " + r1["soluong"].ToString().Trim() + " " + r1["dang"].ToString().Trim();
                                    node3.Nodes.Add(node4);
                                }
                            }
                            tmp1 = get_chidinh("", xxx, decimal.Parse(r["maql"].ToString()), 0);
                            if (tmp1 != null && tmp1.Rows.Count > 0)
                            {
                                node3 = new TreeNode();
                                node3.Text = "Chỉ định cận lâm sàng";
                                node1.Nodes.Add(node3);
                                foreach (DataRow r1 in tmp1.Rows)
                                {
                                    node4 = new TreeNode();
                                    node4.Text = r1["ten"].ToString().Trim();
                                    node3.Nodes.Add(node4);
                                }
                            }

                            tmp1 = get_pttt("", xxx, decimal.Parse(r["maql"].ToString()), 0);
                            if (tmp1 != null && tmp1.Rows.Count > 0)
                            {
                                node3 = new TreeNode();
                                node3.Text = "Phẫu thủ thuật";
                                node1.Nodes.Add(node3);
                                foreach (DataRow r1 in tmp1.Rows)
                                {
                                    ngay = m.DateToString("dd/MM/yyyy HH:mm", DateTime.Parse(r1["ngay"].ToString()));
                                    node4 = new TreeNode();
                                    node4.Text = ngay + " " + r1["tenbs"].ToString();
                                    node3.Nodes.Add(node4);
                                    node5 = new TreeNode();
                                    node5.Text = r1["tenpt"].ToString();
                                    node4.Nodes.Add(node5);
                                    if (r1["noidung"].ToString() != "")
                                    {
                                        node2 = new TreeNode();
                                        node2.Text = r1["noidung"].ToString();
                                        node5.Nodes.Add(node2);
                                    }
                                }
                            }
                        }

                        //tai khám
                        tmp1 = m.get_data_nam(nam, "select maql,ngay,chandoan,to_char(ngay,'yyyymmdd') as yyyymmdd from xxx.benhanpk where mangtr=" + decimal.Parse(r["maql"].ToString()) + " and mabn='" + txtMabn.Text + "'").Tables[0];
                        if (tmp1 != null && tmp1.Rows.Count > 0)
                        {
                            node2 = new TreeNode();
                            node2.Text = "Tái khám";
                            node1.Nodes.Add(node2);
                            foreach (DataRow r2 in tmp1.Select("true", "yyyymmdd desc"))
                            {
                                ngay = m.DateToString("dd/MM/yyyy HH:mm", DateTime.Parse(r2["ngay"].ToString()));
                                node5 = new TreeNode();
                                node5.Text = ngay;
                                node2.Nodes.Add(node5);
                                node4 = new TreeNode();
                                node4.Text = r2["chandoan"].ToString();
                                node5.Nodes.Add(node4);
                                tmp_mmyy0 = m.mmyy(ngay);
                                if (m.bMmyy(tmp_mmyy0))
                                {
                                    xxx = user + tmp_mmyy0;// m.mmyy(ngay);
                                    tmp1 = get_thuoc("", xxx, decimal.Parse(r2["maql"].ToString()), 0);
                                    if (tmp1 != null && tmp1.Rows.Count > 0)
                                    {
                                        node3 = new TreeNode();
                                        node3.Text = "Thuốc";
                                        node5.Nodes.Add(node3);
                                        foreach (DataRow r1 in tmp1.Rows)
                                        {
                                            node4 = new TreeNode();
                                            node4.Text = r1["ten"].ToString().Trim() + " " + r1["soluong"].ToString().Trim() + " " + r1["dang"].ToString().Trim();
                                            node3.Nodes.Add(node4);
                                        }
                                    }
                                    tmp1 = get_chidinh("", xxx, decimal.Parse(r2["maql"].ToString()), 0);
                                    if (tmp1 != null && tmp1.Rows.Count > 0)
                                    {
                                        node3 = new TreeNode();
                                        node3.Text = "Chỉ định cận lâm sàng";
                                        node5.Nodes.Add(node3);
                                        foreach (DataRow r1 in tmp1.Rows)
                                        {
                                            node4 = new TreeNode();
                                            node4.Text = r1["ten"].ToString().Trim();
                                            node3.Nodes.Add(node4);
                                        }
                                    }
                                    tmp1 = get_pttt("", xxx, decimal.Parse(r2["maql"].ToString()), 0);
                                    if (tmp1 != null && tmp1.Rows.Count > 0)
                                    {
                                        node3 = new TreeNode();
                                        node3.Text = "Phẫu thủ thuật";
                                        node5.Nodes.Add(node3);
                                        foreach (DataRow r1 in tmp1.Rows)
                                        {
                                            ngay = m.DateToString("dd/MM/yyyy HH:mm", DateTime.Parse(r1["ngay"].ToString()));
                                            node4 = new TreeNode();
                                            node4.Text = ngay + " " + r1["tenbs"].ToString();
                                            node3.Nodes.Add(node4);
                                            node6 = new TreeNode();
                                            node6.Text = r1["tenpt"].ToString();
                                            node4.Nodes.Add(node6);
                                            if (r1["noidung"].ToString() != "")
                                            {
                                                node2 = new TreeNode();
                                                node2.Text = r1["noidung"].ToString();
                                                node6.Nodes.Add(node2);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                catch { }
                i ++;
                #endregion

                #region phong luu
                node = new TreeNode();
                node.Text = lan.Change_language_MessageText("Phòng lưu");
                node.Tag = "PL";
                treeView1.Nodes.Add(node);
                try
                {
                    foreach (DataRow r in m.get_data_nam(nam, "select maql,ngay,chandoan,ngayrv,to_char(ngay,'yyyymmdd') as yyyymmdd from xxx.benhancc where mabn='" + txtMabn.Text + "'").Tables[0].Select("true", "yyyymmdd desc"))
                    {
                        node1 = new TreeNode();
                        ngay = m.DateToString("dd/MM/yyyy HH:mm", DateTime.Parse(r["ngay"].ToString()));
                        if (r["ngayrv"].ToString() != "") ngay += " - " + m.DateToString("dd/MM/yyyy HH:mm", DateTime.Parse(r["ngayrv"].ToString()));
                        node1.Text = ngay;
                        node.Nodes.Add(node1);
                        node2 = new TreeNode();
                        node2.Text = r["chandoan"].ToString();
                        node1.Nodes.Add(node2);
                        tmp_mmyy0 = m.mmyy(ngay);
                        if (m.bMmyy(tmp_mmyy0))
                        {
                            xxx = user + tmp_mmyy0;
                            //xxx = user + m.mmyy(ngay);
                            tmp1 = get_thuoc("", xxx, decimal.Parse(r["maql"].ToString()), 0);
                            if (tmp1 != null && tmp1.Rows.Count > 0)
                            {
                                node3 = new TreeNode();
                                node3.Text = "Thuốc";
                                node1.Nodes.Add(node3);
                                foreach (DataRow r1 in tmp1.Rows)
                                {
                                    node4 = new TreeNode();
                                    node4.Text = r1["ten"].ToString().Trim() + " " + r1["soluong"].ToString().Trim() + " " + r1["dang"].ToString().Trim();
                                    node3.Nodes.Add(node4);
                                }
                            }

                            tmp1 = get_chidinh("", xxx, decimal.Parse(r["maql"].ToString()), 0);
                            if (tmp1 != null && tmp1.Rows.Count > 0)
                            {
                                node3 = new TreeNode();
                                node3.Text = "Chỉ định cận lâm sàng";
                                node1.Nodes.Add(node3);
                                foreach (DataRow r1 in tmp1.Rows)
                                {
                                    node4 = new TreeNode();
                                    node4.Text = r1["ten"].ToString().Trim();
                                    node3.Nodes.Add(node4);
                                }
                            }
                            tmp1 = get_pttt("", xxx, decimal.Parse(r["maql"].ToString()), 0);
                            if (tmp1 != null && tmp1.Rows.Count > 0)
                            {
                                node3 = new TreeNode();
                                node3.Text = "Phẫu thủ thuật";
                                node1.Nodes.Add(node3);
                                foreach (DataRow r1 in tmp1.Rows)
                                {
                                    ngay = m.DateToString("dd/MM/yyyy HH:mm", DateTime.Parse(r1["ngay"].ToString()));
                                    node4 = new TreeNode();
                                    node4.Text = ngay + " " + r1["tenbs"].ToString();
                                    node3.Nodes.Add(node4);
                                    node5 = new TreeNode();
                                    node5.Text = r1["tenpt"].ToString();
                                    node4.Nodes.Add(node5);
                                    if (r1["noidung"].ToString() != "")
                                    {
                                        node2 = new TreeNode();
                                        node2.Text = r1["noidung"].ToString();
                                        node5.Nodes.Add(node2);
                                    }
                                }
                            }
                        }
                    }                
                }
                catch { }
                i ++;
                #endregion

                #region noi tru
                node = new TreeNode();
                node.Text = "Nội trú";
                node.Tag = "NOITRU";
                treeView1.Nodes.Add(node);
                try
                {
                    foreach (DataRow r in m.get_data("select a.maql,a.ngay,a.chandoan,b.tenkp,c.ngay as ngayrv from " + user + ".benhandt a inner join " + user + ".btdkp_bv b on  a.makp=b.makp left join " + user + ".xuatvien c on a.maql=c.maql where a.loaiba=1 and a.mabn='" + txtMabn.Text + "' order by a.ngay desc").Tables[0].Rows)
                    {
                        node1 = new TreeNode();
                        ngay = m.DateToString("dd/MM/yyyy HH:mm", DateTime.Parse(r["ngay"].ToString()));
                        if (r["ngayrv"].ToString() != "") ngay += " - " + m.DateToString("dd/MM/yyyy HH:mm", DateTime.Parse(r["ngayrv"].ToString()));
                        node1.Text = r["tenkp"].ToString().Trim() + " : [" + ngay + "]";
                        node.Nodes.Add(node1);
                        node2 = new TreeNode();
                        node2.Text = r["chandoan"].ToString();
                        node1.Nodes.Add(node2);
                        foreach (DataRow r1 in m.get_data("select a.id,a.ngay,a.chandoan,b.tenkp,c.ngay as ngayrv from " + user + ".nhapkhoa a inner join " + user + ".btdkp_bv b on a.makp=b.makp left join " + user + ".xuatkhoa c on a.id=c.id where a.maql=" + decimal.Parse(r["maql"].ToString()) + " order by a.ngay desc").Tables[0].Rows)
                        {
                            node3 = new TreeNode();
                            ngay = m.DateToString("dd/MM/yyyy HH:mm", DateTime.Parse(r1["ngay"].ToString()));
                            if (r1["ngayrv"].ToString() != "") ngay += " - " + m.DateToString("dd/MM/yyyy HH:mm", DateTime.Parse(r1["ngayrv"].ToString()));
                            node3.Text = r1["tenkp"].ToString().Trim() + " : [" + ngay + "]";
                            node2.Nodes.Add(node3);
                            node4 = new TreeNode();
                            node4.Text = r1["chandoan"].ToString();
                            node3.Nodes.Add(node4);

                            tmp1 = get_thuoc(mmyy, "", decimal.Parse(r["maql"].ToString()), decimal.Parse(r1["id"].ToString()));
                            if (tmp1 != null && tmp1.Rows.Count > 0)
                            {
                                node1 = new TreeNode();
                                node1.Text = "Thuốc";
                                node4.Nodes.Add(node1);
                                foreach (DataRow r2 in tmp1.Rows)
                                {
                                    node5 = new TreeNode();
                                    node5.Text = r2["ten"].ToString().Trim() + " " + r2["soluong"].ToString().Trim() + " " + r2["dang"].ToString().Trim();
                                    node1.Nodes.Add(node5);
                                }
                            }

                            tmp1 = get_chidinh(mmyy, "", decimal.Parse(r["maql"].ToString()), decimal.Parse(r1["id"].ToString()));
                            if (tmp1 != null && tmp1.Rows.Count > 0)
                            {
                                node1 = new TreeNode();
                                node1.Text = "Chỉ định cận lâm sàng";
                                node4.Nodes.Add(node1);
                                foreach (DataRow r2 in tmp1.Rows)
                                {
                                    node5 = new TreeNode();
                                    node5.Text = r2["ten"].ToString().Trim();
                                    node1.Nodes.Add(node5);
                                }
                            }
                            tmp1 = get_pttt(nam, "", decimal.Parse(r["maql"].ToString()), decimal.Parse(r1["id"].ToString()));
                            if (tmp1 != null && tmp1.Rows.Count > 0)
                            {
                                node1 = new TreeNode();
                                node1.Text = "Phẫu thủ thuật";
                                node4.Nodes.Add(node1);
                                foreach (DataRow r2 in tmp1.Rows)
                                {
                                    ngay = m.DateToString("dd/MM/yyyy HH:mm", DateTime.Parse(r2["ngay"].ToString()));
                                    node5 = new TreeNode();
                                    node5.Text = ngay + " " + r2["tenbs"].ToString();
                                    node1.Nodes.Add(node5);
                                    node6 = new TreeNode();
                                    node6.Text = r2["tenpt"].ToString();
                                    node5.Nodes.Add(node6);
                                    if (r2["noidung"].ToString() != "")
                                    {
                                        node3 = new TreeNode();
                                        node3.Text = r2["noidung"].ToString();
                                        node6.Nodes.Add(node3);
                                    }
                                }
                            }
                        }
                    }
                }
                catch { }
                i ++;
                #endregion

                #region  XN Thuý
                xn = lan.Change_language_MessageText("Xét nghiệm");
                anode_xn = new TreeNode(xn);
                anode_xn.Tag = "XN";
                treeView1.Nodes.Add(anode_xn);
                try
                {
                    i++; j = -1; k = -1; ii = -1;
                    int h = 0;//số thu tu node nhom_ten tren treeview
                    so = ""; nhom = ""; s_i = "";
                    foreach (DataRow r in tmp.Rows)
                    {
                        if (s_i != r["ngay"].ToString())
                        {
                            s_i = r["ngay"].ToString();
                            anode_ngay = new TreeNode(lan.Change_language_MessageText("Ngày : ") + "[ " + r["ngay"].ToString() + " ]");
                            anode_ngay.Tag = s_i + ", , , " + "XN";
                            treeView1.Nodes[i].Nodes.Add(anode_ngay);
                            ii++; j = -1; k = -1; h = 0;

                            so = ""; nhom = "";
                        }
                        if (so != r["so_ten"].ToString())
                        {
                            so = r["so_ten"].ToString();
                            treeView1.Nodes[i].Nodes[ii].Nodes.Add(r["so_ten"].ToString() + " (" + r["so_ma"].ToString() + ")" + "[ " + r["ngay"].ToString() + " ]");
                            j++; k = -1; h = 0;
                            treeView1.Nodes[i].Nodes[ii].Nodes[j].Tag = r["so_ma"].ToString() + ", ,XN";// gam 05-05-2011
                            nhom = "";
                        }
                        if (r["nhom_ten"].ToString() != "")//&& r["loai_ten"].ToString()!="")
                        {
                            if (nhom != r["nhom_ten"].ToString())
                            {
                                nhom = r["nhom_ten"].ToString();
                                treeView1.Nodes[i].Nodes[ii].Nodes[j].Nodes.Add(r["nhom_ten"].ToString() + " (" + r["nhom_ma"].ToString() + ")" + "[ " + r["ngay"].ToString() + " ]");
                                treeView1.Nodes[i].Nodes[ii].Nodes[j].Nodes[h].Tag = r["so_ma"].ToString() + "," + r["id"].ToString() + "," + " ,XN";// gam
                                k++; h++;

                            }

                        }
                        //if (r["nhom_ten"].ToString() != "")// && r["loai_ten"].ToString()=="")
                        //{
                        //    if (nhom != r["nhom_ten"].ToString())
                        //    {
                        //        nhom = r["nhom_ten"].ToString();
                        //        treeView1.Nodes[i].Nodes[ii].Nodes[j].Nodes.Add(r["nhom_ten"].ToString() + " (" + r["nhom_ma"].ToString() + ")");
                        //        k++;

                        //    }

                        //}
                        if (r["nhom_ten"].ToString() == "")// && r["loai_ten"].ToString()=="")
                        {
                            treeView1.Nodes[i].Nodes[ii].Nodes[j].Nodes.Add(r["ten_ten"].ToString() + " (" + r["ten_ma"].ToString() + ")");

                        }


                    }
                }
                catch { }
                anode_xn.Expand();
                #endregion

                #region CDHA+PACS

                string s_mabn = "", _sa = "01+03", xq = "02", _NS = "04";

                anode = new TreeNode("");
                anode.Tag = "";
                dicom = new TreeNode("");
                dicom.Tag = "";
                anoder = new TreeNode("");
                anoder.Tag = "";
                anodect = new TreeNode("");
                anodect.Tag = "";
                anodect_sa = new TreeNode("");
                anodect_sa.Tag = "";
                treeView1.Sorted = false;
                anode = new TreeNode(lan.Change_language_MessageText("Chẩn đoán hình ảnh"));
                s_sql = "select * from " + m.user + ".cdha_loai order by id";
                ds_cdha = m.get_data(s_sql);
                DataTable dttmp = new DataTable();
                string l_sa = "", l_xq = "", l_ns = "", l_dt = "", l_ct = "", l_mri = "";
                s_i = "";
                foreach (DataRow r2 in ds_cdha.Tables[0].Rows)
                {
                    switch (r2["id"].ToString())
                    {
                        case "01": //SA
                            s_i = "";
                            if (l_sa == "")
                            {
                                anoder = new TreeNode();
                                anoder.Nodes.Clear();
                                l_sa = "SA";
                                anoder = new TreeNode(lan.Change_language_MessageText("Siêu âm"));
                                anoder.Tag = "SA";
                                anode.Nodes.Add(anoder);
                            }
                            try
                            {
                                dttmp = f_Load_Caclanchandoanhinhanh("01", txtMabn.Text, namall).Tables[0];
                            }
                            catch
                            { }
                            foreach (DataRow ro in dttmp.Rows)
                            {
                                if (s_i != ro["m_ngay"].ToString())
                                {
                                    s_i = ro["m_ngay"].ToString();
                                    s_mabn = ro["mabn"].ToString();
                                    anodect = new TreeNode(lan.Change_language_MessageText("Ngày : ") + "[ " + s_i.Substring(0, 10) + " " + ro["gio"].ToString() + " ]");
                                    anodect.Tag = ro["id"].ToString();
                                    anodect_sa = new TreeNode(ro["tenkt"].ToString());
                                    anodect_sa.Tag = ro["mainkey"].ToString() + ",SA" + "," + ro["id"].ToString(); 
                                    anodect.Nodes.Add(anodect_sa);
                                    if (anodect.Nodes.Count > 0)
                                        anoder.Nodes.Add(anodect);

                                }
                                else
                                {
                                    anodect_sa = new TreeNode();
                                    anodect_sa = new TreeNode(ro["tenkt"].ToString());
                                    anodect_sa.Tag = ro["mainkey"].ToString() + "," + (_sa.IndexOf(ro["id_loai"].ToString()) >= 0 ? "SA" : "");
                                    anodect.Nodes.Add(anodect_sa);
                                }

                            }

                            break;
                        case "02":	 //XQ
                            s_i = "";
                            if (l_xq == "")
                            {
                                l_xq = "XQ";
                                anoder = new TreeNode();
                                anoder.Nodes.Clear();
                                anoder = new TreeNode(lan.Change_language_MessageText("X-Quang"));
                                anoder.Tag = "XQ";
                                anode.Nodes.Add(anoder);
                            }
                            try
                            {
                                dttmp = f_Load_Caclanchandoanhinhanh("02", txtMabn.Text, namall).Tables[0];
                            }
                            catch
                            { }
                            foreach (DataRow ro in dttmp.Rows)
                            {
                                if (s_i != ro["m_ngay"].ToString())
                                {
                                    s_i = ro["m_ngay"].ToString();
                                    s_mabn = ro["mabn"].ToString();
                                    anodect = new TreeNode(lan.Change_language_MessageText("Ngày : ") + "[ " + s_i.Substring(0, 10) + " " + ro["gio"].ToString() + " ]");
                                    anodect.Tag = ro["id"].ToString();
                                    anodect_sa = new TreeNode(ro["tenkt"].ToString());
                                    anodect_sa.Tag = ro["mainkey"].ToString() + ",XQ";
                                    anodect.Nodes.Add(anodect_sa);
                                    if (anodect.Nodes.Count > 0)
                                        anoder.Nodes.Add(anodect);
                                }
                                else
                                {
                                    anodect_sa = new TreeNode(ro["tenkt"].ToString());
                                    anodect_sa.Tag = ro["mainkey"].ToString() + ",XQ";
                                    anodect.Nodes.Add(anodect_sa);
                                }

                            }
                            break;
                        case "03":	//NS		
                            s_i = "";
                            if (l_ns == "")
                            {
                                l_ns = "NS";
                                anoder = new TreeNode();
                                anoder.Nodes.Clear();
                                anoder = new TreeNode(lan.Change_language_MessageText("Nội soi"));
                                anoder.Tag = "NS";
                                anode.Nodes.Add(anoder);
                            }
                            try
                            {
                                dttmp = f_Load_Caclanchandoanhinhanh("03", txtMabn.Text, namall).Tables[0];
                            }
                            catch
                            { }
                            foreach (DataRow ro in dttmp.Rows)
                            {
                                if (s_i != ro["m_ngay"].ToString())
                                {
                                    s_i = ro["m_ngay"].ToString();
                                    s_mabn = ro["mabn"].ToString();
                                    anodect = new TreeNode(lan.Change_language_MessageText("Ngày : ") + "[ " + s_i.Substring(0, 10) + " " + ro["gio"].ToString() + " ]");
                                    anodect.Tag = ro["id"].ToString();
                                    anodect_sa = new TreeNode(ro["tenkt"].ToString());
                                    anodect_sa.Tag = ro["mainkey"].ToString() + ",NS";
                                    anodect.Nodes.Add(anodect_sa);
                                    if (anodect.Nodes.Count > 0)
                                        anoder.Nodes.Add(anodect);

                                }
                                else
                                {
                                    anodect_sa = new TreeNode();
                                    anodect_sa = new TreeNode(ro["tenkt"].ToString());
                                    anodect_sa.Tag = ro["mainkey"].ToString() + ",NS";
                                    anodect.Nodes.Add(anodect_sa);
                                }
                            }
                            break;
                        case "04":	//DT
                            s_i = "";
                            if (l_dt == "")
                            {
                                l_dt = "DT";
                                anoder = new TreeNode();
                                anoder.Nodes.Clear();
                                anoder = new TreeNode(lan.Change_language_MessageText("Điện tim"));
                                anoder.Tag = "DT";
                                anode.Nodes.Add(anoder);
                            }
                            try
                            {
                                dttmp = f_Load_Caclanchandoanhinhanh("04", txtMabn.Text, namall).Tables[0];
                            }
                            catch { }
                            foreach (DataRow ro in dttmp.Rows)
                            {
                                if (s_i != ro["m_ngay"].ToString())
                                {
                                    s_i = ro["m_ngay"].ToString();
                                    s_mabn = ro["mabn"].ToString();
                                    anodect = new TreeNode(lan.Change_language_MessageText("Ngày : ") + "[ " + s_i.Substring(0, 10) + " " + ro["gio"].ToString() + " ]");
                                    anodect.Tag = ro["id"].ToString();
                                    anodect_sa = new TreeNode(ro["tenkt"].ToString());
                                    anodect_sa.Tag = ro["mainkey"].ToString() + ",DT";
                                    anodect.Nodes.Add(anodect_sa);
                                    if (anodect.Nodes.Count > 0)
                                        anoder.Nodes.Add(anodect);
                                }
                                else
                                {
                                    anodect_sa = new TreeNode(ro["tenkt"].ToString());
                                    anodect_sa.Tag = ro["mainkey"].ToString() + ",DT";
                                    anodect.Nodes.Add(anodect_sa);
                                }

                            }
                            break;
                        case "05":	 //CT_Scan
                            s_i = "";
                            if (l_ct == "")
                            {
                                l_ct = "CT_Scan";
                                anoder = new TreeNode();
                                anoder.Nodes.Clear();
                                anoder = new TreeNode(lan.Change_language_MessageText("CT_Scan"));
                                anoder.Tag = "CT";
                                anode.Nodes.Add(anoder);
                            }
                            try
                            {
                                dttmp = f_Load_Caclanchandoanhinhanh("05", txtMabn.Text, namall).Tables[0];
                            }
                            catch { } 
                            foreach (DataRow ro in dttmp.Rows)
                            {
                                if (s_i != ro["m_ngay"].ToString())
                                {
                                    s_i = ro["m_ngay"].ToString();
                                    s_mabn = ro["mabn"].ToString();
                                    anodect = new TreeNode(lan.Change_language_MessageText("Ngày : ") + "[ " + s_i.Substring(0, 10) + " " + ro["gio"].ToString() + " ]");
                                    anodect.Tag = ro["id"].ToString();
                                    anodect_sa = new TreeNode(ro["tenkt"].ToString());
                                    anodect_sa.Tag = ro["mainkey"].ToString() + ",CT_Scan";
                                    anodect.Nodes.Add(anodect_sa);
                                    if (anodect.Nodes.Count > 0)
                                        anoder.Nodes.Add(anodect);
                                }
                                else
                                {
                                    anodect_sa = new TreeNode(ro["tenkt"].ToString());
                                    anodect_sa.Tag = ro["mainkey"].ToString() + ",CT_Scan";
                                    anodect.Nodes.Add(anodect_sa);
                                }

                            }
                            break;
                        case "06":	 //MRI //gam 21/12/2011
                            s_i = "";
                            if (l_mri == "")
                            {
                                l_mri = "MRI";
                                anoder = new TreeNode();
                                anoder.Nodes.Clear();
                                anoder = new TreeNode(lan.Change_language_MessageText("MRI"));
                                anoder.Tag = "MRI";
                                anode.Nodes.Add(anoder);
                            }
                            try
                            {
                                dttmp = f_Load_Caclanchandoanhinhanh("06", txtMabn.Text, namall).Tables[0];
                            }
                            catch { }
                            foreach (DataRow ro in dttmp.Rows)
                            {
                                if (s_i != ro["m_ngay"].ToString())
                                {
                                    s_i = ro["m_ngay"].ToString();
                                    s_mabn = ro["mabn"].ToString();
                                    anodect = new TreeNode(lan.Change_language_MessageText("Ngày : ") + "[ " + s_i.Substring(0, 10) + " " + ro["gio"].ToString() + " ]");
                                    anodect.Tag = ro["id"].ToString();
                                    anodect_sa = new TreeNode(ro["tenkt"].ToString());
                                    anodect_sa.Tag = ro["mainkey"].ToString() + ",MRI";
                                    anodect.Nodes.Add(anodect_sa);
                                    if (anodect.Nodes.Count > 0)
                                        anoder.Nodes.Add(anodect);
                                }
                                else
                                {
                                    anodect_sa = new TreeNode(ro["tenkt"].ToString());
                                    anodect_sa.Tag = ro["mainkey"].ToString() + ",MRI";
                                    anodect.Nodes.Add(anodect_sa);
                                }

                            }
                            break;
                    }
                }
                #endregion

                if (anode.Nodes.Count > 0)
                {
                    treeView1.Nodes.Add(anode);

                    anode.Expand();

                }



            }
            catch //(Exception ex)
            {
              //  MessageBox.Show(ex.ToString());
            }

        }
        private void load_tv1_1()
        {
            try
            {
                treeView1.Nodes.Clear();
                int i = -1, j = -1, k = -1, ii = -1;
                string xn = "", so = "", nhom = "", s_i = "";

                DataSet ds_cdha = new DataSet();

                string s_sql = "";

                s_sql = "select a.mabn,i.ma so_ma,";
                s_sql += " i.ten as so_ten,a.sophieu,g.ma as nhom_ma,g.ten as nhom_ten,";
                s_sql += " e.ma as ten_ma,e.ten as ten_ten,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay";
                s_sql += " from medibvmmyy.xn_phieu a ";
                s_sql += " inner join medibvmmyy.xn_ketqua b on a.id=b.id";
                s_sql += " inner join medibv.xn_bv_chitiet c on  b.id_ten=c.id";
                s_sql += " inner join medibv.xn_ten e on c.id_ten=e.id";
                s_sql += " inner join medibv.xn_nhom g on e.id_nhom=g.id";
                s_sql += " inner join medibv.xn_so i on g.id_so=i.id";
                s_sql += " where  a.mabn='" + txtMabn.Text + "'";
                s_sql += " order by a.ngay desc";

                DataTable tmp = new DataTable();
                //tmp = f_Load_Caclanxetnghiem(txtMabn.Text.Trim(), f_get_mmyy_mabn()).Tables[0];
                tmp = m_v.get_data_all(s_sql).Tables[0];

                TreeNode anode_xn = new TreeNode(), anode_ngay;
                TreeNode anode, anoder, anodect, anodect_sa, dicom;

                #region  XN Thuý
                xn = lan.Change_language_MessageText("Xét nghiệm");
                anode_xn = new TreeNode(xn);
                anode_xn.Tag = "XN";
                treeView1.Nodes.Add(anode_xn);
                i++; j = -1; k = -1; ii = -1;
                so = ""; nhom = ""; s_i = "";
                foreach (DataRow r in tmp.Rows)
                {
                    if (s_i != r["ngay"].ToString())
                    {
                        s_i = r["ngay"].ToString();
                        anode_ngay = new TreeNode(lan.Change_language_MessageText("Ngày : ") + "[ " + r["ngay"].ToString() + " ]");
                        anode_ngay.Tag = s_i + ", , , " + "XN";
                        treeView1.Nodes[i].Nodes.Add(anode_ngay);
                        ii++; j = -1; k = -1;
                        so = ""; nhom = "";
                    }
                    if (so != r["so_ten"].ToString())
                    {
                        so = r["so_ten"].ToString();
                        treeView1.Nodes[i].Nodes[ii].Nodes.Add(r["so_ten"].ToString() + " (" + r["so_ma"].ToString() + ")");
                        j++; k = -1;
                        nhom = "";
                    }
                    if (r["nhom_ten"].ToString() != "")//&& r["loai_ten"].ToString()!="")
                    {
                        if (nhom != r["nhom_ten"].ToString())
                        {
                            nhom = r["nhom_ten"].ToString();
                            treeView1.Nodes[i].Nodes[ii].Nodes[j].Nodes.Add(r["nhom_ten"].ToString() + " (" + r["nhom_ma"].ToString() + ")");
                            k++;

                        }

                    }
                    if (r["nhom_ten"].ToString() != "")// && r["loai_ten"].ToString()=="")
                    {
                        if (nhom != r["nhom_ten"].ToString())
                        {
                            nhom = r["nhom_ten"].ToString();
                            treeView1.Nodes[i].Nodes[ii].Nodes[j].Nodes.Add(r["nhom_ten"].ToString() + " (" + r["nhom_ma"].ToString() + ")");
                            k++;

                        }

                    }
                    if (r["nhom_ten"].ToString() == "")// && r["loai_ten"].ToString()=="")
                    {
                        treeView1.Nodes[i].Nodes[ii].Nodes[j].Nodes.Add(r["ten_ten"].ToString() + " (" + r["ten_ma"].ToString() + ")");

                    }


                }
                anode_xn.Expand();
                #endregion


                #region CDHA+PACS

                string s_mabn = "", _sa = "01+03", xq = "02", _NS = "04";

                anode = new TreeNode("");
                anode.Tag = "";
                dicom = new TreeNode("");
                dicom.Tag = "";
                anoder = new TreeNode("");
                anoder.Tag = "";
                anodect = new TreeNode("");
                anodect.Tag = "";
                anodect_sa = new TreeNode("");
                anodect_sa.Tag = "";
                treeView1.Sorted = false;
                anode = new TreeNode(lan.Change_language_MessageText("Chẩn đoán hình ảnh"));
                s_sql = "select * from " + m.user + ".cdha_loai order by id";
                ds_cdha = m.get_data(s_sql);
                DataTable dttmp = new DataTable();
                string l_sa = "", l_xq = "", l_ns = "", l_dt = "", l_ct = "";
                s_i = "";
                foreach (DataRow r2 in ds_cdha.Tables[0].Rows)
                {
                    switch (r2["id"].ToString())
                    {
                        case "01": //SA
                            s_i = "";
                            if (l_sa == "")
                            {
                                anoder = new TreeNode();
                                anoder.Nodes.Clear();
                                l_sa = "SA";
                                anoder = new TreeNode(lan.Change_language_MessageText("Siêu âm"));
                                anoder.Tag = "SA";
                                anode.Nodes.Add(anoder);
                            }
                            dttmp = f_Load_Caclanchandoanhinhanh("01", txtMabn.Text,mmyy(DateTime.Now.ToString("dd/MM/yyyy"))).Tables[0];

                            foreach (DataRow ro in dttmp.Rows)
                            {
                                if (s_i != ro["m_ngay"].ToString())
                                {
                                    s_i = ro["m_ngay"].ToString();
                                    s_mabn = ro["mabn"].ToString();
                                    anodect = new TreeNode(lan.Change_language_MessageText("Ngày : ") + "[ " + s_i.Substring(0, 10) + " " + ro["gio"].ToString() + " ]");
                                    anodect.Tag = ro["id"].ToString();
                                    anodect_sa = new TreeNode(ro["tenkt"].ToString());
                                    anodect_sa.Tag = ro["mainkey"].ToString() + ",SA" + "," + ro["id"].ToString();
                                    anodect.Nodes.Add(anodect_sa);
                                    if (anodect.Nodes.Count > 0)
                                        anoder.Nodes.Add(anodect);

                                }
                                else
                                {
                                    anodect_sa = new TreeNode();
                                    anodect_sa = new TreeNode(ro["tenkt"].ToString());
                                    anodect_sa.Tag = ro["mainkey"].ToString() + "," + (_sa.IndexOf(ro["id_loai"].ToString()) >= 0 ? "SA" : "");
                                    anodect.Nodes.Add(anodect_sa);
                                }

                            }

                            break;
                        case "02":	 //XQ
                            s_i = "";
                            if (l_xq == "")
                            {
                                l_xq = "XQ";
                                anoder = new TreeNode();
                                anoder.Nodes.Clear();
                                anoder = new TreeNode(lan.Change_language_MessageText("X-Quang"));
                                anoder.Tag = "XQ";
                                anode.Nodes.Add(anoder);
                            }

                            dttmp = dttmp = f_Load_Caclanchandoanhinhanh("02", txtMabn.Text, mmyy(DateTime.Now.ToString("dd/MM/yyyy"))).Tables[0];
                            foreach (DataRow ro in dttmp.Rows)
                            {
                                if (s_i != ro["m_ngay"].ToString())
                                {
                                    s_i = ro["m_ngay"].ToString();
                                    s_mabn = ro["mabn"].ToString();
                                    anodect = new TreeNode(lan.Change_language_MessageText("Ngày : ") + "[ " + s_i.Substring(0, 10) + " " + ro["gio"].ToString() + " ]");
                                    anodect.Tag = ro["id"].ToString();
                                    anodect_sa = new TreeNode(ro["tenkt"].ToString());
                                    anodect_sa.Tag = ro["mainkey"].ToString() + ",XQ";
                                    anodect.Nodes.Add(anodect_sa);
                                    if (anodect.Nodes.Count > 0)
                                        anoder.Nodes.Add(anodect);
                                }
                                else
                                {
                                    anodect_sa = new TreeNode(ro["tenkt"].ToString());
                                    anodect_sa.Tag = ro["mainkey"].ToString() + ",XQ";
                                    anodect.Nodes.Add(anodect_sa);
                                }

                            }
                            break;
                        case "03":	//NS		
                            s_i = "";
                            if (l_ns == "")
                            {
                                l_ns = "NS";
                                anoder = new TreeNode();
                                anoder.Nodes.Clear();
                                anoder = new TreeNode(lan.Change_language_MessageText("Nội soi"));
                                anoder.Tag = "NS";
                                anode.Nodes.Add(anoder);
                            }
                            dttmp = dttmp = f_Load_Caclanchandoanhinhanh("03", txtMabn.Text, mmyy(DateTime.Now.ToString("dd/MM/yyyy"))).Tables[0];
                            foreach (DataRow ro in dttmp.Rows)
                            {
                                if (s_i != ro["m_ngay"].ToString())
                                {
                                    s_i = ro["m_ngay"].ToString();
                                    s_mabn = ro["mabn"].ToString();
                                    anodect = new TreeNode(lan.Change_language_MessageText("Ngày : ") + "[ " + s_i.Substring(0, 10) + " " + ro["gio"].ToString() + " ]");
                                    anodect.Tag = ro["id"].ToString();
                                    anodect_sa = new TreeNode(ro["tenkt"].ToString());
                                    anodect_sa.Tag = ro["mainkey"].ToString() + ",NS";
                                    anodect.Nodes.Add(anodect_sa);
                                    if (anodect.Nodes.Count > 0)
                                        anoder.Nodes.Add(anodect);

                                }
                                else
                                {
                                    anodect_sa = new TreeNode();
                                    anodect_sa = new TreeNode(ro["tenkt"].ToString());
                                    anodect_sa.Tag = ro["mainkey"].ToString() + ",NS";
                                    anodect.Nodes.Add(anodect_sa);
                                }
                            }
                            break;
                        case "04":	//DT
                            s_i = "";
                            if (l_dt == "")
                            {
                                l_dt = "DT";
                                anoder = new TreeNode();
                                anoder.Nodes.Clear();
                                anoder = new TreeNode(lan.Change_language_MessageText("Điện tim"));
                                anoder.Tag = "DT";
                                anode.Nodes.Add(anoder);
                            }
                            dttmp = dttmp = f_Load_Caclanchandoanhinhanh("04", txtMabn.Text, mmyy(DateTime.Now.ToString("dd/MM/yyyy"))).Tables[0];
                            foreach (DataRow ro in dttmp.Rows)
                            {
                                if (s_i != ro["m_ngay"].ToString())
                                {
                                    s_i = ro["m_ngay"].ToString();
                                    s_mabn = ro["mabn"].ToString();
                                    anodect = new TreeNode(lan.Change_language_MessageText("Ngày : ") + "[ " + s_i.Substring(0, 10) + " " + ro["gio"].ToString() + " ]");
                                    anodect.Tag = ro["id"].ToString();
                                    anodect_sa = new TreeNode(ro["tenkt"].ToString());
                                    anodect_sa.Tag = ro["mainkey"].ToString() + ",DT";
                                    anodect.Nodes.Add(anodect_sa);
                                    if (anodect.Nodes.Count > 0)
                                        anoder.Nodes.Add(anodect);
                                }
                                else
                                {
                                    anodect_sa = new TreeNode(ro["tenkt"].ToString());
                                    anodect_sa.Tag = ro["mainkey"].ToString() + ",DT";
                                    anodect.Nodes.Add(anodect_sa);
                                }

                            }
                            break;
                        case "05":	 //CT_Scan
                            s_i = "";
                            if (l_ct == "")
                            {
                                l_ct = "CT_Scan";
                                anoder = new TreeNode();
                                anoder.Nodes.Clear();
                                anoder = new TreeNode(lan.Change_language_MessageText("CT_Scan"));
                                anoder.Tag = "CT";
                                anode.Nodes.Add(anoder);
                            }

                            dttmp = dttmp = f_Load_Caclanchandoanhinhanh("05", txtMabn.Text, mmyy(DateTime.Now.ToString("dd/MM/yyyy"))).Tables[0];
                            foreach (DataRow ro in dttmp.Rows)
                            {
                                if (s_i != ro["m_ngay"].ToString())
                                {
                                    s_i = ro["m_ngay"].ToString();
                                    s_mabn = ro["mabn"].ToString();
                                    anodect = new TreeNode(lan.Change_language_MessageText("Ngày : ") + "[ " + s_i.Substring(0, 10) + " " + ro["gio"].ToString() + " ]");
                                    anodect.Tag = ro["id"].ToString();
                                    anodect_sa = new TreeNode(ro["tenkt"].ToString());
                                    anodect_sa.Tag = ro["mainkey"].ToString() + ",CT_Scan";
                                    anodect.Nodes.Add(anodect_sa);
                                    if (anodect.Nodes.Count > 0)
                                        anoder.Nodes.Add(anodect);
                                }
                                else
                                {
                                    anodect_sa = new TreeNode(ro["tenkt"].ToString());
                                    anodect_sa.Tag = ro["mainkey"].ToString() + ",CT_Scan";
                                    anodect.Nodes.Add(anodect_sa);
                                }

                            }
                            break;
                    }
                }
                #endregion

                if (anode.Nodes.Count > 0)
                {
                    treeView1.Nodes.Add(anode);

                    anode.Expand();

                }
            }
            catch //(Exception ex)
            {
              //  MessageBox.Show(ex.ToString());
            }

        }
        private string[] f_get_mmyy_mabn()
        {
            string[] s_nam = null;
            string m_nam = "";
            try
            {
                
                m_nam = m.get_mabn_nam(txtMabn.Text);//.Substring(0, 4);
                nam = m_nam;
                if (chkXemtatca.Checked == false)
                {
                    int i_length = int.Parse(numSothang.Value.ToString()) * 5;
                    if (m_nam.Length > i_length) m_nam = m_nam.Substring(m_nam.Length - i_length);
                }
                ////string s_sql = "select * from medibv.table where substr(mmyy,3,2)||substr(mmyy,1,2)>='" + nam.Substring(2, 2) + nam.Substring(0, 2) + "' order by substr(mmyy,3,2) desc,substr(mmyy,1,2) desc";
                ////int immyy = 0;
                ////int i_max_mmyy = int.Parse(numSothang.Value.ToString());
                ////if (chkXemtatca.Checked) i_max_mmyy = 0;
                ////foreach (DataRow r in m.get_data(s_sql).Tables[0].Rows)
                ////{
                ////    if (immyy > i_max_mmyy && i_max_mmyy > 0) break;
                ////    immyy += 1;
                ////    m_nam += r["mmyy"].ToString() + "+";
                ////}
                //////m_nam = m.get_data("select nam from " + m.user + ".btdbn where mabn='" + txtMabn.Text + "'").Tables[0].Rows[0][0].ToString();//
                ////m_nam = m_nam.Trim().Substring(0, m_nam.Trim().Length - 1);
                s_nam= m_nam.Trim().Trim('+').Split('+');
                //s_nam = "";
            }
            catch
            {
                return null;
            }
            return s_nam;
        }
        private DataSet f_Load_Caclanxetnghiem(string s_mabn, string[] s_nam)
        {
            string s_mmyy = "";
            string s_sql = "";
            string user = m.user;
            //nam = m.get_mabn_nam(s_mabn);
            DataSet dstmp = new DataSet();
            DataSet ads1;// = new DataSet();
            try
            {
                if (s_nam.Length > 0)
                {
                    for (int i = 0; i <= s_nam.Length - 1; i++)
                    {
                        s_mmyy = s_nam[i].ToString();
                        if (s_mmyy.Trim() != "" && m.bMmyy(s_mmyy)) 
                        {
                            s_sql = "select a.id,a.mabn,i.ma so_ma,";
                            s_sql += " i.ten as so_ten,a.sophieu,g.ma as nhom_ma,g.ten as nhom_ten,";
                            s_sql += " e.ma as ten_ma,e.ten as ten_ten,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay";
                            s_sql += " from " + user + s_mmyy + ".xn_phieu a ";
                            s_sql += " inner join " + user + s_mmyy + ".xn_ketqua b on a.id=b.id";
                            s_sql += " inner join medibv.xn_bv_chitiet c on  b.id_ten=c.id";
                            s_sql += " inner join medibv.xn_ten e on c.id_ten=e.id";
                            s_sql += " inner join medibv.xn_nhom g on e.id_nhom=g.id";
                            s_sql += " inner join medibv.xn_so i on g.id_so=i.id";
                            s_sql += " where  a.mabn='" + txtMabn.Text + "'";
                            s_sql += " order by a.ngay desc";                            
                            if (dstmp == null|| dstmp.Tables.Count <=0 || dstmp.Tables[0].Rows.Count <=0)
                            {
                                dstmp = m.get_data(s_sql);
                            }
                            else 
                            {
                                ads1 = m.get_data(s_sql);
                                dstmp.Merge(ads1.Tables[0].Copy());
                            }                            
                        }
                    }
                }
            }
            catch
            {
                return null;
            }
            return dstmp;
        }
        private DataSet f_Load_Caclanchandoanhinhanh(string s_loaicdha, string s_mabn, string[] s_nam)
        {
            string s_mmyy = "";
            string s_sql = "";
            string user = m.user;
            DataSet dstmp = new DataSet();
            DataSet ads1;
            try
            {
                if (s_nam.Length > 0)
                {
                    for (int i = 0; i <= s_nam.Length - 1; i++)
                    {

                        s_mmyy = s_nam[i].ToString();
                        if (m.bMmyy(s_mmyy))
                        {
                            s_sql = "select a.*,to_char(a.ngay,'dd/mm/yyyy') as m_ngay,b.makt,c.tenkt,a.id||','||b.makt||','||to_char(a.ngay,'dd/mm/yyyy') as mainkey  ";
                            s_sql += "  from " + user + s_mmyy + ".cdha_bnll a,";
                            s_sql += user + s_mmyy + ".cdha_bnct b ,";
                            s_sql += user + ".cdha_kythuat c";
                            s_sql += " where a.id=b.id and b.makt=c.makt "+
                                " and a.mabn='"+s_mabn+"' and  a.id_loai='" + s_loaicdha + "' order by a.ngay desc";;
                            if (dstmp == null || dstmp.Tables.Count <= 0 || dstmp.Tables[0].Rows.Count <= 0)
                            {
                                dstmp = m.get_data(s_sql);
                            }
                            else
                            {
                                ads1 = m.get_data(s_sql);
                                dstmp.Merge(ads1.Tables[0].Copy());
                            }
                        }
                    }
                }
            }
            catch
            {
                return null;
            }
            return dstmp;
        }
        private DataSet f_Load_Caclanchandoanhinhanh(string s_loaicdha, string s_mabn, string s_mmyy)
        {           
            string s_sql = "";
            string user = m.user;
            DataSet dstmp = new DataSet();
            try
            {
                
                s_sql = "select a.*,to_char(a.ngay,'dd/mm/yyyy') as m_ngay,b.makt,c.tenkt,a.id||','||b.makt||','||to_char(a.ngay,'dd/mm/yyyy') as mainkey  ";
                s_sql += "  from " + user + s_mmyy + ".cdha_bnll a,";
                s_sql += user + s_mmyy + ".cdha_bnct b ,";
                s_sql += user + ".cdha_kythuat c";
                s_sql += " where a.id=b.id and b.makt=c.makt ";
                s_sql+=  " and a.mabn='" + s_mabn + "' and  a.id_loai='" + s_loaicdha + "' order by a.ngay desc"; ;
                dstmp=m.get_data(s_sql);
                 
            }
            catch
            {
                return null;
            }
            return dstmp;
        }

        /*
        bool bMmyy(string m_mmyy)
        {
            return m.get_data("select * from " + m.user + ".cdha_table where mmyy='" + ((m_mmyy.Trim().Length == 4) ? m_mmyy : mmyy(m_mmyy)) + "'").Tables[0].Rows.Count > 0;
        }
        */
        string mmyy(string ngay)
        {
            return ngay.Substring(3, 2) + ngay.Substring(8, 2);
        }

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

        private void load_tvkq()
		{				
			try
			{		
				treeView1.Nodes.Clear();
				
				string as_sql="";
				as_sql="select  b.id,b.id_bv_so,b.id_vienphi,b.ma,b.ten,";
				as_sql+=" a.id id_chidinh,a.mabn,a.maql,a.idkhoa,";
				as_sql+=" to_char(a.ngay,'yyyymmdd') ngay,";
				as_sql+=" a.loai,a.madoituong,a.loai,a.soluong,a.dongia,";
				as_sql+=" a.paid,c.hoten,c.ngaysinh,c.namsinh,c.phai ";
				as_sql+=" from v_chidinh a,xn_bv_ten b,btdbn c where a.mavp=b.id_vienphi and c.mabn=a.mabn ";//order by to_char(a.ngay,'yyyymmdd') desc";
				as_sql+=" order by to_char(a.ngay,'yyyymmdd') desc";
				
				DataTable tmp=m_x.get_data_all(m_tn,m_dn,as_sql).Tables[0];				
					
				tmp=m_x.get_data_all(m_tn,m_dn,as_sql).Tables[0];
				string ng="",ma="";
				int i=-1,j=-1;
				foreach(DataRow r in tmp.Rows)
				{
					if (ng!=r["ngay"].ToString())
					{
						ng=r["ngay"].ToString();
						treeView1.Nodes.Add(ng.Substring(6,2)+"/"+ng.Substring(4,2)+"/"+ng.Substring(0,4));
						ma="";i++;j=-1;
					}
					if (ma!=r["mabn"].ToString())
					{
						ma=r["mabn"].ToString();
						j++;
						treeView1.Nodes[i].Nodes.Add(r["hoten"].ToString().Trim()+" ("+r["mabn"].ToString()+")");
					}
					treeView1.Nodes[i].Nodes[j].Nodes.Add(r["ten"].ToString().Trim()+" - "+r["dongia"].ToString());
					for(int k=0;k<treeView1.Nodes[i].Nodes[j].GetNodeCount(true);k++)
					{
						if (r["paid"].ToString()=="1")
							treeView1.Nodes[i].Nodes[j].Nodes[k].ForeColor=Color.FromArgb(255,0,0);
					}
				}
				ng="";ma="";
				i=-1;j=-1;
				bool bFound;
				foreach(DataRow r in tmp.Rows)
				{
					if (ng!=r["ngay"].ToString())
					{
						ng=r["ngay"].ToString();
						ma="";i++;j=-1;
					}
					if (ma!=r["mabn"].ToString())
					{
						ma=r["mabn"].ToString();
						j++;
					}
					bFound=m_x.get_data_all(m_tn,m_dn,"select a.* from v_chidinh a,xn_phieu b,xn_ketqua c where a.mabn=b.mabn and b.id=c.id and a.mabn='"+r["mabn"].ToString()+"' and to_char(a.ngay,'yyyymmdd')='"+r["ngay"].ToString()+"'").Tables[0].Rows.Count>0;
					if (bFound)
						for(int k=0;k<treeView1.Nodes[i].Nodes[j].GetNodeCount(true);k++)	
							treeView1.Nodes[i].Nodes[j].Nodes[k].Checked=bFound;
				}
			}
			catch{}
		}

		private void txtHoTen_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void treeView1_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			string s_sql="";
			try
			{
                s_ngaycdha = "";
				string amabn1="",s_tag="";
				amabn1=e.Node.Text;
				string count_cdha="",s_makt="",s_loai="",s_mmyy="";
				string pathip=@"..\\..\\..\\xml\\thongsoIP.xml";
				DataSet dsxml=new DataSet();
				dsxml.ReadXml(pathip);
				string dir="",user="";           
                count_cdha = treeView1.SelectedNode.Parent.Tag.ToString();                  
				s_makt=treeView1.SelectedNode.Tag.ToString();
				string [] akey;						
				char[] achar=new char[]{','};
                akey = s_makt.Split(achar);
                user = m.user;
				if (akey.Length>0)
				{
					count_cdha=akey[0].ToString();
					s_makt=akey[1].ToString();
                    try
                    {
                        s_mmyy = m.user + akey[2].ToString().Substring(3, 2) + akey[2].ToString().Substring(8, 2);
                        s_ngaycdha = akey[2].ToString();
                    }
                    catch
                    {
                        s_mmyy = m.user;
                        s_ngaycdha = "";
                    }
					s_loai= akey[3].ToString().Trim();
				}
				switch (s_loai)
				{
                    case "SA":
                    case "XQ":
                    case "NS":
                    case "MRI":
                    case "DT":
                        {
                            tabCtrl.SelectedTab = tabCtrl.TabPages[1];
                            txtMota.Text = "";
                            txtKetluan.Text = "";
                            pnlPicture.Controls.Clear();
                            Load_kq_cdha(s_loai, count_cdha, s_makt, s_mmyy);
                            break;
                        }
                    case "XN":
                        {
                            tabCtrl.SelectedTab = tabCtrl.TabPages[0];
                            int i = amabn1.IndexOf("[");
                            int j = amabn1.IndexOf("]");
                            amabn1 = amabn1.Substring(i + 1, (j - i - 1));
                            DataSet ads = new DataSet();


                            s_sql = "select a.id,to_char(g.ngay,'dd/mm/yyyy hh24:mi') as ngay,";
                            s_sql += " d.ma, d.ten, f.ten as donvi, d.csbt_nam, d.csbt_nu, ";
                            s_sql += " c.ten as ten_xn,c.id as id_bv_ten, a.ketqua,b.id_ten  ";
                            s_sql += " from medibvmmyy.xn_phieu g";
                            s_sql += " inner join medibvmmyy.xn_ketqua a on g.id=a.id";
                            s_sql += " left join medibv.xn_bv_chitiet b on a.id_ten=b.id";
                            s_sql += " left join medibv.xn_bv_ten c on b.id_bv_ten=c.id";
                            s_sql += " left join medibv.xn_ten d on b.id_ten=d.id";
                            s_sql += " left join medibv.xn_donvi f on d.donvi=f.id";
                            s_sql += " where  g.mabn='" + txtMabn.Text + "'";
                            s_sql += " and to_char(g.ngay,'dd/mm/yyyy hh24:mi')='" + amabn1.Trim() + "'";
                            s_sql += " order by g.ngay desc, c.ten, d.ten";

                            ads = m_v.get_data_bc_1(amabn1.Trim().Substring(0, 10), amabn1.Trim().Substring(0, 10), s_sql);

                            DataSet set = ads.Clone();
                            string str = "";
                            int num = 0;
                            foreach (DataRow r in ads.Tables[0].Select("", "id_bv_ten"))
                            {
                                if (str != r["id_bv_ten"].ToString())
                                {
                                    num++;
                                    str = r["id_bv_ten"].ToString();
                                    DataRow r12 = ads.Tables[0].NewRow();
                                    r12["id"] = "0";
                                    r12["ma"] = "  " + num.ToString().PadLeft(3, '0');

                                    r12["ten"] = r["ten_xn"].ToString();
                                    r12["donvi"] = "";
                                    r12["csbt_nam"] = "";
                                    r12["csbt_nu"] = "";
                                    r12["ketqua"] = "";
                                    r12["ten_xn"] = "";
                                    r12["ngay"] = "";
                                    r12["id_bv_ten"] = r["id_bv_ten"].ToString();
                                    set.Tables[0].Rows.Add(r12.ItemArray);
                                }
                                set.Tables[0].Rows.Add(r.ItemArray);
                            }

                            set.Tables[0].Columns.Remove("id_bv_ten");
                            set.Tables[0].Columns.Remove("ten_xn");
                            dataGridView1.DataSource = set.Tables[0];
                            f_Format_DG1(dataGridView1);

                            break;
                        }
                    case "PS":
                        {

                            tabCtrl.SelectedTab = tabCtrl.TabPages[2];
                            try
                            {
                                dir = dsxml.Tables[0].Rows[0]["c4"].ToString() + @"\" + s_makt;// +".DCM";

                            }
                            catch (Exception ex1)
                            {
                                MessageBox.Show(ex1.ToString());
                            }

                            break;
                        }
                    case "CT_Scan":// gam 05-05-2011
                        {
                            tabCtrl.SelectedTab = tabCtrl.TabPages[1];
                            txtMota.Text = "";
                            txtKetluan.Text = "";
                            pnlPicture.Controls.Clear();
                            Load_kq_cdha(s_loai, count_cdha, s_makt, s_mmyy);
                            break;
                        }
                   
				}
			}				
			 catch( Exception ex)
			{
				
			}
			
		}

        private void f_Format_DG1(DataGridView v_dg)
        {
            try
            {
                //check each row
                for (int row = 0; row < v_dg.Rows.Count; row++)
                {
                    f_Format_DG1(v_dg, row);
                }
            }
            catch
            {
            }
        }
        private void f_Format_DG1(DataGridView v_dg, int v_row)
        {
            try
            {
                //get the text in the cell
                string aval = v_dg.Rows[v_row].Cells["Column_stt"].Value.ToString();
                //MessageBox.Show(aval);
                Color acolor = Color.White;
                Color acolor1 = Color.White;
                switch (aval)
                {
                    case "0":
                        acolor = SystemColors.Control;
                        break;
                    default:
                        acolor = Color.White;
                        break;
                }
                acolor1 = Color.FromArgb(255 - acolor.R, 255 - acolor.G, 255 - acolor.B);
                if (aval == "0")
                {
                    acolor1 = Color.Blue;
                    
                }
                for (int i = 0; i < v_dg.ColumnCount; i++)
                {
                    v_dg.Rows[v_row].Cells[i].Style.BackColor = acolor;
                    v_dg.Rows[v_row].Cells[i].Style.ForeColor = acolor1;
                    v_dg.Rows[v_row].Cells[i].Style.SelectionBackColor = acolor;
                    v_dg.Rows[v_row].Cells[i].Style.SelectionForeColor = acolor1;
                }
                v_dg.Rows[v_row].Cells["Column_stt"].ReadOnly = aval != "0";

            }
            catch
            {
            }
        }



 

		
		private void Load_kq_cdha(string loaicdha,string n_count_cdha,string s_makt,string m_usermmyy)
		{
			string s_sql="",file_hinh=""; 
			DataTable dtTemp = new DataTable();
			switch (loaicdha)
			{
				case "SA":
				case "NS":
                case "DT":
                case "CT_Scan":
                case "MRI":
                case "XQ":
            
                    s_sql = "select * from " + m_usermmyy + ".cdha_bnct where id=" + n_count_cdha + " and makt='" + s_makt + "'";
					dtTemp=m.get_data(s_sql).Tables[0];
					foreach(DataRow r in dtTemp.Rows)
					{
						txtMota.Text=r["mota"].ToString();
						txtKetluan.Text=r["ketluan"].ToString();
						
					}
                    if (bQuanlyhinhDatabase)
                    {
                        get_image_cdha(decimal.Parse(n_count_cdha), s_makt, m_usermmyy);
                    }
                    else
                    {
                        f_Load_Image_Server(decimal.Parse(n_count_cdha), s_makt,txtMabn.Text.Trim(),s_ngaycdha);
                    }
					break;			           
			}
			
		}


        private void f_Load_Image_Server(decimal count_cdha, string makt, string mabn, string ngaycdha)
        {
            string apath_thumuc_maychu = "", ayymmdd = "", afilename = "", amabn = "", acount_cdha = "", amakt = "", achon = "0", adk = "";
            int x = 0, y = pnlPicture.Left,sohinh=0;
            ayymmdd = ngaycdha.Substring(8, 2) + ngaycdha.Substring(3, 2) + ngaycdha.Substring(0, 2);
            apath_thumuc_maychu = s_Path_image_Maychu + "\\" + ayymmdd;
            adk = mabn + "_" + count_cdha + "_" + makt + "*";
            if (Directory.Exists(apath_thumuc_maychu))
            {
                string[] sf = System.IO.Directory.GetFiles(apath_thumuc_maychu, adk);
                for (int i = 0; i < sf.Length; i++)
                {

                    afilename = sf[i].Substring(sf[i].LastIndexOf("\\") + 1);
                    if (afilename != "" && (afilename.IndexOf(".jpg") != -1 || afilename.IndexOf(".bmp") != -1))
                    {
                        amabn = afilename.Split('_')[0];
                        acount_cdha = afilename.Split('_')[1];
                        amakt = afilename.Split('_')[2];
                        achon = afilename.Split('_')[3];
                        if (amabn == mabn && count_cdha.ToString() == acount_cdha && amakt == makt)
                        {
                            PictureBox b = new PictureBox();
                            Bitmap bm = new Bitmap(apath_thumuc_maychu + "\\" + afilename);
                            b.Image = (Bitmap)bm;
                            b.Width = 100;
                            b.Height = 100;
                            if (sohinh>=3)
                            {                                
                                b.Top = b.Width+3;
                                b.Left = y;
                                y = pnlPicture.Left + b.Left+102 ;
                            }
                            else if (sohinh >= 6)
                            {
                                b.Top = b.Width + 3;
                                b.Left = y;
                                y = pnlPicture.Left + b.Left + 102;
                            }
                            else
                            {
                                b.Top = 0;
                                b.Left = x;
                            }
                            b.Tag = apath_thumuc_maychu + "\\" + afilename;
                            b.Click += new System.EventHandler(this.pic1_Click);                            
                            x += b.Width + 2;
                            b.SizeMode = PictureBoxSizeMode.StretchImage;
                            b.BorderStyle = BorderStyle.Fixed3D;
                            b.Cursor = Cursors.Hand;
                            pnlPicture.Controls.Add(b);
                            sohinh += 1;
                        }
                    }
                }
            }
        }
        private void pic1_Click(object sender, System.EventArgs e)
        {
            try
            {
                PictureBox l = (PictureBox)(sender);
                picPreview.Image = l.Image;

                int w_s = l.Width;
                int h_s = l.Height;
                int w = 0, h = 0;

                if (w_s <= 400 && h_s <= 400)
                {
                    w = w_s;
                    h = h_s;
                }
                else
                {
                    if (w_s >= h_s)
                    {
                        w = 400;
                        h = 400 * h_s / w_s;
                    }
                    else
                    {
                        h = 400;
                        w = w_s * 400 / h_s;
                    }
                }
                l.Width = w;
                l.Height = h;
                l.SizeMode = PictureBoxSizeMode.StretchImage;
                tabCtrl.SelectedIndex = 2;

            }
            catch
            {
            }
        }

      

		private void treeView1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			try
			{
				if(e.KeyCode==Keys.Enter)
				{
					string atmp = "";
					if(treeView1.SelectedNode.Parent==null)
					{
						atmp=treeView1.SelectedNode.Tag.ToString();
					}
					else
					{
						atmp=treeView1.SelectedNode.Parent.Tag.ToString();
					}					
				}
			}
			catch{}
		}



		private void frmXemCanLamSan_medi_Load(object sender, System.EventArgs e)
        {
            if (bbadt)
            {
                this.Location = new System.Drawing.Point(188 - 38, 120);//151
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                this.Size = new Size(829 + 40, 579);
            }
            if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            user = m.user;
            soluong_le = d.d_soluong_le(m.nhom_duoc);
		    load_option();
            txtTungay.Value = DateTime.Now;
            if (txtMabn.Text != "")
            {
                txtMabn_Validating(null, null);
            }
            //this.ShowInTaskbar = false;
		}
		private void f_loadHC()
		{
			string amabn="";
			amabn=txtMabn.Text;
            string s_sql = "";
            s_sql = "select a.mabn, a.hoten, nvl(to_char(a.ngaysinh,'dd/mm/yyyy'),a.namsinh) as ngaysinh,";
            s_sql += " a.phai, a.matt, a.maqu, a.maphuongxa, trim(trim(a.sonha)||' '||trim(a.thon)) as sonha,";
            s_sql += " a.cholam,d.tentt,c.tenquan,b.tenpxa ";
            s_sql += " FROM " + m.user + ".btdbn a  ";
            s_sql += " inner join " + m.user + ".btdpxa b on a.maphuongxa=b.maphuongxa";
            s_sql += " inner join " + m.user + ".btdquan c on a.maqu=c.maqu ";
            s_sql += " inner join " + m.user + ".btdtt d on a.matt=d.matt ";
            s_sql += " where a.mabn='" + amabn + "'";// and rownum <=1";
			DataTable dttmp = m.get_data(s_sql).Tables[0];
			foreach(DataRow r in dttmp.Rows )
			{
				txtHoTen.Text=r["hoten"].ToString();
				txtTuoi.Text=r["ngaysinh"].ToString();
				if (r["phai"].ToString()=="0")
					txtPhai.Text="Nam";
				else
					txtPhai.Text="Nữ";
                diachi.Text = r["sonha"].ToString() + " " + r["tenpxa"].ToString().Trim() + " " + r["tenquan"].ToString().Trim() + " " + r["tentt"].ToString();
			}
		}
		private void load_option()
		{
			DataSet dstem = new DataSet();
			dstem.ReadXml(@"..\..\..\xml\phongto.xml",XmlReadMode.ReadSchema);
			DataRow r;
			if (dstem.Tables[0].Rows.Count>0)
			{
				r=dstem.Tables[0].Rows[0];
				menu200.Checked=(r["menu"].ToString()=="menu200");
				menu400.Checked=(r["menu"].ToString()=="menu400");
				menu600.Checked=(r["menu"].ToString()=="menu600");
				menu800.Checked=(r["menu"].ToString()=="menu800");
			}
		}
		private void save_option()
		{
			DataSet dstemp = new DataSet();
			DataRow r;
			try
			{
				dstemp.Tables.Add("Zoom");
				dstemp.Tables[0].Columns.Add("menu",typeof(string));
				dstemp.Tables[0].Columns.Add("h",typeof(string));
				dstemp.Tables[0].Columns.Add("w",typeof(string));
				r=dstemp.Tables[0].NewRow();
				if (menu200.Checked)
				{
					menu400.Checked=false;
					menu600.Checked=false;
					menu800.Checked=false;
					r["menu"]="menu200";
					r["h"]="200";
					r["w"]="200";
					dstemp.Tables[0].Rows.Add(r);
				}
				if (menu400.Checked)
				{
					menu200.Checked=false;
					menu600.Checked=false;
					menu800.Checked=false;
					r["menu"]="menu400";
					r["h"]="400";
					r["w"]="400";
					dstemp.Tables[0].Rows.Add(r);
				}
				if (menu600.Checked)
				{
					menu200.Checked=false;
					menu400.Checked=false;
					menu800.Checked=false;
					r["menu"]="menu600";
					r["h"]="600";
					r["w"]="600";
					dstemp.Tables[0].Rows.Add(r);
				}
				if (menu800.Checked)
				{
					menu400.Checked=false;
					menu600.Checked=false;
					menu200.Checked=false;
					r["menu"]="menu800";
					r["h"]="800";
					r["w"]="800";
					dstemp.Tables[0].Rows.Add(r);
				}
				dstemp.WriteXml(@"..\..\..\xml\phongto.xml",XmlWriteMode.WriteSchema);
			}
			catch
			{	
				
			}

		}

		private void menu800_Click(object sender, System.EventArgs e)
		{
			menu800.Checked=!menu800.Checked;
			menu200.Checked=false;
			menu400.Checked=false;
			menu600.Checked=false;
			
			save_option();
		}

		private void menu600_Click(object sender, System.EventArgs e)
		{
			menu600.Checked=!menu600.Checked;
			menu200.Checked=false;
			menu400.Checked=false;
			menu800.Checked=false;
			save_option();
		}

		private void menu400_Click(object sender, System.EventArgs e)
		{
			menu400.Checked=!menu400.Checked;
			menu200.Checked=false;
			menu600.Checked=false;
			menu800.Checked=false;
			save_option();
		}
	
		
		private void load_picture(DataTable dttemp,string s_loai )
		{
			int index=0;
			int X=0;
			int Y=0;
			string path="",file_hinh="";
			pnlPicture.Controls.Clear();
			foreach(DataRow r in dttemp.Rows)
			{
				index++;
				Pb[index]=new PictureBox();
				Pb[index].Size = new System.Drawing.Size(238, 268);
				if(X<225) //576
				{
					Pb[index].Location = new System.Drawing.Point(X,Y);
					X+=Pb[index].Size.Width;     
				}
				else
				{
					X=0;
					Y+=Pb[index].Size.Height;
					Pb[index].Location = new System.Drawing.Point(X,Y);
				}
				Pb[index].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
				//Pb[index].Click +=new EventHandler(Pb_Clk);
				if (r["filename"].ToString()!="")
					file_hinh=r["filename"].ToString();
				else
					file_hinh="none.bmp";
				switch (s_loai)
				{
					case "SA":
						path=@"..\..\..\sieuam\media\sieuam\imagesvr\"+file_hinh;
						break;
					case "NS":
						path=@"..\..\..\sieuam\media\noisoi\imagesvr\"+file_hinh;
						break;
					case "XQ":
						path=@"..\..\..\sieuam\media\noisoi\image\"+file_hinh;
						break;
					default:
						path=@"..\..\..\sieuam\media\sieuam\imagesvr\"+file_hinh;
						break;
				}
				if (! System.IO.File.Exists(path))
					path=@"..\..\..\sieuam\media\sieuam\imagesvr\none.bmp";
				Pb[index].Name =file_hinh.ToString();
				try
				{ 
					bm=new Bitmap(path);
					this.Invalidate();
					Pb[index].Image=(Bitmap)bm.Clone();
					Pb[index].SendToBack();
				}
				catch(Exception ex) 
				{
					MessageBox.Show(ex.ToString());
				}
				pnlPicture.Controls.Add(Pb[index]);
			}

		}



		private void menu200_Click(object sender, System.EventArgs e)
		{
			menu200.Checked=!menu200.Checked;
			menu400.Checked=false;
			menu600.Checked=false;
			menu800.Checked=false;
			save_option();

		}


        private void get_image_cdha(decimal count_cdha, string makt, string s_usermmyy)
		{
			try
			{
				string s_sql="select * from "+s_usermmyy+".cdha_image where id="+count_cdha+ " and makt='"+makt+"'";
				DataSet dstmp=new DataSet();
				dstmp=m.get_data(s_sql);
				int index=0,sodong=0;
				int X=0;
				int Y=0;				
				sodong=dstmp.Tables[0].Rows.Count;
				pnlPicture.Controls.Clear();
				int W=0,H=0,dong=0;
				switch (sodong)
				{
					case 1:
						W=pnlPicture.Width;
						H=pnlPicture.Height;
						dong=W;
						break;
					case 2:
					case 4:
						W=pnlPicture.Width;
						H=pnlPicture.Height;
						dong=W*2;
						break;
					case 3:
					case 5:
					case 6:
						W=pnlPicture.Width;
						H=pnlPicture.Height;
						dong=W*3;
						break;
				}
				foreach(DataRow r in dstmp.Tables[0].Rows)
				{
					index++;
					Pb[index]=new PictureBox();
					Byte[] imageadata =new Byte[0];
					imageadata =(Byte[])(r["image"]);
					MemoryStream memo=new MemoryStream(imageadata);
					Bitmap b=new Bitmap(Image.FromStream(memo));
					Pb[index].Image=(Bitmap)b;
					Pb[index].SendToBack();
					if (sodong==1)
					{
						Pb[index].SizeMode = PictureBoxSizeMode.AutoSize;	
						X=(W/2)-(Pb[index].Width/2);
						Y=(H/2)-(Pb[index].Height/2);
					}
					else
					{
						Pb[index].Size = new System.Drawing.Size(W,H);
					}
					//
					if(X<dong) //576
					{
						Pb[index].Location = new System.Drawing.Point(X,Y);
						X+=Pb[index].Size.Width;     
					}
					else
					{
						X=0;
						Y+=Pb[index].Size.Height;
						Pb[index].Location = new System.Drawing.Point(X,Y);
						X+=Pb[index].Size.Width;
					}
					Pb[index].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
					Pb[index].Name ="h"+index.ToString();
					
					try
					{ 
						this.Invalidate();
						
					}
					catch(Exception ex) 
					{
						MessageBox.Show(ex.ToString());
					}
					pnlPicture.Controls.Add(Pb[index]);
				}
			}
			catch
			{
			}
		}

		private void txtMabn_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void cmdThoat_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void cmdBN_New_Click(object sender, System.EventArgs e)
		{
			txtMabn.Text="";
			txtHoTen.Text="";
			txtPhai.Text="";
			txtTuoi.Text="";
			txtMabn.Enabled=true;
			treeView1.Nodes.Clear();
			
			
			txtMota.Text="";
			txtKetluan.Text="";
			pnlPicture.Controls.Clear();
            dataGridView1.DataSource = null;
			txtMabn.Focus();
		}

		private void txtMabn_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (txtMabn.Text=="" || txtMabn.Text.Trim().Length<3) return;
			if (txtMabn.Text.Trim().Length!=8) txtMabn.Text=txtMabn.Text.Substring(0,2)+txtMabn.Text.Substring(2).PadLeft(6,'0');
            Cursor = Cursors.WaitCursor;
			f_loadHC();
			load_tv1_2();
            Cursor = Cursors.Default;
		}

    	private void frmXemCanLamSan_medi_Resize(object sender, System.EventArgs e)
		{
			int p_w=0;
			try
			{
				p_w=(int)(System.Math.Round((decimal)(tabCtrl.Width/3)))-6;
				tabCtrl.ItemSize = new Size(p_w,25);
			}
			catch
			{}
		}

        private void picPreview_Click(object sender, EventArgs e)
        {
            tabCtrl.SelectedIndex = 1;
        }

        private void rdHienTai_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == rdHienTai) load_tv1_1();
        }

        private void rdTatCa_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl==rdTatCa) load_tv1_2();
        }

        private void butBieudo_Click(object sender, EventArgs e)
        {
            int irow = dataGridView1.CurrentCell.RowIndex;
            try
            {
                int i_id_ten = int.Parse(dataGridView1["xn_id_ten", irow].Value.ToString());
                string s_tenxn = dataGridView1["Column_so", irow].Value.ToString();
                string s_sql = "select to_char(g.ngaylaymau,'dd/mm/yy hh24:mi') as ngay,to_number(a.ketqua) as nhietdo ";
                s_sql += " from medibvmmyy.xn_phieu g";
                s_sql += " inner join medibvmmyy.xn_ketqua a on g.id=a.id";
                s_sql += " left join medibv.xn_bv_chitiet b on a.id_ten=b.id";
                s_sql += " left join medibv.xn_bv_ten c on b.id_bv_ten=c.id";
                s_sql += " left join medibv.xn_ten d on b.id_ten=d.id";
                s_sql += " left join medibv.xn_donvi f on d.donvi=f.id";
                s_sql += " where  g.mabn='" + txtMabn.Text + "'";
                s_sql += " and d.id=" + i_id_ten.ToString();
                s_sql += " and to_date(to_char(g.ngaylaymau,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + txtTungay.Text + "','dd/mm/yyyy') and to_date('" + txtDenngay.Text + "','dd/mm/yyyy')";
                s_sql += " order by g.ngaylaymau asc";
                DataTable dt = m.get_data_mmyy(s_sql, txtTungay.Text, txtDenngay.Text, false).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    dllReportM.frmReport f = new dllReportM.frmReport(m, dt, "rptTheodoixetnghiem.rpt", s_tenxn, txtHoTen.Text + "(" + txtMabn.Text + ")", "", "", "", "", "", "", "", "");
                    f.ShowDialog();
                }
            }
            catch { }
        }

        private void chkXemtatca_CheckedChanged(object sender, EventArgs e)
        {
            numSothang.Enabled = !chkXemtatca.Checked;
        }

        private void butXem_Click(object sender, EventArgs e)
        {
            if (txtMabn.Text.Trim() != "")
            {
                txtMabn_Validating(null, null);
            }
            else
            {
                MessageBox.Show(lan.Change_language_MessageText("Đề nghị nhập Mã số bệnh nhân cần xem"));
                txtMabn.Focus();
            }
        }
	}
}
