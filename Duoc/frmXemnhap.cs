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
	/// Summary description for frmXemnhap.
	/// </summary>
	public class frmXemnhap : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private MaskedBox.MaskedBox ngaysp;
		private MaskedBox.MaskedBox ngayhd;
		private MaskedBox.MaskedBox ngaykiem;
		private System.Windows.Forms.TextBox madv;
		private System.Windows.Forms.TextBox tendv;
		private System.Windows.Forms.ComboBox manguon;
		private System.Windows.Forms.ComboBox makho;
		private LibList.List listNX;
		private LibList.List listDMBD;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label lTen;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.TextBox tenbd;
		private System.Windows.Forms.TextBox mabd;
		private MaskedBox.MaskedBox dang;
		private MaskedTextBox.MaskedTextBox soluong;
		private MaskedTextBox.MaskedTextBox dongia;
		private MaskedTextBox.MaskedTextBox sotien;
		private MaskedTextBox.MaskedTextBox vat;
		private MaskedTextBox.MaskedTextBox sotienvat;
        private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Button butIn;
		private System.Windows.Forms.Button butKetthuc;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.TextBox chuathue;
		private System.Windows.Forms.TextBox cothue;
		private System.Windows.Forms.ComboBox cmbSophieu;
		private string s_mmyy,s_ngay,sql,s_loai,s_vat,s_ngaysp,s_ngayhd,s_ngaykiem,s_makho,format_sotien,format_dongia,format_soluong,format_giaban,s_manhom,s_sophieu,user,xxx,stkgiamgia;
		private int i_nhom,i_userid,i_madv,i_mabd,i_vat,i_nhomcc,i_old,i_songay,manguon_old,makho_old,i_sole_giaban,i_sole_dongia,i_thanhtien_le,itable;
		private decimal l_id;
		private decimal d_soluongcu,d_soluong,d_dongia,d_sotien,d_sotienvat,d_chuathue,d_cothue,d_giaban,d_sl1,d_sl2,d_tyle,d_giaban2,d_tyle2,d_tyle_ggia,d_st_ggia,d_tongtien;
        private bool bKhoaso, bGiaban, bNew, bAdmin, bQuidoi, bGiaban_nguon, bNhom_nx, bKinhphi, bBienban, bNguoigiao, bDinhkhoan, bSophieu, bLockytu, bSophieu_kho, bSophieu_ngay, bChietkhau, bGiaban_noi_ngtru, bGiaban_danhmuc, bGiamgia, bDmtyleban;
		private AccessData d;
		private Doisototext doiso=new Doisototext();
		private DataTable dtdmbd=new DataTable();
		private DataTable dtdmnx=new DataTable();
		private DataTable dtll=new DataTable();
		private DataTable dtct=new DataTable();
		private DataTable dtold=new DataTable();
		private DataTable dtnguon=new DataTable();
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
		private MaskedTextBox.MaskedTextBox bbkiem;
		private MaskedTextBox.MaskedTextBox nguoigiao;
		private MaskedTextBox.MaskedTextBox no;
		private MaskedTextBox.MaskedTextBox co;
		private MaskedTextBox.MaskedTextBox giaban;
		private System.Windows.Forms.Label label25;
		private System.Drawing.Printing.PrintDocument docToPrint = new System.Drawing.Printing.PrintDocument();
		private PrintDialog p=new PrintDialog();
		private DialogResult result;
		private MaskedBox.MaskedBox tenhang;
		private MaskedBox.MaskedBox tennuoc;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.Label ltennuoc;
		private MaskedTextBox.MaskedTextBox sl1;
		private MaskedTextBox.MaskedTextBox sl2;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.Label label28;
		private System.Windows.Forms.Label label29;
		private MaskedTextBox.MaskedTextBox tyle;
		private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TextBox find;
        private System.Windows.Forms.CheckBox chkIn;
		private MaskedTextBox.MaskedTextBox giabancu;
		private System.Windows.Forms.Label label31;
		private System.Windows.Forms.Label lsokhoan;
		private System.Windows.Forms.ComboBox cmbTimkiem;
        private ComboBox chonin;
        private MaskedTextBox.MaskedTextBox giamuacu;
        private Label label32;
        private MaskedTextBox.MaskedTextBox chietkhau;
        private Label label33;
        private Label label34;
        private MaskedTextBox.MaskedTextBox giaban2;
        private Label label35;
        private MaskedTextBox.MaskedTextBox tyle2;
        private Label label36;
        private Label label37;
        private Label lmadoituong;
        private ComboBox madoituong;
        private TextBox losx;
        private MaskedTextBox.MaskedTextBox st_ggia;
        private Label label26;
        private MaskedTextBox.MaskedTextBox tyle_ggia;
        private Label label38;
        private Label label39;
        private MaskedTextBox.MaskedTextBox sotienhang;
        private Label label40;
        private ToolTip toolTip1;
        private Button butFind;
        private IContainer components;

		public frmXemnhap(AccessData acc,string loai,string mmyy,string ngay,int nhom,int userid,string kho,string title,bool ban,bool admin,string _manhom)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			d=acc;
			i_nhom=nhom;s_manhom=_manhom;
			s_makho=kho;i_userid=userid;
			s_mmyy=mmyy;s_ngay=ngay;
			s_loai=loai;bGiaban=ban;
			bAdmin=admin;this.Text=title;
            
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmXemnhap));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.ngaysp = new MaskedBox.MaskedBox();
            this.ngayhd = new MaskedBox.MaskedBox();
            this.ngaykiem = new MaskedBox.MaskedBox();
            this.madv = new System.Windows.Forms.TextBox();
            this.tendv = new System.Windows.Forms.TextBox();
            this.manguon = new System.Windows.Forms.ComboBox();
            this.makho = new System.Windows.Forms.ComboBox();
            this.listNX = new LibList.List();
            this.listDMBD = new LibList.List();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.label13 = new System.Windows.Forms.Label();
            this.lTen = new System.Windows.Forms.Label();
            this.ldvt = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.tenbd = new System.Windows.Forms.TextBox();
            this.mabd = new System.Windows.Forms.TextBox();
            this.dang = new MaskedBox.MaskedBox();
            this.soluong = new MaskedTextBox.MaskedTextBox();
            this.dongia = new MaskedTextBox.MaskedTextBox();
            this.sotien = new MaskedTextBox.MaskedTextBox();
            this.vat = new MaskedTextBox.MaskedTextBox();
            this.sotienvat = new MaskedTextBox.MaskedTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.butIn = new System.Windows.Forms.Button();
            this.butKetthuc = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.chuathue = new System.Windows.Forms.TextBox();
            this.cothue = new System.Windows.Forms.TextBox();
            this.cmbSophieu = new System.Windows.Forms.ComboBox();
            this.stt = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.handung = new MaskedBox.MaskedBox();
            this.tenhc = new System.Windows.Forms.TextBox();
            this.lTenhc = new System.Windows.Forms.Label();
            this.sophieu = new MaskedTextBox.MaskedTextBox();
            this.sohd = new MaskedTextBox.MaskedTextBox();
            this.bbkiem = new MaskedTextBox.MaskedTextBox();
            this.nguoigiao = new MaskedTextBox.MaskedTextBox();
            this.no = new MaskedTextBox.MaskedTextBox();
            this.co = new MaskedTextBox.MaskedTextBox();
            this.giaban = new MaskedTextBox.MaskedTextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.tenhang = new MaskedBox.MaskedBox();
            this.tennuoc = new MaskedBox.MaskedBox();
            this.label23 = new System.Windows.Forms.Label();
            this.ltennuoc = new System.Windows.Forms.Label();
            this.sl1 = new MaskedTextBox.MaskedTextBox();
            this.sl2 = new MaskedTextBox.MaskedTextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.tyle = new MaskedTextBox.MaskedTextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.find = new System.Windows.Forms.TextBox();
            this.chkIn = new System.Windows.Forms.CheckBox();
            this.giabancu = new MaskedTextBox.MaskedTextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.lsokhoan = new System.Windows.Forms.Label();
            this.cmbTimkiem = new System.Windows.Forms.ComboBox();
            this.chonin = new System.Windows.Forms.ComboBox();
            this.giamuacu = new MaskedTextBox.MaskedTextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.chietkhau = new MaskedTextBox.MaskedTextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.giaban2 = new MaskedTextBox.MaskedTextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.tyle2 = new MaskedTextBox.MaskedTextBox();
            this.label36 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.lmadoituong = new System.Windows.Forms.Label();
            this.madoituong = new System.Windows.Forms.ComboBox();
            this.losx = new System.Windows.Forms.TextBox();
            this.st_ggia = new MaskedTextBox.MaskedTextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.tyle_ggia = new MaskedTextBox.MaskedTextBox();
            this.label38 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.sotienhang = new MaskedTextBox.MaskedTextBox();
            this.label40 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.butFind = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 23);
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
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Location = new System.Drawing.Point(429, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 23);
            this.label4.TabIndex = 40;
            this.label4.Text = "Ngày :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(-14, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 23);
            this.label5.TabIndex = 43;
            this.label5.Text = "Nhà cung cấp :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.Location = new System.Drawing.Point(529, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 23);
            this.label6.TabIndex = 41;
            this.label6.Text = "BB kiểm số :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.Location = new System.Drawing.Point(678, 6);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 23);
            this.label7.TabIndex = 42;
            this.label7.Text = "Ngày :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.Location = new System.Drawing.Point(537, 28);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 23);
            this.label8.TabIndex = 44;
            this.label8.Text = "Người giao :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(29, 52);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 23);
            this.label9.TabIndex = 45;
            this.label9.Text = "Nguồn :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(152, 52);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 23);
            this.label10.TabIndex = 46;
            this.label10.Text = "Kho :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(320, 52);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(32, 23);
            this.label11.TabIndex = 47;
            this.label11.Text = "Nợ :";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(532, 52);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(32, 23);
            this.label12.TabIndex = 48;
            this.label12.Text = "Có :";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.ngayhd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            // ngaykiem
            // 
            this.ngaykiem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ngaykiem.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngaykiem.Enabled = false;
            this.ngaykiem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngaykiem.Location = new System.Drawing.Point(723, 6);
            this.ngaykiem.Mask = "##/##/####";
            this.ngaykiem.Name = "ngaykiem";
            this.ngaykiem.Size = new System.Drawing.Size(64, 21);
            this.ngaykiem.TabIndex = 6;
            this.ngaykiem.Text = "  /  /    ";
            this.ngaykiem.Validated += new System.EventHandler(this.ngaykiem_Validated);
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
            this.madv.TabIndex = 7;
            this.madv.Validated += new System.EventHandler(this.madv_Validated);
            this.madv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.madv_KeyDown);
            // 
            // tendv
            // 
            this.tendv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tendv.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tendv.Enabled = false;
            this.tendv.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tendv.Location = new System.Drawing.Point(138, 29);
            this.tendv.Name = "tendv";
            this.tendv.Size = new System.Drawing.Size(302, 21);
            this.tendv.TabIndex = 8;
            this.tendv.Validated += new System.EventHandler(this.tendv_Validated);
            this.tendv.TextChanged += new System.EventHandler(this.tendv_TextChanged);
            this.tendv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tendv_KeyDown);
            // 
            // manguon
            // 
            this.manguon.BackColor = System.Drawing.SystemColors.HighlightText;
            this.manguon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.manguon.Enabled = false;
            this.manguon.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manguon.Location = new System.Drawing.Point(72, 52);
            this.manguon.Name = "manguon";
            this.manguon.Size = new System.Drawing.Size(96, 21);
            this.manguon.TabIndex = 11;
            this.manguon.SelectedIndexChanged += new System.EventHandler(this.manguon_SelectedIndexChanged);
            this.manguon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.manguon_KeyDown);
            // 
            // makho
            // 
            this.makho.BackColor = System.Drawing.SystemColors.HighlightText;
            this.makho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.makho.Enabled = false;
            this.makho.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makho.Location = new System.Drawing.Point(200, 52);
            this.makho.Name = "makho";
            this.makho.Size = new System.Drawing.Size(128, 21);
            this.makho.TabIndex = 12;
            this.makho.KeyDown += new System.Windows.Forms.KeyEventHandler(this.makho_KeyDown);
            // 
            // listNX
            // 
            this.listNX.BackColor = System.Drawing.SystemColors.Info;
            this.listNX.ColumnCount = 0;
            this.listNX.Location = new System.Drawing.Point(504, 565);
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
            this.listDMBD.Location = new System.Drawing.Point(584, 565);
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
            this.dataGrid1.Location = new System.Drawing.Point(8, 57);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(776, 346);
            this.dataGrid1.TabIndex = 100;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label13.Location = new System.Drawing.Point(19, 432);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(46, 23);
            this.label13.TabIndex = 28;
            this.label13.Text = "Mã :";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lTen
            // 
            this.lTen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lTen.Location = new System.Drawing.Point(99, 432);
            this.lTen.Name = "lTen";
            this.lTen.Size = new System.Drawing.Size(53, 23);
            this.lTen.TabIndex = 29;
            this.lTen.Text = "Tên :";
            this.lTen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ldvt
            // 
            this.ldvt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ldvt.Location = new System.Drawing.Point(671, 431);
            this.ldvt.Name = "ldvt";
            this.ldvt.Size = new System.Drawing.Size(41, 23);
            this.ldvt.TabIndex = 30;
            this.ldvt.Text = "ĐVT :";
            this.ldvt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label16.Location = new System.Drawing.Point(9, 454);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(56, 23);
            this.label16.TabIndex = 31;
            this.label16.Text = "Số lượng :";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label17.Location = new System.Drawing.Point(203, 454);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(56, 23);
            this.label17.TabIndex = 32;
            this.label17.Text = "Giá gốc :";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label18.Location = new System.Drawing.Point(422, 454);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(56, 23);
            this.label18.TabIndex = 33;
            this.label18.Text = "Số tiền :";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label19
            // 
            this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label19.Location = new System.Drawing.Point(25, 476);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(40, 23);
            this.label19.TabIndex = 34;
            this.label19.Text = "Thuế :";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label20.Location = new System.Drawing.Point(99, 476);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(53, 23);
            this.label20.TabIndex = 35;
            this.label20.Text = "Tiền :";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tenbd
            // 
            this.tenbd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tenbd.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbd.Enabled = false;
            this.tenbd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbd.Location = new System.Drawing.Point(152, 432);
            this.tenbd.Name = "tenbd";
            this.tenbd.Size = new System.Drawing.Size(267, 21);
            this.tenbd.TabIndex = 16;
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
            this.mabd.Location = new System.Drawing.Point(64, 432);
            this.mabd.Name = "mabd";
            this.mabd.Size = new System.Drawing.Size(59, 21);
            this.mabd.TabIndex = 15;
            this.mabd.Validated += new System.EventHandler(this.mabd_Validated);
            this.mabd.TextChanged += new System.EventHandler(this.mabd_TextChanged);
            this.mabd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbd_KeyDown);
            // 
            // dang
            // 
            this.dang.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dang.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dang.Enabled = false;
            this.dang.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dang.Location = new System.Drawing.Point(710, 432);
            this.dang.Mask = "";
            this.dang.MaxLength = 10;
            this.dang.Name = "dang";
            this.dang.Size = new System.Drawing.Size(74, 21);
            this.dang.TabIndex = 16;
            // 
            // soluong
            // 
            this.soluong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.soluong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.soluong.Enabled = false;
            this.soluong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.soluong.Location = new System.Drawing.Point(152, 455);
            this.soluong.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
            this.soluong.Name = "soluong";
            this.soluong.Size = new System.Drawing.Size(57, 21);
            this.soluong.TabIndex = 19;
            this.soluong.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.soluong.Validated += new System.EventHandler(this.soluong_Validated);
            // 
            // dongia
            // 
            this.dongia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dongia.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dongia.Enabled = false;
            this.dongia.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dongia.Location = new System.Drawing.Point(256, 455);
            this.dongia.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
            this.dongia.Name = "dongia";
            this.dongia.Size = new System.Drawing.Size(76, 21);
            this.dongia.TabIndex = 20;
            this.dongia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.dongia.Validated += new System.EventHandler(this.dongia_Validated);
            // 
            // sotien
            // 
            this.sotien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.sotien.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sotien.Enabled = false;
            this.sotien.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sotien.Location = new System.Drawing.Point(477, 455);
            this.sotien.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
            this.sotien.Name = "sotien";
            this.sotien.Size = new System.Drawing.Size(100, 21);
            this.sotien.TabIndex = 21;
            this.sotien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.sotien.Validated += new System.EventHandler(this.sotien_Validated);
            // 
            // vat
            // 
            this.vat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.vat.BackColor = System.Drawing.SystemColors.HighlightText;
            this.vat.Enabled = false;
            this.vat.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vat.Location = new System.Drawing.Point(64, 477);
            this.vat.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.vat.MaxLength = 3;
            this.vat.Name = "vat";
            this.vat.Size = new System.Drawing.Size(40, 21);
            this.vat.TabIndex = 24;
            this.vat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.vat.Validated += new System.EventHandler(this.vat_Validated);
            // 
            // sotienvat
            // 
            this.sotienvat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.sotienvat.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sotienvat.Enabled = false;
            this.sotienvat.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sotienvat.Location = new System.Drawing.Point(152, 477);
            this.sotienvat.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
            this.sotienvat.Name = "sotienvat";
            this.sotienvat.Size = new System.Drawing.Size(85, 21);
            this.sotienvat.TabIndex = 25;
            this.sotienvat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label14.Location = new System.Drawing.Point(105, 477);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(8, 23);
            this.label14.TabIndex = 45;
            this.label14.Text = "%";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // butIn
            // 
            this.butIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butIn.Image = ((System.Drawing.Image)(resources.GetObject("butIn.Image")));
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(228, 525);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 43;
            this.butIn.Text = "    &In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butKetthuc.Image = ((System.Drawing.Image)(resources.GetObject("butKetthuc.Image")));
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(486, 525);
            this.butKetthuc.Name = "butKetthuc";
            this.butKetthuc.Size = new System.Drawing.Size(70, 25);
            this.butKetthuc.TabIndex = 44;
            this.butKetthuc.Text = "&Kết thúc";
            this.butKetthuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butKetthuc.Click += new System.EventHandler(this.butKetthuc_Click);
            // 
            // label21
            // 
            this.label21.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label21.Location = new System.Drawing.Point(358, 408);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(120, 23);
            this.label21.TabIndex = 55;
            this.label21.Text = "Tổng cộng chưa thuế :";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label22
            // 
            this.label22.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label22.Location = new System.Drawing.Point(553, 406);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(120, 23);
            this.label22.TabIndex = 56;
            this.label22.Text = "Tổng cộng  :";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chuathue
            // 
            this.chuathue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chuathue.BackColor = System.Drawing.SystemColors.HighlightText;
            this.chuathue.Enabled = false;
            this.chuathue.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chuathue.Location = new System.Drawing.Point(477, 408);
            this.chuathue.Name = "chuathue";
            this.chuathue.Size = new System.Drawing.Size(124, 21);
            this.chuathue.TabIndex = 57;
            this.chuathue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cothue
            // 
            this.cothue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cothue.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cothue.Enabled = false;
            this.cothue.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cothue.Location = new System.Drawing.Point(672, 408);
            this.cothue.Name = "cothue";
            this.cothue.Size = new System.Drawing.Size(112, 21);
            this.cothue.TabIndex = 58;
            this.cothue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cmbSophieu
            // 
            this.cmbSophieu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSophieu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSophieu.Location = new System.Drawing.Point(72, 6);
            this.cmbSophieu.Name = "cmbSophieu";
            this.cmbSophieu.Size = new System.Drawing.Size(80, 21);
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
            this.label15.Location = new System.Drawing.Point(238, 499);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(61, 23);
            this.label15.TabIndex = 61;
            this.label15.Text = "Hạn dùng :";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label24
            // 
            this.label24.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label24.Location = new System.Drawing.Point(295, 502);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(64, 19);
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
            this.handung.Location = new System.Drawing.Point(295, 500);
            this.handung.Mask = "####";
            this.handung.Name = "handung";
            this.handung.Size = new System.Drawing.Size(40, 21);
            this.handung.TabIndex = 32;
            this.handung.Text = "    ";
            // 
            // tenhc
            // 
            this.tenhc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tenhc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenhc.Enabled = false;
            this.tenhc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenhc.Location = new System.Drawing.Point(477, 432);
            this.tenhc.Name = "tenhc";
            this.tenhc.Size = new System.Drawing.Size(197, 21);
            this.tenhc.TabIndex = 63;
            // 
            // lTenhc
            // 
            this.lTenhc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lTenhc.Location = new System.Drawing.Point(417, 431);
            this.lTenhc.Name = "lTenhc";
            this.lTenhc.Size = new System.Drawing.Size(63, 23);
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
            this.sophieu.Size = new System.Drawing.Size(80, 21);
            this.sophieu.TabIndex = 1;
            this.sophieu.Validated += new System.EventHandler(this.sophieu_Validated);
            // 
            // sohd
            // 
            this.sohd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sohd.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sohd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.sohd.Enabled = false;
            this.sohd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sohd.Location = new System.Drawing.Point(295, 6);
            this.sohd.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.sohd.Name = "sohd";
            this.sohd.Size = new System.Drawing.Size(145, 21);
            this.sohd.TabIndex = 3;
            this.sohd.Validated += new System.EventHandler(this.sohd_Validated);
            // 
            // bbkiem
            // 
            this.bbkiem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bbkiem.BackColor = System.Drawing.SystemColors.HighlightText;
            this.bbkiem.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.bbkiem.Enabled = false;
            this.bbkiem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bbkiem.Location = new System.Drawing.Point(597, 6);
            this.bbkiem.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.bbkiem.MaxLength = 15;
            this.bbkiem.Name = "bbkiem";
            this.bbkiem.Size = new System.Drawing.Size(86, 21);
            this.bbkiem.TabIndex = 5;
            // 
            // nguoigiao
            // 
            this.nguoigiao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nguoigiao.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nguoigiao.Enabled = false;
            this.nguoigiao.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nguoigiao.Location = new System.Drawing.Point(597, 29);
            this.nguoigiao.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.nguoigiao.Name = "nguoigiao";
            this.nguoigiao.Size = new System.Drawing.Size(163, 21);
            this.nguoigiao.TabIndex = 10;
            this.nguoigiao.Validated += new System.EventHandler(this.nguoigiao_Validated);
            // 
            // no
            // 
            this.no.BackColor = System.Drawing.SystemColors.HighlightText;
            this.no.Enabled = false;
            this.no.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.no.Location = new System.Drawing.Point(352, 52);
            this.no.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.no.Name = "no";
            this.no.Size = new System.Drawing.Size(184, 21);
            this.no.TabIndex = 13;
            // 
            // co
            // 
            this.co.BackColor = System.Drawing.SystemColors.HighlightText;
            this.co.Enabled = false;
            this.co.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.co.Location = new System.Drawing.Point(565, 52);
            this.co.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.co.MaxLength = 10;
            this.co.Name = "co";
            this.co.Size = new System.Drawing.Size(58, 21);
            this.co.TabIndex = 14;
            // 
            // giaban
            // 
            this.giaban.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.giaban.BackColor = System.Drawing.SystemColors.HighlightText;
            this.giaban.Enabled = false;
            this.giaban.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.giaban.Location = new System.Drawing.Point(577, 477);
            this.giaban.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
            this.giaban.Name = "giaban";
            this.giaban.Size = new System.Drawing.Size(82, 21);
            this.giaban.TabIndex = 28;
            this.giaban.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.giaban.Validated += new System.EventHandler(this.giaban_Validated);
            // 
            // label25
            // 
            this.label25.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label25.Location = new System.Drawing.Point(521, 478);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(56, 23);
            this.label25.TabIndex = 66;
            this.label25.Text = "Giá bán :";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tenhang
            // 
            this.tenhang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tenhang.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenhang.Enabled = false;
            this.tenhang.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenhang.Location = new System.Drawing.Point(477, 500);
            this.tenhang.Mask = "";
            this.tenhang.Name = "tenhang";
            this.tenhang.Size = new System.Drawing.Size(140, 21);
            this.tenhang.TabIndex = 34;
            // 
            // tennuoc
            // 
            this.tennuoc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tennuoc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tennuoc.Enabled = false;
            this.tennuoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tennuoc.Location = new System.Drawing.Point(672, 501);
            this.tennuoc.Mask = "";
            this.tennuoc.Name = "tennuoc";
            this.tennuoc.Size = new System.Drawing.Size(112, 21);
            this.tennuoc.TabIndex = 68;
            // 
            // label23
            // 
            this.label23.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label23.Location = new System.Drawing.Point(437, 499);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(40, 23);
            this.label23.TabIndex = 69;
            this.label23.Text = "Hãng :";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ltennuoc
            // 
            this.ltennuoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ltennuoc.Location = new System.Drawing.Point(623, 500);
            this.ltennuoc.Name = "ltennuoc";
            this.ltennuoc.Size = new System.Drawing.Size(48, 23);
            this.ltennuoc.TabIndex = 70;
            this.ltennuoc.Text = "Nước :";
            this.ltennuoc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sl1
            // 
            this.sl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.sl1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sl1.Enabled = false;
            this.sl1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sl1.Location = new System.Drawing.Point(64, 455);
            this.sl1.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
            this.sl1.Name = "sl1";
            this.sl1.Size = new System.Drawing.Size(40, 21);
            this.sl1.TabIndex = 17;
            this.sl1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.sl1.Validated += new System.EventHandler(this.sl1_Validated);
            // 
            // sl2
            // 
            this.sl2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.sl2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sl2.Enabled = false;
            this.sl2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sl2.Location = new System.Drawing.Point(112, 455);
            this.sl2.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.sl2.Name = "sl2";
            this.sl2.Size = new System.Drawing.Size(29, 21);
            this.sl2.TabIndex = 18;
            this.sl2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.sl2.Validated += new System.EventHandler(this.sl2_Validated);
            // 
            // label27
            // 
            this.label27.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label27.Location = new System.Drawing.Point(104, 454);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(8, 23);
            this.label27.TabIndex = 73;
            this.label27.Text = "x";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label28
            // 
            this.label28.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label28.Location = new System.Drawing.Point(143, 454);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(8, 23);
            this.label28.TabIndex = 74;
            this.label28.Text = "=";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label29
            // 
            this.label29.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label29.Location = new System.Drawing.Point(439, 478);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(40, 23);
            this.label29.TabIndex = 101;
            this.label29.Text = "Tỷ lệ :";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tyle
            // 
            this.tyle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tyle.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tyle.Enabled = false;
            this.tyle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tyle.Location = new System.Drawing.Point(477, 477);
            this.tyle.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
            this.tyle.Name = "tyle";
            this.tyle.Size = new System.Drawing.Size(36, 21);
            this.tyle.TabIndex = 27;
            this.tyle.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tyle.Validated += new System.EventHandler(this.tyle_Validated);
            // 
            // label30
            // 
            this.label30.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label30.Location = new System.Drawing.Point(516, 478);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(8, 23);
            this.label30.TabIndex = 103;
            this.label30.Text = "%";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // find
            // 
            this.find.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.find.BackColor = System.Drawing.SystemColors.HighlightText;
            this.find.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.find.Location = new System.Drawing.Point(625, 52);
            this.find.Name = "find";
            this.find.Size = new System.Drawing.Size(88, 21);
            this.find.TabIndex = 104;
            this.find.Text = "Tìm kiếm";
            this.find.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.find.Enter += new System.EventHandler(this.find_Enter);
            this.find.TextChanged += new System.EventHandler(this.find_TextChanged);
            // 
            // chkIn
            // 
            this.chkIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkIn.Location = new System.Drawing.Point(226, 411);
            this.chkIn.Name = "chkIn";
            this.chkIn.Size = new System.Drawing.Size(112, 16);
            this.chkIn.TabIndex = 105;
            this.chkIn.Text = "Xem trước khi in";
            // 
            // giabancu
            // 
            this.giabancu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.giabancu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.giabancu.Enabled = false;
            this.giabancu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.giabancu.Location = new System.Drawing.Point(710, 477);
            this.giabancu.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.giabancu.Name = "giabancu";
            this.giabancu.Size = new System.Drawing.Size(74, 21);
            this.giabancu.TabIndex = 29;
            this.giabancu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label31
            // 
            this.label31.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label31.Location = new System.Drawing.Point(680, 478);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(32, 23);
            this.label31.TabIndex = 108;
            this.label31.Text = "Củ :";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lsokhoan
            // 
            this.lsokhoan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lsokhoan.Location = new System.Drawing.Point(8, 404);
            this.lsokhoan.Name = "lsokhoan";
            this.lsokhoan.Size = new System.Drawing.Size(184, 24);
            this.lsokhoan.TabIndex = 109;
            this.lsokhoan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbTimkiem
            // 
            this.cmbTimkiem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTimkiem.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cmbTimkiem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTimkiem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTimkiem.Items.AddRange(new object[] {
            "Số phiếu",
            "Số hóa đơn",
            "Số phiếu/hoá đơn"});
            this.cmbTimkiem.Location = new System.Drawing.Point(715, 52);
            this.cmbTimkiem.Name = "cmbTimkiem";
            this.cmbTimkiem.Size = new System.Drawing.Size(72, 21);
            this.cmbTimkiem.TabIndex = 103;
            this.cmbTimkiem.SelectedIndexChanged += new System.EventHandler(this.cmbTimkiem_SelectedIndexChanged);
            // 
            // chonin
            // 
            this.chonin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chonin.BackColor = System.Drawing.SystemColors.Info;
            this.chonin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.chonin.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chonin.FormattingEnabled = true;
            this.chonin.Items.AddRange(new object[] {
            "Phiếu nhập",
            "Biên bản giao nhận",
            "Biên bản bàn giao",
            "Kiểm nhập",
            "Phiếu đề nghị thanh toán",
            "Phiếu nhập (Liên 1)",
            "Phiếu nhập (Liên 2)"});
            this.chonin.Location = new System.Drawing.Point(300, 526);
            this.chonin.Name = "chonin";
            this.chonin.Size = new System.Drawing.Size(183, 24);
            this.chonin.TabIndex = 110;
            // 
            // giamuacu
            // 
            this.giamuacu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.giamuacu.BackColor = System.Drawing.SystemColors.HighlightText;
            this.giamuacu.Enabled = false;
            this.giamuacu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.giamuacu.Location = new System.Drawing.Point(355, 455);
            this.giamuacu.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.giamuacu.Name = "giamuacu";
            this.giamuacu.Size = new System.Drawing.Size(79, 21);
            this.giamuacu.TabIndex = 111;
            this.giamuacu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label32
            // 
            this.label32.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label32.Location = new System.Drawing.Point(324, 454);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(32, 23);
            this.label32.TabIndex = 112;
            this.label32.Text = "Củ :";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chietkhau
            // 
            this.chietkhau.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chietkhau.BackColor = System.Drawing.SystemColors.HighlightText;
            this.chietkhau.Enabled = false;
            this.chietkhau.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chietkhau.Location = new System.Drawing.Point(500, 29);
            this.chietkhau.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.chietkhau.MaxLength = 3;
            this.chietkhau.Name = "chietkhau";
            this.chietkhau.Size = new System.Drawing.Size(26, 21);
            this.chietkhau.TabIndex = 9;
            this.chietkhau.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label33
            // 
            this.label33.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label33.Location = new System.Drawing.Point(437, 30);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(66, 19);
            this.label33.TabIndex = 114;
            this.label33.Text = "Chiết khấu :";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label34
            // 
            this.label34.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label34.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label34.Location = new System.Drawing.Point(527, 29);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(8, 23);
            this.label34.TabIndex = 115;
            this.label34.Text = "%";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // giaban2
            // 
            this.giaban2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.giaban2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.giaban2.Enabled = false;
            this.giaban2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.giaban2.Location = new System.Drawing.Point(152, 500);
            this.giaban2.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
            this.giaban2.Name = "giaban2";
            this.giaban2.Size = new System.Drawing.Size(85, 21);
            this.giaban2.TabIndex = 31;
            this.giaban2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.giaban2.Validated += new System.EventHandler(this.giaban2_Validated);
            // 
            // label35
            // 
            this.label35.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label35.Location = new System.Drawing.Point(105, 501);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(8, 23);
            this.label35.TabIndex = 120;
            this.label35.Text = "%";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tyle2
            // 
            this.tyle2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tyle2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tyle2.Enabled = false;
            this.tyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tyle2.Location = new System.Drawing.Point(64, 500);
            this.tyle2.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
            this.tyle2.Name = "tyle2";
            this.tyle2.Size = new System.Drawing.Size(40, 21);
            this.tyle2.TabIndex = 30;
            this.tyle2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tyle2.Validated += new System.EventHandler(this.tyle2_Validated);
            // 
            // label36
            // 
            this.label36.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label36.Location = new System.Drawing.Point(-15, 499);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(80, 23);
            this.label36.TabIndex = 119;
            this.label36.Text = "Tỷ lệ ng trú :";
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label37
            // 
            this.label37.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label37.Location = new System.Drawing.Point(121, 499);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(31, 23);
            this.label37.TabIndex = 118;
            this.label37.Text = "Giá :";
            this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lmadoituong
            // 
            this.lmadoituong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lmadoituong.Location = new System.Drawing.Point(609, 500);
            this.lmadoituong.Name = "lmadoituong";
            this.lmadoituong.Size = new System.Drawing.Size(65, 23);
            this.lmadoituong.TabIndex = 121;
            this.lmadoituong.Text = "Đối tượng :";
            this.lmadoituong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lmadoituong.Visible = false;
            // 
            // madoituong
            // 
            this.madoituong.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.madoituong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.madoituong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.madoituong.Enabled = false;
            this.madoituong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madoituong.Location = new System.Drawing.Point(672, 501);
            this.madoituong.Name = "madoituong";
            this.madoituong.Size = new System.Drawing.Size(112, 21);
            this.madoituong.TabIndex = 35;
            this.madoituong.Visible = false;
            this.madoituong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.madoituong_KeyDown);
            // 
            // losx
            // 
            this.losx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.losx.BackColor = System.Drawing.SystemColors.HighlightText;
            this.losx.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.losx.Enabled = false;
            this.losx.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.losx.Location = new System.Drawing.Point(355, 500);
            this.losx.Name = "losx";
            this.losx.Size = new System.Drawing.Size(79, 21);
            this.losx.TabIndex = 33;
            this.losx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.losx_KeyDown);
            // 
            // st_ggia
            // 
            this.st_ggia.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.st_ggia.BackColor = System.Drawing.SystemColors.HighlightText;
            this.st_ggia.Enabled = false;
            this.st_ggia.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.st_ggia.Location = new System.Drawing.Point(710, 455);
            this.st_ggia.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
            this.st_ggia.Name = "st_ggia";
            this.st_ggia.Size = new System.Drawing.Size(74, 21);
            this.st_ggia.TabIndex = 23;
            this.st_ggia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.st_ggia.Validated += new System.EventHandler(this.st_ggia_Validated);
            // 
            // label26
            // 
            this.label26.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label26.Location = new System.Drawing.Point(660, 453);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(8, 23);
            this.label26.TabIndex = 126;
            this.label26.Text = "%";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tyle_ggia
            // 
            this.tyle_ggia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tyle_ggia.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tyle_ggia.Enabled = false;
            this.tyle_ggia.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tyle_ggia.Location = new System.Drawing.Point(624, 454);
            this.tyle_ggia.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
            this.tyle_ggia.Name = "tyle_ggia";
            this.tyle_ggia.Size = new System.Drawing.Size(35, 21);
            this.tyle_ggia.TabIndex = 22;
            this.tyle_ggia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tyle_ggia.Validated += new System.EventHandler(this.tyle_ggia_Validated);
            // 
            // label38
            // 
            this.label38.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label38.Location = new System.Drawing.Point(533, 453);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(95, 23);
            this.label38.TabIndex = 125;
            this.label38.Text = "Giảm giá :";
            this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label39
            // 
            this.label39.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label39.Location = new System.Drawing.Point(657, 454);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(56, 23);
            this.label39.TabIndex = 124;
            this.label39.Text = "Số tiền :";
            this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sotienhang
            // 
            this.sotienhang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.sotienhang.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sotienhang.Enabled = false;
            this.sotienhang.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sotienhang.Location = new System.Drawing.Point(295, 477);
            this.sotienhang.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
            this.sotienhang.Name = "sotienhang";
            this.sotienhang.Size = new System.Drawing.Size(139, 21);
            this.sotienhang.TabIndex = 26;
            this.sotienhang.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label40
            // 
            this.label40.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label40.Location = new System.Drawing.Point(224, 476);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(73, 23);
            this.label40.TabIndex = 128;
            this.label40.Text = "Tổng tiền :";
            this.label40.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butFind
            // 
            this.butFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butFind.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butFind.Location = new System.Drawing.Point(763, 28);
            this.butFind.Name = "butFind";
            this.butFind.Size = new System.Drawing.Size(24, 23);
            this.butFind.TabIndex = 129;
            this.butFind.Text = "...";
            this.toolTip1.SetToolTip(this.butFind, "Tìm kiếm theo tên thuốc");
            this.butFind.UseVisualStyleBackColor = true;
            this.butFind.Click += new System.EventHandler(this.butFind_Click);
            // 
            // frmXemnhap
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.butFind);
            this.Controls.Add(this.sotienvat);
            this.Controls.Add(this.sotien);
            this.Controls.Add(this.sotienhang);
            this.Controls.Add(this.label40);
            this.Controls.Add(this.st_ggia);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.tyle_ggia);
            this.Controls.Add(this.label38);
            this.Controls.Add(this.label39);
            this.Controls.Add(this.label35);
            this.Controls.Add(this.tenhang);
            this.Controls.Add(this.losx);
            this.Controls.Add(this.madoituong);
            this.Controls.Add(this.lmadoituong);
            this.Controls.Add(this.giabancu);
            this.Controls.Add(this.giaban2);
            this.Controls.Add(this.tyle2);
            this.Controls.Add(this.label36);
            this.Controls.Add(this.label37);
            this.Controls.Add(this.chietkhau);
            this.Controls.Add(this.label34);
            this.Controls.Add(this.tendv);
            this.Controls.Add(this.label33);
            this.Controls.Add(this.giamuacu);
            this.Controls.Add(this.dongia);
            this.Controls.Add(this.tennuoc);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.chonin);
            this.Controls.Add(this.cmbTimkiem);
            this.Controls.Add(this.lsokhoan);
            this.Controls.Add(this.giaban);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.chkIn);
            this.Controls.Add(this.find);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.tyle);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.sl2);
            this.Controls.Add(this.sl1);
            this.Controls.Add(this.ltennuoc);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.co);
            this.Controls.Add(this.no);
            this.Controls.Add(this.nguoigiao);
            this.Controls.Add(this.bbkiem);
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
            this.Controls.Add(this.cothue);
            this.Controls.Add(this.chuathue);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.soluong);
            this.Controls.Add(this.vat);
            this.Controls.Add(this.mabd);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.ldvt);
            this.Controls.Add(this.lTen);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.makho);
            this.Controls.Add(this.manguon);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.listDMBD);
            this.Controls.Add(this.listNX);
            this.Controls.Add(this.madv);
            this.Controls.Add(this.ngaykiem);
            this.Controls.Add(this.ngayhd);
            this.Controls.Add(this.ngaysp);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.stt);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmXemnhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phiếu nhập kho";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmXemnhap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmXemnhap_Load(object sender, System.EventArgs e)
		{
            //if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            user = d.user; xxx = user + s_mmyy;
            if (s_loai == "K")
            {
                label5.Text = "Khoa :";
                lmadoituong.Visible = true;
                madoituong.Visible = true;
                ltennuoc.Visible = false;
                tennuoc.Visible = false;
            }
            bGiamgia = d.bGiamgia(i_nhom);
            bDmtyleban = d.bDmtyleban(i_nhom);
            stkgiamgia = d.Stkgiamgia(i_nhom);
            madoituong.DisplayMember = "DOITUONG";
            madoituong.ValueMember = "MADOITUONG";
            madoituong.DataSource = d.get_data("select * from " + user + ".d_doituong order by madoituong").Tables[0];

            bGiaban_danhmuc = d.bGiaban_danhmuc(i_nhom);
            bGiaban_noi_ngtru = d.bGiaban_noi_ngtru(i_nhom);
			i_thanhtien_le=d.d_thanhtien_le(i_nhom);
			bLockytu=d.bLockytu_traiphai(i_nhom);
			cmbTimkiem.SelectedIndex=0;
            bChietkhau = d.bChietkhau(i_nhom);
			chkIn.Checked=d.bPreview;
			bSophieu=d.bSophieunhap_tudong(i_nhom);
            bSophieu_kho = d.bSophieu_theokho(i_nhom);
            bSophieu_ngay = d.bPhieunhap_ngay(i_nhom);
			bKinhphi=d.bKinhphi(i_nhom);
			format_sotien=d.format_sotien(i_nhom);
			format_dongia=d.format_dongia(i_nhom);
			format_giaban=d.format_giaban(i_nhom);
			format_soluong=d.format_soluong(i_nhom);
			bGiaban_nguon=d.bGiaban_nguon(i_nhom);
			bNhom_nx=d.bNhom_nhapxuat(i_nhom);
			i_sole_giaban=d.d_giaban_le(i_nhom);
			i_sole_dongia=d.d_dongia_le(i_nhom);
			bBienban=d.bBbankiemso;
			bNguoigiao=d.bNguoigiao;
			bDinhkhoan=d.bDinhkhoan;
			bQuidoi=d.bQuidoi(i_nhom);
			bKhoaso=d.bKhoaso(i_nhom,s_mmyy);
			i_songay=d.Ngaylv_Ngayht;
			manguon.DisplayMember="TEN";
			manguon.ValueMember="ID";
			if (d.bQuanlynguon(i_nhom))
				dtnguon=d.get_data("select * from "+user+".d_dmnguon where nhom="+i_nhom+" order by stt").Tables[0];
			else
                dtnguon = d.get_data("select * from " + user + ".d_dmnguon where id=0 or nhom=" + i_nhom + " order by stt").Tables[0];
			manguon.DataSource=dtnguon;
			makho.DisplayMember="TEN";
			makho.ValueMember="ID";
            sql = "select * from " + user + ".d_dmkho where nhom=" + i_nhom;
			if (s_makho!="") sql+=" and id in ("+s_makho.Substring(0,s_makho.Length-1)+")";
            if (s_loai == "M") sql += " and khott=1";
			sql+=" order by stt";
			makho.DataSource=d.get_data(sql).Tables[0];
			if (makho.Items.Count>0) makho.SelectedIndex=0;

			listDMBD.DisplayMember="TEN";
			listDMBD.ValueMember="MA";

			listNX.DisplayMember="MA";
			listNX.ValueMember="TEN";

			load_dm();

            sql = "select id,sophieu,to_char(ngaysp,'dd/mm/yyyy') as ngaysp,sohd,to_char(ngayhd,'dd/mm/yyyy') as ngayhd,bbkiem,to_char(ngaykiem,'dd/mm/yyyy') as ngaykiem,nguoigiao,madv,makho,manguon,nhomcc,no,co,lydo,chietkhau from " + xxx + ".d_nhapll ";
			sql+="where loai='"+s_loai+"'";
            if (s_loai == "T") sql += " and bbkiem<>'BBKKTHUA'";
			if (!bAdmin) sql+=" and userid="+i_userid;
			sql+=" and nhom="+i_nhom;
            if (bSophieu && bSophieu_ngay) sql += " and to_char(ngaysp,'dd/mm/yyyy')='" + s_ngay + "'";
			if (d.bPhieunhap_sophieu(i_nhom)) sql+=" order by sophieu";
			else sql+=" order by manguon,id";
			dtll=d.get_data(sql).Tables[0];
			cmbSophieu.DisplayMember="SOPHIEU";
			cmbSophieu.ValueMember="ID";
			cmbSophieu.DataSource=dtll;
			if (dtll.Rows.Count>0) l_id=decimal.Parse(cmbSophieu.SelectedValue.ToString());
			else l_id=0;
			load_head();
			AddGridTableStyle();
			dsxoa.ReadXml("..\\..\\..\\xml\\d_nhapct.xml");
            chonin.SelectedIndex = 0;
		}

		private void load_grid()
		{
			dataGrid1.DataSource=null;
			sql="select a.stt,a.mabd,b.ma,trim(b.ten)||' '||b.hamluong as ten,nullif(b.tenhc,' ') as tenhc,b.dang,a.handung,a.losx,";
            sql+="a.soluong,a.dongia,a.vat,a.sotien,round(a.soluong*a.giamua,"+i_thanhtien_le+") as tongtien,";
            sql+="a.giaban,a.giamua,c.ten as tenhang,d.ten as tennuoc,a.sl1,a.sl2,a.tyle,a.cuocvc,a.chaythu,a.namsx,";
            sql+="a.tailieu,a.baohanh,a.nguongoc,a.tinhtrang,a.sothe,a.giabancu,a.giamuacu,a.giaban2,a.tyle2,a.tyle_ggia,";
            sql+="a.st_ggia,case when a.vat=0 then 0 else round(a.sotien*a.vat/100,"+i_thanhtien_le+") end as sotienvat " ;
            sql+= " from " + xxx + ".d_nhapct a," + user + ".d_dmbd b," + user + ".d_dmhang c," + user + ".d_dmnuoc d where a.mabd=b.id and b.mahang=c.id and b.manuoc=d.id and a.id=" + l_id + " order by a.stt";
			dtct=d.get_data(sql).Tables[0];
			dataGrid1.DataSource=dtct;
			tongcong();
			lsokhoan.Text="TỔNG SỐ KHOẢN :"+dtct.Rows.Count.ToString();
		}

		private void ref_text()
		{
			try
			{
				int i=dataGrid1.CurrentCell.RowNumber;
				stt.Text=dataGrid1[i,0].ToString();
                DataRow r1 = d.getrowbyid(dtct, "stt=" + int.Parse(stt.Text));
                if (r1 != null)
                {
                    mabd.Text = r1["ma"].ToString();
                    tenbd.Text = r1["ten"].ToString();
                    tenhc.Text = r1["tenhc"].ToString();
                    dang.Text = r1["dang"].ToString();
                    handung.Text = r1["handung"].ToString();
                    losx.Text = r1["losx"].ToString();
                    tenhang.Text = r1["tenhang"].ToString();
                    tennuoc.Text = r1["tennuoc"].ToString();
                    d_soluong = (r1["soluong"].ToString() != "") ? decimal.Parse(r1["soluong"].ToString()) : 0;
                    d_dongia = (r1["dongia"].ToString() != "") ? decimal.Parse(r1["dongia"].ToString()) : 0;
                    d_sotien = (r1["sotien"].ToString() != "") ? decimal.Parse(r1["sotien"].ToString()) : 0;
                    i_vat = (r1["vat"].ToString() != "") ? int.Parse(r1["vat"].ToString()) : 0;
                    d_sotienvat = (r1["sotienvat"].ToString() != "") ? decimal.Parse(r1["sotienvat"].ToString()) : 0;
                    d_giaban = (r1["giaban"].ToString() != "") ? decimal.Parse(r1["giaban"].ToString()) : 0;
                    d_tongtien = (r1["tongtien"].ToString() != "") ? decimal.Parse(r1["tongtien"].ToString()) : 0;
                    d_sl1 = (r1["sl1"].ToString() != "") ? decimal.Parse(r1["sl1"].ToString()) : 0;
                    d_sl2 = (r1["sl2"].ToString() != "") ? decimal.Parse(r1["sl2"].ToString()) : 0;
                    d_tyle = (r1["tyle"].ToString() != "") ? decimal.Parse(r1["tyle"].ToString()) : 0;
                    decimal _sotien = d_sotien + d_sotienvat;
                    if (d_giaban != 0) d_tyle = (d_giaban / (_sotien / d_soluong) - 1) * 100;
                    sl1.Text = d_sl1.ToString(format_soluong);
                    sl2.Text = d_sl2.ToString("###,###,##0");
                    tyle.Text = d_tyle.ToString("##0.00");
                    soluong.Text = d_soluong.ToString(format_soluong);
                    dongia.Text = d_dongia.ToString(format_dongia);
                    sotien.Text = d_sotien.ToString(format_sotien);
                    sotienhang.Text = d_tongtien.ToString(format_sotien);
                    vat.Text = i_vat.ToString("##0");
                    sotienvat.Text = d_sotienvat.ToString(format_sotien);
                    giaban.Text = d_giaban.ToString(format_giaban);
                    d_giaban = (r1["giabancu"].ToString() != "") ? decimal.Parse(r1["giabancu"].ToString()) : 0;
                    giabancu.Text = d_giaban.ToString(format_giaban);
                    d_giaban = (r1["giamuacu"].ToString() != "") ? decimal.Parse(r1["giamuacu"].ToString()) : 0;
                    giamuacu.Text = d_giaban.ToString(format_dongia);
                    d_giaban2 = (r1["giaban2"].ToString() != "") ? decimal.Parse(r1["giaban2"].ToString()) : 0;
                    d_tyle2 = (r1["tyle2"].ToString() != "") ? decimal.Parse(r1["tyle2"].ToString()) : 0;
                    if (d_giaban2 != 0) d_tyle2 = (d_giaban2 / (_sotien / d_soluong) - 1) * 100;
                    tyle2.Text = d_tyle2.ToString("##0.00");
                    giaban2.Text = d_giaban2.ToString(format_giaban);
                    d_tyle_ggia = (r1["tyle_ggia"].ToString() != "") ? decimal.Parse(r1["tyle_ggia"].ToString()) : 0;
                    d_st_ggia = (r1["st_ggia"].ToString() != "") ? decimal.Parse(r1["st_ggia"].ToString()) : 0;
                    tyle_ggia.Text = d_tyle_ggia.ToString("##0.00");
                    st_ggia.Text = d_st_ggia.ToString(format_sotien);
                    d_soluongcu = d_soluong;
                    if (s_loai == "K") madoituong.SelectedValue = r1["tinhtrang"].ToString();
                    /*
                    if (butLuu.Enabled)
                    {
                        r = d.getrowbyid(dtdmbd, "ma='" + mabd.Text + "'");
                        if (r != null)
                        {
                            i_mabd = int.Parse(r["id"].ToString());
                            tenbd.Enabled = d.get_iXuat(s_mmyy, int.Parse(makho.SelectedValue.ToString()), l_id, int.Parse(stt.Text)) == 0;
                            if (d.bNhapmaso) mabd.Enabled = tenbd.Enabled;
                            if (bQuidoi)
                            {
                                sl1.Enabled = tenbd.Enabled;
                                sl2.Enabled = tenbd.Enabled;
                            }
                            else soluong.Enabled = tenbd.Enabled;
                            if (d.bDongia(i_nhom)) dongia.Enabled = tenbd.Enabled;
                            else sotien.Enabled = tenbd.Enabled;
                            if (s_loai != "K") vat.Enabled = tenbd.Enabled;
                        }
                    }*/
                }
			}
            catch { emp_detail(); }
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

            if (bGiamgia)
            {
                TextCol = new DataGridTextBoxColumn();
                TextCol.MappingName = "tyle_ggia";
                TextCol.HeaderText = "Giảm giá";
                TextCol.Width = 50;
                TextCol.Format = "##0.00";
                TextCol.Alignment = HorizontalAlignment.Right;
                ts.GridColumnStyles.Add(TextCol);
                dataGrid1.TableStyles.Add(ts);

                TextCol = new DataGridTextBoxColumn();
                TextCol.MappingName = "st_ggia";
                TextCol.HeaderText = "Tiền giảm";
                TextCol.Width = 100;
                TextCol.Format = format_sotien;
                TextCol.Alignment = HorizontalAlignment.Right;
                ts.GridColumnStyles.Add(TextCol);
                dataGrid1.TableStyles.Add(ts);
            }

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "vat";
			TextCol.HeaderText = "Thuế";
			TextCol.Width = 30;
			TextCol.Format="##0";
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "sotienvat";
			TextCol.HeaderText = "Tiền thuế";
			TextCol.Width = 100;
			TextCol.Format=format_sotien;
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "tongtien";
            TextCol.HeaderText = "Tổng tiền";
            TextCol.Width = 100;
            TextCol.Format = format_sotien;
            TextCol.Alignment = HorizontalAlignment.Right;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "giaban";
			TextCol.HeaderText = (bGiaban && bGiaban_noi_ngtru)?"Giá bán nội trú":(bGiaban)?"Giá bán":"";
			TextCol.Width = (bGiaban)?100:0;
			TextCol.Format="###,###,###,##0";
			TextCol.Alignment=HorizontalAlignment.Right;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "giaban2";
            TextCol.HeaderText = (bGiaban && bGiaban_noi_ngtru) ? "Giá bán ngoại trú" : "";
            TextCol.Width = (bGiaban && bGiaban_noi_ngtru) ? 100 : 0;
            TextCol.Format = "###,###,###,##0";
            TextCol.Alignment = HorizontalAlignment.Right;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "tenhang";
            TextCol.HeaderText = "Hãng";
            TextCol.Width = 150;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "tennuoc";
            TextCol.HeaderText = "Nước";
            TextCol.Width = 150;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);
		}

		private void load_dm()
		{
            sql = "select a.ma,trim(a.ten)||' '||a.hamluong as ten,trim(b.ten)||'/'||c.ten as hang,trim(a.dang)||'/'||trim(a.donvi) as dang,a.tenhc,a.id,a.giaban,a.dongia,b.ten as tenhang,c.ten as tennuoc,a.manhom,nullif(d.ma,' ') as sotk,a.sldonggoi from " + user + ".d_dmbd a inner join " + user + ".d_dmhang b on a.mahang=b.id inner join " + user + ".d_dmnuoc c on a.manuoc=c.id left join " + user + ".d_dmnhomkt d on a.sotk=d.id where a.nhom=" + i_nhom+" and a.hide=0";
			if (s_manhom!="") sql+=" and a.manhom in ("+s_manhom.Substring(0,s_manhom.Length-1)+")";
			sql+=" order by a.ten";
			dtdmbd=d.get_data(sql).Tables[0];
			listDMBD.DataSource=dtdmbd;
            if (s_loai == "K") sql = "select ma,ten,id,0 as nhomcc,' ' as diachi,' ' as masothue,' ' as daidien from "+user+".d_duockp where nhom like '%" + i_nhom.ToString() + ",%' order by stt";
            else sql = "select ma,ten,id,nhomcc,diachi,masothue,daidien from "+user+".d_dmnx where nhom=" + i_nhom + " order by stt";
            dtdmnx = d.get_data(sql).Tables[0];
			listNX.DataSource=dtdmnx;
		}

		private void sophieu_Validated(object sender, System.EventArgs e)
		{
			if (l_id!=0) return;
			try
			{
				r=d.getrowbyid(dtll,"sophieu='"+sophieu.Text+"'");
				if (r!=null)
				{
					MessageBox.Show(lan.Change_language_MessageText("Số phiếu đã nhập !"),d.Msg);
					sophieu.Focus();
				}
			}
			catch{}
            if (s_loai == "K") sohd.Text = sophieu.Text;
		}

		private void cmbSophieu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			//if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab) butMoi.Focus();
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
					bbkiem.Text=r["bbkiem"].ToString();
					ngaykiem.Text=r["ngaykiem"].ToString();
					nguoigiao.Text=r["nguoigiao"].ToString();
					makho.SelectedValue=r["makho"].ToString();
					manguon.SelectedValue=r["manguon"].ToString();
                    chietkhau.Text = r["chietkhau"].ToString();
					DataRow r1=d.getrowbyid(dtdmnx,"id="+int.Parse(r["madv"].ToString()));
					if (r1!=null)
					{
						madv.Text=r1["ma"].ToString();
						tendv.Text=r1["ten"].ToString();
					}
					no.Text=r["no"].ToString();
					co.Text=r["co"].ToString();
					s_ngaysp=ngaysp.Text;
					s_ngayhd=ngayhd.Text;
					s_ngaykiem=ngaykiem.Text;
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
                    sl2.Text = (r["sldonggoi"].ToString()=="0")?"":r["sldonggoi"].ToString();
                    d_giaban = decimal.Parse(r["dongia"].ToString());
                    giamuacu.Text = d_giaban.ToString(format_dongia);
					d_giaban=decimal.Parse(r["giaban"].ToString());
					giabancu.Text=d_giaban.ToString(format_giaban);
					if (bDinhkhoan)
					{
						string sotk=no.Text.Trim();
						if (sotk.IndexOf(r["sotk"].ToString())==-1)
						{
							sotk+=(sotk!="")?",":"";
							sotk+=r["sotk"].ToString().Trim();
							no.Text=sotk;
						}
					}
					if (s_loai=="T" || s_loai=="K")
					{
						d_dongia=decimal.Parse(r["dongia"].ToString());
						dongia.Text=d_dongia.ToString(format_dongia);
						d_giaban=decimal.Parse(r["giaban"].ToString());
						giaban.Text=d_giaban.ToString(format_giaban);
					}
                    else if (!bGiaban_danhmuc) giaban.Text = d_giaban.ToString(format_giaban);
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
                if (chietkhau.Enabled) listNX.BrowseToDmnx(tendv, madv, chietkhau);
				else listNX.BrowseToDmnx(tendv,madv,nguoigiao);
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
            if (bSophieu && bSophieu_ngay) ngaysp.Enabled = false;
            else ngaysp.Enabled = ena;
            if (bChietkhau && s_loai=="M") chietkhau.Enabled = ena;
            if (bGiamgia && s_loai == "M") tyle_ggia.Enabled = ena;
            st_ggia.Enabled = tyle_ggia.Enabled;
			sohd.Enabled=ena;
			ngayhd.Enabled=ena;
            if (s_loai != "K") sohd.Enabled = ena;
            if (s_loai != "K") ngayhd.Enabled = ena;
            if (bBienban && s_loai != "K") bbkiem.Enabled = ena;

			ngaykiem.Enabled=bbkiem.Enabled;
			madv.Enabled=ena;
			tendv.Enabled=ena;
            if (bNguoigiao && s_loai != "K") nguoigiao.Enabled = ena;
			if (d.bQuanlynguon(i_nhom)) manguon.Enabled=ena;
			else manguon.SelectedValue="0";
			makho.Enabled=ena;
            if (bDinhkhoan && s_loai != "K") no.Enabled = ena;
			co.Enabled=no.Enabled;
			if (d.bNhapmaso) mabd.Enabled=ena;
			tenbd.Enabled=ena;
            if (s_loai == "K") madoituong.Enabled = ena;
			if (bQuidoi)
			{
				sl1.Enabled=ena;
				sl2.Enabled=ena;
			}
			else soluong.Enabled=ena;
			if (d.bQuanlyhandung(i_nhom)) handung.Enabled=ena;
			if (d.bQuanlylosx(i_nhom)) losx.Enabled=ena;
			if (d.bDongia(i_nhom)) dongia.Enabled=ena;
			else sotien.Enabled=ena;

            if (!bGiaban_danhmuc && !bDmtyleban)
            {
                if (bGiaban_nguon) giaban.Enabled = ena;
                else if (bGiaban) giaban.Enabled = ena;
                if (bGiaban_nguon && ena && manguon.SelectedIndex != -1)
                    giaban.Enabled = dtnguon.Rows[manguon.SelectedIndex]["loai"].ToString() == "1";
            }

			tyle.Enabled=giaban.Enabled;
            if (giaban.Enabled && bGiaban_noi_ngtru) giaban2.Enabled = giaban.Enabled;
            tyle2.Enabled = giaban2.Enabled;
            if (s_loai != "K") vat.Enabled = ena;
            /*
			butMoi.Enabled=!ena;
			butSua.Enabled=!ena;
			butThem.Enabled=ena;
			butXoa.Enabled=ena;
			butLuu.Enabled=ena;
			butBoqua.Enabled=ena;
			butHuy.Enabled=!ena;
             * */
            butFind.Enabled = !ena;
			butIn.Enabled=!ena;
			butKetthuc.Enabled=!ena;
            chonin.Enabled = !ena;
			i_old=cmbSophieu.SelectedIndex;
			if (d.bDanhmuc || d.bDmbd)
			{
				if (d.bDanhmuc) d.writeXml("d_thongso","c01","0");
				else d.writeXml("d_thongso","c06","0");
				load_dm();
			}
        }

		private void emp_head()
		{
			l_id=0;
            if (bSophieu)
            {
                sql = " where nhom=" + i_nhom + " and loai='" + s_loai + "'";
                if (bSophieu_ngay) sql += " and to_char(ngaysp,'dd/mm/yyyy')='" + s_ngay + "'";
                if (s_loai == "T") sql += " and bbkiem<>'BBKKTHUA'";
                sophieu.Text = d.get_sophieu(s_mmyy, "d_nhapll", "sophieu", sql);
            }
            else sophieu.Text = "";
			ngaysp.Text=s_ngay;
            if (s_loai == "K") sohd.Text = sophieu.Text;
            else sohd.Text = "";
			ngayhd.Text=s_ngay;
			bbkiem.Text="";
			ngaykiem.Text="";
			madv.Text="";
			tendv.Text="";
			nguoigiao.Text="";
			if (makho.Items.Count>0) makho.SelectedIndex=0;
			no.Text="";
			co.Text="";
            chietkhau.Text = "0";
			s_ngaysp=ngaysp.Text;
			s_ngayhd=ngayhd.Text;
			s_ngaykiem=ngaykiem.Text;
			dsxoa.Clear();
			lsokhoan.Text="TỔNG SỐ KHOẢN :"+dtct.Rows.Count.ToString();
		}
		
		private void emp_detail()
		{
			mabd.Text="";tenbd.Text="";tenhc.Text="";dang.Text="";
			soluong.Text="";sl1.Text="";sl2.Text="";dongia.Text="";
			sotien.Text="";vat.Text="";sotienvat.Text="";chuathue.Text="";
			cothue.Text="";handung.Text="";losx.Text="";
			giaban.Text="0";tyle.Text="0";
            giaban2.Text = "0"; tyle2.Text = "0";
            tyle_ggia.Text = "0"; st_ggia.Text = "0";
			tenhang.Text="";tennuoc.Text="";d_soluongcu=0;
			stt.Text=d.get_stt(dtct).ToString();
		}

		private void butMoi_Click(object sender, System.EventArgs e)
		{
			if (bKhoaso)
			{
				MessageBox.Show(lan.Change_language_MessageText("Số liệu tháng")+" "+s_mmyy.Substring(0,2)+" "+lan.Change_language_MessageText("năm")+" "+s_mmyy.Substring(2,2)+" "+lan.Change_language_MessageText("đã khóa !")+"\n"+lan.Change_language_MessageText("Nếu cần thay đổi thì vào mục khai báo hệ thống"),d.Msg);
				return;
			}
			ena_object(true);
			emp_head();
			emp_detail();
            load_dm();
			dtct.Clear();
			dtold.Clear();
			if (sophieu.Text!="")
			{
				emp_head();
				emp_detail();
				dtct.Clear();
			}
			bNew=true;
			manguon_old=0;makho_old=0;
            if (sophieu.Enabled) sophieu.Focus();
            else if (ngaysp.Enabled) ngaysp.Focus();
            else sohd.Focus();
		}

		private void butSua_Click(object sender, System.EventArgs e)
		{
			if (cmbSophieu.Items.Count==0) return;
			if (bKhoaso)
			{
				MessageBox.Show(lan.Change_language_MessageText("Số liệu tháng")+" "+s_mmyy.Substring(0,2)+" "+lan.Change_language_MessageText("năm")+" "+s_mmyy.Substring(2,2)+" "+lan.Change_language_MessageText("đã khóa !")+"\n"+lan.Change_language_MessageText("Nếu cần thay đổi thì vào mục khai báo hệ thống"),d.Msg);
				return;
			}
			l_id=decimal.Parse(cmbSophieu.SelectedValue.ToString());
			if (d.get_paid("d_nhapll",s_mmyy,l_id))
			{
				MessageBox.Show(lan.Change_language_MessageText("Số phiếu đã thanh toán !"),d.Msg);
				return;
			}
			ena_object(true);
			bNew=false;
			s_sophieu=sophieu.Text;
			manguon_old=int.Parse(manguon.SelectedValue.ToString());
			makho_old=int.Parse(makho.SelectedValue.ToString());

            foreach (DataRow r1 in dtct.Rows)
            {
                i_mabd = d.get_iXuat(s_mmyy, makho_old, l_id, int.Parse(r1["stt"].ToString()));
                if (i_mabd != 0)
                {
                    r = d.getrowbyid(dtdmbd, "id=" + i_mabd);
                    if (r != null)
                    {
                        makho.Enabled = false;
                        break;
                    }
                }
            }
			dtold=dtct.Copy();
			dsxoa.Clear();
            if (sophieu.Enabled) sophieu.Focus();
            else if (ngaysp.Enabled) ngaysp.Focus();
            else sohd.Focus();
			ref_text();
		}
		private bool KiemtraHead()
		{
			if (sophieu.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập số phiếu !"),d.Msg);
				sophieu.Focus();
				return false;
			}
			if (ngaysp.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập ngày số phiếu !"),d.Msg);
				ngaysp.Focus();
				return false;
			}
			if (sohd.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập số hóa đơn !"),d.Msg);
				sohd.Focus();
				return false;
			}
			if (ngayhd.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập ngày hóa đơn !"),d.Msg);
				ngayhd.Focus();
				return false;
			}
			if (bBienban && s_loai!="K")
			{
				if ((bbkiem.Text=="" && ngaykiem.Text!="") || (bbkiem.Text!="" && ngaykiem.Text==""))
				{
					if (bbkiem.Text=="")
					{
						MessageBox.Show(lan.Change_language_MessageText("Nhập biên bản kiểm số !"),d.Msg);
						bbkiem.Focus();
						return false;
					}
					else if (ngaykiem.Text=="")
					{
						MessageBox.Show(lan.Change_language_MessageText("Nhập ngày biên bản kiểm !"),d.Msg);
						ngaykiem.Focus();
						return false;
					}
				}
			}
			if (d.bQuanlynguon(i_nhom))
			{
				if (manguon.SelectedIndex==-1 || manguon.SelectedValue.ToString()=="0")
				{
					MessageBox.Show(lan.Change_language_MessageText("Nguồn không hợp lệ !"),d.Msg);
					manguon.Focus();
					return false;
				}
			}
			else manguon.SelectedValue="0";

			if (makho.SelectedIndex==-1)
			{
				MessageBox.Show(lan.Change_language_MessageText("Nhập kho nhập !"),d.Msg);
				makho.Focus();
				return false;
			}
			if (madv.Text=="" && tendv.Text=="")
			{
				MessageBox.Show(lan.Change_language_MessageText("Chọn nhà cung cấp !"),d.Msg);
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
                string s = (s_loai == "K") ? "Khoa " : "Nhà cung cấp";
                MessageBox.Show(s + " không hợp lệ !", d.Msg);
				madv.Focus();
				return false;
			}
			i_madv=int.Parse(r["id"].ToString());
            if (d.bQuanlynhomcc(i_nhom)) i_nhomcc = i_madv;//i_nhomcc=int.Parse(r["nhomcc"].ToString());
            else i_nhomcc=0;
            /*
            if (dtct.Rows.Count==0)
			{
				MessageBox.Show(lan.Change_language_MessageText("Đề nghị nhập chi tiết !"),d.Msg);
				butThem.Focus();
				return false;
			}*/
			if (bDinhkhoan && s_loai!="K")
			{
				if ((no.Text=="" && co.Text!="") || (no.Text!="" && co.Text==""))
				{
					if (no.Text=="")
					{
						no.Focus();
						return false;
					}
					else if (co.Text=="")
					{
						co.Focus();
						return false;
					}
				}
			}
			if (!bNew)
			{
				if (sophieu.Text!=s_sophieu)
				{
					sql="select sophieu from "+xxx+".d_nhapll where loai='"+s_loai+"' and sophieu='"+sophieu.Text+"' and id<>"+l_id;
                    if (s_loai == "T") sql += " and bbkiem<>'BBKKTHUA'";
					if (d.get_data(sql).Tables[0].Rows.Count>0)
					{
						MessageBox.Show(lan.Change_language_MessageText("Số phiếu")+" "+sophieu.Text+" "+lan.Change_language_MessageText("đã nhập !"),d.Msg);
						sophieu.Focus();
						return false;
					}
				}
				if (manguon_old!=int.Parse(manguon.SelectedValue.ToString()) || makho_old!=int.Parse(makho.SelectedValue.ToString()))
				{
					foreach(DataRow r1 in dtct.Rows)
					{
						i_mabd=d.get_iXuat(s_mmyy,makho_old,l_id,int.Parse(r1["stt"].ToString()));
						if (i_mabd!=0)
						{
							r=d.getrowbyid(dtdmbd,"id="+i_mabd);
							if (r!=null)
							{
								MessageBox.Show(r["ten"].ToString().Trim()+" "+r["dang"].ToString().Trim()+"\nĐã xuất không cho phép chỉnh sửa !",d.Msg);
								return false;
							}
						}
					}
                    if (bSophieu)
                    {
                        sql = " where nhom=" + i_nhom + " and loai='" + s_loai + "'";
                        if (bSophieu_kho) sql += " and makho=" + int.Parse(makho.SelectedValue.ToString());
                        if (bSophieu_ngay) sql += " and to_char(ngaysp,'dd/mm/yyyy')='" + s_ngay + "'";
                        if (s_loai == "T") sql += " and bbkiem<>'BBKKTHUA'";
                        sophieu.Text = d.get_sophieu(s_mmyy, "d_nhapll", "sophieu", sql);
                    }
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
					MessageBox.Show(lan.Change_language_MessageText("Nhập mã số !"),d.Msg);
					mabd.Focus();
					return false;
				}
				else if (tenbd.Text=="")
				{
					MessageBox.Show(lan.Change_language_MessageText("Nhập tên !"),d.Msg);
					tenbd.Focus();
					return false;
				}
			}
			r=d.getrowbyid(dtdmbd,"ma='"+mabd.Text+"'");
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
            if (d.bGiaban(i_nhom) && giaban.Enabled && !bGiaban_danhmuc)
            {
                try
                {
                    d_dongia = (dongia.Text != "") ? decimal.Parse(dongia.Text) : 0;
                    d_giaban = (giaban.Text != "") ? decimal.Parse(giaban.Text) : 0;
                    if (d_giaban < d_dongia)
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Giá bán không hợp lệ !"), d.Msg);
                        giaban.Focus();
                        return false;
                    }
                }
                catch { return false; }
            }
			return true;
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
			upd_table(dtct);
			dtct.AcceptChanges();
			if (!KiemtraHead()) return;
			i_old=(bNew)?0:1;
			l_id=(bNew)?d.get_id_nhap:l_id;
            itable = d.tableid(s_mmyy, "d_nhapll");
            if (bNew)
            {
                d.upd_eve_tables(s_mmyy, itable, i_userid, "ins");
                if (bSophieu)
                {
                    sql = " where nhom=" + i_nhom + " and loai='" + s_loai + "'";
                    if (bSophieu_kho) sql += " and makho=" + int.Parse(makho.SelectedValue.ToString());
                    if (bSophieu_ngay) sql += " and to_char(ngaysp,'dd/mm/yyyy')='" + s_ngay + "'";
                    if (s_loai == "T") sql += " and bbkiem<>'BBKKTHUA'";
                    sophieu.Text = d.get_sophieu(s_mmyy, "d_nhapll", "sophieu", sql);
                }
            }
            else
            {
                string s = "";
                DataRow r2;
                foreach (DataRow r1 in dtold.Rows)
                {
                    r2 = d.getrowbyid(dtct, "stt=" + decimal.Parse(r1["stt"].ToString()));
                    if (r2 != null)
                    {
                        if (int.Parse(r1["mabd"].ToString()) != int.Parse(r2["mabd"].ToString()))
                        {
                            i_mabd = d.get_iXuat(s_mmyy, int.Parse(makho.SelectedValue.ToString()), l_id, int.Parse(r1["stt"].ToString()));
                            if (i_mabd != 0)
                            {
                                r = d.getrowbyid(dtdmbd, "id=" + i_mabd);
                                if (r != null)
                                    s += r["ten"].ToString().Trim() + " " + r["dang"].ToString().Trim() + "\n";
                            }
                        }
                    }
                }
                if (s != "")
                {
                    MessageBox.Show(lan.Change_language_MessageText("Những mặt hàng sau đã xuất không cho phép thay đổi")+" \n"+" "+s, d.Msg);
                    return;
                }
                d.upd_eve_tables(s_mmyy, itable, i_userid, "upd");
                d.upd_eve_upd_del(s_mmyy, itable, i_userid, "upd", l_id.ToString() + "^" + i_nhom.ToString() + "^" + sophieu.Text + "^" + ngaysp.Text + "^" + sohd.Text + "^" + ngayhd.Text + "^" + bbkiem.Text + "^" + ngaykiem.Text + "^" + s_loai + "^" + nguoigiao.Text + "^" + i_madv.ToString() + "^" + makho.SelectedValue.ToString() + "^" + manguon.SelectedValue.ToString() + "^" + i_nhomcc.ToString() + "^" + no.Text + "^" + co.Text + "^" + i_userid.ToString() + "^" + "0^"+chietkhau.Text);
            }
			if (!d.upd_nhapll(s_mmyy,l_id,i_nhom,sophieu.Text,ngaysp.Text,sohd.Text,ngayhd.Text,bbkiem.Text,ngaykiem.Text,s_loai,nguoigiao.Text,i_madv,int.Parse(makho.SelectedValue.ToString()),int.Parse(manguon.SelectedValue.ToString()),i_nhomcc,no.Text,co.Text,i_userid,0,(chietkhau.Text!="")?decimal.Parse(chietkhau.Text):0))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin phiếu nhập kho !"),d.Msg);
				return;
			}
            itable = d.tableid(s_mmyy, "d_nhapct");
			if (!bNew)
			{
				if (manguon_old!=int.Parse(manguon.SelectedValue.ToString()) || makho_old!=int.Parse(makho.SelectedValue.ToString()))
				{
					foreach(DataRow r1 in dtold.Rows)
					{
						d.execute_data("delete from "+xxx+".d_nhapct where id="+l_id+" and stt="+int.Parse(r1["stt"].ToString()));
						if (s_loai=="M" && bKinhphi)
						{
							r=d.getrowbyid(dtdmbd,"id="+int.Parse(r1["mabd"].ToString()));
                            if (r != null) d.execute_data("update " + user + ".d_kinhphi set dasudung=dasudung-" + d.Round(decimal.Parse(r1["sotien"].ToString()) + decimal.Parse(r1["sotien"].ToString()) * decimal.Parse(r1["vat"].ToString()) / 100 - decimal.Parse(r1["st_ggia"].ToString()), i_thanhtien_le) + " where nhom=" + i_nhom + " and yy='" + s_mmyy.Substring(2, 2) + "' and id_nhom=" + int.Parse(r["manhom"].ToString()));
						}
                        d.upd_tonkhoct_nhapct(d.delete, s_mmyy, ngayhd.Text, l_id, int.Parse(r1["stt"].ToString()), decimal.Parse(r1["soluong"].ToString()), decimal.Parse(r1["sotien"].ToString()), int.Parse(r1["vat"].ToString()), makho_old, manguon_old, i_nhomcc, int.Parse(r1["mabd"].ToString()), r1["handung"].ToString(), r1["losx"].ToString(), decimal.Parse(r1["giaban"].ToString()), "", 0, 0, s_loai, 0, 0, 0, i_nhom, "", 0, 1, (chietkhau.Text != "") ? decimal.Parse(chietkhau.Text) : 0, decimal.Parse(r1["giaban2"].ToString()), decimal.Parse(r1["giamua"].ToString()), decimal.Parse(r1["sotienvat"].ToString()), decimal.Parse(r1["tyle_ggia"].ToString()), decimal.Parse(r1["st_ggia"].ToString()), decimal.Parse(r1["dongia"].ToString()), bGiaban_danhmuc,"");
					}
					dtold.Clear();
				}
				foreach(DataRow r1 in dsxoa.Tables[0].Rows)
				{
                    d.upd_eve_tables(s_mmyy, itable, i_userid, "del");
                    d.upd_eve_upd_del(s_mmyy, itable, i_userid, "del",d.fields(xxx+".d_nhapct","id="+l_id+" and stt="+int.Parse(r1["stt"].ToString())));
					d.execute_data("delete from "+xxx+".d_nhapct where id="+l_id+" and stt="+int.Parse(r1["stt"].ToString()));
				}
				foreach(DataRow r1 in dtold.Rows)
				{
					if (s_loai=="M" && bKinhphi)
					{
						r=d.getrowbyid(dtdmbd,"id="+int.Parse(r1["mabd"].ToString()));
                        if (r != null) d.execute_data("update " + user + ".d_kinhphi set dasudung=dasudung-" + d.Round(decimal.Parse(r1["sotien"].ToString()) + decimal.Parse(r1["sotien"].ToString()) * decimal.Parse(r1["vat"].ToString()) / 100 - decimal.Parse(r1["st_ggia"].ToString()), i_thanhtien_le) + " where nhom=" + i_nhom + " and yy='" + s_mmyy.Substring(2, 2) + "' and id_nhom=" + int.Parse(r["manhom"].ToString()));
					}
                    d.upd_tonkhoct_nhapct(d.delete, s_mmyy, ngayhd.Text, l_id, int.Parse(r1["stt"].ToString()), decimal.Parse(r1["soluong"].ToString()), decimal.Parse(r1["sotien"].ToString()), int.Parse(r1["vat"].ToString()), int.Parse(makho.SelectedValue.ToString()), int.Parse(manguon.SelectedValue.ToString()), i_nhomcc, int.Parse(r1["mabd"].ToString()), r1["handung"].ToString(), r1["losx"].ToString(), decimal.Parse(r1["giaban"].ToString()), "", 0, 0, s_loai, 0, 0, 0, i_nhom, "", 0, 1, (chietkhau.Text != "") ? decimal.Parse(chietkhau.Text) : 0, decimal.Parse(r1["giaban2"].ToString()), decimal.Parse(r1["giamua"].ToString()), decimal.Parse(r1["sotienvat"].ToString()), decimal.Parse(r1["tyle_ggia"].ToString()), decimal.Parse(r1["st_ggia"].ToString()), decimal.Parse(r1["dongia"].ToString()), bGiaban_danhmuc,"");
				}
			}
			foreach(DataRow r1 in dtct.Rows)
			{
                if (d.get_data("select * from " + xxx + ".d_nhapct where id=" + l_id + " and stt=" + int.Parse(r1["stt"].ToString())).Tables[0].Rows.Count != 0)
                {
                    d.upd_eve_tables(s_mmyy, itable, i_userid, "upd");
                    d.upd_eve_upd_del(s_mmyy, itable, i_userid, "upd", l_id.ToString() + "^" + r1["stt"].ToString() + "^" + r1["mabd"].ToString() + "^" + r1["handung"].ToString() + "^" + r1["losx"].ToString() + "^" + r1["vat"].ToString() + "^" + r1["soluong"].ToString() + "^" + r1["dongia"].ToString() + "^" + r1["sotien"].ToString() + "^" + r1["giaban"].ToString() + "^" + r1["giamua"].ToString() + "^" + r1["sl1"].ToString() + "^" + r1["sl2"].ToString() + "^" + r1["tyle"].ToString() + "^" + "0" + "^" + "0" + "^" + "0" + "^" + "" + "^" + "0" + "^" + "0" + "^" + "0" + "^" + "" + "^" + r1["giabancu"].ToString() + "^" + r1["giamuacu"].ToString());
                }
                else d.upd_eve_tables(s_mmyy, itable, i_userid, "ins");
                d.upd_nhapct(s_mmyy, l_id, int.Parse(r1["stt"].ToString()), int.Parse(r1["mabd"].ToString()), r1["handung"].ToString(), r1["losx"].ToString(), int.Parse(r1["vat"].ToString()), decimal.Parse(r1["soluong"].ToString()), decimal.Parse(r1["dongia"].ToString()), decimal.Parse(r1["sotien"].ToString()), decimal.Parse(r1["giaban"].ToString()), decimal.Parse(r1["giamua"].ToString()), decimal.Parse(r1["sl1"].ToString()), decimal.Parse(r1["sl2"].ToString()), decimal.Parse(r1["tyle"].ToString()), 0, 0, "", "", 0, 0, int.Parse(r1["tinhtrang"].ToString()), "", decimal.Parse(r1["giabancu"].ToString()), decimal.Parse(r1["giamuacu"].ToString()), decimal.Parse(r1["giaban2"].ToString()), decimal.Parse(r1["tyle2"].ToString()), decimal.Parse(r1["tyle_ggia"].ToString()), decimal.Parse(r1["st_ggia"].ToString()),"");
				if (s_loai=="M" && bKinhphi)
				{
					r=d.getrowbyid(dtdmbd,"id="+int.Parse(r1["mabd"].ToString()));
                    if (r != null) d.upd_kinhphi_sd(i_nhom, s_mmyy.Substring(2, 2), int.Parse(r["manhom"].ToString()), d.Round(decimal.Parse(r1["sotien"].ToString()) + decimal.Parse(r1["sotien"].ToString()) * decimal.Parse(r1["vat"].ToString()) / 100 - decimal.Parse(r1["st_ggia"].ToString()), i_thanhtien_le));
				}
                d.upd_tonkhoct_nhapct(d.insert, s_mmyy, ngayhd.Text, l_id, int.Parse(r1["stt"].ToString()), decimal.Parse(r1["soluong"].ToString()), decimal.Parse(r1["sotien"].ToString()), int.Parse(r1["vat"].ToString()), int.Parse(makho.SelectedValue.ToString()), int.Parse(manguon.SelectedValue.ToString()), i_nhomcc, int.Parse(r1["mabd"].ToString()), r1["handung"].ToString(), r1["losx"].ToString(), decimal.Parse(r1["giaban"].ToString()), "", 0, 0, s_loai, 0, 0, 0, i_nhom, "", 0, 1, (chietkhau.Text != "") ? decimal.Parse(chietkhau.Text) : 0, decimal.Parse(r1["giaban2"].ToString()), decimal.Parse(r1["giamua"].ToString()), decimal.Parse(r1["sotienvat"].ToString()), decimal.Parse(r1["tyle_ggia"].ToString()), decimal.Parse(r1["st_ggia"].ToString()), decimal.Parse(r1["dongia"].ToString()), bGiaban_danhmuc,"");
			}
			d.updrec_nhapll(dtll,l_id,sophieu.Text,ngaysp.Text,sohd.Text,ngayhd.Text,bbkiem.Text,ngaykiem.Text,nguoigiao.Text,i_madv,int.Parse(makho.SelectedValue.ToString()),int.Parse(manguon.SelectedValue.ToString()),no.Text,co.Text,0,(chietkhau.Text!="")?decimal.Parse(chietkhau.Text):0);
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
			tongcong();
			ena_object(false);
            giaban2.Enabled = false;
            tyle2.Enabled = false;
			//butMoi.Focus();
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
            giaban2.Enabled = false;
            tyle2.Enabled = false;
			//butMoi.Focus();
		}

		private void ngaysp_Validated(object sender, System.EventArgs e)
		{
			if (ngaysp.Text=="") return;
            ngaysp.Text=ngaysp.Text.Trim();
            if (ngaysp.Text.Length == 6) ngaysp.Text = ngaysp.Text + DateTime.Now.Year.ToString();
			if (!d.bNgay(ngaysp.Text))
			{
				MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"),d.Msg);
				ngaysp.Focus();
				return;
			}
			ngaysp.Text=d.Ktngaygio(ngaysp.Text,10);
			if (ngaysp.Text!=s_ngaysp)
			{
				if (!d.ngay(d.StringToDate(ngaysp.Text.Substring(0,10)),DateTime.Now,i_songay))
				{
					MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ so với khai báo hệ thống (")+i_songay.ToString()+")!",d.Msg);
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
				MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"),d.Msg);
				ngayhd.Focus();
				return;
			}
			ngayhd.Text=d.Ktngaygio(ngayhd.Text,10);
			if (ngayhd.Text!=s_ngayhd)
			{
				if (!d.ngay(d.StringToDate(ngayhd.Text.Substring(0,10)),DateTime.Now,i_songay))
				{
					MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ so với khai báo hệ thống (")+i_songay.ToString()+")!",d.Msg);
					ngayhd.Focus();
					return;
				}
			}
		}

		private void ngaykiem_Validated(object sender, System.EventArgs e)
		{
			if (ngaykiem.Text=="") return;
			ngaykiem.Text=ngaykiem.Text.Trim();
            if (ngaykiem.Text.Length == 6) ngaykiem.Text = ngaykiem.Text + DateTime.Now.Year.ToString();
			if (!d.bNgay(ngaykiem.Text))
			{
                MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ !"),d.Msg);
				ngaykiem.Focus();
				return;
			}
			ngaykiem.Text=d.Ktngaygio(ngaykiem.Text,10);
			if (ngaykiem.Text!=s_ngaykiem)
			{
				if (!d.ngay(d.StringToDate(ngaykiem.Text.Substring(0,10)),DateTime.Now,i_songay))
				{
					MessageBox.Show(lan.Change_language_MessageText("Ngày không hợp lệ so với khai báo hệ thống (")+i_songay.ToString()+")!",d.Msg);
					ngaykiem.Focus();
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
			if (d.bDongia(i_nhom)) dongia.Enabled=tenbd.Enabled;
			else sotien.Enabled=tenbd.Enabled;
            if (!bGiaban_danhmuc && !bDmtyleban)
            {
                if (bGiaban_nguon) giaban.Enabled = tenbd.Enabled;
                else if (bGiaban) giaban.Enabled = tenbd.Enabled;
                if (bGiaban_nguon && manguon.SelectedIndex != -1)
                    giaban.Enabled = dtnguon.Rows[manguon.SelectedIndex]["loai"].ToString() == "1";
            }

            if (giaban.Enabled && bGiaban_noi_ngtru) giaban2.Enabled = giaban.Enabled;
            tyle2.Enabled = giaban2.Enabled;
			if (s_loai!="K") vat.Enabled=tenbd.Enabled;
			tyle.Enabled=giaban.Enabled;
			if (!upd_table(dtct)) return;
			string s_tyle=tyle.Text;
			s_vat=vat.Text;
			emp_detail();
			vat.Text=s_vat;
			tyle.Text=s_tyle;
			if (mabd.Enabled) mabd.Focus();
			else tenbd.Focus();
		}

		private void butXoa_Click(object sender, System.EventArgs e)
		{
			i_mabd=d.get_iXuat(s_mmyy,int.Parse(makho.SelectedValue.ToString()),l_id,int.Parse(stt.Text));
			if (i_mabd!=0)
			{
				r=d.getrowbyid(dtdmbd,"id="+i_mabd);
				if (r!=null)
				{
					MessageBox.Show(r["ten"].ToString().Trim()+" "+r["dang"].ToString().Trim()+"\nĐã xuất không cho phép hủy !",d.Msg);
					return;
				}
			}
			if (!upd_table(dsxoa.Tables[0])) return;
			d.delrec(dtct,"stt="+int.Parse(stt.Text));
			dtct.AcceptChanges();
			if (dtct.Rows.Count==0) emp_detail();
			else ref_text();
		}

		private bool upd_table(DataTable dt)
		{
			if (!KiemtraDetail()) return false;
            if (bDinhkhoan && bGiamgia)
            {
                string sotk = no.Text.Trim();
                if (sotk.IndexOf(stkgiamgia.Trim()) == -1)
                {
                    sotk += (sotk != "") ? "," : "";
                    sotk += stkgiamgia.Trim();
                    no.Text = sotk;
                }
            }
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
			d_dongia=(dongia.Text!="")?decimal.Parse(dongia.Text):0;
			d_sotien=(sotien.Text!="")?decimal.Parse(sotien.Text):0;
			d_sotienvat=(sotienvat.Text!="")?decimal.Parse(sotienvat.Text):0;
            d_tongtien=d_sotien+d_sotienvat;
			i_vat=(vat.Text!="")?int.Parse(vat.Text):0;
            if (bDmtyleban)
            {
                decimal tl = d.get_tyleban(d_tongtien / d_soluong);
                tyle.Text = tyle2.Text = tl.ToString();
                d_giaban = d.Round(d_tongtien / d_soluong + d_tongtien / d_soluong * tl / 100, i_sole_giaban);
                giaban2.Text = giaban.Text = d_giaban.ToString(format_giaban);
            }
			d_giaban=(giaban.Text!="")?decimal.Parse(giaban.Text):0;
            d_giaban2 = (giaban2.Text != "") ? decimal.Parse(giaban2.Text) : 0;
            decimal d_giamuacu = (giamuacu.Text != "") ? decimal.Parse(giamuacu.Text) : 0;
			decimal d_giabancu=(giabancu.Text!="")?decimal.Parse(giabancu.Text):0;
			d_tyle=(tyle.Text=="")?0:decimal.Parse(tyle.Text);
            d_tyle_ggia = (tyle_ggia.Text == "") ? 0 : decimal.Parse(tyle_ggia.Text);
            d_st_ggia = (st_ggia.Text == "") ? 0 : decimal.Parse(st_ggia.Text);
			if (d_giaban==0) d_giaban = d.Round(d_tongtien / d_soluong + d_tongtien / d_soluong * d_tyle / 100, i_sole_giaban);
            d_tyle2 = (tyle2.Text == "") ? 0 : decimal.Parse(tyle2.Text);
            if (d_giaban2 == 0) d_giaban2 = d_giaban;
            d_tongtien -= d_st_ggia;
			decimal d_giamua=d.Round(d_tongtien/d_soluong,10);
			handung.Text=handung.Text.Trim().PadRight(4,'0');
			handung.Refresh();
			losx.Refresh();
			d.updrec_nhapct(dt,int.Parse(stt.Text),i_mabd,mabd.Text,tenbd.Text,tenhc.Text,dang.Text,handung.Text,losx.Text,d_soluong,d_dongia,d_sotien,i_vat,d_sotienvat,d_giaban,d_giamua,d_sl1,d_sl2,d_tyle,0,0,0,"",0,0,(s_loai=="K" && madoituong.SelectedIndex!=-1)?int.Parse(madoituong.SelectedValue.ToString()):0,"",d_giabancu,d_giamuacu,d_giaban2,d_tyle2,d_tyle_ggia,d_st_ggia,d_tongtien,0,0,"");
			dt.AcceptChanges();
			return true;
		}

		private void madv_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter) SendKeys.Send("{Tab}");
		}

		private void manguon_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (manguon.SelectedIndex==-1) manguon.SelectedIndex=0;
				SendKeys.Send("{Tab}{F4}");
			}
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
                    sl2.Text = (r["sldonggoi"].ToString() == "0") ? "" : r["sldonggoi"].ToString();
					d_giaban=decimal.Parse(r["giaban"].ToString());
					giabancu.Text=d_giaban.ToString(format_giaban);
                    d_giaban = decimal.Parse(r["dongia"].ToString());
                    giamuacu.Text = d_giaban.ToString(format_dongia);
					if (bDinhkhoan)
					{
						string sotk=no.Text.Trim();
						if (sotk.IndexOf(r["sotk"].ToString().Trim())==-1)
						{
							sotk+=(sotk!="")?",":"";
							sotk+=r["sotk"].ToString().Trim();
							no.Text=sotk;
						}
					}
					if (s_loai=="T" || s_loai=="K")
					{
						d_dongia=decimal.Parse(r["dongia"].ToString());
						dongia.Text=d_dongia.ToString(format_dongia);
						d_giaban=decimal.Parse(r["giaban"].ToString());
						giaban.Text=d_giaban.ToString(format_giaban);
					}
                    else if (giaban.Enabled || bGiaban_danhmuc)
                    {
                        d_giaban = decimal.Parse(r["giaban"].ToString());
                        giaban.Text = d_giaban.ToString(format_giaban);
                    }
				}
			}
			if(!listDMBD.Focused) listDMBD.Hide();
		}

		private void listDMBD_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab) mabd_Validated(null,null);
		}

		private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
			ref_text();
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
				if (d.bDongia(i_nhom))
				{
					d_dongia=(dongia.Text!="")?decimal.Parse(dongia.Text):0;
					d_sotien=d.Round(d_soluong*d_dongia,i_thanhtien_le);
					sotien.Text=d_sotien.ToString(format_sotien);
				}
				else
				{	
					d_sotien=(sotien.Text!="")?decimal.Parse(sotien.Text):0;
					d_dongia=d.Round(d_sotien/d_soluong,3);
					dongia.Text=d_dongia.ToString(format_dongia);
				}
				i_vat=(vat.Text!="")?int.Parse(vat.Text):0;
                d_tyle_ggia = (tyle_ggia.Text != "") ? decimal.Parse(tyle_ggia.Text) : 0;
                d_st_ggia = (st_ggia.Text != "") ? decimal.Parse(st_ggia.Text) : 0;
                if (!sotienvat.Enabled)
                {
                    d_sotienvat = d.Round( d_sotien * i_vat / 100, i_thanhtien_le);
                    sotienvat.Text = d_sotienvat.ToString(format_sotien);
                    d_tongtien = d_sotien + d_sotienvat;
                    if (bDmtyleban)
                    {
                        decimal tl = d.get_tyleban(d_tongtien / d_soluong);
                        tyle.Text = tyle2.Text = tl.ToString();
                        d_giaban = d.Round(d_tongtien / d_soluong + d_tongtien / d_soluong * tl / 100, i_sole_giaban);
                        giaban2.Text=giaban.Text = d_giaban.ToString(format_giaban);
                    }
                    if (!bGiaban_danhmuc && !bDmtyleban)
                    {
                        d_tyle = (tyle.Text == "") ? 0 : decimal.Parse(tyle.Text);
                        d_giaban = d.Round(d_tongtien / d_soluong + d_tongtien / d_soluong * d_tyle / 100, i_sole_giaban);
                        giaban.Text = d_giaban.ToString(format_giaban);
                    }
                    d_tongtien -= d_st_ggia;
                    sotienhang.Text = d_tongtien.ToString(format_sotien);
                }
			}
			catch{}
		}

		private void vat_Validated(object sender, System.EventArgs e)
		{
			try
			{
				if (vat.Text=="") vat.Text="0";
                decimal _vat = decimal.Parse(vat.Text);
                decimal _st = decimal.Parse(sotien.Text);
                //sotienvat.Enabled = (_st == 0 && _vat > 0);
                //sotienvat.Update();
                if (!sotienvat.Enabled) tinh_giatri();
                else
                {
                    r = d.getrowbyid(dtdmbd, "ma='" + mabd.Text + "'");
                    if (r != null) giaban.Text = r["giaban"].ToString();
                    decimal _giacu = decimal.Parse(giamuacu.Text);
                    decimal _sl = decimal.Parse(soluong.Text);
                    _st = _sl * _giacu;
                    _st = _st * _vat / 100;
                    sotienvat.Text = _st.ToString(format_sotien);
                    sotienvat.Focus();
                }
                /*
                if (tyle.Enabled)
                {
                    tyle.Enabled = !sotienvat.Enabled;
                    giaban.Enabled = tyle.Enabled;
                    if (tyle2.Enabled)
                    {
                        tyle2.Enabled = !sotienvat.Enabled;
                        giaban2.Enabled = tyle.Enabled;
                    }
                }
                */
			}
			catch{}			
		}

		private void dongia_Validated(object sender, System.EventArgs e)
		{
			try
			{
				d_dongia=(dongia.Text!="")?decimal.Parse(dongia.Text):0;
				dongia.Text=d_dongia.ToString(format_dongia);
			}
			catch{dongia.Text="0";}
			tinh_giatri();
		}

		private void sotien_Validated(object sender, System.EventArgs e)
		{
			try
			{
				d_sotien=(sotien.Text!="")?decimal.Parse(sotien.Text):0;
				sotien.Text=d_sotien.ToString(format_sotien);
			}
			catch{}
			tinh_giatri();
		}

		private void soluong_Validated(object sender, System.EventArgs e)
		{
			try
			{
				d_soluong=(soluong.Text!="")?decimal.Parse(soluong.Text):0;
				soluong.Text=d_soluong.ToString(format_soluong);
                if (s_loai == "K" && sotien.Enabled)
                {
                    decimal st = (sotien.Text != "") ? decimal.Parse(sotien.Text) : 0;
                    decimal dgc = (giamuacu.Text != "") ? decimal.Parse(giamuacu.Text) : 0;
                    decimal dg = (dongia.Text != "") ? decimal.Parse(dongia.Text) : 0;
                    if (dg == 0)
                    {
                        dg = dgc;
                        dongia.Text = dg.ToString(format_dongia);
                    }
                    if (st == 0 && dg != 0)
                    {
                        st = d_soluong * dg;
                        sotien.Text = st.ToString(format_sotien);
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
				l_id=decimal.Parse(cmbSophieu.SelectedValue.ToString());
                if (d.get_paid("d_nhapll", s_mmyy, l_id))
				{
					MessageBox.Show(lan.Change_language_MessageText("Số phiếu đã thanh toán !"),d.Msg);
					return;
				}
				foreach(DataRow r1 in dtct.Rows)
				{
					i_mabd=d.get_iXuat(s_mmyy,int.Parse(makho.SelectedValue.ToString()),l_id,int.Parse(r1["stt"].ToString()));
					if (i_mabd!=0)
					{
						r=d.getrowbyid(dtdmbd,"id="+i_mabd);
						if (r!=null)
						{
							MessageBox.Show(r["ten"].ToString().Trim()+" "+r["dang"].ToString().Trim()+"\nĐã xuất không cho phép hủy !",d.Msg);
							return;
						}
					}
				}
				if (MessageBox.Show(lan.Change_language_MessageText("Đồng ý hủy số phiếu này ?"),d.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
				{
                    itable = d.tableid(s_mmyy, "d_nhapct");
					foreach(DataRow r1 in dtct.Rows)
					{
                        d.upd_eve_tables(s_mmyy, itable, i_userid, "del");
                        d.upd_eve_upd_del(s_mmyy, itable, i_userid, "del", d.fields(xxx + ".d_nhapct", "id=" + l_id + " and stt=" + int.Parse(r1["stt"].ToString())));
                        d.upd_tonkhoct_nhapct(d.delete, s_mmyy, ngayhd.Text, l_id, int.Parse(r1["stt"].ToString()), decimal.Parse(r1["soluong"].ToString()), decimal.Parse(r1["sotien"].ToString()), int.Parse(r1["vat"].ToString()), int.Parse(makho.SelectedValue.ToString()), int.Parse(manguon.SelectedValue.ToString()), i_nhomcc, int.Parse(r1["mabd"].ToString()), r1["handung"].ToString(), r1["losx"].ToString(), decimal.Parse(r1["giaban"].ToString()), "", 0, 0, s_loai, 0, 0, 0, i_nhom, "", 0, 1, (chietkhau.Text != "") ? decimal.Parse(chietkhau.Text) : 0, decimal.Parse(r1["giaban2"].ToString()), decimal.Parse(r1["giamua"].ToString()), decimal.Parse(r1["sotienvat"].ToString()), decimal.Parse(r1["tyle_ggia"].ToString()), decimal.Parse(r1["st_ggia"].ToString()), decimal.Parse(r1["dongia"].ToString()), bGiaban_danhmuc,"");
						if (s_loai=="M" && bKinhphi)
						{
							r=d.getrowbyid(dtdmbd,"id="+int.Parse(r1["mabd"].ToString()));
                            if (r != null) d.execute_data("update " + user + ".d_kinhphi set dasudung=dasudung-" + d.Round(decimal.Parse(r1["sotien"].ToString()) + decimal.Parse(r1["sotien"].ToString()) * decimal.Parse(r1["vat"].ToString()) / 100 - decimal.Parse(r1["st_ggia"].ToString()), i_thanhtien_le) + " where nhom=" + i_nhom + " and yy='" + s_mmyy.Substring(2, 2) + "' and id_nhom=" + int.Parse(r["manhom"].ToString()));
						}
					}
                    itable = d.tableid(s_mmyy, "d_nhapll");
                    d.upd_eve_tables(s_mmyy, itable, i_userid, "del");
                    d.upd_eve_upd_del(s_mmyy, itable, i_userid, "del", d.fields(xxx + ".d_nhapll", "id=" + l_id));
					d.execute_data("delete from "+xxx+".d_nhapct where id="+l_id);
                    d.execute_data("delete from "+xxx+".d_thanhtoan where id=" + l_id);
					d.execute_data("delete from "+xxx+".d_nhapll where id="+l_id);
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

		private void tongcong()
		{
			try
			{
				d_chuathue=0;
				d_cothue=0;
				foreach(DataRow r1 in dtct.Rows)
				{
					d_sotien=decimal.Parse(r1["sotien"].ToString());
					d_chuathue+=d_sotien;
					d_cothue+=d.Round(decimal.Parse(r1["tongtien"].ToString()),i_thanhtien_le);
				}
				chuathue.Text=d_chuathue.ToString(format_sotien);
				cothue.Text=d_cothue.ToString(format_sotien);
			}
			catch{}
		}

		private void sohd_Validated(object sender, System.EventArgs e)
		{
			if (l_id!=0) return;
			try
			{
				r=d.getrowbyid(dtll,"sohd='"+sohd.Text+"'");
				if (r!=null)
				{
					MessageBox.Show(lan.Change_language_MessageText("Số hóa đơn đã nhập !"),d.Msg);
					sohd.Focus();
				}
			}
			catch{}		
		}

		private void giaban_Validated(object sender, System.EventArgs e)
		{
			try
			{
				d_dongia=(dongia.Text!="")?decimal.Parse(dongia.Text):0;
				d_giaban=(giaban.Text!="")?decimal.Parse(giaban.Text):0;
				giaban.Text=d_giaban.ToString(format_giaban);
				if (d.bGiaban(i_nhom))
				{
					if (d_giaban<d_dongia)
					{
						MessageBox.Show(lan.Change_language_MessageText("Giá bán không hợp lệ !"),d.Msg);
						giaban.Focus();
						return;
					}
				}
				d_sotienvat=decimal.Parse(sotienvat.Text)+((sotien.Text!="")?decimal.Parse(sotien.Text):0);
				d_soluong=decimal.Parse(soluong.Text);
				d_tyle=(d_giaban/(d_sotienvat/d_soluong)-1)*100;
				tyle.Text=d_tyle.ToString("##0.00");
			}
			catch{giaban.Text="0";}
            if (giaban2.Text == "" || giaban2.Text == "0")
            {
                tyle2.Text = tyle.Text;
                giaban2.Text = giaban.Text;
            }
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{
            switch (chonin.SelectedIndex)
            {
                case 1: giaonhan(); break;
                case 2: bangiao(); break;
                case 3: kiemnhap(); break;
                case 4: indenghi(); break;
                default: phieunhap(); break;
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
				//if (butMoi.Enabled) return;
				Filter_dmbd(tenbd.Text);
				if (soluong.Enabled)
					listDMBD.BrowseToDmbd(tenbd,mabd,soluong,mabd.Location.X,mabd.Location.Y + mabd.Height-2,mabd.Width+lTen.Width+tenbd.Width+lTenhc.Width+tenhc.Width+ldvt.Width+dang.Width-30,mabd.Height+5);
				else
					listDMBD.BrowseToDmbd(tenbd,mabd,sl1,mabd.Location.X,mabd.Location.Y + mabd.Height-2,mabd.Width+lTen.Width+tenbd.Width+lTenhc.Width+tenhc.Width+ldvt.Width+dang.Width-30,mabd.Height+5);
			}
		}

		private void mabd_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==mabd)
			{
				//if (butMoi.Enabled) return;
				Filter_mabd(mabd.Text);
				if (soluong.Enabled)
					listDMBD.BrowseToDmbd(mabd,tenbd,soluong,mabd.Location.X,mabd.Location.Y + mabd.Height-2,mabd.Width+lTen.Width+tenbd.Width+lTenhc.Width+tenhc.Width+ldvt.Width+dang.Width-30,mabd.Height+5);
				else
					listDMBD.BrowseToDmbd(mabd,tenbd,sl1,mabd.Location.X,mabd.Location.Y + mabd.Height-2,mabd.Width+lTen.Width+tenbd.Width+lTenhc.Width+tenhc.Width+ldvt.Width+dang.Width-30,mabd.Height+5);
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

		private void manguon_SelectedIndexChanged(object sender, System.EventArgs e)
		{
            /*
            if (this.ActiveControl == manguon && !bGiaban_danhmuc && !bDmtyleban)
                if (bGiaban_nguon && butLuu.Enabled && manguon.SelectedIndex != -1)
                {
                    giaban.Enabled = dtnguon.Rows[manguon.SelectedIndex]["loai"].ToString() == "1";
                    tyle.Enabled = giaban.Enabled;
                }
             * */
		}

		private void tyle_Validated(object sender, System.EventArgs e)
		{
			try
			{
				d_tyle=(tyle.Text=="")?0:decimal.Parse(tyle.Text);
				tyle.Text=d_tyle.ToString("##0.00");
			}
			catch{tyle.Text="0";}
			tinh_giatri();
            if (tyle2.Text == "" || tyle2.Text == "0" || tyle2.Text == "0.00")
            {
                tyle2.Text = tyle.Text;
                giaban2.Text = giaban.Text;
            }
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

        private void kiemnhap()
        {
            if (dtct.Rows.Count == 0) return;
            rptBbknhap_hd f = new rptBbknhap_hd(d, i_nhom, s_makho, "d_Bbknhap_hd.rpt", madv.Text, tendv.Text, ngayhd.Text, ngaysp.Text, int.Parse(makho.SelectedValue.ToString()),i_userid);
            f.ShowDialog();
        }

        private void bangiao()
        {
            if (dtct.Rows.Count == 0) return;
            r = d.getrowbyid(dtdmnx, "ma='" + madv.Text + "'");
            if (r == null)
            {
                MessageBox.Show(lan.Change_language_MessageText("Nhà cung cấp không hợp lệ !"), d.Msg);
                madv.Focus();
                return;
            }
            string _dc = r["diachi"].ToString().Trim(), _maso = r["masothue"].ToString().Trim();
            frmBangiao f1 = new frmBangiao(r["daidien"].ToString());
            f1.ShowDialog(this);
            if (!f1.ok) return;
            DataSet dsxml = new DataSet();
            dsxml.ReadXml("..\\..\\..\\xml\\d_bangiao.xml");
            sql = "select a.stt,a.mabd,b.ma,trim(b.ten)||' '||b.hamluong as ten,nullif(b.tenhc,' ') as tenhc,b.dang,a.handung,a.losx,";
            sql += "a.soluong,a.dongia,a.vat,a.sotien,round(a.soluong*a.giamua," + i_thanhtien_le + ") as tongtien,";
            sql += "a.giaban,a.giamua,c.ten as tenhang,d.ten as tennuoc,a.sl1,a.sl2,a.tyle,a.cuocvc,a.chaythu,a.namsx,";
            sql += "a.tailieu,a.baohanh,a.nguongoc,a.tinhtrang,a.sothe,a.giabancu,a.giamuacu,a.giaban2,a.tyle2,a.tyle_ggia,";
            sql += "a.st_ggia,a.soluong*a.giamua as sotienvat ";
            sql += " from " + xxx + ".d_nhapct a," + user + ".d_dmbd b," + user + ".d_dmhang c," + user + ".d_dmnuoc d where a.mabd=b.id and b.mahang=c.id and b.manuoc=d.id and a.id=" + l_id + " order by a.stt";
            DataTable dttmp = d.get_data(sql).Tables[0];
            if (chkIn.Checked)
            {
                frmReport f = new frmReport(d, dttmp,i_userid, "d_bangiao.rpt", dsxml.Tables[0].Rows[0]["NGAY"].ToString(), dsxml.Tables[0].Rows[0]["BENA"].ToString(), dsxml.Tables[0].Rows[0]["CVA"].ToString(), dsxml.Tables[0].Rows[0]["NGUOIGIAO"].ToString(), dsxml.Tables[0].Rows[0]["BENB"].ToString().Trim(), dsxml.Tables[0].Rows[0]["CVB"].ToString().Trim(), dsxml.Tables[0].Rows[0]["NGUOINHAN"].ToString().Trim(), dsxml.Tables[0].Rows[0]["BANGIAO"].ToString().Trim(), tendv.Text.ToString().Trim().ToUpper(), ngayhd.Text, _dc, _maso);
                f.ShowDialog();
            }
            else
            {
                ReportDocument oRpt = new ReportDocument();
                oRpt.Load("..\\..\\..\\report\\d_bangiao.rpt", OpenReportMethod.OpenReportByTempCopy);
                oRpt.SetDataSource(dttmp);
                oRpt.DataDefinition.FormulaFields["soyte"].Text = "'" + d.Syte + "'";
                oRpt.DataDefinition.FormulaFields["benhvien"].Text = "'" + d.Tenbv + "'";
                oRpt.DataDefinition.FormulaFields["c1"].Text = "'" + dsxml.Tables[0].Rows[0]["NGAY"].ToString() + "'";
                oRpt.DataDefinition.FormulaFields["c2"].Text = "'" + dsxml.Tables[0].Rows[0]["BENA"].ToString() + "'";
                oRpt.DataDefinition.FormulaFields["c3"].Text = "'" + dsxml.Tables[0].Rows[0]["CVA"].ToString() + "'";
                oRpt.DataDefinition.FormulaFields["c4"].Text = "'" + dsxml.Tables[0].Rows[0]["NGUOIGIAO"].ToString() + "'";
                oRpt.DataDefinition.FormulaFields["c5"].Text = "'" + dsxml.Tables[0].Rows[0]["BENB"].ToString().Trim() + " " + tendv.Text.ToString().Trim().ToUpper() + "'";
                oRpt.DataDefinition.FormulaFields["c6"].Text = "'" + dsxml.Tables[0].Rows[0]["CVB"].ToString() + "'";
                oRpt.DataDefinition.FormulaFields["c7"].Text = "'" + dsxml.Tables[0].Rows[0]["NGUOINHAN"].ToString() + "'";
                oRpt.DataDefinition.FormulaFields["c8"].Text = "'" + dsxml.Tables[0].Rows[0]["BANGIAO"].ToString() + "'";
                oRpt.DataDefinition.FormulaFields["c9"].Text = "'" + tendv.Text.ToString().Trim().ToUpper() + "'";
                oRpt.DataDefinition.FormulaFields["c10"].Text = "'" + ngayhd.Text + "'";
                oRpt.DataDefinition.FormulaFields["diachi"].Text = "'" + _dc + "'";
                oRpt.DataDefinition.FormulaFields["masothue"].Text = "'" + _maso + "'";
                oRpt.DataDefinition.FormulaFields["giamdoc"].Text = "'" + d.Giamdoc(i_nhom) + "'";
                oRpt.DataDefinition.FormulaFields["phutrach"].Text = "'" + d.Phutrach(i_nhom) + "'";
                oRpt.DataDefinition.FormulaFields["thongke"].Text = "'" + d.Thongke(i_nhom) + "'";
                oRpt.DataDefinition.FormulaFields["ketoan"].Text = "'" + d.Ketoan(i_nhom) + "'";
                oRpt.DataDefinition.FormulaFields["thukho"].Text = "'" + d.Thukho(i_nhom) + "'";
                oRpt.PrintOptions.PaperSize = PaperSize.DefaultPaperSize;
                oRpt.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
                if (d.bPrintDialog)
                {
                    result = Thongso();
                    if (result == DialogResult.OK)
                    {
                        oRpt.PrintOptions.PrinterName = p.PrinterSettings.PrinterName;
                        oRpt.PrintToPrinter(p.PrinterSettings.Copies, false, p.PrinterSettings.FromPage, p.PrinterSettings.ToPage);
                    }
                }
                else oRpt.PrintToPrinter(1, false, 0, 0);
                oRpt.Close(); oRpt.Dispose();
            }
        }

        private void giaonhan()
        {
            if (dtct.Rows.Count == 0) return;
            frmGiaonhan f1 = new frmGiaonhan(d);
            f1.ShowDialog(this);
            if (!f1.ok) return;
            sql = "select a.stt,a.mabd,b.ma,trim(b.ten)||' '||b.hamluong as ten,b.tenhc,b.dang,a.handung,a.losx,a.soluong,a.dongia,a.vat,a.sotien,a.soluong*a.giamua as sotienvat,a.giaban,a.giamua,c.ten as tenhang,d.ten as tennuoc,a.sl1,a.sl2,a.tyle,a.cuocvc,a.chaythu,a.namsx,a.tailieu,a.baohanh,a.nguongoc,a.tinhtrang,a.sothe,a.giabancu,b.congsuat,a.tyle_ggia,a.st_ggia ";
            sql += " from "+xxx+".d_nhapct a," + user + ".d_dmbd b," + user + ".d_dmhang c," + user + ".d_dmnuoc d where a.mabd=b.id and b.mahang=c.id and b.manuoc=d.id and a.id=" + l_id + " order by a.stt";
            DataTable dttmp = d.get_data(sql).Tables[0];
            DataSet dsxml = new DataSet();
            dsxml.ReadXml("..\\..\\..\\xml\\d_giaonhan.xml");
            if (chkIn.Checked)
            {
                frmReport f = new frmReport(d, dttmp,i_userid, "d_giaonhan.rpt", dsxml.Tables[0].Rows[0]["NGAY"].ToString(), dsxml.Tables[0].Rows[0]["SOQD"].ToString(), dsxml.Tables[0].Rows[0]["NGAYQD"].ToString(), dsxml.Tables[0].Rows[0]["CUAQD"].ToString(), dsxml.Tables[0].Rows[0]["HT1"].ToString().Trim() + "+" + dsxml.Tables[0].Rows[0]["CV1"].ToString().Trim(), dsxml.Tables[0].Rows[0]["HT2"].ToString().Trim() + "+" + dsxml.Tables[0].Rows[0]["CV2"].ToString().Trim(), dsxml.Tables[0].Rows[0]["HT3"].ToString().Trim() + "+" + dsxml.Tables[0].Rows[0]["CV3"].ToString().Trim(), dsxml.Tables[0].Rows[0]["DD"].ToString().Trim(), ngayhd.Text, sophieu.Text, no.Text, co.Text);
                f.ShowDialog();
            }
            else
            {
                ReportDocument oRpt = new ReportDocument();
                oRpt.Load("..\\..\\..\\report\\d_giaonhan.rpt", OpenReportMethod.OpenReportByTempCopy);
                oRpt.SetDataSource(dttmp);
                oRpt.DataDefinition.FormulaFields["soyte"].Text = "'" + d.Syte + "'";
                oRpt.DataDefinition.FormulaFields["benhvien"].Text = "'" + d.Tenbv + "'";
                oRpt.DataDefinition.FormulaFields["c1"].Text = "'" + dsxml.Tables[0].Rows[0]["NGAY"].ToString() + "'";
                oRpt.DataDefinition.FormulaFields["c2"].Text = "'" + dsxml.Tables[0].Rows[0]["SOQD"].ToString() + "'";
                oRpt.DataDefinition.FormulaFields["c3"].Text = "'" + dsxml.Tables[0].Rows[0]["NGAYQD"].ToString() + "'";
                oRpt.DataDefinition.FormulaFields["c4"].Text = "'" + dsxml.Tables[0].Rows[0]["CUAQD"].ToString() + "'";
                oRpt.DataDefinition.FormulaFields["c5"].Text = "'" + dsxml.Tables[0].Rows[0]["HT1"].ToString().Trim() + " " + tendv.Text.ToString().Trim().ToUpper() + "'";
                oRpt.DataDefinition.FormulaFields["c6"].Text = "'" + dsxml.Tables[0].Rows[0]["CV1"].ToString() + "'";
                oRpt.DataDefinition.FormulaFields["c7"].Text = "'" + dsxml.Tables[0].Rows[0]["HT2"].ToString() + "'";
                oRpt.DataDefinition.FormulaFields["c8"].Text = "'" + dsxml.Tables[0].Rows[0]["CV2"].ToString() + "'";
                oRpt.DataDefinition.FormulaFields["c9"].Text = "'" + dsxml.Tables[0].Rows[0]["HT3"].ToString() + "'";
                oRpt.DataDefinition.FormulaFields["c10"].Text = "'" + dsxml.Tables[0].Rows[0]["CV3"].ToString() + "'";
                oRpt.DataDefinition.FormulaFields["diachi"].Text = "'" + dsxml.Tables[0].Rows[0]["DD"].ToString() + "'";
                oRpt.DataDefinition.FormulaFields["masothue"].Text = "'" + ngayhd.Text + "'";
                oRpt.DataDefinition.FormulaFields["giamdoc"].Text = "'" + d.Giamdoc(i_nhom) + "'";
                oRpt.DataDefinition.FormulaFields["phutrach"].Text = "'" + d.Phutrach(i_nhom) + "'";
                oRpt.DataDefinition.FormulaFields["thongke"].Text = "'" + d.Thongke(i_nhom) + "'";
                oRpt.DataDefinition.FormulaFields["ketoan"].Text = "'" + d.Ketoan(i_nhom) + "'";
                oRpt.DataDefinition.FormulaFields["thukho"].Text = "'" + d.Thukho(i_nhom) + "'";
                oRpt.PrintOptions.PaperSize = PaperSize.DefaultPaperSize;
                oRpt.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
                if (d.bPrintDialog)
                {
                    result = Thongso();
                    if (result == DialogResult.OK)
                    {
                        oRpt.PrintOptions.PrinterName = p.PrinterSettings.PrinterName;
                        oRpt.PrintToPrinter(p.PrinterSettings.Copies, false, p.PrinterSettings.FromPage, p.PrinterSettings.ToPage);
                    }
                }
                else oRpt.PrintToPrinter(1, false, 0, 0);
                oRpt.Close(); oRpt.Dispose();
            }
        }

        private void phieunhap()
        {
            if (dtct.Rows.Count == 0) return;
            DataTable dttmp;
            if (bNhom_nx && d.Mabv_so != 701424)
            {
                sql = "select a.stt,a.mabd,b.ma,trim(b.ten)||' '||b.hamluong as ten,b.tenhc,b.dang,a.handung,a.losx,a.soluong,a.dongia,a.vat,a.sotien,round(a.soluong*a.giamua," + i_thanhtien_le + ")+a.cuocvc+a.chaythu as sotienvat,a.giaban,c.ten as tenhang,d.ten as tennuoc,a.sl1,a.sl2,a.tyle,b.manhom,e.ten as tennhom,f.ten as noingoai,f.stt as sttnn ";
                sql += " from " + xxx + ".d_nhapct a," + user + ".d_dmbd b," + user + ".d_dmhang c," + user + ".d_dmnuoc d," + user + ".d_dmnhom e," + user + ".d_nhomhang f ";
                sql += " where a.mabd=b.id and b.mahang=c.id and b.manuoc=d.id and b.manhom=e.id and c.loai=f.id and a.id=" + l_id;
                if (d.bInHangNuoc_Nhapxuat(i_nhom)) sql += " order by f.stt,e.stt,a.stt";
                else sql += " order by e.stt,a.stt";
                dttmp = d.get_data(sql).Tables[0];
            }
            else
            {
                sql = "select a.stt,a.mabd,b.ma,trim(b.ten)||' '||b.hamluong as ten,nullif(b.tenhc,' ') as tenhc,b.dang,a.handung,a.losx,";
                sql += "a.soluong,a.dongia,a.vat,a.sotien,round(a.soluong*a.giamua," + i_thanhtien_le + ") as tongtien,";
                sql += "a.giaban,a.giamua,c.ten as tenhang,d.ten as tennuoc,a.sl1,a.sl2,a.tyle,a.cuocvc,a.chaythu,a.namsx,";
                sql += "a.tailieu,a.baohanh,a.nguongoc,a.tinhtrang,a.sothe,a.giabancu,a.giamuacu,a.giaban2,a.tyle2,a.tyle_ggia,";
                sql += "a.st_ggia,a.soluong*a.giamua as sotienvat ";
                sql += " from " + xxx + ".d_nhapct a," + user + ".d_dmbd b," + user + ".d_dmhang c," + user + ".d_dmnuoc d where a.mabd=b.id and b.mahang=c.id and b.manuoc=d.id and a.id=" + l_id + " order by a.stt";
                dttmp = d.get_data(sql).Tables[0];
            }
            r = d.getrowbyid(dtdmnx, "ma='" + madv.Text + "'");
            string c11 = no.Text, c12 = co.Text, _dc = r["diachi"].ToString().Trim(), _maso = r["masothue"].ToString().Trim();
            if (r == null)
            {
                MessageBox.Show(lan.Change_language_MessageText("Nhà cung cấp không hợp lệ !"), d.Msg);
                madv.Focus();
                return;
            }
            string tenfile = (d.Mabv_so == 701424) ? "d_phieunhap.rpt" : (d.bInHangNuoc_Nhapxuat(i_nhom)) ? "d_phieunhap_ct_nhom.rpt" : (bNhom_nx) ? "d_phieunhap_nhom.rpt" : "d_phieunhap.rpt";
            if (tenfile == "d_phieunhap.rpt")
            {
                if (c11.IndexOf(",") == -1) c11 += ",";
                decimal st = 0;
                string s12 = "NỢ :     ";
                sql = "select c.ma,sum(a.soluong*a.giamua) as sotienvat from "+xxx+".d_nhapct a,";
                sql += user + ".d_dmbd b," + user + ".d_dmnhomkt c ";
                sql += " where a.mabd=b.id and b.sotk=c.id and a.id=" + l_id;
                if (bGiamgia) sql+=" and a.st_ggia=0 ";
                sql+=" group by c.ma";
                foreach (DataRow r1 in d.get_data(sql).Tables[0].Rows)
                {
                    if (r1["sotienvat"].ToString() != "")
                    {
                        st = decimal.Parse(r1["sotienvat"].ToString());
                        s12 = s12 + r1["ma"].ToString().Trim() + " :     " + st.ToString(format_sotien).Trim() + ";      ";
                    }
                }
                if (bGiamgia)
                {
                    sql = "select sum(a.soluong*a.giamua) as sotienvat from " + xxx + ".d_nhapct a,";
                    sql += user + ".d_dmbd b," + user + ".d_dmnhomkt c ";
                    sql += " where a.mabd=b.id and b.sotk=c.id and a.id=" + l_id + " and a.st_ggia<>0";
                    foreach (DataRow r1 in d.get_data(sql).Tables[0].Rows)
                    {
                        if (r1["sotienvat"].ToString() != "")
                        {
                            st = decimal.Parse(r1["sotienvat"].ToString());
                            s12 = s12 + stkgiamgia + " :     " + st.ToString(format_sotien).Trim() + ";      ";
                        }
                    }
                }
                c12 = c12 + "," + s12;
            }
            string _ngay = ngaysp.Text + ((chonin.SelectedIndex == 5) ? "1" : (chonin.SelectedIndex == 6) ? "2" : "");
            if (chkIn.Checked)
            {
                frmReport f = new frmReport(d, dttmp,i_userid, tenfile, cmbSophieu.Text, _ngay, c11, c12, nguoigiao.Text, sohd.Text, ngayhd.Text, tendv.Text, makho.Text.Trim()+";"+manguon.Text.Trim(), doiso.Doiso_Unicode(Convert.ToInt64(d_cothue).ToString()), _dc, _maso);
                f.ShowDialog();
            }
            else
            {
                ReportDocument oRpt = new ReportDocument();
                oRpt.Load("..\\..\\..\\report\\" + tenfile, OpenReportMethod.OpenReportByTempCopy);
                oRpt.SetDataSource(dttmp);
                oRpt.DataDefinition.FormulaFields["soyte"].Text = "'" + d.Syte + "'";
                oRpt.DataDefinition.FormulaFields["benhvien"].Text = "'" + d.Tenbv + "'";
                oRpt.DataDefinition.FormulaFields["c1"].Text = "'" + cmbSophieu.Text + "'";
                oRpt.DataDefinition.FormulaFields["c2"].Text = "'" + _ngay + "'";
                oRpt.DataDefinition.FormulaFields["c3"].Text = "'" + c11 + "'";
                oRpt.DataDefinition.FormulaFields["c4"].Text = "'" + c12 + "'";
                oRpt.DataDefinition.FormulaFields["c5"].Text = "'" + nguoigiao.Text + "'";
                oRpt.DataDefinition.FormulaFields["c6"].Text = "'" + sohd.Text + "'";
                oRpt.DataDefinition.FormulaFields["c7"].Text = "'" + ngayhd.Text + "'";
                oRpt.DataDefinition.FormulaFields["c8"].Text = "'" + tendv.Text + "'";
                oRpt.DataDefinition.FormulaFields["c9"].Text = "'" + makho.Text.Trim()+";"+manguon.Text.Trim() + "'";
                oRpt.DataDefinition.FormulaFields["c10"].Text = "'" + doiso.Doiso_Unicode(Convert.ToInt64(d_cothue).ToString()) + "'";
                if (_dc != "") oRpt.DataDefinition.FormulaFields["diachi"].Text = "'" + _dc + "'";
                if (_maso != "") oRpt.DataDefinition.FormulaFields["masothue"].Text = "'" + _maso + "'";
                oRpt.DataDefinition.FormulaFields["giamdoc"].Text = "'" + d.Giamdoc(i_nhom) + "'";
                oRpt.DataDefinition.FormulaFields["phutrach"].Text = "'" + d.Phutrach(i_nhom) + "'";
                oRpt.DataDefinition.FormulaFields["thongke"].Text = "'" + d.Thongke(i_nhom) + "'";
                oRpt.DataDefinition.FormulaFields["ketoan"].Text = "'" + d.Ketoan(i_nhom) + "'";
                oRpt.DataDefinition.FormulaFields["thukho"].Text = "'" + d.Thukho(i_nhom) + "'";
                oRpt.PrintOptions.PaperSize = PaperSize.DefaultPaperSize;
                oRpt.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
                if (d.bPrintDialog)
                {
                    result = Thongso();
                    if (result == DialogResult.OK)
                    {
                        oRpt.PrintOptions.PrinterName = p.PrinterSettings.PrinterName;
                        oRpt.PrintToPrinter(p.PrinterSettings.Copies, false, p.PrinterSettings.FromPage, p.PrinterSettings.ToPage);
                    }
                }
                else oRpt.PrintToPrinter(1, false, 0, 0);
                oRpt.Close(); oRpt.Dispose();
            }
        }
        private void indenghi()
        {
            if (dtct.Rows.Count == 0) return;
            frmDenghict f1 = new frmDenghict(d, i_nhom, madv.Text.Trim(), tendv.Text.Trim(), ngayhd.Text, i_userid);
            f1.ShowDialog();
        }

        private void tyle2_Validated(object sender, EventArgs e)
        {
            try
            {
                d_tyle2 = (tyle2.Text == "") ? 0 : decimal.Parse(tyle2.Text);
                tyle2.Text = d_tyle2.ToString("##0.00");
            }
            catch { tyle2.Text = "0"; }
            d_tongtien = ((sotien.Text != "") ? decimal.Parse(sotien.Text) : 0) + ((sotienvat.Text != "") ? decimal.Parse(sotienvat.Text) : 0);
            d_tyle2 = (tyle2.Text == "") ? 0 : decimal.Parse(tyle2.Text);
            d_giaban2 = (d_soluong!=0)?d.Round(d_tongtien / d_soluong + d_tongtien / d_soluong * d_tyle2 / 100, i_sole_giaban):0;
            giaban2.Text = d_giaban2.ToString(format_giaban);
        }

        private void giaban2_Validated(object sender, EventArgs e)
        {
            try
            {
                d_dongia = (dongia.Text != "") ? decimal.Parse(dongia.Text) : 0;
                d_giaban2 = (giaban2.Text != "") ? decimal.Parse(giaban2.Text) : 0;
                giaban2.Text = d_giaban2.ToString(format_giaban);
                if (d.bGiaban(i_nhom))
                {
                    if (d_giaban2 < d_dongia)
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Giá bán không hợp lệ !"), d.Msg);
                        giaban2.Focus();
                        return;
                    }
                }
                d_sotienvat = decimal.Parse(sotienvat.Text) + ((sotien.Text != "") ? decimal.Parse(sotien.Text) : 0);
                d_soluong = decimal.Parse(soluong.Text);
                d_tyle2 = (d_giaban2 / (d_sotienvat / d_soluong) - 1) * 100;
                tyle2.Text = d_tyle2.ToString("##0.00");
            }
            catch { giaban2.Text = "0"; }
        }

        private void madoituong_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void losx_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab || e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
                if (s_loai == "K") SendKeys.Send("{F4}");
            }
        }

        private void tyle_ggia_Validated(object sender, EventArgs e)
        {
            try
            {
                decimal tyle = (tyle_ggia.Text != "") ? decimal.Parse(tyle_ggia.Text) : 0;
                decimal st = (sotien.Text != "") ? decimal.Parse(sotien.Text) : 0;
                decimal stggia = (tyle != 0) ? st * tyle/100 : 0;
                st_ggia.Text = stggia.ToString(format_sotien);
                tinh_giatri();
            }
            catch { tyle_ggia.Text = "0"; }
        }

        private void st_ggia_Validated(object sender, EventArgs e)
        {
            try
            {
                decimal st = (sotien.Text != "") ? decimal.Parse(sotien.Text) : 0;
                decimal stggia = (st_ggia.Text != "") ? decimal.Parse(st_ggia.Text) : 0;
                decimal tyle = (st != 0) ? stggia / st * 100 : 0;
                tyle_ggia.Text=tyle.ToString("##0.00");
                tinh_giatri();
            }
            catch { st_ggia.Text = "0"; }
        }

        private void butFind_Click(object sender, EventArgs e)
        {
            frmTimthuoc f = new frmTimthuoc(d, s_mmyy, s_loai, i_nhom, i_userid, bAdmin);
            f.ShowDialog();
        }
	}
}
