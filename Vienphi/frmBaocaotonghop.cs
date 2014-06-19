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
	/// Summary description for frmBaocaotonghop.
	/// </summary>
	public class frmBaocaotonghop : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private bool m_giavpbangdongiacongvattu=false;

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
		private System.Windows.Forms.TextBox txtNguoilapbang;
		private System.Windows.Forms.TextBox txtTaivu;
		private System.Windows.Forms.TextBox txtThuquy;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.RadioButton rd1;
		private System.Windows.Forms.RadioButton rd2;
		private System.Windows.Forms.GroupBox gbLoaibc;
		private System.Windows.Forms.GroupBox gbLoaibn;
		private System.Windows.Forms.CheckBox chkNoitru;
		private System.Windows.Forms.CheckBox chkPhatsinh;
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
		private System.Windows.Forms.RadioButton rd3;
		private System.Windows.Forms.TreeView tree_User;
		private System.Windows.Forms.CheckBox chkUserid;
		private System.Windows.Forms.TreeView tree_Loaibn;
		private System.Windows.Forms.CheckBox chkLoaibn;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.ComboBox cbMaubaocao;
		private System.Windows.Forms.CheckBox chkMien;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.ContextMenu contextMenu2;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.MenuItem menuItem6;
		private System.Windows.Forms.TextBox txtLamtron;
		private System.Windows.Forms.Label lbLamtron;
		private System.Windows.Forms.TextBox timso;
		private System.Windows.Forms.RadioButton rd4;
		private System.Windows.Forms.TreeView tree_Quyenso;
        private Label label8;
        private Label label12;
        private Label label13;
        private Label label14;
        private TextBox txtTCKT;
        private CheckBox checkBox1;
        private CheckBox chkTamung;
        private CheckBox chkBHYT;
        private CheckBox chkTonghop;
		private System.ComponentModel.IContainer components;

		public frmBaocaotonghop(string v_userid)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBaocaotonghop));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbTitle = new System.Windows.Forms.Label();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.lbNgayDN = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbNguoiDN = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chkTonghop = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.chkMien = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.tree_Quyenso = new System.Windows.Forms.TreeView();
            this.timso = new System.Windows.Forms.TextBox();
            this.txtLamtron = new System.Windows.Forms.TextBox();
            this.lbLamtron = new System.Windows.Forms.Label();
            this.tree_Loaibn = new System.Windows.Forms.TreeView();
            this.tree_User = new System.Windows.Forms.TreeView();
            this.contextMenu2 = new System.Windows.Forms.ContextMenu();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.label9 = new System.Windows.Forms.Label();
            this.cbMaubaocao = new System.Windows.Forms.ComboBox();
            this.txtNgayIn = new System.Windows.Forms.DateTimePicker();
            this.chkLoaibn = new System.Windows.Forms.CheckBox();
            this.chkUserid = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdNgay = new System.Windows.Forms.RadioButton();
            this.txtDN = new System.Windows.Forms.DateTimePicker();
            this.txtThang = new System.Windows.Forms.NumericUpDown();
            this.txtNam = new System.Windows.Forms.NumericUpDown();
            this.txtTN = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.rdThang = new System.Windows.Forms.RadioButton();
            this.gbLoaibn = new System.Windows.Forms.GroupBox();
            this.chkBHYT = new System.Windows.Forms.CheckBox();
            this.chkTamung = new System.Windows.Forms.CheckBox();
            this.chkPhongkham = new System.Windows.Forms.CheckBox();
            this.chkNoitru = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.gbLoaibc = new System.Windows.Forms.GroupBox();
            this.rd3 = new System.Windows.Forms.RadioButton();
            this.rd4 = new System.Windows.Forms.RadioButton();
            this.rd2 = new System.Windows.Forms.RadioButton();
            this.rd1 = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTCKT = new System.Windows.Forms.TextBox();
            this.txtThuquy = new System.Windows.Forms.TextBox();
            this.txtTaivu = new System.Windows.Forms.TextBox();
            this.txtNguoilapbang = new System.Windows.Forms.TextBox();
            this.butInBK = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.chkPhatsinh = new System.Windows.Forms.CheckBox();
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
            this.gbLoaibc.SuspendLayout();
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
            this.panel1.Size = new System.Drawing.Size(737, 49);
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
            this.lbTitle.Text = "  BÁO CÁO TỔNG HỢP THU VIỆN PHÍ";
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
            this.label15.Size = new System.Drawing.Size(737, 3);
            this.label15.TabIndex = 17;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.chkTonghop);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.chkMien);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.tree_Quyenso);
            this.panel2.Controls.Add(this.timso);
            this.panel2.Controls.Add(this.txtLamtron);
            this.panel2.Controls.Add(this.lbLamtron);
            this.panel2.Controls.Add(this.tree_Loaibn);
            this.panel2.Controls.Add(this.tree_User);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.cbMaubaocao);
            this.panel2.Controls.Add(this.txtNgayIn);
            this.panel2.Controls.Add(this.chkLoaibn);
            this.panel2.Controls.Add(this.chkUserid);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.gbLoaibn);
            this.panel2.Controls.Add(this.gbLoaibc);
            this.panel2.Controls.Add(this.txtTCKT);
            this.panel2.Controls.Add(this.txtThuquy);
            this.panel2.Controls.Add(this.txtTaivu);
            this.panel2.Controls.Add(this.txtNguoilapbang);
            this.panel2.Controls.Add(this.butInBK);
            this.panel2.Controls.Add(this.butKetthuc);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.checkBox1);
            this.panel2.Controls.Add(this.chkPhatsinh);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.ForeColor = System.Drawing.Color.Navy;
            this.panel2.Location = new System.Drawing.Point(3, 55);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(737, 421);
            this.panel2.TabIndex = 18;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // chkTonghop
            // 
            this.chkTonghop.Location = new System.Drawing.Point(404, 208);
            this.chkTonghop.Name = "chkTonghop";
            this.chkTonghop.Size = new System.Drawing.Size(146, 23);
            this.chkTonghop.TabIndex = 221;
            this.chkTonghop.Text = "Xem tổng hợp số liệu";
            this.chkTonghop.CheckedChanged += new System.EventHandler(this.chkTonghop_CheckedChanged);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(373, 330);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 21);
            this.label8.TabIndex = 220;
            this.label8.Text = "Người lập phiếu:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkMien
            // 
            this.chkMien.Location = new System.Drawing.Point(574, 208);
            this.chkMien.Name = "chkMien";
            this.chkMien.Size = new System.Drawing.Size(146, 23);
            this.chkMien.TabIndex = 2;
            this.chkMien.Text = "Xem chi tiết miển giảm";
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(372, 396);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(92, 21);
            this.label12.TabIndex = 219;
            this.label12.Text = "Phòng TCKT:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(372, 352);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(92, 21);
            this.label13.TabIndex = 218;
            this.label13.Text = "Kế toán VP:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(372, 374);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(92, 21);
            this.label14.TabIndex = 217;
            this.label14.Text = "Thủ quỹ:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tree_Quyenso
            // 
            this.tree_Quyenso.CheckBoxes = true;
            this.tree_Quyenso.ForeColor = System.Drawing.Color.DimGray;
            this.tree_Quyenso.FullRowSelect = true;
            this.tree_Quyenso.Location = new System.Drawing.Point(231, 23);
            this.tree_Quyenso.Name = "tree_Quyenso";
            this.tree_Quyenso.ShowLines = false;
            this.tree_Quyenso.ShowPlusMinus = false;
            this.tree_Quyenso.ShowRootLines = false;
            this.tree_Quyenso.Size = new System.Drawing.Size(124, 249);
            this.tree_Quyenso.Sorted = true;
            this.tree_Quyenso.TabIndex = 208;
            // 
            // timso
            // 
            this.timso.BackColor = System.Drawing.Color.White;
            this.timso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timso.Location = new System.Drawing.Point(6, 274);
            this.timso.MaxLength = 12;
            this.timso.Name = "timso";
            this.timso.Size = new System.Drawing.Size(349, 21);
            this.timso.TabIndex = 207;
            this.timso.Text = "Tìm sổ";
            this.timso.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.timso.TextChanged += new System.EventHandler(this.timso_TextChanged);
            // 
            // txtLamtron
            // 
            this.txtLamtron.BackColor = System.Drawing.Color.White;
            this.txtLamtron.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLamtron.Location = new System.Drawing.Point(464, 306);
            this.txtLamtron.MaxLength = 30;
            this.txtLamtron.Name = "txtLamtron";
            this.txtLamtron.Size = new System.Drawing.Size(274, 21);
            this.txtLamtron.TabIndex = 198;
            this.txtLamtron.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtLamtron.Visible = false;
            this.txtLamtron.Validated += new System.EventHandler(this.txtLamtron_Validated);
            // 
            // lbLamtron
            // 
            this.lbLamtron.ForeColor = System.Drawing.Color.Blue;
            this.lbLamtron.Location = new System.Drawing.Point(355, 310);
            this.lbLamtron.Name = "lbLamtron";
            this.lbLamtron.Size = new System.Drawing.Size(108, 13);
            this.lbLamtron.TabIndex = 199;
            this.lbLamtron.Text = "Số tiền chênh lệch";
            this.lbLamtron.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbLamtron.Visible = false;
            // 
            // tree_Loaibn
            // 
            this.tree_Loaibn.CheckBoxes = true;
            this.tree_Loaibn.ForeColor = System.Drawing.Color.DimGray;
            this.tree_Loaibn.FullRowSelect = true;
            this.tree_Loaibn.Location = new System.Drawing.Point(6, 315);
            this.tree_Loaibn.Name = "tree_Loaibn";
            this.tree_Loaibn.ShowLines = false;
            this.tree_Loaibn.ShowPlusMinus = false;
            this.tree_Loaibn.ShowRootLines = false;
            this.tree_Loaibn.Size = new System.Drawing.Size(349, 77);
            this.tree_Loaibn.Sorted = true;
            this.tree_Loaibn.TabIndex = 3;
            this.tree_Loaibn.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tree_Loaibn_AfterCheck);
            this.tree_Loaibn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tree_Loaibn_KeyDown);
            // 
            // tree_User
            // 
            this.tree_User.CheckBoxes = true;
            this.tree_User.ContextMenu = this.contextMenu2;
            this.tree_User.ForeColor = System.Drawing.Color.DimGray;
            this.tree_User.FullRowSelect = true;
            this.tree_User.Location = new System.Drawing.Point(6, 23);
            this.tree_User.Name = "tree_User";
            this.tree_User.ShowLines = false;
            this.tree_User.ShowPlusMinus = false;
            this.tree_User.ShowRootLines = false;
            this.tree_User.Size = new System.Drawing.Size(349, 249);
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
            // label9
            // 
            this.label9.ForeColor = System.Drawing.Color.Navy;
            this.label9.Location = new System.Drawing.Point(7, 398);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 13);
            this.label9.TabIndex = 197;
            this.label9.Text = "Mẫu báo cáo";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbMaubaocao
            // 
            this.cbMaubaocao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMaubaocao.Location = new System.Drawing.Point(85, 394);
            this.cbMaubaocao.Name = "cbMaubaocao";
            this.cbMaubaocao.Size = new System.Drawing.Size(270, 21);
            this.cbMaubaocao.TabIndex = 11;
            // 
            // txtNgayIn
            // 
            this.txtNgayIn.CustomFormat = "dd/MM/yyyy";
            this.txtNgayIn.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtNgayIn.Location = new System.Drawing.Point(620, 92);
            this.txtNgayIn.Name = "txtNgayIn";
            this.txtNgayIn.Size = new System.Drawing.Size(83, 20);
            this.txtNgayIn.TabIndex = 4;
            this.txtNgayIn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNgayIn_KeyDown);
            // 
            // chkLoaibn
            // 
            this.chkLoaibn.Location = new System.Drawing.Point(6, 299);
            this.chkLoaibn.Name = "chkLoaibn";
            this.chkLoaibn.Size = new System.Drawing.Size(168, 17);
            this.chkLoaibn.TabIndex = 2;
            this.chkLoaibn.TabStop = false;
            this.chkLoaibn.Text = "Loại bệnh nhân";
            this.chkLoaibn.CheckedChanged += new System.EventHandler(this.chkLoaibn_CheckedChanged);
            this.chkLoaibn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkLoaibn_KeyDown);
            // 
            // chkUserid
            // 
            this.chkUserid.Location = new System.Drawing.Point(6, 6);
            this.chkUserid.Name = "chkUserid";
            this.chkUserid.Size = new System.Drawing.Size(192, 17);
            this.chkUserid.TabIndex = 0;
            this.chkUserid.TabStop = false;
            this.chkUserid.Text = "Nhân viên thu ngân (Quyển sổ)";
            this.chkUserid.CheckedChanged += new System.EventHandler(this.chkUserid_CheckedChanged);
            this.chkUserid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkUserid_KeyDown_1);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdNgay);
            this.groupBox1.Controls.Add(this.txtDN);
            this.groupBox1.Controls.Add(this.txtThang);
            this.groupBox1.Controls.Add(this.txtNam);
            this.groupBox1.Controls.Add(this.txtTN);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.rdThang);
            this.groupBox1.Location = new System.Drawing.Point(359, 17);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(381, 70);
            this.groupBox1.TabIndex = 159;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thời gian báo cáo";
            // 
            // rdNgay
            // 
            this.rdNgay.Checked = true;
            this.rdNgay.Location = new System.Drawing.Point(45, 39);
            this.rdNgay.Name = "rdNgay";
            this.rdNgay.Size = new System.Drawing.Size(64, 20);
            this.rdNgay.TabIndex = 3;
            this.rdNgay.TabStop = true;
            this.rdNgay.Text = "Từ ngày";
            this.rdNgay.CheckedChanged += new System.EventHandler(this.rdNgay_CheckedChanged);
            this.rdNgay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rdNgay_KeyDown);
            // 
            // txtDN
            // 
            this.txtDN.CustomFormat = "dd/MM/yyyy";
            this.txtDN.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtDN.Location = new System.Drawing.Point(260, 40);
            this.txtDN.Name = "txtDN";
            this.txtDN.Size = new System.Drawing.Size(85, 20);
            this.txtDN.TabIndex = 5;
            this.txtDN.ValueChanged += new System.EventHandler(this.txtDN_ValueChanged);
            this.txtDN.Validated += new System.EventHandler(this.txtDN_Validated);
            this.txtDN.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDN_KeyDown);
            // 
            // txtThang
            // 
            this.txtThang.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtThang.Location = new System.Drawing.Point(109, 17);
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
            this.txtNam.Location = new System.Drawing.Point(260, 17);
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
            this.txtTN.CustomFormat = "dd/MM/yyyy";
            this.txtTN.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtTN.Location = new System.Drawing.Point(109, 40);
            this.txtTN.Name = "txtTN";
            this.txtTN.Size = new System.Drawing.Size(85, 20);
            this.txtTN.TabIndex = 4;
            this.txtTN.ValueChanged += new System.EventHandler(this.txtTN_ValueChanged);
            this.txtTN.Validated += new System.EventHandler(this.txtTN_Validated);
            this.txtTN.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTN_KeyDown);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(206, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Năm";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(207, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 154;
            this.label3.Text = "Đến ngày";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rdThang
            // 
            this.rdThang.Location = new System.Drawing.Point(46, 19);
            this.rdThang.Name = "rdThang";
            this.rdThang.Size = new System.Drawing.Size(64, 20);
            this.rdThang.TabIndex = 0;
            this.rdThang.Text = "Tháng";
            this.rdThang.CheckedChanged += new System.EventHandler(this.rdThang_CheckedChanged);
            this.rdThang.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rdThang_KeyDown);
            // 
            // gbLoaibn
            // 
            this.gbLoaibn.Controls.Add(this.chkBHYT);
            this.gbLoaibn.Controls.Add(this.chkTamung);
            this.gbLoaibn.Controls.Add(this.chkPhongkham);
            this.gbLoaibn.Controls.Add(this.chkNoitru);
            this.gbLoaibn.Controls.Add(this.label7);
            this.gbLoaibn.Location = new System.Drawing.Point(359, 87);
            this.gbLoaibn.Name = "gbLoaibn";
            this.gbLoaibn.Size = new System.Drawing.Size(209, 111);
            this.gbLoaibn.TabIndex = 8;
            this.gbLoaibn.TabStop = false;
            this.gbLoaibn.Tag = "0";
            this.gbLoaibn.Text = "Chứng từ";
            // 
            // chkBHYT
            // 
            this.chkBHYT.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkBHYT.Location = new System.Drawing.Point(9, 85);
            this.chkBHYT.Name = "chkBHYT";
            this.chkBHYT.Size = new System.Drawing.Size(197, 23);
            this.chkBHYT.TabIndex = 4;
            this.chkBHYT.Text = "BHYT Ngoại trú";
            // 
            // chkTamung
            // 
            this.chkTamung.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkTamung.Location = new System.Drawing.Point(9, 62);
            this.chkTamung.Name = "chkTamung";
            this.chkTamung.Size = new System.Drawing.Size(197, 23);
            this.chkTamung.TabIndex = 3;
            this.chkTamung.Text = "Thu tạm ứng";
            // 
            // chkPhongkham
            // 
            this.chkPhongkham.Checked = true;
            this.chkPhongkham.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPhongkham.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkPhongkham.Location = new System.Drawing.Point(9, 39);
            this.chkPhongkham.Name = "chkPhongkham";
            this.chkPhongkham.Size = new System.Drawing.Size(197, 23);
            this.chkPhongkham.TabIndex = 1;
            this.chkPhongkham.Text = "Thu trực tiếp";
            // 
            // chkNoitru
            // 
            this.chkNoitru.Checked = true;
            this.chkNoitru.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNoitru.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkNoitru.Location = new System.Drawing.Point(9, 16);
            this.chkNoitru.Name = "chkNoitru";
            this.chkNoitru.Size = new System.Drawing.Size(197, 23);
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
            this.label7.Size = new System.Drawing.Size(6, 92);
            this.label7.TabIndex = 0;
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gbLoaibc
            // 
            this.gbLoaibc.Controls.Add(this.rd3);
            this.gbLoaibc.Controls.Add(this.rd4);
            this.gbLoaibc.Controls.Add(this.rd2);
            this.gbLoaibc.Controls.Add(this.rd1);
            this.gbLoaibc.Controls.Add(this.label6);
            this.gbLoaibc.Location = new System.Drawing.Point(359, 236);
            this.gbLoaibc.Name = "gbLoaibc";
            this.gbLoaibc.Size = new System.Drawing.Size(381, 59);
            this.gbLoaibc.TabIndex = 7;
            this.gbLoaibc.TabStop = false;
            this.gbLoaibc.Tag = "0";
            this.gbLoaibc.Text = "Báo cáo theo";
            // 
            // rd3
            // 
            this.rd3.Location = new System.Drawing.Point(199, 37);
            this.rd3.Name = "rd3";
            this.rd3.Size = new System.Drawing.Size(87, 19);
            this.rd3.TabIndex = 2;
            this.rd3.Tag = "3";
            this.rd3.Text = "Giá viện phí";
            this.rd3.CheckedChanged += new System.EventHandler(this.rd_CheckedChanged);
            this.rd3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rd3_KeyDown);
            // 
            // rd4
            // 
            this.rd4.Location = new System.Drawing.Point(45, 37);
            this.rd4.Name = "rd4";
            this.rd4.Size = new System.Drawing.Size(85, 19);
            this.rd4.TabIndex = 157;
            this.rd4.Tag = "4";
            this.rd4.Text = "Đối tượng";
            this.rd4.CheckedChanged += new System.EventHandler(this.rd_CheckedChanged);
            // 
            // rd2
            // 
            this.rd2.Checked = true;
            this.rd2.Location = new System.Drawing.Point(199, 15);
            this.rd2.Name = "rd2";
            this.rd2.Size = new System.Drawing.Size(87, 19);
            this.rd2.TabIndex = 1;
            this.rd2.TabStop = true;
            this.rd2.Tag = "2";
            this.rd2.Text = "Loại viện phí";
            this.rd2.CheckedChanged += new System.EventHandler(this.rd_CheckedChanged);
            // 
            // rd1
            // 
            this.rd1.Location = new System.Drawing.Point(45, 15);
            this.rd1.Name = "rd1";
            this.rd1.Size = new System.Drawing.Size(85, 19);
            this.rd1.TabIndex = 0;
            this.rd1.Tag = "1";
            this.rd1.Text = "Khoa phòng";
            this.rd1.CheckedChanged += new System.EventHandler(this.rd_CheckedChanged);
            this.rd1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rd1_KeyDown);
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Left;
            this.label6.ForeColor = System.Drawing.Color.Navy;
            this.label6.Location = new System.Drawing.Point(3, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(6, 40);
            this.label6.TabIndex = 156;
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTCKT
            // 
            this.txtTCKT.BackColor = System.Drawing.Color.White;
            this.txtTCKT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTCKT.Location = new System.Drawing.Point(464, 395);
            this.txtTCKT.MaxLength = 50;
            this.txtTCKT.Name = "txtTCKT";
            this.txtTCKT.Size = new System.Drawing.Size(274, 21);
            this.txtTCKT.TabIndex = 10;
            this.txtTCKT.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtThuquy_KeyDown);
            // 
            // txtThuquy
            // 
            this.txtThuquy.BackColor = System.Drawing.Color.White;
            this.txtThuquy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtThuquy.Location = new System.Drawing.Point(464, 373);
            this.txtThuquy.MaxLength = 50;
            this.txtThuquy.Name = "txtThuquy";
            this.txtThuquy.Size = new System.Drawing.Size(274, 21);
            this.txtThuquy.TabIndex = 10;
            this.txtThuquy.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtThuquy_KeyDown);
            // 
            // txtTaivu
            // 
            this.txtTaivu.BackColor = System.Drawing.Color.White;
            this.txtTaivu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTaivu.Location = new System.Drawing.Point(464, 351);
            this.txtTaivu.MaxLength = 50;
            this.txtTaivu.Name = "txtTaivu";
            this.txtTaivu.Size = new System.Drawing.Size(274, 21);
            this.txtTaivu.TabIndex = 8;
            this.txtTaivu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTaivu_KeyDown);
            // 
            // txtNguoilapbang
            // 
            this.txtNguoilapbang.BackColor = System.Drawing.Color.White;
            this.txtNguoilapbang.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNguoilapbang.Location = new System.Drawing.Point(464, 328);
            this.txtNguoilapbang.MaxLength = 50;
            this.txtNguoilapbang.Name = "txtNguoilapbang";
            this.txtNguoilapbang.Size = new System.Drawing.Size(274, 21);
            this.txtNguoilapbang.TabIndex = 9;
            this.txtNguoilapbang.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNguoilapbang_KeyDown);
            // 
            // butInBK
            // 
            this.butInBK.BackColor = System.Drawing.SystemColors.Control;
            this.butInBK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butInBK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butInBK.ForeColor = System.Drawing.Color.Navy;
            this.butInBK.Image = ((System.Drawing.Image)(resources.GetObject("butInBK.Image")));
            this.butInBK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butInBK.Location = new System.Drawing.Point(571, 121);
            this.butInBK.Name = "butInBK";
            this.butInBK.Size = new System.Drawing.Size(79, 26);
            this.butInBK.TabIndex = 5;
            this.butInBK.Text = "     &Xem";
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
            this.butKetthuc.Location = new System.Drawing.Point(650, 121);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(83, 26);
            this.butKetthuc.TabIndex = 6;
            this.butKetthuc.Text = "     &Kết thúc";
            this.butKetthuc.UseVisualStyleBackColor = true;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            this.butKetthuc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.butKetthuc_KeyDown);
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(568, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Ngày in";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // checkBox1
            // 
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(574, 176);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(158, 19);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "Xem trước khi in";
            this.checkBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkPhatsinh_KeyDown);
            // 
            // chkPhatsinh
            // 
            this.chkPhatsinh.Checked = true;
            this.chkPhatsinh.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPhatsinh.Location = new System.Drawing.Point(574, 152);
            this.chkPhatsinh.Name = "chkPhatsinh";
            this.chkPhatsinh.Size = new System.Drawing.Size(158, 19);
            this.chkPhatsinh.TabIndex = 3;
            this.chkPhatsinh.Text = "Chỉ xem các mục có số liệu";
            this.chkPhatsinh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkPhatsinh_KeyDown);
            // 
            // label11
            // 
            this.label11.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label11.Location = new System.Drawing.Point(3, 476);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(737, 4);
            this.label11.TabIndex = 210;
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(3, 480);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(737, 20);
            this.progressBar1.TabIndex = 209;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmBaocaotonghop
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(743, 503);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(759, 1000);
            this.Name = "frmBaocaotonghop";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Báo cáo tổng hợp thu viện phí";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmBaocaotonghop_KeyDown);
            this.Load += new System.EventHandler(this.frmBaocaotonghop_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtThang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNam)).EndInit();
            this.gbLoaibn.ResumeLayout(false);
            this.gbLoaibc.ResumeLayout(false);
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
				lbNguoiDN.Text="" + ads.Tables[0].Rows[0]["hoten"].ToString();
				txtNguoilapbang.Tag=ads.Tables[0].Rows[0]["hoten"].ToString();
				lbNgayDN.Text="Ngày: " + f_Cur_Date();
			}
			catch
			{
				//MessageBox.Show(this,"Chưa đăng nhập. Chỉ có quyền xem thông tin",m_v.s_AppName,MessageBoxButtons.OK,MessageBoxIcon.Warning);
				txtNguoilapbang.Tag="";
				lbNguoiDN.Text="<????>";
				lbNgayDN.Text="";
			}
			this.Text=this.Text+"/"+lbNguoiDN.Text.Trim();
			lbNguoiDN.Visible=false;
		}
		private void frmBaocaotonghop_Load(object sender, System.EventArgs e)
		{
			try
			{
                txtTN.Width = 83;
                txtDN.Width = 83;

                txtThuquy.Text = m_v.sys_thuquy;
                txtTaivu.Text = m_v.sys_ketoanvp;
                txtTCKT.Text = m_v.sys_phongtckt;

                m_giavpbangdongiacongvattu = m_v.sys_dongiacongvattu;
				f_Prepare();
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

		private void chklKP_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
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
						aexp=" upper(a.sohieu) like '%"+timso.Text.Trim().ToUpper()+"%'";
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
				string sql = "select to_char(id) as ma, trim(hoten)||' ('||userid||')' as ten from medibv.v_dlogin ";
                if (m_v.sys_Loctheonguoidangnhap && m_v.get_data("select admin from medibv.v_dlogin where id=" + m_userid).Tables[0].Rows[0][0].ToString() == "0") sql += " where id =" + m_userid + "";
                sql += " order by hoten asc";
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
		private string f_StringDate(DateTime v_dt)
		{
			try
			{
          

                    return v_dt.Day.ToString().PadLeft(2, '0') + "/" + v_dt.Month.ToString().PadLeft(2, '0') + "/" + v_dt.Year.ToString();
                
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
				string exp="", agroup="", alock01="", alock02="", alock03="", alock04="", alock05="", alock06="", alock_last="", alock00="", aluykethang="", aluykenam="";
				string auserid=f_Get_CheckID(tree_User,1);
				string aquyensoid=f_Get_CheckID(tree_User,2);
				string aloaibn=f_Get_CheckID(tree_Loaibn);
				if(m_v.sys_dungchungso)
				{
					auserid = f_Get_CheckID(tree_User);
					aquyensoid = f_Get_CheckID(tree_Quyenso);
				}
				
				DateTime ad1=txtTN.Value;
				DateTime ad2=txtDN.Value;
				aluykethang=lan.Change_language_MessageText("LŨY KẾ THÁNG")+" "+ ad2.Month.ToString().PadLeft(2,'0')+"/"+ad2.Year.ToString();
				aluykenam=lan.Change_language_MessageText("LŨY KẾ NĂM")+" "+ad2.Year.ToString();
				if((ad1-ad2).Days==0)
				{
					alock00=f_StringDate(ad1);
				}
				else
				{
					alock00=f_StringDate(ad1)+" - "+f_StringDate(ad2);
				}

				switch(gbLoaibc.Tag.ToString())
				{
					case "1"://KP
                        sql = "select to_char(nvl(to_number(a.makp),'-3')) id, a.makp ma, a.tenkp ten, 0 sotien, 0 luykethang,0 luykenam, 0 lock01, 0 lock02, 0 lock03, 0 lock04, 0 lock05, 0 lock06, 0 lock_last from medibv.btdkp_bv a order by a.tenkp asc";
						agroup="nvl(to_number(e.makp),'-3')";
						break;
					case "3"://Giavp
						agroup="nvl(to_number(b.id),-3)";
                        sql = "select trim(to_char(a.id)) id, a.ma, a.ten, 0 sotien, 0 luykethang,0 luykenam, 0 lock01, 0 lock02, 0 lock03, 0 lock04, 0 lock05, 0 lock06, 0 lock_last from (select id, to_char(ma) ma, ten from medibv.v_giavp union all select id, ma, ten from medibv.d_dmbd) as a order by a.ten asc";
						break;
					case "2"://Loaivp
					default:
						agroup="nvl(to_number(c.id),-3)";
						sql="select trim(to_char(a.id)) id, a.ma, a.ten, 0 sotien, 0 luykethang,0 luykenam, 0 lock01, 0 lock02, 0 lock03, 0 lock04, 0 lock05, 0 lock06, 0 lock_last from (select id, ma, ten from medibv.v_loaivp union all select 0 id, null ma, null ten from dual) as a order by a.ten asc";
						break;
				}
				ads = m_v.get_data(sql);
                #region 
                DataRow rtmp;	
				if(gbLoaibc.Tag.ToString()=="2")
				{
					try
					{
						rtmp = ads.Tables[0].Select("id=0")[0];
						rtmp["ma"]="THUOC";
						rtmp["ten"]=lan.Change_language_MessageText("Thuốc khoa dược");
					}
					catch
					{
					}
				}
				//BHYT, MIEN
				try
				{
					rtmp = ads.Tables[0].NewRow();
					rtmp["id"]="-1";
					rtmp["ten"]=lan.Change_language_MessageText("BHYT Chi trả");
					rtmp["sotien"]=0;
					rtmp["luykethang"]=0;
					rtmp["luykenam"]=0;
					rtmp["lock01"]=0;
					rtmp["lock02"]=0;
					rtmp["lock03"]=0;
					rtmp["lock04"]=0;
					rtmp["lock05"]=0;
					rtmp["lock06"]=0;
					rtmp["lock_last"]=0;
					ads.Tables[0].Rows.Add(rtmp);
					
					rtmp = ads.Tables[0].NewRow();
					rtmp["id"]="-2";
					rtmp["ten"]=lan.Change_language_MessageText("Miển giảm");
					rtmp["sotien"]=0;
					rtmp["luykethang"]=0;
					rtmp["luykenam"]=0;
					rtmp["lock01"]=0;
					rtmp["lock02"]=0;
					rtmp["lock03"]=0;
					rtmp["lock04"]=0;
					rtmp["lock05"]=0;
					rtmp["lock06"]=0;
					rtmp["lock_last"]=0;
					ads.Tables[0].Rows.Add(rtmp);

					rtmp = ads.Tables[0].NewRow();
					rtmp["id"]="-3";
					rtmp["ten"]=lan.Change_language_MessageText("(Không xác định)");
					rtmp["sotien"]=0;
					rtmp["luykethang"]=0;
					rtmp["luykenam"]=0;
					rtmp["lock01"]=0;
					rtmp["lock02"]=0;
					rtmp["lock03"]=0;
					rtmp["lock04"]=0;
					rtmp["lock05"]=0;
					rtmp["lock06"]=0;
					rtmp["lock_last"]=0;
					ads.Tables[0].Rows.Add(rtmp);
				}
				catch
				{
				}

				if(rd1.Checked)
				{
					adsbhyt=ads.Copy();
					adsmien=ads.Copy();
                }
#endregion 

                #region So tien theo khoa phòng
                try
				{
					exp=" and to_date(to_char(d.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('"+f_StringDate(ad1)+"','dd/mm/yyyy') and to_date('"+f_StringDate(ad2)+"','dd/mm/yyyy')";
					
                    asqlht="select * from medibvmmyy.v_hoantra where to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy')between to_date('"+f_StringDate(ad1)+"','dd/mm/yyyy') and to_date('"+f_StringDate(ad2)+"','dd/mm/yyyy')";
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
					
					if(((!chkPhongkham.Checked)&&(!chkNoitru.Checked))||((chkPhongkham.Checked)&&(chkNoitru.Checked)))
					{
                        asql1 = "select id, sum(to_number(sotien)) sotien from (select to_char(" + agroup + ") id, sum(nvl(a.soluong,0)*nvl(a.dongia,0)-nvl(a.thieu,0)) sotien from medibvmmyy.v_vienphict a, (select id, id_loai from medibv.v_giavp union all select id, 0 id_loai from medibv.d_dmbd) b, (select id from medibv.v_loaivp union all select 0 from dual) c, medibvmmyy.v_vienphill d, medibv.btdkp_bv e where a.id=d.id and b.id=a.mavp and c.id=b.id_loai and e.makp=a.makp " + exp + " group by " + agroup + " union all select to_char(" + agroup + ") id, sum(nvl(a.soluong,0)*nvl(a.dongia,0)+nvl(a.soluong,0)*nvl(a.dongia,0)*round(nvl(a.vat,0)/100,3)) sotien from medibvmmyy.v_ttrvct a, (select id, id_loai from medibv.v_giavp union all select 0 id, 0 id_loai from dual) b, (select id from medibv.v_loaivp union all select 0 from dual) c, medibvmmyy.v_ttrvll d, medibv.btdkp_bv e where a.id=d.id and b.id=a.mavp and c.id=b.id_loai and e.makp=a.makp " + exp + " group by " + agroup + ") froo group by id";
					}
					else
					if(chkPhongkham.Checked)
					{
                        asql1 = "select id, sum(to_number(sotien)) sotien from (select to_char(" + agroup + ") id, sum(nvl(a.soluong,0)*nvl(a.dongia,0)-nvl(a.thieu,0)) sotien from medibvmmyy.v_vienphict a, (select id, id_loai from medibv.v_giavp union all select id, 0 id_loai from medibv.d_dmbd) b, (select id from medibv.v_loaivp union all select 0 from dual) c, medibvmmyy.v_vienphill d, medibv.btdkp_bv e where a.id=d.id and b.id=a.mavp and c.id=b.id_loai and e.makp=a.makp  " + exp + " group by " + agroup + ") froo group by id";
					}
					else
					{
                        asql1 = "select to_char(" + agroup + ") id, sum(nvl(a.soluong,0)*nvl(a.dongia,0)+nvl(a.soluong,0)*nvl(a.dongia,0)*round(nvl(a.vat,0)/100,3)) sotien from medibvmmyy.v_ttrvct a, (select id, id_loai from medibv.v_giavp union all select id, 0 id_loai from medibv.d_dmbd) b, (select id from medibv.v_loaivp union all select 0 from dual) c, medibvmmyy.v_ttrvll d, medibv.btdkp_bv e where a.id=d.id and b.id=a.mavp and c.id=b.id_loai and e.makp=a.makp " + exp + " group by " + agroup;
					}
                ads1 = m_v.get_data_mmyy(asql1, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true);
					//MessageBox.Show(ads1.Tables[0].Rows.Count.ToString());
					for(int i=0;i<ads.Tables[0].Rows.Count;i++)
					{
						try
						{
                            string s = ads.Tables[0].Rows[i]["id"].ToString().Trim();
                            string n = ads.Tables[0].Rows[i]["ten"].ToString().Trim();
							foreach(DataRow r in ads1.Tables[0].Select("id='"+ads.Tables[0].Rows[i]["id"].ToString().Trim()+"'"))
							{
								ads.Tables[0].Rows[i]["sotien"]=decimal.Parse(ads.Tables[0].Rows[i]["sotien"].ToString())+decimal.Parse(decimal.Parse(r["sotien"].ToString()).ToString("###,###,##0.###"));
							}
						}
						catch
						{
						}
                    }
               //ads.WriteXml("c:/thu1.xml", XmlWriteMode.WriteSchema);
#endregion

                #region BHYT sotien
					if(((!chkPhongkham.Checked)&&(!chkNoitru.Checked))||((chkPhongkham.Checked)&&(chkNoitru.Checked)))
					{
                        asql1 = "select '-1' id, sum(sotien) sotien from (select '-1' id, sum(to_number(decode(f.id,null,decode(a.madoituong,1,a.mien,0),0))) sotien from medibvmmyy.v_vienphict a, medibvmmyy.v_vienphill d, (" + asqlht + ") f where a.id=d.id and f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp + " union all select '-1' id, sum(to_number(decode(f.id,null,nvl(d.bhyt,0),0))) sotien from medibvmmyy.v_ttrvll d, (" + asqlht + ") f where f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp + ") as a";
					}
					else
						if(chkPhongkham.Checked)
					{
                        asql1 = "select '-1' id, sum(to_number(decode(f.id,null,decode(a.madoituong,1,a.mien,0),0))) sotien from medibvmmyy.v_vienphict a, medibvmmyy.v_vienphill d, (" + asqlht + ") f where a.id=d.id and f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp;
					}
					else
					{
                        asql1 = "select '-1' id, sum(to_number(decode(f.id,null,nvl(d.bhyt,0),0))) sotien from medibvmmyy.v_ttrvll d, (" + asqlht + ") f where f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp;
					}
                ads1 = m_v.get_data_mmyy(asql1, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true);// m_v.get_data_bc(txtTN.Value.AddMonths(-1), txtDN.Value.AddMonths(1), asql1);
					
					for(int i=0;i<ads.Tables[0].Rows.Count;i++)
					{
						try
						{
							foreach(DataRow r in ads1.Tables[0].Select("id='"+ads.Tables[0].Rows[i]["id"].ToString().Trim()+"'"))
							{
								ads.Tables[0].Rows[i]["sotien"]=decimal.Parse(ads.Tables[0].Rows[i]["sotien"].ToString())+decimal.Parse(decimal.Parse(r["sotien"].ToString()).ToString("###,###,##0.###"));
							}
						}
						catch
						{
						}
                    }
                    //ads.WriteXml("c:/thu2.xml", XmlWriteMode.WriteSchema);
#endregion

                #region Mien
					if(((!chkPhongkham.Checked)&&(!chkNoitru.Checked))||((chkPhongkham.Checked)&&(chkNoitru.Checked)))
					{
                        asql1 = "select '-2' id, sum(to_number(sotien)) sotien from (select sum(to_number(decode(f.id,null,nvl(a.sotien,0),0))) sotien from medibvmmyy.v_mienngtru a, medibvmmyy.v_vienphill d, (" + asqlht + ") f where a.id=d.id and f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp + " union all select sum(to_number(decode(f.id,null,nvl(d.mien,0),0))) sotien from medibvmmyy.v_ttrvll d, (" + asqlht + ") f where f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp + ") froo ";
					}
					else
						if(chkPhongkham.Checked)
					{
                        asql1 = "select '-2' id, sum(to_number(decode(f.id,null,nvl(a.sotien,0),0))) sotien from medibvmmyy.v_mienngtru a, medibvmmyy.v_vienphill d, (" + asqlht + ") f where a.id=d.id and f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp;
					}
					else
					{
                        asql1 = "select '-2' id, sum(to_number(decode(f.id,null,nvl(d.mien,0),0))) sotien from medibvmmyy.v_ttrvll d, (" + asqlht + ") f where f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp;
					}
                ads1 = m_v.get_data_mmyy(asql1, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true);// m_v.get_data_bc(txtTN.Value.AddMonths(-1), txtDN.Value.AddMonths(1), asql1);
					
					for(int i=0;i<ads.Tables[0].Rows.Count;i++)
					{
						try
						{
							foreach(DataRow r in ads1.Tables[0].Select("id='"+ads.Tables[0].Rows[i]["id"].ToString().Trim()+"'"))
							{
								ads.Tables[0].Rows[i]["sotien"]=decimal.Parse(ads.Tables[0].Rows[i]["sotien"].ToString())+decimal.Parse(decimal.Parse(r["sotien"].ToString()).ToString("###,###,##0.###"));
							}
						}
						catch
						{
						}
                    }
                    //ads.WriteXml("c:/thu3.xml", XmlWriteMode.WriteSchema);
#endregion

                #region Tru theo khoa phong BHYT
                    if (rd1.Checked)
					{
						//BHYT
						if(((!chkPhongkham.Checked)&&(!chkNoitru.Checked))||((chkPhongkham.Checked)&&(chkNoitru.Checked)))
						{
                            asql1 = "select to_char(nvl(to_number(d.makp),'-3')) id, sum(to_number(decode(f.id,null,nvl(d.bhyt,0),0))) sotien from medibvmmyy.v_ttrvll d, (" + asqlht + ") f where f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp + " group by to_char(nvl(to_number(d.makp),'-3'))" + " union all " + "select to_char(nvl(to_number(a.makp),'-3')) id, sum(to_number(decode(f.id,null,decode(a.madoituong,1,nvl(a.mien,0),0),0))) sotien from medibvmmyy.v_vienphict a, medibvmmyy.v_vienphill d, (" + asqlht + ") f where d.id=a.id and f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp + " group by to_char(nvl(to_number(a.makp),'-3'))";
						}
						else
							if(chkPhongkham.Checked)
						{
                            asql1 = "select to_char(nvl(to_number(d.makp),'-3')) id, sum(to_number(decode(f.id,null,decode(a.madoituong,1,nvl(a.mien,0),0),0))) sotien from medibvmmyy.v_vienphict a, v_vienphill d, (" + asqlht + ") f where d.id=a.id and f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp + " group by to_char(nvl(to_number(a.makp),'-3'))";
						}
						else
						{
                            asql1 = "select to_char(nvl(to_number(d.makp),'-3')) id, sum(to_number(decode(f.id,null,nvl(d.bhyt,0),0))) sotien from medibvmmyy.v_ttrvll d, (" + asqlht + ") f where f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp + " group by nto_char(nvl(to_number(d.makp),'-3'))";
						}
                    ads1 = m_v.get_data_mmyy(asql1, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true);// m_v.get_data_bc(txtTN.Value.AddMonths(-1), txtDN.Value.AddMonths(1), asql1);
				
						for(int i=0;i<ads.Tables[0].Rows.Count;i++)
						{
							try
							{
                               

								foreach(DataRow r in ads1.Tables[0].Select("id='"+ads.Tables[0].Rows[i]["id"].ToString().Trim()+"'"))
								{
									ads.Tables[0].Rows[i]["sotien"]=decimal.Parse(ads.Tables[0].Rows[i]["sotien"].ToString())-decimal.Parse(decimal.Parse(r["sotien"].ToString()).ToString("###,###,##0.###"));
								}
							}
							catch
							{
							}
                        }
                        //ads.WriteXml("c:/thu4.xml", XmlWriteMode.WriteSchema);
                    #endregion
                
                #region   Mien
                        if (((!chkPhongkham.Checked)&&(!chkNoitru.Checked))||((chkPhongkham.Checked)&&(chkNoitru.Checked)))
						{
                            asql1 = "select to_char(nvl(to_number(d.makp),'-3')) id, sum(to_number(decode(f.id,null,nvl(a.sotien,0),0))) sotien from medibvmmyy.v_mienngtru a, medibvmmyy.v_vienphill d, (" + asqlht + ") f where a.id=d.id and f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp + " group by to_char(nvl(to_number(d.makp),'-3'))" + " union all " + "select nvl(to_char(d.makp),'-3') id, sum(to_number(decode(f.id,null,nvl(d.mien,0),0))) sotien from medibvmmyy.v_ttrvll d, (" + asqlht + ") f where f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp + " group by to_char(nvl(to_number(d.makp),'-3'))";
						}
						else
							if(chkPhongkham.Checked)
						{
                            asql1 = "select to_char(nvl(to_number(d.makp),'-3')) id, sum(to_number(decode(f.id,null,nvl(a.sotien,0),0))) sotien from medibvmmyy.v_mienngtru a, medibvmmyy.v_vienphill d, (" + asqlht + ") f where a.id=d.id and f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp + " group by to_char(nvl(to_number(d.makp),'-3'))";
						}
						else
						{
                            asql1 = "select to_char(nvl(to_number(d.makp),'-3')) id, sum(to_number(decode(f.id,null,nvl(d.mien,0),0))) sotien from medibvmmyy.v_ttrvll d, (" + asqlht + ") f where f.quyenso(+)d.quyenso and f.sobienlai(+)=d.sobienlai " + exp + " group by to_char(nvl(to_number(d.makp),'-3'))";
						}
                    ads1 = m_v.get_data_mmyy(asql1, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true);//m_v.get_data_bc(txtTN.Value.AddMonths(-1), txtDN.Value.AddMonths(1),asql1);
					
						for(int i=0;i<ads.Tables[0].Rows.Count;i++)
						{
							try
							{
                                string s = ads.Tables[0].Rows[i]["id"].ToString().Trim();
                                string n = ads.Tables[0].Rows[i]["ten"].ToString().Trim();

								foreach(DataRow r in ads1.Tables[0].Select("id='"+ads.Tables[0].Rows[i]["id"].ToString().Trim()+"'"))
								{
									ads.Tables[0].Rows[i]["sotien"]=decimal.Parse(ads.Tables[0].Rows[i]["sotien"].ToString())-decimal.Parse(decimal.Parse(r["sotien"].ToString()).ToString("###,###,##0.###"));
								}
							}
							catch
							{
							}
						}
                        //ads.WriteXml("c:/thu5.xml", XmlWriteMode.WriteSchema);
                    }
                        #endregion   End Tru theo khoa phong
                }
				catch
				{
				}
                #region Luy ke thang
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
					if(((!chkPhongkham.Checked)&&(!chkNoitru.Checked))||((chkPhongkham.Checked)&&(chkNoitru.Checked)))
					{
                        asql1 = "select id, sum(to_number(sotien)) sotien from (select to_char(" + agroup + ") id, sum(nvl(a.soluong,0)*nvl(a.dongia,0)-nvl(a.thieu,0)) sotien from medibvmmyy.v_vienphict a, (select id, id_loai from medibv.v_giavp union all select id, 0 id_loai from medibv.d_dmbd) b, (select id from medibv.v_loaivp union all select 0 from dual) c, medibvmmyy.v_vienphill d, medibv.btdkp_bv e where a.id=d.id and b.id(+)=a.mavp and c.id(+)=b.id_loai and e.makp(+)=a.makp " + exp + " group by " + agroup + " union all select to_char(" + agroup + ") id, sum(nvl(a.soluong,0)*nvl(a.dongia,0)+nvl(a.soluong,0)*nvl(a.dongia,0)*round(nvl(a.vat,0)/100,3)) sotien from medibvmmyy.v_ttrvct a, (select id, id_loai from medibv.v_giavp union all select 0 id, 0 id_loai from dual) b, (select id from medibv.v_loaivp union all select 0 from dual) c, medibvmmyy.v_ttrvll d, medibv.btdkp_bv e where a.id=d.id and b.id(+)=a.mavp and c.id(+)=b.id_loai and e.makp(+)=a.makp " + exp + " group by " + agroup + ") froo group by id";
					}
					else
						if(chkPhongkham.Checked)
					{
                        asql1 = "select id, sum(to_number(sotien)) sotien from (select to_char(" + agroup + ") id, sum(nvl(a.soluong,0)*nvl(a.dongia,0)-nvl(a.thieu,0)) sotien from medibvmmyy.v_vienphict a, (select id, id_loai from medibv.v_giavp union all select id, 0 id_loai from medibv.d_dmbd) b, (select id from medibv.v_loaivp union all select 0 from dual) c, medibvmmyy.v_vienphill d, medibv.btdkp_bv e where a.id=d.id and b.id(+)=a.mavp and c.id(+)=b.id_loai and e.makp(+)=a.makp " + exp + " group by " + agroup + ") froo group by id";
					}
					else
					{
                        asql1 = "select to_char(" + agroup + ") id, sum(nvl(a.soluong,0)*nvl(a.dongia,0)+nvl(a.soluong,0)*nvl(a.dongia,0)*round(nvl(a.vat,0)/100,3)) sotien from medibvmmyy.v_ttrvct a, (select id, id_loai from medibv.v_giavp union all select id, 0 id_loai from medibv.d_dmbd) b, (select id from medibv.v_loaivp union all select 0 from dual) c, medibvmmyy.v_ttrvll d, medibv.btdkp_bv e where a.id=d.id and b.id(+)=a.mavp and c.id(+)=b.id_loai and e.makp(+)=a.makp " + exp + " group by " + agroup;
					}
                ads1 = m_v.get_data_mmyy(asql1, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true);//m_v.get_data_bc(txtTN.Value.AddMonths(-1), txtDN.Value.AddMonths(1),asql1);
					for(int i=0;i<ads.Tables[0].Rows.Count;i++)
					{
						try
						{
							foreach(DataRow r in ads1.Tables[0].Select("id='"+ads.Tables[0].Rows[i]["id"].ToString().Trim()+"'"))
							{
								ads.Tables[0].Rows[i]["luykethang"]=decimal.Parse(ads.Tables[0].Rows[i]["luykethang"].ToString())+decimal.Parse(decimal.Parse(r["sotien"].ToString()).ToString("###,###,##0.###"));
							}
						}
						catch
						{
						}
                    }
                    //ads.WriteXml("c:/thu6.xml", XmlWriteMode.WriteSchema);
#endregion

                #region BHYT
					if(((!chkPhongkham.Checked)&&(!chkNoitru.Checked))||((chkPhongkham.Checked)&&(chkNoitru.Checked)))
					{
                        asql1 = "select '-1' id, sum(to_number(sotien)) sotien from (select '-1' id, sum(to_number(decode(f.id,null,decode(a.madoituong,1,a.mien,0),0))) sotien from medibvmmyy.v_vienphict a, medibvmmyy.v_vienphill d, (" + asqlht + ") f where a.id=d.id and f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp + " union all select '-1' id, sum(to_number(decode(f.id,null,nvl(d.bhyt,0),0))) sotien from medibvmmyy.v_ttrvll d, (" + asqlht + ") f where f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp + ") froo ";
					}
					else
						if(chkPhongkham.Checked)
					{
                        asql1 = "select '-1' id, sum(to_number(decode(f.id,null,decode(a.madoituong,1,a.mien,0),0))) sotien from medibvmmyy.v_vienphict a, medibvmmyy.v_vienphill d, (" + asqlht + ") f where a.id=d.id and f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp;
					}
					else
					{
                        asql1 = "select '-1' id, sum(to_number(decode(f.id,null,nvl(d.bhyt,0),0))) sotien from medibvmmyy.v_ttrvll d, (" + asqlht + ") f where f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp;
					}
                ads1 = m_v.get_data_mmyy(asql1, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true); //m_v.get_data_bc(txtTN.Value.AddMonths(-1), txtDN.Value.AddMonths(1), asql1);
					
					for(int i=0;i<ads.Tables[0].Rows.Count;i++)
					{
						try
						{
							foreach(DataRow r in ads1.Tables[0].Select("id='"+ads.Tables[0].Rows[i]["id"].ToString().Trim()+"'"))
							{
								ads.Tables[0].Rows[i]["luykethang"]=decimal.Parse(ads.Tables[0].Rows[i]["luykethang"].ToString())+decimal.Parse(decimal.Parse(r["sotien"].ToString()).ToString("###,###,##0.###"));
							}
						}
						catch
						{
						}
                    }
                    //ads.WriteXml("c:/thu7.xml", XmlWriteMode.WriteSchema);
#endregion

                #region Mien

                    if (((!chkPhongkham.Checked)&&(!chkNoitru.Checked))||((chkPhongkham.Checked)&&(chkNoitru.Checked)))
					{
                        asql1 = "select '-2' id, sum(to_number(sotien)) sotien from (select sum(to_number(decode(f.id,null,nvl(a.sotien,0),0))) sotien from medibvmmyy.v_mienngtru a, medibvmmyy.v_vienphill d, (" + asqlht + ") f where a.id=d.id and f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp + " union all select sum(to_number(decode(f.id,null,nvl(d.mien,0),0))) sotien from medibvmmyy.v_ttrvll d, (" + asqlht + ") f where f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp + ") froo ";
					}
					else
						if(chkPhongkham.Checked)
					{
                        asql1 = "select '-2' id, sum(to_number(decode(f.id,null,nvl(a.sotien,0),0))) sotien from medibvmmyy.v_mienngtru a, medibvmmyy.v_vienphill d, (" + asqlht + ") f where a.id=d.id and f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp;
					}
					else
					{
                        asql1 = "select '-2' id, sum(to_number(decode(f.id,null,nvl(d.mien,0),0))) sotien from medibvmmyy.v_ttrvll d, (" + asqlht + ") f where f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp;
					}
                ads1 = m_v.get_data_mmyy(asql1, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true);//m_v.get_data_bc(txtTN.Value.AddMonths(-1), txtDN.Value.AddMonths(1),asql1);
					
					for(int i=0;i<ads.Tables[0].Rows.Count;i++)
					{
						try
						{
							foreach(DataRow r in ads1.Tables[0].Select("id='"+ads.Tables[0].Rows[i]["id"].ToString().Trim()+"'"))
							{
								ads.Tables[0].Rows[i]["luykethang"]=decimal.Parse(ads.Tables[0].Rows[i]["luykethang"].ToString())+decimal.Parse(decimal.Parse(r["sotien"].ToString()).ToString("###,###,##0.###"));
							}
						}
						catch
						{
						}
                    }
                    //ads.WriteXml("c:/thu8.xml", XmlWriteMode.WriteSchema);
                    #endregion 

                    //Tru theo khoa phong
					if(rd1.Checked)
					{
                        #region BHYT
						if(((!chkPhongkham.Checked)&&(!chkNoitru.Checked))||((chkPhongkham.Checked)&&(chkNoitru.Checked)))
						{
                            asql1 = "select to_char(nvl(to_number(d.makp),'-3')) id, sum(to_number(decode(f.id,null,nvl(d.bhyt,0),0))) sotien from medibvmmyy.v_ttrvll d, (" + asqlht + ") f where f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp + " group by to_char(nvl(to_number(d.makp),'-3'))" + " union all " + "select to_char(nvl(to_number(a.makp),'-3')) id, sum(to_number(decode(f.id,null,decode(a.madoituong,1,nvl(a.mien,0),0),0))) sotien from medibvmmyy.v_vienphict a, medibvmmyy.v_vienphill d, (" + asqlht + ") f where d.id=a.id and f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp + " group by to_char(nvl(to_number(a.makp),'-3'))";
						}
						else
							if(chkPhongkham.Checked)
						{
                            asql1 = "select to_char(nvl(to_number(a.makp),'-3')) id, sum(to_number(decode(f.id,null,decode(a.madoituong,1,nvl(a.mien,0),0),0))) sotien from medibvmmyy.v_vienphict a, medibvmmyy.v_vienphill d, (" + asqlht + ") f where d.id=a.id and f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp + " group by to_char(nvl(to_number(a.makp),'-3'))";
						}
						else
						{
                            asql1 = "select to_char(nvl(to_number(d.makp),'-3')) id, sum(to_number(decode(f.id,null,nvl(d.bhyt,0),0))) sotien from medibvmmyy.v_ttrvll d, (" + asqlht + ") f where f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp + " group byto_char(nvl(to_number(d.makp),'-3'))";
						}
                    ads1 = m_v.get_data_mmyy(asql1, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true);//m_v.get_data_bc(txtTN.Value.AddMonths(-1), txtDN.Value.AddMonths(1),asql1);
					
						for(int i=0;i<ads.Tables[0].Rows.Count;i++)
						{
							try
							{
								foreach(DataRow r in ads1.Tables[0].Select("id='"+ads.Tables[0].Rows[i]["id"].ToString().Trim()+"'"))
								{
									ads.Tables[0].Rows[i]["luykethang"]=decimal.Parse(ads.Tables[0].Rows[i]["luykethang"].ToString())-decimal.Parse(decimal.Parse(r["sotien"].ToString()).ToString("###,###,##0.###"));
								}
							}
							catch
							{
							}
                        }
#endregion

                        #region Mien
                        if (((!chkPhongkham.Checked)&&(!chkNoitru.Checked))||((chkPhongkham.Checked)&&(chkNoitru.Checked)))
						{
                            asql1 = "select to_char(nvl(to_number(d.makp),'-3')) id, sum(to_number(decode(f.id,null,nvl(a.sotien,0),0))) sotien from medibvmmyy.v_mienngtru a, medibvmmyy.v_vienphill d, (" + asqlht + ") f where a.id=d.id and f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp + " group by to_char(nvl(to_number(d.makp),'-3'))" + " union all " + "select to_char(nvl(to_number(d.makp),'-3')) id, sum(to_number(decode(f.id,null,nvl(d.mien,0),0))) sotien from medibvmmyy.v_ttrvll d, (" + asqlht + ") f where f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp + " group by to_char(nvl(to_number(d.makp),'-3'))";
						}
						else
							if(chkPhongkham.Checked)
						{
                            asql1 = "select to_char(nvl(to_number(d.makp),'-3')) id, sum(to_number(decode(f.id,null,nvl(a.sotien,0),0))) sotien from medibvmmyy.v_mienngtru a, medibvmmyy.v_vienphill d, (" + asqlht + ") f where a.id=d.id and f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp + " group by to_char(nvl(to_number(d.makp),'-3'))";
						}
						else
						{
                            asql1 = "select to_char(nvl(to_number(d.makp),'-3')) id, sum(to_number(decode(f.id,null,nvl(d.mien,0),0))) sotien from medibvmmyy.v_ttrvll d, (" + asqlht + ") f where f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp + " group by to_char(nvl(to_number(d.makp),'-3'))";
						}
                        ads1 = m_v.get_data_mmyy(asql1, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true);//m_v.get_data_bc(txtTN.Value.AddMonths(-1), txtDN.Value.AddMonths(1),asql1);
					
						for(int i=0;i<ads.Tables[0].Rows.Count;i++)
						{
							try
							{
								foreach(DataRow r in ads1.Tables[0].Select("id='"+ads.Tables[0].Rows[i]["id"].ToString().Trim()+"'"))
								{
									ads.Tables[0].Rows[i]["luykethang"]=decimal.Parse(ads.Tables[0].Rows[i]["luykethang"].ToString())-decimal.Parse(decimal.Parse(r["sotien"].ToString()).ToString("###,###,##0.###"));
								}
							}
							catch
							{
							}
						}
                        //ads.WriteXml("c:/thu8-1.xml", XmlWriteMode.WriteSchema);
                    }
                        #endregion
                    //End Tru theo khoa phong
				}
				catch
				{
				}

                //Luy ke nam
                #region
                try
				{
					exp=" and to_date(to_char(d.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('01/01"+txtDN.Text.Substring(5,5)+"','dd/mm/yyyy') and to_date(to_char(d.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')<=to_date('"+txtDN.Text.Substring(0,10)+"','dd/mm/yyyy')";
					asqlht="select * from medibv.v_hoantra where to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('01/01"+txtDN.Text.Substring(5,5)+"','dd/mm/yyyy') and to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy')<=to_date('"+txtDN.Text.Substring(0,10)+"','dd/mm/yyyy')";
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
					if(((!chkPhongkham.Checked)&&(!chkNoitru.Checked))||((chkPhongkham.Checked)&&(chkNoitru.Checked)))
					{
                        asql1 = "select id, sum(to_number(sotien)) sotien from (select to_char(" + agroup + ") id, sum(nvl(a.soluong,0)*nvl(a.dongia,0)-nvl(a.thieu,0)) sotien from medibvmmyy.v_vienphict a, (select id, id_loai from medibv.v_giavp union all select id, 0 id_loai from medibv.d_dmbd) b, (select id from medibv.v_loaivp union all select 0 from dual) c, medibvmmyy.v_vienphill d, medibv.btdkp_bv e where a.id=d.id and b.id(+)=a.mavp and c.id(+)=b.id_loai and e.makp(+)=a.makp  " + exp + " group by " + agroup + " union all select to_char(" + agroup + ") id, sum(to_number(decode(f.id, null,nvl(a.soluong,0)*nvl(a.dongia,0)+nvl(a.soluong,0)*nvl(a.dongia,0)*round(nvl(a.vat,0)/100,3),0))) sotien from medibvmmyy.v_ttrvct a, (select id, id_loai from medibv.v_giavp union all select 0 id, 0 id_loai from dual) b, (select id from medibv.v_loaivp union all select 0 from dual) c, medibvmmyy.v_ttrvll d, medibv.btdkp_bv e, (" + asqlht + ") f where a.id=d.id and b.id(+)=a.mavp and c.id(+)=b.id_loai and e.makp(+)=a.makp and f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp + " group by " + agroup + ") froo group by id";
					}
					else
						if(chkPhongkham.Checked)
					{
                        asql1 = "select id, sum(to_number(sotien)) sotien from (select to_char(" + agroup + ") id, sum(nvl(a.soluong,0)*nvl(a.dongia,0)-nvl(a.thieu,0)) sotien from medibvmmyy.v_vienphict a, (select id, id_loai from medibv.v_giavp union all select id, 0 id_loai from medibv.d_dmbd) b, (select id from medibv.v_loaivp union all select 0 from dual) c, medibvmmyy.v_vienphill d, medibv.btdkp_bv e where a.id=d.id and b.id(+)=a.mavp and c.id(+)=b.id_loai and e.makp(+)=a.makp  " + exp + " group by " + agroup + ") froo group by id";
					}
					else
					{
                        asql1 = "select to_char(" + agroup + ") id, sum(nvl(a.soluong,0)*nvl(a.dongia,0)+nvl(a.soluong,0)*nvl(a.dongia,0)*round(nvl(a.vat,0)/100,3)) sotien from medibvmmyy.v_ttrvct a, (select id, id_loai from medibv.v_giavp union all select id, 0 id_loai from medibv.d_dmbd) b, (select id from medibv.v_loaivp union all select 0 from dual) c, medibvmmyy.v_ttrvll d, medibv.btdkp_bv e where a.id=d.id and b.id(+)=a.mavp and c.id(+)=b.id_loai and e.makp(+)=a.makp  " + exp + " group by " + agroup;
					}
                ads1 = m_v.get_data_mmyy(asql1, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true); //m_v.get_data_bc(txtTN.Value.AddMonths(-1), txtDN.Value.AddMonths(1), asql1);
					for(int i=0;i<ads.Tables[0].Rows.Count;i++)
					{
						try
						{
							foreach(DataRow r in ads1.Tables[0].Select("id='"+ads.Tables[0].Rows[i]["id"].ToString().Trim()+"'"))
							{
								ads.Tables[0].Rows[i]["luykenam"]=decimal.Parse(ads.Tables[0].Rows[i]["luykenam"].ToString())+decimal.Parse(decimal.Parse(r["sotien"].ToString()).ToString("###,###,##0.###"));
							}
						}
						catch
						{
						}
                    }
                    //ads.WriteXml("c:/thu9.xml", XmlWriteMode.WriteSchema);
                #endregion 

                #region BHYT
                    if (((!chkPhongkham.Checked)&&(!chkNoitru.Checked))||((chkPhongkham.Checked)&&(chkNoitru.Checked)))
					{
                        asql1 = "select '-1' id, sum(to_number(sotien)) sotien from (select '-1' id, sum(to_number(decode(f.id,null,decode(a.madoituong,1,a.mien,0),0))) sotien from medibvmmyy.v_vienphict a, medibvmmyy.v_vienphill d, (" + asqlht + ") f where a.id=d.id and f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp + " union all select '-1' id, sum(to_number(decode(f.id,null,nvl(d.bhyt,0),0))) sotien from medibvmmyy.v_ttrvll d, (" + asqlht + ") f where f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp + ") froo ";
					}
					else
						if(chkPhongkham.Checked)
					{
                        asql1 = "select '-1' id, sum(to_number(decode(f.id,null,decode(a.madoituong,1,a.mien,0),0))) sotien from medibvmmyy.v_vienphict a, medibvmmyy.v_vienphill d, (" + asqlht + ") f where a.id=d.id and f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp;
					}
					else
					{
                        asql1 = "select '-1' id, sum(to_number(decode(f.id,null,nvl(d.bhyt,0),0))) sotien from medibvmmyy.v_ttrvll d, (" + asqlht + ") f where f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp;
					}
                ads1 = m_v.get_data_mmyy(asql1, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true); //m_v.get_data_bc(txtTN.Value.AddMonths(-1), txtDN.Value.AddMonths(1),asql1);
					
					for(int i=0;i<ads.Tables[0].Rows.Count;i++)
					{
						try
						{
							foreach(DataRow r in ads1.Tables[0].Select("id='"+ads.Tables[0].Rows[i]["id"].ToString().Trim()+"'"))
							{
								ads.Tables[0].Rows[i]["luykenam"]=decimal.Parse(ads.Tables[0].Rows[i]["luykenam"].ToString())+decimal.Parse(decimal.Parse(r["sotien"].ToString()).ToString("###,###,##0.###"));
							}
						}
						catch
						{
						}
                    }
                    //ads.WriteXml("c:/thu10.xml", XmlWriteMode.WriteSchema);
                    #endregion

                #region Mien
					if(((!chkPhongkham.Checked)&&(!chkNoitru.Checked))||((chkPhongkham.Checked)&&(chkNoitru.Checked)))
					{
                        asql1 = "select '-2' id, sum(to_number(sotien)) sotien from (select sum(to_number(decode(f.id,null,nvl(a.sotien,0),0))) sotien from medibvmmyy.v_mienngtru a, medibvmmyy.v_vienphill d, (" + asqlht + ") f where a.id=d.id and f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp + " union all select sum(to_number(decode(f.id,null,nvl(d.mien,0),0))) sotien from medibvmmyy.v_ttrvll d, (" + asqlht + ") f where f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp + ") froo ";
					}
					else
						if(chkPhongkham.Checked)
					{
                        asql1 = "select '-2' id, sum(to_number(decode(f.id,null,nvl(a.sotien,0),0))) sotien from medibvmmyy.v_mienngtru a, medibvmmyy.v_vienphill d, (" + asqlht + ") f where a.id=d.id and f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp;
					}
					else
					{
                        asql1 = "select '-2' id, sum(to_number(decode(f.id,null,nvl(d.mien,0),0))) sotien from medibvmmyy.v_ttrvll d, (" + asqlht + ") f where f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp;
					}
                ads1 = m_v.get_data_mmyy(asql1, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true); //m_v.get_data_bc(txtTN.Value.AddMonths(-1), txtDN.Value.AddMonths(1),asql1);
					
					for(int i=0;i<ads.Tables[0].Rows.Count;i++)
					{
						try
						{
							foreach(DataRow r in ads1.Tables[0].Select("id='"+ads.Tables[0].Rows[i]["id"].ToString().Trim()+"'"))
							{
								ads.Tables[0].Rows[i]["luykenam"]=decimal.Parse(ads.Tables[0].Rows[i]["luykenam"].ToString())+decimal.Parse(decimal.Parse(r["sotien"].ToString()).ToString("###,###,##0.###"));
							}
						}
						catch
						{
						}
                    }
                    //ads.WriteXml("c:/thu11.xml", XmlWriteMode.WriteSchema);
#endregion

                    //Tru theo khoa phong
					if(rd1.Checked)
                    {
                #region	BHYT
                        if (((!chkPhongkham.Checked)&&(!chkNoitru.Checked))||((chkPhongkham.Checked)&&(chkNoitru.Checked)))
						{
                            asql1 = "select to_char(nvl(to_number(d.makp),'-3')) id, sum(to_number(decode(f.id,null,nvl(d.bhyt,0),0))) sotien from medibvmmyy.v_ttrvll d, (" + asqlht + ") f where f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp + " group by to_char(nvl(to_number(d.makp),'-3'))" + " union all " + "select to_char(nvl(to_number(a.makp),'-3')) id, sum(to_number(decode(f.id,null,decode(a.madoituong,1,nvl(a.mien,0),0),0))) sotien from medibvmmyy.v_vienphict a, medibvmmyy.v_vienphill d, (" + asqlht + ") f where d.id=a.id and f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp + " group by to_char(nvl(to_number(a.makp),'-3'))";
						}
						else
							if(chkPhongkham.Checked)
						{
                            asql1 = "select to_char(nvl(to_number(a.makp),'-3')) id, sum(to_number(decode(f.id,null,decode(a.madoituong,1,nvl(a.mien,0),0),0))) sotien from medibvmmyy.v_vienphict a, medibvmmyy.v_vienphill d, (" + asqlht + ") f where d.id=a.id and f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp + " group by to_char(nvl(to_number(a.makp),'-3'))";
						}
						else
						{
                            asql1 = "select to_char(nvl(to_number(d.makp),'-3')) id, sum(to_number(decode(f.id,null,nvl(d.bhyt,0),0))) sotien from medibvmmyy.v_ttrvll d, (" + asqlht + ") f where f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp + " group by to_char(nvl(to_number(d.makp),'-3'))";
						}
                    ads1 = m_v.get_data_mmyy(asql1, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true); //m_v.get_data_bc(txtTN.Value.AddMonths(-1), txtDN.Value.AddMonths(1),asql1);
					
						for(int i=0;i<ads.Tables[0].Rows.Count;i++)
						{
							try
							{
								foreach(DataRow r in ads1.Tables[0].Select("id='"+ads.Tables[0].Rows[i]["id"].ToString().Trim()+"'"))
								{
									ads.Tables[0].Rows[i]["luykenam"]=decimal.Parse(ads.Tables[0].Rows[i]["luykenam"].ToString())-decimal.Parse(decimal.Parse(r["sotien"].ToString()).ToString("###,###,##0.###"));
								}
							}
							catch
							{
							}
                        }
                        //ads.WriteXml("c:/thu11-1.xml", XmlWriteMode.WriteSchema);
                        #endregion

                #region Mien
						if(((!chkPhongkham.Checked)&&(!chkNoitru.Checked))||((chkPhongkham.Checked)&&(chkNoitru.Checked)))
						{
                            asql1 = "select to_char(nvl(to_number(d.makp),'-3')) id, sum(to_number(decode(f.id,null,nvl(a.sotien,0),0))) sotien from medibvmmyy.v_mienngtru a, medibvmmyy.v_vienphill d, (" + asqlht + ") f where a.id=d.id and f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp + " group by to_char(nvl(to_number(d.makp),'-3'))" + " union all " + "select to_char(nvl(to_number(d.makp),'-3')) id, sum(to_number(decode(f.id,null,nvl(d.mien,0),0))) sotien from medibvmmyy.v_ttrvll d, (" + asqlht + ") f where f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp + " group by to_char(nvl(to_number(d.makp),'-3'))";
						}
						else
							if(chkPhongkham.Checked)
						{
                            asql1 = "select to_char(nvl(to_number(d.makp),'-3')) id, sum(to_number(decode(f.id,null,nvl(a.sotien,0),0))) sotien from medibvmmyy.v_mienngtru a, medibvmmyy.v_vienphill d, (" + asqlht + ") f where a.id=d.id and f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp + " group by to_char(nvl(to_number(d.makp),'-3'))";
						}
						else
						{
                            asql1 = "select to_char(nvl(to_number(d.makp),'-3')) id, sum(to_number(decode(f.id,null,nvl(d.mien,0),0))) sotien from medibvmmyy.v_ttrvll d, (" + asqlht + ") f where f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp + " group by to_char(nvl(to_number(d.makp),'-3'))";
						}
                    ads1 = m_v.get_data_mmyy(asql1, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true); //m_v.get_data_bc(txtTN.Value.AddMonths(-1), txtDN.Value.AddMonths(1),asql1);
					
						for(int i=0;i<ads.Tables[0].Rows.Count;i++)
						{
							try
							{
								foreach(DataRow r in ads1.Tables[0].Select("id='"+ads.Tables[0].Rows[i]["id"].ToString().Trim()+"'"))
								{
									ads.Tables[0].Rows[i]["luykenam"]=decimal.Parse(ads.Tables[0].Rows[i]["luykenam"].ToString())-decimal.Parse(decimal.Parse(r["sotien"].ToString()).ToString("###,###,##0.###"));
								}
							}
							catch
							{
							}
                        }
                        //ads.WriteXml("c:/thu11-2.xml", XmlWriteMode.WriteSchema);
#endregion
                    }
					//End Tru theo khoa phong
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
				asn=(asn+1)*-1;
				int ayear=0,amonth=0;

                #region	Lock1
                if (rdThang.Checked)
				{
					ad1=ad1.AddMonths(-1);
					ad2=ad2.AddMonths(-1);

					ayear=ad1.Year;
					amonth=ad1.Month;
					ad1 = new DateTime(ayear,amonth,1);
					ad2 = new DateTime(ayear,amonth,DateTime.DaysInMonth(ayear,amonth));
				}
				else
				{
					ad1=ad1.AddDays(asn);
					ad2=ad2.AddDays(asn);
				}
				if((ad1-ad2).Days==0)
				{
					alock01=f_StringDate(ad1);
				}
				else
				{
					alock01=f_StringDate(ad1)+" - "+f_StringDate(ad2);
				}
				try
				{
					exp=" and to_date(to_char(d.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('"+f_StringDate(ad1)+"','dd/mm/yyyy') and to_date(to_char(d.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')<=to_date('"+f_StringDate(ad2)+"','dd/mm/yyyy')";
                    asqlht = "select * from medibvmmyy.v_hoantra where to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('" + f_StringDate(ad1) + "','dd/mm/yyyy') and to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy')<=to_date('" + f_StringDate(ad2) + "','dd/mm/yyyy')";
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
					if(((!chkPhongkham.Checked)&&(!chkNoitru.Checked))||((chkPhongkham.Checked)&&(chkNoitru.Checked)))
					{
                        asql1 = "select id, sum(to_number(sotien) sotien from (select to_char(" + agroup + ") id, sum(nvl(a.soluong,0)*nvl(a.dongia,0)-nvl(a.thieu,0)) sotien from medibvmmyy.v_vienphict a, (select id, id_loai from medibv.v_giavp union all select id, 0 id_loai from medibv.d_dmbd) b, (select id from medibv.v_loaivp union all select 0 from dual) c, medibvmmyy.v_vienphill d, medibv.btdkp_bv e where a.id=d.id and b.id(+)=a.mavp and c.id(+)=b.id_loai and e.makp(+)=a.makp  " + exp + " group by " + agroup + " union all select to_char(" + agroup + ") id, sum(nvl(a.soluong,0)*nvl(a.dongia,0)+nvl(a.soluong,0)*nvl(a.dongia,0)*round(nvl(a.vat,0)/100,3)) sotien from medibvmmyy.v_ttrvct a, (select id, id_loai from medibv.v_giavp union all select 0 id, 0 id_loai from dual) b, (select id from medibv.v_loaivp union all select 0 from dual) c, medibvmmyy.v_ttrvll d, medibv.btdkp_bv e where a.id=d.id and b.id(+)=a.mavp and c.id(+)=b.id_loai and e.makp(+)=a.makp  " + exp + " group by " + agroup + ") froo group by id";
					}
					else
						if(chkPhongkham.Checked)
					{
                        asql1 = "select id, sum(to_number(sotien) sotien from (select to_char(" + agroup + ") id, sum(nvl(a.soluong,0)*nvl(a.dongia,0)-nvl(a.thieu,0)) sotien from medibvmmyy.v_vienphict a, (select id, id_loai from medibv.v_giavp union all select id, 0 id_loai from medibv.d_dmbd) b, (select id from medibv.v_loaivp union all select 0 from dual) c, medibvmmyy.v_vienphill d, medibv.btdkp_bv e where a.id=d.id and b.id(+)=a.mavp and c.id(+)=b.id_loai and e.makp(+)=a.makp  " + exp + " group by " + agroup + ") froo group by id";
					}
					else
					{
                        asql1 = "select to_char(" + agroup + ") id, sum(nvl(a.soluong,0)*nvl(a.dongia,0)+nvl(a.soluong,0)*nvl(a.dongia,0)*round(nvl(a.vat,0)/100,3)) sotien from medibvmmyy.v_ttrvct a, (select id, id_loai from medibv.v_giavp union all select id, 0 id_loai from medibv.d_dmbd) b, (select id from medibv.v_loaivp union all select 0 from dual) c, medibvmmyy.v_ttrvll d, medibv.btdkp_bv e where a.id=d.id and b.id(+)=a.mavp and c.id(+)=b.id_loai and e.makp(+)=a.makp  " + exp + " group by " + agroup;
					}
                ads1 = m_v.get_data_mmyy(asql1, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true); //m_v.get_data_bc(txtTN.Value.AddMonths(-1), txtDN.Value.AddMonths(1),asql1);
					for(int i=0;i<ads.Tables[0].Rows.Count;i++)
					{
						try
						{
							foreach(DataRow r in ads1.Tables[0].Select("id='"+ads.Tables[0].Rows[i]["id"].ToString().Trim()+"'"))
							{
								ads.Tables[0].Rows[i]["lock01"]=decimal.Parse(ads.Tables[0].Rows[i]["lock01"].ToString())+decimal.Parse(decimal.Parse(r["sotien"].ToString()).ToString("###,###,##0.###"));
							}
						}
						catch
						{
						}
					}
                   
					//BHYT
					if(((!chkPhongkham.Checked)&&(!chkNoitru.Checked))||((chkPhongkham.Checked)&&(chkNoitru.Checked)))
					{
                        asql1 = "select '-1' id, sum(to_number(sotien)) sotien from (select '-1' id, sum(to_number(decode(f.id,null,decode(a.madoituong,1,a.mien,0),0))) sotien from medibvmmyy.v_vienphict a, medibvmmyy.v_vienphill d, (" + asqlht + ") f where a.id=d.id and f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp + " union all select '-1' id, sum(to_number(decode(f.id,null,nvl(d.bhyt,0),0))) sotien from medibvmmyy.v_ttrvll d, (" + asqlht + ") f where f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp + ") froo ";
					}
					else
						if(chkPhongkham.Checked)
					{
                        asql1 = "select '-1' id, sum(to_number(decode(f.id,null,decode(a.madoituong,1,a.mien,0),0))) sotien from medibvmmyy.v_vienphict a, medibvmmyy.v_vienphill d, (" + asqlht + ") f where a.id=d.id and f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp;
					}
					else
					{
                        asql1 = "select '-1' id, sum(to_number(decode(f.id,null,nvl(d.bhyt,0),0))) sotien from medibvmmyy.v_ttrvll d, (" + asqlht + ") f where f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp;
					}
                ads1 = m_v.get_data_mmyy(asql1, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true); //m_v.get_data_bc(txtTN.Value.AddMonths(-1), txtDN.Value.AddMonths(1),asql1);
					
					for(int i=0;i<ads.Tables[0].Rows.Count;i++)
					{
						try
						{
							foreach(DataRow r in ads1.Tables[0].Select("id='"+ads.Tables[0].Rows[i]["id"].ToString().Trim()+"'"))
							{
								ads.Tables[0].Rows[i]["lock01"]=decimal.Parse(ads.Tables[0].Rows[i]["lock01"].ToString())+decimal.Parse(decimal.Parse(r["sotien"].ToString()).ToString("###,###,##0.###"));
							}
						}
						catch
						{
						}
					}
                    //ads.WriteXml("c:/thu13.xml", XmlWriteMode.WriteSchema);
					//Mien
					if(((!chkPhongkham.Checked)&&(!chkNoitru.Checked))||((chkPhongkham.Checked)&&(chkNoitru.Checked)))
					{
                        asql1 = "select '-2' id, sum(to_number(sotien)) sotien from (select sum(to_number(decode(f.id,null,nvl(a.sotien,0),0))) sotien from medibvmmyy.v_mienngtru a, medibvmmyy.v_vienphill d, (" + asqlht + ") f where a.id=d.id and f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp + " union all select sum(to_number(decode(f.id,null,nvl(d.mien,0),0))) sotien from medibvmmyy.v_ttrvll d, (" + asqlht + ") f where f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp + ") froo ";
					}
					else
						if(chkPhongkham.Checked)
					{
                        asql1 = "select '-2' id, sum(to_number(decode(f.id,null,nvl(a.sotien,0),0))) sotien from medibvmmyy.v_mienngtru a, medibvmmyy.v_vienphill d, (" + asqlht + ") f where a.id=d.id and f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp;
					}
					else
					{
                        asql1 = "select '-2' id, sum(to_number(decode(f.id,null,nvl(d.mien,0),0))) sotien from medibvmmyy.v_ttrvll d, (" + asqlht + ") f where f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp;
					}
                ads1 = m_v.get_data_mmyy(asql1, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true); //m_v.get_data_bc(txtTN.Value.AddMonths(-1), txtDN.Value.AddMonths(1),asql1);
					
					for(int i=0;i<ads.Tables[0].Rows.Count;i++)
					{
						try
						{
							foreach(DataRow r in ads1.Tables[0].Select("id='"+ads.Tables[0].Rows[i]["id"].ToString().Trim()+"'"))
							{
								ads.Tables[0].Rows[i]["lock01"]=decimal.Parse(ads.Tables[0].Rows[i]["lock01"].ToString())+decimal.Parse(decimal.Parse(r["sotien"].ToString()).ToString("###,###,##0.###"));
							}
						}
						catch
						{
						}
					}
                    //ads.WriteXml("c:/thu14.xml", XmlWriteMode.WriteSchema);
					//Tru theo khoa phong
					if(rd1.Checked)
					{
						//BHYT
						if(((!chkPhongkham.Checked)&&(!chkNoitru.Checked))||((chkPhongkham.Checked)&&(chkNoitru.Checked)))
						{
                            asql1 = "select to_char(nvl(to_number(d.makp),'-3')) id, sum(to_number(decode(f.id,null,nvl(d.bhyt,0),0))) sotien from medibvmmyy.v_ttrvll d, (" + asqlht + ") f where f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp + " group by to_char(nvl(to_number(d.makp),'-3'))" + " union all " + "select to_char(nvl(to_number(a.makp),'-3')) id, sum(to_number(decode(f.id,null,decode(a.madoituong,1,nvl(a.mien,0),0),0))) sotien from medibvmmyy.v_vienphict a, medibvmmyy.v_vienphill d, (" + asqlht + ") f where d.id=a.id and f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp + " group by to_char(nvl(to_number(a.makp),'-3'))";
						}
						else
							if(chkPhongkham.Checked)
						{
                            asql1 = "select to_char(nvl(to_number(a.makp),'-3')) id, sum(to_number(decode(f.id,null,decode(a.madoituong,1,nvl(a.mien,0),0),0))) sotien from medibvmmyy.v_vienphict a, medibvmmyy.v_vienphill d, (" + asqlht + ") f where d.id=a.id and f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp + " group by to_char(nvl(to_number(a.makp),'-3'))";
						}
						else
						{
                            asql1 = "select to_char(nvl(to_number(d.makp),'-3')) id, sum(to_number(decode(f.id,null,nvl(d.bhyt,0),0))) sotien from medibvmmyy.v_ttrvll d, (" + asqlht + ") f where f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp + " group by to_char(nvl(to_number(d.makp),'-3'))";
						}
                    ads1 = m_v.get_data_mmyy(asql1, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true); //m_v.get_data_bc(txtTN.Value.AddMonths(-1), txtDN.Value.AddMonths(1),asql1);
					
						for(int i=0;i<ads.Tables[0].Rows.Count;i++)
						{
							try
							{
								foreach(DataRow r in ads1.Tables[0].Select("id='"+ads.Tables[0].Rows[i]["id"].ToString().Trim()+"'"))
								{
									ads.Tables[0].Rows[i]["lock01"]=decimal.Parse(ads.Tables[0].Rows[i]["lock01"].ToString())-decimal.Parse(decimal.Parse(r["sotien"].ToString()).ToString("###,###,##0.###"));
								}
							}
							catch
							{
							}
						}
                        //ads.WriteXml("c:/thulock1_kp.xml", XmlWriteMode.WriteSchema);
						//Mien
						if(((!chkPhongkham.Checked)&&(!chkNoitru.Checked))||((chkPhongkham.Checked)&&(chkNoitru.Checked)))
						{
                            asql1 = "select to_char(nvl(to_number(d.makp),'-3')) id, sum(to_number(decode(f.id,null,nvl(a.sotien,0),0))) sotien from medibvmmyy.v_mienngtru a, medibvmmyy.v_vienphill d, (" + asqlht + ") f where a.id=d.id and f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp + " group by to_char(nvl(to_number(d.makp),'-3'))" + " union all " + "select to_char(nvl(to_number(d.makp),'-3')) id, sum(to_number(decode(f.id,null,nvl(d.mien,0),0))) sotien from medibvmmyy.v_ttrvll d, (" + asqlht + ") f where f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp + " group by to_char(nvl(to_number(d.makp),'-3'))";
						}
						else
							if(chkPhongkham.Checked)
						{
                            asql1 = "select to_char(nvl(to_number(d.makp),'-3')) id, sum(to_number(decode(f.id,null,nvl(a.sotien,0),0))) sotien from medibvmmyy.v_mienngtru a, medibvmmyy.v_vienphill d, (" + asqlht + ") f where a.id=d.id and f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp + " group by to_char(nvl(to_number(d.makp),'-3'))";
						}
						else
						{
                            asql1 = "select to_char(nvl(to_number(d.makp),'-3')) id, sum(to_number(decode(f.id,null,nvl(d.mien,0),0))) sotien from medibvmmyy.v_ttrvll d, (" + asqlht + ") f where f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp + " group by to_char(nvl(to_number(d.makp),'-3'))";
						}
                    ads1 = m_v.get_data_mmyy(asql1, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true); //m_v.get_data_bc(txtTN.Value.AddMonths(-1), txtDN.Value.AddMonths(1),asql1);
					
						for(int i=0;i<ads.Tables[0].Rows.Count;i++)
						{
							try
							{
								foreach(DataRow r in ads1.Tables[0].Select("id='"+ads.Tables[0].Rows[i]["id"].ToString().Trim()+"'"))
								{
									ads.Tables[0].Rows[i]["lock01"]=decimal.Parse(ads.Tables[0].Rows[i]["lock01"].ToString())-decimal.Parse(decimal.Parse(r["sotien"].ToString()).ToString("###,###,##0.###"));
								}
							}
							catch
							{
							}
						}
                        //  ads.WriteXml("c:/thulock1_loi.xml", XmlWriteMode.WriteSchema);
					}
					//End Tru theo khoa phong
				}
				catch
				{
                }
                #endregion
                #region Lock2
				if(rdThang.Checked)
				{
					ad1=ad1.AddMonths(-1);
					ad2=ad2.AddMonths(-1);

					ayear=ad1.Year;
					amonth=ad1.Month;
					ad1 = new DateTime(ayear,amonth,1);
					ad2 = new DateTime(ayear,amonth,DateTime.DaysInMonth(ayear,amonth));
				}
				else
				{
					ad1=ad1.AddDays(asn);
					ad2=ad2.AddDays(asn);
				}

				if((ad1-ad2).Days==0)
				{
					alock02=f_StringDate(ad1);
				}
				else
				{
					alock02=f_StringDate(ad1)+" - "+f_StringDate(ad2);
				}
				try
				{
					exp=" and to_date(to_char(d.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('"+f_StringDate(ad1)+"','dd/mm/yyyy') and to_date(to_char(d.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')<=to_date('"+f_StringDate(ad2)+"','dd/mm/yyyy')";
					asqlht="select * from medibvmmyy.v_hoantra where to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('"+f_StringDate(ad1)+"','dd/mm/yyyy') and to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy')<=to_date('"+f_StringDate(ad2)+"','dd/mm/yyyy')";
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
					if(((!chkPhongkham.Checked)&&(!chkNoitru.Checked))||((chkPhongkham.Checked)&&(chkNoitru.Checked)))
					{
                        asql1 = "select id, sum(to_number(sotien)) sotien from (select to_char(" + agroup + ") id, sum(nvl(a.soluong,0)*nvl(a.dongia,0)-nvl(a.thieu,0)) sotien from medibvmmyy.v_vienphict a, (select id, id_loai from medibv.v_giavp union all select id, 0 id_loai from medibv.d_dmbd) b, (select id from medibv.v_loaivp union all select 0 from dual) c, medibvmmyy.v_vienphill d, medibv.btdkp_bv e where a.id=d.id and b.id(+)=a.mavp and c.id(+)=b.id_loai and e.makp(+)=a.makp  " + exp + " group by " + agroup + " union all select to_char(" + agroup + ") id, sum(nvl(a.soluong,0)*nvl(a.dongia,0)+nvl(a.soluong,0)*nvl(a.dongia,0)*round(nvl(a.vat,0)/100,3)) sotien from medibvmmyy.v_ttrvct a, (select id, id_loai from medibv.v_giavp union all select 0 id, 0 id_loai from dual) b, (select id from medibv.v_loaivp union all select 0 from dual) c, medibvmmyy.v_ttrvll d, medibv.btdkp_bv e where a.id=d.id and b.id(+)=a.mavp and c.id(+)=b.id_loai and e.makp(+)=a.makp  " + exp + " group by " + agroup + ") froo group by id";
					}
					else
						if(chkPhongkham.Checked)
					{
                        asql1 = "select id, sum(to_number(sotien)) sotien from (select to_char(" + agroup + ") id, sum( nvl(a.soluong,0)*nvl(a.dongia,0)-nvl(a.thieu,0)) sotien from medibvmmyy.v_vienphict a, (select id, id_loai from medibv.v_giavp union all select id, 0 id_loai from medibv.d_dmbd) b, (select id from medibv.v_loaivp union all select 0 from dual) c, medibvmmyy.v_vienphill d, medibv.btdkp_bv e where a.id=d.id and b.id(+)=a.mavp and c.id(+)=b.id_loai and e.makp(+)=a.makp " + exp + " group by " + agroup + ") froo group by id";
					}
					else
					{
                        asql1 = "select to_char(" + agroup + ") id, sum(nvl(a.soluong,0)*nvl(a.dongia,0)+nvl(a.soluong,0)*nvl(a.dongia,0)*round(nvl(a.vat,0)/100,3)) sotien from medibvmmyy.v_ttrvct a, (select id, id_loai from medibv.v_giavp union all select id, 0 id_loai from medibv.d_dmbd) b, (select id from medibv.v_loaivp union all select 0 from dual) c, medibvmmyy.v_ttrvll d, medibv.btdkp_bv e where a.id=d.id and b.id(+)=a.mavp and c.id(+)=b.id_loai and e.makp(+)=a.makp  " + exp + " group by " + agroup;
					}
                ads1 = m_v.get_data_mmyy(asql1, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true); //m_v.get_data_bc(txtTN.Value.AddMonths(-1), txtDN.Value.AddMonths(1),asql1);
					for(int i=0;i<ads.Tables[0].Rows.Count;i++)
					{
						try
						{
							foreach(DataRow r in ads1.Tables[0].Select("id='"+ads.Tables[0].Rows[i]["id"].ToString().Trim()+"'"))
							{
								ads.Tables[0].Rows[i]["lock02"]=decimal.Parse(ads.Tables[0].Rows[i]["lock02"].ToString())+decimal.Parse(decimal.Parse(r["sotien"].ToString()).ToString("###,###,##0.###"));
							}
						}
						catch
						{
						}
					}
                //    ads.WriteXml("c:/lock2.xml", XmlWriteMode.WriteSchema);
					//BHYT
					if(((!chkPhongkham.Checked)&&(!chkNoitru.Checked))||((chkPhongkham.Checked)&&(chkNoitru.Checked)))
					{
                        asql1 = "select '-1' id, sum(to_number(sotien)) sotien from (select '-1' id, sum(to_number(decode(f.id,null,decode(a.madoituong,1,a.mien,0),0))) sotien from medibvmmyy.v_vienphict a, medibvmmyy.v_vienphill d, (" + asqlht + ") f where a.id=d.id and f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp + " union all select '-1' id, sum(to_number(decode(f.id,null,nvl(d.bhyt,0),0))) sotien from medibvmmyy.v_ttrvll d, (" + asqlht + ") f where f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp + ") froo ";
					}
					else
						if(chkPhongkham.Checked)
					{
                        asql1 = "select '-1' id, sum(to_number(decode(f.id,null,decode(a.madoituong,1,a.mien,0),0))) sotien from medibvmmyy.v_vienphict a, medibvmmyy.v_vienphill d, (" + asqlht + ") f where a.id=d.id and f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp;
					}
					else
					{
                        asql1 = "select '-1' id, sum(to_number(decode(f.id,null,nvl(d.bhyt,0),0))) sotien from medibvmmyy.v_ttrvll d, (" + asqlht + ") f where f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp;
					}
                ads1 = m_v.get_data_mmyy(asql1, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true); //m_v.get_data_bc(txtTN.Value.AddMonths(-1), txtDN.Value.AddMonths(1),asql1);
					
					for(int i=0;i<ads.Tables[0].Rows.Count;i++)
					{
						try
						{
							foreach(DataRow r in ads1.Tables[0].Select("id='"+ads.Tables[0].Rows[i]["id"].ToString().Trim()+"'"))
							{
								ads.Tables[0].Rows[i]["lock02"]=decimal.Parse(ads.Tables[0].Rows[i]["lock02"].ToString())+decimal.Parse(decimal.Parse(r["sotien"].ToString()).ToString("###,###,##0.###"));
							}
						}
						catch
						{
						}
					}
               //     ads.WriteXml("c:/lock2.xml", XmlWriteMode.WriteSchema);
					//Mien
					if(((!chkPhongkham.Checked)&&(!chkNoitru.Checked))||((chkPhongkham.Checked)&&(chkNoitru.Checked)))
					{
                        asql1 = "select '-2' id, sum(sotien) sotien from (select sum(to_number(decode(f.id,null,nvl(a.sotien,0),0))) sotien from medibvmmyy.v_mienngtru a, medibvmmyy.v_vienphill d, (" + asqlht + ") f where a.id=d.id and f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp + " union all select sum(to_number(decode(f.id,null,nvl(d.mien,0),0))) sotien from medibvmmyy.v_ttrvll d, (" + asqlht + ") f where f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp + ") froo ";
					}
					else
						if(chkPhongkham.Checked)
					{
                        asql1 = "select '-2' id, sum(to_number(decode(f.id,null,nvl(a.sotien,0),0))) sotien from medibvmmyy.v_mienngtru a, medibvmmyy.v_vienphill d, (" + asqlht + ") f where a.id=d.id and f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp;
					}
					else
					{
                        asql1 = "select '-2' id, sum(to_number(decode(f.id,null,nvl(d.mien,0),0))) sotien from medibvmmyy.v_ttrvll d, (" + asqlht + ") f where f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp;
					}
                ads1 = m_v.get_data_mmyy(asql1, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true); //m_v.get_data_bc(txtTN.Value.AddMonths(-1), txtDN.Value.AddMonths(1),asql1);
					
					for(int i=0;i<ads.Tables[0].Rows.Count;i++)
					{
						try
						{
							foreach(DataRow r in ads1.Tables[0].Select("id='"+ads.Tables[0].Rows[i]["id"].ToString().Trim()+"'"))
							{
								ads.Tables[0].Rows[i]["lock02"]=decimal.Parse(ads.Tables[0].Rows[i]["lock02"].ToString())+decimal.Parse(decimal.Parse(r["sotien"].ToString()).ToString("###,###,##0.###"));
							}
						}
						catch
						{
						}
					}
               //     ads.WriteXml("c:/lock2.xml", XmlWriteMode.WriteSchema);
					//Tru theo khoa phong
					if(rd1.Checked)
					{
						//BHYT
						if(((!chkPhongkham.Checked)&&(!chkNoitru.Checked))||((chkPhongkham.Checked)&&(chkNoitru.Checked)))
						{
                            asql1 = "select to_char(nvl(to_number(d.makp),'-3')) id, sum(to_number(decode(f.id,null,nvl(d.bhyt,0),0))) sotien from medibvmmyy.v_ttrvll d, (" + asqlht + ") f where f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp + " group by to_char(nvl(to_number(d.makp),'-3'))" + " union all " + "select to_char(nvl(to_number(a.makp),'-3')) id, sum(to_number(decode(f.id,null,decode(a.madoituong,1,nvl(a.mien,0),0),0))) sotien from medibvmmyy.v_vienphict a, medibvmmyy.v_vienphill d, (" + asqlht + ") f where d.id=a.id and f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp + " group by to_char(nvl(to_number(a.makp),'-3'))";
						}
						else
							if(chkPhongkham.Checked)
						{
                            asql1 = "select to_char(nvl(to_number(a.makp),'-3')) id, sum(to_number(decode(f.id,null,decode(a.madoituong,1,nvl(a.mien,0),0),0))) sotien from medibvmmyy.v_vienphict a, medibvmmyy.v_vienphill d, (" + asqlht + ") f where d.id=a.id and f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp + " group by to_char(nvl(to_number(a.makp),'-3'))";
						}
						else
						{
                            asql1 = "select to_char(nvl(to_number(d.makp),'-3')) id, sum(to_number(decode(f.id,null,nvl(d.bhyt,0),0))) sotien from medibvmmyy.v_ttrvll d, (" + asqlht + ") f where f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp + " group by to_char(nvl(to_number(d.makp),'-3'))";
						}
                    ads1 = m_v.get_data_mmyy(asql1, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true); //m_v.get_data_bc(txtTN.Value.AddMonths(-1), txtDN.Value.AddMonths(1),asql1);
					
						for(int i=0;i<ads.Tables[0].Rows.Count;i++)
						{
							try
							{
								foreach(DataRow r in ads1.Tables[0].Select("id='"+ads.Tables[0].Rows[i]["id"].ToString().Trim()+"'"))
								{
									ads.Tables[0].Rows[i]["lock02"]=decimal.Parse(ads.Tables[0].Rows[i]["lock02"].ToString())-decimal.Parse(decimal.Parse(r["sotien"].ToString()).ToString("###,###,##0.###"));
								}
							}
							catch
							{
							}
						}
                   //     ads.WriteXml("c:/lock2.xml", XmlWriteMode.WriteSchema);
						//Mien
						if(((!chkPhongkham.Checked)&&(!chkNoitru.Checked))||((chkPhongkham.Checked)&&(chkNoitru.Checked)))
						{
                            asql1 = "select to_char(nvl(to_number(d.makp),'-3')) id, sum(decode(f.id,null,nvl(a.sotien,0),0)) sotien from v_mienngtru a, v_vienphill d, (" + asqlht + ") f where a.id=d.id and d.quyenso=f.quyenso(+) and d.sobienlai=f.sobienlai(+) " + exp + " group by to_char(nvl(to_number(d.makp),'-3'))" + " union all " + "select to_char(nvl(to_number(d.makp),'-3')) id, sum(decode(f.id,null,nvl(d.mien,0),0)) sotien from v_ttrvll d, (" + asqlht + ") f where d.quyenso=f.quyenso(+) and d.sobienlai=f.sobienlai(+) " + exp + " group by to_char(nvl(to_number(d.makp),'-3'))";
						}
						else
							if(chkPhongkham.Checked)
						{
                            asql1 = "select to_char(nvl(to_number(d.makp),'-3')) id, sum(decode(f.id,null,nvl(a.sotien,0),0)) sotien from v_mienngtru a, v_vienphill d, (" + asqlht + ") f where a.id=d.id and d.quyenso=f.quyenso(+) and d.sobienlai=f.sobienlai(+) " + exp + " group by to_char(nvl(to_number(d.makp),'-3'))";
						}
						else
						{
                            asql1 = "select to_char(nvl(to_number(d.makp),'-3')) id, sum(decode(f.id,null,nvl(d.mien,0),0)) sotien from v_ttrvll d, (" + asqlht + ") f where d.quyenso=f.quyenso(+) and d.sobienlai=f.sobienlai(+) " + exp + " group by to_char(nvl(to_number(d.makp),'-3'))";
						}
                    ads1 = m_v.get_data_mmyy(asql1, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true); //m_v.get_data_bc(txtTN.Value.AddMonths(-1), txtDN.Value.AddMonths(1),asql1);
					
						for(int i=0;i<ads.Tables[0].Rows.Count;i++)
						{
							try
							{
								foreach(DataRow r in ads1.Tables[0].Select("id='"+ads.Tables[0].Rows[i]["id"].ToString().Trim()+"'"))
								{
									ads.Tables[0].Rows[i]["lock02"]=decimal.Parse(ads.Tables[0].Rows[i]["lock02"].ToString())-decimal.Parse(decimal.Parse(r["sotien"].ToString()).ToString("###,###,##0.###"));
								}
							}
							catch
							{
							}
						}
                        //ads.WriteXml("c:/lock2.xml", XmlWriteMode.WriteSchema);
					}
					//End Tru theo khoa phong

				}
				catch
				{
                }
#endregion
                #region Lock3
				if(rdThang.Checked)
				{
					ad1=ad1.AddMonths(-1);
					ad2=ad2.AddMonths(-1);

					ayear=ad1.Year;
					amonth=ad1.Month;
					ad1 = new DateTime(ayear,amonth,1);
					ad2 = new DateTime(ayear,amonth,DateTime.DaysInMonth(ayear,amonth));
				}
				else
				{
					ad1=ad1.AddDays(asn);
					ad2=ad2.AddDays(asn);
				}
				if((ad1-ad2).Days==0)
				{
					alock03=f_StringDate(ad1);
				}
				else
				{
					alock03=f_StringDate(ad1)+" - "+f_StringDate(ad2);
				}
				try
				{
					exp=" and to_date(to_char(d.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('"+f_StringDate(ad1)+"','dd/mm/yyyy') and to_date(to_char(d.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')<=to_date('"+f_StringDate(ad2)+"','dd/mm/yyyy')";
					asqlht="select * from v_hoantra where to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('"+f_StringDate(ad1)+"','dd/mm/yyyy') and to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy')<=to_date('"+f_StringDate(ad2)+"','dd/mm/yyyy')";
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
					if(((!chkPhongkham.Checked)&&(!chkNoitru.Checked))||((chkPhongkham.Checked)&&(chkNoitru.Checked)))
					{
						asql1="select id, sum(sotien) sotien from (select to_char("+agroup+") id, sum(nvl(a.soluong,0)*nvl(a.dongia,0)-nvl(a.thieu,0)) sotien from v_vienphict a, (select id, id_loai from v_giavp union all select id, 0 id_loai from d_dmbd) b, (select id from v_loaivp union all select 0 from dual) c, v_vienphill d, medibv.btdkp_bv e where a.id=d.id and a.mavp=b.id(+) and b.id_loai=c.id(+) and a.makp=e.makp(+)  "+exp+" group by "+agroup+" union all select to_char("+agroup+") id, sum(nvl(a.soluong,0)*nvl(a.dongia,0)+nvl(a.soluong,0)*nvl(a.dongia,0)*round(nvl(a.vat,0)/100,3)) sotien from v_ttrvct a, (select id, id_loai from v_giavp union all select 0 id, 0 id_loai from dual) b, (select id from medibv.v_loaivp union all select 0 from dual) c, medibvmmyy.v_ttrvll d, medibv.btdkp_bv e where a.id=d.id and a.mavp=b.id(+) and b.id_loai=c.id(+) and a.makp=e.makp(+) "+exp+" group by "+agroup+") group by id";
					}
					else
						if(chkPhongkham.Checked)
					{
						asql1="select id, sum(sotien) sotien from (select to_char("+agroup+") id, sum(nvl(a.soluong,0)*nvl(a.dongia,0)-nvl(a.thieu,0)) sotien from v_vienphict a, (select id, id_loai from v_giavp union all select id, 0 id_loai from d_dmbd) b, (select id from v_loaivp union all select 0 from dual) c, v_vienphill d, btdkp_bv e where a.id=d.id and a.mavp=b.id(+) and b.id_loai=c.id(+) and a.makp=e.makp(+)  "+exp+" group by "+agroup+") group by id";
					}
					else
					{
						asql1="select to_char("+agroup+") id, sum(nvl(a.soluong,0)*nvl(a.dongia,0)+nvl(a.soluong,0)*nvl(a.dongia,0)*round(nvl(a.vat,0)/100,3)) sotien from v_ttrvct a, (select id, id_loai from v_giavp union all select id, 0 id_loai from d_dmbd) b, (select id from v_loaivp union all select 0 from dual) c, v_ttrvll d, btdkp_bv e where a.id=d.id and a.mavp=b.id(+) and b.id_loai=c.id(+) and a.makp=e.makp(+)  "+exp+" group by "+agroup;
					}
                ads1 = m_v.get_data_mmyy(asql1, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true); //m_v.get_data_bc(txtTN.Value.AddMonths(-1), txtDN.Value.AddMonths(1),asql1);
					for(int i=0;i<ads.Tables[0].Rows.Count;i++)
					{
						try
						{
							foreach(DataRow r in ads1.Tables[0].Select("id='"+ads.Tables[0].Rows[i]["id"].ToString().Trim()+"'"))
							{
								ads.Tables[0].Rows[i]["lock03"]=decimal.Parse(ads.Tables[0].Rows[i]["lock03"].ToString())+decimal.Parse(decimal.Parse(r["sotien"].ToString()).ToString("###,###,##0.###"));
							}
						}
						catch
						{
						}
					}
                    //ads.WriteXml("c:/lock3.xml", XmlWriteMode.WriteSchema);
					//BHYT
					if(((!chkPhongkham.Checked)&&(!chkNoitru.Checked))||((chkPhongkham.Checked)&&(chkNoitru.Checked)))
					{
						asql1="select '-1' id, sum(sotien) sotien from (select '-1' id, sum(decode(f.id,null,decode(a.madoituong,1,a.mien,0),0)) sotien from v_vienphict a, v_vienphill d, ("+asqlht+") f where a.id=d.id and d.quyenso=f.quyenso(+) and d.sobienlai=f.sobienlai(+) "+exp+" union all select '-1' id, sum(decode(f.id,null,nvl(d.bhyt,0),0)) sotien from v_ttrvll d, ("+asqlht+") f where d.quyenso=f.quyenso(+) and d.sobienlai=f.sobienlai(+) "+exp+")";
					}
					else
						if(chkPhongkham.Checked)
					{
						asql1="select '-1' id, sum(decode(f.id,null,decode(a.madoituong,1,a.mien,0),0)) sotien from v_vienphict a, v_vienphill d, ("+asqlht+") f where a.id=d.id and d.quyenso=f.quyenso(+) and d.sobienlai=f.sobienlai(+) "+exp;
					}
					else
					{
						asql1="select '-1' id, sum(decode(f.id,null,nvl(d.bhyt,0),0)) sotien from v_ttrvll d, ("+asqlht+") f where d.quyenso=f.quyenso(+) and d.sobienlai=f.sobienlai(+) "+exp;
					}
                ads1 = m_v.get_data_mmyy(asql1, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true); //m_v.get_data_bc(txtTN.Value.AddMonths(-1), txtDN.Value.AddMonths(1),asql1);
					
					for(int i=0;i<ads.Tables[0].Rows.Count;i++)
					{
						try
						{
							foreach(DataRow r in ads1.Tables[0].Select("id='"+ads.Tables[0].Rows[i]["id"].ToString().Trim()+"'"))
							{
								ads.Tables[0].Rows[i]["lock03"]=decimal.Parse(ads.Tables[0].Rows[i]["lock03"].ToString())+decimal.Parse(decimal.Parse(r["sotien"].ToString()).ToString("###,###,##0.###"));
							}
						}
						catch
						{
						}
					}
                    //ads.WriteXml("c:/lock3.xml", XmlWriteMode.WriteSchema);
					//Mien
					if(((!chkPhongkham.Checked)&&(!chkNoitru.Checked))||((chkPhongkham.Checked)&&(chkNoitru.Checked)))
					{
                        asql1 = "select '-2' id, sum(sotien) sotien from (select sum(to_number(decode(f.id,null,nvl(a.sotien,0),0))) sotien from medibvmmyy.v_mienngtru a, medibvmmyy.v_vienphill d, (" + asqlht + ") f where a.id=d.id and f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp + " union all select sum(to_number(decode(f.id,null,nvl(d.mien,0),0))) sotien from medibvmmyy.v_ttrvll d, (" + asqlht + ") f where f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp + ") froo ";
					}
					else
						if(chkPhongkham.Checked)
					{
                        asql1 = "select '-2' id, sum(to_number(decode(f.id,null,nvl(a.sotien,0),0))) sotien from medibvmmyy.v_mienngtru a, medibvmmyy.v_vienphill d, (" + asqlht + ") f where a.id=d.id and f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp;
					}
					else
					{
                        asql1 = "select '-2' id, sum(to_number(decode(f.id,null,nvl(d.mien,0),0))) sotien from medibvmmyy.v_ttrvll d, (" + asqlht + ") f where f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp;
					}
                ads1 = m_v.get_data_mmyy(asql1, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true); //m_v.get_data_bc(txtTN.Value.AddMonths(-1), txtDN.Value.AddMonths(1),asql1);
					
					for(int i=0;i<ads.Tables[0].Rows.Count;i++)
					{
						try
						{
							foreach(DataRow r in ads1.Tables[0].Select("id='"+ads.Tables[0].Rows[i]["id"].ToString().Trim()+"'"))
							{
								ads.Tables[0].Rows[i]["lock03"]=decimal.Parse(ads.Tables[0].Rows[i]["lock03"].ToString())+decimal.Parse(decimal.Parse(r["sotien"].ToString()).ToString("###,###,##0.###"));
							}
						}
						catch
						{
						}
					}
                    //ads.WriteXml("c:/lock3.xml", XmlWriteMode.WriteSchema);
					//Tru theo khoa phong
					if(rd1.Checked)
					{
						//BHYT
						if(((!chkPhongkham.Checked)&&(!chkNoitru.Checked))||((chkPhongkham.Checked)&&(chkNoitru.Checked)))
						{
                            asql1 = "select to_char(nvl(to_number(d.makp),'-3')) id, sum(to_number(decode(f.id,null,nvl(d.bhyt,0),0))) sotien from medibvmmyy.v_ttrvll d, (" + asqlht + ") f where f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp + " group by to_char(nvl(to_number(d.makp),'-3'))" + " union all " + "select to_char(nvl(to_number(a.makp),'-3')) id, sum(to_number(decode(f.id,null,decode(a.madoituong,1,nvl(a.mien,0),0),0))) sotien from medibvmmyy.v_vienphict a, medibvmmyy.v_vienphill d, (" + asqlht + ") f where d.id=a.id and f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp + " group by to_char(nvl(to_number(a.makp),'-3'))";
						}
						else
							if(chkPhongkham.Checked)
						{
                            asql1 = "select to_char(nvl(to_number(a.makp),'-3')) id, sum(to_number(decode(f.id,null,decode(a.madoituong,1,nvl(a.mien,0),0),0))) sotien from medibvmmyy.v_vienphict a, medibvmmyy.v_vienphill d, (" + asqlht + ") f where d.id=a.id and f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp + " group by to_char(nvl(to_number(a.makp),'-3'))";
						}
						else
						{
                            asql1 = "select to_char(nvl(to_number(d.makp),'-3')) id, sum(to_number(decode(f.id,null,nvl(d.bhyt,0),0))) sotien from medibvmmyy.v_ttrvll d, (" + asqlht + ") f where f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp + " group by to_char(nvl(to_number(d.makp),'-3')))";
						}
                    ads1 = m_v.get_data_mmyy(asql1, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true); //m_v.get_data_bc(txtTN.Value.AddMonths(-1), txtDN.Value.AddMonths(1),asql1);
					
						for(int i=0;i<ads.Tables[0].Rows.Count;i++)
						{
							try
							{
								foreach(DataRow r in ads1.Tables[0].Select("id='"+ads.Tables[0].Rows[i]["id"].ToString().Trim()+"'"))
								{
									ads.Tables[0].Rows[i]["lock03"]=decimal.Parse(ads.Tables[0].Rows[i]["lock03"].ToString())-decimal.Parse(decimal.Parse(r["sotien"].ToString()).ToString("###,###,##0.###"));
								}
							}
							catch
							{
							}
						}
                        //ads.WriteXml("c:/lock3.xml", XmlWriteMode.WriteSchema);
						//Mien
						if(((!chkPhongkham.Checked)&&(!chkNoitru.Checked))||((chkPhongkham.Checked)&&(chkNoitru.Checked)))
						{
                            asql1 = "select to_char(nvl(to_number(d.makp),'-3')) id, sum(to_number(decode(f.id,null,nvl(a.sotien,0),0))) sotien from medibvmmyy.v_mienngtru a, medibvmmyy.v_vienphill d, (" + asqlht + ") f where a.id=d.id and f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp + " group by to_char(nvl(to_number(d.makp),'-3'))" + " union all " + "select to_char(nvl(to_number(d.makp),'-3')) id, sum(to_number(decode(f.id,null,nvl(d.mien,0),0))) sotien from medibvmmyy.v_ttrvll d, (" + asqlht + ") f where f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp + " group by to_char(nvl(to_number(d.makp),'-3'))";
						}
						else
							if(chkPhongkham.Checked)
						{
                            asql1 = "select to_char(nvl(to_number(d.makp),'-3')) id, sum(to_number(decode(f.id,null,nvl(a.sotien,0),0))) sotien from medibvmmyy.v_mienngtru a, medibvmmyy.v_vienphill d, (" + asqlht + ") f where a.id=d.id and f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp + " group by to_char(nvl(to_number(d.makp),'-3'))";
						}
						else
						{
                            asql1 = "select to_char(nvl(to_number(d.makp),'-3')) id, sum(to_number(decode(f.id,null,nvl(d.mien,0),0))) sotien from medibvmmyy.v_ttrvll d, (" + asqlht + ") f where f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp + " group by to_char(nvl(to_number(d.makp),'-3'))";
						}
                    ads1 = m_v.get_data_mmyy(asql1, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true); //m_v.get_data_bc(txtTN.Value.AddMonths(-1), txtDN.Value.AddMonths(1),asql1);
					
						for(int i=0;i<ads.Tables[0].Rows.Count;i++)
						{
							try
							{
								foreach(DataRow r in ads1.Tables[0].Select("id='"+ads.Tables[0].Rows[i]["id"].ToString().Trim()+"'"))
								{
									ads.Tables[0].Rows[i]["lock03"]=decimal.Parse(ads.Tables[0].Rows[i]["lock03"].ToString())-decimal.Parse(decimal.Parse(r["sotien"].ToString()).ToString("###,###,##0.###"));
								}
							}
							catch
							{
							}
						}
                        //ads.WriteXml("c:/lock3.xml", XmlWriteMode.WriteSchema);
					}
					//End Tru theo khoa phong

				}
				catch
				{
                }
#endregion
                #region Lock4
				if(rdThang.Checked)
				{
					ad1=ad1.AddMonths(-1);
					ad2=ad2.AddMonths(-1);

					ayear=ad1.Year;
					amonth=ad1.Month;
					ad1 = new DateTime(ayear,amonth,1);
					ad2 = new DateTime(ayear,amonth,DateTime.DaysInMonth(ayear,amonth));
				}
				else
				{
					ad1=ad1.AddDays(asn);
					ad2=ad2.AddDays(asn);
				}
				if((ad1-ad2).Days==0)
				{
					alock04=f_StringDate(ad1);
				}
				else
				{
					alock04=f_StringDate(ad1)+" - "+f_StringDate(ad2);
				}
				try
				{
					exp=" and to_date(to_char(d.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('"+f_StringDate(ad1)+"','dd/mm/yyyy') and to_date(to_char(d.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')<=to_date('"+f_StringDate(ad2)+"','dd/mm/yyyy')";
					asqlht="select * from medibvmmyy.v_hoantra where to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('"+f_StringDate(ad1)+"','dd/mm/yyyy') and to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy')<=to_date('"+f_StringDate(ad2)+"','dd/mm/yyyy')";
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
					if(((!chkPhongkham.Checked)&&(!chkNoitru.Checked))||((chkPhongkham.Checked)&&(chkNoitru.Checked)))
					{
                        asql1 = "select id, sum(sotien) sotien from (select to_char(" + agroup + ") id, sum(nvl(a.soluong,0)*nvl(a.dongia,0)-nvl(a.thieu,0)) sotien from medibvmmyy.v_vienphict a, (select id, id_loai from medibv.v_giavp union all select id, 0 id_loai from medibv.d_dmbd) b, (select id from medibv.v_loaivp union all select 0 from dual) c, medibvmmyy.v_vienphill d, medibv.btdkp_bv e where a.id=d.id and b.id(+)=a.mavp and c.id(+)=b.id_loai and e.makp(+)=a.makp " + exp + " group by " + agroup + " union all select to_char(" + agroup + ") id, sum(nvl(a.soluong,0)*nvl(a.dongia,0)+nvl(a.soluong,0)*nvl(a.dongia,0)*round(nvl(a.vat,0)/100,3)) sotien from medibvmmyy.v_ttrvct a, (select id, id_loai from medibv.v_giavp union all select 0 id, 0 id_loai from dual) b, (select id from medibv.v_loaivp union all select 0 from dual) c, medibvmmyy.v_ttrvll d, medibv.btdkp_bv e where a.id=d.id and b.id(+)=a.mavp and c.id(+)=b.id_loai and e.makp(+)=a.makp " + exp + " group by " + agroup + ") froo group by id";
					}
					else
						if(chkPhongkham.Checked)
					{
                        asql1 = "select id, sum(sotien) sotien from (select to_char(" + agroup + ") id, sum(nvl(a.soluong,0)*nvl(a.dongia,0)-nvl(a.thieu,0)) sotien from medibvmmyy.v_vienphict a, (select id, id_loai from medibv.v_giavp union all select id, 0 id_loai from medibv.d_dmbd) b, (select id from medibv.v_loaivp union all select 0 from dual) c, medibvmmyy.v_vienphill d, medibv.btdkp_bv e where a.id=d.id and b.id(+)=a.mavp and c.id(+)=b.id_loai and e.makp(+)=a.makp " + exp + " group by " + agroup + ") froo group by id";
					}
					else
					{
                        asql1 = "select to_char(" + agroup + ") id, sum(nvl(a.soluong,0)*nvl(a.dongia,0)+nvl(a.soluong,0)*nvl(a.dongia,0)*round(nvl(a.vat,0)/100,3)) sotien from medibvmmyy.v_ttrvct a, (select id, id_loai from medibv.v_giavp union all select id, 0 id_loai from medibv.d_dmbd) b, (select id from medibv.v_loaivp union all select 0 from dual) c, medibvmmyy.v_ttrvll d, medibv.btdkp_bv e where a.id=d.id and b.id(+)=a.mavp and c.id(+)=b.id_loai and e.makp(+)=a.makp " + exp + " group by " + agroup;
					}
                ads1 = m_v.get_data_mmyy(asql1, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true); //m_v.get_data_bc(txtTN.Value.AddMonths(-1), txtDN.Value.AddMonths(1),asql1);
					for(int i=0;i<ads.Tables[0].Rows.Count;i++)
					{
						try
						{
							foreach(DataRow r in ads1.Tables[0].Select("id='"+ads.Tables[0].Rows[i]["id"].ToString().Trim()+"'"))
							{
								ads.Tables[0].Rows[i]["lock04"]=decimal.Parse(ads.Tables[0].Rows[i]["lock04"].ToString())+decimal.Parse(decimal.Parse(r["sotien"].ToString()).ToString("###,###,##0.###"));
							}
						}
						catch
						{
						}
					}
                    //ads.WriteXml("c:/lock4.xml", XmlWriteMode.WriteSchema);
					//BHYT
					if(((!chkPhongkham.Checked)&&(!chkNoitru.Checked))||((chkPhongkham.Checked)&&(chkNoitru.Checked)))
					{
                        asql1 = "select '-1' id, sum(sotien) sotien from (select '-1' id, sum(to_number(decode(f.id,null,decode(a.madoituong,1,a.mien,0),0))) sotien from medibvmmyy.v_vienphict a, medibvmmyy.v_vienphill d, (" + asqlht + ") f where a.id=d.id and f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp + " union all select '-1' id, sum(to_number(decode(f.id,null,nvl(d.bhyt,0),0))) sotien from medibvmmyy.v_ttrvll d, (" + asqlht + ") f where f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp + ")";
					}
					else
						if(chkPhongkham.Checked)
					{
                        asql1 = "select '-1' id, sum(to_number(decode(f.id,null,decode(a.madoituong,1,a.mien,0),0))) sotien from medibvmmyy.v_vienphict a, medibvmmyy.v_vienphill d, (" + asqlht + ") f where a.id=d.id and f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp;
					}
					else
					{
                        asql1 = "select '-1' id, sum(to_number(decode(f.id,null,nvl(d.bhyt,0),0))) sotien from medibvmmyy.v_ttrvll d, (" + asqlht + ") f where f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp;
					}
                ads1 = m_v.get_data_mmyy(asql1, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true); //m_v.get_data_bc(txtTN.Value.AddMonths(-1), txtDN.Value.AddMonths(1),asql1);
					
					for(int i=0;i<ads.Tables[0].Rows.Count;i++)
					{
						try
						{
							foreach(DataRow r in ads1.Tables[0].Select("id='"+ads.Tables[0].Rows[i]["id"].ToString().Trim()+"'"))
							{
								ads.Tables[0].Rows[i]["lock04"]=decimal.Parse(ads.Tables[0].Rows[i]["lock04"].ToString())+decimal.Parse(decimal.Parse(r["sotien"].ToString()).ToString("###,###,##0.###"));
							}
						}
						catch
						{
						}
					}
                    //ads.WriteXml("c:/lock4.xml", XmlWriteMode.WriteSchema);
					//Mien
					if(((!chkPhongkham.Checked)&&(!chkNoitru.Checked))||((chkPhongkham.Checked)&&(chkNoitru.Checked)))
					{
                        asql1 = "select '-2' id, sum(sotien) sotien from (select sum(to_number(decode(f.id,null,nvl(a.sotien,0),0))) sotien from medibvmmyy.v_mienngtru a, medibvmmyy.v_vienphill d, (" + asqlht + ") f where a.id=d.id and f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp + " union all select sum(to_number(decode(f.id,null,nvl(d.mien,0),0))) sotien from medibvmmyy.v_ttrvll d, (" + asqlht + ") f where f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp + ") froo ";
					}
					else
						if(chkPhongkham.Checked)
					{
                        asql1 = "select '-2' id, sum(to_number(decode(f.id,null,nvl(a.sotien,0),0))) sotien from medibvmmyy.v_mienngtru a, medibvmmyy.v_vienphill d, (" + asqlht + ") f where a.id=d.id and f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp;
					}
					else
					{
                        asql1 = "select '-2' id, sum(to_number(decode(f.id,null,nvl(d.mien,0),0))) sotien from medibvmmyy.v_ttrvll d, (" + asqlht + ") f where f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp;
					}
                ads1 = m_v.get_data_mmyy(asql1, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true); //m_v.get_data_bc(txtTN.Value.AddMonths(-1), txtDN.Value.AddMonths(1),asql1);
					
					for(int i=0;i<ads.Tables[0].Rows.Count;i++)
					{
						try
						{
							foreach(DataRow r in ads1.Tables[0].Select("id='"+ads.Tables[0].Rows[i]["id"].ToString().Trim()+"'"))
							{
								ads.Tables[0].Rows[i]["lock04"]=decimal.Parse(ads.Tables[0].Rows[i]["lock04"].ToString())+decimal.Parse(decimal.Parse(r["sotien"].ToString()).ToString("###,###,##0.###"));
							}
						}
						catch
						{
						}
					}
                    //ads.WriteXml("c:/lock4.xml", XmlWriteMode.WriteSchema);
					//Tru theo khoa phong
					if(rd1.Checked)
					{
						//BHYT
						if(((!chkPhongkham.Checked)&&(!chkNoitru.Checked))||((chkPhongkham.Checked)&&(chkNoitru.Checked)))
						{
                            asql1 = "select to_char(nvl(to_number(d.makp),'-3')) id, sum(to_number(decode(f.id,null,nvl(d.bhyt,0),0))) sotien from medibvmmyy.v_ttrvll d, (" + asqlht + ") f where f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp + " group by to_char(nvl(to_number(d.makp),'-3'))" + " union all " + "select to_char(nvl(to_number(a.makp),'-3')) id, sum(to_number(decode(f.id,null,decode(a.madoituong,1,nvl(a.mien,0),0),0))) sotien from medibvmmyy.v_vienphict a, medibvmmyy.v_vienphill d, (" + asqlht + ") f where d.id=a.id and f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp + " group by to_char(nvl(to_number(a.makp),'-3'))";
						}
						else
							if(chkPhongkham.Checked)
						{
                            asql1 = "select to_char(nvl(to_number(a.makp),'-3')) id, sum(to_number(decode(f.id,null,decode(a.madoituong,1,nvl(a.mien,0),0),0))) sotien from medibvmmyy.v_vienphict a, medibvmmyy.v_vienphill d, (" + asqlht + ") f where d.id=a.id and f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp + " group by to_char(nvl(to_number(a.makp),'-3'))";
						}
						else
						{
                            asql1 = "select to_char(nvl(to_number(d.makp),'-3')) id, sum(to_number(decode(f.id,null,nvl(d.bhyt,0),0))) sotien from medibvmmyy.v_ttrvll d, (" + asqlht + ") f where f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp + " group by to_char(nvl(to_number(d.makp),'-3'))";
						}
                    ads1 = m_v.get_data_mmyy(asql1, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true); //m_v.get_data_bc(txtTN.Value.AddMonths(-1), txtDN.Value.AddMonths(1),asql1);
					
						for(int i=0;i<ads.Tables[0].Rows.Count;i++)
						{
							try
							{
								foreach(DataRow r in ads1.Tables[0].Select("id='"+ads.Tables[0].Rows[i]["id"].ToString().Trim()+"'"))
								{
									ads.Tables[0].Rows[i]["lock04"]=decimal.Parse(ads.Tables[0].Rows[i]["lock04"].ToString())-decimal.Parse(decimal.Parse(r["sotien"].ToString()).ToString("###,###,##0.###"));
								}
							}
							catch
							{
							}
						}
                        //ads.WriteXml("c:/lock4.xml", XmlWriteMode.WriteSchema);
						//Mien
						if(((!chkPhongkham.Checked)&&(!chkNoitru.Checked))||((chkPhongkham.Checked)&&(chkNoitru.Checked)))
						{
                            asql1 = "select to_char(nvl(to_number(d.makp),'-3')) id, sum(to_number(decode(f.id,null,nvl(a.sotien,0),0))) sotien from medibvmmyy.v_mienngtru a, medibvmmyy.v_vienphill d, (" + asqlht + ") f where a.id=d.id and f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp + " group by to_char(nvl(to_number(d.makp),'-3'))" + " union all " + "select to_char(nvl(to_number(d.makp),'-3')) id, sum(to_number(decode(f.id,null,nvl(d.mien,0),0))) sotien from medibvmmyy.v_ttrvll d, (" + asqlht + ") f where f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp + " group by to_char(nvl(to_number(d.makp),'-3'))";
						}
						else
							if(chkPhongkham.Checked)
						{
                            asql1 = "select to_char(nvl(to_number(d.makp),'-3')) id, sum(to_number(decode(f.id,null,nvl(a.sotien,0),0))) sotien from medibvmmyy.v_mienngtru a, medibvmmyy.v_vienphill d, (" + asqlht + ") f where a.id=d.id and f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp + " group by to_char(nvl(to_number(d.makp),'-3'))";
						}
						else
						{
                            asql1 = "select to_char(nvl(to_number(d.makp),'-3')) id, sum(to_number(decode(f.id,null,nvl(d.mien,0),0))) sotien from medibvmmyy.v_ttrvll d, (" + asqlht + ") f where f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp + " group by to_char(nvl(to_number(d.makp),'-3'))";
						}
                    ads1 = m_v.get_data_mmyy(asql1, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true); //m_v.get_data_bc(txtTN.Value.AddMonths(-1), txtDN.Value.AddMonths(1),asql1);
					
						for(int i=0;i<ads.Tables[0].Rows.Count;i++)
						{
							try
							{
								foreach(DataRow r in ads1.Tables[0].Select("id='"+ads.Tables[0].Rows[i]["id"].ToString().Trim()+"'"))
								{
									ads.Tables[0].Rows[i]["lock04"]=decimal.Parse(ads.Tables[0].Rows[i]["lock04"].ToString())-decimal.Parse(decimal.Parse(r["sotien"].ToString()).ToString("###,###,##0.###"));
								}
							}
							catch
							{
							}
						}
                        //ads.WriteXml("c:/lock4.xml", XmlWriteMode.WriteSchema);
					}
					//End Tru theo khoa phong
				}
				catch
				{
                }
#endregion
                #region Lock5
                if (rdThang.Checked)
				{
					ad1=ad1.AddMonths(-1);
					ad2=ad2.AddMonths(-1);

					ayear=ad1.Year;
					amonth=ad1.Month;
					ad1 = new DateTime(ayear,amonth,1);
					ad2 = new DateTime(ayear,amonth,DateTime.DaysInMonth(ayear,amonth));
				}
				else
				{
					ad1=ad1.AddDays(asn);
					ad2=ad2.AddDays(asn);
				}
				if((ad1-ad2).Days==0)
				{
					alock05=f_StringDate(ad1);
				}
				else
				{
					alock05=f_StringDate(ad1)+" - "+f_StringDate(ad2);
				}
				try
				{
					exp=" and to_date(to_char(d.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('"+f_StringDate(ad1)+"','dd/mm/yyyy') and to_date(to_char(d.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')<=to_date('"+f_StringDate(ad2)+"','dd/mm/yyyy')";
					asqlht="select * from medibvmmyy.v_hoantra where to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('"+f_StringDate(ad1)+"','dd/mm/yyyy') and to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy')<=to_date('"+f_StringDate(ad2)+"','dd/mm/yyyy')";
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
					if(((!chkPhongkham.Checked)&&(!chkNoitru.Checked))||((chkPhongkham.Checked)&&(chkNoitru.Checked)))
					{
                        asql1 = "select id, sum(sotien) sotien from (select to_char(" + agroup + ") id, sum(nvl(a.soluong,0)*nvl(a.dongia,0)-nvl(a.thieu,0)) sotien from medibvmmyy.v_vienphict a, (select id, id_loai from medibv.v_giavp union all select id, 0 id_loai from medibv.d_dmbd) b, (select id from medibv.v_loaivp union all select 0 from dual) c, medibvmmyy.v_vienphill d, medibv.btdkp_bv e where a.id=d.id and b.id(+)=a.mavp and c.id(+)=b.id_loai and e.makp(+)=a.makp  " + exp + " group by " + agroup + " union all select to_char(" + agroup + ") id, sum(nvl(a.soluong,0)*nvl(a.dongia,0)+nvl(a.soluong,0)*nvl(a.dongia,0)*round(nvl(a.vat,0)/100,3)) sotien from medibvmmyy.v_ttrvct a, (select id, id_loai from medibv.v_giavp union all select 0 id, 0 id_loai from dual) b, (select id from medibv.v_loaivp union all select 0 from dual) c, medibvmmyy.v_ttrvll d, medibv.btdkp_bv e where a.id=d.id and b.id(+)=a.mavp and c.id(+)=b.id_loai and e.makp(+)=a.makp  " + exp + " group by " + agroup + ") froo group by id";
					}
					else
						if(chkPhongkham.Checked)
					{
                        asql1 = "select id, sum(sotien) sotien from (select to_char(" + agroup + ") id, sum( nvl(a.soluong,0)*nvl(a.dongia,0)-nvl(a.thieu,0)) sotien from medibvmmyy.v_vienphict a, (select id, id_loai from medibv.v_giavp union all select id, 0 id_loai from medibv.d_dmbd) b, (select id from medibv.v_loaivp union all select 0 from dual) c, medibvmmyy.v_vienphill d, medibv.btdkp_bv e where a.id=d.id and b.id(+)=a.mavp and c.id(+)=b.id_loai and e.makp(+)=a.makp  " + exp + " group by " + agroup + ") froo group by id";
					}
					else
					{
                        asql1 = "select to_char(" + agroup + ") id, sum(nvl(a.soluong,0)*nvl(a.dongia,0)+nvl(a.soluong,0)*nvl(a.dongia,0)*round(nvl(a.vat,0)/100,3)) sotien from medibvmmyy.v_ttrvct a, (select id, id_loai from medibv.v_giavp union all select id, 0 id_loai from medibv.d_dmbd) b, (select id from medibv.v_loaivp union all select 0 from dual) c, medibvmmyy.v_ttrvll d, medibv.btdkp_bv e where a.id=d.id and b.id(+)=a.mavp and c.id(+)=b.id_loai and e.makp(+)=a.makp  " + exp + " group by " + agroup;
					}
                ads1 = m_v.get_data_mmyy(asql1, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true); //m_v.get_data_bc(txtTN.Value.AddMonths(-1), txtDN.Value.AddMonths(1),asql1);
					for(int i=0;i<ads.Tables[0].Rows.Count;i++)
					{
						try
						{
							foreach(DataRow r in ads1.Tables[0].Select("id='"+ads.Tables[0].Rows[i]["id"].ToString().Trim()+"'"))
							{
								ads.Tables[0].Rows[i]["lock05"]=decimal.Parse(ads.Tables[0].Rows[i]["lock05"].ToString())+decimal.Parse(decimal.Parse(r["sotien"].ToString()).ToString("###,###,##0.###"));
							}
						}
						catch
						{
						}
					}
                    //ads.WriteXml("c:/lock5.xml", XmlWriteMode.WriteSchema);
					//BHYT
					if(((!chkPhongkham.Checked)&&(!chkNoitru.Checked))||((chkPhongkham.Checked)&&(chkNoitru.Checked)))
					{
                        asql1 = "select '-1' id, sum(sotien) sotien from (select '-1' id, sum(to_number(decode(f.id,null,decode(a.madoituong,1,a.mien,0),0))) sotien from medibvmmyy.v_vienphict a, medibvmmyy.v_vienphill d, (" + asqlht + ") f where a.id=d.id and f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp + " union all select '-1' id, sum(to_number(decode(f.id,null,nvl(d.bhyt,0),0))) sotien from medibvmmyy.v_ttrvll d, (" + asqlht + ") f where f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp + ") froo ";
					}
					else
						if(chkPhongkham.Checked)
					{
                        asql1 = "select '-1' id, sum(to_number(decode(f.id,null,decode(a.madoituong,1,a.mien,0),0))) sotien from medibvmmyy.v_vienphict a, medibvmmyy.v_vienphill d, (" + asqlht + ") f where a.id=d.id and f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp;
					}
					else
					{
                        asql1 = "select '-1' id, sum(to_number(decode(f.id,null,nvl(d.bhyt,0),0))) sotien from medibvmmyy.v_ttrvll d, (" + asqlht + ") f where f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp;
					}
                ads1 = m_v.get_data_mmyy(asql1, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true); //m_v.get_data_bc(txtTN.Value.AddMonths(-1), txtDN.Value.AddMonths(1),asql1);
					
					for(int i=0;i<ads.Tables[0].Rows.Count;i++)
					{
						try
						{
							foreach(DataRow r in ads1.Tables[0].Select("id='"+ads.Tables[0].Rows[i]["id"].ToString().Trim()+"'"))
							{
								ads.Tables[0].Rows[i]["lock05"]=decimal.Parse(ads.Tables[0].Rows[i]["lock05"].ToString())+decimal.Parse(decimal.Parse(r["sotien"].ToString()).ToString("###,###,##0.###"));
							}
						}
						catch
						{
						}
					}
                    //ads.WriteXml("c:/lock5.xml", XmlWriteMode.WriteSchema);
					//Mien
					if(((!chkPhongkham.Checked)&&(!chkNoitru.Checked))||((chkPhongkham.Checked)&&(chkNoitru.Checked)))
					{
                        asql1 = "select '-2' id, sum(sotien) sotien from (select sum(to_number(decode(f.id,null,nvl(a.sotien,0),0))) sotien from medibvmmyy.v_mienngtru a, medibvmmyy.v_vienphill d, (" + asqlht + ") f where a.id=d.id and f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp + " union all select sum(to_number(decode(f.id,null,nvl(d.mien,0),0))) sotien from medibvmmyy.v_ttrvll d, (" + asqlht + ") f where f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp + ") froo";
					}
					else
						if(chkPhongkham.Checked)
					{
                        asql1 = "select '-2' id, sum(to_number(decode(f.id,null,nvl(a.sotien,0),0))) sotien from medibvmmyy.v_mienngtru a, medibvmmyy.v_vienphill d, (" + asqlht + ") f where a.id=d.id and f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp;
					}
					else
					{
                        asql1 = "select '-2' id, sum(to_number(decode(f.id,null,nvl(d.mien,0),0))) sotien from medibvmmyy.v_ttrvll d, (" + asqlht + ") f where f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp;
					}
                ads1 = m_v.get_data_mmyy(asql1, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true); //m_v.get_data_bc(txtTN.Value.AddMonths(-1), txtDN.Value.AddMonths(1),asql1);
					
					for(int i=0;i<ads.Tables[0].Rows.Count;i++)
					{
						try
						{
							foreach(DataRow r in ads1.Tables[0].Select("id='"+ads.Tables[0].Rows[i]["id"].ToString().Trim()+"'"))
							{
								ads.Tables[0].Rows[i]["lock05"]=decimal.Parse(ads.Tables[0].Rows[i]["lock05"].ToString())+decimal.Parse(decimal.Parse(r["sotien"].ToString()).ToString("###,###,##0.###"));
							}
						}
						catch
						{
						}
					}
                    //ads.WriteXml("c:/lock5.xml", XmlWriteMode.WriteSchema);
					//Tru theo khoa phong
					if(rd1.Checked)
					{
						//BHYT
						if(((!chkPhongkham.Checked)&&(!chkNoitru.Checked))||((chkPhongkham.Checked)&&(chkNoitru.Checked)))
						{
                            asql1 = "select to_char(nvl(to_number(d.makp),'-3')) id, sum(to_number(decode(f.id,null,nvl(d.bhyt,0),0))) sotien from medibvmmyy.v_ttrvll d, (" + asqlht + ") f where f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp + " group by to_char(nvl(to_number(d.makp),'-3'))" + " union all " + "select to_char(nvl(to_number(a.makp),'-3')) id, sum(to_number(decode(f.id,null,decode(a.madoituong,1,nvl(a.mien,0),0),0))) sotien from medibvmmyy.v_vienphict a, medibvmmyy.v_vienphill d, (" + asqlht + ") f where d.id=a.id and f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp + " group by to_char(nvl(to_number(a.makp),'-3'))";
						}
						else
							if(chkPhongkham.Checked)
						{
                            asql1 = "select to_char(nvl(to_number(a.makp),'-3')) id, sum(to_number(decode(f.id,null,decode(a.madoituong,1,nvl(a.mien,0),0),0))) sotien from medibvmmyy.v_vienphict a, medibvmmyy.v_vienphill d, (" + asqlht + ") f where d.id=a.id and f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp + " group by to_char(nvl(to_number(a.makp),'-3'))";
						}
						else
						{
                            asql1 = "select to_char(nvl(to_number(d.makp),'-3')) id, sum(to_number(decode(f.id,null,nvl(d.bhyt,0),0))) sotien from medibvmmyy.v_ttrvll d, (" + asqlht + ") f where f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp + " group by to_char(nvl(to_number(d.makp),'-3'))";
						}
                    ads1 = m_v.get_data_mmyy(asql1, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true); //m_v.get_data_bc(txtTN.Value.AddMonths(-1), txtDN.Value.AddMonths(1),asql1);
					
						for(int i=0;i<ads.Tables[0].Rows.Count;i++)
						{
							try
							{
								foreach(DataRow r in ads1.Tables[0].Select("id='"+ads.Tables[0].Rows[i]["id"].ToString().Trim()+"'"))
								{
									ads.Tables[0].Rows[i]["lock05"]=decimal.Parse(ads.Tables[0].Rows[i]["lock05"].ToString())-decimal.Parse(decimal.Parse(r["sotien"].ToString()).ToString("###,###,##0.###"));
								}
							}
							catch
							{
							}
						}
                        //ads.WriteXml("c:/lock5.xml", XmlWriteMode.WriteSchema);
						//Mien
						if(((!chkPhongkham.Checked)&&(!chkNoitru.Checked))||((chkPhongkham.Checked)&&(chkNoitru.Checked)))
						{
                            asql1 = "select to_char(nvl(to_number(d.makp),'-3')) id, sum(to_number(decode(f.id,null,nvl(a.sotien,0),0))) sotien from medibvmmyy.v_mienngtru a, medibvmmyy.v_vienphill d, (" + asqlht + ") f where a.id=d.id and f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp + " group by to_char(nvl(to_number(d.makp),'-3'))" + " union all " + "select to_char(nvl(to_number(d.makp),'-3')) id, sum(to_number(decode(f.id,null,nvl(d.mien,0),0))) sotien from medibvmmyy.v_ttrvll d, (" + asqlht + ") f where f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp + " group by to_char(nvl(to_number(d.makp),'-3'))";
						}
						else
							if(chkPhongkham.Checked)
						{
                            asql1 = "select to_char(nvl(to_number(d.makp),'-3')) id, sum(to_number(decode(f.id,null,nvl(a.sotien,0),0))) sotien from medibvmmyy.v_mienngtru a, medibvmmyy.v_vienphill d, (" + asqlht + ") f where a.id=d.id and f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp + " group by to_char(nvl(to_number(d.makp),'-3'))";
						}
						else
						{
                            asql1 = "select to_char(nvl(to_number(d.makp),'-3')) id, sum(to_number(decode(f.id,null,nvl(d.mien,0),0))) sotien from medibvmmyy.v_ttrvll d, (" + asqlht + ") f where f.quyenso(+)=d.quyenso and f.sobienlai(+)=d.sobienlai " + exp + " group by to_char(nvl(to_number(d.makp),'-3'))";
						}
                    ads1 = m_v.get_data_mmyy(asql1, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true); //m_v.get_data_bc(txtTN.Value.AddMonths(-1), txtDN.Value.AddMonths(1),asql1);
					
						for(int i=0;i<ads.Tables[0].Rows.Count;i++)
						{
							try
							{
								foreach(DataRow r in ads1.Tables[0].Select("id='"+ads.Tables[0].Rows[i]["id"].ToString().Trim()+"'"))
								{
									ads.Tables[0].Rows[i]["lock05"]=decimal.Parse(ads.Tables[0].Rows[i]["lock05"].ToString())-decimal.Parse(decimal.Parse(r["sotien"].ToString()).ToString("###,###,##0.###"));
								}
							}
							catch
							{
							}
						}
                        //ads.WriteXml("c:/lock5.xml", XmlWriteMode.WriteSchema);
					}
					//End Tru theo khoa phong
				}
				catch
				{
                }
                #endregion
                #region Lock6
				if(rdThang.Checked)
				{
					ad1=ad1.AddMonths(-1);
					ad2=ad2.AddMonths(-1);

					ayear=ad1.Year;
					amonth=ad1.Month;
					ad1 = new DateTime(ayear,amonth,1);
					ad2 = new DateTime(ayear,amonth,DateTime.DaysInMonth(ayear,amonth));
				}
				else
				{
					ad1=ad1.AddDays(asn);
					ad2=ad2.AddDays(asn);
				}
				if((ad1-ad2).Days==0)
				{
					alock06=f_StringDate(ad1);
				}
				else
				{
					alock06=f_StringDate(ad1)+" - "+f_StringDate(ad2);
				}
				try
				{
					exp=" and to_date(to_char(d.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('"+f_StringDate(ad1)+"','dd/mm/yyyy') and to_date(to_char(d.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')<=to_date('"+f_StringDate(ad2)+"','dd/mm/yyyy')";
					asqlht="select * from medibvmmyy.v_hoantra where to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('"+f_StringDate(ad1)+"','dd/mm/yyyy') and to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy')<=to_date('"+f_StringDate(ad2)+"','dd/mm/yyyy')";
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
					if(((!chkPhongkham.Checked)&&(!chkNoitru.Checked))||((chkPhongkham.Checked)&&(chkNoitru.Checked)))
					{
                        asql1 = "select id, sum(sotien) sotien from (select to_char(" + agroup + ") id, sum(nvl(a.soluong,0)*nvl(a.dongia,0)-nvl(a.thieu,0)) sotien from medibvmmyy.v_vienphict a, (select id, id_loai from medibv.v_giavp union all select id, 0 id_loai from medibv.d_dmbd) b, (select id from medibv.v_loaivp union all select 0 from dual) c, medibvmmyy.v_vienphill d, medibv.btdkp_bv e where a.id=d.id and a.mavp=b.id(+) and b.id_loai=c.id(+) and a.makp=e.makp(+)  " + exp + " group by " + agroup + " union all select to_char(" + agroup + ") id, sum(nvl(a.soluong,0)*nvl(a.dongia,0)+nvl(a.soluong,0)*nvl(a.dongia,0)*round(nvl(a.vat,0)/100,3)) sotien from medibvmmyy.v_ttrvct a, (select id, id_loai from medibv.v_giavp union all select 0 id, 0 id_loai from dual) b, (select id from medibvmmyy.v_loaivp union all select 0 from dual) c, medibvmmyy.v_ttrvll d, btdkp_bv e where a.id=d.id and a.mavp=b.id(+) and b.id_loai=c.id(+) and a.makp=e.makp(+) " + exp + " group by " + agroup + ") froo group by id";
					}
					else
						if(chkPhongkham.Checked)
					{
                        asql1 = "select id, sum(sotien) sotien from (select to_char(" + agroup + ") id, sum( nvl(a.soluong,0)*nvl(a.dongia,0)-nvl(a.thieu,0)) sotien from medibvmmyy.v_vienphict a, (select id, id_loai from medibv.v_giavp union all select id, 0 id_loai from medibv.d_dmbd) b, (select id from medibv.v_loaivp union all select 0 from dual) c, medibvmmyy.v_vienphill d, medibv.btdkp_bv e where a.id=d.id and a.mavp=b.id(+) and b.id_loai=c.id(+) and a.makp=e.makp(+)  " + exp + " group by " + agroup + ") group by id";
					}
					else
					{
                        asql1 = "select to_char(" + agroup + ") id, sum(nvl(a.soluong,0)*nvl(a.dongia,0)+nvl(a.soluong,0)*nvl(a.dongia,0)*round(nvl(a.vat,0)/100,3)) sotien from medibvmmyy.v_ttrvct a, (select id, id_loai from medibv.v_giavp union all select id, 0 id_loai from medibv.d_dmbd) b, (select id from medibv.v_loaivp union all select 0 from dual) c, v_ttrvll d, medibv.btdkp_bv e where a.id=d.id and a.mavp=b.id(+) and b.id_loai=c.id(+) and a.makp=e.makp(+)  " + exp + " group by " + agroup;
					}
                ads1 = m_v.get_data_mmyy(asql1, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true); //m_v.get_data_bc(txtTN.Value.AddMonths(-1), txtDN.Value.AddMonths(1),asql1);
					for(int i=0;i<ads.Tables[0].Rows.Count;i++)
					{
						try
						{
							foreach(DataRow r in ads1.Tables[0].Select("id='"+ads.Tables[0].Rows[i]["id"].ToString().Trim()+"'"))
							{
								ads.Tables[0].Rows[i]["lock06"]=decimal.Parse(ads.Tables[0].Rows[i]["lock06"].ToString())+decimal.Parse(decimal.Parse(r["sotien"].ToString()).ToString("###,###,##0.###"));
							}
						}
						catch
						{
						}
					}
                    //ads.WriteXml("c:/lock6.xml", XmlWriteMode.WriteSchema);
					//BHYT
					if(((!chkPhongkham.Checked)&&(!chkNoitru.Checked))||((chkPhongkham.Checked)&&(chkNoitru.Checked)))
					{
						asql1="select '-1' id, sum(sotien) sotien from (select '-1' id, sum(decode(f.id,null,decode(a.madoituong,1,a.mien,0),0)) sotien from v_vienphict a, v_vienphill d, ("+asqlht+") f where a.id=d.id and d.quyenso=f.quyenso(+) and d.sobienlai=f.sobienlai(+) "+exp+" union all select '-1' id, sum(decode(f.id,null,nvl(d.bhyt,0),0)) sotien from v_ttrvll d, ("+asqlht+") f where d.quyenso=f.quyenso(+) and d.sobienlai=f.sobienlai(+) "+exp+")";
					}
					else
						if(chkPhongkham.Checked)
					{
						asql1="select '-1' id, sum(decode(f.id,null,decode(a.madoituong,1,a.mien,0),0)) sotien from v_vienphict a, v_vienphill d, ("+asqlht+") f where a.id=d.id and d.quyenso=f.quyenso(+) and d.sobienlai=f.sobienlai(+) "+exp;
					}
					else
					{
						asql1="select '-1' id, sum(decode(f.id,null,nvl(d.bhyt,0),0)) sotien from v_ttrvll d, ("+asqlht+") f where d.quyenso=f.quyenso(+) and d.sobienlai=f.sobienlai(+) "+exp;
					}
                ads1 = m_v.get_data_mmyy(asql1, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true); //m_v.get_data_bc(txtTN.Value.AddMonths(-1), txtDN.Value.AddMonths(1),asql1);
					
					for(int i=0;i<ads.Tables[0].Rows.Count;i++)
					{
						try
						{
							foreach(DataRow r in ads1.Tables[0].Select("id='"+ads.Tables[0].Rows[i]["id"].ToString().Trim()+"'"))
							{
								ads.Tables[0].Rows[i]["lock06"]=decimal.Parse(ads.Tables[0].Rows[i]["lock06"].ToString())+decimal.Parse(decimal.Parse(r["sotien"].ToString()).ToString("###,###,##0.###"));
							}
						}
						catch
						{
						}
					}
                    ads.WriteXml("c:/lock6.xml", XmlWriteMode.WriteSchema);
					//Mien
					if(((!chkPhongkham.Checked)&&(!chkNoitru.Checked))||((chkPhongkham.Checked)&&(chkNoitru.Checked)))
					{
						asql1="select '-2' id, sum(sotien) sotien from (select sum(to_number(decode(f.id,null,nvl(a.sotien,0),0))) sotien from v_mienngtru a, v_vienphill d, ("+asqlht+") f where a.id=d.id and d.quyenso=f.quyenso(+) and d.sobienlai=f.sobienlai(+) "+exp+" union all select sum(decode(f.id,null,nvl(d.mien,0),0)) sotien from v_ttrvll d, ("+asqlht+") f where d.quyenso=f.quyenso(+) and d.sobienlai=f.sobienlai(+) "+exp+")";
					}
					else
						if(chkPhongkham.Checked)
					{
						asql1="select '-2' id, sum(to_number(decode(f.id,null,nvl(a.sotien,0),0))) sotien from v_mienngtru a, v_vienphill d, ("+asqlht+") f where a.id=d.id and d.quyenso=f.quyenso(+) and d.sobienlai=f.sobienlai(+) "+exp;
					}
					else
					{
						asql1="select '-2' id, sum(decode(f.id,null,nvl(d.mien,0),0)) sotien from v_ttrvll d, ("+asqlht+") f where d.quyenso=f.quyenso(+) and d.sobienlai=f.sobienlai(+) "+exp;
					}
                ads1 = m_v.get_data_mmyy(asql1, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true); //m_v.get_data_bc(txtTN.Value.AddMonths(-1), txtDN.Value.AddMonths(1),asql1);
					
					for(int i=0;i<ads.Tables[0].Rows.Count;i++)
					{
						try
						{
							foreach(DataRow r in ads1.Tables[0].Select("id='"+ads.Tables[0].Rows[i]["id"].ToString().Trim()+"'"))
							{
								ads.Tables[0].Rows[i]["lock06"]=decimal.Parse(ads.Tables[0].Rows[i]["lock06"].ToString())+decimal.Parse(decimal.Parse(r["sotien"].ToString()).ToString("###,###,##0.###"));
							}
						}
						catch
						{
						}
					}
                    //ads.WriteXml("c:/lock6.xml", XmlWriteMode.WriteSchema);
                    //Tru theo khoa phong
					if(rd1.Checked)
					{
						//BHYT
						if(((!chkPhongkham.Checked)&&(!chkNoitru.Checked))||((chkPhongkham.Checked)&&(chkNoitru.Checked)))
						{
                            asql1 = "select to_char(nvl(to_number(d.makp),'-3')) id, sum(decode(f.id,null,nvl(d.bhyt,0),0)) sotien from v_ttrvll d, (" + asqlht + ") f where d.quyenso=f.quyenso(+) and d.sobienlai=f.sobienlai(+) " + exp + " group by to_char(nvl(to_number(d.makp),'-3'))" + " union all " + "select to_char(nvl(to_number(a.makp),'-3')) id, sum(decode(f.id,null,decode(a.madoituong,1,nvl(a.mien,0),0),0)) sotien from v_vienphict a, v_vienphill d, (" + asqlht + ") f where d.id=a.id and d.quyenso=f.quyenso(+) and d.sobienlai=f.sobienlai(+) " + exp + " group by to_char(nvl(to_number(a.makp),'-3'))";
						}
						else
							if(chkPhongkham.Checked)
						{
                            asql1 = "select to_char(nvl(to_number(a.makp),'-3')) id, sum(decode(f.id,null,decode(a.madoituong,1,nvl(a.mien,0),0),0)) sotien from v_vienphict a, v_vienphill d, (" + asqlht + ") f where d.id=a.id and d.quyenso=f.quyenso(+) and d.sobienlai=f.sobienlai(+) " + exp + " group by to_char(nvl(to_number(a.makp),'-3'))";
						}
						else
						{
                            asql1 = "select to_char(nvl(to_number(d.makp),'-3')) id, sum(decode(f.id,null,nvl(d.bhyt,0),0)) sotien from v_ttrvll d, (" + asqlht + ") f where d.quyenso=f.quyenso(+) and d.sobienlai=f.sobienlai(+) " + exp + " group by to_char(nvl(to_number(d.makp),'-3'))";
						}
                    ads1 = m_v.get_data_mmyy(asql1, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true); //m_v.get_data_bc(txtTN.Value.AddMonths(-1), txtDN.Value.AddMonths(1),asql1);
					
						for(int i=0;i<ads.Tables[0].Rows.Count;i++)
						{
							try
							{
								foreach(DataRow r in ads1.Tables[0].Select("id='"+ads.Tables[0].Rows[i]["id"].ToString().Trim()+"'"))
								{
									ads.Tables[0].Rows[i]["lock06"]=decimal.Parse(ads.Tables[0].Rows[i]["lock06"].ToString())-decimal.Parse(decimal.Parse(r["sotien"].ToString()).ToString("###,###,##0.###"));
								}
							}
							catch
							{
							}
						}
                        //ads.WriteXml("c:/lock6.xml", XmlWriteMode.WriteSchema);
						//Mien
						if(((!chkPhongkham.Checked)&&(!chkNoitru.Checked))||((chkPhongkham.Checked)&&(chkNoitru.Checked)))
						{
                            asql1 = "select to_char(nvl(to_number(d.makp),'-3')) id, sum(to_number(decode(f.id,null,nvl(a.sotien,0),0))) sotien from v_mienngtru a, v_vienphill d, (" + asqlht + ") f where a.id=d.id and d.quyenso=f.quyenso(+) and d.sobienlai=f.sobienlai(+) " + exp + " group by to_char(nvl(to_number(d.makp),'-3'))" + " union all " + "select to_char(nvl(to_number(d.makp),'-3')) id, sum(decode(f.id,null,nvl(d.mien,0),0)) sotien from v_ttrvll d, (" + asqlht + ") f where d.quyenso=f.quyenso(+) and d.sobienlai=f.sobienlai(+) " + exp + " group by to_char(nvl(to_number(d.makp),'-3'))";
						}
						else
							if(chkPhongkham.Checked)
						{
                            asql1 = "select to_char(nvl(to_number(d.makp),'-3')) id, sum(to_number(decode(f.id,null,nvl(a.sotien,0),0))) sotien from v_mienngtru a, v_vienphill d, (" + asqlht + ") f where a.id=d.id and d.quyenso=f.quyenso(+) and d.sobienlai=f.sobienlai(+) " + exp + " group by to_char(nvl(to_number(d.makp),'-3'))";
						}
						else
						{
                            asql1 = "select to_char(nvl(to_number(d.makp),'-3')) id, sum(decode(f.id,null,nvl(d.mien,0),0)) sotien from v_ttrvll d, (" + asqlht + ") f where d.quyenso=f.quyenso(+) and d.sobienlai=f.sobienlai(+) " + exp + " group by to_char(nvl(to_number(d.makp),'-3'))";
						}
                    ads1 = m_v.get_data_mmyy(asql1, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true); //m_v.get_data_bc(txtTN.Value.AddMonths(-1), txtDN.Value.AddMonths(1),asql1);
					
						for(int i=0;i<ads.Tables[0].Rows.Count;i++)
						{
							try
							{
								foreach(DataRow r in ads1.Tables[0].Select("id='"+ads.Tables[0].Rows[i]["id"].ToString().Trim()+"'"))
								{
									ads.Tables[0].Rows[i]["lock06"]=decimal.Parse(ads.Tables[0].Rows[i]["lock06"].ToString())-decimal.Parse(decimal.Parse(r["sotien"].ToString()).ToString("###,###,##0.###"));
								}
							}
							catch
							{
							}
						}
                        //ads.WriteXml("c:/lock6.xml", XmlWriteMode.WriteSchema);
					}
					//End Tru theo khoa phong

				}
				catch
				{
				}
#endregion
                #region Lock_last
				if(rdThang.Checked)
				{
					ad1=ad1.AddMonths(-1*7);
					ad2=ad2.AddMonths(-1);

					ayear=ad2.Year;
					amonth=ad2.Month;
					ad2 = new DateTime(ayear,amonth,DateTime.DaysInMonth(ayear,amonth));
				}
				else
				{
					ad1=ad1.AddDays(asn*7);
					ad2=ad2.AddDays(asn);
				}
				if((ad1-ad2).Days==0)
				{
					alock_last=f_StringDate(ad1);
				}
				else
				{
					alock_last=f_StringDate(ad1)+" - "+f_StringDate(ad2);
				}
				try
				{
					exp=" and to_date(to_char(d.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('"+f_StringDate(ad1)+"','dd/mm/yyyy') and to_date(to_char(d.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')<=to_date('"+f_StringDate(ad2)+"','dd/mm/yyyy')";
					asqlht="select * from v_hoantra where to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('"+f_StringDate(ad1)+"','dd/mm/yyyy') and to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy')<=to_date('"+f_StringDate(ad2)+"','dd/mm/yyyy')";
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
					if(((!chkPhongkham.Checked)&&(!chkNoitru.Checked))||((chkPhongkham.Checked)&&(chkNoitru.Checked)))
					{
						asql1="select id, sum(sotien) sotien from (select to_char("+agroup+") id, sum(nvl(a.soluong,0)*nvl(a.dongia,0)-nvl(a.thieu,0)) sotien from v_vienphict a, (select id, id_loai from v_giavp union all select id, 0 id_loai from d_dmbd) b, (select id from v_loaivp union all select 0 from dual) c, v_vienphill d, btdkp_bv e where a.id=d.id and a.mavp=b.id(+) and b.id_loai=c.id(+) and a.makp=e.makp(+)  "+exp+" group by "+agroup+" union all select to_char("+agroup+") id, sum(nvl(a.soluong,0)*nvl(a.dongia,0)+nvl(a.soluong,0)*nvl(a.dongia,0)*round(nvl(a.vat,0)/100,3)) sotien from v_ttrvct a, (select id, id_loai from v_giavp union all select 0 id, 0 id_loai from dual) b, (select id from v_loaivp union all select 0 from dual) c, v_ttrvll d, btdkp_bv e where a.id=d.id and a.mavp=b.id(+) and b.id_loai=c.id(+) and a.makp=e.makp(+)  "+exp+" group by "+agroup+") group by id";
					}
					else
						if(chkPhongkham.Checked)
					{
						asql1="select id, sum(sotien) sotien from (select to_char("+agroup+") id, sum(nvl(a.soluong,0)*nvl(a.dongia,0)-nvl(a.thieu,0)) sotien from v_vienphict a, (select id, id_loai from v_giavp union all select id, 0 id_loai from d_dmbd) b, (select id from v_loaivp union all select 0 from dual) c, v_vienphill d, btdkp_bv e where a.id=d.id and a.mavp=b.id(+) and b.id_loai=c.id(+) and a.makp=e.makp(+)  "+exp+" group by "+agroup+") group by id";
					}
					else
					{
						asql1="select to_char("+agroup+") id, sum(nvl(a.soluong,0)*nvl(a.dongia,0)+nvl(a.soluong,0)*nvl(a.dongia,0)*round(nvl(a.vat,0)/100,3)) sotien from v_ttrvct a, (select id, id_loai from v_giavp union all select id, 0 id_loai from d_dmbd) b, (select id from v_loaivp union all select 0 from dual) c, v_ttrvll d, btdkp_bv e where a.id=d.id and a.mavp=b.id(+) and b.id_loai=c.id(+) and a.makp=e.makp(+)  "+exp+" group by "+agroup;
					}
                ads1 = m_v.get_data_mmyy(asql1, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true); //m_v.get_data_bc(txtTN.Value.AddMonths(-1), txtDN.Value.AddMonths(1),asql1);
					for(int i=0;i<ads.Tables[0].Rows.Count;i++)
					{
						try
						{
							foreach(DataRow r in ads1.Tables[0].Select("id='"+ads.Tables[0].Rows[i]["id"].ToString().Trim()+"'"))
							{
								ads.Tables[0].Rows[i]["lock_last"]=decimal.Parse(ads.Tables[0].Rows[i]["lock_last"].ToString())+decimal.Parse(decimal.Parse(r["sotien"].ToString()).ToString("###,###,##0.###"));
							}
						}
						catch
						{
						}
					}
                    //ads.WriteXml("c:/locklast.xml", XmlWriteMode.WriteSchema);
					//BHYT
					if(((!chkPhongkham.Checked)&&(!chkNoitru.Checked))||((chkPhongkham.Checked)&&(chkNoitru.Checked)))
					{
						asql1="select '-1' id, sum(sotien) sotien from (select '-1' id, sum(decode(f.id,null,decode(a.madoituong,1,a.mien,0),0)) sotien from v_vienphict a, v_vienphill d, ("+asqlht+") f where a.id=d.id and d.quyenso=f.quyenso(+) and d.sobienlai=f.sobienlai(+) "+exp+" union all select '-1' id, sum(decode(f.id,null,nvl(d.bhyt,0),0)) sotien from v_ttrvll d, ("+asqlht+") f where d.quyenso=f.quyenso(+) and d.sobienlai=f.sobienlai(+) "+exp+")";
					}
					else
						if(chkPhongkham.Checked)
					{
						asql1="select '-1' id, sum(decode(f.id,null,decode(a.madoituong,1,a.mien,0),0)) sotien from v_vienphict a, v_vienphill d, ("+asqlht+") f where a.id=d.id and d.quyenso=f.quyenso(+) and d.sobienlai=f.sobienlai(+) "+exp;
					}
					else
					{
						asql1="select '-1' id, sum(decode(f.id,null,nvl(d.bhyt,0),0)) sotien from v_ttrvll d, ("+asqlht+") f where d.quyenso=f.quyenso(+) and d.sobienlai=f.sobienlai(+) "+exp;
					}
                ads1 = m_v.get_data_mmyy(asql1, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true); //m_v.get_data_bc(txtTN.Value.AddMonths(-1), txtDN.Value.AddMonths(1),asql1);
					
					for(int i=0;i<ads.Tables[0].Rows.Count;i++)
					{
						try
						{
							foreach(DataRow r in ads1.Tables[0].Select("id='"+ads.Tables[0].Rows[i]["id"].ToString().Trim()+"'"))
							{
								ads.Tables[0].Rows[i]["lock_last"]=decimal.Parse(ads.Tables[0].Rows[i]["lock_last"].ToString())+decimal.Parse(decimal.Parse(r["sotien"].ToString()).ToString("###,###,##0.###"));
							}
						}
						catch
						{
						}
					}
                    //ads.WriteXml("c:/locklast.xml", XmlWriteMode.WriteSchema);
					//Mien
					if(((!chkPhongkham.Checked)&&(!chkNoitru.Checked))||((chkPhongkham.Checked)&&(chkNoitru.Checked)))
					{
						asql1="select '-2' id, sum(sotien) sotien from (select sum(to_number(decode(f.id,null,nvl(a.sotien,0),0))) sotien from v_mienngtru a, v_vienphill d, ("+asqlht+") f where a.id=d.id and d.quyenso=f.quyenso(+) and d.sobienlai=f.sobienlai(+) "+exp+" union all select sum(decode(f.id,null,nvl(d.mien,0),0)) sotien from v_ttrvll d, ("+asqlht+") f where d.quyenso=f.quyenso(+) and d.sobienlai=f.sobienlai(+) "+exp+")";
					}
					else
						if(chkPhongkham.Checked)
					{
						asql1="select '-2' id, sum(to_number(decode(f.id,null,nvl(a.sotien,0),0))) sotien from v_mienngtru a, v_vienphill d, ("+asqlht+") f where a.id=d.id and d.quyenso=f.quyenso(+) and d.sobienlai=f.sobienlai(+) "+exp;
					}
					else
					{
						asql1="select '-2' id, sum(decode(f.id,null,nvl(d.mien,0),0)) sotien from v_ttrvll d, ("+asqlht+") f where d.quyenso=f.quyenso(+) and d.sobienlai=f.sobienlai(+) "+exp;
					}
                ads1 = m_v.get_data_mmyy(asql1, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true); //m_v.get_data_bc(txtTN.Value.AddMonths(-1), txtDN.Value.AddMonths(1),asql1);
					
					for(int i=0;i<ads.Tables[0].Rows.Count;i++)
					{
						try
						{
							foreach(DataRow r in ads1.Tables[0].Select("id='"+ads.Tables[0].Rows[i]["id"].ToString().Trim()+"'"))
							{
								ads.Tables[0].Rows[i]["lock_last"]=decimal.Parse(ads.Tables[0].Rows[i]["lock_last"].ToString())+decimal.Parse(decimal.Parse(r["sotien"].ToString()).ToString("###,###,##0.###"));
							}
						}
						catch
						{
						}
					}
                    //ads.WriteXml("c:/locklast.xml", XmlWriteMode.WriteSchema);
					//Tru theo khoa phong
					if(rd1.Checked)
					{
						//BHYT
						if(((!chkPhongkham.Checked)&&(!chkNoitru.Checked))||((chkPhongkham.Checked)&&(chkNoitru.Checked)))
						{
                            asql1 = "select to_char(nvl(to_number(d.makp),'-3')) id, sum(decode(f.id,null,nvl(d.bhyt,0),0)) sotien from v_ttrvll d, (" + asqlht + ") f where d.quyenso=f.quyenso(+) and d.sobienlai=f.sobienlai(+) " + exp + " group by to_char(nvl(to_number(d.makp),'-3'))" + " union all " + "select to_char(nvl(to_number(a.makp),'-3')) id, sum(decode(f.id,null,decode(a.madoituong,1,nvl(a.mien,0),0),0)) sotien from v_vienphict a, v_vienphill d, (" + asqlht + ") f where d.id=a.id and d.quyenso=f.quyenso(+) and d.sobienlai=f.sobienlai(+) " + exp + " group by to_char(nvl(to_number(a.makp),'-3'))";
						}
						else
							if(chkPhongkham.Checked)
						{
                            asql1 = "select to_char(nvl(to_number(a.makp),'-3')) id, sum(decode(f.id,null,decode(a.madoituong,1,nvl(a.mien,0),0),0)) sotien from v_vienphict a, v_vienphill d, (" + asqlht + ") f where d.id=a.id and d.quyenso=f.quyenso(+) and d.sobienlai=f.sobienlai(+) " + exp + " group by to_char(nvl(to_number(a.makp),'-3'))";
						}
						else
						{
                            asql1 = "select nto_char(nvl(to_number(d.makp),'-3')) id, sum(decode(f.id,null,nvl(d.bhyt,0),0)) sotien from v_ttrvll d, (" + asqlht + ") f where d.quyenso=f.quyenso(+) and d.sobienlai=f.sobienlai(+) " + exp + " group by to_char(nvl(to_number(d.makp),'-3'))";
						}
                    ads1 = m_v.get_data_mmyy(asql1, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true); //m_v.get_data_bc(txtTN.Value.AddMonths(-1), txtDN.Value.AddMonths(1),asql1);
					
						for(int i=0;i<ads.Tables[0].Rows.Count;i++)
						{
							try
							{
								foreach(DataRow r in ads1.Tables[0].Select("id='"+ads.Tables[0].Rows[i]["id"].ToString().Trim()+"'"))
								{
									ads.Tables[0].Rows[i]["lock_last"]=decimal.Parse(ads.Tables[0].Rows[i]["lock_last"].ToString())-decimal.Parse(decimal.Parse(r["sotien"].ToString()).ToString("###,###,##0.###"));
								}
							}
							catch
							{
							}
						}
                        //ads.WriteXml("c:/locklast.xml", XmlWriteMode.WriteSchema);
						//Mien
						if(((!chkPhongkham.Checked)&&(!chkNoitru.Checked))||((chkPhongkham.Checked)&&(chkNoitru.Checked)))
						{
                            asql1 = "select to_char(nvl(to_number(d.makp),'-3')) id, sum(to_number(decode(f.id,null,nvl(a.sotien,0),0))) sotien from v_mienngtru a, v_vienphill d, (" + asqlht + ") f where a.id=d.id and d.quyenso=f.quyenso(+) and d.sobienlai=f.sobienlai(+) " + exp + " group by to_char(nvl(to_number(d.makp),'-3'))" + " union all " + "select to_char(nvl(to_number(d.makp),'-3')) id, sum(decode(f.id,null,nvl(d.mien,0),0)) sotien from v_ttrvll d, (" + asqlht + ") f where d.quyenso=f.quyenso(+) and d.sobienlai=f.sobienlai(+) " + exp + " group by to_char(nvl(to_number(d.makp),'-3'))";
						}
						else
							if(chkPhongkham.Checked)
						{
                            asql1 = "select to_char(nvl(to_number(d.makp),'-3')) id, sum(to_number(decode(f.id,null,nvl(a.sotien,0),0))) sotien from v_mienngtru a, v_vienphill d, (" + asqlht + ") f where a.id=d.id and d.quyenso=f.quyenso(+) and d.sobienlai=f.sobienlai(+) " + exp + " group by to_char(nvl(to_number(d.makp),'-3'))";
						}
						else
						{
                            asql1 = "select to_char(nvl(to_number(d.makp),'-3')) id, sum(decode(f.id,null,nvl(d.mien,0),0)) sotien from v_ttrvll d, (" + asqlht + ") f where d.quyenso=f.quyenso(+) and d.sobienlai=f.sobienlai(+) " + exp + " group by to_char(nvl(to_number(d.makp),'-3'))";
						}
                    ads1 = m_v.get_data_mmyy(asql1, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true); //m_v.get_data_bc(txtTN.Value.AddMonths(-1), txtDN.Value.AddMonths(1),asql1);
					
						for(int i=0;i<ads.Tables[0].Rows.Count;i++)
						{
							try
							{
								foreach(DataRow r in ads1.Tables[0].Select("id='"+ads.Tables[0].Rows[i]["id"].ToString().Trim()+"'"))
								{
									ads.Tables[0].Rows[i]["lock_last"]=decimal.Parse(ads.Tables[0].Rows[i]["lock_last"].ToString())-decimal.Parse(decimal.Parse(r["sotien"].ToString()).ToString("###,###,##0.###"));
								}
							}
							catch
							{
							}
						}
                        //ads.WriteXml("c:/locklast.xml", XmlWriteMode.WriteSchema);
					}
					//End Tru theo khoa phong

				}
				catch
				{
                }
                ads.WriteXml("..//..//Datareport//v_baocaotonghop.xml", XmlWriteMode.WriteSchema);
                #endregion

                #region haison dong
                //Miển sẽ trừ vào tổng số tiền
                //try
                //{
                //    rtmp = ads.Tables[0].Select("id='-1'")[0];
                //    rtmp["sotien"]=decimal.Parse(rtmp["sotien"].ToString())*-1;
                //    rtmp["luykethang"]=decimal.Parse(rtmp["luykethang"].ToString())*-1;
                //    rtmp["luykenam"]=decimal.Parse(rtmp["luykenam"].ToString())*-1;
                //    rtmp["lock01"]=decimal.Parse(rtmp["lock01"].ToString())*-1;
                //    rtmp["lock02"]=decimal.Parse(rtmp["lock02"].ToString())*-1;
                //    rtmp["lock03"]=decimal.Parse(rtmp["lock03"].ToString())*-1;
                //    rtmp["lock04"]=decimal.Parse(rtmp["lock04"].ToString())*-1;
                //    rtmp["lock05"]=decimal.Parse(rtmp["lock05"].ToString())*-1;
                //    rtmp["lock06"]=decimal.Parse(rtmp["lock06"].ToString())*-1;
                //    rtmp["lock_last"]=decimal.Parse(rtmp["lock_last"].ToString())*-1;
                //}
                //catch
                //{
                //}
                ////BHYT sẽ trừ vào tổng số tiền
                //try
                //{
                //    rtmp = ads.Tables[0].Select("id='-2'")[0];
                //    rtmp["sotien"]=decimal.Parse(rtmp["sotien"].ToString())*-1;
                //    rtmp["luykethang"]=decimal.Parse(rtmp["luykethang"].ToString())*-1;
                //    rtmp["luykenam"]=decimal.Parse(rtmp["luykenam"].ToString())*-1;
                //    rtmp["lock01"]=decimal.Parse(rtmp["lock01"].ToString())*-1;
                //    rtmp["lock02"]=decimal.Parse(rtmp["lock02"].ToString())*-1;
                //    rtmp["lock03"]=decimal.Parse(rtmp["lock03"].ToString())*-1;
                //    rtmp["lock04"]=decimal.Parse(rtmp["lock04"].ToString())*-1;
                //    rtmp["lock05"]=decimal.Parse(rtmp["lock05"].ToString())*-1;
                //    rtmp["lock06"]=decimal.Parse(rtmp["lock06"].ToString())*-1;
                //    rtmp["lock_last"]=decimal.Parse(rtmp["lock_last"].ToString())*-1;
                //}
                //catch
                //{
                //}
                ////Xoá cac record neu khong phat sinh
                //try
                //{
                //    if(chkPhatsinh.Checked)
                //    {
                //        while(ads.Tables[0].Select("sotien=0 and luykethang=0 and luykenam=0 and lock01=0 and lock02=0 and lock03=0 and lock04=0 and lock05=0 and lock06=0 and lock_last=0").Length>0)
                //        {
                //            ads.Tables[0].Rows.Remove(ads.Tables[0].Select("sotien=0 and luykethang=0 and luykenam=0 and lock01=0 and lock02=0 and lock03=0 and lock04=0 and lock05=0 and lock06=0 and lock_last=0")[0]);
                //        }
                //    }
                //}
                //catch
                //{
                //}

                ////Xoá cac record neu co mien giam
                //if(rd1.Checked && !chkMien.Checked)
                //{
                //    while(ads.Tables[0].Select("id='-1' or id='-2'").Length>0)
                //    {
                //        ads.Tables[0].Rows.Remove(ads.Tables[0].Select("id='-1' or id='-2'")[0]);
                //    }
                //}
                //else
                //if(!chkMien.Checked)
                //{
                //    try
                //    {
                //        decimal aasotien=0,aaluykethang=0,aaluykenam=0,aalock01=0,aalock02=0,aalock03=0,aalock04=0,aalock05=0,aalock06=0,aalock_last=0;
                //        decimal aasotientl=0,aaluykethangtl=0,aaluykenamtl=0,aalock01tl=0,aalock02tl=0,aalock03tl=0,aalock04tl=0,aalock05tl=0,aalock06tl=0,aalock_lasttl=0;
                //        decimal atmp=0;
                //        foreach(DataRow r in ads.Tables[0].Select("id <>'-1' and id<> '-2'"))
                //        {
                //            try
                //            {
                //                atmp=decimal.Parse(decimal.Parse(r["sotien"].ToString()).ToString("###,###,##0.###"));
                //            }
                //            catch
                //            {
                //                atmp=0;
                //            }
                //            aasotien+=atmp;

                //            try
                //            {
                //                atmp=decimal.Parse(r["luykethang"].ToString());
                //            }
                //            catch
                //            {
                //                atmp=0;
                //            }
                //            aaluykethang+=atmp;

                //            try
                //            {
                //                atmp=decimal.Parse(r["luykenam"].ToString());
                //            }
                //            catch
                //            {
                //                atmp=0;
                //            }
                //            aaluykenam+=atmp;
						
                //            try
                //            {
                //                atmp=decimal.Parse(r["lock01"].ToString());
                //            }
                //            catch
                //            {
                //                atmp=0;
                //            }
                //            aalock01+=atmp;
                //            try
                //            {
                //                atmp=decimal.Parse(r["lock02"].ToString());
                //            }
                //            catch
                //            {
                //                atmp=0;
                //            }
                //            aalock02+=atmp;
                //            try
                //            {
                //                atmp=decimal.Parse(r["lock03"].ToString());
                //            }
                //            catch
                //            {
                //                atmp=0;
                //            }
                //            aalock03+=atmp;
                //            try
                //            {
                //                atmp=decimal.Parse(r["lock04"].ToString());
                //            }
                //            catch
                //            {
                //                atmp=0;
                //            }
                //            aalock04+=atmp;
                //            try
                //            {
                //                atmp=decimal.Parse(r["lock05"].ToString());
                //            }
                //            catch
                //            {
                //                atmp=0;
                //            }
                //            aalock05+=atmp;
                //            try
                //            {
                //                atmp=decimal.Parse(r["lock06"].ToString());
                //            }
                //            catch
                //            {
                //                atmp=0;
                //            }
                //            aalock06+=atmp;
                //            try
                //            {
                //                atmp=decimal.Parse(r["lock_last"].ToString());
                //            }
                //            catch
                //            {
                //                atmp=0;
                //            }
                //            aalock_last+=atmp;
                //        }
                //        //Tinh ti le
                //        foreach(DataRow r in ads.Tables[0].Select("id ='-1' or id = '-2'"))
                //        {
                //            try
                //            {
                //                atmp=decimal.Parse(decimal.Parse(r["sotien"].ToString()).ToString("###,###,##0.###"));
                //            }
                //            catch
                //            {
                //                atmp=0;
                //            }
                //            aasotientl+=atmp;

                //            try
                //            {
                //                atmp=decimal.Parse(r["luykethang"].ToString());
                //            }
                //            catch
                //            {
                //                atmp=0;
                //            }
                //            aaluykethangtl+=atmp;

                //            try
                //            {
                //                atmp=decimal.Parse(r["luykenam"].ToString());
                //            }
                //            catch
                //            {
                //                atmp=0;
                //            }
                //            aaluykenamtl+=atmp;
						
                //            try
                //            {
                //                atmp=decimal.Parse(r["lock01"].ToString());
                //            }
                //            catch
                //            {
                //                atmp=0;
                //            }
                //            aalock01tl+=atmp;
                //            try
                //            {
                //                atmp=decimal.Parse(r["lock02"].ToString());
                //            }
                //            catch
                //            {
                //                atmp=0;
                //            }
                //            aalock02tl+=atmp;
                //            try
                //            {
                //                atmp=decimal.Parse(r["lock03"].ToString());
                //            }
                //            catch
                //            {
                //                atmp=0;
                //            }
                //            aalock03tl+=atmp;
                //            try
                //            {
                //                atmp=decimal.Parse(r["lock04"].ToString());
                //            }
                //            catch
                //            {
                //                atmp=0;
                //            }
                //            aalock04tl+=atmp;
                //            try
                //            {
                //                atmp=decimal.Parse(r["lock05"].ToString());
                //            }
                //            catch
                //            {
                //                atmp=0;
                //            }
                //            aalock05tl+=atmp;
                //            try
                //            {
                //                atmp=decimal.Parse(r["lock06"].ToString());
                //            }
                //            catch
                //            {
                //                atmp=0;
                //            }
                //            aalock06tl+=atmp;
                //            try
                //            {
                //                atmp=decimal.Parse(r["lock_last"].ToString());
                //            }
                //            catch
                //            {
                //                atmp=0;
                //            }
                //            aalock_lasttl+=atmp;
                //        }
                //        //end  foreach(DataRow r in ads.Tables[0].Select("id ='-1' or id = '-2'"))
                //        try
                //        {
                //            aasotientl=aasotientl/aasotien;
                //        }
                //        catch
                //        {
                //            aasotientl=0;
                //        }
                //        try
                //        {
                //            aaluykethangtl=aaluykethangtl/aaluykethang;
                //        }
                //        catch
                //        {
                //            aaluykethangtl=0;
                //        }
                //        try
                //        {
                //            aaluykenamtl=aaluykenamtl/aaluykenamtl;
                //        }
                //        catch
                //        {
                //            aaluykenamtl=0;
                //        }
                //        try
                //        {
                //            aalock01tl=aalock01tl/aalock01;
                //        }
                //        catch
                //        {
                //            aalock01tl=0;
                //        }
                //        try
                //        {
                //            aalock02tl=aalock02tl/aalock02;
                //        }
                //        catch
                //        {
                //            aalock02tl=0;
                //        }
                //        try
                //        {
                //            aalock03tl=aalock03tl/aalock03;
                //        }
                //        catch
                //        {
                //            aalock03tl=0;
                //        }
                //        try
                //        {
                //            aalock04tl=aalock04tl/aalock04;
                //        }
                //        catch
                //        {
                //            aalock04tl=0;
                //        }
                //        try
                //        {
                //            aalock05tl=aalock05tl/aalock05;
                //        }
                //        catch
                //        {
                //            aalock05tl=0;
                //        }
                //        try
                //        {
                //            aalock06tl=aalock06tl/aalock06;
                //        }
                //        catch
                //        {
                //            aalock06tl=0;
                //        }
                //        try
                //        {
                //            aalock_last=aalock_lasttl/aalock_last;
                //        }
                //        catch
                //        {
                //            aalock_lasttl=0;
                //        }

                //        foreach(DataRow r in ads.Tables[0].Select("id <>'-1' and id<> '-2'"))
                //        {
                //            try
                //            {
                //                atmp=decimal.Parse(decimal.Parse(r["sotien"].ToString()).ToString("###,###,##0.###"));
                //            }
                //            catch
                //            {
                //                atmp=0;
                //            }
                //            r["sotien"]=Math.Round(atmp+atmp*aasotientl,3);

                //            try
                //            {
                //                atmp=decimal.Parse(r["luykethang"].ToString());
                //            }
                //            catch
                //            {
                //                atmp=0;
                //            }
                //            r["luykethang"]=Math.Round(atmp+atmp*aaluykethangtl,3);

                //            try
                //            {
                //                atmp=decimal.Parse(r["luykenam"].ToString());
                //            }
                //            catch
                //            {
                //                atmp=0;
                //            }
                //            r["luykenam"]=Math.Round(atmp+atmp*aaluykenamtl,3);
						
                //            try
                //            {
                //                atmp=decimal.Parse(r["lock01"].ToString());
                //            }
                //            catch
                //            {
                //                atmp=0;
                //            }
                //            r["lock01"]=Math.Round(atmp+atmp*aalock01tl,3);
                //            try
                //            {
                //                atmp=decimal.Parse(r["lock02"].ToString());
                //            }
                //            catch
                //            {
                //                atmp=0;
                //            }
                //            r["lock02"]=Math.Round(atmp+atmp*aalock02tl,3);
                //            try
                //            {
                //                atmp=decimal.Parse(r["lock03"].ToString());
                //            }
                //            catch
                //            {
                //                atmp=0;
                //            }
                //            r["lock03"]=Math.Round(atmp+atmp*aalock03tl,3);
                //            try
                //            {
                //                atmp=decimal.Parse(r["lock04"].ToString());
                //            }
                //            catch
                //            {
                //                atmp=0;
                //            }
                //            r["lock04"]=Math.Round(atmp+atmp*aalock04tl,3);
                //            try
                //            {
                //                atmp=decimal.Parse(r["lock05"].ToString());
                //            }
                //            catch
                //            {
                //                atmp=0;
                //            }
                //            r["lock05"]=Math.Round(atmp+atmp*aalock05tl,3);
                //            try
                //            {
                //                atmp=decimal.Parse(r["lock06"].ToString());
                //            }
                //            catch
                //            {
                //                atmp=0;
                //            }
                //            r["lock06"]=Math.Round(atmp+atmp*aalock06tl,3);
                //            try
                //            {
                //                atmp=decimal.Parse(r["lock_last"].ToString());
                //            }
                //            catch
                //            {
                //                atmp=0;
                //            }
                //            r["lock_last"]=Math.Round(atmp+atmp*aalock_lasttl,3);
                //        }

                //        while(ads.Tables[0].Select("id='-1' or id='-2'").Length>0)
                //        {
                //            ads.Tables[0].Rows.Remove(ads.Tables[0].Select("id='-1' or id='-2'")[0]);
                //        }
                //    }
                //    catch
                //    {
                //    }
                //}
                #endregion

                //ads.WriteXml("..//..//Datareport//v_baocaotonghop.xml", XmlWriteMode.WriteSchema);
				//return;
				if(ads.Tables[0].Rows.Count<=0)
				{
					progressBar1.Value=progressBar1.Maximum;
					timer1.Enabled=false;
					progressBar1.Value=0;
					MessageBox.Show(this,lan.Change_language_MessageText("Không có dữ liệu báo cáo"),m_v.s_AppName,MessageBoxButtons.OK,MessageBoxIcon.Information);
					return;
				}
				//decimal asotien=0;
                //for(int i=0;i<ads.Tables[0].Rows.Count;i++)
                //{
                //    decimal ast=0;
                //    try
                //    {
                //        ast=decimal.Parse(ads.Tables[0].Rows[i]["sotien"].ToString().Trim());
                //    }
                //    catch
                //    {
                //        ast=0;
                //    }
                //    asotien=asotien+ast;
                //}
				string achutien="";
				try
				{
					achutien = "";
				}
				catch
				{
					achutien = lan.Change_language_MessageText("0đồng");
				}
			


				string areport="v_baocaotonghop.rpt",asyt="",abv="",angayin="",anguoiin="",aghichu="", atenloai="";
				areport="v_baocaotonghop.rpt";
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
				atenloai=rd1.Checked?lan.Change_language_MessageText("KHOA PHÒNG"):lan.Change_language_MessageText("NỘI DUNG");
				angayin =lan.Change_language_MessageText("Ngày")+" " + txtNgayIn.Value.Day.ToString().PadLeft(2,'0') + " "+lan.Change_language_MessageText("tháng")+" " + txtNgayIn.Value.Month.ToString().PadLeft(2,'0') + " "+lan.Change_language_MessageText("năm")+" " + txtNgayIn.Value.Year.ToString();
				anguoiin = lbNguoiDN.Text.Substring(lbNguoiDN.Text.IndexOf(":")+1).Trim();
				aghichu = f_Get_GhiChu();
				if(menuItem1.Checked)
				{
					ads.WriteXml("..//..//Datareport//v_"+areport.Replace(".rpt","")+".xml", XmlWriteMode.WriteSchema);
				}
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
     
                frmReport af = new frmReport(m_v, ads.Tables[0], areport, asyt, abv, angayin, anguoiin, aghichu, achutien, atenloai, txtNguoilapbang.Text.Trim(), txtTaivu.Text.Trim(), txtThuquy.Text.Trim(), alock00, alock01, alock02, alock03, alock04, alock05, alock06, alock_last, aluykethang, aluykenam, alamtron, "Báo cáo tổng hợp thu viện phí");
				af.ShowDialog();
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
				string asqltt="", asqlnt="",asqlht="";
				string exp="";
				string auserid=f_Get_CheckID(tree_User,1);
				string aquyensoid=f_Get_CheckID(tree_User,2);
				string aloaibn=f_Get_CheckID(tree_Loaibn);
				if(m_v.sys_dungchungso)
				{
					auserid = f_Get_CheckID(tree_User);
					aquyensoid = f_Get_CheckID(tree_Quyenso);
				}

				asqlht="select * from medibvmmyy.v_hoantra where to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('"+f_StringDate(txtTN.Value)+"','dd/mm/yyyy') and to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy')<=to_date('"+f_StringDate(txtDN.Value)+"','dd/mm/yyyy')";
				//TT
				exp=" and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('"+f_StringDate(txtTN.Value)+"','dd/mm/yyyy') and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')<=to_date('"+f_StringDate(txtDN.Value)+"','dd/mm/yyyy')";
				if(auserid!="")
				{
					exp+=" and a.userid in("+auserid+")";
					asqlht+=" and userid in ("+auserid+")";
				}
				if(aquyensoid!="")
				{
					exp+=" and a.quyenso in("+aquyensoid+")";
				}
				if(aloaibn!="")
				{
					exp+=" and a.loaibn in("+aloaibn+")";
				}
				//TT
                asqltt = "select a.id, to_char(a.ngay,'dd/mm/yyyy') ngay, nvl(to_number(f.id),0) id_loai,f.ten tenloai, nvl(to_number(g.madoituong),0) madoituong, g.doituong, sum(nvl(b.soluong,0)*nvl(b.dongia,0)-nvl(b.thieu,0)) soien, sum(to_number(decode(b.madoituong,1,nvl(b.mien,0),0))) bhyt, max(to_number(decode(b.madoituong,1,0,nvl(d.sotien,0)))) mien, a.loai,a.loaibn from medibvmmyy.v_vienphill a, medibvmmyy.v_vienphict b, (" + asqlht + ") c, medibvmmyy.v_mienngtru d, medibv.v_giavp e, medibv.v_loaivp f, medibv.doituong g where a.id=b.id and d.id(+)=a.id and c.quyenso(+)=a.quyenso and c.sobienlai(+)=a.sobienlai and c.mabn(+)=a.mabn and f.id(+)=e.id_loai and e.id(+)=b.mavp and g.madoituong(+)=b.madoituong and c.id is null " + exp + " group by a.id, to_char(a.ngay,'dd/mm/yyyy'), nvl(to_number(f.id),0),f.ten, nvl(to_number(g.madoituong),0), g.doituong, a.loai ,a.loaibn";
				//TTRV
                asqlnt = "select a.id, to_char(a.ngay,'dd/mm/yyyy') ngay, nvl(to_number(f.id),0) id_loai,f.ten tenloai, nvl(to_number(g.madoituong),0) madoituong, g.doituong, sum(nvl(b.soluong,0)*nvl(b.dongia,0)) soien, max(nvl(a.bhyt,0)) bhyt, max(nvl(a.mien,0)) mien, a.loai, a.loaibn from medibvmmyy.v_ttrvll a, medibvmmyy.v_ttrvct b, (" + asqlht + ") c, medibv.v_giavp e, medibv.v_loaivp f, medibv.doituong g where a.id=b.id and c.quyenso(+)=a.quyenso and c.sobienlai(+)=a.sobienlai and f.id(+)=e.id_loai and e.id(+)=b.mavp and g.madoituong(+)=b.madoituong and c.id is null " + exp + " group by a.id, to_char(a.ngay,'dd/mm/yyyy'), nvl(to_number(f.id),0),f.ten, nvl(to_number(g.madoituong),0), g.doituong, a.loai, a.loaibn";

				DataSet ads = new DataSet();
				DataSet ads1 = new DataSet();
				DataSet ads2 = new DataSet();

				if((chkNoitru.Checked && chkPhongkham.Checked) || (!chkNoitru.Checked && !chkPhongkham.Checked))
				{
                    ads1 = m_v.get_data_mmyy(asqltt, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true); //m_v.get_data_bc(txtTN.Value,txtDN.Value,asqltt);
                    ads2 = m_v.get_data_mmyy(asqlnt, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true); //m_v.get_data_bc(txtTN.Value,txtDN.Value,asqlnt);
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
					if(chkPhongkham.Checked)
				{
                    ads = m_v.get_data_mmyy(asqltt, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true); //m_v.get_data_bc(txtTN.Value,txtDN.Value,asqltt);
				}
				else
				{
                    ads = m_v.get_data_mmyy(asqlnt, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true); //m_v.get_data_bc(txtTN.Value,txtDN.Value,asqlnt);
				}

				ads1.Dispose();
				ads2.Dispose();


				string areport="v_baocaotonghopdoituong.rpt",asyt="",abv="",angayin="",anguoiin="",aghichu="";
				areport="v_baocaotonghopdoituong.rpt";

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
				angayin =lan.Change_language_MessageText("Ngày")+" " + txtNgayIn.Value.Day.ToString().PadLeft(2,'0') + " "+lan.Change_language_MessageText("tháng")+" " + txtNgayIn.Value.Month.ToString().PadLeft(2,'0') + " "+lan.Change_language_MessageText("năm")+" " + txtNgayIn.Value.Year.ToString();
				anguoiin = lbNguoiDN.Text.Substring(lbNguoiDN.Text.IndexOf(":")+1).Trim();
				aghichu = f_Get_GhiChu();
				if(menuItem1.Checked)
				{
					ads.WriteXml("..//..//Datareport//v_"+areport.Replace(".rpt","")+".xml", XmlWriteMode.WriteSchema);
				}


                frmReport af = new frmReport(m_v, ads.Tables[0], areport, asyt.ToUpper(), abv.ToUpper(), angayin, anguoiin, aghichu, txtNguoilapbang.Text.Trim(), txtThuquy.Text.Trim(), txtTaivu.Text.Trim(), txtTCKT.Text.Trim(), "Báo cáo tổng hợp thu viện phí", 1, checkBox1.Checked ? true : false);
				af.ShowDialog();
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
                if (m_v.get_data("select sotien from medibv.v_lamtron where loai=2 and tungay='" + v_tn + "' and denngay='" + v_dn + "'").Tables[0].Rows.Count > 0)
				{
                    m_v.execute_data("update medibv.v_lamtron set sotien=" + v_sotien + " where loai=2 and tungay='" + v_tn + "' and denngay='" + v_dn + "'");
				}
				else
				{
                    m_v.execute_data("insert into medibv.v_lamtron(loai,tungay,denngay,sotien) values(2,'" + v_tn + "','" + v_dn + "'," + v_sotien + ")");
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
                txtLamtron.Text = decimal.Parse(m_v.get_data("select sotien from medibv.v_lamtron where loai=2 and tungay='" + txtTN.Text.Substring(0, 10) + "' and denngay='" + txtDN.Text.Substring(0, 10) + "'").Tables[0].Rows[0]["sotien"].ToString()).ToString("###,###,##0.###");
			}
			catch
			{
				txtLamtron.Text="0";
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
				ads = m_v.get_data("select ma, ten from medibv.v_maubaocao where loai=6");
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
				ads.Tables[0].Columns.Add("taivu");
				ads.Tables[0].Columns.Add("thuquy");
				ads.Tables[0].Rows.Add(new string[] {txtNguoilapbang.Text.Trim(),txtTaivu.Text.Trim(),txtThuquy.Text.Trim()});
				ads.WriteXml("...//...//option//v_optionbaocaotonghop.xml",XmlWriteMode.WriteSchema);
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
				ads.ReadXml("...//...//option//v_optionbaocaotonghop.xml");
				txtNguoilapbang.Text=txtNguoilapbang.Tag.ToString();//ads.Tables[0].Rows[0]["nguoilapbang"].ToString();
				txtTaivu.Text=ads.Tables[0].Rows[0]["taivu"].ToString();
				txtThuquy.Text=ads.Tables[0].Rows[0]["thuquy"].ToString();
			}
			catch
			{
			}
			txtTaivu.Enabled=txtTaivu.Text.Trim()=="";
			txtThuquy.Enabled=txtThuquy.Text.Trim()=="";
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
                    if (chkTonghop.Checked)
                    {
                        DataSet ads = null;
                        try
                        {
                            string sql = "", aexp = "", aexp_bh = "", auserid = "", aquyenso = "", aloaibn = "", aquyensoid="";
                            auserid = f_Get_CheckID(tree_User, 1);
                            aquyensoid = f_Get_CheckID(tree_User, 2);
                            aloaibn = f_Get_CheckID(tree_Loaibn);

                            if (m_v.sys_dungchungso)
                            {
                                auserid = f_Get_CheckID(tree_User);
                                aquyensoid = f_Get_CheckID(tree_Quyenso);
                            }

                            aexp = "to_date(to_char(a1.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('" + txtTN.Text.Trim().Substring(0, 10) + "','dd/mm/yyyy') and to_date(to_char(a1.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')<=to_date('" + txtDN.Text.Trim().Substring(0, 10) + "','dd/mm/yyyy')";
                            aexp_bh = "to_date(to_char(a1.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('" + txtTN.Text.Trim().Substring(0, 10) + "','dd/mm/yyyy') and to_date(to_char(a1.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')<=to_date('" + txtDN.Text.Trim().Substring(0, 10) + "','dd/mm/yyyy')";

                            if (auserid != "")
                            {
                                aexp += " and a1.userid in (" + auserid + ")";
                            }

                            if (aquyenso != "")
                            {
                                aexp += " and a1.quyenso in (" + aquyenso + ")";
                            }

                            if (aloaibn != "")
                            {
                                aexp += " and a1.loaibn in (" + aloaibn + ")";
                            }

                            aexp = "where " + aexp.Trim();
                            aexp_bh = "where " + aexp_bh.Trim();

                            sql = " select a1.id, to_number(0) as tructiep, to_number(0) as thu20, to_number(0) as thubhyt, to_number(0) as tre6t, to_number(0) as mienphi, to_number(0) tamung, sum(a4.soluong*a4.dongia) as sotien, a1.tamung datamung, a1.mien, a1.bhyt, a1.nopthem, a1.thieu, a1.thua, a1.chenhlech";
                            sql += " from medibvmmyy.v_ttrvll a1 inner join medibvmmyy.v_ttrvct a4 on a1.id=a4.id " + aexp + " and (a1.loaibn<>3 and to_number(a1.idtonghop)>0)";
                            sql += " group by a1.id, a1.tamung, a1.mien, a1.bhyt, a1.nopthem, a1.thieu, a1.thua, a1.chenhlech";

                            sql += " union all ";
                            sql += " select a1.id, to_number(0) as tructiep, a1.sotien-a1.bhyt as thu20, a1.bhyt as thubhyt, to_number(0) as tre6t, to_number(0) as mienphi, to_number(0) tamung, to_number(0)  as sotien, to_number(0) as  datamung, a1.mien, to_number(0) as bhyt, a1.nopthem, a1.thieu, a1.thua, a1.chenhlech";
                            sql += " from medibvmmyy.v_ttrvll a1 " + aexp + " and (a1.loaibn=3 or to_number(a1.idtonghop)<0)";
                            sql += " group by a1.id, a1.sotien, a1.tamung, a1.mien, a1.bhyt, a1.nopthem, a1.thieu, a1.thua, a1.chenhlech";

                            sql += " union all ";
                            sql += " select a1.id, sum(b.soluong*b.dongia-nvl(b.tra,0)-nvl(b.thieu,0)-decode(b.madoituong,1,nvl(b.mien,0),0))-nvl(c.sotien,0) as tructiep, ";
                            sql += " to_number(0) as thu20, to_number(0) as thubhyt, to_number(0) as tre6t, sum(decode(b.madoituong,1,nvl(b.mien,0),0))+nvl(c.sotien,0) as mienphi, to_number(0) as tamung, to_number(0) as sotien, to_number(0) as datamung, to_number(0) as mien, to_number(0) as bhyt, to_number(0) as nopthem, to_number(0) as thieu, to_number(0) as thua, to_number(0) as chenhlech ";
                            sql += " from medibvmmyy.v_vienphill a1 inner join medibvmmyy.v_vienphict b on a1.id=b.id left join medibvmmyy.v_mienngtru c on a1.id=c.id " + aexp + "";
                            sql += " group by a1.id, nvl(c.sotien,0)";

                            sql += " union all ";
                            sql += " select a1.id, to_number(0) as tructiep, ";
                            sql += " to_number(0) as thu20, to_number(0) as thubhyt, to_number(0) as tre6t, to_number(0) as mienphi, sum(a1.sotien) as tamung, to_number(0) as sotien, to_number(0) as datamung, to_number(0) as mien, to_number(0) as bhyt, to_number(0) as nopthem, to_number(0) as thieu, to_number(0) as thua, to_number(0) as chenhlech ";
                            sql += " from medibvmmyy.v_tamung a1 " + aexp + " and done=0";
                            sql += " group by a1.id";

                            sql += " union all ";
                            sql += " select a1.id, to_number(0) as tructiep, ";
                            sql += " to_number(0) as thu20, sum(decode(a1.maphu,1,b.soluong*c.giamua,0)) as thubhyt, sum(decode(a1.maphu,1,0,b.soluong*c.giamua)) as tre6t, to_number(0) as mienphi, to_number(0) as tamung, to_number(0) as sotien, to_number(0) as datamung, to_number(0) as mien, to_number(0) as bhyt, to_number(0) as nopthem, to_number(0) as thieu, to_number(0) as thua, to_number(0) as chenhlech ";
                            sql += " from medibvmmyy.bhytkb a1 inner join medibvmmyy.bhytthuoc b on a1.id=b.id inner join medibvmmyy.d_theodoi c on b.sttt=c.id " + aexp_bh + "";
                            sql += " group by a1.id";

                            sql += " union all ";
                            sql += " select a1.id, to_number(0) as tructiep, ";
                            sql += " to_number(0) as thu20, sum(decode(a1.maphu,1,b.soluong*b.dongia,0)) as thubhyt, sum(decode(a1.maphu,1,0,b.soluong*b.dongia)) as tre6t, to_number(0) as mienphi, to_number(0) as tamung, to_number(0) as sotien, to_number(0) as datamung, to_number(0) as mien, to_number(0) as bhyt, to_number(0) as nopthem, to_number(0) as thieu, to_number(0) as thua, to_number(0) as chenhlech ";
                            sql += " from medibvmmyy.bhytkb a1 inner join medibvmmyy.bhytcls b on a1.id=b.id " + aexp_bh + "";
                            sql += " group by a1.id";

                            sql += " union all ";
                            sql += " select a1.id, to_number(0) as tructiep, ";
                            sql += " to_number(0) as thu20, sum(decode(a1.maphu,1,a1.congkham,0)) as thubhyt, sum(decode(a1.maphu,1,0,a1.congkham)) as tre6t, to_number(0) as mienphi, to_number(0) as tamung, to_number(0) as sotien, to_number(0) as datamung, to_number(0) as mien, to_number(0) as bhyt, to_number(0) as nopthem, to_number(0) as thieu, to_number(0) as thua, to_number(0) as chenhlech ";
                            sql += " from medibvmmyy.bhytkb a1 " + aexp_bh + "";
                            sql += " group by a1.id";

                            sql = "select to_number(0) as id, sum(to_number(tructiep)) as tructiep, sum(to_number(thu20)) as thu20, sum(to_number(thubhyt)) as thubhyt, sum(to_number(tre6t)) as tre6t, sum(to_number(mienphi)) as mienphi, sum(to_number(tamung)) as tamung, sum(to_number(sotien)) as sotien, sum(to_number(datamung)) as datamung, sum(to_number(mien)) as mien, sum(to_number(bhyt)) as bhyt, sum(to_number(nopthem)) as nopthem, sum(to_number(thieu)) as thieu, sum(to_number(thua)) as thua, sum(to_number(chenhlech)) as chenhlech from (" + sql + ") as froo ";
                            ads = m_v.get_data_mmyy(sql, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true);

                            if (ads.Tables[0].Rows.Count==0)
                            {
                                MessageBox.Show(lan.Change_language_MessageText("Không có số liệu"), m_v.s_AppName);
                                return;
                            }

                            string asyt = "", abv = "", angayin = "", anguoiin = "", aghichu = "";

                            asyt = m_v.Syte;
                            abv = m_v.Tenbv;
                            angayin = lan.Change_language_MessageText("Ngày") + " " + txtNgayIn.Value.Day.ToString().PadLeft(2, '0') + " " + lan.Change_language_MessageText("tháng") + " " + txtNgayIn.Value.Month.ToString().PadLeft(2, '0') + " " + lan.Change_language_MessageText("năm") + " " + txtNgayIn.Value.Year.ToString();
                            anguoiin = txtNguoilapbang.Text.Trim();

                            if (rdThang.Checked)
                            {
                                aghichu = lan.Change_language_MessageText("Tháng:") + " " + txtThang.Value.ToString().PadLeft(2, '0') + " " + lan.Change_language_MessageText("Năm:") + " " + txtNam.Value.ToString();
                            }
                            else
                            {
                                aghichu = lan.Change_language_MessageText("Từ ngày:") + " " + txtTN.Text.Substring(0, 10) + " " + lan.Change_language_MessageText("Đến ngày:") + " " + txtDN.Text.Substring(0, 10);
                            }

                            if (!System.IO.Directory.Exists("..//..//Datareport//"))
                            {
                                System.IO.Directory.CreateDirectory("..//..//Datareport//");
                            }

                            ads.WriteXml("..//..//Datareport//v_2007_baocaotonghop.xml", XmlWriteMode.WriteSchema);

                            frmReport fa = new frmReport(m_v, ads.Tables[0], "v_2007_baocaotonghop.rpt", asyt.ToUpper(), abv.ToUpper(), angayin, anguoiin, aghichu, txtNguoilapbang.Text.Trim(), txtThuquy.Text.Trim(), txtTaivu.Text.Trim(), txtTCKT.Text.Trim(), "Báo cáo tổng hợp viện phí", 1, checkBox1.Checked ? true : false);
                            fa.ShowDialog();
                        }
                        catch { }
                    }
                    else
                    {
                        if (gbLoaibc.Tag.ToString() == "4")
                        {
                            f_InBK_2();
                        }
                        else
                        {
                            f_InBK_1();
                        }
                        if (txtLamtron.Visible)
                        {
                            txtLamtron_Validated(null, null);
                            f_Save_Lamtron(txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), decimal.Parse(txtLamtron.Text.Trim()));
                        }
                    }
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
					r=
lan.Change_language_MessageText("(Ngày")+" " + ad1.Day.ToString().PadLeft(2,'0') + "/" + ad1.Month.ToString().PadLeft(2,'0') + "/" +ad1.Year.ToString() + ")";
				}
				else
				{
					r=
lan.Change_language_MessageText("(Từ ngày")+" " + ad1.Day.ToString().PadLeft(2,'0') + "/" + ad1.Month.ToString().PadLeft(2,'0') + "/" +ad1.Year.ToString() + " "+
lan.Change_language_MessageText("đến ngày")+" " + ad2.Day.ToString().PadLeft(2,'0') + "/" + ad2.Month.ToString().PadLeft(2,'0') + "/" +ad2.Year.ToString() + ")";
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
					//SendKeys.Send("{Tab}");
					butInBK.Focus();
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

		private void txtTaivu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
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

		private void txtThuquy_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
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

		private void frmBaocaotonghop_SizeChanged(object sender, System.EventArgs e)
		{
		}

		private void rd_CheckedChanged(object sender, System.EventArgs e)
		{
			try
			{
				if(rd1.Checked) gbLoaibc.Tag=rd1.Tag.ToString();
				if(rd2.Checked) gbLoaibc.Tag=rd2.Tag.ToString();
				if(rd3.Checked) gbLoaibc.Tag=rd3.Tag.ToString();
				if(rd4.Checked) gbLoaibc.Tag=rd4.Tag.ToString();
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
					SendKeys.Send("{Tab}");
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

		private void chkUserid_CheckedChanged(object sender, System.EventArgs e)
		{
			f_Set_CheckID(tree_User,chkUserid.Checked);
		}
		private void panel2_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
		
		}

		private void chkLoaibn_CheckedChanged(object sender, System.EventArgs e)
		{
			f_Set_CheckID(tree_Loaibn,chkLoaibn.Checked);
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

		private void chkUserid_KeyDown_1(object sender, System.Windows.Forms.KeyEventArgs e)
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

		private void chkQuyenSo_KeyDown_1(object sender, System.Windows.Forms.KeyEventArgs e)
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

		private void chkPhatsinh_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
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

		private void frmBaocaotonghop_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			try
			{
				if(e.Alt)
				{
					lbLamtron.Visible=!lbLamtron.Visible;
					txtLamtron.Visible=!txtLamtron.Visible;
				}
			}
			catch
			{
			}
		}

		private void txtTN_ValueChanged(object sender, System.EventArgs e)
		{
			f_Load_Lamtron(txtTN.Text.Substring(0,10),txtDN.Text.Substring(0,10));
		}

		private void txtDN_ValueChanged(object sender, System.EventArgs e)
		{
			f_Load_Lamtron(txtTN.Text.Substring(0,10),txtDN.Text.Substring(0,10));
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

        private void chkTonghop_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTonghop.Checked)
            {
                chkTamung.Checked = true;
                chkBHYT.Checked = true;
                chkNoitru.Checked = true;
                chkPhongkham.Checked = true;
            }
        }
	}
}
