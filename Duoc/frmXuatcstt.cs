using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibDuoc;
using doiso;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace Duoc
{
	/// <summary>
	/// Summary description for frmXkhac.
	/// </summary>
	public class frmXuatcstt : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private MaskedBox.MaskedBox ngaysp;
		private LibList.List listDMBD;
		private System.Windows.Forms.Label lTen;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.TextBox tenbd;
		private System.Windows.Forms.TextBox mabd;
		private MaskedBox.MaskedBox dang;
		private MaskedTextBox.MaskedTextBox soluong;
		private MaskedTextBox.MaskedTextBox dongia;
		private MaskedTextBox.MaskedTextBox sotien;
		private System.Windows.Forms.Button butMoi;
		private System.Windows.Forms.Button butSua;
		private System.Windows.Forms.Button butLuu;
		private System.Windows.Forms.Button butThem;
		private System.Windows.Forms.Button butXoa;
		private System.Windows.Forms.Button butBoqua;
		private System.Windows.Forms.Button butHuy;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.Button butKetthuc;
		private System.Windows.Forms.ComboBox cmbSophieu;
		private string xxx,user,s_mmyy,s_ngay,sql,s_ngaysp,s_makho,s_kho,s_makp,s_manguon,format_soluong,format_sotien,format_dongia,s_nguon_doituong;
		private int i_nhom,i_userid,i_mabd,i_old,i_songay,i_makp,i_loai,i_thuoc,itable;
		private decimal l_id,l_sttt,l_idduyet;
		private decimal d_soluong,d_dongia,d_sotien,d_giaban,d_soluongton,d_soluongcu,d_tongcong, d_gia_bh=0;
		private bool bKhoaso,bNew,bEdit=true,bGiaban,bAdmin,bPhattron;
		private AccessData d;
		private Doisototext doiso=new Doisototext();
		private DataTable dttonct=new DataTable();
		private DataTable dtton=new DataTable();
		private DataTable dtll=new DataTable();
		private DataTable dtct=new DataTable();
		private DataTable dtsave=new DataTable();
		private DataTable dtduockp=new DataTable();
		private DataTable dtdoituong=new DataTable();
		private DataSet dsxoa=new DataSet();
		private System.Windows.Forms.Label ldvt;
		private DataRow r;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label24;
		private MaskedBox.MaskedBox handung;
		private MaskedBox.MaskedBox losx;
		private System.Windows.Forms.TextBox tenhc;
		private System.Windows.Forms.Label lTenhc;
		private MaskedTextBox.MaskedTextBox sophieu;
		private MaskedTextBox.MaskedTextBox giaban;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox manguon;
		private System.Windows.Forms.ComboBox nhomcc;
		private System.Windows.Forms.TextBox stt;
		private System.Windows.Forms.TextBox sttt;
		private System.Windows.Forms.ComboBox phieu;
		private System.Windows.Forms.Label lMabd;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox madoituong;
		private System.Windows.Forms.TextBox makp;
		private System.Windows.Forms.TextBox tenkp;
		private LibList.List listDuockp;
		private System.Windows.Forms.ComboBox makho;
		private System.Windows.Forms.Label label5;
		private System.Drawing.Printing.PrintDocument docToPrint = new System.Drawing.Printing.PrintDocument();
		private PrintDialog p=new PrintDialog();
		private DialogResult result;
		private System.Windows.Forms.TextBox find;
		private System.Windows.Forms.TextBox ghichu;
		private System.Windows.Forms.Label label7;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmXuatcstt(AccessData acc,int loai,string mmyy,string ngay,int nhom,int userid,string kho,string makp,string title,bool b_giaban,bool admin,int thuoc)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			d=acc;i_nhom=nhom;s_kho=kho;s_makp=makp;i_userid=userid;s_mmyy=mmyy;s_ngay=ngay;
			i_loai=loai;i_thuoc=thuoc;bGiaban=b_giaban;bAdmin=admin;this.Text=title;
            
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmXuatcstt));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.ngaysp = new MaskedBox.MaskedBox();
            this.phieu = new System.Windows.Forms.ComboBox();
            this.listDMBD = new LibList.List();
            this.lMabd = new System.Windows.Forms.Label();
            this.lTen = new System.Windows.Forms.Label();
            this.ldvt = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.tenbd = new System.Windows.Forms.TextBox();
            this.mabd = new System.Windows.Forms.TextBox();
            this.dang = new MaskedBox.MaskedBox();
            this.soluong = new MaskedTextBox.MaskedTextBox();
            this.dongia = new MaskedTextBox.MaskedTextBox();
            this.sotien = new MaskedTextBox.MaskedTextBox();
            this.butMoi = new System.Windows.Forms.Button();
            this.butSua = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.butThem = new System.Windows.Forms.Button();
            this.butXoa = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butHuy = new System.Windows.Forms.Button();
            this.butIn = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.cmbSophieu = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.handung = new MaskedBox.MaskedBox();
            this.losx = new MaskedBox.MaskedBox();
            this.tenhc = new System.Windows.Forms.TextBox();
            this.lTenhc = new System.Windows.Forms.Label();
            this.sophieu = new MaskedTextBox.MaskedTextBox();
            this.giaban = new MaskedTextBox.MaskedTextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.label3 = new System.Windows.Forms.Label();
            this.manguon = new System.Windows.Forms.ComboBox();
            this.nhomcc = new System.Windows.Forms.ComboBox();
            this.stt = new System.Windows.Forms.TextBox();
            this.sttt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.madoituong = new System.Windows.Forms.ComboBox();
            this.makp = new System.Windows.Forms.TextBox();
            this.tenkp = new System.Windows.Forms.TextBox();
            this.listDuockp = new LibList.List();
            this.makho = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.find = new System.Windows.Forms.TextBox();
            this.ghichu = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(-3, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Số phiếu :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(129, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ngày :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(229, 3);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 23);
            this.label9.TabIndex = 8;
            this.label9.Text = "Phiếu :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(374, 3);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 23);
            this.label10.TabIndex = 9;
            this.label10.Text = "Khoa :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ngaysp
            // 
            this.ngaysp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngaysp.Enabled = false;
            this.ngaysp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngaysp.Location = new System.Drawing.Point(171, 3);
            this.ngaysp.Mask = "##/##/####";
            this.ngaysp.MaxLength = 10;
            this.ngaysp.Name = "ngaysp";
            this.ngaysp.Size = new System.Drawing.Size(64, 21);
            this.ngaysp.TabIndex = 2;
            this.ngaysp.Text = "  /  /    ";
            this.ngaysp.Validated += new System.EventHandler(this.ngaysp_Validated);
            // 
            // phieu
            // 
            this.phieu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.phieu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.phieu.Enabled = false;
            this.phieu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phieu.Location = new System.Drawing.Point(272, 3);
            this.phieu.Name = "phieu";
            this.phieu.Size = new System.Drawing.Size(104, 21);
            this.phieu.TabIndex = 3;
            this.phieu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.phieu_KeyDown);
            // 
            // listDMBD
            // 
            this.listDMBD.BackColor = System.Drawing.SystemColors.Info;
            this.listDMBD.ColumnCount = 0;
            this.listDMBD.Location = new System.Drawing.Point(376, 569);
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
            // lMabd
            // 
            this.lMabd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lMabd.Location = new System.Drawing.Point(129, 440);
            this.lMabd.Name = "lMabd";
            this.lMabd.Size = new System.Drawing.Size(32, 23);
            this.lMabd.TabIndex = 28;
            this.lMabd.Text = "Mã :";
            this.lMabd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lTen
            // 
            this.lTen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lTen.Location = new System.Drawing.Point(205, 440);
            this.lTen.Name = "lTen";
            this.lTen.Size = new System.Drawing.Size(37, 23);
            this.lTen.TabIndex = 29;
            this.lTen.Text = "Tên :";
            this.lTen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ldvt
            // 
            this.ldvt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ldvt.Location = new System.Drawing.Point(8, 463);
            this.ldvt.Name = "ldvt";
            this.ldvt.Size = new System.Drawing.Size(48, 23);
            this.ldvt.TabIndex = 30;
            this.ldvt.Text = "ĐVT :";
            this.ldvt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label16.Location = new System.Drawing.Point(187, 462);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(56, 23);
            this.label16.TabIndex = 31;
            this.label16.Text = "Số lượng :";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label17.Location = new System.Drawing.Point(336, 462);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(56, 23);
            this.label17.TabIndex = 32;
            this.label17.Text = "Đơn giá :";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label18.Location = new System.Drawing.Point(487, 462);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(56, 23);
            this.label18.TabIndex = 33;
            this.label18.Text = "Số tiền :";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label20.Location = new System.Drawing.Point(-8, 486);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(64, 23);
            this.label20.TabIndex = 35;
            this.label20.Text = "Nguồn :";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tenbd
            // 
            this.tenbd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tenbd.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbd.Enabled = false;
            this.tenbd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbd.Location = new System.Drawing.Point(242, 440);
            this.tenbd.Name = "tenbd";
            this.tenbd.Size = new System.Drawing.Size(238, 21);
            this.tenbd.TabIndex = 9;
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
            this.mabd.Location = new System.Drawing.Point(160, 440);
            this.mabd.Name = "mabd";
            this.mabd.Size = new System.Drawing.Size(52, 21);
            this.mabd.TabIndex = 8;
            this.mabd.Validated += new System.EventHandler(this.mabd_Validated);
            this.mabd.TextChanged += new System.EventHandler(this.mabd_TextChanged);
            this.mabd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabd_KeyDown);
            // 
            // dang
            // 
            this.dang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dang.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dang.Enabled = false;
            this.dang.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dang.Location = new System.Drawing.Point(56, 463);
            this.dang.Mask = "";
            this.dang.MaxLength = 10;
            this.dang.Name = "dang";
            this.dang.Size = new System.Drawing.Size(120, 21);
            this.dang.TabIndex = 11;
            // 
            // soluong
            // 
            this.soluong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.soluong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.soluong.Enabled = false;
            this.soluong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.soluong.Location = new System.Drawing.Point(242, 463);
            this.soluong.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
            this.soluong.Name = "soluong";
            this.soluong.Size = new System.Drawing.Size(94, 21);
            this.soluong.TabIndex = 12;
            this.soluong.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.soluong.Validated += new System.EventHandler(this.soluong_Validated);
            // 
            // dongia
            // 
            this.dongia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dongia.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dongia.Enabled = false;
            this.dongia.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dongia.Location = new System.Drawing.Point(391, 463);
            this.dongia.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.dongia.Name = "dongia";
            this.dongia.Size = new System.Drawing.Size(89, 21);
            this.dongia.TabIndex = 13;
            this.dongia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // sotien
            // 
            this.sotien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.sotien.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sotien.Enabled = false;
            this.sotien.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sotien.Location = new System.Drawing.Point(544, 463);
            this.sotien.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.sotien.Name = "sotien";
            this.sotien.Size = new System.Drawing.Size(104, 21);
            this.sotien.TabIndex = 14;
            this.sotien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // butMoi
            // 
            this.butMoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butMoi.Image = global::Duoc.Properties.Resources.add;
            this.butMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMoi.Location = new System.Drawing.Point(104, 515);
            this.butMoi.Name = "butMoi";
            this.butMoi.Size = new System.Drawing.Size(70, 25);
            this.butMoi.TabIndex = 24;
            this.butMoi.Text = "     &Mới";
            this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
            // 
            // butSua
            // 
            this.butSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butSua.Image = global::Duoc.Properties.Resources.quick_edit;
            this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.Location = new System.Drawing.Point(174, 515);
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
            this.butLuu.Location = new System.Drawing.Point(244, 515);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 22;
            this.butLuu.Text = "     &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butThem
            // 
            this.butThem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butThem.Enabled = false;
            this.butThem.Image = global::Duoc.Properties.Resources.plus;
            this.butThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butThem.Location = new System.Drawing.Point(314, 515);
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
            this.butXoa.Location = new System.Drawing.Point(384, 515);
            this.butXoa.Name = "butXoa";
            this.butXoa.Size = new System.Drawing.Size(70, 25);
            this.butXoa.TabIndex = 21;
            this.butXoa.Text = "      &Xóa";
            this.butXoa.Click += new System.EventHandler(this.butXoa_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butBoqua.Enabled = false;
            this.butBoqua.Image = global::Duoc.Properties.Resources.undo_ok;
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(454, 515);
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
            this.butHuy.Location = new System.Drawing.Point(524, 515);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(70, 25);
            this.butHuy.TabIndex = 26;
            this.butHuy.Text = "     &Hủy";
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // butIn
            // 
            this.butIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butIn.Image = global::Duoc.Properties.Resources.Print1;
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(594, 515);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 27;
            this.butIn.Text = "     &In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butKetthuc.Image = global::Duoc.Properties.Resources.close_r;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(664, 515);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 28;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // cmbSophieu
            // 
            this.cmbSophieu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSophieu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSophieu.Location = new System.Drawing.Point(55, 3);
            this.cmbSophieu.Name = "cmbSophieu";
            this.cmbSophieu.Size = new System.Drawing.Size(81, 21);
            this.cmbSophieu.TabIndex = 0;
            this.cmbSophieu.SelectedIndexChanged += new System.EventHandler(this.cmbSophieu_SelectedIndexChanged);
            this.cmbSophieu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbSophieu_KeyDown);
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label15.Location = new System.Drawing.Point(482, 486);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(61, 23);
            this.label15.TabIndex = 61;
            this.label15.Text = "Hạn dùng :";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label24
            // 
            this.label24.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label24.Location = new System.Drawing.Point(610, 486);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(80, 23);
            this.label24.TabIndex = 62;
            this.label24.Text = "Lô sản xuất :";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // handung
            // 
            this.handung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.handung.BackColor = System.Drawing.SystemColors.HighlightText;
            this.handung.Enabled = false;
            this.handung.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.handung.Location = new System.Drawing.Point(544, 486);
            this.handung.Mask = "####";
            this.handung.Name = "handung";
            this.handung.Size = new System.Drawing.Size(40, 21);
            this.handung.TabIndex = 18;
            this.handung.Text = "    ";
            // 
            // losx
            // 
            this.losx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.losx.BackColor = System.Drawing.SystemColors.HighlightText;
            this.losx.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.losx.Enabled = false;
            this.losx.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.losx.Location = new System.Drawing.Point(688, 486);
            this.losx.Mask = "&&&&&&&&&&";
            this.losx.MaxLength = 10;
            this.losx.Name = "losx";
            this.losx.Size = new System.Drawing.Size(96, 21);
            this.losx.TabIndex = 19;
            this.losx.Text = "          ";
            // 
            // tenhc
            // 
            this.tenhc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tenhc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenhc.Enabled = false;
            this.tenhc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenhc.Location = new System.Drawing.Point(544, 440);
            this.tenhc.Name = "tenhc";
            this.tenhc.Size = new System.Drawing.Size(240, 21);
            this.tenhc.TabIndex = 10;
            // 
            // lTenhc
            // 
            this.lTenhc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lTenhc.Location = new System.Drawing.Point(482, 439);
            this.lTenhc.Name = "lTenhc";
            this.lTenhc.Size = new System.Drawing.Size(60, 23);
            this.lTenhc.TabIndex = 64;
            this.lTenhc.Text = "Hoạt chất :";
            this.lTenhc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sophieu
            // 
            this.sophieu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sophieu.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.sophieu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sophieu.Location = new System.Drawing.Point(55, 3);
            this.sophieu.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.sophieu.MaxLength = 8;
            this.sophieu.Name = "sophieu";
            this.sophieu.Size = new System.Drawing.Size(81, 21);
            this.sophieu.TabIndex = 1;
            this.sophieu.Validated += new System.EventHandler(this.sophieu_Validated);
            // 
            // giaban
            // 
            this.giaban.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.giaban.BackColor = System.Drawing.SystemColors.HighlightText;
            this.giaban.Enabled = false;
            this.giaban.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.giaban.Location = new System.Drawing.Point(391, 486);
            this.giaban.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.giaban.Name = "giaban";
            this.giaban.Size = new System.Drawing.Size(89, 21);
            this.giaban.TabIndex = 17;
            this.giaban.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label25
            // 
            this.label25.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label25.Location = new System.Drawing.Point(336, 486);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(56, 23);
            this.label25.TabIndex = 66;
            this.label25.Text = "Giá bán :";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.dataGrid1.HeaderFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.dataGrid1.HeaderForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.LinkColor = System.Drawing.Color.Teal;
            this.dataGrid1.Location = new System.Drawing.Point(8, 8);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(776, 429);
            this.dataGrid1.TabIndex = 27;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.Location = new System.Drawing.Point(172, 486);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 23);
            this.label3.TabIndex = 67;
            this.label3.Text = "Nhà CC :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // manguon
            // 
            this.manguon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.manguon.BackColor = System.Drawing.SystemColors.HighlightText;
            this.manguon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.manguon.Enabled = false;
            this.manguon.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manguon.Location = new System.Drawing.Point(56, 486);
            this.manguon.Name = "manguon";
            this.manguon.Size = new System.Drawing.Size(120, 21);
            this.manguon.TabIndex = 15;
            // 
            // nhomcc
            // 
            this.nhomcc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nhomcc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nhomcc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nhomcc.Enabled = false;
            this.nhomcc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhomcc.Location = new System.Drawing.Point(242, 486);
            this.nhomcc.Name = "nhomcc";
            this.nhomcc.Size = new System.Drawing.Size(94, 21);
            this.nhomcc.TabIndex = 16;
            // 
            // stt
            // 
            this.stt.Location = new System.Drawing.Point(32, 371);
            this.stt.Name = "stt";
            this.stt.Size = new System.Drawing.Size(24, 20);
            this.stt.TabIndex = 68;
            // 
            // sttt
            // 
            this.sttt.Location = new System.Drawing.Point(64, 371);
            this.sttt.Name = "sttt";
            this.sttt.Size = new System.Drawing.Size(24, 20);
            this.sttt.TabIndex = 69;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.Location = new System.Drawing.Point(-4, 440);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 23);
            this.label4.TabIndex = 70;
            this.label4.Text = "Đối tượng :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // madoituong
            // 
            this.madoituong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.madoituong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.madoituong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.madoituong.Enabled = false;
            this.madoituong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madoituong.Location = new System.Drawing.Point(56, 440);
            this.madoituong.Name = "madoituong";
            this.madoituong.Size = new System.Drawing.Size(80, 21);
            this.madoituong.TabIndex = 7;
            this.madoituong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.madoituong_KeyDown);
            // 
            // makp
            // 
            this.makp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.makp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.makp.Enabled = false;
            this.makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makp.Location = new System.Drawing.Point(413, 3);
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(40, 21);
            this.makp.TabIndex = 4;
            this.makp.Validated += new System.EventHandler(this.makp_Validated);
            this.makp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.makp_KeyDown);
            // 
            // tenkp
            // 
            this.tenkp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenkp.Enabled = false;
            this.tenkp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenkp.Location = new System.Drawing.Point(454, 3);
            this.tenkp.Name = "tenkp";
            this.tenkp.Size = new System.Drawing.Size(111, 21);
            this.tenkp.TabIndex = 5;
            this.tenkp.Validated += new System.EventHandler(this.tenkp_Validated);
            this.tenkp.TextChanged += new System.EventHandler(this.tenkp_TextChanged);
            this.tenkp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenkp_KeyDown);
            // 
            // listDuockp
            // 
            this.listDuockp.BackColor = System.Drawing.SystemColors.Info;
            this.listDuockp.ColumnCount = 0;
            this.listDuockp.Location = new System.Drawing.Point(296, 569);
            this.listDuockp.MatchBufferTimeOut = 1000;
            this.listDuockp.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listDuockp.Name = "listDuockp";
            this.listDuockp.Size = new System.Drawing.Size(75, 17);
            this.listDuockp.TabIndex = 71;
            this.listDuockp.TextIndex = -1;
            this.listDuockp.TextMember = null;
            this.listDuockp.ValueIndex = -1;
            this.listDuockp.Visible = false;
            this.listDuockp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listDuockp_KeyDown);
            // 
            // makho
            // 
            this.makho.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.makho.BackColor = System.Drawing.SystemColors.HighlightText;
            this.makho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.makho.Enabled = false;
            this.makho.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makho.Location = new System.Drawing.Point(688, 463);
            this.makho.Name = "makho";
            this.makho.Size = new System.Drawing.Size(96, 21);
            this.makho.TabIndex = 72;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.Location = new System.Drawing.Point(656, 462);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 23);
            this.label5.TabIndex = 73;
            this.label5.Text = "Kho :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // find
            // 
            this.find.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.find.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.find.Location = new System.Drawing.Point(728, 3);
            this.find.Name = "find";
            this.find.Size = new System.Drawing.Size(56, 21);
            this.find.TabIndex = 106;
            this.find.Text = "Tìm kiếm";
            this.find.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.find.Enter += new System.EventHandler(this.find_Enter);
            this.find.TextChanged += new System.EventHandler(this.find_TextChanged);
            // 
            // ghichu
            // 
            this.ghichu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ghichu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ghichu.Enabled = false;
            this.ghichu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ghichu.Location = new System.Drawing.Point(615, 3);
            this.ghichu.Name = "ghichu";
            this.ghichu.Size = new System.Drawing.Size(112, 21);
            this.ghichu.TabIndex = 6;
            this.ghichu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ghichu_KeyDown);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(571, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 23);
            this.label7.TabIndex = 112;
            this.label7.Text = "Ghi chú :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmXuatcstt
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.tenkp);
            this.Controls.Add(this.ghichu);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.find);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.makho);
            this.Controls.Add(this.listDuockp);
            this.Controls.Add(this.makp);
            this.Controls.Add(this.madoituong);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbSophieu);
            this.Controls.Add(this.sophieu);
            this.Controls.Add(this.ngaysp);
            this.Controls.Add(this.phieu);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nhomcc);
            this.Controls.Add(this.manguon);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.giaban);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.tenbd);
            this.Controls.Add(this.tenhc);
            this.Controls.Add(this.lTenhc);
            this.Controls.Add(this.losx);
            this.Controls.Add(this.handung);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.dang);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.butHuy);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butXoa);
            this.Controls.Add(this.butThem);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butSua);
            this.Controls.Add(this.butMoi);
            this.Controls.Add(this.soluong);
            this.Controls.Add(this.sotien);
            this.Controls.Add(this.dongia);
            this.Controls.Add(this.mabd);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.ldvt);
            this.Controls.Add(this.lTen);
            this.Controls.Add(this.lMabd);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.listDMBD);
            this.Controls.Add(this.stt);
            this.Controls.Add(this.sttt);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmXuatcstt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phiếu xuất tủ trực";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmXuatcstt_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmXuatcstt_Load(object sender, System.EventArgs e)
		{
            //if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            user = d.user; xxx = user + s_mmyy;
			bPhattron=d.bPhattron(i_nhom);
            if (bPhattron) format_soluong="###,###,##0";
			else format_soluong=d.format_soluong(i_nhom);
			format_sotien=d.format_sotien(i_nhom);
			format_dongia=d.format_dongia(i_nhom);
			bKhoaso=d.bKhoaso(i_nhom,s_mmyy);
			i_songay=d.Ngaylv_Ngayht;
			s_makho=d.get_dmkho(i_loai).Trim();
			s_makho=(s_makho=="")?"":s_makho.Substring(0,s_makho.Length-1);
			s_manguon=d.get_manguon(i_loai).Trim();
			s_manguon=(s_manguon=="")?"":s_manguon.Substring(0,s_manguon.Length-1);

			manguon.DisplayMember="TEN";
			manguon.ValueMember="ID";
			if (d.bQuanlynguon(i_nhom))
				manguon.DataSource=d.get_data("select * from "+user+".d_dmnguon where nhom="+i_nhom+" order by stt").Tables[0];
			else
                manguon.DataSource = d.get_data("select * from " + user + ".d_dmnguon where id=0 or nhom=" + i_nhom + " order by stt").Tables[0];

			nhomcc.DisplayMember="TEN";
			nhomcc.ValueMember="ID";
			if (d.bQuanlynhomcc(i_nhom))
                nhomcc.DataSource = d.get_data("select * from " + user + ".d_dmnx where nhom=" + i_nhom + " order by stt").Tables[0];
			else
                nhomcc.DataSource = d.get_data("select * from " + user + ".d_dmnx where id=0 or nhom=" + i_nhom + " order by stt").Tables[0];

			phieu.DisplayMember="TEN";
			phieu.ValueMember="ID";
            phieu.DataSource = d.get_data("select * from " + user + ".d_loaiphieu where nhom="+i_nhom+" and loai=" + i_loai + " order by stt").Tables[0];

			makho.DisplayMember="TEN";
			makho.ValueMember="ID";
            sql = "select * from " + user + ".d_dmkho where hide=0 and nhom=" + i_nhom;
			if (s_kho!="") sql+=" and id in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			sql+=" order by stt";
			makho.DataSource=d.get_data(sql).Tables[0];

            dtdoituong = d.get_data("select * from " + user + ".d_doituong order by madoituong").Tables[0];
			madoituong.DisplayMember="DOITUONG";
			madoituong.ValueMember="MADOITUONG";
			madoituong.DataSource=dtdoituong;

			listDMBD.DisplayMember="TEN";
			listDMBD.ValueMember="STT";

			listDuockp.DisplayMember="MA";
			listDuockp.ValueMember="TEN";
            sql = "select ma,ten,id,nguoilinh from " + user + ".d_duockp where nhom like '%" + i_nhom.ToString() + ",%'";
			if (s_makp!="") sql+=" and id in ("+s_makp.Substring(0,s_makp.Length-1)+")";
			sql+=" order by stt";
			dtduockp=d.get_data(sql).Tables[0];
			listDuockp.DataSource=dtduockp;
			//load_dm();
            sql = "select id,mabn,to_char(ngay,'dd/mm/yyyy') as ngay,phieu,makp,idduyet,makhoa,ghichu from " + xxx + ".d_xuatsdll where maql=0 and loai=" + i_loai;
			if (!bAdmin) sql+=" and userid="+i_userid;
			sql+=" and nhom="+i_nhom;
			if (d.bLocxuatcstt) sql+=" and to_char(ngay,'dd/mm/yyyy')='"+s_ngay+"'";
			sql+=" order by id";
			dtll=d.get_data(sql).Tables[0];
			cmbSophieu.DisplayMember="MABN";
			cmbSophieu.ValueMember="ID";
			cmbSophieu.DataSource=dtll;
			if (cmbSophieu.Items.Count>0) l_id=decimal.Parse(cmbSophieu.SelectedValue.ToString());
			else l_id=0;
			load_head();
			//load_grid();
			AddGridTableStyle();
			//ref_text();
			dsxoa.ReadXml("..\\..\\..\\xml\\d_xuatsdct.xml");
            try
            {
                dsxoa.Tables[0].Columns.Add("gia_bh", typeof(decimal)).DefaultValue = 0;
            }
            catch { }
		}

		private void load_grid()
		{
			dataGrid1.DataSource=null;
			sql="select a.stt,a.sttt,e.doituong,a.mabd,b.ma,trim(b.ten)||' '||b.hamluong as ten,b.tenhc,b.dang,f.ten as tenkho,c.ten as tennguon,d.ten as tennhomcc,t.handung,t.losx,a.soluong,t.giamua as dongia,a.soluong*t.giamua as sotien,t.giaban,a.madoituong,a.makho,t.manguon,t.nhomcc,'xx/xx/xxxx' as ngay,a.sttduyet,0 as tutruc,t.giamua, a.gia_bh ";
            sql += " from " + xxx + ".d_xuatsdct a," + user + ".d_dmbd b," + user + ".d_dmnguon c," + user + ".d_dmnx d," + user + ".d_doituong e," + user + ".d_dmkho f," + xxx + ".d_theodoi t where a.sttt=t.id and a.mabd=b.id and t.manguon=c.id and t.nhomcc=d.id and a.madoituong=e.madoituong and a.makho=f.id and a.id=" + l_id + " order by a.stt";
			dtct=d.get_data(sql).Tables[0];
			dataGrid1.DataSource=dtct;
		}

		private void ref_text()
		{
			try
			{
				int i=dataGrid1.CurrentCell.RowNumber;
				stt.Text=dataGrid1[i,0].ToString();
				mabd.Text=dataGrid1[i,2].ToString();
				tenbd.Text=dataGrid1[i,3].ToString();
				tenhc.Text=dataGrid1[i,4].ToString();
				dang.Text=dataGrid1[i,5].ToString();
				handung.Text=dataGrid1[i,9].ToString();
				losx.Text=dataGrid1[i,10].ToString();
				d_soluong=(dataGrid1[i,11].ToString()!="")?decimal.Parse(dataGrid1[i,11].ToString()):0;
				d_dongia=(dataGrid1[i,12].ToString()!="")?decimal.Parse(dataGrid1[i,12].ToString()):0;
				d_sotien=(dataGrid1[i,13].ToString()!="")?decimal.Parse(dataGrid1[i,13].ToString()):0;
				d_giaban=(dataGrid1[i,14].ToString()!="")?decimal.Parse(dataGrid1[i,14].ToString()):0;
                d_gia_bh = (dataGrid1[i, 20].ToString() != "") ? decimal.Parse(dataGrid1[i, 20].ToString()) : 0;
				soluong.Text=d_soluong.ToString(format_soluong);
				dongia.Text=d_dongia.ToString(format_dongia);
				sotien.Text=d_sotien.ToString(format_sotien);
				giaban.Text=d_giaban.ToString("#,###,###,##0");
                giaban.Tag = d_gia_bh.ToString("#,###,###,##0");
				madoituong.SelectedValue=dataGrid1[i,15].ToString();
				makho.SelectedValue=dataGrid1[i,16].ToString();
				manguon.SelectedValue=dataGrid1[i,17].ToString();
				nhomcc.SelectedValue=dataGrid1[i,18].ToString();
				sttt.Text=dataGrid1[i,19].ToString();
                d_soluongcu = (bNew) ? 0 : d_soluong;
				if (butLuu.Enabled)
				{
					tenbd.Enabled=sttt.Text=="0";
					if (d.bNhapmaso) mabd.Enabled=tenbd.Enabled;
					soluong.Enabled=tenbd.Enabled;
				}
			}
			catch{}
		}

		private void AddGridTableStyle()
		{
			DataGridTableStyle ts =new DataGridTableStyle();
			ts.MappingName = dtct.TableName;
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
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "doituong";
			TextCol.HeaderText = "Đối tượng";
			TextCol.Width = 60;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "ma";
			TextCol.HeaderText = "Mã số";
			TextCol.Width = 50;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "ten";
			TextCol.HeaderText = "Tên";
			TextCol.Width = (bGiaban)?200:230;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tenhc";
			TextCol.HeaderText = "Hoạt chất";
			TextCol.Width = (d.bHoatchat)?200:0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "dang";
			TextCol.HeaderText = "ĐVT";
			TextCol.Width = 50;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tenkho";
			TextCol.HeaderText = "Kho xuất";
			TextCol.Width = 70;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tennguon";
			TextCol.HeaderText = "Nguồn";
			TextCol.Width = (d.bQuanlynguon(i_nhom))?80:0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tennhomcc";
            TextCol.HeaderText = "Nhà cung cấp";
			TextCol.Width = (d.bQuanlynhomcc(i_nhom))?90:0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "handung";
			TextCol.HeaderText = "Date";
			TextCol.Width = (d.bQuanlyhandung(i_nhom))?30:0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "losx";
			TextCol.HeaderText = "Lô SX";
			TextCol.Width = (d.bQuanlylosx(i_nhom))?50:0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "soluong";
			TextCol.HeaderText = "Số lượng";
			TextCol.Width = 70;
			TextCol.Format=format_soluong;
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "dongia";
			TextCol.HeaderText = "Đơn giá";
			TextCol.Width = 80;
			TextCol.Format=format_dongia;
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "sotien";
			TextCol.HeaderText = "Số tiền";
			TextCol.Width = 100;
			TextCol.Format=format_sotien;
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();//c14
			TextCol.MappingName = "giaban";
			TextCol.HeaderText = (bGiaban)?"Giá bán":"";
			TextCol.Width = (bGiaban)?80:0;
			TextCol.Format="###,###,###,##0";
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "madoituong";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "makho";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "manguon";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "nhomcc";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "sttt";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "gia_bh";
            TextCol.HeaderText = "";
            TextCol.Width = 0;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);
		}

		private void sophieu_Validated(object sender, System.EventArgs e)
		{
			if (l_id!=0) return;
			try
			{
				r=d.getrowbyid(dtll,"mabn='"+sophieu.Text+"'");
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
					l_idduyet=decimal.Parse(r["idduyet"].ToString());
					sophieu.Text=r["mabn"].ToString();
					ngaysp.Text=r["ngay"].ToString();
					ghichu.Text=r["ghichu"].ToString();
					i_makp=int.Parse(r["makp"].ToString());
					DataRow r1=d.getrowbyid(dtduockp,"id="+i_makp);
					if (r1!=null)
					{
						makp.Text=r1["ma"].ToString();
						tenkp.Text=r1["ten"].ToString();
					}
					phieu.SelectedValue=r["phieu"].ToString();
					s_ngaysp=ngaysp.Text;
				}
			}
			catch{l_id=0;}
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
				sql="(soluong>0) and (ten like '%"+ten.Trim()+"%'"+" or tenhc like '%"+ten.Trim()+"%')";
				if (madoituong.SelectedIndex!=-1) if (madoituong.SelectedValue.ToString()=="1") sql+=" and (bhyt<>0)";
				if (madoituong.SelectedIndex!=-1)
				{
					s_nguon_doituong=dtdoituong.Rows[madoituong.SelectedIndex]["nguon"].ToString().Trim();
					s_nguon_doituong=(s_nguon_doituong!="")?s_nguon_doituong.Substring(0,s_nguon_doituong.Length-1):"";
					if (s_nguon_doituong!="") sql+=" and manguon in ("+s_nguon_doituong+")";
				}
				dv.RowFilter=sql;
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
		}

		private void ena_object(bool ena)
		{
			find.Enabled=!ena;
			sophieu.Visible=ena;
			cmbSophieu.Visible=!ena;
			sophieu.Enabled=ena;
			ghichu.Enabled=ena;
			//ngaysp.Enabled=ena;
			makp.Enabled=ena;
			tenkp.Enabled=ena;
			phieu.Enabled=ena;
			if (i_thuoc==1) madoituong.Enabled=ena;
			if (d.bNhapmaso) mabd.Enabled=ena;
			tenbd.Enabled=ena;
			soluong.Enabled=ena;
			butMoi.Enabled=!ena;
			butSua.Enabled=!ena;
			butThem.Enabled=ena;
			butXoa.Enabled=ena;
			butLuu.Enabled=ena;
			butBoqua.Enabled=ena;
			butHuy.Enabled=!ena;
			butIn.Enabled=!ena;
			butKetthuc.Enabled=!ena;
			i_old=cmbSophieu.SelectedIndex;
            //if (!ena)
            //{
            find.Text = "";
                CurrencyManager cm = (CurrencyManager)BindingContext[cmbSophieu.DataSource];
                DataView dv = (DataView)cm.List;
                dv.RowFilter = "";
            //}
        }

		private void emp_head()
		{
			l_idduyet=0;
			l_id=0;
			i_makp=0;
			sophieu.Text="";
			ghichu.Text="";
			ngaysp.Text=s_ngay;
			s_ngaysp=ngaysp.Text;
			makp.Text="";
			tenkp.Text="";
            //find.Text = "";
            //CurrencyManager cm = (CurrencyManager)BindingContext[cmbSophieu.DataSource];
            //DataView dv = (DataView)cm.List;
            //dv.RowFilter = "";
			dsxoa.Clear();
		}
		
		private void emp_detail()
		{
			sttt.Text="";
			stt.Text="";
			mabd.Text="";
			tenbd.Text="";
			tenhc.Text="";
			dang.Text="";
			soluong.Text="0";
			dongia.Text="0";
			sotien.Text="0";
			handung.Text="";
			losx.Text="";
			giaban.Text="0";
            giaban.Tag = "0";
			manguon.SelectedIndex=-1;
			nhomcc.SelectedIndex=-1;
			makho.SelectedIndex=-1;
			stt.Text=d.get_stt(dtct).ToString();
			d_soluongcu=0;
			if (i_thuoc==2) madoituong.SelectedValue=d.iHaophi.ToString();
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
			dtct.Clear();
			dtsave.Clear();
			emp_head();
			emp_detail();
			bNew=true;
			bEdit=true;
			if (i_thuoc==1) madoituong.SelectedIndex=-1;
			else madoituong.SelectedValue=d.iHaophi.ToString();
			sophieu.Focus();
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
			ena_object(true);
			bNew=false;
			bEdit=true;
			makp.Enabled=bNew;
			tenkp.Enabled=bNew;
			load_dm();
			dtsave=dtct.Copy();
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
			if (phieu.SelectedIndex==-1)
			{
				MessageBox.Show(
lan.Change_language_MessageText("Nhập phiếu !"),d.Msg);
				phieu.Focus();
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
			r=d.getrowbyid(dtton,"ma='"+mabd.Text+"'");
			if (r==null)
			{
				MessageBox.Show(
lan.Change_language_MessageText("Mã số không hợp lệ !"),d.Msg);
				if (mabd.Enabled) mabd.Focus();
				else tenbd.Focus();
				return false;
			}
			i_mabd=int.Parse(r["id"].ToString());
			if (soluong.Text=="" || soluong.Text=="0.00" || soluong.Text=="0")
			{
				MessageBox.Show(
lan.Change_language_MessageText("Nhập số lượng !"),d.Msg);
				soluong.Focus();
				return false;
			}
			if (madoituong.SelectedIndex==-1)
			{
				MessageBox.Show(
lan.Change_language_MessageText("Chọn đối tượng !"),d.Msg);
				madoituong.Focus();
				return false;
			}
			makp.Enabled=false;
			tenkp.Enabled=makp.Enabled;
			return true;
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			bEdit=false;
			cmbSophieu.SelectedIndex=i_old;
			if (cmbSophieu.Items.Count>0) l_id=decimal.Parse(cmbSophieu.SelectedValue.ToString());
			else l_id=0;
			load_head();
			ena_object(false);
			butMoi.Focus();
		}

		private void ngaysp_Validated(object sender, System.EventArgs e)
		{
			if (ngaysp.Text=="") return;
			ngaysp.Text=ngaysp.Text.Trim();
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
			SendKeys.Send("{F4}");
		}

		private void butThem_Click(object sender, System.EventArgs e)
		{
			if (d.bNhapmaso) mabd.Enabled=true;
			tenbd.Enabled=true;
			soluong.Enabled=true;
			if (!upd_table(dtct,"-")) return;
			emp_detail();
			if (i_thuoc==1)
			{
				madoituong.Focus();
				SendKeys.Send("{F4}");
			}
			else mabd.Focus();
		}

		private void butXoa_Click(object sender, System.EventArgs e)
		{
			if (!upd_table(dsxoa.Tables[0],"+")) return;
			d.delrec(dtct,"stt="+int.Parse(stt.Text));
			dtct.AcceptChanges();
			if (dtct.Rows.Count==0) emp_detail();
			else ref_text();
		}

		private bool upd_table(DataTable dt,string tt)
		{
			if (!KiemtraDetail()) return false;
			d_soluong=(soluong.Text!="")?decimal.Parse(soluong.Text):0;
			d_dongia=(dongia.Text!="")?decimal.Parse(dongia.Text):0;
			d_sotien=(sotien.Text!="")?decimal.Parse(sotien.Text):0;
			d_giaban=(giaban.Text!="")?decimal.Parse(giaban.Text):0;
            d_gia_bh = (giaban.Tag.ToString() != "") ? decimal.Parse(giaban.Tag.ToString()) : 0;
			l_sttt=(sttt.Text!="")?decimal.Parse(sttt.Text):0;
			d.updrec_xuatsdct(tt,dt,int.Parse(stt.Text),l_sttt,madoituong.Text,i_mabd,mabd.Text,tenbd.Text,tenhc.Text,dang.Text,makho.Text,(manguon.SelectedIndex==-1)?"":manguon.Text,(nhomcc.SelectedIndex==-1)?"":nhomcc.Text,handung.Text,losx.Text,d_soluong,d_dongia,d_sotien,d_giaban,d_dongia,int.Parse(madoituong.SelectedValue.ToString()),int.Parse(makho.SelectedValue.ToString()),(manguon.SelectedIndex==-1)?0:int.Parse(manguon.SelectedValue.ToString()),(nhomcc.SelectedIndex==-1)?0:int.Parse(nhomcc.SelectedValue.ToString()),ngaysp.Text,int.Parse(stt.Text),0,dtton, d_gia_bh);
			return true;
		}

		private void mabd_Validated(object sender, System.EventArgs e)
		{
			if(!listDMBD.Focused) listDMBD.Hide();
		}

		private void listDMBD_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				try
				{
					r=d.getrowbyid(dtton,"stt="+int.Parse(mabd.Text));
					if (r!=null)
					{
						mabd.Text=r["ma"].ToString();
						tenbd.Text=r["ten"].ToString();
						tenhc.Text=r["tenhc"].ToString();
						dang.Text=r["dang"].ToString();
						makho.SelectedValue=r["makho"].ToString();
						manguon.SelectedValue=r["manguon"].ToString();
					}
				}
				catch{}
			}
		}

		private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			ref_text();
		}

		private void tinh_giatri()
		{
			try
			{
				d_soluong=(soluong.Text!="")?decimal.Parse(soluong.Text):0;
				d_dongia=(dongia.Text!="")?decimal.Parse(dongia.Text):0;
				d_sotien=Math.Round(d_dongia*d_soluong,3);
				sotien.Text=d_sotien.ToString(format_sotien);
			}
			catch{}
		}

		private void soluong_Validated(object sender, System.EventArgs e)
		{
			try
			{
				if (!bEdit) return;
				d_soluong=(soluong.Text!="")?decimal.Parse(soluong.Text):0;
				soluong.Text=d_soluong.ToString(format_soluong);
				if (mabd.Text!="" && tenbd.Text!="")
				{
					r=d.getrowbyid(dtton,"ma='"+mabd.Text+"'");
					if (r!=null)
					{
						i_mabd=int.Parse(r["id"].ToString());
						d_soluongton=d.get_slton_nguon(dtton,int.Parse(makho.SelectedValue.ToString()),i_mabd,int.Parse(manguon.SelectedValue.ToString()),d_soluongcu);
						if (d_soluong>d_soluongton)
						{
							MessageBox.Show(
lan.Change_language_MessageText("Số lượng xuất lớn hơn số lượng tồn !(")+d_soluongton.ToString()+")",d.Msg);
							soluong.Focus();
							return;
						}
					}
				}
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
lan.Change_language_MessageText("đã khóa !")+"\n"+
lan.Change_language_MessageText("Nếu cần thay đổi thì vào mục khai báo hệ thống"),d.Msg);
					return;
				}
				if (MessageBox.Show(
lan.Change_language_MessageText("Đồng ý hủy số phiếu này ?"),d.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
				{
                    itable = d.tableid(s_mmyy, "d_thucxuat");
                    foreach (DataRow r1 in dtct.Rows)
                    {
                        d.upd_eve_tables(s_mmyy, itable, i_userid, "del");
                        d.upd_eve_upd_del(s_mmyy, itable, i_userid, "del", d.fields(xxx + ".d_thucxuat", "id=" + l_id + " and stt=" + int.Parse(r1["stt"].ToString())));
                        d.upd_tonkhoct_thucxuat(d.delete, s_mmyy, i_makp, i_loai, i_thuoc, decimal.Parse(r1["sttt"].ToString()), int.Parse(r1["makho"].ToString()), int.Parse(r1["manguon"].ToString()), int.Parse(r1["mabd"].ToString()), decimal.Parse(r1["soluong"].ToString()));
                    }
                    itable = d.tableid(s_mmyy, "d_xuatsdll");
                    d.upd_eve_tables(s_mmyy, itable, i_userid, "del");
                    d.upd_eve_upd_del(s_mmyy, itable, i_userid, "del", d.fields(xxx + ".d_xuatsdll", "id=" + l_id));
					d.execute_data("delete from "+xxx+".d_xuatsdct where id="+l_id);
                    d.execute_data("delete from " + xxx + ".d_thucxuat where id=" + l_id);
                    d.execute_data("delete from " + xxx + ".d_xuatsdll where id=" + l_id);
					d.delrec(dtll,"id="+l_id);
					cmbSophieu.Refresh();
					if (cmbSophieu.Items.Count>0) l_id=decimal.Parse(cmbSophieu.SelectedValue.ToString());
					else l_id=0;
					load_head();
				}
			}
			catch{}
		}

		private void load_dm()
		{
			if (i_makp==0 || tenkp.Enabled)
			{
				if (makp.Text=="" && tenkp.Text=="")
				{
					MessageBox.Show(
lan.Change_language_MessageText("Chọn khoa !"),d.Msg);
					makp.Focus();
					return;
				}
				if ((makp.Text!="" && tenkp.Text=="") || (makp.Text=="" && tenkp.Text!=""))
				{
					if (makp.Text=="")
					{
						makp.Focus();
						return;
					}
					else if (tenkp.Text=="")
					{
						tenkp.Focus();
						return;
					}
				}
				i_makp=0;
				r=d.getrowbyid(dtduockp,"ma='"+makp.Text+"'");
				if (r==null)
				{
					MessageBox.Show(
lan.Change_language_MessageText("Khoa không hợp lệ !"),d.Msg);
					makp.Focus();
					return;
				}
				i_makp=int.Parse(r["id"].ToString());
			}
			dtton=d.get_tutructh(s_mmyy,i_makp,s_makho,s_kho,s_manguon,i_thuoc);
			listDMBD.DataSource=dtton;
		}
		private void load_tonct()
		{
			dttonct=d.get_tutrucct(s_mmyy,i_makp,s_makho,s_kho,s_manguon,i_thuoc,i_nhom);
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			if (!KiemtraHead()) return;
			bEdit=false;
			upd_table(dtct,"-");
			dtct.AcceptChanges();
			i_old=(bNew)?0:1;
			l_id=(bNew)?d.get_id_xuatsd:l_id;
            itable = d.tableid(s_mmyy, "d_xuatsdll");
            if (bNew) d.upd_eve_tables(s_mmyy, itable, i_userid, "ins");
            else
            {
                d.upd_eve_tables(s_mmyy, itable, i_userid, "upd");
                d.upd_eve_upd_del(s_mmyy, itable, i_userid, "upd", l_id.ToString() + "^" + i_nhom.ToString() + "^" + sophieu.Text + "^" + "0" + "^" + "0" + "^" + "0" + "^" + ngaysp.Text + "^" + i_loai.ToString() + "^" + phieu.SelectedValue.ToString() + "^" + i_makp.ToString() + "^" + i_userid.ToString() + "^" + l_idduyet.ToString() + "^" + i_thuoc.ToString() + "^" + i_makp.ToString() + "^" + "0" + "^" + "0" + "^" + ghichu.Text);
            }
			if (!d.upd_xuatsdll(s_mmyy,l_id,i_nhom,sophieu.Text,0,0,0,ngaysp.Text,i_loai,int.Parse(phieu.SelectedValue.ToString()),i_makp,i_userid,l_idduyet,i_thuoc,i_makp,0,0,ghichu.Text,ngaysp.Text,0,""))
			{
				MessageBox.Show(
lan.Change_language_MessageText("Không cập nhật được thông tin phiếu lĩnh !"),d.Msg);
				return;
			}
            itable = d.tableid(s_mmyy, "d_thucxuat");
			if (!bNew)
			{
				foreach(DataRow r1 in dsxoa.Tables[0].Rows)
				{
                    d.upd_eve_tables(s_mmyy, itable, i_userid, "del");
                    d.upd_eve_upd_del(s_mmyy, itable, i_userid, "del", d.fields(xxx + ".d_thucxuat", "id=" + l_id + " and stt=" + int.Parse(r1["stt"].ToString())));
					d.execute_data("delete from "+xxx+".d_xuatsdct where id="+l_id+" and stt="+decimal.Parse(r1["stt"].ToString()));
                    d.execute_data("delete from " + xxx + ".d_thucxuat where id=" + l_id + " and stt=" + decimal.Parse(r1["stt"].ToString()));
					d.upd_tonkhoct_thucxuat(d.delete,s_mmyy,i_makp,i_loai,i_thuoc,decimal.Parse(r1["sttt"].ToString()),int.Parse(r1["makho"].ToString()),int.Parse(r1["manguon"].ToString()),int.Parse(r1["mabd"].ToString()),decimal.Parse(r1["soluong"].ToString()));
				}
			}
			dtct=d.get_xuatsdct(s_mmyy,dtct,i_makp,i_loai,i_thuoc,l_id,ngaysp.Text,i_nhom);
			d.updrec_xuatsdll(dtll,l_id,sophieu.Text,ngaysp.Text,int.Parse(phieu.SelectedValue.ToString()),i_makp,l_idduyet,i_makp,ghichu.Text);
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
			load_grid();
			ref_text();
			ena_object(false);
			butMoi.Focus();
		}

		private void tongcong(DataTable dt)
		{
			d_tongcong=0;
			foreach(DataRow r1 in dt.Rows) d_tongcong+=decimal.Parse(r1["sotien"].ToString());
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			if (dtct.Rows.Count==0) return;
			tongcong(dtct);
			string s_tenkho=tenkp.Text,lydo="Sử dụng";
			if (d.bPreview)
			{
				frmReport f=new frmReport(d,dtct,i_userid,"d_phieuxuat.rpt",cmbSophieu.Text,ngaysp.Text,"","","",lydo,s_tenkho,doiso.Doiso_Unicode(Convert.ToInt64(d_tongcong).ToString()),"",ghichu.Text);
				f.ShowDialog();
			}
			else
			{
				ReportDocument oRpt=new ReportDocument();
				oRpt.Load("..\\..\\..\\report\\d_phieuxuat.rpt",OpenReportMethod.OpenReportByTempCopy);
				oRpt.SetDataSource(dtct);
				oRpt.DataDefinition.FormulaFields["soyte"].Text="'"+d.Syte+"'";
				oRpt.DataDefinition.FormulaFields["benhvien"].Text="'"+d.Tenbv+"'";
				oRpt.DataDefinition.FormulaFields["c1"].Text="'"+cmbSophieu.Text+"'";
				oRpt.DataDefinition.FormulaFields["c2"].Text="'"+ngaysp.Text+"'";
				oRpt.DataDefinition.FormulaFields["c3"].Text="";
				oRpt.DataDefinition.FormulaFields["c4"].Text="";
				oRpt.DataDefinition.FormulaFields["c5"].Text="";
				oRpt.DataDefinition.FormulaFields["c6"].Text="'"+lydo+"'";
				oRpt.DataDefinition.FormulaFields["c7"].Text="'"+s_tenkho+"'";
				oRpt.DataDefinition.FormulaFields["c8"].Text="'"+doiso.Doiso_Unicode(Convert.ToInt64(d_tongcong).ToString())+"'";
				oRpt.DataDefinition.FormulaFields["c9"].Text="";
				oRpt.DataDefinition.FormulaFields["c10"].Text="'"+ghichu.Text+"'";
				oRpt.DataDefinition.FormulaFields["giamdoc"].Text="'"+d.Giamdoc(i_nhom)+"'";
				oRpt.DataDefinition.FormulaFields["phutrach"].Text="'"+d.Phutrach(i_nhom)+"'";
				oRpt.DataDefinition.FormulaFields["thongke"].Text="'"+d.Thongke(i_nhom)+"'";
				oRpt.DataDefinition.FormulaFields["ketoan"].Text="'"+d.Ketoan(i_nhom)+"'";
				oRpt.DataDefinition.FormulaFields["thukho"].Text="'"+d.Thukho(i_nhom)+"'";
				oRpt.PrintOptions.PaperSize=PaperSize.PaperA4;
				oRpt.PrintOptions.PaperOrientation=PaperOrientation.Portrait;
				if (d.bPrintDialog)
				{
					result=Thongso();
					if (result==DialogResult.OK)
					{
						oRpt.PrintOptions.PrinterName=p.PrinterSettings.PrinterName;
						oRpt.PrintToPrinter(p.PrinterSettings.Copies,false,p.PrinterSettings.FromPage,p.PrinterSettings.ToPage);
					}
				}
				else oRpt.PrintToPrinter(1,false,0,0);
                oRpt.Close(); oRpt.Dispose();
			}
		}

		private void makp_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void makp_Validated(object sender, System.EventArgs e)
		{
			if (makp.Text!="")
			{
				r=d.getrowbyid(dtduockp,"ma='"+makp.Text+"'");
				if (r!=null) 
				{
					tenkp.Text=r["ten"].ToString();
					ghichu.Text=r["nguoilinh"].ToString();
					i_makp=int.Parse(r["id"].ToString());
					load_dm();
				}
			}
		}

		private void tenkp_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listDuockp.Focus();
			else if (e.KeyCode==Keys.Enter)
			{
				if (listDuockp.Visible)	listDuockp.Focus();
				else SendKeys.Send("{Tab}{F4}");
			}
		}

		private void Filter_dmkp(string ten)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listDuockp.DataSource];
				DataView dv=(DataView)cm.List;
				dv.RowFilter="ten like '%"+ten.Trim()+"%'";
			}
			catch{}
		}

		private void tenkp_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tenkp)
			{
				Filter_dmkp(tenkp.Text);
				listDuockp.BrowseToDmnx(tenkp,makp,ghichu,30);
			}
		}

		private void tenkp_Validated(object sender, System.EventArgs e)
		{
		}

		private void phieu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void madoituong_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (madoituong.SelectedIndex==-1) madoituong.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private DialogResult Thongso()
		{
			p.AllowSomePages = true;
			p.ShowHelp = true;
			p.Document = docToPrint;
			return p.ShowDialog();
		}

		private void tenbd_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tenbd)
			{
				if (butMoi.Enabled || i_makp==0) return;
				Filter_dmbd(tenbd.Text);
				listDMBD.Tonkhoct(tenbd,mabd,soluong,madoituong.Location.X,mabd.Location.Y + mabd.Height-2,mabd.Width+lTen.Width+tenbd.Width+lTenhc.Width+tenhc.Width+madoituong.Width+lMabd.Width,mabd.Height+5);
			}
		}

		private void mabd_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==mabd)
			{
				if (butMoi.Enabled || i_makp==0) return;
				Filter_mabd(mabd.Text);
				listDMBD.Tonkhoct(mabd,tenbd,soluong,madoituong.Location.X,mabd.Location.Y + mabd.Height-2,mabd.Width+lTen.Width+tenbd.Width+lTenhc.Width+tenhc.Width+madoituong.Width+lMabd.Width,mabd.Height+5);
			}
		}

		private void Filter_mabd(string ma)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listDMBD.DataSource];
				DataView dv=(DataView)cm.List;
				sql="soluong>0 and ma like '%"+ma.Trim()+"%'";
				if (madoituong.SelectedIndex!=-1) if (madoituong.SelectedValue.ToString()=="1") sql+=" and bhyt<>0";
				if (madoituong.SelectedIndex!=-1)
				{
					s_nguon_doituong=dtdoituong.Rows[madoituong.SelectedIndex]["nguon"].ToString().Trim();
					s_nguon_doituong=(s_nguon_doituong!="")?s_nguon_doituong.Substring(0,s_nguon_doituong.Length-1):"";
					if (s_nguon_doituong!="") sql+=" and manguon in ("+s_nguon_doituong+")";
				}
				dv.RowFilter=sql;
			}
			catch{}
		}

		private void listDuockp_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab) makp_Validated(sender,e);
		}

		private void get_items(int stt)
		{
			try
			{
				r=d.getrowbyid(dtton,"soluong>0 and stt="+stt);
				if (r!=null)
				{
					mabd.Text=r["ma"].ToString();
					tenbd.Text=r["ten"].ToString();
					tenhc.Text=r["tenhc"].ToString();
					dang.Text=r["dang"].ToString();
					makho.SelectedValue=r["makho"].ToString();
					manguon.SelectedValue=r["manguon"].ToString();
					listDMBD.Hide();
					soluong.Focus();
				}
			}
			catch{}		
		}

		private void mabd_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listDMBD.Focus();
			else if (e.KeyCode==Keys.Enter)
			{
				sql="soluong>0 and ma like '"+mabd.Text.Trim()+"%'";
				DataRow [] dr=dtton.Select(sql);
				if (dr.Length==1)
				{
					mabd.Text=dr[0]["stt"].ToString();
					get_items(int.Parse(mabd.Text));
					if(!listDMBD.Focused) listDMBD.Hide();
					soluong.Focus();
				}
				else
				{
					if (listDMBD.Visible)
					{
						listDMBD.Focus();
						SendKeys.Send("{Up}");
					}
					else SendKeys.Send("{Tab}");
				}
			}
		}

		private void find_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==find) RefreshChildren(find.Text);
		}

		private void find_Enter(object sender, System.EventArgs e)
		{
			find.Text="";
		}
		private void RefreshChildren(string text)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[cmbSophieu.DataSource];
				DataView dv=(DataView)cm.List;			
				dv.RowFilter="mabn like '%"+text.Trim()+"%'";
				if(cmbSophieu.SelectedIndex>=0)	l_id=decimal.Parse(cmbSophieu.SelectedValue.ToString());
				else l_id=0;
				load_head();
			}
			catch(Exception ex){MessageBox.Show(ex.Message);}
		}

		private void ghichu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");		
		}
	}
}
