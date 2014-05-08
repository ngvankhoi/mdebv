using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Data;
using LibMedi;
using LibDuoc;

namespace Medisoft
{
	/// <summary>
	/// Summary description for frmGiaonhan.
	/// </summary>
	public class frmGiaonhan : System.Windows.Forms.Form
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
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label88;
		private System.Windows.Forms.Label label90;
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
		private DataSet dsct=new DataSet();
		private DataTable dtnv=new DataTable(); 
		private LibMedi.AccessData m;
		private LibDuoc.AccessData d=new LibDuoc.AccessData();
		private int i_userid;
		private string s_makp,user,xxx,s_ngayrv,sql,s_mabs,mmyy,s_nhomkho,s_userid,s_tenkp;
		private decimal l_id,l_idthuchien,l_idkhoa,l_maql,l_idchung;
		private LibList.List listNv;
		private Brush disabledBackBrush;
		private Brush disabledTextBrush;
		private Brush alertBackBrush;
		private Font alertFont;
		private Brush alertTextBrush;
		private Font currentRowFont;
		private Brush currentRowBackBrush;
		private bool afterCurrentCellChanged=true;
		private int checkCol=0;
		private System.Windows.Forms.NumericUpDown stt;
		private MaskedBox.MaskedBox nhietdo;
		private MaskedTextBox.MaskedTextBox huyetap;
		private MaskedTextBox.MaskedTextBox nhiptho;
		private MaskedTextBox.MaskedTextBox cannang;
		private MaskedTextBox.MaskedTextBox mach;
		private System.Windows.Forms.Label label39;
		private System.Windows.Forms.Label label40;
		private System.Windows.Forms.Label label41;
		private System.Windows.Forms.Label label42;
		private System.Windows.Forms.Label label43;
		private System.Windows.Forms.Label label44;
		private System.Windows.Forms.Label label45;
		private System.Windows.Forms.Label label46;
		private System.Windows.Forms.Label label47;
		private System.Windows.Forms.Label label48;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.TextBox trigiac;
		private MaskedTextBox.MaskedTextBox spo2;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.TextBox camtay;
		private System.Windows.Forms.DataGrid dataGrid2;
		private MaskedTextBox.MaskedTextBox soluong;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.TextBox loai;
		private System.Windows.Forms.Button butTiep;
		private System.Windows.Forms.CheckBox chkXML;
		private System.Windows.Forms.Button butScan;
		private System.Windows.Forms.Button butXoa;

		public frmGiaonhan(LibMedi.AccessData acc,string _mabn,decimal _maql,decimal _idkhoa,decimal _idthuchien,decimal _id,string _sovaovien,string _makp,string _hoten,string _namsinh,string _phai,string _diachi,string _ngayvv,string _sothe,string _phong,string _giuong,string _ngayrv,string _mabs,int _userid,string _nhomkho,string suserid,string _chandoan,string _tenkp)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			m=acc;mabn.Text=_mabn;l_maql=_maql;l_idkhoa=_idkhoa;l_idthuchien=_idthuchien;l_idchung=_id;sovaovien.Text=_sovaovien;i_userid=_userid;s_tenkp=_tenkp;
			hoten.Text=_hoten;chandoan.Text=_chandoan;s_makp=_makp;namsinh.Text=_namsinh;phai.Text=_phai;diachi.Text=_diachi;s_mabs=_mabs;s_nhomkho=_nhomkho;
			ngayvv.Text=_ngayvv;sothe.Text=_sothe;phong.Text=_phong;giuong.Text=_giuong;s_ngayrv=_ngayrv;s_userid=suserid;
            
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGiaonhan));
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
            this.stt = new System.Windows.Forms.NumericUpDown();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.butMoi = new System.Windows.Forms.Button();
            this.butSua = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butHuy = new System.Windows.Forms.Button();
            this.butIn = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.butScan = new System.Windows.Forms.Button();
            this.listNv = new LibList.List();
            this.nhietdo = new MaskedBox.MaskedBox();
            this.huyetap = new MaskedTextBox.MaskedTextBox();
            this.nhiptho = new MaskedTextBox.MaskedTextBox();
            this.cannang = new MaskedTextBox.MaskedTextBox();
            this.mach = new MaskedTextBox.MaskedTextBox();
            this.label39 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.trigiac = new System.Windows.Forms.TextBox();
            this.spo2 = new MaskedTextBox.MaskedTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.camtay = new System.Windows.Forms.TextBox();
            this.dataGrid2 = new System.Windows.Forms.DataGrid();
            this.soluong = new MaskedTextBox.MaskedTextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.loai = new System.Windows.Forms.TextBox();
            this.butTiep = new System.Windows.Forms.Button();
            this.butXoa = new System.Windows.Forms.Button();
            this.chkXML = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.stt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
            this.SuspendLayout();
            // 
            // chandoan
            // 
            this.chandoan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.chandoan.Enabled = false;
            this.chandoan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chandoan.Location = new System.Drawing.Point(75, 94);
            this.chandoan.Name = "chandoan";
            this.chandoan.Size = new System.Drawing.Size(56, 21);
            this.chandoan.TabIndex = 71;
            // 
            // sothe
            // 
            this.sothe.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sothe.Enabled = false;
            this.sothe.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sothe.Location = new System.Drawing.Point(75, 94);
            this.sothe.Name = "sothe";
            this.sothe.Size = new System.Drawing.Size(56, 21);
            this.sothe.TabIndex = 63;
            // 
            // giuong
            // 
            this.giuong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.giuong.Enabled = false;
            this.giuong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.giuong.Location = new System.Drawing.Point(75, 94);
            this.giuong.Name = "giuong";
            this.giuong.Size = new System.Drawing.Size(56, 21);
            this.giuong.TabIndex = 70;
            // 
            // phong
            // 
            this.phong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.phong.Enabled = false;
            this.phong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phong.Location = new System.Drawing.Point(75, 94);
            this.phong.Name = "phong";
            this.phong.Size = new System.Drawing.Size(56, 21);
            this.phong.TabIndex = 69;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(75, 94);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 16);
            this.label13.TabIndex = 68;
            this.label13.Text = "Chẩn đoán :";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(75, 94);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 16);
            this.label12.TabIndex = 67;
            this.label12.Text = "Giường :";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(75, 94);
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
            this.ngayvv.Location = new System.Drawing.Point(75, 94);
            this.ngayvv.Name = "ngayvv";
            this.ngayvv.Size = new System.Drawing.Size(56, 21);
            this.ngayvv.TabIndex = 65;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(75, 94);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 16);
            this.label7.TabIndex = 64;
            this.label7.Text = "Ngày :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(75, 94);
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
            this.diachi.Location = new System.Drawing.Point(75, 94);
            this.diachi.Name = "diachi";
            this.diachi.Size = new System.Drawing.Size(56, 21);
            this.diachi.TabIndex = 61;
            // 
            // phai
            // 
            this.phai.BackColor = System.Drawing.SystemColors.HighlightText;
            this.phai.Enabled = false;
            this.phai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phai.Location = new System.Drawing.Point(75, 94);
            this.phai.Name = "phai";
            this.phai.Size = new System.Drawing.Size(56, 21);
            this.phai.TabIndex = 60;
            // 
            // namsinh
            // 
            this.namsinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.namsinh.Enabled = false;
            this.namsinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namsinh.Location = new System.Drawing.Point(75, 94);
            this.namsinh.Name = "namsinh";
            this.namsinh.Size = new System.Drawing.Size(56, 21);
            this.namsinh.TabIndex = 59;
            // 
            // hoten
            // 
            this.hoten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.hoten.Enabled = false;
            this.hoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoten.Location = new System.Drawing.Point(75, 94);
            this.hoten.Name = "hoten";
            this.hoten.Size = new System.Drawing.Size(56, 21);
            this.hoten.TabIndex = 58;
            // 
            // mabn
            // 
            this.mabn.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabn.Enabled = false;
            this.mabn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabn.Location = new System.Drawing.Point(75, 94);
            this.mabn.Name = "mabn";
            this.mabn.Size = new System.Drawing.Size(56, 21);
            this.mabn.TabIndex = 52;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(75, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 16);
            this.label5.TabIndex = 57;
            this.label5.Text = "Địa chỉ :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(75, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 16);
            this.label4.TabIndex = 56;
            this.label4.Text = "Giới tính :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(75, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 16);
            this.label3.TabIndex = 55;
            this.label3.Text = "NS :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(75, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 54;
            this.label1.Text = "Họ tên :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(75, 94);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 16);
            this.label10.TabIndex = 53;
            this.label10.Text = "Mã BN :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(75, 94);
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
            this.sovaovien.Location = new System.Drawing.Point(75, 94);
            this.sovaovien.Name = "sovaovien";
            this.sovaovien.Size = new System.Drawing.Size(56, 21);
            this.sovaovien.TabIndex = 73;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(281, 300);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 16);
            this.label8.TabIndex = 74;
            this.label8.Text = "Số lượng :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gio
            // 
            this.gio.BackColor = System.Drawing.SystemColors.HighlightText;
            this.gio.Enabled = false;
            this.gio.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gio.Location = new System.Drawing.Point(462, 7);
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
            this.ngay.Location = new System.Drawing.Point(355, 7);
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
            this.label88.Location = new System.Drawing.Point(430, 9);
            this.label88.Name = "label88";
            this.label88.Size = new System.Drawing.Size(32, 16);
            this.label88.TabIndex = 302;
            this.label88.Text = "Giờ :";
            this.label88.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label90
            // 
            this.label90.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label90.Location = new System.Drawing.Point(315, 9);
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
            this.tenbs.Location = new System.Drawing.Point(459, 466);
            this.tenbs.Name = "tenbs";
            this.tenbs.Size = new System.Drawing.Size(326, 21);
            this.tenbs.TabIndex = 15;
            this.tenbs.TextChanged += new System.EventHandler(this.tenbs_TextChanged);
            this.tenbs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbs_KeyDown);
            // 
            // mabs
            // 
            this.mabs.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mabs.Enabled = false;
            this.mabs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabs.Location = new System.Drawing.Point(416, 466);
            this.mabs.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.mabs.MaxLength = 9;
            this.mabs.Name = "mabs";
            this.mabs.Size = new System.Drawing.Size(41, 21);
            this.mabs.TabIndex = 14;
            this.mabs.Validated += new System.EventHandler(this.mabs_Validated);
            this.mabs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // label87
            // 
            this.label87.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label87.Location = new System.Drawing.Point(307, 469);
            this.label87.Name = "label87";
            this.label87.Size = new System.Drawing.Size(104, 16);
            this.label87.TabIndex = 300;
            this.label87.Text = "Ý tá (điều dưỡng) :";
            this.label87.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // stt
            // 
            this.stt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.stt.Enabled = false;
            this.stt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stt.Location = new System.Drawing.Point(168, 416);
            this.stt.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.stt.Name = "stt";
            this.stt.Size = new System.Drawing.Size(40, 21);
            this.stt.TabIndex = 0;
            this.stt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
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
            this.dataGrid1.Location = new System.Drawing.Point(6, -12);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(274, 500);
            this.dataGrid1.TabIndex = 310;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            this.dataGrid1.Click += new System.EventHandler(this.dataGrid1_Click);
            // 
            // butMoi
            // 
            this.butMoi.Location = new System.Drawing.Point(174, 496);
            this.butMoi.Name = "butMoi";
            this.butMoi.Size = new System.Drawing.Size(70, 25);
            this.butMoi.TabIndex = 18;
            this.butMoi.Text = "&Mới";
            this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
            // 
            // butSua
            // 
            this.butSua.Location = new System.Drawing.Point(244, 496);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(70, 25);
            this.butSua.TabIndex = 19;
            this.butSua.Text = "&Sữa";
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butLuu
            // 
            this.butLuu.Enabled = false;
            this.butLuu.Location = new System.Drawing.Point(314, 496);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 16;
            this.butLuu.Text = "&Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Enabled = false;
            this.butBoqua.Location = new System.Drawing.Point(384, 496);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(70, 25);
            this.butBoqua.TabIndex = 17;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butHuy
            // 
            this.butHuy.Location = new System.Drawing.Point(454, 496);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(70, 25);
            this.butHuy.TabIndex = 20;
            this.butHuy.Text = "&Hủy";
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // butIn
            // 
            this.butIn.Location = new System.Drawing.Point(524, 496);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 21;
            this.butIn.Text = "&In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Location = new System.Drawing.Point(594, 496);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 22;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // butScan
            // 
            this.butScan.Enabled = false;
            this.butScan.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butScan.Location = new System.Drawing.Point(787, 466);
            this.butScan.Name = "butScan";
            this.butScan.Size = new System.Drawing.Size(22, 21);
            this.butScan.TabIndex = 325;
            this.butScan.Text = "...";
            this.toolTip1.SetToolTip(this.butScan, "Các kết quả bằng tập tin");
            this.butScan.Click += new System.EventHandler(this.butScan_Click);
            // 
            // listNv
            // 
            this.listNv.BackColor = System.Drawing.SystemColors.Info;
            this.listNv.ColumnCount = 0;
            this.listNv.Location = new System.Drawing.Point(688, 536);
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
            // nhietdo
            // 
            this.nhietdo.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nhietdo.Enabled = false;
            this.nhietdo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhietdo.Location = new System.Drawing.Point(535, 31);
            this.nhietdo.Mask = "##.##";
            this.nhietdo.Name = "nhietdo";
            this.nhietdo.Size = new System.Drawing.Size(40, 21);
            this.nhietdo.TabIndex = 4;
            this.nhietdo.Text = "  .  ";
            // 
            // huyetap
            // 
            this.huyetap.BackColor = System.Drawing.SystemColors.HighlightText;
            this.huyetap.Enabled = false;
            this.huyetap.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.huyetap.Location = new System.Drawing.Point(691, 31);
            this.huyetap.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.huyetap.MaxLength = 7;
            this.huyetap.Name = "huyetap";
            this.huyetap.Size = new System.Drawing.Size(48, 21);
            this.huyetap.TabIndex = 5;
            // 
            // nhiptho
            // 
            this.nhiptho.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nhiptho.Enabled = false;
            this.nhiptho.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhiptho.Location = new System.Drawing.Point(355, 55);
            this.nhiptho.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.nhiptho.MaxLength = 5;
            this.nhiptho.Name = "nhiptho";
            this.nhiptho.Size = new System.Drawing.Size(32, 21);
            this.nhiptho.TabIndex = 6;
            this.nhiptho.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cannang
            // 
            this.cannang.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cannang.Enabled = false;
            this.cannang.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cannang.Location = new System.Drawing.Point(535, 55);
            this.cannang.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.cannang.MaxLength = 7;
            this.cannang.Name = "cannang";
            this.cannang.Size = new System.Drawing.Size(40, 21);
            this.cannang.TabIndex = 7;
            this.cannang.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // mach
            // 
            this.mach.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mach.Enabled = false;
            this.mach.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mach.Location = new System.Drawing.Point(355, 31);
            this.mach.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.mach.MaxLength = 5;
            this.mach.Name = "mach";
            this.mach.Size = new System.Drawing.Size(32, 21);
            this.mach.TabIndex = 3;
            this.mach.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label39
            // 
            this.label39.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label39.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label39.Location = new System.Drawing.Point(392, 34);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(48, 19);
            this.label39.TabIndex = 11;
            this.label39.Text = "lần/phút";
            this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label40
            // 
            this.label40.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label40.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label40.Location = new System.Drawing.Point(583, 34);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(24, 16);
            this.label40.TabIndex = 13;
            this.label40.Text = "°C";
            this.label40.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label41
            // 
            this.label41.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label41.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label41.Location = new System.Drawing.Point(747, 34);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(38, 16);
            this.label41.TabIndex = 16;
            this.label41.Text = "mmHg";
            this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label42
            // 
            this.label42.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label42.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label42.Location = new System.Drawing.Point(395, 60);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(48, 16);
            this.label42.TabIndex = 18;
            this.label42.Text = "lần/phút";
            this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label43
            // 
            this.label43.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label43.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label43.Location = new System.Drawing.Point(583, 60);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(32, 16);
            this.label43.TabIndex = 19;
            this.label43.Text = "Kg";
            this.label43.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label44
            // 
            this.label44.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label44.Location = new System.Drawing.Point(471, 60);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(64, 16);
            this.label44.TabIndex = 7;
            this.label44.Text = "Cân nặng :";
            this.label44.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label45
            // 
            this.label45.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label45.Location = new System.Drawing.Point(299, 60);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(56, 16);
            this.label45.TabIndex = 6;
            this.label45.Text = "Nhịp thở :";
            this.label45.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label46
            // 
            this.label46.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label46.Location = new System.Drawing.Point(627, 34);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(64, 16);
            this.label46.TabIndex = 5;
            this.label46.Text = "Huyết áp :";
            this.label46.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label47
            // 
            this.label47.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label47.Location = new System.Drawing.Point(479, 34);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(56, 16);
            this.label47.TabIndex = 4;
            this.label47.Text = "Nhiệt độ :";
            this.label47.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label48
            // 
            this.label48.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label48.Location = new System.Drawing.Point(315, 34);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(40, 16);
            this.label48.TabIndex = 3;
            this.label48.Text = "Mạch :";
            this.label48.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(499, 9);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(56, 16);
            this.label15.TabIndex = 313;
            this.label15.Text = "Tri giác :";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // trigiac
            // 
            this.trigiac.BackColor = System.Drawing.SystemColors.HighlightText;
            this.trigiac.Enabled = false;
            this.trigiac.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trigiac.Location = new System.Drawing.Point(555, 7);
            this.trigiac.Name = "trigiac";
            this.trigiac.Size = new System.Drawing.Size(254, 21);
            this.trigiac.TabIndex = 2;
            this.trigiac.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // spo2
            // 
            this.spo2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.spo2.Enabled = false;
            this.spo2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spo2.Location = new System.Drawing.Point(691, 55);
            this.spo2.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.spo2.MaxLength = 7;
            this.spo2.Name = "spo2";
            this.spo2.Size = new System.Drawing.Size(48, 21);
            this.spo2.TabIndex = 8;
            this.spo2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(649, 58);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 16);
            this.label9.TabIndex = 316;
            this.label9.Text = "SpO   :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(678, 63);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(8, 14);
            this.label14.TabIndex = 317;
            this.label14.Text = "2";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label16.Location = new System.Drawing.Point(747, 55);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(38, 16);
            this.label16.TabIndex = 318;
            this.label16.Text = "%";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(276, 323);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(135, 16);
            this.label17.TabIndex = 319;
            this.label17.Text = "Số kết quả CLS cầm tay :";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // camtay
            // 
            this.camtay.BackColor = System.Drawing.SystemColors.HighlightText;
            this.camtay.Enabled = false;
            this.camtay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.camtay.Location = new System.Drawing.Point(416, 321);
            this.camtay.Multiline = true;
            this.camtay.Name = "camtay";
            this.camtay.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.camtay.Size = new System.Drawing.Size(393, 144);
            this.camtay.TabIndex = 13;
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
            this.dataGrid2.Location = new System.Drawing.Point(296, 63);
            this.dataGrid2.Name = "dataGrid2";
            this.dataGrid2.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid2.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid2.ReadOnly = true;
            this.dataGrid2.RowHeaderWidth = 10;
            this.dataGrid2.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid2.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid2.Size = new System.Drawing.Size(513, 233);
            this.dataGrid2.TabIndex = 321;
            this.dataGrid2.CurrentCellChanged += new System.EventHandler(this.dataGrid2_CurrentCellChanged);
            // 
            // soluong
            // 
            this.soluong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.soluong.Enabled = false;
            this.soluong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.soluong.Location = new System.Drawing.Point(337, 298);
            this.soluong.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.soluong.MaxLength = 7;
            this.soluong.Name = "soluong";
            this.soluong.Size = new System.Drawing.Size(48, 21);
            this.soluong.TabIndex = 9;
            this.soluong.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(383, 299);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(40, 18);
            this.label18.TabIndex = 323;
            this.label18.Text = "Loại :";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // loai
            // 
            this.loai.BackColor = System.Drawing.SystemColors.HighlightText;
            this.loai.Enabled = false;
            this.loai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loai.Location = new System.Drawing.Point(416, 298);
            this.loai.Name = "loai";
            this.loai.Size = new System.Drawing.Size(308, 21);
            this.loai.TabIndex = 10;
            this.loai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // butTiep
            // 
            this.butTiep.Enabled = false;
            this.butTiep.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butTiep.Location = new System.Drawing.Point(726, 298);
            this.butTiep.Name = "butTiep";
            this.butTiep.Size = new System.Drawing.Size(40, 21);
            this.butTiep.TabIndex = 11;
            this.butTiep.Text = "&Tiếp";
            this.butTiep.Click += new System.EventHandler(this.butTiep_Click);
            // 
            // butXoa
            // 
            this.butXoa.Enabled = false;
            this.butXoa.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butXoa.Location = new System.Drawing.Point(769, 298);
            this.butXoa.Name = "butXoa";
            this.butXoa.Size = new System.Drawing.Size(40, 21);
            this.butXoa.TabIndex = 12;
            this.butXoa.Text = "&Xóa";
            this.butXoa.Click += new System.EventHandler(this.butXoa_Click);
            // 
            // chkXML
            // 
            this.chkXML.Location = new System.Drawing.Point(696, 488);
            this.chkXML.Name = "chkXML";
            this.chkXML.Size = new System.Drawing.Size(88, 24);
            this.chkXML.TabIndex = 324;
            this.chkXML.Text = "Xuất ra XML";
            // 
            // frmGiaonhan
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(829, 579);
            this.Controls.Add(this.butScan);
            this.Controls.Add(this.chkXML);
            this.Controls.Add(this.butXoa);
            this.Controls.Add(this.butTiep);
            this.Controls.Add(this.gio);
            this.Controls.Add(this.loai);
            this.Controls.Add(this.soluong);
            this.Controls.Add(this.camtay);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.spo2);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.trigiac);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.listNv);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.butHuy);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butSua);
            this.Controls.Add(this.butMoi);
            this.Controls.Add(this.ngay);
            this.Controls.Add(this.label88);
            this.Controls.Add(this.label90);
            this.Controls.Add(this.tenbs);
            this.Controls.Add(this.mabs);
            this.Controls.Add(this.label87);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label48);
            this.Controls.Add(this.mach);
            this.Controls.Add(this.label39);
            this.Controls.Add(this.label47);
            this.Controls.Add(this.nhietdo);
            this.Controls.Add(this.label40);
            this.Controls.Add(this.label46);
            this.Controls.Add(this.huyetap);
            this.Controls.Add(this.label41);
            this.Controls.Add(this.label45);
            this.Controls.Add(this.nhiptho);
            this.Controls.Add(this.label42);
            this.Controls.Add(this.label44);
            this.Controls.Add(this.cannang);
            this.Controls.Add(this.label43);
            this.Controls.Add(this.dataGrid2);
            this.Controls.Add(this.stt);
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
            this.Controls.Add(this.label18);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmGiaonhan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phiếu giao nhận";
            this.Load += new System.EventHandler(this.frmGiaonhan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.stt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmGiaonhan_Load(object sender, System.EventArgs e)
		{
            this.Location = new System.Drawing.Point(188, 151);
			user=m.user;
            dtnv = m.get_data("select ma,hoten,nhom from " + user + ".dmbs where nhom<>" + LibMedi.AccessData.nghiviec + " and nhom=" + LibMedi.AccessData.nhanvien + " order by hoten").Tables[0];
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
			if (r!=null) tenbs.Text=r["hoten"].ToString();
			else tenbs.Text="";	
		}

		private void tenbs_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tenbs)
			{
				Filt_dmbs(tenbs.Text);
				listNv.BrowseToDanhmuc(tenbs,mabs,butLuu,35);
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
			sql="select a.id,a.idthuchien,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay,a.trigiac,a.mach,a.nhietdo,a.huyetap,a.nhiptho,a.cannang,a.spo2,a.camtay,";
			sql+="a.yta,c.hoten as tenyta from xxx.ba_giaonhan a,xxx.ba_thuchien b,"+user+".dmbs c where a.idthuchien=b.id and a.yta=c.ma and b.idkhoa="+l_idkhoa;
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
			TextCol.Width = 30;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "soluong";
			TextCol.HeaderText = "Số lượng";
			TextCol.Format="### ### ##0";
			TextCol.Width = 50;
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid2.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "loai";
			TextCol.HeaderText = "Loại";
			TextCol.Width = 380;
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
			TextCol1.MappingName = "ngay";
			TextCol1.HeaderText = "Ngày";
			TextCol1.Width =100;
			TextCol1.ReadOnly=true;
			TextCol1.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new FormattableTextBoxColumn();
			TextCol1.MappingName = "tenyta";
			TextCol1.HeaderText = "Y tá (điều dưỡng)";
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
				if (this.dataGrid1[e.Row,8].ToString().Trim()=="1" || this.dataGrid1[e.Row,9].ToString().Trim()=="1")
					e.ForeBrush=this.disabledTextBrush;
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
			catch
			{
				l_id=0;
				sql="select * from xxx.ba_giaonhanct where id="+l_id+" order by stt";
				dsct=m.get_data_mmyy(sql,ngayvv.Text.Substring(0,10),s_ngayrv.Substring(0,10),false);
				dataGrid2.DataSource=dsct.Tables[0];
				ref_text1();
			}
		}

		private void ref_text1()
		{
			try
			{
				int i_row=dataGrid2.CurrentCell.RowNumber;
				stt.Value=decimal.Parse(dataGrid2[i_row,0].ToString());
				soluong.Text=dataGrid2[i_row,1].ToString();
				loai.Text=dataGrid2[i_row,2].ToString();
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
				mabs.Text=r["yta"].ToString();
				DataRow r1=m.getrowbyid(dtnv,"ma='"+mabs.Text+"'");
				if (r!=null) tenbs.Text=r1["hoten"].ToString();
				else tenbs.Text="";
				trigiac.Text=r["trigiac"].ToString();
				mach.Text=(r["mach"].ToString()!="0")?r["mach"].ToString():"";
				nhietdo.Text=(r["nhietdo"].ToString()!="0")?r["nhietdo"].ToString():"";
				huyetap.Text=r["huyetap"].ToString();
				nhiptho.Text=(r["nhiptho"].ToString()!="0")?r["nhiptho"].ToString():"";
				cannang.Text=(r["cannang"].ToString()!="0")?r["cannang"].ToString():"";
				spo2.Text=r["spo2"].ToString();
				camtay.Text=r["camtay"].ToString();
			}
			sql="select * from xxx.ba_giaonhanct where id="+id+" order by stt";
			dsct=m.get_data_mmyy(sql,ngayvv.Text.Substring(0,10),s_ngayrv.Substring(0,10),false);
			dataGrid2.DataSource=dsct.Tables[0];
			ref_text1();
		}

		private void emp_text()
		{
			l_id=0;
			string _ngay=m.ngayhienhanh_server;
			ngay.Text=_ngay.Substring(0,10);
			gio.Text=_ngay.Substring(11);dsct.Clear();
			mabs.Text="";tenbs.Text="";trigiac.Text="";spo2.Text="";camtay.Text="";
			mach.Text="";nhietdo.Text="";huyetap.Text="";nhiptho.Text="";cannang.Text="";
			stt.Value=1;soluong.Text="";loai.Text="";
			if (ds.Tables[0].Rows.Count==0)
			{
				decimal id=m.get_idchung(ngayvv.Text,l_idthuchien);
				foreach(DataRow r in m.get_data("select * from "+user+m.mmyy(ngayvv.Text)+".ba_kbdausinhton where id="+id).Tables[0].Rows)
				{
					mach.Text=(r["mach"].ToString()!="0")?r["mach"].ToString():"";
					nhietdo.Text=(r["nhietdo"].ToString()!="0")?r["nhietdo"].ToString():"";
					huyetap.Text=r["huyetap"].ToString();
					nhiptho.Text=(r["nhiptho"].ToString()!="0")?r["nhiptho"].ToString():"";
					cannang.Text=(r["cannang"].ToString()!="0")?r["cannang"].ToString():"";
					break;
				}
			}
		}

		private void ena_object(bool ena)
		{
			ngay.Enabled=ena;
			gio.Enabled=ena;
			trigiac.Enabled=ena;
			mach.Enabled=ena;
			nhietdo.Enabled=ena;
			huyetap.Enabled=ena;
			nhiptho.Enabled=ena;
			cannang.Enabled=ena;
			spo2.Enabled=ena;
			camtay.Enabled=ena;
			mabs.Enabled=ena;
			tenbs.Enabled=ena;
			soluong.Enabled=ena;
			loai.Enabled=ena;
			butLuu.Enabled=ena;
			butBoqua.Enabled=ena;
			butTiep.Enabled=ena;
			butXoa.Enabled=ena;
			butMoi.Enabled=!ena;
			butSua.Enabled=!ena;
			butIn.Enabled=!ena;
			butHuy.Enabled=!ena;
			butKetthuc.Enabled=!ena;
			butScan.Enabled=ena;
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
				m.execute_data("delete from "+xxx+".ba_giaonhanct where id="+l_id);
				m.execute_data("delete from "+xxx+".ba_giaonhan where id="+l_id);
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
			if (mabs.Text=="" || tenbs.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập Y tá (điều dưỡng) !"),LibMedi.AccessData.Msg);
				if (mabs.Text=="") mabs.Focus();
				else tenbs.Focus();
				return false;
			}
			return true;
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			if (!kiemtra()) return;
			upd_loai();
			mmyy=m.mmyy(ngay.Text);
            if (!m.bMmyy(mmyy)) m.tao_schema(mmyy, i_userid);
			xxx=user+mmyy;
			l_idthuchien=m.get_idthuchien(ngay.Text,l_idkhoa);
			if (l_idthuchien==0) 
			{
				l_idthuchien=m.get_capid(-300);
				m.upd_ba_thuchien(ngay.Text,l_idthuchien,mabn.Text,l_maql,l_idkhoa,s_makp,phong.Text,giuong.Text,chandoan.Text);
			}
			if (l_id==0) l_id=m.get_capid(-304);
			else m.execute_data("delete from "+xxx+".ba_giaonhanct where id="+l_id);
            m.upd_ba_giaonhan(mabn.Text, l_id, l_idthuchien, ngay.Text + " " + gio.Text, trigiac.Text, (mach.Text != "") ? decimal.Parse(mach.Text) : 0, (nhietdo.Text != "") ? decimal.Parse(nhietdo.Text) : 0, huyetap.Text, (nhiptho.Text != "") ? decimal.Parse(nhiptho.Text) : 0, (cannang.Text != "") ? decimal.Parse(cannang.Text) : 0, (spo2.Text != "") ? decimal.Parse(spo2.Text) : 0, camtay.Text, mabs.Text, i_userid);
			foreach(DataRow r in dsct.Tables[0].Rows) m.upd_ba_giaonhanct(ngay.Text+" "+gio.Text,l_id,decimal.Parse(r["stt"].ToString()),decimal.Parse(r["soluong"].ToString()),r["loai"].ToString());
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
				r2["trigiac"]=trigiac.Text;
				r2["mach"]=(mach.Text!="")?decimal.Parse(mach.Text):0;
				r2["nhietdo"]=(nhietdo.Text!="")?decimal.Parse(nhietdo.Text):0;
				r2["huyetap"]=huyetap.Text;
				r2["nhiptho"]=(nhiptho.Text!="")?decimal.Parse(nhiptho.Text):0;
				r2["cannang"]=(cannang.Text!="")?decimal.Parse(cannang.Text):0;
				r2["spo2"]=(spo2.Text!="")?decimal.Parse(spo2.Text):0;
				r2["camtay"]=camtay.Text;
				r2["yta"]=mabs.Text;
				r2["tenyta"]=tenbs.Text;
				r2["chon"]=true;
				ds.Tables[0].Rows.Add(r2);
			}
			else
			{
				DataRow [] dr=ds.Tables[0].Select("id="+l_id);
				dr[0]["idthuchien"]=l_idthuchien;
				dr[0]["ngay"]=ngay.Text+" "+gio.Text;
				dr[0]["trigiac"]=trigiac.Text;
				dr[0]["mach"]=(mach.Text!="")?decimal.Parse(mach.Text):0;
				dr[0]["nhietdo"]=(nhietdo.Text!="")?decimal.Parse(nhietdo.Text):0;
				dr[0]["huyetap"]=huyetap.Text;
				dr[0]["nhiptho"]=(nhiptho.Text!="")?decimal.Parse(nhiptho.Text):0;
				dr[0]["cannang"]=(cannang.Text!="")?decimal.Parse(cannang.Text):0;
				dr[0]["spo2"]=(spo2.Text!="")?decimal.Parse(spo2.Text):0;
				dr[0]["camtay"]=camtay.Text;
				dr[0]["yta"]=mabs.Text;
				dr[0]["tenyta"]=tenbs.Text;
			}
		}

        private void butIn_Click(object sender, System.EventArgs e)
        {
            string s_id = "", stuoi = m.get_tuoivao(l_maql).Trim();
            foreach (DataRow r1 in ds.Tables[0].Select("chon=true")) s_id += r1["id"].ToString() + ",";
            sql = "select '' as sovaovien,'' as mabn,'' as hoten,'' as tuoi,'' as phai,'' as tenkp,";
            sql += "'' as phong,'' as giuong,'' as chandoan,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay,";
            sql += "a.trigiac,a.mach,a.nhietdo,a.huyetap,a.nhiptho,a.cannang,a.spo2,a.camtay,a.yta,c.hoten as tenyta,c.image,";
            sql += "e.soluong,e.loai";
            sql += " from xxx.ba_giaonhan a inner join xxx.ba_thuchien d on a.idthuchien=d.id left join xxx.ba_giaonhanct e on a.id=e.id";
            sql += " left join " + user + ".dmbs c on a.yta=c.ma";
            sql += " where d.idkhoa=" + l_idkhoa;
            if (s_id != "") sql += " and a.id in (" + s_id.Substring(0, s_id.Length - 1) + ")";
            DataSet dsxml = m.get_data_mmyy(sql, ngayvv.Text.Substring(0, 10), s_ngayrv.Substring(0, 10), false);
            if (chkXML.Checked)
            {
                if (!System.IO.Directory.Exists("..\\xml")) System.IO.Directory.CreateDirectory("..\\xml");
                dsxml.WriteXml("..\\xml\\giaonhan.xml", XmlWriteMode.WriteSchema);
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
                dllReportM.frmReport f = new dllReportM.frmReport(m, dsxml, "", "r091bv.rpt");
                f.ShowDialog();
            }
            else MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"), LibMedi.AccessData.Msg);
        }

		private void upd_loai()
		{
			if (soluong.Text!="" && soluong.Text!="0" && loai.Text!="")
			{
				DataRow r=m.getrowbyid(dsct.Tables[0],"stt="+stt.Value),r1;
				if (r==null)
				{
					r1=dsct.Tables[0].NewRow();
					r1["stt"]=stt.Value;
					r1["soluong"]=soluong.Text;
					r1["loai"]=loai.Text;
					dsct.Tables[0].Rows.Add(r1);
				}
				else
				{
					DataRow [] dr=dsct.Tables[0].Select("stt="+stt.Value);
					if (dr.Length>0)
					{
						dr[0]["soluong"]=soluong.Text;
						dr[0]["loai"]=loai.Text;
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
			soluong.Text="";loai.Text="";
			soluong.Focus();
		}

		private void butXoa_Click(object sender, System.EventArgs e)
		{
			if (dsct.Tables[0].Rows.Count==0) return;
			if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý hủy thông tin này ?"),LibMedi.AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
			{
				m.delrec(dsct.Tables[0],"stt="+stt.Value);
				ref_text1();
			}
		}

		private void dataGrid2_CurrentCellChanged(object sender, System.EventArgs e)
		{
			ref_text1();
		}

		private void butScan_Click(object sender, System.EventArgs e)
		{
			if (l_id==0)
			{
				if (!kiemtra()) return;
				mmyy=m.mmyy(ngay.Text);
                if (!m.bMmyy(mmyy)) m.tao_schema(mmyy, i_userid);
				xxx=user+mmyy;
				l_idthuchien=m.get_idthuchien(ngay.Text,l_idkhoa);
				if (l_idthuchien==0) 
				{
					l_idthuchien=m.get_capid(-300);
					m.upd_ba_thuchien(ngay.Text,l_idthuchien,mabn.Text,l_maql,l_idkhoa,s_makp,phong.Text,giuong.Text,chandoan.Text);
				}
				if (l_id==0) l_id=m.get_capid(-304);
				else m.execute_data("delete from "+xxx+".ba_giaonhanct where id="+l_id);
                m.upd_ba_giaonhan(mabn.Text, l_id, l_idthuchien, ngay.Text + " " + gio.Text, trigiac.Text, (mach.Text != "") ? decimal.Parse(mach.Text) : 0, (nhietdo.Text != "") ? decimal.Parse(nhietdo.Text) : 0, huyetap.Text, (nhiptho.Text != "") ? decimal.Parse(nhiptho.Text) : 0, (cannang.Text != "") ? decimal.Parse(cannang.Text) : 0, (spo2.Text != "") ? decimal.Parse(spo2.Text) : 0, camtay.Text, mabs.Text, i_userid);
				upd_items();
			}
			frmBascan f=new frmBascan(m,1,mabn.Text,l_maql,l_idkhoa,l_idchung,sovaovien.Text,s_makp,hoten.Text,namsinh.Text,phai.Text,diachi.Text,ngayvv.Text,sothe.Text,phong.Text,giuong.Text,s_ngayrv,s_mabs,i_userid,s_nhomkho,s_userid,chandoan.Text,s_tenkp);
			f.ShowDialog();
		}
	}
}
