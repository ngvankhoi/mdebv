using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibDuoc;
using doiso;

namespace Duoc
{
	/// <summary>
	/// Summary description for frmNhap.
	/// </summary>
	public class frmNhap_soluong : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label10;
		private MaskedBox.MaskedBox ngaysp;
		private MaskedBox.MaskedBox ngayhd;
		private System.Windows.Forms.TextBox madv;
		private System.Windows.Forms.TextBox tendv;
		private System.Windows.Forms.ComboBox makho;
		private LibList.List listNX;
		private LibList.List listDMBD;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label lTen;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.TextBox tenbd;
		private System.Windows.Forms.TextBox mabd;
		private MaskedBox.MaskedBox dang;
		private MaskedTextBox.MaskedTextBox soluong;
		private System.Windows.Forms.Button butMoi;
		private System.Windows.Forms.Button butSua;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butThem;
		private System.Windows.Forms.Button butXoa;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.Button butHuy;
		private System.Windows.Forms.Button butKetthuc;
		private System.Windows.Forms.ComboBox cmbSophieu;
		private string xxx,user,s_mmyy,s_ngay,sql,s_loai,s_ngaysp,s_ngayhd,s_makho,format_soluong;
		private int i_nhom,i_userid,i_madv,i_mabd,i_old,i_songay,makho_old,i_done,i_row,itable,i_khudt=0;
		private decimal l_id;
		private decimal d_soluong,d_sl1,d_sl2;
		private bool bKhoaso,bNew,bAdmin,bQuidoi,bNguoigiao,bSophieu,bLockytu;
		private AccessData d;
		private Doisototext doiso=new Doisototext();
		private DataTable dtdmbd=new DataTable();
		private DataTable dtdmnx=new DataTable();
		private DataTable dtll=new DataTable();
		private DataTable dtct=new DataTable();
		private DataTable dtold=new DataTable();
		private DataSet dsxoa=new DataSet();
		private System.Windows.Forms.Label ldvt;
		private DataRow r;
		private System.Windows.Forms.TextBox stt;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label24;
		private MaskedBox.MaskedBox handung;
		private System.Windows.Forms.TextBox tenhc;
		private System.Windows.Forms.Label lTenhc;
		private MaskedTextBox.MaskedTextBox sophieu;
		private MaskedTextBox.MaskedTextBox sohd;
		private MaskedTextBox.MaskedTextBox nguoigiao;
		private MaskedBox.MaskedBox tenhang;
		private MaskedBox.MaskedBox tennuoc;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.Label label26;
		private MaskedTextBox.MaskedTextBox sl1;
		private MaskedTextBox.MaskedTextBox sl2;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.Label label28;
		private System.Windows.Forms.TextBox find;
		private MaskedTextBox.MaskedTextBox losx;
		private System.Windows.Forms.Label lsokhoan;
		private System.Windows.Forms.ComboBox cmbTimkiem;
		private System.Windows.Forms.DataGrid dataGrid1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmNhap_soluong(AccessData acc,string loai,string mmyy,string ngay,int nhom,int userid,string kho,string title,bool admin, int _khudt)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			d=acc;
			i_nhom=nhom;
			s_makho=kho;
			i_userid=userid;
			s_mmyy=mmyy;
			s_ngay=ngay;
			s_loai=loai;
			bAdmin=admin;
			this.Text=title;
            i_khudt = _khudt;
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNhap_soluong));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.ngaysp = new MaskedBox.MaskedBox();
            this.ngayhd = new MaskedBox.MaskedBox();
            this.madv = new System.Windows.Forms.TextBox();
            this.tendv = new System.Windows.Forms.TextBox();
            this.makho = new System.Windows.Forms.ComboBox();
            this.listNX = new LibList.List();
            this.listDMBD = new LibList.List();
            this.label13 = new System.Windows.Forms.Label();
            this.lTen = new System.Windows.Forms.Label();
            this.ldvt = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.tenbd = new System.Windows.Forms.TextBox();
            this.mabd = new System.Windows.Forms.TextBox();
            this.dang = new MaskedBox.MaskedBox();
            this.soluong = new MaskedTextBox.MaskedTextBox();
            this.butMoi = new System.Windows.Forms.Button();
            this.butSua = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.butThem = new System.Windows.Forms.Button();
            this.butXoa = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butHuy = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.cmbSophieu = new System.Windows.Forms.ComboBox();
            this.stt = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.handung = new MaskedBox.MaskedBox();
            this.tenhc = new System.Windows.Forms.TextBox();
            this.lTenhc = new System.Windows.Forms.Label();
            this.sophieu = new MaskedTextBox.MaskedTextBox();
            this.sohd = new MaskedTextBox.MaskedTextBox();
            this.nguoigiao = new MaskedTextBox.MaskedTextBox();
            this.tenhang = new MaskedBox.MaskedBox();
            this.tennuoc = new MaskedBox.MaskedBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.sl1 = new MaskedTextBox.MaskedTextBox();
            this.sl2 = new MaskedTextBox.MaskedTextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.find = new System.Windows.Forms.TextBox();
            this.losx = new MaskedTextBox.MaskedTextBox();
            this.lsokhoan = new System.Windows.Forms.Label();
            this.cmbTimkiem = new System.Windows.Forms.ComboBox();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(23, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 23);
            this.label1.TabIndex = 37;
            this.label1.Text = "Số phiếu :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(140, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 23);
            this.label2.TabIndex = 38;
            this.label2.Text = "Ngày :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(244, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 23);
            this.label3.TabIndex = 39;
            this.label3.Text = "Hóa đơn :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(429, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 23);
            this.label4.TabIndex = 40;
            this.label4.Text = "Ngày :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(-16, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 23);
            this.label5.TabIndex = 43;
            this.label5.Text = "Nhà cung cấp :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(539, 6);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 23);
            this.label8.TabIndex = 44;
            this.label8.Text = "Người giao :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(425, 28);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 23);
            this.label10.TabIndex = 46;
            this.label10.Text = "Kho :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ngaysp
            // 
            this.ngaysp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngaysp.Enabled = false;
            this.ngaysp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngaysp.Location = new System.Drawing.Point(184, 6);
            this.ngaysp.Mask = "##/##/####";
            this.ngaysp.MaxLength = 10;
            this.ngaysp.Name = "ngaysp";
            this.ngaysp.Size = new System.Drawing.Size(64, 21);
            this.ngaysp.TabIndex = 2;
            this.ngaysp.Text = "  /  /    ";
            this.ngaysp.Validated += new System.EventHandler(this.ngaysp_Validated);
            // 
            // ngayhd
            // 
            this.ngayhd.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngayhd.Enabled = false;
            this.ngayhd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngayhd.Location = new System.Drawing.Point(473, 6);
            this.ngayhd.Mask = "##/##/####";
            this.ngayhd.MaxLength = 10;
            this.ngayhd.Name = "ngayhd";
            this.ngayhd.Size = new System.Drawing.Size(64, 21);
            this.ngayhd.TabIndex = 4;
            this.ngayhd.Text = "  /  /    ";
            this.ngayhd.Validated += new System.EventHandler(this.ngayhd_Validated);
            // 
            // madv
            // 
            this.madv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.madv.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.madv.Enabled = false;
            this.madv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madv.Location = new System.Drawing.Point(72, 29);
            this.madv.Name = "madv";
            this.madv.Size = new System.Drawing.Size(64, 21);
            this.madv.TabIndex = 6;
            this.madv.Validated += new System.EventHandler(this.madv_Validated);
            this.madv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.madv_KeyDown);
            // 
            // tendv
            // 
            this.tendv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tendv.Enabled = false;
            this.tendv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tendv.Location = new System.Drawing.Point(138, 29);
            this.tendv.Name = "tendv";
            this.tendv.Size = new System.Drawing.Size(302, 21);
            this.tendv.TabIndex = 7;
            this.tendv.Validated += new System.EventHandler(this.tendv_Validated);
            this.tendv.TextChanged += new System.EventHandler(this.tendv_TextChanged);
            this.tendv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tendv_KeyDown);
            // 
            // makho
            // 
            this.makho.BackColor = System.Drawing.SystemColors.HighlightText;
            this.makho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.makho.Enabled = false;
            this.makho.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makho.Location = new System.Drawing.Point(473, 29);
            this.makho.Name = "makho";
            this.makho.Size = new System.Drawing.Size(128, 21);
            this.makho.TabIndex = 8;
            this.makho.KeyDown += new System.Windows.Forms.KeyEventHandler(this.makho_KeyDown);
            // 
            // listNX
            // 
            this.listNX.BackColor = System.Drawing.SystemColors.Info;
            this.listNX.ColumnCount = 0;
            this.listNX.Location = new System.Drawing.Point(504, 549);
            this.listNX.MatchBufferTimeOut = 1000;
            this.listNX.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listNX.Name = "listNX";
            this.listNX.Size = new System.Drawing.Size(75, 17);
            this.listNX.TabIndex = 25;
            this.listNX.TextIndex = -1;
            this.listNX.TextMember = null;
            this.listNX.ValueIndex = -1;
            this.listNX.Visible = false;
            // 
            // listDMBD
            // 
            this.listDMBD.BackColor = System.Drawing.SystemColors.Info;
            this.listDMBD.ColumnCount = 0;
            this.listDMBD.Location = new System.Drawing.Point(584, 549);
            this.listDMBD.MatchBufferTimeOut = 1000;
            this.listDMBD.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listDMBD.Name = "listDMBD";
            this.listDMBD.Size = new System.Drawing.Size(75, 17);
            this.listDMBD.TabIndex = 26;
            this.listDMBD.TextIndex = -1;
            this.listDMBD.TextMember = null;
            this.listDMBD.ValueIndex = -1;
            this.listDMBD.Visible = false;
            this.listDMBD.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listDMBD_KeyDown);
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label13.Location = new System.Drawing.Point(18, 474);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(32, 23);
            this.label13.TabIndex = 28;
            this.label13.Text = "Mã :";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lTen
            // 
            this.lTen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lTen.Location = new System.Drawing.Point(93, 474);
            this.lTen.Name = "lTen";
            this.lTen.Size = new System.Drawing.Size(41, 23);
            this.lTen.TabIndex = 29;
            this.lTen.Text = "Tên :";
            this.lTen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ldvt
            // 
            this.ldvt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ldvt.Location = new System.Drawing.Point(688, 473);
            this.ldvt.Name = "ldvt";
            this.ldvt.Size = new System.Drawing.Size(41, 23);
            this.ldvt.TabIndex = 30;
            this.ldvt.Text = "ĐVT :";
            this.ldvt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label16.Location = new System.Drawing.Point(-4, 495);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(56, 23);
            this.label16.TabIndex = 31;
            this.label16.Text = "Số lượng :";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tenbd
            // 
            this.tenbd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tenbd.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbd.Enabled = false;
            this.tenbd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbd.Location = new System.Drawing.Point(133, 474);
            this.tenbd.Name = "tenbd";
            this.tenbd.Size = new System.Drawing.Size(286, 21);
            this.tenbd.TabIndex = 10;
            this.tenbd.Validated += new System.EventHandler(this.tenbd_Validated);
            this.tenbd.TextChanged += new System.EventHandler(this.tenbd_TextChanged);
            this.tenbd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbd_KeyDown);
            // 
            // mabd
            // 
            this.mabd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.mabd.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mabd.Enabled = false;
            this.mabd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabd.Location = new System.Drawing.Point(48, 474);
            this.mabd.Name = "mabd";
            this.mabd.Size = new System.Drawing.Size(57, 21);
            this.mabd.TabIndex = 9;
            this.mabd.Validated += new System.EventHandler(this.mabd_Validated);
            this.mabd.TextChanged += new System.EventHandler(this.mabd_TextChanged);
            this.mabd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbd_KeyDown);
            // 
            // dang
            // 
            this.dang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dang.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dang.Enabled = false;
            this.dang.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dang.Location = new System.Drawing.Point(727, 474);
            this.dang.Mask = "";
            this.dang.MaxLength = 10;
            this.dang.Name = "dang";
            this.dang.Size = new System.Drawing.Size(57, 21);
            this.dang.TabIndex = 12;
            // 
            // soluong
            // 
            this.soluong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.soluong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.soluong.Enabled = false;
            this.soluong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.soluong.Location = new System.Drawing.Point(176, 497);
            this.soluong.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
            this.soluong.Name = "soluong";
            this.soluong.Size = new System.Drawing.Size(80, 21);
            this.soluong.TabIndex = 15;
            this.soluong.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.soluong.Validated += new System.EventHandler(this.soluong_Validated);
            // 
            // butMoi
            // 
            this.butMoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butMoi.Image = global::Duoc.Properties.Resources.add;
            this.butMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMoi.Location = new System.Drawing.Point(124, 527);
            this.butMoi.Name = "butMoi";
            this.butMoi.Size = new System.Drawing.Size(70, 25);
            this.butMoi.TabIndex = 24;
            this.butMoi.Text = "    &Mới";
            this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
            // 
            // butSua
            // 
            this.butSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butSua.Image = global::Duoc.Properties.Resources.quick_edit;
            this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.Location = new System.Drawing.Point(194, 527);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(70, 25);
            this.butSua.TabIndex = 25;
            this.butSua.Text = "     &Sửa";
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butLuu
            // 
            this.butLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butLuu.Enabled = false;
            this.butLuu.Image = global::Duoc.Properties.Resources.save;
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(264, 527);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 22;
            this.butLuu.Text = "    &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butThem
            // 
            this.butThem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butThem.Enabled = false;
            this.butThem.Image = global::Duoc.Properties.Resources.plus;
            this.butThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butThem.Location = new System.Drawing.Point(334, 527);
            this.butThem.Name = "butThem";
            this.butThem.Size = new System.Drawing.Size(70, 25);
            this.butThem.TabIndex = 20;
            this.butThem.Text = "&Thêm";
            this.butThem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butThem.Click += new System.EventHandler(this.butThem_Click);
            // 
            // butXoa
            // 
            this.butXoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butXoa.Enabled = false;
            this.butXoa.Image = global::Duoc.Properties.Resources.Cancel;
            this.butXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butXoa.Location = new System.Drawing.Point(404, 527);
            this.butXoa.Name = "butXoa";
            this.butXoa.Size = new System.Drawing.Size(70, 25);
            this.butXoa.TabIndex = 21;
            this.butXoa.Text = "    &Xóa";
            this.butXoa.Click += new System.EventHandler(this.butXoa_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butBoqua.Enabled = false;
            this.butBoqua.Image = global::Duoc.Properties.Resources.undo_ok;
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(474, 527);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(70, 25);
            this.butBoqua.TabIndex = 23;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butHuy
            // 
            this.butHuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butHuy.Image = global::Duoc.Properties.Resources.delete_enabled;
            this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHuy.Location = new System.Drawing.Point(544, 527);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(70, 25);
            this.butHuy.TabIndex = 26;
            this.butHuy.Text = "    &Hủy";
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butKetthuc.Image = global::Duoc.Properties.Resources.close_r;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(614, 527);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 27;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // cmbSophieu
            // 
            this.cmbSophieu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSophieu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSophieu.Location = new System.Drawing.Point(72, 6);
            this.cmbSophieu.Name = "cmbSophieu";
            this.cmbSophieu.Size = new System.Drawing.Size(83, 21);
            this.cmbSophieu.TabIndex = 0;
            this.cmbSophieu.SelectedIndexChanged += new System.EventHandler(this.cmbSophieu_SelectedIndexChanged);
            this.cmbSophieu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbSophieu_KeyDown);
            // 
            // stt
            // 
            this.stt.Enabled = false;
            this.stt.Location = new System.Drawing.Point(64, 352);
            this.stt.Name = "stt";
            this.stt.Size = new System.Drawing.Size(40, 20);
            this.stt.TabIndex = 60;
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label15.Location = new System.Drawing.Point(256, 497);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(61, 23);
            this.label15.TabIndex = 61;
            this.label15.Text = "Hạn dùng :";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label24
            // 
            this.label24.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label24.Location = new System.Drawing.Point(336, 497);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(48, 23);
            this.label24.TabIndex = 62;
            this.label24.Text = "Lô :";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // handung
            // 
            this.handung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.handung.BackColor = System.Drawing.SystemColors.HighlightText;
            this.handung.Enabled = false;
            this.handung.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.handung.Location = new System.Drawing.Point(320, 497);
            this.handung.Mask = "####";
            this.handung.Name = "handung";
            this.handung.Size = new System.Drawing.Size(40, 21);
            this.handung.TabIndex = 16;
            this.handung.Text = "    ";
            // 
            // tenhc
            // 
            this.tenhc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tenhc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenhc.Enabled = false;
            this.tenhc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenhc.Location = new System.Drawing.Point(477, 474);
            this.tenhc.Name = "tenhc";
            this.tenhc.Size = new System.Drawing.Size(219, 21);
            this.tenhc.TabIndex = 11;
            // 
            // lTenhc
            // 
            this.lTenhc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lTenhc.Location = new System.Drawing.Point(407, 473);
            this.lTenhc.Name = "lTenhc";
            this.lTenhc.Size = new System.Drawing.Size(71, 23);
            this.lTenhc.TabIndex = 64;
            this.lTenhc.Text = "Hoạt chất :";
            this.lTenhc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sophieu
            // 
            this.sophieu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sophieu.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.sophieu.Enabled = false;
            this.sophieu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sophieu.Location = new System.Drawing.Point(72, 6);
            this.sophieu.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.sophieu.Name = "sophieu";
            this.sophieu.Size = new System.Drawing.Size(83, 21);
            this.sophieu.TabIndex = 1;
            this.sophieu.Validated += new System.EventHandler(this.sophieu_Validated);
            // 
            // sohd
            // 
            this.sohd.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sohd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.sohd.Enabled = false;
            this.sohd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sohd.Location = new System.Drawing.Point(295, 6);
            this.sohd.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.sohd.MaxLength = 50;
            this.sohd.Name = "sohd";
            this.sohd.Size = new System.Drawing.Size(145, 21);
            this.sohd.TabIndex = 3;
            this.sohd.Validated += new System.EventHandler(this.sohd_Validated);
            // 
            // nguoigiao
            // 
            this.nguoigiao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.nguoigiao.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nguoigiao.Enabled = false;
            this.nguoigiao.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nguoigiao.Location = new System.Drawing.Point(603, 6);
            this.nguoigiao.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.nguoigiao.Name = "nguoigiao";
            this.nguoigiao.Size = new System.Drawing.Size(181, 21);
            this.nguoigiao.TabIndex = 5;
            this.nguoigiao.Validated += new System.EventHandler(this.nguoigiao_Validated);
            // 
            // tenhang
            // 
            this.tenhang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tenhang.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenhang.Enabled = false;
            this.tenhang.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenhang.Location = new System.Drawing.Point(512, 497);
            this.tenhang.Mask = "";
            this.tenhang.Name = "tenhang";
            this.tenhang.Size = new System.Drawing.Size(112, 21);
            this.tenhang.TabIndex = 18;
            // 
            // tennuoc
            // 
            this.tennuoc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tennuoc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tennuoc.Enabled = false;
            this.tennuoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tennuoc.Location = new System.Drawing.Point(664, 497);
            this.tennuoc.Mask = "";
            this.tennuoc.Name = "tennuoc";
            this.tennuoc.Size = new System.Drawing.Size(120, 21);
            this.tennuoc.TabIndex = 19;
            // 
            // label23
            // 
            this.label23.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label23.Location = new System.Drawing.Point(472, 497);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(40, 23);
            this.label23.TabIndex = 69;
            this.label23.Text = "Hãng :";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label26
            // 
            this.label26.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label26.Location = new System.Drawing.Point(616, 497);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(48, 23);
            this.label26.TabIndex = 70;
            this.label26.Text = "Nước :";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sl1
            // 
            this.sl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.sl1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sl1.Enabled = false;
            this.sl1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sl1.Location = new System.Drawing.Point(48, 497);
            this.sl1.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
            this.sl1.Name = "sl1";
            this.sl1.Size = new System.Drawing.Size(72, 21);
            this.sl1.TabIndex = 13;
            this.sl1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.sl1.Validated += new System.EventHandler(this.sl1_Validated);
            // 
            // sl2
            // 
            this.sl2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.sl2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sl2.Enabled = false;
            this.sl2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sl2.Location = new System.Drawing.Point(128, 497);
            this.sl2.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.sl2.Name = "sl2";
            this.sl2.Size = new System.Drawing.Size(40, 21);
            this.sl2.TabIndex = 14;
            this.sl2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.sl2.Validated += new System.EventHandler(this.sl2_Validated);
            // 
            // label27
            // 
            this.label27.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label27.Location = new System.Drawing.Point(120, 495);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(8, 23);
            this.label27.TabIndex = 73;
            this.label27.Text = "x";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label28
            // 
            this.label28.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label28.Location = new System.Drawing.Point(168, 495);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(8, 23);
            this.label28.TabIndex = 74;
            this.label28.Text = "=";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // find
            // 
            this.find.BackColor = System.Drawing.SystemColors.HighlightText;
            this.find.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.find.Location = new System.Drawing.Point(602, 29);
            this.find.Name = "find";
            this.find.Size = new System.Drawing.Size(110, 21);
            this.find.TabIndex = 104;
            this.find.Text = "Tìm kiếm";
            this.find.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.find.Enter += new System.EventHandler(this.find_Enter);
            this.find.TextChanged += new System.EventHandler(this.find_TextChanged);
            // 
            // losx
            // 
            this.losx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.losx.BackColor = System.Drawing.SystemColors.HighlightText;
            this.losx.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.losx.Enabled = false;
            this.losx.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.losx.Location = new System.Drawing.Point(384, 497);
            this.losx.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.losx.MaxLength = 20;
            this.losx.Name = "losx";
            this.losx.Size = new System.Drawing.Size(88, 21);
            this.losx.TabIndex = 17;
            // 
            // lsokhoan
            // 
            this.lsokhoan.Location = new System.Drawing.Point(8, 411);
            this.lsokhoan.Name = "lsokhoan";
            this.lsokhoan.Size = new System.Drawing.Size(184, 24);
            this.lsokhoan.TabIndex = 109;
            this.lsokhoan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbTimkiem
            // 
            this.cmbTimkiem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTimkiem.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cmbTimkiem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTimkiem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTimkiem.Items.AddRange(new object[] {
            "Số phiếu",
            "Số hóa đơn",
            "Số phiếu/hoá đơn"});
            this.cmbTimkiem.Location = new System.Drawing.Point(713, 29);
            this.cmbTimkiem.Name = "cmbTimkiem";
            this.cmbTimkiem.Size = new System.Drawing.Size(72, 21);
            this.cmbTimkiem.TabIndex = 103;
            this.cmbTimkiem.SelectedIndexChanged += new System.EventHandler(this.cmbTimkiem_SelectedIndexChanged);
            // 
            // dataGrid1
            // 
            this.dataGrid1.AlternatingBackColor = System.Drawing.Color.Lavender;
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
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
            this.dataGrid1.HeaderFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGrid1.HeaderForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.LinkColor = System.Drawing.Color.Teal;
            this.dataGrid1.Location = new System.Drawing.Point(8, 34);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(776, 434);
            this.dataGrid1.TabIndex = 1006;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            // 
            // frmNhap_soluong
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.tendv);
            this.Controls.Add(this.madv);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbTimkiem);
            this.Controls.Add(this.find);
            this.Controls.Add(this.makho);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.lsokhoan);
            this.Controls.Add(this.losx);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.sl2);
            this.Controls.Add(this.sl1);
            this.Controls.Add(this.tenhang);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.tennuoc);
            this.Controls.Add(this.nguoigiao);
            this.Controls.Add(this.sohd);
            this.Controls.Add(this.cmbSophieu);
            this.Controls.Add(this.sophieu);
            this.Controls.Add(this.tenbd);
            this.Controls.Add(this.tenhc);
            this.Controls.Add(this.lTenhc);
            this.Controls.Add(this.handung);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.dang);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butHuy);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butXoa);
            this.Controls.Add(this.butThem);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butSua);
            this.Controls.Add(this.butMoi);
            this.Controls.Add(this.soluong);
            this.Controls.Add(this.mabd);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.ldvt);
            this.Controls.Add(this.lTen);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.listDMBD);
            this.Controls.Add(this.listNX);
            this.Controls.Add(this.ngayhd);
            this.Controls.Add(this.ngaysp);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.stt);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmNhap_soluong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phiếu nhập kho";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmNhap_soluong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmNhap_soluong_Load(object sender, System.EventArgs e)
		{
            //if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            user = d.user; xxx = user + s_mmyy;
			bLockytu=d.bLockytu_traiphai(i_nhom);
			format_soluong=d.format_soluong(i_nhom);
			cmbTimkiem.SelectedIndex=0;
			bSophieu=d.bSophieunhap_tudong(i_nhom);
			bNguoigiao=d.bNguoigiao;
			bQuidoi=d.bQuidoi(i_nhom);
			bKhoaso=d.bKhoaso(i_nhom,s_mmyy);
			i_songay=d.Ngaylv_Ngayht;
			makho.DisplayMember="TEN";
			makho.ValueMember="ID";
			sql="select * from "+user+".d_dmkho where nhom="+i_nhom;
			if (s_makho!="") sql+=" and id in ("+s_makho.Substring(0,s_makho.Length-1)+")";
            if (s_loai == "M") sql += " and khott=1";
            if (i_khudt != 0) sql += " and (khu=0 or khu=" + i_khudt + ")";
			sql+=" order by stt";
			makho.DataSource=d.get_data(sql).Tables[0];
			makho.SelectedIndex=0;

			listDMBD.DisplayMember="TEN";
			listDMBD.ValueMember="MA";

			listNX.DisplayMember="MA";
			listNX.ValueMember="TEN";

			load_dm();

            sql = "select id,sophieu,to_char(ngaysp,'dd/mm/yyyy') as ngaysp,sohd,to_char(ngayhd,'dd/mm/yyyy') as ngayhd,nguoigiao,madv,makho,done from " + xxx + ".d_nhapslll ";
			sql+="where loai='"+s_loai+"'";
			if (!bAdmin) sql+=" and userid="+i_userid;
			sql+=" and nhom="+i_nhom;
			if (d.bPhieunhap_sophieu(i_nhom)) sql+=" order by sophieu";
			else sql+=" order by id";
			dtll=d.get_data(sql).Tables[0];
			cmbSophieu.DisplayMember="SOPHIEU";
			cmbSophieu.ValueMember="ID";
			cmbSophieu.DataSource=dtll;
			if (dtll.Rows.Count>0) l_id=decimal.Parse(cmbSophieu.SelectedValue.ToString());
			else l_id=0;
			load_head();
			AddGridTableStyle();
			dsxoa.ReadXml("..\\..\\..\\xml\\d_nhapct.xml");
		}

		private void load_grid()
		{
			dataGrid1.DataSource=null;
			sql="select a.stt,a.mabd,b.ma,trim(b.ten)||' '||b.hamluong as ten,nullif(b.tenhc,' ') as tenhc,b.dang,a.handung,a.losx,a.soluong,c.ten as tenhang,d.ten as tennuoc,a.sl1,a.sl2";
            sql += " from " + xxx + ".d_nhapslct a," + user + ".d_dmbd b," + user + ".d_dmhang c," + user + ".d_dmnuoc d where a.mabd=b.id and b.mahang=c.id and b.manuoc=d.id and a.id=" + l_id + " order by a.stt";
			dtct=d.get_data(sql).Tables[0];
			dataGrid1.DataSource=dtct;
			lsokhoan.Text="TỔNG SỐ KHOẢN :"+dtct.Rows.Count.ToString();
		}

		private void ref_text()
		{
			try
			{
				int i=dataGrid1.CurrentCell.RowNumber;
				stt.Text=dataGrid1[i,0].ToString();
				mabd.Text=dataGrid1[i,1].ToString();
				tenbd.Text=dataGrid1[i,2].ToString();
				tenhc.Text=dataGrid1[i,3].ToString();
				dang.Text=dataGrid1[i,4].ToString();
				handung.Text=dataGrid1[i,5].ToString();
				losx.Text=dataGrid1[i,6].ToString();
				tenhang.Text=dataGrid1[i,10].ToString();
				tennuoc.Text=dataGrid1[i,11].ToString();
				d_soluong=(dataGrid1[i,9].ToString()!="")?decimal.Parse(dataGrid1[i,9].ToString()):0;
				d_sl1=(dataGrid1[i,7].ToString()!="")?decimal.Parse(dataGrid1[i,7].ToString()):0;
				d_sl2=(dataGrid1[i,8].ToString()!="")?decimal.Parse(dataGrid1[i,8].ToString()):0;
				sl1.Text=(bQuidoi)?d_sl1.ToString(format_soluong):d_soluong.ToString(format_soluong);
				sl2.Text=d_sl2.ToString("###,###,##0");
				soluong.Text=d_soluong.ToString(format_soluong);
				if (butLuu.Enabled)
				{
					r=d.getrowbyid(dtdmbd,"ma='"+mabd.Text+"'");
					if (r!=null)
					{
						i_mabd=int.Parse(r["id"].ToString());
						tenbd.Enabled=d.get_iXuat(s_mmyy,int.Parse(makho.SelectedValue.ToString()),l_id,int.Parse(stt.Text))==0;
						if (d.bNhapmaso) mabd.Enabled=tenbd.Enabled;
						if (bQuidoi)
						{
							sl1.Enabled=tenbd.Enabled;
							sl2.Enabled=tenbd.Enabled;
						}
						else soluong.Enabled=tenbd.Enabled;
						if (d.bQuanlyhandung(i_nhom)) handung.Enabled=tenbd.Enabled;
						if (d.bQuanlylosx(i_nhom)) losx.Enabled=tenbd.Enabled;
					}
				}
			}
            catch { emp_detail(); }
		}

		private void AddGridTableStyle()
		{
			DataGridColoredTextBoxColumn TextCol;
			delegateGetColorRowCol de = new delegateGetColorRowCol(MyGetColorRowCol);
			DataGridTableStyle ts =new DataGridTableStyle();
			ts.AlternatingBackColor = Color.Beige;
			ts.BackColor = Color.GhostWhite;
			ts.ForeColor = Color.MidnightBlue;
			ts.GridLineColor = Color.RoyalBlue;
			ts.HeaderBackColor = Color.MidnightBlue;
			ts.HeaderForeColor = Color.Lavender;
			ts.SelectionBackColor = Color.Teal;
			ts.SelectionForeColor = Color.PaleGreen;
			ts.RowHeaderWidth=10;
			ts.MappingName = dtct.TableName;
			ts.AllowSorting=false;
			
			TextCol=new DataGridColoredTextBoxColumn(de, 0);
			TextCol.MappingName = "stt";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 1);
			TextCol.MappingName = "ma";
			TextCol.HeaderText = "Mã số";
			TextCol.Width = 50;
			TextCol.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 2);
			TextCol.MappingName = "ten";
			TextCol.HeaderText = "Tên";
			TextCol.Width = 200;
			TextCol.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 3);
			TextCol.MappingName = "tenhc";
			TextCol.HeaderText = "Hoạt chất";
			TextCol.Width = (d.bHoatchat)?200:0;
			TextCol.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 4);
			TextCol.MappingName = "dang";
			TextCol.HeaderText = "ĐVT";
			TextCol.Width = 50;
			TextCol.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 5);
			TextCol.MappingName = "handung";
			TextCol.HeaderText = "Date";
			TextCol.Width = (d.bQuanlyhandung(i_nhom))?30:0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 6);
			TextCol.MappingName = "losx";
			TextCol.HeaderText = "Lô SX";
			TextCol.Width = (d.bQuanlylosx(i_nhom))?50:0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 7);
			TextCol.MappingName = "sl1";
			TextCol.HeaderText = (bQuidoi)?"Số lượng":"";
			TextCol.Width = (bQuidoi)?80:0;
			TextCol.Format=format_soluong;
			TextCol.Alignment=HorizontalAlignment.Right;
			TextCol.ReadOnly=(bQuidoi)?false:true;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 8);
			TextCol.MappingName = "sl2";
			TextCol.HeaderText = (bQuidoi)?"Qui đổi":"";
			TextCol.Width = (bQuidoi)?60:0;
			TextCol.Format=format_soluong;
			TextCol.Alignment=HorizontalAlignment.Right;
			TextCol.ReadOnly=(bQuidoi)?false:true;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 9);
			TextCol.MappingName = "soluong";
			TextCol.HeaderText = "Số lượng";
			TextCol.Width = 80;
			TextCol.Format=format_soluong;
			TextCol.Alignment=HorizontalAlignment.Right;
			TextCol.ReadOnly=(bQuidoi)?true:false;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 10);
			TextCol.MappingName = "tenhang";
			TextCol.HeaderText = "Hãng";
			TextCol.Width = 150;
			TextCol.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridColoredTextBoxColumn(de, 11);
			TextCol.MappingName = "tennuoc";
			TextCol.HeaderText = "Nước";
			TextCol.Width = 150;
			TextCol.ReadOnly=true;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);
		}

		public Color MyGetColorRowCol(int row, int col)
		{
			return (dataGrid1[row,9].ToString()=="0")?Color.Red:Color.Black;
		}
		public delegate Color delegateGetColorRowCol(int row, int col);
		public class DataGridColoredTextBoxColumn : DataGridTextBoxColumn
		{
			private delegateGetColorRowCol _getColorRowCol;
			private int _column;
			public DataGridColoredTextBoxColumn(delegateGetColorRowCol getcolorRowCol, int column)
			{
				_getColorRowCol = getcolorRowCol;
				_column = column;
			}
			protected override void Paint(System.Drawing.Graphics g, System.Drawing.Rectangle bounds, System.Windows.Forms.CurrencyManager source, int rowNum, System.Drawing.Brush backBrush, System.Drawing.Brush foreBrush, bool alignToRight)
			{
				try
				{
					foreBrush = new SolidBrush(_getColorRowCol(rowNum, this._column));
				}			
				catch{}
				finally
				{
					base.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight);
				}
			}
		}

		private void load_dm()
		{
            dtdmbd = d.get_data("select a.ma,trim(a.ten)||' '||a.hamluong as ten,trim(b.ten)||'/'||c.ten as hang,a.dang,a.tenhc,a.id,a.giaban,a.dongia,b.ten as tenhang,c.ten as tennuoc,a.manhom,nullif(d.ma,' ') as sotk from " + user + ".d_dmbd a inner join " + user + ".d_dmhang b on a.mahang=b.id inner join " + user + ".d_dmnuoc c on a.manuoc=c.id left join " + user + ".d_dmnhomkt d on a.sotk=d.id where a.nhom=" + i_nhom + " and a.hide=0 order by a.ten").Tables[0];
			listDMBD.DataSource=dtdmbd;
            dtdmnx = d.get_data("select ma,ten,id,nhomcc,diachi,masothue from " + user + ".d_dmnx where nhom=" + i_nhom + " order by stt").Tables[0];
			listNX.DataSource=dtdmnx;
		}

		private void sophieu_Validated(object sender, System.EventArgs e)
		{
			//if (l_id!=0) return;
			try
			{
				r=d.getrowbyid(dtll,"sophieu='"+sophieu.Text+"' and id<>"+l_id);
				if (r!=null)
				{
					MessageBox.Show(
lan.Change_language_MessageText("Số phiếu đã nhập !"),d.Msg);
					sophieu.Focus();
				}
			}
			catch{}
		}

		private void cmbSophieu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab) butMoi.Focus();
		}

		private void cmbSophieu_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==cmbSophieu)
			{
				try
				{
					l_id=decimal.Parse(cmbSophieu.SelectedValue.ToString());
				}
				catch{l_id=0;}
				load_head();
			}
		}

		private void load_head()
		{
			try
			{
				r=d.getrowbyid(dtll,"id="+l_id);
				if (r!=null)
				{
					sophieu.Text=r["sophieu"].ToString();
					ngaysp.Text=r["ngaysp"].ToString();
					sohd.Text=r["sohd"].ToString();
					ngayhd.Text=r["ngayhd"].ToString();
					nguoigiao.Text=r["nguoigiao"].ToString();
					makho.SelectedValue=r["makho"].ToString();
					DataRow r1=d.getrowbyid(dtdmnx,"id="+int.Parse(r["madv"].ToString()));
					if (r1!=null)
					{
						madv.Text=r1["ma"].ToString();
						tendv.Text=r1["ten"].ToString();
					}
					s_ngaysp=ngaysp.Text;
					s_ngayhd=ngayhd.Text;
					i_done=int.Parse(r["done"].ToString());
				}
			}
			catch{}
			load_grid();
			ref_text();
		}

		private void butKetthuc_Click(object sender, System.EventArgs e)
		{
			d.close();this.Close();
		}

		private void Filter_dmbd(string ten)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listDMBD.DataSource];
				DataView dv=(DataView)cm.List;
				if (bLockytu) sql="ten like '"+ten.Trim()+"%'"+" or tenhc like '"+ten.Trim()+"%'";
				else sql="ten like '%"+ten.Trim()+"%'"+" or tenhc like '%"+ten.Trim()+"%'";
				dv.RowFilter=sql;
			}
			catch{}
		}

		private void Filter_dmnx(string ten)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listNX.DataSource];
				DataView dv=(DataView)cm.List;
				dv.RowFilter="ten like '%"+ten.Trim()+"%'";
			}
			catch{}
		}

		private void tenbd_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listDMBD.Focus();
			else if (e.KeyCode==Keys.Enter)
			{
				if (listDMBD.Visible) listDMBD.Focus();
				else SendKeys.Send("{Tab}");
			}
		}

		private void tenbd_Validated(object sender, System.EventArgs e)
		{
			if(!listDMBD.Focused) listDMBD.Hide();
			if (tenbd.Text!="" && mabd.Text=="")
			{
				r=d.getrowbyid(dtdmbd,"ten='"+tenbd.Text+"'");
				if (r!=null)
				{
					mabd.Text=r["ma"].ToString();
					dang.Text=r["dang"].ToString();
					tenhc.Text=r["tenhc"].ToString();
					tenhang.Text=r["tenhang"].ToString();
					tennuoc.Text=r["tennuoc"].ToString();
				}
			}
		}

		private void tendv_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listNX.Focus();
			else if (e.KeyCode==Keys.Enter)
			{
				if (listNX.Visible)	listNX.Focus();
				else SendKeys.Send("{Tab}");
			}
		}

		private void tendv_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tendv)
			{
				Filter_dmnx(tendv.Text);
				listNX.BrowseToDmnx(tendv,madv,makho);
			}
		}

		private void tendv_Validated(object sender, System.EventArgs e)
		{
			if(!listNX.Focused) listNX.Hide();
			if (tendv.Text!="" && madv.Text=="")
			{
				r=d.getrowbyid(dtdmnx,"ten='"+tendv.Text+"'");
				if (r!=null) madv.Text=r["ma"].ToString();
			}
		}

		private void ena_object(bool ena)
		{
			find.Enabled=!ena;
			cmbTimkiem.Enabled=!ena;
			sophieu.Visible=ena;
			cmbSophieu.Visible=!ena;
			if (!bSophieu) sophieu.Enabled=ena;
			ngaysp.Enabled=ena;
			sohd.Enabled=ena;
			ngayhd.Enabled=ena;
			madv.Enabled=ena;
			tendv.Enabled=ena;
			if (bNguoigiao) nguoigiao.Enabled=ena;
			makho.Enabled=ena;
			if (d.bNhapmaso) mabd.Enabled=ena;
			tenbd.Enabled=ena;
			if (bQuidoi)
			{
				sl1.Enabled=ena;
				sl2.Enabled=ena;
			}
			else soluong.Enabled=ena;
			if (d.bQuanlyhandung(i_nhom)) handung.Enabled=ena;
			if (d.bQuanlylosx(i_nhom)) losx.Enabled=ena;
			butMoi.Enabled=!ena;
			butSua.Enabled=!ena;
			butThem.Enabled=ena;
			butXoa.Enabled=ena;
			butLuu.Enabled=ena;
			butBoqua.Enabled=ena;
			butHuy.Enabled=!ena;
			butKetthuc.Enabled=!ena;
			i_old=cmbSophieu.SelectedIndex;
			if (d.bDanhmuc || d.bDmbd)
			{
				if (d.bDanhmuc) d.writeXml("d_thongso","c01","0");
				else d.writeXml("d_thongso","c06","0");
				load_dm();
			}
			dataGrid1.ReadOnly=!ena;
			CurrencyManager cm = (CurrencyManager)BindingContext[dataGrid1.DataSource,dataGrid1.DataMember];  
			DataView dv = (DataView) cm.List;
            find.Text = "";
            CurrencyManager cm1 = (CurrencyManager)BindingContext[cmbSophieu.DataSource];
            DataView dv1 = (DataView)cm1.List;
            dv1.RowFilter = "";
        }

		private void emp_head()
		{
			l_id=0;i_done=0;
			if (bSophieu) sophieu.Text=d.get_sophieu(s_mmyy,"d_nhapslll","sophieu"," where nhom="+i_nhom+" and loai='"+s_loai+"'");
			else sophieu.Text="";
			ngaysp.Text=s_ngay;
			sohd.Text="";
			ngayhd.Text=s_ngay;
			madv.Text="";
			tendv.Text="";
			nguoigiao.Text="";            
			makho.SelectedIndex=0;
			s_ngaysp=ngaysp.Text;
			s_ngayhd=ngayhd.Text;
			dsxoa.Clear();
			lsokhoan.Text="TỔNG SỐ KHOẢN :"+dtct.Rows.Count.ToString();
		}
		
		private void emp_detail()
		{
			mabd.Text="";
			tenbd.Text="";
			tenhc.Text="";
			dang.Text="";
			soluong.Text="";
			sl1.Text="";
			sl2.Text="1";
			handung.Text="";
			losx.Text="";
			tenhang.Text="";
			tennuoc.Text="";
			stt.Text=d.get_stt(dtct).ToString();
		}

		private void butMoi_Click(object sender, System.EventArgs e)
		{
			if (bKhoaso)
			{
				MessageBox.Show(
lan.Change_language_MessageText("Số liệu tháng")+" "+s_mmyy.Substring(0,2)+" "+
lan.Change_language_MessageText("năm")+" "+s_mmyy.Substring(2,2)+" "+
lan.Change_language_MessageText("đã khóa !")+"\n"+
lan.Change_language_MessageText("Nếu cần thay đổi thì vào mục khai báo hệ thống"),d.Msg);
				return;
			}
			ena_object(true);
			emp_head();
			emp_detail();
			dtct.Clear();
			dtold.Clear();
			if (sophieu.Text!="")
			{
				emp_head();
				emp_detail();
				dtct.Clear();
			}
			bNew=true;
			makho_old=0;
			if (sophieu.Enabled) sophieu.Focus();
			else ngaysp.Focus();
		}
		private void butSua_Click(object sender, System.EventArgs e)
		{
			if (cmbSophieu.Items.Count==0) return;
			if (bKhoaso)
			{
				MessageBox.Show(
lan.Change_language_MessageText("Số liệu tháng")+" "+s_mmyy.Substring(0,2)+" "+
lan.Change_language_MessageText("năm")+" "+s_mmyy.Substring(2,2)+" "+
lan.Change_language_MessageText("đã khóa !")+"\n"+
lan.Change_language_MessageText("Nếu cần thay đổi thì vào mục khai báo hệ thống"),d.Msg);
				return;
			}
			l_id=decimal.Parse(cmbSophieu.SelectedValue.ToString());
			if (i_done==1)
			{
				MessageBox.Show(
lan.Change_language_MessageText("Số phiếu đã cập nhật !"),d.Msg);
				return;
			}
			ena_object(true);
			bNew=false;
			makho_old=int.Parse(makho.SelectedValue.ToString());
			dtold=dtct.Copy();
			dsxoa.Clear();
			sophieu.Focus();
			ref_text();
		}
		private bool KiemtraHead()
		{
			if (sophieu.Text=="")
			{
				MessageBox.Show(
lan.Change_language_MessageText("Nhập số phiếu !"),d.Msg);
				sophieu.Focus();
				return false;
			}
			if (ngaysp.Text=="")
			{
				MessageBox.Show(
lan.Change_language_MessageText("Nhập ngày số phiếu !"),d.Msg);
				ngaysp.Focus();
				return false;
			}
			if (sohd.Text=="")
			{
				MessageBox.Show(
lan.Change_language_MessageText("Nhập số hóa đơn !"),d.Msg);
				sohd.Focus();
				return false;
			}
			if (ngayhd.Text=="")
			{
				MessageBox.Show(
lan.Change_language_MessageText("Nhập ngày hóa đơn !"),d.Msg);
				ngayhd.Focus();
				return false;
			}
			if (makho.SelectedIndex==-1)
			{
				MessageBox.Show(
lan.Change_language_MessageText("Nhập kho nhập !"),d.Msg);
				makho.Focus();
				return false;
			}
			if (madv.Text=="" && tendv.Text=="")
			{
				MessageBox.Show(
lan.Change_language_MessageText("Chọn nhà cung cấp !"),d.Msg);
				madv.Focus();
				return false;
			}
			if ((madv.Text!="" && tendv.Text=="") || (madv.Text=="" && tendv.Text!=""))
			{
				if (madv.Text=="")
				{
					madv.Focus();
					return false;
				}
				else if (tendv.Text=="")
				{
					tendv.Focus();
					return false;
				}
			}
			i_madv=0;
			r=d.getrowbyid(dtdmnx,"ma='"+madv.Text+"'");
			if (r==null)
			{
				MessageBox.Show(
lan.Change_language_MessageText("Nhà cung cấp không hợp lệ !"),d.Msg);
				madv.Focus();
				return false;
			}
			i_madv=int.Parse(r["id"].ToString());
			if (dtct.Rows.Count==0)
			{
				MessageBox.Show(
lan.Change_language_MessageText("Đề nghị nhập chi tiết !"),d.Msg);
				butThem.Focus();
				return false;
			}
			return true;
		}

		private bool KiemtraDetail()
		{
			i_mabd=0;
			if (mabd.Text=="" && tenbd.Text=="")
			{
				if (mabd.Enabled) mabd.Focus();
				else tenbd.Focus();
				return false;
			}
			if ((mabd.Text=="" && tenbd.Text!="") || (mabd.Text!="" && tenbd.Text==""))
			{
				if (mabd.Text=="" && mabd.Enabled)
				{
					MessageBox.Show(
lan.Change_language_MessageText("Nhập mã số !"),d.Msg);
					mabd.Focus();
					return false;
				}
				else if (tenbd.Text=="")
				{
					MessageBox.Show(
lan.Change_language_MessageText("Nhập tên !"),d.Msg);
					tenbd.Focus();
					return false;
				}
			}
			r=d.getrowbyid(dtdmbd,"ma='"+mabd.Text+"'");
			if (r==null)
			{
				MessageBox.Show(
lan.Change_language_MessageText("Mã số không hợp lệ !"),d.Msg);
				if (mabd.Enabled) mabd.Focus();
				else tenbd.Focus();
				return false;
			}
			i_mabd=int.Parse(r["id"].ToString());
			return true;
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			upd_table(dtct);
			dtct.AcceptChanges();
			if (!KiemtraHead()) return;
			i_old=(bNew)?0:1;
			l_id=(bNew)?d.get_id_nhap:l_id;
            itable = d.tableid(s_mmyy, "d_nhapslll");
            if (bNew) d.upd_eve_tables(s_mmyy, itable, i_userid, "ins");
            else
            {
                d.upd_eve_tables(s_mmyy, itable, i_userid, "upd");
                d.upd_eve_upd_del(s_mmyy, itable, i_userid, "upd", l_id.ToString() + "^" + i_nhom.ToString() + "^" + sophieu.Text + "^" + ngaysp.Text + "^" + sohd.Text + "^" + ngayhd.Text + "^" + s_loai + "^" + nguoigiao.Text + "^" + i_madv.ToString() + "^" + makho.SelectedValue.ToString() + "^" + i_userid.ToString());
            }
			if (!d.upd_nhapslll(s_mmyy,l_id,i_nhom,sophieu.Text,ngaysp.Text,sohd.Text,ngayhd.Text,s_loai,nguoigiao.Text,i_madv,int.Parse(makho.SelectedValue.ToString()),i_userid))
			{
				MessageBox.Show(
lan.Change_language_MessageText("Không cập nhật được thông tin phiếu nhập kho !"),d.Msg);
				return;
			}
            itable = d.tableid(s_mmyy, "d_nhapslct");
			if (!bNew)
			{
				if (makho_old!=int.Parse(makho.SelectedValue.ToString()))
				{
					foreach(DataRow r1 in dtold.Rows)
                        d.execute_data("delete from " + xxx + ".d_nhapslct where id=" + l_id + " and stt=" + int.Parse(r1["stt"].ToString()));
					dtold.Clear();
				}
                foreach (DataRow r1 in dsxoa.Tables[0].Rows)
                {
                    d.upd_eve_tables(s_mmyy, itable, i_userid, "del");
                    d.upd_eve_upd_del(s_mmyy, itable, i_userid, "del", d.fields(xxx + ".d_nhapslct", "id=" + l_id + " and stt=" + int.Parse(r1["stt"].ToString())));
                    d.execute_data("delete from " + xxx + ".d_nhapslct where id=" + l_id + " and stt=" + int.Parse(r1["stt"].ToString()));
                }
			}
            foreach (DataRow r1 in dtct.Rows)
            {
                if (d.get_data("select * from " + xxx + ".d_nhapslct where id=" + l_id + " and stt=" + int.Parse(r1["stt"].ToString())).Tables[0].Rows.Count != 0)
                {
                    d.upd_eve_tables(s_mmyy, itable, i_userid, "upd");
                    d.upd_eve_upd_del(s_mmyy, itable, i_userid, "upd", l_id.ToString() + "^" + r1["stt"].ToString() + "^" + r1["mabd"].ToString() + "^" + r1["handung"].ToString().PadLeft(4, '0') + "^" + r1["losx"].ToString() + "^" + r1["soluong"].ToString() + "^" + ((bQuidoi) ? r1["sl1"].ToString() : r1["soluong"].ToString()) + "^" + r1["sl2"].ToString());
                }
                else d.upd_eve_tables(s_mmyy, itable, i_userid, "ins");
                d.upd_nhapslct(s_mmyy, l_id, int.Parse(r1["stt"].ToString()), int.Parse(r1["mabd"].ToString()), r1["handung"].ToString().PadLeft(4, '0'), r1["losx"].ToString(), decimal.Parse(r1["soluong"].ToString()), (bQuidoi) ? decimal.Parse(r1["sl1"].ToString()) : decimal.Parse(r1["soluong"].ToString()), decimal.Parse(r1["sl2"].ToString()));
            }
			d.updrec_nhapslll(dtll,l_id,sophieu.Text,ngaysp.Text,sohd.Text,ngayhd.Text,nguoigiao.Text,i_madv,int.Parse(makho.SelectedValue.ToString()));
			try
			{
				if (i_old==0 && dtll.Rows.Count>0) cmbSophieu.SelectedIndex=dtll.Rows.Count-1;
                if (!bNew)
                {
                    cmbSophieu.SelectedValue = l_id.ToString();
                    load_head();
                }
			}
			catch{}
			ena_object(false);
			butMoi.Focus();
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			cmbSophieu.SelectedIndex=i_old;
			try
			{
				l_id=decimal.Parse(cmbSophieu.SelectedValue.ToString());
			}
			catch{l_id=0;}
			load_head();
			ena_object(false);
			butMoi.Focus();
		}

		private void ngaysp_Validated(object sender, System.EventArgs e)
		{
			if (ngaysp.Text=="") return;
			ngaysp.Text=ngaysp.Text.Trim();
            if (ngaysp.Text.Length == 6) ngaysp.Text = ngaysp.Text + DateTime.Now.Year.ToString();
			if (!d.bNgay(ngaysp.Text))
			{
				MessageBox.Show(
lan.Change_language_MessageText("Ngày không hợp lệ !"),d.Msg);
				ngaysp.Focus();
				return;
			}
			ngaysp.Text=d.Ktngaygio(ngaysp.Text,10);
			if (ngaysp.Text!=s_ngaysp)
			{
				if (!d.ngay(d.StringToDate(ngaysp.Text.Substring(0,10)),DateTime.Now,i_songay))
				{
					MessageBox.Show(
lan.Change_language_MessageText("Ngày không hợp lệ so với khai báo hệ thống (")+i_songay.ToString()+")!",d.Msg);
					ngaysp.Focus();
					return;
				}
			}
		}

		private void ngayhd_Validated(object sender, System.EventArgs e)
		{
			if (ngayhd.Text=="") return;
			ngayhd.Text=ngayhd.Text.Trim();
            if (ngayhd.Text.Length == 6) ngayhd.Text = ngayhd.Text + DateTime.Now.Year.ToString();
			if (!d.bNgay(ngayhd.Text))
			{
				MessageBox.Show(
lan.Change_language_MessageText("Ngày không hợp lệ !"),d.Msg);
				ngayhd.Focus();
				return;
			}
			ngayhd.Text=d.Ktngaygio(ngayhd.Text,10);
			if (ngayhd.Text!=s_ngayhd)
			{
				if (!d.ngay(d.StringToDate(ngayhd.Text.Substring(0,10)),DateTime.Now,i_songay))
				{
					MessageBox.Show(
lan.Change_language_MessageText("Ngày không hợp lệ so với khai báo hệ thống (")+i_songay.ToString()+")!",d.Msg);
					ngayhd.Focus();
					return;
				}
			}
		}

		private void butThem_Click(object sender, System.EventArgs e)
		{
			tenbd.Enabled=true;
			if (d.bNhapmaso) mabd.Enabled=tenbd.Enabled;
			if (bQuidoi)
			{
				sl1.Enabled=tenbd.Enabled;
				sl2.Enabled=tenbd.Enabled;
			}
			else soluong.Enabled=tenbd.Enabled;
			if (d.bQuanlyhandung(i_nhom)) handung.Enabled=tenbd.Enabled;
			if (d.bQuanlylosx(i_nhom)) losx.Enabled=tenbd.Enabled;
			if (!upd_table(dtct)) return;
			emp_detail();
			if (mabd.Enabled) mabd.Focus();
			else tenbd.Focus();
		}

		private void butXoa_Click(object sender, System.EventArgs e)
		{
			if (!upd_table(dsxoa.Tables[0])) return;
			d.delrec(dtct,"stt="+int.Parse(stt.Text));
			dtct.AcceptChanges();
			if (dtct.Rows.Count==0) emp_detail();
			else ref_text();
		}

		private bool upd_table(DataTable dt)
		{
			if (!KiemtraDetail()) return false;
			if (bQuidoi)
			{
				d_sl1=(sl1.Text!="")?decimal.Parse(sl1.Text):0;
				d_sl2=(sl2.Text!="")?decimal.Parse(sl2.Text):1;
				d_soluong=d_sl1*d_sl2;
			}
			else 
			{
				d_soluong=(soluong.Text!="")?decimal.Parse(soluong.Text):0;
				d_sl1=d_soluong;d_sl2=1;
			}
			handung.Text=handung.Text.Trim().PadRight(4,'0');
			handung.Refresh();
			d.updrec_nhapslct(dt,int.Parse(stt.Text),i_mabd,mabd.Text,tenbd.Text,tenhc.Text,dang.Text,handung.Text,losx.Text,d_soluong,d_sl1,d_sl2);
			dt.AcceptChanges();
			return true;
		}

		private void madv_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void makho_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (makho.SelectedIndex==-1) makho.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void madv_Validated(object sender, System.EventArgs e)
		{
			if (madv.Text!="")
			{
				r=d.getrowbyid(dtdmnx,"ma='"+madv.Text+"'");
				if (r!=null) tendv.Text=r["ten"].ToString();
			}
		}

		private void mabd_Validated(object sender, System.EventArgs e)
		{
			if (mabd.Text!="")
			{
				r=d.getrowbyid(dtdmbd,"ma='"+mabd.Text+"'");
				if (r!=null) 
				{
					tenbd.Text=r["ten"].ToString();
					tenhc.Text=r["tenhc"].ToString();
					dang.Text=r["dang"].ToString();
					tenhang.Text=r["tenhang"].ToString();
					tennuoc.Text=r["tennuoc"].ToString();
				}
			}
			if(!listDMBD.Focused) listDMBD.Hide();
		}

		private void listDMBD_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) mabd_Validated(null,null);
		}

		private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			try
			{
				if (dataGrid1.CurrentCell.ColumnNumber>6 && dataGrid1.CurrentCell.ColumnNumber<9 && i_row<dtct.Rows.Count)
					upd_rec(int.Parse(dataGrid1[i_row,0].ToString()),decimal.Parse(dataGrid1[i_row,7].ToString()),decimal.Parse(dataGrid1[i_row,8].ToString()));
				i_row=dataGrid1.CurrentRowIndex;
			}
			catch{}
			ref_text();
		}

		private void upd_rec(int stt,decimal s1,decimal s2)
		{
			DataRow [] dr=dtct.Select("stt="+stt);
			if (dr.Length>0) dr[0]["soluong"]=s1*s2;
		}

		private void tinh_giatri()
		{
			try
			{
				if (bQuidoi)
				{
					d_sl1=(sl1.Text!="")?decimal.Parse(sl1.Text):0;
					d_sl2=(sl2.Text!="")?decimal.Parse(sl2.Text):1;
					d_soluong=d_sl1*d_sl2;
					soluong.Text=d_soluong.ToString(format_soluong);
				}
				else
				{
					d_soluong=(soluong.Text!="")?decimal.Parse(soluong.Text):0;
					sl1.Text=d_soluong.ToString(format_soluong);
					sl2.Text="1";
				}
			}
			catch{}
		}

		private void soluong_Validated(object sender, System.EventArgs e)
		{
			try
			{
				d_soluong=(soluong.Text!="")?decimal.Parse(soluong.Text):0;
				soluong.Text=d_soluong.ToString(format_soluong);
			}
			catch{}
			tinh_giatri();
		}

		private void butHuy_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (cmbSophieu.Items.Count==0) return;
				if (bKhoaso)
				{
					MessageBox.Show(
lan.Change_language_MessageText("Số liệu tháng")+" "+s_mmyy.Substring(0,2)+" "+
lan.Change_language_MessageText("năm")+" "+s_mmyy.Substring(2,2)+" "+
lan.Change_language_MessageText("đã khóa !")+
lan.Change_language_MessageText("\nNếu cần thay đổi thì vào mục khai báo hệ thống"),d.Msg);
					return;
				}
				l_id=decimal.Parse(cmbSophieu.SelectedValue.ToString());
				if (i_done==1)
				{
					MessageBox.Show(
lan.Change_language_MessageText("Số phiếu đã cập nhật !"),d.Msg);
					return;
				}
				if (MessageBox.Show(
lan.Change_language_MessageText("Đồng ý hủy số phiếu này ?"),d.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
				{
                    itable = d.tableid(s_mmyy, "d_nhapslct");
                    foreach (DataRow r1 in dtct.Rows)
                    {
                        d.upd_eve_tables(s_mmyy, itable, i_userid, "del");
                        d.upd_eve_upd_del(s_mmyy, itable, i_userid, "del", d.fields(xxx + ".d_nhapslct", "id=" + l_id+" and stt="+int.Parse(r1["stt"].ToString())));
                    }
                    itable = d.tableid(s_mmyy, "d_nhapslll");
                    d.upd_eve_tables(s_mmyy, itable, i_userid, "del");
                    d.upd_eve_upd_del(s_mmyy, itable, i_userid, "del", d.fields(xxx + ".d_nhapll", "id=" + l_id));
                    d.execute_data("delete from " + xxx + ".d_nhapslct where id=" + l_id);
                    d.execute_data("delete from " + xxx + ".d_nhapslll where id=" + l_id);
					d.delrec(dtll,"id="+l_id);
					cmbSophieu.Refresh();
					if (cmbSophieu.Items.Count>0) l_id=decimal.Parse(cmbSophieu.SelectedValue.ToString());
					else l_id=0;
					load_head();
				}
			}
			catch{}
		}

		private void nguoigiao_Validated(object sender, System.EventArgs e)
		{
			SendKeys.Send("{F4}");
		}

		private void sohd_Validated(object sender, System.EventArgs e)
		{
            //if (l_id!=0) return;
			try
			{
                r = d.getrowbyid(dtll, "sohd='" + sohd.Text + "'  and id<>" + l_id);
				if (r!=null)
				{
					MessageBox.Show(lan.Change_language_MessageText("Số hóa đơn đã nhập !"),d.Msg);
					sohd.Focus();
				}
			}
			catch{}		
		}

		private void tenbd_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tenbd)
			{
				if (butMoi.Enabled) return;
				Filter_dmbd(tenbd.Text);
				if (soluong.Enabled)
					listDMBD.BrowseToDmbd(tenbd,mabd,soluong,mabd.Location.X,mabd.Location.Y + mabd.Height-2,mabd.Width+lTen.Width+tenbd.Width+lTenhc.Width+tenhc.Width+ldvt.Width+dang.Width-40,mabd.Height+5);
				else
					listDMBD.BrowseToDmbd(tenbd,mabd,sl1,mabd.Location.X,mabd.Location.Y + mabd.Height-2,mabd.Width+lTen.Width+tenbd.Width+lTenhc.Width+tenhc.Width+ldvt.Width+dang.Width-40,mabd.Height+5);
			}
		}

		private void mabd_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==mabd)
			{
				if (butMoi.Enabled) return;
				Filter_mabd(mabd.Text);
				if (soluong.Enabled)
					listDMBD.BrowseToDmbd(mabd,tenbd,soluong,mabd.Location.X,mabd.Location.Y + mabd.Height-2,mabd.Width+lTen.Width+tenbd.Width+lTenhc.Width+tenhc.Width+ldvt.Width+dang.Width-40,mabd.Height+5);
				else
					listDMBD.BrowseToDmbd(mabd,tenbd,sl1,mabd.Location.X,mabd.Location.Y + mabd.Height-2,mabd.Width+lTen.Width+tenbd.Width+lTenhc.Width+tenhc.Width+ldvt.Width+dang.Width-40,mabd.Height+5);
			}
		}

		private void Filter_mabd(string ma)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listDMBD.DataSource];
				DataView dv=(DataView)cm.List;
				if (bLockytu) sql="ma like '"+ma.Trim()+"%'";
				else sql="ma like '%"+ma.Trim()+"%'";
				dv.RowFilter=sql;
			}
			catch{}
		}

		private void sl1_Validated(object sender, System.EventArgs e)
		{
			try
			{
				d_sl1=(sl1.Text!="")?decimal.Parse(sl1.Text):0;
				sl1.Text=d_sl1.ToString(format_soluong);
			}
			catch{}
			tinh_giatri();
		}

		private void sl2_Validated(object sender, System.EventArgs e)
		{
			try
			{
				d_sl2=(sl2.Text!="")?decimal.Parse(sl2.Text):1;
				sl2.Text=d_sl2.ToString("#,###,##0");
			}
			catch{}
			tinh_giatri();
		}

		private void find_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==find) RefreshChildren(find.Text);
		}

		private void RefreshChildren(string text)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[cmbSophieu.DataSource];
				DataView dv=(DataView)cm.List;			
				if (cmbTimkiem.SelectedIndex==0)sql="sophieu like '%"+text.Trim()+"%'";
				else if (cmbTimkiem.SelectedIndex==1)sql="sohd like '%"+text+"%'";
				else sql="sophieu like '%"+text.Trim()+"%' or sohd like '%"+text+"%'";
				dv.RowFilter=sql;
				if(cmbSophieu.SelectedIndex>=0)	l_id=decimal.Parse(cmbSophieu.SelectedValue.ToString());
				else l_id=0;
				load_head();
			}
			catch(Exception ex){MessageBox.Show(ex.Message);}
		}

		private void find_Enter(object sender, System.EventArgs e)
		{
			find.Text="";
		}

		private void cmbTimkiem_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==cmbTimkiem && find.Text!="") RefreshChildren(find.Text);
		}
	}
}
