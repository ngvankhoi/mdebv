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
	/// Summary description for frmBaocaothanhtoanravien.
	/// </summary>
	public class frmBaocaothanhtoanravien : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private bool m_giavpbangdongiacongvattu=false;

		private string m_userid="";
		private string m_ngaythu="";

		private DataSet m_ds=new DataSet();
		private DataSet m_ds1=new DataSet();
		private DataSet m_ds2=new DataSet();
		private LibVP.AccessData m_v = LibVP.AccessData.GetImplement();

        private int i_nhomvp_thuoc = 0;
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
		private System.Windows.Forms.DateTimePicker txtNgayIn;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.RadioButton rd1;
		private System.Windows.Forms.RadioButton rd2;
		private System.Windows.Forms.CheckBox chkAll;
		private System.Windows.Forms.CheckBox chkAll1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton rd4;
		private System.Windows.Forms.RadioButton rd3;
		private System.Windows.Forms.Button butExcel;
		private System.Windows.Forms.Button butWeb;
		private System.Windows.Forms.TreeView tree_Field;
		private System.Windows.Forms.TreeView tree_Loai;
        private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.TreeView tree_Loaibn;
		private System.Windows.Forms.CheckBox chkLoaibn;
		private System.Windows.Forms.TreeView tree_User;
		private System.Windows.Forms.CheckBox chkUserid;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.ContextMenu contextMenu2;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem6;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.TextBox timso;
		private System.Windows.Forms.TreeView tree_Quyenso;
		private System.Windows.Forms.RadioButton rd5;
		private System.Windows.Forms.TreeView tree_Lydomien;
        private System.Windows.Forms.CheckBox chkLydomen;
        private Button butInchiphi;
        private CheckBox checkBox1;
        private RadioButton rd6;
        private ProgressBar progressBar1;
        private Label label4;
        private ComboBox cbMaubaocao;
        private Button button1;
        private CheckBox chkBNCungchitra;
        private TreeView tree_qgia;
        private CheckBox chkTamung;
        private TreeView tree_KhoaPhong;
        private CheckBox chkAllKhoaphong;
		private System.ComponentModel.IContainer components;

		public frmBaocaothanhtoanravien(string v_userid)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBaocaothanhtoanravien));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbTitle = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label15 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chkTamung = new System.Windows.Forms.CheckBox();
            this.tree_qgia = new System.Windows.Forms.TreeView();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cbMaubaocao = new System.Windows.Forms.ComboBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.butInchiphi = new System.Windows.Forms.Button();
            this.butWeb = new System.Windows.Forms.Button();
            this.butExcel = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.tree_Lydomien = new System.Windows.Forms.TreeView();
            this.chkLydomen = new System.Windows.Forms.CheckBox();
            this.tree_Quyenso = new System.Windows.Forms.TreeView();
            this.chkAll1 = new System.Windows.Forms.CheckBox();
            this.timso = new System.Windows.Forms.TextBox();
            this.tree_Loaibn = new System.Windows.Forms.TreeView();
            this.chkLoaibn = new System.Windows.Forms.CheckBox();
            this.tree_User = new System.Windows.Forms.TreeView();
            this.contextMenu2 = new System.Windows.Forms.ContextMenu();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.chkUserid = new System.Windows.Forms.CheckBox();
            this.tree_Field = new System.Windows.Forms.TreeView();
            this.tree_Loai = new System.Windows.Forms.TreeView();
            this.rd2 = new System.Windows.Forms.RadioButton();
            this.rd1 = new System.Windows.Forms.RadioButton();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkBNCungchitra = new System.Windows.Forms.CheckBox();
            this.rd6 = new System.Windows.Forms.RadioButton();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.rd5 = new System.Windows.Forms.RadioButton();
            this.rd4 = new System.Windows.Forms.RadioButton();
            this.rd3 = new System.Windows.Forms.RadioButton();
            this.txtTN = new System.Windows.Forms.DateTimePicker();
            this.txtNgayIn = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDN = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tree_KhoaPhong = new System.Windows.Forms.TreeView();
            this.chkAllKhoaphong = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.ForestGreen;
            this.panel1.Controls.Add(this.lbTitle);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(1);
            this.panel1.Size = new System.Drawing.Size(875, 49);
            this.panel1.TabIndex = 15;
            // 
            // lbTitle
            // 
            this.lbTitle.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbTitle.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.Color.White;
            this.lbTitle.Location = new System.Drawing.Point(71, 1);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(357, 47);
            this.lbTitle.TabIndex = 15;
            this.lbTitle.Text = "  BÁO CÁO THANH TOÁN RA VIỆN";
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(70, 47);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 63;
            this.pictureBox1.TabStop = false;
            // 
            // label15
            // 
            this.label15.Dock = System.Windows.Forms.DockStyle.Top;
            this.label15.Location = new System.Drawing.Point(3, 52);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(875, 3);
            this.label15.TabIndex = 17;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.chkAllKhoaphong);
            this.panel2.Controls.Add(this.tree_KhoaPhong);
            this.panel2.Controls.Add(this.chkTamung);
            this.panel2.Controls.Add(this.tree_qgia);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.cbMaubaocao);
            this.panel2.Controls.Add(this.progressBar1);
            this.panel2.Controls.Add(this.butInchiphi);
            this.panel2.Controls.Add(this.butWeb);
            this.panel2.Controls.Add(this.butExcel);
            this.panel2.Controls.Add(this.butKetthuc);
            this.panel2.Controls.Add(this.tree_Lydomien);
            this.panel2.Controls.Add(this.chkLydomen);
            this.panel2.Controls.Add(this.tree_Quyenso);
            this.panel2.Controls.Add(this.chkAll1);
            this.panel2.Controls.Add(this.timso);
            this.panel2.Controls.Add(this.tree_Loaibn);
            this.panel2.Controls.Add(this.chkLoaibn);
            this.panel2.Controls.Add(this.tree_User);
            this.panel2.Controls.Add(this.chkUserid);
            this.panel2.Controls.Add(this.tree_Field);
            this.panel2.Controls.Add(this.tree_Loai);
            this.panel2.Controls.Add(this.rd2);
            this.panel2.Controls.Add(this.rd1);
            this.panel2.Controls.Add(this.chkAll);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.ForeColor = System.Drawing.Color.Navy;
            this.panel2.Location = new System.Drawing.Point(3, 55);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(875, 428);
            this.panel2.TabIndex = 0;
            // 
            // chkTamung
            // 
            this.chkTamung.AutoSize = true;
            this.chkTamung.Location = new System.Drawing.Point(510, 71);
            this.chkTamung.Name = "chkTamung";
            this.chkTamung.Size = new System.Drawing.Size(86, 17);
            this.chkTamung.TabIndex = 219;
            this.chkTamung.Text = "Thu tạm ứng";
            this.chkTamung.UseVisualStyleBackColor = true;
            this.chkTamung.Visible = false;
            // 
            // tree_qgia
            // 
            this.tree_qgia.BackColor = System.Drawing.Color.White;
            this.tree_qgia.CheckBoxes = true;
            this.tree_qgia.ForeColor = System.Drawing.Color.DimGray;
            this.tree_qgia.FullRowSelect = true;
            this.tree_qgia.Location = new System.Drawing.Point(573, 290);
            this.tree_qgia.Name = "tree_qgia";
            this.tree_qgia.ShowLines = false;
            this.tree_qgia.ShowPlusMinus = false;
            this.tree_qgia.ShowRootLines = false;
            this.tree_qgia.Size = new System.Drawing.Size(140, 109);
            this.tree_qgia.TabIndex = 218;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(573, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(70, 25);
            this.button1.TabIndex = 217;
            this.button1.Text = "   &Report";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(368, 406);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 216;
            this.label4.Text = "Mẫu BC:";
            // 
            // cbMaubaocao
            // 
            this.cbMaubaocao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbMaubaocao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMaubaocao.FormattingEnabled = true;
            this.cbMaubaocao.Location = new System.Drawing.Point(422, 402);
            this.cbMaubaocao.Name = "cbMaubaocao";
            this.cbMaubaocao.Size = new System.Drawing.Size(444, 21);
            this.cbMaubaocao.TabIndex = 215;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(6, 400);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(353, 23);
            this.progressBar1.TabIndex = 214;
            // 
            // butInchiphi
            // 
            this.butInchiphi.BackColor = System.Drawing.SystemColors.Control;
            this.butInchiphi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butInchiphi.ForeColor = System.Drawing.Color.Black;
            this.butInchiphi.Image = ((System.Drawing.Image)(resources.GetObject("butInchiphi.Image")));
            this.butInchiphi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butInchiphi.Location = new System.Drawing.Point(514, 38);
            this.butInchiphi.Name = "butInchiphi";
            this.butInchiphi.Size = new System.Drawing.Size(98, 27);
            this.butInchiphi.TabIndex = 213;
            this.butInchiphi.Text = "     In chi tiết";
            this.butInchiphi.UseVisualStyleBackColor = true;
            this.butInchiphi.Click += new System.EventHandler(this.butInchiphi_Click);
            // 
            // butWeb
            // 
            this.butWeb.BackColor = System.Drawing.SystemColors.Control;
            this.butWeb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butWeb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butWeb.ForeColor = System.Drawing.Color.Navy;
            this.butWeb.Image = ((System.Drawing.Image)(resources.GetObject("butWeb.Image")));
            this.butWeb.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butWeb.Location = new System.Drawing.Point(644, 8);
            this.butWeb.Name = "butWeb";
            this.butWeb.Size = new System.Drawing.Size(70, 25);
            this.butWeb.TabIndex = 2;
            this.butWeb.Text = "    &Web";
            this.butWeb.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butWeb.UseVisualStyleBackColor = true;
            this.butWeb.Click += new System.EventHandler(this.butWeb_Click);
            // 
            // butExcel
            // 
            this.butExcel.BackColor = System.Drawing.SystemColors.Control;
            this.butExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butExcel.ForeColor = System.Drawing.Color.Navy;
            this.butExcel.Image = ((System.Drawing.Image)(resources.GetObject("butExcel.Image")));
            this.butExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butExcel.Location = new System.Drawing.Point(502, 8);
            this.butExcel.Name = "butExcel";
            this.butExcel.Size = new System.Drawing.Size(70, 25);
            this.butExcel.TabIndex = 3;
            this.butExcel.Text = "    &Excel";
            this.butExcel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butExcel.UseVisualStyleBackColor = true;
            this.butExcel.Click += new System.EventHandler(this.butInBK_Click);
            this.butExcel.Enter += new System.EventHandler(this.butExcel_Enter);
            // 
            // butKetthuc
            // 
            this.butKetthuc.BackColor = System.Drawing.SystemColors.Control;
            this.butKetthuc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butKetthuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butKetthuc.ForeColor = System.Drawing.Color.Navy;
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(617, 38);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(90, 28);
            this.butKetthuc.TabIndex = 4;
            this.butKetthuc.Text = "      &Kết thúc";
            this.butKetthuc.UseVisualStyleBackColor = true;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // tree_Lydomien
            // 
            this.tree_Lydomien.CheckBoxes = true;
            this.tree_Lydomien.ForeColor = System.Drawing.Color.DimGray;
            this.tree_Lydomien.FullRowSelect = true;
            this.tree_Lydomien.Location = new System.Drawing.Point(187, 314);
            this.tree_Lydomien.Name = "tree_Lydomien";
            this.tree_Lydomien.ShowLines = false;
            this.tree_Lydomien.ShowPlusMinus = false;
            this.tree_Lydomien.ShowRootLines = false;
            this.tree_Lydomien.Size = new System.Drawing.Size(172, 85);
            this.tree_Lydomien.Sorted = true;
            this.tree_Lydomien.TabIndex = 211;
            this.tree_Lydomien.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tree_Lydomien_AfterCheck);
            // 
            // chkLydomen
            // 
            this.chkLydomen.Location = new System.Drawing.Point(187, 297);
            this.chkLydomen.Name = "chkLydomen";
            this.chkLydomen.Size = new System.Drawing.Size(111, 17);
            this.chkLydomen.TabIndex = 212;
            this.chkLydomen.TabStop = false;
            this.chkLydomen.Text = "Lý do miễn giảm";
            this.chkLydomen.CheckedChanged += new System.EventHandler(this.chkLydomen_CheckedChanged);
            // 
            // tree_Quyenso
            // 
            this.tree_Quyenso.CheckBoxes = true;
            this.tree_Quyenso.ForeColor = System.Drawing.Color.DimGray;
            this.tree_Quyenso.FullRowSelect = true;
            this.tree_Quyenso.Location = new System.Drawing.Point(235, 109);
            this.tree_Quyenso.Name = "tree_Quyenso";
            this.tree_Quyenso.ShowLines = false;
            this.tree_Quyenso.ShowPlusMinus = false;
            this.tree_Quyenso.ShowRootLines = false;
            this.tree_Quyenso.Size = new System.Drawing.Size(124, 165);
            this.tree_Quyenso.Sorted = true;
            this.tree_Quyenso.TabIndex = 208;
            // 
            // chkAll1
            // 
            this.chkAll1.Location = new System.Drawing.Point(573, 93);
            this.chkAll1.Name = "chkAll1";
            this.chkAll1.Size = new System.Drawing.Size(117, 16);
            this.chkAll1.TabIndex = 6;
            this.chkAll1.Text = "Thông tin hiển thị";
            this.chkAll1.CheckedChanged += new System.EventHandler(this.chkAll1_CheckedChanged);
            this.chkAll1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkAll1_KeyDown);
            // 
            // timso
            // 
            this.timso.BackColor = System.Drawing.Color.White;
            this.timso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timso.Location = new System.Drawing.Point(6, 275);
            this.timso.MaxLength = 12;
            this.timso.Name = "timso";
            this.timso.Size = new System.Drawing.Size(353, 21);
            this.timso.TabIndex = 207;
            this.timso.Text = "Tìm sổ";
            this.timso.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.timso.TextChanged += new System.EventHandler(this.timso_TextChanged);
            // 
            // tree_Loaibn
            // 
            this.tree_Loaibn.CheckBoxes = true;
            this.tree_Loaibn.ForeColor = System.Drawing.Color.DimGray;
            this.tree_Loaibn.FullRowSelect = true;
            this.tree_Loaibn.Location = new System.Drawing.Point(6, 314);
            this.tree_Loaibn.Name = "tree_Loaibn";
            this.tree_Loaibn.ShowLines = false;
            this.tree_Loaibn.ShowPlusMinus = false;
            this.tree_Loaibn.ShowRootLines = false;
            this.tree_Loaibn.Size = new System.Drawing.Size(179, 85);
            this.tree_Loaibn.Sorted = true;
            this.tree_Loaibn.TabIndex = 12;
            this.tree_Loaibn.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tree_Loaibn_AfterCheck);
            // 
            // chkLoaibn
            // 
            this.chkLoaibn.Location = new System.Drawing.Point(6, 297);
            this.chkLoaibn.Name = "chkLoaibn";
            this.chkLoaibn.Size = new System.Drawing.Size(114, 17);
            this.chkLoaibn.TabIndex = 11;
            this.chkLoaibn.TabStop = false;
            this.chkLoaibn.Text = "Loại bệnh nhân";
            this.chkLoaibn.CheckedChanged += new System.EventHandler(this.chkLoaibn_CheckedChanged);
            // 
            // tree_User
            // 
            this.tree_User.CheckBoxes = true;
            this.tree_User.ContextMenu = this.contextMenu2;
            this.tree_User.ForeColor = System.Drawing.Color.DimGray;
            this.tree_User.FullRowSelect = true;
            this.tree_User.Location = new System.Drawing.Point(6, 109);
            this.tree_User.Name = "tree_User";
            this.tree_User.ShowLines = false;
            this.tree_User.ShowPlusMinus = false;
            this.tree_User.ShowRootLines = false;
            this.tree_User.Size = new System.Drawing.Size(353, 165);
            this.tree_User.Sorted = true;
            this.tree_User.TabIndex = 10;
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
            this.chkUserid.Location = new System.Drawing.Point(6, 93);
            this.chkUserid.Name = "chkUserid";
            this.chkUserid.Size = new System.Drawing.Size(186, 17);
            this.chkUserid.TabIndex = 9;
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
            this.tree_Field.Location = new System.Drawing.Point(573, 109);
            this.tree_Field.Name = "tree_Field";
            this.tree_Field.ShowLines = false;
            this.tree_Field.ShowPlusMinus = false;
            this.tree_Field.ShowRootLines = false;
            this.tree_Field.Size = new System.Drawing.Size(140, 175);
            this.tree_Field.TabIndex = 2;
            this.tree_Field.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tree_Field_AfterCheck);
            // 
            // tree_Loai
            // 
            this.tree_Loai.BackColor = System.Drawing.Color.White;
            this.tree_Loai.CheckBoxes = true;
            this.tree_Loai.ForeColor = System.Drawing.Color.DimGray;
            this.tree_Loai.FullRowSelect = true;
            this.tree_Loai.Location = new System.Drawing.Point(361, 109);
            this.tree_Loai.Name = "tree_Loai";
            this.tree_Loai.ShowLines = false;
            this.tree_Loai.ShowPlusMinus = false;
            this.tree_Loai.ShowRootLines = false;
            this.tree_Loai.Size = new System.Drawing.Size(210, 290);
            this.tree_Loai.TabIndex = 1;
            this.tree_Loai.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tree_Loai_AfterCheck);
            // 
            // rd2
            // 
            this.rd2.Location = new System.Drawing.Point(483, 92);
            this.rd2.Name = "rd2";
            this.rd2.Size = new System.Drawing.Size(92, 16);
            this.rd2.TabIndex = 5;
            this.rd2.Text = "Loại viện phí";
            this.rd2.CheckedChanged += new System.EventHandler(this.rd2_CheckedChanged);
            this.rd2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rd2_KeyDown);
            // 
            // rd1
            // 
            this.rd1.Checked = true;
            this.rd1.Location = new System.Drawing.Point(385, 92);
            this.rd1.Name = "rd1";
            this.rd1.Size = new System.Drawing.Size(97, 16);
            this.rd1.TabIndex = 4;
            this.rd1.TabStop = true;
            this.rd1.Text = "Nhóm viện phí";
            this.rd1.CheckedChanged += new System.EventHandler(this.rd1_CheckedChanged);
            this.rd1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rd1_KeyDown);
            // 
            // chkAll
            // 
            this.chkAll.Location = new System.Drawing.Point(361, 94);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(16, 14);
            this.chkAll.TabIndex = 3;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            this.chkAll.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkAll_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkBNCungchitra);
            this.groupBox1.Controls.Add(this.rd6);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.rd5);
            this.groupBox1.Controls.Add(this.rd4);
            this.groupBox1.Controls.Add(this.rd3);
            this.groupBox1.Controls.Add(this.txtTN);
            this.groupBox1.Controls.Add(this.txtNgayIn);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtDN);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(6, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(489, 88);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // chkBNCungchitra
            // 
            this.chkBNCungchitra.AutoSize = true;
            this.chkBNCungchitra.Checked = true;
            this.chkBNCungchitra.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBNCungchitra.Location = new System.Drawing.Point(374, 65);
            this.chkBNCungchitra.Name = "chkBNCungchitra";
            this.chkBNCungchitra.Size = new System.Drawing.Size(102, 17);
            this.chkBNCungchitra.TabIndex = 82;
            this.chkBNCungchitra.Text = "Xem trước khi in";
            this.chkBNCungchitra.UseVisualStyleBackColor = true;
            this.chkBNCungchitra.Visible = false;
            // 
            // rd6
            // 
            this.rd6.AutoSize = true;
            this.rd6.Location = new System.Drawing.Point(281, 46);
            this.rd6.Name = "rd6";
            this.rd6.Size = new System.Drawing.Size(86, 17);
            this.rd6.TabIndex = 81;
            this.rd6.TabStop = true;
            this.rd6.Text = "Theo tên BN";
            this.toolTip1.SetToolTip(this.rd6, "Báo cáo bệnh viện Châu Đốc");
            this.rd6.UseVisualStyleBackColor = true;
            this.rd6.CheckedChanged += new System.EventHandler(this.rd6_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(374, 47);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(102, 17);
            this.checkBox1.TabIndex = 80;
            this.checkBox1.Text = "Xem trước khi in";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.Visible = false;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // rd5
            // 
            this.rd5.Location = new System.Drawing.Point(195, 41);
            this.rd5.Name = "rd5";
            this.rd5.Size = new System.Drawing.Size(83, 27);
            this.rd5.TabIndex = 79;
            this.rd5.Text = "Theo khoa";
            this.rd5.CheckedChanged += new System.EventHandler(this.rd3_CheckedChanged);
            // 
            // rd4
            // 
            this.rd4.Location = new System.Drawing.Point(107, 41);
            this.rd4.Name = "rd4";
            this.rd4.Size = new System.Drawing.Size(83, 27);
            this.rd4.TabIndex = 5;
            this.rd4.Text = "Theo ngày";
            this.rd4.CheckedChanged += new System.EventHandler(this.rd4_CheckedChanged);
            this.rd4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rd4_KeyDown);
            // 
            // rd3
            // 
            this.rd3.Checked = true;
            this.rd3.Location = new System.Drawing.Point(8, 41);
            this.rd3.Name = "rd3";
            this.rd3.Size = new System.Drawing.Size(104, 27);
            this.rd3.TabIndex = 4;
            this.rd3.TabStop = true;
            this.rd3.Text = "Theo biên lai";
            this.rd3.CheckedChanged += new System.EventHandler(this.rd3_CheckedChanged);
            this.rd3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rd3_KeyDown);
            // 
            // txtTN
            // 
            this.txtTN.CustomFormat = "dd/MM/yyyy hh:mm";
            this.txtTN.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtTN.Location = new System.Drawing.Point(53, 13);
            this.txtTN.Name = "txtTN";
            this.txtTN.Size = new System.Drawing.Size(85, 20);
            this.txtTN.TabIndex = 0;
            this.txtTN.Validated += new System.EventHandler(this.txtTN_Validated);
            this.txtTN.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTN_KeyDown);
            // 
            // txtNgayIn
            // 
            this.txtNgayIn.CustomFormat = "dd/MM/yyyy hh:mm";
            this.txtNgayIn.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtNgayIn.Location = new System.Drawing.Point(355, 13);
            this.txtNgayIn.Name = "txtNgayIn";
            this.txtNgayIn.Size = new System.Drawing.Size(85, 20);
            this.txtNgayIn.TabIndex = 3;
            this.txtNgayIn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNgayIn_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(8, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 77;
            this.label3.Text = "Từ ngày";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(312, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Ngày in";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDN
            // 
            this.txtDN.CustomFormat = "dd/MM/yyyy hh:mm";
            this.txtDN.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtDN.Location = new System.Drawing.Point(193, 13);
            this.txtDN.Name = "txtDN";
            this.txtDN.Size = new System.Drawing.Size(85, 20);
            this.txtDN.TabIndex = 1;
            this.txtDN.Validated += new System.EventHandler(this.txtDN_Validated);
            this.txtDN.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDN_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(140, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 78;
            this.label2.Text = "Đến ngày";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label11.Location = new System.Drawing.Point(3, 483);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(875, 4);
            this.label11.TabIndex = 214;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tree_KhoaPhong
            // 
            this.tree_KhoaPhong.BackColor = System.Drawing.Color.White;
            this.tree_KhoaPhong.CheckBoxes = true;
            this.tree_KhoaPhong.ForeColor = System.Drawing.Color.DimGray;
            this.tree_KhoaPhong.FullRowSelect = true;
            this.tree_KhoaPhong.Location = new System.Drawing.Point(719, 109);
            this.tree_KhoaPhong.Name = "tree_KhoaPhong";
            this.tree_KhoaPhong.ShowLines = false;
            this.tree_KhoaPhong.ShowPlusMinus = false;
            this.tree_KhoaPhong.ShowRootLines = false;
            this.tree_KhoaPhong.Size = new System.Drawing.Size(149, 287);
            this.tree_KhoaPhong.TabIndex = 220;
            // 
            // chkAllKhoaphong
            // 
            this.chkAllKhoaphong.Checked = true;
            this.chkAllKhoaphong.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAllKhoaphong.Location = new System.Drawing.Point(719, 94);
            this.chkAllKhoaphong.Name = "chkAllKhoaphong";
            this.chkAllKhoaphong.Size = new System.Drawing.Size(16, 14);
            this.chkAllKhoaphong.TabIndex = 221;
            this.chkAllKhoaphong.CheckedChanged += new System.EventHandler(this.chkAllKhoaphong_CheckedChanged);
            // 
            // frmBaocaothanhtoanravien
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(881, 490);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.panel1);
            this.Name = "frmBaocaothanhtoanravien";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Báo cáo thanh toán ra viện";
            this.Load += new System.EventHandler(this.frmBaocaothanhtoanravien_Load);
            this.SizeChanged += new System.EventHandler(this.frmBaocaothanhtoanravien_SizeChanged);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
				this.Text=this.Text+"/"+ ads.Tables[0].Rows[0]["hoten"].ToString();
				this.Tag=ads.Tables[0].Rows[0]["hoten"].ToString();
			}
			catch
			{
				this.Tag="";
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

		private void f_Load_Tree_Field()
		{
			try
			{
				m_ds1 = new DataSet();
				m_ds1.Tables.Add("Table");
				m_ds1.Tables[0].Columns.Add("MA");
				m_ds1.Tables[0].Columns.Add("TEN");
				if(rd3.Checked)
				{
					m_ds1.Tables[0].Rows.Add(new string[] {"MABN",lan.Change_language_MessageText("Mã số BN")});
					m_ds1.Tables[0].Rows.Add(new string[] {"HOTEN",lan.Change_language_MessageText("Họ và tên bệnh nhân")});
					m_ds1.Tables[0].Rows.Add(new string[] {"NAMSINH",lan.Change_language_MessageText("Năm sinh")});
					
                    m_ds1.Tables[0].Rows.Add(new string[] {"NGAY",lan.Change_language_MessageText("Ngày thu")});
					m_ds1.Tables[0].Rows.Add(new string[] {"QUYENSO",lan.Change_language_MessageText("Quyển sổ")});
					m_ds1.Tables[0].Rows.Add(new string[] {"SOBIENLAI",lan.Change_language_MessageText("Số biên lai")});
					m_ds1.Tables[0].Rows.Add(new string[] {"SOCHUNGTU",lan.Change_language_MessageText("Số chứng từ")});
					m_ds1.Tables[0].Rows.Add(new string[] {"SOTIEN",lan.Change_language_MessageText("Tổng số tiền")});
					m_ds1.Tables[0].Rows.Add(new string[] {"BHYT",lan.Change_language_MessageText("BHYT trả")});
					m_ds1.Tables[0].Rows.Add(new string[] {"TAMUNG",lan.Change_language_MessageText("Tạm ứng")});
					m_ds1.Tables[0].Rows.Add(new string[] {"MIEN",lan.Change_language_MessageText("Miễn")});
					m_ds1.Tables[0].Rows.Add(new string[] {"THUCTHU",lan.Change_language_MessageText("Thực thu")});
					m_ds1.Tables[0].Rows.Add(new string[] {"THUCCHI",lan.Change_language_MessageText("Thực chi")});
					m_ds1.Tables[0].Rows.Add(new string[] {"LYDOMIEN",lan.Change_language_MessageText("Lý do miễn")});
					m_ds1.Tables[0].Rows.Add(new string[] {"NGUOIKYMIEN",lan.Change_language_MessageText("Nhân viên nhập miễn")});
					m_ds1.Tables[0].Rows.Add(new string[] {"GHICHU",lan.Change_language_MessageText("Ghi chú miễn")});
                    m_ds1.Tables[0].Rows.Add(new string[] { "nguoithu", lan.Change_language_MessageText("Người thu") });//khuyen 21/02/14
                    m_ds1.Tables[0].Rows.Add(new string[] { "tenkp", lan.Change_language_MessageText("Khoa") });//khuyen 21/02/14
				}
				else
				if(rd4.Checked)
				{
					m_ds1.Tables[0].Rows.Add(new string[] {"NGAY",lan.Change_language_MessageText("Ngày thu")});
					m_ds1.Tables[0].Rows.Add(new string[] {"SOHOADON",lan.Change_language_MessageText("Tổng hoá đơn")});
					m_ds1.Tables[0].Rows.Add(new string[] {"SOTIEN",lan.Change_language_MessageText("Tổng số tiền")});
					m_ds1.Tables[0].Rows.Add(new string[] {"BHYT",lan.Change_language_MessageText("Tổng BHYT")});
					m_ds1.Tables[0].Rows.Add(new string[] {"TAMUNG",lan.Change_language_MessageText("Tổng tạm ứng")});
					m_ds1.Tables[0].Rows.Add(new string[] {"MIEN",lan.Change_language_MessageText("Tổng miễn")});
					m_ds1.Tables[0].Rows.Add(new string[] {"THUCTHU",lan.Change_language_MessageText("Thực thu")});
					m_ds1.Tables[0].Rows.Add(new string[] {"THUCCHI",lan.Change_language_MessageText("Thực chi")});
				}
				else
					if(rd5.Checked)
				{
					m_ds1.Tables[0].Rows.Add(new string[] {"NGAY",lan.Change_language_MessageText("Mã KP")});
					m_ds1.Tables[0].Rows.Add(new string[] {"VIETTAT",lan.Change_language_MessageText("Khoa")});
					m_ds1.Tables[0].Rows.Add(new string[] {"TENKP",lan.Change_language_MessageText("Tên khoa")});
					m_ds1.Tables[0].Rows.Add(new string[] {"SOHOADON",lan.Change_language_MessageText("Tổng hoá đơn")});
					m_ds1.Tables[0].Rows.Add(new string[] {"SOTIEN",lan.Change_language_MessageText("Tổng số tiền")});
					m_ds1.Tables[0].Rows.Add(new string[] {"BHYT",lan.Change_language_MessageText("Tổng BHYT")});
					m_ds1.Tables[0].Rows.Add(new string[] {"TAMUNG",lan.Change_language_MessageText("Tổng tạm ứng")});
					m_ds1.Tables[0].Rows.Add(new string[] {"MIEN",lan.Change_language_MessageText("Tổng miễn")});
					m_ds1.Tables[0].Rows.Add(new string[] {"THUCTHU",lan.Change_language_MessageText("Thực thu")});
					m_ds1.Tables[0].Rows.Add(new string[] {"THUCCHI",lan.Change_language_MessageText("Thực chi")});
				}
                else if (rd6.Checked)
                {
                    m_ds1.Tables[0].Rows.Add(new string[] { "MABN", lan.Change_language_MessageText("Mã số BN") });
                    m_ds1.Tables[0].Rows.Add(new string[] { "HOTEN", lan.Change_language_MessageText("Họ và tên bệnh nhân") });
                    m_ds1.Tables[0].Rows.Add(new string[] { "NAMSINH", lan.Change_language_MessageText("Năm sinh") });
                    m_ds1.Tables[0].Rows.Add(new string[] { "DIACHI", lan.Change_language_MessageText("Địa chỉ") });
                    m_ds1.Tables[0].Rows.Add(new string[] { "TENKP", lan.Change_language_MessageText("Tên khoa phòng") });
                    m_ds1.Tables[0].Rows.Add(new string[] { "NGAY", lan.Change_language_MessageText("Ngày thu") });
                    m_ds1.Tables[0].Rows.Add(new string[] { "QUYENSO", lan.Change_language_MessageText("Quyển sổ") });
                    m_ds1.Tables[0].Rows.Add(new string[] { "SOBIENLAI", lan.Change_language_MessageText("Số biên lai") });
                    m_ds1.Tables[0].Rows.Add(new string[] { "SOCHUNGTU", lan.Change_language_MessageText("Số chứng từ") });
                    m_ds1.Tables[0].Rows.Add(new string[] { "SOTIEN", lan.Change_language_MessageText("Tổng số tiền") });
                    m_ds1.Tables[0].Rows.Add(new string[] { "BHYT", lan.Change_language_MessageText("BHYT trả") });
                    m_ds1.Tables[0].Rows.Add(new string[] { "THU20", lan.Change_language_MessageText("Thu 20%") });
                    m_ds1.Tables[0].Rows.Add(new string[] { "TAMUNG", lan.Change_language_MessageText("Tạm ứng") });
                    m_ds1.Tables[0].Rows.Add(new string[] { "MIEN", lan.Change_language_MessageText("Miễn") });
                    m_ds1.Tables[0].Rows.Add(new string[] { "THUCTHU", lan.Change_language_MessageText("Thực thu") });
                    m_ds1.Tables[0].Rows.Add(new string[] { "THUCCHI", lan.Change_language_MessageText("Thực chi") });
                    m_ds1.Tables[0].Rows.Add(new string[] { "LYDOMIEN", lan.Change_language_MessageText("Lý do miễn") });
                    m_ds1.Tables[0].Rows.Add(new string[] { "NGUOIKYMIEN", lan.Change_language_MessageText("Nhân viên nhập miễn") });
                    m_ds1.Tables[0].Rows.Add(new string[] { "GHICHU", lan.Change_language_MessageText("Ghi chú miễn") });
                    m_ds1.Tables[0].Rows.Add(new string[] { "nguoithu", lan.Change_language_MessageText("Người thu") });//khuyen 21/02/14
                }

				f_Load_Tree(tree_Field,m_ds1);
				f_Set_CheckID(tree_Field,chkAll1.Checked);
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		private void f_Load_Tree_Loai()
		{
			try
			{
                
				string asql = "select to_char(ma) as ma, ten from medibv.v_nhomvp order by stt asc";
				if(rd2.Checked)
				{
                    asql = "select to_char(id) as ma, ten from medibv.v_loaivp  order by stt asc";
				}
				m_ds =  m_v.get_data(asql);
                //DataRow r = m_ds.Tables[0].NewRow();
                //r["ma"]="0";
                //r["ten"]="Thuốc khoa dược";
                //m_ds.Tables[0].Rows.Add(r);
				f_Load_Tree(tree_Loai,m_ds);
				f_Set_CheckID(tree_Field,chkAll.Checked);
			}
			catch
			{
			}
		}
        private void f_Load_Tree_KhoaPhong()
        {
            try
            {

                string asql = "select to_char(makp) as ma,tenkp as ten from medibv.btdkp_bv order by tenkp asc";
                f_Load_Tree(tree_KhoaPhong, m_v.get_data(asql));
                f_Set_CheckID(tree_KhoaPhong, chkAllKhoaphong.Checked);
            }
            catch
            {
            }
        }
		private void f_Load_Tree_Loaibn()
		{
			try
			{
				string asql = "select to_char(id) as ma, ten from medibv.v_loaibn order by id";
				f_Load_Tree(tree_Loaibn,m_v.get_data(asql));
			}
			catch
			{
			}
		}

        private void f_Load_Tree_quocgia()
        {
            try
            {
                string asql = "select to_char(ma) as ma,vietnamese as ten from medibv.dmquocgia order by vietnamese ";
                f_Load_Tree(tree_qgia, m_v.get_data(asql));
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
					string asql = "select to_char(a.id) as ma, trim(a.sohieu)||'     ('||to_char(a.tu)||' -->'||to_char(a.den)|| ')' as ten, to_char(b.id) as mar, trim(b.hoten)||' ('||b.userid||')' as tenr from medibv.v_quyenso a left join medibv.v_dlogin b on b.id=a.userid"+aexp+" order by b.id, b.hoten";
					f_Load_Tree(tree_User,m_v.get_data(asql),false);
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
				string asql = "select to_char(id) as ma, sohieu as ten from medibv.v_quyenso where 1=1 "+aexp+" order by sohieu asc";
				f_Load_Tree(tree_Quyenso,m_v.get_data(asql));
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
				string asql = "select to_char(id) as ma, trim(hoten)||' ('||userid||')' as ten from medibv.v_dlogin ";
                if (m_v.sys_Loctheonguoidangnhap && m_v.get_data("select admin from medibv.v_dlogin where id=" + m_userid).Tables[0].Rows[0][0].ToString() == "0") asql += " where id =" + m_userid + "";
                asql += " order by hoten asc";
				f_Load_Tree(tree_User,m_v.get_data(asql));
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
		private void f_Load_Tree_Lydomien()
		{
			try
			{
				string asql = "select to_char(id) as ma, ten from medibv.v_lydomien order by ten asc";
				DataSet ads =  m_v.get_data(asql);
				f_Load_Tree(tree_Lydomien,m_v.get_data(asql));
			}
			catch
			{
			}
		}
		private void frmBaocaothanhtoanravien_Load(object sender, System.EventArgs e)
		{
			try
			{

                i_nhomvp_thuoc = m_v.iNhomvpthuoc;
				m_giavpbangdongiacongvattu=m_v.sys_dongiacongvattu;
				txtNgayIn.Value=System.DateTime.Now;
				txtTN.Value=System.DateTime.Now;
				txtDN.Value=System.DateTime.Now;
				f_Display_User();
				f_Load_Tree_Loai();
                f_Load_Tree_KhoaPhong();
				f_Load_Tree_Field();
				f_Load_Tree_Userid();
				f_Load_Tree_Loaibn();
				f_Load_Tree_Lydomien();
                f_Load_CB_Maubaocao();
                f_Load_Tree_quocgia();
                button1.Enabled = false;
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
			try
			{
				chkAll1.Checked=true;
				chkAll.Checked=true;
				chkAll1_CheckedChanged(null,null);
				chkAll_CheckedChanged(null,null);
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
                string asql = "", asql1 = "", aexp = "";
                string atmp = "";
                string aloaibn = f_Get_CheckID(tree_Loaibn);
                string aquyenso = f_Get_CheckID(tree_User, 2);
                string auserid = f_Get_CheckID(tree_User, 1);
                string alydomien = f_Get_CheckID(tree_Lydomien);
                string aQuocgia = f_Get_CheckID(tree_qgia);
                string aKhoaphong = f_Get_CheckID(tree_KhoaPhong); //khuyen 21/02/14
                string asqlht = "select * from medibvmmyy.v_hoantra where to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('" + txtTN.Text.Trim().Substring(0, 10) + "','dd/mm/yyyy') and to_date(to_char(ngay,'dd/mm/yyyy'),'dd/mm/yyyy')<=to_date('" + txtDN.Text.Trim().Substring(0, 10) + "','dd/mm/yyyy')";
                if (m_v.sys_dungchungso)
                {
                    auserid = f_Get_CheckID(tree_User);
                    aquyenso = f_Get_CheckID(tree_Quyenso);
                }
                //khuyen 21/02/14
                if (aKhoaphong != "")
                {
                    if (aexp.Length > 0)
                    {
                        aexp = aexp.Trim() + " and gg.makp in ('" + aKhoaphong.Trim(',').Replace(",", "','") + "')";
                    }
                    else
                    {
                        aexp = " gg.makp  in ('" + aKhoaphong.Trim(',').Replace(",", "','") + "')";
                    }
                }
                //
                if (aloaibn != "")
                {
                    if (aexp.Length > 0)
                    {
                        aexp = aexp.Trim() + " and a.loaibn in (" + aloaibn + ")";
                    }
                    else
                    {
                        aexp = "a.loaibn in (" + aloaibn + ")";
                    }
                }
                if (auserid != "")
                {
                    if (aexp.Length > 0)
                    {
                        aexp = aexp.Trim() + " and a.userid in (" + auserid + ")";
                    }
                    else
                    {
                        aexp = "a.userid in (" + auserid + ")";
                    }
                }
                if (aquyenso != "")
                {
                    if (aexp.Length > 0)
                    {
                        aexp = aexp.Trim() + " and a.quyenso in (" + aquyenso + ")";
                    }
                    else
                    {
                        aexp = "a.quyenso in (" + aquyenso + ")";
                    }
                }
                if (aQuocgia != "")
                {
                    if (aexp.Length > 0)
                    {
                        aexp = aexp.Trim() + " and nn.id_nuoc in ('" + aQuocgia.Trim(',').Replace(",","','") + "')";
                    }
                    else
                    {
                        aexp = "nn.id_nuoc in ('" + aQuocgia.Trim(',').Replace(",", "','") + "')";
                    }
                }
                if (chkLydomen.Checked)
                {
                    if (alydomien != "")
                    {
                        if (aexp.Length > 0)
                        {
                            aexp = aexp.Trim() + " and c.lydo in (" + alydomien + ")";
                        }
                        else
                        {
                            aexp = "c.lydo in (" + alydomien + ")";
                        }
                    }
                    else
                    {
                        if (aexp.Length > 0)
                        {
                            aexp = aexp.Trim() + " and c.id is null";
                        }
                        else
                        {
                            aexp = "c.id is null";
                        }
                    }
                }

                aexp = aexp.Trim();
                if (aexp.Length > 0)
                {
                    aexp = " and " + aexp;
                }

                DataSet ads = new DataSet();
                string atable = rd1.Checked ? "h.ma" : "g.id";
                m_ds2 = m_ds1.Clone();

                //Cac field se hien thi
                for (int i = 0; i < tree_Field.Nodes.Count; i++)
                {
                    if (tree_Field.Nodes[i].Checked)
                    {
                        try
                        {
                            m_ds2.Tables[0].Rows.Add(new string[] { tree_Field.Nodes[i].Tag.ToString().Trim(), tree_Field.Nodes[i].Text.Trim() });
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
                //

                bool ok = false;
                for (int i = 0; i < tree_Loai.Nodes.Count; i++)
                {
                    if (tree_Loai.Nodes[i].Checked)
                    {
                        ok = true;
                        break;
                    }
                }

                atmp = "";
                if (ok)
                {
                    for (int i = 0; i < tree_Loai.Nodes.Count; i++)
                    {
                        if (tree_Loai.Nodes[i].Checked)
                        {
                            try
                            {
                                //atmp = atmp + ",sum(to_number(case when " + atable + "=" + m_ds.Tables[0].Rows[i]["MA"].ToString() + " then b.soluong*b.dongia + b.soluong*b.dongia*nvl(b.vat,0)/100 - b.bhyttra else 0 end)) as LLLL" + i.ToString();
                                atmp = atmp + ",sum(to_number(case when " + atable + "=" + m_ds.Tables[0].Rows[i]["MA"].ToString() + " then b.sotien + b.sotien*nvl(b.vat,0)/100 - b.bhyttra else 0 end)) as LLLL" + i.ToString();
                                m_ds2.Tables[0].Rows.Add(new string[] { "LLLL" + i.ToString(), tree_Loai.Nodes[i].Text.Trim() });
                            }
                            catch (Exception exx)
                            {
                                MessageBox.Show(exx.ToString());
                            }
                        }
                    }
                    atmp = atmp.Trim().Trim(',');
                    atmp = atmp.Trim();
                    if (atmp.Length > 0)
                    {
                        atmp = "," + atmp.Trim(',');
                    }
                }

                //string asqldmbd = "select a1.id as id, c1.id_loai as id_loai from medibv.d_dmbd a1 left join medibv.d_dmnhom b1 on a1.manhom=b1.id left join (select a0.ma, case when b0.id is null then 0 else b0.id end as id_loai from medibv.v_nhomvp a0 left join medibv.v_loaivp b0 on a0.ma=b0.id_nhom) as c1 on b1.nhomvp=c1.ma";
                
                //string asqldmbd = " select a.id as id, b.loaivp as id_loai, b.nhomvp as id_nhom, c.stt as sttnhom, d.ten tenloai, c.ten tennhom, 0 as sotien from medibv.d_dmbd a inner join medibv.d_dmnhom b on a.manhom=b.id inner join medibv.v_loaivp d on b.loaivp=d.id inner join medibv.v_nhomvp c on d.id_nhom=c.ma  ";
                string asqldmbd = " select a.id as id, b.loaivp as id_loai from medibv.d_dmbd a inner join medibv.d_dmnhom b on a.manhom=b.id inner join medibv.v_loaivp d on b.loaivp=d.id inner join medibv.v_nhomvp c on d.id_nhom=c.ma union select id,id_loai from medibv.v_giavp  ";//Tu :15/07/2011 đang theo dõi chỗ này

                if (rd5.Checked)//Nhom theo khoa
                {
                    //khuyen 03/03/14 lay 2 lan v_giavp asql = "select gg.makp as ngay, gg.tenkp, gg.viettat, count(a.id) as sohoadon, sum(a.sotien) as sotien, sum(a.mien) as mien, sum(a.bhyt) as bhyt, sum(a.tamung) as tamung, sum(to_number(case when a.sotien-a.tamung-a.bhyt-a.mien>=0 then a.sotien-a.tamung-a.bhyt-a.mien else 0 end)) as thucthu, sum(to_number(case when a.sotien-a.tamung-a.bhyt-a.mien<0 then a.tamung-a.sotien-a.bhyt-a.mien else 0 end)) as thucchi " + atmp + " from medibvmmyy.v_ttrvds aa inner join medibvmmyy.v_ttrvll a on aa.id=a.id left join (" + asqlht + ") as aht on a.quyenso=aht.quyenso and a.sobienlai=aht.sobienlai inner join medibvmmyy.v_ttrvct b on aa.id=b.id left join medibvmmyy.v_miennoitru c on a.id=c.id left join (select id, id_loai from medibv.v_giavp union all select id, id_loai from (" + asqldmbd + ") froo ) as f on b.mavp= f.id left join (select id, id_nhom from medibv.v_loaivp union all select distinct 0 as id, 0 as id_nhom from dual) as g on f.id_loai=g.id left join (select ma from medibv.v_nhomvp union all select distinct 0 as ma from dual) as h on g.id_nhom=h.ma left join medibv.btdkp_bv gg on a.makp=gg.makp  left join medibv.nuocngoai nn on aa.mabn=nn.mabn where to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('" + txtTN.Text.Trim().Substring(0, 10) + "','dd/mm/yyyy') and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')<=to_date('" + txtDN.Text.Trim().Substring(0, 10) + "','dd/mm/yyyy') and aht.id is null " + aexp + " group by gg.makp,gg.tenkp,gg.viettat order by gg.tenkp asc";
                    asql = "select gg.makp as ngay, gg.tenkp, gg.viettat, count(a.id) as sohoadon, sum(a.sotien) as sotien, sum(a.mien) as mien, sum(a.bhyt) as bhyt, sum(a.tamung) as tamung, sum(to_number(case when a.sotien-a.tamung-a.bhyt-a.mien>=0 then a.sotien-a.tamung-a.bhyt-a.mien else 0 end)) as thucthu, sum(to_number(case when a.sotien-a.tamung-a.bhyt-a.mien<0 then a.tamung-a.sotien-a.bhyt-a.mien else 0 end)) as thucchi " + atmp + " from medibvmmyy.v_ttrvds aa inner join medibvmmyy.v_ttrvll a on aa.id=a.id left join (" + asqlht + ") as aht on a.quyenso=aht.quyenso and a.sobienlai=aht.sobienlai inner join medibvmmyy.v_ttrvct b on aa.id=b.id left join medibvmmyy.v_miennoitru c on a.id=c.id left join ( select id, id_loai from (" + asqldmbd + ") froo ) as f on b.mavp= f.id left join (select id, id_nhom from medibv.v_loaivp union all select distinct 0 as id, 0 as id_nhom from dual) as g on f.id_loai=g.id left join (select ma from medibv.v_nhomvp union all select distinct 0 as ma from dual) as h on g.id_nhom=h.ma left join medibv.btdkp_bv gg on a.makp=gg.makp  left join medibv.nuocngoai nn on aa.mabn=nn.mabn where to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('" + txtTN.Text.Trim().Substring(0, 10) + "','dd/mm/yyyy') and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')<=to_date('" + txtDN.Text.Trim().Substring(0, 10) + "','dd/mm/yyyy') and aht.id is null " + aexp + " group by gg.makp,gg.tenkp,gg.viettat order by gg.tenkp asc";
                    asql1 = "select a.id, a.quyenso as quyensoid, a.sobienlai, gg.makp as ngay,gg.tenkp,gg.viettat, d.sohieu as quyenso, d.sohieu||' - '||to_char(a.sobienlai,'0000000') as sochungtu, c.ghichu as lydomien, cc.ten as nguoikymien, aaa.mabn, aaa.hoten, aaa.namsinh, a.sotien, a.mien, a.bhyt, a.tamung, case when a.sotien-a.tamung-a.bhyt-a.mien>=0 then a.sotien-a.tamung-a.bhyt-a.mien else 0 end as thucthu, (case when a.sotien-a.tamung-a.bhyt-a.mien<0 then (a.sotien-a.tamung-a.bhyt-a.mien)*-1 else 0 end) as thucchi, e.hoten as nguoithu, e.hoten ||' ('||to_char(e.userid)||')' as userid " + atmp + " from medibv.btdbn aaa inner join medibvmmyy.v_ttrvds aa on aa.mabn=aaa.mabn inner join medibvmmyy.v_ttrvll a on aa.id=a.id left join (" + asqlht + ") as aht on a.quyenso=aht.quyenso and a.sobienlai=aht.sobienlai inner join medibvmmyy.v_ttrvct b on a.id=b.id left join medibvmmyy.v_miennoitru c on a.id=c.id left join medibv.v_dsduyet cc on c.maduyet=cc.ma left join medibv.v_quyenso d on a.quyenso=d.id left join medibv.v_dlogin e on a.userid=e.id left join (select id, id_loai from medibv.v_giavp union all select id, id_loai from (" + asqldmbd + ") froo ) as f on b.mavp= f.id left join (select id, id_nhom from medibv.v_loaivp union all select 0 as id, 0 as id_nhom from dual) as g on f.id_loai=g.id left join (select ma from medibv.v_nhomvp union all select 0 as ma from dual) as h on g.id_nhom=h.ma left join medibv.btdkp_bv gg on a.makp=gg.makp  left join medibv.nuocngoai nn on aaa.mabn=nn.mabn where to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('" + txtTN.Text.Trim().Substring(0, 10) + "','dd/mm/yyyy') and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')<=to_date('" + txtDN.Text.Trim().Substring(0, 10) + "','dd/mm/yyyy') and aht.id is null" + aexp + " group by a.id, a.quyenso, a.sobienlai, d.sohieu, aaa.mabn, aaa.hoten, aaa.namsinh, a.sotien, a.tamung, a.bhyt, a.mien, e.hoten, c.ghichu, cc.ten, e.hoten ||' ('||to_char(e.userid)||')', gg.makp,gg.tenkp,gg.viettat order by d.sohieu asc, a.sobienlai asc, gg.tenkp asc";
                }
                else
                    if (rd4.Checked)//Nhom theo ngay
                    {
                        asql = "select to_char(a.ngay,'dd/mm/yyyy') ngay, count(a.id) sohoadon, sum(nvl(a.sotien,0)) sotien, sum(nvl(a.mien,0)) mien, sum(nvl(a.bhyt,0)) bhyt, sum(nvl(a.tamung,0)) tamung, nvl(sum(case when nvl(a.sotien,0)-nvl(a.tamung,0)-nvl(a.bhyt,0)-nvl(a.mien,0)>=0 then nvl(a.sotien,0)-nvl(a.tamung,0)-nvl(a.bhyt,0)-nvl(a.mien,0) end),0) thucthu, nvl(sum(case when nvl(a.sotien,0)-nvl(a.tamung,0)-nvl(a.bhyt,0)-nvl(a.mien,0)<0 then nvl(a.tamung,0)-nvl(a.sotien,0)-nvl(a.bhyt,0)-nvl(a.mien,0) end),0) thucchi " + atmp + " from medibvmmyy.v_ttrvds aa inner join medibvmmyy.v_ttrvll a on aa.id=a.id left join (" + asqlht + ") aht on a.quyenso=aht.quyenso and a.sobienlai=aht.sobienlai inner join medibvmmyy.v_ttrvct b on a.id=b.id left join medibvmmyy.v_miennoitru c on a.id=c.id left join ( select id, id_loai from (" + asqldmbd + ") froo ) f on b.mavp=f.id left join (select id, id_nhom from medibv.v_loaivp union all select distinct 0 id, 0 id_nhom from dual) g on f.id_loai=g.id left join (select ma from medibv.v_nhomvp union all select distinct 0 ma from dual) h on g.id_nhom=h.ma  left join medibv.btdkp_bv gg on a.makp=gg.makp left join medibv.nuocngoai nn on aa.mabn=nn.mabn where to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('" + txtTN.Text.Trim().Substring(0, 10) + "','dd/mm/yyyy') and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')<=to_date('" + txtDN.Text.Trim().Substring(0, 10) + "','dd/mm/yyyy') and aht.id is null " + aexp + " group by to_char(a.ngay,'dd/mm/yyyy') order by to_char(a.ngay,'dd/mm/yyyy') asc";
                        //khuyen 03/03/14 lay 2 lan v_giavp  asql = "select to_char(a.ngay,'dd/mm/yyyy') ngay, count(a.id) sohoadon, sum(nvl(a.sotien,0)) sotien, sum(nvl(a.mien,0)) mien, sum(nvl(a.bhyt,0)) bhyt, sum(nvl(a.tamung,0)) tamung, nvl(sum(case when nvl(a.sotien,0)-nvl(a.tamung,0)-nvl(a.bhyt,0)-nvl(a.mien,0)>=0 then nvl(a.sotien,0)-nvl(a.tamung,0)-nvl(a.bhyt,0)-nvl(a.mien,0) end),0) thucthu, nvl(sum(case when nvl(a.sotien,0)-nvl(a.tamung,0)-nvl(a.bhyt,0)-nvl(a.mien,0)<0 then nvl(a.tamung,0)-nvl(a.sotien,0)-nvl(a.bhyt,0)-nvl(a.mien,0) end),0) thucchi " + atmp + " from medibvmmyy.v_ttrvds aa inner join medibvmmyy.v_ttrvll a on aa.id=a.id left join (" + asqlht + ") aht on a.quyenso=aht.quyenso and a.sobienlai=aht.sobienlai inner join medibvmmyy.v_ttrvct b on a.id=b.id left join medibvmmyy.v_miennoitru c on a.id=c.id left join ( select id, id_loai from (" + asqldmbd + ") froo ) f on b.mavp=f.id left join (select id, id_nhom from medibv.v_loaivp union all select distinct 0 id, 0 id_nhom from dual) g on f.id_loai=g.id left join (select ma from medibv.v_nhomvp union all select distinct 0 ma from dual) h on g.id_nhom=h.ma  left join medibv.nuocngoai nn on aa.mabn=nn.mabn where to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('" + txtTN.Text.Trim().Substring(0, 10) + "','dd/mm/yyyy') and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')<=to_date('" + txtDN.Text.Trim().Substring(0, 10) + "','dd/mm/yyyy') and aht.id is null " + aexp + " group by to_char(a.ngay,'dd/mm/yyyy') order by to_char(a.ngay,'dd/mm/yyyy') asc";
                        asql1 = "select to_char(a.id) id, to_char(a.quyenso) quyensoid, to_char(a.sobienlai) sobienlai, to_char(a.ngay,'dd/mm/yyyy') ngay, d.sohieu quyenso, d.sohieu||' - '||to_char(a.sobienlai) sochungtu, c.ghichu lydomien, cc.ten nguoikymien, aaa.mabn, aaa.hoten, aaa.namsinh, nvl(a.sotien,0) sotien, nvl(a.mien,0) mien, nvl(a.bhyt,0) bhyt, nvl(a.tamung,0) tamung, nvl(case when nvl(a.sotien,0)-nvl(a.tamung,0)-nvl(a.bhyt,0)-nvl(a.mien,0)>=0 then nvl(a.sotien,0)-nvl(a.tamung,0)-nvl(a.bhyt,0)-nvl(a.mien,0) end,0) thucthu, nvl(case when nvl(a.sotien,0)-nvl(a.tamung,0)-nvl(a.bhyt,0)-nvl(a.mien,0)<0 then (nvl(a.sotien,0)-nvl(a.tamung,0)-nvl(a.bhyt,0)-nvl(a.mien,0))*-1 end,0) thucchi, e.hoten nguoithu, e.hoten ||' ('||to_char(e.userid)||')' userid " + atmp + " ";
                        asql1 += " from medibv.btdbn aaa inner join medibvmmyy.v_ttrvds aa on aaa.mabn=aa.mabn inner join medibvmmyy.v_ttrvll a on aa.id=a.id left join (" + asqlht + ") aht on a.quyenso=aht.quyenso and a.sobienlai=aht.sobienlai inner join medibvmmyy.v_ttrvct b on a.id=b.id left join medibvmmyy.v_miennoitru c on a.id=c.id left join medibv.v_dsduyet cc on c.maduyet=cc.ma inner join medibv.v_quyenso d on a.quyenso=d.id inner join medibv.v_dlogin e on a.userid=e.id left join (select id, id_loai from medibv.v_giavp union all select id, id_loai from (" + asqldmbd + ") froo ) f on b.mavp=f.id left join (select id, id_nhom from medibv.v_loaivp union all select distinct 0 id, 0 id_nhom from dual) g on f.id_loai=g.id left join (select ma from medibv.v_nhomvp union all select distinct 0 as ma from dual) h on g.id_nhom=h.ma  left join medibv.nuocngoai nn on aaa.mabn=nn.mabn where to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('" + txtTN.Text.Trim().Substring(0, 10) + "','dd/mm/yyyy') and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')<=to_date('" + txtDN.Text.Trim().Substring(0, 10) + "','dd/mm/yyyy') and aht.id is null " + aexp + " group by a.id, a.quyenso, a.sobienlai, d.sohieu, aaa.mabn, aaa.hoten, aaa.namsinh, a.sotien, a.tamung, a.bhyt, a.mien, e.hoten, a.ngay, c.ghichu, cc.ten, e.hoten ||' ('||to_char(e.userid)||')' order by d.sohieu asc, a.sobienlai asc, a.ngay asc";
                    }
                    else
                        if (rd3.Checked)//Nhóm theo biên lai
                        {
                            asql = "select gg.tenkp,to_char(a.id) id, to_char(a.quyenso) quyensoid, to_char(a.sobienlai) sobienlai, to_char(a.ngay,'dd/mm/yyyy') ngay, d.sohieu quyenso, d.sohieu||' - '||to_char(a.sobienlai) sochungtu, c.ghichu, ccc.ten lydomien, cc.ten nguoikymien, aaa.mabn, aaa.hoten, aaa.namsinh, round(nvl(a.sotien,0),0) sotien, nvl(a.mien,0) mien, nvl(a.bhyt,0) bhyt, nvl(a.tamung,0) tamung, nvl(case when nvl(a.sotien,0)-nvl(a.tamung,0)-nvl(a.bhyt,0)-nvl(a.mien,0)>=0 then nvl(a.sotien,0)-nvl(a.tamung,0)-nvl(a.bhyt,0)-nvl(a.mien,0) end,0) thucthu, nvl(case when nvl(a.sotien,0)-nvl(a.tamung,0)-nvl(a.bhyt,0)-nvl(a.mien,0)<0 then (nvl(a.sotien,0)-nvl(a.tamung,0)-nvl(a.bhyt,0)-nvl(a.mien,0))*-1 end,0) thucchi, e.hoten nguoithu, e.hoten ||' ('||to_char(e.userid)||')' userid " + atmp + " ";
                            ////khuyen 03/03/14 lay 2 lan v_giavp asql += " from medibv.btdbn aaa inner join medibvmmyy.v_ttrvds aa on aaa.mabn=aa.mabn inner join medibvmmyy.v_ttrvll a on aa.id=a.id left join (" + asqlht + ") aht on a.quyenso=aht.quyenso and a.sobienlai=aht.sobienlai inner join medibvmmyy.v_ttrvct b on a.id=b.id left join medibvmmyy.v_miennoitru c on a.id=c.id left join medibv.v_dsduyet cc on c.maduyet=cc.ma left join medibv.v_lydomien ccc on c.lydo=ccc.id inner join medibv.v_quyenso d on a.quyenso=d.id inner join medibv.v_dlogin e on a.userid=e.id left join (select id, id_loai from medibv.v_giavp union all select id, id_loai from (" + asqldmbd + ") froo ) f on b.mavp=f.id left join (select id, id_nhom from medibv.v_loaivp union all select distinct 0 as id, 0 as id_nhom from dual) g on f.id_loai=g.id left join (select ma from medibv.v_nhomvp union all select distinct 0 as ma from dual) h on g.id_nhom=h.ma left join medibv.btdkp_bv gg on a.makp=gg.makp  left join medibv.nuocngoai nn on aaa.mabn=nn.mabn where to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('" + txtTN.Text.Trim().Substring(0, 10) + "','dd/mm/yyyy') and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')<=to_date('" + txtDN.Text.Trim().Substring(0, 10) + "','dd/mm/yyyy') and aht.id is null " + aexp + " group by a.id, a.quyenso, a.sobienlai, d.sohieu, aaa.mabn, aaa.hoten, aaa.namsinh, a.sotien, a.tamung, a.bhyt, a.mien, e.hoten, a.ngay, c.ghichu, cc.ten, ccc.ten, e.hoten ||' ('||to_char(e.userid)||')',gg.tenkp order by d.sohieu asc, a.sobienlai asc, a.ngay asc";
                            asql += " from medibv.btdbn aaa inner join medibvmmyy.v_ttrvds aa on aaa.mabn=aa.mabn inner join medibvmmyy.v_ttrvll a on aa.id=a.id left join (" + asqlht + ") aht on a.quyenso=aht.quyenso and a.sobienlai=aht.sobienlai inner join medibvmmyy.v_ttrvct b on a.id=b.id left join medibvmmyy.v_miennoitru c on a.id=c.id left join medibv.v_dsduyet cc on c.maduyet=cc.ma left join medibv.v_lydomien ccc on c.lydo=ccc.id inner join medibv.v_quyenso d on a.quyenso=d.id inner join medibv.v_dlogin e on a.userid=e.id left join (select id, id_loai from (" + asqldmbd + ") froo ) f on b.mavp=f.id left join (select id, id_nhom from medibv.v_loaivp union all select distinct 0 as id, 0 as id_nhom from dual) g on f.id_loai=g.id left join (select ma from medibv.v_nhomvp union all select distinct 0 as ma from dual) h on g.id_nhom=h.ma left join medibv.btdkp_bv gg on a.makp=gg.makp  left join medibv.nuocngoai nn on aaa.mabn=nn.mabn where to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('" + txtTN.Text.Trim().Substring(0, 10) + "','dd/mm/yyyy') and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')<=to_date('" + txtDN.Text.Trim().Substring(0, 10) + "','dd/mm/yyyy') and aht.id is null " + aexp + " group by a.id, a.quyenso, a.sobienlai, d.sohieu, aaa.mabn, aaa.hoten, aaa.namsinh, a.sotien, a.tamung, a.bhyt, a.mien, e.hoten, a.ngay, c.ghichu, cc.ten, ccc.ten, e.hoten ||' ('||to_char(e.userid)||')',gg.tenkp order by d.sohieu asc, a.sobienlai asc, a.ngay asc";
                        }
                        else if (rd6.Checked) // theo ten bn
                        {
                            //asql = "select to_char(a.id) id, to_char(a.quyenso) quyensoid, to_char(a.sobienlai) sobienlai, to_char(a.ngay,'dd/mm/yyyy') ngay, d.sohieu quyenso, d.sohieu||' - '||to_char(a.sobienlai) sochungtu, c.ghichu, ccc.ten lydomien, cc.ten nguoikymien, aaa.mabn, aaa.hoten, trim(aaa.sonha || ' '||aaa.thon) ||' '||xx.tenpxa ||' '|| qq.tenquan ||' '|| tt.tentt as  diachi, gg.tenkp, aaa.namsinh, nvl(a.sotien,0) sotien, nvl(a.mien,0) mien, nvl(a.bhyt,0) bhyt, sum(case when b.bhyttra<>0 then b.sotien-b.bhyttra end) as thu20, nvl(a.tamung,0) tamung, nvl(case when nvl(a.sotien,0)-nvl(a.tamung,0)-nvl(a.bhyt,0)-nvl(a.mien,0)>=0 then nvl(a.sotien,0)-nvl(a.tamung,0)-nvl(a.bhyt,0)-nvl(a.mien,0) end,0) thucthu, nvl(case when nvl(a.sotien,0)-nvl(a.tamung,0)-nvl(a.bhyt,0)-nvl(a.mien,0)<0 then (nvl(a.sotien,0)-nvl(a.tamung,0)-nvl(a.bhyt,0)-nvl(a.mien,0))*-1 end,0) thucchi, e.hoten nguoithu, e.hoten ||' ('||to_char(e.userid)||')' userid " + atmp + " ";//BN dong chi tra: chi lay doi tuong bhyt
                            asql = "select to_char(a.id) id, to_char(a.quyenso) quyensoid, to_char(a.sobienlai) sobienlai, to_char(a.ngay,'dd/mm/yyyy') ngay, d.sohieu quyenso, d.sohieu||' - '||to_char(a.sobienlai) sochungtu, c.ghichu, ccc.ten lydomien, cc.ten nguoikymien, aaa.mabn, aaa.hoten, trim(aaa.sonha || ' '||aaa.thon) ||' '||xx.tenpxa ||' '|| qq.tenquan ||' '|| tt.tentt as  diachi, gg.tenkp, aaa.namsinh, nvl(a.sotien,0) sotien, nvl(a.mien,0) mien, nvl(a.bhyt,0) bhyt,  sum(case when b.bhyttra<>0 then b.sotien-b.bhyttra end) as thu20, sum(b.sotien-b.bhyttra-b.mien) as bntra, nvl(a.tamung,0) tamung, nvl(case when nvl(a.sotien,0)-nvl(a.tamung,0)-nvl(a.bhyt,0)-nvl(a.mien,0)>=0 then nvl(a.sotien,0)-nvl(a.tamung,0)-nvl(a.bhyt,0)-nvl(a.mien,0) end,0) thucthu, nvl(case when nvl(a.sotien,0)-nvl(a.tamung,0)-nvl(a.bhyt,0)-nvl(a.mien,0)<0 then (nvl(a.sotien,0)-nvl(a.tamung,0)-nvl(a.bhyt,0)-nvl(a.mien,0))*-1 end,0) thucchi, e.hoten nguoithu, e.hoten ||' ('||to_char(e.userid)||')' userid " + atmp + " ";// bn cung chi tra: lay phan bn phai tra: thu phi+BH
                            asql += " from medibv.btdbn aaa left join medibv.btdtt tt on aaa.matt=tt.matt left join medibv.btdquan qq on aaa.maqu=qq.maqu left join medibv.btdpxa xx on aaa.maphuongxa=xx.maphuongxa inner join medibvmmyy.v_ttrvds aa on aaa.mabn=aa.mabn inner join medibvmmyy.v_ttrvll a on aa.id=a.id left join (" + asqlht + ") aht on a.quyenso=aht.quyenso and a.sobienlai=aht.sobienlai inner join medibvmmyy.v_ttrvct b on a.id=b.id left join medibvmmyy.v_miennoitru c on a.id=c.id left join medibv.v_dsduyet cc on c.maduyet=cc.ma left join medibv.v_lydomien ccc on c.lydo=ccc.id inner join medibv.v_quyenso d on a.quyenso=d.id inner join medibv.v_dlogin e on a.userid=e.id left join (select id, id_loai from (" + asqldmbd + ") froo ) f on b.mavp=f.id left join (select id, id_nhom from medibv.v_loaivp union all select distinct 0 as id, 0 as id_nhom from dual) g on f.id_loai=g.id left join (select ma from medibv.v_nhomvp union all select distinct 0 as ma from dual) h on g.id_nhom=h.ma left join medibv.btdkp_bv gg on a.makp=gg.makp  left join medibv.nuocngoai nn on aaa.mabn=nn.mabn where to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('" + txtTN.Text.Trim().Substring(0, 10) + "','dd/mm/yyyy') and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')<=to_date('" + txtDN.Text.Trim().Substring(0, 10) + "','dd/mm/yyyy') and aht.id is null " + aexp + " group by a.id, a.quyenso, a.sobienlai, d.sohieu, aaa.mabn, aaa.hoten, gg.tenkp, aaa.sonha, aaa.thon, xx.tenpxa, qq.tenquan, tt.tentt , aaa.namsinh, a.sotien, a.tamung, a.bhyt, a.mien, e.hoten, a.ngay, c.ghichu, cc.ten, ccc.ten, e.hoten ||' ('||to_char(e.userid)||')' order by d.sohieu asc, a.sobienlai asc, a.ngay asc";
                            //asql = "select to_char(a.id) id, to_char(a.quyenso) quyensoid, to_char(a.sobienlai) sobienlai, to_char(a.ngay,'dd/mm/yyyy') ngay, d.sohieu quyenso, d.sohieu||' - '||to_char(a.sobienlai) sochungtu, c.ghichu, ccc.ten lydomien, cc.ten nguoikymien, aaa.mabn, aaa.hoten, trim(aaa.sonha || ' '||aaa.thon) ||' '||xx.tenpxa ||' '|| qq.tenquan ||' '|| tt.tentt as  diachi, gg.tenkp, aaa.namsinh, nvl(a.sotien,0) sotien, nvl(a.mien,0) mien, nvl(a.bhyt,0) bhyt, nvl(a.tamung,0) tamung, nvl(case when nvl(a.sotien,0)-nvl(a.tamung,0)-nvl(a.bhyt,0)-nvl(a.mien,0)>=0 then nvl(a.sotien,0)-nvl(a.tamung,0)-nvl(a.bhyt,0)-nvl(a.mien,0) end,0) thucthu, nvl(case when nvl(a.sotien,0)-nvl(a.tamung,0)-nvl(a.bhyt,0)-nvl(a.mien,0)<0 then (nvl(a.sotien,0)-nvl(a.tamung,0)-nvl(a.bhyt,0)-nvl(a.mien,0))*-1 end,0) thucchi, e.hoten nguoithu, e.hoten ||' ('||to_char(e.userid)||')' userid " + atmp + " ";
                            //asql += " from medibv.btdbn aaa left join medibv.btdtt tt on aaa.matt=tt.matt left join medibv.btdquan qq on aaa.maqu=qq.maqu left join medibv.btdpxa xx on aaa.maphuongxa=xx.maphuongxa inner join medibvmmyy.v_ttrvds aa on aaa.mabn=aa.mabn inner join medibvmmyy.v_ttrvll a on aa.id=a.id left join (" + asqlht + ") aht on a.quyenso=aht.quyenso and a.sobienlai=aht.sobienlai inner join medibvmmyy.v_ttrvct b on a.id=b.id left join medibvmmyy.v_miennoitru c on a.id=c.id left join medibv.v_dsduyet cc on c.maduyet=cc.ma left join medibv.v_lydomien ccc on c.lydo=ccc.id inner join medibv.v_quyenso d on a.quyenso=d.id inner join medibv.v_dlogin e on a.userid=e.id left join (select id, id_loai from medibv.v_giavp union all select id, id_loai from (" + asqldmbd + ") froo ) f on b.mavp=f.id left join (select id, id_nhom from medibv.v_loaivp union all select distinct 0 as id, 0 as id_nhom from dual) g on f.id_loai=g.id left join (select ma from medibv.v_nhomvp union all select distinct 0 as ma from dual) h on g.id_nhom=h.ma left join medibv.btdkp_bv gg on a.makp=gg.makp where to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('" + txtTN.Text.Trim().Substring(0, 10) + "','dd/mm/yyyy') and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')<=to_date('" + txtDN.Text.Trim().Substring(0, 10) + "','dd/mm/yyyy') and aht.id is null " + aexp + " group by a.id, a.quyenso, a.sobienlai, d.sohieu, aaa.mabn, aaa.hoten, gg.tenkp, aaa.sonha, aaa.thon, xx.tenpxa, qq.tenquan, tt.tentt , aaa.namsinh, a.sotien, a.tamung, a.bhyt, a.mien, e.hoten, a.ngay, c.ghichu, cc.ten, ccc.ten, e.hoten ||' ('||to_char(e.userid)||')' order by d.sohieu asc, a.sobienlai asc, a.ngay asc";
                        }
                if (m_ds2.Tables[0].Rows.Count <= 0)
                {
                    progressBar1.Value = progressBar1.Maximum;
                    timer1.Enabled = false;
                    progressBar1.Value = 0;
                    MessageBox.Show(this, lan.Change_language_MessageText("Chọn thông tin báo cáo cần hiển thị"), m_v.s_AppName, MessageBoxButtons.OK);
                    return;
                }
                ads = m_v.get_data_mmyy(asql, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true);
                if (rd4.Checked || rd5.Checked)
                {
                    DataSet ads1 = new DataSet();
                    ads1 = m_v.get_data_mmyy(asql1, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true);
                    for (int i = 0; i < ads.Tables[0].Rows.Count; i++)
                    {
                        ads.Tables[0].Rows[i]["sohoadon"] = 0;
                        ads.Tables[0].Rows[i]["sotien"] = 0;
                        ads.Tables[0].Rows[i]["bhyt"] = 0;
                        ads.Tables[0].Rows[i]["tamung"] = 0;
                        ads.Tables[0].Rows[i]["mien"] = 0;
                        ads.Tables[0].Rows[i]["thucthu"] = 0;
                        ads.Tables[0].Rows[i]["thucchi"] = 0;
                        try
                        {
                            foreach (DataRow r1 in ads1.Tables[0].Select("ngay='" + ads.Tables[0].Rows[i]["ngay"].ToString() + "'"))
                            {
                                ads.Tables[0].Rows[i]["sohoadon"] = decimal.Parse(ads.Tables[0].Rows[i]["sohoadon"].ToString()) + 1;
                                ads.Tables[0].Rows[i]["sotien"] = decimal.Parse(ads.Tables[0].Rows[i]["sotien"].ToString()) + decimal.Parse(r1["sotien"].ToString());
                                ads.Tables[0].Rows[i]["bhyt"] = decimal.Parse(ads.Tables[0].Rows[i]["bhyt"].ToString()) + decimal.Parse(r1["bhyt"].ToString());
                                ads.Tables[0].Rows[i]["tamung"] = decimal.Parse(ads.Tables[0].Rows[i]["tamung"].ToString()) + decimal.Parse(r1["tamung"].ToString());
                                ads.Tables[0].Rows[i]["mien"] = decimal.Parse(ads.Tables[0].Rows[i]["mien"].ToString()) + decimal.Parse(r1["mien"].ToString());
                                ads.Tables[0].Rows[i]["thucthu"] = decimal.Parse(ads.Tables[0].Rows[i]["thucthu"].ToString()) + decimal.Parse(r1["thucthu"].ToString());
                                ads.Tables[0].Rows[i]["thucchi"] = decimal.Parse(ads.Tables[0].Rows[i]["thucchi"].ToString()) + decimal.Parse(r1["thucchi"].ToString());
                            }
                        }
                        catch
                        {
                        }
                    }
                }
                //
                ads.Tables[0].Columns.Add("tamungtrongngay", typeof(decimal)).DefaultValue = 0;
                if (chkTamung.Checked)
                {
                    aexp = "";
                    if (m_v.sys_dungchungso)
                    {
                        auserid = f_Get_CheckID(tree_User);
                        aquyenso = f_Get_CheckID(tree_Quyenso);
                    }

                    if (aloaibn != "")
                    {
                        if (aexp.Length > 0)
                        {
                            aexp = aexp.Trim() + " and a.loaibn in (" + aloaibn + ")";
                        }
                        else
                        {
                            aexp = "a.loaibn in (" + aloaibn + ")";
                        }
                    }
                    if (auserid != "")
                    {
                        if (aexp.Length > 0)
                        {
                            aexp = aexp.Trim() + " and a.userid in (" + auserid + ")";
                        }
                        else
                        {
                            aexp = "a.userid in (" + auserid + ")";
                        }
                    }
                    if (aquyenso != "")
                    {
                        if (aexp.Length > 0)
                        {
                            aexp = aexp.Trim() + " and a.quyenso in (" + aquyenso + ")";
                        }
                        else
                        {
                            aexp = "a.quyenso in (" + aquyenso + ")";
                        }
                    }

                    //phan tam ung cua BN
                    asql1 = "select a.quyenso, a.sobienlai, a.mabn from medibvmmyy.v_hoantra a ";
                    asql1 += " where to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy')";
                    asql1 += (aexp == "") ? "" : (" and " + aexp);
                    DataSet lds_ht = m_v.get_data_mmyy(asql1, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true); 
                    //
                    asql="select a.id, a.mabn, b.hoten, to_char(a.quyenso) quyensoid, to_char(a.sobienlai) sobienlai, to_char(a.ngay,'dd/mm/yyyy') ngay, c.sohieu quyenso, c.sohieu||' - '||to_char(a.sobienlai) sochungtu, a.sotien, d.hoten||' ('||d.userid||')' as userid, d.hoten as nguoithu ";
                    asql += " from medibvmmyy.v_tamung a inner join medibv.btdbn b on a.mabn=b.mabn inner join medibv.v_quyenso c on a.quyenso=c.id ";
                    asql += " inner join medibv.v_dlogin d on a.userid=d.id ";
                    asql += " where to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy')";
                    asql += (aexp == "") ? "" : (" and " + aexp);
                    //asql += " and a.quyenso||'-'||a.sobienlai||'-'||a.mabn not in (" + asql1 + ")";
                    DataSet lds1 = m_v.get_data_mmyy(asql, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true);                    
                    foreach (DataRow dr1 in lds1.Tables[0].Rows)
                    {
                        DataRow[] adr = lds_ht.Tables[0].Select("quyenso=" + dr1["quyensoid"].ToString() + " and sobienlai=" + dr1["sobienlai"].ToString() + " and mabn='" + dr1["mabn"].ToString() + "'");
                        if (adr.Length == 0)
                        {
                            DataRow dr2 = ads.Tables[0].NewRow();
                            dr2["id"] = dr1["id"].ToString();
                            dr2["quyensoid"] = dr1["quyensoid"].ToString();
                            dr2["quyenso"] = dr1["quyenso"].ToString();
                            dr2["sobienlai"] = dr1["sobienlai"].ToString();
                            dr2["ngay"] = dr1["ngay"].ToString();
                            dr2["sochungtu"] = dr1["sochungtu"].ToString();
                            dr2["mabn"] = dr1["mabn"].ToString();
                            dr2["hoten"] = dr1["hoten"].ToString();
                            dr2["tamungtrongngay"] = dr1["sotien"].ToString();
                            dr2["nguoithu"] = dr1["nguoithu"].ToString();
                            dr2["userid"] = dr1["userid"].ToString();
                            ads.Tables[0].Rows.Add(dr2);
                        }
                    }
                }
                //
                if (ads.Tables[0].Rows.Count <= 0)
                {
                    progressBar1.Value = progressBar1.Maximum;
                    timer1.Enabled = false;
                    progressBar1.Value = 0;
                    MessageBox.Show(this, lan.Change_language_MessageText("Không có số liệu báo cáo"), m_v.s_AppName, MessageBoxButtons.OK);
                    return;
                }
                DataRow r = ads.Tables[0].NewRow();
                for (int i = 0; i < ads.Tables[0].Columns.Count; i++)
                {
                    if (ads.Tables[0].Columns[i].DataType.ToString() == "System.Decimal")
                    {
                        r[i] = "0";
                    }
                }

                for (int i = 0; i < ads.Tables[0].Rows.Count; i++)
                {
                    for (int j = 0; j < ads.Tables[0].Columns.Count; j++)
                    {
                        if (ads.Tables[0].Columns[j].DataType.ToString() == "System.Decimal")
                        {
                            try
                            {
                                r[j] = decimal.Parse(r[j].ToString()) + decimal.Parse(ads.Tables[0].Rows[i][j].ToString());
                            }
                            catch
                            {
                                r[j] = 0;
                            }
                        }
                    }
                }
                if (!rd6.Checked)
                {
                    try
                    {
                        r["mabn"] =     lan.Change_language_MessageText("Tổng:") + " " + ads.Tables[0].Rows.Count.ToString();
                    }
                    catch
                    {
                        try
                        {
                            r["ngay"] = "Tổng: " + ads.Tables[0].Rows.Count.ToString();
                        }
                        catch
                        {
                        }
                    }
                    ads.Tables[0].Rows.Add(r);
                }
                try
                {
                    if (!System.IO.Directory.Exists("..//..//Export"))
                    {
                        System.IO.Directory.CreateDirectory("..//..//Export");
                    }
                }
                catch
                {
                }
                string apath = Application.ExecutablePath;
                apath = apath.Substring(0, apath.LastIndexOf("\\"));
                apath = apath.Substring(0, apath.LastIndexOf("\\"));
                apath = apath.Substring(0, apath.LastIndexOf("\\"));
                apath = apath.Replace("\\", "//");


                switch (v_format)
                {
                    case "HTML":
                        f_Export_HTML(ads, m_ds2, apath + "//Export//baocaothanhtoanravien");
                        break;
                    case "Report":
                        string areport = "", asyt = "", abv = "", angayin = "", s_bc = "";
                        asyt = m_v.Syte;
                        abv = m_v.Tenbv;
                        angayin = lan.Change_language_MessageText("Ngày") + " " + txtNgayIn.Value.Day.ToString().PadLeft(2, '0') + " " + lan.Change_language_MessageText("tháng") + " " + txtNgayIn.Value.Month.ToString().PadLeft(2, '0') + " " + lan.Change_language_MessageText("năm") + " " + txtNgayIn.Value.Year.ToString();
                        s_bc = lan.Change_language_MessageText("Từ ngày: ") + " " + txtTN.Text.Substring(0, 10) + " " + lan.Change_language_MessageText("đến ngày: ") + txtDN.Text.Substring(0, 10);
                        if (rd1.Checked)
                            areport = "rptDS_TTRV_noitru.rpt";
                        else if (rd2.Checked) areport = "rptDS_TTRV_noitru_loaiVP.rpt";
                        if (cbMaubaocao.SelectedIndex > 0)
                        {
                            string s_report = cbMaubaocao.SelectedValue.ToString();
                            if (File.Exists("..\\..\\..\\report\\" + s_report.Replace(".rpt","")+".rpt") == true) areport = s_report;
                        }

                        ads.WriteXml("..\\..\\datareport\\" + areport.Replace(".rpt", "") + ".xml", XmlWriteMode.WriteSchema);
                        frmReport fa = new frmReport(m_v, ads.Tables[0], areport, asyt.ToUpper(), abv.ToUpper(), angayin, "", s_bc, "", "", "", "", "", 1, checkBox1.Checked ? true : false);
                        fa.ShowDialog();
                        break;
                    default:
                        f_Export_Excel(ads, m_ds2, apath + "//Export//baocaothanhtoanravien");
                        break;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

		private void f_Export_Excel(DataSet v_ds1, DataSet v_ds2, string v_filepath)
		{
			v_filepath=v_filepath+".xls";
			try
			{
				int n=0, n1=0;
				string t="";
				if(rd3.Checked)
				{
					t=" "+lan.Change_language_MessageText("THEO HOÁ ĐƠN");
				}
				else if (rd4.Checked)
				{
					t=" "+lan.Change_language_MessageText("THEO NGÀY");
				}
				else if(rd5.Checked)
				{
					t=" "+lan.Change_language_MessageText("THEO HOA PHÒNG");
				}
				t="";

				for(int i=0;i<v_ds2.Tables[0].Rows.Count;i++)
				{
					n+=v_ds2.Tables[0].Rows[i]["MA"].ToString().IndexOf("LLLL")==0?1:0;
				}

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
				astr=astr + lan.Change_language_MessageText("BÁO CÁO THU CHI THANH TOÁN RA VIỆN")+" "+ t;
				astr=astr + "</th>";
				astr=astr + "</tr>";
				
				astr=astr + "<tr>";
				astr=astr + "<th align=center style=\"font-family: Arial; font-size: 10pt; font-weight: bold\" colspan="+v_ds2.Tables[0].Rows.Count.ToString()+">";
				astr=astr + lan.Change_language_MessageText("(Từ ngày")+" "+ txtTN.Text.Substring(0,10) + " "+lan.Change_language_MessageText("Đến ngày")+" " + txtDN.Text.Substring(0,10)+")";
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
				
				if((n<m_ds2.Tables[0].Rows.Count)&&(n>0))
				{
					astr=astr + "<tr>";
					for(int i=0;i<v_ds2.Tables[0].Rows.Count;i++)
					{
						if(v_ds2.Tables[0].Rows[i]["MA"].ToString().IndexOf("LLLL")==0)
						{
						}
						else
						{
							astr=astr + "<th rowspan=2>";
							astr=astr + v_ds2.Tables[0].Rows[i]["TEN"].ToString();
							astr=astr + "</th>";
						}
					}
					astr=astr + "<th colspan="+n.ToString()+">";
					astr=astr + lan.Change_language_MessageText("THÔNG TIN CHI TIẾT");
					astr=astr + "</th>";

					astr=astr + "</tr>";

					astr=astr + "<tr>";
					for(int i=0;i<v_ds2.Tables[0].Rows.Count;i++)
					{
						if(v_ds2.Tables[0].Rows[i]["MA"].ToString().IndexOf("LLLL")==0)
						{
							astr=astr + "<th>";
							astr=astr + v_ds2.Tables[0].Rows[i]["TEN"].ToString();
							astr=astr + "</th>";
						}
					}
					astr=astr + "</tr>";
				}
				else
				{
					astr=astr + "<tr>";
					for(int i=0;i<v_ds2.Tables[0].Rows.Count;i++)
					{
						n1=(v_ds2.Tables[0].Rows[i]["MA"].ToString().IndexOf("LLLL")==0)?1:2;
						astr=astr + "<th>";
						astr=astr + v_ds2.Tables[0].Rows[i]["TEN"].ToString();
						astr=astr + "</th>";
					}
					astr=astr + "</tr>";
				}
				//Them dong so thu tu
				astr=astr + "<tr>";
				for(int i=0;i<v_ds2.Tables[0].Rows.Count;i++)
				{
					astr=astr + "<th>";
					astr=astr + (i+1).ToString();
					astr=astr + "</th>";
				}
				//
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
				astr=astr + this.Tag.ToString().Trim()+"                 ";
				astr=astr + "</th>";
				astr=astr + "</tr>";
				astr=astr + "</Table>";
				sw.Write(astr);
				sw.Close();
				//System.IO.File.Copy(v_filepath,v_filepath+".html",true);
				//MessageBox.Show(lan.Change_language_MessageText("OK");
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
				int n=0, n1=0;
				string t=rd3.Checked?" "+
lan.Change_language_MessageText("THEO HOÁ ĐƠN"):" "+
lan.Change_language_MessageText("THEO NGÀY");
				for(int i=0;i<v_ds2.Tables[0].Rows.Count;i++)
				{
					n+=v_ds2.Tables[0].Rows[i]["MA"].ToString().IndexOf("LLLL")==0?1:0;
				}

				System.IO.StreamWriter sw  =  new System.IO.StreamWriter(v_filepath,false,System.Text.Encoding.UTF8);
				string astr="";
				
				astr=astr + "<html>";
				astr=astr + "<head>";
				astr=astr + "<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\">";
				astr=astr + 
lan.Change_language_MessageText("<title>Báo cáo thu chi thanh toán ra viện</title>");
				astr=astr + "</head>";

				astr=astr + "<body>";

				astr=astr + "<Table border=0>";

				astr=astr + "<tr>";
				astr=astr + "<th align=left colspan="+v_ds2.Tables[0].Rows.Count.ToString()+">";
				astr=astr + "&nbsp; " + m_v.Syte;
				astr=astr + "</th>";
				astr=astr + "</tr>";
				
				astr=astr + "<tr>";
				astr=astr + "<th align=left colspan="+v_ds2.Tables[0].Rows.Count.ToString()+">";
				astr=astr + "&nbsp; " + m_v.Tenbv;
				astr=astr + "</th>";
				astr=astr + "</tr>";

				astr=astr + "<tr>";
				astr=astr + "<th height=40 align=center style=\"font-family: Arial; font-size: 14pt; font-weight: bold\" colspan="+v_ds2.Tables[0].Rows.Count.ToString()+">";
				astr=astr + 
lan.Change_language_MessageText("BÁO CÁO THU CHI THANH TOÁN RA VIỆN")+" "+ t;
				astr=astr + "</th>";
				astr=astr + "</tr>";
				
				astr=astr + "<tr>";
				astr=astr + "<th align=center style=\"font-family: Arial; font-size: 10pt; font-weight: bold\" colspan="+v_ds2.Tables[0].Rows.Count.ToString()+">";
				astr=astr + 
lan.Change_language_MessageText("(Từ ngày")+" "+ txtTN.Text.Substring(0,10) + " "+
lan.Change_language_MessageText("Đến ngày")+" " + txtDN.Text.Substring(0,10)+")";
				astr=astr + "</th>";
				astr=astr + "</tr>";

				astr=astr + "<tr>";
				astr=astr + "<th align=left colspan="+v_ds2.Tables[0].Rows.Count.ToString()+">";
				astr=astr + "&nbsp; ";
				astr=astr + "</th>";
				astr=astr + "</tr>";

				astr=astr+"</Table>";
				sw.Write(astr);

				astr="<Table border=1 style=\"font-family: Arial; font-size: 10pt; font-weight: normal\">";
				
				if((n<m_ds2.Tables[0].Rows.Count)&&(n>0))
				{
					astr=astr + "<tr>";
					for(int i=0;i<v_ds2.Tables[0].Rows.Count;i++)
					{
						if(v_ds2.Tables[0].Rows[i]["MA"].ToString().IndexOf("LLLL")==0)
						{
						}
						else
						{
							astr=astr + "<th rowspan=2>";
							astr=astr + "&nbsp; " + v_ds2.Tables[0].Rows[i]["TEN"].ToString();
							astr=astr + "</th>";
						}
					}
					astr=astr + "<th colspan="+n.ToString()+">";
					astr=astr + 
lan.Change_language_MessageText("THÔNG TIN CHI TIẾT")+" ";
					astr=astr + "</th>";

					astr=astr + "</tr>";

					astr=astr + "<tr>";
					for(int i=0;i<v_ds2.Tables[0].Rows.Count;i++)
					{
						if(v_ds2.Tables[0].Rows[i]["MA"].ToString().IndexOf("LLLL")==0)
						{
							astr=astr + "<th>";
							astr=astr + "&nbsp; " + v_ds2.Tables[0].Rows[i]["TEN"].ToString();
							astr=astr + "</th>";
						}
					}
					astr=astr + "</tr>";
				}
				else
				{
					astr=astr + "<tr>";
					for(int i=0;i<v_ds2.Tables[0].Rows.Count;i++)
					{
						n1=(v_ds2.Tables[0].Rows[i]["MA"].ToString().IndexOf("LLLL")==0)?1:2;
						astr=astr + "<th>";
						astr=astr + "&nbsp; " + v_ds2.Tables[0].Rows[i]["TEN"].ToString();
						astr=astr + "</th>";
					}
					astr=astr + "</tr>";
				}
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
									astr=astr + "&nbsp; " + at;
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
									astr=astr + "&nbsp; " + v_ds1.Tables[0].Rows[i][k].ToString();
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
				astr=astr + this.Tag.ToString().Trim()+"                 ";
				astr=astr + "</th>";
				astr=astr + "</tr>";
				astr=astr + "</Table>";
				astr=astr + "</body>";
				astr=astr + "</html>";
				sw.Write(astr);
				sw.Close();
				//MessageBox.Show(v_filepath);
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
				return 
lan.Change_language_MessageText("Ngày")+" " + v_ngay.Substring(0,2) + " "+
lan.Change_language_MessageText("tháng")+" " + v_ngay.Substring(3,2) + " "+
lan.Change_language_MessageText("năm")+" " + v_ngay.Substring(6);
			}
			catch
			{
				return "";
			}
		}
		private void butInBK_Click(object sender, System.EventArgs e)
		{	
			string atmp=System.Environment.CurrentDirectory;
			try
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
		private void chkAll_CheckedChanged(object sender, System.EventArgs e)
		{
			f_Set_CheckID(tree_Loai,chkAll.Checked);
		}

		private void rd2_CheckedChanged(object sender, System.EventArgs e)
		{
			f_Load_Tree_Loai();
            f_Set_CheckID(tree_Loai, chkAll.Checked);
		}

		private void rd1_CheckedChanged(object sender, System.EventArgs e)
		{
			f_Load_Tree_Loai();
            f_Set_CheckID(tree_Loai, chkAll.Checked);

		}

		private void chkAll1_CheckedChanged(object sender, System.EventArgs e)
		{
			f_Set_CheckID(tree_Field,chkAll1.Checked);
		}

		private void rd3_CheckedChanged(object sender, System.EventArgs e)
		{
			f_Load_Tree_Field();
            //button1.Enabled = false;
            //En_txt(true);
		}

		private void rd4_CheckedChanged(object sender, System.EventArgs e)
		{
			f_Load_Tree_Field();
            button1.Enabled = false;
            //En_txt(true);
		}

		private void butWeb_Click(object sender, System.EventArgs e)
		{
			f_Ketxuat("HTML");
		}

		private void butExcel_Enter(object sender, System.EventArgs e)
		{
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

		private void chkLoai_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
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

		private void chkField_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
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

		private void button1_Click(object sender, System.EventArgs e)
		{
		}

		private void frmBaocaothanhtoanravien_SizeChanged(object sender, System.EventArgs e)
		{
		}

		private void tree_Loai_AfterCheck(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			try
			{
				e.Node.ForeColor=e.Node.Checked?Color.Navy:Color.DimGray;
				for(int i=0;i<tree_Loai.Nodes.Count;i++)
				{
					if(tree_Loai.Nodes[i].Checked)
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

		private void chkLoaibn_CheckedChanged(object sender, System.EventArgs e)
		{
			f_Set_CheckID(tree_Loaibn,chkLoaibn.Checked);
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

        private void chkLydomen_CheckedChanged(object sender, EventArgs e)
        {
            f_Set_CheckID(tree_Lydomien, chkLydomen.Checked);
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
                chkLydomen.Checked = false;
            }
            catch
            {
            }
        }

   

        private void butInchiphi_Click(object sender, EventArgs e)
        {
            if (rd6.Checked)
            {
                f_Xem_TTRV();
            }
            if (checkBox1.Checked)
            {
                f_chitiet();
            }
        }

        private void f_chitiet()
        {
            string aexp = "";
            string aloaibn = f_Get_CheckID(tree_Loaibn);
            string aquyenso = f_Get_CheckID(tree_User, 2);
            string auserid = f_Get_CheckID(tree_User, 1);
            try
            {
                if (aloaibn != "")
                {
                    if (aexp.Length > 0)
                    {
                        aexp = aexp.Trim() + " and f.loaibn in (" + aloaibn + ")";
                    }
                    else
                    {
                        aexp = "f.loaibn in (" + aloaibn + ")";
                    }
                }
                if (auserid != "")
                {
                    if (aexp.Length > 0)
                    {
                        aexp = aexp.Trim() + " and f.userid in (" + auserid + ")";
                    }
                    else
                    {
                        aexp = " f.userid in (" + auserid + ")";
                    }
                }
                if (aquyenso != "")
                {
                    if (aexp.Length > 0)
                    {
                        aexp = aexp.Trim() + " and f.quyenso in (" + aquyenso + ")";
                    }
                    else
                    {
                        aexp = "f.quyenso in (" + aquyenso + ")";
                    }
                }
                //if (chkLydomen.Checked)
                //{
                //    if (alydomien != "")
                //    {
                //        if (aexp.Length > 0)
                //        {
                //            aexp = aexp.Trim() + " and c.lydo in (" + alydomien + ")";
                //        }
                //        else
                //        {
                //            aexp = "c.lydo in (" + alydomien + ")";
                //        }
                //    }
                //    else
                //    {
                //        if (aexp.Length > 0)
                //        {
                //            aexp = aexp.Trim() + " and c.id is null";
                //        }
                //        else
                //        {
                //            aexp = "c.id is null";
                //        }
                //    }
                //}

                aexp = aexp.Trim();
                if (aexp.Length > 0)
                {
                    aexp = " and " + aexp;
                }

                string asql = "";
                DataSet ads1 = new DataSet();
                asql = "select c.mabn,e.hoten,namsinh,tenkp,a.makp,a.madoituong,a.mavp,b.ma,b.ten,manhom,dang,sum(a.soluong) as soluong,a.dongia,sum(a.soluong*a.dongia-a.tra) as sotien, g.ten as mota ";
                asql += " from medibvmmyy.v_ttrvct a, medibv.d_dmbd b,medibvmmyy.v_ttrvds c,medibv.btdkp_bv d,medibv.btdbn e,medibvmmyy.v_ttrvll f, medibv.d_dmnhom g where a.mavp=b.id and a.id=c.id and a.makp=d.makp and e.mabn=c.mabn and f.id=c.id and b.manhom=g.id";
                asql += " and to_date(to_char(f.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + txtTN.Text.Trim().Substring(0, 10) + "','dd/mm/yyyy') and to_date('" + txtDN.Text.Trim().Substring(0, 10) + "','dd/mm/yyyy')" + aexp + "";
                asql += " group by c.mabn,e.hoten,namsinh,tenkp,a.makp,a.madoituong,a.mavp,dang,a.dongia,b.ma,b.ten,manhom,g.ten";

                ads1 = m_v.get_data_mmyy(asql, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), true);

                if (ads1.Tables[0].Rows.Count <= 0)
                {
                    MessageBox.Show(this, lan.Change_language_MessageText("Không có số liệu!"), m_v.s_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
    
                string areport = "v_2007_baocaochitiet_noitru.rpt", asyt = "", abv = "", angayin = "", anguoiin = "", aghichu = "";
                

                asyt = m_v.Syte;
                abv = m_v.Tenbv;
                string s_title = "";
                s_title = "Từ ngày " + txtTN.Text.Substring(0, 10).ToString() + " đến ngày " + txtDN.Text.Substring(0, 10).ToString();
                if (txtTN.Text == txtDN.Text) s_title = "Ngày " + txtTN.Text.Substring(0, 10).ToString();
                angayin = lan.Change_language_MessageText("Ngày :") + " " + txtNgayIn.Value.Day.ToString().PadLeft(2, '0') + " " + lan.Change_language_MessageText("tháng") + " " + txtNgayIn.Value.Month.ToString().PadLeft(2, '0') + " " + lan.Change_language_MessageText("năm") + " " + txtNgayIn.Value.Year.ToString();
                //ads1.WriteXml("c:/thuhs.xml",XmlWriteMode.WriteSchema);
                frmReport fa = new frmReport(m_v, ads1.Tables[0], areport, asyt.ToUpper(), abv.ToUpper(), angayin, anguoiin, aghichu, s_title, "", "", "", "Báo cáo chi tiết thuốc và vật tư của bệnh nhân nội trú.", 1, checkBox1.Checked ? true : false);
                fa.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //if (checkBox1.Checked)
            //{
            //    butInchiphi.Visible = true;
            //}
            //else
            //{
            //    butInchiphi.Visible = false;
            //}
        }

        private DataSet f_Get_Data()
        {
            DataSet ads = null;
            try
            {
                string asql = "", aexp = "", auserid = "", aquyenso = "", aloaibn = "";
                             
                aloaibn=f_Get_CheckID(tree_Loaibn);
				aquyenso=f_Get_CheckID(tree_User,2);
				auserid=f_Get_CheckID(tree_User,1);
                
                aexp = "to_date(to_char(a1.ngay,'dd/mm/yyyy'),'dd/mm/yyyy')>=to_date('" + txtTN.Text.Substring(0, 10) + "','dd/mm/yyyy') and to_date(to_char(a1.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') <= to_date('" + txtDN.Text.Substring(0, 10) + "','dd/mm/yyyy')";
                
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
                asql = "select a.id, a.mabn, a.mavaovien, a.maql, a1.loai, hs.ten as ten_loaivp, a1.loaibn, to_char(a.ngayvao,'dd/mm/yyyy') as ngayvao, to_char(a.ngayra,'dd/mm/yyyy') as ngayra, b.hoten, case when b.ngaysinh is null then b.namsinh else to_char(b.ngaysinh,'dd/mm/yyyy') end as namsinh, trim(b.sonha || ' '||b.thon) as diachi, c.tentt, c1.tenquan, c2.tenpxa, c4.makp, c4.tenkp, c4.viettat, to_char(a1.ngay,'dd/mm/yyyy') as ngay,case when gvp.id_loai=25 then sum(a4.soluong*a4.dongia) else 0 end as thuoc,case when gvp.id_loai<>25 then sum(a4.soluong*a4.dongia-a4.tra) else 0 end as vienphi, sum(a4.soluong*a4.dongia) as sotien, a1.tamung, a1.mien, a1.bhyt, a1.nopthem, a1.thieu, a1.thua, a1.chenhlech, d.hoten as user_hoten, d.userid as user_username,a1.userid, a1.quyenso, a1.sobienlai, e.sohieu, e.sohieubl, to_number(0,'9') as hoan,sum(a4.tra) as tra";
                asql += " from medibvmmyy.v_ttrvds a left join medibvmmyy.v_ttrvll a1 on a.id=a1.id inner join medibvmmyy.v_ttrvct a4 on a1.id=a4.id left join medibv.v_giavp gvp on a4.mavp=gvp.id left join medibv.btdbn b on a.mabn=b.mabn left join medibv.btdtt c on b.matt=c.matt left join medibv.btdquan c1 on b.maqu=c1.maqu left join medibv.btdpxa c2 on b.maphuongxa=c2.maphuongxa left join medibv.btdkp_bv c4 on a1.makp=c4.makp left join medibv.v_dlogin d on a1.userid=d.id left join medibv.v_quyenso e on a1.quyenso=e.id inner join medibv.v_tenloaivp hs on a1.loai=hs.ma " + aexp + "";
                asql += " group by a.id,a.mabn,a.mavaovien,a.maql,a1.loai,hs.ten,a1.loaibn,to_char(a.ngayvao,'dd/mm/yyyy') ,to_char(a.ngayra,'dd/mm/yyyy'),b.hoten,case when b.ngaysinh is null then b.namsinh else to_char(b.ngaysinh,'dd/mm/yyyy') end , trim(b.sonha || ' '||b.thon) ,c.tentt, c1.tenquan, c2.tenpxa, c4.makp,c4.tenkp, c4.viettat, to_char(a1.ngay,'dd/mm/yyyy') , a1.sotien, a1.tamung, a1.mien, a1.bhyt, a1.nopthem, a1.thieu, a1.thua, a1.chenhlech, d.hoten , d.userid, a1.userid, a1.quyenso, a1.sobienlai, e.sohieu, e.sohieubl, gvp.id_loai";
                asql += " union all";
                asql += " select a.id, a.mabn, a.mavaovien, a.maql, a1.loai, hs.ten as ten_loaivp, a1.loaibn, to_char(a.ngayvao,'dd/mm/yyyy') as ngayvao, to_char(a.ngayra,'dd/mm/yyyy') as ngayra, b.hoten, case when b.ngaysinh is null then b.namsinh else to_char(b.ngaysinh,'dd/mm/yyyy') end as namsinh, trim(b.sonha || ' '||b.thon) as diachi, c.tentt, c1.tenquan, c2.tenpxa, c4.makp, c4.tenkp, c4.viettat, to_char(a1.ngay,'dd/mm/yyyy') as ngay,case when nvp.ma=7 then sum(a4.soluong*a4.dongia) else 0 end as thuoc,case when nvp.ma<>7 then sum(a4.soluong*a4.dongia-a4.tra) else 0 end as vienphi, to_number('0') as sotien,to_number('0') as tamung, to_number('0') as mien, to_number('0') as bhyt, to_number('0') as nopthem, to_number('0') as thieu, to_number('0') as thua, to_number('0') as chenhlech, d.hoten as user_hoten, d.userid as user_username,a1.userid, a1.quyenso, a1.sobienlai, e.sohieu, e.sohieubl, to_number(0,'9') as hoan,to_number('0') as tra";
                asql += " from medibvmmyy.v_ttrvds a left join medibvmmyy.v_ttrvll a1 on a.id=a1.id inner join medibvmmyy.v_ttrvct a4 on a1.id=a4.id left join medibv.d_dmbd bd on a4.mavp=bd.id  left join medibv.d_dmnhom n on bd.manhom=n.id left join medibv.v_nhomvp nvp on n.nhomvp=nvp.ma left join medibv.btdbn b on a.mabn=b.mabn left join medibv.btdtt c on b.matt=c.matt left join medibv.btdquan c1 on b.maqu=c1.maqu left join medibv.btdpxa c2 on b.maphuongxa=c2.maphuongxa left join medibv.btdkp_bv c4 on a1.makp=c4.makp left join medibv.v_dlogin d on a1.userid=d.id left join medibv.v_quyenso e on a1.quyenso=e.id inner join medibv.v_tenloaivp hs on a1.loai=hs.ma " + aexp + "";
                asql += " group by a.id,a.mabn,a.mavaovien,a.maql,a1.loai,hs.ten,a1.loaibn,to_char(a.ngayvao,'dd/mm/yyyy') ,to_char(a.ngayra,'dd/mm/yyyy'),b.hoten,case when b.ngaysinh is null then b.namsinh else to_char(b.ngaysinh,'dd/mm/yyyy') end , trim(b.sonha || ' '||b.thon) ,c.tentt, c1.tenquan, c2.tenpxa, c4.makp,c4.tenkp, c4.viettat, to_char(a1.ngay,'dd/mm/yyyy') , a1.sotien, a1.tamung, a1.mien, a1.bhyt, a1.nopthem, a1.thieu, a1.thua, a1.chenhlech, d.hoten , d.userid, a1.userid, a1.quyenso, a1.sobienlai, e.sohieu, e.sohieubl, nvp.ma";
                ads = m_v.get_data_mmyy(asql, txtTN.Text.Substring(0, 10), txtDN.Text.Substring(0, 10), false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return ads;
        }
        private void f_Xem_TTRV()
        {
            string acurdir = System.Environment.CurrentDirectory;
            try
            {
                DataSet ads = f_Get_Data();
                if (ads.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Không có số liệu!"), LibVP.AccessData.Msg);
                    return;
                }
                if (ads != null)
                {
                    string areport = "", asyt = "", abv = "", angayin = "", aghichu = "";
                    areport = "v_2007_dstd_ttravien_bnntru.rpt";
                    if (cbMaubaocao.SelectedIndex != 0)
                    {
                        string areportt = cbMaubaocao.SelectedValue.ToString();
                        if (System.IO.File.Exists("..\\..\\..\\report\\" + areportt))
                        {
                            areport = areportt;
                        }
                    }
                    asyt = m_v.Syte;
                    abv = m_v.Tenbv;
                    angayin = lan.Change_language_MessageText("Ngày") + " " + txtNgayIn.Value.Day.ToString().PadLeft(2, '0') + " " + lan.Change_language_MessageText("tháng") + " " + txtNgayIn.Value.Month.ToString().PadLeft(2, '0') + " " + lan.Change_language_MessageText("năm") + " " + txtNgayIn.Value.Year.ToString();
                    
                    aghichu = lan.Change_language_MessageText("Từ ngày:") + " " + txtTN.Text.Substring(0, 10) + " " + lan.Change_language_MessageText("Đến ngày:") + " " + txtDN.Text.Substring(0, 10);
                    
                    if (!System.IO.Directory.Exists("..//..//Datareport//"))
                    {
                        System.IO.Directory.CreateDirectory("..//..//Datareport//");
                    }
                    ads.WriteXml("..//..//Datareport//v_2007_dstd_ttravien_bnntru.xml", XmlWriteMode.WriteSchema);

                    frmReport fa = new frmReport(m_v, ads.Tables[0], areport, asyt.ToUpper(), abv.ToUpper(), angayin, "", aghichu, "", "", "", "", "", 1, checkBox1.Checked ? true : false);
                    fa.ShowDialog();
                }
            }
            catch
            {
            }
            finally
            {
                System.Environment.CurrentDirectory = acurdir;
            }
        }
        private DataSet f_Get_Maubaocaotructiep()
        {
            //v_maubaocao 
            //loai=1: Báo cáo thu viện phí trực tiếp (v_vienphill, v_vienphict, v_mienngtru, v_bhyt)
            //loai=2: Bảng kê thanh toán ra viện ngoại trú + nội trú (v_ttrvll, v_ttrvct, v_ttrvbhyt, v_ttrvds, v_miennoitru)
            //loai=3: Báo cáo thu tạm ứng
            //loai=4: Báo cáo miễn giảm
            //loai=13: Báo cáo thanh toán ra viện
            DataSet ads = new DataSet();
            try
            {

                ads = m_v.get_data("select ma, ten from medibv.v_maubaocao where loai=13");
                DataRow r = ads.Tables[0].NewRow();
                r["ma"] = "";
                r["ten"] = lan.Change_language_MessageText("Mẫu báo cáo chung");
                ads.Tables[0].Rows.InsertAt(r, 0);
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
                cbMaubaocao.DisplayMember = "TEN";
                cbMaubaocao.ValueMember = "MA";
                cbMaubaocao.DataSource = ads.Tables[0];
                cbMaubaocao.SelectedIndex = 0;
            }
            catch
            {
            }
        }

        private void rd6_CheckedChanged(object sender, EventArgs e)
        {
            f_Load_Tree_Field();
            button1.Enabled = true;
            chkTamung.Visible = rd6.Checked;
            //En_txt(false);
        }

        private void En_txt(bool val)
        {
            butWeb.Enabled = val;
            butExcel.Enabled = val;
            rd1.Visible = val;
            rd2.Visible = val;
            tree_Loai.Enabled = val;
            chkAll.Visible = val;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string atmp = System.Environment.CurrentDirectory;
            try
            {
                progressBar1.Value = 1;
                timer1.Enabled = true;
                butExcel.Enabled = false;
                this.Cursor = Cursors.WaitCursor;
                f_Ketxuat("Report");
                butExcel.Enabled = true;
                this.Cursor = Cursors.Default;
                progressBar1.Value = 0;
                timer1.Enabled = false;
            }
            catch
            {
            }
            finally
            {
                System.Environment.CurrentDirectory = atmp;
            }
        }

        private void chkAllKhoaphong_CheckedChanged(object sender, EventArgs e)
        {
            f_Set_CheckID(tree_KhoaPhong, chkAllKhoaphong.Checked);
        }
	}
}
