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
using System.IO;

namespace Duoc
{
	/// <summary>
	/// Summary description for frmXkhac.
	/// </summary>
	public class frmBaohiem : System.Windows.Forms.Form
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
		private string user,s_mmyy,xxx,yyy,s_ngay,sql,s_ngaysp,s_makho,s_kho,s_manguon,format_soluong,format_dongia,format_sotien,s_userid;
        private int i_nhom, i_userid, i_mabd, i_old, i_songay, i_loai, i_madoituong, i_loaiba, itable, traituyen = 0, i_khudt=0;
		private decimal l_id,l_sttt,l_maql,l_mavaovien;
		private decimal d_soluong,d_dongia,d_sotien,d_soluongton,d_soluongcu,d_tongcong,d_giaban,d_sotienmua;
        private bool bKhoaso, bNew, bEdit = true, bAdmin, bTiepdon, bMabn, bLoad, bLoc, bCongkham, bThongbao, bChandoan, bSotien, bDenngay_sothe, bLockytu, bGiaban = false, b701540, bSothe;
		private LibDuoc.AccessData d;
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
		private DataTable dticd=new DataTable();
		private DataTable dticdkt=new DataTable();
		private DataTable dtvp=new DataTable();
		private DataTable dtbd=new DataTable();
		private DataSet dsxoa=new DataSet();
		private DataSet dsxml=new DataSet();
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
		private LibList.List listICD;
		private System.Windows.Forms.Button butDuyet;
		private System.Windows.Forms.TextBox timkiem;
		private System.Windows.Forms.Label lbltoa;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Button butrefresh;
		private System.Windows.Forms.CheckBox chkInfull;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label l_kemtheo;
		private System.Windows.Forms.TextBox giaban;
		private System.Windows.Forms.TextBox sotienmua;
		private DataTable dtdt=new DataTable();
		private System.Windows.Forms.Button butTreem;
		private System.Windows.Forms.TextBox sum;
		private System.Windows.Forms.Label label22;
        private FileStream fstr;
        private byte[] image;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmBaohiem(LibDuoc.AccessData acc,int loai,string mmyy,string ngay,int nhom,int userid,string kho,string title,bool admin,int madoituong,int loaiba,string tenuser,int _khudt)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			d=acc;i_nhom=nhom;s_kho=kho;i_userid=userid;s_mmyy=mmyy;
			s_ngay=ngay;i_loai=loai;bAdmin = admin; i_loaiba = loaiba;
            i_madoituong = madoituong; this.Text = title; s_userid = tenuser;
            lan.Read_Language_to_Xml(this.Name.ToString(), this);
            lan.Changelanguage_to_English(this.Name.ToString(), this);
            i_khudt = _khudt;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBaohiem));
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
            this.listICD = new LibList.List();
            this.timkiem = new System.Windows.Forms.TextBox();
            this.lbltoa = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.butrefresh = new System.Windows.Forms.Button();
            this.chkInfull = new System.Windows.Forms.CheckBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.giaban = new System.Windows.Forms.TextBox();
            this.sotienmua = new System.Windows.Forms.TextBox();
            this.butTreem = new System.Windows.Forms.Button();
            this.sum = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.l_kemtheo = new System.Windows.Forms.Label();
            this.butDuyet = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.butIn = new System.Windows.Forms.Button();
            this.butHuy = new System.Windows.Forms.Button();
            this.butBoqua = new System.Windows.Forms.Button();
            this.butXoa = new System.Windows.Forms.Button();
            this.butThem = new System.Windows.Forms.Button();
            this.butLuu = new System.Windows.Forms.Button();
            this.butSua = new System.Windows.Forms.Button();
            this.butMoi = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(110, 7);
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
            this.label9.Location = new System.Drawing.Point(264, 7);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 23);
            this.label9.TabIndex = 8;
            this.label9.Text = "Họ tên :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(535, 8);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 23);
            this.label10.TabIndex = 9;
            this.label10.Text = "Địa chỉ :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ngaysp
            // 
            this.ngaysp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngaysp.Enabled = false;
            this.ngaysp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngaysp.Location = new System.Drawing.Point(43, 7);
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
            this.listDMBD.Location = new System.Drawing.Point(376, 547);
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
            this.lMabd.Location = new System.Drawing.Point(24, 430);
            this.lMabd.Name = "lMabd";
            this.lMabd.Size = new System.Drawing.Size(32, 23);
            this.lMabd.TabIndex = 28;
            this.lMabd.Text = "Mã :";
            this.lMabd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lTen
            // 
            this.lTen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lTen.Location = new System.Drawing.Point(128, 430);
            this.lTen.Name = "lTen";
            this.lTen.Size = new System.Drawing.Size(72, 23);
            this.lTen.TabIndex = 29;
            this.lTen.Text = "Tên :";
            this.lTen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ldvt
            // 
            this.ldvt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ldvt.Location = new System.Drawing.Point(3, 453);
            this.ldvt.Name = "ldvt";
            this.ldvt.Size = new System.Drawing.Size(53, 23);
            this.ldvt.TabIndex = 30;
            this.ldvt.Text = "ĐVT :";
            this.ldvt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label16.Location = new System.Drawing.Point(145, 452);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(56, 23);
            this.label16.TabIndex = 31;
            this.label16.Text = "Số lượng :";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label17.Location = new System.Drawing.Point(312, 452);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(56, 23);
            this.label17.TabIndex = 32;
            this.label17.Text = "Đơn giá :";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label18.Location = new System.Drawing.Point(0, 476);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(56, 23);
            this.label18.TabIndex = 33;
            this.label18.Text = "Số tiền :";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label20.Location = new System.Drawing.Point(305, 476);
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
            this.tenbd.Location = new System.Drawing.Point(200, 430);
            this.tenbd.Name = "tenbd";
            this.tenbd.Size = new System.Drawing.Size(264, 21);
            this.tenbd.TabIndex = 16;
            this.tenbd.TextChanged += new System.EventHandler(this.tenbd_TextChanged);
            this.tenbd.Validated += new System.EventHandler(this.tenbd_Validated);
            this.tenbd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbd_KeyDown);
            // 
            // mabd
            // 
            this.mabd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.mabd.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.mabd.Enabled = false;
            this.mabd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabd.Location = new System.Drawing.Point(56, 430);
            this.mabd.Name = "mabd";
            this.mabd.Size = new System.Drawing.Size(52, 21);
            this.mabd.TabIndex = 15;
            this.mabd.TextChanged += new System.EventHandler(this.mabd_TextChanged);
            this.mabd.Validated += new System.EventHandler(this.mabd_Validated);
            this.mabd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mabd_KeyDown);
            // 
            // dang
            // 
            this.dang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dang.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dang.Enabled = false;
            this.dang.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dang.Location = new System.Drawing.Point(56, 453);
            this.dang.Mask = "";
            this.dang.MaxLength = 10;
            this.dang.Name = "dang";
            this.dang.Size = new System.Drawing.Size(88, 21);
            this.dang.TabIndex = 18;
            // 
            // soluong
            // 
            this.soluong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.soluong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.soluong.Enabled = false;
            this.soluong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.soluong.Location = new System.Drawing.Point(200, 453);
            this.soluong.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
            this.soluong.Name = "soluong";
            this.soluong.Size = new System.Drawing.Size(112, 21);
            this.soluong.TabIndex = 19;
            this.soluong.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.soluong.Validated += new System.EventHandler(this.soluong_Validated);
            // 
            // dongia
            // 
            this.dongia.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dongia.Enabled = false;
            this.dongia.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dongia.Location = new System.Drawing.Point(320, 320);
            this.dongia.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.dongia.Name = "dongia";
            this.dongia.Size = new System.Drawing.Size(94, 21);
            this.dongia.TabIndex = 18;
            this.dongia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // sotien
            // 
            this.sotien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.sotien.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sotien.Enabled = false;
            this.sotien.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sotien.Location = new System.Drawing.Point(56, 476);
            this.sotien.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.sotien.Name = "sotien";
            this.sotien.Size = new System.Drawing.Size(88, 21);
            this.sotien.TabIndex = 21;
            this.sotien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cmbSophieu
            // 
            this.cmbSophieu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSophieu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSophieu.Location = new System.Drawing.Point(153, 7);
            this.cmbSophieu.Name = "cmbSophieu";
            this.cmbSophieu.Size = new System.Drawing.Size(94, 21);
            this.cmbSophieu.TabIndex = 0;
            this.cmbSophieu.SelectedIndexChanged += new System.EventHandler(this.cmbSophieu_SelectedIndexChanged);
            this.cmbSophieu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbSophieu_KeyDown);
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label15.Location = new System.Drawing.Point(616, 476);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(61, 23);
            this.label15.TabIndex = 61;
            this.label15.Text = "Hạn dùng :";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label24
            // 
            this.label24.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label24.Location = new System.Drawing.Point(700, 476);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(31, 23);
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
            this.handung.Location = new System.Drawing.Point(675, 476);
            this.handung.Mask = "####";
            this.handung.Name = "handung";
            this.handung.Size = new System.Drawing.Size(32, 21);
            this.handung.TabIndex = 25;
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
            this.losx.Location = new System.Drawing.Point(730, 476);
            this.losx.Mask = "&&&&&&&&&&";
            this.losx.MaxLength = 10;
            this.losx.Name = "losx";
            this.losx.Size = new System.Drawing.Size(56, 21);
            this.losx.TabIndex = 26;
            this.losx.Text = "          ";
            // 
            // tenhc
            // 
            this.tenhc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tenhc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenhc.Enabled = false;
            this.tenhc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenhc.Location = new System.Drawing.Point(530, 430);
            this.tenhc.Name = "tenhc";
            this.tenhc.Size = new System.Drawing.Size(256, 21);
            this.tenhc.TabIndex = 17;
            // 
            // lTenhc
            // 
            this.lTenhc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lTenhc.Location = new System.Drawing.Point(465, 429);
            this.lTenhc.Name = "lTenhc";
            this.lTenhc.Size = new System.Drawing.Size(66, 23);
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
            this.sophieu.Location = new System.Drawing.Point(153, 7);
            this.sophieu.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.sophieu.MaxLength = 10;
            this.sophieu.Name = "sophieu";
            this.sophieu.Size = new System.Drawing.Size(94, 21);
            this.sophieu.TabIndex = 1;
            this.sophieu.Validated += new System.EventHandler(this.sophieu_Validated);
            // 
            // label25
            // 
            this.label25.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label25.Location = new System.Drawing.Point(461, 452);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(72, 23);
            this.label25.TabIndex = 66;
            this.label25.Text = "Cách dùng :";
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
            this.dataGrid1.Location = new System.Drawing.Point(8, 80);
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
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.Location = new System.Drawing.Point(461, 476);
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
            this.manguon.Location = new System.Drawing.Point(368, 476);
            this.manguon.Name = "manguon";
            this.manguon.Size = new System.Drawing.Size(96, 21);
            this.manguon.TabIndex = 23;
            // 
            // nhomcc
            // 
            this.nhomcc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nhomcc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nhomcc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nhomcc.Enabled = false;
            this.nhomcc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhomcc.Location = new System.Drawing.Point(530, 476);
            this.nhomcc.Name = "nhomcc";
            this.nhomcc.Size = new System.Drawing.Size(86, 21);
            this.nhomcc.TabIndex = 24;
            // 
            // stt
            // 
            this.stt.Location = new System.Drawing.Point(96, 344);
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
            // diachi
            // 
            this.diachi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.diachi.BackColor = System.Drawing.SystemColors.HighlightText;
            this.diachi.Enabled = false;
            this.diachi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diachi.Location = new System.Drawing.Point(584, 7);
            this.diachi.Name = "diachi";
            this.diachi.Size = new System.Drawing.Size(200, 21);
            this.diachi.TabIndex = 4;
            this.diachi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.diachi_KeyDown);
            // 
            // makho
            // 
            this.makho.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.makho.BackColor = System.Drawing.SystemColors.HighlightText;
            this.makho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.makho.Enabled = false;
            this.makho.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makho.Location = new System.Drawing.Point(200, 476);
            this.makho.Name = "makho";
            this.makho.Size = new System.Drawing.Size(112, 21);
            this.makho.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.Location = new System.Drawing.Point(169, 476);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 23);
            this.label5.TabIndex = 73;
            this.label5.Text = "Kho :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(459, 7);
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
            this.hoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoten.Location = new System.Drawing.Point(312, 7);
            this.hoten.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.hoten.Name = "hoten";
            this.hoten.Size = new System.Drawing.Size(150, 21);
            this.hoten.TabIndex = 2;
            // 
            // namsinh
            // 
            this.namsinh.BackColor = System.Drawing.SystemColors.HighlightText;
            this.namsinh.Enabled = false;
            this.namsinh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namsinh.Location = new System.Drawing.Point(512, 8);
            this.namsinh.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.namsinh.MaxLength = 4;
            this.namsinh.Name = "namsinh";
            this.namsinh.Size = new System.Drawing.Size(32, 21);
            this.namsinh.TabIndex = 3;
            this.namsinh.Validated += new System.EventHandler(this.namsinh_Validated);
            // 
            // cachdung
            // 
            this.cachdung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cachdung.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cachdung.Enabled = false;
            this.cachdung.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cachdung.Location = new System.Drawing.Point(530, 453);
            this.cachdung.Name = "cachdung";
            this.cachdung.Size = new System.Drawing.Size(256, 21);
            this.cachdung.TabIndex = 20;
            this.cachdung.TextChanged += new System.EventHandler(this.cachdung_TextChanged);
            this.cachdung.Validated += new System.EventHandler(this.cachdung_Validated);
            this.cachdung.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cachdung_KeyDown);
            // 
            // listcachdung
            // 
            this.listcachdung.BackColor = System.Drawing.SystemColors.Info;
            this.listcachdung.ColumnCount = 0;
            this.listcachdung.Location = new System.Drawing.Point(296, 547);
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
            this.label6.Location = new System.Drawing.Point(182, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 23);
            this.label6.TabIndex = 81;
            this.label6.Text = "Số thẻ :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(-18, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 23);
            this.label7.TabIndex = 82;
            this.label7.Text = "Đ.tượng :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(395, 32);
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
            this.maphu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maphu.Location = new System.Drawing.Point(43, 31);
            this.maphu.Name = "maphu";
            this.maphu.Size = new System.Drawing.Size(141, 21);
            this.maphu.TabIndex = 5;
            this.maphu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.maphu_KeyDown);
            // 
            // tenbv
            // 
            this.tenbv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tenbv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbv.Enabled = false;
            this.tenbv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbv.Location = new System.Drawing.Point(530, 31);
            this.tenbv.Name = "tenbv";
            this.tenbv.Size = new System.Drawing.Size(254, 21);
            this.tenbv.TabIndex = 8;
            this.tenbv.TextChanged += new System.EventHandler(this.tenbv_TextChanged);
            this.tenbv.Validated += new System.EventHandler(this.tenbv_Validated);
            this.tenbv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbv_KeyDown);
            // 
            // mabv
            // 
            this.mabv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.mabv.Enabled = false;
            this.mabv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabv.Location = new System.Drawing.Point(474, 32);
            this.mabv.Name = "mabv";
            this.mabv.Size = new System.Drawing.Size(54, 21);
            this.mabv.TabIndex = 7;
            // 
            // listDstt
            // 
            this.listDstt.BackColor = System.Drawing.SystemColors.Info;
            this.listDstt.ColumnCount = 0;
            this.listDstt.Location = new System.Drawing.Point(456, 547);
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
            this.sobienlai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sobienlai.Location = new System.Drawing.Point(152, 336);
            this.sobienlai.Name = "sobienlai";
            this.sobienlai.Size = new System.Drawing.Size(40, 21);
            this.sobienlai.TabIndex = 89;
            // 
            // sothe
            // 
            this.sothe.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sothe.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.sothe.Enabled = false;
            this.sothe.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sothe.Location = new System.Drawing.Point(225, 31);
            this.sothe.MaxLength = 20;
            this.sothe.Name = "sothe";
            this.sothe.Size = new System.Drawing.Size(183, 21);
            this.sothe.TabIndex = 6;
            this.sothe.Validated += new System.EventHandler(this.sothe_Validated);
            this.sothe.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sothe_KeyDown);
            // 
            // tenbs
            // 
            this.tenbs.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbs.Enabled = false;
            this.tenbs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbs.Location = new System.Drawing.Point(259, 54);
            this.tenbs.Name = "tenbs";
            this.tenbs.Size = new System.Drawing.Size(149, 21);
            this.tenbs.TabIndex = 12;
            this.tenbs.TextChanged += new System.EventHandler(this.tenbs_TextChanged);
            this.tenbs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbs_KeyDown);
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(180, 54);
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
            this.tenkp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenkp.Location = new System.Drawing.Point(68, 54);
            this.tenkp.Name = "tenkp";
            this.tenkp.Size = new System.Drawing.Size(116, 21);
            this.tenkp.TabIndex = 10;
            this.tenkp.TextChanged += new System.EventHandler(this.tenkp_TextChanged);
            this.tenkp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenkp_KeyDown);
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(403, 54);
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
            this.mabs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mabs.Location = new System.Drawing.Point(225, 54);
            this.mabs.Name = "mabs";
            this.mabs.Size = new System.Drawing.Size(32, 21);
            this.mabs.TabIndex = 11;
            this.mabs.Validated += new System.EventHandler(this.mabs_Validated);
            this.mabs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.diachi_KeyDown);
            // 
            // makp
            // 
            this.makp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.makp.Enabled = false;
            this.makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makp.Location = new System.Drawing.Point(43, 54);
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(24, 21);
            this.makp.TabIndex = 9;
            this.makp.Validated += new System.EventHandler(this.makp_Validated);
            this.makp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.diachi_KeyDown);
            // 
            // chandoan
            // 
            this.chandoan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.chandoan.BackColor = System.Drawing.SystemColors.HighlightText;
            this.chandoan.Enabled = false;
            this.chandoan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chandoan.Location = new System.Drawing.Point(530, 54);
            this.chandoan.Name = "chandoan";
            this.chandoan.Size = new System.Drawing.Size(254, 21);
            this.chandoan.TabIndex = 14;
            this.chandoan.TextChanged += new System.EventHandler(this.chandoan_TextChanged);
            this.chandoan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chandoan_KeyDown);
            // 
            // maicd
            // 
            this.maicd.BackColor = System.Drawing.SystemColors.HighlightText;
            this.maicd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.maicd.Enabled = false;
            this.maicd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maicd.Location = new System.Drawing.Point(474, 54);
            this.maicd.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.maicd.Name = "maicd";
            this.maicd.Size = new System.Drawing.Size(54, 21);
            this.maicd.TabIndex = 13;
            this.maicd.Validated += new System.EventHandler(this.maicd_Validated);
            // 
            // listBTDKP
            // 
            this.listBTDKP.BackColor = System.Drawing.SystemColors.Info;
            this.listBTDKP.ColumnCount = 0;
            this.listBTDKP.Location = new System.Drawing.Point(96, 547);
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
            this.listDMBS.BackColor = System.Drawing.SystemColors.Info;
            this.listDMBS.ColumnCount = 0;
            this.listDMBS.Location = new System.Drawing.Point(176, 547);
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
            // listICD
            // 
            this.listICD.BackColor = System.Drawing.SystemColors.Info;
            this.listICD.ColumnCount = 0;
            this.listICD.Location = new System.Drawing.Point(560, 547);
            this.listICD.MatchBufferTimeOut = 1000;
            this.listICD.MatchEntryStyle = AsYetUnnamed.MatchEntryStyle.FirstLetterInsensitive;
            this.listICD.Name = "listICD";
            this.listICD.Size = new System.Drawing.Size(75, 17);
            this.listICD.TabIndex = 99;
            this.listICD.TextIndex = -1;
            this.listICD.TextMember = null;
            this.listICD.ValueIndex = -1;
            this.listICD.Visible = false;
            // 
            // timkiem
            // 
            this.timkiem.BackColor = System.Drawing.SystemColors.HighlightText;
            this.timkiem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timkiem.ForeColor = System.Drawing.Color.Red;
            this.timkiem.Location = new System.Drawing.Point(43, 77);
            this.timkiem.Name = "timkiem";
            this.timkiem.Size = new System.Drawing.Size(141, 21);
            this.timkiem.TabIndex = 109;
            this.timkiem.Text = "Tìm kiếm";
            this.timkiem.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.timkiem.TextChanged += new System.EventHandler(this.timkiem_TextChanged);
            this.timkiem.Enter += new System.EventHandler(this.timkiem_Enter);
            // 
            // lbltoa
            // 
            this.lbltoa.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltoa.ForeColor = System.Drawing.Color.Red;
            this.lbltoa.Location = new System.Drawing.Point(707, 79);
            this.lbltoa.Name = "lbltoa";
            this.lbltoa.Size = new System.Drawing.Size(74, 17);
            this.lbltoa.TabIndex = 108;
            this.lbltoa.Text = "0";
            this.lbltoa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(557, 78);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(144, 18);
            this.label14.TabIndex = 107;
            this.label14.Text = "Số toa đã phát trong ngày :";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butrefresh
            // 
            this.butrefresh.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butrefresh.Location = new System.Drawing.Point(248, 6);
            this.butrefresh.Name = "butrefresh";
            this.butrefresh.Size = new System.Drawing.Size(24, 22);
            this.butrefresh.TabIndex = 110;
            this.butrefresh.Text = "...";
            this.butrefresh.Click += new System.EventHandler(this.butrefresh_Click);
            // 
            // chkInfull
            // 
            this.chkInfull.Checked = true;
            this.chkInfull.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkInfull.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkInfull.Location = new System.Drawing.Point(-61, 547);
            this.chkInfull.Name = "chkInfull";
            this.chkInfull.Size = new System.Drawing.Size(128, 22);
            this.chkInfull.TabIndex = 111;
            this.chkInfull.Text = "In toa BHYT đầy đủ";
            this.chkInfull.Visible = false;
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.Red;
            this.label19.Location = new System.Drawing.Point(474, 80);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(54, 17);
            this.label19.TabIndex = 112;
            this.label19.Text = "0";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label21
            // 
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(435, 80);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(40, 18);
            this.label21.TabIndex = 113;
            this.label21.Text = "Toa :";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // giaban
            // 
            this.giaban.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.giaban.BackColor = System.Drawing.SystemColors.HighlightText;
            this.giaban.Enabled = false;
            this.giaban.Location = new System.Drawing.Point(368, 454);
            this.giaban.Name = "giaban";
            this.giaban.Size = new System.Drawing.Size(96, 20);
            this.giaban.TabIndex = 230;
            this.giaban.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // sotienmua
            // 
            this.sotienmua.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sotienmua.Enabled = false;
            this.sotienmua.Location = new System.Drawing.Point(464, 280);
            this.sotienmua.Name = "sotienmua";
            this.sotienmua.Size = new System.Drawing.Size(104, 20);
            this.sotienmua.TabIndex = 231;
            // 
            // butTreem
            // 
            this.butTreem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butTreem.Image = global::Duoc.Properties.Resources.F9;
            this.butTreem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butTreem.Location = new System.Drawing.Point(585, 505);
            this.butTreem.Name = "butTreem";
            this.butTreem.Size = new System.Drawing.Size(114, 25);
            this.butTreem.TabIndex = 232;
            this.butTreem.Text = "In &chi phí điều trị";
            this.butTreem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butTreem.Click += new System.EventHandler(this.butTreem_Click);
            // 
            // sum
            // 
            this.sum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sum.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sum.Enabled = false;
            this.sum.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sum.Location = new System.Drawing.Point(530, 406);
            this.sum.Name = "sum";
            this.sum.Size = new System.Drawing.Size(256, 21);
            this.sum.TabIndex = 234;
            this.sum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label22
            // 
            this.label22.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label22.Location = new System.Drawing.Point(464, 406);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(67, 23);
            this.label22.TabIndex = 233;
            this.label22.Text = "Tổng cộng :";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // l_kemtheo
            // 
            this.l_kemtheo.BackColor = System.Drawing.Color.Transparent;
            this.l_kemtheo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.l_kemtheo.Enabled = false;
            this.l_kemtheo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_kemtheo.ForeColor = System.Drawing.SystemColors.WindowText;
            this.l_kemtheo.Image = ((System.Drawing.Image)(resources.GetObject("l_kemtheo.Image")));
            this.l_kemtheo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.l_kemtheo.Location = new System.Drawing.Point(222, 80);
            this.l_kemtheo.Name = "l_kemtheo";
            this.l_kemtheo.Size = new System.Drawing.Size(112, 17);
            this.l_kemtheo.TabIndex = 229;
            this.l_kemtheo.Text = "       Bệnh kèm theo";
            this.l_kemtheo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.l_kemtheo.Click += new System.EventHandler(this.l_kemtheo_Click);
            // 
            // butDuyet
            // 
            this.butDuyet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butDuyet.Image = ((System.Drawing.Image)(resources.GetObject("butDuyet.Image")));
            this.butDuyet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butDuyet.Location = new System.Drawing.Point(1, 403);
            this.butDuyet.Name = "butDuyet";
            this.butDuyet.Size = new System.Drawing.Size(106, 25);
            this.butDuyet.TabIndex = 35;
            this.butDuyet.Text = "Đơn thuốc";
            this.butDuyet.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butDuyet.Click += new System.EventHandler(this.butDuyet_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butKetthuc.Image = global::Duoc.Properties.Resources.close_r;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(699, 505);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 36;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // butIn
            // 
            this.butIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butIn.Image = global::Duoc.Properties.Resources.F7;
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(490, 505);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(95, 25);
            this.butIn.TabIndex = 34;
            this.butIn.Text = "&In đơn thuốc";
            this.butIn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butHuy
            // 
            this.butHuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butHuy.Image = global::Duoc.Properties.Resources.delete_enabled;
            this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHuy.Location = new System.Drawing.Point(420, 505);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(70, 25);
            this.butHuy.TabIndex = 33;
            this.butHuy.Text = "   &Hủy";
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butBoqua.Enabled = false;
            this.butBoqua.Image = global::Duoc.Properties.Resources.undo_ok;
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(350, 505);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(70, 25);
            this.butBoqua.TabIndex = 32;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butXoa
            // 
            this.butXoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butXoa.Enabled = false;
            this.butXoa.Image = global::Duoc.Properties.Resources.Cancel;
            this.butXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butXoa.Location = new System.Drawing.Point(280, 505);
            this.butXoa.Name = "butXoa";
            this.butXoa.Size = new System.Drawing.Size(70, 25);
            this.butXoa.TabIndex = 28;
            this.butXoa.Text = "    &Xóa";
            this.butXoa.Click += new System.EventHandler(this.butXoa_Click);
            // 
            // butThem
            // 
            this.butThem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butThem.Enabled = false;
            this.butThem.Image = global::Duoc.Properties.Resources.plus;
            this.butThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butThem.Location = new System.Drawing.Point(210, 505);
            this.butThem.Name = "butThem";
            this.butThem.Size = new System.Drawing.Size(70, 25);
            this.butThem.TabIndex = 27;
            this.butThem.Text = "&Thêm";
            this.butThem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butThem.Click += new System.EventHandler(this.butThem_Click);
            // 
            // butLuu
            // 
            this.butLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butLuu.Enabled = false;
            this.butLuu.Image = global::Duoc.Properties.Resources.save;
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(140, 505);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 31;
            this.butLuu.Text = "    &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butSua
            // 
            this.butSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butSua.Image = global::Duoc.Properties.Resources.quick_edit;
            this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.Location = new System.Drawing.Point(70, 505);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(70, 25);
            this.butSua.TabIndex = 30;
            this.butSua.Text = "    &Sửa";
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butMoi
            // 
            this.butMoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butMoi.Image = global::Duoc.Properties.Resources.add;
            this.butMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMoi.Location = new System.Drawing.Point(0, 505);
            this.butMoi.Name = "butMoi";
            this.butMoi.Size = new System.Drawing.Size(70, 25);
            this.butMoi.TabIndex = 29;
            this.butMoi.Text = "    &Mới";
            this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
            // 
            // frmBaohiem
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.sum);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.butTreem);
            this.Controls.Add(this.mabv);
            this.Controls.Add(this.mabs);
            this.Controls.Add(this.makp);
            this.Controls.Add(this.giaban);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.lbltoa);
            this.Controls.Add(this.tenkp);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.timkiem);
            this.Controls.Add(this.l_kemtheo);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.chkInfull);
            this.Controls.Add(this.butrefresh);
            this.Controls.Add(this.butDuyet);
            this.Controls.Add(this.listICD);
            this.Controls.Add(this.listDMBS);
            this.Controls.Add(this.listBTDKP);
            this.Controls.Add(this.maicd);
            this.Controls.Add(this.chandoan);
            this.Controls.Add(this.tenbs);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.sothe);
            this.Controls.Add(this.listDstt);
            this.Controls.Add(this.tenbv);
            this.Controls.Add(this.maphu);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.listcachdung);
            this.Controls.Add(this.makho);
            this.Controls.Add(this.cachdung);
            this.Controls.Add(this.namsinh);
            this.Controls.Add(this.hoten);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.diachi);
            this.Controls.Add(this.cmbSophieu);
            this.Controls.Add(this.sophieu);
            this.Controls.Add(this.ngaysp);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nhomcc);
            this.Controls.Add(this.manguon);
            this.Controls.Add(this.label3);
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
            this.Controls.Add(this.sobienlai);
            this.Controls.Add(this.dongia);
            this.Controls.Add(this.sotien);
            this.Controls.Add(this.sotienmua);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmBaohiem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phiếu xuất bảo hiểm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmBaohiem_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmBaohiem_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmBaohiem_Load(object sender, System.EventArgs e)
		{
            //if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            user = d.user; xxx = user + d.mmyy(s_ngay); yyy = user + s_mmyy; b701540 = d.Mabv_so == 701540; bSothe = d.bSothe;
			if (i_madoituong==1) bGiaban=d.get_data("select * from "+user+".d_doituong where loai=1 and madoituong="+i_madoituong).Tables[0].Rows.Count>0;
			bDenngay_sothe=m.bDenngay_sothe;
			bLockytu=d.bLockytu_traiphai(i_nhom);
			sql="select a.id,a.ma,a.ten,a.dvt,b.stt as sttloai,b.ten as loai,c.stt as sttnhom,c.ten as nhom";
            sql += ", a.kcct, a.bhyt, a.kythuat";
            sql += " from " + user + ".v_giavp a," + user + ".v_loaivp b," + user + ".v_nhomvp c";
			sql+=" where a.id_loai=b.id and b.id_nhom=c.ma";
			dtvp=m.get_data(sql).Tables[0];

			sql="select a.id,a.ma,trim(a.ten)||' '||trim(a.hamluong)||' ['||trim(b.ten)||']' as ten,";
			sql+="a.dang as dvt,c.stt as sttloai,c.ten as loai,d.stt as sttnhom,d.ten as nhom";
            sql += ", a.kcct, a.bhyt, a.kythuat";
            sql += " from " + user + ".d_dmbd a," + user + ".d_dmhang b," + user + ".d_dmnhom c," + user + ".v_nhomvp d";
			sql+=" where a.mahang=b.id and a.manhom=c.id and c.nhomvp=d.ma";
			dtbd=m.get_data(sql).Tables[0];

			format_sotien=d.format_sotien(i_nhom);
			format_dongia=d.format_dongia(i_nhom);
			format_soluong=d.format_soluong(i_nhom);
            d.upd_capsotoa(s_mmyy, 2, s_ngay, (i_madoituong == 1) ? 0 : 1);
			bMabn=d.bMabn_bhyt(i_nhom);
			bTiepdon=m.bTiepdon(LibMedi.AccessData.Duoc);
			bChandoan=d.bChandoan_bhyt(i_nhom);
			bSotien=d.bSotien_bhyt(i_nhom);
			bCongkham=d.bcongkham_bhyt(i_nhom);
			bThongbao=d.bThongbao_bhyt(i_nhom);
			bKhoaso=d.bKhoaso(i_nhom,s_mmyy);
			bLoc=d.bLoc_bhyt(i_nhom);
			butrefresh.Visible=!bLoc;
			i_songay=d.Ngaylv_Ngayht;
			s_makho=d.get_dmkho(i_loai).Trim();
			s_makho=(s_makho=="")?"":s_makho.Substring(0,s_makho.Length-1);
			s_manguon=d.get_manguon(i_loai).Trim();
			s_manguon=(s_manguon=="")?"":s_manguon.Substring(0,s_manguon.Length-1);

			manguon.DisplayMember="TEN";
			manguon.ValueMember="ID";
			if (d.bQuanlynguon(i_nhom))
                manguon.DataSource = d.get_data("select * from " + user + ".d_dmnguon where nhom=" + i_nhom + " order by stt").Tables[0];
			else
                manguon.DataSource = d.get_data("select * from " + user + ".d_dmnguon where id=0 or nhom=" + i_nhom + " order by stt").Tables[0];

			nhomcc.DisplayMember="TEN";
			nhomcc.ValueMember="ID";
			if (d.bQuanlynhomcc(i_nhom))
                nhomcc.DataSource = d.get_data("select * from " + user + ".d_dmnx where nhom=" + i_nhom + " order by stt").Tables[0];
			else
                nhomcc.DataSource = d.get_data("select * from " + user + ".d_dmnx where id=0 or nhom=" + i_nhom + " order by stt").Tables[0];

			makho.DisplayMember="TEN";
			makho.ValueMember="ID";
            sql = "select * from " + user + ".d_dmkho where hide=0 and nhom=" + i_nhom;
            if (i_khudt != 0) sql += " and (khu=0 or khu=" + i_khudt + ")";//binh 210411
			sql+=" order by stt";
			makho.DataSource=d.get_data(sql).Tables[0];
            string s = "";
            sql = "select * from "+user+".doituong ";
            if (i_loaiba != 2)
            {
                if (i_madoituong == 1) sql += " where madoituong=1";
                else
                {
                    sql += "where madoituong<>1";
                    foreach (DataRow r in d.get_data("select madoituong from "+user+".d_dmphieu where id=" + i_loai).Tables[0].Rows) s = r["madoituong"].ToString().Trim();
                    if (s != "") sql += " and madoituong in (" + s.Substring(0, s.Length - 1) + ")";
                }
            }
            else
            {
                foreach (DataRow r in d.get_data("select madoituong from " + user + ".d_dmphieu where id=" + i_loai).Tables[0].Rows) s = r["madoituong"].ToString().Trim();
                if (s != "") sql += " where madoituong in (" + s.Substring(0, s.Length - 1) + ")";
            }
            sql += "order by madoituong";
			dtdt=d.get_data(sql).Tables[0];
			maphu.DisplayMember="DOITUONG";
			maphu.ValueMember="MADOITUONG";
			maphu.DataSource=dtdt;
			if (i_madoituong!=1 && i_loaiba!=2) 
			{
				try
				{
					maphu.SelectedValue=m.iTreem6tuoi.ToString();
				}
				catch{}
			}
            dtdstt = d.get_data("select * from " + user + ".dmnoicapbhyt order by mabv").Tables[0];
			listDstt.DisplayMember="MABV";
			listDstt.ValueMember="TENBV";
			listDstt.DataSource=dtdstt;

			listICD.DisplayMember="CICD10";
			listICD.ValueMember="VVIET";
            dticd = d.get_data("select cicd10,vviet from " + user + ".icd10 order by cicd10").Tables[0];
			listICD.DataSource=dticd;

			listDMBS.DisplayMember="MA";
			listDMBS.ValueMember="HOTEN";
            dtbs = d.get_data("select ma,hoten from " + user + ".dmbs where nhom not in (" + LibMedi.AccessData.nhanvien + "," + LibMedi.AccessData.nghiviec + ") order by hoten").Tables[0];
			listDMBS.DataSource=dtbs;

			listBTDKP.DisplayMember="MAKP";
			listBTDKP.ValueMember="TENKP";
            dtkp = d.get_data("select makp,tenkp from " + user + ".btdkp_bv order by tenkp").Tables[0];
			listBTDKP.DataSource=dtkp;

			listDMBD.DisplayMember="TEN";
			listDMBD.ValueMember="STT";

			listcachdung.DisplayMember="STT";
			listcachdung.ValueMember="TEN";

			cmbSophieu.DisplayMember="MABN";
			cmbSophieu.ValueMember="ID";
			load_sophieu();
			if (dtll.Rows.Count>0) cmbSophieu.SelectedIndex=dtll.Rows.Count-1;	
			if (cmbSophieu.Items.Count>0) l_id=decimal.Parse(cmbSophieu.SelectedValue.ToString());
			else l_id=0;
			load_head();
			AddGridTableStyle();
			dsxoa.ReadXml("..\\..\\..\\xml\\d_bhytthuoc.xml");
			dsxml.ReadXml("..\\..\\..\\xml\\m_inravien.xml");
            dsxml.Tables[0].Columns.Add("Image", typeof(byte[]));
            dsxml.Tables[0].Columns.Add("Imagetk", typeof(byte[]));
            dsxml.Tables[0].Columns.Add("Imageuser", typeof(byte[]));
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
		}

		private void load_sophieu()
		{
            sql = "select distinct a.id,a.mabn,a.mavaovien,a.maql,b.hoten,b.namsinh,to_char(a.ngay,'dd/mm/yyyy') as ngay,";
            sql+="b.diachi,a.makp,a.chandoan,a.maicd,a.mabs,a.sothe,a.maphu,a.mabv,a.sobienlai,a.sotoa,";
            sql+="'' as denngay,'' as tungay,'' as ngay1,'' as ngay2,'' as ngay3,a.traituyen ";
            sql += " from " + yyy + ".bhytkb a," + yyy + ".bhytds b," + yyy + ".bhytthuoc c," + user + ".btdkp_bv d ";
            sql += " where a.id=c.id and a.mabn=b.mabn and a.makp=d.makp ";
            sql += " and a.nhom=" + i_nhom + " and a.loaiba=" + i_loaiba;
			if (bLoc) sql+=" and a.userid="+i_userid;
            if (i_loaiba != 2)
            {
                if (i_madoituong == 1) sql += " and a.maphu=1";
                else sql += " and a.maphu<>1";
            }
			if (d.bLocbaohiem) sql+=" and to_char(a.ngay,'dd/mm/yyyy')='"+s_ngay+"'";
            if (s_kho != "") sql += " and c.makho in (" + s_kho.Substring(0, s_kho.Length - 1) + ")";
            if (i_khudt != 0) sql += " and (d.khu=0 or d.khu=" + i_khudt + ")";//binh 210411
			if (bMabn) sql+=" order by a.sotoa,a.id";
			else sql+=" order by a.mabn";
			dtll=d.get_data(sql).Tables[0];
			cmbSophieu.DataSource=dtll;
			lbltoa.Text=d.get_sotoa_bhyt(s_mmyy,i_nhom,s_ngay,i_madoituong).ToString();
		}

		private void load_grid()
		{
			sql="select a.stt,a.sttt,a.mabd,b.ma,trim(b.ten)||' '||b.hamluong as ten,b.tenhc,b.dang,e.ten as tenkho,c.ten as tennguon,d.ten as tennhomcc,t.handung,t.losx,a.soluong,";
			sql+="t.giamua as dongia,";
			if (bGiaban) sql+=" a.soluong*t.giaban as sotien,t.giaban,";
			else sql+=" a.soluong*t.giamua as sotien,t.giamua as giaban,";
			sql+="a.soluong*t.giamua as sotienmua,a.cachdung,a.makho,t.manguon,t.nhomcc,t.giamua ";
            sql += " from " + yyy + ".bhytthuoc a," + user + ".d_dmbd b," + user + ".d_dmnguon c," + user + ".d_dmnx d," + user + ".d_dmkho e," + yyy + ".d_theodoi t where a.sttt=t.id and a.mabd=b.id and t.manguon=c.id and t.nhomcc=d.id and a.makho=e.id and e.hide=0 and a.id=" + l_id;
            if (i_khudt != 0) sql += " and (e.khu=0 or e.khu=" + i_khudt + ")";//binh 210411
            sql += " order by a.stt";
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
					soluong.Text=d_soluong.ToString(format_soluong);
					dongia.Text=d_dongia.ToString(format_dongia);
					sotien.Text=d_sotien.ToString(format_sotien);
					cachdung.Text=r["cachdung"].ToString();
					makho.SelectedValue=r["makho"].ToString();
					manguon.SelectedValue=r["manguon"].ToString();
					nhomcc.SelectedValue=r["nhomcc"].ToString();
					sttt.Text=r["sttt"].ToString();
                    d_soluongcu = (bNew) ? 0 : d_soluong;
					giaban.Text=r["giaban"].ToString();
					sotienmua.Text=r["sotienmua"].ToString();
					if (butLuu.Enabled)
					{
						tenbd.Enabled=sttt.Text=="0";
						if (d.bNhapmaso) mabd.Enabled=tenbd.Enabled;
						soluong.Enabled=tenbd.Enabled;
						cachdung.Enabled=tenbd.Enabled;
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
			TextCol.Width = 200;
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
			TextCol.Width = 60;
			TextCol.Format=format_soluong;
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = (bGiaban)?"giaban":"dongia";
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
			timkiem.Enabled=!ena;
			sophieu.Visible=ena;
			cmbSophieu.Visible=!ena;
			if(bMabn) sophieu.Enabled=ena;
			hoten.Enabled=ena;
			diachi.Enabled=ena;
			namsinh.Enabled=ena;
			maphu.Enabled=ena;
			if (d.bBaobiem_makp) tenkp.Enabled=ena;
			if (d.bBaobiem_bacsi) tenbs.Enabled=ena;
			if (d.bBaohiem_icd) maicd.Enabled=ena;
			makp.Enabled=tenkp.Enabled;
			mabs.Enabled=tenbs.Enabled;
			chandoan.Enabled=maicd.Enabled;
			if (!bChandoan) maicd.Enabled=false;
			if (d.bNhapmaso) mabd.Enabled=ena;
			if (bSothe)
			{
				sothe.Enabled=ena;
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
			butTreem.Enabled=!ena;
			butKetthuc.Enabled=!ena;
			butDuyet.Enabled=!ena;
			l_kemtheo.Enabled=ena;
			i_old=cmbSophieu.SelectedIndex;
            if (ena) load_dm();
            else
            {
                sophieu.Enabled = false;
            }
            timkiem.Text = "";
            CurrencyManager cm = (CurrencyManager)BindingContext[cmbSophieu.DataSource];
            DataView dv = (DataView)cm.List;
            dv.RowFilter = "";
        }

		private void emp_head()
		{
			RefreshChildren("");
			l_id=0;
			l_maql=0;
            l_mavaovien = 0;
            traituyen = 0;
			ngaysp.Text=s_ngay;
			s_ngaysp=ngaysp.Text;
            sophieu.Text = hoten.Text = namsinh.Text = diachi.Text = cachdung.Text = sothe.Text = tenbv.Text = mabv.Text = "";
            tenbs.Text = mabs.Text = makp.Text = tenkp.Text = maicd.Text = chandoan.Text = "";
			sobienlai.Text="0";
            label19.Text = timkiem.Text = sum.Text = "";
			dtct.Clear();
			dsxoa.Clear();
		}
		
		private void emp_detail()
		{
            sttt.Text = stt.Text = mabd.Text = tenbd.Text = tenhc.Text = dang.Text = "";
            soluong.Text = dongia.Text = sotien.Text = "0";
            handung.Text = losx.Text = cachdung.Text = "";
			manguon.SelectedIndex=-1;
			nhomcc.SelectedIndex=-1;
			makho.SelectedIndex=-1;
			stt.Text=d.get_stt(dtct).ToString();
			giaban.Text="0";
			sotienmua.Text="0";
			d_soluongcu=0;
		}
		private void butMoi_Click(object sender, System.EventArgs e)
		{
			if (bKhoaso)
			{
				MessageBox.Show(lan.Change_language_MessageText("Số liệu tháng")+" "+s_mmyy.Substring(0,2)+" "+lan.Change_language_MessageText("năm")+" "+s_mmyy.Substring(2,2)+" "+
                lan.Change_language_MessageText("đã khóa !")+"\n"+lan.Change_language_MessageText("Nếu cần thay đổi thì vào mục khai báo hệ thống"),d.Msg);
				return;
			}
			ena_object(true);
			l_id=0;
			dtct.Clear();
			dtsave.Clear();
			dticdkt.Clear();
			emp_head();
			emp_detail();
			bNew=true;
			bEdit=true;
			bLoad=false;
			if (i_madoituong!=1 && i_loaiba!=2) 
			{
				try
				{
					maphu.SelectedValue=m.iTreem6tuoi.ToString();
				}
				catch{}
			}
			if (!bMabn) 
			{
                sql = " where nhom=" + i_nhom;
                if (bLoc) sql += " and userid=" + i_userid;
                if (i_loaiba != 2)
                {
                    if (i_madoituong == 1) sql += " and maphu=1";
                    else sql += " and maphu<>1";
                }
                sql += " and loaiba=" + i_loaiba;
                if (d.bLocbaohiem) sql += " and to_char(ngay,'dd/mm/yyyy')='" + s_ngay + "'";
				string s=(i_madoituong==1)?"B":"T";
				sophieu.Text=d.get_sophieu(s_mmyy,"bhytkb","mabn",sql)+s+i_nhom.ToString().PadLeft(1,'0')+s_ngay.Substring(0,2);//d.get_stt(dtll,"mabn").ToString().PadLeft(3,'0');
			}
			if (sophieu.Enabled) sophieu.Focus();
			else hoten.Focus();
		}
		private void butSua_Click(object sender, System.EventArgs e)
		{
			if (cmbSophieu.Items.Count==0) return;
			if (bKhoaso)
			{
				MessageBox.Show(lan.Change_language_MessageText("Số liệu tháng")+" "+s_mmyy.Substring(0,2)+" "+lan.Change_language_MessageText("năm")+" "+s_mmyy.Substring(2,2)+" "+lan.Change_language_MessageText("đã khóa !") + "\n" +lan.Change_language_MessageText("Nếu cần thay đổi thì vào mục khai báo hệ thống"), d.Msg);
				return;
			}
			if(Check_bienlai(l_id))				
			{
				MessageBox.Show(lan.Change_language_MessageText("Thông tin này đã cập nhật vào viện phí !"),d.Msg);
				return;
			}
			l_id=decimal.Parse(cmbSophieu.SelectedValue.ToString());
			if (d.get_done_bhytkb(s_mmyy,l_id))
            {
				MessageBox.Show(lan.Change_language_MessageText("Thông tin này đã cập nhật!"),d.Msg);
				return;
			}
			//luu lai toa sua
			try
			{
                sql = "select a.mabn, a.ngay, b.*, c.ten, c.hamluong, c.dang from " + yyy + ".bhytkb a," + yyy + ".bhytthuoc b, " + user + ".d_dmbd c where a.id=b.id and b.mabd=c.id and a.id=" + l_id;
				DataSet lds=d.get_data(sql);
				//
				if(lds.Tables[0].Rows.Count>0)
				{
					if(Directory.Exists("..\\..\\..\\toahuy")==false)Directory.CreateDirectory("..\\..\\..\\toahuy");
					lds.WriteXml("..\\..\\..\\toahuy\\Sua_"+cmbSophieu.Text+"_"+l_id+".xml",XmlWriteMode.WriteSchema);
				}
				lds.Dispose();
			}
			catch{}
			//
            dticdkt = d.get_data("select * from " + yyy + ".d_chandoan where loai=1 and id=" + l_id).Tables[0];
			ena_object(true);
			if (bMabn)
			{
				hoten.Enabled=false;
				sothe.Enabled=false;
				sophieu.Enabled=false;
				tenkp.Enabled=false;
				tenbs.Enabled=false;
				maicd.Enabled=false;
				chandoan.Enabled=false;
				makp.Enabled=false;
				mabs.Enabled=false;
				tenbv.Enabled=false;
				namsinh.Enabled=false;
				diachi.Enabled=false;
			}
			else sophieu.Enabled=true;
			bNew=false;
			bEdit=true;
			bLoad=false;
			dtsave=dtct.Copy();
			dsxoa.Clear();
			ref_text();
			dataGrid1.Focus();
		}

		private bool KiemtraHead()
		{
			if (sophieu.Text=="")
			{
				MessageBox.Show(
lan.Change_language_MessageText(
"Nhập mã số người bệnh !"),d.Msg);
				sophieu.Focus();
				return false;
			}
			if (ngaysp.Text=="")
			{
				MessageBox.Show(
lan.Change_language_MessageText(
"Nhập ngày số phiếu !"),d.Msg);
				ngaysp.Focus();
				return false;
			}
			if (i_madoituong==1)
			{
				if (sothe.Enabled)
				{
					if (sothe.Text=="")
					{
						MessageBox.Show(
lan.Change_language_MessageText("Yêu cầu nhập số thẻ !"),d.Msg);
						sothe.Focus();
						return false;
					}
				}
				if (tenbv.Enabled && mabv.Enabled)
				{
					r=d.getrowbyid(dtdstt,"mabv='"+mabv.Text+"'");
					if (r==null)
					{
						MessageBox.Show(
lan.Change_language_MessageText("Tên nơi ĐKKCB không hợp lệ !"),d.Msg);
						tenbv.Focus();
						return false;
					}
				}
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
			if (tenkp.Enabled)
			{
				r=d.getrowbyid(dtkp,"tenkp='"+tenkp.Text+"'");
				if (r==null)
				{
					MessageBox.Show(
lan.Change_language_MessageText("Phòng khám không hợp lệ !"),d.Msg);
					tenkp.Focus();
					return false;
				}
			}
			if (maicd.Enabled)
			{
				r=d.getrowbyid(dticd,"cicd10='"+maicd.Text+"'");
				if (r==null)
				{
					MessageBox.Show(
lan.Change_language_MessageText("Chẩn đoán không hợp lệ !"),d.Msg);
					chandoan.Focus();
					return false;
				}
			}
			if (bNew)
			{
				try
				{
					dtct.AcceptChanges();
					int i_toaso=d.kiemtra_baohiem(dtct.Select("soluong>0","mabd,soluong"),s_ngay,sophieu.Text.Trim(),s_mmyy);
					if (i_toaso!=0)
					{
						if (MessageBox.Show(
lan.Change_language_MessageText("Họ tên")+" "+hoten.Text.Trim()+"\n"+
lan.Change_language_MessageText("đã nhập toa số")+" "+i_toaso.ToString()+"\n"+
lan.Change_language_MessageText("Bạn có muốn nhập thêm không ?"),d.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)==DialogResult.No)
							return false;
						else
							hoten.Text=hoten.Text.Trim()+"(+)";
					}
				}
				catch{}
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
				MessageBox.Show(lan.Change_language_MessageText("Mã số không hợp lệ !"),d.Msg);
				if (mabd.Enabled) mabd.Focus();
				else tenbd.Focus();
				return false;
			}
			i_mabd=int.Parse(r["id"].ToString());
			if (soluong.Text=="" || soluong.Text=="0.00" || soluong.Text=="0")
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập số lượng !"),d.Msg);
				soluong.Focus();
				return false;
			}
			return true;
		}

		private void butBoqua_Click(object sender, System.EventArgs e)
		{
			bEdit=false;
			cmbSophieu.SelectedIndex=i_old;
			if(cmbSophieu.Items.Count>0) l_id=decimal.Parse(cmbSophieu.SelectedValue.ToString());
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
			d_giaban=(giaban.Text!="")?decimal.Parse(giaban.Text):0;
			d_sotien=(sotien.Text!="")?decimal.Parse(sotien.Text):0;
			d_sotienmua=(sotienmua.Text!="")?decimal.Parse(sotienmua.Text):0;
			l_sttt=(sttt.Text!="")?decimal.Parse(sttt.Text):0;
			d.updrec_bhytthuoc(dt,int.Parse(stt.Text),l_sttt,i_mabd,mabd.Text,tenbd.Text,tenhc.Text,dang.Text,makho.Text,(manguon.SelectedIndex==-1)?"":manguon.Text,(nhomcc.SelectedIndex==-1)?"":nhomcc.Text,handung.Text,losx.Text,d_soluong,d_dongia,d_sotienmua,d_giaban,d_dongia,d_sotien,cachdung.Text,int.Parse(makho.SelectedValue.ToString()),(manguon.SelectedIndex==-1)?0:int.Parse(manguon.SelectedValue.ToString()),(nhomcc.SelectedIndex==-1)?0:int.Parse(nhomcc.SelectedValue.ToString()),(del)?null:dtton);
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
					MessageBox.Show(lan.Change_language_MessageText("Số liệu tháng")+" "+s_mmyy.Substring(0,2)+" "+lan.Change_language_MessageText("năm")+" "+s_mmyy.Substring(2,2)+" "+lan.Change_language_MessageText("đã khóa !")+"\n"+lan.Change_language_MessageText("Nếu cần thay đổi thì vào mục khai báo hệ thống"),d.Msg);
					return;
				}
				if(Check_bienlai(l_id))
				{
					MessageBox.Show(lan.Change_language_MessageText("Thông tin này đã cập nhật vào viện phí !"),d.Msg);
					return;
				}
                if (d.get_done_bhytkb(s_mmyy, l_id))// && !bAdmin)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Thông tin này đã cập nhật!"), d.Msg);
					return;
				}
				if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý hủy số phiếu này ?"),d.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
				{
					try
					{
                        sql = "select a.mabn, a.ngay, b.*, c.ten, c.hamluong, c.dang from " + yyy + ".bhytkb a, " + yyy + ".bhytthuoc b, " + d.user + ".d_dmbd c where a.id=b.id and b.mabd=c.id and a.id=" + l_id;
						DataSet lds=d.get_data(sql);
						//
						if(lds.Tables[0].Rows.Count>0)
						{
							if(Directory.Exists("..\\..\\..\\toahuy")==false)Directory.CreateDirectory("..\\..\\..\\toahuy");
							lds.WriteXml("..\\..\\..\\toahuy\\huy_"+cmbSophieu.Text+"_"+l_id+".xml",XmlWriteMode.WriteSchema);
						}
						lds.Dispose();
					}
					catch{}
                    itable = d.tableid(s_mmyy, "bhytthuoc");
                    foreach (DataRow r1 in dtct.Rows)
                    {
                        d.upd_eve_tables(s_mmyy, itable, i_userid, "del");
                        d.upd_eve_upd_del(s_mmyy, itable, i_userid, "del", d.fields(xxx + ".bhytthuoc", "id=" + l_id + " and stt=" + int.Parse(r1["stt"].ToString())));
                        d.upd_tonkhoct_xuat(d.delete, s_mmyy, decimal.Parse(r1["sttt"].ToString()), int.Parse(r1["makho"].ToString()), int.Parse(r1["manguon"].ToString()), int.Parse(r1["nhomcc"].ToString()), int.Parse(r1["mabd"].ToString()), r1["handung"].ToString(), r1["losx"].ToString(), decimal.Parse(r1["soluong"].ToString()), decimal.Parse(r1["sotien"].ToString()), 0, 0);
                    }
                    itable = d.tableid(s_mmyy, "bhytkb");
                    d.upd_eve_tables(s_mmyy, itable, i_userid, "del");
                    d.upd_eve_upd_del(s_mmyy, itable, i_userid, "del", d.fields(xxx + ".bhytkb", "id=" + l_id));
                    foreach (DataRow r1 in d.get_data("select * from " + xxx + ".d_thuocbhytct where id=" + l_id).Tables[0].Rows)
                        d.upd_tonkhoth_dutru(d.dutru, i_nhom, s_mmyy, int.Parse(r1["makho"].ToString()), int.Parse(r1["manguon"].ToString()), int.Parse(r1["mabd"].ToString()), decimal.Parse(r1["slthuc"].ToString()));
                    d.execute_data("delete from " + yyy + ".d_chandoan where loai=1 and id=" + l_id);
                    d.execute_data("delete from " + yyy + ".bhytthuoc where id=" + l_id);
                    d.execute_data("delete from " + yyy + ".bhytkb where sobienlai=0 and id=" + l_id);
					d.execute_data("update "+xxx+".d_thuocbhytct set slthuc=0 where id="+l_id);
					d.execute_data("update "+xxx+".d_thuocbhytll set done=0 where id="+l_id);
					d.delrec(dtll,"id="+l_id);
					dtll.AcceptChanges();
					cmbSophieu.Refresh();
					lbltoa.Text=d.get_sotoa_bhyt(s_mmyy,i_nhom,s_ngay,i_madoituong).ToString();
					if (dtll.Rows.Count>0) cmbSophieu.SelectedIndex=dtll.Rows.Count-1;
					if(cmbSophieu.Items.Count>0) l_id=decimal.Parse(cmbSophieu.SelectedValue.ToString());
					else l_id=0;
					load_head();
				}
			}
			catch(Exception ex){MessageBox.Show(ex.Message);}
		}

		private void load_dm()
		{
            dtton = d.get_tonkhoth_bhyt(s_mmyy, s_makho, s_kho, s_manguon, i_madoituong, i_khudt);
			listDMBD.DataSource=dtton;
			dtcachdung=d.get_data("select ten as stt,ten from "+user+".d_dmcachdung order by ten").Tables[0];
			listcachdung.DataSource=dtcachdung;
		}
		private void load_tonct()
		{
			dttonct=d.get_tonkhoct_bhyt(s_mmyy,s_makho,s_kho,s_manguon,i_madoituong,i_nhom);
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			if (!KiemtraHead()) return;
			bEdit=false;
			upd_table(dtct,false);
			dtct.AcceptChanges();
			if (bLoad)
				foreach(DataRow r1 in dtct.Rows)
				{
					d.execute_data("update "+xxx+".d_thuocbhytct set slthuc=slthuc+"+decimal.Parse(r1["soluong"].ToString())+" where id="+l_id+" and stt="+int.Parse(r1["stt"].ToString()));
                    d.upd_tonkhoth_dutru(d.duyet, i_nhom, s_mmyy, int.Parse(r1["makho"].ToString()), int.Parse(r1["manguon"].ToString()), int.Parse(r1["mabd"].ToString()), decimal.Parse(r1["soluong"].ToString()));
				}
			i_old=(bNew)?0:1;
			l_id=(bNew)?d.get_id_bhyt:l_id;
            itable = d.tableid(s_mmyy, "bhytkb");
            if (bNew) d.upd_eve_tables(s_mmyy, itable, i_userid, "ins");
            else
            {
                d.upd_eve_tables(s_mmyy, itable, i_userid, "upd");
                d.upd_eve_upd_del(s_mmyy, itable, i_userid, "upd", l_id.ToString() + "^" + i_nhom.ToString() + "^" + ngaysp.Text + "^" + sophieu.Text + "^" + l_mavaovien.ToString() + "^" + l_maql.ToString() + "^" + makp.Text + "^" + chandoan.Text + "^" + maicd.Text + "^" + mabs.Text + "^" + sothe.Text + "^" + maphu.SelectedValue.ToString() + "^" + mabv.Text + "^" + i_userid.ToString()+"^"+i_loaiba.ToString());
            }
			if (bNew)
			{
                if (!bMabn)
                {
                    sql = " where nhom=" + i_nhom;
                    if (bLoc) sql += " and userid=" + i_userid;
                    if (i_loaiba != 2)
                    {
                        if (i_madoituong == 1) sql += " and maphu=1";
                        else sql += " and maphu<>1";
                    }
                    sql += " and loaiba=" + i_loaiba;
                    if (d.bLocbaohiem) sql += " and to_char(ngay,'dd/mm/yyyy')='" + s_ngay + "'";
                    string s = (i_madoituong == 1) ? "B" : "T";
                    sophieu.Text = d.get_sophieu(s_mmyy, "bhytkb", "mabn", sql) + s + i_nhom.ToString().PadLeft(1, '0') + s_ngay.Substring(0, 2);
                    sophieu.Refresh();
                }
				if (bMabn && bTiepdon)
				{
					l_maql=m.get_tiepdon(sophieu.Text,ngaysp.Text);
					if (l_maql==0)
					{
						int tuoi=(namsinh.Text!="")?int.Parse(ngaysp.Text.Substring(6,4))-int.Parse(namsinh.Text):0;
                        l_maql = m.getidyymmddhhmiss_stt_computer;//m.get_capid(1);
                        string nam = m.get_mabn_nam(sophieu.Text);
                        if (nam.IndexOf(s_mmyy + "+") == -1) nam = nam + s_mmyy + "+";
						m.upd_btdbn(sophieu.Text,hoten.Text,"",(namsinh.Text!="")?namsinh.Text:"0000",m.vodanh_gioitinh,m.vodanh_nghenghiep,m.vodanh_dantoc,"",diachi.Text,"",m.vodanh_tinh,m.vodanh_tinh+"00",m.vodanh_tinh+"0000",i_userid,nam);
						m.upd_lienhe(ngaysp.Text,l_maql,"",diachi.Text,"",m.vodanh_tinh,m.vodanh_tinh+"00",m.vodanh_tinh+"0000",tuoi.ToString().PadLeft(3,'0')+"0",0,0);
						m.upd_tiepdon(sophieu.Text,l_maql,l_maql,(makp.Text!="")?makp.Text:"01",ngaysp.Text,1,"",tuoi.ToString().PadLeft(3,'0')+"0",i_userid,0,LibMedi.AccessData.Duoc,0);
						if (sothe.Text!="") m.upd_bhyt(ngaysp.Text,sophieu.Text,l_maql,sothe.Text,ngaysp.Text,mabv.Text,0,ngaysp.Text,"","","",traituyen);
					}
					m.upd_sukien(ngaysp.Text,sophieu.Text,l_maql,LibMedi.AccessData.Duoc,l_maql);
                    l_mavaovien = l_maql;
				}
			}
            else if (l_maql == 0 && bMabn)
            {
                l_maql = m.get_tiepdon(sophieu.Text, ngaysp.Text);
                l_mavaovien = l_maql;
            }
            if (!d.upd_bhytds(s_mmyy, sophieu.Text, hoten.Text, namsinh.Text, diachi.Text))
            {
                MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin !"), d.Msg);
                return;
            }
			if (!d.upd_bhytkb(s_mmyy,l_id,i_nhom,ngaysp.Text,sophieu.Text,l_mavaovien,l_maql,makp.Text,chandoan.Text,maicd.Text,mabs.Text,sothe.Text,int.Parse(maphu.SelectedValue.ToString()),mabv.Text,i_userid,i_loaiba,traituyen))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin !"),d.Msg);
				return;
			}
			if (dticdkt!=null)
			{
				d.execute_data("delete from "+yyy+".d_chandoan where loai=1 and id="+l_id);
				foreach(DataRow r in dticdkt.Rows) d.upd_chandoan(s_mmyy,l_id,1,r["maicd"].ToString(),r["chandoan"].ToString());
			}
            itable = d.tableid(s_mmyy, "bhytthuoc");
			if (!bNew)
			{
				foreach(DataRow r1 in dsxoa.Tables[0].Rows)
				{
                    d.upd_eve_tables(s_mmyy, itable, i_userid, "del");
                    d.upd_eve_upd_del(s_mmyy, itable, i_userid, "del", d.fields(xxx + ".bhytthuoc", "id=" + l_id + " and stt=" + decimal.Parse(r1["stt"].ToString())));
                    d.execute_data("delete from " + yyy + ".bhytthuoc where id=" + l_id + " and stt=" + decimal.Parse(r1["stt"].ToString()));
					d.upd_tonkhoct_xuat(d.delete,s_mmyy,decimal.Parse(r1["sttt"].ToString()),int.Parse(r1["makho"].ToString()),int.Parse(r1["manguon"].ToString()),int.Parse(r1["nhomcc"].ToString()),int.Parse(r1["mabd"].ToString()),r1["handung"].ToString(),r1["losx"].ToString(),decimal.Parse(r1["soluong"].ToString()),decimal.Parse(r1["sotienmua"].ToString()),decimal.Parse(r1["giaban"].ToString()),decimal.Parse(r1["giamua"].ToString()));
				}
			}
            dtct = d.get_bhytthuoc(s_mmyy, dtct, l_id, (i_loaiba == 2) ? 0 : i_madoituong);
			tongcong(dtct);
			sum.Text=d_tongcong.ToString(format_sotien);
			d.updrec_bhytll(dtll,l_id,sophieu.Text,l_mavaovien,l_maql,hoten.Text,namsinh.Text,ngaysp.Text,diachi.Text,makp.Text,chandoan.Text,maicd.Text,mabs.Text,sothe.Text,int.Parse(maphu.SelectedValue.ToString()),mabv.Text,0);
			d.execute_data("update "+xxx+".d_thuocbhytll set done=1 where id="+l_id);
			dtll.AcceptChanges();
			cmbSophieu.SelectedValue=l_id.ToString();
			lbltoa.Text=d.get_sotoa_bhyt(s_mmyy,i_nhom,s_ngay,i_madoituong).ToString();
			load_grid();
			ena_object(false);
			butMoi.Focus();
		}

		private void tongcong(DataTable dt)
		{
			d_tongcong=0;
			foreach(DataRow r1 in dt.Rows) d_tongcong=d_tongcong+((bGiaban)?decimal.Parse(r1["soluong"].ToString())*decimal.Parse(r1["giaban"].ToString()):decimal.Parse(r1["sotien"].ToString()));
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
			if (dtct.Rows.Count==0) return;
			Print_ToaBHYT_Full();
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

		private bool get_data(string mabn)
		{
			bool ret=false;
			DataRow r1;
			sql="select a.id,a.mabn,a.mavaovien,a.maql,c.sothe,";
            if (i_loaiba == 2) sql += "d.sothe as sothengtr,";
            else sql += "c.sothe as sothengtr,";
            sql+="b.hoten,b.namsinh,trim(b.sonha)||' '||b.thon as diachi,b.cholam,";
			sql+=" c.mabv,a.makp,a.chandoan,a.maicd,a.mabs,a.madoituong,"+traituyen+" as traituyen ";
			sql+=" from "+xxx+".d_thuocbhytll a inner join "+user+".btdbn b on a.mabn=b.mabn ";
            sql+=" left join "+xxx+".bhyt c on a.maql=c.maql ";
            if (i_loaiba==2) sql+=" left join " + user + ".bhyt d on a.maql=d.maql ";
			sql+=" where a.done=0 and to_char(a.ngay,'dd/mm/yyyy')='"+s_ngay+"'";
			sql+=" and a.nhom="+i_nhom+" and a.mabn='"+mabn+"'";
            if (i_loaiba != 2)
            {
                sql += " and a.loaiba<>2";
                if (i_madoituong == 1) sql += " and a.madoituong=1";
                else sql += " and a.madoituong<>1";
            }
            else sql += " and a.loaiba=" + i_loaiba;
			foreach(DataRow r in d.get_data(sql).Tables[0].Rows)
			{
				hoten.Text=r["hoten"].ToString();
				namsinh.Text=r["namsinh"].ToString();
                diachi.Text = r["diachi"].ToString(); //diachi.Text = (r["cholam"].ToString() != "") ? r["cholam"].ToString() : r["diachi"].ToString();
                sothe.Text = (r["sothe"].ToString() != "") ? r["sothe"].ToString() : r["sothengtr"].ToString();
				maphu.SelectedValue=r["madoituong"].ToString();
				chandoan.Text=r["chandoan"].ToString();
				maicd.Text=r["maicd"].ToString();
                l_mavaovien = decimal.Parse(r["mavaovien"].ToString());
				l_maql=decimal.Parse(r["maql"].ToString());
				l_id=decimal.Parse(r["id"].ToString());
				bNew=false;
				bLoad=true;
				makp.Text=r["makp"].ToString();
				mabs.Text=r["mabs"].ToString();
				mabv.Text=r["mabv"].ToString();
				r1=d.getrowbyid(dtkp,"makp='"+makp.Text+"'");
				if (r1!=null) tenkp.Text=r1["tenkp"].ToString();
				else tenkp.Text="";
				r1=d.getrowbyid(dtbs,"ma='"+mabs.Text+"'");
				if (r1!=null) tenbs.Text=r1["hoten"].ToString();
				else tenbs.Text="";
				r1=d.getrowbyid(dtdstt,"mabv='"+mabv.Text+"'");
				if (r1!=null) tenbv.Text=r1["tenbv"].ToString();
				else tenbv.Text="";
				ret=true;
				break;
			}
			if (ret)
			{
				load_thuoc(l_id);
				load_kemtheo();
			}
			return ret;
		}

		private void load_thuoc(decimal id)
		{
			sql="select a.stt,0 as sttt,a.mabd,b.ma,trim(b.ten)||' '||b.hamluong as ten,";
			sql+=" b.tenhc,b.dang,e.ten as tenkho,c.ten as tennguon,' ' as tennhomcc,";
			sql+=" ' ' as handung,' ' as losx,a.slyeucau as soluong,0 as dongia,0 as sotien,0 as giaban,0 as sotienmua,";
			sql+=" a.cachdung,a.makho,a.manguon,0 as nhomcc,0 as giamua ";
			sql+=" from "+xxx+".d_thuocbhytct a,"+user+".d_dmbd b,"+user+".d_dmnguon c,"+user+".d_dmkho e ";
			sql+=" where a.mabd=b.id and a.manguon=c.id and a.makho=e.id and e.hide=0 ";
            if (i_khudt != 0) sql += " and (e.khu=0 or e.khu=" + i_khudt + ")";//binh 210411
			sql+=" and a.id="+id+" order by a.stt";
			foreach(DataRow r in d.get_data(sql).Tables[0].Rows)
				d.updrec_bhytthuoc(dtct,int.Parse(r["stt"].ToString()),0,int.Parse(r["mabd"].ToString()),r["ma"].ToString(),
					r["ten"].ToString(),r["tenhc"].ToString(),r["dang"].ToString(),r["tenkho"].ToString(),r["tennguon"].ToString(),
					r["tennhomcc"].ToString(),r["handung"].ToString(),r["losx"].ToString(),decimal.Parse(r["soluong"].ToString()),
					decimal.Parse(r["dongia"].ToString()),decimal.Parse(r["sotien"].ToString()),0,0,0,r["cachdung"].ToString(),int.Parse(r["makho"].ToString()),
					int.Parse(r["manguon"].ToString()),int.Parse(r["nhomcc"].ToString()),dtton);
		}

		private void sophieu_Validated(object sender, System.EventArgs e)
		{
			if (bNew)
			{
				hoten.Text="";namsinh.Text="";diachi.Text="";
				sothe.Text="";mabv.Text="";
			}
			if (bMabn)
			{
				if (sophieu.Text=="" || sophieu.Text.Trim().Length<3) return;
				if (sophieu.Text.Trim().Length!=8) sophieu.Text=sophieu.Text.Substring(0,2)+sophieu.Text.Substring(2).PadLeft(6,'0');
				l_maql=m.get_tiepdon(sophieu.Text,ngaysp.Text);
				if (!bTiepdon)
				{
					if (l_maql==0)
					{
						MessageBox.Show(lan.Change_language_MessageText("Người bệnh chưa qua tiếp đón !"),d.Msg);
						butBoqua.Focus();
						return;
					}
				}
				if (bThongbao)
				{
					string ten=d.thongbao_baohiem(s_mmyy,sophieu.Text,s_ngay);
					if (ten!="")
					{
						if (ten=="?") ten="";
						else ten="tại "+ten;
						if (MessageBox.Show(lan.Change_language_MessageText("Người bệnh này đã nhập đơn thuốc")+" "+ten+"\n"+lan.Change_language_MessageText("Bạn có nhập tiếp không ?"),d.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)==DialogResult.No)
						{
							butBoqua_Click(sender,e);
							return;
						}
					}
				}
                if (l_maql != 0) l_maql = d.get_macap(s_ngay, l_maql,(i_loaiba==2)?LibMedi.AccessData.Ngoaitru:LibMedi.AccessData.Khambenh);
				if (l_maql!=0)
				{
					if (get_data(sophieu.Text)) 
					{
						butLuu_Click(sender,e);
						return;
					}
                    sql = "select a.hoten,a.namsinh,a.sonha,a.thon,a.cholam,c.sothe,c.mabv,c.maphu,coalesce(c.traituyen,0) as traituyen,";
					sql+="b.makp,b.mabs,b.maicd,b.chandoan,b.madoituong";
					sql+=" from "+user+".btdbn a inner join "+xxx+".benhanpk b on a.mabn=b.mabn left join "+xxx+".bhyt c on b.maql=c.maql ";
                    sql += " where b.maql=" + l_maql;
                    if (i_loaiba != 2)
                    {
                        if (i_madoituong == 1) sql += " and b.madoituong=1 ";
                        else sql += " and b.madoituong<>1 ";
                    }
					foreach(DataRow r1 in m.get_data(sql).Tables[0].Rows)
					{
						hoten.Text=r1["hoten"].ToString();
						namsinh.Text=r1["namsinh"].ToString();
						diachi.Text=r1["sonha"].ToString().Trim()+" "+r1["thon"].ToString().Trim();
                        traituyen = int.Parse(r1["traituyen"].ToString());
						sothe.Text=r1["sothe"].ToString();
						maphu.SelectedValue=r1["madoituong"].ToString();
						mabv.Text=r1["mabv"].ToString();
						mabs.Text=r1["mabs"].ToString();
						makp.Text=r1["makp"].ToString();
						maicd.Text=r1["maicd"].ToString();
						chandoan.Text=r1["chandoan"].ToString();
						r=d.getrowbyid(dtdstt,"mabv='"+mabv.Text+"'");
						if (r!=null) tenbv.Text=r["tenbv"].ToString();
						r=d.getrowbyid(dtkp,"makp='"+makp.Text+"'");
						if (r!=null) tenkp.Text=r["tenkp"].ToString();
						else tenkp.Text="";
						r=d.getrowbyid(dtbs,"ma='"+mabs.Text+"'");
						if (r!=null) tenbs.Text=r["hoten"].ToString();
						else tenbs.Text="";
						break;
					}
					load_kemtheo();
				}
				else //if (i_madoituong==1)
				{
                    sql = "select c.madoituong,a.hoten,a.namsinh,a.sonha,a.thon,a.cholam,coalesce(b.sothe,'') as sothe,coalesce(b.traituyen,0) as traituyen,";
                    sql += "coalesce(b.mabv,'') as mabv,coalesce(b.maphu,0) as maphu,c.maql  ";
					sql+="from "+user+".btdbn a inner join "+xxx+".tiepdon c on a.mabn=c.mabn left join "+xxx+".bhyt b on c.maql=b.maql";
					sql+=" where a.mabn='"+sophieu.Text+"'";
                    if (i_loaiba != 2)
                    {
                        if (i_madoituong == 1) sql += " and c.madoituong=" + i_madoituong;
                        else sql += " and c.madoituong<>1";
                    }
					sql+=" order by c.maql desc";
					foreach(DataRow r1 in d.get_data(sql).Tables[0].Rows)
					{
						l_maql=decimal.Parse(r1["maql"].ToString());
						hoten.Text=r1["hoten"].ToString();
						namsinh.Text=r1["namsinh"].ToString();
	    				diachi.Text=r1["sonha"].ToString().Trim()+" "+r1["thon"].ToString().Trim();
                        traituyen = int.Parse(r1["traituyen"].ToString());
						sothe.Text=r1["sothe"].ToString().Trim();
						maphu.SelectedValue=int.Parse(r1["madoituong"].ToString());
						mabv.Text=r1["mabv"].ToString().Trim();
						if (mabv.Text!="")
						{
							r=d.getrowbyid(dtdstt,"mabv='"+mabv.Text+"'");
							if (r!=null) tenbv.Text=r["tenbv"].ToString();
						}
						break;
					}
				}
				if (hoten.Text=="")
				{
                    foreach (DataRow r1 in d.get_data("select a.hoten,a.namsinh,a.diachi,b.sothe,b.mabv,b.maphu from " + yyy + ".bhytds a," + yyy + ".bhytkb b where a.mabn=b.mabn and b.sothe is not null and a.mabn='" + sophieu.Text + "' order by b.id desc").Tables[0].Rows)
					{
						hoten.Text=r1["hoten"].ToString();
						namsinh.Text=r1["namsinh"].ToString();
						diachi.Text=r1["diachi"].ToString();
						sothe.Text=r1["sothe"].ToString();
						maphu.SelectedValue=r1["maphu"].ToString();
						mabv.Text=r1["mabv"].ToString();
						r=d.getrowbyid(dtdstt,"mabv='"+mabv.Text+"'");
						if (r!=null) tenbv.Text=r["tenbv"].ToString();
						break;
					}
				}
                if (hoten.Text == "")
                {
                    sql = "select hoten,namsinh,sonha,thon,cholam from " + user + ".btdbn  where mabn='" + sophieu.Text + "'";
                    foreach (DataRow r1 in d.get_data(sql).Tables[0].Rows)
                    {                        
                        hoten.Text = r1["hoten"].ToString();
                        namsinh.Text = r1["namsinh"].ToString();
                        diachi.Text = r1["sonha"].ToString().Trim() + " " + r1["thon"].ToString().Trim();
                        break;
                    }
                }
                l_mavaovien = l_maql;
			}
			else if (bNew)
			{
                foreach (DataRow r1 in d.get_data("select a.hoten,a.namsinh,a.diachi,b.sothe,b.mabv,b.maphu from " + yyy + ".bhytds a," + yyy + ".bhytkb b where a.mabn=b.mabn and b.sothe is not null and a.mabn='" + sophieu.Text + "' order by b.id desc").Tables[0].Rows)
				{
					hoten.Text=r1["hoten"].ToString();
					namsinh.Text=r1["namsinh"].ToString();
					diachi.Text=r1["diachi"].ToString();
					sothe.Text=r1["sothe"].ToString();
					maphu.SelectedValue=r1["maphu"].ToString();
					mabv.Text=r1["mabv"].ToString();
					r=d.getrowbyid(dtdstt,"mabv='"+mabv.Text+"'");
					if (r!=null) tenbv.Text=r["tenbv"].ToString();
					break;
				}
			}
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
            if (this.ActiveControl == cachdung)
            {
                Filter_cachdung(cachdung.Text);
                listcachdung.BrowseToBtdkp(cachdung, cachdung, butThem);
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
			Filter_dstt(tenbv.Text);
			listDstt.BrowseToDanhmuc(tenbv,mabv,makp);
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
                if (sothe.Enabled)
                {
                    string so = m.sothe(int.Parse(maphu.SelectedValue.ToString()));
                    if (sothe.Text == "" && int.Parse(so.Substring(0, 2)) > 0) load_bhyt();
                    sothe.Enabled = int.Parse(so.Substring(0, 2)) > 0;
                    tenbv.Enabled = so.Substring(3, 1) == "1";
                }
				SendKeys.Send("{Tab}");
			}
		}

		private void load_bhyt()
		{
			string so=m.sothe(int.Parse(maphu.SelectedValue.ToString()));
			if (int.Parse(so.Substring(0,2))>0 && ngaysp.Text!="")
			{
				string s_mabn=sophieu.Text;
				if (so.Substring(2,1)=="1" && bDenngay_sothe)
					sql="select * from "+xxx+".bhyt where mabn='"+s_mabn+"' and to_timestamp(denngay,'dd/mm/yy')>=to_timestamp('"+ngaysp.Text.Substring(0,10)+"','dd/mm/yy') order by maql desc";
				else
					sql="select * from "+xxx+".bhyt where mabn='"+s_mabn+"' order by maql desc";
				foreach(DataRow r in m.get_data(sql).Tables[0].Rows)
				{
					sothe.Text=r["sothe"].ToString();
					mabv.Text=r["mabv"].ToString();
					try
					{
						if (so.Substring(3,1)=="1")
						{
							if (mabv.Text=="") mabv.Text=m.Mabv;
							tenbv.Text=m.get_data("select tenbv from "+user+".dmnoicapbhyt where mabv='"+mabv.Text+"'").Tables[0].Rows[0][0].ToString();
						}
					}
					catch{}
					break;
				}
			}
			else
			{
				sothe.Text="";
				tenbv.Text="";
			}
		}

		private void sothe_Validated(object sender, System.EventArgs e)
		{
			string so=m.sothe(int.Parse(maphu.SelectedValue.ToString()));
            if (m.sothe(int.Parse(maphu.SelectedValue.ToString()),sothe.Text)) return;
			else
			{
                MessageBox.Show(
lan.Change_language_MessageText("Chiều dài số thẻ không hợp lệ :") + sothe.Text.Length.ToString(), d.Msg);
				sothe.Focus();
			}
		}

		private void sothe_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void chandoan_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==chandoan && bChandoan)
			{
				Filt_ICD(chandoan.Text);
				listICD.BrowseToICD10(chandoan,maicd,butThem,maicd.Location.X,maicd.Location.Y+maicd.Height,maicd.Width+chandoan.Width+2,maicd.Height);
			}
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

		private void Filt_ICD(string ten)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listICD.DataSource];
				DataView dv=(DataView)cm.List;
				dv.RowFilter="vviet like '%"+ten.Trim()+"%'";
			}
			catch{}
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
			if(e.KeyCode==Keys.Down || e.KeyCode==Keys.Up) listICD.Focus(); 
			else if (e.KeyCode==Keys.Enter)
			{
				if (listICD.Visible) listICD.Focus();
				else SendKeys.Send("{Tab}");
			}		
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
			Filt_btdkp(tenkp.Text);
			listBTDKP.BrowseToDanhmuc(tenkp,makp,mabs);
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
			listDMBS.BrowseToDanhmuc(tenbs,mabs,maicd);		
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

		public void RefreshChildren(string text)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[cmbSophieu.DataSource];
				DataView dv=(DataView)cm.List;
				dv.RowFilter="hoten like '%"+text.Trim()+"%'"+" or sothe like '%"+text.Trim()+"%' or mabn like '%"+text+"%'";
				if (cmbSophieu.Items.Count>0) l_id=decimal.Parse(cmbSophieu.SelectedValue.ToString());
				else l_id=0;
				load_head();
			}
			catch{l_id=0;load_head();}
		}

		private void load_head()
		{
			try
			{
				r=d.getrowbyid(dtll,"id="+l_id);
				if (r!=null)
				{
                    l_mavaovien = decimal.Parse(r["mavaovien"].ToString());
					l_maql=decimal.Parse(r["maql"].ToString());
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
					label19.Text=r["sotoa"].ToString();
                    //traituyen = int.Parse(r["traituyen"].ToString());
				}
			}
			catch{l_id=0;}
			load_grid();
			tongcong(dtct);
			sum.Text=d_tongcong.ToString(format_sotien);
			ref_text();
		}

		private void butDuyet_Click(object sender, System.EventArgs e)
		{
            if (maphu.SelectedIndex == -1)
            {
                if (maphu.Items.Count > 0) maphu.SelectedIndex = 0;
                else
                {
                    MessageBox.Show(lan.Change_language_MessageText("Đối tượng không hợp lệ !"), d.Msg);
                    return;
                }
            }
			frmDuyetbhyt f=new frmDuyetbhyt(d,dtll,i_nhom,s_makho,s_manguon,s_ngay,i_userid,s_mmyy,false,int.Parse(maphu.SelectedValue.ToString()),i_loaiba,bAdmin,s_userid, i_khudt );
			f.ShowDialog(this);
			if (f.bOk)
			{
				dtll=f.dtll;
				dtll.AcceptChanges();
				cmbSophieu.Refresh();
				if (dtll.Rows.Count>0) l_id=decimal.Parse(cmbSophieu.SelectedValue.ToString());
				else l_id=0;
				load_head();
				load_dm();
			}
		}

		private void timkiem_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==timkiem) RefreshChildren(timkiem.Text);
		}

		private void timkiem_Enter(object sender, System.EventArgs e)
		{
			timkiem.Text="";
		}
		private void Load_ds_toa(decimal d_id)
		{
            sql = "select a.id,a.mabn,a.maql,b.hoten,b.namsinh,to_char(a.ngay,'dd/mm/yyyy') as ngay,b.diachi,a.makp,a.chandoan,a.maicd,a.mabs,a.sothe,a.maphu,a.mabv,a.sobienlai, a.congkham, a.thuoc, a.cls, a.bntra, a.bhyttra, a.sotoa,a.traituyen from " + yyy + ".bhytkb a," + yyy + ".bhytds b where a.mabn=b.mabn and a.nhom=" + i_nhom+" and a.loaiba="+i_loaiba;
            if (i_loaiba != 2)
            {
                if (i_madoituong == 1) sql += " and a.maphu=1";
                else sql += " and a.maphu<>1";
            }
			if (d.bLocbaohiem) sql+=" and to_char(a.ngay,'dd/mm/yyyy')='"+s_ngay+"'";
			sql+=" order by a.id";
			dtll=d.get_data(sql).Tables[0];		
			lbltoa.Text=dtll.Rows.Count.ToString("###,###");
			cmbSophieu.DataSource=dtll;
			if(l_id>0)cmbSophieu.SelectedValue=d_id.ToString();
		}

		private void butrefresh_Click(object sender, System.EventArgs e)
		{
			Cursor=Cursors.WaitCursor;
            //d.upd_kiemtra(s_mmyy,i_nhom);
            //d.upd_tonkho(s_mmyy,i_nhom,0);
			string s_sid=(cmbSophieu.SelectedIndex>=0)?cmbSophieu.SelectedValue.ToString():"0";
			load_sophieu();
			cmbSophieu.Refresh();
			label4.Refresh();
			cmbSophieu.SelectedValue=s_sid;
			Cursor=Cursors.Default;
		}

		private void Print_ToaBHYT()
		{
			int iTuoi=(namsinh.Text!="")?DateTime.Now.Year-int.Parse(namsinh.Text):0;
			tongcong(dtct);
			decimal d_bn=0,d_bhyt=d_tongcong;
			int d_toaso=d.get_sotoa_bhyt(s_mmyy,l_id,ngaysp.Text,i_madoituong);
            string cholam = "";
            foreach (DataRow r1 in d.get_data("select cholam from " + user + ".btdbn where mabn='" + sophieu.Text + "'").Tables[0].Rows)
                cholam = r1["cholam"].ToString();
            d.execute_data("update " + yyy + ".bhytkb set sotoa=" + d_toaso + " where id=" + l_id);
			label19.Text=d_toaso.ToString("###,###");
			d.updrec_bhytll(dtll,l_id,d_toaso);
			if (maphu.SelectedIndex!=-1)
			{
				if (dtdt.Rows[maphu.SelectedIndex]["mien"].ToString()=="1")
				{
					d_bn=0;d_bhyt=d_tongcong;
				}
				else
				{
					d_bn=d_tongcong;
					d_bhyt=0;
				}
			}
			if (d.bPreview)
			{
				frmReport f=new frmReport(d,dtct,i_userid ,"d_bhyt.rpt",hoten.Text,(iTuoi==0)?"":iTuoi.ToString(),diachi.Text.Trim()+"^"+cholam.Trim(),sothe.Text,chandoan.Text,dtct.Rows.Count.ToString(),d_tongcong.ToString(),d_bn.ToString(),d_bhyt.ToString(),tenbs.Text,d_toaso.ToString(),"");
				f.ShowDialog();
			}
			else
			{
				ReportDocument oRpt=new ReportDocument();
				oRpt.Load("..\\..\\..\\report\\d_bhyt.rpt",OpenReportMethod.OpenReportByTempCopy);
				oRpt.SetDataSource(dtct);
				oRpt.DataDefinition.FormulaFields["soyte"].Text="'"+d.Syte+"'";
				oRpt.DataDefinition.FormulaFields["benhvien"].Text="'"+d.Tenbv+"'";
				oRpt.DataDefinition.FormulaFields["c1"].Text="'"+hoten.Text+"'";
				oRpt.DataDefinition.FormulaFields["c2"].Text=(iTuoi==0)?"'"+iTuoi.ToString()+"'":"";
				oRpt.DataDefinition.FormulaFields["c3"].Text="'"+diachi.Text.Trim()+"^"+cholam.Trim()+"'";
				oRpt.DataDefinition.FormulaFields["c4"].Text="'"+sothe.Text+"'";
				oRpt.DataDefinition.FormulaFields["c5"].Text="'"+chandoan.Text+"'";
				oRpt.DataDefinition.FormulaFields["c6"].Text="'"+dtct.Rows.Count.ToString()+"'";
				oRpt.DataDefinition.FormulaFields["c7"].Text="'"+d_tongcong.ToString()+"'";
				oRpt.DataDefinition.FormulaFields["c8"].Text="'"+d_bn.ToString()+"'";
				oRpt.DataDefinition.FormulaFields["c9"].Text="'"+d_bhyt.ToString()+"'";
				oRpt.DataDefinition.FormulaFields["c10"].Text="'"+tenbs.Text+"'";
				oRpt.DataDefinition.FormulaFields["giamdoc"].Text="'"+d_toaso.ToString()+"'";
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
		//binh: In toa BHYT day du
		private void Print_ToaBHYT_Full()
		{
			if (dtct.Rows.Count==0) return;
			int iTuoi=(namsinh.Text!="")?DateTime.Now.Year-int.Parse(namsinh.Text):0;
			DataSet dstmp=load_grid_Toa_full();
			tongcong(dstmp.Tables[0]);
            DataColumn dc = new DataColumn("Image", typeof(byte[]));
            dstmp.Tables[0].Columns.Add(dc);
			//			
            string cholam = "";
            foreach (DataRow r1 in d.get_data("select cholam from " + user + ".btdbn where mabn='" + sophieu.Text + "'").Tables[0].Rows)
                cholam = r1["cholam"].ToString();
			if (i_madoituong==1 && bCongkham) d_tongcong+=d.Congkham(i_nhom);
			decimal d_bn=0,d_bhyt=d_tongcong;
			if (maphu.SelectedIndex!=-1)
			{
				if (dtdt.Rows[maphu.SelectedIndex]["mien"].ToString()=="1")
				{
					d_bn=0;d_bhyt=d_tongcong;
				}
				else
				{
					d_bn=d_tongcong;
					d_bhyt=0;
				}
			}
			int d_toaso=d.get_sotoa_bhyt(s_mmyy,l_id,ngaysp.Text,i_madoituong);
            d.execute_data("update " + yyy + ".bhytkb set sotoa=" + d_toaso + " where id=" + l_id);
			label19.Text=d_toaso.ToString("###,###");
			d.updrec_bhytll(dtll,l_id,d_toaso);
			string s_tmp=d.Giamdoc(i_nhom);
			decimal congkham=(bCongkham && i_madoituong==1)?d.Congkham(i_nhom):0;
            string sotoa = (bCongkham && !b701540) ? sophieu.Text.Trim() + " (" + s_ngay + ")" : d_toaso.ToString("###,###,###") + " (" + s_ngay + ")";
			d.writeXml("d_thongso","c04",d_toaso.ToString()+" ("+s_ngay+")");//Toa BHYT so
			//
            if (File.Exists("..\\..\\..\\chuky\\" + mabs.Text + ".bmp"))
            {
                fstr = new FileStream("..\\..\\..\\chuky\\" + mabs.Text + ".bmp", FileMode.Open, FileAccess.Read);
                image = new byte[fstr.Length];
                fstr.Read(image, 0, System.Convert.ToInt32(fstr.Length));
                fstr.Close();
                foreach (DataRow r in dstmp.Tables[0].Rows) r["Image"] = image;
            }
			if (d.bPreview)
			{
				frmReport f=new frmReport(d,dstmp.Tables[0], i_userid ,"d_bhyt.rpt",hoten.Text+"   ("+sophieu.Text+")",(iTuoi==0)?"":iTuoi.ToString(),diachi.Text.Trim()+"^"+cholam.Trim(),sothe.Text,maicd.Text+" - "+chandoan.Text+maicd.Tag.ToString(),dtct.Rows.Count.ToString(),d_tongcong.ToString(),d_bn.ToString(),d_bhyt.ToString(),tenbs.Text,sotoa,congkham.ToString());
				f.ShowDialog();	
				d.writeXml("d_thongso","c04",s_tmp);//Toa BHYT so
			}
			else
			{
				ReportDocument oRpt=new ReportDocument();
				oRpt.Load("..\\..\\..\\report\\d_bhyt.rpt",OpenReportMethod.OpenReportByTempCopy);
				oRpt.SetDataSource(dstmp.Tables[0]);//dtct);
				oRpt.DataDefinition.FormulaFields["soyte"].Text="'"+d.Syte+"'";
				oRpt.DataDefinition.FormulaFields["benhvien"].Text="'"+d.Tenbv+"'";
				oRpt.DataDefinition.FormulaFields["c1"].Text="'"+hoten.Text+"   ("+sophieu.Text+")"+"'";
				oRpt.DataDefinition.FormulaFields["c2"].Text=(iTuoi==0)?"":"'"+iTuoi.ToString()+"'";
				oRpt.DataDefinition.FormulaFields["c3"].Text="'"+diachi.Text.Trim()+"^"+cholam.Trim()+"'";
				oRpt.DataDefinition.FormulaFields["c4"].Text="'"+sothe.Text+"'";
				oRpt.DataDefinition.FormulaFields["c5"].Text="'"+maicd.Text+" - "+chandoan.Text+maicd.Tag.ToString()+"'";
				oRpt.DataDefinition.FormulaFields["c6"].Text="'"+dtct.Rows.Count.ToString()+"'";
				oRpt.DataDefinition.FormulaFields["c7"].Text="'"+d_tongcong.ToString()+"'";
				oRpt.DataDefinition.FormulaFields["c8"].Text="'"+d_bn.ToString()+"'";
				oRpt.DataDefinition.FormulaFields["c9"].Text="'"+d_bhyt.ToString()+"'";
				oRpt.DataDefinition.FormulaFields["c10"].Text="'"+tenbs.Text+"'";
				oRpt.DataDefinition.FormulaFields["giamdoc"].Text="'"+sotoa+"'";
				oRpt.DataDefinition.FormulaFields["phutrach"].Text="'"+d.Phutrach(i_nhom)+"'";
				oRpt.DataDefinition.FormulaFields["thongke"].Text="'"+congkham.ToString()+"'";
				oRpt.DataDefinition.FormulaFields["ketoan"].Text="'"+d.Ketoan(i_nhom)+"'";
				oRpt.DataDefinition.FormulaFields["thukho"].Text="'"+d.Thukho(i_nhom)+"'";
				//
				//binh
				oRpt.DataDefinition.FormulaFields["l_soluong"].Text=d.d_soluong_le(i_nhom).ToString();
				oRpt.DataDefinition.FormulaFields["l_dongia"].Text=d.d_soluong_le(i_nhom).ToString();
				oRpt.DataDefinition.FormulaFields["l_thanhtien"].Text=d.d_soluong_le(i_nhom).ToString();
				//
//				oRpt.PrintOptions.PaperSize=PaperSize.PaperA4;
//				oRpt.PrintOptions.PaperOrientation=PaperOrientation.Portrait;
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
		private DataSet load_grid_Toa_full()
		{
			string s_tentt="";
			maicd.Tag="";
            DataSet ds,ds1;
			sql="select a.stt,a.sttt,a.mabd,b.ma,trim(b.ten)||' '||b.hamluong as ten,b.tenhc,b.dang,e.ten as tenkho,c.ten as tennguon,'' as tennhomcc,t.handung,t.losx,a.soluong,";
			if (bGiaban) sql+="t.giaban as dongia,a.soluong*t.giaban as sotien,";
			else sql+="t.giamua as dongia,a.soluong*t.giamua as sotien,";
			sql+="a.soluong*t.giamua as sotienmua,t.giaban,a.cachdung,a.makho,t.manguon,t.nhomcc,case when b.manhom=9 then f.nhomin else 4 end as nhomin,case when b.manhom=9 then f.ten else g.ten end as tennhomin, 1 as loaidv,g.id as manhom ";
            sql += " from " + yyy + ".bhytthuoc a," + user + ".d_dmbd b," + user + ".d_dmnguon c," + user + ".d_dmnx d," + user + ".d_dmkho e, " + user + ".d_dmnhom f, " + user + ".d_nhomin g," + yyy + ".d_theodoi t";
			sql+=" where a.sttt=t.id and a.mabd=b.id and t.manguon=c.id and t.nhomcc=d.id and a.makho=e.id and e.hide=0 and b.manhom=f.id and f.nhomin=g.id ";
            sql += " and a.id=" + l_id;
            sql += " union all ";
			sql +="select a.stt,0 as sttt,a.mavp as mabd,b.ma,b.ten,' ' as tenhc,b.dvt as dang,' ' as tenkho,' ' as tennguon,' ' as tennhomcc,' ' as handung,' ' as losx,a.soluong,a.dongia,a.soluong*a.dongia as sotien,a.soluong*a.dongia as sotienmua,a.dongia as giaban,' ' as cachdung,0 as makho,0 as manguon,0 as nhomcc,4 as nhomin,' ' as tennhomin, 2 as loaidv,0 as manhom ";
            sql += " from " + yyy + ".bhytcls a," + user + ".v_giavp b where a.mavp=b.id and a.id=" + l_id;// +" order by a.stt";
            ds = d.get_data(sql);
			if (bCongkham) foreach(DataRow r in ds.Tables[0].Rows) r["ten"]=d.Caps(r["ten"].ToString());
            foreach (DataRow r in d.get_data("select * from " + yyy + ".d_chandoan where loai=1 and id=" + l_id).Tables[0].Rows)
				maicd.Tag+=";  "+ r["maicd"].ToString()+" - "+r["chandoan"].ToString();
			if (l_maql!=0)
				foreach(DataRow r3 in d.get_data("select b.tenbv from "+xxx+".noigioithieu a,"+user+".dstt b where a.mabv=b.mabv and a.maql="+l_maql).Tables[0].Rows)
					s_tentt=r3["tenbv"].ToString().Trim();
			foreach(DataRow r3 in ds.Tables[0].Rows)
			{
				r3["tennhomcc"]=s_tentt;
				r3["tennguon"]=tenbv.Text;
			}
            ds1 = ds.Copy();
            ds1.Clear();
            ds1.Merge(ds.Tables[0].Select("true", "loaidv,stt"));
			return ds1;
		}
		private bool Check_bienlai(decimal lid)
		{
            sql = " select quyenso, sobienlai from " + yyy + ".bhytkb where id=" + lid + " and quyenso<>0 and sobienlai<>0";
			return d.get_data(sql).Tables[0].Rows.Count>0;
		}

		private void l_kemtheo_Click(object sender, System.EventArgs e)
		{
			if (maicd.Text=="" || chandoan.Text=="")
			{
				maicd.Focus();
				return;
			}
			string s_mabn=sophieu.Text;
			frmCdkemtheo f=new frmCdkemtheo(l_id,1,s_mmyy,dticdkt,maicd.Text);
			f.ShowDialog(this);
			dticdkt=f.dt;
		}

		private void load_kemtheo()
		{	
			dticdkt=d.get_data("select maicd,chandoan from "+xxx+".cdkemtheo where maql="+l_maql).Tables[0];
			l_kemtheo.ForeColor=(dticdkt.Rows.Count>0)?Color.FromArgb(255,0,0):Color.FromArgb(0,0,255);
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

		private void frmBaohiem_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.F11) l_kemtheo_Click(sender,e);
			else if (e.KeyCode==Keys.F6) butDuyet_Click(sender,e);
            else if (e.KeyCode == Keys.F7) butIn_Click(sender, e);
            else if (e.KeyCode == Keys.F9) butTreem_Click(sender, e);
		}

		private void makp_Validated(object sender, System.EventArgs e)
		{
			r=d.getrowbyid(dtkp,"makp='"+makp.Text+"'");
			if (r!=null) tenkp.Text=r["tenkp"].ToString();
			else tenkp.Text="";
		}

		private void mabs_Validated(object sender, System.EventArgs e)
		{
			r=d.getrowbyid(dtbs,"ma='"+mabs.Text+"'");
			if (r!=null) tenbs.Text=r["hoten"].ToString();
			else tenbs.Text="";
		}

		private void butTreem_Click(object sender, System.EventArgs e)
		{
			if (dtct.Rows.Count==0) return;
			DataSet dstmp=load_grid_Toa_full();
			if (dstmp.Tables[0].Rows.Count==0) return;
			dsxml.Clear();
			DataRow r2;
			string ns="",_sothe=sothe.Text,denngay="",phai="",diachi="";
			if (l_maql!=0)
			{
				foreach(DataRow r in m.get_data("select sothe,to_char(denngay,'dd/mm/yyyy')||' '||to_char(tungay,'dd/mm/yyyy') as denngay from "+xxx+".bhyt where maql="+l_maql).Tables[0].Rows)
				{
					if (_sothe=="") _sothe=r["sothe"].ToString();
					denngay=r["denngay"].ToString();
				}
			}
			sql="select a.*,b.sothe,to_char(b.denngay,'dd/mm/yyyy')||' '||to_char(b.tungay,'dd/mm/yyyy') as denngay,c.tenpxa,d.tenquan ";
			sql+="from "+user+".btdbn a left join "+xxx+".bhyt b on a.mabn=b.mabn inner join "+user+".btdpxa c on a.maphuongxa=c.maphuongxa inner join "+user+".btdquan d on a.maqu=d.maqu";
			sql+=" where a.mabn='"+sophieu.Text+"'";
			sql+=" order by b.maql desc";
			foreach(DataRow r in d.get_data(sql).Tables[0].Rows)
			{
				ns=r["namsinh"].ToString();
				phai=(r["phai"].ToString()=="0")?"Nam":"Nữ";
				diachi=r["sonha"].ToString().Trim()+" "+r["thon"].ToString().Trim()+","+r["tenpxa"].ToString().Trim()+","+r["tenquan"].ToString().Trim()+"^"+r["cholam"].ToString().Trim();
				if (_sothe!="")
				{
					_sothe=r["sothe"].ToString();
					denngay=r["denngay"].ToString();
				}
				break;
			}
			foreach(DataRow r in dstmp.Tables[0].Rows)
			{
				if (r["loaidv"].ToString()=="1")
					r2=m.getrowbyid(dtbd,"id="+int.Parse(r["mabd"].ToString()));
				else
					r2=m.getrowbyid(dtvp,"id="+int.Parse(r["mabd"].ToString()));
				if (r2!=null)
				{
					m.updrec_ravien(dsxml,sophieu.Text,sophieu.Text,l_maql,0,hoten.Text,ns,phai,diachi,int.Parse(maphu.SelectedValue.ToString()),
						maphu.Text,_sothe,0,denngay,tenbv.Text,"","","",(tenkp.Text!="")?tenkp.Text:"Khoa khám bệnh",
						ngaysp.Text,ngaysp.Text,chandoan.Text,maicd.Text,int.Parse(r2["sttnhom"].ToString()),
						r2["nhom"].ToString(),int.Parse(r2["sttloai"].ToString()),r2["loai"].ToString(),
						int.Parse(r["mabd"].ToString()),r["ten"].ToString(),r["dang"].ToString(),
						decimal.Parse(r["soluong"].ToString()),decimal.Parse(r["sotien"].ToString()),
                        0, 0, d.Congkham(i_nhom), m.get_nguoinha(d.mmyy(s_ngay), sophieu.Text, l_maql), 1,
                        (makp.Text != "") ? m.phuongphapdieutri(makp.Text) : 0, 0, "", 
                        decimal.Parse(r["dongia"].ToString()), false, 0, "", "", "", "", 
                        int.Parse(maphu.SelectedValue.ToString()), (decimal.Parse(r["soluong"].ToString()) != 0) 
                        ? decimal.Parse(r["sotien"].ToString()) / decimal.Parse(r["soluong"].ToString()) : 0,
                        0, decimal.Parse(r["sotien"].ToString()), traituyen, int.Parse(r2["kythuat"].ToString()),mabs.Text);
				}
			}
            if (File.Exists("..\\..\\..\\chuky\\" + mabs.Text + ".bmp"))
            {
                fstr = new FileStream("..\\..\\..\\chuky\\" + mabs.Text + ".bmp", FileMode.Open, FileAccess.Read);
                image = new byte[fstr.Length];
                fstr.Read(image, 0, System.Convert.ToInt32(fstr.Length));
                fstr.Close();
                foreach(DataRow r in dsxml.Tables[0].Rows) r["Image"] = image;
            }
			string tenfile=d.bIndieutreem(i_nhom)?"rpt_ttravien_te.rpt":"rpt_ttravien_kp.rpt";
			frmReport f=new frmReport(d,dsxml.Tables[0], i_userid ,(tenkp.Text!="")?tenkp.Text:"Khoa khám bệnh",tenfile);
			f.ShowDialog();
		}
	}
}
