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
	/// Summary description for frmBaocaochiphichuathanhtoan.
	/// </summary>
	public class frmBaocaochiphichuathanhtoan : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private string m_userid="";
		private LibVP.AccessData m_v = LibVP.AccessData.GetImplement();
		

		private DataSet m_dsnhomvp =  new DataSet();
		private DataSet m_dsloaivp =  new DataSet();
		private DataSet m_dsgiavp =  new DataSet();
		private DataSet m_dskp =  new DataSet();
		private DataSet m_dsdoituong =  new DataSet();

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
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox txtNguoilapbang;
		private System.Windows.Forms.ComboBox cbMaubaocao;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.TreeView tree_Khoa;
		private System.Windows.Forms.CheckBox chkKP;
		private System.Windows.Forms.CheckBox chkDoituong;
		private System.Windows.Forms.TreeView tree_Doituong;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.CheckBox chkXV;
		private System.Windows.Forms.CheckBox chkCXV;
		private System.Windows.Forms.CheckBox chkTTXK;
		private System.Windows.Forms.TreeView tree_TTXK;
		private System.Windows.Forms.CheckBox chkThuoc;
		private System.Windows.Forms.CheckBox chkVPKhoa;
		private System.Windows.Forms.CheckBox chkChidinh;
		private System.Windows.Forms.CheckBox chkTU;
		private System.Windows.Forms.Label lbKP;
		private System.Windows.Forms.Label lbTT;
		private System.ComponentModel.IContainer components;

		public frmBaocaochiphichuathanhtoan(string v_userid)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBaocaochiphichuathanhtoan));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbTitle = new System.Windows.Forms.Label();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label15 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tree_TTXK = new System.Windows.Forms.TreeView();
            this.chkTTXK = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkTU = new System.Windows.Forms.CheckBox();
            this.chkChidinh = new System.Windows.Forms.CheckBox();
            this.chkVPKhoa = new System.Windows.Forms.CheckBox();
            this.chkThuoc = new System.Windows.Forms.CheckBox();
            this.chkCXV = new System.Windows.Forms.CheckBox();
            this.chkXV = new System.Windows.Forms.CheckBox();
            this.cbMaubaocao = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tree_Doituong = new System.Windows.Forms.TreeView();
            this.tree_Khoa = new System.Windows.Forms.TreeView();
            this.txtNguoilapbang = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.butInBK = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.txtNgayIn = new System.Windows.Forms.DateTimePicker();
            this.chkKP = new System.Windows.Forms.CheckBox();
            this.txtDN = new System.Windows.Forms.DateTimePicker();
            this.txtTN = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chkDoituong = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbTT = new System.Windows.Forms.Label();
            this.lbKP = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
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
            this.panel1.Size = new System.Drawing.Size(593, 49);
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
            this.lbTitle.Size = new System.Drawing.Size(481, 45);
            this.lbTitle.TabIndex = 15;
            this.lbTitle.Text = "BÁO CÁO CHI PHÍ BỆNH NHÂN CHƯA THANH TOÁN";
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // contextMenu1
            // 
            this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.Text = "Write XML";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
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
            this.label15.Size = new System.Drawing.Size(593, 3);
            this.label15.TabIndex = 17;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.tree_TTXK);
            this.panel2.Controls.Add(this.chkTTXK);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.cbMaubaocao);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.tree_Doituong);
            this.panel2.Controls.Add(this.tree_Khoa);
            this.panel2.Controls.Add(this.txtNguoilapbang);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.butInBK);
            this.panel2.Controls.Add(this.butKetthuc);
            this.panel2.Controls.Add(this.txtNgayIn);
            this.panel2.Controls.Add(this.chkKP);
            this.panel2.Controls.Add(this.txtDN);
            this.panel2.Controls.Add(this.txtTN);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.chkDoituong);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.lbTT);
            this.panel2.Controls.Add(this.lbKP);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.ForeColor = System.Drawing.Color.Navy;
            this.panel2.Location = new System.Drawing.Point(3, 55);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(593, 345);
            this.panel2.TabIndex = 18;
            // 
            // tree_TTXK
            // 
            this.tree_TTXK.BackColor = System.Drawing.Color.White;
            this.tree_TTXK.CheckBoxes = true;
            this.tree_TTXK.ForeColor = System.Drawing.Color.DimGray;
            this.tree_TTXK.FullRowSelect = true;
            this.tree_TTXK.Location = new System.Drawing.Point(146, 248);
            this.tree_TTXK.Name = "tree_TTXK";
            this.tree_TTXK.ShowLines = false;
            this.tree_TTXK.ShowPlusMinus = false;
            this.tree_TTXK.ShowRootLines = false;
            this.tree_TTXK.Size = new System.Drawing.Size(168, 87);
            this.tree_TTXK.Sorted = true;
            this.tree_TTXK.TabIndex = 5;
            this.tree_TTXK.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tree_TTXK_KeyDown);
            // 
            // chkTTXK
            // 
            this.chkTTXK.BackColor = System.Drawing.SystemColors.Control;
            this.chkTTXK.ForeColor = System.Drawing.Color.Navy;
            this.chkTTXK.Location = new System.Drawing.Point(146, 231);
            this.chkTTXK.Name = "chkTTXK";
            this.chkTTXK.Size = new System.Drawing.Size(134, 18);
            this.chkTTXK.TabIndex = 4;
            this.chkTTXK.TabStop = false;
            this.chkTTXK.Text = "Tình trạng xuất viện";
            this.chkTTXK.UseVisualStyleBackColor = false;
            this.chkTTXK.CheckedChanged += new System.EventHandler(this.chkTTXK_CheckedChanged);
            this.chkTTXK.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkTTXK_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkTU);
            this.groupBox1.Controls.Add(this.chkChidinh);
            this.groupBox1.Controls.Add(this.chkVPKhoa);
            this.groupBox1.Controls.Add(this.chkThuoc);
            this.groupBox1.Controls.Add(this.chkCXV);
            this.groupBox1.Controls.Add(this.chkXV);
            this.groupBox1.Location = new System.Drawing.Point(320, 95);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(264, 136);
            this.groupBox1.TabIndex = 202;
            this.groupBox1.TabStop = false;
            this.groupBox1.Tag = "1";
            this.groupBox1.Text = "Tùy chọn";
            // 
            // chkTU
            // 
            this.chkTU.BackColor = System.Drawing.SystemColors.Control;
            this.chkTU.Checked = true;
            this.chkTU.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTU.ForeColor = System.Drawing.Color.Navy;
            this.chkTU.Location = new System.Drawing.Point(12, 112);
            this.chkTU.Name = "chkTU";
            this.chkTU.Size = new System.Drawing.Size(136, 21);
            this.chkTU.TabIndex = 7;
            this.chkTU.TabStop = false;
            this.chkTU.Text = "Tạm ứng";
            this.chkTU.UseVisualStyleBackColor = false;
            // 
            // chkChidinh
            // 
            this.chkChidinh.BackColor = System.Drawing.SystemColors.Control;
            this.chkChidinh.Checked = true;
            this.chkChidinh.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkChidinh.ForeColor = System.Drawing.Color.Navy;
            this.chkChidinh.Location = new System.Drawing.Point(12, 91);
            this.chkChidinh.Name = "chkChidinh";
            this.chkChidinh.Size = new System.Drawing.Size(136, 21);
            this.chkChidinh.TabIndex = 6;
            this.chkChidinh.TabStop = false;
            this.chkChidinh.Text = "Chỉ định";
            this.chkChidinh.UseVisualStyleBackColor = false;
            // 
            // chkVPKhoa
            // 
            this.chkVPKhoa.BackColor = System.Drawing.SystemColors.Control;
            this.chkVPKhoa.Checked = true;
            this.chkVPKhoa.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkVPKhoa.ForeColor = System.Drawing.Color.Navy;
            this.chkVPKhoa.Location = new System.Drawing.Point(12, 70);
            this.chkVPKhoa.Name = "chkVPKhoa";
            this.chkVPKhoa.Size = new System.Drawing.Size(136, 21);
            this.chkVPKhoa.TabIndex = 5;
            this.chkVPKhoa.TabStop = false;
            this.chkVPKhoa.Text = "Viện phí khoa";
            this.chkVPKhoa.UseVisualStyleBackColor = false;
            // 
            // chkThuoc
            // 
            this.chkThuoc.BackColor = System.Drawing.SystemColors.Control;
            this.chkThuoc.Checked = true;
            this.chkThuoc.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkThuoc.ForeColor = System.Drawing.Color.Navy;
            this.chkThuoc.Location = new System.Drawing.Point(12, 49);
            this.chkThuoc.Name = "chkThuoc";
            this.chkThuoc.Size = new System.Drawing.Size(136, 21);
            this.chkThuoc.TabIndex = 4;
            this.chkThuoc.TabStop = false;
            this.chkThuoc.Text = "Thuốc - Vật tư y tế";
            this.chkThuoc.UseVisualStyleBackColor = false;
            // 
            // chkCXV
            // 
            this.chkCXV.BackColor = System.Drawing.SystemColors.Control;
            this.chkCXV.ForeColor = System.Drawing.Color.Navy;
            this.chkCXV.Location = new System.Drawing.Point(104, 24);
            this.chkCXV.Name = "chkCXV";
            this.chkCXV.Size = new System.Drawing.Size(136, 21);
            this.chkCXV.TabIndex = 3;
            this.chkCXV.TabStop = false;
            this.chkCXV.Text = "Chưa xuất viện";
            this.chkCXV.UseVisualStyleBackColor = false;
            this.chkCXV.CheckedChanged += new System.EventHandler(this.chkXV_CheckedChanged);
            // 
            // chkXV
            // 
            this.chkXV.BackColor = System.Drawing.SystemColors.Control;
            this.chkXV.Checked = true;
            this.chkXV.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkXV.ForeColor = System.Drawing.Color.Navy;
            this.chkXV.Location = new System.Drawing.Point(12, 22);
            this.chkXV.Name = "chkXV";
            this.chkXV.Size = new System.Drawing.Size(136, 21);
            this.chkXV.TabIndex = 2;
            this.chkXV.TabStop = false;
            this.chkXV.Text = "Đã xuất viện";
            this.chkXV.UseVisualStyleBackColor = false;
            this.chkXV.CheckedChanged += new System.EventHandler(this.chkXV_CheckedChanged);
            // 
            // cbMaubaocao
            // 
            this.cbMaubaocao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMaubaocao.Location = new System.Drawing.Point(396, 313);
            this.cbMaubaocao.Name = "cbMaubaocao";
            this.cbMaubaocao.Size = new System.Drawing.Size(187, 21);
            this.cbMaubaocao.TabIndex = 12;
            // 
            // label11
            // 
            this.label11.ForeColor = System.Drawing.Color.Navy;
            this.label11.Location = new System.Drawing.Point(314, 317);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(82, 13);
            this.label11.TabIndex = 201;
            this.label11.Text = "Mẫu báo cáo";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tree_Doituong
            // 
            this.tree_Doituong.CheckBoxes = true;
            this.tree_Doituong.ForeColor = System.Drawing.Color.DimGray;
            this.tree_Doituong.FullRowSelect = true;
            this.tree_Doituong.Location = new System.Drawing.Point(5, 248);
            this.tree_Doituong.Name = "tree_Doituong";
            this.tree_Doituong.ShowLines = false;
            this.tree_Doituong.ShowPlusMinus = false;
            this.tree_Doituong.ShowRootLines = false;
            this.tree_Doituong.Size = new System.Drawing.Size(139, 87);
            this.tree_Doituong.Sorted = true;
            this.tree_Doituong.TabIndex = 3;
            this.tree_Doituong.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tree_Doituong_AfterCheck);
            this.tree_Doituong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tree_Doituong_KeyDown);
            // 
            // tree_Khoa
            // 
            this.tree_Khoa.CheckBoxes = true;
            this.tree_Khoa.ForeColor = System.Drawing.Color.DimGray;
            this.tree_Khoa.FullRowSelect = true;
            this.tree_Khoa.Location = new System.Drawing.Point(5, 21);
            this.tree_Khoa.Name = "tree_Khoa";
            this.tree_Khoa.ShowLines = false;
            this.tree_Khoa.ShowPlusMinus = false;
            this.tree_Khoa.ShowRootLines = false;
            this.tree_Khoa.Size = new System.Drawing.Size(311, 209);
            this.tree_Khoa.Sorted = true;
            this.tree_Khoa.TabIndex = 1;
            this.tree_Khoa.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tree_Khoa_AfterCheck);
            this.tree_Khoa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tree_Khoa_KeyDown);
            // 
            // txtNguoilapbang
            // 
            this.txtNguoilapbang.BackColor = System.Drawing.Color.White;
            this.txtNguoilapbang.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNguoilapbang.Location = new System.Drawing.Point(396, 291);
            this.txtNguoilapbang.MaxLength = 50;
            this.txtNguoilapbang.Name = "txtNguoilapbang";
            this.txtNguoilapbang.Size = new System.Drawing.Size(187, 21);
            this.txtNguoilapbang.TabIndex = 11;
            this.txtNguoilapbang.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNguoilapbang_KeyDown);
            // 
            // label10
            // 
            this.label10.ForeColor = System.Drawing.Color.Navy;
            this.label10.Location = new System.Drawing.Point(315, 295);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(82, 13);
            this.label10.TabIndex = 149;
            this.label10.Text = "Người lập bảng";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butInBK
            // 
            this.butInBK.BackColor = System.Drawing.SystemColors.Control;
            this.butInBK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butInBK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butInBK.ForeColor = System.Drawing.Color.Navy;
            this.butInBK.Image = ((System.Drawing.Image)(resources.GetObject("butInBK.Image")));
            this.butInBK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butInBK.Location = new System.Drawing.Point(363, 64);
            this.butInBK.Name = "butInBK";
            this.butInBK.Size = new System.Drawing.Size(73, 25);
            this.butInBK.TabIndex = 9;
            this.butInBK.Text = "    &In ";
            this.butInBK.UseVisualStyleBackColor = true;
            this.butInBK.Click += new System.EventHandler(this.butInBK_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.BackColor = System.Drawing.SystemColors.Control;
            this.butKetthuc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butKetthuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butKetthuc.ForeColor = System.Drawing.Color.Navy;
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(436, 64);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(73, 25);
            this.butKetthuc.TabIndex = 10;
            this.butKetthuc.Text = " &Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.UseVisualStyleBackColor = true;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            this.butKetthuc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.butKetthuc_KeyDown);
            // 
            // txtNgayIn
            // 
            this.txtNgayIn.CustomFormat = "dd/MM/yyyy hh:mm";
            this.txtNgayIn.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtNgayIn.Location = new System.Drawing.Point(363, 42);
            this.txtNgayIn.Name = "txtNgayIn";
            this.txtNgayIn.Size = new System.Drawing.Size(85, 20);
            this.txtNgayIn.TabIndex = 8;
            this.txtNgayIn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNgayIn_KeyDown);
            // 
            // chkKP
            // 
            this.chkKP.Location = new System.Drawing.Point(5, 4);
            this.chkKP.Name = "chkKP";
            this.chkKP.Size = new System.Drawing.Size(131, 18);
            this.chkKP.TabIndex = 0;
            this.chkKP.TabStop = false;
            this.chkKP.Text = "Khoa xuất viện";
            this.chkKP.CheckedChanged += new System.EventHandler(this.chkKP_CheckedChanged);
            this.chkKP.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkKP_KeyDown);
            // 
            // txtDN
            // 
            this.txtDN.CustomFormat = "dd/MM/yyyy hh:mm";
            this.txtDN.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtDN.Location = new System.Drawing.Point(499, 20);
            this.txtDN.Name = "txtDN";
            this.txtDN.Size = new System.Drawing.Size(85, 20);
            this.txtDN.TabIndex = 7;
            this.txtDN.Validated += new System.EventHandler(this.txtDN_Validated);
            this.txtDN.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDN_KeyDown);
            // 
            // txtTN
            // 
            this.txtTN.CustomFormat = "dd/MM/yyyy hh:mm";
            this.txtTN.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtTN.Location = new System.Drawing.Point(363, 20);
            this.txtTN.Name = "txtTN";
            this.txtTN.Size = new System.Drawing.Size(85, 20);
            this.txtTN.TabIndex = 6;
            this.txtTN.Validated += new System.EventHandler(this.txtTN_Validated);
            this.txtTN.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTN_KeyDown);
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(443, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 20);
            this.label2.TabIndex = 78;
            this.label2.Text = "đến ngày";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(318, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 77;
            this.label3.Text = "Từ ngày";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkDoituong
            // 
            this.chkDoituong.BackColor = System.Drawing.SystemColors.Control;
            this.chkDoituong.ForeColor = System.Drawing.Color.Navy;
            this.chkDoituong.Location = new System.Drawing.Point(5, 231);
            this.chkDoituong.Name = "chkDoituong";
            this.chkDoituong.Size = new System.Drawing.Size(83, 18);
            this.chkDoituong.TabIndex = 2;
            this.chkDoituong.TabStop = false;
            this.chkDoituong.Text = "Đối tượng";
            this.chkDoituong.UseVisualStyleBackColor = false;
            this.chkDoituong.CheckedChanged += new System.EventHandler(this.chkDoituong_CheckedChanged);
            this.chkDoituong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkDoituong_KeyDown);
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(281, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 20);
            this.label1.TabIndex = 79;
            this.label1.Text = "Ngày in";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbTT
            // 
            this.lbTT.BackColor = System.Drawing.Color.White;
            this.lbTT.Location = new System.Drawing.Point(148, 250);
            this.lbTT.Name = "lbTT";
            this.lbTT.Size = new System.Drawing.Size(164, 83);
            this.lbTT.TabIndex = 204;
            // 
            // lbKP
            // 
            this.lbKP.BackColor = System.Drawing.Color.White;
            this.lbKP.Location = new System.Drawing.Point(8, 23);
            this.lbKP.Name = "lbKP";
            this.lbKP.Size = new System.Drawing.Size(306, 205);
            this.lbKP.TabIndex = 203;
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label6.Location = new System.Drawing.Point(3, 400);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(593, 4);
            this.label6.TabIndex = 216;
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(3, 404);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(593, 20);
            this.progressBar1.TabIndex = 215;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmBaocaochiphichuathanhtoan
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(599, 427);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmBaocaochiphichuathanhtoan";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo cáo chi phí bệnh nhân chưa thanh toán";
            this.Load += new System.EventHandler(this.frmBaocaochiphichuathanhtoan_Load);
            this.SizeChanged += new System.EventHandler(this.frmBaocaochiphichuathanhtoan_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmBaocaochiphichuathanhtoan_KeyDown);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
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

		private void f_Display_User()
		{
			try
			{
				DataSet ads = m_v.get_data("select to_char(id) id, hoten from medibv.v_dlogin where to_char(id)='"+ m_userid + "'");
				txtNguoilapbang.Tag=ads.Tables[0].Rows[0]["hoten"].ToString();
			}
			catch
			{
				txtNguoilapbang.Tag="";
			}
			this.Text=this.Text+"/"+txtNguoilapbang.Tag.ToString().Trim();
		}
		private void frmBaocaochiphichuathanhtoan_Load(object sender, System.EventArgs e)
		{
			try
			{
				txtNgayIn.Value=System.DateTime.Now;
				txtTN.Value=System.DateTime.Now;
				txtDN.Value=System.DateTime.Now;
				f_Display_User();
				f_Load_CB_Maubaocao();
				f_Load_Tree_Khoa();
				f_Load_Tree_Doituong();
				f_Load_Tree_TTXK();
				f_LoadHistory();
				f_Load_Data();
				chkXV_CheckedChanged(null,null);
			}
			catch
			{
			}
		}
		private void f_Load_Data()
		{
			try
			{
				m_dsnhomvp=m_v.get_data("select ma, ten from medibv.v_nhomvp");
				m_dsloaivp=m_v.get_data("select id, ten from medibv.v_loaivp");
				m_dsgiavp=m_v.get_data("select a.id, to_char(a.ma) as ma, a.ten, a.id_loai, b.id_nhom from medibv.v_giavp a left join medibv.v_loaivp b on a.id_loai=b.id union all select aa.id,to_char(aa.ma) as ma,aa.ten||' ['||aa.hamluong||']' as ten, 0 id_loai, bb.nhomvp as id_nhom from medibv.d_dmbd aa left join medibv.d_dmnhom bb on aa.manhom=bb.id");
				m_dskp=m_v.get_data("select makp, tenkp from medibv.btdkp_bv");
				m_dsdoituong=m_v.get_data("select madoituong, doituong from medibv.doituong");
			}
			catch
			{
			}
		}
		private string f_get_tenkp(string v_makp)
		{
			try
			{
				return m_dskp.Tables[0].Select("makp='"+v_makp+"'")[0]["tenkp"].ToString();
			}
			catch
			{
				return "";
			}
		}
		private string f_get_doituong(string v_madoituong)
		{
			try
			{
				return m_dsdoituong.Tables[0].Select("madoituong="+v_madoituong)[0]["doituong"].ToString();
			}
			catch
			{
				return "";
			}
		}
		private string f_get_nhomvp(string v_id_giavp)
		{
			try
			{
				string ama=m_dsgiavp.Tables[0].Select("id="+v_id_giavp)[0]["id_nhom"].ToString();
				return ama;
			}
			catch
			{
				return "";
			}
		}
		private string f_get_nhomvp_ten(string v_id_giavp)
		{
			try
			{
				string ama=m_dsgiavp.Tables[0].Select("id="+v_id_giavp)[0]["id_nhom"].ToString();
				return m_dsnhomvp.Tables[0].Select("ma="+ama)[0]["ten"].ToString();
			}
			catch
			{
				return "";
			}
		}
		private string f_get_loaivp(string v_id_gia)
		{
			try
			{
				string ama=m_dsgiavp.Tables[0].Select("id="+v_id_gia)[0]["id_loai"].ToString();
				return ama;
			}
			catch
			{
				return "";
			}
		}
		private string f_get_loaivp_ten(string v_id_gia)
		{
			try
			{
				string ama=m_dsgiavp.Tables[0].Select("id="+v_id_gia)[0]["id_loai"].ToString();
				return m_dsloaivp.Tables[0].Select("id="+ama)[0]["ten"].ToString();
			}
			catch
			{
				return "";
			}
		}
		private string f_get_giavp(string v_id)
		{
			try
			{
				return m_dsgiavp.Tables[0].Select("id="+v_id)[0]["ten"].ToString();
			}
			catch
			{
				return "";
			}
		}
		private void f_Load_Tree_Khoa()
		{
			try
			{
				string sql = "select to_char(makp) as ma, tenkp as ten from medibv.btdkp_bv where loai=0 order by tenkp asc";
				f_Load_Tree(tree_Khoa,m_v.get_data(sql));
			}
			catch
			{
			}
		}
		private void f_Load_Tree_Doituong()
		{
			try
			{
				string sql = "select madoituong as ma, doituong as ten from medibv.doituong order by madoituong asc";
				f_Load_Tree(tree_Doituong,m_v.get_data(sql));
			}
			catch
			{
			}
		}
		private void f_Load_Tree_TTXK()
		{
			try
			{
				string sql = "select ma, ten from medibv.ttxk where rakhoa=0 order by ten asc";
				f_Load_Tree(tree_TTXK,m_v.get_data(sql));
			}
			catch
			{
			}
		}
		private void f_Validate()
		{
			try
			{
			}
			catch
			{
			}
		}
		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			this.Close();
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
		private DataSet f_Get_Maubaocaomien()
		{
			//v_maubaocao 
			//loai=1: Báo cáo thu viện phí trực tiếp (v_vienphill, v_vienphict, v_mienngtru, v_bhyt)
			//loai=2: Báo cáo thanh toán ra viện ngoại trú + nội trú (v_ttrvll, v_ttrvct, v_ttrvbhyt, v_ttrvds, v_miennoitru)
			//loai=3: Báo cáo thu tạm ứng
			//loai=4: Báo cáo miễn giảm
			//loai=5: Bảng kê hoàn trả
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
				ads = m_v.get_data("select ma, ten from medibv.v_maubaocao where loai=8");
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
				ads = f_Get_Maubaocaomien();
				cbMaubaocao.DisplayMember="TEN";
				cbMaubaocao.ValueMember="MA";
				cbMaubaocao.DataSource = ads.Tables[0];
				cbMaubaocao.SelectedIndex=0;
			}
			catch
			{
			}
		}
		private DataSet f_Cursor_Tonghop()
		{
			try
			{
				DataSet ads = new DataSet();
				ads.Tables.Add("Table");
				ads.Tables[0].Columns.Add("mabn");
				ads.Tables[0].Columns.Add("hoten");
				ads.Tables[0].Columns.Add("namsinh");
				ads.Tables[0].Columns.Add("diachi");
				ads.Tables[0].Columns.Add("cholam");
				ads.Tables[0].Columns.Add("sothe");
				ads.Tables[0].Columns.Add("mabv");
				ads.Tables[0].Columns.Add("maql");
				ads.Tables[0].Columns.Add("idkhoa");
				ads.Tables[0].Columns.Add("makp");
				ads.Tables[0].Columns.Add("tenkp");
				ads.Tables[0].Columns.Add("ngayvv");
				ads.Tables[0].Columns.Add("ngayrv");
				ads.Tables[0].Columns.Add("ttlucrv");
				ads.Tables[0].Columns.Add("ttlucrv_ten");
				ads.Tables[0].Columns.Add("nhomvp");
				ads.Tables[0].Columns.Add("tennhomvp");
				ads.Tables[0].Columns.Add("loaivp");
				ads.Tables[0].Columns.Add("tenloaivp");
				ads.Tables[0].Columns.Add("mavp");
				ads.Tables[0].Columns.Add("tenvp");
				ads.Tables[0].Columns.Add("madoituong");
				ads.Tables[0].Columns.Add("doituong");
				ads.Tables[0].Columns.Add("soluong",typeof(decimal));
				ads.Tables[0].Columns.Add("dongia",typeof(decimal));

				return ads;
			}
			catch
			{
				return null;
			}
		}
		private void f_InBK_1()
		{
			try
			{
				string adoituong_giadv = m_v.s_doituong_giadv;
				DataSet ads = new DataSet();
				string sql="", aexp="";
				string amakp = f_Get_CheckID(tree_Khoa);
				string adoituong= f_Get_CheckID(tree_Doituong);
				string atinhtrang= f_Get_CheckID(tree_TTXK);
				
				if(amakp.Length>0 && (chkXV.Checked || (!chkXV.Checked && !chkCXV.Checked) || (chkXV.Checked && chkCXV.Checked)))
				{
					amakp=amakp.Replace(",","','");
					amakp="'"+amakp+"'";
					if(aexp.Length>0)
					{
						aexp=aexp+ " and b.makp in("+ amakp+")";
					}
					else
					{
						aexp="b.makp in("+ amakp+")";
					}
				}

				if(adoituong.Length>0)
				{
					if(aexp.Length>0)
					{
						aexp=aexp+ " and a.madoituong in("+ adoituong+")";
					}
					else
					{
						aexp="a.madoituong in("+ adoituong+")";
					}
				}

				if(atinhtrang.Length>0  && (chkXV.Checked || (!chkXV.Checked && !chkCXV.Checked) || (chkXV.Checked && chkCXV.Checked)))
				{
					if(aexp.Length>0)
					{
						aexp=aexp+ " and b.ttlucrv in("+ atinhtrang+")";
					}
					else
					{
						aexp="a.ttlucrv in("+ atinhtrang+")";
					}
				}
				string aexpdt="((to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('"+txtTN.Text.Substring(0,10)+"','dd/mm/yyyy') and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')<=to_date('"+txtDN.Text.Substring(0,10)+"','dd/mm/yyyy')) or (to_date(to_char(b.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('"+txtTN.Text.Substring(0,10)+"','dd/mm/yyyy') and to_date(to_char(b.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')<=to_date('"+txtDN.Text.Substring(0,10)+"','dd/mm/yyyy')) or b.ngay is null)";
				if((!chkXV.Checked && !chkCXV.Checked) || (chkXV.Checked && chkCXV.Checked))
				{
					if(aexp.Length>0)
					{
						aexp=aexp+ " and "+aexpdt;
					}
					else
					{
						aexp=aexpdt;
					}
				}
				else
				if(chkXV.Checked)
				{
					if(aexp.Length>0)
					{
						aexp=aexp+ " and b.maql is not null and "+aexpdt;
					}
					else
					{
						aexp="b.maql is not null and "+aexpdt;
					}
				}
				else
					if(chkCXV.Checked)
				{
					if(aexp.Length>0)
					{
						aexp=aexp+ " and b.maql is null";
					}
					else
					{
						aexp="b.maql is null";
					}
				}

				if(aexp.Trim().Length>0)
				{
					aexp=" and "+ aexp.Trim();
				}
                sql = "select a.mabn, aa.hoten, aa.namsinh, aa.cholam, trim(aa.sonha||' '||aa.thon||' '||g.tenpxa||' '||f.tenquan||' '||e.tentt) diachi, d.sothe, d.mabv, a.maql, to_char(a.ngay,'dd/mm/yyyy') ngayvv, to_char(b.ngay,'dd/mm/yyyy') ngayrv, b.ttlucrv, c.ten ttlucrv_ten ";
                sql += " from medibv.btdbn aa inner join medibv.benhandt a on aa.mabn=a.mabn left join medibv.xuatvien b on a.maql=b.maql left join medibv.ttxk c on b.ttlucrv=c.ma left join medibv.bhyt d on a.maql=d.maql inner join medibv.btdtt e on aa.matt=e.matt inner join medibv.btdquan f on aa.maqu=f.maqu inner join medibv.btdpxa g on aa.maphuongxa=g.maphuongxa where a.loaiba=1 " + aexp;

				ads =  f_Cursor_Tonghop();
				foreach(DataRow r in m_v.get_data(sql).Tables[0].Rows)
				{
					//VPKhoa
					if(chkVPKhoa.Checked || (!chkVPKhoa.Checked&&!chkThuoc.Checked&&!chkChidinh.Checked&&!chkTU.Checked))
					{
						try
						{
							foreach(DataRow rr in m_v.get_v_vpkhoa(r["mabn"].ToString(),r["maql"].ToString(),"","0").Tables[0].Select("soluong>0 and dongia>0"))
							{
								try
								{
									DataRow r1 = ads.Tables[0].Select("mabn='"+r["mabn"].ToString()+"' and maql='"+r["maql"].ToString()+"' and mavp='"+rr["mavp"].ToString()+"' and madoituong='"+rr["madoituong"].ToString()+"' and idkhoa='"+rr["idkhoa"].ToString()+"'")[0];
									r1["mabn"]=r["mabn"].ToString();
									r1["hoten"]=r["hoten"].ToString();
									r1["namsinh"]=r["namsinh"].ToString();
									r1["diachi"]=r["diachi"].ToString();
									r1["cholam"]=r["cholam"].ToString();
									r1["sothe"]=r["sothe"].ToString();
									r1["mabv"]=r["mabv"].ToString();
									r1["maql"]=r["maql"].ToString();
									r1["idkhoa"]=rr["idkhoa"].ToString();
									r1["makp"]=rr["makp"].ToString();
									r1["tenkp"]=f_get_tenkp(rr["makp"].ToString());
									r1["ngayvv"]=r["ngayvv"].ToString();
									r1["ngayrv"]=r["ngayrv"].ToString();
									r1["ttlucrv"]=r["ttlucrv"].ToString();
									r1["ttlucrv_ten"]=r["ttlucrv_ten"].ToString();
									r1["nhomvp"]=f_get_nhomvp(rr["mavp"].ToString());
									r1["tennhomvp"]=f_get_nhomvp_ten(rr["mavp"].ToString());
									r1["loaivp"]=f_get_loaivp(rr["mavp"].ToString());
									r1["tenloaivp"]=f_get_loaivp_ten(rr["mavp"].ToString());
									r1["mavp"]=rr["mavp"].ToString();
									r1["tenvp"]=f_get_giavp(r["mavp"].ToString());
									r1["madoituong"]=rr["madoituong"].ToString();
									r1["doituong"]=f_get_doituong(rr["madoituong"].ToString());
									r1["dongia"]=(decimal.Parse(r1["soluong"].ToString())*decimal.Parse(r1["dongia"].ToString())+decimal.Parse(rr["soluong"].ToString())*decimal.Parse(rr["dongia"].ToString()))/(decimal.Parse(r1["soluong"].ToString())+decimal.Parse(rr["soluong"].ToString()));
									r1["soluong"]=decimal.Parse(r1["soluong"].ToString())+decimal.Parse(rr["soluong"].ToString());
								}
								catch//(Exception ex)
								{
									//MessageBox.Show(ex.ToString());
									DataRow r11 = ads.Tables[0].NewRow();
									r11["mabn"]=r["mabn"].ToString();
									r11["hoten"]=r["hoten"].ToString();
									r11["namsinh"]=r["namsinh"].ToString();
									r11["diachi"]=r["diachi"].ToString();
									r11["cholam"]=r["cholam"].ToString();
									r11["sothe"]=r["sothe"].ToString();
									r11["mabv"]=r["mabv"].ToString();
									r11["maql"]=r["maql"].ToString();
									r11["idkhoa"]=rr["idkhoa"].ToString();
									r11["makp"]=rr["makp"].ToString();
									r11["tenkp"]=f_get_tenkp(rr["makp"].ToString());
									r11["ngayvv"]=r["ngayvv"].ToString();
									r11["ngayrv"]=r["ngayrv"].ToString();
									r11["ttlucrv"]=r["ttlucrv"].ToString();
									r11["ttlucrv_ten"]=r["ttlucrv_ten"].ToString();
									r11["nhomvp"]=f_get_nhomvp(rr["mavp"].ToString());
									r11["tennhomvp"]=f_get_nhomvp_ten(rr["mavp"].ToString());
									r11["loaivp"]=f_get_loaivp(rr["mavp"].ToString());
									r11["tenloaivp"]=f_get_loaivp_ten(rr["mavp"].ToString());
									r11["mavp"]=rr["mavp"].ToString();
									r11["tenvp"]=f_get_giavp(rr["mavp"].ToString());
									r11["madoituong"]=rr["madoituong"].ToString();
									r11["doituong"]=f_get_doituong(rr["madoituong"].ToString());
									r11["dongia"]=decimal.Parse(rr["dongia"].ToString());
									r11["soluong"]=decimal.Parse(rr["soluong"].ToString());
									ads.Tables[0].Rows.Add(r11);
								}
							}
						}
						catch
						{
							
						}
					}

					//V_chidinh
					if(chkChidinh.Checked || (!chkVPKhoa.Checked&&!chkThuoc.Checked&&!chkChidinh.Checked&&!chkTU.Checked))
					{
						try
						{
							foreach(DataRow rr in m_v.get_v_chidinh(r["mabn"].ToString(),r["maql"].ToString(),"0","").Tables[0].Select("soluong>0 and dongia>0"))
							{
								try
								{
									DataRow r1 = ads.Tables[0].Select("mabn='"+r["mabn"].ToString()+"' and maql='"+r["maql"].ToString()+"' and mavp='"+rr["mavp"].ToString()+"' and madoituong='"+rr["madoituong"].ToString()+"' and idkhoa='"+rr["idkhoa"].ToString()+"'")[0];
									r1["mabn"]=r["mabn"].ToString();
									r1["hoten"]=r["hoten"].ToString();
									r1["namsinh"]=r["namsinh"].ToString();
									r1["diachi"]=r["diachi"].ToString();
									r1["cholam"]=r["cholam"].ToString();
									r1["sothe"]=r["sothe"].ToString();
									r1["mabv"]=r["mabv"].ToString();
									r1["maql"]=r["maql"].ToString();
									r1["idkhoa"]=rr["idkhoa"].ToString();
									r1["makp"]=rr["makp"].ToString();
									r1["tenkp"]=f_get_tenkp(rr["makp"].ToString());
									r1["ngayvv"]=r["ngayvv"].ToString();
									r1["ngayrv"]=r["ngayrv"].ToString();
									r1["ttlucrv"]=r["ttlucrv"].ToString();
									r1["ttlucrv_ten"]=r["ttlucrv_ten"].ToString();
									r1["nhomvp"]=f_get_nhomvp(rr["mavp"].ToString());
									r1["tennhomvp"]=f_get_nhomvp_ten(rr["mavp"].ToString());
									r1["loaivp"]=f_get_loaivp(rr["mavp"].ToString());
									r1["tenloaivp"]=f_get_loaivp_ten(rr["mavp"].ToString());
									r1["mavp"]=rr["mavp"].ToString();
									r1["tenvp"]=f_get_giavp(r["mavp"].ToString());
									r1["madoituong"]=rr["madoituong"].ToString();
									r1["doituong"]=f_get_doituong(rr["madoituong"].ToString());
									r1["dongia"]=(decimal.Parse(r1["soluong"].ToString())*decimal.Parse(r1["dongia"].ToString())+decimal.Parse(rr["soluong"].ToString())*decimal.Parse(rr["dongia"].ToString()))/(decimal.Parse(r1["soluong"].ToString())+decimal.Parse(rr["soluong"].ToString()));
									r1["soluong"]=decimal.Parse(r1["soluong"].ToString())+decimal.Parse(rr["soluong"].ToString());
								}
								catch
								{
									DataRow r11 = ads.Tables[0].NewRow();
									r11["mabn"]=r["mabn"].ToString();
									r11["hoten"]=r["hoten"].ToString();
									r11["namsinh"]=r["namsinh"].ToString();
									r11["diachi"]=r["diachi"].ToString();
									r11["cholam"]=r["cholam"].ToString();
									r11["sothe"]=r["sothe"].ToString();
									r11["mabv"]=r["mabv"].ToString();
									r11["maql"]=r["maql"].ToString();
									r11["idkhoa"]=rr["idkhoa"].ToString();
									r11["makp"]=rr["makp"].ToString();
									r11["tenkp"]=f_get_tenkp(rr["makp"].ToString());
									r11["ngayvv"]=r["ngayvv"].ToString();
									r11["ngayrv"]=r["ngayrv"].ToString();
									r11["ttlucrv"]=r["ttlucrv"].ToString();
									r11["ttlucrv_ten"]=r["ttlucrv_ten"].ToString();
									r11["nhomvp"]=f_get_nhomvp(rr["mavp"].ToString());
									r11["tennhomvp"]=f_get_nhomvp_ten(rr["mavp"].ToString());
									r11["loaivp"]=f_get_loaivp(rr["mavp"].ToString());
									r11["tenloaivp"]=f_get_loaivp_ten(rr["mavp"].ToString());
									r11["mavp"]=rr["mavp"].ToString();
									r11["tenvp"]=f_get_giavp(rr["mavp"].ToString());
									r11["madoituong"]=rr["madoituong"].ToString();
									r11["doituong"]=f_get_doituong(rr["madoituong"].ToString());
									r11["dongia"]=decimal.Parse(rr["dongia"].ToString());
									r11["soluong"]=decimal.Parse(rr["soluong"].ToString());
									ads.Tables[0].Rows.Add(r11);
								}
							}
						}
						catch
						{
							
						}
					}

					//d_tienthuoc
					if(chkThuoc.Checked || (!chkVPKhoa.Checked&&!chkThuoc.Checked&&!chkChidinh.Checked&&!chkTU.Checked))
					{
						try
						{
							foreach(DataRow rr in m_v.get_d_tienthuoc(r["mabn"].ToString(),r["maql"].ToString(),"","0").Tables[0].Select("soluong>0 and sotien>0"))
							{
								try
								{
									DataRow r1 = ads.Tables[0].Select("mabn='"+r["mabn"].ToString()+"' and maql='"+r["maql"].ToString()+"' and mavp='"+rr["mabd"].ToString()+"' and madoituong='"+rr["madoituong"].ToString()+"' and idkhoa='"+rr["idkhoa"].ToString()+"'")[0];
									r1["mabn"]=r["mabn"].ToString();
									r1["hoten"]=r["hoten"].ToString();
									r1["namsinh"]=r["namsinh"].ToString();
									r1["diachi"]=r["diachi"].ToString();
									r1["cholam"]=r["cholam"].ToString();
									r1["sothe"]=r["sothe"].ToString();
									r1["mabv"]=r["mabv"].ToString();
									r1["maql"]=r["maql"].ToString();
									r1["idkhoa"]=rr["idkhoa"].ToString();
									r1["makp"]=rr["makp"].ToString();
									r1["tenkp"]=f_get_tenkp(rr["makp"].ToString());
									r1["ngayvv"]=r["ngayvv"].ToString();
									r1["ngayrv"]=r["ngayrv"].ToString();
									r1["ttlucrv"]=r["ttlucrv"].ToString();
									r1["ttlucrv_ten"]=r["ttlucrv_ten"].ToString();
									r1["nhomvp"]=f_get_nhomvp(rr["mabd"].ToString());
									r1["tennhomvp"]=f_get_nhomvp_ten(rr["mabd"].ToString());
									r1["loaivp"]=f_get_loaivp(rr["mabd"].ToString());
									r1["tenloaivp"]=f_get_loaivp_ten(rr["mabd"].ToString());
									r1["mavp"]=rr["mabd"].ToString();
									r1["tenvp"]=f_get_giavp(rr["mabd"].ToString());
									r1["madoituong"]=rr["madoituong"].ToString();
									r1["doituong"]=f_get_doituong(rr["madoituong"].ToString());
									if(adoituong_giadv!="" && adoituong_giadv.IndexOf(rr["madoituong"].ToString())>=0)
									{
										r1["dongia"]=(decimal.Parse(r1["soluong"].ToString())*decimal.Parse(r1["dongia"].ToString())+decimal.Parse(rr["soluong"].ToString())*decimal.Parse(rr["giaban"].ToString()))/(decimal.Parse(r1["soluong"].ToString())+decimal.Parse(rr["soluong"].ToString()));
										r1["soluong"]=decimal.Parse(r1["soluong"].ToString())+decimal.Parse(rr["soluong"].ToString());
									}
									else
									{
										r1["dongia"]=(decimal.Parse(r1["soluong"].ToString())*decimal.Parse(r1["dongia"].ToString())+decimal.Parse(rr["sotien"].ToString()))/(decimal.Parse(r1["soluong"].ToString())+decimal.Parse(rr["soluong"].ToString()));
										r1["soluong"]=decimal.Parse(r1["soluong"].ToString())+decimal.Parse(rr["soluong"].ToString());
									}
								}
								catch
								{
									DataRow r11 = ads.Tables[0].NewRow();
									r11["mabn"]=r["mabn"].ToString();
									r11["hoten"]=r["hoten"].ToString();
									r11["namsinh"]=r["namsinh"].ToString();
									r11["diachi"]=r["diachi"].ToString();
									r11["cholam"]=r["cholam"].ToString();
									r11["sothe"]=r["sothe"].ToString();
									r11["mabv"]=r["mabv"].ToString();
									r11["maql"]=r["maql"].ToString();
									r11["idkhoa"]=rr["idkhoa"].ToString();
									r11["makp"]=rr["makp"].ToString();
									r11["tenkp"]=f_get_tenkp(rr["makp"].ToString());
									r11["ngayvv"]=r["ngayvv"].ToString();
									r11["ngayrv"]=r["ngayrv"].ToString();
									r11["ttlucrv"]=r["ttlucrv"].ToString();
									r11["ttlucrv_ten"]=r["ttlucrv_ten"].ToString();
									r11["nhomvp"]=f_get_nhomvp(rr["mabd"].ToString());
									r11["tennhomvp"]=f_get_nhomvp_ten(rr["mabd"].ToString());
									r11["loaivp"]=f_get_loaivp(rr["mabd"].ToString());
									r11["tenloaivp"]=f_get_loaivp_ten(rr["mabd"].ToString());
									r11["mavp"]=rr["mabd"].ToString();
									r11["tenvp"]=f_get_giavp(rr["mabd"].ToString());
									r11["madoituong"]=rr["madoituong"].ToString();
									r11["doituong"]=f_get_doituong(rr["madoituong"].ToString());
									if(adoituong_giadv!="" && adoituong_giadv.IndexOf(rr["madoituong"].ToString())>=0)
									{
										r11["dongia"]=decimal.Parse(rr["giaban"].ToString());
										r11["soluong"]=decimal.Parse(rr["soluong"].ToString());
									}
									else
									{
										r11["dongia"]=decimal.Parse(rr["sotien"].ToString())/decimal.Parse(rr["soluong"].ToString());
										r11["soluong"]=decimal.Parse(rr["soluong"].ToString());
									}
									ads.Tables[0].Rows.Add(r11);
								}
							}
						}
						catch
						{
							
						}
					}
					//v_tamung
					if(chkTU.Checked || (!chkVPKhoa.Checked&&!chkThuoc.Checked&&!chkChidinh.Checked&&!chkTU.Checked))
					{
						try
						{
							foreach(DataRow rr in m_v.get_v_tamung(r["mabn"].ToString(),r["maql"].ToString(),"","0","").Tables[0].Select("sotien>0"))
							{
								try
								{
									DataRow r1 = ads.Tables[0].Select("mabn='"+r["mabn"].ToString()+"' and maql='"+r["maql"].ToString()+"' and mavp='-1' and madoituong='"+rr["madoituong"].ToString()+"' and idkhoa='"+rr["idkhoa"].ToString()+"'")[0];
									r1["mabn"]=r["mabn"].ToString();
									r1["hoten"]=r["hoten"].ToString();
									r1["namsinh"]=r["namsinh"].ToString();
									r1["diachi"]=r["diachi"].ToString();
									r1["cholam"]=r["cholam"].ToString();
									r1["sothe"]=r["sothe"].ToString();
									r1["mabv"]=r["mabv"].ToString();
									r1["maql"]=r["maql"].ToString();
									r1["idkhoa"]=rr["idkhoa"].ToString();
									r1["makp"]=rr["makp"].ToString();
									r1["tenkp"]=f_get_tenkp(rr["makp"].ToString());
									r1["ngayvv"]=r["ngayvv"].ToString();
									r1["ngayrv"]=r["ngayrv"].ToString();
									r1["ttlucrv"]=r["ttlucrv"].ToString();
									r1["ttlucrv_ten"]=r["ttlucrv_ten"].ToString();
									r1["nhomvp"]="-1";
									r1["tennhomvp"]="Tạm ứng";
									r1["loaivp"]="-1";
									r1["tenloaivp"]="Tạm ứng";
									r1["mavp"]="-1";
									r1["tenvp"]="Tạm ứng";
									r1["madoituong"]=rr["madoituong"].ToString();
									r1["doituong"]=f_get_doituong(rr["madoituong"].ToString());
									r1["dongia"]=(decimal.Parse(r1["dongia"].ToString())+decimal.Parse(rr["sotien"].ToString()));
									r1["soluong"]=1;
								}
								catch//(Exception ex)
								{
									//MessageBox.Show(ex.ToString());
									DataRow r11 = ads.Tables[0].NewRow();
									r11["mabn"]=r["mabn"].ToString();
									r11["hoten"]=r["hoten"].ToString();
									r11["namsinh"]=r["namsinh"].ToString();
									r11["diachi"]=r["diachi"].ToString();
									r11["cholam"]=r["cholam"].ToString();
									r11["sothe"]=r["sothe"].ToString();
									r11["mabv"]=r["mabv"].ToString();
									r11["maql"]=r["maql"].ToString();
									r11["idkhoa"]=rr["idkhoa"].ToString();
									r11["makp"]=rr["makp"].ToString();
									r11["tenkp"]=f_get_tenkp(rr["makp"].ToString());
									r11["ngayvv"]=r["ngayvv"].ToString();
									r11["ngayrv"]=r["ngayrv"].ToString();
									r11["ttlucrv"]=r["ttlucrv"].ToString();
									r11["ttlucrv_ten"]=r["ttlucrv_ten"].ToString();
									r11["nhomvp"]="-1";
									r11["tennhomvp"]="Tạm ứng";
									r11["loaivp"]="-1";
									r11["tenloaivp"]="Tạm ứng";
									r11["mavp"]="-1";
									r11["tenvp"]="Tạm ứng";
									r11["madoituong"]=rr["madoituong"].ToString();
									r11["doituong"]=f_get_doituong(rr["madoituong"].ToString());
									r11["dongia"]=decimal.Parse(rr["sotien"].ToString());
									r11["soluong"]=1;
									ads.Tables[0].Rows.Add(r11);
								}
							}
						}
						catch//(Exception ex)
						{
							//MessageBox.Show(ex.ToString());
						}
					}
				}

				if((ads == null)||ads.Tables[0].Rows.Count<=0)
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
				crystalReportViewer1.BringToFront();
				crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;

				string areport="",asyt="",abv="",angayin="",anguoiin="",aghichu="";
				areport="v_bangkechuathanhtoan_loai.rpt";
				asyt = m_v.Syte;
				abv = m_v.Tenbv;
				angayin ="Ngày " + txtNgayIn.Value.Day.ToString().PadLeft(2,'0') + " tháng " + txtNgayIn.Value.Month.ToString().PadLeft(2,'0') + " năm " + txtNgayIn.Value.Year.ToString();
				anguoiin = txtNguoilapbang.Text.Trim();
				aghichu = f_Get_GhiChu();
				switch(groupBox1.Tag.ToString())
				{
					default:
						areport="v_bangkechuathanhtoan.rpt";
						break;
				}
				if(menuItem1.Checked)
				{
					ads.WriteXml("..//..//Datareport//v_"+areport.Replace(".rpt","")+".xml", XmlWriteMode.WriteSchema);
				}
				ReportDocument cMain=new ReportDocument();
				cMain.Load("..\\..\\..\\report\\"+areport, OpenReportMethod.OpenReportByTempCopy);
				cMain.SetDataSource(ads);
				cMain.DataDefinition.FormulaFields["v_syt"].Text="'"+asyt.ToUpper()+"'";
				cMain.DataDefinition.FormulaFields["v_bv"].Text="'"+abv.ToUpper()+"'";
				cMain.DataDefinition.FormulaFields["v_ngayin"].Text="'"+angayin+"'";
				cMain.DataDefinition.FormulaFields["v_nguoiin"].Text="'"+anguoiin+"'";
				cMain.DataDefinition.FormulaFields["v_ghichu"].Text="'"+aghichu+"'";
				cMain.DataDefinition.FormulaFields["v_nguoilapbang"].Text="'"+txtNguoilapbang.Text.Trim()+"'";
				cMain.PrintOptions.PaperSize=CrystalDecisions.Shared.PaperSize.PaperA4; 
				cMain.PrintOptions.PaperOrientation=CrystalDecisions.Shared.PaperOrientation.Landscape; 
				crystalReportViewer1.ReportSource=cMain;
				af.Text=af.Text+" ("+areport+")";
				af.ShowDialog();
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}
		private void f_SaveHistory()
		{
			try
			{
				DataSet ads = new DataSet();
				ads.Tables.Add("Bangkehoantra");
				ads.Tables[0].Columns.Add("nguoilapbang");
				ads.Tables[0].Rows.Add(new string[] {txtNguoilapbang.Text.Trim()});
				ads.WriteXml("...//...//option//v_optionbangketronvien.xml",XmlWriteMode.WriteSchema);
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
			}
			try
			{
				DataSet ads = new DataSet();
				ads.ReadXml("...//...//option//v_optionbangketronvien.xml");
				txtNguoilapbang.Text=txtNguoilapbang.Tag.ToString();//ads.Tables[0].Rows[0]["nguoilapbang"].ToString();
				//txtNguoilapbang.Text=ads.Tables[0].Rows[0]["nguoilapbang"].ToString();
			}
			catch
			{
			}
		}
		private void butInBK_Click(object sender, System.EventArgs e)
		{	
			progressBar1.Value=1;
			timer1.Enabled=true;
			butInBK.Enabled=false;
			this.Cursor=Cursors.WaitCursor;
			try
			{
				f_SaveHistory();
				f_InBK_1();
			}
			catch
			{
			}
			butInBK.Enabled=true;
			this.Cursor=Cursors.Default;
			progressBar1.Value=0;
			timer1.Enabled=false;
		}
		private void txtTN_Validated(object sender, System.EventArgs e)
		{
			try
			{
				DateTime ad1 = new DateTime(txtTN.Value.Year,txtTN.Value.Month,txtTN.Value.Day);
				DateTime ad2 = new DateTime(txtDN.Value.Year,txtDN.Value.Month,txtDN.Value.Day);
				if(ad1>ad2)
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
				DateTime ad1 = new DateTime(txtTN.Value.Year,txtTN.Value.Month,txtTN.Value.Day);
				DateTime ad2 = new DateTime(txtDN.Value.Year,txtDN.Value.Month,txtDN.Value.Day);
				if(ad1>ad2)
				{
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
				if(ad1==ad2)
				{
					r=
lan.Change_language_MessageText("(Ngày")+" " + ad1.Day.ToString().PadLeft(2,'0') + "/" + ad1.Month.ToString().PadLeft(2,'0') + "/" +ad1.Year.ToString() + ")";
				}
				else
				{
					r=
lan.Change_language_MessageText("(Từ ngày")+" " + ad1.Day.ToString().PadLeft(2,'0') + "/" + ad1.Month.ToString().PadLeft(2,'0') + "/" +ad1.Year.ToString() + " đến ngày " + ad2.Day.ToString().PadLeft(2,'0') + "/" + ad2.Month.ToString().PadLeft(2,'0') + "/" +ad2.Year.ToString() + ")";
				}
				return r;
			}
			catch
			{
				return "";
			}
		}
		private void txtNgayIn_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
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

		private void frmBaocaochiphichuathanhtoan_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			try
			{
			}
			catch
			{
			}
		}

		private void txtNguoilapbang_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
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

		private void frmBaocaochiphichuathanhtoan_SizeChanged(object sender, System.EventArgs e)
		{
		}

		private void chkKP_CheckedChanged(object sender, System.EventArgs e)
		{
			f_Set_CheckID(tree_Khoa,chkKP.Checked);
		}

		private void tree_Khoa_AfterCheck(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			try
			{
				e.Node.ForeColor=e.Node.Checked?Color.Navy:Color.DimGray;
				for(int i=0;i<tree_Khoa.Nodes.Count;i++)
				{
					if(tree_Khoa.Nodes[i].Checked)
					{
						return;
					}
				}
				chkKP.Checked=false;
			}
			catch
			{
			}

		}

		private void chkDoituong_CheckedChanged(object sender, System.EventArgs e)
		{
			f_Set_CheckID(tree_Doituong,chkDoituong.Checked);
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

		private void chkKP_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			try
			{
				if(e.KeyCode==Keys.Enter)
				{
					tree_Khoa.Focus();
				}
			}
			catch
			{
			}
		}

		private void tree_Khoa_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			try
			{
				if(e.KeyCode==Keys.Enter)
				{
					chkDoituong.Focus();
				}
			}
			catch
			{
			}
		}

		private void chkDoituong_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			try
			{
				if(e.KeyCode==Keys.Enter)
				{
					tree_Doituong.Focus();
				}
			}
			catch
			{
			}
		}

		private void tree_Doituong_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			try
			{
				if(e.KeyCode==Keys.Enter)
				{
					chkTTXK.Focus();
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
				//if(rd1.Checked) groupBox1.Tag="1";
				//if(rd2.Checked) groupBox1.Tag="2";
			}
			catch
			{
			}
		}

		private void chkXV_CheckedChanged(object sender, System.EventArgs e)
		{
			try
			{
				bool b = chkXV.Checked || (!chkXV.Checked && !chkCXV.Checked) || (chkXV.Checked && chkCXV.Checked);

				tree_TTXK.Enabled=b;
				chkTTXK.Enabled=b;

				tree_Khoa.Enabled=b;
				chkKP.Enabled=b;

				txtTN.Enabled=b;
				txtDN.Enabled=b;

				if(b)
				{
					lbKP.SendToBack();
					lbTT.SendToBack();
				}
				else
				{
					lbKP.BringToFront();
					lbTT.BringToFront();
				}
			}
			catch
			{
			}
		}

		private void chkTTXK_CheckedChanged(object sender, System.EventArgs e)
		{
			f_Set_CheckID(tree_TTXK,chkTTXK.Checked);
		}

		private void chkTTXK_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			try
			{
				if(e.KeyCode==Keys.Enter)
				{
					tree_TTXK.Focus();
				}
			}
			catch
			{
			}
		}

		private void tree_TTXK_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			try
			{
				if(e.KeyCode==Keys.Enter)
				{
					txtTN.Focus();
				}
			}
			catch
			{
			}
		}

	}
}
