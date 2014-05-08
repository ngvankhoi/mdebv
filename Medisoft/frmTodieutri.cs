using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Data;
using LibVienphi;
using LibMedi;
using LibDuoc;

namespace Medisoft
{
	public class frmTodieutri : System.Windows.Forms.Form
    {
        #region Khai bao
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
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label88;
		private System.Windows.Forms.Label label90;
		private System.Windows.Forms.TextBox tenbs;
		private MaskedTextBox.MaskedTextBox mabs;
		private System.Windows.Forms.Label label87;
		private System.Windows.Forms.NumericUpDown sophieu;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.TextBox dienbien;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.ComboBox chedoan;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Button butMoi;
		private System.Windows.Forms.Button butSua;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.Button butHuy;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.Button butKetthuc;
		private System.Windows.Forms.ComboBox chon;
		private System.Windows.Forms.Button butChon;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.TextBox ngayvv;
		private MaskedBox.MaskedBox gio;
		private MaskedBox.MaskedBox ngay;
		private System.ComponentModel.IContainer components;
		private DataSet dsba=new DataSet();
		private DataSet ds=new DataSet();
		private DataSet dsct=new DataSet();
		private DataTable dtnv=new DataTable(); 
		private LibMedi.AccessData m;
		private LibDuoc.AccessData d=new LibDuoc.AccessData();
		private LibVienphi.AccessData v=new LibVienphi.AccessData();
		private int i_userid;
		private string s_makp,user,xxx,s_ngayrv,sql,s_mabs,mmyy,s_nhomkho,s_userid,s_tenkp;
		private decimal l_id,l_idthuchien,l_idkhoa,l_maql,l_idylenh,l_idba;
		private LibList.List listNv;
		private Brush disabledBackBrush;
		private Brush disabledTextBrush;
		private Brush alertBackBrush;
		private Font alertFont;
		private Brush alertTextBrush;
		private Font currentRowFont;
		private Brush currentRowBackBrush;
		private bool afterCurrentCellChanged=true,bAdmin,bNgoaitonkho,bSankhoa,bGiuong_plylenh,bPhonggiuong;
		private int checkCol=0,madoituong;
		public bool bUpdate=false;
		public string sGiuong="";
		private DataTable dtg=new DataTable();
		private DataTable dtdt=new DataTable();
		private System.Windows.Forms.CheckBox chkXML;
		private System.Windows.Forms.CheckBox sankhoa;
		private System.Windows.Forms.DataGrid dataGrid2;
		private System.Windows.Forms.Button butXoa;
		private System.Windows.Forms.Button butTiep;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.ComboBox loai;
		private System.Windows.Forms.TextBox noidung;
		private System.Windows.Forms.NumericUpDown stt;
		private System.Windows.Forms.TextBox thuchien;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.TextBox ghichu;
		private System.Windows.Forms.TextBox ylenh;
		private System.Windows.Forms.Button butPhong;
		private System.Windows.Forms.TextBox tenbs_pass;
        #endregion

        public frmTodieutri(LibMedi.AccessData acc,string _mabn,decimal _maql,decimal _idkhoa,string _sovaovien,string _makp,string _hoten,string _namsinh,string _phai,string _diachi,string _ngayvv,string _sothe,string _phong,string _giuong,string _ngayrv,string _mabs,int _userid,string _nhomkho,string suserid,string _chandoan,string _tenkp,bool _admin,bool _sankhoa,decimal _idba,DataSet _dsba,int _madoituong)
		{
			InitializeComponent();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
			m=acc;mabn.Text=_mabn;l_maql=_maql;l_idkhoa=_idkhoa;sovaovien.Text=_sovaovien;i_userid=_userid;s_tenkp=_tenkp;bSankhoa=_sankhoa;
			hoten.Text=_hoten;chandoan.Text=_chandoan;s_makp=_makp;namsinh.Text=_namsinh;phai.Text=_phai;diachi.Text=_diachi;s_mabs=_mabs;s_nhomkho=_nhomkho;
			ngayvv.Text=_ngayvv;sothe.Text=_sothe;phong.Text=_phong;giuong.Text=_giuong;s_ngayrv=_ngayrv;s_userid=suserid;bAdmin=_admin;
			dsba=_dsba;l_idba=_idba;madoituong=_madoituong;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTodieutri));
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
            this.label8 = new System.Windows.Forms.Label();
            this.gio = new MaskedBox.MaskedBox();
            this.ngay = new MaskedBox.MaskedBox();
            this.label88 = new System.Windows.Forms.Label();
            this.label90 = new System.Windows.Forms.Label();
            this.tenbs = new System.Windows.Forms.TextBox();
            this.mabs = new MaskedTextBox.MaskedTextBox();
            this.label87 = new System.Windows.Forms.Label();
            this.sophieu = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.dienbien = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.chedoan = new System.Windows.Forms.ComboBox();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.butMoi = new System.Windows.Forms.Button();
            this.butSua = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butHuy = new System.Windows.Forms.Button();
            this.butIn = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.chon = new System.Windows.Forms.ComboBox();
            this.butChon = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tenbs_pass = new System.Windows.Forms.TextBox();
            this.butPhong = new System.Windows.Forms.Button();
            this.listNv = new LibList.List();
            this.chkXML = new System.Windows.Forms.CheckBox();
            this.sankhoa = new System.Windows.Forms.CheckBox();
            this.dataGrid2 = new System.Windows.Forms.DataGrid();
            this.butXoa = new System.Windows.Forms.Button();
            this.butTiep = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.loai = new System.Windows.Forms.ComboBox();
            this.noidung = new System.Windows.Forms.TextBox();
            this.stt = new System.Windows.Forms.NumericUpDown();
            this.thuchien = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.ghichu = new System.Windows.Forms.TextBox();
            this.ylenh = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.sophieu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stt)).BeginInit();
            this.SuspendLayout();
            // 
            // chandoan
            // 
            this.chandoan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.chandoan.Enabled = false;
            this.chandoan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chandoan.Location = new System.Drawing.Point(46, 295);
            this.chandoan.Name = "chandoan";
            this.chandoan.Size = new System.Drawing.Size(709, 21);
            this.chandoan.TabIndex = 71;
            // 
            // sothe
            // 
            this.sothe.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sothe.Enabled = false;
            this.sothe.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sothe.Location = new System.Drawing.Point(46, 295);
            this.sothe.Name = "sothe";
            this.sothe.Size = new System.Drawing.Size(164, 21);
            this.sothe.TabIndex = 63;
            // 
            // giuong
            // 
            this.giuong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.giuong.Enabled = false;
            this.giuong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.giuong.Location = new System.Drawing.Point(46, 295);
            this.giuong.Name = "giuong";
            this.giuong.Size = new System.Drawing.Size(64, 21);
            this.giuong.TabIndex = 70;
            // 
            // phong
            // 
            this.phong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.phong.Enabled = false;
            this.phong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phong.Location = new System.Drawing.Point(46, 295);
            this.phong.Name = "phong";
            this.phong.Size = new System.Drawing.Size(64, 21);
            this.phong.TabIndex = 69;
            // 
            // label13
            // 
            this.label13.Enabled = false;
            this.label13.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(46, 300);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(73, 16);
            this.label13.TabIndex = 68;
            this.label13.Text = "Chẩn đoán :";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.Enabled = false;
            this.label12.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(46, 300);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(48, 16);
            this.label12.TabIndex = 67;
            this.label12.Text = "Giường :";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Enabled = false;
            this.label11.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(46, 300);
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
            this.ngayvv.Location = new System.Drawing.Point(46, 295);
            this.ngayvv.Name = "ngayvv";
            this.ngayvv.Size = new System.Drawing.Size(109, 21);
            this.ngayvv.TabIndex = 65;
            // 
            // label7
            // 
            this.label7.Enabled = false;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(46, 300);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 16);
            this.label7.TabIndex = 64;
            this.label7.Text = "Ngày :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Enabled = false;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(107, 330);
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
            this.diachi.Location = new System.Drawing.Point(171, 330);
            this.diachi.Name = "diachi";
            this.diachi.Size = new System.Drawing.Size(245, 21);
            this.diachi.TabIndex = 61;
            // 
            // phai
            // 
            this.phai.BackColor = System.Drawing.SystemColors.HighlightText;
            this.phai.Enabled = false;
            this.phai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phai.Location = new System.Drawing.Point(46, 295);
            this.phai.Name = "phai";
            this.phai.Size = new System.Drawing.Size(32, 21);
            this.phai.TabIndex = 60;
            // 
            // namsinh
            // 
            this.namsinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.namsinh.Enabled = false;
            this.namsinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namsinh.Location = new System.Drawing.Point(46, 295);
            this.namsinh.Name = "namsinh";
            this.namsinh.Size = new System.Drawing.Size(32, 21);
            this.namsinh.TabIndex = 59;
            // 
            // hoten
            // 
            this.hoten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.hoten.Enabled = false;
            this.hoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoten.Location = new System.Drawing.Point(46, 295);
            this.hoten.Name = "hoten";
            this.hoten.Size = new System.Drawing.Size(160, 21);
            this.hoten.TabIndex = 58;
            // 
            // mabn
            // 
            this.mabn.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabn.Enabled = false;
            this.mabn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabn.Location = new System.Drawing.Point(46, 295);
            this.mabn.Name = "mabn";
            this.mabn.Size = new System.Drawing.Size(56, 21);
            this.mabn.TabIndex = 52;
            // 
            // label5
            // 
            this.label5.Enabled = false;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(46, 300);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 16);
            this.label5.TabIndex = 57;
            this.label5.Text = "Địa chỉ :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Enabled = false;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(46, 300);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 16);
            this.label4.TabIndex = 56;
            this.label4.Text = "Giới tính :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(107, 331);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 16);
            this.label3.TabIndex = 55;
            this.label3.Text = "NS :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Enabled = false;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(46, 300);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 16);
            this.label1.TabIndex = 54;
            this.label1.Text = "Họ tên :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Enabled = false;
            this.label10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(46, 300);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 16);
            this.label10.TabIndex = 53;
            this.label10.Text = "Mã BN :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Enabled = false;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(46, 300);
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
            this.sovaovien.Location = new System.Drawing.Point(46, 295);
            this.sovaovien.Name = "sovaovien";
            this.sovaovien.Size = new System.Drawing.Size(70, 21);
            this.sovaovien.TabIndex = 73;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(283, 6);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 16);
            this.label8.TabIndex = 74;
            this.label8.Text = "Số phiếu :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gio
            // 
            this.gio.BackColor = System.Drawing.SystemColors.HighlightText;
            this.gio.Enabled = false;
            this.gio.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gio.Location = new System.Drawing.Point(543, 4);
            this.gio.Mask = "##:##";
            this.gio.Name = "gio";
            this.gio.Size = new System.Drawing.Size(40, 21);
            this.gio.TabIndex = 2;
            this.gio.Text = "  :  ";
            this.gio.Validated += new System.EventHandler(this.gio_Validated);
            // 
            // ngay
            // 
            this.ngay.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngay.Enabled = false;
            this.ngay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngay.Location = new System.Drawing.Point(439, 4);
            this.ngay.Mask = "##/##/####";
            this.ngay.Name = "ngay";
            this.ngay.Size = new System.Drawing.Size(72, 21);
            this.ngay.TabIndex = 1;
            this.ngay.Text = "  /  /    ";
            this.ngay.Validated += new System.EventHandler(this.ngay_Validated);
            // 
            // label88
            // 
            this.label88.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label88.Location = new System.Drawing.Point(511, 6);
            this.label88.Name = "label88";
            this.label88.Size = new System.Drawing.Size(32, 16);
            this.label88.TabIndex = 302;
            this.label88.Text = "Giờ :";
            this.label88.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label90
            // 
            this.label90.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label90.Location = new System.Drawing.Point(399, 6);
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
            this.tenbs.Location = new System.Drawing.Point(550, 515);
            this.tenbs.Name = "tenbs";
            this.tenbs.Size = new System.Drawing.Size(204, 21);
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
            this.mabs.Location = new System.Drawing.Point(507, 515);
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
            this.label87.Location = new System.Drawing.Point(472, 518);
            this.label87.Name = "label87";
            this.label87.Size = new System.Drawing.Size(48, 16);
            this.label87.TabIndex = 300;
            this.label87.Text = "Bác sĩ :";
            this.label87.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // sophieu
            // 
            this.sophieu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sophieu.Enabled = false;
            this.sophieu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sophieu.Location = new System.Drawing.Point(339, 4);
            this.sophieu.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.sophieu.Name = "sophieu";
            this.sophieu.Size = new System.Drawing.Size(56, 21);
            this.sophieu.TabIndex = 0;
            this.sophieu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label9.Location = new System.Drawing.Point(288, 31);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(104, 16);
            this.label9.TabIndex = 304;
            this.label9.Text = "DIỄN BIẾN BỆNH";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label14.Location = new System.Drawing.Point(288, 226);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(56, 16);
            this.label14.TabIndex = 15;
            this.label14.Text = "&Y LỆNH";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dienbien
            // 
            this.dienbien.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dienbien.Enabled = false;
            this.dienbien.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dienbien.Location = new System.Drawing.Point(296, 50);
            this.dienbien.Multiline = true;
            this.dienbien.Name = "dienbien";
            this.dienbien.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.dienbien.Size = new System.Drawing.Size(521, 170);
            this.dienbien.TabIndex = 3;
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(40, 519);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(96, 16);
            this.label15.TabIndex = 308;
            this.label15.Text = "Chế độ ăn uống :";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chedoan
            // 
            this.chedoan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.chedoan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.chedoan.Enabled = false;
            this.chedoan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chedoan.Location = new System.Drawing.Point(128, 515);
            this.chedoan.Name = "chedoan";
            this.chedoan.Size = new System.Drawing.Size(344, 21);
            this.chedoan.TabIndex = 10;
            this.chedoan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chedoan_KeyDown);
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
            this.dataGrid1.Location = new System.Drawing.Point(6, 3);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(280, 237);
            this.dataGrid1.TabIndex = 310;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            this.dataGrid1.Click += new System.EventHandler(this.dataGrid1_Click);
            // 
            // butMoi
            // 
            this.butMoi.Location = new System.Drawing.Point(167, 545);
            this.butMoi.Name = "butMoi";
            this.butMoi.Size = new System.Drawing.Size(70, 25);
            this.butMoi.TabIndex = 16;
            this.butMoi.Text = "&Mới";
            this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
            // 
            // butSua
            // 
            this.butSua.Location = new System.Drawing.Point(237, 545);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(70, 25);
            this.butSua.TabIndex = 17;
            this.butSua.Text = "&Sửa";
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butLuu
            // 
            this.butLuu.Enabled = false;
            this.butLuu.Location = new System.Drawing.Point(307, 545);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 14;
            this.butLuu.Text = "&Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Enabled = false;
            this.butBoqua.Location = new System.Drawing.Point(377, 545);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(70, 25);
            this.butBoqua.TabIndex = 15;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butHuy
            // 
            this.butHuy.Location = new System.Drawing.Point(447, 545);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(70, 25);
            this.butHuy.TabIndex = 18;
            this.butHuy.Text = "&Hủy";
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // butIn
            // 
            this.butIn.Location = new System.Drawing.Point(517, 545);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 19;
            this.butIn.Text = "&In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Location = new System.Drawing.Point(587, 545);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 20;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // chon
            // 
            this.chon.BackColor = System.Drawing.SystemColors.HighlightText;
            this.chon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.chon.Enabled = false;
            this.chon.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chon.Items.AddRange(new object[] {
            "Thường qui",
            "Tủ trực",
            "Hoàn trả"});
            this.chon.Location = new System.Drawing.Point(339, 224);
            this.chon.Name = "chon";
            this.chon.Size = new System.Drawing.Size(450, 21);
            this.chon.TabIndex = 16;
            // 
            // butChon
            // 
            this.butChon.Enabled = false;
            this.butChon.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butChon.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butChon.Location = new System.Drawing.Point(795, 223);
            this.butChon.Name = "butChon";
            this.butChon.Size = new System.Drawing.Size(22, 21);
            this.butChon.TabIndex = 17;
            this.butChon.Text = "...";
            this.toolTip1.SetToolTip(this.butChon, "Nhập thuốc theo y lệnh");
            this.butChon.Click += new System.EventHandler(this.butChon_Click);
            // 
            // tenbs_pass
            // 
            this.tenbs_pass.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbs_pass.Enabled = false;
            this.tenbs_pass.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbs_pass.Location = new System.Drawing.Point(753, 515);
            this.tenbs_pass.Name = "tenbs_pass";
            this.tenbs_pass.PasswordChar = '*';
            this.tenbs_pass.Size = new System.Drawing.Size(64, 21);
            this.tenbs_pass.TabIndex = 13;
            this.toolTip1.SetToolTip(this.tenbs_pass, "Mật khẩu bác sĩ điều trị");
            this.tenbs_pass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // butPhong
            // 
            this.butPhong.Enabled = false;
            this.butPhong.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butPhong.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butPhong.Location = new System.Drawing.Point(46, 295);
            this.butPhong.Name = "butPhong";
            this.butPhong.Size = new System.Drawing.Size(22, 21);
            this.butPhong.TabIndex = 330;
            this.butPhong.Text = "...";
            this.toolTip1.SetToolTip(this.butPhong, "Chọn phòng/giường");
            this.butPhong.Visible = false;
            this.butPhong.Click += new System.EventHandler(this.butPhong_Click);
            // 
            // listNv
            // 
            this.listNv.BackColor = System.Drawing.SystemColors.Info;
            this.listNv.ColumnCount = 0;
            this.listNv.Location = new System.Drawing.Point(656, 18);
            this.listNv.MatchBufferTimeOut = 1000;
            this.listNv.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listNv.Name = "listNv";
            this.listNv.Size = new System.Drawing.Size(75, 17);
            this.listNv.TabIndex = 311;
            this.listNv.TextIndex = -1;
            this.listNv.TextMember = null;
            this.listNv.ValueIndex = -1;
            this.listNv.Visible = false;
            this.listNv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listNv_KeyDown);
            // 
            // chkXML
            // 
            this.chkXML.Location = new System.Drawing.Point(8, 545);
            this.chkXML.Name = "chkXML";
            this.chkXML.Size = new System.Drawing.Size(104, 24);
            this.chkXML.TabIndex = 314;
            this.chkXML.Text = "Xuất ra XML";
            // 
            // sankhoa
            // 
            this.sankhoa.Appearance = System.Windows.Forms.Appearance.Button;
            this.sankhoa.Enabled = false;
            this.sankhoa.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.sankhoa.Location = new System.Drawing.Point(756, 23);
            this.sankhoa.Name = "sankhoa";
            this.sankhoa.Size = new System.Drawing.Size(61, 21);
            this.sankhoa.TabIndex = 315;
            this.sankhoa.Text = "Sản khoa";
            this.sankhoa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.sankhoa.CheckedChanged += new System.EventHandler(this.sankhoa_CheckedChanged);
            // 
            // dataGrid2
            // 
            this.dataGrid2.AlternatingBackColor = System.Drawing.Color.Lavender;
            this.dataGrid2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid2.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGrid2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid2.CaptionBackColor = System.Drawing.SystemColors.Control;
            this.dataGrid2.CaptionFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid2.CaptionForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid2.DataMember = "";
            this.dataGrid2.FlatMode = true;
            this.dataGrid2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid2.GridLineColor = System.Drawing.Color.Gainsboro;
            this.dataGrid2.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            this.dataGrid2.HeaderFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.dataGrid2.HeaderForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid2.LinkColor = System.Drawing.Color.Teal;
            this.dataGrid2.Location = new System.Drawing.Point(8, 228);
            this.dataGrid2.Name = "dataGrid2";
            this.dataGrid2.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid2.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid2.ReadOnly = true;
            this.dataGrid2.RowHeaderWidth = 10;
            this.dataGrid2.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid2.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid2.Size = new System.Drawing.Size(809, 164);
            this.dataGrid2.TabIndex = 322;
            this.dataGrid2.CurrentCellChanged += new System.EventHandler(this.dataGrid2_CurrentCellChanged);
            // 
            // butXoa
            // 
            this.butXoa.Enabled = false;
            this.butXoa.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butXoa.Location = new System.Drawing.Point(777, 400);
            this.butXoa.Name = "butXoa";
            this.butXoa.Size = new System.Drawing.Size(40, 21);
            this.butXoa.TabIndex = 8;
            this.butXoa.Text = "&Xóa";
            this.butXoa.Click += new System.EventHandler(this.butXoa_Click);
            // 
            // butTiep
            // 
            this.butTiep.Enabled = false;
            this.butTiep.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butTiep.Location = new System.Drawing.Point(734, 400);
            this.butTiep.Name = "butTiep";
            this.butTiep.Size = new System.Drawing.Size(40, 21);
            this.butTiep.TabIndex = 7;
            this.butTiep.Text = "&Tiếp";
            this.butTiep.Click += new System.EventHandler(this.butTiep_Click);
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(8, 403);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(32, 16);
            this.label16.TabIndex = 325;
            this.label16.Text = "Loại :";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // loai
            // 
            this.loai.BackColor = System.Drawing.SystemColors.HighlightText;
            this.loai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.loai.Enabled = false;
            this.loai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loai.Location = new System.Drawing.Point(40, 400);
            this.loai.Name = "loai";
            this.loai.Size = new System.Drawing.Size(120, 21);
            this.loai.TabIndex = 4;
            this.loai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // noidung
            // 
            this.noidung.BackColor = System.Drawing.SystemColors.HighlightText;
            this.noidung.Enabled = false;
            this.noidung.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noidung.Location = new System.Drawing.Point(208, 400);
            this.noidung.Name = "noidung";
            this.noidung.Size = new System.Drawing.Size(248, 21);
            this.noidung.TabIndex = 5;
            this.noidung.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // stt
            // 
            this.stt.Enabled = false;
            this.stt.Location = new System.Drawing.Point(224, 184);
            this.stt.Name = "stt";
            this.stt.Size = new System.Drawing.Size(48, 20);
            this.stt.TabIndex = 326;
            // 
            // thuchien
            // 
            this.thuchien.BackColor = System.Drawing.SystemColors.HighlightText;
            this.thuchien.Enabled = false;
            this.thuchien.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thuchien.Location = new System.Drawing.Point(152, 144);
            this.thuchien.Name = "thuchien";
            this.thuchien.Size = new System.Drawing.Size(72, 21);
            this.thuchien.TabIndex = 327;
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(168, 403);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(48, 16);
            this.label17.TabIndex = 328;
            this.label17.Text = "Y lệnh :";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(456, 403);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(56, 16);
            this.label18.TabIndex = 329;
            this.label18.Text = "Ghi chú :";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ghichu
            // 
            this.ghichu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ghichu.Enabled = false;
            this.ghichu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ghichu.Location = new System.Drawing.Point(504, 400);
            this.ghichu.Name = "ghichu";
            this.ghichu.Size = new System.Drawing.Size(225, 21);
            this.ghichu.TabIndex = 6;
            this.ghichu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // ylenh
            // 
            this.ylenh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ylenh.Enabled = false;
            this.ylenh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ylenh.Location = new System.Drawing.Point(40, 423);
            this.ylenh.Multiline = true;
            this.ylenh.Name = "ylenh";
            this.ylenh.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ylenh.Size = new System.Drawing.Size(777, 86);
            this.ylenh.TabIndex = 9;
            // 
            // frmTodieutri
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(829, 579);
            this.ControlBox = false;
            this.Controls.Add(this.ylenh);
            this.Controls.Add(this.noidung);
            this.Controls.Add(this.ghichu);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.loai);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.butXoa);
            this.Controls.Add(this.butTiep);
            this.Controls.Add(this.sankhoa);
            this.Controls.Add(this.chkXML);
            this.Controls.Add(this.tenbs_pass);
            this.Controls.Add(this.listNv);
            this.Controls.Add(this.butChon);
            this.Controls.Add(this.chon);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.butHuy);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butSua);
            this.Controls.Add(this.butMoi);
            this.Controls.Add(this.chedoan);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.dienbien);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.sophieu);
            this.Controls.Add(this.gio);
            this.Controls.Add(this.ngay);
            this.Controls.Add(this.label88);
            this.Controls.Add(this.label90);
            this.Controls.Add(this.tenbs);
            this.Controls.Add(this.mabs);
            this.Controls.Add(this.label87);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dataGrid2);
            this.Controls.Add(this.stt);
            this.Controls.Add(this.thuchien);
            this.Controls.Add(this.butPhong);
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
            this.Controls.Add(this.phai);
            this.Controls.Add(this.namsinh);
            this.Controls.Add(this.hoten);
            this.Controls.Add(this.mabn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.diachi);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTodieutri";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tờ điều trị";
            this.Load += new System.EventHandler(this.frmTodieutri_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sophieu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmTodieutri_Load(object sender, System.EventArgs e)
		{
            this.Location = new System.Drawing.Point(188, 151);
			bGiuong_plylenh=m.bGiuong_plylenh;
			if (bGiuong_plylenh)
			{
                dtg = m.get_data("select * from " + m.user + ".dmgiuong").Tables[0];
                dtdt = m.get_data("select * from " + m.user + ".doituong").Tables[0];
			}
			chon.SelectedIndex=0;user=m.user;bNgoaitonkho=m.bNgoaitonkho;
			sankhoa.Visible=bSankhoa;

            dtnv = m.get_data("select * from " + m.user + ".dmbs where nhom<>" + LibMedi.AccessData.nghiviec + " order by hoten").Tables[0];
			listNv.DisplayMember="MA";
			listNv.ValueMember="HOTEN";
			listNv.DataSource=dtnv;

			chedoan.DisplayMember="TEN";
			chedoan.ValueMember="ID";
            chedoan.DataSource = m.get_data("select * from " + m.user + ".ba_dmchedoan order by stt").Tables[0];

			loai.DisplayMember="TEN";
			loai.ValueMember="ID";
            loai.DataSource = m.get_data("select * from " + m.user + ".ba_dmylenh order by stt").Tables[0];

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
			AddGridTableStyle1();
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

		private void chedoan_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (chedoan.SelectedIndex==-1 && chedoan.Items.Count>0) chedoan.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void load_grid()
		{
			sql="select a.id,a.idthuchien,a.sophieu,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay,a.dienbien,a.ylenh,";
            sql += "a.idylenh,a.chedoan,a.mabs,a.loai,a.sankhoa,c.hoten as tenbs,c.password_ from xxx.ba_dieutri a,xxx.ba_thuchien b," + user + ".dmbs c where a.idthuchien=b.id and a.mabs=c.ma and b.idkhoa=" + l_idkhoa;
			sql+=" order by a.id";
			ds=m.get_data_mmyy(sql,ngayvv.Text.Substring(0,10),s_ngayrv.Substring(0,10),false);
			ds.Tables[0].Columns.Add("Chon",typeof(bool));
			dataGrid1.DataSource=ds.Tables[0];
			CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource,dataGrid1.DataMember]; 
			DataView dv = (DataView) cm.List; 
			dv.AllowNew = false; 
			foreach (DataRow row in ds.Tables[0].Rows) row["chon"]=false;
		}

		private void AddGridTableStyle1()
		{
			DataGridTableStyle ts =new DataGridTableStyle();
			ts.MappingName = dsct.Tables[0].TableName;
			ts.AlternatingBackColor = Color.Beige;
			ts.BackColor = Color.GhostWhite;
			ts.ForeColor = Color.MidnightBlue;
			ts.GridLineColor = Color.RoyalBlue;
			ts.HeaderBackColor = Color.MidnightBlue;
			ts.HeaderForeColor = Color.Lavender;
			ts.SelectionBackColor = Color.Teal;
			ts.SelectionForeColor = Color.PaleGreen;
			ts.ReadOnly=false;
			ts.RowHeaderWidth=10;
						
			DataGridTextBoxColumn TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "stt";
			TextCol.HeaderText = "Stt";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "noidung";
			TextCol.HeaderText = "Y lệnh";
			TextCol.Width = 280;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "ghichu";
			TextCol.HeaderText = "Ghi chú";
			TextCol.Width = 230;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "thuchien";
			TextCol.HeaderText = "Thực hiện";
			TextCol.Width = 230;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "loai";
			TextCol.HeaderText = "";
			TextCol.Width =0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts);
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
			TextCol1.MappingName = "sophieu";
			TextCol1.HeaderText = "Số";
			TextCol1.Width = 30;
			TextCol1.ReadOnly=true;
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
			TextCol1.Width = 150;
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
				sophieu.Value=decimal.Parse(r["sophieu"].ToString());
				ngay.Text=r["ngay"].ToString().Substring(0,10);
				gio.Text=r["ngay"].ToString().Substring(11);
				dienbien.Text=r["dienbien"].ToString();
				ylenh.Text=r["ylenh"].ToString();
				chedoan.SelectedValue=r["chedoan"].ToString();
				chon.SelectedIndex=int.Parse(r["loai"].ToString());
				mabs.Text=r["mabs"].ToString();
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
				sankhoa.Checked=r["sankhoa"].ToString()!="0";
			}
            sql = "select a.*,b.ten from xxx.ba_dieutrict a," + user + ".ba_dmylenh b where a.loai=b.id and a.id=" + id + " order by a.stt";
			dsct=m.get_data_mmyy(sql,ngayvv.Text.Substring(0,10),s_ngayrv.Substring(0,10),false);
			dataGrid2.DataSource=dsct.Tables[0];
			ref_text1();
		}

		private void emp_text()
		{
			try
			{
				sophieu.Value=decimal.Parse(ds.Tables[0].Rows[ds.Tables[0].Rows.Count-1]["sophieu"].ToString())+1;
			}
			catch{sophieu.Value=1;}
			l_id=0;
			string _ngay=m.ngayhienhanh_server;
			ngay.Text=_ngay.Substring(0,10);
			gio.Text=_ngay.Substring(11);
			dienbien.Text="";ylenh.Text="";
			mabs.Text="";tenbs.Text="";tenbs_pass.Text="";
			if (sankhoa.Visible) sankhoa.Checked=false;
			if (s_mabs!="")
			{
				mabs.Text=s_mabs;
				DataRow r1=m.getrowbyid(dtnv,"ma='"+mabs.Text+"'");
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
			dsct.Clear();stt.Value=1;noidung.Text="";thuchien.Text="";ghichu.Text="";
		}

		private void ena_object(bool ena)
		{
			sophieu.Enabled=ena;
			ngay.Enabled=ena;
			gio.Enabled=ena;
			dienbien.Enabled=ena;
			ylenh.Enabled=ena;
			chon.Enabled=ena;
			butChon.Enabled=ena;
			chedoan.Enabled=ena;
			mabs.Enabled=ena;
			tenbs.Enabled=ena;
			tenbs_pass.Enabled=ena;
			butLuu.Enabled=ena;
			butBoqua.Enabled=ena;
			if (bSankhoa) sankhoa.Enabled=ena;
			butMoi.Enabled=!ena;
			butSua.Enabled=!ena;
			butIn.Enabled=!ena;
			butHuy.Enabled=!ena;
			butKetthuc.Enabled=!ena;
			dataGrid1.Enabled=!ena;
			loai.Enabled=ena;
			noidung.Enabled=ena;
			ghichu.Enabled=ena;
			butTiep.Enabled=ena;
			butXoa.Enabled=ena;
		}

		private void butMoi_Click(object sender, System.EventArgs e)
		{
			ena_object(true);
			if (s_makp=="99" && bGiuong_plylenh)
			{
                bPhonggiuong = m.get_data("select * from " + m.user + ".theodoigiuong where mabn='" + mabn.Text + "' and makp='" + s_makp + "' and den is null").Tables[0].Rows.Count == 0;
				butPhong.Visible=bPhonggiuong;
			}
			emp_text();
			sophieu.Focus();
		}

		private void butSua_Click(object sender, System.EventArgs e)
		{
			if (ds.Tables[0].Rows.Count==0) return;
			ena_object(true);
			sophieu.Focus();
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void butHuy_Click(object sender, System.EventArgs e)
		{
            //TU:19/05/1011 ????????
			//if (ds.Tables[0].Rows.Count==0 || dsct.Tables[0].Select("loai=1 or thuchien is not null").Length>0) return;
			if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý hủy thông tin này ?"),LibMedi.AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
			{
				xxx=user+m.mmyy(ngay.Text);
                m.execute_data("delete from " + xxx + ".ba_dieutri where id=" + l_id);
                m.execute_data("delete from " + xxx + ".ba_dieutrict where id=" + l_id);
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
			if (chedoan.SelectedIndex==-1)
			{
				MessageBox.Show(lan.Change_language_MessageText("Chọn chế độ ăn !"),LibMedi.AccessData.Msg);
				chedoan.Focus();
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
                //if (!bAdmin)
                //{
                //    if (tenbs_pass.Text!=r["password_"].ToString())
                //    {
                //        MessageBox.Show(lan.Change_language_MessageText("Mật khẩu bác sĩ điều trị chưa hợp lệ !"),LibMedi.AccessData.Msg);
                //        tenbs_pass.Focus();
                //        return false;
                //    }
                //}
			}
//			if (!sankhoa.Checked)
//			{
//				if (dienbien.Text=="")
//				{
//					MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập diễn biến bệnh !",LibMedi.AccessData.Msg);
//					dienbien.Focus();
//					return false;
//				}
//				if (ylenh.Text=="")
//				{
//					MessageBox.Show(lan.Change_language_MessageText("Yêu cầu nhập y lệnh !",LibMedi.AccessData.Msg);
//					ylenh.Focus();
//					return false;
//				}
//			}
			if (butPhong.Visible && giuong.Text == "")
			{
				MessageBox.Show(lan.Change_language_MessageText("Yêu cầu chọn phòng/giường !"), LibMedi.AccessData.Msg);
				butPhong.Focus();
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
            if (l_id == 0) l_id = m.get_capid(-302);
            else m.execute_data("delete from " + xxx + ".ba_dieutrict where id=" + l_id);
            m.upd_ba_dieutri(mabn.Text, l_id, l_idthuchien, sophieu.Value, ngay.Text + " " + gio.Text, dienbien.Text, ylenh.Text, l_idylenh, int.Parse(chedoan.SelectedValue.ToString()), mabs.Text, chon.SelectedIndex, (sankhoa.Checked) ? l_idba : 0, i_userid);
			foreach(DataRow r in dsct.Tables[0].Rows) m.upd_ba_dieutrict(ngay.Text+" "+gio.Text,l_id,int.Parse(r["stt"].ToString()),int.Parse(r["loai"].ToString()),r["noidung"].ToString(),r["ghichu"].ToString());
			if (butPhong.Visible)
			{
				DataRow r2,r1=m.getrowbyid(dtg,"ma='"+giuong.Text+"'");
				string fie="gia_th";
				decimal id=v.get_id_vpkhoa;
				if (r1!=null)
				{
					r2=m.getrowbyid(dtdt,"madoituong="+madoituong);
					if (r2!=null) fie=r2["field_gia"].ToString().Trim();
					decimal tygia = (fie.IndexOf("_nn") != -1) ? m.dTygia : 1;
					decimal idgiuong=decimal.Parse(r1["id"].ToString());
                    m.upd_theodoigiuong(id, s_makp, mabn.Text, l_maql, l_idkhoa, madoituong, int.Parse(r1["id"].ToString()), ngay.Text + " " + gio.Text, decimal.Parse(r1[fie].ToString()) * tygia, i_userid);
					m.execute_data("update "+user+".dmgiuong set tinhtrang=2,soluong=soluong+1 where id="+int.Parse(r1["id"].ToString()));
					int itable=m.tableid("","theodoigiuong");
					m.upd_eve_tables(itable,i_userid,"ins");
					m.upd_eve_upd_del(itable,i_userid,"ins",m.fields(m.user+".theodoigiuong","id="+id));
					m.execute_data("update "+user+".hiendien set idgiuong="+idgiuong+" where id="+l_idkhoa);
					m.execute_data("update "+user+".nhapkhoa set giuong='"+giuong.Text+"' where id="+l_idkhoa);
					sGiuong=giuong.Text;
				}
			}
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
				r2["sophieu"]=sophieu.Value;
				r2["ngay"]=ngay.Text+" "+gio.Text;
				r2["dienbien"]=dienbien.Text;
				r2["ylenh"]=ylenh.Text;
				r2["idylenh"]=l_idylenh;
				r2["chedoan"]=int.Parse(chedoan.SelectedValue.ToString());
				r2["mabs"]=mabs.Text;
				r2["loai"]=chon.SelectedIndex;
				r2["tenbs"]=tenbs.Text;
				r2["password_"]=tenbs_pass.Text;
				r2["sankhoa"]=(sankhoa.Checked)?l_idba:0;
				r2["chon"]=true;
				ds.Tables[0].Rows.Add(r2);
			}
			else
			{
				DataRow [] dr=ds.Tables[0].Select("id="+l_id);
				dr[0]["idthuchien"]=l_idthuchien;
				dr[0]["sophieu"]=sophieu.Value;
				dr[0]["ngay"]=ngay.Text+" "+gio.Text;
				dr[0]["dienbien"]=dienbien.Text;
				dr[0]["ylenh"]=ylenh.Text;
				dr[0]["idylenh"]=l_idylenh;
				dr[0]["chedoan"]=int.Parse(chedoan.SelectedValue.ToString());
				dr[0]["mabs"]=mabs.Text;
				dr[0]["loai"]=chon.SelectedIndex;
				dr[0]["tenbs"]=tenbs.Text;
				dr[0]["password_"]=tenbs_pass.Text;
				dr[0]["sankhoa"]=(sankhoa.Checked)?l_idba:0;
			}
		}

		private void butChon_Click(object sender, System.EventArgs e)
		{
			string t1="d_dutrull",t2="d_dutruct";
			decimal l_duyet=0;
			if (chon.SelectedIndex==0)
			{
                frmChonthongso f = new frmChonthongso(m, 1, 1, 1, s_makp + ",", false, s_nhomkho, this.i_userid);//linh 16102012
				f.ShowDialog(this);
				if (f.s_makp!="")
				{
                    bool bLuudon = false;
                    frmDutru f1 = new frmDutru(f.s_ngay, f.s_makho, f.s_makp, f.i_nhom, 1, f.i_phieu, f.i_makp, i_userid, f.s_mmyy, f.l_duyet, "Dự trù " + f.s_tennhom.Trim() + " theo người bệnh (" + f.s_ngay.Trim() + ", " + f.s_tenkp.Trim() + ", " + f.s_phieu.Trim() + ", " + s_userid.Trim() + ")", LibMedi.AccessData.Msg, m.bDausinhton, m.iSudungthuoc, f.s_manguon, f.i_buoi, f.s_tenkp, f.s_phieu, f.i_somay, s_mabs);//, bLuudon, mabn.Text);
					f1.ShowDialog(this);
                    l_duyet = 0;// f1.duyet;
					t1="d_dutrull";t2="d_dutruct";
				}
			}
			else if (chon.SelectedIndex==1)
			{
                frmChonthongso f = new frmChonthongso(m, 1, 2, 0, s_makp + ",", false, s_nhomkho, this.i_userid);//linh 16102012
				f.ShowDialog(this);
				if (f.s_makp!="")
				{
                    frmXtutruc f1 = new frmXtutruc(f.s_ngay, f.s_makho, f.s_makp, f.i_nhom, 2, f.i_phieu, f.i_macstt, f.i_makp, i_userid, f.s_mmyy, f.l_duyet, "Phiếu xuất tủ trực " + f.s_tennhom.Trim() + " theo người bệnh (" + f.s_ngay.Trim() + ", " + f.s_tenkp.Trim() + ", " + f.s_phieu.Trim() + ", " + s_userid.Trim() + ")", LibMedi.AccessData.Msg, m.bDausinhton, m.iSudungthuoc, f.s_manguon, mabn.Text, f.i_buoi, f.s_tenkp, f.s_phieu, f.i_somay, "");//, false, 0);
					f1.ShowDialog(this);
                    l_duyet = 0;// f1.l_duyet;
					t1="d_xtutrucll";t2="d_xtutrucct";
				}		
			}
			else
			{
                frmChonthongso f = new frmChonthongso(m, 1, 3, 1, s_makp + ",", false, s_nhomkho, this.i_userid);//linh 16102012
				f.ShowDialog(this);
				if (f.s_makp!="")
				{
                    frmHoantra f1 = new frmHoantra(f.s_ngay, f.s_makho, f.s_makp, f.i_nhom, 3, f.i_phieu, f.i_makp, i_userid, f.s_mmyy, f.l_duyet, "Hoàn trả " + f.s_tennhom.Trim() + " theo người bệnh (" + f.s_ngay.Trim() + ", " + f.s_tenkp.Trim() + ", " + f.s_phieu.Trim() + ", " + s_userid.Trim() + ")", LibMedi.AccessData.Msg, m.bDausinhton, m.iSudungthuoc, f.i_buoi, f.s_tenkp, f.s_phieu, f.i_somay);//, mabn.Text);
					f1.ShowDialog(this);
                    l_duyet = 0;// f1.l_duyet;
					t1="d_hoantrall";t2="d_hoantract";
				}
			}
			if (l_duyet!=0)
			{
				if (chon.SelectedIndex==0 && bNgoaitonkho)
				{
					sql="select a.id,case when c.ten is not null then trim(c.ten)||' '||trim(c.hamluong) else d.ten end as ten,nvl(c.dang,d.dang) as dang,b.slylenh,";
					if (chon.SelectedIndex==2) sql+="'' as cachdung ";
					else sql+="b.cachdung ";
                    sql += " from " + m.user + "." + t1 + " a," + m.user + "." + t2 + " b," + m.user + ".d_dmbd c," + m.user + ".d_dmthuoc d ";
					sql+=" where a.id=b.id and b.mabd=c.id(+) and b.mabd=d.id(+) and a.mabn='"+mabn.Text+"' and a.idduyet="+l_duyet;
					sql+=" order by b.tt,b.stt";
				}
				else
				{
					sql="select a.id,trim(c.ten)||' '||trim(c.hamluong) as ten,c.dang,b.slylenh,";
					if (chon.SelectedIndex==2) sql+="'' as cachdung ";
					else sql+="b.cachdung ";
                    sql += " from " + m.user + "." + t1 + " a," + m.user + "." + t2 + " b," + m.user + ".d_dmbd c ";
					sql+=" where a.id=b.id and b.mabd=c.id and a.mabn='"+mabn.Text+"' and a.idduyet="+l_duyet;
					sql+=" order by b.stt";
				}
				//string s="";
				if (chon.SelectedIndex<2)
				{
					int i=1;
					try
					{
						i=int.Parse(dsct.Tables[0].Rows[dsct.Tables[0].Rows.Count-1]["stt"].ToString())+1;
					}
					catch{i=1;}
					d.delrec(dsct.Tables[0],"loai=1");
					foreach(DataRow r in m.get_data(sql).Tables[0].Rows)
					{
						l_idylenh=decimal.Parse(r["id"].ToString());
						//s+=i.ToString()+". "+r["ten"].ToString()+"\t"+r["slylenh"].ToString().Trim()+"\t"+r["dang"].ToString().Trim()+"\n\t"+r["cachdung"].ToString().Trim()+"\n";
						stt.Value=i;
						noidung.Text=r["ten"].ToString().Trim()+" "+r["slylenh"].ToString().Trim()+" "+r["dang"].ToString().Trim();
						ghichu.Text=r["cachdung"].ToString().Trim();
						loai.SelectedValue="1";
						upd_items(i,noidung.Text,ghichu.Text);
						i++;
					}
				}
				//if (ylenh.Text.Trim()=="")	ylenh.Text+=s;
			}
		}

		private void upd_items(int stt,string noidung,string ghichu)
		{
			DataRow r1=dsct.Tables[0].NewRow();
			r1["stt"]=stt;
			r1["noidung"]=noidung;
			r1["ghichu"]=ghichu;
			r1["loai"]=1;
			dsct.Tables[0].Rows.Add(r1);
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			string ss01="",ss02="",ss03="",ss04="",ss05="",ss06="",ss07="",ss08="",ss09="",ss10="",ss11="",ss12="",ss13="",ss14="",ss15="",ss16="";
			if (sankhoa.Checked)
			{
				sql="select to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay,b.ten as tenngoithai,b.ma,";
				sql+="decode(a.phai,0,'Nam','Nu') as t_phai,decode(a.tinhtrang,0,'Song','Chet') as t_tinhtrang,";
				sql+="decode(a.ditat,0,'Không','Có') as t_ditat,a.cannang,a.phai,a.tinhtrang,a.ditat,a.id_ss,d.ten as tencachthucde,";
				sql+="c.apgar1,c.apgar5,c.apgar10,c.conthu,c.mass,c.hoten,c.duthang,c.thang,c.tuan,c.manv1,c.manv2,c.cachthucde,c.xuly,";
				sql+="c.cao,c.vongdau,c.ditatbs,e.ten as tenditat,a.ngoithai ";
                sql += " from " + m.user + ".tresosinh a," + m.user + ".dmngoithai b," + m.user + ".ddsosinh c," + m.user + ".dmkieusanh d," + m.user + ".dmditat e ";
                sql += " where a.ngoithai=b.ma and a.id_ss=c.maql and c.cachthucde=d.id and c.ditatbs=e.ma(+) and a.maql=" + l_maql + " order by a.id_ss";
				DataSet dstress=m.get_data(sql);				
				int sothai=dstress.Tables[0].Rows.Count;
				if (sothai>0)
				{
					foreach(DataRow r in dstress.Tables[0].Rows)
					{
						ss01=r["ngay"].ToString();
						ss02=r["apgar1"].ToString();
						ss03=r["apgar5"].ToString();
						ss04=r["apgar10"].ToString();
						ss05=r["cannang"].ToString();
						ss06=r["cao"].ToString();
						ss07=r["vongdau"].ToString();
						if (sothai>1)
						{
							ss10=dstress.Tables[0].Select("phai=0").Length.ToString();
							ss11=dstress.Tables[0].Select("phai=1").Length.ToString();
						}
						else
						{
							ss08=dstress.Tables[0].Select("phai=0").Length.ToString();
							ss09=dstress.Tables[0].Select("phai=1").Length.ToString();
						}
						ss12=r["ditat"].ToString();
						ss14=r["tenditat"].ToString();
						ss15=(r["tinhtrang"].ToString()=="0")?"Sống":"Chết";
						ss16=r["xuly"].ToString();
						break;
					}
				}
			}
			string s_id="",stuoi=m.get_tuoivao(l_maql).Trim();
			foreach(DataRow r1 in ds.Tables[0].Select("chon=true")) s_id+=r1["id"].ToString()+",";
			sql="select a.id,'' as sovaovien,'' as mabn,'' as hoten,'' as tuoi,'' as phai,'' as tenkp,";
			sql+="'' as phong,'' as giuong,'' as chandoan,a.sophieu,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay,";
            sql += "a.dienbien,a.ylenh,b.ten as chedoan,a.mabs,c.hoten as tenbs,g.noidung,g.ghichu ";//,c.image
			if (sankhoa.Checked)
			{
				sql+=",e.bishop,";
				sql+="e.amho,e.amdao,e.sinhmon,e.tucung,e.phanphu,e.tinhtrangoi,to_char(e.voluc,'dd/mm/yyyy hh24:mi') as voluc,e.oivo,e.mausac,";
				sql+="e.nuocoi,e.ngoi,e.the,e.kieu,e.dolot,e.have,to_char(e.deluc,'dd/mm/yyyy hh24:mi') as deluc,f.hoten as theodoi,e.chucdanh,e.rau,";
				sql+="to_char(e.rauluc,'dd/mm/yyyy hh24:mi') as rauluc,e.cachso,e.mang,e.mui,e.banhrau,e.raucannang,e.raucuon,e.raudai,e.chaymau,";
				sql+="e.maumat,e.kiemsoattc,e.xuly,e.da,e.ppde,e.mach as sd_mach,e.nhietdo as sd_nhietdo,e.huyetap as sd_huyetap,e.nhiptho as sd_nhiptho,";
				sql+="e.canthiep,e.tangsinhmon,e.loaichi,e.somui,e.cotucung,";
				sql+="' ' as ss01,' ' as ss02,' ' as ss03,' ' as ss04,' ' as ss05,' ' as ss06,' ' as ss07,' ' as ss08,' ' as ss09,' ' as ss10,' ' as ss11,' ' as ss12,' ' as ss13,' ' as ss14,' ' as ss15,' ' as ss16";
			}
            sql += " from xxx.ba_dieutri a," + user + ".ba_dmchedoan b," + user + ".dmbs c,xxx.ba_thuchien d,xxx.ba_dieutrict g";
            if (sankhoa.Checked) sql += "," + user + m.mmyy(ngayvv.Text) + ".ba_sankhoa e," + user + ".dmbs f ";
			sql+=" where a.id=g.id(+) and a.idthuchien=d.id and a.chedoan=b.id and a.mabs=c.ma and d.idkhoa="+l_idkhoa;
			if (sankhoa.Checked) sql+=" and a.sankhoa=e.id and e.theodoi=f.ma(+)";
			if (s_id!="") sql+=" and a.id in ("+s_id.Substring(0,s_id.Length-1)+")";
			sql+=" order by a.ngay";
			DataSet dsxml=m.get_data_mmyy(sql,ngayvv.Text.Substring(0,10),s_ngayrv.Substring(0,10),false);
			if (chkXML.Checked)
			{
				if (!System.IO.Directory.Exists("..\\xml")) System.IO.Directory.CreateDirectory("..\\xml");
				dsxml.WriteXml("..\\xml\\dieutri.xml",XmlWriteMode.WriteSchema);
			}
			foreach(DataRow r in dsxml.Tables[0].Rows)
			{
				if (sankhoa.Checked)
				{
					r["ss01"]=ss01;r["ss02"]=ss02;r["ss03"]=ss03;r["ss04"]=ss04;r["ss05"]=ss05;r["ss06"]=ss06;r["ss07"]=ss07;r["ss08"]=ss08;
					r["ss09"]=ss09;r["ss10"]=ss10;r["ss11"]=ss11;r["ss12"]=ss12;r["ss13"]=ss13;r["ss14"]=ss14;r["ss15"]=ss15;r["ss16"]=ss16;
				}
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
				dllReportM.frmReport f=new dllReportM.frmReport(m,dsxml,"",(sankhoa.Checked)?"r39bv_BSA.rpt":"r39bv.rpt");
				f.ShowDialog();
			}
            else MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"), LibMedi.AccessData.Msg);
		}

		private void listNv_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab) mabs_Validated(sender,e);
		}

		private void sankhoa_CheckedChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==sankhoa && sankhoa.Checked)
			{
				if (l_id==0)
				{
					mmyy=m.mmyy(ngay.Text);
					if (!m.bMmyy(mmyy)) m.tao_schema(mmyy,i_userid);
					xxx=user+mmyy;
					l_idthuchien=m.get_idthuchien(ngay.Text,l_idkhoa);
					if (l_idthuchien==0) 
					{
						l_idthuchien=m.get_capid(-300);
						m.upd_ba_thuchien(ngay.Text,l_idthuchien,mabn.Text,l_maql,l_idkhoa,s_makp,phong.Text,giuong.Text,chandoan.Text);
					}
					if (l_id==0) l_id=m.get_capid(-302);
                    m.upd_ba_dieutri(mabn.Text, l_id, l_idthuchien, sophieu.Value, ngay.Text + " " + gio.Text, dienbien.Text, ylenh.Text, l_idylenh, (chedoan.SelectedIndex != -1) ? int.Parse(chedoan.SelectedValue.ToString()) : 0, mabs.Text, chon.SelectedIndex, (sankhoa.Checked) ? l_idba : 0, i_userid);
					upd_items();
				}
				frmTTSankhoa f=new frmTTSankhoa(m,dsba,l_idba,l_maql,ngayvv.Text,i_userid,l_id,bAdmin,sovaovien.Text,hoten.Text,phai.Text,s_tenkp,phong.Text,giuong.Text,chandoan.Text);
				f.ShowDialog();
				bUpdate=f.bUpdate;
			}
		}

		private void dataGrid2_CurrentCellChanged(object sender, System.EventArgs e)
		{
			ref_text1();
		}

		private void ref_text1()
		{
			try
			{
				int i_row=dataGrid2.CurrentCell.RowNumber;
				stt.Value=decimal.Parse(dataGrid2[i_row,0].ToString());
				noidung.Text=dataGrid2[i_row,1].ToString();
				ghichu.Text=dataGrid2[i_row,2].ToString();
				thuchien.Text=dataGrid2[i_row,3].ToString();
				loai.SelectedValue=dataGrid2[i_row,4].ToString();
			}
			catch{}
		}

		private void upd_loai()
		{
			if (noidung.Text!="")
			{
				DataRow r=m.getrowbyid(dsct.Tables[0],"stt="+stt.Value),r1;
				if (r==null)
				{
					r1=dsct.Tables[0].NewRow();
					r1["stt"]=stt.Value;
					r1["noidung"]=noidung.Text;
					r1["ghichu"]=ghichu.Text;
					r1["loai"]=int.Parse(loai.SelectedValue.ToString());
					dsct.Tables[0].Rows.Add(r1);
				}
				else
				{
					DataRow [] dr=dsct.Tables[0].Select("stt="+stt.Value);
					if (dr.Length>0)
					{
						dr[0]["noidung"]=noidung.Text;
						dr[0]["ghichu"]=ghichu.Text;
						dr[0]["loai"]=int.Parse(loai.SelectedValue.ToString());
					}
				}
			}
		}

		private void butTiep_Click(object sender, System.EventArgs e)
		{
			upd_loai();
			try
			{
				stt.Value=decimal.Parse(dsct.Tables[0].Rows[dsct.Tables[0].Rows.Count-1]["stt"].ToString())+1;
			}
			catch{stt.Value=1;}
			noidung.Text="";ghichu.Text="";thuchien.Text="";
			loai.Focus();
		}

		private void butXoa_Click(object sender, System.EventArgs e)
		{
            //Tu:20/05/2011
			//if (dsct.Tables[0].Rows.Count==0  || loai.SelectedValue.ToString()=="1") return;
            //end Tu
			if (thuchien.Text!="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Y lệnh đã thực hiện !"),LibMedi.AccessData.Msg);
				return;
			}
			if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý hủy thông tin này ?"),LibMedi.AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
			{
				m.delrec(dsct.Tables[0],"stt="+stt.Value);
				ref_text1();
                dsct.AcceptChanges();
			}
		}

		private void butPhong_Click(object sender, System.EventArgs e)
		{
            if (m.get_data("select * from " + m.user + ".theodoigiuong where mabn='" + mabn.Text + "' and makp='" + s_makp + "' and den is null").Tables[0].Rows.Count > 0)
			{
				MessageBox.Show(lan.Change_language_MessageText("Đã chọn phòng/giường")+"\n"+"Nếu muốn chuyển phòng/giường thì chọn phần chuyển phòng giường !",LibMedi.AccessData.Msg);
				return;
			}
			frmDsgiuong f=new frmDsgiuong(m,s_makp,madoituong,false);
			f.ShowDialog();
			if (f.ma!="") giuong.Text=f.ma;
			butLuu.Focus();		
		}
	}
}
