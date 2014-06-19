using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.IO;
using System.Drawing.Printing;
using System.Data;
using System.Xml;
using LibVP;


namespace Vienphi
{
	/// <summary>
	/// Summary description for frmBaocaotreem.
	/// </summary>
	public class frmBaocaotreem : System.Windows.Forms.Form
	{

        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private string m_userid="";
		private string m_quyensoid="";
		private string m_ngaythu="";
		private string m_doituongtreem="";

		private LibVP.AccessData m_v = LibVP.AccessData.GetImplement();		

		private string m_sqlloai="";
		private string m_sqlnhom="";
		private string m_sqlkb="";

		private string m_sqlloai_nt="";
		private string m_sqlnhom_nt="";

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label lbTitle;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button butKetthuc;
		private System.Windows.Forms.DateTimePicker txtDN;
		private System.Windows.Forms.DateTimePicker txtTN;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button butInBK;
		private System.Windows.Forms.DateTimePicker txtNgayIn;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox chkUserid;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton rd1;
		private System.Windows.Forms.TextBox txtKetoanvp;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtGiamdoc;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox txtNguoilapphieu;
		private System.Windows.Forms.TreeView tree_User;
		private System.Windows.Forms.CheckBox chkLoaiBN;
		private System.Windows.Forms.TreeView tree_LoaiBN;
		private System.Windows.Forms.CheckBox chkBHYT;
		private System.Windows.Forms.ComboBox cbMaubaocao;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.CheckBox chkThanhtoanravien;
		private System.Windows.Forms.CheckBox chkTructiep;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.ContextMenu contextMenu2;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem6;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.RadioButton rd4;
		private System.Windows.Forms.RadioButton rd3;
		private System.Windows.Forms.RadioButton rd2;
		private System.Windows.Forms.MenuItem menuItem7;
		private System.Windows.Forms.MenuItem menuItem8;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox cbKy;
		private System.Windows.Forms.NumericUpDown txtThang;
		private System.Windows.Forms.NumericUpDown txtNam;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.RadioButton rdNoitru;
		private System.Windows.Forms.CheckBox chkPhatsinh;
		private System.Windows.Forms.RadioButton rdNgoaitru;
		private System.Windows.Forms.TextBox timso;
		private System.Windows.Forms.TreeView tree_Quyenso;
		private System.ComponentModel.IContainer components;

		public frmBaocaotreem(string v_userid)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
			m_userid=v_userid;
			f_SetEvent(panel2);

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBaocaotreem));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbTitle = new System.Windows.Forms.Label();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.menuItem8 = new System.Windows.Forms.MenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label15 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tree_Quyenso = new System.Windows.Forms.TreeView();
            this.timso = new System.Windows.Forms.TextBox();
            this.txtNam = new System.Windows.Forms.NumericUpDown();
            this.txtThang = new System.Windows.Forms.NumericUpDown();
            this.cbKy = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkThanhtoanravien = new System.Windows.Forms.CheckBox();
            this.chkTructiep = new System.Windows.Forms.CheckBox();
            this.chkPhatsinh = new System.Windows.Forms.CheckBox();
            this.txtGiamdoc = new System.Windows.Forms.TextBox();
            this.tree_User = new System.Windows.Forms.TreeView();
            this.contextMenu2 = new System.Windows.Forms.ContextMenu();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.label9 = new System.Windows.Forms.Label();
            this.cbMaubaocao = new System.Windows.Forms.ComboBox();
            this.tree_LoaiBN = new System.Windows.Forms.TreeView();
            this.txtNguoilapphieu = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtKetoanvp = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rd2 = new System.Windows.Forms.RadioButton();
            this.rd4 = new System.Windows.Forms.RadioButton();
            this.rd3 = new System.Windows.Forms.RadioButton();
            this.rd1 = new System.Windows.Forms.RadioButton();
            this.chkUserid = new System.Windows.Forms.CheckBox();
            this.txtDN = new System.Windows.Forms.DateTimePicker();
            this.txtTN = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.butInBK = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.txtNgayIn = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.chkBHYT = new System.Windows.Forms.CheckBox();
            this.chkLoaiBN = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.rdNgoaitru = new System.Windows.Forms.RadioButton();
            this.rdNoitru = new System.Windows.Forms.RadioButton();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label11 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtThang)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.ForestGreen;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lbTitle);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(1);
            this.panel1.Size = new System.Drawing.Size(672, 49);
            this.panel1.TabIndex = 15;
            // 
            // lbTitle
            // 
            this.lbTitle.ContextMenu = this.contextMenu1;
            this.lbTitle.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbTitle.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.Color.White;
            this.lbTitle.Location = new System.Drawing.Point(71, 1);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(345, 45);
            this.lbTitle.TabIndex = 15;
            this.lbTitle.Text = "  BÁO CÁO CHI PHÍ ĐIỀU TRỊ TRẺ EM";
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // contextMenu1
            // 
            this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItem7,
            this.menuItem8});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.Text = "Write XML";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // menuItem7
            // 
            this.menuItem7.Index = 1;
            this.menuItem7.Text = "-";
            // 
            // menuItem8
            // 
            this.menuItem8.Index = 2;
            this.menuItem8.Text = "Khi báo đối tượng trẻ em";
            this.menuItem8.Click += new System.EventHandler(this.menuItem8_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(70, 45);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 63;
            this.pictureBox1.TabStop = false;
            // 
            // label15
            // 
            this.label15.Dock = System.Windows.Forms.DockStyle.Top;
            this.label15.Location = new System.Drawing.Point(3, 52);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(672, 3);
            this.label15.TabIndex = 17;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.tree_Quyenso);
            this.panel2.Controls.Add(this.timso);
            this.panel2.Controls.Add(this.txtNam);
            this.panel2.Controls.Add(this.txtThang);
            this.panel2.Controls.Add(this.cbKy);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.txtGiamdoc);
            this.panel2.Controls.Add(this.tree_User);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.cbMaubaocao);
            this.panel2.Controls.Add(this.tree_LoaiBN);
            this.panel2.Controls.Add(this.txtNguoilapphieu);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.txtKetoanvp);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.chkUserid);
            this.panel2.Controls.Add(this.txtDN);
            this.panel2.Controls.Add(this.txtTN);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.butInBK);
            this.panel2.Controls.Add(this.butKetthuc);
            this.panel2.Controls.Add(this.txtNgayIn);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.chkBHYT);
            this.panel2.Controls.Add(this.chkLoaiBN);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.rdNgoaitru);
            this.panel2.Controls.Add(this.rdNoitru);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.ForeColor = System.Drawing.Color.Navy;
            this.panel2.Location = new System.Drawing.Point(3, 55);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(672, 359);
            this.panel2.TabIndex = 18;
            // 
            // tree_Quyenso
            // 
            this.tree_Quyenso.CheckBoxes = true;
            this.tree_Quyenso.ForeColor = System.Drawing.Color.DimGray;
            this.tree_Quyenso.FullRowSelect = true;
            this.tree_Quyenso.Location = new System.Drawing.Point(254, 21);
            this.tree_Quyenso.Name = "tree_Quyenso";
            this.tree_Quyenso.ShowLines = false;
            this.tree_Quyenso.ShowPlusMinus = false;
            this.tree_Quyenso.ShowRootLines = false;
            this.tree_Quyenso.Size = new System.Drawing.Size(124, 154);
            this.tree_Quyenso.Sorted = true;
            this.tree_Quyenso.TabIndex = 213;
            // 
            // timso
            // 
            this.timso.BackColor = System.Drawing.Color.White;
            this.timso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timso.Location = new System.Drawing.Point(4, 176);
            this.timso.MaxLength = 12;
            this.timso.Name = "timso";
            this.timso.Size = new System.Drawing.Size(374, 21);
            this.timso.TabIndex = 212;
            this.timso.Text = "Tìm sổ";
            this.timso.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.timso.TextChanged += new System.EventHandler(this.timso_TextChanged);
            // 
            // txtNam
            // 
            this.txtNam.Location = new System.Drawing.Point(610, 16);
            this.txtNam.Maximum = new decimal(new int[] {
            2020,
            0,
            0,
            0});
            this.txtNam.Minimum = new decimal(new int[] {
            1990,
            0,
            0,
            0});
            this.txtNam.Name = "txtNam";
            this.txtNam.Size = new System.Drawing.Size(50, 20);
            this.txtNam.TabIndex = 9;
            this.txtNam.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNam.Value = new decimal(new int[] {
            1990,
            0,
            0,
            0});
            this.txtNam.ValueChanged += new System.EventHandler(this.txtThang_ValueChanged);
            this.txtNam.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNam_KeyDown);
            // 
            // txtThang
            // 
            this.txtThang.Location = new System.Drawing.Point(532, 16);
            this.txtThang.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.txtThang.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtThang.Name = "txtThang";
            this.txtThang.Size = new System.Drawing.Size(40, 20);
            this.txtThang.TabIndex = 8;
            this.txtThang.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtThang.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtThang.ValueChanged += new System.EventHandler(this.txtThang_ValueChanged);
            this.txtThang.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtThang_KeyDown);
            // 
            // cbKy
            // 
            this.cbKy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbKy.Items.AddRange(new object[] {
            "Từ...Đến",
            "Tháng",
            "Quý"});
            this.cbKy.Location = new System.Drawing.Point(431, 16);
            this.cbKy.Name = "cbKy";
            this.cbKy.Size = new System.Drawing.Size(82, 21);
            this.cbKy.TabIndex = 7;
            this.cbKy.SelectedIndexChanged += new System.EventHandler(this.cbKy_SelectedIndexChanged);
            this.cbKy.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbKy_KeyDown);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkThanhtoanravien);
            this.groupBox2.Controls.Add(this.chkTructiep);
            this.groupBox2.Controls.Add(this.chkPhatsinh);
            this.groupBox2.Location = new System.Drawing.Point(381, 211);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(270, 75);
            this.groupBox2.TabIndex = 206;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chứng từ";
            // 
            // chkThanhtoanravien
            // 
            this.chkThanhtoanravien.Location = new System.Drawing.Point(112, 18);
            this.chkThanhtoanravien.Name = "chkThanhtoanravien";
            this.chkThanhtoanravien.Size = new System.Drawing.Size(131, 24);
            this.chkThanhtoanravien.TabIndex = 1;
            this.chkThanhtoanravien.Text = "Thanh toán ra viện";
            // 
            // chkTructiep
            // 
            this.chkTructiep.Location = new System.Drawing.Point(11, 18);
            this.chkTructiep.Name = "chkTructiep";
            this.chkTructiep.Size = new System.Drawing.Size(131, 24);
            this.chkTructiep.TabIndex = 0;
            this.chkTructiep.Text = "Thu trực tiếp";
            // 
            // chkPhatsinh
            // 
            this.chkPhatsinh.Location = new System.Drawing.Point(11, 47);
            this.chkPhatsinh.Name = "chkPhatsinh";
            this.chkPhatsinh.Size = new System.Drawing.Size(231, 19);
            this.chkPhatsinh.TabIndex = 212;
            this.chkPhatsinh.Text = "Chỉ xem các mục có số liệu phát sinh";
            // 
            // txtGiamdoc
            // 
            this.txtGiamdoc.BackColor = System.Drawing.Color.White;
            this.txtGiamdoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGiamdoc.Location = new System.Drawing.Point(88, 332);
            this.txtGiamdoc.MaxLength = 50;
            this.txtGiamdoc.Name = "txtGiamdoc";
            this.txtGiamdoc.Size = new System.Drawing.Size(290, 21);
            this.txtGiamdoc.TabIndex = 6;
            this.txtGiamdoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtGiamdoc_KeyDown);
            // 
            // tree_User
            // 
            this.tree_User.CheckBoxes = true;
            this.tree_User.ContextMenu = this.contextMenu2;
            this.tree_User.ForeColor = System.Drawing.Color.DimGray;
            this.tree_User.FullRowSelect = true;
            this.tree_User.Location = new System.Drawing.Point(4, 21);
            this.tree_User.Name = "tree_User";
            this.tree_User.ShowLines = false;
            this.tree_User.ShowPlusMinus = false;
            this.tree_User.ShowRootLines = false;
            this.tree_User.Size = new System.Drawing.Size(374, 154);
            this.tree_User.Sorted = true;
            this.tree_User.TabIndex = 1;
            this.tree_User.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tree_User_AfterCheck);
            // 
            // contextMenu2
            // 
            this.contextMenu2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem2,
            this.menuItem5,
            this.menuItem3,
            this.menuItem6,
            this.menuItem4});
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 0;
            this.menuItem2.Text = "Đảo chọn lựa các mục cùng cấp";
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 1;
            this.menuItem5.Text = "-";
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 2;
            this.menuItem3.Text = "Chọn tất cả các mục cùng cấp";
            this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 3;
            this.menuItem6.Text = "-";
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 4;
            this.menuItem4.Text = "Không chọn tất cả các mục cùng cấp";
            this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
            // 
            // label9
            // 
            this.label9.ForeColor = System.Drawing.Color.Navy;
            this.label9.Location = new System.Drawing.Point(378, 317);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 13);
            this.label9.TabIndex = 195;
            this.label9.Text = "Mẫu báo cáo";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbMaubaocao
            // 
            this.cbMaubaocao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMaubaocao.Location = new System.Drawing.Point(380, 332);
            this.cbMaubaocao.Name = "cbMaubaocao";
            this.cbMaubaocao.Size = new System.Drawing.Size(271, 21);
            this.cbMaubaocao.TabIndex = 15;
            // 
            // tree_LoaiBN
            // 
            this.tree_LoaiBN.CheckBoxes = true;
            this.tree_LoaiBN.ForeColor = System.Drawing.Color.DimGray;
            this.tree_LoaiBN.FullRowSelect = true;
            this.tree_LoaiBN.Location = new System.Drawing.Point(4, 216);
            this.tree_LoaiBN.Name = "tree_LoaiBN";
            this.tree_LoaiBN.ShowLines = false;
            this.tree_LoaiBN.ShowPlusMinus = false;
            this.tree_LoaiBN.ShowRootLines = false;
            this.tree_LoaiBN.Size = new System.Drawing.Size(374, 70);
            this.tree_LoaiBN.Sorted = true;
            this.tree_LoaiBN.TabIndex = 3;
            this.tree_LoaiBN.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tree_LoaiBN_AfterCheck);
            // 
            // txtNguoilapphieu
            // 
            this.txtNguoilapphieu.BackColor = System.Drawing.Color.White;
            this.txtNguoilapphieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNguoilapphieu.Location = new System.Drawing.Point(88, 288);
            this.txtNguoilapphieu.MaxLength = 50;
            this.txtNguoilapphieu.Name = "txtNguoilapphieu";
            this.txtNguoilapphieu.Size = new System.Drawing.Size(290, 21);
            this.txtNguoilapphieu.TabIndex = 4;
            this.txtNguoilapphieu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNguoilapphieu_KeyDown);
            // 
            // label8
            // 
            this.label8.ForeColor = System.Drawing.Color.Navy;
            this.label8.Location = new System.Drawing.Point(2, 292);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 13);
            this.label8.TabIndex = 161;
            this.label8.Text = "Người lập phiếu";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtKetoanvp
            // 
            this.txtKetoanvp.BackColor = System.Drawing.Color.White;
            this.txtKetoanvp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKetoanvp.Location = new System.Drawing.Point(88, 310);
            this.txtKetoanvp.MaxLength = 50;
            this.txtKetoanvp.Name = "txtKetoanvp";
            this.txtKetoanvp.Size = new System.Drawing.Size(290, 21);
            this.txtKetoanvp.TabIndex = 5;
            this.txtKetoanvp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtKetoanvp_KeyDown);
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.Color.Navy;
            this.label4.Location = new System.Drawing.Point(-1, 314);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 157;
            this.label4.Text = "Kế toán";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.ForeColor = System.Drawing.Color.Navy;
            this.label7.Location = new System.Drawing.Point(1, 336);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 13);
            this.label7.TabIndex = 155;
            this.label7.Text = "Giám đốc";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rd2);
            this.groupBox1.Controls.Add(this.rd4);
            this.groupBox1.Controls.Add(this.rd3);
            this.groupBox1.Controls.Add(this.rd1);
            this.groupBox1.Location = new System.Drawing.Point(390, 91);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(274, 106);
            this.groupBox1.TabIndex = 146;
            this.groupBox1.TabStop = false;
            this.groupBox1.Tag = "1";
            this.groupBox1.Text = "Tùy chọn";
            // 
            // rd2
            // 
            this.rd2.Location = new System.Drawing.Point(10, 36);
            this.rd2.Name = "rd2";
            this.rd2.Size = new System.Drawing.Size(229, 22);
            this.rd2.TabIndex = 1;
            this.rd2.Text = "Báo cáo tổng hợp theo nhóm viện phí";
            this.rd2.CheckedChanged += new System.EventHandler(this.rd_CheckedChanged);
            // 
            // rd4
            // 
            this.rd4.BackColor = System.Drawing.SystemColors.Control;
            this.rd4.ForeColor = System.Drawing.Color.Navy;
            this.rd4.Location = new System.Drawing.Point(10, 80);
            this.rd4.Name = "rd4";
            this.rd4.Size = new System.Drawing.Size(229, 22);
            this.rd4.TabIndex = 3;
            this.rd4.Text = "Bảng kê chi phí theo nhóm viện phí";
            this.rd4.UseVisualStyleBackColor = false;
            this.rd4.CheckedChanged += new System.EventHandler(this.rd_CheckedChanged);
            this.rd4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rd3_KeyDown);
            // 
            // rd3
            // 
            this.rd3.Location = new System.Drawing.Point(10, 58);
            this.rd3.Name = "rd3";
            this.rd3.Size = new System.Drawing.Size(229, 22);
            this.rd3.TabIndex = 2;
            this.rd3.Text = "Bảng kê chi phí theo loại viện phí";
            this.rd3.CheckedChanged += new System.EventHandler(this.rd_CheckedChanged);
            this.rd3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rd2_KeyDown);
            // 
            // rd1
            // 
            this.rd1.Checked = true;
            this.rd1.Location = new System.Drawing.Point(10, 14);
            this.rd1.Name = "rd1";
            this.rd1.Size = new System.Drawing.Size(229, 22);
            this.rd1.TabIndex = 0;
            this.rd1.TabStop = true;
            this.rd1.Text = "Báo cáo tổng hợp theo loại viện phí";
            this.rd1.CheckedChanged += new System.EventHandler(this.rd_CheckedChanged);
            this.rd1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rd1_KeyDown);
            // 
            // chkUserid
            // 
            this.chkUserid.Location = new System.Drawing.Point(4, 5);
            this.chkUserid.Name = "chkUserid";
            this.chkUserid.Size = new System.Drawing.Size(196, 17);
            this.chkUserid.TabIndex = 0;
            this.chkUserid.TabStop = false;
            this.chkUserid.Text = "Nhân viên thu ngân (Quyển sổ)";
            this.chkUserid.CheckedChanged += new System.EventHandler(this.chkUserid_CheckedChanged);
            this.chkUserid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkUserid_KeyDown);
            // 
            // txtDN
            // 
            this.txtDN.CustomFormat = "dd/MM/yyyy hh:mm";
            this.txtDN.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtDN.Location = new System.Drawing.Point(575, 43);
            this.txtDN.Name = "txtDN";
            this.txtDN.Size = new System.Drawing.Size(85, 20);
            this.txtDN.TabIndex = 11;
            this.txtDN.Validated += new System.EventHandler(this.txtDN_Validated);
            this.txtDN.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDN_KeyDown);
            // 
            // txtTN
            // 
            this.txtTN.CustomFormat = "dd/MM/yyyy hh:mm";
            this.txtTN.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtTN.Location = new System.Drawing.Point(431, 43);
            this.txtTN.Name = "txtTN";
            this.txtTN.Size = new System.Drawing.Size(82, 20);
            this.txtTN.TabIndex = 10;
            this.txtTN.ValueChanged += new System.EventHandler(this.txtTN_ValueChanged);
            this.txtTN.Validated += new System.EventHandler(this.txtTN_Validated);
            this.txtTN.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTN_KeyDown);
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(514, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 78;
            this.label2.Text = "đến ngày";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(380, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 77;
            this.label3.Text = "Từ ngày";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butInBK
            // 
            this.butInBK.BackColor = System.Drawing.SystemColors.Control;
            this.butInBK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butInBK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butInBK.ForeColor = System.Drawing.Color.Navy;
            this.butInBK.Image = ((System.Drawing.Image)(resources.GetObject("butInBK.Image")));
            this.butInBK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butInBK.Location = new System.Drawing.Point(514, 65);
            this.butInBK.Name = "butInBK";
            this.butInBK.Size = new System.Drawing.Size(73, 25);
            this.butInBK.TabIndex = 13;
            this.butInBK.Text = "&In";
            this.butInBK.UseVisualStyleBackColor = true;
            this.butInBK.Click += new System.EventHandler(this.butInBK_Click);
            this.butInBK.KeyDown += new System.Windows.Forms.KeyEventHandler(this.butInBK_KeyDown);
            // 
            // butKetthuc
            // 
            this.butKetthuc.BackColor = System.Drawing.SystemColors.Control;
            this.butKetthuc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butKetthuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butKetthuc.ForeColor = System.Drawing.Color.Navy;
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(587, 65);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(73, 25);
            this.butKetthuc.TabIndex = 14;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.UseVisualStyleBackColor = true;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            this.butKetthuc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.butKetthuc_KeyDown);
            // 
            // txtNgayIn
            // 
            this.txtNgayIn.CustomFormat = "dd/MM/yyyy hh:mm";
            this.txtNgayIn.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtNgayIn.Location = new System.Drawing.Point(431, 68);
            this.txtNgayIn.Name = "txtNgayIn";
            this.txtNgayIn.Size = new System.Drawing.Size(82, 20);
            this.txtNgayIn.TabIndex = 12;
            this.txtNgayIn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNgayIn_KeyDown);
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(379, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 79;
            this.label1.Text = "Ngày in";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkBHYT
            // 
            this.chkBHYT.Location = new System.Drawing.Point(409, 138);
            this.chkBHYT.Name = "chkBHYT";
            this.chkBHYT.Size = new System.Drawing.Size(72, 17);
            this.chkBHYT.TabIndex = 193;
            this.chkBHYT.TabStop = false;
            this.chkBHYT.Text = "Mẫu BHYT";
            // 
            // chkLoaiBN
            // 
            this.chkLoaiBN.Location = new System.Drawing.Point(4, 200);
            this.chkLoaiBN.Name = "chkLoaiBN";
            this.chkLoaiBN.Size = new System.Drawing.Size(104, 17);
            this.chkLoaiBN.TabIndex = 2;
            this.chkLoaiBN.TabStop = false;
            this.chkLoaiBN.Text = "Loại bệnh nhân";
            this.chkLoaiBN.CheckedChanged += new System.EventHandler(this.chkLoaiBN_CheckedChanged);
            // 
            // label6
            // 
            this.label6.ForeColor = System.Drawing.Color.Navy;
            this.label6.Location = new System.Drawing.Point(553, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 211;
            this.label6.Text = "Năm";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.ForeColor = System.Drawing.Color.Navy;
            this.label5.Location = new System.Drawing.Point(368, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 207;
            this.label5.Text = "Báo cáo";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rdNgoaitru
            // 
            this.rdNgoaitru.BackColor = System.Drawing.SystemColors.Control;
            this.rdNgoaitru.ForeColor = System.Drawing.Color.Navy;
            this.rdNgoaitru.Location = new System.Drawing.Point(527, 315);
            this.rdNgoaitru.Name = "rdNgoaitru";
            this.rdNgoaitru.Size = new System.Drawing.Size(80, 18);
            this.rdNgoaitru.TabIndex = 17;
            this.rdNgoaitru.Text = "Ngoại trú";
            this.rdNgoaitru.UseVisualStyleBackColor = false;
            this.rdNgoaitru.Visible = false;
            // 
            // rdNoitru
            // 
            this.rdNoitru.BackColor = System.Drawing.SystemColors.Control;
            this.rdNoitru.Checked = true;
            this.rdNoitru.ForeColor = System.Drawing.Color.Navy;
            this.rdNoitru.Location = new System.Drawing.Point(470, 315);
            this.rdNoitru.Name = "rdNoitru";
            this.rdNoitru.Size = new System.Drawing.Size(57, 18);
            this.rdNoitru.TabIndex = 16;
            this.rdNoitru.TabStop = true;
            this.rdNoitru.Text = "Nội trú";
            this.rdNoitru.UseVisualStyleBackColor = false;
            this.rdNoitru.Visible = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(3, 418);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(672, 20);
            this.progressBar1.TabIndex = 207;
            // 
            // label11
            // 
            this.label11.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label11.Location = new System.Drawing.Point(3, 414);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(672, 4);
            this.label11.TabIndex = 208;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmBaocaotreem
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(678, 441);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximumSize = new System.Drawing.Size(686, 468);
            this.Name = "frmBaocaotreem";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Báo cáo chi phí điều trị trẻ em";
            this.Load += new System.EventHandler(this.frmBaocaotreem_Load);
            this.SizeChanged += new System.EventHandler(this.frmBaocaotreem_SizeChanged);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtThang)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion
		private string f_Cur_Date()
		{
			try
			{
				return System.DateTime.Now.Day.ToString().PadLeft(2,'0')+ "/" + System.DateTime.Now.Month.ToString().PadLeft(2,'0')+ "/" + System.DateTime.Now.Year.ToString();
			}
			catch
			{
				return "";
			}
		}
		private DateTime f_Cur_Date(string v_ngay)
		{
			try
			{
				//MessageBox.Show(v_ngay.Substring(6,4) + ":" +v_ngay.Substring(3,2) + ":" + v_ngay.Substring(0,2));
				return new DateTime(int.Parse(v_ngay.Substring(6,4)),int.Parse(v_ngay.Substring(3,2)),int.Parse(v_ngay.Substring(0,2)));
			}
			catch
			{
				return DateTime.Now;
			}
		}
		private void f_Load_Default()
		{
			try
			{
				DataSet ads = new DataSet();
				m_sqlnhom="";
				ads = m_v.get_data("select ma, stt from medibv.v_nhomvp union all select 0 ma, 0 stt from dual order by stt asc");
				for (int i=0;i<ads.Tables[0].Rows.Count;i++)
				{
					m_sqlnhom = m_sqlnhom + ",sum(to_number(decode(h.ma," + ads.Tables[0].Rows[i]["MA"].ToString()+",b.soluong*b.dongia-b.mien-b.thieu,0))) LL" + i.ToString(); 
					m_sqlnhom_nt = m_sqlnhom_nt + ",sum(to_number(decode(i.ma," + ads.Tables[0].Rows[i]["MA"].ToString()+",(aaa.soluong*aaa.dongia + aaa.soluong*aaa.dongia*nvl(aaa.vat,0)/100),0))) LL" + i.ToString(); 
				}
				
				for(int i=ads.Tables[0].Rows.Count;i<=50;i++)
				{
					m_sqlnhom = m_sqlnhom + ", 0 LL"+i.ToString();
					m_sqlnhom_nt = m_sqlnhom_nt + ", 0 LL"+i.ToString();
				}
				m_sqlnhom = "," + m_sqlnhom.Trim(',');
				m_sqlnhom_nt = "," + m_sqlnhom_nt.Trim(',');
				
				//MessageBox.Show(m_sqlnhom);
			
				m_sqlloai="";

                ads = m_v.get_data("select id ma, stt from medibv.v_loaivp union all select 0 ma, 0 stt from dual order by stt asc");
				for (int i=0;i<ads.Tables[0].Rows.Count;i++)
				{
					m_sqlloai = m_sqlloai + ",sum(to_number(decode(g.id," + ads.Tables[0].Rows[i]["MA"].ToString()+",b.soluong*b.dongia-b.mien-b.thieu,0))) LL" + i.ToString();
                    m_sqlloai_nt = m_sqlloai_nt + ",sum(to_number(decode(h.id," + ads.Tables[0].Rows[i]["MA"].ToString() + ",(aaa.soluong*aaa.dongia + aaa.soluong*aaa.dongia*nvl(aaa.vat,0)/100),0))) LL" + i.ToString(); 
				}
				
				for(int i=ads.Tables[0].Rows.Count;i<=50;i++)
				{
					m_sqlloai = m_sqlloai + ", 0 LL"+i.ToString();
					m_sqlloai_nt = m_sqlloai_nt + ", 0 LL"+i.ToString();
				}
				m_sqlloai = "," + m_sqlloai.Trim(',');
				m_sqlloai_nt = "," + m_sqlloai_nt.Trim(',');
				
				//Mã vp khám bệnh
				m_sqlkb="";
				ads = m_v.get_data("select mavp from medibv.btdkp_bv where mavp is not null and mavp>0 group by mavp order by mavp");
				for (int i=0;i<ads.Tables[0].Rows.Count;i++)
				{
                    m_sqlkb = m_sqlkb + ",sum(to_number(decode(b.mavp," + ads.Tables[0].Rows[i]["MAVP"].ToString() + ",b.soluong*b.dongia-b.mien-b.thieu,0))) LL" + i.ToString(); 
				}
				
				for(int i=ads.Tables[0].Rows.Count;i<=50;i++)
				{
					m_sqlkb = m_sqlkb + ", 0 LL"+i.ToString();
				}
				m_sqlkb = "," + m_sqlkb.Trim(',');
				//MessageBox.Show(m_sqlkb);
			}
			catch
			{
			}
		}
		private void f_Display_User()
		{
			try
			{
				DataSet ads = m_v.get_data("select to_char(id) id, hoten from medibv.v_dlogin where to_char(id)='"+ m_userid + "'");
				txtNguoilapphieu.Tag = ads.Tables[0].Rows[0]["hoten"].ToString();
			}
			catch
			{
				txtNguoilapphieu.Tag = "";
			}
			this.Text=this.Text+"/"+txtNguoilapphieu.Tag.ToString().Trim();
		}
		public string s_userid
		{
			get
			{
				return m_userid;
			}
			set
			{
				m_userid=value;
				try
				{
					for(int i=0;i<tree_User.Nodes.Count;i++)
					{
						if(tree_User.Nodes[i].Tag.ToString()==m_userid)
						{
							tree_User.Nodes[i].Checked=true;
						}
					}
				}
				catch
				{
				}
			}
		}

		public string s_quyensoid
		{
			get
			{
				return m_quyensoid;
			}
			set
			{
				m_quyensoid=value;
				try
				{
					for(int i=0;i<tree_User.Nodes.Count;i++)
					{
						for(int j=0;j<tree_User.Nodes[i].Nodes.Count;j++)
						{
							if(tree_User.Nodes[i].Nodes[j].Tag.ToString()==m_quyensoid)
							{
								tree_User.Nodes[i].Nodes[j].Checked=true;
							}
						}
					}
				}
				catch
				{
				}
			}
		}

		public string s_ngay
		{
			get
			{
				return txtTN.Text.Substring(0,10);
			}
			set
			{
				m_ngaythu=value;
				try
				{
					txtTN.Value=f_Cur_Date(m_ngaythu);
					txtDN.Value=f_Cur_Date(m_ngaythu);
					txtNgayIn.Value=f_Cur_Date(m_ngaythu);
				}
				catch
				{
				}
			}
		}

		private void f_Load_Tree_Userid()
		{
			if(m_v.sys_dungchungso)
			{
				tree_User.Width=tree_Quyenso.Left-tree_User.Left-1;
				timso.Width=tree_Quyenso.Width;
				timso.Left=tree_Quyenso.Left;
				tree_User.Height=timso.Bottom-tree_User.Top;
				tree_Quyenso.Visible=true;
				f_Load_tree_Quyenso();
				f_Load_tree_User1();
			}
			else
			{
				tree_Quyenso.Visible=false;
				try
				{
					string aexp="";
					if(timso.Text.Trim()!=lan.Change_language_MessageText("Tìm sổ") && timso.Text.Trim()!="")
					{
						aexp="upper(a.sohieu) like '%"+timso.Text.Trim().ToUpper()+"%'";
					}
                    if (aexp != "")
                    {
                        aexp = " where " + aexp;
                    }
					string sql = "select to_char(a.id) as ma, trim(a.sohieu)||'     ('||to_char(a.tu)||' -->'||to_char(a.den)|| ')' as ten, to_char(b.id) as mar, trim(b.hoten)||' ('||b.userid||')' as tenr from medibv.v_quyenso a left join medibv.v_dlogin b on b.id=a.userid"+aexp+" order by b.id, b.hoten";
					f_Load_Tree(tree_User,m_v.get_data(sql),false);
					for(int i=0;i<tree_User.Nodes.Count;i++)
					{
						if(tree_User.Nodes[i].Tag.ToString()==m_userid)
						{
							tree_User.Nodes[i].Checked=true;
							break;
						}
					}
				}
				catch
				{
				}
			}
		}

		private void f_Load_tree_Quyenso()
		{
			try
			{
				string aexp="";
				if(timso.Text.Trim()!=lan.Change_language_MessageText("Tìm sổ") && timso.Text.Trim()!="")
				{
					aexp=" and upper(sohieu) like '%"+timso.Text.Trim().ToUpper()+"%'";
				}
				string sql = "select to_char(id) as ma, sohieu as ten from medibv.v_quyenso where 1=1 "+aexp+" order by sohieu asc";
				f_Load_Tree(tree_Quyenso,m_v.get_data(sql));
				toolTip1.SetToolTip(tree_Quyenso,"Ký hiệu biên lai");
			}
			catch
			{
			}
		}
		private void f_Load_tree_User1()
		{
			try
			{
				string sql = "select to_char(id) as ma, trim(hoten)||' ('||userid||')' as ten from medibv.v_dlogin order by hoten asc";
				f_Load_Tree(tree_User,m_v.get_data(sql));
				for(int i=0;i<tree_User.Nodes.Count;i++)
				{
					if(tree_User.Nodes[i].Tag.ToString()==m_userid)
					{
						tree_User.Nodes[i].Checked=true;
						break;
					}
				}
			}
			catch
			{
			}
		}
		private void f_Load_tree_LoaiBN()
		{
			try
			{
				DataSet ads = new DataSet();
				ads=m_v.get_data("select to_char(id) as ma, ten from medibv.v_loaibn order by id");
				f_Load_Tree(tree_LoaiBN,ads);
			}
			catch
			{
			}
		}
		private void frmBaocaotreem_Load(object sender, System.EventArgs e)
		{
			try
			{
				rd_CheckedChanged(null,null);
				cbKy.SelectedIndex=0;
				txtThang.Value=DateTime.Now.Month;
				txtNam.Value=DateTime.Now.Year;
				cbKy_SelectedIndexChanged(null,null);

				txtNgayIn.Value=System.DateTime.Now;
				txtTN.Value=System.DateTime.Now;
				txtDN.Value=System.DateTime.Now;
				f_Display_User();
				f_Load_Tree_Userid();
				f_Load_tree_LoaiBN();
				f_Load_CB_Maubaocao();
				f_LoadHistory();
				f_Load_Default();
				rd_CheckedChanged(null,null);
				chkBHYT.Checked=false;
				chkBHYT.Visible=false;
				try
				{
					m_doituongtreem=m_v.get_data("select * from medibv.v_optiondoituongtreem").Tables[0].Rows[0][0].ToString();
				}
				catch
				{
					m_doituongtreem="";
				}
			}
			catch
			{
			}
		}
		private DataSet f_Get_Maubaocaotructiep()
		{
			//v_maubaocao 
			//Loai=9
			DataSet ads = new DataSet();
			try
			{
                //try
                //{
                //    int n=0;
                //    n=m_v.get_data("select * from medibv.v_maubaocao where rownum<=2").Tables[0].Rows.Count;
                //}
                //catch
                //{
                //    m_v.execute_data("create table " + m_v.s_schemaroot + ".v_maubaocao(id numeric(3), ma text, ten text, loai numeric(1), constraint pk_v_maubaocao primary key(id)) with oids");
                //    m_v.execute_data("alter table " + m_v.s_schemaroot + ".v_maubaocao owner to " + m_v.s_database + "");
                //}
				ads = m_v.get_data("select ma, ten from medibv.v_maubaocao where loai=9");
				DataRow r = ads.Tables[0].NewRow();
				r["ma"]="";
				r["ten"]=lan.Change_language_MessageText("Mẫu báo cáo chung");
				ads.Tables[0].Rows.InsertAt(r,0);
			}
			catch
			{
			}
			return ads;
		}
		private void f_Load_CB_Maubaocao()
		{
			try
			{
				DataSet ads =  new DataSet();
				ads = f_Get_Maubaocaotructiep();
				cbMaubaocao.DisplayMember="TEN";
				cbMaubaocao.ValueMember="MA";
				cbMaubaocao.DataSource = ads.Tables[0];
				cbMaubaocao.SelectedIndex=0;
			}
			catch
			{
			}
		}
		private void f_Load_Tree(TreeView v_tree, DataSet v_ds)
		{
			try
			{
				TreeNode anode;
				v_tree.Nodes.Clear();
				v_tree.Sorted=false;
				for(int i=0;i<v_ds.Tables[0].Rows.Count;i++)
				{
					anode = new TreeNode(v_ds.Tables[0].Rows[i]["ten"].ToString());
					anode.Tag = v_ds.Tables[0].Rows[i]["ma"].ToString();
					v_tree.Nodes.Add(anode);
				}
			}
			catch
			{
			}
		}
		private void f_Load_Tree(TreeView v_tree, DataSet v_ds, bool v_expand)
		{
			try
			{
				v_tree.ShowLines=true;
				v_tree.ShowPlusMinus=true;
				v_tree.ShowRootLines=true;
				v_tree.FullRowSelect=false;

				TreeNode anode,anoder;
				anode=new TreeNode("");
				anode.Tag="";
				anoder=new TreeNode("");
				anoder.Tag="";
				
				v_tree.Nodes.Clear();
				v_tree.Sorted=false;
				string amar="";
				foreach(DataRow r in v_ds.Tables[0].Select("","mar"))
				{
					if(amar!=r["mar"].ToString())
					{
						amar=r["mar"].ToString();
						anoder = new TreeNode(r["tenr"].ToString());
						anoder.Tag = r["mar"].ToString();
						if(anoder.Tag.ToString()!="")
						{
							v_tree.Nodes.Add(anoder);
						}
					}
					if(r["ma"].ToString().Trim()!="")
					{
						anode = new TreeNode(r["ten"].ToString());
						anode.Tag = r["ma"].ToString();
						anoder.Nodes.Add(anode);
					}
				}
				if(anoder.Tag.ToString()!=amar)
				{
					v_tree.Nodes.Add(anoder);
				}
				if(v_expand)
				{
					v_tree.ExpandAll();
				}
			}
			catch
			{
			}
		}
		private string f_Get_CheckID(TreeView v_tree, int v_i)
		{
			try
			{
				string r="";
				if(v_i==1)
				{
					for(int i=0;i<v_tree.Nodes.Count;i++)
					{
						if(v_tree.Nodes[i].Checked) r = r.Trim().Trim(',') + "," + v_tree.Nodes[i].Tag.ToString();
					}
					r=r.Trim().Trim(',');
				}
				else
					if(v_i==2)
				{
					for(int i=0;i<v_tree.Nodes.Count;i++)
					{
						for(int j=0;j<v_tree.Nodes[i].Nodes.Count;j++)
						{
							if(v_tree.Nodes[i].Nodes[j].Checked) r = r.Trim().Trim(',') + "," + v_tree.Nodes[i].Nodes[j].Tag.ToString();
						}
					}
					r=r.Trim().Trim(',');
				}
				//MessageBox.Show(r);
				return r;
			}
			catch
			{
				return "";
			}
		}
		private void f_Set_CheckID(TreeView v_tree, bool v_b)
		{
			try
			{
				for(int i=0;i<v_tree.Nodes.Count;i++)
				{
					v_tree.Nodes[i].Checked=v_b;
				}
			}
			catch
			{
			}
		}

		private string f_Get_CheckID(TreeView v_tree)
		{
			try
			{
				string r="";
				for(int i=0;i<v_tree.Nodes.Count;i++)
				{
					if(v_tree.Nodes[i].Checked) r = r.Trim().Trim(',') + "," + v_tree.Nodes[i].Tag.ToString();
				}
				r=r.Trim().Trim(',');
				//MessageBox.Show(r);
				return r;
			}
			catch
			{
				return "";
			}
		}
		private void f_SaveHistory()
		{
			try
			{
				DataSet ads = new DataSet();
				ads.Tables.Add("Bangkehoantra");
				ads.Tables[0].Columns.Add("nguoilapphieu");
				ads.Tables[0].Columns.Add("giamdoc");
				ads.Tables[0].Columns.Add("ketoan");
				ads.Tables[0].Rows.Add(new string[] {txtNguoilapphieu.Text.Trim(),txtGiamdoc.Text.Trim(),txtKetoanvp.Text.Trim()});
				ads.WriteXml("...//...//option//v_optionbaocaotreem.xml",XmlWriteMode.WriteSchema);
			}
			catch
			{
			}
		}
		private void f_LoadHistory()
		{
			try
			{
				if(!System.IO.Directory.Exists("..//..//option"))
				{
					System.IO.Directory.CreateDirectory("..//..//option");
				}
			}
			catch
			{
				//MessageBox.Show(ex.ToString());
			}
			try
			{
				DataSet ads = new DataSet();
				ads.ReadXml("...//...//option//v_optionbaocaotreem.xml");
				txtNguoilapphieu.Text=txtNguoilapphieu.Tag.ToString();//ads.Tables[0].Rows[0]["nguoilapphieu"].ToString();
				txtGiamdoc.Text=ads.Tables[0].Rows[0]["giamdoc"].ToString();
				txtKetoanvp.Text=ads.Tables[0].Rows[0]["ketoan"].ToString();
			}
			catch
			{
			}
		}
		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
		private void chklQuyenSo_Leave(object sender, System.EventArgs e)
		{
			try
			{
				//chklQuyenSo.SetSelected(chklQuyenSo.SelectedIndex,false);
				//chklQuyenSo.SetSelected(0,false);
			}
			catch
			{
			}
		}

		private void chklLoaiBN_Leave(object sender, System.EventArgs e)
		{
			try
			{
				//chklLoaiBN.SetSelected(chklLoaiBN.SelectedIndex,false);
				//chklLoaiBN.SetSelected(0,false);
			}
			catch
			{
			}
		}
		private void f_SetEvent(System.Windows.Forms.Control v_c)
		{
			try
			{
				foreach(Control c in v_c.Controls)
				{
					c.Leave += new System.EventHandler(this.Control_Leave);
					c.Enter += new System.EventHandler(this.Control_Enter);
				}
			}
			catch
			{
			}
		}
		private void Control_Enter(object sender, System.EventArgs e)
		{
			try
			{
				System.Windows.Forms.Control c = (System.Windows.Forms.Control)(sender);
				if((c.GetType().ToString()=="System.Windows.Forms.TextBox")||(c.GetType().ToString()=="System.Windows.Forms.ComboBox")||(c.GetType().ToString()=="AsYetUnnamed.MultiColumnListBox")||(c.GetType().ToString()=="System.Windows.Forms.TreeView")||(c.GetType().ToString()=="System.Windows.Forms.DataGrid")||(c.GetType().ToString()=="System.Windows.Forms.DateTimePicker")||(c.GetType().ToString()=="System.Windows.Forms.CheckedListBox"))
				{
					c.BackColor=SystemColors.Info;
					if(c.ForeColor!=Color.Red)
					{
						//c.ForeColor=SystemColors.InfoText;
					}
					if(c.GetType().ToString()=="System.Windows.Forms.DataGrid")
					{
						System.Windows.Forms.DataGrid c1 = (System.Windows.Forms.DataGrid)(sender);
						c1.BackgroundColor=SystemColors.Info;
					}
					else
						if(c.GetType().ToString()=="System.Windows.Forms.ComboBox")
					{
						System.Windows.Forms.ComboBox c1 = (System.Windows.Forms.ComboBox)(sender);
						if(c1.SelectedIndex<0)
						{
							c1.SelectedIndex=0;
						}
					}
				}
			}
			catch
			{
			}
		}
		private void Control_Leave(object sender, System.EventArgs e)
		{
			try
			{
				System.Windows.Forms.Control c = (System.Windows.Forms.Control)(sender);
				if((c.GetType().ToString()=="System.Windows.Forms.TextBox")||(c.GetType().ToString()=="System.Windows.Forms.ComboBox")||(c.GetType().ToString()=="AsYetUnnamed.MultiColumnListBox")||(c.GetType().ToString()=="System.Windows.Forms.TreeView")||(c.GetType().ToString()=="System.Windows.Forms.DataGrid")||(c.GetType().ToString()=="System.Windows.Forms.DateTimePicker")||(c.GetType().ToString()=="System.Windows.Forms.CheckedListBox"))
				{
					c.BackColor=Color.FromArgb(255,255,255);
					if(c.ForeColor!=Color.Red)
					{
						//c.ForeColor=SystemColors.ControlText;
					}
					if(c.GetType().ToString()=="System.Windows.Forms.DataGrid")
					{
						System.Windows.Forms.DataGrid c1 = (System.Windows.Forms.DataGrid)(sender);
						c1.BackgroundColor=Color.White;
					}
				}
			}
			catch
			{
			}
		}

		private void cbUserid_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			try
			{
				if(e.KeyCode==Keys.Enter)
				{
					SendKeys.Send("{Tab}");
				}
			}
			catch
			{
			}
		}

		private void chklLoaiBN_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			try
			{
				if(e.KeyCode==Keys.Enter)
				{
					SendKeys.Send("{Tab}");
				}
			}
			catch
			{
			}
		}

		private void chklQuyenSo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			try
			{
				if(e.KeyCode==Keys.Enter)
				{
					SendKeys.Send("{Tab}");
				}
			}
			catch
			{
			}
		}

		private void txtTS_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			try
			{
				if(e.KeyCode==Keys.Enter)
				{
					SendKeys.Send("{Tab}");
				}
			}
			catch
			{
			}
		}

		private void txtDS_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			try
			{
				if(e.KeyCode==Keys.Enter)
				{
					SendKeys.Send("{Tab}");
				}
			}
			catch
			{
			}
		}

		private void txtTN_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			try
			{
				if(e.KeyCode==Keys.Enter)
				{
					//SendKeys.Send("{Tab}");
					txtDN.Focus();
				}
			}
			catch
			{
			}
		}

		private void txtDN_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			try
			{
				if(e.KeyCode==Keys.Enter)
				{
					//SendKeys.Send("{Tab}");
					butInBK.Focus();
				}
			}
			catch
			{
			}
		}
		private string f_Get_CheckID(CheckedListBox v_ckl)
		{
			try
			{
				string r="";
				int iold=v_ckl.SelectedIndex;
				for(int i=0;i<v_ckl.Items.Count;i++)
				{
					if(i==iold)
					{
						if(!v_ckl.GetItemChecked(i))
						{
							v_ckl.SelectedIndex=i;
							r=r.Trim().Trim(',') + "," + v_ckl.SelectedValue.ToString();
						}
					}
					else
					{
						if(v_ckl.GetItemChecked(i))
						{
							v_ckl.SelectedIndex=i;
							r=r.Trim().Trim(',') + "," + v_ckl.SelectedValue.ToString();
						}
					}
				}
				r=r.Trim().Trim(',');
				v_ckl.SelectedIndex=iold;
				//MessageBox.Show(r.ToString());
				return r;
			}
			catch
			{
				return "";
			}
		}
		private DataSet f_Data_BK_2_TT()
		{
			try
			{
				DataSet ads = new DataSet();
				string sql="";
				string asqlht="select * from medibvmmyy.v_hoantra where to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('"+ txtTN.Text.Trim().Substring(0,10) +"','dd/mm/yyyy') and to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy')<=to_date('"+ txtDN.Text.Trim().Substring(0,10) +"','dd/mm/yyyy')";
				string auserid = f_Get_CheckID(tree_User,1);
				string aquyenso= f_Get_CheckID(tree_User,2);
				string aloaibn= f_Get_CheckID(tree_LoaiBN);
				if(m_v.sys_dungchungso)
				{
					auserid = f_Get_CheckID(tree_User);
					aquyenso = f_Get_CheckID(tree_Quyenso);
				}

				string exp="";

				if(auserid.Length>0)
				{
					if(exp.Length>0)
					{
						exp=exp+" and a.userid in(" + auserid+")";
					}
					else
					{
						exp="a.userid in(" + auserid+")";
					}
					asqlht+=" and userid in("+auserid+")";
				}
				if(aquyenso.Length>0)
				{
					if(exp.Length>0)
					{
						exp=exp + " and a.quyenso in(" + aquyenso +")";
					}
					else
					{
						exp=" a.quyenso in(" + aquyenso+")";
					}
				}

				if(aloaibn.Length>0)
				{
					if(exp.Length>0)
					{
						exp=exp + " and a.loaibn in(" + aloaibn+")";
					}
					else
					{
						exp=exp + " a.loaibn in(" + aloaibn+")";
					}
				}

				if(m_doituongtreem.Length>0)
				{
					if(exp.Length>0)
					{
						exp=exp + " and b.madoituong in(" + m_doituongtreem+")";
					}
					else
					{
						exp=exp + " b.madoituong in(" + m_doituongtreem+")";
					}
				}

				exp=exp.Trim();
				if(exp.Length>0)
				{
					exp=" and "+exp;
				}

                string asqldmbd = "select a1.id id, c1.id_loai id_loai from medibv.d_dmbd a1, medibv.d_dmnhom b1, (select a0.ma, nvl(to_number(b0.id),0) id_loai from medibv.v_nhomvp a0, medibv.v_loaivp b0 where b0.id_nhom(+)=a0.ma) c1 where b1.id(+)=a1.manhom and c1.ma(+)=b1.nhomvp ";
				switch (groupBox1.Tag.ToString())
				{
					case "3"://Loai A4
						//sql="select a.id, a.quyenso quyensoid, a.sobienlai, to_char(a.ngay,'dd/mm/yyyy') ngay, d.sohieu quyenso, a.mabn, a.hoten, aaa.cholam, a.namsinh, i.sothe mabhyt, j.mabv, j.tenbv, sum(nvl(b.soluong,0)*nvl(b.dongia,0)) sotien, sum(decode(b.madoituong,1,nvl(b.mien,0),0)) bhyt, nvl(c.sotien,0) mien, sum(nvl(b.thieu,0)) thieu, sum(nvl(b.soluong,0)*nvl(b.dongia,0)-nvl(b.thieu,0)-decode(b.madoituong,1,nvl(b.mien,0),0))-nvl(c.sotien,0) thucthu, e.hoten nguoithu, e.hoten ||' ('||to_char(e.userid)||')' userid,'' ngayvao,'' ngayra,'' chandoan,'' maicd,'' tenkp,'' doituong,0 tongcp, 0 tamung "+m_sqlloai+" from v_vienphill a, ("+asqlht+") aa, btdbn aaa, v_vienphict b, v_mienngtru c, v_quyenso d, medibv.v_dlogin e, (select id, id_loai from v_giavp union all select id, 0 from d_dmbd order by id) f, (select id, id_nhom from v_loaivp union all select 0, 0 from dual order by id) g, (select ma, stt from v_nhomvp union all select 0, 0 from dual order by ma) h, bhyt i, (select mabv, tenbv from tenvien union select mabv, tenbv from tenvien_add) j where a.id=b.id and a.id=c.id(+) and a.mabn=aaa.mabn(+) and a.quyenso=d.id(+) and a.userid=e.id(+) and a.userid=e.id(+) and b.mavp=f.id(+) and f.id_loai=g.id(+) and g.id_nhom=h.ma(+) and a.maql=i.maql(+) and a.quyenso=aa.quyenso(+) and a.sobienlai=aa.sobienlai(+) and i.mabv=j.mabv(+) and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('"+ txtTN.Text.Trim().Substring(0,10) +"','dd/mm/yyyy') and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')<=to_date('"+ txtDN.Text.Trim().Substring(0,10) +"','dd/mm/yyyy') "+exp+" group by a.id, a.quyenso, a.sobienlai, d.sohieu, a.mabn, a.hoten, a.namsinh, i.sothe, aaa.cholam, j.mabv, j.tenbv, c.sotien, e.hoten, a.ngay, e.hoten ||' ('||to_char(e.userid)||')' order by d.sohieu asc, a.sobienlai asc, a.ngay asc";
						sql="select a.id, a.quyenso quyensoid, a.sobienlai, to_char(a.ngay,'dd/mm/yyyy') ngay, d.sohieu quyenso, a.mabn, a.hoten,aaaa.hoten_bo,aaaa.hoten_me,aaa.cholam, nvl(to_char(aaa.ngaysinh,'dd/mm/yyyy'),to_char(aaa.namsinh)) namsinh, trim(aaa.sonha||' '||aaa.thon) diachi, dc1.tentt, dc2.tenquan,dc3.tenpxa,i.sothe mabhyt, j.mabv, j.tenbv, sum(nvl(b.soluong,0)*nvl(b.dongia,0)) sotien, sum(decode(to_number(b.madoituong,1,nvl(b.mien,0),0))) bhyt, nvl(c.sotien,0) mien, sum(nvl(b.thieu,0)) thieu, sum(nvl(b.soluong,0)*nvl(b.dongia,0)-nvl(b.thieu,0)-to_number(decode(b.madoituong,1,nvl(b.mien,0),0)))-nvl(c.sotien,0) thucthu, e.hoten nguoithu, e.hoten ||' ('||to_char(e.userid)||')' userid,to_char(a.ngay,'dd/mm/yyyy') ngayvao,to_char(a.ngay,'dd/mm/yyyy') ngayra,1 songaydt, '' chandoan,'' maicd,'' tenkp,'' doituong,0 tongcp, 0 tamung "+m_sqlloai;
                        sql += " from medibvmmyy.v_vienphill a, (" + asqlht + ") aa, medibv.btdbn aaa, medibv.hcnhi aaaa, medibvmmyy.v_vienphict b, medibvmmyy.v_mienngtru c, medibv.v_quyenso d, medibv.v_dlogin e, (select id, id_loai from medibv.v_giavp union all select id, 0 from medibv.d_dmbd order by id) f, (select id, id_nhom from medibv.v_loaivp union all select 0, 0 from dual order by id) g, (select ma, stt from medibv.v_nhomvp union all select 0, 0 from dual order by ma) h, medibvmmyy.bhyt i, (select mabv, tenbv from medibv.tenvien union select mabv, tenbv from medibv.tenvien_add) j, medibv.btdtt dc1, medibv.btdquan dc2, medibv.btdpxa dc3 where a.id=b.id and c.id(+)=a.id and aaa.mabn(+)=a.mabn and aaaa.mabn(+)=aaa.mabn and dc1.matt(+)=aaa.matt and dc2.maqu(+)=aaa.maqu and dc3.maphuongxa(+)=aaa.maphuongxa and d.id(+)=a.quyenso and e.id(+)=a.userid and e.id(+)=a.userid and f.id(+)=b.mavp and g.id(+)=f.id_loai and h.ma(+)=g.id_nhom and i.maql(+)=a.maql and aa.quyenso(+)=a.quyenso and aa.sobienlai(+)=a.sobienlai and j.mabv(+)=i.mabv and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('" + txtTN.Text.Trim().Substring(0, 10) + "','dd/mm/yyyy') and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')<=to_date('" + txtDN.Text.Trim().Substring(0, 10) + "','dd/mm/yyyy') " + exp + " group by a.id, a.quyenso, a.sobienlai, d.sohieu, a.mabn, a.hoten, aaaa.hoten_bo,aaaa.hoten_me, aaa.ngaysinh, aaa.namsinh, aaa.sonha, aaa.thon, dc1.tentt, dc2.tenquan, dc3.tenpxa, i.sothe, aaa.cholam, j.mabv, j.tenbv, c.sotien, e.hoten, a.ngay, e.hoten ||' ('||to_char(e.userid)||')' order by a.ngay asc, d.sohieu asc, a.sobienlai asc";
						break;
					case "4"://Nhom A4
						//sql="select a.id,a.quyenso quyensoid, a.sobienlai, to_char(a.ngay,'dd/mm/yyyy') ngay, d.sohieu quyenso, a.mabn, a.hoten, aaa.cholam, a.namsinh, i.sothe mabhyt, j.mabv, j.tenbv, sum(nvl(b.soluong,0)*nvl(b.dongia,0)) sotien, sum(decode(b.madoituong,1,nvl(b.mien,0),0)) bhyt, nvl(c.sotien,0) mien, sum(nvl(b.thieu,0)) thieu, sum(nvl(b.soluong,0)*nvl(b.dongia,0)-nvl(b.thieu,0)-decode(b.madoituong,1,nvl(b.mien,0),0))-nvl(c.sotien,0) thucthu, e.hoten nguoithu, e.hoten ||' ('||to_char(e.userid)||')' userid,'' ngayvao,'' ngayra,'' chandoan,'' maicd,'' tenkp,'' doituong,0 tongcp, 0 tamung "+m_sqlnhom+" from v_vienphill a, ("+asqlht+") aa, btdbn aaa, v_vienphict b, v_mienngtru c, v_quyenso d, medibv.v_dlogin e, (select id, id_loai from v_giavp union all select id, id_loai from ("+asqldmbd+") order by id) f, (select id, id_nhom from v_loaivp union all select 0, 0 from dual order by id) g, (select ma, stt from v_nhomvp union all select 0, 0 from dual order by ma) h, bhyt i, (select mabv, tenbv from tenvien union select mabv, tenbv from tenvien_add) j where a.id=b.id and a.id=c.id(+) and a.mabn=aaa.mabn(+) and a.quyenso=d.id(+) and a.userid=e.id(+) and a.userid=e.id(+) and b.mavp=f.id(+) and f.id_loai=g.id(+) and g.id_nhom=h.ma(+) and a.maql=i.maql(+) and a.quyenso=aa.quyenso(+) and a.sobienlai=aa.sobienlai(+) and i.mabv=j.mabv(+) and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('"+ txtTN.Text.Trim().Substring(0,10) +"','dd/mm/yyyy') and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')<=to_date('"+ txtDN.Text.Trim().Substring(0,10) +"','dd/mm/yyyy') "+exp+" group by a.id, a.quyenso, a.sobienlai, d.sohieu, a.mabn, a.hoten, a.namsinh, i.sothe, aaa.cholam, j.mabv, j.tenbv, c.sotien, e.hoten, a.ngay, e.hoten ||' ('||to_char(e.userid)||')' order by d.sohieu asc, a.sobienlai asc, a.ngay asc";
						sql="select a.id,a.quyenso quyensoid, a.sobienlai, to_char(a.ngay,'dd/mm/yyyy') ngay, d.sohieu quyenso, a.mabn, a.hoten, aaaa.hoten_bo,aaaa.hoten_me, aaa.cholam, nvl(to_char(aaa.ngaysinh,'dd/mm/yyyy'),aaa.namsinh) namsinh, trim(aaa.sonha||' '||aaa.thon) diachi, dc1.tentt, dc2.tenquan,dc3.tenpxa, i.sothe mabhyt, j.mabv, j.tenbv, sum(nvl(b.soluong,0)*nvl(b.dongia,0)) sotien, sum(to_number(decode(b.madoituong,1,nvl(b.mien,0),0))) bhyt, nvl(c.sotien,0) mien, sum(nvl(b.thieu,0)) thieu, sum(nvl(b.soluong,0)*nvl(b.dongia,0)-nvl(b.thieu,0)-to_number(decode(b.madoituong,1,nvl(b.mien,0),0)))-nvl(c.sotien,0) thucthu, e.hoten nguoithu, e.hoten ||' ('||to_char(e.userid)||')' userid,to_char(a.ngay,'dd/mm/yyyy') ngayvao,to_char(a.ngay,'dd/mm/yyyy') ngayra,1 songaydt,'' chandoan,'' maicd,'' tenkp,'' doituong,0 tongcp, 0 tamung "+m_sqlnhom;
                        sql += " from medibvmmyy.v_vienphill a, (" + asqlht + ") aa, medibv.btdbn aaa, medibv.hcnhi aaaa, medibvmmyy.v_vienphict b, medibvmmyy.v_mienngtru c, medibv.v_quyenso d, medibv.v_dlogin e, (select id, id_loai from medibv.v_giavp union all select id, id_loai from (" + asqldmbd + ") froo order by id) f, (select id, id_nhom from medibv.v_loaivp union all select 0, 0 from dual order by id) g, (select ma, stt from medibv.v_nhomvp union all select 0, 0 from dual order by ma) h, medibvmmyy.bhyt i, (select mabv, tenbv from medibv.tenvien union select mabv, tenbv from medibv.tenvien_add) j, medibv.btdtt dc1, medibv.btdquan dc2, medibv.btdpxa dc3 where a.id=b.id and c.id(+)=a.id and aaa.mabn(+)=a.mabn and aaaa.mabn(+)=aaa.mabn and dc1.matt(+)=aaa.matt and dc2.maqu(+)=aaa.maqu and dc3.maphuongxa(+)=aaa.maphuongxa and d.id(+)=a.quyenso and e.id(+)=a.userid and e.id(+)=a.userid and f.id(+)=b.mavp and g.id(+)=f.id_loai and h.ma(+)=g.id_nhom and i.maql(+)=a.maql and aa.quyenso(+)=a.quyenso and aa.sobienlai(+)=a.sobienlai and j.mabv(+)=i.mabv and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('" + txtTN.Text.Trim().Substring(0, 10) + "','dd/mm/yyyy') and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')<=to_date('" + txtDN.Text.Trim().Substring(0, 10) + "','dd/mm/yyyy') " + exp + " group by a.id, a.quyenso, a.sobienlai, d.sohieu, a.mabn, a.hoten,aaaa.hoten_bo,aaaa.hoten_me,aaa.ngaysinh, aaa.namsinh, aaa.sonha, aaa.thon, dc1.tentt, dc2.tenquan, dc3.tenpxa,i.sothe, aaa.cholam, j.mabv, j.tenbv, c.sotien, e.hoten, a.ngay, e.hoten ||' ('||to_char(e.userid)||')' order by a.ngay asc, d.sohieu asc, a.sobienlai asc";
						break;
				}

				//MessageBox.Show(sql);
				ads = m_v.get_data_bc(txtTN.Value,txtDN.Value,sql);
				return ads;
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
				return null;
			}
		}
		private DataSet f_Data_BK_2_NT()
		{
			try
			{
				DataSet ads = new DataSet();
				string sql="";
				string asqlht="select * from medibvmmyy.v_hoantra where to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('"+ txtTN.Text.Trim().Substring(0,10) +"','dd/mm/yyyy') and to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy')<=to_date('"+ txtDN.Text.Trim().Substring(0,10) +"','dd/mm/yyyy')";
				string auserid = f_Get_CheckID(tree_User,1);
				string aquyenso= f_Get_CheckID(tree_User,2);
				string aloaibn= f_Get_CheckID(tree_LoaiBN);
				if(m_v.sys_dungchungso)
				{
					auserid = f_Get_CheckID(tree_User);
					aquyenso = f_Get_CheckID(tree_Quyenso);
				}
				
				string exp="";

				if(auserid.Length>0)
				{
					if(exp.Length>0)
					{
						exp = exp + " and aa.userid in(" + auserid+")";
					}
					else
					{
						exp = "aa.userid in(" + auserid+")";
					}
					asqlht+=" and userid in("+auserid+")";
				}

				if(aquyenso.Length>0)
				{
					if(exp.Length>0)
					{
						exp=exp + " and aa.quyenso in(" + aquyenso +")";
					}
					else
					{
						exp=" aa.quyenso in(" + aquyenso+")";
					}
				}

				if(aloaibn.Length>0)
				{
					if(exp.Length>0)
					{
						exp=exp + " and aa.loaibn in(" + aloaibn+")";
					}
					else
					{
						exp=exp + " aa.loaibn in(" + aloaibn+")";
					}
				}
				if(m_doituongtreem.Length>0)
				{
					if(exp.Length>0)
					{
						exp=exp + " and aaa.madoituong in(" + m_doituongtreem+")";
					}
					else
					{
						exp=exp + " aaa.madoituong in(" + m_doituongtreem+")";
					}
				}

				exp=exp.Trim();
				if(exp.Length>0)
				{
					exp="and "+exp;
				}

				//MessageBox.Show(exp);

                string asqldmbd = "select a1.id id, c1.id_loai id_loai from medibv.d_dmbd a1, medibv.d_dmnhom b1, (select a0.ma, nvl(to_number(b0.id),0) id_loai from medibv.v_nhomvp a0, medibv.v_loaivp b0 where b0.id_nhom(+)=a0.ma) c1 where b1.id(+)=a1.manhom and c1.ma(+)=b1.nhomvp ";
				switch (groupBox1.Tag.ToString())
				{
					case "3"://Loai
						//sql="select a.id, aa.quyenso quyensoid, aa.sobienlai, to_char(aa.ngay,'dd/mm/yyyy') ngay, c.sohieu quyenso, a.mabn, b.hoten, b.cholam, b.namsinh, j.sothe mabhyt, k.mabv, k.tenbv, 0 sotien, nvl(aa.bhyt,0) bhyt, nvl(aa.mien,0) mien, 0 thieu, 0 thucthu, f.hoten nguoithu, f.hoten ||' ('||to_char(f.userid)||')' userid, to_char(a.ngayvao,'dd/mm/yyyy') ngayvao, to_char(a.ngayra,'dd/mm/yyyy') ngayra, a.chandoan, a.maicd, e.tenkp, '' doituong, nvl(aa.sotien,0) tongcp, nvl(aa.tamung,0) tamung "+m_sqlloai_nt+" from v_ttrvds a, v_ttrvll aa, v_ttrvct aaa, ("+asqlht+") aaaa, btdbn b, v_quyenso c, btdkp_bv e, medibv.v_dlogin f, (select id, id_loai from v_giavp union all select id, 0 id_loai from d_dmbd order by id) g, (select id, id_nhom from v_loaivp union all select 0 id, 0 id_nhom from dual order by id) h, (select ma, stt from v_nhomvp union all select 0 ma, 0 stt from dual order by ma) i, bhyt j, (select mabv, tenbv from tenvien union select mabv, tenbv from tenvien_add) k where a.id=aa.id and aa.id=aaa.id(+) and aaa.mavp=g.id and g.id_loai=h.id and h.id_nhom=i.ma and a.mabn=b.mabn and aa.quyenso=c.id(+) and aa.makp=e.makp(+) and aa.userid=f.id(+) and a.maql=j.maql(+) and j.mabv=k.mabv(+) and aa.quyenso=aaaa.quyenso(+) and aa.sobienlai=aaaa.sobienlai(+) and to_date(to_char(aa.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('"+ txtTN.Text.Trim().Substring(0,10) +"','dd/mm/yyyy') and to_date(to_char(aa.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')<=to_date('"+ txtDN.Text.Trim().Substring(0,10) +"','dd/mm/yyyy') "+exp+"  group by a.id, a.mabn, b.hoten, b.cholam, b.namsinh, aa.sobienlai, nvl(aa.sotien,0), nvl(aa.tamung,0), nvl(aa.mien,0), nvl(aa.bhyt,0), to_char(aa.ngay,'dd/mm/yyyy'), c.sohieu, aa.quyenso, e.tenkp, f.hoten, f.hoten ||' ('||to_char(f.userid)||')', j.sothe,to_char(a.ngayvao,'dd/mm/yyyy'), to_char(a.ngayra,'dd/mm/yyyy'), a.chandoan, a.maicd, k.mabv, k.tenbv order by c.sohieu, aa.sobienlai";
						sql="select a.id, aa.quyenso quyensoid, aa.sobienlai, to_char(aa.ngay,'dd/mm/yyyy') ngay, c.sohieu quyenso, a.mabn, b.hoten, b.cholam, nvl(to_char(b.ngaysinh,'dd/mm/yyyy'),b.namsinh) namsinh, trim(b.sonha||' '||b.thon) diachi, dc1.tentt, dc2.tenquan,dc3.tenpxa, j.sothe mabhyt, k.mabv, k.tenbv, 0 sotien, nvl(aa.bhyt,0) bhyt, nvl(aa.mien,0) mien, 0 thieu, 0 thucthu, f.hoten nguoithu, f.hoten ||' ('||to_char(f.userid)||')' userid, to_char(a.ngayvao,'dd/mm/yyyy') ngayvao, to_char(a.ngayra,'dd/mm/yyyy') ngayra, decode(a.ngayra-a.ngayvao,null,1,(a.ngayra-a.ngayvao)+1) songaydt, a.chandoan, a.maicd, e.tenkp, '' doituong, nvl(aa.sotien,0) tongcp, nvl(aa.tamung,0) tamung "+m_sqlloai_nt;
                        sql += " from medibvmmyy.v_ttrvds a, medibvmmyy.v_ttrvll aa, medibvmmyy.v_ttrvct aaa, (" + asqlht + ") aaaa, medibv.btdbn b, medibv.v_quyenso c, medibv.btdkp_bv e, medibv.v_dlogin f, (select id, id_loai from medibv.v_giavp union all select id, 0 id_loai from medibv.d_dmbd order by id) g, (select id, id_nhom from medibv.v_loaivp union all select 0 id, 0 id_nhom from dual order by id) h, (select ma, stt from medibv.v_nhomvp union all select 0 ma, 0 stt from dual order by ma) i, medibvmmyy.bhyt j, (select mabv, tenbv from medibv.tenvien union select mabv, tenbv from medibv.tenvien_add) k, medibv.btdtt dc1, medibv.btdquan dc2, medibv.btdpxa dc3 where a.id=aa.id and aaa.id(+)=aa.id and aaa.mavp=g.id and g.id_loai=h.id and h.id_nhom=i.ma and a.mabn=b.mabn and dc1.matt(+)=b.matt and dc2.maqu(+)=b.maqu and dc3.maphuongxa(+)=b.maphuongxa and c.id(+)=aa.quyenso and e.makp(+)=aa.makp and f.id(+)=aa.userid and j.maql(+)=a.maql and k.mabv(+)=j.mabv and aaaa.quyenso(+)=aa.quyenso and aaaa.sobienlai(+)=aa.sobienlai and to_date(to_char(aa.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('" + txtTN.Text.Trim().Substring(0, 10) + "','dd/mm/yyyy') and to_date(to_char(aa.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')<=to_date('" + txtDN.Text.Trim().Substring(0, 10) + "','dd/mm/yyyy') " + exp + "  group by a.id, a.mabn, b.hoten, b.cholam, b.ngaysinh, b.namsinh, b.sonha, b.thon, dc1.tentt, dc2.tenquan, dc3.tenpxa, aa.sobienlai, nvl(aa.sotien,0), nvl(aa.tamung,0), nvl(aa.mien,0), nvl(aa.bhyt,0), to_char(aa.ngay,'dd/mm/yyyy'), c.sohieu, aa.quyenso, e.tenkp, f.hoten, f.hoten ||' ('||to_char(f.userid)||')', j.sothe,to_char(a.ngayvao,'dd/mm/yyyy'), to_char(a.ngayra,'dd/mm/yyyy'), a.chandoan, a.maicd, k.mabv, k.tenbv, decode(a.ngayra-a.ngayvao,null,1,(a.ngayra-a.ngayvao)+1) order by to_date(ngayvao,'dd/mm/yyyy'), c.sohieu, aa.sobienlai";
						break;
					case "4"://nhom
						//sql="select a.id, aa.quyenso quyensoid, aa.sobienlai, to_char(aa.ngay,'dd/mm/yyyy') ngay, c.sohieu quyenso, a.mabn, b.hoten, b.cholam, b.namsinh, j.sothe mabhyt, k.mabv, k.tenbv, 0 sotien, nvl(aa.bhyt,0) bhyt, nvl(aa.mien,0) mien, 0 thieu, 0 thucthu, f.hoten nguoithu, f.hoten ||' ('||to_char(f.userid)||')' userid, to_char(a.ngayvao,'dd/mm/yyyy') ngayvao, to_char(a.ngayra,'dd/mm/yyyy') ngayra, a.chandoan, a.maicd, e.tenkp, '' doituong, nvl(aa.sotien,0) tongcp, nvl(aa.tamung,0) tamung "+m_sqlnhom_nt+" from v_ttrvds a, v_ttrvll aa, v_ttrvct aaa, ("+asqlht+") aaaa, btdbn b, v_quyenso c, btdkp_bv e, medibv.v_dlogin f, (select id, id_loai from v_giavp union all select id, id_loai from ("+asqldmbd+") order by id) g, (select id, id_nhom from v_loaivp union all select 0 id, 0 id_nhom from dual order by id) h, (select ma, stt from v_nhomvp union all select 0 ma, 0 stt from dual order by ma) i, bhyt j, (select mabv, tenbv from tenvien union select mabv, tenbv from tenvien_add) k where a.id=aa.id and aa.id=aaa.id(+) and aaa.mavp=g.id and g.id_loai=h.id and h.id_nhom=i.ma and a.mabn=b.mabn and aa.quyenso=c.id(+) and aa.makp=e.makp(+) and aa.userid=f.id(+) and a.maql=j.maql(+) and j.mabv=k.mabv(+) and aa.quyenso=aaaa.quyenso(+) and aa.sobienlai=aaaa.sobienlai(+) and to_date(to_char(aa.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('"+ txtTN.Text.Trim().Substring(0,10) +"','dd/mm/yyyy') and to_date(to_char(aa.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')<=to_date('"+ txtDN.Text.Trim().Substring(0,10) +"','dd/mm/yyyy') "+exp+"  group by a.id, a.mabn, b.hoten, b.cholam, b.namsinh, aa.sobienlai, nvl(aa.sotien,0), nvl(aa.tamung,0), nvl(aa.mien,0), nvl(aa.bhyt,0), to_char(aa.ngay,'dd/mm/yyyy'), c.sohieu, aa.quyenso, e.tenkp, f.hoten, f.hoten ||' ('||to_char(f.userid)||')', j.sothe, to_char(a.ngayvao,'dd/mm/yyyy'), to_char(a.ngayra,'dd/mm/yyyy'), a.chandoan, a.maicd, k.mabv, k.tenbv order by c.sohieu, aa.sobienlai";
						sql="select a.id, aa.quyenso quyensoid, aa.sobienlai, to_char(aa.ngay,'dd/mm/yyyy') ngay, c.sohieu quyenso, a.mabn, b.hoten, b.cholam, nvl(to_char(b.ngaysinh,'dd/mm/yyyy'),b.namsinh) namsinh, trim(b.sonha||' '||b.thon) diachi, dc1.tentt, dc2.tenquan,dc3.tenpxa, j.sothe mabhyt, k.mabv, k.tenbv, 0 sotien, nvl(aa.bhyt,0) bhyt, nvl(aa.mien,0) mien, 0 thieu, 0 thucthu, f.hoten nguoithu, f.hoten ||' ('||to_char(f.userid)||')' userid, to_char(a.ngayvao,'dd/mm/yyyy') ngayvao, to_char(a.ngayra,'dd/mm/yyyy') ngayra, decode(a.ngayra-a.ngayvao,null,1,(a.ngayra-a.ngayvao)+1) songaydt, a.chandoan, a.maicd, e.tenkp, '' doituong, nvl(aa.sotien,0) tongcp, nvl(aa.tamung,0) tamung "+m_sqlnhom_nt;
                        sql += " from medibvmmyy.v_ttrvds a, medibvmmyy.v_ttrvll aa, medibvmmyy.v_ttrvct aaa, (" + asqlht + ") aaaa, medibv.btdbn b, medibv.v_quyenso c, medibv.btdkp_bv e, medibv.v_dlogin f, (select id, id_loai from medibv.v_giavp union all select id, id_loai from (" + asqldmbd + ") froo order by id) g, (select id, id_nhom from medibv.v_loaivp union all select 0 id, 0 id_nhom from dual order by id) h, (select ma, stt from medibv.v_nhomvp union all select 0 ma, 0 stt from dual order by ma) i, medibvmmyy.bhyt j, (select mabv, tenbv from medibv.tenvien union select mabv, tenbv from medibv.tenvien_add) k, medibv.btdtt dc1, medibv.btdquan dc2, medibv.btdpxa dc3 where a.id=aa.id and aaa.id(+)=aa.id and aaa.mavp=g.id and g.id_loai=h.id and h.id_nhom=i.ma and a.mabn=b.mabn and dc1.matt(+)=b.matt and dc2.maqu(+)=b.maqu and dc3.maphuongxa(+)=b.maphuongxa and c.id(+)=aa.quyenso and e.makp(+)=aa.makp and f.id(+)=aa.userid and j.maql(+)=a.maql and k.mabv(+)=j.mabv and aaaa.quyenso(+)=aa.quyenso and aaaa.sobienlai(+)=aa.sobienlai and to_date(to_char(aa.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('" + txtTN.Text.Trim().Substring(0, 10) + "','dd/mm/yyyy') and to_date(to_char(aa.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')<=to_date('" + txtDN.Text.Trim().Substring(0, 10) + "','dd/mm/yyyy') " + exp + "  group by a.id, a.mabn, b.hoten, b.cholam, b.ngaysinh, b.namsinh, b.sonha, b.thon, dc1.tentt, dc2.tenquan, dc3.tenpxa, aa.sobienlai, nvl(aa.sotien,0), nvl(aa.tamung,0), nvl(aa.mien,0), nvl(aa.bhyt,0), to_char(aa.ngay,'dd/mm/yyyy'), c.sohieu, aa.quyenso, e.tenkp, f.hoten, f.hoten ||' ('||to_char(f.userid)||')', j.sothe, to_char(a.ngayvao,'dd/mm/yyyy'), to_char(a.ngayra,'dd/mm/yyyy'), a.chandoan, a.maicd, k.mabv, k.tenbv,decode(a.ngayra-a.ngayvao,null,1,(a.ngayra-a.ngayvao)+1) order by to_date(ngayvao,'dd/mm/yyyy'), c.sohieu, aa.sobienlai";
						break;
				}

				//MessageBox.Show(sql);
				ads = m_v.get_data_bc(txtTN.Value,txtDN.Value,sql);
				//MessageBox.Show(ads.Tables[0].Rows.Count.ToString());
				return ads;
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
				return null;
			}
		}
		private DataSet f_Cursor_Tonghop()
		{
			try
			{
				DataSet ads = new DataSet();
				string sql="";
				if(rd1.Checked)
				{
                    sql = "select a.id, a.ma, a.ten,0 soluongnt, 0 soluongnt_lk, 0 sotiennt, 0 sotiennt_lk, 0 soluongngt, 0 soluongngt_lk, 0 sotienngt, 0 sotienngt_lk from medibv.v_loaivp a order by a.stt";
				}
				else
					if(rd2.Checked)
				{
                    sql = "select a.ma id, '' ma, a.ten,0 soluongnt, 0 soluongnt_lk, 0 sotiennt, 0 sotiennt_lk, 0 soluongngt, 0 soluongngt_lk, 0 sotienngt, 0 sotienngt_lk from medibv.v_nhomvp a order by a.stt";
				}
				ads=m_v.get_data(sql);
				return ads;
			}
			catch
			{
				return null;
			}
		}
		private string f_StringDate(DateTime v_dt)
		{
			try
			{
				return v_dt.Day.ToString().PadLeft(2,'0')+"/"+v_dt.Month.ToString().PadLeft(2,'0')+"/"+v_dt.Year.ToString();
			}
			catch
			{
				return "";
			}
		}
		private void f_InBK_1()
		{
			try
			{
				DataSet ads = new DataSet();
				DataSet ads1 = new DataSet();
				DataSet adsmien = new DataSet();
				DataSet adsbhyt = new DataSet();

				string sql="", asql1="",asqlht="";
				string exp="", agroup="", aluykethang="", aluykenam="";
				string auserid=f_Get_CheckID(tree_User,1);
				string aquyensoid=f_Get_CheckID(tree_User,2);
				string aloaibn=f_Get_CheckID(tree_LoaiBN);
				if(m_v.sys_dungchungso)
				{
					auserid = f_Get_CheckID(tree_User);
					aquyensoid = f_Get_CheckID(tree_Quyenso);
				}
				
				DateTime ad1=txtTN.Value;
				DateTime ad2=txtDN.Value;
				aluykethang=lan.Change_language_MessageText("LŨY KẾ THÁNG")+" "+ ad2.Month.ToString().PadLeft(2,'0')+"/"+ad2.Year.ToString();
				aluykenam=lan.Change_language_MessageText("LŨY KẾ NĂM")+" "+ad2.Year.ToString();

				switch(groupBox1.Tag.ToString())
				{
					case "1"://Loaivp
                        sql = "select to_char(a.id) id, a.ma, a.ten, 0 soluongnt, 0 soluongnt_lkt, 0 soluongnt_lkn, 0 sotiennt, 0 sotiennt_lkt, 0 sotiennt_lkn, 0 soluongngt, 0 soluongngt_lkt, 0 soluongngt_lkn, 0 sotienngt, 0 sotienngt_lkt, 0 sotienngt_lkn from medibv.v_loaivp a order by a.stt";
						agroup="nvl(to_number(c.id),0)";
						break;
					case "2"://nhomvp
                        agroup = "nvl(to_number(e.id),0)";
                        sql = "select to_char(a.ma) id, '' ma, a.ten, 0 soluongnt, 0 soluongnt_lkt, 0 soluongnt_lkn, 0 sotiennt, 0 sotiennt_lkt, 0 sotiennt_lkn, 0 soluongngt, 0 soluongngt_lkt, 0 soluongngt_lkn, 0 sotienngt, 0 sotienngt_lkt, 0 sotienngt_lkn from medibv.v_nhomvp a order by a.stt";
						break;
					default:
                        agroup = "nvl(to_number(e.id),0)";
                        sql = "select to_char(a.ma) id, '' ma, a.ten, 0 soluongnt, 0 soluongnt_lkt, 0 soluongnt_lkn, 0 sotiennt, 0 sotiennt_lkt, 0 sotiennt_lkn, 0 soluongngt, 0 soluongngt_lkt, 0 soluongngt_lkn, 0 sotienngt, 0 sotienngt_lkt, 0 sotienngt_lkn from medibv.v_nhomvp a order by a.stt";
						break;
				}
				ads = m_v.get_data(sql);
				
				DataRow rtmp;	
				if(groupBox1.Tag.ToString()=="2")
				{
					try
					{
						rtmp = ads.Tables[0].Select("id=0")[0];
						rtmp["ma"]="THUOC";
						rtmp["ten"]=lan.Change_language_MessageText("Thuốc khoa dược");
					}
					catch
					{
						rtmp = ads.Tables[0].NewRow();
						rtmp["id"]="0";
						rtmp["ma"]="THUOC";
						rtmp["ten"]=lan.Change_language_MessageText("Thuốc khoa dược");
						rtmp["soluongnt"]=0;
						rtmp["soluongnt_lkt"]=0;
						rtmp["soluongnt_lkn"]=0;
						rtmp["sotiennt"]=0;
						rtmp["sotiennt_lkt"]=0;
						rtmp["sotiennt_lkn"]=0;
						rtmp["soluongngt"]=0;
						rtmp["soluongngt_lkt"]=0;
						rtmp["soluongngt_lkn"]=0;
						rtmp["sotienngt"]=0;
						rtmp["sotienngt_lkt"]=0;
						rtmp["sotienngt_lkn"]=0;
						ads.Tables[0].Rows.Add(rtmp);
					}
				}

				//Sotien
				try
				{
					exp=" and to_date(to_char(d.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('"+f_StringDate(ad1)+"','dd/mm/yyyy') and to_date(to_char(d.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')<=to_date('"+f_StringDate(ad2)+"','dd/mm/yyyy')";
					asqlht="select * from medibvmmyy.v_hoantra where to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('"+f_StringDate(ad1)+"','dd/mm/yyyy') and to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy')<=to_date('"+f_StringDate(ad2)+"','dd/mm/yyyy')";
					if(auserid!="")
					{
						exp+=" and d.userid in("+auserid+")";
						asqlht+=" and userid in ("+auserid+")";
					}
					if(aquyensoid!="")
					{
						exp+=" and d.quyenso in("+aquyensoid+")";
					}
					if(aloaibn!="")
					{
						exp+=" and d.loaibn in("+aloaibn+")";
					}

					if(m_doituongtreem.Length>0)
					{
						if(exp.Length>0)
						{
							exp=exp + " and a.madoituong in(" + m_doituongtreem+")";
						}
						else
						{
							exp=exp + " a.madoituong in(" + m_doituongtreem+")";
						}
					}
					
					if(chkTructiep.Checked || (!chkTructiep.Checked && !chkThanhtoanravien.Checked))
					{
                        asql1 = "select id, sum(sotien) sotien, count(idhd) soluong from (select to_char(" + agroup + ") id, sum(to_number(decode(f.id, null, nvl(a.soluong,0)*nvl(a.dongia,0)-nvl(a.thieu,0),0))) sotien, a.id idhd from medibvmmyy.v_vienphict a, (select id, id_loai from medibv.v_giavp union all select id, 0 id_loai from medibv.d_dmbd) b, (select id, id_nhom from medibv.v_loaivp union all select 0 id, 0 id_nhom from dual) c, medibvmmyy.v_vienphill d, (select ma id from medibv.v_nhomvp union all select 0 from dual) e, (" + asqlht + ") f where a.id=d.id and b.id(+)=a.mavp and c.id(+)=b.id_loai and e.id(+)=c.id_nhom and f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp + " group by a.id, " + agroup + ") froo group by id";
						ads1=m_v.get_data_bc(txtTN.Value,txtDN.Value,asql1);
						//MessageBox.Show(ads1.Tables[0].Rows.Count.ToString());
						for(int i=0;i<ads.Tables[0].Rows.Count;i++)
						{
							try
							{
								foreach(DataRow r in ads1.Tables[0].Select("id='"+ads.Tables[0].Rows[i]["id"].ToString().Trim()+"'"))
								{
									ads.Tables[0].Rows[i]["sotienngt"]=decimal.Parse(ads.Tables[0].Rows[i]["sotienngt"].ToString())+decimal.Parse(r["sotien"].ToString());
									ads.Tables[0].Rows[i]["soluongngt"]=decimal.Parse(ads.Tables[0].Rows[i]["soluongngt"].ToString())+decimal.Parse(r["soluong"].ToString());
								}
							}
							catch
							{
							}
						}
					}
					if(chkThanhtoanravien.Checked || (!chkTructiep.Checked && !chkThanhtoanravien.Checked))
					{
                        asql1 = "select to_char(" + agroup + ") id, sum(to_number(decode(f.id,null,nvl(a.soluong,0)*nvl(a.dongia,0)+nvl(a.soluong,0)*nvl(a.dongia,0)*round(nvl(a.vat,0)/100,3),0))) sotien, count(a.id) soluong, a.id idhd from medibvmmyy.v_ttrvct a, (select id, id_loai from medibv.v_giavp union all select id, 0 id_loai from medibv.d_dmbd) b, (select id, id_nhom from medibv.v_loaivp union all select 0 id, 0 id_nhom from dual) c, medibvmmyy.v_ttrvll d, (select ma id from medibv.v_nhomvp union all select 0 from dual) e, (" + asqlht + ") f where a.id=d.id and b.id(+)=a.mavp and c.id(+)=b.id_loai and e.id(+)=c.id_nhom and f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp + " group by a.id, " + agroup;
						ads1=m_v.get_data_bc(txtTN.Value,txtDN.Value,asql1);
						for(int i=0;i<ads.Tables[0].Rows.Count;i++)
						{
							try
							{
								foreach(DataRow r in ads1.Tables[0].Select("id='"+ads.Tables[0].Rows[i]["id"].ToString().Trim()+"'"))
								{
									ads.Tables[0].Rows[i]["sotiennt"]=decimal.Parse(ads.Tables[0].Rows[i]["sotiennt"].ToString())+decimal.Parse(r["sotien"].ToString());
									ads.Tables[0].Rows[i]["soluongnt"]=decimal.Parse(ads.Tables[0].Rows[i]["soluongnt"].ToString())+decimal.Parse(r["soluong"].ToString());
								}
							}
							catch
							{
							}
						}
					}
				}
				catch
				{
				}
				//Luy ke thang
				try
				{
					exp=" and to_date(to_char(d.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('01"+txtDN.Text.Substring(2,8)+"','dd/mm/yyyy') and to_date(to_char(d.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')<=to_date('"+txtDN.Text.Substring(0,10)+"','dd/mm/yyyy')";
					asqlht="select * from medibvmmyy.v_hoantra where to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('01"+txtDN.Text.Substring(2,8)+"','dd/mm/yyyy') and to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy')<=to_date('"+txtDN.Text.Substring(0,10)+"','dd/mm/yyyy')";
					if(auserid!="")
					{
						exp=exp+" and d.userid in("+auserid+")";
						asqlht+=" and userid in ("+auserid+")";
					}
					if(aquyensoid!="")
					{
						exp=exp+" and d.quyenso in("+aquyensoid+")";
					}
					if(aloaibn!="")
					{
						exp=exp+" and d.loaibn in("+aloaibn+")";
					}
					if(m_doituongtreem.Length>0)
					{
						if(exp.Length>0)
						{
							exp=exp + " and a.madoituong in(" + m_doituongtreem+")";
						}
						else
						{
							exp=exp + " a.madoituong in(" + m_doituongtreem+")";
						}
					}
					if(chkTructiep.Checked || (!chkTructiep.Checked && !chkThanhtoanravien.Checked))
					{
                        asql1 = "select id, sum(sotien) sotien, count(idhd) soluong from (select to_char(" + agroup + ") id, sum(to_number(decode(f.id, null, nvl(a.soluong,0)*nvl(a.dongia,0)-nvl(a.thieu,0),0))) sotien, a.id idhd from medibvmmyy.v_vienphict a, (select id, id_loai from medibv.v_giavp union all select id, 0 id_loai from medibv.d_dmbd) b, (select id, id_nhom from medibv.v_loaivp union all select 0 id, 0 id_nhom from dual) c, medibvmmyy.v_vienphill d, (select ma id from medibv.v_nhomvp union all select 0 from dual) e, (" + asqlht + ") f where a.id=d.id and b.id(+)=a.mavp and c.id(+)=b.id_loai and e.id(+)=c.id_nhom and f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp + " group by a.id, " + agroup + ") froo group by id";
						ads1=m_v.get_data_bc(txtTN.Value,txtDN.Value,asql1);
						//MessageBox.Show(ads1.Tables[0].Rows.Count.ToString());
						for(int i=0;i<ads.Tables[0].Rows.Count;i++)
						{
							try
							{
								foreach(DataRow r in ads1.Tables[0].Select("id='"+ads.Tables[0].Rows[i]["id"].ToString().Trim()+"'"))
								{
									ads.Tables[0].Rows[i]["sotienngt_lkt"]=decimal.Parse(ads.Tables[0].Rows[i]["sotienngt_lkt"].ToString())+decimal.Parse(r["sotien"].ToString());
									ads.Tables[0].Rows[i]["soluongngt_lkt"]=decimal.Parse(ads.Tables[0].Rows[i]["soluongngt_lkt"].ToString())+decimal.Parse(r["soluong"].ToString());
								}
							}
							catch
							{
							}
						}
					}
					if(chkThanhtoanravien.Checked || (!chkTructiep.Checked && !chkThanhtoanravien.Checked))
					{
                        asql1 = "select to_char(" + agroup + ") id, sum(to_number(decode(f.id,null,nvl(a.soluong,0)*nvl(a.dongia,0)+nvl(a.soluong,0)*nvl(a.dongia,0)*round(nvl(a.vat,0)/100,3),0))) sotien, count(a.id) soluong, a.id idhd from medibvmmyy.v_ttrvct a, (select id, id_loai from medibv.v_giavp union all select id, 0 id_loai from medibv.d_dmbd) b, (select id, id_nhom from medibv.v_loaivp union all select 0 id, 0 id_nhom from dual) c, medibvmmyy.v_ttrvll d, (select ma id from medibv.v_nhomvp union all select 0 from dual) e, (" + asqlht + ") f where a.id=d.id and b.id(+)=a.mavp and c.id(+)=b.id_loai and e.id(+)=c.id_nhom and f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp + " group by a.id, " + agroup;
						ads1=m_v.get_data_bc(txtTN.Value,txtDN.Value,asql1);
						for(int i=0;i<ads.Tables[0].Rows.Count;i++)
						{
							try
							{
								foreach(DataRow r in ads1.Tables[0].Select("id='"+ads.Tables[0].Rows[i]["id"].ToString().Trim()+"'"))
								{
									ads.Tables[0].Rows[i]["sotiennt_lkt"]=decimal.Parse(ads.Tables[0].Rows[i]["sotiennt_lkt"].ToString())+decimal.Parse(r["sotien"].ToString());
									ads.Tables[0].Rows[i]["soluongnt_lkt"]=decimal.Parse(ads.Tables[0].Rows[i]["soluongnt_lkt"].ToString())+decimal.Parse(r["soluong"].ToString());
								}
							}
							catch
							{
							}
						}
					}
				}
				catch
				{
				}

				//Luy ke nam
				try
				{
					exp=" and to_date(to_char(d.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('01/01"+txtDN.Text.Substring(5,5)+"','dd/mm/yyyy') and to_date(to_char(d.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')<=to_date('"+txtDN.Text.Substring(0,10)+"','dd/mm/yyyy')";
					asqlht="select * from medibvmmyy.v_hoantra where to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('01/01"+txtDN.Text.Substring(5,5)+"','dd/mm/yyyy') and to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy')<=to_date('"+txtDN.Text.Substring(0,10)+"','dd/mm/yyyy')";
					if(auserid!="")
					{
						exp=exp+" and d.userid in("+auserid+")";
						asqlht+=" and userid in ("+auserid+")";
					}
					if(aquyensoid!="")
					{
						exp=exp+" and d.quyenso in("+aquyensoid+")";
					}
					if(aloaibn!="")
					{
						exp=exp+" and d.loaibn in("+aloaibn+")";
					}
					if(m_doituongtreem.Length>0)
					{
						if(exp.Length>0)
						{
							exp=exp + " and a.madoituong in(" + m_doituongtreem+")";
						}
						else
						{
							exp=exp + " a.madoituong in(" + m_doituongtreem+")";
						}
					}
					if(chkTructiep.Checked || (!chkTructiep.Checked && !chkThanhtoanravien.Checked))
					{
                        asql1 = "select id, sum(sotien) sotien, count(idhd) soluong from (select to_char(" + agroup + ") id, sum(to_number(decode(f.id, null, nvl(a.soluong,0)*nvl(a.dongia,0)-nvl(a.thieu,0),0))) sotien, a.id idhd from medibvmmyy.v_vienphict a, (select id, id_loai from medibv.v_giavp union all select id, 0 id_loai from medibv.d_dmbd) b, (select id, id_nhom from medibv.v_loaivp union all select 0 id, 0 id_nhom from dual) c, medibvmmyy.v_vienphill d, (select ma id from medibv.v_nhomvp union all select 0 from dual) e, (" + asqlht + ") f where a.id=d.id and b.id(+)=a.mavp and c.id(+)=b.id_loai and e.id(+)=c.id_nhom and f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp + " group by a.id, " + agroup + ") froo group by id";
						ads1=m_v.get_data_bc(txtTN.Value,txtDN.Value,asql1);
						//MessageBox.Show(ads1.Tables[0].Rows.Count.ToString());
						for(int i=0;i<ads.Tables[0].Rows.Count;i++)
						{
							try
							{
								foreach(DataRow r in ads1.Tables[0].Select("id='"+ads.Tables[0].Rows[i]["id"].ToString().Trim()+"'"))
								{
									ads.Tables[0].Rows[i]["sotienngt_lkn"]=decimal.Parse(ads.Tables[0].Rows[i]["sotienngt_lkn"].ToString())+decimal.Parse(r["sotien"].ToString());
									ads.Tables[0].Rows[i]["soluongngt_lkn"]=decimal.Parse(ads.Tables[0].Rows[i]["soluongngt_lkn"].ToString())+decimal.Parse(r["soluong"].ToString());
								}
							}
							catch
							{
							}
						}
					}
					if(chkThanhtoanravien.Checked || (!chkTructiep.Checked && !chkThanhtoanravien.Checked))
					{
                        asql1 = "select to_char(" + agroup + ") id, sum(to_number(decode(f.id,null,nvl(a.soluong,0)*nvl(a.dongia,0)+nvl(a.soluong,0)*nvl(a.dongia,0)*round(nvl(a.vat,0)/100,3),0))) sotien, count(a.id) soluong, a.id idhd from medibvmmyy.v_ttrvct a, (select id, id_loai from medibv.v_giavp union all select id, 0 id_loai from medibv.d_dmbd) b, (select id, id_nhom from medibv.v_loaivp union all select 0 id, 0 id_nhom from dual) c, medibvmmyy.v_ttrvll d, (select ma id from medibv.v_nhomvp union all select 0 from dual) e, (" + asqlht + ") f where a.id=d.id and b.id(+)=a.mavp and c.id(+)=b.id_loai and e.id(+)=c.id_nhom and f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp + " group by a.id, " + agroup;
						ads1=m_v.get_data_bc(txtTN.Value,txtDN.Value,asql1);
						for(int i=0;i<ads.Tables[0].Rows.Count;i++)
						{
							try
							{
								foreach(DataRow r in ads1.Tables[0].Select("id='"+ads.Tables[0].Rows[i]["id"].ToString().Trim()+"'"))
								{
									ads.Tables[0].Rows[i]["sotiennt_lkn"]=decimal.Parse(ads.Tables[0].Rows[i]["sotiennt_lkn"].ToString())+decimal.Parse(r["sotien"].ToString());
									ads.Tables[0].Rows[i]["soluongnt_lkn"]=decimal.Parse(ads.Tables[0].Rows[i]["soluongnt_lkn"].ToString())+decimal.Parse(r["soluong"].ToString());
								}
							}
							catch
							{
							}
						}
					}

				}
				catch
				{
				}

				int asn=0;
				try
				{
					TimeSpan ats = ad2-ad1;
					asn=ats.Days;
				}
				catch
				{
					asn=0;
				}

				//Xoá cac record neu khong phat sinh
				try
				{
					if(chkPhatsinh.Checked)
					{
						while(ads.Tables[0].Select("sotiennt=0 and sotiennt_lk=0 and sotienngt=0 and sotienngt_lk=0").Length>0)
						{
							ads.Tables[0].Rows.Remove(ads.Tables[0].Select("sotiennt=0 and sotiennt_lk=0 and sotienngt=0 and sotienngt_lk=0")[0]);
						}
					}
				}
				catch
				{
				}

				if(ads.Tables[0].Rows.Count<=0)
				{
					progressBar1.Value=progressBar1.Maximum;
					timer1.Enabled=false;
					progressBar1.Value=0;
					MessageBox.Show(this,
lan.Change_language_MessageText("Không có dữ liệu báo cáo"),m_v.s_AppName,MessageBoxButtons.OK,MessageBoxIcon.Information);
					return;
				}
				//return;
				//dataGrid1.DataSource=ads.Tables[0];

				CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
				crystalReportViewer1.ActiveViewIndex = -1;
				crystalReportViewer1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(239)), ((System.Byte)(239)), ((System.Byte)(239)));
				crystalReportViewer1.DisplayGroupTree = false;
				crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
				crystalReportViewer1.Name = "crystalReportViewer1";
				crystalReportViewer1.ReportSource = null;
				crystalReportViewer1.Size = new System.Drawing.Size(792, 573);
				crystalReportViewer1.TabIndex = 85;

				System.Windows.Forms.Form af = new System.Windows.Forms.Form();
				af.WindowState=FormWindowState.Maximized;
				af.Controls.Add(crystalReportViewer1);
				af.Text=
lan.Change_language_MessageText("Báo cáo trẻ em");
				crystalReportViewer1.BringToFront();
				crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;

				string areport="",asyt="",abv="",angayin="",anguoiin="",aghichu="";
				areport="v_baocaotreem_th.rpt";
				switch(groupBox1.Tag.ToString())
				{
					case "1":
						areport="v_baocaotreem_th.rpt";
						break;
					case "2":
						areport="v_baocaotreem_th.rpt";
						break;
					default:
						areport="v_baocaotreem_th.rpt";
						break;
				}

				if(cbMaubaocao.SelectedIndex>0)
				{
					string areportt=areport.Replace(".rpt","_"+cbMaubaocao.SelectedValue.ToString().Trim()+".rpt");
					if(System.IO.File.Exists("..\\..\\..\\report\\"+areportt))
					{
						areport=areportt;
					}
				}

				asyt = m_v.Syte;
				abv = m_v.Tenbv;
				angayin ="Ngày " + txtNgayIn.Value.Day.ToString().PadLeft(2,'0') + " tháng " + txtNgayIn.Value.Month.ToString().PadLeft(2,'0') + " năm " + txtNgayIn.Value.Year.ToString();
				anguoiin = txtNguoilapphieu.Text.Trim();
				aghichu = f_Get_GhiChu();
				if(menuItem1.Checked)
				{
					ads.WriteXml("..//..//Datareport//v_"+areport.Replace(".rpt","")+".xml", XmlWriteMode.WriteSchema);
					MessageBox.Show("..//..//Datareport//v_"+areport.Replace(".rpt","")+".xml");
				}
				ReportDocument cMain=new ReportDocument();
				cMain.Load("..\\..\\..\\report\\"+areport, OpenReportMethod.OpenReportByTempCopy);
				cMain.SetDataSource(ads);
				cMain.DataDefinition.FormulaFields["v_syt"].Text="'"+asyt.ToUpper()+"'";
				cMain.DataDefinition.FormulaFields["v_bv"].Text="'"+abv.ToUpper()+"'";
				cMain.DataDefinition.FormulaFields["v_ngayin"].Text="'"+angayin+"'";
				cMain.DataDefinition.FormulaFields["v_nguoiin"].Text="'"+anguoiin+"'";
				cMain.DataDefinition.FormulaFields["v_ghichu"].Text="'"+aghichu+"'";
				cMain.DataDefinition.FormulaFields["v_nguoilapphieu"].Text="'"+txtNguoilapphieu.Text.Trim()+"'";
				cMain.DataDefinition.FormulaFields["v_ketoan"].Text="'"+txtKetoanvp.Text.Trim()+"'";
				cMain.DataDefinition.FormulaFields["v_giamdoc"].Text="'"+txtGiamdoc.Text.Trim()+"'";
				//cMain.PrintOptions.PaperSize=CrystalDecisions.Shared.PaperSize.PaperA4; 
				//cMain.PrintOptions.PaperOrientation=CrystalDecisions.Shared.PaperOrientation.Landscape; 
				crystalReportViewer1.ReportSource=cMain;
				af.Text=af.Text+" ("+areport+")";
				af.ShowDialog();
				ads.Dispose();
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}
		private void f_InBK_2()
		{
			try
			{
				DataSet ads = new DataSet();
				DataSet ads1 = new DataSet();
				DataSet ads2 = new DataSet();
				if((chkTructiep.Checked && chkThanhtoanravien.Checked) || (!chkTructiep.Checked && !chkThanhtoanravien.Checked))
				{
					ads1=f_Data_BK_2_TT();
					ads2=f_Data_BK_2_NT();
					if(ads1==null && ads2==null)
					{
						ads=null;
					}
					else
						if(ads1!=null && ads2!=null)
					{
						ads=ads1;
						ads.Merge(ads2);
					}
					else
						if(ads1!=null)
					{
						ads=ads1;
					}
					else
					{
						ads=ads2;
					}
				}
				else
					if(chkTructiep.Checked)
				{
					ads=f_Data_BK_2_TT();
				}
				else
				{
					ads=f_Data_BK_2_NT();
				}

				ads1.Dispose();
				ads2.Dispose();

				if(ads.Tables[0].Rows.Count<=0)
				{
					progressBar1.Value=progressBar1.Maximum;
					timer1.Enabled=false;
					progressBar1.Value=0;
					MessageBox.Show(this,
lan.Change_language_MessageText("Không có dữ liệu báo cáo"),m_v.s_AppName,MessageBoxButtons.OK,MessageBoxIcon.Information);
					return;
				}
				string areport="v_baocaotreem_ct_loai.rpt";
				string apre=rdNoitru.Checked?"noitru":"ngoaitru";
				switch (groupBox1.Tag.ToString())
				{
					case "3"://Loai A4
						areport="v_baocaotreem"+apre+"_ct_loai.rpt";
						//ads.WriteXml("..//..//Datareport//v_bangkethutructiep_ct_loai.xml", XmlWriteMode.WriteSchema);
						break;
					case "4"://Nhom A4
						areport="v_baocaotreem"+apre+"_ct_nhom.rpt";
						//ads.WriteXml("..//..//Datareport//v_bangkethutructiep_ct_nhom.xml", XmlWriteMode.WriteSchema);
						break;
				}
				if(menuItem1.Checked)
				{
					ads.WriteXml("..//..//Datareport//v_"+areport.Replace(".rpt","")+".xml", XmlWriteMode.WriteSchema);
				}

				//dataGrid1.DataSource=ads.Tables[0];

				CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
				crystalReportViewer1.ActiveViewIndex = -1;
				crystalReportViewer1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(239)), ((System.Byte)(239)), ((System.Byte)(239)));
				crystalReportViewer1.DisplayGroupTree = false;
				crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
				crystalReportViewer1.Name = "crystalReportViewer1";
				crystalReportViewer1.ReportSource = null;
				crystalReportViewer1.Size = new System.Drawing.Size(792, 573);
				crystalReportViewer1.TabIndex = 85;

				System.Windows.Forms.Form af = new System.Windows.Forms.Form();
				af.WindowState=FormWindowState.Maximized;
				af.Controls.Add(crystalReportViewer1);
				af.Text=rd1.Text;
				crystalReportViewer1.BringToFront();
				crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;

				string asyt="",abv="",angayin="",anguoiin="",aghichu="";
				asyt = m_v.Syte;
				abv = m_v.Tenbv;
				angayin =lan.Change_language_MessageText("Ngày")+" " + txtNgayIn.Value.Day.ToString().PadLeft(2,'0') + " "+lan.Change_language_MessageText("tháng")+" " + txtNgayIn.Value.Month.ToString().PadLeft(2,'0') + " "+lan.Change_language_MessageText("năm")+" " + txtNgayIn.Value.Year.ToString();
				anguoiin = txtNguoilapphieu.Text.Trim();
				aghichu = f_Get_GhiChu();

				if(cbMaubaocao.SelectedIndex>0)
				{
					string areportt=areport.Replace(".rpt","_"+cbMaubaocao.SelectedValue.ToString().Trim()+".rpt");
					if(System.IO.File.Exists("..\\..\\..\\report\\"+areportt))
					{
						areport=areportt;
					}
				}

				ReportDocument cMain=new ReportDocument();
				cMain.Load("..\\..\\..\\report\\"+areport, OpenReportMethod.OpenReportByTempCopy);
				cMain.SetDataSource(ads);
				cMain.DataDefinition.FormulaFields["v_syt"].Text="'"+asyt.ToUpper()+"'";
				cMain.DataDefinition.FormulaFields["v_bv"].Text="'"+abv.ToUpper()+"'";
				cMain.DataDefinition.FormulaFields["v_ngayin"].Text="'"+angayin+"'";
				cMain.DataDefinition.FormulaFields["v_nguoiin"].Text="'"+anguoiin+"'";
				cMain.DataDefinition.FormulaFields["v_ghichu"].Text="'"+aghichu+"'";
				cMain.DataDefinition.FormulaFields["v_nguoilapphieu"].Text="'"+txtNguoilapphieu.Text.Trim()+"'";
				cMain.DataDefinition.FormulaFields["v_ketoan"].Text="'"+txtKetoanvp.Text.Trim()+"'";
				cMain.DataDefinition.FormulaFields["v_giamdoc"].Text="'"+txtGiamdoc.Text.Trim()+"'";
				crystalReportViewer1.ReportSource=cMain;
				af.Text=af.Text+" ("+areport+")";
				af.ShowDialog();
				ads.Dispose();
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}
		private void butInBK_Click(object sender, System.EventArgs e)
		{	
			string atmp=System.Environment.CurrentDirectory;
			try
			{
				butInBK.Enabled=false;
				progressBar1.Value=1;
				timer1.Enabled=true;
				this.Cursor=Cursors.WaitCursor;
				try
				{
					switch(groupBox1.Tag.ToString())
					{
						case "1":
						case "2":
							f_InBK_1();
							break;
						case "3"://Theo loai vp
						case "4"://Theo nhom vp
							f_InBK_2();
							break;
					}
				}
				catch
				{
				}
				f_SaveHistory();
				butInBK.Enabled=true;
				this.Cursor=Cursors.Default;
				timer1.Enabled=false;
				progressBar1.Value=progressBar1.Minimum;
			}
			catch
			{
			}
			finally
			{
				System.Environment.CurrentDirectory=atmp;
			}
		}

		private void txtTN_Validated(object sender, System.EventArgs e)
		{
			try
			{
				DateTime ad1 = new DateTime(txtTN.Value.Year,txtTN.Value.Month,txtTN.Value.Day);
				DateTime ad2 = new DateTime(txtDN.Value.Year,txtDN.Value.Month,txtDN.Value.Day);
				if(ad1>ad2)
				{
					//MessageBox.Show(this,"Ngày cần thống kê không hợp lệ",m_v.s_AppName, MessageBoxButtons.OK,MessageBoxIcon.Information);
					//txtTN.Focus();
					txtDN.Value=txtTN.Value;
				}
			}
			catch
			{
			}
		}
		private void txtDN_Validated(object sender, System.EventArgs e)
		{
			try
			{
				DateTime ad1 = new DateTime(txtTN.Value.Year,txtTN.Value.Month,txtTN.Value.Day);
				DateTime ad2 = new DateTime(txtDN.Value.Year,txtDN.Value.Month,txtDN.Value.Day);
				if(ad1>ad2)
				{
					//MessageBox.Show(this,"Ngày cần thống kê không hợp lệ",m_v.s_AppName, MessageBoxButtons.OK,MessageBoxIcon.Information);
					//txtDN.Focus();
					txtTN.Value=txtDN.Value;
				}
			}
			catch
			{
			}
		}
		private string f_Get_GhiChu()
		{
			try
			{
				string r="";
				DateTime ad1 = new DateTime(txtTN.Value.Year,txtTN.Value.Month,txtTN.Value.Day);
				DateTime ad2 = new DateTime(txtDN.Value.Year,txtDN.Value.Month,txtDN.Value.Day);
				switch(cbKy.SelectedIndex.ToString())
				{
					case "0":
						if(ad1==ad2)
						{
							r=
lan.Change_language_MessageText("(Ngày")+" " + ad1.Day.ToString().PadLeft(2,'0') + "/" + ad1.Month.ToString().PadLeft(2,'0') + "/" +ad1.Year.ToString() + ")";
						}
						else
						{
							r=
lan.Change_language_MessageText("(Từ ngày")+" " + ad1.Day.ToString().PadLeft(2,'0') + "/" + ad1.Month.ToString().PadLeft(2,'0') + "/" +ad1.Year.ToString() + " "+
lan.Change_language_MessageText("đến ngày")+" " + ad2.Day.ToString().PadLeft(2,'0') + "/" + ad2.Month.ToString().PadLeft(2,'0') + "/" +ad2.Year.ToString() + ")";
						}
						break;
					case "1":
                        r =
lan.Change_language_MessageText("(Tháng") + " " + txtThang.Value.ToString().PadLeft(2, '0') + " "+
lan.Change_language_MessageText("năm")+" " + txtNam.Value.ToString() + ")";
						break;
					case "2":
                        r = lan.Change_language_MessageText("Quý")+" " + txtThang.Value.ToString().PadLeft(2, '0') + " "+lan.Change_language_MessageText("năm")+" " + txtNam.Value.ToString() + ")";
						break;
				}
				return r;
			}
			catch
			{
				return "";
			}
		}

		private void chklUserid_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			try
			{
				if(e.KeyCode==Keys.Enter)
				{
					SendKeys.Send("{Tab}");
				}
			}
			catch
			{
			}
		}

		private void chklUserid_Leave(object sender, System.EventArgs e)
		{
			try
			{
				//chklUserid.SetSelected(chklUserid.SelectedIndex,false);
				//chklUserid.SetSelected(0,false);
			}
			catch
			{
			}
		}
		private void chkUserid_CheckedChanged(object sender, System.EventArgs e)
		{
			f_Set_CheckID(tree_User,chkUserid.Checked);
		}
		private void rd_CheckedChanged(object sender, System.EventArgs e)
		{
			try
			{
				if(rd1.Checked) groupBox1.Tag="1";
				if(rd2.Checked) groupBox1.Tag="2";
				if(rd3.Checked) groupBox1.Tag="3";
				if(rd4.Checked) groupBox1.Tag="4";
				rdNoitru.Visible=(rd3.Checked || rd4.Checked);
				rdNgoaitru.Visible=(rd3.Checked || rd4.Checked);
				chkPhatsinh.Visible=(rd1.Checked || rd2.Checked);

			}
			catch
			{
			}
		}

		private void txtNguoilapphieu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			try
			{
				if(e.KeyCode==Keys.Enter)
				{
					SendKeys.Send("{Tab}");
				}
			}
			catch
			{
			}
		}

		private void txtGiamdoc_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			try
			{
				if(e.KeyCode==Keys.Enter)
				{
					SendKeys.Send("{Tab}");
				}
			}
			catch
			{
			}
		}

		private void txtKetoanvp_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			try
			{
				if(e.KeyCode==Keys.Enter)
				{
					SendKeys.Send("{Tab}");
				}
			}
			catch
			{
			}
		}

		private void txtPhongtckt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			try
			{
				if(e.KeyCode==Keys.Enter)
				{
					SendKeys.Send("{Tab}");
				}
			}
			catch
			{
			}
		}

		private void chkUserid_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			try
			{
				if(e.KeyCode==Keys.Enter)
				{
					SendKeys.Send("{Tab}");
				}
			}
			catch
			{
			}
		}

		private void chkQuyenSo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			try
			{
				if(e.KeyCode==Keys.Enter)
				{
					SendKeys.Send("{Tab}");
				}
			}
			catch
			{
			}
		}

		private void chkLoaiDV_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			try
			{
				if(e.KeyCode==Keys.Enter)
				{
					SendKeys.Send("{Tab}");
				}
			}
			catch
			{
			}
		}

		private void txtNgayIn_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			try
			{
				if(e.KeyCode==Keys.Enter)
				{
					//SendKeys.Send("{Tab}");
					butInBK.Focus();
				}
			}
			catch
			{
			}
		}

		private void butInBK_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			try
			{
				if(e.KeyCode==Keys.Enter)
				{
					SendKeys.Send("{Tab}");
				}
			}
			catch
			{
			}
		}

		private void butKetthuc_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			try
			{
				if(e.KeyCode==Keys.Enter)
				{
					SendKeys.Send("{Tab}");
				}
			}
			catch
			{
			}
		}

		private void rd1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			try
			{
				if(e.KeyCode==Keys.Enter)
				{
					SendKeys.Send("{Tab}");
				}
			}
			catch
			{
			}
		}

		private void rd2_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			try
			{
				if(e.KeyCode==Keys.Enter)
				{
					SendKeys.Send("{Tab}");
				}
			}
			catch
			{
			}
		}

		private void rd3_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			try
			{
				if(e.KeyCode==Keys.Enter)
				{
					SendKeys.Send("{Tab}");
				}
			}
			catch
			{
			}
		}

		private void rd4_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			try
			{
				if(e.KeyCode==Keys.Enter)
				{
					SendKeys.Send("{Tab}");
				}
			}
			catch
			{
			}
		}

		private void rd5_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			try
			{
				if(e.KeyCode==Keys.Enter)
				{
					SendKeys.Send("{Tab}");
				}
			}
			catch
			{
			}
		}

		private void rd6_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			try
			{
				if(e.KeyCode==Keys.Enter)
				{
					SendKeys.Send("{Tab}");
				}
			}
			catch
			{
			}
		}

		private void frmBaocaotreem_SizeChanged(object sender, System.EventArgs e)
		{
		}

		private void tree_User_AfterCheck(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			try
			{
				int anu=0,ans=0;
				string amsg="";
				e.Node.ForeColor=e.Node.Checked?Color.Navy:Color.DimGray;
				for(int i=0;i<tree_User.Nodes.Count;i++)
				{
					if(tree_User.Nodes[i].Checked)
					{
						anu++;
					}
					for(int j=0;j<tree_User.Nodes[i].Nodes.Count;j++)
					{
						if(tree_User.Nodes[i].Nodes[j].Checked)
						{
							ans++;
						}
					}
				}
                amsg = lan.Change_language_MessageText("Đã chọn:") + "\n" + lan.Change_language_MessageText("Nhân viên thu ngân:") + " " + anu.ToString() + "\n" + lan.Change_language_MessageText("Quyển sổ thu tiền:") + " " + ans.ToString();
				
				toolTip1.SetToolTip(chkUserid,amsg);
				if(anu==0 && ans==0)
				{
					chkUserid.Checked=false;
				}
			}
			catch
			{
			}

		}

		private void tree_LoaiBN_AfterCheck(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			try
			{
				e.Node.ForeColor=e.Node.Checked?Color.Navy:Color.DimGray;
				for(int i=0;i<tree_LoaiBN.Nodes.Count;i++)
				{
					if(tree_LoaiBN.Nodes[i].Checked)
					{
						return;
					}
				}
				chkLoaiBN.Checked=false;
			}
			catch
			{
			}
		}

		private void chkLoaiBN_CheckedChanged(object sender, System.EventArgs e)
		{
			f_Set_CheckID(tree_LoaiBN,chkLoaiBN.Checked);
		}

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			try
			{
				progressBar1.Value=(progressBar1.Value>=progressBar1.Maximum)?0:progressBar1.Value+1;
				progressBar1.Update();
			}
			catch
			{
			}
		}

		private void chk100_CheckedChanged(object sender, System.EventArgs e)
		{
		
		}

		private void menuItem1_Click(object sender, System.EventArgs e)
		{
			menuItem1.Checked=!menuItem1.Checked;
		}
		private void f_RevertCheck(TreeView v_tree, bool v_dao, bool v_val)
		{
			try
			{
				if(v_tree.SelectedNode.Parent!=null)
				{
					foreach(TreeNode anode in v_tree.SelectedNode.Parent.Nodes)
					{
						anode.Checked=v_dao?!anode.Checked:v_val;
					}
				}
				else
				{
					foreach(TreeNode anode in v_tree.Nodes)
					{
						anode.Checked=v_dao?!anode.Checked:v_val;
					}
				}
			}
			catch
			{
			}
		}
		private void menuItem2_Click(object sender, System.EventArgs e)
		{
			f_RevertCheck(tree_User,true,true);
		}
		private void menuItem3_Click(object sender, System.EventArgs e)
		{
			f_RevertCheck(tree_User,false,true);
		}

		private void menuItem4_Click(object sender, System.EventArgs e)
		{
			f_RevertCheck(tree_User,false,false);
		}

		private void menuItem8_Click(object sender, System.EventArgs e)
		{
			try
			{
				frmKhaibaodoituongthanhtoanravien f=new frmKhaibaodoituongthanhtoanravien(m_userid,"6");
				f.ShowDialog();
				try
				{
					m_doituongtreem=m_v.get_data("select * from v_optiondoituongtreem").Tables[0].Rows[0][0].ToString();
				}
				catch
				{
					m_doituongtreem="";
				}
			}
			catch
			{
			}
		}
		private void cbKy_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				int i=0;
				try
				{
					i=int.Parse(cbKy.SelectedIndex.ToString());
				}
				catch
				{
					i=0;
				}
				if(i<0) i=0;
				switch(i)
				{
					case 0://Tu...den
						txtThang.Enabled=false;
						txtNam.Enabled=false;
						txtTN.Enabled=true;
						txtDN.Enabled=true;
						break;
					case 1://Thang
						txtThang.Minimum=1;
						txtThang.Maximum=12;
						txtThang.Enabled=true;
						txtNam.Enabled=true;
						txtTN.Enabled=false;
						txtDN.Enabled=false;
						break;
					case 2://Quy
						txtThang.Minimum=1;
						txtThang.Maximum=4;
						txtThang.Enabled=true;
						txtNam.Enabled=true;
						txtTN.Enabled=false;
						txtDN.Enabled=false;
						break;
				}

			}
			catch
			{
			}
			txtThang_ValueChanged(null,null);
		}

		private void txtThang_ValueChanged(object sender, System.EventArgs e)
		{
			try
			{
				if(cbKy.SelectedIndex==1)
				{
					txtTN.Value = new DateTime(int.Parse(txtNam.Value.ToString()),int.Parse(txtThang.Value.ToString()),1);
					txtDN.Value = new DateTime(int.Parse(txtNam.Value.ToString()),int.Parse(txtThang.Value.ToString()),DateTime.DaysInMonth(int.Parse(txtNam.Value.ToString()),int.Parse(txtThang.Value.ToString())));
				}
				else
					if(cbKy.SelectedIndex==2)
				{
					switch(txtThang.Value.ToString())
					{
						case "1":
							txtTN.Value = new DateTime(int.Parse(txtNam.Value.ToString()),1,1);
							txtDN.Value = new DateTime(int.Parse(txtNam.Value.ToString()),3,DateTime.DaysInMonth(int.Parse(txtNam.Value.ToString()),3));
							break;
						case "2":
							txtTN.Value = new DateTime(int.Parse(txtNam.Value.ToString()),4,1);
							txtDN.Value = new DateTime(int.Parse(txtNam.Value.ToString()),6,DateTime.DaysInMonth(int.Parse(txtNam.Value.ToString()),6));
							break;
						case "3":
							txtTN.Value = new DateTime(int.Parse(txtNam.Value.ToString()),7,1);
							txtDN.Value = new DateTime(int.Parse(txtNam.Value.ToString()),9,DateTime.DaysInMonth(int.Parse(txtNam.Value.ToString()),9));
							break;
						case "4":
							txtTN.Value = new DateTime(int.Parse(txtNam.Value.ToString()),10,1);
							txtDN.Value = new DateTime(int.Parse(txtNam.Value.ToString()),12,DateTime.DaysInMonth(int.Parse(txtNam.Value.ToString()),12));
							break;
					}
				}
			}
			catch
			{
			}
		}

		private void cbKy_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			try
			{
				if(e.KeyCode==Keys.Enter)
				{
					if(cbKy.SelectedIndex==0)
					{
						txtTN.Focus();
					}
					else
					{
						txtThang.Focus();
					}
				}
			}
			catch
			{
			}
		}

		private void txtThang_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			try
			{
				if(e.KeyCode==Keys.Enter)
				{
					txtNam.Focus();
				}
			}
			catch
			{
			}
		}

		private void txtNam_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			try
			{
				if(e.KeyCode==Keys.Enter)
				{
					butInBK.Focus();
				}
			}
			catch
			{
			}
		}

		private void timso_TextChanged(object sender, System.EventArgs e)
		{
			if(m_v.sys_dungchungso)
			{
				f_Load_tree_Quyenso();
			}
			else
			{
				f_Load_Tree_Userid();
			}
		}

        private void txtTN_ValueChanged(object sender, EventArgs e)
        {

        }
	}
}
