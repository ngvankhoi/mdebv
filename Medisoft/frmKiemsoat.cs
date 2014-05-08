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
	/// Summary description for frmKiemsoat.
	/// </summary>
	public class frmKiemsoat : System.Windows.Forms.Form
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
		private int i_userid;
		private string s_makp,user,xxx,s_ngayrv,sql,s_mabs,s_nhomkho,s_userid,s_tenkp;
		private decimal l_id,l_idthuchien,l_idkhoa,l_maql;
		private LibList.List listNv;
		private Brush disabledBackBrush;
		private Brush disabledTextBrush;
		private Brush alertBackBrush;
		private Font alertFont;
		private Brush alertTextBrush;
		private Font currentRowFont;
		private Brush currentRowBackBrush;
		private bool afterCurrentCellChanged=true;
		private int checkCol=2;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.TextBox tenddtruong;
		private MaskedTextBox.MaskedTextBox ddtruong;
		private System.Windows.Forms.TextBox nhanxet;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox tenddpmo;
		private MaskedTextBox.MaskedTextBox ddpmo;
		private System.Windows.Forms.TextBox tenddphutrach;
		private MaskedTextBox.MaskedTextBox ddphutrach;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.ComboBox cmbNgay;
		private System.Windows.Forms.TextBox trigiac;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label48;
		private MaskedTextBox.MaskedTextBox mach;
		private System.Windows.Forms.Label label39;
		private System.Windows.Forms.Label label47;
		private MaskedBox.MaskedBox nhietdo;
		private System.Windows.Forms.Label label40;
		private System.Windows.Forms.Label label46;
		private MaskedTextBox.MaskedTextBox huyetap;
		private System.Windows.Forms.Label label41;
		private System.Windows.Forms.Label label45;
		private MaskedTextBox.MaskedTextBox nhiptho;
		private System.Windows.Forms.Label label42;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.TextBox thuoc;
		private System.Windows.Forms.CheckBox tiembap;
		private System.Windows.Forms.CheckBox tiemtm;
		private System.Windows.Forms.CheckBox chkXML;

		public frmKiemsoat(LibMedi.AccessData acc,string _mabn,decimal _maql,decimal _idkhoa,decimal _idthuchien,string _sovaovien,string _makp,string _hoten,string _namsinh,string _phai,string _diachi,string _ngayvv,string _sothe,string _phong,string _giuong,string _ngayrv,string _mabs,int _userid,string _nhomkho,string suserid,string _chandoan,string _tenkp)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			m=acc;mabn.Text=_mabn;l_maql=_maql;l_idkhoa=_idkhoa;l_idthuchien=_idthuchien;sovaovien.Text=_sovaovien;i_userid=_userid;s_tenkp=_tenkp;
			hoten.Text=_hoten;chandoan.Text=_chandoan;s_makp=_makp;namsinh.Text=_namsinh;phai.Text=_phai;diachi.Text=_diachi;s_mabs=_mabs;s_nhomkho=_nhomkho;
			ngayvv.Text=_ngayvv;sothe.Text=_sothe;phong.Text=_phong;giuong.Text=_giuong;s_ngayrv=_ngayrv;s_userid=suserid;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKiemsoat));
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
            this.tenddtruong = new System.Windows.Forms.TextBox();
            this.ddtruong = new MaskedTextBox.MaskedTextBox();
            this.label87 = new System.Windows.Forms.Label();
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
            this.label17 = new System.Windows.Forms.Label();
            this.nhanxet = new System.Windows.Forms.TextBox();
            this.chkXML = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tenddpmo = new System.Windows.Forms.TextBox();
            this.ddpmo = new MaskedTextBox.MaskedTextBox();
            this.tenddphutrach = new System.Windows.Forms.TextBox();
            this.ddphutrach = new MaskedTextBox.MaskedTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cmbNgay = new System.Windows.Forms.ComboBox();
            this.trigiac = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.mach = new MaskedTextBox.MaskedTextBox();
            this.label39 = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.nhietdo = new MaskedBox.MaskedBox();
            this.label40 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.huyetap = new MaskedTextBox.MaskedTextBox();
            this.label41 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.nhiptho = new MaskedTextBox.MaskedTextBox();
            this.label42 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.thuoc = new System.Windows.Forms.TextBox();
            this.tiembap = new System.Windows.Forms.CheckBox();
            this.tiemtm = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // chandoan
            // 
            this.chandoan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.chandoan.Enabled = false;
            this.chandoan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chandoan.Location = new System.Drawing.Point(75, 5);
            this.chandoan.Name = "chandoan";
            this.chandoan.Size = new System.Drawing.Size(461, 21);
            this.chandoan.TabIndex = 71;
            // 
            // sothe
            // 
            this.sothe.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sothe.Enabled = false;
            this.sothe.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sothe.Location = new System.Drawing.Point(126, 105);
            this.sothe.Name = "sothe";
            this.sothe.Size = new System.Drawing.Size(56, 21);
            this.sothe.TabIndex = 63;
            // 
            // giuong
            // 
            this.giuong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.giuong.Enabled = false;
            this.giuong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.giuong.Location = new System.Drawing.Point(126, 105);
            this.giuong.Name = "giuong";
            this.giuong.Size = new System.Drawing.Size(56, 21);
            this.giuong.TabIndex = 70;
            // 
            // phong
            // 
            this.phong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.phong.Enabled = false;
            this.phong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phong.Location = new System.Drawing.Point(126, 105);
            this.phong.Name = "phong";
            this.phong.Size = new System.Drawing.Size(56, 21);
            this.phong.TabIndex = 69;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(-3, 7);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(73, 16);
            this.label13.TabIndex = 68;
            this.label13.Text = "Chẩn đoán :";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(126, 105);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 16);
            this.label12.TabIndex = 67;
            this.label12.Text = "Giường :";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(126, 105);
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
            this.ngayvv.Location = new System.Drawing.Point(126, 105);
            this.ngayvv.Name = "ngayvv";
            this.ngayvv.Size = new System.Drawing.Size(56, 21);
            this.ngayvv.TabIndex = 65;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(126, 105);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 16);
            this.label7.TabIndex = 64;
            this.label7.Text = "Ngày :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(126, 105);
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
            this.diachi.Location = new System.Drawing.Point(126, 105);
            this.diachi.Name = "diachi";
            this.diachi.Size = new System.Drawing.Size(56, 21);
            this.diachi.TabIndex = 61;
            // 
            // phai
            // 
            this.phai.BackColor = System.Drawing.SystemColors.HighlightText;
            this.phai.Enabled = false;
            this.phai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phai.Location = new System.Drawing.Point(126, 105);
            this.phai.Name = "phai";
            this.phai.Size = new System.Drawing.Size(56, 21);
            this.phai.TabIndex = 60;
            // 
            // namsinh
            // 
            this.namsinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.namsinh.Enabled = false;
            this.namsinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namsinh.Location = new System.Drawing.Point(126, 105);
            this.namsinh.Name = "namsinh";
            this.namsinh.Size = new System.Drawing.Size(56, 21);
            this.namsinh.TabIndex = 59;
            // 
            // hoten
            // 
            this.hoten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.hoten.Enabled = false;
            this.hoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoten.Location = new System.Drawing.Point(126, 105);
            this.hoten.Name = "hoten";
            this.hoten.Size = new System.Drawing.Size(56, 21);
            this.hoten.TabIndex = 58;
            // 
            // mabn
            // 
            this.mabn.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabn.Enabled = false;
            this.mabn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabn.Location = new System.Drawing.Point(126, 105);
            this.mabn.Name = "mabn";
            this.mabn.Size = new System.Drawing.Size(56, 21);
            this.mabn.TabIndex = 52;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(126, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 16);
            this.label5.TabIndex = 57;
            this.label5.Text = "Địa chỉ :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(126, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 16);
            this.label4.TabIndex = 56;
            this.label4.Text = "Giới tính :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(126, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 16);
            this.label3.TabIndex = 55;
            this.label3.Text = "NS :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(126, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 54;
            this.label1.Text = "Họ tên :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(126, 105);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 16);
            this.label10.TabIndex = 53;
            this.label10.Text = "Mã BN :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(126, 105);
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
            this.sovaovien.Location = new System.Drawing.Point(126, 105);
            this.sovaovien.Name = "sovaovien";
            this.sovaovien.Size = new System.Drawing.Size(56, 21);
            this.sovaovien.TabIndex = 73;
            // 
            // gio
            // 
            this.gio.BackColor = System.Drawing.SystemColors.HighlightText;
            this.gio.Enabled = false;
            this.gio.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gio.Location = new System.Drawing.Point(230, 448);
            this.gio.Mask = "##:##";
            this.gio.Name = "gio";
            this.gio.Size = new System.Drawing.Size(36, 21);
            this.gio.TabIndex = 11;
            this.gio.Text = "  :  ";
            this.gio.Validated += new System.EventHandler(this.gio_Validated);
            // 
            // ngay
            // 
            this.ngay.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngay.Enabled = false;
            this.ngay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngay.Location = new System.Drawing.Point(126, 448);
            this.ngay.Mask = "##/##/####";
            this.ngay.Name = "ngay";
            this.ngay.Size = new System.Drawing.Size(72, 21);
            this.ngay.TabIndex = 10;
            this.ngay.Text = "  /  /    ";
            this.ngay.Validated += new System.EventHandler(this.ngay_Validated);
            // 
            // label88
            // 
            this.label88.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label88.Location = new System.Drawing.Point(203, 450);
            this.label88.Name = "label88";
            this.label88.Size = new System.Drawing.Size(32, 16);
            this.label88.TabIndex = 302;
            this.label88.Text = "Giờ :";
            this.label88.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label90
            // 
            this.label90.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label90.Location = new System.Drawing.Point(86, 448);
            this.label90.Name = "label90";
            this.label90.Size = new System.Drawing.Size(40, 16);
            this.label90.TabIndex = 301;
            this.label90.Text = "Ngày :";
            this.label90.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tenddtruong
            // 
            this.tenddtruong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenddtruong.Enabled = false;
            this.tenddtruong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenddtruong.Location = new System.Drawing.Point(416, 448);
            this.tenddtruong.Name = "tenddtruong";
            this.tenddtruong.Size = new System.Drawing.Size(216, 21);
            this.tenddtruong.TabIndex = 13;
            this.tenddtruong.TextChanged += new System.EventHandler(this.tenddtruong_TextChanged);
            this.tenddtruong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbs_KeyDown);
            // 
            // ddtruong
            // 
            this.ddtruong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ddtruong.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ddtruong.Enabled = false;
            this.ddtruong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddtruong.Location = new System.Drawing.Point(374, 448);
            this.ddtruong.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.ddtruong.MaxLength = 9;
            this.ddtruong.Name = "ddtruong";
            this.ddtruong.Size = new System.Drawing.Size(41, 21);
            this.ddtruong.TabIndex = 12;
            this.ddtruong.Validated += new System.EventHandler(this.ddtruong_Validated);
            this.ddtruong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // label87
            // 
            this.label87.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label87.Location = new System.Drawing.Point(251, 450);
            this.label87.Name = "label87";
            this.label87.Size = new System.Drawing.Size(127, 16);
            this.label87.TabIndex = 300;
            this.label87.Text = "ĐD Trưởng toán trực :";
            this.label87.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.dataGrid1.Location = new System.Drawing.Point(0, 12);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(809, 341);
            this.dataGrid1.TabIndex = 1;
            this.dataGrid1.Click += new System.EventHandler(this.dataGrid1_Click);
            // 
            // butMoi
            // 
            this.butMoi.Location = new System.Drawing.Point(174, 496);
            this.butMoi.Name = "butMoi";
            this.butMoi.Size = new System.Drawing.Size(70, 25);
            this.butMoi.TabIndex = 20;
            this.butMoi.Text = "&Mới";
            this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
            // 
            // butSua
            // 
            this.butSua.Location = new System.Drawing.Point(244, 496);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(70, 25);
            this.butSua.TabIndex = 21;
            this.butSua.Text = "&Sửa";
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butLuu
            // 
            this.butLuu.Enabled = false;
            this.butLuu.Location = new System.Drawing.Point(314, 496);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 18;
            this.butLuu.Text = "&Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Enabled = false;
            this.butBoqua.Location = new System.Drawing.Point(384, 496);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(70, 25);
            this.butBoqua.TabIndex = 19;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butHuy
            // 
            this.butHuy.Location = new System.Drawing.Point(454, 496);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(70, 25);
            this.butHuy.TabIndex = 22;
            this.butHuy.Text = "&Hủy";
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // butIn
            // 
            this.butIn.Location = new System.Drawing.Point(524, 496);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 23;
            this.butIn.Text = "&In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Location = new System.Drawing.Point(594, 496);
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
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(-10, 408);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(136, 16);
            this.label17.TabIndex = 319;
            this.label17.Text = "Nhận xét của phòng mổ :";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nhanxet
            // 
            this.nhanxet.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nhanxet.Enabled = false;
            this.nhanxet.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhanxet.Location = new System.Drawing.Point(126, 405);
            this.nhanxet.Multiline = true;
            this.nhanxet.Name = "nhanxet";
            this.nhanxet.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.nhanxet.Size = new System.Drawing.Size(506, 40);
            this.nhanxet.TabIndex = 9;
            // 
            // chkXML
            // 
            this.chkXML.Location = new System.Drawing.Point(696, 496);
            this.chkXML.Name = "chkXML";
            this.chkXML.Size = new System.Drawing.Size(88, 24);
            this.chkXML.TabIndex = 324;
            this.chkXML.Text = "Xuất ra XML";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(0, 472);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(127, 16);
            this.label8.TabIndex = 325;
            this.label8.Text = "ĐD phòng mổ :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(387, 472);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(127, 16);
            this.label9.TabIndex = 326;
            this.label9.Text = "ĐD phụ trách bệnh :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tenddpmo
            // 
            this.tenddpmo.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenddpmo.Enabled = false;
            this.tenddpmo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenddpmo.Location = new System.Drawing.Point(168, 471);
            this.tenddpmo.Name = "tenddpmo";
            this.tenddpmo.Size = new System.Drawing.Size(224, 21);
            this.tenddpmo.TabIndex = 15;
            this.tenddpmo.TextChanged += new System.EventHandler(this.tenddpmo_TextChanged);
            this.tenddpmo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbs_KeyDown);
            // 
            // ddpmo
            // 
            this.ddpmo.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ddpmo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ddpmo.Enabled = false;
            this.ddpmo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddpmo.Location = new System.Drawing.Point(126, 471);
            this.ddpmo.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.ddpmo.MaxLength = 9;
            this.ddpmo.Name = "ddpmo";
            this.ddpmo.Size = new System.Drawing.Size(41, 21);
            this.ddpmo.TabIndex = 14;
            this.ddpmo.Validated += new System.EventHandler(this.ddpmo_Validated);
            this.ddpmo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // tenddphutrach
            // 
            this.tenddphutrach.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenddphutrach.Enabled = false;
            this.tenddphutrach.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenddphutrach.Location = new System.Drawing.Point(560, 471);
            this.tenddphutrach.Name = "tenddphutrach";
            this.tenddphutrach.Size = new System.Drawing.Size(249, 21);
            this.tenddphutrach.TabIndex = 17;
            this.tenddphutrach.TextChanged += new System.EventHandler(this.tenddphutrach_TextChanged);
            this.tenddphutrach.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbs_KeyDown);
            // 
            // ddphutrach
            // 
            this.ddphutrach.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ddphutrach.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ddphutrach.Enabled = false;
            this.ddphutrach.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddphutrach.Location = new System.Drawing.Point(518, 471);
            this.ddphutrach.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.ddphutrach.MaxLength = 9;
            this.ddphutrach.Name = "ddphutrach";
            this.ddphutrach.Size = new System.Drawing.Size(41, 21);
            this.ddphutrach.TabIndex = 16;
            this.ddphutrach.Validated += new System.EventHandler(this.ddphutrach_Validated);
            this.ddphutrach.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(541, 7);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(40, 16);
            this.label14.TabIndex = 327;
            this.label14.Text = "Ngày :";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbNgay
            // 
            this.cmbNgay.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cmbNgay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNgay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbNgay.Location = new System.Drawing.Point(584, 5);
            this.cmbNgay.Name = "cmbNgay";
            this.cmbNgay.Size = new System.Drawing.Size(225, 21);
            this.cmbNgay.TabIndex = 0;
            this.cmbNgay.SelectedIndexChanged += new System.EventHandler(this.cmbNgay_SelectedIndexChanged);
            // 
            // trigiac
            // 
            this.trigiac.BackColor = System.Drawing.SystemColors.HighlightText;
            this.trigiac.Enabled = false;
            this.trigiac.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trigiac.Location = new System.Drawing.Point(688, 448);
            this.trigiac.Name = "trigiac";
            this.trigiac.Size = new System.Drawing.Size(121, 21);
            this.trigiac.TabIndex = 8;
            this.trigiac.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(536, 453);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(152, 16);
            this.label15.TabIndex = 341;
            this.label15.Text = "Tri giác :";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label48
            // 
            this.label48.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label48.Location = new System.Drawing.Point(648, 357);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(40, 16);
            this.label48.TabIndex = 330;
            this.label48.Text = "Mạch :";
            this.label48.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mach
            // 
            this.mach.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mach.Enabled = false;
            this.mach.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mach.Location = new System.Drawing.Point(688, 357);
            this.mach.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.mach.MaxLength = 5;
            this.mach.Name = "mach";
            this.mach.Size = new System.Drawing.Size(32, 21);
            this.mach.TabIndex = 4;
            this.mach.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label39
            // 
            this.label39.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label39.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label39.Location = new System.Drawing.Point(723, 357);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(48, 19);
            this.label39.TabIndex = 337;
            this.label39.Text = "lần/phút";
            this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label47
            // 
            this.label47.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label47.Location = new System.Drawing.Point(632, 405);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(56, 16);
            this.label47.TabIndex = 331;
            this.label47.Text = "Nhiệt độ :";
            this.label47.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nhietdo
            // 
            this.nhietdo.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nhietdo.Enabled = false;
            this.nhietdo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhietdo.Location = new System.Drawing.Point(688, 403);
            this.nhietdo.Mask = "##.##";
            this.nhietdo.Name = "nhietdo";
            this.nhietdo.Size = new System.Drawing.Size(40, 21);
            this.nhietdo.TabIndex = 6;
            this.nhietdo.Text = "  .  ";
            // 
            // label40
            // 
            this.label40.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label40.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label40.Location = new System.Drawing.Point(731, 405);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(24, 16);
            this.label40.TabIndex = 338;
            this.label40.Text = "°C";
            this.label40.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label46
            // 
            this.label46.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label46.Location = new System.Drawing.Point(624, 381);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(64, 16);
            this.label46.TabIndex = 333;
            this.label46.Text = "Huyết áp :";
            this.label46.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // huyetap
            // 
            this.huyetap.BackColor = System.Drawing.SystemColors.HighlightText;
            this.huyetap.Enabled = false;
            this.huyetap.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.huyetap.Location = new System.Drawing.Point(688, 380);
            this.huyetap.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.huyetap.MaxLength = 7;
            this.huyetap.Name = "huyetap";
            this.huyetap.Size = new System.Drawing.Size(48, 21);
            this.huyetap.TabIndex = 5;
            // 
            // label41
            // 
            this.label41.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label41.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label41.Location = new System.Drawing.Point(739, 381);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(38, 16);
            this.label41.TabIndex = 339;
            this.label41.Text = "mmHg";
            this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label45
            // 
            this.label45.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label45.Location = new System.Drawing.Point(632, 429);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(56, 16);
            this.label45.TabIndex = 335;
            this.label45.Text = "Nhịp thở :";
            this.label45.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nhiptho
            // 
            this.nhiptho.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nhiptho.Enabled = false;
            this.nhiptho.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhiptho.Location = new System.Drawing.Point(688, 426);
            this.nhiptho.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.nhiptho.MaxLength = 5;
            this.nhiptho.Name = "nhiptho";
            this.nhiptho.Size = new System.Drawing.Size(32, 21);
            this.nhiptho.TabIndex = 7;
            this.nhiptho.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label42
            // 
            this.label42.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label42.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label42.Location = new System.Drawing.Point(725, 429);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(48, 16);
            this.label42.TabIndex = 340;
            this.label42.Text = "lần/phút";
            this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(-66, 364);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(192, 16);
            this.label16.TabIndex = 342;
            this.label16.Text = "Thuốc dùng trước khi PT :";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // thuoc
            // 
            this.thuoc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.thuoc.Enabled = false;
            this.thuoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thuoc.Location = new System.Drawing.Point(126, 363);
            this.thuoc.Multiline = true;
            this.thuoc.Name = "thuoc";
            this.thuoc.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.thuoc.Size = new System.Drawing.Size(330, 40);
            this.thuoc.TabIndex = 1;
            // 
            // tiembap
            // 
            this.tiembap.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tiembap.Enabled = false;
            this.tiembap.Location = new System.Drawing.Point(458, 363);
            this.tiembap.Name = "tiembap";
            this.tiembap.Size = new System.Drawing.Size(67, 16);
            this.tiembap.TabIndex = 2;
            this.tiembap.Text = "tiêm bắp";
            this.tiembap.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // tiemtm
            // 
            this.tiemtm.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tiemtm.Enabled = false;
            this.tiemtm.Location = new System.Drawing.Point(530, 363);
            this.tiemtm.Name = "tiemtm";
            this.tiemtm.Size = new System.Drawing.Size(97, 16);
            this.tiemtm.TabIndex = 3;
            this.tiemtm.Text = "tiêm tĩnh mạch";
            this.tiemtm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // frmKiemsoat
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(829, 579);
            this.Controls.Add(this.tenddtruong);
            this.Controls.Add(this.tiemtm);
            this.Controls.Add(this.tiembap);
            this.Controls.Add(this.thuoc);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.trigiac);
            this.Controls.Add(this.label15);
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
            this.Controls.Add(this.cmbNgay);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.tenddphutrach);
            this.Controls.Add(this.ddphutrach);
            this.Controls.Add(this.tenddpmo);
            this.Controls.Add(this.ddpmo);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.chkXML);
            this.Controls.Add(this.gio);
            this.Controls.Add(this.nhanxet);
            this.Controls.Add(this.label17);
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
            this.Controls.Add(this.ddtruong);
            this.Controls.Add(this.label87);
            this.Controls.Add(this.chandoan);
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
            this.Name = "frmKiemsoat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bảng kiểm soát bệnh nhân trước khi đưa lên phòng mổ";
            this.Load += new System.EventHandler(this.frmKiemsoat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmKiemsoat_Load(object sender, System.EventArgs e)
		{
            this.Location = new System.Drawing.Point(188, 151);
			user=m.user;xxx=user+m.mmyy(ngayvv.Text);
            dtnv = m.get_data("select ma,hoten,nhom from " + user + ".dmbs where nhom<>" + LibMedi.AccessData.nghiviec + " and nhom=" + LibMedi.AccessData.nhanvien + " order by hoten").Tables[0];
			listNv.DisplayMember="MA";
			listNv.ValueMember="HOTEN";
			listNv.DataSource=dtnv;
			cmbNgay.DisplayMember="NGAY";
			cmbNgay.ValueMember="ID";
			ds=m.get_data("select a.id,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay,a.thuoc,a.tiembap,a.tiemtm,a.mach,a.nhietdo,a.huyetap,a.nhiptho,a.trigiac,a.nhanxet,a.ddtruong,a.ddpmo,a.ddphutrach from "+xxx+".ba_kiemsoat a,"+xxx+".ba_thuchien b where a.idthuchien=b.id and b.id="+l_idthuchien+" order by a.ngay");
			cmbNgay.DataSource=ds.Tables[0];
			load_head();
			AddGridTableStyle();
			this.disabledBackBrush = new SolidBrush(Color.Black);
			this.disabledTextBrush = new SolidBrush(Color.Red);

			this.alertBackBrush = new SolidBrush(SystemColors.HotTrack);
			this.alertFont = new Font(this.dataGrid1.Font.Name, this.dataGrid1.Font.Size, FontStyle.Bold);
			this.alertTextBrush = new SolidBrush(Color.White);
			
			this.currentRowFont = new Font(this.dataGrid1.Font.Name, this.dataGrid1.Font.Size, FontStyle.Regular);
			this.currentRowBackBrush = new SolidBrush(Color.FromArgb(0,255, 255));
			dataGrid1.ReadOnly=true;
		}

		private void load_head()
		{			
			l_id=(cmbNgay.SelectedIndex!=-1)?decimal.Parse(cmbNgay.SelectedValue.ToString()):0;
			DataRow r1,r=m.getrowbyid(ds.Tables[0],"id="+l_id);
			if (r!=null)
			{
				nhanxet.Text=r["nhanxet"].ToString();
				ngay.Text=r["ngay"].ToString().Substring(0,10);
				thuoc.Text=r["thuoc"].ToString();
				tiembap.Checked=r["tiembap"].ToString()=="1";
				tiemtm.Checked=r["tiemtm"].ToString()=="1";
				mach.Text=(r["mach"].ToString()!="0")?r["mach"].ToString():"";
				nhietdo.Text=(r["nhietdo"].ToString()!="0")?r["nhietdo"].ToString():"";
				huyetap.Text=r["huyetap"].ToString();
				nhiptho.Text=(r["nhiptho"].ToString()!="0")?r["nhiptho"].ToString():"";
				trigiac.Text=r["trigiac"].ToString();
				gio.Text=r["ngay"].ToString().Substring(11);
				ddtruong.Text=r["ddtruong"].ToString();
				r1=m.getrowbyid(dtnv,"ma='"+ddtruong.Text+"'");
				if (r1!=null) tenddtruong.Text=r1["hoten"].ToString();
				else tenddtruong.Text="";
				ddpmo.Text=r["ddpmo"].ToString();
				r1=m.getrowbyid(dtnv,"ma='"+ddpmo.Text+"'");
				if (r1!=null) tenddpmo.Text=r1["hoten"].ToString();
				else tenddpmo.Text="";
				ddphutrach.Text=r["ddphutrach"].ToString();
				r1=m.getrowbyid(dtnv,"ma='"+ddphutrach.Text+"'");
				if (r1!=null) tenddphutrach.Text=r1["hoten"].ToString();
				else tenddphutrach.Text="";
			}
			load_grid(0);
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

		private void load_grid(int loai)
		{
            if (loai == -1) sql = "select stt,id as ma,ten,0 as cokhong,' ' as ghichu from " + user + ".ba_dmcongtac order by stt";
			else
			{
				sql="select b.stt,b.id as ma,b.ten,coalesce(a.cokhong,0) as cokhong,coalesce(a.ghichu,' ') as ghichu from "+xxx+".ba_kiemsoatct a,"+user+".ba_dmcongtac b";
				sql+=" where a.ma=b.id and a.id="+l_id+" order by b.stt";
			}
			dsct=m.get_data(sql);
			dsct.Tables[0].Columns.Add("Chon",typeof(bool));
			dataGrid1.DataSource=dsct.Tables[0];
			CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource,dataGrid1.DataMember]; 
			DataView dv = (DataView) cm.List; 
			dv.AllowNew = false; 
			foreach (DataRow r in dsct.Tables[0].Rows) r["chon"]=(r["cokhong"].ToString()=="1")?true:false;
		}

		private void AddGridTableStyle()
		{
			DataGridTableStyle ts =new DataGridTableStyle();
			ts.MappingName = dsct.Tables[0].TableName;
			ts.AlternatingBackColor = Color.Beige;
			ts.BackColor = Color.GhostWhite;
			ts.ForeColor = Color.MidnightBlue;
			ts.GridLineColor = Color.RoyalBlue;
			ts.HeaderBackColor = Color.MidnightBlue;
			ts.HeaderForeColor = Color.Lavender;
			ts.SelectionBackColor = Color.FromArgb(0,255,255);
			ts.SelectionForeColor = Color.PaleGreen;
			ts.RowHeaderWidth=5;

			FormattableTextBoxColumn TextCol1 = new FormattableTextBoxColumn();
			TextCol1.MappingName = "stt";
			TextCol1.HeaderText = "TT";
			TextCol1.Width = 20;
			TextCol1.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			TextCol1.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new FormattableTextBoxColumn();
			TextCol1.MappingName = "ten";
			TextCol1.HeaderText = "Công tác thực hiện";
			TextCol1.Width =400;
			TextCol1.ReadOnly=true;
			TextCol1.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			FormattableBooleanColumn discontinuedCol = new FormattableBooleanColumn();
			discontinuedCol.MappingName = "chon";
			discontinuedCol.HeaderText = "Có/Không";
			discontinuedCol.Width = 55;
			discontinuedCol.AllowNull = false;

			discontinuedCol.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			discontinuedCol.BoolValueChanged += new BoolValueChangedEventHandler(BoolValueChanged);
			ts.GridColumnStyles.Add(discontinuedCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new FormattableTextBoxColumn();
			TextCol1.MappingName = "ghichu";
			TextCol1.HeaderText = "Ghi chú";
			TextCol1.Width = 270;
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

		private void emp_text()
		{
			l_id=0;dsct.Clear();load_grid(-1);
			string _ngay=m.ngayhienhanh_server;
			ngay.Text=_ngay.Substring(0,10);
			gio.Text=_ngay.Substring(11);thuoc.Text="";tiembap.Checked=false;tiemtm.Checked=false;
			mach.Text="";nhietdo.Text="";huyetap.Text="";nhiptho.Text="";trigiac.Text="";
			nhanxet.Text="";ddtruong.Text="";tenddtruong.Text="";
			ddpmo.Text="";tenddpmo.Text="";ddphutrach.Text="";tenddphutrach.Text="";
			decimal _id=m.get_idchung(ngayvv.Text,l_idthuchien);
			foreach(DataRow r in m.get_data("select * from "+xxx+".ba_kbdausinhton where id="+_id).Tables[0].Rows)
			{
				mach.Text=(r["mach"].ToString()!="0")?r["mach"].ToString():"";
				nhietdo.Text=(r["nhietdo"].ToString()!="0")?r["nhietdo"].ToString():"";
				huyetap.Text=r["huyetap"].ToString();
				nhiptho.Text=(r["nhiptho"].ToString()!="0")?r["nhiptho"].ToString():"";
				break;
			}
		}

		private void ena_object(bool ena)
		{
			ngay.Enabled=ena;
			gio.Enabled=ena;
			thuoc.Enabled=ena;
			tiembap.Enabled=ena;
			tiemtm.Enabled=ena;
			mach.Enabled=ena;
			nhietdo.Enabled=ena;
			huyetap.Enabled=ena;
			nhiptho.Enabled=ena;
			trigiac.Enabled=ena;
			nhanxet.Enabled=ena;
			ddtruong.Enabled=ena;
			tenddtruong.Enabled=ena;
			ddpmo.Enabled=ena;
			tenddpmo.Enabled=ena;
			ddphutrach.Enabled=ena;
			tenddphutrach.Enabled=ena;
			cmbNgay.Enabled=!ena;
			butLuu.Enabled=ena;
			butBoqua.Enabled=ena;
			butMoi.Enabled=!ena;
			butSua.Enabled=!ena;
			butIn.Enabled=!ena;
			butHuy.Enabled=!ena;
			butKetthuc.Enabled=!ena;
			dataGrid1.ReadOnly=!ena;
		}

		private void butMoi_Click(object sender, System.EventArgs e)
		{
			ena_object(true);
			emp_text();
			dataGrid1.Focus();
		}

		private void butSua_Click(object sender, System.EventArgs e)
		{
			if (cmbNgay.SelectedIndex==-1) return;
			ena_object(true);
			dataGrid1.Focus();
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void butHuy_Click(object sender, System.EventArgs e)
		{
			if (cmbNgay.SelectedIndex==-1) return;
			if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý hủy thông tin này ?"),LibMedi.AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
			{
				m.execute_data("delete from "+xxx+".ba_kiemsoatct where id="+l_id);
				m.execute_data("delete from "+xxx+".ba_kiemsoat where id="+l_id);
				m.delrec(ds.Tables[0],"id="+l_id);
				cmbNgay.Update();
				load_head();
			}
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			ena_object(false);
			load_head();
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
			if (ddpmo.Text=="" || tenddpmo.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("ĐD phòng mổ không hợp lệ !"),LibMedi.AccessData.Msg);
				ddpmo.Focus();
				return false;
			}
			if (ddphutrach.Text=="" || tenddphutrach.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("ĐD phụ trách bệnh không hợp lệ !"),LibMedi.AccessData.Msg);
				ddphutrach.Focus();
				return false;
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
			if (l_id==0) l_id=m.get_capid(-306);
			else m.execute_data("delete from "+xxx+".ba_kiemsoatct where id="+l_id);
            m.upd_ba_kiemsoat(m.mmyy(ngayvv.Text), mabn.Text, l_id, l_idthuchien, ngay.Text + " " + gio.Text, thuoc.Text, (tiembap.Checked) ? 1 : 0, (tiemtm.Checked) ? 1 : 0, (mach.Text != "") ? decimal.Parse(mach.Text) : 0, (nhietdo.Text != "") ? decimal.Parse(nhietdo.Text) : 0, huyetap.Text, (nhiptho.Text != "") ? decimal.Parse(nhiptho.Text) : 0, trigiac.Text, nhanxet.Text, ddtruong.Text, ddpmo.Text, ddphutrach.Text, i_userid);
			foreach(DataRow r in dsct.Tables[0].Select("true","stt")) m.upd_ba_kiemsoatct(ngayvv.Text,l_id,int.Parse(r["ma"].ToString()),(r["chon"].ToString().ToLower()=="true")?1:0,r["ghichu"].ToString());
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
				r2["ngay"]=ngay.Text+" "+gio.Text;
				r2["thuoc"]=thuoc.Text;
				r2["tiembap"]=(tiembap.Checked)?1:0;
				r2["tiemtm"]=(tiemtm.Checked)?1:0;
				r2["mach"]=(mach.Text!="")?decimal.Parse(mach.Text):0;
				r2["nhietdo"]=(nhietdo.Text!="")?decimal.Parse(nhietdo.Text):0;
				r2["huyetap"]=huyetap.Text;
				r2["nhiptho"]=(nhiptho.Text!="")?decimal.Parse(nhiptho.Text):0;
				r2["trigiac"]=trigiac.Text;
				r2["nhanxet"]=nhanxet.Text;
				r2["ddtruong"]=ddtruong.Text;
				r2["ddpmo"]=ddpmo.Text;
				r2["ddphutrach"]=ddphutrach.Text;
				ds.Tables[0].Rows.Add(r2);
			}
			else
			{
				DataRow [] dr=ds.Tables[0].Select("id="+l_id);
				dr[0]["ngay"]=ngay.Text+" "+gio.Text;
				dr[0]["tiembap"]=(tiembap.Checked)?1:0;
				dr[0]["tiemtm"]=(tiemtm.Checked)?1:0;
				dr[0]["mach"]=(mach.Text!="")?decimal.Parse(mach.Text):0;
				dr[0]["nhietdo"]=(nhietdo.Text!="")?decimal.Parse(nhietdo.Text):0;
				dr[0]["huyetap"]=huyetap.Text;
				dr[0]["nhiptho"]=(nhiptho.Text!="")?decimal.Parse(nhiptho.Text):0;
				dr[0]["trigiac"]=trigiac.Text;
				dr[0]["nhanxet"]=nhanxet.Text;
				dr[0]["ddtruong"]=ddtruong.Text;
				dr[0]["ddpmo"]=ddpmo.Text;
				dr[0]["ddphutrach"]=ddphutrach.Text;
			}
		}

        private void butIn_Click(object sender, System.EventArgs e)
        {
            string stuoi = m.get_tuoivao(l_maql).Trim();
            sql = "select '' as sovaovien,'' as mabn,'' as hoten,'' as tuoi,'' as phai,'' as tenkp,";
            sql += "'' as phong,'' as giuong,'' as chandoan,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay,";
            sql += "a.thuoc,a.tiembap,a.tiemtm,a.mach,a.nhietdo,a.huyetap,a.nhiptho,a.trigiac,a.nhanxet,d.hoten as ddtruong,e.hoten as ddpmo,f.hoten as ddphutrach,";
            sql += "c.ten,b.cokhong,b.ghichu,'' as iddtruong,'' as iddpmo,'' as iddphutrach";//d.image,e.image,f.image
            sql += " from " + xxx + ".ba_kiemsoat a inner join " + xxx + ".ba_kiemsoatct b on a.id=b.id";
            sql += " inner join " + user + ".ba_dmcongtac c on b.ma=c.id left join " + user + ".dmbs d on a.ddtruong=d.ma";
            sql += " left join " + user + ".dmbs e on a.ddpmo=e.ma left join " + user + ".dmbs f on a.ddphutrach=f.ma";
            sql += " where a.id=" + l_id;
            DataSet dsxml = m.get_data(sql);
            if (chkXML.Checked)
            {
                if (!System.IO.Directory.Exists("..\\xml")) System.IO.Directory.CreateDirectory("..\\xml");
                dsxml.WriteXml("..\\xml\\kiemsoat.xml", XmlWriteMode.WriteSchema);
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
                dllReportM.frmReport f = new dllReportM.frmReport(m, dsxml, "", "rKiemsoat.rpt");
                f.ShowDialog();
            }
            else MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"), LibMedi.AccessData.Msg);
        }

		private void ddtruong_Validated(object sender, System.EventArgs e)
		{
			if (ddtruong.Text=="") return;
			DataRow r=m.getrowbyid(dtnv,"ma='"+ddtruong.Text+"'");
			if (r!=null) tenddtruong.Text=r["hoten"].ToString();
			else tenddtruong.Text="";	
		}

		private void ddpmo_Validated(object sender, System.EventArgs e)
		{
			if (ddpmo.Text=="") return;
			DataRow r=m.getrowbyid(dtnv,"ma='"+ddpmo.Text+"'");
			if (r!=null) tenddpmo.Text=r["hoten"].ToString();
			else tenddpmo.Text="";	
		}

		private void ddphutrach_Validated(object sender, System.EventArgs e)
		{
			if (ddphutrach.Text=="") return;
			DataRow r=m.getrowbyid(dtnv,"ma='"+ddphutrach.Text+"'");
			if (r!=null) tenddphutrach.Text=r["hoten"].ToString();
			else tenddphutrach.Text="";	
		}

		private void tenddtruong_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tenddtruong)
			{
				Filt_dmbs(tenddtruong.Text);
				listNv.BrowseToDanhmuc(tenddtruong,ddtruong,ddpmo,35);
			}		
		}

		private void tenddpmo_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tenddpmo)
			{
				Filt_dmbs(tenddpmo.Text);
				listNv.BrowseToDanhmuc(tenddpmo,ddpmo,ddphutrach,35);
			}		
		}

		private void tenddphutrach_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tenddphutrach)
			{
				Filt_dmbs(tenddphutrach.Text);
				listNv.BrowseToDanhmuc(tenddphutrach,ddphutrach,butLuu,35);
			}		
		}

		private void cmbNgay_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==cmbNgay && cmbNgay.SelectedIndex!=-1) load_head();
		}
	}
}
