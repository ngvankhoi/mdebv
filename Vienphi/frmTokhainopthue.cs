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
	/// Summary description for frmTokhainopthue.
	/// </summary>
	public class frmTokhainopthue : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private string m_userid="";
		private LibVP.AccessData m_v = new LibVP.AccessData();		

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label lbTitle;
		private System.Windows.Forms.Label lbNgayDN;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label lbNguoiDN;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.DateTimePicker txtTN;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.NumericUpDown txtThang;
		private System.Windows.Forms.NumericUpDown txtNam;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.RadioButton rdThang;
		private System.Windows.Forms.RadioButton rdNgay;
		private System.Windows.Forms.Button butKetthuc;
		private System.Windows.Forms.Button butInchiphi;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox txtTongthu;
		private System.Windows.Forms.DateTimePicker txtDN;
		private System.Windows.Forms.TextBox txtNo;
		private System.Windows.Forms.TextBox txtSotienBYT;
		private System.Windows.Forms.TextBox txtSotienBV;
		private System.Windows.Forms.TextBox txtNop;
		private System.Windows.Forms.TextBox txtTyleBYT;
		private System.Windows.Forms.TextBox txtTyleBV;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.DateTimePicker txtNgayin;
		private System.Windows.Forms.RadioButton rd1;
		private System.Windows.Forms.TextBox txtNguoilapbang;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox txtKetoantruong;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox txtGiamdoc;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.TextBox txtGuikem;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.RadioButton rd2;
		private System.Windows.Forms.RadioButton rd3;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.TextBox txtCucthue;
		private System.Windows.Forms.TextBox txtMau;
		private System.Windows.Forms.TextBox txtSo;
		private System.Windows.Forms.TreeView tree_User;
		private System.Windows.Forms.CheckBox chkUserid;
		private System.Windows.Forms.GroupBox gbChungtu;
		private System.Windows.Forms.CheckBox chkNoitru;
		private System.Windows.Forms.CheckBox chkTructiep;
		private System.Windows.Forms.TreeView tree_Doituong;
		private System.Windows.Forms.CheckBox chkDoituong;
		private System.Windows.Forms.NumericUpDown txtLock;
		private System.Windows.Forms.ProgressBar progressBar1;
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
		private System.Windows.Forms.RadioButton rd4;
		private System.Windows.Forms.TextBox txtTonghoan;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.TextBox txtLamtron;
		private System.Windows.Forms.Label lbLamtron;
		private System.Windows.Forms.TextBox timso;
		private System.Windows.Forms.TreeView tree_Quyenso;
		private System.Windows.Forms.MenuItem menuItem7;
        private Button butBoyte;
		private System.ComponentModel.IContainer components;

		public frmTokhainopthue(string v_userid)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTokhainopthue));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbTitle = new System.Windows.Forms.Label();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.lbNgayDN = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbNguoiDN = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tree_Quyenso = new System.Windows.Forms.TreeView();
            this.timso = new System.Windows.Forms.TextBox();
            this.txtLamtron = new System.Windows.Forms.TextBox();
            this.lbLamtron = new System.Windows.Forms.Label();
            this.txtTonghoan = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.tree_Doituong = new System.Windows.Forms.TreeView();
            this.chkDoituong = new System.Windows.Forms.CheckBox();
            this.tree_User = new System.Windows.Forms.TreeView();
            this.contextMenu2 = new System.Windows.Forms.ContextMenu();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.chkUserid = new System.Windows.Forms.CheckBox();
            this.txtSo = new System.Windows.Forms.TextBox();
            this.txtMau = new System.Windows.Forms.TextBox();
            this.txtCucthue = new System.Windows.Forms.TextBox();
            this.txtGuikem = new System.Windows.Forms.TextBox();
            this.txtGiamdoc = new System.Windows.Forms.TextBox();
            this.txtKetoantruong = new System.Windows.Forms.TextBox();
            this.txtNguoilapbang = new System.Windows.Forms.TextBox();
            this.txtTyleBV = new System.Windows.Forms.TextBox();
            this.txtTyleBYT = new System.Windows.Forms.TextBox();
            this.txtNop = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSotienBV = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSotienBYT = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rd4 = new System.Windows.Forms.RadioButton();
            this.txtLock = new System.Windows.Forms.NumericUpDown();
            this.rd2 = new System.Windows.Forms.RadioButton();
            this.rd1 = new System.Windows.Forms.RadioButton();
            this.rd3 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtNgayin = new System.Windows.Forms.DateTimePicker();
            this.txtDN = new System.Windows.Forms.DateTimePicker();
            this.txtTN = new System.Windows.Forms.DateTimePicker();
            this.rdNgay = new System.Windows.Forms.RadioButton();
            this.rdThang = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtThang = new System.Windows.Forms.NumericUpDown();
            this.txtNam = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.butBoyte = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.butInchiphi = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.txtTongthu = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.gbChungtu = new System.Windows.Forms.GroupBox();
            this.chkNoitru = new System.Windows.Forms.CheckBox();
            this.chkTructiep = new System.Windows.Forms.CheckBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLock)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtThang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNam)).BeginInit();
            this.panel3.SuspendLayout();
            this.gbChungtu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.ForestGreen;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lbTitle);
            this.panel1.Controls.Add(this.lbNgayDN);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.lbNguoiDN);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(1);
            this.panel1.Size = new System.Drawing.Size(792, 49);
            this.panel1.TabIndex = 16;
            // 
            // lbTitle
            // 
            this.lbTitle.BackColor = System.Drawing.Color.ForestGreen;
            this.lbTitle.ContextMenu = this.contextMenu1;
            this.lbTitle.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbTitle.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.Color.White;
            this.lbTitle.Location = new System.Drawing.Point(71, 1);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(249, 45);
            this.lbTitle.TabIndex = 15;
            this.lbTitle.Text = "  BÁO CÁO THUẾ";
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // contextMenu1
            // 
            this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItem7});
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
            this.menuItem7.Text = "Làm tròn số";
            this.menuItem7.Click += new System.EventHandler(this.menuItem7_Click);
            // 
            // lbNgayDN
            // 
            this.lbNgayDN.ForeColor = System.Drawing.Color.White;
            this.lbNgayDN.Location = new System.Drawing.Point(536, 26);
            this.lbNgayDN.Name = "lbNgayDN";
            this.lbNgayDN.Size = new System.Drawing.Size(248, 13);
            this.lbNgayDN.TabIndex = 0;
            this.lbNgayDN.Text = "Ngày làm việc";
            this.lbNgayDN.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            // lbNguoiDN
            // 
            this.lbNguoiDN.BackColor = System.Drawing.Color.ForestGreen;
            this.lbNguoiDN.ForeColor = System.Drawing.Color.White;
            this.lbNguoiDN.Location = new System.Drawing.Point(534, 8);
            this.lbNguoiDN.Name = "lbNguoiDN";
            this.lbNguoiDN.Size = new System.Drawing.Size(248, 13);
            this.lbNguoiDN.TabIndex = 66;
            this.lbNguoiDN.Text = "Người đăng nhập";
            this.lbNguoiDN.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label15
            // 
            this.label15.Dock = System.Windows.Forms.DockStyle.Top;
            this.label15.Location = new System.Drawing.Point(3, 52);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(792, 3);
            this.label15.TabIndex = 18;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.tree_Quyenso);
            this.panel2.Controls.Add(this.timso);
            this.panel2.Controls.Add(this.txtLamtron);
            this.panel2.Controls.Add(this.lbLamtron);
            this.panel2.Controls.Add(this.txtTonghoan);
            this.panel2.Controls.Add(this.label19);
            this.panel2.Controls.Add(this.tree_Doituong);
            this.panel2.Controls.Add(this.chkDoituong);
            this.panel2.Controls.Add(this.tree_User);
            this.panel2.Controls.Add(this.chkUserid);
            this.panel2.Controls.Add(this.txtSo);
            this.panel2.Controls.Add(this.txtMau);
            this.panel2.Controls.Add(this.txtCucthue);
            this.panel2.Controls.Add(this.txtGuikem);
            this.panel2.Controls.Add(this.txtGiamdoc);
            this.panel2.Controls.Add(this.txtKetoantruong);
            this.panel2.Controls.Add(this.txtNguoilapbang);
            this.panel2.Controls.Add(this.txtTyleBV);
            this.panel2.Controls.Add(this.txtTyleBYT);
            this.panel2.Controls.Add(this.txtNop);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txtSotienBV);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txtSotienBYT);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtNo);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.txtTongthu);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label18);
            this.panel2.Controls.Add(this.label17);
            this.panel2.Controls.Add(this.label16);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.gbChungtu);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.ForeColor = System.Drawing.Color.Navy;
            this.panel2.Location = new System.Drawing.Point(3, 55);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(5);
            this.panel2.Size = new System.Drawing.Size(792, 456);
            this.panel2.TabIndex = 19;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // tree_Quyenso
            // 
            this.tree_Quyenso.CheckBoxes = true;
            this.tree_Quyenso.ForeColor = System.Drawing.Color.DimGray;
            this.tree_Quyenso.FullRowSelect = true;
            this.tree_Quyenso.Location = new System.Drawing.Point(171, 21);
            this.tree_Quyenso.Name = "tree_Quyenso";
            this.tree_Quyenso.ShowLines = false;
            this.tree_Quyenso.ShowPlusMinus = false;
            this.tree_Quyenso.ShowRootLines = false;
            this.tree_Quyenso.Size = new System.Drawing.Size(124, 200);
            this.tree_Quyenso.Sorted = true;
            this.tree_Quyenso.TabIndex = 208;
            // 
            // timso
            // 
            this.timso.BackColor = System.Drawing.Color.White;
            this.timso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timso.Location = new System.Drawing.Point(5, 222);
            this.timso.MaxLength = 12;
            this.timso.Name = "timso";
            this.timso.Size = new System.Drawing.Size(290, 21);
            this.timso.TabIndex = 207;
            this.timso.Text = "Tìm sổ";
            this.timso.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.timso.TextChanged += new System.EventHandler(this.timso_TextChanged);
            // 
            // txtLamtron
            // 
            this.txtLamtron.BackColor = System.Drawing.Color.White;
            this.txtLamtron.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLamtron.Location = new System.Drawing.Point(453, 227);
            this.txtLamtron.MaxLength = 30;
            this.txtLamtron.Name = "txtLamtron";
            this.txtLamtron.Size = new System.Drawing.Size(156, 21);
            this.txtLamtron.TabIndex = 194;
            this.txtLamtron.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtLamtron.Visible = false;
            this.txtLamtron.Validated += new System.EventHandler(this.txtLamtron_Validated);
            // 
            // lbLamtron
            // 
            this.lbLamtron.ForeColor = System.Drawing.Color.Blue;
            this.lbLamtron.Location = new System.Drawing.Point(293, 231);
            this.lbLamtron.Name = "lbLamtron";
            this.lbLamtron.Size = new System.Drawing.Size(160, 13);
            this.lbLamtron.TabIndex = 195;
            this.lbLamtron.Text = "Số tiền chênh lệch";
            this.lbLamtron.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbLamtron.Visible = false;
            // 
            // txtTonghoan
            // 
            this.txtTonghoan.BackColor = System.Drawing.Color.White;
            this.txtTonghoan.Enabled = false;
            this.txtTonghoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTonghoan.Location = new System.Drawing.Point(453, 117);
            this.txtTonghoan.MaxLength = 12;
            this.txtTonghoan.Name = "txtTonghoan";
            this.txtTonghoan.Size = new System.Drawing.Size(156, 21);
            this.txtTonghoan.TabIndex = 192;
            this.txtTonghoan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(303, 121);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(150, 13);
            this.label19.TabIndex = 193;
            this.label19.Text = "Số tiền hoàn trong kỳ này";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tree_Doituong
            // 
            this.tree_Doituong.CheckBoxes = true;
            this.tree_Doituong.ForeColor = System.Drawing.Color.DimGray;
            this.tree_Doituong.FullRowSelect = true;
            this.tree_Doituong.Location = new System.Drawing.Point(5, 264);
            this.tree_Doituong.Name = "tree_Doituong";
            this.tree_Doituong.ShowLines = false;
            this.tree_Doituong.ShowPlusMinus = false;
            this.tree_Doituong.ShowRootLines = false;
            this.tree_Doituong.Size = new System.Drawing.Size(290, 69);
            this.tree_Doituong.Sorted = true;
            this.tree_Doituong.TabIndex = 5;
            this.tree_Doituong.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tree_Doituong_AfterCheck);
            // 
            // chkDoituong
            // 
            this.chkDoituong.Location = new System.Drawing.Point(5, 248);
            this.chkDoituong.Name = "chkDoituong";
            this.chkDoituong.Size = new System.Drawing.Size(104, 17);
            this.chkDoituong.TabIndex = 4;
            this.chkDoituong.TabStop = false;
            this.chkDoituong.Text = "Đối tượng";
            this.chkDoituong.CheckedChanged += new System.EventHandler(this.chkDoituong_CheckedChanged);
            // 
            // tree_User
            // 
            this.tree_User.CheckBoxes = true;
            this.tree_User.ContextMenu = this.contextMenu2;
            this.tree_User.ForeColor = System.Drawing.Color.DimGray;
            this.tree_User.FullRowSelect = true;
            this.tree_User.Location = new System.Drawing.Point(5, 21);
            this.tree_User.Name = "tree_User";
            this.tree_User.ShowLines = false;
            this.tree_User.ShowPlusMinus = false;
            this.tree_User.ShowRootLines = false;
            this.tree_User.Size = new System.Drawing.Size(290, 200);
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
            // chkUserid
            // 
            this.chkUserid.Location = new System.Drawing.Point(5, 3);
            this.chkUserid.Name = "chkUserid";
            this.chkUserid.Size = new System.Drawing.Size(268, 21);
            this.chkUserid.TabIndex = 0;
            this.chkUserid.TabStop = false;
            this.chkUserid.Text = "Nhân viên thu ngân (Quyển sổ)";
            this.chkUserid.CheckedChanged += new System.EventHandler(this.chkUserid_CheckedChanged);
            // 
            // txtSo
            // 
            this.txtSo.BackColor = System.Drawing.Color.White;
            this.txtSo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSo.Location = new System.Drawing.Point(625, 308);
            this.txtSo.MaxLength = 1000;
            this.txtSo.Name = "txtSo";
            this.txtSo.Size = new System.Drawing.Size(159, 21);
            this.txtSo.TabIndex = 17;
            this.txtSo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSo_KeyDown);
            // 
            // txtMau
            // 
            this.txtMau.BackColor = System.Drawing.Color.White;
            this.txtMau.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMau.Location = new System.Drawing.Point(625, 286);
            this.txtMau.MaxLength = 1000;
            this.txtMau.Name = "txtMau";
            this.txtMau.Size = new System.Drawing.Size(159, 21);
            this.txtMau.TabIndex = 16;
            this.txtMau.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMau_KeyDown);
            // 
            // txtCucthue
            // 
            this.txtCucthue.BackColor = System.Drawing.Color.White;
            this.txtCucthue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCucthue.Location = new System.Drawing.Point(625, 264);
            this.txtCucthue.MaxLength = 1000;
            this.txtCucthue.Name = "txtCucthue";
            this.txtCucthue.Size = new System.Drawing.Size(159, 21);
            this.txtCucthue.TabIndex = 15;
            this.txtCucthue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCucthue_KeyDown);
            // 
            // txtGuikem
            // 
            this.txtGuikem.BackColor = System.Drawing.Color.White;
            this.txtGuikem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGuikem.Location = new System.Drawing.Point(297, 264);
            this.txtGuikem.Multiline = true;
            this.txtGuikem.Name = "txtGuikem";
            this.txtGuikem.Size = new System.Drawing.Size(244, 134);
            this.txtGuikem.TabIndex = 14;
            // 
            // txtGiamdoc
            // 
            this.txtGiamdoc.BackColor = System.Drawing.Color.White;
            this.txtGiamdoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGiamdoc.Location = new System.Drawing.Point(625, 374);
            this.txtGiamdoc.MaxLength = 1000;
            this.txtGiamdoc.Name = "txtGiamdoc";
            this.txtGiamdoc.Size = new System.Drawing.Size(159, 21);
            this.txtGiamdoc.TabIndex = 20;
            // 
            // txtKetoantruong
            // 
            this.txtKetoantruong.BackColor = System.Drawing.Color.White;
            this.txtKetoantruong.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKetoantruong.Location = new System.Drawing.Point(625, 352);
            this.txtKetoantruong.MaxLength = 1000;
            this.txtKetoantruong.Name = "txtKetoantruong";
            this.txtKetoantruong.Size = new System.Drawing.Size(159, 21);
            this.txtKetoantruong.TabIndex = 19;
            // 
            // txtNguoilapbang
            // 
            this.txtNguoilapbang.BackColor = System.Drawing.Color.White;
            this.txtNguoilapbang.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNguoilapbang.Location = new System.Drawing.Point(625, 330);
            this.txtNguoilapbang.MaxLength = 1000;
            this.txtNguoilapbang.Name = "txtNguoilapbang";
            this.txtNguoilapbang.Size = new System.Drawing.Size(159, 21);
            this.txtNguoilapbang.TabIndex = 18;
            // 
            // txtTyleBV
            // 
            this.txtTyleBV.BackColor = System.Drawing.Color.White;
            this.txtTyleBV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTyleBV.Location = new System.Drawing.Point(453, 183);
            this.txtTyleBV.MaxLength = 3;
            this.txtTyleBV.Name = "txtTyleBV";
            this.txtTyleBV.Size = new System.Drawing.Size(30, 21);
            this.txtTyleBV.TabIndex = 11;
            this.txtTyleBV.Tag = "26";
            this.txtTyleBV.Text = "26";
            this.txtTyleBV.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTyleBV.Validated += new System.EventHandler(this.txtTyleBV_Validated);
            this.txtTyleBV.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTyleBV_KeyDown);
            // 
            // txtTyleBYT
            // 
            this.txtTyleBYT.BackColor = System.Drawing.Color.White;
            this.txtTyleBYT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTyleBYT.Location = new System.Drawing.Point(453, 161);
            this.txtTyleBYT.MaxLength = 3;
            this.txtTyleBYT.Name = "txtTyleBYT";
            this.txtTyleBYT.Size = new System.Drawing.Size(30, 21);
            this.txtTyleBYT.TabIndex = 9;
            this.txtTyleBYT.Tag = "4";
            this.txtTyleBYT.Text = "4";
            this.txtTyleBYT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTyleBYT.Validated += new System.EventHandler(this.txtTyleBYT_Validated);
            this.txtTyleBYT.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTyleBYT_KeyDown);
            // 
            // txtNop
            // 
            this.txtNop.BackColor = System.Drawing.Color.White;
            this.txtNop.Enabled = false;
            this.txtNop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNop.Location = new System.Drawing.Point(453, 205);
            this.txtNop.MaxLength = 30;
            this.txtNop.Name = "txtNop";
            this.txtNop.Size = new System.Drawing.Size(156, 21);
            this.txtNop.TabIndex = 13;
            this.txtNop.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNop.Validated += new System.EventHandler(this.txtNop_Validated);
            this.txtNop.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNop_KeyDown);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(293, 209);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(160, 13);
            this.label6.TabIndex = 164;
            this.label6.Text = "Số tiền nộp ngân sách kỳ này";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSotienBV
            // 
            this.txtSotienBV.BackColor = System.Drawing.Color.White;
            this.txtSotienBV.Enabled = false;
            this.txtSotienBV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSotienBV.Location = new System.Drawing.Point(498, 183);
            this.txtSotienBV.MaxLength = 30;
            this.txtSotienBV.Name = "txtSotienBV";
            this.txtSotienBV.Size = new System.Drawing.Size(111, 21);
            this.txtSotienBV.TabIndex = 12;
            this.txtSotienBV.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSotienBV.Validated += new System.EventHandler(this.txtSotienBV_Validated);
            this.txtSotienBV.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSotienBV_KeyDown);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(301, 187);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(150, 13);
            this.label5.TabIndex = 162;
            this.label5.Text = "Trích sử dụng Bệnh viện";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSotienBYT
            // 
            this.txtSotienBYT.BackColor = System.Drawing.Color.White;
            this.txtSotienBYT.Enabled = false;
            this.txtSotienBYT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSotienBYT.Location = new System.Drawing.Point(498, 161);
            this.txtSotienBYT.MaxLength = 30;
            this.txtSotienBYT.Name = "txtSotienBYT";
            this.txtSotienBYT.Size = new System.Drawing.Size(111, 21);
            this.txtSotienBYT.TabIndex = 10;
            this.txtSotienBYT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSotienBYT.Validated += new System.EventHandler(this.txtSotienBYT_Validated);
            this.txtSotienBYT.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSotienBYT_KeyDown);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(300, 165);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 13);
            this.label4.TabIndex = 160;
            this.label4.Text = "Trích sử dụng Bộ y tế";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNo
            // 
            this.txtNo.BackColor = System.Drawing.Color.White;
            this.txtNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNo.Location = new System.Drawing.Point(453, 139);
            this.txtNo.MaxLength = 12;
            this.txtNo.Name = "txtNo";
            this.txtNo.Size = new System.Drawing.Size(156, 21);
            this.txtNo.TabIndex = 8;
            this.txtNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNo.Validated += new System.EventHandler(this.txtNo_Validated);
            this.txtNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNo_KeyDown);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(302, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 13);
            this.label3.TabIndex = 158;
            this.label3.Text = "Số tiền nợ của kỳ trước";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rd4);
            this.groupBox2.Controls.Add(this.txtLock);
            this.groupBox2.Controls.Add(this.rd2);
            this.groupBox2.Controls.Add(this.rd1);
            this.groupBox2.Controls.Add(this.rd3);
            this.groupBox2.Location = new System.Drawing.Point(611, 90);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(173, 136);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Tag = "1";
            this.groupBox2.Text = "Loại báo cáo";
            // 
            // rd4
            // 
            this.rd4.Location = new System.Drawing.Point(12, 80);
            this.rd4.Name = "rd4";
            this.rd4.Size = new System.Drawing.Size(156, 20);
            this.rd4.TabIndex = 4;
            this.rd4.Tag = "4";
            this.rd4.Text = "Bảng kê biên lai hoàn trả";
            this.rd4.CheckedChanged += new System.EventHandler(this.rd_CheckedChanged);
            // 
            // txtLock
            // 
            this.txtLock.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLock.Location = new System.Drawing.Point(107, 40);
            this.txtLock.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.txtLock.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtLock.Name = "txtLock";
            this.txtLock.Size = new System.Drawing.Size(51, 21);
            this.txtLock.TabIndex = 3;
            this.txtLock.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtLock.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // rd2
            // 
            this.rd2.Location = new System.Drawing.Point(12, 40);
            this.rd2.Name = "rd2";
            this.rd2.Size = new System.Drawing.Size(100, 20);
            this.rd2.TabIndex = 1;
            this.rd2.Tag = "2";
            this.rd2.Text = "Tờ khai chi tiết";
            this.rd2.CheckedChanged += new System.EventHandler(this.rd_CheckedChanged);
            // 
            // rd1
            // 
            this.rd1.Checked = true;
            this.rd1.Location = new System.Drawing.Point(12, 20);
            this.rd1.Name = "rd1";
            this.rd1.Size = new System.Drawing.Size(122, 20);
            this.rd1.TabIndex = 0;
            this.rd1.TabStop = true;
            this.rd1.Tag = "1";
            this.rd1.Text = "Tờ khai nộp thuế";
            this.rd1.CheckedChanged += new System.EventHandler(this.rd_CheckedChanged);
            this.rd1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rd1_KeyDown);
            // 
            // rd3
            // 
            this.rd3.Location = new System.Drawing.Point(12, 60);
            this.rd3.Name = "rd3";
            this.rd3.Size = new System.Drawing.Size(122, 20);
            this.rd3.TabIndex = 2;
            this.rd3.Tag = "3";
            this.rd3.Text = "Bảng kê chứng từ";
            this.rd3.CheckedChanged += new System.EventHandler(this.rd_CheckedChanged);
            this.rd3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rd2_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtNgayin);
            this.groupBox1.Controls.Add(this.txtDN);
            this.groupBox1.Controls.Add(this.txtTN);
            this.groupBox1.Controls.Add(this.rdNgay);
            this.groupBox1.Controls.Add(this.rdThang);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtThang);
            this.groupBox1.Controls.Add(this.txtNam);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Location = new System.Drawing.Point(298, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(486, 71);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thời gian báo cáo";
            // 
            // txtNgayin
            // 
            this.txtNgayin.CustomFormat = "dd/MM/yyyy hh:mm";
            this.txtNgayin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtNgayin.Location = new System.Drawing.Point(379, 41);
            this.txtNgayin.Name = "txtNgayin";
            this.txtNgayin.Size = new System.Drawing.Size(83, 20);
            this.txtNgayin.TabIndex = 4;
            this.txtNgayin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNgayin_KeyDown);
            // 
            // txtDN
            // 
            this.txtDN.CustomFormat = "dd/MM/yyyy hh:mm";
            this.txtDN.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtDN.Location = new System.Drawing.Point(210, 41);
            this.txtDN.Name = "txtDN";
            this.txtDN.Size = new System.Drawing.Size(85, 20);
            this.txtDN.TabIndex = 3;
            this.txtDN.ValueChanged += new System.EventHandler(this.txtDN_ValueChanged);
            this.txtDN.Validated += new System.EventHandler(this.txtDN_Validated);
            this.txtDN.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDN_KeyDown);
            // 
            // txtTN
            // 
            this.txtTN.CustomFormat = "dd/MM/yyyy hh:mm";
            this.txtTN.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtTN.Location = new System.Drawing.Point(72, 41);
            this.txtTN.Name = "txtTN";
            this.txtTN.Size = new System.Drawing.Size(85, 20);
            this.txtTN.TabIndex = 2;
            this.txtTN.ValueChanged += new System.EventHandler(this.txtTN_ValueChanged);
            this.txtTN.Validated += new System.EventHandler(this.txtTN_Validated);
            this.txtTN.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTN_KeyDown);
            // 
            // rdNgay
            // 
            this.rdNgay.Location = new System.Drawing.Point(8, 41);
            this.rdNgay.Name = "rdNgay";
            this.rdNgay.Size = new System.Drawing.Size(64, 20);
            this.rdNgay.TabIndex = 3;
            this.rdNgay.Text = "Từ ngày";
            this.rdNgay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rdNgay_KeyDown);
            // 
            // rdThang
            // 
            this.rdThang.Checked = true;
            this.rdThang.Location = new System.Drawing.Point(8, 20);
            this.rdThang.Name = "rdThang";
            this.rdThang.Size = new System.Drawing.Size(64, 16);
            this.rdThang.TabIndex = 0;
            this.rdThang.TabStop = true;
            this.rdThang.Text = "Tháng";
            this.rdThang.CheckedChanged += new System.EventHandler(this.rdThang_CheckedChanged);
            this.rdThang.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rdThang_KeyDown);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(182, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Năm";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(157, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 154;
            this.label2.Text = "Đến ngày";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtThang
            // 
            this.txtThang.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtThang.Location = new System.Drawing.Point(72, 18);
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
            this.txtThang.Size = new System.Drawing.Size(48, 21);
            this.txtThang.TabIndex = 0;
            this.txtThang.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtThang.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtThang.ValueChanged += new System.EventHandler(this.txtThang_ValueChanged);
            this.txtThang.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtThang_KeyDown);
            // 
            // txtNam
            // 
            this.txtNam.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNam.Location = new System.Drawing.Point(210, 18);
            this.txtNam.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.txtNam.Minimum = new decimal(new int[] {
            1900,
            0,
            0,
            0});
            this.txtNam.Name = "txtNam";
            this.txtNam.Size = new System.Drawing.Size(64, 21);
            this.txtNam.TabIndex = 1;
            this.txtNam.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNam.Value = new decimal(new int[] {
            1980,
            0,
            0,
            0});
            this.txtNam.ValueChanged += new System.EventHandler(this.txtNam_ValueChanged);
            this.txtNam.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNam_KeyDown);
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(298, 45);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(80, 13);
            this.label12.TabIndex = 174;
            this.label12.Text = "Ngày lập bảng";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Controls.Add(this.butBoyte);
            this.panel3.Controls.Add(this.progressBar1);
            this.panel3.Controls.Add(this.butInchiphi);
            this.panel3.Controls.Add(this.butKetthuc);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(5, 410);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(3);
            this.panel3.Size = new System.Drawing.Size(778, 37);
            this.panel3.TabIndex = 148;
            // 
            // butBoyte
            // 
            this.butBoyte.BackColor = System.Drawing.SystemColors.Control;
            this.butBoyte.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butBoyte.Dock = System.Windows.Forms.DockStyle.Right;
            this.butBoyte.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butBoyte.ForeColor = System.Drawing.Color.Navy;
            this.butBoyte.Image = ((System.Drawing.Image)(resources.GetObject("butBoyte.Image")));
            this.butBoyte.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoyte.Location = new System.Drawing.Point(448, 3);
            this.butBoyte.Name = "butBoyte";
            this.butBoyte.Size = new System.Drawing.Size(135, 31);
            this.butBoyte.TabIndex = 3;
            this.butBoyte.Text = "     Báo cáo Bộ Y Tế";
            this.butBoyte.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoyte.UseMnemonic = false;
            this.butBoyte.UseVisualStyleBackColor = true;
            this.butBoyte.Click += new System.EventHandler(this.butBoyte_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(6, 8);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(440, 23);
            this.progressBar1.TabIndex = 2;
            // 
            // butInchiphi
            // 
            this.butInchiphi.BackColor = System.Drawing.SystemColors.Control;
            this.butInchiphi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butInchiphi.Dock = System.Windows.Forms.DockStyle.Right;
            this.butInchiphi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butInchiphi.ForeColor = System.Drawing.Color.Navy;
            this.butInchiphi.Image = ((System.Drawing.Image)(resources.GetObject("butInchiphi.Image")));
            this.butInchiphi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butInchiphi.Location = new System.Drawing.Point(583, 3);
            this.butInchiphi.Name = "butInchiphi";
            this.butInchiphi.Size = new System.Drawing.Size(104, 31);
            this.butInchiphi.TabIndex = 0;
            this.butInchiphi.Text = "     In báo cáo";
            this.butInchiphi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butInchiphi.UseVisualStyleBackColor = true;
            this.butInchiphi.Click += new System.EventHandler(this.butInchiphi_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.BackColor = System.Drawing.SystemColors.Control;
            this.butKetthuc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butKetthuc.Dock = System.Windows.Forms.DockStyle.Right;
            this.butKetthuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butKetthuc.ForeColor = System.Drawing.Color.Navy;
            this.butKetthuc.Image = global::Vienphi.Properties.Resources.close_r;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(687, 3);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(88, 31);
            this.butKetthuc.TabIndex = 1;
            this.butKetthuc.Text = "     Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.UseVisualStyleBackColor = true;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // txtTongthu
            // 
            this.txtTongthu.BackColor = System.Drawing.Color.White;
            this.txtTongthu.Enabled = false;
            this.txtTongthu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongthu.Location = new System.Drawing.Point(453, 95);
            this.txtTongthu.MaxLength = 30;
            this.txtTongthu.Name = "txtTongthu";
            this.txtTongthu.Size = new System.Drawing.Size(156, 21);
            this.txtTongthu.TabIndex = 7;
            this.txtTongthu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTongthu.Validated += new System.EventHandler(this.txtTongthu_Validated);
            this.txtTongthu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTongthu_KeyDown);
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(297, 99);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(158, 13);
            this.label10.TabIndex = 147;
            this.label10.Text = "Tổng số tiền thu trong kỳ này";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(536, 308);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(89, 21);
            this.label18.TabIndex = 191;
            this.label18.Text = "Số báo cáo";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(536, 286);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(89, 21);
            this.label17.TabIndex = 189;
            this.label17.Text = "Mẫu báo cáo";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(535, 264);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(89, 21);
            this.label16.TabIndex = 187;
            this.label16.Text = "Cục thuế";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(536, 374);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(89, 21);
            this.label13.TabIndex = 183;
            this.label13.Text = "Giám đốc";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(536, 352);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 21);
            this.label11.TabIndex = 181;
            this.label11.Text = "Kế toán trưởng";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(536, 330);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 21);
            this.label9.TabIndex = 179;
            this.label9.Text = "Người lập bảng";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(485, 165);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(14, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "%";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(485, 187);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(14, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "%";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(295, 250);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(120, 13);
            this.label14.TabIndex = 185;
            this.label14.Text = "Gửi kèm";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gbChungtu
            // 
            this.gbChungtu.Controls.Add(this.chkNoitru);
            this.gbChungtu.Controls.Add(this.chkTructiep);
            this.gbChungtu.Location = new System.Drawing.Point(5, 334);
            this.gbChungtu.Name = "gbChungtu";
            this.gbChungtu.Size = new System.Drawing.Size(289, 64);
            this.gbChungtu.TabIndex = 6;
            this.gbChungtu.TabStop = false;
            this.gbChungtu.Text = "Chứng từ";
            // 
            // chkNoitru
            // 
            this.chkNoitru.Location = new System.Drawing.Point(10, 39);
            this.chkNoitru.Name = "chkNoitru";
            this.chkNoitru.Size = new System.Drawing.Size(118, 18);
            this.chkNoitru.TabIndex = 1;
            this.chkNoitru.TabStop = false;
            this.chkNoitru.Text = "Thanh toán ra viện";
            // 
            // chkTructiep
            // 
            this.chkTructiep.Location = new System.Drawing.Point(10, 19);
            this.chkTructiep.Name = "chkTructiep";
            this.chkTructiep.Size = new System.Drawing.Size(88, 19);
            this.chkTructiep.TabIndex = 0;
            this.chkTructiep.TabStop = false;
            this.chkTructiep.Text = "Thu trực tiếp";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmTokhainopthue
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(798, 514);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(806, 541);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(806, 541);
            this.Name = "frmTokhainopthue";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo cáo thuế";
            this.Load += new System.EventHandler(this.frmTokhainopthue_Load);
            this.SizeChanged += new System.EventHandler(this.frmTokhainopthue_SizeChanged);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmTokhainopthue_Closing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmTokhainopthue_KeyDown);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtLock)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtThang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNam)).EndInit();
            this.panel3.ResumeLayout(false);
            this.gbChungtu.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void frmTokhainopthue_Load(object sender, System.EventArgs e)
		{
			try
			{
				f_Prepare();
				f_Display_User();
				f_LoadHistory();
				f_Load_Tree_Userid();
				f_Load_Tree_Doituong();
				txtThang.Value=DateTime.Now.Month;
				txtNam.Value=DateTime.Now.Year;
				txtThang_ValueChanged(null,null);
				rd_CheckedChanged(null,null);
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
						if(anoder.Nodes.Count>0)
						{
							v_tree.Nodes.Add(anoder);
						}
						anoder = new TreeNode(r["tenr"].ToString());
						anoder.Tag = r["mar"].ToString();
					}
					if(r["ma"].ToString().Trim()!="")
					{
						anode = new TreeNode(r["ten"].ToString());
						anode.Tag = r["ma"].ToString();
						anoder.Nodes.Add(anode);
					}
				}
				if(anoder.Nodes.Count>0)
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
				toolTip1.SetToolTip(tree_Quyenso,lan.Change_language_MessageText(
"Ký hiệu biên lai"));
			}
			catch
			{
			}
		}
		private void f_Load_tree_User1()
		{
			try
			{
				string sql = "select to_char(id) ma, hoten ten from medibv.v_dlogin order by hoten asc";
				f_Load_Tree(tree_User,m_v.get_data(sql));
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
		private void f_Load_Tree_Doituong()
		{
			try
			{
				string sql = "select to_char(madoituong) as ma, doituong as ten from medibv.doituong order by madoituong";
				f_Load_Tree(tree_Doituong,m_v.get_data(sql));
			}
			catch
			{
			}
		}

		private DataSet f_Cursor1()
		{
			try
			{
				DataSet ads = new DataSet();
				ads.Tables.Add("Tables");
				ads.Tables[0].Columns.Add("sotienno");
				ads.Tables[0].Columns.Add("sotienthu");
				ads.Tables[0].Columns.Add("tilebyt");
				ads.Tables[0].Columns.Add("tilebv");
				ads.Tables[0].Columns.Add("sotienbyt");
				ads.Tables[0].Columns.Add("sotienbv");
				ads.Tables[0].Columns.Add("sotiennop");
				ads.Tables[0].Columns.Add("chutiennop");
				ads.Tables[0].Columns.Add("guikem");
				return ads;
			}
			catch
			{
				return null;
			}
		}
		private DataSet f_Cursor2()
		{
			try
			{
				DataSet ads = new DataSet();
				ads.Tables.Add("Tables");
				ads.Tables[0].Columns.Add("loai");
				ads.Tables[0].Columns.Add("dvt");
				ads.Tables[0].Columns.Add("kyhieu");
				ads.Tables[0].Columns.Add("solan");
				ads.Tables[0].Columns.Add("mucthu");
				ads.Tables[0].Columns.Add("tongtien");
				ads.Tables[0].Columns.Add("solanhuy");
				return ads;
			}
			catch
			{
				return null;
			}
		}
		private DataSet f_Cursor3()
		{
			try
			{
				DataSet ads = new DataSet();
				ads.Tables.Add("Tables");
				ads.Tables[0].Columns.Add("kyhieu");
				ads.Tables[0].Columns.Add("soluong");
				ads.Tables[0].Columns.Add("tusodenso");
				ads.Tables[0].Columns.Add("xoabo");
				ads.Tables[0].Columns.Add("sotienthu");
				ads.Tables[0].Columns.Add("sotiennop");
				ads.Tables[0].Columns.Add("ghichu");
				return ads;
			}
			catch
			{
				return null;
			}
		}
		private void f_Tinhtien()
		{
			try
			{
				decimal atylebyt=0,atylebv=0,asotien=0,ano=0, ahoan=0;
				try
				{
					asotien=decimal.Parse(txtTongthu.Text.Trim());
				}
				catch
				{
					asotien=0;
				}
				try
				{
					ahoan=decimal.Parse(txtTonghoan.Text.Trim());
				}
				catch
				{
					ahoan=0;
				}
				try
				{
					atylebyt=decimal.Parse(txtTyleBYT.Text.Trim());
				}
				catch
				{
					atylebyt=0;
				}

				try
				{
					atylebv=decimal.Parse(txtTyleBV.Text.Trim());
				}
				catch
				{
					atylebv=0;
				}

				try
				{
					ano=decimal.Parse(txtNo.Text.Trim());
				}
				catch
				{
					ano=0;
				}

				txtTongthu.Text=asotien.ToString("###,###,##0");
				txtTyleBYT.Text=atylebyt.ToString("###,###,##0");
				txtTyleBV.Text=atylebv.ToString("###,###,##0");
				txtSotienBYT.Text=((asotien-ahoan)*atylebyt/100).ToString("###,###,##0");
				txtSotienBV.Text=((asotien-ahoan)*atylebv/100).ToString("###,###,##0");
				txtNop.Text=(asotien-ahoan-decimal.Parse(txtSotienBYT.Text.Trim())-decimal.Parse(txtSotienBV.Text.Trim())+ano).ToString("###,###,##0");
				txtNop_Validated(null,null);
			}
			catch
			{
			}
		}
		private void f_Load_CB()
		{
			try
			{
				//string sql = "select to_char(madoituong) ma, doituong ten from doituong order by madoituong asc";
				//DataSet ads =  m_d.get_data(sql);
				//cbDoiTuong.DisplayMember="TEN";
				//cbDoiTuong.ValueMember="MA";
				//cbDoiTuong.DataSource = ads.Tables[0];
				//cbDoiTuong.SelectedValue="";
			}
			catch
			{
			}
		}
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

		private void f_Display_User()
		{
			try
			{
				DataSet ads = m_v.get_data("select to_char(id) id, hoten from medibv.v_dlogin where to_char(id)='"+ m_userid + "'");
				lbNguoiDN.Text=lan.Change_language_MessageText(
"Người đăng nhập:")+" " + ads.Tables[0].Rows[0]["hoten"].ToString();
				lbNgayDN.Text=lan.Change_language_MessageText(
"Ngày:")+" " + f_Cur_Date();
				txtNguoilapbang.Text =ads.Tables[0].Rows[0]["hoten"].ToString();
			}
			catch
			{
				MessageBox.Show(this,lan.Change_language_MessageText("Chưa đăng nhập. Chỉ có quyền xem thông tin"),m_v.s_AppName,MessageBoxButtons.OK,MessageBoxIcon.Warning);
				lbNguoiDN.Text=lan.Change_language_MessageText("Người đăng nhập: ???? ");
				lbNgayDN.Text=lan.Change_language_MessageText("Ngày: ")+f_Cur_Date();
			}
		}
		private void f_LoadHistory()
		{
			try
			{
				txtNgayin.Value = System.DateTime.Now;
				DataSet ads = new DataSet();
				ads.ReadXml("..//..//option//v_baocaothue.xml");
				txtNguoilapbang.Text=ads.Tables[0].Rows[0]["nguoilapbang"].ToString();
				txtKetoantruong.Text=ads.Tables[0].Rows[0]["ketoantruong"].ToString();
				txtGiamdoc.Text=ads.Tables[0].Rows[0]["giamdoc"].ToString();
				txtGuikem.Text=ads.Tables[0].Rows[0]["guikem"].ToString();
				txtCucthue.Text=ads.Tables[0].Rows[0]["cucthue"].ToString();
				txtMau.Text=ads.Tables[0].Rows[0]["mau"].ToString();
				txtSo.Text=ads.Tables[0].Rows[0]["so"].ToString();
				txtTyleBYT.Text=ads.Tables[0].Rows[0]["tyleBYT"].ToString();
				txtTyleBV.Text=ads.Tables[0].Rows[0]["tyleBV"].ToString();
			}
			catch
			{
			}
		}
		private void f_SaveHistory()
		{
			try
			{
				DataSet ads = new DataSet();
				ads.Tables.Add("Tables");
				ads.Tables[0].Columns.Add("nguoilapbang");
				ads.Tables[0].Columns.Add("ketoantruong");
				ads.Tables[0].Columns.Add("giamdoc");
				ads.Tables[0].Columns.Add("guikem");
				ads.Tables[0].Columns.Add("cucthue");
				ads.Tables[0].Columns.Add("mau");
				ads.Tables[0].Columns.Add("so");
				ads.Tables[0].Columns.Add("tyleBYT");
				ads.Tables[0].Columns.Add("tyleBV");
				ads.Tables[0].Rows.Add(new string[]{txtNguoilapbang.Text.Trim(),txtKetoantruong.Text.Trim(),txtGiamdoc.Text.Trim(),txtGuikem.Text,txtCucthue.Text.Trim(),txtMau.Text.Trim(),txtSo.Text.Trim(),txtTyleBYT.Text.Trim(),txtTyleBV.Text.Trim()});
				ads.WriteXml("..//..//option//v_baocaothue.xml",XmlWriteMode.WriteSchema);
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
						c.ForeColor=SystemColors.InfoText;
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
						c.ForeColor=SystemColors.ControlText;
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
		private void panel2_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
		
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void txtThang_ValueChanged(object sender, System.EventArgs e)
		{
			try
			{
				txtTN.Value = new DateTime(int.Parse(txtNam.Value.ToString()),int.Parse(txtThang.Value.ToString()),1);
				txtDN.Value = new DateTime(int.Parse(txtNam.Value.ToString()),int.Parse(txtThang.Value.ToString()),DateTime.DaysInMonth(int.Parse(txtNam.Value.ToString()),int.Parse(txtThang.Value.ToString())));
			}
			catch
			{
			}
		}

		private void txtNam_ValueChanged(object sender, System.EventArgs e)
		{
			try
			{
				txtTN.Value = new DateTime(int.Parse(txtNam.Value.ToString()),int.Parse(txtThang.Value.ToString()),1);
				txtDN.Value = new DateTime(int.Parse(txtNam.Value.ToString()),int.Parse(txtThang.Value.ToString()),DateTime.DaysInMonth(int.Parse(txtNam.Value.ToString()),int.Parse(txtThang.Value.ToString())));
			}
			catch
			{
			}
		}

		private void txtTN_Validated(object sender, System.EventArgs e)
		{
			try
			{
				if(txtDN.Value<txtTN.Value)
				{
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
				if(txtTN.Value>txtDN.Value)
				{
					txtTN.Value=txtDN.Value;
				}
			}
			catch
			{
			}
		}

		private void rd_CheckedChanged(object sender, System.EventArgs e)
		{
			try
			{
				if(rd1.Checked) groupBox2.Tag=rd1.Tag.ToString();
				if(rd2.Checked) groupBox2.Tag=rd2.Tag.ToString();
				if(rd3.Checked) groupBox2.Tag=rd3.Tag.ToString();
				if(rd4.Checked) groupBox2.Tag=rd4.Tag.ToString();
				
//				txtGuikem.Enabled = rd1.Checked;
//				txtCucthue.Enabled=rd3.Checked;
//				txtMau.Enabled=rd3.Checked;
//				txtSo.Enabled=rd3.Checked;
//				txtNo.Enabled = rd1.Checked;
//				txtTyleBYT.Enabled = rd1.Checked||rd3.Checked;
//				txtTyleBV.Enabled = rd1.Checked||rd3.Checked;
//				txtNguoilapbang.Enabled = rd3.Checked;
//				txtKetoantruong.Enabled = rd3.Checked;
			}
			catch
			{
			}
		}

		private void txtCoquanthue_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
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

		private void txtThang_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
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

		private void txtNam_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
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
					SendKeys.Send("{Tab}");
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
					SendKeys.Send("{Tab}");
				}
			}
			catch
			{
			}
		}

		private void txtTongthu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
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

		private void txtNo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
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

		private void txtTyleBYT_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
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

		private void txtSotienBYT_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
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

		private void txtTyleBV_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
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

		private void txtSotienBV_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
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

		private void txtNop_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
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

		private void txtDiachi_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
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

		private void txtNgayin_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
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

		private void frmTokhainopthue_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			try
			{
				if(e.KeyCode==Keys.Escape)
				{
					butKetthuc_Click(null,null);
					return;
				}
				if(e.Alt)
				{
					lbLamtron.Visible=!lbLamtron.Visible;
					txtLamtron.Visible=!txtLamtron.Visible;
					return;
				}
			}
			catch
			{
			}
		}

		private void txtNop_Validated(object sender, System.EventArgs e)
		{
			try
			{
				txtNop.Text=decimal.Parse(txtNop.Text.Trim()).ToString("###,###,##0.###");
			}
			catch
			{
			}
		}

		private void txtNo_Validated(object sender, System.EventArgs e)
		{
			try
			{
				txtNo.Text=decimal.Parse(txtNo.Text.Trim()).ToString("###,###,##0.###");
			}
			catch
			{
				txtNo.Text="0";
			}
		}

		private void txtTongthu_Validated(object sender, System.EventArgs e)
		{
			try
			{
				txtTongthu.Text=decimal.Parse(txtTongthu.Text.Trim()).ToString("###,###,##0.###");
			}
			catch
			{
				txtTongthu.Text="0";
			}
		}

		private void txtSotienBYT_Validated(object sender, System.EventArgs e)
		{
			try
			{
				txtSotienBYT.Text=decimal.Parse(txtSotienBYT.Text.Trim()).ToString("###,###,##0.###");
			}
			catch
			{
				txtSotienBYT.Text="0";
			}
		}

		private void txtSotienBV_Validated(object sender, System.EventArgs e)
		{
			try
			{
				txtSotienBV.Text=decimal.Parse(txtSotienBV.Text.Trim()).ToString("###,###,##0.###");
			}
			catch
			{
				txtSotienBV.Text="0";
			}
		}

		private void txtTyleBYT_Validated(object sender, System.EventArgs e)
		{
			try
			{
				int i =  int.Parse(txtTyleBYT.Text);
				txtTyleBYT.Text="";
				if((i>=0)&&(i<=100))
				{
					txtTyleBYT.Text=i.ToString();
				}
			}
			catch
			{
				txtTyleBYT.Text="";
			}
		}

		private void txtTyleBV_Validated(object sender, System.EventArgs e)
		{
			try
			{
				int i =  int.Parse(txtTyleBV.Text);
				txtTyleBV.Text="";
				if((i>=0)&&(i<=100))
				{
					txtTyleBV.Text=i.ToString();
				}
			}
			catch
			{
				txtTyleBV.Text="";
			}
		}

		private void frmTokhainopthue_SizeChanged(object sender, System.EventArgs e)
		{
		}

		private void rdThang_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
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

		private void rdNgay_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
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
		private void butInchiphi_Click(object sender, System.EventArgs e)
		{
			string atmp = System.Environment.CurrentDirectory;
			try
			{
				progressBar1.Visible=true;
				progressBar1.Value=1;
				progressBar1.Update();
				timer1.Enabled=true;
				f_Inbaocao();
				if(txtLamtron.Visible)
				{
					txtLamtron_Validated(null,null);
					f_Save_Lamtron(txtTN.Text.Substring(0,10),txtDN.Text.Substring(0,10),decimal.Parse(txtLamtron.Text.Trim()));
				}
				progressBar1.Value=0;
				progressBar1.Visible=false;
				timer1.Enabled=false;
			}
			catch
			{
			}
			finally
			{
				System.Environment.CurrentDirectory=atmp;
			}
		}
		private decimal f_TyleSD()
		{
			try
			{
				decimal d1=0,d2=0;
				try
				{
					d1=decimal.Parse(txtTyleBYT.Text.Trim());
				}
				catch
				{
					d1=0;
				}
				try
				{
					d2=decimal.Parse(txtTyleBV.Text.Trim());
				}
				catch
				{
					d2=0;
				}
				return d1 + d2;
			}
			catch
			{
				return 0;
			}
		}
		private DataSet f_get_Data()
		{
			DataSet ads = new DataSet();
			try
			{
				string sql="", asort="",asqltt="", asqlnt="",exptt="", expnt="",auserid="",aquyenso="", adoituong="",asqlht="";
				auserid=f_Get_CheckID(tree_User,1);
				aquyenso=f_Get_CheckID(tree_User,2);
				adoituong=f_Get_CheckID(tree_Doituong);
				if(m_v.sys_dungchungso)
				{
					auserid = f_Get_CheckID(tree_User);
					aquyenso = f_Get_CheckID(tree_Quyenso);
				}

				asqlht="select * from medibvmmyy.v_hoantra where to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('"+ txtTN.Text.Substring(0,10)+"','dd/mm/yyyy') and to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy')<=to_date('"+ txtDN.Text.Substring(0,10)+"','dd/mm/yyyy')";

				exptt=" and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('"+ txtTN.Text.Substring(0,10)+"','dd/mm/yyyy')";
				exptt=exptt + " and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')<=to_date('"+ txtDN.Text.Substring(0,10)+"','dd/mm/yyyy')";

				if(auserid.Length>0)				
				{
					exptt=exptt + " and a.userid in("+auserid+")";
				}
				if(aquyenso.Length>0)				
				{
					exptt=exptt + " and a.quyenso in("+aquyenso+")";
				}
				expnt=exptt;
				if(adoituong!="")
				{
					if(adoituong.IndexOf("1")>=0)
					{
                        //exptt=exptt+" and g.id is not null";
                        //expnt=expnt+" and g.id is not null";
					}
					exptt=exptt+" and b.madoituong in ("+adoituong+")";
					expnt=expnt+" and aa.madoituong in ("+adoituong+")";
				}

                asqltt = "select '1' loaibl, to_char(a.id) id, to_char(a.ngay,'dd/mm/yyyy') ngay, to_char(a.quyenso) quyensoid, d.sohieubl , d.sohieu quyenso, a.sobienlai, (sum(b.soluong*b.dongia-to_number(decode(b.madoituong,1,b.mien,0))-b.thieu)- nvl(c.sotien,0)) sotien, e.hoten nguoithu, e.hoten||'('||e.userid||') - '||to_char(e.id) tenuserid, e.id userid, decode(f.id,null,'0','1') huy, decode(g.id,null,'0','1') bhyt from medibvmmyy.v_vienphill a, medibvmmyy.v_vienphict b, medibvmmyy.v_mienngtru c, medibv.v_quyenso d, medibv.v_dlogin e, (" + asqlht + ") f, medibvmmyy.v_bhyt g where a.id=b.id and c.id(+)=a.id and g.id(+)=a.id and d.id(+)=a.quyenso and f.quyenso(+)=a.quyenso and f.sobienlai(+)=a.sobienlai and a.userid=e.id and a.sobienlai>0 " + exptt + " group by to_char(a.id), to_char(a.ngay,'dd/mm/yyyy'), to_char(a.quyenso), d.sohieubl, d.sohieu, a.sobienlai, e.hoten, e.hoten||'('||e.userid||') - '||to_char(e.id), e.id, c.sotien,decode(f.id,null,'0','1'),decode(g.id,null,'0','1')";
                asqlnt = "select '2' loaibl, to_char(a.id) id, to_char(a.ngay,'dd/mm/yyyy') ngay, to_char(a.quyenso) quyensoid, d.sohieubl, d.sohieu quyenso, a.sobienlai, (nvl(a.sotien,0)-nvl(a.mien,0)-nvl(a.bhyt,0)) sotien, e.hoten nguoithu, e.hoten||'('||e.userid||') - '||to_char(e.id) tenuserid, e.id userid, decode(f.id,null,'0','1') huy, decode(g.id,null,'0','1') bhyt from medibvmmyy.v_ttrvll a, medibvmmyy.v_ttrvct aa, medibvmmyy.v_miennoitru c, medibv.v_quyenso d, medibv.v_dlogin e, (" + asqlht + ") f, medibvmmyy.v_ttrvbhyt g where a.id=aa.id and c.id(+)=a.id and d.id(+)=a.quyenso and g.id(+)=a.id and f.quyenso(+)=a.quyenso and f.sobienlai(+)=a.sobienlai and a.userid=e.id and a.sobienlai>0 " + expnt + " group by to_char(a.id), to_char(a.ngay,'dd/mm/yyyy'), to_char(a.quyenso), d.sohieubl, d.sohieu, a.sobienlai, (nvl(a.sotien,0)-nvl(a.mien,0)-nvl(a.bhyt,0)), e.hoten, e.hoten||'('||e.userid||') - '||to_char(e.id), e.id, decode(f.id,null,'0','1'), decode(g.id,null,'0','1')";
				
				if(!chkTructiep.Checked&&!chkNoitru.Checked)
				{
					sql="select * from ( "+asqltt+" union all "+ asqlnt +" ) froo ";
				}
				else
				{
					if(chkTructiep.Checked)
					{
						if(sql.Length<=0)
						{
							sql="select * from ( "+asqltt;
						}
						else
						{
							sql=sql+ " union all "+ asqltt;
						}
					}

					if(chkNoitru.Checked)
					{
						if(sql.Length<=0)
						{
							sql="select * from ( "+asqlnt;
						}
						else
						{
							sql=sql+ " union all "+ asqlnt;
						}
					}

					if(sql.Length>0)
					{
						sql=sql + ") froo ";
					}
				}

				asort=" order by sohieubl, to_number(sobienlai) asc";

				sql=sql + asort;
				sql="select * from ("+sql+") froo " + asort;
				//MessageBox.Show(sql);
				
				ads =m_v.get_data_all(txtTN.Value,txtDN.Value,sql);				
			}
			catch
			{
			}
			return ads;
		}
		private DataSet f_Sum_Bangkechungtu(DataSet v_ds)
		{
			int aindex=0;
			DataSet ads = new DataSet();
			ads.Tables.Add("Table");
			ads.Tables[0].Columns.Add("kyhieu");
			ads.Tables[0].Columns.Add("soluong",typeof(decimal));
			ads.Tables[0].Columns.Add("tuden");
			ads.Tables[0].Columns.Add("sotien",typeof(decimal));
			ads.Tables[0].Columns.Add("soluong_huy",typeof(decimal));
			ads.Tables[0].Columns.Add("tuden_huy");
			decimal atu=0,aden=0,asotien=0,asoluong=0,asoluong_huy=0;
			string atuden="",atuden_huy="",akyhieu="";
			try
			{
				akyhieu=v_ds.Tables[0].Select("","sohieubl,sobienlai")[0]["sohieubl"].ToString();
						
				atu=decimal.Parse(v_ds.Tables[0].Select("","sohieubl,sobienlai")[0]["sobienlai"].ToString());
				aden=atu-1;
				atuden=decimal.Parse(v_ds.Tables[0].Select("","sohieubl,sobienlai")[0]["sobienlai"].ToString()).ToString().PadLeft(7,'0');
				asotien=0;
				
				asoluong=0;
				asoluong_huy=0;
				atuden_huy="";

				foreach(DataRow r in v_ds.Tables[0].Select("","sohieubl,sobienlai"))
				{
					if(akyhieu!=r["sohieubl"].ToString()||(aden+1!=decimal.Parse(r["sobienlai"].ToString())))
					{
						atuden=atuden+" ... "+aden.ToString().PadLeft(7,'0');//decimal.Parse(r["sobienlai"].ToString()).ToString().PadLeft(7,'0');

						DataRow r1= ads.Tables[0].NewRow();
						r1["kyhieu"]=akyhieu;
						r1["soluong"]=asoluong.ToString();
						r1["tuden"]=atuden;
						r1["sotien"]=asotien.ToString();
						r1["soluong_huy"]=asoluong_huy.ToString();
						r1["tuden_huy"]=atuden_huy.Trim().Trim(',').Trim();
						ads.Tables[0].Rows.Add(r1);
						
						akyhieu=r["sohieubl"].ToString();
						
						atu=decimal.Parse(r["sobienlai"].ToString());
						aden=atu;
						atuden=atu.ToString().PadLeft(7,'0');
						
						if(r["huy"].ToString()=="1")
						{
							asoluong=0;
							asoluong_huy=1;
							atuden_huy=atu.ToString().PadLeft(7,'0');
							asotien=0;
						} 
						else
						{
							asoluong=1;
							asoluong_huy=0;
							atuden_huy="";
							asotien=decimal.Parse(decimal.Parse(r["sotien"].ToString()).ToString("###,###,##0.###"));
						}
						aindex=0;
					}
					else
					{
						aindex++;
						if(r["huy"].ToString()=="1")
						{
							asoluong_huy=asoluong_huy+1;
							atuden_huy=atuden_huy.Trim().Trim(',')+", "+decimal.Parse(r["sobienlai"].ToString()).ToString().PadLeft(7,'0');
						}
						else
						{
							asoluong=asoluong+1;
							asotien=asotien+decimal.Parse(decimal.Parse(r["sotien"].ToString()).ToString("###,###,##0.###"));
						}
						aden=decimal.Parse(r["sobienlai"].ToString());
					}
				}
				atuden=atuden+" ... "+decimal.Parse(v_ds.Tables[0].Rows[v_ds.Tables[0].Rows.Count-1]["sobienlai"].ToString()).ToString().PadLeft(7,'0');
				DataRow r2= ads.Tables[0].NewRow();
				r2["kyhieu"]=akyhieu;
				r2["soluong"]=asoluong.ToString();
				r2["tuden"]=atuden;
				r2["sotien"]=asotien.ToString();
				r2["soluong_huy"]=asoluong_huy.ToString();
				r2["tuden_huy"]=atuden_huy.Trim().Trim(',').Trim();
				ads.Tables[0].Rows.Add(r2);
			}
			catch
			{
			}
			return ads;
		}
		private int f_get_index(int v_sobl, int v_lock)
		{
			try
			{
				int aid=v_sobl-(v_sobl/v_lock)*v_lock;
				if(aid==0) aid=50;
				return aid;
			}
			catch
			{
				return 1;
			}
		}
		private DataSet f_Sum_Tokhaichitiet(DataSet v_ds)
		{
			int alock=int.Parse(txtLock.Value.ToString()), aindex=0;
			DataSet ads = new DataSet();
			ads.Tables.Add("Table");
			ads.Tables[0].Columns.Add("kyhieu");
			ads.Tables[0].Columns.Add("soluong",typeof(decimal));
			ads.Tables[0].Columns.Add("tuden");
			ads.Tables[0].Columns.Add("sotien",typeof(decimal));
			ads.Tables[0].Columns.Add("soluong_huy",typeof(decimal));
			ads.Tables[0].Columns.Add("tuden_huy");
			decimal atu=0,aden=0,asotien=0,asoluong=0,asoluong_huy=0;
			string atuden="",atuden_huy="",akyhieu="";
			try
			{
				akyhieu=v_ds.Tables[0].Select("")[0]["sohieubl"].ToString();
						
				atu=decimal.Parse(v_ds.Tables[0].Select("")[0]["sobienlai"].ToString());
				aden=atu;
				atuden=decimal.Parse(v_ds.Tables[0].Select("")[0]["sobienlai"].ToString()).ToString().PadLeft(7,'0');
				asotien=0;
				
				asoluong=0;
				asoluong_huy=0;
				atuden_huy="";

				aindex=f_get_index(int.Parse(atu.ToString()),alock);
				aindex=aindex-1;

				foreach(DataRow r in v_ds.Tables[0].Select(""))
				{
					aindex++;
					if(akyhieu!=r["sohieubl"].ToString()||(aden+1!=decimal.Parse(r["sobienlai"].ToString())) || aindex>alock || asoluong_huy>0)
					{
						if(asoluong_huy>0)
						{
							atuden=atuden+" ... "+(aden-1).ToString().PadLeft(7,'0');
						}
						else
						{
							atuden=atuden+" ... "+aden.ToString().PadLeft(7,'0');
						}
						if(asotien==0)
						{
							atuden="";
						}

						if(asoluong>0 || asoluong_huy>0)
						{
							DataRow r1= ads.Tables[0].NewRow();
							r1["kyhieu"]=akyhieu;
							r1["soluong"]=asoluong.ToString();
							r1["tuden"]=atuden;
							r1["sotien"]=asotien.ToString();
							r1["soluong_huy"]=asoluong_huy.ToString();
							r1["tuden_huy"]=atuden_huy.Trim().Trim(',').Trim();
							ads.Tables[0].Rows.Add(r1);
						}
						
						akyhieu=r["sohieubl"].ToString();
						
						atu=decimal.Parse(r["sobienlai"].ToString());
						aindex=f_get_index(int.Parse(atu.ToString()),alock);
						aden=atu;
						atuden=atu.ToString().PadLeft(7,'0');
						
						if(r["huy"].ToString()=="1")
						{
							asoluong=0;
							asoluong_huy=1;
							atuden_huy=atu.ToString().PadLeft(7,'0');
							asotien=0;
						} 
						else
						{
							asoluong=1;
							asoluong_huy=0;
							atuden_huy="";
							asotien=decimal.Parse(decimal.Parse(r["sotien"].ToString()).ToString("###,###,##0.###"));
						}
					}
					else
					{
						if(r["huy"].ToString()=="1")
						{
							asoluong_huy=asoluong_huy+1;
							atuden_huy=atuden_huy.Trim().Trim(',')+", "+decimal.Parse(r["sobienlai"].ToString()).ToString().PadLeft(7,'0');
						}
						else
						{
							asoluong=asoluong+1;
							asotien=asotien+decimal.Parse(decimal.Parse(r["sotien"].ToString()).ToString("###,###,##0.###"));
						}
						aden=decimal.Parse(r["sobienlai"].ToString());
					}
				}
				atuden=atuden+" ... "+decimal.Parse(v_ds.Tables[0].Rows[v_ds.Tables[0].Rows.Count-1]["sobienlai"].ToString()).ToString().PadLeft(7,'0');

				if(asoluong>0 || asoluong_huy>0)
				{
					DataRow r2= ads.Tables[0].NewRow();
					r2["kyhieu"]=akyhieu;
					r2["soluong"]=asoluong.ToString();
					r2["tuden"]=atuden;
					r2["sotien"]=asotien.ToString();
					r2["soluong_huy"]=asoluong_huy.ToString();
					r2["tuden_huy"]=atuden_huy.Trim().Trim(',').Trim();
					ads.Tables[0].Rows.Add(r2);
				}
			}
			catch//(Exception ex)
			{
				//MessageBox.Show(ex.ToString());
			}
			return ads;
		}
		private DataSet f_Sum_Tokhai(DataSet v_ds)
		{
			DataSet ads =f_Cursor1();
			decimal asotien=0;
			try
			{
				foreach(DataRow r in v_ds.Tables[0].Rows)
				{
					if(r["huy"].ToString()=="1")
					{
					}
					else
					{
						asotien=asotien+decimal.Parse(decimal.Parse(r["sotien"].ToString()).ToString("###,###,##0.###"));
					}
				}
			}
			catch
			{
			}

			try
			{
				txtTongthu.Text = asotien.ToString("###,###,##0.###");
				f_Tinhtien();

				DataRow r = ads.Tables[0].NewRow();
				r["sotienno"]=txtNo.Text.Trim()==""?"0":decimal.Parse(txtNo.Text.Trim()).ToString();
				r["sotienthu"]=txtTongthu.Text.Trim()==""?"0":decimal.Parse(txtTongthu.Text.Trim()).ToString();
				r["tilebyt"]=txtTyleBYT.Text.Trim()==""?"0":decimal.Parse(txtTyleBYT.Text.Trim()).ToString();
				r["tilebv"]=txtTyleBV.Text.Trim()==""?"0":decimal.Parse(txtTyleBV.Text.Trim()).ToString();
				r["sotienbyt"]=txtSotienBYT.Text.Trim()==""?"0":decimal.Parse(txtSotienBYT.Text.Trim()).ToString();
				r["sotienbv"]=txtSotienBV.Text.Trim()==""?"0":decimal.Parse(txtSotienBV.Text.Trim()).ToString();
				r["sotiennop"]=txtNop.Text.Trim()==""?"0":decimal.Parse(txtNop.Text.Trim()).ToString();
				r["chutiennop"]="";
				r["guikem"]=txtGuikem.Text.Trim();
				ads.Tables[0].Rows.Add(r);
			}
			catch
			{
				ads = f_Cursor1();
			}
			return ads;
		}
		private DataSet f_Hoan()
		{
			try
			{
				string sql="", exp="",asqlct="",auserid="",aquyenso="", adoituong="";
				auserid=f_Get_CheckID(tree_User,1);
				aquyenso=f_Get_CheckID(tree_User,2);
				adoituong=f_Get_CheckID(tree_Doituong);

				if(auserid.Length>0)
				{
					exp="a.userid in(" + auserid+")";
				}

				if(aquyenso.Length>0)
				{
					if(exp.Length>0)
					{
						exp=exp + " and a.quyenso in(" + aquyenso +")";
					}
					else
					{
						exp="a.quyenso in(" + aquyenso+")";
					}
				}
				exp=exp.Trim();
				if(exp.Length>0)
				{
					exp="and "+exp.Trim();
				}
				asqlct="";
				if((chkTructiep.Checked && chkNoitru.Checked)||(!chkTructiep.Checked && !chkNoitru.Checked))
				{
                    asqlct = "select 0 loai, ngay, to_char(ngay,'dd/mm/yyyy') ngaythu, quyenso, sobienlai, makp from medibvmmyy.v_vienphill union all select 1 loai, ngay, to_char(ngay,'dd/mm/yyyy') ngaythu, quyenso, sobienlai, makp from medibvmmyy.v_ttrvll";
				}
				else
				{
					asqlct=asqlct.Trim();
					if(chkTructiep.Checked)
					{
						if(asqlct=="")
						{
                            asqlct = "select 0 loai, ngay, to_char(ngay,'dd/mm/yyyy') ngaythu, quyenso, sobienlai,makp from medibvmmyy.v_vienphill";
						}
						else
						{
                            asqlct = asqlct.Trim() + " union all select 0 loai, ngay,to_char(ngay,'dd/mm/yyyy') ngaythu, quyenso, sobienlai,makp from medibvmmyy.v_vienphill";
						}
					}
					asqlct=asqlct.Trim();
					if(chkNoitru.Checked)
					{
						if(asqlct=="")
						{
                            asqlct = "select 1 loai, ngay, to_char(ngay,'dd/mm/yyyy') ngaythu, quyenso, sobienlai, makp from medibvmmyy.v_ttrvll";
						}
						else
						{
                            asqlct = asqlct.Trim() + " union all select 1 loai, ngay, to_char(ngay,'dd/mm/yyyy') ngaythu, quyenso, sobienlai, makp from medibvmmyy.v_ttrvll";
						}
					}

				}
                sql = "select to_char(j.loai)||'_'||to_char(a.id) id, a.mabn, b.hoten, a.sobienlai, a.sotien, to_char(a.ngay,'dd/mm/yyyy') ngay, decode(to_char(a.ngay,'dd/mm/yyyy'),j.ngaythu,1,0) huy, c.sohieu quyenso, a.quyenso quyensoid, f.hoten nguoithu, f.hoten ||' ('||to_char(f.userid)||')' userid, a.ghichu, trim(trim(trim(trim(trim(b.sonha)||' '||trim(b.thon))||' '||trim(i.tenpxa))||' '||trim(h.tenquan))||' '||trim(g.tentt)) diachi, j.loai, j.ngaythu, k.makp, k.tenkp from medibvmmyy.v_hoantra a, medibv.btdbn b, medibv.v_quyenso c, medibv.v_dlogin f, medibv.btdtt g, medibv.btdquan h, medibv.btdpxa i, (" + asqlct + " ) j, medibv.btdkp_bv k where a.quyenso=j.quyenso and a.sobienlai=j.sobienlai and k.makp(+)=j.makp and to_date(j.ngaythu,'dd/mm/yyyy')< to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and b.mabn(+)=a.mabn and c.id(+)=a.quyenso and f.id(+)=a.userid and g.matt(+)=b.matt and h.maqu(+)=b.maqu and i.maphuongxa(+)=b.maphuongxa and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('" + txtTN.Text.Trim().Substring(0, 10) + "','dd/mm/yyyy') and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')<=to_date('" + txtDN.Text.Trim().Substring(0, 10) + "','dd/mm/yyyy') " + exp + " order by c.sohieu, a.sobienlai";
				return m_v.get_data_bc(txtTN.Value,txtDN.Value,sql);
			}
			catch//(Exception ex)
			{
				return null;
			}
		}
		private string f_Sotien_Hoan()
		{
			try
			{
				decimal ast=0,atmp=0;
				foreach(DataRow r in f_Hoan().Tables[0].Rows)
				{
					try
					{
						atmp=decimal.Parse(decimal.Parse(r["sotien"].ToString()).ToString("###,###,##0.###"));
					}
					catch
					{
						atmp=0;
					}
					ast=ast+atmp;
				}
				return ast.ToString();
			}
			catch
			{
				return "0";
			}
		}
		private void f_Inbaocao()
		{
			try
			{
				string atn="",adn="",asyt="",abv="",adiachibv="",amasothue="",angayin="",aghichu="",areport="v_tokhaibaocaothue.rpt";

				txtTonghoan.Text=decimal.Parse(f_Sotien_Hoan()).ToString("###,###,##0.###");
				DataSet ads = new DataSet();
				switch(groupBox2.Tag.ToString())
				{
					case "1":
						areport="v_baocaothue_tk.rpt";
						ads=f_Sum_Tokhai(f_get_Data());
						//ads.WriteXml("..//..//DataReport//v_baocaothue_tk.xml",XmlWriteMode.WriteSchema);
						break;
					case "2":
						areport="v_baocaothue_tkct.rpt";
						ads=f_Sum_Tokhaichitiet(f_get_Data());
						//ads.WriteXml("..//..//DataReport//v_baocaothue_tkct.xml",XmlWriteMode.WriteSchema);
						break;
					case "3":
						areport="v_baocaothue_bkct.rpt";
						ads=f_Sum_Bangkechungtu(f_get_Data());
						//ads.WriteXml("..//..//DataReport//v_baocaothue_bkct.xml",XmlWriteMode.WriteSchema);
						break;
					case "4"://Bảng kê hoàn trả
						areport="v_baocaothue_hdht.rpt";
						ads=f_Hoan();
						//ads.WriteXml("..//..//DataReport//v_baocaothue_bkct.xml",XmlWriteMode.WriteSchema);
						break;
				}
				if(ads==null || ads.Tables[0].Rows.Count<=0)
				{
					MessageBox.Show(this,lan.Change_language_MessageText("Không có số liệu!"),m_v.s_AppName,MessageBoxButtons.OK,MessageBoxIcon.Information);
					return;
				}
				//return;

				asyt=m_v.Syte;
				abv=m_v.Tenbv;
				angayin=lan.Change_language_MessageText(
"Ngày")+" " + txtNgayin.Value.Day.ToString().PadLeft(2,'0') + " "+lan.Change_language_MessageText(
"tháng")+" " + txtNgayin.Value.Month.ToString().PadLeft(2,'0') + " "+lan.Change_language_MessageText(
"năm")+" "+txtNgayin.Value.Year.ToString();
				atn=txtTN.Text.Substring(0,10);
				adn=txtDN.Text.Substring(0,10);
				if(rdThang.Checked)
				{
					aghichu=lan.Change_language_MessageText(
"THÁNG")+" "+ txtThang.Value.ToString().PadLeft(2,'0')+ " "+lan.Change_language_MessageText(
"NĂM")+" " + txtNam.Value.ToString();
				}
				else
				{
					if(atn==adn)
					{
						aghichu  = lan.Change_language_MessageText(
"NGÀY")+" " + atn;
					}
					else
					{
						aghichu = lan.Change_language_MessageText(
"TỪ")+" "+ atn + " "+lan.Change_language_MessageText(
"ĐẾN")+" " + adn; 
					}
				}
				adiachibv=m_v.s_diachi;
				amasothue=m_v.s_masothue;

				if(menuItem1.Checked)
				{
					ads.WriteXml("..//..//Datareport//v_"+areport.Replace(".rpt","")+".xml", XmlWriteMode.WriteSchema);
				}

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
				af.Text=lan.Change_language_MessageText("Báo cáo thuế");
				crystalReportViewer1.BringToFront();
				crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;

				string alamtron="0";
				if(txtLamtron.Visible)
				{
					try
					{
						alamtron=decimal.Parse(txtLamtron.Text.Trim()).ToString("###,###,##0.##");
					}
					catch
					{
						alamtron="0";
					}
				}


                //ReportDocument cMain=new ReportDocument();
                //cMain.Load("..\\..\\..\\report\\"+areport, OpenReportMethod.OpenReportByTempCopy);
                //cMain.SetDataSource(ads);
                //cMain.DataDefinition.FormulaFields["v_syt"].Text="'"+asyt.ToUpper()+"'";
                //cMain.DataDefinition.FormulaFields["v_bv"].Text="'"+abv.ToUpper()+"'";
                //cMain.DataDefinition.FormulaFields["v_diachi"].Text="'"+adiachibv.ToUpper()+"'";
                //cMain.DataDefinition.FormulaFields["v_masothue"].Text="'"+amasothue.ToUpper()+"'";
                //cMain.DataDefinition.FormulaFields["v_ngayin"].Text="'"+angayin+"'";
                //cMain.DataDefinition.FormulaFields["v_ghichu"].Text="'"+aghichu+"'";
                //cMain.DataDefinition.FormulaFields["v_nguoilapbang"].Text="'"+txtNguoilapbang.Text.Trim()+"'";
                //cMain.DataDefinition.FormulaFields["v_cucthue"].Text="'"+txtCucthue.Text.Trim()+"'";
                //cMain.DataDefinition.FormulaFields["v_mau"].Text="'"+txtMau.Text.Trim()+"'";
                //cMain.DataDefinition.FormulaFields["v_so"].Text="'"+txtSo.Text.Trim()+"'";
                //cMain.DataDefinition.FormulaFields["v_ketoantruong"].Text="'"+txtKetoantruong.Text.Trim()+"'";
                //cMain.DataDefinition.FormulaFields["v_giamdoc"].Text="'"+txtGiamdoc.Text.Trim()+"'";
                //cMain.DataDefinition.FormulaFields["v_tylenop"].Text="'"+(100-f_TyleSD()).ToString()+"'";
                //cMain.DataDefinition.FormulaFields["v_hoan"].Text="'"+decimal.Parse(txtTonghoan.Text.Trim()).ToString("###,###,##0.###")+"'";
                //cMain.DataDefinition.FormulaFields["v_lamtron"].Text="'"+alamtron+"'";
                //cMain.PrintOptions.PaperSize=CrystalDecisions.Shared.PaperSize.PaperA4; 
                //cMain.PrintOptions.PaperOrientation=CrystalDecisions.Shared.PaperOrientation.Portrait; 
                //crystalReportViewer1.ReportSource=cMain;
                //af.Text=lan.Change_language_MessageText("Báo cáo thuế (")+areport+")";				
                //progressBar1.Value=0;
                //progressBar1.Visible=false;
                //timer1.Enabled=false;				
                //af.ShowDialog();

                frmReport fa = new frmReport(m_v, ads.Tables[0], areport, asyt.ToUpper(), abv.ToUpper(), adiachibv, amasothue.ToUpper(), angayin, aghichu, txtNguoilapbang.Text.Trim(), txtCucthue.Text.Trim(), txtMau.Text.Trim(), txtSo.Text.Trim(), txtKetoantruong.Text.Trim(), txtGiamdoc.Text.Trim(), (100 - f_TyleSD()).ToString(), decimal.Parse(txtTonghoan.Text.Trim()).ToString("###,###,##0.###"), alamtron, true, "Báo cáo thuế");
                fa.ShowDialog();

			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}
		private void f_Prepare()
		{
			try
			{
				string n = m_v.get_data("select sotien from medibv.v_lamtron where loai=1 and tungay='"+txtTN.Text.Substring(0,10)+"' and denngay='"+txtDN.Text.Substring(0,10)+"'").Tables[0].Rows.Count.ToString();
			}
			catch
			{
                m_v.execute_data("create table medibv.v_lamtron(loai number(1),tungay varchar2(10),denngay varchar2(10),sotien number(12,3))");
			}
		}
		private void f_Save_Lamtron(string v_tn, string v_dn, decimal v_sotien)
		{
			try
			{
                if (m_v.get_data("select sotien from medibv.v_lamtron where loai=1 and tungay='" + v_tn + "' and denngay='" + v_dn + "'").Tables[0].Rows.Count > 0)
				{
                    m_v.execute_data("update medibv.v_lamtron set sotien=" + v_sotien + " where loai=1 and tungay='" + v_tn + "' and denngay='" + v_dn + "'");
				}
				else
				{
                    m_v.execute_data("insert into medibv.v_lamtron(loai,tungay,denngay,sotien) values(1,'" + v_tn + "','" + v_dn + "'," + v_sotien + ")");
				}
			}
			catch
			{
			}
		}
		private void f_Load_Lamtron(string v_tn, string v_dn)
		{
			try
			{
                txtLamtron.Text = decimal.Parse(m_v.get_data("select sotien from medibv.v_lamtron where loai=1 and tungay='" + txtTN.Text.Substring(0, 10) + "' and denngay='" + txtDN.Text.Substring(0, 10) + "'").Tables[0].Rows[0]["sotien"].ToString()).ToString("###,###,##0.###");
			}
			catch
			{
				txtLamtron.Text="0";
			}
		}

		private void frmTokhainopthue_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			try
			{
				f_SaveHistory();
			}
			catch
			{
			}
		}

		private void txtCucthue_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
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

		private void txtMau_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
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

		private void txtSo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
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

		private void rdThang_CheckedChanged(object sender, System.EventArgs e)
		{
		
		}

		private void chkUserid_CheckedChanged(object sender, System.EventArgs e)
		{
			f_Set_CheckID(tree_User,chkUserid.Checked);
		}

		private void chkDoituong_CheckedChanged(object sender, System.EventArgs e)
		{
			f_Set_CheckID(tree_Doituong,chkDoituong.Checked);
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

				amsg=lan.Change_language_MessageText("Đã chọn:")+"\n"+lan.Change_language_MessageText(
"Nhân viên thu ngân:")+" "+anu.ToString()+"\n"+lan.Change_language_MessageText("Quyển sổ thu tiền:")+" "+ans.ToString();
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

		private void tree_Doituong_AfterCheck(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			try
			{
				e.Node.ForeColor=e.Node.Checked?Color.Navy:Color.DimGray;
				for(int i=0;i<tree_Doituong.Nodes.Count;i++)
				{
					if(tree_Doituong.Nodes[i].Checked)
					{
						return;
					}
				}
				chkDoituong.Checked=false;
			}
			catch
			{
			}
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

		#region Datagrid Colored Collum
		public Color MyGetColorRowCol(int row, int col)
		{
			Color c = Color.Black;
			switch (col.ToString())
			{
				case "0":
					c=Color.Black;
					break;
				case "1":
					c=Color.Blue;
					break;
				case "2":
					c=Color.Red;
					break;
				case "3":
					c=Color.Orange;
					break;
				case "4":
					c=Color.Cyan;
					break;
				default:
					c=Color.Black;
					break;
			}
			return c;
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

		private void menuItem1_Click(object sender, System.EventArgs e)
		{
			menuItem1.Checked=!menuItem1.Checked;
		}

		private void txtLamtron_Validated(object sender, System.EventArgs e)
		{
			try
			{
				txtLamtron.Text=decimal.Parse(txtLamtron.Text.Trim()).ToString("###,###,##0.###");
			}
			catch
			{
				txtLamtron.Text="0";
			}
		}

		private void txtDN_ValueChanged(object sender, System.EventArgs e)
		{
			f_Load_Lamtron(txtTN.Text.Substring(0,10),txtDN.Text.Substring(0,10));
		}

		private void txtTN_ValueChanged(object sender, System.EventArgs e)
		{
			f_Load_Lamtron(txtTN.Text.Substring(0,10),txtDN.Text.Substring(0,10));
		}

		private void menuItem7_Click(object sender, System.EventArgs e)
		{
			lbLamtron.Visible=!lbLamtron.Visible;
			txtLamtron.Visible=!txtLamtron.Visible;
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
					//foreBrush = new SolidBrush(_getColorRowCol(rowNum, this._column));
					//backBrush = new SolidBrush(Color.GhostWhite);
				}
				catch{}
				finally
				{
					base.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight);
				}
			}
		}

		#endregion

        private void butBoyte_Click(object sender, EventArgs e)
        {
            frmBaocaobo_VP af = new frmBaocaobo_VP(m_v);
            af.ShowInTaskbar = false;
            af.ShowDialog(this);
        }
    }
}
