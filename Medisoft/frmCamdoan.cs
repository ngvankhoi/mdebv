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
	/// Summary description for frmCamdoan.
	/// </summary>
	public class frmCamdoan : System.Windows.Forms.Form
	{
        Language lan = new Language();
Bogotiengviet tv = new Bogotiengviet();
private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();	

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
		private LibDuoc.AccessData d=new LibDuoc.AccessData();
		private int i_userid;
		private string s_makp,user,xxx,s_ngayrv,sql,s_mabs,mmyy,s_nhomkho,s_userid,s_tenkp;
		private decimal l_id,l_idthuchien,l_idkhoa,l_maql;
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
		private System.Windows.Forms.TextBox ghichu;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox tenkp;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.TextBox tenbv;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.CheckBox chk1;
		private System.Windows.Forms.CheckBox chk2;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.PictureBox pic;
		private System.Windows.Forms.Button butChon;
		private System.Windows.Forms.CheckBox chkXML;
		private byte[] image;
		private System.IO.MemoryStream memo;
		private System.IO.FileStream fstr;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.TextBox tuoi;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.TextBox phai_qh;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.TextBox dantoc;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.TextBox ngoaikieu;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.TextBox noilam;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.TextBox nghenghiep;
		private System.Windows.Forms.TextBox hoten_qh;
		private System.Windows.Forms.TextBox diachi_qh;
		private Bitmap map;

		public frmCamdoan(LibMedi.AccessData acc,string _mabn,decimal _maql,decimal _idkhoa,string _sovaovien,string _makp,string _hoten,string _namsinh,string _phai,string _diachi,string _ngayvv,string _sothe,string _phong,string _giuong,string _ngayrv,string _mabs,int _userid,string _nhomkho,string suserid,string _chandoan,string _tenkp,bool _admin)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			m=acc;mabn.Text=_mabn;l_maql=_maql;l_idkhoa=_idkhoa;sovaovien.Text=_sovaovien;i_userid=_userid;s_tenkp=_tenkp;
			hoten.Text=_hoten;chandoan.Text=_chandoan;s_makp=_makp;namsinh.Text=_namsinh;phai.Text=_phai;diachi.Text=_diachi;s_mabs=_mabs;s_nhomkho=_nhomkho;
			ngayvv.Text=_ngayvv;sothe.Text=_sothe;phong.Text=_phong;giuong.Text=_giuong;s_ngayrv=_ngayrv;s_userid=suserid;bAdmin=_admin;
            
lan.Read_Language_to_Xml(this.Name.ToString(),this);
lan.Changelanguage_to_English(this.Name.ToString(),this);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCamdoan));
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
            this.hoten_qh = new System.Windows.Forms.TextBox();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.butMoi = new System.Windows.Forms.Button();
            this.butSua = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butHuy = new System.Windows.Forms.Button();
            this.butIn = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.butChon = new System.Windows.Forms.Button();
            this.ghichu = new System.Windows.Forms.TextBox();
            this.chkXML = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tenkp = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.tenbv = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.chk1 = new System.Windows.Forms.CheckBox();
            this.chk2 = new System.Windows.Forms.CheckBox();
            this.label19 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pic = new System.Windows.Forms.PictureBox();
            this.label20 = new System.Windows.Forms.Label();
            this.tuoi = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.phai_qh = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.dantoc = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.ngoaikieu = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.noilam = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.diachi_qh = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.nghenghiep = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            this.SuspendLayout();
            // 
            // chandoan
            // 
            this.chandoan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.chandoan.Enabled = false;
            this.chandoan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chandoan.Location = new System.Drawing.Point(72, 28);
            this.chandoan.Name = "chandoan";
            this.chandoan.Size = new System.Drawing.Size(56, 21);
            this.chandoan.TabIndex = 71;
            // 
            // sothe
            // 
            this.sothe.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sothe.Enabled = false;
            this.sothe.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sothe.Location = new System.Drawing.Point(72, 28);
            this.sothe.Name = "sothe";
            this.sothe.Size = new System.Drawing.Size(56, 21);
            this.sothe.TabIndex = 63;
            // 
            // giuong
            // 
            this.giuong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.giuong.Enabled = false;
            this.giuong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.giuong.Location = new System.Drawing.Point(72, 28);
            this.giuong.Name = "giuong";
            this.giuong.Size = new System.Drawing.Size(56, 21);
            this.giuong.TabIndex = 70;
            // 
            // phong
            // 
            this.phong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.phong.Enabled = false;
            this.phong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phong.Location = new System.Drawing.Point(72, 28);
            this.phong.Name = "phong";
            this.phong.Size = new System.Drawing.Size(56, 21);
            this.phong.TabIndex = 69;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(72, 28);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 16);
            this.label13.TabIndex = 68;
            this.label13.Text = "Chẩn đoán :";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(72, 28);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 16);
            this.label12.TabIndex = 67;
            this.label12.Text = "Giường :";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(72, 28);
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
            this.ngayvv.Location = new System.Drawing.Point(72, 28);
            this.ngayvv.Name = "ngayvv";
            this.ngayvv.Size = new System.Drawing.Size(56, 21);
            this.ngayvv.TabIndex = 65;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(72, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 16);
            this.label7.TabIndex = 64;
            this.label7.Text = "Ngày :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(72, 28);
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
            this.diachi.Location = new System.Drawing.Point(72, 28);
            this.diachi.Name = "diachi";
            this.diachi.Size = new System.Drawing.Size(56, 21);
            this.diachi.TabIndex = 61;
            // 
            // phai
            // 
            this.phai.BackColor = System.Drawing.SystemColors.HighlightText;
            this.phai.Enabled = false;
            this.phai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phai.Location = new System.Drawing.Point(72, 28);
            this.phai.Name = "phai";
            this.phai.Size = new System.Drawing.Size(56, 21);
            this.phai.TabIndex = 60;
            // 
            // namsinh
            // 
            this.namsinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.namsinh.Enabled = false;
            this.namsinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namsinh.Location = new System.Drawing.Point(72, 28);
            this.namsinh.Name = "namsinh";
            this.namsinh.Size = new System.Drawing.Size(56, 21);
            this.namsinh.TabIndex = 59;
            // 
            // hoten
            // 
            this.hoten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.hoten.Enabled = false;
            this.hoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoten.Location = new System.Drawing.Point(72, 28);
            this.hoten.Name = "hoten";
            this.hoten.Size = new System.Drawing.Size(56, 21);
            this.hoten.TabIndex = 58;
            // 
            // mabn
            // 
            this.mabn.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabn.Enabled = false;
            this.mabn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabn.Location = new System.Drawing.Point(72, 28);
            this.mabn.Name = "mabn";
            this.mabn.Size = new System.Drawing.Size(56, 21);
            this.mabn.TabIndex = 52;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(72, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 16);
            this.label5.TabIndex = 57;
            this.label5.Text = "Địa chỉ :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(72, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 16);
            this.label4.TabIndex = 56;
            this.label4.Text = "Giới tính :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(72, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 16);
            this.label3.TabIndex = 55;
            this.label3.Text = "NS :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(72, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 54;
            this.label1.Text = "Họ tên :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(72, 28);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 16);
            this.label10.TabIndex = 53;
            this.label10.Text = "Mã BN :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(72, 28);
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
            this.sovaovien.Location = new System.Drawing.Point(72, 28);
            this.sovaovien.Name = "sovaovien";
            this.sovaovien.Size = new System.Drawing.Size(56, 21);
            this.sovaovien.TabIndex = 73;
            // 
            // gio
            // 
            this.gio.BackColor = System.Drawing.SystemColors.HighlightText;
            this.gio.Enabled = false;
            this.gio.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gio.Location = new System.Drawing.Point(440, 2);
            this.gio.Mask = "##:##";
            this.gio.Name = "gio";
            this.gio.Size = new System.Drawing.Size(40, 21);
            this.gio.TabIndex = 1;
            this.gio.Text = "  :  ";
            this.gio.Validated += new System.EventHandler(this.gio_Validated);
            // 
            // ngay
            // 
            this.ngay.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngay.Enabled = false;
            this.ngay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngay.Location = new System.Drawing.Point(336, 2);
            this.ngay.Mask = "##/##/####";
            this.ngay.Name = "ngay";
            this.ngay.Size = new System.Drawing.Size(72, 21);
            this.ngay.TabIndex = 0;
            this.ngay.Text = "  /  /    ";
            this.ngay.Validated += new System.EventHandler(this.ngay_Validated);
            // 
            // label88
            // 
            this.label88.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label88.Location = new System.Drawing.Point(416, 4);
            this.label88.Name = "label88";
            this.label88.Size = new System.Drawing.Size(32, 16);
            this.label88.TabIndex = 302;
            this.label88.Text = "Giờ :";
            this.label88.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label90
            // 
            this.label90.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label90.Location = new System.Drawing.Point(296, 4);
            this.label90.Name = "label90";
            this.label90.Size = new System.Drawing.Size(40, 16);
            this.label90.TabIndex = 301;
            this.label90.Text = "Ngày :";
            this.label90.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // hoten_qh
            // 
            this.hoten_qh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.hoten_qh.Enabled = false;
            this.hoten_qh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoten_qh.Location = new System.Drawing.Point(584, 28);
            this.hoten_qh.Name = "hoten_qh";
            this.hoten_qh.Size = new System.Drawing.Size(225, 21);
            this.hoten_qh.TabIndex = 2;
            this.hoten_qh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
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
            this.dataGrid1.Location = new System.Drawing.Point(6, -14);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(280, 326);
            this.dataGrid1.TabIndex = 310;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            this.dataGrid1.Click += new System.EventHandler(this.dataGrid1_Click);
            // 
            // butMoi
            // 
            this.butMoi.Location = new System.Drawing.Point(177, 496);
            this.butMoi.Name = "butMoi";
            this.butMoi.Size = new System.Drawing.Size(70, 25);
            this.butMoi.TabIndex = 17;
            this.butMoi.Text = "&Mới";
            this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
            // 
            // butSua
            // 
            this.butSua.Location = new System.Drawing.Point(247, 496);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(70, 25);
            this.butSua.TabIndex = 18;
            this.butSua.Text = "&Sửa";
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butLuu
            // 
            this.butLuu.Enabled = false;
            this.butLuu.Location = new System.Drawing.Point(317, 496);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 15;
            this.butLuu.Text = "&Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Enabled = false;
            this.butBoqua.Location = new System.Drawing.Point(387, 496);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(70, 25);
            this.butBoqua.TabIndex = 16;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butHuy
            // 
            this.butHuy.Location = new System.Drawing.Point(457, 496);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(70, 25);
            this.butHuy.TabIndex = 19;
            this.butHuy.Text = "&Hủy";
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // butIn
            // 
            this.butIn.Location = new System.Drawing.Point(527, 496);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 20;
            this.butIn.Text = "&In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Location = new System.Drawing.Point(597, 496);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 21;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // butChon
            // 
            this.butChon.Enabled = false;
            this.butChon.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butChon.Location = new System.Drawing.Point(3, 490);
            this.butChon.Name = "butChon";
            this.butChon.Size = new System.Drawing.Size(22, 21);
            this.butChon.TabIndex = 22;
            this.butChon.Text = "...";
            this.toolTip1.SetToolTip(this.butChon, "Chọn hình ");
            this.butChon.Click += new System.EventHandler(this.butChon_Click);
            // 
            // ghichu
            // 
            this.ghichu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ghichu.Enabled = false;
            this.ghichu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ghichu.Location = new System.Drawing.Point(296, 338);
            this.ghichu.Multiline = true;
            this.ghichu.Name = "ghichu";
            this.ghichu.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ghichu.Size = new System.Drawing.Size(513, 150);
            this.ghichu.TabIndex = 14;
            // 
            // chkXML
            // 
            this.chkXML.Location = new System.Drawing.Point(680, 496);
            this.chkXML.Name = "chkXML";
            this.chkXML.Size = new System.Drawing.Size(104, 24);
            this.chkXML.TabIndex = 313;
            this.chkXML.Text = "Xuất ra XML";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(296, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(336, 16);
            this.label8.TabIndex = 314;
            this.label8.Text = "- Là người bệnh / đại diện gia đình người bệnh / họ tên là :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(296, 172);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(200, 16);
            this.label9.TabIndex = 315;
            this.label9.Text = "hiện đang được điều trị tại Khoa :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tenkp
            // 
            this.tenkp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenkp.Enabled = false;
            this.tenkp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenkp.Location = new System.Drawing.Point(456, 168);
            this.tenkp.Name = "tenkp";
            this.tenkp.Size = new System.Drawing.Size(104, 21);
            this.tenkp.TabIndex = 10;
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(560, 172);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(176, 16);
            this.label14.TabIndex = 317;
            this.label14.Text = "Bệnh viện :";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tenbv
            // 
            this.tenbv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbv.Enabled = false;
            this.tenbv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbv.Location = new System.Drawing.Point(616, 168);
            this.tenbv.Name = "tenbv";
            this.tenbv.Size = new System.Drawing.Size(193, 21);
            this.tenbv.TabIndex = 11;
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(296, 200);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(488, 16);
            this.label15.TabIndex = 319;
            this.label15.Text = "Sau khi nghe Bác sĩ cho biết tình trạng bệnh của tôi/ của người gia đình tôi/ ";
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(296, 216);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(488, 14);
            this.label16.TabIndex = 320;
            this.label16.Text = "những nguy hiểm của bệnh nếu không thực hiện phẫu thuật thủ thuật, gây mê ";
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(296, 232);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(488, 17);
            this.label17.TabIndex = 321;
            this.label17.Text = "hồi sức và những rủi ro có thể xảy ra do bệnh tật, do khi tiến hành phẫu thuật, ";
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(296, 248);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(488, 16);
            this.label18.TabIndex = 322;
            this.label18.Text = "thủ thuật, gây mê hồi sức; tôi tự nguyện viết giấy cam đoan này :";
            // 
            // chk1
            // 
            this.chk1.Enabled = false;
            this.chk1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk1.Location = new System.Drawing.Point(296, 280);
            this.chk1.Name = "chk1";
            this.chk1.Size = new System.Drawing.Size(488, 16);
            this.chk1.TabIndex = 12;
            this.chk1.Text = "Đồng ý xin phẫu thuật, thủ thuật, gây mê hồi sức và để giấy này làm bằng .";
            this.chk1.CheckedChanged += new System.EventHandler(this.chk1_CheckedChanged);
            this.chk1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // chk2
            // 
            this.chk2.Enabled = false;
            this.chk2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk2.Location = new System.Drawing.Point(296, 296);
            this.chk2.Name = "chk2";
            this.chk2.Size = new System.Drawing.Size(504, 17);
            this.chk2.TabIndex = 13;
            this.chk2.Text = "Không đồng ý phẫu thuật, thủ thuật, gây mê hồi sức và để giấy này làm bằng .";
            this.chk2.CheckedChanged += new System.EventHandler(this.chk2_CheckedChanged);
            this.chk2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(360, 311);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(344, 24);
            this.label19.TabIndex = 325;
            this.label19.Text = "(Câu 1 và câu 2 do người bệnh, đại diện gia đình tự viết)";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.pic);
            this.panel1.Location = new System.Drawing.Point(8, 318);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(280, 168);
            this.panel1.TabIndex = 328;
            // 
            // pic
            // 
            this.pic.Location = new System.Drawing.Point(0, 0);
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(280, 168);
            this.pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pic.TabIndex = 0;
            this.pic.TabStop = false;
            // 
            // label20
            // 
            this.label20.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(296, 55);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(104, 16);
            this.label20.TabIndex = 329;
            this.label20.Text = "- Tuổi :";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tuoi
            // 
            this.tuoi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tuoi.Enabled = false;
            this.tuoi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tuoi.Location = new System.Drawing.Point(376, 53);
            this.tuoi.MaxLength = 3;
            this.tuoi.Name = "tuoi";
            this.tuoi.Size = new System.Drawing.Size(184, 21);
            this.tuoi.TabIndex = 3;
            this.tuoi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tuoi_KeyPress);
            this.tuoi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // label21
            // 
            this.label21.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(576, 55);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(56, 16);
            this.label21.TabIndex = 331;
            this.label21.Text = "Giới tính :";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // phai_qh
            // 
            this.phai_qh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.phai_qh.Enabled = false;
            this.phai_qh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phai_qh.Location = new System.Drawing.Point(632, 53);
            this.phai_qh.Name = "phai_qh";
            this.phai_qh.Size = new System.Drawing.Size(177, 21);
            this.phai_qh.TabIndex = 4;
            this.phai_qh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // label22
            // 
            this.label22.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(296, 79);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(104, 16);
            this.label22.TabIndex = 333;
            this.label22.Text = "- Dân tộc :";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dantoc
            // 
            this.dantoc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dantoc.Enabled = false;
            this.dantoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dantoc.Location = new System.Drawing.Point(376, 77);
            this.dantoc.Name = "dantoc";
            this.dantoc.Size = new System.Drawing.Size(184, 21);
            this.dantoc.TabIndex = 5;
            this.dantoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // label23
            // 
            this.label23.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(568, 79);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(72, 16);
            this.label23.TabIndex = 335;
            this.label23.Text = "Ngoại kiều :";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ngoaikieu
            // 
            this.ngoaikieu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngoaikieu.Enabled = false;
            this.ngoaikieu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngoaikieu.Location = new System.Drawing.Point(632, 77);
            this.ngoaikieu.Name = "ngoaikieu";
            this.ngoaikieu.Size = new System.Drawing.Size(177, 21);
            this.ngoaikieu.TabIndex = 6;
            this.ngoaikieu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // label24
            // 
            this.label24.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(296, 124);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(80, 16);
            this.label24.TabIndex = 337;
            this.label24.Text = "- Nơi làm việc :";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // noilam
            // 
            this.noilam.BackColor = System.Drawing.SystemColors.HighlightText;
            this.noilam.Enabled = false;
            this.noilam.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noilam.Location = new System.Drawing.Point(376, 123);
            this.noilam.Name = "noilam";
            this.noilam.Size = new System.Drawing.Size(433, 21);
            this.noilam.TabIndex = 8;
            this.noilam.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // label25
            // 
            this.label25.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(296, 149);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(80, 16);
            this.label25.TabIndex = 339;
            this.label25.Text = "- Địa chỉ :";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // diachi_qh
            // 
            this.diachi_qh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.diachi_qh.Enabled = false;
            this.diachi_qh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diachi_qh.Location = new System.Drawing.Point(376, 145);
            this.diachi_qh.Name = "diachi_qh";
            this.diachi_qh.Size = new System.Drawing.Size(433, 21);
            this.diachi_qh.TabIndex = 9;
            this.diachi_qh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // label26
            // 
            this.label26.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(296, 104);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(88, 16);
            this.label26.TabIndex = 341;
            this.label26.Text = "- Nghề nghiệp :";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nghenghiep
            // 
            this.nghenghiep.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nghenghiep.Enabled = false;
            this.nghenghiep.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nghenghiep.Location = new System.Drawing.Point(376, 100);
            this.nghenghiep.Name = "nghenghiep";
            this.nghenghiep.Size = new System.Drawing.Size(433, 21);
            this.nghenghiep.TabIndex = 7;
            this.nghenghiep.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // frmCamdoan
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(829, 579);
            this.Controls.Add(this.nghenghiep);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.diachi_qh);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.noilam);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.ngoaikieu);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.dantoc);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.phai_qh);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.tuoi);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.hoten_qh);
            this.Controls.Add(this.butChon);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.chk2);
            this.Controls.Add(this.chk1);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.tenbv);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.tenkp);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.chkXML);
            this.Controls.Add(this.ghichu);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.butHuy);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butSua);
            this.Controls.Add(this.butMoi);
            this.Controls.Add(this.gio);
            this.Controls.Add(this.ngay);
            this.Controls.Add(this.label88);
            this.Controls.Add(this.label90);
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
            this.Name = "frmCamdoan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Giấy cam đoan chấp nhận phẫu thuật, thủ thuật và gây mê hồi sức";
            this.Load += new System.EventHandler(this.frmCamdoan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmCamdoan_Load(object sender, System.EventArgs e)
		{
            this.Location = new System.Drawing.Point(188, 151);
			user=m.user;
			tenkp.Text=s_tenkp;tenbv.Text=m.Tenbv;
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

		private void load_grid()
		{
			sql="select a.id,a.idthuchien,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay,a.hoten,a.tuoi,a.phai,a.dantoc,a.nghenghiep,a.ngoaikieu,a.diachi,a.noilam,a.nguoinha,a.dongy,";
			sql+="a.image,a.ghichu ";
			sql+=" from xxx.ba_camdoan a,xxx.ba_thuchien b ";
			sql+=" where a.idthuchien=b.id and b.idkhoa="+l_idkhoa;
			sql+=" order by a.id";
			ds=m.get_data_mmyy(sql,ngayvv.Text.Substring(0,10),s_ngayrv.Substring(0,10),false);
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
			TextCol1.MappingName = "nguoinha";
			TextCol1.HeaderText = "Người bệnh/Đại diện gia đình";
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
			}
			catch{l_id=0;}
			load_items(l_id);
		}

		private void load_items(decimal id)
		{
			DataRow r=m.getrowbyid(ds.Tables[0],"id="+id);
			if (r!=null)
			{
				ngay.Text=r["ngay"].ToString().Substring(0,10);
				gio.Text=r["ngay"].ToString().Substring(11);
				hoten_qh.Text=r["hoten"].ToString();
				tuoi.Text=r["tuoi"].ToString();
				phai_qh.Text=r["phai"].ToString();
				dantoc.Text=r["dantoc"].ToString();
				nghenghiep.Text=r["nghenghiep"].ToString();
				ngoaikieu.Text=r["ngoaikieu"].ToString();
				diachi_qh.Text=r["diachi"].ToString();
				noilam.Text=r["noilam"].ToString();
				ghichu.Text=r["ghichu"].ToString();
				chk1.Checked=r["dongy"].ToString()=="1";
				chk2.Checked=r["dongy"].ToString()=="0";
				try
				{
					image =new byte[0];
					image =(byte[])(r["image"]);
					memo=new MemoryStream(image);
					map=new Bitmap(Image.FromStream(memo));
					pic.Image=(Bitmap)map;
					pic.Tag=image;
				}
				catch
				{
					pic.Tag="0000.bmp";
					fstr=new System.IO.FileStream(pic.Tag.ToString(),System.IO.FileMode.Open,System.IO.FileAccess.Read);
					map=new Bitmap(Image.FromStream(fstr));
					pic.Image=(Bitmap)map;
					image=new byte[fstr.Length];
					fstr.Read(image,0,System.Convert.ToInt32(fstr.Length));
					fstr.Close();
					pic.Tag=image;
				}
			}
		}

		private void emp_text()
		{
			l_id=0;
			string _ngay=m.ngayhienhanh_server;
			ngay.Text=_ngay.Substring(0,10);
			gio.Text=_ngay.Substring(11);
			hoten_qh.Text="";ghichu.Text="";chk1.Checked=false;chk2.Checked=false;
			tuoi.Text="";phai_qh.Text="";dantoc.Text="Kinh";ngoaikieu.Text="";
			nghenghiep.Text="";diachi_qh.Text="";noilam.Text="";
			pic.Tag="0000.bmp";
			fstr=new System.IO.FileStream(pic.Tag.ToString(),System.IO.FileMode.Open,System.IO.FileAccess.Read);
			map=new Bitmap(Image.FromStream(fstr));
			pic.Image=(Bitmap)map;
			image=new Byte[fstr.Length];
			fstr.Read(image,0,System.Convert.ToInt32(fstr.Length));
			fstr.Close();
			pic.Tag=image;
		}

		private void ena_object(bool ena)
		{
			ngay.Enabled=ena;
			gio.Enabled=ena;
			hoten_qh.Enabled=ena;
			tuoi.Enabled=ena;
			phai_qh.Enabled=ena;
			dantoc.Enabled=ena;
			nghenghiep.Enabled=ena;
			ngoaikieu.Enabled=ena;
			diachi_qh.Enabled=ena;
			noilam.Enabled=ena;
			ghichu.Enabled=ena;
			chk1.Enabled=ena;
			chk2.Enabled=ena;
			butChon.Enabled=ena;
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
			ngay.Focus();
		}

		private void butSua_Click(object sender, System.EventArgs e)
		{
			if (ds.Tables[0].Rows.Count==0) return;
			ena_object(true);
			ngay.Focus();
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
				xxx=user+m.mmyy(ngay.Text);
				m.execute_data("delete from "+xxx+".ba_camdoan where id="+l_id);
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
			if (hoten_qh.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Người bệnh / đại diện gia đình !"),LibMedi.AccessData.Msg);
				hoten_qh.Focus();
				return false;
			}
			if (tuoi.Text=="" || tuoi.Text=="0")
			{
				tuoi.Focus();return false;
			}
			if (phai_qh.Text=="")
			{
				phai_qh.Focus();return false;
			}
			if (dantoc.Text=="")
			{
				dantoc.Focus();return false;
			}
			if (nghenghiep.Text=="")
			{
				nghenghiep.Focus();return false;
			}
			if (diachi_qh.Text=="")
			{
				diachi_qh.Focus();return false;
			}
			if (!chk1.Checked && !chk2.Checked)
			{
				MessageBox.Show(lan.Change_language_MessageText("Đồng ý/Không đồng ý !"),LibMedi.AccessData.Msg);
				chk1.Focus();
				return false;
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
			if (l_id==0) l_id=m.get_capid(-403);
            m.upd_ba_camdoan(mabn.Text,l_id, l_idthuchien, ngay.Text + " " + gio.Text, hoten_qh.Text, (tuoi.Text != "") ? int.Parse(tuoi.Text) : 0, phai_qh.Text, dantoc.Text, nghenghiep.Text, ngoaikieu.Text, diachi_qh.Text, noilam.Text, hoten.Text, (chk1.Checked) ? 1 : 0, ghichu.Text, i_userid);
			m.upd_ba_camdoan(l_id,ngay.Text+" "+gio.Text,(byte[])(pic.Tag));
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
				r2["hoten"]=hoten_qh.Text;
				r2["tuoi"]=(tuoi.Text!="")?int.Parse(tuoi.Text):0;
				r2["phai"]=phai_qh.Text;
				r2["dantoc"]=dantoc.Text;
				r2["nghenghiep"]=nghenghiep.Text;
				r2["ngoaikieu"]=ngoaikieu.Text;
				r2["diachi"]=diachi_qh.Text;
				r2["noilam"]=noilam.Text;
				r2["nguoinha"]=hoten.Text;
				r2["ghichu"]=ghichu.Text;
				r2["dongy"]=(chk1.Checked)?1:0;
				r2["image"]=(byte[])(pic.Tag);
				r2["chon"]=true;
				ds.Tables[0].Rows.Add(r2);
			}
			else
			{
				DataRow [] dr=ds.Tables[0].Select("id="+l_id);
				dr[0]["idthuchien"]=l_idthuchien;
				dr[0]["ngay"]=ngay.Text+" "+gio.Text;
				dr[0]["hoten"]=hoten_qh.Text;
				dr[0]["tuoi"]=(tuoi.Text!="")?int.Parse(tuoi.Text):0;
				dr[0]["phai"]=phai_qh.Text;
				dr[0]["dantoc"]=dantoc.Text;
				dr[0]["nghenghiep"]=nghenghiep.Text;
				dr[0]["ngoaikieu"]=ngoaikieu.Text;
				dr[0]["diachi"]=diachi_qh.Text;
				dr[0]["noilam"]=noilam.Text;
				dr[0]["nguoinha"]=hoten.Text;
				dr[0]["ghichu"]=ghichu.Text;
				dr[0]["dongy"]=(chk1.Checked)?1:0;
				dr[0]["image"]=(byte[])(pic.Tag);
			}
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			string s_id="";
			foreach(DataRow r1 in ds.Tables[0].Select("chon=true")) s_id+=r1["id"].ToString()+",";
			sql="select a.id,'' as sovaovien,'' as mabn,a.hoten,to_char(a.tuoi) as tuoi,a.phai,'' as tenkp,";
			sql+="'' as phong,'' as giuong,'' as chandoan,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay,";
			sql+="a.dantoc,a.nghenghiep,a.ngoaikieu,a.diachi,a.noilam,";
			sql+="a.nguoinha,a.dongy,a.image,a.ghichu ";
			sql+=" from xxx.ba_camdoan a,xxx.ba_thuchien d";
			sql+=" where a.idthuchien=d.id and d.idkhoa="+l_idkhoa;
			if (s_id!="") sql+=" and a.id in ("+s_id.Substring(0,s_id.Length-1)+")";
			DataSet dsxml=m.get_data_mmyy(sql,ngayvv.Text.Substring(0,10),s_ngayrv.Substring(0,10),false);
			if (chkXML.Checked)
			{
				if (!System.IO.Directory.Exists("..\\xml")) System.IO.Directory.CreateDirectory("..\\xml");
				dsxml.WriteXml("..\\xml\\camdoan.xml",XmlWriteMode.WriteSchema);
			}				
			foreach(DataRow r in dsxml.Tables[0].Rows)
			{
				r["sovaovien"]=sovaovien.Text;
				r["mabn"]=mabn.Text;
				r["tenkp"]=s_tenkp;
				r["phong"]=phong.Text;
				r["giuong"]=giuong.Text;
				r["chandoan"]=chandoan.Text;
			}
			if (dsxml.Tables[0].Rows.Count>0)
			{
				dllReportM.frmReport f=new dllReportM.frmReport(m,dsxml,"","r03bv.rpt");
				f.ShowDialog();
			}
			else MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),LibMedi.AccessData.Msg);
		}

		private void butChon_Click(object sender, System.EventArgs e)
		{
			string sDir=System.Environment.CurrentDirectory.ToString();
			OpenFileDialog of=new OpenFileDialog();
			of.Title = "Chọn File giấy cam đoan chấp nhận phẫu thuật, thủ thuật và gây mê hồi sức";
			of.Filter = "All Files (*.*)|*.*";
			of.RestoreDirectory=true;
			if (of.ShowDialog() == DialogResult.OK)
			{
				pic.Tag=of.FileName;
				fstr=new System.IO.FileStream(pic.Tag.ToString(),System.IO.FileMode.Open,System.IO.FileAccess.Read);
				image=new byte[fstr.Length];
				fstr.Read(image,0,System.Convert.ToInt32(fstr.Length));
				pic.Tag=image;
				map=new Bitmap(Image.FromStream(fstr));
				pic.Image=(Bitmap)map;
				fstr.Close();
			}
			System.Environment.CurrentDirectory=sDir;
		}

		private void chk1_CheckedChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==chk1 && chk1.Checked) chk2.Checked=false;
		}

		private void chk2_CheckedChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==chk2 && chk2.Checked) chk1.Checked=false;
		}

		private void tuoi_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			m.MaskDigit(e);
		}
	}
}
