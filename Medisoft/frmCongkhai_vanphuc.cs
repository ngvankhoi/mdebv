using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibDuoc;
using LibMedi;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Diagnostics;
using Excel;

namespace Medisoft
{
	/// <summary>
	/// Summary description for frmCongkhai.
	/// </summary>
	public class frmCongkhai : System.Windows.Forms.Form
	{
		Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        private int i_maxlength_mabn = 8;
		string b_makp="",s_mabn,sql,user,stime,xxx,tenuser;
        System.Data.DataTable dtnhom = new System.Data.DataTable();
        System.Data.DataTable dtdoituong = new System.Data.DataTable();
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.DateTimePicker ngayvao;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.Button butKetthuc;
		private System.Windows.Forms.TextBox m1;
		private System.Windows.Forms.TextBox m2;
		private System.Windows.Forms.TextBox hoten;
		private System.Windows.Forms.TextBox namsinh;
		private System.Windows.Forms.TextBox phai;
		private System.Windows.Forms.TextBox chandoan;
		private DataSet ds=new DataSet();
		private DataSet dsngay=new DataSet();
		private LibDuoc.AccessData d;
		private LibMedi.AccessData m=new LibMedi.AccessData();
		private long l_maql,l_id,l_mavaovien;
		private int col,songay,i_loaiba,i_userid;
		private System.Windows.Forms.Button butTiep;
		private System.Data.DataTable dt,dttmp;
		private bool bCapve,bNdot,bThanhtoan_khoa;
		private DataColumn dc;
		private DataSet ds1=new DataSet();
		Excel.Application oxl;
		Excel._Workbook owb;
		Excel._Worksheet osheet;
        Excel.Range orange;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox chkXem;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox sothe;
		private MaskedBox.MaskedBox ngayra;
		private System.Windows.Forms.CheckBox chkVienphi;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox diachi;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.ComboBox ngayvv;
		private System.Windows.Forms.TextBox soluutru;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Label lblpt;
        private ComboBox tenkp;
        private System.Windows.Forms.CheckBox chkKhoa;
        private System.Windows.Forms.CheckBox chkThuoc;
        private System.Windows.Forms.CheckBox chkExcel;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.CheckBox chkHaophi;
        private System.Windows.Forms.CheckBox chkDoituong;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTieude;
        private ComboBox cmbDoituong;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox chkInnhieuphieu;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
        private string m_sovaovien = "", m_phong = "", m_giuong = "";
        private System.Windows.Forms.CheckBox chkNgay;
        decimal d_sttamung = 0;

		public frmCongkhai(LibDuoc.AccessData acc, string makp,bool admin,int loaiba,string suserid,int userid)
		{
			//
			// Required for Windows Form Designer support
			//

			InitializeComponent();
			lan.Read_Language_to_Xml(this.Name.ToString(),this);
			lan.Changelanguage_to_English(this.Name.ToString(),this);
            d = acc; b_makp = makp; chkVienphi.Enabled = admin; i_loaiba = loaiba; tenuser = suserid; i_userid = userid;
            if (m.bBogo) tv.GanBogo(this, textBox111);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCongkhai));
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.m1 = new System.Windows.Forms.TextBox();
            this.m2 = new System.Windows.Forms.TextBox();
            this.hoten = new System.Windows.Forms.TextBox();
            this.namsinh = new System.Windows.Forms.TextBox();
            this.phai = new System.Windows.Forms.TextBox();
            this.chandoan = new System.Windows.Forms.TextBox();
            this.ngayvao = new System.Windows.Forms.DateTimePicker();
            this.butIn = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.butTiep = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.chkXem = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.sothe = new System.Windows.Forms.TextBox();
            this.ngayra = new MaskedBox.MaskedBox();
            this.chkVienphi = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.diachi = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.ngayvv = new System.Windows.Forms.ComboBox();
            this.soluutru = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.lblpt = new System.Windows.Forms.Label();
            this.tenkp = new System.Windows.Forms.ComboBox();
            this.chkKhoa = new System.Windows.Forms.CheckBox();
            this.chkThuoc = new System.Windows.Forms.CheckBox();
            this.chkExcel = new System.Windows.Forms.CheckBox();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.chkHaophi = new System.Windows.Forms.CheckBox();
            this.chkDoituong = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTieude = new System.Windows.Forms.TextBox();
            this.cmbDoituong = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.chkInnhieuphieu = new System.Windows.Forms.CheckBox();
            this.chkNgay = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(-13, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã BN :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(141, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 23);
            this.label3.TabIndex = 3;
            this.label3.Text = "Họ tên :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(328, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 23);
            this.label4.TabIndex = 5;
            this.label4.Text = "NS :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(400, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 23);
            this.label5.TabIndex = 7;
            this.label5.Text = "Giới tính :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(140, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 23);
            this.label8.TabIndex = 13;
            this.label8.Text = "Từ :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(339, 31);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 23);
            this.label9.TabIndex = 15;
            this.label9.Text = "đến :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(137, 56);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 23);
            this.label10.TabIndex = 23;
            this.label10.Text = "Chẩn đoán :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m1
            // 
            this.m1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.m1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m1.Location = new System.Drawing.Point(56, 9);
            this.m1.MaxLength = 2;
            this.m1.Name = "m1";
            this.m1.Size = new System.Drawing.Size(26, 22);
            this.m1.TabIndex = 1;
            this.m1.Validated += new System.EventHandler(this.m1_Validated);
            this.m1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m1_KeyDown);
            this.m1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m1_KeyPress);
            // 
            // m2
            // 
            this.m2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.m2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m2.Location = new System.Drawing.Point(82, 9);
            this.m2.MaxLength = 6;
            this.m2.Name = "m2";
            this.m2.Size = new System.Drawing.Size(62, 22);
            this.m2.TabIndex = 2;
            this.m2.Validated += new System.EventHandler(this.m2_Validated);
            this.m2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m2_KeyDown);
            this.m2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m2_KeyPress);
            // 
            // hoten
            // 
            this.hoten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.hoten.Enabled = false;
            this.hoten.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoten.Location = new System.Drawing.Point(183, 9);
            this.hoten.Name = "hoten";
            this.hoten.Size = new System.Drawing.Size(157, 22);
            this.hoten.TabIndex = 4;
            // 
            // namsinh
            // 
            this.namsinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.namsinh.Enabled = false;
            this.namsinh.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namsinh.Location = new System.Drawing.Point(369, 9);
            this.namsinh.Name = "namsinh";
            this.namsinh.Size = new System.Drawing.Size(40, 22);
            this.namsinh.TabIndex = 6;
            // 
            // phai
            // 
            this.phai.BackColor = System.Drawing.SystemColors.HighlightText;
            this.phai.Enabled = false;
            this.phai.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phai.Location = new System.Drawing.Point(460, 9);
            this.phai.Name = "phai";
            this.phai.Size = new System.Drawing.Size(45, 22);
            this.phai.TabIndex = 8;
            // 
            // chandoan
            // 
            this.chandoan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.chandoan.Enabled = false;
            this.chandoan.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chandoan.Location = new System.Drawing.Point(208, 56);
            this.chandoan.Name = "chandoan";
            this.chandoan.Size = new System.Drawing.Size(297, 22);
            this.chandoan.TabIndex = 24;
            // 
            // ngayvao
            // 
            this.ngayvao.CustomFormat = "dd/MM/yyyy HH:mm";
            this.ngayvao.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngayvao.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ngayvao.Location = new System.Drawing.Point(208, 33);
            this.ngayvao.Name = "ngayvao";
            this.ngayvao.Size = new System.Drawing.Size(132, 22);
            this.ngayvao.TabIndex = 14;
            this.ngayvao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngayvao_KeyDown);
            // 
            // butIn
            // 
            this.butIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(730, 80);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 25;
            this.butIn.Text = "    &In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(800, 80);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 27;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // butTiep
            // 
            this.butTiep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butTiep.Image = ((System.Drawing.Image)(resources.GetObject("butTiep.Image")));
            this.butTiep.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butTiep.Location = new System.Drawing.Point(660, 80);
            this.butTiep.Name = "butTiep";
            this.butTiep.Size = new System.Drawing.Size(70, 25);
            this.butTiep.TabIndex = 26;
            this.butTiep.Text = "     &Tiếp";
            this.butTiep.Click += new System.EventHandler(this.butTiep_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(643, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 23);
            this.label1.TabIndex = 19;
            this.label1.Text = "Khoa :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkXem
            // 
            this.chkXem.AutoSize = true;
            this.chkXem.Location = new System.Drawing.Point(9, 84);
            this.chkXem.Name = "chkXem";
            this.chkXem.Size = new System.Drawing.Size(102, 17);
            this.chkXem.TabIndex = 28;
            this.chkXem.Text = "Xem trước khi in";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(506, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 23);
            this.label7.TabIndex = 17;
            this.label7.Text = "Số thẻ :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sothe
            // 
            this.sothe.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sothe.Enabled = false;
            this.sothe.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sothe.Location = new System.Drawing.Point(552, 33);
            this.sothe.Name = "sothe";
            this.sothe.Size = new System.Drawing.Size(92, 22);
            this.sothe.TabIndex = 18;
            // 
            // ngayra
            // 
            this.ngayra.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngayra.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngayra.Location = new System.Drawing.Point(369, 33);
            this.ngayra.Mask = "##/##/#### ##:##";
            this.ngayra.Name = "ngayra";
            this.ngayra.Size = new System.Drawing.Size(136, 22);
            this.ngayra.TabIndex = 16;
            this.ngayra.Text = "  /  /       :  ";
            this.ngayra.Validated += new System.EventHandler(this.ngayra_Validated);
            // 
            // chkVienphi
            // 
            this.chkVienphi.AutoSize = true;
            this.chkVienphi.Checked = true;
            this.chkVienphi.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkVienphi.Location = new System.Drawing.Point(111, 84);
            this.chkVienphi.Name = "chkVienphi";
            this.chkVienphi.Size = new System.Drawing.Size(149, 17);
            this.chkVienphi.TabIndex = 29;
            this.chkVienphi.Text = "Chuyển số liệu thanh toán";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(488, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(67, 23);
            this.label11.TabIndex = 9;
            this.label11.Text = "Địa chỉ :";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // diachi
            // 
            this.diachi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.diachi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.diachi.Enabled = false;
            this.diachi.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diachi.Location = new System.Drawing.Point(552, 9);
            this.diachi.Name = "diachi";
            this.diachi.Size = new System.Drawing.Size(318, 22);
            this.diachi.TabIndex = 10;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(-13, 31);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(72, 23);
            this.label12.TabIndex = 11;
            this.label12.Text = "Ngày vào :";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ngayvv
            // 
            this.ngayvv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngayvv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ngayvv.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngayvv.Location = new System.Drawing.Point(56, 33);
            this.ngayvv.Name = "ngayvv";
            this.ngayvv.Size = new System.Drawing.Size(88, 22);
            this.ngayvv.TabIndex = 12;
            this.ngayvv.SelectedIndexChanged += new System.EventHandler(this.ngayvv_SelectedIndexChanged);
            this.ngayvv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngayvao_KeyDown);
            // 
            // soluutru
            // 
            this.soluutru.BackColor = System.Drawing.SystemColors.HighlightText;
            this.soluutru.Enabled = false;
            this.soluutru.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.soluutru.Location = new System.Drawing.Point(56, 56);
            this.soluutru.Name = "soluutru";
            this.soluutru.Size = new System.Drawing.Size(88, 22);
            this.soluutru.TabIndex = 22;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(-5, 54);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(64, 23);
            this.label13.TabIndex = 21;
            this.label13.Text = "Số lưu trữ :";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dataGrid1
            // 
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid1.CaptionBackColor = System.Drawing.SystemColors.Control;
            this.dataGrid1.CaptionForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGrid1.DataMember = "";
            this.dataGrid1.FlatMode = true;
            this.dataGrid1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(5, 87);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.Size = new System.Drawing.Size(870, 451);
            this.dataGrid1.TabIndex = 32;
            // 
            // lblpt
            // 
            this.lblpt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblpt.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblpt.ForeColor = System.Drawing.Color.Red;
            this.lblpt.Location = new System.Drawing.Point(528, 94);
            this.lblpt.Name = "lblpt";
            this.lblpt.Size = new System.Drawing.Size(91, 10);
            this.lblpt.TabIndex = 33;
            // 
            // tenkp
            // 
            this.tenkp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tenkp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenkp.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenkp.Location = new System.Drawing.Point(679, 33);
            this.tenkp.Name = "tenkp";
            this.tenkp.Size = new System.Drawing.Size(191, 22);
            this.tenkp.TabIndex = 20;
            this.tenkp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ngayvao_KeyDown);
            // 
            // chkKhoa
            // 
            this.chkKhoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkKhoa.Location = new System.Drawing.Point(5, 539);
            this.chkKhoa.Name = "chkKhoa";
            this.chkKhoa.Size = new System.Drawing.Size(137, 21);
            this.chkKhoa.TabIndex = 258;
            this.chkKhoa.Text = "Thanh toán theo khoa";
            this.chkKhoa.Click += new System.EventHandler(this.chkKhoa_Click);
            this.chkKhoa.CheckedChanged += new System.EventHandler(this.chkKhoa_CheckedChanged);
            // 
            // chkThuoc
            // 
            this.chkThuoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkThuoc.Location = new System.Drawing.Point(710, 539);
            this.chkThuoc.Name = "chkThuoc";
            this.chkThuoc.Size = new System.Drawing.Size(177, 21);
            this.chkThuoc.TabIndex = 259;
            this.chkThuoc.Text = "Tổng hợp thuốc + vật tư y tế";
            this.chkThuoc.CheckedChanged += new System.EventHandler(this.chkThuoc_CheckedChanged);
            // 
            // chkExcel
            // 
            this.chkExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkExcel.Location = new System.Drawing.Point(710, 556);
            this.chkExcel.Name = "chkExcel";
            this.chkExcel.Size = new System.Drawing.Size(95, 21);
            this.chkExcel.TabIndex = 260;
            this.chkExcel.Text = "Xuất ra Excel";
            this.chkExcel.CheckedChanged += new System.EventHandler(this.chkExcel_CheckedChanged);
            // 
            // chkAll
            // 
            this.chkAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkAll.Location = new System.Drawing.Point(5, 556);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(137, 21);
            this.chkAll.TabIndex = 261;
            this.chkAll.Text = "In tất cả";
            this.chkAll.Visible = false;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // chkHaophi
            // 
            this.chkHaophi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkHaophi.Location = new System.Drawing.Point(143, 539);
            this.chkHaophi.Name = "chkHaophi";
            this.chkHaophi.Size = new System.Drawing.Size(113, 21);
            this.chkHaophi.TabIndex = 262;
            this.chkHaophi.Text = "In cả hao phí";
            this.chkHaophi.Click += new System.EventHandler(this.chkHaophi_Click);
            // 
            // chkDoituong
            // 
            this.chkDoituong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkDoituong.Location = new System.Drawing.Point(234, 539);
            this.chkDoituong.Name = "chkDoituong";
            this.chkDoituong.Size = new System.Drawing.Size(137, 21);
            this.chkDoituong.TabIndex = 263;
            this.chkDoituong.Text = "In cột đối tượng";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(508, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 13);
            this.label6.TabIndex = 264;
            this.label6.Text = "Tiêu đề phiếu:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTieude
            // 
            this.txtTieude.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTieude.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtTieude.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTieude.Location = new System.Drawing.Point(585, 56);
            this.txtTieude.Name = "txtTieude";
            this.txtTieude.Size = new System.Drawing.Size(285, 22);
            this.txtTieude.TabIndex = 265;
            this.txtTieude.Text = "PHIẾU CÔNG KHAI THUỐC VÀ TỔNG HỢP VIỆN PHÍ";
            this.txtTieude.Validated += new System.EventHandler(this.txtTieude_Validated);
            // 
            // cmbDoituong
            // 
            this.cmbDoituong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cmbDoituong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDoituong.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDoituong.Location = new System.Drawing.Point(348, 82);
            this.cmbDoituong.Name = "cmbDoituong";
            this.cmbDoituong.Size = new System.Drawing.Size(120, 22);
            this.cmbDoituong.TabIndex = 267;
            this.cmbDoituong.SelectedIndexChanged += new System.EventHandler(this.cmbDoituong_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(260, 86);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(91, 13);
            this.label14.TabIndex = 266;
            this.label14.Text = "In theo đối tượng:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkInnhieuphieu
            // 
            this.chkInnhieuphieu.AutoSize = true;
            this.chkInnhieuphieu.Location = new System.Drawing.Point(480, 84);
            this.chkInnhieuphieu.Name = "chkInnhieuphieu";
            this.chkInnhieuphieu.Size = new System.Drawing.Size(93, 17);
            this.chkInnhieuphieu.TabIndex = 268;
            this.chkInnhieuphieu.Text = "In nhiều phiếu";
            this.chkInnhieuphieu.UseVisualStyleBackColor = true;
            this.chkInnhieuphieu.CheckedChanged += new System.EventHandler(this.chkInnhieuphieu_CheckedChanged);
            // 
            // chkNgay
            // 
            this.chkNgay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkNgay.Location = new System.Drawing.Point(342, 539);
            this.chkNgay.Name = "chkNgay";
            this.chkNgay.Size = new System.Drawing.Size(137, 21);
            this.chkNgay.TabIndex = 269;
            this.chkNgay.Text = "Lấy số liệu theo ngày";
            // 
            // frmCongkhai
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(880, 575);
            this.Controls.Add(this.chkNgay);
            this.Controls.Add(this.chkInnhieuphieu);
            this.Controls.Add(this.cmbDoituong);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtTieude);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.chkDoituong);
            this.Controls.Add(this.chkHaophi);
            this.Controls.Add(this.chkAll);
            this.Controls.Add(this.chkExcel);
            this.Controls.Add(this.chkThuoc);
            this.Controls.Add(this.chkKhoa);
            this.Controls.Add(this.tenkp);
            this.Controls.Add(this.soluutru);
            this.Controls.Add(this.butTiep);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.lblpt);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.phai);
            this.Controls.Add(this.ngayvv);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.diachi);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.chkVienphi);
            this.Controls.Add(this.ngayra);
            this.Controls.Add(this.sothe);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.chkXem);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ngayvao);
            this.Controls.Add(this.chandoan);
            this.Controls.Add(this.namsinh);
            this.Controls.Add(this.hoten);
            this.Controls.Add(this.m2);
            this.Controls.Add(this.m1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGrid1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCongkhai";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phiếu tổng hợp thuốc";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmCongkhai_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmCongkhai_Load(object sender, System.EventArgs e)
		{
            if (m.Thongso("frmCongkhai").Trim()!="")
                txtTieude.Text = lan.Change_language_MessageText(m.Thongso("frmCongkhai"));
            txtTieude.Text = txtTieude.Text.ToUpper();
            //if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            i_maxlength_mabn = m.i_maxlength_mabn;
            m2.MaxLength = i_maxlength_mabn;
            bNdot = m.bThanhtoan_ndot; user = m.user; stime = "'" + m.f_ngay + "'"; bThanhtoan_khoa = m.bThanhtoan_khoa;
			if (i_loaiba==1) chkVienphi.Enabled=false;
			else chkVienphi.Enabled=true;
            f_tao_t_congkhai();
            chkHaophi.Checked = m.Thongso("congkhai_incahaophi") == "1";
			bCapve=m.bCapve_noitru;
            chkKhoa.Checked = bThanhtoan_khoa || bNdot;
            sql = "select * from " + user + ".btdkp_bv where makp<>'01'";
            if (b_makp != "")
            {
                string s = b_makp.Replace(",", "','");
                sql += " and makp in ('" + s.Substring(0, s.Length - 3) + "')";
            }
            if (i_loaiba == 1) sql += " and loai=0";
            else if (i_loaiba == 3) sql += " and loai=1";
            sql += " order by makp";
            tenkp.DisplayMember = "TENKP";
            tenkp.ValueMember = "MAKP";
            tenkp.DataSource = m.get_data(sql).Tables[0];

			dsngay.ReadXml("..//..//..//xml//m_ngayvao.xml");
            dsngay.Tables[0].Columns.Add("tenbs");
            dsngay.Tables[0].Columns.Add("mabs");
            dsngay.Tables[0].Columns.Add("cholam");
            dsngay.Tables[0].Columns.Add("traituyen", typeof(decimal));

			ngayvv.DisplayMember="NGAYVAO";
			ngayvv.ValueMember="MAQL";
			ngayvv.DataSource=dsngay.Tables[0];
			songay=m.Ngaylv_Ngayht;
			chkXem.Checked=m.bPreview;
			m1.Text=DateTime.Now.Year.ToString().Substring(2,2);
            chkThuoc.Checked = m.Thongso("ckthuoc") == "1";
            chkExcel.Checked=m.Thongso("ckexcel")=="1";
            chkAll.Checked = m.Thongso("ckall") == "1";

            sql = "select madoituong,doituong from "+m.user+".doituong";
            
            dtdoituong = m.get_data(sql).Tables[0];
            dtdoituong.Rows.Add("0", "");
            cmbDoituong.DataSource = dtdoituong;
            cmbDoituong.DisplayMember = "doituong";
            cmbDoituong.ValueMember = "madoituong";
            cmbDoituong.SelectedIndex = dtdoituong.Rows.Count - 1;
		}

		private void m1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void m2_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void ngayvao_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void m1_Validated(object sender, System.EventArgs e)
		{
			m1.Text=m1.Text.PadLeft(2,'0');
		}

		private void m2_Validated(object sender, System.EventArgs e)
		{
			if (m2.Text=="")
			{
				m1.Text="";
				m1.Focus();
				return;
			}
			dsngay.Clear();
			m2.Text=m2.Text.PadLeft(6,'0');
			l_mavaovien=l_maql=l_id=0;
			s_mabn=m1.Text+m2.Text;
			if (chkKhoa.Checked && i_loaiba==1)
			{
				sql="select d.makp,d.tenkp,b.hoten, b.namsinh,b.phai,a.id,j.mavaovien,a.maql,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayvv, to_char(c.ngay,'dd/mm/yyyy hh24:mi') as ngayrv, case when c.chandoan is null then a.chandoan else c.chandoan end as chandoan,";
                sql+="case when c.maicd is null then a.maicd else c.maicd end as maicd,e.sothe, ";
                sql += "case when e.traituyen is null then 0 else e.traituyen end as traituyen,";
				sql+=" b.sonha,b.thon,f.tentt,g.tenquan,h.tenpxa,i.soluutru,c.chandoan as chandoanrv,b.cholam ";
                sql+=" from " + user + ".nhapkhoa a inner join " + user + ".btdbn b on a.mabn=b.mabn ";
                sql+=" left join " + user + ".xuatkhoa c on a.id=c.id ";
                sql+=" inner join " + user + ".btdkp_bv d on a.makp=d.makp ";
                sql+=" left join " + user + ".bhyt e on a.maql=e.maql ";
                sql+=" inner join " + user + ".btdtt f on b.matt=f.matt ";
                sql+=" inner join " + user + ".btdquan g on b.maqu=g.maqu ";
                sql+=" inner join " + user + ".btdpxa h on b.maphuongxa=h.maphuongxa ";
                sql+=" inner join " + user + ".lienhe i on a.maql=i.maql ";
                sql += " inner join " + user + ".benhandt j on a.maql=j.maql ";
				sql+=" where a.mabn='"+s_mabn+"' order by a.id desc ";
			}
			else
			{
                if (i_loaiba == 1)
                {
                    sql = "select d.makp,d.tenkp,b.hoten, b.namsinh,b.phai,0 as id,a.mavaovien,a.maql,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayvv, to_char(c.ngay,'dd/mm/yyyy hh24:mi') as ngayrv, case when c.chandoan is null then a.chandoan else c.chandoan end as chandoan,";
                    sql += "case when c.maicd is null then a.maicd else c.maicd end as maicd,e.sothe, ";
                    sql += " case when e.traituyen is null then 0 else e.traituyen end as traituyen,";
                    sql += " b.sonha,b.thon,f.tentt,g.tenquan,h.tenpxa,c.soluutru,c.chandoan as chandoanrv,b.cholam, a.sovaovien ";
                    sql += " from " + user + ".benhandt a inner join " + user + ".btdbn b on a.mabn=b.mabn ";
                    sql += " left join " + user + ".xuatvien c on a.maql=c.maql ";
                    sql += " inner join " + user + ".btdkp_bv d on a.makp=d.makp ";
                    sql += " left join " + user + ".bhyt e on a.maql=e.maql ";
                    sql += " inner join " + user + ".btdtt f on b.matt=f.matt ";
                    sql += " inner join " + user + ".btdquan g on b.maqu=g.maqu ";
                    sql += " inner join " + user + ".btdpxa h on b.maphuongxa=h.maphuongxa ";
                    sql += " where a.mabn='" + s_mabn + "' order by a.maql desc ";
                }
                else
                {
                    sql = "select d.makp,d.tenkp,b.hoten, b.namsinh,b.phai,0 as id,a.mavaovien,a.maql,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngayvv, to_char(a.ngayrv,'dd/mm/yyyy hh24:mi') as ngayrv, case when a.chandoanrv is null then a.chandoan else a.chandoanrv end as chandoan,";
                    sql += "case when a.maicdrv is null then a.maicd else a.maicdrv end as maicd,e.sothe, ";
                    sql += " case when e.traituyen is null then 0 else e.traituyen end as traituyen,";
                    sql += " b.sonha,b.thon,f.tentt,g.tenquan,h.tenpxa,a.soluutru,a.chandoanrv,b.cholam, a.sovaovien ";
                    sql += " from " + user + ".benhanngtr a inner join " + user + ".btdbn b on a.mabn=b.mabn ";
                    sql += " inner join " + user + ".btdkp_bv d on a.makp=d.makp ";
                    sql += " left join " + user + ".bhyt e on a.maql=e.maql ";
                    sql += " inner join " + user + ".btdtt f on b.matt=f.matt ";
                    sql += " inner join " + user + ".btdquan g on b.maqu=g.maqu ";
                    sql += " inner join " + user + ".btdpxa h on b.maphuongxa=h.maphuongxa ";
                    sql += " where a.mabn='" + s_mabn + "' order by a.maql desc ";
                }
			}
			ds=m.get_data(sql);
			if (ds.Tables[0].Rows.Count==0)
			{
				MessageBox.Show(lan.Change_language_MessageText("Không tìm thấy !"),LibMedi.AccessData.Msg);
				m1.Focus();
				return;
			}
			int i=1;
            m_sovaovien = "";
			foreach(DataRow r in ds.Tables[0].Rows)
			{
				if (i==1)
				{
                    l_mavaovien = long.Parse(r["mavaovien"].ToString());
					l_maql=long.Parse(r["maql"].ToString());
					l_id=long.Parse(r["id"].ToString());
					hoten.Text=r["hoten"].ToString();
					namsinh.Text=r["namsinh"].ToString();
					phai.Text=(int.Parse(r["phai"].ToString())==1)?"Nữ":"Nam";				
					diachi.Text=r["sonha"].ToString().Trim()+" "+r["thon"].ToString().Trim()+" "+r["tenpxa"].ToString().Trim()+"-"+r["tenquan"].ToString().Trim()+"-"+r["tentt"].ToString().Trim();
					chandoan.Text=r["chandoan"].ToString()+" ["+r["maicd"].ToString()+"]";
					int dd=int.Parse(r["ngayvv"].ToString().Substring(0,2));
					int mm=int.Parse(r["ngayvv"].ToString().Substring(3,2));
					int yyyy=int.Parse(r["ngayvv"].ToString().Substring(6,4));
					int hh=int.Parse(r["ngayvv"].ToString().Substring(11,2));
					int mi=int.Parse(r["ngayvv"].ToString().Substring(14,2));
					ngayvao.Value=new DateTime(yyyy,mm,dd,hh,mi,0);
					ngayra.Text=r["ngayrv"].ToString();
					tenkp.SelectedValue=r["makp"].ToString();
					sothe.Text=r["sothe"].ToString();
                    soluutru.Text = r["soluutru"].ToString() + "^" + r["sovaovien"].ToString();
                    m_sovaovien = r["sovaovien"].ToString();
                    chkVienphi.Checked=r["chandoanrv"].ToString().Trim()!="" && chkKhoa.Checked==false;
                    //
                    get_phong_giuong(m1.Text + m2.Text, l_maql.ToString(), l_id.ToString(), r["makp"].ToString(), ref m_phong, ref m_giuong);
                    get_tong_tamung(ngayvao.Text.Substring(0, 10), (ngayra.Text.Trim().Length > 10) ? ngayra.Text.Substring(0, 10) : ngayvao.Text.Substring(0, 10), m1.Text + m2.Text, l_mavaovien.ToString(), l_maql.ToString(), ref d_sttamung);
                    //
				}
				i++;
				m.updrec_ravien(dsngay,s_mabn,long.Parse(r["mavaovien"].ToString()),long.Parse(r["maql"].ToString()),long.Parse(r["id"].ToString()),
					r["hoten"].ToString(),r["namsinh"].ToString(),(r["phai"].ToString()=="0")?"Nam":"Nữ",r["sonha"].ToString().Trim()+" "+r["thon"].ToString().Trim()+", "+r["tenpxa"].ToString().Trim()+", "+r["tenquan"].ToString().Trim()+", "+r["tentt"].ToString().Trim(),
					0,"",r["sothe"].ToString(),"","","","",r["chandoanrv"].ToString(),r["tenkp"].ToString(),r["ngayvv"].ToString(),r["ngayrv"].ToString(),
					r["chandoan"].ToString(),r["maicd"].ToString(),"",2,0,1,r["soluutru"].ToString()+"^"+r["sovaovien"].ToString(),"","",r["cholam"].ToString(),int.Parse(r["traituyen"].ToString()));
			}			
			if(ngayra.Text=="")ngayra.Text=m.Ngaygio_hienhanh;
		}

		private void butTiep_Click(object sender, System.EventArgs e)
		{
            m2.Text = hoten.Text = namsinh.Text = phai.Text = ngayra.Text = chandoan.Text = sothe.Text = diachi.Text = soluutru.Text = "";
            m_sovaovien = m_giuong = m_phong = "";
            l_mavaovien = l_maql = l_id = 0;
			dsngay.Clear();
			dataGrid1.DataSource=null;
			lblpt.Text="";
			m1.Focus();
			chkVienphi.Checked=false;
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
            m.writeXml("thongso", "frmCongkhai", txtTieude.Text);
			m.close();this.Close();
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
            //
            chkVienphi.Checked = false;
            //
			d.check_process_Excel();
			if(m2.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Đề nghị nhập mã BN"));
				return;
			}
            if (chkInnhieuphieu.Checked)
                chkDoituong.Checked = true;
            //if (cmbDoituong.Text.Trim() != "")
            //    chkDoituong.Checked = true;
			if (chkVienphi.Checked && !bThanhtoan_khoa && !chkThuoc.Checked) m.get_thanhtoan(l_maql,l_id,ngayvao.Text,ngayra.Text,i_loaiba,m.bThanhtoan_khoa,tenuser,i_userid);
			gan_data();            
            if (chkVienphi.Checked || chkExcel.Checked)
            {
                if (cmbDoituong.Text.Trim() != "" || (cmbDoituong.Text.Trim() == "" && chkInnhieuphieu.Checked))
                    imp_excel2();
                else
                    imp_excel();
            }
            else
            {
                string sql, tenpt = "";
                sql = "select a.tenpt,to_char(a.ngay,'dd/mm/yyyy') as ngay,c.ten as loaipt,a.somat,a.molaimien from xxx.pttt a," + user + ".dmpttt b," + user + ".loaipttt c where a.mapt=b.mapt and b.loaipt=c.ma and a.mabn='" + m1.Text + m2.Text + "'";
                sql += " and " + m.for_ngay("a.ngay", stime) + " between to_date('" + ngayvao.Text.Substring(0, 10) + "'," + stime + ") and to_date('" + ngayra.Text.Substring(0, 10) + "'," + stime + ")";
                foreach (DataRow r in m.get_data_mmyy(sql, ngayvao.Text, ngayra.Text, false).Tables[0].Rows)
                {
                    tenpt += r["tenpt"].ToString().Trim() + "(" + r["loaipt"].ToString().Trim() + ";" + r["ngay"].ToString() + ";" + r["somat"].ToString() + ")";
                    tenpt += (r["molaimien"].ToString() == "1") ? " MỔ LẠI MIỄN" : "";
                }
                lblpt.Text = tenpt;
                load_grid();
            }
			butTiep.Focus();
		}

		private void load_grid()
		{
            //foreach(System.Windows.Forms.Control c in this.Controls) if (c.Name=="dataGrid1") this.Controls.Remove(c);
            //dataGrid1=new System.Windows.Forms.DataGrid();
            //this.dataGrid1.BackgroundColor = System.Drawing.SystemColors.Control;
            //this.dataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            //this.dataGrid1.CaptionBackColor = System.Drawing.SystemColors.Control;
            //this.dataGrid1.CaptionForeColor = System.Drawing.SystemColors.ActiveCaption;
            //this.dataGrid1.DataMember = "";
            //this.dataGrid1.FlatMode = true;
            //this.dataGrid1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            //this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            //this.dataGrid1.Location = new System.Drawing.Point(5, 101);
            //this.dataGrid1.Name = "dataGrid1";
            //this.dataGrid1.RowHeaderWidth = 10;
            //this.dataGrid1.Size = new System.Drawing.Size(784, 409);
            //this.dataGrid1.TabIndex = 32;
            dataGrid1.DataSource = dt;
            AddGridTableStyle();
            //this.Controls.Add(dataGrid1);
		}

		private void AddGridTableStyle()
		{
			DataGridTableStyle ts1=new DataGridTableStyle();
			DataGridColoredTextBoxColumn TextCol;
			delegateGetColorRowCol de = new delegateGetColorRowCol(MyGetColorRowCol);
			ts1.MappingName = dt.TableName;
			ts1.AlternatingBackColor = Color.Beige;
			ts1.BackColor = Color.GhostWhite;
			ts1.ForeColor = Color.MidnightBlue;
			ts1.GridLineColor = Color.RoyalBlue;
			ts1.HeaderBackColor = Color.MidnightBlue;
			ts1.HeaderForeColor = Color.Lavender;
			ts1.SelectionBackColor = Color.Teal;
			ts1.SelectionForeColor = Color.PaleGreen;
			ts1.ReadOnly=false;
			ts1.RowHeaderWidth=5;

			TextCol=new DataGridColoredTextBoxColumn(de, 0);
			TextCol.MappingName = "loai";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts1.GridColumnStyles.Add(TextCol);
			

			TextCol=new DataGridColoredTextBoxColumn(de, 1);
			TextCol.MappingName = "tenbd";
			TextCol.HeaderText = "Tên thuốc - hàm lượng";
			TextCol.Width = 200;
			ts1.GridColumnStyles.Add(TextCol);
			

			TextCol=new DataGridColoredTextBoxColumn(de, 2);
			TextCol.MappingName = "dangbd";
			TextCol.HeaderText = "ĐVT";
			TextCol.Width = 40;
			ts1.GridColumnStyles.Add(TextCol);
			
			int i=3,cot;
            if (chkDoituong.Checked) cot = 7;
            else cot = 6;
            string ngay;
            for (; i < dt.Columns.Count - cot; i++)
            {
                ngay = dt.Columns[i].ColumnName.ToString().Substring(2);
                TextCol = new DataGridColoredTextBoxColumn(de, i);
                TextCol.MappingName = dt.Columns[i].ColumnName.ToString();
                TextCol.HeaderText = (ngay.Length == 8 ? (ngay.Substring(6, 2) + "/" + ngay.Substring(4, 2)) : "TC");
                TextCol.Width = 40;
                TextCol.Format = "#,###,###.##";
                TextCol.Alignment = HorizontalAlignment.Right;
                ts1.GridColumnStyles.Add(TextCol);
                
            }
			TextCol=new DataGridColoredTextBoxColumn(de,i);
			TextCol.MappingName = "tongso";
			TextCol.HeaderText = "Tổng số";
			TextCol.Width = 60;
			TextCol.Format="#,###,###.##";
			TextCol.Alignment=HorizontalAlignment.Right;
			ts1.GridColumnStyles.Add(TextCol);
			

			TextCol=new DataGridColoredTextBoxColumn(de,i+1);
			TextCol.MappingName = "dongia";
			TextCol.HeaderText = "Đơn giá";
			TextCol.Width = 80;
			TextCol.Format="#,###,###.##";
			TextCol.Alignment=HorizontalAlignment.Right;
			ts1.GridColumnStyles.Add(TextCol);
			

			TextCol=new DataGridColoredTextBoxColumn(de,i+2);
			TextCol.MappingName = "thanhtien";
			TextCol.HeaderText = "Số tiền";
			TextCol.Width = 80;
			TextCol.Format="#,###,###.##";
			TextCol.Alignment=HorizontalAlignment.Right;
			ts1.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Clear();
            dataGrid1.TableStyles.Add(ts1);
		}

		public Color MyGetColorRowCol(int row, int col)
		{
			return (dataGrid1[row,0].ToString()=="1")?Color.Blue:Color.Black;
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
					foreBrush = new SolidBrush(_getColorRowCol(rowNum, this._column));
					//backBrush = new SolidBrush(Color.GhostWhite);
				}
				catch{}
				finally
				{
					base.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight);
				}
			}
		}

        private void gan_data()
        {
            col = 0;
            string maso = "";
            if (i_loaiba == 2)
            {
                maso = l_maql.ToString() + ",";
                foreach (DataRow r in m.get_data_mmyy("select maql from xxx.benhanpk where mangtr=" + l_maql, ngayvao.Text.Substring(0, 10), ngayra.Text.Substring(0, 10), false).Tables[0].Rows)
                    maso += r["maql"].ToString() + ",";
            }
            if (chkDoituong.Checked == false&&(cmbDoituong.SelectedText.Trim()==""&&chkInnhieuphieu.Checked==false))
                ds1 = get_congkhai(ngayvao.Text, ngayra.Text, m1.Text + m2.Text, l_maql, l_id, maso);
            else
                ds1 = get_congkhai_doituong(ngayvao.Text, ngayra.Text, m1.Text + m2.Text, l_maql, l_id, maso);
            dttmp = new System.Data.DataTable();

            dc = new DataColumn();
            dc.ColumnName = "NGAY";
            dc.DataType = Type.GetType("System.String");
            dc.MaxLength = 8;
            dttmp.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "SOLUONG";
            dc.DataType = Type.GetType("System.Decimal");
            dttmp.Columns.Add(dc);

            dt = new System.Data.DataTable();

            dc = new DataColumn();
            dc.ColumnName = "MABD";
            dc.DataType = Type.GetType("System.String");
            dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "TENBD";
            dc.DataType = Type.GetType("System.String");
            dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "DANGBD";
            dc.DataType = Type.GetType("System.String");
            dt.Columns.Add(dc);

            //foreach (DataRow r in ds1.Tables[0].Select("true", "ngay,stt,nhomvp,tenbd"))//loai
            foreach (DataRow r in ds1.Tables[0].Select("true", "ngay,sttnhom,nhomvp,tenbd"))//loai
            {
                if (updrec_p_congkhai(dttmp, r["ngay"].ToString(), double.Parse(r["sotien"].ToString())))
                {
                    dc = new DataColumn();
                    dc.ColumnName = "C_" + r["ngay"].ToString();
                    dc.DataType = Type.GetType("System.Decimal");
                    dt.Columns.Add(dc);
                    col++;
                }
            }
            dc = new DataColumn();
            dc.ColumnName = "TONGSO";
            dc.DataType = Type.GetType("System.Decimal");
            dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "DONGIA";
            dc.DataType = Type.GetType("System.Decimal");
            dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "THANHTIEN";
            dc.DataType = Type.GetType("System.Decimal");
            dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "STT";
            dc.DataType = Type.GetType("System.Decimal");
            dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "NHOMVP";
            dc.DataType = Type.GetType("System.String");
            dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "LOAI";
            dc.DataType = Type.GetType("System.Decimal");
            dt.Columns.Add(dc);            

            if (chkDoituong.Checked)
            {
                dc = new DataColumn();
                dc.ColumnName = "DOITUONG";
                dc.DataType = Type.GetType("System.String");
                dt.Columns.Add(dc);
                //Tu:08/08/2011 thêm cột sttnhom để sort
                dc = new DataColumn();
                dc.ColumnName = "STTNHOM";
                dc.DataType = Type.GetType("System.Decimal");
                dt.Columns.Add(dc);//end Tu

                //foreach (DataRow r in ds1.Tables[0].Select("true", "stt,nhomvp,ngay,tenbd"))
                foreach (DataRow r in ds1.Tables[0].Select("true", "ngay,sttnhom,nhomvp,tenbd"))
                {
                    for (int i = 3; i < dt.Columns.Count - 6; i++)
                    {
                        if (r["ngay"].ToString() == dt.Columns[i].ToString().Substring(2, 8))
                        {
                            updrec_p_congkhai_doituong(dt, r["loai"].ToString(), r["stt"].ToString(), r["nhomvp"].ToString(), r["mabd"].ToString(), r["tenbd"].ToString(), r["dangbd"].ToString(), double.Parse(r["soluong"].ToString()), double.Parse(r["dongia"].ToString()), i, r["doituong"].ToString(),int.Parse(r["sttnhom"].ToString()));
                            break;
                        }
                    }
                }
            }
            else
            {
                dc = new DataColumn();
                dc.ColumnName = "DOITUONG";
                dc.DataType = Type.GetType("System.String");
                dt.Columns.Add(dc);
                //Tu:08/08/2011 thêm cột sttnhom để sort
                dc = new DataColumn();
                dc.ColumnName = "STTNHOM";
                dc.DataType = Type.GetType("System.Decimal");
                dt.Columns.Add(dc);//end Tu
                //foreach (DataRow r in ds1.Tables[0].Select("true", "stt,nhomvp,ngay,tenbd"))
                foreach (DataRow r in ds1.Tables[0].Select("true", "ngay,sttnhom,nhomvp,tenbd"))
                {
                    for (int i = 3; i < dt.Columns.Count - 6; i++)
                    {
                        if (r["ngay"].ToString() == dt.Columns[i].ToString().Substring(2, 8))
                        {
                            updrec_p_congkhai(dt, r["loai"].ToString(), r["stt"].ToString(), r["nhomvp"].ToString(), r["mabd"].ToString(), r["tenbd"].ToString(), r["dangbd"].ToString(), double.Parse(r["soluong"].ToString()), double.Parse(r["dongia"].ToString()), i,int.Parse(r["sttnhom"].ToString()),r["doituong"].ToString());
                            break;
                        }
                    }
                }
            }
        }

		private void sort()
		{
			System.Data.DataTable dt1=new System.Data.DataTable();
			dt1=dt.Copy();
			dt.Clear();
			string nhomvp="";
			DataRow r1;
			//foreach(DataRow r in dt1.Select("true","stt,nhomvp,tenbd"))
            foreach (DataRow r in dt1.Select("true", "sttnhom,nhomvp,tenbd"))
			{
				if (r["nhomvp"].ToString()!=nhomvp)
				{
					r1=dt.NewRow();
					r1["mabd"]=0;
                    r1["tenbd"] = r["nhomvp"].ToString().ToUpper();
					r1["dangbd"]="";
					for(int i=3;i<dt1.Columns.Count-6;i++) r1[i]=0;
					r1["tongso"]=0;
					r1["dongia"]=0;
					r1["thanhtien"]=sum(r["nhomvp"].ToString(),dt1);
					dt.Rows.Add(r1);
					nhomvp=r["nhomvp"].ToString();
				}
				r1=dt.NewRow();
				for(int i=0;i<dt1.Columns.Count;i++) r1[i]=r[i].ToString();
				dt.Rows.Add(r1);
			}
		}
        System.Data.DataTable dttam2 = new System.Data.DataTable();
        private void sort2(string s_doituong)
        {
            System.Data.DataTable dt1 = new System.Data.DataTable();
            dt1 = dt.Copy(); //dt1.Columns.Remove("STTNHOM");
            dttam2.Clear(); //dttam2.Columns.Add("STTNHOM");
            string nhomvp = "";
            DataRow r1;
            
            //foreach (DataRow r in dt1.Select("doituong='"+s_doituong+"'", "stt,nhomvp,tenbd"))
            foreach (DataRow r in dt1.Select("doituong='" + s_doituong + "'", "sttnhom,nhomvp,tenbd"))
            {
                if (r["nhomvp"].ToString() != nhomvp)
                {
                    r1 = dttam2.NewRow();
                    r1["mabd"] = 0;
                    r1["tenbd"] = r["nhomvp"].ToString().ToUpper();
                    r1["dangbd"] = "";
                    for (int i = 3; i < dt1.Columns.Count - 6; i++) r1[i] = 0;
                    r1["tongso"] = 0;
                    r1["dongia"] = 0;
                    r1["thanhtien"] = sum_doituong(r["nhomvp"].ToString(), s_doituong, dt1);
                    //r1["STTNHOM"] = r["STTNHOM"].ToString();
                    dttam2.Rows.Add(r1);
                    nhomvp = r["nhomvp"].ToString();                    
                }
                r1 = dttam2.NewRow();
                for (int i = 0; i < dt1.Columns.Count; i++) r1[i] = r[i].ToString();
                dttam2.Rows.Add(r1);
            }
        }

		private decimal sum(string nhomvp,System.Data.DataTable tmp)
		{
			decimal  tc=0;
            string exp = "nhomvp='" + nhomvp + "'";

			foreach(DataRow r in tmp.Select(exp)) tc+=decimal.Parse(r["tongso"].ToString())*decimal.Parse(r["dongia"].ToString());
			return tc;
		}

        private decimal sum_doituong(string nhomvp, string m_doituong, System.Data.DataTable tmp)
        {
            decimal tc = 0;
            string exp = "nhomvp='" + nhomvp + "'";
            exp += " and doituong='" + m_doituong + "'";
            foreach (DataRow r in tmp.Select(exp)) tc += decimal.Parse(r["tongso"].ToString()) * decimal.Parse(r["dongia"].ToString());
            return tc;
        }
		private void imp_excel()
		{
            try
            {
                sort();
                try { dt.Columns.Remove("STTNHOM"); }
                catch { }
                string sql, tenpt = "";
                sql = "select a.tenpt,to_char(a.ngay,'dd/mm/yyyy') as ngay,c.ten as loaipt,a.somat,a.molaimien from xxx.pttt a," + user + ".dmpttt b," + user + ".loaipttt c where a.mapt=b.mapt and b.loaipt=c.ma and a.mabn='" + m1.Text + m2.Text + "'";
                sql += " and " + m.for_ngay("a.ngay", stime) + " between to_date('" + ngayvao.Text.Substring(0, 10) + "'," + stime + ") and to_date('" + ngayra.Text.Substring(0, 10) + "'," + stime + ")";
                foreach (DataRow r in m.get_data_mmyy(sql, ngayvao.Text, ngayra.Text, false).Tables[0].Rows)
                {
                    tenpt += r["tenpt"].ToString().Trim() + "(" + r["loaipt"].ToString().Trim() + ";" + r["ngay"].ToString() + ";" + r["somat"].ToString() + ")";
                    tenpt += (r["molaimien"].ToString() == "1") ? " MỔ LẠI MIỄN" : "";
                }

                oxl = new Excel.Application();
                owb = (Excel._Workbook)(oxl.Workbooks.Add(Missing.Value));
                osheet = (Excel._Worksheet)owb.ActiveSheet;

                int i, j, be = 11, cot = dt.Columns.Count, dong = dt.Rows.Count;
                int i_rowbegin = 10;//8
                int tuoi = int.Parse(DateTime.Now.Year.ToString()) - int.Parse(namsinh.Text.ToString());
                string ten = "";
                double ftc = 0;
                osheet.Cells[i_rowbegin, 1] = "TT"; //osheet.Cells[8, 1] = "TT";
                int icol_sol = 7;
                if (chkDoituong.Checked) icol_sol = 7;
                for (i = 1; i < cot - icol_sol; i++)
                {
                    ten = dt.Columns[i].ColumnName.ToString();
                    if (i > 2) ten = "'" + ten.Substring(8, 2).PadLeft(2, '0') + "/" + ten.Substring(6, 2).PadLeft(2, '0');//+"/"+ten.Substring(2,4);
                    else ten = (i == 1) ? "Tên thuốc,hàm lượng" : "Đơn vị";
                    osheet.Cells[i_rowbegin, i + 1] = ten;
                }

                osheet.Cells[i_rowbegin, i + 1] = "Tổng số";
                osheet.Cells[i_rowbegin, i + 2] = "Đơn giá";
                osheet.Cells[i_rowbegin, i + 3] = "Thành tiền";
                if (chkDoituong.Checked) osheet.Cells[i_rowbegin, i + 4] = "Đối tượng";
                //osheet.Cells[8,i+4]="Ghi chú";            
                int stt = 1, tt;
                icol_sol = 4;
                if (chkDoituong.Checked) icol_sol = 4;
                for (i = 0; i < dong; i++)
                {
                    tt = i + be;
                    if (dt.Rows[i]["mabd"].ToString() == "0") osheet.get_Range(m.getIndex(0) + tt.ToString(), m.getIndex(cot) + tt.ToString()).Font.Bold = true;
                    else osheet.Cells[i + be, 1] = stt;
                    for (j = 1; j < cot - icol_sol; j++) osheet.Cells[i + be, j + 1] = dt.Rows[i][j].ToString();
                    if (chkDoituong.Checked) osheet.Cells[i + be, j + 1] = dt.Rows[i][j + icol_sol - 1].ToString();
                    //osheet.Cells[i+be,cot-3]=double.Parse(dt.Rows[i][cot-6].ToString())*double.Parse(dt.Rows[i][cot-5].ToString());
                    //ftc+=double.Parse(dt.Rows[i][cot-6].ToString())*double.Parse(dt.Rows[i][cot-5].ToString());
                    ftc += double.Parse(dt.Rows[i][cot - icol_sol - 2].ToString()) * double.Parse(dt.Rows[i][cot - icol_sol - 3].ToString());
                    if (dt.Rows[i]["mabd"].ToString() != "0") stt++;
                }
                //oxl.Visible = true;
                //return;
                j = 4;
                osheet.Cells[dong + be, cot - icol_sol] = ftc;
                if (chkDoituong.Checked==false) cot = cot - 1;
                osheet.get_Range(m.getIndex(2) + i_rowbegin.ToString(), m.getIndex(cot - 6) + i_rowbegin.ToString()).Orientation = 90;//osheet.get_Range(m.getIndex(2)+"8",m.getIndex(cot-6)+"8").Orientation=90;
                orange = osheet.get_Range(m.getIndex(0) + i_rowbegin.ToString(), m.getIndex(1) + i_rowbegin.ToString());
                orange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                orange.HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;
                orange = osheet.get_Range(m.getIndex(cot - col - 6) + i_rowbegin.ToString(), m.getIndex(cot) + i_rowbegin.ToString());
                orange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                orange.HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;
                dong += be;
                osheet.get_Range(m.getIndex(0) + dong.ToString(), m.getIndex(cot) + dong.ToString()).Font.Bold = true;
                osheet.Cells[dong, 2] = "TỔNG CỘNG";
                dong = dong + 1;
                osheet.get_Range(m.getIndex(0) + dong.ToString(), m.getIndex(cot) + dong.ToString()).Font.Bold = true;
                osheet.Cells[dong, 2] = "Người bệnh ký tên mỗi ngày";
                int line = dong + 1;
                osheet.get_Range(d.getIndex(0) + i_rowbegin.ToString(), d.getIndex(cot - 4) + dong.ToString()).Borders.LineStyle = XlBorderWeight.xlHairline;
                osheet.get_Range(d.getIndex(cot - 6) + i_rowbegin.ToString(), d.getIndex(cot - 4) + dong.ToString()).NumberFormat = "#,##0.00";
                dong += 4;
                //osheet.get_Range(m.getIndex(0) + i_rowbegin.ToString(), m.getIndex(cot - 4) + dong.ToString()).EntireColumn.AutoFit();
                osheet.get_Range(m.getIndex(0) + i_rowbegin.ToString(), m.getIndex(cot - 5) + dong.ToString()).EntireColumn.AutoFit();
                osheet.Cells[line, 1] = tenpt;
                //osheet.Cells[line+3,1]=nhomvp;
                //if (chkThuoc.Checked)
                //{
                //osheet.Cells[line + 1, 1] = "Người bệnh ký tên mỗi ngày";
                //osheet.Cells[line + 3, 1] = "Xác nhận của bệnh nhân/Người nhà bệnh nhân";
                osheet.Cells[line + 2, cot - 4] = "Ngày       tháng     năm";// "Người lập biểu";
                osheet.Cells[line + 3, cot - 4] = "ĐD Phụ Trách";// "Người lập biểu";
                //}
                //else osheet.Cells[line + 3, cot - 6] = "Y TÁ HÀNH CHÁNH";
                osheet.Cells[1, 1] = m.Syte;
                osheet.Cells[2, 1] = m.Tenbv;
                osheet.Cells[1, 11] = "MS : 18D/BV - 01";
                osheet.Cells[2, 11] = "Số vào viện : " + m_sovaovien;
                //Khuong sua cho van phuc, xuat theo tieu de nhap tren form
                osheet.Cells[3, 3] = txtTieude.Text;
                //osheet.Cells[2, 3] = "PHIẾU CÔNG KHAI THUỐC "+((chkThuoc.Checked) ? "" : "DỊCH VỤ");             
                //osheet.Cells[2,3]="VÀ THANH TOÁN TIỀN CHO BỆNH NHÂN RA VIỆN";
                osheet.get_Range("C2", "C3").Font.Size = 11;
                osheet.get_Range("C2", "C3").Font.Bold = true;
                if ((cmbDoituong.SelectedText.Trim() == "" && chkInnhieuphieu.Checked) || cmbDoituong.SelectedText.Trim() != "")
                {
                    osheet.Cells[4, 3] = "Đối tượng :";
                    osheet.get_Range("C4", "D4").Font.Size = 11;
                    osheet.get_Range("C4", "D4").Font.Bold = true;
                }
                osheet.Cells[5, 1] = "Khoa :" + tenkp.Text;
                osheet.Cells[6, 1] = "Họ tên người bệnh :" + hoten.Text.Trim() + " (" + m1.Text + m2.Text + ")";
                osheet.Cells[6, 6] = "Tuổi: " + tuoi.ToString().Trim() + ", Giới tính: " + phai.Text;
                osheet.Cells[7, 1] = "Địa chỉ: " + diachi.Text.Trim() + ", Số thẻ " + sothe.Text.Trim();// +" Buồng : " + " Giường :";
                //osheet.Cells[4, 9] = "Số thẻ " + sothe.Text.Trim();
                //osheet.Cells[6,1]="Số giường :"+"";
                //osheet.Cells[6,3]="Số lưu trữ :"+soluutru.Text;//"Buồng :";
                osheet.Cells[8, 1] = "Phòng: " + m_phong + ", giường: " + m_giuong + ", Ngày vào: " + ngayvao.Text.Trim() + ", Ngày ra :" + ngayra.Text.Trim() + ", Tạm ứng: " + d_sttamung.ToString("###,###,###.0#");
                osheet.Cells[9, 1] = "Chẩn đoán : " + chandoan.Text.Trim();
                //Tu:10/08/2011
                foreach (DataRow r in ds1.Tables[0].Select("true", "ngay desc"))//loai
                {
                    string s_ngay = r["ngay"].ToString();
                    s_ngay = s_ngay.Substring(6, 2) + "/" + s_ngay.Substring(4, 2) + "/" + s_ngay.Substring(0, 4);
                    long songaydt = m.songay(m.StringToDate(s_ngay), m.StringToDate(ngayvao.Text.Substring(0, 10)), 1);
                    osheet.Cells[9, 6] = "Tổng số ngày điều trị : " + songaydt;
                    break;
                }
                //end Tu

                //osheet.Cells[6,9]="Ngày vào viện :"+ngayvao.Text.Trim();			
                //osheet.Cells[7,9]="Ngày ra viện : "+ngayra.Text.Trim();
                try { osheet.PageSetup.Orientation = XlPageOrientation.xlLandscape; }
                catch { }
                //osheet.PageSetup.PaperSize=XlPaperSize.xlPaperA4;
                oxl.ActiveWindow.DisplayZeros = false;
                if (chkXem.Checked) oxl.Visible = true;
                else osheet.PrintOut(Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            }
            catch { }
		}
        private void imp_excel2()
        {
            try
            {
                //sort2();
                dttam2 = dt.Copy();
                //try { dttam2.Columns.Remove("STTNHOM"); }
                //catch { }
                DataSet dsPhieu = new DataSet();
                System.Data.DataTable dttam1 = new System.Data.DataTable();
                if (cmbDoituong.Text == "")
                {
                    for (int ii = 0; ii < dtdoituong.Rows.Count; ii++)
                    {

                        sort2(dtdoituong.Rows[ii]["doituong"].ToString());

                        //if (dt.Select("madoituong=" + dtdoituong.Rows[ii]["madoituong"].ToString()).Length != 0)
                        //{

                        if (dttam2.Rows.Count != 0)
                        {
                            //dttam1.TableName = dtdoituong.Rows[ii]["madoituong"].ToString();
                            dttam1 = dttam2.Copy();
                            dttam1.TableName = dtdoituong.Rows[ii]["madoituong"].ToString();
                            dsPhieu.Tables.Add(dttam1);
                        }



                        //    DataRow r = dt.NewRow();
                        //}
                    }
                }
                else
                {
                    sort2(cmbDoituong.Text);

                    //if (dt.Select("madoituong=" + dtdoituong.Rows[ii]["madoituong"].ToString()).Length != 0)
                    //{

                    if (dttam2.Rows.Count != 0)
                    {
                        //dttam1.TableName = dtdoituong.Rows[ii]["madoituong"].ToString();
                        dttam1 = dttam2.Copy();
                        dttam1.TableName = cmbDoituong.SelectedValue.ToString();
                        dsPhieu.Tables.Add(dttam1);
                    }
                }

                try { dsPhieu.Tables[0].Columns.Remove("STTNHOM"); dsPhieu.Tables[0].Columns.Remove("DOITUONG"); }
                catch { }
                //dsPhieu.Tables[0].Columns.Remove("DOITUONG");
                string sql, tenpt = "";
                sql = "select a.tenpt,to_char(a.ngay,'dd/mm/yyyy') as ngay,c.ten as loaipt,a.somat,a.molaimien from xxx.pttt a," + user + ".dmpttt b," + user + ".loaipttt c where a.mapt=b.mapt and b.loaipt=c.ma and a.mabn='" + m1.Text + m2.Text + "'";
                sql += " and " + m.for_ngay("a.ngay", stime) + " between to_date('" + ngayvao.Text.Substring(0, 10) + "'," + stime + ") and to_date('" + ngayra.Text.Substring(0, 10) + "'," + stime + ")";
                foreach (DataRow r in m.get_data_mmyy(sql, ngayvao.Text, ngayra.Text, false).Tables[0].Rows)
                {
                    tenpt += r["tenpt"].ToString().Trim() + "(" + r["loaipt"].ToString().Trim() + ";" + r["ngay"].ToString() + ";" + r["somat"].ToString() + ")";
                    tenpt += (r["molaimien"].ToString() == "1") ? " MỔ LẠI MIỄN" : "";
                }

                oxl = new Excel.Application();
                owb = (Excel._Workbook)(oxl.Workbooks.Add(Missing.Value));
                foreach (System.Data.DataTable dtt in dsPhieu.Tables)
                {
                    osheet = (Excel._Worksheet)owb.Sheets.Add(Missing.Value, Missing.Value, Missing.Value, Missing.Value);//.ActiveSheet;
                    osheet.Name = m.getrowbyid(dtdoituong, "madoituong=" + dtt.TableName)["doituong"].ToString();
                    int i, j, be = 11, cot = dtt.Columns.Count, dong = dtt.Rows.Count;
                    int tuoi = int.Parse(DateTime.Now.Year.ToString()) - int.Parse(namsinh.Text.ToString());
                    string ten = "";
                    double ftc = 0;
                    int i_rowbegin = 10;//8
                    osheet.Cells[i_rowbegin, 1] = "TT"; //osheet.Cells[8, 1] = "TT";
                    int icol_sol = 6;
                    if (chkDoituong.Checked) icol_sol = 7;
                    for (i = 1; i < cot - icol_sol; i++)
                    {
                        ten = dtt.Columns[i].ColumnName.ToString();
                        if (i > 2) ten = "'" + ten.Substring(8, 2).PadLeft(2, '0') + "/" + ten.Substring(6, 2).PadLeft(2, '0');//+"/"+ten.Substring(2,4);
                        else ten = (i == 1) ? "Tên thuốc,hàm lượng" : "Đơn vị";
                        osheet.Cells[i_rowbegin, i + 1] = ten;
                    }
                    osheet.Cells[i_rowbegin, i + 1] = "Tổng số";
                    osheet.Cells[i_rowbegin, i + 2] = "Đơn giá";
                    osheet.Cells[i_rowbegin, i + 3] = "Thành tiền";
                    if (chkDoituong.Checked) osheet.Cells[i_rowbegin, i + 4] = "Đối tượng";
                    //osheet.Cells[8,i+4]="Ghi chú";            
                    int stt = 1, tt;
                    icol_sol = 3;
                    if (chkDoituong.Checked) icol_sol = 4;
                    for (i = 0; i < dong; i++)
                    {
                        tt = i + be;
                        if (dtt.Rows[i]["mabd"].ToString() == "0") osheet.get_Range(m.getIndex(0) + tt.ToString(), m.getIndex(cot) + tt.ToString()).Font.Bold = true;
                        else osheet.Cells[i + be, 1] = stt;
                        for (j = 1; j < cot - icol_sol; j++) osheet.Cells[i + be, j + 1] = dtt.Rows[i][j].ToString();
                        if (chkDoituong.Checked) osheet.Cells[i + be, j + 1] = dtt.Rows[i][j + icol_sol - 1].ToString();
                        //osheet.Cells[i+be,cot-3]=double.Parse(dtt.Rows[i][cot-6].ToString())*double.Parse(dtt.Rows[i][cot-5].ToString());
                        //ftc += double.Parse(dtt.Rows[i][cot - 7].ToString()) * double.Parse(dtt.Rows[i][cot - 6].ToString());
                        ftc += double.Parse(dtt.Rows[i][cot - 6].ToString()) * double.Parse(dtt.Rows[i][cot - 5].ToString());
                        if (dtt.Rows[i]["mabd"].ToString() != "0") stt++;
                    }
                    j = 4;
                    osheet.Cells[dong + be, cot - icol_sol] = ftc;
                    osheet.get_Range(m.getIndex(2) + i_rowbegin.ToString(), m.getIndex(cot - 6) + i_rowbegin.ToString()).Orientation = 90;
                    orange = osheet.get_Range(m.getIndex(0) + i_rowbegin.ToString(), m.getIndex(1) + i_rowbegin.ToString());
                    orange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    orange.HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    orange = osheet.get_Range(m.getIndex(cot - col - 6) + i_rowbegin.ToString(), m.getIndex(cot) + i_rowbegin.ToString());
                    orange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    orange.HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    dong += be;
                    osheet.get_Range(m.getIndex(0) + dong.ToString(), m.getIndex(cot) + dong.ToString()).Font.Bold = true;
                    osheet.Cells[dong, 2] = "TỔNG CỘNG";
                    dong = dong + 1;
                    osheet.get_Range(m.getIndex(0) + dong.ToString(), m.getIndex(cot) + dong.ToString()).Font.Bold = true;
                    osheet.Cells[dong, 2] = "Người bệnh ký tên mỗi ngày";
                    int line = dong + 1;
                    osheet.get_Range(d.getIndex(0) + i_rowbegin.ToString(), d.getIndex(cot - 4) + dong.ToString()).Borders.LineStyle = XlBorderWeight.xlHairline;
                    osheet.get_Range(d.getIndex(cot - 6) + i_rowbegin.ToString(), d.getIndex(cot - 4) + dong.ToString()).NumberFormat = "#,##0.00";
                    dong += 4;
                    osheet.get_Range(m.getIndex(0) + "8", m.getIndex(cot - 4) + dong.ToString()).EntireColumn.AutoFit();
                    osheet.Cells[line, 1] = tenpt;
                    //osheet.Cells[line+3,1]=nhomvp;
                    //if (chkThuoc.Checked)
                    //{
                    //osheet.Cells[line + 1, 1] = "Người bệnh ký tên mỗi ngày";
                    //osheet.Cells[line + 3, 1] = "Xác nhận của bệnh nhân/Người nhà bệnh nhân";
                    osheet.Cells[line + 2, cot - 4] = "Ngày      tháng      năm";
                    osheet.Cells[line + 3, cot - 4] = "ĐD Phụ trách";// "Người lập biểu";
                    //}
                    //else osheet.Cells[line + 3, cot - 6] = "Y TÁ HÀNH CHÁNH";
                    osheet.Cells[1, 1] = m.Syte;
                    osheet.Cells[2, 1] = m.Tenbv;
                    osheet.Cells[1, 11] = "MS : 18D/BV - 01";
                    osheet.Cells[2, 11] = "Số vào viện: " + m_sovaovien;
                    //Khuong sua cho van phuc, xuat theo tieu de nhap tren form
                    osheet.Cells[3, 3] = txtTieude.Text;
                    //osheet.Cells[2, 3] = "PHIẾU CÔNG KHAI THUỐC "+((chkThuoc.Checked) ? "" : "DỊCH VỤ");             
                    //osheet.Cells[2,3]="VÀ THANH TOÁN TIỀN CHO BỆNH NHÂN RA VIỆN";
                    osheet.get_Range("C2", "C3").Font.Size = 11;
                    osheet.get_Range("C2", "C3").Font.Bold = true;
                    if ((cmbDoituong.SelectedText.Trim() == "" && chkInnhieuphieu.Checked) || cmbDoituong.SelectedText.Trim() != "")
                    {
                        osheet.Cells[4, 3] = "Đối tượng : " + osheet.Name;
                        osheet.get_Range("C4", "D4").Font.Size = 11;
                        osheet.get_Range("C4", "D4").Font.Bold = true;
                    }
                    osheet.Cells[5, 1] = "Khoa :" + tenkp.Text;
                    //osheet.Cells[6, 1] = "Họ tên :" + m1.Text + m2.Text + "-" + hoten.Text.Trim();
                    //
                    osheet.Cells[6, 1] = "Họ tên người bệnh :" + hoten.Text.Trim() + " (" + m1.Text + m2.Text + ")";
                    osheet.Cells[6, 6] = "Tuổi: " + tuoi.ToString().Trim() + ", Giới tính: " + phai.Text;
                    osheet.Cells[7, 1] = "Địa chỉ: " + diachi.Text.Trim() + ", Số thẻ " + sothe.Text.Trim();// +" Buồng : " + " Giường :";
                    //osheet.Cells[4, 9] = "Số thẻ " + sothe.Text.Trim();
                    //osheet.Cells[6,1]="Số giường :"+"";
                    //osheet.Cells[6,3]="Số lưu trữ :"+soluutru.Text;//"Buồng :";
                    osheet.Cells[8, 1] = "Phòng: " + m_phong + ", giường: " + m_giuong + ", Ngày vào: " + ngayvao.Text.Trim() + ", Ngày ra :" + ngayra.Text.Trim() + ", Tạm ứng: " + d_sttamung.ToString("###,###,###.0#");
                    osheet.Cells[9, 1] = "Chẩn đoán : " + chandoan.Text.Trim();
                    
                    //Tu:10/08/2011
                    foreach (DataRow r in ds1.Tables[0].Select("true", "ngay desc"))//loai
                    {
                        string s_ngay = r["ngay"].ToString();
                        s_ngay = s_ngay.Substring(6, 2) + "/" + s_ngay.Substring(4, 2) + "/" + s_ngay.Substring(0, 4);
                        long songaydt = m.songay(m.StringToDate(s_ngay), m.StringToDate(ngayvao.Text.Substring(0, 10)), 1);
                        osheet.Cells[9, 6] = "Tổng số ngày điều trị : " + songaydt;
                        break;
                    }
                    //end Tu

                    //osheet.Cells[6, 6] = "Tuổi " + tuoi.ToString().Trim() + " Giới tính " + phai.Text;
                    //osheet.Cells[7, 1] = "Địa chỉ : " + diachi.Text.Trim() + " Số thẻ " + sothe.Text.Trim() + " Buồng : " + " Giường :";
                    ////osheet.Cells[4, 9] = "Số thẻ " + sothe.Text.Trim();
                    ////osheet.Cells[6,1]="Số giường :"+"";
                    ////osheet.Cells[6,3]="Số lưu trữ :"+soluutru.Text;//"Buồng :";
                    //osheet.Cells[8, 1] = "Chẩn đoán : " + chandoan.Text.Trim() + " Ngày vào :" + ngayvao.Text.Trim() + " Ngày ra :" + ngayra.Text.Trim();
                    //osheet.Cells[6,9]="Ngày vào viện :"+ngayvao.Text.Trim();			
                    //osheet.Cells[7,9]="Ngày ra viện : "+ngayra.Text.Trim();
                    try { osheet.PageSetup.Orientation = XlPageOrientation.xlLandscape; }
                    catch { }
                }
                //osheet.PageSetup.PaperSize=XlPaperSize.xlPaperA4;
                oxl.ActiveWindow.DisplayZeros = false;
                if (chkXem.Checked) oxl.Visible = true;
                else osheet.PrintOut(Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            }
            catch { }
        }
		#region phieucaongkhaithuoc
		public DataSet get_congkhai(string d_tu, string d_den, string d_mabn, long d_maql,long d_id,string maso)
		{
            int haophi = d.iHaophi;
            maso =d_maql.ToString() + ",";
            string _ngayvv = ngayvv.Text;
            if (i_loaiba == 1)
            {
                _ngayvv = m.get_ngay_Capcuu_noitru(ngayvv.Text, l_mavaovien);
                maso += m.get_maql_Capcuu_noitru(ngayvv.Text, l_mavaovien);
                maso += m.get_maql_Capve_noitru(ngayvv.Text, l_mavaovien);
            }
            else if (i_loaiba == 2)
            {
                maso += m.get_maql_ngoaitru(ngayvv.Text.Substring(0, 10), (ngayra.Text != "") ? ngayra.Text.Substring(0, 10) : m.ngayhienhanh_server.Substring(0, 10), d_maql);
                if (m.bChiphikp_noingoai) maso += m.get_maql_Capve_noitru(ngayvv.Text, l_mavaovien);
            }
			string sql="delete from "+user+".t_congkhai ";
            sql += " where maql in (" + maso.Substring(0, maso.Length - 1) + ")";
			m.execute_data(sql);
			DateTime dt1=d.StringToDate(d_tu).AddDays(-d.iNgaykiemke);
			DateTime dt2=d.StringToDate(d_den).AddDays(d.iNgaykiemke);
			int y1=dt1.Year,m1=dt1.Month;
			int y2=dt2.Year,m2=dt2.Month;
			int itu,iden;
			string mmyy="";		
			for(int i=y1;i<=y2;i++)
			{
				itu=(i==y1)?m1:1;
				iden=(i==y2)?m2:12;
				for(int j=itu;j<=iden;j++)
				{
					mmyy=j.ToString().PadLeft(2,'0')+i.ToString().Substring(2,2);
					if (m.bMmyy(mmyy))
					{
                        xxx = user + mmyy;
						sql=" insert into "+user+".t_congkhai "+
							" select c.makp,"+l_maql+" as maql,a.mabd,to_char(a.ngay,'yyyymmdd') as ngay,sum(a.soluong) as soluong,sum(a.soluong*case when d.loai=0 then a.giamua else a.giaban end) as sotien,case when d.loai=0 then a.giamua else a.giaban end as dongia,0 as loai,a.madoituong "+
							" from "+xxx+".d_tienthuoc a, "+user+".d_dmbd b,"+user+".d_duockp c,"+user+".d_doituong d where a.mabd=b.id and a.makp=c.id and a.madoituong=d.madoituong and a.mabn='"+d_mabn+"'";
						//if (i_loaiba==1) sql+=" and a.maql="+d_maql;
						if (d_id!=0)
						{
							sql+=" and a.idkhoa="+d_id;
						}
                        if (chkNgay.Checked)
                        {
                            sql += " and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + d_tu.Substring(0, 10) + "','dd/mm/yyyy') and to_date('" + d_den.Substring(0, 10) + "','dd/mm/yyyy')";
                        }
                        //sql += " and a.ngay between to_date('" + d_tu.Substring(0, 10) + "'," + stime + ") and to_date('" + d_den.Substring(0, 10) + "'," + stime + ")";
                        if (chkHaophi.Checked == false) sql += " and a.madoituong<>" + haophi;
                        if (maso != "") sql += " and a.maql in (" + maso.Substring(0, maso.Length - 1) + ")";
                        sql += " group by c.makp,a.mabd,to_char(a.ngay,'yyyymmdd'),case when d.loai=0 then a.giamua else a.giaban end,a.madoituong";
						d.execute_data(sql);
						if (bCapve || i_loaiba==2)
						{
							sql=" insert into "+user+".t_congkhai "+
								" select k.makp,"+l_maql+" as maql,a.mabd,to_char(k.ngay,'yyyymmdd') as ngay,sum(a.soluong) as soluong,sum(a.soluong*t.giamua) as sotien,t.giamua as dongia,0 as loai,a.madoituong "+
								" from "+xxx+".bhytkb k,"+xxx+".bhytthuoc a,"+user+".d_dmbd b,"+xxx+".d_theodoi t where k.id=a.id and a.sttt=t.id and a.mabd=b.id and k.mabn='"+d_mabn+"'";
							//if (bCapve && i_loaiba==1) sql+=" and k.maql="+d_maql;
                            if (chkNgay.Checked)
                            {
                                sql += " and to_date(to_char(k.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + d_tu.Substring(0, 10) + "','dd/mm/yyyy') and to_date('" + d_den.Substring(0, 10) + "','dd/mm/yyyy')";
                            }
                            //sql += " and k.ngay between to_date('" + d_tu.Substring(0, 10) + "'," + stime + ") and to_date('" + d_den.Substring(0, 10) + "'," + stime + ")";
                            if (maso != "") sql += " and k.maql in (" + maso.Substring(0, maso.Length - 1) + ")";
                            sql += " group by k.makp,a.mabd,to_char(k.ngay,'yyyymmdd'),t.giamua,a.madoituong";
							d.execute_data(sql);
							//
                            //sql=" insert into "+user+".t_congkhai "+
                            //    " select k.makp,"+l_maql+" as maql,a.mavp as mabd,to_char(k.ngay,'yyyymmdd') as ngay,sum(a.soluong) as soluong,sum(a.soluong*a.dongia) as sotien,a.dongia,1 as loai,a.madoituong "+
                            //    " from "+xxx+".bhytkb k,"+xxx+".bhytcls a,"+user+".v_giavp b where k.id=a.id and a.mavp=b.id and k.mabn='"+d_mabn+"'";
                            //if (chkNgay.Checked)
                            //{
                            //    sql += " and to_date(to_char(k.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + d_tu.Substring(0, 10) + "','dd/mm/yyyy') and to_date('" + d_den.Substring(0, 10) + "','dd/mm/yyyy')";
                            //}
                            //if (maso != "") sql += " and k.maql in (" + maso.Substring(0, maso.Length - 1) + ")";
                            //sql += " group by k.makp,a.mavp,to_char(k.ngay,'yyyymmdd'),a.dongia,a.madoituong";
                            //d.execute_data(sql);

                            //Khuong
                            try
                            {
                                sql = " insert into " + user + ".t_congkhai1 " +
                                    " select k.makp," + l_maql + " as maql,a.mabd,to_char(k.ngay,'yyyymmdd') as ngay,sum(a.soluong) as soluong,sum(a.soluong*t.giamua) as sotien,t.giamua as dongia,0 as loai, a.madoituong " +
                                    " from " + xxx + ".d_ngtrull k," + xxx + ".d_ngtruct a," + user + ".d_dmbd b," + xxx + ".d_theodoi t where k.id=a.id and a.sttt=t.id and a.mabd=b.id and k.mabn='" + d_mabn + "'";
                                //if (bCapve && i_loaiba==1) sql+=" and k.maql="+d_maql;
                                if (chkNgay.Checked)
                                {
                                    sql += " and to_date(to_char(k.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + d_tu.Substring(0, 10) + "','dd/mm/yyyy') and to_date('" + d_den.Substring(0, 10) + "','dd/mm/yyyy')";
                                }
                                if (maso != "") sql += " and k.maql in (" + maso.Substring(0, maso.Length - 1) + ")";
                                //if (cmbDoituong.SelectedIndex >= 0) sql += " and a.maphu=" + cmbDoituong.SelectedValue.ToString();
                                sql += " group by k.makp,a.mabd,to_char(k.ngay,'yyyymmdd'),t.giamua, a.madoituong";
                                d.execute_data(sql);
                            }
                            catch { }
                            //Khuong
						}

                        if (!chkThuoc.Checked)
                        {
                            sql = " insert into " + user + ".t_congkhai " +
                                " select a.makp," + l_maql + " as maql,a.mavp as mabd,to_char(a.ngay,'yyyymmdd') as ngay,sum(a.soluong) as soluong,sum(a.soluong*(a.dongia+a.vattu-a.stgiam)) as sotien,a.dongia+a.vattu-a.stgiam as dongia,1 as loai,a.madoituong " +
                                " from " + xxx + ".v_vpkhoa a," + user + ".v_giavp b where a.mavp=b.id and a.mabn='" + d_mabn + "'";
                            //if (i_loaiba == 1) sql += " and a.maql=" + d_maql;
                            if (d_id != 0)
                            {
                                sql += " and a.idkhoa=" + d_id;
                            }
                            sql += " and " + m.for_ngay("a.ngay", stime) + " between to_date('" + d_tu.Substring(0, 10) + "'," + stime + ") and to_date('" + d_den.Substring(0, 10) + "'," + stime + ")";
                            if (maso != "") sql += " and a.maql in (" + maso.Substring(0, maso.Length - 1) + ")";
                            sql += " group by a.makp,a.mavp,to_char(a.ngay,'yyyymmdd'),a.dongia+a.vattu-a.stgiam,a.madoituong";
                            d.execute_data(sql);
                            if (m.bChidinh_vienphi)
                            {
                                sql = " insert into " + user + ".t_congkhai " +
                                    " select a.makp," + l_maql + " as maql,a.mavp as mabd,to_char(a.ngay,'yyyymmdd') as ngay,sum(a.soluong) as soluong,sum(a.soluong*(a.dongia+a.vattu-a.stgiam)) as sotien,a.dongia+a.vattu-a.stgiam as dongia,1 as loai,a.madoituong " +
                                    " from " + xxx + ".v_chidinh a," + user + ".v_giavp b where a.mavp=b.id and a.mabn='" + d_mabn + "'";
                               // if (bCapve || i_loaiba == 2)  sql += " and a.paid=0 ";
                                //if (i_loaiba == 1) sql += " and a.maql=" + d_maql;
                                if (d_id != 0)
                                {
                                    sql += " and a.idkhoa=" + d_id;
                                }
                                sql += " and " + m.for_ngay("a.ngay", stime) + " between to_date('" + d_tu.Substring(0, 10) + "'," + stime + ") and to_date('" + d_den.Substring(0, 10) + "'," + stime + ")";
                                if (maso != "") sql += " and a.maql in (" + maso.Substring(0, maso.Length - 1) + ")";
                                sql += " group by a.makp,a.mavp,to_char(a.ngay,'yyyymmdd'),a.dongia+a.vattu-a.stgiam,a.madoituong";
                                d.execute_data(sql);
                            }
                        }
					}
				}
			}
            
            sql = " select f.stt,f.ten as nhomvp,a.loai,a.mabd,trim(b.ten)||' '||b.hamluong as tenbd, " +
               " b.dang as dangbd,a.ngay,a.soluong,a.dongia,a.sotien " +
               " from " + user + ".t_congkhai a," + user + ".d_dmbd b," + user + ".d_dmnhom c," + user + ".v_nhomvp d," + user + ".v_nhombhyt f where a.mabd=b.id and b.manhom=c.id and c.nhomvp=d.ma and d.idnhombhyt=f.id and a.maql=" + d_maql;
            sql += " union all";
            sql += "  select f.stt,f.ten as nhomvp,a.loai,a.mabd,b.ten as tenbd,b.dvt as dangbd,a.ngay,a.soluong,a.dongia,a.sotien " +
            " from " + user + ".t_congkhai a," + user + ".v_giavp b," + user + ".v_loaivp c," + user + ".v_nhomvp d," + user + ".v_nhombhyt f where a.mabd=b.id and b.id_loai=c.id and c.id_nhom=d.ma and d.idnhombhyt=f.id and a.maql=" + d_maql;

            sql = " select d.stt,d.ten as nhomvp,a.loai,a.mabd,trim(b.ten)||' '||b.hamluong as tenbd, " +
                " b.dang as dangbd,a.ngay,a.soluong,a.dongia,a.sotien,e.doituong, " +
                "(case when d.stt=13 then 1 else (case when d.stt=4 then 2 else(case when d.stt=1 then 3 else(case when d.stt=5 then 4 else(case when d.stt=6 then 5 else(case when d.stt=8 then 7 else(case when d.stt=2 then 8 else(case when d.stt=3 or d.stt=14 then 9 else(case when d.stt=9 then 10 else(case when d.stt=11 then 11 else(case when d.stt=7 then 12 else(case when d.stt=12 then 13 else d.stt end)end)end)end)end)end)end)end)end)end)end)end) as sttnhom" +
                " from " + user + ".t_congkhai a," + user + ".d_dmbd b," + user + ".d_dmnhom c," + user + ".v_nhomvp d," + user + ".d_doituong e where a.mabd=b.id and b.manhom=c.id and c.nhomvp=d.ma and a.madoituong=e.madoituong and a.maql=" + d_maql;
            sql += " union all";
            sql += "  select d.stt,d.ten as nhomvp,a.loai,a.mabd,b.ten as tenbd,b.dvt as dangbd,a.ngay,a.soluong,a.dongia,a.sotien,e.doituong, " +
                "(case when d.stt=13 then 1 else (case when d.stt=4 then 2 else(case when d.stt=1 then 3 else(case when d.stt=5 then 4 else(case when d.stt=6 then 5 else(case when d.stt=8 then 7 else(case when d.stt=2 then 8 else(case when d.stt=3 or d.stt=14 then 9 else(case when d.stt=9 then 10 else(case when d.stt=11 then 11 else(case when d.stt=7 then 12 else(case when d.stt=12 then 13 else d.stt end)end)end)end)end)end)end)end)end)end)end)end) as sttnhom" +
            " from " + user + ".t_congkhai a," + user + ".v_giavp b," + user + ".v_loaivp c," + user + ".v_nhomvp d," + user + ".d_doituong e where a.mabd=b.id and b.id_loai=c.id and c.id_nhom=d.ma and a.madoituong=e.madoituong and a.maql=" + d_maql;

			DataSet ret=m.get_data(sql);
            m.execute_data("delete from " + user + ".t_congkhai where maql=" + d_maql);
            return ret;
			//
		}
        public DataSet get_congkhai_doituong(string d_tu, string d_den, string d_mabn, long d_maql, long d_id, string maso)
        {
            int haophi = d.iHaophi;
            maso = d_maql.ToString() + ",";
            string _ngayvv = ngayvv.Text;
            if (i_loaiba == 1)
            {
                _ngayvv = m.get_ngay_Capcuu_noitru(ngayvv.Text, l_mavaovien);
                maso += m.get_maql_Capcuu_noitru(ngayvv.Text, l_mavaovien);
                maso += m.get_maql_Capve_noitru(ngayvv.Text, l_mavaovien);
            }
            else if (i_loaiba == 2)
            {
                maso += m.get_maql_ngoaitru(ngayvv.Text.Substring(0, 10), (ngayra.Text != "") ? ngayra.Text.Substring(0, 10) : m.ngayhienhanh_server.Substring(0, 10), d_maql);
                if (m.bChiphikp_noingoai) maso += m.get_maql_Capve_noitru(ngayvv.Text, l_mavaovien);
            }
            string sql = "delete from " + user + ".t_congkhai1 ";
            sql += " where maql in (" + maso.Substring(0, maso.Length - 1) + ")";
            m.execute_data(sql);
            DateTime dt1 = d.StringToDate(d_tu).AddDays(-d.iNgaykiemke);
            DateTime dt2 = d.StringToDate(d_den).AddDays(d.iNgaykiemke);
            int y1 = dt1.Year, m1 = dt1.Month;
            int y2 = dt2.Year, m2 = dt2.Month;
            int itu, iden;
            string mmyy = "";
            for (int i = y1; i <= y2; i++)
            {
                itu = (i == y1) ? m1 : 1;
                iden = (i == y2) ? m2 : 12;
                for (int j = itu; j <= iden; j++)
                {
                    mmyy = j.ToString().PadLeft(2, '0') + i.ToString().Substring(2, 2);
                    if (m.bMmyy(mmyy))
                    {
                        xxx = user + mmyy;
                        sql = " insert into " + user + ".t_congkhai1 " +
                            " select c.makp," + l_maql + " as maql,a.mabd,to_char(a.ngay,'yyyymmdd') as ngay,sum(a.soluong) as soluong,sum(a.soluong*case when d.loai=0 then a.giamua else a.giaban end) as sotien,case when d.loai=0 then a.giamua else a.giaban end as dongia,0 as loai, a.madoituong " +
                            " from " + xxx + ".d_tienthuoc a, " + user + ".d_dmbd b," + user + ".d_duockp c," + user + ".d_doituong d where a.mabd=b.id and a.makp=c.id and a.madoituong=d.madoituong and a.mabn='" + d_mabn + "'";
                        //if (i_loaiba==1) sql+=" and a.maql="+d_maql;
                        if (d_id != 0)
                        {
                            sql += " and a.idkhoa=" + d_id;
                        }
                        //linh
                        if (chkNgay.Checked)
                        {
                            sql += " and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + d_tu.Substring(0, 10) + "','dd/mm/yyyy') and to_date('" + d_den.Substring(0, 10) + "','dd/mm/yyyy')";
                        }
                        if (chkHaophi.Checked == false) sql += " and a.madoituong<>" + haophi;
                        if (cmbDoituong.SelectedIndex >= 0 && cmbDoituong.SelectedValue.ToString() != "0") sql += " and a.madoituong=" + cmbDoituong.SelectedValue.ToString();
                        if (maso != "") sql += " and a.maql in (" + maso.Substring(0, maso.Length - 1) + ")";
                        sql += " group by c.makp,a.mabd,to_char(a.ngay,'yyyymmdd'),case when d.loai=0 then a.giamua else a.giaban end, a.madoituong ";
                        d.execute_data(sql);
                        if (bCapve || i_loaiba == 2)
                        {
                            //Linh
                            sql = " insert into " + user + ".t_congkhai1 " +
                                " select k.makp," + l_maql + " as maql,a.mabd,to_char(k.ngay,'yyyymmdd') as ngay,sum(a.soluong) as soluong,sum(a.soluong*t.giamua) as sotien,t.giamua as dongia,0 as loai, k.maphu as madoituong " +
                                " from " + xxx + ".bhytkb k," + xxx + ".bhytthuoc a," + user + ".d_dmbd b," + xxx + ".d_theodoi t where k.id=a.id and a.sttt=t.id and a.mabd=b.id and k.mabn='" + d_mabn + "'";
                            //if (bCapve && i_loaiba==1) sql+=" and k.maql="+d_maql;
                            if (chkNgay.Checked)
                            {
                                sql += " and to_date(to_char(k.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + d_tu.Substring(0, 10) + "','dd/mm/yyyy') and to_date('" + d_den.Substring(0, 10) + "','dd/mm/yyyy')";
                            }
                            if (maso != "") sql += " and k.maql in (" + maso.Substring(0, maso.Length - 1) + ")";
                            //if (cmbDoituong.SelectedIndex >= 0) sql += " and a.maphu=" + cmbDoituong.SelectedValue.ToString();
                            sql += " group by k.makp,a.mabd,to_char(k.ngay,'yyyymmdd'),t.giamua, k.maphu";
                            d.execute_data(sql);
                            //Linh
                            //
                            //sql = " insert into " + user + ".t_congkhai1 " +
                            //    " select k.makp," + l_maql + " as maql,a.mavp as mabd,to_char(k.ngay,'yyyymmdd') as ngay,sum(a.soluong) as soluong,sum(a.soluong*a.dongia) as sotien,a.dongia,1 as loai, k.maphu as madoituong " +
                            //    " from " + xxx + ".bhytkb k," + xxx + ".bhytcls a," + user + ".v_giavp b where k.id=a.id and a.mavp=b.id and k.mabn='" + d_mabn + "'";
                            //if (chkNgay.Checked)
                            //{
                            //    sql += " and to_date(to_char(k.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + d_tu.Substring(0, 10) + "','dd/mm/yyyy') and to_date('" + d_den.Substring(0, 10) + "','dd/mm/yyyy')";
                            //}
                            //if (maso != "") sql += " and k.maql in (" + maso.Substring(0, maso.Length - 1) + ")";
                            //sql += " group by k.makp,a.mavp,to_char(k.ngay,'yyyymmdd'),a.dongia, k.maphu";
                            //d.execute_data(sql);

                            //Khuong
                            try
                            {
                                sql = " insert into " + user + ".t_congkhai1 " +
                                    " select k.makp," + l_maql + " as maql,a.mabd,to_char(k.ngay,'yyyymmdd') as ngay,sum(a.soluong) as soluong,sum(a.soluong*t.giamua) as sotien,t.giamua as dongia,0 as loai, a.madoituong " +
                                    " from " + xxx + ".d_ngtrull k," + xxx + ".d_ngtruct a," + user + ".d_dmbd b," + xxx + ".d_theodoi t where k.id=a.id and a.sttt=t.id and a.mabd=b.id and k.mabn='" + d_mabn + "'";
                                //if (bCapve && i_loaiba==1) sql+=" and k.maql="+d_maql;
                                if (chkNgay.Checked)
                                {
                                    sql += " and to_date(to_char(k.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + d_tu.Substring(0, 10) + "','dd/mm/yyyy') and to_date('" + d_den.Substring(0, 10) + "','dd/mm/yyyy')";
                                }
                                if (maso != "") sql += " and k.maql in (" + maso.Substring(0, maso.Length - 1) + ")";
                                //if (cmbDoituong.SelectedIndex >= 0) sql += " and a.maphu=" + cmbDoituong.SelectedValue.ToString();
                                sql += " group by k.makp,a.mabd,to_char(k.ngay,'yyyymmdd'),t.giamua, a.madoituong";
                                d.execute_data(sql);
                            }
                            catch { }
                            //Khuong
                            //d_ngtrull,d_ngtruct
                        }

                        if (!chkThuoc.Checked)
                        {
                            sql = " insert into " + user + ".t_congkhai1 " +
                                " select a.makp," + l_maql + " as maql,a.mavp as mabd,to_char(a.ngay,'yyyymmdd') as ngay,sum(a.soluong) as soluong,sum(a.soluong*(a.dongia+a.vattu-a.stgiam)) as sotien,a.dongia+a.vattu-a.stgiam as dongia,1 as loai, a.madoituong " +
                                " from " + xxx + ".v_vpkhoa a," + user + ".v_giavp b where a.mavp=b.id and a.mabn='" + d_mabn + "'";
                            //if (i_loaiba == 1) sql += " and a.maql=" + d_maql;
                            if (d_id != 0)
                            {
                                sql += " and a.idkhoa=" + d_id;
                            }
                            if (chkNgay.Checked)
                            {
                                sql += " and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + d_tu.Substring(0, 10) + "','dd/mm/yyyy') and to_date('" + d_den.Substring(0, 10) + "','dd/mm/yyyy')";
                            }
                            if (maso != "") sql += " and a.maql in (" + maso.Substring(0, maso.Length - 1) + ")";
                            if (cmbDoituong.SelectedIndex >= 0 && cmbDoituong.SelectedValue.ToString()!="0") sql += " and a.madoituong=" + cmbDoituong.SelectedValue.ToString();
                            sql += " group by a.madoituong, a.makp,a.mavp,to_char(a.ngay,'yyyymmdd'),a.dongia+a.vattu-a.stgiam";
                            d.execute_data(sql);
                            if (m.bChidinh_vienphi)
                            {
                                sql = " insert into " + user + ".t_congkhai1 " +
                                    " select a.makp," + l_maql + " as maql,a.mavp as mabd,to_char(a.ngay,'yyyymmdd') as ngay,sum(a.soluong) as soluong,sum(a.soluong*(a.dongia+a.vattu-a.stgiam)) as sotien,a.dongia+a.vattu-a.stgiam as dongia,1 as loai, a.madoituong " +
                                    " from " + xxx + ".v_chidinh a," + user + ".v_giavp b where a.mavp=b.id and a.mabn='" + d_mabn + "'";
                                //if (bCapve || i_loaiba == 2) sql += " and a.paid=0 ";
                                //if (i_loaiba == 1) sql += " and a.maql=" + d_maql;
                                if (d_id != 0)
                                {
                                    sql += " and a.idkhoa=" + d_id;
                                }
                                if (chkNgay.Checked)
                                {
                                    sql += " and to_date(to_char(a.ngay,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + d_tu.Substring(0, 10) + "','dd/mm/yyyy') and to_date('" + d_den.Substring(0, 10) + "','dd/mm/yyyy')";
                                }
                                if (maso != "") sql += " and a.maql in (" + maso.Substring(0, maso.Length - 1) + ")";
                                if (cmbDoituong.SelectedIndex >= 0 && cmbDoituong.SelectedValue.ToString() != "0") sql += " and a.madoituong=" + cmbDoituong.SelectedValue.ToString();
                                sql += " group by a.makp,a.mavp,to_char(a.ngay,'yyyymmdd'),a.dongia+a.vattu-a.stgiam, a.madoituong";
                                d.execute_data(sql);
                            }
                        }
                    }
                }
            }
            DataSet ret = new DataSet();

            //sql = " select d.stt,d.ten as nhomvp,a.loai,a.mabd,trim(b.ten)||' '||b.hamluong as tenbd, " +
            //    " b.dang as dangbd,a.ngay,a.soluong,a.dongia,a.sotien, e.doituong" +
            //    " from " + user + ".t_congkhai1 a," + user + ".d_dmbd b," + user + ".d_dmnhom c," + user + ".v_nhomvp d ," + user + ".doituong e where a.mabd=b.id and b.manhom=c.id and c.nhomvp=d.ma and a.madoituong=e.madoituong and a.maql=" + d_maql +
            //    " union all select d.stt,d.ten as nhomvp,a.loai,a.mabd,b.ten as tenbd,b.dvt as dangbd,a.ngay,a.soluong,a.dongia,a.sotien, e.doituong " +
            //    " from " + user + ".t_congkhai1 a," + user + ".v_giavp b," + user + ".v_loaivp c," + user + ".v_nhomvp d," + user + ".doituong e where a.mabd=b.id and b.id_loai=c.id and c.id_nhom=d.ma and a.madoituong=e.madoituong and a.maql=" + d_maql;
           
            //Tu:08/08/2011 chỗ này lấy theo nhóm vp không lấy theo nhóm bhyt
            sql = " select d.stt,d.ten as nhomvp,a.loai,a.mabd,trim(b.ten)||' '||b.hamluong as tenbd, " +
                " b.dang as dangbd,a.ngay,a.soluong,a.dongia,a.sotien, e.doituong," +
                "(case when d.stt=13 then 1 else (case when d.stt=4 then 2 else(case when d.stt=1 then 3 else(case when d.stt=5 then 4 else(case when d.stt=6 then 5 else(case when d.stt=8 then 7 else(case when d.stt=2 then 8 else(case when d.stt=3 or d.stt=14 then 9 else(case when d.stt=9 then 10 else(case when d.stt=11 then 11 else(case when d.stt=7 then 12 else(case when d.stt=12 then 13 else d.stt end)end)end)end)end)end)end)end)end)end)end)end) as sttnhom" +
                " from " + user + ".t_congkhai1 a," + user + ".d_dmbd b," + user + ".d_dmnhom c," + user + ".v_nhomvp d ," + user + ".doituong e where a.mabd=b.id and b.manhom=c.id and c.nhomvp=d.ma and a.madoituong=e.madoituong and a.maql=" + d_maql +//, " + user + ".v_nhombhyt f and d.idnhombhyt=f.id
                " union all select d.stt,d.ten as nhomvp,a.loai,a.mabd,b.ten as tenbd,b.dvt as dangbd,a.ngay,a.soluong,a.dongia,a.sotien, e.doituong, " +
                "(case when d.stt=13 then 1 else (case when d.stt=4 then 2 else(case when d.stt=1 then 3 else(case when d.stt=5 then 4 else(case when d.stt=6 then 5 else(case when d.stt=8 then 7 else(case when d.stt=2 then 8 else(case when d.stt=3 or d.stt=14 then 9 else(case when d.stt=9 then 10 else(case when d.stt=11 then 11 else(case when d.stt=7 then 12 else(case when d.stt=12 then 13 else d.stt end)end)end)end)end)end)end)end)end)end)end)end) as sttnhom" +
                " from " + user + ".t_congkhai1 a," + user + ".v_giavp b," + user + ".v_loaivp c," + user + ".v_nhomvp d," + user + ".doituong e where a.mabd=b.id and b.id_loai=c.id and c.id_nhom=d.ma and a.madoituong=e.madoituong and a.maql=" + d_maql + "" + //, " + user + ".v_nhombhyt f  and d.idnhombhyt=f.id
                " order by sttnhom ";
            //end Tu
            ret = m.get_data(sql);

            m.execute_data("delete from " + user + ".t_congkhai1 where maql=" + d_maql);
            return ret;
            //
        }
		public bool updrec_p_congkhai (System.Data.DataTable dt,string ngay,double soluong)
		{
			string exp="ngay='"+ngay+"'";
			int i=(soluong!=0)?1:0;
			DataRow r = m.getrowbyid (dt,exp); 
			if ( r == null )
			{
				DataRow nrow = dt.NewRow ( ) ;
				nrow[0] = ngay;
				nrow[1] = i;
				dt.Rows.Add ( nrow ) ;
				return true;
			}
			else
			{
				DataRow[] dr = dt.Select(exp);
				double f=double.Parse(dr[0][1].ToString())+i;
				dr[0][0] = ngay;
				dr[0][1] = f;
				return false;
			}
		}

		private void ngayvv_SelectedIndexChanged(object sender, System.EventArgs e)
		{
            try
            {
                if (this.ActiveControl == ngayvv)
                {
                    if (ngayvv.Items.Count > 0)
                    {
                        int dd = int.Parse(dsngay.Tables[0].Rows[ngayvv.SelectedIndex]["ngayvao"].ToString().Substring(0, 2));
                        int mm = int.Parse(dsngay.Tables[0].Rows[ngayvv.SelectedIndex]["ngayvao"].ToString().Substring(3, 2));
                        int yyyy = int.Parse(dsngay.Tables[0].Rows[ngayvv.SelectedIndex]["ngayvao"].ToString().Substring(6, 4));
                        int hh = int.Parse(dsngay.Tables[0].Rows[ngayvv.SelectedIndex]["ngayvao"].ToString().Substring(11, 2));
                        int mi = int.Parse(dsngay.Tables[0].Rows[ngayvv.SelectedIndex]["ngayvao"].ToString().Substring(14, 2));
                        ngayvao.Value = new DateTime(yyyy, mm, dd, hh, mi, 0);
                        ngayra.Text = dsngay.Tables[0].Rows[ngayvv.SelectedIndex]["ngayra"].ToString();
                        if (ngayra.Text == "") ngayra.Text = m.ngayhienhanh_server;
                        sothe.Text = dsngay.Tables[0].Rows[ngayvv.SelectedIndex]["sothe"].ToString();
                        chandoan.Text = dsngay.Tables[0].Rows[ngayvv.SelectedIndex]["chandoan"].ToString();
                        tenkp.Text = dsngay.Tables[0].Rows[ngayvv.SelectedIndex]["tenkp"].ToString();
                        l_maql = long.Parse(dsngay.Tables[0].Rows[ngayvv.SelectedIndex]["maql"].ToString());
                        l_id = long.Parse(dsngay.Tables[0].Rows[ngayvv.SelectedIndex]["idkhoa"].ToString());
                        chkVienphi.Checked = dsngay.Tables[0].Rows[ngayvv.SelectedIndex]["makp"].ToString().Trim() != "";
                    }
                }
            }
            catch { }
		}

		private void ngayra_Validated(object sender, System.EventArgs e)
		{
			if (ngayra.Text=="")
			{
				ngayra.Focus();
				return;
			}
			ngayra.Text=ngayra.Text.Trim();
			if (ngayra.Text.Length<16)
			{
				MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập Ngày và giờ ra viện !"));
				ngayra.Focus();
				return;
			}
			if (!m.bNgay(ngayra.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Ngày và giờ không hợp lệ !"));
				ngayra.Focus();
				return;
			}
			ngayra.Text=m.Ktngaygio(ngayra.Text,16);		
			if (!m.bNgaygio(ngayra.Text,ngayvao.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Ngày ra viện không được nhỏ hơn ngày vào viện !"));
				ngayra.Focus();
				return;
			}
		}

		private void m1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			d.MaskDigit(e);
		}	

		private void m2_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			d.MaskDigit(e);
		}

		public void updrec_p_congkhai (System.Data.DataTable dt,string loai,string stt,string nhomvp,string mabd,string tenbd,string dangbd,double soluong,double dongia,int i,int sttnhom,string doituong)
		{
			string exp="mabd='"+mabd+"'"+" and dongia="+dongia;
            exp += " and doituong='" + doituong + "'";
			DataRow r = m.getrowbyid (dt,exp); 
			if ( r == null )
			{
				DataRow nrow = dt.NewRow ( ) ;
				nrow["loai"]=loai;
				nrow["stt"]=stt;
				nrow["nhomvp"]=nhomvp;
				nrow["mabd"] = mabd;
				nrow["tenbd"] = tenbd;
				nrow["dangbd"] = dangbd;
				//for(int k=3;k<dt.Columns.Count-3;k++) nrow[k]=0;
                for (int k = 3; k < dt.Columns.Count - 4; k++) nrow[k] = 0;
				nrow[i] = soluong;
				nrow["tongso"]= soluong;
				nrow["dongia"]	= dongia;
				nrow["thanhtien"]=soluong*dongia;
                nrow["sttnhom"] = sttnhom;
                nrow["doituong"] = doituong;
				dt.Rows.Add ( nrow ) ;
			}
			else
			{
				DataRow[] dr = dt.Select(exp);
				double f=double.Parse(dr[0]["tongso"].ToString())+soluong;
				dr[0][i] = double.Parse(dr[0][i].ToString())+soluong;
				dr[0]["tongso"]= f;
				dr[0]["dongia"] = dongia;
				dr[0]["thanhtien"]=f*dongia;
			}
		}

        public void updrec_p_congkhai_doituong(System.Data.DataTable dt, string loai, string stt, string nhomvp, string mabd, string tenbd, string dangbd, double soluong, double dongia, int i, string doituong,int sttnhom)
        {
            string exp = "mabd='" + mabd + "'" + " and dongia=" + dongia;
            exp += " and doituong='" + doituong + "'";
            DataRow r = m.getrowbyid(dt, exp);
            if (r == null)
            {
                DataRow nrow = dt.NewRow();
                nrow["loai"] = loai;
                nrow["stt"] = stt;
                nrow["nhomvp"] = nhomvp;
                nrow["mabd"] = mabd;
                nrow["tenbd"] = tenbd;
                nrow["dangbd"] = dangbd;
                for (int k = 3; k < dt.Columns.Count - 4; k++) nrow[k] = 0;
                nrow[i] = soluong;
                nrow["tongso"] = soluong;
                nrow["dongia"] = dongia;
                nrow["thanhtien"] = soluong * dongia;
                nrow["doituong"] = doituong;
                nrow["sttnhom"] = sttnhom;
                dt.Rows.Add(nrow);
            }
            else
            {
                DataRow[] dr = dt.Select(exp);
                double f = double.Parse(dr[0]["tongso"].ToString()) + soluong;
                dr[0][i] = double.Parse(dr[0][i].ToString()) + soluong;
                dr[0]["tongso"] = f;
                dr[0]["dongia"] = dongia;
                dr[0]["thanhtien"] = f * dongia;
            }
        }
		#endregion

        private void chkThuoc_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == chkThuoc) m.writeXml("thongso", "ckthuoc", (chkThuoc.Checked) ? "1" : "0");
        }

        private void chkExcel_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == chkExcel) m.writeXml("thongso", "ckexcel", (chkExcel.Checked) ? "1" : "0");
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == chkAll) m.writeXml("thongso", "ckall", (chkAll.Checked) ? "1" : "0");
        }

        private void chkKhoa_CheckedChanged(object sender, EventArgs e)
        {
            if (chkKhoa.Checked) { chkVienphi.Checked = false; }
            tenkp.Enabled = !chkKhoa.Checked;
            m2_Validated(null, null);
        }

        private void chkKhoa_Click(object sender, EventArgs e)
        {
           
        }

        private void chkHaophi_Click(object sender, EventArgs e)
        {
            m.writeXml("thongso", "congkhai_incahaophi", chkHaophi.Checked ? "1" : "0");
        }

        private void f_tao_t_congkhai()
        {
            user = m.user;
            string sql = "select doituong from " + user + ".t_congkhai1 where 1=2";
            DataSet lds = m.get_data(sql);
            if (lds == null || lds.Tables.Count <= 0)
            {
                sql = " create table " + user + ".t_congkhai1 (makp varchar(2),  maql numeric(22)DEFAULT 0, mabd numeric(7) DEFAULT 0, ngay varchar(8), soluong numeric(11,2) DEFAULT 0, sotien numeric(14,2)DEFAULT 0, dongia numeric(24,10)DEFAULT 0, loai numeric(1)DEFAULT 0, madoituong numeric(2)) WITH OIDS";
                m.execute_data(sql);
            }
            //Tu:10/08/2011
            sql = "select doituong from " + user + ".t_congkhai where 1=2";
            lds = m.get_data(sql);
            if (lds == null || lds.Tables.Count <= 0)
            {
                sql = " alter table " + user + ".t_congkhai add madoituong numeric(2)";
                m.execute_data(sql);
            }
            //end TU
        }

        private void txtTieude_Validated(object sender, EventArgs e)
        {
            txtTieude.Text = txtTieude.Text.ToUpper();
        }

        private void chkInnhieuphieu_CheckedChanged(object sender, EventArgs e)
        {
            if (chkInnhieuphieu.Checked)
                chkDoituong.Checked = true;
        }

        private void cmbDoituong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbDoituong.Text.Trim()!="")
                chkDoituong.Checked = true;
        }

        private void get_phong_giuong(string m_mabn, string m_maql,string m_idkhoa, string m_makp, ref string a_phong, ref string a_giuong)
        {
            sql = "select giuong from " + m.user + ".nhapkhoa where mabn='" + m_mabn + "' and maql=" + m_maql;
            if (m_makp.Trim() != "") sql += " and makp='" + m_makp + "'";
            if (m_idkhoa.Trim() != "" && m_idkhoa.Trim() != "0") sql += " and id=" + m_idkhoa;
            DataSet lds = m.get_data(sql);
            if (lds != null && lds.Tables.Count > 0)
            {
                foreach (DataRow r in lds.Tables[0].Rows)
                {
                    a_giuong = r["giuong"].ToString();
                }
            }
            string[] arr_giuong = a_giuong.Split('/');
            if (arr_giuong.Length > 1)
            {
                a_giuong = arr_giuong[1];
                a_phong = arr_giuong[0];
            }
            else a_phong = "";

        }
        private void get_tong_tamung(string m_tu, string m_den, string m_mabn, string m_mavaovien, string m_maql, ref decimal d_tamung)
        {
            sql = "select sotien from xxx.v_tamung where done=0 and mabn='" + m_mabn + "'";
            if (m_mavaovien != "" && m_mavaovien != "0") sql += " and mavaovien=" + m_mavaovien;
            else if (m_maql != "" && m_maql != "0") sql += " and maql=" + m_maql;

            DataSet lds = m.get_data_mmyy(sql, m_tu, m_den, true);
            d_tamung = 0;
            if(lds!=null && lds.Tables.Count >0)
            {
                foreach(DataRow r in lds.Tables[0].Rows)
                {
                    d_tamung+=decimal.Parse(r["sotien"].ToString());
                }
            }
        }
	}
}
