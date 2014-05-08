using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibDuoc;
using LibMedi;
using doiso;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace Duoc
{
	/// <summary>
	/// Summary description for frmXkhac.
	/// </summary>
	public class frmXuatban_mabn : System.Windows.Forms.Form
	{
		private int i_soluong_le=0,i_dongia_le=0,i_thanhtien_le=0,i_quayban=0;
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
		private string s_mmyy,s_ngay,sql,s_ngaysp,s_makho,s_kho,s_makp,s_userid,tmp_ngaygio,s_manguon,format_soluong,format_dongia,format_sotien;
		private int i_nhom,i_userid,i_mabd,i_old,i_songay,i_loai,i_makp,i_sotoa;
		private long l_id,l_sttt;
		private decimal d_soluong,d_dongia,d_sotien,d_giaban,d_soluongton,d_soluongcu,d_sotiencu,d_tongcong,d_sotienban;
		private bool bKhoaso,bNew,bEdit=true,bGiaban,bAdmin;
		private bool bHotennt,bNgtru_khoa,bNgtru_bacsi,bNamsinhnt,bNhapmaso,bNgtru_mabn;
		private LibDuoc.AccessData d;
		private LibMedi.AccessData m=new LibMedi.AccessData();
		private Doisototext doiso=new Doisototext();
		private DataTable dttonct=new DataTable();
		private DataTable dtton=new DataTable();
		private DataTable dtll=new DataTable();
		private DataTable dtct=new DataTable();
		private DataTable dtsave=new DataTable();
		private DataTable dtduockp=new DataTable();
		private DataTable dtbs=new DataTable();
		private DataSet dsxoa=new DataSet();
		private DataTable dtdmbd=new DataTable();
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
		private System.Windows.Forms.Label lMabd;
		private System.Windows.Forms.TextBox tenkp;
		private LibList.List listDuockp;
		private System.Windows.Forms.ComboBox makho;
		private System.Windows.Forms.Label label5;
		private System.Drawing.Printing.PrintDocument docToPrint = new System.Drawing.Printing.PrintDocument();
		private PrintDialog p=new PrintDialog();
		private DialogResult result;
		private System.Windows.Forms.ComboBox loai;
		private System.Windows.Forms.Label label4;
		private MaskedTextBox.MaskedTextBox hoten;
		private MaskedTextBox.MaskedTextBox namsinh;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox makp;
		private System.Windows.Forms.TextBox tenbs;
		private System.Windows.Forms.Label label11;
		private LibList.List listDMBS;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox sum;
		private System.Windows.Forms.TextBox mabs;
		private MaskedTextBox.MaskedTextBox sotienban;
		private frmMain parent;
		private System.Windows.Forms.Button butMua;
		private System.Windows.Forms.Button butDonthuoc;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.TextBox timkiem;
		private System.Windows.Forms.Label toaso;
		private System.Windows.Forms.Label lbl;
		private System.Windows.Forms.Label ltoaso;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmXuatban_mabn(LibDuoc.AccessData acc,int loai,string mmyy,string ngay,int nhom,int userid,string kho,string makp,string title,bool b_giaban,string user,bool admin, int quayban)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			d=acc;
			i_nhom=nhom;
			s_kho=kho;
			s_makp=makp;
			i_userid=userid;
			s_mmyy=mmyy;
			s_ngay=ngay;
			s_userid=user;
			i_loai=loai;
			bGiaban=b_giaban;
			bAdmin=admin;
			i_quayban=quayban;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmXuatban_mabn));
			this.lbl = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.ngaysp = new MaskedBox.MaskedBox();
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
			this.tenkp = new System.Windows.Forms.TextBox();
			this.listDuockp = new LibList.List();
			this.makho = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.loai = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.hoten = new MaskedTextBox.MaskedTextBox();
			this.namsinh = new MaskedTextBox.MaskedTextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.makp = new System.Windows.Forms.TextBox();
			this.tenbs = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.listDMBS = new LibList.List();
			this.label7 = new System.Windows.Forms.Label();
			this.sum = new System.Windows.Forms.TextBox();
			this.mabs = new System.Windows.Forms.TextBox();
			this.sotienban = new MaskedTextBox.MaskedTextBox();
			this.butMua = new System.Windows.Forms.Button();
			this.butDonthuoc = new System.Windows.Forms.Button();
			this.label8 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.timkiem = new System.Windows.Forms.TextBox();
			this.ltoaso = new System.Windows.Forms.Label();
			this.toaso = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			this.SuspendLayout();
			// 
			// lbl
			// 
			this.lbl.Location = new System.Drawing.Point(104, 7);
			this.lbl.Name = "lbl";
			this.lbl.Size = new System.Drawing.Size(46, 23);
			this.lbl.TabIndex = 0;
			this.lbl.Text = "Mã BN :";
			this.lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(-8, 7);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(48, 23);
			this.label2.TabIndex = 1;
			this.label2.Text = "Ngày :";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(264, 7);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(49, 23);
			this.label9.TabIndex = 8;
			this.label9.Text = "Họ tên :";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(-5, 28);
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
			this.ngaysp.Location = new System.Drawing.Point(40, 7);
			this.ngaysp.Mask = "##/##/####";
			this.ngaysp.MaxLength = 10;
			this.ngaysp.Name = "ngaysp";
			this.ngaysp.Size = new System.Drawing.Size(64, 21);
			this.ngaysp.TabIndex = 0;
			this.ngaysp.Text = "";
			this.ngaysp.Validated += new System.EventHandler(this.ngaysp_Validated);
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
			this.listDMBD.DoubleClick += new System.EventHandler(this.listDMBD_DoubleClick);
			// 
			// lMabd
			// 
			this.lMabd.Location = new System.Drawing.Point(24, 415);
			this.lMabd.Name = "lMabd";
			this.lMabd.Size = new System.Drawing.Size(32, 23);
			this.lMabd.TabIndex = 28;
			this.lMabd.Text = "Mã :";
			this.lMabd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lTen
			// 
			this.lTen.Location = new System.Drawing.Point(128, 415);
			this.lTen.Name = "lTen";
			this.lTen.Size = new System.Drawing.Size(80, 23);
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
			this.label16.Location = new System.Drawing.Point(154, 437);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(56, 23);
			this.label16.TabIndex = 31;
			this.label16.Text = "Số lượng :";
			this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label17
			// 
			this.label17.Location = new System.Drawing.Point(315, 461);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(56, 23);
			this.label17.TabIndex = 32;
			this.label17.Text = "Giá mua :";
			this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label18
			// 
			this.label18.Location = new System.Drawing.Point(472, 437);
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
			this.tenbd.Location = new System.Drawing.Point(210, 415);
			this.tenbd.Name = "tenbd";
			this.tenbd.Size = new System.Drawing.Size(254, 21);
			this.tenbd.TabIndex = 11;
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
			this.mabd.Location = new System.Drawing.Point(56, 415);
			this.mabd.Name = "mabd";
			this.mabd.Size = new System.Drawing.Size(52, 21);
			this.mabd.TabIndex = 10;
			this.mabd.Text = "";
			this.mabd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabd_KeyDown);
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
			this.dang.Size = new System.Drawing.Size(88, 21);
			this.dang.TabIndex = 13;
			this.dang.Text = "";
			// 
			// soluong
			// 
			this.soluong.BackColor = System.Drawing.SystemColors.HighlightText;
			this.soluong.Enabled = false;
			this.soluong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.soluong.Location = new System.Drawing.Point(210, 438);
			this.soluong.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
			this.soluong.Name = "soluong";
			this.soluong.Size = new System.Drawing.Size(94, 21);
			this.soluong.TabIndex = 14;
			this.soluong.Text = "";
			this.soluong.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.soluong.Validated += new System.EventHandler(this.soluong_Validated);
			// 
			// dongia
			// 
			this.dongia.BackColor = System.Drawing.SystemColors.HighlightText;
			this.dongia.Enabled = false;
			this.dongia.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.dongia.Location = new System.Drawing.Point(370, 461);
			this.dongia.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
			this.dongia.Name = "dongia";
			this.dongia.Size = new System.Drawing.Size(94, 21);
			this.dongia.TabIndex = 20;
			this.dongia.Text = "";
			this.dongia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// sotien
			// 
			this.sotien.BackColor = System.Drawing.SystemColors.HighlightText;
			this.sotien.Enabled = false;
			this.sotien.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.sotien.Location = new System.Drawing.Point(136, 344);
			this.sotien.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
			this.sotien.Name = "sotien";
			this.sotien.Size = new System.Drawing.Size(104, 21);
			this.sotien.TabIndex = 14;
			this.sotien.Text = "";
			this.sotien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// butMoi
			// 
			this.butMoi.Image = ((System.Drawing.Bitmap)(resources.GetObject("butMoi.Image")));
			this.butMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butMoi.Location = new System.Drawing.Point(130, 490);
			this.butMoi.Name = "butMoi";
			this.butMoi.Size = new System.Drawing.Size(53, 28);
			this.butMoi.TabIndex = 27;
			this.butMoi.Text = "&Mới";
			this.butMoi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
			// 
			// butSua
			// 
			this.butSua.Image = ((System.Drawing.Bitmap)(resources.GetObject("butSua.Image")));
			this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butSua.Location = new System.Drawing.Point(129, 544);
			this.butSua.Name = "butSua";
			this.butSua.Size = new System.Drawing.Size(56, 28);
			this.butSua.TabIndex = 28;
			this.butSua.Text = "&Sửa";
			this.butSua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.butSua.Visible = false;
			this.butSua.Click += new System.EventHandler(this.butSua_Click);
			// 
			// butLuu
			// 
			this.butLuu.Enabled = false;
			this.butLuu.Image = ((System.Drawing.Bitmap)(resources.GetObject("butLuu.Image")));
			this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butLuu.Location = new System.Drawing.Point(184, 490);
			this.butLuu.Name = "butLuu";
			this.butLuu.Size = new System.Drawing.Size(55, 28);
			this.butLuu.TabIndex = 25;
			this.butLuu.Text = "&Lưu";
			this.butLuu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
			// 
			// butThem
			// 
			this.butThem.Enabled = false;
			this.butThem.Image = ((System.Drawing.Bitmap)(resources.GetObject("butThem.Image")));
			this.butThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butThem.Location = new System.Drawing.Point(240, 490);
			this.butThem.Name = "butThem";
			this.butThem.Size = new System.Drawing.Size(64, 28);
			this.butThem.TabIndex = 23;
			this.butThem.Text = "&Thêm";
			this.butThem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.butThem.Click += new System.EventHandler(this.butThem_Click);
			// 
			// butXoa
			// 
			this.butXoa.Enabled = false;
			this.butXoa.Image = ((System.Drawing.Bitmap)(resources.GetObject("butXoa.Image")));
			this.butXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butXoa.Location = new System.Drawing.Point(305, 490);
			this.butXoa.Name = "butXoa";
			this.butXoa.Size = new System.Drawing.Size(56, 28);
			this.butXoa.TabIndex = 24;
			this.butXoa.Text = "&Xóa";
			this.butXoa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.butXoa.Click += new System.EventHandler(this.butXoa_Click);
			// 
			// butBoqua
			// 
			this.butBoqua.Enabled = false;
			this.butBoqua.Image = ((System.Drawing.Bitmap)(resources.GetObject("butBoqua.Image")));
			this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butBoqua.Location = new System.Drawing.Point(362, 490);
			this.butBoqua.Name = "butBoqua";
			this.butBoqua.Size = new System.Drawing.Size(68, 28);
			this.butBoqua.TabIndex = 26;
			this.butBoqua.Text = "&Bỏ qua";
			this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
			// 
			// butHuy
			// 
			this.butHuy.Image = ((System.Drawing.Bitmap)(resources.GetObject("butHuy.Image")));
			this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butHuy.Location = new System.Drawing.Point(431, 490);
			this.butHuy.Name = "butHuy";
			this.butHuy.Size = new System.Drawing.Size(55, 28);
			this.butHuy.TabIndex = 29;
			this.butHuy.Text = "&Hủy";
			this.butHuy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
			// 
			// butIn
			// 
			this.butIn.Image = ((System.Drawing.Bitmap)(resources.GetObject("butIn.Image")));
			this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butIn.Location = new System.Drawing.Point(487, 490);
			this.butIn.Name = "butIn";
			this.butIn.Size = new System.Drawing.Size(48, 28);
			this.butIn.TabIndex = 31;
			this.butIn.Text = "&In";
			this.butIn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.butIn.Click += new System.EventHandler(this.butIn_Click);
			// 
			// butKetthuc
			// 
			this.butKetthuc.Image = ((System.Drawing.Bitmap)(resources.GetObject("butKetthuc.Image")));
			this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butKetthuc.Location = new System.Drawing.Point(640, 490);
			this.butKetthuc.Name = "butKetthuc";
			this.butKetthuc.Size = new System.Drawing.Size(75, 28);
			this.butKetthuc.TabIndex = 33;
			this.butKetthuc.Text = "&Kết thúc";
			this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
			// 
			// cmbSophieu
			// 
			this.cmbSophieu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbSophieu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.cmbSophieu.Location = new System.Drawing.Point(149, 7);
			this.cmbSophieu.Name = "cmbSophieu";
			this.cmbSophieu.Size = new System.Drawing.Size(115, 21);
			this.cmbSophieu.TabIndex = 1;
			this.cmbSophieu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbSophieu_KeyDown);
			this.cmbSophieu.SelectedIndexChanged += new System.EventHandler(this.cmbSophieu_SelectedIndexChanged);
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(467, 461);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(61, 23);
			this.label15.TabIndex = 61;
			this.label15.Text = "Hạn dùng :";
			this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label24
			// 
			this.label24.Location = new System.Drawing.Point(596, 461);
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
			this.handung.Location = new System.Drawing.Point(530, 461);
			this.handung.Mask = "####";
			this.handung.Name = "handung";
			this.handung.Size = new System.Drawing.Size(40, 21);
			this.handung.TabIndex = 21;
			this.handung.Text = "";
			// 
			// losx
			// 
			this.losx.BackColor = System.Drawing.SystemColors.HighlightText;
			this.losx.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.losx.Enabled = false;
			this.losx.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.losx.Location = new System.Drawing.Point(674, 461);
			this.losx.Mask = "&&&&&&&&&&";
			this.losx.MaxLength = 10;
			this.losx.Name = "losx";
			this.losx.Size = new System.Drawing.Size(110, 21);
			this.losx.TabIndex = 22;
			this.losx.Text = "";
			// 
			// tenhc
			// 
			this.tenhc.BackColor = System.Drawing.SystemColors.HighlightText;
			this.tenhc.Enabled = false;
			this.tenhc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tenhc.Location = new System.Drawing.Point(530, 415);
			this.tenhc.Name = "tenhc";
			this.tenhc.Size = new System.Drawing.Size(256, 21);
			this.tenhc.TabIndex = 12;
			this.tenhc.Text = "";
			// 
			// lTenhc
			// 
			this.lTenhc.Location = new System.Drawing.Point(469, 414);
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
			this.sophieu.Enabled = false;
			this.sophieu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.sophieu.Location = new System.Drawing.Point(149, 7);
			this.sophieu.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
			this.sophieu.MaxLength = 8;
			this.sophieu.Name = "sophieu";
			this.sophieu.Size = new System.Drawing.Size(115, 21);
			this.sophieu.TabIndex = 2;
			this.sophieu.Text = "";
			this.sophieu.Validated += new System.EventHandler(this.sophieu_Validated);
			// 
			// giaban
			// 
			this.giaban.BackColor = System.Drawing.SystemColors.HighlightText;
			this.giaban.Enabled = false;
			this.giaban.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.giaban.Location = new System.Drawing.Point(370, 438);
			this.giaban.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
			this.giaban.Name = "giaban";
			this.giaban.Size = new System.Drawing.Size(94, 21);
			this.giaban.TabIndex = 15;
			this.giaban.Text = "";
			this.giaban.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label25
			// 
			this.label25.Location = new System.Drawing.Point(315, 437);
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
			this.dataGrid1.Location = new System.Drawing.Point(8, 64);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
			this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
			this.dataGrid1.ReadOnly = true;
			this.dataGrid1.RowHeaderWidth = 10;
			this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
			this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
			this.dataGrid1.Size = new System.Drawing.Size(776, 320);
			this.dataGrid1.TabIndex = 27;
			this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(139, 461);
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
			this.manguon.Size = new System.Drawing.Size(88, 21);
			this.manguon.TabIndex = 18;
			// 
			// nhomcc
			// 
			this.nhomcc.BackColor = System.Drawing.SystemColors.HighlightText;
			this.nhomcc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.nhomcc.Enabled = false;
			this.nhomcc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.nhomcc.Location = new System.Drawing.Point(210, 461);
			this.nhomcc.Name = "nhomcc";
			this.nhomcc.Size = new System.Drawing.Size(94, 21);
			this.nhomcc.TabIndex = 19;
			// 
			// stt
			// 
			this.stt.Location = new System.Drawing.Point(32, 352);
			this.stt.Name = "stt";
			this.stt.Size = new System.Drawing.Size(24, 20);
			this.stt.TabIndex = 68;
			this.stt.Text = "";
			// 
			// sttt
			// 
			this.sttt.Location = new System.Drawing.Point(64, 352);
			this.sttt.Name = "sttt";
			this.sttt.Size = new System.Drawing.Size(24, 20);
			this.sttt.TabIndex = 69;
			this.sttt.Text = "";
			// 
			// tenkp
			// 
			this.tenkp.BackColor = System.Drawing.SystemColors.HighlightText;
			this.tenkp.Enabled = false;
			this.tenkp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tenkp.Location = new System.Drawing.Point(72, 30);
			this.tenkp.Name = "tenkp";
			this.tenkp.Size = new System.Drawing.Size(192, 21);
			this.tenkp.TabIndex = 7;
			this.tenkp.Text = "";
			this.tenkp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenkp_KeyDown);
			this.tenkp.Validated += new System.EventHandler(this.tenkp_Validated);
			this.tenkp.TextChanged += new System.EventHandler(this.tenkp_TextChanged);
			// 
			// listDuockp
			// 
			this.listDuockp.ColumnCount = 0;
			this.listDuockp.Location = new System.Drawing.Point(256, 544);
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
			this.makho.Location = new System.Drawing.Point(674, 438);
			this.makho.Name = "makho";
			this.makho.Size = new System.Drawing.Size(110, 21);
			this.makho.TabIndex = 17;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(642, 437);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(32, 23);
			this.label5.TabIndex = 73;
			this.label5.Text = "Kho :";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// loai
			// 
			this.loai.BackColor = System.Drawing.SystemColors.HighlightText;
			this.loai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.loai.Enabled = false;
			this.loai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.loai.ItemHeight = 13;
			this.loai.Location = new System.Drawing.Point(648, 7);
			this.loai.Name = "loai";
			this.loai.Size = new System.Drawing.Size(136, 21);
			this.loai.TabIndex = 5;
			this.loai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.loai_KeyDown);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(504, 7);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(67, 23);
			this.label4.TabIndex = 74;
			this.label4.Text = "Năm sinh :";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// hoten
			// 
			this.hoten.BackColor = System.Drawing.SystemColors.HighlightText;
			this.hoten.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.hoten.Enabled = false;
			this.hoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.hoten.Location = new System.Drawing.Point(312, 7);
			this.hoten.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
			this.hoten.Name = "hoten";
			this.hoten.Size = new System.Drawing.Size(192, 21);
			this.hoten.TabIndex = 3;
			this.hoten.Text = "";
			this.hoten.Validated += new System.EventHandler(this.hoten_Validated);
			// 
			// namsinh
			// 
			this.namsinh.BackColor = System.Drawing.SystemColors.HighlightText;
			this.namsinh.Enabled = false;
			this.namsinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.namsinh.Location = new System.Drawing.Point(568, 7);
			this.namsinh.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
			this.namsinh.MaxLength = 4;
			this.namsinh.Name = "namsinh";
			this.namsinh.Size = new System.Drawing.Size(43, 21);
			this.namsinh.TabIndex = 4;
			this.namsinh.Text = "";
			this.namsinh.Validated += new System.EventHandler(this.namsinh_Validated);
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(616, 7);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(32, 23);
			this.label6.TabIndex = 77;
			this.label6.Text = "Loại :";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// makp
			// 
			this.makp.BackColor = System.Drawing.SystemColors.HighlightText;
			this.makp.Enabled = false;
			this.makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.makp.Location = new System.Drawing.Point(40, 30);
			this.makp.Name = "makp";
			this.makp.Size = new System.Drawing.Size(30, 21);
			this.makp.TabIndex = 6;
			this.makp.Text = "";
			this.makp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.makp_KeyDown);
			this.makp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.makp_KeyPress);
			this.makp.Validated += new System.EventHandler(this.makp_Validated);
			// 
			// tenbs
			// 
			this.tenbs.BackColor = System.Drawing.SystemColors.HighlightText;
			this.tenbs.Enabled = false;
			this.tenbs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tenbs.Location = new System.Drawing.Point(360, 30);
			this.tenbs.Name = "tenbs";
			this.tenbs.Size = new System.Drawing.Size(216, 21);
			this.tenbs.TabIndex = 9;
			this.tenbs.Text = "";
			this.tenbs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbs_KeyDown);
			this.tenbs.Validated += new System.EventHandler(this.tenbs_Validated);
			this.tenbs.TextChanged += new System.EventHandler(this.tenbs_TextChanged);
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(264, 28);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(48, 23);
			this.label11.TabIndex = 93;
			this.label11.Text = "Bác sĩ :";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// listDMBS
			// 
			this.listDMBS.ColumnCount = 0;
			this.listDMBS.Location = new System.Drawing.Point(168, 544);
			this.listDMBS.MatchBufferTimeOut = 1000;
			this.listDMBS.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
			this.listDMBS.Name = "listDMBS";
			this.listDMBS.Size = new System.Drawing.Size(75, 17);
			this.listDMBS.TabIndex = 99;
			this.listDMBS.TextIndex = -1;
			this.listDMBS.TextMember = null;
			this.listDMBS.ValueIndex = -1;
			this.listDMBS.Visible = false;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(581, 28);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(67, 23);
			this.label7.TabIndex = 100;
			this.label7.Text = "Tổng cộng :";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// sum
			// 
			this.sum.BackColor = System.Drawing.SystemColors.HighlightText;
			this.sum.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.sum.ForeColor = System.Drawing.Color.Red;
			this.sum.Location = new System.Drawing.Point(648, 30);
			this.sum.Name = "sum";
			this.sum.Size = new System.Drawing.Size(136, 22);
			this.sum.TabIndex = 1001;
			this.sum.Text = "";
			this.sum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// mabs
			// 
			this.mabs.BackColor = System.Drawing.SystemColors.HighlightText;
			this.mabs.Enabled = false;
			this.mabs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.mabs.Location = new System.Drawing.Point(312, 30);
			this.mabs.Name = "mabs";
			this.mabs.Size = new System.Drawing.Size(46, 21);
			this.mabs.TabIndex = 8;
			this.mabs.Text = "";
			this.mabs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabs_KeyDown);
			this.mabs.Validated += new System.EventHandler(this.mabs_Validated);
			// 
			// sotienban
			// 
			this.sotienban.BackColor = System.Drawing.SystemColors.HighlightText;
			this.sotienban.Enabled = false;
			this.sotienban.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.sotienban.Location = new System.Drawing.Point(530, 438);
			this.sotienban.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
			this.sotienban.Name = "sotienban";
			this.sotienban.Size = new System.Drawing.Size(104, 21);
			this.sotienban.TabIndex = 16;
			this.sotienban.Text = "";
			this.sotienban.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// butMua
			// 
			this.butMua.Image = ((System.Drawing.Bitmap)(resources.GetObject("butMua.Image")));
			this.butMua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butMua.Location = new System.Drawing.Point(536, 490);
			this.butMua.Name = "butMua";
			this.butMua.Size = new System.Drawing.Size(103, 28);
			this.butMua.TabIndex = 32;
			this.butMua.Text = "Mua thêm đơn";
			this.butMua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.butMua.Click += new System.EventHandler(this.butMua_Click);
			// 
			// butDonthuoc
			// 
			this.butDonthuoc.Image = ((System.Drawing.Bitmap)(resources.GetObject("butDonthuoc.Image")));
			this.butDonthuoc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butDonthuoc.Location = new System.Drawing.Point(77, 490);
			this.butDonthuoc.Name = "butDonthuoc";
			this.butDonthuoc.Size = new System.Drawing.Size(52, 28);
			this.butDonthuoc.TabIndex = 102;
			this.butDonthuoc.Text = "Đơn";
			this.butDonthuoc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.butDonthuoc.Click += new System.EventHandler(this.butDonthuoc_Click);
			// 
			// label8
			// 
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label8.Location = new System.Drawing.Point(-8, 56);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(80, 23);
			this.label8.TabIndex = 103;
			this.label8.Text = "Tổng số đơn :";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label12
			// 
			this.label12.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label12.ForeColor = System.Drawing.Color.Blue;
			this.label12.Location = new System.Drawing.Point(80, 56);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(64, 23);
			this.label12.TabIndex = 104;
			this.label12.Text = "0";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label13
			// 
			this.label13.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label13.Location = new System.Drawing.Point(8, 385);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(56, 23);
			this.label13.TabIndex = 105;
			this.label13.Text = "Số tiền :";
			this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label14
			// 
			this.label14.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label14.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(192)));
			this.label14.Location = new System.Drawing.Point(66, 385);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(718, 23);
			this.label14.TabIndex = 106;
			this.label14.Text = "đồng";
			this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// timkiem
			// 
			this.timkiem.BackColor = System.Drawing.SystemColors.HighlightText;
			this.timkiem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.timkiem.ForeColor = System.Drawing.Color.Red;
			this.timkiem.Location = new System.Drawing.Point(312, 56);
			this.timkiem.Name = "timkiem";
			this.timkiem.Size = new System.Drawing.Size(472, 21);
			this.timkiem.TabIndex = 107;
			this.timkiem.Text = "Tìm kiếm";
			this.timkiem.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.timkiem.TextChanged += new System.EventHandler(this.timkiem_TextChanged);
			this.timkiem.Enter += new System.EventHandler(this.timkiem_Enter);
			// 
			// ltoaso
			// 
			this.ltoaso.Location = new System.Drawing.Point(144, 56);
			this.ltoaso.Name = "ltoaso";
			this.ltoaso.Size = new System.Drawing.Size(56, 23);
			this.ltoaso.TabIndex = 1002;
			this.ltoaso.Text = "Toa số :";
			this.ltoaso.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// toaso
			// 
			this.toaso.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.toaso.ForeColor = System.Drawing.Color.Blue;
			this.toaso.Location = new System.Drawing.Point(208, 56);
			this.toaso.Name = "toaso";
			this.toaso.Size = new System.Drawing.Size(56, 23);
			this.toaso.TabIndex = 1003;
			this.toaso.Text = "0";
			this.toaso.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// frmXuatban_mabn
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(792, 573);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.toaso,
																		  this.ltoaso,
																		  this.loai,
																		  this.timkiem,
																		  this.label14,
																		  this.label13,
																		  this.label12,
																		  this.label8,
																		  this.butDonthuoc,
																		  this.makp,
																		  this.mabs,
																		  this.butMua,
																		  this.sotienban,
																		  this.sum,
																		  this.tenbs,
																		  this.label7,
																		  this.listDMBS,
																		  this.label11,
																		  this.label6,
																		  this.namsinh,
																		  this.hoten,
																		  this.label4,
																		  this.label5,
																		  this.makho,
																		  this.listDuockp,
																		  this.tenkp,
																		  this.cmbSophieu,
																		  this.sophieu,
																		  this.ngaysp,
																		  this.label10,
																		  this.label9,
																		  this.label2,
																		  this.lbl,
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
																		  this.sttt,
																		  this.sotien});
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.Name = "frmXuatban_mabn";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Phiếu xuất bán";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmXuatban_mabn_KeyDown);
			this.Load += new System.EventHandler(this.frmXuatban_mabn_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void frmXuatban_mabn_Load(object sender, System.EventArgs e)
		{
			i_soluong_le=d.d_soluong_le(i_nhom);
			i_dongia_le=d.d_dongia_le(i_nhom);
			i_thanhtien_le=d.d_thanhtien_le(i_nhom);
			format_sotien=d.format_sotien(i_nhom);
			format_dongia=d.format_dongia(i_nhom);
			format_soluong=d.format_soluong(i_nhom);
			bHotennt=d.bHotennt;bNgtru_khoa=d.bNgtru_khoa;
			bNgtru_bacsi=d.bNgtru_bacsi;bNamsinhnt=d.bNamsinhnt;
			bNhapmaso=d.bNhapmaso;bNgtru_mabn=d.bNgtru_mabn;
			if (!bNgtru_mabn)
			{
				lbl.Text="Số toa :";
				ltoaso.Visible=false;toaso.Visible=false;
			}
			bKhoaso=d.bKhoaso(i_nhom,s_mmyy);
			i_songay=d.Ngaylv_Ngayht;
			s_makho="";
			//s_makho=d.get_dmkho(i_loai).Trim();
			//s_makho=(s_makho=="")?"":s_makho.Substring(0,s_makho.Length-1);
			s_manguon=d.get_manguon(i_loai).Trim();
			s_manguon=(s_manguon=="")?"":s_manguon.Substring(0,s_manguon.Length-1);
			dtdmbd=d.get_data("select ma,trim(ten)||' '||hamluong ten,tenhc,dang,id,dongia,giaban from d_dmbd where nhom="+i_nhom+" order by ten").Tables[0];
			manguon.DisplayMember="TEN";
			manguon.ValueMember="ID";
			if (d.bQuanlynguon(i_nhom))
				manguon.DataSource=d.get_data("select * from d_dmnguon where nhom="+i_nhom+" order by stt").Tables[0];
			else
				manguon.DataSource=d.get_data("select * from d_dmnguon where nhom=0 or nhom="+i_nhom+" order by stt").Tables[0];

			nhomcc.DisplayMember="TEN";
			nhomcc.ValueMember="ID";
			if (d.bQuanlynhomcc(i_nhom))
				nhomcc.DataSource=d.get_data("select * from d_nhomcc where nhom="+i_nhom+" order by stt").Tables[0];
			else
				nhomcc.DataSource=d.get_data("select * from d_nhomcc where nhom=0 or nhom="+i_nhom+" order by stt").Tables[0];

			loai.DisplayMember="TEN";
			loai.ValueMember="ID";
			loai.DataSource=d.get_data("select * from d_dmloaint where nhom="+i_nhom+" order by stt").Tables[0];//((i_quayban>0)?" and id="+i_quayban:"")+

			makho.DisplayMember="TEN";
			makho.ValueMember="ID";
			sql="select * from d_dmkho where nhom="+i_nhom;
			if (s_makho!="") sql+=" and id in ("+s_makho+")";
			else if (s_kho!="") sql+=" and id in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			sql+=" order by stt";
			makho.DataSource=d.get_data(sql).Tables[0];

			listDMBD.DisplayMember="TEN";
			listDMBD.ValueMember="STT";

			listDMBS.DisplayMember="MA";
			listDMBS.ValueMember="HOTEN";
			dtbs=d.get_data("select ma,hoten from dmbs where nhom not in ("+LibMedi.AccessData.nhanvien+","+LibMedi.AccessData.nghiviec+") order by hoten").Tables[0];
			listDMBS.DataSource=dtbs;

			listDuockp.DisplayMember="ID";
			listDuockp.ValueMember="TEN";
			sql="select id,ten from d_duockp where nhom like '%"+i_nhom.ToString()+",%'";
			if (s_makp!="") sql+=" and id in ("+s_makp.Substring(0,s_makp.Length-1)+")";
			sql+=" order by stt";
			dtduockp=d.get_data(sql).Tables[0];
			listDuockp.DataSource=dtduockp;
			sql="select id,mabn,hoten,namsinh,to_char(ngay,'dd/mm/yyyy') ngay,mabs,makp,loai,done,userid,sotoa,maql from d_ngtrull where nhom="+i_nhom+" and mmyy='"+s_mmyy+"'";
			if (!bAdmin) sql+=" and userid="+i_userid+" and loai="+i_quayban;
			if (d.bLocngoaitru) sql+=" and to_char(ngay,'dd/mm/yyyy')='"+s_ngay+"'";
			sql+=" order by loai,sotoa";
			dtll=d.get_data(s_mmyy,sql).Tables[0];
			//
			label12.Text=dtll.Rows.Count.ToString("###,###,###");
			//
			cmbSophieu.DisplayMember=(bNgtru_mabn)?"MABN":"SOTOA";
			cmbSophieu.ValueMember="ID";
			cmbSophieu.DataSource=dtll;
			if (dtll.Rows.Count>0) cmbSophieu.SelectedIndex=dtll.Rows.Count-1;
			l_id=(dtll.Rows.Count==0)?0:long.Parse(dtll.Rows[dtll.Rows.Count-1]["id"].ToString());
			load_head(l_id);
			//load_grid();
			AddGridTableStyle();
			ref_text();
			dsxoa.ReadXml("..\\..\\..\\xml\\d_ngtruct.xml");
		}

		private void load_grid()
		{
			sql="select a.stt,a.sttt,a.mabd,b.ma,trim(b.ten)||' '||b.hamluong ten,b.tenhc,b.dang,e.ten tenkho,c.ten tennguon,d.ten tennhomcc,a.handung,a.losx,a.soluong,round(a.sotien/a.soluong,3) dongia,a.sotien,a.giaban,a.makho,a.manguon,a.nhomcc,a.soluong*a.giaban sotienban,a.soluong soluongcu,a.sotien sotiencu ";
			sql+=" from d_ngtruct a,"+d.user+".d_dmbd b,"+d.user+".d_dmnguon c,"+d.user+".d_nhomcc d,"+d.user+".d_dmkho e where a.mabd=b.id and a.manguon=c.id and a.nhomcc=d.id and a.makho=e.id and a.id="+l_id+" order by a.stt";
			dtct=d.get_data(s_mmyy,sql).Tables[0];
			dataGrid1.DataSource=dtct;
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
				handung.Text=dataGrid1[i,8].ToString();
				losx.Text=dataGrid1[i,9].ToString();
				d_soluong=(dataGrid1[i,10].ToString()!="")?decimal.Parse(dataGrid1[i,10].ToString()):0;
				d_dongia=(dataGrid1[i,11].ToString()!="")?decimal.Parse(dataGrid1[i,11].ToString()):0;
				d_sotien=(dataGrid1[i,12].ToString()!="")?decimal.Parse(dataGrid1[i,12].ToString()):0;
				d_giaban=(dataGrid1[i,13].ToString()!="")?decimal.Parse(dataGrid1[i,13].ToString()):0;
				soluong.Text=d_soluong.ToString(format_soluong);
				dongia.Text=d_dongia.ToString(format_dongia);
				sotien.Text=d_sotien.ToString(format_sotien);
				giaban.Text=d_giaban.ToString("#,###,###,##0");
				makho.SelectedValue=dataGrid1[i,14].ToString();
				manguon.SelectedValue=dataGrid1[i,15].ToString();
				nhomcc.SelectedValue=dataGrid1[i,16].ToString();
				sttt.Text=dataGrid1[i,17].ToString();
				d_sotienban=d_soluong*d_giaban;
				sotienban.Text=d_sotienban.ToString(format_sotien);
				d_soluongcu=d_soluong;
				d_sotiencu=d_sotien;
				if (butLuu.Enabled)
				{
					tenbd.Enabled=sttt.Text=="0";
					if (bNhapmaso) mabd.Enabled=tenbd.Enabled;
					//soluong.Enabled=tenbd.Enabled;
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
			TextCol.MappingName = "ma";
			TextCol.HeaderText = "Mã số";
			TextCol.Width = 50;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "ten";
			TextCol.HeaderText = "Tên";
			TextCol.Width = 290;//(bGiaban || d.bHoatchat || d.bQuanlyhandung(i_nhom) || d.bQuanlylosx(i_nhom) || d.bQuanlynguon(i_nhom) || d.bQuanlynhomcc(i_nhom))?200:290;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tenhc";
			TextCol.HeaderText = "";//(d.bHoatchat)?"Hoạt chất":"";
			TextCol.Width = 0;//(d.bHoatchat)?200:0;
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
			TextCol.HeaderText = (d.bQuanlynguon(i_nhom))?"Nguồn":"";
			TextCol.Width = (d.bQuanlynguon(i_nhom))?80:0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tennhomcc";
			TextCol.HeaderText = (d.bQuanlynhomcc(i_nhom))?"Nhóm cung cấp":"";
			TextCol.Width = (d.bQuanlynhomcc(i_nhom))?90:0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "handung";
			TextCol.HeaderText =(d.bQuanlyhandung(i_nhom))?"Date":"";
			TextCol.Width =(d.bQuanlyhandung(i_nhom))?30:0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "losx";
			TextCol.HeaderText = (d.bQuanlylosx(i_nhom))?"Lô SX":"";
			TextCol.Width =(d.bQuanlylosx(i_nhom))?50:0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "soluong";
			TextCol.HeaderText = "Số lượng";
			TextCol.Width = 80;
			TextCol.Format=format_soluong;
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "dongia";
			TextCol.HeaderText = "";
			TextCol.Width =0;
			TextCol.Format=format_dongia;
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "sotien";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
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

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "sotienban";
			TextCol.HeaderText = "Số tiền";
			TextCol.Width = 100;
			TextCol.Format=format_sotien;
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);
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
					l_id=long.Parse(cmbSophieu.SelectedValue.ToString());
				}
				catch{l_id=0;}
				load_head(l_id);
			}
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

		private void tenbd_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tenbd)
			{
				if (butMoi.Enabled) return;
				Filter_dmbd(tenbd.Text);
				listDMBD.Tonkhoct(tenbd,mabd,soluong,mabd.Location.X,mabd.Location.Y + mabd.Height-2,mabd.Width+lTen.Width+tenbd.Width+lTenhc.Width+tenhc.Width+lMabd.Width,mabd.Height+5);
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
			//ngaysp.Enabled=ena;
			if (bHotennt) hoten.Enabled=ena;
			loai.Enabled=(i_quayban>0)?false:ena;
			if (bNgtru_khoa) tenkp.Enabled=ena;
			if (bNgtru_bacsi) tenbs.Enabled=ena;
			if (bNamsinhnt) namsinh.Enabled=ena;
			if (bNhapmaso) mabd.Enabled=ena;
			if (bNgtru_mabn) sophieu.Enabled=ena;
			makp.Enabled=tenkp.Enabled;
			mabs.Enabled=tenbs.Enabled;
			tenbd.Enabled=ena;
			soluong.Enabled=ena;
			butMoi.Enabled=!ena;
			butSua.Enabled=!ena;
			butThem.Enabled=ena;
			butMua.Enabled=!ena;
			butDonthuoc.Enabled=!ena;
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
			if (sophieu.Enabled )sophieu.Text="";
			else sophieu.Text=d.get_sotoa_xuatban(s_mmyy,i_quayban,s_ngay).ToString();//;d.get_stt(dtll,"mabn").ToString();
			ngaysp.Text=s_ngay;
			s_ngaysp=ngaysp.Text;
			hoten.Text="";
			namsinh.Text="";
			tenkp.Text="";
			makp.Text="";
			mabs.Text="";
			tenbs.Text="";
			sum.Text="0";
			toaso.Text="";
			if(i_quayban>0)loai.SelectedValue=i_quayban.ToString();
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
			sotienban.Text="0";
			handung.Text="";
			losx.Text="";
			giaban.Text="0";
			manguon.SelectedIndex=-1;
			nhomcc.SelectedIndex=-1;
			makho.SelectedIndex=-1;
			stt.Text=d.get_stt(dtct).ToString();
			d_soluongcu=0;
			d_sotiencu=0;
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
			dtsave.Clear();
			emp_head();
			emp_detail();
			bNew=true;
			bEdit=true;
			if (sophieu.Enabled) sophieu.Focus();
			else hoten.Focus();
		}
		private void butSua_Click(object sender, System.EventArgs e)
		{
			if (cmbSophieu.Items.Count==0) return;
			if (bKhoaso)
			{
				MessageBox.Show("Số liệu tháng "+s_mmyy.Substring(0,2)+" năm "+s_mmyy.Substring(2,2)+" đã khóa !\nNếu cần thay đổi thì vào mục khai báo hệ thống",d.Msg);
				return;
			}
			l_id=long.Parse(cmbSophieu.SelectedValue.ToString());
			if (dtll.Rows[cmbSophieu.SelectedIndex]["done"].ToString()=="1")// && !bAdmin)
			{
				MessageBox.Show("Đơn thuốc đã in \nBạn không được sửa !",d.Msg);
				return;
			}
			ena_object(true);
			bNew=false;
			bEdit=true;
			dtsave=dtct.Copy();
			if (sophieu.Enabled) sophieu.Focus();
			else hoten.Focus();
			ref_text();
		}
		private bool KiemtraHead()
		{
			if (sophieu.Text=="")
			{
				MessageBox.Show("Nhập mã số người bệnh !",d.Msg);
				sophieu.Focus();
				return false;
			}
			if (ngaysp.Text=="")
			{
				MessageBox.Show("Nhập ngày số phiếu !",d.Msg);
				ngaysp.Focus();
				return false;
			}
			if (loai.SelectedIndex==-1)
			{
				MessageBox.Show("Nhập loại !",d.Msg);
				loai.Focus();
				return false;
			}
			i_makp=0;
			if (tenkp.Enabled)
			{
				r=d.getrowbyid(dtduockp,"ten='"+tenkp.Text+"'");
				if (r==null)
				{
					MessageBox.Show("Khoa không hợp lệ !",d.Msg);
					tenkp.Focus();
					return false;
				}
				i_makp=int.Parse(r["id"].ToString());
			}
			if (tenbs.Enabled)
			{
				r=d.getrowbyid(dtbs,"hoten='"+tenbs.Text+"'");
				if (r==null)
				{
					MessageBox.Show("Họ tên bác sĩ không hợp lệ !",d.Msg);
					tenbs.Focus();
					return false;
				}
			}
			if  (dtct.Rows.Count==0)
			{
				MessageBox.Show("Yêu cầu nhập mặt hàng !",d.Msg);
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
			/*
			if (soluong.Text=="" || soluong.Text=="0.00" || soluong.Text=="0")
			{
				MessageBox.Show("Nhập số lượng !",d.Msg);
				soluong.Focus();
				return false;
			}
			*/
			return true;
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			bEdit=false;
			try
			{
				cmbSophieu.SelectedIndex=dtll.Rows.Count-1;
				//cmbSophieu.SelectedIndex=i_old;
				if (cmbSophieu.Items.Count>0) l_id=long.Parse(cmbSophieu.SelectedValue.ToString());
				else l_id=0;
				load_head(l_id);
			}
			catch{}
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
			//
			if (soluong.Text=="" || soluong.Text=="0.00" || soluong.Text=="0")
			{
				MessageBox.Show("Đề nghị nhập số lượng.",d.Msg);
				soluong.Focus();
				return;
			}
			//
			if (bNhapmaso) mabd.Enabled=true;
			tenbd.Enabled=true;
			soluong.Enabled=true;
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
			d.updrec_ngtruct(dt,int.Parse(stt.Text),l_sttt,i_mabd,mabd.Text,tenbd.Text,tenhc.Text,dang.Text,makho.Text,(manguon.SelectedIndex==-1)?"":manguon.Text,(nhomcc.SelectedIndex==-1)?"":nhomcc.Text,handung.Text,losx.Text,d_soluong,d_dongia,d_sotien,d_giaban,d_dongia,d_soluong*d_giaban,int.Parse(makho.SelectedValue.ToString()),(manguon.SelectedIndex==-1)?0:int.Parse(manguon.SelectedValue.ToString()),(nhomcc.SelectedIndex==-1)?0:int.Parse(nhomcc.SelectedValue.ToString()),dtton,d_soluongcu,d_sotiencu);
			if (bGiaban) tongcong_giaban(dtct);
			else tongcong(dtct);
			sum.Text=d_tongcong.ToString("###,###,###,##0");
			string s_chu=doiso.Doiso_Unicode(Convert.ToInt64(d_tongcong.ToString()).ToString());
			label14.Text=s_chu;
			return true;
		}

		private void mabd_Validated(object sender, System.EventArgs e)
		{
			//if(!listDMBD.Focused) listDMBD.Hide();
		}

		private void listDMBD_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter)
			{
				get_items(int.Parse(mabd.Text));
				#region 1105
//				try
//				{
//					r=d.getrowbyid(dtton,"stt="+int.Parse(mabd.Text));
//					if (r!=null)
//					{
//						mabd.Text=r["ma"].ToString();
//						tenbd.Text=r["ten"].ToString();
//						tenhc.Text=r["tenhc"].ToString();
//						dang.Text=r["dang"].ToString();
//						makho.SelectedValue=r["makho"].ToString();
//						manguon.SelectedValue=r["manguon"].ToString();
//						if (bGiaban)
//						{
//							d_giaban=decimal.Parse(r["giaban"].ToString());
//							giaban.Text=d_giaban.ToString("###,###,###,###");
//						}
//					}
//				}
//				catch{}
				#endregion
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
				d_sotien=(sotien.Text!="")?decimal.Parse(sotien.Text):0;
				d_dongia=Math.Round(d_sotien/d_soluong,3);
				dongia.Text=d_dongia.ToString(format_dongia);
				d_giaban=(giaban.Text!="")?decimal.Parse(giaban.Text):0;
				d_sotienban=d_soluong*d_giaban;
				sotienban.Text=d_sotienban.ToString(format_sotien);
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
							MessageBox.Show("Số lượng xuất lớn hơn số lượng tồn !("+d_soluongton.ToString()+")",d.Msg);
							soluong.Focus();
							return;
						}
					}
				}
			}
			catch{}
			tinh_giatri();
			if (d_soluongcu!=0) sttt.Text="0";
			if (soluong.Text=="" || soluong.Text=="0.00" || soluong.Text=="0")return;
			upd_table(dtct);
			r=d.getrowbyid(dtdmbd,"ma='"+mabd.Text+"'");
			if (r!=null)
			{
				DataTable tmp=d.get_data("select a.*,trim(b.ten)||' '||trim(b.hamluong)||' '||trim(b.dang) ten,trim(b.ten)||' '||b.hamluong tenbd,b.dang,b.tenhc,b.ma,b.giaban,b.dongia from d_dmbdkemtheo a,d_dmbd b where a.mabd=b.id and a.id="+int.Parse(r["id"].ToString())).Tables[0];
				if (tmp.Rows.Count>0)
				{
					string s="";
					foreach(DataRow r1 in tmp.Rows)
					{
						i_mabd=int.Parse(r1["mabd"].ToString());
						d_soluongton=d.get_slton_nguon(dtton,int.Parse(makho.SelectedValue.ToString()),i_mabd,int.Parse(manguon.SelectedValue.ToString()),d_soluongcu);
						if (d_soluong>d_soluongton) s+=r1["ten"].ToString().Trim()+"\n";
						else d.updrec_ngtruct(dtct,d.get_stt(dtct),0,i_mabd,r1["ma"].ToString(),r1["tenbd"].ToString(),r1["tenhc"].ToString(),r1["dang"].ToString(),makho.Text,(manguon.SelectedIndex==-1)?"":manguon.Text,(nhomcc.SelectedIndex==-1)?"":nhomcc.Text,handung.Text,losx.Text,decimal.Parse(r1["soluong"].ToString()),decimal.Parse(r1["dongia"].ToString()),decimal.Parse(r1["soluong"].ToString())*decimal.Parse(r1["dongia"].ToString()),decimal.Parse(r1["giaban"].ToString()),decimal.Parse(r1["giamua"].ToString()),decimal.Parse(r1["soluong"].ToString())*decimal.Parse(r1["giaban"].ToString()),int.Parse(makho.SelectedValue.ToString()),(manguon.SelectedIndex==-1)?0:int.Parse(manguon.SelectedValue.ToString()),(nhomcc.SelectedIndex==-1)?0:int.Parse(nhomcc.SelectedValue.ToString()),dtton,d_soluongcu,d_sotiencu);
					}						 			
					if (bGiaban) tongcong_giaban(dtct);
					else tongcong(dtct);
					sum.Text=d_tongcong.ToString("###,###,###,##0");
					string s_chu=doiso.Doiso_Unicode(Convert.ToInt64(d_tongcong.ToString()).ToString());
					label14.Text=s_chu;
					if (s!="") MessageBox.Show("Những mặt hàng sau không đủ tồn\n"+s,d.Msg);
				}
			}
		}

		private void butHuy_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (cmbSophieu.Items.Count==0) return;
				if (bKhoaso)
				{
					MessageBox.Show("Số liệu tháng "+s_mmyy.Substring(0,2)+" năm "+s_mmyy.Substring(2,2)+" đã khóa !\nNếu cần thay đổi thì vào mục khai báo hệ thống",d.Msg);
					return;
				}
				if (dtll.Rows[cmbSophieu.SelectedIndex]["done"].ToString()=="1")// && !bAdmin)
				{
					MessageBox.Show("Đơn thuốc đã in \nBạn không được hủy !",d.Msg);
					return;
				}
				if (MessageBox.Show("Đồng ý hủy số phiếu này ?",d.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)==DialogResult.Yes)
				{
					l_id=long.Parse(cmbSophieu.SelectedValue.ToString());
					d.execute_data(s_mmyy,"insert into d_huybanll select * from d_ngtrull where id="+l_id);
					d.execute_data(s_mmyy,"insert into d_huybanct select * from d_ngtruct where id="+l_id);
					d.execute_data(s_mmyy,"delete from d_ngtruct where id="+l_id);
					d.execute_data(s_mmyy,"delete from d_ngtrull where id="+l_id);
					d.execute_data("update d_toathuocll set done=0 where idngtru="+l_id);
					foreach(DataRow r1 in dtct.Rows)
						d.upd_tonkhoct_xuat(d.delete,s_mmyy,long.Parse(r1["sttt"].ToString()),int.Parse(r1["makho"].ToString()),int.Parse(r1["manguon"].ToString()),int.Parse(r1["nhomcc"].ToString()),int.Parse(r1["mabd"].ToString()),r1["handung"].ToString(),r1["losx"].ToString(),decimal.Parse(r1["soluong"].ToString()),decimal.Parse(r1["sotien"].ToString()),decimal.Parse(r1["giaban"].ToString()),decimal.Parse(r1["giamua"].ToString()));
					d.delrec(dtll,"id="+l_id);
					dtll.AcceptChanges();
					cmbSophieu.Refresh();
					if (cmbSophieu.Items.Count>0) l_id=long.Parse(cmbSophieu.SelectedValue.ToString());
					else l_id=0;
					load_head(l_id);
				}
			}
			catch{}
		}

		private void load_dm()
		{
			dtton=d.get_tonkhoth(s_mmyy,s_makho,s_kho,s_manguon);
			listDMBD.DataSource=dtton;
		}
		private void load_tonct()
		{
			dttonct=d.get_tonkhoct(s_mmyy,s_makho,s_kho,s_manguon);
		}

		private void tongcong_giaban(DataTable dt)
		{
			d_tongcong=0;
			foreach(DataRow r1 in dt.Rows) d_tongcong+=decimal.Parse(r1["sotienban"].ToString());
		}

		private void tongcong(DataTable dt)
		{
			d_tongcong=0;
			foreach(DataRow r1 in dt.Rows) d_tongcong+=decimal.Parse(r1["sotien"].ToString());
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
			if (this.ActiveControl==tenkp)
			{
				Filter_dmkp(tenkp.Text);
				if (mabs.Enabled)
					listDuockp.BrowseToBtdkp(tenkp,makp,mabs);
				else
					listDuockp.BrowseToBtdkp(tenkp,makp,butThem);
			}
		}

		private void tenkp_Validated(object sender, System.EventArgs e)
		{
			if(!listDuockp.Focused) listDuockp.Hide();
		}

		private DialogResult Thongso()
		{
			p.AllowSomePages = true;
			p.ShowHelp = true;
			p.Document = docToPrint;
			return p.ShowDialog();
		}

		private void namsinh_Validated(object sender, System.EventArgs e)
		{
			if (namsinh.Text!="" && namsinh.Text.Length<4) namsinh.Text=Convert.ToString(DateTime.Now.Year-int.Parse(namsinh.Text));
			SendKeys.Send("{F4}");
		}

		private void loai_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (loai.SelectedIndex==-1) loai.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void sophieu_Validated(object sender, System.EventArgs e)
		{
			if (sophieu.Text=="" || sophieu.Text.Trim().Length<3) return;
			if (sophieu.Text.Trim().Length!=8) sophieu.Text=sophieu.Text.Substring(0,2)+sophieu.Text.Substring(2).PadLeft(6,'0');
			DataRow r;
			foreach(DataRow r1 in d.get_data("select a.hoten,a.namsinh,b.makp,b.mabs from btdbn a,benhandt b where a.mabn=b.mabn(+) and a.mabn='"+sophieu.Text+"' order by b.maql desc").Tables[0].Rows)
			{
				hoten.Text=r1["hoten"].ToString();
				namsinh.Text=r1["namsinh"].ToString();
				if (makp.Enabled)
				{
					makp.Text=r1["makp"].ToString();
					r=d.getrowbyid(dtduockp,"id="+int.Parse(makp.Text));
					if (r!=null) tenkp.Text=r["ten"].ToString();
					else tenkp.Text="";
				}
				if (mabs.Enabled)
				{
					mabs.Text=r1["mabs"].ToString();
					r=d.getrowbyid(dtbs,"ma='"+mabs.Text+"'");
					if (r!=null) tenbs.Text=r["hoten"].ToString();
					else tenbs.Text="";
				}
				break;
			}
			if (!bHotennt || !bNamsinhnt) SendKeys.Send("{F4}");
		}

		private void hoten_Validated(object sender, System.EventArgs e)
		{
			if (!bNamsinhnt) SendKeys.Send("{F4}");
		}

		private void mabd_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==mabd)
			{
				if (butMoi.Enabled) return;
				Filter_mabd(mabd.Text);
				listDMBD.Tonkhoct(mabd,tenbd,soluong,mabd.Location.X,mabd.Location.Y + mabd.Height-2,mabd.Width+lTen.Width+tenbd.Width+lTenhc.Width+tenhc.Width+lMabd.Width,mabd.Height+5);
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

		private void tenbs_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listDMBS.Focus(); 
			else if (e.KeyCode==Keys.Enter)
			{
				if (listDMBS.Visible) listDMBS.Focus();
				else SendKeys.Send("{Tab}");
			}		
		}

		private void tenbs_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tenbs)
			{
				Filt_dmbs(tenbs.Text);
				listDMBS.BrowseToDanhmuc(tenbs,mabs,butThem);
			}
		}

		private void Filt_dmbs(string ten)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listDMBS.DataSource];
				DataView dv=(DataView)cm.List;
				dv.RowFilter="hoten like '%"+ten.Trim()+"%'";
			}
			catch{}
		}

		private void tenbs_Validated(object sender, System.EventArgs e)
		{
			if(!listDMBS.Focused) listDMBS.Hide();
		}

		private void frmXuatban_mabn_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.F3:
					if(butMua.Enabled)butMua_Click(sender,e);
					break;
				case Keys.F6:
					if(butIn.Enabled)butIn_Click(sender,e);
					break;
				case Keys.F5:
					if(butLuu.Enabled)butLuu_Click(sender,e);
					break;
				case Keys.F7:
					if(butDonthuoc.Enabled)butDonthuoc_Click(sender,e);
					break;
				case Keys.F10:
					if(butKetthuc.Enabled)butKetthuc_Click(sender,e);
					break;
			}
		}

		public void RefreshChildren(string text)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[cmbSophieu.DataSource];
				DataView dv=(DataView)cm.List;			
				dv.RowFilter="hoten like '%"+text.Trim()+"%' or mabn like '%"+text+"%'";
				if(cmbSophieu.SelectedIndex>=0)
					load_head(long.Parse(cmbSophieu.SelectedValue.ToString()));
				else
					load_head(0);
			}
			catch(Exception ex){MessageBox.Show(ex.Message);}
		}

		private void load_head(long id)
		{
			try
			{
				l_id=id;
				r=d.getrowbyid(dtll,"id="+l_id);
				DataRow r1;
				if (r!=null)
				{
					sophieu.Text=r["mabn"].ToString();
					hoten.Text=r["hoten"].ToString();
					namsinh.Text=r["namsinh"].ToString();
					ngaysp.Text=r["ngay"].ToString();
					makp.Text=r["makp"].ToString();
					r1=d.getrowbyid(dtduockp,"id="+int.Parse(makp.Text));
					if (r1!=null) tenkp.Text=r1["ten"].ToString();
					else tenkp.Text="";
					mabs.Text=r["mabs"].ToString();
					r1=d.getrowbyid(dtbs,"ma='"+mabs.Text+"'");
					if (r1!=null) tenbs.Text=r1["hoten"].ToString();
					else tenbs.Text="";
					loai.SelectedValue=r["loai"].ToString();
					s_ngaysp=ngaysp.Text;
					i_userid=int.Parse(r["userid"].ToString());
					toaso.Text=r["sotoa"].ToString();
				}
			}
			catch{l_id=0;}
			load_grid();
			ref_text();
			if (bGiaban) tongcong_giaban(dtct);
			else tongcong(dtct);
			sum.Text=d_tongcong.ToString("###,###,###,##0");
			string s_chu=doiso.Doiso_Unicode(Convert.ToInt64(d_tongcong.ToString()).ToString());
			label14.Text=s_chu;
		}

		private void butMua_Click(object sender, System.EventArgs e)
		{
			if (cmbSophieu.Items.Count==0) return;
			if (bKhoaso)
			{
				MessageBox.Show("Số liệu tháng "+s_mmyy.Substring(0,2)+" năm "+s_mmyy.Substring(2,2)+" đã khóa !\nNếu cần thay đổi thì vào mục khai báo hệ thống",d.Msg);
				return;
			}
			if (MessageBox.Show("Đồng ý mua thêm nguyên đơn ?",d.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
			{
				bNew=true;
				if (!sophieu.Enabled) sophieu.Text=d.get_stt(dtll,"mabn").ToString();
				dataGrid1.Focus();
				if (MessageBox.Show("Có sửa thuốc không ?",d.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)==DialogResult.No)
					butLuu_Click(sender,e);
				else ena_object(true);
			}
		}

		private void listDMBD_DoubleClick(object sender, System.EventArgs e)
		{
			try
			{
				mabd.Text=listDMBD.Text;
				r=d.getrowbyid(dtton,"stt="+int.Parse(mabd.Text));
				if (r!=null)
				{
					mabd.Text=r["ma"].ToString();
					tenbd.Text=r["ten"].ToString();
					tenhc.Text=r["tenhc"].ToString();
					dang.Text=r["dang"].ToString();
					makho.SelectedValue=r["makho"].ToString();
					manguon.SelectedValue=r["manguon"].ToString();
					if (bGiaban)
					{
						d_giaban=decimal.Parse(r["giaban"].ToString());
						giaban.Text=d_giaban.ToString("###,###,###,###");
					}
					listDMBD.Hide();
					soluong.Focus();
				}
			}
			catch{}
		}

		private void makp_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void makp_Validated(object sender, System.EventArgs e)
		{
			try
			{
				if (makp.Text!="")
				{
					DataRow r1=d.getrowbyid(dtduockp,"id="+int.Parse(makp.Text));
					if (r1!=null) tenkp.Text=r1["ten"].ToString();
				}
			}
			catch{}
		}

		private void mabs_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void mabs_Validated(object sender, System.EventArgs e)
		{
			if (mabs.Text!="")
			{
				DataRow r1=d.getrowbyid(dtbs,"ma='"+mabs.Text+"'");
				if (r1!=null) tenbs.Text=r1["hoten"].ToString();			
			}
		}

		private void makp_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			d.MaskDigit(e);
		}

		private void butDonthuoc_Click(object sender, System.EventArgs e)
		{
			frmDuyetdon f=new frmDuyetdon(d,dtll,i_nhom,s_kho,s_ngay,i_userid,s_mmyy,i_loai,s_makho,s_manguon,s_userid,loai.Text);
			f.ShowDialog(this);
			if (f.bOk)
			{
				dtll=f.dtll;
				dtll.AcceptChanges();
				cmbSophieu.Refresh();
				if (dtll.Rows.Count>0) 
				{
					cmbSophieu.SelectedIndex=dtll.Rows.Count-1;//l_id=long.Parse(cmbSophieu.SelectedValue.ToString());
					l_id=long.Parse(cmbSophieu.SelectedValue.ToString());
				}
				else l_id=0;
				load_head(l_id);
			}
		}
		private void tongcong_n_lien(DataTable dt, int i_lien)
		{

			d_tongcong=0;
			int i=0,j=0;
			foreach(DataRow r1 in dt.Rows) 
			{
				d_tongcong+=decimal.Parse(r1["sotienban"].ToString());
				r1["lien"]=1;
				i+=1;
			}
			if(i_lien>1)
			{
				for(j=i;j<6;j++)
				{
					DataRow lr=dt.NewRow();
					lr["lien"]=1;
					lr["stt"]=j;
					lr["soluong"]=0;
					dt.Rows.Add(lr);
				}			
				DataTable tmpdt=dt.Copy();
				j=0;
				for(int k=2;k<4;k++)
				{				
					foreach(DataRow lr2 in tmpdt.Rows)
					{									
						dt.Rows.Add(lr2.ItemArray);
						dt.Rows[dt.Rows.Count-1]["lien"]=k;
					}				
				}
			}
		}

		private void timkiem_TextChanged(object sender, System.EventArgs e)
		{
			RefreshChildren(timkiem.Text);
		}

		private void timkiem_Enter(object sender, System.EventArgs e)
		{
			timkiem.Text="";
		}

		private void mabd_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listDMBD.Focus();
			else if (e.KeyCode==Keys.Enter)
			{
				sql="ma like '"+mabd.Text.Trim()+"%'";
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

		private void get_items(int tt)
		{
			try
			{
				r=d.getrowbyid(dtton,"stt="+tt);
				if (r!=null)
				{
					mabd.Text=r["ma"].ToString();
					tenbd.Text=r["ten"].ToString();
					tenhc.Text=r["tenhc"].ToString();
					dang.Text=r["dang"].ToString();
					makho.SelectedValue=r["makho"].ToString();
					manguon.SelectedValue=r["manguon"].ToString();
					if (bGiaban)
					{
						d_giaban=decimal.Parse(r["giaban"].ToString());
						giaban.Text=d_giaban.ToString("###,###,###,###");
					}
				}
			}
			catch{}
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			if (!KiemtraHead()) return;
			bEdit=false;
			upd_table(dtct);
			dtct.AcceptChanges();
			upd_data();
			printer(i_sotoa);
			try
			{
				if (dtll.Rows.Count>0) cmbSophieu.SelectedIndex=dtll.Rows.Count-1;
			}
			catch{}
			if (cmbSophieu.Items.Count>0) l_id=long.Parse(cmbSophieu.SelectedValue.ToString());
			else l_id=0;
			load_head(l_id);

		}

		private void upd_data()
		{
			i_old=(bNew)?0:1;
			l_id=(bNew)?d.get_id_xuatban:l_id;
			i_sotoa=d.get_sotoa_xuatban(s_mmyy,l_id,i_quayban,ngaysp.Text);
			if (!bNgtru_mabn) sophieu.Text=i_sotoa.ToString();
			if (!d.upd_ngtrull(l_id,i_nhom,(bNgtru_mabn)?sophieu.Text:i_sotoa.ToString(),hoten.Text,namsinh.Text,ngaysp.Text,mabs.Text,i_makp,int.Parse(loai.SelectedValue.ToString()),s_mmyy,i_userid,i_sotoa,0))
			{
				MessageBox.Show("Không cập nhật được thông tin đơn thuốc !",d.Msg);
				return;
			}
			ena_object(false);
			load_tonct();
			if (!bNew)
			{
				foreach(DataRow r1 in dsxoa.Tables[0].Rows)
					d.execute_data(s_mmyy,"delete from d_ngtruct where id="+l_id+" and stt="+long.Parse(r1["stt"].ToString()));
				foreach(DataRow r1 in dtsave.Rows)
					d.upd_tonkhoct_xuat(d.delete,s_mmyy,long.Parse(r1["sttt"].ToString()),int.Parse(r1["makho"].ToString()),int.Parse(r1["manguon"].ToString()),int.Parse(r1["nhomcc"].ToString()),int.Parse(r1["mabd"].ToString()),r1["handung"].ToString(),r1["losx"].ToString(),decimal.Parse(r1["soluong"].ToString()),decimal.Parse(r1["sotien"].ToString()),decimal.Parse(r1["giaban"].ToString()),decimal.Parse(r1["giamua"].ToString()));
			}
			dtct=d.get_xuatban(null,dtct,dttonct,l_id);
			foreach(DataRow r1 in dtct.Rows)
			{
				d.upd_ngtruct(s_mmyy,l_id,int.Parse(r1["stt"].ToString()),long.Parse(r1["sttt"].ToString()),int.Parse(r1["makho"].ToString()),int.Parse(r1["manguon"].ToString()),int.Parse(r1["nhomcc"].ToString()),int.Parse(r1["mabd"].ToString()),r1["handung"].ToString(),r1["losx"].ToString(),decimal.Parse(r1["soluong"].ToString()),decimal.Parse(r1["sotien"].ToString()),decimal.Parse(r1["giaban"].ToString()),decimal.Parse(r1["giamua"].ToString()));
				d.upd_tonkhoct_xuat(d.insert,s_mmyy,long.Parse(r1["sttt"].ToString()),int.Parse(r1["makho"].ToString()),int.Parse(r1["manguon"].ToString()),int.Parse(r1["nhomcc"].ToString()),int.Parse(r1["mabd"].ToString()),r1["handung"].ToString(),r1["losx"].ToString(),decimal.Parse(r1["soluong"].ToString()),decimal.Parse(r1["sotien"].ToString()),decimal.Parse(r1["giaban"].ToString()),decimal.Parse(r1["giamua"].ToString()));
			}
			//d.updrec_ngtrull(dtll,l_id,sophieu.Text,hoten.Text,namsinh.Text,ngaysp.Text,mabs.Text,i_makp,int.Parse(loai.SelectedValue.ToString()),0,i_userid,i_sotoa,0);
			d.updrec_ngtrull(dtll,l_id,(bNgtru_mabn)?sophieu.Text:i_sotoa.ToString(),hoten.Text,namsinh.Text,ngaysp.Text,mabs.Text,i_makp,int.Parse(loai.SelectedValue.ToString()),0,i_userid,i_sotoa,0);
//			try
//			{
//				if (i_old==0 && dtll.Rows.Count>0) cmbSophieu.SelectedIndex=dtll.Rows.Count-1;
//			}
//			catch{}
			load_grid();
			if (bGiaban) tongcong_giaban(dtct);
			else tongcong(dtct);
			sum.Text=d_tongcong.ToString("###,###,###,##0");
			string s_chu=doiso.Doiso_Unicode(Convert.ToInt64(d_tongcong.ToString()).ToString());
			label14.Text=s_chu;
			label12.Text=dtll.Rows.Count.ToString("###,###");
			butMoi.Focus();
			toaso.Text=i_sotoa.ToString();
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			if (cmbSophieu.Items.Count==0 || toaso.Text=="") return;
			printer(int.Parse(toaso.Text));
		}

		private void printer(int toa)
		{
			if (dtct.Rows.Count==0) return;
			DataTable dt=d.get_data(s_mmyy,"select lanin from d_ngtrull where id="+l_id).Tables[0];
			int lanin=(dt.Rows.Count>0)?int.Parse(dt.Rows[0]["lanin"].ToString()):0;
			if (lanin>0)
			{
				lanin++;
				if (MessageBox.Show("Lần in thứ "+lanin.ToString()+"\nBạn có muốn in ?",d.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.No) return;
			}
			DataTable ldt=dtct.Copy();
			ldt.Columns.Add("lien");
			DataSet lds=new DataSet();
			lds.ReadXml("..\\..\\..\\xml\\d_lienbanle.xml");
			int i_lien=lds.Tables[0].Rows.Count;
			string d_tenrpt=(i_lien>1)?"d_xuatban.rpt":"d_xuatban_a5.rpt";
			string s_c8=(lanin>1)?"Lần in thứ "+lanin.ToString():"";
			tongcong_n_lien(ldt,i_lien);
			decimal d_sotoa=Convert.ToDecimal(toa);
			tmp_ngaygio=s_ngay+" "+DateTime.Now.Hour.ToString().PadLeft(2,'0')+":"+DateTime.Now.Minute.ToString().PadLeft(2,'0');
			string s_toa=d_sotoa.ToString("###,###")+" ("+tmp_ngaygio+" - "+loai.Text+")";
			toaso.Text=d_sotoa.ToString("###,###");
			sum.Text=d_tongcong.ToString("###,###,###,##0");
			string s_chu=doiso.Doiso_Unicode(Convert.ToInt64(d_tongcong.ToString()).ToString());
			string s_tenkho=(s_makho=="")?"":makho.Text,lydo=loai.Text;
			r=d.getrowbyid(dtll,"id="+l_id);
			if (r!=null) r["done"]=1;
			d.execute_data(s_mmyy,"update d_ngtrull set lanin=lanin+1,done=1 where id="+l_id);
			string s_hoten=hoten.Text.Trim();
			if (bNgtru_mabn) s_hoten+="["+sophieu.Text.Trim()+"]";
			if (d.bPreview)
			{
				frmReport f=new frmReport(d,ldt,d_tenrpt,s_toa,s_hoten,tenbs.Text,tenkp.Text,ngaysp.Text,s_userid,s_chu,s_c8,"","");
				f.ShowDialog();
			}
			else
			{
				try
				{
					ReportDocument oRpt=new ReportDocument();
					oRpt.Load("..\\..\\..\\report\\"+d_tenrpt,OpenReportMethod.OpenReportByTempCopy);
					oRpt.SetDataSource(ldt);
					//oRpt.SetDataSource(dtct);
					oRpt.DataDefinition.FormulaFields["soyte"].Text="'"+d.Syte+"'";
					oRpt.DataDefinition.FormulaFields["benhvien"].Text="'"+d.Tenbv+"'";
					oRpt.DataDefinition.FormulaFields["c1"].Text="'"+s_toa+"'";//cmbSophieu.Text
					oRpt.DataDefinition.FormulaFields["c2"].Text="'"+s_hoten+"'";
					oRpt.DataDefinition.FormulaFields["c3"].Text="'"+tenbs.Text+"'";
					oRpt.DataDefinition.FormulaFields["c4"].Text="'"+tenkp.Text+"'";
					oRpt.DataDefinition.FormulaFields["c5"].Text="'"+ngaysp.Text+"'";
					oRpt.DataDefinition.FormulaFields["c6"].Text="'"+s_userid+"'";
					oRpt.DataDefinition.FormulaFields["c7"].Text="'"+s_chu+"'";
					oRpt.DataDefinition.FormulaFields["c8"].Text="'"+s_c8+"'";
					oRpt.DataDefinition.FormulaFields["c9"].Text="";
					oRpt.DataDefinition.FormulaFields["c10"].Text="";
					oRpt.DataDefinition.FormulaFields["giamdoc"].Text="";
					oRpt.DataDefinition.FormulaFields["phutrach"].Text="";
					oRpt.DataDefinition.FormulaFields["thongke"].Text="";
					oRpt.DataDefinition.FormulaFields["ketoan"].Text="";
					oRpt.DataDefinition.FormulaFields["thukho"].Text="";
					oRpt.DataDefinition.FormulaFields["l_soluong"].Text=i_soluong_le.ToString();
					oRpt.DataDefinition.FormulaFields["l_dongia"].Text=i_dongia_le.ToString();
					oRpt.DataDefinition.FormulaFields["l_thanhtien"].Text=i_thanhtien_le.ToString();
					//oRpt.PrintOptions.PaperSize=PaperSize.PaperA4;
					//oRpt.PrintOptions.PaperOrientation=PaperOrientation.Portrait;
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
				catch(Exception ex)
				{
					MessageBox.Show(ex.ToString());
					return;
				}
			}
		}
	}
}
