using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibMedi;
using LibDuoc;

namespace Medisoft
{
	/// <summary>
	/// Summary description for frmThongsomay.
	/// </summary>
	public class frmThongsomay : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Button butOk;
		private System.Windows.Forms.Button butCancel;
		private LibMedi.AccessData m;
		private LibDuoc.AccessData d=new LibDuoc.AccessData();
        private DataSet dssys = new DataSet();
		private DataSet ds=new DataSet();
		private DataSet dsnn=new DataSet();
		private DataSet dsts=new DataSet();
		private DataTable dt=new DataTable();
		private DataTable dttd=new DataTable();
        private int i_userid;
        private System.ComponentModel.IContainer components;
		private string user;
        private string s_196 = "", sTemp = "", _id, mabv = "", tenbv = "";
        private System.Windows.Forms.CheckBox c44;
        private System.Windows.Forms.NumericUpDown songay;
        private System.Windows.Forms.CheckBox saoluu33;
		private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
		private System.Windows.Forms.CheckBox c47;
		private System.Windows.Forms.CheckBox c46;
        private System.Windows.Forms.CheckBox c45;
        private System.Windows.Forms.CheckBox c53;
		private System.Windows.Forms.CheckBox bsPttt;
		private System.Windows.Forms.CheckBox bsXuatvien;
		private System.Windows.Forms.CheckBox bsXuatkhoa;
		private System.Windows.Forms.CheckBox bsNhapkhoa;
		private System.Windows.Forms.CheckBox bsNhanbenh;
		private System.Windows.Forms.CheckBox bsNgoaitru;
        private System.Windows.Forms.CheckBox bsKhambenh;
        private Label label50;
        private NumericUpDown c189;
        private ComboBox c196;
        private CheckBox c195;
        private TreeView treeView1;
        private TextBox txtNodeTextSearch;
        private Panel p01;
        private Panel p02;
        private GroupBox groupBox1;
        private Panel p03;
        private Panel p12;
        private Panel p04;
        private Panel p05;
        private Panel p06;
        private Panel p07;
        private Panel p08;
        private Panel p09;
        private Panel p11;
        private Panel p10;
        private Label lTemp;
        private Button butTemp;
        private TextBox tTemp;
        private CheckBox c277;
        private DataSet dsletet = new DataSet();
        private ComboBox ngonngu;
        private Label label30;
        private CheckBox c343;
        private DataTable dtkp = new DataTable();
	
		public frmThongsomay(LibMedi.AccessData acc,int userid)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
            m = acc; i_userid = userid; if (m.bBogo) tv.GanBogo(this, textBox111);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThongsomay));
            this.butOk = new System.Windows.Forms.Button();
            this.butCancel = new System.Windows.Forms.Button();
            this.c196 = new System.Windows.Forms.ComboBox();
            this.c47 = new System.Windows.Forms.CheckBox();
            this.c46 = new System.Windows.Forms.CheckBox();
            this.c53 = new System.Windows.Forms.CheckBox();
            this.c195 = new System.Windows.Forms.CheckBox();
            this.c44 = new System.Windows.Forms.CheckBox();
            this.songay = new System.Windows.Forms.NumericUpDown();
            this.saoluu33 = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.c189 = new System.Windows.Forms.NumericUpDown();
            this.c45 = new System.Windows.Forms.CheckBox();
            this.bsPttt = new System.Windows.Forms.CheckBox();
            this.bsXuatvien = new System.Windows.Forms.CheckBox();
            this.bsXuatkhoa = new System.Windows.Forms.CheckBox();
            this.bsNhapkhoa = new System.Windows.Forms.CheckBox();
            this.bsNhanbenh = new System.Windows.Forms.CheckBox();
            this.bsNgoaitru = new System.Windows.Forms.CheckBox();
            this.bsKhambenh = new System.Windows.Forms.CheckBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.txtNodeTextSearch = new System.Windows.Forms.TextBox();
            this.p01 = new System.Windows.Forms.Panel();
            this.c277 = new System.Windows.Forms.CheckBox();
            this.butTemp = new System.Windows.Forms.Button();
            this.tTemp = new System.Windows.Forms.TextBox();
            this.lTemp = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ngonngu = new System.Windows.Forms.ComboBox();
            this.label30 = new System.Windows.Forms.Label();
            this.p02 = new System.Windows.Forms.Panel();
            this.p03 = new System.Windows.Forms.Panel();
            this.p12 = new System.Windows.Forms.Panel();
            this.p04 = new System.Windows.Forms.Panel();
            this.p05 = new System.Windows.Forms.Panel();
            this.p06 = new System.Windows.Forms.Panel();
            this.p07 = new System.Windows.Forms.Panel();
            this.p08 = new System.Windows.Forms.Panel();
            this.p09 = new System.Windows.Forms.Panel();
            this.p11 = new System.Windows.Forms.Panel();
            this.p10 = new System.Windows.Forms.Panel();
            this.c343 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.songay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c189)).BeginInit();
            this.p01.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.p02.SuspendLayout();
            this.p07.SuspendLayout();
            this.SuspendLayout();
            // 
            // butOk
            // 
            this.butOk.Image = ((System.Drawing.Image)(resources.GetObject("butOk.Image")));
            this.butOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butOk.Location = new System.Drawing.Point(8, 477);
            this.butOk.Name = "butOk";
            this.butOk.Size = new System.Drawing.Size(70, 25);
            this.butOk.TabIndex = 54;
            this.butOk.Text = "    &Lưu";
            this.butOk.Click += new System.EventHandler(this.butOk_Click);
            // 
            // butCancel
            // 
            this.butCancel.Image = ((System.Drawing.Image)(resources.GetObject("butCancel.Image")));
            this.butCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butCancel.Location = new System.Drawing.Point(79, 477);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(70, 25);
            this.butCancel.TabIndex = 55;
            this.butCancel.Text = "&Kết thúc";
            this.butCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // c196
            // 
            this.c196.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.c196.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c196.Location = new System.Drawing.Point(115, 5);
            this.c196.Name = "c196";
            this.c196.Size = new System.Drawing.Size(144, 21);
            this.c196.TabIndex = 177;
            // 
            // c47
            // 
            this.c47.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c47.ForeColor = System.Drawing.SystemColors.ControlText;
            this.c47.Location = new System.Drawing.Point(6, 26);
            this.c47.Name = "c47";
            this.c47.Size = new System.Drawing.Size(241, 21);
            this.c47.TabIndex = 9;
            this.c47.Text = "Danh sách chờ đóng tiền";
            // 
            // c46
            // 
            this.c46.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c46.ForeColor = System.Drawing.SystemColors.ControlText;
            this.c46.Location = new System.Drawing.Point(6, 7);
            this.c46.Name = "c46";
            this.c46.Size = new System.Drawing.Size(241, 16);
            this.c46.TabIndex = 6;
            this.c46.Text = "In tiền khám bệnh";
            // 
            // c53
            // 
            this.c53.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c53.ForeColor = System.Drawing.SystemColors.ControlText;
            this.c53.Location = new System.Drawing.Point(6, 45);
            this.c53.Name = "c53";
            this.c53.Size = new System.Drawing.Size(241, 18);
            this.c53.TabIndex = 7;
            this.c53.Text = "Sửa đơn giá trong đăng ký";
            // 
            // c195
            // 
            this.c195.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c195.ForeColor = System.Drawing.SystemColors.ControlText;
            this.c195.Location = new System.Drawing.Point(83, 129);
            this.c195.Name = "c195";
            this.c195.Size = new System.Drawing.Size(192, 19);
            this.c195.TabIndex = 178;
            this.c195.Text = "Mẫu đăng ký khám bệnh số 1";
            // 
            // c44
            // 
            this.c44.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c44.ForeColor = System.Drawing.SystemColors.ControlText;
            this.c44.Location = new System.Drawing.Point(3, 5);
            this.c44.Name = "c44";
            this.c44.Size = new System.Drawing.Size(331, 21);
            this.c44.TabIndex = 94;
            this.c44.Text = "Kiểm tra hợp lệ họ tên và giới tính";
            // 
            // songay
            // 
            this.songay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.songay.Location = new System.Drawing.Point(364, 49);
            this.songay.Name = "songay";
            this.songay.Size = new System.Drawing.Size(50, 21);
            this.songay.TabIndex = 82;
            this.songay.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // saoluu33
            // 
            this.saoluu33.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saoluu33.ForeColor = System.Drawing.SystemColors.ControlText;
            this.saoluu33.Location = new System.Drawing.Point(83, 92);
            this.saoluu33.Name = "saoluu33";
            this.saoluu33.Size = new System.Drawing.Size(331, 17);
            this.saoluu33.TabIndex = 84;
            this.saoluu33.Text = "Thông báo sao lưu số liệu trước khi kết thúc chương trình";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(413, 54);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(32, 13);
            this.label11.TabIndex = 86;
            this.label11.Text = "ngày";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label10.Location = new System.Drawing.Point(63, 50);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(264, 17);
            this.label10.TabIndex = 92;
            this.label10.Text = "Khoảng cách ngày làm việc so với ngày hệ thống :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label50
            // 
            this.label50.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label50.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label50.Location = new System.Drawing.Point(17, 72);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(344, 17);
            this.label50.TabIndex = 170;
            this.label50.Text = "Số chương trình Medisoft kích hoạt tối đa trên mỗi máy là :";
            this.label50.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // c189
            // 
            this.c189.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c189.Location = new System.Drawing.Point(364, 72);
            this.c189.Name = "c189";
            this.c189.Size = new System.Drawing.Size(50, 21);
            this.c189.TabIndex = 169;
            this.c189.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // c45
            // 
            this.c45.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c45.ForeColor = System.Drawing.SystemColors.ControlText;
            this.c45.Location = new System.Drawing.Point(83, 111);
            this.c45.Name = "c45";
            this.c45.Size = new System.Drawing.Size(162, 15);
            this.c45.TabIndex = 4;
            this.c45.Text = "Xem trước khi in";
            // 
            // bsPttt
            // 
            this.bsPttt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bsPttt.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bsPttt.Location = new System.Drawing.Point(265, 40);
            this.bsPttt.Name = "bsPttt";
            this.bsPttt.Size = new System.Drawing.Size(144, 20);
            this.bsPttt.TabIndex = 99;
            this.bsPttt.Text = "Phẩu thuật - thủ thuật";
            // 
            // bsXuatvien
            // 
            this.bsXuatvien.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bsXuatvien.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bsXuatvien.Location = new System.Drawing.Point(143, 40);
            this.bsXuatvien.Name = "bsXuatvien";
            this.bsXuatvien.Size = new System.Drawing.Size(87, 20);
            this.bsXuatvien.TabIndex = 98;
            this.bsXuatvien.Text = "Xuất viện";
            // 
            // bsXuatkhoa
            // 
            this.bsXuatkhoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bsXuatkhoa.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bsXuatkhoa.Location = new System.Drawing.Point(16, 40);
            this.bsXuatkhoa.Name = "bsXuatkhoa";
            this.bsXuatkhoa.Size = new System.Drawing.Size(80, 20);
            this.bsXuatkhoa.TabIndex = 97;
            this.bsXuatkhoa.Text = "Xuất khoa";
            // 
            // bsNhapkhoa
            // 
            this.bsNhapkhoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bsNhapkhoa.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bsNhapkhoa.Location = new System.Drawing.Point(379, 23);
            this.bsNhapkhoa.Name = "bsNhapkhoa";
            this.bsNhapkhoa.Size = new System.Drawing.Size(96, 20);
            this.bsNhapkhoa.TabIndex = 96;
            this.bsNhapkhoa.Text = "Nhập khoa";
            // 
            // bsNhanbenh
            // 
            this.bsNhanbenh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bsNhanbenh.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bsNhanbenh.Location = new System.Drawing.Point(265, 23);
            this.bsNhanbenh.Name = "bsNhanbenh";
            this.bsNhanbenh.Size = new System.Drawing.Size(80, 20);
            this.bsNhanbenh.TabIndex = 95;
            this.bsNhanbenh.Text = "Nhận bệnh";
            // 
            // bsNgoaitru
            // 
            this.bsNgoaitru.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bsNgoaitru.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bsNgoaitru.Location = new System.Drawing.Point(142, 23);
            this.bsNgoaitru.Name = "bsNgoaitru";
            this.bsNgoaitru.Size = new System.Drawing.Size(113, 20);
            this.bsNgoaitru.TabIndex = 94;
            this.bsNgoaitru.Text = "Bệnh án ngoại trú";
            // 
            // bsKhambenh
            // 
            this.bsKhambenh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bsKhambenh.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bsKhambenh.Location = new System.Drawing.Point(16, 23);
            this.bsKhambenh.Name = "bsKhambenh";
            this.bsKhambenh.Size = new System.Drawing.Size(120, 20);
            this.bsKhambenh.TabIndex = 93;
            this.bsKhambenh.Text = "Phiếu khám bệnh";
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(2, 25);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(152, 450);
            this.treeView1.TabIndex = 76;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // txtNodeTextSearch
            // 
            this.txtNodeTextSearch.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNodeTextSearch.ForeColor = System.Drawing.Color.Red;
            this.txtNodeTextSearch.Location = new System.Drawing.Point(2, 3);
            this.txtNodeTextSearch.Name = "txtNodeTextSearch";
            this.txtNodeTextSearch.Size = new System.Drawing.Size(152, 21);
            this.txtNodeTextSearch.TabIndex = 77;
            this.txtNodeTextSearch.Text = "Tìm kiếm";
            this.txtNodeTextSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNodeTextSearch.Enter += new System.EventHandler(this.txtNodeTextSearch_Enter);
            this.txtNodeTextSearch.TextChanged += new System.EventHandler(this.txtNodeTextSearch_TextChanged);
            this.txtNodeTextSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNodeTextSearch_KeyDown);
            // 
            // p01
            // 
            this.p01.AutoScroll = true;
            this.p01.Controls.Add(this.c277);
            this.p01.Controls.Add(this.butTemp);
            this.p01.Controls.Add(this.tTemp);
            this.p01.Controls.Add(this.lTemp);
            this.p01.Controls.Add(this.groupBox1);
            this.p01.Controls.Add(this.songay);
            this.p01.Controls.Add(this.c195);
            this.p01.Controls.Add(this.c189);
            this.p01.Controls.Add(this.label50);
            this.p01.Controls.Add(this.ngonngu);
            this.p01.Controls.Add(this.label30);
            this.p01.Controls.Add(this.saoluu33);
            this.p01.Controls.Add(this.label10);
            this.p01.Controls.Add(this.label11);
            this.p01.Controls.Add(this.c45);
            this.p01.Location = new System.Drawing.Point(159, 3);
            this.p01.Name = "p01";
            this.p01.Size = new System.Drawing.Size(613, 500);
            this.p01.TabIndex = 78;
            // 
            // c277
            // 
            this.c277.Enabled = false;
            this.c277.Location = new System.Drawing.Point(366, 5);
            this.c277.Name = "c277";
            this.c277.Size = new System.Drawing.Size(244, 18);
            this.c277.TabIndex = 231;
            this.c277.Text = "Tự động hủy các tập tin trong thư mục TEMP";
            // 
            // butTemp
            // 
            this.butTemp.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butTemp.Location = new System.Drawing.Point(583, 26);
            this.butTemp.Name = "butTemp";
            this.butTemp.Size = new System.Drawing.Size(24, 23);
            this.butTemp.TabIndex = 230;
            this.butTemp.Text = "...";
            this.butTemp.UseVisualStyleBackColor = true;
            this.butTemp.Click += new System.EventHandler(this.butTemp_Click);
            // 
            // tTemp
            // 
            this.tTemp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tTemp.Enabled = false;
            this.tTemp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tTemp.Location = new System.Drawing.Point(83, 26);
            this.tTemp.Name = "tTemp";
            this.tTemp.Size = new System.Drawing.Size(498, 21);
            this.tTemp.TabIndex = 229;
            // 
            // lTemp
            // 
            this.lTemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lTemp.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lTemp.Location = new System.Drawing.Point(3, 3);
            this.lTemp.Name = "lTemp";
            this.lTemp.Size = new System.Drawing.Size(507, 23);
            this.lTemp.TabIndex = 228;
            this.lTemp.Text = "Thư mục TEMP của :";
            this.lTemp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bsKhambenh);
            this.groupBox1.Controls.Add(this.bsNgoaitru);
            this.groupBox1.Controls.Add(this.bsNhanbenh);
            this.groupBox1.Controls.Add(this.bsNhapkhoa);
            this.groupBox1.Controls.Add(this.bsXuatkhoa);
            this.groupBox1.Controls.Add(this.bsXuatvien);
            this.groupBox1.Controls.Add(this.bsPttt);
            this.groupBox1.Location = new System.Drawing.Point(83, 177);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(526, 62);
            this.groupBox1.TabIndex = 171;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "LỌC DANH SÁCH BÁC SĨ THEO KHOA/PHÒNG TRONG CÁC BIỂU NHẬP SAU :";
            // 
            // ngonngu
            // 
            this.ngonngu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ngonngu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngonngu.Location = new System.Drawing.Point(185, 148);
            this.ngonngu.Name = "ngonngu";
            this.ngonngu.Size = new System.Drawing.Size(98, 21);
            this.ngonngu.TabIndex = 114;
            this.ngonngu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngonngu_KeyDown);
            // 
            // label30
            // 
            this.label30.Location = new System.Drawing.Point(78, 148);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(104, 21);
            this.label30.TabIndex = 113;
            this.label30.Text = "Ngôn ngữ thể hiện :";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // p02
            // 
            this.p02.AutoScroll = true;
            this.p02.Controls.Add(this.c343);
            this.p02.Controls.Add(this.c44);
            this.p02.Location = new System.Drawing.Point(159, 3);
            this.p02.Name = "p02";
            this.p02.Size = new System.Drawing.Size(613, 500);
            this.p02.TabIndex = 79;
            this.p02.Visible = false;
            // 
            // p03
            // 
            this.p03.AutoScroll = true;
            this.p03.Location = new System.Drawing.Point(159, 3);
            this.p03.Name = "p03";
            this.p03.Size = new System.Drawing.Size(613, 500);
            this.p03.TabIndex = 80;
            this.p03.Visible = false;
            // 
            // p12
            // 
            this.p12.AutoScroll = true;
            this.p12.Location = new System.Drawing.Point(159, 3);
            this.p12.Name = "p12";
            this.p12.Size = new System.Drawing.Size(613, 500);
            this.p12.TabIndex = 81;
            this.p12.Visible = false;
            // 
            // p04
            // 
            this.p04.AutoScroll = true;
            this.p04.Location = new System.Drawing.Point(159, 3);
            this.p04.Name = "p04";
            this.p04.Size = new System.Drawing.Size(613, 500);
            this.p04.TabIndex = 82;
            this.p04.Visible = false;
            // 
            // p05
            // 
            this.p05.AutoScroll = true;
            this.p05.Location = new System.Drawing.Point(159, 3);
            this.p05.Name = "p05";
            this.p05.Size = new System.Drawing.Size(613, 500);
            this.p05.TabIndex = 83;
            this.p05.Visible = false;
            // 
            // p06
            // 
            this.p06.AutoScroll = true;
            this.p06.Location = new System.Drawing.Point(159, 3);
            this.p06.Name = "p06";
            this.p06.Size = new System.Drawing.Size(613, 500);
            this.p06.TabIndex = 84;
            this.p06.Visible = false;
            // 
            // p07
            // 
            this.p07.AutoScroll = true;
            this.p07.Controls.Add(this.c196);
            this.p07.Controls.Add(this.c46);
            this.p07.Controls.Add(this.c47);
            this.p07.Controls.Add(this.c53);
            this.p07.Location = new System.Drawing.Point(159, 3);
            this.p07.Name = "p07";
            this.p07.Size = new System.Drawing.Size(613, 500);
            this.p07.TabIndex = 82;
            this.p07.Visible = false;
            // 
            // p08
            // 
            this.p08.AutoScroll = true;
            this.p08.Location = new System.Drawing.Point(159, 3);
            this.p08.Name = "p08";
            this.p08.Size = new System.Drawing.Size(613, 500);
            this.p08.TabIndex = 85;
            this.p08.Visible = false;
            // 
            // p09
            // 
            this.p09.AutoScroll = true;
            this.p09.Location = new System.Drawing.Point(159, 3);
            this.p09.Name = "p09";
            this.p09.Size = new System.Drawing.Size(613, 500);
            this.p09.TabIndex = 86;
            this.p09.Visible = false;
            // 
            // p11
            // 
            this.p11.AutoScroll = true;
            this.p11.Location = new System.Drawing.Point(159, 3);
            this.p11.Name = "p11";
            this.p11.Size = new System.Drawing.Size(613, 500);
            this.p11.TabIndex = 87;
            this.p11.Visible = false;
            // 
            // p10
            // 
            this.p10.AutoScroll = true;
            this.p10.Location = new System.Drawing.Point(159, 3);
            this.p10.Name = "p10";
            this.p10.Size = new System.Drawing.Size(613, 500);
            this.p10.TabIndex = 88;
            this.p10.Visible = false;
            // 
            // c343
            // 
            this.c343.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c343.ForeColor = System.Drawing.SystemColors.ControlText;
            this.c343.Location = new System.Drawing.Point(3, 24);
            this.c343.Name = "c343";
            this.c343.Size = new System.Drawing.Size(201, 19);
            this.c343.TabIndex = 266;
            this.c343.Text = "Quản lý Smard Card";
            // 
            // frmThongsomay
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(778, 510);
            this.Controls.Add(this.p02);
            this.Controls.Add(this.p01);
            this.Controls.Add(this.p03);
            this.Controls.Add(this.p04);
            this.Controls.Add(this.p05);
            this.Controls.Add(this.p06);
            this.Controls.Add(this.p07);
            this.Controls.Add(this.p08);
            this.Controls.Add(this.p09);
            this.Controls.Add(this.p10);
            this.Controls.Add(this.p11);
            this.Controls.Add(this.p12);
            this.Controls.Add(this.txtNodeTextSearch);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmThongsomay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Khai báo thông số hệ thống";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmThongsomay_KeyDown);
            this.Load += new System.EventHandler(this.frmThongsomay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.songay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c189)).EndInit();
            this.p01.ResumeLayout(false);
            this.p01.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.p02.ResumeLayout(false);
            this.p07.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmThongsomay_Load(object sender, System.EventArgs e)
		{
            this.Text += " của máy " + Environment.UserName.ToString();
            sTemp = m.getPathTemp;
            tTemp.Text = sTemp;
            lTemp.Text = "Thư mục TEMP của máy "+Environment.UserName.ToString();
            user = m.user;
            load_treeview();

			dsnn.ReadXml("..//..//..//xml//ngonngu.xml");
			ngonngu.DisplayMember="TEN";
			ngonngu.ValueMember="TEN";
			ngonngu.DataSource=dsnn.Tables[0];

            c196.DisplayMember = "HOTEN";
            c196.ValueMember = "ID";
            c196.DataSource = m.get_data("select * from "+user+".v_dlogin order by id").Tables[0];

            if (ngonngu.Items.Count>0) ngonngu.SelectedIndex=int.Parse(m.Thongso("Ngonngu"));
			songay.Maximum=Decimal.Parse(int.MaxValue.ToString());
			dsts.ReadXml("..//..//..//xml//thongso.xml");
			ds.ReadXml("..//..//..//xml//maincode.xml");
            _id = "";
			try
			{
                load_tso("ten");
			}
            catch (Exception ex) { MessageBox.Show(_id+"\n"+ex.Message); }
            check(p06);
		}

        private void load_tso(string fie)
        {
            foreach (DataRow r in m.get_data("select * from " + user + ".thongso order by id").Tables[0].Rows)
            {
                _id = r["id"].ToString();
                if (r[fie].ToString() != "")
                {
                    switch (int.Parse(r["id"].ToString()))
                    {
                        case 26: bsKhambenh.Checked = int.Parse(m.Thongso("c26")) == 1;
                            break;
                        case 27: bsNgoaitru.Checked = int.Parse(m.Thongso("c27")) == 1;
                            break;
                        case 28: bsNhanbenh.Checked = int.Parse(m.Thongso("c28")) == 1;
                            break;
                        case 29: bsNhapkhoa.Checked = int.Parse(m.Thongso("c29")) == 1;
                            break;
                        case 30: bsXuatkhoa.Checked = int.Parse(m.Thongso("c30")) == 1;
                            break;
                        case 31: bsXuatvien.Checked = int.Parse(m.Thongso("c31")) == 1;
                            break;
                        case 32: bsPttt.Checked = int.Parse(m.Thongso("c32")) == 1;
                            break;
                        case 33: saoluu33.Checked = int.Parse(m.Thongso("c33")) == 1;
                            break;
                        case 44: c44.Checked = int.Parse(m.Thongso("c44")) == 1;
                            break;
                        case 45: c45.Checked = int.Parse(m.Thongso("c45")) == 1;
                            break;
                        case 46: c46.Checked = int.Parse(m.Thongso("c46")) == 1;
                            break;
                        case 47: c47.Checked = int.Parse(m.Thongso("c47")) == 1;
                            break;
                        case 195: c195.Checked = int.Parse(m.Thongso("c195")) == 1;
                            break;
                        case 196: c196.SelectedValue = m.Thongso("c196");
                            s_196 = m.Thongso("c196");
                            break;
                        case 277: c277.Checked = r[fie].ToString().Trim() == "1";
                            break;
                        case 343: c343.Checked = m.Thongso("smartcard").ToString().Trim() == "1";
                            break;
                    }
                }
            }
        }
        private void check(Panel p)
        {
            foreach (System.Windows.Forms.Control c in p.Controls)
            {
                try
                {
                    CheckBox chk = (CheckBox)c;
                    if (chk.Checked) chk.ForeColor = Color.Red;
                }
                catch { }
            }
        }

        private void load_treeview()
        {
            dssys.ReadXml("..//..//..//xml//tsosystem.xml");
            TreeNode node;
            TreeNode nod;
            node = treeView1.Nodes.Add("Medisoft");
            foreach (DataRow r in dssys.Tables[0].Rows)
            {
                nod = new TreeNode();
                nod.Text = r["text"].ToString();
                nod.Tag = r["tag"].ToString();
                node.Nodes.Add(nod);
            }
            treeView1.ExpandAll();
            this.p01.Location = new System.Drawing.Point(159, 3);
            this.p02.Location = new System.Drawing.Point(159, 3);
            this.p03.Location = new System.Drawing.Point(159, 3);
            this.p04.Location = new System.Drawing.Point(159, 3);
            this.p05.Location = new System.Drawing.Point(159, 3);
            this.p06.Location = new System.Drawing.Point(159, 3);
            this.p07.Location = new System.Drawing.Point(159, 3);
            this.p08.Location = new System.Drawing.Point(159, 3);
            this.p09.Location = new System.Drawing.Point(159, 3);
            this.p11.Location = new System.Drawing.Point(159, 3);
            this.p10.Location = new System.Drawing.Point(159, 3);
            this.p12.Location = new System.Drawing.Point(159, 3);
            //this.p01.Visible = true;
        }

		private void butCancel_Click(object sender, System.EventArgs e)
		{
			m.close();this.Close();
		}

		private void butOk_Click(object sender, System.EventArgs e)
		{
            if (sTemp != tTemp.Text && tTemp.Text != "")
            {
                if (!System.IO.Directory.Exists(tTemp.Text)) System.IO.Directory.CreateDirectory(tTemp.Text);
                Environment.SetEnvironmentVariable("TEMP", tTemp.Text, EnvironmentVariableTarget.User);
            }
			if (c46.Checked && c47.Checked)
			{
				MessageBox.Show(lan.Change_language_MessageText("Không hợp lệ chỉ chọn in hoặc danh sách chờ đóng tiền !"),LibMedi.AccessData.Msg);
				c46.Focus();
				return;
			}
            upd_tso("ten");
		}

        private void upd_tso(string fie)
        {
            Cursor = Cursors.WaitCursor;
            m.upd_thongso(2, fie, mabv.ToString().Trim());
            m.upd_thongso(3, fie, tenbv.ToString().Trim());

            ds.Tables[0].Rows[0]["mabv"] = mabv.ToString().Trim();
            ds.Tables[0].Rows[0]["tenbv"] = tenbv.ToString().Trim();
            ds.WriteXml("..//..//..//xml//maincode.xml");

            m.upd_thongso(189, fie, c189.Value.ToString());

            dsts.Tables[0].Rows[0]["c14"] = songay.Value.ToString().Trim();
            dsts.Tables[0].Rows[0]["c26"] = (bsKhambenh.Checked) ? "1" : "0";
            dsts.Tables[0].Rows[0]["c27"] = (bsNgoaitru.Checked) ? "1" : "0";
            dsts.Tables[0].Rows[0]["c28"] = (bsNhanbenh.Checked) ? "1" : "0";
            dsts.Tables[0].Rows[0]["c29"] = (bsNhapkhoa.Checked) ? "1" : "0";
            dsts.Tables[0].Rows[0]["c30"] = (bsXuatkhoa.Checked) ? "1" : "0";
            dsts.Tables[0].Rows[0]["c31"] = (bsXuatvien.Checked) ? "1" : "0";
            dsts.Tables[0].Rows[0]["c32"] = (bsPttt.Checked) ? "1" : "0";
            dsts.Tables[0].Rows[0]["c33"] = (saoluu33.Checked) ? "1" : "0";
            dsts.Tables[0].Rows[0]["c44"] = (c44.Checked) ? "1" : "0";
            dsts.Tables[0].Rows[0]["c45"] = (c45.Checked) ? "1" : "0";
            dsts.Tables[0].Rows[0]["c46"] = (c46.Checked) ? "1" : "0";
            dsts.Tables[0].Rows[0]["c47"] = (c47.Checked) ? "1" : "0";
            dsts.Tables[0].Rows[0]["c53"] = (c53.Checked) ? "1" : "0";
            dsts.Tables[0].Rows[0]["c195"] = (c195.Checked) ? "1" : "0";
            dsts.Tables[0].Rows[0]["c196"] = (c196.SelectedIndex != -1) ? c196.SelectedValue.ToString() : "0";
            dsts.Tables[0].Rows[0]["ngonngu"] = ngonngu.SelectedIndex.ToString();
            dsts.WriteXml("..//..//..//xml//thongso.xml");
            m.writeXml("thongso", "smartcard", (c343.Checked) ? "1" : "0");
            m.get_dmcomputer();
            Cursor = Cursors.Default;
            butCancel.Focus();
        }
		private void loaidv_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{F4}");
		}

		private void soyte_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}{F4}");
		}

		private void benhvien_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void diachi_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void dienthoai_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void thunhap_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void ketxuat_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void saoluu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");	
		}

		private void songay_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void frmThongsomay_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.F10) butCancel_Click(sender,e);
		}

		private void sovaovien_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void soluutru_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void pttt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void ngaylv_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void chandoan_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void network_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void solieu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void khambenh_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");		
		}

		private void noichuyen_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void bsKhambenh_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void bsNgoaitru_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void bsNhanbenh_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void bsNhapkhoa_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void bsXuatkhoa_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void bsXuatvien_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void bsPttt_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void saoluu33_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void c38_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void c42_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void c43_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");		
		}


		private void ngonngu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (ngonngu.SelectedIndex==-1 && ngonngu.Items.Count>0) ngonngu.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}


        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                /*
                Panel p=new Panel();
                foreach (DataRow r in dssys.Tables[0].Rows)
                {
                    p.Name = r["tag"].ToString();
                    p.Visible = false;
                }
                p.Name=treeView1.SelectedNode.Tag.ToString();
                p.Visible = true;
                 * */
                p01.Visible = false;p02.Visible = false;p03.Visible = false;
                p04.Visible = false;p05.Visible = false;p06.Visible = false;
                p07.Visible = false;p08.Visible = false;p09.Visible = false;
                p11.Visible = false;p10.Visible = false;p12.Visible = false;

                switch (treeView1.SelectedNode.Tag.ToString())
                {
                    case "p01": p01.Visible = true; check(p01); break;
                    case "p02": p02.Visible = true; check(p02); break;
                    case "p03": p03.Visible = true; check(p03); break;
                    case "p04": p04.Visible = true; check(p04); break;
                    case "p05": p05.Visible = true; check(p05); break;
                    case "p06": p06.Visible = true; check(p06); break;
                    case "p07": p07.Visible = true; check(p07); break;
                    case "p08": p08.Visible = true; check(p08); break;
                    case "p09": p09.Visible = true; check(p09); break;
                    case "p10": p10.Visible = true; check(p10); break;
                    case "p11": p11.Visible = true; check(p11); break;
                    case "p12": p12.Visible = true; check(p12); break;
                }
            }
            catch { }
        }

        private void FindByText()
        {
            TreeNodeCollection nodes = treeView1.Nodes;
            foreach (TreeNode n in nodes)
            {
                FindRecursive(n);
            }
        }


        private void FindRecursive(TreeNode treeNode)
        {
            foreach (TreeNode tn in treeNode.Nodes)
            {
                if (tn.Text.ToLower().IndexOf(this.txtNodeTextSearch.Text.ToLower().Trim())!=-1)
                    tn.BackColor = Color.Yellow;
                FindRecursive(tn);
            }
        }

        private void ClearBackColor()
        {
            TreeNodeCollection nodes = treeView1.Nodes;
            foreach (TreeNode n in nodes)
            {
                ClearRecursive(n);
            }
        }

        private void ClearRecursive(TreeNode treeNode)
        {
            foreach (TreeNode tn in treeNode.Nodes)
            {
                tn.BackColor = Color.White;
                ClearRecursive(tn);
            }
        }

        private void NodeTextSearch()
        {
            ClearBackColor();
            FindByText();
        }

        private void txtNodeTextSearch_TextChanged(object sender, EventArgs e)
        {
            NodeTextSearch();
        }

        private void txtNodeTextSearch_Enter(object sender, EventArgs e)
        {
            txtNodeTextSearch.Text = "";
        }

        private void txtNodeTextSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab || e.KeyCode == Keys.Enter) treeView1.Focus();
        }

        private void butTemp_Click(object sender, EventArgs e)
        {
            string sDir = System.Environment.CurrentDirectory.ToString();
            frmThumuc f = new frmThumuc(tTemp.Text, "Chọn thư mục", 0);
            f.ShowDialog();
            if (f.s_dir != "") tTemp.Text = f.s_dir;
            System.Environment.CurrentDirectory = sDir;
        }
	}
}
