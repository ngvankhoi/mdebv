using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LibMedi;
using LibDuoc;
using doiso;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace Duoc
{
	/// <summary>
	/// Summary description for frmXkhac.
	/// </summary>
	public class frmNgoaitru : System.Windows.Forms.Form
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
		private string xxx,user,s_mmyy,s_ngay,sql,s_ngaysp,s_makho,s_kho,s_makp,s_manguon,format_soluong,format_dongia,format_sotien,s_loaint;
		private int i_nhom,i_userid,i_mabd,i_old,i_songay,i_loai,i_makp,i_quay=0,itable;
		private decimal l_id,l_sttt,l_maql;
		private decimal d_soluong,d_dongia,d_sotien,d_giaban,d_soluongton,d_soluongcu,d_sotiencu,d_tongcong;
		private bool bKhoaso,bNew,bEdit=true,bGiaban,bTiepdon,bAdmin,bLockytu,bPhieulinh,b701424;
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
		private DataTable dtbd=new DataTable();
		private DataSet dsxoa=new DataSet();
		private DataSet dsxml=new DataSet();
		private DataTable dticd=new DataTable();
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
		private System.Windows.Forms.TextBox find;
		private System.Windows.Forms.Button butICD;
		private System.Windows.Forms.CheckBox chktreem;
		private System.Windows.Forms.Button butTreem;
		private System.Windows.Forms.Label lbltoa;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmNgoaitru(LibDuoc.AccessData acc,int loai,string mmyy,string ngay,int nhom,int userid,string kho,string makp,string title,bool b_giaban,bool admin,int quay,string _loaint)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			d=acc;
			i_nhom=nhom;s_kho=kho;s_makp=makp;
			i_userid=userid;s_mmyy=mmyy;
			s_ngay=ngay;i_loai=loai;i_quay=quay;
			s_loaint=_loaint;
			bGiaban=b_giaban;bAdmin=admin;
			this.Text=title;
            
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNgoaitru));
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
            this.find = new System.Windows.Forms.TextBox();
            this.butICD = new System.Windows.Forms.Button();
            this.chktreem = new System.Windows.Forms.CheckBox();
            this.butTreem = new System.Windows.Forms.Button();
            this.lbltoa = new System.Windows.Forms.Label();
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
            this.label9.Location = new System.Drawing.Point(294, 7);
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
            this.ngaysp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngaysp.Location = new System.Drawing.Point(40, 7);
            this.ngaysp.Mask = "##/##/####";
            this.ngaysp.MaxLength = 10;
            this.ngaysp.Name = "ngaysp";
            this.ngaysp.Size = new System.Drawing.Size(64, 21);
            this.ngaysp.TabIndex = 0;
            this.ngaysp.Text = "  /  /    ";
            this.ngaysp.Validated += new System.EventHandler(this.ngaysp_Validated);
            // 
            // listDMBD
            // 
            this.listDMBD.BackColor = System.Drawing.SystemColors.Info;
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
            this.lMabd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lMabd.Location = new System.Drawing.Point(24, 442);
            this.lMabd.Name = "lMabd";
            this.lMabd.Size = new System.Drawing.Size(32, 23);
            this.lMabd.TabIndex = 28;
            this.lMabd.Text = "Mã :";
            this.lMabd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lTen
            // 
            this.lTen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lTen.Location = new System.Drawing.Point(142, 442);
            this.lTen.Name = "lTen";
            this.lTen.Size = new System.Drawing.Size(66, 23);
            this.lTen.TabIndex = 29;
            this.lTen.Text = "Tên :";
            this.lTen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ldvt
            // 
            this.ldvt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ldvt.Location = new System.Drawing.Point(5, 465);
            this.ldvt.Name = "ldvt";
            this.ldvt.Size = new System.Drawing.Size(51, 23);
            this.ldvt.TabIndex = 30;
            this.ldvt.Text = "ĐVT :";
            this.ldvt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label16.Location = new System.Drawing.Point(154, 464);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(56, 23);
            this.label16.TabIndex = 31;
            this.label16.Text = "Số lượng :";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label17.Location = new System.Drawing.Point(315, 464);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(56, 23);
            this.label17.TabIndex = 32;
            this.label17.Text = "Đơn giá :";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label18.Location = new System.Drawing.Point(472, 464);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(56, 23);
            this.label18.TabIndex = 33;
            this.label18.Text = "Số tiền :";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label20.Location = new System.Drawing.Point(-8, 488);
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
            this.tenbd.Location = new System.Drawing.Point(210, 442);
            this.tenbd.Name = "tenbd";
            this.tenbd.Size = new System.Drawing.Size(254, 21);
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
            this.mabd.Location = new System.Drawing.Point(56, 442);
            this.mabd.Name = "mabd";
            this.mabd.Size = new System.Drawing.Size(52, 21);
            this.mabd.TabIndex = 9;
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
            this.dang.Location = new System.Drawing.Point(56, 465);
            this.dang.Mask = "";
            this.dang.MaxLength = 10;
            this.dang.Name = "dang";
            this.dang.Size = new System.Drawing.Size(88, 21);
            this.dang.TabIndex = 12;
            // 
            // soluong
            // 
            this.soluong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.soluong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.soluong.Enabled = false;
            this.soluong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.soluong.Location = new System.Drawing.Point(210, 465);
            this.soluong.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
            this.soluong.Name = "soluong";
            this.soluong.Size = new System.Drawing.Size(94, 21);
            this.soluong.TabIndex = 13;
            this.soluong.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.soluong.Validated += new System.EventHandler(this.soluong_Validated);
            // 
            // dongia
            // 
            this.dongia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dongia.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dongia.Enabled = false;
            this.dongia.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dongia.Location = new System.Drawing.Point(370, 465);
            this.dongia.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.dongia.Name = "dongia";
            this.dongia.Size = new System.Drawing.Size(94, 21);
            this.dongia.TabIndex = 14;
            this.dongia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // sotien
            // 
            this.sotien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.sotien.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sotien.Enabled = false;
            this.sotien.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sotien.Location = new System.Drawing.Point(530, 465);
            this.sotien.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.sotien.Name = "sotien";
            this.sotien.Size = new System.Drawing.Size(104, 21);
            this.sotien.TabIndex = 15;
            this.sotien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // butMoi
            // 
            this.butMoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butMoi.Image = global::Duoc.Properties.Resources.add;
            this.butMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMoi.Location = new System.Drawing.Point(0, 517);
            this.butMoi.Name = "butMoi";
            this.butMoi.Size = new System.Drawing.Size(70, 25);
            this.butMoi.TabIndex = 26;
            this.butMoi.Text = "     &Mới";
            this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
            // 
            // butSua
            // 
            this.butSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butSua.Image = global::Duoc.Properties.Resources.quick_edit;
            this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.Location = new System.Drawing.Point(70, 517);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(70, 25);
            this.butSua.TabIndex = 27;
            this.butSua.Text = "     &Sửa";
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butLuu
            // 
            this.butLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butLuu.Enabled = false;
            this.butLuu.Image = global::Duoc.Properties.Resources.save;
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(140, 517);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 24;
            this.butLuu.Tag = "  ";
            this.butLuu.Text = "     &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butThem
            // 
            this.butThem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butThem.Enabled = false;
            this.butThem.Image = global::Duoc.Properties.Resources.plus;
            this.butThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butThem.Location = new System.Drawing.Point(210, 517);
            this.butThem.Name = "butThem";
            this.butThem.Size = new System.Drawing.Size(70, 25);
            this.butThem.TabIndex = 22;
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
            this.butXoa.Location = new System.Drawing.Point(280, 517);
            this.butXoa.Name = "butXoa";
            this.butXoa.Size = new System.Drawing.Size(70, 25);
            this.butXoa.TabIndex = 23;
            this.butXoa.Text = "    &Xóa";
            this.butXoa.Click += new System.EventHandler(this.butXoa_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butBoqua.Enabled = false;
            this.butBoqua.Image = global::Duoc.Properties.Resources.undo_ok;
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(350, 517);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(70, 25);
            this.butBoqua.TabIndex = 25;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butHuy
            // 
            this.butHuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butHuy.Image = global::Duoc.Properties.Resources.delete_enabled;
            this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHuy.Location = new System.Drawing.Point(420, 517);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(70, 25);
            this.butHuy.TabIndex = 28;
            this.butHuy.Text = "     &Hủy";
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // butIn
            // 
            this.butIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butIn.Image = global::Duoc.Properties.Resources.F7;
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(574, 517);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 30;
            this.butIn.Text = "&In đơn";
            this.butIn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butKetthuc.Image = global::Duoc.Properties.Resources.close_r;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(722, 517);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 32;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // cmbSophieu
            // 
            this.cmbSophieu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSophieu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSophieu.Location = new System.Drawing.Point(149, 7);
            this.cmbSophieu.Name = "cmbSophieu";
            this.cmbSophieu.Size = new System.Drawing.Size(115, 21);
            this.cmbSophieu.TabIndex = 1;
            this.cmbSophieu.SelectedIndexChanged += new System.EventHandler(this.cmbSophieu_SelectedIndexChanged);
            this.cmbSophieu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbSophieu_KeyDown);
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label15.Location = new System.Drawing.Point(467, 488);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(61, 23);
            this.label15.TabIndex = 61;
            this.label15.Text = "Hạn dùng :";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label24
            // 
            this.label24.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label24.Location = new System.Drawing.Point(596, 488);
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
            this.handung.Location = new System.Drawing.Point(530, 488);
            this.handung.Mask = "####";
            this.handung.Name = "handung";
            this.handung.Size = new System.Drawing.Size(40, 21);
            this.handung.TabIndex = 20;
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
            this.losx.Location = new System.Drawing.Point(674, 488);
            this.losx.Mask = "&&&&&&&&&&";
            this.losx.MaxLength = 10;
            this.losx.Name = "losx";
            this.losx.Size = new System.Drawing.Size(110, 21);
            this.losx.TabIndex = 21;
            this.losx.Text = "          ";
            // 
            // tenhc
            // 
            this.tenhc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tenhc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenhc.Enabled = false;
            this.tenhc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenhc.Location = new System.Drawing.Point(530, 442);
            this.tenhc.Name = "tenhc";
            this.tenhc.Size = new System.Drawing.Size(256, 21);
            this.tenhc.TabIndex = 11;
            // 
            // lTenhc
            // 
            this.lTenhc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lTenhc.Location = new System.Drawing.Point(466, 441);
            this.lTenhc.Name = "lTenhc";
            this.lTenhc.Size = new System.Drawing.Size(62, 23);
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
            this.sophieu.Location = new System.Drawing.Point(149, 7);
            this.sophieu.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.sophieu.MaxLength = 8;
            this.sophieu.Name = "sophieu";
            this.sophieu.Size = new System.Drawing.Size(115, 21);
            this.sophieu.TabIndex = 2;
            this.sophieu.Validated += new System.EventHandler(this.sophieu_Validated);
            // 
            // giaban
            // 
            this.giaban.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.giaban.BackColor = System.Drawing.SystemColors.HighlightText;
            this.giaban.Enabled = false;
            this.giaban.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.giaban.Location = new System.Drawing.Point(370, 488);
            this.giaban.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.giaban.Name = "giaban";
            this.giaban.Size = new System.Drawing.Size(94, 21);
            this.giaban.TabIndex = 19;
            this.giaban.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label25
            // 
            this.label25.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label25.Location = new System.Drawing.Point(315, 488);
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
            this.dataGrid1.Location = new System.Drawing.Point(8, 34);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(776, 405);
            this.dataGrid1.TabIndex = 33;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.Location = new System.Drawing.Point(139, 488);
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
            this.manguon.Location = new System.Drawing.Point(56, 488);
            this.manguon.Name = "manguon";
            this.manguon.Size = new System.Drawing.Size(88, 21);
            this.manguon.TabIndex = 17;
            // 
            // nhomcc
            // 
            this.nhomcc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nhomcc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nhomcc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nhomcc.Enabled = false;
            this.nhomcc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhomcc.Location = new System.Drawing.Point(210, 488);
            this.nhomcc.Name = "nhomcc";
            this.nhomcc.Size = new System.Drawing.Size(94, 21);
            this.nhomcc.TabIndex = 18;
            // 
            // stt
            // 
            this.stt.Location = new System.Drawing.Point(32, 344);
            this.stt.Name = "stt";
            this.stt.Size = new System.Drawing.Size(24, 20);
            this.stt.TabIndex = 68;
            // 
            // sttt
            // 
            this.sttt.Location = new System.Drawing.Point(64, 344);
            this.sttt.Name = "sttt";
            this.sttt.Size = new System.Drawing.Size(24, 20);
            this.sttt.TabIndex = 69;
            // 
            // tenkp
            // 
            this.tenkp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenkp.Enabled = false;
            this.tenkp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenkp.Location = new System.Drawing.Point(73, 30);
            this.tenkp.Name = "tenkp";
            this.tenkp.Size = new System.Drawing.Size(144, 21);
            this.tenkp.TabIndex = 7;
            this.tenkp.Validated += new System.EventHandler(this.tenkp_Validated);
            this.tenkp.TextChanged += new System.EventHandler(this.tenkp_TextChanged);
            this.tenkp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenkp_KeyDown);
            // 
            // listDuockp
            // 
            this.listDuockp.BackColor = System.Drawing.SystemColors.Info;
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
            this.makho.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.makho.BackColor = System.Drawing.SystemColors.HighlightText;
            this.makho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.makho.Enabled = false;
            this.makho.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makho.Location = new System.Drawing.Point(674, 465);
            this.makho.Name = "makho";
            this.makho.Size = new System.Drawing.Size(110, 21);
            this.makho.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.Location = new System.Drawing.Point(642, 464);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 23);
            this.label5.TabIndex = 73;
            this.label5.Text = "Kho :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // loai
            // 
            this.loai.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.loai.BackColor = System.Drawing.SystemColors.HighlightText;
            this.loai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.loai.Enabled = false;
            this.loai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.hoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoten.Location = new System.Drawing.Point(342, 7);
            this.hoten.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.hoten.Name = "hoten";
            this.hoten.Size = new System.Drawing.Size(168, 21);
            this.hoten.TabIndex = 3;
            this.hoten.Validated += new System.EventHandler(this.hoten_Validated);
            // 
            // namsinh
            // 
            this.namsinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.namsinh.Enabled = false;
            this.namsinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namsinh.Location = new System.Drawing.Point(568, 7);
            this.namsinh.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.namsinh.MaxLength = 4;
            this.namsinh.Name = "namsinh";
            this.namsinh.Size = new System.Drawing.Size(43, 21);
            this.namsinh.TabIndex = 4;
            this.namsinh.Validated += new System.EventHandler(this.namsinh_Validated);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(613, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 23);
            this.label6.TabIndex = 77;
            this.label6.Text = "Loại :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // makp
            // 
            this.makp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.makp.Enabled = false;
            this.makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makp.Location = new System.Drawing.Point(40, 30);
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(32, 21);
            this.makp.TabIndex = 6;
            this.makp.Validated += new System.EventHandler(this.makp_Validated);
            this.makp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.makp_KeyDown);
            // 
            // tenbs
            // 
            this.tenbs.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbs.Enabled = false;
            this.tenbs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbs.Location = new System.Drawing.Point(264, 30);
            this.tenbs.Name = "tenbs";
            this.tenbs.Size = new System.Drawing.Size(200, 21);
            this.tenbs.TabIndex = 8;
            this.tenbs.Validated += new System.EventHandler(this.tenbs_Validated);
            this.tenbs.TextChanged += new System.EventHandler(this.tenbs_TextChanged);
            this.tenbs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbs_KeyDown);
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(216, 28);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 23);
            this.label11.TabIndex = 93;
            this.label11.Text = "Bác sĩ :";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // listDMBS
            // 
            this.listDMBS.BackColor = System.Drawing.SystemColors.Info;
            this.listDMBS.ColumnCount = 0;
            this.listDMBS.Location = new System.Drawing.Point(216, 544);
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
            this.label7.Location = new System.Drawing.Point(610, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 23);
            this.label7.TabIndex = 100;
            this.label7.Text = "Tổng cộng :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sum
            // 
            this.sum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sum.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sum.Enabled = false;
            this.sum.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sum.Location = new System.Drawing.Point(680, 30);
            this.sum.Name = "sum";
            this.sum.Size = new System.Drawing.Size(104, 21);
            this.sum.TabIndex = 101;
            this.sum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // mabs
            // 
            this.mabs.Location = new System.Drawing.Point(136, 336);
            this.mabs.Name = "mabs";
            this.mabs.Size = new System.Drawing.Size(24, 20);
            this.mabs.TabIndex = 102;
            // 
            // find
            // 
            this.find.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.find.Location = new System.Drawing.Point(466, 30);
            this.find.Name = "find";
            this.find.Size = new System.Drawing.Size(145, 21);
            this.find.TabIndex = 106;
            this.find.Text = "Tìm kiếm";
            this.find.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.find.Enter += new System.EventHandler(this.find_Enter);
            this.find.TextChanged += new System.EventHandler(this.find_TextChanged);
            // 
            // butICD
            // 
            this.butICD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butICD.Enabled = false;
            this.butICD.Image = ((System.Drawing.Image)(resources.GetObject("butICD.Image")));
            this.butICD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butICD.Location = new System.Drawing.Point(490, 517);
            this.butICD.Name = "butICD";
            this.butICD.Size = new System.Drawing.Size(84, 25);
            this.butICD.TabIndex = 29;
            this.butICD.Text = "&Chẩn đoán";
            this.butICD.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butICD.Click += new System.EventHandler(this.butICD_Click);
            // 
            // chktreem
            // 
            this.chktreem.Location = new System.Drawing.Point(8, 554);
            this.chktreem.Name = "chktreem";
            this.chktreem.Size = new System.Drawing.Size(168, 16);
            this.chktreem.TabIndex = 108;
            this.chktreem.Text = "In mẫu trẻ em dưới 6 tuổi";
            this.chktreem.Visible = false;
            // 
            // butTreem
            // 
            this.butTreem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butTreem.Image = global::Duoc.Properties.Resources.F9;
            this.butTreem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butTreem.Location = new System.Drawing.Point(644, 517);
            this.butTreem.Name = "butTreem";
            this.butTreem.Size = new System.Drawing.Size(78, 25);
            this.butTreem.TabIndex = 31;
            this.butTreem.Text = "In &chi phí";
            this.butTreem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butTreem.Click += new System.EventHandler(this.butTreem_Click);
            // 
            // lbltoa
            // 
            this.lbltoa.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltoa.ForeColor = System.Drawing.Color.Red;
            this.lbltoa.Location = new System.Drawing.Point(264, 8);
            this.lbltoa.Name = "lbltoa";
            this.lbltoa.Size = new System.Drawing.Size(28, 17);
            this.lbltoa.TabIndex = 234;
            this.lbltoa.Text = "0";
            this.lbltoa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmNgoaitru
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.makp);
            this.Controls.Add(this.lbltoa);
            this.Controls.Add(this.butTreem);
            this.Controls.Add(this.chktreem);
            this.Controls.Add(this.butICD);
            this.Controls.Add(this.find);
            this.Controls.Add(this.tenkp);
            this.Controls.Add(this.sum);
            this.Controls.Add(this.tenbs);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.listDMBS);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.namsinh);
            this.Controls.Add(this.hoten);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.makho);
            this.Controls.Add(this.listDuockp);
            this.Controls.Add(this.cmbSophieu);
            this.Controls.Add(this.sophieu);
            this.Controls.Add(this.ngaysp);
            this.Controls.Add(this.loai);
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
            this.Controls.Add(this.mabs);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmNgoaitru";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phiếu xuất ngoại trú";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmNgoaitru_KeyDown);
            this.Load += new System.EventHandler(this.frmNgoaitru_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmNgoaitru_Load(object sender, System.EventArgs e)
		{
            //if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            user = d.user; xxx = user + s_mmyy;
			b701424=m.Mabv_so==701424;
			bLockytu=d.bLockytu_traiphai(i_nhom);
			bPhieulinh=d.bNgoaitru_phieulinh(i_nhom);
			d.upd_capsotoa(s_mmyy,3,s_ngay,i_quay);
			chktreem.Enabled=d.bNgtru_mabn;
			format_sotien=d.format_sotien(i_nhom);
			format_dongia=d.format_dongia(i_nhom);
			format_soluong=d.format_soluong(i_nhom);
			bTiepdon=m.bTiepdon(LibMedi.AccessData.Duoc);
			bKhoaso=d.bKhoaso(i_nhom,s_mmyy);
			i_songay=d.Ngaylv_Ngayht;
			if (i_quay==0)
			{
				s_makho=d.get_dmkho(i_loai).Trim();
				s_makho=(s_makho=="")?"":s_makho.Substring(0,s_makho.Length-1);
			}
			else s_makho="";
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

            sql = "select * from " + user + ".d_dmloaint where nhom=" + i_nhom;
			if (s_loaint!="") sql+=" and id in ("+s_loaint.Substring(0,s_loaint.Length-1)+")";
			sql+=" order by stt";
			loai.DisplayMember="TEN";
			loai.ValueMember="ID";
			loai.DataSource=d.get_data(sql).Tables[0];

			sql="select a.id,a.ma,trim(a.ten)||' '||trim(a.hamluong)||' ['||trim(b.ten)||']' as ten,";
			sql+="a.dang as dvt,c.stt as sttloai,c.ten as loai,d.stt as sttnhom,d.ten as nhom";
            sql += ", a.kcct, a.bhyt, a.kythuat";
            sql += " from " + user + ".d_dmbd a," + user + ".d_dmhang b," + user + ".d_dmnhom c," + user + ".v_nhomvp d";
			sql+=" where a.mahang=b.id and a.manhom=c.id and c.nhomvp=d.ma";
			dtbd=m.get_data(sql).Tables[0];

			makho.DisplayMember="TEN";
			makho.ValueMember="ID";
            sql = "select * from " + user + ".d_dmkho where nhom=" + i_nhom;
			if (s_makho!="") sql+=" and id in ("+s_makho+")";
			if (s_kho!="") sql+=" and id in ("+s_kho.Substring(0,s_kho.Length-1)+")";
			sql+=" order by stt";
			makho.DataSource=d.get_data(sql).Tables[0];

			listDMBD.DisplayMember="TEN";
			listDMBD.ValueMember="STT";

			listDMBS.DisplayMember="MA";
			listDMBS.ValueMember="HOTEN";
            dtbs = d.get_data("select ma,hoten from " + user + ".dmbs where nhom not in (" + LibMedi.AccessData.nhanvien + "," + LibMedi.AccessData.nghiviec + ") order by hoten").Tables[0];
			listDMBS.DataSource=dtbs;

			listDuockp.DisplayMember="MA";
			listDuockp.ValueMember="TEN";
            sql = "select ma,ten,id from " + user + ".d_duockp where nhom like '%" + i_nhom.ToString() + ",%'";
			if (s_makp!="") sql+=" and id in ("+s_makp.Substring(0,s_makp.Length-1)+")";
			sql+=" order by stt";
			dtduockp=d.get_data(sql).Tables[0];
			listDuockp.DataSource=dtduockp;
            sql = "select id,mabn,hoten,namsinh,to_char(ngay,'dd/mm/yyyy') as ngay,mabs,makp,loai,done,userid,sotoa,maql from " + xxx + ".d_ngtrull where nhom=" + i_nhom;
			if (!bAdmin) sql+=" and userid="+i_userid;
			if (d.bLocngoaitru) sql+=" and to_char(ngay,'dd/mm/yyyy')='"+s_ngay+"'";
			if (i_quay!=0) sql+=" and loai="+i_quay;
			sql+=" order by sotoa,id";
			dtll=d.get_data(sql).Tables[0];
			cmbSophieu.DisplayMember="MABN";
			cmbSophieu.ValueMember="ID";
			cmbSophieu.DataSource=dtll;
			if (cmbSophieu.Items.Count>0) l_id=decimal.Parse(cmbSophieu.SelectedValue.ToString());
			else l_id=0;
			load_head();
			//load_grid();
			AddGridTableStyle();
			ref_text();
			dsxoa.ReadXml("..\\..\\..\\xml\\d_ngtruct.xml");
			dsxml.ReadXml("..\\..\\..\\xml\\m_inravien.xml");
            DataColumn dc = new DataColumn("Image", typeof(byte[]));
            dsxml.Tables[0].Columns.Add(dc);
            dc = new DataColumn("Imagetk", typeof(byte[]));
            dsxml.Tables[0].Columns.Add(dc);
            dc = new DataColumn("Imageuser", typeof(byte[]));
            dsxml.Tables[0].Columns.Add(dc);
            dsxml.Tables[0].Columns.Add("mabs");
            dsxml.Tables[0].Columns.Add("tenbs");
            dsxml.Tables[0].Columns.Add("makprv");
            dsxml.Tables[0].Columns.Add("tenuser");
            dsxml.Tables[0].Columns.Add("cholam");
            dsxml.Tables[0].Columns.Add("madt", typeof(decimal));
            dsxml.Tables[0].Columns.Add("haophi", typeof(decimal));
            dsxml.Tables[0].Columns.Add("gianovat", typeof(decimal));
            dsxml.Tables[0].Columns.Add("idttrv", typeof(decimal));
            dsxml.Tables[0].Columns.Add("sotientra", typeof(decimal));
            dsxml.Tables[0].Columns.Add("traituyen", typeof(decimal));
            dsxml.Tables[0].Columns.Add("kythuat", typeof(decimal));
            dsxml.Tables[0].Columns.Add("loaikythuat", typeof(string));
            try { dsxml.Tables[0].Columns.Add("cachdung");}
            catch { }
            try { dsxoa.Tables[0].Columns.Add("cachdung"); }
            catch { }
		}

		private void load_grid()
		{
			sql="select a.stt,a.sttt,a.mabd,b.ma,trim(b.ten)||' '||b.hamluong as ten,b.tenhc,b.dang,e.ten as tenkho,c.ten as tennguon,d.ten as tennhomcc,t.handung,t.losx,a.soluong,t.giamua as dongia,a.soluong*t.giamua as sotien,a.giaban,a.makho,t.manguon,t.nhomcc,a.soluong*a.giaban as sotienban,a.soluong as soluongcu,a.soluong*t.giamua as sotiencu,t.giamua, a.cachdung ";//gam 27/09/2011 sửa a.cahcdung --> sai chinh ta
            sql += " from " + xxx + ".d_ngtruct a," + user + ".d_dmbd b," + user + ".d_dmnguon c," + user + ".d_dmnx d," + user + ".d_dmkho e," + xxx + ".d_theodoi t where a.sttt=t.id and a.mabd=b.id and t.manguon=c.id and t.nhomcc=d.id and a.makho=e.id and a.id=" + l_id + " order by a.stt";
			dtct=d.get_data(sql).Tables[0];
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
				soluong.Text=d_soluong.ToString(format_soluong );
				dongia.Text=d_dongia.ToString(format_dongia);
				sotien.Text=d_sotien.ToString(format_sotien);
				giaban.Text=d_giaban.ToString("#,###,###,##0");
				makho.SelectedValue=dataGrid1[i,14].ToString();
				manguon.SelectedValue=dataGrid1[i,15].ToString();
				nhomcc.SelectedValue=dataGrid1[i,16].ToString();
				sttt.Text=dataGrid1[i,17].ToString();
                d_soluongcu = (bNew) ? 0 : d_soluong;
				d_sotiencu=d_sotien;
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
            TextCol.HeaderText = "Nhà cung cấp";
			TextCol.Width = (d.bQuanlynhomcc(i_nhom))?150:0;
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
			TextCol.Format=format_soluong;
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "dongia";
			TextCol.HeaderText = "Đơn giá";
			TextCol.Width = 100;
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
					sophieu.Text=r["mabn"].ToString();
					hoten.Text=r["hoten"].ToString();
					namsinh.Text=r["namsinh"].ToString();
					ngaysp.Text=r["ngay"].ToString();
					makp.Text=r["makp"].ToString();
					mabs.Text=r["mabs"].ToString();
					DataRow r1=d.getrowbyid(dtduockp,"id="+int.Parse(r["makp"].ToString()));
					if (r1!=null) 
					{
						tenkp.Text=r1["ten"].ToString();
						makp.Text=r1["ma"].ToString();
					}
					r1=d.getrowbyid(dtbs,"ma='"+mabs.Text+"'");
					if (r1!=null) tenbs.Text=r1["hoten"].ToString();
					loai.SelectedValue=r["loai"].ToString();
					s_ngaysp=ngaysp.Text;
					l_maql=decimal.Parse(r["maql"].ToString());
					lbltoa.Text=r["sotoa"].ToString();
				}
			}
			catch{l_id=0;}
			load_grid();
			ref_text();
			if (bGiaban) tongcong_giaban(dtct);
			else tongcong(dtct);
			sum.Text=d_tongcong.ToString(format_sotien);
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
				if (bLockytu) sql="(soluong>0) and (ten like '"+ten.Trim()+"%'"+" or tenhc like '"+ten.Trim()+"%')";
				else sql="(soluong>0) and (ten like '%"+ten.Trim()+"%'"+" or tenhc like '%"+ten.Trim()+"%')";
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
			find.Enabled=!ena;
			sophieu.Visible=ena;
			cmbSophieu.Visible=!ena;
			//ngaysp.Enabled=ena;
			if (d.bHotennt) hoten.Enabled=ena;
			if (i_quay==0) loai.Enabled=ena;
			if (d.bNgtru_khoa) tenkp.Enabled=ena;
			if (d.bNgtru_bacsi) tenbs.Enabled=ena;
			if (d.bNamsinhnt) namsinh.Enabled=ena;
			if (d.bNhapmaso) mabd.Enabled=ena;
			if (d.bNgtru_mabn) sophieu.Enabled=ena;
			makp.Enabled=tenkp.Enabled;
			tenbd.Enabled=ena;
			soluong.Enabled=ena;
			butMoi.Enabled=!ena;
			butSua.Enabled=!ena;
			butThem.Enabled=ena;
			butXoa.Enabled=ena;
			butLuu.Enabled=ena;
			butBoqua.Enabled=ena;
			butICD.Enabled=ena;
			butHuy.Enabled=!ena;
			butIn.Enabled=!ena;
			butTreem.Enabled=!ena;
			butKetthuc.Enabled=!ena;
			i_old=cmbSophieu.SelectedIndex;
            if (ena) load_dm();
            //else
            //{
            find.Text = "";
                CurrencyManager cm = (CurrencyManager)BindingContext[cmbSophieu.DataSource];
                DataView dv = (DataView)cm.List;
                dv.RowFilter = "";
            //}
        }

		private void emp_head()
		{
			l_id=0;l_maql=0;
			if (sophieu.Enabled )sophieu.Text="";
			else 
			{
				sql=" where nhom="+i_nhom;
				if (!bAdmin) sql+=" and userid="+i_userid;
				if (d.bLocngoaitru) sql+=" and to_char(ngay,'dd/mm/yyyy')='"+s_ngay+"'";
				if (i_quay!=0) sql+=" and loai="+i_quay;
				sophieu.Text=d.get_sophieu(s_mmyy,"d_ngtrull","mabn",sql);//d.get_stt(dtll,"mabn").ToString();
			}
			if (i_quay!=0) loai.SelectedValue=i_quay.ToString();
			ngaysp.Text=s_ngay;
			s_ngaysp=ngaysp.Text;
			hoten.Text="";
			namsinh.Text="";
			tenkp.Text="";
			makp.Text="";
			mabs.Text="";
			tenbs.Text="";
			sum.Text="0";
			lbltoa.Text="0";
            /*
            find.Text = "";
            CurrencyManager cm = (CurrencyManager)BindingContext[cmbSophieu.DataSource];
            DataView dv = (DataView)cm.List;
            dv.RowFilter = "";
             * */
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
			d_sotiencu=0;
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
			dticd.Clear();
			dtsave.Clear();
			emp_head();
			emp_detail();
			bNew=true;
			bEdit=true;
			if (sophieu.Enabled) sophieu.Focus();
			else if (hoten.Enabled) hoten.Focus();
			else if (loai.Enabled) loai.Focus();
			else if (tenkp.Enabled) makp.Focus();
			else if (tenbs.Enabled) tenbs.Focus();
			else if (mabd.Enabled) mabd.Focus();
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
			dticd=d.get_data("select * from "+xxx+".d_chandoan where loai=0 and id="+l_id).Tables[0];
			ena_object(true);
			bNew=false;
			bEdit=true;
			dtsave=dtct.Copy();
			dsxoa.Clear();
			if (sophieu.Enabled) sophieu.Focus();
			else hoten.Focus();
			ref_text();
		}
		private bool KiemtraHead()
		{
			if (sophieu.Text=="")
			{
				MessageBox.Show(
lan.Change_language_MessageText("Nhập mã số người bệnh !"),d.Msg);
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
			if (loai.SelectedIndex==-1)
			{
				MessageBox.Show(
lan.Change_language_MessageText("Nhập loại !"),d.Msg);
				loai.Focus();
				return false;
			}
			i_makp=0;
			if (tenkp.Enabled)
			{
				r=d.getrowbyid(dtduockp,"ten='"+tenkp.Text+"'");
				if (r==null)
				{
					MessageBox.Show(
lan.Change_language_MessageText("Khoa không hợp lệ !"),d.Msg);
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
					MessageBox.Show(
lan.Change_language_MessageText("Họ tên bác sĩ không hợp lệ !"),d.Msg);
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
			if (!upd_table(dtct,false)) return;
			emp_detail();
			if (mabd.Enabled) mabd.Focus();
			else tenbd.Focus();
		}

		private void butXoa_Click(object sender, System.EventArgs e)
		{
			if (!upd_table(dsxoa.Tables[0],true)) return;
			d.delrec(dtct,"stt="+int.Parse(stt.Text));
			dtct.AcceptChanges();
			if (dtct.Rows.Count==0) emp_detail();
			else ref_text();
		}

		private bool upd_table(DataTable dt,bool del)
		{
			if (!KiemtraDetail()) return false;
			d_soluong=(soluong.Text!="")?decimal.Parse(soluong.Text):0;
			d_dongia=(dongia.Text!="")?decimal.Parse(dongia.Text):0;
			d_sotien=(sotien.Text!="")?decimal.Parse(sotien.Text):0;
			d_giaban=(giaban.Text!="")?decimal.Parse(giaban.Text):0;
			l_sttt=(sttt.Text!="")?decimal.Parse(sttt.Text):0;
			d.updrec_ngtruct(dt,int.Parse(stt.Text),l_sttt,i_mabd,mabd.Text,tenbd.Text,tenhc.Text,dang.Text,makho.Text,(manguon.SelectedIndex==-1)?"":manguon.Text,(nhomcc.SelectedIndex==-1)?"":nhomcc.Text,handung.Text,losx.Text,d_soluong,d_dongia,d_sotien,d_giaban,d_dongia,Math.Round(d_soluong*d_giaban,3),int.Parse(makho.SelectedValue.ToString()),(manguon.SelectedIndex==-1)?0:int.Parse(manguon.SelectedValue.ToString()),(nhomcc.SelectedIndex==-1)?0:int.Parse(nhomcc.SelectedValue.ToString()),(del)?null:dtton,d_soluongcu,d_sotiencu,"");
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
					r=d.getrowbyid(dtton,"soluong>0 and stt="+int.Parse(mabd.Text));
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
					MessageBox.Show(lan.Change_language_MessageText("Số liệu tháng")+" "+s_mmyy.Substring(0,2)+" "+lan.Change_language_MessageText("năm")+" "+s_mmyy.Substring(2,2)+" "+lan.Change_language_MessageText("đã khóa !")+"\n"+lan.Change_language_MessageText("Nếu cần thay đổi thì vào mục khai báo hệ thống"),d.Msg);
					return;
				}
				if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý hủy số phiếu này ?"),d.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
				{
					l_id=decimal.Parse(cmbSophieu.SelectedValue.ToString());
                    itable = d.tableid(s_mmyy, "d_ngtruct");
                    foreach (DataRow r1 in dtct.Rows)
                    {
                        d.upd_eve_tables(s_mmyy, itable, i_userid, "del");
                        d.upd_eve_upd_del(s_mmyy, itable, i_userid, "del", d.fields(xxx + ".d_ngtruct", "id=" + l_id + " and stt=" + int.Parse(r1["stt"].ToString())));
                        d.upd_tonkhoct_xuat(d.delete, s_mmyy, decimal.Parse(r1["sttt"].ToString()), int.Parse(r1["makho"].ToString()), int.Parse(r1["manguon"].ToString()), int.Parse(r1["nhomcc"].ToString()), int.Parse(r1["mabd"].ToString()), r1["handung"].ToString(), r1["losx"].ToString(), decimal.Parse(r1["soluong"].ToString()), decimal.Parse(r1["sotien"].ToString()), decimal.Parse(r1["giaban"].ToString()), decimal.Parse(r1["giamua"].ToString()));
                    }
                    itable = d.tableid(s_mmyy, "d_ngtrull");
                    d.upd_eve_tables(s_mmyy, itable, i_userid, "del");
                    d.upd_eve_upd_del(s_mmyy, itable, i_userid, "del", d.fields(xxx + ".d_ngtrull", "id=" + l_id));
                    d.execute_data("delete from " + xxx + ".d_ngtruct where id=" + l_id);
                    d.execute_data("delete from " + xxx + ".d_ngtrull where id=" + l_id);
                    d.execute_data("delete from " + xxx + ".d_chandoan where loai=0 and id=" + l_id);
					d.delrec(dtll,"id="+l_id);
					dtll.AcceptChanges();
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
			dtton=d.get_tonkhoth(s_mmyy,s_makho,s_kho,s_manguon);
			listDMBD.DataSource=dtton;
		}
		private void load_tonct()
		{
			dttonct=d.get_tonkhoct(s_mmyy,s_makho,s_kho,s_manguon,i_nhom);
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			if (!KiemtraHead()) return;
			bEdit=false;
			upd_table(dtct,false);
			dtct.AcceptChanges();
			i_old=(bNew)?0:1;
			l_id=(bNew)?d.get_id_ngtru:l_id;
            itable = d.tableid(s_mmyy, "d_ngtrull");
            if (bNew) d.upd_eve_tables(s_mmyy, itable, i_userid, "ins");
            else
            {
                d.upd_eve_tables(s_mmyy, itable, i_userid, "upd");
                d.upd_eve_upd_del(s_mmyy, itable, i_userid, "upd", l_id.ToString() + "^" + i_nhom.ToString() + "^" + sophieu.Text + "^" + hoten.Text + "^" + namsinh.Text + "^" + ngaysp.Text + "^" + mabs.Text + "^" + i_makp.ToString() + "^" + loai.SelectedValue.ToString() + "^" + i_userid.ToString() + "^" + ((lbltoa.Text != "") ? lbltoa.Text : "0") + "^" + l_maql.ToString());
            }
			if (bNew && sophieu.Enabled && !b701424)
			{
				if (bTiepdon)
				{
					l_maql=m.get_tiepdon(sophieu.Text,ngaysp.Text);
					if (l_maql==0)
					{
						int tuoi=(namsinh.Text!="")?int.Parse(ngaysp.Text.Substring(6,4))-int.Parse(namsinh.Text):0;
                        l_maql = m.getidyymmddhhmiss_stt_computer;//m.get_capid(1);
                        string nam = m.get_mabn_nam(sophieu.Text);
                        if (nam.IndexOf(s_mmyy+"+") == -1) nam = nam + s_mmyy + "+";
						m.upd_btdbn(sophieu.Text,hoten.Text,"",(namsinh.Text!="")?namsinh.Text:"0000",m.vodanh_gioitinh,m.vodanh_nghenghiep,m.vodanh_dantoc,"","","",m.vodanh_tinh,m.vodanh_tinh+"00",m.vodanh_tinh+"0000",i_userid,nam);
						m.upd_lienhe(ngaysp.Text,l_maql,"","","",m.vodanh_tinh,m.vodanh_tinh+"00",m.vodanh_tinh+"0000",tuoi.ToString().PadLeft(3,'0')+"0",0,0);
						m.upd_tiepdon(sophieu.Text,l_maql,l_maql,"01",ngaysp.Text,3,"",tuoi.ToString().PadLeft(3,'0')+"0",i_userid,0,LibMedi.AccessData.Duoc,0);
					}
					m.upd_sukien(ngaysp.Text,sophieu.Text,l_maql,LibMedi.AccessData.Duoc,l_maql);
				}
			}
			if (!d.upd_ngtrull(s_mmyy,l_id,i_nhom,sophieu.Text,hoten.Text,namsinh.Text,ngaysp.Text,mabs.Text,i_makp,int.Parse(loai.SelectedValue.ToString()),i_userid,(lbltoa.Text!="")?int.Parse(lbltoa.Text):0,l_maql))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin ngoại trú !"),d.Msg);
				return;
			}
			if (dticd!=null)
			{
				d.execute_data("delete from "+xxx+".d_chandoan where loai=0 and id="+l_id);
				foreach(DataRow r in dticd.Rows) d.upd_chandoan(s_mmyy,l_id,0,r["maicd"].ToString(),r["chandoan"].ToString());
			}
            itable = d.tableid(s_mmyy, "d_ngtruct");
			if (!bNew)
			{
				foreach(DataRow r1 in dsxoa.Tables[0].Rows)
				{
                    d.upd_eve_tables(s_mmyy, itable, i_userid, "del");
                    d.upd_eve_upd_del(s_mmyy, itable, i_userid, "del", d.fields(xxx + ".d_ngtruct", "id=" + l_id + " and stt=" + int.Parse(r1["stt"].ToString())));
                    d.execute_data("delete from " + xxx + ".d_ngtruct where id=" + l_id + " and stt=" + decimal.Parse(r1["stt"].ToString()));
					d.upd_tonkhoct_xuat(d.delete,s_mmyy,decimal.Parse(r1["sttt"].ToString()),int.Parse(r1["makho"].ToString()),int.Parse(r1["manguon"].ToString()),int.Parse(r1["nhomcc"].ToString()),int.Parse(r1["mabd"].ToString()),r1["handung"].ToString(),r1["losx"].ToString(),decimal.Parse(r1["soluong"].ToString()),decimal.Parse(r1["sotien"].ToString()),decimal.Parse(r1["giaban"].ToString()),decimal.Parse(r1["giamua"].ToString()));
				}
			}
			dtct=d.get_ngtruct(s_mmyy,dtct,l_id);
			d.updrec_ngtrull(dtll,l_id,sophieu.Text,hoten.Text,namsinh.Text,ngaysp.Text,mabs.Text,i_makp,int.Parse(loai.SelectedValue.ToString()),0,i_userid,(lbltoa.Text!="")?int.Parse(lbltoa.Text):0,l_maql);
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
			load_grid();
			if (bGiaban) tongcong_giaban(dtct);
			else tongcong(dtct);
			sum.Text=d_tongcong.ToString(format_sotien);
			butMoi.Focus();
		}

		private void tongcong_giaban(DataTable dt)
		{
			d_tongcong=0;
			foreach(DataRow r1 in dt.Rows) d_tongcong+=decimal.Parse(r1["soluong"].ToString())*decimal.Parse(r1["giaban"].ToString());
		}

		private void tongcong(DataTable dt)
		{
			d_tongcong=0;
			foreach(DataRow r1 in dt.Rows) d_tongcong+=decimal.Parse(r1["sotien"].ToString());
		}

		private void Printer_phieulinh()
		{
			DataTable dttmp=dtct.Copy();
			sql="select a.stt,a.sttt,a.mabd,b.ma,trim(b.ten)||' '||b.hamluong as ten,nullif(b.tenhc,' ') as tenhc,b.dang,c.ten as tennguon,d.ten as tennhomcc,t.handung,t.losx,a.soluong,t.giamua as dongia,a.soluong*t.giamua as sotien,a.giaban,t.manguon,t.nhomcc,e.ten as tenhang,b.manhom,f.ten as tennhom,g.ten as tennuoc,h.ten as noingoai,h.stt as sttnn ";
            sql += " from " + xxx + ".d_ngtruct a," + user + ".d_dmbd b," + user + ".d_dmnguon c," + user + ".d_dmnx d," + user + ".d_dmhang e," + user + ".d_dmnhom f," + user + ".d_dmnuoc g," + user + ".d_nhomhang h," + xxx + ".d_theodoi t";
			sql+=" where a.sttt=t.id and a.mabd=b.id and t.manguon=c.id and t.nhomcc=d.id and b.mahang=e.id and b.manhom=f.id ";
			sql+=" and b.manuoc=g.id and e.loai=h.id";
			sql+=" and a.id="+l_id;
			sql+=" order by f.stt,a.stt";
			dttmp=d.get_data(sql).Tables[0];
			string tenfile="d_phieuxuat_mat.rpt";
			if (d.bPreview)
			{
				frmReport f=new frmReport(d,dttmp, i_userid,tenfile,cmbSophieu.Text,ngaysp.Text,"","","Ngoại trú","",d.Thongso("d_thongso","kho"),"","","");
				f.ShowDialog();
			}
			else
			{
				ReportDocument oRpt=new ReportDocument();
				oRpt.Load("..\\..\\..\\report\\"+tenfile,OpenReportMethod.OpenReportByTempCopy);
				oRpt.SetDataSource(dttmp);
				oRpt.DataDefinition.FormulaFields["soyte"].Text="'"+d.Syte+"'";
				oRpt.DataDefinition.FormulaFields["benhvien"].Text="'"+d.Tenbv+"'";
				oRpt.DataDefinition.FormulaFields["c1"].Text="'"+cmbSophieu.Text+"'";
				oRpt.DataDefinition.FormulaFields["c2"].Text="'"+ngaysp.Text+"'";
				oRpt.DataDefinition.FormulaFields["c3"].Text="";
				oRpt.DataDefinition.FormulaFields["c4"].Text="";
				oRpt.DataDefinition.FormulaFields["c5"].Text="Ngoại trú";
				oRpt.DataDefinition.FormulaFields["c6"].Text="";
				oRpt.DataDefinition.FormulaFields["c7"].Text=d.Thongso("d_thongso","kho");
				oRpt.DataDefinition.FormulaFields["c8"].Text="";
				oRpt.DataDefinition.FormulaFields["c9"].Text="";
				oRpt.DataDefinition.FormulaFields["c10"].Text="";
				oRpt.DataDefinition.FormulaFields["giamdoc"].Text="'"+d.Giamdoc(i_nhom)+"'";
				oRpt.DataDefinition.FormulaFields["phutrach"].Text="'"+d.Phutrach(i_nhom)+"'";
				oRpt.DataDefinition.FormulaFields["thongke"].Text="'"+d.Thongke(i_nhom)+"'";
				oRpt.DataDefinition.FormulaFields["ketoan"].Text="'"+d.Ketoan(i_nhom)+"'";
				oRpt.DataDefinition.FormulaFields["thukho"].Text="'"+d.Thukho(i_nhom)+"'";
				oRpt.PrintOptions.PaperSize=PaperSize.DefaultPaperSize;
				oRpt.PrintOptions.PaperOrientation=PaperOrientation.Portrait;
				oRpt.PrintToPrinter(1,false,0,0);
                oRpt.Close(); oRpt.Dispose();
			}
		}
		private void butIn_Click(object sender, System.EventArgs e)
		{
			if (dtct.Rows.Count==0) return;
			if (bPhieulinh)
			{
				Printer_phieulinh();
				return;
			}
			int iTuoi=(namsinh.Text!="")?DateTime.Now.Year-int.Parse(namsinh.Text):0;
			tongcong(dtct);
			int d_toaso=d.get_sotoa_ngtru(s_mmyy,l_id,ngaysp.Text,i_quay);
            d.execute_data("update "+xxx+".d_ngtrull set sotoa=" + d_toaso + " where id=" + l_id);
			lbltoa.Text=d_toaso.ToString();
			d.updrec_ngtrull(dtll,l_id,d_toaso);
			string s_chandoan="",s_tenkho=(s_makho=="")?"":makho.Text,lydo=loai.Text;
            foreach (DataRow r in d.get_data("select * from " + xxx + ".d_chandoan where loai=0 and id=" + l_id).Tables[0].Rows)
				s_chandoan+=r["maicd"].ToString().Trim()+"-"+r["chandoan"].ToString().Trim()+";";
			if (d.bPreview)
			{
				frmReport f=new frmReport(d,dtct, i_userid,"d_treem.rpt",hoten.Text,(iTuoi==0)?"":iTuoi.ToString(),"","",s_chandoan,dtct.Rows.Count.ToString(),d_tongcong.ToString(),d_tongcong.ToString(),"0",tenbs.Text.ToString(),cmbSophieu.Text,"");
				f.ShowDialog();
			}
			else
			{
				ReportDocument oRpt=new ReportDocument();
				oRpt.Load("..\\..\\..\\report\\d_treem.rpt",OpenReportMethod.OpenReportByTempCopy);
				oRpt.SetDataSource(dtct);
				oRpt.DataDefinition.FormulaFields["soyte"].Text="'"+d.Syte+"'";
				oRpt.DataDefinition.FormulaFields["benhvien"].Text="'"+d.Tenbv+"'";
				oRpt.DataDefinition.FormulaFields["c1"].Text="'"+hoten.Text+"'";
				oRpt.DataDefinition.FormulaFields["c2"].Text=(iTuoi==0)?"'"+iTuoi.ToString()+"'":"";
				oRpt.DataDefinition.FormulaFields["c3"].Text="";
				oRpt.DataDefinition.FormulaFields["c4"].Text="";
				oRpt.DataDefinition.FormulaFields["c5"].Text="'"+s_chandoan+"'";
				oRpt.DataDefinition.FormulaFields["c6"].Text="'"+dtct.Rows.Count.ToString()+"'";
				oRpt.DataDefinition.FormulaFields["c7"].Text="'"+d_tongcong.ToString()+"'";
				oRpt.DataDefinition.FormulaFields["c8"].Text="'"+d_tongcong.ToString()+"'";
				oRpt.DataDefinition.FormulaFields["c9"].Text="'0'";
				oRpt.DataDefinition.FormulaFields["c10"].Text="'"+tenbs.Text.ToString()+"'";
				oRpt.DataDefinition.FormulaFields["giamdoc"].Text="'"+cmbSophieu.ToString()+"'";
				oRpt.DataDefinition.FormulaFields["phutrach"].Text="'"+d.Phutrach(i_nhom)+"'";
				oRpt.DataDefinition.FormulaFields["thongke"].Text="";
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
			if (tenbs.Enabled)
                listDuockp.BrowseToBtdkp(tenkp,makp,tenbs);
			else
				listDuockp.BrowseToBtdkp(tenkp,makp,butThem);
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
			if (!b701424)
			{
				if (!bTiepdon)
				{
					l_maql=m.get_tiepdon(sophieu.Text,ngaysp.Text);
					if (l_maql==0)
					{
						MessageBox.Show(
lan.Change_language_MessageText("Người bệnh chưa qua tiếp đón !"),d.Msg);
						butBoqua.Focus();
						return;
					}
				}
				foreach(DataRow r1 in d.get_data("select hoten,namsinh from "+user+".btdbn where mabn='"+sophieu.Text+"'").Tables[0].Rows)
				{
					hoten.Text=r1["hoten"].ToString();
					namsinh.Text=r1["namsinh"].ToString();
					break;
				}
			}
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
				if (bLockytu) sql="soluong>0 and ma like '"+ma.Trim()+"%'";
				else sql="soluong>0 and ma like '%"+ma.Trim()+"%'";
				dv.RowFilter=sql;
			}
			catch{}
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
			Filt_dmbs(tenbs.Text);
			listDMBS.BrowseToDanhmuc(tenbs,mabs,butThem);
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
				dv.RowFilter="mabn like '%"+text.Trim()+"%' or hoten like '%"+text.Trim()+"%'";
				if(cmbSophieu.SelectedIndex>=0)	l_id=decimal.Parse(cmbSophieu.SelectedValue.ToString());
				else l_id=0;
				load_head();
			}
			catch(Exception ex){MessageBox.Show(ex.Message);}
		}

		private void butICD_Click(object sender, System.EventArgs e)
		{
			dticd.Clear();
			frmCdkemtheo f=new frmCdkemtheo(l_id,0,s_mmyy,null,"");
			f.ShowDialog(this);
			dticd=f.dt;
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

		private void butTreem_Click(object sender, System.EventArgs e)
		{
			if (dtct.Rows.Count==0) return;
			int iTuoi=(namsinh.Text!="")?DateTime.Now.Year-int.Parse(namsinh.Text):0;
			tongcong(dtct);
			int d_toaso=d.get_sotoa_ngtru(s_mmyy,l_id,ngaysp.Text,i_quay);
			d.execute_data("update "+xxx+".d_ngtrull set sotoa="+d_toaso+" where id="+l_id);
			lbltoa.Text=d_toaso.ToString();
			d.updrec_ngtrull(dtll,l_id,d_toaso);
			string s_chandoan="",s_tenkho=(s_makho=="")?"":makho.Text,lydo=loai.Text;
            foreach (DataRow r in d.get_data("select * from " + xxx + ".d_chandoan where loai=0 and id=" + l_id).Tables[0].Rows)
				s_chandoan+=r["maicd"].ToString().Trim()+"-"+r["chandoan"].ToString().Trim()+";";
			dsxml.Clear();
			DataRow r2;
			string ns="",sothe="",denngay="",phai="",diachi="";
			if (l_maql!=0)
			{
				foreach(DataRow r in m.get_data("select sothe,to_char(denngay,'dd/mm/yyyy') as denngay from "+xxx+".bhyt where maql="+l_maql).Tables[0].Rows)
				{
					sothe=r["sothe"].ToString();
					denngay=r["denngay"].ToString();
				}
			}
			sql="select a.*,b.sothe,to_char(b.denngay,'dd/mm/yyyy') as denngay,c.tenpxa,d.tenquan ";
			sql+="from "+user+".btdbn a left join "+xxx+".bhyt b on a.mabn=b.mabn inner join "+user+".btdpxa c on a.maphuongxa=c.maphuongxa inner join "+user+".btdquan d on a.maqu=d.maqu ";
			sql+=" where a.mabn='"+sophieu.Text+"'";
			sql+=" order by b.maql desc";
			foreach(DataRow r in d.get_data(sql).Tables[0].Rows)
			{
				ns=r["namsinh"].ToString();
				phai=(r["phai"].ToString()=="0")?"Nam":"Nữ";
				diachi=r["sonha"].ToString().Trim()+" "+r["thon"].ToString().Trim()+","+r["tenpxa"].ToString().Trim()+","+r["tenquan"].ToString().Trim();
				if (sothe!="")
				{
					sothe=r["sothe"].ToString();
					denngay=r["denngay"].ToString();
				}
				break;
			}
			foreach(DataRow r in dtct.Rows)
			{
				r2=m.getrowbyid(dtbd,"id="+int.Parse(r["mabd"].ToString()));
				if (r2!=null)
				{
					m.updrec_ravien(dsxml,sophieu.Text,sophieu.Text,l_maql,0,hoten.Text,ns,phai,diachi,m.iTreem6tuoi,
						"Trẻ em < 6 tuổi",sothe,0,denngay,"","","","",(tenkp.Text!="")?tenkp.Text:"Khoa khám bệnh",
						ngaysp.Text,ngaysp.Text,s_chandoan,"",int.Parse(r2["sttnhom"].ToString()),
						r2["nhom"].ToString(),int.Parse(r2["sttloai"].ToString()),r2["loai"].ToString(),
						int.Parse(r["mabd"].ToString()),r["ten"].ToString(),r["dang"].ToString(),
						decimal.Parse(r["soluong"].ToString()),decimal.Parse(r["sotien"].ToString()),
                        0, 0, 0, m.get_nguoinha(d.mmyy(s_ngay), sophieu.Text, l_maql), 1, 0, 0, "",
                        decimal.Parse(r["dongia"].ToString()), false, 0, "", "", "", "", m.iTreem6tuoi,
                        (decimal.Parse(r["soluong"].ToString())!=0)?
                        decimal.Parse(r["sotien"].ToString())/decimal.Parse(r["soluong"].ToString()):0,
                        0,decimal.Parse(r["sotien"].ToString()),0,int.Parse(r2["kythuat"].ToString()),mabs.Text);
				}
			}
			string tenfile=d.bIndieutreem(i_nhom)?"rpt_ttravien_te.rpt":"rpt_ttravien_kp.rpt";
			frmReport f=new frmReport(d,dsxml.Tables[0], i_userid,(tenkp.Text!="")?tenkp.Text:"Khoa khám bệnh",tenfile);
			f.ShowDialog();
		}

		private void makp_Validated(object sender, System.EventArgs e)
		{
			try
			{
				DataRow r1=d.getrowbyid(dtduockp,"ma='"+makp.Text+"'");
				if (r1!=null) tenkp.Text=r1["ten"].ToString();
			}
			catch{tenkp.Text="";}
		}

		private void makp_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

        private void frmNgoaitru_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F7) butIn_Click(sender, e);
            else if (e.KeyCode == Keys.F9) butTreem_Click(sender, e);
        }
	}
}
