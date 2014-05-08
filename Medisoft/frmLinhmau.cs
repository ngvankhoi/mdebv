using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Data;
using LibDuoc;
using LibMedi;

namespace Medisoft
{
	/// <summary>
	/// Summary description for frmLinhmau.
	/// </summary>
	public class frmLinhmau : System.Windows.Forms.Form
	{
        Language lan = new Language(); Bogotiengviet tv = new Bogotiengviet(); private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.TextBox chandoan;
		private System.Windows.Forms.TextBox sothe;
		private System.Windows.Forms.TextBox giuong;
		private System.Windows.Forms.TextBox phong;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox diachi;
		private System.Windows.Forms.TextBox phai;
		private System.Windows.Forms.TextBox namsinh;
		private System.Windows.Forms.TextBox hoten;
		private System.Windows.Forms.TextBox mabn;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox sovaovien;
		private System.Windows.Forms.TextBox tenbs;
		private MaskedTextBox.MaskedTextBox mabs;
		private System.Windows.Forms.Label label87;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Button butMoi;
		private System.Windows.Forms.Button butSua;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.Button butHuy;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.Button butKetthuc;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.TextBox ngayvv;
		private MaskedBox.MaskedBox ngay;
		private System.ComponentModel.IContainer components;
		private DataSet ds=new DataSet();
		private DataSet dsh=new DataSet();
		private DataTable dtnv=new DataTable(); 
		private LibMedi.AccessData m;
		private LibDuoc.AccessData d=new LibDuoc.AccessData();
		private int i_userid,i_stt=0;
		private string s_makp,user,xxx,s_ngayrv,sql,s_mabs,mmyy,s_nhomkho,s_userid,s_tenkp;
		private decimal l_id,l_idthuchien,l_idkhoa,l_maql;
		private LibList.List listNv;
		private Brush disabledBackBrush;
		private Brush disabledTextBrush;
		private Brush alertBackBrush;
		private Font alertFont;
		private Brush alertTextBrush;
		private Font currentRowFont;
		private Brush currentRowBackBrush;
		private bool afterCurrentCellChanged=true,bAdmin;
		private int checkCol=0;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.ComboBox cmbngay;
		private System.Windows.Forms.Button butXoa;
		private System.Windows.Forms.Button butThem;
		private System.Windows.Forms.Label lgio;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.TextBox sophieu;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox chephamct;
		private System.Windows.Forms.TextBox tennguoilinh;
		private MaskedTextBox.MaskedTextBox nguoilinh;
		private System.Windows.Forms.TextBox maso;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.TextBox tenkp;
		private System.Windows.Forms.TextBox tenbv;
		private System.Windows.Forms.TextBox donvi;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.TextBox chepham;
		private System.Windows.Forms.Label label28;
		private System.Windows.Forms.ComboBox nhommau;
		private System.Windows.Forms.Label label29;
		private System.Windows.Forms.NumericUpDown lanthu;
		private System.Windows.Forms.Label label30;
		private System.Windows.Forms.Label label31;
		private System.Windows.Forms.TextBox bvphat;
		private System.Windows.Forms.TextBox phongphat;
		private System.Windows.Forms.Label label32;
		private System.Windows.Forms.Label label33;
		private System.Windows.Forms.Label label34;
		private System.Windows.Forms.TextBox dvphat;
		private System.Windows.Forms.Label label35;
		private System.Windows.Forms.Label label36;
		private System.Windows.Forms.ComboBox nhommauct;
		private System.Windows.Forms.Label label37;
		private MaskedBox.MaskedBox ngayphat;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.TextBox tennguoiphat;
		private MaskedTextBox.MaskedTextBox truongkhoa;
		private MaskedTextBox.MaskedTextBox nguoiphat;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.TextBox tentruongkhoa;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.CheckBox chkXML;

		public frmLinhmau(LibMedi.AccessData acc,string _mabn,decimal _maql,decimal _idkhoa,string _sovaovien,string _makp,string _hoten,string _namsinh,string _phai,string _diachi,string _ngayvv,string _sothe,string _phong,string _giuong,string _ngayrv,string _mabs,int _userid,string _nhomkho,string suserid,string _chandoan,string _tenkp,bool _admin)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			m=acc;mabn.Text=_mabn;l_maql=_maql;l_idkhoa=_idkhoa;sovaovien.Text=_sovaovien;i_userid=_userid;s_tenkp=_tenkp;
			hoten.Text=_hoten;chandoan.Text=_chandoan;s_makp=_makp;namsinh.Text=_namsinh;phai.Text=_phai;diachi.Text=_diachi;s_mabs=_mabs;s_nhomkho=_nhomkho;
			ngayvv.Text=_ngayvv;sothe.Text=_sothe;phong.Text=_phong;giuong.Text=_giuong;s_ngayrv=_ngayrv;s_userid=suserid;bAdmin=_admin;
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
					if(disabledBackBrush != null)
					{
						disabledBackBrush.Dispose();
						disabledTextBrush.Dispose();
						alertBackBrush.Dispose();
						alertFont.Dispose();
						alertTextBrush.Dispose();
						currentRowFont.Dispose();
						currentRowBackBrush.Dispose();
					}
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLinhmau));
            this.chandoan = new System.Windows.Forms.TextBox();
            this.sothe = new System.Windows.Forms.TextBox();
            this.giuong = new System.Windows.Forms.TextBox();
            this.phong = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.ngayvv = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.diachi = new System.Windows.Forms.TextBox();
            this.phai = new System.Windows.Forms.TextBox();
            this.namsinh = new System.Windows.Forms.TextBox();
            this.hoten = new System.Windows.Forms.TextBox();
            this.mabn = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.sovaovien = new System.Windows.Forms.TextBox();
            this.ngay = new MaskedBox.MaskedBox();
            this.tenbs = new System.Windows.Forms.TextBox();
            this.mabs = new MaskedTextBox.MaskedTextBox();
            this.label87 = new System.Windows.Forms.Label();
            this.chephamct = new System.Windows.Forms.TextBox();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.butMoi = new System.Windows.Forms.Button();
            this.butSua = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butHuy = new System.Windows.Forms.Button();
            this.butIn = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.listNv = new LibList.List();
            this.chkXML = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tennguoilinh = new System.Windows.Forms.TextBox();
            this.nguoilinh = new MaskedTextBox.MaskedTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.maso = new System.Windows.Forms.TextBox();
            this.cmbngay = new System.Windows.Forms.ComboBox();
            this.lgio = new System.Windows.Forms.Label();
            this.butXoa = new System.Windows.Forms.Button();
            this.butThem = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.sophieu = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.tenkp = new System.Windows.Forms.TextBox();
            this.tenbv = new System.Windows.Forms.TextBox();
            this.donvi = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.chepham = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.nhommau = new System.Windows.Forms.ComboBox();
            this.label29 = new System.Windows.Forms.Label();
            this.lanthu = new System.Windows.Forms.NumericUpDown();
            this.label30 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.bvphat = new System.Windows.Forms.TextBox();
            this.phongphat = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.dvphat = new System.Windows.Forms.TextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.nhommauct = new System.Windows.Forms.ComboBox();
            this.label37 = new System.Windows.Forms.Label();
            this.ngayphat = new MaskedBox.MaskedBox();
            this.label16 = new System.Windows.Forms.Label();
            this.tennguoiphat = new System.Windows.Forms.TextBox();
            this.truongkhoa = new MaskedTextBox.MaskedTextBox();
            this.nguoiphat = new MaskedTextBox.MaskedTextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.tentruongkhoa = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lanthu)).BeginInit();
            this.SuspendLayout();
            // 
            // chandoan
            // 
            this.chandoan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.chandoan.Enabled = false;
            this.chandoan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chandoan.Location = new System.Drawing.Point(75, 12);
            this.chandoan.Name = "chandoan";
            this.chandoan.Size = new System.Drawing.Size(461, 21);
            this.chandoan.TabIndex = 71;
            // 
            // sothe
            // 
            this.sothe.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sothe.Enabled = false;
            this.sothe.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sothe.Location = new System.Drawing.Point(177, 273);
            this.sothe.Name = "sothe";
            this.sothe.Size = new System.Drawing.Size(56, 21);
            this.sothe.TabIndex = 63;
            // 
            // giuong
            // 
            this.giuong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.giuong.Enabled = false;
            this.giuong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.giuong.Location = new System.Drawing.Point(177, 273);
            this.giuong.Name = "giuong";
            this.giuong.Size = new System.Drawing.Size(56, 21);
            this.giuong.TabIndex = 70;
            // 
            // phong
            // 
            this.phong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.phong.Enabled = false;
            this.phong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phong.Location = new System.Drawing.Point(177, 273);
            this.phong.Name = "phong";
            this.phong.Size = new System.Drawing.Size(56, 21);
            this.phong.TabIndex = 69;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(14, 13);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(73, 16);
            this.label13.TabIndex = 68;
            this.label13.Text = "Chẩn đoán :";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(177, 273);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 16);
            this.label12.TabIndex = 67;
            this.label12.Text = "Giường :";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(177, 273);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 16);
            this.label11.TabIndex = 66;
            this.label11.Text = "Phòng :";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ngayvv
            // 
            this.ngayvv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngayvv.Enabled = false;
            this.ngayvv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngayvv.Location = new System.Drawing.Point(177, 273);
            this.ngayvv.Name = "ngayvv";
            this.ngayvv.Size = new System.Drawing.Size(56, 21);
            this.ngayvv.TabIndex = 65;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(177, 273);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 16);
            this.label7.TabIndex = 64;
            this.label7.Text = "Ngày :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(177, 273);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 16);
            this.label6.TabIndex = 62;
            this.label6.Text = "Số thẻ :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // diachi
            // 
            this.diachi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.diachi.Enabled = false;
            this.diachi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diachi.Location = new System.Drawing.Point(177, 273);
            this.diachi.Name = "diachi";
            this.diachi.Size = new System.Drawing.Size(56, 21);
            this.diachi.TabIndex = 61;
            // 
            // phai
            // 
            this.phai.BackColor = System.Drawing.SystemColors.HighlightText;
            this.phai.Enabled = false;
            this.phai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phai.Location = new System.Drawing.Point(177, 273);
            this.phai.Name = "phai";
            this.phai.Size = new System.Drawing.Size(56, 21);
            this.phai.TabIndex = 60;
            // 
            // namsinh
            // 
            this.namsinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.namsinh.Enabled = false;
            this.namsinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namsinh.Location = new System.Drawing.Point(177, 273);
            this.namsinh.Name = "namsinh";
            this.namsinh.Size = new System.Drawing.Size(56, 21);
            this.namsinh.TabIndex = 59;
            // 
            // hoten
            // 
            this.hoten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.hoten.Enabled = false;
            this.hoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoten.Location = new System.Drawing.Point(177, 273);
            this.hoten.Name = "hoten";
            this.hoten.Size = new System.Drawing.Size(56, 21);
            this.hoten.TabIndex = 58;
            // 
            // mabn
            // 
            this.mabn.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabn.Enabled = false;
            this.mabn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabn.Location = new System.Drawing.Point(177, 273);
            this.mabn.Name = "mabn";
            this.mabn.Size = new System.Drawing.Size(56, 21);
            this.mabn.TabIndex = 52;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(177, 273);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 16);
            this.label5.TabIndex = 57;
            this.label5.Text = "Địa chỉ :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(177, 273);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 16);
            this.label4.TabIndex = 56;
            this.label4.Text = "Giới tính :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(177, 273);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 16);
            this.label3.TabIndex = 55;
            this.label3.Text = "NS :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(177, 273);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 54;
            this.label1.Text = "Họ tên :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(177, 273);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 16);
            this.label10.TabIndex = 53;
            this.label10.Text = "Mã BN :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(177, 273);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 72;
            this.label2.Text = "Số vào viện :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sovaovien
            // 
            this.sovaovien.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sovaovien.Enabled = false;
            this.sovaovien.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sovaovien.Location = new System.Drawing.Point(177, 273);
            this.sovaovien.Name = "sovaovien";
            this.sovaovien.Size = new System.Drawing.Size(56, 21);
            this.sovaovien.TabIndex = 73;
            // 
            // ngay
            // 
            this.ngay.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngay.Enabled = false;
            this.ngay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngay.Location = new System.Drawing.Point(712, 12);
            this.ngay.Mask = "##/##/####";
            this.ngay.Name = "ngay";
            this.ngay.Size = new System.Drawing.Size(72, 21);
            this.ngay.TabIndex = 2;
            this.ngay.Text = "  /  /    ";
            this.ngay.Visible = false;
            this.ngay.Validated += new System.EventHandler(this.ngay_Validated);
            // 
            // tenbs
            // 
            this.tenbs.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbs.Enabled = false;
            this.tenbs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbs.Location = new System.Drawing.Point(586, 128);
            this.tenbs.Name = "tenbs";
            this.tenbs.Size = new System.Drawing.Size(202, 21);
            this.tenbs.TabIndex = 12;
            this.tenbs.TextChanged += new System.EventHandler(this.tenbs_TextChanged);
            this.tenbs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbs_KeyDown);
            // 
            // mabs
            // 
            this.mabs.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mabs.Enabled = false;
            this.mabs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabs.Location = new System.Drawing.Point(539, 128);
            this.mabs.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.mabs.MaxLength = 9;
            this.mabs.Name = "mabs";
            this.mabs.Size = new System.Drawing.Size(41, 21);
            this.mabs.TabIndex = 11;
            this.mabs.Validated += new System.EventHandler(this.mabs_Validated);
            this.mabs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // label87
            // 
            this.label87.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label87.Location = new System.Drawing.Point(403, 131);
            this.label87.Name = "label87";
            this.label87.Size = new System.Drawing.Size(136, 16);
            this.label87.TabIndex = 300;
            this.label87.Text = "Trưởng khoa điều trị :";
            this.label87.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chephamct
            // 
            this.chephamct.BackColor = System.Drawing.SystemColors.HighlightText;
            this.chephamct.Enabled = false;
            this.chephamct.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chephamct.Location = new System.Drawing.Point(75, 435);
            this.chephamct.Name = "chephamct";
            this.chephamct.Size = new System.Drawing.Size(376, 21);
            this.chephamct.TabIndex = 17;
            this.chephamct.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // dataGrid1
            // 
            this.dataGrid1.AlternatingBackColor = System.Drawing.Color.Lavender;
            this.dataGrid1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid1.CaptionBackColor = System.Drawing.SystemColors.Control;
            this.dataGrid1.CaptionFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid1.CaptionForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.DataMember = "";
            this.dataGrid1.FlatMode = true;
            this.dataGrid1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.GridLineColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dataGrid1.HeaderFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.dataGrid1.HeaderForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.LinkColor = System.Drawing.Color.Teal;
            this.dataGrid1.Location = new System.Drawing.Point(6, 204);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(778, 226);
            this.dataGrid1.TabIndex = 310;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            this.dataGrid1.Click += new System.EventHandler(this.dataGrid1_Click);
            // 
            // butMoi
            // 
            this.butMoi.Location = new System.Drawing.Point(114, 496);
            this.butMoi.Name = "butMoi";
            this.butMoi.Size = new System.Drawing.Size(70, 25);
            this.butMoi.TabIndex = 28;
            this.butMoi.Text = "&Mới";
            this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
            // 
            // butSua
            // 
            this.butSua.Location = new System.Drawing.Point(184, 496);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(70, 25);
            this.butSua.TabIndex = 29;
            this.butSua.Text = "&Sữa";
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butLuu
            // 
            this.butLuu.Enabled = false;
            this.butLuu.Location = new System.Drawing.Point(254, 496);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 26;
            this.butLuu.Text = "&Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Enabled = false;
            this.butBoqua.Location = new System.Drawing.Point(464, 496);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(70, 25);
            this.butBoqua.TabIndex = 27;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butHuy
            // 
            this.butHuy.Location = new System.Drawing.Point(534, 496);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(70, 25);
            this.butHuy.TabIndex = 30;
            this.butHuy.Text = "&Hủy";
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // butIn
            // 
            this.butIn.Location = new System.Drawing.Point(604, 496);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 31;
            this.butIn.Text = "&In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Location = new System.Drawing.Point(674, 496);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 32;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // listNv
            // 
            this.listNv.BackColor = System.Drawing.SystemColors.Info;
            this.listNv.ColumnCount = 0;
            this.listNv.Location = new System.Drawing.Point(704, 504);
            this.listNv.MatchBufferTimeOut = 1000;
            this.listNv.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listNv.Name = "listNv";
            this.listNv.Size = new System.Drawing.Size(75, 17);
            this.listNv.TabIndex = 311;
            this.listNv.TextIndex = -1;
            this.listNv.TextMember = null;
            this.listNv.ValueIndex = -1;
            this.listNv.Visible = false;
            // 
            // chkXML
            // 
            this.chkXML.Location = new System.Drawing.Point(8, 496);
            this.chkXML.Name = "chkXML";
            this.chkXML.Size = new System.Drawing.Size(104, 24);
            this.chkXML.TabIndex = 313;
            this.chkXML.Text = "Xuất ra XML";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(3, 436);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(160, 16);
            this.label8.TabIndex = 314;
            this.label8.Text = "Loại chế phẩm :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tennguoilinh
            // 
            this.tennguoilinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tennguoilinh.Enabled = false;
            this.tennguoilinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tennguoilinh.Location = new System.Drawing.Point(119, 128);
            this.tennguoilinh.Name = "tennguoilinh";
            this.tennguoilinh.Size = new System.Drawing.Size(257, 21);
            this.tennguoilinh.TabIndex = 10;
            this.tennguoilinh.TextChanged += new System.EventHandler(this.tennguoilinh_TextChanged);
            this.tennguoilinh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbs_KeyDown);
            // 
            // nguoilinh
            // 
            this.nguoilinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nguoilinh.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nguoilinh.Enabled = false;
            this.nguoilinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nguoilinh.Location = new System.Drawing.Point(75, 128);
            this.nguoilinh.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.nguoilinh.MaxLength = 9;
            this.nguoilinh.Name = "nguoilinh";
            this.nguoilinh.Size = new System.Drawing.Size(41, 21);
            this.nguoilinh.TabIndex = 9;
            this.nguoilinh.Validated += new System.EventHandler(this.nguoilinh_Validated);
            this.nguoilinh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(14, 131);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(72, 16);
            this.label14.TabIndex = 319;
            this.label14.Text = "Người lĩnh :";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // maso
            // 
            this.maso.BackColor = System.Drawing.SystemColors.HighlightText;
            this.maso.Enabled = false;
            this.maso.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maso.Location = new System.Drawing.Point(512, 435);
            this.maso.Name = "maso";
            this.maso.Size = new System.Drawing.Size(104, 21);
            this.maso.TabIndex = 18;
            this.maso.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // cmbngay
            // 
            this.cmbngay.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cmbngay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbngay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbngay.Location = new System.Drawing.Point(589, 12);
            this.cmbngay.Name = "cmbngay";
            this.cmbngay.Size = new System.Drawing.Size(195, 21);
            this.cmbngay.TabIndex = 0;
            this.cmbngay.SelectedIndexChanged += new System.EventHandler(this.cmbngay_SelectedIndexChanged);
            this.cmbngay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // lgio
            // 
            this.lgio.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lgio.Location = new System.Drawing.Point(673, 13);
            this.lgio.Name = "lgio";
            this.lgio.Size = new System.Drawing.Size(40, 16);
            this.lgio.TabIndex = 339;
            this.lgio.Text = "Ngày :";
            this.lgio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lgio.Visible = false;
            // 
            // butXoa
            // 
            this.butXoa.Enabled = false;
            this.butXoa.Location = new System.Drawing.Point(394, 496);
            this.butXoa.Name = "butXoa";
            this.butXoa.Size = new System.Drawing.Size(70, 25);
            this.butXoa.TabIndex = 25;
            this.butXoa.Text = "&Xóa";
            this.butXoa.Click += new System.EventHandler(this.butXoa_Click);
            // 
            // butThem
            // 
            this.butThem.Enabled = false;
            this.butThem.Location = new System.Drawing.Point(324, 496);
            this.butThem.Name = "butThem";
            this.butThem.Size = new System.Drawing.Size(70, 25);
            this.butThem.TabIndex = 24;
            this.butThem.Text = "&Thêm";
            this.butThem.Click += new System.EventHandler(this.butThem_Click);
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(525, 13);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(64, 16);
            this.label15.TabIndex = 340;
            this.label15.Text = "Số phiếu :";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sophieu
            // 
            this.sophieu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sophieu.Enabled = false;
            this.sophieu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sophieu.Location = new System.Drawing.Point(589, 12);
            this.sophieu.Name = "sophieu";
            this.sophieu.Size = new System.Drawing.Size(80, 21);
            this.sophieu.TabIndex = 1;
            this.sophieu.Visible = false;
            this.sophieu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(14, 62);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 16);
            this.label9.TabIndex = 342;
            this.label9.Text = "Khoa :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label24
            // 
            this.label24.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(192, 62);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(64, 16);
            this.label24.TabIndex = 343;
            this.label24.Text = "Bệnh viện :";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label25
            // 
            this.label25.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(525, 62);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(64, 16);
            this.label25.TabIndex = 344;
            this.label25.Text = "Lĩnh :";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label26
            // 
            this.label26.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(744, 62);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(40, 16);
            this.label26.TabIndex = 345;
            this.label26.Text = "đơn vị";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tenkp
            // 
            this.tenkp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenkp.Enabled = false;
            this.tenkp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenkp.Location = new System.Drawing.Point(75, 59);
            this.tenkp.Name = "tenkp";
            this.tenkp.Size = new System.Drawing.Size(109, 21);
            this.tenkp.TabIndex = 3;
            // 
            // tenbv
            // 
            this.tenbv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbv.Enabled = false;
            this.tenbv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbv.Location = new System.Drawing.Point(256, 59);
            this.tenbv.Name = "tenbv";
            this.tenbv.Size = new System.Drawing.Size(280, 21);
            this.tenbv.TabIndex = 4;
            // 
            // donvi
            // 
            this.donvi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.donvi.Enabled = false;
            this.donvi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.donvi.Location = new System.Drawing.Point(589, 59);
            this.donvi.Name = "donvi";
            this.donvi.Size = new System.Drawing.Size(147, 21);
            this.donvi.TabIndex = 5;
            this.donvi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // label27
            // 
            this.label27.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(14, 85);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(336, 16);
            this.label27.TabIndex = 349;
            this.label27.Text = "Máu, chế phẩm máu (ghi rõ máu toàn phần hay chế phẩm gì ) :";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chepham
            // 
            this.chepham.BackColor = System.Drawing.SystemColors.HighlightText;
            this.chepham.Enabled = false;
            this.chepham.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chepham.Location = new System.Drawing.Point(332, 82);
            this.chepham.Name = "chepham";
            this.chepham.Size = new System.Drawing.Size(456, 21);
            this.chepham.TabIndex = 6;
            this.chepham.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // label28
            // 
            this.label28.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(14, 107);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(80, 16);
            this.label28.TabIndex = 351;
            this.label28.Text = "Nhóm máu :";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nhommau
            // 
            this.nhommau.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nhommau.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nhommau.Enabled = false;
            this.nhommau.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhommau.Location = new System.Drawing.Point(75, 105);
            this.nhommau.Name = "nhommau";
            this.nhommau.Size = new System.Drawing.Size(109, 21);
            this.nhommau.TabIndex = 7;
            this.nhommau.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // label29
            // 
            this.label29.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(216, 107);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(112, 16);
            this.label29.TabIndex = 353;
            this.label29.Text = "Truyền máu lần thứ :";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lanthu
            // 
            this.lanthu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.lanthu.Enabled = false;
            this.lanthu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lanthu.Location = new System.Drawing.Point(328, 105);
            this.lanthu.Name = "lanthu";
            this.lanthu.Size = new System.Drawing.Size(48, 21);
            this.lanthu.TabIndex = 8;
            this.lanthu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // label30
            // 
            this.label30.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label30.Location = new System.Drawing.Point(16, 38);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(248, 16);
            this.label30.TabIndex = 355;
            this.label30.Text = "I. PHẦN DÀNH CHO NGƯỜI LĨNH MÁU :";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label31
            // 
            this.label31.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label31.Location = new System.Drawing.Point(16, 155);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(248, 16);
            this.label31.TabIndex = 356;
            this.label31.Text = "II. PHẦN DÀNH CHO NGƯỜI PHÁT MÁU :";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bvphat
            // 
            this.bvphat.BackColor = System.Drawing.SystemColors.HighlightText;
            this.bvphat.Enabled = false;
            this.bvphat.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bvphat.Location = new System.Drawing.Point(540, 176);
            this.bvphat.Name = "bvphat";
            this.bvphat.Size = new System.Drawing.Size(248, 21);
            this.bvphat.TabIndex = 15;
            this.bvphat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // phongphat
            // 
            this.phongphat.BackColor = System.Drawing.SystemColors.HighlightText;
            this.phongphat.Enabled = false;
            this.phongphat.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phongphat.Location = new System.Drawing.Point(256, 176);
            this.phongphat.Name = "phongphat";
            this.phongphat.Size = new System.Drawing.Size(224, 21);
            this.phongphat.TabIndex = 14;
            this.phongphat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // label32
            // 
            this.label32.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.Location = new System.Drawing.Point(475, 179);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(64, 16);
            this.label32.TabIndex = 358;
            this.label32.Text = "Bệnh viện :";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label33
            // 
            this.label33.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.Location = new System.Drawing.Point(168, 179);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(98, 16);
            this.label33.TabIndex = 357;
            this.label33.Text = "Phòng phát máu :";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label34
            // 
            this.label34.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.Location = new System.Drawing.Point(16, 203);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(336, 16);
            this.label34.TabIndex = 361;
            this.label34.Text = "Tổng số đơn vị máu, chế phẩm máu phát :";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dvphat
            // 
            this.dvphat.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dvphat.Enabled = false;
            this.dvphat.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dvphat.Location = new System.Drawing.Point(224, 200);
            this.dvphat.Name = "dvphat";
            this.dvphat.Size = new System.Drawing.Size(512, 21);
            this.dvphat.TabIndex = 16;
            this.dvphat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // label35
            // 
            this.label35.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label35.Location = new System.Drawing.Point(744, 203);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(40, 16);
            this.label35.TabIndex = 362;
            this.label35.Text = "đơn vị";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label36
            // 
            this.label36.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.Location = new System.Drawing.Point(465, 439);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(48, 16);
            this.label36.TabIndex = 364;
            this.label36.Text = "Mã số :";
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nhommauct
            // 
            this.nhommauct.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nhommauct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nhommauct.Enabled = false;
            this.nhommauct.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhommauct.Location = new System.Drawing.Point(679, 435);
            this.nhommauct.Name = "nhommauct";
            this.nhommauct.Size = new System.Drawing.Size(109, 21);
            this.nhommauct.TabIndex = 19;
            this.nhommauct.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // label37
            // 
            this.label37.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label37.Location = new System.Drawing.Point(620, 438);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(80, 16);
            this.label37.TabIndex = 366;
            this.label37.Text = "Nhóm máu :";
            this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ngayphat
            // 
            this.ngayphat.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngayphat.Enabled = false;
            this.ngayphat.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngayphat.Location = new System.Drawing.Point(75, 176);
            this.ngayphat.Mask = "##/##/####";
            this.ngayphat.Name = "ngayphat";
            this.ngayphat.Size = new System.Drawing.Size(72, 21);
            this.ngayphat.TabIndex = 13;
            this.ngayphat.Text = "  /  /    ";
            this.ngayphat.Validated += new System.EventHandler(this.ngayphat_Validated);
            this.ngayphat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(14, 179);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(40, 16);
            this.label16.TabIndex = 368;
            this.label16.Text = "Ngày :";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tennguoiphat
            // 
            this.tennguoiphat.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tennguoiphat.Enabled = false;
            this.tennguoiphat.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tennguoiphat.Location = new System.Drawing.Point(118, 458);
            this.tennguoiphat.Name = "tennguoiphat";
            this.tennguoiphat.Size = new System.Drawing.Size(250, 21);
            this.tennguoiphat.TabIndex = 21;
            this.tennguoiphat.TextChanged += new System.EventHandler(this.tennguoiphat_TextChanged);
            this.tennguoiphat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbs_KeyDown);
            // 
            // truongkhoa
            // 
            this.truongkhoa.BackColor = System.Drawing.SystemColors.HighlightText;
            this.truongkhoa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.truongkhoa.Enabled = false;
            this.truongkhoa.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.truongkhoa.Location = new System.Drawing.Point(512, 458);
            this.truongkhoa.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.truongkhoa.MaxLength = 9;
            this.truongkhoa.Name = "truongkhoa";
            this.truongkhoa.Size = new System.Drawing.Size(41, 21);
            this.truongkhoa.TabIndex = 22;
            this.truongkhoa.Validated += new System.EventHandler(this.truongkhoa_Validated);
            this.truongkhoa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // nguoiphat
            // 
            this.nguoiphat.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nguoiphat.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nguoiphat.Enabled = false;
            this.nguoiphat.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nguoiphat.Location = new System.Drawing.Point(75, 458);
            this.nguoiphat.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.nguoiphat.MaxLength = 9;
            this.nguoiphat.Name = "nguoiphat";
            this.nguoiphat.Size = new System.Drawing.Size(41, 21);
            this.nguoiphat.TabIndex = 20;
            this.nguoiphat.Validated += new System.EventHandler(this.nguoiphat_Validated);
            this.nguoiphat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(14, 461);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(72, 16);
            this.label17.TabIndex = 374;
            this.label17.Text = "Người phát :";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tentruongkhoa
            // 
            this.tentruongkhoa.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tentruongkhoa.Enabled = false;
            this.tentruongkhoa.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tentruongkhoa.Location = new System.Drawing.Point(555, 458);
            this.tentruongkhoa.Name = "tentruongkhoa";
            this.tentruongkhoa.Size = new System.Drawing.Size(233, 21);
            this.tentruongkhoa.TabIndex = 23;
            this.tentruongkhoa.TextChanged += new System.EventHandler(this.tentruongkhoa_TextChanged);
            this.tentruongkhoa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbs_KeyDown);
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(361, 461);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(152, 16);
            this.label18.TabIndex = 373;
            this.label18.Text = "Trưởng khoa XN. phát máu :";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmLinhmau
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(829, 579);
            this.Controls.Add(this.butXoa);
            this.Controls.Add(this.butThem);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.butHuy);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butSua);
            this.Controls.Add(this.butMoi);
            this.Controls.Add(this.tennguoiphat);
            this.Controls.Add(this.truongkhoa);
            this.Controls.Add(this.nguoiphat);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.tentruongkhoa);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.ngayphat);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.maso);
            this.Controls.Add(this.nhommauct);
            this.Controls.Add(this.label37);
            this.Controls.Add(this.label36);
            this.Controls.Add(this.dvphat);
            this.Controls.Add(this.label35);
            this.Controls.Add(this.label34);
            this.Controls.Add(this.bvphat);
            this.Controls.Add(this.phongphat);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.label33);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.lanthu);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.nhommau);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.chepham);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.donvi);
            this.Controls.Add(this.tenbv);
            this.Controls.Add(this.tenkp);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.sophieu);
            this.Controls.Add(this.chandoan);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.ngay);
            this.Controls.Add(this.tennguoilinh);
            this.Controls.Add(this.lgio);
            this.Controls.Add(this.cmbngay);
            this.Controls.Add(this.mabs);
            this.Controls.Add(this.chephamct);
            this.Controls.Add(this.nguoilinh);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.chkXML);
            this.Controls.Add(this.listNv);
            this.Controls.Add(this.tenbs);
            this.Controls.Add(this.label87);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.ngayvv);
            this.Controls.Add(this.sovaovien);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.sothe);
            this.Controls.Add(this.giuong);
            this.Controls.Add(this.phong);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.diachi);
            this.Controls.Add(this.phai);
            this.Controls.Add(this.namsinh);
            this.Controls.Add(this.hoten);
            this.Controls.Add(this.mabn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label10);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLinhmau";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phiếu lĩnh và phát máu";
            this.Load += new System.EventHandler(this.frmLinhmau_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lanthu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmLinhmau_Load(object sender, System.EventArgs e)
		{
            this.Location = new System.Drawing.Point(188, 151);
            user=m.user;
	
			nhommau.DisplayMember="TEN";
			nhommau.ValueMember="MA";
            nhommau.DataSource = m.get_data("select * from " + user + ".dmnhommau where ma<>0").Tables[0];

			nhommauct.DisplayMember="TEN";
			nhommauct.ValueMember="MA";
            nhommauct.DataSource = m.get_data("select * from " + user + ".dmnhommau where ma<>0").Tables[0];

            dtnv = m.get_data("select * from " + user + ".dmbs where nhom<>" + LibMedi.AccessData.nghiviec + " order by hoten").Tables[0];
			listNv.DisplayMember="MA";
			listNv.ValueMember="HOTEN";
			listNv.DataSource=dtnv;

			xxx=user+m.mmyy(ngayvv.Text);
			sql="select a.id,a.idthuchien,a.sophieu,to_char(a.ngaylinh,'dd/mm/yyyy') as ngaylinh,";
			sql+="a.donvi,a.chepham,a.nhommau,a.lanthu,a.nguoilinh,a.bsdt,a.phongphat,a.bvphat,a.dvphat,";
			sql+="to_char(a.ngayphat,'dd/mm/yyyy') as ngayphat,a.nguoiphat,a.truongkhoa";
			sql+=" from "+xxx+".ba_linhmau a,"+xxx+".ba_thuchien b ";
			sql+=" where a.idthuchien=b.id and b.idkhoa="+l_idkhoa;
			sql+=" order by a.id";

			dsh=m.get_data(sql);
			cmbngay.DisplayMember="NGAYLINH";
			cmbngay.ValueMember="ID";
			cmbngay.DataSource=dsh.Tables[0];
			l_id=(dsh.Tables[0].Rows.Count>0)?decimal.Parse(dsh.Tables[0].Rows[0]["id"].ToString()):0;
			load_head();
			load_grid();

			AddGridTableStyle();
			this.disabledBackBrush = new SolidBrush(Color.Black);
			this.disabledTextBrush = new SolidBrush(Color.Red);

			this.alertBackBrush = new SolidBrush(SystemColors.HotTrack);
			this.alertFont = new Font(this.dataGrid1.Font.Name, this.dataGrid1.Font.Size, FontStyle.Bold);
			this.alertTextBrush = new SolidBrush(Color.White);
			
			this.currentRowFont = new Font(this.dataGrid1.Font.Name, this.dataGrid1.Font.Size, FontStyle.Regular);
			this.currentRowBackBrush = new SolidBrush(Color.FromArgb(0,255, 255));
			tenkp.Text=s_tenkp;
			tenbv.Text=m.Tenbv;
		}

		private void sophieu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void ngay_Validated(object sender, System.EventArgs e)
		{
			ngay.Text=ngay.Text.Trim();
			if (ngay.Text.Length==6) ngay.Text=ngay.Text+DateTime.Now.Year.ToString();
			if (!m.bNgay(ngay.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"));
				ngay.Focus();
				return;
			}
		}

		private void mabs_Validated(object sender, System.EventArgs e)
		{
			if (mabs.Text=="") return;
			DataRow r=m.getrowbyid(dtnv,"ma='"+mabs.Text+"'");
			if (r!=null) tenbs.Text=r["hoten"].ToString();
			else tenbs.Text="";	
		}

		private void tenbs_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tenbs)
			{
				Filt_dmbs(tenbs.Text);
				listNv.BrowseToDanhmuc(tenbs,mabs,ngayphat,35);
			}		
		}

		private void tenbs_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listNv.Focus(); 
			else if (e.KeyCode==Keys.Enter)
			{
				if (listNv.Visible) listNv.Focus();
				else SendKeys.Send("{Tab}");
			}	
		}

		private void Filt_dmbs(string ten)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listNv.DataSource];
				DataView dv=(DataView)cm.List;
				dv.RowFilter="hoten like '%"+ten.Trim()+"%'";
			}
			catch{}
		}

		private void load_grid()
		{
			sql="select a.*,b.ten as tennhommau from "+xxx+".ba_linhmauct a,"+user+".dmnhommau b where a.nhommau=b.ma and a.id="+l_id;
			sql+=" order by a.stt";
			ds=m.get_data(sql);
			ds.Tables[0].Columns.Add("Chon",typeof(bool));
			dataGrid1.DataSource=ds.Tables[0];
			CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource,dataGrid1.DataMember]; 
			DataView dv = (DataView) cm.List; 
			dv.AllowNew = false; 
			foreach (DataRow row in ds.Tables[0].Rows) row["chon"]=false;
			ref_text();
		}

		private void AddGridTableStyle()
		{
			DataGridTableStyle ts =new DataGridTableStyle();
			ts.MappingName = ds.Tables[0].TableName;
			ts.AlternatingBackColor = Color.Beige;
			ts.BackColor = Color.GhostWhite;
			ts.ForeColor = Color.MidnightBlue;
			ts.GridLineColor = Color.RoyalBlue;
			ts.HeaderBackColor = Color.MidnightBlue;
			ts.HeaderForeColor = Color.Lavender;
			ts.SelectionBackColor = Color.FromArgb(0,255,255);
			ts.SelectionForeColor = Color.PaleGreen;
			ts.RowHeaderWidth=5;
					
			
			FormattableBooleanColumn discontinuedCol = new FormattableBooleanColumn();
			discontinuedCol.MappingName = "chon";
			discontinuedCol.HeaderText = "";
			discontinuedCol.Width = 0;
			discontinuedCol.AllowNull = false;

			discontinuedCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			discontinuedCol.BoolValueChanged += new BoolValueChangedEventHandler(BoolValueChanged);
			ts.GridColumnStyles.Add(discontinuedCol);
			dataGrid1.TableStyles.Add(ts);
			
			FormattableTextBoxColumn TextCol1 = new FormattableTextBoxColumn();
			TextCol1.MappingName = "stt";
			TextCol1.HeaderText = "";
			TextCol1.Width = 0;
			TextCol1.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new FormattableTextBoxColumn();
			TextCol1.MappingName = "chepham";
			TextCol1.HeaderText = "Loại chế phẩm";
			TextCol1.Width =500;
			TextCol1.ReadOnly=true;
			TextCol1.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new FormattableTextBoxColumn();
			TextCol1.MappingName = "maso";
			TextCol1.HeaderText = "Mã số";
			TextCol1.Width =100;
			TextCol1.ReadOnly=true;
			TextCol1.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new FormattableTextBoxColumn();
			TextCol1.MappingName = "tennhommau";
			TextCol1.HeaderText = "Nhóm máu";
			TextCol1.Width =150;
			TextCol1.ReadOnly=true;
			TextCol1.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);
		}

		private void SetCellFormat(object sender, DataGridFormatCellEventArgs e)
		{
			try
			{
				bool discontinued = (bool) ((e.Column != 0) ? this.dataGrid1[e.Row, 0] : e.CurrentCellValue);
				if(e.Column > 0 && (bool)(this.dataGrid1[e.Row, 0])) e.ForeBrush = new SolidBrush(Color.Blue);
				else if(e.Column > 0 && e.Row == this.dataGrid1.CurrentRowIndex)
				{
					e.BackBrush = this.currentRowBackBrush;
					e.TextFont = this.currentRowFont;
				}				
			}
			catch{}
		}

		private void BoolValueChanged(object sender, BoolValueChangedEventArgs e)
		{
			this.dataGrid1.EndEdit(this.dataGrid1.TableStyles[0].GridColumnStyles["Discontinued"],e.Row, false);
			RefreshRow(e.Row);
			this.dataGrid1.BeginEdit(this.dataGrid1.TableStyles[0].GridColumnStyles["Discontinued"],e.Row);
		}
		private void RefreshRow(int row)
		{
			Rectangle rect = this.dataGrid1.GetCellBounds(row, 0);
			rect = new Rectangle(rect.Right, rect.Top, this.dataGrid1.Width, rect.Height);
			this.dataGrid1.Invalidate(rect);
		}

		private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			if((bool)this.dataGrid1[this.dataGrid1.CurrentRowIndex, checkCol])
				this.dataGrid1.CurrentCell = new DataGridCell(this.dataGrid1.CurrentRowIndex, checkCol);
			ref_text();
		}

		private void dataGrid1_Click(object sender, System.EventArgs e)
		{
			Point pt = this.dataGrid1.PointToClient(Control.MousePosition);
			DataGrid.HitTestInfo hti = this.dataGrid1.HitTest(pt);
			BindingManagerBase bmb = this.BindingContext[this.dataGrid1.DataSource, this.dataGrid1.DataMember];
			if(afterCurrentCellChanged && hti.Row < bmb.Count && hti.Type == DataGrid.HitTestType.Cell &&  hti.Column == checkCol )
			{	
				this.dataGrid1[hti.Row, checkCol] = !(bool)this.dataGrid1[hti.Row, checkCol];
				RefreshRow(hti.Row);
			}
		}

		private void ref_text()
		{
			try
			{
				int i_row=dataGrid1.CurrentCell.RowNumber;
				i_stt=int.Parse(dataGrid1[i_row,1].ToString());				
			}
			catch{i_stt=0;}
			load_items(i_stt);
		}

		private void load_items(int stt)
		{
			DataRow r=m.getrowbyid(ds.Tables[0],"stt="+stt);
			if (r!=null)
			{
				chephamct.Text=r["chepham"].ToString();
				maso.Text=r["maso"].ToString();
				nhommauct.SelectedValue=r["nhommau"].ToString();		
			}
		}

		private void emp_detail()
		{
			i_stt=1;
			if (ds.Tables[0].Rows.Count>0) i_stt=int.Parse(ds.Tables[0].Rows[ds.Tables[0].Rows.Count-1]["stt"].ToString())+1;
			chephamct.Text="";maso.Text="";nhommauct.SelectedIndex=0;
		}

		private void emp_text()
		{
			l_id=0;
			string _ngay=m.ngayhienhanh_server;
			ngay.Text=_ngay.Substring(0,10);
			ngayphat.Text=_ngay.Substring(0,10);
			sophieu.Text="";donvi.Text="";chepham.Text="";nhommau.SelectedIndex=0;
			lanthu.Value=1;nguoilinh.Text="";tennguoilinh.Text="";mabs.Text="";tenbs.Text="";
			phongphat.Text="";bvphat.Text="";dvphat.Text="";nguoiphat.Text="";tennguoiphat.Text="";
			truongkhoa.Text="";tentruongkhoa.Text="";
//			if (s_mabs!="")
//			{
//				mabs.Text=s_mabs;
//				DataRow r1=m.getrowbyid(dtnv,"ma='"+mabs.Text+"'");
//				if (r1!=null) 	tenbs.Text=r1["hoten"].ToString();
//				else tenbs.Text="";
//				if (mabs.Text!="" && tenbs.Text!="" && !bAdmin)
//				{
//					mabs.Enabled=false;tenbs.Enabled=false;
//				}
//			}
			ds.Clear();
			emp_detail();
		}

		private void ena_object(bool ena)
		{
			cmbngay.Visible=!ena;
			ngay.Visible=ena;
			lgio.Visible=ena;
			ngay.Enabled=ena;
			sophieu.Visible=ena;
			sophieu.Enabled=ena;
			donvi.Enabled=ena;
			chepham.Enabled=ena;
			lanthu.Enabled=ena;
			nhommau.Enabled=ena;
			nguoilinh.Enabled=ena;
			tennguoilinh.Enabled=ena;
			mabs.Enabled=ena;
			tenbs.Enabled=ena;
			ngayphat.Enabled=ena;
			phongphat.Enabled=ena;
			bvphat.Enabled=ena;
			dvphat.Enabled=ena;
			nguoiphat.Enabled=ena;
			tennguoiphat.Enabled=ena;
			truongkhoa.Enabled=ena;
			tentruongkhoa.Enabled=ena;
			chephamct.Enabled=ena;
			maso.Enabled=ena;
			nhommauct.Enabled=ena;

			butLuu.Enabled=ena;
			butBoqua.Enabled=ena;
			butMoi.Enabled=!ena;
			butSua.Enabled=!ena;
			butIn.Enabled=!ena;
			butHuy.Enabled=!ena;
			butKetthuc.Enabled=!ena;
			butThem.Enabled=ena;
			butXoa.Enabled=ena;
		}

		private void butMoi_Click(object sender, System.EventArgs e)
		{
			ena_object(true);
			emp_text();
			sophieu.Focus();
		}

		private void butSua_Click(object sender, System.EventArgs e)
		{
			if (dsh.Tables[0].Rows.Count==0) return;
			if (m.get_data("select * from "+user+m.mmyy(ngay.Text)+".ba_linhmau where id="+l_id+" and done=1").Tables[0].Rows.Count>0)
			{
				MessageBox.Show(lan.Change_language_MessageText("Đã thực hiện truyền máu !"),LibMedi.AccessData.Msg);
				return;
			}
			ena_object(true);
			chephamct.Focus();
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void butHuy_Click(object sender, System.EventArgs e)
		{
			if (ds.Tables[0].Rows.Count==0) return;
			if (m.get_data("select * from "+user+m.mmyy(ngay.Text)+".ba_linhmau where id="+l_id+" and done=1").Tables[0].Rows.Count>0)
			{
				MessageBox.Show(lan.Change_language_MessageText("Đã thực hiện truyền máu !"),LibMedi.AccessData.Msg);
				return;
			}
			if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý hủy thông tin này ?"),LibMedi.AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
			{
				xxx=user+m.mmyy(ngayvv.Text);
				m.execute_data("delete from "+xxx+".ba_linhmauct where id="+l_id);
				m.execute_data("delete from "+xxx+".ba_linhmau where id="+l_id);
				m.delrec(dsh.Tables[0],"id="+l_id);
				cmbngay.Refresh();
				l_id=(cmbngay.SelectedIndex!=-1)?decimal.Parse(cmbngay.SelectedValue.ToString()):0;
				load_head();
				load_grid();
			}
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			ena_object(false);
			if (l_id!=0) load_head();
			butMoi.Focus();
		}

		private bool kiemtra()
		{
			if (ngay.Text.Trim().Length!=10)
			{
				MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"),LibMedi.AccessData.Msg);
				ngay.Focus();
				return false;
			}
			if (chepham.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập máu, chế phẩm máu !"),LibMedi.AccessData.Msg);
				chepham.Focus();
				return false;
			}
			if (mabs.Text=="" || tenbs.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Trưởng khoa điều trị !"),LibMedi.AccessData.Msg);
				if (mabs.Text=="") mabs.Focus();
				else tenbs.Focus();
				return false;
			}
			if (mabs.Text!="" && tenbs.Text!="")
			{
				DataRow r=m.getrowbyid(dtnv,"ma='"+mabs.Text+"'");
				if (r==null)
				{
					MessageBox.Show(lan.Change_language_MessageText("Nhập trưởng khoa điều trị !"),LibMedi.AccessData.Msg);
					mabs.Focus();
					return false;
				}
			}
			if (nguoilinh.Text!="" && tennguoilinh.Text!="")
			{
				DataRow r=m.getrowbyid(dtnv,"ma='"+nguoilinh.Text+"'");
				if (r==null)
				{
					MessageBox.Show(lan.Change_language_MessageText("Nhập người lĩnh !"),LibMedi.AccessData.Msg);
					nguoilinh.Focus();
					return false;
				}
			}
			if (nguoiphat.Text!="" && tennguoiphat.Text!="")
			{
				DataRow r=m.getrowbyid(dtnv,"ma='"+nguoiphat.Text+"'");
				if (r==null)
				{
					MessageBox.Show(lan.Change_language_MessageText("Nhập người phát !"),LibMedi.AccessData.Msg);
					nguoiphat.Focus();
					return false;
				}
			}
			if (truongkhoa.Text!="" && tentruongkhoa.Text!="")
			{
				DataRow r=m.getrowbyid(dtnv,"ma='"+truongkhoa.Text+"'");
				if (r==null)
				{
					MessageBox.Show(lan.Change_language_MessageText("Nhập trưởng khoa xét nghiệm phát máu !"),LibMedi.AccessData.Msg);
					truongkhoa.Focus();
					return false;
				}
			}
			return true;
		}

		private bool kiemtrad()
		{
			if (ngayphat.Text!="")
			{
				if (ngayphat.Text.Trim().Length!=10)
				{
					MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"),LibMedi.AccessData.Msg);
					ngayphat.Focus();
					return false;
				}
				if (!m.bNgaygio(ngayphat.Text+" 00:00",ngay.Text+" 00:00"))
				{
					MessageBox.Show(lan.Change_language_MessageText("Ngày phát không được nhỏ hơn ngày lĩnh !"),LibMedi.AccessData.Msg);
					ngayphat.Focus();
					return false;
				}
			}
			if (chephamct.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Loại chế phẩm !"),LibMedi.AccessData.Msg);
				chephamct.Focus();
				return false;
			}
			return true;
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			if (!kiemtra()) return;
			mmyy=m.mmyy(ngayvv.Text);
            if (!m.bMmyy(mmyy)) m.tao_schema(mmyy, i_userid);
			xxx=user+mmyy;
			l_idthuchien=m.get_idthuchien(ngayvv.Text,l_idkhoa);
			if (l_idthuchien==0) 
			{
				l_idthuchien=m.get_capid(-300);
				m.upd_ba_thuchien(ngayvv.Text,l_idthuchien,mabn.Text,l_maql,l_idkhoa,s_makp,phong.Text,giuong.Text,chandoan.Text);
			}
			if (l_id==0) l_id=m.get_capid(-406);
			if (!upd_itemsd()) return;
            m.upd_ba_linhmau(ngayvv.Text, mabn.Text, l_id, l_idthuchien, sophieu.Text, ngay.Text, donvi.Text, chepham.Text, int.Parse(nhommau.SelectedValue.ToString()), lanthu.Value, nguoilinh.Text, mabs.Text, phongphat.Text, bvphat.Text, dvphat.Text, ngayphat.Text, nguoiphat.Text, truongkhoa.Text, i_userid);
			upd_items();
			m.execute_data("delete from "+xxx+".ba_linhmauct where id="+l_id);
			ds.AcceptChanges();
			foreach(DataRow r in ds.Tables[0].Rows)
				m.upd_ba_linhmauct(ngayvv.Text,l_id,int.Parse(r["stt"].ToString()),r["chepham"].ToString(),r["maso"].ToString(),int.Parse(r["nhommau"].ToString()));
			ena_object(false);
			butMoi.Focus();
		}

		private void upd_items()
		{
			DataRow r1,r2;
			r1=m.getrowbyid(dsh.Tables[0],"id="+l_id);
			if (r1==null)
			{
				r2=dsh.Tables[0].NewRow();
				r2["id"]=l_id;
				r2["idthuchien"]=l_idthuchien;
				r2["sophieu"]=sophieu.Text;
				r2["ngaylinh"]=ngay.Text;
				r2["donvi"]=donvi.Text;
				r2["chepham"]=chepham.Text;
				r2["nhommau"]=int.Parse(nhommau.SelectedValue.ToString());
				r2["lanthu"]=lanthu.Value;
				r2["nguoilinh"]=nguoilinh.Text;
				r2["bsdt"]=mabs.Text;
				r2["phongphat"]=phongphat.Text;
				r2["bvphat"]=bvphat.Text;
				r2["dvphat"]=dvphat.Text;
				r2["ngayphat"]=ngayphat.Text;
				r2["nguoiphat"]=nguoiphat.Text;
				r2["truongkhoa"]=truongkhoa.Text;
				dsh.Tables[0].Rows.Add(r2);
			}
			else
			{
				DataRow [] dr=dsh.Tables[0].Select("id="+l_id);
				dr[0]["idthuchien"]=l_idthuchien;
				dr[0]["sophieu"]=sophieu.Text;
				dr[0]["ngaylinh"]=ngay.Text;
				dr[0]["donvi"]=donvi.Text;
				dr[0]["chepham"]=chepham.Text;
				dr[0]["nhommau"]=int.Parse(nhommau.SelectedValue.ToString());
				dr[0]["lanthu"]=lanthu.Value;
				dr[0]["nguoilinh"]=nguoilinh.Text;
				dr[0]["bsdt"]=mabs.Text;
				dr[0]["phongphat"]=phongphat.Text;
				dr[0]["bvphat"]=bvphat.Text;
				dr[0]["dvphat"]=dvphat.Text;
				dr[0]["ngayphat"]=ngayphat.Text;
				dr[0]["nguoiphat"]=nguoiphat.Text;
				dr[0]["truongkhoa"]=truongkhoa.Text;
			}
		}

		private bool upd_itemsd()
		{
			if (chephamct.Text!="")
			{
				if (!kiemtrad()) return false;
				DataRow r1,r2;
				r1=m.getrowbyid(ds.Tables[0],"stt="+i_stt);
				if (r1==null)
				{
					r2=ds.Tables[0].NewRow();
					r2["stt"]=i_stt;
					r2["chepham"]=chephamct.Text;
					r2["maso"]=maso.Text;
					r2["nhommau"]=int.Parse(nhommauct.SelectedValue.ToString());
					r2["chon"]=false;
					ds.Tables[0].Rows.Add(r2);
				}
				else
				{
					DataRow [] dr=ds.Tables[0].Select("stt="+i_stt);
					dr[0]["chepham"]=chephamct.Text;
					dr[0]["maso"]=maso.Text;
					dr[0]["nhommau"]=int.Parse(nhommauct.SelectedValue.ToString());
				}
			}
			return true;
		}

        private void butIn_Click(object sender, System.EventArgs e)
        {
            string s_stt = "", stuoi = m.get_tuoivao(l_maql).Trim();
            foreach (DataRow r1 in ds.Tables[0].Select("chon=true")) s_stt += r1["stt"].ToString() + ",";
            sql = "select b.stt,'' as sovaovien,'' as mabn,'' as hoten,'' as tuoi,'' as phai,'' as tenkp,";
            sql += "'' as phong,'' as giuong,'' as chandoan,a.sophieu,to_char(a.ngaylinh,'dd/mm/yyyy') as ngaylinh,";
            sql += "a.donvi,a.chepham,h.ten nhomau,a.lanthu,e.hoten as nguoilinh,c.hoten as bsdt,";
            sql += "a.phongphat,a.bvphat,a.dvphat,";
            sql += "to_char(a.ngayphat,'dd/mm/yyyy') as ngayphat,f.hoten as nguoiphat,g.hoten as truongkhoa,";
            sql += "b.chepham as chephamct,b.maso,i.ten as nhommauct,";
            sql += "'' as i_bsdt,'' as i_nguoilinh,'' as i_nguoiphat,'' as i_truongkhoa ";//c.image,e.image,f.image,g.image
            sql += " from " + xxx + ".ba_linhmau a inner join " + xxx + ".ba_linhmauct b on a.id=b.id left join " + user + ".dmbs c on a.bsdt=c.ma";
            sql += " left join " + user + ".dmbs e on a.nguoilinh=e.ma left join " + user + ".dmbs f on a.nguoiphat=f.ma";
            sql += " left join " + user + ".dmbs g on a.truongkhoa=g.ma inner join " + user + ".dmnhommau h on a.nhommau=h.ma";
            sql += " inner join " + user + ".dmnhommau i on b.nhommau=i.ma";
            sql += " where a.id=" + l_id;
            if (s_stt != "") sql += " and a.stt in (" + s_stt.Substring(0, s_stt.Length - 1) + ")";
            DataSet dsxml = m.get_data(sql);
            if (chkXML.Checked)
            {
                if (!System.IO.Directory.Exists("..\\xml")) System.IO.Directory.CreateDirectory("..\\xml");
                dsxml.WriteXml("..\\xml\\linhmau.xml", XmlWriteMode.WriteSchema);
            }

            foreach (DataRow r in dsxml.Tables[0].Rows)
            {
                r["sovaovien"] = sovaovien.Text;
                r["mabn"] = mabn.Text;
                r["hoten"] = hoten.Text;
                r["tuoi"] = stuoi;
                r["phai"] = phai.Text;
                r["tenkp"] = s_tenkp;
                r["phong"] = phong.Text;
                r["giuong"] = giuong.Text;
                r["chandoan"] = chandoan.Text;
            }
            if (dsxml.Tables[0].Rows.Count > 0)
            {
                dllReportM.frmReport f = new dllReportM.frmReport(m, dsxml, "", "r15bv.rpt");
                f.ShowDialog();
            }
            else MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"), LibMedi.AccessData.Msg);
        }


		private void nguoilinh_Validated(object sender, System.EventArgs e)
		{
			if (nguoilinh.Text=="") return;
			DataRow r=m.getrowbyid(dtnv,"ma='"+nguoilinh.Text+"'");
			if (r!=null) tennguoilinh.Text=r["hoten"].ToString();
			else tennguoilinh.Text="";	
		}

		private void tennguoilinh_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tennguoilinh)
			{
				Filt_dmbs(tennguoilinh.Text);
				listNv.BrowseToDanhmuc(tennguoilinh,nguoilinh,mabs,35);
			}		
		}

		private void butThem_Click(object sender, System.EventArgs e)
		{
			if (!upd_itemsd()) return;
			emp_detail();
			chephamct.Focus();
		}

		private void butXoa_Click(object sender, System.EventArgs e)
		{
			m.delrec(ds.Tables[0],"stt="+i_stt);
			ref_text();			
		}

		private void cmbngay_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==cmbngay)
			{
				l_id=(cmbngay.SelectedIndex!=-1)?decimal.Parse(cmbngay.SelectedValue.ToString()):0;
				load_head();
				load_grid();
			}
		}

		private void load_head()
		{
			DataRow r=m.getrowbyid(dsh.Tables[0],"id="+l_id);
			if (r!=null)
			{
				ngay.Text=r["ngaylinh"].ToString();
				ngayphat.Text=r["ngayphat"].ToString();
				sophieu.Text=r["sophieu"].ToString();
				donvi.Text=r["donvi"].ToString();
				chepham.Text=r["chepham"].ToString();
				nhommau.SelectedValue=r["nhommau"].ToString();
				lanthu.Value=decimal.Parse(r["lanthu"].ToString());
				mabs.Text=r["bsdt"].ToString();
				DataRow r1=m.getrowbyid(dtnv,"ma='"+mabs.Text+"'");
				if (r1!=null) tenbs.Text=r1["hoten"].ToString();
				else tenbs.Text="";	
				
				nguoilinh.Text=r["nguoilinh"].ToString();
				r1=m.getrowbyid(dtnv,"ma='"+nguoilinh.Text+"'");
				if (r1!=null) tennguoilinh.Text=r1["hoten"].ToString();
				else tennguoilinh.Text="";	

				phongphat.Text=r["phongphat"].ToString();
				bvphat.Text=r["bvphat"].ToString();
				dvphat.Text=r["dvphat"].ToString();

				nguoiphat.Text=r["nguoiphat"].ToString();
				r1=m.getrowbyid(dtnv,"ma='"+nguoiphat.Text+"'");
				if (r1!=null) tennguoiphat.Text=r1["hoten"].ToString();
				else tennguoiphat.Text="";	

				truongkhoa.Text=r["truongkhoa"].ToString();
				r1=m.getrowbyid(dtnv,"ma='"+truongkhoa.Text+"'");
				if (r1!=null) tentruongkhoa.Text=r1["hoten"].ToString();
				else tentruongkhoa.Text="";	
			}
		}

		private void ngayphat_Validated(object sender, System.EventArgs e)
		{
			if (ngayphat.Text!="")
			{
				ngayphat.Text=ngayphat.Text.Trim();
				if (ngayphat.Text.Length==6) ngayphat.Text=ngayphat.Text+DateTime.Now.Year.ToString();
				if (!m.bNgay(ngayphat.Text))
				{
					MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"));
					ngayphat.Focus();
					return;
				}
			}
		}

		private void nguoiphat_Validated(object sender, System.EventArgs e)
		{
			if (nguoiphat.Text=="") return;
			DataRow r=m.getrowbyid(dtnv,"ma='"+nguoiphat.Text+"'");
			if (r!=null) tennguoiphat.Text=r["hoten"].ToString();
			else tennguoiphat.Text="";	
		}

		private void tennguoiphat_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tennguoiphat)
			{
				Filt_dmbs(nguoiphat.Text);
				listNv.BrowseToDanhmuc(tennguoiphat,nguoiphat,truongkhoa,35);
			}		
		}

		private void truongkhoa_Validated(object sender, System.EventArgs e)
		{
			if (truongkhoa.Text=="") return;
			DataRow r=m.getrowbyid(dtnv,"ma='"+truongkhoa.Text+"'");
			if (r!=null) tentruongkhoa.Text=r["hoten"].ToString();
			else tentruongkhoa.Text="";	
		}

		private void tentruongkhoa_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tentruongkhoa)
			{
				Filt_dmbs(truongkhoa.Text);
				listNv.BrowseToDanhmuc(tentruongkhoa,truongkhoa,butThem,35);
			}		
		}
	}
}
