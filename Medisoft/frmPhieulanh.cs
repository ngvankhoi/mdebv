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
	public class frmPhieulanh : System.Windows.Forms.Form
	{
        Language lan = new Language();
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
		private string s_mmyy,s_ngay,sql,s_ngaysp,s_makho,s_kho,s_makp;
		private int i_nhom,i_userid,i_mabd,i_old,i_songay,i_makp,i_loai;
		private long l_id,l_sttt;
		private decimal d_soluong,d_dongia,d_sotien,d_giaban,d_soluongton,d_soluongcu,d_tongcong;
		private bool bKhoaso,bNew,bEdit=true,bGiaban;
		private AccessData d;
		private Doisototext doiso=new Doisototext();
		private DataTable dttonct=new DataTable();
		private DataTable dtton=new DataTable();
		private DataTable dtll=new DataTable();
		private DataTable dtct=new DataTable();
		private DataTable dtsave=new DataTable();
		private DataTable dtduockp=new DataTable();
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
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmPhieulanh(AccessData acc,int loai,string mmyy,string ngay,int nhom,int userid,string kho,string makp,string title,bool b_giaban)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            d=acc;
			i_nhom=nhom;
			s_kho=kho;
			s_makp=makp;
			i_userid=userid;
			s_mmyy=mmyy;
			s_ngay=ngay;
			i_loai=loai;
			bGiaban=b_giaban;
			this.Text=title;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmPhieulanh));
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
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(2, 6);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Số phiếu :";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(134, 6);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(48, 23);
			this.label2.TabIndex = 1;
			this.label2.Text = "Ngày :";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(247, 8);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(49, 23);
			this.label9.TabIndex = 8;
			this.label9.Text = "Phiếu :";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(432, 8);
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
			this.ngaysp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ngaysp.Location = new System.Drawing.Point(183, 8);
			this.ngaysp.Mask = "##/##/####";
			this.ngaysp.MaxLength = 10;
			this.ngaysp.Name = "ngaysp";
			this.ngaysp.Size = new System.Drawing.Size(64, 21);
			this.ngaysp.TabIndex = 2;
			this.ngaysp.Text = "";
			this.ngaysp.Validated += new System.EventHandler(this.ngaysp_Validated);
			// 
			// phieu
			// 
			this.phieu.BackColor = System.Drawing.SystemColors.HighlightText;
			this.phieu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.phieu.Enabled = false;
			this.phieu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.phieu.Location = new System.Drawing.Point(296, 8);
			this.phieu.Name = "phieu";
			this.phieu.Size = new System.Drawing.Size(136, 21);
			this.phieu.TabIndex = 3;
			this.phieu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.phieu_KeyDown);
			// 
			// listDMBD
			// 
			this.listDMBD.ColumnCount = 0;
			this.listDMBD.Location = new System.Drawing.Point(376, 544);
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
			this.lMabd.Location = new System.Drawing.Point(129, 415);
			this.lMabd.Name = "lMabd";
			this.lMabd.Size = new System.Drawing.Size(32, 23);
			this.lMabd.TabIndex = 28;
			this.lMabd.Text = "Mã :";
			this.lMabd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lTen
			// 
			this.lTen.Location = new System.Drawing.Point(212, 415);
			this.lTen.Name = "lTen";
			this.lTen.Size = new System.Drawing.Size(30, 23);
			this.lTen.TabIndex = 29;
			this.lTen.Text = "Tên :";
			this.lTen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// ldvt
			// 
			this.ldvt.Location = new System.Drawing.Point(22, 438);
			this.ldvt.Name = "ldvt";
			this.ldvt.Size = new System.Drawing.Size(34, 23);
			this.ldvt.TabIndex = 30;
			this.ldvt.Text = "ĐVT :";
			this.ldvt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label16
			// 
			this.label16.Location = new System.Drawing.Point(187, 437);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(56, 23);
			this.label16.TabIndex = 31;
			this.label16.Text = "Số lượng :";
			this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label17
			// 
			this.label17.Location = new System.Drawing.Point(336, 437);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(56, 23);
			this.label17.TabIndex = 32;
			this.label17.Text = "Đơn giá :";
			this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label18
			// 
			this.label18.Location = new System.Drawing.Point(487, 437);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(56, 23);
			this.label18.TabIndex = 33;
			this.label18.Text = "Số tiền :";
			this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label20
			// 
			this.label20.Location = new System.Drawing.Point(-8, 461);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(64, 23);
			this.label20.TabIndex = 35;
			this.label20.Text = "Nguồn :";
			this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// tenbd
			// 
			this.tenbd.BackColor = System.Drawing.SystemColors.HighlightText;
			this.tenbd.Enabled = false;
			this.tenbd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tenbd.Location = new System.Drawing.Point(242, 415);
			this.tenbd.Name = "tenbd";
			this.tenbd.Size = new System.Drawing.Size(238, 21);
			this.tenbd.TabIndex = 8;
			this.tenbd.Text = "";
			this.tenbd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbd_KeyDown);
			this.tenbd.Validated += new System.EventHandler(this.tenbd_Validated);
			this.tenbd.TextChanged += new System.EventHandler(this.tenbd_TextChanged);
			// 
			// mabd
			// 
			this.mabd.BackColor = System.Drawing.SystemColors.HighlightText;
			this.mabd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.mabd.Enabled = false;
			this.mabd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.mabd.Location = new System.Drawing.Point(160, 415);
			this.mabd.Name = "mabd";
			this.mabd.Size = new System.Drawing.Size(52, 21);
			this.mabd.TabIndex = 7;
			this.mabd.Text = "";
			this.mabd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbd_KeyDown);
			this.mabd.Validated += new System.EventHandler(this.mabd_Validated);
			this.mabd.TextChanged += new System.EventHandler(this.mabd_TextChanged);
			// 
			// dang
			// 
			this.dang.BackColor = System.Drawing.SystemColors.HighlightText;
			this.dang.Enabled = false;
			this.dang.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.dang.Location = new System.Drawing.Point(56, 438);
			this.dang.Mask = "";
			this.dang.MaxLength = 10;
			this.dang.Name = "dang";
			this.dang.Size = new System.Drawing.Size(120, 21);
			this.dang.TabIndex = 10;
			this.dang.Text = "";
			// 
			// soluong
			// 
			this.soluong.BackColor = System.Drawing.SystemColors.HighlightText;
			this.soluong.Enabled = false;
			this.soluong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.soluong.Location = new System.Drawing.Point(242, 438);
			this.soluong.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
			this.soluong.Name = "soluong";
			this.soluong.Size = new System.Drawing.Size(94, 21);
			this.soluong.TabIndex = 11;
			this.soluong.Text = "";
			this.soluong.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.soluong.Validated += new System.EventHandler(this.soluong_Validated);
			// 
			// dongia
			// 
			this.dongia.BackColor = System.Drawing.SystemColors.HighlightText;
			this.dongia.Enabled = false;
			this.dongia.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.dongia.Location = new System.Drawing.Point(391, 438);
			this.dongia.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
			this.dongia.Name = "dongia";
			this.dongia.Size = new System.Drawing.Size(89, 21);
			this.dongia.TabIndex = 12;
			this.dongia.Text = "";
			this.dongia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// sotien
			// 
			this.sotien.BackColor = System.Drawing.SystemColors.HighlightText;
			this.sotien.Enabled = false;
			this.sotien.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.sotien.Location = new System.Drawing.Point(544, 438);
			this.sotien.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
			this.sotien.Name = "sotien";
			this.sotien.Size = new System.Drawing.Size(104, 21);
			this.sotien.TabIndex = 13;
			this.sotien.Text = "";
			this.sotien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// butMoi
			// 
			this.butMoi.Image = ((System.Drawing.Bitmap)(resources.GetObject("butMoi.Image")));
			this.butMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butMoi.Location = new System.Drawing.Point(51, 490);
			this.butMoi.Name = "butMoi";
			this.butMoi.Size = new System.Drawing.Size(75, 28);
			this.butMoi.TabIndex = 23;
			this.butMoi.Text = "      &Mới";
			this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
			// 
			// butSua
			// 
			this.butSua.Image = ((System.Drawing.Bitmap)(resources.GetObject("butSua.Image")));
			this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butSua.Location = new System.Drawing.Point(128, 490);
			this.butSua.Name = "butSua";
			this.butSua.Size = new System.Drawing.Size(75, 28);
			this.butSua.TabIndex = 24;
			this.butSua.Text = "     &Sửa";
			this.butSua.Click += new System.EventHandler(this.butSua_Click);
			// 
			// butLuu
			// 
			this.butLuu.Enabled = false;
			this.butLuu.Image = ((System.Drawing.Bitmap)(resources.GetObject("butLuu.Image")));
			this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butLuu.Location = new System.Drawing.Point(205, 490);
			this.butLuu.Name = "butLuu";
			this.butLuu.Size = new System.Drawing.Size(75, 28);
			this.butLuu.TabIndex = 21;
			this.butLuu.Text = "     &Lưu";
			this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
			// 
			// butThem
			// 
			this.butThem.Enabled = false;
			this.butThem.Image = ((System.Drawing.Bitmap)(resources.GetObject("butThem.Image")));
			this.butThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butThem.Location = new System.Drawing.Point(282, 490);
			this.butThem.Name = "butThem";
			this.butThem.Size = new System.Drawing.Size(75, 28);
			this.butThem.TabIndex = 19;
			this.butThem.Text = "       &Thêm";
			this.butThem.Click += new System.EventHandler(this.butThem_Click);
			// 
			// butXoa
			// 
			this.butXoa.Enabled = false;
			this.butXoa.Image = ((System.Drawing.Bitmap)(resources.GetObject("butXoa.Image")));
			this.butXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butXoa.Location = new System.Drawing.Point(359, 490);
			this.butXoa.Name = "butXoa";
			this.butXoa.Size = new System.Drawing.Size(75, 28);
			this.butXoa.TabIndex = 20;
			this.butXoa.Text = "       &Xóa";
			this.butXoa.Click += new System.EventHandler(this.butXoa_Click);
			// 
			// butBoqua
			// 
			this.butBoqua.Enabled = false;
			this.butBoqua.Image = ((System.Drawing.Bitmap)(resources.GetObject("butBoqua.Image")));
			this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butBoqua.Location = new System.Drawing.Point(436, 490);
			this.butBoqua.Name = "butBoqua";
			this.butBoqua.Size = new System.Drawing.Size(75, 28);
			this.butBoqua.TabIndex = 22;
			this.butBoqua.Text = "     &Bỏ qua";
			this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
			// 
			// butHuy
			// 
			this.butHuy.Image = ((System.Drawing.Bitmap)(resources.GetObject("butHuy.Image")));
			this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butHuy.Location = new System.Drawing.Point(513, 490);
			this.butHuy.Name = "butHuy";
			this.butHuy.Size = new System.Drawing.Size(75, 28);
			this.butHuy.TabIndex = 25;
			this.butHuy.Text = "     &Hủy";
			this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
			// 
			// butIn
			// 
			this.butIn.Image = ((System.Drawing.Bitmap)(resources.GetObject("butIn.Image")));
			this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butIn.Location = new System.Drawing.Point(590, 490);
			this.butIn.Name = "butIn";
			this.butIn.Size = new System.Drawing.Size(75, 28);
			this.butIn.TabIndex = 26;
			this.butIn.Text = "   &In";
			this.butIn.Click += new System.EventHandler(this.butIn_Click);
			// 
			// butKetthuc
			// 
			this.butKetthuc.Image = ((System.Drawing.Bitmap)(resources.GetObject("butKetthuc.Image")));
			this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butKetthuc.Location = new System.Drawing.Point(667, 490);
			this.butKetthuc.Name = "butKetthuc";
			this.butKetthuc.Size = new System.Drawing.Size(75, 28);
			this.butKetthuc.TabIndex = 27;
			this.butKetthuc.Text = "&Kết thúc";
			this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
			// 
			// cmbSophieu
			// 
			this.cmbSophieu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbSophieu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.cmbSophieu.Location = new System.Drawing.Point(56, 8);
			this.cmbSophieu.Name = "cmbSophieu";
			this.cmbSophieu.Size = new System.Drawing.Size(80, 21);
			this.cmbSophieu.TabIndex = 0;
			this.cmbSophieu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbSophieu_KeyDown);
			this.cmbSophieu.SelectedIndexChanged += new System.EventHandler(this.cmbSophieu_SelectedIndexChanged);
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(482, 461);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(61, 23);
			this.label15.TabIndex = 61;
			this.label15.Text = "Hạn dùng :";
			this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label24
			// 
			this.label24.Location = new System.Drawing.Point(610, 461);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(80, 23);
			this.label24.TabIndex = 62;
			this.label24.Text = "Lô sản xuất :";
			this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// handung
			// 
			this.handung.BackColor = System.Drawing.SystemColors.HighlightText;
			this.handung.Enabled = false;
			this.handung.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.handung.Location = new System.Drawing.Point(544, 461);
			this.handung.Mask = "####";
			this.handung.Name = "handung";
			this.handung.Size = new System.Drawing.Size(40, 21);
			this.handung.TabIndex = 17;
			this.handung.Text = "";
			// 
			// losx
			// 
			this.losx.BackColor = System.Drawing.SystemColors.HighlightText;
			this.losx.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.losx.Enabled = false;
			this.losx.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.losx.Location = new System.Drawing.Point(688, 461);
			this.losx.Mask = "&&&&&&&&&&";
			this.losx.MaxLength = 10;
			this.losx.Name = "losx";
			this.losx.Size = new System.Drawing.Size(96, 21);
			this.losx.TabIndex = 18;
			this.losx.Text = "";
			// 
			// tenhc
			// 
			this.tenhc.BackColor = System.Drawing.SystemColors.HighlightText;
			this.tenhc.Enabled = false;
			this.tenhc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tenhc.Location = new System.Drawing.Point(544, 415);
			this.tenhc.Name = "tenhc";
			this.tenhc.Size = new System.Drawing.Size(240, 21);
			this.tenhc.TabIndex = 9;
			this.tenhc.Text = "";
			// 
			// lTenhc
			// 
			this.lTenhc.Location = new System.Drawing.Point(484, 414);
			this.lTenhc.Name = "lTenhc";
			this.lTenhc.Size = new System.Drawing.Size(59, 23);
			this.lTenhc.TabIndex = 64;
			this.lTenhc.Text = "Hoạt chất :";
			this.lTenhc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// sophieu
			// 
			this.sophieu.BackColor = System.Drawing.SystemColors.HighlightText;
			this.sophieu.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.sophieu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.sophieu.Location = new System.Drawing.Point(56, 8);
			this.sophieu.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
			this.sophieu.MaxLength = 8;
			this.sophieu.Name = "sophieu";
			this.sophieu.Size = new System.Drawing.Size(80, 21);
			this.sophieu.TabIndex = 1;
			this.sophieu.Text = "";
			this.sophieu.Validated += new System.EventHandler(this.sophieu_Validated);
			// 
			// giaban
			// 
			this.giaban.BackColor = System.Drawing.SystemColors.HighlightText;
			this.giaban.Enabled = false;
			this.giaban.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.giaban.Location = new System.Drawing.Point(391, 461);
			this.giaban.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
			this.giaban.Name = "giaban";
			this.giaban.Size = new System.Drawing.Size(89, 21);
			this.giaban.TabIndex = 16;
			this.giaban.Text = "";
			this.giaban.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label25
			// 
			this.label25.Location = new System.Drawing.Point(336, 461);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(56, 23);
			this.label25.TabIndex = 66;
			this.label25.Text = "Giá bán :";
			this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// dataGrid1
			// 
			this.dataGrid1.AlternatingBackColor = System.Drawing.Color.Lavender;
			this.dataGrid1.BackColor = System.Drawing.Color.WhiteSmoke;
			this.dataGrid1.BackgroundColor = System.Drawing.SystemColors.Control;
			this.dataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dataGrid1.CaptionBackColor = System.Drawing.SystemColors.Control;
			this.dataGrid1.CaptionFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.dataGrid1.CaptionForeColor = System.Drawing.Color.MidnightBlue;
			this.dataGrid1.DataMember = "";
			this.dataGrid1.FlatMode = true;
			this.dataGrid1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.dataGrid1.ForeColor = System.Drawing.Color.MidnightBlue;
			this.dataGrid1.GridLineColor = System.Drawing.Color.Gainsboro;
			this.dataGrid1.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
			this.dataGrid1.HeaderFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
			this.dataGrid1.HeaderForeColor = System.Drawing.Color.WhiteSmoke;
			this.dataGrid1.LinkColor = System.Drawing.Color.Teal;
			this.dataGrid1.Location = new System.Drawing.Point(8, 16);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
			this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
			this.dataGrid1.ReadOnly = true;
			this.dataGrid1.RowHeaderWidth = 10;
			this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
			this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
			this.dataGrid1.Size = new System.Drawing.Size(776, 392);
			this.dataGrid1.TabIndex = 27;
			this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(172, 461);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(72, 23);
			this.label3.TabIndex = 67;
			this.label3.Text = "Nhóm NCC :";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// manguon
			// 
			this.manguon.BackColor = System.Drawing.SystemColors.HighlightText;
			this.manguon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.manguon.Enabled = false;
			this.manguon.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.manguon.Location = new System.Drawing.Point(56, 461);
			this.manguon.Name = "manguon";
			this.manguon.Size = new System.Drawing.Size(120, 21);
			this.manguon.TabIndex = 14;
			// 
			// nhomcc
			// 
			this.nhomcc.BackColor = System.Drawing.SystemColors.HighlightText;
			this.nhomcc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.nhomcc.Enabled = false;
			this.nhomcc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.nhomcc.Location = new System.Drawing.Point(242, 461);
			this.nhomcc.Name = "nhomcc";
			this.nhomcc.Size = new System.Drawing.Size(94, 21);
			this.nhomcc.TabIndex = 15;
			// 
			// stt
			// 
			this.stt.Location = new System.Drawing.Point(32, 376);
			this.stt.Name = "stt";
			this.stt.Size = new System.Drawing.Size(24, 20);
			this.stt.TabIndex = 68;
			this.stt.Text = "";
			// 
			// sttt
			// 
			this.sttt.Location = new System.Drawing.Point(64, 376);
			this.sttt.Name = "sttt";
			this.sttt.Size = new System.Drawing.Size(24, 20);
			this.sttt.TabIndex = 69;
			this.sttt.Text = "";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(-4, 415);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 23);
			this.label4.TabIndex = 70;
			this.label4.Text = "Đối tượng :";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// madoituong
			// 
			this.madoituong.BackColor = System.Drawing.SystemColors.HighlightText;
			this.madoituong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.madoituong.Enabled = false;
			this.madoituong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.madoituong.Location = new System.Drawing.Point(56, 415);
			this.madoituong.Name = "madoituong";
			this.madoituong.Size = new System.Drawing.Size(80, 21);
			this.madoituong.TabIndex = 6;
			this.madoituong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.madoituong_KeyDown);
			this.madoituong.SelectedIndexChanged += new System.EventHandler(this.madoituong_SelectedIndexChanged);
			// 
			// makp
			// 
			this.makp.BackColor = System.Drawing.SystemColors.HighlightText;
			this.makp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.makp.Enabled = false;
			this.makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.makp.Location = new System.Drawing.Point(478, 8);
			this.makp.Name = "makp";
			this.makp.Size = new System.Drawing.Size(72, 21);
			this.makp.TabIndex = 4;
			this.makp.Text = "";
			this.makp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.makp_KeyDown);
			this.makp.Validated += new System.EventHandler(this.makp_Validated);
			// 
			// tenkp
			// 
			this.tenkp.BackColor = System.Drawing.SystemColors.HighlightText;
			this.tenkp.Enabled = false;
			this.tenkp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tenkp.Location = new System.Drawing.Point(552, 8);
			this.tenkp.Name = "tenkp";
			this.tenkp.Size = new System.Drawing.Size(232, 21);
			this.tenkp.TabIndex = 5;
			this.tenkp.Text = "";
			this.tenkp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenkp_KeyDown);
			this.tenkp.Validated += new System.EventHandler(this.tenkp_Validated);
			this.tenkp.TextChanged += new System.EventHandler(this.tenkp_TextChanged);
			// 
			// listDuockp
			// 
			this.listDuockp.ColumnCount = 0;
			this.listDuockp.Location = new System.Drawing.Point(296, 544);
			this.listDuockp.MatchBufferTimeOut = 1000;
			this.listDuockp.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
			this.listDuockp.Name = "listDuockp";
			this.listDuockp.Size = new System.Drawing.Size(75, 17);
			this.listDuockp.TabIndex = 71;
			this.listDuockp.TextIndex = -1;
			this.listDuockp.TextMember = null;
			this.listDuockp.ValueIndex = -1;
			this.listDuockp.Visible = false;
			// 
			// makho
			// 
			this.makho.BackColor = System.Drawing.SystemColors.HighlightText;
			this.makho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.makho.Enabled = false;
			this.makho.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.makho.Location = new System.Drawing.Point(688, 438);
			this.makho.Name = "makho";
			this.makho.Size = new System.Drawing.Size(96, 21);
			this.makho.TabIndex = 72;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(656, 437);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(32, 23);
			this.label5.TabIndex = 73;
			this.label5.Text = "Kho :";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// frmPhieulanh
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(792, 573);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.label5,
																		  this.makho,
																		  this.listDuockp,
																		  this.tenkp,
																		  this.makp,
																		  this.madoituong,
																		  this.label4,
																		  this.cmbSophieu,
																		  this.sophieu,
																		  this.ngaysp,
																		  this.phieu,
																		  this.label10,
																		  this.label9,
																		  this.label2,
																		  this.label1,
																		  this.nhomcc,
																		  this.manguon,
																		  this.label3,
																		  this.giaban,
																		  this.label25,
																		  this.tenbd,
																		  this.tenhc,
																		  this.lTenhc,
																		  this.losx,
																		  this.handung,
																		  this.label24,
																		  this.label15,
																		  this.dang,
																		  this.butKetthuc,
																		  this.butIn,
																		  this.butHuy,
																		  this.butBoqua,
																		  this.butXoa,
																		  this.butThem,
																		  this.butLuu,
																		  this.butSua,
																		  this.butMoi,
																		  this.soluong,
																		  this.sotien,
																		  this.dongia,
																		  this.mabd,
																		  this.label20,
																		  this.label18,
																		  this.label17,
																		  this.label16,
																		  this.ldvt,
																		  this.lTen,
																		  this.lMabd,
																		  this.dataGrid1,
																		  this.listDMBD,
																		  this.stt,
																		  this.sttt});
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmPhieulanh";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Phiếu lĩnh";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmPhieulanh_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void frmPhieulanh_Load(object sender, System.EventArgs e)
		{
			bKhoaso=d.bKhoaso(i_nhom,s_mmyy);
			i_songay=d.Ngaylv_Ngayht;
			s_makho=d.get_dmkho(i_loai).Trim();
			s_makho=(s_makho=="")?"":s_makho.Substring(0,s_makho.Length-1);

			manguon.DisplayMember="TEN";
			manguon.ValueMember="ID";
			if (d.bQuanlynguon)
				manguon.DataSource=d.get_data("select * from d_dmnguon where nhom="+i_nhom+" order by stt").Tables[0];
			else
				manguon.DataSource=d.get_data("select * from d_dmnguon where nhom=0 or nhom="+i_nhom+" order by stt").Tables[0];

			nhomcc.DisplayMember="TEN";
			nhomcc.ValueMember="ID";
			if (d.bQuanlynhomcc)
				nhomcc.DataSource=d.get_data("select * from d_nhomcc where nhom="+i_nhom+" order by stt").Tables[0];
			else
				nhomcc.DataSource=d.get_data("select * from d_nhomcc where nhom=0 or nhom="+i_nhom+" order by stt").Tables[0];

			phieu.DisplayMember="TEN";
			phieu.ValueMember="ID";
			phieu.DataSource=d.get_data("select * from d_loaiphieu where loai="+i_loai+" order by stt").Tables[0];

			makho.DisplayMember="TEN";
			makho.ValueMember="ID";
			sql="select * from d_dmkho where nhom="+i_nhom;
			if (s_kho!="") sql+=" and id in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			sql+=" order by stt";
			makho.DataSource=d.get_data(sql).Tables[0];

			madoituong.DisplayMember="DOITUONG";
			madoituong.ValueMember="MADOITUONG";
			madoituong.DataSource=d.get_data("select * from doituong order by madoituong").Tables[0];

			listDMBD.DisplayMember="TEN";
			listDMBD.ValueMember="STT";

			listDuockp.DisplayMember="MA";
			listDuockp.ValueMember="TEN";
			sql="select ma,ten,id from d_duockp where nhom like '%"+i_nhom.ToString()+",%'";
			if (s_makp!="") sql+=" and id in ("+s_makp.Substring(0,s_makp.Length-1)+")";
			sql+=" order by stt";
			dtduockp=d.get_data(sql).Tables[0];
			listDuockp.DataSource=dtduockp;
			//load_dm();
			sql="select id,mabn,to_char(ngay,'dd/mm/yyyy') ngay,phieu,makp from d_xuatsdll where maql=0 and loai="+i_loai+" and userid="+i_userid+" and nhom="+i_nhom+" and mmyy='"+s_mmyy+"'";
			if (d.bLoclinh) sql+=" and to_char(ngay,'dd/mm/yyyy')='"+s_ngay+"'";
			sql+=" order by id";
			dtll=d.get_data(sql).Tables[0];
			cmbSophieu.DisplayMember="MABN";
			cmbSophieu.ValueMember="ID";
			cmbSophieu.DataSource=dtll;
			load_grid();
			AddGridTableStyle();
			ref_text();
			dsxoa.ReadXml("..\\..\\..\\xml\\d_xuatsdct.xml");
		}

		private void load_grid()
		{
			sql="select a.stt,a.sttt,e.doituong,a.mabd,b.ma,trim(b.ten)||' '||b.hamluong ten,b.tenhc,b.dang,f.ten tenkho,c.ten tennguon,d.ten tennhomcc,a.handung,a.losx,a.soluong,round(a.sotien/a.soluong,3) dongia,a.sotien,a.giaban,a.madoituong,a.makho,a.manguon,a.nhomcc,'xx/xx/xxxx' ngay ";
			sql+=" from d_xuatsdct a,d_dmbd b,d_dmnguon c,d_nhomcc d,doituong e,d_dmkho f where a.mabd=b.id and a.manguon=c.id and a.nhomcc=d.id and a.madoituong=e.madoituong and a.makho=f.id and a.id="+l_id+" order by a.stt";
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
				soluong.Text=d_soluong.ToString("###,###,##0.00");
				dongia.Text=d_dongia.ToString("###,###,###,##0.000");
				sotien.Text=d_sotien.ToString("###,###,###,##0.000");
				giaban.Text=d_giaban.ToString("#,###,###,##0");
				madoituong.SelectedValue=dataGrid1[i,15].ToString();
				makho.SelectedValue=dataGrid1[i,16].ToString();
				manguon.SelectedValue=dataGrid1[i,17].ToString();
				nhomcc.SelectedValue=dataGrid1[i,18].ToString();
				sttt.Text=dataGrid1[i,19].ToString();
				d_soluongcu=d_soluong;
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
			TextCol.Width = (d.bQuanlynguon)?80:0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tennhomcc";
			TextCol.HeaderText = "Nhóm cung cấp";
			TextCol.Width = (d.bQuanlynhomcc)?90:0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "handung";
			TextCol.HeaderText = "Date";
			TextCol.Width = (d.bQuanlyhandung)?30:0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "losx";
			TextCol.HeaderText = "Lô SX";
			TextCol.Width = (d.bQuanlylosx)?50:0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "soluong";
			TextCol.HeaderText = "Số lượng";
			TextCol.Width = 80;
			TextCol.Format="#,###,##0.00";
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "dongia";
			TextCol.HeaderText = "Đơn giá";
			TextCol.Width = 100;
			TextCol.Format="###,###,###,##0.000";
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "sotien";
			TextCol.HeaderText = "Số tiền";
			TextCol.Width = 100;
			TextCol.Format="###,###,###,##0.000";
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "giaban";
			TextCol.HeaderText = (bGiaban)?"Giá bán":"";
			TextCol.Width = (bGiaban)?100:0;
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
		}

		private void sophieu_Validated(object sender, System.EventArgs e)
		{
			if (l_id!=0) return;
			try
			{
				r=d.getrowbyid(dtll,"mabn='"+sophieu.Text+"'");
				if (r!=null)
				{
					MessageBox.Show("Số phiếu đã nhập !",d.Msg);
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
			try
			{
				l_id=long.Parse(cmbSophieu.SelectedValue.ToString());
				r=d.getrowbyid(dtll,"id="+l_id);
				if (r!=null)
				{
					sophieu.Text=r["mabn"].ToString();
					ngaysp.Text=r["ngay"].ToString();
					DataRow r1=d.getrowbyid(dtduockp,"id="+int.Parse(r["makp"].ToString()));
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
			this.Close();
		}

		private void Filter_dmbd(string ten)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listDMBD.DataSource];
				DataView dv=(DataView)cm.List;
				dv.RowFilter="(soluong>0) and (ten like '%"+ten.Trim()+"%'"+" or tenhc like '%"+ten.Trim()+"%')";
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
			sophieu.Visible=ena;
			cmbSophieu.Visible=!ena;
			sophieu.Enabled=ena;
			ngaysp.Enabled=ena;
			makp.Enabled=ena;
			tenkp.Enabled=ena;
			phieu.Enabled=ena;
			madoituong.Enabled=ena;
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
			if (ena) load_dm();
        }

		private void emp_head()
		{
			l_id=0;
			sophieu.Text="";
			ngaysp.Text=s_ngay;
			s_ngaysp=ngaysp.Text;
			makp.Text="";
			tenkp.Text="";
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
			manguon.SelectedIndex=-1;
			nhomcc.SelectedIndex=-1;
			makho.SelectedIndex=-1;
			stt.Text=d.get_stt(dtct).ToString();
			d_soluongcu=0;
		}
		private void butMoi_Click(object sender, System.EventArgs e)
		{
			if (bKhoaso)
			{
				MessageBox.Show("Số liệu tháng "+s_mmyy.Substring(0,2)+" năm "+s_mmyy.Substring(2,2)+" đã khóa !\nNếu cần thay đổi thì vào mục khai báo hệ thống",d.Msg);
				return;
			}
			ena_object(true);
			dtct.Clear();
			dtsave=dtct.Copy();
			emp_head();
			emp_detail();
			bNew=true;
			bEdit=true;
			sophieu.Focus();
		}
		private void butSua_Click(object sender, System.EventArgs e)
		{
			if (dtll.Rows.Count==0) return;
			if (bKhoaso)
			{
				MessageBox.Show("Số liệu tháng "+s_mmyy.Substring(0,2)+" năm "+s_mmyy.Substring(2,2)+" đã khóa !\nNếu cần thay đổi thì vào mục khai báo hệ thống",d.Msg);
				return;
			}
			l_id=long.Parse(cmbSophieu.SelectedValue.ToString());
			ena_object(true);
			bNew=false;
			bEdit=true;
			dtsave=dtct.Copy();
			sophieu.Focus();
			ref_text();
		}
		private bool KiemtraHead()
		{
			if (sophieu.Text=="")
			{
				MessageBox.Show("Nhập số phiếu !",d.Msg);
				sophieu.Focus();
				return false;
			}
			if (ngaysp.Text=="")
			{
				MessageBox.Show("Nhập ngày số phiếu !",d.Msg);
				ngaysp.Focus();
				return false;
			}
			if (phieu.SelectedIndex==-1)
			{
				MessageBox.Show("Nhập phiếu !",d.Msg);
				phieu.Focus();
				return false;
			}
			if (makp.Text=="" && tenkp.Text=="")
			{
				MessageBox.Show("Chọn khoa !",d.Msg);
				makp.Focus();
				return false;
			}
			if ((makp.Text!="" && tenkp.Text=="") || (makp.Text=="" && tenkp.Text!=""))
			{
				if (makp.Text=="")
				{
					makp.Focus();
					return false;
				}
				else if (tenkp.Text=="")
				{
					tenkp.Focus();
					return false;
				}
			}
			i_makp=0;
			r=d.getrowbyid(dtduockp,"ma='"+makp.Text+"'");
			if (r==null)
			{
				MessageBox.Show("Khoa không hợp lệ !",d.Msg);
				makp.Focus();
				return false;
			}
			i_makp=int.Parse(r["id"].ToString());
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
					MessageBox.Show("Nhập mã số !",d.Msg);
					mabd.Focus();
					return false;
				}
				else if (tenbd.Text=="")
				{
					MessageBox.Show("Nhập tên !",d.Msg);
					tenbd.Focus();
					return false;
				}
			}
			r=d.getrowbyid(dtton,"ma='"+mabd.Text+"'");
			if (r==null)
			{
				MessageBox.Show("Mã số không hợp lệ !",d.Msg);
				if (mabd.Enabled) mabd.Focus();
				else tenbd.Focus();
				return false;
			}
			i_mabd=int.Parse(r["id"].ToString());
			if (soluong.Text=="" || soluong.Text=="0.00" || soluong.Text=="0")
			{
				MessageBox.Show("Nhập số lượng !",d.Msg);
				soluong.Focus();
				return false;
			}
			if (madoituong.SelectedIndex==-1)
			{
				MessageBox.Show("Chọn đối tượng !",d.Msg);
				madoituong.Focus();
				return false;
			}
			return true;
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			bEdit=false;
			cmbSophieu.SelectedIndex=i_old;
			ena_object(false);
			butMoi.Focus();
		}

		private void ngaysp_Validated(object sender, System.EventArgs e)
		{
			if (ngaysp.Text=="") return;
			ngaysp.Text=ngaysp.Text.Trim();
			if (!d.bNgay(ngaysp.Text))
			{
				MessageBox.Show("Ngày không hợp lệ !",d.Msg);
				ngaysp.Focus();
				return;
			}
			ngaysp.Text=d.Ktngaygio(ngaysp.Text,10);
			if (ngaysp.Text!=s_ngaysp)
			{
				if (!d.ngay(d.StringToDate(ngaysp.Text.Substring(0,10)),DateTime.Now,i_songay))
				{
					MessageBox.Show("Ngày không hợp lệ so với khai báo hệ thống ("+i_songay.ToString()+")!",d.Msg);
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
			if (!upd_table(dtct)) return;
			emp_detail();
			madoituong.Focus();
			SendKeys.Send("{F4}");
		}

		private void butXoa_Click(object sender, System.EventArgs e)
		{
			if (!upd_table(dsxoa.Tables[0])) return;
			d.delrec(dtct,"stt="+int.Parse(stt.Text));
			dtct.AcceptChanges();
			ref_text();
		}

		private bool upd_table(DataTable dt)
		{
			if (!KiemtraDetail()) return false;
			d_soluong=(soluong.Text!="")?decimal.Parse(soluong.Text):0;
			d_dongia=(dongia.Text!="")?decimal.Parse(dongia.Text):0;
			d_sotien=(sotien.Text!="")?decimal.Parse(sotien.Text):0;
			d_giaban=(giaban.Text!="")?decimal.Parse(giaban.Text):0;
			l_sttt=(sttt.Text!="")?long.Parse(sttt.Text):0;
			d.updrec_xuatsdct(dt,int.Parse(stt.Text),l_sttt,madoituong.Text,i_mabd,mabd.Text,tenbd.Text,tenhc.Text,dang.Text,makho.Text,(manguon.SelectedIndex==-1)?"":manguon.Text,(nhomcc.SelectedIndex==-1)?"":nhomcc.Text,handung.Text,losx.Text,d_soluong,d_dongia,d_sotien,d_giaban,int.Parse(madoituong.SelectedValue.ToString()),int.Parse(makho.SelectedValue.ToString()),(manguon.SelectedIndex==-1)?0:int.Parse(manguon.SelectedValue.ToString()),(nhomcc.SelectedIndex==-1)?0:int.Parse(nhomcc.SelectedValue.ToString()),ngaysp.Text,dtton);
			return true;
		}

		private void mabd_Validated(object sender, System.EventArgs e)
		{
//			if (mabd.text!="")
//			{
//				r=d.getrowbyid(dtton,"soluong>0 and ma='"+mabd.text+"'");
//				if (r!=null) 
//				{
//					tenbd.text=r["ten"].tostring();
//					tenhc.text=r["tenhc"].tostring();
//					dang.text=r["dang"].tostring();
//					makho.selectedvalue=r["makho"].tostring();
//				}
//			}
			if(!listDMBD.Focused) listDMBD.Hide();
		}

		private void listDMBD_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
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
				}
			}
			catch{}
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
				d_sotien=(sotien.Text!="")?decimal.Parse(sotien.Text):0;
				d_dongia=Math.Round(d_sotien/d_soluong,3);
				dongia.Text=d_dongia.ToString("###,###,###,##0.000");
			}
			catch{}
		}

		private void soluong_Validated(object sender, System.EventArgs e)
		{
			try
			{
				if (!bEdit) return;
				d_soluong=(soluong.Text!="")?decimal.Parse(soluong.Text):0;
				soluong.Text=d_soluong.ToString("#,###,##0.00");
				if (mabd.Text!="" && tenbd.Text!="")
				{
					r=d.getrowbyid(dtton,"ma='"+mabd.Text+"'");
					if (r!=null)
					{
						i_mabd=int.Parse(r["id"].ToString());
						d_soluongton=d.get_soluongton(dtton,int.Parse(makho.SelectedValue.ToString()),i_mabd,d_soluongcu);
						if (d_soluong>d_soluongton)
						{
							MessageBox.Show("Số lượng xuất lớn hơn số lượng tồn !("+d_soluongton.ToString()+")",d.Msg);
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
				if (dtll.Rows.Count==0) return;
				if (bKhoaso)
				{
					MessageBox.Show("Số liệu tháng "+s_mmyy.Substring(0,2)+" năm "+s_mmyy.Substring(2,2)+" đã khóa !\nNếu cần thay đổi thì vào mục khai báo hệ thống",d.Msg);
					return;
				}
				if (MessageBox.Show("Đồng ý hủy số phiếu này ?",d.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
				{
					l_id=long.Parse(cmbSophieu.SelectedValue.ToString());
					d.execute_data("delete from d_xuatsdct where id="+l_id);
					d.execute_data("delete from d_xuatsdll where id="+l_id);
					d.delrec(dtll,"id="+l_id);
					cmbSophieu.Refresh();
					load_grid();
				}
			}
			catch{}
		}

		private void load_dm()
		{
			sql="select rownum stt,b.ma,trim(b.ten)||' '||b.hamluong ten,b.tenhc,b.dang,c.ten tenkho,a.tondau+a.slnhap-a.slxuat soluong,b.id,a.makho from d_tonkhoth a,d_dmbd b,d_dmkho c where a.mabd=b.id and a.makho=c.id and a.mmyy='"+s_mmyy+"'";
			if (s_makho!="") sql+=" and a.makho in ("+s_makho+")";
			else if (s_kho!="") sql+=" and a.makho in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			if (madoituong.SelectedIndex!=-1) if (madoituong.SelectedValue.ToString()=="1") sql+=" and b.bhyt<>0";
			sql+=" order by b.ten";
			dtton=d.get_data(sql).Tables[0];
			listDMBD.DataSource=dtton;
		}
		private void load_tonct()
		{
			sql="select a.*,b.ten tennguon,c.ten tennhomcc from d_tonkhoct a,d_dmnguon b,d_nhomcc c where a.manguon=b.id and a.nhomcc=c.id and a.mmyy='"+s_mmyy+"'";
			if (s_kho!="") sql+=" and a.makho in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			else if (s_makho!="") sql+=" and a.makho in ("+s_makho+")";
			sql+=" order by a.stt";
			dttonct=d.get_data(sql).Tables[0];
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			if (!KiemtraHead()) return;
			bEdit=false;
			upd_table(dtct);
			dtct.AcceptChanges();
			i_old=(bNew)?0:1;
			l_id=(bNew)?d.get_id_xuatsd:l_id;
			if (!d.upd_xuatsdll(l_id,i_nhom,sophieu.Text,0,0,ngaysp.Text,i_loai,int.Parse(phieu.SelectedValue.ToString()),i_makp,s_mmyy,i_userid))
			{
				MessageBox.Show("Không cập nhật được thông tin phiếu lĩnh !",d.Msg);
				return;
			}
			if (dsxoa.Tables[0].Rows.Count>0)
			{
				foreach(DataRow r1 in dtsave.Rows)
					d.execute_data("delete from d_xuatsdct where id="+l_id+" and stt="+long.Parse(r1["stt"].ToString()));
			}
			load_tonct();
			foreach(DataRow r1 in d.get_xuatsdct(dtsave,dtct,dttonct).Rows)
				d.upd_xuatsdct(l_id,int.Parse(r1["stt"].ToString()),long.Parse(r1["sttt"].ToString()),int.Parse(r1["madoituong"].ToString()),int.Parse(r1["makho"].ToString()),int.Parse(r1["manguon"].ToString()),int.Parse(r1["nhomcc"].ToString()),int.Parse(r1["mabd"].ToString()),r1["handung"].ToString(),r1["losx"].ToString(),decimal.Parse(r1["soluong"].ToString()),decimal.Parse(r1["sotien"].ToString()),decimal.Parse(r1["giaban"].ToString()));
			d.updrec_xuatsdll(dtll,l_id,sophieu.Text,ngaysp.Text,int.Parse(phieu.SelectedValue.ToString()),i_makp);
			try
			{
				if (i_old==0 && dtll.Rows.Count>0) cmbSophieu.SelectedIndex=dtll.Rows.Count-1;
			}
			catch{}
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
			string s_tenkho=(s_kho=="")?"":makho.Text,lydo="Sử dụng";
			if (d.bPreview)
			{
				frmReport f=new frmReport(d,dtct,"d_phieuxuat.rpt",cmbSophieu.Text,ngaysp.Text,"","",tenkp.Text,lydo,s_tenkho,doiso.Doiso_Unicode(Convert.ToInt64(d_tongcong).ToString()),"","");
				f.ShowDialog();
			}
			else
			{
				ReportDocument oRpt=new ReportDocument();
				oRpt.Load("..\\..\\..\\report\\d_phieuxuat.rpt",OpenReportMethod.OpenReportByTempCopy);
				oRpt.SetDataSource(dtct);
				oRpt.DataDefinition.FormulaFields["soyte"].Text="'"+d.Tenbv+"'";
				oRpt.DataDefinition.FormulaFields["benhvien"].Text="'"+d.Diachi+"'";
				oRpt.DataDefinition.FormulaFields["c1"].Text="'"+cmbSophieu.Text+"'";
				oRpt.DataDefinition.FormulaFields["c2"].Text="'"+ngaysp.Text+"'";
				oRpt.DataDefinition.FormulaFields["c3"].Text="";
				oRpt.DataDefinition.FormulaFields["c4"].Text="";
				oRpt.DataDefinition.FormulaFields["c5"].Text="'"+tenkp.Text+"'";
				oRpt.DataDefinition.FormulaFields["c6"].Text="'"+lydo+"'";
				oRpt.DataDefinition.FormulaFields["c7"].Text="'"+s_tenkho+"'";
				oRpt.DataDefinition.FormulaFields["c8"].Text="'"+doiso.Doiso_Unicode(Convert.ToInt64(d_tongcong).ToString())+"'";
				oRpt.DataDefinition.FormulaFields["c9"].Text="";
				oRpt.DataDefinition.FormulaFields["c10"].Text="";
				oRpt.DataDefinition.FormulaFields["giamdoc"].Text="'"+d.Giamdoc+"'";
				oRpt.DataDefinition.FormulaFields["phutrach"].Text="'"+d.Phutrach+"'";
				oRpt.DataDefinition.FormulaFields["thongke"].Text="'"+d.Thongke+"'";
				oRpt.DataDefinition.FormulaFields["ketoan"].Text="'"+d.Ketoan+"'";
				oRpt.DataDefinition.FormulaFields["thukho"].Text="'"+d.Thukho+"'";
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
				if (r!=null) tenkp.Text=r["ten"].ToString();
			}
		}

		private void tenkp_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listDuockp.Focus();
			else if (e.KeyCode==Keys.Enter)
			{
				if (listDuockp.Visible)	listDuockp.Focus();
				else SendKeys.Send("{Tab}");
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
			Filter_dmkp(tenkp.Text);
			listDuockp.BrowseToDmnx(tenkp,makp,madoituong);
		}

		private void tenkp_Validated(object sender, System.EventArgs e)
		{
			if(!listDuockp.Focused) listDuockp.Hide();
			if (tenkp.Text!="" && makp.Text=="")
			{
				r=d.getrowbyid(dtduockp,"ten='"+tenkp.Text+"'");
				if (r!=null) makp.Text=r["ma"].ToString();
			}
			SendKeys.Send("{F4}");
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

		private void madoituong_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				if (this.ActiveControl==madoituong) load_dm();
			}
			catch{}
		}

		private void tenbd_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tenbd)
			{
				if (butMoi.Enabled) return;
				Filter_dmbd(tenbd.Text);
				listDMBD.BrowseToTonkhoct(tenbd,mabd,soluong,madoituong.Location.X,mabd.Location.Y + mabd.Height-2,mabd.Width+lTen.Width+tenbd.Width+lTenhc.Width+tenhc.Width+madoituong.Width+lMabd.Width,mabd.Height+5);
			}
		}

		private void mabd_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==mabd)
			{
				if (butMoi.Enabled) return;
				Filter_mabd(mabd.Text);
				listDMBD.BrowseToTonkhoct(mabd,tenbd,soluong,madoituong.Location.X,mabd.Location.Y + mabd.Height-2,mabd.Width+lTen.Width+tenbd.Width+lTenhc.Width+tenhc.Width+madoituong.Width+lMabd.Width,mabd.Height+5);
			}
		}

		private void Filter_mabd(string ma)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listDMBD.DataSource];
				DataView dv=(DataView)cm.List;
				dv.RowFilter="soluong>0 and ma like '%"+ma.Trim()+"%'";
			}
			catch{}
		}
	}
}
