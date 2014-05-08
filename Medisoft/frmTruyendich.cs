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
	public class frmTruyendich : System.Windows.Forms.Form
	{
        private Language lan = new Language();
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
		private MaskedBox.MaskedBox gio;
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
		private System.Windows.Forms.TextBox ten;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.TextBox soluong;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.TextBox losx;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.TextBox tocdo;
		private System.Windows.Forms.Label lgio;
		private System.Windows.Forms.TextBox ghichu;
		private System.Windows.Forms.TextBox tenyta;
		private MaskedTextBox.MaskedTextBox yta;
		private MaskedBox.MaskedBox gio_bd;
		private MaskedBox.MaskedBox ngay_bd;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label21;
		private MaskedBox.MaskedBox gio_kt;
		private MaskedBox.MaskedBox ngay_kt;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.ComboBox cmbngay;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Button butXoa;
		private System.Windows.Forms.Button butThem;
		private System.Windows.Forms.CheckBox chkXML;

		public frmTruyendich(LibMedi.AccessData acc,string _mabn,decimal _maql,decimal _idkhoa,string _sovaovien,string _makp,string _hoten,string _namsinh,string _phai,string _diachi,string _ngayvv,string _sothe,string _phong,string _giuong,string _ngayrv,string _mabs,int _userid,string _nhomkho,string suserid,string _chandoan,string _tenkp,bool _admin)
		{
			InitializeComponent();
			m=acc;mabn.Text=_mabn;l_maql=_maql;l_idkhoa=_idkhoa;sovaovien.Text=_sovaovien;i_userid=_userid;s_tenkp=_tenkp;
			hoten.Text=_hoten;chandoan.Text=_chandoan;s_makp=_makp;namsinh.Text=_namsinh;phai.Text=_phai;diachi.Text=_diachi;s_mabs=_mabs;s_nhomkho=_nhomkho;
			ngayvv.Text=_ngayvv;sothe.Text=_sothe;phong.Text=_phong;giuong.Text=_giuong;s_ngayrv=_ngayrv;s_userid=suserid;bAdmin=_admin;
		}

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTruyendich));
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
            this.lgio = new System.Windows.Forms.Label();
            this.tenbs = new System.Windows.Forms.TextBox();
            this.mabs = new MaskedTextBox.MaskedTextBox();
            this.label87 = new System.Windows.Forms.Label();
            this.ten = new System.Windows.Forms.TextBox();
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
            this.ghichu = new System.Windows.Forms.TextBox();
            this.chkXML = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tenyta = new System.Windows.Forms.TextBox();
            this.yta = new MaskedTextBox.MaskedTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.soluong = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.losx = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.tocdo = new System.Windows.Forms.TextBox();
            this.gio_bd = new MaskedBox.MaskedBox();
            this.ngay_bd = new MaskedBox.MaskedBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.gio_kt = new MaskedBox.MaskedBox();
            this.ngay_kt = new MaskedBox.MaskedBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.cmbngay = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.butXoa = new System.Windows.Forms.Button();
            this.butThem = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // chandoan
            // 
            this.chandoan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.chandoan.Enabled = false;
            this.chandoan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chandoan.Location = new System.Drawing.Point(66, 85);
            this.chandoan.Name = "chandoan";
            this.chandoan.Size = new System.Drawing.Size(461, 21);
            this.chandoan.TabIndex = 71;
            // 
            // sothe
            // 
            this.sothe.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sothe.Enabled = false;
            this.sothe.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sothe.Location = new System.Drawing.Point(66, 85);
            this.sothe.Name = "sothe";
            this.sothe.Size = new System.Drawing.Size(164, 21);
            this.sothe.TabIndex = 63;
            // 
            // giuong
            // 
            this.giuong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.giuong.Enabled = false;
            this.giuong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.giuong.Location = new System.Drawing.Point(66, 85);
            this.giuong.Name = "giuong";
            this.giuong.Size = new System.Drawing.Size(72, 21);
            this.giuong.TabIndex = 70;
            // 
            // phong
            // 
            this.phong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.phong.Enabled = false;
            this.phong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phong.Location = new System.Drawing.Point(66, 85);
            this.phong.Name = "phong";
            this.phong.Size = new System.Drawing.Size(80, 21);
            this.phong.TabIndex = 69;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(66, 85);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(73, 16);
            this.label13.TabIndex = 68;
            this.label13.Text = "Chẩn đoán :";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(66, 85);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(48, 16);
            this.label12.TabIndex = 67;
            this.label12.Text = "Giường :";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(66, 85);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 16);
            this.label11.TabIndex = 66;
            this.label11.Text = "Phòng :";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ngayvv
            // 
            this.ngayvv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngayvv.Enabled = false;
            this.ngayvv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngayvv.Location = new System.Drawing.Point(66, 85);
            this.ngayvv.Name = "ngayvv";
            this.ngayvv.Size = new System.Drawing.Size(109, 21);
            this.ngayvv.TabIndex = 65;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(66, 85);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 16);
            this.label7.TabIndex = 64;
            this.label7.Text = "Ngày :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(66, 85);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 16);
            this.label6.TabIndex = 62;
            this.label6.Text = "Số thẻ :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // diachi
            // 
            this.diachi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.diachi.Enabled = false;
            this.diachi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diachi.Location = new System.Drawing.Point(66, 85);
            this.diachi.Name = "diachi";
            this.diachi.Size = new System.Drawing.Size(245, 21);
            this.diachi.TabIndex = 61;
            // 
            // phai
            // 
            this.phai.BackColor = System.Drawing.SystemColors.HighlightText;
            this.phai.Enabled = false;
            this.phai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phai.Location = new System.Drawing.Point(66, 85);
            this.phai.Name = "phai";
            this.phai.Size = new System.Drawing.Size(32, 21);
            this.phai.TabIndex = 60;
            // 
            // namsinh
            // 
            this.namsinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.namsinh.Enabled = false;
            this.namsinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namsinh.Location = new System.Drawing.Point(66, 85);
            this.namsinh.Name = "namsinh";
            this.namsinh.Size = new System.Drawing.Size(32, 21);
            this.namsinh.TabIndex = 59;
            // 
            // hoten
            // 
            this.hoten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.hoten.Enabled = false;
            this.hoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoten.Location = new System.Drawing.Point(66, 85);
            this.hoten.Name = "hoten";
            this.hoten.Size = new System.Drawing.Size(160, 21);
            this.hoten.TabIndex = 58;
            // 
            // mabn
            // 
            this.mabn.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabn.Enabled = false;
            this.mabn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabn.Location = new System.Drawing.Point(66, 85);
            this.mabn.Name = "mabn";
            this.mabn.Size = new System.Drawing.Size(56, 21);
            this.mabn.TabIndex = 52;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(66, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 16);
            this.label5.TabIndex = 57;
            this.label5.Text = "Địa chỉ :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(66, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 16);
            this.label4.TabIndex = 56;
            this.label4.Text = "Giới tính :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(66, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 16);
            this.label3.TabIndex = 55;
            this.label3.Text = "NS :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(66, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 16);
            this.label1.TabIndex = 54;
            this.label1.Text = "Họ tên :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(66, 85);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 16);
            this.label10.TabIndex = 53;
            this.label10.Text = "Mã BN :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(66, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 72;
            this.label2.Text = "Số vào viện :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sovaovien
            // 
            this.sovaovien.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sovaovien.Enabled = false;
            this.sovaovien.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sovaovien.Location = new System.Drawing.Point(66, 85);
            this.sovaovien.Name = "sovaovien";
            this.sovaovien.Size = new System.Drawing.Size(64, 21);
            this.sovaovien.TabIndex = 73;
            // 
            // gio
            // 
            this.gio.BackColor = System.Drawing.SystemColors.HighlightText;
            this.gio.Enabled = false;
            this.gio.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gio.Location = new System.Drawing.Point(198, 3);
            this.gio.Mask = "##:##";
            this.gio.Name = "gio";
            this.gio.Size = new System.Drawing.Size(40, 21);
            this.gio.TabIndex = 2;
            this.gio.Text = "  :  ";
            this.gio.Visible = false;
            this.gio.Validated += new System.EventHandler(this.gio_Validated);
            // 
            // ngay
            // 
            this.ngay.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngay.Enabled = false;
            this.ngay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngay.Location = new System.Drawing.Point(38, 3);
            this.ngay.Mask = "##/##/####";
            this.ngay.Name = "ngay";
            this.ngay.Size = new System.Drawing.Size(72, 21);
            this.ngay.TabIndex = 1;
            this.ngay.Text = "  /  /    ";
            this.ngay.Visible = false;
            this.ngay.Validated += new System.EventHandler(this.ngay_Validated);
            // 
            // lgio
            // 
            this.lgio.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lgio.Location = new System.Drawing.Point(166, 6);
            this.lgio.Name = "lgio";
            this.lgio.Size = new System.Drawing.Size(32, 16);
            this.lgio.TabIndex = 302;
            this.lgio.Text = "Giờ :";
            this.lgio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lgio.Visible = false;
            // 
            // tenbs
            // 
            this.tenbs.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbs.Enabled = false;
            this.tenbs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbs.Location = new System.Drawing.Point(523, 431);
            this.tenbs.Name = "tenbs";
            this.tenbs.Size = new System.Drawing.Size(294, 21);
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
            this.mabs.Location = new System.Drawing.Point(480, 431);
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
            this.label87.Location = new System.Drawing.Point(376, 432);
            this.label87.Name = "label87";
            this.label87.Size = new System.Drawing.Size(104, 16);
            this.label87.TabIndex = 300;
            this.label87.Text = "Bác sĩ chỉ định :";
            this.label87.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ten
            // 
            this.ten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ten.Enabled = false;
            this.ten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ten.Location = new System.Drawing.Point(152, 384);
            this.ten.Name = "ten";
            this.ten.Size = new System.Drawing.Size(665, 21);
            this.ten.TabIndex = 3;
            this.ten.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
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
            this.dataGrid1.Location = new System.Drawing.Point(6, 8);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(811, 370);
            this.dataGrid1.TabIndex = 310;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            this.dataGrid1.Navigate += new System.Windows.Forms.NavigateEventHandler(this.dataGrid1_Navigate);
            this.dataGrid1.Click += new System.EventHandler(this.dataGrid1_Click);
            // 
            // butMoi
            // 
            this.butMoi.Location = new System.Drawing.Point(118, 496);
            this.butMoi.Name = "butMoi";
            this.butMoi.Size = new System.Drawing.Size(70, 25);
            this.butMoi.TabIndex = 20;
            this.butMoi.Text = "&Mới";
            this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
            // 
            // butSua
            // 
            this.butSua.Location = new System.Drawing.Point(188, 496);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(70, 25);
            this.butSua.TabIndex = 21;
            this.butSua.Text = "&Sửa";
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butLuu
            // 
            this.butLuu.Enabled = false;
            this.butLuu.Location = new System.Drawing.Point(258, 496);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 18;
            this.butLuu.Text = "&Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Enabled = false;
            this.butBoqua.Location = new System.Drawing.Point(468, 496);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(70, 25);
            this.butBoqua.TabIndex = 19;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butHuy
            // 
            this.butHuy.Location = new System.Drawing.Point(538, 496);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(70, 25);
            this.butHuy.TabIndex = 22;
            this.butHuy.Text = "&Hủy";
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // butIn
            // 
            this.butIn.Location = new System.Drawing.Point(608, 496);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 23;
            this.butIn.Text = "&In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Location = new System.Drawing.Point(678, 496);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 24;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // listNv
            // 
            this.listNv.BackColor = System.Drawing.SystemColors.Info;
            this.listNv.ColumnCount = 0;
            this.listNv.Location = new System.Drawing.Point(721, 527);
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
            // ghichu
            // 
            this.ghichu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ghichu.Enabled = false;
            this.ghichu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ghichu.Location = new System.Drawing.Point(480, 455);
            this.ghichu.Name = "ghichu";
            this.ghichu.Size = new System.Drawing.Size(337, 21);
            this.ghichu.TabIndex = 15;
            this.ghichu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
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
            this.label8.Location = new System.Drawing.Point(-12, 388);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(160, 16);
            this.label8.TabIndex = 314;
            this.label8.Text = "Tên dịch truyền / hàm lượng :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tenyta
            // 
            this.tenyta.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenyta.Enabled = false;
            this.tenyta.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenyta.Location = new System.Drawing.Point(195, 455);
            this.tenyta.Name = "tenyta";
            this.tenyta.Size = new System.Drawing.Size(229, 21);
            this.tenyta.TabIndex = 14;
            this.tenyta.TextChanged += new System.EventHandler(this.tenyta_TextChanged);
            this.tenyta.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbs_KeyDown);
            // 
            // yta
            // 
            this.yta.BackColor = System.Drawing.SystemColors.HighlightText;
            this.yta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.yta.Enabled = false;
            this.yta.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yta.Location = new System.Drawing.Point(152, 455);
            this.yta.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.yta.MaxLength = 9;
            this.yta.Name = "yta";
            this.yta.Size = new System.Drawing.Size(41, 21);
            this.yta.TabIndex = 13;
            this.yta.Validated += new System.EventHandler(this.yta_Validated);
            this.yta.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(44, 456);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(104, 16);
            this.label14.TabIndex = 319;
            this.label14.Text = "YT (ĐD) thực hiện :";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(408, 456);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(72, 16);
            this.label16.TabIndex = 323;
            this.label16.Text = "Ghi chú :";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(92, 409);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(56, 16);
            this.label17.TabIndex = 324;
            this.label17.Text = "Số lượng :";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // soluong
            // 
            this.soluong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.soluong.Enabled = false;
            this.soluong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.soluong.Location = new System.Drawing.Point(152, 407);
            this.soluong.Name = "soluong";
            this.soluong.Size = new System.Drawing.Size(56, 21);
            this.soluong.TabIndex = 4;
            this.soluong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            this.soluong.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.soluong_KeyPress);
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(208, 410);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(96, 16);
            this.label18.TabIndex = 326;
            this.label18.Text = "Lô / số sản xuất :";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // losx
            // 
            this.losx.BackColor = System.Drawing.SystemColors.HighlightText;
            this.losx.Enabled = false;
            this.losx.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.losx.Location = new System.Drawing.Point(296, 407);
            this.losx.Name = "losx";
            this.losx.Size = new System.Drawing.Size(104, 21);
            this.losx.TabIndex = 5;
            this.losx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(384, 410);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(96, 16);
            this.label19.TabIndex = 328;
            this.label19.Text = "Tốc độ giọt/ph :";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tocdo
            // 
            this.tocdo.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tocdo.Enabled = false;
            this.tocdo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tocdo.Location = new System.Drawing.Point(480, 407);
            this.tocdo.Name = "tocdo";
            this.tocdo.Size = new System.Drawing.Size(149, 21);
            this.tocdo.TabIndex = 6;
            this.tocdo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // gio_bd
            // 
            this.gio_bd.BackColor = System.Drawing.SystemColors.HighlightText;
            this.gio_bd.Enabled = false;
            this.gio_bd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gio_bd.Location = new System.Drawing.Point(776, 408);
            this.gio_bd.Mask = "##:##";
            this.gio_bd.Name = "gio_bd";
            this.gio_bd.Size = new System.Drawing.Size(40, 21);
            this.gio_bd.TabIndex = 8;
            this.gio_bd.Text = "  :  ";
            this.gio_bd.Validated += new System.EventHandler(this.gio_bd_Validated);
            // 
            // ngay_bd
            // 
            this.ngay_bd.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngay_bd.Enabled = false;
            this.ngay_bd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngay_bd.Location = new System.Drawing.Point(680, 408);
            this.ngay_bd.Mask = "##/##/####";
            this.ngay_bd.Name = "ngay_bd";
            this.ngay_bd.Size = new System.Drawing.Size(72, 21);
            this.ngay_bd.TabIndex = 7;
            this.ngay_bd.Text = "  /  /    ";
            this.ngay_bd.Validated += new System.EventHandler(this.ngay_bd_Validated);
            // 
            // label20
            // 
            this.label20.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(752, 410);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(32, 16);
            this.label20.TabIndex = 333;
            this.label20.Text = "Giờ :";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label21
            // 
            this.label21.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(631, 410);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(56, 16);
            this.label21.TabIndex = 332;
            this.label21.Text = "Bắt đầu :";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gio_kt
            // 
            this.gio_kt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.gio_kt.Enabled = false;
            this.gio_kt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gio_kt.Location = new System.Drawing.Point(296, 431);
            this.gio_kt.Mask = "##:##";
            this.gio_kt.Name = "gio_kt";
            this.gio_kt.Size = new System.Drawing.Size(40, 21);
            this.gio_kt.TabIndex = 10;
            this.gio_kt.Text = "  :  ";
            this.gio_kt.Validated += new System.EventHandler(this.gio_kt_Validated);
            // 
            // ngay_kt
            // 
            this.ngay_kt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngay_kt.Enabled = false;
            this.ngay_kt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngay_kt.Location = new System.Drawing.Point(152, 431);
            this.ngay_kt.Mask = "##/##/####";
            this.ngay_kt.Name = "ngay_kt";
            this.ngay_kt.Size = new System.Drawing.Size(72, 21);
            this.ngay_kt.TabIndex = 9;
            this.ngay_kt.Text = "  /  /    ";
            this.ngay_kt.Validated += new System.EventHandler(this.ngay_kt_Validated);
            // 
            // label22
            // 
            this.label22.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(269, 433);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(32, 16);
            this.label22.TabIndex = 337;
            this.label22.Text = "Giờ :";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label23
            // 
            this.label23.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(92, 433);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(56, 16);
            this.label23.TabIndex = 336;
            this.label23.Text = "Kết thúc :";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbngay
            // 
            this.cmbngay.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cmbngay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbngay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbngay.Location = new System.Drawing.Point(38, 3);
            this.cmbngay.Name = "cmbngay";
            this.cmbngay.Size = new System.Drawing.Size(200, 21);
            this.cmbngay.TabIndex = 0;
            this.cmbngay.SelectedIndexChanged += new System.EventHandler(this.cmbngay_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(-2, 4);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 16);
            this.label9.TabIndex = 339;
            this.label9.Text = "Ngày :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // butXoa
            // 
            this.butXoa.Enabled = false;
            this.butXoa.Location = new System.Drawing.Point(398, 496);
            this.butXoa.Name = "butXoa";
            this.butXoa.Size = new System.Drawing.Size(70, 25);
            this.butXoa.TabIndex = 17;
            this.butXoa.Text = "&Xóa";
            this.butXoa.Click += new System.EventHandler(this.butXoa_Click);
            // 
            // butThem
            // 
            this.butThem.Enabled = false;
            this.butThem.Location = new System.Drawing.Point(328, 496);
            this.butThem.Name = "butThem";
            this.butThem.Size = new System.Drawing.Size(70, 25);
            this.butThem.TabIndex = 16;
            this.butThem.Text = "&Thêm";
            this.butThem.Click += new System.EventHandler(this.butThem_Click);
            // 
            // frmTruyendich
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(829, 565);
            this.ControlBox = false;
            this.Controls.Add(this.tocdo);
            this.Controls.Add(this.butXoa);
            this.Controls.Add(this.butThem);
            this.Controls.Add(this.tenyta);
            this.Controls.Add(this.losx);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cmbngay);
            this.Controls.Add(this.mabs);
            this.Controls.Add(this.gio_kt);
            this.Controls.Add(this.ngay_kt);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.gio_bd);
            this.Controls.Add(this.ngay_bd);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.soluong);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.ten);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.yta);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.chkXML);
            this.Controls.Add(this.ghichu);
            this.Controls.Add(this.listNv);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.butHuy);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butSua);
            this.Controls.Add(this.butMoi);
            this.Controls.Add(this.gio);
            this.Controls.Add(this.ngay);
            this.Controls.Add(this.lgio);
            this.Controls.Add(this.tenbs);
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
            this.Name = "frmTruyendich";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phiếu theo dõi truyền dịch";
            this.Load += new System.EventHandler(this.frmTruyendich_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmTruyendich_Load(object sender, System.EventArgs e)
		{
            this.Location = new System.Drawing.Point(188, 151);
			user=m.user;

            dtnv = m.get_data("select * from " + user + ".dmbs where nhom<>" + LibMedi.AccessData.nghiviec + " order by hoten").Tables[0];
			listNv.DisplayMember="MA";
			listNv.ValueMember="HOTEN";
			listNv.DataSource=dtnv;

			sql="select a.id,a.idthuchien,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay";
			sql+=" from xxx.ba_truyendich a,xxx.ba_thuchien b ";
			sql+=" where a.idthuchien=b.id and b.idkhoa="+l_idkhoa;
			sql+=" order by a.id";

			dsh=m.get_data_mmyy(sql,ngayvv.Text.Substring(0,10),s_ngayrv.Substring(0,10),false);
			cmbngay.DisplayMember="NGAY";
			cmbngay.ValueMember="ID";
			cmbngay.DataSource=dsh.Tables[0];
			l_id=(dsh.Tables[0].Rows.Count>0)?decimal.Parse(dsh.Tables[0].Rows[0]["id"].ToString()):0;
			load_grid();
			AddGridTableStyle();
			this.disabledBackBrush = new SolidBrush(Color.Black);
			this.disabledTextBrush = new SolidBrush(Color.Red);

			this.alertBackBrush = new SolidBrush(SystemColors.HotTrack);
			this.alertFont = new Font(this.dataGrid1.Font.Name, this.dataGrid1.Font.Size, FontStyle.Bold);
			this.alertTextBrush = new SolidBrush(Color.White);
			
			this.currentRowFont = new Font(this.dataGrid1.Font.Name, this.dataGrid1.Font.Size, FontStyle.Regular);
			this.currentRowBackBrush = new SolidBrush(Color.FromArgb(0,255, 255));
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
			if (r!=null) tenbs.Text=r["hoten"].ToString();
			else tenbs.Text="";	
		}

		private void tenbs_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tenbs)
			{
				Filt_dmbs(tenbs.Text);
				listNv.BrowseToDanhmuc(tenbs,mabs,yta,35);
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
            sql = "select a.stt,a.ten,a.soluong,a.losx,a.tocdo,to_char(a.batdau,'dd/mm/yyyy hh24:mi') as batdau,";
            sql += "to_char(a.ketthuc,'dd/mm/yyyy hh24:mi') as ketthuc,";
            sql += "a.bscd,c.hoten as tenbscd,a.yta,d.hoten as tenyta,a.ghichu";
            sql += " from xxx.ba_truyendichct a left join " + user + ".dmbs c on a.bscd=c.ma left join " + user + ".dmbs d on a.yta=d.ma";
            sql += " where a.id=" + l_id + " order by a.stt";
			ds=m.get_data_mmyy(sql,ngayvv.Text.Substring(0,10),s_ngayrv.Substring(0,10),false);
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
			discontinuedCol.HeaderText = "In";
			discontinuedCol.Width = 20;
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
			TextCol1.MappingName = "ten";
			TextCol1.HeaderText = "Tên dịch truyền - hàm lượng";
			TextCol1.Width =200;
			TextCol1.ReadOnly=true;
			TextCol1.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new FormattableTextBoxColumn();
			TextCol1.MappingName = "soluong";
			TextCol1.HeaderText = "Số lượng";
			TextCol1.Width =50;
			TextCol1.ReadOnly=true;
			TextCol1.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new FormattableTextBoxColumn();
			TextCol1.MappingName = "losx";
			TextCol1.HeaderText = "Lô/số sản xuất";
			TextCol1.Width =50;
			TextCol1.ReadOnly=true;
			TextCol1.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new FormattableTextBoxColumn();
			TextCol1.MappingName = "tocdo";
			TextCol1.HeaderText = "Tốc độ giọt/ph";
			TextCol1.Width =80;
			TextCol1.ReadOnly=true;
			TextCol1.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new FormattableTextBoxColumn();
			TextCol1.MappingName = "batdau";
			TextCol1.HeaderText = "Bắt đầu";
			TextCol1.Width =100;
			TextCol1.ReadOnly=true;
			TextCol1.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new FormattableTextBoxColumn();
			TextCol1.MappingName = "ketthuc";
			TextCol1.HeaderText = "Kết thúc";
			TextCol1.Width =100;
			TextCol1.ReadOnly=true;
			TextCol1.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new FormattableTextBoxColumn();
			TextCol1.MappingName = "tenbscd";
			TextCol1.HeaderText = "Bác sĩ chỉ định";
			TextCol1.Width = 180;
			TextCol1.ReadOnly=true;
			TextCol1.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new FormattableTextBoxColumn();
			TextCol1.MappingName = "tenyta";
			TextCol1.HeaderText = "YT (ĐD) thực hiện";
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
				ngay_bd.Text=r["batdau"].ToString().Substring(0,10);
				gio_bd.Text=r["batdau"].ToString().Substring(11);
				ngay_kt.Text=(r["ketthuc"].ToString()!="")?"":r["ketthuc"].ToString().Substring(0,10);
				gio_kt.Text=(r["ketthuc"].ToString()!="")?"":r["ketthuc"].ToString().Substring(11);

				ten.Text=r["ten"].ToString();
				soluong.Text=r["soluong"].ToString();
				losx.Text=r["losx"].ToString();
				tocdo.Text=r["tocdo"].ToString();

				mabs.Text=r["bscd"].ToString();
				DataRow r1=m.getrowbyid(dtnv,"ma='"+mabs.Text+"'");
				if (r1!=null) tenbs.Text=r1["hoten"].ToString();
				else tenbs.Text="";	
				
				yta.Text=r["yta"].ToString();
				r1=m.getrowbyid(dtnv,"ma='"+yta.Text+"'");
				if (r1!=null) tenyta.Text=r1["hoten"].ToString();
				else tenyta.Text="";	
				
				ghichu.Text=r["ghichu"].ToString();
			}
		}

		private void emp_detail()
		{
			ngay_bd.Text=ngay.Text;
			gio_bd.Text=gio.Text;
			ngay_kt.Text=ngay.Text;
			gio_kt.Text=gio.Text;
			i_stt=1;
			if (ds.Tables[0].Rows.Count>0) i_stt=int.Parse(ds.Tables[0].Rows[ds.Tables[0].Rows.Count-1]["stt"].ToString())+1;
			ten.Text="";soluong.Text="";losx.Text="";tocdo.Text="";yta.Text="";tenyta.Text="";ghichu.Text="";
			mabs.Text="";tenbs.Text="";
			if (s_mabs!="")
			{
				mabs.Text=s_mabs;
				DataRow r1=m.getrowbyid(dtnv,"ma='"+mabs.Text+"'");
				if (r1!=null) 	tenbs.Text=r1["hoten"].ToString();
				else tenbs.Text="";
				if (mabs.Text!="" && tenbs.Text!="" && !bAdmin)
				{
					mabs.Enabled=false;tenbs.Enabled=false;
				}
			}
		}

		private void emp_text()
		{
			l_id=0;
			string _ngay=m.ngayhienhanh_server;
			ngay.Text=_ngay.Substring(0,10);
			gio.Text=_ngay.Substring(11);
			ds.Clear();
			emp_detail();
		}

		private void ena_object(bool ena)
		{
			cmbngay.Visible=!ena;
			ngay.Visible=ena;
			lgio.Visible=ena;
			gio.Visible=ena;
			ngay.Enabled=ena;
			gio.Enabled=ena;

			ten.Enabled=ena;
			soluong.Enabled=ena;
			losx.Enabled=ena;
			tocdo.Enabled=ena;
			ngay_bd.Enabled=ena;
			gio_bd.Enabled=ena;
			ngay_kt.Enabled=ena;
			gio_kt.Enabled=ena;

			mabs.Enabled=ena;
			tenbs.Enabled=ena;
			yta.Enabled=ena;
			tenyta.Enabled=ena;
			ghichu.Enabled=ena;

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
			ngay.Focus();
		}

		private void butSua_Click(object sender, System.EventArgs e)
		{
			if (dsh.Tables[0].Rows.Count==0) return;
			ngay.Text=cmbngay.Text.ToString().Substring(0,10);
			gio.Text=cmbngay.Text.ToString().Substring(11);
			ena_object(true);
			ten.Focus();
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void butHuy_Click(object sender, System.EventArgs e)
		{
			if (dsh.Tables[0].Rows.Count==0) return;
			if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý hủy thông tin này ?"),LibMedi.AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
			{
				xxx=user+m.mmyy(cmbngay.Text.ToString());
				m.execute_data("delete from "+xxx+".ba_truyendichct where id="+l_id);
				m.execute_data("delete from "+xxx+".ba_truyendich where id="+l_id);				
				m.delrec(dsh.Tables[0],"id="+l_id);
				cmbngay.Refresh();
				l_id=(cmbngay.SelectedIndex!=-1)?decimal.Parse(cmbngay.SelectedValue.ToString()):0;
				load_grid();
				ref_text();
			}
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			ena_object(false);
			if (l_id!=0) load_grid();
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
			return true;
		}

		private bool kiemtrad()
		{
			if (ngay_bd.Text.Trim().Length!=10)
			{
				MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"),LibMedi.AccessData.Msg);
				ngay_bd.Focus();
				return false;
			}
			if (gio_bd.Text.Trim().Length!=5)
			{
				MessageBox.Show(lan.Change_language_MessageText("Giờ không hợp lệ !"),LibMedi.AccessData.Msg);
				gio_bd.Focus();
				return false;
			}
			if (!m.bNgaygio(ngay_bd.Text+" "+gio_bd.Text,ngay.Text+" "+gio.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Ngày giờ bắt đầu không được nhỏ hơn ngày giờ thực hiện !"),LibMedi.AccessData.Msg);
				ngay_bd.Focus();
				return false;
			}
			if (ngay_kt.Text!="" && gio_kt.Text!="")
			{
				if (ngay_kt.Text.Trim().Length!=10)
				{
					MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"),LibMedi.AccessData.Msg);
					ngay_kt.Focus();
					return false;
				}
				if (gio_kt.Text.Trim().Length!=5)
				{
					MessageBox.Show(lan.Change_language_MessageText("Giờ không hợp lệ !"),LibMedi.AccessData.Msg);
					gio_kt.Focus();
					return false;
				}
				if (!m.bNgaygio(ngay_kt.Text+" "+gio_kt.Text,ngay_bd.Text+" "+gio_bd.Text))
				{
					MessageBox.Show(lan.Change_language_MessageText("Ngày giờ kết thúc không được nhỏ hơn ngày giờ bắt đầu !"),LibMedi.AccessData.Msg);
					ngay_kt.Focus();
					return false;
				}
			}
			if (ten.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Tên dịch truyền - hàm lượng !"),LibMedi.AccessData.Msg);
				ten.Focus();
				return false;
			}
			if (mabs.Text=="" || tenbs.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Bác sĩ chỉ định !"),LibMedi.AccessData.Msg);
				if (mabs.Text=="") mabs.Focus();
				else tenbs.Focus();
				return false;
			}
			if (mabs.Text!="" && tenbs.Text!="")
			{
				DataRow r=m.getrowbyid(dtnv,"ma='"+mabs.Text+"'");
				if (r==null)
				{
					MessageBox.Show(lan.Change_language_MessageText("Nhập bác sĩ chỉ định !"),LibMedi.AccessData.Msg);
					mabs.Focus();
					return false;
				}
			}
			if (yta.Text!="" && tenyta.Text!="")
			{
				DataRow r=m.getrowbyid(dtnv,"ma='"+yta.Text+"'");
				if (r==null)
				{
					MessageBox.Show(lan.Change_language_MessageText("Nhập YT (ĐD) thực hiện !"),LibMedi.AccessData.Msg);
					yta.Focus();
					return false;
				}
			}
			return true;
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			if (!kiemtra()) return;
			mmyy=m.mmyy(ngay.Text);
			if (!m.bMmyy(mmyy)) m.tao_schema(mmyy,i_userid);
			xxx=user+mmyy;
			l_idthuchien=m.get_idthuchien(ngay.Text,l_idkhoa);
			if (l_idthuchien==0) 
			{
				l_idthuchien=m.get_capid(-300);
				m.upd_ba_thuchien(ngay.Text,l_idthuchien,mabn.Text,l_maql,l_idkhoa,s_makp,phong.Text,giuong.Text,chandoan.Text);
			}
			if (l_id==0) l_id=m.get_capid(-405);
			if (!upd_itemsd()) return;
            m.upd_ba_truyendich(mabn.Text, l_id, l_idthuchien, ngay.Text + " " + gio.Text, i_userid);
			upd_items();
			m.execute_data_mmyy("delete from xxx.ba_truyendichct where id="+l_id,ngayvv.Text,s_ngayrv,false);
			ds.AcceptChanges();
			foreach(DataRow r in ds.Tables[0].Rows)
				m.upd_ba_truyendichct(ngay.Text+" "+gio.Text,l_id,int.Parse(r["stt"].ToString()),r["ten"].ToString(),decimal.Parse(r["soluong"].ToString()),r["losx"].ToString(),r["tocdo"].ToString(),r["batdau"].ToString(),r["ketthuc"].ToString(),r["bscd"].ToString(),r["yta"].ToString(),r["ghichu"].ToString(),i_userid);
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
				r2["ngay"]=ngay.Text+" "+gio.Text;
				dsh.Tables[0].Rows.Add(r2);
			}
			else
			{
				DataRow [] dr=dsh.Tables[0].Select("id="+l_id);
				dr[0]["idthuchien"]=l_idthuchien;
				dr[0]["ngay"]=ngay.Text+" "+gio.Text;
			}
		}

		private bool upd_itemsd()
		{
			if (ten.Text!="")
			{
				if (!kiemtrad()) return false;
				DataRow r1,r2;
				r1=m.getrowbyid(ds.Tables[0],"stt="+i_stt);
				if (r1==null)
				{
					r2=ds.Tables[0].NewRow();
					r2["stt"]=i_stt;
					r2["batdau"]=ngay_bd.Text+" "+gio_bd.Text;
					r2["ketthuc"]=ngay_kt.Text+" "+gio_kt.Text;
					r2["ten"]=ten.Text;
					r2["soluong"]=(soluong.Text!="")?decimal.Parse(soluong.Text):0;
					r2["losx"]=losx.Text;
					r2["tocdo"]=tocdo.Text;
					r2["bscd"]=mabs.Text;
					r2["tenbscd"]=tenbs.Text;
					r2["yta"]=yta.Text;
					r2["tenyta"]=tenyta.Text;
					r2["ghichu"]=ghichu.Text;
					r2["chon"]=false;
					ds.Tables[0].Rows.Add(r2);
				}
				else
				{
					DataRow [] dr=ds.Tables[0].Select("stt="+i_stt);
					dr[0]["batdau"]=ngay_bd.Text+" "+gio_bd.Text;
					dr[0]["ketthuc"]=ngay_kt.Text+" "+gio_kt.Text;
					dr[0]["ten"]=ten.Text;
					dr[0]["soluong"]=(soluong.Text!="")?decimal.Parse(soluong.Text):0;
					dr[0]["losx"]=losx.Text;
					dr[0]["tocdo"]=tocdo.Text;
					dr[0]["bscd"]=mabs.Text;
					dr[0]["tenbscd"]=tenbs.Text;
					dr[0]["yta"]=yta.Text;
					dr[0]["tenyta"]=tenyta.Text;
					dr[0]["ghichu"]=ghichu.Text;
				}
				emp_detail();
			}
			return true;
		}

        private void butIn_Click(object sender, System.EventArgs e)
        {
            string s_stt = "", stuoi = m.get_tuoivao(l_maql).Trim();
            foreach (DataRow r1 in ds.Tables[0].Select("chon=true")) s_stt += r1["stt"].ToString() + ",";
            sql = "select a.stt,'' as sovaovien,'' as mabn,'' as hoten,'' as tuoi,'' as phai,'' as tenkp,'' as ngay,";
            sql += "'' as phong,'' as giuong,'' as chandoan,to_char(a.batdau,'dd/mm/yyyy hh24:mi') as batdau,";
            sql += "to_char(a.ketthuc,'dd/mm/yyyy hh24:mi') as ketthuc,";
            sql += "a.ten,a.soluong,a.losx,a.tocdo,c.hoten as bscd,e.hoten as yta,a.ghichu,";
            sql += "'' as i_bscd,'' as i_yta";//c.image,e.image
            sql += " from xxx.ba_truyendichct a left join " + user + ".dmbs c on a.bscd=c.ma left join " + user + ".dmbs e on a.yta=e.ma";
            sql += " where a.id=" + l_id;
            if (s_stt != "") sql += " and a.stt in (" + s_stt.Substring(0, s_stt.Length - 1) + ")";
            DataSet dsxml = m.get_data_mmyy(sql, ngayvv.Text.Substring(0, 10), s_ngayrv.Substring(0, 10), false);
            if (chkXML.Checked)
            {
                if (!System.IO.Directory.Exists("..\\xml")) System.IO.Directory.CreateDirectory("..\\xml");
                dsxml.WriteXml("..\\xml\\truyendich.xml", XmlWriteMode.WriteSchema);
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
                r["ngay"] = ngay.Text + " " + gio.Text;
            }
            if (dsxml.Tables[0].Rows.Count > 0)
            {
                dllReportM.frmReport f = new dllReportM.frmReport(m, dsxml, "", "r17bv.rpt");
                f.ShowDialog();
            }
            else MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"), LibMedi.AccessData.Msg);
        }

        private void yta_Validated(object sender, System.EventArgs e)
        {
            if (yta.Text == "") return;
            DataRow r = m.getrowbyid(dtnv, "ma='" + yta.Text + "'");
            if (r != null) tenyta.Text = r["hoten"].ToString();
            else tenyta.Text = "";
        }

		private void tenyta_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tenyta)
			{
				Filt_dmbs(tenyta.Text);
				listNv.BrowseToDanhmuc(tenyta,yta,ghichu,35);
			}		
		}

		private void butThem_Click(object sender, System.EventArgs e)
		{
			if (!upd_itemsd()) return;
			ten.Focus();
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
				load_grid();
			}
		}

		private void soluong_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			m.MaskDecimal(e);
		}

		private void ngay_bd_Validated(object sender, System.EventArgs e)
		{
			ngay_bd.Text=ngay_bd.Text.Trim();
			if (ngay_bd.Text.Length==6) ngay_bd.Text=ngay_bd.Text+DateTime.Now.Year.ToString();
			if (!m.bNgay(ngay_bd.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"));
				ngay_bd.Focus();
				return;
			}
		}

		private void gio_bd_Validated(object sender, System.EventArgs e)
		{
			string sgio=(gio_bd.Text.Trim()=="")?"00:00":gio_bd.Text.Trim();
			gio_bd.Text=sgio.Substring(0,2).PadLeft(2,'0')+":"+sgio.Substring(3).Trim().PadRight(2,'0');
			if (!m.bGio(gio_bd.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Giờ không hợp lệ !"));
				gio_bd.Focus();
				return;
			}
		}

		private void ngay_kt_Validated(object sender, System.EventArgs e)
		{
			if (ngay_kt.Text!="")
			{
				ngay_kt.Text=ngay_kt.Text.Trim();
				if (ngay_kt.Text.Length==6) ngay_kt.Text=ngay_kt.Text+DateTime.Now.Year.ToString();
				if (!m.bNgay(ngay_kt.Text))
				{
					MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"));
					ngay_kt.Focus();
					return;
				}
			}
		}

		private void gio_kt_Validated(object sender, System.EventArgs e)
		{
			if (gio_kt.Text!="")
			{
				string sgio=(gio_kt.Text.Trim()=="")?"00:00":gio_kt.Text.Trim();
				gio_kt.Text=sgio.Substring(0,2).PadLeft(2,'0')+":"+sgio.Substring(3).Trim().PadRight(2,'0');
				if (!m.bGio(gio_kt.Text))
				{
					MessageBox.Show(lan.Change_language_MessageText("Giờ không hợp lệ !"));
					gio_kt.Focus();
					return;
				}
			}
		}

        private void dataGrid1_Navigate(object sender, NavigateEventArgs ne)
        {

        }
	}
}
