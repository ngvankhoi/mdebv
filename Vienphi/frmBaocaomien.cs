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
	/// Summary description for frmBaocaomien.
	/// </summary>
	public class frmBaocaomien : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private string m_userid="";
		private LibVP.AccessData m_v = LibVP.AccessData.GetImplement();
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
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtNguoilapbang;
		private System.Windows.Forms.TextBox txtKetoanvp;
		private System.Windows.Forms.TextBox txtPhongtckt;
		private System.Windows.Forms.TreeView tree_User;
		private System.Windows.Forms.TreeView tree_Kymien;
		private System.Windows.Forms.CheckBox chkKymien;
		private System.Windows.Forms.ComboBox cbMaubaocao;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TreeView tree_Loaibn;
		private System.Windows.Forms.CheckBox chkLoaibn;
		private System.Windows.Forms.CheckBox chkTructiep;
		private System.Windows.Forms.CheckBox chkThanhtoanravien;
		private System.Windows.Forms.TreeView tree_Lydomien;
		private System.Windows.Forms.CheckBox chkLydomien;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.ContextMenu contextMenu2;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem6;
		private System.Windows.Forms.MenuItem menuItem4;
        private TreeView tree_doituong;
        private CheckBox checkBox1;
        private CheckBox chkMiengiam;
        private CheckBox chkHaophi;
		private System.ComponentModel.IContainer components;

		public frmBaocaomien(string v_userid)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBaocaomien));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbTitle = new System.Windows.Forms.Label();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label15 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkTructiep = new System.Windows.Forms.CheckBox();
            this.chkThanhtoanravien = new System.Windows.Forms.CheckBox();
            this.tree_Lydomien = new System.Windows.Forms.TreeView();
            this.chkLydomien = new System.Windows.Forms.CheckBox();
            this.cbMaubaocao = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tree_doituong = new System.Windows.Forms.TreeView();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.tree_Loaibn = new System.Windows.Forms.TreeView();
            this.chkLoaibn = new System.Windows.Forms.CheckBox();
            this.tree_Kymien = new System.Windows.Forms.TreeView();
            this.tree_User = new System.Windows.Forms.TreeView();
            this.contextMenu2 = new System.Windows.Forms.ContextMenu();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.txtPhongtckt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtKetoanvp = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNguoilapbang = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.butInBK = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.txtNgayIn = new System.Windows.Forms.DateTimePicker();
            this.chkUserid = new System.Windows.Forms.CheckBox();
            this.txtDN = new System.Windows.Forms.DateTimePicker();
            this.txtTN = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chkKymien = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.chkHaophi = new System.Windows.Forms.CheckBox();
            this.chkMiengiam = new System.Windows.Forms.CheckBox();
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
            this.panel1.Size = new System.Drawing.Size(592, 49);
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
            this.lbTitle.Size = new System.Drawing.Size(353, 45);
            this.lbTitle.TabIndex = 15;
            this.lbTitle.Text = "  BÁO CÁO MIỄN GIẢM";
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
            this.label15.Size = new System.Drawing.Size(592, 3);
            this.label15.TabIndex = 17;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.chkMiengiam);
            this.panel2.Controls.Add(this.chkHaophi);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.tree_Lydomien);
            this.panel2.Controls.Add(this.chkLydomien);
            this.panel2.Controls.Add(this.cbMaubaocao);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.tree_doituong);
            this.panel2.Controls.Add(this.checkBox1);
            this.panel2.Controls.Add(this.tree_Loaibn);
            this.panel2.Controls.Add(this.chkLoaibn);
            this.panel2.Controls.Add(this.tree_Kymien);
            this.panel2.Controls.Add(this.tree_User);
            this.panel2.Controls.Add(this.txtPhongtckt);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txtKetoanvp);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtNguoilapbang);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.butInBK);
            this.panel2.Controls.Add(this.butKetthuc);
            this.panel2.Controls.Add(this.txtNgayIn);
            this.panel2.Controls.Add(this.chkUserid);
            this.panel2.Controls.Add(this.txtDN);
            this.panel2.Controls.Add(this.txtTN);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.chkKymien);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.ForeColor = System.Drawing.Color.Navy;
            this.panel2.Location = new System.Drawing.Point(3, 55);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(592, 343);
            this.panel2.TabIndex = 18;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkTructiep);
            this.groupBox1.Controls.Add(this.chkThanhtoanravien);
            this.groupBox1.Location = new System.Drawing.Point(443, 147);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(141, 80);
            this.groupBox1.TabIndex = 206;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chứng từ";
            // 
            // chkTructiep
            // 
            this.chkTructiep.Location = new System.Drawing.Point(9, 22);
            this.chkTructiep.Name = "chkTructiep";
            this.chkTructiep.Size = new System.Drawing.Size(95, 18);
            this.chkTructiep.TabIndex = 202;
            this.chkTructiep.TabStop = false;
            this.chkTructiep.Text = "Thu trực tiếp";
            // 
            // chkThanhtoanravien
            // 
            this.chkThanhtoanravien.Location = new System.Drawing.Point(9, 47);
            this.chkThanhtoanravien.Name = "chkThanhtoanravien";
            this.chkThanhtoanravien.Size = new System.Drawing.Size(119, 18);
            this.chkThanhtoanravien.TabIndex = 203;
            this.chkThanhtoanravien.TabStop = false;
            this.chkThanhtoanravien.Text = "Thanh toán ra viện";
            // 
            // tree_Lydomien
            // 
            this.tree_Lydomien.CheckBoxes = true;
            this.tree_Lydomien.ForeColor = System.Drawing.Color.DimGray;
            this.tree_Lydomien.FullRowSelect = true;
            this.tree_Lydomien.Location = new System.Drawing.Point(5, 244);
            this.tree_Lydomien.Name = "tree_Lydomien";
            this.tree_Lydomien.ShowLines = false;
            this.tree_Lydomien.ShowPlusMinus = false;
            this.tree_Lydomien.ShowRootLines = false;
            this.tree_Lydomien.Size = new System.Drawing.Size(138, 90);
            this.tree_Lydomien.Sorted = true;
            this.tree_Lydomien.TabIndex = 205;
            this.tree_Lydomien.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tree_Lydomien_AfterCheck);
            // 
            // chkLydomien
            // 
            this.chkLydomien.Location = new System.Drawing.Point(5, 227);
            this.chkLydomien.Name = "chkLydomien";
            this.chkLydomien.Size = new System.Drawing.Size(130, 18);
            this.chkLydomien.TabIndex = 204;
            this.chkLydomien.TabStop = false;
            this.chkLydomien.Text = "Lý do miển giảm";
            this.chkLydomien.CheckedChanged += new System.EventHandler(this.chkLydomien_CheckedChanged);
            // 
            // cbMaubaocao
            // 
            this.cbMaubaocao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMaubaocao.Location = new System.Drawing.Point(364, 313);
            this.cbMaubaocao.Name = "cbMaubaocao";
            this.cbMaubaocao.Size = new System.Drawing.Size(219, 21);
            this.cbMaubaocao.TabIndex = 200;
            // 
            // label11
            // 
            this.label11.ForeColor = System.Drawing.Color.Navy;
            this.label11.Location = new System.Drawing.Point(290, 317);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(74, 13);
            this.label11.TabIndex = 201;
            this.label11.Text = "Mẫu báo cáo";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tree_doituong
            // 
            this.tree_doituong.CheckBoxes = true;
            this.tree_doituong.ForeColor = System.Drawing.Color.DimGray;
            this.tree_doituong.FullRowSelect = true;
            this.tree_doituong.Location = new System.Drawing.Point(290, 119);
            this.tree_doituong.Name = "tree_doituong";
            this.tree_doituong.ShowLines = false;
            this.tree_doituong.ShowPlusMinus = false;
            this.tree_doituong.ShowRootLines = false;
            this.tree_doituong.Size = new System.Drawing.Size(135, 108);
            this.tree_doituong.Sorted = true;
            this.tree_doituong.TabIndex = 187;
            this.tree_doituong.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tree_Loaibn_AfterCheck);
            // 
            // checkBox1
            // 
            this.checkBox1.Location = new System.Drawing.Point(292, 98);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(130, 15);
            this.checkBox1.TabIndex = 186;
            this.checkBox1.TabStop = false;
            this.checkBox1.Text = "Loại bệnh nhân";
            this.checkBox1.CheckedChanged += new System.EventHandler(this.chkLoaibn_CheckedChanged);
            // 
            // tree_Loaibn
            // 
            this.tree_Loaibn.CheckBoxes = true;
            this.tree_Loaibn.ForeColor = System.Drawing.Color.DimGray;
            this.tree_Loaibn.FullRowSelect = true;
            this.tree_Loaibn.Location = new System.Drawing.Point(149, 244);
            this.tree_Loaibn.Name = "tree_Loaibn";
            this.tree_Loaibn.ShowLines = false;
            this.tree_Loaibn.ShowPlusMinus = false;
            this.tree_Loaibn.ShowRootLines = false;
            this.tree_Loaibn.Size = new System.Drawing.Size(135, 90);
            this.tree_Loaibn.Sorted = true;
            this.tree_Loaibn.TabIndex = 187;
            this.tree_Loaibn.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tree_Loaibn_AfterCheck);
            // 
            // chkLoaibn
            // 
            this.chkLoaibn.Location = new System.Drawing.Point(151, 227);
            this.chkLoaibn.Name = "chkLoaibn";
            this.chkLoaibn.Size = new System.Drawing.Size(130, 18);
            this.chkLoaibn.TabIndex = 186;
            this.chkLoaibn.TabStop = false;
            this.chkLoaibn.Text = "Loại bệnh nhân";
            this.chkLoaibn.CheckedChanged += new System.EventHandler(this.chkLoaibn_CheckedChanged);
            // 
            // tree_Kymien
            // 
            this.tree_Kymien.CheckBoxes = true;
            this.tree_Kymien.ForeColor = System.Drawing.Color.DimGray;
            this.tree_Kymien.FullRowSelect = true;
            this.tree_Kymien.Location = new System.Drawing.Point(5, 153);
            this.tree_Kymien.Name = "tree_Kymien";
            this.tree_Kymien.ShowLines = false;
            this.tree_Kymien.ShowPlusMinus = false;
            this.tree_Kymien.ShowRootLines = false;
            this.tree_Kymien.Size = new System.Drawing.Size(279, 74);
            this.tree_Kymien.Sorted = true;
            this.tree_Kymien.TabIndex = 183;
            this.tree_Kymien.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tree_Kymien_AfterCheck);
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
            this.tree_User.Size = new System.Drawing.Size(279, 115);
            this.tree_User.Sorted = true;
            this.tree_User.TabIndex = 182;
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
            // txtPhongtckt
            // 
            this.txtPhongtckt.BackColor = System.Drawing.Color.White;
            this.txtPhongtckt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhongtckt.Location = new System.Drawing.Point(364, 290);
            this.txtPhongtckt.MaxLength = 50;
            this.txtPhongtckt.Name = "txtPhongtckt";
            this.txtPhongtckt.Size = new System.Drawing.Size(219, 21);
            this.txtPhongtckt.TabIndex = 7;
            this.txtPhongtckt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPhongtckt_KeyDown);
            // 
            // label5
            // 
            this.label5.ForeColor = System.Drawing.Color.Navy;
            this.label5.Location = new System.Drawing.Point(282, 296);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 13);
            this.label5.TabIndex = 153;
            this.label5.Text = "Phòng TCKT";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtKetoanvp
            // 
            this.txtKetoanvp.BackColor = System.Drawing.Color.White;
            this.txtKetoanvp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKetoanvp.Location = new System.Drawing.Point(364, 267);
            this.txtKetoanvp.MaxLength = 50;
            this.txtKetoanvp.Name = "txtKetoanvp";
            this.txtKetoanvp.Size = new System.Drawing.Size(219, 21);
            this.txtKetoanvp.TabIndex = 6;
            this.txtKetoanvp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtKetoanvp_KeyDown);
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.Color.Navy;
            this.label4.Location = new System.Drawing.Point(282, 272);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 151;
            this.label4.Text = "Kế toán VP";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNguoilapbang
            // 
            this.txtNguoilapbang.BackColor = System.Drawing.Color.White;
            this.txtNguoilapbang.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNguoilapbang.Location = new System.Drawing.Point(364, 244);
            this.txtNguoilapbang.MaxLength = 50;
            this.txtNguoilapbang.Name = "txtNguoilapbang";
            this.txtNguoilapbang.Size = new System.Drawing.Size(219, 21);
            this.txtNguoilapbang.TabIndex = 5;
            this.txtNguoilapbang.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNguoilapbang_KeyDown);
            // 
            // label10
            // 
            this.label10.ForeColor = System.Drawing.Color.Navy;
            this.label10.Location = new System.Drawing.Point(282, 248);
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
            this.butInBK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butInBK.ForeColor = System.Drawing.Color.Navy;
            this.butInBK.Image = ((System.Drawing.Image)(resources.GetObject("butInBK.Image")));
            this.butInBK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butInBK.Location = new System.Drawing.Point(362, 64);
            this.butInBK.Name = "butInBK";
            this.butInBK.Size = new System.Drawing.Size(116, 28);
            this.butInBK.TabIndex = 3;
            this.butInBK.Text = "     &In bảng kê";
            this.butInBK.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butInBK.UseVisualStyleBackColor = true;
            this.butInBK.Click += new System.EventHandler(this.butInBK_Click);
            this.butInBK.KeyDown += new System.Windows.Forms.KeyEventHandler(this.butInBK_KeyDown);
            // 
            // butKetthuc
            // 
            this.butKetthuc.BackColor = System.Drawing.SystemColors.Control;
            this.butKetthuc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butKetthuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butKetthuc.ForeColor = System.Drawing.Color.Navy;
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(478, 64);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(108, 28);
            this.butKetthuc.TabIndex = 4;
            this.butKetthuc.Text = "      &Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.txtNgayIn.TabIndex = 2;
            this.txtNgayIn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNgayIn_KeyDown);
            // 
            // chkUserid
            // 
            this.chkUserid.Location = new System.Drawing.Point(5, 4);
            this.chkUserid.Name = "chkUserid";
            this.chkUserid.Size = new System.Drawing.Size(138, 18);
            this.chkUserid.TabIndex = 8;
            this.chkUserid.TabStop = false;
            this.chkUserid.Text = "Nhân viên thu ngân";
            this.chkUserid.CheckedChanged += new System.EventHandler(this.chkUserid_CheckedChanged);
            this.chkUserid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkUserid_KeyDown);
            // 
            // txtDN
            // 
            this.txtDN.CustomFormat = "dd/MM/yyyy hh:mm";
            this.txtDN.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtDN.Location = new System.Drawing.Point(499, 20);
            this.txtDN.Name = "txtDN";
            this.txtDN.Size = new System.Drawing.Size(85, 20);
            this.txtDN.TabIndex = 1;
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
            this.txtTN.TabIndex = 0;
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
            // chkKymien
            // 
            this.chkKymien.Location = new System.Drawing.Point(5, 136);
            this.chkKymien.Name = "chkKymien";
            this.chkKymien.Size = new System.Drawing.Size(130, 18);
            this.chkKymien.TabIndex = 10;
            this.chkKymien.TabStop = false;
            this.chkKymien.Text = "Người ký miễn";
            this.chkKymien.CheckedChanged += new System.EventHandler(this.chkKymien_CheckedChanged);
            this.chkKymien.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkQuyenSo_KeyDown);
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
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label6.Location = new System.Drawing.Point(3, 398);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(592, 4);
            this.label6.TabIndex = 216;
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(3, 402);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(592, 20);
            this.progressBar1.TabIndex = 215;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // chkHaophi
            // 
            this.chkHaophi.Location = new System.Drawing.Point(455, 117);
            this.chkHaophi.Name = "chkHaophi";
            this.chkHaophi.Size = new System.Drawing.Size(130, 15);
            this.chkHaophi.TabIndex = 207;
            this.chkHaophi.TabStop = false;
            this.chkHaophi.Text = "Miễn - Hao phí";
            // 
            // chkMiengiam
            // 
            this.chkMiengiam.Checked = true;
            this.chkMiengiam.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMiengiam.Location = new System.Drawing.Point(456, 98);
            this.chkMiengiam.Name = "chkMiengiam";
            this.chkMiengiam.Size = new System.Drawing.Size(130, 15);
            this.chkMiengiam.TabIndex = 208;
            this.chkMiengiam.TabStop = false;
            this.chkMiengiam.Text = "Duyệt miễn";
            // 
            // frmBaocaomien
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(598, 425);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmBaocaomien";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Báo cáo miễn giảm";
            this.Load += new System.EventHandler(this.frmBaocaomien_Load);
            this.SizeChanged += new System.EventHandler(this.frmBaocaomien_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmBaocaomien_KeyDown);
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
				DataSet ads = m_v.get_data("select to_char(id) as id, hoten from medibv.v_dlogin where to_char(id)='"+ m_userid + "'");
				txtNguoilapbang.Tag=ads.Tables[0].Rows[0]["hoten"].ToString();
			}
			catch
			{
				txtNguoilapbang.Tag="";
			}
			this.Text=this.Text+"/"+txtNguoilapbang.Tag.ToString().Trim();
		}
		private void frmBaocaomien_Load(object sender, System.EventArgs e)
		{
			try
			{
				txtNgayIn.Value=System.DateTime.Now;
				txtTN.Value=System.DateTime.Now;
				txtDN.Value=System.DateTime.Now;
				f_Display_User();
				f_Load_CB_Maubaocao();
				f_Load_Tree_Userid();
				f_Load_Tree_Kymien();
				f_Load_Tree_Loaibn();
				f_Load_Tree_Lydomien();
                f_load_doituong();
				f_LoadHistory();
			}
			catch
			{
			}
		}
        private void f_load_doituong()
        {
            try
            {
                string sql = "select madoituong as ma,doituong as ten from medibv.doituong order by madoituong,doituong";
                f_Load_Tree(tree_doituong, m_v.get_data(sql));
            }
            catch
            { }
        }
		private void f_Load_Tree_Userid()
		{
			try
			{
				string sql = "select to_char(id) as ma, hoten as ten from medibv.v_dlogin order by hoten asc";
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
		private void f_Load_Tree_Kymien()
		{
			try
			{
				string sql = "select ma, ten from medibv.v_dsduyet order by ten asc";
				f_Load_Tree(tree_Kymien,m_v.get_data(sql));
			}
			catch
			{
			}
		}
		private void f_Load_Tree_Loaibn()
		{
			try
			{
				string sql = "select to_char(id) as ma, ten from medibv.v_loaibn order by id";
				DataSet ads = m_v.get_data(sql);
				f_Load_Tree(tree_Loaibn,ads);
			}
			catch
			{
			}
		}
		private void f_Load_Tree_Lydomien()
		{
			try
			{
				string sql = "select to_char(id) as ma, ten from medibv.v_lydomien order by id";
				DataSet ads = m_v.get_data(sql);
				f_Load_Tree(tree_Lydomien,ads);
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


        private string f_Get_Doituong(TreeView v_tree)
        {
            try
            {
                string r = "";
                for (int i = 0; i < v_tree.Nodes.Count; i++)
                {
                    if (v_tree.Nodes[i].Checked) r = r.Trim().Trim(',') + "," + v_tree.Nodes[i].Tag.ToString();
                }
                r = r.Trim().Trim(',');
                
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
				ads = m_v.get_data("select ma, ten from medibv.v_maubaocao where loai=4");
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
		private void f_InBK_1()
		{
			try
			{
				DataSet ads = new DataSet();
				string sql="", aexp="";
				string auserid = f_Get_CheckID(tree_User);
				string akymien= f_Get_CheckID(tree_Kymien);
				string aloaibn= f_Get_CheckID(tree_Loaibn);
				string alydomien= f_Get_CheckID(tree_Lydomien);
                string adoituong = f_Get_Doituong(tree_doituong);

				if(auserid.Length>0)
				{
					if(aexp.Length>0)
					{
						aexp=aexp+ " and aa.userid in("+ auserid+")";
					}
					else
					{
						aexp="aa.userid in("+ auserid+")";
					}
				}

				if(akymien.Length>0)
				{
					if(aexp.Length>0)
					{
						aexp=aexp+ " and aaa.maduyet in("+ akymien+")";
					}
					else
					{
						aexp="aaa.maduyet in("+ akymien+")";
					}
				}
				
				if(aloaibn.Length>0)
				{
					if(aexp.Length>0)
					{
						aexp=aexp+ " and aa.loaibn in("+ aloaibn+")";
					}
					else
					{
						aexp="aa.loaibn in("+ aloaibn+")";
					}
				}
				if(alydomien.Length>0)
				{
					if(aexp.Length>0)
					{
						aexp=aexp+ " and nvl(aaa.lydo,0) in("+ alydomien+")";
					}
					else
					{
						aexp="nvl(aaa.lydo,0) in("+ alydomien+")";
					}
				}

                if (adoituong.Length > 0)
                {
                    if (aexp.Length > 0)
                    {
                        aexp = aexp + " and aaaa.madoituong in("+adoituong+")";
                    }
                    else
                    {
                        aexp = " aaaa.madoituong in("+adoituong+")";
                    }
                }
                if (chkHaophi.Checked == false && chkMiengiam.Checked)
                {
                    if (aexp.Length > 0)
                    {
                        aexp += " and i.id is not null ";//null: la hao phi; not null la mien
                    }
                    else
                    {
                        aexp = " i.id is not null ";//null: la hao phi; not null la mien
                    }
                }
                else if (chkHaophi.Checked && chkMiengiam.Checked==false)
                {
                    if (aexp.Length > 0)
                    {
                        aexp += " and i.id is null ";//null: la hao phi; not null la mien
                    }
                    else
                    {
                        aexp = " i.id is null ";//null: la hao phi; not null la mien
                    }

                }
                //
                if(aexp.Trim().Length>0)
				{
					aexp=" and "+ aexp.Trim();
				}
				
				if((chkTructiep.Checked&&chkThanhtoanravien.Checked)||(!chkTructiep.Checked&&!chkThanhtoanravien.Checked))
				{
					//Thu trực tiếp
                    sql = "select '1_'||to_char(aa.id) id, aa.mabn, b.hoten, to_char(b.ngaysinh,'dd/mm/yyyy') ngaysinh, b.namsinh, trim(trim(b.sonha)|| trim(b.thon)) diachi, bb.tentt tinh, bbb.tenquan quan, bbbb.tenpxa xa, g.sothe mabhyt, aa.sobienlai, nvl(aaa.sotien,0) mien, sum(aaaa.soluong*aaaa.dongia-aaaa.thieu-to_number(decode(aaaa.madoituong,1,aaaa.mien,0))) sotien, to_char(aa.ngay,'dd/mm/yyyy') ngay, c.sohieu quyenso, aa.quyenso quyensoid, e.makp, e.tenkp, to_char(h.ma) maduyet, h.ten nguoikyduyet, to_char(i.id) lydomien, i.ten tenlydomien, aaa.ghichu ghichumien, f.hoten nguoithu, f.hoten ||' ('||to_char(f.userid)||')' userid, to_char(aa.loaibn) loaibn, '1' loaithu from medibvmmyy.v_vienphill aa, medibvmmyy.v_mienngtru aaa, medibvmmyy.v_vienphict aaaa, medibv.btdbn b, medibv.btdtt bb, medibv.btdquan bbb, medibv.btdpxa bbbb, medibv.v_quyenso c, medibv.btdkp_bv e, medibv.v_dlogin f, medibvmmyy.bhyt g, medibv.v_dsduyet h, medibv.v_lydomien i where aa.id=aaa.id and aa.id=aaaa.id and b.mabn(+)=aa.mabn and bb.matt(+)=b.matt and bbb.maqu(+)=b.maqu and bbbb.maphuongxa(+)=b.maphuongxa and c.id(+)=aa.quyenso and e.makp(+)=aa.makp and f.id(+)=aa.userid and g.maql(+)=aa.maql and h.ma(+)=aaa.maduyet and i.id(+)=aaa.lydo and to_date(to_char(aa.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('" + txtTN.Text.Trim().Substring(0, 10) + "','dd/mm/yyyy') and to_date(to_char(aa.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')<=to_date('" + txtDN.Text.Trim().Substring(0, 10) + "','dd/mm/yyyy') " + aexp + "  group by '1_'||to_char(aa.id), aa.mabn, b.hoten, to_char(b.ngaysinh,'dd/mm/yyyy'), b.namsinh, trim(trim(b.sonha)|| trim(b.thon)), bb.tentt, bbb.tenquan, bbbb.tenpxa, g.sothe, aa.sobienlai, nvl(aaa.sotien,0), to_char(aa.ngay,'dd/mm/yyyy'), c.sohieu, aa.quyenso, e.makp, e.tenkp, to_char(h.ma), h.ten, to_char(i.id), i.ten, aaa.ghichu, f.hoten, f.hoten ||' ('||to_char(f.userid)||')', to_char(aa.loaibn) order by c.sohieu, aa.sobienlai";
                    ads = m_v.get_data_mmyy(sql, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true);

					//Nội trú + Ngoại trú
                    sql = "select '2_'||to_char(a.id) id, a.mabn, b.hoten, to_char(b.ngaysinh,'dd/mm/yyyy') ngaysinh, b.namsinh, trim(trim(b.sonha)|| trim(b.thon)) diachi, bb.tentt tinh, bbb.tenquan quan, bbbb.tenpxa xa, g.sothe mabhyt, aa.sobienlai, nvl(aa.mien,0) mien, (nvl(aa.sotien,0)-nvl(aa.bhyt,0)) sotien , to_char(aa.ngay,'dd/mm/yyyy') ngay, c.sohieu quyenso, aa.quyenso quyensoid, e.makp, e.tenkp, to_char(h.ma) maduyet, h.ten nguoikyduyet, to_char(i.id) lydomien, i.ten tenlydomien, aaa.ghichu ghichumien, f.hoten nguoithu, f.hoten ||' ('||to_char(f.userid)||')' userid, to_char(aa.loaibn) loaibn, '2' loaithu from medibvmmyy.v_ttrvds a, medibvmmyy.v_ttrvll aa, medibvmmyy.v_miennoitru aaa, medibv.btdbn b, medibv.btdtt bb, medibv.btdquan bbb, medibv.btdpxa bbbb, medibv.v_quyenso c, medibv.btdkp_bv e, medibv.v_dlogin f, medibvmmyy.bhyt g, medibv.v_dsduyet h, medibv.v_lydomien i where a.id=aa.id and a.id=aaa.id and b.mabn(+)=a.mabn and bb.matt(+)=b.matt and bbb.maqu(+)=b.maqu and bbbb.maphuongxa(+)=b.maphuongxa and c.id(+)=aa.quyenso and e.makp(+)=aa.makp and f.id(+)=aa.userid and g.maql(+)=a.maql and h.ma(+)=aaa.maduyet and i.id(+)=aaa.lydo and to_date(to_char(aa.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('" + txtTN.Text.Trim().Substring(0, 10) + "','dd/mm/yyyy') and to_date(to_char(aa.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')<=to_date('" + txtDN.Text.Trim().Substring(0, 10) + "','dd/mm/yyyy') " + aexp + "";                    
                    sql += " order by c.sohieu, aa.sobienlai";
                    if (ads != null && ads.Tables.Count > 0 && ads.Tables[0].Rows.Count > 0)
                    {
                        ads.Merge(m_v.get_data_mmyy(sql, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true));
                    }
                    else
                    {
                        ads = m_v.get_data_mmyy(sql, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true);
                    }
				}
				else
					if(chkTructiep.Checked)
				{
					//Thu trực tiếp
                    sql = "select '1_'||to_char(aa.id) id, aa.mabn, b.hoten, to_char(b.ngaysinh,'dd/mm/yyyy') ngaysinh, b.namsinh, trim(trim(b.sonha)|| trim(b.thon)) diachi, bb.tentt tinh, bbb.tenquan quan, bbbb.tenpxa xa, g.sothe mabhyt, aa.sobienlai, nvl(aaa.sotien,0) mien, sum(aaaa.soluong*aaaa.dongia-aaaa.thieu-to_number(decode(aaaa.madoituong,1,aaaa.mien,0))) sotien, to_char(aa.ngay,'dd/mm/yyyy') ngay, c.sohieu quyenso, aa.quyenso quyensoid, e.makp, e.tenkp, to_char(h.ma) maduyet, h.ten nguoikyduyet, to_char(i.id) lydomien, i.ten tenlydomien, aaa.ghichu ghichumien, f.hoten nguoithu, f.hoten ||' ('||to_char(f.userid)||')' userid, to_char(aa.loaibn) loaibn, '1' loaithu from medibvmmyy.v_vienphill aa, medibvmmyy.v_mienngtru aaa, medibvmmyy.v_vienphict aaaa, medibv.btdbn b, medibv.btdtt bb, medibv.btdquan bbb, medibv.btdpxa bbbb, medibv.v_quyenso c, medibv.btdkp_bv e, medibv.v_dlogin f, medibvmmyy.bhyt g, medibv.v_dsduyet h, medibv.v_lydomien i where aa.id=aaa.id and aa.id=aaaa.id and b.mabn(+)=aa.mabn and bb.matt(+)=b.matt and bbb.maqu(+)=b.maqu and bbbb.maphuongxa(+)=b.maphuongxa and c.id(+)=aa.quyenso and e.makp(+)=aa.makp and f.id(+)=aa.userid and g.maql(+)=aa.maql and h.ma(+)=aaa.maduyet and i.id(+)=aaa.lydo and to_date(to_char(aa.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('" + txtTN.Text.Trim().Substring(0, 10) + "','dd/mm/yyyy') and to_date(to_char(aa.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')<=to_date('" + txtDN.Text.Trim().Substring(0, 10) + "','dd/mm/yyyy') " + aexp + "  group by '1_'||to_char(aa.id), aa.mabn, b.hoten, to_char(b.ngaysinh,'dd/mm/yyyy'), b.namsinh, trim(trim(b.sonha)|| trim(b.thon)), bb.tentt, bbb.tenquan, bbbb.tenpxa, g.sothe, aa.sobienlai, nvl(aaa.sotien,0), to_char(aa.ngay,'dd/mm/yyyy'), c.sohieu, aa.quyenso, e.makp, e.tenkp, to_char(h.ma), h.ten, to_char(i.id), i.ten, aaa.ghichu, f.hoten, f.hoten ||' ('||to_char(f.userid)||')', to_char(aa.loaibn) order by c.sohieu, aa.sobienlai";
                    ads = m_v.get_data_mmyy(sql, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true);
				}
				else
					if(chkThanhtoanravien.Checked)
				{
					//Nội trú + Ngoại trú
                    sql = "select '2_'||to_char(a.id) id, a.mabn, b.hoten, to_char(b.ngaysinh,'dd/mm/yyyy') ngaysinh, b.namsinh, trim(trim(b.sonha)|| trim(b.thon)) diachi, bb.tentt tinh, bbb.tenquan quan, bbbb.tenpxa xa, g.sothe mabhyt, aa.sobienlai, nvl(aa.mien,0) mien, (nvl(aa.sotien,0)-nvl(aa.bhyt,0)) sotien , to_char(aa.ngay,'dd/mm/yyyy') ngay, c.sohieu quyenso, aa.quyenso quyensoid, e.makp, e.tenkp, to_char(h.ma) maduyet, h.ten nguoikyduyet, to_char(i.id) lydomien, i.ten tenlydomien, aaa.ghichu ghichumien, f.hoten nguoithu, f.hoten ||' ('||to_char(f.userid)||')' userid, to_char(aa.loaibn) loaibn, '2' loaithu from medibvmmyy.v_ttrvds a, medibvmmyy.v_ttrvll aa, medibvmmyy.v_miennoitru aaa, medibv.btdbn b, medibv.btdtt bb, medibv.btdquan bbb, medibv.btdpxa bbbb, medibv.v_quyenso c, medibv.btdkp_bv e, medibv.v_dlogin f, medibv.bhyt g, medibv.v_dsduyet h, medibv.v_lydomien i where a.id=aa.id and a.id=aaa.id and b.mabn(+)=a.mabn and bb.matt(+)=b.matt and bbb.maqu(+)=b.maqu and bbbb.maphuongxa(+)=b.maphuongxa and c.id(+)=aa.quyenso and e.makp(+)=aa.makp and f.id(+)=aa.userid and g.maql(+)=a.maql and h.ma(+)=aaa.maduyet and i.id(+)=aaa.lydo and to_date(to_char(aa.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('" + txtTN.Text.Trim().Substring(0, 10) + "','dd/mm/yyyy') and to_date(to_char(aa.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')<=to_date('" + txtDN.Text.Trim().Substring(0, 10) + "','dd/mm/yyyy') " + aexp + " order by c.sohieu, aa.sobienlai";                    
                    ads = m_v.get_data_mmyy(sql, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true);
				}

				if(ads.Tables[0].Rows.Count<=0)
				{
					progressBar1.Value=progressBar1.Maximum;
					timer1.Enabled=false;
					progressBar1.Value=0;
					MessageBox.Show(this,lan.Change_language_MessageText("Không có dữ liệu báo cáo"),m_v.s_AppName,MessageBoxButtons.OK,MessageBoxIcon.Information);
					return;
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
				crystalReportViewer1.BringToFront();
				crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;

				string areport="",asyt="",abv="",angayin="",anguoiin="",aghichu="";
				areport="v_bangkemiengiam.rpt";
				asyt = m_v.Syte;
				abv = m_v.Tenbv;
				angayin =
                lan.Change_language_MessageText("Ngày")+" " + txtNgayIn.Value.Day.ToString().PadLeft(2,'0') + " "+
                lan.Change_language_MessageText("tháng")+" " + txtNgayIn.Value.Month.ToString().PadLeft(2,'0') + " "+
                lan.Change_language_MessageText("năm")+" " + txtNgayIn.Value.Year.ToString();
				anguoiin = txtNguoilapbang.Text.Trim();
				aghichu = f_Get_GhiChu();

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
				cMain.DataDefinition.FormulaFields["v_ketoanvp"].Text="'"+txtKetoanvp.Text.Trim()+"'";
				cMain.DataDefinition.FormulaFields["v_phongtckt"].Text="'"+txtPhongtckt.Text.Trim()+"'";

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
				ads.Tables[0].Columns.Add("ketoanvp");
				ads.Tables[0].Columns.Add("phongtckt");
				ads.Tables[0].Rows.Add(new string[] {txtNguoilapbang.Text.Trim(),txtKetoanvp.Text.Trim(),txtPhongtckt.Text.Trim()});
				ads.WriteXml("...//...//option//v_optionbangkemiengiam.xml",XmlWriteMode.WriteSchema);
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
				ads.ReadXml("...//...//option//v_optionbangkemiengiam.xml");
				txtNguoilapbang.Text=txtNguoilapbang.Tag.ToString();//ads.Tables[0].Rows[0]["nguoilapbang"].ToString();
				txtKetoanvp.Text=ads.Tables[0].Rows[0]["ketoanvp"].ToString();
				txtPhongtckt.Text=ads.Tables[0].Rows[0]["phongtckt"].ToString();
			}
			catch
			{
			}
		}
		private void butInBK_Click(object sender, System.EventArgs e)
		{	
			string atmp = System.Environment.CurrentDirectory;
			try
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

		private void frmBaocaomien_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			try
			{
				if(e.KeyCode==Keys.F12)
				{
					txtKetoanvp.Enabled=!txtKetoanvp.Enabled;
					txtPhongtckt.Enabled=!txtPhongtckt.Enabled;
				}
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

		private void frmBaocaomien_SizeChanged(object sender, System.EventArgs e)
		{
		}

		private void chkUserid_CheckedChanged(object sender, System.EventArgs e)
		{
			f_Set_CheckID(tree_User,chkUserid.Checked);
		}

		private void tree_User_AfterCheck(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			try
			{
				e.Node.ForeColor=e.Node.Checked?Color.Navy:Color.DimGray;
				for(int i=0;i<tree_User.Nodes.Count;i++)
				{
					if(tree_User.Nodes[i].Checked)
					{
						return;
					}
				}
				chkUserid.Checked=false;
			}
			catch
			{
			}

		}

		private void chkKymien_CheckedChanged(object sender, System.EventArgs e)
		{
			f_Set_CheckID(tree_Kymien,chkKymien.Checked);
		}

		private void chkLoaibn_CheckedChanged(object sender, System.EventArgs e)
		{
			f_Set_CheckID(tree_Loaibn,chkLoaibn.Checked);
		}

		private void tree_Kymien_AfterCheck(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			try
			{
				e.Node.ForeColor=e.Node.Checked?Color.Navy:Color.DimGray;
				for(int i=0;i<tree_Kymien.Nodes.Count;i++)
				{
					if(tree_Kymien.Nodes[i].Checked)
					{
						return;
					}
				}
				chkKymien.Checked=false;
			}
			catch
			{
			}
		}

		private void tree_Loaibn_AfterCheck(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			try
			{
				e.Node.ForeColor=e.Node.Checked?Color.Navy:Color.DimGray;
				for(int i=0;i<tree_Loaibn.Nodes.Count;i++)
				{
					if(tree_Loaibn.Nodes[i].Checked)
					{
						return;
					}
				}
				chkLoaibn.Checked=false;
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

        private void chkLydomien_CheckedChanged(object sender, EventArgs e)
        {
            f_Set_CheckID(tree_Lydomien, chkLydomien.Checked);
        }

        private void tree_Lydomien_AfterCheck(object sender, TreeViewEventArgs e)
        {
            try
            {
                e.Node.ForeColor = e.Node.Checked ? Color.Navy : Color.DimGray;
                for (int i = 0; i < tree_Lydomien.Nodes.Count; i++)
                {
                    if (tree_Lydomien.Nodes[i].Checked)
                    {
                        return;
                    }
                }
                chkLydomien.Checked = false;
            }
            catch
            {
            }
        }
	}
}
