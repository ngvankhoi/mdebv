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
	/// Summary description for frmTrathuoc.
	/// </summary>
	public class frmTrathuoc : System.Windows.Forms.Form
	{
        Language lan = new Language();Bogotiengviet tv = new Bogotiengviet();private System.Windows.Forms.TextBox textBox111 = new System.Windows.Forms.TextBox();
        private int i_maxlength_mabn = 8;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label10;
		private MaskedBox.MaskedBox ngaysp;
		private System.Windows.Forms.ComboBox makho;
		private LibList.List listDMBD;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label lTen;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label18;
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
        private string xxx, user, s_mmyy, s_ngay, sql, s_loai, s_ngaysp, s_makho, s_userid, format_soluong, format_dongia, format_sotien, s_loaint;
		private int i_nhom,i_userid,i_mabd,i_old,i_songay,i_quayban,itable,i_madv;
		private decimal l_id;
		private decimal d_soluong,d_dongia,d_sotien,d_giaban,d_soluongcu;
        private bool bKhoaso, bGiaban, bNew, bAdmin, bNgtru_mabn, bDongia, bTrathuoc_xuatban,bThuhoi,bSotoa_thang;
		private AccessData d;
		private Doisototext doiso=new Doisototext();
		private DataTable dtdmbd=new DataTable();
		private DataTable dtdmnx=new DataTable();
		private DataTable dtll=new DataTable();
		private DataTable dtct=new DataTable();
		private DataTable dtold=new DataTable();
		private DataSet dsxoa=new DataSet();
        private bool aThem = false;
		private System.Windows.Forms.Label ldvt;
		private DataRow r;
		private System.Windows.Forms.TextBox stt;
		private System.Windows.Forms.TextBox tenhc;
		private System.Windows.Forms.Label lTenhc;
		private MaskedTextBox.MaskedTextBox sophieu;
		private MaskedTextBox.MaskedTextBox giaban;
		private System.Windows.Forms.Label label25;
		private System.Drawing.Printing.PrintDocument docToPrint = new System.Drawing.Printing.PrintDocument();
		private PrintDialog p=new PrintDialog();
		private DialogResult result;
		private System.Windows.Forms.Label label3;
		private MaskedTextBox.MaskedTextBox hoten;
		private System.Windows.Forms.ComboBox manguon;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label lbl;
        private ComboBox quay;
        private Label label1;
        private MaskedBox.MaskedBox ngayhd;
        private Label label4;
        private ComboBox userid;
        private Label label5;
        private ComboBox khoban;
        private Label label6;
        private ComboBox lydo;
        private Label label7;
        private ComboBox nhomcc;
        private Label label8;
        private MaskedBox.MaskedBox handung;
        private Label label24;
        private Label label15;
        private TextBox losx;
        private TextBox tinhtrang;
        private TextBox makp;
        private MaskedTextBox.MaskedTextBox gianovat;
        private Label label11;
        private bool bGiaban_danhmuc;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

        public frmTrathuoc(AccessData acc, string loai, string mmyy, string ngay, int nhom, int userid, string kho, string title, bool ban, bool admin, string user, int quayban, string _loaint,bool thuhoi)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			d=acc;i_quayban = quayban; s_loaint = _loaint;
			i_nhom=nhom;s_makho=kho;i_userid=userid;s_mmyy=mmyy;s_ngay=ngay;
			s_loai=loai;s_userid=user;bGiaban=ban;bAdmin=admin;
            this.Text = title; bThuhoi = thuhoi;            
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTrathuoc));
            this.lbl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.ngaysp = new MaskedBox.MaskedBox();
            this.makho = new System.Windows.Forms.ComboBox();
            this.listDMBD = new LibList.List();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.label13 = new System.Windows.Forms.Label();
            this.lTen = new System.Windows.Forms.Label();
            this.ldvt = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
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
            this.stt = new System.Windows.Forms.TextBox();
            this.tenhc = new System.Windows.Forms.TextBox();
            this.lTenhc = new System.Windows.Forms.Label();
            this.sophieu = new MaskedTextBox.MaskedTextBox();
            this.giaban = new MaskedTextBox.MaskedTextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.hoten = new MaskedTextBox.MaskedTextBox();
            this.manguon = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.quay = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ngayhd = new MaskedBox.MaskedBox();
            this.label4 = new System.Windows.Forms.Label();
            this.userid = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.khoban = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lydo = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.nhomcc = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.handung = new MaskedBox.MaskedBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.losx = new System.Windows.Forms.TextBox();
            this.tinhtrang = new System.Windows.Forms.TextBox();
            this.makp = new System.Windows.Forms.TextBox();
            this.gianovat = new MaskedTextBox.MaskedTextBox();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl
            // 
            this.lbl.Location = new System.Drawing.Point(239, 4);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(56, 23);
            this.lbl.TabIndex = 2;
            this.lbl.Text = "Mã BN :";
            this.lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(4, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "Ngày trả :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(536, 26);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 23);
            this.label10.TabIndex = 9;
            this.label10.Text = "Kho :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ngaysp
            // 
            this.ngaysp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngaysp.Enabled = false;
            this.ngaysp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngaysp.Location = new System.Drawing.Point(56, 5);
            this.ngaysp.Mask = "##/##/####";
            this.ngaysp.MaxLength = 10;
            this.ngaysp.Name = "ngaysp";
            this.ngaysp.Size = new System.Drawing.Size(64, 21);
            this.ngaysp.TabIndex = 0;
            this.ngaysp.Text = "  /  /    ";
            this.ngaysp.Validated += new System.EventHandler(this.ngaysp_Validated);
            // 
            // makho
            // 
            this.makho.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.makho.BackColor = System.Drawing.SystemColors.HighlightText;
            this.makho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.makho.Enabled = false;
            this.makho.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makho.Location = new System.Drawing.Point(583, 28);
            this.makho.Name = "makho";
            this.makho.Size = new System.Drawing.Size(201, 21);
            this.makho.TabIndex = 11;
            this.makho.KeyDown += new System.Windows.Forms.KeyEventHandler(this.makho_KeyDown);
            // 
            // listDMBD
            // 
            this.listDMBD.BackColor = System.Drawing.SystemColors.Info;
            this.listDMBD.ColumnCount = 0;
            this.listDMBD.Location = new System.Drawing.Point(376, 553);
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
            this.dataGrid1.Location = new System.Drawing.Point(8, 32);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.dataGrid1.ParentRowsForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeaderWidth = 10;
            this.dataGrid1.SelectionBackColor = System.Drawing.Color.CadetBlue;
            this.dataGrid1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.dataGrid1.Size = new System.Drawing.Size(776, 419);
            this.dataGrid1.TabIndex = 27;
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label13.Location = new System.Drawing.Point(4, 454);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(32, 23);
            this.label13.TabIndex = 28;
            this.label13.Text = "Mã :";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lTen
            // 
            this.lTen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lTen.Location = new System.Drawing.Point(127, 454);
            this.lTen.Name = "lTen";
            this.lTen.Size = new System.Drawing.Size(63, 23);
            this.lTen.TabIndex = 29;
            this.lTen.Text = "Tên :";
            this.lTen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ldvt
            // 
            this.ldvt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ldvt.Location = new System.Drawing.Point(-20, 477);
            this.ldvt.Name = "ldvt";
            this.ldvt.Size = new System.Drawing.Size(58, 23);
            this.ldvt.TabIndex = 30;
            this.ldvt.Text = "ĐVT :";
            this.ldvt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label16.Location = new System.Drawing.Point(134, 476);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(56, 23);
            this.label16.TabIndex = 31;
            this.label16.Text = "Số lượng :";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label17.Location = new System.Drawing.Point(440, 476);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(56, 23);
            this.label17.TabIndex = 32;
            this.label17.Text = "Giá mua :";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label18.Location = new System.Drawing.Point(597, 476);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(56, 23);
            this.label18.TabIndex = 33;
            this.label18.Text = "Số tiền :";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tenbd
            // 
            this.tenbd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tenbd.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenbd.Enabled = false;
            this.tenbd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenbd.Location = new System.Drawing.Point(193, 454);
            this.tenbd.Name = "tenbd";
            this.tenbd.Size = new System.Drawing.Size(237, 21);
            this.tenbd.TabIndex = 13;
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
            this.mabd.Location = new System.Drawing.Point(44, 454);
            this.mabd.Name = "mabd";
            this.mabd.Size = new System.Drawing.Size(87, 21);
            this.mabd.TabIndex = 12;
            this.mabd.Validated += new System.EventHandler(this.mabd_Validated);
            this.mabd.TextChanged += new System.EventHandler(this.mabd_TextChanged);
            this.mabd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tenbd_KeyDown);
            // 
            // dang
            // 
            this.dang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dang.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dang.Enabled = false;
            this.dang.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dang.Location = new System.Drawing.Point(44, 477);
            this.dang.Mask = "";
            this.dang.MaxLength = 10;
            this.dang.Name = "dang";
            this.dang.Size = new System.Drawing.Size(87, 21);
            this.dang.TabIndex = 15;
            // 
            // soluong
            // 
            this.soluong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.soluong.BackColor = System.Drawing.SystemColors.HighlightText;
            this.soluong.Enabled = false;
            this.soluong.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.soluong.Location = new System.Drawing.Point(193, 477);
            this.soluong.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
            this.soluong.Name = "soluong";
            this.soluong.Size = new System.Drawing.Size(77, 21);
            this.soluong.TabIndex = 16;
            this.soluong.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.soluong.Validated += new System.EventHandler(this.soluong_Validated);
            // 
            // dongia
            // 
            this.dongia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dongia.BackColor = System.Drawing.SystemColors.HighlightText;
            this.dongia.Enabled = false;
            this.dongia.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dongia.Location = new System.Drawing.Point(498, 477);
            this.dongia.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
            this.dongia.Name = "dongia";
            this.dongia.Size = new System.Drawing.Size(111, 21);
            this.dongia.TabIndex = 18;
            this.dongia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.dongia.Validated += new System.EventHandler(this.dongia_Validated);
            // 
            // sotien
            // 
            this.sotien.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sotien.BackColor = System.Drawing.SystemColors.HighlightText;
            this.sotien.Enabled = false;
            this.sotien.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sotien.Location = new System.Drawing.Point(650, 477);
            this.sotien.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
            this.sotien.Name = "sotien";
            this.sotien.Size = new System.Drawing.Size(134, 21);
            this.sotien.TabIndex = 19;
            this.sotien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.sotien.Validated += new System.EventHandler(this.sotien_Validated);
            // 
            // butMoi
            // 
            this.butMoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butMoi.Image = global::Duoc.Properties.Resources.add;
            this.butMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMoi.Location = new System.Drawing.Point(106, 524);
            this.butMoi.Name = "butMoi";
            this.butMoi.Size = new System.Drawing.Size(70, 25);
            this.butMoi.TabIndex = 28;
            this.butMoi.Text = "     &Mới";
            this.butMoi.Click += new System.EventHandler(this.butMoi_Click);
            // 
            // butSua
            // 
            this.butSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butSua.Image = global::Duoc.Properties.Resources.quick_edit;
            this.butSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butSua.Location = new System.Drawing.Point(176, 524);
            this.butSua.Name = "butSua";
            this.butSua.Size = new System.Drawing.Size(70, 25);
            this.butSua.TabIndex = 29;
            this.butSua.Text = "     &Sửa";
            this.butSua.Click += new System.EventHandler(this.butSua_Click);
            // 
            // butLuu
            // 
            this.butLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butLuu.Enabled = false;
            this.butLuu.Image = global::Duoc.Properties.Resources.save;
            this.butLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLuu.Location = new System.Drawing.Point(246, 524);
            this.butLuu.Name = "butLuu";
            this.butLuu.Size = new System.Drawing.Size(70, 25);
            this.butLuu.TabIndex = 26;
            this.butLuu.Text = "     &Lưu";
            this.butLuu.Click += new System.EventHandler(this.butLuu_Click);
            // 
            // butThem
            // 
            this.butThem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butThem.Enabled = false;
            this.butThem.Image = global::Duoc.Properties.Resources.plus;
            this.butThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butThem.Location = new System.Drawing.Point(316, 524);
            this.butThem.Name = "butThem";
            this.butThem.Size = new System.Drawing.Size(70, 25);
            this.butThem.TabIndex = 24;
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
            this.butXoa.Location = new System.Drawing.Point(386, 524);
            this.butXoa.Name = "butXoa";
            this.butXoa.Size = new System.Drawing.Size(70, 25);
            this.butXoa.TabIndex = 25;
            this.butXoa.Text = "     &Xóa";
            this.butXoa.Click += new System.EventHandler(this.butXoa_Click);
            // 
            // butBoqua
            // 
            this.butBoqua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butBoqua.Enabled = false;
            this.butBoqua.Image = global::Duoc.Properties.Resources.undo_ok;
            this.butBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBoqua.Location = new System.Drawing.Point(456, 524);
            this.butBoqua.Name = "butBoqua";
            this.butBoqua.Size = new System.Drawing.Size(70, 25);
            this.butBoqua.TabIndex = 27;
            this.butBoqua.Text = "&Bỏ qua";
            this.butBoqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butBoqua.Click += new System.EventHandler(this.butBoqua_Click);
            // 
            // butHuy
            // 
            this.butHuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butHuy.Image = global::Duoc.Properties.Resources.delete_enabled;
            this.butHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butHuy.Location = new System.Drawing.Point(526, 524);
            this.butHuy.Name = "butHuy";
            this.butHuy.Size = new System.Drawing.Size(70, 25);
            this.butHuy.TabIndex = 30;
            this.butHuy.Text = "    &Hủy";
            this.butHuy.Click += new System.EventHandler(this.butHuy_Click);
            // 
            // butIn
            // 
            this.butIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butIn.Image = global::Duoc.Properties.Resources.Print1;
            this.butIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butIn.Location = new System.Drawing.Point(596, 524);
            this.butIn.Name = "butIn";
            this.butIn.Size = new System.Drawing.Size(70, 25);
            this.butIn.TabIndex = 31;
            this.butIn.Text = "     &In";
            this.butIn.Click += new System.EventHandler(this.butIn_Click);
            // 
            // butKetthuc
            // 
            this.butKetthuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butKetthuc.Image = global::Duoc.Properties.Resources.close_r;
            this.butKetthuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butKetthuc.Location = new System.Drawing.Point(666, 524);
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
            this.cmbSophieu.Location = new System.Drawing.Point(293, 5);
            this.cmbSophieu.Name = "cmbSophieu";
            this.cmbSophieu.Size = new System.Drawing.Size(79, 21);
            this.cmbSophieu.TabIndex = 4;
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
            // tenhc
            // 
            this.tenhc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tenhc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tenhc.Enabled = false;
            this.tenhc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenhc.Location = new System.Drawing.Point(498, 454);
            this.tenhc.Name = "tenhc";
            this.tenhc.Size = new System.Drawing.Size(286, 21);
            this.tenhc.TabIndex = 14;
            // 
            // lTenhc
            // 
            this.lTenhc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lTenhc.Location = new System.Drawing.Point(433, 453);
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
            this.sophieu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sophieu.Location = new System.Drawing.Point(293, 5);
            this.sophieu.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.sophieu.Name = "sophieu";
            this.sophieu.Size = new System.Drawing.Size(79, 21);
            this.sophieu.TabIndex = 3;
            this.sophieu.Validated += new System.EventHandler(this.sophieu_Validated);
            // 
            // giaban
            // 
            this.giaban.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.giaban.BackColor = System.Drawing.SystemColors.HighlightText;
            this.giaban.Enabled = false;
            this.giaban.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.giaban.Location = new System.Drawing.Point(44, 500);
            this.giaban.Masked = MaskedTextBox.MaskedTextBox.Mask.Digit;
            this.giaban.Name = "giaban";
            this.giaban.Size = new System.Drawing.Size(87, 21);
            this.giaban.TabIndex = 20;
            this.giaban.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.giaban.Validated += new System.EventHandler(this.giaban_Validated);
            // 
            // label25
            // 
            this.label25.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label25.Location = new System.Drawing.Point(-9, 500);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(56, 23);
            this.label25.TabIndex = 66;
            this.label25.Text = "Giá bán :";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(382, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 23);
            this.label3.TabIndex = 67;
            this.label3.Text = "Họ tên :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // hoten
            // 
            this.hoten.BackColor = System.Drawing.SystemColors.HighlightText;
            this.hoten.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.hoten.Enabled = false;
            this.hoten.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoten.Location = new System.Drawing.Point(427, 5);
            this.hoten.Masked = MaskedTextBox.MaskedTextBox.Mask.None;
            this.hoten.Name = "hoten";
            this.hoten.Size = new System.Drawing.Size(121, 21);
            this.hoten.TabIndex = 5;
            // 
            // manguon
            // 
            this.manguon.BackColor = System.Drawing.SystemColors.HighlightText;
            this.manguon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.manguon.Enabled = false;
            this.manguon.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manguon.Location = new System.Drawing.Point(427, 28);
            this.manguon.Name = "manguon";
            this.manguon.Size = new System.Drawing.Size(121, 21);
            this.manguon.TabIndex = 10;
            this.manguon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.manguon_KeyDown);
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(382, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 20);
            this.label9.TabIndex = 68;
            this.label9.Text = "Nguồn :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // quay
            // 
            this.quay.BackColor = System.Drawing.SystemColors.HighlightText;
            this.quay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.quay.Enabled = false;
            this.quay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quay.Location = new System.Drawing.Point(583, 5);
            this.quay.Name = "quay";
            this.quay.Size = new System.Drawing.Size(87, 21);
            this.quay.TabIndex = 6;
            this.quay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.quay_KeyDown);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(536, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 23);
            this.label1.TabIndex = 69;
            this.label1.Text = "Quầy :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ngayhd
            // 
            this.ngayhd.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ngayhd.Enabled = false;
            this.ngayhd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ngayhd.Location = new System.Drawing.Point(179, 5);
            this.ngayhd.Mask = "##/##/####";
            this.ngayhd.MaxLength = 10;
            this.ngayhd.Name = "ngayhd";
            this.ngayhd.Size = new System.Drawing.Size(64, 21);
            this.ngayhd.TabIndex = 1;
            this.ngayhd.Text = "  /  /    ";
            this.ngayhd.Validated += new System.EventHandler(this.ngayhd_Validated);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(119, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 23);
            this.label4.TabIndex = 71;
            this.label4.Text = "Ngày bán :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // userid
            // 
            this.userid.BackColor = System.Drawing.SystemColors.HighlightText;
            this.userid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.userid.Enabled = false;
            this.userid.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userid.Location = new System.Drawing.Point(56, 28);
            this.userid.Name = "userid";
            this.userid.Size = new System.Drawing.Size(187, 21);
            this.userid.TabIndex = 8;
            this.userid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.userid_KeyDown);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(-20, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 23);
            this.label5.TabIndex = 73;
            this.label5.Text = "Người bán :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // khoban
            // 
            this.khoban.BackColor = System.Drawing.SystemColors.HighlightText;
            this.khoban.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.khoban.Enabled = false;
            this.khoban.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.khoban.Location = new System.Drawing.Point(293, 28);
            this.khoban.Name = "khoban";
            this.khoban.Size = new System.Drawing.Size(94, 21);
            this.khoban.TabIndex = 9;
            this.khoban.KeyDown += new System.Windows.Forms.KeyEventHandler(this.khoban_KeyDown);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(235, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 23);
            this.label6.TabIndex = 76;
            this.label6.Text = "Kho bán :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lydo
            // 
            this.lydo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lydo.BackColor = System.Drawing.SystemColors.HighlightText;
            this.lydo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lydo.Enabled = false;
            this.lydo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lydo.Location = new System.Drawing.Point(704, 5);
            this.lydo.Name = "lydo";
            this.lydo.Size = new System.Drawing.Size(80, 21);
            this.lydo.TabIndex = 7;
            this.lydo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lydo_KeyDown);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(659, 2);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 23);
            this.label7.TabIndex = 105;
            this.label7.Text = "Lý do :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nhomcc
            // 
            this.nhomcc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.nhomcc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nhomcc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nhomcc.Enabled = false;
            this.nhomcc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhomcc.Location = new System.Drawing.Point(498, 500);
            this.nhomcc.Name = "nhomcc";
            this.nhomcc.Size = new System.Drawing.Size(286, 21);
            this.nhomcc.TabIndex = 23;
            this.nhomcc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nhomcc_KeyDown);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.Location = new System.Drawing.Point(424, 498);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 23);
            this.label8.TabIndex = 111;
            this.label8.Text = "Nhà CC :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // handung
            // 
            this.handung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.handung.BackColor = System.Drawing.SystemColors.HighlightText;
            this.handung.Enabled = false;
            this.handung.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.handung.Location = new System.Drawing.Point(193, 499);
            this.handung.Mask = "####";
            this.handung.Name = "handung";
            this.handung.Size = new System.Drawing.Size(77, 21);
            this.handung.TabIndex = 21;
            this.handung.Text = "    ";
            // 
            // label24
            // 
            this.label24.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label24.Location = new System.Drawing.Point(247, 498);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(80, 23);
            this.label24.TabIndex = 110;
            this.label24.Text = "Lô :";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label15.Location = new System.Drawing.Point(129, 499);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(61, 23);
            this.label15.TabIndex = 109;
            this.label15.Text = "Hạn dùng :";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // losx
            // 
            this.losx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.losx.BackColor = System.Drawing.SystemColors.HighlightText;
            this.losx.Enabled = false;
            this.losx.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.losx.Location = new System.Drawing.Point(329, 499);
            this.losx.Name = "losx";
            this.losx.Size = new System.Drawing.Size(101, 21);
            this.losx.TabIndex = 22;
            this.losx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.losx_KeyDown);
            // 
            // tinhtrang
            // 
            this.tinhtrang.Enabled = false;
            this.tinhtrang.Location = new System.Drawing.Point(688, 310);
            this.tinhtrang.Name = "tinhtrang";
            this.tinhtrang.Size = new System.Drawing.Size(33, 20);
            this.tinhtrang.TabIndex = 112;
            // 
            // makp
            // 
            this.makp.BackColor = System.Drawing.SystemColors.HighlightText;
            this.makp.Enabled = false;
            this.makp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makp.Location = new System.Drawing.Point(645, 310);
            this.makp.Name = "makp";
            this.makp.Size = new System.Drawing.Size(62, 21);
            this.makp.TabIndex = 113;
            // 
            // gianovat
            // 
            this.gianovat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gianovat.BackColor = System.Drawing.SystemColors.HighlightText;
            this.gianovat.Enabled = false;
            this.gianovat.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gianovat.Location = new System.Drawing.Point(329, 476);
            this.gianovat.Masked = MaskedTextBox.MaskedTextBox.Mask.Decimal;
            this.gianovat.Name = "gianovat";
            this.gianovat.Size = new System.Drawing.Size(101, 21);
            this.gianovat.TabIndex = 17;
            this.gianovat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.gianovat.Validated += new System.EventHandler(this.gianovat_Validated);
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label11.Location = new System.Drawing.Point(271, 475);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 23);
            this.label11.TabIndex = 115;
            this.label11.Text = "Giá gốc :";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmTrathuoc
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.handung);
            this.Controls.Add(this.soluong);
            this.Controls.Add(this.gianovat);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.giaban);
            this.Controls.Add(this.dang);
            this.Controls.Add(this.losx);
            this.Controls.Add(this.ngaysp);
            this.Controls.Add(this.sotien);
            this.Controls.Add(this.nhomcc);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.quay);
            this.Controls.Add(this.lydo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.khoban);
            this.Controls.Add(this.manguon);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.userid);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.hoten);
            this.Controls.Add(this.cmbSophieu);
            this.Controls.Add(this.ngayhd);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.sophieu);
            this.Controls.Add(this.makho);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.tenbd);
            this.Controls.Add(this.tenhc);
            this.Controls.Add(this.lTenhc);
            this.Controls.Add(this.butKetthuc);
            this.Controls.Add(this.butIn);
            this.Controls.Add(this.butHuy);
            this.Controls.Add(this.butBoqua);
            this.Controls.Add(this.butXoa);
            this.Controls.Add(this.butThem);
            this.Controls.Add(this.butLuu);
            this.Controls.Add(this.butSua);
            this.Controls.Add(this.butMoi);
            this.Controls.Add(this.dongia);
            this.Controls.Add(this.mabd);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.ldvt);
            this.Controls.Add(this.lTen);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.listDMBD);
            this.Controls.Add(this.stt);
            this.Controls.Add(this.tinhtrang);
            this.Controls.Add(this.makp);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTrathuoc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phiếu trả thuốc";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmTrathuoc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmTrathuoc_Load(object sender, System.EventArgs e)
		{
            //if (Screen.PrimaryScreen.WorkingArea.Width > 800) this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            i_maxlength_mabn = LibDuoc.AccessData.i_maxlength_mabn;
            sophieu.MaxLength = 10;
            bSotoa_thang = false;
            bDongia = true;// d.bDongia(i_nhom);
            bGiaban_danhmuc = d.bGiaban_danhmuc(i_nhom);
            bTrathuoc_xuatban = d.bTrathuoc_xuatban(i_nhom);
            user = d.user; xxx = user + s_mmyy;
			format_soluong=d.format_soluong(i_nhom);
			format_sotien=d.format_sotien(i_nhom);
			format_dongia=d.format_dongia(i_nhom);
			bNgtru_mabn=d.bNgtru_mabn;
			if (!bNgtru_mabn) lbl.Text="Số toa :";
			bKhoaso=d.bKhoaso(i_nhom,s_mmyy);
			i_songay=d.Ngaylv_Ngayht;

            dtdmnx = d.get_data("select * from " + user + ".d_dmnx where nhom=" + i_nhom).Tables[0];
            if (dtdmnx.Rows.Count > 0) i_madv = int.Parse(dtdmnx.Rows[0]["id"].ToString());
            else i_madv = 0;
			manguon.DisplayMember="TEN";
			manguon.ValueMember="ID";
			if (d.bQuanlynguon(i_nhom))
				manguon.DataSource=d.get_data("select * from "+user+".d_dmnguon where nhom="+i_nhom+" order by stt").Tables[0];
			else
                manguon.DataSource = d.get_data("select * from " + user + ".d_dmnguon where id=0 or nhom=" + i_nhom + " order by stt").Tables[0];

			makho.DisplayMember="TEN";
			makho.ValueMember="ID";
            sql = "select * from " + user + ".d_dmkho where nhom=" + i_nhom;
			if (s_makho!="") sql+=" and id in ("+s_makho.Substring(0,s_makho.Length-1)+")";
			sql+=" order by stt";
			makho.DataSource=d.get_data(sql).Tables[0];
			makho.SelectedIndex=0;

            nhomcc.DisplayMember = "TEN";
            nhomcc.ValueMember = "ID";
            if (d.bQuanlynhomcc(i_nhom))
                nhomcc.DataSource = d.get_data("select * from " + user + ".d_dmnx where nhom=" + i_nhom + " order by stt").Tables[0];
            else
                nhomcc.DataSource = d.get_data("select * from " + user + ".d_dmnx where id=0 or nhom=" + i_nhom + " order by stt").Tables[0];

            khoban.DisplayMember = "TEN";
            khoban.ValueMember = "ID";
            sql = "select * from " + user + ".d_dmkho where nhom=" + i_nhom;
            //if (s_makho != "") sql += " and id in (" + s_makho.Substring(0, s_makho.Length - 1) + ")";
            sql += " order by stt";
            khoban.DataSource = d.get_data(sql).Tables[0];
            if (khoban.Items.Count > 0) khoban.SelectedIndex = 0;
            //
            sql = "select * from " + user + ".d_dmloaint where nhom=" + i_nhom;
            if (s_loaint != "") sql += " and id in (" + s_loaint.Substring(0, s_loaint.Length - 1) + ")";
            sql += " order by stt";
            quay.DisplayMember = "TEN";
            quay.ValueMember = "ID";
            quay.DataSource = d.get_data(sql).Tables[0];

            lydo.DisplayMember = "TEN";
            lydo.ValueMember = "ID";
            lydo.DataSource = d.get_data("select * from " + user + ".d_dmlydo where nhom=" + i_nhom + " order by stt").Tables[0];

            userid.DisplayMember = "HOTEN";
            userid.ValueMember = "ID";
            sql = "select * from " + user + ".d_dlogin where nhomkho=" + i_nhom;
            sql += " order by hoten";
            userid.DataSource = d.get_data(sql).Tables[0];
            userid.SelectedIndex = 0;

			listDMBD.DisplayMember="TEN";
			listDMBD.ValueMember=(bTrathuoc_xuatban)?"STT":"MA";

            if (!bTrathuoc_xuatban) load_dm();

            sql = "select id,sophieu,to_char(ngaysp,'dd/mm/yyyy') as ngaysp,sohd,to_char(ngayhd,'dd/mm/yyyy') as ngayhd,bbkiem,to_char(ngaykiem,'dd/mm/yyyy') as ngaykiem,nguoigiao,madv,makho,manguon,nhomcc,no,co,lydo,chietkhau from " + xxx + ".d_nhapll where loai='" + s_loai + "' and nhom=" + i_nhom;
			sql+=" and to_char(ngaysp,'dd/mm/yyyy')='"+s_ngay+"'";
            if (!bAdmin) sql += " and userid=" + i_userid;
            //sql+="  and lydo=" + i_quayban;
			sql+=" order by id";
			dtll=d.get_data(sql).Tables[0];
			cmbSophieu.DisplayMember="SOPHIEU";
			cmbSophieu.ValueMember="ID";
			cmbSophieu.DataSource=dtll;
            l_id = (cmbSophieu.SelectedIndex != -1) ? decimal.Parse(cmbSophieu.SelectedValue.ToString()) : 0;
			load_grid();
			AddGridTableStyle();
			ref_text();
			dsxoa.ReadXml("..\\..\\..\\xml\\d_nhapct.xml");
		}

		private void load_grid()
		{
            sql = "select a.stt,a.mabd,b.ma,trim(b.ten)||' '||b.hamluong as ten,nullif(b.tenhc,' ') as tenhc,";
            sql += "b.dang,a.handung,a.losx,a.soluong,a.dongia,a.vat,a.sotien,round(a.soluong*a.giamua,2) as tongtien,";
            sql+="round(a.sotien+a.sotien*a.vat/100,3) as sotienvat,a.giaban,";
            sql+="a.giamua,c.ten as tenhang,d.ten as tennuoc,a.sl1,a.sl2,a.tyle,a.cuocvc,a.chaythu,a.namsx,";
            sql+="a.tailieu,a.baohanh,a.nguongoc,a.tinhtrang,a.sothe,a.giabancu,a.giamuacu,a.giaban2,";
            sql += "a.tyle2,a.tyle_ggia,a.st_ggia,a.haohut,a.giahaohut,a.sodangky ";
            sql+=" from " + xxx + ".d_nhapct a," + user + ".d_dmbd b," + user + ".d_dmhang c," + user + ".d_dmnuoc d where a.mabd=b.id and b.mahang=c.id and b.manuoc=d.id and a.id=" + l_id + " order by a.stt";
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
				d_soluong=(dataGrid1[i,7].ToString()!="")?decimal.Parse(dataGrid1[i,7].ToString()):0;
				d_dongia=(dataGrid1[i,8].ToString()!="")?decimal.Parse(dataGrid1[i,8].ToString()):0;
				d_sotien=(dataGrid1[i,9].ToString()!="")?decimal.Parse(dataGrid1[i,9].ToString()):0;
				d_giaban=(dataGrid1[i,12].ToString()!="")?decimal.Parse(dataGrid1[i,12].ToString()):0;
                decimal giagoc = (dataGrid1[i, 13].ToString() != "") ? decimal.Parse(dataGrid1[i, 13].ToString()) : 0;
				soluong.Text=d_soluong.ToString(format_soluong);
                gianovat.Text = giagoc.ToString(format_dongia);
				dongia.Text=d_dongia.ToString(format_dongia);
				sotien.Text=d_sotien.ToString(format_sotien);
				giaban.Text=d_giaban.ToString("#,###,###,##0");
                DataRow r = d.getrowbyid(dtct, "stt=" + decimal.Parse(stt.Text));
                if (r != null)
                {
                    handung.Text = r["handung"].ToString();
                    losx.Text = r["losx"].ToString();
                    nhomcc.SelectedValue = r["baohanh"].ToString();
                    tinhtrang.Text = r["tinhtrang"].ToString();
                }
				if (butLuu.Enabled)
				{
					r=d.getrowbyid(dtdmbd,"ma='"+mabd.Text+"'");
					if (r!=null)
					{
						i_mabd=int.Parse(r["id"].ToString());
						tenbd.Enabled=d.get_iXuat(s_mmyy,int.Parse(makho.SelectedValue.ToString()),l_id,int.Parse(stt.Text))==0;
						if (d.bNhapmaso) mabd.Enabled=tenbd.Enabled;
						soluong.Enabled=tenbd.Enabled;
						if (bDongia && !bTrathuoc_xuatban) dongia.Enabled=tenbd.Enabled;
						else if (!bTrathuoc_xuatban) sotien.Enabled=tenbd.Enabled;
                        if (bGiaban && !bTrathuoc_xuatban) giaban.Enabled = tenbd.Enabled;
					}
				}
                d_soluongcu = (bNew) ? 0 : d_soluong;
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
			TextCol.HeaderText = "Hạn dùng";
			TextCol.Width = 50;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "losx";
			TextCol.HeaderText = "Lô SX";
			TextCol.Width = 100;
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
			TextCol.MappingName = "giamua";
			TextCol.HeaderText = "Giá mua";
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
			TextCol.MappingName = "vat";
			TextCol.HeaderText = "";
			TextCol.Width = 0;
			ts.GridColumnStyles.Add(TextCol);
			dataGrid1.TableStyles.Add(ts);

			TextCol=new DataGridTextBoxColumn();
			TextCol.MappingName = "sotienvat";
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

            TextCol = new DataGridTextBoxColumn();
            TextCol.MappingName = "dongia";
            TextCol.HeaderText = "Giá gốc";
            TextCol.Width = 80;
            TextCol.Format = format_dongia;
            TextCol.Alignment = HorizontalAlignment.Right;
            ts.GridColumnStyles.Add(TextCol);
            dataGrid1.TableStyles.Add(ts);
		}

		private void load_dm()
		{
            if (bTrathuoc_xuatban)
            {
                dtdmbd = d.get_xuatban(ngayhd.Text, i_nhom, i_quayban, (bNgtru_mabn) ? sophieu.Text : "", (bNgtru_mabn) ? 0 : decimal.Parse(sophieu.Text), int.Parse(makho.SelectedValue.ToString()));
            }
            else
            {
                //dtdmbd = d.get_data("select id,ma,trim(ten)||' '||hamluong as ten,tenhc,trim(dang)||'/'||trim(donvi) as dang,id,dongia,giaban,dongia as gianovat from " + user + ".d_dmbd where nhom=" + i_nhom + " order by ten").Tables[0];
                dtdmbd = d.get_data("select ma,trim(ten)||' '||hamluong as ten,tenhc,trim(dang)||'/'||trim(donvi) as dang,id,dongia,giaban,dongia as gianovat from " + user + ".d_dmbd where nhom=" + i_nhom + " order by ten").Tables[0];
            }
			listDMBD.DataSource=dtdmbd;
		}

		private void sophieu_Validated(object sender, System.EventArgs e)
		{
			if (l_id!=0) return;
			try
			{
                if (bNgtru_mabn)
                {
                    if (sophieu.Text == "" || sophieu.Text.Trim().Length < 3) return;
                    if (sophieu.Text.Trim().Length != i_maxlength_mabn) sophieu.Text = sophieu.Text.Substring(0, 2) + sophieu.Text.Substring(2).PadLeft(i_maxlength_mabn - 2, '0');
                }
                if (bTrathuoc_xuatban)
                {
                    if (ngayhd.Text != "" && sophieu.Text != "")
                    {
                        sql = "select a.*,b.makp as kp from xxx.d_ngtrull a left join " + user + ".d_duockp b on a.makp=b.id where a.nhom=" + i_nhom + " and a.loai=" + i_quayban;
                        if(!bSotoa_thang)
                            sql += " and to_char(a.ngay,'dd/mm/yyyy')='" + ngayhd.Text + "' "; 
                        if (bNgtru_mabn) sql += " and a.mabn='" + sophieu.Text + "'";
                        else sql += " and a.sotoa=" + decimal.Parse(sophieu.Text);
                        foreach (DataRow r in d.get_data_mmyy(sql, ngayhd.Text, ngayhd.Text,true).Tables[0].Rows)
                        {
                            hoten.Text = r["hoten"].ToString();
                            makp.Text = r["kp"].ToString();
                            break;
                        }
                    }
                    load_dm();
                }
                else
                {
                    foreach (DataRow r1 in d.get_data("select hoten,namsinh,trim(sonha)||' '||trim(thon) as diachi from "+user+".btdbn where mabn='" + sophieu.Text + "'").Tables[0].Rows)
                    {
                        hoten.Text = r1["hoten"].ToString();
                        break;
                    }
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
				l_id=decimal.Parse(cmbSophieu.SelectedValue.ToString());
		
			}
			catch{l_id=0;}
			load_head();
		}

        private void load_head()
        {
            r = d.getrowbyid(dtll, "id=" + l_id);
            if (r != null)
            {
                sophieu.Text = r["sophieu"].ToString();
                ngaysp.Text = r["ngaysp"].ToString();
                makho.SelectedValue = r["makho"].ToString();
                manguon.SelectedValue = r["manguon"].ToString();
                hoten.Text = r["nguoigiao"].ToString();
                ngayhd.Text = r["ngayhd"].ToString();
                quay.SelectedValue = r["lydo"].ToString();
                userid.SelectedValue = r["no"].ToString();
                khoban.SelectedValue = r["co"].ToString();
                try
                {
                    lydo.SelectedValue = r["bbkiem"].ToString();
                }
                catch { }
                s_ngaysp = ngaysp.Text;
                makp.Text = r["chietkhau"].ToString();
            }
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
				dv.RowFilter="ten like '%"+ten.Trim()+"%'"+" or tenhc like '%"+ten.Trim()+"%'";
                if (bTrathuoc_xuatban) sql += " and soluong>0";
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
            if (!bTrathuoc_xuatban)
            {
                if (tenbd.Text != "" && mabd.Text == "")
                {
                    r = d.getrowbyid(dtdmbd, "ten='" + tenbd.Text + "'");
                    if (r != null)
                    {
                        mabd.Text = r["ma"].ToString();
                        dang.Text = r["dang"].ToString();
                        tenhc.Text = r["tenhc"].ToString();
                        d_dongia = decimal.Parse(r["dongia"].ToString());
                        d_giaban = decimal.Parse(r["giaban"].ToString());
                        gianovat.Text=dongia.Text = d_dongia.ToString(format_dongia);
                        giaban.Text = d_giaban.ToString("###,###,###,###0");
                    }
                }
            }
		}

		private void ena_object(bool ena)
		{
			sophieu.Visible=ena;
			cmbSophieu.Visible=!ena;
			sophieu.Enabled=ena;
			ngaysp.Enabled=ena;
			makho.Enabled=ena;
            if (d.bQuanlyhandung(i_nhom) && !bTrathuoc_xuatban) handung.Enabled = ena;
            if (d.bQuanlylosx(i_nhom) && !bTrathuoc_xuatban) losx.Enabled = ena;
			manguon.Enabled=ena;
            ngayhd.Enabled = ena;
            quay.Enabled = ena;
            userid.Enabled = ena;
            khoban.Enabled = ena;
			hoten.Enabled=ena;
            lydo.Enabled = ena;
			if (d.bNhapmaso) mabd.Enabled=ena;
			tenbd.Enabled=ena;
			soluong.Enabled=ena;
            if (bDongia && !bTrathuoc_xuatban) dongia.Enabled = ena;
			else if (!bTrathuoc_xuatban)sotien.Enabled=ena;
            if (bGiaban && !bTrathuoc_xuatban) giaban.Enabled = ena;
            if (!bTrathuoc_xuatban) nhomcc.Enabled = ena;
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
			if (d.bDanhmuc || d.bDmbd)
			{
				if (d.bDanhmuc) d.writeXml("d_thongso","c01","0");
				else d.writeXml("d_thongso","c06","0");
				if (!bTrathuoc_xuatban) load_dm();
			}
            //if (!ena)
            //{
                CurrencyManager cm = (CurrencyManager)BindingContext[cmbSophieu.DataSource];
                DataView dv = (DataView)cm.List;
                dv.RowFilter = "";
            //}
        }

		private void emp_head()
		{
			l_id=0;
            if (!bTrathuoc_xuatban)  cmbSophieu.Text = d.get_stt(dtll, "sophieu").ToString();//sophieu.Text = d.get_stt(dtll, "sophieu").ToString();
            else sophieu.Text = "";
			hoten.Text="";
			ngaysp.Text=s_ngay;
            if (ngayhd.Text.Trim().Length != 10) ngayhd.Text = s_ngay;
			makho.SelectedIndex=0;
            quay.SelectedValue = i_quayban.ToString();
			s_ngaysp=ngaysp.Text;
			dsxoa.Clear();
		}
		
		private void emp_detail()
		{
			handung.Text=losx.Text=mabd.Text=tenbd.Text="";
			gianovat.Text=tenhc.Text=dang.Text=soluong.Text=dongia.Text=sotien.Text="";
            giaban.Text = "0"; d_soluongcu = 0;
			stt.Text=d.get_stt(dtct).ToString();
		}
		private void butMoi_Click(object sender, System.EventArgs e)
		{
            aThem = false;
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
			dtold.Clear();
			emp_head();
			emp_detail();
			bNew=true;
            if (ngayhd.Enabled) ngayhd.Focus();
			else if (sophieu.Enabled) sophieu.Focus();
			else hoten.Focus();
		}
		private void butSua_Click(object sender, System.EventArgs e)
		{
			if (cmbSophieu.Items.Count==0) return;
			if (bKhoaso)
			{
				MessageBox.Show(lan.Change_language_MessageText("Số liệu tháng")+" "+s_mmyy.Substring(0,2)+" "+lan.Change_language_MessageText("năm")+" "+s_mmyy.Substring(2,2)+" "+lan.Change_language_MessageText("đã khóa !")+"\n"+lan.Change_language_MessageText("Nếu cần thay đổi thì vào mục khai báo hệ thống"),d.Msg);
				return;
			}
            if (!bThuhoi)
            {
                MessageBox.Show(lan.Change_language_MessageText("Bạn không có quyền chỉnh sửa !"), d.Msg);
                return;
            }
			l_id=decimal.Parse(cmbSophieu.SelectedValue.ToString());
			ena_object(true);
			bNew=false;
			dtold=dtct.Copy();
			dsxoa.Clear();
            if (bTrathuoc_xuatban) load_dm();
            if (ngayhd.Enabled) ngayhd.Focus();
			else sophieu.Focus();
			ref_text();
		}
		private bool KiemtraHead()
		{
			if (sophieu.Text=="")
			{
				MessageBox.Show(
lan.Change_language_MessageText("Nhập số toa !"),d.Msg);
				sophieu.Focus();
				return false;
			}
			if (ngaysp.Text=="")
			{
				MessageBox.Show(
lan.Change_language_MessageText("Nhập ngày số toa !"),d.Msg);
				ngaysp.Focus();
				return false;
			}

            if (ngayhd.Text.Trim().Length!=10)
            {
                MessageBox.Show(
lan.Change_language_MessageText("Nhập ngày bán !"), d.Msg);
                ngayhd.Focus();
                return false;
            }

            if (lydo.SelectedIndex == -1)
            {
                MessageBox.Show(lan.Change_language_MessageText("Nhập lý do !"), d.Msg);
                lydo.Focus();
                return false;
            }
			if (manguon.SelectedIndex==-1)
			{
				MessageBox.Show(
lan.Change_language_MessageText("Nhập nguồn hàng !"),d.Msg);
				manguon.Focus();
				return false;
			}

			if (makho.SelectedIndex==-1)
			{
				MessageBox.Show(
lan.Change_language_MessageText("Nhập kho nhập !"),d.Msg);
				makho.Focus();
				return false;
			}
            if (khoban.SelectedIndex == -1)
            {
                MessageBox.Show(
lan.Change_language_MessageText("Nhập kho bán !"), d.Msg);
                khoban.Focus();
                return false;
            }
            if (userid.SelectedIndex == -1)
            {
                MessageBox.Show(
lan.Change_language_MessageText("Người bán !"), d.Msg);
                userid.Focus();
                return false;
            }
            if (quay.SelectedIndex == -1)
            {
                MessageBox.Show(
lan.Change_language_MessageText("Quầy bán !"), d.Msg);
                quay.Focus();
                return false;
            }
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
			if ((soluong.Text=="" || soluong.Text=="0.00" || soluong.Text=="0" )&& aThem)
			{
				MessageBox.Show(
lan.Change_language_MessageText("Nhập số lượng !"),d.Msg);
				soluong.Focus();
				return false;
			}
			if (d.bGiaban(i_nhom) && giaban.Enabled)
			{
				try
				{
					d_dongia=(dongia.Text!="")?decimal.Parse(dongia.Text):0;
					d_giaban=(giaban.Text!="")?decimal.Parse(giaban.Text):0;
					if (d_giaban<d_dongia)
					{
						MessageBox.Show(lan.Change_language_MessageText("Giá bán không hợp lệ !"),d.Msg);
						giaban.Focus();
						return false;
					}
				}
				catch{return false;}
			}
			return true;
		}

		private void butLuu_Click(object sender, System.EventArgs e)
		{
            aThem = true;
            upd_table(dtct);
			dtct.AcceptChanges();
			if (!KiemtraHead()) return;
			i_old=(bNew)?0:1;
			l_id=(bNew)?d.get_id_nhap:l_id;
            itable = d.tableid(s_mmyy, "d_nhapll");
            if (bNew) d.upd_eve_tables(s_mmyy, itable, i_userid, "ins");
            else
            {
                d.upd_eve_tables(s_mmyy, itable, i_userid, "upd");
                d.upd_eve_upd_del(s_mmyy, itable, i_userid, "upd", l_id.ToString() + "^" + i_nhom.ToString() + "^" + sophieu.Text + "^" + ngaysp.Text + "^" + sophieu.Text + "^" + ngayhd.Text + "^" + lydo.SelectedValue.ToString() + "^" + "" + "^" + s_loai + "^" + hoten.Text + "^" + i_madv.ToString() + "^" + makho.SelectedValue.ToString() + "^" + manguon.SelectedValue.ToString() + "^" + i_madv.ToString() + "^" + userid.SelectedValue.ToString() + "^" + khoban.SelectedValue.ToString() + "^" + i_userid.ToString() + "^" + quay.SelectedValue.ToString());
            }
			if (!d.upd_nhapll(s_mmyy,l_id,i_nhom,sophieu.Text,ngaysp.Text,makp.Text,ngayhd.Text,lydo.SelectedValue.ToString(),"",s_loai,hoten.Text,i_madv,int.Parse(makho.SelectedValue.ToString()),int.Parse(manguon.SelectedValue.ToString()),i_madv,userid.SelectedValue.ToString(),khoban.SelectedValue.ToString(),i_userid,int.Parse(quay.SelectedValue.ToString()),(makp.Text!="")?decimal.Parse(makp.Text):0))
			{
				MessageBox.Show(lan.Change_language_MessageText("Không cập nhật được thông tin trả thuốc !"),d.Msg);
				return;
			}
            itable = d.tableid(s_mmyy, "d_nhapct");
			if (!bNew)
			{
                foreach (DataRow r1 in dsxoa.Tables[0].Rows)
                {
                    d.upd_eve_tables(s_mmyy, itable, i_userid, "del");
                    d.upd_eve_upd_del(s_mmyy, itable, i_userid, "del", d.fields(xxx + ".d_nhapct", "id=" + l_id + " and stt=" + int.Parse(r1["stt"].ToString())));
                    d.execute_data("delete from " + xxx + ".d_nhapct where id=" + l_id + " and stt=" + int.Parse(r1["stt"].ToString()));
                }
				foreach(DataRow r1 in dtold.Rows)
                    d.upd_tonkhoct_nhapct(d.delete, s_mmyy, ngaysp.Text, l_id, int.Parse(r1["stt"].ToString()), decimal.Parse(r1["soluong"].ToString()), decimal.Parse(r1["sotien"].ToString()), int.Parse(r1["vat"].ToString()), int.Parse(makho.SelectedValue.ToString()), int.Parse(manguon.SelectedValue.ToString()), 0, int.Parse(r1["mabd"].ToString()), r1["handung"].ToString(), r1["losx"].ToString(), decimal.Parse(r1["giaban"].ToString()), "", 0, 0, s_loai, 0, 0, int.Parse(r1["tinhtrang"].ToString()), i_nhom, "", 0, 1, 0, decimal.Parse(r1["giaban2"].ToString()), decimal.Parse(r1["giamua"].ToString()), decimal.Parse(r1["sotienvat"].ToString()), decimal.Parse(r1["tyle_ggia"].ToString()), decimal.Parse(r1["st_ggia"].ToString()), decimal.Parse(r1["dongia"].ToString()), bGiaban_danhmuc,"");
			}
			foreach(DataRow r1 in dtct.Rows)
			{
                if (d.get_data("select * from " + xxx + ".d_nhapct where id=" + l_id + " and stt=" + int.Parse(r1["stt"].ToString())).Tables[0].Rows.Count != 0)
                {
                    d.upd_eve_tables(s_mmyy, itable, i_userid, "upd");
                    d.upd_eve_upd_del(s_mmyy, itable, i_userid, "upd", l_id.ToString() + "^" + r1["stt"].ToString() + "^" + r1["mabd"].ToString() + "^" + r1["handung"].ToString() + "^" + r1["losx"].ToString() + "^" + r1["vat"].ToString() + "^" + r1["soluong"].ToString() + "^" + r1["dongia"].ToString() + "^" + r1["sotien"].ToString() + "^" + r1["giaban"].ToString() + "^" + r1["giamua"].ToString() + "^" + r1["sl1"].ToString() + "^" + r1["sl2"].ToString() + "^" + r1["tyle"].ToString() + "^" + "0" + "^" + "0" + "^" + "0" + "^" + "" + "^" + "0" + "^" + "0" + "^" + "0" + "^" + "" + "^" + r1["giabancu"].ToString());
                }
                else d.upd_eve_tables(s_mmyy, itable, i_userid, "ins");
                d.upd_nhapct(s_mmyy, l_id, int.Parse(r1["stt"].ToString()), int.Parse(r1["mabd"].ToString()), r1["handung"].ToString(), r1["losx"].ToString(), int.Parse(r1["vat"].ToString()), decimal.Parse(r1["soluong"].ToString()), decimal.Parse(r1["dongia"].ToString()), decimal.Parse(r1["sotien"].ToString()), decimal.Parse(r1["giaban"].ToString()), decimal.Parse(r1["giamua"].ToString()), decimal.Parse(r1["soluong"].ToString()), 1, 0, 0, 0, "", "",int.Parse(r1["baohanh"].ToString()), 0,int.Parse(r1["tinhtrang"].ToString()), "", 0, decimal.Parse(r1["giamua"].ToString()), decimal.Parse(r1["giaban2"].ToString()), decimal.Parse(r1["tyle2"].ToString()), decimal.Parse(r1["tyle_ggia"].ToString()), decimal.Parse(r1["st_ggia"].ToString()),"");
                d.upd_tonkhoct_nhapct(d.insert, s_mmyy, ngaysp.Text, l_id, int.Parse(r1["stt"].ToString()), decimal.Parse(r1["soluong"].ToString()), decimal.Parse(r1["sotien"].ToString()), int.Parse(r1["vat"].ToString()), int.Parse(makho.SelectedValue.ToString()), int.Parse(manguon.SelectedValue.ToString()), int.Parse(r1["baohanh"].ToString()), int.Parse(r1["mabd"].ToString()), r1["handung"].ToString(), r1["losx"].ToString(), decimal.Parse(r1["giaban"].ToString()), "", 0, 0, s_loai, 0, 0, int.Parse(r1["tinhtrang"].ToString()), i_nhom, "", 0, 1, 0, decimal.Parse(r1["giaban2"].ToString()), decimal.Parse(r1["giamua"].ToString()), decimal.Parse(r1["sotienvat"].ToString()), decimal.Parse(r1["tyle_ggia"].ToString()), decimal.Parse(r1["st_ggia"].ToString()), decimal.Parse(r1["dongia"].ToString()), bGiaban_danhmuc,"");
			}
			d.updrec_nhapll(dtll,l_id,sophieu.Text,ngaysp.Text,sophieu.Text,ngayhd.Text,lydo.SelectedValue.ToString(),"",hoten.Text,0,int.Parse(makho.SelectedValue.ToString()),int.Parse(manguon.SelectedValue.ToString()),userid.SelectedValue.ToString(),khoban.SelectedValue.ToString(),int.Parse(quay.SelectedValue.ToString()),0);
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
            aThem = false;
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

		private void butThem_Click(object sender, System.EventArgs e)
		{
            aThem = true;
			tenbd.Enabled=true;
            decimal asoluong = 0;
            if (bTrathuoc_xuatban)//gam 01-04-2011
            {
                foreach (DataRow r in dtdmbd.Select("ma like '" + mabd.Text.Trim() + "' and handung like '" + handung.Text + "'"))
                {
                    asoluong = decimal.Parse(r["soluong"].ToString()) - decimal.Parse(soluong.Text.ToString());
                    if (asoluong < 0)
                    {
                        MessageBox.Show("Số lượng xuất không được nhỏ hơn số lượng dự trù !");
                        return;
                    }
                    else if (asoluong >= 0)
                    {
                        r["soluong"] = asoluong;
                    }
                }
            }
            if (mabd.Enabled) mabd.Focus();
            else tenbd.Focus();
			if (d.bNhapmaso) mabd.Enabled=tenbd.Enabled;
			soluong.Enabled=tenbd.Enabled;
            if (bDongia && !bTrathuoc_xuatban) dongia.Enabled = tenbd.Enabled;
			else if (!bTrathuoc_xuatban) sotien.Enabled=tenbd.Enabled;
            if (bGiaban && !bTrathuoc_xuatban) giaban.Enabled = tenbd.Enabled;
			if (!upd_table(dtct)) return;
			emp_detail();
           
		}

		private void butXoa_Click(object sender, System.EventArgs e)
		{
            aThem = false;
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
			d_soluong=(soluong.Text!="")?decimal.Parse(soluong.Text):0;
			d_dongia=(dongia.Text!="")?decimal.Parse(dongia.Text):0;
			d_sotien=(sotien.Text!="")?decimal.Parse(sotien.Text):0;
			d_giaban=(giaban.Text!="")?decimal.Parse(giaban.Text):0;
            decimal giagoc = (gianovat.Text != "") ? decimal.Parse(gianovat.Text) : 0;            
            handung.Text = handung.Text.Trim().PadRight(4, '0');
            handung.Refresh();
			d.updrec_nhapct(dt,int.Parse(stt.Text),i_mabd,mabd.Text,tenbd.Text,tenhc.Text,dang.Text,handung.Text,losx.Text,d_soluong,(giagoc!=0)?giagoc:d_dongia,d_sotien,0,d_sotien,d_giaban,d_dongia,d_soluong,1,0,0,0,0,"",(nhomcc.SelectedIndex!=-1)?int.Parse(nhomcc.SelectedValue.ToString()):0,0,(tinhtrang.Text!="")?int.Parse(tinhtrang.Text):0,"",0,d_dongia,d_giaban,0,0,0,d_sotien,0,0,"");
			return true;
		}

		private void makho_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (makho.SelectedIndex==-1) makho.SelectedIndex=0;
				SendKeys.Send("{Tab}");
			}
		}

		private void mabd_Validated(object sender, System.EventArgs e)
		{
            if (!bTrathuoc_xuatban)
            {
                if (mabd.Text != "")
                {
                    r = d.getrowbyid(dtdmbd, "ma='" + mabd.Text + "'");
                    if (r != null)
                    {
                        tenbd.Text = r["ten"].ToString();
                        tenhc.Text = r["tenhc"].ToString();
                        dang.Text = r["dang"].ToString();
                        d_dongia = decimal.Parse(r["dongia"].ToString());
                        d_giaban = decimal.Parse(r["giaban"].ToString());
                        gianovat.Text=dongia.Text = d_dongia.ToString(format_dongia);
                        giaban.Text = d_giaban.ToString("###,###,###,##0");
                    }
                }
                if (!listDMBD.Focused) listDMBD.Hide();
            }
            else
            {
				sql="soluong>0 and ma like '"+mabd.Text.Trim()+"%'";
				DataRow [] dr=dtdmbd.Select(sql);
				if (dr.Length==1)
				{
					mabd.Text=dr[0]["stt"].ToString();
					get_items(decimal.Parse(mabd.Text));
					if(!listDMBD.Focused) listDMBD.Hide();
					soluong.Focus();
				}
            }
		}

		private void listDMBD_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
            if (!bTrathuoc_xuatban) mabd_Validated(null, null);
            else
            {
                try
                {
                    r = d.getrowbyid(dtdmbd, "soluong>=0 and stt=" + decimal.Parse(mabd.Text));
                    if (r != null)
                    {
                        mabd.Text = r["ma"].ToString();
                        tenbd.Text = r["ten"].ToString();
                        tenhc.Text = r["tenhc"].ToString();
                        dang.Text = r["dang"].ToString();
                        manguon.SelectedValue = r["manguon"].ToString();
                        //sttt.Text=r["sttt"].ToString();
                        nhomcc.SelectedValue=r["nhomcc"].ToString();
                        handung.Text = r["handung"].ToString();
                        losx.Text = r["losx"].ToString();
                        d_dongia = decimal.Parse(r["giamua"].ToString());
                        decimal giagoc = decimal.Parse(r["gianovat"].ToString());
                        d_giaban = decimal.Parse(r["giaban"].ToString());
                        dongia.Text = d_dongia.ToString(format_dongia);
                        gianovat.Text = giagoc.ToString(format_dongia);
                        giaban.Text = d_giaban.ToString("#,###,###,##0");
                        tinhtrang.Text=r["madoituong"].ToString();
                        listDMBD.Hide();
                        soluong.Focus();
                    }
                }
                catch { }
            }
		}

        private void get_items(decimal stt)
        {
            try
            {
                r = d.getrowbyid(dtdmbd, "soluong>0 and stt=" + stt);
                if (r != null)
                {
                    mabd.Text = r["ma"].ToString();
                    tenbd.Text = r["ten"].ToString();
                    tenhc.Text = r["tenhc"].ToString();
                    dang.Text = r["dang"].ToString();
                    manguon.SelectedValue = r["manguon"].ToString();
                    //sttt.Text=r["sttt"].ToString();
                    nhomcc.SelectedValue=r["nhomcc"].ToString();
                    handung.Text = r["handung"].ToString();
                    losx.Text = r["losx"].ToString();
                    decimal giagoc = decimal.Parse(r["gianovat"].ToString());
                    d_dongia = decimal.Parse(r["giamua"].ToString());
                    d_giaban = decimal.Parse(r["giaban"].ToString());
                    dongia.Text = d_dongia.ToString(format_dongia);
                    gianovat.Text = giagoc.ToString(format_dongia);
                    giaban.Text = d_giaban.ToString("#,###,###,##0");
                    tinhtrang.Text = r["madoituong"].ToString();
                    listDMBD.Hide();
                    soluong.Focus();
                }
            }
            catch { }
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
				if (bDongia)
				{
					d_dongia=(dongia.Text!="")?decimal.Parse(dongia.Text):0;
					d_sotien=Math.Round(d_soluong*d_dongia,3);
					sotien.Text=d_sotien.ToString(format_sotien);
				}
                else
                {
                    d_sotien = (sotien.Text != "") ? decimal.Parse(sotien.Text) : 0;
                    d_dongia = Math.Round(d_sotien / d_soluong, 3);
                    dongia.Text = d_dongia.ToString(format_dongia);
                }
				if (!bGiaban) giaban.Text=d_dongia.ToString("#,###,###,##0");
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
			}
			catch{}
			//upd_table(dtct);
			r=d.getrowbyid(dtdmbd,"ma='"+mabd.Text+"'");
			if (r!=null)
			{
                if (bTrathuoc_xuatban)
                {
                    decimal d_soluongton = decimal.Parse(r["soluong"].ToString())+ d_soluongcu;
                    if ((d_soluong > d_soluongton) && aThem)
                    {
                        MessageBox.Show(lan.Change_language_MessageText("Số lượng xuất lớn hơn số lượng mua !(") + d_soluongton.ToString() + ")", d.Msg);
                        soluong.Focus();
                        return;
                    }
                }
                else
                {
                    DataTable tmp = d.get_data("select a.*,trim(b.ten)||' '||trim(b.hamluong)||' '||trim(b.dang) as ten,trim(b.ten)||' '||b.hamluong as tenbd,b.dang,b.tenhc,b.ma,b.giaban,b.dongia from " + user + ".d_dmbdkemtheo a," + user + ".d_dmbd b where a.mabd=b.id and a.id=" + int.Parse(r["id"].ToString())).Tables[0];
                    if (tmp.Rows.Count > 0)
                    {
                        foreach (DataRow r1 in tmp.Rows)
                        {
                            i_mabd = int.Parse(r1["mabd"].ToString());
                            d.updrec_nhapct(dtct, d.get_stt(dtct), i_mabd, mabd.Text, r1["tenbd"].ToString(), r1["tenhc"].ToString(), r1["dang"].ToString(), "", "", decimal.Parse(r1["soluong"].ToString()), decimal.Parse(r1["dongia"].ToString()), decimal.Parse(r1["soluong"].ToString()) * decimal.Parse(r1["dongia"].ToString()), 0, decimal.Parse(r1["soluong"].ToString()) * decimal.Parse(r1["dongia"].ToString()), decimal.Parse(r1["giaban"].ToString()), decimal.Parse(r1["giamua"].ToString()), decimal.Parse(r1["soluong"].ToString()), 1, 0, 0, 0, 0, "", 0, 0, 0, "", 0, decimal.Parse(r1["giamua"].ToString()), decimal.Parse(r1["giaban2"].ToString()), decimal.Parse(r1["tyle2"].ToString()), 0, 0, decimal.Parse(r1["soluong"].ToString()) * decimal.Parse(r1["dongia"].ToString()),0,0,"");
                        }
                    }
                }
			}
			tinh_giatri();
		}

		private void butHuy_Click(object sender, System.EventArgs e)
		{
            aThem = false;
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
                if (!bThuhoi)
                {
                    MessageBox.Show(lan.Change_language_MessageText("Bạn không có quyền hủy !"), d.Msg);
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
				if (MessageBox.Show(
lan.Change_language_MessageText("Đồng ý hủy số phiếu này ?"),d.Msg,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
				{
					l_id=decimal.Parse(cmbSophieu.SelectedValue.ToString());
                    itable = d.tableid(s_mmyy, "d_nhapct");
                    foreach (DataRow r1 in dtct.Rows)
                    {
                        d.upd_eve_tables(s_mmyy, itable, i_userid, "del");
                        d.upd_eve_upd_del(s_mmyy, itable, i_userid, "del", d.fields(xxx + ".d_nhapct", "id=" + l_id + " and stt=" + int.Parse(r1["stt"].ToString())));
                        d.upd_tonkhoct_nhapct(d.delete, s_mmyy, ngaysp.Text, l_id, int.Parse(r1["stt"].ToString()), decimal.Parse(r1["soluong"].ToString()), decimal.Parse(r1["sotien"].ToString()), int.Parse(r1["vat"].ToString()), int.Parse(makho.SelectedValue.ToString()), int.Parse(manguon.SelectedValue.ToString()), int.Parse(r1["baohanh"].ToString()), int.Parse(r1["mabd"].ToString()), r1["handung"].ToString(), r1["losx"].ToString(), decimal.Parse(r1["giaban"].ToString()), "", 0, 0, s_loai, 0, 0, 0, i_nhom, "", 0, 1, 0, decimal.Parse(r1["giaban2"].ToString()), decimal.Parse(r1["giamua"].ToString()), decimal.Parse(r1["sotienvat"].ToString()), decimal.Parse(r1["tyle_ggia"].ToString()), decimal.Parse(r1["st_ggia"].ToString()), decimal.Parse(r1["dongia"].ToString()), bGiaban_danhmuc,"");
                    }
                    itable = d.tableid(s_mmyy, "d_nhapll");
                    d.upd_eve_tables(s_mmyy, itable, i_userid, "del");
                    d.upd_eve_upd_del(s_mmyy, itable, i_userid, "del", d.fields(xxx + ".d_nhapll", "id=" + l_id));
                    d.execute_data("delete from " + xxx + ".d_nhapct where id=" + l_id);
                    d.execute_data("delete from " + xxx + ".d_nhapll where id=" + l_id);
					d.delrec(dtll,"id="+l_id);
					cmbSophieu.Refresh();
					load_grid();
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
				giaban.Text=d_giaban.ToString("#,###,###,##0");
				if (d.bGiaban(i_nhom))
				{
					if (d_giaban<d_dongia)
					{
						MessageBox.Show(
lan.Change_language_MessageText("Giá bán không hợp lệ !"),d.Msg);
						giaban.Focus();
						return;
					}
				}
			}
			catch{giaban.Text="0";}
		}

		private void butIn_Click(object sender, System.EventArgs e)
		{	
			if (dtct.Rows.Count==0) return;
			string s_tenkho=(s_makho=="")?"":makho.Text;
			if (d.bPreview)
			{
				frmReport f=new frmReport(d,dtct,i_userid ,"d_trathuoc.rpt",cmbSophieu.Text,hoten.Text,lydo.Text,"",ngaysp.Text,s_userid,"","","","");
				f.ShowDialog();
			}
			else
			{
				ReportDocument oRpt=new ReportDocument();
				oRpt.Load("..\\..\\..\\report\\d_trathuoc.rpt",OpenReportMethod.OpenReportByTempCopy);
				oRpt.SetDataSource(dtct);
				oRpt.DataDefinition.FormulaFields["soyte"].Text="'"+d.Syte+"'";
				oRpt.DataDefinition.FormulaFields["benhvien"].Text="'"+d.Tenbv+"'";
				oRpt.DataDefinition.FormulaFields["c1"].Text="'"+cmbSophieu.Text+"'";
				oRpt.DataDefinition.FormulaFields["c2"].Text="'"+hoten.Text+"'";
				oRpt.DataDefinition.FormulaFields["c3"].Text="'"+lydo.Text+"'";
				oRpt.DataDefinition.FormulaFields["c4"].Text="";
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
				if (butMoi.Enabled) return;
				Filter_dmbd(tenbd.Text);
                if (bTrathuoc_xuatban)
                    listDMBD.Tutrucct_taisan(tenbd, mabd, soluong, mabd.Location.X, mabd.Location.Y + mabd.Height - 2, mabd.Width + lTen.Width + tenbd.Width + lTenhc.Width + tenhc.Width - 15, mabd.Height + 5);
                else
				    listDMBD.BrowseToDmbd(tenbd,mabd,soluong,mabd.Location.X,mabd.Location.Y + mabd.Height-2,mabd.Width+lTen.Width+tenbd.Width+lTenhc.Width+tenhc.Width-15,mabd.Height+5);
			}
		}

		private void mabd_TextChanged(object sender, System.EventArgs e)
		{
			if (this.ActiveControl==mabd)
			{
				if (butMoi.Enabled) return;
				Filter_mabd(mabd.Text);
                if (bTrathuoc_xuatban)
                    listDMBD.Tutrucct_taisan(mabd, tenbd, soluong, mabd.Location.X, mabd.Location.Y + mabd.Height - 2, mabd.Width + lTen.Width + tenbd.Width + lTenhc.Width + tenhc.Width - 15, mabd.Height + 5);
                else
				    listDMBD.BrowseToDmbd(mabd,tenbd,soluong,mabd.Location.X,mabd.Location.Y + mabd.Height-2,mabd.Width+lTen.Width+tenbd.Width+lTenhc.Width+tenhc.Width-15,mabd.Height+5);
			}
		}

		private void Filter_mabd(string ma)
		{
			try
			{
				CurrencyManager cm= (CurrencyManager)BindingContext[listDMBD.DataSource];
				DataView dv=(DataView)cm.List;
				dv.RowFilter="ma like '%"+ma.Trim()+"%'";
                if (bTrathuoc_xuatban) sql += " and soluong>0";
			}
			catch{}
		}

		private void manguon_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode==Keys.Enter || e.KeyCode==Keys.Tab)
			{
				if (manguon.SelectedIndex==-1) manguon.SelectedIndex=0;
				SendKeys.Send("{Tab}{F4}");
			}
		}

        private void ngayhd_Validated(object sender, EventArgs e)
        {
            if (ngayhd.Text == "") return;
            ngayhd.Text = ngayhd.Text.Trim();
            if (!d.bNgay(ngayhd.Text))
            {
                MessageBox.Show(
lan.Change_language_MessageText("Ngày không hợp lệ !"), d.Msg);
                ngayhd.Focus();
                return;
            }
            ngayhd.Text = d.Ktngaygio(ngayhd.Text, 10);
        }

        private void quay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (quay.SelectedIndex == -1) quay.SelectedIndex = 0;
                SendKeys.Send("{Tab}{F4}");
            }
        }

        private void userid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (userid.SelectedIndex == -1) userid.SelectedIndex = 0;
                SendKeys.Send("{Tab}{F4}");
            }
        }

        private void khoban_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (khoban.SelectedIndex == -1) khoban.SelectedIndex = 0;
                SendKeys.Send("{Tab}{F4}");
            }
        }

        private void lydo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (lydo.SelectedIndex == -1 && lydo.Items.Count > 0) lydo.SelectedIndex = 0;
                SendKeys.Send("{Tab}");
            }
        }

        private void nhomcc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void losx_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{Tab}");
        }

        private void gianovat_Validated(object sender, EventArgs e)
        {
            try
            {
                d_dongia = (gianovat.Text != "") ? decimal.Parse(gianovat.Text) : 0;
                gianovat.Text = d_dongia.ToString(format_dongia);
            }
            catch { gianovat.Text = "0"; }
        }
	}
}
