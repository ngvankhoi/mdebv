using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Data;
using LibMedi;

namespace Medisoft
{
	/// <summary>
	/// Summary description for frmSoket.
	/// </summary>
	public class frmSoket : System.Windows.Forms.Form
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
		private System.Windows.Forms.Label label88;
		private System.Windows.Forms.Label label90;
		private System.Windows.Forms.TextBox tenbs;
		private MaskedTextBox.MaskedTextBox mabs;
		private System.Windows.Forms.Label label87;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox dienbien;
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
		private MaskedBox.MaskedBox gio;
		private MaskedBox.MaskedBox ngay;
		private System.ComponentModel.IContainer components;
		private DataSet ds=new DataSet();
		private DataTable dtnv=new DataTable(); 
		private LibMedi.AccessData m;
		private int i_userid;
		private string s_makp,user,xxx,s_ngayrv,sql,s_mabs,mmyy,s_userid,s_tenkp;
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
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.TextBox cls;
		private System.Windows.Forms.TextBox dieutri;
		private System.Windows.Forms.TextBox ketqua;
		private System.Windows.Forms.TextBox tienluong;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.TextBox tenbstruong;
		private MaskedTextBox.MaskedTextBox bstruong;
		private System.Windows.Forms.CheckBox chkXML;
		private System.Windows.Forms.TextBox tenbs_pass;

		public frmSoket(LibMedi.AccessData acc,string _mabn,decimal _maql,decimal _idkhoa,string _sovaovien,string _makp,string _hoten,string _namsinh,string _phai,string _diachi,string _ngayvv,string _sothe,string _phong,string _giuong,string _ngayrv,string _mabs,int _userid,string suserid,string _chandoan,string _tenkp,bool _admin)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			m=acc;mabn.Text=_mabn;l_maql=_maql;l_idkhoa=_idkhoa;sovaovien.Text=_sovaovien;i_userid=_userid;s_tenkp=_tenkp;
			hoten.Text=_hoten;chandoan.Text=_chandoan;s_makp=_makp;namsinh.Text=_namsinh;phai.Text=_phai;diachi.Text=_diachi;s_mabs=_mabs;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSoket));
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
            this.gio = new MaskedBox.MaskedBox();
            this.ngay = new MaskedBox.MaskedBox();
            this.label88 = new System.Windows.Forms.Label();
            this.label90 = new System.Windows.Forms.Label();
            this.tenbs = new System.Windows.Forms.TextBox();
            this.mabs = new MaskedTextBox.MaskedTextBox();
            this.label87 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dienbien = new System.Windows.Forms.TextBox();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.butMoi = new System.Windows.Forms.Button();
            this.butSua = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butHuy = new System.Windows.Forms.Button();
            this.butIn = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tenbs_pass = new System.Windows.Forms.TextBox();
            this.listNv = new LibList.List();
            this.label8 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.cls = new System.Windows.Forms.TextBox();
            this.dieutri = new System.Windows.Forms.TextBox();
            this.ketqua = new System.Windows.Forms.TextBox();
            this.tienluong = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.tenbstruong = new System.Windows.Forms.TextBox();
            this.bstruong = new MaskedTextBox.MaskedTextBox();
            this.chkXML = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // chandoan
            // 
            this.chandoan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.chandoan.Enabled = false;
            this.chandoan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chandoan.Location = new System.Drawing.Point(67, 92);
            this.chandoan.Name = "chandoan";
            this.chandoan.Size = new System.Drawing.Size(109, 21);
            this.chandoan.TabIndex = 71;
            // 
            // sothe
            // 
            this.sothe.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sothe.Enabled = false;
            this.sothe.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sothe.Location = new System.Drawing.Point(67, 92);
            this.sothe.Name = "sothe";
            this.sothe.Size = new System.Drawing.Size(109, 21);
            this.sothe.TabIndex = 63;
            // 
            // giuong
            // 
            this.giuong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.giuong.Enabled = false;
            this.giuong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.giuong.Location = new System.Drawing.Point(67, 92);
            this.giuong.Name = "giuong";
            this.giuong.Size = new System.Drawing.Size(109, 21);
            this.giuong.TabIndex = 70;
            // 
            // phong
            // 
            this.phong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.phong.Enabled = false;
            this.phong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phong.Location = new System.Drawing.Point(67, 92);
            this.phong.Name = "phong";
            this.phong.Size = new System.Drawing.Size(109, 21);
            this.phong.TabIndex = 69;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(67, 92);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(109, 16);
            this.label13.TabIndex = 68;
            this.label13.Text = "Chẩn đoán :";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(67, 92);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(109, 16);
            this.label12.TabIndex = 67;
            this.label12.Text = "Giường :";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(67, 92);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(109, 16);
            this.label11.TabIndex = 66;
            this.label11.Text = "Phòng :";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ngayvv
            // 
            this.ngayvv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngayvv.Enabled = false;
            this.ngayvv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngayvv.Location = new System.Drawing.Point(67, 92);
            this.ngayvv.Name = "ngayvv";
            this.ngayvv.Size = new System.Drawing.Size(109, 21);
            this.ngayvv.TabIndex = 65;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(67, 92);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 16);
            this.label7.TabIndex = 64;
            this.label7.Text = "Ngày :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(67, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 16);
            this.label6.TabIndex = 62;
            this.label6.Text = "Số thẻ :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // diachi
            // 
            this.diachi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.diachi.Enabled = false;
            this.diachi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diachi.Location = new System.Drawing.Point(67, 92);
            this.diachi.Name = "diachi";
            this.diachi.Size = new System.Drawing.Size(109, 21);
            this.diachi.TabIndex = 61;
            // 
            // phai
            // 
            this.phai.BackColor = System.Drawing.SystemColors.HighlightText;
            this.phai.Enabled = false;
            this.phai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phai.Location = new System.Drawing.Point(67, 92);
            this.phai.Name = "phai";
            this.phai.Size = new System.Drawing.Size(109, 21);
            this.phai.TabIndex = 60;
            // 
            // namsinh
            // 
            this.namsinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.namsinh.Enabled = false;
            this.namsinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namsinh.Location = new System.Drawing.Point(67, 92);
            this.namsinh.Name = "namsinh";
            this.namsinh.Size = new System.Drawing.Size(109, 21);
            this.namsinh.TabIndex = 59;
            // 
            // hoten
            // 
            this.hoten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.hoten.Enabled = false;
            this.hoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoten.Location = new System.Drawing.Point(67, 92);
            this.hoten.Name = "hoten";
            this.hoten.Size = new System.Drawing.Size(109, 21);
            this.hoten.TabIndex = 58;
            // 
            // mabn
            // 
            this.mabn.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabn.Enabled = false;
            this.mabn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabn.Location = new System.Drawing.Point(67, 92);
            this.mabn.Name = "mabn";
            this.mabn.Size = new System.Drawing.Size(109, 21);
            this.mabn.TabIndex = 52;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(67, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 16);
            this.label5.TabIndex = 57;
            this.label5.Text = "Địa chỉ :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(67, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 16);
            this.label4.TabIndex = 56;
            this.label4.Text = "Giới tính :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(67, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 16);
            this.label3.TabIndex = 55;
            this.label3.Text = "NS :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(67, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 16);
            this.label1.TabIndex = 54;
            this.label1.Text = "Họ tên :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(67, 92);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(109, 16);
            this.label10.TabIndex = 53;
            this.label10.Text = "Mã BN :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(67, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 16);
            this.label2.TabIndex = 72;
            this.label2.Text = "Số vào viện :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sovaovien
            // 
            this.sovaovien.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sovaovien.Enabled = false;
            this.sovaovien.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sovaovien.Location = new System.Drawing.Point(67, 92);
            this.sovaovien.Name = "sovaovien";
            this.sovaovien.Size = new System.Drawing.Size(109, 21);
            this.sovaovien.TabIndex = 73;
            // 
            // gio
            // 
            this.gio.BackColor = System.Drawing.SystemColors.HighlightText;
            this.gio.Enabled = false;
            this.gio.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gio.Location = new System.Drawing.Point(136, 466);
            this.gio.Mask = "##:##";
            this.gio.Name = "gio";
            this.gio.Size = new System.Drawing.Size(40, 21);
            this.gio.TabIndex = 6;
            this.gio.Text = "  :  ";
            this.gio.Validated += new System.EventHandler(this.gio_Validated);
            // 
            // ngay
            // 
            this.ngay.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngay.Enabled = false;
            this.ngay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngay.Location = new System.Drawing.Point(40, 466);
            this.ngay.Mask = "##/##/####";
            this.ngay.Name = "ngay";
            this.ngay.Size = new System.Drawing.Size(72, 21);
            this.ngay.TabIndex = 5;
            this.ngay.Text = "  /  /    ";
            this.ngay.Validated += new System.EventHandler(this.ngay_Validated);
            // 
            // label88
            // 
            this.label88.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label88.Location = new System.Drawing.Point(112, 469);
            this.label88.Name = "label88";
            this.label88.Size = new System.Drawing.Size(32, 16);
            this.label88.TabIndex = 302;
            this.label88.Text = "Giờ :";
            this.label88.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label90
            // 
            this.label90.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label90.Location = new System.Drawing.Point(0, 469);
            this.label90.Name = "label90";
            this.label90.Size = new System.Drawing.Size(40, 16);
            this.label90.TabIndex = 301;
            this.label90.Text = "Ngày :";
            this.label90.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tenbs
            // 
            this.tenbs.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbs.Enabled = false;
            this.tenbs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbs.Location = new System.Drawing.Point(547, 464);
            this.tenbs.Name = "tenbs";
            this.tenbs.Size = new System.Drawing.Size(198, 21);
            this.tenbs.TabIndex = 10;
            this.tenbs.TextChanged += new System.EventHandler(this.tenbs_TextChanged);
            this.tenbs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbs_KeyDown);
            // 
            // mabs
            // 
            this.mabs.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mabs.Enabled = false;
            this.mabs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabs.Location = new System.Drawing.Point(507, 464);
            this.mabs.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.mabs.MaxLength = 9;
            this.mabs.Name = "mabs";
            this.mabs.Size = new System.Drawing.Size(41, 21);
            this.mabs.TabIndex = 9;
            this.mabs.Validated += new System.EventHandler(this.mabs_Validated);
            this.mabs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // label87
            // 
            this.label87.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label87.Location = new System.Drawing.Point(468, 469);
            this.label87.Name = "label87";
            this.label87.Size = new System.Drawing.Size(88, 16);
            this.label87.TabIndex = 300;
            this.label87.Text = "Bác sĩ :";
            this.label87.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label9.Location = new System.Drawing.Point(287, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(248, 16);
            this.label9.TabIndex = 304;
            this.label9.Text = "1. Diễn biến lâm sàng trong đợt điều trị :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dienbien
            // 
            this.dienbien.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dienbien.Enabled = false;
            this.dienbien.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dienbien.Location = new System.Drawing.Point(290, 28);
            this.dienbien.Multiline = true;
            this.dienbien.Name = "dienbien";
            this.dienbien.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.dienbien.Size = new System.Drawing.Size(519, 119);
            this.dienbien.TabIndex = 0;
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
            this.dataGrid1.Location = new System.Drawing.Point(6, -11);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(280, 467);
            this.dataGrid1.TabIndex = 310;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            this.dataGrid1.Click += new System.EventHandler(this.dataGrid1_Click);
            // 
            // butMoi
            // 
            this.butMoi.Location = new System.Drawing.Point(174, 496);
            this.butMoi.Name = "butMoi";
            this.butMoi.Size = new System.Drawing.Size(70, 25);
            this.butMoi.TabIndex = 14;
            this.butMoi.Text = "&Mới";
            this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
            // 
            // butSua
            // 
            this.butSua.Location = new System.Drawing.Point(244, 496);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(70, 25);
            this.butSua.TabIndex = 15;
            this.butSua.Text = "&Sữa";
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butLuu
            // 
            this.butLuu.Enabled = false;
            this.butLuu.Location = new System.Drawing.Point(314, 496);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 12;
            this.butLuu.Text = "&Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Enabled = false;
            this.butBoqua.Location = new System.Drawing.Point(384, 496);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(70, 25);
            this.butBoqua.TabIndex = 13;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butHuy
            // 
            this.butHuy.Location = new System.Drawing.Point(454, 496);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(70, 25);
            this.butHuy.TabIndex = 16;
            this.butHuy.Text = "&Hủy";
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // butIn
            // 
            this.butIn.Location = new System.Drawing.Point(524, 496);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 17;
            this.butIn.Text = "&In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Location = new System.Drawing.Point(594, 496);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 18;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // tenbs_pass
            // 
            this.tenbs_pass.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbs_pass.Enabled = false;
            this.tenbs_pass.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbs_pass.Location = new System.Drawing.Point(745, 464);
            this.tenbs_pass.Name = "tenbs_pass";
            this.tenbs_pass.PasswordChar = '*';
            this.tenbs_pass.Size = new System.Drawing.Size(64, 21);
            this.tenbs_pass.TabIndex = 11;
            this.toolTip1.SetToolTip(this.tenbs_pass, "Mật khẩu bác sĩ điều trị");
            this.tenbs_pass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // listNv
            // 
            this.listNv.BackColor = System.Drawing.SystemColors.Info;
            this.listNv.ColumnCount = 0;
            this.listNv.Location = new System.Drawing.Point(664, 528);
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
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label8.Location = new System.Drawing.Point(290, 152);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(232, 16);
            this.label8.TabIndex = 312;
            this.label8.Text = "2. Xét nghiệm cận lâm sàng :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label14.Location = new System.Drawing.Point(290, 230);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(232, 16);
            this.label14.TabIndex = 313;
            this.label14.Text = "3. Quá trình điều trị :";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label15.Location = new System.Drawing.Point(290, 308);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(232, 16);
            this.label15.TabIndex = 314;
            this.label15.Text = "4. Đánh giá kết quả :";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label16.Location = new System.Drawing.Point(290, 387);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(232, 16);
            this.label16.TabIndex = 315;
            this.label16.Text = "5. Hướng điều trị tiếp và tiên lượng :";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cls
            // 
            this.cls.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cls.Enabled = false;
            this.cls.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cls.Location = new System.Drawing.Point(290, 171);
            this.cls.Multiline = true;
            this.cls.Name = "cls";
            this.cls.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.cls.Size = new System.Drawing.Size(519, 55);
            this.cls.TabIndex = 1;
            // 
            // dieutri
            // 
            this.dieutri.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dieutri.Enabled = false;
            this.dieutri.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dieutri.Location = new System.Drawing.Point(290, 248);
            this.dieutri.Multiline = true;
            this.dieutri.Name = "dieutri";
            this.dieutri.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.dieutri.Size = new System.Drawing.Size(519, 55);
            this.dieutri.TabIndex = 2;
            // 
            // ketqua
            // 
            this.ketqua.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ketqua.Enabled = false;
            this.ketqua.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ketqua.Location = new System.Drawing.Point(290, 328);
            this.ketqua.Multiline = true;
            this.ketqua.Name = "ketqua";
            this.ketqua.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ketqua.Size = new System.Drawing.Size(519, 55);
            this.ketqua.TabIndex = 3;
            // 
            // tienluong
            // 
            this.tienluong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tienluong.Enabled = false;
            this.tienluong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tienluong.Location = new System.Drawing.Point(290, 407);
            this.tienluong.Multiline = true;
            this.tienluong.Name = "tienluong";
            this.tienluong.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tienluong.Size = new System.Drawing.Size(519, 55);
            this.tienluong.TabIndex = 4;
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(176, 469);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(88, 16);
            this.label17.TabIndex = 320;
            this.label17.Text = "Trưởng khoa :";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tenbstruong
            // 
            this.tenbstruong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbstruong.Enabled = false;
            this.tenbstruong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbstruong.Location = new System.Drawing.Point(290, 464);
            this.tenbstruong.Name = "tenbstruong";
            this.tenbstruong.Size = new System.Drawing.Size(173, 21);
            this.tenbstruong.TabIndex = 8;
            this.tenbstruong.TextChanged += new System.EventHandler(this.tenbstruong_TextChanged);
            this.tenbstruong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbs_KeyDown);
            // 
            // bstruong
            // 
            this.bstruong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.bstruong.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.bstruong.Enabled = false;
            this.bstruong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bstruong.Location = new System.Drawing.Point(248, 464);
            this.bstruong.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.bstruong.MaxLength = 9;
            this.bstruong.Name = "bstruong";
            this.bstruong.Size = new System.Drawing.Size(41, 21);
            this.bstruong.TabIndex = 7;
            this.bstruong.Validated += new System.EventHandler(this.bstruong_Validated);
            this.bstruong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // chkXML
            // 
            this.chkXML.Location = new System.Drawing.Point(8, 496);
            this.chkXML.Name = "chkXML";
            this.chkXML.Size = new System.Drawing.Size(104, 16);
            this.chkXML.TabIndex = 321;
            this.chkXML.Text = "Xuất ra XML";
            // 
            // frmSoket
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(829, 579);
            this.Controls.Add(this.chkXML);
            this.Controls.Add(this.tenbstruong);
            this.Controls.Add(this.bstruong);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.tienluong);
            this.Controls.Add(this.ketqua);
            this.Controls.Add(this.dieutri);
            this.Controls.Add(this.cls);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tenbs_pass);
            this.Controls.Add(this.listNv);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.butHuy);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butSua);
            this.Controls.Add(this.butMoi);
            this.Controls.Add(this.dienbien);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.gio);
            this.Controls.Add(this.ngay);
            this.Controls.Add(this.label88);
            this.Controls.Add(this.label90);
            this.Controls.Add(this.tenbs);
            this.Controls.Add(this.mabs);
            this.Controls.Add(this.label87);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.ngayvv);
            this.Controls.Add(this.sovaovien);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chandoan);
            this.Controls.Add(this.sothe);
            this.Controls.Add(this.giuong);
            this.Controls.Add(this.phong);
            this.Controls.Add(this.label13);
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
            this.Name = "frmSoket";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phiếu sơ kết 15 ngày điều trị";
            this.Load += new System.EventHandler(this.frmSoket_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmSoket_Load(object sender, System.EventArgs e)
        {
            this.Location = new System.Drawing.Point(188, 151);
			user=m.user;xxx=user+m.mmyy(ngayvv.Text);
            dtnv = m.get_data("select * from " + user + ".dmbs where nhom<>" + LibMedi.AccessData.nghiviec + " order by hoten").Tables[0];
			listNv.DisplayMember="MA";
			listNv.ValueMember="HOTEN";
			listNv.DataSource=dtnv;
			load_grid();
			AddGridTableStyle();
			this.disabledBackBrush = new SolidBrush(Color.Black);
			this.disabledTextBrush = new SolidBrush(Color.Red);

			this.alertBackBrush = new SolidBrush(SystemColors.HotTrack);
			this.alertFont = new Font(this.dataGrid1.Font.Name, this.dataGrid1.Font.Size, FontStyle.Bold);
			this.alertTextBrush = new SolidBrush(Color.White);
			
			this.currentRowFont = new Font(this.dataGrid1.Font.Name, this.dataGrid1.Font.Size, FontStyle.Regular);
			this.currentRowBackBrush = new SolidBrush(Color.FromArgb(0,255, 255));

			ref_text();
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

		private void gio_Validated(object sender, System.EventArgs e)
		{
			string sgio=(gio.Text.Trim()=="")?"00:00":gio.Text.Trim();
			gio.Text=sgio.Substring(0,2).PadLeft(2,'0')+":"+sgio.Substring(3).Trim().PadRight(2,'0');
			if (!m.bGio(gio.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Giờ không hợp lệ !"));
				gio.Focus();
				return;
			}
		}

		private void mabs_Validated(object sender, System.EventArgs e)
		{
			if (mabs.Text=="") return;
			DataRow r=m.getrowbyid(dtnv,"ma='"+mabs.Text+"'");
			if (r!=null)
			{
				tenbs.Text=r["hoten"].ToString();
				if (bAdmin) tenbs_pass.Text=r["password_"].ToString();
			}
			else tenbs.Text="";	
		}

		private void tenbs_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tenbs)
			{
				Filt_dmbs(tenbs.Text);
				listNv.BrowseToDanhmuc(tenbs,mabs,tenbs_pass,35);
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
			sql="select a.id,a.idthuchien,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay,a.dienbien,a.cls,a.dieutri,a.ketqua,a.tienluong,";
			sql+="a.mabs,c.hoten as tenbs,c.password_,a.bstruong,d.hoten as tenbstruong from "+xxx+".ba_soket a,"+xxx+".ba_thuchien b,"+user+".dmbs c,"+user+".dmbs d ";
			sql+=" where a.idthuchien=b.id and a.mabs=c.ma and a.bstruong=d.ma and b.idkhoa="+l_idkhoa;
			sql+=" order by a.id";
			ds=m.get_data(sql);
			ds.Tables[0].Columns.Add("Chon",typeof(bool));
			dataGrid1.DataSource=ds.Tables[0];
			CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource,dataGrid1.DataMember]; 
			DataView dv = (DataView) cm.List; 
			dv.AllowNew = false; 
			foreach (DataRow row in ds.Tables[0].Rows) row["chon"]=false;
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
			discontinuedCol.HeaderText = "In";
			discontinuedCol.Width = 20;
			discontinuedCol.AllowNull = false;

			discontinuedCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			discontinuedCol.BoolValueChanged += new BoolValueChangedEventHandler(BoolValueChanged);
			ts.GridColumnStyles.Add(discontinuedCol);
			dataGrid1.TableStyles.Add(ts);

			FormattableTextBoxColumn TextCol1 = new FormattableTextBoxColumn();
			TextCol1.MappingName = "id";
			TextCol1.HeaderText = "";
			TextCol1.Width = 0;
			TextCol1.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new FormattableTextBoxColumn();
			TextCol1.MappingName = "ngay";
			TextCol1.HeaderText = "Ngày";
			TextCol1.Width =100;
			TextCol1.ReadOnly=true;
			TextCol1.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new FormattableTextBoxColumn();
			TextCol1.MappingName = "tenbs";
			TextCol1.HeaderText = "Bác sĩ";
			TextCol1.Width = 180;
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
				l_id=decimal.Parse(dataGrid1[i_row,1].ToString());
				load_items(l_id);
			}
			catch{}
		}

		private void load_items(decimal id)
		{
			DataRow r=m.getrowbyid(ds.Tables[0],"id="+id);
			if (r!=null)
			{
				ngay.Text=r["ngay"].ToString().Substring(0,10);
				gio.Text=r["ngay"].ToString().Substring(11);
				dienbien.Text=r["dienbien"].ToString();
				cls.Text=r["cls"].ToString();
				dieutri.Text=r["dieutri"].ToString();
				ketqua.Text=r["ketqua"].ToString();
				tienluong.Text=r["tienluong"].ToString();
				mabs.Text=r["mabs"].ToString();
				bstruong.Text=r["bstruong"].ToString();
				tenbstruong.Text=r["tenbstruong"].ToString();
				DataRow r1=m.getrowbyid(dtnv,"ma='"+mabs.Text+"'");
				if (r1!=null)
				{
					tenbs.Text=r1["hoten"].ToString();
					tenbs_pass.Text=r1["password_"].ToString();
				}
				else
				{
					tenbs.Text="";	
					tenbs_pass.Text="";
				}
			}
		}
		private void emp_text()
		{
			l_id=0;
			string _ngay=m.ngayhienhanh_server;
			ngay.Text=_ngay.Substring(0,10);
			gio.Text=_ngay.Substring(11);
			dienbien.Text="";cls.Text="";dieutri.Text="";ketqua.Text="";tienluong.Text="";
			mabs.Text="";tenbs.Text="";tenbs_pass.Text="";bstruong.Text="";tenbstruong.Text="";
			DataRow r1=m.getrowbyid(dtnv,"makp='"+s_makp+"' and nhom="+LibMedi.AccessData.truongkhoa);
			if (r1!=null)
			{
				bstruong.Text=r1["ma"].ToString();tenbstruong.Text=r1["hoten"].ToString();
			}
			if (s_mabs!="")
			{
				mabs.Text=s_mabs;
				r1=m.getrowbyid(dtnv,"ma='"+mabs.Text+"'");
				if (r1!=null) 
				{
					tenbs.Text=r1["hoten"].ToString();
					tenbs_pass.Text=r1["password_"].ToString();
				}
				else
				{
					tenbs.Text="";tenbs_pass.Text="";
				}
				if (mabs.Text!="" && tenbs.Text!="" && !bAdmin)
				{
					mabs.Enabled=false;tenbs.Enabled=false;
				}
			}

		}

		private void ena_object(bool ena)
		{
			ngay.Enabled=ena;
			gio.Enabled=ena;
			dienbien.Enabled=ena;
			cls.Enabled=ena;
			dieutri.Enabled=ena;
			ketqua.Enabled=ena;
			tienluong.Enabled=ena;
			mabs.Enabled=ena;
			tenbs.Enabled=ena;
			tenbs_pass.Enabled=ena;
			bstruong.Enabled=ena;
			tenbstruong.Enabled=ena;
			butLuu.Enabled=ena;
			butBoqua.Enabled=ena;
			butMoi.Enabled=!ena;
			butSua.Enabled=!ena;
			butIn.Enabled=!ena;
			butHuy.Enabled=!ena;
			butKetthuc.Enabled=!ena;
			dataGrid1.Enabled=!ena;
		}

		private void butMoi_Click(object sender, System.EventArgs e)
		{
			ena_object(true);
			emp_text();
			dienbien.Focus();
		}

		private void butSua_Click(object sender, System.EventArgs e)
		{
			if (ds.Tables[0].Rows.Count==0) return;
			ena_object(true);
			dienbien.Focus();
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void butHuy_Click(object sender, System.EventArgs e)
		{
			if (ds.Tables[0].Rows.Count==0) return;
			if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý hủy thông tin này ?"),LibMedi.AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
			{
				m.execute_data("delete from "+xxx+".ba_soket where id="+l_id);
				m.delrec(ds.Tables[0],"id="+l_id);
				ref_text();
			}
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			ena_object(false);
			if (l_id!=0) load_items(l_id);
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
			if (gio.Text.Trim().Length!=5)
			{
				MessageBox.Show(lan.Change_language_MessageText("Giờ không hợp lệ !"),LibMedi.AccessData.Msg);
				gio.Focus();
				return false;
			}
			if (bstruong.Text=="" || tenbstruong.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập bác sĩ trưởng khoa !"),LibMedi.AccessData.Msg);
				if (bstruong.Text=="") bstruong.Focus();
				else tenbstruong.Focus();
				return false;
			}
			if (mabs.Text=="" || tenbs.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập bác sĩ điều trị !"),LibMedi.AccessData.Msg);
				if (mabs.Text=="") mabs.Focus();
				else tenbs.Focus();
				return false;
			}
			if (mabs.Text!="" && tenbs.Text!="")
			{
				DataRow r=m.getrowbyid(dtnv,"ma='"+mabs.Text+"'");
				if (r==null)
				{
					MessageBox.Show(lan.Change_language_MessageText("Bác sĩ điều trị chưa hợp lệ !"),LibMedi.AccessData.Msg);
					mabs.Focus();
					return false;
				}
				if (!bAdmin)
				{
					if (tenbs_pass.Text!=r["password_"].ToString())
					{
						MessageBox.Show(lan.Change_language_MessageText("Mật khẩu bác sĩ điều trị chưa hợp lệ !"),LibMedi.AccessData.Msg);
						tenbs_pass.Focus();
						return false;
					}
				}
			}
			return true;
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			if (!kiemtra()) return;
			l_idthuchien=m.get_idthuchien(ngayvv.Text,l_idkhoa);
			if (l_idthuchien==0) 
			{
				l_idthuchien=m.get_capid(-300);
				m.upd_ba_thuchien(ngayvv.Text,l_idthuchien,mabn.Text,l_maql,l_idkhoa,s_makp,phong.Text,giuong.Text,chandoan.Text);
			}
			if (l_id==0) l_id=m.get_capid(-307);
            m.upd_ba_soket(ngayvv.Text, mabn.Text, l_id, l_idthuchien, ngay.Text + " " + gio.Text, dienbien.Text, cls.Text, dieutri.Text, ketqua.Text, tienluong.Text, bstruong.Text, mabs.Text, i_userid);
			upd_items();
			ena_object(false);
			butMoi.Focus();
		}

		private void upd_items()
		{
			DataRow r1,r2;
			r1=m.getrowbyid(ds.Tables[0],"id="+l_id);
			if (r1==null)
			{
				r2=ds.Tables[0].NewRow();
				r2["id"]=l_id;
				r2["idthuchien"]=l_idthuchien;
				r2["ngay"]=ngay.Text+" "+gio.Text;
				r2["dienbien"]=dienbien.Text;
				r2["cls"]=cls.Text;
				r2["dieutri"]=dieutri.Text;
				r2["ketqua"]=ketqua.Text;
				r2["tienluong"]=tienluong.Text;
				r2["mabs"]=mabs.Text;
				r2["tenbs"]=tenbs.Text;
				r2["password_"]=tenbs_pass.Text;
				r2["bstruong"]=bstruong.Text;
				r2["tenbstruong"]=tenbstruong.Text;
				r2["chon"]=true;
				ds.Tables[0].Rows.Add(r2);
			}
			else
			{
				DataRow [] dr=ds.Tables[0].Select("id="+l_id);
				dr[0]["idthuchien"]=l_idthuchien;
				dr[0]["ngay"]=ngay.Text+" "+gio.Text;
				dr[0]["dienbien"]=dienbien.Text;
				dr[0]["cls"]=cls.Text;
				dr[0]["dieutri"]=dieutri.Text;
				dr[0]["ketqua"]=ketqua.Text;
				dr[0]["tienluong"]=tienluong.Text;
				dr[0]["mabs"]=mabs.Text;
				dr[0]["tenbs"]=tenbs.Text;
				dr[0]["password_"]=tenbs_pass.Text;
				dr[0]["bstruong"]=bstruong.Text;
				dr[0]["tenbstruong"]=tenbstruong.Text;
			}
		}		

		private void butIn_Click(object sender, System.EventArgs e)
		{
			string s_id="",stuoi=m.get_tuoivao(l_maql).Trim();
			foreach(DataRow r1 in ds.Tables[0].Select("chon=true")) s_id+=r1["id"].ToString()+",";
			sql="select '' as sovaovien,'' as mabn,'' as hoten,'' as tuoi,'' as phai,'' as tenkp,";
			sql+="'' as phong,'' as giuong,'' as chandoan,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay,";
            sql += "a.dienbien,a.cls,a.dieutri,a.ketqua,a.tienluong,a.mabs,c.hoten as tenbs,'' as image,";//c.image
            sql += "a.bstruong,e.hoten as tenbstruong,'' as ibstruong ";//e.image
			sql+=" from "+xxx+".ba_soket a,"+user+".dmbs e,"+user+".dmbs c,"+xxx+".ba_thuchien d";
			sql+=" where a.idthuchien=d.id and a.bstruong=e.ma and a.mabs=c.ma and d.idkhoa="+l_idkhoa;
			if (s_id!="") sql+=" and a.id in ("+s_id.Substring(0,s_id.Length-1)+")";
			sql+=" order by a.ngay";
			DataSet dsxml=m.get_data(sql);
			if (chkXML.Checked)
			{
				if (!System.IO.Directory.Exists("..\\xml")) System.IO.Directory.CreateDirectory("..\\xml");
				dsxml.WriteXml("..\\xml\\soket.xml",XmlWriteMode.WriteSchema);
			}
			foreach(DataRow r in dsxml.Tables[0].Rows)
			{
				r["sovaovien"]=sovaovien.Text;
				r["mabn"]=mabn.Text;
				r["hoten"]=hoten.Text;
				r["tuoi"]=stuoi;
				r["phai"]=phai.Text;
				r["tenkp"]=s_tenkp;
				r["phong"]=phong.Text;
				r["giuong"]=giuong.Text;
				r["chandoan"]=chandoan.Text;
			}
			if (dsxml.Tables[0].Rows.Count>0)
			{
				dllReportM.frmReport f=new dllReportM.frmReport(m,dsxml,"","r18bv.rpt");
				f.ShowDialog();
			}
			else MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),LibMedi.AccessData.Msg);
		}

		private void bstruong_Validated(object sender, System.EventArgs e)
		{
			if (bstruong.Text=="") return;
			DataRow r=m.getrowbyid(dtnv,"ma='"+bstruong.Text+"'");
			if (r!=null) tenbstruong.Text=r["hoten"].ToString();
			else tenbstruong.Text="";	
		}

		private void tenbstruong_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tenbstruong)
			{
				Filt_dmbs(tenbstruong.Text);
				listNv.BrowseToDanhmuc(tenbstruong,bstruong,mabs,35);
			}		
		}
	}
}
