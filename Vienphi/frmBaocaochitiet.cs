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
	/// Summary description for frmBaocaochitiet.
	/// </summary>
	public class frmBaocaochitiet : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private string m_userid="";
		private LibVP.AccessData m_v = LibVP.AccessData.GetImplement();
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label lbTitle;
		private System.Windows.Forms.Label lbNgayDN;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label lbNguoiDN;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button butKetthuc;
		private System.Windows.Forms.Button butInBK;
		private System.Windows.Forms.DateTimePicker txtNgayIn;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.GroupBox gbLoaibn;
		private System.Windows.Forms.CheckBox chkNoitru;
		private System.Windows.Forms.CheckBox chkPhongkham;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton rdNgay;
		private System.Windows.Forms.RadioButton rdThang;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker txtDN;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.NumericUpDown txtThang;
		private System.Windows.Forms.NumericUpDown txtNam;
		private System.Windows.Forms.DateTimePicker txtTN;
		private System.Windows.Forms.TreeView tree_User;
		private System.Windows.Forms.CheckBox chkUserid;
		private System.Windows.Forms.TreeView tree_Loaibn;
		private System.Windows.Forms.CheckBox chkLoaibn;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.ComboBox cbMaubaocao;
		private System.Windows.Forms.CheckBox chkVP;
        private System.Windows.Forms.Label lbKhaibao;
		private System.Windows.Forms.TreeView tree_VP;
		private System.Windows.Forms.TreeView tree_Doituong;
		private System.Windows.Forms.CheckBox chkDoituong;
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
		private System.Windows.Forms.CheckBox chkNgoaitru;
        private TextBox txtThuquy;
        private TextBox txtNguoilapbang;
        private TextBox txtPhongtckt;
        private TextBox txtKetoanvp;
        private Label label8;
        private Label label5;
        private Label label4;
        private Label label6;
        private CheckBox checkBox1;
		private System.ComponentModel.IContainer components;

		public frmBaocaochitiet(string v_userid)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);

			m_userid=v_userid;
			f_SetEvent(panel2);
            f_load_data();
            

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBaocaochitiet));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbTitle = new System.Windows.Forms.Label();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.lbNgayDN = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbNguoiDN = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tree_VP = new System.Windows.Forms.TreeView();
            this.txtThuquy = new System.Windows.Forms.TextBox();
            this.txtNguoilapbang = new System.Windows.Forms.TextBox();
            this.txtPhongtckt = new System.Windows.Forms.TextBox();
            this.txtKetoanvp = new System.Windows.Forms.TextBox();
            this.tree_Quyenso = new System.Windows.Forms.TreeView();
            this.timso = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tree_User = new System.Windows.Forms.TreeView();
            this.contextMenu2 = new System.Windows.Forms.ContextMenu();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.tree_Doituong = new System.Windows.Forms.TreeView();
            this.chkDoituong = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.chkVP = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cbMaubaocao = new System.Windows.Forms.ComboBox();
            this.txtNgayIn = new System.Windows.Forms.DateTimePicker();
            this.tree_Loaibn = new System.Windows.Forms.TreeView();
            this.chkLoaibn = new System.Windows.Forms.CheckBox();
            this.chkUserid = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdNgay = new System.Windows.Forms.RadioButton();
            this.rdThang = new System.Windows.Forms.RadioButton();
            this.txtDN = new System.Windows.Forms.DateTimePicker();
            this.txtThang = new System.Windows.Forms.NumericUpDown();
            this.txtNam = new System.Windows.Forms.NumericUpDown();
            this.txtTN = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.gbLoaibn = new System.Windows.Forms.GroupBox();
            this.chkNgoaitru = new System.Windows.Forms.CheckBox();
            this.chkPhongkham = new System.Windows.Forms.CheckBox();
            this.chkNoitru = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.butInBK = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.lbKhaibao = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtThang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNam)).BeginInit();
            this.gbLoaibn.SuspendLayout();
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
            this.panel1.Size = new System.Drawing.Size(685, 49);
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
            this.lbTitle.Text = "  BÁO CÁO CHI TIẾT THU VIỆN PHÍ";
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
            // lbNgayDN
            // 
            this.lbNgayDN.ForeColor = System.Drawing.Color.White;
            this.lbNgayDN.Location = new System.Drawing.Point(428, 26);
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
            this.lbNguoiDN.Location = new System.Drawing.Point(428, 8);
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
            this.label15.Size = new System.Drawing.Size(685, 3);
            this.label15.TabIndex = 17;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(5)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.tree_VP);
            this.panel2.Controls.Add(this.txtThuquy);
            this.panel2.Controls.Add(this.txtNguoilapbang);
            this.panel2.Controls.Add(this.txtPhongtckt);
            this.panel2.Controls.Add(this.txtKetoanvp);
            this.panel2.Controls.Add(this.tree_Quyenso);
            this.panel2.Controls.Add(this.timso);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.tree_User);
            this.panel2.Controls.Add(this.tree_Doituong);
            this.panel2.Controls.Add(this.chkDoituong);
            this.panel2.Controls.Add(this.checkBox1);
            this.panel2.Controls.Add(this.chkVP);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.cbMaubaocao);
            this.panel2.Controls.Add(this.txtNgayIn);
            this.panel2.Controls.Add(this.tree_Loaibn);
            this.panel2.Controls.Add(this.chkLoaibn);
            this.panel2.Controls.Add(this.chkUserid);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.gbLoaibn);
            this.panel2.Controls.Add(this.butInBK);
            this.panel2.Controls.Add(this.butKetthuc);
            this.panel2.Controls.Add(this.lbKhaibao);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.ForeColor = System.Drawing.Color.Navy;
            this.panel2.Location = new System.Drawing.Point(3, 55);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(685, 414);
            this.panel2.TabIndex = 18;
            // 
            // tree_VP
            // 
            this.tree_VP.CheckBoxes = true;
            this.tree_VP.ForeColor = System.Drawing.Color.DimGray;
            this.tree_VP.FullRowSelect = true;
            this.tree_VP.Location = new System.Drawing.Point(281, 206);
            this.tree_VP.Name = "tree_VP";
            this.tree_VP.ShowLines = false;
            this.tree_VP.ShowPlusMinus = false;
            this.tree_VP.ShowRootLines = false;
            this.tree_VP.Size = new System.Drawing.Size(399, 180);
            this.tree_VP.Sorted = true;
            this.tree_VP.TabIndex = 199;
            this.tree_VP.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tree_VP_AfterCheck);
            // 
            // txtThuquy
            // 
            this.txtThuquy.BackColor = System.Drawing.Color.White;
            this.txtThuquy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtThuquy.Location = new System.Drawing.Point(525, 134);
            this.txtThuquy.MaxLength = 50;
            this.txtThuquy.Name = "txtThuquy";
            this.txtThuquy.Size = new System.Drawing.Size(154, 21);
            this.txtThuquy.TabIndex = 211;
            // 
            // txtNguoilapbang
            // 
            this.txtNguoilapbang.BackColor = System.Drawing.Color.White;
            this.txtNguoilapbang.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNguoilapbang.Location = new System.Drawing.Point(525, 90);
            this.txtNguoilapbang.MaxLength = 50;
            this.txtNguoilapbang.Name = "txtNguoilapbang";
            this.txtNguoilapbang.Size = new System.Drawing.Size(154, 21);
            this.txtNguoilapbang.TabIndex = 209;
            // 
            // txtPhongtckt
            // 
            this.txtPhongtckt.BackColor = System.Drawing.Color.White;
            this.txtPhongtckt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhongtckt.Location = new System.Drawing.Point(525, 156);
            this.txtPhongtckt.MaxLength = 50;
            this.txtPhongtckt.Name = "txtPhongtckt";
            this.txtPhongtckt.Size = new System.Drawing.Size(154, 21);
            this.txtPhongtckt.TabIndex = 212;
            // 
            // txtKetoanvp
            // 
            this.txtKetoanvp.BackColor = System.Drawing.Color.White;
            this.txtKetoanvp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKetoanvp.Location = new System.Drawing.Point(525, 112);
            this.txtKetoanvp.MaxLength = 50;
            this.txtKetoanvp.Name = "txtKetoanvp";
            this.txtKetoanvp.Size = new System.Drawing.Size(154, 21);
            this.txtKetoanvp.TabIndex = 210;
            // 
            // tree_Quyenso
            // 
            this.tree_Quyenso.CheckBoxes = true;
            this.tree_Quyenso.ForeColor = System.Drawing.Color.DimGray;
            this.tree_Quyenso.FullRowSelect = true;
            this.tree_Quyenso.Location = new System.Drawing.Point(156, 21);
            this.tree_Quyenso.Name = "tree_Quyenso";
            this.tree_Quyenso.ShowLines = false;
            this.tree_Quyenso.ShowPlusMinus = false;
            this.tree_Quyenso.ShowRootLines = false;
            this.tree_Quyenso.Size = new System.Drawing.Size(124, 184);
            this.tree_Quyenso.Sorted = true;
            this.tree_Quyenso.TabIndex = 208;
            // 
            // timso
            // 
            this.timso.BackColor = System.Drawing.Color.White;
            this.timso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timso.Location = new System.Drawing.Point(5, 206);
            this.timso.MaxLength = 12;
            this.timso.Name = "timso";
            this.timso.Size = new System.Drawing.Size(275, 21);
            this.timso.TabIndex = 207;
            this.timso.Text = "Tìm sổ";
            this.timso.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.timso.TextChanged += new System.EventHandler(this.timso_TextChanged);
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(534, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Ngày in";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.tree_User.Size = new System.Drawing.Size(275, 184);
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
            // tree_Doituong
            // 
            this.tree_Doituong.CheckBoxes = true;
            this.tree_Doituong.ForeColor = System.Drawing.Color.DimGray;
            this.tree_Doituong.FullRowSelect = true;
            this.tree_Doituong.Location = new System.Drawing.Point(142, 246);
            this.tree_Doituong.Name = "tree_Doituong";
            this.tree_Doituong.ShowLines = false;
            this.tree_Doituong.ShowPlusMinus = false;
            this.tree_Doituong.ShowRootLines = false;
            this.tree_Doituong.Size = new System.Drawing.Size(137, 140);
            this.tree_Doituong.Sorted = true;
            this.tree_Doituong.TabIndex = 204;
            this.tree_Doituong.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tree_Doituong_AfterCheck);
            // 
            // chkDoituong
            // 
            this.chkDoituong.Location = new System.Drawing.Point(142, 230);
            this.chkDoituong.Name = "chkDoituong";
            this.chkDoituong.Size = new System.Drawing.Size(133, 17);
            this.chkDoituong.TabIndex = 203;
            this.chkDoituong.TabStop = false;
            this.chkDoituong.Text = "Đối tượng";
            this.chkDoituong.CheckedChanged += new System.EventHandler(this.chkDoituong_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox1.Location = new System.Drawing.Point(417, 185);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(112, 17);
            this.checkBox1.TabIndex = 198;
            this.checkBox1.TabStop = false;
            this.checkBox1.Text = "Xem trước khi in";
            this.checkBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkVP_KeyDown);
            // 
            // chkVP
            // 
            this.chkVP.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkVP.Location = new System.Drawing.Point(282, 185);
            this.chkVP.Name = "chkVP";
            this.chkVP.Size = new System.Drawing.Size(168, 17);
            this.chkVP.TabIndex = 198;
            this.chkVP.TabStop = false;
            this.chkVP.Text = "Nội dung thu viện phí";
            this.chkVP.CheckedChanged += new System.EventHandler(this.chkVP_CheckedChanged);
            this.chkVP.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkVP_KeyDown);
            // 
            // label9
            // 
            this.label9.ForeColor = System.Drawing.Color.Navy;
            this.label9.Location = new System.Drawing.Point(267, 388);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 21);
            this.label9.TabIndex = 197;
            this.label9.Text = "Mẫu báo cáo";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbMaubaocao
            // 
            this.cbMaubaocao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMaubaocao.Location = new System.Drawing.Point(348, 388);
            this.cbMaubaocao.Name = "cbMaubaocao";
            this.cbMaubaocao.Size = new System.Drawing.Size(331, 21);
            this.cbMaubaocao.TabIndex = 196;
            // 
            // txtNgayIn
            // 
            this.txtNgayIn.CustomFormat = "dd/MM/yyyy hh:mm";
            this.txtNgayIn.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtNgayIn.Location = new System.Drawing.Point(591, 2);
            this.txtNgayIn.Name = "txtNgayIn";
            this.txtNgayIn.Size = new System.Drawing.Size(85, 20);
            this.txtNgayIn.TabIndex = 10;
            this.txtNgayIn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNgayIn_KeyDown);
            // 
            // tree_Loaibn
            // 
            this.tree_Loaibn.CheckBoxes = true;
            this.tree_Loaibn.ForeColor = System.Drawing.Color.DimGray;
            this.tree_Loaibn.FullRowSelect = true;
            this.tree_Loaibn.Location = new System.Drawing.Point(5, 246);
            this.tree_Loaibn.Name = "tree_Loaibn";
            this.tree_Loaibn.ShowLines = false;
            this.tree_Loaibn.ShowPlusMinus = false;
            this.tree_Loaibn.ShowRootLines = false;
            this.tree_Loaibn.Size = new System.Drawing.Size(136, 140);
            this.tree_Loaibn.Sorted = true;
            this.tree_Loaibn.TabIndex = 5;
            this.tree_Loaibn.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tree_Loaibn_AfterCheck);
            this.tree_Loaibn.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tree_Loaibn_AfterSelect);
            this.tree_Loaibn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tree_Loaibn_KeyDown);
            // 
            // chkLoaibn
            // 
            this.chkLoaibn.Location = new System.Drawing.Point(5, 230);
            this.chkLoaibn.Name = "chkLoaibn";
            this.chkLoaibn.Size = new System.Drawing.Size(136, 17);
            this.chkLoaibn.TabIndex = 4;
            this.chkLoaibn.TabStop = false;
            this.chkLoaibn.Text = "Loại bệnh nhân";
            this.chkLoaibn.CheckedChanged += new System.EventHandler(this.chkLoaibn_CheckedChanged);
            this.chkLoaibn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkLoaibn_KeyDown);
            // 
            // chkUserid
            // 
            this.chkUserid.Location = new System.Drawing.Point(5, 5);
            this.chkUserid.Name = "chkUserid";
            this.chkUserid.Size = new System.Drawing.Size(200, 17);
            this.chkUserid.TabIndex = 0;
            this.chkUserid.TabStop = false;
            this.chkUserid.Text = "Nhân viên thu ngân (Quyển sổ)";
            this.chkUserid.CheckedChanged += new System.EventHandler(this.chkUserid_CheckedChanged);
            this.chkUserid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkUserid_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdNgay);
            this.groupBox1.Controls.Add(this.rdThang);
            this.groupBox1.Controls.Add(this.txtDN);
            this.groupBox1.Controls.Add(this.txtThang);
            this.groupBox1.Controls.Add(this.txtNam);
            this.groupBox1.Controls.Add(this.txtTN);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(283, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(303, 70);
            this.groupBox1.TabIndex = 159;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thời gian báo cáo";
            // 
            // rdNgay
            // 
            this.rdNgay.Checked = true;
            this.rdNgay.Location = new System.Drawing.Point(8, 40);
            this.rdNgay.Name = "rdNgay";
            this.rdNgay.Size = new System.Drawing.Size(64, 20);
            this.rdNgay.TabIndex = 3;
            this.rdNgay.TabStop = true;
            this.rdNgay.Text = "Từ ngày";
            this.rdNgay.CheckedChanged += new System.EventHandler(this.rdNgay_CheckedChanged);
            this.rdNgay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rdNgay_KeyDown);
            // 
            // rdThang
            // 
            this.rdThang.Location = new System.Drawing.Point(8, 18);
            this.rdThang.Name = "rdThang";
            this.rdThang.Size = new System.Drawing.Size(64, 19);
            this.rdThang.TabIndex = 0;
            this.rdThang.Text = "Tháng";
            this.rdThang.CheckedChanged += new System.EventHandler(this.rdThang_CheckedChanged);
            this.rdThang.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rdThang_KeyDown);
            // 
            // txtDN
            // 
            this.txtDN.CustomFormat = "dd/MM/yyyy hh:mm";
            this.txtDN.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtDN.Location = new System.Drawing.Point(210, 40);
            this.txtDN.Name = "txtDN";
            this.txtDN.Size = new System.Drawing.Size(85, 20);
            this.txtDN.TabIndex = 5;
            this.txtDN.Validated += new System.EventHandler(this.txtDN_Validated);
            this.txtDN.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDN_KeyDown);
            // 
            // txtThang
            // 
            this.txtThang.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtThang.Location = new System.Drawing.Point(72, 17);
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
            this.txtThang.Validated += new System.EventHandler(this.txtThang_Validated);
            this.txtThang.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtThang_KeyDown);
            // 
            // txtNam
            // 
            this.txtNam.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNam.Location = new System.Drawing.Point(210, 17);
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
            this.txtTN.Location = new System.Drawing.Point(72, 40);
            this.txtTN.Name = "txtTN";
            this.txtTN.Size = new System.Drawing.Size(85, 20);
            this.txtTN.TabIndex = 4;
            this.txtTN.Validated += new System.EventHandler(this.txtTN_Validated);
            this.txtTN.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTN_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(182, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Năm";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(157, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 154;
            this.label3.Text = "Đến ngày";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gbLoaibn
            // 
            this.gbLoaibn.Controls.Add(this.chkNgoaitru);
            this.gbLoaibn.Controls.Add(this.chkPhongkham);
            this.gbLoaibn.Controls.Add(this.chkNoitru);
            this.gbLoaibn.Controls.Add(this.label7);
            this.gbLoaibn.Location = new System.Drawing.Point(283, 87);
            this.gbLoaibn.Name = "gbLoaibn";
            this.gbLoaibn.Size = new System.Drawing.Size(157, 84);
            this.gbLoaibn.TabIndex = 8;
            this.gbLoaibn.TabStop = false;
            this.gbLoaibn.Tag = "0";
            this.gbLoaibn.Text = "Chứng từ";
            // 
            // chkNgoaitru
            // 
            this.chkNgoaitru.Checked = true;
            this.chkNgoaitru.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNgoaitru.Location = new System.Drawing.Point(9, 60);
            this.chkNgoaitru.Name = "chkNgoaitru";
            this.chkNgoaitru.Size = new System.Drawing.Size(127, 21);
            this.chkNgoaitru.TabIndex = 2;
            this.chkNgoaitru.Text = "BHYT ngoại trú";
            // 
            // chkPhongkham
            // 
            this.chkPhongkham.Checked = true;
            this.chkPhongkham.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPhongkham.Location = new System.Drawing.Point(9, 37);
            this.chkPhongkham.Name = "chkPhongkham";
            this.chkPhongkham.Size = new System.Drawing.Size(127, 21);
            this.chkPhongkham.TabIndex = 1;
            this.chkPhongkham.Text = "Thu trực tiếp";
            // 
            // chkNoitru
            // 
            this.chkNoitru.Checked = true;
            this.chkNoitru.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNoitru.Location = new System.Drawing.Point(9, 16);
            this.chkNoitru.Name = "chkNoitru";
            this.chkNoitru.Size = new System.Drawing.Size(127, 21);
            this.chkNoitru.TabIndex = 0;
            this.chkNoitru.Text = "Thanh toán ra viện";
            this.chkNoitru.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkNoitru_KeyDown);
            // 
            // label7
            // 
            this.label7.Dock = System.Windows.Forms.DockStyle.Left;
            this.label7.ForeColor = System.Drawing.Color.Navy;
            this.label7.Location = new System.Drawing.Point(3, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(6, 65);
            this.label7.TabIndex = 0;
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butInBK
            // 
            this.butInBK.BackColor = System.Drawing.SystemColors.Control;
            this.butInBK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butInBK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butInBK.ForeColor = System.Drawing.Color.Navy;
            this.butInBK.Image = ((System.Drawing.Image)(resources.GetObject("butInBK.Image")));
            this.butInBK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butInBK.Location = new System.Drawing.Point(589, 26);
            this.butInBK.Name = "butInBK";
            this.butInBK.Size = new System.Drawing.Size(89, 28);
            this.butInBK.TabIndex = 6;
            this.butInBK.Text = "      &Xem";
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
            this.butKetthuc.Location = new System.Drawing.Point(589, 54);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(89, 28);
            this.butKetthuc.TabIndex = 7;
            this.butKetthuc.Text = "     &Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.UseVisualStyleBackColor = true;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            this.butKetthuc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.butKetthuc_KeyDown);
            // 
            // lbKhaibao
            // 
            this.lbKhaibao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbKhaibao.Image = ((System.Drawing.Image)(resources.GetObject("lbKhaibao.Image")));
            this.lbKhaibao.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbKhaibao.Location = new System.Drawing.Point(612, 186);
            this.lbKhaibao.Name = "lbKhaibao";
            this.lbKhaibao.Size = new System.Drawing.Size(67, 17);
            this.lbKhaibao.TabIndex = 200;
            this.lbKhaibao.Text = "Khai báo";
            this.lbKhaibao.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbKhaibao.Click += new System.EventHandler(this.lbKhaibao_Click);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(438, 90);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 21);
            this.label8.TabIndex = 216;
            this.label8.Text = "Người lập phiếu:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(437, 156);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 21);
            this.label5.TabIndex = 215;
            this.label5.Text = "Phòng TCKT:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(437, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 21);
            this.label4.TabIndex = 214;
            this.label4.Text = "Kế toán VP:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(437, 134);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 21);
            this.label6.TabIndex = 213;
            this.label6.Text = "Thủ quỹ:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label11.Location = new System.Drawing.Point(3, 469);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(685, 4);
            this.label11.TabIndex = 210;
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(3, 473);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(685, 20);
            this.progressBar1.TabIndex = 209;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmBaocaochitiet
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(691, 496);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBaocaochitiet";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Báo cáo chi tiết thu viện phí";
            this.Load += new System.EventHandler(this.frmBaocaochitiet_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtThang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNam)).EndInit();
            this.gbLoaibn.ResumeLayout(false);
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
        private void f_load_data()
        {
            txtThuquy.Text = m_v.sys_thuquy;
            txtKetoanvp.Text = m_v.sys_ketoanvp;
            txtPhongtckt.Text = m_v.sys_phongtckt;
           
        }
		private void f_Display_User()
		{
			try
			{
				DataSet ads = m_v.get_data("select to_char(id) id, hoten from medibv.v_dlogin where to_char(id)='"+ m_userid + "'");
				lbNguoiDN.Text="" + ads.Tables[0].Rows[0]["hoten"].ToString();
				txtNguoilapbang.Text=ads.Tables[0].Rows[0]["hoten"].ToString();
				lbNgayDN.Text=lan.Change_language_MessageText("Ngày:")+" " + f_Cur_Date();
			}
			catch
			{
				//MessageBox.Show(this,"Chưa đăng nhập. Chỉ có quyền xem thông tin",m_v.s_AppName,MessageBoxButtons.OK,MessageBoxIcon.Warning);
				lbNguoiDN.Text="<????>";
				lbNgayDN.Text="";
			}
			this.Text=this.Text+"/"+lbNguoiDN.Text.Trim();
			lbNguoiDN.Visible=false;
		}
		private void frmBaocaochitiet_Load(object sender, System.EventArgs e)
		{
			try
			{
				txtNgayIn.Value=System.DateTime.Now;
				txtTN.Value=System.DateTime.Now;
				txtDN.Value=System.DateTime.Now;
				txtThang.Value=decimal.Parse(System.DateTime.Now.Month.ToString());
				txtNam.Value=decimal.Parse(System.DateTime.Now.Year.ToString());
				rdThang_CheckedChanged(null,null);
                txtTN.Value = m_v.s_server_date;
                txtDN.Value = txtTN.Value;
				f_Display_User();
				f_Load_CB_Maubaocao();
				f_LoadHistory();
                
			}
			catch
			{
			}
			f_Load_Tree_Userid();
			f_Load_Tree_Loaibn();
			f_Load_Tree_VP();
			f_Load_Tree_Doituong();
         
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
		private void f_Load_Tree_Loaibn()
		{
			try
			{
				string sql = "select to_char(id) as ma, ten from medibv.v_loaibn order by id";
				f_Load_Tree(tree_Loaibn,m_v.get_data(sql));
			}
			catch
			{
			}
		}
        /// <summary>
        /// Lấy mã quản lý cấp cứu
        /// </summary>
        
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
						aexp=" and upper(a.sohieu) like '%"+timso.Text.Trim().ToUpper()+"%'";
					}
                    string sql = "select to_char(a.id) ma, trim(a.sohieu)||'     ('||to_char(a.tu)||' -->'||to_char(a.den)|| ')'ten, to_char(b.id) mar, trim(b.hoten)||' ('||b.userid||')' tenr from medibv.v_quyenso a, medibv.v_dlogin b where a.userid(+)=b.id " + aexp + " order by b.id, b.hoten";
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
		private void f_Load_Tree_VP()
		{
			try
			{
                string sql = "select * from (select to_char(a.id) as ma, trim(a.ten) || ' ('||trim(a.ma)||')' as ten, to_char(c.id) as mar, trim(c.ten) as tenr, c.stt from medibv.v_giavp a left join medibv.v_option_bcct b on a.id=b.id left join medibv.v_loaivp c on a.id_loai=c.id";// order by a.id_loai, a.ten desc
                sql += " union all select to_char(a.id) as ma, trim(a.ten)||' '||trim(a.hamluong) || ' ('||trim(a.ma)||')' as ten, to_char(d.ma) as mar, trim(d.ten) as tenr, d.stt from medibv.d_dmbd a left join medibv.v_option_bcct b on a.id=b.id inner join medibv.d_dmnhom c on a.manhom=c.id left join medibv.v_nhomvp d on c.nhomvp=d.ma where a.nhom=1) as froo order by stt, ten desc";
				try
				{
					string atmp = m_v.get_data(sql).Tables[0].Rows.Count.ToString();
				}
				catch
				{
                    m_v.execute_data("create table " + m_v.s_schemaroot + ".v_option_bcct(id numeric(3), ma text, ten text, loai numeric(1), constraint pk_v_option_bcct primary key(id)) with oids");
                    m_v.execute_data("alter table " + m_v.s_schemaroot + ".v_option_bcct owner to " + m_v.s_database + "");
                }
				f_Load_Tree(tree_VP,m_v.get_data(sql),false);
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
				foreach(DataRow r in v_ds.Tables[0].Select("","mar,tenr"))
				{
                    if(amar!=r["tenr"].ToString())
					{
						amar=r["tenr"].ToString();
						anoder = new TreeNode(r["tenr"].ToString());
						anoder.Tag = r["tenr"].ToString();
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
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
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
				string sql="",asqltt="",asqlnt="";
				string auserid=f_Get_CheckID(tree_User,1);
				string aquyensoid=f_Get_CheckID(tree_User,2);
				string aloaibn=f_Get_CheckID(tree_Loaibn);
				string avp=f_Get_CheckID(tree_VP,2);
				string adoituong=f_Get_CheckID(tree_Doituong);
				if(m_v.sys_dungchungso)
				{
					auserid = f_Get_CheckID(tree_User);
					aquyensoid = f_Get_CheckID(tree_Quyenso);
				}
				string aexptt="",aexpnt="";
				if(auserid!="")
				{
					aexptt+=" and a.userid in("+auserid+")";
					aexpnt+=" and a.userid in("+auserid+")";
				}
				if(aquyensoid!="")
				{
					aexptt+=" and a.quyenso in("+aquyensoid+")";
					aexpnt+=" and a.quyenso in("+aquyensoid+")";
				}
				if(aloaibn!="")
				{
					aexptt+=" and a.loaibn in("+aloaibn+")";
					aexpnt+=" and a.loaibn in("+aloaibn+")";
				}
				if(avp!="")
				{
					aexptt+=" and b.mavp in("+avp+")";
					aexpnt+=" and c.mavp in("+avp+")";
				}
				if(adoituong!="")
				{
					aexptt+=" and b.madoituong in("+adoituong+")";
					aexpnt+=" and c.madoituong in("+adoituong+")";
				}

                asqltt = " select c.id, c.ma, c.ten, c.dvt, j.id_loai, nvl(j.tenloai,j.tennhom) as tenloai, j.id_nhom, j.tennhom, a.quyenso, a.sobienlai,h.sohieu, h.sohieubl, i.hoten nguoithu,sum(b.soluong) as soluong,sum(b.dongia) as dongia,sum(b.soluong*b.dongia) as sotien,to_number(b.mien) as mien,case when d.sotien>0 then d.sotien else 0 end as hoan,case when d.sotienct>0 then d.sotienct else 0 end as hoanct, f.makp,f.tenkp,to_char(a.ngay,'dd/mm/yyyy') ngay,g.mabn, g.hoten, g.namsinh,(g.sonha||' '||g.thon) diachi, g.cholam, e.sothe mabhyt, to_char(e.denngay,'dd/mm/yyyy') denngay, to_number('0') as bhyttra ";
                asqltt += " from medibvmmyy.v_vienphill a inner join medibvmmyy.v_vienphict b on a.id=b.id inner join medibv.v_giavp c on b.mavp=c.id left join (select a.*,b.sotien  as sotienct,b.loaivp as loaict from medibvmmyy.v_hoantra a left join medibvmmyy.v_hoantract b on a.id=b.id where to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy')) d on d.quyenso=a.quyenso and d.sobienlai=a.sobienlai and b.mavp=d.loaict left join medibvmmyy.bhyt e on e.maql=a.maql left join medibv.btdkp_bv f on f.makp=b.makp inner join medibv.btdbn g on a.mabn=g.mabn left join medibv.v_quyenso h on h.id=a.quyenso inner join medibv.v_dlogin i on i.id=a.userid inner join ";

                asqltt += " (select a.id as idvp, a.id_loai, c.ma id_nhom, b.ten tenloai, c.ten tennhom from medibv.v_giavp a inner join medibv.v_loaivp b on a.id_loai=b.id left join medibv.v_nhomvp c on b.id_nhom=c.ma ";
                asqltt += " union all ";
                asqltt += " select a.id as idvp, 0 as id_loai, b.nhomvp id_nhom, null tenloai, c.ten tennhom from medibv.d_dmbd a inner join medibv.d_dmnhom b on a.manhom=b.id left join medibv.v_nhomvp c on b.nhomvp=c.ma) as j on b.mavp=j.idvp";

                asqltt += " where to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy') " + aexptt + " ";
                asqltt += " group by c.id, c.ma, c.ten, c.dvt, j.id_loai, nvl(j.tenloai,j.tennhom), j.id_nhom, j.tennhom, to_char(a.ngay,'dd/mm/yyyy'),g.mabn, g.hoten,g.namsinh,g.sonha||' '||g.thon, g.cholam,e.sothe, to_char(e.denngay,'dd/mm/yyyy'), f.makp,f.tenkp, a.quyenso,a.sobienlai,h.sohieu,h.sohieubl,i.hoten,to_number(b.mien),case when d.sotien>0 then d.sotien else 0 end,case when d.sotienct>0 then d.sotienct else 0 end ";

                //asqlnt = " select d.id, d.ma, d.ten, d.dvt, j.id_loai, nvl(j.tenloai,j.tennhom) as tenloai, j.id_nhom, j.tennhom, a.quyenso, a.sobienlai,i.sohieu, i.sohieubl, k.hoten nguoithu, sum(c.soluong) as soluong, sum(c.dongia) as dongia, sum(c.soluong*c.dongia) as sotien, to_number(a.mien) as mien,case when e.sotien>0 then e.sotien else 0 end as hoan,0 as hoanct,h.makp,h.tenkp,to_char(a.ngay,'dd/mm/yyyy') ngay,f.mabn, f.hoten, f.namsinh, f.sonha || ' ' || f.thon diachi,f.cholam, g.sothe mabhyt, to_char(g.denngay,'dd/mm/yyyy') denngay, sum(c.bhyttra) as bhyttra ";
                //asqlnt += " from medibvmmyy.v_ttrvll a inner join medibvmmyy.v_ttrvds b on a.id=b.id inner join medibvmmyy.v_ttrvct c on a.id=c.id inner join medibv.v_giavp d on c.mavp=d.id left join (select * from medibvmmyy.v_hoantra where to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy')) e on a.quyenso=e.quyenso and a.sobienlai=e.sobienlai inner join medibv.btdbn f on b.mabn=f.mabn left join medibvmmyy.bhyt g on b.maql=g.maql left join medibv.btdkp_bv h on c.makp=h.makp inner join medibv.v_quyenso i on a.quyenso=i.id inner join medibv.v_dlogin k on a.userid=k.id inner join ";
                asqlnt = " select j.idvp as id, j.ma, j.ten, j.dvt, j.id_loai, nvl(j.tenloai,j.tennhom) as tenloai, j.id_nhom, j.tennhom, a.quyenso, a.sobienlai,i.sohieu, i.sohieubl, k.hoten nguoithu, sum(c.soluong) as soluong, sum(c.dongia) as dongia, sum(c.soluong*c.dongia) as sotien, to_number(a.mien) as mien,case when e.sotien>0 then e.sotien else 0 end as hoan,0 as hoanct,h.makp,h.tenkp,to_char(a.ngay,'dd/mm/yyyy') ngay,f.mabn, f.hoten, f.namsinh, f.sonha || ' ' || f.thon diachi,f.cholam, g.sothe mabhyt, to_char(g.denngay,'dd/mm/yyyy') denngay, sum(c.bhyttra) as bhyttra ";
                asqlnt += " from medibvmmyy.v_ttrvll a inner join medibvmmyy.v_ttrvds b on a.id=b.id inner join medibvmmyy.v_ttrvct c on a.id=c.id left join (select * from medibvmmyy.v_hoantra where to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy')) e on a.quyenso=e.quyenso and a.sobienlai=e.sobienlai inner join medibv.btdbn f on b.mabn=f.mabn left join medibvmmyy.bhyt g on b.maql=g.maql left join medibv.btdkp_bv h on c.makp=h.makp inner join medibv.v_quyenso i on a.quyenso=i.id inner join medibv.v_dlogin k on a.userid=k.id inner join ";

                asqlnt += " (select a.id as idvp, a.id_loai, c.ma id_nhom, b.ten tenloai, c.ten tennhom, a.ma, a.ten, a.dvt from medibv.v_giavp a inner join medibv.v_loaivp b on a.id_loai=b.id left join medibv.v_nhomvp c on b.id_nhom=c.ma ";
                asqlnt += " union all ";
                asqlnt += " select a.id as idvp, 0 as id_loai, b.nhomvp id_nhom, null tenloai, c.ten tennhom, a.ma, a.ten||' '||a.hamluong as ten, a.dang as dvt from medibv.d_dmbd a inner join medibv.d_dmnhom b on a.manhom=b.id left join medibv.v_nhomvp c on b.nhomvp=c.ma) as j on c.mavp=j.idvp";

                asqlnt += " where to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy') " + aexpnt + " ";
                //asqlnt += " group by d.id, d.ma, d.ten, d.dvt, j.id_loai, nvl(j.tenloai,j.tennhom), j.id_nhom, j.tennhom, to_char(a.ngay,'dd/mm/yyyy'),f.mabn, f.hoten,f.namsinh,f.sonha||' '||f.thon,f.cholam, g.sothe,to_char(g.denngay,'dd/mm/yyyy'),h.makp,h.tenkp,a.quyenso,a.sobienlai,i.sohieu, i.sohieubl, k.hoten,to_number(a.mien),case when e.sotien>0 then e.sotien else 0 end ";
                asqlnt += " group by j.idvp, j.ma, j.ten, j.dvt, j.id_loai, nvl(j.tenloai,j.tennhom), j.id_nhom, j.tennhom, to_char(a.ngay,'dd/mm/yyyy'),f.mabn, f.hoten,f.namsinh,f.sonha||' '||f.thon,f.cholam, g.sothe,to_char(g.denngay,'dd/mm/yyyy'),h.makp,h.tenkp,a.quyenso,a.sobienlai,i.sohieu, i.sohieubl, k.hoten,to_number(a.mien),case when e.sotien>0 then e.sotien else 0 end ";

				sql="";
				if((chkNoitru.Checked && chkPhongkham.Checked)||(!chkNoitru.Checked && !chkPhongkham.Checked))
				{
					sql=asqltt.Trim() + " union all "+asqlnt.Trim();
				}
				else
					if(chkNoitru.Checked)
				{
					sql=asqlnt.Trim();
				}
				else
					if(chkPhongkham.Checked)
				{
					sql=asqltt.Trim();
				}
				DataSet ads = null;
				if(sql!="")
				{
                    ads = m_v.get_data_mmyy(sql, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true);//
				}
				if(chkNgoaitru.Checked || (!chkNoitru.Checked && !chkPhongkham.Checked && !chkNgoaitru.Checked))
				{
					DataSet adsngtru = null;
					try
					{
                        sql = "select j.idvp as id, j.ma, j.ten, j.dvt, j.id_loai, nvl(j.tenloai,j.tennhom) as tenloai, j.id_nhom, j.tennhom, a.quyenso, a.sobienlai, h.sohieu, h.sohieubl, i.hoten nguoithu, b.soluong, b.dongia, b.soluong*b.dongia sotien, to_number(0) as mien, to_number(0) as hoan, to_number(0) as hoanct, f.makp, f.tenkp, to_char(a.ngay,'dd/mm/yyyy') ngay,g.mabn, g.hoten, g.namsinh,(g.sonha||' '||g.thon) diachi, g.cholam, e.sothe mabhyt, to_char(e.denngay,'dd/mm/yyyy') denngay, a.bhyttra ";
                        sql += " from medibvmmyy.bhytkb a inner join (select id, mavp, soluong, dongia from medibvmmyy.bhytcls union all select id, mabd as mavp, soluong, giaban as dongia from medibvmmyy.bhytthuoc) as b on a.id=b.id left join medibvmmyy.bhyt e on a.maql=e.maql left join medibv.btdkp_bv f on a.makp=f.makp inner join medibv.btdbn g on a.mabn=g.mabn left join medibv.v_quyenso h on a.quyenso=h.id left join medibv.v_dlogin i on a.userid=i.id inner join ";
                        sql += " (select a.id as idvp, to_char(a.ma) as ma, a.ten, a.dvt, a.id_loai, c.ma id_nhom, b.ten tenloai, c.ten tennhom from medibv.v_giavp a inner join medibv.v_loaivp b on a.id_loai=b.id left join medibv.v_nhomvp c on b.id_nhom=c.ma ";
                        sql += " union all ";
                        sql += " select a.id as idvp, to_char(a.ma) as ma, trim(a.ten||' '||a.hamluong) as ten, a.dang as dvt, 0 as id_loai, b.nhomvp id_nhom, null tenloai, c.ten tennhom from medibv.d_dmbd a inner join medibv.d_dmnhom b on a.manhom=b.id left join medibv.v_nhomvp c on b.nhomvp=c.ma) as j on b.mavp=j.idvp";
                        sql += " where to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy') " + aexptt + " group by j.idvp, j.ma, j.ten, j.dvt, j.id_loai, nvl(j.tenloai,j.tennhom), j.id_nhom, j.tennhom, to_char(a.ngay,'dd/mm/yyyy'),g.mabn, g.hoten,g.namsinh,g.sonha||' '||g.thon, g.cholam,e.sothe, to_char(e.denngay,'dd/mm/yyyy'), f.makp,f.tenkp,b.soluong,b.dongia, a.quyenso,a.sobienlai,h.sohieu,h.sohieubl,i.hoten";
                        adsngtru = m_v.get_data_mmyy(sql, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true);// m_v.get_data_all(txtTN.Value,txtDN.Value,sql);
					}
					catch
					{
					}
					if(adsngtru!=null)
					{
						if(ads!=null)
						{
							ads.Merge(adsngtru);
						}
						else
						{
							ads=adsngtru;
						}
					}
				}
				if(ads.Tables[0].Rows.Count<=0)
				{
					MessageBox.Show(this,lan.Change_language_MessageText("Không có số liệu!"),m_v.s_AppName,MessageBoxButtons.OK,MessageBoxIcon.Information);
					return;
				}
     


				string areport="v_2007_baocaochitiet.rpt",asyt="",abv="",angayin="",anguoiin="",aghichu="";
				areport="v_2007_baocaochitiet.rpt";
				if(cbMaubaocao.SelectedIndex>0)
				{
					string areportt=areport.Replace(".rpt","_"+cbMaubaocao.SelectedValue.ToString().Trim()+".rpt");
					if(System.IO.File.Exists("..\\..\\report_vp\\"+areportt))
					{
						areport=areportt;
					}
				}
				asyt = m_v.Syte;
				abv = m_v.Tenbv;
           
				angayin =lan.Change_language_MessageText("Ngày :")+" " + txtNgayIn.Value.Day.ToString().PadLeft(2,'0') + " "+lan.Change_language_MessageText("tháng")+" " + txtNgayIn.Value.Month.ToString().PadLeft(2,'0') + " "+lan.Change_language_MessageText("năm")+" " + txtNgayIn.Value.Year.ToString();
				anguoiin = txtNguoilapbang.Text.Trim();
				aghichu = f_Get_GhiChu();

				if(menuItem1.Checked)
				{
					ads.WriteXml("..//..//Datareport//v_"+areport.Replace(".rpt","")+".xml", XmlWriteMode.WriteSchema);
				}


                frmReport af = new frmReport(m_v, ads.Tables[0], areport, asyt, abv, angayin, anguoiin, aghichu, txtNguoilapbang.Text.Trim(), txtThuquy.Text.Trim(), txtKetoanvp.Text.Trim(), txtPhongtckt.Text.Trim(), "Báo cáo chi tiết thu viện phí", 1, checkBox1.Checked ? true : false);
                af.ShowDialog();
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}
		private DataSet f_Get_Maubaocaotructiep()
		{
			//v_maubaocao 
			//loai=7: Báo cáo chi tiết
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
				ads = m_v.get_data("select ma, ten from medibv.v_maubaocao where loai=7");
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
		private void f_SaveHistory()
		{
			try
			{
				DataSet ads = new DataSet();
				ads.Tables.Add("Bangkehoantra");
				ads.Tables[0].Columns.Add("nguoilapbang");
				ads.Tables[0].Rows.Add(new string[] {txtNguoilapbang.Text.Trim()});
				ads.WriteXml("...//...//option//v_optionbaocaochitiet.xml",XmlWriteMode.WriteSchema);
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
				ads.ReadXml("...//...//option//v_optionbaocaochitiet.xml");
				txtNguoilapbang.Text=txtNguoilapbang.Tag.ToString();//ads.Tables[0].Rows[0]["nguoilapbang"].ToString();
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
				if(ad1==ad2)
				{
					r=lan.Change_language_MessageText("(Ngày :") + ad1.Day.ToString().PadLeft(2,'0') + "/" + ad1.Month.ToString().PadLeft(2,'0') + "/" +ad1.Year.ToString() + ")";
				}
				else
				{
					r=lan.Change_language_MessageText("(Từ ngày :") + ad1.Day.ToString().PadLeft(2,'0') + "/" + ad1.Month.ToString().PadLeft(2,'0') + "/" +ad1.Year.ToString() + " đến ngày " + ad2.Day.ToString().PadLeft(2,'0') + "/" + ad2.Month.ToString().PadLeft(2,'0') + "/" +ad2.Year.ToString() + ")";
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

		private void frmBaocaochitiet_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
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

		private void frmBaocaochitiet_SizeChanged(object sender, System.EventArgs e)
		{
		}
		private void rdThang_CheckedChanged(object sender, System.EventArgs e)
		{
			try
			{
				txtThang.Enabled=rdThang.Checked;
				txtNam.Enabled=rdThang.Checked;
				txtTN.Enabled=rdNgay.Checked;
				txtDN.Enabled=rdNgay.Checked;
				txtThang_ValueChanged(null,null);
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

		private void txtThang_Validated(object sender, System.EventArgs e)
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

				amsg=lan.Change_language_MessageText("Đã chọn:")+"\n"+lan.Change_language_MessageText("Nhân viên thu ngân:")+" "+anu.ToString()+"\n"+ lan.Change_language_MessageText("Quyển sổ thu tiền:")+" "+ans.ToString();
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

		private void chkUserid_CheckedChanged(object sender, System.EventArgs e)
		{
			f_Set_CheckID(tree_User,chkUserid.Checked);
		}
		private void chkVP_CheckedChanged(object sender, System.EventArgs e)
		{
			f_Set_CheckID(tree_VP,chkVP.Checked);
		}
		private void chkLoaibn_CheckedChanged(object sender, System.EventArgs e)
		{
			f_Set_CheckID(tree_Loaibn,chkLoaibn.Checked);
		}
		private void chkDoituong_CheckedChanged(object sender, System.EventArgs e)
		{
			f_Set_CheckID(tree_Doituong,chkDoituong.Checked);
		}

		private void chkLoaibn_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
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

		private void tree_Loaibn_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
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

		private void chkVP_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
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

		private void tree_Quyenso_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
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

		private void chkNoitru_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
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
		private void tree_VP_AfterCheck(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			try
			{
				e.Node.ForeColor=e.Node.Checked?Color.Navy:Color.DimGray;
				if(e.Node.Nodes.Count>0)
				{
					for(int i=0;i<e.Node.Nodes.Count;i++)
					{
						e.Node.Nodes[i].Checked=e.Node.Checked;
					}
				}
				for(int i=0;i<tree_VP.Nodes.Count;i++)
				{
					for(int j=0;j<tree_VP.Nodes[i].Nodes.Count;j++)
					{
						if(tree_VP.Nodes[i].Nodes[j].Checked)
						{
							return;
						}
					}
				}
				chkVP.Checked=false;
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

		private void lbKhaibao_Click(object sender, System.EventArgs e)
		{
			try
			{
				frmChondichvuVP_bcct af = new frmChondichvuVP_bcct();
				af.ShowInTaskbar=false;
				af.ShowDialog();
				if(af.s_mavp!="?")
				{
					m_v.execute_data("delete from medibv.v_option_bcct");
					foreach(string r in af.s_mavp.Split(','))
					{
						try
						{
							m_v.execute_data("insert into medibv.v_option_bcct (id) values("+r.Trim()+")");
						}
						catch
						{
						}
					}
					f_Load_Tree_VP();
				}
			}
			catch
			{
			}
		}

		private void tree_Loaibn_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
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
