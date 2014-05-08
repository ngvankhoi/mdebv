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
	/// Summary description for frmDanhgia.
	/// </summary>
	public class frmDanhgia : System.Windows.Forms.Form
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
		private System.Windows.Forms.TextBox tenbs;
		private MaskedTextBox.MaskedTextBox mabs;
		private System.Windows.Forms.Label label87;
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
		private LibList.List listNv;
		private bool bAdmin;
		private System.Windows.Forms.Label label30;
		private System.Windows.Forms.ComboBox cmbngay;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.Label label8;
		private MaskedBox.MaskedBox nhietdo;
		private MaskedTextBox.MaskedTextBox huyetap;
		private MaskedTextBox.MaskedTextBox nhiptho;
		private MaskedTextBox.MaskedTextBox mach;
		private System.Windows.Forms.Label label149;
		private System.Windows.Forms.Label label150;
		private System.Windows.Forms.Label label151;
		private System.Windows.Forms.Label label152;
		private System.Windows.Forms.Label label155;
		private System.Windows.Forms.Label label156;
		private System.Windows.Forms.Label label157;
		private System.Windows.Forms.Label label158;
		private System.Windows.Forms.TextBox thuoc;
		private System.Windows.Forms.CheckBox thuoc_k;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label14;
		private MaskedTextBox.MaskedTextBox cannang;
		private MaskedTextBox.MaskedTextBox chieucao;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.CheckBox diung_k;
		private System.Windows.Forms.TextBox diung;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.CheckBox tm_k;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.Label label28;
		private System.Windows.Forms.Label label29;
		private System.Windows.Forms.Label label31;
		private System.Windows.Forms.ComboBox asa;
		private System.Windows.Forms.Label label32;
		private System.Windows.Forms.Label label33;
		private System.Windows.Forms.CheckBox tm_1;
		private System.Windows.Forms.CheckBox tm_4;
		private System.Windows.Forms.CheckBox tm_5;
		private System.Windows.Forms.CheckBox tm_2;
		private System.Windows.Forms.CheckBox tm_6;
		private System.Windows.Forms.CheckBox tm_3;
		private System.Windows.Forms.CheckBox tm_7;
		private System.Windows.Forms.TextBox tm;
		private System.Windows.Forms.TextBox than;
		private System.Windows.Forms.CheckBox than_4;
		private System.Windows.Forms.CheckBox than_3;
		private System.Windows.Forms.CheckBox than_2;
		private System.Windows.Forms.CheckBox than_1;
		private System.Windows.Forms.CheckBox than_k;
		private System.Windows.Forms.TextBox hh;
		private System.Windows.Forms.CheckBox hh_7;
		private System.Windows.Forms.CheckBox hh_6;
		private System.Windows.Forms.CheckBox hh_3;
		private System.Windows.Forms.CheckBox hh_5;
		private System.Windows.Forms.CheckBox hh_2;
		private System.Windows.Forms.CheckBox hh_4;
		private System.Windows.Forms.CheckBox hh_1;
		private System.Windows.Forms.CheckBox hh_k;
		private System.Windows.Forms.TextBox noitiet;
		private System.Windows.Forms.CheckBox noitiet_6;
		private System.Windows.Forms.CheckBox noitiet_3;
		private System.Windows.Forms.CheckBox noitiet_5;
		private System.Windows.Forms.CheckBox noitiet_2;
		private System.Windows.Forms.CheckBox noitiet_4;
		private System.Windows.Forms.CheckBox noitiet_1;
		private System.Windows.Forms.CheckBox noitiet_k;
		private System.Windows.Forms.TextBox tieuhoa;
		private System.Windows.Forms.CheckBox tieuhoa_7;
		private System.Windows.Forms.CheckBox tieuhoa_6;
		private System.Windows.Forms.CheckBox tieuhoa_3;
		private System.Windows.Forms.CheckBox tieuhoa_5;
		private System.Windows.Forms.CheckBox tieuhoa_2;
		private System.Windows.Forms.CheckBox tieuhoa_4;
		private System.Windows.Forms.CheckBox tieuhoa_1;
		private System.Windows.Forms.CheckBox tieuhoa_k;
		private System.Windows.Forms.CheckBox thankinh_2;
		private System.Windows.Forms.CheckBox thankinh_3;
		private System.Windows.Forms.CheckBox thankinh_4;
		private System.Windows.Forms.CheckBox thankinh_1;
		private System.Windows.Forms.CheckBox thankinh_k;
		private System.Windows.Forms.TextBox huyethoc;
		private System.Windows.Forms.CheckBox huyethoc_3;
		private System.Windows.Forms.CheckBox huyethoc_2;
		private System.Windows.Forms.CheckBox huyethoc_1;
		private System.Windows.Forms.CheckBox huyethoc_k;
		private System.Windows.Forms.TextBox lamsang;
		private System.Windows.Forms.TextBox xn;
		private System.Windows.Forms.TextBox luuy;
		private System.Windows.Forms.CheckBox thaoluan_3;
		private System.Windows.Forms.CheckBox thaoluan_2;
		private System.Windows.Forms.CheckBox thaoluan_1;
		private System.Windows.Forms.CheckBox thaoluan_5;
		private System.Windows.Forms.CheckBox thaoluan_4;
		private System.Windows.Forms.CheckBox kham_3;
		private System.Windows.Forms.CheckBox kham_5;
		private System.Windows.Forms.CheckBox kham_2;
		private System.Windows.Forms.CheckBox kham_4;
		private System.Windows.Forms.CheckBox kham_1;
		private System.Windows.Forms.TextBox kham;
		private System.Windows.Forms.TextBox cls;
		private System.Windows.Forms.TextBox kehoach;
		private System.Windows.Forms.CheckBox chkXML;

		public frmDanhgia(LibMedi.AccessData acc,string _mabn,decimal _maql,decimal _idkhoa,string _sovaovien,string _makp,string _hoten,string _namsinh,string _phai,string _diachi,string _ngayvv,string _sothe,string _phong,string _giuong,string _ngayrv,string _mabs,int _userid,string _nhomkho,string suserid,string _chandoan,string _tenkp,bool _admin)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDanhgia));
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
            this.label30 = new System.Windows.Forms.Label();
            this.cmbngay = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.huyethoc = new System.Windows.Forms.TextBox();
            this.huyethoc_3 = new System.Windows.Forms.CheckBox();
            this.huyethoc_2 = new System.Windows.Forms.CheckBox();
            this.huyethoc_1 = new System.Windows.Forms.CheckBox();
            this.huyethoc_k = new System.Windows.Forms.CheckBox();
            this.label24 = new System.Windows.Forms.Label();
            this.thankinh_2 = new System.Windows.Forms.CheckBox();
            this.thankinh_3 = new System.Windows.Forms.CheckBox();
            this.thankinh_4 = new System.Windows.Forms.CheckBox();
            this.thankinh_1 = new System.Windows.Forms.CheckBox();
            this.thankinh_k = new System.Windows.Forms.CheckBox();
            this.label23 = new System.Windows.Forms.Label();
            this.tieuhoa = new System.Windows.Forms.TextBox();
            this.tieuhoa_7 = new System.Windows.Forms.CheckBox();
            this.tieuhoa_6 = new System.Windows.Forms.CheckBox();
            this.tieuhoa_3 = new System.Windows.Forms.CheckBox();
            this.tieuhoa_5 = new System.Windows.Forms.CheckBox();
            this.tieuhoa_2 = new System.Windows.Forms.CheckBox();
            this.tieuhoa_4 = new System.Windows.Forms.CheckBox();
            this.tieuhoa_1 = new System.Windows.Forms.CheckBox();
            this.tieuhoa_k = new System.Windows.Forms.CheckBox();
            this.label22 = new System.Windows.Forms.Label();
            this.noitiet = new System.Windows.Forms.TextBox();
            this.noitiet_6 = new System.Windows.Forms.CheckBox();
            this.noitiet_3 = new System.Windows.Forms.CheckBox();
            this.noitiet_5 = new System.Windows.Forms.CheckBox();
            this.noitiet_2 = new System.Windows.Forms.CheckBox();
            this.noitiet_4 = new System.Windows.Forms.CheckBox();
            this.noitiet_1 = new System.Windows.Forms.CheckBox();
            this.noitiet_k = new System.Windows.Forms.CheckBox();
            this.label21 = new System.Windows.Forms.Label();
            this.than = new System.Windows.Forms.TextBox();
            this.than_4 = new System.Windows.Forms.CheckBox();
            this.than_3 = new System.Windows.Forms.CheckBox();
            this.than_2 = new System.Windows.Forms.CheckBox();
            this.than_1 = new System.Windows.Forms.CheckBox();
            this.than_k = new System.Windows.Forms.CheckBox();
            this.label20 = new System.Windows.Forms.Label();
            this.hh = new System.Windows.Forms.TextBox();
            this.hh_7 = new System.Windows.Forms.CheckBox();
            this.hh_6 = new System.Windows.Forms.CheckBox();
            this.hh_3 = new System.Windows.Forms.CheckBox();
            this.hh_5 = new System.Windows.Forms.CheckBox();
            this.hh_2 = new System.Windows.Forms.CheckBox();
            this.hh_4 = new System.Windows.Forms.CheckBox();
            this.hh_1 = new System.Windows.Forms.CheckBox();
            this.hh_k = new System.Windows.Forms.CheckBox();
            this.label19 = new System.Windows.Forms.Label();
            this.tm = new System.Windows.Forms.TextBox();
            this.tm_7 = new System.Windows.Forms.CheckBox();
            this.tm_6 = new System.Windows.Forms.CheckBox();
            this.tm_3 = new System.Windows.Forms.CheckBox();
            this.tm_5 = new System.Windows.Forms.CheckBox();
            this.tm_2 = new System.Windows.Forms.CheckBox();
            this.tm_4 = new System.Windows.Forms.CheckBox();
            this.tm_1 = new System.Windows.Forms.CheckBox();
            this.tm_k = new System.Windows.Forms.CheckBox();
            this.label18 = new System.Windows.Forms.Label();
            this.diung = new System.Windows.Forms.TextBox();
            this.diung_k = new System.Windows.Forms.CheckBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.chieucao = new MaskedTextBox.MaskedTextBox();
            this.cannang = new MaskedTextBox.MaskedTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.nhietdo = new MaskedBox.MaskedBox();
            this.huyetap = new MaskedTextBox.MaskedTextBox();
            this.nhiptho = new MaskedTextBox.MaskedTextBox();
            this.mach = new MaskedTextBox.MaskedTextBox();
            this.label149 = new System.Windows.Forms.Label();
            this.label150 = new System.Windows.Forms.Label();
            this.label151 = new System.Windows.Forms.Label();
            this.label152 = new System.Windows.Forms.Label();
            this.label155 = new System.Windows.Forms.Label();
            this.label156 = new System.Windows.Forms.Label();
            this.label157 = new System.Windows.Forms.Label();
            this.label158 = new System.Windows.Forms.Label();
            this.thuoc_k = new System.Windows.Forms.CheckBox();
            this.thuoc = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label33 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.asa = new System.Windows.Forms.ComboBox();
            this.kehoach = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.cls = new System.Windows.Forms.TextBox();
            this.kham = new System.Windows.Forms.TextBox();
            this.kham_3 = new System.Windows.Forms.CheckBox();
            this.kham_5 = new System.Windows.Forms.CheckBox();
            this.kham_2 = new System.Windows.Forms.CheckBox();
            this.kham_4 = new System.Windows.Forms.CheckBox();
            this.kham_1 = new System.Windows.Forms.CheckBox();
            this.label29 = new System.Windows.Forms.Label();
            this.thaoluan_3 = new System.Windows.Forms.CheckBox();
            this.thaoluan_5 = new System.Windows.Forms.CheckBox();
            this.thaoluan_2 = new System.Windows.Forms.CheckBox();
            this.thaoluan_4 = new System.Windows.Forms.CheckBox();
            this.thaoluan_1 = new System.Windows.Forms.CheckBox();
            this.label28 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.luuy = new System.Windows.Forms.TextBox();
            this.xn = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.lamsang = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // chandoan
            // 
            this.chandoan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.chandoan.Enabled = false;
            this.chandoan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chandoan.Location = new System.Drawing.Point(122, 67);
            this.chandoan.Name = "chandoan";
            this.chandoan.Size = new System.Drawing.Size(56, 21);
            this.chandoan.TabIndex = 71;
            // 
            // sothe
            // 
            this.sothe.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sothe.Enabled = false;
            this.sothe.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sothe.Location = new System.Drawing.Point(122, 67);
            this.sothe.Name = "sothe";
            this.sothe.Size = new System.Drawing.Size(56, 21);
            this.sothe.TabIndex = 63;
            // 
            // giuong
            // 
            this.giuong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.giuong.Enabled = false;
            this.giuong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.giuong.Location = new System.Drawing.Point(122, 67);
            this.giuong.Name = "giuong";
            this.giuong.Size = new System.Drawing.Size(56, 21);
            this.giuong.TabIndex = 70;
            // 
            // phong
            // 
            this.phong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.phong.Enabled = false;
            this.phong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phong.Location = new System.Drawing.Point(122, 67);
            this.phong.Name = "phong";
            this.phong.Size = new System.Drawing.Size(56, 21);
            this.phong.TabIndex = 69;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(122, 67);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 16);
            this.label13.TabIndex = 68;
            this.label13.Text = "Chẩn đoán :";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(122, 67);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 16);
            this.label12.TabIndex = 67;
            this.label12.Text = "Giường :";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(122, 67);
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
            this.ngayvv.Location = new System.Drawing.Point(122, 67);
            this.ngayvv.Name = "ngayvv";
            this.ngayvv.Size = new System.Drawing.Size(56, 21);
            this.ngayvv.TabIndex = 65;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(122, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 16);
            this.label7.TabIndex = 64;
            this.label7.Text = "Ngày :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(122, 67);
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
            this.diachi.Location = new System.Drawing.Point(122, 67);
            this.diachi.Name = "diachi";
            this.diachi.Size = new System.Drawing.Size(56, 21);
            this.diachi.TabIndex = 61;
            // 
            // phai
            // 
            this.phai.BackColor = System.Drawing.SystemColors.HighlightText;
            this.phai.Enabled = false;
            this.phai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phai.Location = new System.Drawing.Point(122, 67);
            this.phai.Name = "phai";
            this.phai.Size = new System.Drawing.Size(56, 21);
            this.phai.TabIndex = 60;
            // 
            // namsinh
            // 
            this.namsinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.namsinh.Enabled = false;
            this.namsinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namsinh.Location = new System.Drawing.Point(122, 67);
            this.namsinh.Name = "namsinh";
            this.namsinh.Size = new System.Drawing.Size(56, 21);
            this.namsinh.TabIndex = 59;
            // 
            // hoten
            // 
            this.hoten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.hoten.Enabled = false;
            this.hoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoten.Location = new System.Drawing.Point(122, 67);
            this.hoten.Name = "hoten";
            this.hoten.Size = new System.Drawing.Size(56, 21);
            this.hoten.TabIndex = 58;
            // 
            // mabn
            // 
            this.mabn.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabn.Enabled = false;
            this.mabn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabn.Location = new System.Drawing.Point(122, 67);
            this.mabn.Name = "mabn";
            this.mabn.Size = new System.Drawing.Size(56, 21);
            this.mabn.TabIndex = 52;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(122, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 16);
            this.label5.TabIndex = 57;
            this.label5.Text = "Địa chỉ :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(122, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 16);
            this.label4.TabIndex = 56;
            this.label4.Text = "Giới tính :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(122, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 16);
            this.label3.TabIndex = 55;
            this.label3.Text = "NS :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(122, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 54;
            this.label1.Text = "Họ tên :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(122, 67);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 16);
            this.label10.TabIndex = 53;
            this.label10.Text = "Mã BN :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(122, 67);
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
            this.sovaovien.Location = new System.Drawing.Point(122, 67);
            this.sovaovien.Name = "sovaovien";
            this.sovaovien.Size = new System.Drawing.Size(56, 21);
            this.sovaovien.TabIndex = 73;
            // 
            // gio
            // 
            this.gio.BackColor = System.Drawing.SystemColors.HighlightText;
            this.gio.Enabled = false;
            this.gio.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gio.Location = new System.Drawing.Point(170, 3);
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
            this.ngay.Location = new System.Drawing.Point(69, 3);
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
            this.label88.Location = new System.Drawing.Point(146, 6);
            this.label88.Name = "label88";
            this.label88.Size = new System.Drawing.Size(32, 16);
            this.label88.TabIndex = 302;
            this.label88.Text = "Giờ :";
            this.label88.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label90
            // 
            this.label90.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label90.Location = new System.Drawing.Point(-16, 6);
            this.label90.Name = "label90";
            this.label90.Size = new System.Drawing.Size(80, 16);
            this.label90.TabIndex = 301;
            this.label90.Text = "Ngày :";
            this.label90.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tenbs
            // 
            this.tenbs.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbs.Enabled = false;
            this.tenbs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbs.Location = new System.Drawing.Point(312, 3);
            this.tenbs.Name = "tenbs";
            this.tenbs.Size = new System.Drawing.Size(226, 21);
            this.tenbs.TabIndex = 4;
            this.tenbs.TextChanged += new System.EventHandler(this.tenbs_TextChanged);
            this.tenbs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbs_KeyDown);
            // 
            // mabs
            // 
            this.mabs.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mabs.Enabled = false;
            this.mabs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabs.Location = new System.Drawing.Point(269, 3);
            this.mabs.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.mabs.MaxLength = 9;
            this.mabs.Name = "mabs";
            this.mabs.Size = new System.Drawing.Size(41, 21);
            this.mabs.TabIndex = 3;
            this.mabs.Validated += new System.EventHandler(this.mabs_Validated);
            this.mabs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // label87
            // 
            this.label87.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label87.Location = new System.Drawing.Point(216, 6);
            this.label87.Name = "label87";
            this.label87.Size = new System.Drawing.Size(62, 16);
            this.label87.TabIndex = 300;
            this.label87.Text = "BS GMHS :";
            this.label87.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // butMoi
            // 
            this.butMoi.Location = new System.Drawing.Point(177, 537);
            this.butMoi.Name = "butMoi";
            this.butMoi.Size = new System.Drawing.Size(70, 25);
            this.butMoi.TabIndex = 8;
            this.butMoi.Text = "&Mới";
            this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
            // 
            // butSua
            // 
            this.butSua.Location = new System.Drawing.Point(247, 537);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(70, 25);
            this.butSua.TabIndex = 9;
            this.butSua.Text = "&Sữa";
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butLuu
            // 
            this.butLuu.Enabled = false;
            this.butLuu.Location = new System.Drawing.Point(317, 537);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 6;
            this.butLuu.Text = "&Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Enabled = false;
            this.butBoqua.Location = new System.Drawing.Point(387, 537);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(70, 25);
            this.butBoqua.TabIndex = 7;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butHuy
            // 
            this.butHuy.Location = new System.Drawing.Point(457, 537);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(70, 25);
            this.butHuy.TabIndex = 10;
            this.butHuy.Text = "&Hủy";
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // butIn
            // 
            this.butIn.Location = new System.Drawing.Point(527, 537);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 11;
            this.butIn.Text = "&In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Location = new System.Drawing.Point(597, 537);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 12;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // listNv
            // 
            this.listNv.BackColor = System.Drawing.SystemColors.Info;
            this.listNv.ColumnCount = 0;
            this.listNv.Location = new System.Drawing.Point(96, 544);
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
            this.chkXML.Location = new System.Drawing.Point(8, 536);
            this.chkXML.Name = "chkXML";
            this.chkXML.Size = new System.Drawing.Size(104, 24);
            this.chkXML.TabIndex = 313;
            this.chkXML.Text = "Xuất ra XML";
            // 
            // label30
            // 
            this.label30.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.Location = new System.Drawing.Point(540, 4);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(48, 16);
            this.label30.TabIndex = 352;
            this.label30.Text = "Ngày :";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbngay
            // 
            this.cmbngay.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cmbngay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbngay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbngay.Location = new System.Drawing.Point(588, 3);
            this.cmbngay.Name = "cmbngay";
            this.cmbngay.Size = new System.Drawing.Size(235, 21);
            this.cmbngay.TabIndex = 0;
            this.cmbngay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(4, 25);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(819, 509);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.huyethoc);
            this.tabPage1.Controls.Add(this.huyethoc_3);
            this.tabPage1.Controls.Add(this.huyethoc_2);
            this.tabPage1.Controls.Add(this.huyethoc_1);
            this.tabPage1.Controls.Add(this.huyethoc_k);
            this.tabPage1.Controls.Add(this.label24);
            this.tabPage1.Controls.Add(this.thankinh_2);
            this.tabPage1.Controls.Add(this.thankinh_3);
            this.tabPage1.Controls.Add(this.thankinh_4);
            this.tabPage1.Controls.Add(this.thankinh_1);
            this.tabPage1.Controls.Add(this.thankinh_k);
            this.tabPage1.Controls.Add(this.label23);
            this.tabPage1.Controls.Add(this.tieuhoa);
            this.tabPage1.Controls.Add(this.tieuhoa_7);
            this.tabPage1.Controls.Add(this.tieuhoa_6);
            this.tabPage1.Controls.Add(this.tieuhoa_3);
            this.tabPage1.Controls.Add(this.tieuhoa_5);
            this.tabPage1.Controls.Add(this.tieuhoa_2);
            this.tabPage1.Controls.Add(this.tieuhoa_4);
            this.tabPage1.Controls.Add(this.tieuhoa_1);
            this.tabPage1.Controls.Add(this.tieuhoa_k);
            this.tabPage1.Controls.Add(this.label22);
            this.tabPage1.Controls.Add(this.noitiet);
            this.tabPage1.Controls.Add(this.noitiet_6);
            this.tabPage1.Controls.Add(this.noitiet_3);
            this.tabPage1.Controls.Add(this.noitiet_5);
            this.tabPage1.Controls.Add(this.noitiet_2);
            this.tabPage1.Controls.Add(this.noitiet_4);
            this.tabPage1.Controls.Add(this.noitiet_1);
            this.tabPage1.Controls.Add(this.noitiet_k);
            this.tabPage1.Controls.Add(this.label21);
            this.tabPage1.Controls.Add(this.than);
            this.tabPage1.Controls.Add(this.than_4);
            this.tabPage1.Controls.Add(this.than_3);
            this.tabPage1.Controls.Add(this.than_2);
            this.tabPage1.Controls.Add(this.than_1);
            this.tabPage1.Controls.Add(this.than_k);
            this.tabPage1.Controls.Add(this.label20);
            this.tabPage1.Controls.Add(this.hh);
            this.tabPage1.Controls.Add(this.hh_7);
            this.tabPage1.Controls.Add(this.hh_6);
            this.tabPage1.Controls.Add(this.hh_3);
            this.tabPage1.Controls.Add(this.hh_5);
            this.tabPage1.Controls.Add(this.hh_2);
            this.tabPage1.Controls.Add(this.hh_4);
            this.tabPage1.Controls.Add(this.hh_1);
            this.tabPage1.Controls.Add(this.hh_k);
            this.tabPage1.Controls.Add(this.label19);
            this.tabPage1.Controls.Add(this.tm);
            this.tabPage1.Controls.Add(this.tm_7);
            this.tabPage1.Controls.Add(this.tm_6);
            this.tabPage1.Controls.Add(this.tm_3);
            this.tabPage1.Controls.Add(this.tm_5);
            this.tabPage1.Controls.Add(this.tm_2);
            this.tabPage1.Controls.Add(this.tm_4);
            this.tabPage1.Controls.Add(this.tm_1);
            this.tabPage1.Controls.Add(this.tm_k);
            this.tabPage1.Controls.Add(this.label18);
            this.tabPage1.Controls.Add(this.diung);
            this.tabPage1.Controls.Add(this.diung_k);
            this.tabPage1.Controls.Add(this.label17);
            this.tabPage1.Controls.Add(this.label16);
            this.tabPage1.Controls.Add(this.label15);
            this.tabPage1.Controls.Add(this.chieucao);
            this.tabPage1.Controls.Add(this.cannang);
            this.tabPage1.Controls.Add(this.label14);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.nhietdo);
            this.tabPage1.Controls.Add(this.huyetap);
            this.tabPage1.Controls.Add(this.nhiptho);
            this.tabPage1.Controls.Add(this.mach);
            this.tabPage1.Controls.Add(this.label149);
            this.tabPage1.Controls.Add(this.label150);
            this.tabPage1.Controls.Add(this.label151);
            this.tabPage1.Controls.Add(this.label152);
            this.tabPage1.Controls.Add(this.label155);
            this.tabPage1.Controls.Add(this.label156);
            this.tabPage1.Controls.Add(this.label157);
            this.tabPage1.Controls.Add(this.label158);
            this.tabPage1.Controls.Add(this.thuoc_k);
            this.tabPage1.Controls.Add(this.thuoc);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(811, 483);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Trang 1";
            // 
            // huyethoc
            // 
            this.huyethoc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.huyethoc.Enabled = false;
            this.huyethoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.huyethoc.Location = new System.Drawing.Point(439, 460);
            this.huyethoc.Name = "huyethoc";
            this.huyethoc.Size = new System.Drawing.Size(369, 21);
            this.huyethoc.TabIndex = 60;
            this.huyethoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // huyethoc_3
            // 
            this.huyethoc_3.Enabled = false;
            this.huyethoc_3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.huyethoc_3.Location = new System.Drawing.Point(392, 463);
            this.huyethoc_3.Name = "huyethoc_3";
            this.huyethoc_3.Size = new System.Drawing.Size(56, 16);
            this.huyethoc_3.TabIndex = 59;
            this.huyethoc_3.Text = "Khác";
            this.huyethoc_3.CheckedChanged += new System.EventHandler(this.huyethoc_3_CheckedChanged);
            this.huyethoc_3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // huyethoc_2
            // 
            this.huyethoc_2.Enabled = false;
            this.huyethoc_2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.huyethoc_2.Location = new System.Drawing.Point(632, 441);
            this.huyethoc_2.Name = "huyethoc_2";
            this.huyethoc_2.Size = new System.Drawing.Size(116, 16);
            this.huyethoc_2.TabIndex = 58;
            this.huyethoc_2.Text = "RL đông máu";
            this.huyethoc_2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // huyethoc_1
            // 
            this.huyethoc_1.Enabled = false;
            this.huyethoc_1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.huyethoc_1.Location = new System.Drawing.Point(392, 441);
            this.huyethoc_1.Name = "huyethoc_1";
            this.huyethoc_1.Size = new System.Drawing.Size(96, 16);
            this.huyethoc_1.TabIndex = 57;
            this.huyethoc_1.Text = "Thiếu máu";
            this.huyethoc_1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // huyethoc_k
            // 
            this.huyethoc_k.Enabled = false;
            this.huyethoc_k.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.huyethoc_k.Location = new System.Drawing.Point(712, 422);
            this.huyethoc_k.Name = "huyethoc_k";
            this.huyethoc_k.Size = new System.Drawing.Size(56, 16);
            this.huyethoc_k.TabIndex = 56;
            this.huyethoc_k.Text = "Không";
            this.huyethoc_k.CheckedChanged += new System.EventHandler(this.huyethoc_k_CheckedChanged);
            this.huyethoc_k.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // label24
            // 
            this.label24.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label24.Location = new System.Drawing.Point(384, 422);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(225, 16);
            this.label24.TabIndex = 404;
            this.label24.Text = "Bệnh lý huyết học :";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // thankinh_2
            // 
            this.thankinh_2.Enabled = false;
            this.thankinh_2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thankinh_2.Location = new System.Drawing.Point(632, 384);
            this.thankinh_2.Name = "thankinh_2";
            this.thankinh_2.Size = new System.Drawing.Size(137, 16);
            this.thankinh_2.TabIndex = 53;
            this.thankinh_2.Text = "Tâm thần";
            this.thankinh_2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // thankinh_3
            // 
            this.thankinh_3.Enabled = false;
            this.thankinh_3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thankinh_3.Location = new System.Drawing.Point(392, 402);
            this.thankinh_3.Name = "thankinh_3";
            this.thankinh_3.Size = new System.Drawing.Size(116, 16);
            this.thankinh_3.TabIndex = 54;
            this.thankinh_3.Text = "Động kinh";
            this.thankinh_3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // thankinh_4
            // 
            this.thankinh_4.Enabled = false;
            this.thankinh_4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thankinh_4.Location = new System.Drawing.Point(632, 402);
            this.thankinh_4.Name = "thankinh_4";
            this.thankinh_4.Size = new System.Drawing.Size(136, 16);
            this.thankinh_4.TabIndex = 55;
            this.thankinh_4.Text = "Chấn thương cột sống";
            this.thankinh_4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // thankinh_1
            // 
            this.thankinh_1.Enabled = false;
            this.thankinh_1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thankinh_1.Location = new System.Drawing.Point(392, 384);
            this.thankinh_1.Name = "thankinh_1";
            this.thankinh_1.Size = new System.Drawing.Size(144, 16);
            this.thankinh_1.TabIndex = 52;
            this.thankinh_1.Text = "Tăng áp lực nội sọ";
            this.thankinh_1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // thankinh_k
            // 
            this.thankinh_k.Enabled = false;
            this.thankinh_k.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thankinh_k.Location = new System.Drawing.Point(712, 365);
            this.thankinh_k.Name = "thankinh_k";
            this.thankinh_k.Size = new System.Drawing.Size(56, 16);
            this.thankinh_k.TabIndex = 51;
            this.thankinh_k.Text = "Không";
            this.thankinh_k.CheckedChanged += new System.EventHandler(this.thankinh_k_CheckedChanged);
            this.thankinh_k.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // label23
            // 
            this.label23.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label23.Location = new System.Drawing.Point(384, 365);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(225, 16);
            this.label23.TabIndex = 397;
            this.label23.Text = "Bệnh lý thần kinh trung ương :";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tieuhoa
            // 
            this.tieuhoa.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tieuhoa.Enabled = false;
            this.tieuhoa.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tieuhoa.Location = new System.Drawing.Point(64, 459);
            this.tieuhoa.Name = "tieuhoa";
            this.tieuhoa.Size = new System.Drawing.Size(296, 21);
            this.tieuhoa.TabIndex = 25;
            this.tieuhoa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // tieuhoa_7
            // 
            this.tieuhoa_7.Enabled = false;
            this.tieuhoa_7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tieuhoa_7.Location = new System.Drawing.Point(16, 459);
            this.tieuhoa_7.Name = "tieuhoa_7";
            this.tieuhoa_7.Size = new System.Drawing.Size(56, 16);
            this.tieuhoa_7.TabIndex = 24;
            this.tieuhoa_7.Text = "Khác";
            this.tieuhoa_7.CheckedChanged += new System.EventHandler(this.tieuhoa_7_CheckedChanged);
            this.tieuhoa_7.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // tieuhoa_6
            // 
            this.tieuhoa_6.Enabled = false;
            this.tieuhoa_6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tieuhoa_6.Location = new System.Drawing.Point(256, 441);
            this.tieuhoa_6.Name = "tieuhoa_6";
            this.tieuhoa_6.Size = new System.Drawing.Size(120, 16);
            this.tieuhoa_6.TabIndex = 23;
            this.tieuhoa_6.Text = "RL CN gan";
            this.tieuhoa_6.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // tieuhoa_3
            // 
            this.tieuhoa_3.Enabled = false;
            this.tieuhoa_3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tieuhoa_3.Location = new System.Drawing.Point(256, 423);
            this.tieuhoa_3.Name = "tieuhoa_3";
            this.tieuhoa_3.Size = new System.Drawing.Size(112, 16);
            this.tieuhoa_3.TabIndex = 20;
            this.tieuhoa_3.Text = "Trào ngược";
            this.tieuhoa_3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // tieuhoa_5
            // 
            this.tieuhoa_5.Enabled = false;
            this.tieuhoa_5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tieuhoa_5.Location = new System.Drawing.Point(136, 441);
            this.tieuhoa_5.Name = "tieuhoa_5";
            this.tieuhoa_5.Size = new System.Drawing.Size(104, 16);
            this.tieuhoa_5.TabIndex = 22;
            this.tieuhoa_5.Text = "Viêm gan";
            this.tieuhoa_5.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // tieuhoa_2
            // 
            this.tieuhoa_2.Enabled = false;
            this.tieuhoa_2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tieuhoa_2.Location = new System.Drawing.Point(136, 423);
            this.tieuhoa_2.Name = "tieuhoa_2";
            this.tieuhoa_2.Size = new System.Drawing.Size(80, 16);
            this.tieuhoa_2.TabIndex = 19;
            this.tieuhoa_2.Text = "Tắt ruột";
            this.tieuhoa_2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // tieuhoa_4
            // 
            this.tieuhoa_4.Enabled = false;
            this.tieuhoa_4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tieuhoa_4.Location = new System.Drawing.Point(16, 441);
            this.tieuhoa_4.Name = "tieuhoa_4";
            this.tieuhoa_4.Size = new System.Drawing.Size(104, 16);
            this.tieuhoa_4.TabIndex = 21;
            this.tieuhoa_4.Text = "Thoát vị hoành";
            this.tieuhoa_4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // tieuhoa_1
            // 
            this.tieuhoa_1.Enabled = false;
            this.tieuhoa_1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tieuhoa_1.Location = new System.Drawing.Point(16, 419);
            this.tieuhoa_1.Name = "tieuhoa_1";
            this.tieuhoa_1.Size = new System.Drawing.Size(96, 24);
            this.tieuhoa_1.TabIndex = 18;
            this.tieuhoa_1.Text = "Ăn uống";
            this.tieuhoa_1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // tieuhoa_k
            // 
            this.tieuhoa_k.Enabled = false;
            this.tieuhoa_k.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tieuhoa_k.Location = new System.Drawing.Point(304, 404);
            this.tieuhoa_k.Name = "tieuhoa_k";
            this.tieuhoa_k.Size = new System.Drawing.Size(56, 16);
            this.tieuhoa_k.TabIndex = 17;
            this.tieuhoa_k.Text = "Không";
            this.tieuhoa_k.CheckedChanged += new System.EventHandler(this.tieuhoa_k_CheckedChanged);
            this.tieuhoa_k.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // label22
            // 
            this.label22.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label22.Location = new System.Drawing.Point(8, 404);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(128, 16);
            this.label22.TabIndex = 387;
            this.label22.Text = "Bệnh lý tiêu hóa :";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // noitiet
            // 
            this.noitiet.BackColor = System.Drawing.SystemColors.HighlightText;
            this.noitiet.Enabled = false;
            this.noitiet.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noitiet.Location = new System.Drawing.Point(439, 337);
            this.noitiet.Name = "noitiet";
            this.noitiet.Size = new System.Drawing.Size(369, 21);
            this.noitiet.TabIndex = 50;
            this.noitiet.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // noitiet_6
            // 
            this.noitiet_6.Enabled = false;
            this.noitiet_6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noitiet_6.Location = new System.Drawing.Point(391, 339);
            this.noitiet_6.Name = "noitiet_6";
            this.noitiet_6.Size = new System.Drawing.Size(56, 16);
            this.noitiet_6.TabIndex = 49;
            this.noitiet_6.Text = "Khác";
            this.noitiet_6.CheckedChanged += new System.EventHandler(this.noitiet_6_CheckedChanged);
            this.noitiet_6.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // noitiet_3
            // 
            this.noitiet_3.Enabled = false;
            this.noitiet_3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noitiet_3.Location = new System.Drawing.Point(631, 301);
            this.noitiet_3.Name = "noitiet_3";
            this.noitiet_3.Size = new System.Drawing.Size(137, 16);
            this.noitiet_3.TabIndex = 46;
            this.noitiet_3.Text = "TC dùng Corticoide";
            this.noitiet_3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // noitiet_5
            // 
            this.noitiet_5.Enabled = false;
            this.noitiet_5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noitiet_5.Location = new System.Drawing.Point(511, 319);
            this.noitiet_5.Name = "noitiet_5";
            this.noitiet_5.Size = new System.Drawing.Size(137, 16);
            this.noitiet_5.TabIndex = 48;
            this.noitiet_5.Text = "TC sốt cao ác tính";
            this.noitiet_5.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // noitiet_2
            // 
            this.noitiet_2.Enabled = false;
            this.noitiet_2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noitiet_2.Location = new System.Drawing.Point(511, 301);
            this.noitiet_2.Name = "noitiet_2";
            this.noitiet_2.Size = new System.Drawing.Size(116, 16);
            this.noitiet_2.TabIndex = 45;
            this.noitiet_2.Text = "Bệnh lý tuyết giáp";
            this.noitiet_2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // noitiet_4
            // 
            this.noitiet_4.Enabled = false;
            this.noitiet_4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noitiet_4.Location = new System.Drawing.Point(391, 319);
            this.noitiet_4.Name = "noitiet_4";
            this.noitiet_4.Size = new System.Drawing.Size(80, 16);
            this.noitiet_4.TabIndex = 47;
            this.noitiet_4.Text = "Béo phì";
            this.noitiet_4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // noitiet_1
            // 
            this.noitiet_1.Enabled = false;
            this.noitiet_1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noitiet_1.Location = new System.Drawing.Point(391, 301);
            this.noitiet_1.Name = "noitiet_1";
            this.noitiet_1.Size = new System.Drawing.Size(96, 16);
            this.noitiet_1.TabIndex = 44;
            this.noitiet_1.Text = "Tiểu đường";
            this.noitiet_1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // noitiet_k
            // 
            this.noitiet_k.Enabled = false;
            this.noitiet_k.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noitiet_k.Location = new System.Drawing.Point(711, 281);
            this.noitiet_k.Name = "noitiet_k";
            this.noitiet_k.Size = new System.Drawing.Size(56, 16);
            this.noitiet_k.TabIndex = 43;
            this.noitiet_k.Text = "Không";
            this.noitiet_k.CheckedChanged += new System.EventHandler(this.noitiet_k_CheckedChanged);
            this.noitiet_k.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // label21
            // 
            this.label21.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label21.Location = new System.Drawing.Point(383, 281);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(225, 16);
            this.label21.TabIndex = 377;
            this.label21.Text = "Bệnh lý nội tiết - Chuyển hóa :";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // than
            // 
            this.than.BackColor = System.Drawing.SystemColors.HighlightText;
            this.than.Enabled = false;
            this.than.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.than.Location = new System.Drawing.Point(64, 375);
            this.than.Name = "than";
            this.than.Size = new System.Drawing.Size(296, 21);
            this.than.TabIndex = 16;
            this.than.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // than_4
            // 
            this.than_4.Enabled = false;
            this.than_4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.than_4.Location = new System.Drawing.Point(16, 375);
            this.than_4.Name = "than_4";
            this.than_4.Size = new System.Drawing.Size(56, 16);
            this.than_4.TabIndex = 15;
            this.than_4.Text = "Khác";
            this.than_4.CheckedChanged += new System.EventHandler(this.than_4_CheckedChanged);
            this.than_4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // than_3
            // 
            this.than_3.Enabled = false;
            this.than_3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.than_3.Location = new System.Drawing.Point(256, 355);
            this.than_3.Name = "than_3";
            this.than_3.Size = new System.Drawing.Size(72, 16);
            this.than_3.TabIndex = 14;
            this.than_3.Text = "NT tiểu";
            this.than_3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // than_2
            // 
            this.than_2.Enabled = false;
            this.than_2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.than_2.Location = new System.Drawing.Point(136, 355);
            this.than_2.Name = "than_2";
            this.than_2.Size = new System.Drawing.Size(104, 16);
            this.than_2.TabIndex = 13;
            this.than_2.Text = "Suy thận mãn";
            this.than_2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // than_1
            // 
            this.than_1.Enabled = false;
            this.than_1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.than_1.Location = new System.Drawing.Point(16, 355);
            this.than_1.Name = "than_1";
            this.than_1.Size = new System.Drawing.Size(96, 16);
            this.than_1.TabIndex = 12;
            this.than_1.Text = "Suy thận cấp";
            this.than_1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // than_k
            // 
            this.than_k.Enabled = false;
            this.than_k.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.than_k.Location = new System.Drawing.Point(304, 335);
            this.than_k.Name = "than_k";
            this.than_k.Size = new System.Drawing.Size(56, 16);
            this.than_k.TabIndex = 11;
            this.than_k.Text = "Không";
            this.than_k.CheckedChanged += new System.EventHandler(this.than_k_CheckedChanged);
            this.than_k.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // label20
            // 
            this.label20.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label20.Location = new System.Drawing.Point(8, 335);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(128, 16);
            this.label20.TabIndex = 367;
            this.label20.Text = "Bệnh lý thận :";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // hh
            // 
            this.hh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.hh.Enabled = false;
            this.hh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hh.Location = new System.Drawing.Point(440, 251);
            this.hh.Name = "hh";
            this.hh.Size = new System.Drawing.Size(368, 21);
            this.hh.TabIndex = 42;
            this.hh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // hh_7
            // 
            this.hh_7.Enabled = false;
            this.hh_7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hh_7.Location = new System.Drawing.Point(392, 253);
            this.hh_7.Name = "hh_7";
            this.hh_7.Size = new System.Drawing.Size(56, 16);
            this.hh_7.TabIndex = 41;
            this.hh_7.Text = "Khác";
            this.hh_7.CheckedChanged += new System.EventHandler(this.hh_7_CheckedChanged);
            this.hh_7.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // hh_6
            // 
            this.hh_6.Enabled = false;
            this.hh_6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hh_6.Location = new System.Drawing.Point(632, 233);
            this.hh_6.Name = "hh_6";
            this.hh_6.Size = new System.Drawing.Size(120, 16);
            this.hh_6.TabIndex = 40;
            this.hh_6.Text = "TC V. hô hấp cấp";
            this.hh_6.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // hh_3
            // 
            this.hh_3.Enabled = false;
            this.hh_3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hh_3.Location = new System.Drawing.Point(632, 215);
            this.hh_3.Name = "hh_3";
            this.hh_3.Size = new System.Drawing.Size(112, 16);
            this.hh_3.TabIndex = 37;
            this.hh_3.Text = "Tâm phế mãn";
            this.hh_3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // hh_5
            // 
            this.hh_5.Enabled = false;
            this.hh_5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hh_5.Location = new System.Drawing.Point(512, 233);
            this.hh_5.Name = "hh_5";
            this.hh_5.Size = new System.Drawing.Size(104, 16);
            this.hh_5.TabIndex = 39;
            this.hh_5.Text = "Chít hẹp";
            this.hh_5.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // hh_2
            // 
            this.hh_2.Enabled = false;
            this.hh_2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hh_2.Location = new System.Drawing.Point(512, 215);
            this.hh_2.Name = "hh_2";
            this.hh_2.Size = new System.Drawing.Size(80, 16);
            this.hh_2.TabIndex = 36;
            this.hh_2.Text = "Hút thuốc";
            this.hh_2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // hh_4
            // 
            this.hh_4.Enabled = false;
            this.hh_4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hh_4.Location = new System.Drawing.Point(392, 233);
            this.hh_4.Name = "hh_4";
            this.hh_4.Size = new System.Drawing.Size(80, 16);
            this.hh_4.TabIndex = 38;
            this.hh_4.Text = "Hen PQ";
            this.hh_4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // hh_1
            // 
            this.hh_1.Enabled = false;
            this.hh_1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hh_1.Location = new System.Drawing.Point(392, 215);
            this.hh_1.Name = "hh_1";
            this.hh_1.Size = new System.Drawing.Size(96, 16);
            this.hh_1.TabIndex = 35;
            this.hh_1.Text = "Khó thở";
            this.hh_1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // hh_k
            // 
            this.hh_k.Enabled = false;
            this.hh_k.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hh_k.Location = new System.Drawing.Point(712, 195);
            this.hh_k.Name = "hh_k";
            this.hh_k.Size = new System.Drawing.Size(56, 16);
            this.hh_k.TabIndex = 34;
            this.hh_k.Text = "Không";
            this.hh_k.CheckedChanged += new System.EventHandler(this.hh_k_CheckedChanged);
            this.hh_k.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label19.Location = new System.Drawing.Point(384, 195);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(128, 16);
            this.label19.TabIndex = 357;
            this.label19.Text = "Bệnh lý hô hấp :";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tm
            // 
            this.tm.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tm.Enabled = false;
            this.tm.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tm.Location = new System.Drawing.Point(64, 305);
            this.tm.Name = "tm";
            this.tm.Size = new System.Drawing.Size(296, 21);
            this.tm.TabIndex = 10;
            this.tm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // tm_7
            // 
            this.tm_7.Enabled = false;
            this.tm_7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tm_7.Location = new System.Drawing.Point(16, 307);
            this.tm_7.Name = "tm_7";
            this.tm_7.Size = new System.Drawing.Size(56, 16);
            this.tm_7.TabIndex = 9;
            this.tm_7.Text = "Khác";
            this.tm_7.CheckedChanged += new System.EventHandler(this.tm_7_CheckedChanged);
            this.tm_7.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // tm_6
            // 
            this.tm_6.Enabled = false;
            this.tm_6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tm_6.Location = new System.Drawing.Point(256, 287);
            this.tm_6.Name = "tm_6";
            this.tm_6.Size = new System.Drawing.Size(112, 16);
            this.tm_6.TabIndex = 8;
            this.tm_6.Text = "Loạn nhịp tim";
            this.tm_6.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // tm_3
            // 
            this.tm_3.Enabled = false;
            this.tm_3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tm_3.Location = new System.Drawing.Point(256, 269);
            this.tm_3.Name = "tm_3";
            this.tm_3.Size = new System.Drawing.Size(72, 16);
            this.tm_3.TabIndex = 5;
            this.tm_3.Text = "Suy tim";
            this.tm_3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // tm_5
            // 
            this.tm_5.Enabled = false;
            this.tm_5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tm_5.Location = new System.Drawing.Point(137, 287);
            this.tm_5.Name = "tm_5";
            this.tm_5.Size = new System.Drawing.Size(104, 16);
            this.tm_5.TabIndex = 7;
            this.tm_5.Text = "Bệnh van tim";
            this.tm_5.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // tm_2
            // 
            this.tm_2.Enabled = false;
            this.tm_2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tm_2.Location = new System.Drawing.Point(137, 269);
            this.tm_2.Name = "tm_2";
            this.tm_2.Size = new System.Drawing.Size(56, 16);
            this.tm_2.TabIndex = 4;
            this.tm_2.Text = "NMCT";
            this.tm_2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // tm_4
            // 
            this.tm_4.Enabled = false;
            this.tm_4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tm_4.Location = new System.Drawing.Point(16, 287);
            this.tm_4.Name = "tm_4";
            this.tm_4.Size = new System.Drawing.Size(80, 16);
            this.tm_4.TabIndex = 6;
            this.tm_4.Text = "Cao HA";
            this.tm_4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // tm_1
            // 
            this.tm_1.Enabled = false;
            this.tm_1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tm_1.Location = new System.Drawing.Point(16, 269);
            this.tm_1.Name = "tm_1";
            this.tm_1.Size = new System.Drawing.Size(96, 16);
            this.tm_1.TabIndex = 3;
            this.tm_1.Text = "Đau thắt ngực";
            this.tm_1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // tm_k
            // 
            this.tm_k.Enabled = false;
            this.tm_k.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tm_k.Location = new System.Drawing.Point(304, 248);
            this.tm_k.Name = "tm_k";
            this.tm_k.Size = new System.Drawing.Size(56, 16);
            this.tm_k.TabIndex = 2;
            this.tm_k.Text = "Không";
            this.tm_k.CheckedChanged += new System.EventHandler(this.tm_k_CheckedChanged);
            this.tm_k.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label18.Location = new System.Drawing.Point(8, 248);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(128, 16);
            this.label18.TabIndex = 347;
            this.label18.Text = "Bệnh lý tim mạch :";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // diung
            // 
            this.diung.BackColor = System.Drawing.SystemColors.HighlightText;
            this.diung.Enabled = false;
            this.diung.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diung.Location = new System.Drawing.Point(432, 70);
            this.diung.Multiline = true;
            this.diung.Name = "diung";
            this.diung.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.diung.Size = new System.Drawing.Size(376, 119);
            this.diung.TabIndex = 33;
            // 
            // diung_k
            // 
            this.diung_k.Enabled = false;
            this.diung_k.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diung_k.Location = new System.Drawing.Point(712, 54);
            this.diung_k.Name = "diung_k";
            this.diung_k.Size = new System.Drawing.Size(56, 16);
            this.diung_k.TabIndex = 32;
            this.diung_k.Text = "Không";
            this.diung_k.CheckedChanged += new System.EventHandler(this.diung_k_CheckedChanged);
            this.diung_k.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label17.Location = new System.Drawing.Point(384, 54);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(104, 16);
            this.label17.TabIndex = 344;
            this.label17.Text = "Dị ứng :";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(617, 8);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(24, 19);
            this.label16.TabIndex = 343;
            this.label16.Text = "cm";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(481, 8);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(24, 19);
            this.label15.TabIndex = 342;
            this.label15.Text = "kg";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chieucao
            // 
            this.chieucao.BackColor = System.Drawing.SystemColors.HighlightText;
            this.chieucao.Enabled = false;
            this.chieucao.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chieucao.Location = new System.Drawing.Point(569, 4);
            this.chieucao.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.chieucao.MaxLength = 5;
            this.chieucao.Name = "chieucao";
            this.chieucao.Size = new System.Drawing.Size(45, 21);
            this.chieucao.TabIndex = 27;
            this.chieucao.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cannang
            // 
            this.cannang.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cannang.Enabled = false;
            this.cannang.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cannang.Location = new System.Drawing.Point(433, 4);
            this.cannang.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
            this.cannang.MaxLength = 5;
            this.cannang.Name = "cannang";
            this.cannang.Size = new System.Drawing.Size(40, 21);
            this.cannang.TabIndex = 26;
            this.cannang.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(505, 8);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(64, 16);
            this.label14.TabIndex = 339;
            this.label14.Text = "Chiều cao :";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(369, 8);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 16);
            this.label9.TabIndex = 338;
            this.label9.Text = "Cân nặng :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nhietdo
            // 
            this.nhietdo.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nhietdo.Enabled = false;
            this.nhietdo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhietdo.Location = new System.Drawing.Point(433, 27);
            this.nhietdo.Mask = "##.##";
            this.nhietdo.Name = "nhietdo";
            this.nhietdo.Size = new System.Drawing.Size(40, 21);
            this.nhietdo.TabIndex = 29;
            this.nhietdo.Text = "  .  ";
            // 
            // huyetap
            // 
            this.huyetap.BackColor = System.Drawing.SystemColors.HighlightText;
            this.huyetap.Enabled = false;
            this.huyetap.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.huyetap.Location = new System.Drawing.Point(569, 27);
            this.huyetap.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.huyetap.MaxLength = 7;
            this.huyetap.Name = "huyetap";
            this.huyetap.Size = new System.Drawing.Size(45, 21);
            this.huyetap.TabIndex = 30;
            // 
            // nhiptho
            // 
            this.nhiptho.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nhiptho.Enabled = false;
            this.nhiptho.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhiptho.Location = new System.Drawing.Point(712, 27);
            this.nhiptho.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.nhiptho.MaxLength = 5;
            this.nhiptho.Name = "nhiptho";
            this.nhiptho.Size = new System.Drawing.Size(32, 21);
            this.nhiptho.TabIndex = 31;
            this.nhiptho.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // mach
            // 
            this.mach.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mach.Enabled = false;
            this.mach.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mach.Location = new System.Drawing.Point(712, 4);
            this.mach.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.mach.MaxLength = 5;
            this.mach.Name = "mach";
            this.mach.Size = new System.Drawing.Size(32, 21);
            this.mach.TabIndex = 28;
            this.mach.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label149
            // 
            this.label149.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label149.Location = new System.Drawing.Point(752, 8);
            this.label149.Name = "label149";
            this.label149.Size = new System.Drawing.Size(24, 19);
            this.label149.TabIndex = 334;
            this.label149.Text = "l/p";
            this.label149.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label150
            // 
            this.label150.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label150.Location = new System.Drawing.Point(481, 32);
            this.label150.Name = "label150";
            this.label150.Size = new System.Drawing.Size(24, 16);
            this.label150.TabIndex = 335;
            this.label150.Text = "°C";
            this.label150.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label151
            // 
            this.label151.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label151.Location = new System.Drawing.Point(617, 32);
            this.label151.Name = "label151";
            this.label151.Size = new System.Drawing.Size(38, 16);
            this.label151.TabIndex = 336;
            this.label151.Text = "mmHg";
            this.label151.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label152
            // 
            this.label152.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label152.Location = new System.Drawing.Point(745, 32);
            this.label152.Name = "label152";
            this.label152.Size = new System.Drawing.Size(24, 16);
            this.label152.TabIndex = 337;
            this.label152.Text = "l/p";
            this.label152.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label155
            // 
            this.label155.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label155.Location = new System.Drawing.Point(657, 32);
            this.label155.Name = "label155";
            this.label155.Size = new System.Drawing.Size(56, 16);
            this.label155.TabIndex = 333;
            this.label155.Text = "Nhịp thở :";
            this.label155.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label156
            // 
            this.label156.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label156.Location = new System.Drawing.Point(505, 32);
            this.label156.Name = "label156";
            this.label156.Size = new System.Drawing.Size(64, 16);
            this.label156.TabIndex = 332;
            this.label156.Text = "Huyết áp :";
            this.label156.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label157
            // 
            this.label157.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label157.Location = new System.Drawing.Point(377, 32);
            this.label157.Name = "label157";
            this.label157.Size = new System.Drawing.Size(56, 16);
            this.label157.TabIndex = 331;
            this.label157.Text = "Nhiệt độ :";
            this.label157.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label158
            // 
            this.label158.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label158.Location = new System.Drawing.Point(673, 8);
            this.label158.Name = "label158";
            this.label158.Size = new System.Drawing.Size(40, 16);
            this.label158.TabIndex = 330;
            this.label158.Text = "Mạch :";
            this.label158.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // thuoc_k
            // 
            this.thuoc_k.Enabled = false;
            this.thuoc_k.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thuoc_k.Location = new System.Drawing.Point(304, 6);
            this.thuoc_k.Name = "thuoc_k";
            this.thuoc_k.Size = new System.Drawing.Size(56, 16);
            this.thuoc_k.TabIndex = 0;
            this.thuoc_k.Text = "Không";
            this.thuoc_k.CheckedChanged += new System.EventHandler(this.thuoc_k_CheckedChanged);
            this.thuoc_k.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // thuoc
            // 
            this.thuoc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.thuoc.Enabled = false;
            this.thuoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thuoc.Location = new System.Drawing.Point(16, 24);
            this.thuoc.Multiline = true;
            this.thuoc.Name = "thuoc";
            this.thuoc.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.thuoc.Size = new System.Drawing.Size(344, 221);
            this.thuoc.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label8.Location = new System.Drawing.Point(8, 6);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 16);
            this.label8.TabIndex = 0;
            this.label8.Text = "Thuốc đang dùng :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label33);
            this.tabPage2.Controls.Add(this.label32);
            this.tabPage2.Controls.Add(this.asa);
            this.tabPage2.Controls.Add(this.kehoach);
            this.tabPage2.Controls.Add(this.label31);
            this.tabPage2.Controls.Add(this.cls);
            this.tabPage2.Controls.Add(this.kham);
            this.tabPage2.Controls.Add(this.kham_3);
            this.tabPage2.Controls.Add(this.kham_5);
            this.tabPage2.Controls.Add(this.kham_2);
            this.tabPage2.Controls.Add(this.kham_4);
            this.tabPage2.Controls.Add(this.kham_1);
            this.tabPage2.Controls.Add(this.label29);
            this.tabPage2.Controls.Add(this.thaoluan_3);
            this.tabPage2.Controls.Add(this.thaoluan_5);
            this.tabPage2.Controls.Add(this.thaoluan_2);
            this.tabPage2.Controls.Add(this.thaoluan_4);
            this.tabPage2.Controls.Add(this.thaoluan_1);
            this.tabPage2.Controls.Add(this.label28);
            this.tabPage2.Controls.Add(this.label27);
            this.tabPage2.Controls.Add(this.label26);
            this.tabPage2.Controls.Add(this.luuy);
            this.tabPage2.Controls.Add(this.xn);
            this.tabPage2.Controls.Add(this.label25);
            this.tabPage2.Controls.Add(this.lamsang);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(811, 483);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Trang 2";
            // 
            // label33
            // 
            this.label33.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label33.Location = new System.Drawing.Point(392, 229);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(40, 16);
            this.label33.TabIndex = 419;
            this.label33.Text = "ASA :";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label32
            // 
            this.label32.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label32.Location = new System.Drawing.Point(392, 253);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(136, 16);
            this.label32.TabIndex = 418;
            this.label32.Text = "Kế hoạch và lưu ý :";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // asa
            // 
            this.asa.BackColor = System.Drawing.SystemColors.HighlightText;
            this.asa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.asa.Enabled = false;
            this.asa.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.asa.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.asa.Location = new System.Drawing.Point(432, 226);
            this.asa.Name = "asa";
            this.asa.Size = new System.Drawing.Size(336, 21);
            this.asa.TabIndex = 15;
            this.asa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // kehoach
            // 
            this.kehoach.BackColor = System.Drawing.SystemColors.HighlightText;
            this.kehoach.Enabled = false;
            this.kehoach.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kehoach.Location = new System.Drawing.Point(395, 272);
            this.kehoach.Multiline = true;
            this.kehoach.Name = "kehoach";
            this.kehoach.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.kehoach.Size = new System.Drawing.Size(413, 147);
            this.kehoach.TabIndex = 16;
            // 
            // label31
            // 
            this.label31.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label31.Location = new System.Drawing.Point(392, 68);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(136, 16);
            this.label31.TabIndex = 415;
            this.label31.Text = "ECG và các CLS khác :";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cls
            // 
            this.cls.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cls.Enabled = false;
            this.cls.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cls.Location = new System.Drawing.Point(395, 85);
            this.cls.Multiline = true;
            this.cls.Name = "cls";
            this.cls.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.cls.Size = new System.Drawing.Size(413, 139);
            this.cls.TabIndex = 14;
            // 
            // kham
            // 
            this.kham.BackColor = System.Drawing.SystemColors.HighlightText;
            this.kham.Enabled = false;
            this.kham.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kham.Location = new System.Drawing.Point(507, 41);
            this.kham.Name = "kham";
            this.kham.Size = new System.Drawing.Size(301, 21);
            this.kham.TabIndex = 13;
            this.kham.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // kham_3
            // 
            this.kham_3.Enabled = false;
            this.kham_3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kham_3.Location = new System.Drawing.Point(616, 24);
            this.kham_3.Name = "kham_3";
            this.kham_3.Size = new System.Drawing.Size(56, 16);
            this.kham_3.TabIndex = 10;
            this.kham_3.Text = "Răng";
            this.kham_3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // kham_5
            // 
            this.kham_5.Enabled = false;
            this.kham_5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kham_5.Location = new System.Drawing.Point(408, 44);
            this.kham_5.Name = "kham_5";
            this.kham_5.Size = new System.Drawing.Size(112, 16);
            this.kham_5.TabIndex = 12;
            this.kham_5.Text = "Bất thường khác";
            this.kham_5.CheckedChanged += new System.EventHandler(this.kham_5_CheckedChanged);
            this.kham_5.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // kham_2
            // 
            this.kham_2.Enabled = false;
            this.kham_2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kham_2.Location = new System.Drawing.Point(507, 24);
            this.kham_2.Name = "kham_2";
            this.kham_2.Size = new System.Drawing.Size(80, 16);
            this.kham_2.TabIndex = 9;
            this.kham_2.Text = "Mallampati";
            this.kham_2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // kham_4
            // 
            this.kham_4.Enabled = false;
            this.kham_4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kham_4.Location = new System.Drawing.Point(688, 24);
            this.kham_4.Name = "kham_4";
            this.kham_4.Size = new System.Drawing.Size(80, 16);
            this.kham_4.TabIndex = 11;
            this.kham_4.Text = "Di động cổ";
            this.kham_4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // kham_1
            // 
            this.kham_1.Enabled = false;
            this.kham_1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kham_1.Location = new System.Drawing.Point(408, 24);
            this.kham_1.Name = "kham_1";
            this.kham_1.Size = new System.Drawing.Size(72, 16);
            this.kham_1.TabIndex = 8;
            this.kham_1.Text = "Há miệng";
            this.kham_1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // label29
            // 
            this.label29.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label29.Location = new System.Drawing.Point(392, 6);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(112, 16);
            this.label29.TabIndex = 361;
            this.label29.Text = "Khám đường thở :";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // thaoluan_3
            // 
            this.thaoluan_3.Enabled = false;
            this.thaoluan_3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thaoluan_3.Location = new System.Drawing.Point(249, 443);
            this.thaoluan_3.Name = "thaoluan_3";
            this.thaoluan_3.Size = new System.Drawing.Size(136, 16);
            this.thaoluan_3.TabIndex = 5;
            this.thaoluan_3.Text = "Theo dõi HA xâm lấn";
            this.thaoluan_3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // thaoluan_5
            // 
            this.thaoluan_5.Enabled = false;
            this.thaoluan_5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thaoluan_5.Location = new System.Drawing.Point(153, 462);
            this.thaoluan_5.Name = "thaoluan_5";
            this.thaoluan_5.Size = new System.Drawing.Size(192, 16);
            this.thaoluan_5.TabIndex = 7;
            this.thaoluan_5.Text = "Giảm đau sau phẫu thuật";
            this.thaoluan_5.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // thaoluan_2
            // 
            this.thaoluan_2.Enabled = false;
            this.thaoluan_2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thaoluan_2.Location = new System.Drawing.Point(153, 443);
            this.thaoluan_2.Name = "thaoluan_2";
            this.thaoluan_2.Size = new System.Drawing.Size(88, 16);
            this.thaoluan_2.TabIndex = 4;
            this.thaoluan_2.Text = "Truyền máu";
            this.thaoluan_2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // thaoluan_4
            // 
            this.thaoluan_4.Enabled = false;
            this.thaoluan_4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thaoluan_4.Location = new System.Drawing.Point(17, 462);
            this.thaoluan_4.Name = "thaoluan_4";
            this.thaoluan_4.Size = new System.Drawing.Size(104, 16);
            this.thaoluan_4.TabIndex = 6;
            this.thaoluan_4.Text = "Gây tê vùng";
            this.thaoluan_4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // thaoluan_1
            // 
            this.thaoluan_1.Enabled = false;
            this.thaoluan_1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thaoluan_1.Location = new System.Drawing.Point(17, 443);
            this.thaoluan_1.Name = "thaoluan_1";
            this.thaoluan_1.Size = new System.Drawing.Size(112, 16);
            this.thaoluan_1.TabIndex = 3;
            this.thaoluan_1.Text = "Tổn thương răng";
            this.thaoluan_1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // label28
            // 
            this.label28.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label28.Location = new System.Drawing.Point(9, 422);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(208, 16);
            this.label28.TabIndex = 355;
            this.label28.Text = "Thảo luận với bệnh nhân về :";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label27
            // 
            this.label27.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label27.Location = new System.Drawing.Point(9, 234);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(136, 16);
            this.label27.TabIndex = 76;
            this.label27.Text = "Lưu ý về thuốc mê :";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label26
            // 
            this.label26.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label26.Location = new System.Drawing.Point(9, 108);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(136, 16);
            this.label26.TabIndex = 75;
            this.label26.Text = "Xét nghiệm :";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // luuy
            // 
            this.luuy.BackColor = System.Drawing.SystemColors.HighlightText;
            this.luuy.Enabled = false;
            this.luuy.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.luuy.Location = new System.Drawing.Point(5, 252);
            this.luuy.Multiline = true;
            this.luuy.Name = "luuy";
            this.luuy.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.luuy.Size = new System.Drawing.Size(368, 167);
            this.luuy.TabIndex = 2;
            // 
            // xn
            // 
            this.xn.BackColor = System.Drawing.SystemColors.HighlightText;
            this.xn.Enabled = false;
            this.xn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xn.Location = new System.Drawing.Point(5, 125);
            this.xn.Multiline = true;
            this.xn.Name = "xn";
            this.xn.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.xn.Size = new System.Drawing.Size(368, 104);
            this.xn.TabIndex = 1;
            // 
            // label25
            // 
            this.label25.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label25.Location = new System.Drawing.Point(9, 6);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(136, 16);
            this.label25.TabIndex = 72;
            this.label25.Text = "Khám TQ lâm sàng :";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lamsang
            // 
            this.lamsang.BackColor = System.Drawing.SystemColors.HighlightText;
            this.lamsang.Enabled = false;
            this.lamsang.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lamsang.Location = new System.Drawing.Point(5, 24);
            this.lamsang.Multiline = true;
            this.lamsang.Name = "lamsang";
            this.lamsang.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.lamsang.Size = new System.Drawing.Size(368, 80);
            this.lamsang.TabIndex = 0;
            // 
            // frmDanhgia
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(829, 579);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.cmbngay);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.chkXML);
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
            this.Controls.Add(this.label88);
            this.Controls.Add(this.label90);
            this.Controls.Add(this.tenbs);
            this.Controls.Add(this.mabs);
            this.Controls.Add(this.label87);
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
            this.Name = "frmDanhgia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phiếu đánh giá bệnh nhân trước phẫu thuật";
            this.Load += new System.EventHandler(this.frmDanhgia_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmDanhgia_Load(object sender, System.EventArgs e)
		{
            this.Location = new System.Drawing.Point(188, 151);
			user=m.user;

            dtnv = m.get_data("select * from " + user + ".dmbs where nhom<>" + LibMedi.AccessData.nghiviec + " order by hoten").Tables[0];
			listNv.DisplayMember="MA";
			listNv.ValueMember="HOTEN";
			listNv.DataSource=dtnv;
			cmbngay.DisplayMember="NGAY";
			cmbngay.ValueMember="ID";
			asa.SelectedIndex=0;
			load_grid();
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
			if (r!=null) tenbs.Text=r["hoten"].ToString();
			else tenbs.Text="";	
		}

		private void tenbs_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tenbs)
			{
				Filt_dmbs(tenbs.Text);
				listNv.BrowseToDanhmuc(tenbs,mabs,thuoc_k,35);
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
            sql = "select a.id,a.idthuchien,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay,";
            sql += "a.thuoc,a.thuoc_k,a.cannang,a.chieucao,a.mach,a.nhietdo,a.huyetap,a.nhiptho,a.diung,a.diung_k,";
            sql += "a.tm,a.tm_k,a.tm_1,a.tm_2,a.tm_3,a.tm_4,a.tm_5,a.tm_6,a.tm_7,";
            sql += "a.hh,a.hh_k,a.hh_1,a.hh_2,a.hh_3,a.hh_4,a.hh_5,a.hh_6,a.hh_7,";
            sql += "a.than,a.than_k,a.than_1,a.than_2,a.than_3,a.than_4,";
            sql += "e.mabs,c.hoten as tenbs,d.*,e.*";
            sql += " from xxx.ba_danhgia1 a inner join xxx.ba_thuchien b on a.idthuchien=b.id";
            sql += " inner join xxx.ba_danhgia2 d on a.id=d.id2 inner join xxx.ba_danhgia3 e on a.id=e.id3";
            sql += " left join " + user + ".dmbs c on e.mabs=c.ma";
            sql += " where b.idkhoa=" + l_idkhoa;
            sql += " order by a.id";
            ds = m.get_data_mmyy(sql, ngayvv.Text.Substring(0, 10), s_ngayrv.Substring(0, 10), false);
            cmbngay.DataSource = ds.Tables[0];
        }

		private void ref_text()
		{
			l_id=(cmbngay.SelectedIndex!=-1)?decimal.Parse(cmbngay.SelectedValue.ToString()):0;
			load_items(l_id);
		}

		private void load_items(decimal id)
		{
			DataRow r=m.getrowbyid(ds.Tables[0],"id="+id);
			if (r!=null)
			{
				ngay.Text=r["ngay"].ToString().Substring(0,10);
				gio.Text=r["ngay"].ToString().Substring(11);
				mabs.Text=r["mabs"].ToString();
				DataRow r1=m.getrowbyid(dtnv,"ma='"+mabs.Text+"'");
				if (r1!=null) tenbs.Text=r1["hoten"].ToString();
				else tenbs.Text="";	
				thuoc.Text=r["thuoc"].ToString();
				thuoc_k.Checked=r["thuoc_k"].ToString()=="1";
				cannang.Text=(r["cannang"].ToString()!="0")?r["cannang"].ToString():"";
				chieucao.Text=(r["chieucao"].ToString()!="0")?r["chieucao"].ToString():"";
				mach.Text=(r["mach"].ToString()!="0")?r["mach"].ToString():"";
				huyetap.Text=r["huyetap"].ToString();
				nhietdo.Text=(r["nhietdo"].ToString()!="0")?r["nhietdo"].ToString():"";
				nhiptho.Text=(r["nhiptho"].ToString()!="0")?r["nhiptho"].ToString():"";
				diung.Text=r["diung"].ToString();
				diung_k.Checked=r["diung_k"].ToString()=="1";
				tm_k.Checked=r["tm_k"].ToString()=="1";
				tm_1.Checked=r["tm_1"].ToString()=="1";
				tm_2.Checked=r["tm_2"].ToString()=="1";
				tm_3.Checked=r["tm_3"].ToString()=="1";
				tm_4.Checked=r["tm_4"].ToString()=="1";
				tm_5.Checked=r["tm_5"].ToString()=="1";
				tm_6.Checked=r["tm_6"].ToString()=="1";
				tm_7.Checked=r["tm_7"].ToString()=="1";
				tm.Text=r["tm"].ToString();
				than_k.Checked=r["than_k"].ToString()=="1";
				than_1.Checked=r["than_1"].ToString()=="1";
				than_2.Checked=r["than_2"].ToString()=="1";
				than_3.Checked=r["than_3"].ToString()=="1";
				than_4.Checked=r["than_4"].ToString()=="1";
				than.Text=r["than"].ToString();
				tieuhoa_k.Checked=r["tieuhoa_k"].ToString()=="1";
				tieuhoa_1.Checked=r["tieuhoa_1"].ToString()=="1";
				tieuhoa_2.Checked=r["tieuhoa_2"].ToString()=="1";
				tieuhoa_3.Checked=r["tieuhoa_3"].ToString()=="1";
				tieuhoa_4.Checked=r["tieuhoa_4"].ToString()=="1";
				tieuhoa_5.Checked=r["tieuhoa_5"].ToString()=="1";
				tieuhoa_6.Checked=r["tieuhoa_6"].ToString()=="1";
				tieuhoa_7.Checked=r["tieuhoa_7"].ToString()=="1";
				tieuhoa.Text=r["tieuhoa"].ToString();
				hh_k.Checked=r["hh_k"].ToString()=="1";
				hh_1.Checked=r["hh_1"].ToString()=="1";
				hh_2.Checked=r["hh_2"].ToString()=="1";
				hh_3.Checked=r["hh_3"].ToString()=="1";
				hh_4.Checked=r["hh_4"].ToString()=="1";
				hh_5.Checked=r["hh_5"].ToString()=="1";
				hh_6.Checked=r["hh_6"].ToString()=="1";
				hh_7.Checked=r["hh_7"].ToString()=="1";
				hh.Text=r["hh"].ToString();
				noitiet_k.Checked=r["noitiet_k"].ToString()=="1";
				noitiet_1.Checked=r["noitiet_1"].ToString()=="1";
				noitiet_2.Checked=r["noitiet_2"].ToString()=="1";
				noitiet_3.Checked=r["noitiet_3"].ToString()=="1";
				noitiet_4.Checked=r["noitiet_4"].ToString()=="1";
				noitiet_5.Checked=r["noitiet_5"].ToString()=="1";
				noitiet_6.Checked=r["noitiet_6"].ToString()=="1";
				noitiet.Text=r["noitiet"].ToString();
				thankinh_k.Checked=r["thankinh_k"].ToString()=="1";
				thankinh_1.Checked=r["thankinh_1"].ToString()=="1";
				thankinh_2.Checked=r["thankinh_2"].ToString()=="1";
				thankinh_3.Checked=r["thankinh_3"].ToString()=="1";
				thankinh_4.Checked=r["thankinh_4"].ToString()=="1";
				huyethoc_k.Checked=r["huyethoc_k"].ToString()=="1";
				huyethoc_1.Checked=r["huyethoc_1"].ToString()=="1";
				huyethoc_2.Checked=r["huyethoc_2"].ToString()=="1";
				huyethoc_3.Checked=r["huyethoc_3"].ToString()=="1";
				huyethoc.Text=r["huyethoc"].ToString();
				lamsang.Text=r["lamsang"].ToString();
				xn.Text=r["xn"].ToString();
				luuy.Text=r["luuy"].ToString();
				thaoluan_1.Checked=r["thaoluan_1"].ToString()=="1";
				thaoluan_2.Checked=r["thaoluan_2"].ToString()=="1";
				thaoluan_3.Checked=r["thaoluan_3"].ToString()=="1";
				thaoluan_4.Checked=r["thaoluan_4"].ToString()=="1";
				thaoluan_5.Checked=r["thaoluan_5"].ToString()=="1";
				kham_1.Checked=r["kham_1"].ToString()=="1";
				kham_2.Checked=r["kham_2"].ToString()=="1";
				kham_3.Checked=r["kham_3"].ToString()=="1";
				kham_4.Checked=r["kham_4"].ToString()=="1";
				kham_5.Checked=r["kham_5"].ToString()=="1";
				kham.Text=r["kham"].ToString();
				cls.Text=r["cls"].ToString();
				asa.Text=r["asa"].ToString();
				kehoach.Text=r["kehoach"].ToString();
			}
		}

		private void emp_text()
		{
			l_id=0;
			string _ngay=m.ngayhienhanh_server;
			ngay.Text=_ngay.Substring(0,10);
			gio.Text=_ngay.Substring(11);
			mabs.Text="";tenbs.Text="";
			thuoc.Text="";thuoc_k.Checked=false;cannang.Text="";chieucao.Text="";mach.Text="";huyetap.Text="";
			nhietdo.Text="";nhiptho.Text="";diung.Text="";diung_k.Checked=false;
			tm_k.Checked=false;tm_1.Checked=false;tm_2.Checked=false;
			tm_3.Checked=false;tm_4.Checked=false;tm_5.Checked=false;tm_6.Checked=false;tm_7.Checked=false;
			tm.Text="";than_k.Checked=false;than_1.Checked=false;than_2.Checked=false;than_3.Checked=false;
			than_4.Checked=false;than.Text="";tieuhoa_k.Checked=false;tieuhoa_1.Checked=false;tieuhoa_2.Checked=false;
			tieuhoa_3.Checked=false;tieuhoa_4.Checked=false;tieuhoa_5.Checked=false;tieuhoa_6.Checked=false;
			tieuhoa_7.Checked=false;tieuhoa.Text="";asa.SelectedIndex=0;hh.Text="";hh_k.Checked=false;hh_1.Checked=false;
			hh_2.Checked=false;hh_3.Checked=false;hh_4.Checked=false;hh_5.Checked=false;hh_6.Checked=false;
			hh_7.Checked=false;noitiet.Text="";noitiet_k.Checked=false;noitiet_1.Checked=false;noitiet_2.Checked=false;
			noitiet_3.Checked=false;noitiet_4.Checked=false;noitiet_5.Checked=false;noitiet_6.Checked=false;
			thankinh_k.Checked=false;thankinh_1.Checked=false;thankinh_2.Checked=false;thankinh_3.Checked=false;
			thankinh_4.Checked=false;huyethoc.Text="";huyethoc_k.Checked=false;huyethoc_1.Checked=false;
			huyethoc_2.Checked=false;huyethoc_3.Checked=false;lamsang.Text="";kham.Text="";kham_1.Checked=false;
			kham_2.Checked=false;kham_3.Checked=false;kham_4.Checked=false;kham_5.Checked=false;
			xn.Text="";cls.Text="";luuy.Text="";thaoluan_1.Checked=false;thaoluan_2.Checked=false;
			thaoluan_3.Checked=false;thaoluan_4.Checked=false;thaoluan_5.Checked=false;kehoach.Text="";
			ena_tm(!tm_k.Checked);ena_than(!than_k.Checked);ena_tieuhoa(!tieuhoa_k.Checked);
			ena_hh(!hh_k.Checked);ena_noitiet(!noitiet_k.Checked);ena_thankinh(!thankinh_k.Checked);
			ena_huyethoc(!huyethoc_k.Checked);
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

		private void ena_object(bool ena)
		{
			ngay.Enabled=ena;
			gio.Enabled=ena;
			mabs.Enabled=ena;
			tenbs.Enabled=ena;
			thuoc_k.Enabled=ena;
			thuoc.Enabled=ena;
			cannang.Enabled=ena;
			chieucao.Enabled=ena;
			mach.Enabled=ena;
			huyetap.Enabled=ena;
			nhietdo.Enabled=ena;
			nhiptho.Enabled=ena;
			diung_k.Enabled=ena;
			diung.Enabled=ena;
			tm_k.Enabled=ena;
			than_k.Enabled=ena;
			tieuhoa_k.Enabled=ena;
			hh_k.Enabled=ena;
			noitiet_k.Enabled=ena;
			thankinh_k.Enabled=ena;
			huyethoc_k.Enabled=ena;
			lamsang.Enabled=ena;
			xn.Enabled=ena;
			luuy.Enabled=ena;
			thaoluan_1.Enabled=ena;
			thaoluan_2.Enabled=ena;
			thaoluan_3.Enabled=ena;
			thaoluan_4.Enabled=ena;
			thaoluan_5.Enabled=ena;
			kham_1.Enabled=ena;
			kham_2.Enabled=ena;
			kham_3.Enabled=ena;
			kham_4.Enabled=ena;
			kham_5.Enabled=ena;
			cls.Enabled=ena;
			asa.Enabled=ena;
			kehoach.Enabled=ena;
			butLuu.Enabled=ena;
			butBoqua.Enabled=ena;
			butMoi.Enabled=!ena;
			butSua.Enabled=!ena;
			butIn.Enabled=!ena;
			butHuy.Enabled=!ena;
			butKetthuc.Enabled=!ena;
			cmbngay.Enabled=!ena;
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
			ena_tm(!tm_k.Checked);ena_than(!than_k.Checked);ena_tieuhoa(!tieuhoa_k.Checked);
			ena_hh(!hh_k.Checked);ena_noitiet(!noitiet_k.Checked);ena_thankinh(!thankinh_k.Checked);
			ena_huyethoc(!huyethoc_k.Checked);
			tm.Enabled=tm_7.Checked;
			than.Enabled=than_4.Checked;
			tieuhoa.Enabled=tieuhoa_7.Checked;
			hh.Enabled=hh_7.Checked;
			noitiet.Enabled=noitiet_6.Checked;
			huyethoc.Enabled=huyethoc_3.Checked;
			kham.Enabled=kham_5.Checked;
			thuoc.Enabled=!thuoc_k.Checked;
			diung.Enabled=!diung_k.Checked;
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
				m.execute_data("delete from "+xxx+".ba_danhgia1 where id="+l_id);
				m.execute_data("delete from "+xxx+".ba_danhgia2 where id2="+l_id);
				m.execute_data("delete from "+xxx+".ba_danhgia3 where id3="+l_id);
				m.delrec(ds.Tables[0],"id="+l_id);
				ref_text();
			}
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			ena_object(false);
			if (l_id!=0) load_items(l_id);
			ena_object1();
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
				MessageBox.Show(lan.Change_language_MessageText("Bác sĩ GMHS !"),LibMedi.AccessData.Msg);
				if (mabs.Text=="") mabs.Focus();
				else tenbs.Focus();
				return false;
			}
			if (mabs.Text!="" && tenbs.Text!="")
			{
				DataRow r=m.getrowbyid(dtnv,"ma='"+mabs.Text+"'");
				if (r==null)
				{
					MessageBox.Show(lan.Change_language_MessageText("Nhập Bác sĩ GMHS !"),LibMedi.AccessData.Msg);
					mabs.Focus();
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
			if (l_id==0) l_id=m.get_capid(-402);
            m.upd_ba_danhgia1(mabn.Text, l_id, l_idthuchien, ngay.Text + " " + gio.Text, thuoc.Text, (thuoc_k.Checked) ? 1 : 0, (cannang.Text != "") ? decimal.Parse(cannang.Text) : 0,
				(chieucao.Text!="")?int.Parse(chieucao.Text):0,(mach.Text!="")?int.Parse(mach.Text):0,(nhietdo.Text!="")?decimal.Parse(nhietdo.Text):0,
				huyetap.Text,(nhiptho.Text!="")?int.Parse(nhiptho.Text):0,diung.Text,(diung_k.Checked)?1:0,tm.Text,(tm_k.Checked)?1:0,
				(tm_1.Checked)?1:0,(tm_2.Checked)?1:0,(tm_3.Checked)?1:0,(tm_4.Checked)?1:0,(tm_5.Checked)?1:0,(tm_6.Checked)?1:0,
				(tm_7.Checked)?1:0,hh.Text,(hh_k.Checked)?1:0,(hh_1.Checked)?1:0,(hh_2.Checked)?1:0,(hh_3.Checked)?1:0,(hh_4.Checked)?1:0,
				(hh_5.Checked)?1:0,(hh_6.Checked)?1:0,(hh_7.Checked)?1:0,than.Text,(than_k.Checked)?1:0,(than_1.Checked)?1:0,(than_2.Checked)?1:0,
				(than_3.Checked)?1:0,(than_4.Checked)?1:0);
            m.upd_ba_danhgia2(mabn.Text, l_id, ngay.Text + " " + gio.Text, noitiet.Text, (noitiet_k.Checked) ? 1 : 0, (noitiet_1.Checked) ? 1 : 0,
				(noitiet_2.Checked)?1:0,(noitiet_3.Checked)?1:0,(noitiet_4.Checked)?1:0,(noitiet_5.Checked)?1:0,
				(noitiet_6.Checked)?1:0,tieuhoa.Text,(tieuhoa_k.Checked)?1:0,(tieuhoa_1.Checked)?1:0,(tieuhoa_2.Checked)?1:0,
				(tieuhoa_3.Checked)?1:0,(tieuhoa_4.Checked)?1:0,(tieuhoa_5.Checked)?1:0,(tieuhoa_6.Checked)?1:0,(tieuhoa_7.Checked)?1:0,
				"",(thankinh_k.Checked)?1:0,(thankinh_1.Checked)?1:0,(thankinh_2.Checked)?1:0,(thankinh_3.Checked)?1:0,
				(thankinh_4.Checked)?1:0,huyethoc.Text,(huyethoc_k.Checked)?1:0,(huyethoc_1.Checked)?1:0,(huyethoc_2.Checked)?1:0,
				(huyethoc_3.Checked)?1:0);
            m.upd_ba_danhgia3(mabn.Text, l_id, ngay.Text + " " + gio.Text, lamsang.Text, kham.Text, (kham_1.Checked) ? 1 : 0, (kham_2.Checked) ? 1 : 0,
				(kham_3.Checked)?1:0,(kham_4.Checked)?1:0,(kham_5.Checked)?1:0,xn.Text,cls.Text,luuy.Text,asa.Text,(thaoluan_1.Checked)?1:0,
				(thaoluan_2.Checked)?1:0,(thaoluan_3.Checked)?1:0,(thaoluan_4.Checked)?1:0,(thaoluan_5.Checked)?1:0,kehoach.Text,mabs.Text,i_userid);

			upd_items();
			ena_object(false);
			ena_object1();
			butMoi.Focus();
		}

		private void ena_object1()
		{
			ena_tm(false);ena_than(false);ena_tieuhoa(false);ena_hh(false);ena_noitiet(false);ena_thankinh(false);
			ena_huyethoc(false);hh.Enabled=false;than.Enabled=false;tieuhoa.Enabled=false;hh.Enabled=false;
			noitiet.Enabled=false;huyethoc.Enabled=false;kham.Enabled=false;
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
				r2["mabs"]=mabs.Text;
				r2["tenbs"]=tenbs.Text;
				r2["thuoc"]=thuoc.Text;
				r2["thuoc_k"]=(thuoc_k.Checked)?1:0;
				r2["tm"]=tm.Text;
				r2["tm_k"]=(tm_k.Checked)?1:0;
				r2["tm_1"]=(tm_1.Checked)?1:0;
				r2["tm_2"]=(tm_2.Checked)?1:0;
				r2["tm_3"]=(tm_3.Checked)?1:0;
				r2["tm_4"]=(tm_4.Checked)?1:0;
				r2["tm_5"]=(tm_5.Checked)?1:0;
				r2["tm_6"]=(tm_6.Checked)?1:0;
				r2["tm_7"]=(tm_7.Checked)?1:0;
				r2["than"]=than.Text;
				r2["than_k"]=(than_k.Checked)?1:0;
				r2["than_1"]=(than_1.Checked)?1:0;
				r2["than_2"]=(than_2.Checked)?1:0;
				r2["than_3"]=(than_3.Checked)?1:0;
				r2["than_4"]=(than_4.Checked)?1:0;
				r2["tieuhoa"]=tieuhoa.Text;
				r2["tieuhoa_k"]=(tieuhoa_k.Checked)?1:0;
				r2["tieuhoa_1"]=(tieuhoa_1.Checked)?1:0;
				r2["tieuhoa_2"]=(tieuhoa_2.Checked)?1:0;
				r2["tieuhoa_3"]=(tieuhoa_3.Checked)?1:0;
				r2["tieuhoa_4"]=(tieuhoa_4.Checked)?1:0;
				r2["tieuhoa_5"]=(tieuhoa_5.Checked)?1:0;
				r2["tieuhoa_6"]=(tieuhoa_6.Checked)?1:0;
				r2["tieuhoa_7"]=(tieuhoa_7.Checked)?1:0;
				r2["cannang"]=(cannang.Text!="")?decimal.Parse(cannang.Text):0;
				r2["chieucao"]=(chieucao.Text!="")?int.Parse(chieucao.Text):0;
				r2["mach"]=(mach.Text!="")?int.Parse(mach.Text):0;
				r2["huyetap"]=huyetap.Text;
				r2["nhietdo"]=(nhietdo.Text!="")?decimal.Parse(nhietdo.Text):0;
				r2["nhiptho"]=(nhiptho.Text!="")?int.Parse(nhiptho.Text):0;
				r2["hh"]=hh.Text;
				r2["hh_k"]=(hh_k.Checked)?1:0;
				r2["hh_1"]=(hh_1.Checked)?1:0;
				r2["hh_2"]=(hh_2.Checked)?1:0;
				r2["hh_3"]=(hh_3.Checked)?1:0;
				r2["hh_4"]=(hh_4.Checked)?1:0;
				r2["hh_5"]=(hh_5.Checked)?1:0;
				r2["hh_6"]=(hh_6.Checked)?1:0;
				r2["hh_7"]=(hh_7.Checked)?1:0;
				r2["noitiet"]=noitiet.Text;
				r2["noitiet_k"]=(noitiet_k.Checked)?1:0;
				r2["noitiet_1"]=(noitiet_1.Checked)?1:0;
				r2["noitiet_2"]=(noitiet_2.Checked)?1:0;
				r2["noitiet_3"]=(noitiet_3.Checked)?1:0;
				r2["noitiet_4"]=(noitiet_4.Checked)?1:0;
				r2["noitiet_5"]=(noitiet_5.Checked)?1:0;
				r2["noitiet_6"]=(noitiet_6.Checked)?1:0;
				r2["thankinh_k"]=(thankinh_k.Checked)?1:0;
				r2["thankinh_1"]=(thankinh_1.Checked)?1:0;
				r2["thankinh_2"]=(thankinh_2.Checked)?1:0;
				r2["thankinh_3"]=(thankinh_3.Checked)?1:0;
				r2["thankinh_4"]=(thankinh_4.Checked)?1:0;
				r2["huyethoc"]=huyethoc.Text;
				r2["huyethoc_k"]=(huyethoc_k.Checked)?1:0;
				r2["huyethoc_1"]=(huyethoc_1.Checked)?1:0;
				r2["huyethoc_2"]=(huyethoc_2.Checked)?1:0;
				r2["huyethoc_3"]=(huyethoc_3.Checked)?1:0;
				r2["lamsang"]=lamsang.Text;
				r2["xn"]=xn.Text;
				r2["luuy"]=luuy.Text;
				r2["thaoluan_1"]=(thaoluan_1.Checked)?1:0;
				r2["thaoluan_2"]=(thaoluan_2.Checked)?1:0;
				r2["thaoluan_3"]=(thaoluan_3.Checked)?1:0;
				r2["thaoluan_4"]=(thaoluan_4.Checked)?1:0;
				r2["thaoluan_5"]=(thaoluan_5.Checked)?1:0;
				r2["kham"]=kham.Text;
				r2["kham_1"]=(kham_1.Checked)?1:0;
				r2["kham_2"]=(kham_2.Checked)?2:0;
				r2["kham_3"]=(kham_3.Checked)?3:0;
				r2["kham_4"]=(kham_4.Checked)?4:0;
				r2["kham_5"]=(kham_5.Checked)?5:0;
				r2["cls"]=cls.Text;
				r2["asa"]=asa.Text;
				r2["kehoach"]=kehoach.Text;
				ds.Tables[0].Rows.Add(r2);
			}
			else
			{
				DataRow [] dr=ds.Tables[0].Select("id="+l_id);
				dr[0]["idthuchien"]=l_idthuchien;
				dr[0]["ngay"]=ngay.Text+" "+gio.Text;
				dr[0]["mabs"]=mabs.Text;
				dr[0]["tenbs"]=tenbs.Text;
				dr[0]["thuoc"]=thuoc.Text;
				dr[0]["thuoc_k"]=(thuoc_k.Checked)?1:0;
				dr[0]["tm"]=tm.Text;
				dr[0]["tm_k"]=(tm_k.Checked)?1:0;
				dr[0]["tm_1"]=(tm_1.Checked)?1:0;
				dr[0]["tm_2"]=(tm_2.Checked)?1:0;
				dr[0]["tm_3"]=(tm_3.Checked)?1:0;
				dr[0]["tm_4"]=(tm_4.Checked)?1:0;
				dr[0]["tm_5"]=(tm_5.Checked)?1:0;
				dr[0]["tm_6"]=(tm_6.Checked)?1:0;
				dr[0]["tm_7"]=(tm_7.Checked)?1:0;
				dr[0]["than"]=than.Text;
				dr[0]["than_k"]=(than_k.Checked)?1:0;
				dr[0]["than_1"]=(than_1.Checked)?1:0;
				dr[0]["than_2"]=(than_2.Checked)?1:0;
				dr[0]["than_3"]=(than_3.Checked)?1:0;
				dr[0]["than_4"]=(than_4.Checked)?1:0;
				dr[0]["tieuhoa"]=tieuhoa.Text;
				dr[0]["tieuhoa_k"]=(tieuhoa_k.Checked)?1:0;
				dr[0]["tieuhoa_1"]=(tieuhoa_1.Checked)?1:0;
				dr[0]["tieuhoa_2"]=(tieuhoa_2.Checked)?1:0;
				dr[0]["tieuhoa_3"]=(tieuhoa_3.Checked)?1:0;
				dr[0]["tieuhoa_4"]=(tieuhoa_4.Checked)?1:0;
				dr[0]["tieuhoa_5"]=(tieuhoa_5.Checked)?1:0;
				dr[0]["tieuhoa_6"]=(tieuhoa_6.Checked)?1:0;
				dr[0]["tieuhoa_7"]=(tieuhoa_7.Checked)?1:0;
				dr[0]["cannang"]=(cannang.Text!="")?decimal.Parse(cannang.Text):0;
				dr[0]["chieucao"]=(chieucao.Text!="")?int.Parse(chieucao.Text):0;
				dr[0]["mach"]=(mach.Text!="")?int.Parse(mach.Text):0;
				dr[0]["huyetap"]=huyetap.Text;
				dr[0]["nhietdo"]=(nhietdo.Text!="")?decimal.Parse(nhietdo.Text):0;
				dr[0]["nhiptho"]=(nhiptho.Text!="")?int.Parse(nhiptho.Text):0;
				dr[0]["hh"]=hh.Text;
				dr[0]["hh_k"]=(hh_k.Checked)?1:0;
				dr[0]["hh_1"]=(hh_1.Checked)?1:0;
				dr[0]["hh_2"]=(hh_2.Checked)?1:0;
				dr[0]["hh_3"]=(hh_3.Checked)?1:0;
				dr[0]["hh_4"]=(hh_4.Checked)?1:0;
				dr[0]["hh_5"]=(hh_5.Checked)?1:0;
				dr[0]["hh_6"]=(hh_6.Checked)?1:0;
				dr[0]["hh_7"]=(hh_7.Checked)?1:0;
				dr[0]["noitiet"]=noitiet.Text;
				dr[0]["noitiet_k"]=(noitiet_k.Checked)?1:0;
				dr[0]["noitiet_1"]=(noitiet_1.Checked)?1:0;
				dr[0]["noitiet_2"]=(noitiet_2.Checked)?1:0;
				dr[0]["noitiet_3"]=(noitiet_3.Checked)?1:0;
				dr[0]["noitiet_4"]=(noitiet_4.Checked)?1:0;
				dr[0]["noitiet_5"]=(noitiet_5.Checked)?1:0;
				dr[0]["noitiet_6"]=(noitiet_6.Checked)?1:0;
				dr[0]["thankinh_k"]=(thankinh_k.Checked)?1:0;
				dr[0]["thankinh_1"]=(thankinh_1.Checked)?1:0;
				dr[0]["thankinh_2"]=(thankinh_2.Checked)?1:0;
				dr[0]["thankinh_3"]=(thankinh_3.Checked)?1:0;
				dr[0]["thankinh_4"]=(thankinh_4.Checked)?1:0;
				dr[0]["huyethoc"]=huyethoc.Text;
				dr[0]["huyethoc_k"]=(huyethoc_k.Checked)?1:0;
				dr[0]["huyethoc_1"]=(huyethoc_1.Checked)?1:0;
				dr[0]["huyethoc_2"]=(huyethoc_2.Checked)?1:0;
				dr[0]["huyethoc_3"]=(huyethoc_3.Checked)?1:0;
				dr[0]["lamsang"]=lamsang.Text;
				dr[0]["xn"]=xn.Text;
				dr[0]["luuy"]=luuy.Text;
				dr[0]["thaoluan_1"]=(thaoluan_1.Checked)?1:0;
				dr[0]["thaoluan_2"]=(thaoluan_2.Checked)?1:0;
				dr[0]["thaoluan_3"]=(thaoluan_3.Checked)?1:0;
				dr[0]["thaoluan_4"]=(thaoluan_4.Checked)?1:0;
				dr[0]["thaoluan_5"]=(thaoluan_5.Checked)?1:0;
				dr[0]["kham"]=kham.Text;
				dr[0]["kham_1"]=(kham_1.Checked)?1:0;
				dr[0]["kham_2"]=(kham_2.Checked)?2:0;
				dr[0]["kham_3"]=(kham_3.Checked)?3:0;
				dr[0]["kham_4"]=(kham_4.Checked)?4:0;
				dr[0]["kham_5"]=(kham_5.Checked)?5:0;
				dr[0]["cls"]=cls.Text;
				dr[0]["asa"]=asa.Text;
				dr[0]["kehoach"]=kehoach.Text;
			}
		}

        private void butIn_Click(object sender, System.EventArgs e)
        {
            if (cmbngay.SelectedIndex == -1) return;

            string stuoi = m.get_tuoivao(l_maql).Trim();
            sql = "select a.id,'' as sovaovien,'' as mabn,'' as hoten,'' as tuoi,'' as phai,'' as tenkp,";
            sql += "'' as phong,'' as giuong,'' as chandoan,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay,";
            sql += "a.thuoc,a.thuoc_k,a.cannang,a.chieucao,a.mach,a.nhietdo,a.huyetap,a.nhiptho,a.diung,a.diung_k,";
            sql += "a.tm,a.tm_k,a.tm_1,a.tm_2,a.tm_3,a.tm_4,a.tm_5,a.tm_6,a.tm_7,";
            sql += "a.hh,a.hh_k,a.hh_1,a.hh_2,a.hh_3,a.hh_4,a.hh_5,a.hh_6,a.hh_7,";
            sql += "a.than,a.than_k,a.than_1,a.than_2,a.than_3,a.than_4,";
            sql += "e.mabs,c.hoten as tenbs,d.*,e.*,'' as image ";//c.image
            sql += " from xxx.ba_danhgia1 a inner join xxx.ba_thuchien b on a.idthuchien=b.id";
            sql += " inner join xxx.ba_danhgia2 d on a.id=d.id2 inner join xxx.ba_danhgia3 e on a.id=e.id3";
            sql += " left join " + user + ".dmbs c on e.mabs=c.ma";
            sql += " where a.id=" + l_id;
            DataSet dsxml = m.get_data_mmyy(sql, ngayvv.Text.Substring(0, 10), s_ngayrv.Substring(0, 10), false);

            if (chkXML.Checked)
            {
                if (!System.IO.Directory.Exists("..\\xml")) System.IO.Directory.CreateDirectory("..\\xml");
                dsxml.WriteXml("..\\xml\\danhgia.xml", XmlWriteMode.WriteSchema);
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
                dllReportM.frmReport f = new dllReportM.frmReport(m, dsxml, "", "rDanhgia.rpt");
                f.ShowDialog();
            }
            else MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"), LibMedi.AccessData.Msg);
        }

		private void thuoc_k_CheckedChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==thuoc_k) thuoc.Enabled=!thuoc_k.Checked;
		}

		private void tm_k_CheckedChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tm_k) ena_tm(!tm_k.Checked);
		}

		private void ena_tm(bool ena)
		{
			tm_1.Enabled=ena;
			tm_2.Enabled=ena;
			tm_3.Enabled=ena;
			tm_4.Enabled=ena;
			tm_5.Enabled=ena;
			tm_6.Enabled=ena;
			tm_7.Enabled=ena;
		}

		private void tm_7_CheckedChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tm_7) tm.Enabled=tm_7.Checked;
		}

		private void than_k_CheckedChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==than_k) ena_than(!than_k.Checked);
		}

		private void ena_than(bool ena)
		{
			than_1.Enabled=ena;
			than_2.Enabled=ena;
			than_3.Enabled=ena;
			than_4.Enabled=ena;
		}
		private void than_4_CheckedChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==than_4) than.Enabled=than_4.Checked;
		}

		private void tieuhoa_k_CheckedChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tieuhoa_k) ena_tieuhoa(!tieuhoa_k.Checked);
		}

		private void ena_tieuhoa(bool ena)
		{
			tieuhoa_1.Enabled=ena;
			tieuhoa_2.Enabled=ena;
			tieuhoa_3.Enabled=ena;
			tieuhoa_4.Enabled=ena;
			tieuhoa_5.Enabled=ena;
			tieuhoa_6.Enabled=ena;
			tieuhoa_7.Enabled=ena;
		}

		private void tieuhoa_7_CheckedChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tieuhoa_7) tieuhoa.Enabled=tieuhoa_7.Checked;		
		}

		private void diung_k_CheckedChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==diung_k) diung.Enabled=!diung_k.Checked;
		}

		private void hh_k_CheckedChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==hh_k) ena_hh(!hh_k.Checked);
		}

		private void ena_hh(bool ena)
		{
			hh_1.Enabled=ena;
			hh_2.Enabled=ena;
			hh_3.Enabled=ena;
			hh_4.Enabled=ena;
			hh_5.Enabled=ena;
			hh_6.Enabled=ena;
			hh_7.Enabled=ena;
		}
		private void hh_7_CheckedChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==hh_7) hh.Enabled=hh_7.Checked;
		}

		private void noitiet_k_CheckedChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==noitiet_k) ena_noitiet(!noitiet_k.Checked);
		}

		private void ena_noitiet(bool ena)
		{
			noitiet_1.Enabled=ena;
			noitiet_2.Enabled=ena;
			noitiet_3.Enabled=ena;
			noitiet_4.Enabled=ena;
			noitiet_5.Enabled=ena;
			noitiet_6.Enabled=ena;
		}

		private void noitiet_6_CheckedChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==noitiet_6) noitiet.Enabled=noitiet_6.Checked;
		}

		private void thankinh_k_CheckedChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==thankinh_k) ena_thankinh(!thankinh_k.Checked);
		}

		private void ena_thankinh(bool ena)
		{
			thankinh_1.Enabled=ena;
			thankinh_2.Enabled=ena;
			thankinh_3.Enabled=ena;
			thankinh_4.Enabled=ena;
		}
		private void huyethoc_k_CheckedChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==huyethoc_k) ena_huyethoc(!huyethoc_k.Checked);		
		}

		private void ena_huyethoc(bool ena)
		{
			huyethoc_1.Enabled=ena;
			huyethoc_2.Enabled=ena;
			huyethoc_3.Enabled=ena;
		}

		private void huyethoc_3_CheckedChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==huyethoc_3) huyethoc.Enabled=huyethoc_3.Checked;
		}

		private void kham_5_CheckedChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==kham_5) kham.Enabled=kham_5.Checked;
		}

	}
}
