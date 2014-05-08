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
	public class frmXuatban_save : System.Windows.Forms.Form
	{
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
		private string s_mmyy,s_ngay,sql,s_ngaysp,s_makho,s_kho,s_makp,s_userid;
		private int i_nhom,i_userid,i_mabd,i_old,i_songay,i_loai,i_makp;
		private long l_id,l_sttt;
		private decimal d_soluong,d_dongia,d_sotien,d_giaban,d_soluongton,d_soluongcu,d_sotiencu,d_tongcong,d_sotienban;
		private bool bKhoaso,bNew,bEdit=true,bGiaban,bAdmin;
		private AccessData d;
		private Doisototext doiso=new Doisototext();
		private DataTable dttonct=new DataTable();
		private DataTable dtton=new DataTable();
		private DataTable dtll=new DataTable();
		private DataTable dtct=new DataTable();
		private DataTable dtsave=new DataTable();
		private DataTable dtduockp=new DataTable();
		private DataTable dtbs=new DataTable();
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
		private System.Windows.Forms.Button butTim;
		private frmMain parent;
		private System.Windows.Forms.Button butMua;
		private System.Windows.Forms.Button butDonthuoc;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmXuatban_save(AccessData acc,int loai,string mmyy,string ngay,int nhom,int userid,string kho,string makp,string title,bool b_giaban,string user,bool admin)
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmXuatban_save));
			this.label1 = new System.Windows.Forms.Label();
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
			this.butTim = new System.Windows.Forms.Button();
			this.butMua = new System.Windows.Forms.Button();
			this.butDonthuoc = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(104, 7);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(46, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Mã BN :";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
			this.butMoi.Location = new System.Drawing.Point(75, 490);
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
			this.butSua.Location = new System.Drawing.Point(129, 490);
			this.butSua.Name = "butSua";
			this.butSua.Size = new System.Drawing.Size(56, 28);
			this.butSua.TabIndex = 28;
			this.butSua.Text = "&Sữa";
			this.butSua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.butSua.Click += new System.EventHandler(this.butSua_Click);
			// 
			// butLuu
			// 
			this.butLuu.Enabled = false;
			this.butLuu.Image = ((System.Drawing.Bitmap)(resources.GetObject("butLuu.Image")));
			this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butLuu.Location = new System.Drawing.Point(186, 490);
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
			this.butThem.Location = new System.Drawing.Point(242, 490);
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
			this.butXoa.Location = new System.Drawing.Point(307, 490);
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
			this.butBoqua.Location = new System.Drawing.Point(364, 490);
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
			this.butHuy.Location = new System.Drawing.Point(433, 490);
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
			this.butIn.Location = new System.Drawing.Point(542, 490);
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
			this.butKetthuc.Location = new System.Drawing.Point(695, 490);
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
			this.dataGrid1.Location = new System.Drawing.Point(8, 40);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
			this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
			this.dataGrid1.ReadOnly = true;
			this.dataGrid1.RowHeaderWidth = 10;
			this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
			this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
			this.dataGrid1.Size = new System.Drawing.Size(776, 368);
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
			this.tenbs.Size = new System.Drawing.Size(224, 21);
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
			this.sum.Enabled = false;
			this.sum.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.sum.Location = new System.Drawing.Point(648, 30);
			this.sum.Name = "sum";
			this.sum.Size = new System.Drawing.Size(136, 21);
			this.sum.TabIndex = 101;
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
			// butTim
			// 
			this.butTim.Image = ((System.Drawing.Bitmap)(resources.GetObject("butTim.Image")));
			this.butTim.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butTim.Location = new System.Drawing.Point(489, 490);
			this.butTim.Name = "butTim";
			this.butTim.Size = new System.Drawing.Size(52, 28);
			this.butTim.TabIndex = 30;
			this.butTim.Text = "&Tìm";
			this.butTim.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.butTim.Click += new System.EventHandler(this.butTim_Click);
			// 
			// butMua
			// 
			this.butMua.Image = ((System.Drawing.Bitmap)(resources.GetObject("butMua.Image")));
			this.butMua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butMua.Location = new System.Drawing.Point(591, 490);
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
			this.butDonthuoc.Location = new System.Drawing.Point(22, 490);
			this.butDonthuoc.Name = "butDonthuoc";
			this.butDonthuoc.Size = new System.Drawing.Size(52, 28);
			this.butDonthuoc.TabIndex = 102;
			this.butDonthuoc.Text = "Đơn";
			this.butDonthuoc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.butDonthuoc.Click += new System.EventHandler(this.butDonthuoc_Click);
			// 
			// frmXuatban_save
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(792, 573);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.butDonthuoc,
																		  this.makp,
																		  this.mabs,
																		  this.butMua,
																		  this.butTim,
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
																		  this.loai,
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
			this.Name = "frmXuatban_save";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Phiếu xuất bán";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmXuatban_save_KeyDown);
			this.Load += new System.EventHandler(this.frmXuatban_save_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void frmXuatban_save_Load(object sender, System.EventArgs e)
		{
			bKhoaso=d.bKhoaso(i_nhom,s_mmyy);
			i_songay=d.Ngaylv_Ngayht;
			s_makho="";
			//s_makho=d.get_dmkho(i_loai).Trim();
			//s_makho=(s_makho=="")?"":s_makho.Substring(0,s_makho.Length-1);

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
			loai.DataSource=d.get_data("select * from d_dmloaint where nhom="+i_nhom+" order by stt").Tables[0];

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
			dtbs=d.get_data("select ma,hoten from dmbs where nhom=0 order by hoten").Tables[0];
			listDMBS.DataSource=dtbs;

			listDuockp.DisplayMember="ID";
			listDuockp.ValueMember="TEN";
			sql="select id,ten from d_duockp where nhom like '%"+i_nhom.ToString()+",%'";
			if (s_makp!="") sql+=" and id in ("+s_makp.Substring(0,s_makp.Length-1)+")";
			sql+=" order by stt";
			dtduockp=d.get_data(sql).Tables[0];
			listDuockp.DataSource=dtduockp;
			sql="select id,mabn,hoten,namsinh,to_char(ngay,'dd/mm/yyyy') ngay,mabs,makp,loai,done,userid from d_ngtrull where nhom="+i_nhom+" and mmyy='"+s_mmyy+"'";
			if (!bAdmin) sql+=" and userid="+i_userid;
			if (d.bLocngoaitru) sql+=" and to_char(ngay,'dd/mm/yyyy')='"+s_ngay+"'";
			sql+=" order by id";
			dtll=d.get_data(s_mmyy,sql).Tables[0];
			cmbSophieu.DisplayMember="MABN";
			cmbSophieu.ValueMember="ID";
			cmbSophieu.DataSource=dtll;
			l_id=(dtll.Rows.Count==0)?0:long.Parse(dtll.Rows[0]["id"].ToString());
			load_head(l_id);
			load_grid();
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
				soluong.Text=d_soluong.ToString("###,###,##0.00");
				dongia.Text=d_dongia.ToString("###,###,###,##0.000");
				sotien.Text=d_sotien.ToString("###,###,###,##0.000");
				giaban.Text=d_giaban.ToString("#,###,###,##0");
				makho.SelectedValue=dataGrid1[i,14].ToString();
				manguon.SelectedValue=dataGrid1[i,15].ToString();
				nhomcc.SelectedValue=dataGrid1[i,16].ToString();
				sttt.Text=dataGrid1[i,17].ToString();
				d_sotienban=d_soluong*d_giaban;
				sotienban.Text=d_sotienban.ToString("###,###,###,##0.000");
				d_soluongcu=d_soluong;
				d_sotiencu=d_sotien;
				if (butLuu.Enabled)
				{
					tenbd.Enabled=sttt.Text=="0";
					if (d.bNhapmaso) mabd.Enabled=tenbd.Enabled;
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
			TextCol.Width = (bGiaban || d.bHoatchat || d.bQuanlyhandung(i_nhom) || d.bQuanlylosx(i_nhom) || d.bQuanlynguon(i_nhom) || d.bQuanlynhomcc(i_nhom))?200:290;
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
			TextCol.HeaderText = "Nhóm cung cấp";
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
			TextCol.Width = 80;
			TextCol.Format="#,###,##0.00";
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "dongia";
			TextCol.HeaderText = "Giá mua";
			TextCol.Width =100;
			TextCol.Format="###,###,##0.000";
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
			TextCol.Format="###,###,###,##0.000";
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
			ngaysp.Enabled=ena;
			if (d.bHotennt) hoten.Enabled=ena;
			loai.Enabled=ena;
			if (d.bNgtru_khoa) tenkp.Enabled=ena;
			if (d.bNgtru_bacsi) tenbs.Enabled=ena;
			if (d.bNamsinhnt) namsinh.Enabled=ena;
			if (d.bNhapmaso) mabd.Enabled=ena;
			if (d.bNgtru_mabn) sophieu.Enabled=ena;
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
			butTim.Enabled=!ena;
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
			else sophieu.Text=d.get_stt(dtll,"mabn").ToString();
			ngaysp.Text=s_ngay;
			s_ngaysp=ngaysp.Text;
			hoten.Text="";
			namsinh.Text="";
			tenkp.Text="";
			makp.Text="";
			mabs.Text="";
			tenbs.Text="";
			sum.Text="0";
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
			dtsave=dtct.Copy();
			emp_head();
			emp_detail();
			bNew=true;
			bEdit=true;
			if (sophieu.Enabled) sophieu.Focus();
			else hoten.Focus();
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
			if (dtll.Rows[cmbSophieu.SelectedIndex]["done"].ToString()=="1" && !bAdmin)
			{
				MessageBox.Show("Đơn thuốc đã in \nBạn không có quyền sữa !",d.Msg);
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
			return true;
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			bEdit=false;
			try
			{
				cmbSophieu.SelectedIndex=i_old;
				l_id=long.Parse(cmbSophieu.SelectedValue.ToString());
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
			if (d.bNhapmaso) mabd.Enabled=true;
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
			d.updrec_ngtruct(dt,int.Parse(stt.Text),l_sttt,i_mabd,mabd.Text,tenbd.Text,tenhc.Text,dang.Text,makho.Text,(manguon.SelectedIndex==-1)?"":manguon.Text,(nhomcc.SelectedIndex==-1)?"":nhomcc.Text,handung.Text,losx.Text,d_soluong,d_dongia,d_sotien,d_giaban,d_soluong*d_giaban,int.Parse(makho.SelectedValue.ToString()),(manguon.SelectedIndex==-1)?0:int.Parse(manguon.SelectedValue.ToString()),(nhomcc.SelectedIndex==-1)?0:int.Parse(nhomcc.SelectedValue.ToString()),dtton,d_soluongcu,d_sotiencu);
			if (bGiaban) tongcong_giaban(dtct);
			else tongcong(dtct);
			sum.Text=d_tongcong.ToString("###,###,##0.000");
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
						if (bGiaban)
						{
							d_giaban=decimal.Parse(r["giaban"].ToString());
							giaban.Text=d_giaban.ToString("###,###,###,###");
						}
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
				d_sotien=(sotien.Text!="")?decimal.Parse(sotien.Text):0;
				d_dongia=Math.Round(d_sotien/d_soluong,3);
				dongia.Text=d_dongia.ToString("###,###,###,##0.000");
				d_giaban=(giaban.Text!="")?decimal.Parse(giaban.Text):0;
				d_sotienban=d_soluong*d_giaban;
				sotienban.Text=d_sotienban.ToString("###,###,###,##0.000");
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
			upd_table(dtct);
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
				if (dtll.Rows[cmbSophieu.SelectedIndex]["done"].ToString()=="1" && !bAdmin)
				{
					MessageBox.Show("Đơn thuốc đã in \nBạn không có quyền hủy !",d.Msg);
					return;
				}
				if (MessageBox.Show("Đồng ý hủy số phiếu này ?",d.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
				{
					l_id=long.Parse(cmbSophieu.SelectedValue.ToString());
					d.execute_data(s_mmyy,"delete from d_ngtruct where id="+l_id);
					d.execute_data(s_mmyy,"delete from d_ngtrull where id="+l_id);
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
			sql="select rownum stt,d.ten tennguon,b.ma,trim(b.ten)||' '||b.hamluong ten,b.tenhc,b.dang,c.ten tenkho,a.tondau+a.slnhap-a.slxuat-a.slyeucau soluong,b.id,a.makho,b.giaban,a.manguon from d_tonkhoth a,"+d.user+".d_dmbd b,"+d.user+".d_dmkho c,"+d.user+".d_dmnguon d where a.mabd=b.id and a.makho=c.id and a.manguon=d.id and a.mmyy='"+s_mmyy+"'";
			if (s_makho!="") sql+=" and a.makho in ("+s_makho+")";
			else if (s_kho!="") sql+=" and a.makho in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			sql+=" order by b.ten";
			dtton=d.get_data(s_mmyy,sql).Tables[0];
			listDMBD.DataSource=dtton;
		}
		private void load_tonct()
		{
			sql="select a.*,b.ten tennguon,c.ten tennhomcc from d_tonkhoct a,"+d.user+".d_dmnguon b,"+d.user+".d_nhomcc c where a.manguon=b.id and a.nhomcc=c.id and a.mmyy='"+s_mmyy+"'";
			if (s_kho!="") sql+=" and a.makho in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			else if (s_makho!="") sql+=" and a.makho in ("+s_makho+")";
			sql+=" order by a.stt";
			dttonct=d.get_data(s_mmyy,sql).Tables[0];
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			if (!KiemtraHead()) return;
			bEdit=false;
			upd_table(dtct);
			dtct.AcceptChanges();
			upd_data();
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

		private void butIn_Click(object sender, System.EventArgs e)
		{
			if (dtct.Rows.Count==0) return;
			DataTable dt=d.get_data(s_mmyy,"select lanin from d_ngtrull where id="+l_id).Tables[0];
			int lanin=(dt.Rows.Count>0)?int.Parse(dt.Rows[0]["lanin"].ToString()):0;
			if (lanin>0)
			{
				lanin++;
				if (MessageBox.Show("Lần in thứ "+lanin.ToString()+"\nBạn có muốn in ?",d.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.No) return;
			}
			tongcong(dtct);
			string s_tenkho=(s_makho=="")?"":makho.Text,lydo=loai.Text;
			if (d.bPreview)
			{
				frmReport f=new frmReport(d,dtct,"d_xuatban.rpt",cmbSophieu.Text,hoten.Text,tenbs.Text,tenkp.Text,ngaysp.Text,s_userid,"","","","");
				f.ShowDialog();
			}
			else
			{
				ReportDocument oRpt=new ReportDocument();
				oRpt.Load("..\\..\\..\\report\\d_xuatban.rpt",OpenReportMethod.OpenReportByTempCopy);
				oRpt.SetDataSource(dtct);
				oRpt.DataDefinition.FormulaFields["soyte"].Text="'"+d.Tenbv+"'";
				oRpt.DataDefinition.FormulaFields["benhvien"].Text="'"+d.Diachi+"'";
				oRpt.DataDefinition.FormulaFields["c1"].Text="'"+cmbSophieu.Text+"'";
				oRpt.DataDefinition.FormulaFields["c2"].Text="'"+hoten.Text+"'";
				oRpt.DataDefinition.FormulaFields["c3"].Text="'"+tenbs.Text+"'";
				oRpt.DataDefinition.FormulaFields["c4"].Text="'"+tenkp.Text+"'";
				oRpt.DataDefinition.FormulaFields["c5"].Text="'"+ngaysp.Text+"'";
				oRpt.DataDefinition.FormulaFields["c6"].Text="'"+s_userid+"'";
				oRpt.DataDefinition.FormulaFields["c7"].Text="";
				oRpt.DataDefinition.FormulaFields["c8"].Text="";
				oRpt.DataDefinition.FormulaFields["c9"].Text="";
				oRpt.DataDefinition.FormulaFields["c10"].Text="";
				oRpt.DataDefinition.FormulaFields["giamdoc"].Text="";
				oRpt.DataDefinition.FormulaFields["phutrach"].Text="";
				oRpt.DataDefinition.FormulaFields["thongke"].Text="";
				oRpt.DataDefinition.FormulaFields["ketoan"].Text="";
				oRpt.DataDefinition.FormulaFields["thukho"].Text="";
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
			r=d.getrowbyid(dtll,"id="+l_id);
			if (r!=null) r["done"]=1;
			d.execute_data(s_mmyy,"update d_ngtrull set done=1,lanin=lanin+1 where id="+l_id);
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
			//if (sophieu.Text.Trim().Length==8)
			//{
				foreach(DataRow r1 in d.get_data("select hoten,namsinh from btdbn where mabn='"+sophieu.Text+"'").Tables[0].Rows)
				{
					hoten.Text=r1["hoten"].ToString();
					namsinh.Text=r1["namsinh"].ToString();
					break;
				}
			//}
			if (!d.bHotennt || !d.bNamsinhnt) SendKeys.Send("{F4}");
		}

		private void hoten_Validated(object sender, System.EventArgs e)
		{
			if (!d.bNamsinhnt) SendKeys.Send("{F4}");
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

		private void frmXuatban_save_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.F3:
					butMua_Click(sender,e);
					break;
				case Keys.F6:
					butIn_Click(sender,e);
					break;
				case Keys.F5:
					butLuu_Click(sender,e);
					break;
				case Keys.F7:
					butDonthuoc_Click(sender,e);
					break;
				case Keys.F10:
					butKetthuc_Click(sender,e);
					break;
			}
		}

		private void butTim_Click(object sender, System.EventArgs e)
		{
//			frmTimxuatban f=new frmTimxuatban(this);
//			f.MdiParent=parent;
//			f.RefreshText("");
//			f.Show();
		}

		public void RefreshChildren(string text)
		{
			try
			{
				sql="hoten like '%"+text.Trim()+"%'";
				r=d.getrowbyid(dtll,sql);
				if (r!=null)
				{
					cmbSophieu.SelectedValue=r["id"].ToString();
					l_id=long.Parse(r["id"].ToString());
					load_head(l_id);
				}
			}
			catch{}
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
				}
			}
			catch{l_id=0;}
			load_grid();
			ref_text();
			if (bGiaban) tongcong_giaban(dtct);
			else tongcong(dtct);
			sum.Text=d_tongcong.ToString("###,###,##0.000");
		}

		private void butMua_Click(object sender, System.EventArgs e)
		{
			if (dtll.Rows.Count==0) return;
			if (bKhoaso)
			{
				MessageBox.Show("Số liệu tháng "+s_mmyy.Substring(0,2)+" năm "+s_mmyy.Substring(2,2)+" đã khóa !\nNếu cần thay đổi thì vào mục khai báo hệ thống",d.Msg);
				return;
			}
			if (MessageBox.Show("Đồng ý mua thêm nguyên đơn ?",d.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
			{
				bNew=true;
				if (!sophieu.Enabled) sophieu.Text=d.get_stt(dtll,"mabn").ToString();
				upd_data();
			}
		}

		private void upd_data()
		{
			i_old=(bNew)?0:1;
			l_id=(bNew)?d.get_id_ngtru:l_id;
			if (!d.upd_ngtrull(l_id,i_nhom,sophieu.Text,hoten.Text,namsinh.Text,ngaysp.Text,mabs.Text,i_makp,int.Parse(loai.SelectedValue.ToString()),s_mmyy,i_userid,0))
			{
				MessageBox.Show("Không cập nhật được thông tin ngoại trú !",d.Msg);
				return;
			}
			if (dsxoa.Tables[0].Rows.Count>0)
			{
				foreach(DataRow r1 in dtsave.Rows)
					d.execute_data(s_mmyy,"delete from d_ngtruct where id="+l_id+" and stt="+long.Parse(r1["stt"].ToString()));
			}
			load_tonct();
			dtct=d.get_xuatban(dtsave,dtct,dttonct);
			foreach(DataRow r1 in dtct.Rows)
				d.upd_ngtruct(s_mmyy,l_id,int.Parse(r1["stt"].ToString()),long.Parse(r1["sttt"].ToString()),int.Parse(r1["makho"].ToString()),int.Parse(r1["manguon"].ToString()),int.Parse(r1["nhomcc"].ToString()),int.Parse(r1["mabd"].ToString()),r1["handung"].ToString(),r1["losx"].ToString(),decimal.Parse(r1["soluong"].ToString()),decimal.Parse(r1["sotien"].ToString()),decimal.Parse(r1["giaban"].ToString()));
			d.updrec_ngtrull(dtll,l_id,sophieu.Text,hoten.Text,namsinh.Text,ngaysp.Text,mabs.Text,i_makp,int.Parse(loai.SelectedValue.ToString()),0,i_userid,0);
			try
			{
				if (i_old==0 && dtll.Rows.Count>0) cmbSophieu.SelectedIndex=dtll.Rows.Count-1;
			}
			catch{}
			ena_object(false);
			load_grid();
			if (bGiaban) tongcong_giaban(dtct);
			else tongcong(dtct);
			sum.Text=d_tongcong.ToString("###,###,##0.000");
			butMoi.Focus();
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
			frmDuyetdon f=new frmDuyetdon(d,dtll,i_nhom,s_kho,s_ngay,i_userid,s_mmyy,i_loai);
			f.ShowDialog(this);
			if (f.bOk)
			{
				dtll=f.dtll;
				dtll.AcceptChanges();
				cmbSophieu.Refresh();
				if (dtll.Rows.Count>0) l_id=long.Parse(cmbSophieu.SelectedValue.ToString());
				else l_id=0;
				load_head(l_id);
			}
		}
	}
}
