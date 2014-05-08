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
	/// Summary description for frmBaocaothutamung.
	/// </summary>
	public class frmBaocaothutamung : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private string m_userid="";
		private string m_ngaythu="";
		private string m_field_dt="";
		private DataSet m_ds2=new DataSet();
		private DataSet m_dsdt=new DataSet();
		private LibVP.AccessData m_v = new LibVP.AccessData();
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label lbTitle;
		private System.Windows.Forms.Label lbNgayDN;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label lbNguoiDN;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button butKetthuc;
		private System.Windows.Forms.DateTimePicker txtDN;
		private System.Windows.Forms.DateTimePicker txtTN;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.DateTimePicker txtNgayIn;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox chkAll1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button butExcel;
		private System.Windows.Forms.Button butWeb;
		private System.Windows.Forms.CheckBox chkAll;
		private System.Windows.Forms.RadioButton rd2;
		private System.Windows.Forms.RadioButton rd1;
		private System.Windows.Forms.RadioButton rd3;
		private System.Windows.Forms.CheckBox chkAll2;
		private System.Windows.Forms.TreeView tree_KP;
		private System.Windows.Forms.TreeView tree_Doituong;
		private System.Windows.Forms.TreeView tree_Field;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.TreeView tree_User;
		private System.Windows.Forms.CheckBox chkUserid;
		private System.Windows.Forms.ContextMenu contextMenu2;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem6;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.TextBox timso;
		private System.Windows.Forms.TreeView tree_Quyenso;
		private System.Windows.Forms.RadioButton rd4;
		private System.ComponentModel.IContainer components;

		public frmBaocaothutamung(string v_userid)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
			m_userid=v_userid;
			f_SetEvent(panel2);
			f_SetEvent(groupBox1);

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBaocaothutamung));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbTitle = new System.Windows.Forms.Label();
            this.lbNgayDN = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbNguoiDN = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.butWeb = new System.Windows.Forms.Button();
            this.tree_Quyenso = new System.Windows.Forms.TreeView();
            this.timso = new System.Windows.Forms.TextBox();
            this.tree_User = new System.Windows.Forms.TreeView();
            this.contextMenu2 = new System.Windows.Forms.ContextMenu();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.chkUserid = new System.Windows.Forms.CheckBox();
            this.tree_Field = new System.Windows.Forms.TreeView();
            this.tree_KP = new System.Windows.Forms.TreeView();
            this.tree_Doituong = new System.Windows.Forms.TreeView();
            this.chkAll2 = new System.Windows.Forms.CheckBox();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.butExcel = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rd4 = new System.Windows.Forms.RadioButton();
            this.rd3 = new System.Windows.Forms.RadioButton();
            this.rd2 = new System.Windows.Forms.RadioButton();
            this.rd1 = new System.Windows.Forms.RadioButton();
            this.txtTN = new System.Windows.Forms.DateTimePicker();
            this.txtNgayIn = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDN = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.chkAll1 = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
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
            this.panel1.Controls.Add(this.lbNgayDN);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.lbNguoiDN);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(1);
            this.panel1.Size = new System.Drawing.Size(615, 49);
            this.panel1.TabIndex = 15;
            // 
            // lbTitle
            // 
            this.lbTitle.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbTitle.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.Color.White;
            this.lbTitle.Location = new System.Drawing.Point(71, 1);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(345, 45);
            this.lbTitle.TabIndex = 15;
            this.lbTitle.Text = "  BÁO CÁO THU TẠM ỨNG";
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbNgayDN
            // 
            this.lbNgayDN.ForeColor = System.Drawing.Color.White;
            this.lbNgayDN.Location = new System.Drawing.Point(350, 26);
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
            this.lbNguoiDN.ForeColor = System.Drawing.Color.White;
            this.lbNguoiDN.Location = new System.Drawing.Point(350, 6);
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
            this.label15.Size = new System.Drawing.Size(615, 3);
            this.label15.TabIndex = 17;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.butWeb);
            this.panel2.Controls.Add(this.tree_Quyenso);
            this.panel2.Controls.Add(this.timso);
            this.panel2.Controls.Add(this.tree_User);
            this.panel2.Controls.Add(this.chkUserid);
            this.panel2.Controls.Add(this.tree_Field);
            this.panel2.Controls.Add(this.tree_KP);
            this.panel2.Controls.Add(this.tree_Doituong);
            this.panel2.Controls.Add(this.chkAll2);
            this.panel2.Controls.Add(this.chkAll);
            this.panel2.Controls.Add(this.butExcel);
            this.panel2.Controls.Add(this.butKetthuc);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.chkAll1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.ForeColor = System.Drawing.Color.Navy;
            this.panel2.Location = new System.Drawing.Point(3, 55);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(615, 363);
            this.panel2.TabIndex = 18;
            // 
            // butWeb
            // 
            this.butWeb.BackColor = System.Drawing.SystemColors.Control;
            this.butWeb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butWeb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butWeb.ForeColor = System.Drawing.Color.Navy;
            this.butWeb.Image = ((System.Drawing.Image)(resources.GetObject("butWeb.Image")));
            this.butWeb.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butWeb.Location = new System.Drawing.Point(513, 32);
            this.butWeb.Name = "butWeb";
            this.butWeb.Size = new System.Drawing.Size(93, 28);
            this.butWeb.TabIndex = 10;
            this.butWeb.Text = "      &Web";
            this.butWeb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butWeb.UseVisualStyleBackColor = true;
            this.butWeb.Click += new System.EventHandler(this.butWeb_Click);
            // 
            // tree_Quyenso
            // 
            this.tree_Quyenso.CheckBoxes = true;
            this.tree_Quyenso.ForeColor = System.Drawing.Color.DimGray;
            this.tree_Quyenso.FullRowSelect = true;
            this.tree_Quyenso.Location = new System.Drawing.Point(201, 90);
            this.tree_Quyenso.Name = "tree_Quyenso";
            this.tree_Quyenso.ShowLines = false;
            this.tree_Quyenso.ShowPlusMinus = false;
            this.tree_Quyenso.ShowRootLines = false;
            this.tree_Quyenso.Size = new System.Drawing.Size(124, 137);
            this.tree_Quyenso.Sorted = true;
            this.tree_Quyenso.TabIndex = 2;
            // 
            // timso
            // 
            this.timso.BackColor = System.Drawing.Color.White;
            this.timso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timso.Location = new System.Drawing.Point(6, 228);
            this.timso.MaxLength = 12;
            this.timso.Name = "timso";
            this.timso.Size = new System.Drawing.Size(319, 21);
            this.timso.TabIndex = 207;
            this.timso.Text = "Tìm sổ";
            this.timso.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.timso.TextChanged += new System.EventHandler(this.timso_TextChanged);
            // 
            // tree_User
            // 
            this.tree_User.CheckBoxes = true;
            this.tree_User.ContextMenu = this.contextMenu2;
            this.tree_User.ForeColor = System.Drawing.Color.DimGray;
            this.tree_User.FullRowSelect = true;
            this.tree_User.Location = new System.Drawing.Point(6, 90);
            this.tree_User.Name = "tree_User";
            this.tree_User.ShowLines = false;
            this.tree_User.ShowPlusMinus = false;
            this.tree_User.ShowRootLines = false;
            this.tree_User.Size = new System.Drawing.Size(319, 137);
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
            this.chkUserid.Location = new System.Drawing.Point(6, 74);
            this.chkUserid.Name = "chkUserid";
            this.chkUserid.Size = new System.Drawing.Size(220, 17);
            this.chkUserid.TabIndex = 0;
            this.chkUserid.TabStop = false;
            this.chkUserid.Text = "Nhân viên thu ngân (Quyển sổ)";
            this.chkUserid.CheckedChanged += new System.EventHandler(this.chkUserid_CheckedChanged);
            // 
            // tree_Field
            // 
            this.tree_Field.BackColor = System.Drawing.Color.White;
            this.tree_Field.CheckBoxes = true;
            this.tree_Field.ForeColor = System.Drawing.Color.DimGray;
            this.tree_Field.FullRowSelect = true;
            this.tree_Field.Location = new System.Drawing.Point(327, 90);
            this.tree_Field.Name = "tree_Field";
            this.tree_Field.ShowLines = false;
            this.tree_Field.ShowPlusMinus = false;
            this.tree_Field.ShowRootLines = false;
            this.tree_Field.Size = new System.Drawing.Size(278, 159);
            this.tree_Field.TabIndex = 6;
            this.tree_Field.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tree_Field_AfterCheck);
            // 
            // tree_KP
            // 
            this.tree_KP.CheckBoxes = true;
            this.tree_KP.ForeColor = System.Drawing.Color.DimGray;
            this.tree_KP.FullRowSelect = true;
            this.tree_KP.Location = new System.Drawing.Point(6, 268);
            this.tree_KP.Name = "tree_KP";
            this.tree_KP.ShowLines = false;
            this.tree_KP.ShowPlusMinus = false;
            this.tree_KP.ShowRootLines = false;
            this.tree_KP.Size = new System.Drawing.Size(319, 86);
            this.tree_KP.Sorted = true;
            this.tree_KP.TabIndex = 4;
            this.tree_KP.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tree_KP_AfterCheck);
            // 
            // tree_Doituong
            // 
            this.tree_Doituong.CheckBoxes = true;
            this.tree_Doituong.ForeColor = System.Drawing.Color.DimGray;
            this.tree_Doituong.FullRowSelect = true;
            this.tree_Doituong.Location = new System.Drawing.Point(327, 268);
            this.tree_Doituong.Name = "tree_Doituong";
            this.tree_Doituong.ShowLines = false;
            this.tree_Doituong.ShowPlusMinus = false;
            this.tree_Doituong.ShowRootLines = false;
            this.tree_Doituong.Size = new System.Drawing.Size(278, 86);
            this.tree_Doituong.Sorted = true;
            this.tree_Doituong.TabIndex = 8;
            this.tree_Doituong.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tree_Doituong_AfterCheck);
            // 
            // chkAll2
            // 
            this.chkAll2.Location = new System.Drawing.Point(6, 250);
            this.chkAll2.Name = "chkAll2";
            this.chkAll2.Size = new System.Drawing.Size(98, 21);
            this.chkAll2.TabIndex = 3;
            this.chkAll2.Text = " Khoa phòng";
            this.chkAll2.CheckedChanged += new System.EventHandler(this.chkAll2_CheckedChanged);
            this.chkAll2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkAll2_KeyDown);
            // 
            // chkAll
            // 
            this.chkAll.Location = new System.Drawing.Point(327, 247);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(278, 26);
            this.chkAll.TabIndex = 7;
            this.chkAll.Text = " Đối tượng";
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            this.chkAll.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkAll_KeyDown_1);
            // 
            // butExcel
            // 
            this.butExcel.BackColor = System.Drawing.SystemColors.Control;
            this.butExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butExcel.ForeColor = System.Drawing.Color.Navy;
            this.butExcel.Image = ((System.Drawing.Image)(resources.GetObject("butExcel.Image")));
            this.butExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butExcel.Location = new System.Drawing.Point(513, 4);
            this.butExcel.Name = "butExcel";
            this.butExcel.Size = new System.Drawing.Size(93, 28);
            this.butExcel.TabIndex = 9;
            this.butExcel.Text = "      &Excel";
            this.butExcel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butExcel.UseVisualStyleBackColor = true;
            this.butExcel.Click += new System.EventHandler(this.butExcel_Click);
            this.butExcel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.butExcel_KeyDown);
            // 
            // butKetthuc
            // 
            this.butKetthuc.BackColor = System.Drawing.SystemColors.Control;
            this.butKetthuc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butKetthuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butKetthuc.ForeColor = System.Drawing.Color.Red;
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(513, 60);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(93, 28);
            this.butKetthuc.TabIndex = 11;
            this.butKetthuc.Text = "      &Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.UseVisualStyleBackColor = true;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            this.butKetthuc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.butKetthuc_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rd4);
            this.groupBox1.Controls.Add(this.rd3);
            this.groupBox1.Controls.Add(this.rd2);
            this.groupBox1.Controls.Add(this.rd1);
            this.groupBox1.Controls.Add(this.txtTN);
            this.groupBox1.Controls.Add(this.txtNgayIn);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtDN);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(6, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(501, 62);
            this.groupBox1.TabIndex = 153;
            this.groupBox1.TabStop = false;
            // 
            // rd4
            // 
            this.rd4.Location = new System.Drawing.Point(288, 36);
            this.rd4.Name = "rd4";
            this.rd4.Size = new System.Drawing.Size(104, 17);
            this.rd4.TabIndex = 9;
            this.rd4.Text = "Theo người thu";
            this.rd4.CheckedChanged += new System.EventHandler(this.rd3_CheckedChanged);
            // 
            // rd3
            // 
            this.rd3.Location = new System.Drawing.Point(186, 36);
            this.rd3.Name = "rd3";
            this.rd3.Size = new System.Drawing.Size(96, 17);
            this.rd3.TabIndex = 8;
            this.rd3.Text = "Theo khoa";
            this.rd3.CheckedChanged += new System.EventHandler(this.rd3_CheckedChanged);
            // 
            // rd2
            // 
            this.rd2.Location = new System.Drawing.Point(101, 36);
            this.rd2.Name = "rd2";
            this.rd2.Size = new System.Drawing.Size(82, 17);
            this.rd2.TabIndex = 7;
            this.rd2.Text = "Theo ngày";
            this.rd2.CheckedChanged += new System.EventHandler(this.rd2_CheckedChanged);
            this.rd2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rd2_KeyDown);
            // 
            // rd1
            // 
            this.rd1.Checked = true;
            this.rd1.Location = new System.Drawing.Point(10, 36);
            this.rd1.Name = "rd1";
            this.rd1.Size = new System.Drawing.Size(94, 17);
            this.rd1.TabIndex = 6;
            this.rd1.TabStop = true;
            this.rd1.Text = "Theo biên lai";
            this.rd1.CheckedChanged += new System.EventHandler(this.rd1_CheckedChanged);
            this.rd1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rd1_KeyDown);
            // 
            // txtTN
            // 
            this.txtTN.CustomFormat = "dd/MM/yyyy hh:mm";
            this.txtTN.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtTN.Location = new System.Drawing.Point(64, 10);
            this.txtTN.Name = "txtTN";
            this.txtTN.Size = new System.Drawing.Size(85, 20);
            this.txtTN.TabIndex = 1;
            this.txtTN.Validated += new System.EventHandler(this.txtTN_Validated);
            this.txtTN.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTN_KeyDown);
            // 
            // txtNgayIn
            // 
            this.txtNgayIn.CustomFormat = "dd/MM/yyyy hh:mm";
            this.txtNgayIn.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtNgayIn.Location = new System.Drawing.Point(376, 10);
            this.txtNgayIn.Name = "txtNgayIn";
            this.txtNgayIn.Size = new System.Drawing.Size(85, 20);
            this.txtNgayIn.TabIndex = 5;
            this.txtNgayIn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNgayIn_KeyDown);
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(11, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Từ ngày";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(309, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Ngày in";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDN
            // 
            this.txtDN.CustomFormat = "dd/MM/yyyy hh:mm";
            this.txtDN.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtDN.Location = new System.Drawing.Point(217, 10);
            this.txtDN.Name = "txtDN";
            this.txtDN.Size = new System.Drawing.Size(85, 20);
            this.txtDN.TabIndex = 3;
            this.txtDN.Validated += new System.EventHandler(this.txtDN_Validated);
            this.txtDN.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDN_KeyDown);
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(165, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Đến ngày";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkAll1
            // 
            this.chkAll1.Checked = true;
            this.chkAll1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAll1.Location = new System.Drawing.Point(327, 74);
            this.chkAll1.Name = "chkAll1";
            this.chkAll1.Size = new System.Drawing.Size(117, 17);
            this.chkAll1.TabIndex = 5;
            this.chkAll1.Text = "Thông tin hiển thị";
            this.chkAll1.CheckedChanged += new System.EventHandler(this.chkAll1_CheckedChanged);
            this.chkAll1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkAll1_KeyDown);
            // 
            // label11
            // 
            this.label11.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label11.Location = new System.Drawing.Point(3, 418);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(615, 4);
            this.label11.TabIndex = 212;
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(3, 422);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(615, 20);
            this.progressBar1.TabIndex = 211;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmBaocaothutamung
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(621, 445);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBaocaothutamung";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Báo cáo thu tạm ứng";
            this.Load += new System.EventHandler(this.frmBaocaothutamung_Load);
            this.SizeChanged += new System.EventHandler(this.frmBaocaothutamung_SizeChanged);
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
		private void f_Display_User()
		{
			try
			{
				DataSet ads = m_v.get_data("select to_char(id) id, hoten from medibv.v_dlogin where to_char(id)='"+ m_userid + "'");
				lbNguoiDN.Text="" + ads.Tables[0].Rows[0]["hoten"].ToString();
				lbNgayDN.Text=lan.Change_language_MessageText("Ngày:")+" " + f_Cur_Date();
			}
			catch
			{
				MessageBox.Show(this,lan.Change_language_MessageText("Chưa đăng nhập. Chỉ có quyền xem thông tin"),m_v.s_AppName,MessageBoxButtons.OK,MessageBoxIcon.Warning);
				lbNguoiDN.Text="<????>";
				lbNgayDN.Text=lan.Change_language_MessageText("Ngày:")+" "+f_Cur_Date();
			}
			this.Text=this.Text+"/"+lbNguoiDN.Text.Trim();
			lbNguoiDN.Visible=false;
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

		private void f_Load_Tree_Field()
		{
			try
			{
				DataSet ads = new DataSet();
				ads.Tables.Add("Table");
				ads.Tables[0].Columns.Add("MA");
				ads.Tables[0].Columns.Add("TEN");
				if(rd1.Checked)
				{
					ads.Tables[0].Rows.Add(new string[] {"MABN",lan.Change_language_MessageText("Mã BN")});
					ads.Tables[0].Rows.Add(new string[] {"HOTEN",lan.Change_language_MessageText("Họ và tên")});
					ads.Tables[0].Rows.Add(new string[] {"NAMSINH",lan.Change_language_MessageText("Năm sinh")});
					ads.Tables[0].Rows.Add(new string[] {"DIACHI",lan.Change_language_MessageText("Địa chỉ")});
					ads.Tables[0].Rows.Add(new string[] {"CHOLAM",lan.Change_language_MessageText("Chổ làm")});
					ads.Tables[0].Rows.Add(new string[] {"NGAY",lan.Change_language_MessageText("Ngày thu")});
					ads.Tables[0].Rows.Add(new string[] {"QUYENSO",lan.Change_language_MessageText("Quyển sổ")});
					ads.Tables[0].Rows.Add(new string[] {"SOBIENLAI",lan.Change_language_MessageText("Số biên lai")});
					ads.Tables[0].Rows.Add(new string[] {"SOCHUNGTU",lan.Change_language_MessageText("Số chứng từ")});
					ads.Tables[0].Rows.Add(new string[] {"SOTIEN",lan.Change_language_MessageText("Số tiền")});
					ads.Tables[0].Rows.Add(new string[] {"DOITUONG",lan.Change_language_MessageText("Đối tượng")});
					ads.Tables[0].Rows.Add(new string[] {"KHOA",lan.Change_language_MessageText("Khoa")});
					ads.Tables[0].Rows.Add(new string[] {"NGUOITHU",lan.Change_language_MessageText("Nhân viên thu ngân")});
				}
				else
					if(rd2.Checked)
				{
					ads.Tables[0].Rows.Add(new string[] {"NGAY",lan.Change_language_MessageText("Ngày thu")});
					ads.Tables[0].Rows.Add(new string[] {"SOHOADON",lan.Change_language_MessageText("Tổng hoá đơn")});
					ads.Tables[0].Rows.Add(new string[] {"SOTIEN",lan.Change_language_MessageText("Tổng số tiền")});
					foreach(DataRow r in m_dsdt.Tables[0].Rows)
					{
						ads.Tables[0].Rows.Add(new string[] {"DOITUONG_"+r["ma"].ToString(),lan.Change_language_MessageText("Trong đó:")+" "+r["ten"].ToString()});
					}
				}
				else
					if(rd3.Checked)
				{
					ads.Tables[0].Rows.Add(new string[] {"NGAY",lan.Change_language_MessageText("Mã KP")});
					ads.Tables[0].Rows.Add(new string[] {"TENKP",lan.Change_language_MessageText("Tên khoa phòng")});
					ads.Tables[0].Rows.Add(new string[] {"SOHOADON",lan.Change_language_MessageText("Tổng hoá đơn")});
					ads.Tables[0].Rows.Add(new string[] {"SOTIEN",lan.Change_language_MessageText("Tổng số tiền")});
					foreach(DataRow r in m_dsdt.Tables[0].Rows)
					{
						ads.Tables[0].Rows.Add(new string[] {"DOITUONG_"+r["ma"].ToString(),lan.Change_language_MessageText("Trong đó:")+" "+r["ten"].ToString()});
					}
				}
				else
					if(rd4.Checked)
				{
					ads.Tables[0].Rows.Add(new string[] {"NGAY",lan.Change_language_MessageText("Tên đăng nhập")});
					ads.Tables[0].Rows.Add(new string[] {"NGUOITHU",lan.Change_language_MessageText("Họ tên nhân viên thu ngân")});
					ads.Tables[0].Rows.Add(new string[] {"SOHOADON",lan.Change_language_MessageText("Tổng hoá đơn")});
					ads.Tables[0].Rows.Add(new string[] {"SOTIEN",lan.Change_language_MessageText("Tổng số tiền")});
					foreach(DataRow r in m_dsdt.Tables[0].Rows)
					{
						ads.Tables[0].Rows.Add(new string[] {lan.Change_language_MessageText("DOITUONG_")+r["ma"].ToString(),lan.Change_language_MessageText("Trong đó:")+" "+r["ten"].ToString()});
					}
				}
				f_Load_Tree(tree_Field,ads);
				f_Set_CheckID(tree_Field,chkAll1.Checked);
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		private void f_Load_Tree_Doituong()
		{
			try
			{
				string sql = "select to_char(madoituong) as ma, doituong as ten from medibv.doituong order by madoituong asc";
				m_dsdt=m_v.get_data(sql);
				f_Load_Tree(tree_Doituong,m_dsdt);
				f_Set_CheckID(tree_Doituong,chkAll.Checked);
				m_field_dt="";
				foreach(DataRow r in m_dsdt.Tables[0].Rows)
				{
					m_field_dt+=" ,sum(nvl(to_number(decode(a.madoituong,"+r["ma"].ToString()+",a.sotien,0)),0)) doituong_"+r["ma"].ToString();
				}
			}
			catch
			{
			}
		}

		private void f_Load_Tree_Khoa()
		{
			try
			{
				string sql = "select to_char(makp) as ma, tenkp as ten from medibv.btdkp_bv where loai= 0 order by tenkp asc";
				f_Load_Tree(tree_KP,m_v.get_data(sql));
				f_Set_CheckID(tree_KP,chkAll2.Checked);
			}
			catch
			{
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
                    if (m_v.sys_Loctheonguoidangnhap && m_v.get_data("select admin from medibv.v_dlogin where id=" + m_userid).Tables[0].Rows[0][0].ToString() == "0")
                    {
                        if (aexp != "")
                            aexp += " and id =" + m_userid + "";
                        else aexp += " id =" + m_userid + "";
                    }
                    if (aexp != "")
                    {
                        aexp = " where " + aexp;
                    }
					string sql = "select to_char(a.id) as ma, trim(a.sohieu)||'     ('||to_char(a.tu)||' -->'||to_char(a.den)|| ')' as ten, to_char(b.id) as mar, trim(b.hoten)||' ('||b.userid||')' as tenr from medibv.v_quyenso a left join medibv.v_dlogin b on b.id=a.userid(+)"+aexp+" order by b.id, b.hoten";
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
				toolTip1.SetToolTip(tree_Quyenso,lan.Change_language_MessageText("Ký hiệu biên lai"));
			}
			catch
			{
			}
		}
		private void f_Load_tree_User1()
		{
			try
			{
				string sql = "select to_char(id) as ma, trim(hoten)||' ('||userid||')' as ten from medibv.v_dlogin ";
                if (m_v.sys_Loctheonguoidangnhap && m_v.get_data("select admin from medibv.v_dlogin where id=" + m_userid).Tables[0].Rows[0][0].ToString() == "0") sql += " where id =" + m_userid + "";
                sql += " order by hoten";
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
		private void frmBaocaothutamung_Load(object sender, System.EventArgs e)
		{
			try
			{
				txtNgayIn.Value=System.DateTime.Now;
				txtTN.Value=System.DateTime.Now;//.AddMonths(-1);
				txtDN.Value=System.DateTime.Now;
				f_Display_User();
				f_Load_Tree_Doituong();
				f_Load_Tree_Khoa();
				f_Load_Tree_Field();
				f_Load_Tree_Userid();
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
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
					//SendKeys.Send("{Tab}{F4}");
					butExcel.Focus();
				}
			}
			catch
			{
			}
		}
		private void Export_Excel(System.Data.DataSet v_ds, string v_filepath)
		{
			try
			{
				System.IO.StreamWriter sw  =  new System.IO.StreamWriter(v_filepath,false,System.Text.Encoding.UTF8);
				string astr="";
				astr="<Table border=1>";
				astr=astr + "<tr>";
				for(int i=0;i<v_ds.Tables[0].Columns.Count;i++)
				{
					astr=astr + "<th>";
					astr=astr + v_ds.Tables[0].Columns[i].ColumnName;
					astr=astr + "</th>";
				}
				astr=astr + "</tr>";
				sw.Write(astr);
				for(int i=0;i<v_ds.Tables[0].Rows.Count;i++)
				{
					astr="<tr>";
					for(int j=0;j<v_ds.Tables[0].Columns.Count;j++)
					{
						astr=astr + "<td>";
						astr=astr + v_ds.Tables[0].Rows[i][j].ToString();
						astr=astr + "</td>";
					}
					astr=astr + "</tr>";
					sw.Write(astr);
				}
				astr="</Table>";
				sw.Write(astr);
				
				sw.Close();
				MessageBox.Show("OK");
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}
		private void f_Ketxuat(string v_format)
		{
			try
			{
				string sql="",exp="";
				string amadoituong=f_Get_CheckID(tree_Doituong);
				string akhoa=f_Get_CheckID(tree_KP);
				string auserid=f_Get_CheckID(tree_User,1);
				string aquyenso=f_Get_CheckID(tree_User,2);
				string asqlht="select * from medibvmmyy.v_hoantra where to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('"+ txtTN.Text.Trim().Substring(0,10) +"','dd/mm/yyyy') and to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy')<=to_date('"+ txtDN.Text.Trim().Substring(0,10) +"','dd/mm/yyyy')";
				if(m_v.sys_dungchungso)
				{
					auserid = f_Get_CheckID(tree_User);
					aquyenso = f_Get_CheckID(tree_Quyenso);
				}

				DataSet ads = new DataSet();
				m_ds2 = new DataSet();
				m_ds2.Tables.Add("Tables");
				m_ds2.Tables[0].Columns.Add("MA");
				m_ds2.Tables[0].Columns.Add("TEN");
				//Cac field se hien thi
				for(int i=0;i<tree_Field.Nodes.Count;i++)
				{
					if(tree_Field.Nodes[i].Checked)
					{
						try
						{
							m_ds2.Tables[0].Rows.Add(new string[] {tree_Field.Nodes[i].Tag.ToString().Trim(), tree_Field.Nodes[i].Text.Trim()});
						}
						catch
						{
						}
					}
				}
				if(amadoituong!="")
				{
					if(exp.Trim()=="")
					{
						exp = "a.madoituong in("+amadoituong+")";
					}
					else
					{
						exp = exp.Trim()+" and a.madoituong in("+amadoituong+")";
					}
				}
				
				if(akhoa!="")
				{
					akhoa=akhoa.Trim().Replace(",","','");
					akhoa="'"+akhoa+"'";
					if(exp.Trim()=="")
					{
						exp = "a.makp in("+akhoa+")";
					}
					else
					{
						exp = exp.Trim()+" and a.makp in("+akhoa+")";
					}
				}
				if(auserid!="")
				{
					if(exp.Trim()=="")
					{
						exp = "a.userid in("+auserid+")";
					}
					else
					{
						exp = exp.Trim()+" and a.userid in("+auserid+")";
					}
				}
				if(aquyenso!="")
				{
					if(exp.Trim()=="")
					{
						exp = "a.quyenso in("+aquyenso+")";
					}
					else
					{
						exp = exp.Trim()+" and a.quyenso in("+aquyenso+")";
					}
				}
                if (exp.Trim() == "")//gam 05/12/2011 không lấy hóa đơn đã hủy lên báo cáo
                {
                    exp = " a.id not in (select id from medibvmmyy.v_huybienlai where tables='v_tamung')";
                }
                else
                {
                    exp = exp.Trim() + " and a.id not in (select id from medibvmmyy.v_huybienlai where tables='v_tamung')";
                }
				if(exp.Trim()!="")
				{
					exp=" and " + exp.Trim();
				}

				if(rd1.Checked)//Nhóm theo biên lai
				{
                    sql = "select to_char(a.id) id, to_char(a.quyenso) quyensoid, to_char(a.sobienlai) sobienlai, to_char(a.ngay,'dd/mm/yyyy') ngay, c.sohieu quyenso, c.sohieu||' - '||to_char(a.sobienlai) sochungtu, b.mabn, b.hoten, nvl(to_char(b.ngaysinh,'dd/mm/yyyy'),to_char(b.namsinh)) namsinh, nvl(a.sotien,0) sotien, d.hoten nguoithu, d.hoten ||' ('||to_char(d.userid)||')' userid, e.doituong, f.tenkp khoa, trim(trim(b.sonha)||' '||trim(b.thon)||' '||trim(i.tenpxa)||' '||trim(h.tenquan)||' '||trim(g.tentt)) diachi, b.cholam, d.hoten||' ('||d.userid||')' nguoithu  ";
                    sql+=" from medibvmmyy.v_tamung a left join (" + asqlht + ") aa on a.quyenso=aa.quyenso and a.sobienlai=aa.sobienlai ";
                    sql+=" inner join medibv.btdbn b on a.mabn=b.mabn inner join medibv.v_quyenso c on a.quyenso=c.id inner join medibv.v_dlogin d on a.userid=d.id inner join medibv.doituong e on a.madoituong=e.madoituong inner join medibv.btdkp_bv f on a.makp=f.makp left join medibv.btdtt g on b.matt=g.matt";
                    sql+=" left join medibv.btdquan h on b.maqu=h.maqu left join medibv.btdpxa i on b.maphuongxa=i.maphuongxa";
                    sql+=" where aa.id is null and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('" + txtTN.Text.Trim().Substring(0, 10) + "','dd/mm/yyyy') and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')<=to_date('" + txtDN.Text.Trim().Substring(0, 10) + "','dd/mm/yyyy') " + exp + " order by c.sohieu asc, a.sobienlai asc, a.ngay asc";
				}
				else
				if(rd2.Checked)//Nhom theo ngay
				{
                    sql = "select to_char(a.ngay,'dd/mm/yyyy') ngay, count(a.id) sohoadon, sum(nvl(a.sotien,0)) sotien" + m_field_dt + " ";
                    sql+=" from medibvmmyy.v_tamung a left join (" + asqlht + ") aa on a.quyenso=aa.quyenso and a.sobienlai=aa.sobienlai ";
                    sql+=" where aa.id is null and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('" + txtTN.Text.Trim().Substring(0, 10) + "','dd/mm/yyyy') and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')<=to_date('" + txtDN.Text.Trim().Substring(0, 10) + "','dd/mm/yyyy') " + exp + " group by to_char(a.ngay,'dd/mm/yyyy') order by to_char(a.ngay,'dd/mm/yyyy') asc";
				}
				else
				if(rd3.Checked)//Nhom theo khoa
				{
                    sql = "select b.viettat ngay, b.makp, b.tenkp, count(a.id) sohoadon, sum(nvl(a.sotien,0)) sotien" + m_field_dt + " ";
                    sql+=" from medibvmmyy.v_tamung a left join (" + asqlht + ") aa on a.quyenso=aa.quyenso and a.sobienlai=aa.sobienlai";
                    sql+=" inner join medibv.btdkp_bv b on a.makp=b.makp where aa.id is null and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('" + txtTN.Text.Trim().Substring(0, 10) + "','dd/mm/yyyy') and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')<=to_date('" + txtDN.Text.Trim().Substring(0, 10) + "','dd/mm/yyyy') " + exp + " group by b.makp, b.viettat, b.tenkp order by b.tenkp asc";
				}
				else
					if(rd4.Checked)//Nhom theo nhan vien thu ngan
				{
                    sql = "select b.userid ngay, b.hoten nguoithu, count(a.id) sohoadon, sum(nvl(a.sotien,0)) sotien" + m_field_dt + " ";
                    sql+=" from medibvmmyy.v_tamung a left join (" + asqlht + ") aa on a.quyenso=aa.quyenso and a.sobienlai=aa.sobienlai";
                    sql+=" inner join medibv.v_dlogin b on a.userid=b.id where aa.id is null and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('" + txtTN.Text.Trim().Substring(0, 10) + "','dd/mm/yyyy') and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')<=to_date('" + txtDN.Text.Trim().Substring(0, 10) + "','dd/mm/yyyy') " + exp + " group by b.hoten,b.userid order by b.hoten asc";
				}

				if(m_ds2.Tables[0].Rows.Count<=0)
				{
					progressBar1.Value=progressBar1.Maximum;
					timer1.Enabled=false;
					progressBar1.Value=0;
					MessageBox.Show(this,lan.Change_language_MessageText("Chọn thông tin báo cáo cần hiển thị"),m_v.s_AppName,MessageBoxButtons.OK);
					return;
				}
				//MessageBox.Show(sql);
				//return;

                ads = m_v.get_data_mmyy(sql, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true);
				if(ads.Tables[0].Rows.Count<=0)
				{
					progressBar1.Value=progressBar1.Maximum;
					timer1.Enabled=false;
					progressBar1.Value=0;
					MessageBox.Show(this,lan.Change_language_MessageText("Không có số liệu báo cáo"),m_v.s_AppName,MessageBoxButtons.OK);
					return;
				}

				//Them dong tong cong vao cuoi
				DataRow r = ads.Tables[0].NewRow();
				for(int i=0;i<ads.Tables[0].Columns.Count;i++)
				{
					if(ads.Tables[0].Columns[i].DataType.ToString()=="System.Decimal")
					{
						r[i]="0";
					}
				}
				for(int i=0;i<ads.Tables[0].Rows.Count;i++)
				{
					for(int j=0;j<ads.Tables[0].Columns.Count;j++)
					{
						if(ads.Tables[0].Columns[j].DataType.ToString()=="System.Decimal")
						{
							try
							{
								r[j]=decimal.Parse(r[j].ToString()) + decimal.Parse(ads.Tables[0].Rows[i][j].ToString());
							}
							catch
							{
								r[j]=0;
							}
						}
					}
				}

				try
				{
					r["mabn"]="Tổng: "+ads.Tables[0].Rows.Count.ToString();
				}
				catch
				{
					try
					{
						r["ngay"]="Tổng: "+ads.Tables[0].Rows.Count.ToString();
					}
					catch
					{
					}
				}
				ads.Tables[0].Rows.Add(r);
				
				try
				{
					if(!System.IO.Directory.Exists("..//..//Export"))
					{
						System.IO.Directory.CreateDirectory("..//..//Export");
					}
				}
				catch
				{
				}
				string apath = Application.ExecutablePath;
				apath=apath.Substring(0,apath.LastIndexOf("\\"));
				apath=apath.Substring(0,apath.LastIndexOf("\\"));
				apath=apath.Substring(0,apath.LastIndexOf("\\"));
				apath = apath.Replace("\\","//");

				switch(v_format)
				{
					case "HTML":
						f_Export_HTML(ads, m_ds2,apath+"//Export//baocaothutamung");
						break;
					default:
						f_Export_Excel(ads, m_ds2,apath+"//Export//baocaothutamung");
						break;
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}
		private void f_Export_Excel(DataSet v_ds1, DataSet v_ds2, string v_filepath)
		{
			v_filepath=v_filepath+".xls";
			try
			{
				string t=rd1.Checked?lan.Change_language_MessageText("THEO HOÁ ĐƠN"):lan.Change_language_MessageText(" THEO NGÀY");
				if(rd1.Checked)
				{
					t =" "+ lan.Change_language_MessageText("THEO HOÁ ĐƠN");
				}
				else
					if(rd2.Checked)
				{
					t = " "+lan.Change_language_MessageText("THEO NGÀY");
				}
				else
					if(rd3.Checked)
				{
					t = " "+lan.Change_language_MessageText("THEO KHOA");
				}
				else
					if(rd4.Checked)
				{
					t = " "+lan.Change_language_MessageText("THEO NHÂN VIÊN THU NGÂN");
				}
				t="";

				System.IO.StreamWriter sw  =  new System.IO.StreamWriter(v_filepath,false,System.Text.Encoding.UTF8);
				string astr="";
				astr="<Table border=0>";

				astr=astr + "<tr>";
				astr=astr + "<th align=left colspan="+v_ds2.Tables[0].Rows.Count.ToString()+">";
				astr=astr + m_v.Syte;
				astr=astr + "</th>";
				astr=astr + "</tr>";
				
				astr=astr + "<tr>";
				astr=astr + "<th align=left colspan="+v_ds2.Tables[0].Rows.Count.ToString()+">";
				astr=astr + m_v.Tenbv;
				astr=astr + "</th>";
				astr=astr + "</tr>";

				astr=astr + "<tr>";
				astr=astr + "<th height=40 align=center style=\"font-family: Arial; font-size: 14pt; font-weight: bold\" colspan="+v_ds2.Tables[0].Rows.Count.ToString()+">";
				astr=astr + lan.Change_language_MessageText("BÁO CÁO THU TẠM ỨNG")+" "+ t;
				astr=astr + "</th>";
				astr=astr + "</tr>";
				
				astr=astr + "<tr>";
				astr=astr + "<th align=center style=\"font-family: Arial; font-size: 10pt; font-weight: bold\" colspan="+v_ds2.Tables[0].Rows.Count.ToString()+">";
                astr = astr + lan.Change_language_MessageText("Từ ngày")+" " + txtTN.Text.Substring(0, 10) + " Đến ngày " + txtDN.Text.Substring(0, 10) + ")";
				astr=astr + "</th>";
				astr=astr + "</tr>";

				astr=astr + "<tr>";
				astr=astr + "<th align=left colspan="+v_ds2.Tables[0].Rows.Count.ToString()+">";
				astr=astr + "";
				astr=astr + "</th>";
				astr=astr + "</tr>";

				astr=astr+"</Table>";
				sw.Write(astr);

				astr="<Table border=1 style=\"font-family: Arial; font-size: 10pt; font-weight: normal\">";
				astr=astr + "<tr>";
				for(int i=0;i<v_ds2.Tables[0].Rows.Count;i++)
				{
					astr=astr + "<th>";
					astr=astr + v_ds2.Tables[0].Rows[i]["TEN"].ToString();
					astr=astr + "</th>";
				}
				astr=astr + "</tr>";
				//Dong so thu tu
				astr=astr + "<tr>";
				for(int i=0;i<v_ds2.Tables[0].Rows.Count;i++)
				{
					astr=astr + "<th>";
					astr=astr + (i+1).ToString();
					astr=astr + "</th>";
				}
				astr=astr + "</tr>";
				sw.Write(astr);

				string at="";
				for(int i=0;i<v_ds1.Tables[0].Rows.Count;i++)
				{
					astr="<tr>";
					for(int j=0;j<v_ds2.Tables[0].Rows.Count;j++)
					{
						for(int k=0;k<v_ds1.Tables[0].Columns.Count;k++)
						{
							//MessageBox.Show(v_ds1.Tables[0].Columns[k].ColumnName.ToUpper()+"="+v_ds2.Tables[0].Rows[j]["MA"].ToString().ToUpper());
							if(v_ds1.Tables[0].Columns[k].ColumnName.ToUpper()==v_ds2.Tables[0].Rows[j]["MA"].ToString().ToUpper())
							{
								if(v_ds1.Tables[0].Columns[k].DataType.ToString()=="System.Decimal")
								{
									try
									{
										at = decimal.Parse(v_ds1.Tables[0].Rows[i][k].ToString()).ToString("###,###,##0.##");
									}
									catch
									{
										at="";
									}
									if(at=="0")
									{
										at="";
									}
									if(i==v_ds1.Tables[0].Rows.Count-1)
									{
										astr=astr + "<td align=right style=\"font-family: Arial; font-size: 10pt; font-weight: bold\">";
									}
									else
									{
										astr=astr + "<td align=right>";
									}
									astr=astr + at;
									astr=astr + "</td>";
								}
								else
								{
									if(i==v_ds1.Tables[0].Rows.Count-1)
									{
										astr=astr + "<td align=left style=\"font-family: Arial; font-size: 10pt; font-weight: bold\">";
									}
									else
									{
										astr=astr + "<td align=left>";
									}
									string atmp="";
									if((v_ds1.Tables[0].Columns[k].ColumnName.ToUpper()=="MABN")&&(i!=v_ds1.Tables[0].Rows.Count-1))
									{
										atmp="'";//(i+1).ToString()+" - ";
									}
									astr=astr + atmp + v_ds1.Tables[0].Rows[i][k].ToString();
									astr=astr + "</td>";
								}
								//break;
							}
						}
					}
					astr=astr + "</tr>";
					sw.Write(astr);
				}

				astr="</table>";
				sw.Write(astr);
				
				astr="<table boder=0>";
				astr=astr + "<tr>";
				astr=astr + "<th align=right style=\"font-family: Arial; font-size: 10pt; font-weight: bold\" colspan="+v_ds2.Tables[0].Rows.Count.ToString()+">";
				astr=astr + f_GetNgay(txtNgayIn.Text.Substring(0,10));
				astr=astr + "</th>";
				astr=astr + "</tr>";
				
				astr=astr + "<tr>";
				astr=astr + "<th height=30 align=right style=\"font-family: Arial; font-size: 10pt; font-weight: bold\" colspan="+v_ds2.Tables[0].Rows.Count.ToString()+">";
				astr=astr + "";
				astr=astr + "</th>";
				astr=astr + "</tr>";

				astr=astr + "<tr>";
				astr=astr + "<th height=30 align=right style=\"font-family: Arial; font-size: 10pt; font-weight: bold\" colspan="+v_ds2.Tables[0].Rows.Count.ToString()+">";
				astr=astr + lbNguoiDN.Text.Trim()+"                 ";
				astr=astr + "</th>";
				astr=astr + "</tr>";
				astr=astr + "</Table>";
				sw.Write(astr);
				sw.Close();
				//System.IO.File.Copy(v_filepath,v_filepath+".html",true);
				//MessageBox.Show(lan.Change_language_MessageText("OK");
				timer1.Enabled=false;
				System.Diagnostics.Process.Start(v_filepath);
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}
		private void f_Export_HTML(DataSet v_ds1, DataSet v_ds2, string v_filepath)
		{
			try
			{
				v_filepath=v_filepath+".html";
				int n=0;
				string t="";
				if(rd1.Checked)
				{
					t = " "+lan.Change_language_MessageText("THEO HOÁ ĐƠN");
				}
				else
					if(rd2.Checked)
				{
					t = " "+lan.Change_language_MessageText("THEO NGÀY");
				}
				else
					if(rd3.Checked)
				{
					t = " "+lan.Change_language_MessageText("THEO KHOA");
				}
				else
					if(rd4.Checked)
				{
					t = " "+lan.Change_language_MessageText("THEO NHÂN VIÊN THU NGÂN");
				}
				t="";

				for(int i=0;i<v_ds2.Tables[0].Rows.Count;i++)
				{
					n+=v_ds2.Tables[0].Rows[i]["MA"].ToString().IndexOf("LLLL")==0?1:0;
				}

				System.IO.StreamWriter sw  =  new System.IO.StreamWriter(v_filepath,false,System.Text.Encoding.UTF8);
				string astr="";
				
				astr=astr + "<html>";
				astr=astr + "<head>";
				astr=astr + "<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\">";
                astr = astr + lan.Change_language_MessageText("<title>Báo cáo thu tạm ứng</title>");
				astr=astr + "</head>";

				astr=astr + "<body>";

				astr="<Table border=0>";

				astr=astr + "<tr>";
				astr=astr + "<th align=left colspan="+v_ds2.Tables[0].Rows.Count.ToString()+">";
				astr=astr + m_v.Syte;
				astr=astr + "</th>";
				astr=astr + "</tr>";
				
				astr=astr + "<tr>";
				astr=astr + "<th align=left colspan="+v_ds2.Tables[0].Rows.Count.ToString()+">";
				astr=astr + m_v.Tenbv;
				astr=astr + "</th>";
				astr=astr + "</tr>";

				astr=astr + "<tr>";
				astr=astr + "<th height=40 align=center style=\"font-family: Arial; font-size: 14pt; font-weight: bold\" colspan="+v_ds2.Tables[0].Rows.Count.ToString()+">";
				astr=astr + lan.Change_language_MessageText("BÁO CÁO THU TẠM ỨNG")+" "+ t;
				astr=astr + "</th>";
				astr=astr + "</tr>";
				
				astr=astr + "<tr>";
				astr=astr + "<th align=center style=\"font-family: Arial; font-size: 10pt; font-weight: bold\" colspan="+v_ds2.Tables[0].Rows.Count.ToString()+">";
				astr=astr + lan.Change_language_MessageText("(Từ ngày")+" "+ txtTN.Text.Substring(0,10) + " Đến ngày " + txtDN.Text.Substring(0,10)+")";
				astr=astr + "</th>";
				astr=astr + "</tr>";

				astr=astr + "<tr>";
				astr=astr + "<th align=left colspan="+v_ds2.Tables[0].Rows.Count.ToString()+">";
				astr=astr + "";
				astr=astr + "</th>";
				astr=astr + "</tr>";

				astr=astr + "<tr>";
				astr=astr + "<th align=left colspan="+v_ds2.Tables[0].Rows.Count.ToString()+">";
				sw.Write(astr);

				astr="<Table border=1 style=\"font-family: Arial; font-size: 10pt; font-weight: normal; border-style: solid; border-width: 1\" cellspacing=1>";
				astr=astr + "<tr>";
				for(int i=0;i<v_ds2.Tables[0].Rows.Count;i++)
				{
					astr=astr + "<th style=\"border-style: solid; border-width: 1\">";
					astr=astr + v_ds2.Tables[0].Rows[i]["TEN"].ToString();
					astr=astr + "</th>";
				}
				astr=astr + "</tr>";
				//Dong so thu tu
				astr=astr + "<tr>";
				for(int i=0;i<v_ds2.Tables[0].Rows.Count;i++)
				{
					astr=astr + "<th style=\"border-style: solid; border-width: 1\">";
					astr=astr + (i+1).ToString();
					astr=astr + "</th>";
				}
				astr=astr + "</tr>";
				sw.Write(astr);

				string at="";
				for(int i=0;i<v_ds1.Tables[0].Rows.Count;i++)
				{
					astr="<tr>";
					for(int j=0;j<v_ds2.Tables[0].Rows.Count;j++)
					{
						for(int k=0;k<v_ds1.Tables[0].Columns.Count;k++)
						{
							//MessageBox.Show(v_ds1.Tables[0].Columns[k].ColumnName.ToUpper()+"="+v_ds2.Tables[0].Rows[j]["MA"].ToString().ToUpper());
							if(v_ds1.Tables[0].Columns[k].ColumnName.ToUpper()==v_ds2.Tables[0].Rows[j]["MA"].ToString().ToUpper())
							{
								if(v_ds1.Tables[0].Columns[k].DataType.ToString()=="System.Decimal")
								{
									try
									{
										at = decimal.Parse(v_ds1.Tables[0].Rows[i][k].ToString()).ToString("###,###,##0.##");
									}
									catch
									{
										at="";
									}
									if(at=="0")
									{
										at="";
									}
									if(i==v_ds1.Tables[0].Rows.Count-1)
									{
										astr=astr + "<td align=right style=\"font-family: Arial; font-size: 10pt; font-weight: bold; border-style: solid; border-width: 1\">";
									}
									else
									{
										astr=astr + "<td align=right style=\"border-style: solid; border-width: 1\">";
									}
									astr=astr + at;
									astr=astr + "&nbsp;</td>";
								}
								else
								{
									if(i==v_ds1.Tables[0].Rows.Count-1)
									{
										astr=astr + "<td align=left style=\"font-family: Arial; font-size: 10pt; font-weight: bold; border-style: solid; border-width: 1\">";
									}
									else
									{
										astr=astr + "<td align=left style=\"border-style: solid; border-width: 1\">";
									}
									string atmp="";
									if((v_ds1.Tables[0].Columns[k].ColumnName.ToUpper()=="MABN")&&(i!=v_ds1.Tables[0].Rows.Count-1))
									{
										atmp="&nbsp;";//(i+1).ToString()+" - ";
									}
									astr=astr + atmp + v_ds1.Tables[0].Rows[i][k].ToString();
									astr=astr + "&nbsp;</td>";
								}
								//break;
							}
						}
					}
					astr=astr + "</tr>";
					sw.Write(astr);
				}
				astr="</table>";
				sw.Write(astr);

				astr="</th>";
				astr=astr + "</tr>";
				sw.Write(astr);

				astr="<tr>";
				astr=astr + "<th align=left colspan="+v_ds2.Tables[0].Rows.Count.ToString()+">";
				sw.Write(astr);

				astr="<table boder=0 width=100%>";
				astr=astr + "<tr>";
				astr=astr + "<th align=right style=\"font-family: Arial; font-size: 10pt; font-weight: bold\" colspan="+v_ds2.Tables[0].Rows.Count.ToString()+">";
				astr=astr + f_GetNgay(txtNgayIn.Text.Substring(0,10));
				astr=astr + "</th>";
				astr=astr + "</tr>";
				
				astr=astr + "<tr>";
				astr=astr + "<th height=30 align=right style=\"font-family: Arial; font-size: 10pt; font-weight: bold\" colspan="+v_ds2.Tables[0].Rows.Count.ToString()+">";
				astr=astr + "&nbsp;";
				astr=astr + "</th>";
				astr=astr + "</tr>";

				astr=astr + "<tr>";
				astr=astr + "<th height=30 align=right style=\"font-family: Arial; font-size: 10pt; font-weight: bold\" colspan="+v_ds2.Tables[0].Rows.Count.ToString()+">";
				astr=astr + lbNguoiDN.Text.Trim()+"                 ";
				astr=astr + "</th>";
				astr=astr + "</tr>";
				astr=astr + "</Table>";
				sw.Write(astr);

				astr="</th>";
				astr=astr + "</tr>";
				astr=astr+"</Table>";
				sw.Write(astr);
				
				astr=astr + "</body>";	
				astr=astr + "</html>";
				sw.Write(astr);
				sw.Close();
				//MessageBox.Show(v_filepath);
				timer1.Enabled=false;
				System.Diagnostics.Process.Start(v_filepath);
				//MessageBox.Show(lan.Change_language_MessageText("OK");
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}
		private string f_GetNgay(string v_ngay)
		{
			try
			{
				return lan.Change_language_MessageText("Ngày")+" " + v_ngay.Substring(0,2) + " "+lan.Change_language_MessageText("tháng")+" " + v_ngay.Substring(3,2) + " "+lan.Change_language_MessageText("năm")+" " + v_ngay.Substring(6);
			}
			catch
			{
				return "";
			}
		}
		private void butExcel_Click(object sender, System.EventArgs e)
		{	
			progressBar1.Value=1;
			timer1.Enabled=true;
			butExcel.Enabled=false;
			this.Cursor=Cursors.WaitCursor;
			f_Ketxuat("EXCEL");
			butExcel.Enabled=true;
			this.Cursor=Cursors.Default;
			progressBar1.Value=0;
			timer1.Enabled=false;
		}
		private void butWeb_Click(object sender, System.EventArgs e)
		{
			progressBar1.Value=1;
			timer1.Enabled=true;
			butWeb.Enabled=false;
			this.Cursor=Cursors.WaitCursor;
			f_Ketxuat("HTML");
			butWeb.Enabled=true;
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
		private void chkAll_CheckedChanged(object sender, System.EventArgs e)
		{
			f_Set_CheckID(tree_Doituong,chkAll.Checked);
		}

		private void chkAll1_CheckedChanged(object sender, System.EventArgs e)
		{
			f_Set_CheckID(tree_Field,chkAll1.Checked);
		}

		private void rd1_CheckedChanged(object sender, System.EventArgs e)
		{
			f_Load_Tree_Field();
		}

		private void rd2_CheckedChanged(object sender, System.EventArgs e)
		{
			f_Load_Tree_Field();
		}

		private void cbLoaiBN_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
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

		private void chkAll_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
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

		private void chkl_Doituong_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
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

		private void chkl_Field_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
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

		private void rd3_CheckedChanged(object sender, System.EventArgs e)
		{
			f_Load_Tree_Field();
		}

		private void chkAll2_CheckedChanged(object sender, System.EventArgs e)
		{
			f_Set_CheckID(tree_KP,chkAll2.Checked);
		}

		private void butExcel_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
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

		private void chkAll_KeyDown_1(object sender, System.Windows.Forms.KeyEventArgs e)
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

		private void chkAll2_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
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

		private void chkl_Khoa_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
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

		private void chkAll1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
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

		private void frmBaocaothutamung_SizeChanged(object sender, System.EventArgs e)
		{
		}

		private void tree_Field_AfterCheck(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			try
			{
				e.Node.ForeColor=e.Node.Checked?Color.Navy:Color.DimGray;
				for(int i=0;i<tree_Field.Nodes.Count;i++)
				{
					if(tree_Field.Nodes[i].Checked)
					{
						return;
					}
				}
				chkAll1.Checked=false;
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
				chkAll.Checked=false;
			}
			catch
			{
			}
		}

		private void tree_KP_AfterCheck(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			try
			{
				e.Node.ForeColor=e.Node.Checked?Color.Navy:Color.DimGray;
				for(int i=0;i<tree_KP.Nodes.Count;i++)
				{
					if(tree_KP.Nodes[i].Checked)
					{
						return;
					}
				}
				chkAll2.Checked=false;
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

                amsg = lan.Change_language_MessageText("Đã chọn:") + "\n" + lan.Change_language_MessageText("Nhân viên thu ngân:") + " " + anu.ToString() + "\n"+lan.Change_language_MessageText("Quyển sổ thu tiền:") + " " + ans.ToString();
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

		private void chkUserid_CheckedChanged(object sender, System.EventArgs e)
		{
			f_Set_CheckID(tree_User,chkUserid.Checked);
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
	}
}
