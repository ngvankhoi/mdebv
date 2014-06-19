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
	/// Summary description for frmBaocaosobienlai.
	/// </summary>
	public class frmBaocaosobienlai : System.Windows.Forms.Form
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
		private System.Windows.Forms.Button butInBK;
		private System.Windows.Forms.DateTimePicker txtNgayIn;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox txtNguoilapbang;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton rdNgay;
		private System.Windows.Forms.RadioButton rdThang;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker txtDN;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.NumericUpDown txtThang;
		private System.Windows.Forms.NumericUpDown txtNam;
		private System.Windows.Forms.DateTimePicker txtTN;
		private System.Windows.Forms.CheckBox chkLoaiBN;
		private System.Windows.Forms.TreeView tree_LoaiBN;
		private System.Windows.Forms.TreeView tree_User;
		private System.Windows.Forms.CheckBox chkUserid;
		private System.Windows.Forms.CheckBox chkDoituong;
		private System.Windows.Forms.TreeView tree_Doituong;
		private System.Windows.Forms.CheckBox chkLoaidv;
		private System.Windows.Forms.TreeView tree_Loaidv;
		private System.Windows.Forms.GroupBox gbChungtu;
		private System.Windows.Forms.CheckBox chkNoitru;
		private System.Windows.Forms.CheckBox chkTructiep;
		private System.Windows.Forms.RadioButton rdToanvien;
		private System.Windows.Forms.RadioButton rdUser;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.CheckBox chkTU;
		private System.Windows.Forms.Label label11;
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
		private System.Windows.Forms.TextBox timso;
		private System.Windows.Forms.TreeView tree_Quyenso;
        private ComboBox cboMaubaocao;
        private Label label4;
        private RadioButton rdNguoithu;
		private System.ComponentModel.IContainer components;

		public frmBaocaosobienlai(string v_userid)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBaocaosobienlai));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbTitle = new System.Windows.Forms.Label();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label15 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cboMaubaocao = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tree_Quyenso = new System.Windows.Forms.TreeView();
            this.timso = new System.Windows.Forms.TextBox();
            this.tree_Doituong = new System.Windows.Forms.TreeView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdNguoithu = new System.Windows.Forms.RadioButton();
            this.rdUser = new System.Windows.Forms.RadioButton();
            this.rdToanvien = new System.Windows.Forms.RadioButton();
            this.gbChungtu = new System.Windows.Forms.GroupBox();
            this.chkTU = new System.Windows.Forms.CheckBox();
            this.chkNoitru = new System.Windows.Forms.CheckBox();
            this.chkTructiep = new System.Windows.Forms.CheckBox();
            this.tree_Loaidv = new System.Windows.Forms.TreeView();
            this.tree_LoaiBN = new System.Windows.Forms.TreeView();
            this.tree_User = new System.Windows.Forms.TreeView();
            this.contextMenu2 = new System.Windows.Forms.ContextMenu();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDN = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.txtThang = new System.Windows.Forms.NumericUpDown();
            this.txtNam = new System.Windows.Forms.NumericUpDown();
            this.txtTN = new System.Windows.Forms.DateTimePicker();
            this.rdNgay = new System.Windows.Forms.RadioButton();
            this.rdThang = new System.Windows.Forms.RadioButton();
            this.txtNguoilapbang = new System.Windows.Forms.TextBox();
            this.butInBK = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.txtNgayIn = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.chkUserid = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkDoituong = new System.Windows.Forms.CheckBox();
            this.chkLoaiBN = new System.Windows.Forms.CheckBox();
            this.chkLoaidv = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gbChungtu.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtThang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNam)).BeginInit();
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
            this.panel1.Size = new System.Drawing.Size(686, 49);
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
            this.lbTitle.Text = "  BÁO CÁO BIÊN LAI SỬ DỤNG";
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
            this.label15.Size = new System.Drawing.Size(686, 3);
            this.label15.TabIndex = 17;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.cboMaubaocao);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.tree_Quyenso);
            this.panel2.Controls.Add(this.timso);
            this.panel2.Controls.Add(this.tree_Doituong);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.gbChungtu);
            this.panel2.Controls.Add(this.tree_Loaidv);
            this.panel2.Controls.Add(this.tree_LoaiBN);
            this.panel2.Controls.Add(this.tree_User);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.txtNguoilapbang);
            this.panel2.Controls.Add(this.butInBK);
            this.panel2.Controls.Add(this.butKetthuc);
            this.panel2.Controls.Add(this.txtNgayIn);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.chkUserid);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.chkDoituong);
            this.panel2.Controls.Add(this.chkLoaiBN);
            this.panel2.Controls.Add(this.chkLoaidv);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.ForeColor = System.Drawing.Color.Navy;
            this.panel2.Location = new System.Drawing.Point(3, 55);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(686, 314);
            this.panel2.TabIndex = 18;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // cboMaubaocao
            // 
            this.cboMaubaocao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMaubaocao.FormattingEnabled = true;
            this.cboMaubaocao.Location = new System.Drawing.Point(409, 285);
            this.cboMaubaocao.Name = "cboMaubaocao";
            this.cboMaubaocao.Size = new System.Drawing.Size(235, 21);
            this.cboMaubaocao.TabIndex = 212;
            this.cboMaubaocao.SelectedIndexChanged += new System.EventHandler(this.cboMaubaocao_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.Color.Navy;
            this.label4.Location = new System.Drawing.Point(330, 290);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 211;
            this.label4.Text = "Mẫu báo cáo ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tree_Quyenso
            // 
            this.tree_Quyenso.CheckBoxes = true;
            this.tree_Quyenso.ForeColor = System.Drawing.Color.DimGray;
            this.tree_Quyenso.FullRowSelect = true;
            this.tree_Quyenso.Location = new System.Drawing.Point(207, 20);
            this.tree_Quyenso.Name = "tree_Quyenso";
            this.tree_Quyenso.ShowLines = false;
            this.tree_Quyenso.ShowPlusMinus = false;
            this.tree_Quyenso.ShowRootLines = false;
            this.tree_Quyenso.Size = new System.Drawing.Size(124, 134);
            this.tree_Quyenso.Sorted = true;
            this.tree_Quyenso.TabIndex = 210;
            // 
            // timso
            // 
            this.timso.BackColor = System.Drawing.Color.White;
            this.timso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timso.Location = new System.Drawing.Point(5, 155);
            this.timso.MaxLength = 12;
            this.timso.Name = "timso";
            this.timso.Size = new System.Drawing.Size(326, 21);
            this.timso.TabIndex = 209;
            this.timso.Text = "Tìm sổ";
            this.timso.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.timso.TextChanged += new System.EventHandler(this.timso_TextChanged);
            // 
            // tree_Doituong
            // 
            this.tree_Doituong.CheckBoxes = true;
            this.tree_Doituong.ForeColor = System.Drawing.Color.DimGray;
            this.tree_Doituong.FullRowSelect = true;
            this.tree_Doituong.Location = new System.Drawing.Point(221, 194);
            this.tree_Doituong.Name = "tree_Doituong";
            this.tree_Doituong.ShowLines = false;
            this.tree_Doituong.ShowPlusMinus = false;
            this.tree_Doituong.ShowRootLines = false;
            this.tree_Doituong.Size = new System.Drawing.Size(109, 113);
            this.tree_Doituong.Sorted = true;
            this.tree_Doituong.TabIndex = 9;
            this.tree_Doituong.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tree_Doituong_AfterCheck);
            this.tree_Doituong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tree_Doituong_KeyDown);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdNguoithu);
            this.groupBox2.Controls.Add(this.rdUser);
            this.groupBox2.Controls.Add(this.rdToanvien);
            this.groupBox2.Location = new System.Drawing.Point(473, 92);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(206, 84);
            this.groupBox2.TabIndex = 208;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Mẫu báo cáo";
            // 
            // rdNguoithu
            // 
            this.rdNguoithu.Location = new System.Drawing.Point(7, 37);
            this.rdNguoithu.Name = "rdNguoithu";
            this.rdNguoithu.Size = new System.Drawing.Size(147, 20);
            this.rdNguoithu.TabIndex = 2;
            this.rdNguoithu.Text = "Họ tên người thu";
            // 
            // rdUser
            // 
            this.rdUser.Checked = true;
            this.rdUser.Location = new System.Drawing.Point(7, 18);
            this.rdUser.Name = "rdUser";
            this.rdUser.Size = new System.Drawing.Size(200, 20);
            this.rdUser.TabIndex = 0;
            this.rdUser.TabStop = true;
            this.rdUser.Text = "Theo nhân viên thu ngân (user login)";
            // 
            // rdToanvien
            // 
            this.rdToanvien.Location = new System.Drawing.Point(7, 58);
            this.rdToanvien.Name = "rdToanvien";
            this.rdToanvien.Size = new System.Drawing.Size(75, 20);
            this.rdToanvien.TabIndex = 1;
            this.rdToanvien.Text = "Toàn viện";
            // 
            // gbChungtu
            // 
            this.gbChungtu.Controls.Add(this.chkTU);
            this.gbChungtu.Controls.Add(this.chkNoitru);
            this.gbChungtu.Controls.Add(this.chkTructiep);
            this.gbChungtu.Location = new System.Drawing.Point(335, 92);
            this.gbChungtu.Name = "gbChungtu";
            this.gbChungtu.Size = new System.Drawing.Size(134, 84);
            this.gbChungtu.TabIndex = 207;
            this.gbChungtu.TabStop = false;
            this.gbChungtu.Text = "Chứng từ";
            // 
            // chkTU
            // 
            this.chkTU.Location = new System.Drawing.Point(10, 58);
            this.chkTU.Name = "chkTU";
            this.chkTU.Size = new System.Drawing.Size(88, 20);
            this.chkTU.TabIndex = 2;
            this.chkTU.TabStop = false;
            this.chkTU.Text = "Tạm ứng";
            // 
            // chkNoitru
            // 
            this.chkNoitru.Checked = true;
            this.chkNoitru.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNoitru.Location = new System.Drawing.Point(10, 38);
            this.chkNoitru.Name = "chkNoitru";
            this.chkNoitru.Size = new System.Drawing.Size(118, 20);
            this.chkNoitru.TabIndex = 1;
            this.chkNoitru.TabStop = false;
            this.chkNoitru.Text = "Thanh toán ra viện";
            // 
            // chkTructiep
            // 
            this.chkTructiep.Checked = true;
            this.chkTructiep.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTructiep.Location = new System.Drawing.Point(10, 18);
            this.chkTructiep.Name = "chkTructiep";
            this.chkTructiep.Size = new System.Drawing.Size(88, 20);
            this.chkTructiep.TabIndex = 0;
            this.chkTructiep.TabStop = false;
            this.chkTructiep.Text = "Thu trực tiếp";
            // 
            // tree_Loaidv
            // 
            this.tree_Loaidv.CheckBoxes = true;
            this.tree_Loaidv.ForeColor = System.Drawing.Color.DimGray;
            this.tree_Loaidv.FullRowSelect = true;
            this.tree_Loaidv.Location = new System.Drawing.Point(5, 194);
            this.tree_Loaidv.Name = "tree_Loaidv";
            this.tree_Loaidv.ShowLines = false;
            this.tree_Loaidv.ShowPlusMinus = false;
            this.tree_Loaidv.ShowRootLines = false;
            this.tree_Loaidv.Size = new System.Drawing.Size(96, 113);
            this.tree_Loaidv.Sorted = true;
            this.tree_Loaidv.TabIndex = 5;
            this.tree_Loaidv.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tree_Loaidv_AfterCheck);
            this.tree_Loaidv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tree_Loaidv_KeyDown);
            // 
            // tree_LoaiBN
            // 
            this.tree_LoaiBN.CheckBoxes = true;
            this.tree_LoaiBN.ForeColor = System.Drawing.Color.DimGray;
            this.tree_LoaiBN.FullRowSelect = true;
            this.tree_LoaiBN.Location = new System.Drawing.Point(102, 194);
            this.tree_LoaiBN.Name = "tree_LoaiBN";
            this.tree_LoaiBN.ShowLines = false;
            this.tree_LoaiBN.ShowPlusMinus = false;
            this.tree_LoaiBN.ShowRootLines = false;
            this.tree_LoaiBN.Size = new System.Drawing.Size(118, 113);
            this.tree_LoaiBN.Sorted = true;
            this.tree_LoaiBN.TabIndex = 7;
            this.tree_LoaiBN.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tree_LoaiBN_AfterCheck);
            this.tree_LoaiBN.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tree_LoaiBN_KeyDown);
            // 
            // tree_User
            // 
            this.tree_User.CheckBoxes = true;
            this.tree_User.ContextMenu = this.contextMenu2;
            this.tree_User.ForeColor = System.Drawing.Color.DimGray;
            this.tree_User.FullRowSelect = true;
            this.tree_User.Location = new System.Drawing.Point(5, 20);
            this.tree_User.Name = "tree_User";
            this.tree_User.ShowLines = false;
            this.tree_User.ShowPlusMinus = false;
            this.tree_User.ShowRootLines = false;
            this.tree_User.Size = new System.Drawing.Size(326, 134);
            this.tree_User.Sorted = true;
            this.tree_User.TabIndex = 1;
            this.tree_User.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tree_User_AfterCheck);
            this.tree_User.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tree_User_KeyDown);
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtDN);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtThang);
            this.groupBox1.Controls.Add(this.txtNam);
            this.groupBox1.Controls.Add(this.txtTN);
            this.groupBox1.Controls.Add(this.rdNgay);
            this.groupBox1.Controls.Add(this.rdThang);
            this.groupBox1.Location = new System.Drawing.Point(335, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(344, 74);
            this.groupBox1.TabIndex = 158;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thời gian báo cáo";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(177, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Năm";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDN
            // 
            this.txtDN.CustomFormat = "dd/MM/yyyy hh:mm";
            this.txtDN.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtDN.Location = new System.Drawing.Point(210, 43);
            this.txtDN.Name = "txtDN";
            this.txtDN.Size = new System.Drawing.Size(85, 20);
            this.txtDN.TabIndex = 5;
            this.txtDN.ValueChanged += new System.EventHandler(this.txtDN_ValueChanged);
            this.txtDN.Validated += new System.EventHandler(this.txtDN_Validated);
            this.txtDN.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDN_KeyDown);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(157, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 154;
            this.label3.Text = "Đến ngày";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtThang
            // 
            this.txtThang.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtThang.Location = new System.Drawing.Point(72, 20);
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
            this.txtThang.Size = new System.Drawing.Size(85, 21);
            this.txtThang.TabIndex = 1;
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
            this.txtNam.Location = new System.Drawing.Point(210, 20);
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
            this.txtNam.Size = new System.Drawing.Size(85, 21);
            this.txtNam.TabIndex = 2;
            this.txtNam.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNam.Value = new decimal(new int[] {
            1980,
            0,
            0,
            0});
            this.txtNam.ValueChanged += new System.EventHandler(this.txtNam_ValueChanged);
            this.txtNam.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNam_KeyDown);
            // 
            // txtTN
            // 
            this.txtTN.CustomFormat = "dd/MM/yyyy hh:mm";
            this.txtTN.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtTN.Location = new System.Drawing.Point(72, 43);
            this.txtTN.Name = "txtTN";
            this.txtTN.Size = new System.Drawing.Size(85, 20);
            this.txtTN.TabIndex = 4;
            this.txtTN.ValueChanged += new System.EventHandler(this.txtTN_ValueChanged);
            this.txtTN.Validated += new System.EventHandler(this.txtTN_Validated);
            this.txtTN.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTN_KeyDown);
            // 
            // rdNgay
            // 
            this.rdNgay.Location = new System.Drawing.Point(9, 43);
            this.rdNgay.Name = "rdNgay";
            this.rdNgay.Size = new System.Drawing.Size(64, 20);
            this.rdNgay.TabIndex = 3;
            this.rdNgay.Text = "Từ ngày";
            this.rdNgay.CheckedChanged += new System.EventHandler(this.rdNgay_CheckedChanged);
            this.rdNgay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rdNgay_KeyDown);
            // 
            // rdThang
            // 
            this.rdThang.Checked = true;
            this.rdThang.Location = new System.Drawing.Point(9, 22);
            this.rdThang.Name = "rdThang";
            this.rdThang.Size = new System.Drawing.Size(64, 16);
            this.rdThang.TabIndex = 0;
            this.rdThang.TabStop = true;
            this.rdThang.Text = "Tháng";
            this.rdThang.CheckedChanged += new System.EventHandler(this.rdThang_CheckedChanged);
            this.rdThang.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rdThang_KeyDown);
            // 
            // txtNguoilapbang
            // 
            this.txtNguoilapbang.BackColor = System.Drawing.Color.White;
            this.txtNguoilapbang.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNguoilapbang.Location = new System.Drawing.Point(409, 261);
            this.txtNguoilapbang.MaxLength = 50;
            this.txtNguoilapbang.Name = "txtNguoilapbang";
            this.txtNguoilapbang.Size = new System.Drawing.Size(235, 21);
            this.txtNguoilapbang.TabIndex = 11;
            this.txtNguoilapbang.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNguoilapbang_KeyDown);
            // 
            // butInBK
            // 
            this.butInBK.BackColor = System.Drawing.SystemColors.Control;
            this.butInBK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butInBK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butInBK.ForeColor = System.Drawing.Color.Navy;
            this.butInBK.Image = ((System.Drawing.Image)(resources.GetObject("butInBK.Image")));
            this.butInBK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butInBK.Location = new System.Drawing.Point(494, 235);
            this.butInBK.Name = "butInBK";
            this.butInBK.Size = new System.Drawing.Size(70, 25);
            this.butInBK.TabIndex = 12;
            this.butInBK.Text = "     &In";
            this.butInBK.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butInBK.UseVisualStyleBackColor = true;
            this.butInBK.Click += new System.EventHandler(this.butInBK_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.BackColor = System.Drawing.SystemColors.Control;
            this.butKetthuc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butKetthuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butKetthuc.ForeColor = System.Drawing.Color.Navy;
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(563, 235);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(83, 25);
            this.butKetthuc.TabIndex = 13;
            this.butKetthuc.Text = "     &Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.UseVisualStyleBackColor = true;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // txtNgayIn
            // 
            this.txtNgayIn.CustomFormat = "dd/MM/yyyy hh:mm";
            this.txtNgayIn.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtNgayIn.Location = new System.Drawing.Point(409, 238);
            this.txtNgayIn.Name = "txtNgayIn";
            this.txtNgayIn.Size = new System.Drawing.Size(85, 20);
            this.txtNgayIn.TabIndex = 10;
            this.txtNgayIn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNgayIn_KeyDown);
            // 
            // label10
            // 
            this.label10.ForeColor = System.Drawing.Color.Navy;
            this.label10.Location = new System.Drawing.Point(328, 267);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(83, 13);
            this.label10.TabIndex = 149;
            this.label10.Text = "Người lập bảng ";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkUserid
            // 
            this.chkUserid.Location = new System.Drawing.Point(5, 2);
            this.chkUserid.Name = "chkUserid";
            this.chkUserid.Size = new System.Drawing.Size(268, 21);
            this.chkUserid.TabIndex = 0;
            this.chkUserid.TabStop = false;
            this.chkUserid.Text = "Nhân viên thu ngân (Quyển sổ)";
            this.chkUserid.CheckedChanged += new System.EventHandler(this.chkUserid_CheckedChanged);
            this.chkUserid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkUserid_KeyDown);
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(363, 243);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 79;
            this.label1.Text = "Ngày in";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkDoituong
            // 
            this.chkDoituong.Location = new System.Drawing.Point(221, 178);
            this.chkDoituong.Name = "chkDoituong";
            this.chkDoituong.Size = new System.Drawing.Size(78, 17);
            this.chkDoituong.TabIndex = 8;
            this.chkDoituong.TabStop = false;
            this.chkDoituong.Text = "Đối tượng";
            this.chkDoituong.CheckedChanged += new System.EventHandler(this.chkDoituong_CheckedChanged);
            this.chkDoituong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkDoituong_KeyDown);
            // 
            // chkLoaiBN
            // 
            this.chkLoaiBN.Location = new System.Drawing.Point(102, 178);
            this.chkLoaiBN.Name = "chkLoaiBN";
            this.chkLoaiBN.Size = new System.Drawing.Size(112, 17);
            this.chkLoaiBN.TabIndex = 6;
            this.chkLoaiBN.TabStop = false;
            this.chkLoaiBN.Text = "Loại bệnh nhân";
            this.chkLoaiBN.CheckedChanged += new System.EventHandler(this.chkLoaiBN_CheckedChanged);
            this.chkLoaiBN.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkLoaiBN_KeyDown);
            // 
            // chkLoaidv
            // 
            this.chkLoaidv.Location = new System.Drawing.Point(5, 178);
            this.chkLoaidv.Name = "chkLoaidv";
            this.chkLoaidv.Size = new System.Drawing.Size(48, 17);
            this.chkLoaidv.TabIndex = 4;
            this.chkLoaidv.TabStop = false;
            this.chkLoaidv.Text = "Loại";
            this.chkLoaidv.CheckedChanged += new System.EventHandler(this.chkLoaidv_CheckedChanged);
            this.chkLoaidv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkLoaidv_KeyDown);
            // 
            // label11
            // 
            this.label11.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label11.Location = new System.Drawing.Point(3, 369);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(686, 4);
            this.label11.TabIndex = 216;
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(3, 373);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(686, 20);
            this.progressBar1.TabIndex = 215;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmBaocaosobienlai
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(692, 396);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmBaocaosobienlai";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Báo cáo biên lai sử dụng";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmBaocaosobienlai_KeyDown);
            this.Load += new System.EventHandler(this.frmBaocaosobienlai_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.gbChungtu.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtThang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNam)).EndInit();
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
				//MessageBox.Show(this,"Chưa đăng nhập. Chỉ có quyền xem thông tin",m_v.s_AppName,MessageBoxButtons.OK,MessageBoxIcon.Warning);
				txtNguoilapbang.Tag="";
			}
			this.Text=this.Text+"/"+txtNguoilapbang.Tag.ToString().Trim();
		}
		private void frmBaocaosobienlai_Load(object sender, System.EventArgs e)
		{
			try
			{
				txtNgayIn.Value=System.DateTime.Now;
				//txtTN.Value=System.DateTime.Now;
				//txtDN.Value=System.DateTime.Now;
				txtThang.Value=decimal.Parse(System.DateTime.Now.Month.ToString());
				txtNam.Value=decimal.Parse(System.DateTime.Now.Year.ToString());
				txtThang_ValueChanged(null,null);
				f_Display_User();
				f_LoadHistory();
				f_Load_Tree_Userid();
				f_Load_tree_LoaiBN();
				f_Load_tree_LoaiDV();
				f_Load_Tree_Doituong();
                f_Load_CB_Maubaocao();
				rdThang_CheckedChanged(null,null);
			}
			catch
			{
			}
		}

        private DataSet f_Get_Maubaocaotructiep()
        {
            //v_maubaocao 
            //loai=1: Báo cáo thu viện phí trực tiếp (v_vienphill, v_vienphict, v_mienngtru, v_bhyt)
            //loai=2: Báo cáo thanh toán ra viện ngoại trú + nội trú (v_ttrvll, v_ttrvct, v_ttrvbhyt, v_ttrvds, v_miennoitru)
            //loai=3: Báo cáo thu tạm ứng
            //loai=4: Báo cáo miễn giảm
            //loai=5: Báo cáo tổng hợp
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
                ads = m_v.get_data("select ma, ten from medibv.v_maubaocao where loai=12");
                DataRow r = ads.Tables[0].NewRow();
                r["ma"] = "1";
                r["ten"] = lan.Change_language_MessageText("Mẫu báo cáo chung");
                ads.Tables[0].Rows.InsertAt(r, 0);
                DataRow r1 = ads.Tables[0].NewRow();
                r1["ma"] = "2";
                r1["ten"] = lan.Change_language_MessageText("Báo cáo tổng hợp doanh thu");
                ads.Tables[0].Rows.InsertAt(r1, 0);
                //DataRow r;
                //foreach (DataRow dr in m_v.get_data("select ma, ten from medibv.v_maubaocao where loai=12").Tables[0].Rows)
                //{
                //    r = ads.Tables[0].NewRow();
                //    r["ma"]=
                //}
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
                DataSet ads = new DataSet();
                ads = f_Get_Maubaocaotructiep();
                cboMaubaocao.DisplayMember = "TEN";
                cboMaubaocao.ValueMember = "MA";
                cboMaubaocao.DataSource = ads.Tables[0];
                cboMaubaocao.SelectedIndex = 0;
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
        private DataSet f_Sum_User_Bctonghop(DataSet v_ds)
        {
            int aindex = 0;
            DataSet ads = new DataSet();
            ads.Tables.Add("Table");
            ads.Tables[0].Columns.Add("userid");
            ads.Tables[0].Columns.Add("tenuserid");
            ads.Tables[0].Columns.Add("nguoithu");
            ads.Tables[0].Columns.Add("loaibl");
            ads.Tables[0].Columns.Add("ngay");
            ads.Tables[0].Columns.Add("kyhieu");
            ads.Tables[0].Columns.Add("soluong", typeof(decimal));
            ads.Tables[0].Columns.Add("tuden");
            ads.Tables[0].Columns.Add("vienphi", typeof(decimal));
            ads.Tables[0].Columns.Add("thuoc", typeof(decimal));
            ads.Tables[0].Columns.Add("tamung", typeof(decimal));
            ads.Tables[0].Columns.Add("soluong_huy", typeof(decimal));
            ads.Tables[0].Columns.Add("tuden_huy");
            decimal atu = 0, aden = 0, athuoc = 0, avienphi = 0, atamung = 0, asoluong = 0, asoluong_huy = 0;
            string aloaibl = "", angay = "", auserid = "", aquyensoid = "", atuden = "", atuden_huy = "", atenuser = "", anguoithu = "", akyhieu = "";
            try
            {
                string s_group = " userid, quyensoid, sobienlai ";
                if (rdNguoithu.Checked) s_group = " nguoithu, quyensoid, sobienlai ";
                DataRow[] dr0 = v_ds.Tables[0].Select("", s_group);
                if (dr0.Length > 0)
                {
                    aloaibl = dr0[0]["loaibl"].ToString(); //v_ds.Tables[0].Rows[0]["loaibl"].ToString();
                    angay = dr0[0]["ngay"].ToString(); //v_ds.Tables[0].Rows[0]["ngay"].ToString();
                    auserid = (rdNguoithu.Checked) ? dr0[0]["nguoithu"].ToString() : dr0[0]["userid"].ToString();
                    atenuser = dr0[0]["tenuserid"].ToString();
                    anguoithu = dr0[0]["nguoithu"].ToString();
                    aquyensoid = dr0[0]["quyensoid"].ToString();
                    akyhieu = dr0[0]["quyenso"].ToString();

                    atu = decimal.Parse(dr0[0]["sobienlai"].ToString());
                    aden = atu - 1;
                    atuden = decimal.Parse(dr0[0]["sobienlai"].ToString()).ToString().PadLeft(7, '0');
                }
                athuoc = 0;//decimal.Parse(v_ds.Tables[0].Rows[0]["sotien"].ToString());
                avienphi = 0;
                atamung = 0;
                asoluong = 0;
                asoluong_huy = 0;
                atuden_huy = "";
                DataRow dr_user;
                
                string s_nguoithu = (rdNguoithu.Checked) ? "nguoithu" : "userid";
                
                foreach (DataRow r in v_ds.Tables[0].Select("", s_group))//.Rows)//userid, quyensoid, sobienlai
                {                    
                    //if (aloaibl != r["loaibl"].ToString() || angay != r["ngay"].ToString() || auserid != r["userid"].ToString() || aquyensoid != r["quyensoid"].ToString() || (aden + 1 != decimal.Parse(r["sobienlai"].ToString())))//||(aindex>=alock))
                    if (aloaibl != r["loaibl"].ToString() || angay != r["ngay"].ToString() || auserid != r[s_nguoithu].ToString() || aquyensoid != r["quyensoid"].ToString() || (aden + 1 != decimal.Parse(r["sobienlai"].ToString()) && aden != decimal.Parse(r["sobienlai"].ToString())))//||(aindex>=alock))
                    {
                        atuden = atuden + " ... " + aden.ToString().PadLeft(7, '0');//decimal.Parse(r["sobienlai"].ToString()).ToString().PadLeft(7,'0');

                        DataRow r1 = ads.Tables[0].NewRow();
                        r1["userid"] = auserid;
                        r1["tenuserid"] = atenuser;
                        r1["nguoithu"] = anguoithu;
                        r1["loaibl"] = aloaibl;
                        r1["ngay"] = angay;
                        r1["kyhieu"] = akyhieu;
                        r1["soluong"] = asoluong.ToString();
                        r1["tuden"] = atuden;
                        r1["vienphi"] = avienphi.ToString();
                        r1["thuoc"] = athuoc.ToString();
                        r1["tamung"] = atamung.ToString();
                        r1["soluong_huy"] = asoluong_huy.ToString();
                        r1["tuden_huy"] = atuden_huy.Trim().Trim(',').Trim();
                        ads.Tables[0].Rows.Add(r1);

                        aloaibl = r["loaibl"].ToString();
                        angay = r["ngay"].ToString();
                        auserid = (rdNguoithu.Checked) ? r["nguoithu"].ToString() : r["userid"].ToString();
                        atenuser = r["tenuserid"].ToString();
                        anguoithu = r["nguoithu"].ToString();
                        aquyensoid = r["quyensoid"].ToString();
                        akyhieu = r["quyenso"].ToString();

                        atu = decimal.Parse(r["sobienlai"].ToString());
                        aden = atu;
                        atuden = atu.ToString().PadLeft(7, '0');

                        if (r["huy"].ToString() == "1")
                        {
                            asoluong = 0;
                            asoluong_huy = 1;
                            atuden_huy = atu.ToString().PadLeft(7, '0');
                            athuoc = 0;
                            avienphi = 0;
                            atamung = 0;
                        }
                        else
                        {
                            asoluong = 1;
                            asoluong_huy = 0;
                            atuden_huy = "";
                            athuoc = decimal.Parse(r["thuoc"].ToString());
                            avienphi = decimal.Parse(r["vienphi"].ToString());
                            atamung= decimal.Parse(r["tamung"].ToString());
                        }
                        aindex = 0;
                    }
                    else
                    {
                        aindex++;
                        if (r["huy"].ToString() == "1")
                        {
                            asoluong_huy = asoluong_huy + 1;
                            atuden_huy = atuden_huy.Trim().Trim(',') + ", " + decimal.Parse(r["sobienlai"].ToString()).ToString().PadLeft(7, '0');
                        }
                        else
                        {
                            if(decimal.Parse(r["sobienlai"].ToString())!=aden) asoluong = asoluong + 1;
                            //asotien = asotien + decimal.Parse(r["sotien"].ToString());
                            athuoc = athuoc+ decimal.Parse(r["thuoc"].ToString());
                            avienphi =avienphi+ decimal.Parse(r["vienphi"].ToString());
                            atamung =atamung+ decimal.Parse(r["tamung"].ToString());
                        }
                        aden = decimal.Parse(r["sobienlai"].ToString());
                    }
                }
                if(v_ds.Tables[0].Rows.Count>0) atuden = atuden + " ... " + decimal.Parse(v_ds.Tables[0].Rows[v_ds.Tables[0].Rows.Count - 1]["sobienlai"].ToString()).ToString().PadLeft(7, '0');
                DataRow r2 = ads.Tables[0].NewRow();
                r2["userid"] = auserid;
                r2["tenuserid"] = atenuser;
                r2["nguoithu"] = anguoithu;
                r2["loaibl"] = aloaibl;
                r2["ngay"] = angay;
                r2["kyhieu"] = akyhieu;
                r2["soluong"] = asoluong.ToString();
                r2["tuden"] = atuden;
                r2["thuoc"] = athuoc.ToString();
                r2["vienphi"] = avienphi.ToString();
                r2["tamung"] = atamung.ToString();
                r2["soluong_huy"] = asoluong_huy.ToString();
                r2["tuden_huy"] = atuden_huy.Trim().Trim(',').Trim();
                ads.Tables[0].Rows.Add(r2);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return ads;
        }
		private DataSet f_Sum_User(DataSet v_ds)
		{
			int aindex=0;
			DataSet ads = new DataSet();
			ads.Tables.Add("Table");
			ads.Tables[0].Columns.Add("userid");
			ads.Tables[0].Columns.Add("tenuserid");
			ads.Tables[0].Columns.Add("nguoithu");
			ads.Tables[0].Columns.Add("loaibl");
			ads.Tables[0].Columns.Add("ngay");
			ads.Tables[0].Columns.Add("kyhieu");
			ads.Tables[0].Columns.Add("soluong",typeof(decimal));
			ads.Tables[0].Columns.Add("tuden");
			ads.Tables[0].Columns.Add("sotien",typeof(decimal));
			ads.Tables[0].Columns.Add("soluong_huy",typeof(decimal));
			ads.Tables[0].Columns.Add("tuden_huy");
			decimal atu=0,aden=0,asotien=0,asoluong=0,asoluong_huy=0;
			string aloaibl="",angay="",auserid="",aquyensoid="",atuden="",atuden_huy="",atenuser="",anguoithu="",akyhieu="";
			try
			{
				aloaibl=v_ds.Tables[0].Rows[0]["loaibl"].ToString();
				angay=v_ds.Tables[0].Rows[0]["ngay"].ToString();
				auserid=v_ds.Tables[0].Rows[0]["userid"].ToString();
				atenuser=v_ds.Tables[0].Rows[0]["tenuserid"].ToString();
				anguoithu=v_ds.Tables[0].Rows[0]["nguoithu"].ToString();
				aquyensoid=v_ds.Tables[0].Rows[0]["quyensoid"].ToString();
				akyhieu=v_ds.Tables[0].Rows[0]["quyenso"].ToString();
						
				atu=decimal.Parse(v_ds.Tables[0].Rows[0]["sobienlai"].ToString());
				aden=atu-1;
				atuden=decimal.Parse(v_ds.Tables[0].Rows[0]["sobienlai"].ToString()).ToString().PadLeft(7,'0');
				asotien=0;//decimal.Parse(v_ds.Tables[0].Rows[0]["sotien"].ToString());
				
				asoluong=0;
				asoluong_huy=0;
				atuden_huy="";

				foreach(DataRow r in v_ds.Tables[0].Rows)
				{
					if(aloaibl!=r["loaibl"].ToString()||angay!=r["ngay"].ToString()||auserid!=r["userid"].ToString()||aquyensoid!=r["quyensoid"].ToString()||(aden+1!=decimal.Parse(r["sobienlai"].ToString())))//||(aindex>=alock))
					{
						atuden=atuden+" ... "+aden.ToString().PadLeft(7,'0');//decimal.Parse(r["sobienlai"].ToString()).ToString().PadLeft(7,'0');

						DataRow r1= ads.Tables[0].NewRow();
						r1["userid"]=auserid;
						r1["tenuserid"]=atenuser;
						r1["nguoithu"]=anguoithu;
						r1["loaibl"]=aloaibl;
						r1["ngay"]=angay;
						r1["kyhieu"]=akyhieu;
						r1["soluong"]=asoluong.ToString();
						r1["tuden"]=atuden;
						r1["sotien"]=asotien.ToString();
						r1["soluong_huy"]=asoluong_huy.ToString();
						r1["tuden_huy"]=atuden_huy.Trim().Trim(',').Trim();
						ads.Tables[0].Rows.Add(r1);
						
						aloaibl=r["loaibl"].ToString();
						angay=r["ngay"].ToString();
						auserid=r["userid"].ToString();
						atenuser=r["tenuserid"].ToString();
						anguoithu=r["nguoithu"].ToString();
						aquyensoid=r["quyensoid"].ToString();
						akyhieu=r["quyenso"].ToString();
						
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
							asotien=decimal.Parse(r["sotien"].ToString());
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
							asotien=asotien+decimal.Parse(r["sotien"].ToString());
						}
						aden=decimal.Parse(r["sobienlai"].ToString());
					}
				}
				atuden=atuden+" ... "+decimal.Parse(v_ds.Tables[0].Rows[v_ds.Tables[0].Rows.Count-1]["sobienlai"].ToString()).ToString().PadLeft(7,'0');
				DataRow r2= ads.Tables[0].NewRow();
				r2["userid"]=auserid;
				r2["tenuserid"]=atenuser;
				r2["nguoithu"]=anguoithu;
				r2["loaibl"]=aloaibl;
				r2["ngay"]=angay;
				r2["kyhieu"]=akyhieu;
				r2["soluong"]=asoluong.ToString();
				r2["tuden"]=atuden;
				r2["sotien"]=asotien.ToString();
				r2["soluong_huy"]=asoluong_huy.ToString();
				r2["tuden_huy"]=atuden_huy.Trim().Trim(',').Trim();
				ads.Tables[0].Rows.Add(r2);

                // 
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
			return ads;
		}
		private DataSet f_Sum_Toanvien(DataSet v_ds)
		{
			DataSet ads = new DataSet();
			ads.Tables.Add("Table");
			ads.Tables[0].Columns.Add("userid");
			ads.Tables[0].Columns.Add("tenuserid");
			ads.Tables[0].Columns.Add("nguoithu");
			ads.Tables[0].Columns.Add("loaibl");
			ads.Tables[0].Columns.Add("ngay");
			ads.Tables[0].Columns.Add("kyhieu");
			ads.Tables[0].Columns.Add("soluong",typeof(decimal));
			ads.Tables[0].Columns.Add("tuden");
			ads.Tables[0].Columns.Add("sotien",typeof(decimal));
			ads.Tables[0].Columns.Add("soluong_huy",typeof(decimal));
			ads.Tables[0].Columns.Add("tuden_huy");
			decimal atu=0,aden=0,asotien=0,asoluong=0,asoluong_huy=0;
			string aloaibl="",angay="",auserid="",aquyensoid="",atuden="",atuden_huy="",atenuser="",anguoithu="",akyhieu="",abhyt="";
			try
			{
				aloaibl=v_ds.Tables[0].Rows[0]["loaibl"].ToString();
				angay=v_ds.Tables[0].Rows[0]["ngay"].ToString();
				auserid=v_ds.Tables[0].Rows[0]["userid"].ToString();
				atenuser=v_ds.Tables[0].Rows[0]["tenuserid"].ToString();
				anguoithu=v_ds.Tables[0].Rows[0]["nguoithu"].ToString();
				aquyensoid=v_ds.Tables[0].Rows[0]["quyensoid"].ToString();
				akyhieu=v_ds.Tables[0].Rows[0]["quyenso"].ToString();
				abhyt=v_ds.Tables[0].Rows[0]["bhyt"].ToString();
						
				atu=decimal.Parse(v_ds.Tables[0].Rows[0]["sobienlai"].ToString());
				aden=atu-1;
				atuden=decimal.Parse(v_ds.Tables[0].Rows[0]["sobienlai"].ToString()).ToString().PadLeft(7,'0');
				asotien=0;//decimal.Parse(v_ds.Tables[0].Rows[0]["sotien"].ToString());
				
				asoluong=0;
				asoluong_huy=0;
				atuden_huy="";

				foreach(DataRow r in v_ds.Tables[0].Rows)
				{
					if(aquyensoid!=r["quyensoid"].ToString()||abhyt!=r["bhyt"].ToString()||(aden+1!=decimal.Parse(r["sobienlai"].ToString())))
					{
						atuden=atuden+" ... "+aden.ToString().PadLeft(7,'0');//decimal.Parse(r["sobienlai"].ToString()).ToString().PadLeft(7,'0');

						DataRow r1= ads.Tables[0].NewRow();
						r1["userid"]="";//auserid;
						r1["tenuserid"]="";//atenuser;
						r1["nguoithu"]="";
						r1["loaibl"]=aloaibl;
						if(aloaibl=="3")
						{
							r1["ngay"]=
lan.Change_language_MessageText("Tạm ứng");
						}
						else
						{
							r1["ngay"]=abhyt=="1"?
lan.Change_language_MessageText("BHYT"):
lan.Change_language_MessageText("Viện phí");
						}
						r1["kyhieu"]=akyhieu;
						r1["soluong"]=asoluong.ToString();
						r1["tuden"]=atuden;
						r1["sotien"]=asotien.ToString();
						r1["soluong_huy"]=asoluong_huy.ToString();
						r1["tuden_huy"]=atuden_huy.Trim().Trim(',').Trim();
						ads.Tables[0].Rows.Add(r1);
						
						aloaibl=r["loaibl"].ToString();
						angay=r["ngay"].ToString();
						auserid=r["userid"].ToString();
						atenuser=r["tenuserid"].ToString();
						anguoithu=r["nguoithu"].ToString();
						aquyensoid=r["quyensoid"].ToString();
						akyhieu=r["quyenso"].ToString();
						abhyt=r["bhyt"].ToString();
						
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
							asotien=decimal.Parse(r["sotien"].ToString());
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
							asotien=asotien+decimal.Parse(r["sotien"].ToString());
						}
						aden=decimal.Parse(r["sobienlai"].ToString());
					}
				}
				atuden=atuden+" ... "+decimal.Parse(v_ds.Tables[0].Rows[v_ds.Tables[0].Rows.Count-1]["sobienlai"].ToString()).ToString().PadLeft(7,'0');
				DataRow r2= ads.Tables[0].NewRow();
				r2["userid"]="";//auserid;
				r2["tenuserid"]="";//atenuser;
				r2["nguoithu"]="";//anguoithu;
				r2["loaibl"]=aloaibl;
				if(aloaibl=="3")
				{
					r2["ngay"]=
lan.Change_language_MessageText("Tạm ứng");
				}
				else
				{
					r2["ngay"]=abhyt=="1"?
lan.Change_language_MessageText("BHYT"):
lan.Change_language_MessageText("Viện phí");
				}
				r2["kyhieu"]=akyhieu;
				r2["soluong"]=asoluong.ToString();
				r2["tuden"]=atuden;
				r2["sotien"]=asotien.ToString();
				r2["soluong_huy"]=asoluong_huy.ToString();
				r2["tuden_huy"]=atuden_huy.Trim().Trim(',').Trim();
				ads.Tables[0].Rows.Add(r2);
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
			return ads;
		}
		private DataSet f_get_Data()
		{
			DataSet ads = new DataSet();
			try
			{
				string sql="", asort="",asqltt="", asqlnt="", asqltu="",exptt="", expnt="",exptu="", auserid="",aquyenso="", aloaibn="",aloaidv="",adoituong="";
				auserid=f_Get_CheckID(tree_User,1);
				aquyenso=f_Get_CheckID(tree_User,2);
				aloaibn=f_Get_CheckID(tree_LoaiBN);
				aloaidv=f_Get_CheckID(tree_Loaidv);
				adoituong=f_Get_CheckID(tree_Doituong);
                string a_nhomvp_thuoc = f_get_nhomthuoc();
				if(m_v.sys_dungchungso)
				{
					auserid = f_Get_CheckID(tree_User);
					aquyenso = f_Get_CheckID(tree_Quyenso);
				}

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
				if(aloaibn.Length>0)				
				{
					exptt=exptt + " and a.loaibn in("+aloaibn+")";
				}
				if(aloaidv.Length>0)				
				{
					exptt=exptt + " and a.loai in("+aloaidv+")";
				}
				exptu=exptt;
				expnt=exptt;

				if(adoituong!="")
				{
					if(adoituong.IndexOf("1")>=0)
					{
						exptt=exptt+" and g.id is not null";
						expnt=expnt+" and g.id is not null";
					}
					exptu=exptu+" and a.madoituong in ("+adoituong+")";
					exptt=exptt+" and b.madoituong in ("+adoituong+")";
					expnt=expnt+" and aa.madoituong in ("+adoituong+")";
				}
                string sql_vp = " select a.id from medibv.v_giavp a inner join medibv.v_loaivp b on a.id_loai=b.id " + ((a_nhomvp_thuoc != "") ? (" and b.id_nhom not in(" + a_nhomvp_thuoc + ")") : "");
                string sql_thuoc = " select id from medibv.d_dmbd ";
                sql_thuoc+=" union all  select a.id from medibv.v_giavp a inner join medibv.v_loaivp b on a.id_loai=b.id " + ((a_nhomvp_thuoc != "") ? (" and b.id_nhom in(" + a_nhomvp_thuoc + ")") : "");
                //
                asqltt = "select '1' loaibl, to_char(a.id) id, to_char(a.ngay,'dd/mm/yyyy') ngay";
                asqltt+=", to_char(a.quyenso) quyensoid, d.sohieu quyenso, to_char(a.sobienlai) sobienlai,";
                //asqltt += " sum(b.soluong*b.dongia-nvl(b.tra,0)-to_number(decode(b.madoituong,1,b.mien,0))-b.thieu)- nvl(c.sotien,0)as sotien";
                //asqltt += "case when b.mavp in (select id from medibv.v_giavp ) then (sum(b.soluong*b.dongia-nvl(b.tra,0)-to_number(decode(b.madoituong,1,b.mien,0))-b.thieu)- nvl(c.sotien,0)) else 0 end vienphi";
                //asqltt += " ,case when b.mavp in (select id from medibv.d_dmbd ) then (sum(b.soluong*b.dongia-nvl(b.tra,0)-to_number(decode(b.madoituong,1,b.mien,0))-b.thieu)- nvl(c.sotien,0)) else 0 end thuoc,";
                asqltt += "case when b.mavp in (" + sql_vp + " ) then (sum(b.soluong*b.dongia-nvl(b.tra,0)-to_number(decode(b.madoituong,1,b.mien,0))-b.thieu)- nvl(c.sotien,0)) else 0 end vienphi";
                asqltt += " ,case when b.mavp in (" + sql_thuoc + ") then (sum(b.soluong*b.dongia-nvl(b.tra,0)-to_number(decode(b.madoituong,1,b.mien,0))-b.thieu)- nvl(c.sotien,0)) else 0 end thuoc,";
                asqltt +=" 0 as tamung,e.hoten nguoithu, e.hoten||'('||e.userid||') - '||to_char(e.id) tenuserid, e.id userid,decode(f.id,null,'0','1') huy, decode(g.id,null,'0','1') bhyt";
                asqltt += " ,(sum(b.soluong*b.dongia-nvl(b.tra,0)-to_number(decode(b.madoituong,1,b.mien,0))-b.thieu)- nvl(c.sotien,0)) sotien";
                asqltt += " from medibvmmyy.v_vienphill a inner join medibvmmyy.v_vienphict b on a.id=b.id left join medibvmmyy.v_mienngtru c on a.id=c.id inner join medibv.v_quyenso d on a.quyenso=d.id inner join medibv.v_dlogin e on a.userid=e.id left join medibvmmyy.v_hoantra f on a.quyenso=f.quyenso and a.sobienlai=f.sobienlai left join medibvmmyy.v_bhyt g on a.id=g.id";
                asqltt += " where a.sobienlai>0 " + exptt ;
                //asqltt += " and b.mavp not in ( select id from medibv.v_giavp )";
                asqltt += " group by to_char(a.id),b.mavp, to_char(a.ngay,'dd/mm/yyyy'), to_char(a.quyenso), d.sohieu, to_char(a.sobienlai), e.hoten, e.hoten||'('||e.userid||') - '||to_char(e.id), e.id, c.sotien,decode(f.id,null,'0','1'),decode(g.id,null,'0','1')";

                asqlnt = "select '2' loaibl, to_char(a.id) id, to_char(a.ngay,'dd/mm/yyyy') ngay,";
                asqlnt+=" to_char(a.quyenso) quyensoid, d.sohieu quyenso, to_char(a.sobienlai) sobienlai,";
                //asqlnt += "case when aa.mavp in (select id from medibv.v_giavp ) then (nvl(a.sotien,0)-nvl(a.mien,0)-nvl(a.bhyt,0))  else 0 end vienphi, ";
                asqlnt += "sum(case when aa.mavp in (" + sql_vp + "  ) then (nvl(aa.sotien,0)-nvl(aa.bhyttra,0)-nvl(aa.tra,0))  else 0 end) vienphi, ";
                //asqlnt += "sum(case when aa.mavp in (select id from medibv.d_dmbd ) then (nvl(a.sotien,0)-nvl(a.mien,0)-nvl(a.bhyt,0))  else 0 end thuoc,";
                asqlnt += "sum(case when aa.mavp in (" + sql_thuoc + "  ) then (nvl(aa.sotien,0)-nvl(aa.bhyttra,0)-nvl(aa.tra,0))  else 0 end) thuoc, ";
                asqlnt += "  0 as tamung ,e.hoten nguoithu, e.hoten||'('||e.userid||') - '||to_char(e.id) tenuserid, e.id userid,decode(f.id,null,'0','1') huy, decode(g.id,null,'1','0') bhyt";
                asqlnt += " ,(nvl(a.sotien,0)-nvl(a.mien,0)-nvl(a.bhyt,0)) sotien";
                asqlnt += " from medibvmmyy.v_ttrvll a inner join medibvmmyy.v_ttrvct aa on a.id=aa.id left join medibvmmyy.v_miennoitru c on a.id=c.id inner join medibv.v_quyenso d on a.quyenso=d.id inner join medibv.v_dlogin e on a.userid=e.id left join medibvmmyy.v_hoantra f on a.quyenso=f.quyenso and a.sobienlai=f.sobienlai left join medibvmmyy.v_ttrvbhyt g on a.id=g.id where a.sobienlai>0 " + expnt;
                asqlnt += " group by to_char(a.id),to_char(a.ngay,'dd/mm/yyyy'), to_char(a.quyenso), d.sohieu, to_char(a.sobienlai), (nvl(a.sotien,0)-nvl(a.mien,0)-nvl(a.bhyt,0)), e.hoten, e.hoten||'('||e.userid||') - '||to_char(e.id), e.id,decode(f.id,null,'0','1'), g.id";//aa.mavp 

                asqltu = "select '3' loaibl, to_char(a.id) id, to_char(a.ngay,'dd/mm/yyyy') ngay, to_char(a.quyenso) quyensoid, d.sohieu quyenso, to_char(a.sobienlai) sobienlai, a.sotien as tamung, 0 as vienphi, 0 as thuoc, e.hoten nguoithu, e.hoten||'('||e.userid||') - '||to_char(e.id) tenuserid, e.id userid,  decode(f.id,null,'0','1') huy, decode(a.madoituong,null,'0','1'),a.sotien as sotien";
                asqltu += " from medibvmmyy.v_tamung a inner join medibv.v_quyenso d on a.quyenso=d.id inner join medibv.v_dlogin e on a.userid=e.id left join medibvmmyy.v_hoantra f on a.quyenso=f.quyenso and a.sobienlai=f.sobienlai where a.sobienlai>0 " + exptu + "";
				

				//asqlnt="select '2' loaibl, to_char(a.id) id, to_char(a.ngay,'dd/mm/yyyy') ngay, to_char(a.quyenso) quyensoid, d.sohieu quyenso, to_char(a.sobienlai) sobienlai, (nvl(a.sotien,0)-nvl(a.tamung,0)-nvl(a.mien,0)-nvl(a.bhyt,0)) sotien, e.hoten nguoithu, e.hoten||'('||e.userid||') - '||to_char(e.id) tenuserid, e.id userid, decode(f.id,null,'0','1') huy, decode(g.id,null,'0','1') bhyt from v_ttrvll a, v_ttrvct aa, v_miennoitru c, v_quyenso d, medibv.v_dlogin e, v_hoantra f, v_ttrvbhyt g where a.id=aa.id and a.id=c.id(+) and a.quyenso=d.id(+) and a.id=g.id(+) and a.quyenso=f.quyenso(+) and a.sobienlai=f.sobienlai(+) and a.userid=e.id and a.sobienlai>0 group by to_char(a.id), to_char(a.ngay,'dd/mm/yyyy'), to_char(a.quyenso), d.sohieu, to_char(a.sobienlai), (nvl(a.sotien,0)-nvl(a.tamung,0)-nvl(a.mien,0)-nvl(a.bhyt,0)), e.hoten, e.hoten||'('||e.userid||') - '||to_char(e.id), e.id, decode(f.id,null,'0','1'), decode(g.id,null,'0','1') "+exp+"";

				if(!chkTructiep.Checked&&!chkNoitru.Checked&&!chkTU.Checked)
				{
					sql="select * from (( "+asqltt+" union all "+ asqlnt + " union all "+asqltu +" )) froo ";
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

					if(chkTU.Checked)
					{
						if(sql.Length<=0)
						{
							sql="select * from ( "+asqltu;
						}
						else
						{
							sql=sql+ " union all "+ asqltu;
						}
					}

					if(sql.Length>0)
					{
						sql=sql + ") froo ";
					}
				}

				asort=" order by tenuserid asc, to_date(ngay,'dd/mm/yyyy') asc, to_number(quyensoid) asc, to_number(sobienlai) asc";
				if(rdToanvien.Checked)
				{
					asort=" order by to_number(quyensoid) asc, to_number(sobienlai) asc, bhyt asc";
				}

				sql=sql + asort;
				
				ads =m_v.get_data_bc(txtTN.Value,txtDN.Value,sql);
                //ads.WriteXml("D:\\trang\\thang 02\\baocaodoanhthutonghop01.xml", XmlWriteMode.WriteSchema);
			}
			catch
			{
			}
			return ads;
		}
        // 250310
		private void f_InBK_1()
		{
			try
			{
                if (cboMaubaocao.SelectedIndex == 0)
                {
                    //ads.WriteXml("..//..//Datareport//v_baocaosobienlai.xml", XmlWriteMode.WriteSchema);
                    DataSet ads = f_get_Data();
                    DataSet ds_bcth = new DataSet();
                    if (ads.Tables.Count > 0) ds_bcth = f_Sum_User_Bctonghop(ads);
                    //ds_bcth.WriteXml("D:\\trang\\thang 02\\baocaodoanhthutonghop.xml", XmlWriteMode.WriteSchema);
                    if ((ads == null) || (ads.Tables[0].Rows.Count <= 0))
                    {
                        progressBar1.Value = progressBar1.Maximum;
                        timer1.Enabled = false;
                        progressBar1.Value = 0;
                        MessageBox.Show(this,
                        lan.Change_language_MessageText("Không có dữ liệu báo cáo"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    af.WindowState = FormWindowState.Maximized;
                    af.Controls.Add(crystalReportViewer1);
                    crystalReportViewer1.BringToFront();
                    crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;

                    string areport = "v_baocaotonghop.rpt", asyt = "", abv = "", angayin = "", anguoiin = "", aghichu = "";
                    areport = "v_baocaotonghop.rpt";
                    asyt = m_v.Syte;
                    abv = m_v.Tenbv;
                    angayin =
                    lan.Change_language_MessageText("Ngày") + " " + txtNgayIn.Value.Day.ToString().PadLeft(2, '0') + " " +
                    lan.Change_language_MessageText("tháng") + " " + txtNgayIn.Value.Month.ToString().PadLeft(2, '0') + " " +

                    lan.Change_language_MessageText("năm") + " " + txtNgayIn.Value.Year.ToString();
                    anguoiin = txtNguoilapbang.Text.ToString();
                    aghichu = f_Get_GhiChu();

                    ReportDocument cMain = new ReportDocument();
                    areport = "v_baocaotonghop.rpt";
                    cMain.Load("..\\..\\..\\report\\"+areport, OpenReportMethod.OpenReportByTempCopy);
                    cMain.SetDataSource(ds_bcth);//f_Sum_User_Bctonghop(ads));
                    ////if(rdUser.Checked)
                    ////{
                    ////    areport="v_baocaosobienlai.rpt";
                    ////    cMain.Load("..\\..\\..\\report\\"+areport, OpenReportMethod.OpenReportByTempCopy);
                    ////    cMain.SetDataSource(f_Sum_User(ads));
                    ////}
                    ////else
                    ////{
                    ////    areport="v_baocaosobienlai_tv.rpt";
                    ////    cMain.Load("..\\..\\..\\report\\"+areport, OpenReportMethod.OpenReportByTempCopy);
                    ////    cMain.SetDataSource(f_Sum_Toanvien(ads));
                    ////}

                    ////if (cboMaubaocao.SelectedIndex > 0)
                    ////{
                    ////    string areportt = areport.Replace(".rpt", "_" + cboMaubaocao.SelectedValue.ToString().Trim() + ".rpt");
                    ////    if (System.IO.File.Exists("..\\..\\..\\report\\" + areportt))
                    ////    {
                    ////        areport = areportt;
                    ////    }
                    ////}

                    ////if(menuItem1.Checked)
                    ////{
                    ////    ads.WriteXml("..//..//Datareport//v_"+areport.Replace(".rpt","")+".xml", XmlWriteMode.WriteSchema);
                    ////}
                    cMain.DataDefinition.FormulaFields["v_syt"].Text = "'" + asyt.ToUpper() + "'";
                    cMain.DataDefinition.FormulaFields["v_bv"].Text = "'" + abv.ToUpper() + "'";
                    cMain.DataDefinition.FormulaFields["v_ngayin"].Text = "'" + angayin + "'";
                    cMain.DataDefinition.FormulaFields["v_nguoiin"].Text = "'" + anguoiin.ToUpper() + "'";
                    cMain.DataDefinition.FormulaFields["v_ghichu"].Text = "'" + aghichu + "'";
                    cMain.DataDefinition.FormulaFields["v_nguoilapbang"].Text = "'" + txtNguoilapbang.Text.Trim().ToUpper() + "'";
                    cMain.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
                    cMain.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
                    crystalReportViewer1.ReportSource = cMain;
                    af.Text = "Báo cáo số biên lai";
                    af.Text = af.Text + " (" + areport + ")";
                    af.ShowDialog();
                    //}
                    //else
                    //{
                    //    //ads.WriteXml("..//..//Datareport//v_baocaosobienlai.xml", XmlWriteMode.WriteSchema);
                    //    DataSet ads = f_get_Data();
                    //    //DataSet ds_bcth = new DataSet();
                    //    //ds_bcth = f_Sum_User_Bctonghop(ads);
                    //    //ds_bcth.WriteXml("D:\\trang\\thang 02\\baocaodoanhthutonghop.xml", XmlWriteMode.WriteSchema);
                    //    if ((ads == null) || (ads.Tables[0].Rows.Count <= 0))
                    //    {
                    //        progressBar1.Value = progressBar1.Maximum;
                    //        timer1.Enabled = false;
                    //        progressBar1.Value = 0;
                    //        MessageBox.Show(this,
                    //        lan.Change_language_MessageText("Không có dữ liệu báo cáo"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //        return;
                    //    }


                    //    CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
                    //    crystalReportViewer1.ActiveViewIndex = -1;
                    //    crystalReportViewer1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(239)), ((System.Byte)(239)), ((System.Byte)(239)));
                    //    crystalReportViewer1.DisplayGroupTree = false;
                    //    crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
                    //    crystalReportViewer1.Name = "crystalReportViewer1";
                    //    crystalReportViewer1.ReportSource = null;
                    //    crystalReportViewer1.Size = new System.Drawing.Size(792, 573);
                    //    crystalReportViewer1.TabIndex = 85;

                    //    System.Windows.Forms.Form af = new System.Windows.Forms.Form();
                    //    af.WindowState = FormWindowState.Maximized;
                    //    af.Controls.Add(crystalReportViewer1);
                    //    crystalReportViewer1.BringToFront();
                    //    crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;

                    //    string areport = "v_baocaosobienlai.rpt", asyt = "", abv = "", angayin = "", anguoiin = "", aghichu = "";
                    //    areport = "v_baocaosobienlai.rpt";
                    //    asyt = m_v.Syte;
                    //    abv = m_v.Tenbv;
                    //    angayin =
                    //    lan.Change_language_MessageText("Ngày") + " " + txtNgayIn.Value.Day.ToString().PadLeft(2, '0') + " " +
                    //    lan.Change_language_MessageText("tháng") + " " + txtNgayIn.Value.Month.ToString().PadLeft(2, '0') + " " +

                    //    lan.Change_language_MessageText("năm") + " " + txtNgayIn.Value.Year.ToString();
                    //    anguoiin = txtNguoilapbang.Text.ToString();
                    //    aghichu = f_Get_GhiChu();

                    //    ReportDocument cMain = new ReportDocument();
                    //    areport = "v_baocaosobienlai.rpt";
                    //    cMain.Load("..\\..\\..\\report\\" + areport, OpenReportMethod.OpenReportByTempCopy);
                    //    cMain.SetDataSource(f_Sum_User(ads));
                    //    if (rdUser.Checked)
                    //    {
                    //        areport = "v_baocaosobienlai.rpt";
                    //        cMain.Load("..\\..\\..\\report\\" + areport, OpenReportMethod.OpenReportByTempCopy);
                    //        cMain.SetDataSource(f_Sum_User(ads));
                    //    }
                    //    else
                    //    {
                    //        areport = "v_baocaosobienlai_tv.rpt";
                    //        cMain.Load("..\\..\\..\\report\\" + areport, OpenReportMethod.OpenReportByTempCopy);
                    //        cMain.SetDataSource(f_Sum_Toanvien(ads));
                    //    }

                    //    if (cboMaubaocao.SelectedIndex > 0)
                    //    {
                    //        string areportt = areport.Replace(".rpt", "_" + cboMaubaocao.SelectedValue.ToString().Trim() + ".rpt");
                    //        if (System.IO.File.Exists("..\\..\\..\\report\\" + areportt))
                    //        {
                    //            areport = areportt;
                    //        }
                    //    }

                    //    if (menuItem1.Checked)
                    //    {
                    //        ads.WriteXml("..//..//Datareport//v_" + areport.Replace(".rpt", "") + ".xml", XmlWriteMode.WriteSchema);
                    //    }
                    //    cMain.DataDefinition.FormulaFields["v_syt"].Text = "'" + asyt.ToUpper() + "'";
                    //    cMain.DataDefinition.FormulaFields["v_bv"].Text = "'" + abv.ToUpper() + "'";
                    //    cMain.DataDefinition.FormulaFields["v_ngayin"].Text = "'" + angayin + "'";
                    //    cMain.DataDefinition.FormulaFields["v_nguoiin"].Text = "'" + anguoiin.ToUpper() + "'";
                    //    cMain.DataDefinition.FormulaFields["v_ghichu"].Text = "'" + aghichu + "'";
                    //    cMain.DataDefinition.FormulaFields["v_nguoilapbang"].Text = "'" + txtNguoilapbang.Text.Trim().ToUpper() + "'";
                    //    cMain.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
                    //    cMain.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
                    //    crystalReportViewer1.ReportSource = cMain;
                    //    af.Text = "Báo cáo số biên lai";
                    //    af.Text = af.Text + " (" + areport + ")";
                    //    af.ShowDialog();
                    //}
                }
                else
                {
                    //ads.WriteXml("..//..//Datareport//v_baocaosobienlai.xml", XmlWriteMode.WriteSchema);
                    DataSet ads = f_get_Data();
                    DataSet ds_bcth = new DataSet();
                    ds_bcth = f_Sum_User_Bctonghop(ads);
                    //ds_bcth.WriteXml("D:\\trang\\thang 02\\baocaodoanhthutonghop.xml", XmlWriteMode.WriteSchema);
                    if ((ads == null) || (ads.Tables[0].Rows.Count <= 0))
                    {
                        progressBar1.Value = progressBar1.Maximum;
                        timer1.Enabled = false;
                        progressBar1.Value = 0;
                        MessageBox.Show(this,
                        lan.Change_language_MessageText("Không có dữ liệu báo cáo"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    af.WindowState = FormWindowState.Maximized;
                    af.Controls.Add(crystalReportViewer1);
                    crystalReportViewer1.BringToFront();
                    crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;

                    string areport = "v_baocaosobienlai.rpt", asyt = "", abv = "", angayin = "", anguoiin = "", aghichu = "";
                    areport = "v_baocaosobienlai.rpt";
                    asyt = m_v.Syte;
                    abv = m_v.Tenbv;
                    angayin =
                    lan.Change_language_MessageText("Ngày") + " " + txtNgayIn.Value.Day.ToString().PadLeft(2, '0') + " " +
                    lan.Change_language_MessageText("tháng") + " " + txtNgayIn.Value.Month.ToString().PadLeft(2, '0') + " " +

                    lan.Change_language_MessageText("năm") + " " + txtNgayIn.Value.Year.ToString();
                    anguoiin = txtNguoilapbang.Text.ToString();
                    aghichu = f_Get_GhiChu();

                    ReportDocument cMain = new ReportDocument();
                    areport = "v_baocaosobienlai.rpt";
                    cMain.Load("..\\..\\..\\report\\" + areport, OpenReportMethod.OpenReportByTempCopy);
                    cMain.SetDataSource(f_Sum_User(ads));
                    if (rdUser.Checked)
                    {
                        areport = "v_baocaosobienlai.rpt";
                        cMain.Load("..\\..\\..\\report\\" + areport, OpenReportMethod.OpenReportByTempCopy);
                        cMain.SetDataSource(f_Sum_User(ads));
                    }
                    else
                    {
                        areport = "v_baocaosobienlai_tv.rpt";
                        cMain.Load("..\\..\\..\\report\\" + areport, OpenReportMethod.OpenReportByTempCopy);
                        cMain.SetDataSource(f_Sum_Toanvien(ads));
                    }

                    if (cboMaubaocao.SelectedIndex > 0)
                    {
                        string areportt = areport.Replace(".rpt", "_" + cboMaubaocao.SelectedValue.ToString().Trim() + ".rpt");
                        if (System.IO.File.Exists("..\\..\\..\\report\\" + areportt))
                        {
                            areport = areportt;
                        }
                    }

                    if (menuItem1.Checked)
                    {
                        ads.WriteXml("..//..//Datareport//v_" + areport.Replace(".rpt", "") + ".xml", XmlWriteMode.WriteSchema);
                    }
                    cMain.DataDefinition.FormulaFields["v_syt"].Text = "'" + asyt.ToUpper() + "'";
                    cMain.DataDefinition.FormulaFields["v_bv"].Text = "'" + abv.ToUpper() + "'";
                    cMain.DataDefinition.FormulaFields["v_ngayin"].Text = "'" + angayin + "'";
                    cMain.DataDefinition.FormulaFields["v_nguoiin"].Text = "'" + anguoiin.ToUpper() + "'";
                    cMain.DataDefinition.FormulaFields["v_ghichu"].Text = "'" + aghichu + "'";
                    cMain.DataDefinition.FormulaFields["v_nguoilapbang"].Text = "'" + txtNguoilapbang.Text.Trim().ToUpper() + "'";
                    cMain.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
                    cMain.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
                    crystalReportViewer1.ReportSource = cMain;
                    af.Text = "Báo cáo số biên lai";
                    af.Text = af.Text + " (" + areport + ")";
                    af.ShowDialog();
                }                  
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
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
					string sql = "select to_char(a.id) as ma, trim(a.sohieu)||'     ('||to_char(a.tu)||' -->'||to_char(a.den)|| ')' as ten, to_char(b.id) as mar, trim(b.hoten)||' ('||b.userid||')' as tenr from medibv.v_quyenso a left join medibv.v_dlogin b on b.id=a.userid" + aexp + " order by b.id, b.hoten";
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
				string sql = "select to_char(id) as ma, sohieu as ten from medibv.v_quyenso where 1=1 " + aexp + " order by sohieu asc";
				f_Load_Tree(tree_Quyenso,m_v.get_data(sql));
				toolTip1.SetToolTip(tree_Quyenso,
lan.Change_language_MessageText("Ký hiệu biên lai"));
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
		private void f_Load_tree_LoaiDV()
		{
			try
			{
				string sql = "select to_char(ma) as ma, ten from medibv.v_tenloaivp order by ten asc";
				f_Load_Tree(tree_Loaidv,m_v.get_data(sql));
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
		private void f_SaveHistory()
		{
			try
			{
				DataSet ads = new DataSet();
				ads.Tables.Add("Baocaosobienlai");
				ads.Tables[0].Columns.Add("nguoilapbang");
				ads.Tables[0].Rows.Add(new string[] {txtNguoilapbang.Text.Trim()});
				ads.WriteXml("...//...//option//v_optionbaocaosobienlai.xml",XmlWriteMode.WriteSchema);
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
				//DataSet ads = new DataSet();
				//ads.ReadXml("...//...//option//v_optionbaocaosobienlai.xml");
				txtNguoilapbang.Text=txtNguoilapbang.Tag.ToString();//ads.Tables[0].Rows[0]["nguoilapbang"].ToString();
			}
			catch
			{
			}
		}
		private void butInBK_Click(object sender, System.EventArgs e)
		{	
			string atmp=System.Environment.CurrentDirectory;
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
				progressBar1.Value=1;
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
		private string f_Get_GhiChu()
		{
			try
			{
				string r="";
				DateTime ad1 = new DateTime(txtTN.Value.Year,txtTN.Value.Month,txtTN.Value.Day);
				DateTime ad2 = new DateTime(txtDN.Value.Year,txtDN.Value.Month,txtDN.Value.Day);
				if(rdThang.Checked)
				{
					r=
lan.Change_language_MessageText("(Tháng")+" "+txtThang.Value.ToString().PadLeft(2,'0')+" "+
lan.Change_language_MessageText("Năm")+" "+txtNam.Value.ToString()+")";
				}
				else
				{
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

		private void frmBaocaosobienlai_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			try
			{
				if(e.KeyCode==Keys.F12)
				{
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

		private void frmBaocaosobienlai_SizeChanged(object sender, System.EventArgs e)
		{
		}

		private void chkUserid_CheckedChanged(object sender, System.EventArgs e)
		{
			f_Set_CheckID(tree_User,chkUserid.Checked);
		}

		private void chkLoaiBN_CheckedChanged(object sender, System.EventArgs e)
		{
			f_Set_CheckID(tree_LoaiBN,chkLoaiBN.Checked);
		}

		private void chkLoaidv_CheckedChanged(object sender, System.EventArgs e)
		{
			f_Set_CheckID(tree_Loaidv,chkLoaidv.Checked);
		}

		private void chkDoituong_CheckedChanged(object sender, System.EventArgs e)
		{
			f_Set_CheckID(tree_Doituong,chkDoituong.Checked);
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

		private void rdThang_CheckedChanged(object sender, System.EventArgs e)
		{
			try
			{
				txtThang.Enabled=rdThang.Checked;
				txtNam.Enabled=rdThang.Checked;
				txtTN.Enabled=rdNgay.Checked;
				txtDN.Enabled=rdNgay.Checked;
			}
			catch
			{
			}
		}

		private void rdNgay_CheckedChanged(object sender, System.EventArgs e)
		{
			try
			{
				txtThang.Enabled=rdThang.Checked;
				txtNam.Enabled=rdThang.Checked;
				txtTN.Enabled=rdNgay.Checked;
				txtDN.Enabled=rdNgay.Checked;
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
					//SendKeys.Send("{Tab}");
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
					//SendKeys.Send("{Tab}");
					butInBK.Focus();
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

		private void tree_User_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
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

		private void chkLoaiBN_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
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

		private void tree_LoaiBN_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
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

		private void chkLoaidv_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
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

		private void tree_Loaidv_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
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

		private void chkDoituong_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
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

		private void tree_Doituong_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
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

				amsg=lan.Change_language_MessageText("Đã chọn:")+"\n"+lan.Change_language_MessageText("Nhân viên thu ngân:")+" "+anu.ToString()+"\n"+lan.Change_language_MessageText("Quyển sổ thu tiền:")+" "+ans.ToString();
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

		private void tree_Loaidv_AfterCheck(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			try
			{
				e.Node.ForeColor=e.Node.Checked?Color.Navy:Color.DimGray;
				for(int i=0;i<tree_Loaidv.Nodes.Count;i++)
				{
					if(tree_Loaidv.Nodes[i].Checked)
					{
						return;
					}
				}
				chkLoaidv.Checked=false;
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

		private void txtTN_ValueChanged(object sender, System.EventArgs e)
		{
		
		}

		private void txtDN_ValueChanged(object sender, System.EventArgs e)
		{
		
		}

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cboMaubaocao_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private string f_get_nhomthuoc()
        {
            string s_nhomvp_thuoc = "";
            string sql = "select distinct nhomvp from medibv.d_dmnhom where nhom=" + m_v.nhom_duoc;
            foreach (DataRow r in m_v.get_data(sql).Tables[0].Rows)
            {
                s_nhomvp_thuoc += r["nhomvp"].ToString() + ",";
            }
            return s_nhomvp_thuoc.Trim().Trim(',');
        }
	}
}
