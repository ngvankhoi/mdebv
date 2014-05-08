using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibMedi;
using LibDuoc;

namespace Medisoft
{
	/// <summary>
	/// Summary description for frmBahausangan.
	/// </summary>
	public class frmBahausangan : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
        Language lan = new Language(); Bogotiengviet tv = new Bogotiengviet(); private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();

        private System.ComponentModel.Container components = null;
		private string sql,s_msg,xxx,s_tenkp,user,s_makp,s_mabs,s_userid,mmyy,s_ngayrv;
		private decimal l_maql,l_id,l_idkhoa,l_idthuchien;
		private int i_userid;
		private bool bAdmin;
		public string s_theodoi="";
		private DataTable dtnv=new DataTable();
		private DataSet ds=new DataSet();
		private System.Windows.Forms.Label label168;
		private MaskedBox.MaskedBox ngaychuyenda;
		private MaskedBox.MaskedBox giochuyenda;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.TextBox tienluong;
		private System.Windows.Forms.TextBox xutri;
		private System.Windows.Forms.TextBox tentheodoi;
		private MaskedTextBox.MaskedTextBox theodoi;
		private System.Windows.Forms.Label label133;
		private LibList.List listNv1;
		private System.Windows.Forms.Label label149;
		private System.Windows.Forms.Label label150;
		private System.Windows.Forms.Label label151;
		private System.Windows.Forms.Label label152;
		private System.Windows.Forms.Label label155;
		private System.Windows.Forms.Label label156;
		private System.Windows.Forms.Label label157;
		private System.Windows.Forms.Label label158;
		private MaskedBox.MaskedBox nhietdo;
		private MaskedTextBox.MaskedTextBox huyetap;
		private MaskedTextBox.MaskedTextBox nhiptho;
		private MaskedTextBox.MaskedTextBox mach;
		private System.Windows.Forms.TextBox theodoi_pass;
		private System.Windows.Forms.CheckBox chkXml;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox toantrang;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tim;
		private System.Windows.Forms.TextBox phoi;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox tucung;
		private System.Windows.Forms.Label label116;
		private System.Windows.Forms.Label label144;
		private MaskedTextBox.MaskedTextBox maumat;
		private System.Windows.Forms.Label label143;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox nuoctieu;
		private System.Windows.Forms.TextBox tresosinh;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox ngayvv;
		private System.Windows.Forms.TextBox sovaovien;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox chandoan;
		private System.Windows.Forms.TextBox sothe;
		private System.Windows.Forms.TextBox giuong;
		private System.Windows.Forms.TextBox phong;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox diachi;
		private System.Windows.Forms.TextBox phai;
		private System.Windows.Forms.TextBox namsinh;
		private System.Windows.Forms.TextBox hoten;
		private System.Windows.Forms.TextBox mabn;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Button butKetthuc;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.Button butHuy;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butSua;
		private System.Windows.Forms.Button butMoi;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.ComboBox tangsinhmon;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.ComboBox tinhchat;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.TextBox khac;
		private LibMedi.AccessData m;
		private LibDuoc.AccessData d=new LibDuoc.AccessData();
		private Brush disabledBackBrush;
		private Brush disabledTextBrush;
		private Brush alertBackBrush;
		private Font alertFont;
		private Brush alertTextBrush;
		private Font currentRowFont;
		private Brush currentRowBackBrush;
		private bool afterCurrentCellChanged=true;
		private int checkCol=0;

		public frmBahausangan(LibMedi.AccessData acc,string _mabn,decimal _maql,decimal _idkhoa,string _sovaovien,string _makp,string _hoten,string _namsinh,string _phai,string _diachi,string _ngayvv,string _sothe,string _phong,string _giuong,string _ngayrv,string _mabs,int _userid,string suserid,string _chandoan,string _tenkp,bool _admin)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            //Language lan = new Language();
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBahausangan));
            this.label168 = new System.Windows.Forms.Label();
            this.ngaychuyenda = new MaskedBox.MaskedBox();
            this.giochuyenda = new MaskedBox.MaskedBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.tienluong = new System.Windows.Forms.TextBox();
            this.xutri = new System.Windows.Forms.TextBox();
            this.tentheodoi = new System.Windows.Forms.TextBox();
            this.theodoi = new MaskedTextBox.MaskedTextBox();
            this.label133 = new System.Windows.Forms.Label();
            this.listNv1 = new LibList.List();
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
            this.theodoi_pass = new System.Windows.Forms.TextBox();
            this.chkXml = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toantrang = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tim = new System.Windows.Forms.TextBox();
            this.phoi = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tucung = new System.Windows.Forms.TextBox();
            this.label116 = new System.Windows.Forms.Label();
            this.label144 = new System.Windows.Forms.Label();
            this.maumat = new MaskedTextBox.MaskedTextBox();
            this.label143 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nuoctieu = new System.Windows.Forms.TextBox();
            this.tresosinh = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ngayvv = new System.Windows.Forms.TextBox();
            this.sovaovien = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chandoan = new System.Windows.Forms.TextBox();
            this.sothe = new System.Windows.Forms.TextBox();
            this.giuong = new System.Windows.Forms.TextBox();
            this.phong = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.diachi = new System.Windows.Forms.TextBox();
            this.phai = new System.Windows.Forms.TextBox();
            this.namsinh = new System.Windows.Forms.TextBox();
            this.hoten = new System.Windows.Forms.TextBox();
            this.mabn = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.butIn = new System.Windows.Forms.Button();
            this.butHuy = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.butSua = new System.Windows.Forms.Button();
            this.butMoi = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.tangsinhmon = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.tinhchat = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.khac = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // label168
            // 
            this.label168.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label168.Location = new System.Drawing.Point(260, 75);
            this.label168.Name = "label168";
            this.label168.Size = new System.Drawing.Size(38, 16);
            this.label168.TabIndex = 456;
            this.label168.Text = "Ngày :";
            this.label168.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ngaychuyenda
            // 
            this.ngaychuyenda.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngaychuyenda.Enabled = false;
            this.ngaychuyenda.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngaychuyenda.Location = new System.Drawing.Point(301, 73);
            this.ngaychuyenda.Mask = "##/##/####";
            this.ngaychuyenda.Name = "ngaychuyenda";
            this.ngaychuyenda.Size = new System.Drawing.Size(64, 21);
            this.ngaychuyenda.TabIndex = 0;
            this.ngaychuyenda.Text = "  /  /    ";
            this.ngaychuyenda.Validated += new System.EventHandler(this.ngaychuyenda_Validated);
            // 
            // giochuyenda
            // 
            this.giochuyenda.BackColor = System.Drawing.SystemColors.HighlightText;
            this.giochuyenda.Enabled = false;
            this.giochuyenda.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.giochuyenda.Location = new System.Drawing.Point(389, 73);
            this.giochuyenda.Mask = "##:##";
            this.giochuyenda.Name = "giochuyenda";
            this.giochuyenda.Size = new System.Drawing.Size(40, 21);
            this.giochuyenda.TabIndex = 1;
            this.giochuyenda.Text = "  :  ";
            this.giochuyenda.Validated += new System.EventHandler(this.giochuyenda_Validated);
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(365, 75);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(24, 16);
            this.label9.TabIndex = 457;
            this.label9.Text = "giờ :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label25
            // 
            this.label25.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(226, 313);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(72, 16);
            this.label25.TabIndex = 473;
            this.label25.Text = "Tiên lượng :";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label26
            // 
            this.label26.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(218, 363);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(80, 16);
            this.label26.TabIndex = 474;
            this.label26.Text = "Hướng xử trí :";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tienluong
            // 
            this.tienluong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tienluong.Enabled = false;
            this.tienluong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tienluong.Location = new System.Drawing.Point(301, 311);
            this.tienluong.Multiline = true;
            this.tienluong.Name = "tienluong";
            this.tienluong.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tienluong.Size = new System.Drawing.Size(483, 52);
            this.tienluong.TabIndex = 16;
            // 
            // xutri
            // 
            this.xutri.BackColor = System.Drawing.SystemColors.HighlightText;
            this.xutri.Enabled = false;
            this.xutri.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xutri.Location = new System.Drawing.Point(301, 364);
            this.xutri.Multiline = true;
            this.xutri.Name = "xutri";
            this.xutri.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.xutri.Size = new System.Drawing.Size(483, 52);
            this.xutri.TabIndex = 17;
            // 
            // tentheodoi
            // 
            this.tentheodoi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tentheodoi.Enabled = false;
            this.tentheodoi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tentheodoi.Location = new System.Drawing.Point(339, 418);
            this.tentheodoi.Name = "tentheodoi";
            this.tentheodoi.Size = new System.Drawing.Size(365, 21);
            this.tentheodoi.TabIndex = 19;
            this.tentheodoi.TextChanged += new System.EventHandler(this.tentheodoi_TextChanged);
            this.tentheodoi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tentheodoi_KeyDown);
            // 
            // theodoi
            // 
            this.theodoi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.theodoi.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.theodoi.Enabled = false;
            this.theodoi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.theodoi.Location = new System.Drawing.Point(301, 418);
            this.theodoi.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.theodoi.MaxLength = 9;
            this.theodoi.Name = "theodoi";
            this.theodoi.Size = new System.Drawing.Size(36, 21);
            this.theodoi.TabIndex = 18;
            this.theodoi.Validated += new System.EventHandler(this.theodoi_Validated);
            // 
            // label133
            // 
            this.label133.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label133.Location = new System.Drawing.Point(210, 419);
            this.label133.Name = "label133";
            this.label133.Size = new System.Drawing.Size(88, 16);
            this.label133.TabIndex = 481;
            this.label133.Text = "Người theo dõi :";
            this.label133.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // listNv1
            // 
            this.listNv1.BackColor = System.Drawing.SystemColors.Info;
            this.listNv1.ColumnCount = 0;
            this.listNv1.Location = new System.Drawing.Point(680, 72);
            this.listNv1.MatchBufferTimeOut = 1000;
            this.listNv1.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listNv1.Name = "listNv1";
            this.listNv1.Size = new System.Drawing.Size(75, 17);
            this.listNv1.TabIndex = 482;
            this.listNv1.TextIndex = -1;
            this.listNv1.TextMember = null;
            this.listNv1.ValueIndex = -1;
            this.listNv1.Visible = false;
            // 
            // nhietdo
            // 
            this.nhietdo.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nhietdo.Enabled = false;
            this.nhietdo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhietdo.Location = new System.Drawing.Point(445, 150);
            this.nhietdo.Mask = "##.##";
            this.nhietdo.Name = "nhietdo";
            this.nhietdo.Size = new System.Drawing.Size(32, 21);
            this.nhietdo.TabIndex = 4;
            this.nhietdo.Text = "  .  ";
            // 
            // huyetap
            // 
            this.huyetap.BackColor = System.Drawing.SystemColors.HighlightText;
            this.huyetap.Enabled = false;
            this.huyetap.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.huyetap.Location = new System.Drawing.Point(556, 150);
            this.huyetap.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.huyetap.MaxLength = 7;
            this.huyetap.Name = "huyetap";
            this.huyetap.Size = new System.Drawing.Size(45, 21);
            this.huyetap.TabIndex = 5;
            // 
            // nhiptho
            // 
            this.nhiptho.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nhiptho.Enabled = false;
            this.nhiptho.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhiptho.Location = new System.Drawing.Point(695, 150);
            this.nhiptho.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.nhiptho.MaxLength = 5;
            this.nhiptho.Name = "nhiptho";
            this.nhiptho.Size = new System.Drawing.Size(32, 21);
            this.nhiptho.TabIndex = 6;
            this.nhiptho.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // mach
            // 
            this.mach.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mach.Enabled = false;
            this.mach.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mach.Location = new System.Drawing.Point(301, 150);
            this.mach.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.mach.MaxLength = 5;
            this.mach.Name = "mach";
            this.mach.Size = new System.Drawing.Size(32, 21);
            this.mach.TabIndex = 3;
            this.mach.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label149
            // 
            this.label149.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label149.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label149.Location = new System.Drawing.Point(341, 153);
            this.label149.Name = "label149";
            this.label149.Size = new System.Drawing.Size(48, 19);
            this.label149.TabIndex = 11;
            this.label149.Text = "lần/phút";
            this.label149.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label150
            // 
            this.label150.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label150.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label150.Location = new System.Drawing.Point(477, 153);
            this.label150.Name = "label150";
            this.label150.Size = new System.Drawing.Size(24, 16);
            this.label150.TabIndex = 13;
            this.label150.Text = "°C";
            this.label150.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label151
            // 
            this.label151.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label151.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label151.Location = new System.Drawing.Point(604, 153);
            this.label151.Name = "label151";
            this.label151.Size = new System.Drawing.Size(38, 16);
            this.label151.TabIndex = 16;
            this.label151.Text = "mmHg";
            this.label151.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label152
            // 
            this.label152.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label152.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label152.Location = new System.Drawing.Point(734, 153);
            this.label152.Name = "label152";
            this.label152.Size = new System.Drawing.Size(48, 16);
            this.label152.TabIndex = 18;
            this.label152.Text = "lần/phút";
            this.label152.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label155
            // 
            this.label155.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label155.Location = new System.Drawing.Point(639, 153);
            this.label155.Name = "label155";
            this.label155.Size = new System.Drawing.Size(56, 16);
            this.label155.TabIndex = 6;
            this.label155.Text = "Nhịp thở :";
            this.label155.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label156
            // 
            this.label156.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label156.Location = new System.Drawing.Point(492, 153);
            this.label156.Name = "label156";
            this.label156.Size = new System.Drawing.Size(64, 16);
            this.label156.TabIndex = 5;
            this.label156.Text = "Huyết áp :";
            this.label156.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label157
            // 
            this.label157.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label157.Location = new System.Drawing.Point(389, 153);
            this.label157.Name = "label157";
            this.label157.Size = new System.Drawing.Size(56, 16);
            this.label157.TabIndex = 4;
            this.label157.Text = "Nhiệt độ :";
            this.label157.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label158
            // 
            this.label158.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label158.Location = new System.Drawing.Point(258, 153);
            this.label158.Name = "label158";
            this.label158.Size = new System.Drawing.Size(40, 16);
            this.label158.TabIndex = 3;
            this.label158.Text = "Mạch :";
            this.label158.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // theodoi_pass
            // 
            this.theodoi_pass.BackColor = System.Drawing.SystemColors.HighlightText;
            this.theodoi_pass.Enabled = false;
            this.theodoi_pass.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.theodoi_pass.Location = new System.Drawing.Point(705, 418);
            this.theodoi_pass.Name = "theodoi_pass";
            this.theodoi_pass.PasswordChar = '*';
            this.theodoi_pass.Size = new System.Drawing.Size(78, 21);
            this.theodoi_pass.TabIndex = 20;
            this.theodoi_pass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.conthu_KeyDown);
            // 
            // chkXml
            // 
            this.chkXml.Location = new System.Drawing.Point(8, 456);
            this.chkXml.Name = "chkXml";
            this.chkXml.Size = new System.Drawing.Size(96, 16);
            this.chkXml.TabIndex = 486;
            this.chkXml.Text = "Xuất ra XML";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(226, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 487;
            this.label1.Text = "Toàn trạng :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // toantrang
            // 
            this.toantrang.BackColor = System.Drawing.SystemColors.HighlightText;
            this.toantrang.Enabled = false;
            this.toantrang.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toantrang.Location = new System.Drawing.Point(301, 96);
            this.toantrang.Multiline = true;
            this.toantrang.Name = "toantrang";
            this.toantrang.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.toantrang.Size = new System.Drawing.Size(483, 52);
            this.toantrang.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(226, 174);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 489;
            this.label2.Text = "Tim :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tim
            // 
            this.tim.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tim.Enabled = false;
            this.tim.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tim.Location = new System.Drawing.Point(301, 173);
            this.tim.Name = "tim";
            this.tim.Size = new System.Drawing.Size(483, 21);
            this.tim.TabIndex = 7;
            this.tim.KeyDown += new System.Windows.Forms.KeyEventHandler(this.conthu_KeyDown);
            // 
            // phoi
            // 
            this.phoi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.phoi.Enabled = false;
            this.phoi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phoi.Location = new System.Drawing.Point(301, 196);
            this.phoi.Name = "phoi";
            this.phoi.Size = new System.Drawing.Size(483, 21);
            this.phoi.TabIndex = 8;
            this.phoi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.conthu_KeyDown);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(226, 199);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.TabIndex = 492;
            this.label3.Text = "Phổi :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tucung
            // 
            this.tucung.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tucung.Enabled = false;
            this.tucung.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tucung.Location = new System.Drawing.Point(301, 243);
            this.tucung.Name = "tucung";
            this.tucung.Size = new System.Drawing.Size(272, 21);
            this.tucung.TabIndex = 12;
            this.tucung.KeyDown += new System.Windows.Forms.KeyEventHandler(this.conthu_KeyDown);
            // 
            // label116
            // 
            this.label116.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label116.Location = new System.Drawing.Point(215, 245);
            this.label116.Name = "label116";
            this.label116.Size = new System.Drawing.Size(83, 16);
            this.label116.TabIndex = 494;
            this.label116.Text = "Độ gò tử cung :";
            this.label116.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label144
            // 
            this.label144.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label144.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label144.Location = new System.Drawing.Point(740, 245);
            this.label144.Name = "label144";
            this.label144.Size = new System.Drawing.Size(38, 16);
            this.label144.TabIndex = 497;
            this.label144.Text = "ml";
            this.label144.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // maumat
            // 
            this.maumat.BackColor = System.Drawing.SystemColors.HighlightText;
            this.maumat.Enabled = false;
            this.maumat.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maumat.Location = new System.Drawing.Point(695, 243);
            this.maumat.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.maumat.MaxLength = 5;
            this.maumat.Name = "maumat";
            this.maumat.Size = new System.Drawing.Size(40, 21);
            this.maumat.TabIndex = 13;
            this.maumat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label143
            // 
            this.label143.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label143.Location = new System.Drawing.Point(567, 245);
            this.label143.Name = "label143";
            this.label143.Size = new System.Drawing.Size(128, 16);
            this.label143.TabIndex = 496;
            this.label143.Text = "Lượng máu mất :";
            this.label143.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(210, 288);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 16);
            this.label4.TabIndex = 501;
            this.label4.Text = "Lượng nước tiểu :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nuoctieu
            // 
            this.nuoctieu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nuoctieu.Enabled = false;
            this.nuoctieu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nuoctieu.Location = new System.Drawing.Point(301, 288);
            this.nuoctieu.Name = "nuoctieu";
            this.nuoctieu.Size = new System.Drawing.Size(483, 21);
            this.nuoctieu.TabIndex = 15;
            this.nuoctieu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.conthu_KeyDown);
            // 
            // tresosinh
            // 
            this.tresosinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tresosinh.Enabled = false;
            this.tresosinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tresosinh.Location = new System.Drawing.Point(301, 266);
            this.tresosinh.Name = "tresosinh";
            this.tresosinh.Size = new System.Drawing.Size(483, 21);
            this.tresosinh.TabIndex = 14;
            this.tresosinh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.conthu_KeyDown);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(226, 266);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 16);
            this.label5.TabIndex = 498;
            this.label5.Text = "Trẻ sơ sinh :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ngayvv
            // 
            this.ngayvv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngayvv.Enabled = false;
            this.ngayvv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngayvv.Location = new System.Drawing.Point(74, 27);
            this.ngayvv.Name = "ngayvv";
            this.ngayvv.Size = new System.Drawing.Size(109, 21);
            this.ngayvv.TabIndex = 515;
            // 
            // sovaovien
            // 
            this.sovaovien.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sovaovien.Enabled = false;
            this.sovaovien.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sovaovien.Location = new System.Drawing.Point(255, 27);
            this.sovaovien.Name = "sovaovien";
            this.sovaovien.Size = new System.Drawing.Size(70, 21);
            this.sovaovien.TabIndex = 523;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(183, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 16);
            this.label6.TabIndex = 522;
            this.label6.Text = "Số vào viện :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chandoan
            // 
            this.chandoan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.chandoan.Enabled = false;
            this.chandoan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chandoan.Location = new System.Drawing.Point(74, 50);
            this.chandoan.Name = "chandoan";
            this.chandoan.Size = new System.Drawing.Size(709, 21);
            this.chandoan.TabIndex = 521;
            // 
            // sothe
            // 
            this.sothe.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sothe.Enabled = false;
            this.sothe.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sothe.Location = new System.Drawing.Point(371, 27);
            this.sothe.Name = "sothe";
            this.sothe.Size = new System.Drawing.Size(164, 21);
            this.sothe.TabIndex = 513;
            // 
            // giuong
            // 
            this.giuong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.giuong.Enabled = false;
            this.giuong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.giuong.Location = new System.Drawing.Point(711, 27);
            this.giuong.Name = "giuong";
            this.giuong.Size = new System.Drawing.Size(72, 21);
            this.giuong.TabIndex = 520;
            // 
            // phong
            // 
            this.phong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.phong.Enabled = false;
            this.phong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phong.Location = new System.Drawing.Point(583, 27);
            this.phong.Name = "phong";
            this.phong.Size = new System.Drawing.Size(80, 21);
            this.phong.TabIndex = 519;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(-4, 51);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(73, 16);
            this.label13.TabIndex = 518;
            this.label13.Text = "Chẩn đoán :";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(663, 28);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(48, 16);
            this.label12.TabIndex = 517;
            this.label12.Text = "Giường :";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(535, 28);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 16);
            this.label11.TabIndex = 516;
            this.label11.Text = "Phòng :";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(30, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 16);
            this.label7.TabIndex = 514;
            this.label7.Text = "Ngày :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(322, 28);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 16);
            this.label8.TabIndex = 512;
            this.label8.Text = "Số thẻ :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // diachi
            // 
            this.diachi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.diachi.Enabled = false;
            this.diachi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diachi.Location = new System.Drawing.Point(538, 4);
            this.diachi.Name = "diachi";
            this.diachi.Size = new System.Drawing.Size(245, 21);
            this.diachi.TabIndex = 511;
            // 
            // phai
            // 
            this.phai.BackColor = System.Drawing.SystemColors.HighlightText;
            this.phai.Enabled = false;
            this.phai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phai.Location = new System.Drawing.Point(458, 4);
            this.phai.Name = "phai";
            this.phai.Size = new System.Drawing.Size(32, 21);
            this.phai.TabIndex = 510;
            // 
            // namsinh
            // 
            this.namsinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.namsinh.Enabled = false;
            this.namsinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namsinh.Location = new System.Drawing.Point(371, 4);
            this.namsinh.Name = "namsinh";
            this.namsinh.Size = new System.Drawing.Size(32, 21);
            this.namsinh.TabIndex = 509;
            // 
            // hoten
            // 
            this.hoten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.hoten.Enabled = false;
            this.hoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoten.Location = new System.Drawing.Point(178, 4);
            this.hoten.Name = "hoten";
            this.hoten.Size = new System.Drawing.Size(160, 21);
            this.hoten.TabIndex = 508;
            // 
            // mabn
            // 
            this.mabn.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabn.Enabled = false;
            this.mabn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabn.Location = new System.Drawing.Point(74, 4);
            this.mabn.Name = "mabn";
            this.mabn.Size = new System.Drawing.Size(56, 21);
            this.mabn.TabIndex = 502;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(490, 6);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 16);
            this.label10.TabIndex = 507;
            this.label10.Text = "Địa chỉ :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(402, 6);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(56, 16);
            this.label14.TabIndex = 506;
            this.label14.Text = "Giới tính :";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(338, 6);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(32, 16);
            this.label15.TabIndex = 505;
            this.label15.Text = "NS :";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(130, 6);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(48, 16);
            this.label16.TabIndex = 504;
            this.label16.Text = "Họ tên :";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(21, 6);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(48, 16);
            this.label17.TabIndex = 503;
            this.label17.Text = "Mã BN :";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.dataGrid1.Location = new System.Drawing.Point(8, 56);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(192, 384);
            this.dataGrid1.TabIndex = 524;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            this.dataGrid1.Click += new System.EventHandler(this.dataGrid1_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Image = global::Medisoft.Properties.Resources.exit1;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(594, 450);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 27;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // butIn
            // 
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(524, 450);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 26;
            this.butIn.Text = "&In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butHuy
            // 
            this.butHuy.Image = ((System.Drawing.Image)(resources.GetObject("butHuy.Image")));
            this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHuy.Location = new System.Drawing.Point(454, 450);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(70, 25);
            this.butHuy.TabIndex = 25;
            this.butHuy.Text = "&Hủy";
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Enabled = false;
            this.butBoqua.Image = ((System.Drawing.Image)(resources.GetObject("butBoqua.Image")));
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(384, 450);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(70, 25);
            this.butBoqua.TabIndex = 22;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butLuu
            // 
            this.butLuu.Enabled = false;
            this.butLuu.Image = ((System.Drawing.Image)(resources.GetObject("butLuu.Image")));
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(314, 450);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 21;
            this.butLuu.Text = "&Lưu";
            this.butLuu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butSua
            // 
            this.butSua.Image = ((System.Drawing.Image)(resources.GetObject("butSua.Image")));
            this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.Location = new System.Drawing.Point(244, 450);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(70, 25);
            this.butSua.TabIndex = 24;
            this.butSua.Text = "&Sữa";
            this.butSua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butMoi
            // 
            this.butMoi.Image = ((System.Drawing.Image)(resources.GetObject("butMoi.Image")));
            this.butMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMoi.Location = new System.Drawing.Point(174, 450);
            this.butMoi.Name = "butMoi";
            this.butMoi.Size = new System.Drawing.Size(70, 25);
            this.butMoi.TabIndex = 23;
            this.butMoi.Text = "&Mới";
            this.butMoi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(192, 223);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(112, 16);
            this.label18.TabIndex = 532;
            this.label18.Text = "May tầng sinh môn :";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tangsinhmon
            // 
            this.tangsinhmon.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tangsinhmon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tangsinhmon.Enabled = false;
            this.tangsinhmon.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tangsinhmon.Items.AddRange(new object[] {
            "Có",
            "Không"});
            this.tangsinhmon.Location = new System.Drawing.Point(301, 219);
            this.tangsinhmon.Name = "tangsinhmon";
            this.tangsinhmon.Size = new System.Drawing.Size(67, 21);
            this.tangsinhmon.TabIndex = 9;
            this.tangsinhmon.SelectedIndexChanged += new System.EventHandler(this.tangsinhmon_SelectedIndexChanged);
            this.tangsinhmon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.conthu_KeyDown);
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(376, 223);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(64, 16);
            this.label19.TabIndex = 534;
            this.label19.Text = "Tính chất :";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tinhchat
            // 
            this.tinhchat.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tinhchat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tinhchat.Enabled = false;
            this.tinhchat.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tinhchat.Items.AddRange(new object[] {
            "Sưng",
            "Tụ máu",
            "Chảy máu",
            "Nhiễm",
            "Khác"});
            this.tinhchat.Location = new System.Drawing.Point(445, 219);
            this.tinhchat.Name = "tinhchat";
            this.tinhchat.Size = new System.Drawing.Size(75, 21);
            this.tinhchat.TabIndex = 10;
            this.tinhchat.SelectedIndexChanged += new System.EventHandler(this.tinhchat_SelectedIndexChanged);
            this.tinhchat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.conthu_KeyDown);
            // 
            // label20
            // 
            this.label20.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(500, 223);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(56, 16);
            this.label20.TabIndex = 536;
            this.label20.Text = "Khác :";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // khac
            // 
            this.khac.BackColor = System.Drawing.SystemColors.HighlightText;
            this.khac.Enabled = false;
            this.khac.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.khac.Location = new System.Drawing.Point(556, 219);
            this.khac.Name = "khac";
            this.khac.Size = new System.Drawing.Size(228, 21);
            this.khac.TabIndex = 11;
            this.khac.KeyDown += new System.Windows.Forms.KeyEventHandler(this.conthu_KeyDown);
            // 
            // frmBahausangan
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.tinhchat);
            this.Controls.Add(this.khac);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.tangsinhmon);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.butHuy);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butSua);
            this.Controls.Add(this.butMoi);
            this.Controls.Add(this.ngayvv);
            this.Controls.Add(this.sovaovien);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.chandoan);
            this.Controls.Add(this.sothe);
            this.Controls.Add(this.giuong);
            this.Controls.Add(this.phong);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.diachi);
            this.Controls.Add(this.phai);
            this.Controls.Add(this.namsinh);
            this.Controls.Add(this.hoten);
            this.Controls.Add(this.mabn);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nuoctieu);
            this.Controls.Add(this.tresosinh);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tucung);
            this.Controls.Add(this.label144);
            this.Controls.Add(this.maumat);
            this.Controls.Add(this.label143);
            this.Controls.Add(this.label116);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.phoi);
            this.Controls.Add(this.tim);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.toantrang);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkXml);
            this.Controls.Add(this.theodoi_pass);
            this.Controls.Add(this.listNv1);
            this.Controls.Add(this.tentheodoi);
            this.Controls.Add(this.theodoi);
            this.Controls.Add(this.xutri);
            this.Controls.Add(this.tienluong);
            this.Controls.Add(this.ngaychuyenda);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.giochuyenda);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label168);
            this.Controls.Add(this.label158);
            this.Controls.Add(this.mach);
            this.Controls.Add(this.label149);
            this.Controls.Add(this.label157);
            this.Controls.Add(this.nhietdo);
            this.Controls.Add(this.label150);
            this.Controls.Add(this.label156);
            this.Controls.Add(this.huyetap);
            this.Controls.Add(this.label151);
            this.Controls.Add(this.label155);
            this.Controls.Add(this.nhiptho);
            this.Controls.Add(this.label152);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.label133);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBahausangan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Diễn biến hậu sản gần";
            this.Load += new System.EventHandler(this.frmBahausangan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmBahausangan_Load(object sender, System.EventArgs e)
		{
			user=m.user;
			dtnv=m.get_data("select * from dmbs where nhom<>"+LibMedi.AccessData.nghiviec+" order by hoten").Tables[0];
			listNv1.DisplayMember="MA";
			listNv1.ValueMember="HOTEN";
			listNv1.DataSource=m.get_data("select * from dmbs where nhom<>"+LibMedi.AccessData.nghiviec+" order by hoten").Tables[0];

			string _ngay=m.ngayhienhanh_server;
			ngaychuyenda.Text=_ngay.Substring(0,10);
			giochuyenda.Text=_ngay.Substring(11);

			tangsinhmon.SelectedIndex=1;
			tinhchat.SelectedIndex=0;
			//load_data();
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

		private void load_grid()
		{
			sql="select a.id,a.idthuchien,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngay,";
			sql+="a.theodoi,c.hoten as tenbs,c.password_ from xxx.ba_hausangan a,xxx.ba_thuchien b,"+user+".dmbs c where a.idthuchien=b.id and a.theodoi=c.ma and b.idkhoa="+l_idkhoa;
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
				string _ngay=dataGrid1[i_row,2].ToString();
				ngaychuyenda.Text=_ngay.Substring(0,10);
				giochuyenda.Text=_ngay.Substring(11);
				load_data();
			}
			catch{}
		}

		private bool kiemtra()
		{
			if (theodoi.Text=="" || tentheodoi.Text=="")
			{
				MessageBox.Show(
lan.Change_language_MessageText("Tên người theo dõi không hợp lệ !"),LibMedi.AccessData.Msg);
				if (theodoi.Text=="") theodoi.Focus();
				else tentheodoi.Focus();
				return false;
			}
			if (theodoi.Text!="" && tentheodoi.Text!="")
			{
				DataRow r=m.getrowbyid(dtnv,"ma='"+theodoi.Text+"'");
				if (r==null)
				{
					MessageBox.Show(
lan.Change_language_MessageText("Tên người theo dõi không hợp lệ !"),LibMedi.AccessData.Msg);
					theodoi.Focus();
					return false;
				}
				if (!bAdmin)
				{
					if (theodoi_pass.Text!=r["password_"].ToString())
					{
						MessageBox.Show(
lan.Change_language_MessageText("Mật khẩu tên người theo dõi chưa hợp lệ !"),LibMedi.AccessData.Msg);
						theodoi_pass.Focus();
						return false;
					}
				}
			}
			return true;
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			if (!kiemtra()) return;
			mmyy=m.mmyy(ngaychuyenda.Text);
			if (!m.bMmyy(mmyy)) m.tao_schema(mmyy,i_userid);
			xxx=user+mmyy;
			l_idthuchien=m.get_idthuchien(ngaychuyenda.Text,l_idkhoa);
			if (l_idthuchien==0) 
			{
				l_idthuchien=m.get_capid(-300);
				m.upd_ba_thuchien(ngaychuyenda.Text,l_idthuchien,mabn.Text,l_maql,l_idkhoa,s_makp,phong.Text,giuong.Text,chandoan.Text);
			}
			if (l_id==0) l_id=m.get_capid(-309);
			s_theodoi=theodoi.Text;
			m.upd_ba_hausangan(l_id,l_idthuchien,ngaychuyenda.Text+" "+giochuyenda.Text,toantrang.Text,(mach.Text!="")?decimal.Parse(mach.Text):0,huyetap.Text,(nhietdo.Text!="")?decimal.Parse(nhietdo.Text):0,(nhiptho.Text!="")?decimal.Parse(nhiptho.Text):0,tim.Text,phoi.Text,tucung.Text,(maumat.Text!="")?decimal.Parse(maumat.Text):0,tresosinh.Text,nuoctieu.Text,tienluong.Text,xutri.Text,theodoi.Text,tangsinhmon.SelectedIndex,tinhchat.SelectedIndex,khac.Text,i_userid);
			upd_items();
			ena_object(false);
			tinhchat.Enabled=false;
			khac.Enabled=false;
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
				r2["ngay"]=ngaychuyenda.Text+" "+giochuyenda.Text;
				r2["theodoi"]=theodoi.Text;
				r2["tenbs"]=tentheodoi.Text;
				r2["password_"]=theodoi_pass.Text;
				r2["chon"]=true;
				ds.Tables[0].Rows.Add(r2);
			}
			else
			{
				DataRow [] dr=ds.Tables[0].Select("id="+l_id);
				dr[0]["idthuchien"]=l_idthuchien;
				dr[0]["ngay"]=ngaychuyenda.Text+" "+giochuyenda.Text;
				dr[0]["theodoi"]=theodoi.Text;
				dr[0]["tenbs"]=tentheodoi.Text;
				dr[0]["password_"]=theodoi_pass.Text;
			}
		}

		private void ena_object(bool ena)
		{
			ngaychuyenda.Enabled=ena;
			giochuyenda.Enabled=ena;
			toantrang.Enabled=ena;
			mach.Enabled=ena;
			huyetap.Enabled=ena;
			nhietdo.Enabled=ena;
			nhiptho.Enabled=ena;
			tim.Enabled=ena;
			phoi.Enabled=ena;
			tangsinhmon.Enabled=ena;
			tucung.Enabled=ena;
			maumat.Enabled=ena;
			tresosinh.Enabled=ena;
			nuoctieu.Enabled=ena;
			tienluong.Enabled=ena;
			xutri.Enabled=ena;
			theodoi.Enabled=ena;
			tentheodoi.Enabled=ena;
			theodoi_pass.Enabled=ena;
			butMoi.Enabled=!ena;
			butSua.Enabled=!ena;
			butLuu.Enabled=ena;
			butBoqua.Enabled=ena;
			butHuy.Enabled=!ena;
			butIn.Enabled=!ena;
			butKetthuc.Enabled=!ena;
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			ena_object(false);
			tinhchat.Enabled=false;
			khac.Enabled=false;
			if (l_id!=0) load_data();
			butMoi.Focus();
		}

		private void load_data()
		{
			xxx=user+m.mmyy(ngaychuyenda.Text);
			sql="select a.*,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngaychuyenda from "+xxx+".ba_hausangan a";
			sql+=" where a.id="+l_id;
			foreach(DataRow r in m.get_data(sql).Tables[0].Rows)
			{
				ngaychuyenda.Text=r["ngaychuyenda"].ToString().Substring(0,10);
				giochuyenda.Text=r["ngaychuyenda"].ToString().Substring(11);
				toantrang.Text=r["toantrang"].ToString();
				mach.Text=(r["mach"].ToString()=="0")?"":r["mach"].ToString();
				nhietdo.Text=(r["nhietdo"].ToString()=="0")?"":r["nhietdo"].ToString();
				huyetap.Text=r["huyetap"].ToString();
				nhiptho.Text=(r["nhiptho"].ToString()=="0")?"":r["nhiptho"].ToString();
				tim.Text=r["tim"].ToString();
				phoi.Text=r["phoi"].ToString();
				tucung.Text=r["tucung"].ToString();
				maumat.Text=(r["maumat"].ToString()=="0")?"":r["maumat"].ToString();
				tresosinh.Text=r["tresosinh"].ToString();
				nuoctieu.Text=r["nuoctieu"].ToString();
				tienluong.Text=r["tienluong"].ToString();
				xutri.Text=r["xutri"].ToString();
				theodoi.Text=r["theodoi"].ToString();
				DataRow r1=m.getrowbyid(dtnv,"ma='"+r["theodoi"].ToString()+"'");
				if (r1!=null)
				{
					tentheodoi.Text=r1["hoten"].ToString();
					theodoi_pass.Text=r1["password_"].ToString();
				}
				s_theodoi=theodoi.Text;
				tangsinhmon.SelectedIndex=int.Parse(r["tangsinhmon"].ToString());
				tinhchat.SelectedIndex=int.Parse(r["tinhchat"].ToString());
				khac.Text=r["khac"].ToString();
				break;
			}
		}

		private void conthu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void theodoi_Validated(object sender, System.EventArgs e)
		{
			if (theodoi.Text=="") return;
			DataRow r=m.getrowbyid(dtnv,"ma='"+theodoi.Text+"'");
			if (r!=null) tentheodoi.Text=r["hoten"].ToString();
			else tentheodoi.Text="";				
		}

		private void tentheodoi_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tentheodoi)
			{
				Filt_dmbs(tentheodoi.Text);
				listNv1.BrowseToDanhmuc(tentheodoi,theodoi,theodoi_pass,35);
			}	
		}

		private void tentheodoi_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listNv1.Focus(); 
			else if (e.KeyCode==Keys.Enter)
			{
				if (listNv1.Visible) listNv1.Focus();
				else SendKeys.Send("{Tab}");
			}		
		}

		private void Filt_dmbs(string ten)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listNv1.DataSource];
				DataView dv=(DataView)cm.List;
				dv.RowFilter="hoten like '%"+ten.Trim()+"%'";
			}
			catch{}
		}

		private void giochuyenda_Validated(object sender, System.EventArgs e)
		{
			try
			{
				if (giochuyenda.Text!="")
				{
					string sgio=(giochuyenda.Text.Trim()=="")?"00:00":giochuyenda.Text.Trim();
					giochuyenda.Text=sgio.Substring(0,2).PadLeft(2,'0')+":"+sgio.Substring(3).Trim().PadRight(2,'0');
					if (!m.bGio(giochuyenda.Text))
					{
						MessageBox.Show(
lan.Change_language_MessageText("Giờ không hợp lệ !"),LibMedi.AccessData.Msg);
						giochuyenda.Focus();
						return;
					}
				}
			}
			catch{}
		}

		private void ngaychuyenda_Validated(object sender, System.EventArgs e)
		{
			try
			{
				if (ngaychuyenda.Text!="")
				{
					ngaychuyenda.Text=ngaychuyenda.Text.Trim();
					if (ngaychuyenda.Text.Length==6) ngaychuyenda.Text=ngaychuyenda.Text+DateTime.Now.Year.ToString();
					if (!m.bNgay(ngaychuyenda.Text))
					{
						MessageBox.Show(
lan.Change_language_MessageText("Ngày không hợp lệ !"),LibMedi.AccessData.Msg);
						ngaychuyenda.Focus();
						return;
					}
				}
			}
			catch{}		
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			string s_id="";
			foreach(DataRow r1 in ds.Tables[0].Select("chon=true")) s_id+=r1["id"].ToString()+",";
			sql="select a.*,to_char(a.ngay,'dd/mm/yyyy hh24:mi') as ngaychuyenda,";
			sql+="b.hoten as tentheodoi,b.image,'' as sovaovien,'' as mabn,'' as hoten,'' as tuoi,'' as gioitinh,'' as tenkp,";
			sql+="'' as phong,'' as giuong,'' as chandoan ";
			sql+=" from xxx.ba_hausangan a,"+user+".dmbs b,xxx.ba_thuchien c";
			sql+=" where a.idthuchien=c.id and a.theodoi=b.ma and c.idkhoa="+l_idkhoa;
			if (s_id!="") sql+=" and a.id in ("+s_id.Substring(0,s_id.Length-1)+")";
			sql+=" order by a.ngay ";
			DataSet dsxml=m.get_data_mmyy(sql,ngayvv.Text.Substring(0,10),s_ngayrv.Substring(0,10),false);
			foreach(DataRow r in dsxml.Tables[0].Rows)
			{
				r["sovaovien"]=sovaovien.Text;
				r["mabn"]=mabn.Text;
				r["hoten"]=hoten.Text;
				r["tuoi"]=m.get_tuoivao(l_maql);
				r["gioitinh"]=phai.Text;
				r["tenkp"]=s_tenkp;
				r["phong"]=phong.Text;
				r["giuong"]=giuong.Text;
				r["chandoan"]=chandoan.Text;
			}
			if (chkXml.Checked)
			{
				if (!System.IO.Directory.Exists("..\\xml")) System.IO.Directory.CreateDirectory("..\\xml");
				dsxml.WriteXml("..\\xml\\hausangan.xml",XmlWriteMode.WriteSchema);
			}
			if (dsxml.Tables[0].Rows.Count>0)
			{
				dllReportM.frmReport f=new dllReportM.frmReport(m,dsxml,"","r39bv_hausangan.rpt");
				f.ShowDialog();
			}
			else MessageBox.Show(
lan.Change_language_MessageText("Không có số liệu !"),LibMedi.AccessData.Msg);
		}

		private void tinhchat_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tinhchat) khac.Enabled=tinhchat.SelectedIndex==4;
		}

		private void emp_text()
		{
			l_id=0;
			string _ngay=m.ngayhienhanh_server;
			ngaychuyenda.Text=_ngay.Substring(0,10);
			giochuyenda.Text=_ngay.Substring(11);
			toantrang.Text="";tim.Text="";phoi.Text="";
			tangsinhmon.SelectedIndex=1;tinhchat.SelectedIndex=0;khac.Text="";
			tucung.Text="";maumat.Text="";tresosinh.Text="";nuoctieu.Text="";
			tienluong.Text="";xutri.Text="";
			mach.Text="";huyetap.Text="";nhietdo.Text="";nhiptho.Text="";
			theodoi.Text="";tentheodoi.Text="";theodoi_pass.Text="";
			if (s_mabs!="")
			{
				theodoi.Text=s_mabs;
				DataRow r1=m.getrowbyid(dtnv,"ma='"+theodoi.Text+"'");
				if (r1!=null) 
				{
					tentheodoi.Text=r1["hoten"].ToString();
					theodoi_pass.Text=r1["password_"].ToString();
				}
				else
				{
					tentheodoi.Text="";theodoi_pass.Text="";
				}
				if (theodoi.Text!="" && tentheodoi.Text!="" && !bAdmin)
				{
					theodoi.Enabled=false;tentheodoi.Enabled=false;
				}
			}
		}

		private void butMoi_Click(object sender, System.EventArgs e)
		{
			ena_object(true);
			emp_text();
			ngaychuyenda.Focus();
		}

		private void butSua_Click(object sender, System.EventArgs e)
		{
			if (ds.Tables[0].Rows.Count==0) return;
			ena_object(true);
			tinhchat.Enabled=tangsinhmon.SelectedIndex==0;
			khac.Enabled=tinhchat.SelectedIndex==4;
			ngaychuyenda.Focus();
		}

		private void butHuy_Click(object sender, System.EventArgs e)
		{
			if (ds.Tables[0].Rows.Count==0) return;
			if (MessageBox.Show(
lan.Change_language_MessageText("Đồng ý hủy thông tin này ?"),LibMedi.AccessData.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
			{
				xxx=user+m.mmyy(ngaychuyenda.Text);
				m.execute_data("delete from "+xxx+".ba_hausangan where id="+l_id);
				m.delrec(ds.Tables[0],"id="+l_id);
				ref_text();
			}
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void tangsinhmon_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tangsinhmon) tinhchat.Enabled=tangsinhmon.SelectedIndex==0;
		}
	}
}
