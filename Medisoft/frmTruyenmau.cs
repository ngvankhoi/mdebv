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
	public class frmTruyenmau : System.Windows.Forms.Form
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
		private DataTable dtlinh=new DataTable();
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
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label lgio;
		private System.Windows.Forms.TextBox tenyta;
		private MaskedTextBox.MaskedTextBox yta;
		private System.Windows.Forms.Label label21;
		private MaskedBox.MaskedBox gio_kt;
		private MaskedBox.MaskedBox ngay_kt;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.ComboBox cmbngay;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Button butXoa;
		private System.Windows.Forms.Button butThem;
		private System.Windows.Forms.TextBox noilam;
		private System.Windows.Forms.TextBox kythuat;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.ComboBox idlinh;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.Label label28;
		private System.Windows.Forms.Label label29;
		private MaskedBox.MaskedBox ngaylay;
		private MaskedBox.MaskedBox handung;
		private System.Windows.Forms.TextBox chepham;
		private System.Windows.Forms.TextBox maso;
		private System.Windows.Forms.TextBox soluong;
		private System.Windows.Forms.Label label30;
		private System.Windows.Forms.Label label31;
		private System.Windows.Forms.TextBox sinhpham;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.Panel panel8;
		private System.Windows.Forms.Panel panel9;
		private System.Windows.Forms.CheckBox hcv;
		private System.Windows.Forms.CheckBox giangmai;
		private System.Windows.Forms.CheckBox sotret;
		private System.Windows.Forms.TextBox ong1;
		private System.Windows.Forms.Label label32;
		private System.Windows.Forms.Label label33;
		private System.Windows.Forms.ComboBox nguoicho;
		private System.Windows.Forms.ComboBox benhnhan;
		private System.Windows.Forms.Label label34;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.TextBox ong2;
		private System.Windows.Forms.Label label35;
		private MaskedTextBox.MaskedTextBox truongkhoa;
		private System.Windows.Forms.TextBox tentruongkhoa;
		private MaskedTextBox.MaskedTextBox ktv1;
		private System.Windows.Forms.TextBox tenktv1;
		private MaskedTextBox.MaskedTextBox ktv2;
		private System.Windows.Forms.TextBox tenktv2;
		private System.Windows.Forms.Label label36;
		private System.Windows.Forms.Label label37;
		private MaskedBox.MaskedBox gio_ct;
		private MaskedBox.MaskedBox ngay_ct;
		private System.Windows.Forms.Label label38;
		private System.Windows.Forms.Label label39;
		private System.Windows.Forms.TextBox masotr;
		private System.Windows.Forms.TextBox chephamtr;
		private MaskedBox.MaskedBox handungtr;
		private System.Windows.Forms.Label label40;
		private System.Windows.Forms.Label label41;
		private System.Windows.Forms.Label label42;
		private System.Windows.Forms.NumericUpDown lanthu;
		private System.Windows.Forms.Label label43;
		private MaskedTextBox.MaskedTextBox bscd;
		private System.Windows.Forms.TextBox tenbscd;
		private System.Windows.Forms.ComboBox benhnhantr;
		private System.Windows.Forms.ComboBox nguoichotr;
		private System.Windows.Forms.Label label44;
		private System.Windows.Forms.Label label45;
		private System.Windows.Forms.Label label46;
		private System.Windows.Forms.TextBox tai;
		private System.Windows.Forms.Label label47;
		private System.Windows.Forms.TextBox soluongtr;
		private System.Windows.Forms.Label label48;
		private MaskedBox.MaskedBox gio_bd;
		private MaskedBox.MaskedBox ngay_bd;
		private System.Windows.Forms.Label label49;
		private System.Windows.Forms.Label label50;
		private System.Windows.Forms.Label label51;
		private System.Windows.Forms.Label label53;
		private System.Windows.Forms.Label label54;
		private System.Windows.Forms.Label label55;
		private System.Windows.Forms.Label label56;
		private System.Windows.Forms.Label label57;
		private System.Windows.Forms.Label label58;
		private System.Windows.Forms.Label label52;
		private System.Windows.Forms.TextBox soluongthuc;
		private System.Windows.Forms.TextBox sacmat_ct;
		private MaskedBox.MaskedBox nhietdo_ct;
		private MaskedBox.MaskedBox huyetap_ct;
		private MaskedTextBox.MaskedTextBox nhiptho_ct;
		private MaskedTextBox.MaskedTextBox mach_ct;
		private System.Windows.Forms.TextBox dienbien_ct;
		private System.Windows.Forms.TextBox sacmat;
		private System.Windows.Forms.TextBox dienbien;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label22;
		private MaskedBox.MaskedBox nhietdo;
		private MaskedTextBox.MaskedTextBox huyetap;
		private MaskedTextBox.MaskedTextBox nhiptho;
		private MaskedTextBox.MaskedTextBox mach;
		private System.Windows.Forms.Label label59;
		private System.Windows.Forms.Label label60;
		private System.Windows.Forms.Label label61;
		private System.Windows.Forms.Label label62;
		private System.Windows.Forms.Label label63;
		private System.Windows.Forms.Label label64;
		private System.Windows.Forms.Label label65;
		private System.Windows.Forms.Label label66;
		private System.Windows.Forms.CheckBox hbsag;
		private System.Windows.Forms.CheckBox chkXML;
        #endregion

        public frmTruyenmau(LibMedi.AccessData acc,string _mabn,decimal _maql,decimal _idkhoa,string _sovaovien,string _makp,string _hoten,string _namsinh,string _phai,string _diachi,string _ngayvv,string _sothe,string _phong,string _giuong,string _ngayrv,string _mabs,int _userid,string _nhomkho,string suserid,string _chandoan,string _tenkp,bool _admin)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTruyenmau));
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
            this.noilam = new System.Windows.Forms.TextBox();
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
            this.tenyta = new System.Windows.Forms.TextBox();
            this.yta = new MaskedTextBox.MaskedTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.kythuat = new System.Windows.Forms.TextBox();
            this.ong1 = new System.Windows.Forms.TextBox();
            this.gio_ct = new MaskedBox.MaskedBox();
            this.ngay_ct = new MaskedBox.MaskedBox();
            this.label21 = new System.Windows.Forms.Label();
            this.gio_kt = new MaskedBox.MaskedBox();
            this.ngay_kt = new MaskedBox.MaskedBox();
            this.label23 = new System.Windows.Forms.Label();
            this.cmbngay = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.butXoa = new System.Windows.Forms.Button();
            this.butThem = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.idlinh = new System.Windows.Forms.ComboBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.ngaylay = new MaskedBox.MaskedBox();
            this.handung = new MaskedBox.MaskedBox();
            this.chepham = new System.Windows.Forms.TextBox();
            this.maso = new System.Windows.Forms.TextBox();
            this.soluong = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.sinhpham = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.hbsag = new System.Windows.Forms.CheckBox();
            this.hcv = new System.Windows.Forms.CheckBox();
            this.giangmai = new System.Windows.Forms.CheckBox();
            this.sotret = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.label32 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.nguoicho = new System.Windows.Forms.ComboBox();
            this.benhnhan = new System.Windows.Forms.ComboBox();
            this.label34 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.ong2 = new System.Windows.Forms.TextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.truongkhoa = new MaskedTextBox.MaskedTextBox();
            this.tentruongkhoa = new System.Windows.Forms.TextBox();
            this.ktv1 = new MaskedTextBox.MaskedTextBox();
            this.tenktv1 = new System.Windows.Forms.TextBox();
            this.ktv2 = new MaskedTextBox.MaskedTextBox();
            this.tenktv2 = new System.Windows.Forms.TextBox();
            this.label36 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.masotr = new System.Windows.Forms.TextBox();
            this.chephamtr = new System.Windows.Forms.TextBox();
            this.handungtr = new MaskedBox.MaskedBox();
            this.label40 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.lanthu = new System.Windows.Forms.NumericUpDown();
            this.label43 = new System.Windows.Forms.Label();
            this.bscd = new MaskedTextBox.MaskedTextBox();
            this.tenbscd = new System.Windows.Forms.TextBox();
            this.benhnhantr = new System.Windows.Forms.ComboBox();
            this.nguoichotr = new System.Windows.Forms.ComboBox();
            this.label44 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.tai = new System.Windows.Forms.TextBox();
            this.label47 = new System.Windows.Forms.Label();
            this.soluongtr = new System.Windows.Forms.TextBox();
            this.label48 = new System.Windows.Forms.Label();
            this.gio_bd = new MaskedBox.MaskedBox();
            this.ngay_bd = new MaskedBox.MaskedBox();
            this.label49 = new System.Windows.Forms.Label();
            this.sacmat_ct = new System.Windows.Forms.TextBox();
            this.nhietdo_ct = new MaskedBox.MaskedBox();
            this.huyetap_ct = new MaskedBox.MaskedBox();
            this.nhiptho_ct = new MaskedTextBox.MaskedTextBox();
            this.mach_ct = new MaskedTextBox.MaskedTextBox();
            this.label50 = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.label55 = new System.Windows.Forms.Label();
            this.label56 = new System.Windows.Forms.Label();
            this.label57 = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.dienbien_ct = new System.Windows.Forms.TextBox();
            this.soluongthuc = new System.Windows.Forms.TextBox();
            this.sacmat = new System.Windows.Forms.TextBox();
            this.dienbien = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.nhietdo = new MaskedBox.MaskedBox();
            this.huyetap = new MaskedTextBox.MaskedTextBox();
            this.nhiptho = new MaskedTextBox.MaskedTextBox();
            this.mach = new MaskedTextBox.MaskedTextBox();
            this.label59 = new System.Windows.Forms.Label();
            this.label60 = new System.Windows.Forms.Label();
            this.label61 = new System.Windows.Forms.Label();
            this.label62 = new System.Windows.Forms.Label();
            this.label63 = new System.Windows.Forms.Label();
            this.label64 = new System.Windows.Forms.Label();
            this.label65 = new System.Windows.Forms.Label();
            this.label66 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lanthu)).BeginInit();
            this.SuspendLayout();
            // 
            // chandoan
            // 
            this.chandoan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.chandoan.Enabled = false;
            this.chandoan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chandoan.Location = new System.Drawing.Point(41, 359);
            this.chandoan.Name = "chandoan";
            this.chandoan.Size = new System.Drawing.Size(461, 21);
            this.chandoan.TabIndex = 71;
            // 
            // sothe
            // 
            this.sothe.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sothe.Enabled = false;
            this.sothe.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sothe.Location = new System.Drawing.Point(41, 359);
            this.sothe.Name = "sothe";
            this.sothe.Size = new System.Drawing.Size(220, 21);
            this.sothe.TabIndex = 63;
            // 
            // giuong
            // 
            this.giuong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.giuong.Enabled = false;
            this.giuong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.giuong.Location = new System.Drawing.Point(41, 359);
            this.giuong.Name = "giuong";
            this.giuong.Size = new System.Drawing.Size(109, 21);
            this.giuong.TabIndex = 70;
            // 
            // phong
            // 
            this.phong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.phong.Enabled = false;
            this.phong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phong.Location = new System.Drawing.Point(41, 359);
            this.phong.Name = "phong";
            this.phong.Size = new System.Drawing.Size(80, 21);
            this.phong.TabIndex = 69;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(41, 359);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(73, 16);
            this.label13.TabIndex = 68;
            this.label13.Text = "Chẩn đoán :";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(41, 359);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(48, 16);
            this.label12.TabIndex = 67;
            this.label12.Text = "Giường :";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(41, 359);
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
            this.ngayvv.Location = new System.Drawing.Point(41, 359);
            this.ngayvv.Name = "ngayvv";
            this.ngayvv.Size = new System.Drawing.Size(109, 21);
            this.ngayvv.TabIndex = 65;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(41, 359);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 16);
            this.label7.TabIndex = 64;
            this.label7.Text = "Ngày :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(41, 359);
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
            this.diachi.Location = new System.Drawing.Point(41, 359);
            this.diachi.Name = "diachi";
            this.diachi.Size = new System.Drawing.Size(349, 21);
            this.diachi.TabIndex = 61;
            // 
            // phai
            // 
            this.phai.BackColor = System.Drawing.SystemColors.HighlightText;
            this.phai.Enabled = false;
            this.phai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phai.Location = new System.Drawing.Point(41, 359);
            this.phai.Name = "phai";
            this.phai.Size = new System.Drawing.Size(32, 21);
            this.phai.TabIndex = 60;
            // 
            // namsinh
            // 
            this.namsinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.namsinh.Enabled = false;
            this.namsinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namsinh.Location = new System.Drawing.Point(41, 359);
            this.namsinh.Name = "namsinh";
            this.namsinh.Size = new System.Drawing.Size(32, 21);
            this.namsinh.TabIndex = 59;
            // 
            // hoten
            // 
            this.hoten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.hoten.Enabled = false;
            this.hoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoten.Location = new System.Drawing.Point(41, 359);
            this.hoten.Name = "hoten";
            this.hoten.Size = new System.Drawing.Size(160, 21);
            this.hoten.TabIndex = 58;
            // 
            // mabn
            // 
            this.mabn.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabn.Enabled = false;
            this.mabn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabn.Location = new System.Drawing.Point(41, 359);
            this.mabn.Name = "mabn";
            this.mabn.Size = new System.Drawing.Size(56, 21);
            this.mabn.TabIndex = 52;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(41, 359);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 16);
            this.label5.TabIndex = 57;
            this.label5.Text = "Địa chỉ :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(41, 359);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 16);
            this.label4.TabIndex = 56;
            this.label4.Text = "Giới tính :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(41, 359);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 16);
            this.label3.TabIndex = 55;
            this.label3.Text = "NS :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(41, 359);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 16);
            this.label1.TabIndex = 54;
            this.label1.Text = "Họ tên :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(41, 359);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 16);
            this.label10.TabIndex = 53;
            this.label10.Text = "Mã BN :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(41, 359);
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
            this.sovaovien.Location = new System.Drawing.Point(41, 359);
            this.sovaovien.Name = "sovaovien";
            this.sovaovien.Size = new System.Drawing.Size(64, 21);
            this.sovaovien.TabIndex = 73;
            // 
            // gio
            // 
            this.gio.BackColor = System.Drawing.SystemColors.HighlightText;
            this.gio.Enabled = false;
            this.gio.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gio.Location = new System.Drawing.Point(143, 3);
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
            this.ngay.Location = new System.Drawing.Point(47, 3);
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
            this.lgio.Location = new System.Drawing.Point(119, 6);
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
            this.tenbs.Location = new System.Drawing.Point(148, 512);
            this.tenbs.Name = "tenbs";
            this.tenbs.Size = new System.Drawing.Size(203, 21);
            this.tenbs.TabIndex = 56;
            this.tenbs.TextChanged += new System.EventHandler(this.tenbs_TextChanged);
            this.tenbs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbs_KeyDown);
            // 
            // mabs
            // 
            this.mabs.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mabs.Enabled = false;
            this.mabs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabs.Location = new System.Drawing.Point(105, 512);
            this.mabs.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.mabs.MaxLength = 9;
            this.mabs.Name = "mabs";
            this.mabs.Size = new System.Drawing.Size(41, 21);
            this.mabs.TabIndex = 55;
            this.mabs.Validated += new System.EventHandler(this.mabs_Validated);
            this.mabs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // label87
            // 
            this.label87.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label87.Location = new System.Drawing.Point(9, 514);
            this.label87.Name = "label87";
            this.label87.Size = new System.Drawing.Size(104, 16);
            this.label87.TabIndex = 300;
            this.label87.Text = "Bác sĩ thực hiện :";
            this.label87.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // noilam
            // 
            this.noilam.BackColor = System.Drawing.SystemColors.HighlightText;
            this.noilam.Enabled = false;
            this.noilam.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noilam.Location = new System.Drawing.Point(164, 70);
            this.noilam.Name = "noilam";
            this.noilam.Size = new System.Drawing.Size(632, 21);
            this.noilam.TabIndex = 9;
            this.noilam.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
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
            this.dataGrid1.Location = new System.Drawing.Point(7, 314);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(789, 99);
            this.dataGrid1.TabIndex = 310;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            this.dataGrid1.Click += new System.EventHandler(this.dataGrid1_Click);
            // 
            // butMoi
            // 
            this.butMoi.Location = new System.Drawing.Point(133, 543);
            this.butMoi.Name = "butMoi";
            this.butMoi.Size = new System.Drawing.Size(70, 25);
            this.butMoi.TabIndex = 63;
            this.butMoi.Text = "&Mới";
            this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
            // 
            // butSua
            // 
            this.butSua.Location = new System.Drawing.Point(203, 543);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(70, 25);
            this.butSua.TabIndex = 64;
            this.butSua.Text = "&Sửa";
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butLuu
            // 
            this.butLuu.Enabled = false;
            this.butLuu.Location = new System.Drawing.Point(273, 543);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 61;
            this.butLuu.Text = "&Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Enabled = false;
            this.butBoqua.Location = new System.Drawing.Point(483, 543);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(70, 25);
            this.butBoqua.TabIndex = 62;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butHuy
            // 
            this.butHuy.Location = new System.Drawing.Point(553, 543);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(70, 25);
            this.butHuy.TabIndex = 65;
            this.butHuy.Text = "&Hủy";
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // butIn
            // 
            this.butIn.Location = new System.Drawing.Point(623, 543);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 66;
            this.butIn.Text = "&In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Location = new System.Drawing.Point(693, 543);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 67;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // listNv
            // 
            this.listNv.BackColor = System.Drawing.SystemColors.Info;
            this.listNv.ColumnCount = 0;
            this.listNv.Location = new System.Drawing.Point(672, 7);
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
            this.chkXML.Location = new System.Drawing.Point(8, 552);
            this.chkXML.Name = "chkXML";
            this.chkXML.Size = new System.Drawing.Size(104, 24);
            this.chkXML.TabIndex = 313;
            this.chkXML.Text = "Xuất ra XML";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 73);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(160, 16);
            this.label8.TabIndex = 314;
            this.label8.Text = "Ngày và nơi làm xét nghiệm :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tenyta
            // 
            this.tenyta.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenyta.Enabled = false;
            this.tenyta.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenyta.Location = new System.Drawing.Point(607, 512);
            this.tenyta.Name = "tenyta";
            this.tenyta.Size = new System.Drawing.Size(188, 21);
            this.tenyta.TabIndex = 58;
            this.tenyta.TextChanged += new System.EventHandler(this.tenyta_TextChanged);
            this.tenyta.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbs_KeyDown);
            // 
            // yta
            // 
            this.yta.BackColor = System.Drawing.SystemColors.HighlightText;
            this.yta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.yta.Enabled = false;
            this.yta.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yta.Location = new System.Drawing.Point(564, 512);
            this.yta.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.yta.MaxLength = 9;
            this.yta.Name = "yta";
            this.yta.Size = new System.Drawing.Size(41, 21);
            this.yta.TabIndex = 57;
            this.yta.Validated += new System.EventHandler(this.yta_Validated);
            this.yta.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(277, 514);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(288, 16);
            this.label14.TabIndex = 319;
            this.label14.Text = "Y tá (điều dưỡng) thực hiện và theo dõi";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(185, 469);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(176, 16);
            this.label16.TabIndex = 323;
            this.label16.Text = "Số lượng máu truyền thực :";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(6, 99);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(192, 16);
            this.label17.TabIndex = 324;
            this.label17.Text = "Anti HIV       (âm tính) Kỹ thuật :";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(8, 162);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(152, 16);
            this.label18.TabIndex = 326;
            this.label18.Text = "a. Nhóm máu : Người cho";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // kythuat
            // 
            this.kythuat.BackColor = System.Drawing.SystemColors.HighlightText;
            this.kythuat.Enabled = false;
            this.kythuat.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kythuat.Location = new System.Drawing.Point(164, 96);
            this.kythuat.Name = "kythuat";
            this.kythuat.Size = new System.Drawing.Size(301, 21);
            this.kythuat.TabIndex = 10;
            this.kythuat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // ong1
            // 
            this.ong1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ong1.Enabled = false;
            this.ong1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ong1.Location = new System.Drawing.Point(498, 160);
            this.ong1.Name = "ong1";
            this.ong1.Size = new System.Drawing.Size(134, 21);
            this.ong1.TabIndex = 18;
            this.ong1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // gio_ct
            // 
            this.gio_ct.BackColor = System.Drawing.SystemColors.HighlightText;
            this.gio_ct.Enabled = false;
            this.gio_ct.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gio_ct.Location = new System.Drawing.Point(177, 421);
            this.gio_ct.Mask = "##:##";
            this.gio_ct.Name = "gio_ct";
            this.gio_ct.Size = new System.Drawing.Size(40, 21);
            this.gio_ct.TabIndex = 39;
            this.gio_ct.Text = "  :  ";
            this.gio_ct.Validated += new System.EventHandler(this.gio_ct_Validated);
            // 
            // ngay_ct
            // 
            this.ngay_ct.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngay_ct.Enabled = false;
            this.ngay_ct.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngay_ct.Location = new System.Drawing.Point(105, 421);
            this.ngay_ct.Mask = "##/##/####";
            this.ngay_ct.Name = "ngay_ct";
            this.ngay_ct.Size = new System.Drawing.Size(70, 21);
            this.ngay_ct.TabIndex = 38;
            this.ngay_ct.Text = "  /  /    ";
            this.ngay_ct.Validated += new System.EventHandler(this.ngay_ct_Validated);
            // 
            // label21
            // 
            this.label21.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(76, 423);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(32, 16);
            this.label21.TabIndex = 332;
            this.label21.Text = "Ngày :";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gio_kt
            // 
            this.gio_kt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.gio_kt.Enabled = false;
            this.gio_kt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gio_kt.Location = new System.Drawing.Point(105, 467);
            this.gio_kt.Mask = "##:##";
            this.gio_kt.Name = "gio_kt";
            this.gio_kt.Size = new System.Drawing.Size(40, 21);
            this.gio_kt.TabIndex = 46;
            this.gio_kt.Text = "  :  ";
            this.gio_kt.Validated += new System.EventHandler(this.gio_kt_Validated);
            // 
            // ngay_kt
            // 
            this.ngay_kt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngay_kt.Enabled = false;
            this.ngay_kt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngay_kt.Location = new System.Drawing.Point(145, 467);
            this.ngay_kt.Mask = "##/##/####";
            this.ngay_kt.Name = "ngay_kt";
            this.ngay_kt.Size = new System.Drawing.Size(72, 21);
            this.ngay_kt.TabIndex = 47;
            this.ngay_kt.Text = "  /  /    ";
            this.ngay_kt.Validated += new System.EventHandler(this.ngay_kt_Validated);
            // 
            // label23
            // 
            this.label23.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(4, 469);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(104, 16);
            this.label23.TabIndex = 336;
            this.label23.Text = "Kết thúc truyền hồi :";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbngay
            // 
            this.cmbngay.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cmbngay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbngay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbngay.Location = new System.Drawing.Point(47, 3);
            this.cmbngay.Name = "cmbngay";
            this.cmbngay.Size = new System.Drawing.Size(136, 21);
            this.cmbngay.TabIndex = 0;
            this.cmbngay.SelectedIndexChanged += new System.EventHandler(this.cmbngay_SelectedIndexChanged);
            this.cmbngay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(7, 4);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 16);
            this.label9.TabIndex = 339;
            this.label9.Text = "Ngày :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // butXoa
            // 
            this.butXoa.Enabled = false;
            this.butXoa.Location = new System.Drawing.Point(413, 543);
            this.butXoa.Name = "butXoa";
            this.butXoa.Size = new System.Drawing.Size(70, 25);
            this.butXoa.TabIndex = 60;
            this.butXoa.Text = "&Xóa";
            this.butXoa.Click += new System.EventHandler(this.butXoa_Click);
            // 
            // butThem
            // 
            this.butThem.Enabled = false;
            this.butThem.Location = new System.Drawing.Point(343, 543);
            this.butThem.Name = "butThem";
            this.butThem.Size = new System.Drawing.Size(70, 25);
            this.butThem.TabIndex = 59;
            this.butThem.Text = "&Thêm";
            this.butThem.Click += new System.EventHandler(this.butThem_Click);
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(159, 4);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(80, 16);
            this.label15.TabIndex = 340;
            this.label15.Text = "Phiếu lĩnh :";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // idlinh
            // 
            this.idlinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.idlinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.idlinh.Enabled = false;
            this.idlinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idlinh.Location = new System.Drawing.Point(235, 3);
            this.idlinh.Name = "idlinh";
            this.idlinh.Size = new System.Drawing.Size(109, 21);
            this.idlinh.TabIndex = 3;
            this.idlinh.SelectedIndexChanged += new System.EventHandler(this.idlinh_SelectedIndexChanged);
            this.idlinh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // label24
            // 
            this.label24.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(13, 30);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(120, 16);
            this.label24.TabIndex = 342;
            this.label24.Text = "Loại chế phẩm máu :";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label25
            // 
            this.label25.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(173, 32);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(120, 16);
            this.label25.TabIndex = 343;
            this.label25.Text = "Mã số (tên) :";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label26
            // 
            this.label26.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(370, 30);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(120, 16);
            this.label26.TabIndex = 344;
            this.label26.Text = "Ngày lấy :";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label27
            // 
            this.label27.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(498, 30);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(64, 16);
            this.label27.TabIndex = 345;
            this.label27.Text = "Hạn dùng :";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label28
            // 
            this.label28.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(562, 28);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(120, 16);
            this.label28.TabIndex = 346;
            this.label28.Text = "Số lượng :";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label29
            // 
            this.label29.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label29.Location = new System.Drawing.Point(4, 53);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(376, 16);
            this.label29.TabIndex = 347;
            this.label29.Text = "1. Kết quả sàng lọc các bệnh nhiễm trùng cho đơn vị máu :";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ngaylay
            // 
            this.ngaylay.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngaylay.Enabled = false;
            this.ngaylay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngaylay.Location = new System.Drawing.Point(426, 28);
            this.ngaylay.Mask = "##/##/####";
            this.ngaylay.Name = "ngaylay";
            this.ngaylay.Size = new System.Drawing.Size(72, 21);
            this.ngaylay.TabIndex = 6;
            this.ngaylay.Text = "  /  /    ";
            this.ngaylay.Validated += new System.EventHandler(this.ngaylay_Validated);
            // 
            // handung
            // 
            this.handung.BackColor = System.Drawing.SystemColors.HighlightText;
            this.handung.Enabled = false;
            this.handung.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.handung.Location = new System.Drawing.Point(554, 28);
            this.handung.Mask = "##/##/####";
            this.handung.Name = "handung";
            this.handung.Size = new System.Drawing.Size(72, 21);
            this.handung.TabIndex = 7;
            this.handung.Text = "  /  /    ";
            this.handung.Validated += new System.EventHandler(this.handung_Validated);
            // 
            // chepham
            // 
            this.chepham.BackColor = System.Drawing.SystemColors.HighlightText;
            this.chepham.Enabled = false;
            this.chepham.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chepham.Location = new System.Drawing.Point(112, 28);
            this.chepham.Name = "chepham";
            this.chepham.Size = new System.Drawing.Size(113, 21);
            this.chepham.TabIndex = 4;
            this.chepham.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // maso
            // 
            this.maso.BackColor = System.Drawing.SystemColors.HighlightText;
            this.maso.Enabled = false;
            this.maso.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maso.Location = new System.Drawing.Point(284, 30);
            this.maso.Name = "maso";
            this.maso.Size = new System.Drawing.Size(80, 21);
            this.maso.TabIndex = 5;
            this.maso.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // soluong
            // 
            this.soluong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.soluong.Enabled = false;
            this.soluong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.soluong.Location = new System.Drawing.Point(684, 28);
            this.soluong.Name = "soluong";
            this.soluong.Size = new System.Drawing.Size(35, 21);
            this.soluong.TabIndex = 8;
            this.soluong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // label30
            // 
            this.label30.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.Location = new System.Drawing.Point(46, 107);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(20, 12);
            this.label30.TabIndex = 353;
            this.label30.Text = "1,2";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label31
            // 
            this.label31.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.Location = new System.Drawing.Point(6, 121);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(192, 16);
            this.label31.TabIndex = 354;
            this.label31.Text = "Tên sinh phẩm :";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // sinhpham
            // 
            this.sinhpham.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sinhpham.Enabled = false;
            this.sinhpham.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sinhpham.Location = new System.Drawing.Point(164, 118);
            this.sinhpham.Name = "sinhpham";
            this.sinhpham.Size = new System.Drawing.Size(301, 21);
            this.sinhpham.TabIndex = 11;
            this.sinhpham.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.hbsag);
            this.panel1.Controls.Add(this.hcv);
            this.panel1.Controls.Add(this.giangmai);
            this.panel1.Controls.Add(this.sotret);
            this.panel1.Location = new System.Drawing.Point(4, 93);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(792, 49);
            this.panel1.TabIndex = 356;
            // 
            // hbsag
            // 
            this.hbsag.Enabled = false;
            this.hbsag.Location = new System.Drawing.Point(471, 7);
            this.hbsag.Name = "hbsag";
            this.hbsag.Size = new System.Drawing.Size(72, 40);
            this.hbsag.TabIndex = 12;
            this.hbsag.Text = "HBsAg (âm tính)";
            this.hbsag.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.hbsag.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // hcv
            // 
            this.hcv.Enabled = false;
            this.hcv.Location = new System.Drawing.Point(551, 7);
            this.hcv.Name = "hcv";
            this.hcv.Size = new System.Drawing.Size(72, 40);
            this.hcv.TabIndex = 13;
            this.hcv.Text = "Anti HCV (âm tính)";
            this.hcv.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.hcv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // giangmai
            // 
            this.giangmai.Enabled = false;
            this.giangmai.Location = new System.Drawing.Point(630, 7);
            this.giangmai.Name = "giangmai";
            this.giangmai.Size = new System.Drawing.Size(80, 40);
            this.giangmai.TabIndex = 14;
            this.giangmai.Text = "Giang mai (âm tính)";
            this.giangmai.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.giangmai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // sotret
            // 
            this.sotret.Enabled = false;
            this.sotret.Location = new System.Drawing.Point(710, 7);
            this.sotret.Name = "sotret";
            this.sotret.Size = new System.Drawing.Size(72, 40);
            this.sotret.TabIndex = 15;
            this.sotret.Text = "Sốt rét (âm tính)";
            this.sotret.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.sotret.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Location = new System.Drawing.Point(710, 93);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1, 48);
            this.panel2.TabIndex = 365;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Location = new System.Drawing.Point(-72, -1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(2, 56);
            this.panel3.TabIndex = 366;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Location = new System.Drawing.Point(470, 93);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1, 48);
            this.panel4.TabIndex = 366;
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Location = new System.Drawing.Point(-72, -1);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(2, 56);
            this.panel5.TabIndex = 366;
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.panel7);
            this.panel6.Location = new System.Drawing.Point(550, 93);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1, 48);
            this.panel6.TabIndex = 367;
            // 
            // panel7
            // 
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Location = new System.Drawing.Point(-72, -1);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(2, 56);
            this.panel7.TabIndex = 366;
            // 
            // panel8
            // 
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel8.Controls.Add(this.panel9);
            this.panel8.Location = new System.Drawing.Point(631, 93);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(1, 48);
            this.panel8.TabIndex = 368;
            // 
            // panel9
            // 
            this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel9.Location = new System.Drawing.Point(-72, -1);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(2, 56);
            this.panel9.TabIndex = 366;
            // 
            // label32
            // 
            this.label32.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label32.Location = new System.Drawing.Point(4, 143);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(376, 16);
            this.label32.TabIndex = 369;
            this.label32.Text = "2. Kết quả xét nghiệm hòa hợp nhóm máu :";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label33
            // 
            this.label33.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.Location = new System.Drawing.Point(184, 162);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(96, 16);
            this.label33.TabIndex = 370;
            this.label33.Text = "Bệnh nhân :";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nguoicho
            // 
            this.nguoicho.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nguoicho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nguoicho.Enabled = false;
            this.nguoicho.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nguoicho.Location = new System.Drawing.Point(136, 160);
            this.nguoicho.Name = "nguoicho";
            this.nguoicho.Size = new System.Drawing.Size(80, 21);
            this.nguoicho.TabIndex = 16;
            this.nguoicho.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // benhnhan
            // 
            this.benhnhan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.benhnhan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.benhnhan.Enabled = false;
            this.benhnhan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.benhnhan.Location = new System.Drawing.Point(284, 160);
            this.benhnhan.Name = "benhnhan";
            this.benhnhan.Size = new System.Drawing.Size(80, 21);
            this.benhnhan.TabIndex = 17;
            this.benhnhan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // label34
            // 
            this.label34.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.Location = new System.Drawing.Point(363, 162);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(144, 16);
            this.label34.TabIndex = 373;
            this.label34.Text = "b. Phản ứng chéo : Ống 1 :";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(578, 162);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(96, 16);
            this.label19.TabIndex = 374;
            this.label19.Text = "Ống 2 :";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ong2
            // 
            this.ong2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ong2.Enabled = false;
            this.ong2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ong2.Location = new System.Drawing.Point(672, 160);
            this.ong2.Name = "ong2";
            this.ong2.Size = new System.Drawing.Size(124, 21);
            this.ong2.TabIndex = 19;
            this.ong2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // label35
            // 
            this.label35.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label35.Location = new System.Drawing.Point(92, 184);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(136, 16);
            this.label35.TabIndex = 376;
            this.label35.Text = "Trưởng khoa XN :";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // truongkhoa
            // 
            this.truongkhoa.BackColor = System.Drawing.SystemColors.HighlightText;
            this.truongkhoa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.truongkhoa.Enabled = false;
            this.truongkhoa.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.truongkhoa.Location = new System.Drawing.Point(176, 182);
            this.truongkhoa.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.truongkhoa.MaxLength = 9;
            this.truongkhoa.Name = "truongkhoa";
            this.truongkhoa.Size = new System.Drawing.Size(38, 21);
            this.truongkhoa.TabIndex = 20;
            this.truongkhoa.Validated += new System.EventHandler(this.truongkhoa_Validated);
            this.truongkhoa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // tentruongkhoa
            // 
            this.tentruongkhoa.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tentruongkhoa.Enabled = false;
            this.tentruongkhoa.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tentruongkhoa.Location = new System.Drawing.Point(215, 182);
            this.tentruongkhoa.Name = "tentruongkhoa";
            this.tentruongkhoa.Size = new System.Drawing.Size(190, 21);
            this.tentruongkhoa.TabIndex = 21;
            this.tentruongkhoa.TextChanged += new System.EventHandler(this.tentruongkhoa_TextChanged);
            this.tentruongkhoa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbs_KeyDown);
            // 
            // ktv1
            // 
            this.ktv1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ktv1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ktv1.Enabled = false;
            this.ktv1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ktv1.Location = new System.Drawing.Point(176, 204);
            this.ktv1.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.ktv1.MaxLength = 9;
            this.ktv1.Name = "ktv1";
            this.ktv1.Size = new System.Drawing.Size(38, 21);
            this.ktv1.TabIndex = 22;
            this.ktv1.Validated += new System.EventHandler(this.ktv1_Validated);
            this.ktv1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // tenktv1
            // 
            this.tenktv1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenktv1.Enabled = false;
            this.tenktv1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenktv1.Location = new System.Drawing.Point(216, 204);
            this.tenktv1.Name = "tenktv1";
            this.tenktv1.Size = new System.Drawing.Size(189, 21);
            this.tenktv1.TabIndex = 23;
            this.tenktv1.TextChanged += new System.EventHandler(this.tenktv1_TextChanged);
            this.tenktv1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbs_KeyDown);
            // 
            // ktv2
            // 
            this.ktv2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ktv2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ktv2.Enabled = false;
            this.ktv2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ktv2.Location = new System.Drawing.Point(498, 204);
            this.ktv2.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.ktv2.MaxLength = 9;
            this.ktv2.Name = "ktv2";
            this.ktv2.Size = new System.Drawing.Size(44, 21);
            this.ktv2.TabIndex = 24;
            this.ktv2.Validated += new System.EventHandler(this.ktv2_Validated);
            this.ktv2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // tenktv2
            // 
            this.tenktv2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenktv2.Enabled = false;
            this.tenktv2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenktv2.Location = new System.Drawing.Point(542, 204);
            this.tenktv2.Name = "tenktv2";
            this.tenktv2.Size = new System.Drawing.Size(254, 21);
            this.tenktv2.TabIndex = 25;
            this.tenktv2.TextChanged += new System.EventHandler(this.tenktv2_TextChanged);
            this.tenktv2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbs_KeyDown);
            // 
            // label36
            // 
            this.label36.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.Location = new System.Drawing.Point(20, 206);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(173, 16);
            this.label36.TabIndex = 383;
            this.label36.Text = "BS/KTV phát máu : Người thứ 1 :";
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label37
            // 
            this.label37.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label37.Location = new System.Drawing.Point(430, 206);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(74, 16);
            this.label37.TabIndex = 384;
            this.label37.Text = "Người thứ 2 :";
            this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label38
            // 
            this.label38.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label38.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label38.Location = new System.Drawing.Point(1, 226);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(376, 16);
            this.label38.TabIndex = 385;
            this.label38.Text = "3. Chỉ định, thực hiện và theo dõi truyền máu tại giường bệnh :";
            this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label39
            // 
            this.label39.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label39.Location = new System.Drawing.Point(38, 246);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(152, 16);
            this.label39.TabIndex = 386;
            this.label39.Text = "Loại chế phẩm, máu truyền :";
            this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // masotr
            // 
            this.masotr.BackColor = System.Drawing.SystemColors.HighlightText;
            this.masotr.Enabled = false;
            this.masotr.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.masotr.Location = new System.Drawing.Point(498, 244);
            this.masotr.Name = "masotr";
            this.masotr.Size = new System.Drawing.Size(77, 21);
            this.masotr.TabIndex = 27;
            this.masotr.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // chephamtr
            // 
            this.chephamtr.BackColor = System.Drawing.SystemColors.HighlightText;
            this.chephamtr.Enabled = false;
            this.chephamtr.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chephamtr.Location = new System.Drawing.Point(175, 244);
            this.chephamtr.Name = "chephamtr";
            this.chephamtr.Size = new System.Drawing.Size(230, 21);
            this.chephamtr.TabIndex = 26;
            this.chephamtr.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // handungtr
            // 
            this.handungtr.BackColor = System.Drawing.SystemColors.HighlightText;
            this.handungtr.Enabled = false;
            this.handungtr.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.handungtr.Location = new System.Drawing.Point(639, 244);
            this.handungtr.Mask = "##/##/####";
            this.handungtr.Name = "handungtr";
            this.handungtr.Size = new System.Drawing.Size(72, 21);
            this.handungtr.TabIndex = 28;
            this.handungtr.Text = "  /  /    ";
            this.handungtr.Validated += new System.EventHandler(this.handungtr_Validated);
            this.handungtr.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // label40
            // 
            this.label40.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label40.Location = new System.Drawing.Point(583, 246);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(64, 16);
            this.label40.TabIndex = 388;
            this.label40.Text = "Hạn dùng :";
            this.label40.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label41
            // 
            this.label41.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label41.Location = new System.Drawing.Point(381, 246);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(120, 16);
            this.label41.TabIndex = 387;
            this.label41.Text = "Mã số (tên) :";
            this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label42
            // 
            this.label42.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label42.Location = new System.Drawing.Point(710, 246);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(64, 16);
            this.label42.TabIndex = 392;
            this.label42.Text = "Lần thứ :";
            this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lanthu
            // 
            this.lanthu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.lanthu.Enabled = false;
            this.lanthu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lanthu.Location = new System.Drawing.Point(756, 244);
            this.lanthu.Name = "lanthu";
            this.lanthu.Size = new System.Drawing.Size(40, 21);
            this.lanthu.TabIndex = 29;
            this.lanthu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // label43
            // 
            this.label43.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label43.Location = new System.Drawing.Point(102, 267);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(152, 16);
            this.label43.TabIndex = 394;
            this.label43.Text = "Bác sĩ chỉ định :";
            this.label43.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bscd
            // 
            this.bscd.BackColor = System.Drawing.SystemColors.HighlightText;
            this.bscd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.bscd.Enabled = false;
            this.bscd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bscd.Location = new System.Drawing.Point(175, 266);
            this.bscd.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.bscd.MaxLength = 9;
            this.bscd.Name = "bscd";
            this.bscd.Size = new System.Drawing.Size(41, 21);
            this.bscd.TabIndex = 30;
            this.bscd.Validated += new System.EventHandler(this.bscd_Validated);
            this.bscd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // tenbscd
            // 
            this.tenbscd.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbscd.Enabled = false;
            this.tenbscd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbscd.Location = new System.Drawing.Point(218, 266);
            this.tenbscd.Name = "tenbscd";
            this.tenbscd.Size = new System.Drawing.Size(253, 21);
            this.tenbscd.TabIndex = 31;
            this.tenbscd.TextChanged += new System.EventHandler(this.tenbscd_TextChanged);
            this.tenbscd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbs_KeyDown);
            // 
            // benhnhantr
            // 
            this.benhnhantr.BackColor = System.Drawing.SystemColors.HighlightText;
            this.benhnhantr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.benhnhantr.Enabled = false;
            this.benhnhantr.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.benhnhantr.Location = new System.Drawing.Point(378, 288);
            this.benhnhantr.Name = "benhnhantr";
            this.benhnhantr.Size = new System.Drawing.Size(72, 21);
            this.benhnhantr.TabIndex = 33;
            this.benhnhantr.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // nguoichotr
            // 
            this.nguoichotr.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nguoichotr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nguoichotr.Enabled = false;
            this.nguoichotr.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nguoichotr.Location = new System.Drawing.Point(174, 288);
            this.nguoichotr.Name = "nguoichotr";
            this.nguoichotr.Size = new System.Drawing.Size(80, 21);
            this.nguoichotr.TabIndex = 32;
            this.nguoichotr.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // label44
            // 
            this.label44.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label44.Location = new System.Drawing.Point(245, 290);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(136, 16);
            this.label44.TabIndex = 398;
            this.label44.Text = "Nhóm máu bệnh nhân :";
            this.label44.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label45
            // 
            this.label45.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label45.Location = new System.Drawing.Point(29, 290);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(152, 16);
            this.label45.TabIndex = 397;
            this.label45.Text = "Nhóm máu người cho :";
            this.label45.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label46
            // 
            this.label46.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label46.Location = new System.Drawing.Point(459, 290);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(152, 16);
            this.label46.TabIndex = 401;
            this.label46.Text = "Phản ứng hòa hợp tại :";
            this.label46.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tai
            // 
            this.tai.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tai.Enabled = false;
            this.tai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tai.Location = new System.Drawing.Point(572, 288);
            this.tai.Name = "tai";
            this.tai.Size = new System.Drawing.Size(224, 21);
            this.tai.TabIndex = 34;
            this.tai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // label47
            // 
            this.label47.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label47.Location = new System.Drawing.Point(-18, 312);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(200, 16);
            this.label47.TabIndex = 403;
            this.label47.Text = "Lượng máu, chế phẩm truyền :";
            this.label47.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // soluongtr
            // 
            this.soluongtr.BackColor = System.Drawing.SystemColors.HighlightText;
            this.soluongtr.Enabled = false;
            this.soluongtr.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.soluongtr.Location = new System.Drawing.Point(174, 310);
            this.soluongtr.Name = "soluongtr";
            this.soluongtr.Size = new System.Drawing.Size(80, 21);
            this.soluongtr.TabIndex = 35;
            this.soluongtr.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // label48
            // 
            this.label48.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label48.Location = new System.Drawing.Point(277, 312);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(200, 16);
            this.label48.TabIndex = 405;
            this.label48.Text = "Bắt đầu truyền hồi :";
            this.label48.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gio_bd
            // 
            this.gio_bd.BackColor = System.Drawing.SystemColors.HighlightText;
            this.gio_bd.Enabled = false;
            this.gio_bd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gio_bd.Location = new System.Drawing.Point(377, 310);
            this.gio_bd.Mask = "##:##";
            this.gio_bd.Name = "gio_bd";
            this.gio_bd.Size = new System.Drawing.Size(40, 21);
            this.gio_bd.TabIndex = 36;
            this.gio_bd.Text = "  :  ";
            this.gio_bd.Validated += new System.EventHandler(this.gio_bd_Validated);
            // 
            // ngay_bd
            // 
            this.ngay_bd.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngay_bd.Enabled = false;
            this.ngay_bd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngay_bd.Location = new System.Drawing.Point(419, 310);
            this.ngay_bd.Mask = "##/##/####";
            this.ngay_bd.Name = "ngay_bd";
            this.ngay_bd.Size = new System.Drawing.Size(72, 21);
            this.ngay_bd.TabIndex = 37;
            this.ngay_bd.Text = "  /  /    ";
            this.ngay_bd.Validated += new System.EventHandler(this.ngay_bd_Validated);
            // 
            // label49
            // 
            this.label49.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label49.Location = new System.Drawing.Point(54, 446);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(59, 16);
            this.label49.TabIndex = 408;
            this.label49.Text = "Sắc mặt :";
            this.label49.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sacmat_ct
            // 
            this.sacmat_ct.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sacmat_ct.Enabled = false;
            this.sacmat_ct.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sacmat_ct.Location = new System.Drawing.Point(105, 444);
            this.sacmat_ct.Name = "sacmat_ct";
            this.sacmat_ct.Size = new System.Drawing.Size(112, 21);
            this.sacmat_ct.TabIndex = 40;
            this.sacmat_ct.Validated += new System.EventHandler(this.sacmat_ct_Validated);
            this.sacmat_ct.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // nhietdo_ct
            // 
            this.nhietdo_ct.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nhietdo_ct.Enabled = false;
            this.nhietdo_ct.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhietdo_ct.Location = new System.Drawing.Point(359, 444);
            this.nhietdo_ct.Mask = "##.##";
            this.nhietdo_ct.Name = "nhietdo_ct";
            this.nhietdo_ct.Size = new System.Drawing.Size(32, 21);
            this.nhietdo_ct.TabIndex = 42;
            this.nhietdo_ct.Text = "  .  ";
            // 
            // huyetap_ct
            // 
            this.huyetap_ct.BackColor = System.Drawing.SystemColors.HighlightText;
            this.huyetap_ct.Enabled = false;
            this.huyetap_ct.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.huyetap_ct.Location = new System.Drawing.Point(443, 444);
            this.huyetap_ct.Mask = "###/###";
            this.huyetap_ct.Name = "huyetap_ct";
            this.huyetap_ct.Size = new System.Drawing.Size(45, 21);
            this.huyetap_ct.TabIndex = 43;
            this.huyetap_ct.Text = "   /   ";
            // 
            // nhiptho_ct
            // 
            this.nhiptho_ct.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nhiptho_ct.Enabled = false;
            this.nhiptho_ct.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhiptho_ct.Location = new System.Drawing.Point(269, 444);
            this.nhiptho_ct.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.nhiptho_ct.MaxLength = 5;
            this.nhiptho_ct.Name = "nhiptho_ct";
            this.nhiptho_ct.Size = new System.Drawing.Size(32, 21);
            this.nhiptho_ct.TabIndex = 41;
            // 
            // mach_ct
            // 
            this.mach_ct.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mach_ct.Enabled = false;
            this.mach_ct.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mach_ct.Location = new System.Drawing.Point(564, 444);
            this.mach_ct.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.mach_ct.MaxLength = 5;
            this.mach_ct.Name = "mach_ct";
            this.mach_ct.Size = new System.Drawing.Size(32, 21);
            this.mach_ct.TabIndex = 44;
            // 
            // label50
            // 
            this.label50.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label50.Location = new System.Drawing.Point(522, 446);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(48, 16);
            this.label50.TabIndex = 418;
            this.label50.Text = "Mạch :";
            this.label50.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label51
            // 
            this.label51.Location = new System.Drawing.Point(608, 446);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(48, 16);
            this.label51.TabIndex = 414;
            this.label51.Text = "l/p";
            this.label51.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label53
            // 
            this.label53.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label53.Location = new System.Drawing.Point(394, 446);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(24, 16);
            this.label53.TabIndex = 415;
            this.label53.Text = "°C";
            this.label53.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label54
            // 
            this.label54.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label54.Location = new System.Drawing.Point(417, 446);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(32, 16);
            this.label54.TabIndex = 420;
            this.label54.Text = "HA :";
            this.label54.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label55
            // 
            this.label55.Location = new System.Drawing.Point(490, 446);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(38, 16);
            this.label55.TabIndex = 416;
            this.label55.Text = "mmHg";
            this.label55.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label56
            // 
            this.label56.Location = new System.Drawing.Point(301, 446);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(21, 16);
            this.label56.TabIndex = 417;
            this.label56.Text = "l/p";
            this.label56.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label57
            // 
            this.label57.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label57.Location = new System.Drawing.Point(216, 446);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(59, 16);
            this.label57.TabIndex = 421;
            this.label57.Text = "Nhịp thở :";
            this.label57.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label58
            // 
            this.label58.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label58.Location = new System.Drawing.Point(342, 446);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(24, 16);
            this.label58.TabIndex = 422;
            this.label58.Text = "T° :";
            this.label58.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label52
            // 
            this.label52.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label52.Location = new System.Drawing.Point(212, 423);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(64, 16);
            this.label52.TabIndex = 423;
            this.label52.Text = "Diễn biến :";
            this.label52.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dienbien_ct
            // 
            this.dienbien_ct.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dienbien_ct.Enabled = false;
            this.dienbien_ct.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dienbien_ct.Location = new System.Drawing.Point(269, 421);
            this.dienbien_ct.Name = "dienbien_ct";
            this.dienbien_ct.Size = new System.Drawing.Size(527, 21);
            this.dienbien_ct.TabIndex = 45;
            this.dienbien_ct.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // soluongthuc
            // 
            this.soluongthuc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.soluongthuc.Enabled = false;
            this.soluongthuc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.soluongthuc.Location = new System.Drawing.Point(359, 467);
            this.soluongthuc.Name = "soluongthuc";
            this.soluongthuc.Size = new System.Drawing.Size(129, 21);
            this.soluongthuc.TabIndex = 48;
            this.soluongthuc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // sacmat
            // 
            this.sacmat.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sacmat.Enabled = false;
            this.sacmat.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sacmat.Location = new System.Drawing.Point(105, 489);
            this.sacmat.Name = "sacmat";
            this.sacmat.Size = new System.Drawing.Size(112, 21);
            this.sacmat.TabIndex = 49;
            this.sacmat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // dienbien
            // 
            this.dienbien.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dienbien.Enabled = false;
            this.dienbien.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dienbien.Location = new System.Drawing.Point(564, 467);
            this.dienbien.Name = "dienbien";
            this.dienbien.Size = new System.Drawing.Size(231, 21);
            this.dienbien.TabIndex = 54;
            this.dienbien.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sophieu_KeyDown);
            // 
            // label20
            // 
            this.label20.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label20.Location = new System.Drawing.Point(506, 469);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(64, 16);
            this.label20.TabIndex = 440;
            this.label20.Text = "Diễn biến :";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label22
            // 
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(342, 491);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(24, 16);
            this.label22.TabIndex = 439;
            this.label22.Text = "T° :";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nhietdo
            // 
            this.nhietdo.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nhietdo.Enabled = false;
            this.nhietdo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhietdo.Location = new System.Drawing.Point(359, 489);
            this.nhietdo.Mask = "##.##";
            this.nhietdo.Name = "nhietdo";
            this.nhietdo.Size = new System.Drawing.Size(32, 21);
            this.nhietdo.TabIndex = 51;
            this.nhietdo.Text = "  .  ";
            // 
            // huyetap
            // 
            this.huyetap.BackColor = System.Drawing.SystemColors.HighlightText;
            this.huyetap.Enabled = false;
            this.huyetap.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.huyetap.Location = new System.Drawing.Point(443, 489);
            this.huyetap.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.huyetap.MaxLength = 7;
            this.huyetap.Name = "huyetap";
            this.huyetap.Size = new System.Drawing.Size(45, 21);
            this.huyetap.TabIndex = 52;
            // 
            // nhiptho
            // 
            this.nhiptho.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nhiptho.Enabled = false;
            this.nhiptho.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhiptho.Location = new System.Drawing.Point(269, 489);
            this.nhiptho.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.nhiptho.MaxLength = 5;
            this.nhiptho.Name = "nhiptho";
            this.nhiptho.Size = new System.Drawing.Size(32, 21);
            this.nhiptho.TabIndex = 50;
            // 
            // mach
            // 
            this.mach.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mach.Enabled = false;
            this.mach.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mach.Location = new System.Drawing.Point(564, 489);
            this.mach.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.mach.MaxLength = 5;
            this.mach.Name = "mach";
            this.mach.Size = new System.Drawing.Size(32, 21);
            this.mach.TabIndex = 53;
            // 
            // label59
            // 
            this.label59.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label59.Location = new System.Drawing.Point(522, 491);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(48, 16);
            this.label59.TabIndex = 436;
            this.label59.Text = "Mạch :";
            this.label59.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label60
            // 
            this.label60.Location = new System.Drawing.Point(602, 491);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(48, 16);
            this.label60.TabIndex = 432;
            this.label60.Text = "l/p";
            this.label60.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label61
            // 
            this.label61.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label61.Location = new System.Drawing.Point(381, 491);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(24, 16);
            this.label61.TabIndex = 433;
            this.label61.Text = "°C";
            this.label61.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label62
            // 
            this.label62.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label62.Location = new System.Drawing.Point(417, 491);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(32, 16);
            this.label62.TabIndex = 437;
            this.label62.Text = "HA :";
            this.label62.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label63
            // 
            this.label63.Location = new System.Drawing.Point(486, 491);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(38, 16);
            this.label63.TabIndex = 434;
            this.label63.Text = "mmHg";
            this.label63.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label64
            // 
            this.label64.Location = new System.Drawing.Point(301, 491);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(21, 16);
            this.label64.TabIndex = 435;
            this.label64.Text = "l/p";
            this.label64.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label65
            // 
            this.label65.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label65.Location = new System.Drawing.Point(216, 491);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(59, 16);
            this.label65.TabIndex = 438;
            this.label65.Text = "Nhịp thở :";
            this.label65.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label66
            // 
            this.label66.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label66.Location = new System.Drawing.Point(53, 491);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(59, 16);
            this.label66.TabIndex = 426;
            this.label66.Text = "Sắc mặt :";
            this.label66.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmTruyenmau
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(829, 579);
            this.ControlBox = false;
            this.Controls.Add(this.handungtr);
            this.Controls.Add(this.label55);
            this.Controls.Add(this.label63);
            this.Controls.Add(this.benhnhan);
            this.Controls.Add(this.tenbs);
            this.Controls.Add(this.gio);
            this.Controls.Add(this.sacmat);
            this.Controls.Add(this.dienbien);
            this.Controls.Add(this.nhietdo);
            this.Controls.Add(this.huyetap);
            this.Controls.Add(this.nhiptho);
            this.Controls.Add(this.mach);
            this.Controls.Add(this.label59);
            this.Controls.Add(this.label60);
            this.Controls.Add(this.label61);
            this.Controls.Add(this.label62);
            this.Controls.Add(this.label64);
            this.Controls.Add(this.label65);
            this.Controls.Add(this.label66);
            this.Controls.Add(this.soluongthuc);
            this.Controls.Add(this.sacmat_ct);
            this.Controls.Add(this.gio_ct);
            this.Controls.Add(this.dienbien_ct);
            this.Controls.Add(this.label52);
            this.Controls.Add(this.nhietdo_ct);
            this.Controls.Add(this.huyetap_ct);
            this.Controls.Add(this.nhiptho_ct);
            this.Controls.Add(this.mach_ct);
            this.Controls.Add(this.label50);
            this.Controls.Add(this.label51);
            this.Controls.Add(this.label53);
            this.Controls.Add(this.label54);
            this.Controls.Add(this.label56);
            this.Controls.Add(this.label57);
            this.Controls.Add(this.label49);
            this.Controls.Add(this.tai);
            this.Controls.Add(this.tenbscd);
            this.Controls.Add(this.gio_bd);
            this.Controls.Add(this.ngay_bd);
            this.Controls.Add(this.label48);
            this.Controls.Add(this.soluongtr);
            this.Controls.Add(this.label47);
            this.Controls.Add(this.label46);
            this.Controls.Add(this.benhnhantr);
            this.Controls.Add(this.nguoichotr);
            this.Controls.Add(this.label44);
            this.Controls.Add(this.label45);
            this.Controls.Add(this.bscd);
            this.Controls.Add(this.label43);
            this.Controls.Add(this.lanthu);
            this.Controls.Add(this.label42);
            this.Controls.Add(this.masotr);
            this.Controls.Add(this.chephamtr);
            this.Controls.Add(this.label40);
            this.Controls.Add(this.label41);
            this.Controls.Add(this.label39);
            this.Controls.Add(this.label38);
            this.Controls.Add(this.ktv1);
            this.Controls.Add(this.ktv2);
            this.Controls.Add(this.label37);
            this.Controls.Add(this.label36);
            this.Controls.Add(this.tenktv2);
            this.Controls.Add(this.tenktv1);
            this.Controls.Add(this.truongkhoa);
            this.Controls.Add(this.tentruongkhoa);
            this.Controls.Add(this.label35);
            this.Controls.Add(this.ong1);
            this.Controls.Add(this.ong2);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label34);
            this.Controls.Add(this.nguoicho);
            this.Controls.Add(this.label33);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.sinhpham);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.soluong);
            this.Controls.Add(this.maso);
            this.Controls.Add(this.chepham);
            this.Controls.Add(this.handung);
            this.Controls.Add(this.ngaylay);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.idlinh);
            this.Controls.Add(this.butXoa);
            this.Controls.Add(this.butThem);
            this.Controls.Add(this.tenyta);
            this.Controls.Add(this.kythuat);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.mabs);
            this.Controls.Add(this.gio_kt);
            this.Controls.Add(this.ngay_kt);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.ngay_ct);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.noilam);
            this.Controls.Add(this.yta);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.chkXML);
            this.Controls.Add(this.listNv);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.butHuy);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butSua);
            this.Controls.Add(this.butMoi);
            this.Controls.Add(this.ngay);
            this.Controls.Add(this.lgio);
            this.Controls.Add(this.label87);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cmbngay);
            this.Controls.Add(this.label15);
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
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label58);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label20);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTruyenmau";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phiếu truyền máu";
            this.Load += new System.EventHandler(this.frmTruyenmau_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lanthu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmTruyenmau_Load(object sender, System.EventArgs e)
		{
            this.Location = new System.Drawing.Point(188, 151);
			user=m.user;
	
			xxx=user+m.mmyy(ngayvv.Text);
			nguoicho.DisplayMember="TEN";
			nguoicho.ValueMember="MA";
            nguoicho.DataSource = m.get_data("select * from " + user + ".dmnhommau where ma<>0").Tables[0];

			benhnhan.DisplayMember="TEN";
			benhnhan.ValueMember="MA";
            benhnhan.DataSource = m.get_data("select * from " + user + ".dmnhommau where ma<>0").Tables[0];

			nguoichotr.DisplayMember="TEN";
			nguoichotr.ValueMember="MA";
            nguoichotr.DataSource = m.get_data("select * from " + user + ".dmnhommau where ma<>0").Tables[0];

			benhnhantr.DisplayMember="TEN";
			benhnhantr.ValueMember="MA";
            benhnhantr.DataSource = m.get_data("select * from " + user + ".dmnhommau where ma<>0").Tables[0];

            dtnv = m.get_data("select * from " + user + ".dmbs where nhom<>" + LibMedi.AccessData.nghiviec + " order by hoten").Tables[0];
			listNv.DisplayMember="MA";
			listNv.ValueMember="HOTEN";
			listNv.DataSource=dtnv;

			idlinh.DisplayMember="NGAY";
			idlinh.ValueMember="ID";
			load_linh("");

			sql="select a.id,a.idthuchien,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay,";
			sql+="a.chepham,a.maso,to_char(a.ngaylay,'dd/mm/yyyy') as ngaylay,to_char(a.handung,'dd/mm/yyyy') as handung,";
			sql+="a.soluong,a.noilam,a.kythuat,a.sinhpham,a.hbsag,a.hcv,a.sotret,a.nguoicho,a.benhnhan,a.ong1,";
            sql += "a.ong2,a.truongkhoa,a.ktv1,a.ktv2,'' as giangmai,";//,a.giangmai
			sql+="a.chephamtr,a.masotr,to_char(a.handungtr,'dd/mm/yyyy') as handungtr,a.lanthu,a.bscd,a.nguoichotr,";
			sql+="a.benhnhantr,a.tai,a.soluongtr,to_char(a.batdau,'dd/mm/yyyy hh24:mi') as batdau,";
			sql+="to_char(a.ketthuc,'dd/mm/yyyy hh24:mi') as ketthuc,a.soluongthuc,";
			sql+="a.sacmat,a.nhiptho,a.nhietdo,a.huyetap,a.mach,a.dienbien,a.bsth,a.yta,a.idlinh";
			sql+=" from "+xxx+".ba_truyenmau a,"+xxx+".ba_thuchien b ";
			sql+=" where a.idthuchien=b.id and b.idkhoa="+l_idkhoa;
			sql+=" order by a.id";				

			dsh=m.get_data(sql);
			cmbngay.DisplayMember="NGAY";
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
		}

		private void load_linh(string dk)
		{
			sql="select a.id,to_char(a.ngaylinh,'dd/mm/yyyy') as ngay,to_char(a.ngayphat,'dd/mm/yyyy') as ngayphat,";
			sql+="a.bvphat,c.chepham,c.maso,c.nhommau,a.dvphat as donvi";
			sql+=" from "+xxx+".ba_linhmau a,"+xxx+".ba_thuchien b,"+xxx+".ba_linhmauct c";
			sql+=" where a.id=c.id and a.idthuchien=b.id and b.idkhoa="+l_idkhoa;
			if (dk!="") sql+=dk;
			sql+=" order by a.ngaylinh";
			dtlinh=m.get_data(sql).Tables[0];
			idlinh.DataSource=dtlinh;
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
			sql="select stt,to_char(ngay,'dd/mm/yyyy hh24:mi') as ngay,";
			sql+="sacmat,nhiptho,nhietdo,huyetap,mach,dienbien from "+xxx+".ba_truyenmauct ";
			sql+=" where id="+l_id;
			sql+=" order by stt";
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
			TextCol1.MappingName = "ngay";
			TextCol1.HeaderText = "Ngày";
			TextCol1.Width =100;
			TextCol1.ReadOnly=true;
			TextCol1.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new FormattableTextBoxColumn();
			TextCol1.MappingName = "sacmat";
			TextCol1.HeaderText = "Sắc mặt";
			TextCol1.Width =200;
			TextCol1.ReadOnly=true;
			TextCol1.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new FormattableTextBoxColumn();
			TextCol1.MappingName = "nhiptho";
			TextCol1.HeaderText = "Nhịp thở";
			TextCol1.Width =70;
			TextCol1.ReadOnly=true;
			TextCol1.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new FormattableTextBoxColumn();
			TextCol1.MappingName = "nhietdo";
			TextCol1.HeaderText = "Nhiệt độ";
			TextCol1.Width =70;
			TextCol1.ReadOnly=true;
			TextCol1.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new FormattableTextBoxColumn();
			TextCol1.MappingName = "huyetap";
			TextCol1.HeaderText = "Huyết áp";
			TextCol1.Width =70;
			TextCol1.ReadOnly=true;
			TextCol1.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new FormattableTextBoxColumn();
			TextCol1.MappingName = "mach";
			TextCol1.HeaderText = "Mạch";
			TextCol1.Width =70;
			TextCol1.ReadOnly=true;
			TextCol1.SetCellFormat += new FormatCellEventHandler(SetCellFormat);
			ts.GridColumnStyles.Add(TextCol1);
			dataGrid1.TableStyles.Add(ts);

			TextCol1=new FormattableTextBoxColumn();
			TextCol1.MappingName = "dienbien";
			TextCol1.HeaderText = "Diễn biến";
			TextCol1.Width = 270;
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
				ngay_ct.Text=r["ngay"].ToString().Substring(0,10);
				gio_ct.Text=r["ngay"].ToString().Substring(11);

				sacmat_ct.Text=r["sacmat"].ToString();
				nhiptho_ct.Text=(r["nhiptho"].ToString()!="0")?r["nhiptho"].ToString():"";
				nhietdo_ct.Text=(r["nhietdo"].ToString()!="0")?r["nhietdo"].ToString():"";
				huyetap_ct.Text=r["huyetap"].ToString();
				mach_ct.Text=(r["mach"].ToString()!="0")?r["mach"].ToString():"";
				dienbien_ct.Text=r["dienbien"].ToString();			
			}
		}

		private void emp_detail()
		{
			ngay_ct.Text=ngay.Text;
			gio_ct.Text=gio.Text;
			i_stt=1;
			if (ds.Tables[0].Rows.Count>0) i_stt=int.Parse(ds.Tables[0].Rows[ds.Tables[0].Rows.Count-1]["stt"].ToString())+1;
			sacmat_ct.Text="";nhiptho_ct.Text="";nhietdo_ct.Text="";huyetap_ct.Text="";mach_ct.Text="";dienbien_ct.Text="";
		}

		private void emp_text()
		{
			l_id=0;
			string _ngay=m.ngayhienhanh_server;
			ngay.Text=_ngay.Substring(0,10);
			gio.Text=_ngay.Substring(11);
			chepham.Text="";maso.Text="";ngaylay.Text=ngay.Text;handung.Text="";soluong.Text="";noilam.Text="";
			kythuat.Text="";sinhpham.Text="";hbsag.Checked=false;hcv.Checked=false;giangmai.Checked=false;sotret.Checked=false;
			nguoicho.SelectedIndex=0;benhnhan.SelectedIndex=0;ong1.Text="";ong2.Text="";
			truongkhoa.Text="";tentruongkhoa.Text="";ktv1.Text="";tenktv1.Text="";ktv2.Text="";tenktv2.Text="";
			chephamtr.Text="";masotr.Text="";handungtr.Text="";lanthu.Value=1;bscd.Text="";tenbscd.Text="";nguoichotr.SelectedIndex=0;
			benhnhantr.SelectedIndex=0;tai.Text="";soluongtr.Text="";
			mabs.Text="";tenbs.Text="";ngay_bd.Text=ngay.Text;gio_bd.Text=gio.Text;
			ngay_kt.Text="";gio_kt.Text="";soluongthuc.Text="";sacmat.Text="";nhiptho.Text="";nhietdo.Text="";
			huyetap.Text="";mach.Text="";dienbien.Text="";mabs.Text="";tenbs.Text="";yta.Text="";tenyta.Text="";
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
			gio.Visible=ena;
			ngay.Enabled=ena;
			gio.Enabled=ena;

			idlinh.Enabled=ena;
			chepham.Enabled=ena;
			maso.Enabled=ena;
			ngaylay.Enabled=ena;
			handung.Enabled=ena;
			soluong.Enabled=ena;
			noilam.Enabled=ena;
			kythuat.Enabled=ena;
			sinhpham.Enabled=ena;
			hbsag.Enabled=ena;
			hcv.Enabled=ena;
			giangmai.Enabled=ena;
			sotret.Enabled=ena;
			nguoicho.Enabled=ena;
			benhnhan.Enabled=ena;
			ong1.Enabled=ena;
			ong2.Enabled=ena;
			truongkhoa.Enabled=ena;
			tentruongkhoa.Enabled=ena;
			ktv1.Enabled=ena;
			tenktv1.Enabled=ena;
			ktv2.Enabled=ena;
			tenktv2.Enabled=ena;
			chephamtr.Enabled=ena;
			masotr.Enabled=ena;
			handungtr.Enabled=ena;
			lanthu.Enabled=ena;
			bscd.Enabled=ena;
			tenbscd.Enabled=ena;
			nguoichotr.Enabled=ena;
			benhnhantr.Enabled=ena;
			tai.Enabled=ena;
			soluongtr.Enabled=ena;

			ngay_bd.Enabled=ena;
			gio_bd.Enabled=ena;
			ngay_kt.Enabled=ena;
			gio_kt.Enabled=ena;
			
			ngay_ct.Enabled=ena;
			gio_ct.Enabled=ena;
			sacmat_ct.Enabled=ena;
			nhiptho_ct.Enabled=ena;
			nhietdo_ct.Enabled=ena;
			huyetap_ct.Enabled=ena;
			mach_ct.Enabled=ena;
			dienbien_ct.Enabled=ena;
			soluongthuc.Enabled=ena;
			sacmat.Enabled=ena;
			nhiptho.Enabled=ena;
			nhietdo.Enabled=ena;
			huyetap.Enabled=ena;
			mach.Enabled=ena;
			dienbien.Enabled=ena;
			mabs.Enabled=ena;
			tenbs.Enabled=ena;
			yta.Enabled=ena;
			tenyta.Enabled=ena;

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
			load_linh(" and a.done=0");
			load_idlinh();
			ngay.Focus();
		}

		private void butSua_Click(object sender, System.EventArgs e)
		{
			if (dsh.Tables[0].Rows.Count==0) return;
			ngay.Text=cmbngay.Text.ToString().Substring(0,10);
			gio.Text=cmbngay.Text.ToString().Substring(11);			
			ena_object(true);
			idlinh.Enabled=false;
			ngay_ct.Focus();
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
				xxx=user+m.mmyy(ngayvv.Text.ToString());
				m.execute_data("delete from "+xxx+".ba_truyenmauct where id="+l_id);
				m.execute_data("delete from "+xxx+".ba_truyenmau where id="+l_id);				
				if (idlinh.SelectedIndex!=-1) m.execute_data("update "+xxx+".ba_linhmau set done=0 where id="+decimal.Parse(idlinh.SelectedValue.ToString()));
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
			load_head();
			load_grid();
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
			if (mabs.Text=="" || tenbs.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Bác sĩ thực hiện !"),LibMedi.AccessData.Msg);
				if (mabs.Text=="") mabs.Focus();
				else tenbs.Focus();
				return false;
			}
			if (mabs.Text!="" && tenbs.Text!="")
			{
				DataRow r=m.getrowbyid(dtnv,"ma='"+mabs.Text+"'");
				if (r==null)
				{
					MessageBox.Show(lan.Change_language_MessageText("Nhập bác sĩ thực hiện !"),LibMedi.AccessData.Msg);
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
			if (idlinh.SelectedIndex==-1)
			{
				MessageBox.Show(lan.Change_language_MessageText("Chọn phiếu lĩnh máu !"),LibMedi.AccessData.Msg);
				idlinh.Focus();
				return false;
			}
			return true;
		}

		private bool kiemtrad()
		{
			if (ngay_ct.Text.Trim().Length!=10)
			{
				MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"),LibMedi.AccessData.Msg);
				ngay_ct.Focus();
				return false;
			}
			if (gio_ct.Text.Trim().Length!=5)
			{
				MessageBox.Show(lan.Change_language_MessageText("Giờ không hợp lệ !"),LibMedi.AccessData.Msg);
				gio_ct.Focus();
				return false;
			}
			if (!m.bNgaygio(ngay_ct.Text+" "+gio_ct.Text,ngay_bd.Text+" "+gio_bd.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Ngày giờ thực hiện không được nhỏ hơn ngày giờ bắt đầu !"),LibMedi.AccessData.Msg);
				ngay_ct.Focus();
				return false;
			}
			return true;
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			if (!kiemtra()) return;
			mmyy=m.mmyy(ngayvv.Text);
			if (!m.bMmyy(mmyy)) m.tao_schema(mmyy,i_userid);
			xxx=user+mmyy;
			l_idthuchien=m.get_idthuchien(ngayvv.Text,l_idkhoa);
			if (l_idthuchien==0) 
			{
				l_idthuchien=m.get_capid(-300);
				m.upd_ba_thuchien(ngayvv.Text,l_idthuchien,mabn.Text,l_maql,l_idkhoa,s_makp,phong.Text,giuong.Text,chandoan.Text);
			}
			if (l_id==0) l_id=m.get_capid(-408);
			if (!upd_itemsd()) return;
            m.upd_ba_truyenmau1(ngayvv.Text, mabn.Text, l_id, l_idthuchien, ngay.Text + " " + gio.Text, chepham.Text, maso.Text, ngaylay.Text,
				handung.Text,soluong.Text,noilam.Text,kythuat.Text,sinhpham.Text,(hbsag.Checked)?1:0,(hcv.Checked)?1:0,
				(giangmai.Checked)?1:0,(sotret.Checked)?1:0,int.Parse(nguoicho.SelectedValue.ToString()),int.Parse(benhnhan.SelectedValue.ToString()),
				ong1.Text,ong2.Text,truongkhoa.Text,ktv1.Text,ktv2.Text,chephamtr.Text,masotr.Text,handungtr.Text,lanthu.Value,
				bscd.Text,int.Parse(nguoichotr.SelectedValue.ToString()),int.Parse(benhnhantr.SelectedValue.ToString()),
				tai.Text,soluongtr.Text);
            m.upd_ba_truyenmau2(ngayvv.Text, mabn.Text, l_id, ngay_bd.Text + " " + gio_bd.Text, ngay_kt.Text + " " + gio_kt.Text, soluongthuc.Text, sacmat.Text,
				(nhiptho.Text!="")?decimal.Parse(nhiptho.Text):0,(nhietdo.Text!="")?decimal.Parse(nhietdo.Text):0,
				huyetap.Text,(mach.Text!="")?decimal.Parse(mach.Text):0,dienbien.Text,mabs.Text,yta.Text,decimal.Parse(idlinh.SelectedValue.ToString()),i_userid);
			upd_items();
			m.execute_data_mmyy("delete from xxx.ba_truyendichct where id="+l_id,ngayvv.Text,s_ngayrv,false);
			ds.AcceptChanges();
			foreach(DataRow r in ds.Tables[0].Rows)
				m.upd_ba_truyenmauct(ngayvv.Text,l_id,int.Parse(r["stt"].ToString()),r["ngay"].ToString(),r["sacmat"].ToString(),decimal.Parse(r["nhiptho"].ToString()),decimal.Parse(r["nhietdo"].ToString()),r["huyetap"].ToString(),decimal.Parse(r["mach"].ToString()),r["dienbien"].ToString());
			if (idlinh.SelectedIndex!=-1) m.execute_data("update "+xxx+".ba_linhmau set done=1 where id="+decimal.Parse(idlinh.SelectedValue.ToString()));
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

				r2["chepham"]=chepham.Text;
				r2["maso"]=maso.Text;
				r2["ngaylay"]=ngaylay.Text;
				r2["handung"]=handung.Text;
				r2["soluong"]=soluong.Text;
				r2["noilam"]=noilam.Text;
				r2["kythuat"]=kythuat.Text;
				r2["sinhpham"]=sinhpham.Text;
				r2["hbsag"]=(hbsag.Checked)?1:0;
				r2["hcv"]=(hcv.Checked)?1:0;
				r2["giangmai"]=(giangmai.Checked)?1:0;
				r2["sotret"]=(sotret.Checked)?1:0;
				r2["nguoicho"]=nguoicho.SelectedValue.ToString();
				r2["benhnhan"]=benhnhan.SelectedValue.ToString();
				r2["ong1"]=ong1.Text;
				r2["ong2"]=ong2.Text;

				r2["chephamtr"]=chephamtr.Text;
				r2["masotr"]=masotr.Text;
				r2["handungtr"]=handungtr.Text;
				r2["lanthu"]=lanthu.Value;
				r2["nguoichotr"]=nguoichotr.SelectedValue.ToString();
				r2["benhnhantr"]=benhnhantr.SelectedValue.ToString();
				r2["tai"]=tai.Text;
				r2["soluongtr"]=soluongtr.Text;
				r2["batdau"]=ngay_bd.Text+" "+gio_bd.Text;
				r2["ketthuc"]=ngay_kt.Text+" "+gio_kt.Text;
				r2["sacmat"]=sacmat.Text;
				r2["nhiptho"]=(nhiptho.Text!="")?decimal.Parse(nhiptho.Text):0;
				r2["nhietdo"]=(nhietdo.Text!="")?decimal.Parse(nhietdo.Text):0;
				r2["huyetap"]=huyetap.Text;
				r2["mach"]=(mach.Text!="")?decimal.Parse(mach.Text):0;
				r2["dienbien"]=dienbien.Text;

				r2["bsth"]=mabs.Text;
				r2["truongkhoa"]=truongkhoa.Text;
				r2["ktv1"]=ktv1.Text;
				r2["ktv2"]=ktv2.Text;
				r2["bsth"]=mabs.Text;
				r2["yta"]=yta.Text;
				r2["idlinh"]=idlinh.SelectedValue.ToString();
				dsh.Tables[0].Rows.Add(r2);
			}
			else
			{
				DataRow [] dr=dsh.Tables[0].Select("id="+l_id);
				dr[0]["idthuchien"]=l_idthuchien;
				dr[0]["ngay"]=ngay.Text+" "+gio.Text;
				dr[0]["chepham"]=chepham.Text;
				dr[0]["maso"]=maso.Text;
				dr[0]["ngaylay"]=ngaylay.Text;
				dr[0]["handung"]=handung.Text;
				dr[0]["soluong"]=soluong.Text;
				dr[0]["noilam"]=noilam.Text;
				dr[0]["kythuat"]=kythuat.Text;
				dr[0]["sinhpham"]=sinhpham.Text;
				dr[0]["hbsag"]=(hbsag.Checked)?1:0;
				dr[0]["hcv"]=(hcv.Checked)?1:0;
				dr[0]["giangmai"]=(giangmai.Checked)?1:0;
				dr[0]["sotret"]=(sotret.Checked)?1:0;
				dr[0]["nguoicho"]=nguoicho.SelectedValue.ToString();
				dr[0]["benhnhan"]=benhnhan.SelectedValue.ToString();
				dr[0]["ong1"]=ong1.Text;
				dr[0]["ong2"]=ong2.Text;

				dr[0]["chephamtr"]=chephamtr.Text;
				dr[0]["masotr"]=masotr.Text;
				dr[0]["handungtr"]=handungtr.Text;
				dr[0]["lanthu"]=lanthu.Value;
				dr[0]["nguoichotr"]=nguoichotr.SelectedValue.ToString();
				dr[0]["benhnhantr"]=benhnhantr.SelectedValue.ToString();
				dr[0]["tai"]=tai.Text;
				dr[0]["soluongtr"]=soluongtr.Text;
				dr[0]["batdau"]=ngay_bd.Text+" "+gio_bd.Text;
				dr[0]["ketthuc"]=ngay_kt.Text+" "+gio_kt.Text;
				dr[0]["sacmat"]=sacmat.Text;
				dr[0]["nhiptho"]=(nhiptho.Text!="")?decimal.Parse(nhiptho.Text):0;
				dr[0]["nhietdo"]=(nhietdo.Text!="")?decimal.Parse(nhietdo.Text):0;
				dr[0]["huyetap"]=huyetap.Text;
				dr[0]["mach"]=(mach.Text!="")?decimal.Parse(mach.Text):0;
				dr[0]["dienbien"]=dienbien.Text;

				dr[0]["bsth"]=mabs.Text;
				dr[0]["truongkhoa"]=truongkhoa.Text;
				dr[0]["ktv1"]=ktv1.Text;
				dr[0]["ktv2"]=ktv2.Text;
				dr[0]["bsth"]=mabs.Text;
				dr[0]["yta"]=yta.Text;
				dr[0]["idlinh"]=idlinh.SelectedValue.ToString();
			}
		}

		private bool upd_itemsd()
		{
			if (sacmat_ct.Text!="")
			{
				if (!kiemtrad()) return false;
				DataRow r1,r2;
				r1=m.getrowbyid(ds.Tables[0],"stt="+i_stt);
				if (r1==null)
				{
					r2=ds.Tables[0].NewRow();
					r2["stt"]=i_stt;
					r2["ngay"]=ngay_ct.Text+" "+gio_ct.Text;
					r2["sacmat"]=sacmat_ct.Text;
					r2["nhiptho"]=(nhiptho_ct.Text!="")?decimal.Parse(nhiptho_ct.Text):0;
					r2["nhietdo"]=(nhietdo_ct.Text!="")?decimal.Parse(nhietdo_ct.Text):0;
					r2["huyetap"]=huyetap_ct.Text;
					r2["mach"]=(mach_ct.Text!="")?decimal.Parse(mach_ct.Text):0;
					r2["dienbien"]=dienbien_ct.Text;
					r2["chon"]=false;
					ds.Tables[0].Rows.Add(r2);
				}
				else
				{
					DataRow [] dr=ds.Tables[0].Select("stt="+i_stt);
					dr[0]["ngay"]=ngay_ct.Text+" "+gio_ct.Text;
					dr[0]["sacmat"]=sacmat_ct.Text;
					dr[0]["nhiptho"]=(nhiptho_ct.Text!="")?decimal.Parse(nhiptho_ct.Text):0;
					dr[0]["nhietdo"]=(nhietdo_ct.Text!="")?decimal.Parse(nhietdo_ct.Text):0;
					dr[0]["huyetap"]=huyetap_ct.Text;
					dr[0]["mach"]=(mach_ct.Text!="")?decimal.Parse(mach_ct.Text):0;
					dr[0]["dienbien"]=dienbien_ct.Text;
				}
				emp_detail();
			}
			return true;
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			string s_stt="",stuoi=m.get_tuoivao(l_maql).Trim();
            foreach (DataRow r1 in ds.Tables[0].Select("chon=true")) s_stt += r1["stt"].ToString() + ",";
            sql = "select b.stt,'' as sovaovien,'' as mabn,'' as hoten,'' as tuoi,'' as phai,'' as tenkp,";
            sql += "'' as phong,'' as giuong,'' as chandoan,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay,";
            sql += "a.chepham,a.maso,to_char(a.ngaylay,'dd/mm/yyyy') as ngaylay,";
            sql += "to_char(a.handung,'dd/mm/yyyy') as handung,a.soluong,a.noilam,a.kythuat,a.sinhpham,";
            sql += "i.ten as nguoicho,j.ten as benhnhan,a.ong1,a.ong2,c.hoten as truongkhoa,d.hoten as ktv1,";
            sql += "e.hoten as ktv2,a.chephamtr,a.masotr,to_char(a.handungtr,'dd/mm/yyyy') as handungtr,";
            sql += "a.lanthu,f.hoten as bscd,k.ten as nguoichotr,l.ten as benhnhantr,a.tai,a.soluongtr,";
            sql += "to_char(a.batdau,'dd/mm/yyyy hh24:mi') as batdau,";
            sql += "to_char(a.ketthuc,'dd/mm/yyyy hh24:mi') as ketthuc,";
            sql += "a.soluongthuc,g.hoten as bsth,h.hoten as yta,";
            sql += "'' as i_truongkhoa,'' as i_ktv1,'' as i_ktv2,'' as i_bscd,'' as i_bsth,";//c.image,d.image,e.image,f.image,g.image
            sql += "'' as i_yta,to_char(b.ngay,'dd/mm/yyyy hh24:mi') as ngaytruyen,";//h.image
            sql += "b.sacmat,b.nhiptho,b.nhietdo,b.huyetap,b.mach,b.dienbien, ";
            sql += "a.sacmat as sacmatkt,a.nhiptho as nhipthokt,a.nhietdo as nhietdokt,a.huyetap as huyetapkt,a.mach as machkt,a.dienbien as dienbienkt";
            sql += " from " + xxx + ".ba_truyenmau a inner join " + xxx + ".ba_truyenmauct b on a.id=b.id left join " + user + ".dmbs c on a.truongkhoa=c.ma";
            sql += " left join " + user + ".dmbs d on a.ktv1=d.ma left join " + user + ".dmbs e on a.ktv2=e.ma left join " + user + ".dmbs f on a.bscd=f.ma";
            sql += " left join " + user + ".dmbs g on a.bsth=g.ma left join " + user + ".dmbs h on a.yta=h.ma inner join " + user + ".dmnhommau i on a.nguoicho=i.ma";
            sql += " inner join " + user + ".dmnhommau j on a.benhnhan=j.ma inner join " + user + ".dmnhommau k on a.nguoichotr=k.ma inner join " + user + ".dmnhommau l on a.benhnhantr=l.ma";
            sql += " where a.id=" + l_id;
            if (s_stt != "") sql += " and b.stt in (" + s_stt.Substring(0, s_stt.Length - 1) + ")";
            DataSet dsxml = m.get_data(sql);
			if (chkXML.Checked)
			{
				if (!System.IO.Directory.Exists("..\\xml")) System.IO.Directory.CreateDirectory("..\\xml");
				dsxml.WriteXml("..\\xml\\truyenmau.xml",XmlWriteMode.WriteSchema);
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
				dllReportM.frmReport f=new dllReportM.frmReport(m,dsxml,"","r16bv.rpt");
				f.ShowDialog();
			}
			else MessageBox.Show(lan.Change_language_MessageText("Không có số liệu !"),LibMedi.AccessData.Msg);
		}


		private void yta_Validated(object sender, System.EventArgs e)
		{
			if (yta.Text=="") return;
			DataRow r=m.getrowbyid(dtnv,"ma='"+yta.Text+"'");
			if (r!=null) tenyta.Text=r["hoten"].ToString();
			else tenyta.Text="";	
		}

		private void tenyta_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tenyta)
			{
				Filt_dmbs(tenyta.Text);
				listNv.BrowseToDanhmuc(tenyta,yta,butThem,35);
			}		
		}

		private void butThem_Click(object sender, System.EventArgs e)
		{
			if (!upd_itemsd()) return;
			ngay_ct.Focus();
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
			load_linh("");
			DataRow r=m.getrowbyid(dsh.Tables[0],"id="+l_id);
			if (r!=null)
			{
				ngay.Text=r["ngay"].ToString().Substring(0,10);
				gio.Text=r["ngay"].ToString().Substring(11);
				chepham.Text=r["chepham"].ToString();
				maso.Text=r["maso"].ToString();
				ngaylay.Text=r["ngaylay"].ToString();
				handung.Text=r["handung"].ToString();
				soluong.Text=r["soluong"].ToString();
				noilam.Text=r["noilam"].ToString();
				kythuat.Text=r["kythuat"].ToString();
				sinhpham.Text=r["sinhpham"].ToString();
				hbsag.Checked=r["hbsag"].ToString()=="1";
				hcv.Checked=r["hcv"].ToString()=="1";
				giangmai.Checked=r["giangmai"].ToString()=="1";
				sotret.Checked=r["sotret"].ToString()=="1";
				nguoicho.SelectedValue=r["nguoicho"].ToString();
				benhnhan.SelectedValue=r["benhnhan"].ToString();
				ong1.Text=r["ong1"].ToString();
				ong2.Text=r["ong2"].ToString();

				chephamtr.Text=r["chephamtr"].ToString();
				masotr.Text=r["masotr"].ToString();
				handungtr.Text=r["handungtr"].ToString();
				lanthu.Value=decimal.Parse(r["lanthu"].ToString());
				nguoichotr.SelectedValue=r["nguoichotr"].ToString();
				benhnhantr.SelectedValue=r["benhnhantr"].ToString();
				tai.Text=r["tai"].ToString();
				soluongtr.Text=r["soluongtr"].ToString();
				ngay_bd.Text=(r["batdau"].ToString().Length==16)?r["batdau"].ToString().Substring(0,10):"";
				gio_bd.Text=(r["batdau"].ToString().Length==16)?r["batdau"].ToString().Substring(11):"";
				ngay_kt.Text=(r["ketthuc"].ToString().Length==16)?r["ketthuc"].ToString().Substring(0,10):"";
				gio_kt.Text=(r["ketthuc"].ToString().Length==16)?r["ketthuc"].ToString().Substring(11):"";
				sacmat.Text=r["sacmat"].ToString();
				nhiptho.Text=(r["nhiptho"].ToString()!="0")?r["nhiptho"].ToString():"";
				nhietdo.Text=(r["nhietdo"].ToString()!="0")?r["nhietdo"].ToString():"";
				huyetap.Text=r["huyetap"].ToString();
				mach.Text=(r["mach"].ToString()!="0")?r["mach"].ToString():"";
				dienbien.Text=r["dienbien"].ToString();

				mabs.Text=r["bsth"].ToString();
				DataRow r1=m.getrowbyid(dtnv,"ma='"+mabs.Text+"'");
				if (r1!=null) tenbs.Text=r1["hoten"].ToString();
				else tenbs.Text="";	
				
				truongkhoa.Text=r["truongkhoa"].ToString();
				r1=m.getrowbyid(dtnv,"ma='"+truongkhoa.Text+"'");
				if (r1!=null) tentruongkhoa.Text=r1["hoten"].ToString();
				else tentruongkhoa.Text="";	

				ktv1.Text=r["ktv1"].ToString();
				r1=m.getrowbyid(dtnv,"ma='"+ktv1.Text+"'");
				if (r1!=null) tenktv1.Text=r1["hoten"].ToString();
				else tenktv1.Text="";	

				ktv2.Text=r["ktv2"].ToString();
				r1=m.getrowbyid(dtnv,"ma='"+ktv2.Text+"'");
				if (r1!=null) tenktv2.Text=r1["hoten"].ToString();
				else tenktv2.Text="";	

				mabs.Text=r["bsth"].ToString();
				r1=m.getrowbyid(dtnv,"ma='"+mabs.Text+"'");
				if (r1!=null) tenbs.Text=r1["hoten"].ToString();
				else tenbs.Text="";	

				yta.Text=r["yta"].ToString();
				r1=m.getrowbyid(dtnv,"ma='"+yta.Text+"'");
				if (r1!=null) tenyta.Text=r1["hoten"].ToString();
				else tenyta.Text="";	

				idlinh.SelectedValue=r["idlinh"].ToString();
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

		private void ngay_ct_Validated(object sender, System.EventArgs e)
		{
			ngay_ct.Text=ngay_ct.Text.Trim();
			if (ngay_ct.Text.Length==6) ngay_ct.Text=ngay_ct.Text+DateTime.Now.Year.ToString();
			if (!m.bNgay(ngay_ct.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"));
				ngay_ct.Focus();
				return;
			}
		}

		private void gio_ct_Validated(object sender, System.EventArgs e)
		{
			string sgio=(gio_ct.Text.Trim()=="")?"00:00":gio_ct.Text.Trim();
			gio_ct.Text=sgio.Substring(0,2).PadLeft(2,'0')+":"+sgio.Substring(3).Trim().PadRight(2,'0');
			if (!m.bGio(gio_ct.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Giờ không hợp lệ !"));
				gio_ct.Focus();
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
			else butThem.Focus();
		}

		private void ngaylay_Validated(object sender, System.EventArgs e)
		{
			ngaylay.Text=ngaylay.Text.Trim();
			if (ngaylay.Text.Length==6) ngaylay.Text=ngaylay.Text+DateTime.Now.Year.ToString();
			if (!m.bNgay(ngaylay.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"));
				ngaylay.Focus();
				return;
			}
		}

		private void handung_Validated(object sender, System.EventArgs e)
		{
			if (handung.Text!="")
			{
				handung.Text=handung.Text.Trim();
				if (handung.Text.Length==6) handung.Text=handung.Text+DateTime.Now.Year.ToString();
				if (!m.bNgay(handung.Text))
				{
					MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"));
					handung.Focus();
					return;
				}
				if (handungtr.Text=="") handungtr.Text=handung.Text;
                int ss_ngay = DateTime.Compare(m.StringToDate(ngaylay.Text), m.StringToDate(handung.Text));
                if (ss_ngay == 1)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Hạn dùng không hợp lệ!"));
                    handung.Focus();
                    return;
                }
			}
		}

		private void handungtr_Validated(object sender, System.EventArgs e)
		{
			if (handungtr.Text!="")
			{
				handungtr.Text=handungtr.Text.Trim();
				if (handungtr.Text.Length==6) handungtr.Text=handungtr.Text+DateTime.Now.Year.ToString();
				if (!m.bNgay(handungtr.Text))
				{
					MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"));
					handungtr.Focus();
					return;
				}
			}		
		}

		private void truongkhoa_Validated(object sender, System.EventArgs e)
		{
			if (truongkhoa.Text=="") return;
			DataRow r=m.getrowbyid(dtnv,"ma='"+truongkhoa.Text+"'");
			if (r!=null) tentruongkhoa.Text=r["hoten"].ToString();
			else tentruongkhoa.Text="";			
		}

		private void ktv1_Validated(object sender, System.EventArgs e)
		{
			if (ktv1.Text=="") return;
			DataRow r=m.getrowbyid(dtnv,"ma='"+ktv1.Text+"'");
			if (r!=null) tenktv1.Text=r["hoten"].ToString();
			else tenktv1.Text="";	
		}

		private void tentruongkhoa_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tentruongkhoa)
			{
				Filt_dmbs(tentruongkhoa.Text);
				listNv.BrowseToDanhmuc(tentruongkhoa,truongkhoa,ktv1,35);
			}		
		}

		private void tenktv1_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tenktv1)
			{
				Filt_dmbs(tenktv1.Text);
				listNv.BrowseToDanhmuc(tenktv1,ktv1,ktv2,35);
			}		
		}

		private void ktv2_Validated(object sender, System.EventArgs e)
		{
			if (ktv2.Text=="") return;
			DataRow r=m.getrowbyid(dtnv,"ma='"+ktv2.Text+"'");
			if (r!=null) tenktv2.Text=r["hoten"].ToString();
			else tenktv2.Text="";	
		}

		private void tenktv2_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tenktv2)
			{
				Filt_dmbs(tenktv2.Text);
				listNv.BrowseToDanhmuc(tenktv2,ktv2,chephamtr,35);
			}				
		}

		private void bscd_Validated(object sender, System.EventArgs e)
		{
			if (bscd.Text=="") return;
			DataRow r=m.getrowbyid(dtnv,"ma='"+bscd.Text+"'");
			if (r!=null) tenbscd.Text=r["hoten"].ToString();
			else tenbscd.Text="";	
		}

		private void tenbscd_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tenbscd)
			{
				Filt_dmbs(tenbscd.Text);
				listNv.BrowseToDanhmuc(tenbscd,bscd,nguoichotr,35);
			}				
		}

		private void idlinh_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==idlinh) load_idlinh();
		}

		private void load_idlinh()
		{
			if (idlinh.SelectedIndex!=-1)
			{
				DataRow r=m.getrowbyid(dtlinh,"id="+decimal.Parse(idlinh.SelectedValue.ToString()));
				if (r!=null)
				{
					ngaylay.Text=r["ngayphat"].ToString();
					chepham.Text=r["chepham"].ToString();
					maso.Text=r["maso"].ToString();
					soluong.Text=r["donvi"].ToString();
					noilam.Text=r["bvphat"].ToString();
					nguoicho.SelectedValue=r["nhommau"].ToString();
					benhnhan.SelectedValue=r["nhommau"].ToString();
					chephamtr.Text=r["chepham"].ToString();
					masotr.Text=r["maso"].ToString();
					soluongtr.Text=r["donvi"].ToString();
					nguoichotr.SelectedValue=r["nhommau"].ToString();
					benhnhantr.SelectedValue=r["nhommau"].ToString();
				}
			}
		}

		private void sacmat_ct_Validated(object sender, System.EventArgs e)
		{
			if (sacmat_ct.Text=="") gio_kt.Focus();
		}
	}
}
