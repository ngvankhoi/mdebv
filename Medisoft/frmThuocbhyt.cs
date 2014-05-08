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

namespace Medisoft
{
	/// <summary>
	/// Summary description for frmXkhac.
	/// </summary>
	public class frmThuocbhyt : System.Windows.Forms.Form
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
		private string s_mmyy,s_ngay,sql,s_ngaysp,s_makho,s_kho,s_mabn,s_mabv,s_manguon;
		private string s_Hoten,s_Namsinh,s_Diachi,s_Sothe,s_Tenkp,s_Tenbs,s_Maicd,s_Chandoan,s_Makp,s_Mabs;
		private int i_nhom,i_userid,i_mabd,i_old,i_songay,i_loai;
		private long l_id,l_sttt,l_maql;
		private decimal d_soluong,d_dongia,d_sotien,d_soluongton,d_soluongcu,d_tongcong;
		private bool bKhoaso,bNew,bEdit=true;
		private LibDuoc.AccessData d=new LibDuoc.AccessData();
		private LibMedi.AccessData m=new LibMedi.AccessData();
		private Doisototext doiso=new Doisototext();
		private DataTable dttonct=new DataTable();
		private DataTable dtton=new DataTable();
		private DataTable dtll=new DataTable();
		private DataTable dtct=new DataTable();
		private DataTable dtsave=new DataTable();
		private DataTable dtcachdung=new DataTable();
		private DataTable dtdstt=new DataTable();
		private DataTable dtkp=new DataTable();
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
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox manguon;
		private System.Windows.Forms.ComboBox nhomcc;
		private System.Windows.Forms.TextBox stt;
		private System.Windows.Forms.TextBox sttt;
		private System.Windows.Forms.Label lMabd;
		private System.Windows.Forms.ComboBox makho;
		private System.Windows.Forms.Label label5;
		private System.Drawing.Printing.PrintDocument docToPrint = new System.Drawing.Printing.PrintDocument();
		private PrintDialog p=new PrintDialog();
		private DialogResult result;
		private System.Windows.Forms.Label label4;
		private MaskedTextBox.MaskedTextBox hoten;
		private MaskedTextBox.MaskedTextBox namsinh;
		private System.Windows.Forms.TextBox cachdung;
		private System.Windows.Forms.TextBox diachi;
		private LibList.List listcachdung;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.ComboBox maphu;
		private System.Windows.Forms.TextBox tenbv;
		private System.Windows.Forms.TextBox mabv;
		private LibList.List listDstt;
		private System.Windows.Forms.TextBox sobienlai;
		private System.Windows.Forms.TextBox sothe;
		private System.Windows.Forms.TextBox tenbs;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox tenkp;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.TextBox mabs;
		private System.Windows.Forms.TextBox makp;
		private System.Windows.Forms.TextBox chandoan;
		private MaskedTextBox.MaskedTextBox maicd;
		private LibList.List listBTDKP;
		private LibList.List listDMBS;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmThuocbhyt(string mabn,int loai,string mmyy,string ngay,int nhom,int userid,string kho,string title,long lMaql,string sHoten,string sNamsinh,string sDiachi,string sSothe,string sTenkp,string sTenbs,string sMaicd,string sChandoan,string sMakp,string sMabs,string sMabv)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            i_nhom=nhom;s_kho=kho;i_userid=userid;
			s_mmyy=mmyy;s_ngay=ngay;i_loai=loai;
			s_mabn=mabn;l_maql=lMaql;s_mabv=sMabv;
			s_Hoten=sHoten;s_Namsinh=sNamsinh;s_Diachi=sDiachi;s_Makp=sMakp;s_Mabs=sMabs;
			s_Sothe=sSothe;s_Tenkp=sTenkp;s_Tenbs=sTenbs;s_Maicd=sMaicd;s_Chandoan=sChandoan;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmThuocbhyt));
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
			this.label25 = new System.Windows.Forms.Label();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.label3 = new System.Windows.Forms.Label();
			this.manguon = new System.Windows.Forms.ComboBox();
			this.nhomcc = new System.Windows.Forms.ComboBox();
			this.stt = new System.Windows.Forms.TextBox();
			this.sttt = new System.Windows.Forms.TextBox();
			this.diachi = new System.Windows.Forms.TextBox();
			this.makho = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.hoten = new MaskedTextBox.MaskedTextBox();
			this.namsinh = new MaskedTextBox.MaskedTextBox();
			this.cachdung = new System.Windows.Forms.TextBox();
			this.listcachdung = new LibList.List();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.maphu = new System.Windows.Forms.ComboBox();
			this.tenbv = new System.Windows.Forms.TextBox();
			this.mabv = new System.Windows.Forms.TextBox();
			this.listDstt = new LibList.List();
			this.sobienlai = new System.Windows.Forms.TextBox();
			this.sothe = new System.Windows.Forms.TextBox();
			this.tenbs = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.tenkp = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.mabs = new System.Windows.Forms.TextBox();
			this.makp = new System.Windows.Forms.TextBox();
			this.chandoan = new System.Windows.Forms.TextBox();
			this.maicd = new MaskedTextBox.MaskedTextBox();
			this.listBTDKP = new LibList.List();
			this.listDMBS = new LibList.List();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(112, 7);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(46, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Mã BN :";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(-2, 7);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(48, 23);
			this.label2.TabIndex = 1;
			this.label2.Text = "Ngày :";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(242, 7);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(49, 23);
			this.label9.TabIndex = 8;
			this.label9.Text = "Họ tên :";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(536, 8);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(56, 23);
			this.label10.TabIndex = 9;
			this.label10.Text = "Địa chỉ :";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// ngaysp
			// 
			this.ngaysp.BackColor = System.Drawing.SystemColors.HighlightText;
			this.ngaysp.Enabled = false;
			this.ngaysp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ngaysp.Location = new System.Drawing.Point(43, 7);
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
			this.listDMBD.Location = new System.Drawing.Point(376, 423);
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
			this.lMabd.Location = new System.Drawing.Point(24, 294);
			this.lMabd.Name = "lMabd";
			this.lMabd.Size = new System.Drawing.Size(32, 23);
			this.lMabd.TabIndex = 28;
			this.lMabd.Text = "Mã :";
			this.lMabd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lTen
			// 
			this.lTen.Location = new System.Drawing.Point(128, 294);
			this.lTen.Name = "lTen";
			this.lTen.Size = new System.Drawing.Size(72, 23);
			this.lTen.TabIndex = 29;
			this.lTen.Text = "Tên :";
			this.lTen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// ldvt
			// 
			this.ldvt.Location = new System.Drawing.Point(22, 317);
			this.ldvt.Name = "ldvt";
			this.ldvt.Size = new System.Drawing.Size(34, 23);
			this.ldvt.TabIndex = 30;
			this.ldvt.Text = "ĐVT :";
			this.ldvt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label16
			// 
			this.label16.Location = new System.Drawing.Point(145, 316);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(56, 23);
			this.label16.TabIndex = 31;
			this.label16.Text = "Số lượng :";
			this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label17
			// 
			this.label17.Location = new System.Drawing.Point(312, 316);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(64, 23);
			this.label17.TabIndex = 32;
			this.label17.Text = "Đơn giá :";
			this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label18
			// 
			this.label18.Location = new System.Drawing.Point(0, 340);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(56, 23);
			this.label18.TabIndex = 33;
			this.label18.Text = "Số tiền :";
			this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label20
			// 
			this.label20.Location = new System.Drawing.Point(307, 340);
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
			this.tenbd.Location = new System.Drawing.Point(200, 294);
			this.tenbd.Name = "tenbd";
			this.tenbd.Size = new System.Drawing.Size(264, 21);
			this.tenbd.TabIndex = 14;
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
			this.mabd.Location = new System.Drawing.Point(56, 294);
			this.mabd.Name = "mabd";
			this.mabd.Size = new System.Drawing.Size(52, 21);
			this.mabd.TabIndex = 13;
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
			this.dang.Location = new System.Drawing.Point(56, 317);
			this.dang.Mask = "";
			this.dang.MaxLength = 10;
			this.dang.Name = "dang";
			this.dang.Size = new System.Drawing.Size(88, 21);
			this.dang.TabIndex = 16;
			this.dang.Text = "";
			// 
			// soluong
			// 
			this.soluong.BackColor = System.Drawing.SystemColors.HighlightText;
			this.soluong.Enabled = false;
			this.soluong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.soluong.Location = new System.Drawing.Point(200, 317);
			this.soluong.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
			this.soluong.Name = "soluong";
			this.soluong.Size = new System.Drawing.Size(112, 21);
			this.soluong.TabIndex = 17;
			this.soluong.Text = "";
			this.soluong.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.soluong.Validated += new System.EventHandler(this.soluong_Validated);
			// 
			// dongia
			// 
			this.dongia.BackColor = System.Drawing.SystemColors.HighlightText;
			this.dongia.Enabled = false;
			this.dongia.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.dongia.Location = new System.Drawing.Point(370, 317);
			this.dongia.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
			this.dongia.Name = "dongia";
			this.dongia.Size = new System.Drawing.Size(94, 21);
			this.dongia.TabIndex = 18;
			this.dongia.Text = "";
			this.dongia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// sotien
			// 
			this.sotien.BackColor = System.Drawing.SystemColors.HighlightText;
			this.sotien.Enabled = false;
			this.sotien.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.sotien.Location = new System.Drawing.Point(56, 340);
			this.sotien.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
			this.sotien.Name = "sotien";
			this.sotien.Size = new System.Drawing.Size(104, 21);
			this.sotien.TabIndex = 20;
			this.sotien.Text = "";
			this.sotien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// butMoi
			// 
			this.butMoi.Image = ((System.Drawing.Bitmap)(resources.GetObject("butMoi.Image")));
			this.butMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butMoi.Location = new System.Drawing.Point(39, 369);
			this.butMoi.Name = "butMoi";
			this.butMoi.Size = new System.Drawing.Size(75, 28);
			this.butMoi.TabIndex = 28;
			this.butMoi.Text = "      &Mới";
			this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
			// 
			// butSua
			// 
			this.butSua.Image = ((System.Drawing.Bitmap)(resources.GetObject("butSua.Image")));
			this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butSua.Location = new System.Drawing.Point(116, 369);
			this.butSua.Name = "butSua";
			this.butSua.Size = new System.Drawing.Size(75, 28);
			this.butSua.TabIndex = 29;
			this.butSua.Text = "     &Sửa";
			this.butSua.Click += new System.EventHandler(this.butSua_Click);
			// 
			// butLuu
			// 
			this.butLuu.Enabled = false;
			this.butLuu.Image = ((System.Drawing.Bitmap)(resources.GetObject("butLuu.Image")));
			this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butLuu.Location = new System.Drawing.Point(193, 369);
			this.butLuu.Name = "butLuu";
			this.butLuu.Size = new System.Drawing.Size(75, 28);
			this.butLuu.TabIndex = 30;
			this.butLuu.Text = "     &Lưu";
			this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
			// 
			// butThem
			// 
			this.butThem.Enabled = false;
			this.butThem.Image = ((System.Drawing.Bitmap)(resources.GetObject("butThem.Image")));
			this.butThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butThem.Location = new System.Drawing.Point(270, 369);
			this.butThem.Name = "butThem";
			this.butThem.Size = new System.Drawing.Size(75, 28);
			this.butThem.TabIndex = 26;
			this.butThem.Text = "       &Thêm";
			this.butThem.Click += new System.EventHandler(this.butThem_Click);
			// 
			// butXoa
			// 
			this.butXoa.Enabled = false;
			this.butXoa.Image = ((System.Drawing.Bitmap)(resources.GetObject("butXoa.Image")));
			this.butXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butXoa.Location = new System.Drawing.Point(347, 369);
			this.butXoa.Name = "butXoa";
			this.butXoa.Size = new System.Drawing.Size(75, 28);
			this.butXoa.TabIndex = 27;
			this.butXoa.Text = "       &Xóa";
			this.butXoa.Click += new System.EventHandler(this.butXoa_Click);
			// 
			// butBoqua
			// 
			this.butBoqua.Enabled = false;
			this.butBoqua.Image = ((System.Drawing.Bitmap)(resources.GetObject("butBoqua.Image")));
			this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butBoqua.Location = new System.Drawing.Point(424, 369);
			this.butBoqua.Name = "butBoqua";
			this.butBoqua.Size = new System.Drawing.Size(75, 28);
			this.butBoqua.TabIndex = 31;
			this.butBoqua.Text = "     &Bỏ qua";
			this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
			// 
			// butHuy
			// 
			this.butHuy.Image = ((System.Drawing.Bitmap)(resources.GetObject("butHuy.Image")));
			this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butHuy.Location = new System.Drawing.Point(501, 369);
			this.butHuy.Name = "butHuy";
			this.butHuy.Size = new System.Drawing.Size(75, 28);
			this.butHuy.TabIndex = 32;
			this.butHuy.Text = "     &Hủy";
			this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
			// 
			// butIn
			// 
			this.butIn.Image = ((System.Drawing.Bitmap)(resources.GetObject("butIn.Image")));
			this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butIn.Location = new System.Drawing.Point(578, 369);
			this.butIn.Name = "butIn";
			this.butIn.Size = new System.Drawing.Size(75, 28);
			this.butIn.TabIndex = 33;
			this.butIn.Text = "   &In";
			this.butIn.Click += new System.EventHandler(this.butIn_Click);
			// 
			// butKetthuc
			// 
			this.butKetthuc.Image = ((System.Drawing.Bitmap)(resources.GetObject("butKetthuc.Image")));
			this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butKetthuc.Location = new System.Drawing.Point(655, 369);
			this.butKetthuc.Name = "butKetthuc";
			this.butKetthuc.Size = new System.Drawing.Size(75, 28);
			this.butKetthuc.TabIndex = 34;
			this.butKetthuc.Text = "&Kết thúc";
			this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
			// 
			// cmbSophieu
			// 
			this.cmbSophieu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbSophieu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.cmbSophieu.Location = new System.Drawing.Point(157, 7);
			this.cmbSophieu.Name = "cmbSophieu";
			this.cmbSophieu.Size = new System.Drawing.Size(83, 21);
			this.cmbSophieu.TabIndex = 1;
			this.cmbSophieu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbSophieu_KeyDown);
			this.cmbSophieu.SelectedIndexChanged += new System.EventHandler(this.cmbSophieu_SelectedIndexChanged);
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(608, 340);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(40, 23);
			this.label15.TabIndex = 61;
			this.label15.Text = "Date :";
			this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label24
			// 
			this.label24.Location = new System.Drawing.Point(664, 340);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(48, 23);
			this.label24.TabIndex = 62;
			this.label24.Text = "Lô :";
			this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// handung
			// 
			this.handung.BackColor = System.Drawing.SystemColors.HighlightText;
			this.handung.Enabled = false;
			this.handung.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.handung.Location = new System.Drawing.Point(648, 340);
			this.handung.Mask = "####";
			this.handung.Name = "handung";
			this.handung.Size = new System.Drawing.Size(32, 21);
			this.handung.TabIndex = 24;
			this.handung.Text = "";
			// 
			// losx
			// 
			this.losx.BackColor = System.Drawing.SystemColors.HighlightText;
			this.losx.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.losx.Enabled = false;
			this.losx.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.losx.Location = new System.Drawing.Point(710, 340);
			this.losx.Mask = "&&&&&&&&&&";
			this.losx.MaxLength = 10;
			this.losx.Name = "losx";
			this.losx.Size = new System.Drawing.Size(50, 21);
			this.losx.TabIndex = 25;
			this.losx.Text = "";
			// 
			// tenhc
			// 
			this.tenhc.BackColor = System.Drawing.SystemColors.HighlightText;
			this.tenhc.Enabled = false;
			this.tenhc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tenhc.Location = new System.Drawing.Point(530, 294);
			this.tenhc.Name = "tenhc";
			this.tenhc.Size = new System.Drawing.Size(230, 21);
			this.tenhc.TabIndex = 15;
			this.tenhc.Text = "";
			// 
			// lTenhc
			// 
			this.lTenhc.Location = new System.Drawing.Point(456, 293);
			this.lTenhc.Name = "lTenhc";
			this.lTenhc.Size = new System.Drawing.Size(72, 23);
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
			this.sophieu.Location = new System.Drawing.Point(157, 7);
			this.sophieu.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
			this.sophieu.MaxLength = 8;
			this.sophieu.Name = "sophieu";
			this.sophieu.Size = new System.Drawing.Size(83, 21);
			this.sophieu.TabIndex = 2;
			this.sophieu.Text = "";
			this.sophieu.Validated += new System.EventHandler(this.sophieu_Validated);
			// 
			// label25
			// 
			this.label25.Location = new System.Drawing.Point(460, 316);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(72, 23);
			this.label25.TabIndex = 66;
			this.label25.Text = "Cách dùng :";
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
			this.dataGrid1.Size = new System.Drawing.Size(752, 224);
			this.dataGrid1.TabIndex = 27;
			this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(460, 340);
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
			this.manguon.Location = new System.Drawing.Point(370, 340);
			this.manguon.Name = "manguon";
			this.manguon.Size = new System.Drawing.Size(94, 21);
			this.manguon.TabIndex = 22;
			// 
			// nhomcc
			// 
			this.nhomcc.BackColor = System.Drawing.SystemColors.HighlightText;
			this.nhomcc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.nhomcc.Enabled = false;
			this.nhomcc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.nhomcc.Location = new System.Drawing.Point(530, 340);
			this.nhomcc.Name = "nhomcc";
			this.nhomcc.Size = new System.Drawing.Size(86, 21);
			this.nhomcc.TabIndex = 23;
			// 
			// stt
			// 
			this.stt.Location = new System.Drawing.Point(96, 248);
			this.stt.Name = "stt";
			this.stt.Size = new System.Drawing.Size(24, 20);
			this.stt.TabIndex = 68;
			this.stt.Text = "";
			// 
			// sttt
			// 
			this.sttt.Location = new System.Drawing.Point(64, 248);
			this.sttt.Name = "sttt";
			this.sttt.Size = new System.Drawing.Size(24, 20);
			this.sttt.TabIndex = 69;
			this.sttt.Text = "";
			// 
			// diachi
			// 
			this.diachi.BackColor = System.Drawing.SystemColors.HighlightText;
			this.diachi.Enabled = false;
			this.diachi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.diachi.Location = new System.Drawing.Point(592, 7);
			this.diachi.Name = "diachi";
			this.diachi.Size = new System.Drawing.Size(168, 21);
			this.diachi.TabIndex = 5;
			this.diachi.Text = "";
			this.diachi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.diachi_KeyDown);
			// 
			// makho
			// 
			this.makho.BackColor = System.Drawing.SystemColors.HighlightText;
			this.makho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.makho.Enabled = false;
			this.makho.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.makho.Location = new System.Drawing.Point(200, 340);
			this.makho.Name = "makho";
			this.makho.Size = new System.Drawing.Size(128, 21);
			this.makho.TabIndex = 21;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(160, 340);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(40, 23);
			this.label5.TabIndex = 73;
			this.label5.Text = "Kho :";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(446, 7);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(59, 23);
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
			this.hoten.Location = new System.Drawing.Point(292, 7);
			this.hoten.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
			this.hoten.Name = "hoten";
			this.hoten.Size = new System.Drawing.Size(150, 21);
			this.hoten.TabIndex = 3;
			this.hoten.Text = "";
			// 
			// namsinh
			// 
			this.namsinh.BackColor = System.Drawing.SystemColors.HighlightText;
			this.namsinh.Enabled = false;
			this.namsinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.namsinh.Location = new System.Drawing.Point(504, 8);
			this.namsinh.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
			this.namsinh.MaxLength = 4;
			this.namsinh.Name = "namsinh";
			this.namsinh.Size = new System.Drawing.Size(32, 21);
			this.namsinh.TabIndex = 4;
			this.namsinh.Text = "";
			this.namsinh.Validated += new System.EventHandler(this.namsinh_Validated);
			// 
			// cachdung
			// 
			this.cachdung.BackColor = System.Drawing.SystemColors.HighlightText;
			this.cachdung.Enabled = false;
			this.cachdung.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.cachdung.Location = new System.Drawing.Point(530, 317);
			this.cachdung.Name = "cachdung";
			this.cachdung.Size = new System.Drawing.Size(230, 21);
			this.cachdung.TabIndex = 19;
			this.cachdung.Text = "";
			this.cachdung.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cachdung_KeyDown);
			this.cachdung.Validated += new System.EventHandler(this.cachdung_Validated);
			this.cachdung.TextChanged += new System.EventHandler(this.cachdung_TextChanged);
			// 
			// listcachdung
			// 
			this.listcachdung.ColumnCount = 0;
			this.listcachdung.Location = new System.Drawing.Point(296, 423);
			this.listcachdung.MatchBufferTimeOut = 1000;
			this.listcachdung.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
			this.listcachdung.Name = "listcachdung";
			this.listcachdung.Size = new System.Drawing.Size(75, 17);
			this.listcachdung.TabIndex = 80;
			this.listcachdung.TextIndex = -1;
			this.listcachdung.TextMember = null;
			this.listcachdung.ValueIndex = -1;
			this.listcachdung.Visible = false;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(1, 32);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(45, 23);
			this.label6.TabIndex = 81;
			this.label6.Text = "Số thẻ :";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(152, 32);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(56, 23);
			this.label7.TabIndex = 82;
			this.label7.Text = "Mã phụ :";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(337, 32);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(80, 23);
			this.label8.TabIndex = 83;
			this.label8.Text = "Nơi ĐKKCB :";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// maphu
			// 
			this.maphu.BackColor = System.Drawing.SystemColors.HighlightText;
			this.maphu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.maphu.Enabled = false;
			this.maphu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.maphu.Location = new System.Drawing.Point(207, 31);
			this.maphu.Name = "maphu";
			this.maphu.Size = new System.Drawing.Size(137, 21);
			this.maphu.TabIndex = 7;
			this.maphu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.maphu_KeyDown);
			// 
			// tenbv
			// 
			this.tenbv.BackColor = System.Drawing.SystemColors.HighlightText;
			this.tenbv.Enabled = false;
			this.tenbv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tenbv.Location = new System.Drawing.Point(416, 31);
			this.tenbv.Name = "tenbv";
			this.tenbv.Size = new System.Drawing.Size(344, 21);
			this.tenbv.TabIndex = 8;
			this.tenbv.Text = "";
			this.tenbv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbv_KeyDown);
			this.tenbv.Validated += new System.EventHandler(this.tenbv_Validated);
			this.tenbv.TextChanged += new System.EventHandler(this.tenbv_TextChanged);
			// 
			// mabv
			// 
			this.mabv.BackColor = System.Drawing.SystemColors.HighlightText;
			this.mabv.Enabled = false;
			this.mabv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.mabv.Location = new System.Drawing.Point(144, 232);
			this.mabv.Name = "mabv";
			this.mabv.Size = new System.Drawing.Size(32, 21);
			this.mabv.TabIndex = 87;
			this.mabv.Text = "";
			// 
			// listDstt
			// 
			this.listDstt.ColumnCount = 0;
			this.listDstt.Location = new System.Drawing.Point(456, 423);
			this.listDstt.MatchBufferTimeOut = 1000;
			this.listDstt.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
			this.listDstt.Name = "listDstt";
			this.listDstt.Size = new System.Drawing.Size(75, 17);
			this.listDstt.TabIndex = 88;
			this.listDstt.TextIndex = -1;
			this.listDstt.TextMember = null;
			this.listDstt.ValueIndex = -1;
			this.listDstt.Visible = false;
			// 
			// sobienlai
			// 
			this.sobienlai.BackColor = System.Drawing.SystemColors.HighlightText;
			this.sobienlai.Enabled = false;
			this.sobienlai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.sobienlai.Location = new System.Drawing.Point(152, 208);
			this.sobienlai.Name = "sobienlai";
			this.sobienlai.Size = new System.Drawing.Size(40, 21);
			this.sobienlai.TabIndex = 89;
			this.sobienlai.Text = "";
			// 
			// sothe
			// 
			this.sothe.BackColor = System.Drawing.SystemColors.HighlightText;
			this.sothe.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.sothe.Enabled = false;
			this.sothe.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.sothe.Location = new System.Drawing.Point(43, 31);
			this.sothe.MaxLength = 16;
			this.sothe.Name = "sothe";
			this.sothe.Size = new System.Drawing.Size(117, 21);
			this.sothe.TabIndex = 6;
			this.sothe.Text = "";
			this.sothe.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sothe_KeyDown);
			this.sothe.Validated += new System.EventHandler(this.sothe_Validated);
			// 
			// tenbs
			// 
			this.tenbs.BackColor = System.Drawing.SystemColors.HighlightText;
			this.tenbs.Enabled = false;
			this.tenbs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tenbs.Location = new System.Drawing.Point(207, 54);
			this.tenbs.Name = "tenbs";
			this.tenbs.Size = new System.Drawing.Size(137, 21);
			this.tenbs.TabIndex = 10;
			this.tenbs.Text = "";
			this.tenbs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbs_KeyDown);
			this.tenbs.TextChanged += new System.EventHandler(this.tenbs_TextChanged);
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(159, 54);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(48, 23);
			this.label11.TabIndex = 91;
			this.label11.Text = "Bác sĩ :";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(-10, 54);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(56, 23);
			this.label12.TabIndex = 92;
			this.label12.Text = "P.Khám :";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// tenkp
			// 
			this.tenkp.BackColor = System.Drawing.SystemColors.HighlightText;
			this.tenkp.Enabled = false;
			this.tenkp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tenkp.Location = new System.Drawing.Point(43, 54);
			this.tenkp.Name = "tenkp";
			this.tenkp.Size = new System.Drawing.Size(117, 21);
			this.tenkp.TabIndex = 9;
			this.tenkp.Text = "";
			this.tenkp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenkp_KeyDown);
			this.tenkp.TextChanged += new System.EventHandler(this.tenkp_TextChanged);
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(345, 54);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(72, 23);
			this.label13.TabIndex = 94;
			this.label13.Text = "Chẩn đoán :";
			this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// mabs
			// 
			this.mabs.BackColor = System.Drawing.SystemColors.HighlightText;
			this.mabs.Enabled = false;
			this.mabs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.mabs.Location = new System.Drawing.Point(232, 176);
			this.mabs.Name = "mabs";
			this.mabs.Size = new System.Drawing.Size(32, 21);
			this.mabs.TabIndex = 95;
			this.mabs.Text = "";
			// 
			// makp
			// 
			this.makp.BackColor = System.Drawing.SystemColors.HighlightText;
			this.makp.Enabled = false;
			this.makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.makp.Location = new System.Drawing.Point(432, 200);
			this.makp.Name = "makp";
			this.makp.Size = new System.Drawing.Size(32, 21);
			this.makp.TabIndex = 96;
			this.makp.Text = "";
			// 
			// chandoan
			// 
			this.chandoan.BackColor = System.Drawing.SystemColors.HighlightText;
			this.chandoan.Enabled = false;
			this.chandoan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.chandoan.Location = new System.Drawing.Point(464, 54);
			this.chandoan.Name = "chandoan";
			this.chandoan.Size = new System.Drawing.Size(296, 21);
			this.chandoan.TabIndex = 12;
			this.chandoan.Text = "";
			this.chandoan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chandoan_KeyDown);
			this.chandoan.TextChanged += new System.EventHandler(this.chandoan_TextChanged);
			// 
			// maicd
			// 
			this.maicd.BackColor = System.Drawing.SystemColors.HighlightText;
			this.maicd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.maicd.Enabled = false;
			this.maicd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.maicd.Location = new System.Drawing.Point(416, 54);
			this.maicd.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
			this.maicd.Name = "maicd";
			this.maicd.Size = new System.Drawing.Size(47, 21);
			this.maicd.TabIndex = 11;
			this.maicd.Text = "";
			this.maicd.Validated += new System.EventHandler(this.maicd_Validated);
			// 
			// listBTDKP
			// 
			this.listBTDKP.ColumnCount = 0;
			this.listBTDKP.Location = new System.Drawing.Point(96, 423);
			this.listBTDKP.MatchBufferTimeOut = 1000;
			this.listBTDKP.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
			this.listBTDKP.Name = "listBTDKP";
			this.listBTDKP.Size = new System.Drawing.Size(75, 17);
			this.listBTDKP.TabIndex = 97;
			this.listBTDKP.TextIndex = -1;
			this.listBTDKP.TextMember = null;
			this.listBTDKP.ValueIndex = -1;
			this.listBTDKP.Visible = false;
			// 
			// listDMBS
			// 
			this.listDMBS.ColumnCount = 0;
			this.listDMBS.Location = new System.Drawing.Point(176, 423);
			this.listDMBS.MatchBufferTimeOut = 1000;
			this.listDMBS.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
			this.listDMBS.Name = "listDMBS";
			this.listDMBS.Size = new System.Drawing.Size(75, 17);
			this.listDMBS.TabIndex = 98;
			this.listDMBS.TextIndex = -1;
			this.listDMBS.TextMember = null;
			this.listDMBS.ValueIndex = -1;
			this.listDMBS.Visible = false;
			// 
			// frmThuocbhyt
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(768, 453);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.listDMBS,
																		  this.listBTDKP,
																		  this.maicd,
																		  this.chandoan,
																		  this.tenbs,
																		  this.label13,
																		  this.tenkp,
																		  this.label12,
																		  this.label11,
																		  this.sothe,
																		  this.listDstt,
																		  this.tenbv,
																		  this.maphu,
																		  this.label8,
																		  this.label7,
																		  this.label6,
																		  this.listcachdung,
																		  this.makho,
																		  this.dongia,
																		  this.cachdung,
																		  this.namsinh,
																		  this.hoten,
																		  this.label4,
																		  this.label5,
																		  this.diachi,
																		  this.cmbSophieu,
																		  this.sophieu,
																		  this.ngaysp,
																		  this.label10,
																		  this.label9,
																		  this.label2,
																		  this.label1,
																		  this.nhomcc,
																		  this.manguon,
																		  this.label3,
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
																		  this.mabv,
																		  this.sobienlai,
																		  this.mabs,
																		  this.makp});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmThuocbhyt";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Đơn thuốc bảo hiểm";
			this.Load += new System.EventHandler(this.frmThuocbhyt_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void frmThuocbhyt_Load(object sender, System.EventArgs e)
		{
			bKhoaso=d.bKhoaso(i_nhom,s_mmyy);
			i_songay=d.Ngaylv_Ngayht;
			s_makho=d.get_dmkho(i_loai).Trim();
			s_makho=(s_makho=="")?"":s_makho.Substring(0,s_makho.Length-1);
			s_manguon=d.get_manguon(i_loai).Trim();
			s_manguon=(s_manguon=="")?"":s_manguon.Substring(0,s_manguon.Length-1);

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

			makho.DisplayMember="TEN";
			makho.ValueMember="ID";
			sql="select * from d_dmkho where nhom="+i_nhom;
			if (s_kho!="") sql+=" and id in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			else if (s_makho!="") sql+=" and id in ("+s_makho+")";
			sql+=" order by stt";
			makho.DataSource=d.get_data(sql).Tables[0];

			maphu.DisplayMember="TEN";
			maphu.ValueMember="ID";
			maphu.DataSource=d.get_data("select * from dmphu").Tables[0];

			dtdstt=d.get_data("select * from dstt order by mabv").Tables[0];
			listDstt.DisplayMember="MABV";
			listDstt.ValueMember="TENBV";
			listDstt.DataSource=dtdstt;

			listDMBS.DisplayMember="MA";
			listDMBS.ValueMember="HOTEN";
			dtbs=d.get_data("select ma,hoten from dmbs order by hoten").Tables[0];
			listDMBS.DataSource=dtbs;

			listBTDKP.DisplayMember="MAKP";
			listBTDKP.ValueMember="TENKP";
			dtkp=d.get_data("select makp,tenkp from btdkp_bv where loai=1 order by tenkp").Tables[0];
			listBTDKP.DataSource=dtkp;

			listDMBD.DisplayMember="TEN";
			listDMBD.ValueMember="STT";

			listcachdung.DisplayMember="STT";
			listcachdung.ValueMember="TEN";
			sql="select a.id,a.mabn,a.maql,b.hoten,b.namsinh,to_char(a.ngay,'dd/mm/yyyy') ngay,b.diachi,a.makp,a.chandoan,a.maicd,a.mabs,a.sothe,a.maphu,a.mabv,a.sobienlai from bhytkb a,bhytds b where a.mabn=b.mabn and a.nhom="+i_nhom+" and a.userid="+i_userid+" and a.mmyy='"+s_mmyy+"'";
			sql+=" and a.mabn='"+s_mabn+"'";
			if (d.bLocbaohiem) sql+=" and to_char(a.ngay,'dd/mm/yyyy')='"+s_ngay.Substring(0,10)+"'";
			sql+=" order by a.id";
			dtll=d.get_data(sql).Tables[0];
			cmbSophieu.DisplayMember="MABN";
			cmbSophieu.ValueMember="ID";
			cmbSophieu.DataSource=dtll;
			load_grid();
			AddGridTableStyle();
			ref_text();
			dsxoa.ReadXml("..\\..\\..\\xml\\d_bhytthuoc.xml");
		}

		private void load_grid()
		{
			sql="select a.stt,a.sttt,a.mabd,b.ma,trim(b.ten)||' '||b.hamluong ten,b.tenhc,b.dang,e.ten tenkho,c.ten tennguon,d.ten tennhomcc,a.handung,a.losx,a.soluong,round(a.sotien/a.soluong,3) dongia,a.sotien,a.cachdung,a.makho,a.manguon,a.nhomcc ";
			sql+=" from bhytthuoc a,d_dmbd b,d_dmnguon c,d_nhomcc d,d_dmkho e where a.mabd=b.id and a.manguon=c.id and a.nhomcc=d.id and a.makho=e.id and a.id="+l_id+" order by a.stt";
			dtct=d.get_data(sql).Tables[0];
			dataGrid1.DataSource=dtct;
		}

		private void ref_text()
		{
			try
			{
				int i=dataGrid1.CurrentCell.RowNumber;
				stt.Text=dataGrid1[i,0].ToString();
				r=d.getrowbyid(dtct,"stt="+int.Parse(stt.Text));
				if (r!=null)
				{	  
					mabd.Text=r["ma"].ToString();
					tenbd.Text=r["ten"].ToString();
					tenhc.Text=r["tenhc"].ToString();
					dang.Text=r["dang"].ToString();
					handung.Text=r["handung"].ToString();
					losx.Text=r["losx"].ToString();
					d_soluong=(r["soluong"].ToString()!="")?decimal.Parse(r["soluong"].ToString()):0;
					d_dongia=(r["dongia"].ToString()!="")?decimal.Parse(r["dongia"].ToString()):0;
					d_sotien=(r["sotien"].ToString()!="")?decimal.Parse(r["sotien"].ToString()):0;
					soluong.Text=d_soluong.ToString("###,###,##0.00");
					dongia.Text=d_dongia.ToString("###,###,###,##0.000");
					sotien.Text=d_sotien.ToString("###,###,###,##0.000");
					cachdung.Text=r["cachdung"].ToString();
					makho.SelectedValue=r["makho"].ToString();
					manguon.SelectedValue=r["manguon"].ToString();
					nhomcc.SelectedValue=r["nhomcc"].ToString();
					sttt.Text=r["sttt"].ToString();
					d_soluongcu=d_soluong;
					if (butLuu.Enabled)
					{
						tenbd.Enabled=sttt.Text=="0";
						if (d.bNhapmaso) mabd.Enabled=tenbd.Enabled;
						soluong.Enabled=tenbd.Enabled;
					}
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
			TextCol.Width = 150;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tenhc";
			TextCol.HeaderText = "Hoạt chất";
			TextCol.Width = 150;
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
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tennguon";
			TextCol.HeaderText = "Nguồn";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "tennhomcc";
			TextCol.HeaderText = "Nhóm cung cấp";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "handung";
			TextCol.HeaderText = "Date";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "losx";
			TextCol.HeaderText = "Lô SX";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "soluong";
			TextCol.HeaderText = "Số lượng";
			TextCol.Width = 50;
			TextCol.Format="#,###,##0.00";
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "dongia";
			TextCol.HeaderText = "Đơn giá";
			TextCol.Width = 80;
			TextCol.Format="###,###,###,##0";
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "sotien";
			TextCol.HeaderText = "Số tiền";
			TextCol.Width = 90;
			TextCol.Format="###,###,###,##0.000";
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "cachdung";
			TextCol.HeaderText = "Cách dùng";
			TextCol.Width = 100;
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
					l_maql=long.Parse(r["maql"].ToString());
					sophieu.Text=r["mabn"].ToString();
					hoten.Text=r["hoten"].ToString();
					namsinh.Text=r["namsinh"].ToString();
					ngaysp.Text=r["ngay"].ToString();
					diachi.Text=r["diachi"].ToString();
					sothe.Text=r["sothe"].ToString();
					maphu.SelectedValue=r["maphu"].ToString();
					sobienlai.Text=r["sobienlai"].ToString();
					mabv.Text=r["mabv"].ToString();
					maicd.Text=r["maicd"].ToString();
					chandoan.Text=r["chandoan"].ToString();
					makp.Text=r["makp"].ToString();
					mabs.Text=r["mabs"].ToString();
					DataRow r1=d.getrowbyid(dtdstt,"mabv='"+r["mabv"].ToString()+"'");
					if (r1!=null) tenbv.Text=r1["tenbv"].ToString();
					else tenbv.Text="";
					r1=d.getrowbyid(dtkp,"makp='"+makp.Text+"'");
					if (r1!=null) tenkp.Text=r1["tenkp"].ToString();
					else tenkp.Text="";
					r1=d.getrowbyid(dtbs,"ma='"+mabs.Text+"'");
					if (r1!=null) tenbs.Text=r1["hoten"].ToString();
					else tenbs.Text="";
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
			if (d.bNhapmaso) mabd.Enabled=ena;
			if (d.bSothe)
			{
				maphu.Enabled=ena;
				tenbv.Enabled=ena;
			}
			tenbd.Enabled=ena;
			soluong.Enabled=ena;
			cachdung.Enabled=ena;
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
			hoten.Text="";
			namsinh.Text="";
			diachi.Text="";
			cachdung.Text="";
			sothe.Text="";
			tenbv.Text="";
			mabv.Text="";
			tenbs.Text="";
			mabs.Text="";
			makp.Text="";
			tenkp.Text="";
			maicd.Text="";
			chandoan.Text="";
			sobienlai.Text="0";
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
			cachdung.Text="";
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
			sophieu.Text=s_mabn;
			hoten.Text=s_Hoten;
			namsinh.Text=s_Namsinh;
			sothe.Text=s_Sothe;
			tenkp.Text=s_Tenkp;
			tenbs.Text=s_Tenbs;
			maicd.Text=s_Maicd;
			chandoan.Text=s_Chandoan;
			makp.Text=s_Makp;
			mabs.Text=s_Mabs;
			maphu.SelectedValue=d.get_maphu(sothe.Text).ToString();
			mabv.Text=s_mabv;
			r=d.getrowbyid(dtdstt,"mabv='"+mabv.Text+"'");
			if (r!=null) tenbv.Text=r["tenbv"].ToString();
			butThem.Focus();
		}
		private void butSua_Click(object sender, System.EventArgs e)
		{
			if (dtll.Rows.Count==0) return;
			if (bKhoaso)
			{
				MessageBox.Show("Số liệu tháng "+s_mmyy.Substring(0,2)+" năm "+s_mmyy.Substring(2,2)+" đã khóa !\nNếu cần thay đổi thì vào mục khai báo hệ thống",d.Msg);
				return;
			}
			if (sobienlai.Text!="0")
			{
				MessageBox.Show("Thông tin này đã cập nhật vào viện phí !",d.Msg);
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
			if (sothe.Enabled)
			{
				if (sothe.Text=="")
				{
					MessageBox.Show("Yêu cầu nhập số thẻ !",d.Msg);
					sothe.Focus();
					return false;
				}
			}
			if (tenbv.Enabled)
			{
				r=d.getrowbyid(dtdstt,"mabv='"+mabv.Text+"'");
				if (r==null)
				{
					MessageBox.Show("Tên nơi ĐKKCB không hợp lệ !",d.Msg);
					tenbv.Focus();
					return false;
				}
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
			if (tenkp.Enabled)
			{
				r=d.getrowbyid(dtkp,"tenkp='"+tenkp.Text+"'");
				if (r==null)
				{
					MessageBox.Show("Phòng khám không hợp lệ !",d.Msg);
					tenkp.Focus();
					return false;
				}
			}
//			if (maicd.Enabled)
//			{
//				r=d.getrowbyid(dticd,"cicd10='"+maicd.Text+"'");
//				if (r==null)
//				{
//					MessageBox.Show("Chẩn đoán không hợp lệ !",d.Msg);
//					chandoan.Focus();
//					return false;
//				}
//			}
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
			l_sttt=(sttt.Text!="")?long.Parse(sttt.Text):0;
			d.updrec_bhytthuoc(dt,int.Parse(stt.Text),l_sttt,i_mabd,mabd.Text,tenbd.Text,tenhc.Text,dang.Text,makho.Text,(manguon.SelectedIndex==-1)?"":manguon.Text,(nhomcc.SelectedIndex==-1)?"":nhomcc.Text,handung.Text,losx.Text,d_soluong,d_dongia,d_sotien,cachdung.Text,int.Parse(makho.SelectedValue.ToString()),(manguon.SelectedIndex==-1)?0:int.Parse(manguon.SelectedValue.ToString()),(nhomcc.SelectedIndex==-1)?0:int.Parse(nhomcc.SelectedValue.ToString()),dtton);
			return true;
		}

		private void mabd_Validated(object sender, System.EventArgs e)
		{
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
					manguon.SelectedValue=r["manguon"].ToString();
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
				if (sobienlai.Text!="0")
				{
					MessageBox.Show("Thông tin này đã cập nhật vào viện phí !",d.Msg);
					return;
				}
				if (MessageBox.Show("Đồng ý hủy số phiếu này ?",d.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
				{
					l_id=long.Parse(cmbSophieu.SelectedValue.ToString());
					d.execute_data("delete from bhytthuoc where id="+l_id);
					d.execute_data("delete from bhytkb where sobienlai=0 and id="+l_id);
					d.delrec(dtll,"id="+l_id);
					cmbSophieu.Refresh();
					load_grid();
				}
			}
			catch{}
		}

		private void load_dm()
		{
			sql="select rownum stt,d.ten tennguon,b.ma,trim(b.ten)||' '||b.hamluong ten,b.tenhc,b.dang,c.ten tenkho,a.tondau+a.slnhap-a.slxuat-a.slyeucau soluong,b.id,a.makho,a.manguon from d_tonkhoth a,d_dmbd b,d_dmkho c,d_dmnguon d where a.mabd=b.id and a.makho=c.id and a.manguon=d.id and a.mmyy='"+s_mmyy+"'";
			if (s_kho!="") sql+=" and a.makho in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			else if (s_makho!="") sql+=" and a.makho in ("+s_makho+")";
			if (s_manguon!="") sql+=" and a.manguon in ("+s_manguon+")";
			sql+=" order by b.ten";
			dtton=d.get_data(sql).Tables[0];
			listDMBD.DataSource=dtton;
			dtcachdung=d.get_data("select ten stt,ten from d_dmcachdung order by ten").Tables[0];
			listcachdung.DataSource=dtcachdung;
		}
		private void load_tonct()
		{
			sql="select a.*,b.ten tennguon,c.ten tennhomcc from d_tonkhoct a,d_dmnguon b,d_nhomcc c where a.manguon=b.id and a.nhomcc=c.id and a.mmyy='"+s_mmyy+"'";
			if (s_kho!="") sql+=" and a.makho in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			else if (s_makho!="") sql+=" and a.makho in ("+s_makho+")";
			if (s_manguon!="") sql+=" and a.manguon in ("+s_manguon+")";
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
			l_id=(bNew)?d.get_id_bhyt:l_id;
			if (!d.upd_bhytkb(l_id,i_nhom,ngaysp.Text,sophieu.Text,l_maql,makp.Text,chandoan.Text,maicd.Text,mabs.Text,sothe.Text,int.Parse(maphu.SelectedValue.ToString()),mabv.Text,s_mmyy,i_userid))
			{
				MessageBox.Show("Không cập nhật được thông tin bảo hiểm !",d.Msg);
				return;
			}
			if (!d.upd_bhytds(s_mmyy,sophieu.Text,hoten.Text,namsinh.Text,diachi.Text))
			{
				MessageBox.Show("Không cập nhật được thông tin bảo hiểm !",d.Msg);
				return;
			}
			if (dsxoa.Tables[0].Rows.Count>0)
			{
				foreach(DataRow r1 in dtsave.Rows)
					d.execute_data("delete from bhytthuoc where id="+l_id+" and stt="+long.Parse(r1["stt"].ToString()));
			}
			load_tonct();
			foreach(DataRow r1 in d.get_bhytthuoc(dtsave,dtct,dttonct).Rows)
			{
				d.upd_bhytthuoc(s_mmyy,l_id,int.Parse(r1["stt"].ToString()),long.Parse(r1["sttt"].ToString()),int.Parse(r1["makho"].ToString()),int.Parse(r1["manguon"].ToString()),int.Parse(r1["nhomcc"].ToString()),int.Parse(r1["mabd"].ToString()),r1["handung"].ToString(),r1["losx"].ToString(),decimal.Parse(r1["soluong"].ToString()),decimal.Parse(r1["sotien"].ToString()),r1["cachdung"].ToString());
				if (r1["cachdung"].ToString()!="") d.upd_dmcachdung(r1["ten"].ToString());
			}
			d.updrec_bhytll(dtll,l_id,sophieu.Text,l_maql,hoten.Text,namsinh.Text,ngaysp.Text,diachi.Text,makp.Text,chandoan.Text,maicd.Text,mabs.Text,sothe.Text,int.Parse(maphu.SelectedValue.ToString()),mabv.Text,(sobienlai.Text=="")?0:long.Parse(sobienlai.Text));
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
			int iTuoi=(namsinh.Text!="")?DateTime.Now.Year-int.Parse(namsinh.Text):0;
			tongcong(dtct);
			decimal d_bn=0,d_bhyt=d_tongcong;
			if (maphu.SelectedValue.ToString()=="1")
			{
				d_bn=d_tongcong*20/100;d_bhyt=d_tongcong*80/100;
			}
			if (d.bPreview)
			{
				frmReport f=new frmReport(m,dtct,"d_bhyt.rpt",hoten.Text,(iTuoi==0)?"":iTuoi.ToString(),diachi.Text,sothe.Text,chandoan.Text,dtct.Rows.Count.ToString(),d_tongcong.ToString(),d_bn.ToString(),d_bhyt.ToString(),tenbs.Text);
				f.ShowDialog(this);
			}
			else
			{
				#region inphieu
				ReportDocument oRpt=new ReportDocument();
				oRpt.Load("..\\..\\..\\report\\d_bhyt.rpt",OpenReportMethod.OpenReportByTempCopy);
				oRpt.SetDataSource(dtct);
				oRpt.DataDefinition.FormulaFields["soyte"].Text="'"+d.Syte+"'";
				oRpt.DataDefinition.FormulaFields["benhvien"].Text="'"+d.Tenbv+"'";
				oRpt.DataDefinition.FormulaFields["c1"].Text="'"+hoten.Text+"'";
				oRpt.DataDefinition.FormulaFields["c2"].Text=(iTuoi==0)?"'"+iTuoi.ToString()+"'":"";
				oRpt.DataDefinition.FormulaFields["c3"].Text="'"+diachi.Text+"'";
				oRpt.DataDefinition.FormulaFields["c4"].Text="'"+sothe.Text+"'";
				oRpt.DataDefinition.FormulaFields["c5"].Text="'"+chandoan.Text+"'";
				oRpt.DataDefinition.FormulaFields["c6"].Text="'"+dtct.Rows.Count.ToString()+"'";
				oRpt.DataDefinition.FormulaFields["c7"].Text="'"+d_tongcong.ToString()+"'";
				oRpt.DataDefinition.FormulaFields["c8"].Text="'"+d_bn.ToString()+"'";
				oRpt.DataDefinition.FormulaFields["c9"].Text="'"+d_bhyt.ToString()+"'";
				oRpt.DataDefinition.FormulaFields["c10"].Text="'"+tenbs.Text+"'";
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
				#endregion
			}
		}

		private void Filter_cachdung(string ten)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listcachdung.DataSource];
				DataView dv=(DataView)cm.List;
				dv.RowFilter="ten like '%"+ten.Trim()+"%'";
			}
			catch{}
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
		}

		private void sophieu_Validated(object sender, System.EventArgs e)
		{
			hoten.Text="";namsinh.Text="";diachi.Text="";
			sothe.Text="";mabv.Text="";l_maql=0;
			foreach(DataRow r1 in d.get_data("select * from bhytds where mabn='"+sophieu.Text+"'").Tables[0].Rows)
			{
				hoten.Text=r1["hoten"].ToString();
				namsinh.Text=r1["namsinh"].ToString();
				diachi.Text=r1["diachi"].ToString();
				break;
			}
			if (hoten.Text=="")
			{
				foreach(DataRow r1 in d.get_data("select * from btdbn where mabn='"+sophieu.Text+"'").Tables[0].Rows)
				{
					hoten.Text=r1["hoten"].ToString();
					namsinh.Text=r1["namsinh"].ToString();
					diachi.Text=r1["sonha"].ToString().Trim()+" "+r1["thon"].ToString();
					diachi.Text=diachi.Text.Trim();
					break;
				}
				foreach(DataRow r1 in d.get_data("select * from bhyt where mabn='"+sophieu.Text+"'"+" order by maql desc").Tables[0].Rows)
				{
					sothe.Text=r1["sothe"].ToString();
					mabv.Text=r1["mabv"].ToString();
					l_maql=long.Parse(r1["maql"].ToString());
					r=d.getrowbyid(dtdstt,"mabv='"+mabv.Text+"'");
					if (r!=null) tenbv.Text=r["tenbv"].ToString();
				}
			}
			else
			{
				foreach(DataRow r1 in d.get_data("select * from bhytkb where sothe is not null and mabn='"+sophieu.Text+"'"+" order by id desc").Tables[0].Rows)
				{
					sothe.Text=r1["sothe"].ToString();
					mabv.Text=r1["mabv"].ToString();
					r=d.getrowbyid(dtdstt,"mabv='"+mabv.Text+"'");
					if (r!=null) tenbv.Text=r["tenbv"].ToString();
				}
			}
			if (sothe.Text!="") maphu.SelectedValue=d.get_maphu(sothe.Text).ToString();
			if (l_maql==0 && sophieu.Text.Trim().Length==8) l_maql=d.get_maql(sophieu.Text);
		}

		private void cachdung_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listcachdung.Focus();
			else if (e.KeyCode==Keys.Enter)
			{
				if (listcachdung.Visible)	listcachdung.Focus();
				else SendKeys.Send("{Tab}");
			}		
		}

		private void cachdung_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==cachdung)
			{
				Filter_cachdung(cachdung.Text);
				listcachdung.BrowseToBtdkp(cachdung,cachdung,butThem);
			}
		}

		private void cachdung_Validated(object sender, System.EventArgs e)
		{
			if(!listcachdung.Focused) listcachdung.Hide();		
		}

		private void diachi_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void tenbv_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listDstt.Focus();
			else if (e.KeyCode==Keys.Enter)
			{
				if (listDstt.Visible)	listDstt.Focus();
				else SendKeys.Send("{Tab}");
			}				
		}

		private void tenbv_Validated(object sender, System.EventArgs e)
		{
			if(!listDstt.Focused) listDstt.Hide();
		}

		private void tenbv_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tenbv)
			{
				Filter_dstt(tenbv.Text);
				listDstt.BrowseToDanhmuc(tenbv,mabv,tenkp);
			}
		}

		private void Filter_dstt(string ten)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listDstt.DataSource];
				DataView dv=(DataView)cm.List;
				dv.RowFilter="tenbv like '%"+ten.Trim()+"%'";
			}
			catch{}
		}

		private void maphu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (maphu.SelectedIndex==-1) maphu.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void sothe_Validated(object sender, System.EventArgs e)
		{
			if (sothe.Text.Trim().Length<13)
			{
				MessageBox.Show("Nhập số thẻ chưa đủ ("+sothe.Text.Trim().Length.ToString()+")",d.Msg);
				sothe.Focus();
				return;
			}
			maphu.SelectedValue=d.get_maphu(sothe.Text).ToString();
		}

		private void sothe_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void chandoan_TextChanged(object sender, System.EventArgs e)
		{
//			if (this.ActiveControl==chandoan)
//			{
//				Filt_ICD(chandoan.Text);
//				listICD.BrowseToICD10(chandoan,maicd,butThem,maicd.Location.X,maicd.Location.Y+maicd.Height,maicd.Width+chandoan.Width+2,maicd.Height);
//			}
		}

		private void maicd_Validated(object sender, System.EventArgs e)
		{
			if (maicd.Text=="") chandoan.Text="";
			else chandoan.Text=m.get_vviet(maicd.Text);
			if (chandoan.Text=="" && maicd.Text!="")
			{
				frmDMICD10 f=new frmDMICD10(m,maicd.Text,chandoan.Text,true);
				f.ShowDialog();
				if (f.mICD!="")
				{
					chandoan.Text=f.mTen;
					maicd.Text=f.mICD;
				}
			}
		}

//		private void Filt_ICD(string ten)
//		{
//			try
//			{
//				CurrencyManager cm= (CurrencyManager)BindingContext[listICD.DataSource];
//				DataView dv=(DataView)cm.List;
//				dv.RowFilter="vviet like '%"+ten.Trim()+"%'";
//			}
//			catch{}
//		}

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

		private void Filt_btdkp(string ten)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listBTDKP.DataSource];
				DataView dv=(DataView)cm.List;
				dv.RowFilter="tenkp like '%"+ten.Trim()+"%'";
			}
			catch{}
		}

		private void chandoan_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
//			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listICD.Focus(); 
//			else if (e.KeyCode==Keys.Enter)
//			{
//				if (listICD.Visible) listICD.Focus();
//				else SendKeys.Send("{Tab}");
//			}		
		}

		private void tenkp_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listBTDKP.Focus(); 
			else if (e.KeyCode==Keys.Enter)
			{
				if (listBTDKP.Visible) listBTDKP.Focus();
				else SendKeys.Send("{Tab}");
			}		
		}

		private void tenkp_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==tenkp)
			{
				Filt_btdkp(tenkp.Text);
				listBTDKP.BrowseToDanhmuc(tenkp,makp,tenbs);
			}
		}

		private void tenbs_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listDMBS.Focus(); 
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
				listDMBS.BrowseToDanhmuc(tenbs,mabs,maicd);		
			}
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
	}
}
